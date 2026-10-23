"""Read-only native/CLI and cached-source inventory; no SDK/game code is loaded."""
import collections,datetime,hashlib,importlib.util,json,mmap,re,sys,tarfile,uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]
ROOT=WS/'Recovery/RecRoom-2023-04-18'
BASE=ROOT/'Validation/AllOriginalScripts-20261022T145115Z-25a68695'
CACHE=Path('C:/Users/andre/AppData/Local/Unity/cache/npm/packages.unity.com')
sp=importlib.util.spec_from_file_location('scoped_cli',HERE/'audit_hashable_scoped_vtable.py');h=importlib.util.module_from_spec(sp);sp.loader.exec_module(h)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def pin(p):return {'path':str(p),'sha256':sha(p)}
def need(v,s):
 if not v:raise ValueError(s)
def rows(p):
 with p.open(encoding='utf-8') as f:return [json.loads(s) for s in f]
def body(c,token):
 at=c.row(6,int(token,16)&0xffffff);rva=c.u32(at)
 if not rva:return {'rva':0,'IL_hex':None,'bytes':0}
 start=c.raw(rva,1);first=c.b[start]
 if first&3==2:size=first>>2;code=start+1
 else:
  need(first&3==3,'IL header');header=(c.u16(start)>>12)*4;need(header>=12,'Fat IL header');size=c.u32(start+4);code=start+header
 need(code+size<=len(c.b),'IL range');return {'rva':rva,'IL_hex':bytes(c.b[code:code+size]).hex() if size<=128 else None,'bytes':size}
