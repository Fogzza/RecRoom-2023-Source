"""Root-only fresh-clone actual Windows Mono S12 plus prior7 safe smoke.

No Editor rebuild. The exact registered diagnostic assembly/type/Boot name is
retained; only diagnostic DLL/PDB and two tested SDK DLLs change in the clone.
The original player, SDKs, metas, Main and all earlier receipts stay untouched.
"""
from pathlib import Path
import argparse, datetime as dt, json, re, shutil, uuid
import run_custom_urp_seven_body_mono_smoke as prior
import stage_custom_urp_initializer_prerequisite_bodies_v2 as stage
import audit_custom_urp_cecil_reindex as raw

HERE=prior.HERE;WS=prior.WS;ROOT=prior.ROOT;guard=prior.guard
pin=prior.pin;check=prior.check;need=prior.need;save=prior.save
STAGE=ROOT/'Validation/CustomUrpInitializerTwelveBodyStageV2-20261023T105426Z-364bec00'
STAGE_SHA='b7266b0ce04722326aaaa707213d333d77c972f99dba79c6c0718cc22036b431'
BASE=ROOT/'Validation/CustomUrpSevenBodyMonoSmoke-20261023T100312Z-a4f1df91/Run-20261023T100533Z-9c9227cf'
BASE_SHA='09193492804243f057dbc376334b23525149c3b1cfe242b9dcff354e30c2dbe6'
RUNTIME='Recovery.CustomUrp.SafeSmoke.dll';CAP=2*1024**3;COMPILE_CAP=256*1024**2
SCHEMA='prepared-actual-original-custom-URP-initializer12-plus-seven-cloned-Mono-smoke/v1'
BOOT='[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]static void Boot(){new GameObject("OriginalCustomUrpSafeSmoke").AddComponent<CustomUrpSevenBodyMonoSmoke>();}'
STRICT=r'(?im)^.*(?:error CS\d+|Unhandled Exception|TypeLoadException|ReflectionTypeLoadException|MissingMethodException|MissingFieldException|InvalidProgramException|FileNotFoundException|Fatal error|Aborting batchmode|ERROR: Shader|Partial constant buffer not found).*$'

def baselines():
    need(pin(STAGE/'run-report.json')['sha256']==STAGE_SHA and pin(BASE/'run-report.json')['sha256']==BASE_SHA,'Exact successful actual stage and real prior player smoke')
    s=json.loads((STAGE/'run-report.json').read_bytes());b=json.loads((BASE/'run-report.json').read_bytes())
    need(s['status']=='twelve_tested_bodies_staged_full_scoped_metadata_other_bodies_preserved' and len(s['phases'])==2 and all(x['exit_code']==0 for x in s['phases']) and s['raw_Param_omissions']==0 and not s['Main_modified'],'Actual strict twelve-body stage')
    need(b['status']=='actual_original_URP_finite_metadata_binding_and_safe_paths_proved_in_matching_Windows_Mono' and len(b['actual_checks'])==20 and b['full_log_error_counts']=={'Editor':0,'Player':0} and b['actual_D3D11_initialized'],'Actual prior20 safe paths in genuine Windows D3D11 Mono')
    for row in [s['plan'],s['result'],s['independent_raw_CLI_validation'],b['plan'],b['player'],b['runtime_result'],b['build_result']]+s['candidates']+b['actual_packaged_SDKs']:check(row)
    for row in [b['full_Editor_log'],b['full_Player_log']]:check(row);need(not re.findall(STRICT,Path(row['path']).read_text(encoding='utf-8',errors='replace')),'Prior whole logs independently strict clear')
    need('CustomUrpSevenBodyMonoSmoke.exe'==Path(b['player']['path']).name,'Exact existing player')
    return s,b,json.loads(Path(b['plan']['path']).read_bytes())

