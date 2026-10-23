"""Prepare/verify, or Root-apply precisely four tested existing SDK bodies.

Actual constructor/value evidence is Editor-shipped Windows32 Mono console,
not Windows64 Player. PHJ/JON/private registration never ran; their original
bindings and25 controlled cases passed. No bootstrap activation is performed.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,uuid
import run_windows_development_define_probe as guard
import run_container_provider_value_mono_probe_v2 as probe
HERE=Path(__file__).resolve().parent; WS=HERE.parents[2]; ROOT=WS/'Recovery/RecRoom-2023-04-18'
SCHEMA='reviewed-four-registration-provider-value-bodies-one-SDK-exact-apply/v1'
RUNTIME_PLAN=ROOT/'Validation/ContainerProviderActualMonoValues-v2-20261023T110323Z-09e744e6/plan.json'
RUNTIME_PLAN_SHA='2800a8d634a539a6cd3f510fc897e1f3cd90de43e3b15f723f77de5d7fe0f889'
MEMBERS=[{'owner':'MNALHHOLFGL','name':'PHJOGIEDKPN','current_MethodDef_token':0x06000013},{'owner':'MNALHHOLFGL','name':'JONINBOMMEP','current_MethodDef_token':0x06000017},{'owner':'IKGLJOBBAAC','name':'.ctor','current_MethodDef_token':0x06000084},{'owner':'PLIPHMBIGMM','name':'.ctor','current_MethodDef_token':0x06000057}]
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:h=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':h}
def check(row):need(pin(row['path'])==row,'Pinned four-body apply input changed: '+row['path'])
def durable(path,data):
    with path.open('xb') as f:f.write(data);f.flush();os.fsync(f.fileno())
def save(path,value):durable(path,(json.dumps(value,indent=2)+'\n').encode('utf-8'))

def proof(path,digest):
    path=path.resolve(strict=True);need(path==RUNTIME_PLAN.parent/'run-report.json' and pin(path)['sha256']==digest and pin(RUNTIME_PLAN)['sha256']==RUNTIME_PLAN_SHA,'Exact successful rawSDK console proof and frozen plan');r=json.loads(path.read_bytes());p=json.loads(RUNTIME_PLAN.read_bytes());need(r['plan']==pin(RUNTIME_PLAN),'Only exact reviewed console plan');check(r['plan'])
    need(r['schema']=='guarded-actual-original-provider-constructor-Windows32-Mono-console-values/v2' and r['status']=='actual_matching_Editor_shipped_Windows32_Mono_console_original_ctor_chain_and_22_value_observations_passed' and r['checks']==22 and r['actual_original_SDK_constructor_bodies_executed'] and r['original_base_ctor_CIL_unchanged'] and r['Main_plugin_and_meta_unchanged'] and not r['Main_modified'] and not r['Unity_or_Player_launched'] and not r['production_registration_lookup_retrieval_injection_callbacks_executed'] and not r['working_provider_registration_or_client_claimed'],'Actual scoped console execution passed with honest architecture/client boundaries')
    need([x['phase'] for x in r['phases']]==['compile-reflection-only-console-probe','actual-matching-Windows32-Mono-original-ctor-value-observation'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] and x['cap_bytes']==256*1024**2 for x in r['phases']),'Both actual bounded compile/console phases passed and exited')
    for k in ['actual_runtime_result','compiled_probe','actual_framework']:check(r[k])
    observed=json.loads(Path(r['actual_runtime_result']['path']).read_bytes());need(observed['schema']=='actual-matching-Windows32-Mono-console-original-provider-ctor-values/v2' and observed['status']=='actual_original_constructor_chain_and_value_retention_passed' and observed['host_pointer_bytes']==4 and observed['host_platform']=='Win32NT' and observed['host_Mono_Runtime_type_present'] and observed['execution_host']=='matching Editor-shipped Windows32 Mono console; not Windows64 Unity Player' and observed['actual_SDK_constructor_bodies_executed'] and observed['executed_original_constructor_MethodDefs']==['0x06000084','0x06000083','0x06000057','0x0600005c'] and len(observed['checks'])==len(set(observed['checks']))==22 and observed['exception'] is None and not observed['production_registration_lookup_retrieval_injection_callbacks_executed'] and not observed['working_client_or_registration_claimed'],'Exact22 actual rawfield/ctor observations; only four constructor MethodDefs executed')
    need(p['runner']==pin(Path(probe.__file__)),'Exact reviewed console helper');probe.execute(RUNTIME_PLAN,RUNTIME_PLAN_SHA,False)
    stage,result,stageplan=probe.stage();need(p['candidate']==result['candidate'] and p['owned_candidate']['sha256']==result['candidate']['sha256'] and r['actual_runtime_result']['path']==p['runtime_result'] and observed['SDK_mvid']==p['SDK_initializer_audit']['MVID'] and Path(observed['SDK_location']).resolve()==Path(p['owned_candidate']['path']),'Actual SDK was precisely the four-body candidate')
    source=stageplan['current_Main_plugin'];meta=stageplan['current_Main_meta'];need(Path(source['path'])==WS/'RR23/Assets/Plugins/UJect.Runtime.dll' and meta['path']==source['path']+'.meta' and source['sha256']=='9997b88de8261636419c1a9354fd768d8b3b7618ec193d62349908477ba1d170' and meta['sha256']=='1c3aec244b704c63992053639096f1834d12f9377ebfb0ed399a31e5b6cfead3','One exact current Main SDK/importer target')
    prior=json.loads(Path(stageplan['registration3_result']['path']).read_bytes());module=prior['modules'][0];need(module['selected_original_members']==MEMBERS[:3] and result['selected_original_MethodDef']==MEMBERS[3]['current_MethodDef_token'] and result['original']==module['candidate'] and module['original']==source and result['changed_in_this_stage']==1 and result['combined_changed_bodies']==4 and result['original_metadata_fingerprint']==module['metadata_fingerprint'] and result['original_features_fingerprint']==module['module_features_fingerprint'] and module['all_other_method_bodies_unchanged']==134 and result['all_other_method_bodies_preserved']==136,'Exact3+1 body union and unchanged metadata across both actual readbacks')
    from stage_container_registration_and_value_constructor import raw_empty_bases
    need(raw_empty_bases(source['path'])==raw_empty_bases(result['candidate']['path'])==stageplan['already_correct_empty_bases_raw_CIL'],'Original NPIL83/JEM5c seven-byte CIL remain identical and unselected')
    sources=[stageplan['ctor_donor_source']];threeplan=json.loads(Path(stageplan['registration3_stage_plan']['path']).read_bytes());sources.append(threeplan['reviewable_donor_source']);need(len({x['path'] for x in sources})==len(sources),'Unique actual recovered donor source files')
    for x in sources:check(x)
    row={'source':source,'meta':meta,'candidate':result['candidate'],'changed_members':MEMBERS,'unchanged_original_empty_ctor_CIL':stageplan['already_correct_empty_bases_raw_CIL'],'original_metadata_fingerprint':result['original_metadata_fingerprint'],'original_module_features_fingerprint':result['original_features_fingerprint'],'unchanged_other_method_bodies':133,'original_runtime_type_names_and_tokens_preserved':True}
    return r,p,stage,result,row,sources

def prepare(runtime,digest):
    r,rp,stage,result,row,sources=proof(runtime,digest);out=ROOT/'Validation'/('ContainerRegistrationValueExactApply-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    p={'schema':SCHEMA,'status':'prepared_Main_not_modified','fixture':str(out),'runner':pin(Path(__file__)),'console_validation_helper':pin(Path(probe.__file__)),'successful_actual_console_receipt':pin(runtime),'successful_actual_console_plan':r['plan'],'body_stage_receipt':rp['stage_receipt'],'body_stage_plan':stage['plan'],'body_semantic_report':stage['result'],'rows':[row],'readable_recovered_CSharp_sources':sources,'only_Main_writes':'one exact UJect.Runtime.dll replacement; no source/meta/settings/other SDK write','metadata_contract':'All original names, tokens, arity, fields, method declarations, references, features and133 unselected bodies preserved. No runtime metadata renaming or AssemblyRef addition.','actual_runtime_scope':'Editor-shipped Windows32 Mono console executes IKGL84/NPIL83/PLIPH57/JEM5c and reads exact readonly fields. This is not Windows64 Player proof. PHJ/JON/private registration/retrieval/injection/provider callback bodies were not executed.','registration_binding_effects':'Actual original-owner bindings and25 controlled cases passed; held private registration remains unexecuted.','two_already_correct_empty_base_bodies_rewritten':False,'working_startup_login_or_dorm_claimed':False,'higher_bootstrap_activation_performed':False,'Main_modified':False};target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_apply_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--apply']}))

def execute(path,digest,apply):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed4body oneSDK apply plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerRegistrationValueExactApply-') and not p['two_already_correct_empty_base_bodies_rewritten'] and not p['higher_bootstrap_activation_performed'],'Exact isolated apply scope, no bootstrap or base rewrite')
    for k in ['runner','console_validation_helper','successful_actual_console_receipt','successful_actual_console_plan','body_stage_receipt','body_stage_plan','body_semantic_report']:check(p[k])
    need(p['runner']==pin(Path(__file__)) and p['console_validation_helper']==pin(Path(probe.__file__)),'Exact reviewed apply and proof helpers');r,rp,stage,result,row,sources=proof(Path(p['successful_actual_console_receipt']['path']),p['successful_actual_console_receipt']['sha256']);need(p['rows']==[row] and p['readable_recovered_CSharp_sources']==sources and p['successful_actual_console_plan']==r['plan'] and p['body_stage_receipt']==rp['stage_receipt'] and p['body_stage_plan']==stage['plan'] and p['body_semantic_report']==stage['result'],'Exact candidate/meta/body union and actual proof lineage')
    if not apply:print(json.dumps({'status':'verified_no_Main_write','plan_sha256':digest}));return 0
    guard.safety.assert_editor_closed();need(not(out/'apply-receipt.json').exists() and not(out/'journal.jsonl').exists() and not(out/'Backup').exists(),'Fresh one-shot exact apply; no automatic retry')
    report={'schema':SCHEMA,'status':'starting','plan':pin(path),'Main_modified':False,'applied':[],'metas_unchanged':False,'higher_bootstrap_activated':False,'working_startup_login_or_dorm_claimed':False,'Windows64_Player_proof_claimed':False,'registration_runtime_proved':False}
    def journal(event):
        with(out/'journal.jsonl').open('ab') as f:f.write((json.dumps({'utc':dt.datetime.now(dt.timezone.utc).isoformat(),**event})+'\n').encode());f.flush();os.fsync(f.fileno())
    try:
        for k in ['source','meta','candidate']:check(row[k])
        backup=out/'Backup';backup.mkdir();source=Path(row['source']['path']);meta=Path(row['meta']['path']);bf=backup/source.name;bm=backup/meta.name;temp=out/'pending-UJect.Runtime.dll'
        durable(bf,source.read_bytes());durable(bm,meta.read_bytes());durable(temp,Path(row['candidate']['path']).read_bytes());need(pin(bf)['sha256']==row['source']['sha256'] and pin(bm)['sha256']==row['meta']['sha256'] and pin(temp)['sha256']==row['candidate']['sha256'],'All durable originals/metas/candidate verify before any Main write');report['backups']=[{'DLL':pin(bf),'meta':pin(bm)}];journal({'event':'all_original_DLL_and_meta_backups_verified_before_any_Main_write'})
        check(row['source']);check(row['meta']);check(row['candidate']);journal({'event':'replace_intent','source':str(source),'before_sha256':row['source']['sha256'],'after_sha256':row['candidate']['sha256']});os.replace(temp,source);report['Main_modified']=True
        need(pin(source)['sha256']==row['candidate']['sha256'],'Exact staged4body candidate after replacement');check(row['meta']);need(source.read_bytes()==Path(row['candidate']['path']).read_bytes() and meta.read_bytes()==bm.read_bytes(),'Exact candidate DLL and unchanged original meta bytes');report['applied'].append({'source':pin(source),'meta':pin(meta),'changed_members':MEMBERS});journal({'event':'replace_verified','source':str(source),'sha256':pin(source)['sha256']})
        report.update(status='four_tested_registration_provider_value_bodies_applied_one_SDK_meta_preserved',metas_unchanged=True,changed_method_bodies=4,all_other_bodies_and_all_original_semantic_metadata_retained=True,two_original_empty_base_ctor_CIL_byte_identical=True)
    except BaseException as error:report.update(status='partial_or_failed_HOLD_no_automatic_reapply' if report['Main_modified'] else 'failed_Main_not_modified',error=repr(error));journal({'event':'HOLD','status':report['status']})
    finally:save(out/'apply-receipt.json',report)
    print(json.dumps({'status':report['status'],'receipt':pin(out/'apply-receipt.json'),'Main_modified':report['Main_modified'],'error':report.get('error')}));return 0 if report['status']=='four_tested_registration_provider_value_bodies_applied_one_SDK_meta_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--runtime-report',type=Path);a.add_argument('--runtime-report-sha256');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--apply',action='store_true');v=a.parse_args()
    if v.runtime_report:need(v.runtime_report_sha256 and not v.plan and not v.apply,'Prepare only after exact actual scoped Mono pass');prepare(v.runtime_report.resolve(strict=True),v.runtime_report_sha256);return 0
    need(v.plan and v.plan_sha256,'Explicit reviewed apply plan required');return execute(v.plan,v.plan_sha256,v.apply)
if __name__=='__main__':raise SystemExit(main())
