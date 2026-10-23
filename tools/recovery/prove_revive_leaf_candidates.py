"""Native-proved leaf/predicate candidates; no live source edits or compilation."""
from pathlib import Path
import hashlib,json,mmap,re,struct,sys
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18';PROJECT=WORKSPACE/'RR23'
sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_ogpeg_constructors import Decoder

def main():
 folder=Path(sys.argv[1]);out=folder/'LeafCandidates';need(not out.exists(),'Fresh candidates required');out.mkdir();deps=json.loads((folder/'dependencies-v2.json').read_text());inventory=json.loads((folder/'inventory.json').read_text());paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Original native source changed');paths.append(p)
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);base='AGUI.StackedUI.ConditionalButton';getter=v.find_method(base,0x06004205);predicate=v.find_method(base,0x0600420e);derived=v.find_method('RecRoom.ReviveButton',0x0600afcd)
  field=next(r for r in deps['original_inheritance_field_layouts'] if r['original_type']['name']==base)['fields'];field=[f for f in field if f['name']=='ONMKHCBEKPF'];need(len(field)==1,'Unique original field required');field=field[0];need(field['original_token']=='0x4002fe3' and field['type']=='System.Int32' and field['registered_offset']==24 and field['native_type']['attributes']==1 and not field['native_type']['byref'] and not field['native_type']['num_mods'] and not field['native_type']['pinned'],'Exact original private unmodified instanceInt32 field required')
  for method,ret in ((getter,'System.Int32'),(predicate,'System.Boolean'),(derived,'System.Boolean')):
   need(method['return']==ret and not method['parameters'] and method['generic_container_index']<0 and method['declaring_type']['generic_container_index']<0 and not method['flags']&(0x10|0x400|0x2000) and method['impl_flags']==0,'Original ordinary nongeneric managed instance method shape required')
  target=v.method_pointer(predicate);target_row=next(r for r in deps['native_target_registration_matches'] if int(r['native_target'],16)==target);need(target_row['direct_MethodDef_pointer_match_count']==1 and target_row['generic_registration_match_count']==0 and target_row['direct_MethodDefs'][0]['token']==predicate['token'],'Derived base-predicate identity must be unique')
  def decode_get(code,va):
   d=Decoder(code,va);d.literal('8b 41');d.literal(bytes([field['registered_offset']]).hex());d.literal('c3');d.end();return {'read':'this.ONMKHCBEKPF','type':'System.Int32','width_bytes':4,'return_register':'EAX','field_original_token':field['original_token'],'native_offset':24}
  def decode_base(code,va):
   d=Decoder(code,va);d.literal('83 79');d.literal(bytes([field['registered_offset']]).hex());d.literal('00 0f 97 c0 c3');d.end();return {'operation':'unsigned32(field)>0','equivalent_source':'this.ONMKHCBEKPF != 0','equivalence_scope':'All32-bit values, including negative Int32 bit patterns: unsigned x>0 iff x!=0. This is not signed x>0.','field_original_token':field['original_token'],'native_offset':24}
  def decode_derived(code,va):
   d=Decoder(code,va);d.literal('40 53 48 83 ec 20 33 d2 48 8b d9');callee=d.relative('e8');need(callee==target,'Exact original base predicate call target differs');d.literal('84 c0');branch=d.short('75');d.literal('48 83 c4 20 5b c3');need(branch==va+d.at,'Conditional true branch must join field comparison');d.literal('83 7b');d.literal(bytes([field['registered_offset']]).hex());d.literal('02 0f 94 c0 48 83 c4 20 5b c3');d.end();return {'operation':'base.FNINFCOHBOK() short-circuit AND inheritedfield==2','exact_base_callee':predicate,'base_callee_native_pointer':hex(target),'source_candidate':'return base.FNINFCOHBOK() && GJDIGNBBMNF() == 2;','base_call_preserved_before_second_read':True,'no_constant_false_recovery_claim':True,'both_return_branches_and_complete39byte_region_proved':True,'null_tail':'No separate null-tail path in this complete native region; original base predicate/helper field accesses retained with no invented guard.'}
  methods=[];negative=[]
  for method,length,decode in ((getter,4,decode_get),(predicate,8,decode_base),(derived,39,decode_derived)):
   va=v.method_pointer(method);at=v.raw(va,length);code=bytes(b[at:at+length]);semantics=decode(code,va)
   if method['owner']=='RecRoom.ReviveButton':
    original_region=next(r['runtime_function'] for r in inventory['methods'] if r['original']['token']==method['token']);need(original_region['end_rva']-original_region['start_rva']==39 and original_region['bytes']==code.hex(),'Complete derived predicate region differs')
   methods.append({'original':method,'native_pointer':hex(va),'native_bytes':code.hex(),'native_sha256':hashlib.sha256(code).hexdigest(),'semantics':semantics})
   for i in range(length):
    changed=bytearray(code);changed[i]^=1
    try:decode(bytes(changed),va)
    except (ValueError,struct.error):negative.append({'method':method['name'],'owner':method['owner'],'changed_native_byte':i,'rejected':True})
    else:raise AssertionError('Native mutation accepted')
  # Keep every unrelated source byte. Full Roslyn binding/Unity compile is a
  # deployment prerequisite, not claimed by this textual preparation stage.
  definitions=[('Assets/Scripts/Assembly-CSharp/AGUI/StackedUI/ConditionalButton.cs',[
   (rb'protected int GJDIGNBBMNF\(\)\s*\{\s*(return 0;)\s*\}',b'return this.ONMKHCBEKPF;','GJDIGNBBMNF'),
   (rb'protected virtual bool FNINFCOHBOK\(\)\s*\{\s*(return false;)\s*\}',b'return this.ONMKHCBEKPF != 0;','base.FNINFCOHBOK')]),
   ('Assets/Scripts/Assembly-CSharp/RecRoom/ReviveButton.cs',[(rb'protected override bool FNINFCOHBOK\(\)\s*\{\s*(return false;)\s*\}',b'return base.FNINFCOHBOK() && GJDIGNBBMNF() == 2;','derived.FNINFCOHBOK')])]
  files=[]
  for rel,edits in definitions:
   source=PROJECT/rel;data=source.read_bytes();pending=[]
   for pattern,replacement,name in edits:
    matches=list(re.finditer(pattern,data));need(len(matches)==1,'Exact known-stub method source match required: '+name);match=matches[0];start,end=match.span(1);pending.append({'start':start,'length':end-start,'original_hex':data[start:end].hex(),'replacement_hex':replacement.hex(),'method':name})
   candidate=data
   for e in sorted(pending,key=lambda e:e['start'],reverse=True):candidate=candidate[:e['start']]+bytes.fromhex(e['replacement_hex'])+candidate[e['start']+e['length']:]
   target=out/'Sources'/rel;target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(candidate);meta=source.with_name(source.name+'.meta');guid=re.search(rb'^guid:\s*([0-9a-f]{32})\s*$',meta.read_bytes(),re.M);need(guid is not None,'Original scriptGUID required')
   files.append({'project_relative_path':rel,'source':str(source),'source_sha256':sha(source),'meta':str(meta),'meta_sha256':sha(meta),'script_guid':guid.group(1).decode(),'candidate':str(target),'candidate_sha256':sha(target),'byte_edits':pending,'changes_are_known_stub_body_spans_only':True})
  report={'schema':'native-ReviveButton-and-base-leaf-candidates/v1','status':'candidate_only_not_applied','inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'dependencies':{'path':str(folder/'dependencies-v2.json'),'sha256':sha(folder/'dependencies-v2.json')},'original_field':field,'native_methods':methods,'all_native_byte_mutations_rejected':negative,'files':files,'source_semantic_binding_and_matching_Unity_compile_passed':False,'deployment_gates':['ExactRoslynmember/fieldbinding and fixtureIL proof','Freshwhole-source/hashrebase and regressioncompile','CurrentUnityILPPpackage source/deployment hashes refreshed','OriginalCodeGen/type/member/field/PDB contracts retained'],'no_ambiguous_OnEnable_UpdateButton_forwarder_patched':True,'no_other_ReviveButton_callback_body_reconstructed':True,'original_source_or_meta_modified':False,'game_code_executed':False};(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'native_methods':3,'negative_byte_mutations':len(negative),'source_candidates':len(files),'project_modified':False}))
if __name__=='__main__':main()
