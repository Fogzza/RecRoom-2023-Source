"""Read-only original version/default and marshaling flag witnesses; no IL load."""
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(WS/'Tools/RecoveryTools/ConstructorEvidence'));from native_metadata import NativeMetadata,PRIMITIVES
PRIMITIVES.update({24:'System.IntPtr',25:'System.UIntPtr'})
OFFICIAL=ROOT/'Validation/OfficialSteamworks14-20261022T140058Z-91fe31a3/report.json'
def need(x,s):
 if not x:raise ValueError(s)
def sha(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  while b:=f.read(1024*1024):h.update(b)
 return h.hexdigest()
out=ROOT/'Validation'/('NativeSteamworks14-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-native-steamworks14-contract-inventory/v1','status':'preparing','project_modified':False,'original_code_executed':False,'official_source_report':str(OFFICIAL),'official_source_report_sha256':sha(OFFICIAL)}
inputs=[(ROOT/'CodeSource/GameAssembly.dll','ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b'),(ROOT/'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat','1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474')];need(all(sha(p)==h for p,h in inputs),'Verified original input SHA mismatch');report['original_inputs']=[{'path':str(p),'sha256':h} for p,h in inputs]
with (ROOT/'CodeSource/GameAssembly.dll').open('rb') as bf,(ROOT/'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat').open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
 v=NativeMetadata(b,m);defs={}
 for k in range(v.count('fieldDefaultValues',12)):
  f,t,d=struct.unpack_from('<iii',m,v.row('fieldDefaultValues',k,12));defs.setdefault(f,[]).append((k,t,d))
 fields=[];version=[];methods=[];native_imports=[]
 for ti in range(v.count('typeDefinitions',88)):
  td=v.row('typeDefinitions',ti,88);image=v.image_of_type(ti)['name']
  if image!='Assembly-CSharp.dll':continue
  owner=v.full_name(ti);first=v.i32(m,td+32)
  for ordinal in range(v.u16(m,td+68)):
   fi=first+ordinal;at=v.row('fields',fi,12);ft=v.native_type(v.i32(m,at+4));flags=ft['attributes'];name=v.string(v.i32(m,at));token=hex(v.u32(m,at+8))
   if flags&0x1000 or owner=='Steamworks.Version':
    try:type_name=v.typename(ft)
    except ValueError as e:type_name={'unflattened_native_type':ft,'error':str(e)}
    row={'owner':owner,'owner_native_token':hex(v.u32(m,td+84)),'field_name':name,'field_native_token':token,'metadata_type_index':ti,'metadata_field_index':fi,'field_ordinal':ordinal,'type':type_name,'native_type':ft,'flags':flags,'HasFieldMarshal':bool(flags&0x1000)}
    if flags&0x1000:fields.append(row)
    if owner=='Steamworks.Version':
     need(len(defs.get(fi,[]))==1,'Version constant default ownership not unique');k,t,d=defs[fi][0];base,length=v.tables['fieldAndParameterDefaultValueData'];nt=v.native_type(t);need(0<=d<=length-4,'Version data out of bounds')
     if nt['kind']==14:
      size=v.i32(m,base+d);need(0<=size<=1024 and d+4+size<=length,'Bounded version string required');value=m[base+d+4:base+d+4+size].decode('utf-8')
     elif nt['kind']==8:value=v.i32(m,base+d)
     else:raise ValueError('Unrecognized version constant type')
     row.update(default_value=value,default_row=k,default_type_index=t,default_data_index=d);version.append(row)
  start=v.i32(m,td+36)
  for mi in range(start,start+v.u16(m,td+64)):
   at=v.row('methods',mi,32);firstp=v.i32(m,at+12);params=[];rt=v.native_type(v.i32(m,at+8))
   if owner=='Steamworks.NativeMethods':native_imports.append(v.method_info(mi))
   if rt['attributes']&0x2000:params.append({'sequence':0,'native_type':rt,'flags':rt['attributes']})
   for pi in range(v.u16(m,at+30)):
    p=v.row('parameters',firstp+pi,12);pt=v.native_type(v.i32(m,p+8))
    if pt['attributes']&0x2000:params.append({'sequence':pi+1,'name':v.string(v.i32(m,p)),'original_parameter_token':hex(v.u32(m,p+4)),'metadata_parameter_index':firstp+pi,'native_type':pt,'flags':pt['attributes']})
   if params:methods.append({'owner':owner,'owner_native_token':hex(v.u32(m,td+84)),'method_name':v.string(v.i32(m,at)),'original_method_token':hex(v.u32(m,at+20)),'metadata_method_index':mi,'marshal_parameters':params})
 expected={'SteamworksNETVersion':'14.0.0','SteamworksSDKVersion':'1.48','SteamAPIDLLVersion':'05.69.73.98','SteamAPIDLLSize':237856,'SteamAPI64DLLSize':262944};need({r['field_name']:r['default_value'] for r in version}==expected,'Native SDK/version constants differ')
 report.update(status='native_sdk_identity_proven',version_constants=version,marshal_fields=fields,marshal_methods=methods,native_steam_imports=native_imports,total_marshal_fields=len(fields),steamworks_marshal_fields=sum(x['owner'].startswith('Steamworks.') for x in fields),total_marshal_parameters=sum(len(x['marshal_parameters']) for x in methods),steamworks_marshal_parameters=sum(len(x['marshal_parameters']) for x in methods if x['owner'].startswith('Steamworks.')),source_version_match=expected,official_commit='445c9559d981a864b0c35a0ac6b9151b4d11e91d',limitations=['HasFieldMarshal proves native ownership but not its missing descriptor bytes. Exact official matching-source declarations still require per-member signature/layout validation.','Native return type attrs do not necessarily retain original Param0 marshal flags; count is a lower bound.'])
need(all(sha(p)==h for p,h in inputs),'Verified original inputs changed');report['original_inputs_before_after_verified']=True;(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'fields':report['total_marshal_fields'],'steam_fields':report['steamworks_marshal_fields'],'parameters':report['total_marshal_parameters'],'steam_parameters':report['steamworks_marshal_parameters']}),flush=True)
