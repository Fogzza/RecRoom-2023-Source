"""Pure preparation / Root-only compiler and fake-effects controls for17.

Exact selected candidates are inserted verbatim. Two original-identity donors
compile against genuine matching Unity APIs, but never CLR load. A distinct
effects executable has explicit fake engine APIs and real BCL collections.
No staging, Main application, renderer activation, Unity or network launch.
"""
from pathlib import Path
import argparse,copy,datetime as dt,json,re,shutil,uuid
import run_custom_urp_factory_cache_controls as base
from run_custom_urp_factory_cache_controls import HERE,WS,ROOT,EDITOR,guard,pin,check,need,save,GUARD_SHA,LAUNCH_SHA
from run_custom_urp_initializer_prerequisite_controls import enums
import run_custom_urp_initializer_prerequisite_controls as enum_helper
import audit_custom_urp_cecil_reindex as raw
import audit_custom_urp_cecil_reindex_v2 as cil

PROOF=ROOT/'Validation/CustomURPInitializerClosureCandidates-20261023T112814Z-c14788ea/report.json'
PROOF_SHA='4b3929f5c2ea730ac676d82128016dde2c06fef7c82f405966fb0f158bf810bf'
SUPPORT=ROOT/'Validation/CustomUrpInitializerPrerequisiteBindingEffectsV2-20261023T104211Z-f2e47736/plan.json'
SUPPORT_SHA='6f1ce7af416d352bca60ec100cfe597846d2917c4362a6b9679157cf33c913b9'
SUPPORT_PASS=ROOT/'Validation/CustomUrpInitializerPrerequisiteBindingEffectsV2-20261023T104211Z-f2e47736/run-report.json'
SUPPORT_PASS_SHA='341959bba58115716d5b20222ec15b5926e32dc2da198939264703a49d82d793'
SCHEMA='prepared-seventeen-original-custom-URP-initializer-XR-binding-effects/v1'
SUCCESS='seventeen_original_initializer_XR_bindings_53_controlled_effects_passed'
SELECTED={69734,69733,69749,69616,91168,91167,91429,91430,91435,91437,91447,91439,91441,91454,91347,91309,91340}
INSERTIONS={'TEXTURE_XR':'TextureXR.members.cs','PROFILING_CTOR':'ProfilingSampler.ctor.cs','STEREO_CTOR':'StereoConstants.FieldInitializersAndCtor.PROJECTION.cs','RENDERING_CCTOR':'RenderingUtils.cctor.cs','XRPASS_CTOR':'XRPass.FieldInitializersAndCtor.PROJECTION.cs','XRPASS_CCTOR':'XRPass.cctor.cs','XRSYSTEM_CTOR':'XRSystem.FieldInitializersAndCtor.PROJECTION.cs','XRSYSTEM_CCTOR':'XRSystem.cctor.cs','GET_DISPLAY':'XRSystem.GetDisplaySubsystem.cs','REFRESH':'XRSystem.RefreshXrSdk.cs','UPDATES':'XRSystem.Updates.cs','CALLBACK_CCTOR':'OriginalGeneratedCallbackSingleton.cctor.PROJECTION.cs','PIPELINE_CTOR':'UniversalRenderPipeline.Constructor.PROJECTION.cs','PIPELINE_CCTOR':'UniversalRenderPipeline.cctor.PROJECTION.cs'}
SUPPORT_INSERTIONS={'SUPPORT_CAPTURE':'CameraCaptureBridge.Enabled.members.cs','SUPPORT_ASSET':'UniversalRenderPipelineAsset.ConstructorGetterPrerequisites.members.cs','SUPPORT_CLEAR':'RenderingUtils.ClearSystemInfoCache.member.cs','SUPPORT_COMPARISON':'OriginalGeneratedCameraComparison.body.cs','SUPPORT_LIGHTS':'OriginalGeneratedLightmappingCallback.body.cs'}

