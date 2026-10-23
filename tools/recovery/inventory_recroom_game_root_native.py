"""Bounded original RecRoomGameRoot + exact external GameRoot byte inventory.
Native code is read only. Callback completeness is not inferred from entry bytes.
"""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
def region(v,va):
 opt=v.u32(v.b,60)+24;rva,size=struct.unpack_from('<II',v.b,opt+136);need(size%12==0 and 0<size<=16*1024**2,'BoundedPEexceptiontable');at=v.raw(v.base+rva,size);wanted=va-v.base;low,high=0,size//12
 while low<high:
  mid=(low+high)//2;start=v.u32(v.b,at+mid*12)
  if start<wanted:low=mid+1
  else:high=mid
 need(low<size//12,'Runtimeentrybounds');start,end,unwind=struct.unpack_from('<III',v.b,at+low*12);need(start==wanted and start<end and end-start<=16384,'Exact bounded entryruntimefunction');raw=v.raw(va,end-start);code=bytes(v.b[raw:raw+end-start]);return {'start_rva':start,'end_rva':end,'unwind_rva':unwind,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'complete_PE_runtime_function_region':True,'split_or_external_controlflow_not_assumed_complete':True}
def main():
 out=ROOT/'Validation'/('RecRoomGameRootNative-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Original source drift');paths.append(p)
 rows=[];types=[];fields=[];gaps=[]
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md)
  for owner in ('RecRoomGameRoot','GameRoot'):
   hits=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)==owner];need(len(hits)==1,'Unique originaltype '+owner);ti=hits[0];info=v.type_info(ti);types.append(info);td=v.row('typeDefinitions',ti,88);start=v.i32(md,td+36);count=v.u16(md,td+64);fstart=v.i32(md,td+32);fcount=v.u16(md,td+68);offsets=v.u64(b,v.field_offsets+ti*8);need(not fcount or offsets,'Nativefieldoffsettable')
   for n in range(fcount):
    fi=fstart+n;fa=v.row('fields',fi,12);nt=v.native_type(v.i32(md,fa+4));fields.append({'original_owner':info,'native_field_index':fi,'token':hex(v.u32(md,fa+8)),'name':v.string(v.i32(md,fa)),'type':v.typename(nt),'native_type':nt,'instance_or_static_offset':struct.unpack_from('<i',b,v.raw(offsets+n*4,4))[0]})
   for mi in range(start,start+count):
    method=v.method_info(mi);va=v.method_pointer(method);row={'original':method,'native_pointer':hex(va),'native_MethodDef_slot':v.u16(md,v.row('methods',mi,32)+28)}
    if va and v.executable(va):
     try:row['runtime_function']=region(v,va)
     except ValueError as e:row['region_error']=str(e);gaps.append({'method':method,'error':str(e)})
    else:row['region_error']='no executable original registered pointer'
    rows.append(row)
 for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source changed')
 source=WORKSPACE/'RR23/Assets/Scripts/Assembly-CSharp/RecRoomGameRoot.cs';report={'schema':'original-RecRoomGameRoot-external-base-startup-native-inventory/v1','original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'current_source':{'path':str(source),'sha256':sha(source),'meta_sha256':sha(str(source)+'.meta')},'original_types':types,'original_fields':fields,'methods':rows,'region_gaps':gaps,'source_body_recovered':False,'CSharp_body_invented_or_project_modified':False,'game_or_native_code_executed':False};rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':sha(rp),'types':types,'methods':[{'owner':r['original']['owner'],'name':r['original']['name'],'token':r['original']['token'],'VA':r['native_pointer'],'bytes':(r['runtime_function']['end_rva']-r['runtime_function']['start_rva']) if 'runtime_function'in r else None} for r in rows]}))
if __name__=='__main__':main()
