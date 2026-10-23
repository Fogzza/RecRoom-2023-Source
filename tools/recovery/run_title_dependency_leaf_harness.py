"""Prepare or Root-run three actual full-file leaf bindings and15 effects.

Uses original native+injected attribute provider and exact export rename rule.
The actual full compile/Cecil ldfld check supplies source symbol binding; only
explicit test-only getter subjects run. No Main write or production invocation.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,shutil,uuid
import run_title_login_slice_harness_v3 as base
from run_title_login_slice_harness_v3 import guard,pin,need,save,check,HERE,WS,ROOT,EDITOR,RESPONSE
import run_title_display_callback_harness as display
SLICE=ROOT/'Validation/TitleDependencyLeafProperties-20261023T083105Z-041fd428/report.json'
SLICE_SHA='c1db3b610088f936736a9074cd348fb45e727fd1897aa8511dca8d07a285ce64'
SCHEMA='prepared-three-original-title-leaf-full-file-bindings-effects/v1'

def candidate():
    need(pin(SLICE)['sha256']==SLICE_SHA,'Exact three original single-field candidate evidence');r=json.loads(SLICE.read_bytes());need(r['all_bytes_outside_three_null_expressions_preserved'] and r['all_original_script_meta_bytes_preserved'] and len(r['sources'])==3,'Only three exact null expressions changed')
    for k in ['native_inline_evidence','original_attribute_provider','current_title_checkpoint']:check(r[k])
    for x in r['reused_policy_sources']:check(x)
    bodies=[]
    for row in r['sources']:
        for k in ['source','source_meta','candidate']:check(row[k])
        e=row['byte_edit'];before=Path(row['source']['path']).read_bytes();after=Path(row['candidate']['path']).read_bytes();old=base64.b64decode(e['original_base64'],validate=True);new=base64.b64decode(e['replacement_base64'],validate=True);at=e['start'];need(old==b'null' and e['length']==4 and before[at:at+4]==old and new==('this.'+row['source_field']).encode() and after==before[:at]+new+before[at+4:],'Only exact same-instance original field expression');body=base64.b64decode(row['exact_proposed_getter_body_base64'],validate=True);need(body==b'return '+new+b';','Exact full getter statement inserted in explicit test subject');bodies.append(body)
    return r,bodies

def prepare():
    r,bodies=candidate();runtime=display.runtime_checkpoint();out=ROOT/'Validation'/('TitleDependencyLeafBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();captured=out/'Unity-emitted-WindowsDevelopment-Assembly-CSharp.rsp';shutil.copyfile(RESPONSE,captured);replace={row['source']['path'].casefold():Path(row['candidate']['path']) for row in r['sources']};text,inputs=base.response(captured.read_text(encoding='utf-8-sig'),out/'Assembly-CSharp.dll',replace);rsp=out/'full-three-leaf-candidate-binding.rsp';rsp.write_text(text,encoding='utf-8',newline='\n');manifest=out/'full-compiler-inputs.json';save(manifest,inputs)
    template=HERE/'TitleDependencyLeafEffects.template.cs';data=template.read_bytes()
    for i,body in enumerate(bodies):marker=('/*LEAF'+str(i)+'_BODY*/').encode();need(data.count(marker)==1,'Unique exact leaf marker');data=data.replace(marker,body)
    source=out/'ExactTitleLeafControlledEffects.cs';source.write_bytes(data);refs=[EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'/x for x in ['mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll']]+[WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll'];shutil.copyfile(refs[-1],out/'Mono.Cecil.dll');fx=out/'controlled-effects.rsp';fx.write_text('/nologo\n/nostdlib+\n/target:exe\n/langversion:8.0\n/out:"'+str(out/'ExactTitleLeafControlledEffects.exe')+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n',encoding='utf-8')
    p={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'runtime_checkpoint_provider':pin(Path(display.__file__)),'slice':pin(SLICE),'original_attribute_provider':r['original_attribute_provider'],'current_title_checkpoint':r['current_title_checkpoint'],'current_actual_runtime_checkpoint':runtime,'template':pin(template),'source':pin(source),'captured_Unity_response':pin(captured),'full_response':pin(rsp),'effect_response':pin(fx),'compiler_inputs':pin(manifest),'effect_references':[pin(x) for x in refs],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'full_compile_cap_bytes':1024**3,'helper_and_effect_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'source_count':sum(not x.startswith('/') for x in text.splitlines()),'reference_count':sum(x.startswith('/reference:') for x in text.splitlines()),'effect_cases':15,'selected_properties':3,'test_doubles_are_explicitly_test_only':True,'binding_proof_scope':'Full5095-source Csc binding then exact same-owner typed ldfld IL; original provider Token/RVA/FieldOffset ownership, raw PropertyDef getter ownership, exact original CompilerGenerated enclosed-name export rule, complete original/current field count/type sequence and chosen ordinal. No broad old getter-pack run or source shadow class claim.','Main_modified':False,'callee_bodies_completed_or_working_boot_claimed':False};need(p['source_count']==5095 and p['reference_count']==409 and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA,'Exact genuine full compile/owned guard scope');target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed leaf plan SHA');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitleDependencyLeafBindingEffects-'),'Exact isolated three-leaf output scope')
    for k in ['runner','base_runner','runtime_checkpoint_provider','slice','original_attribute_provider','current_title_checkpoint','template','source','captured_Unity_response','full_response','effect_response','compiler_inputs','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for x in p['effect_references']:check(x)
    need(p['runner']==pin(Path(__file__)) and p['base_runner']==pin(Path(base.__file__)) and p['runtime_checkpoint_provider']==pin(Path(display.__file__)) and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA and p['full_compile_cap_bytes']==1024**3 and p['helper_and_effect_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and p['selected_properties']==3 and p['effect_cases']==15,'Exact reviewed resource/helper/scope limits');need(display.runtime_checkpoint()==p['current_actual_runtime_checkpoint'],'Current actual SDK baseline unchanged');r,bodies=candidate();data=Path(p['template']['path']).read_bytes()
    for i,body in enumerate(bodies):data=data.replace(('/*LEAF'+str(i)+'_BODY*/').encode(),body)
    need(data==Path(p['source']['path']).read_bytes(),'Exact body bytes in explicit controlled effects');inputs=json.loads(Path(p['compiler_inputs']['path']).read_bytes())
    for x in inputs:check(x)
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected}));return 0
    need(all(not(out/x).exists() for x in ['run-report.json','Assembly-CSharp.dll','ExactTitleLeafControlledEffects.exe']),'Fresh one-shot Root test outputs');report={'schema':'guarded-three-original-title-leaf-bindings-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Unity_network_or_production_game_code_executed':False,'working_boot_title_login_claimed':False}
    try:
        guard.CAP=p['full_compile_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['full_response']['path']],out,'compile-actual-full-three-title-leaf-candidate-files',report);report['full_assembly']=pin(out/'Assembly-CSharp.dll');guard.CAP=p['helper_and_effect_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['effect_response']['path']],out,'compile-exact-title-leaf-controlled-effects-reader',report);guard.bounded([p['mono']['path'],str(out/'ExactTitleLeafControlledEffects.exe'),'--inspect',p['original_attribute_provider']['path'],str(out/'Assembly-CSharp.dll')],out,'inspect-original-field-mapping-and-three-leaf-bindings',report);guard.bounded([p['mono']['path'],str(out/'ExactTitleLeafControlledEffects.exe')],out,'fifteen-exact-title-leaf-controlled-effects',report)
        for x in inputs:check(x)
        candidate();need(display.runtime_checkpoint()==p['current_actual_runtime_checkpoint'],'Runtime checkpoint unchanged after test');report.update(status='actual_full_three_leaf_file_bindings_original_field_mappings_and_fifteen_controlled_cases_passed',actual_full_file_compiled=True,metadata_binding_verified=True,original_field_mapping_verified=True,controlled_effect_cases=15,all_Main_sources_and_selected_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_full_three_leaf_file_bindings_original_field_mappings_and_fifteen_controlled_cases_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed leaf plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without children');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
