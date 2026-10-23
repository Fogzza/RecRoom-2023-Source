"""Recover three literal PInvoke bindings from original registered native wrappers.

No DLL is loaded and no client code is executed. This proves effective ABI and
resolver inputs, not unavailable bits of the original stripped ImplMap table.
"""
import hashlib,json,mmap,struct,sys,uuid
from datetime import datetime,timezone
from pathlib import Path
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from native_metadata import NativeMetadata
from audit_generic_forwarders import runtime_range
from audit_ogpeg_constructors import Decoder,fields
from audit_forwarding import EXPECTED,sha
TARGETS={'JEDDJIOGLIG':(0x06001c28,'GetCurrentUserDateOfBirth',1,False),'FCCCIJBJPJI':(0x06001c29,'GetTimeSinceAppBootInMicroseconds',0,False),'LFLBODIJFPF':(0x06001c2a,'GetMemoryStats',1,True)}
def need(b,s):
 if not b:raise ValueError(s)
def data(v,p,n):at=v.raw(p,n);return bytes(v.b[at:at+n])
def text(v,p,n,wide):
 raw=data(v,p,(n+1)*(2 if wide else 1));need(raw[-(2 if wide else 1):]==(b'\0\0' if wide else b'\0'),'Exact literal terminator differs');return raw[:-(2 if wide else 1)].decode('utf-16le' if wide else 'ascii')
def decode(v,code,va,name):
 token,entry,arity,boolean=TARGETS[name];d=Decoder(code,va)
 if arity:d.literal('40 53 48 83 ec 50')
 else:d.literal('48 83 ec 58')
 cache=d.relative('48 8b 05')
 if arity:d.literal('48 8b d9')
 d.literal('48 85 c0');cached=d.short('75');module=d.relative('48 8d 05');d.literal('48 c7 44 24 28 0f 00 00 00 48 89 44 24 20 48 8d 4c 24 20');entryptr=d.relative('48 8d 05');d.literal('48 c7 44 24 38');d.literal(struct.pack('<I',len(entry)).hex());d.literal('48 89 44 24 30')
 if arity:d.literal('c7 44 24 40 00 00 00 00 c7 44 24 44 02 00 00 00 c7 44 24 48 08 00 00 00 c6 44 24 4c 00')
 else:d.literal('33 c0 89 44 24 40 88 44 24 4c 48 c7 44 24 44 02 00 00 00')
 resolver=d.relative('e8');written=d.relative('48 89 05');need(cache==written and resolver==0x1806c03f0 and cached==va+d.at,'Exact original cache/resolver/control-flow differs')
 if arity:d.literal('48 8b cb')
 d.literal('ff d0')
 if boolean:d.literal('85 c0 0f 95 c0')
 d.literal('48 83 c4 50 5b c3' if arity else '48 83 c4 58 c3');d.end();need(text(v,module,15,True)=='PS4NativePlugin' and text(v,entryptr,len(entry),False)==entry,'Original literal module/entry differs')
 return {'module':'PS4NativePlugin','module_literal_address':hex(module),'module_native_character_width':2,'module_length_without_terminator':15,'entry_point':entry,'entry_literal_address':hex(entryptr),'entry_length_without_terminator':len(entry),'calling_convention_enum':0,'calling_convention_name':'IL2CPP_CALL_DEFAULT','charset_enum':2,'charset_name':'CHARSET_NOT_SPECIFIED','parameter_size_bytes':8 if arity else 0,'is_no_mangle':False,'cache_address':hex(cache),'resolver_thunk':hex(resolver),'resolver_argument_base_rsp_offset':32,'stack_struct_offsets':{'module_pointer':0,'module_length':8,'entry_pointer':16,'entry_length':24,'calling_convention':32,'charset':36,'parameter_size':40,'is_no_mangle':44},'out_parameter_pointer_forwarded_unchanged':bool(arity),'return_conversion':'native32bit BOOL nonzero→managedBoolean' if boolean else 'Int64 RAX bits unchanged','no_managed_last_error_capture_or_other_call_after_native_call':True,'complete_function_decoded':True}
def payloads(v):
 rows=[]
 for name,expected in [('GGIBCLBPGML',[('BAMAIEFDAEJ','System.UInt16',16),('JOEPEOEMEDF','System.Byte',18),('CLDPOBMLBNK','System.Byte',19)]),('MFOKHKGBDHB',[('FNHLJAFIJCI','System.Int64',16),('ECPCNIMMOMJ','System.Int64',24),('JKLBAGILIFE','System.Int64',32),('KJOPFHPPICK','System.Int64',40)])]:
  owner='AKCLNNEPBEL/'+name;fs=fields(v,owner);need([(f['name'],f['type'],f['offset']) for f in fs]==expected and all(f['native_type']['attributes']==6 and not f['native_type']['byref'] and not f['native_type']['num_mods'] for f in fs),'Original out-struct field types/layout differ');matches=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)==owner and v.image_of_type(i)['name']=='Assembly-CSharp.dll'];need(len(matches)==1,'Unique original native out-struct scope required');info=v.type_info(matches[0]);need(info['parent_type']=='System.ValueType' and info['flags']&24==8,'Original sequential value layout differs');rows.append({'original_type':info,'fields':fs,'payload_bytes':4 if name=='GGIBCLBPGML' else 32,'no_reference_or_character_marshalling':True})
 return rows
