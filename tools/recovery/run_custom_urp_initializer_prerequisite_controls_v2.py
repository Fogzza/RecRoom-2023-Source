"""Prepare/Root-run the twelve prerequisite controls with one inspector fix.

The frozen two production donors are reused byte for byte. Only a fresh fake
effects/metadata-inspector executable is compiled. Generic parameter identity
is kind plus position, never its display name. No production code is loaded.
"""
from pathlib import Path
import argparse, copy, datetime as dt, json, re, shutil, uuid
import run_custom_urp_initializer_prerequisite_controls as old
from run_custom_urp_factory_cache_controls import HERE, ROOT, guard, pin, check, need, save, GUARD_SHA, LAUNCH_SHA
import audit_custom_urp_cecil_reindex as raw
import audit_custom_urp_cecil_reindex_v2 as cil

BASE = ROOT/'Validation/CustomUrpInitializerPrerequisiteBindingEffects-20261023T103342Z-57fa6ac5'
PLAN_SHA = '3d3c2077bf02ebc10da345aa474df0ba3753d88542c58775cbaba0c42790d4b9'
FAILED_SHA = '06c718170ae47e8861fe4c2d9b9cf78295044a032e480f54e679d034daf6d450'
OLD = 'static string TypeKey(TypeReference t){return t.FullName;}'
NEW = 'static string TypeKey(TypeReference t){if(t is GenericParameter p)return (p.Type==GenericParameterType.Type?"!":"!!")+p.Position;return t.FullName;}'
SCHEMA = 'prepared-twelve-original-custom-URP-initializer-prerequisite-bindings-effects/v2'
SUCCESS = 'twelve_original_initializer_prerequisite_bindings_31_controlled_effects_passed'

def baseline():
    need(pin(BASE/'plan.json')['sha256']==PLAN_SHA and pin(BASE/'run-report.json')['sha256']==FAILED_SHA,'Exact preserved original plan and failed receipt')
    p=json.loads((BASE/'plan.json').read_bytes());r=json.loads((BASE/'run-report.json').read_bytes())
    need(p['runner']==pin(Path(old.__file__)) and r['status']=='failed_or_guard_refused_preserve_outputs','Frozen v1 provenance')
    need([x['phase'] for x in r['phases']]==['compile-original-Core-prerequisite-donor','compile-original-URP-prerequisite-donor','compile-twelve-prerequisite-controlled-effects','inspect-twelve-original-typed-prerequisite-bindings'],'Exact original four phases')
    need([x['exit_code'] for x in r['phases']]==[0,0,0,1] and all(x['owned_child_exit_confirmed'] and x['launcher']['membership_verified_before_resume'] for x in r['phases']),'All three original compiles passed; inspector alone failed')
    stderr=BASE/'inspect-twelve-original-typed-prerequisite-bindings-stderr.log'
    need(stderr.read_text().strip()=='Exception: exact genuine Unity/BCL callee System.Void Unity.Collections.NativeArray`1<UnityEngine.Experimental.GlobalIllumination.LightDataGI>::set_Item(System.Int32,!0)','Only the diagnosed inspector failure')
    keys=['runner','base_runner','native_proof','template','source','genuine_Unity','genuine_mscorlib','copied_Cecil','actual_Core_target','actual_URP_target','Main_URP_unchanged','Main_Core_meta','Main_URP_meta','compiler','mono','guard','launcher']
    for row in [p[k] for k in keys]+p['member_fragments']+p['responses']+p['references']:check(row)
    old.proof()
    outputs=[pin(p[k]) for k in ['core_donor_output','urp_donor_output','effect_output']]
    return p,outputs

