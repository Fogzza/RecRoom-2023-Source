"""Prepare or Root-run twelve original music members: full binding +35 effects.

Default preparation reads/pins files and emits isolated test sources only.
Only Root may run the managed compiler and explicit controlled-effect model.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,shutil,uuid
import run_title_login_slice_harness_v3 as base
import run_title_display_callback_harness as prior
from run_title_login_slice_harness_v3 import guard,pin,need,save,check,HERE,WS,ROOT,EDITOR,RESPONSE
SLICE=ROOT/'Validation/TitleMusicCallbackSlice-20261023T095759Z-8abf107f/report.json'
SLICE_SHA='f26f0406e99efa72044d99fd14b8ae629c4257175c298433ffad33957bcc86b9'
ORIGINAL=ROOT/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll'
ORIGINAL_SHA='15cbc3614b2986da2813cfc82b640199029d8a9b5a60fd8f42db2bdaee7ea9fe'
SCHEMA='prepared-original-twelve-title-music-member-full-binding-effects/v1'
REVIEW=ROOT/'Validation/TitleMusicIndependentSemanticReview-20261023T100543Z-f67817b1/report.json'
REVIEW_SHA='bda999405491925867fb2f1ca28d678ea02a8fbf1e842079625ebcd84cdbc88b'

def candidate():
    need(pin(SLICE)['sha256']==SLICE_SHA and pin(ORIGINAL)['sha256']==ORIGINAL_SHA and pin(REVIEW)['sha256']==REVIEW_SHA,'Frozen complete music slice, independent Root semantic review and exact original attribute-provider metadata');r=json.loads(SLICE.read_bytes());review=json.loads(REVIEW.read_bytes());need(review['status']=='Root_independent_complete988B_semantic_review_passed_binding_effects_still_required' and review['slice']==pin(SLICE),'Recorded independent whole-caller review is necessary but does not replace binding/effects')
    need(r['status']=='twelve_original_members_staged_full_binding_effects_UNVERIFIED' and r['staged_member_count']==12 and len(r['files'])==3 and len(r['eight_complete_native_shapes'])==8 and len(r['native_single_byte_negative_controls'])==735 and all(x['rejected'] for x in r['native_single_byte_negative_controls']) and r['state_getter_field_layout']['calculated_closed_offsets']==[16,24,32,40,42,44,46,48,56],'Exact narrow complete native music dependencies')
    for key in ['original_music_988B_join_proof','eight_dependency_join_proof','producer']:check(r[key])
    members={};substitutions={}
    for file in r['files']:
        for key in ['source','source_meta','candidate']:check(file[key])
        before=Path(file['source']['path']).read_bytes();after=before
        for e in sorted(file['byte_edits'],key=lambda x:x['start'],reverse=True):
            old=base64.b64decode(e['original_base64'],validate=True);new=base64.b64decode(e['replacement_base64'],validate=True);at=e['start'];need(e['length']==len(old) and before[at:at+len(old)]==old,'Exact current music stub span');after=after[:at]+new+after[at+len(old):];key=e['owner']+'::'+e['member'];need(key not in members,'Only one exact selected member');members[key]=new
        need(after==Path(file['candidate']['path']).read_bytes(),'All bytes outside exact12 original stub spans preserved');substitutions[file['source']['path'].casefold()]=Path(file['candidate']['path'])
    need(len(members)==12,'Exactly12 unchanged original candidate spans');return r,members,substitutions

def effects_source(members,template):
    text=template.read_bytes();markers={}
    for name in ['IsInAccountCreationState','IsInChatState','IsInFeedState','IsInInterstitialState']:markers['EXACT_'+name]=members['RRUI.Data.TitleScreenFlowModel::'+name]
    for name in ['BBOMFKCKKEP','EPCGHFICLMA']:markers['EXACT_'+name+'_ctor']=members['TitleScreenManager/'+name+'::.ctor']
    markers['EXACT_TITLE_MUSIC_METHODS']=b'\r\n'.join(members['TitleScreenManager::'+n] for n in ['NDENAIFEGGC','MLOEPDOPGJD','NMJIFHLPFNP','KJNOGCGEIHD','MDLLPIFKLJO']);markers['EXACT_STATE_EXPRESSION']=members['GONBPKCPFNK<T>::get_CPDFJCCALIA']
    for key,value in markers.items():token=('/*'+key+'*/').encode();need(text.count(token)==1,'One verbatim original source marker '+key);text=text.replace(token,value)
    need(b'/*EXACT_' not in text,'No unexpanded original body marker');return text,markers

def prepare():
    r,members,substitutions=candidate();runtime=prior.runtime_checkpoint();out=ROOT/'Validation'/('TitleMusicCallbackBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    captured=out/'Unity-emitted-WindowsDevelopment-Assembly-CSharp.rsp';shutil.copyfile(RESPONSE,captured);text,inputs=base.response(captured.read_text(encoding='utf-8-sig'),out/'Assembly-CSharp.dll',substitutions);rsp=out/'full-music-candidate-binding.rsp';rsp.write_text(text,encoding='utf-8',newline='\n');manifest=out/'full-compiler-inputs.json';save(manifest,inputs)
    template=HERE/'TitleMusicCallbackEffects.template.cs';data,markers=effects_source(members,template);source=out/'ExactMusicControlledEffects.cs';source.write_bytes(data)
    refs=[EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'/x for x in ['mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll']]+[WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll'];shutil.copyfile(refs[-1],out/'Mono.Cecil.dll');fx=out/'controlled-effects.rsp';fx.write_text('/nologo\n/nostdlib+\n/target:exe\n/langversion:8.0\n/out:"'+str(out/'ExactMusicControlledEffects.exe')+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n',encoding='utf-8')
    p={'schema':SCHEMA,'status':'prepared_no_compiler_or_test_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'runtime_checkpoint_helper':pin(Path(prior.__file__)),'original_attribute_provider':pin(ORIGINAL),'slice':pin(SLICE),'independent_Root_review':pin(REVIEW),'current_actual_runtime_checkpoint':runtime,'template':pin(template),'source':pin(source),'captured_Unity_response':pin(captured),'full_response':pin(rsp),'effect_response':pin(fx),'compiler_inputs':pin(manifest),'effect_references':[pin(x) for x in refs],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'full_compile_cap_bytes':1024**3,'helper_and_effect_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'source_count':sum(not x.startswith('/') for x in text.splitlines()),'reference_count':sum(x.startswith('/reference:') for x in text.splitlines()),'exact_candidate_member_sha256':{k:hashlib.sha256(v).hexdigest() for k,v in members.items()},'exact_effect_marker_sha256':{k:hashlib.sha256(v).hexdigest() for k,v in markers.items()},'selected_members':12,'effect_cases':35,'ushort_predicate_domain_values':65536,'test_doubles_are_explicitly_test_only':True,'Main_modified':False,'iterator_playback_or_working_boot_claimed':False};need(p['source_count']==5095 and p['reference_count']==409 and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA,'Exact full-source compiler/guard scope');target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed12 music member harness plan SHA');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleMusicCallbackBindingEffects-'),'Exact isolated music fixture')
    for k in ['runner','base_runner','runtime_checkpoint_helper','original_attribute_provider','slice','independent_Root_review','template','source','captured_Unity_response','full_response','effect_response','compiler_inputs','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for row in p['effect_references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['base_runner']==pin(Path(base.__file__)) and p['runtime_checkpoint_helper']==pin(Path(prior.__file__)) and p['original_attribute_provider']['sha256']==ORIGINAL_SHA and p['selected_members']==12 and p['effect_cases']==35 and p['ushort_predicate_domain_values']==65536 and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA and p['full_compile_cap_bytes']==1024**3 and p['helper_and_effect_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Exact reviewed inputs/owned resource limits');need(prior.runtime_checkpoint()==p['current_actual_runtime_checkpoint'],'Fresh actual current SDK DLL/meta baseline');r,members,substitutions=candidate();need({k:hashlib.sha256(v).hexdigest() for k,v in members.items()}==p['exact_candidate_member_sha256'],'Exact12 original candidate member bytes');derived,markers=effects_source(members,Path(p['template']['path']));need(derived==Path(p['source']['path']).read_bytes() and {k:hashlib.sha256(v).hexdigest() for k,v in markers.items()}==p['exact_effect_marker_sha256'],'Effects use unchanged exact candidate bytes');inputs=json.loads(Path(p['compiler_inputs']['path']).read_bytes())
    for x in inputs:check(x)
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected}));return 0
    need(all(not(out/x).exists() for x in ['run-report.json','Assembly-CSharp.dll','ExactMusicControlledEffects.exe']),'Fresh one-shot Root fixture');report={'schema':'guarded-original-twelve-title-music-member-full-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Unity_network_or_production_game_code_executed':False,'iterator_playback_or_working_boot_title_login_claimed':False}
    try:
        guard.CAP=p['full_compile_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['full_response']['path']],out,'compile-actual-full-twelve-music-member-candidates',report);report['full_assembly']=pin(out/'Assembly-CSharp.dll')
        guard.CAP=p['helper_and_effect_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['effect_response']['path']],out,'compile-exact-music-effects-and-metadata-reader',report)
        guard.bounded([p['mono']['path'],str(out/'ExactMusicControlledEffects.exe'),'--inspect',str(out/'Assembly-CSharp.dll'),p['original_attribute_provider']['path']],out,'inspect-twelve-actual-original-music-bindings-metadata-only',report)
        guard.bounded([p['mono']['path'],str(out/'ExactMusicControlledEffects.exe')],out,'thirty-five-exact-music-controlled-effects',report)
        for x in inputs:check(x)
        candidate();need(prior.runtime_checkpoint()==p['current_actual_runtime_checkpoint'],'Actual runtime SDKs unchanged after test');report.update(status='actual_full_twelve_music_member_bindings_and_thirty_five_controlled_effect_cases_passed',actual_full_files_compiled=True,metadata_binding_verified=True,controlled_effect_cases=35,ushort_predicate_domain_values=65536,all_Main_sources_and_selected_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_full_twelve_music_member_bindings_and_thirty_five_controlled_effect_cases_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without children');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
