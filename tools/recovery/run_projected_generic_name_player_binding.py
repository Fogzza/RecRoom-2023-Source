"""Prepare or Root-run one actual projected-reference/raw-SDK type binding diagnostic.

No Main path is written. The consumer is genuinely compiled against the current
projected SDK, while the isolated matching player receives only the unchanged
raw SDK. A recorded type-resolution failure completes the diagnostic; it never
becomes a successful binding or working-startup claim. No SDK method or
constructor and no production GameRoot is invoked.
"""
from pathlib import Path
import argparse,datetime as dt,json,re,shlex,uuid
import run_windows_development_define_probe as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROOF=ROOT/'Validation/TitleLeafGenericNameProof-20261023T084249Z-e5b1d08f/report.json'
PROOF_SHA='d3611ad86b0fa94f7437f507eaa54b6002ccbda4bcbedbd2f228134b1a176286'
GUARD_SHA='685f87ada7d4c10a09421e11b59466b3e19e817bfdaabd5a233c0192f17529fc'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
CAP=2*1024**3;SCHEMA='prepared-projected-reference-raw-SDK-matching-player-binding/v1'
IDENTITY='RecRoom.Datastructures.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'

def need(v,m):
    if not v:raise ValueError(m)

def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p);return {'path':str(p),'bytes':p.stat().st_size,'sha256':guard.sha(p)}

def check(row):need(pin(row['path'])==row,'Pinned diagnostic input changed: '+row['path'])

def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')

