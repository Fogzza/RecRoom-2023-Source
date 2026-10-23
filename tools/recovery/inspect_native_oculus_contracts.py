"""Original obfuscated Oculus identities and bounded version-cctor bytes only."""
import argparse,datetime as dt,hashlib,json,mmap,struct,sys,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(WS/'Tools/RecoveryTools/ConstructorEvidence'));from native_metadata import NativeMetadata,PRIMITIVES
PRIMITIVES.update({24:'System.IntPtr',25:'System.UIntPtr'})
def sha(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  while b:=f.read(1024*1024):h.update(b)
 return h.hexdigest()
parser=argparse.ArgumentParser();parser.add_argument('--version-owner',default='KJCHIEACBJI');args=parser.parse_args();out=ROOT/'Validation'/('NativeOculusContracts-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-native-obfuscated-oculus-contract-inventory/v1','project_modified':False,'native_code_executed':False,'selected_version_owner':args.version_owner}
try:
 inputs=[(ROOT/'CodeSource/GameAssembly.dll','ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b'),(ROOT/'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat','1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474')];assert all(sha(p)==h for p,h in inputs)
 with inputs[0][0].open('rb') as bf,inputs[1][0].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
  v=NativeMetadata(b,m);image=next(x for x in v.images if x['name']=='Oculus.VR.dll');defaults={struct.unpack_from('<iii',m,v.row('fieldDefaultValues',k,12))[0]:struct.unpack_from('<iii',m,v.row('fieldDefaultValues',k,12))[1:] for k in range(v.count('fieldDefaultValues',12))};types=[];cctor=None
  def typename(nt):
   try:return v.typename(nt)
   except ValueError as e:return {'unsupported_type':nt,'shape_error':str(e)}
  for ti in range(image['start'],image['start']+image['count']):
   td=v.row('typeDefinitions',ti,88);owner=v.full_name(ti);fields=[];methods=[];first=v.i32(m,td+32);field_count=v.u16(m,td+68);offsetptr=v.u64(b,v.field_offsets+ti*8);offsets=None;offset_error=None
   if offsetptr and field_count:
    try:offsets=v.raw(offsetptr,field_count*4)
    except ValueError as e:offset_error=str(e)
   for ordinal in range(field_count):
    fi=first+ordinal;at=v.row('fields',fi,12);nt=v.native_type(v.i32(m,at+4));row={'name':v.string(v.i32(m,at)),'token':v.u32(m,at+8),'metadata_index':fi,'ordinal':ordinal,'type':typename(nt),'native_type':nt,'flags':nt['attributes'],'offset':v.i32(b,offsets+ordinal*4) if offsets is not None else None}
    if fi in defaults:
     ft,di=defaults[fi];dnt=v.native_type(ft);base,length=v.tables['fieldAndParameterDefaultValueData']
     if di>=0 and dnt['kind']==14:
      size=v.i32(m,base+di);assert 0<=size<=4096 and di+4+size<=length;row['constant']=m[base+di+4:base+di+4+size].decode('utf-8')
     elif di>=0 and dnt['kind'] in (8,9):row['constant']=v.i32(m,base+di)
    if offset_error:row['offset_unavailable_reason']=offset_error
    fields.append(row)
   firstm=v.i32(m,td+36)
   for mi in range(firstm,firstm+v.u16(m,td+64)):
    at=v.row('methods',mi,32);rt=v.native_type(v.i32(m,at+8));params=[];firstp=v.i32(m,at+12)
    for ordinal in range(v.u16(m,at+30)):
     p=v.row('parameters',firstp+ordinal,12);pt=v.native_type(v.i32(m,p+8));params.append({'sequence':ordinal+1,'name':v.string(v.i32(m,p)),'token':v.u32(m,p+4),'type':typename(pt),'native_type':pt,'flags':pt['attributes']})
    row={'owner':owner,'name':v.string(v.i32(m,at)),'token':v.u32(m,at+20),'metadata_index':mi,'flags':v.u16(m,at+24),'impl_flags':v.u16(m,at+26),'return_type':typename(rt),'return_native_type':rt,'return_flags':rt['attributes'],'parameters':params};methods.append(row)
    if owner==args.version_owner and row['name']=='.cctor':cctor=row
   parent=v.i32(m,td+16);types.append({'name':owner,'token':v.u32(m,td+84),'metadata_index':ti,'flags':v.u32(m,td+28),'parent':typename(v.native_type(parent)) if parent>=0 else None,'native_bitfield':v.u32(m,td+80),'fields':fields,'methods':methods})
  assert cctor is not None;method=v.find_method(cctor['owner'],cctor['token']);pointer=v.method_pointer(method);pe=v.u32(b,60);opt=pe+24;dd=opt+112;prva,psize=struct.unpack_from('<II',b,dd+3*8);pstart=v.raw(v.base+prva,psize);ranges=[struct.unpack_from('<III',b,pstart+i) for i in range(0,psize,12) if v.u32(b,pstart+i)==pointer-v.base];assert len(ranges)==1;begin,end,unwind=ranges[0];assert 0<end-begin<=16384;code=bytes(b[v.raw(pointer,end-begin):v.raw(pointer,end-begin)+end-begin]);report['version_cctor']={'original':method,'native_pointer':hex(pointer),'complete_pdata_body_available':True,'native_bytes':code.hex(),'native_sha256':hashlib.sha256(code).hexdigest(),'pdata_size':len(code),'pdata_end_rva':hex(end),'unwind_rva':hex(unwind)}
  report.update(status='inventoried',image=image,types=types,marshal_fields=sum(bool(f['flags']&4096) for t in types for f in t['fields']),marshal_parameters=sum(bool(p['flags']&8192) for t in types for m in t['methods'] for p in m['parameters']))
 assert all(sha(p)==h for p,h in inputs);report['original_inputs']=[{'path':str(p),'sha256':h} for p,h in inputs];report['original_inputs_before_after_verified']=True
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error'),'fields':report.get('marshal_fields'),'parameters':report.get('marshal_parameters'),'cctor_bytes':report.get('version_cctor',{}).get('pdata_size')}),flush=True)
