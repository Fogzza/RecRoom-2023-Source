"""Fresh8 native mapping -> ROOT-only Class21 probes -> reviewed patch plan.

--prepare and --finalize are bounded Python-only data stages. Only Root may use
--run-material-probes; that switch runs the already compiled genuine reader.
No mode compiles, launches Unity/player, writes Main, or accesses the network.
"""
from pathlib import Path
import argparse
import datetime as dt
import json
import os
import sys
import uuid
import map_shader_buildreport as native
import map_builtin_material_shader_targets as builtin
import patch_original_shader_collection_with_builtins as patcher
import prepare_original_shader_null_dependency_projection as projection
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
AR=projection.AR
FIXTURE=AR/'OriginalShaderNullDependencyFixture-20261023T065310Z-47a193e1'
FIXTURE_SHA='5ee4854fbb8780ef4f04bd1e9e97cfd415beb13670894e3b1d54e5ef2d32b801'
BUILD_RUN=FIXTURE/'Run-20261023T065347Z-d8ac1778'
BUILD_RUN_SHA='79339267677288296effdd4ed91da35eee59f00286e2df1c00a8c8876d8d61e2'
CONVERSION=projection.CONVERTER/'Run-20261023T065122Z-687764f8/run-report.json'
CONVERSION_SHA='2268f96ceb2d52ec803009f947b1f5ad50ab3a7e630c734b4fcc44f6ff69395f'
MATERIAL_PROBE=AR/'OriginalMaterialShaderPointerProbe-20261023T050904Z-466e0b7f'
MATERIAL_PLAN_SHA='9b52baedd0b1224ab1851a6382b1d23500010b4b6523c83371ff9a6d2390deaa'
MATERIAL_COMPILE_SHA='f9fe0a4933bb69af60010ddf8fbd123da5f46284175c16090436c252ca7a2fea'
TOOLS={
    'map_shader_buildreport.py':'249e3638197496a405291e3d9dd40c010d2bdcec9757194307cdd5a53ee905b7',
    'map_builtin_material_shader_targets.py':'92241ff0bc026bc6ec87f2b391f38a74b3b8cbedca51ecee33b92e7b425e7810',
    'patch_original_shader_collection_with_builtins.py':'fbba70a207bf76f82f1257ef238e1b7c1858ae115b58f8fd1e8e47afd18b295f',
    'run_windows_development_define_probe.py':'685f87ada7d4c10a09421e11b59466b3e19e817bfdaabd5a233c0192f17529fc',
    'owned_suspended_launch.py':'3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'}


def need(v,message):
    if not v:raise ValueError(message)


def save(path,value):
    with Path(path).open('x',encoding='utf-8') as stream:json.dump(value,stream,indent=2);stream.write('\n')


def check(row):
    path=Path(row['path']).resolve(strict=True)
    need(path.is_relative_to(AR) and native.pin(path)==row,'Exact pinned isolated input required')
    return path


def checked_tools():
    pins=[]
    for name,wanted in TOOLS.items():
        row=native.pin(HERE/name);need(row['sha256']==wanted,'Reviewed mapper/patcher/guard source changed: '+name);pins.append(row)
    return pins


def probe_inputs():
    need(guard.sha(MATERIAL_PROBE/'plan.json')==MATERIAL_PLAN_SHA and guard.sha(MATERIAL_PROBE/'compile-report.json')==MATERIAL_COMPILE_SHA,'Genuine already compiled Class21 reader proof')
    plan=json.loads((MATERIAL_PROBE/'plan.json').read_bytes());compiled=json.loads((MATERIAL_PROBE/'compile-report.json').read_bytes())
    need(compiled['status']=='compiled_full_generated_Class21_reader' and compiled['phases'][-1]['exit_code']==0,'Actual successful reader compilation')
    for row in [plan[k] for k in ('source','source_original','response','dotnet','compiler','runner','guard','launcher','genuine_factory_API_source')]+plan['runtime']+plan['references']+[compiled['assembly']]:guard.checked(row)
    return plan,compiled


