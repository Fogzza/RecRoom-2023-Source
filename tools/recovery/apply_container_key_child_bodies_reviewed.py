"""Prepare, verify or Root-apply four tested key/child bodies in one SDK.

Only Root --apply writes Main. Actual Unity proved key equality/hash/Dictionary;
the child constructor boundary has complete native CFG and controlled tests,
not production registration/provider execution. Original meta/other bodies stay.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,uuid
import run_windows_development_define_probe as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
STAGE=ROOT/'Validation/ContainerKeyChildBodyStage-20261023T091828Z-7970a37a'
STAGE_SHA='b3a1d6ac9aa77941510496de99bb3551661f489fc3ecbe116e5d2b0ddd65a87c'
RESULT_SHA='9651b18a90813d53ecc7fa329409b753591171354142b6b2700876c7caa33a4b'
SCHEMA='reviewed-four-native-key-child-bodies-one-SDK-exact-apply/v1'
def need(value,message):
    if not value:raise ValueError(message)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned key/child apply input changed: '+row['path'])
def durable(path,data):
    with path.open('xb') as f:f.write(data);f.flush();os.fsync(f.fileno())
def save(path,value):durable(path,(json.dumps(value,indent=2)+'\n').encode('utf-8'))
def proof_rows():
    need(pin(STAGE/'run-report.json')['sha256']==STAGE_SHA and pin(STAGE/'Candidates/report.json')['sha256']==RESULT_SHA,'Exact actual four-body stage/readback receipts');stage=json.loads((STAGE/'run-report.json').read_bytes());result=json.loads((STAGE/'Candidates/report.json').read_bytes());check(stage['plan']);p=json.loads(Path(stage['plan']['path']).read_bytes())
    need(stage['status']=='four_tested_key_child_bodies_staged_all_metadata_and_other_bodies_preserved' and result['status']=='four_tested_key_child_bodies_imported_all_original_metadata_other_bodies_preserved' and result['changed_method_bodies']==4 and len(result['modules'])==len(p['modules'])==1,'Exact four member bodies in one original SDK')
    need(len(stage['phases'])==2 and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in stage['phases']) and not p['new_AssemblyRefs_permitted'],'Actual importer compilation/readback passed without metadata additions')
    row=result['modules'][0];source=p['modules'][0];need(row['original']==source['original'] and Path(row['original']['path'])==WS/'RR23/Assets/Plugins/UJect.Runtime.dll','One exact Main SDK target')
    for x in [source['original'],source['meta'],row['candidate'],row['donor']]+p['reviewable_donor_sources']:check(x)
    need(source['meta']['path']==source['original']['path']+'.meta' and row['entire_donor_bodies_and_scoped_operands_equal'] and row['all_original_MethodDef_tokens_preserved'],'Exact original importer/token and full donor body proof')
    members=row['selected_original_members'];need([(x['owner'],x['name'],x['current_MethodDef_token']) for x in members]==[('MNALHHOLFGL','MJHONDPGJFA',0x0600002c),('CPAMAFPANDM','OFPEIHMPLIL',0x0600004e),('CPAMAFPANDM','Equals',0x0600004f),('CPAMAFPANDM','GetHashCode',0x06000050)],'Exact four original named MethodDefs only')
    return [{'source':source['original'],'meta':source['meta'],'candidate':row['candidate'],'changed_members':members,'original_metadata_fingerprint':row['metadata_fingerprint'],'original_module_features_fingerprint':row['module_features_fingerprint'],'unchanged_other_method_bodies':row['all_other_method_bodies_unchanged']}],p['reviewable_donor_sources']
def smoke_proof(path,digest,rows):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit actual22-check matching player proof');r=json.loads(path.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['schema']=='guarded-actual-Unity-original-container-key-dictionary-smoke/v1' and r['status']=='actual_original_key_equality_hash_Dictionary_proved_in_matching_Windows_Mono_player' and r['all_selected_Main_plugins_and_metas_unchanged'] and not r['Main_modified'] and r['only_closed_SDK_key_constructor_equality_hash_executed'] and not r['production_child_method_executed'] and r['actual_D3D11_initialized'],'Actual matching key-only player checks')
    names=['empty-scene-Editor-builder-compile','actual-SDK-player-only-probe-compile','matching-Unity-original-SDK-smoke-build','actual-original-SDK-key-Dictionary-player'];need([x['phase'] for x in r['phases']]==names and all(x['exit_code']==0 and x['owned_cli_or_compiler_exit_confirmed'] and x['Editor_closed_after_job'] for x in r['phases']),'All four actual source/build/player phases succeeded and closed')
    for k in ['runtime_result','build_result','player','full_Editor_log','full_Player_log','actual_packaged_mscorlib']:check(r[k])
    observed=json.loads(Path(r['runtime_result']['path']).read_bytes());need(observed['schema']=='actual-Unity-original-container-key-dictionary-smoke/v1' and observed['status']=='actual_original_key_equality_hash_and_Dictionary_passed' and observed['mono_runtime'] and observed['unity_version']=='2020.3.33f1' and observed['platform']=='WindowsPlayer' and len(observed['checks'])==22 and not observed['errors'] and not observed['exception'] and observed['actual_key_equality_hash_and_Dictionary_tested'] and not observed['production_container_child_registration_lookup_factory_logger_or_provider_executed'],'Only actual original key behavior/Dictionary operations; no child/provider inference')
    need(p['schema']=='prepared-actual-Unity-original-container-key-dictionary-smoke/v1' and p['expected_runtime_checks']==22 and not p['production_child_method_executed'] and r['full_log_error_counts']=={'Editor':0,'Player':0},'Exact reviewed22-check scope and clean logs')
    import re
    editor=Path(r['full_Editor_log']['path']).read_text(encoding='utf-8',errors='replace');player=Path(r['full_Player_log']['path']).read_text(encoding='utf-8',errors='replace');need(not re.search(r'(?im)^.*(?:error CS\d+|Fatal error|Aborting batchmode|TypeLoadException|ReflectionTypeLoadException).*$',editor) and not re.search(r'(?im)^.*(?:Unhandled Exception|TypeLoadException|ReflectionTypeLoadException|Fatal error|ERROR: Shader|Partial constant buffer not found).*$',player),'Independent full-log error rescan');need('Direct3D:' in player and re.search(r'(?im)^\s*Version:\s*Direct3D 11',player) and 'Renderer: Null Device' not in player,'Actual D3D11 device')
    byname={x['name']:x for x in p['sdks']};packed={Path(x['path']).name:x for x in r['actual_packaged_SDKs']};need(set(byname)==set(packed)=={'UJect.Runtime.dll','RecRoom.NoEngine.JetBrains.Annotations.dll'},'Only exact staged UJect and genuine required annotations packaged')
    row=rows[0];sdk=byname['UJect.Runtime.dll'];need(sdk['origin']==row['candidate'] and sdk['current_Main_origin']==row['source'] and sdk['current_Main_meta']==row['meta'] and packed['UJect.Runtime.dll']['sha256']==row['candidate']['sha256'],'Actual player exercised exactly this staged candidate')
    for item in p['sdks']:
        for k in ['dll','meta','origin','current_Main_origin','current_Main_meta']:check(item[k])
        check(packed[item['name']])
    for row in p['read_only_sources']:check(row)
    return r

def prepare(smoke,digest):
    rows,readable=proof_rows();observed=smoke_proof(smoke,digest,rows)
    out=ROOT/'Validation'/('ContainerKeyChildExactApply-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    plan={'schema':SCHEMA,'status':'prepared_Main_not_modified','fixture':str(out),'runner':pin(Path(__file__)),'body_stage_receipt':pin(STAGE/'run-report.json'),'body_semantic_report':pin(STAGE/'Candidates/report.json'),'successful_actual_Unity_smoke':pin(smoke),'successful_smoke_plan':observed['plan'],'rows':rows,'readable_recovered_CSharp_sources':readable,'only_Main_writes':'the exact one listed DLL replacement; no meta or source write','metadata_contract':'Every original declaration/signature/identity/reference and other body retained. No metadata addition is permitted.','actual_runtime_scope':'Only original CPAM constructor/equality/hash ran in matching Unity, with22 key/Dictionary checks. Child method has complete native CFG and an exact controlled constructor boundary in the32-case pass; original child/registration/provider paths never ran.','higher_bootstrap_activation_performed':False,'working_startup_login_or_dorm_claimed':False,'Main_modified':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_apply_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--apply']}))
def execute(path,digest,apply):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed one-SDK apply plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerKeyChildExactApply-'),'Exact isolated apply evidence scope')
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
        report.update(status='four_native_key_child_bodies_applied_one_SDK_meta_preserved',metas_unchanged=True,changed_method_bodies=4,all_other_bodies_and_all_original_semantic_metadata_retained=True)
    except BaseException as error:report.update(status='partial_or_failed_HOLD_no_automatic_reapply' if report['Main_modified'] else 'failed_Main_not_modified',error=repr(error));journal({'event':'HOLD','status':report['status']})
    finally:save(out/'apply-receipt.json',report)
    print(json.dumps({'status':report['status'],'receipt':pin(out/'apply-receipt.json'),'Main_modified':report['Main_modified'],'error':report.get('error')}));return 0 if report['status']=='four_native_key_child_bodies_applied_one_SDK_meta_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--smoke-report',type=Path);a.add_argument('--smoke-report-sha256');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--apply',action='store_true');v=a.parse_args()
    if v.smoke_report:need(v.smoke_report_sha256 and not v.plan and not v.apply,'Prepare only after actual successful pinned real Unity smoke');prepare(v.smoke_report.resolve(strict=True),v.smoke_report_sha256);return 0
    need(v.plan and v.plan_sha256,'Explicit reviewed plan required');return execute(v.plan,v.plan_sha256,v.apply)
if __name__=='__main__':raise SystemExit(main())
