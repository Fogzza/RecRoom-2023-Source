"""Prepare or Root-run a matching real-Unity three-member lifecycle smoke.

Copies two staged SDKs with original metas and their genuine annotation-only
metadata dependency. An explicitly referenced player-only diagnostic assembly
observes real private fields and callbacks, never SDK getter stubs/GameRoot.
No Main write, backend call, or source publication occurs here.
"""
from pathlib import Path
import argparse,datetime as dt,json,re,shlex,uuid
import run_windows_development_define_probe as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
STAGE=ROOT/'Validation/StartupThreeMemberBodyStage-20261023T072237Z-29c9faaf'
STAGE_SHA='bc28f138814d1f1908848b2d9001a139d8df5c446edf45e6baa006af72490a85'
RESULT_SHA='c08fcd0a9615607a7cb2a51f764b6a370d69d491c2934c3923e5f996deb355eb'
GUARD_SHA='685f87ada7d4c10a09421e11b59466b3e19e817bfdaabd5a233c0192f17529fc'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
CAP=2*1024**3;SCHEMA='prepared-actual-Unity-original-startup-SDK-lifecycle-smoke/v1'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p);return {'path':str(p),'bytes':p.stat().st_size,'sha256':guard.sha(p)}
def check(row):need(pin(row['path'])==row,'Pinned SDK lifecycle input changed: '+row['path'])
def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')
def prepare():
    need(pin(STAGE/'run-report.json')['sha256']==STAGE_SHA and pin(STAGE/'Candidates/report.json')['sha256']==RESULT_SHA,'Actual full metadata/body staging proofs required')
    staged=json.loads((STAGE/'Candidates/report.json').read_bytes());need(staged['status']=='three_tested_bodies_imported_all_original_metadata_other_bodies_preserved' and staged['changed_method_bodies']==3,'Exact three staged bodies')
    sourceplan=json.loads((STAGE/'plan.json').read_bytes());need(pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCH_SHA and pin(HERE/'run_windows_development_define_probe.py')['sha256']==GUARD_SHA,'Reviewed assign-before-resume guard')
    fixture=ROOT/'Validation'/('StartupSdkLifecycleSmoke-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);fixture.mkdir();project=fixture/'Project';inputs=[];sources=[pin(STAGE/'run-report.json'),pin(STAGE/'Candidates/report.json'),pin(STAGE/'plan.json')]
    def write(relative,data):
        path=project/relative;path.parent.mkdir(parents=True,exist_ok=True)
        with path.open('xb') as f:f.write(data.encode('utf-8') if isinstance(data,str) else data)
        inputs.append(pin(path));return path
    def copy(source,relative):
        row=pin(source);target=write(relative,Path(source).read_bytes());need(pin(target)['sha256']==row['sha256'] and pin(source)==row,'Exact read-only source copy');sources.append(row);return target
    sdks=[]
    for row,original in zip(staged['modules'],sourceplan['modules']):
        check(row['candidate']);check(original['original']);check(original['meta']);name=Path(row['original']['path']).name
        dll=copy(Path(row['candidate']['path']),'Assets/Plugins/'+name);meta=copy(Path(original['meta']['path']),'Assets/Plugins/'+name+'.meta');sdks.append({'name':name,'dll':pin(dll),'meta':pin(meta),'origin':row['candidate'],'current_Main_origin':original['original'],'current_Main_meta':original['meta'],'kind':'staged_three_member_native_recovery'})
    name='RecRoom.NoEngine.JetBrains.Annotations.dll';original=WS/'RR23/Assets/Plugins'/name;meta=Path(str(original)+'.meta');dll=copy(original,'Assets/Plugins/'+name);metacopy=copy(meta,'Assets/Plugins/'+name+'.meta');sdks.append({'name':name,'dll':pin(dll),'meta':pin(metacopy),'origin':pin(original),'current_Main_origin':pin(original),'current_Main_meta':pin(meta),'kind':'genuine_required_annotation_metadata_dependency'})
    # Exact original import filters stay untouched. Player-only explicit refs
    # respect the original Editor-disabled, explicitly-referenced plugin metas.
    for row in sdks:
        text=Path(row['meta']['path']).read_text();need('isExplicitlyReferenced: 1' in text and 'Editor: Editor' in text and 'enabled: 0' in text,'Expected unchanged original importer filter shape')
    runtime=[copy(HERE/'StartupSdkLifecycleSmoke.v2.cs','Assets/Runtime/StartupSdkLifecycleSmoke.cs')]+[copy(HERE/name,'Assets/Runtime/'+name) for name in ['StartupSdkSingletonA.cs','StartupSdkSingletonB.cs']]
    builder=copy(HERE/'BuildStartupSdkLifecycleSmoke.cs','Assets/Editor/BuildStartupSdkLifecycleSmoke.cs')
    write('Assets/Runtime/Recovery.StartupSdk.Smoke.asmdef',json.dumps({'name':'Recovery.StartupSdk.Smoke','references':[],'excludePlatforms':['Editor'],'overrideReferences':True,'precompiledReferences':[row['name'] for row in sdks],'autoReferenced':True},indent=2)+'\n')
    write('Assets/Runtime/link.xml','<linker>\n  <assembly fullname="Recovery.StartupSdk.Smoke" preserve="all" />\n'+''.join('  <assembly fullname="'+row['name'][:-4]+'" preserve="all" />\n' for row in sdks)+'</linker>\n')
    write('ProjectSettings/ProjectVersion.txt','m_EditorVersion: 2020.3.33f1\nm_EditorVersionWithRevision: 2020.3.33f1 (915a7af8b0d5)\n')
    copy(WS/'RR23/ProjectSettings/ProjectSettings.asset','ProjectSettings/ProjectSettings.asset')
    package=guard.EDITOR.parent/'Data/Resources/PackageManager/BuiltInPackages/com.unity.modules.jsonserialize/package.json';need(json.loads(package.read_bytes())['version']=='1.0.0','Matching installed builtin JSON module');sources.append(pin(package));write('Packages/manifest.json','{"dependencies":{"com.unity.modules.jsonserialize":"1.0.0"}}\n')
    editor=guard.EDITOR.parent;mono=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';common=[mono/name for name in ['mscorlib.dll','System.dll','System.Core.dll']]
    editorrefs=common+[editor/'Data/Managed/UnityEditor.dll',editor/'Data/Managed/UnityEngine/UnityEngine.dll',editor/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',editor/'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll']
    playerrefs=common+[editor/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed'/name for name in ['UnityEngine.CoreModule.dll','UnityEngine.JSONSerializeModule.dll']]+[Path(row['dll']['path']) for row in sdks]
    checks=[]
    for name,files,refs in [('empty-scene-Editor-builder',[builder],editorrefs),('actual-SDK-player-only-probe',runtime,playerrefs)]:
        rsp=fixture/(name+'.rsp');rsp.write_text('/nologo\n/nostdlib+\n/target:library\n/langversion:8.0\n'+''.join('/reference:"'+str(p)+'"\n' for p in refs)+''.join('"'+str(p)+'"\n' for p in files),encoding='utf-8',newline='\n');checks.append({'name':name,'source':pin(files[0]),'additional_sources':[pin(p) for p in files[1:]],'response':pin(rsp),'references':[pin(p) for p in refs]})
    plan={'schema':SCHEMA,'status':'prepared_no_compiler_Editor_player_started','fixture':str(fixture),'project':str(project),'runner':pin(Path(__file__)),'guard':pin(HERE/'run_windows_development_define_probe.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'process_safety':pin(Path(guard.safety.__file__)),'editor':pin(guard.EDITOR),'cli':pin(guard.CLI),'compiler':pin(editor/'Data/Tools/Roslyn/csc.exe'),'inputs':inputs,'read_only_sources':sources,'sdks':sdks,'compile_checks':checks,'cap_bytes':CAP,'reserve_bytes':guard.RESERVE,'Editor_timeout_seconds':300,'player_timeout_seconds':60,'expected_runtime_checks':15,'production_GameRoot_instantiated':False,'getter_stubs_as_observations':False,'Main_modified':False,'original_SDK_metas_filters_and_all_unselected_bodies_preserved':True,'genuine_annotation_metadata_dependency_included':True,'working_boot_or_login_claimed':False}
    target=fixture/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def verify(path,digest):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed real Unity smoke plan');p=json.loads(path.read_bytes());fixture=path.parent;project=Path(p['project']).resolve(strict=True)
    need(p['schema']==SCHEMA and fixture.parent==ROOT/'Validation' and fixture.name.startswith('StartupSdkLifecycleSmoke-') and project==fixture/'Project' and p['cap_bytes']==CAP and p['reserve_bytes']==guard.RESERVE and p['Editor_timeout_seconds']==300 and p['player_timeout_seconds']==60,'Exact isolated matching fixture bounds')
    need(Path(p['editor']['path'])==guard.EDITOR and Path(p['cli']['path'])==guard.CLI and len(p['sdks'])==3 and p['expected_runtime_checks']==15,'Fixed original SDK dependency scope')
    for row in [p[k] for k in ['runner','guard','launcher','process_safety','editor','cli','compiler']]+p['inputs']+p['read_only_sources']:check(row)
    for group in p['compile_checks']:
        for row in [group['source'],group['response']]+group['additional_sources']+group['references']:check(row)
    for sdk in p['sdks']:
        for k in ['dll','meta','origin','current_Main_origin','current_Main_meta']:check(sdk[k])
    need(p['runner']==pin(Path(__file__)) and p['launcher']['sha256']==LAUNCH_SHA and p['guard']['sha256']==GUARD_SHA,'Reviewed exact runner and suspended launcher')
    need(not(project/'Library').exists() and not(project/'Temp').exists(),'Fresh never-launched smoke project required')
    need({x.resolve() for x in project.rglob('*') if x.is_file()}=={Path(x['path']).resolve() for x in p['inputs']},'Exact initial fixture inventory')
    return p,fixture,project
def execute(path,digest,run):
    p,fixture,project=verify(path,digest)
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_write','plan_sha256':digest}));return 0
    out=fixture/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'guarded-actual-Unity-original-startup-SDK-smoke/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'production_GameRoot_instantiated':False,'getter_stubs_as_observations':False,'working_boot_or_login_claimed':False}
    try:
        guard.compile_sources(p,project,out,report)
        player=out/'Player/StartupSdkLifecycleSmoke.exe';player.parent.mkdir();buildresult=out/'build-report.json';editorlog=out/'Editor.log'
        extra=shlex.join(['-disable-assembly-updater','-job-worker-count','1','-startupSdkBuildReport',buildresult.as_posix(),'-startupSdkProject',project.as_posix()])
        command=[guard.CLI.as_posix(),'build',project.as_posix(),'--target','StandaloneWindows64','--execute-method','BuildStartupSdkLifecycleSmoke.Run','--output-path',player.as_posix(),'--editor-path',guard.EDITOR.as_posix(),'--args',extra,'--timeout','300','--allow-dirty-build','--no-tail','--no-accelerator','--log-file',editorlog.as_posix(),'--provenance-path',(out/'provenance.json').as_posix(),'--format','json']
        guard.bounded(command,project,out,'matching-Unity-original-SDK-smoke-build',CAP,300,report)
        built=json.loads(buildresult.read_bytes());need(built['status']=='Succeeded' and built['errors']==0 and built['unity_version']=='2020.3.33f1' and built['backend']=='Mono2x' and built['target']=='StandaloneWindows64' and built['development'] and all(x in built['build_options'] for x in ['Development','StrictMode']),'Actual matching clean Mono Development Strict build required')
        report['build_result']=pin(buildresult);report['player']=pin(player);report['full_Editor_log']=pin(editorlog)
        packed=[]
        for sdk in p['sdks']:
            path=player.parent/'StartupSdkLifecycleSmoke_Data/Managed'/sdk['name'];record=pin(path);need(record['sha256']==sdk['dll']['sha256'],'Packaged actual SDK bytes must equal the exact staged/source DLL');packed.append(record)
        report['actual_packaged_SDKs']=packed
        result=out/'runtime-result.json';playerlog=out/'Player.log';guard.bounded([player.as_posix(),'-batchmode','-nographics','-startupSdkResult',result.as_posix(),'-logFile',playerlog.as_posix()],project,out,'actual-original-SDK-lifecycle-player',CAP,60,report)
        observed=json.loads(result.read_bytes());need(observed['schema']=='actual-Unity-original-startup-SDK-lifecycle-smoke/v1' and observed['status']=='actual_original_SDK_Awake_OnDestroy_and_disposed_guard_passed' and observed['mono_runtime'] and observed['unity_version']=='2020.3.33f1' and observed['platform']=='WindowsPlayer' and len(observed['checks'])==15 and not observed['errors'] and observed['end_frame']-observed['start_frame']>=6 and not observed['production_GameRoot_instantiated'] and not observed['game_getter_stubs_used'],'Actual field/lifecycle/exception witnesses must pass')
        need(all(observed[k] for k in ['old_GameObject_destroyed','new_instance_survived_old_OnDestroy','current_instance_cleared','independent_generic_storage','disposed_guard_exact_exception']),'Every original SDK runtime witness required')
        editorerrors=re.findall(r'(?im)^.*(?:error CS\d+|Fatal error|Aborting batchmode|TypeLoadException|ReflectionTypeLoadException).*$',editorlog.read_text(encoding='utf-8',errors='replace'));playererrors=re.findall(r'(?im)^.*(?:Unhandled Exception|TypeLoadException|ReflectionTypeLoadException|Fatal error|ERROR: Shader|Partial constant buffer not found).*$',playerlog.read_text(encoding='utf-8',errors='replace'));need(not editorerrors and not playererrors,'Full Editor/player log error scan must be clear')
        for sdk in p['sdks']:check(sdk['current_Main_origin']);check(sdk['current_Main_meta']);check(sdk['dll']);check(sdk['meta'])
        report.update(status='actual_original_SDK_lifecycle_and_disposed_guard_proved_in_matching_Windows_Mono_player',runtime_result=pin(result),actual_checks=observed['checks'],full_Player_log=pin(playerlog),full_log_error_counts={'Editor':len(editorerrors),'Player':len(playererrors)},all_selected_Main_plugins_and_metas_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();guard.save(out,report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_original_SDK_lifecycle_and_disposed_guard_proved_in_matching_Windows_Mono_player' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without launching');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
