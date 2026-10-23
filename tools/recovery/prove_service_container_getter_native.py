"""Close every byte/path of the real lazy service getter; do not fake init.

Only original mappings, native metadata and installed matching runtime headers
are read. A factory dependency is preserved explicitly, never replaced by a
default object or treated as functional merely because a method body exists.
"""
from pathlib import Path
import ctypes,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from native_metadata import NativeMetadata
from audit_ogpeg_constructors import Decoder,need
from audit_forwarding import EXPECTED,sha
from prove_recroom_ondestroy_native_cfg import aliases
WINDOW=ROOT/'Validation/ServiceContainerNativeWindows-20261022T180635Z-6a8820b3/report.json'

def decode(code,va):
 d=Decoder(code,va);d.literal('48 83 ec 28');flag=d.relative('80 3d','00');skip=d.short('75');a=d.relative('48 8d 0d');init_a=d.relative('e8');b=d.relative('48 8d 0d');init_b=d.relative('e8');written=d.relative('c6 05','01');ready=va+d.at
 load_a=d.relative('48 8b 05');d.literal('48 89 7c 24 20 48 8b 88 b8 00 00 00 48 8b 41 08 48 85 c0');nonnull=d.relative('0f 85');load_b=d.relative('48 8b 0d');d.literal('48 8d 54 24 38 89 44 24 38');box=d.relative('e8');d.literal('48 8b f8 48 85 c0');null=d.short('74')
 d.literal('4c 8b 00 48 8b c8 48 89 5c 24 30 49 8b 90 70 01 00 00 41 ff 90 68 01 00 00 48 8b cf 48 8b d8');unbox=d.relative('e8');d.literal('45 33 c0 33 d2 8b 08 89 4c 24 38 48 8b cb');create=d.relative('e8');store_a=d.relative('48 8b 0d');d.literal('48 8b d0 48 8b 89 b8 00 00 00 48 83 c1 08 48 89 01');barrier=d.relative('e8');final_a=d.relative('48 8b 05');d.literal('48 8b 5c 24 30 48 8b 88 b8 00 00 00 48 8b 41 08');epilog=va+d.at
 d.literal('48 8b 7c 24 20 48 83 c4 28 c3');null_tail=va+d.at;nre=d.relative('e8');d.literal('cc');semantic=d.at;need(len(code)==240 and all(x==0xcc for x in code[semantic:]),'Original registered-bound window padding differs');d.literal('cc '*(len(code)-semantic));d.end()
 need(flag==written and skip==ready and a==load_a==store_a==final_a and b==load_b,'Metadata guard/usage aliases differ')
 need(nonnull==epilog and null==null_tail,'Normal/null CFG edges do not close')
 need(init_a==init_b==0x1806c01e0 and box==0x180641680 and unbox==0x180640e30 and barrier==0x1806bfd30 and nre==0x1806c0390,'Anchored runtime helper differs')
 need(create==0x186767f40,'Real original container factory target differs')
 return {'class_usage':hex(a),'enum_usage':hex(b),'metadata_initialize':hex(init_a),'box_export':hex(box),'unbox_export':hex(unbox),'factory':hex(create),'write_barrier':hex(barrier),'null_helper':hex(nre),'static_field_offset':8,'native_virtual_method_pointer_offset':0x168,'native_virtual_MethodInfo_offset':0x170,'normal_return_epilog':hex(epilog),'null_exception_tail':hex(null_tail),'semantic_bytes':semantic,'padding_bytes':len(code)-semantic,'all240_bytes_checked':True,'all_normal_and_exception_edges_closed':True}

def exported(v,name):
 opt=v.u32(v.b,60)+24;a=v.raw(v.base+v.u32(v.b,opt+112),40);nf=v.u32(v.b,a+20);nn=v.u32(v.b,a+24);fp=v.raw(v.base+v.u32(v.b,a+28),nf*4);np=v.raw(v.base+v.u32(v.b,a+32),nn*4);op=v.raw(v.base+v.u32(v.b,a+36),nn*2);hits=[]
 for i in range(nn):
  if v.cstr(v.base+v.u32(v.b,np+i*4))==name:hits.append(v.base+v.u32(v.b,fp+v.u16(v.b,op+i*2)*4))
 need(len(hits)==1,'Unique original runtime export absent:'+name);return hits[0]