def authority():
    need(pin(PROOF)['sha256']==PROOF_SHA and pin(SUPPORT)['sha256']==SUPPORT_SHA and pin(SUPPORT_PASS)['sha256']==SUPPORT_PASS_SHA,'Frozen17 proof and actual prior support effects')
    p=json.loads(PROOF.read_bytes());s=json.loads(SUPPORT.read_bytes());passed=json.loads(SUPPORT_PASS.read_bytes())
    need(p['status']=='17_original_methods_7165B_typed_native_source_candidates_uncompiled_activation_HELD' and not p['Main_modified'] and not p['compiler_managed_Unity_player_network_executed'] and not p['working_renderer_or_Main_activation_claimed'],'Uncompiled isolated17 candidates, activation held')
    need({r['original_native']['index'] for r in p['original17_members']}==SELECTED and len(p['original17_members'])==17 and len(p['candidate_sources'])==14,'Exact17 original methods and14 fragments')
    need(passed['status']=='twelve_original_initializer_prerequisite_bindings_31_controlled_effects_passed' and passed['selected_members']==12 and passed['controlled_effect_cases']==31,'Actual12 support bindings and31 effects')
    for row in p['candidate_sources']+p['current_candidates']+p['Root_complete_decodes']+p['original_inputs']+s['member_fragments']+[s['actual_Core_target'],s['actual_URP_target'],p['current_tested19_body_candidate_authority']]:check(row)
    return p,s

def render(p,s):
    source=(HERE/'CustomUrpInitializerSeventeen.v3.template.cs').read_text()
    selected={Path(row['path']).name:row for row in p['candidate_sources']};support={Path(row['path']).name:row for row in s['member_fragments']}
    for mapping,rows in [(INSERTIONS,selected),(SUPPORT_INSERTIONS,support)]:
        for marker,name in mapping.items():
            token='/*'+marker+'*/';need(source.count(token)==1,'One exact insertion '+marker);source=source.replace(token,Path(rows[name]['path']).read_text())
    need(source.count('/*ENUMS*/')==1,'One native enum value insertion');source=source.replace('/*ENUMS*/',enums(Path(p['current_candidates'][1]['path'])))
    names=re.findall(r'\bDone\("([^"\r\n]+)"\)',source);need(len(names)==len(set(names))==53 and 'Need(cases==53,' in source,'Exact53 named finite effects')
    inspector=(HERE/'InspectCustomUrpInitializerSeventeen.v8.template.cs').read_text();rows=[]
    for row in p['original17_members']:
        n=row['original_native'];name=n['name'];alias='OriginalComparison' if name=='<.ctor>b__32_0' else 'OriginalLights' if name=='<.cctor>b__73_0' else name
        owner=n['owner'];rows.append('Tuple.Create('+json.dumps('Core' if 'Core.Runtime' in n['image'] else 'URP')+',0x'+format(int(row['current_candidate_MethodDef_token'],16),'08X')+'u,'+json.dumps(owner)+','+json.dumps(name)+','+json.dumps(alias)+','+str(row['native_type_flags'])+'u)')
    need(inspector.count('/*EXACT_SPECS*/')==1,'One exact token/spec insertion');inspector=inspector.replace('/*EXACT_SPECS*/',',\n                '.join(rows))
    return source,inspector,names

def singleton_dependency(p):
    model=raw.Model(Path(p['current_candidates'][1]['path']));owner='UnityEngine.Rendering.Universal.UniversalRenderPipeline/<>c';rows=[]
    for name in ['.cctor','.ctor']:
        matches=[(i,m) for i,m in model.method.items() if m['owner'].endswith(owner) and m['name']==name];need(len(matches)==1,'One actual current generated '+name)
        i,m=matches[0];body=cil.decode(model,i);rows.append({'current_token':hex(0x06000000|i),'method':m,'complete_current_CIL':body})
    need(rows[0]['current_token']=='0x60002da' and rows[0]['complete_current_CIL']['instructions']==[{'opcode':'0x2a','operand':None}],'Current generated static ctor is exactly a ret stub, not restored')
    instructions=rows[1]['complete_current_CIL']['instructions'];need(len(instructions)==3 and [r['opcode'] for r in instructions]==['0x2','0x28','0x2a'],'Current generated instance constructor has three instructions')
    reference=json.loads(instructions[1]['operand']);need(reference=={'name':'.ctor','owner':'[mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]System.Object','signature':{'arity':0,'callconv':32,'parameters':[],'return':'void'}},'Exact existing real Object-only generated constructor')
    return {'schema':'current-URP-generated-singleton-dependency-explicit-HOLD/v1','current_URP_candidate':p['current_candidates'][1],'methods':rows,'current_static_initializer_is_ret_stub':True,'current_instance_constructor_is_real_Object_only':True,'selected17_contains_original89B_static_initializer_91347':True,'manual_initialization_or_guessed_global_cache_added':False,'original_static_initializer_must_be_body_staged_and_runtime_tested_before_activation':True,'runtime_activation_HELD':True,'managed_code_loaded':False,'Main_modified':False}

