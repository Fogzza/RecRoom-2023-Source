"""Original v27.1 OpenVR identities, flags and constant ownership; no execution."""
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(WS/'Tools/RecoveryTools/ConstructorEvidence'));from native_metadata import NativeMetadata,PRIMITIVES
PRIMITIVES.update({24:'System.IntPtr',25:'System.UIntPtr'})
def sha(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  while b:=f.read(1024*1024):h.update(b)
 return h.hexdigest()
out=ROOT/'Validation'/('NativeOpenVr-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-native-openvr-contract-inventory/v1','project_modified':False,'native_code_executed':False}
try:
 inputs=[(ROOT/'CodeSource/GameAssembly.dll','ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b'),(ROOT/'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat','1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474')]
 if any(sha(p)!=h for p,h in inputs):raise ValueError('Original input hash differs')
 with inputs[0][0].open('rb') as bf,inputs[1][0].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
  v=NativeMetadata(b,m);image=next(x for x in v.images if x['name']=='Unity.XR.OpenVR.dll');defaults={struct.unpack_from('<iii',m,v.row('fieldDefaultValues',k,12))[0]:struct.unpack_from('<iii',m,v.row('fieldDefaultValues',k,12))[1:] for k in range(v.count('fieldDefaultValues',12))};types=[]
  for ti in range(image['start'],image['start']+image['count']):
   td=v.row('typeDefinitions',ti,88);owner=v.full_name(ti);fields=[];methods=[];first=v.i32(m,td+32)
   for ordinal in range(v.u16(m,td+68)):
    fi=first+ordinal;at=v.row('fields',fi,12);native=v.native_type(v.i32(m,at+4));row={'owner':owner,'owner_token':v.u32(m,td+84),'name':v.string(v.i32(m,at)),'token':v.u32(m,at+8),'metadata_index':fi,'ordinal':ordinal,'type':v.typename(native),'native_type':native,'flags':native['attributes']}
    if fi in defaults:
     ft,di=defaults[fi];nt=v.native_type(ft);base,length=v.tables['fieldAndParameterDefaultValueData']
     if di>=0 and nt['kind']==14:
      size=v.i32(m,base+di)
      if not 0<=size<=2048 or di+4+size>length:raise ValueError('Unbounded native string')
      row['constant']=m[base+di+4:base+di+4+size].decode('utf-8')
     elif di>=0 and nt['kind']==8:row['constant']=v.i32(m,base+di)
    fields.append(row)
   firstm=v.i32(m,td+36)
   for mi in range(firstm,firstm+v.u16(m,td+64)):
    at=v.row('methods',mi,32);rt=v.native_type(v.i32(m,at+8));params=[];firstp=v.i32(m,at+12)
    for ordinal in range(v.u16(m,at+30)):
     p=v.row('parameters',firstp+ordinal,12);pt=v.native_type(v.i32(m,p+8));params.append({'sequence':ordinal+1,'name':v.string(v.i32(m,p)),'token':v.u32(m,p+4),'type':v.typename(pt),'native_type':pt,'flags':pt['attributes']})
    methods.append({'owner':owner,'name':v.string(v.i32(m,at)),'token':v.u32(m,at+20),'metadata_index':mi,'flags':v.u16(m,at+24),'impl_flags':v.u16(m,at+26),'return_type':v.typename(rt),'return_native_type':rt,'return_flags':rt['attributes'],'parameters':params})
   types.append({'name':owner,'token':v.u32(m,td+84),'metadata_index':ti,'flags':v.u32(m,td+28),'fields':fields,'methods':methods})
  report.update(status='inventoried',image=image,types=types,marshal_fields=sum(bool(f['flags']&4096) for t in types for f in t['fields']),marshal_parameters=sum(bool(p['flags']&8192) for t in types for f in t['methods'] for p in f['parameters']),marshal_returns=sum(bool(f['return_flags']&8192) for t in types for f in t['methods']))
 if any(sha(p)!=h for p,h in inputs):raise ValueError('Original input changed')
 report['original_inputs']=[{'path':str(p),'sha256':h} for p,h in inputs];report['original_inputs_before_after_verified']=True
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error'),'fields':report.get('marshal_fields'),'parameters':report.get('marshal_parameters')}),flush=True)