def validate_build():
    need(guard.sha(FIXTURE/'plan.json')==FIXTURE_SHA and guard.sha(BUILD_RUN/'run-report.json')==BUILD_RUN_SHA,'Exact reviewed successful fresh8 build')
    plan=json.loads((FIXTURE/'plan.json').read_bytes());run=json.loads((BUILD_RUN/'run-report.json').read_bytes())
    need(run['status']=='projected_original_Shader_Windows_build_verified_UNPATCHED_NOT_FOR_RUNTIME'
        and run['plan']==native.pin(FIXTURE/'plan.json') and run['partial_constant_buffer_full_log_count']==0
        and run['full_log_failure_lines']==[] and len(run['phases'])>=2,'Actual clean matching CLI/build receipt')
    for phase in run['phases']:
        need(phase['exit_code']==0 and phase['owned_cli_or_compiler_exit_confirmed'] and phase['launcher']['membership_verified_before_resume'],'Every actual owned build process completed')
    source=check(run['build']['report']);build=json.loads(source.read_bytes())
    need(build==run['build']['result'] and build['status']=='Succeeded' and build['shader_count']==8
        and build['total_errors']==build['partial_constant_buffer_messages']==0 and build['serialization_mode']=='Mixed'
        and build['target']=='StandaloneWindows64' and build['backend']=='Mono2x' and build['unity_version']=='2020.3.33f1'
        and build['four_builtin_material_witnesses_verified'] and build['input_assets_and_metas_unchanged']
        and build['Editor_only_null_dependency_projection'] and not build['original_dependencies_restored_in_player'],'Actual eight-projection/four-Material successful native build required')
    config=json.loads(Path(plan['config']['path']).read_bytes());guard.checked(plan['config'])
    need(tuple(r['guid'] for r in config['shaders'])==projection.GUIDS and config['copied_materials']==build['builtin_shader_material_witnesses'],'Same actual8Shader/4Material build identity set')
    player=(BUILD_RUN/'Player').resolve(strict=True);project=Path(plan['project']).resolve(strict=True)
    need(Path(build['output_path']).resolve(strict=True).parent==player,'Exact actual player output root')
    guard.checked(run['diagnostic_player'])
    return plan,run,build,config,source,player,project


def prepare(out):
    tool_pins=checked_tools();fixture,run,build,config,build_path,player,project=validate_build()
    probe,compiled=probe_inputs()
    mapping_dir=out/'NativeMapping';mapping_dir.mkdir()
    expected=[{'guid':r['guid'],'source_path':r['path'],'count':1} for r in config['shaders']]
    save(mapping_dir/'expected-eight-Shader-GUIDs.json',expected)
    mapped=native.corroborate(native.extract_capture(build),expected,player)
    mapped.update(actual_input_report=native.pin(build_path),expected_input=native.pin(mapping_dir/'expected-eight-Shader-GUIDs.json'),tool=native.pin(Path(native.__file__)))
    map_path=mapping_dir/'Shader-GUID-native-map.json';save(map_path,mapped)
    material_map=builtin.extract(build,project,player,mapping_dir)
    material_map.update(tool=native.pin(Path(builtin.__file__)),actual_input_report=native.pin(build_path))
    material_path=mapping_dir/'material-native-map-report.json';save(material_path,material_map)
    need(guard.sha(projection.AUTHORITY)==projection.AUTHORITY_SHA and guard.sha(CONVERSION)==CONVERSION_SHA,'Exact original canonical source and fresh generated preservation authority')
    authority=json.loads(projection.AUTHORITY.read_bytes());by_guid={r['guid']:r for r in authority['shaders']}
    canonical={'schema':authority['schema'],'status':'exact_original_eight_Release_authority_for_postbuild_restoration',
        'proofs':authority['proofs']+[native.pin(projection.AUTHORITY),native.pin(build_path),native.pin(CONVERSION)],
        'shaders':[by_guid[g] for g in projection.GUIDS]}
    canonical_path=out/'canonical-original-eight.json';save(canonical_path,canonical)
    conversion=json.loads(CONVERSION.read_bytes());need(conversion['status']=='all_manifest_original_Shader_Editor_conversions_verified' and len(conversion['results'])==8,'Fresh eight complete generated conversions')
    results={r['guid']:r for r in conversion['results']};need(set(results)==set(projection.GUIDS),'Exact typed source identity set')
    typed=[]
    for row in canonical['shaders']:
        pin=results[row['guid']]['report'];proof=json.loads(check(pin).read_bytes());patcher.payload(row,proof)
        typed.append({'guid':row['guid'],'typed_source_proof':pin})
    raw_materials=material_map['materials'];need(len(raw_materials)==4,'Exact four typed Material inputs')
    jobs=[]
    for row in raw_materials:
        jobs.append({'builtin_local_id':row['builtin_local_id'],'raw':row['raw'],'native_path_id':row['native_material_path_id'],
            'already_compiled_reader_command_shape':[probe['dotnet']['path'],compiled['assembly']['path'],row['raw']['path'],row['raw']['sha256'],row['native_material_path_id'],'<FRESH_TYPED_OUTPUT_JSON>']})
    plan={'schema':'same-build-eight-original-Shader-restoration-orchestration/v1','status':'actual8Shader_4Material_native_ranges_mapped_await_ROOT_typed_Class21_reads',
        'fixture':str(out),'build_run':native.pin(BUILD_RUN/'run-report.json'),'build_report':native.pin(build_path),
        'fixture_plan':native.pin(FIXTURE/'plan.json'),'player_root':str(player),'project':str(project),
        'Shader_mapping':native.pin(map_path),'Material_mapping':native.pin(material_path),'canonical_manifest':native.pin(canonical_path),
        'original_typed_source_proofs':typed,'fresh_conversion_run':native.pin(CONVERSION),
        'compiled_Material_reader_plan':native.pin(MATERIAL_PROBE/'plan.json'),'compiled_Material_reader_proof':native.pin(MATERIAL_PROBE/'compile-report.json'),
        'compiled_Material_reader_assembly':compiled['assembly'],'material_jobs':jobs,'tool_pins':tool_pins+[native.pin(Path(__file__))],
        'Root_only_next_command':[sys.executable,'-B',str(Path(__file__)),'--run-material-probes','--plan',str(out/'restoration-plan.json'),'--plan-sha256','<PIN_RESTORATION_PLAN>'],
        'Main_modified':False,'compiler_Unity_player_network_launched':False,'original_programs_or_dependencies_restored_yet':False}
    save(out/'restoration-plan.json',plan)
    print(json.dumps({'status':plan['status'],'plan':native.pin(out/'restoration-plan.json'),'Shader_ranges':len(mapped['mappings']),
        'Material_ranges':len(raw_materials),'containers':sorted({r['container']['path'] for r in mapped['mappings']}),'Root_only_next_command':plan['Root_only_next_command']}))


