"""Finalize the existing Mixed binary Shader test; no Editor/build/compiler launch."""
from pathlib import Path
import datetime as dt
import json
import os
import uuid
import run_windows_development_define_probe as guard
from probe_original_shader_sources import native_objects, object_name
from shader_program_data import model_program, program_facts, lz4, dxbc, digest

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
FIXTURE = WS / 'Recovery/RecRoom-2023-04-18/AssetRecovery/OriginalShaderWindowsBuildFixture-Mixed-20261022T214413Z-51ccf456'
RUN = FIXTURE / 'Run-20261022T214438Z-0aae461b'
need = guard.need


def row(path):
    return {'path': str(path.resolve()), 'sha256': guard.sha(path), 'bytes': path.stat().st_size}


def main():
    frozen = [
        (FIXTURE / 'plan.json', 'ff8427db7cdd28c60bab2b3e93d9d50c114f03fc58e7162ed798462a7f057b76'),
        (RUN / 'run-report.json', '068dfb621a34fd5f55782cd9871038d7bfa7224ef8065d4f721b6e1cdd8689f5'),
        (RUN / 'build-report.json', '46fd58da67cf01c061a4329747682173b91e25e2b2a3788b762cedf2975f9a0b'),
        (RUN / 'BuiltShaderModel-0/report.json', '95437a00dff9557b78743a24672d95f84364f6d13f8aab56fd35302b4b84a7cb'),
        (RUN / 'BuiltShader-0.bin', '676515fb319afaca6d60c75d20a6b318bec172face0d74d96b1f5d45cba5a092'),
    ]
    for path, expected in frozen:
        need(guard.sha(path) == expected, 'Frozen Mixed test evidence changed')
    plan = json.loads(frozen[0][0].read_bytes())
    previous = json.loads(frozen[1][0].read_bytes())
    built = json.loads(frozen[2][0].read_bytes())
    model = json.loads(frozen[3][0].read_bytes())
    guard.safety.assert_editor_closed()
    for pin in plan['reader_pins'] + plan['support_sources'] + plan['read_only_sources'] + [plan[k] for k in ('reader', 'dotnet', 'launcher', 'original_programs', 'expected_data')]:
        guard.checked(pin)
    for pin in plan['inputs']:
        if not Path(pin['path']).is_relative_to(Path(plan['project']) / 'ProjectSettings'):
            guard.checked(pin)
    guard.checked(previous['diagnostic_player'])
    phase = [p for p in previous['phases'] if p['phase'] == 'tiny-original-shader-Windows-build']
    need(len(phase) == 1 and phase[0]['exit_code'] == 0 and phase[0]['owned_cli_or_compiler_exit_confirmed'] and phase[0]['Editor_closed_after_job'], 'Closed owned successful build required')
    need(built['status'] == 'Succeeded' and built['total_errors'] == built['total_warnings'] == built['partial_constant_buffer_messages'] == 0 and built['input_bytes_unchanged'] and built['serialization_mode'] == 'Mixed' and built['direct_original_binary_imported'] and built['imported_file_id'] == 4800000 and built['imported_guid'] == 'd2a5536c48f6e914f900eb13ea2f4d68', 'Exact successful import/build controls required')
    need(previous['partial_constant_buffer_log_count'] == 0 and previous['failure_log_lines'] == [], 'No shader failure log lines required')
    need(model['status'] == 'parsed_entire_original_object' and model['actual_name'] == 'Hidden/Universal Render Pipeline/FallbackError' and model['total_bytes'] == model['consumed_bytes'] == 2652, 'Complete native packaged Shader read required')
    raw = frozen[-1][0].read_bytes()
    program = model_program(model, raw)
    need(program['platforms'] == [4] and program['offsets'] == [[0]] and program['compressedLengths'] == [[5]] and program['decompressedLengths'] == [[4]] and program['blob'] == bytes.fromhex('4000000000'), 'Exact empty packaged program encoding required')
    expanded = lz4(program['blob'], 4)
    need(expanded == bytes(4) and dxbc(expanded) == [], 'Zero programs, not a decoder exception, required')
    original = json.loads(Path(plan['original_programs']['path']).read_bytes())['shaders']
    need(len(original) == 1 and original[0]['program']['blob_bytes'] == 991 and original[0]['program']['dxbc_chunks'] == 4, 'Exact original positive programs required')
    out = FIXTURE / ('FinalProgramRetentionControl-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'mixed-original-editor-binary-shader-build-retention-control/v1', 'status': 'starting', 'phases': [],
              'tool': row(Path(__file__)), 'frozen_inputs': [row(p) for p, _ in frozen], 'builtin_selection': 'Class48 row3/5432B as in earlier same-target builtin control; full reader verifies actual ParsedForm name because stripped leading NamedObject name is empty', 'Main_modified': False,
              'Editor_launched': False, 'compiler_launched': False, 'build_repeated': False, 'player_launched': False,
              'original_binary_preserved_during_import_and_build': True, 'original_meta_GUID_localFileID_preserved': True,
              'build_succeeded_errors_warnings_partialCB_zero': True, 'packaged_original_shader': {
                  'model': row(frozen[3][0]), 'raw': row(frozen[-1][0]), 'full_object_consumption': True,
                  'fields': model['fields'], 'blob_hex': program['blob'].hex(), 'expanded_hex': expanded.hex(),
                  'expanded_sha256': digest(expanded), 'DXBC_count': 0, 'original_DXBC_count': 4,
                  'compiled_program_retention_failed': True}, 'builtin_control': None}
    try:
        source = RUN / 'Player/OriginalShaderDiagnostic_Data/globalgamemanagers.assets'
        table = native_objects(source)
        need(table['engine'] == '2020.3.33f1' and table['endian'] == '<', 'Matching native output metadata required')
        matches = [obj for obj in table['shader_objects'] if obj['path_id'] == '3' and obj['byte_size'] == 5432]
        need(len(matches) == 1 and 0 < matches[0]['byte_size'] <= 1024**2, 'Exact previously proven builtin Class48 row3/5432B required; full reader must verify ParsedForm name')
        obj = matches[0]
        with source.open('rb') as stream:
            stream.seek(obj['byte_offset'])
            builtin = stream.read(obj['byte_size'])
        need(len(builtin) == obj['byte_size'], 'Complete builtin object range required')
        rawpath = out / 'Builtin-SpritesDefault.bin'
        rawpath.write_bytes(builtin)
        target = out / 'BuiltinModel'
        home = out / 'DotnetHome'
        home.mkdir()
        env = dict(os.environ, DOTNET_PROCESSOR_COUNT='1', DOTNET_CLI_TELEMETRY_OPTOUT='1', DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1', DOTNET_NOLOGO='1', DOTNET_CLI_HOME=str(home))
        guard.bounded([plan['dotnet']['path'], plan['reader']['path'], str(rawpath), guard.sha(rawpath), obj['path_id'], 'Sprites/Default', str(target)], Path(plan['project']), out, 'read-same-build-builtin', 512 * 1024**2, 60, report, env=env)
        modelpath = target / 'report.json'
        control = json.loads(modelpath.read_bytes())
        need(control['actual_name'] == 'Sprites/Default' and control['status'] == 'parsed_entire_original_object' and control['consumed_bytes'] == control['total_bytes'] == len(builtin), 'Full same-build builtin read required')
        facts = program_facts(model_program(control, builtin))
        need(facts['dxbc_chunks'] > 0, 'Same-build builtin must contain real DXBC')
        report['builtin_control'] = {'container': row(source), 'object': obj, 'raw': row(rawpath), 'model': row(modelpath), 'full_object_consumption': True, 'program': facts}
        report['status'] = 'original_Editor_binary_import_preserved_but_BuildPlayer_program_retention_failed_builtin_control_passed'
        report['barrier'] = 'Authentic cooked Shader object import and exact source bytes do not establish BuildPlayer compiled-program retention. This tested original FallbackError packages zero DXBC while the same build packages valid builtin DXBC.'
        report['future_routes_not_tested'] = ['Runtime loading of exact original bundles with proved platform/dependency/material closure.', 'Faithful recovery of original shader source, custom includes and compiler contract.']
    except BaseException as error:
        report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        report['frozen_inputs_unchanged'] = all(guard.sha(p) == h for p, h in frozen)
        need(report['frozen_inputs_unchanged'], 'Frozen original evidence must remain unchanged')
        guard.safety.assert_editor_closed()
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'receipt': row(out / 'run-report.json'), 'packaged_original_DXBC': 0, 'same_build_builtin_DXBC': report['builtin_control']['program']['dxbc_chunks'] if report['builtin_control'] else None, 'error': report.get('error')}))
    return 0 if report['builtin_control'] else 1


if __name__ == '__main__':
    raise SystemExit(main())
