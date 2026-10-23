"""Fresh two-SHA derivative of a passed marshal stage; no live project edits."""
import argparse,copy,json,shutil,uuid
from datetime import datetime,timezone
from pathlib import Path
import prepare_marshalling_integration as p

def main():
    a=argparse.ArgumentParser();a.add_argument('--stage',required=True,type=Path);a.add_argument('--runtime-plan',required=True,type=Path);args=a.parse_args();old=args.stage.resolve(strict=True);runtime=p.read(args.runtime_plan);changes=runtime['changed_assemblies']
    p.need(len(changes)==2 and {x['assembly'] for x in changes}=={'Unity.Addressables','Unity.ResourceManager'},'Exact two-SDK runtime derivative required')
    new=p.ROOT/'CompilerRepairs'/('CurrentCoreMarshalTestedSDK-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);p.need(not new.exists(),'Fresh derivative required');new.mkdir();shutil.copytree(old/'Package',new/'Package');shutil.copytree(old/'OriginalGaps',new/'OriginalGaps');(new/'ToolBuild').mkdir()
    for name in ('CurrentCoreChecks.cs','compile-checker.rsp','compile-codegen.rsp','proposed-project-csc.rsp','current-core-manifest.bin','proven-marshalling-overlay.bin','overlay-binding-proof.json'):
        src=old/name;dst=new/name
        if name.endswith(('.cs','.rsp','.json')):dst.write_text(src.read_text().replace(str(old),str(new)))
        else:shutil.copyfile(src,dst)
    plan=p.rebase(p.read(old/'stage-plan.json'),old,new)
    for row in plan['tool_dependencies']:p.pinned(Path(row['path']),row['sha256']);shutil.copyfile(row['path'],new/'ToolBuild'/Path(row['path']).name)
    generated=new/'Package/Assets/Editor/OriginalMetadataRestoration/OriginalRuntimeMetadataReferenceInputs.cs';text=generated.read_text();before=text
    for change in changes:
        old_hash=change['before']['candidate_sha256'];new_hash=change['after']['candidate_sha256'];p.need(text.count(old_hash)==1,'Unique exact previous runtime SHA');text=text.replace(old_hash,new_hash)
    check=text
    for change in changes:check=check.replace(change['after']['candidate_sha256'],change['before']['candidate_sha256'])
    p.need(check==before,'Generated reference input may change only two exact SHAs');generated.write_text(text)
    plan['inputs'].append(p.pinned(args.runtime_plan));plan['tested_genuine_SDK_runtime_plan']=p.pinned(args.runtime_plan);plan['prior_passed_marshal_stage']=p.pinned(old/'stage-plan.json');plan['source_snapshots']=[{'source':str(x),'copy':str(x),'sha256':p.sha(x)} for x in sorted(generated.parent.glob('*.cs'))]
    # The copied proof contains only input identities; path rebasing changes its
    # own SHA, while every original native/SDK input and overlay binary is fixed.
    plan['marshalling_overlay']['binding_proof']=p.pinned(new/'overlay-binding-proof.json')
    plan['two_runtime_SHA_delta']=[{'assembly':x['assembly'],'before':x['before']['candidate_sha256'],'after':x['after']['candidate_sha256']} for x in changes]
    plan['patched_engine']['sha256']=p.sha(generated.parent/'WholeMetadataRestorer.cs')
    (new/'stage-plan.json').write_text(json.dumps(plan,indent=2)+'\n');print(json.dumps({'stage':str(new),'stage_plan_sha256':p.sha(new/'stage-plan.json'),'only_generated_runtime_input_changes':2,'project_changed':False}))
if __name__=='__main__':main()
