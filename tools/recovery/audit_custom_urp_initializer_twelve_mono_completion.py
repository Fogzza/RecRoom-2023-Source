"""Pure completion audit of the already-executed S12 cloned Mono smoke.

Does not rerun any child, alter the original interim run-report, change a
player/SDK/Main file or repair the frozen runner. Writes only a new receipt.
"""
from pathlib import Path
import argparse, copy, datetime as dt, json, re
import run_custom_urp_initializer_twelve_mono_smoke as smoke

pin=smoke.pin;check=smoke.check;need=smoke.need;save=smoke.save
FIXTURE=smoke.ROOT/'Validation/CustomUrpInitializerTwelveClonedMonoSmoke-20261023T110256Z-e078ab43'
PLAN_SHA='80ff33d86efedb91718584c35da28546b9083d46459812a9be2c286aadb5aebb'
SUCCESS='actual_original12_initializer_and_prior7_safe_paths_39checks_independently_completed_after_wrapper_finalizer_failure'

def observations(p,r,o):
    need(r['schema']=='guarded-actual-original-custom-URP-initializer12-plus-seven-cloned-Mono-smoke/v1' and r['status']=='starting' and r['plan']==pin(FIXTURE/'plan.json') and not r['Main_modified'] and not r['Editor_launched'] and not r['working_renderer_claimed'],'Preserved original interim status; never claim original runner completed')
    phases=r['phases'];need([x['phase'] for x in phases]==['compile-clone-only-actual12-plus-seven-diagnostic','actual-cloned-Windows-Mono-initializer12-plus-seven-safe-player'],'Exactly actual compiler and player, no Editor phase')
    for index,phase in enumerate(phases):
        need(phase['exit_code']==0 and phase['owned_cli_or_compiler_exit_confirmed'] and phase['cap_bytes']==[smoke.COMPILE_CAP,smoke.CAP][index] and phase['reserve_bytes']==p['reserve_bytes'] and phase['maximum_seconds']==[90,60][index] and 0<phase['seconds']<=[90,60][index],'Exact successful owned child exit/resource/deadline')
        launch=phase['launcher'];need(launch['resumed'] and launch['membership_verified_before_resume'] and launch['creation_flags']==134217732 and launch['owned_pid']==launch['opened_thread_owner_pid'] and launch['owned_pid']>0 and launch['primary_thread_id']>0 and launch['resume_previous_suspend_count']==1 and launch['primary_thread_handle_closed'],'Actual owned assign-before-resume launch with exact thread ownership')
        need(launch['events']==['created_suspended','assigned_to_owned_job_while_suspended','exact_job_membership_verified_before_resume','primary_thread_resumed'],'Exact mandatory launch order')
        need(phase['samples'] and all(x['available_commit_bytes']>=p['reserve_bytes'] and x['peak_job_bytes']<=phase['cap_bytes'] and x['peak_process_bytes']<=phase['cap_bytes'] for x in phase['samples']),'Retained actual bounded samples and reserve')
    need(o['schema']=='actual-original-custom-URP-initializer12-plus-seven-Mono-binding-smoke/v1' and o['status']=='actual_original_URP_initializer12_and_safe_seven_body_paths_passed' and o['mono_runtime'] and o['unity_version']=='2020.3.33f1' and o['platform']=='WindowsPlayer' and len(o['checks'])==39 and len(set(o['checks']))==39 and not o['errors'] and not o['working_renderer_claimed'] and not o['constructors_Dispose_or_frame_executed'] and o['end_frame']-o['start_frame']>=2,'All39 actual checks and honest inactive-renderer boundary')
    need({k:o[k] for k in p['expected_binding_counts']}==p['expected_binding_counts'],'Actual full Core+URP emitted-token binding counts')
    for name,field in [('Core','core_declared_assembly_references'),('URP','declared_assembly_references')]:
        expected=json.loads(Path(next(x['path'] for x in p['binding_manifests'] if Path(x['path']).name.startswith(name+'-'))).read_bytes());need(o[field]==expected['referenced_assemblies'],'Actual exact declared '+name+' full references and order')

