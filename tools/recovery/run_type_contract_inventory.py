"""Bounded metadata-only original/core type header and generic-constraint audit."""
import datetime as dt,importlib.util,json,mmap,shutil,struct,sys,uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent
spec=importlib.util.spec_from_file_location('header_guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
sys.path.insert(0,str(HERE.parent));from metadata_projection_subset import array_rows
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'));from native_metadata import NativeMetadata
from audit_forwarding import EXPECTED
def need(b,s):
 if not b:raise ValueError(s)
def main():
 stamp=dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8];out=g.ROOT/'Validation'/('TypeContractInventory-'+stamp);out.mkdir();report={'phases':[],'project_modified':False,'game_code_executed':False}
 try:
  manifest=g.ROOT/'CompilerRepairs/RuntimeSourcePlacementProjection-20261022T104037Z-a6651f58/metadata-restoration.json';reference=g.ROOT/'CompilerRepairs/ReferenceProjection-20261022T061434Z-45058b36/reference-projection.json';types=list(array_rows(manifest,'source_type_inventory'));aliases=[{'assembly':'Assembly-CSharp','original':r['original_full_name'],'compiled':r['compiled_full_name']} for r in types]
  for assembly in array_rows(reference,'assemblies'):
   if assembly['assembly_name']=='Assembly-CSharp':continue
   aliases.extend({'assembly':assembly['assembly_name'],'original':r['original_full_name'],'compiled':r['compiled_full_name']} for r in assembly['types'])
  actual=g.ROOT/'Validation/CompileCheck-20261022T104058Z-8b5ef50d/Assembly-CSharp.dll';raw=g.ROOT/'ScriptRecoveryModernLayout/Attempt-20261022T021923Z-2fcf0245/Output/Assembly-CSharp.dll';initial=g.ROOT/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll';inputFile=out/'input.json';inputFile.write_text(json.dumps({'types':types,'aliases':aliases,'compiled':str(actual),'raw':str(raw),'initial':str(initial)}));inputs=[manifest,reference,actual,raw,initial,inputFile];report['inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in inputs]
  pilot=g.ROOT/'CompilerRepairs/MetadataRestorationPilot';sources=[HERE/'TypeContractInventory.cs',pilot/'CanonicalMetadataSignatures.cs',pilot/'ProjectedCanonicalSignatures.cs'];deps=[HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll'];report['sources']=[{'path':str(p),'sha256':g.sha(p)} for p in sources];host=out/'TypeContractInventory.dll';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/nullable:enable','/langversion:latest','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+deps]+['"'+str(p)+'"' for p in sources])+'\n');g.phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile',report,maximum=120,cap=.25)
  for p in deps:shutil.copyfile(p,out/p.name)
  host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));headers=out/'raw-type-headers.jsonl';differences=out/'differences.json';g.phase([g.DOTNET,host,'--input',inputFile,'--headers',headers,'--output',differences],out,'metadata-only-contract-differences',report,maximum=120,cap=.25)
  expected={row['original']:row['raw_flags'] for row in map(json.loads,headers.read_text().splitlines())};paths=[]
  for rel,digest in EXPECTED.items():p=g.ROOT/'CodeSource'/rel;need(g.sha(p)==digest,'Verified native source SHA differs');paths.append(p)
  nativeRows=[]
  with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as binary,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
   v=NativeMetadata(binary,md)
   for index in range(v.count('typeDefinitions',88)):
    name=v.full_name(index)
    if name not in expected or v.image_of_type(index)['name']!='Assembly-CSharp.dll':continue
    at=v.row('typeDefinitions',index,88);flags=v.u32(v.m,at+28);nativeRows.append({'original':name,'original_native_metadata_index':index,'original_native_token':hex(v.u32(v.m,at+84)),'original_native_flags':flags,'raw_provider_flags':expected[name],'exact_match':flags==expected[name]})
  need(len(nativeRows)==len(expected) and all(r['exact_match'] for r in nativeRows),'Raw type provider flags differ from exact original native metadata');(out/'native-type-flag-proof.json').write_text(json.dumps({'types':nativeRows,'exact_match_count':len(nativeRows),'inputs':[{'path':str(p),'sha256':g.sha(p)} for p in paths]},indent=2)+'\n');need(all(g.sha(Path(r['path']))==r['sha256'] for r in report['inputs']+report['sources']),'Input drift during audit');summary=json.loads(differences.read_text());report['summary']={k:v for k,v in summary.items() if k not in ('type_differences','generic_method_changes','unmatched_generic_methods')};report['native_raw_TypeAttributes_exact_matches']=len(nativeRows);report['differences']={'path':str(differences),'sha256':g.sha(differences)};report['status']='completed';return 0
 except Exception as error:report['status']='failed';report['error']=str(error);return 1
 finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'output':str(out),'status':report['status'],'summary':report.get('summary'),'error':report.get('error')}))
if __name__=='__main__':raise SystemExit(main())