def load_plan(path,wanted):
    need(guard.sha(path)==wanted,'Reviewed exact orchestration plan hash')
    plan=json.loads(path.read_bytes());out=path.parent.resolve(strict=True)
    need(plan['schema']=='same-build-eight-original-Shader-restoration-orchestration/v1' and out.is_relative_to(AR)
        and out.name.startswith('EightOriginalShaderRestoration-') and plan['fixture']==str(out),'Exact fresh isolated orchestration workspace')
    for row in plan['tool_pins']:guard.checked(row)
    for key in ('build_run','build_report','fixture_plan','Shader_mapping','Material_mapping','canonical_manifest','fresh_conversion_run',
        'compiled_Material_reader_plan','compiled_Material_reader_proof','compiled_Material_reader_assembly'):check(plan[key])
    checked_tools();validate_build()
    return plan,out


def root_material_probes(path,wanted):
    plan,out=load_plan(path,wanted);probe,compiled=probe_inputs()
    target=out/'MaterialTypedProofs';target.mkdir()
    receipt={'schema':'ROOT-owned-four-compiled-Class21-reads/v1','status':'starting','plan':native.pin(path),'phases':[],
        'results':[],'Main_modified':False,'Unity_compiler_player_network_launched':False}
    try:
        env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1',DOTNET_NOLOGO='1')
        for row in plan['material_jobs']:
            raw=check(row['raw']);output=target/('Builtin-'+row['builtin_local_id']+'-typed-Material.json')
            command=[probe['dotnet']['path'],compiled['assembly']['path'],str(raw),row['raw']['sha256'],row['native_path_id'],str(output)]
            guard.bounded(command,out,target,'full-Class21-'+row['builtin_local_id'],256*1024**2,30,receipt,env)
            proof=json.loads(output.read_bytes())
            need(proof['status']=='entire_Class21_read_and_exact_Release_roundtrip_verified'
                and proof['full_Release_bytes_equal'] and proof['bytes']==proof['consumed_bytes']==proof['roundtrip_bytes']==row['raw']['bytes']
                and proof['source_sha256']==proof['roundtrip_sha256']==row['raw']['sha256'],'Entire exact typed Material readback')
            receipt['results'].append({'builtin_local_id':row['builtin_local_id'],'typed_report':native.pin(output)})
        receipt['status']='all_four_genuine_Class21_full_reads_and_entire_byte_roundtrips_passed'
    except BaseException as error:receipt.update(status='held',error=repr(error))
    guard.save(target,receipt)
    print(json.dumps({'status':receipt['status'],'receipt':native.pin(target/'run-report.json'),'error':receipt.get('error')}))
    need(receipt['status'].startswith('all_four_'),'Typed Material read sequence held')


