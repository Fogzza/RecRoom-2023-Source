"""Prepare or Root-run four native-proven body bindings and32 controlled cases.

Only a separate controlled-effects executable runs. The original SDK and thin
original-owner donor are read as metadata; unrecovered registration/providers
and the original child constructor are never executed by this test.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,mmap,sys,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROOF=ROOT/'Validation/ContainerKeyChildMembers-20261023T090718Z-841bc7ca/report.json'
PROOF_SHA='8c7d9c87c989d68ea6309ea2a7ab356a3cf0da4797a3a24bd8f87f9d6b863480'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor';SCHEMA='prepared-four-key-child-original-owner-bindings-effects/v1'
def need(value,message):
    if not value:raise ValueError(message)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned key/child input changed: '+row['path'])
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def proof():
    need(pin(PROOF)['sha256']==PROOF_SHA,'Frozen complete four-method native CFG proof');p=json.loads(PROOF.read_bytes());need(p['status']=='four_complete_native_bodies_and_typed_targets_staged_binding_effects_pending' and len(p['native_methods'])==4 and len(p['negative_controls'])==79 and all(x['rejected'] for x in p['negative_controls']),'Exact native selected member set and mutation controls')
    for key in ['current_plugin','current_meta','readable_selected_members','Root_decode_receipt','Root_decoded_output','original_windows','producer']:check(p[key])
    need({int(k) for k in p['complete_native_shapes']}=={47897,47931,47932,47933} and all(x['all_CFG_edges_closed'] for x in p['complete_native_shapes'].values()),'All exact606 original bytes have closed CFGs');return p
def virtual_base_slot2(p):
    # Csc can encode an override invocation using its original base virtual
    # declaration. Bind that precise base declaration rather than permitting an
    # arbitrary name-only target. Type/string slot2 are in the main native proof.
    sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
    from collect_all_pinvoke_native import ExternMetadata
    paths=[Path(x['path']) for x in p['original_sources']]
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
        v=ExternMetadata(b,m);td=v.row('typeDefinitions',413,88);start=v.i32(m,td+56);encoded=v.u32(m,v.row('vtableMethods',start+2,4));need(encoded>>29==3,'Original Object slot2 is MethodDef');method=v.method_info((encoded&0x1fffffff)>>1)
        need(method['index']==4226 and method['owner']=='System.Object' and method['name']=='GetHashCode' and method['return']=='System.Int32' and not method['parameters'] and v.u16(m,v.row('methods',4226,32)+28)==2,'Exact original Object virtual hash base slot2')
    return {'original_method':method,'original_virtual_slot':2,'encoded_vtable_row':hex(encoded),'original_source_authority':p['original_sources'],'only_base_virtual_declaration_encoding_difference_permitted':True}
def prepare():
    p=proof();text=Path(p['readable_selected_members']['path']).read_text();marker='// CPAMAFPANDM only.';need(text.count(marker)==1,'Exact reviewed child/key fragment boundary');child,key=text.split(marker,1);key=marker+key
    donor='''// Thin original-owner compile context; never import this DLL wholesale.
// Only four named bodies are selected. Context ctor/CompareTo are unselected.
using System;
public sealed class MNALHHOLFGL
{
    internal MNALHHOLFGL(MNALHHOLFGL parent,string name){throw new NotImplementedException("Unselected original ctor context");}
'''+child+'''
}
public struct CPAMAFPANDM:IComparable<CPAMAFPANDM>
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;}
    public int CompareTo(CPAMAFPANDM other){throw new NotImplementedException("Unselected original context");}
'''+key+'\n}\n'
    fixed=HERE/'RecoveredContainerKeyChildDonor.cs'
    if fixed.exists():need(fixed.read_text()==donor,'Never overwrite reviewed donor context')
    else:
        with fixed.open('x',encoding='utf-8',newline='\n') as f:f.write(donor)
    out=ROOT/'Validation'/('ContainerKeyChildBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();donorsource=out/'OriginalOwnerKeyChildDonor.cs';donorsource.write_bytes(fixed.read_bytes());template=HERE/'ContainerKeyChildEffects.template.cs';effects=template.read_bytes()
    for label,value in [('EXACT_CHILD_MEMBER',child),('EXACT_KEY_MEMBERS',key)]:
        token=('/*'+label+'*/').encode();need(effects.count(token)==1,'One exact verbatim fragment insertion');effects=effects.replace(token,value.encode())
    effectsource=out/'ExactContainerKeyChildControlledEffects.cs';effectsource.write_bytes(effects);api=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[api/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];facade=api/'Facades/netstandard.dll';cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';copied=out/'Mono.Cecil.dll';copied.write_bytes(cecil.read_bytes());need(pin(copied)['sha256']==pin(cecil)['sha256'],'Exact metadata-only Cecil dependency')
    donorout=out/'UJect.Runtime.dll';effectout=out/'ExactContainerKeyChildControlledEffects.exe';responses=[]
    for name,source,target,refs,kind in [('donor',donorsource,donorout,framework,'library'),('effects-reader',effectsource,effectout,framework+[cecil,facade],'exe')]:
        response=out/(name+'.rsp');response.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(target)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n',encoding='utf-8',newline='\n');responses.append(pin(response))
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'proof':pin(PROOF),'native_virtual_hash_base_slot2':virtual_base_slot2(p),'candidate_members':p['readable_selected_members'],'reviewable_donor_source':pin(fixed),'template':pin(template),'sources':[pin(donorsource),pin(effectsource)],'responses':responses,'references':[pin(x) for x in framework+[cecil,facade]],'copied_Cecil':pin(copied),'original_plugin':p['current_plugin'],'original_meta':p['current_meta'],'donor_output':str(donorout),'effects_output':str(effectout),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'selected_members':4,'controlled_cases':32,'production_SDK_donor_or_child_constructor_executed':False,'registration_lookup_provider_or_working_boot_claimed':False,'Main_modified':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed assign-before-resume guard');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    need(pin(path)['sha256']==digest,'Explicit frozen four-member plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerKeyChildBindingEffects-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and p['selected_members']==4 and p['controlled_cases']==32,'Exact four-member bounded fixture scope')
    for key in ['runner','proof','candidate_members','reviewable_donor_source','template','copied_Cecil','original_plugin','original_meta','compiler','mono','guard','launcher']:check(p[key])
    for row in p['sources']+p['responses']+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact current reviewed runner/guards');need(p['native_virtual_hash_base_slot2']==virtual_base_slot2(proof()),'Exact original base virtual slot2 proof')
    if not run:print(json.dumps({'status':'verified_no_child_started','selected_members':4,'controlled_cases':32}));return 0
    need(not(out/'run-report.json').exists() and all(not Path(p[k]).exists() for k in ['donor_output','effects_output']),'Fresh one-shot outputs only, preserve failures');report={'schema':'guarded-four-original-key-child-binding-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'production_SDK_or_donor_executed':False,'Unity_game_or_network_launched':False,'registration_lookup_provider_or_working_boot_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        for i,name in enumerate(['compile-four-key-child-original-owner-donor','compile-explicit-key-child-effects-reader']):guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][i]['path']],out,name,report)
        guard.bounded([p['mono']['path'],p['effects_output'],'--inspect',p['original_plugin']['path'],p['donor_output']],out,'inspect-four-original-key-child-bindings',report)
        guard.bounded([p['mono']['path'],p['effects_output']],out,'thirty-two-key-child-controlled-effects',report)
        check(p['original_plugin']);check(p['original_meta']);report.update(status='four_original_key_child_bindings_and_thirty_two_controlled_cases_passed',compiled_donor=pin(p['donor_output']),compiled_effects=pin(p['effects_output']),selected_members=4,controlled_cases=32)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='four_original_key_child_bindings_and_thirty_two_controlled_cases_passed' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan.resolve(strict=True),v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
