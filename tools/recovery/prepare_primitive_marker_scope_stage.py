"""Exact three-family noarg marker VOID import correction; full scopes stay strict."""
import json,shutil,uuid
from datetime import datetime,timezone
from pathlib import Path
import prepare_marshalling_integration as p
BASE=p.ROOT/'CompilerRepairs/CurrentCoreScopeAttributeDiagnostics-20261022T161252Z-3d7f1dc6'
out=p.ROOT/'CompilerRepairs'/('CurrentCoreNativeScopeMarkerVoid-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();shutil.copytree(BASE/'Package',out/'Package');shutil.copytree(BASE/'OriginalGaps',out/'OriginalGaps');(out/'ToolBuild').mkdir()
for name in ('CurrentCoreChecks.cs','compile-checker.rsp','compile-codegen.rsp','proposed-project-csc.rsp','current-core-manifest.bin','proven-marshalling-overlay.bin','overlay-binding-proof.json'):
 src=BASE/name;dst=out/name
 if name.endswith(('.cs','.rsp','.json')):dst.write_text(src.read_text().replace(str(BASE),str(out)))
 else:shutil.copyfile(src,dst)
plan=p.rebase(p.read(BASE/'stage-plan.json'),BASE,out)
for row in plan['tool_dependencies']:p.pinned(Path(row['path']),row['sha256']);shutil.copyfile(row['path'],out/'ToolBuild'/Path(row['path']).name)
folder=out/'Package/Assets/Editor/OriginalMetadataRestoration';shutil.copyfile(p.HERE/'ExactCliMarkerConstructor.cs',folder/'ExactCliMarkerConstructor.cs');(folder/'ExactCliMarkerConstructor.cs.meta').write_text('fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\n')
for name in ('MetadataDefinitionRestoration.cs','ReadonlyAttributeRestoration.cs'):
 file=folder/name;text=file.read_text();prior=text;text=text.replace('compiled.ImportReference(attribute.Constructor)','ExactCliMarkerConstructor.Import(compiled, attribute.Constructor)').replace('compiled.ImportReference(originalAttribute.Constructor)','ExactCliMarkerConstructor.Import(compiled, originalAttribute.Constructor)');p.need(text!=prior,'Exact marker import site required');file.write_text(text)
for name in ('compile-checker.rsp','compile-codegen.rsp'):
 file=out/name;file.write_text(file.read_text()+'"'+str(folder/'ExactCliMarkerConstructor.cs')+'"\n')
plan['CLI_marker_constructor_primitive_VOID']={'no_argument_markers':['UnityEngine.SerializeField','UnityEngine.SerializeReference','System.Runtime.CompilerServices.IsReadOnlyAttribute'],'one_primitive_STRING_argument_only':'UnityEngine.Serialization.FormerlySerializedAsAttribute','encoded_primitive_types':'ELEMENT_TYPE_VOID 0x01 and STRING 0x0e have no scoped TypeRef token','target_primitive_corelib_TypeSystem':True,'named_class_enum_interface_generic_scope_normalization':False,'full_scoped_fingerprints_remain_strict':True,'method_body_edits':0};plan['source_snapshots']=[{'source':str(x),'copy':str(x),'sha256':p.sha(x)} for x in sorted(folder.glob('*.cs'))];plan['patched_engine']['sha256']=p.sha(folder/'WholeMetadataRestorer.cs');plan['marshalling_overlay']['binding_proof']=p.pinned(out/'overlay-binding-proof.json');plan['inputs'].append(p.pinned(BASE/'stage-plan.json'));(out/'stage-plan.json').write_text(json.dumps(plan,indent=2)+'\n');print(json.dumps({'stage':str(out),'sha256':p.sha(out/'stage-plan.json'),'acceptance_unchanged':True}))