def prepare():
    need(pin(PROOF)['sha256']==PROOF_SHA,'Exact native/raw/projected arity-name evidence');proof=json.loads(PROOF.read_bytes())
    need(proof['status']=='same_original_type_token_assembly_arity_proven_for_one_field_only','Original semantic evidence is not a runtime resolution claim')
    raw=Path(proof['raw_runtime_contract']['module']['path']);projected=Path(proof['projected_compiler_contract']['module']['path']);check(proof['raw_runtime_contract']['module']);check(proof['projected_compiler_contract']['module'])
    need(raw==WS/'RR23/Assets/Plugins/RecRoom.Datastructures.Runtime.dll' and projected==WS/'RR23/CompilerSupport/References/RecRoom.Datastructures.Runtime.dll','Only the actual retained runtime and its actual compiler projection')
    need(pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCH_SHA and pin(HERE/'run_windows_development_define_probe.py')['sha256']==GUARD_SHA,'Reviewed suspended-owned guard')
    fixture=ROOT/'Validation'/('ProjectedGenericNamePlayerBinding-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);fixture.mkdir();project=fixture/'Project';inputs=[];sources=[pin(PROOF),pin(projected)]
    def write(relative,data):
        path=project/relative;path.parent.mkdir(parents=True,exist_ok=True)
        with path.open('xb') as f:f.write(data.encode() if isinstance(data,str) else data)
        inputs.append(pin(path));return path
    def copy(source,relative):
        record=pin(source);target=write(relative,Path(source).read_bytes());need(pin(target)['sha256']==record['sha256'] and pin(source)==record,'Exact source copy');sources.append(record);return target
    sdk=copy(raw,'Assets/Plugins/RecRoom.Datastructures.Runtime.dll');meta=copy(Path(str(raw)+'.meta'),'Assets/Plugins/RecRoom.Datastructures.Runtime.dll.meta')
    text=meta.read_text();need('isExplicitlyReferenced: 1' in text and 'Editor: Editor' in text and 'enabled: 0' in text and 'validateReferences: 0' in text,'Preserve actual original raw SDK importer filters')
    runtime=copy(HERE/'ProjectedGenericNamePlayerProbe.cs','Assets/Runtime/ProjectedGenericNamePlayerProbe.cs');builder=copy(HERE/'BuildStartupSdkLifecycleSmoke.cs','Assets/Editor/BuildStartupSdkLifecycleSmoke.cs')
    consumer_name='Recovery.ProjectedGenericConsumer.dll';consumer=project/'Assets/Plugins'/consumer_name
    consumer_meta=write('Assets/Plugins/'+consumer_name+'.meta','fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\nPluginImporter:\n  serializedVersion: 2\n  externalObjects: {}\n  iconMap: {}\n  executionOrder: {}\n  defineConstraints: []\n  isPreloaded: 0\n  isOverridable: 0\n  isExplicitlyReferenced: 1\n  validateReferences: 0\n  platformData:\n  - first:\n      Any:\n    second:\n      enabled: 1\n      settings: {}\n  - first:\n      Editor: Editor\n    second:\n      enabled: 0\n      settings: {}\n  userData:\n  assetBundleName:\n  assetBundleVariant:\n')
    write('Assets/Runtime/Recovery.ProjectedGenericBinding.Probe.asmdef',json.dumps({'name':'Recovery.ProjectedGenericBinding.Probe','references':[],'excludePlatforms':['Editor'],'overrideReferences':True,'precompiledReferences':[sdk.name,consumer_name],'autoReferenced':True},indent=2)+'\n')
    write('Assets/Runtime/link.xml','<linker>\n  <assembly fullname="Recovery.ProjectedGenericBinding.Probe" preserve="all" />\n  <assembly fullname="Recovery.ProjectedGenericConsumer" preserve="all" />\n  <assembly fullname="RecRoom.Datastructures.Runtime" preserve="all" />\n</linker>\n')
    write('ProjectSettings/ProjectVersion.txt','m_EditorVersion: 2020.3.33f1\nm_EditorVersionWithRevision: 2020.3.33f1 (915a7af8b0d5)\n');copy(WS/'RR23/ProjectSettings/ProjectSettings.asset','ProjectSettings/ProjectSettings.asset')
    package=guard.EDITOR.parent/'Data/Resources/PackageManager/BuiltInPackages/com.unity.modules.jsonserialize/package.json';need(json.loads(package.read_bytes())['version']=='1.0.0','Matching builtin JSON module');sources.append(pin(package));write('Packages/manifest.json','{"dependencies":{"com.unity.modules.jsonserialize":"1.0.0"}}\n')
    editor=guard.EDITOR.parent;monoapi=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';common=[monoapi/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];playerengine=editor/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed';core=playerengine/'UnityEngine.CoreModule.dll';jsonref=playerengine/'UnityEngine.JSONSerializeModule.dll';cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll'
    checks=[]
    groups=[('empty-scene-Editor-builder',builder,common+[editor/'Data/Managed/UnityEditor.dll',editor/'Data/Managed/UnityEngine/UnityEngine.dll',editor/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',editor/'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll'],'library'),('actual-player-reflection-only-probe',runtime,common+[core,jsonref],'library'),('projected-reference-generic-consumer',HERE/'ProjectedGenericNameConsumer.cs',common+[core,projected],'library'),('metadata-only-raw-projected-consumer-reader',HERE/'ProjectedGenericNameMetadata.cs',common+[monoapi/'Facades/netstandard.dll',cecil],'exe')]
    for name,source,refs,target in groups:
        rsp=fixture/(name+'.rsp');rsp.write_text('/nologo\n/nostdlib+\n/target:'+target+'\n/langversion:8.0\n'+''.join('/reference:"'+str(p)+'"\n' for p in refs)+'"'+str(source)+'"\n',encoding='utf-8',newline='\n');checks.append({'name':name,'source':pin(source),'additional_sources':[],'response':pin(rsp),'references':[pin(p) for p in refs],'target':target})
    plan={'schema':SCHEMA,'status':'prepared_no_compiler_Editor_player_started','fixture':str(fixture),'project':str(project),'runner':pin(Path(__file__)),'guard':pin(HERE/'run_windows_development_define_probe.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'process_safety':pin(Path(guard.safety.__file__)),'editor':pin(guard.EDITOR),'cli':pin(guard.CLI),'compiler':pin(editor/'Data/Tools/Roslyn/csc.exe'),'mono':pin(editor/'Data/MonoBleedingEdge/bin/mono.exe'),'Cecil':pin(cecil),'inputs':inputs,'read_only_sources':sources,'raw_SDK':pin(raw),'raw_SDK_meta':pin(Path(str(raw)+'.meta')),'fixture_SDK':pin(sdk),'fixture_SDK_meta':pin(meta),'projected_SDK':pin(projected),'consumer_output':str(consumer),'consumer_meta':pin(consumer_meta),'compile_checks':checks,'cap_bytes':CAP,'compile_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'Editor_timeout_seconds':300,'player_timeout_seconds':60,'SDK_bodies_invoked':False,'production_GameRoot_instantiated':False,'Main_modified':False,'no_binding_success_assumption':True,'no_runtime_metadata_normalization_or_rename':True}
    target=fixture/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def verify(path,digest):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed diagnostic plan');p=json.loads(path.read_bytes());fixture=path.parent;project=Path(p['project']).resolve(strict=True)
    need(p['schema']==SCHEMA and fixture.parent==ROOT/'Validation' and fixture.name.startswith('ProjectedGenericNamePlayerBinding-') and project==fixture/'Project' and p['cap_bytes']==CAP and p['compile_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['Editor_timeout_seconds']==300 and p['player_timeout_seconds']==60,'Exact bounded isolated matching fixture')
    for row in [p[k] for k in ['runner','guard','launcher','process_safety','editor','cli','compiler','mono','Cecil','raw_SDK','raw_SDK_meta','fixture_SDK','fixture_SDK_meta','projected_SDK','consumer_meta']]+p['inputs']+p['read_only_sources']:check(row)
    for group in p['compile_checks']:
        for row in [group['source'],group['response']]+group['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['launcher']['sha256']==LAUNCH_SHA and p['guard']['sha256']==GUARD_SHA and len(p['compile_checks'])==4 and Path(p['editor']['path'])==guard.EDITOR and Path(p['cli']['path'])==guard.CLI,'Exact reviewed runner/matching Editor/assign-before-resume guard')
    need(Path(p['consumer_output'])==project/'Assets/Plugins/Recovery.ProjectedGenericConsumer.dll' and not Path(p['consumer_output']).exists() and not(project/'Library').exists() and not(project/'Temp').exists(),'Fresh fixture and consumer output')
    need({x.resolve() for x in project.rglob('*') if x.is_file()}=={Path(x['path']).resolve() for x in p['inputs']},'Exact initial fixture inventory');return p,fixture,project

def execute(path,digest,run):
    p,fixture,project=verify(path,digest)
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_write','plan_sha256':digest}));return 0
    out=fixture/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'guarded-actual-projected-reference-raw-SDK-name-binding/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'SDK_bodies_invoked':False,'production_GameRoot_instantiated':False,'working_startup_claimed':False}
    try:
        compiled={}
        for group in p['compile_checks']:
            target=out/(group['name']+('.exe' if group['target']=='exe' else '.dll'))
            if group['name']=='projected-reference-generic-consumer':target=Path(p['consumer_output'])
            guard.bounded([Path(p['compiler']['path']).as_posix(),'@'+Path(group['response']['path']).as_posix(),'/out:'+target.as_posix()],project,out,'compile-'+group['name'],p['compile_cap_bytes'],30,report);compiled[group['name']]=pin(target)
        report['compiled_outputs']=compiled
        copied=out/'Mono.Cecil.dll'
        with copied.open('xb') as f:f.write(Path(p['Cecil']['path']).read_bytes())
        need(pin(copied)['sha256']==p['Cecil']['sha256'],'Exact metadata reader dependency')
        metadata=out/'actual-requested-and-raw-metadata.txt';helper=compiled['metadata-only-raw-projected-consumer-reader']
        guard.bounded([Path(p['mono']['path']).as_posix(),helper['path'],p['raw_SDK']['path'],p['projected_SDK']['path'],p['consumer_output'],str(metadata)],project,out,'inspect-actual-compiled-consumer-and-raw-contract',p['compile_cap_bytes'],30,report)
        lines=metadata.read_text().splitlines();pairs=[line.split('=',1) for line in lines];need(all(len(x)==2 for x in pairs) and len({x[0] for x in pairs})==len(pairs),'Exact unique metadata record keys');m=dict(pairs)
        need(m['status']=='actual_compiler_requested_name_and_raw_definition_proven' and m['requested_type']=='HHOBPMOCKMJ`1' and m['raw_type']=='HHOBPMOCKMJ' and m['requested_scope']==m['raw_scope']==IDENTITY and m['raw_generic_parameter_count']=='1' and m['metadata_only_no_game_or_SDK_execution']=='true','Actual compiled mismatch proof');report['metadata_observation']=m;report['metadata_evidence']=pin(metadata)
        consumer_pin=pin(p['consumer_output']);report['actual_projected_consumer']=consumer_pin
        player=out/'Player/ProjectedGenericBinding.exe';player.parent.mkdir();buildresult=out/'build-report.json';editorlog=out/'Editor.log'
        extra=shlex.join(['-disable-assembly-updater','-job-worker-count','1','-startupSdkBuildReport',buildresult.as_posix(),'-startupSdkProject',project.as_posix()])
        command=[guard.CLI.as_posix(),'build',project.as_posix(),'--target','StandaloneWindows64','--execute-method','BuildStartupSdkLifecycleSmoke.Run','--output-path',player.as_posix(),'--editor-path',guard.EDITOR.as_posix(),'--args',extra,'--timeout','300','--allow-dirty-build','--no-tail','--no-accelerator','--log-file',editorlog.as_posix(),'--provenance-path',(out/'provenance.json').as_posix(),'--format','json']
        guard.bounded(command,project,out,'matching-Unity-raw-SDK-projected-consumer-build',CAP,300,report)
        built=json.loads(buildresult.read_bytes());need(built['status']=='Succeeded' and built['errors']==0 and built['unity_version']=='2020.3.33f1' and built['backend']=='Mono2x' and built['target']=='StandaloneWindows64' and built['development'] and all(x in built['build_options'] for x in ['Development','StrictMode']),'Actual clean matching Mono Development Strict build')
        report['build_result']=pin(buildresult);report['player']=pin(player);report['full_Editor_log']=pin(editorlog);managed=player.parent/'ProjectedGenericBinding_Data/Managed';packaged=[]
        for source in [p['raw_SDK'],consumer_pin]:
            record=pin(managed/Path(source['path']).name);need(record['sha256']==source['sha256'],'Exact unchanged raw SDK and actual projected consumer packaged');packaged.append(record)
        report['actual_packaged_DLLs']=packaged
        result=out/'runtime-result.json';playerlog=out/'Player.log';guard.bounded([player.as_posix(),'-batchmode','-force-d3d11','-screen-fullscreen','0','-screen-width','64','-screen-height','64','-startupSdkResult',result.as_posix(),'-logFile',playerlog.as_posix()],project,out,'actual-Windows-Mono-projected-name-binding',CAP,60,report)
        observed=json.loads(result.read_bytes());need(observed['schema']=='actual-Windows-Mono-projected-generic-name-binding/v1' and observed['status'] in ['diagnostic_completed_projected_name_resolves_to_raw_definition','diagnostic_completed_projected_name_does_not_resolve'] and observed['mono_runtime'] and observed['unity_version']=='2020.3.33f1' and observed['platform']=='WindowsPlayer' and observed['raw_generic_constructible'] and not observed['SDK_bodies_invoked'] and not observed['production_GameRoot_instantiated'] and not observed['exception'] and not observed['errors'],'Actual completed bounded resolution diagnostic')
        need(observed['requested_SDK_identity']==observed['raw_SDK_identity']==IDENTITY and observed['requested_type_name']==m['requested_type'] and observed['raw_type_name']==m['raw_type'] and observed['raw_type_token']=='0x02000032' and observed['raw_SDK_mvid'].lower()==m['raw_mvid'].lower(),'Actual requested/raw identities agree with independent compiled metadata')
        need(observed['projected_consumer_binding_succeeded']==(observed['status']=='diagnostic_completed_projected_name_resolves_to_raw_definition') and (observed['raw_and_resolved_same_type'] if observed['projected_consumer_binding_succeeded'] else bool(observed['projected_resolution_exception_type'])),'Resolution success and observed failure are distinct')
        editorerrors=re.findall(r'(?im)^.*(?:error CS\d+|Fatal error|Aborting batchmode|TypeLoadException|ReflectionTypeLoadException).*$',editorlog.read_text(encoding='utf-8',errors='replace'));playertext=playerlog.read_text(encoding='utf-8',errors='replace');playererrors=re.findall(r'(?im)^.*(?:Unhandled Exception|Fatal error|ERROR: Shader|Partial constant buffer not found).*$',playertext);need(not editorerrors and not playererrors,'Clean complete logs, with caught binding exception retained only as diagnostic data')
        need('Direct3D:' in playertext and re.search(r'(?im)^\s*Version:\s*Direct3D 11',playertext) and 'Renderer: Null Device' not in playertext,'Actual D3D11 initialization')
        for key in ['raw_SDK','raw_SDK_meta','fixture_SDK','fixture_SDK_meta','projected_SDK','consumer_meta']:check(p[key])
        check(consumer_pin);report.update(status='actual_matching_player_generic_name_binding_diagnostic_completed',runtime_result=pin(result),projected_consumer_binding_succeeded=observed['projected_consumer_binding_succeeded'],resolution_status=observed['status'],actual_checks=observed['checks'],full_Player_log=pin(playerlog),full_log_error_counts={'Editor':len(editorerrors),'Player':len(playererrors)},all_selected_Main_SDK_and_meta_bytes_unchanged=True,no_runtime_metadata_normalization_or_rename=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();guard.save(out,report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'projected_consumer_binding_succeeded':report.get('projected_consumer_binding_succeeded'),'error':report.get('error')}));return 0 if report['status']=='actual_matching_player_generic_name_binding_diagnostic_completed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without launching');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
