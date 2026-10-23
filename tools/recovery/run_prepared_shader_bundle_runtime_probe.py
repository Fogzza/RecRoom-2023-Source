"""Run the reviewed original shader-only bundle in the already-tested tiny player."""
from pathlib import Path
import datetime as dt
import json
import re
import uuid
import run_windows_development_define_probe as guard
from run_original_shader_runtime_patch_fixture import launch_probe

HERE = Path(__file__).resolve().parent
ROOT = HERE.parents[2] / 'Recovery/RecRoom-2023-04-18'
INPUT = ROOT / 'AssetRecovery/OriginalShaderOnlyBundleRuntimeInput-20261023T024041Z-94c09341'
PREVIOUS = ROOT / 'AssetRecovery/OriginalShaderRuntimePatchFixture-20261023T024141Z-2a543430/Run-20261023T024141Z-06257a67'


def pin(p):
    return {'path': str(p.resolve()), 'sha256': guard.sha(p), 'bytes': p.stat().st_size}


def main():
    plan_path, previous_path = INPUT / 'runtime-test-plan.json', PREVIOUS / 'run-report.json'
    guard.need(guard.sha(plan_path) == '54f129960c07a1b5cd9dce62f1a7aeae166e136706899f541d299c4f9e8a84fa' and guard.sha(previous_path) == 'c78a2385429ac165141ebb577d7200362ae65782c70959b9baca5c7f676a60ab', 'Frozen actual proof inputs changed')
    plan, previous = json.loads(plan_path.read_bytes()), json.loads(previous_path.read_bytes())
    guard.need(previous['status'] == 'exact_original_release_shader_patch_passed_D3D11_runtime_positive_and_negative_controls', 'Same-player green GPU control and original shader patch proof required')
    for key in ('input_proof', 'config', 'runtime_source', 'original_ParsedForm'):
        guard.checked(plan[key])
    cfg = json.loads(Path(plan['config']['path']).read_bytes())
    for row in cfg['bundles']:
        guard.checked(row)
    player = PREVIOUS / 'Patched/OriginalShaderRuntimeDiagnostic.exe'
    project = PREVIOUS.parent / 'Project'
    guard.need(player.is_file() and (player.parent / 'OriginalShaderRuntimeDiagnostic_Data/Managed/Assembly-CSharp.dll').is_file(), 'Exact already-built shared-harness player required')
    guard.checked(previous['patch']['output_container'])
    out = INPUT / ('Runtime-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'guarded-original-shader-only-bundle-runtime-probe/v1', 'status': 'starting', 'phases': [], 'plan': pin(plan_path), 'prior_GPU_control': pin(previous_path),
              'player': pin(player), 'runtime_assembly': pin(player.parent / 'OriginalShaderRuntimeDiagnostic_Data/Managed/Assembly-CSharp.dll'),
              'Main_modified': False, 'Editor_launched': False, 'gameplay_tested': False}
    result_path = out / 'runtime-result.json'
    args = [str(result_path) if s == '<fresh output JSON>' else s for s in plan['arguments']]
    command = [str(player)] + args + ['-logFile', str(out / 'Player.log')]
    try:
        green = launch_probe(None, project, out, report, player, 'clean-patched-player-green-control', False)
        green_observation = report['clean-patched-player-green-control']
        guard.need(green_observation['process_failure'] is None and not green_observation['full_log_shader_diagnostics'] and green['status'] == 'exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed'
                   and green['center_pixel'] == {'r': 0, 'g': 255, 'b': 0, 'a': 255}, 'Independent green GPU control must pass and have zero errors throughout full Player.log')
        guard.bounded(command, project, out, 'shader-only-original-bundle-player', plan['suggested_owned_job_cap_bytes'], plan['deadline_seconds'], report)
        actual = json.loads(result_path.read_bytes())
        report['runtime_result'] = actual
        report['runtime_result_pin'] = pin(result_path)
        log_path = out / 'Player.log'
        log_text = log_path.read_text(encoding='utf-8', errors='replace')
        errors = [line[:1024] for line in log_text.splitlines() if re.search(r'Partial constant buffer not found\.|Shader error in|ERROR: Shader|ShaderUnsupported|Failed to find expected binary shader data', line, re.I)]
        report['full_player_log'] = pin(log_path)
        report['full_log_shader_diagnostics'] = errors[:64]
        guard.need(actual['status'] == 'exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed' and actual['property_names'] == plan['expected_property_names']
                   and actual['material_pass_count'] == plan['expected_material_pass_count'] and actual['partial_constant_buffer_messages'] == 0 and not actual['shader_error_lines'] and not errors, 'Original shader-only bundle runtime proof failed including complete Player.log')
        for row in cfg['bundles']:
            guard.checked(row)
        guard.checked(report['player'])
        guard.checked(report['runtime_assembly'])
        report['status'] = 'exact_original_shader_only_bundle_loaded_and_rendered_D3D11_without_reemission'
    except BaseException as error:
        report.update(status='failed_or_guard_refused', error=repr(error))
        if result_path.is_file():
            report['runtime_result'] = json.loads(result_path.read_bytes())
    finally:
        report['finished_utc'] = dt.datetime.now(dt.timezone.utc).isoformat()
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'report': pin(out / 'run-report.json'), 'error': report.get('error')}), flush=True)
    return 0 if report['status'].startswith('exact_original_shader_only_bundle_loaded') else 1


if __name__ == '__main__':
    raise SystemExit(main())
