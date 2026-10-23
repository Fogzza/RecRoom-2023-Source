"""Prove original AG/Fallback programs with optional genuine URP shader selection tag.
The tag permits the manual shader pass test; no real URP implementation is added.
"""
from pathlib import Path
import argparse
import datetime as dt
import json
import os
import re
import shutil
import sys
import uuid
import run_windows_development_define_probe as guard
from patch_isolated_room_shader_pair import patch_pair
from patch_isolated_player_shader import inspect, parser_module
from shader_program_data import model_program, program_facts

HERE = Path(__file__).resolve().parent
ROOT = HERE.parents[2] / 'Recovery/RecRoom-2023-04-18'
RUN = ROOT / 'AssetRecovery/OriginalAGDependencyFixture-20261023T025353Z-cfa54d37/Run-20261023T025506Z-1308d744'
READER_ROOT = ROOT / 'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
AG = ROOT / 'AssetRecovery/OriginalShaderRecoveryRoute-20261022T184808Z-356f2e1f/OriginalSerializedShaderObjects/native-6351.bin'
FALLBACK = ROOT / 'AssetRecovery/OriginalShaderEditorConversion-20261022T212623Z-fde1a98d/OriginalReleaseShader.bin'


def pin(path):
    return {'path': str(path.resolve()), 'sha256': guard.sha(path), 'bytes': path.stat().st_size}


def decode_worker(spec_path):
    spec = json.loads(spec_path.read_bytes())
    for record in spec['objects']:
        guard.checked(record['raw'])
        guard.checked(record['model'])
        facts = program_facts(model_program(json.loads(Path(record['model']['path']).read_bytes()), Path(record['raw']['path']).read_bytes()))
        output = spec_path.parent / (record['key'] + '-all-DXBC.json')
        output.write_text(json.dumps(facts, indent=2) + '\n', encoding='utf-8')


