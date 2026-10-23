"""Prepare or Root-run actual full-file Route binding and exact-span effects.

Preparation starts no child and never changes Main. Root-only --run compiles
the current5095-source Windows MonoDev input with one full-file substitution.
Controlled effects use explicitly test-only SDK doubles, not game replacements.
"""
from pathlib import Path
import argparse,base64,datetime as dt,hashlib,json,shutil,uuid
import run_title_login_slice_harness_v3 as base
from run_title_login_slice_harness_v3 import guard,pin,need,save,check,HERE,WS,ROOT,EDITOR,RESPONSE
SLICE=ROOT/'Validation/TitlePageRouteSlice-v2-20261023T070346Z-93f0cece/report.json'
SLICE_SHA='790eacf90d754643307480b314605122ee645acf412c07e511c43c0e77f59f9b'
APPLIED=ROOT/'Validation/TitleLoginExactApply-20261023T065708Z-a4cb9d48/apply-receipt.json'
APPLIED_SHA='7349366a4c7caa94e32669ed36cad2300ea513789c9f7a506acb428ab7469830'
SCHEMA='prepared-original-TitlePage-Route-full-file-binding-and-effects/v2'
def candidate():
    need(pin(SLICE)['sha256']==SLICE_SHA and pin(APPLIED)['sha256']==APPLIED_SHA,'Exact Route slice and actual applied UI callers')
    r=json.loads(SLICE.read_bytes());
    for contract in r['source_binding_alias']['actual_runtime_and_compile_contracts']:check(contract['assembly'])
    a=json.loads(APPLIED.read_bytes());need(a['status']=='exact_two_reviewed_members_applied_other_bytes_and_metas_preserved','Prior actual two-member apply proof')
    for k in ['source','source_meta','candidate']:check(r[k])
    e=r['byte_edit'];before=Path(r['source']['path']).read_bytes();after=Path(r['candidate']['path']).read_bytes();old=base64.b64decode(e['original_base64'],validate=True);new=base64.b64decode(e['replacement_base64'],validate=True);start=e['start']
    need(e['length']==len(old) and before[start:start+len(old)]==old and after==before[:start]+new+before[start+len(old):],'Only exact nested original Route property span')
    need(any(x['source']==r['source'] for x in a['applied']),'Route source must start at actual GoToLogin-applied full file')
    for x in a['applied']:check(x['source']);check(x['meta'])
    return r,new
def prepare():
    r,span=candidate();out=ROOT/'Validation'/('TitlePageRouteBindingEffects-v2-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    snapshot=out/'Unity-emitted-WindowsDevelopment-Assembly-CSharp.rsp';shutil.copyfile(RESPONSE,snapshot)
    response,inputs=base.response(snapshot.read_text(encoding='utf-8-sig'),out/'Assembly-CSharp.dll',{r['source']['path'].casefold():Path(r['candidate']['path'])})
    rsp=out/'full-route-candidate-binding.rsp';rsp.write_text(response,encoding='utf-8',newline='\n');manifest=out/'full-compiler-inputs.json';save(manifest,inputs)
    template=HERE/'TitlePageRouteEffects.v2.template.cs';data=template.read_bytes();need(data.count(b'/*EXACT_ROUTE_PROPERTY*/')==1,'Unique exact property marker');source=out/'ExactRouteControlledEffects.cs';source.write_bytes(data.replace(b'/*EXACT_ROUTE_PROPERTY*/',span))
    refs=[EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'/x for x in ['mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll']]+[WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll']
    shutil.copyfile(refs[-1],out/'Mono.Cecil.dll');fx=out/'controlled-effects.rsp';fx.write_text('/nologo\n/nostdlib+\n/target:exe\n/langversion:8.0\n/out:"'+str(out/'ExactRouteControlledEffects.exe')+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n',encoding='utf-8')
    sdk=[]
    for name in ['RecRoom.AgInitialization.Runtime.dll','RecRoom.GameSystems.Interfaces.dll']:
        rows=[x for x in inputs if Path(x['path']).name==name];need(len(rows)==1,'Exact current compiler SDK reference '+name);sdk.append(rows[0])
    p={'schema':SCHEMA,'status':'prepared_no_compiler_or_test_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'previous_failed_binding_receipt':pin(ROOT/'Validation/TitlePageRouteBindingEffects-20261023T070055Z-d677936a/run-report.json'),'slice':pin(SLICE),'actual_previous_apply':pin(APPLIED),'template':pin(template),'source':pin(source),'captured_Unity_response':pin(snapshot),'full_response':pin(rsp),'effect_response':pin(fx),'compiler_inputs':pin(manifest),'effect_references':[pin(x) for x in refs],'sdk_property_references':sdk,'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'full_compile_cap_bytes':1024**3,'helper_and_effect_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'source_count':sum(not x.startswith('/') for x in response.splitlines()),'reference_count':sum(x.startswith('/reference:') for x in response.splitlines()),'exact_candidate_span_sha256':hashlib.sha256(span).hexdigest(),'effect_cases':13,'test_doubles_are_explicitly_test_only':True,'Main_modified':False,'production_callees_recovered_or_working_title_claimed':False}
    need(p['source_count']==5095 and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA,'Fixed genuine compile/guard scope')
    target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed Route plan SHA');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('TitlePageRouteBindingEffects-v2-'),'Exact isolated Route fixture')
    for k in ['previous_failed_binding_receipt','runner','base_runner','slice','actual_previous_apply','template','source','captured_Unity_response','full_response','effect_response','compiler_inputs','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for x in p['effect_references']+p['sdk_property_references']:check(x)
    need(p['runner']==pin(Path(__file__)) and p['base_runner']==pin(Path(base.__file__)) and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA,'Reviewed runners/owned guard')
    need(p['full_compile_cap_bytes']==1024**3 and p['helper_and_effect_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90,'Fixed owned resource bounds')
    r,span=candidate();need(hashlib.sha256(span).hexdigest()==p['exact_candidate_span_sha256'],'Exact source span')
    inputs=json.loads(Path(p['compiler_inputs']['path']).read_bytes())
    for x in inputs:check(x)
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected}));return 0
    need(all(not(out/x).exists() for x in ['run-report.json','Assembly-CSharp.dll','ExactRouteControlledEffects.exe']),'Fresh one-shot Route fixture')
    report={'schema':'guarded-original-TitlePage-Route-full-file-binding-and-effects/v2','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Unity_network_or_production_game_code_executed':False,'working_title_or_login_claimed':False}
    try:
        guard.CAP=p['full_compile_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['full_response']['path']],out,'compile-actual-full-route-candidate-file',report);report['full_assembly']=pin(out/'Assembly-CSharp.dll')
        guard.CAP=p['helper_and_effect_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['effect_response']['path']],out,'compile-controlled-Route-effects-and-reader',report)
        guard.bounded([p['mono']['path'],str(out/'ExactRouteControlledEffects.exe'),'--inspect',str(out/'Assembly-CSharp.dll')]+[x['path'] for x in p['sdk_property_references']],out,'inspect-real-Route-binding-metadata-only',report)
        guard.bounded([p['mono']['path'],str(out/'ExactRouteControlledEffects.exe')],out,'execute-exact-Route-property-controlled-effects',report)
        for x in inputs:check(x)
        candidate();report.update(status='actual_full_Route_file_binding_and_thirteen_controlled_effect_cases_passed',actual_full_file_compiled=True,metadata_binding_verified=True,controlled_effect_cases=13,all_Main_sources_and_selected_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_full_Route_file_binding_and_thirteen_controlled_effect_cases_passed' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed Route plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without starting a child');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