def generic_proof(p):
    donor=raw.Model(Path(p['urp_donor_output']));engine=raw.Model(Path(p['genuine_Unity']['path']))
    selected=[mi for mi,m in donor.method.items() if m['name']=='OriginalLights'];need(len(selected)==1,'One original light callback alias')
    body=cil.decode(donor,selected[0]);refs=[]
    for instruction in body['instructions']:
        value=instruction['operand']
        if isinstance(value,str) and value.startswith('{'):
            v=json.loads(value)
            if v.get('name')=='set_Item':refs.append(v)
    need(len(refs)==1,'One actual NativeArray setter operand');reference=refs[0]
    expected_owner='valuetype [UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]Unity.Collections.NativeArray`1<valuetype [UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]UnityEngine.Experimental.GlobalIllumination.LightDataGI>'
    need(reference['owner']==expected_owner,'Exact constructed NativeArray<LightDataGI> and genuine engine scope')
    declared=[(mi,m) for mi,m in engine.method.items() if m['owner']=='[UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]Unity.Collections.NativeArray`1' and m['name']=='set_Item']
    need(len(declared)==1,'Unique genuine NativeArray setter');mi,method=declared[0]
    need(reference['signature']==method['signature']=={'arity':0,'callconv':32,'parameters':['int32','!0'],'return':'void'},'Exact same Type VAR0 structural method signatures')
    owner=engine.owner[mi];c=engine.c;params=[]
    for ri in range(1,c.rows[42]+1):
        at=c.row(42,ri);coded=c.value(at+4,c.coded(1,[2,6]))
        if coded==owner<<1:params.append({'kind':'type','position':c.u16(at),'flags':c.u16(at+2),'name':c.string(c.value(at+4+c.coded(1,[2,6]),c.strw))})
    need(params==[{'kind':'type','position':0,'flags':24,'name':'T'}],'Actual declaration parameter display name T, Type VAR0')
    blob=c.blob(c.value(c.row(6,mi)+8+c.strw,c.blobw)).hex();need(blob=='200201081300','Genuine exact method signature encoding')
    # Negative controls retain owner namespace/scope, kind, position, argument,
    # return, calling convention and primitive type distinctions.
    variants=[]
    def negative(label,mutate):
        v=copy.deepcopy(reference);mutate(v);need(v!=reference,'Reject '+label);variants.append(label)
    negative('method_MVAR0_is_not_type_VAR0',lambda v:v['signature']['parameters'].__setitem__(1,'!!0'))
    negative('type_VAR1_is_not_type_VAR0',lambda v:v['signature']['parameters'].__setitem__(1,'!1'))
    negative('int64_index_is_not_int32',lambda v:v['signature']['parameters'].__setitem__(0,'int64'))
    negative('nonvoid_return',lambda v:v['signature'].__setitem__('return','int32'))
    negative('static_calling_convention',lambda v:v['signature'].__setitem__('callconv',0))
    negative('different_constructed_argument',lambda v:v.__setitem__('owner',v['owner'].replace('LightDataGI','LightDataGIWrong')))
    negative('different_engine_scope',lambda v:v.__setitem__('owner',v['owner'].replace('Version=0.0.0.0','Version=1.0.0.0')))
    negative('different_member_name',lambda v:v.__setitem__('name','get_Item'))
    return {'schema':'pure-actual-CLI-generic-parameter-inspector-diagnosis/v1','status':'passed','donor':pin(p['urp_donor_output']),'genuine_engine':pin(p['genuine_Unity']['path']),'donor_callback_token':hex(0x06000000|selected[0]),'complete_callback_CIL':body,'actual_member_reference':reference,'genuine_method_token':hex(0x06000000|mi),'genuine_method_signature_blob':blob,'genuine_type_generic_parameter':params[0],'identical_ECMA_type_VAR0_signatures':True,'display_names_are_not_generic_parameter_identity':True,'negative_controls':variants,'managed_code_loaded':False,'Main_modified':False}

def source_only_fix(source):
    need(source.count(OLD)==1 and NEW not in source,'Exact single old display-name comparator')
    amended=source.replace(OLD,NEW)
    need(amended.replace(NEW,OLD)==source and amended.count(NEW)==1,'Only generic parameter key changed; every body/callee gate retained')
    need(len(re.findall(r'\bDone\("',amended))==31 and 'Need(cases==31,' in amended,'All original31 effects unchanged')
    return amended