def resolver(v):
 thunk=data(v,0x1806c03f0,5);need(thunk[0]==0xe9,'Original resolve JMP thunk differs');target=0x1806c03f5+struct.unpack_from('<i',thunk,1)[0];need(target==0x18068eb80,'Original resolver target differs');start,end,code=runtime_range(v,target);need(len(code)==504 and code[:34]==bytes.fromhex('48895c2408488974241048897c241855488bec4883ec60488bd9448b4124488d5110'),'Original resolver receives StringViews and charset field at0x24 differently');literals=[]
 for p,n,wide,expected in [(0x187f80918,17,False,'__InternalDynamic'),(0x187f80930,20,True,"Unable to load DLL '"),(0x187f809c0,37,True,"Unable to find an entry point named '")]:
  # Bound literal extraction; lengths below are checked from the actual source string.
  literal=text(v,p,len(expected),wide);need(literal==expected,'Original resolver-specific error/internal-library literal differs');literals.append({'address':hex(p),'value':literal,'width':2 if wide else 1})
 return {'thunk':hex(0x1806c03f0),'thunk_bytes':thunk.hex(),'native_target':hex(target),'runtime_function':{'start_rva':start,'end_rva':end,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest()},'specific_original_literals':literals,'source_structural_match':'matching Unity2020 PlatformInvoke::Resolve: module/entry/charset→hardcoded lookup, __InternalDynamic, library load and named-entry lookup with exact error literals'}
def main():
 out=ROOT/'Validation'/('OriginalPInvokeBindings-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();paths=[]
 for rel,digest in EXPECTED.items():p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Verified original native source SHA differs');paths.append(p)
 headers=WORKSPACE/'Tools/Editors/2020.3.33f1/Editor/Data/il2cpp';sources=[headers/'libil2cpp/il2cpp-pinvoke-support.h',headers/'libil2cpp/utils/StringView.h',headers/'libil2cpp/codegen/il2cpp-codegen-il2cpp.h',headers/'libil2cpp/codegen/il2cpp-codegen-il2cpp.cpp',headers/'libil2cpp/vm/PlatformInvoke.cpp',headers/'libil2cpp/os/Win32/LibraryLoader.cpp',headers/'external/mono/mono/metadata/tabledefs.h'];rows=[];tests=[]
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=NativeMetadata(b,md);layout=payloads(v);resolverProof=resolver(v)
  for name,(token,entry,arity,boolean) in TARGETS.items():
   method=v.find_method('AKCLNNEPBEL',token);need(method['name']==name and method['return']==('System.Boolean' if boolean else 'System.Int64') and len(method['parameters'])==arity and method['flags']==8337 and method['impl_flags']==128 and method['generic_container_index']<0,'Original extern method metadata differs');need(all(p['native_type']['byref'] and p['native_type']['attributes']==2 for p in method['parameters']),'Original out parameter flags differ');va=v.method_pointer(method);start,end,code=runtime_range(v,va);binding=decode(v,code,va,name);rows.append({'original':method,'registered_native_pointer':hex(va),'runtime_function':{'start_rva':start,'end_rva':end,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest()},'recovered_effective_native_import':binding})
   for i in range(len(code)):
    mutated=bytearray(code);mutated[i]^=1
    try:decode(v,bytes(mutated),va,name)
    except (ValueError,UnicodeError,struct.error):tests.append({'method':name,'changed_byte':i,'rejected':True})
    else:raise AssertionError('Mutated native wrapper accepted')
 report={'schema':'original-native-pinvoke-literal-abi-proof/v1','inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'matching_editor_primary_sources':[{'path':str(p),'sha256':sha(p)} for p in sources],'tool_sources':[{'path':str(p),'sha256':sha(p)} for p in [Path(__file__).resolve(),HERE.parent/'ConstructorEvidence/native_metadata.py',HERE.parent/'ConstructorEvidence/audit_generic_forwarders.py',HERE.parent/'ConstructorEvidence/audit_ogpeg_constructors.py']],'methods':rows,'out_structure_layouts':layout,'resolver_proof':resolverProof,'all_wrapper_opcode_mutations_rejected':tests,'exact_effective_native_resolver_inputs_recovered':True,'PreserveSig_proved_original_methodimpl_flags':128,'stripped_original_ImplMap_table_bytes_or_all_unobservable_attribute_bits_recovered':False,'unrecoverable_original_bits':['BestFitMapping/ThrowOnUnmappableChar metadata: no character/string managed parameters, so not represented in these native wrappers'],'SetLastError_behavior':'No post-native-call helper or memory side effect exists in any complete wrapper; no managed last-error capture is performed','no_new_platform_behavior_or_native_library_provided':True,'project_modified':False,'game_code_executed':False};(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'bindings':3,'all_byte_negative_tests':len(tests),'exact_original_ImplMap_bits_recovered':False}))
if __name__=='__main__':main()
