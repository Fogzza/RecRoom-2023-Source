"""Prepare or Root-run three tested body imports outside Main only.

Requires actual successful owner-binding and 17-effect proof. The helper copies
only compiled member IL into current original modules, then verifies all other
bodies, original metadata, scoped operands, and MethodDef tokens after emission.
There is deliberately no Main apply option in this tool.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,re,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
TEST=ROOT/'Validation/StartupThreeMemberBindingEffects-20261023T071226Z-a2643d20/run-report.json'
TEST_SHA='4a38c651b5d73c13af1ad87f070154efedd28a36648d975cd3c16ec807acde50'
SUPPORT=HERE.parent/'RuntimeMetadataAudit/COMCompatibility-20261022T100736Z'
PREVIOUS=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-three-tested-startup-body-only-import/v1'
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
    need(pin(TEST)['sha256']==TEST_SHA,'Exact Root actual binding/effect receipt required');r=json.loads(TEST.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['status']=='three_exact_owner_bindings_and_seventeen_controlled_effect_cases_passed' and r['controlled_effect_cases']==17 and r['exact_original_metadata_binding'] is True and r['all_selected_Main_sources_plugins_metas_unchanged'] is True and not r['production_donor_DLLs_executed'] and not r['body_import_or_apply_performed'],'Actual three-member proof must have passed')
    need([x['phase'] for x in r['phases']]==['compile-explicit-controlled-effects-reader-v2','inspect-three-original-metadata-bindings','seventeen-exact-member-controlled-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'Exact three successful owned v2 phases')
    check(p['prior_failure_receipt']);prior=json.loads(Path(p['prior_failure_receipt']['path']).read_bytes());need(all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in prior['phases'][:2]),'Both original exact donor compiles passed')
    for row in [p[k] for k in ['proof','template','runner','compiler','mono']]+p['sources']+p['references']+p['members']+p['current_source_checkpoint']+r['compiled_donors']:check(row)
    for row in p['original_modules']:check({k:row[k] for k in ['path','bytes','sha256']});check(row['meta'])
    return r,p
def prepare():
    r,p=tested();readable=[pin(HERE/name) for name in ['RecoveredSingletonStartupDonor.cs','RecoveredDisposedGuardDonor.cs']]
    for source,published in zip(p['sources'][:2],readable):need(source['bytes']==published['bytes'] and source['sha256']==published['sha256'],'Fixed readable tool source must exactly match actual compiled donor source')
    out=ROOT/'Validation'/('StartupThreeMemberBodyStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    modules=[]
    for original,donor in zip(p['original_modules'],r['compiled_donors']):
        members=[{'owner':'SingletonMonoBehaviour`1','name':'Awake'},{'owner':'SingletonMonoBehaviour`1','name':'OnDestroy'}] if original['assembly']=='RecRoom.Datastructures.Singletons.Runtime.dll' else [{'owner':'MKECFLEMHEL','name':'GFKAFPHLKMJ'}]
        modules.append({'original':{k:original[k] for k in ['path','bytes','sha256']},'meta':original['meta'],'donor':donor,'members':members})
    spec=out/'inputs.json';save(spec,{'schema':'three-tested-startup-member-body-only-import-input/v1','modules':modules})
    sources=[HERE/'StageStartupThreeMemberBodies.v3.cs']+[SUPPORT/name for name in ['CanonicalMetadataSignatures.cs','MetadataRoundTripSafety.cs','BodyAndSymbolSafety.cs']]
    old=(PREVIOUS/'compile.rsp').read_text(encoding='utf-8-sig');refs=[Path(s) for s in re.findall(r'(?m)^/reference:"([^"]+)"$',old) if '/packs/Microsoft.NETCore.App.Ref/' in s.replace('\\','/')];need(len(refs)>=100,'Exact existing framework reference pack')
    cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';refs.append(cecil);shutil.copyfile(cecil,out/cecil.name)
    output=out/'StageStartupThreeMemberBodies.dll';rsp=out/'compile.rsp';rsp.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(s)+'"\n' for s in refs)+''.join('"'+str(s)+'"\n' for s in sources),encoding='utf-8',newline='\n')
    shutil.copyfile(PREVIOUS/'OriginalShaderObjectProbe.runtimeconfig.json',output.with_suffix('.runtimeconfig.json'))
    plan={'schema':SCHEMA,'status':'prepared_no_child_and_no_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'test_receipt':pin(TEST),'test_plan':r['plan'],'spec':pin(spec),'sources':[pin(s) for s in sources],'reviewable_donor_sources':readable,'response':pin(rsp),'references':[pin(s) for s in refs],'runtime':[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],'modules':modules,'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':pin(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),'output':str(output),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'Main_modified':False,'Main_apply_supported':False,'changed_bodies':3,'unselected_method_bodies_and_all_original_metadata_must_be_equal':True}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed owned suspended resource guard')
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed body-only stage plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('StartupThreeMemberBodyStage-'),'Exact isolated candidate scope')
    need(p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['changed_bodies']==3 and not p['Main_apply_supported'],'Fixed read-only-to-Main body staging')
    for row in [p[k] for k in ['runner','test_receipt','test_plan','spec','response','guard','launcher','dotnet','compiler']]+p['sources']+p['reviewable_donor_sources']+p['references']+p['runtime']:check(row)
    for row in p['modules']:
        for key in ['original','donor','meta']:check(row[key])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed staging runner/guard');tested()
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_apply','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh outputs only, preserve failed staging')
    report={'schema':'guarded-three-tested-startup-body-only-stage/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'game_or_Unity_or_network_launched':False,'higher_bootstrap_activated':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-pure-three-member-body-importer',report)
        env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-and-readback-three-original-body-only-candidates',report,env)
        result=out/'Candidates/report.json';proof=json.loads(result.read_bytes());need(proof['status']=='three_tested_bodies_imported_all_original_metadata_other_bodies_preserved' and proof['changed_method_bodies']==3 and len(proof['modules'])==2 and not proof['Main_modified'],'Exact emitted metadata and other-body proof required')
        for row in proof['modules']:check(row['candidate']);need(row['entire_donor_bodies_and_scoped_operands_equal'] and row['all_original_MethodDef_tokens_preserved'],'Full actual donor-body/token proof')
        for row in p['modules']:check(row['original']);check(row['meta'])
        report.update(status='three_tested_original_bodies_staged_all_metadata_and_other_bodies_preserved',result=pin(result),candidates=[row['candidate'] for row in proof['modules']],Main_plugins_and_metas_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}));return 0 if report['status']=='three_tested_original_bodies_staged_all_metadata_and_other_bodies_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare without child first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
