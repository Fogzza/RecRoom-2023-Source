"""Prepare or Root-run eight original member bindings and 26 controlled cases.

Selected donor source bytes are unchanged native-proved fragments. Only the
separately named controlled-effects executable runs; production SDKs/donors
are read as metadata. Unrecovered providers, logger and child factory remain
explicit test-only dependencies, not recovered game implementations.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROOF=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207/LowerContainerDonors-20261023T080043Z-b8287e09/report.json'
PROOF_SHA='38dcf22930824a65aa35f25757afed84161b141ff66a5aba30068178fbde96e7'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor';SCHEMA='prepared-eight-lower-container-member-bindings-controlled-effects/v3'
CTOR=ROOT/'Validation/ServiceContainerCtorCFG-20261022T181322Z-c199a46d/report.json'
CTOR_SHA='87a0159a74f277bc970c34eb1080ec1770ddf5048ab7a86793c114545b3252c0'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):
    need(set(row) in ({'path','sha256'},{'path','sha256','format'},{'path','bytes','sha256'}),'Exact legacy/current pin schema');actual=pin(row['path']);need(all(actual[k]==v for k,v in row.items() if k!='format'),'Pinned lower-member input changed: '+row['path'])
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def proof():
    need(pin(PROOF)['sha256']==PROOF_SHA,'Frozen eight original member-source proof');p=json.loads(PROOF.read_bytes());need(len(p['selected_members'])==8 and p['all_selected_source_fragments_inserted_verbatim'] and p['unselected_helper_bodies_explicitly_throw_and_never_imported'],'Exact selected slice and explicit dependency boundary')
    for row in p['donor_sources']+p['input_member_fragments']:check(row)
    check(p['original_seven_member_proof']);check(p['original_resolver_proof']);original=json.loads(Path(p['original_seven_member_proof']['path']).read_bytes())
    for row in original['prior_complete_CFG_proofs']:check({'path':row['path'],'bytes':Path(row['path']).stat().st_size,'sha256':row['sha256']})
    return p
def prepare():
    p=proof();need(pin(CTOR)['sha256']==CTOR_SHA,'Original constructor access metadata authority');ctor=json.loads(CTOR.read_bytes());need(ctor['original']['index']==47895 and ctor['original']['flags']==6275 and ctor['original']['impl_flags']==0,'Original MethodDef0600002A is Assembly/internal, not private');out=ROOT/'Validation'/('ContainerLowerBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    files={Path(x['path']).name:x for x in p['input_member_fragments']};template=HERE/'ContainerLowerEffects.template.cs';data=template.read_bytes()
    mapping={'EXACT_CONTAINER_CTORS':'MNALHHOLFGL.members.cs','EXACT_KEY_CTOR':'CPAMAFPANDM.members.cs','EXACT_AUX_CTOR':'OENEDGPIOFN.members.cs','EXACT_INITIALIZATION_MEMBERS':'MPAAIECKLGA.members.cs','EXACT_RESOLVER':'MNALHHOLFGL.resolver.member.cs'}
    for marker,name in mapping.items():
        token=('/*'+marker+'*/').encode();need(data.count(token)==1,'One exact source insertion '+marker);data=data.replace(token,Path(files[name]['path']).read_bytes())
    declaration=b'private MNALHHOLFGL(MNALHHOLFGL DDFCHDGPJBN, string LGENGCEEBPB)';replacement=b'internal MNALHHOLFGL(MNALHHOLFGL DDFCHDGPJBN, string LGENGCEEBPB)';need(data.count(declaration)==1,'Unique selected constructor declaration correction');data=data.replace(declaration,replacement)
    guard_source=HERE/'RecoveredDisposedGuardDonor.cs';text=guard_source.read_text().split('public static class MKECFLEMHEL\n{\n',1)[1].rsplit('\n}\n',1)[0];need(data.count(b'/*EXACT_DISPOSED_GUARD*/')==1,'Exact previously tested disposed dependency');data=data.replace(b'/*EXACT_DISPOSED_GUARD*/',text.encode());effect=out/'ExactContainerLowerControlledEffects.cs';effect.write_bytes(data)
    source1=out/'UjectLowerOriginalOwnerDonor.cs';source2=out/'InitializationLowerOriginalOwnerDonor.cs';source1.write_bytes(Path(p['donor_sources'][0]['path']).read_bytes());source2.write_bytes(Path(p['donor_sources'][1]['path']).read_bytes())
    original_donor=source1.read_bytes();need(original_donor.count(declaration)==1,'Unique donor declaration correction');source1.write_bytes(original_donor.replace(declaration,replacement));fixed=HERE/'RecoveredUjectContainerLowerDonor.v3.cs'
    if fixed.exists():need(fixed.read_bytes()==source1.read_bytes(),'Preserve reviewed corrected donor')
    else:
        with fixed.open('xb') as f:f.write(source1.read_bytes())
    mono=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[mono/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];facade=mono/'Facades/netstandard.dll';unity=EDITOR/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed/UnityEngine.CoreModule.dll';cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';shutil.copyfile(cecil,out/cecil.name)
    external=[WS/'RR23/CompilerSupport/References'/x for x in ['RecRoom.AgInitialization.Interfaces.dll','RecRoom.Debugging.Runtime.dll','RecRoom.NoEngine.Common.Runtime.dll']];donor1=out/'UJect.Runtime.dll';donor2=out/'RecRoom.AgInitialization.Runtime.dll';effectout=out/'ExactContainerLowerControlledEffects.exe'
    def rsp(name,src,target,refs,kind):
        f=out/name;f.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(target)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(src)+'"\n',encoding='utf-8',newline='\n');return pin(f)
    responses=[rsp('uject-donor.rsp',source1,donor1,framework,'library'),rsp('initialization-donor.rsp',source2,donor2,framework+[unity]+external+[donor1],'library'),rsp('controlled-effects.rsp',effect,effectout,framework+[cecil,facade],'exe')]
    originals=[{'DLL':pin(WS/'RR23/Assets/Plugins'/name),'meta':pin(WS/'RR23/Assets/Plugins'/(name+'.meta'))} for name in ['UJect.Runtime.dll','RecRoom.AgInitialization.Runtime.dll']]
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'proof':pin(PROOF),'template':pin(template),'sources':[pin(source1),pin(source2),pin(effect)],'selected_fragments':p['input_member_fragments'],'reviewable_donor_sources':[pin(fixed),p['donor_sources'][1]],'constructor_access_metadata_authority':pin(CTOR),'source_amendment':'Only selected two-argument ctor declaration private becomes internal/Assembly, matching original flags6275. Entire constructor body and all seven other selected members unchanged.','disposed_dependency_source':pin(guard_source),'responses':responses,'references':[pin(x) for x in framework+[facade,unity,cecil]+external],'copied_Cecil':pin(out/cecil.name),'original_modules':originals,'donor_outputs':[str(donor1),str(donor2)],'effect_output':str(effectout),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'selected_member_count':8,'controlled_effect_cases':26,'Main_modified':False,'production_modules_executed':False,'working_boot_or_provider_graph_claimed':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed bounded owned-job guard');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    need(pin(path)['sha256']==digest,'Explicit reviewed eight-member plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerLowerBindingEffects-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and p['selected_member_count']==8 and p['controlled_effect_cases']==26,'Exact finite bounded member scope')
    for key in ['runner','proof','template','disposed_dependency_source','copied_Cecil','compiler','mono','guard','launcher','constructor_access_metadata_authority']:check(p[key])
    for row in p['sources']+p['selected_fragments']+p['reviewable_donor_sources']+p['responses']+p['references']:check(row)
    for row in p['original_modules']:check(row['DLL']);check(row['meta'])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed runner/guards');proof()
    if not run:print(json.dumps({'status':'verified_no_child_started','selected_members':8,'controlled_effect_cases':26}));return 0
    need(not(out/'run-report.json').exists() and all(not Path(x).exists() for x in p['donor_outputs']+[p['effect_output']]),'Fresh one-shot outputs only; preserve failures')
    report={'schema':'guarded-eight-original-lower-container-bindings-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'production_modules_executed':False,'Unity_game_or_network_launched':False,'working_boot_or_provider_graph_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        for i,name in enumerate(['compile-eight-member-Uject-donor','compile-eight-member-initialization-donor','compile-explicit-lower-member-effects-reader']):guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][i]['path']],out,name,report)
        guard.bounded([p['mono']['path'],p['effect_output'],'--inspect',p['original_modules'][0]['DLL']['path'],p['donor_outputs'][0],p['original_modules'][1]['DLL']['path'],p['donor_outputs'][1]],out,'inspect-eight-original-member-bindings',report)
        guard.bounded([p['mono']['path'],p['effect_output']],out,'twenty-six-original-lower-member-controlled-effects',report)
        for row in p['original_modules']:check(row['DLL']);check(row['meta'])
        report.update(status='eight_original_member_bindings_and_twenty_six_controlled_cases_passed',compiled_donors=[pin(x) for x in p['donor_outputs']],compiled_effects=pin(p['effect_output']),controlled_effect_cases=26,selected_member_count=8)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='eight_original_member_bindings_and_twenty_six_controlled_cases_passed' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit plan SHA required');return execute(v.plan.resolve(strict=True),v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