def main():
    global RUN
    args = argparse.ArgumentParser(description=__doc__)
    args.add_argument('--decode-worker', type=Path)
    args.add_argument('--build-receipt', type=Path)
    args.add_argument('--build-receipt-sha')
    args.add_argument('--pipeline-tag', choices=['unchanged','UniversalPipeline,LightweightPipeline'], default='unchanged')
    parsed = args.parse_args()
    if parsed.decode_worker:
        decode_worker(parsed.decode_worker)
        return 0
    if parsed.build_receipt:
        receipt_path = parsed.build_receipt.resolve(strict=True)
        guard.need(receipt_path.is_relative_to(ROOT / 'AssetRecovery') and parsed.build_receipt_sha, 'Explicit isolated actual build receipt and hash required')
        RUN = receipt_path.parent
        expected_receipt_sha = parsed.build_receipt_sha
    else:
        receipt_path = RUN / 'run-report.json'
        expected_receipt_sha = '0160a658a57b4d994d7082661c7e364572af435b453c1450399ce326c1e3688f'
    guard.need(guard.sha(receipt_path) == expected_receipt_sha, 'Actual clean AG dependency build receipt changed')
    receipt = json.loads(receipt_path.read_bytes())
    guard.need(receipt['status'] == 'AG_Fallback_native_dependency_and_clean_Windows_build_verified_cooked_program_retention_not_claimed' and receipt['partial_constant_buffer_full_log_count'] == 0, 'Actual dependency/import/build proof required')
    selected = receipt['packaged_Shader_ranges_for_followup']
    ag, fallback = selected['AG/Standard-Opaque'], selected['Hidden/Universal Render Pipeline/FallbackError']
    for record in (ag, fallback):
        guard.checked(record['container'])
        guard.checked(record['raw'])
    guard.need(ag['container'] == fallback['container'], 'Two actual shaders must share their local native container')
    source_container = Path(ag['container']['path'])
    source_player = Path(receipt['diagnostic_player']['path'])
    guard.checked(receipt['diagnostic_player'])
    out = RUN.parent / ('OriginalProgramRestoration-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    project = RUN.parent / 'Project'
    report = {'schema': 'original-AG-Fallback-postbuild-program-restoration/v1', 'status': 'starting', 'phases': [], 'input_build_receipt': pin(receipt_path),
              'Main_modified': False, 'Editor_launched': False, 'gameplay_tested': False, 'AG_visual_fidelity_claimed': False, 'patcher': pin(HERE / 'patch_isolated_room_shader_pair.py')}
    try:
        player_dir = out / 'Player'
        player_dir.mkdir()
        for source in source_player.parent.rglob('*'):
            guard.safety.assert_no_reparse(source)
            target = player_dir / source.relative_to(source_player.parent)
            if source.is_dir():
                target.mkdir(exist_ok=True)
            elif source != source_container:
                shutil.copyfile(source, target)
                guard.need(guard.sha(source) == guard.sha(target), 'Clone every unmodified player file exactly')
        output, proof = patch_pair(source_container.read_bytes(), AG.read_bytes(), FALLBACK.read_bytes(), int(ag['object']['path_id']), int(fallback['object']['path_id']), ag['raw']['sha256'], fallback['raw']['sha256'])
        target_container = player_dir / source_container.relative_to(source_player.parent)
        target_container.write_bytes(output)
        report['patch'] = {'source': pin(source_container), 'target': pin(target_container), 'proof': proof}
        _, table, _, _ = inspect(output, parser_module())
        objects = []
        env = dict(os.environ, DOTNET_PROCESSOR_COUNT='1', DOTNET_CLI_TELEMETRY_OPTOUT='1', DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1', DOTNET_NOLOGO='1')
        for key, name, original in [('AG', 'AG/Standard-Opaque', ag), ('Fallback', 'Hidden/Universal Render Pipeline/FallbackError', fallback)]:
            row = next(o for o in table['objects'] if o['path_id'] == int(original['object']['path_id']))
            raw = out / (key + '-Patched.bin')
            raw.write_bytes(output[row['offset']:row['offset'] + row['size']])
            model = out / (key + '-Model')
            guard.bounded(['C:/Program Files/dotnet/dotnet.exe', str(READER_ROOT / 'OriginalShaderObjectProbe.dll'), str(raw), guard.sha(raw), str(row['path_id']), name, str(model)], project, out, key + '-typed-full-object-read', 512 * 1024**2, 60, report, env=env)
            actual = json.loads((model / 'report.json').read_bytes())
            guard.need(actual['status'] == 'parsed_entire_original_object' and actual['consumed_bytes'] == actual['total_bytes'] == row['size'], 'Whole mapped original Release object must parse')
            objects.append({'key': key, 'name': name, 'raw': pin(raw), 'model': pin(model / 'report.json')})
        spec = out / 'decode-spec.json'
        spec.write_text(json.dumps({'objects': objects}, indent=2) + '\n', encoding='utf-8')
        guard.bounded([sys.executable, '-B', str(Path(__file__).resolve()), '--decode-worker', str(spec)], project, out, 'decode-all-original-DXBC', 512 * 1024**2, 90, report)
        summaries = []
        for row in objects:
            facts_path = out / (row['key'] + '-all-DXBC.json')
            facts = json.loads(facts_path.read_bytes())
            summaries.append({'name': row['name'], 'report': pin(facts_path), 'compiled_blob_bytes': facts['blob_bytes'], 'compiled_blob_sha256': facts['blob_sha256'], 'segments': len(facts['segments']), 'DXBC_count': facts['dxbc_chunks'], 'unique_DXBC_count': len(facts['unique_dxbc_sha256'])})
        report['restored_GPU_programs'] = summaries
        player = player_dir / source_player.name
        runtime_result = out / 'AG-runtime-result.json'
        log = out / 'AG-Player.log'
        command = [str(player), '-batchmode', '-force-d3d11', '-screen-width', '64', '-screen-height', '64', '-logFile', str(log),
                   '-shaderProbeMode', 'resources', '-shaderProbeResource', 'OriginalAG', '-shaderProbeExpectedName', 'AG/Standard-Opaque',
                   '-shaderProbeExpectedProperties', '49', '-shaderProbeExpectedPasses', '5', '-shaderProbePixelCheck', 'none', '-shaderProbeOutput', str(runtime_result)]
        command += ['-shaderProbePipelineTag', parsed.pipeline_tag]
        report['requested_original_URP_shader_selection_tag'] = parsed.pipeline_tag
        runtime_error = None
        try:
            guard.bounded(command, project, out, 'AG-manual-D3D11-runtime-probe', 2 * 1024**3, 60, report)
        except RuntimeError as error:
            runtime_error = str(error)
        if runtime_result.is_file():
            report['AG_runtime'] = {'report': pin(runtime_result), 'result': json.loads(runtime_result.read_bytes()), 'process_failure': runtime_error}
        if log.is_file():
            text = log.read_text(encoding='utf-8', errors='replace')
            report['AG_full_player_log'] = pin(log)
            report['AG_full_log_shader_diagnostics'] = [s[:1024] for s in text.splitlines() if re.search(r'Partial constant buffer not found\.|Shader error in|ERROR: Shader|ShaderUnsupported|Failed to find expected binary shader data', s, re.I)][:64]
        guard.checked(ag['container'])
        report['status'] = 'exact_original_AG_and_Fallback_GPU_programs_restored_with_proven_local_dependency'
        if runtime_error is None and report.get('AG_runtime', {}).get('result', {}).get('status') == 'exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed' and not report.get('AG_full_log_shader_diagnostics'):
            report['AG_manual_D3D11_pass_and_readback_verified'] = True
        else:
            report['AG_manual_D3D11_pass_and_readback_verified'] = False
            report['AG_runtime_limit'] = 'Original room Shader targets UniversalPipeline; this isolated Builtin test does not prove real room rendering.'
    except BaseException as error:
        report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        report['finished_utc'] = dt.datetime.now(dt.timezone.utc).isoformat()
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'report': pin(out / 'run-report.json'), 'error': report.get('error'), 'AG_manual_GPU_verified': report.get('AG_manual_D3D11_pass_and_readback_verified')}), flush=True)
    return 0 if report['status'].startswith('exact_original_AG_and_Fallback') else 1


if __name__ == '__main__':
    raise SystemExit(main())
