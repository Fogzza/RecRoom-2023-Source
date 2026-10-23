"""Pure guarded corroboration of the genuine small C# API-capture fixture."""
from pathlib import Path
import datetime as dt
import json
import sys
import uuid
import run_windows_development_define_probe as guard
import map_shader_buildreport as mapper

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS/'Recovery/RecRoom-2023-04-18/AssetRecovery'
RUN = ROOT/'OriginalAGDependencyFixture-20261023T045108Z-3fcc66c0/Run-20261023T045146Z-b9e37de3'
RECEIPT_SHA = 'f3e8ea1645f412d5a9c3324d125fadffef6b68e57e8422af05fc544e0a06f951'
EXPECTED = ROOT/'ShaderBuildReportMapperControls-20261023T045107Z-c7bb2910/expected-project-Shaders.json'


def main():
    guard.need(guard.sha(RUN/'run-report.json') == RECEIPT_SHA, 'Actual reviewed successful API build receipt changed')
    receipt = json.loads((RUN/'run-report.json').read_bytes())
    guard.need(receipt['status'].startswith('AG_Fallback_native_dependency_and_clean')
        and receipt['phases'][-1]['exit_code'] == 0 and receipt['partial_constant_buffer_full_log_count'] == 0
        and receipt['build']['result']['status'] == 'Succeeded'
        and receipt['build']['result']['input_assets_and_metas_unchanged'], 'Actual successful fresh API/build controls required')
    guard.checked(receipt['build']['report'])
    plan = json.loads(Path(receipt['plan']['path']).read_bytes())
    guard.checked(receipt['plan'])
    for row in plan['read_only_sources'] + [r for r in plan['inputs'] if not Path(r['path']).is_relative_to(Path(plan['project'])/'ProjectSettings')]:
        guard.checked(row)
    out = ROOT/('ActualShaderPackedAPIMapping-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'guarded-actual-CSharp-Shader-packed-API-native-corroboration/v1',
        'status': 'starting', 'phases': [], 'actual_build_receipt': mapper.pin(RUN/'run-report.json'),
        'actual_API_build_report': receipt['build']['report'], 'expected_GUID_paths': mapper.pin(EXPECTED),
        'mapper': mapper.pin(Path(mapper.__file__)), 'Main_modified': False,
        'Unity_launched': False, 'compiler_launched': False}
    try:
        command = [sys.executable, '-B', str(Path(mapper.__file__)), '--api-report', str(RUN/'build-report.json'),
            '--expected', str(EXPECTED), '--player-root', str(RUN/'Player'), '--out', str(out/'mapping-report.json')]
        guard.bounded(command, WS, out, 'actual-CSharp-API-to-native-Class48-map', 256*1024**2, 30, report)
        mapped = json.loads((out/'mapping-report.json').read_bytes())
        for row in mapped['mappings']:
            original = next(v for v in receipt['packaged_Shader_ranges_for_followup'].values()
                            if str(v['object']['path_id']) == row['path_id'])
            guard.need(row['container'] == original['container'] and row['raw_sha256'] == original['raw']['sha256'],
                       'Independent table/range/hash witness disagreement')
        report['mapping'] = mapper.pin(out/'mapping-report.json')
        report['actual_CSharp_API_values_independently_native_corroborated'] = True
        report['status'] = 'passed_actual_CSharp_GUID_Class48_id_absolute_range_and_payload_SHA_corroborated'
    except BaseException as exc:
        report.update(status='failed_or_guard_refused', error=repr(exc))
    finally:
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'receipt': mapper.pin(out/'run-report.json'), 'error': report.get('error')}))
    return 0 if report['status'].startswith('passed_') else 1


if __name__ == '__main__':
    raise SystemExit(main())
