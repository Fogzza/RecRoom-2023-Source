"""Prepare, verify, or Root-apply the tested original three title getter expressions only.

No compiler/test/Unity/network launch. A successful pinned binding/effect
receipt is mandatory. Preparation never writes Main. --apply is the sole
mutation path and preserves the original meta and all unrelated source bytes.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,os,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
SLICE=ROOT/'Validation/TitleDependencyLeafProperties-20261023T083105Z-041fd428/report.json'
SLICE_SHA='c1db3b610088f936736a9074cd348fb45e727fd1897aa8511dca8d07a285ce64'
SCHEMA='reviewed-exact-three-original-title-leaf-expressions-apply/v1'
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
    need(pin(SLICE)['sha256']==SLICE_SHA,'Exact three original leaf source expressions');p=json.loads(SLICE.read_bytes());need(p['all_bytes_outside_three_null_expressions_preserved'] and p['all_original_script_meta_bytes_preserved'] and len(p['sources'])==3,'Only three exact original null expressions')
    for k in ['native_inline_evidence','original_attribute_provider','current_title_checkpoint']:check(p[k])
    for x in p['reused_policy_sources']:check(x)
    tokens=set();sources=[]
    for r in p['sources']:
        for k in ['source','source_meta','candidate']:check(r[k])
        source=Path(r['source']['path']);meta=Path(r['source_meta']['path']);expected=WS/'RR23/Assets/Scripts/Assembly-CSharp'/Path(*r['owner'].split('.')).with_suffix('.cs');need(source==expected and str(meta)==str(source)+'.meta','Only three exact same-owner source paths')
        e=r['byte_edit'];old=base64.b64decode(e['original_base64'],validate=True);new=base64.b64decode(e['replacement_base64'],validate=True);before=source.read_bytes();at=e['start'];need(old==b'null' and e['length']==4 and before[at:at+4]==old and new==('this.'+r['source_field']).encode() and Path(r['candidate']['path']).read_bytes()==before[:at]+new+before[at+4:],'Only selected null expression becomes proved same-instance field')
        token='0x%08X'%int(r['original_getter']['original']['token'],16);tokens.add(token);sources.append({'source':r['source'],'source_meta':r['source_meta'],'candidate':r['candidate'],'byte_edits':[dict(e,original_method_token=token)]})
    need(tokens=={'0x06012701','0x06011563','0x060115C6'} and len({x['source']['path'].casefold() for x in sources})==3,'Exactly three distinct tested original getter methods/files');p['sources']=sources;return p

def test_proof(path,expected):
    import run_title_dependency_leaf_harness_v2 as harness
    need(pin(path)['sha256']==expected,'Exact successful15case original-field binding receipt');r=json.loads(path.read_bytes());need(r['status']=='actual_full_three_leaf_file_bindings_original_field_mappings_and_fifteen_controlled_cases_passed' and r['actual_full_file_compiled'] is True and r['metadata_binding_verified'] is True and r['original_field_mapping_verified'] is True and r['controlled_effect_cases']==15 and r['all_Main_sources_and_selected_meta_unchanged'] is True and r['Main_modified'] is False and r['working_boot_title_login_claimed'] is False,'Actual full-file/ownership and15effects proof passed')
    check(r['plan']);plan=json.loads(Path(r['plan']['path']).read_bytes());need(plan['schema']==harness.SCHEMA and plan['slice']==pin(SLICE) and plan['source_count']==5095 and plan['reference_count']==409 and plan['runner']==pin(Path(harness.__file__)),'Exact three getter candidates and reviewed v2 reader')
    for k in ['runner','prior_runner','base_runner','prior_failed_receipt','prior_successful_full_compile_plan','reused_successful_full_assembly','unchanged_full_compiler_inputs','slice','current_title_checkpoint','original_attribute_provider','generic_name_proof','raw_generic_contract','projected_generic_contract','old_template','new_template','source','effect_response','copied_Cecil','compiler','mono','guard','launcher']:check(plan[k])
    for x in plan['effect_references']:check(x)
    previous,old=harness.previous();harness.generic();template,data=harness.effect_source();need(plan['prior_successful_full_compile_plan']==previous['plan'] and plan['reused_successful_full_assembly']==previous['full_assembly'] and r['full_assembly']==previous['full_assembly'] and r['reused_full_compile_receipt']==pin(harness.FAILED) and plan['unchanged_current_runtime']==harness.prior.display.runtime_checkpoint() and Path(plan['source']['path']).read_bytes()==data,'Exact retained real fullcompile/all5095+409 unchanged inputs, runtime baseline and actual three source bodies')
    check(r['full_assembly']);need([x['phase'] for x in r['phases']]==['compile-one-proven-generic-name-leaf-reader-v2','inspect-exact-three-field-bindings-with-one-proven-name-projection','fifteen-exact-title-leaf-controlled-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'All three corrected helper/ownership/effect phases passed; fullcompile is separately pinned')
    return r,plan

def prepare(test,expected):
    proof=proof_sources();r,t=test_proof(test,expected)
    out=ROOT/'Validation'/('TitleDependencyLeafExactApply-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    plan={'schema':SCHEMA,'status':'prepared_Main_not_modified','fixture':str(out),'runner':pin(Path(__file__)),'slice':pin(SLICE),'successful_test_receipt':pin(test),'successful_test_plan':r['plan'],'sources':proof['sources'],'actual_compiled_assembly':r['full_assembly'],'no_working_login_or_bootstrap_claim':True,'Main_modified':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_apply_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--apply']}))
def execute(path,expected,apply):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed apply plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleDependencyLeafExactApply-'),'Owned exact apply workspace')
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
            check(row['source_meta']);report['applied'].append({'source':pin(source),'meta':pin(meta),'original_method_token':row['byte_edits'][0]['original_method_token']});journal({'event':'replace_verified','source':str(source),'sha256':pin(source)['sha256']})
        for row,source,meta,target,bf,bm in pending:
            need(source.read_bytes()==Path(row['candidate']['path']).read_bytes() and meta.read_bytes()==bm.read_bytes(),'Final complete candidate and original meta bytes')
        report.update(status='exact_original_three_title_leaf_expressions_applied_other_bytes_and_meta_preserved',metas_unchanged=True,all_unrelated_source_bytes_unchanged=True)
    except BaseException as error:
        report.update(status='partial_or_failed_HOLD_no_automatic_reapply' if report['Main_modified'] else 'failed_Main_not_modified',error=repr(error));journal({'event':'HOLD','status':report['status']})
    finally:save(out/'apply-receipt.json',report)
    print(json.dumps({'status':report['status'],'receipt':pin(out/'apply-receipt.json'),'Main_modified':report['Main_modified'],'error':report.get('error')}));return 0 if report['status']=='exact_original_three_title_leaf_expressions_applied_other_bytes_and_meta_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--test-report',type=Path);a.add_argument('--test-report-sha256');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--apply',action='store_true');v=a.parse_args()
    if v.test_report:need(v.test_report_sha256 and not v.plan and not v.apply,'Prepare only from exact successful test receipt');prepare(v.test_report.resolve(strict=True),v.test_report_sha256);return 0
    need(v.plan and v.plan_sha256,'Explicit reviewed apply plan required');return execute(v.plan,v.plan_sha256,v.apply)
if __name__=='__main__':raise SystemExit(main())
