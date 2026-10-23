"""Prepare or Root-stage four tested key/child bodies into current SDK metadata.

Default only prepares/verifies. Only Root --run launches the bounded metadata
importer; no Main apply path exists. Every original metadata feature and every
unselected method body must compare equal before and after candidate emission.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,re,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
TEST=ROOT/'Validation/ContainerKeyChildBindingEffects-20261023T091429Z-abca668d/run-report.json'
TEST_SHA='011369db384b3a39b2dd1f7a3389bfbae384e6a38422534eb7024cffbf4f86c6'
APPLY=ROOT/'Validation/ContainerLowerExactApply-20261023T085850Z-84bc64a8/apply-receipt.json'
APPLY_SHA='3efc854c41bf95e61e461197495ebe8316caa6a60e05cd1a39f705778b9920eb'
SUPPORT=HERE.parent/'RuntimeMetadataAudit/COMCompatibility-20261022T100736Z';PREVIOUS=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-four-tested-container-key-child-body-only-import/v1'
def need(value,message):
    if not value:raise ValueError(message)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned key/child staging input changed: '+row['path'])
def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')
def tested():
    need(pin(TEST)['sha256']==TEST_SHA,'Exact actual four-binding32-effect receipt');r=json.loads(TEST.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['status']=='four_original_key_child_bindings_and_thirty_two_controlled_cases_passed' and r['selected_members']==4 and r['controlled_cases']==32 and not r['production_SDK_or_donor_executed'] and not r['Main_modified'],'Exact passed original-owner and controlled-effect scope')
    need([x['phase'] for x in r['phases']]==['compile-four-key-child-original-owner-donor','compile-explicit-key-child-effects-reader','inspect-four-original-key-child-bindings','thirty-two-key-child-controlled-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'All four actual bounded successful phases')
    for key in ['runner','proof','candidate_members','reviewable_donor_source','template','original_plugin','original_meta','compiler','mono']:check(p[key])
    for row in p['sources']+p['references']+[r['compiled_donor']]:check(row)
    need(p['sources'][0]['sha256']==p['reviewable_donor_source']['sha256'] and Path(r['compiled_donor']['path']).name=='UJect.Runtime.dll','Readable exact donor source compiled and inspected with original owner scope')
    need(pin(APPLY)['sha256']==APPLY_SHA,'Exact Root prior eight-body apply checkpoint');applied=json.loads(APPLY.read_bytes());need(applied['status']=='eight_native_container_bodies_applied_two_SDKs_one_proven_reference_append_metas_preserved' and applied['metas_unchanged'] and applied['changed_method_bodies']==8,'Current lower eight member checkpoint remains applied')
    baseline=[x for x in applied['applied'] if Path(x['source']['path']).name=='UJect.Runtime.dll'];need(len(baseline)==1,'One original current UJect module');baseline=baseline[0];check(baseline['source']);check(baseline['meta']);need(baseline['source']==p['original_plugin'] and baseline['meta']==p['original_meta'],'Current applied8 SDK is the exact original-owner binding baseline')
    return r,p,baseline
def prepare():
    r,p,baseline=tested();out=ROOT/'Validation'/('ContainerKeyChildBodyStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    modules=[{'original':baseline['source'],'meta':baseline['meta'],'donor':r['compiled_donor'],'members':[{'owner':'MNALHHOLFGL','name':'MJHONDPGJFA'},{'owner':'CPAMAFPANDM','name':'OFPEIHMPLIL'},{'owner':'CPAMAFPANDM','name':'Equals'},{'owner':'CPAMAFPANDM','name':'GetHashCode'}]}]
    spec=out/'inputs.json';save(spec,{'schema':'four-tested-container-key-child-body-only-import-input/v1','modules':modules})
    sources=[HERE/'StageContainerKeyChildBodies.cs']+[SUPPORT/name for name in ['CanonicalMetadataSignatures.cs','MetadataRoundTripSafety.cs','BodyAndSymbolSafety.cs']];old=(PREVIOUS/'compile.rsp').read_text(encoding='utf-8-sig');refs=[Path(x) for x in re.findall(r'(?m)^/reference:"([^"]+)"$',old) if '/packs/Microsoft.NETCore.App.Ref/' in x.replace('\\','/')];need(len(refs)>=100,'Exact previously used framework reference pack')
    cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';refs.append(cecil);shutil.copyfile(cecil,out/cecil.name);output=out/'StageContainerKeyChildBodies.dll';response=out/'compile.rsp';response.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+''.join('"'+str(x)+'"\n' for x in sources),encoding='utf-8',newline='\n');shutil.copyfile(PREVIOUS/'OriginalShaderObjectProbe.runtimeconfig.json',output.with_suffix('.runtimeconfig.json'))
    plan={'schema':SCHEMA,'status':'prepared_no_child_or_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'test_receipt':pin(TEST),'test_plan':r['plan'],'baseline_Root_apply':pin(APPLY),'spec':pin(spec),'sources':[pin(x) for x in sources],'reviewable_donor_sources':[p['reviewable_donor_source'],p['candidate_members']],'response':pin(response),'references':[pin(x) for x in refs],'runtime':[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],'modules':modules,'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':pin(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),'output':str(output),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'Main_modified':False,'Main_apply_supported':False,'changed_bodies':4,'all_original_metadata_and_unselected_bodies_must_be_equal':True,'new_AssemblyRefs_permitted':False,'registration_or_provider_functionality_claimed':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed bounded owned suspended guard');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed body stage plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerKeyChildBodyStage-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['changed_bodies']==4 and not p['Main_apply_supported'] and not p['new_AssemblyRefs_permitted'],'Exact isolated four-body scope with no metadata additions')
    for row in [p[k] for k in ['runner','test_receipt','test_plan','baseline_Root_apply','spec','response','guard','launcher','dotnet','compiler']]+p['sources']+p['reviewable_donor_sources']+p['references']+p['runtime']:check(row)
    for row in p['modules']:
        for key in ['original','donor','meta']:check(row[key])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact current reviewed stage helper/guards');tested()
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_apply','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh one-shot outputs only; failures preserved');report={'schema':'guarded-four-tested-container-key-child-body-only-stage/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'game_Unity_or_network_launched':False,'registration_or_provider_functionality_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-pure-four-key-child-body-importer',report);env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-and-readback-four-original-key-child-bodies',report,env)
        result=out/'Candidates/report.json';data=json.loads(result.read_bytes());need(data['status']=='four_tested_key_child_bodies_imported_all_original_metadata_other_bodies_preserved' and data['changed_method_bodies']==4 and len(data['modules'])==1 and not data['Main_modified'],'All four emitted bodies and metadata preservation actual proof')
        for row in data['modules']:check(row['candidate']);need(row['entire_donor_bodies_and_scoped_operands_equal'] and row['all_original_MethodDef_tokens_preserved'],'All exact donor operands/MethodDef tokens preserved')
        for row in p['modules']:check(row['original']);check(row['meta'])
        report.update(status='four_tested_key_child_bodies_staged_all_metadata_and_other_bodies_preserved',result=pin(result),candidates=[row['candidate'] for row in data['modules']],Main_plugin_and_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}));return 0 if report['status']=='four_tested_key_child_bodies_staged_all_metadata_and_other_bodies_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