def controls(p,r,o):
    observations(p,r,o);cases=['actual_two_successful_owned_phases_and39_runtime_checks_admitted']
    mutations=[('nonzero_child_exit',lambda a,b:a['phases'][1].update(exit_code=1)),('missing_owned_exit_confirmation',lambda a,b:a['phases'][1].update(owned_cli_or_compiler_exit_confirmed=False)),('unverified_membership',lambda a,b:a['phases'][1]['launcher'].update(membership_verified_before_resume=False)),('wrong_thread_owner',lambda a,b:a['phases'][1]['launcher'].update(opened_thread_owner_pid=-1)),('wrong_job_cap',lambda a,b:a['phases'][1].update(cap_bytes=smoke.CAP*2)),('wrong_launch_order',lambda a,b:a['phases'][1]['launcher']['events'].reverse()),('runtime_failed',lambda a,b:b.update(status='failed')),('missing_check',lambda a,b:b['checks'].pop()),('runtime_errors',lambda a,b:b['errors'].append('test error')),('wrong_Core_binding',lambda a,b:b.update(core_methods=1694)),('wrong_URP_binding',lambda a,b:b.update(added_method_refs=11)),('wrong_declared_scope',lambda a,b:b['core_declared_assembly_references'].__setitem__(0,'wrong full scope'))]
    for name,mutate in mutations:
        a,b=copy.deepcopy(r),copy.deepcopy(o);mutate(a,b)
        try:observations(p,a,b)
        except (ValueError,KeyError):cases.append(name+'_refused')
        else:raise ValueError('Completion negative control accepted '+name)
    return {'schema':'pure-actual12-Mono-completion-admission-controls/v1','status':'passed','controls':len(cases),'cases':cases,'children_launched':False}