def native_file_id(source,target,externals):
    source,target=Path(source).resolve(strict=True),Path(target).resolve(strict=True)
    if source==target:return 0,None
    matches=[]
    for index,row in enumerate(externals,1):
        relative=bytes.fromhex(row['path_hex']).decode('utf-8')
        if (row['asset_path_hex']=='' and row['guid_hex']=='0'*32 and row['type']==0
            and relative==target.name and relative not in ('','.','..') and '/' not in relative and '\\' not in relative
            and (source.parent/relative).resolve(strict=True)==target):matches.append((index,row))
    need(len(matches)==1,'Cross-container target requires exactly one existing proven plain-relative zeroGUID native external row')
    return matches[0]


def finalize(path,wanted):
    plan,out=load_plan(path,wanted)
    typed_path=out/'MaterialTypedProofs/run-report.json';typed=json.loads(typed_path.read_bytes())
    need(typed['schema']=='ROOT-owned-four-compiled-Class21-reads/v1' and typed['plan']==native.pin(path)
        and typed['status']=='all_four_genuine_Class21_full_reads_and_entire_byte_roundtrips_passed' and len(typed['results'])==len(typed['phases'])==4,'Actual Root four-reader receipt')
    for phase in typed['phases']:
        need(phase['exit_code']==0 and phase['owned_cli_or_compiler_exit_confirmed'] and phase['launcher']['membership_verified_before_resume']
            and phase['cap_bytes']==256*1024**2 and phase['reserve_bytes']==int(1.5*1024**3),'Every typed reader must complete in its exact assigned-before-resume owned job')
    pins=[r['typed_report'] for r in typed['results']]
    for row in pins:check(row)
    pin_list=out/'MaterialTypedProofs/typed-report-pins.json';save(pin_list,pins)
    material_map=json.loads(check(plan['Material_mapping']).read_bytes())
    resolved=builtin.resolve(material_map,pins,plan['player_root'])
    resolved.update(tool=native.pin(Path(builtin.__file__)),actual_input_report=plan['Material_mapping'],typed_report_pin_list=native.pin(pin_list))
    builtins_path=out/'NativeMapping/builtin-native-Shader-targets.json';save(builtins_path,resolved)
    mappings=json.loads(check(plan['Shader_mapping']).read_bytes());by_guid={r['guid']:r for r in mappings['mappings']}
    builtin_targets={r['builtin_local_id']:r['target'] for r in resolved['builtin_targets']}
    canonical=json.loads(check(plan['canonical_manifest']).read_bytes());proofs={r['guid']:r['typed_source_proof'] for r in plan['original_typed_source_proofs']}
    shaders=[];bindings=0
    for row in canonical['shaders']:
        source=check(by_guid[row['guid']]['container']);parsed,_=native.native(source);edges=[]
        for index,dep in enumerate(row['dependencies']):
            expected=patcher.expected_target(row,index)
            binding={'index':index,'kind':expected['kind'],'target_guid':expected['guid']}
            if expected['kind']=='null':binding.update(output_file_id=0,output_path_id='0')
            else:
                if expected['kind']=='project':target=by_guid[expected['guid']]
                else:
                    binding['builtin_local_id']=str(expected['builtin_id']);target=builtin_targets[binding['builtin_local_id']]
                target_path=check(target['container']);file_id,external=native_file_id(source,target_path,parsed['externals'])
                binding.update(output_file_id=file_id,output_path_id=target['path_id'],target_container=target['container'])
                if external is not None:binding['external_row']=external
            edges.append(binding);bindings+=1
        shaders.append({'guid':row['guid'],'typed_source_proof':proofs[row['guid']],'bindings':edges})
    patch_plan={'schema':'explicit-original-Shader-streaming-native-patch-with-builtin-Material-proof/v1',
        'canonical_manifest':plan['canonical_manifest'],'mapping_report':plan['Shader_mapping'],'builtin_material_mapping_report':native.pin(builtins_path),
        'player_root':plan['player_root'],'shaders':shaders,'actual_same_build_report':plan['build_report'],'orchestration_plan':native.pin(path),
        'Root_typed_Material_read_receipt':native.pin(typed_path),'Main_modified':False,'compiler_Unity_player_network_launched':False}
    player,containers,prepared=patcher.preflight(patch_plan)
    need(len(prepared)==8 and bindings==14,'Exactly all eight original payloads and fourteen original dependency bindings restored')
    patch_path=out/'original-eight-streaming-patch-plan.json';save(patch_path,patch_plan)
    patched=out/'PatchedNativeFiles';patched.mkdir()
    receipt={'schema':'same-build-eight-original-Shader-patch-plan-preflight/v1','status':'all8_original_payload_and14project_builtin_PPtr_bindings_native_preflight_passed_NO_PATCH_EXECUTED',
        'patch_plan':native.pin(patch_path),'builtin_mapping':native.pin(builtins_path),'Shader_count':8,'dependency_bindings':bindings,
        'native_containers':len(containers),'original_program_fields_preserved_by_exact_original_payloads':True,
        'Root_only_patch_command':[sys.executable,'-B',str(Path(patcher.__file__)),'--plan',str(patch_path),'--plan-sha256',guard.sha(patch_path),'--output',str(patched)],
        'Root_following_gate':'Require actual streaming-patch-report status, all8 appended readback SHAs,14 typed PPtr edits and exact masked original bytes before clone/runtime.',
        'runtime_or_GPU_ready':False,'Main_modified':False,'managed_compiler_Unity_player_network_launched':False}
    save(out/'patch-preflight-report.json',receipt)
    print(json.dumps({'status':receipt['status'],'receipt':native.pin(out/'patch-preflight-report.json'),'patch_plan':native.pin(patch_path),'Root_only_patch_command':receipt['Root_only_patch_command']}))


