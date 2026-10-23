"""Prepare or ROOT-run only ProBuilder after independent builtin46 native proof."""
from pathlib import Path
import argparse
import copy
import datetime as dt
import json
import re
import sys
import uuid
import map_shader_buildreport as native
import orchestrate_eight_original_shader_restoration as context
import run_eight_original_shader_gpu_probes as earlier
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
GPU=context.AR/'EightOriginalShaderGPUFixture-20261023T071953Z-2d7c4232'
GPU_PLAN_SHA='1107364721e1ac35433c31c179febff25457196cd8185472cde2cc92ced986a1'
PRIOR=GPU/'Runtime-20261023T072107Z-28b4504c/run-report.json'
PRIOR_SHA='0d8fbbb9358d2adfaa307170240d6dc772de7168f0aec28548349b130675db43'
NATIVE=context.AR/'BuiltStandardNativePassProof-20261023T072631Z-a314e61c'
NATIVE_RUN_SHA='254ee232fcd46ad24887504af41debf6870bfa9e759afe086f83862c594693a8'
NATIVE_FACTS_SHA='26001bc3d0a61403c71fa6ef16f5df714e538f32cb7ab99c848eba98158ddaee'
GUID='dbe0ca40b3618e44e9ef2664c6daae98'


def save(path,obj):
    with Path(path).open('x',encoding='utf-8') as stream:json.dump(obj,stream,indent=2);stream.write('\n')


def authority():
    old,root=earlier.verify(GPU/'gpu-probe-plan.json',GPU_PLAN_SHA)
    native.need(guard.sha(PRIOR)==PRIOR_SHA and guard.sha(NATIVE/'run-report.json')==NATIVE_RUN_SHA
        and guard.sha(NATIVE/'native-vs-Editor-pass-layout.json')==NATIVE_FACTS_SHA,'Exact prior GPU and independent native data receipts')
    prior=json.loads(PRIOR.read_bytes());native_run=json.loads((NATIVE/'run-report.json').read_bytes())
    facts=json.loads((NATIVE/'native-vs-Editor-pass-layout.json').read_bytes())
    native.need(prior['plan']==native.pin(GPU/'gpu-probe-plan.json') and len(prior['results'])==9,'Exact same-clone green+8 previous cases')
    green=[r for r in prior['results'] if r['label']=='green-control']
    native.need(len(green)==1 and green[0]['passed'] and green[0]['runtime']['center_pixel']=={'r':0,'g':255,'b':0,'a':255},'Prior clean same-player green GPU control')
    seven=[r for r in prior['results'] if r['guid'] is not None and r['guid']!=GUID]
    native.need(len(seven)==7 and all(r['passed'] and not r['full_log_failure_lines'] for r in seven)
        and {r['guid'] for r in seven}==set(context.projection.GUIDS)-{GUID},'Exactly seven other original Shader cases already passed')
    for row in prior['results']:
        for key in ('runtime_report','full_player_log'):guard.checked(row[key])
    native.need(native_run['status']=='actual_native_builtin46_entire_Class48_and_pass_layout_proven'
        and native_run['result']==native.pin(NATIVE/'native-vs-Editor-pass-layout.json')
        and native_run['phases'][-1]['exit_code']==0 and native_run['phases'][-1]['launcher']['membership_verified_before_resume'],
        'Actual independently completed full built Standard ReadRelease')
    native.need(facts['entire_native_bytes_consumed'] and facts['GPU_observation_used_to_set_expected_count'] is False
        and [s['pass_count'] for s in facts['native_ParsedForm_facts']['subshaders']]==[4,3]
        and [s['pass_count'] for s in facts['genuine_Editor_ParsedForm_facts']['subshaders']]==[5,4],
        'Independent actual native4/3 versus Editor5/4 subshader counts')
    for key in ('native_model_report','actual_native_Material_identity_chain'):guard.checked(facts[key])
    guard.checked(facts['native_ParsedForm_facts']['source_ParsedForm']);guard.checked(facts['genuine_Editor_ParsedForm_facts']['source_ParsedForm'])
    original=next(r for r in old['cases'] if r['guid']==GUID)
    native.need(original['expected_property_count']==4 and original['pipeline_tag_argument']=='unchanged'
        and original['pass_count_source']['original_own_pass_count']==0
        and original['pass_count_source']['canonical_fallback_edge']['local_file_id']==46,'Original zero-own-pass ProBuilder with explicit builtin46 fallback')
    case=copy.deepcopy(original);case['expected_pass_count']=facts['first_native_subshader_pass_count']
    case['effective_pass_count_authority']={'kind':'independent_whole_native_builtin46_ReadRelease_and_actual_Material_identity_chain',
        'native_pass_layout':native.pin(NATIVE/'native-vs-Editor-pass-layout.json'),'native_model_report':facts['native_model_report'],
        'native_first_subshader_count':facts['first_native_subshader_pass_count'],'count_derived_from_failed_GPU_observation':False,
        'removed_named_pass_identified':False}
    return old,prior,seven,case


