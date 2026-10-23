"""Join proven SDK descriptors and2explicit validated Win64 compatibility rows.

Data only. Does not mutate any assembly, source, project or CodeGen package.
"""
import copy,hashlib,json,sys
from pathlib import Path
HERE=Path(__file__).resolve().parent;ROOT=HERE.parents[2]/'Recovery/RecRoom-2023-04-18'
SDK=ROOT/'Validation/SteamworksMarshalOverlay-20261022T141534Z-0c4f149b/overlay.json'
SDK_SHA='a25e1e96a72c66057611405b1367d0cb0bf206fc59b6be4834dca33f65926526'
COMPAT=ROOT/'Validation/ActualUnityMarshalAudit-20261022T135400Z/Win32-compatibility-candidates.json'
JOIN=ROOT/'Validation/ActualUnityMarshalAudit-20261022T135400Z/native-contract-join.json'
ABI=ROOT/'Validation/MonoX64MarshalCompatibility-20261022T142400Z/x64-runtime-abi-proof.json'
ABI_SHA='23fdac1652c75c40adc3203d722d92b9f1b0e0692f11195ff4eb0299ebf2b43e'
def need(b,s):
 if not b:raise ValueError(s)
def sha(p):
 with p.open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def link(p):return {'path':str(p),'sha256':sha(p)}
def main():
 out=Path(sys.argv[1]);need(out.parent==ROOT/'Validation' and out.name.startswith('CombinedMarshalOverlay-') and not out.exists(),'Fresh exact validation output required');need(sha(SDK)==SDK_SHA and sha(ABI)==ABI_SHA,'Reviewed SDK/ABI evidence changed');sdk=json.loads(SDK.read_bytes());compat=json.loads(COMPAT.read_bytes());join=json.loads(JOIN.read_bytes());abi=json.loads(ABI.read_bytes());need(abi['status']=='passed' and not abi['actual_RR23_or_harness_modified'] and not abi['Windows_trust_device_game_or_vendor_API_invoked'],'Matching x64 nongame fixture proof required');need(join['parameter_count']==64 and join['field_count']==111 and not join['unresolved'],'Complete exact actual/native dangling owner joins required');need(sdk['counts']=={'fields':111,'parameters':62,'returns':318,'imports':819} and len(compat['records'])==2,'Exact reviewed descriptor inventory required');records=copy.deepcopy(sdk['records']);records['parameters']+=copy.deepcopy(compat['records'])
 pkeys={};fkeys={}
 for r in records['parameters']:
  key=(r['owner'],r['name'],r['sequence']);need(key not in pkeys,'Duplicate parameter overlay target');pkeys[key]=r
 for r in records['fields']:
  key=(r['owner'],r['name']);need(key not in fkeys,'Duplicate field overlay target');fkeys[key]=r
 coverage=[]
 for row in join['exact_parameter_joins']:
  a=row['actual'];m=a['method'];key=(m['owner']['display_owner'],m['name'],a['sequence']);need(key in pkeys,'Uncovered dangling parameter');r=pkeys[key];shape=row['actual_full_signature'];need(r['type']==shape['parameters'][a['sequence']-1] and r['parameter_types']==shape['parameters'] and r['return']==shape['return'] and r['original_flags']==a['flags'] and int(r['native_method_token'],16)==int(row['original_method_token'],16),'Parameter overlay identity/signature/nativeflags mismatch');coverage.append({'kind':'parameter','original_owner':key[0],'original_name':key[1],'sequence':key[2],'actual_current_token':a['current_parameter_token'],'original_native_token':row['original_parameter_token'],'flags_unchanged':True,'authority':r['authority']})
 for row in join['exact_field_joins']:
  a=row['actual'];key=(a['owner']['display_owner'],a['name']);need(key in fkeys,'Uncovered dangling field');r=fkeys[key];need(r['type']==row['actual_field_type'] and r['original_flags']==a['flags'] and int(r['native_field_token'],16)==int(row['original_native']['field_native_token'],16),'Field overlay exact type/nativeflag/token mismatch');coverage.append({'kind':'field','original_owner':key[0],'original_name':key[1],'actual_current_token':a['current_field_token'],'original_native_token':row['original_native']['field_native_token'],'flags_unchanged':True,'authority':r['authority']})
 need(len(coverage)==175 and len(pkeys)==64 and len(fkeys)==111,'Every dangling marshal flag must have exactly one descriptor');out.mkdir();overlay={'schema':'combined-original-source-and-explicit-Windowsx64-compatibility-marshal-overlay/v1','status':'validated_data_only_not_applied','target_assembly':'Assembly-CSharp','apply_phase':'After original declaration identities and flags restored; before final write/fingerprint/reference walk','inputs':[link(p) for p in (SDK,COMPAT,JOIN,ABI)],'records':records,'counts':{'fields':111,'parameters':64,'returns':318,'imports':819,'actual_dangling_rows_covered':175,'genuine_matching_SDK_dangling_descriptors':173,'explicit_Windowsx64_compatibility_dangling_descriptors':2},'actual_dangling_coverage':coverage,'compatibility_scope':'The2KNBDGFKMGCP scalar/GUID rows are nonshipping Windows-x64 ABI compatibility, NOT recovered original descriptor bytes. Original flags and full signatures remain unchanged. Otherplatformvalidation unestablished; no platform/source/API changed by this data artifact.','additional_returns_policy':'318 return descriptors/HasFieldMarshal ownership come from exact matching genuine SDKsource; raw IL2CPP Param0 flags did not retain these. Treat as separately proven source recovery, not rawmetadata equality.','import_policy':'819 full ImplMap records come from exact matching SDK source and original native effective-binding joins. Remaining27 bindings remain separate evidence, never fabricate full original ImplMapbits.','custom_marshaler_scope_policy':'If a descriptor refers to a managed marshaller type, bind by exact actual original type identity in target module, not the witness SDK assembly scope. No new helper type synthesized.','unresolved':copy.deepcopy(sdk['unresolved']),'actual_RR23_or_harness_modified':False,'assembly_or_source_rewritten':False,'Windows_trust_device_game_or_vendor_API_invoked':False,'field_or_parameter_flag_clears':0,'native_original_descriptor_blob_equality_claim':False};target=out/'overlay.json';target.write_text(json.dumps(overlay,indent=2)+'\n');receipt={'overlay':link(target),'covered_dangling_rows':175,'source_descriptor_rows':173,'validated_compatibility_rows':2,'project_modified':False,'assembly_written':False};(out/'receipt.json').write_text(json.dumps(receipt,indent=2)+'\n');print(json.dumps(receipt))
if __name__=='__main__':main()
