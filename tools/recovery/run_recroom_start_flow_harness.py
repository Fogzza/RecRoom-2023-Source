"""Root-only full source binding and13 controlled effects for original Start.

Default preparation never compiles or runs. Candidate stays outside Main while
Addressables and higher bootstrap activation dependencies remain unrecovered.
"""
from pathlib import Path
import argparse, base64, datetime as dt, hashlib, json, shutil, uuid
import run_title_login_slice_harness_v3 as base
from run_title_login_slice_harness_v3 import HERE, WS, ROOT, EDITOR, RESPONSE, guard, pin, need, save, check
SLICE=ROOT/'Validation/RecRoomStartFlowCandidate-20261023T103232Z-8b043b4c/report.json'
SLICE_SHA='9286e28a76881e556ad2f778319cca1322d186405918f0078e2d2b471c51d344'
SCHEMA='prepared-original-RecRoomGameRoot-Start-full-binding-thirteen-effects/v1'

def candidate():
    need(pin(SLICE)['sha256']==SLICE_SHA,'Exact original complete Start candidate authority')
    r=json.loads(SLICE.read_bytes())
    need(not r['Main_modified'] and not r['Main_activation_approved'] and r['native_single_byte_mutations_rejected']==list(range(288)) and r['independent_peer_EH_review_received'],'Original whole native proof and activation HOLD')
    for key in ['native_proof','producer','native_proof_helper','EH_reader','source','meta','candidate']:check(r[key])
    before=Path(r['source']['path']).read_bytes();old=base64.b64decode(r['original_base64'],validate=True);member=base64.b64decode(r['replacement_base64'],validate=True);at=r['start']
    need(r['length']==len(old) and before[at:at+len(old)]==old and before[:at]+member+before[at+len(old):]==Path(r['candidate']['path']).read_bytes() and hashlib.sha256(member).hexdigest()==r['member_sha256'],'Only exact private Start body candidate; all other bytes preserved')
    return r,member,{r['source']['path'].casefold():Path(r['candidate']['path'])}

def effect_source(template,member):
    data=template.read_bytes();need(data.count(b'/*EXACT_START*/')==1,'One original body marker');return data.replace(b'/*EXACT_START*/',member)

def prepare():
    r,member,substitutions=candidate();out=ROOT/'Validation'/('RecRoomStartFlowBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    captured=out/'Unity-emitted-WindowsDevelopment-Assembly-CSharp.rsp';shutil.copyfile(RESPONSE,captured)
    response,inputs=base.response(captured.read_text(encoding='utf-8-sig'),out/'Assembly-CSharp.dll',substitutions);rsp=out/'full-Start-candidate-binding.rsp';rsp.write_text(response,encoding='utf-8',newline='\n');manifest=out/'full-compiler-inputs.json';save(manifest,inputs)
    template=HERE/'RecRoomStartFlowEffects.template.cs';source=out/'ExactStartControlledEffects.cs';source.write_bytes(effect_source(template,member))
    refs=[EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'/x for x in ['mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll']]+[WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll'];shutil.copyfile(refs[-1],out/'Mono.Cecil.dll')
    effects=out/'ExactStartControlledEffects.exe';fx=out/'effects-reader.rsp';fx.write_text('/nologo\n/nostdlib+\n/target:exe\n/langversion:8.0\n/out:"'+str(effects)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n',encoding='utf-8')
    p={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'slice':pin(SLICE),'template':pin(template),'source':pin(source),'captured_Unity_response':pin(captured),'full_response':pin(rsp),'effects_response':pin(fx),'compiler_inputs':pin(manifest),'effect_references':[pin(x) for x in refs],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'full_compile_cap_bytes':1024**3,'helper_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'source_count':sum(not x.startswith('/') for x in response.splitlines()),'reference_count':sum(x.startswith('/reference:') for x in response.splitlines()),'member_sha256':r['member_sha256'],'effects_output':str(effects),'selected_members':1,'controlled_cases':13,'Main_modified':False,'Main_activation_approved':False,'production_Addressables_or_startup_code_executed':False}
    need(p['source_count']==5095 and p['reference_count']==409 and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA,'Actual full source/reference scope and trusted guard')
    target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Exact Root-reviewed test plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('RecRoomStartFlowBindingEffects-') and p['selected_members']==1 and p['controlled_cases']==13 and p['full_compile_cap_bytes']==1024**3 and p['helper_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and not p['Main_activation_approved'],'Exact isolated binding/effects and activation HOLD')
    for key in ['runner','base_runner','slice','template','source','captured_Unity_response','full_response','effects_response','compiler_inputs','copied_Cecil','compiler','mono','guard','launcher']:check(p[key])
    for row in p['effect_references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['base_runner']==pin(Path(base.__file__)) and p['guard']['sha256']==base.GUARD_SHA and p['launcher']['sha256']==base.LAUNCH_SHA,'Exact current runner/guard')
    r,member,substitutions=candidate();need(r['member_sha256']==p['member_sha256'] and effect_source(Path(p['template']['path']),member)==Path(p['source']['path']).read_bytes(),'Same exact original member in actual and controlled sources')
    inputs=json.loads(Path(p['compiler_inputs']['path']).read_bytes())
    for row in inputs:check(row)
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':digest}));return 0
    need(not(out/'run-report.json').exists() and not(out/'Assembly-CSharp.dll').exists() and not Path(p['effects_output']).exists(),'Fresh one-shot test')
    report={'schema':'guarded-original-Start-full-source-binding-thirteen-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Main_activation_approved':False,'production_Addressables_or_startup_code_executed':False,'working_login_or_dorm_claimed':False}
    try:
        guard.CAP=p['full_compile_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['full_response']['path']],out,'compile-actual-full-original-Start-candidate',report);report['full_assembly']=pin(out/'Assembly-CSharp.dll')
        guard.CAP=p['helper_cap_bytes'];guard.bounded([p['compiler']['path'],'/noconfig','@'+p['effects_response']['path']],out,'compile-Start-effects-metadata-reader',report)
        guard.bounded([p['mono']['path'],p['effects_output'],'--inspect',str(out/'Assembly-CSharp.dll')],out,'inspect-actual-original-Start-bindings-metadata-only',report)
        guard.bounded([p['mono']['path'],p['effects_output']],out,'thirteen-original-Start-controlled-effects',report)
        for row in inputs:check(row)
        candidate();report.update(status='actual_full_original_Start_bindings_and_thirteen_controlled_effects_passed',source_count=5095,reference_count=409,controlled_cases=13)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='actual_full_original_Start_bindings_and_thirteen_controlled_effects_passed' else 1

if __name__=='__main__':
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--plan',type=Path);parser.add_argument('--plan-sha256');parser.add_argument('--run',action='store_true');args=parser.parse_args()
    if args.plan:need(args.plan_sha256,'Explicit reviewed plan SHA');raise SystemExit(execute(args.plan,args.plan_sha256,args.run))
    need(not args.run and not args.plan_sha256,'Prepare first with no child');prepare()