def audit():
    need(pin(FIXTURE/'plan.json')['sha256']==PLAN_SHA,'Exact reviewed existing clone plan');p,out=smoke.verify(FIXTURE/'plan.json',PLAN_SHA);need(out==FIXTURE,'One frozen actual fixture only')
    interim=out/'run-report.json';runtime=out/'runtime-result.json';log=out/'Player.log';r=json.loads(interim.read_bytes());o=json.loads(runtime.read_bytes());test=controls(p,r,o)
    compiler_command=[p['compiler']['path'],'/noconfig','@'+p['response']['path']];need(r['phases'][0]['command']==compiler_command,'Exact pinned diagnostic compiler command')
    clone=out/'PlayerClone';player=clone/Path(p['source_player']['path']).name;core,urp=p['binding_manifests'];expected_command=[player.as_posix(),'-batchmode','-force-d3d11','-screen-fullscreen','0','-screen-width','64','-screen-height','64','-urpSmokeResult',runtime.as_posix(),'-urpSmokeBindingExpected',Path(urp['path']).as_posix(),'-urpSmokeCoreBindingExpected',Path(core['path']).as_posix(),'-logFile',log.as_posix()];need(r['phases'][1]['command']==expected_command,'Exact genuine cloned player command and external manifests')
    compile_text=(out/'compile-clone-only-actual12-plus-seven-diagnostic-stderr.log').read_text(encoding='utf-8',errors='replace')+(out/'compile-clone-only-actual12-plus-seven-diagnostic-stdout.log').read_text(encoding='utf-8',errors='replace');need(not re.findall(smoke.STRICT,compile_text),'Whole actual compiler logs strict clear')
    text=log.read_text(encoding='utf-8',errors='replace');need(not re.findall(smoke.STRICT,text) and 'Direct3D:' in text and re.search(r'(?im)^\s*Version:\s*Direct3D 11',text) and 'Renderer: Null Device' not in text,'Whole actual player log strict clear and genuine D3D11 initialized')
    dll=Path(p['runtime_output']);pdb=Path(p['runtime_pdb_output']);need(smoke.raw.Model(dll).r.asm==p['expected_runtime_identity'],'Exact registered diagnostic assembly identity')
    candidate_by_name={Path(x['path']).name:x for x in p['candidates']};replacements={p['diagnostic_relative_path']:pin(dll),str(Path(p['diagnostic_relative_path']).with_suffix('.pdb')).replace('\\','/'):pin(pdb)}
    replacements.update({'CustomUrpSevenBodyMonoSmoke_Data/Managed/'+name:row for name,row in candidate_by_name.items()});need(set(replacements)==set(p['allowed_clone_replacements']),'Exactly four approved replacements')
    immutable=[];changed=[]
    for row in p['source_player_files']:
        check(row['pin']);target=clone/row['relative'];need(target.resolve().is_relative_to(clone.resolve()),'Exact owned clone file');actual=pin(target);expected=replacements.get(row['relative'],row['pin']);need(actual['bytes']==expected['bytes'] and actual['sha256']==expected['sha256'],'Every cloned source byte outside the exact four replacements is unchanged')
        (changed if row['relative'] in replacements else immutable).append({'relative':row['relative'],'source':row['pin'],'actual':actual})
    need(len(changed)==4,'All four actual replacements accounted for')
    stage_plan=json.loads(Path(p['stage_plan']['path']).read_bytes());check(stage_plan['Main_URP_unchanged'])
    for module in p['stage_modules']:check(module['original']);check(module['meta'])
    # Recreate expected binding records from actual staged bytes. URP includes
    # all original six imported refs plus the six new original12 operands.
    for name,candidate,authority,counts in [('Core',candidate_by_name[stage.CORE+'.dll'],smoke.WS/'RR23/Assets/Plugins/Unity.RenderPipelines.Core.Runtime.dll',(278,897,1695,1)),('URP',candidate_by_name[stage.URP+'.dll'],smoke.raw.ORIGINAL,(298,2015,1616,12))]:
        manifest=Path(next(x['path'] for x in p['binding_manifests'] if Path(x['path']).name.startswith(name+'-')));need(json.loads(manifest.read_bytes())==smoke.manifest(Path(candidate['path']),authority,counts),'Every expected actual emitted binding record derived from immutable candidate bytes')
    old=json.loads(Path(p['prior_runtime_result']['path']).read_bytes())['checks'];new=o['checks'];old_ref='six_genuine_Unity_BCL_imported_operands_resolved_without_invocation';new_ref='twelve_genuine_Unity_BCL_imported_operands_resolved_without_invocation';need(all(x in new if x!=old_ref else new_ref in new for x in old),'All prior20 behavioral/binding checks retained, external operand count strengthened6 to12')
    output=out/'completion-receipt.json';need(not output.exists(),'New completion receipt only; never overwrite any earlier evidence')
    report={'schema':'independently-completed-actual-original-custom-URP-initializer12-plus-seven-Mono-smoke/v1','status':SUCCESS,'auditor':pin(Path(__file__)),'plan':pin(out/'plan.json'),'preserved_original_interim_run_report':pin(interim),'original_wrapper_completed_successfully':False,'original_wrapper_finalization_failure':'Its exclusive-create save conflicts with the run-report.json already saved by the owned guard. Both child phases finished with exit0; this new pure auditor independently validates completion, without overwriting that starting-status receipt.','actual_child_phases':r['phases'],'runtime_result':pin(runtime),'full_Player_log':pin(log),'whole_compiler_logs':[pin(out/'compile-clone-only-actual12-plus-seven-diagnostic-stdout.log'),pin(out/'compile-clone-only-actual12-plus-seven-diagnostic-stderr.log')],'actual39checks':new,'actual_binding_counts':p['expected_binding_counts'],'exact_registered_diagnostic_assembly_identity':p['expected_runtime_identity'],'actual_D3D11_initialized':True,'full_log_error_counts':{'compiler':0,'Player':0},'source_player_files_all_unchanged':True,'cloned_nonreplacement_files_all_exact':True,'unchanged_clone_file_count':len(immutable),'exact_four_clone_replacements':changed,'source_player_inventory':p['source_player_files'],'stage_receipt':p['stage_receipt'],'stage_scoped_audit':p['stage_scoped_audit'],'native12_bindings31_controlled_effects':stage.TEST_SHA,'completion_controls':test,'Main_plugins_and_metas_unchanged':True,'boundary':p['boundary'],'Main_modified':False,'children_launched_by_auditor':False,'Editor_launched':False,'working_renderer_claimed':False,'audited_utc':dt.datetime.now(dt.timezone.utc).isoformat()}
    save(output,report);print(json.dumps({'status':report['status'],'completion_receipt':pin(output),'controls':test['controls'],'actual_checks':len(new)}))

def main():
    parser=argparse.ArgumentParser(description=__doc__);parser.parse_args();audit();return 0

# stage is a read-only module import, not an executed compiler or writer.
import stage_custom_urp_initializer_prerequisite_bodies_v2 as stage
if __name__=='__main__':raise SystemExit(main())