def main():
    ap=argparse.ArgumentParser(description=__doc__);choice=ap.add_mutually_exclusive_group(required=True)
    choice.add_argument('--prepare',action='store_true');choice.add_argument('--run-material-probes',action='store_true');choice.add_argument('--finalize',action='store_true')
    ap.add_argument('--plan',type=Path);ap.add_argument('--plan-sha256');ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);args=ap.parse_args()
    if args._worker:
        out=args._worker.resolve(strict=True);need(out.is_relative_to(AR) and out.name.startswith('EightOriginalShaderRestoration-'),'Recovery-only new workspace')
        if args.prepare:prepare(out)
        else:finalize(args.plan.resolve(strict=True),args.plan_sha256)
        return 0
    if args.run_material_probes:
        need(args.plan and args.plan_sha256,'Root explicit reviewed plan required')
        root_material_probes(args.plan.resolve(strict=True),args.plan_sha256);return 0
    if args.prepare:
        out=AR/('EightOriginalShaderRestoration-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    else:
        need(args.plan and args.plan_sha256,'Reviewed orchestration plan required');_,out=load_plan(args.plan.resolve(strict=True),args.plan_sha256)
    report={'schema':'guarded-pure-eight-Shader-restoration-data/v1','status':'starting','phases':[],'Main_modified':False,'managed_compiler_Unity_player_network_launched':False}
    command=[sys.executable,'-B',str(Path(__file__).resolve()),'--prepare' if args.prepare else '--finalize','--_worker',str(out)]
    if args.plan:command+=['--plan',str(args.plan.resolve(strict=True)),'--plan-sha256',args.plan_sha256]
    phase='pure-same-build8Shader4Material-native-mapping' if args.prepare else 'pure-four-builtin-binding-and-original8-native-preflight'
    try:
        guard.bounded(command,guard.WS,out,phase,256*1024**2,60,report);report['status']='passed'
    except BaseException as error:report.update(status='held',error=repr(error))
    receipt=out/('prepare-run-report.json' if args.prepare else 'finalize-run-report.json');save(receipt,report)
    print(json.dumps({'status':report['status'],'receipt':native.pin(receipt),'error':report.get('error')}))
    return 0 if report['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
