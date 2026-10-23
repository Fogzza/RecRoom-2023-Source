"""Prepare, verify, or Root-apply exactly the two tested small title callback spans.

No compiler/test/Unity/network launch. A successful pinned binding/effect
receipt is mandatory. Preparation never writes Main. --apply is the sole
mutation path and preserves the original meta and all unrelated source bytes.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,os,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
SLICE=ROOT/'Validation/TitleSmallCallbacksSlice-20261023T092721Z-f87472a0/report.json'
SLICE_SHA='73cc26342ca361e16597050677df69241f40c65cef5f8a60667818ee964a8e19'
SCHEMA='reviewed-exact-two-original-small-title-callback-spans-apply/v1'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned source/proof changed: '+row['path'])
def durable(path,data):
    with path.open('xb') as f:f.write(data);f.flush();os.fsync(f.fileno())
def save(path,value):durable(path,(json.dumps(value,indent=2)+'\n').encode())
def proof_sources():
    need(pin(SLICE)['sha256']==SLICE_SHA,'Exact complete54+165 original callback bytes');p=json.loads(SLICE.read_bytes())
    need([(x['index'],int(x['token'],16)) for x in p['original_methods']]==[(192552,0x060008A1),(192568,0x060008B1)] and p['all_bytes_outside_two_exact_original_stubs_preserved'] and p['complete_native_shapes'][0]['all54_original_bytes_recognized'] and p['complete_native_shapes'][1]['all165_original_bytes_recognized'] and len(p['native_single_byte_negative_controls'])==219 and all(x['rejected'] for x in p['native_single_byte_negative_controls']),'Only the exact two complete native callbacks and their negative controls')
    for key in ['actual_decoder_receipt','actual_decoded_output','native_join_proof','readable_members','producer']:check(p[key])
    need(len(p['byte_edits'])==2,'Two exact original callback spans')
    p['sources']=[{'source':p['source'],'source_meta':p['source_meta'],'candidate':p['candidate'],'byte_edits':[dict(e,original_method_token=token) for e,token in zip(p['byte_edits'],['0x060008A1','0x060008B1'])]}]
    r=p['sources'][0]
    for key in ['source','source_meta','candidate']:check(r[key])
    src=Path(r['source']['path']);meta=Path(r['source_meta']['path']);need(src==WS/'RR23/Assets/Scripts/Assembly-CSharp/TitleScreenManager.cs' and str(meta)==str(src)+'.meta','Exact source/meta scope')
    data=src.read_bytes();after=data;last=-1
    for e in sorted(r['byte_edits'],key=lambda x:x['start']):
        old=base64.b64decode(e['original_base64'],validate=True);a=e['start'];need(e['length']==len(old) and a>=last and data[a:a+len(old)]==old,'Exact original distinct nonoverlapping stub spans');last=a+len(old)
    for e in sorted(r['byte_edits'],key=lambda x:x['start'],reverse=True):
        old=base64.b64decode(e['original_base64'],validate=True);new=base64.b64decode(e['replacement_base64'],validate=True);a=e['start'];after=after[:a]+new+after[a+len(old):]
    need(Path(r['candidate']['path']).read_bytes()==after,'Only both exact native-proved callback spans; preserve Awake/Start/PMNJ/FlowModel and every other byte')
    return p

def test_proof(path,expected):
    import run_title_small_callbacks_harness as harness
    need(pin(path)['sha256']==expected,'Explicit successful21case receipt hash');r=json.loads(path.read_bytes())
    need(r['status']=='actual_full_two_small_callback_bindings_and_twenty_one_controlled_effect_cases_passed' and r['actual_full_file_compiled'] is True and r['metadata_binding_verified'] is True and r['controlled_effect_cases']==21 and r['all_Main_sources_and_selected_meta_unchanged'] is True and r['Main_modified'] is False and r['working_boot_title_login_claimed'] is False,'Actual full-file binding and21 controlled cases passed')
    check(r['plan']);plan=json.loads(Path(r['plan']['path']).read_bytes());need(plan['schema']==harness.SCHEMA and plan['slice']==pin(SLICE) and plan['source_count']==5095 and plan['reference_count']==409 and plan['test_doubles_are_explicitly_test_only'] and plan['runner']==pin(Path(harness.__file__)),'Tests bind exact original callback and real full compiler inputs')
    for key in ['runner','base_runner','runtime_checkpoint_helper','original_attribute_provider','slice','template','source','captured_Unity_response','full_response','effect_response','compiler_inputs','copied_Cecil','compiler','mono','guard','launcher']:check(plan[key])
    for x in plan['effect_references']:check(x)
    for x in json.loads(Path(plan['compiler_inputs']['path']).read_bytes()):check(x)
    slice,span=harness.candidate();need(harness.runtime_checkpoint()==plan['current_actual_runtime_checkpoint'] and hashlib.sha256(span).hexdigest()==plan['exact_candidate_span_sha256'] and Path(plan['source']['path']).read_bytes()==Path(plan['template']['path']).read_bytes().replace(b'/*EXACT_ORIGINAL_SMALL_CALLBACKS*/',span),'Exact actual current runtime SDKs and unchanged original source insertion')
    check(r['full_assembly']);need([x['phase'] for x in r['phases']]==['compile-actual-full-two-small-callback-candidate-file','compile-exact-small-callback-effects-and-reader','inspect-two-actual-original-callback-bindings-metadata-only','twenty-one-exact-small-callback-controlled-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'All four exact owned phases passed')
    return r,plan

def prepare(test,expected):
    proof=proof_sources();r,t=test_proof(test,expected)
    out=ROOT/'Validation'/('TitleSmallCallbacksExactApply-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    plan={'schema':SCHEMA,'status':'prepared_Main_not_modified','fixture':str(out),'runner':pin(Path(__file__)),'slice':pin(SLICE),'successful_test_receipt':pin(test),'successful_test_plan':r['plan'],'sources':proof['sources'],'actual_compiled_assembly':r['full_assembly'],'no_working_login_or_bootstrap_claim':True,'Main_modified':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_apply_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--apply']}))
def execute(path,expected,apply):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed apply plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleSmallCallbacksExactApply-'),'Owned exact apply workspace')
    for k in ['runner','slice','successful_test_receipt','successful_test_plan','actual_compiled_assembly']:check(p[k])
    need(p['runner']==pin(Path(__file__)) and p['slice']==pin(SLICE),'Exact reviewed apply source and slice')
    proof=proof_sources();need(p['sources']==proof['sources'],'Exact source/meta/candidate spans')
    test_proof(Path(p['successful_test_receipt']['path']),p['successful_test_receipt']['sha256'])
    if not apply:print(json.dumps({'status':'verified_no_Main_write','plan_sha256':expected}));return 0
    guard.safety.assert_editor_closed();need(not(out/'apply-receipt.json').exists() and not(out/'journal.jsonl').exists() and not(out/'Backup').exists(),'Fresh one-shot apply, no overwrite/retry')
    report={'schema':SCHEMA,'status':'starting','plan':pin(path),'Main_modified':False,'applied':[],'metas_unchanged':False,'all_unrelated_source_bytes_unchanged':False,'compiler_Unity_game_network_executed':False,'working_login_or_bootstrap_claimed':False}
    def journal(event):
        with (out/'journal.jsonl').open('ab') as f:f.write((json.dumps({'utc':dt.datetime.now(dt.timezone.utc).isoformat(),**event})+'\n').encode());f.flush();os.fsync(f.fileno())
    try:
        backup=out/'Backup';backup.mkdir();pending=[]
        for i,row in enumerate(p['sources']):
            for k in ['source','source_meta','candidate']:check(row[k])
            source=Path(row['source']['path']);meta=Path(row['source_meta']['path']);original=source.read_bytes();meta_bytes=meta.read_bytes();candidate=Path(row['candidate']['path']).read_bytes()
            bf=backup/(str(i)+'-'+source.name);bm=backup/(str(i)+'-'+meta.name);durable(bf,original);durable(bm,meta_bytes);target=out/('pending-'+str(i)+'.cs');durable(target,candidate)
            need(pin(bf)['sha256']==row['source']['sha256'] and pin(bm)['sha256']==row['source_meta']['sha256'] and pin(target)['sha256']==row['candidate']['sha256'],'Exact durable backups and candidates')
            pending.append((row,source,meta,target,bf,bm))
        report['backups']=[{'source':pin(x[4]),'meta':pin(x[5])} for x in pending];journal({'event':'all_backups_verified_before_any_source_write'})
        # This is a single-file journaled replacement, not an OS-level multi-file CAS.
        # Every target is rechecked immediately before its one exact replacement.
        for row,source,meta,target,bf,bm in pending:
            check(row['source']);check(row['source_meta']);check(row['candidate']);journal({'event':'replace_intent','source':str(source),'before_sha256':row['source']['sha256'],'after_sha256':row['candidate']['sha256']})
            os.replace(target,source);report['Main_modified']=True
            need(pin(source)['sha256']==row['candidate']['sha256'],'Exact post-replacement full source')
            check(row['source_meta']);report['applied'].append({'source':pin(source),'meta':pin(meta),'original_method_tokens':[e['original_method_token'] for e in row['byte_edits']]});journal({'event':'replace_verified','source':str(source),'sha256':pin(source)['sha256']})
        for row,source,meta,target,bf,bm in pending:
            need(source.read_bytes()==Path(row['candidate']['path']).read_bytes() and meta.read_bytes()==bm.read_bytes(),'Final complete candidate and original meta bytes')
        report.update(status='two_exact_original_small_title_callbacks_applied_other_bytes_and_meta_preserved',metas_unchanged=True,all_unrelated_source_bytes_unchanged=True,changed_method_bodies=2)
    except BaseException as error:
        report.update(status='partial_or_failed_HOLD_no_automatic_reapply' if report['Main_modified'] else 'failed_Main_not_modified',error=repr(error));journal({'event':'HOLD','status':report['status']})
    finally:save(out/'apply-receipt.json',report)
    print(json.dumps({'status':report['status'],'receipt':pin(out/'apply-receipt.json'),'Main_modified':report['Main_modified'],'error':report.get('error')}));return 0 if report['status']=='two_exact_original_small_title_callbacks_applied_other_bytes_and_meta_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--test-report',type=Path);a.add_argument('--test-report-sha256');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--apply',action='store_true');v=a.parse_args()
    if v.test_report:need(v.test_report_sha256 and not v.plan and not v.apply,'Prepare only from exact successful test receipt');prepare(v.test_report.resolve(strict=True),v.test_report_sha256);return 0
    need(v.plan and v.plan_sha256,'Explicit reviewed apply plan required');return execute(v.plan,v.plan_sha256,v.apply)
if __name__=='__main__':raise SystemExit(main())
