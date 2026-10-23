"""Prepare or Root-run only the existing SDK smoke player with a real D3D11 device.

The frozen first three successful compile/build phases are reused, not rerun.
The old NullGPU/log-scan failure is retained and explicitly pinned as provenance.
No compiler, Editor, Main mutation, or network operation is available here.
"""
from pathlib import Path
import argparse, copy, datetime as dt, json, re, uuid
import run_startup_sdk_lifecycle_smoke_v2 as original

HERE=Path(__file__).resolve().parent; ROOT=original.ROOT; guard=original.guard
OLD=ROOT/'Validation/StartupSdkLifecycleSmoke-20261023T073956Z-58499243/Run-20261023T074515Z-6112ec08'
OLD_SHA='8a3b77377646be8d588ad29e1df9c42ea6e4fe27947ef7253e83071e2832afab'
PLAN_SHA='913d7b11b623ef3485bf86eaf20bbac85dbe3586ebbff48448c75246e11d401d'
SCHEMA='prepared-original-SDK-existing-player-D3D11-retest/v1'
PHASES=['empty-scene-Editor-builder-compile','actual-SDK-player-only-probe-compile','matching-Unity-original-SDK-smoke-build','actual-original-SDK-lifecycle-player']
pin=original.pin;check=original.check;need=original.need;save=original.save

def scan(editor,player):
    e=re.findall(r'(?im)^.*(?:error CS\d+|Fatal error|Aborting batchmode|TypeLoadException|ReflectionTypeLoadException).*$',editor)
    p=re.findall(r'(?im)^.*(?:Unhandled Exception|TypeLoadException|ReflectionTypeLoadException|Fatal error|ERROR: Shader|Partial constant buffer not found).*$',player)
    return e,p

def observe(row):
    need(row['schema']=='actual-Unity-original-startup-SDK-lifecycle-smoke/v1' and row['status']=='actual_original_SDK_Awake_OnDestroy_and_disposed_guard_passed' and row['mono_runtime'] and row['unity_version']=='2020.3.33f1' and row['platform']=='WindowsPlayer' and len(row['checks'])==15 and not row['errors'] and row['end_frame']-row['start_frame']>=6 and not row['production_GameRoot_instantiated'] and not row['game_getter_stubs_used'],'All fifteen real lifecycle witnesses required')
    need(all(row[k] for k in ['old_GameObject_destroyed','new_instance_survived_old_OnDestroy','current_instance_cleared','independent_generic_storage','disposed_guard_exact_exception']),'Exact original SDK effects required')

def baseline():
    need(pin(OLD/'run-report.json')['sha256']==OLD_SHA,'Frozen previous failed overall receipt')
    r=json.loads((OLD/'run-report.json').read_bytes());check(r['plan']);need(r['plan']['sha256']==PLAN_SHA,'Frozen actual original source/build plan')
    p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['status']=='failed_or_guard_refused_preserve_outputs' and r['error']=="ValueError('Full Editor/player log error scan must be clear')",'Only the preserved final full-log gate failed')
    need([x['phase'] for x in r['phases']]==PHASES and all(x['exit_code']==0 and x['owned_cli_or_compiler_exit_confirmed'] and x['Editor_closed_after_job'] and x['launcher']['membership_verified_before_resume'] for x in r['phases']),'All previous actual processes succeeded and closed')
    for k in ['runner','guard','launcher','process_safety','editor','cli','compiler']:check(p[k])
    # Unity reserialized this fixture's ProjectSettings during the successful
    # build. It is not player input in this runtime-only retest. Pin its current
    # bytes separately without misrepresenting them as the prebuild bytes.
    setting=str(Path(p['project'])/'ProjectSettings/ProjectSettings.asset')
    for row in p['inputs']+p['read_only_sources']:
        if row['path']!=setting:check(row)
    for group in p['compile_checks']:
        for row in [group['source'],group['response']]+group['additional_sources']+group['references']:check(row)
    for sdk in p['sdks']:
        for k in ['dll','meta','origin','current_Main_origin','current_Main_meta']:check(sdk[k])
    for k in ['build_result','player','full_Editor_log']:check(r[k])
    for row in r['actual_packaged_SDKs']:check(row)
    observe(json.loads((OLD/'runtime-result.json').read_bytes()))
    for phase in r['phases'][:2]:
        dll=OLD/(phase['phase']+'.dll');need(pin(dll)['sha256']==phase['output_sha256'],'Successful original compiled output unchanged')
    built=json.loads(Path(r['build_result']['path']).read_bytes())
    need(built['status']=='Succeeded' and built['errors']==0 and built['unity_version']=='2020.3.33f1' and built['backend']=='Mono2x' and built['target']=='StandaloneWindows64' and built['development'] and all(x in built['build_options'] for x in ['Development','StrictMode']),'Original real matching player build')
    oldlog=(OLD/'Player.log').read_text(encoding='utf-8',errors='replace');e,errors=scan(Path(r['full_Editor_log']['path']).read_text(encoding='utf-8',errors='replace'),oldlog)
    need(not e and errors and all('ERROR: Shader' in x and ('Sprites/Default' in x or 'Sprites/Mask' in x) for x in errors) and 'Renderer: Null Device' in oldlog,'Preserved failure is specifically builtin shaders on NullGPU; never waived')
    return r,p