def prepare(out):
    old,prior,seven,case=authority()
    plan={'schema':'independent-native-builtin46-ProBuilder-only-GPU-plan/v1','status':'prepared_no_player_started',
        'fixture':str(out),'player':old['player'],'player_root':old['player_root'],'clone_inventory':old['clone_inventory'],
        'prior_eight_case_plan':native.pin(GPU/'gpu-probe-plan.json'),'prior_green_and_seven_originals':native.pin(PRIOR),
        'independent_native_read':native.pin(NATIVE/'run-report.json'),'independent_native_pass_layout':native.pin(NATIVE/'native-vs-Editor-pass-layout.json'),
        'case':case,'runner':native.pin(Path(__file__)),'guard':native.pin(Path(guard.__file__)),
        'launcher':native.pin(HERE/'owned_suspended_launch.py'),'owned_job_cap_bytes':1536*1024**2,'reserve_bytes':int(1.5*1024**3),'deadline_seconds':60,
        'other_seven_and_green_will_not_be_repeated':True,'all_original_fixture_and_source_files_preserved':True,
        'Root_only_command':[sys.executable,'-B',str(Path(__file__)),'--plan',str(out/'plan.json'),'--plan-sha256','<PIN_PLAN>','--run'],
        'no_named_removed_pass_claimed':True,'Main_modified':False,'player_Unity_compiler_network_launched':False}
    save(out/'plan.json',plan)
    print(json.dumps({'plan':native.pin(out/'plan.json'),'expected_pass_count':case['expected_pass_count'],'expected_properties':case['expected_property_count'],'Root_only_command':plan['Root_only_command']}))


