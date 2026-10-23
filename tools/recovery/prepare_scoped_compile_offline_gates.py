"""Pin final source/SDK/marshal/native-scope evidence; never invent Unity pass."""
import argparse,json
from pathlib import Path
import prepare_marshalling_integration as p
def main():
 a=argparse.ArgumentParser();a.add_argument('--readiness',required=True,type=Path);a.add_argument('--scope-proof',required=True,type=Path);a.add_argument('--actual-comparison',type=Path);args=a.parse_args();ready=p.read(args.readiness);p.need(ready['status']=='offline_passed_requires_actual_Unity_compile_load','Whole offline readiness required');folder=args.readiness.parent
 old=p.ROOT/'Validation/CurrentCoreMarshalRoundtrip-20261022T150805Z-97bb598a/offline-gates-pending-actual-comparison.json';gates=p.read(old)
 for i,file in enumerate((args.readiness,folder/'report.json',folder/'direct-cli-overlay-proof.json')):gates[i].update(p.pinned(file))
 def gate(file,checks):
  doc=p.read(file);items=[]
  for selector,value in checks:
   current=doc
   for key in selector:current=current[key]
   p.need(current==value,'Explicit acceptance selector failed: '+str(selector));items.append({'selector':selector,'equals':value})
  gates.append({**p.pinned(file),'checks':items})
 gate(args.scope_proof,[(['status'],'passed_scope_only'),(['validated_native_scope_rows'],22),(['all_other_TypeRef_rows_and_full_scopes_preserved'],True),(['preexisting_AssemblyRefs_preserved'],True),(['fallback_or_framework_identity_aliases_used'],False)])
 gate(p.ROOT/'Validation/NativeFrameworkAssemblyScopes-20261022T154947Z-0d359b85/report.json',[(['status'],'all22_exact_native_scopes_proven'),(['native_core_references_both_framework_images'],True)])
 gate(p.ROOT/'Validation/FiniteAOTResolverFixtures-20261022T160306Z-9b9a8e06/report.json',[(['status'],'passed'),(['checks'],12)])
 gate(p.ROOT/'Validation/CliMarkerVoidFixtures-20261022T162142Z-a3778891/report.json',[(['status'],'passed'),(['checks'],15),(['named_scope_PKT_negative_retained'],True)])
 gate(p.ROOT/'Validation/CliMarkerVoidEncoding-20261022T162146Z-0682eeeb/report.json',[(['status'],'passed'),(['return_primitive_type_has_no_scoped_TypeRef_token'],True)])
 gate(p.ROOT/'Validation/ScopedMarshallingComparerBuild-20261022T160308Z-4ded9f37/report.json',[(['status'],'passed'),(['project_modified'],False)])
 gate(p.ROOT/'RuntimeSDKRecovery/SDKTextureFixture-20261022T141730Z-4fc6c539/run-report.json',[(['status'],'passed'),(['exit_code'],0)])
 # Original seven gates already include unchanged seven native body spans,
 # all2291 source rows, whole metadata/PDB checks and exact SDK marshal blobs.
 if args.actual_comparison:
  gate(args.actual_comparison,[(['status'],'passed'),(['game_code_loaded_or_executed'],False),(['project_modified'],False)])
 name='offline-gates-with-actual-scoped-comparison.json' if args.actual_comparison else 'offline-gates-pending-actual-scoped-comparison.json';out=folder/name;p.need(not out.exists(),'Fresh gate report required');out.write_text(json.dumps(gates,indent=2)+'\n');print(json.dumps({'gates':str(out),'sha256':p.sha(out),'reports':len(gates),'actual_Unity_comparison_included':bool(args.actual_comparison)}))
if __name__=='__main__':main()
