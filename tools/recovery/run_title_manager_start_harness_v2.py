"""Root-only Start reader correction; reuse exact successful full-file compile.

The candidate/effects/count/signature gates are unchanged. Repeated call sites
are selected by ordered Instruction index, never interned MethodReference.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,shutil,uuid
import run_title_manager_start_harness as prior
from run_title_manager_start_harness import base,guard,pin,need,save,check,HERE,WS,ROOT
FAILED=ROOT/'Validation/TitleManagerStartBindingEffects-20261023T080312Z-d8f4e52d/run-report.json'
FAILED_SHA='06c2e213eddc39e30dd676b7f2f9e43ea55032c5d931e7a7d96e1197783ee02a'
SCHEMA='prepared-original-complete-TitleScreenManager-Start-binding-effects/v2'

def previous():
    need(pin(FAILED)['sha256']==FAILED_SHA,'Frozen exact prior fullcompile/reader failure');r=json.loads(FAILED.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes());need(p['schema']==prior.SCHEMA and r['status']=='failed_or_guard_refused_preserve_outputs' and len(r['phases'])==3 and [x['phase'] for x in r['phases']]==['compile-actual-full-Start-candidate-file','compile-exact-Start-controlled-effects-and-reader','inspect-real-Start-binding-metadata-only'] and [x['exit_code'] for x in r['phases']]==[0,0,1] and all(x['owned_child_exit_confirmed'] for x in r['phases']),'Exactly successful real fullcompile then helpercompile and retained reader failure')
    for k in ['runner','base_runner','slice','template','source','captured_Unity_response','full_response','effect_response','compiler_inputs','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for x in p['effect_references']:check(x)
    for x in json.loads(Path(p['compiler_inputs']['path']).read_bytes()):check(x)
    need(p['runner']==pin(Path(prior.__file__)) and p['current_actual_runtime_checkpoint']==prior.runtime_checkpoint(),'Exact unchanged prior runner and actual runtime baseline');check(r['full_assembly']);need(r['full_assembly']['sha256']=='c8deaf5ad47212ffc35dcbad1440b3ea85c17c61dbd365d921cb140c17ea2b19','Actual successful fullassembly output');return r,p

def corrected_template():
    old=HERE/'TitleManagerStartEffects.template.cs';new=HERE/'TitleManagerStartEffects.v2.template.cs';a=old.read_bytes();b=new.read_bytes();before=b'var calls=il.Where(x=>x.OpCode.Code==Code.Call||x.OpCode.Code==Code.Callvirt||x.OpCode.Code==Code.Newobj).Select(x=>(MethodReference)x.Operand).ToArray();';after=b'var callInstructions=il.Where(x=>x.OpCode.Code==Code.Call||x.OpCode.Code==Code.Callvirt||x.OpCode.Code==Code.Newobj).ToArray();var calls=callInstructions.Select(x=>(MethodReference)x.Operand).ToArray();';need(a.count(before)==1 and a.count(b'var at=il.Single(x=>Same(x.Operand,calls[n]));')==2 and a.count(b'il.Single(x=>Same(x.Operand,calls[21])).Next')==1,'Exact prior repeated-call lookup sites');expect=a.replace(before,after).replace(b'var at=il.Single(x=>Same(x.Operand,calls[n]));',b'var at=callInstructions[n];').replace(b'il.Single(x=>Same(x.Operand,calls[21])).Next',b'callInstructions[21].Next');need(b==expect,'Only exact call-instruction selection correction; no gate, candidate or effect change');return new,b

def prepare():
    r,p=previous();slice,span=prior.candidate();template,data=corrected_template();out=ROOT/'Validation'/('TitleManagerStartBindingEffects-v2-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=out/'ExactStartControlledEffects.cs';need(data.count(b'/*EXACT_START_METHOD*/')==1,'Exact untouched Start span marker');source.write_bytes(data.replace(b'/*EXACT_START_METHOD*/',span));shutil.copyfile(p['copied_Cecil']['path'],out/'Mono.Cecil.dll');rsp=out/'controlled-effects.rsp';rsp.write_text('/nologo\n/nostdlib+\n/target:exe\n/langversion:8.0\n/out:"'+str(out/'ExactStartControlledEffects.exe')+'"\n'+''.join('/reference:"'+x['path']+'"\n' for x in p['effect_references'])+'"'+str(source)+'"\n',encoding='utf-8')
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'prior_runner':pin(Path(prior.__file__)),'base_runner':pin(Path(base.__file__)),'prior_failed_receipt':pin(FAILED),'prior_successful_full_compile_plan':r['plan'],'reused_successful_full_assembly':r['full_assembly'],'unchanged_full_compiler_inputs':p['compiler_inputs'],'unchanged_current_runtime':p['current_actual_runtime_checkpoint'],'slice':p['slice'],'exact_candidate_span_sha256':hashlib.sha256(span).hexdigest(),'old_template':p['template'],'new_template':pin(template),'source':pin(source),'effect_response':pin(rsp),'effect_references':p['effect_references'],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':p['compiler'],'mono':p['mono'],'guard':p['guard'],'launcher':p['launcher'],'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'effect_cases':42,'source_count':p['source_count'],'reference_count':p['reference_count'],'full_compile_reused_only_after_exact_all_inputs_rechecked':True,'candidate_or_effect_bytes_changed':False,'Main_modified':False,'production_callees_or_Unity_executed':False};target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed v2 Start plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleManagerStartBindingEffects-v2-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and p['effect_cases']==42,'Exact isolated correction/owned256MiB scope')
    for k in ['runner','prior_runner','base_runner','prior_failed_receipt','prior_successful_full_compile_plan','reused_successful_full_assembly','unchanged_full_compiler_inputs','slice','old_template','new_template','source','effect_response','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for x in p['effect_references']:check(x)
    r,old=previous();slice,span=prior.candidate();template,data=corrected_template();need(p['runner']==pin(Path(__file__)) and p['prior_successful_full_compile_plan']==r['plan'] and p['reused_successful_full_assembly']==r['full_assembly'] and p['unchanged_current_runtime']==prior.runtime_checkpoint() and p['exact_candidate_span_sha256']==hashlib.sha256(span).hexdigest() and Path(p['source']['path']).read_bytes()==data.replace(b'/*EXACT_START_METHOD*/',span),'Exact successful original fullcompile/candidate and reader-only correction')
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':digest}));return 0
    need(not(out/'run-report.json').exists() and not(out/'ExactStartControlledEffects.exe').exists(),'Fresh v2 output, failed prior outputs preserved');report={'schema':'guarded-original-complete-TitleScreenManager-Start-binding-effects/v2','status':'starting','plan':pin(path),'phases':[],'reused_full_compile_receipt':pin(FAILED),'full_assembly':r['full_assembly'],'Main_modified':False,'Unity_network_or_production_game_code_executed':False,'working_boot_title_login_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['effect_response']['path']],out,'compile-corrected-Start-controlled-effects-reader-v2',report);guard.bounded([p['mono']['path'],str(out/'ExactStartControlledEffects.exe'),'--inspect',p['reused_successful_full_assembly']['path']],out,'inspect-real-Start-binding-metadata-only-v2',report);guard.bounded([p['mono']['path'],str(out/'ExactStartControlledEffects.exe')],out,'fortytwo-exact-Start-controlled-effects',report);previous();prior.candidate();report.update(status='actual_full_Start_file_binding_and_fortytwo_controlled_effect_cases_passed',actual_full_file_compiled=True,metadata_binding_verified=True,controlled_effect_cases=42,all_Main_sources_and_selected_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_full_Start_file_binding_and_fortytwo_controlled_effect_cases_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without children');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
