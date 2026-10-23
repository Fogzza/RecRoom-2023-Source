"""Bounded complete v27 image/type/method accounting, never executes game code.

Native pointers are deliberately not used as evidence that a managed body exists.
All unrenderable signatures retain exact original indexes/descriptors as UNKNOWN.
"""
from pathlib import Path
import collections,datetime as dt,hashlib,importlib.util,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from native_metadata import NativeMetadata
EXPECTED={'GameAssembly.dll':'ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b','RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat':'1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474'}
def need(b,s):
 if not b:raise ValueError(s)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def dump(f,row):f.write(json.dumps(row,separators=(',',':'),ensure_ascii=True)+'\n')
SHAPE_SOURCE=HERE.parent/'PluginNativeFlagsInventory/ArrayVariant-20261022T101556Z/inventory_native_plugin_method_flags_arrays.py'
sp=importlib.util.spec_from_file_location('proven_shapes',SHAPE_SOURCE);shape_module=importlib.util.module_from_spec(sp);sp.loader.exec_module(shape_module)
class DisplayMetadata(NativeMetadata):
 def typename(self,t,depth=0):
  if t['kind'] in (22,24,25):
   need(not t['num_mods'] and not t['pinned'],'Modified/pinned display not flattened');return {22:'System.TypedReference',24:'System.IntPtr',25:'System.UIntPtr'}[t['kind']]+('&' if t['byref'] else '')
  if t['kind']==20:
   need(depth<=16 and not t['num_mods'] and not t['pinned'],'Array display shape unsupported');at=self.raw(t['data'],32);rank,ns,nl=struct.unpack_from('<BBB',self.b,at+8);need(2<=rank<=32 and ns==nl==0 and self.u64(self.b,at+16)==self.u64(self.b,at+24)==0,'Only proved unspecified multidimensional shape rendered');return self.typename(self.type_at(self.u64(self.b,at)),depth+1)+'['+','*(rank-1)+']'+('&' if t['byref'] else '')
  return super().typename(t,depth)
