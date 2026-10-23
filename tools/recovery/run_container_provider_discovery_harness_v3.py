"""Prepare or Root-run native CPBM binding and30 Dictionary/combined effects.

NGB and CPBM source fragments are unchanged, separately native-proven bodies.
The real generic Dictionary uses the already tested key body source. LNF,
container/key formatting and provider returns are explicit controlled contexts;
no original SDK/donor/provider is executed and no Main file can be modified.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,uuid
import original_shader_pair_editor_conversion as guard
import run_container_lookup_harness_v2 as lookup
from audit_boot_candidate_dependency_closure import module_methods
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROOF=ROOT/'Validation/LiveProviderDiscoveryMember-20261023T093223Z-ea7e110d/report.json';PROOF_SHA='9fa16c33aa212587ddd690615afa124a472eefc10039bcc7737a309b8c122204'
LOOKUP_TEST=ROOT/'Validation/ContainerLookupBindingEffects-20261023T094501Z-7c3047b7/run-report.json';LOOKUP_TEST_SHA='1c5bf208315c17b363513d5684dd18fc4d0e157514dd1e1649a04efdfc4f5e91'
KEY_NATIVE=ROOT/'Validation/ContainerKeyChildMembers-20261023T090718Z-841bc7ca/report.json';KEY_NATIVE_SHA='8c7d9c87c989d68ea6309ea2a7ab356a3cf0da4797a3a24bd8f87f9d6b863480'
KEY_SMOKE=ROOT/'Validation/ContainerKeyDictionarySmoke-20261023T092158Z-ce32cccb/Run-20261023T092258Z-17dd2c7c/run-report.json';KEY_SMOKE_SHA='ddcf1723f4375ca44f7514bdc3f21bef5a50f02049332cc8ba4c2a80edfdc327'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor';SCHEMA='prepared-unconstrained-provider-discovery-real-Dictionary-combined-effects/v3'
FAILED=ROOT/'Validation/ContainerProviderDiscoveryBindingEffects-20261023T095059Z-53f662b0/run-report.json';FAILED_SHA='f2ce9b956ad88c442e65dc940f3285c1ee0c9695c109119181dac8ea08adef24'
def need(value,message):
    if not value:raise ValueError(message)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned provider discovery input changed: '+row['path'])
def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')
def proofs():
    need(pin(PROOF)['sha256']==PROOF_SHA and pin(LOOKUP_TEST)['sha256']==LOOKUP_TEST_SHA and pin(KEY_NATIVE)['sha256']==KEY_NATIVE_SHA and pin(KEY_SMOKE)['sha256']==KEY_SMOKE_SHA,'Exact native discovery and prior actual lookup/key receipts')
    p=json.loads(PROOF.read_bytes());r=json.loads(LOOKUP_TEST.read_bytes());key=json.loads(KEY_NATIVE.read_bytes());smoke=json.loads(KEY_SMOKE.read_bytes());check(r['plan']);lp=json.loads(Path(r['plan']['path']).read_bytes());native_lookup,baseline=lookup.proof();reuse=lookup.prior_compile()
    need(p['status']=='complete_original_provider_discovery_caller_staged_binding_effects_and_preparation_closure_pending' and p['complete_native_shape']['all455_original_bytes_and_CFG_edges_checked'] and p['complete_native_shape']['out_assigned_before_stored_null_assertion'] and p['original']['index']==47884 and p['original']['flags']==129 and p['original_generic_parameter_flags']==0 and len(p['negative_controls'])==455 and all(x['rejected'] for x in p['negative_controls']),'Exact original private/unconstrained455-byte discovery and all mutation controls')
    need(r['schema']=='guarded-one-original-container-reference-lookup-binding-effects/v2' and r['status']=='one_original_reference_lookup_binding_and_twenty_controlled_cases_passed' and r['selected_members']==1 and r['controlled_cases']==20 and not r['production_SDK_donor_or_provider_executed'] and [x['phase'] for x in r['phases']]==['compile-explicit-lookup-effects-reader-v2','inspect-one-original-reference-lookup-binding','twenty-reference-lookup-controlled-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'Actual successful lookup metadata/20effects with preserved initial compiler proof')
    need(r['compiled_donor']==lp['reused_compiled_donor']==reuse[2] and lp['original_plugin']==baseline['source'] and lp['original_meta']==baseline['meta'],'Exact current Root4 SDK and actual reused lookup donor')
    need(smoke['status']=='actual_original_key_equality_hash_Dictionary_proved_in_matching_Windows_Mono_player' and smoke['only_closed_SDK_key_constructor_equality_hash_executed'] and not smoke['production_child_method_executed'],'Genuine matching-player key behavior already tested')
    for row in [p['producer'],p['original_typed_dependency_joins'],p['actual_Root_decoder_receipt'],p['candidate'],native_lookup['candidate'],key['readable_selected_members'],r['compiled_donor'],lp['template']]:check(row)
    return p,native_lookup,key,baseline,lp
def prior_compile():
    need(pin(FAILED)['sha256']==FAILED_SHA,'Preserve exact ambiguous test-Key helper compile failure');r=json.loads(FAILED.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes());need(r['status']=='failed_or_guard_refused_preserve_outputs' and len(r['phases'])==2 and r['phases'][0]['phase']=='compile-original-provider-discovery-and-lookup-donor' and r['phases'][0]['exit_code']==0 and r['phases'][0]['owned_child_exit_confirmed'] and r['phases'][1]['phase']=='compile-explicit-real-Dictionary-combined-effects-reader' and r['phases'][1]['exit_code']!=0,'Only the native-backed successful donor compile is reused; failed helper preserved')
    for key in ['runner','proof','successful_lookup_test','successful_lookup_test_plan','lookup_validation_helper','native_lookup_proof','Root_four_body_apply','original_plugin','original_meta','compiler','mono']:check(p[key])
    for row in p['sources']+p['responses']+p['references']+p['reviewable_sources']:check(row)
    return r,p,pin(p['donor_output'])
INSPECT_FAILED=ROOT/'Validation/ContainerProviderDiscoveryBindingEffects-20261023T095504Z-845c9968/run-report.json';INSPECT_FAILED_SHA='325e2858a015b7c3842e76782600970345646e4ab54a83d854759f87f0bad419'
def prior_inspection_failure():
    need(pin(INSPECT_FAILED)['sha256']==INSPECT_FAILED_SHA,'Preserve exact Call-vs-Callvirt inspector failure');r=json.loads(INSPECT_FAILED.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['schema']=='guarded-original-provider-discovery-Dictionary-combined-effects/v2' and r['status']=='failed_or_guard_refused_preserve_outputs' and [x['phase'] for x in r['phases']]==['compile-explicit-real-Dictionary-combined-effects-reader-v2','inspect-exact-provider-discovery-and-rechecked-lookup-bindings'] and r['phases'][0]['exit_code']==0 and r['phases'][1]['exit_code']==1 and all(x['owned_child_exit_confirmed'] for x in r['phases']),'Only actual helper compilation/metadata failure, effects not run')
    for row in [p['runner'],p['template'],p['reused_compiled_donor']]+p['sources']:check(row)
    return r,p
def compiled_donor_lowering(row):
    from audit_cli_marshal_contracts import Cli
    import struct
    check(row);b=Path(row['path']).read_bytes();c=Cli(b);at=c.row(6,8);start=c.raw(c.u32(at),12);header=(c.u16(start)>>12)*4;size=c.u32(start+4);il=b[start+header:start+header+size]
    expected=bytes.fromhex('027b050000047241000070280b000006022809000006027b030000040312006f0800000a2c1f040651062d1772c800007002038c03000002280900000a730a00000a7a172a027b040000040b072c10070312026f0100002b2c05040851172a041451162a')
    need(il==expected and c.string(c.value(at+8,c.strw))=='CPBMOKFMMMK' and c.u16(at+6)==129 and c.blob(c.value(at+8+c.strw,c.blobw)).hex()=='30010202110c101208','Unchanged100-byte private unconstrained donor method')
    spec=c.row(43,1);need(c.rows[43]==1 and c.value(spec,c.coded(1,[6,10]))==16 and c.blob(c.value(spec+c.coded(1,[6,10]),c.blobw)).hex()=='0a011e00','Recursive MethodSpec exactly same MethodDef8 with method generic0')
    return {'method_token':'0x06000008','IL_bytes':len(il),'IL_sha256':hashlib.sha256(il).hexdigest(),'recursive_instruction_offset':83,'recursive_opcode':'callvirt','recursive_MethodSpec':'0x2b000001','instantiation_blob_hex':'0a011e00','parent_capture_offset':69,'parent_null_and_false_target_offset':95,'candidate_and_donor_changed':False}
def prepare():
    previous,previous_plan,reused=prior_compile();inspected,inspected_plan=prior_inspection_failure();lowering=compiled_donor_lowering(reused);p,native_lookup,key,baseline,prior=proofs();discovery=Path(p['candidate']['path']).read_text();member=Path(native_lookup['candidate']['path']).read_text();key_text=Path(key['readable_selected_members']['path']).read_text();marker='// CPAMAFPANDM only.';need(key_text.count(marker)==1,'Exact tested key fragment boundary');key_members=marker+key_text.split(marker,1)[1]
    fixed=HERE/'RecoveredContainerProviderDiscoveryMember.cs'
    if fixed.exists():need(fixed.read_text()==discovery,'Preserve exact native discovery member')
    else:
        with fixed.open('x',encoding='utf-8',newline='\n') as f:f.write(discovery)
    donor='''// Thin original-owner context only. Import only the selected two bodies.
using System;using System.Collections.Generic;
public interface NJAICAFMPBE{object AIKLEKDPIFH();}
public struct CPAMAFPANDM:IComparable<CPAMAFPANDM>
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;}
    public int CompareTo(CPAMAFPANDM other){throw new NotImplementedException("Unselected original key context");}
'''+key_members+'''
}
public sealed class MNALHHOLFGL
{
    private readonly Dictionary<CPAMAFPANDM,NJAICAFMPBE> AAHKPPMHGFI;
    private readonly MNALHHOLFGL DDFCHDGPJBN;private bool KBDIBPJIHNN;
'''+member+discovery+'''
    public void LNFNAIMOFOF(){throw new NotImplementedException("Unselected original preparation context");}
}
internal static class MKECFLEMHEL
{
    public static void GFKAFPHLKMJ(bool condition,string message){throw new NotImplementedException("Unselected original disposed guard context");}
}
'''
    fixed_donor=HERE/'RecoveredContainerProviderDiscoveryDonor.cs'
    if fixed_donor.exists():need(fixed_donor.read_text()==donor,'Preserve selected original-owner donor')
    else:
        with fixed_donor.open('x',encoding='utf-8',newline='\n') as f:f.write(donor)
    out=ROOT/'Validation'/('ContainerProviderDiscoveryBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();donorsource=out/'OriginalOwnerProviderDiscoveryDonor.cs';donorsource.write_bytes(fixed_donor.read_bytes());template=HERE/'ContainerProviderDiscoveryEffects.v3.template.cs';effects=template.read_bytes();guard_source=HERE/'RecoveredDisposedGuardDonor.cs';disposed=guard_source.read_text().split('public static class MKECFLEMHEL\n{\n',1)[1].rsplit('\n}\n',1)[0]
    for label,text in [('EXACT_LOOKUP_MEMBER',member),('EXACT_PROVIDER_DISCOVERY_MEMBER',discovery),('EXACT_TESTED_KEY_MEMBERS',key_members),('EXACT_TESTED_DISPOSED_GUARD',disposed)]:
        token=('/*'+label+'*/').encode();need(effects.count(token)==1,'One verbatim source fragment '+label);effects=effects.replace(token,text.encode())
    effectsource=out/'ExactProviderDiscoveryDictionaryControlledEffects.cs';effectsource.write_bytes(effects)
    # Recheck the identical proven lookup reader in the new compiled donor.
    # Its effect model/Main are excluded; only metadata-reader functions copied.
    old=Path(prior['template']['path']).read_text();start=old.index('    static string TypeKey(');end=old.index('    public static int Main(',start);reader_text=old[start:end];need(reader_text.count('    static void Inspect(')==1,'Exact prior actual lookup metadata-reader extraction');reader_text=reader_text.replace('    static void Inspect(','    public static void Inspect(',1);reader='using System;using System.Linq;using Mono.Cecil;using Mono.Cecil.Cil;\nstatic class OriginalLookupMetadataReader\n{\n    static void Need(bool value,string message){if(!value)throw new InvalidOperationException(message);}\n'+reader_text+'}\n';reader_path=out/'ReusedOriginalLookupMetadataReader.cs';reader_path.write_text(reader,encoding='utf-8',newline='\n')
    api=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[api/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';facade=api/'Facades/netstandard.dll';copied=out/'Mono.Cecil.dll';copied.write_bytes(cecil.read_bytes());need(pin(copied)['sha256']==pin(cecil)['sha256'],'Exact metadata reader dependency');donorout=out/'UJect.Runtime.dll';effectout=out/'ExactProviderDiscoveryDictionaryEffects.exe';responses=[]
    for name,sources,target,refs,kind in [('provider-discovery-donor',[donorsource],donorout,framework,'library'),('provider-discovery-effects-reader',[effectsource,reader_path],effectout,framework+[cecil,facade],'exe')]:
        response=out/(name+'.rsp');response.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(target)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+''.join('"'+str(x)+'"\n' for x in sources),encoding='utf-8',newline='\n');responses.append(pin(response))
    current=module_methods(Path(baseline['source']['path']),[{'owner':'MNALHHOLFGL','name':n,'parameters':2,'generic':1} for n in ['NGBMOPMLJCM','CPBMOKFMMMK']]);need([x['flags'] for x in current]==[131,129],'Exact current original internal/private selected caller MethodDefs')
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'proof':pin(PROOF),'successful_lookup_test':pin(LOOKUP_TEST),'successful_lookup_test_plan':pin(Path(LOOKUP_TEST).parent/'plan.json'),'lookup_validation_helper':pin(Path(lookup.__file__)),'native_lookup_proof':pin(lookup.PROOF),'Root_four_body_apply':pin(lookup.APPLY),'key_native_proof':pin(KEY_NATIVE),'key_engine_smoke':pin(KEY_SMOKE),'reviewable_sources':[pin(fixed),pin(fixed_donor),native_lookup['candidate'],key['readable_selected_members'],pin(guard_source)],'template':pin(template),'sources':[pin(donorsource),pin(effectsource),pin(reader_path)],'derived_lookup_reader_source':pin(Path(prior['template']['path'])),'derived_reader_transformation':'Exact TypeKey through Inspect functions only, one private-to-public test-helper access change; effect model and Main excluded.','responses':responses,'references':[pin(x) for x in framework+[cecil,facade]],'copied_Cecil':pin(copied),'original_plugin':baseline['source'],'original_meta':baseline['meta'],'exact_current_selected_methods':current,'donor_output':str(donorout),'effects_output':str(effectout),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'selected_members':2,'controlled_cases':30,'real_Dictionary_and_exact_tested_key_source_used':True,'explicit_controlled_boundaries':['LNF initialization','container ToString','key ToString','provider object-return method'],'production_SDK_donor_or_held_callees_executed':False,'LNF_registration_formatters_or_provider_functionality_proved':False,'working_boot_claimed':False,'Main_modified':False}
    need(plan['sources'][0]['sha256']==previous_plan['sources'][0]['sha256'] and plan['references']==previous_plan['references'] and plan['compiler']==previous_plan['compiler'] and plan['original_plugin']==previous_plan['original_plugin'] and plan['original_meta']==previous_plan['original_meta'],'Reused donor exact source/compiler/references/current SDK pins')
    old_response=Path(previous_plan['responses'][0]['path']).read_text();new_response=Path(plan['responses'][0]['path']).read_text();need(old_response.replace(previous_plan['sources'][0]['path'],plan['sources'][0]['path']).replace(previous_plan['donor_output'],plan['donor_output'])==new_response,'Only unused donor response paths rebased, compiler flags byte-identical')
    original_template=Path(previous_plan['template']['path']).read_bytes();v2=Path(inspected_plan['template']['path']).read_bytes();need(original_template.count(b'Key(null)')==2 and v2==original_template.replace(b'Key(null)',b'Key((string)null)'),'Preserved exact earlier two-site test-only correction')
    current_template=Path(plan['template']['path']).read_text();prior_template=v2.decode();begin=current_template.index('            // Exact emitted parent capture/null guard/callvirt/out-temporary lowering.');end=current_template.index('            var fields=ins.Where',begin);inverted=current_template[:begin]+current_template[end:];need(inverted.count('calls[5].OpCode.Code==Code.Callvirt&&recurse!=null')==1 and inverted.replace('calls[5].OpCode.Code==Code.Callvirt&&recurse!=null','calls[5].OpCode.Code==Code.Call&&recurse!=null',1)==prior_template,'Only exact emitted Callvirt recursion gate plus strict tail/receiver/branch/MethodDef assertions')
    need(plan['sources'][0]['sha256']==inspected_plan['sources'][0]['sha256'] and reused==inspected_plan['reused_compiled_donor'],'Exact original donor source/output also matches preserved second failure')
    plan.update(prior_failed_receipt=pin(FAILED),prior_failed_plan=previous['plan'],reused_compiled_donor=reused,donor_recompiled=False,unused_donor_response_not_executed=True,prior_inspector_failure=pin(INSPECT_FAILED),prior_inspector_plan=inspected['plan'],prior_inspector_template=inspected_plan['template'],compiled_donor_lowering=lowering,sole_amendment='Exact unchanged donor callvirt self-recursion with captured parent/null guard/temporary-output lowering; source/candidate unchanged.')
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed suspended owned-job guard');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    need(pin(path)['sha256']==digest,'Explicit frozen discovery/combined plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerProviderDiscoveryBindingEffects-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and p['selected_members']==2 and p['controlled_cases']==30,'Exact two-caller finite fixture')
    for key in ['runner','proof','successful_lookup_test','successful_lookup_test_plan','lookup_validation_helper','native_lookup_proof','Root_four_body_apply','key_native_proof','key_engine_smoke','template','derived_lookup_reader_source','copied_Cecil','original_plugin','original_meta','compiler','mono','guard','launcher','prior_failed_receipt','prior_failed_plan','reused_compiled_donor','prior_inspector_failure','prior_inspector_plan','prior_inspector_template']:check(p[key])
    for row in p['reviewable_sources']+p['sources']+p['responses']+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact runner and owned guard');proofs();previous=prior_compile();prior_inspection_failure();need(previous[2]==p['reused_compiled_donor'] and compiled_donor_lowering(previous[2])==p['compiled_donor_lowering'],'Exact successful native-backed donor remains unchanged')
    if not run:print(json.dumps({'status':'verified_no_child_started','selected_members':2,'controlled_cases':30}));return 0
    need(not(out/'run-report.json').exists() and all(not Path(p[k]).exists() for k in ['donor_output','effects_output']),'Fresh one-shot outputs only');report={'schema':'guarded-original-provider-discovery-Dictionary-combined-effects/v3','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'production_SDK_donor_or_held_callees_executed':False,'Unity_game_or_network_launched':False,'LNF_registration_formatters_or_provider_functionality_proved':False,'working_boot_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][1]['path']],out,'compile-explicit-real-Dictionary-combined-effects-reader-v3',report)
        guard.bounded([p['mono']['path'],p['effects_output'],'--inspect',p['original_plugin']['path'],p['reused_compiled_donor']['path']],out,'inspect-exact-provider-discovery-and-rechecked-lookup-bindings',report);guard.bounded([p['mono']['path'],p['effects_output']],out,'thirty-real-Dictionary-discovery-and-combined-effects',report);check(p['original_plugin']);check(p['original_meta']);report.update(status='original_provider_discovery_binding_and_thirty_real_Dictionary_combined_cases_passed',compiled_donor=p['reused_compiled_donor'],donor_recompiled=False,original_successful_donor_compile_reused=p['prior_failed_receipt'],compiled_effects=pin(p['effects_output']),selected_members=2,controlled_cases=30)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='original_provider_discovery_binding_and_thirty_real_Dictionary_combined_cases_passed' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan.resolve(strict=True),v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
