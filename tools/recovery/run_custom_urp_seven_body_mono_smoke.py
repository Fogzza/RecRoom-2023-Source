"""Prepare or Root-run actual matching Windows Mono URP metadata/safe-body smoke.

Candidate + eight exact genuine SDK dependencies, original plugin metas, an
empty Builtin scene, no game root, no renderer/pipeline ctor/non-null Dispose
or frame execution. All compiler/Unity/player phases require explicit --run.
"""
from pathlib import Path
import argparse,datetime as dt,json,re,shlex,uuid
import run_windows_development_define_probe as guard
import audit_custom_urp_cecil_reindex as raw
import audit_hashable_scoped_vtable as signatures
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
STAGE=ROOT/'Validation/CustomUrpSevenBodyStageV3-20261023T095100Z-057fd079'
STAGE_SHA='f98cee8cea37da9ae31ea26c146f3dd0c41488d19fd0ba027cf1e88cec3d9c81'
RESULT_SHA='aa33c6d071ce434bd89bcff2ff8739e7b28f1d4541899fce7dde0c7659847ea5'
GUARD_SHA='685f87ada7d4c10a09421e11b59466b3e19e817bfdaabd5a233c0192f17529fc'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-actual-original-custom-URP-seven-body-Mono-smoke/v1';CAP=2*1024**3
EXPECTED_SDKS=['Unity.Burst.dll','Unity.Collections.dll','Unity.InputSystem.dll','Unity.Jobs.dll','Unity.Mathematics.dll','Unity.RenderPipeline.Universal.ShaderLibrary.dll','Unity.RenderPipelines.Core.Runtime.dll','Unity.RenderPipelines.Universal.Runtime.dll','UnityEngine.UI.dll']
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p);return {'path':str(p),'bytes':p.stat().st_size,'sha256':guard.sha(p)}
def check(row):need(pin(row['path'])==row,'Pinned URP smoke input changed: '+row['path'])
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def stage():
    need(pin(STAGE/'run-report.json')['sha256']==STAGE_SHA and pin(STAGE/'Candidates/report.json')['sha256']==RESULT_SHA,'Actual reviewed finite-map stage')
    r=json.loads((STAGE/'run-report.json').read_bytes());p=json.loads((STAGE/'plan.json').read_bytes());s=json.loads((STAGE/'Candidates/report.json').read_bytes());check(r['plan']);check(r['result']);check(r['independent_raw_CLI_validation']);need(r['status']=='seven_tested_URP_bodies_staged_semantic_metadata_other_bodies_preserved_exact_finite_raw_reindex' and len(r['phases'])==2 and all(x['exit_code']==0 for x in r['phases']) and len(s['modules'])==1 and s['changed_method_bodies']==7 and s['raw_RID_and_four_empty_Param_normalization_explicit'],'Actual stage phases and explicit normalization required')
    return r,p,s
def refs(path):
    c=raw.Cli(path.read_bytes());return [signatures.m.identity(c,35,i) for i in range(1,c.rows[35]+1)]
def closure():
    todo=['Unity.RenderPipelines.Universal.Runtime.dll'];seen={};engine=set()
    while todo:
        name=todo.pop(0)
        if name in seen:continue
        p=WS/'RR23/Assets/Plugins'/name;seen[name]=pin(p)
        for r in refs(p):
            source=WS/'RR23/Assets/Plugins'/(r['name']+'.dll')
            if source.exists():todo.append(source.name)
            else:
                need(r['name'].startswith('UnityEngine.') or r['name'] in ['mscorlib','System','System.Core'],'Unproved external SDK dependency '+r['full_name'])
                if r['name'].startswith('UnityEngine.'):engine.add(r['name']+'.dll')
    need(sorted(seen)==EXPECTED_SDKS,'Exact nine SDK original reference closure')
    return seen,sorted(engine)