def manifest(candidate,original,counts):
    m=raw.Model(candidate);old=raw.Model(original);types=[];fields=[];methods=[];refs=[]
    def owner(value):return value.split(']',1)[1].split('<',1)[0]
    for i in range(1,m.c.rows[2]+1):
        name=m.r.definition(i)
        if name!='<Module>':types.append({'token':2<<24|i,'name':name})
    for i,v in m.field.items():fields.append({'token':4<<24|i,'owner':v['owner'].split(']',1)[1],'name':v['name'],'type':prior.canon(v['type'])})
    for i,v in m.method.items():methods.append({'token':6<<24|i,'owner':v['owner'].split(']',1)[1],'name':v['name'],'return_type':prior.canon(v['signature']['return']),'parameters':[prior.canon(x) for x in v['signature']['parameters']],'arity':v['signature']['arity'],'callconv':v['signature']['callconv']})
    oldrefs=[old.token(10<<24|i) for i in range(1,old.c.rows[10]+1)]
    for i in range(1,m.c.rows[10]+1):
        value=m.token(10<<24|i)
        if value not in oldrefs:
            v=json.loads(value);need('signature' in v,'Only method additions in actual candidates');refs.append({'token':10<<24|i,'owner':owner(v['owner']),'name':v['name']})
    need((len(types),len(fields),len(methods),len(refs))==counts,'Exact independently staged binding counts')
    return {'assembly_full_name':m.r.asm,'referenced_assemblies':[x['full_name'] for x in prior.refs(candidate)],'types':types,'fields':fields,'methods':methods,'added_method_refs':refs}

