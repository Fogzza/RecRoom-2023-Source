"""Pure singleton writer with mandatory successful bounded-conversion receipt."""
from pathlib import Path
import argparse
import datetime as dt
import importlib.util
import json
import sys
import uuid

HERE = Path(__file__).resolve().parent
BASE = HERE / 'stage_editor_shader_native_input.py'
import hashlib
if hashlib.sha256(BASE.read_bytes()).hexdigest() != 'abd134a9272de3365a3b492228e66bf526dffcd07bdae2851e6a1b6b5269c455':
    raise ValueError('Frozen reviewed metadata/wrapper implementation changed')
spec = importlib.util.spec_from_file_location('frozen_editor_shader_wrapper', BASE)
base = importlib.util.module_from_spec(spec)
spec.loader.exec_module(base)
original_checked_payload = base.checked_payload


def checked_payload(args):
    base.need(args.conversion_run_report and args.conversion_run_report_sha, 'Successful guarded conversion run receipt and expected SHA required')
    run_path = args.conversion_run_report.resolve(strict=True)
    run_pin = base.pin(run_path)
    base.need(run_path.is_relative_to(base.ROOT / 'AssetRecovery') and run_pin['sha256'] == args.conversion_run_report_sha, 'Pinned conversion run receipt changed or outside staging')
    run = json.loads(run_path.read_bytes())
    base.need(run.get('schema') == 'guarded-pure-original-shader-Editor-conversion/v1' and run.get('status') == 'all_original_data_and_DXBC_preserved_in_Editor_roundtrip' and not run.get('error'), 'Actual successful bounded conversion required before wrapping')
    base.need(run.get('Editor_launched') is False and run.get('native_api_executed') is False and run.get('Main_modified') is False, 'Pure conversion scope required')
    base.need(len(run.get('phases', [])) == 2, 'Exact compile plus data-roundtrip phases required')
    for phase in run['phases']:
        launch = phase.get('launcher', {})
        base.need(phase.get('exit_code') == 0 and phase.get('owned_cli_or_compiler_exit_confirmed') is True and launch.get('membership_verified_before_resume') is True and launch.get('resume_previous_suspend_count') == 1, 'Both actual conversion phases must pass with assign-before-resume proof')
    for key, path, expected in [('conversion_report', args.converter_report, args.converter_report_sha), ('editor_payload', args.payload, args.payload_sha)]:
        witness = run.get(key, {})
        base.need(Path(witness.get('path', '')).resolve() == path.resolve() and witness.get('sha256') == expected, 'Successful run does not pin exact converter output: ' + key)
    payload, evidence = original_checked_payload(args)
    evidence.update(successful_conversion_run=run_pin, conversion_guard_wrapper=base.pin(Path(__file__)))
    return payload, evidence


base.checked_payload = checked_payload


def main():
    p = argparse.ArgumentParser(description=__doc__)
    p.add_argument('--payload', type=Path, required=True)
    p.add_argument('--payload-sha', required=True)
    p.add_argument('--converter-report', type=Path, required=True)
    p.add_argument('--converter-report-sha', required=True)
    p.add_argument('--conversion-run-report', type=Path, required=True)
    p.add_argument('--conversion-run-report-sha', required=True)
    p.add_argument('--output', type=Path)
    p.add_argument('--worker', action='store_true')
    args = p.parse_args()
    if args.worker:
        base.need(args.output, 'Worker requires a fresh parent-created output directory')
        return base.worker(args)
    base.need(args.output is None, 'Parent creates a fresh output directory')
    out = base.ROOT / 'AssetRecovery' / ('EditorShaderNativeInput-v2-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    import read_original_ag_shader_models as bounded
    bounded.CAP = 256 * 1024**2
    command = [sys.executable, '-B', str(Path(__file__).resolve()), '--worker', '--output', str(out),
               '--payload', str(args.payload.resolve()), '--payload-sha', args.payload_sha,
               '--converter-report', str(args.converter_report.resolve()), '--converter-report-sha', args.converter_report_sha,
               '--conversion-run-report', str(args.conversion_run_report.resolve()), '--conversion-run-report-sha', args.conversion_run_report_sha]
    run = bounded.phase(command, out, 'pure-proven-editor-shader-wrapper')
    (out / 'outer-job-report.json').write_text(json.dumps(run, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'report': str(out / 'report.json'), 'job_report': str(out / 'outer-job-report.json'), 'exit_code': run.get('exit_code'), 'peak_job_bytes': run.get('peak_job_bytes'), 'error': run.get('error')}), flush=True)
    return 0 if run.get('exit_code') == 0 and not run.get('error') else 1


if __name__ == '__main__':
    raise SystemExit(main())
