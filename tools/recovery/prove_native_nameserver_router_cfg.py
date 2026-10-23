"""Whole-opcode native router proof and uninstalled finite nameserver override plan."""
import datetime,hashlib,importlib.util,json,mmap,struct,sys,uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from audit_ogpeg_constructors import Decoder
from collect_all_pinvoke_native import ExternMetadata,need
from inventory_recroom_game_root_native import region
from audit_original_rendering_sdk_candidates import h,body
INV=ROOT/'Validation/NativeNameserverRouter-20261022T192805Z-fb2324c8/report.json'
FETCH=INV.parent/'chained-fetch-function.json'
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def pin(p):return {'path':str(p),'sha256':sha(p)}
def class_ready(d):
 first=d.relative('48 8b 05');d.literal('f6 80 33 01 00 00 04');skip1=d.short('74');d.literal('83 b8 e0 00 00 00 00');skip2=d.short('75');d.literal('48 8b c8');init=d.relative('e8');again=d.relative('48 8b 05');ready=d.va+d.at
 need(first==again==0x18876a358 and skip1==skip2==ready and init==0x180640f10,'Exact original class-init guard/field receiver');return first

def getter(code,va):
 d=Decoder(code,va);d.literal('40 53 48 83 ec 20');flag=d.relative('80 3d','00');d.literal('8b d9');skip=d.short('75');item=d.relative('48 8d 0d');i1=d.relative('e8');klass=d.relative('48 8d 0d');i2=d.relative('e8');written=d.relative('c6 05','01');ready=d.va+d.at
 need(flag==written and skip==ready and item==0x18870cc28 and klass==0x18876a358 and i1==i2==0x1806c01e0,'Original getter metadata guards');class_ready(d);d.literal('48 8b 80 b8 00 00 00 48 8b 48 70 48 85 c9');null=d.short('74');loaded=d.relative('4c 8b 05');d.literal('8b d3 48 83 c4 20 5b');index=d.relative('e9');error=d.va+d.at;nre=d.relative('e8');d.literal('cc');d.end();need(null==error and loaded==item and index==0x185ed5b10 and nre==0x1806c0390,'Original indexer/null/argument/tailcall behavior');return {'field_offset':112,'original_argument0_passed_unchanged':True,'single_static_dictionary_read':True,'methodspec_slot':hex(item),'indexer_target':hex(index),'null_receiver_throws':True,'all_native_bytes_checked':len(code)}
def try_router(code,va):
 d=Decoder(code,va);d.literal('48 89 5c 24 08 57 48 83 ec 20');flag=d.relative('80 3d','00');d.literal('48 8b da 8b f9');skip=d.short('75');count=d.relative('48 8d 0d');i1=d.relative('e8');item=d.relative('48 8d 0d');i2=d.relative('e8');klass=d.relative('48 8d 0d');i3=d.relative('e8');written=d.relative('c6 05','01');ready=d.va+d.at
 need(flag==written and skip==ready and count==0x18870c9a0 and item==0x18870cc28 and klass==0x18876a358 and i1==i2==i3==0x1806c01e0,'Original Try router metadata guards');class_ready(d);d.literal('48 8b 80 b8 00 00 00 48 8b 48 70 48 85 c9');null1=d.relative('0f 84');count_loaded=d.relative('48 8b 15');count_call=d.relative('e8');d.literal('85 c0');positive=d.short('7f');d.literal('33 d2 48 c7 03 00 00 00 00 48 8b cb');barrier0=d.relative('e8');d.literal('32 c0 48 8b 5c 24 30 48 83 c4 20 5f c3');positive_at=d.va+d.at
 need(positive==positive_at and count_loaded==count and count_call==0x18237f7e0 and barrier0==0x1806bfd30,'Exact Count>0/false-null out path');class_ready(d);d.literal('48 8b 80 b8 00 00 00 48 8b 48 70 48 85 c9');null2=d.short('74');item_loaded=d.relative('4c 8b 05');d.literal('8b d7');index=d.relative('e8');d.literal('48 8b d0 48 89 03 48 8b cb');barrier1=d.relative('e8');d.literal('48 8b 5c 24 30 b0 01 48 83 c4 20 5f c3');error=d.va+d.at;nre=d.relative('e8');d.literal('cc');d.end();need(null1==null2==error and item_loaded==item and index==0x185ed5b10 and barrier1==0x1806bfd30 and nre==0x1806c0390,'Exact positive indexer/true/out-write/null path');return {'field_offset':112,'count_test':'Count > 0','false_path':'out Uri = null; return false','positive_path':'reload original static dictionary; out Uri = dictionary[argument0]; return true','is_Dictionary_TryGetValue':False,'missing_key_exception_preserved_on_positive_path':True,'dictionary_not_cached_across_count_and_indexer':True,'all_native_bytes_checked':len(code)}
