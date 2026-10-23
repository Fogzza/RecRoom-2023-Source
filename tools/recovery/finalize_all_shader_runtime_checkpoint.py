"""Pure bounded179 diagnostic checkpoint/approved tested source inventory.

Reads actual Root receipts; never launches compiler, Unity, player or network.
No Main or publisher file is written. Earlier failed attempts remain unchanged.
"""
from pathlib import Path
import argparse,datetime as dt,json,re,struct,sys,uuid
import run_all_shader_runtime_probes as runtime
import shader_program_data as programs
import run_windows_development_define_probe as guard

proof=runtime.proof;HERE=Path(__file__).resolve().parent;AR=proof.AR
FIXTURE=AR/'All179OriginalShaderRuntimeFixture-20261023T082543Z-f149e9b3'
PLAN_SHA='33631aea0fd67dee94072b78b406a79b2c872ca6e4459f0b344996018a6c4b99'
COMPILE=FIXTURE/'CompileRuntime-20261023T082803Z-b4f8cbef/run-report.json'
COMPILE_SHA='5f43a02afa87f671b7cf8e4c594207d489adade0169ec7b2be1be630da6b34aa'
LOADS=FIXTURE/'StructuralLoads-20261023T082833Z-37e583be/run-report.json'
LOADS_SHA='3366aae20264ef4a55e8d478107ba9442019deb4a5081c1608f4e900cbc8ebdb'
GPU=FIXTURE/'GPU8-20261023T082955Z-7965ca5c/run-report.json'
GPU_SHA='91929eb4bc460c8b3a984359f6fbf8e5222bb794e61d72150aac06b30004275a'
UNSUPPORTED='4a2db69e9a45b1843b366b21b2944bb4'
need=proof.need;pin=proof.pin;save=proof.save


def phase_success(report):
    for row in report['phases']:
        need(row['exit_code']==0 and row['owned_cli_or_compiler_exit_confirmed'] and row['launcher']['membership_verified_before_resume']
            and row['reserve_bytes']==guard.RESERVE,'Every actual process success/membership/reserve required')


def inspect_receipt(path,digest,status,mode=None):
    need(guard.sha(path)==digest,'Exact actual Root receipt');report=json.loads(path.read_bytes());need(report['status']==status,'Actual completed passing receipt status')
    phase_success(report)
    if mode:need(report['mode']==mode,'Exact runtime mode')
    for result in report.get('results',[]):
        need(result['passed'] and result['process_error'] is None and result['actual_D3D11_initialized'] and not result['full_log_failure_lines'],'Every actual runtime case passed')
        for key in ('runtime_report','full_player_log'):guard.checked(result[key])
        actual=json.loads(Path(result['runtime_report']['path']).read_bytes());need(actual==result['runtime'],'Actual persisted runtime report equals observation')
        errors,d3d=runtime.failures(Path(result['full_player_log']['path']));need(not errors and d3d,'Independent complete actual Player log rescan')
        need(actual['partial_constant_buffer_messages']==0 and not actual['shader_error_lines'],'Actual post-hook native/Shader/CB events clear')
    return report