def header_layout():
 # Matching2020.3.33 header, AMD64 MSVC default8-byte aggregate alignment.
 pointer=ctypes.c_uint64
 class Type(ctypes.Structure):_fields_=[('data',pointer),('bits',ctypes.c_uint32)]
 class Class(ctypes.Structure):
  _fields_=[(x,pointer)for x in ['image','gc_desc','name','namespace']]+[('byval',Type),('this_arg',Type)]+[(x,pointer)for x in ['element','cast','declaring','parent','generic','type_handle','interop','klass','fields','events','properties','methods','nested','interfaces','interface_offsets','static_fields','rgctx','hierarchy','unity_data']]+[(x,ctypes.c_uint32)for x in ['init_exception','cctor_started','cctor_finished']]+[('cctor_thread',pointer),('generic_container',pointer)]+[(x,ctypes.c_uint32)for x in ['instance_size','actual_size','element_size','native_size','static_size','threadstatic_size','threadstatic_offset','flags','token']]+[(x,ctypes.c_uint16)for x in ['method_count','property_count','field_count','event_count','nested_count','vtable_count','interface_count','interface_offset_count']]+[(x,ctypes.c_uint8)for x in ['hierarchy_depth','recursion','rank','minimum_alignment','natural_alignment','packing','bits0','bits1']]+[('vtable_start',pointer)]
 need(ctypes.sizeof(Type)==16 and Class.static_fields.offset==0xb8 and Class.vtable_start.offset==0x138,'Exact matching AMD64 class layout differs')
 return {'Il2CppType_bytes':16,'static_fields_offset':Class.static_fields.offset,'vtable_offset':Class.vtable_start.offset,'VirtualInvokeData_bytes':16,'slot3_method_pointer_offset':Class.vtable_start.offset+3*16,'slot3_MethodInfo_offset':Class.vtable_start.offset+3*16+8}

