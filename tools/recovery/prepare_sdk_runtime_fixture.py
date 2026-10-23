"""Prepare, but never launch, the source-reviewed isolated SDK runtime fixture."""
from pathlib import Path
from datetime import datetime, timezone
import argparse
import hashlib
import json
import shutil
import uuid

HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'


def sha(path):
    with path.open('rb') as stream:return hashlib.file_digest(stream,'sha256').hexdigest()


def main():
    p=argparse.ArgumentParser();p.add_argument('--proposal',type=Path,required=True);p.add_argument('--texture-plan',type=Path,required=True);a=p.parse_args()
    proposal=json.loads(a.proposal.read_text());texture=json.loads(a.texture_plan.read_text())
    if proposal['status']!='native-contracts-and-reference-closure-passed-not-installed' or texture['all_class_ids']!=[28,142] or not texture['no_cross_bundle_dependencies'] or not texture['no_native_resource_externals']:raise ValueError('Closed genuine SDK and original script-free texture input required')
    for row in texture['inputs']:
        if sha(Path(row['path']))!=row['sha256']:raise ValueError('Texture provenance changed')
    for row in proposal['files']:
        if sha(Path(row['candidate']))!=row['sha256'] or sha(Path(row['proposed_meta_copy']))!=row['original_meta_sha256']:raise ValueError('Proposal bytes/meta changed')
    output=ROOT/'RuntimeSDKRecovery'/('SDKTextureFixture-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);project=output/'Project'
    for directory in ('Assets/Editor','Assets/Plugins','Packages','ProjectSettings','FixtureInputs'):(project/directory).mkdir(parents=True,exist_ok=True)
    files=[]
    def copy(source,relative):
        target=project/relative;shutil.copyfile(source,target);files.append({'path':relative,'sha256':sha(target),'source':str(source),'source_sha256':sha(source)})
    for row in proposal['files']:
        copy(Path(row['candidate']),'Assets/Plugins/'+row['assembly']+'.dll')
        copy(Path(row['proposed_meta_copy']),'Assets/Plugins/'+row['assembly']+'.dll.meta')
    copy(HERE/'SDKTextureLoadFixture.cs','Assets/Editor/SDKTextureLoadFixture.cs')
    copy(WORKSPACE/'RR23/Packages/manifest.json','Packages/manifest.json')
    copy(WORKSPACE/'RR23/ProjectSettings/ProjectVersion.txt','ProjectSettings/ProjectVersion.txt')
    source=Path(texture['source_bundle'])
    if sha(source)!=texture['source_bundle_sha256']:raise ValueError('Original bundle changed')
    copy(source,'FixtureInputs/OriginalTexture.bundle')
    tex=texture['selection']['texture'];entry=texture['selection']['container']['entries'][0]
    sdk={r['assembly']:r for r in proposal['files']}
    spec={'bundle_path':'FixtureInputs/OriginalTexture.bundle','bundle_sha256':sha(source),'internal_asset_path':entry['key'],
          'asset_bundle_name':texture['selection']['container']['asset_bundle_name'],'expected_name':tex['name'],'expected_width':tex['width'],'expected_height':tex['height'],
          'addressables_sha256':sdk['Unity.Addressables']['sha256'],'resource_manager_sha256':sdk['Unity.ResourceManager']['sha256']}
    spec_path=project/'FixtureInputs/spec.json';spec_path.write_text(json.dumps(spec,indent=2)+'\n');files.append({'path':'FixtureInputs/spec.json','sha256':sha(spec_path),'generated_trusted_input':True})
    report={'schema':'genuine-sdk-texture-runtime-fixture-preparation/v1','status':'prepared-not-launched','project':str(project),
            'execute_method':'SDKTextureLoadFixture.Run','inputs':[{'path':str(p.resolve()),'sha256':sha(p)} for p in (a.proposal,a.texture_plan,HERE/'SDKTextureLoadFixture.cs',Path(__file__).resolve())],
            'files':files,'source_class_ids':[28,142],'bundle_dependency_closure_files':1,'source_original_game_assemblies':0,'source_scenes_or_prefabs':0,'SDK_DLLs':2,
            'genuine_SDK_methods_authorized_for_test':True,'original_client_or_game_methods_authorized':False,'PlayMode':False,'original_RR23_changed':False,
            'runtime_test_executed':False,'required_guard':{'owned_aggregate_job_bytes':2*1024**3,'minimum_global_commit_reserve_bytes':int(1.5*1024**3),'maximum_seconds':180},
            'success_requires':['exact original bundle SHA and 28/142-only class inventory','exact genuine SDK DLL hashes','both genuine Addressables.ResourceManager and AssetBundleProvider/BundledAssetProvider invoked','Texture2D exact original name/width/height match','genuine SDK handle released and manager disposed','Editor exit0 +fresh passed result +success log marker']}
    (output/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'preparation':str(output/'report.json'),'project':str(project),'source_texture':tex['name']}))


if __name__=='__main__':main()