def scope(value):
    need(value['selected_members']==17 and value['controlled_effect_cases']==53 and value['cap_bytes']==256*1024**2 and value['reserve_bytes']==guard.RESERVE and value['maximum_seconds_per_phase']==90,'Exact17/53/256MiB/reserve/deadline scope')
    need(value['production_donors_loaded']==False and value['Unity_game_network_launched']==False and value['Main_modified']==False and value['renderer_activation_claimed']==False,'No real engine/renderer/Main execution admitted')
    need(value['native_BeforeFieldInit_preservation_required'] and value['initializers_before_base_required'] and value['callback_aliases_are_existing_declarations_only'] and value['existing_support_bodies_inserted_verbatim'],'Original static/ctor/generated/support contracts')

def pure_controls(value,source,inspector,names):
    scope(value);positive=['exact17_53_bounded_scope','all19_fragment_insertions_verbatim','all17_current_token_specs_generated','53_unique_effect_labels','explicit_engine_fakes_separate_preprocessor','genuine_production_donor_never_loaded','original_native_flags_not_donor_TypeDef_flags','only_existing_callback_aliases']
    need(all('/*'+m+'*/' not in source for m in list(INSERTIONS)+list(SUPPORT_INSERTIONS)+['ENUMS']) and '/*EXACT_SPECS*/' not in inspector,'All frozen fragments inserted')
    need(len(re.findall(r'Tuple.Create\("(?:Core|URP)",0x[0-9A-F]{8}u,',inspector))==17 and len(names)==len(set(names))==53,'Exact actual generated counts')
    negatives=[]
    def reject(label,mutate):
        candidate=copy.deepcopy(value);mutate(candidate)
        try:scope(candidate)
        except ValueError:negatives.append(label);return
        raise ValueError('Negative control accepted '+label)
    for key,changed in [('selected_members',18),('controlled_effect_cases',52),('cap_bytes',512*1024**2),('reserve_bytes',0),('maximum_seconds_per_phase',91),('production_donors_loaded',True),('Unity_game_network_launched',True),('Main_modified',True),('renderer_activation_claimed',True),('native_BeforeFieldInit_preservation_required',False),('initializers_before_base_required',False),('callback_aliases_are_existing_declarations_only',False),('existing_support_bodies_inserted_verbatim',False)]:reject(key,lambda c,k=key,v=changed:c.__setitem__(k,v))
    return {'schema':'pure-preparation-controls-seventeen-initializer-XR/v1','status':'passed','positive_controls':positive,'negative_controls':negatives,'managed_Unity_player_network_launched':False,'Main_modified':False}

