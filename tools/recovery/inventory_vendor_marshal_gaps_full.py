"""Full790-owner ledger; source data only, never guesses missing marshal blobs."""
from pathlib import Path
import hashlib,importlib.util,json,mmap,sys
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';PLAN=ROOT/'Validation/Mono64CoreSignature-20261022T151506Z-476ee90a/plan.json';FLAGS=ROOT/'Validation/NativePluginMethodFlagsComparison-20261022T101648Z/report.json';sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'));from audit_cli_marshal_contracts import Cli,need;from join_actual_marshal_native import Signatures;from native_metadata import NativeMetadata
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def main():
 p=json.loads(PLAN.read_text());wanted={r['image'] for r in p['malformed_dependency_marshal_owners']};proof=json.loads(FLAGS.read_text());maps={r['assembly']+'.dll':r for r in proof['assemblies']};captured=[];errors=[];rows=[]
 for module in p['references']:
  if module['image'] not in wanted:continue
  path=Path(module['path']);need(sha(path)==module['sha256'],'Pinned plugin changed');item=maps[module['image']];need(sha(Path(item['stage_DLL']))==item['stage_DLL_sha256']==module['sha256'],'Exact native method audit DLL hash must match candidate');mapfile=Path(item['joined_token_map']);need(sha(mapfile)==item['joined_token_map_sha256'],'Native token map changed');tokenmap={int(r['s'],16):r for r in (json.loads(l) for l in mapfile.read_text().splitlines())}
  with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
   c=Cli(b);sig=Signatures(c);a=c.audit()
   for r in a['flagged_parameters']:
    if not r['malformed_flag_without_blob']:continue
    m=r['method'];t=tokenmap.get(int(m['current_token'],16));need(t is not None,'Flagged current method lacks proven original token map');rows.append({'image':module['image'],'kind':'parameter','current_cli_method_token':m['current_token'],'original_method_token':t['n'],'native_method_index':t['i'],'owner':m['owner']['display_owner'],'method':m['name'],'parameter_sequence':r['sequence'],'parameter_name':r['parameter_name'],'current_parameter_token':r['current_parameter_token'],'flags':r['flags'],'current_method_flags':m['flags'],'current_impl_flags':m['impl_flags'],'CLI_full_signature':sig.method(m['signature_hex']),'descriptor_blob':'MISSING_NO_DEFAULT_INFERRED','source_DLL':{'path':str(path),'sha256':module['sha256']}})
   for r in a['flagged_fields']:
    if r['malformed_flag_without_blob']:rows.append({'image':module['image'],'kind':'field','owner':r['owner']['display_owner'],'field':r['name'],'current_cli_field_token':r['current_field_token'],'type':sig.field(int(r['current_field_token'],16)&0xffffff),'flags':r['flags'],'descriptor_blob':'MISSING_NO_DEFAULT_INFERRED','source_DLL':{'path':str(path),'sha256':module['sha256']}})
 need(len(rows)==790,'Exact known vendor gap count differs');need(len({(r['image'],r['kind'],r.get('current_parameter_token',r.get('current_cli_field_token'))) for r in rows})==790,'Duplicate gap owners')
 binary=ROOT/'CodeSource/GameAssembly.dll';metadata=ROOT/'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat';need(sha(binary)=='ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b' and sha(metadata)=='1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474','Original source pins changed')
 with binary.open('rb') as bf,metadata.open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
  v=NativeMetadata(b,m);fieldwanted={(r['image'],r['owner'],r['field']):r for r in rows if r['kind']=='field'};typewanted={(r['image'],r['owner']) for r in fieldwanted.values()};fieldfound=set()
  for image in v.images:
   if image['name'] not in wanted:continue
   for ti in range(image['start'],image['start']+image['count']):
    owner=v.full_name(ti)
    if (image['name'],owner) not in typewanted:continue
    at=v.row('typeDefinitions',ti,88);first=v.i32(m,at+32);count=v.u16(m,at+68)
    for ordinal,fi in enumerate(range(first,first+count)):
     fa=v.row('fields',fi,12);name=v.string(v.i32(m,fa));key=(image['name'],owner,name)
     if key not in fieldwanted:continue
     r=fieldwanted[key];t=v.native_type(v.i32(m,fa+4));need(r['flags']==t['attributes'],'Native field flag ownership differs');display={24:'System.IntPtr',25:'System.UIntPtr'}.get(t['kind']) or v.typename(t);need(display==r['type'],'Native exact field type differs');need(key not in fieldfound,'Ambiguous original field');fieldfound.add(key);r.update(native_field_index=fi,original_field_token=hex(v.u32(m,fa+8)),native_owner_type_index=ti,original_type_token=hex(v.u32(m,at+84)),original_field_ordinal=ordinal,native_flags_and_type_ownership_exact=True)
  need(len(fieldfound)==len(fieldwanted),'Some790 field owners not joined to original native fields')
  for r in rows:
   if r['kind']!='parameter':continue
   mi=r['native_method_index'];ma=v.row('methods',mi,32);need(hex(v.u32(m,ma+20))==r['original_method_token'] and v.full_name(v.i32(m,ma+4))==r['owner'] and v.string(v.i32(m,ma))==r['method'],'Original method token/owner/name differs');need(v.u16(m,ma+24)==r['current_method_flags'] and v.u16(m,ma+26)==r['current_impl_flags'],'Native method flags differ');sequence=r['parameter_sequence'];need(1<=sequence<=v.u16(m,ma+30),'Original nonreturn parameter sequence required');pi=v.i32(m,ma+12)+sequence-1;pa=v.row('parameters',pi,12);nt=v.native_type(v.i32(m,pa+8));need(nt['attributes']==r['flags'] and v.string(v.i32(m,pa))==r['parameter_name'],'Original parameter flags/name differ');r.update(native_parameter_index=pi,original_parameter_token=hex(v.u32(m,pa+4)),native_flags_and_parameter_ownership_exact=True)
 dest=PLAN.parent/'vendor-marshal-gaps-full.jsonl';need(not dest.exists(),'Fresh full ledger');
 with dest.open('w') as f:
  for r in rows:f.write(json.dumps(r,separators=(',',':'))+'\n')
 report={'schema':'all790-normalized-vendor-dangling-marshal-owners-original-native-join/v1','status':'complete_native_ownership_proven_descriptors_still_missing','owners':len(rows),'fields':sum(r['kind']=='field' for r in rows),'parameters':sum(r['kind']=='parameter' for r in rows),'modules':len(wanted),'all_native_flag_ownership_matched':True,'missing_descriptor_blobs_recovered':False,'default_descriptor_or_flag_clearing_applied':False,'ledger':{'path':str(dest),'sha256':sha(dest)},'inputs':[{'path':str(x),'sha256':sha(x)} for x in [PLAN,FLAGS,binary,metadata]],'project_modified':False,'game_or_native_vendor_code_executed':False};target=PLAN.parent/'vendor-marshal-gaps-native-ownership.json';target.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(target),'sha256':sha(target),'owners':790,'fields':report['fields'],'parameters':report['parameters']}))
if __name__=='__main__':main()
