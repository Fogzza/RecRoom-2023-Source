"""Prepare or Root-run exact-owner compilation and 17 controlled effects.

Only three proved members are compiled in narrow donor contexts. Full original
plugins are read as metadata to verify owners/fields/signatures. Donor DLLs are
never loaded or applied; execution uses separately named test-only Unity effects.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROOF=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207/SingletonDisposedMembers-20261023T065855Z-c81ffded/report.json'
PROOF_SHA='a073ef5183c9d554509ae16689595bcb7981627e4328a50c7682d4c5c131b48a'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor'
SCHEMA='prepared-three-original-startup-member-binding-controlled-effects/v2'
PRIOR=ROOT/'Validation/StartupThreeMemberBindingEffects-20261023T070937Z-81c60f98'
PRIOR_RECEIPT_SHA='5b6f4b0f3955795522c3e55a265cd220072d3a142002b6854176def672791c97'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned startup binding/effect input changed: '+row['path'])
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def members():
    need(pin(PROOF)['sha256']==PROOF_SHA,'Frozen original semantic proof required');proof=json.loads(PROOF.read_bytes());need(len(proof['members'])==2 and len(proof['negative_controls'])==12,'Exact three proved member slice')
    rows=proof['members']
    for row in rows:check(row)
    singleton=Path(rows[0]['path']).read_bytes();disposed=Path(rows[1]['path']).read_bytes()
    need(rows[0]['sha256']=='42d65058faaaa05f2186f006aa3235e0204533c54e7d9941cdca8c85456ada02' and rows[1]['sha256']=='f52752a1f9a32924b1bc93b2c640cb30267cecb9a5b5140985e1a5a5ab134871','Exact original-owner C# member bytes')
    return proof,singleton,disposed
def prepare():
    proof,singleton,disposed=members();need(pin(HERE/'original_shader_pair_editor_conversion.py')['sha256']==GUARD_SHA and pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCH_SHA,'Reviewed owned helper guard')
    out=ROOT/'Validation'/('StartupThreeMemberBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    source1=out/'SingletonOriginalOwnerDonor.cs';source1.write_bytes(b'// Exact original owner, field, base and generic constraint; only two selected bodies.\npublic class SingletonMonoBehaviour<T> : UnityEngine.MonoBehaviour where T : SingletonMonoBehaviour<T>\n{\n    private static T CMDPMJBEBAB;\n'+singleton+b'\n}\n')
    source2=out/'DisposedOriginalOwnerDonor.cs';source2.write_bytes(b'// Exact original owner and method signature; only the selected disposed guard.\npublic static class MKECFLEMHEL\n{\n'+disposed+b'\n}\n')
    template=HERE/'StartupSingletonDisposedEffects.v2.template.cs';data=template.read_bytes()
    for marker,value in [(b'/*EXACT_SINGLETON_MEMBERS*/',singleton),(b'/*EXACT_DISPOSED_MEMBER*/',disposed)]:need(data.count(marker)==1,'Unique exact controlled-body insertion');data=data.replace(marker,value)
    effect=out/'ExactStartupMemberControlledEffects.cs';effect.write_bytes(data)
    mono=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[mono/name for name in ['mscorlib.dll','System.dll','System.Core.dll']]
    unity=EDITOR/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed/UnityEngine.CoreModule.dll';cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';facade=mono/'Facades/netstandard.dll';shutil.copyfile(cecil,out/'Mono.Cecil.dll')
    def rsp(name,source,output,refs,kind):
        path=out/name;path.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(p)+'"\n' for p in refs)+'"'+str(source)+'"\n',encoding='utf-8',newline='\n');return pin(path)
    donor1=out/'RecRoom.Datastructures.Singletons.Runtime.dll';donor2=out/'UJect.Runtime.dll';exe=out/'ExactStartupMemberControlledEffects.exe'
    responses=[rsp('singleton-donor.rsp',source1,donor1,framework+[unity],'library'),rsp('disposed-donor.rsp',source2,donor2,framework,'library'),rsp('controlled-effects.rsp',effect,exe,framework+[cecil,facade],'exe')]
    originals=[{'assembly':name,**pin(WS/'RR23/Assets/Plugins'/name),'meta':pin(WS/'RR23/Assets/Plugins'/(name+'.meta'))} for name in ['RecRoom.Datastructures.Singletons.Runtime.dll','UJect.Runtime.dll']]
    current=[pin(WS/'RR23/Assets/Scripts/Assembly-CSharp'/name) for name in ['RecRoomGameRoot.cs','TitleScreenManager.cs','RRUI/Data/TitleScreenFlowModel.cs']]
    p={'schema':SCHEMA,'status':'prepared_no_compiler_or_effect_test_started','fixture':str(out),'runner':pin(Path(__file__)),'proof':pin(PROOF),'members':proof['members'],'template':pin(template),'sources':[pin(source1),pin(source2),pin(effect)],'responses':responses,'references':[pin(p) for p in framework+[unity,cecil,facade]],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'original_modules':originals,'current_source_checkpoint':current,'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'donor_outputs':[str(donor1),str(donor2)],'effect_output':str(exe),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'controlled_effect_cases':17,'production_donor_DLLs_executed':False,'Main_writes':False,'body_import_or_apply_performed':False,'entire_original_modules_rebuilt':False,'game_boot_or_login_claimed':False}
    need(pin(PRIOR/'run-report.json')['sha256']==PRIOR_RECEIPT_SHA,'Exact preserved first failure required');prior=json.loads((PRIOR/'run-report.json').read_bytes());check(prior['plan']);oldplan=json.loads(Path(prior['plan']['path']).read_bytes())
    need(prior['status']=='failed_or_guard_refused_preserve_outputs' and [x['phase'] for x in prior['phases'][:2]]==['compile-exact-Singleton-owner-donor','compile-exact-disposed-owner-donor'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in prior['phases'][:2]),'Both exact donor compiles passed in preserved run')
    need(oldplan['proof']==p['proof'] and oldplan['members']==p['members'] and oldplan['references']==p['references'] and oldplan['compiler']==p['compiler'] and oldplan['original_modules']==p['original_modules'],'Exact reused donor compiler/references/targets')
    for before,after in zip(oldplan['sources'][:2],p['sources'][:2]):check(before);need(before['bytes']==after['bytes'] and before['sha256']==after['sha256'],'Reused donor source byte equality')
    for row in oldplan['responses'][:2]:check(row)
    p.update(prior_failure_receipt=pin(PRIOR/'run-report.json'),prior_successful_donor_compile_plan=prior['plan'],reused_compiled_donors=[pin(Path(x)) for x in oldplan['donor_outputs']],donor_outputs=oldplan['donor_outputs'],Csc_reference_cast_encoding='unbox.any !0 with exact original reference constraint; equivalent checked reference cast, not value-type unboxing')
    target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed startup test plan hash required');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('StartupThreeMemberBindingEffects-'),'Exact owned isolated test output')
    need(p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and p['controlled_effect_cases']==17,'Fixed pure helper bounds')
    for row in [p[k] for k in ['runner','proof','template','copied_Cecil','compiler','mono','guard','launcher','prior_failure_receipt','prior_successful_donor_compile_plan']]+p['reused_compiled_donors']+p['members']+p['sources']+p['responses']+p['references']+p['current_source_checkpoint']:check(row)
    for row in p['original_modules']:check({k:row[k] for k in ['path','bytes','sha256']});check(row['meta'])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed runner/owned guard')
    members()
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':digest,'member_count':3,'effect_cases':17}));return 0
    need(not(out/'run-report.json').exists() and not Path(p['effect_output']).exists(),'Fresh one-shot owned outputs; preserve prior failures')
    report={'schema':'guarded-three-original-startup-members-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'reused_successful_donor_compile_receipt':p['prior_failure_receipt'],'reused_successful_donors':p['reused_compiled_donors'],'Main_modified':False,'production_donor_DLLs_executed':False,'game_or_Unity_or_network_invoked':False,'body_import_or_apply_performed':False,'working_boot_or_login_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][2]['path']],out,'compile-explicit-controlled-effects-reader-v2',report)
        guard.bounded([p['mono']['path'],p['effect_output'],'--inspect',p['original_modules'][0]['path'],p['donor_outputs'][0],p['original_modules'][1]['path'],p['donor_outputs'][1]],out,'inspect-three-original-metadata-bindings',report)
        guard.bounded([p['mono']['path'],p['effect_output']],out,'seventeen-exact-member-controlled-effects',report)
        for row in p['original_modules']:check({k:row[k] for k in ['path','bytes','sha256']});check(row['meta'])
        for row in p['current_source_checkpoint']:check(row)
        report.update(status='three_exact_owner_bindings_and_seventeen_controlled_effect_cases_passed',compiled_donors=[pin(Path(x)) for x in p['donor_outputs']],compiled_effects=pin(Path(p['effect_output'])),controlled_effect_cases=17,exact_original_metadata_binding=True,all_selected_Main_sources_plugins_metas_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='three_exact_owner_bindings_and_seventeen_controlled_effect_cases_passed' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan hash required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare without children first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