def main():
 out=ROOT/'Validation'/('AllOriginalScripts-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();inputs=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Original source SHA mismatch');inputs.append({'path':str(p),'sha256':digest,'size':p.stat().st_size})
 with Path(inputs[0]['path']).open('rb') as bf,Path(inputs[1]['path']).open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=DisplayMetadata(b,md);shapes=shape_module.Shapes(v);nt=v.count('typeDefinitions',88);nm=v.count('methods',32);covered_types=bytearray(nt);covered_methods=bytearray(nm);summaries=[];render_errors=collections.Counter();shape_errors=collections.Counter()
  # Resolve type names only; type flags/counts/tokens are taken from original tables.
  for ti in range(nt):v.full_name(ti)
  for image in v.images:
   name=image['name'];need(Path(name).name==name and name.endswith('.dll'),'Unsafe original image name');types_path=out/(name+'.types.jsonl');methods_path=out/(name+'.methods.jsonl');seen_type_tokens=set();seen_method_tokens=set();counts=collections.Counter();errors=collections.Counter()
   def rendered(index):
    native=v.native_type(index)
    try:return {'original_type_index':index,'native_descriptor':native,'display_type':v.typename(native),'display_status':'rendered'}
    except ValueError as e:errors[str(e)]+=1;render_errors[str(e)]+=1;return {'original_type_index':index,'native_descriptor':native,'display_type':None,'display_status':'unknown_explicit','display_error':str(e)}
   shapes.cache.clear()
   with types_path.open('w',encoding='utf-8') as tf,methods_path.open('w',encoding='utf-8') as mm:
    for ti in range(image['start'],image['start']+image['count']):
     need(0<=ti<nt and covered_types[ti]==0,'Native image type partition gap/overlap');covered_types[ti]=1;at=v.row('typeDefinitions',ti,88);token=v.u32(md,at+84);need(token>>24==2 and token&0xffffff and token not in seen_type_tokens,'Invalid/duplicate native TypeDef token within image');seen_type_tokens.add(token);owner=v.full_name(ti);start=v.i32(md,at+36);method_count=v.u16(md,at+64);flags=v.u32(md,at+28);bits=v.u32(md,at+80)
     dump(tf,{'record':'type','image':name,'image_index':image['index'],'native_type_index':ti,'original_type_token':hex(token),'full_name':owner,'original_flags':flags,'native_bitfield':bits,'is_value_type':bool(bits&1),'is_enum':bool(bits&2),'generic_container_index':v.i32(md,at+24),'parent_type_index':v.i32(md,at+16),'method_start':start,'method_count':method_count,'field_start':v.i32(md,at+32),'field_count':v.u16(md,at+68),'property_count':v.u16(md,at+66),'event_count':v.u16(md,at+70),'source_presence':'not_yet_joined','managed_type_presence':'not_yet_joined','body_recovery':'not_assessed_from_native_metadata'})
     counts['types']+=1;counts['methods']+=method_count;counts['fields']+=v.u16(md,at+68);counts['properties']+=v.u16(md,at+66);counts['events']+=v.u16(md,at+70)
     if method_count:need(0<=start and start+method_count<=nm,'Native method range out of bounds')
     for mi in range(start,start+method_count):
      need(covered_methods[mi]==0,'Method belongs to duplicate original type');covered_methods[mi]=1;ma=v.row('methods',mi,32);need(v.i32(md,ma+4)==ti,'Native method declaring owner disagrees with type range');mtoken=v.u32(md,ma+20);need(mtoken>>24==6 and mtoken&0xffffff and mtoken not in seen_method_tokens,'Invalid/duplicate native MethodDef token within image');seen_method_tokens.add(mtoken);pstart=v.i32(md,ma+12);pcount=v.u16(md,ma+30);params=[]
      for pi in range(pstart,pstart+pcount):
       pa=v.row('parameters',pi,12);params.append({'original_parameter_index':pi,'original_parameter_token':hex(v.u32(md,pa+4)),'name':v.string(v.i32(md,pa)),**rendered(v.i32(md,pa+8))})
      gc=v.i32(md,ma+16);arity=0
      if gc>=0:
       ga=v.row('genericContainers',gc,16);need(v.i32(md,ga)==mi and v.i32(md,ga+8)==1,'Original method generic container ownership differs');arity=v.i32(md,ga+4)
      method={'record':'method','image':name,'image_index':image['index'],'native_type_index':ti,'original_type_token':hex(token),'owner':owner,'native_method_index':mi,'original_method_token':hex(mtoken),'name':v.string(v.i32(md,ma)),'original_flags':v.u16(md,ma+24),'original_impl_flags':v.u16(md,ma+26),'generic_container_index':gc,'generic_arity':arity,'return':rendered(v.i32(md,ma+8)),'parameters':params,'managed_body_status':'not_assessed','native_pointer_presence_is_body_recovery':False}
      try:method.update(return_shape=shapes.index(v.i32(md,ma+8)),parameters_shape=[shapes.index(v.i32(md,v.row('parameters',pi,12)+8)) for pi in range(pstart,pstart+pcount)],shape_status='exact_scoped_positional_native_type_graph')
      except ValueError as e:shape_errors[str(e)]+=1;method.update(return_shape=None,parameters_shape=None,shape_status='unknown_explicit',shape_error=str(e))
      dump(mm,method)
   summaries.append({'image':name,'image_index':image['index'],'native_type_start':image['start'],'native_type_count':image['count'],'counts':dict(counts),'types':{'path':str(types_path),'sha256':sha(types_path)},'methods':{'path':str(methods_path),'sha256':sha(methods_path)},'display_signature_unknowns':dict(errors)})
  need(all(covered_types) and all(covered_methods),'Original type/method inventory has unaccounted records');need(sum(s['counts']['types'] for s in summaries)==nt and sum(s['counts']['methods'] for s in summaries)==nm,'Original partition count mismatch')
  for row in inputs:need(sha(row['path'])==row['sha256'],'Original source changed during accounting')
  report={'schema':'complete-original-v27-script-metadata-accounting/v2','status':'native_inventory_complete_current_source_and_body_joins_pending','inputs':inputs,'tool':{'path':str(Path(__file__).resolve()),'sha256':sha(Path(__file__).resolve())},'native_reader':{'path':str(HERE.parent/'ConstructorEvidence/native_metadata.py'),'sha256':sha(HERE.parent/'ConstructorEvidence/native_metadata.py')},'strict_shape_reader':{'path':str(SHAPE_SOURCE),'sha256':sha(SHAPE_SOURCE)},'original_images':len(summaries),'original_types':nt,'original_methods':nm,'type_partition_covered':sum(covered_types),'method_partition_covered':sum(covered_methods),'unaccounted_types':covered_types.count(0),'unaccounted_methods':covered_methods.count(0),'images':summaries,'signature_display_unknowns':dict(render_errors),'strict_scoped_signature_unknowns':dict(shape_errors),'scope':'All original images, including platform/framework/engine code. No platform filters removed.','body_limitation':'This report accounts original definitions only. Native pointer presence, dummy DLL methods, C# declarations or nonempty IL are not proof of restored behavior. Current source/runtime joins and explicit missing/empty/proven/unknown classifications are separate pending gates.','project_modified':False,'game_or_sdk_code_executed':False};(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'images':len(summaries),'types':nt,'methods':nm,'unaccounted':0,'display_unknowns':sum(render_errors.values()),'strict_shape_unknowns':sum(shape_errors.values())}))
if __name__=='__main__':main()
