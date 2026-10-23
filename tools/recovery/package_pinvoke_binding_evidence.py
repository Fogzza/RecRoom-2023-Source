"""Package reviewed native facts and explicit ABI/dependency gaps; never apply."""
from pathlib import Path
import hashlib,json,mmap,struct,sys,shutil,collections
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE));from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha

def link(p):return {'path':str(p),'sha256':sha(p)}
def main():
 folder=Path(sys.argv[1]);out=folder/'ReviewedEvidencePackage';need(not out.exists(),'Fresh package required');out.mkdir()
 proof_path=folder/'effective-bindings-v6.json';dependency_path=folder/'native-dependencies-v2.json';control_path=folder/'negative-controls-v1.json'
 proof=json.loads(proof_path.read_text());deps=json.loads(dependency_path.read_text());controls=json.loads(control_path.read_text());need(proof['proven_count']==846 and not proof['unresolved'] and controls['passed'] and controls['negative_count']==148,'Complete native/control prerequisites')
 need(proof['tool']['sha256']==sha(proof['tool']['path'])==controls['production_proof_source']['sha256'],'Production source/control drift');need(deps['binding_proof']['sha256']==sha(proof_path),'Dependency proof does not target final bindings')
 dep_by_module={r['module']:r for r in deps['modules']};paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Verified original source changed');paths.append(p)
 rows=[];value_types=set()
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md)
  for r in proof['methods']:
   m=r['original'];fresh=v.method_info(m['index']);fresh['declaring_type']=v.type_info(fresh['owner_index']);need(fresh==m and v.method_pointer(fresh)==int(r['original_native_pointer'],16),'Native identity/pointer drift')
   at=v.row('methods',m['index'],32);first=v.i32(md,at+12);parameters=[]
   for ordinal,p in enumerate(m['parameters']):
    pa=v.row('parameters',first+ordinal,12);nt=p['native_type'];parameters.append({'ordinal':ordinal,'name':p['name'],'original_ParameterDef_token':hex(v.u32(md,pa+4)),'native_parameter_index':first+ordinal,'type':p['type'],'native_type_descriptor':nt,'native_Il2CppType_attribute_bits':nt['attributes']})
    if nt['kind']==17:value_types.add(nt['data'])
   ret=v.native_type(v.i32(md,at+8))
   if ret['kind']==17:value_types.add(ret['data'])
   binding=r['effective_binding'];dependency=dep_by_module[binding['module']['value']];availability='not present in verified original Windows client'
   if 'matched' in dependency:
    match=[x for x in dependency['matched'] if x['native_method_token']==m['token'] and x['owner']==m['owner']]
    availability='export present in '+dependency['status'] if len(match)==1 else 'entry point absent from verified original vendor DLL'
   rows.append({'target_assembly':'Assembly-CSharp','original_native_MethodDef_token':m['token'],'original_native_method_index':m['index'],'declaring_type':m['owner'],'declaring_type_original_token':m['declaring_type']['token'],'method_name':m['name'],'return_type':m['return'],'return_native_type_descriptor':ret,'parameters':parameters,'original_MethodAttributes':m['flags'],'original_MethodImplAttributes':m['impl_flags'],
    'original_native_pointer':r['original_native_pointer'],'native_runtime_region_sha256':r['registered_runtime_function_region']['sha256'],
    'effective_import':{'module':binding['module']['value'],'entry_point':binding['entry_point']['value'],'native_calling_convention':binding['calling_convention'],'native_char_set':binding['char_set'],'native_parameter_size_bytes':binding['parameter_size_bytes'],'is_no_mangle':binding['is_no_mangle']},
    'native_dependency_availability':availability,'original_ImplMap_bytes_recovered':False,'complete_managed_MarshalAs_payloads_recovered':False,'automatic_runtime_patch_allowed':False})
  sizes_count=v.u64(b,v.raw(0x187f85ef0+96,8));need(sizes_count==v.count('typeDefinitions',88),'TypeDefinitionSizes count differs');size_ptrs=v.raw(v.u64(b,v.raw(0x187f85ef0+104,8)),sizes_count*8);layouts=[]
  for ti in sorted(value_types):
   info=v.type_info(ti);ta=v.row('typeDefinitions',ti,88);start=v.i32(md,ta+32);count=v.u16(md,ta+68);offset_ptr=v.u64(b,v.field_offsets+ti*8);offsets=v.raw(offset_ptr,count*4) if count else None;fields=[]
   for ordinal in range(count):
    fa=v.row('fields',start+ordinal,12);nt=v.native_type(v.i32(md,fa+4))
    try:type_name=v.typename(nt)
    except ValueError:type_name=None
    fields.append({'ordinal':ordinal,'original_field_token':hex(v.u32(md,fa+8)),'name':v.string(v.i32(md,fa)),'type':type_name,'native_type_descriptor':nt,'registered_IL2CPP_field_offset':v.i32(b,offsets+ordinal*4)})
   pointer=v.u64(b,size_ptrs+ti*8);sa=v.raw(pointer,16);instance,native,static,thread=struct.unpack_from('<IiII',b,sa)
   layouts.append({'original_type':info,'registered_type_sizes_pointer':hex(pointer),'registered_sizes':{'instance_size':instance,'native_size':native,'static_fields_size':static,'thread_static_fields_size':thread},'fields':fields,'offset_interpretation':'Raw original IL2CPP field-offset table values, not new CLR FieldOffset annotations. Value payload/header and marshaling layout must be proved separately.','native_MarshalAs_layout_fully_recovered':False})
 manifest={'schema':'reviewed-original-effective-import-bindings/v1','status':'evidence_only_no_project_apply','original_source_inputs':[link(p) for p in paths],'proof':link(proof_path),'controls':link(control_path),'dependency_audit':link(dependency_path),'binding_count':846,'bindings':rows,'value_type_layout_evidence':layouts,'abi_unknown_ledger':[
  {'area':'Original ImplMap table','known':'Original modules, entry names, effective native calling convention, native charset, parameter byte size and no-mangle resolver inputs','unknown':'Original full ImplMap attribute bytes were stripped; effective values are not a claim of metadata byte recovery.'},
  {'area':'Managed charset','known':'CHARSET_ANSI/UNICODE/NOT_SPECIFIED native resolver enum','unknown':'Whether managed CharSet.Auto or another source choice lowered to the same Windows native enum cannot be inferred from that enum alone.'},
  {'area':'SetLastError','known':'Three PS4 wrappers have separate complete body proof of no post-call last-error capture','unknown':'Batch proof does not yet classify all split PE unwind/body regions or every post-native-call helper. No default SetLastError bit is invented.'},
  {'area':'Character conversion flags','known':'Native literal names and exact resolver inputs','unknown':'BestFitMapping/ThrowOnUnmappableChar original bits may be optimized away or semantically unobserved; not guessed.'},
  {'area':'Parameter/return marshalling','known':'Original native parameter tokens/types/type attributes and registered value-type sizes/field offsets, plus retained native wrapper bytes','unknown':'Complete MarshalAs/custom-marshaler payloads and bool/string/array/native-struct contracts are not rebuilt from resolver inputs alone.'},
  {'area':'Native libraries','known':'Original SteamDLL809 matching exports,23 current-PC system export matches;2 Steamserver exports and12 module-specific requests unavailable in verified original Windows inventory','unknown':'No unused/platform-gated call is treated as required on every target. No substitutes or platform toggles are introduced.'}],
  'automatic_ImplMap_or_MarshalAs_patch_allowed':False,'original_platform_code_and_filters_unchanged':True,'project_modified':False,'game_or_native_code_executed':False}
 (out/'binding-ledger.json').write_text(json.dumps(manifest,indent=2)+'\n')
 source_files=[HERE/'collect_all_pinvoke_native.py',HERE/'prove_all_pinvoke_resolver_args.py',HERE/'test_all_pinvoke_proofs.py',HERE/'audit_pinvoke_native_dependencies.py',HERE/'package_pinvoke_binding_evidence.py',HERE/'DisassemblePInvokeWrappers.cs',HERE/'audit_original_pinvoke_wrappers.py',HERE.parent/'ConstructorEvidence/native_metadata.py',HERE.parent/'ConstructorEvidence/audit_forwarding.py',HERE.parent/'ConstructorEvidence/audit_generic_forwarders.py',HERE.parent/'ConstructorEvidence/audit_ogpeg_constructors.py'];snapshots=[]
 for source in source_files:
  target=out/'SourceSnapshots'/source.relative_to(WORKSPACE);target.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(source,target);need(sha(source)==sha(target),'Source snapshot drift');snapshots.append({'source':str(source),'snapshot':str(target),'sha256':sha(source)})
 decoder=HERE/'PInvokeDisassembler-20261022T124000Z';decoder_files=[decoder/'DisassemblePInvokeWrappers.dll',decoder/'Iced.dll',decoder/'compile.rsp']
 receipt={'schema':'native-import-evidence-package-receipt/v1','manifest':link(out/'binding-ledger.json'),'sources':snapshots,'decoder_artifacts':[link(p) for p in decoder_files],'negative_controls':link(control_path),'effective_proof':link(proof_path),'dependency_proof':link(dependency_path),'source_count':len(snapshots),'bindings':846,'value_type_layouts':len(layouts),'project_modified':False,'native_code_executed':False};(out/'receipt.json').write_text(json.dumps(receipt,indent=2)+'\n')
 print(json.dumps({'package':str(out),'manifest':str(out/'binding-ledger.json'),'manifest_sha256':sha(out/'binding-ledger.json'),'bindings':846,'value_type_layouts':len(layouts),'receipt':str(out/'receipt.json')}))
if __name__=='__main__':main()
