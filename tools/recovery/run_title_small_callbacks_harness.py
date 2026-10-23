"""Prepare or Root-run two complete small title callbacks and21 controlled effects.

Preparation performs only file/hash checks. Root alone may select --run.
Test-only models never execute production game/Unity/backend callees.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,shutil,uuid
import run_title_login_slice_harness_v3 as base
import run_title_display_callback_harness as prior
from run_title_login_slice_harness_v3 import guard,pin,need,save,check,HERE,WS,ROOT,EDITOR,RESPONSE
SLICE=ROOT/'Validation/TitleSmallCallbacksSlice-20261023T092721Z-f87472a0/report.json'
SLICE_SHA='73cc26342ca361e16597050677df69241f40c65cef5f8a60667818ee964a8e19'
SCHEMA='prepared-original-two-small-title-callbacks-full-binding-effects/v1'
ORIGINAL=ROOT/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll'
ORIGINAL_SHA='15cbc3614b2986da2813cfc82b640199029d8a9b5a60fd8f42db2bdaee7ea9fe'
RUNTIME_APPLY=ROOT/'Validation/SingletonAccessorExactApply-20261023T081036Z-f16f1f39/apply-receipt.json'
RUNTIME_APPLY_SHA='7aa8925add1796efe088c1c858fd751be25a3997f44392df8c87623cd85c69fb'

def runtime_checkpoint():
    return prior.runtime_checkpoint()

def candidate():
    need(pin(SLICE)['sha256']==SLICE_SHA and pin(ORIGINAL)['sha256']==ORIGINAL_SHA,'Frozen complete two-callback proof and exact original attribute-provider metadata');r=json.loads(SLICE.read_bytes())
    need(r['status']=='two_complete_native_bodies_staged_binding_and_effects_pending' and len(r['byte_edits'])==2 and r['complete_native_shapes'][0]['all54_original_bytes_recognized'] and r['complete_native_shapes'][1]['all165_original_bytes_recognized'] and len(r['native_single_byte_negative_controls'])==219 and all(x['rejected'] for x in r['native_single_byte_negative_controls']),'Both original complete scopes and typed control/argument/cast/arithmetic shapes')
    for key in ['source','source_meta','candidate','actual_decoder_receipt','actual_decoded_output','native_join_proof','readable_members','producer']:check(r[key])
    before=Path(r['source']['path']).read_bytes();after=before;spans=[]
    for e in sorted(r['byte_edits'],key=lambda x:x['start'],reverse=True):
        old=base64.b64decode(e['original_base64'],validate=True);new=base64.b64decode(e['replacement_base64'],validate=True);at=e['start'];need(e['length']==len(old) and before[at:at+len(old)]==old,'Only exact original callback stub spans');after=after[:at]+new+after[at+len(old):]
    need(after==Path(r['candidate']['path']).read_bytes(),'All other Main title bytes including prior recovered members preserved');span=Path(r['readable_members']['path']).read_bytes();need(span==b'\r\n'.join(base64.b64decode(x['replacement_base64'],validate=True) for x in r['byte_edits']),'Only both exact unchanged candidate bodies in effects');return r,span

def prepare():
    r,span=candidate();runtime=runtime_checkpoint();out=ROOT/'Validation'/('TitleSmallCallbacksBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    captured=out/'Unity-emitted-WindowsDevelopment-Assembly-CSharp.rsp';shutil.copyfile(RESPONSE,captured);text,inputs=base.response(captured.read_text(encoding='utf-8-sig'),out/'Assembly-CSharp.dll',{r['source']['path'].casefold():Path(r['candidate']['path'])});rsp=out/'full-display-candidate-binding.rsp';rsp.write_text(text,encoding='utf-8',newline='\n');manifest=out/'full-compiler-inputs.json';save(manifest,inputs)
    template=HERE/'TitleSmallCallbacksEffects.template.cs';data=template.read_bytes();need(data.count(b'/*EXACT_ORIGINAL_SMALL_CALLBACKS*/')==1,'One exact unchanged two-method marker');source=out/'ExactDisplayControlledEffects.cs';source.write_bytes(data.replace(b'/*EXACT_ORIGINAL_SMALL_CALLBACKS*/',span))
    refs=[EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'/x for x in ['mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll']]+[WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll'];shutil.copyfile(refs[-1],out/'Mono.Cecil.dll');fx=out/'controlled-effects.rsp';fx.write_text('/nologo\n/nostdlib+\n/target:exe\n/langversion:8.0\n/out:"'+str(out/'ExactDisplayControlledEffects.exe')+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n',encoding='utf-8')
    p={'schema':SCHEMA,'status':'prepared_no_compiler_or_test_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'runtime_checkpoint_helper':pin(Path(prior.__file__)),'original_attribute_provider':pin(ORIGINAL),'slice':pin(SLICE),'current_actual_runtime_checkpoint':runtime,'template':pin(template),'source':pin(source),'captured_Unity_response':pin(captured),'full_response':pin(rsp),'effect_response':pin(fx),'compiler_inputs':pin(manifest),'effect_references':[pin(x) for x in refs],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'full_compile_cap_bytes':1024**3,'helper_and_effect_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'source_count':sum(not x.startswith('/') for x in text.splitlines()),'reference_count':sum(x.startswith('/reference:') for x in text.splitlines()),'exact_candidate_span_sha256':hashlib.sha256(span).hexdigest(),'effect_cases':21,'test_doubles_are_explicitly_test_only':True,'Main_modified':False,'callee_bodies_completed_or_working_boot_claimed':False};need(p['source_count']==5095 and p['reference_count']==409 and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA,'Exact full-source compiler/guard scope');target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed two-callback harness plan SHA');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleSmallCallbacksBindingEffects-'),'Exact isolated small-callback fixture')
    for k in ['runner','base_runner','runtime_checkpoint_helper','original_attribute_provider','slice','template','source','captured_Unity_response','full_response','effect_response','compiler_inputs','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for row in p['effect_references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['base_runner']==pin(Path(base.__file__)) and p['runtime_checkpoint_helper']==pin(Path(prior.__file__)) and p['original_attribute_provider']['sha256']==ORIGINAL_SHA and p['effect_cases']==21 and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA and p['full_compile_cap_bytes']==1024**3 and p['helper_and_effect_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Exact reviewed inputs/owned resource limits');need(runtime_checkpoint()==p['current_actual_runtime_checkpoint'],'Fresh actual current SDK DLL/meta baseline');r,span=candidate();need(hashlib.sha256(span).hexdigest()==p['exact_candidate_span_sha256'],'Exact two original candidate spans');inputs=json.loads(Path(p['compiler_inputs']['path']).read_bytes())
    for x in inputs:check(x)
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected}));return 0
    need(all(not(out/x).exists() for x in ['run-report.json','Assembly-CSharp.dll','ExactDisplayControlledEffects.exe']),'Fresh one-shot Root fixture');report={'schema':'guarded-original-two-small-title-callbacks-full-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Unity_network_or_production_game_code_executed':False,'working_boot_title_login_claimed':False}
    try:
        guard.CAP=p['full_compile_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['full_response']['path']],out,'compile-actual-full-two-small-callback-candidate-file',report);report['full_assembly']=pin(out/'Assembly-CSharp.dll')
        guard.CAP=p['helper_and_effect_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['effect_response']['path']],out,'compile-exact-small-callback-effects-and-reader',report)
        guard.bounded([p['mono']['path'],str(out/'ExactDisplayControlledEffects.exe'),'--inspect',str(out/'Assembly-CSharp.dll'),p['original_attribute_provider']['path']],out,'inspect-two-actual-original-callback-bindings-metadata-only',report)
        guard.bounded([p['mono']['path'],str(out/'ExactDisplayControlledEffects.exe')],out,'twenty-one-exact-small-callback-controlled-effects',report)
        for x in inputs:check(x)
        candidate();need(runtime_checkpoint()==p['current_actual_runtime_checkpoint'],'Actual runtime SDKs remain unchanged after test');report.update(status='actual_full_two_small_callback_bindings_and_twenty_one_controlled_effect_cases_passed',actual_full_file_compiled=True,metadata_binding_verified=True,controlled_effect_cases=21,all_Main_sources_and_selected_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_full_two_small_callback_bindings_and_twenty_one_controlled_effect_cases_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without children');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