def prepare():
    p,outputs=baseline();diagnosis=generic_proof(p)
    out=ROOT/'Validation'/('CustomUrpInitializerPrerequisiteBindingEffectsV2-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    template=HERE/'CustomUrpInitializerPrerequisiteControls.v2.template.cs'
    need(template.read_text()==source_only_fix(Path(p['template']['path']).read_text()),'Fresh template only exact inspector comparator amendment')
    source=out/'ExactOriginalInitializerPrerequisites.v2.cs';source.write_text(source_only_fix(Path(p['source']['path']).read_text()),encoding='utf-8',newline='\n')
    diagnosis_path=out/'generic-parameter-diagnosis.json';save(diagnosis_path,diagnosis)
    effect=out/'ExactInitializerPrerequisiteEffects.v2.exe';response=out/'controlled-effects-v2.rsp'
    previous_rsp=Path(p['responses'][2]['path']).read_text();need(previous_rsp.count(p['effect_output'])==1 and previous_rsp.count(p['source']['path'])==1,'Exact original effects compiler response')
    response.write_text(previous_rsp.replace(p['effect_output'],str(effect)).replace(p['source']['path'],str(source)),encoding='utf-8',newline='\n')
    shutil.copyfile(p['copied_Cecil']['path'],out/'Mono.Cecil.dll')
    plan={'schema':SCHEMA,'status':'prepared_no_child_no_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'v1_runner':p['runner'],'base_runner':p['base_runner'],'v1_plan':pin(BASE/'plan.json'),'v1_failed_run':pin(BASE/'run-report.json'),'v1_source':p['source'],'v1_template':p['template'],'v1_three_successful_outputs':outputs,'v1_stderr':pin(BASE/'inspect-twelve-original-typed-prerequisite-bindings-stderr.log'),'diagnosis':pin(diagnosis_path),'template':pin(template),'source':pin(source),'response':pin(response),'copied_Cecil':pin(out/'Mono.Cecil.dll'),'effect_output':str(effect),'reused_Core_donor':outputs[0],'reused_URP_donor':outputs[1],'original_compiled_effects_preserved_unused':outputs[2],'native_proof':p['native_proof'],'member_fragments':p['member_fragments'],'references':p['references'],'genuine_Unity':p['genuine_Unity'],'genuine_mscorlib':p['genuine_mscorlib'],'actual_Core_target':p['actual_Core_target'],'actual_URP_target':p['actual_URP_target'],'Main_URP_unchanged':p['Main_URP_unchanged'],'Main_Core_meta':p['Main_Core_meta'],'Main_URP_meta':p['Main_URP_meta'],'compiler':p['compiler'],'mono':p['mono'],'guard':p['guard'],'launcher':p['launcher'],'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'selected_members':12,'controlled_effect_cases':31,'only_source_amendment':{'before':OLD,'after':NEW,'all_other_source_bytes_equal':True},'pure_negative_controls':8,'Main_modified':False,'production_donors_or_Unity_loaded_or_executed':False,'constructor_or_renderer_closure_claimed':False}
    target=out/'plan.json';save(target,plan)
    print(json.dumps({'plan':pin(target),'diagnosis':pin(diagnosis_path),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed v2 plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('CustomUrpInitializerPrerequisiteBindingEffectsV2-') and p['schema']==SCHEMA,'Exact fresh sibling scope')
    need(p['selected_members']==12 and p['controlled_effect_cases']==31 and p['pure_negative_controls']==8 and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Exact finite resource and effect scope')
    keys=['runner','v1_runner','base_runner','v1_plan','v1_failed_run','v1_source','v1_template','v1_stderr','diagnosis','template','source','response','copied_Cecil','reused_Core_donor','reused_URP_donor','original_compiled_effects_preserved_unused','native_proof','genuine_Unity','genuine_mscorlib','actual_Core_target','actual_URP_target','Main_URP_unchanged','Main_Core_meta','Main_URP_meta','compiler','mono','guard','launcher']
    for row in [p[k] for k in keys]+p['v1_three_successful_outputs']+p['member_fragments']+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact runner and frozen owned guard')
    original,outputs=baseline();need(outputs==p['v1_three_successful_outputs'] and generic_proof(original)==json.loads(Path(p['diagnosis']['path']).read_bytes()),'Recheck actual complete raw CLI evidence and8 negative controls')
    need(Path(p['source']['path']).read_text()==source_only_fix(Path(p['v1_source']['path']).read_text()) and p['only_source_amendment']=={'before':OLD,'after':NEW,'all_other_source_bytes_equal':True},'Only proven generic display-name inspector fix')
    need(p['effect_output']==str(out/'ExactInitializerPrerequisiteEffects.v2.exe'),'Fresh fixed helper output')
    if not run:print(json.dumps({'status':'verified_no_child_no_Main_write','members':12,'effects':31,'pure_negative_controls':8,'reused_donors':2}));return 0
    need(not(out/'run-report.json').exists() and not Path(p['effect_output']).exists(),'One-shot fresh helper and receipt; preserve failures')
    report={'schema':'guarded-twelve-original-custom-URP-initializer-prerequisite-bindings-effects/v2','status':'starting','plan':pin(path),'phases':[],'reused_successful_v1_donor_compiles':p['v1_three_successful_outputs'][:2],'preserved_original_failure':p['v1_failed_run'],'Main_modified':False,'production_donors_or_Unity_loaded_or_executed':False,'constructor_or_renderer_closure_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        guard.bounded([p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-inspector-v2-and-unchanged31-effects',report)
        guard.bounded([p['mono']['path'],p['effect_output'],'--inspect',p['actual_Core_target']['path'],p['actual_URP_target']['path'],p['reused_Core_donor']['path'],p['reused_URP_donor']['path'],p['genuine_Unity']['path'],p['genuine_mscorlib']['path']],out,'inspect-twelve-original-typed-prerequisite-bindings-v2',report)
        text=(out/'inspect-twelve-original-typed-prerequisite-bindings-v2-stdout.log').read_text();need('RESULT twelve_exact_original_initializer_prerequisite_bindings_passed_metadata_only; exact_two_generated_aliases_explicit=true; production_donors_loaded=false' in text and 'future_import_requires_exact_original_field_TypeSpec=true' in text,'Exact12 original binding witnesses and original HashSet scope hold')
        guard.bounded([p['mono']['path'],p['effect_output']],out,'thirty-one-original-prerequisite-controlled-effects',report)
        text=(out/'thirty-one-original-prerequisite-controlled-effects-stdout.log').read_text();need(len(re.findall(r'^PASS ',text,re.M))==31 and 'RESULT twelve_original_initializer_prerequisites_31_controlled_effects_passed; genuine_Unity_executed=false; renderer_closure=false' in text,'All31 actual unchanged controlled effects')
        for row in [p[k] for k in ['actual_Core_target','actual_URP_target','Main_URP_unchanged','Main_Core_meta','Main_URP_meta']]+p['v1_three_successful_outputs']:check(row)
        report.update(status=SUCCESS,compiled_Core_donor=p['reused_Core_donor'],compiled_URP_donor=p['reused_URP_donor'],compiled_effects=pin(p['effect_output']),selected_members=12,controlled_effect_cases=31,generic_parameter_identity='ECMA type/method kind plus position; display name excluded',all_other_source_bytes_equal=True,original_Core_HashSet_scope_import_hold_explicit=True)
    except BaseException as e:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(e))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']==SUCCESS else 1

def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--plan',type=Path);p.add_argument('--plan-sha256');p.add_argument('--run',action='store_true');a=p.parse_args()
    if a.plan:need(a.plan_sha256,'Explicit Root plan SHA');return execute(a.plan,a.plan_sha256,a.run)
    need(not a.run and not a.plan_sha256,'Pure preparation first');prepare();return 0

if __name__=='__main__':raise SystemExit(main())