def canon(s):
    s=re.sub(r'\[([^,\]]+), Version=[^\]]+\]',lambda m:'['+m[1]+']',s)
    # Reflection exposes array rank/element, not encoded optional size/bounds.
    # Raw byte/semantic metadata proof independently preserves those exact blobs.
    s=re.sub(r',([0-9]+),\[[0-9, ]*\],\[[0-9, ]*\]\)',r',\1)',s)
    return s
def expected_manifest(path):
    m=raw.Model(path);types=[];fields=[];methods=[];method_refs=[]
    def owner(s):return s.split(']',1)[1]
    for ri in range(1,m.c.rows[2]+1):
        n=m.r.definition(ri)
        if n!='<Module>':types.append({'token':2<<24|ri,'name':n})
    for ri,v in m.field.items():fields.append({'token':4<<24|ri,'owner':owner(v['owner']),'name':v['name'],'type':canon(v['type'])})
    for ri,v in m.method.items():methods.append({'token':6<<24|ri,'owner':owner(v['owner']),'name':v['name'],'return_type':canon(v['signature']['return']),'parameters':[canon(s) for s in v['signature']['parameters']],'arity':v['signature']['arity'],'callconv':v['signature']['callconv']})
    old=raw.Model(raw.ORIGINAL);original_refs=[old.token(10<<24|i) for i in range(1,old.c.rows[10]+1)]
    for ri in range(1,m.c.rows[10]+1):
        token=10<<24|ri;v=m.token(token)
        if v not in original_refs:
            d=json.loads(v);method_refs.append({'token':token,'owner':owner(d['owner']),'name':d['name']})
    need((len(types),len(fields),len(methods),len(method_refs))==(298,2015,1616,6),'Exact actual staged metadata runtime witness counts')
    return {'assembly_full_name':m.r.asm,'referenced_assemblies':[r['full_name'] for r in refs(path)],'types':types,'fields':fields,'methods':methods,'added_method_refs':method_refs}
def controls(expected):
    need(len(expected['types'])==298 and len({x['token'] for x in expected['fields']})==2015 and len({x['token'] for x in expected['methods']})==1616,'Unique runtime manifest tokens');need(len(expected['added_method_refs'])==6,'Six new original scoped method refs')
    source=(HERE/'CustomUrpSevenBodyMonoSmoke.cs').read_text();need('new ForwardRenderer(' not in source and 'new UniversalRenderPipeline(' not in source and '.Dispose(' not in source and '.Render(' not in source,'Forbidden downstream execution absent');need('GraphicsSettings.currentRenderPipeline==null' in source and 'k_AssetPreviousVersion' in source and 'Calls' not in source,'Safe branch preconditions explicit')
    return {'schema':'pure-URP-Mono-smoke-preparation-controls/v1','status':'passed','checks':['exact_actual_candidate_298_2015_1616_6_manifest','unique_native_emitted_tokens','exact_nine_original_SDK_closure','all_forbidden_downstream_construction_disposal_frame_calls_absent','safe_builtin_and_version_mismatch_preconditions_explicit'],'managed_Unity_or_player_executed':False,'runtime_claimed':False}
