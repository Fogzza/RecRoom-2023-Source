"""Prepare or Root-run complete Start real binding +42 controlled effects.

Preparation performs only file/hash checks. Root alone may select --run.
Test-only models never execute production game/Unity/backend callees.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,shutil,uuid
import run_title_login_slice_harness_v3 as base
from run_title_login_slice_harness_v3 import guard,pin,need,save,check,HERE,WS,ROOT,EDITOR,RESPONSE
SLICE=ROOT/'Validation/TitleManagerStartSlice-20261023T075610Z-ecc62627/report.json'
SLICE_SHA='006ddbafca9bf64cd988f752fa960d1517f8c915a26150e8d19d2fcc118d81e4'
SCHEMA='prepared-original-complete-TitleScreenManager-Start-binding-effects/v1'
RUNTIME_APPLY=ROOT/'Validation/StartupThreeMemberExactApply-20261023T075506Z-0cb9bede/apply-receipt.json'
RUNTIME_APPLY_SHA='686b35bc95bc1a1659f020650f08d63a6b0fd4f5244f46aa6263547352f10756'

def runtime_checkpoint():
    need(pin(RUNTIME_APPLY)['sha256']==RUNTIME_APPLY_SHA,'Root actual three-body SDK application receipt');p=json.loads(RUNTIME_APPLY.read_bytes());need(p['status']=='three_tested_original_startup_bodies_applied_two_SDKs_metas_preserved' and len(p['applied'])==2,'Exactly current reviewed two-SDK baseline')
    for row in p['applied']:check(row['source']);check(row['meta'])
    return {'receipt':pin(RUNTIME_APPLY),'modules':[{'DLL':x['source'],'meta':x['meta']} for x in p['applied']],'scope_note':'Actual current runtime DLLs are pinned separately. The unchanged genuine Unity-emitted response binds original projected CompilerSupport API references; no runtime DLL body is invoked by this harness.'}

def candidate():
    need(pin(SLICE)['sha256']==SLICE_SHA,'Frozen complete original1053B caller proof');r=json.loads(SLICE.read_bytes())
    need(r['native_shape']['all1053bytes_checked'] and r['native_shape']['all_original_CFG_edges_checked'] and r['typed_joins']['all_touched_fields_and_application_targets_bound'],'Entire original caller closed and typed')
    for k in ['source','source_meta','candidate','actual_decoder_receipt','complete_native_typed_inventory','dispatch_and_UI_field_inventory']:check(r[k])
    e=r['byte_edit'];before=Path(r['source']['path']).read_bytes();after=Path(r['candidate']['path']).read_bytes();old=base64.b64decode(e['original_base64'],validate=True);new=base64.b64decode(e['replacement_base64'],validate=True);at=e['start'];need(e['length']==len(old) and before[at:at+len(old)]==old and after==before[:at]+new+before[at+len(old):] and b'private void Start()' in new,'Only exact original Start span replaced; current Awake/UI bytes preserved');return r,new

def prepare():
    r,span=candidate();runtime=runtime_checkpoint();out=ROOT/'Validation'/('TitleManagerStartBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    captured=out/'Unity-emitted-WindowsDevelopment-Assembly-CSharp.rsp';shutil.copyfile(RESPONSE,captured);text,inputs=base.response(captured.read_text(encoding='utf-8-sig'),out/'Assembly-CSharp.dll',{r['source']['path'].casefold():Path(r['candidate']['path'])});rsp=out/'full-Start-candidate-binding.rsp';rsp.write_text(text,encoding='utf-8',newline='\n');manifest=out/'full-compiler-inputs.json';save(manifest,inputs)
    template=HERE/'TitleManagerStartEffects.template.cs';data=template.read_bytes();need(data.count(b'/*EXACT_START_METHOD*/')==1,'One exact unchanged Start method marker');source=out/'ExactStartControlledEffects.cs';source.write_bytes(data.replace(b'/*EXACT_START_METHOD*/',span))
    refs=[EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'/x for x in ['mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll']]+[WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll'];shutil.copyfile(refs[-1],out/'Mono.Cecil.dll');fx=out/'controlled-effects.rsp';fx.write_text('/nologo\n/nostdlib+\n/target:exe\n/langversion:8.0\n/out:"'+str(out/'ExactStartControlledEffects.exe')+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n',encoding='utf-8')
    p={'schema':SCHEMA,'status':'prepared_no_compiler_or_test_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'slice':pin(SLICE),'current_actual_runtime_checkpoint':runtime,'template':pin(template),'source':pin(source),'captured_Unity_response':pin(captured),'full_response':pin(rsp),'effect_response':pin(fx),'compiler_inputs':pin(manifest),'effect_references':[pin(x) for x in refs],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'full_compile_cap_bytes':1024**3,'helper_and_effect_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'source_count':sum(not x.startswith('/') for x in text.splitlines()),'reference_count':sum(x.startswith('/reference:') for x in text.splitlines()),'exact_candidate_span_sha256':hashlib.sha256(span).hexdigest(),'effect_cases':42,'test_doubles_are_explicitly_test_only':True,'Main_modified':False,'callee_bodies_completed_or_working_boot_claimed':False};need(p['source_count']==5095 and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA,'Exact full-source compiler/guard scope');target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed Start harness plan SHA');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleManagerStartBindingEffects-'),'Exact isolated Start fixture')
    for k in ['runner','base_runner','slice','template','source','captured_Unity_response','full_response','effect_response','compiler_inputs','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for row in p['effect_references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['base_runner']==pin(Path(base.__file__)) and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA and p['full_compile_cap_bytes']==1024**3 and p['helper_and_effect_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Exact reviewed inputs/owned resource limits');need(runtime_checkpoint()==p['current_actual_runtime_checkpoint'],'Fresh actual current two-SDK DLL/meta baseline');r,span=candidate();need(hashlib.sha256(span).hexdigest()==p['exact_candidate_span_sha256'],'Exact original Start source span');inputs=json.loads(Path(p['compiler_inputs']['path']).read_bytes())
    for x in inputs:check(x)
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected}));return 0
    need(all(not(out/x).exists() for x in ['run-report.json','Assembly-CSharp.dll','ExactStartControlledEffects.exe']),'Fresh one-shot Root fixture');report={'schema':'guarded-original-complete-TitleScreenManager-Start-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Unity_network_or_production_game_code_executed':False,'working_boot_title_login_claimed':False}
    try:
        guard.CAP=p['full_compile_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['full_response']['path']],out,'compile-actual-full-Start-candidate-file',report);report['full_assembly']=pin(out/'Assembly-CSharp.dll')
        guard.CAP=p['helper_and_effect_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['effect_response']['path']],out,'compile-exact-Start-controlled-effects-and-reader',report)
        guard.bounded([p['mono']['path'],str(out/'ExactStartControlledEffects.exe'),'--inspect',str(out/'Assembly-CSharp.dll')],out,'inspect-real-Start-binding-metadata-only',report)
        guard.bounded([p['mono']['path'],str(out/'ExactStartControlledEffects.exe')],out,'fortytwo-exact-Start-controlled-effects',report)
        for x in inputs:check(x)
        candidate();need(runtime_checkpoint()==p['current_actual_runtime_checkpoint'],'Actual runtime SDKs remain unchanged after test');report.update(status='actual_full_Start_file_binding_and_fortytwo_controlled_effect_cases_passed',actual_full_file_compiled=True,metadata_binding_verified=True,controlled_effect_cases=42,all_Main_sources_and_selected_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_full_Start_file_binding_and_fortytwo_controlled_effect_cases_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without children');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
