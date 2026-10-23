"""Prepare or Root-run exact8 preparation-member bindings and50 effects.

The original SDK and original-owner donor are metadata-only. The effect model
uses identical selected bodies plus explicit graph/injection/provider contexts,
real Dictionary/LINQ and recording subclasses to observe both real finalizers.
Default preparation/verification starts no child and never changes Main.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor'
PROOFS=[('prerequisites','ContainerPreparationPrerequisiteMembers-20261023T101500Z-0d739a98','a484d80f7fec644bfd86c145c4ba2089e2d44306ee64a2dc690f594749fa35d8'),('assertion','LNFAssertionMembers-20261023T102947Z-bf972cc4','0a47dae79cad41da88485a79951e3f3f284c3113a31ad5cef2519a6b92ac49a3'),('LNF','ContainerPreparationLnfMember-20261023T103438Z-0eb4d50d','eed4201b4ba5658f41a101fb3e8a460ba8cc84b38fd1fafabd37cb14e818b4bd')]
KEY=ROOT/'Validation/ContainerKeyChildMembers-20261023T090718Z-841bc7ca/report.json';KEY_SHA='8c7d9c87c989d68ea6309ea2a7ab356a3cf0da4797a3a24bd8f87f9d6b863480'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-eight-original-container-preparation-binding-fifty-effects/v1'

def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned preparation input changed: '+row['path'])
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')

def proofs():
    result={};pins=[]
    for label,folder,digest in PROOFS:
        path=ROOT/'Validation'/folder/'report.json';need(pin(path)['sha256']==digest,'Exact native preparation proof');r=json.loads(path.read_bytes());check(r['producer']);need(not r['Main_modified'],'Pure original-data proof only');result[label]=r;pins.append(pin(path))
    pre,assertion,lnf=[result[k] for k in ['prerequisites','assertion','LNF']]
    need(pre['status']=='seven_complete_native_prerequisites_staged_five_changed_bodies_two_genuinely_empty_constructors' and pre['changed_body_targets']==[47904,47906,47914,47921,47925] and pre['already_genuinely_empty_original_constructors']==[47905,47922] and len(pre['negative_controls'])==71 and all(x['rejected'] for x in pre['negative_controls']),'Five changed prerequisite bodies, two constructors stay genuine empty')
    need(assertion['status']=='two_complete_original_typed_candidates_staged_binding_effects_pending' and assertion['assertion_shape']['all162_native_bytes_and_CFG_checked'] and assertion['predicate_shape']['all80_native_bytes_and_CFG_checked'] and len(assertion['negative_controls'])==242 and all(x['rejected'] for x in assertion['negative_controls']),'Exact called null-or-dead assertion/predicate')
    need(lnf['status']=='complete1989B_original_LNF_caller_staged_binding_effects_and_callee_closure_pending' and lnf['complete_native_shape']['complete_normal_and_both_exception_landing_CFG_edges_closed'] and len(lnf['negative_controls'])==122 and all(x['rejected'] for x in lnf['negative_controls']),'Exact full LNF CFG/EH and behavior controls')
    for row in [pre['readable_candidate'],assertion['candidate'],lnf['candidate'],lnf['original_EH_proof']]:check(row)
    need(pin(KEY)['sha256']==KEY_SHA,'Exact native tested key source');key=json.loads(KEY.read_bytes());check(key['readable_selected_members']);text=Path(key['readable_selected_members']['path']).read_text();marker='// CPAMAFPANDM only.';need(text.count(marker)==1,'Exact tested key fragment');key_body=marker+text.split(marker,1)[1]
    return result,pins,key_body,key['readable_selected_members']

def wrappers(proof):
    text=Path(proof['assertion']['candidate']['path']).read_text();marker='// MKECFLEMHEL original method47951; called, not inlined, by original LNF.\n';need(text.count(marker)==1,'Exact two unchanged assertion source boundaries');a,b=text.split(marker,1)
    assertion='using System;\npublic static class AGNPJIHDJFG\n{\n'+a+'}\npublic static class MKECFLEMHEL\n{\n'+marker+b+'}\n'
    lnf='public partial class MNALHHOLFGL\n{\n'+Path(proof['LNF']['candidate']['path']).read_text()+'}\n'
    return assertion,lnf

DONOR_CONTEXT='''// Disposable declaration context only; no SDK/donor execution.
using System;using System.Collections.Generic;
public interface DCDAPNDPFMI{void IHEKMEOIBOI(MNALHHOLFGL container);}
public interface NJAICAFMPBE:DCDAPNDPFMI{object AIKLEKDPIFH();bool DHABENNNOIJ();}
public interface CKAJONGONMK{NJAICAFMPBE IBOAFOPAJKI();}
public struct CPAMAFPANDM
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
}
public partial class OENEDGPIOFN
{
    private List<CPAMAFPANDM> OMMELJLAGLB;
    public class NPDGPDKAHLN{public readonly CPAMAFPANDM HDPNFBMCAHN;}
    private IEnumerable<NPDGPDKAHLN> IEPIDJGAOIN(){throw new NotImplementedException("Held original graph roots getter");}
    private static List<NPDGPDKAHLN> LAEKFDEFKFK(IEnumerable<NPDGPDKAHLN> nodes){throw new NotImplementedException("Held original graph sorting");}
    public bool HCILKBKIKOG(out string cycle){throw new NotImplementedException("Held original cycle detection");}
}
public partial class MNALHHOLFGL
{
    private readonly Dictionary<CPAMAFPANDM,NJAICAFMPBE> AAHKPPMHGFI;
    private readonly Dictionary<CPAMAFPANDM,CKAJONGONMK> LMAFHCPPMAD;
    private readonly OENEDGPIOFN OLGLBMGAHBO;
    private PFCPCBJDEMB MGADLDPDPGK;
    private enum PFCPCBJDEMB:byte{Bind=0,Resolved=1}
    internal void FIKOCEOODPI(object value,Nullable<CPAMAFPANDM> key){throw new NotImplementedException("Held original injection");}
}
'''

def prepare():
    p,receipts,key,key_pin=proofs();out=ROOT/'Validation'/('ContainerPreparationBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();assertion,lnf=wrappers(p)
    source_paths=[]
    for name,data in [('ExactPreparationPrerequisites.cs',Path(p['prerequisites']['readable_candidate']['path']).read_bytes()),('ExactCalledAssertions.cs',assertion.encode()),('ExactLnfCaller.cs',lnf.encode()),('OriginalOwnerPreparationContext.cs',DONOR_CONTEXT.encode())]:path=out/name;path.write_bytes(data);source_paths.append(path)
    template=HERE/'ContainerPreparationEffects.template.cs';effect=template.read_bytes();need(effect.count(b'/*EXACT_TESTED_KEY_MEMBERS*/')==1,'One exact tested key insertion');effect=effect.replace(b'/*EXACT_TESTED_KEY_MEMBERS*/',key.encode());need(effect.count(b'Case("')==50,'Exactly50 finite declared effect cases');effect_path=out/'ExactPreparationControlledEffects.cs';effect_path.write_bytes(effect);reader=HERE/'ContainerPreparationMetadata.cs'
    api=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[api/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';facade=api/'Facades/netstandard.dll';copy=out/'Mono.Cecil.dll';copy.write_bytes(cecil.read_bytes());donor=out/'UJect.Runtime.dll';metadata=out/'ContainerPreparationMetadata.exe';effects=out/'ContainerPreparationEffects.exe';responses=[]
    sets=[('donor',source_paths,donor,framework,'library'),('metadata',[reader],metadata,framework+[cecil,facade],'exe'),('effects',source_paths[:3]+[effect_path],effects,framework,'exe')]
    for name,sources,output,refs,kind in sets:
        path=out/(name+'.rsp');path.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+''.join('"'+str(x)+'"\n' for x in sources),encoding='utf-8',newline='\n');responses.append(pin(path))
    plugin=WS/'RR23/Assets/Plugins/UJect.Runtime.dll';plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'native_proofs':receipts,'readable_selected_sources':[p['prerequisites']['readable_candidate'],p['assertion']['candidate'],p['LNF']['candidate']],'original_key_source':key_pin,'key_native_proof':pin(KEY),'template':pin(template),'metadata_reader':pin(reader),'sources':[pin(x) for x in source_paths]+[pin(effect_path)],'responses':responses,'references':[pin(x) for x in framework+[cecil,facade]],'copied_Cecil':pin(copy),'original_plugin':pin(plugin),'original_meta':pin(Path(str(plugin)+'.meta')),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'donor_output':str(donor),'metadata_output':str(metadata),'effects_output':str(effects),'selected_changed_members':8,'genuinely_empty_constructors_unchanged':2,'controlled_cases':50,'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'legal_generated_aliases':p['prerequisites']['legal_generated_alias_map'],'real_Dictionary_and_LINQ_used':True,'tracking_method':'Only test-context List/Dictionary subclasses reimplement their IEnumerable interface, forwarding to real base enumerators, to observe actual foreach/LINQ disposal. Selected source bodies are unchanged.','explicit_test_only_boundaries':['graph cycle detection','graph roots getter and topological sorting','FIKO injection','concrete factory and provider interfaces'],'production_SDK_donor_graph_or_provider_code_executed':False,'Main_modified':False,'working_bootstrap_claimed':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed suspended-owned bounds');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Exact reviewed preparation plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerPreparationBindingEffects-') and p['schema']==SCHEMA and p['selected_changed_members']==8 and p['controlled_cases']==50 and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Exact finite8-member/50-case scope')
    for key in ['runner','original_key_source','key_native_proof','template','metadata_reader','copied_Cecil','original_plugin','original_meta','compiler','mono','guard','launcher']:check(p[key])
    for row in p['native_proofs']+p['readable_selected_sources']+p['sources']+p['responses']+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed runner and guard');native,receipts,key,key_pin=proofs();assertion,lnf=wrappers(native);need(p['native_proofs']==receipts and Path(p['sources'][0]['path']).read_bytes()==Path(native['prerequisites']['readable_candidate']['path']).read_bytes() and Path(p['sources'][1]['path']).read_text()==assertion and Path(p['sources'][2]['path']).read_text()==lnf and Path(p['sources'][3]['path']).read_text()==DONOR_CONTEXT,'Exact unchanged eight candidate bodies and declaration-only donor context');need(Path(p['sources'][4]['path']).read_bytes()==Path(p['template']['path']).read_bytes().replace(b'/*EXACT_TESTED_KEY_MEMBERS*/',key.encode()),'Effect model includes exact frozen key fragment and all selected sources separately')
    if not run:print(json.dumps({'status':'verified_no_child_started','selected_members':8,'controlled_cases':50}));return 0
    need(not(out/'run-report.json').exists() and all(not Path(p[k]).exists() for k in ['donor_output','metadata_output','effects_output']),'Fresh one-shot Root test; preserve failed outputs');r={'schema':'guarded-eight-original-preparation-bindings-fifty-effects/v1','status':'starting','plan':pin(path),'phases':[],'selected_changed_members':8,'controlled_cases':50,'production_SDK_donor_graph_or_provider_code_executed':False,'Main_modified':False,'working_bootstrap_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        for name,n in [('compile-eight-original-owner-preparation-donor',0),('compile-eight-preparation-metadata-reader',1),('compile-exact-preparation-controlled-effects',2)]:guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][n]['path']],out,name,r)
        guard.bounded([p['mono']['path'],p['metadata_output'],p['original_plugin']['path'],p['donor_output']],out,'inspect-eight-original-preparation-bindings-and-foreach-EH',r);guard.bounded([p['mono']['path'],p['effects_output']],out,'fifty-real-Dictionary-LINQ-preparation-effects',r);check(p['original_plugin']);check(p['original_meta']);r.update(status='eight_original_preparation_bindings_and_fifty_real_Dictionary_LINQ_controlled_effects_passed',compiled_donor=pin(p['donor_output']),compiled_reader=pin(p['metadata_output']),compiled_effects=pin(p['effects_output']),all_original_SDK_meta_and_Main_unchanged=True)
    except BaseException as error:r.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',r)
    print(json.dumps({'status':r['status'],'report':pin(out/'run-report.json'),'error':r.get('error')}));return 0 if r['status']=='eight_original_preparation_bindings_and_fifty_real_Dictionary_LINQ_controlled_effects_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without child');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
