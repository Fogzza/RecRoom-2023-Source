"""Fresh native-pinned22 external TypeRef identity derivative; no live edits."""
import json,shutil,uuid
from datetime import datetime,timezone
from pathlib import Path
import prepare_marshalling_integration as p

BASE=p.ROOT/'CompilerRepairs/CurrentCoreMarshalTestedSDK-20261022T151730Z-97890da6'
AUDIT=p.ROOT/'Validation/CoreTypeRefAssemblyScopes-20261022T154753Z-eab50e94/report.json'
NATIVE=p.ROOT/'Validation/NativeFrameworkAssemblyScopes-20261022T154947Z-0d359b85/report.json'
def main():
 p.pinned(AUDIT,'a5e6a61bbae1471141919ed23697b6f9e7a3cb82be7a5dacfc7d4973fc47184c');p.pinned(NATIVE,'8b3b7e9c03fc158d04ecbac21f280be433fed4deab9f7745efe1a55d88d3fac8')
 a=p.read(AUDIT);n=p.read(NATIVE);rows=a['scope_mismatches'];p.need(len(rows)==22 and a['counts']['ambiguous_original_scopes']==0 and n['status']=='all22_exact_native_scopes_proven','Native22 finite scope proof required')
 for i in n['inputs']:p.pinned(Path(i['path']),i['sha256'])
 proof={r['current_TypeRef']['name']:r for r in n['rows']};p.need(len(proof)==22,'Exact native22 witness bijection')
 for r in rows:
  q=proof[r['actual']['name']];p.need(q['current_TypeRef']==r['actual'] and q['native_assembly']['full_name']==r['original_scope'] and q['native_type']['name']==r['actual']['name'],'Native scoped TypeRef witness mismatch')
 out=p.ROOT/'CompilerRepairs'/('CurrentCoreNativeFrameworkScopes-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();shutil.copytree(BASE/'Package',out/'Package');shutil.copytree(BASE/'OriginalGaps',out/'OriginalGaps');(out/'ToolBuild').mkdir()
 for name in ('CurrentCoreChecks.cs','compile-checker.rsp','compile-codegen.rsp','proposed-project-csc.rsp','current-core-manifest.bin','proven-marshalling-overlay.bin','overlay-binding-proof.json'):
  src=BASE/name;dst=out/name
  if name.endswith(('.cs','.rsp','.json')):dst.write_text(src.read_text().replace(str(BASE),str(out)))
  else:shutil.copyfile(src,dst)
 plan=p.rebase(p.read(BASE/'stage-plan.json'),BASE,out)
 for row in plan['tool_dependencies']:p.pinned(Path(row['path']),row['sha256']);shutil.copyfile(row['path'],out/'ToolBuild'/Path(row['path']).name)
 folder=out/'Package/Assets/Editor/OriginalMetadataRestoration';shutil.copyfile(p.HERE/'ExactOriginalFrameworkScopes.cs',folder/'ExactOriginalFrameworkScopes.cs')
 canonical=(folder/'CanonicalMetadataSignatures.cs').read_text().replace('public static class CanonicalMetadataSignatures','public static class ScopedMetadataSignatures').replace('return assembly.Name;','return assembly.FullName;').replace('return module.Assembly.Name.Name;','return module.Assembly.Name.FullName;')
 (folder/'ScopedMetadataSignatures.cs').write_text(canonical)
 generated='namespace RR23.MetadataRestoration { public static class OriginalFrameworkScopeInputs { public static readonly OriginalFrameworkScopeRow[] Rows = new OriginalFrameworkScopeRow[] {\n'
 for row in rows:generated+='new OriginalFrameworkScopeRow('+','.join(json.dumps(v) for v in (row['actual']['name'],row['actual']['assembly_full_name'],row['original_scope']))+'),\n'
 generated+='}; } }\n';(folder/'OriginalFrameworkScopeInputs.cs').write_text(generated)
 added=('ExactOriginalFrameworkScopes.cs','ScopedMetadataSignatures.cs','OriginalFrameworkScopeInputs.cs')
 for name in added:(folder/(name+'.meta')).write_text('fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\n')
 for name in ('compile-checker.rsp','compile-codegen.rsp'):
  file=out/name;file.write_text(file.read_text()+''.join('"'+str(folder/x)+'"\n' for x in added))
 file=folder/'WholeMetadataRestorer.cs';text=file.read_text();text=p.replace_once(text,'public ProvenMarshallingOverlayResult MarshallingOverlay;','public ProvenMarshallingOverlayResult MarshallingOverlay;\n        public int NativeFrameworkTypeRefScopes;');text=p.replace_once(text,'var marshallingOverlay = ProvenMarshallingOverlay.Apply','var frameworkScopes = ExactOriginalFrameworkScopes.Apply(assembly.MainModule, raw.MainModule, OriginalFrameworkScopeInputs.Rows);\n                var marshallingOverlay = ProvenMarshallingOverlay.Apply');text=p.replace_once(text,'MarshallingOverlay = marshallingOverlay };','MarshallingOverlay = marshallingOverlay, NativeFrameworkTypeRefScopes = frameworkScopes };');file.write_text(text)
 for name in ('BodyAndSymbolSafety.cs','MetadataRoundTripSafety.cs','MetadataRoundTripDiagnostics.cs'):
  file=folder/name;text=file.read_text().replace('CanonicalMetadataSignatures.Type(','ScopedMetadataSignatures.Type(').replace('CanonicalMetadataSignatures.Method(','ScopedMetadataSignatures.Method(')
  if name=='MetadataRoundTripSafety.cs':text=p.replace_once(text,'attribute.Constructor.FullName','ScopedMetadataSignatures.Type(attribute.Constructor.DeclaringType)+ScopedMetadataSignatures.Method(attribute.Constructor)')
  file.write_text(text)
 plan['native_framework_scope_restoration']={'schema':'exact-native22-TypeRef-scope-restoration/v1','type_reference_count':22,'assembly_identities':2,'native_proof':p.pinned(NATIVE),'whole_scope_audit':p.pinned(AUDIT),'only_finite_proven_type_names':True,'global_assembly_aliasing':False,'method_body_edits':0,'manifest_selector_dialect_unchanged':True,'metadata_and_body_roundtrip_full_assembly_identities':True}
 plan['inputs'].extend([p.pinned(AUDIT),p.pinned(NATIVE),p.pinned(BASE/'stage-plan.json')]);plan['marshalling_overlay']['binding_proof']=p.pinned(out/'overlay-binding-proof.json');plan['source_snapshots']=[{'source':str(x),'copy':str(x),'sha256':p.sha(x)} for x in sorted(folder.glob('*.cs'))];plan['patched_engine']['sha256']=p.sha(folder/'WholeMetadataRestorer.cs');(out/'stage-plan.json').write_text(json.dumps(plan,indent=2)+'\n')
 print(json.dumps({'stage':str(out),'stage_sha256':p.sha(out/'stage-plan.json'),'type_scopes':22,'project_modified':False}))
if __name__=='__main__':main()
