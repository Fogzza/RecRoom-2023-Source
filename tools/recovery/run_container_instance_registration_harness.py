"""Prepare or Root-run original three registration-member binding and25 effects.

Only a thin original-owner donor is compiled/inspected, never executed. The
separate controlled model inserts unchanged selected source bodies. Original
base/value-provider/private registration implementations remain held.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor'
PROOF=ROOT/'Validation/ContainerInstanceRegistrationMembers-20261023T100233Z-8bdc898e/report.json';PROOF_SHA='24f819aec671a0623e24816ee62bf4f52a60e339f7bac6e6e5148029d90e964f'
APPLY=ROOT/'Validation/ContainerLookupDiscoveryExactApply-20261023T101025Z-0b12c39b/apply-receipt.json';APPLY_SHA='9b914faf3c6c7a5a3c67f756cd8f2473d2103c74f3206f8b7c9d56b1efbf1584'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-three-original-instance-registration-bindings-controlled-effects/v1'

def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned three-member input changed: '+row['path'])
def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')

def proof():
    need(pin(PROOF)['sha256']==PROOF_SHA and pin(APPLY)['sha256']==APPLY_SHA,'Exact original native3 proof and fresh Root two-body runtime baseline');p=json.loads(PROOF.read_bytes());a=json.loads(APPLY.read_bytes());need(p['status']=='three_original_typed_candidates_staged_binding_effects_and_provider_closure_pending' and p['original_native_bytes']==748 and not p['Main_modified'] and not p['CSharp_compiled_or_runtime_behavior_claimed'],'Complete original748-byte typed source evidence')
    need(p['complete_native_shapes'][2]['all168_bytes_checked'] and p['complete_native_shapes'][2]['base_before_allocation_before_field_store'] and p['complete_native_shapes'][2]['no_null_value_rejection_added'] and len(p['provider_constructor_original_class_rgctx']['rows'])==4,'Complete provider ctor across three regions with original class rgctx')
    need(p['original_generic_parameter_contracts']==[[{'name':'TClass','number':0,'flags':4,'constraints':[]}],[{'name':'TFrom','number':0,'flags':0,'constraints':[]},{'name':'TTo','number':1,'flags':0,'constraints':['TFrom']}],[{'name':'TImpl','number':0,'flags':0,'constraints':[]}]],'Exact original reference-only bind, dependent reg and unconstrained provider type')
    for key in ['producer','actual_Root_decode','actual_decoded_output','original_scopes','original_binding_proof','candidate']:check(p[key])
    need(p['candidate']['sha256']=='5f2189033ce742d5d9f05f837eab53c0fc4abe5e05ee71204c6015ed46819e66','Exact unchanged Root source candidate')
    need(a['status']=='two_native_lookup_discovery_bodies_applied_one_SDK_meta_preserved' and len(a['applied'])==1 and a['changed_method_bodies']==2 and a['metas_unchanged'] and a['all_other_bodies_and_all_original_semantic_metadata_retained'] and not a['higher_bootstrap_activated'],'Fresh applied UJect body-only baseline, no whole boot claim');row=a['applied'][0];check(row['source']);check(row['meta']);need(Path(row['source']['path'])==WS/'RR23/Assets/Plugins/UJect.Runtime.dll' and row['source']['sha256']=='9997b88de8261636419c1a9354fd768d8b3b7618ec193d62349908477ba1d170','Exact current unchanged original-owner SDK')
    return p,row

def fragments(p):
    text=Path(p['candidate']['path']).read_text();labels=['// MNALHHOLFGL, original public MethodDef06000013:\n','// MNALHHOLFGL, original internal MethodDef06000017:\n','// IKGLJOBBAAC<TImpl>, original public constructor MethodDef06000084:\n'];positions=[]
    for label in labels:need(text.count(label)==1,'Exact Root source member boundary');positions.append(text.index(label)+len(label))
    result=[]
    for i,start in enumerate(positions):end=text.index(labels[i+1]) if i+1<len(labels) else len(text);result.append(text[start:end].rstrip()+'\n')
    need([x.count('{')==x.count('}') for x in result]==[True]*3 and result[0].startswith('public MNALHHOLFGL PHJOGIEDKPN<TClass>') and result[1].startswith('internal void JONINBOMMEP<TFrom, TTo>') and result[2].startswith('public IKGLJOBBAAC(TImpl'),'Three unchanged whole selected members only');return result

def donor_source(parts):
    return '''// Thin original-owner declaration context. ONLY three selected bodies.
// This compiled donor is read via Cecil and is NEVER executed or substituted.
using System;
public interface CKAJONGONMK{}
public interface MOANAJANOIL<TImpl>{}
public abstract class NPILHMLGJCC<TImpl>:CKAJONGONMK
{
    protected NPILHMLGJCC(){throw new NotImplementedException("Unselected original base constructor");}
}
internal class PLIPHMBIGMM<TImpl>:MOANAJANOIL<TImpl>
{
    public PLIPHMBIGMM(TImpl value){throw new NotImplementedException("Unselected original value-provider constructor");}
}
internal class IKGLJOBBAAC<TImpl>:NPILHMLGJCC<TImpl>
{
    private readonly MOANAJANOIL<TImpl> JPEDOBINBHH;
'''+parts[2]+'''}
public struct CPAMAFPANDM:IComparable<CPAMAFPANDM>
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string id){throw new NotImplementedException("Unselected original key constructor");}
    public int CompareTo(CPAMAFPANDM other){throw new NotImplementedException("Unselected original key ordering");}
}
public sealed class MNALHHOLFGL
{
    private bool KBDIBPJIHNN;
'''+parts[0]+parts[1]+'''    private void JONINBOMMEP(CPAMAFPANDM from,CPAMAFPANDM to,CKAJONGONMK provider){throw new NotImplementedException("Unselected original private registration");}
}
public static class MKECFLEMHEL
{
    public static void GFKAFPHLKMJ(bool condition,string message){throw new NotImplementedException("Unselected original guard context");}
}
'''

def prepare():
    p,baseline=proof();parts=fragments(p);readable=HERE/'RecoveredContainerInstanceRegistrationDonor.cs';donor=donor_source(parts)
    if readable.exists():need(readable.read_text()==donor,'Preserve unchanged exact original-owner donor')
    else:readable.write_text(donor,encoding='utf-8',newline='\n')
    out=ROOT/'Validation'/('ContainerInstanceRegistrationBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=out/'OriginalOwnerThreeInstanceRegistrationDonor.cs';source.write_bytes(readable.read_bytes());template=HERE/'ContainerInstanceRegistrationEffects.template.cs';effect=template.read_bytes()
    for label,value in zip(['EXACT_INSTANCE_BIND_MEMBER','EXACT_GENERIC_KEY_REG_MEMBER','EXACT_INSTANCE_PROVIDER_CTOR'],parts):token=('/*'+label+'*/').encode();need(effect.count(token)==1,'One exact selected source effect marker');effect=effect.replace(token,value.encode())
    need(b'/*EXACT_' not in effect,'All exact original bodies inserted');effectsource=out/'ExactInstanceRegistrationControlledEffects.cs';effectsource.write_bytes(effect);api=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[api/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';facade=api/'Facades/netstandard.dll';copied=out/'Mono.Cecil.dll';copied.write_bytes(cecil.read_bytes());donorout=out/'UJect.Runtime.dll';effectsout=out/'ExactInstanceRegistrationEffects.exe';responses=[]
    for name,src,target,refs,kind in [('original-three-instance-registration-donor',source,donorout,framework,'library'),('instance-registration-effects-reader',effectsource,effectsout,framework+[cecil,facade],'exe')]:
        response=out/(name+'.rsp');response.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(target)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(src)+'"\n',encoding='utf-8',newline='\n');responses.append(pin(response))
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'proof':pin(PROOF),'Root_current_UJect_apply':pin(APPLY),'original_plugin':baseline['source'],'original_meta':baseline['meta'],'readable_original_owner_donor':pin(readable),'template':pin(template),'sources':[pin(source),pin(effectsource)],'responses':responses,'references':[pin(x) for x in framework+[cecil,facade]],'copied_Cecil':pin(copied),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'donor_output':str(donorout),'effects_output':str(effectsout),'selected_members':3,'controlled_cases':25,'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'exact_source_member_sha256':[hashlib.sha256(x.encode()).hexdigest() for x in parts],'donor_only_exact_generic_arity_source_spelling_exceptions':['IKGLJOBBAAC -> IKGLJOBBAAC`1','NPILHMLGJCC -> NPILHMLGJCC`1','PLIPHMBIGMM -> PLIPHMBIGMM`1','MOANAJANOIL -> MOANAJANOIL`1'],'source_spelling_note':'These are exact original raw definition names/arity versus mandatory C# generic source spellings in the disposable donor only. No original runtime definition or reference is renamed.','explicit_controlled_boundaries':['guard bool/message','key constructor','NPIL generic base constructor','PLIPH value-provider constructor','private three-argument registration'],'production_SDK_donor_base_provider_private_registration_executed':False,'Main_modified':False,'working_startup_or_instance_provider_runtime_claimed':False};need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Exact suspended-owned guard');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed three-instance-member plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerInstanceRegistrationBindingEffects-') and p['schema']==SCHEMA and p['selected_members']==3 and p['controlled_cases']==25 and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Exact finite original-three member fixture')
    for key in ['runner','proof','Root_current_UJect_apply','original_plugin','original_meta','readable_original_owner_donor','template','copied_Cecil','compiler','mono','guard','launcher']:check(p[key])
    for row in p['sources']+p['responses']+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed runner/guard/launcher');native,baseline=proof();parts=fragments(native);need(p['original_plugin']==baseline['source'] and p['original_meta']==baseline['meta'] and [hashlib.sha256(x.encode()).hexdigest() for x in parts]==p['exact_source_member_sha256'] and Path(p['sources'][0]['path']).read_text()==donor_source(parts),'Exact native member bytes/current original SDK/donor context')
    effect=Path(p['template']['path']).read_bytes()
    for label,value in zip(['EXACT_INSTANCE_BIND_MEMBER','EXACT_GENERIC_KEY_REG_MEMBER','EXACT_INSTANCE_PROVIDER_CTOR'],parts):effect=effect.replace(('/*'+label+'*/').encode(),value.encode())
    need(effect==Path(p['sources'][1]['path']).read_bytes(),'Controlled effects insert exact unchanged selected bodies')
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':digest}));return 0
    need(not Path(p['donor_output']).exists() and not Path(p['effects_output']).exists() and not(out/'run-report.json').exists(),'Fresh one-shot Root test');r={'schema':'guarded-three-original-instance-registration-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'selected_members':3,'controlled_cases':25,'Main_modified':False,'production_SDK_donor_base_provider_private_registration_executed':False,'working_startup_or_provider_runtime_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][0]['path']],out,'compile-original-owner-three-instance-registration-donor',r);r['compiled_donor']=pin(p['donor_output']);guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][1]['path']],out,'compile-three-registration-effects-and-reader',r);guard.bounded([p['mono']['path'],p['effects_output'],'--inspect',p['original_plugin']['path'],p['donor_output']],out,'inspect-three-original-instance-registration-bindings',r);guard.bounded([p['mono']['path'],p['effects_output']],out,'twenty-five-instance-registration-controlled-effects',r);proof()
        for row in p['sources']+p['references']:check(row)
        r.update(status='three_original_instance_registration_bindings_and_twenty_five_controlled_effect_cases_passed',all_original_SDK_meta_and_Main_unchanged=True)
    except BaseException as error:r.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',r)
    print(json.dumps({'status':r['status'],'report':pin(out/'run-report.json'),'error':r.get('error')}));return 0 if r['status']=='three_original_instance_registration_bindings_and_twenty_five_controlled_effect_cases_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without child');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
