"""Prepare, verify or Root-apply exactly the tested NGB and CPBM bodies.

Both original-owner bindings and30 real-Dictionary/combined controlled effects
passed. Original LNF, provider implementations and SDK callers are NOT executed
by this proof; no working initialization/login claim or bootstrap activation.
Only explicit Root --apply can replace the one pinned Main SDK, preserving meta.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,uuid
import run_windows_development_define_probe as guard
import stage_container_lookup_discovery_bodies as staging
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
SCHEMA='reviewed-two-native-lookup-discovery-bodies-one-SDK-exact-apply/v1'
EXPECTED_STAGE_PLAN=ROOT/'Validation/ContainerLookupDiscoveryBodyStage-20261023T100454Z-0d2f0cee/plan.json'
EXPECTED_STAGE_PLAN_SHA='c4275315f226800175ab8a0e3ad28efb2335389aa411345eb4819d3694052199'
def need(value,message):
    if not value:raise ValueError(message)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned lookup/discovery apply input changed: '+row['path'])
def durable(path,data):
    with path.open('xb') as f:f.write(data);f.flush();os.fsync(f.fileno())
def save(path,value):durable(path,(json.dumps(value,indent=2)+'\n').encode('utf-8'))
def proof_rows(path,digest):
    need(path.resolve(strict=True)==EXPECTED_STAGE_PLAN.parent/'run-report.json' and pin(path)['sha256']==digest and pin(EXPECTED_STAGE_PLAN)['sha256']==EXPECTED_STAGE_PLAN_SHA,'Exact actual two-body stage receipt and reviewed plan')
    stage=json.loads(path.read_bytes());check(stage['plan']);p=json.loads(Path(stage['plan']['path']).read_bytes());need(stage['plan']==pin(EXPECTED_STAGE_PLAN),'Only exact reviewed stage')
    need(stage['schema']=='guarded-two-tested-container-lookup-discovery-body-only-stage/v1' and stage['status']=='two_tested_lookup_discovery_bodies_staged_all_metadata_and_other_bodies_preserved' and [x['phase'] for x in stage['phases']]==['compile-pure-two-lookup-discovery-body-importer','stage-and-readback-two-original-lookup-discovery-bodies'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in stage['phases']) and stage['Main_plugin_and_meta_unchanged'],'Actual importer compilation and complete readback passed')
    need(p['runner']==pin(Path(staging.__file__)),'Exact reviewed staging helper');staging.execute(EXPECTED_STAGE_PLAN,EXPECTED_STAGE_PLAN_SHA,False)
    check(stage['result']);result=json.loads(Path(stage['result']['path']).read_bytes());need(result['schema']=='two-tested-original-container-lookup-discovery-body-only-staged-candidates/v1' and result['status']=='two_tested_lookup_discovery_bodies_imported_all_original_metadata_other_bodies_preserved' and result['changed_method_bodies']==2 and len(result['modules'])==len(p['modules'])==1 and not result['Main_modified'],'Exactly two bodies, one original SDK, no Main staging writes')
    row=result['modules'][0];source=p['modules'][0];need(row['original']==source['original'] and row['donor']==source['donor'] and Path(row['original']['path'])==WS/'RR23/Assets/Plugins/UJect.Runtime.dll','One exact original target/donor')
    for x in [source['original'],source['meta'],row['candidate'],row['donor']]+p['reviewable_donor_sources']:check(x)
    need(source['meta']['path']==source['original']['path']+'.meta' and row['entire_donor_bodies_and_scoped_operands_equal'] and row['all_original_MethodDef_tokens_preserved'] and not p['new_AssemblyRefs_permitted'],'Original importer/meta and full body/token/metadata preservation')
    members=row['selected_original_members'];need([(x['owner'],x['name'],x['current_MethodDef_token']) for x in members]==[('MNALHHOLFGL','NGBMOPMLJCM',0x0600001e),('MNALHHOLFGL','CPBMOKFMMMK',0x0600001f)],'Only exact two original caller MethodDefs')
    rows=[{'source':source['original'],'meta':source['meta'],'candidate':row['candidate'],'changed_members':members,'original_metadata_fingerprint':row['metadata_fingerprint'],'original_module_features_fingerprint':row['module_features_fingerprint'],'unchanged_other_method_bodies':row['all_other_method_bodies_unchanged']}]
    return rows,p['reviewable_donor_sources'],stage,p

def prepare(stage_path,digest):
    rows,readable,stage,p=proof_rows(stage_path,digest)
    out=ROOT/'Validation'/('ContainerLookupDiscoveryExactApply-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    plan={'schema':SCHEMA,'status':'prepared_Main_not_modified','fixture':str(out),'runner':pin(Path(__file__)),'body_stage_receipt':pin(stage_path),'body_stage_plan':stage['plan'],'body_semantic_report':stage['result'],'successful_binding_effects_receipt':p['test_receipt'],'rows':rows,'readable_recovered_CSharp_sources':readable,'only_Main_writes':'one exact listed UJect.Runtime.dll replacement; no meta or source writes','metadata_contract':'Every original declaration/signature/identity/reference and all other bodies retained; no metadata addition.','actual_execution_scope':'Twenty isolated NGB cases and30 real-Dictionary CPBM/combined controlled cases, exact original-owner binding and full imported-body readback. No original SDK caller, LNF, formatter or provider implementation was executed.','SDK_callers_or_held_dependencies_runtime_proved':False,'higher_bootstrap_activation_performed':False,'working_startup_login_or_dorm_claimed':False,'Main_modified':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_apply_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--apply']}))
def execute(path,digest,apply):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed one-SDK apply plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerLookupDiscoveryExactApply-'),'Exact isolated apply evidence scope')
    for k in ['runner','body_stage_receipt','body_stage_plan','body_semantic_report','successful_binding_effects_receipt']:check(p[k])
    need(p['runner']==pin(Path(__file__)),'Exact reviewed apply runner');rows,readable,stage,stageplan=proof_rows(Path(p['body_stage_receipt']['path']),p['body_stage_receipt']['sha256']);need(p['rows']==rows and p['readable_recovered_CSharp_sources']==readable and p['body_stage_plan']==stage['plan'] and p['successful_binding_effects_receipt']==stageplan['test_receipt'],'Exact current source/candidate/meta/member and actual30-effect binding set')
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
        report.update(status='two_native_lookup_discovery_bodies_applied_one_SDK_meta_preserved',metas_unchanged=True,changed_method_bodies=2,all_other_bodies_and_all_original_semantic_metadata_retained=True)
    except BaseException as error:report.update(status='partial_or_failed_HOLD_no_automatic_reapply' if report['Main_modified'] else 'failed_Main_not_modified',error=repr(error));journal({'event':'HOLD','status':report['status']})
    finally:save(out/'apply-receipt.json',report)
    print(json.dumps({'status':report['status'],'receipt':pin(out/'apply-receipt.json'),'Main_modified':report['Main_modified'],'error':report.get('error')}));return 0 if report['status']=='two_native_lookup_discovery_bodies_applied_one_SDK_meta_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--stage-report',type=Path);a.add_argument('--stage-report-sha256');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--apply',action='store_true');v=a.parse_args()
    if v.stage_report:need(v.stage_report_sha256 and not v.plan and not v.apply,'Prepare only after actual successful pinned stage');prepare(v.stage_report.resolve(strict=True),v.stage_report_sha256);return 0
    need(v.plan and v.plan_sha256,'Explicit reviewed plan required');return execute(v.plan,v.plan_sha256,v.apply)
if __name__=='__main__':raise SystemExit(main())
