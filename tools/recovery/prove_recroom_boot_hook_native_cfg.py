"""Exact bounded original boot hook CFG; no behavior inferred from stub CIL."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_ogpeg_constructors import Decoder
from prove_recroom_ondestroy_native_cfg import aliases
INV=ROOT/'Validation/RecRoomGameRootNative-20261022T162444Z-d9c732b7/report.json'
def decode(code,va):
 d=Decoder(code,va);d.literal('40 53 48 83 ec 20');flag=d.relative('80 3d','00');d.literal('48 8b d9');skip=d.short('75');a=d.relative('48 8d 0d');i1=d.relative('e8');b=d.relative('48 8d 0d');i2=d.relative('e8');c=d.relative('48 8d 0d');i3=d.relative('e8');written=d.relative('c6 05','01');ready=d.at;d.literal('33 d2 48 8b cb');base=d.relative('e8');bl=d.relative('48 8b 0d');allocation=d.relative('e8');cl=d.relative('48 8b 15');d.literal('45 33 c0 48 8b c8 48 8b d8');ctor=d.relative('e8');d.literal('48 85 db');null=d.short('74');al=d.relative('48 8b 15');d.literal('48 8b cb 48 83 c4 20 5b');tail=d.relative('e9');null_at=va+d.at;nre=d.relative('e8');d.literal('cc');d.end();need(flag==written and skip==va+ready and a==al and b==bl and c==cl,'Exactmetadata/cacheCFG');need(i1==i2==i3==0x1806c01e0 and allocation==0x1806c0340 and null==null_at and nre==0x1806c0390,'Exactoriginalruntimehelper/exceptionCFG');return {'metadata_A':hex(a),'metadata_B_allocated_class':hex(b),'metadata_C_ctor_argument':hex(c),'base_call':hex(base),'constructor_call':hex(ctor),'tail_call':hex(tail),'null_exception_helper':hex(nre),'complete_entry_function_including_exception_tail':True,'all135bytes_and_stack_balance_checked':True}
def main():
 need(sha(INV)=='9492989fb0f23794155b1e0bd6e9ae25eeae2fc86687a9e1016abfb14617d7f6','InventorySHA');inv=json.loads(INV.read_text());row=next(x for x in inv['methods'] if x['original']['owner']=='RecRoomGameRoot' and x['original']['name']=='HPCJAAEDLCH');code=bytes.fromhex(row['runtime_function']['bytes']);need(len(code)==135,'Exactoriginalhook135B');va=int(row['native_pointer'],16);shape=decode(code,va);paths=[ROOT/'CodeSource'/r for r in EXPECTED]
 for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'OriginalinputSHA')
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);method=v.find_method('RecRoomGameRoot',0x060026c1);need(v.method_pointer(method)==va and bytes(b[v.raw(va,len(code)):v.raw(va,len(code))+len(code)])==code,'Exactoriginalregistration/bytes');uses={k:v.usage(int(shape[k],16)) for k in ['metadata_A','metadata_B_allocated_class','metadata_C_ctor_argument']};targets={int(shape[k],16) for k in ['constructor_call','tail_call']};mapped,gaps=aliases(v,targets);base=v.find_method('GameRoot',0x06000004);need(v.method_pointer(base)==int(shape['base_call'],16),'Exacttypedexternalbasehook');generic=[]
  if uses['metadata_A']['kind']==6:generic=v.generic_targets({uses['metadata_A']['index']})[uses['metadata_A']['index']]
  literal=None;cu=uses['metadata_C_ctor_argument']
  if cu['kind']==5:
   at=v.row('stringLiteral',cu['index'],8);length,index=struct.unpack_from('<Ii',md,at);off,size=v.tables['stringLiteralData'];need(0<=index<=size-length and length<=256,'Bounded originallabel');raw=bytes(md[off+index:off+index+length]);text=raw.decode('utf-8');literal={'native_index':cu['index'],'length':length,'sha256':hashlib.sha256(raw).hexdigest(),'value':text if all(ch.isalnum() or ch in ' _-().' for ch in text) else None}
 controls=[]
 for label,at in [('receiverregister',17),('metadatajump',20),('nullbranch',106),('tailcallopcode',124)]:
  changed=bytearray(code);changed[at]^=1
  try:decode(bytes(changed),va)
  except (ValueError,struct.error):controls.append({'mutation':label,'offset':at,'rejected':True})
  else:raise AssertionError('Changedbootshapeaccepted')
 out=ROOT/'Validation'/('RecRoomBootHookCFG-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-RecRoomGameRoot-boot-hook-closed-CFG/v1','status':'native_CFG_and_dependencies_only','original':row,'exact_native_controlflow':shape,'original_metadata_uses':uses,'native_base_hook':base,'original_generic_tail_registrations':generic,'metadata_ctor_argument_literal':literal,'raw_backed_direct_pointer_aliases':mapped,'alias_inventory_unbacked_tables':gaps,'negative_controls':controls,'CSharp_candidate_written':False,'original_project_changed':False,'game_or_native_code_executed':False};rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':sha(rp),'uses':uses,'literal':literal,'generic_targets':generic,'callee_counts':{k:len(val) for k,val in mapped.items()},'controls':len(controls)}))
if __name__=='__main__':main()
