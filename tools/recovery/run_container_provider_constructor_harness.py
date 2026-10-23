"""Root-only three original ctor metadata bindings and13 controlled values.

Default emits/pins test sources only. Disposable donor is never executed;
actual SDK assembly, metadata and every original body remain unchanged.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,uuid
import run_container_instance_registration_harness as old
from run_container_instance_registration_harness import HERE,WS,ROOT,EDITOR,guard,need,pin,check,save
PROOF=ROOT/'Validation/ContainerInstanceProviderConstructorMembers-20261023T104201Z-81c66751/report.json';PROOF_SHA='e56ed0b8166b18ba3b3285db5519b8ffdf2c6c722ff6855d1c48cc0394c47ab3'
SCHEMA='prepared-three-original-provider-constructor-bindings-effects/v1'

def proof():
    need(pin(PROOF)['sha256']==PROOF_SHA,'Exact complete original123B constructor proof');p=json.loads(PROOF.read_bytes());need(p['status']=='three_complete_ctor_semantics_proven_binding_effects_and_combined_staging_pending' and p['logical_ctor_members']==3 and p['sum_native_bytes']==123 and len(p['negative_controls'])==123 and all(x['rejected'] for x in p['negative_controls']) and len(p['already_semantically_complete_retained_constructors'])==2,'All original ctor semantics and known two existing no-op semantics')
    for k in ['actual_Root_decoder_receipt','actual_decoded_output','original_scopes','candidate','producer']:check(p[k])
    need(p['candidate']['sha256']=='60f8b99344786b5015536e31f06d2828f5ec38c2a232df2957cb0f44ee9757ee','Unchanged original ctor candidate');native,baseline=old.proof();return p,baseline

def fragments(p):
    text=Path(p['candidate']['path']).read_text();result=[]
    for start in ['protected NPILHMLGJCC()','protected JEMKLLFDDFD()','public PLIPHMBIGMM(TImpl']:
        need(text.count(start)==1,'Exact selected ctor source boundary');at=text.index(start);end=text.index('\n}',at)+2;member=text[at:end]+'\n';need(member.count('{')==member.count('}')==1,'Whole simple original ctor');result.append(member)
    return result

def donor_source(parts):
    return '''// Thin original-owner constructor context. Only3 ctor bodies may be copied.
using System;
public abstract class NPILHMLGJCC<TImpl>
{
'''+parts[0]+'''}
public abstract class JEMKLLFDDFD<TImpl>
{
    private bool OEAONLGBBPN;
'''+parts[1]+'''}
internal class PLIPHMBIGMM<TImpl>:JEMKLLFDDFD<TImpl>
{
    // Compiler-only context emits exact original readonly backing-field name.
    // This property/getter declaration is never transplanted to the SDK.
    public TImpl LHGCALINHGC {get;}
'''+parts[2]+'''}
'''

def prepare():
    p,baseline=proof();parts=fragments(p);fixed=HERE/'RecoveredContainerProviderConstructorDonor.cs';donor=donor_source(parts)
    if fixed.exists():need(fixed.read_text()==donor,'Preserve unchanged ctor donor source')
    else:fixed.write_text(donor,encoding='utf-8',newline='\n')
    out=ROOT/'Validation'/('ContainerProviderConstructorBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=out/'OriginalOwnerProviderConstructorDonor.cs';source.write_bytes(fixed.read_bytes());template=HERE/'ContainerProviderConstructorEffects.template.cs';effect=template.read_bytes()
    for label,value in zip(['EXACT_NPIL_CTOR','EXACT_JEM_CTOR','EXACT_PLIPH_CTOR'],parts):token=('/*'+label+'*/').encode();need(effect.count(token)==1,'One exact constructor source marker');effect=effect.replace(token,value.encode())
    effectsource=out/'ExactProviderConstructorEffects.cs';effectsource.write_bytes(effect);api=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[api/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';refs=framework+[cecil,api/'Facades/netstandard.dll'];copied=out/'Mono.Cecil.dll';copied.write_bytes(cecil.read_bytes());donorout=out/'UJect.Runtime.dll';effectout=out/'ExactProviderConstructorEffects.exe';responses=[]
    for name,src,target,rr,kind in [('three-original-provider-constructor-donor',source,donorout,framework,'library'),('provider-constructor-effects-reader',effectsource,effectout,refs,'exe')]:
        rsp=out/(name+'.rsp');rsp.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(target)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in rr)+'"'+str(src)+'"\n',encoding='utf-8',newline='\n');responses.append(pin(rsp))
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'proof':pin(PROOF),'baseline_helper':pin(Path(old.__file__)),'Root_current_UJect_apply':pin(old.APPLY),'original_plugin':baseline['source'],'original_meta':baseline['meta'],'readable_original_owner_donor':pin(fixed),'template':pin(template),'sources':[pin(source),pin(effectsource)],'responses':responses,'references':[pin(x) for x in refs],'copied_Cecil':pin(copied),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'donor_output':str(donorout),'effects_output':str(effectout),'selected_ctor_members':3,'already_semantically_complete_retained_empty_ctors':2,'controlled_cases':13,'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'exact_source_member_sha256':[hashlib.sha256(x.encode()).hexdigest() for x in parts],'original_SDK_or_provider_runtime_executed':False,'Main_modified':False,'working_provider_or_boot_claimed':False};need(plan['guard']['sha256']==old.GUARD_SHA and plan['launcher']['sha256']==old.LAUNCH_SHA,'Reviewed suspended owned guard');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed ctor test plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerProviderConstructorBindingEffects-') and p['schema']==SCHEMA and p['selected_ctor_members']==3 and p['controlled_cases']==13 and p['already_semantically_complete_retained_empty_ctors']==2 and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Exact finite original three ctor test scope')
    for key in ['runner','proof','baseline_helper','Root_current_UJect_apply','original_plugin','original_meta','readable_original_owner_donor','template','copied_Cecil','compiler','mono','guard','launcher']:check(p[key])
    for row in p['sources']+p['responses']+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['baseline_helper']==pin(Path(old.__file__)) and p['guard']['sha256']==old.GUARD_SHA and p['launcher']['sha256']==old.LAUNCH_SHA,'Exact fresh test source and original guards');native,baseline=proof();parts=fragments(native);need(p['original_plugin']==baseline['source'] and p['original_meta']==baseline['meta'] and [hashlib.sha256(x.encode()).hexdigest() for x in parts]==p['exact_source_member_sha256'] and Path(p['sources'][0]['path']).read_text()==donor_source(parts),'Exact original constructor source/current SDK/disposable donor');effect=Path(p['template']['path']).read_bytes()
    for label,value in zip(['EXACT_NPIL_CTOR','EXACT_JEM_CTOR','EXACT_PLIPH_CTOR'],parts):effect=effect.replace(('/*'+label+'*/').encode(),value.encode())
    need(effect==Path(p['sources'][1]['path']).read_bytes(),'Controlled model uses unchanged original ctor bodies')
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':digest}));return 0
    need(not Path(p['donor_output']).exists() and not Path(p['effects_output']).exists() and not(out/'run-report.json').exists(),'Fresh one-shot Root test');r={'schema':'guarded-three-original-provider-constructor-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'selected_ctor_members':3,'already_semantically_complete_retained_empty_ctors':2,'controlled_cases':13,'Main_modified':False,'original_SDK_or_provider_runtime_executed':False,'working_provider_or_boot_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][0]['path']],out,'compile-original-owner-three-provider-constructor-donor',r);r['compiled_donor']=pin(p['donor_output']);guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][1]['path']],out,'compile-exact-provider-constructor-effects-reader',r);guard.bounded([p['mono']['path'],p['effects_output'],'--inspect',p['original_plugin']['path'],p['donor_output']],out,'inspect-three-original-provider-constructor-bindings',r);guard.bounded([p['mono']['path'],p['effects_output']],out,'thirteen-provider-constructor-controlled-values',r);proof()
        for row in p['sources']+p['references']:check(row)
        r.update(status='three_original_provider_constructor_bindings_and_thirteen_controlled_cases_passed',all_original_SDK_meta_and_Main_unchanged=True)
    except BaseException as error:r.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',r)
    print(json.dumps({'status':r['status'],'report':pin(out/'run-report.json'),'error':r.get('error')}));return 0 if r['status']=='three_original_provider_constructor_bindings_and_thirteen_controlled_cases_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without child');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