def prepare(out):
    plan,root=runtime.verify(FIXTURE/'plan.json',PLAN_SHA);ready,inventory=runtime.ready_inputs(FIXTURE/'plan.json',plan,root)
    need(guard.sha(FIXTURE/'runtime-ready.json')=='17a58d533ec3f2dd0babce5ddaedc9229973207d7a3bd846de6edb7ba672f5fc','Exact actual diagnostic compilation/install readiness')
    compile_report=inspect_receipt(COMPILE,COMPILE_SHA,'matching_diagnostic_only_assembly_and_PDB_compiled_and_installed_fresh_clone')
    loads=inspect_receipt(LOADS,LOADS_SHA,'all179_original_Shader_names_and_ordered_properties_loaded_zero_native_Shader_CB_errors','loads')
    gpu=inspect_receipt(GPU,GPU_SHA,'same179patched_player_green_and8_original_Shader_GPU_cases_passed','gpu')
    need(len(loads['results'])==len(loads['phases'])==6 and len(gpu['results'])==len(gpu['phases'])==9,'Six load batches and green+8 draw processes')
    observed=[row for result in loads['results'] for row in result['runtime']['shaders']]
    need(len(observed)==179 and tuple(r['guid'] for r in observed)==proof.context.canonical_guids()
        and sum(bool(r['supported']) for r in observed)==178 and [r['guid'] for r in observed if not r['supported']]==[UNSUPPORTED],
        'Exactly179 unique structural loads,178 supported and one explicit unsupported particle asset')
    for case,raw in zip(plan['load_batches'],loads['results']):
        expected=json.loads(Path(case['path']).read_bytes())['shaders'];actual=raw['runtime']['shaders'];need(len(expected)==len(actual),'Exact batch length')
        for a,b in zip(expected,actual):need(b['guid']==a['guid'] and b['name']==a['name'] and b['resource_key']==a['resource_key']
            and b['property_count']==a['expected_property_count'] and b['property_names']==a['expected_property_names'] and b['loaded_exact_original_identity'],
            'Every actual179 name/ordered property list matches original source')
    cases=json.loads(Path(plan['GPU_cases']['path']).read_bytes());need(gpu['results'][0]['runtime']['center_pixel']=={'r':0,'g':255,'b':0,'a':255},'Actual green readback control')
    for expected,actual in zip(cases,gpu['results'][1:]):
        row=actual['runtime'];need(actual['label']=='original-'+expected['guid'] and row['shader_name']==expected['name'] and row['property_count']==expected['expected_property_count']
            and row['property_names']==expected['expected_property_names'] and row['material_pass_count']==expected['expected_pass_count']
            and row['shader_supported'] and row['set_pass_succeeded'] and row['render_and_readback_completed'],'Every8 actual original/native-derived GPU gate passed')
    # Explain the sole unsupported observation using ORIGINAL cooked data only.
    canonical=json.loads(Path(plan['native_patch_plan']['path']).read_bytes());authority=json.loads(Path(canonical['canonical_manifest']['path']).read_bytes())
    source=next(r for r in authority['shaders'] if r['guid']==UNSUPPORTED);fact=next(r for r in json.loads(Path(plan['source_facts']['path']).read_bytes()) if r['guid']==UNSUPPORTED)
    conversion=json.loads(proof.context.CONVERSION.read_bytes());converted=next(r for r in conversion['results'] if r['guid']==UNSUPPORTED)
    for key in ('report','ParsedForm','original_compiled_blob'):guard.checked(converted[key])
    typed=json.loads(Path(converted['report']['path']).read_bytes());blob=Path(converted['original_compiled_blob']['path']).read_bytes();decoded=programs.lz4(blob,4)
    need(fact['name']=='Universal Render Pipeline/Particles/Unlit' and fact['property_count']==33 and len(fact['subshaders'])==1
        and fact['subshaders'][0]['pipeline_tag']=='UniversalPipeline' and fact['subshaders'][0]['pass_count']==0 and fact['fallback_name'] is None
        and source['dependencies']==[] and typed['all_five_original_program_fields_equal'] and typed['entire_ParsedForm_equal']
        and typed['original_program_fields']['Platforms']==[4] and blob==bytes.fromhex('4000000000') and decoded==bytes(4) and programs.dxbc(decoded)==[],
        'Original particle cooked object genuinely has0 passes/no fallback/dependencies and no DXBC in its4B D3D11 segment')
    unsupported={'schema':'original-cooked-particle-unsupported-observation-source-explanation/v1','status':'consistent_with_original_zero_pass_no_fallback_cooked_source',
        'guid':UNSUPPORTED,'name':fact['name'],'actual_runtime':next(r for r in observed if r['guid']==UNSUPPORTED),'original_source':source['source'],
        'original_source_identity':source['original_source_identity'],'original_ParsedForm':fact['source_ParsedForm'],'full_generated_original_read_proof':converted['report'],
        'property_count':33,'original_pass_count':0,'original_fallback':None,'original_dependencies':[], 'original_platforms':[4],
        'compressed_blob':converted['original_compiled_blob'],'compressed_bytes_hex':blob.hex(),'decompressed_segment_bytes':4,'decompressed_segment_hex':decoded.hex(),
        'decompressed_u32':struct.unpack('<I',decoded)[0],'DXBC_chunks':0,
        'conclusion':'The actual unsupported status follows the retained original empty cooked pass/program content; it is not evidence of a platform mismatch or permission to substitute another shader.',
        'original2023_runtime_usage_or_missing_source_variants_proven':False,'fallback_or_source_changed':False}
    save(out/'unsupported-original-particle-analysis.json',unsupported)
    approved=[('prepare_all_shader_null_dependency_expansion.py','Pure179 authority projection and104 typed-word controls; actual8 gate and Root179 conversion input.'),
        ('BuildAllOriginalShaderNullDependencyFixture.cs','Actual matching179/fourMaterial build succeeded, all original inputs/metas retained.'),
        ('run_all_original_shader_null_dependency_fixture.py','Actual6GiB owned matching compile/build and final telemetry passed.'),
        ('test_all_null_dependency_fixture_preparation.py','179 positive authority admission,24 negative controls,4 owned-close controls passed.'),
        ('run_all_null_dependency_fixture_offline_controls.py','Actual bounded pure fixture controls passed.'),
        ('orchestrate_all_original_shader_restoration.py','Actual179/fourMaterial native mapping and Root whole Class21 probes passed; insufficient-gap finalize correctly held.'),
        ('test_all_shader_restoration_orchestration.py','Actual known-native namespace/old8 authority refusal controls passed.'),
        ('run_all_shader_restoration_offline_controls.py','Actual bounded pure12 namespace controls passed.'),
        ('patch_original_shader_collection_with_external_relocation.py','Actual179 full original payloads/104 pointer restoration,48B explicit data shift and nontarget identity/data proofs passed.'),
        ('run_original_shader_relocated_patch_v3.py','Actual bounded patch succeeded with separate diagnostics and empty output guard retained.'),
        ('prepare_all_shader_runtime_fixture.py','Actual pure179 source facts/native integrity/full fresh player clone/compile plan passed.'),
        ('OriginalShaderRuntimeProbeWithLoadBatches.cs','Actual matching Csc, green control and8 original GPU draws passed; default GPU source only adds dispatch.'),
        ('OriginalShaderLoadBatchProbe.cs','Actual six batches loaded179 original names and property lists;178 support true and one original empty particle observed false.'),
        ('run_all_shader_runtime_probes.py','Actual diagnostic-only DLL/PDB compilation/install, six structural batches and green+8 draws passed.'),
        ('finalize_all_shader_runtime_checkpoint.py','This actual bounded pure receipt/hash/log/native/identity aggregation run; valid only with its passed owned receipt.')]
    tools=[{'source':pin(HERE/name),'tested_role':role} for name,role in approved]
    exclusions=[{'path':str(HERE/name),'reason':reason} for name,reason in [
        ('run_original_shader_relocated_patch.py','Superseded; logs would pollute required-empty native output.'),
        ('run_original_shader_relocated_patch_v2.py','Actual guard refused output polluted by runner logs; failure preserved.'),
        ('prepare_all_shader_relocated_restoration.py','Pure full-data controls/preflight passed, but returned launcher command was superseded by pinned-launch-handoff-v3; not a finalized launch entry point.')]]
    save(out/'finalized-tested-new-shader-tools.json',{'schema':'finalized-tested-new-Shader-tool-publication-candidates/v1','status':'reviewable_source_list_only_no_publisher_write',
        'tools':tools,'excluded_superseded_entries':exclusions,'publication_repos_or_source_manifest_modified':False,
        'private_native_inputs_players_and_raw_logs_are_not_in_this_source_file_list':True})
    terrain=next(r['runtime'] for r in gpu['results'][1:] if r['runtime']['shader_name']=='Universal Render Pipeline/Terrain/Lit')
    need(terrain['material_pass_count']==1 and terrain['center_pixel']=={'r':255,'g':0,'b':255,'a':255},'Terrain original fallback observation retained')
    aggregate={'schema':'actual179-original-cooked-Shader-native-restoration-runtime-checkpoint/v1',
        'status':'179_original_native_payloads_restored_all179_structurally_loaded_178_supported_green_plus8_GPU_passed_with_explicit_limits',
        'native_patch_plan':plan['native_patch_plan'],'actual_native_patch_report':plan['actual_native_patch_report'],'actual_owned_patch_receipt':plan['native_owned_patch_receipt'],
        'runtime_plan':pin(FIXTURE/'plan.json'),'actual_diagnostic_compile':pin(COMPILE),'runtime_ready':pin(FIXTURE/'runtime-ready.json'),
        'actual_all179_structural_receipt':pin(LOADS),'actual_green_and8_GPU_receipt':pin(GPU),'original_179_Release_payloads':179,'typed_original_dependencies_restored':104,
        'original_project_dependency_edges':77,'original_builtin_dependency_edges':27,'all_original_data_bytes_retained_at_explicit48B_shift':15742148,
        'all179_exact_names_and_ordered_properties_loaded':True,'structural_support_true':178,'structural_support_false':1,
        'unsupported_original_particle_analysis':pin(out/'unsupported-original-particle-analysis.json'),'green_control_passed':True,'original_GPU_draw_cases_passed':8,
        'GPU_cases':[{'name':r['runtime']['shader_name'],'properties':r['runtime']['property_count'],'passes':r['runtime']['material_pass_count'],'center_pixel':r['runtime']['center_pixel']} for r in gpu['results']],
        'all_structural_and_GPU_full_Player_logs_native_Shader_CB_errors':0,'full_shader_Main_apply_performed':False,
        'limitations':['The sole unsupported particle Shader is faithfully retained original cooked data:33 properties,0passes,no fallback,no dependency and a4zero-byte D3D11 segment/no DXBC.',
            'Terrain/Lit draws its original FallbackError magenta; this is not successful terrain rendering.',
            'Only eight originals were drawn; all179 structural loads and178 support flags do not prove all179 render correctly.',
            'The genuine URP global tag selects original subshaders; no full original URP renderer, scene visuals, startup/login, gameplay or usable recovered-game executable is claimed.',
            'Diagnostic clone only. Main shaders and publisher/source repositories were not changed by these tools.'],
        'earlier_failed_receipts_and_sources_preserved':True,'finalized_tested_new_source_tools':pin(out/'finalized-tested-new-shader-tools.json'),
        'Main_modified':False,'compiler_Unity_managed_reader_player_network_launched':False,'publisher_modified':False,'tool':pin(Path(__file__))}
    save(out/'aggregate.json',aggregate)
    print(json.dumps({'status':aggregate['status'],'aggregate':pin(out/'aggregate.json'),'publication_source_list':aggregate['finalized_tested_new_source_tools'],
        'unsupported_analysis':aggregate['unsupported_original_particle_analysis'],'approved_new_source_files':len(tools)}))


def main():
    ap=argparse.ArgumentParser(description=__doc__);ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);args=ap.parse_args()
    if args._worker:return prepare(args._worker.resolve(strict=True))
    out=AR/('All179ShaderRuntimeCheckpoint-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    receipt={'schema':'guarded-pure179-final-runtime-checkpoint/v1','status':'starting','phases':[],'Main_modified':False,'compiler_Unity_managed_reader_player_network_launched':False}
    try:guard.bounded([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],guard.WS,out,'pure179-actual-runtime-aggregate-and-final-tested-source-list',256*1024**2,180,receipt);receipt['status']='passed'
    except BaseException as error:receipt.update(status='held',error=repr(error))
    guard.save(out,receipt);print(json.dumps({'status':receipt['status'],'receipt':pin(out/'run-report.json'),'error':receipt.get('error')}));return 0 if receipt['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
