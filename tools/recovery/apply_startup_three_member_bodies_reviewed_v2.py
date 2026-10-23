"""Prepare, verify, or Root-apply exactly two SDK DLLs after real Unity smoke.

The three native-backed member bodies are already staged and metadata/body
roundtripped. Preparation requires a separately pinned passing actual Windows
Mono lifecycle smoke. There is no compiler/Editor/player/network launch here.
Only --apply can replace Main's two exact old DLL hashes; metas are preserved.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,uuid
import run_windows_development_define_probe as guard
import run_startup_sdk_runtime_d3d11_retest as retest
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
STAGE=ROOT/'Validation/StartupThreeMemberBodyStage-20261023T072237Z-29c9faaf'
STAGE_SHA='bc28f138814d1f1908848b2d9001a139d8df5c446edf45e6baa006af72490a85'
RESULT_SHA='c08fcd0a9615607a7cb2a51f764b6a370d69d491c2934c3923e5f996deb355eb'
SCHEMA='reviewed-three-tested-native-startup-bodies-two-SDK-apply/v2'
NAMES={'RecRoom.Datastructures.Singletons.Runtime.dll','UJect.Runtime.dll'}
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned SDK apply input changed: '+row['path'])
def durable(path,data):
    with path.open('xb') as f:f.write(data);f.flush();os.fsync(f.fileno())
def save(path,value):durable(path,(json.dumps(value,indent=2)+'\n').encode('utf-8'))
def proof_rows():
    need(pin(STAGE/'run-report.json')['sha256']==STAGE_SHA and pin(STAGE/'Candidates/report.json')['sha256']==RESULT_SHA,'Exact actual body-staging/readback receipts required')
    result=json.loads((STAGE/'Candidates/report.json').read_bytes());stage=json.loads((STAGE/'run-report.json').read_bytes());check(stage['plan']);p=json.loads(Path(stage['plan']['path']).read_bytes())
    need(stage['status']=='three_tested_original_bodies_staged_all_metadata_and_other_bodies_preserved' and result['status']=='three_tested_bodies_imported_all_original_metadata_other_bodies_preserved' and result['changed_method_bodies']==3 and len(result['modules'])==2,'Exact three tested bodies in two original plugins')
    need(len(stage['phases'])==2 and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in stage['phases']),'Actual importer compiled/executed successfully')
    rows=[]
    for item,source in zip(result['modules'],p['modules']):
        need(item['original']==source['original'] and Path(item['original']['path']).parent==WS/'RR23/Assets/Plugins' and Path(item['original']['path']).name in NAMES,'Exact two Main plugin targets')
        for row in [source['original'],source['meta'],item['candidate'],item['donor']]:check(row)
        need(str(Path(source['meta']['path']))==source['original']['path']+'.meta' and item['entire_donor_bodies_and_scoped_operands_equal'] and item['all_original_MethodDef_tokens_preserved'],'Original importer/meta/token and exact donor body proof')
        rows.append({'source':source['original'],'meta':source['meta'],'candidate':item['candidate'],'changed_members':item['selected_original_members'],'original_metadata_fingerprint':item['metadata_fingerprint'],'original_module_features_fingerprint':item['module_features_fingerprint'],'unchanged_other_method_bodies':item['all_other_method_bodies_unchanged']})
    need({Path(x['source']['path']).name for x in rows}==NAMES and sum(len(x['changed_members']) for x in rows)==3,'Exact unique plugin/member set')
    for row in p['reviewable_donor_sources']:check(row)
    return rows,p['reviewable_donor_sources']
def smoke_proof(path,digest,rows):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit successful real Unity smoke receipt hash required');r=json.loads(path.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['schema']=='guarded-actual-Unity-original-startup-SDK-smoke/v1' and r['status']=='actual_original_SDK_lifecycle_and_disposed_guard_proved_in_matching_Windows_Mono_player' and r['all_selected_Main_plugins_and_metas_unchanged'] is True and not r['Main_modified'] and not r['production_GameRoot_instantiated'] and not r['getter_stubs_as_observations'],'Passing real original SDK lifecycle proof required')
    need(p['schema']==retest.SCHEMA and r['retest_only_player'] is True and r['reused_prior_successful_compiles_and_build'] is True and r['actual_D3D11_initialized'] is True,'Exact runtime-only D3D11 retest schema/provenance')
    verified,prior=retest.verify(Path(r['plan']['path']),r['plan']['sha256']);need(r['prior_failed_overall_receipt']==verified['original_failed_overall_receipt'] and len(r['phases'])==4,'Exact preserved previous NullGPU failure provenance')
    for got,original in zip(r['phases'][:3],prior['phases'][:3]):
        expected_phase=dict(original);expected_phase['reused_from_frozen_actual_receipt']=verified['original_failed_overall_receipt'];expected_phase['executed_in_this_retest']=False
        need(got==expected_phase,'Successful old compile/build phase must be retained verbatim and explicitly labeled reused')
    need(all(r[k]==prior[k] for k in ['build_result','player','full_Editor_log','actual_packaged_SDKs']),'Same actual successful build and exact packaged SDK bytes')
    expected=['empty-scene-Editor-builder-compile','actual-SDK-player-only-probe-compile','matching-Unity-original-SDK-smoke-build','actual-original-SDK-lifecycle-player'];need([x['phase'] for x in r['phases']]==expected and all(x['exit_code']==0 and x['owned_cli_or_compiler_exit_confirmed'] and x['Editor_closed_after_job'] for x in r['phases']),'All four actual source/build/player phases passed and owned jobs closed')
    for k in ['runtime_result','build_result','player','full_Editor_log','full_Player_log']:check(r[k])
    editorerrors,playererrors=retest.scan(Path(r['full_Editor_log']['path']).read_text(encoding='utf-8',errors='replace'),Path(r['full_Player_log']['path']).read_text(encoding='utf-8',errors='replace'));need(not editorerrors and not playererrors,'Independent unchanged strict full-log rescan')
    actual=json.loads(Path(r['runtime_result']['path']).read_bytes());need(actual['status']=='actual_original_SDK_Awake_OnDestroy_and_disposed_guard_passed' and actual['mono_runtime'] and actual['unity_version']=='2020.3.33f1' and actual['platform']=='WindowsPlayer' and len(actual['checks'])==15 and actual['end_frame']-actual['start_frame']>=6 and not actual['errors'] and not actual['game_getter_stubs_used'] and not actual['production_GameRoot_instantiated'],'Actual callback/storage/exception observations required')
    need(all(actual[k] for k in ['old_GameObject_destroyed','new_instance_survived_old_OnDestroy','current_instance_cleared','independent_generic_storage','disposed_guard_exact_exception']) and r['full_log_error_counts']=={'Editor':0,'Player':0},'Complete positive original SDK integration witnesses')
    byname={x['name']:x for x in p['sdks']};packed={Path(x['path']).name:x for x in r['actual_packaged_SDKs']};need(len(byname)==len(packed)==3,'Exact packaged SDK closure including annotation metadata')
    for row in rows:
        name=Path(row['source']['path']).name;sdk=byname[name];need(sdk['origin']==row['candidate'] and sdk['current_Main_origin']==row['source'] and sdk['current_Main_meta']==row['meta'] and packed[name]['sha256']==row['candidate']['sha256'],'Real player must exercise exact staged SDK bytes and exact original meta source')
        check(packed[name]);check(sdk['dll']);check(sdk['meta'])
    for row in p['read_only_sources']:check(row)
    return r
def prepare(smoke,digest):
    rows,readable=proof_rows();observed=smoke_proof(smoke,digest,rows)
    out=ROOT/'Validation'/('StartupThreeMemberExactApply-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    plan={'schema':SCHEMA,'status':'prepared_Main_not_modified','fixture':str(out),'runner':pin(Path(__file__)),'body_stage_receipt':pin(STAGE/'run-report.json'),'body_semantic_report':pin(STAGE/'Candidates/report.json'),'successful_actual_Unity_smoke':pin(smoke),'successful_smoke_plan':observed['plan'],'rows':rows,'readable_recovered_CSharp_sources':readable,'only_Main_writes':'the exact two listed DLL replacements; no meta or source write','compiler_scope_note':'Original plugin declarations, signatures, type/field/method identities and full assembly-reference inventories are semantically unchanged; existing compiler projections/scopes therefore remain valid. This apply tool does not run a new full game compilation.','higher_bootstrap_activation_performed':False,'working_startup_login_or_dorm_claimed':False,'Main_modified':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_apply_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--apply']}))
def execute(path,digest,apply):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed two-SDK apply plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('StartupThreeMemberExactApply-'),'Exact isolated apply evidence scope')
    for k in ['runner','body_stage_receipt','body_semantic_report','successful_actual_Unity_smoke','successful_smoke_plan']:check(p[k])
    need(p['runner']==pin(Path(__file__)),'Exact reviewed apply runner');rows,readable=proof_rows();need(p['rows']==rows and p['readable_recovered_CSharp_sources']==readable,'Exact current source/candidate/meta/member set');smoke_proof(Path(p['successful_actual_Unity_smoke']['path']),p['successful_actual_Unity_smoke']['sha256'],rows)
    if not apply:print(json.dumps({'status':'verified_no_Main_write','plan_sha256':digest}));return 0
    guard.safety.assert_editor_closed();need(not(out/'apply-receipt.json').exists() and not(out/'journal.jsonl').exists() and not(out/'Backup').exists(),'Fresh one-shot exact apply; no automatic retry')
    report={'schema':SCHEMA,'status':'starting','plan':pin(path),'Main_modified':False,'applied':[],'metas_unchanged':False,'higher_bootstrap_activated':False,'working_startup_login_or_dorm_claimed':False}
    def journal(event):
        with (out/'journal.jsonl').open('ab') as f:f.write((json.dumps({'utc':dt.datetime.now(dt.timezone.utc).isoformat(),**event})+'\n').encode());f.flush();os.fsync(f.fileno())
    try:
        backup=out/'Backup';backup.mkdir();pending=[]
        for n,row in enumerate(rows):
            for k in ['source','meta','candidate']:check(row[k])
            source=Path(row['source']['path']);meta=Path(row['meta']['path']);bf=backup/source.name;bm=backup/meta.name;temp=out/('pending-'+str(n)+'.dll')
            durable(bf,source.read_bytes());durable(bm,meta.read_bytes());durable(temp,Path(row['candidate']['path']).read_bytes());need(pin(bf)['sha256']==row['source']['sha256'] and pin(bm)['sha256']==row['meta']['sha256'] and pin(temp)['sha256']==row['candidate']['sha256'],'All durable originals/metas/candidates must verify before any Main write');pending.append((row,source,meta,bf,bm,temp))
        report['backups']=[{'DLL':pin(x[3]),'meta':pin(x[4])} for x in pending];journal({'event':'all_original_DLL_and_meta_backups_verified_before_any_Main_write'})
        # Explicit per-file journaled transaction; not an OS-level multi-file CAS.
        for row,source,meta,bf,bm,temp in pending:
            check(row['source']);check(row['meta']);check(row['candidate']);journal({'event':'replace_intent','source':str(source),'before_sha256':row['source']['sha256'],'after_sha256':row['candidate']['sha256']});os.replace(temp,source);report['Main_modified']=True
            need(pin(source)['sha256']==row['candidate']['sha256'],'Exact staged plugin bytes after replacement');check(row['meta']);report['applied'].append({'source':pin(source),'meta':pin(meta),'changed_members':row['changed_members']});journal({'event':'replace_verified','source':str(source),'sha256':pin(source)['sha256']})
        for row,source,meta,bf,bm,temp in pending:need(source.read_bytes()==Path(row['candidate']['path']).read_bytes() and meta.read_bytes()==bm.read_bytes(),'Final exact candidate bytes and original importer meta bytes')
        report.update(status='three_tested_original_startup_bodies_applied_two_SDKs_metas_preserved',metas_unchanged=True,changed_method_bodies=3,all_other_bodies_and_original_semantic_metadata_preserved=True)
    except BaseException as error:report.update(status='partial_or_failed_HOLD_no_automatic_reapply' if report['Main_modified'] else 'failed_Main_not_modified',error=repr(error));journal({'event':'HOLD','status':report['status']})
    finally:save(out/'apply-receipt.json',report)
    print(json.dumps({'status':report['status'],'receipt':pin(out/'apply-receipt.json'),'Main_modified':report['Main_modified'],'error':report.get('error')}));return 0 if report['status']=='three_tested_original_startup_bodies_applied_two_SDKs_metas_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--smoke-report',type=Path);a.add_argument('--smoke-report-sha256');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--apply',action='store_true');v=a.parse_args()
    if v.smoke_report:need(v.smoke_report_sha256 and not v.plan and not v.apply,'Prepare only after actual successful pinned real Unity smoke');prepare(v.smoke_report.resolve(strict=True),v.smoke_report_sha256);return 0
    need(v.plan and v.plan_sha256,'Explicit reviewed plan required');return execute(v.plan,v.plan_sha256,v.apply)
if __name__=='__main__':raise SystemExit(main())
