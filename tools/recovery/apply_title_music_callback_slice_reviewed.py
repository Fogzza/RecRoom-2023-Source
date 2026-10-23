"""Prepare, verify, or Root-apply exactly12 tested members in three source files.

No compiler/Unity/player/network launch. Full binding+35 effect receipt is
mandatory. All source/meta backups are durable before the first replacement.
The three writes are journaled, not claimed to be one multi-file transaction.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,os,uuid
import original_shader_pair_editor_conversion as guard
import run_title_music_callback_harness as harness
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
SLICE=harness.SLICE;SLICE_SHA=harness.SLICE_SHA
SCHEMA='reviewed-exact-twelve-original-title-music-member-spans-apply/v1'
TOKENS={'TitleScreenManager::NDENAIFEGGC':'0x060008a8','TitleScreenManager::MLOEPDOPGJD':'0x060008a9','TitleScreenManager::NMJIFHLPFNP':'0x060008aa','TitleScreenManager::KJNOGCGEIHD':'0x060008ab','TitleScreenManager::MDLLPIFKLJO':'0x060008ac','TitleScreenManager/BBOMFKCKKEP::.ctor':'0x060008b9','TitleScreenManager/EPCGHFICLMA::.ctor':'0x060008bf','RRUI.Data.TitleScreenFlowModel::IsInAccountCreationState':'0x06008929','RRUI.Data.TitleScreenFlowModel::IsInChatState':'0x0600892a','RRUI.Data.TitleScreenFlowModel::IsInFeedState':'0x0600892b','RRUI.Data.TitleScreenFlowModel::IsInInterstitialState':'0x0600892d','GONBPKCPFNK<T>::get_CPDFJCCALIA':'0x06011b4d'}
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned source/proof changed: '+row['path'])
def durable(path,data):
    with path.open('xb') as f:f.write(data);f.flush();os.fsync(f.fileno())
def save(path,v):durable(path,(json.dumps(v,indent=2)+'\n').encode())

def proof_sources():
    need(pin(SLICE)['sha256']==SLICE_SHA,'Exact complete native music slice');p,members,subs=harness.candidate();need(set(members)==set(TOKENS),'Only12 exact reviewed original members');p=dict(p);p['sources']=json.loads(json.dumps(p['files']));expected=[WS/'RR23/Assets/Scripts/Assembly-CSharp'/x for x in ['TitleScreenManager.cs','RRUI/Data/TitleScreenFlowModel.cs','GONBPKCPFNK.cs']]
    need([Path(r['source']['path']) for r in p['sources']]==expected,'Only three exact Main source paths')
    for row in p['sources']:
        source=Path(row['source']['path']);need(row['source_meta']['path']==str(source)+'.meta','Exact original source/meta companion');before=source.read_bytes();after=before;previous=-1
        for e in sorted(row['byte_edits'],key=lambda x:x['start']):
            old=base64.b64decode(e['original_base64'],validate=True);need(e['start']>=previous and e['length']==len(old) and before[e['start']:e['start']+len(old)]==old,'Distinct exact original stub spans');previous=e['start']+len(old);e['original_method_token']=TOKENS[e['owner']+'::'+e['member']]
        for e in sorted(row['byte_edits'],key=lambda x:x['start'],reverse=True):after=after[:e['start']]+base64.b64decode(e['replacement_base64'],validate=True)+after[e['start']+e['length']:]
        need(after==Path(row['candidate']['path']).read_bytes(),'All other current source bytes preserved')
    need(sum(len(r['byte_edits']) for r in p['sources'])==12,'Exactly12 source edits');return p

def test_proof(path,expected):
    need(pin(path)['sha256']==expected,'Explicit actual successful12binding/35case receipt');r=json.loads(path.read_bytes());need(r['status']=='actual_full_twelve_music_member_bindings_and_thirty_five_controlled_effect_cases_passed' and r['actual_full_files_compiled'] and r['metadata_binding_verified'] and r['controlled_effect_cases']==35 and r['ushort_predicate_domain_values']==65536 and r['all_Main_sources_and_selected_meta_unchanged'] and not r['Main_modified'] and not r['iterator_playback_or_working_boot_title_login_claimed'],'Actual complete-source compile/original metadata35 cases; no playback claim');check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(p['schema']==harness.SCHEMA and p['runner']==pin(Path(harness.__file__)) and p['slice']==pin(SLICE) and p['source_count']==5095 and p['reference_count']==409 and p['selected_members']==12 and p['effect_cases']==35 and p['test_doubles_are_explicitly_test_only'],'Exact selected native slice and full compiler inputs')
    for k in ['runner','base_runner','runtime_checkpoint_helper','original_attribute_provider','slice','independent_Root_review','template','source','captured_Unity_response','full_response','effect_response','compiler_inputs','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for x in p['effect_references']+json.loads(Path(p['compiler_inputs']['path']).read_bytes()):check(x)
    native,members,subs=harness.candidate();derived,markers=harness.effects_source(members,Path(p['template']['path']));need(derived==Path(p['source']['path']).read_bytes() and {k:hashlib.sha256(v).hexdigest() for k,v in members.items()}==p['exact_candidate_member_sha256'] and {k:hashlib.sha256(v).hexdigest() for k,v in markers.items()}==p['exact_effect_marker_sha256'] and harness.prior.runtime_checkpoint()==p['current_actual_runtime_checkpoint'],'Exact unchanged candidate spans/effects/current actual runtime SDKs');check(r['full_assembly']);need([x['phase'] for x in r['phases']]==['compile-actual-full-twelve-music-member-candidates','compile-exact-music-effects-and-metadata-reader','inspect-twelve-actual-original-music-bindings-metadata-only','thirty-five-exact-music-controlled-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'All four exact suspended-owned phases passed');return r,p

def prepare(test,expected):
    proof=proof_sources();r,t=test_proof(test,expected);out=ROOT/'Validation'/('TitleMusicCallbackExactApply-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();p={'schema':SCHEMA,'status':'prepared_Main_not_modified','fixture':str(out),'runner':pin(Path(__file__)),'slice':pin(SLICE),'independent_Root_review':pin(harness.REVIEW),'successful_test_receipt':pin(test),'successful_test_plan':r['plan'],'sources':proof['sources'],'actual_compiled_assembly':r['full_assembly'],'no_working_music_or_login_or_bootstrap_claim':True,'Main_modified':False};target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_apply_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--apply']}))

def execute(path,expected,apply):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed music apply plan SHA');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleMusicCallbackExactApply-'),'Owned exact apply directory')
    for k in ['runner','slice','independent_Root_review','successful_test_receipt','successful_test_plan','actual_compiled_assembly']:check(p[k])
    need(p['runner']==pin(Path(__file__)) and p['slice']==pin(SLICE),'Exact reviewed apply source/slice');proof=proof_sources();need(p['sources']==proof['sources'],'Only exact tested source/meta/candidate spans');test_proof(Path(p['successful_test_receipt']['path']),p['successful_test_receipt']['sha256'])
    if not apply:print(json.dumps({'status':'verified_no_Main_write','plan_sha256':expected}));return 0
    guard.safety.assert_editor_closed();need(not(out/'apply-receipt.json').exists() and not(out/'journal.jsonl').exists() and not(out/'Backup').exists(),'Fresh one-shot apply, no automatic retry')
    report={'schema':SCHEMA,'status':'starting','plan':pin(path),'Main_modified':False,'applied':[],'metas_unchanged':False,'all_unrelated_source_bytes_unchanged':False,'compiler_Unity_game_network_executed':False,'working_music_login_or_bootstrap_claimed':False}
    def journal(event):
        with (out/'journal.jsonl').open('ab') as f:f.write((json.dumps({'utc':dt.datetime.now(dt.timezone.utc).isoformat(),**event})+'\n').encode());f.flush();os.fsync(f.fileno())
    try:
        backup=out/'Backup';backup.mkdir();pending=[]
        for i,row in enumerate(p['sources']):
            for k in ['source','source_meta','candidate']:check(row[k])
            source=Path(row['source']['path']);meta=Path(row['source_meta']['path']);bf=backup/(str(i)+'-'+source.name);bm=backup/(str(i)+'-'+meta.name);durable(bf,source.read_bytes());durable(bm,meta.read_bytes());target=out/('pending-'+str(i)+'.cs');durable(target,Path(row['candidate']['path']).read_bytes());need(pin(bf)['sha256']==row['source']['sha256'] and pin(bm)['sha256']==row['source_meta']['sha256'] and pin(target)['sha256']==row['candidate']['sha256'],'Durable exact backups and pending candidates');pending.append((row,source,meta,target,bf,bm))
        report['backups']=[{'source':pin(x[4]),'meta':pin(x[5])} for x in pending];journal({'event':'all_three_source_and_meta_backups_verified_before_any_write'})
        for row,source,meta,target,bf,bm in pending:
            check(row['source']);check(row['source_meta']);check(row['candidate']);journal({'event':'replace_intent','source':str(source),'before_sha256':row['source']['sha256'],'after_sha256':row['candidate']['sha256']});os.replace(target,source);report['Main_modified']=True;need(pin(source)['sha256']==row['candidate']['sha256'],'Exact full source after replacement');check(row['source_meta']);report['applied'].append({'source':pin(source),'meta':pin(meta),'original_method_tokens':[e['original_method_token'] for e in row['byte_edits']]});journal({'event':'replace_verified','source':str(source),'sha256':pin(source)['sha256']})
        for row,source,meta,target,bf,bm in pending:need(source.read_bytes()==Path(row['candidate']['path']).read_bytes() and meta.read_bytes()==bm.read_bytes(),'All three complete candidates and original meta bytes')
        report.update(status='twelve_exact_original_title_music_members_applied_other_bytes_and_metas_preserved',metas_unchanged=True,all_unrelated_source_bytes_unchanged=True,changed_method_bodies=12,changed_source_files=3)
    except BaseException as error:report.update(status='partial_or_failed_HOLD_no_automatic_reapply' if report['Main_modified'] else 'failed_Main_not_modified',error=repr(error));journal({'event':'HOLD','status':report['status']})
    finally:save(out/'apply-receipt.json',report)
    print(json.dumps({'status':report['status'],'receipt':pin(out/'apply-receipt.json'),'Main_modified':report['Main_modified'],'error':report.get('error')}));return 0 if report['status']=='twelve_exact_original_title_music_members_applied_other_bytes_and_metas_preserved' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--test-report',type=Path);a.add_argument('--test-report-sha256');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--apply',action='store_true');v=a.parse_args()
    if v.test_report:need(v.test_report_sha256 and not v.plan and not v.apply,'Prepare only from exact successful test receipt');prepare(v.test_report.resolve(strict=True),v.test_report_sha256);return 0
    need(v.plan and v.plan_sha256,'Explicit reviewed exact apply plan required');return execute(v.plan,v.plan_sha256,v.apply)
if __name__=='__main__':raise SystemExit(main())
