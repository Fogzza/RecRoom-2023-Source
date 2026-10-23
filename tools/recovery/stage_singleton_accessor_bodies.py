"""Prepare or Root-run two tested getter-body imports outside Main only.

Requires actual successful owner-binding and 10-effect proof. The helper copies
only compiled member IL into current original modules, then verifies all other
bodies, original metadata, scoped operands, and MethodDef tokens after emission.
There is deliberately no Main apply option in this tool.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,re,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
TEST=ROOT/'Validation/SingletonAccessorBindingEffects-20261023T080400Z-ca8ed568/run-report.json'
TEST_SHA='c5e7fe142c53b21468bd57136b680831d27f4292bb1f13a50c48ed673171a5cb'
APPLY=ROOT/'Validation/StartupThreeMemberExactApply-20261023T075506Z-0cb9bede/apply-receipt.json'
APPLY_SHA='686b35bc95bc1a1659f020650f08d63a6b0fd4f5244f46aa6263547352f10756'
SUPPORT=HERE.parent/'RuntimeMetadataAudit/COMCompatibility-20261022T100736Z'
PREVIOUS=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-two-tested-Singleton-accessor-body-only-import/v1'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:s=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':s}
def check(row):need(pin(row['path'])==row,'Pinned body-only import input changed: '+row['path'])
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def tested():
    need(pin(TEST)['sha256']==TEST_SHA,'Exact successful Root getter binding/effect receipt');r=json.loads(TEST.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['status']=='two_exact_original_accessor_bindings_and_ten_controlled_cases_passed' and r['controlled_effect_cases']==10 and r['exact_original_metadata_binding'] is True and not r['production_modules_executed'] and not r['Main_modified'],'Two getters actually compiled/bound and ten effects passed')
    need([x['phase'] for x in r['phases']]==['compile-explicit-accessor-controlled-effects-reader-v2','inspect-two-original-accessor-metadata-bindings','ten-exact-accessor-controlled-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'All three actual owned v2 phases passed')
    check(p['prior_failed_receipt']);check(p['prior_successful_donor_compile_plan']);prior=json.loads(Path(p['prior_failed_receipt']['path']).read_bytes());need(prior['phases'][0]['phase']=='compile-exact-Singleton-accessor-donor' and prior['phases'][0]['exit_code']==0 and prior['phases'][0]['owned_child_exit_confirmed'],'Unchanged donor originally compiled successfully')
    for row in [p[k] for k in ['runner','proof','members','baseline_stage_receipt','baseline_metadata_report','original_metadata_module','template','reviewable_fixed_donor','compiler','mono','reused_compiled_donor']]+p['sources']+p['references']+[r['compiled_donor']]:check(row)
    need(r['compiled_donor']==p['reused_compiled_donor'],'Use only the exact actual compiled and inspected getter donor')
    need(pin(APPLY)['sha256']==APPLY_SHA,'Exact Root actual prior three-body apply receipt');applied=json.loads(APPLY.read_bytes());need(applied['status']=='three_tested_original_startup_bodies_applied_two_SDKs_metas_preserved' and applied['metas_unchanged'] and applied['changed_method_bodies']==3,'Prior independently tested lower members remain applied')
    original=[x for x in applied['applied'] if Path(x['source']['path']).name=='RecRoom.Datastructures.Singletons.Runtime.dll'];need(len(original)==1,'One exact current Singleton plugin');original=original[0];check(original['source']);check(original['meta']);need(original['source']['sha256']==p['original_metadata_module']['sha256'],'Current Main equals the three-member staged metadata baseline inspected by accessor harness')
    return r,p,original

def prepare():
    r,p,original=tested();readable=[p['reviewable_fixed_donor']];need(p['sources'][0]['sha256']==readable[0]['sha256'] and p['sources'][0]['bytes']==readable[0]['bytes'],'Readable tool donor exactly equals successfully compiled source')
    out=ROOT/'Validation'/('SingletonAccessorBodyStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    modules=[{'original':original['source'],'meta':original['meta'],'donor':r['compiled_donor'],'members':[{'owner':'SingletonMonoBehaviour`1','name':'get_Instance'},{'owner':'SingletonMonoBehaviour`1','name':'get_IsInitialized'}]}]
    spec=out/'inputs.json';save(spec,{'schema':'two-tested-Singleton-accessor-body-only-import-input/v1','modules':modules})
    sources=[HERE/'StageSingletonAccessorBodies.cs']+[SUPPORT/name for name in ['CanonicalMetadataSignatures.cs','MetadataRoundTripSafety.cs','BodyAndSymbolSafety.cs']]
    old=(PREVIOUS/'compile.rsp').read_text(encoding='utf-8-sig');refs=[Path(s) for s in re.findall(r'(?m)^/reference:"([^"]+)"$',old) if '/packs/Microsoft.NETCore.App.Ref/' in s.replace('\\','/')];need(len(refs)>=100,'Exact existing framework reference pack')
    cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';refs.append(cecil);shutil.copyfile(cecil,out/cecil.name)
    output=out/'StageSingletonAccessorBodies.dll';rsp=out/'compile.rsp';rsp.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(s)+'"\n' for s in refs)+''.join('"'+str(s)+'"\n' for s in sources),encoding='utf-8',newline='\n')
    shutil.copyfile(PREVIOUS/'OriginalShaderObjectProbe.runtimeconfig.json',output.with_suffix('.runtimeconfig.json'))
    plan={'schema':SCHEMA,'status':'prepared_no_child_and_no_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'test_receipt':pin(TEST),'test_plan':r['plan'],'spec':pin(spec),'sources':[pin(s) for s in sources],'reviewable_donor_sources':readable,'response':pin(rsp),'references':[pin(s) for s in refs],'runtime':[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],'modules':modules,'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':pin(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),'output':str(output),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'Main_modified':False,'Main_apply_supported':False,'changed_bodies':2,'unselected_method_bodies_and_all_original_metadata_must_be_equal':True}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed owned suspended resource guard')
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed body-only stage plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('SingletonAccessorBodyStage-'),'Exact isolated candidate scope')
    need(p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['changed_bodies']==2 and not p['Main_apply_supported'],'Fixed read-only-to-Main body staging')
    for row in [p[k] for k in ['runner','test_receipt','test_plan','spec','response','guard','launcher','dotnet','compiler']]+p['sources']+p['reviewable_donor_sources']+p['references']+p['runtime']:check(row)
    for row in p['modules']:
        for key in ['original','donor','meta']:check(row[key])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed staging runner/guard');tested()
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_apply','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh outputs only, preserve failed staging')
    report={'schema':'guarded-two-tested-Singleton-accessor-body-only-stage/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'game_or_Unity_or_network_launched':False,'higher_bootstrap_activated':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-pure-two-getter-body-importer',report)
        env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-and-readback-two-original-getter-body-only-candidate',report,env)
        result=out/'Candidates/report.json';proof=json.loads(result.read_bytes());need(proof['status']=='two_tested_getter_bodies_imported_all_original_metadata_other_bodies_preserved' and proof['changed_method_bodies']==2 and len(proof['modules'])==1 and not proof['Main_modified'],'Exact emitted metadata and other-body proof required')
        for row in proof['modules']:check(row['candidate']);need(row['entire_donor_bodies_and_scoped_operands_equal'] and row['all_original_MethodDef_tokens_preserved'],'Full actual donor-body/token proof')
        for row in p['modules']:check(row['original']);check(row['meta'])
        report.update(status='two_tested_getters_staged_all_metadata_and_other_bodies_preserved',result=pin(result),candidates=[row['candidate'] for row in proof['modules']],Main_plugins_and_metas_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}));return 0 if report['status']=='two_tested_getters_staged_all_metadata_and_other_bodies_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare without child first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
