"""Derive a225-runtime proposal replacing only the two tested genuine SDKs.

No DLLs, metadata importers, hash maps or live Unity projects are overwritten.
The returned plan is for a subsequent isolated integration validation only.
"""
import argparse,copy,json,uuid
from datetime import datetime,timezone
from pathlib import Path
import prepare_marshalling_integration as p

BASE=p.ROOT/'NativeGameplayRepairs/RuntimePluginMonoCompatibility-20261022T100750Z/report.json'
PROPOSAL=p.ROOT/'RuntimeSDKRecovery/GenuineAddressablesProposal-20261022T140804Z-40686d7c/report.json'
RUN=p.ROOT/'RuntimeSDKRecovery/SDKTextureFixture-20261022T141730Z-4fc6c539/run-report.json'
DEPLOY=p.ROOT/'NativeGameplayRepairs/RuntimePluginDeployment-20261022T103518Z-1b33f079/manifest.json'

def main():
    parser=argparse.ArgumentParser();parser.add_argument('--output',type=Path);args=parser.parse_args()
    output=args.output or p.ROOT/'NativeGameplayRepairs'/('RuntimePluginTestedSDKProposal-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8])
    p.need(not output.exists() and output.is_relative_to(p.ROOT/'NativeGameplayRepairs'),'Fresh isolated runtime proposal required')
    base=p.read(BASE);sdk=p.read(PROPOSAL);run=p.read(RUN)
    p.need(sdk['status']=='native-contracts-and-reference-closure-passed-not-installed' and sdk['genuine_managed_method_bodies']==1342,'Exact two genuine SDK proposal required')
    # Runtime receipt schema is kept as evidence. The explicit marker proves the
    # original texture path/dimensions, not general game playability.
    p.need(run.get('status') in ('passed','completed','verified') or run.get('exit_code')==0,'Passed reviewed SDK-only Unity run required')
    rows=copy.deepcopy(base['assemblies']);p.need(len(rows)==225 and len({r['assembly'] for r in rows})==225,'Exact225 unique runtime identities')
    changes=[]
    for candidate in sdk['files']:
        assembly=candidate['assembly'];p.need(assembly in {'Unity.Addressables','Unity.ResourceManager'},'Only exact tested SDKs')
        matches=[r for r in rows if r['assembly']==assembly];p.need(len(matches)==1,'Unique original SDK slot');row=matches[0]
        p.pinned(Path(candidate['candidate']),candidate['sha256']);p.pinned(Path(candidate['proposed_meta_copy']),candidate['original_meta_sha256']);p.pinned(Path(candidate['original_project_meta']),candidate['original_meta_sha256'])
        p.need(candidate['meta_bytes_GUID_and_all_platform_filters_unchanged'] and row['meta_sha256']==candidate['original_meta_sha256'],'GUID and platform importer bytes unchanged')
        before=copy.deepcopy(row);row.update(source=row['candidate'],source_sha256=row['candidate_sha256'],candidate=candidate['candidate'],candidate_sha256=candidate['sha256'],action='genuine-official-1.20.5-source-runtime-replacement-proposed',body_authority='official package source; exact native API/layout/flags proof; SDK-only texture-load tested')
        changes.append({'assembly':assembly,'before':before,'after':copy.deepcopy(row)})
    p.need(len(changes)==2,'Exact two-row runtime delta')
    result=copy.deepcopy(base);result.update(schema='isolated225-runtime-plan-with-tested-genuine-SDKs/v1',status='proposal_requires_fresh_core_reference_closure_and_Unity_signature_gate',assemblies=rows,source_runtime_plan=p.pinned(BASE),tested_SDK_proposal=p.pinned(PROPOSAL),SDK_only_Unity_runtime_receipt=p.pinned(RUN),changed_assemblies=changes,genuine_official_SDK_method_bodies=1342,runtime_apply_performed=False,project_changed=False,all_original_platform_sources_preserved=True,other_platform_runtime_validation_pending=True,actual_compiled_core_and_Unity_pipeline_verified=False,game_playability_verified=False)
    output.mkdir();path=output/'report.json';path.write_text(json.dumps(result,indent=2)+'\n')
    deployment=copy.deepcopy(p.read(DEPLOY));deployment.update(schema='isolated225-test-only-plugin-input-with-genuine-SDKs/v1',status='proposal_requires_full_core_and_actual_Unity_signature_gate',source_deployment_plan=p.pinned(DEPLOY),source_runtime_plan=p.pinned(path),runtime_apply_performed=False,project_changed=False)
    mapped={r['assembly']:r for r in rows};changes=0
    for row in deployment['assemblies']:
        key=Path(row['target']).stem;candidate=mapped[key]
        if row['candidate_sha256']!=candidate['candidate_sha256']:
            p.need(key in {'Unity.Addressables','Unity.ResourceManager'} and row['meta_sha256']==candidate['meta_sha256'],'Only two tested SDK candidates may change')
            row.update(candidate=candidate['candidate'],candidate_sha256=candidate['candidate_sha256']);changes+=1
    p.need(changes==2 and len(deployment['assemblies'])==225,'Exact two-row full deployment input delta')
    dp=output/'deployment-input.json';dp.write_text(json.dumps(deployment,indent=2)+'\n');print(json.dumps({'runtime_plan':str(path),'sha256':p.sha(path),'deployment_input':str(dp),'changed_assemblies':2,'project_changed':False}))
if __name__=='__main__':main()