def main():
 out=ROOT/'RuntimeSDKRecovery'/('OriginalRenderingSDKSourceAudit-'+datetime.datetime.now(datetime.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 packages=[];sources={};by_pkg={}
 for pkg in ['com.unity.render-pipelines.core','com.unity.render-pipelines.universal']:
  tar=CACHE/pkg/'10.8.1/package.tgz';files={}
  with tarfile.open(tar,'r:gz') as archive:
   members=archive.getmembers();names=[m.name for m in members];need(len(names)==len(set(names)),'Duplicate tar members')
   for m in members:
    if m.name.startswith('package/Runtime/') and (m.name.endswith('.cs') or m.name.endswith('.asmdef')):
     need(m.isfile() and m.size<2*1024*1024,'Regular bounded source required');files[m.name]=archive.extractfile(m).read().decode('utf-8-sig')
   metadata=json.loads(archive.extractfile('package/package.json').read());need(metadata['version']=='10.8.1' and metadata['name']==pkg,'Cache metadata identity')
  source_rows=[{'archive_member':name,'sha256_UTF8_text':hashlib.sha256(text.encode('utf-8')).hexdigest(),'lines':len(text.splitlines())} for name,text in sorted(files.items())]
  identifiers=set(re.findall(r'\b[A-Za-z_]\w*\b','\n'.join(files.values())))
  by_pkg[pkg]={'files':files,'identifiers':identifiers}
  packages.append({'cache_archive':pin(tar),'package_json':pin(CACHE/pkg/'10.8.1/package/package.json'),'package_metadata':metadata,'runtime_CSharp_files':sum(n.endswith('.cs') for n in files),'runtime_asmdefs':[{'archive_member':n,'definition':json.loads(t)} for n,t in files.items() if n.endswith('.asmdef')],'source_members':source_rows,'cache_package_source_provenance':'Existing local Unity npm registry cache; no network provenance refresh or managed compilation in this audit','exact_original_package_version_proven':False})
 assemblies=[];evidence=[]
 selected={'UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset':{'CreatePipeline'},'UnityEngine.Rendering.Universal.UniversalRenderPipeline':{'Render'},'UnityEngine.Rendering.VolumeManager':{'Update'}}
 for assembly,pkg in [('Unity.RenderPipelines.Core.Runtime.dll','com.unity.render-pipelines.core'),('Unity.RenderPipelines.Universal.Runtime.dll','com.unity.render-pipelines.universal')]:
  nt=BASE/(assembly+'.types.jsonl');nm=BASE/(assembly+'.methods.jsonl');types=rows(nt);methods=rows(nm)
  identifiers=by_pkg[pkg]['identifiers'];missing=[]
  for typ in types:
   simple=typ['full_name'].split('/')[-1].split('.')[-1].split('`')[0]
   if any(x in simple for x in ['<','>']) or typ['full_name'].startswith(('Microsoft.CodeAnalysis.','System.Runtime.CompilerServices.')):continue
   if simple not in identifiers:missing.append(typ)
  current=WS/'RR23/Assets/Plugins'/assembly
  current_types=[]
  with current.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as data:
   c=h.m.cli.Cli(data);r=h.Read(c);refs=[h.m.identity(c,35,i) for i in range(1,c.rows[35]+1)]
   for rid in range(1,c.rows[2]+1):
    name=r.definition(rid)
    if name not in selected:continue
    actual_methods=[]
    for m in r.methods(rid):
     if m['name'] in selected[name]:actual_methods.append(m|{'body':body(c,m['token'])})
    current_types.append({'owner':name,'current_type_token':hex(0x02000000|rid),'methods':actual_methods})
   identity=r.asm;table_counts={'types':c.rows[2],'fields':c.rows[4],'methods':c.rows[6],'properties':c.rows[23],'events':c.rows[20]}
  critical=[]
  if pkg.endswith('universal'):
   owners={'UnityEngine.Rendering.Universal.UniversalRenderPipeline','UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset','UnityEngine.Rendering.Universal.RecRoomQualityConfig','UnityEngine.Rendering.Universal.IRecRoomQualityConfigProvider','UnityEngine.Rendering.Universal.UrpRecRoomQualityConfigProvider'}
   for m in methods:
    if m['owner'] not in owners or m['name'] in {'.ctor','.cctor'}:continue
    name=re.sub(r'^(get_|set_|add_|remove_)','',m['name'])
    if '<' not in name and name not in identifiers:critical.append(m)
  assemblies.append({'assembly':assembly,'native_type_inventory':pin(nt),'native_method_inventory':pin(nm),'original_native_types_including_module_and_generated':len(types),'original_native_methods':len(methods),'original_native_fields':sum(t['field_count'] for t in types if t['field_count']>0),'actual_Main_DLL':pin(current),'actual_assembly_full_identity':identity,'actual_table_counts':table_counts,'actual_references_full_identity':refs,'live_critical_method_bodies':current_types,'native_type_identifiers_absent_from_every_stock_runtime_source':missing,'native_custom_method_or_accessor_identifiers_absent_from_every_stock_runtime_source':critical,'absence_check_limit':'Identifier absence proves no literal declaration in this stock source set; identifier presence is not a signature/layout/body equivalence claim.'})
 for pkg,paths in [('com.unity.render-pipelines.universal',['package/Runtime/Data/UniversalRenderPipelineAsset.cs','package/Runtime/UniversalRenderPipeline.cs']),('com.unity.render-pipelines.core',['package/Runtime/Volume/VolumeManager.cs'])]:
  for path in paths:
   text=by_pkg[pkg]['files'].get(path)
   if text is None:continue
   lines=text.splitlines()
   for i,line in enumerate(lines):
    if 'override RenderPipeline CreatePipeline(' in line or 'override void Render(' in line or ('void Update(' in line and 'Volume' in path):evidence.append({'package':pkg,'archive_member':path,'source_sha256_UTF8_text':hashlib.sha256(text.encode()).hexdigest(),'line':i+1,'excerpt':'\n'.join(lines[i:i+26]),'source_body_is_available':True,'native_equivalent_body_proven':False})
 report={'schema':'original-rendering-SDK-native-contract-vs-local-source-candidate/v1','status':'stock_replacement_rejected_original_custom_fork_requires_exact_recovery','packages':packages,'native_and_actual_assemblies':assemblies,'genuine_source_body_witnesses':evidence,'conclusions':['Both cached package candidates are version10.8.1 with Unity2020.3.18f1 minimum; original assembly versions0.0.0.0 do not prove this exact package version.','Original URP has Rec Room-specific quality/configuration types and render API absent from stock10.8.1; wholesale replacement cannot preserve original API/layout/behavior.','Current Main CreatePipeline is ldnull;ret and UniversalRenderPipeline.Render is ret. This is a real render-loop recovery gap separate from shader payload recovery.','Stock official source can support a native-anchored per-member or proven whole-contract recovery; no source body is accepted here merely because its method name matches.','Next bounded step, after the actual Windows build: compile untouched10.8.1 PlayerWindows/Editor profiles outsideMain, compare complete native API/layout/flags/constants/serialization/assembly scopes; preserve every custom member and platform branch. Native proof is required for any transplanted member.'],'Main_modified':False,'package_manifest_modified':False,'managed_or_Unity_or_game_code_invoked':False,'source_archive_extracted_to_Main':False,'tool':pin(Path(__file__))}
 path=out/'report.json';path.write_text(json.dumps(report,indent=2)+'\n')
 print(json.dumps({'report':str(path),'sha256':sha(path),'stock_swap_permitted':False,'Main_modified':False,'managed_invoked':False,'assemblies':[{'name':a['assembly'],'native_types':a['original_native_types_including_module_and_generated'],'native_methods':a['original_native_methods'],'absent_type_identifiers':len(a['native_type_identifiers_absent_from_every_stock_runtime_source']),'absent_custom_method_identifiers':len(a['native_custom_method_or_accessor_identifiers_absent_from_every_stock_runtime_source'])} for a in assemblies]}))
if __name__=='__main__':main()
