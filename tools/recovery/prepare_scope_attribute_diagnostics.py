"""Align component diagnostics with the exact full-scope aggregate, no gate change."""
import json,shutil,uuid
from datetime import datetime,timezone
from pathlib import Path
import prepare_marshalling_integration as p
BASE=p.ROOT/'CompilerRepairs/CurrentCoreExactAOTScopes-20261022T160146Z-e2673b24'
out=p.ROOT/'CompilerRepairs'/('CurrentCoreScopeAttributeDiagnostics-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();shutil.copytree(BASE/'Package',out/'Package');shutil.copytree(BASE/'OriginalGaps',out/'OriginalGaps');(out/'ToolBuild').mkdir()
for name in ('CurrentCoreChecks.cs','compile-checker.rsp','compile-codegen.rsp','proposed-project-csc.rsp','current-core-manifest.bin','proven-marshalling-overlay.bin','overlay-binding-proof.json'):
 src=BASE/name;dst=out/name
 if name.endswith(('.cs','.rsp','.json')):dst.write_text(src.read_text().replace(str(BASE),str(out)))
 else:shutil.copyfile(src,dst)
plan=p.rebase(p.read(BASE/'stage-plan.json'),BASE,out)
for row in plan['tool_dependencies']:p.pinned(Path(row['path']),row['sha256']);shutil.copyfile(row['path'],out/'ToolBuild'/Path(row['path']).name)
folder=out/'Package/Assets/Editor/OriginalMetadataRestoration';file=folder/'MetadataRoundTripDiagnostics.cs';text=file.read_text();text=p.replace_once(text,'attribute.Constructor.FullName','ScopedMetadataSignatures.Type(attribute.Constructor.DeclaringType)+ScopedMetadataSignatures.Method(attribute.Constructor)');file.write_text(text)
plan['scope_component_diagnostic_alignment_only']=True;plan['source_snapshots']=[{'source':str(x),'copy':str(x),'sha256':p.sha(x)} for x in sorted(folder.glob('*.cs'))];plan['patched_engine']['sha256']=p.sha(folder/'WholeMetadataRestorer.cs');plan['marshalling_overlay']['binding_proof']=p.pinned(out/'overlay-binding-proof.json');plan['inputs'].append(p.pinned(BASE/'stage-plan.json'));(out/'stage-plan.json').write_text(json.dumps(plan,indent=2)+'\n');print(json.dumps({'stage':str(out),'sha256':p.sha(out/'stage-plan.json'),'acceptance_unchanged':True}))