def execute(path,wanted):
    native.need(guard.sha(path)==wanted,'Reviewed exact ProBuilder native-fallback GPU plan')
    plan=json.loads(path.read_bytes());out=path.parent.resolve(strict=True)
    native.need(plan['schema']=='independent-native-builtin46-ProBuilder-only-GPU-plan/v1' and out.is_relative_to(context.AR)
        and out.name.startswith('ProBuilderNativeFallbackGPU-'),'Fresh isolated ProBuilder-only GPU workspace')
    for key in ('player','clone_inventory','prior_eight_case_plan','prior_green_and_seven_originals','independent_native_read','independent_native_pass_layout','runner','guard','launcher'):guard.checked(plan[key])
    old,prior,seven,case=authority();native.need(case==plan['case'],'Exact original-case contract plus independently native-derived pass count')
    native.need(plan['owned_job_cap_bytes']==1536*1024**2 and plan['reserve_bytes']==int(1.5*1024**3) and plan['deadline_seconds']==60,'Fixed existing runtime guard')
    runtime=out/('Runtime-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);runtime.mkdir()
    result=runtime/'ProBuilder-result.json';log=runtime/'ProBuilder-Player.log'
    report={'schema':'ROOT-ProBuilder-original-builtin46-native-derived-GPU-proof/v1','status':'starting','phases':[],'plan':native.pin(path),
        'prior_seven_originals_and_green':native.pin(PRIOR),'independent_native_builtin46_pass_layout':plan['independent_native_pass_layout'],
        'Main_modified':False,'Unity_Editor_compiler_network_launched':False,'actual_URP_renderer_or_visual_fidelity_claimed':False}
    try:
        command=[plan['player']['path'],'-batchmode','-force-d3d11','-screen-width','64','-screen-height','64','-logFile',str(log),
            '-shaderProbeMode','resources','-shaderProbeOutput',str(result),'-shaderProbeResource',case['resource_key'],
            '-shaderProbeExpectedName',case['name'],'-shaderProbeExpectedProperties',str(case['expected_property_count']),
            '-shaderProbeExpectedPasses',str(case['expected_pass_count']),'-shaderProbePipelineTag','unchanged','-shaderProbePixelCheck','none']
        guard.bounded(command,out,runtime,'ProBuilder-only-native46-fallback-GPU',plan['owned_job_cap_bytes'],60,report)
        actual=json.loads(result.read_bytes());text=log.read_text(encoding='utf-8',errors='replace')
        errors=[line[:1024] for line in text.splitlines() if re.search(r'Partial constant buffer not found\.|error CS\d+|Shader error in|ERROR: Shader|Failed to find expected binary shader data|ShaderUnsupported|shader is not supported|is corrupted|Position out of bounds|Fatal error|StackOverflowException|Could not allocate memory|Out of memory',line,re.I)]
        report.update(runtime_result=actual,runtime_report=native.pin(result),full_player_log=native.pin(log),full_log_failure_lines=errors[:64])
        native.need(actual['status']=='exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed'
            and actual['shader_name']==case['name'] and actual['property_count']==4 and actual['property_names']==case['expected_property_names']
            and actual['material_pass_count']==case['expected_pass_count'] and actual['shader_supported'] and actual['set_pass_succeeded']
            and actual['render_and_readback_completed'] and actual['partial_constant_buffer_messages']==0 and not actual['shader_error_lines'] and not errors,
            'Source/native-derived ProBuilder support/properties/pass0/readback/full-log gates')
        for row in json.loads(Path(plan['clone_inventory']['path']).read_bytes()):guard.checked(row['clone']);guard.checked(row['original'])
        aggregate=[{'guid':r['guid'],'runtime':r['runtime'],'runtime_report':r['runtime_report'],'full_player_log':r['full_player_log']} for r in seven]
        aggregate.append({'guid':GUID,'runtime':actual,'runtime_report':native.pin(result),'full_player_log':native.pin(log)})
        native.need({r['guid'] for r in aggregate}==set(context.projection.GUIDS) and len(aggregate)==8,'All eight original identities accounted for')
        aggregate_report={'schema':'eight-original-native-payload-GPU-aggregate/v1','status':'all8_original_Shader_identities_original_or_proven_fallback_counts_pass0_and_D3D11_readback_verified',
            'results':aggregate,'earlier_green_and_seven_receipt':native.pin(PRIOR),'ProBuilder_fresh_plan':native.pin(path),
            'ProBuilder_native46_count_authority':plan['independent_native_pass_layout'],
            'earlier_failed_five_pass_expectation_preserved':True,'no_removed_pass_name_asserted':True,
            'terrain_Lit_readback_is_original_FallbackError_not_terrain_render_fidelity':True,
            'actual_URP_renderer_gameplay_or_visual_fidelity_claimed':False,'Main_modified':False}
        save(runtime/'all-eight-aggregate.json',aggregate_report)
        report.update(status='ProBuilder_original_builtin46_fallback_GPU_verified_all8_aggregate_complete',aggregate=native.pin(runtime/'all-eight-aggregate.json'))
    except BaseException as exc:
        report.update(status='held_or_failed',error=repr(exc))
        if result.is_file():report['runtime_result']=json.loads(result.read_bytes())
        if log.is_file():report['full_player_log']=native.pin(log)
    guard.save(runtime,report);print(json.dumps({'status':report['status'],'receipt':native.pin(runtime/'run-report.json'),'aggregate':report.get('aggregate'),'error':report.get('error')}))
    return 0 if report['status'].startswith('ProBuilder_original_') else 1


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);ap.add_argument('--plan',type=Path);ap.add_argument('--plan-sha256');ap.add_argument('--run',action='store_true');args=ap.parse_args()
    if args._worker:return prepare(args._worker.resolve(strict=True))
    if args.run:
        native.need(args.plan and args.plan_sha256,'Root reviewed explicit plan required');return execute(args.plan.resolve(strict=True),args.plan_sha256)
    native.need(not args.plan,'Prepare first; no implicit player launch')
    out=context.AR/('ProBuilderNativeFallbackGPU-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-pure-ProBuilder-native46-expectation-preparation/v1','status':'starting','phases':[]}
    try:
        guard.bounded([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],guard.WS,out,'pure-native46-source-derived-ProBuilder-only-GPU-plan',256*1024**2,30,report);report['status']='passed'
    except BaseException as exc:report.update(status='held',error=repr(exc))
    save(out/'prepare-run-report.json',report);print(json.dumps({'status':report['status'],'receipt':native.pin(out/'prepare-run-report.json'),'error':report.get('error')}))
    return 0 if report['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