def prepare():
    s,b,old=baselines();need(pin(HERE/'run_windows_development_define_probe.py')['sha256']==prior.GUARD_SHA and pin(HERE/'owned_suspended_launch.py')['sha256']==prior.LAUNCH_SHA,'Frozen owned2GiB guard unchanged')
    source=HERE/'CustomUrpInitializerTwelveMonoSmoke.cs';text=source.read_text();original=(HERE/'CustomUrpSevenBodyMonoSmoke.cs').read_text();need(text.count(BOOT)==original.count(BOOT)==1 and 'public sealed class CustomUrpSevenBodyMonoSmoke : MonoBehaviour' in text,'Exact original registered assembly/type/Boot entry')
    need(text.count('Check(')==40 and text.count('InitializerPrerequisites(asset);')==1 and 'new ForwardRenderer(' not in text and 'new UniversalRenderPipeline(' not in text and '.Render(' not in text,'39 checks; no renderer/pipeline construction or custom frame execution')
    out=ROOT/'Validation'/('CustomUrpInitializerTwelveClonedMonoSmoke-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();candidates={Path(x['path']).name:x for x in s['candidates']}
    source_root=Path(b['player']['path']).parent;files=[{'relative':x.relative_to(source_root).as_posix(),'pin':pin(x)} for x in sorted(source_root.rglob('*')) if x.is_file()];need(len(files)<512 and sum(x['pin']['bytes'] for x in files)<256*1024**2,'Bounded genuine previous player clone')
    core=candidates[stage.CORE+'.dll'];urp=candidates[stage.URP+'.dll'];stage_plan=json.loads(Path(s['plan']['path']).read_bytes())
    for module in stage_plan['modules']:check(module['original']);check(module['meta'])
    manifests=[]
    for name,candidate,authority,counts in [('Core',core,WS/'RR23/Assets/Plugins/Unity.RenderPipelines.Core.Runtime.dll',(278,897,1695,1)),('URP',urp,raw.ORIGINAL,(298,2015,1616,12))]:
        p=out/(name+'-binding-expected.json');save(p,manifest(Path(candidate['path']),authority,counts));manifests.append(pin(p))
    runtime_dir=out/'CompiledRuntime';runtime_dir.mkdir();dll=runtime_dir/RUNTIME;pdb=dll.with_suffix('.pdb');response=out/'compile-runtime.rsp';group=old['compile_checks'][1];references=[]
    for row in group['references']:
        check(row);name=Path(row['path']).name;references.append(candidates.get(name,row))
    response.write_text('/nologo\n/nostdlib+\n/target:library\n/langversion:8.0\n/optimize+\n/debug:portable\n/deterministic+\n/out:"'+str(dll)+'"\n/pdb:"'+str(pdb)+'"\n'+''.join('/reference:"'+x['path']+'"\n' for x in references)+'"'+str(source)+'"\n',encoding='utf-8',newline='\n')
    diagnostic_relative='CustomUrpSevenBodyMonoSmoke_Data/Managed/'+RUNTIME;need(any(x['relative']==diagnostic_relative for x in files) and any(x['relative']==diagnostic_relative[:-4]+'.pdb' for x in files),'Existing exact diagnostic DLL/PDB pair')
    replacements=[diagnostic_relative,diagnostic_relative[:-4]+'.pdb']+['CustomUrpSevenBodyMonoSmoke_Data/Managed/'+x for x in candidates]
    cp=out/'preparation-controls.json';save(cp,{'schema':'pure-initializer12-player-clone-admission-controls/v1','status':'passed','cases':['actual12binding31effects_stage_and_full_scoped_audit_pinned','prior20_actual_Windows_Mono_D3D11_paths_and_whole_logs_pinned','exact_registered_diagnostic_assembly_type_Boot_retained','all_previous20_checks_retained_plus19_new_checks','full_Core_and_URP_binding_manifests_from_actual_emitted_RIDs','original_player_inventory_finite_and_all_files_pinned','only_two_SDKs_and_diagnostic_DLL_PDB_replaceable','no_Editor_or_custom_renderer_frame_or_instance_constructor_launch'],'genuine_Runtime_behavior_not_yet_claimed':True})
    plan={'schema':SCHEMA,'status':'prepared_no_child_no_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'prior_runner':pin(Path(prior.__file__)),'stage_runner':pin(Path(stage.__file__)),'stage_receipt':pin(STAGE/'run-report.json'),'stage_plan':s['plan'],'stage_result':s['result'],'stage_scoped_audit':s['independent_raw_CLI_validation'],'prior_actual_receipt':pin(BASE/'run-report.json'),'prior_actual_plan':b['plan'],'prior_runtime_result':b['runtime_result'],'prior_build_result':b['build_result'],'source_player_root':str(source_root),'source_player_files':files,'source_player':b['player'],'source':pin(source),'source_members':pin(HERE/'CustomUrpInitializerTwelveMonoSmoke.members.cs'),'frozen_original_runtime_source':pin(HERE/'CustomUrpSevenBodyMonoSmoke.cs'),'binding_manifests':manifests,'candidates':s['candidates'],'stage_modules':stage_plan['modules'],'references':references,'response':pin(response),'compiler':old['compiler'],'guard':old['guard'],'launcher':old['launcher'],'process_safety':old['process_safety'],'runtime_output':str(dll),'runtime_pdb_output':str(pdb),'diagnostic_relative_path':diagnostic_relative,'allowed_clone_replacements':replacements,'expected_runtime_identity':'Recovery.CustomUrp.SafeSmoke, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null','expected_runtime_checks':39,'expected_binding_counts':{'types':298,'fields':2015,'methods':1616,'added_method_refs':12,'core_types':278,'core_fields':897,'core_methods':1695,'core_added_method_refs':1},'compile_cap_bytes':COMPILE_CAP,'cap_bytes':CAP,'reserve_bytes':guard.RESERVE,'compile_timeout_seconds':90,'player_timeout_seconds':60,'preparation_controls':pin(cp),'Main_modified':False,'Editor_launch_supported':False,'ForwardRenderer_pipeline_instance_constructor_nonnull_Dispose_or_custom_frame_execution_supported':False,'boundary':'Asset and test Data ScriptableObject constructor stubs, generated callback Object constructor, and existing still-stub static initializers may execute. Original ForwardRenderer/pipeline instance constructors and nonnull Dispose/frame remain HELD; no working renderer claimed.'}
    pp=out/'plan.json';save(pp,plan);print(json.dumps({'plan':pin(pp),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(pp),'--plan-sha256',pin(pp)['sha256'],'--run']}))

def verify(path,digest):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed actual cloned Mono smoke plan');p=json.loads(path.read_bytes());out=path.parent
    need(p['schema']==SCHEMA and out.parent==ROOT/'Validation' and out.name.startswith('CustomUrpInitializerTwelveClonedMonoSmoke-') and p['cap_bytes']==CAP and p['compile_cap_bytes']==COMPILE_CAP and p['reserve_bytes']==guard.RESERVE and p['compile_timeout_seconds']==90 and p['player_timeout_seconds']==60 and p['expected_runtime_checks']==39 and not p['Editor_launch_supported'],'Exact clone-only finite resource scope')
    for row in [p[k] for k in ['runner','prior_runner','stage_runner','stage_receipt','stage_plan','stage_result','stage_scoped_audit','prior_actual_receipt','prior_actual_plan','prior_runtime_result','prior_build_result','source_player','source','source_members','frozen_original_runtime_source','response','compiler','guard','launcher','process_safety','preparation_controls']]+p['binding_manifests']+p['candidates']+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==prior.GUARD_SHA and p['launcher']['sha256']==prior.LAUNCH_SHA,'Exact runner/frozen memory guard')
    root=Path(p['source_player_root']).resolve(strict=True);need(root==Path(p['source_player']['path']).parent and root==BASE/'Player','Exact frozen original player only')
    need({x.relative_to(root).as_posix() for x in root.rglob('*') if x.is_file()}=={x['relative'] for x in p['source_player_files']},'Exact old player inventory')
    for row in p['source_player_files']:
        check(row['pin']);need(Path(row['pin']['path'])==root/row['relative'],'Exact owned source relative file')
    need(p['runtime_output']==str(out/'CompiledRuntime'/RUNTIME) and p['runtime_pdb_output']==str((out/'CompiledRuntime'/RUNTIME).with_suffix('.pdb')),'Fresh fixed diagnostic outputs')
    for module in p['stage_modules']:check(module['original']);check(module['meta'])
    baselines();return p,out