def prepare():
    p,s=authority();source,inspector,names=render(p,s)
    out=ROOT/'Validation'/('CustomUrpInitializerSeventeenBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    source_path=out/'ExactOriginalInitializerSeventeen.cs';source_path.write_text(source,encoding='utf-8',newline='\n');inspect_path=out/'InspectExactInitializerSeventeen.cs';inspect_path.write_text(inspector,encoding='utf-8',newline='\n')
    api=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[api/n for n in ['mscorlib.dll','System.dll','System.Core.dll']];facade=api/'Facades/netstandard.dll'
    managed=EDITOR/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed';engine=[managed/n for n in ['UnityEngine.CoreModule.dll','UnityEngine.XRModule.dll','UnityEngine.SubsystemsModule.dll']]
    cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';shutil.copyfile(cecil,out/'Mono.Cecil.dll')
    core=out/'Unity.RenderPipelines.Core.Runtime.dll';urp=out/'Unity.RenderPipelines.Universal.Runtime.dll';inspect=out/'InspectInitializerSeventeen.exe';effects=out/'ExactInitializerSeventeenEffects.exe'
    def response(name,target,refs,src,kind,define=None):
        path=out/name;path.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(target)+'"\n'+('/define:'+define+'\n' if define else '')+''.join('/reference:"'+str(r)+'"\n' for r in refs)+'"'+str(src)+'"\n',encoding='utf-8',newline='\n');return pin(path)
    responses=[response('original-Core-owner.rsp',core,framework+engine,source_path,'library','INIT17_CORE'),response('original-URP-owner.rsp',urp,framework+engine+[core],source_path,'library','INIT17_URP'),response('metadata-inspector.rsp',inspect,framework+[cecil,facade],inspect_path,'exe'),response('fake-engine-effects.rsp',effects,framework,source_path,'exe','INIT17_EFFECTS')]
    plan={'schema':SCHEMA,'status':'prepared_no_child_no_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'native_proof':pin(PROOF),'support_plan':pin(SUPPORT),'support_actual_pass':pin(SUPPORT_PASS),'candidate_fragments':p['candidate_sources'],'support_fragments':s['member_fragments'],'source_template':pin(HERE/'CustomUrpInitializerSeventeen.v3.template.cs'),'inspector_template':pin(HERE/'InspectCustomUrpInitializerSeventeen.v8.template.cs'),'source':pin(source_path),'inspector_source':pin(inspect_path),'responses':responses,'references':[pin(x) for x in framework+engine+[cecil,facade]],'genuine_engine':[pin(x) for x in engine],'genuine_framework':[pin(x) for x in framework],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'actual_Core_target':p['current_candidates'][0],'actual_URP_target':p['current_candidates'][1],'Main_inputs':[pin(WS/'RR23/Assets/Plugins'/name) for name in ['Unity.RenderPipelines.Core.Runtime.dll','Unity.RenderPipelines.Core.Runtime.dll.meta','Unity.RenderPipelines.Universal.Runtime.dll','Unity.RenderPipelines.Universal.Runtime.dll.meta']],'core_donor_output':str(core),'urp_donor_output':str(urp),'inspector_output':str(inspect),'effect_output':str(effects),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'selected_members':17,'controlled_effect_cases':53,'effect_names':names,'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'native_BeforeFieldInit_preservation_required':True,'initializers_before_base_required':True,'callback_aliases_are_existing_declarations_only':True,'existing_support_bodies_inserted_verbatim':True,'production_donors_loaded':False,'Unity_game_network_launched':False,'Main_modified':False,'renderer_activation_claimed':False,'no_declarations_copied':True,'remaining_activation_HOLD':['body-only stage/full emitted preservation not performed for17','actual matching Unity smoke not performed for17','original ScriptableRenderer/ForwardRenderer constructors remain separate unclosed scopes','non-null Dispose and frame Render/Execute remain unrecovered']}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Frozen owned guard unchanged')
    singleton=out/'current-generated-singleton-dependency-HOLD.json';save(singleton,singleton_dependency(p));plan['current_singleton_dependency']=pin(singleton)
    plan['enum_helper']=pin(Path(enum_helper.__file__));plan['raw_enum_reader']=pin(Path(raw.__file__));plan['raw_CIL_reader']=pin(Path(cil.__file__))
    control=out/'pure-preparation-controls.json';save(control,pure_controls(plan,source,inspector,names));plan['pure_controls']=pin(control);path=out/'plan.json';save(path,plan)
    print(json.dumps({'plan':pin(path),'pure_controls':pin(control),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(path),'--plan-sha256',pin(path)['sha256'],'--run'],'managed_children_launched':False,'Main_modified':False}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Reviewed17 plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('CustomUrpInitializerSeventeenBindingEffects-') and p['schema']==SCHEMA,'Fresh exact17 fixture path/schema');scope(p)
    for row in [p[k] for k in ['runner','base_runner','enum_helper','raw_enum_reader','raw_CIL_reader','current_singleton_dependency','native_proof','support_plan','support_actual_pass','source_template','inspector_template','source','inspector_source','copied_Cecil','actual_Core_target','actual_URP_target','compiler','mono','guard','launcher','pure_controls']]+p['candidate_fragments']+p['support_fragments']+p['responses']+p['references']+p['genuine_engine']+p['genuine_framework']+p['Main_inputs']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact new runner and unchanged guard')
    original,support=authority();source,inspector,names=render(original,support)
    need(source==Path(p['source']['path']).read_text() and inspector==Path(p['inspector_source']['path']).read_text() and names==p['effect_names'] and pure_controls(p,source,inspector,names)==json.loads(Path(p['pure_controls']['path']).read_bytes()),'All actual frozen source insertions/token specs/count controls recomputed')
    need(singleton_dependency(original)==json.loads(Path(p['current_singleton_dependency']['path']).read_bytes()),'Exact existing static ret stub / real instance constructor boundary revalidated')
    for key,name in [('core_donor_output','Unity.RenderPipelines.Core.Runtime.dll'),('urp_donor_output','Unity.RenderPipelines.Universal.Runtime.dll'),('inspector_output','InspectInitializerSeventeen.exe'),('effect_output','ExactInitializerSeventeenEffects.exe')]:need(p[key]==str(out/name),'Fresh fixed compiler output')
    if not run:print(json.dumps({'status':'verified_no_child_no_Main_write','selected_members':17,'controlled_cases':53,'pure_positive_controls':8,'pure_negative_controls':13}));return 0
    need(not(out/'run-report.json').exists() and all(not Path(p[k]).exists() for k in ['core_donor_output','urp_donor_output','inspector_output','effect_output']),'One shot fresh outputs; preserve failed artifacts')
    report={'schema':'guarded-seventeen-original-initializer-XR-bindings-effects/v1','status':'starting','plan':pin(path),'phases':[],'production_donors_loaded':False,'Unity_game_network_launched':False,'Main_modified':False,'renderer_activation_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        for i,label in enumerate(['compile-exact-Core-four-original-owner-donor','compile-exact-URP-thirteen-original-owner-donor','compile-metadata-only-seventeen-inspector','compile-fake-engine-fifty-three-effects']):guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][i]['path']],out,label,report)
        args=[p['actual_Core_target']['path'],p['actual_URP_target']['path'],p['core_donor_output'],p['urp_donor_output']]+[v['path'] for v in p['genuine_engine']]+[p['genuine_framework'][i]['path'] for i in [0,2]]
        guard.bounded([p['mono']['path'],p['inspector_output']]+args,out,'inspect-seventeen-exact-original-bindings',report)
        text=(out/'inspect-seventeen-exact-original-bindings-stdout.log').read_text();need(len(re.findall(r'^BIND ',text,re.M))==17 and 'RESULT seventeen_exact_original_initializer_XR_bindings_passed_metadata_only; original_BeforeFieldInit_retained=true; initializers_before_base=true; existing_autoaccessor6_CIL_equal=true; support11_CIL_equal=true; production_donors_loaded=false; no_stub_SDK_callee=true' in text,'All17 original bindings/initializer/callee contracts')
        guard.bounded([p['mono']['path'],p['effect_output']],out,'fifty-three-original-initializer-XR-controlled-effects',report)
        text=(out/'fifty-three-original-initializer-XR-controlled-effects-stdout.log').read_text();need(re.findall(r'^PASS (.+)$',text,re.M)==p['effect_names'] and 'RESULT '+SUCCESS+'; genuine_Unity_executed=false; renderer_activation=false' in text,'All53 named controlled effects in exact order')
        for row in p['Main_inputs']+[p['actual_Core_target'],p['actual_URP_target']]:check(row)
        report.update(status=SUCCESS,selected_members=17,controlled_effect_cases=53,original_flags_and_initializer_order_checked=True,existing_support_callees_exact=True,compiled_Core_donor=pin(p['core_donor_output']),compiled_URP_donor=pin(p['urp_donor_output']),compiled_inspector=pin(p['inspector_output']),compiled_effects=pin(p['effect_output']))
    except BaseException as e:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(e))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']==SUCCESS else 1

def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--plan',type=Path);p.add_argument('--plan-sha256');p.add_argument('--run',action='store_true');a=p.parse_args()
    if a.plan:need(a.plan_sha256,'Explicit Root reviewed plan SHA');return execute(a.plan,a.plan_sha256,a.run)
    need(not a.run and not a.plan_sha256,'Pure preparation first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
