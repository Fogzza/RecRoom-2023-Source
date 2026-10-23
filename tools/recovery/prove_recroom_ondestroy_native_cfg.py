"""Exact complete 119-byte callback shape + original registrations/metadata uses.
No game or native code is executed. Callee identities come from original tables.
"""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_ogpeg_constructors import Decoder
INV=ROOT/'Validation/RecRoomGameRootNative-20261022T162444Z-d9c732b7/report.json'
def decode(code,va):
 d=Decoder(code,va);d.literal('48 89 5c 24 08 57 48 83 ec 20');flag=d.relative('80 3d','00');d.literal('48 8b f9');skip=d.short('75');klass=d.relative('48 8d 0d');init1=d.relative('e8');method=d.relative('48 8d 0d');init2=d.relative('e8');written=d.relative('c6 05','01');ready=d.at;d.literal('33 d2 48 8b cf');base=d.relative('e8');loaded_class=d.relative('48 8b 0d');allocate=d.relative('e8');loaded_method=d.relative('4c 8b 05');d.literal('45 33 c9 48 8b d7 48 8b c8 48 8b d8');ctor=d.relative('e8');d.literal('33 d2 48 8b cb 48 8b 5c 24 30 48 83 c4 20 5f');tail=d.relative('e9');d.end();need(flag==written and skip==va+ready and klass==loaded_class and method==loaded_method,'Exactmetadata/cacheCFG');need(init1==init2==0x1806c01e0 and allocate==0x1806c0340,'Knownoriginalruntimehelperanchors');return {'guard_flag_address':hex(flag),'metadata_class_usage':hex(klass),'metadata_callback_usage':hex(method),'runtime_initialize_helper':hex(init1),'base_call':hex(base),'allocation_helper':hex(allocate),'delegate_constructor_call':hex(ctor),'tail_call':hex(tail),'receiver_flow':['RDI = original this','base receives original this; null hidden MethodInfo','allocate exactmetadata class','ctor receives allocatedobject RCX,original this RDX,callback MethodInfo R8,null hidden MethodInfo R9','tail receives newdelegate RCX,null hidden MethodInfo RDX'],'metadata_setup_branch_target':hex(skip),'complete_function_allbytes_opcodes_and_stack_balance_checked':True}
def aliases(v,targets):
 found={x:[] for x in targets};skipped=[]
 for image,module in v.modules.items():
  if not module['count']:continue
  try:raw=v.raw(module['pointers_va'],module['count']*8)
  except ValueError as e:
   skipped.append({'image':image,'table_pointer':hex(module['pointers_va']),'count':module['count'],'error':str(e),'not_assumed_zero_or_excluded_from_ambiguity':True});continue
  hits=[(rid+1,v.u64(v.b,raw+rid*8)) for rid in range(module['count']) if v.u64(v.b,raw+rid*8) in targets]
  if not hits:continue
  im=next(r for r in v.images if r['name']==image);wanted=dict(hits);matched=set()
  for ti in range(im['start'],im['start']+im['count']):
   td=v.row('typeDefinitions',ti,88);start=v.i32(v.m,td+36);count=v.u16(v.m,td+64)
   for mi in range(start,start+count):
    token=v.u32(v.m,v.row('methods',mi,32)+20);rid=token&0xffffff
    if rid not in wanted:continue
    method=v.method_info(mi);need(token>>24==6 and method['image']==image and method['owner_index']==ti,'Exactoriginalcodegenmodule/token/ownerjoin');found[wanted[rid]].append(method);matched.add(rid)
  for rid in set(wanted)-matched:skipped.append({'image':image,'method_RID':rid,'pointer':hex(wanted[rid]),'error':'Native pointer row has no retained exact MethodDef token witness','not_assumed_zero_or_excluded_from_ambiguity':True})
 return {hex(k):val for k,val in found.items()},skipped
def main():
 need(sha(INV)=='9492989fb0f23794155b1e0bd6e9ae25eeae2fc86687a9e1016abfb14617d7f6','Startupinventorypin');inv=json.loads(INV.read_text());row=next(x for x in inv['methods'] if x['original']['owner']=='RecRoomGameRoot' and x['original']['name']=='OnDestroy');code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);need(len(code)==119,'Exactbound');shape=decode(code,va);paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
 for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'OriginalSHA')
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);need(bytes(b[v.raw(va,len(code)):v.raw(va,len(code))+len(code)])==code,'Nativebytepin');need(v.method_pointer(v.find_method('RecRoomGameRoot',0x060026c2))==va,'Originalregistrationpin');uses={k:v.usage(int(shape[k],16)) for k in ['metadata_class_usage','metadata_callback_usage']};targets={int(shape[k],16) for k in ['base_call','delegate_constructor_call','tail_call']};mapped,skipped=aliases(v,targets)
 controls=[]
 for name,offset in [('receiverregister',20),('metadatajump',23),('nullhiddenargument',91),('tailcallopcode',114)]:
  mutation=bytearray(code);mutation[offset]^=1
  try:decode(bytes(mutation),va)
  except (ValueError,struct.error):controls.append({'name':name,'offset':offset,'rejected':True})
  else:raise AssertionError('Changedcompletecallbackaccepted '+name)
 out=ROOT/'Validation'/('RecRoomOnDestroyCFG-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-complete-RecRoomGameRoot-OnDestroy-native-CFG/v1','status':'native_shape_and_registration_evidence_only','original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'original_callback':row,'exact_native_controlflow':shape,'original_metadata_uses':uses,'raw_backed_original_direct_pointer_aliases':mapped,'alias_inventory_unbacked_tables':skipped,'alias_inventory_complete':not skipped,'negative_controls':controls,'CSharp_candidate_written':False,'original_source_or_project_modified':False,'game_or_native_code_executed':False};rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':sha(rp),'uses':uses,'calls':{k:[x['owner']+'.'+x['name'] for x in val] for k,val in mapped.items()},'negatives':len(controls),'alias_gaps':len(skipped)}))
if __name__=='__main__':main()