def main():
 evidence=json.loads(WINDOW.read_text());row=next(x for x in evidence['methods']if x['original']['name']=='PNFLFFOAING');code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);shape=decode(code,va);layout=header_layout();paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
 for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source hash changed')
 with paths[0].open('rb')as f,paths[1].open('rb')as g,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ)as b,mmap.mmap(g.fileno(),0,access=mmap.ACCESS_READ)as md:
  v=NativeMetadata(b,md);method=v.find_method('MPAAIECKLGA',0x0600001e);need(v.method_pointer(method)==va and method['name']=='PNFLFFOAING' and method['flags']==2198 and method['return']=='MNALHHOLFGL' and not method['parameters'],'Original exact getter identity differs');a=v.raw(va,len(code));need(bytes(b[a:a+len(code)])==code,'Original getter bytes changed')
  uses={k:v.usage(int(shape[k],16))for k in ['class_usage','enum_usage']};need(uses['class_usage']['type']=='MPAAIECKLGA' and uses['enum_usage']['type']=='NAFLJHIHEAG' and all(x['kind']==1 for x in uses.values()),'Original metadata class uses differ')
  ti=method['owner_index'];td=v.row('typeDefinitions',ti,88);need(v.u32(md,td+28)&0x100000,'Original BeforeFieldInit flag differs');first=v.i32(md,td+36);count=v.u16(md,td+64);need(not any(v.string(v.i32(md,v.row('methods',i,32)))=='.cctor'for i in range(first,first+count)),'Original cctor assumption differs')
  fs=v.i32(md,td+32);fc=v.u16(md,td+68);fo=v.raw(v.u64(b,v.field_offsets+ti*8),fc*4);fields=[]
  for i in range(fc):
   at=v.row('fields',fs+i,12);nt=v.native_type(v.i32(md,at+4));fields.append({'name':v.string(v.i32(md,at)),'type':v.typename(nt),'token':hex(v.u32(md,at+8)),'flags':nt['attributes'],'offset':v.i32(b,fo+i*4)})
  field=[x for x in fields if x['offset']==8];need(len(field)==1 and field[0]['name']=='OAEHHEPLLJE' and field[0]['flags']==17 and field[0]['type']=='MNALHHOLFGL','Original nonvolatile static service field differs')
  enum_ti=next(i for i in range(v.count('typeDefinitions',88))if v.full_name(i)=='NAFLJHIHEAG');et=v.row('typeDefinitions',enum_ti,88);vt=v.i32(md,et+56);encoded=v.u32(md,v.row('vtableMethods',vt+3,4));need(encoded>>29==3,'Original virtualslot is not MethodDef');index=(encoded&0x1fffffff)>>1;virtual=v.method_info(index);ma=v.row('methods',index,32)
  need(virtual['owner']=='System.Enum' and virtual['name']=='ToString' and virtual['image']=='mscorlib.dll' and virtual['return']=='System.String' and not virtual['parameters'] and v.u16(md,ma+28)==3,'Exact virtualslot does not target System.Enum.ToString')
  exports={name:hex(exported(v,name))for name in ['il2cpp_value_box','il2cpp_object_unbox','il2cpp_gc_wbarrier_set_field']};need(exports['il2cpp_value_box']==shape['box_export'] and exports['il2cpp_object_unbox']==shape['unbox_export'],'Box/unbox are not exact original exports')
  wb=int(exports['il2cpp_gc_wbarrier_set_field'],16);q=v.raw(wb,11);public=Decoder(bytes(b[q:q+11]),wb);public.literal('48 8b ca 4c 89 02');wb_public=public.relative('e9');public.end();q=v.raw(int(shape['write_barrier'],16),5);thunk=Decoder(bytes(b[q:q+5]),int(shape['write_barrier'],16));need(thunk.relative('e9')==wb_public,'Write barrier export/thunk target differs');thunk.end()
  factory=v.find_method('MPAAIECKLGA',0x06000028);need(v.method_pointer(factory)==int(shape['factory'],16) and factory['name']=='OBAIKOPBHAP' and [p['type']for p in factory['parameters']]==['System.String','MNALHHOLFGL'],'Exact original factory signature differs')
  ps=v.i32(md,td+44);pc=v.u16(md,td+66);properties=[]
  for i in range(pc):
   q=v.row('properties',ps+i,20)
   if first+v.i32(md,q+4)==method['index']:properties.append({'name':v.string(v.i32(md,q)),'token':hex(v.u32(md,q+16)),'setter':v.i32(md,q+8)})
  need(len(properties)==1 and properties[0]['name']=='CFHDLGEGDFD' and properties[0]['setter']==-1,'Original exact getter/property ownership differs')
 controls=[]
 for label,old,new in [('static-field-offset','48 8b 41 08','48 8b 41 10'),('virtual-slot','41 ff 90 68 01 00 00','41 ff 90 78 01 00 00'),('factory-parent-null','45 33 c0 33 d2','45 33 c0 33 c9'),('barrier-store','48 83 c1 08 48 89 01','48 83 c1 10 48 89 01'),('final-service-reload','48 8b 88 b8 00 00 00 48 8b 41 08','48 8b 88 b8 00 00 00 48 8b 41 10')]:
  a=bytes.fromhex(old);need(a in code,'Mutation anchor absent');changed=code.replace(a,bytes.fromhex(new),1)
  try:decode(changed,va)
  except (ValueError,struct.error):controls.append({'case':label,'rejected':True})
  else:raise AssertionError('Wrong original getter mutation accepted:'+label)
 report={'schema':'original-lazy-service-getter-full-native-CFG/v1','status':'complete_getter_native_proven_factory_dependency_unrecovered','original':method,'property':properties[0],'native_pointer':hex(va),'all240_native_bytes':code.hex(),'native_sha256':hashlib.sha256(code).hexdigest(),'exact_control_flow':shape,'native_class_layout':layout,'original_metadata_uses':uses,'service_field':field[0],'original_virtual_slot3_method':virtual,'runtime_exports':exports,'factory_dependency':factory,'declaring_type_has_no_cctor':True,'semantic_paths':['Existing nonnull field: return exact cached reference; no factory call or writes.','Null field: box enumzero; invoke exact original System.Enum.ToString throughslot3; preserve original factory(name,null) call; store+GCbarrier; reload sharedfield and return.','Original boxednull runtimepath raises NullReferenceException; Enum/factory exceptions propagate.'],'no_lock_or_default_service_added':True,'all_boot_dependencies_closed':False,'new_factory_or_constructor_behavior_invented':False,'source_candidate_emitted':False,'blocked_by':['MPAAIECKLGA.OBAIKOPBHAP original factory behavior and its container/registration dependencies must be recovered; do not replace with new/default service or fake a completed bootstrap.'],'negative_controls':controls,'inputs':[{'path':str(p),'sha256':sha(p)}for p in [WINDOW]+paths+[WS/'Tools/Editors/2020.3.33f1/Editor/Data/il2cpp/libil2cpp/il2cpp-class-internals.h',WS/'Tools/RecoveryTools/Cpp2IL-development-b5ad444b-Unity2020LayoutRecovery/Source/Cpp2IL-b5ad444b82267cb1e4b88b8b373c008105bdea52/LibCpp2IL/MetadataUsage.cs']],'project_modified':False,'native_or_game_code_executed':False}
 out=ROOT/'Validation'/('ServiceContainerGetterCFG-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'semantic_bytes':shape['semantic_bytes'],'negative_controls':len(controls)}))

if __name__=='__main__':main()
