"""ROOT-only actual D3D11 probes in a proved fresh copy; no build/Editor/network."""
from pathlib import Path
import argparse
import datetime as dt
import json
import re
import uuid
import map_shader_buildreport as native
import prepare_eight_original_shader_gpu_fixture as proof
import run_windows_development_define_probe as guard


def verify(path,wanted):
    native.need(guard.sha(path)==wanted,'Exact reviewed Root GPU plan hash')
    plan=json.loads(path.read_bytes());root=path.parent.resolve(strict=True)
    native.need(root.is_relative_to(proof.context.AR) and root.name.startswith('EightOriginalShaderGPUFixture-')
        and plan['schema']=='actual-restored-eight-original-Shader-Root-D3D11-probe-plan/v1'
        and tuple(r['guid'] for r in plan['cases'])==proof.context.projection.GUIDS,'Exact isolated8 GPU fixture')
    for key in ('player','source_runtime_harness','actual_build_report','actual_native_patch_report','native_patch_plan','clone_inventory','source_facts','runner','guard','launcher'):guard.checked(plan[key])
    proof.verify_patch()
    inventory=json.loads(Path(plan['clone_inventory']['path']).read_bytes())
    for row in inventory:guard.checked(row['clone']);guard.checked(row['original'])
    player_root=Path(plan['player_root']).resolve(strict=True)
    native.need({p.resolve() for p in player_root.rglob('*') if p.is_file()}=={Path(r['clone']['path']).resolve() for r in inventory},'Complete unchanged clone inventory before GPU launch')
    native.need(plan['owned_job_cap_bytes']==1536*1024**2 and plan['reserve_bytes']==int(1.5*1024**3) and plan['deadline_seconds_each']==60,'Exact existing runtime caps/deadline')
    for case in plan['cases']:
        guard.checked(case['ParsedForm'])
        native.need(case['pipeline_tag_argument'] in ('unchanged',proof.URP_TAG) and case['resource_key']=='OriginalShaders/'+case['guid'],'Exact source-backed resource and allowed pipeline selection')
        fallback=case['pass_count_source'].get('fallback_identity_proof',{})
        for key in ('genuine_builtin_model','genuine_builtin_ParsedForm','original_ParsedForm'):
            if key in fallback:guard.checked(fallback[key])
    return plan,root


def run(path,plan,root):
    out=root/('Runtime-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'ROOT-owned-restored-eight-original-Shader-D3D11-probes/v1','status':'starting','plan':native.pin(path),'phases':[],'results':[],
        'Main_modified':False,'Editor_or_compiler_launched':False,'actual_URP_renderer_or_visual_fidelity_claimed':False}
    def launch(case,label):
        result=out/(label+'-result.json');log=out/(label+'-Player.log')
        command=[plan['player']['path'],'-batchmode','-force-d3d11','-screen-width','64','-screen-height','64','-logFile',str(log),
            '-shaderProbeMode','resources','-shaderProbeOutput',str(result),'-shaderProbeResource',case['resource_key'],
            '-shaderProbeExpectedName',case['name'],'-shaderProbeExpectedProperties',str(case['expected_property_count']),
            '-shaderProbeExpectedPasses',str(case['expected_pass_count']),'-shaderProbePipelineTag',case['pipeline_tag_argument'],'-shaderProbePixelCheck','none']
        error=None
        try:guard.bounded(command,root,out,label,plan['owned_job_cap_bytes'],plan['deadline_seconds_each'],report)
        except BaseException as exc:error=repr(exc)
        observation={'label':label,'guid':case.get('guid'),'process_error':error,'runtime':None,'full_log_failure_lines':[]}
        if result.is_file():observation.update(runtime=json.loads(result.read_bytes()),runtime_report=native.pin(result))
        if log.is_file():
            text=log.read_text(encoding='utf-8',errors='replace');observation['full_player_log']=native.pin(log)
            observation['full_log_failure_lines']=[line[:1024] for line in text.splitlines() if re.search(r'Partial constant buffer not found\.|error CS\d+|Shader error in|ERROR: Shader|Failed to find expected binary shader data|ShaderUnsupported|shader is not supported|is corrupted|Position out of bounds|Fatal error|StackOverflowException|Could not allocate memory|Out of memory',line,re.I)][:64]
        actual=observation['runtime']
        observation['passed']=bool(error is None and actual and actual['status']=='exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed'
            and actual['shader_name']==case['name'] and actual['property_count']==case['expected_property_count'] and actual['material_pass_count']==case['expected_pass_count']
            and actual['shader_supported'] and actual['set_pass_succeeded'] and actual['render_and_readback_completed']
            and actual['partial_constant_buffer_messages']==0 and not actual['shader_error_lines'] and not observation['full_log_failure_lines'])
        if case.get('expected_property_names') is not None:observation['passed'] &= actual is not None and actual['property_names']==case['expected_property_names']
        report['results'].append(observation);guard.save(out,report)
        return observation
    try:
        green={'resource_key':'ShaderProbeControl','name':'SolarNet/Diagnostic/Green','expected_property_count':0,'expected_pass_count':1,'pipeline_tag_argument':'unchanged'}
        control=launch(green,'green-control')
        native.need(control['passed'] and control['runtime']['center_pixel']=={'r':0,'g':255,'b':0,'a':255},'Clean patched-player green GPU control required before originals')
        for case in plan['cases']:
            observation=launch(case,'original-'+case['guid'])
            if not observation['passed']:report['any_original_probe_failed']=True
        for row in json.loads(Path(plan['clone_inventory']['path']).read_bytes()):guard.checked(row['clone']);guard.checked(row['original'])
        native.need(len(report['results'])==9 and all(row['passed'] for row in report['results']),'All eight strict original Shader cases must pass')
        report['status']='all8_restored_original_Shader_identities_source_counts_pass0_and_D3D11_readback_verified'
    except BaseException as exc:report.update(status='held_or_failed',error=repr(exc))
    finally:guard.save(out,report);print(json.dumps({'status':report['status'],'receipt':native.pin(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status'].startswith('all8_') else 1


def main():
    ap=argparse.ArgumentParser(description=__doc__);ap.add_argument('--plan',type=Path,required=True);ap.add_argument('--plan-sha256',required=True);ap.add_argument('--run',action='store_true');args=ap.parse_args()
    path=args.plan.resolve(strict=True);plan,root=verify(path,args.plan_sha256)
    if not args.run:print(json.dumps({'status':'verified_no_player_started','plan':native.pin(path)}));return 0
    return run(path,plan,root)


if __name__=='__main__':raise SystemExit(main())