def execute(path,digest,run):
    p,out=verify(path,digest)
    if not run:print(json.dumps({'status':'verified_no_child_no_Main_write','checks':39,'Editor_required':False}));return 0
    need(not(out/'run-report.json').exists() and not(out/'PlayerClone').exists() and not Path(p['runtime_output']).exists() and not Path(p['runtime_pdb_output']).exists(),'Fresh one-shot clone/compile outputs only')
    report={'schema':'guarded-actual-original-custom-URP-initializer12-plus-seven-cloned-Mono-smoke/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Editor_launched':False,'working_renderer_claimed':False,'boundary':p['boundary']}
    try:
        guard.bounded([p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,out,'compile-clone-only-actual12-plus-seven-diagnostic',COMPILE_CAP,90,report)
        dll=Path(p['runtime_output']);pdb=Path(p['runtime_pdb_output']);need(raw.Model(dll).r.asm==p['expected_runtime_identity'],'Exact registered runtime assembly identity retained');need(pdb.exists(),'Matching fresh diagnostic PDB required')
        clone=out/'PlayerClone';clone.mkdir();original=Path(p['source_player_root'])
        for row in p['source_player_files']:
            target=clone/row['relative'];need(target.resolve().is_relative_to(clone.resolve()),'Clone target stays owned');target.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(row['pin']['path'],target);need(pin(target)['sha256']==row['pin']['sha256'],'Exact original player clone before replacements')
        replacements=[(dll,clone/p['diagnostic_relative_path']),(pdb,(clone/p['diagnostic_relative_path']).with_suffix('.pdb'))]+[(Path(x['path']),clone/'CustomUrpSevenBodyMonoSmoke_Data/Managed'/Path(x['path']).name) for x in p['candidates']]
        need({t.relative_to(clone).as_posix() for s,t in replacements}==set(p['allowed_clone_replacements']),'Only four explicitly approved clone replacements')
        for source,target in replacements:shutil.copyfile(source,target);need(pin(target)['sha256']==pin(source)['sha256'],'Exact fresh SDK/diagnostic copy')
        def integrity():
            for row in p['source_player_files']:
                check(row['pin']);target=clone/row['relative'];expected=next((pin(src)['sha256'] for src,dest in replacements if dest==target),row['pin']['sha256']);need(pin(target)['sha256']==expected,'Every cloned original file unchanged outside exact four replacements')
            for row in p['candidates']:check(row)
            for module in p['stage_modules']:check(module['original']);check(module['meta'])
        integrity();player=clone/Path(p['source_player']['path']).name;result=out/'runtime-result.json';log=out/'Player.log';core,urp=p['binding_manifests'];guard.bounded([player.as_posix(),'-batchmode','-force-d3d11','-screen-fullscreen','0','-screen-width','64','-screen-height','64','-urpSmokeResult',result.as_posix(),'-urpSmokeBindingExpected',Path(urp['path']).as_posix(),'-urpSmokeCoreBindingExpected',Path(core['path']).as_posix(),'-logFile',log.as_posix()],out,out,'actual-cloned-Windows-Mono-initializer12-plus-seven-safe-player',CAP,60,report)
        value=json.loads(result.read_bytes());need(value['schema']=='actual-original-custom-URP-initializer12-plus-seven-Mono-binding-smoke/v1' and value['status']=='actual_original_URP_initializer12_and_safe_seven_body_paths_passed' and value['mono_runtime'] and value['unity_version']=='2020.3.33f1' and value['platform']=='WindowsPlayer' and len(value['checks'])==39 and not value['errors'] and not value['working_renderer_claimed'] and not value['constructors_Dispose_or_frame_executed'] and value['end_frame']-value['start_frame']>=2,'All39 actual typed binding/Unity/BCL/safe path witnesses required')
        need({k:value[k] for k in p['expected_binding_counts']}==p['expected_binding_counts'],'Exact actual fresh candidate metadata binding counts')
        text=log.read_text(encoding='utf-8',errors='replace');errors=re.findall(STRICT,text);need(not errors and 'Direct3D:' in text and re.search(r'(?im)^\s*Version:\s*Direct3D 11',text) and 'Renderer: Null Device' not in text,'Whole runtime log strict clear and actual D3D11 device required');integrity()
        report.update(status='actual_original12_initializer_and_prior7_safe_paths_39checks_proved_in_matching_Windows_Mono',runtime_result=pin(result),actual_checks=value['checks'],full_Player_log=pin(log),full_log_error_count=0,actual_D3D11_initialized=True,diagnostic_DLL=pin(dll),diagnostic_PDB=pin(pdb),actual_packaged_candidates=[pin(t) for src,t in replacements],original_player_and_Main_plugins_metas_unchanged=True,all_clone_nonreplacement_files_exact=True)
    except BaseException as e:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(e))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_original12_initializer_and_prior7_safe_paths_39checks_proved_in_matching_Windows_Mono' else 1

def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--plan',type=Path);p.add_argument('--plan-sha256');p.add_argument('--run',action='store_true');a=p.parse_args()
    if a.plan:need(a.plan_sha256,'Explicit reviewed Root plan SHA');return execute(a.plan,a.plan_sha256,a.run)
    need(not a.run and not a.plan_sha256,'Pure preparation first');prepare();return 0

if __name__=='__main__':raise SystemExit(main())