def inventory(player):
    base=player.parent;rows=[]
    for path in sorted(base.rglob('*')):
        guard.safety.assert_no_reparse(path)
        if path.is_file():rows.append(pin(path))
    need(rows and len(rows)<=512 and sum(x['bytes'] for x in rows)<=256*1024**2,'Bounded exact existing player inventory')
    return rows

def prepare():
    r,p=baseline();out=ROOT/'Validation'/('StartupSdkD3D11Retest-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','runner':pin(Path(__file__)),'original_runner':pin(Path(original.__file__)),'guard':p['guard'],'launcher':p['launcher'],'process_safety':p['process_safety'],'original_failed_overall_receipt':pin(OLD/'run-report.json'),'original_actual_build_plan':r['plan'],'fixture':str(out),'project':p['project'],'postbuild_Unity_reserialized_fixture_settings':pin(Path(p['project'])/'ProjectSettings/ProjectSettings.asset'),'player':r['player'],'player_inventory':inventory(Path(r['player']['path'])),'sdks':p['sdks'],'read_only_sources':p['read_only_sources'],'reused_successful_phase_names':PHASES[:3],'cap_bytes':original.CAP,'reserve_bytes':guard.RESERVE,'player_timeout_seconds':60,'expected_runtime_checks':15,'arguments':['-batchmode','-force-d3d11','-screen-fullscreen','0','-screen-width','64','-screen-height','64'],'original_overall_failure_preserved':True,'Main_modified':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def verify(path,digest):
    need(pin(path)['sha256']==digest,'Explicit reviewed D3D11 runtime-only plan');p=json.loads(path.read_bytes());out=path.parent
    need(p['schema']==SCHEMA and out.parent==ROOT/'Validation' and out.name.startswith('StartupSdkD3D11Retest-') and p['fixture']==str(out) and p['cap_bytes']==original.CAP and p['reserve_bytes']==guard.RESERVE and p['player_timeout_seconds']==60 and p['expected_runtime_checks']==15,'Exact runtime-only scope/bounds')
    for k in ['runner','original_runner','guard','launcher','process_safety','original_failed_overall_receipt','original_actual_build_plan','postbuild_Unity_reserialized_fixture_settings','player']:check(p[k])
    need(p['runner']==pin(Path(__file__)) and p['original_runner']==pin(Path(original.__file__)) and p['arguments']==['-batchmode','-force-d3d11','-screen-fullscreen','0','-screen-width','64','-screen-height','64'],'Exact unchanged reviewed runner and real-device arguments')
    r,old=baseline();need(p['sdks']==old['sdks'] and p['read_only_sources']==old['read_only_sources'] and p['player']==r['player'] and p['reused_successful_phase_names']==PHASES[:3] and p['player_inventory']==inventory(Path(p['player']['path'])),'Exact existing built player/source/config preservation')
    return p,r

def execute(path,digest,run):
    p,old=verify(path,digest)
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':digest}));return 0
    out=path.parent/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    phases=copy.deepcopy(old['phases'][:3])
    for phase in phases:phase['reused_from_frozen_actual_receipt']=p['original_failed_overall_receipt'];phase['executed_in_this_retest']=False
    report={'schema':'guarded-actual-Unity-original-startup-SDK-smoke/v1','status':'starting','plan':pin(path),'phases':phases,'prior_failed_overall_receipt':p['original_failed_overall_receipt'],'retest_only_player':True,'reused_prior_successful_compiles_and_build':True,'Main_modified':False,'production_GameRoot_instantiated':False,'getter_stubs_as_observations':False,'working_boot_or_login_claimed':False,'build_result':old['build_result'],'player':old['player'],'full_Editor_log':old['full_Editor_log'],'actual_packaged_SDKs':old['actual_packaged_SDKs']}
    try:
        result=out/'runtime-result.json';log=out/'Player.log';command=[Path(p['player']['path']).as_posix()]+p['arguments']+['-startupSdkResult',result.as_posix(),'-logFile',log.as_posix()]
        guard.bounded(command,Path(p['project']),out,PHASES[3],original.CAP,60,report)
        row=json.loads(result.read_bytes());observe(row)
        text=log.read_text(encoding='utf-8',errors='replace');e,errors=scan(Path(old['full_Editor_log']['path']).read_text(encoding='utf-8',errors='replace'),text)
        need(not e and not errors,'Unchanged strict full Editor/player log scan must be clear')
        need('Direct3D:' in text and re.search(r'(?im)^\s*Version:\s*Direct3D 11',text) and 'Renderer: Null Device' not in text and 'Forcing GfxDevice: Null' not in text,'Actual non-Null D3D11 initialization evidence required')
        verify(path,digest)
        report.update(status='actual_original_SDK_lifecycle_and_disposed_guard_proved_in_matching_Windows_Mono_player',runtime_result=pin(result),actual_checks=row['checks'],full_Player_log=pin(log),full_log_error_counts={'Editor':0,'Player':0},all_selected_Main_plugins_and_metas_unchanged=True,actual_D3D11_initialized=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();guard.save(out,report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_original_SDK_lifecycle_and_disposed_guard_proved_in_matching_Windows_Mono_player' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit plan SHA required');return execute(v.plan.resolve(strict=True),v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first, Root-only explicit run');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