def prepare():
    r,p,s=stage();seen,engine=closure();need(pin(HERE/'run_windows_development_define_probe.py')['sha256']==GUARD_SHA and pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCH_SHA,'Exact suspended owned guard')
    candidate=s['modules'][0]['candidate'];check(candidate);expected=expected_manifest(Path(candidate['path']));out=ROOT/'Validation'/('CustomUrpSevenBodyMonoSmoke-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();project=out/'Project';inputs=[];sources=[]
    def write(rel,data):
        target=project/rel;target.parent.mkdir(parents=True,exist_ok=True)
        with target.open('xb') as f:f.write(data.encode('utf-8') if isinstance(data,str) else data)
        inputs.append(pin(target));return target
    def copy(source,rel):
        original=pin(source);target=write(rel,Path(source).read_bytes());need(pin(source)==original and pin(target)['sha256']==original['sha256'],'Exact input copy');sources.append(original);return target
    sdks=[]
    for name in EXPECTED_SDKS:
        original=Path(seen[name]['path']);origin=Path(candidate['path']) if name=='Unity.RenderPipelines.Universal.Runtime.dll' else original;meta=Path(str(original)+'.meta');dll=copy(origin,'Assets/Plugins/'+name);met=copy(meta,'Assets/Plugins/'+name+'.meta');text=meta.read_text();need('isExplicitlyReferenced: 1' in text and 'Editor: Editor' in text and 'enabled: 0' in text,'Original Editor-disabled explicit SDK importer filters preserved');sdks.append({'name':name,'dll':pin(dll),'meta':pin(met),'origin':pin(origin),'Main_original':pin(original),'Main_meta':pin(meta)})
    runtime=copy(HERE/'CustomUrpSevenBodyMonoSmoke.cs','Assets/Runtime/CustomUrpSevenBodyMonoSmoke.cs');builder=copy(HERE/'BuildStartupSdkLifecycleSmoke.cs','Assets/Editor/BuildStartupSdkLifecycleSmoke.cs')
    write('Assets/Runtime/Recovery.CustomUrp.SafeSmoke.asmdef',json.dumps({'name':'Recovery.CustomUrp.SafeSmoke','references':[],'excludePlatforms':['Editor'],'overrideReferences':True,'precompiledReferences':EXPECTED_SDKS,'autoReferenced':True},indent=2)+'\n')
    write('Assets/Runtime/link.xml','<linker>\n  <assembly fullname="Recovery.CustomUrp.SafeSmoke" preserve="all" />\n'+''.join('  <assembly fullname="'+x[:-4]+'" preserve="all" />\n' for x in EXPECTED_SDKS)+'</linker>\n')
    write('Assets/Resources/CustomUrpBindingExpected.json',json.dumps(expected,indent=2)+'\n');write('ProjectSettings/ProjectVersion.txt','m_EditorVersion: 2020.3.33f1\nm_EditorVersionWithRevision: 2020.3.33f1 (915a7af8b0d5)\n');copy(WS/'RR23/ProjectSettings/ProjectSettings.asset','ProjectSettings/ProjectSettings.asset')
    builtin=guard.EDITOR.parent/'Data/Resources/PackageManager/BuiltInPackages';packages={}
    for name in ['animation','imgui','jsonserialize','physics','physics2d','ui','xr']:
        path=builtin/('com.unity.modules.'+name)/'package.json';value=json.loads(path.read_bytes());need(value['name']=='com.unity.modules.'+name and value['version']=='1.0.0','Genuine installed matching builtin module');packages[value['name']]=value['version'];sources.append(pin(path))
    write('Packages/manifest.json',json.dumps({'dependencies':packages},indent=2)+'\n')
    editor=guard.EDITOR.parent;framework=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';common=[framework/n for n in ['mscorlib.dll','System.dll','System.Core.dll']];engineDir=editor/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed'
    editorrefs=common+[editor/'Data/Managed/UnityEditor.dll',editor/'Data/Managed/UnityEngine/UnityEngine.dll',editor/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',editor/'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll'];playerrefs=common+[engineDir/n for n in sorted(set(engine+['UnityEngine.JSONSerializeModule.dll']))]+[Path(x['dll']['path']) for x in sdks];compiles=[]
    for name,source,refs_ in [('empty-scene-Editor-builder',builder,editorrefs),('actual-custom-URP-safe-Mono-probe',runtime,playerrefs)]:
        rsp=out/(name+'.rsp');rsp.write_text('/nologo\n/nostdlib+\n/target:library\n/langversion:8.0\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs_)+'"'+str(source)+'"\n',encoding='utf-8',newline='\n');compiles.append({'name':name,'source':pin(source),'additional_sources':[],'response':pin(rsp),'references':[pin(x) for x in refs_]})
    cp=out/'preparation-controls.json';save(cp,controls(expected));plan={'schema':SCHEMA,'status':'prepared_no_child_no_Main_write','fixture':str(out),'project':str(project),'runner':pin(Path(__file__)),'guard':pin(HERE/'run_windows_development_define_probe.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'process_safety':pin(Path(guard.safety.__file__)),'editor':pin(guard.EDITOR),'cli':pin(guard.CLI),'compiler':pin(editor/'Data/Tools/Roslyn/csc.exe'),'stage_receipt':pin(STAGE/'run-report.json'),'stage_plan':pin(STAGE/'plan.json'),'stage_result':pin(STAGE/'Candidates/report.json'),'raw_CLI_proof':r['independent_raw_CLI_validation'],'inputs':inputs,'read_only_sources':sources,'sdks':sdks,'compile_checks':compiles,'preparation_controls':pin(cp),'cap_bytes':CAP,'reserve_bytes':guard.RESERVE,'Editor_timeout_seconds':300,'player_timeout_seconds':60,'expected_runtime_checks':20,'expected_binding_counts':{'types':298,'fields':2015,'methods':1616,'added_method_refs':6},'Main_modified':False,'working_renderer_claimed':False,'constructors_Dispose_or_frame_executed':False,'original_metas_preserved':True};pp=out/'plan.json';save(pp,plan);print(json.dumps({'plan':pin(pp),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(pp),'--plan-sha256',pin(pp)['sha256'],'--run']}))
def verify(path,digest):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Reviewed explicit actual URP smoke plan');p=json.loads(path.read_bytes());out=path.parent;project=Path(p['project']).resolve(strict=True);need(p['schema']==SCHEMA and out.parent==ROOT/'Validation' and out.name.startswith('CustomUrpSevenBodyMonoSmoke-') and project==out/'Project' and p['cap_bytes']==CAP and p['reserve_bytes']==guard.RESERVE and p['Editor_timeout_seconds']==300 and p['player_timeout_seconds']==60 and [x['name'] for x in p['sdks']]==EXPECTED_SDKS and not p['constructors_Dispose_or_frame_executed'],'Exact bounded fixture/dependency/behavior scope')
    for row in [p[k] for k in ['runner','guard','launcher','process_safety','editor','cli','compiler','stage_receipt','stage_plan','stage_result','raw_CLI_proof','preparation_controls']]+p['inputs']+p['read_only_sources']:check(row)
    for group in p['compile_checks']:
        for row in [group['source'],group['response']]+group['references']:check(row)
    for sdk in p['sdks']:
        for k in ['dll','meta','origin','Main_original','Main_meta']:check(sdk[k])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed runner/guard');need(not(project/'Library').exists() and not(project/'Temp').exists(),'Never-launched fresh fixture');need({x.resolve() for x in project.rglob('*') if x.is_file()}=={Path(x['path']).resolve() for x in p['inputs']},'Exact initial fixture inventory');stage();return p,out,project
def execute(path,digest,run):
    p,fixture,project=verify(path,digest)
    if not run:print(json.dumps({'status':'verified_no_child_no_Main_write','plan_sha256':digest}));return 0
    out=fixture/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'guarded-actual-original-custom-URP-seven-body-Mono-smoke/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'working_renderer_claimed':False,'constructors_Dispose_or_frame_executed':False}
    try:
        guard.compile_sources(p,project,out,report);player=out/'Player/CustomUrpSevenBodyMonoSmoke.exe';player.parent.mkdir();build=out/'build-report.json';elog=out/'Editor.log';extra=shlex.join(['-disable-assembly-updater','-job-worker-count','1','-startupSdkBuildReport',build.as_posix(),'-startupSdkProject',project.as_posix()]);command=[guard.CLI.as_posix(),'build',project.as_posix(),'--target','StandaloneWindows64','--execute-method','BuildStartupSdkLifecycleSmoke.Run','--output-path',player.as_posix(),'--editor-path',guard.EDITOR.as_posix(),'--args',extra,'--timeout','300','--allow-dirty-build','--no-tail','--no-accelerator','--log-file',elog.as_posix(),'--provenance-path',(out/'provenance.json').as_posix(),'--format','json'];guard.bounded(command,project,out,'matching-Unity-custom-URP-safe-smoke-build',CAP,300,report)
        built=json.loads(build.read_bytes());need(built['status']=='Succeeded' and built['errors']==0 and built['unity_version']=='2020.3.33f1' and built['backend']=='Mono2x' and built['target']=='StandaloneWindows64' and built['development'] and all(x in built['build_options'] for x in ['Development','StrictMode']),'Actual strict matching Mono build')
        report.update(build_result=pin(build),player=pin(player),full_Editor_log=pin(elog));packed=[]
        for sdk in p['sdks']:
            dll=player.parent/'CustomUrpSevenBodyMonoSmoke_Data/Managed'/sdk['name'];record=pin(dll);need(record['sha256']==sdk['dll']['sha256'],'Actual packaged SDK byte identity');packed.append(record)
        report['actual_packaged_SDKs']=packed;result=out/'runtime-result.json';plog=out/'Player.log';guard.bounded([player.as_posix(),'-batchmode','-force-d3d11','-screen-fullscreen','0','-screen-width','64','-screen-height','64','-urpSmokeResult',result.as_posix(),'-logFile',plog.as_posix()],project,out,'actual-original-custom-URP-Mono-safe-player',CAP,60,report)
        observed=json.loads(result.read_bytes());need(observed['schema']=='actual-original-custom-URP-seven-body-Mono-binding-smoke/v1' and observed['status']=='actual_original_URP_metadata_binding_and_safe_seven_body_paths_passed' and observed['mono_runtime'] and observed['unity_version']=='2020.3.33f1' and observed['platform']=='WindowsPlayer' and len(observed['checks'])==p['expected_runtime_checks'] and not observed['errors'] and not observed['constructors_Dispose_or_frame_executed'] and not observed['working_renderer_claimed'] and observed['end_frame']-observed['start_frame']>=2,'Every actual binding/safe-path check required');need({k:observed[k] for k in p['expected_binding_counts']}==p['expected_binding_counts'],'Exact actual structural binding counts')
        strict=r'(?im)^.*(?:error CS\d+|Unhandled Exception|TypeLoadException|ReflectionTypeLoadException|MissingMethodException|MissingFieldException|InvalidProgramException|FileNotFoundException|Fatal error|Aborting batchmode|ERROR: Shader|Partial constant buffer not found).*$';ee=re.findall(strict,elog.read_text(encoding='utf-8',errors='replace'));pt=plog.read_text(encoding='utf-8',errors='replace');pe=re.findall(strict,pt);need(not ee and not pe,'Full Editor/player strict logs must remain clear');need('Direct3D:' in pt and re.search(r'(?im)^\s*Version:\s*Direct3D 11',pt) and 'Renderer: Null Device' not in pt,'Actual D3D11 device required')
        for sdk in p['sdks']:
            for k in ['dll','meta','origin','Main_original','Main_meta']:check(sdk[k])
        report.update(status='actual_original_URP_finite_metadata_binding_and_safe_paths_proved_in_matching_Windows_Mono',runtime_result=pin(result),actual_checks=observed['checks'],full_Player_log=pin(plog),full_log_error_counts={'Editor':len(ee),'Player':len(pe)},actual_D3D11_initialized=True,Main_plugins_and_metas_unchanged=True)
    except BaseException as e:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(e))
    finally:report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();guard.save(out,report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_original_URP_finite_metadata_binding_and_safe_paths_proved_in_matching_Windows_Mono' else 1
def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--plan',type=Path);p.add_argument('--plan-sha256');p.add_argument('--run',action='store_true');a=p.parse_args()
    if a.plan:need(a.plan_sha256,'Exact reviewed Root plan SHA');return execute(a.plan,a.plan_sha256,a.run)
    need(not a.run and not a.plan_sha256,'Prepare only first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
