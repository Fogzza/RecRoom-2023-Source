"""Original two Win32 wrappers with dangling marshal metadata; bytes as data."""
import hashlib,json,mmap,sys
from pathlib import Path
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_generic_forwarders import runtime_range
def main():
 folder=Path(sys.argv[1]);out=folder/'Win32-marshal-wrapper-input.json';need(not out.exists(),'Fresh evidence output');paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Verified source changed');paths.append(p)
 methods=[]
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md)
  for token in (0x0600e7d4,0x0600e7de):
   method=v.find_method('KNBDGFKMGCP',token);va=v.method_pointer(method);lo,hi,code=runtime_range(v,va);methods.append({'original':method,'native_pointer':hex(va),'runtime_function':{'start_rva':lo,'end_rva':hi,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'scope':'Exact entry PE runtime-function; all external branch tails require separate proof.'}})
  guid=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)=='System.Guid'];need(len(guid)==1,'Unique original Guid type');ti=guid[0];td=v.row('typeDefinitions',ti,88);fs=v.i32(md,td+32);fc=v.u16(md,td+68);fp=v.raw(v.u64(b,v.field_offsets+ti*8),fc*4);fields=[]
  for i in range(fc):
   fa=v.row('fields',fs+i,12);nt=v.native_type(v.i32(md,fa+4));fields.append({'name':v.string(v.i32(md,fa)),'original_token':hex(v.u32(md,fa+8)),'type':v.typename(nt),'native_type':nt,'registered_offset':v.i32(b,fp+i*4)})
  guid_type=v.type_info(ti)
 report={'schema':'original-two-Win32-marshal-wrapper-bytes/v1','original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'methods':methods,'original_Guid_type':guid_type,'original_Guid_fields':fields,'game_code_or_native_import_invoked':False,'project_modified':False};out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'methods':len(methods)}))
if __name__=='__main__':main()
