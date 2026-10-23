"""Read-only native registration/range inventory for all core extern methods."""
from pathlib import Path
import bisect,hashlib,json,mmap,struct,sys
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from native_metadata import NativeMetadata
from audit_forwarding import EXPECTED,sha

class ExternMetadata(NativeMetadata):
 def typename(self,t,depth=0):
  if t['kind'] in (24,25):
   need(not t['num_mods'] and not t['pinned'],'Modified/pinned native integer excluded')
   return ('System.IntPtr' if t['kind']==24 else 'System.UIntPtr')+('&' if t['byref'] else '')
  return super().typename(t,depth)

def need(b,s):
 if not b:raise ValueError(s)

def main():
 out=Path(sys.argv[1]);need(not out.exists(),'Fresh output required');paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Verified original input changed');paths.append(p)
 rows=[];gaps=[]
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);opt=v.u32(b,60)+24;rva,size=struct.unpack_from('<II',b,opt+136);need(size%12==0 and size<=16*1024*1024,'Bounded PE .pdata required');at=v.raw(v.base+rva,size)
  ranges={}
  for start,end,unwind in struct.iter_unpack('<III',b[at:at+size]):
   need(start<end and start not in ranges,'Runtime ranges invalid/duplicate');ranges[start]=(end,unwind)
  for image in v.images:
   if image['name']!='Assembly-CSharp.dll':continue
   for ti in range(image['start'],image['start']+image['count']):
    t=v.row('typeDefinitions',ti,88);start=v.i32(md,t+36);count=v.u16(md,t+64)
    for index in range(start,start+count):
     a=v.row('methods',index,32)
     if not v.u16(md,a+24)&0x2000:continue
     try:
      method=v.method_info(index);method['declaring_type']=v.type_info(ti);need(method['owner_index']==ti,'Native owner mismatch');va=v.method_pointer(method)
      need(va!=0 and v.executable(va),'Original nonzero executable wrapper pointer required');native_rva=va-v.base;need(native_rva in ranges,'Wrapper must start exact runtime function')
      end,unwind=ranges[native_rva];need(0<end-native_rva<=65536,'Wrapper runtime size bound');raw=v.raw(va,end-native_rva);code=bytes(b[raw:raw+end-native_rva]);rows.append({'original':method,'native_pointer':hex(va),'runtime_function':{'start_rva':native_rva,'end_rva':end,'unwind_rva':unwind,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest()}})
     except Exception as e:gaps.append({'native_method_index':index,'native_token':hex(v.u32(md,a+20)),'owner':v.full_name(ti),'name':v.string(v.i32(md,a)),'error':type(e).__name__+': '+str(e)})
 need(len(rows)+len(gaps)==846,'Exact native846 core extern inventory required')
 report={'schema':'all-original-core-pinvoke-native-wrapper-inventory/v1','inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'tool':{'path':str(Path(__file__).resolve()),'sha256':sha(Path(__file__))},'original_native_extern_count':846,'methods':rows,'unresolved':gaps,'original_project_modified':False,'game_code_executed':False}
 out.parent.mkdir(parents=True,exist_ok=True);out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'registered_bounded_wrappers':len(rows),'unresolved':len(gaps),'wrapper_bytes':sum(len(bytes.fromhex(r['runtime_function']['bytes'])) for r in rows)}))
if __name__=='__main__':main()
