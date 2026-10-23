"""Prepare or Root-run one original lookup binding and20 controlled effects.

Pins Root's exact four-body-applied SDK baseline. Original SDK and thin donor
are metadata-only. LNF, CPBM and the provider getter execute only as explicitly
named controlled boundaries; this proves neither providers nor working boot.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,uuid
import original_shader_pair_editor_conversion as guard
from audit_boot_candidate_dependency_closure import module_methods
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROOF=ROOT/'Validation/LiveLookupMember-20261023T091845Z-0c963d0d/report.json'
PROOF_SHA='0d885b1674cda84718ddb7557f4db0f4ccff3b0c05c856ac85d0333b726a39fa'
APPLY=ROOT/'Validation/ContainerKeyChildExactApply-20261023T092636Z-6f0addc4/apply-receipt.json'
APPLY_SHA='b7a6f206834ba24175d6da1cf48d98f5f6643e484439e076140d74545b2b27c8'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor';SCHEMA='prepared-original-reference-constrained-container-lookup-binding-effects/v1'
def need(value,message):
    if not value:raise ValueError(message)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned lookup input changed: '+row['path'])
def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')
def proof():
    need(pin(PROOF)['sha256']==PROOF_SHA and pin(APPLY)['sha256']==APPLY_SHA,'Exact native lookup proof and Root four-body SDK baseline');p=json.loads(PROOF.read_bytes());applied=json.loads(APPLY.read_bytes())
    need(p['status']=='complete_original_lookup_caller_candidate_binding_effects_and_provider_closure_pending' and p['complete_shape']['all350_native_bytes_and_CFG_edges_checked'] and p['complete_shape']['provider_interface_invoke_slot']==0 and p['original']['index']==47883 and p['original']['flags']==131 and p['original_generic_parameter']['flags']==4 and p['original_provider_method']['index']==47936,'Exact closed350-byte internal reference-constrained caller and slot0 object-return provider')
    need(len(p['negative_controls'])==350 and all(x['rejected'] for x in p['negative_controls']),'All350 native single-byte controls rejected')
    for key in ['producer','typed_join_authority','candidate']:check(p[key])
    need(applied['status']=='four_native_key_child_bodies_applied_one_SDK_meta_preserved' and applied['changed_method_bodies']==4 and applied['metas_unchanged'] and len(applied['applied'])==1,'Only the exact applied four-body checkpoint may be current SDK baseline');baseline=applied['applied'][0];check(baseline['source']);check(baseline['meta']);need(Path(baseline['source']['path'])==WS/'RR23/Assets/Plugins/UJect.Runtime.dll','Exact current SDK scope')
    return p,baseline
def prepare():
    p,baseline=proof();member=Path(p['candidate']['path']).read_text();fixed=HERE/'RecoveredContainerLookupMember.cs'
    if fixed.exists():need(fixed.read_text()==member,'Never overwrite readable exact native-proven lookup member')
    else:
        with fixed.open('x',encoding='utf-8',newline='\n') as f:f.write(member)
    donor='''// Thin original-owner context only; never import declarations/stubs wholesale.
using System;
public interface NJAICAFMPBE { object AIKLEKDPIFH(); }
public struct CPAMAFPANDM { public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;} }
public sealed class MNALHHOLFGL
{
    private bool KBDIBPJIHNN;
'''+member+'''
    public void LNFNAIMOFOF(){throw new NotImplementedException("Unselected original preparation context");}
    private bool CPBMOKFMMMK<TType>(CPAMAFPANDM key,out NJAICAFMPBE provider) {throw new NotImplementedException("Unselected original provider discovery context");}
}
internal static class MKECFLEMHEL
{
    public static void GFKAFPHLKMJ(bool condition,string message){throw new NotImplementedException("Unselected original disposed guard context");}
}
'''
    fixed_donor=HERE/'RecoveredContainerLookupDonor.v2.cs'
    if fixed_donor.exists():need(fixed_donor.read_text()==donor,'Preserve original-owner donor')
    else:
        with fixed_donor.open('x',encoding='utf-8',newline='\n') as f:f.write(donor)
    out=ROOT/'Validation'/('ContainerLookupBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=out/'OriginalOwnerLookupDonor.cs';source.write_bytes(fixed_donor.read_bytes());template=HERE/'ContainerLookupEffects.v2.template.cs';effects=template.read_bytes();token=b'/*EXACT_LOOKUP_MEMBER*/';need(effects.count(token)==1,'One exact lookup insertion');effects=effects.replace(token,member.encode());guard_source=HERE/'RecoveredDisposedGuardDonor.cs';guard_text=guard_source.read_text().split('public static class MKECFLEMHEL\n{\n',1)[1].rsplit('\n}\n',1)[0];token=b'/*EXACT_TESTED_DISPOSED_GUARD*/';need(effects.count(token)==1,'One exact previously tested disposed guard insertion');effects=effects.replace(token,guard_text.encode());effectsource=out/'ExactContainerLookupControlledEffects.cs';effectsource.write_bytes(effects)
    api=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[api/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';facade=api/'Facades/netstandard.dll';copied=out/'Mono.Cecil.dll';copied.write_bytes(cecil.read_bytes());need(pin(copied)['sha256']==pin(cecil)['sha256'],'Exact metadata-only reader dependency');donorout=out/'UJect.Runtime.dll';effectout=out/'ExactContainerLookupControlledEffects.exe';responses=[]
    for name,src,target,refs,kind in [('lookup-donor',source,donorout,framework,'library'),('lookup-effects-reader',effectsource,effectout,framework+[cecil,facade],'exe')]:
        response=out/(name+'.rsp');response.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(target)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(src)+'"\n',encoding='utf-8',newline='\n');responses.append(pin(response))
    current=module_methods(Path(baseline['source']['path']),[{'owner':'MNALHHOLFGL','name':'NGBMOPMLJCM','parameters':2,'generic':1}]);need(len(current)==1 and current[0]['flags']==131 and current[0]['generic_arity']==1 and current[0]['current_CLI_token_not_original_native']=='0x0600001e','Exact current selected original MethodDef contract')
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'proof':pin(PROOF),'Root_four_body_apply':pin(APPLY),'native_member':p['candidate'],'readable_member':pin(fixed),'reviewable_donor_source':pin(fixed_donor),'template':pin(template),'sources':[pin(source),pin(effectsource)],'tested_disposed_guard_source':pin(guard_source),'responses':responses,'references':[pin(x) for x in framework+[cecil,facade]],'copied_Cecil':pin(copied),'original_plugin':baseline['source'],'original_meta':baseline['meta'],'exact_current_selected_method':current[0],'donor_output':str(donorout),'effects_output':str(effectout),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'selected_members':1,'controlled_cases':20,'actual_NGB_call_tuple':{'interface':'NJAICAFMPBE','slot':0,'method':'AIKLEKDPIFH','return':'System.Object'},'reused_generic_interface_helper_description_is_prior_Route_caller_context_only':True,'ordinary_thin_interface_context_declaration_is_unimported':True,'production_SDK_donor_or_provider_executed':False,'LNF_CPBM_or_provider_functionality_proved':False,'working_boot_claimed':False,'Main_modified':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed suspended assign-before-resume guard');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    need(pin(path)['sha256']==digest,'Explicit frozen lookup plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerLookupBindingEffects-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and p['selected_members']==1 and p['controlled_cases']==20,'Exact one-caller bounded fixture')
    for key in ['runner','proof','Root_four_body_apply','native_member','readable_member','reviewable_donor_source','template','tested_disposed_guard_source','copied_Cecil','original_plugin','original_meta','compiler','mono','guard','launcher']:check(p[key])
    for row in p['sources']+p['responses']+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed runner/guards');proof()
    if not run:print(json.dumps({'status':'verified_no_child_started','selected_members':1,'controlled_cases':20}));return 0
    need(not(out/'run-report.json').exists() and all(not Path(p[k]).exists() for k in ['donor_output','effects_output']),'Fresh one-shot outputs only; preserve failures');report={'schema':'guarded-one-original-container-reference-lookup-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'production_SDK_donor_or_provider_executed':False,'Unity_game_or_network_launched':False,'LNF_CPBM_or_provider_functionality_proved':False,'working_boot_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        for i,name in enumerate(['compile-one-original-lookup-owner-donor','compile-explicit-lookup-effects-reader']):guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][i]['path']],out,name,report)
        guard.bounded([p['mono']['path'],p['effects_output'],'--inspect',p['original_plugin']['path'],p['donor_output']],out,'inspect-one-original-reference-lookup-binding',report);guard.bounded([p['mono']['path'],p['effects_output']],out,'twenty-reference-lookup-controlled-effects',report);check(p['original_plugin']);check(p['original_meta']);report.update(status='one_original_reference_lookup_binding_and_twenty_controlled_cases_passed',compiled_donor=pin(p['donor_output']),compiled_effects=pin(p['effects_output']),selected_members=1,controlled_cases=20)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='one_original_reference_lookup_binding_and_twenty_controlled_cases_passed' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan.resolve(strict=True),v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without child');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
