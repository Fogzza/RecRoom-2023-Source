"""Prepare or Root-run complete Awake actual binding +20 controlled effects.

No Main writes or production callees run. Native base/delegate/field/call proof
is retained independently of the separately controlled effect-model harness.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,shutil,uuid
import run_title_login_slice_harness_v3 as base
from run_title_login_slice_harness_v3 import guard,pin,need,save,check,HERE,WS,ROOT,EDITOR,RESPONSE
SLICE=ROOT/'Validation/TitleManagerAwakeSlice-20261023T072530Z-d1d2fdf4/report.json'
SLICE_SHA='cc2bc61d61fbcb6f0a077b91dc9c9ca1b046f4f320016be2e238c7d6cb9b9dc5'
BASE_PROOF=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207/SingletonDisposedMembers-20261023T065855Z-c81ffded/report.json'
BASE_PROOF_SHA='a073ef5183c9d554509ae16689595bcb7981627e4328a50c7682d4c5c131b48a'
SCHEMA='prepared-original-complete-TitleScreenManager-Awake-binding-effects/v1'
def candidate():
    need(pin(SLICE)['sha256']==SLICE_SHA and pin(BASE_PROOF)['sha256']==BASE_PROOF_SHA,'Exact closed original Awake caller and native base dependency proofs')
    r=json.loads(SLICE.read_bytes());need(r['complete_native_shape']['all556bytes_checked'] and r['complete_native_shape']['all_hot_cold_CFG_edges_closed'] and r['typed_callee_field_proof']['all_original_application_targets_bound'],'Entire original caller must be closed and typed')
    for k in ['source','source_meta','candidate','current_UIFlowModel_checkpoint','actual_decoder_receipt','genuine_chain_input','typed_evidence']:check(r[k])
    e=r['byte_edit'];before=Path(r['source']['path']).read_bytes();after=Path(r['candidate']['path']).read_bytes();old=base64.b64decode(e['original_base64'],validate=True);new=base64.b64decode(e['replacement_base64'],validate=True);at=e['start']
    need(e['length']==len(old) and before[at:at+len(old)]==old and after==before[:at]+new+before[at+len(old):] and b'protected override void Awake()' in new,'Exactly one original full Awake span, all other current UI bytes retained')
    return r,new
def prepare():
    r,span=candidate();out=ROOT/'Validation'/('TitleManagerAwakeBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    captured=out/'Unity-emitted-WindowsDevelopment-Assembly-CSharp.rsp';shutil.copyfile(RESPONSE,captured)
    text,inputs=base.response(captured.read_text(encoding='utf-8-sig'),out/'Assembly-CSharp.dll',{r['source']['path'].casefold():Path(r['candidate']['path'])});rsp=out/'full-Awake-candidate-binding.rsp';rsp.write_text(text,encoding='utf-8',newline='\n');manifest=out/'full-compiler-inputs.json';save(manifest,inputs)
    template=HERE/'TitleManagerAwakeEffects.template.cs';data=template.read_bytes();need(data.count(b'/*EXACT_AWAKE_METHOD*/')==1,'Unique exact candidate method marker');source=out/'ExactAwakeControlledEffects.cs';source.write_bytes(data.replace(b'/*EXACT_AWAKE_METHOD*/',span))
    refs=[EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'/x for x in ['mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll']]+[WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll'];shutil.copyfile(refs[-1],out/'Mono.Cecil.dll')
    fx=out/'controlled-effects.rsp';fx.write_text('/nologo\n/nostdlib+\n/target:exe\n/langversion:8.0\n/out:"'+str(out/'ExactAwakeControlledEffects.exe')+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n',encoding='utf-8')
    sdk=[x for x in inputs if Path(x['path']).name=='RecRoom.AgInitialization.Runtime.dll'];need(len(sdk)==1,'Actual compiler property-alias reference')
    p={'schema':SCHEMA,'status':'prepared_no_compiler_or_test_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'slice':pin(SLICE),'base_Awake_native_dependency_proof':pin(BASE_PROOF),'native_dependency_scope_note':'Exact original SingletonMonoBehaviour<T>.Awake body is separately proved; this title caller uses MethodSpec306409<TitleScreenManager> mapped to the same18333e400. This harness tests caller effects with a controlled base and does not claim base Unity lifecycle or service completion.','template':pin(template),'source':pin(source),'captured_Unity_response':pin(captured),'full_response':pin(rsp),'effect_response':pin(fx),'compiler_inputs':pin(manifest),'effect_references':[pin(x) for x in refs],'SDK_property_alias_reference':sdk[0],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'full_compile_cap_bytes':1024**3,'helper_and_effect_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'source_count':sum(not x.startswith('/') for x in text.splitlines()),'reference_count':sum(x.startswith('/reference:') for x in text.splitlines()),'exact_candidate_span_sha256':hashlib.sha256(span).hexdigest(),'effect_cases':20,'test_doubles_are_explicitly_test_only':True,'Main_modified':False,'callee_bodies_completed_or_working_boot_claimed':False}
    need(p['source_count']==5095 and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA,'Exact full compile and owned guard scope')
    target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed complete Awake harness SHA');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleManagerAwakeBindingEffects-'),'Exact isolated complete Awake fixture')
    for k in ['runner','base_runner','slice','base_Awake_native_dependency_proof','template','source','captured_Unity_response','full_response','effect_response','compiler_inputs','SDK_property_alias_reference','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for row in p['effect_references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['base_runner']==pin(Path(base.__file__)) and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA and p['full_compile_cap_bytes']==1024**3 and p['helper_and_effect_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Exact reviewed inputs/owned resource scope')
    r,span=candidate();need(hashlib.sha256(span).hexdigest()==p['exact_candidate_span_sha256'],'Exact candidate method bytes');inputs=json.loads(Path(p['compiler_inputs']['path']).read_bytes())
    for x in inputs:check(x)
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected}));return 0
    need(all(not(out/x).exists() for x in ['run-report.json','Assembly-CSharp.dll','ExactAwakeControlledEffects.exe']),'Fresh one-shot complete Awake fixture')
    report={'schema':'guarded-original-complete-TitleScreenManager-Awake-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Unity_network_or_production_game_code_executed':False,'working_boot_title_login_claimed':False}
    try:
        guard.CAP=p['full_compile_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['full_response']['path']],out,'compile-actual-full-Awake-candidate-file',report);report['full_assembly']=pin(out/'Assembly-CSharp.dll')
        guard.CAP=p['helper_and_effect_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['effect_response']['path']],out,'compile-exact-Awake-controlled-effects-and-reader',report)
        guard.bounded([p['mono']['path'],str(out/'ExactAwakeControlledEffects.exe'),'--inspect',str(out/'Assembly-CSharp.dll'),p['SDK_property_alias_reference']['path']],out,'inspect-real-Awake-binding-metadata-only',report)
        guard.bounded([p['mono']['path'],str(out/'ExactAwakeControlledEffects.exe')],out,'twenty-exact-Awake-controlled-effects',report)
        for x in inputs:check(x)
        candidate();report.update(status='actual_full_Awake_file_binding_and_twenty_controlled_effect_cases_passed',actual_full_file_compiled=True,metadata_binding_verified=True,controlled_effect_cases=20,all_Main_sources_and_selected_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_full_Awake_file_binding_and_twenty_controlled_effect_cases_passed' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed complete Awake plan required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without starting children');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
