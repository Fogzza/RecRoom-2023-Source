"""Owned 256MiB pure offline controls and optional fresh fixture preparation."""
from pathlib import Path
import argparse
import datetime as dt
import json
import sys
import uuid
import run_windows_development_define_probe as guard

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18/AssetRecovery'


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument('--prepare-fixture', action='store_true')
    args = ap.parse_args()
    out = ROOT / ('ShaderBuildReportMapperControls-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'guarded-pure-Shader-BuildReport-mapper-controls/v1', 'status': 'running',
        'phases': [], 'Main_modified': False, 'Unity_launched': False, 'compiler_launched': False,
        'production_credentials_used': False,
        'source_pins': [{'path': str(HERE/name), 'sha256': guard.sha(HERE/name)} for name in
            ('map_shader_buildreport.py', 'test_shader_buildreport_mapper.py',
             'ShaderPackedBuildReportCapture.cs', 'run_original_ag_packed_report_fixture.py')]}
    try:
        guard.bounded([sys.executable, '-B', str(HERE/'test_shader_buildreport_mapper.py'), '--out', str(out)], WS, out,
                      'actual-native-mapper-positive-negative-controls', 256*1024**2, 30, report)
        if args.prepare_fixture:
            folder = ROOT/'OriginalAGEditorGuidWrapper-20261023T025159Z-84496a7f'
            command = [sys.executable, '-B', str(HERE/'run_original_ag_packed_report_fixture.py'),
                '--ag-asset', str(folder/'AG_Standard-Opaque-EditorGuidBound.asset'),
                '--ag-sha', 'f0df9bb79d8cdb5ca455bfeb71b37fbb7da1d6a138e5551651728c9853a8981c',
                '--ag-proof', str(folder/'report.json'),
                '--ag-proof-sha', 'fd9b02fdf4131431bef3900673da0630b236a86226050b5c94231409c39b73ae']
            guard.bounded(command, WS, out, 'prepare-fresh-API-capture-fixture-no-launch', 256*1024**2, 30, report)
            prep = json.loads((out/'prepare-fresh-API-capture-fixture-no-launch-stdout.log').read_text())
            report['fresh_fixture_preparation'] = prep
        report['status'] = 'passed_actual_native_mapping_controls_no_Editor_or_compiler'
    except BaseException as exc:
        report.update(status='failed_or_guard_refused', error=repr(exc))
    finally:
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'receipt': str(out/'run-report.json'),
                          'sha256': guard.sha(out/'run-report.json'), 'error': report.get('error'),
                          'fixture': report.get('fresh_fixture_preparation')}))
    return 0 if report['status'].startswith('passed_') else 1


if __name__ == '__main__':
    raise SystemExit(main())
