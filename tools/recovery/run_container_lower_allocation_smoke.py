"""Prepare or Root-run genuine Unity HashSet/key allocation checks.

Copies staged UJect and genuine required annotation metadata only. Executes
only OENEDGPIOFN/CPAMAFPANDM constructors; the initialization candidate is
pinned as unexecuted evidence. No service registration, lookup, provider,
factory or logger path is invoked, and no Main file can be written.
"""
from pathlib import Path
import argparse,datetime as dt,json,re,shlex,uuid
import run_windows_development_define_probe as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
STAGE=ROOT/'Validation/ContainerLowerBodyStage-20261023T084345Z-cac57c96'
STAGE_SHA='a553cd64ef24528a2fb18392af1b29fc51c981a52282f8771e916ec826cf1fd1'
APPLY=ROOT/'Validation/StartupThreeMemberExactApply-20261023T075506Z-0cb9bede/apply-receipt.json'
APPLY_SHA='686b35bc95bc1a1659f020650f08d63a6b0fd4f5244f46aa6263547352f10756'
RESULT_SHA='1db12e1055a905d8057edf8998086cd2ba5ca7440c2edaf0e6e308e78a5bc3d7'
GUARD_SHA='685f87ada7d4c10a09421e11b59466b3e19e817bfdaabd5a233c0192f17529fc'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
CAP=2*1024**3;SCHEMA='prepared-actual-Unity-original-container-allocation-smoke/v1'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p);return {'path':str(p),'bytes':p.stat().st_size,'sha256':guard.sha(p)}
def check(row):need(pin(row['path'])==row,'Pinned SDK lifecycle input changed: '+row['path'])
def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')
def prepare():
    need(pin(STAGE/'run-report.json')['sha256']==STAGE_SHA and pin(STAGE/'Candidates/report.json')['sha256']==RESULT_SHA,'Actual full metadata/body staging proofs required')
    staged=json.loads((STAGE/'Candidates/report.json').read_bytes());need(staged['status']=='eight_tested_lower_bodies_imported_original_metadata_preserved_with_one_native_required_reference' and staged['changed_method_bodies']==8 and len(staged['modules'])==2,'Exact three staged bodies')
    sourceplan=json.loads((STAGE/'plan.json').read_bytes());need(pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCH_SHA and pin(HERE/'run_windows_development_define_probe.py')['sha256']==GUARD_SHA,'Reviewed assign-before-resume guard')
    fixture=ROOT/'Validation'/('ContainerLowerAllocationSmoke-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);fixture.mkdir();project=fixture/'Project';inputs=[];sources=[pin(STAGE/'run-report.json'),pin(STAGE/'Candidates/report.json'),pin(STAGE/'plan.json')]
    def write(relative,data):
        path=project/relative;path.parent.mkdir(parents=True,exist_ok=True)
        with path.open('xb') as f:f.write(data.encode('utf-8') if isinstance(data,str) else data)
        inputs.append(pin(path));return path
    def copy(source,relative):
        row=pin(source);target=write(relative,Path(source).read_bytes());need(pin(target)['sha256']==row['sha256'] and pin(source)==row,'Exact read-only source copy');sources.append(row);return target
    sdks=[]
    for row,original in zip(staged['modules'][:1],sourceplan['modules'][:1]):
        check(row['candidate']);check(original['original']);check(original['meta']);name=Path(row['original']['path']).name
        dll=copy(Path(row['candidate']['path']),'Assets/Plugins/'+name);meta=copy(Path(original['meta']['path']),'Assets/Plugins/'+name+'.meta');sdks.append({'name':name,'dll':pin(dll),'meta':pin(meta),'origin':row['candidate'],'current_Main_origin':original['original'],'current_Main_meta':original['meta'],'kind':'staged_six_lower_bodies_only_two_native_proved_constructors_executed'})
    name='RecRoom.NoEngine.JetBrains.Annotations.dll';original=WS/'RR23/Assets/Plugins'/name;meta=Path(str(original)+'.meta');dll=copy(original,'Assets/Plugins/'+name);metacopy=copy(meta,'Assets/Plugins/'+name+'.meta');sdks.append({'name':name,'dll':pin(dll),'meta':pin(metacopy),'origin':pin(original),'current_Main_origin':pin(original),'current_Main_meta':pin(meta),'kind':'genuine_required_annotation_metadata_dependency'})
    # Exact original import filters stay untouched. Player-only explicit refs
    # respect the original Editor-disabled, explicitly-referenced plugin metas.
    for row in sdks:
        text=Path(row['meta']['path']).read_text();need('isExplicitlyReferenced: 1' in text and 'Editor: Editor' in text and 'enabled: 0' in text,'Expected unchanged original importer filter shape')
    runtime=[copy(HERE/'ContainerLowerAllocationSmoke.cs','Assets/Runtime/ContainerLowerAllocationSmoke.cs')]
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
    plan={'schema':SCHEMA,'status':'prepared_no_compiler_Editor_player_started','fixture':str(fixture),'project':str(project),'runner':pin(Path(__file__)),'guard':pin(HERE/'run_windows_development_define_probe.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'process_safety':pin(Path(guard.safety.__file__)),'editor':pin(guard.EDITOR),'cli':pin(guard.CLI),'compiler':pin(editor/'Data/Tools/Roslyn/csc.exe'),'inputs':inputs,'read_only_sources':sources,'sdks':sdks,'compile_checks':checks,'cap_bytes':CAP,'reserve_bytes':guard.RESERVE,'Editor_timeout_seconds':300,'player_timeout_seconds':60,'expected_runtime_checks':15,'unexecuted_initialization_candidate':staged['modules'][1]['candidate'],'production_registration_lookup_factory_logger_or_provider_executed':False,'production_GameRoot_instantiated':False,'getter_stubs_as_observations':False,'Main_modified':False,'original_SDK_metas_filters_and_all_unselected_bodies_preserved':True,'genuine_annotation_metadata_dependency_included':True,'working_boot_or_login_claimed':False}
    target=fixture/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def verify(path,digest):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed real Unity smoke plan');p=json.loads(path.read_bytes());fixture=path.parent;project=Path(p['project']).resolve(strict=True)
    need(p['schema']==SCHEMA and fixture.parent==ROOT/'Validation' and fixture.name.startswith('ContainerLowerAllocationSmoke-') and project==fixture/'Project' and p['cap_bytes']==CAP and p['reserve_bytes']==guard.RESERVE and p['Editor_timeout_seconds']==300 and p['player_timeout_seconds']==60,'Exact isolated matching fixture bounds')
    need(Path(p['editor']['path'])==guard.EDITOR and Path(p['cli']['path'])==guard.CLI and len(p['sdks'])==2 and p['expected_runtime_checks']==15,'Fixed original SDK dependency scope')
    for row in [p[k] for k in ['runner','guard','launcher','process_safety','editor','cli','compiler','unexecuted_initialization_candidate']]+p['inputs']+p['read_only_sources']:check(row)
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
    out=fixture/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'guarded-actual-Unity-original-container-allocation-smoke/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'production_GameRoot_instantiated':False,'getter_stubs_as_observations':False,'working_boot_or_login_claimed':False}
    try:
        guard.compile_sources(p,project,out,report)
        player=out/'Player/ContainerLowerAllocationSmoke.exe';player.parent.mkdir();buildresult=out/'build-report.json';editorlog=out/'Editor.log'
        extra=shlex.join(['-disable-assembly-updater','-job-worker-count','1','-startupSdkBuildReport',buildresult.as_posix(),'-startupSdkProject',project.as_posix()])
        command=[guard.CLI.as_posix(),'build',project.as_posix(),'--target','StandaloneWindows64','--execute-method','BuildStartupSdkLifecycleSmoke.Run','--output-path',player.as_posix(),'--editor-path',guard.EDITOR.as_posix(),'--args',extra,'--timeout','300','--allow-dirty-build','--no-tail','--no-accelerator','--log-file',editorlog.as_posix(),'--provenance-path',(out/'provenance.json').as_posix(),'--format','json']
        guard.bounded(command,project,out,'matching-Unity-original-SDK-smoke-build',CAP,300,report)
        built=json.loads(buildresult.read_bytes());need(built['status']=='Succeeded' and built['errors']==0 and built['unity_version']=='2020.3.33f1' and built['backend']=='Mono2x' and built['target']=='StandaloneWindows64' and built['development'] and all(x in built['build_options'] for x in ['Development','StrictMode']),'Actual matching clean Mono Development Strict build required')
        report['build_result']=pin(buildresult);report['player']=pin(player);report['full_Editor_log']=pin(editorlog)
        packed=[]
        for sdk in p['sdks']:
            path=player.parent/'ContainerLowerAllocationSmoke_Data/Managed'/sdk['name'];record=pin(path);need(record['sha256']==sdk['dll']['sha256'],'Packaged actual SDK bytes must equal the exact staged/source DLL');packed.append(record)
        report['actual_packaged_SDKs']=packed
        result=out/'runtime-result.json';playerlog=out/'Player.log';guard.bounded([player.as_posix(),'-batchmode','-force-d3d11','-screen-fullscreen','0','-screen-width','64','-screen-height','64','-startupSdkResult',result.as_posix(),'-logFile',playerlog.as_posix()],project,out,'actual-original-SDK-lifecycle-player',CAP,60,report)
        observed=json.loads(result.read_bytes());need(observed['schema']=='actual-Unity-original-container-allocation-smoke/v1' and observed['status']=='actual_original_HashSet_scope_allocation_and_key_fields_passed' and observed['mono_runtime'] and observed['unity_version']=='2020.3.33f1' and observed['platform']=='WindowsPlayer' and len(observed['checks'])==15 and not observed['errors'] and not observed['production_registration_lookup_factory_logger_or_provider_executed'],'Actual genuine allocation/key witnesses only; no unproved game paths')
        need(all(observed[k] for k in ['original_reference_preserved','actual_HashSet_allocated','actual_Dictionary_allocated','key_constructor_fields_proved','independent_auxiliary_allocations']) and observed['requested_original_System_Core_reference']=='System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e','Original scope retained and real allocation/field resolution witnesses required')
        framework=player.parent/'ContainerLowerAllocationSmoke_Data/Managed/System.Core.dll';report['actual_packaged_System_Core']=pin(framework);report['requested_original_System_Core_reference']=observed['requested_original_System_Core_reference'];report['actual_resolved_HashSet_framework_identity']=observed['actual_HashSet_framework_identity'];report['actual_HashSet_field_type']=observed['actual_HashSet_field_type']
        editorerrors=re.findall(r'(?im)^.*(?:error CS\d+|Fatal error|Aborting batchmode|TypeLoadException|ReflectionTypeLoadException).*$',editorlog.read_text(encoding='utf-8',errors='replace'));playererrors=re.findall(r'(?im)^.*(?:Unhandled Exception|TypeLoadException|ReflectionTypeLoadException|Fatal error|ERROR: Shader|Partial constant buffer not found).*$',playerlog.read_text(encoding='utf-8',errors='replace'));need(not editorerrors and not playererrors,'Full Editor/player log error scan must be clear')
        playertext=playerlog.read_text(encoding='utf-8',errors='replace');need('Direct3D:' in playertext and re.search(r'(?im)^\s*Version:\s*Direct3D 11',playertext) and 'Renderer: Null Device' not in playertext,'Actual D3D11 device required for strict clean runtime log')
        for sdk in p['sdks']:check(sdk['current_Main_origin']);check(sdk['current_Main_meta']);check(sdk['dll']);check(sdk['meta'])
        report.update(status='actual_original_container_HashSet_allocation_and_key_fields_proved_in_matching_Windows_Mono_player',runtime_result=pin(result),actual_checks=observed['checks'],full_Player_log=pin(playerlog),full_log_error_counts={'Editor':len(editorerrors),'Player':len(playererrors)},all_selected_Main_plugins_and_metas_unchanged=True,actual_D3D11_initialized=True,only_closed_SDK_constructors_executed=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();guard.save(out,report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_original_container_HashSet_allocation_and_key_fields_proved_in_matching_Windows_Mono_player' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without launching');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
