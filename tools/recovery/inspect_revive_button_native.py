"""Small inert native method inventory for original RecRoom.ReviveButton."""
from pathlib import Path
import hashlib,json,mmap,struct,sys
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_generic_forwarders import runtime_range

def main():
 out=Path(sys.argv[1]);need(not out.exists(),'Fresh output required');paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Verified original source changed');paths.append(p)
 rows=[];gaps=[]
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);matches=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)=='RecRoom.ReviveButton'];need(len(matches)==1,'Original named type ambiguous');ti=matches[0];info=v.type_info(ti);need(info['image']=='Assembly-CSharp.dll','Wrong original image');at=v.row('typeDefinitions',ti,88);first=v.i32(md,at+36);count=v.u16(md,at+64)
  for index in range(first,first+count):
   m=v.method_info(index);need(m['owner_index']==ti,'Original method owner differs');va=v.method_pointer(m);need(v.executable(va),'Original executable method pointer required')
   try:
    start,end,code=runtime_range(v,va);region={'start_rva':start,'end_rva':end,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'scope':'Exact registered PE runtime-function region; not assumed to cover all split-unwind regions.'}
   except ValueError as error:
    raw=v.raw(va,32);code=bytes(b[raw:raw+32]);region={'start_rva':va-v.base,'end_rva':va-v.base+32,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'scope':'Bounded32-byte native entry prefix; no full .pdata range found.','range_error':str(error)}
   rows.append({'original':m,'native_pointer':hex(va),'runtime_function':region})
  enum_name='RecRoom.ReviveButton/NMLCCKCPGDA';matches=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)==enum_name];need(len(matches)==1,'Original nested enum absent/ambiguous');ei=matches[0];e=v.row('typeDefinitions',ei,88);fs=v.i32(md,e+32);fc=v.u16(md,e+68);enum_fields=[]
  defaults={}
  for n in range(v.count('fieldDefaultValues',12)):
   field,type_index,data_index=struct.unpack_from('<iii',md,v.row('fieldDefaultValues',n,12))
   if fs<=field<fs+fc:defaults[field]=(type_index,data_index)
  for n in range(fc):
   fi=fs+n;f=v.row('fields',fi,12);nt=v.native_type(v.i32(md,f+4));entry={'name':v.string(v.i32(md,f)),'token':hex(v.u32(md,f+8)),'native_type':nt,'value':None}
   if fi in defaults:
    type_index,data_index=defaults[fi];dt=v.native_type(type_index);need(dt['kind']==8 and not dt['byref'],'Expected literal Int32 enum default');base,length=v.tables['fieldAndParameterDefaultValueData'];need(0<=data_index<=length-4,'Enum default out of bounds');entry['value']=struct.unpack_from('<i',md,base+data_index)[0]
   enum_fields.append(entry)
  private_enum={'original_type':v.type_info(ei),'fields':enum_fields}
 source=WORKSPACE/'RR23/Assets/Scripts/Assembly-CSharp/RecRoom/ReviveButton.cs';report={'schema':'original-ReviveButton-bounded-native-inventory/v1','original_source_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'current_exported_source':{'path':str(source),'sha256':sha(source)},'original_type':info,'methods':rows,'nested_enum':private_enum,'source_body_recovery_claim':False,'project_modified':False,'game_code_executed':False};out.parent.mkdir(exist_ok=True);out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'methods':len(rows),'original_nested_enum':enum_name,'project_modified':False}))
if __name__=='__main__':main()