def main():
 need(sha(INV)=='cb25a245039b640da0135d2b0a7caaad6998f4f3f4acf7f3917338e5f7c9798d' and sha(FETCH)=='e27e4eca05ea6f5511d161c26bc1b7126bf2f429b91601bf49dd284004034b62','Pinned native evidence');data=json.loads(INV.read_text());fetch=json.loads(FETCH.read_text());proofs=[];controls=[]
 for row in data['methods']:
  name=row['original']['name']
  if name=='.cctor':continue
  code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);decode=getter if name=='OHFNGFDHOEG' else try_router;proofs.append({'original':row['original'],'native_sha256':hashlib.sha256(code).hexdigest(),'whole_opcode_proof':decode(code,va)})
  rejected=0
  for index in range(len(code)):
   changed=bytearray(code);changed[index]^=1
   try:decode(bytes(changed),va)
   except (ValueError,struct.error):rejected+=1
   else:raise AssertionError('Unproved native byte mutation accepted '+name+' offset'+str(index))
  controls.append({'method':name,'one_byte_mutations_each_byte_xor1':len(code),'all_rejected':rejected==len(code)})
 usages=data['RIP_metadata_usages'];item=usages['0x18870cc28'];count=usages['0x18870c9a0'];ctor=usages['0x18870c490'];need(all(u['kind']==6 and u['class_argument_types']==['FIJCCHEPFFC','System.Uri'] for u in [item,count,ctor]),'Exact closed dictionary class');need(item['method']['name']=='get_Item' and count['method']['name']=='get_Count' and ctor['method']['name']=='.ctor','Exact dictionary MethodDefs');need([r['pointer']for r in data['generic_method_registrations'][str(item['index'])]]==['0x185ed5b10'] and [r['pointer']for r in data['generic_method_registrations'][str(count['index'])]]==['0x18237f7e0'],'Exact generic registration targets');field=[f for f in data['original_router_fields_and_offsets']if f['name']=='GJAAPHOHPKN'];need(len(field)==1 and field[0]['offset']==112 and field[0]['type']=='System.Collections.Generic.Dictionary`2<FIJCCHEPFFC,System.Uri>' and field[0]['native_type']['attributes']==17,'Exact original private static map field')
 paths=[ROOT/'VerifiedSource/GameAssembly.dll',ROOT/'VerifiedSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat'];dependencies=[]
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);enum=next(i for i in range(v.count('typeDefinitions',88))if v.full_name(i)=='FIJCCHEPFFC');td=v.row('typeDefinitions',enum,88);fs=v.i32(md,td+32);field0=v.row('fields',fs,12);need(v.string(v.i32(md,field0))=='value__' and v.native_type(v.i32(md,field0+4))['kind']==8,'Exact service enumInt32ABI')
  methods=[fetch['method']]+[u['method']for u in fetch['metadata_usages'].values()if u['kind']==3]+[v.find_method('NDFLHBFOIGB',0x06004ea6),v.find_method('NDFLHBFOIGB',0x06004eb8),v.find_method('NDFLHBFOIGB',0x06004eb3),v.find_method('CDMLNBEJKKH',0x06005de1)]
  for slot,token in [(11,0x06005dee),(22,0x06005dfb),(23,0x06005dfc)]:
   m=v.find_method('CDMLNBEJKKH',token);need(v.u16(md,v.row('methods',m['index'],32)+28)==slot,'Exact native request declared vtable slot');methods.append(m)
  for m in methods:
   va=v.method_pointer(m);row={'original':m,'VA':hex(va),'native_body_available':bool(va)}
   if va:
    try:w=region(v,va);row['first_runtime_region_bytes_not_assumed_whole']=len(bytes.fromhex(w['bytes']));row['first_runtime_region_sha256']=w['sha256']
    except ValueError as e:row['first_region_gap']=str(e)
   module=WS/'RR23/Assets/Plugins'/m['image'];actual=[]
   with module.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as cb:
    c=h.m.cli.Cli(cb);r=h.Read(c)
    for rid in range(1,c.rows[2]+1):
     if r.definition(rid)!=m['owner']:continue
     for a in r.methods(rid):
      if a['name']==m['name'] and len(a['signature']['parameters'])==len(m['parameters']):actual.append(a|{'body':body(c,a['token'])})
   row['current_DLL']=pin(module);row['current_methods_same_owner_name_parameter_count_diagnostic_only']=actual;dependencies.append(row)
 out=ROOT/'Validation'/('NativeNameserverRouterPlan-'+datetime.datetime.now(datetime.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 snippet=out/'OriginalRouterBodies.cs.txt';snippet.write_text('// Native-equivalent body proposals only. Not compiled or installed.\n// Existing declarations/types/flags/signatures remain authoritative.\n\n// NDFLHBFOIGB.OHFNGFDHOEG(FIJCCHEPFFC BDIJLBAAEHA) : System.Uri\n{\n    return GJAAPHOHPKN[BDIJLBAAEHA];\n}\n\n// NDFLHBFOIGB.KBKOIKCIEKB(FIJCCHEPFFC BDIJLBAAEHA, out System.Uri OGBMDDBICLO) : bool\n{\n    if (GJAAPHOHPKN.Count <= 0)\n    {\n        OGBMDDBICLO = null;\n        return false;\n    }\n    OGBMDDBICLO = GJAAPHOHPKN[BDIJLBAAEHA];\n    return true;\n}\n')
 override={'schema':'planned-client-only-nameserver-default-origin-override/v1','status':'plan_only_not_consumed_by_current_client','enabled':True,'scope':'default nameserver origin literal in fully recovered original NDFLHBFOIGB.DKBECGKHEKO only','original_origin':'https://ns.rec.net','configured_origin':'https://ns.nerlz.com','allowed_origins':['https://ns.rec.net','https://ns.nerlz.com'],'method_original_token':'0x06004ea2','original_native_RVA':'0x2106370','original_literal_index':42416,'original_literal_sha256':'0246681f93128f00a8f1783c22681bc43132208dc699f3d0f2b6b30a60847dea','keep_original_optional_environment_suffix_logic':True,'rewrite_response_discovered_service_URIs':False,'rewrite_all_dictionary_router_results':False,'change_auth_session_TLS_or_cert_validation':False,'do_not_install_until_original_bootstrap_and_request_callback_logic_recovered':True}
 override_path=out/'planned-client-network-override.json';override_path.write_text(json.dumps(override,indent=2)+'\n')
 report={'schema':'whole-opcode-native-router-and-finite-nameserver-plan/v1','status':'two_router_bodies_native_proven_bootstrap_dependencies_unrecovered','native_inputs':[pin(INV),pin(FETCH),pin(INV.parent/'fetch-direct-call-dependencies.json')],'original_field':field[0],'service_enum_32bit_ABI_proven':True,'exact_BCL_MethodSpec_bindings':{'get_Item':item,'get_Count':count,'constructor':ctor},'whole_opcode_method_proofs':proofs,'negative_controls':controls,'proposed_original_body_text':pin(snippet),'configured_override_plan':pin(override_path),'exact_unrecovered_bootstrap_dependencies':dependencies,'initializer_analysis':{'original_native_bytes':1733,'instructions':339,'contains_no_literal_URL_or_service_endpoint_population':True,'dictionary_initialization':'new Dictionary<FIJCCHEPFFC,System.Uri>() with exact native MethodSpec83462','original_crypto_array_initializers_preserved_as_unrecovered_dependencies':True,'HTTP_certificate_callbacks_and_existing_HTTPManager_fields_must_be_preserved':True,'full_original_cctor_body_reconstruction_complete':False,'partial_cctor_replacement_permitted':False},'finite_override_boundary':{'method':'NDFLHBFOIGB.DKBECGKHEKO','native_bytes_with_two_verified_chained_regions':771,'original_metadata_literal_index':42416,'original_origin':'https://ns.rec.net','new_origin':'https://ns.nerlz.com','change_when_implemented':'only original default-origin string operand; preserve existing optional suffix, Uri construction, logging, original request factory/virtual calls, callbacks, promise and discovered service map'},'blocked_by':['The original1733-byte classinitializer is not fully reconstructed; a new empty/default initializer must not replace crypto arrays, queues, TLS callbacks or security behavior.','ConnectToRecNet and its request factory/response callback currently returnnull or empty bodies. A string-only redirect cannot produce login/connectivity.','Original nameserver response parsing/map population and existing auth/session behavior must be recovered before an operational backend test.','No original game, HTTP request, PInvoke, TLS callback or production endpoint was executed in this audit.'],'Main_modified':False,'backend_modified':False,'network_requests':0,'managed_Unity_or_game_code_invoked':False,'native_disassembler_only_not_game_code':True,'tool':pin(Path(__file__))}
 rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':sha(rp),'native_proven_router_methods':len(proofs),'negative_controls':sum(r['one_byte_mutations_each_byte_xor1']for r in controls),'dependency_methods':len(dependencies),'configured_override_plan':str(override_path),'Main_modified':False}))
if __name__=='__main__':main()
