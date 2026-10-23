"""Prepare or run an isolated179-original-Shader Windows build, never Main.

Preparation is pure copying and pinning. --run alone launches the reviewed
matching compiler/Editor in owned capped jobs. No recovered game code is used.
"""
from pathlib import Path
import argparse
import datetime as dt
import json
import re
import shlex
import uuid
import run_windows_development_define_probe as guard

HERE = Path(__file__).resolve().parent
ROOT = HERE.parents[2] / 'Recovery/RecRoom-2023-04-18'
TEMPLATE = ROOT / 'AssetRecovery/OriginalAGDependencyFixture-20261023T030326Z-a1848347'
TEMPLATE_SHA = '1012a5935462ac9034da85aa0b11b212488d0df03440570174a438db1ca54549'
CAP = 3 * 1024**3


def pin(path):
    path = Path(path).resolve(strict=True)
    guard.safety.assert_no_reparse(path)
    return {'path': str(path), 'sha256': guard.sha(path), 'bytes': path.stat().st_size}


def save(path, value):
    with path.open('x', encoding='utf-8') as stream:
        json.dump(value, stream, indent=2)
        stream.write('\n')


def prepare(args):
    guard.need(guard.sha(TEMPLATE / 'plan.json') == TEMPLATE_SHA, 'Reviewed successful two-Shader template changed')
    base = json.loads((TEMPLATE / 'plan.json').read_bytes())
    for source, expected in [(args.manifest, args.manifest_sha256), (args.wrappers, args.wrappers_sha256)]:
        guard.need(source.resolve(strict=True).is_relative_to(ROOT / 'AssetRecovery') and guard.sha(source) == expected, 'Pinned recovery-only manifest/collection required')
    manifest, wrappers = json.loads(args.manifest.read_bytes()), json.loads(args.wrappers.read_bytes())
    guard.need(manifest['schema'] == 'resolved-original-Shader-Editor-collection/v1' and len(manifest['shaders']) == 179, 'Full resolved179 original inputs required')
    guard.need(wrappers['status'] == 'all_mapped_original_Shader_Editor_wrappers_verified_native_import_unproven'
               and wrappers['manifest']['sha256'] == args.manifest_sha256 and wrappers['count'] == len(wrappers['shaders']) == 179, 'Actual exact179 native wrapper receipt required')
    by_guid = {row['guid']: row for row in manifest['shaders']}
    guard.need(len(by_guid) == 179 and {row['guid'] for row in wrappers['shaders']} == set(by_guid), 'Unique exact shader identity set')
    out = ROOT / 'AssetRecovery' / ('OriginalShaderCollectionFixture-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    project, inputs, sources = out / 'Project', [], [pin(TEMPLATE / 'plan.json'), pin(args.manifest), pin(args.wrappers)]
    original_inputs = {Path(row['path']).relative_to(TEMPLATE / 'Project').as_posix(): row for row in base['inputs']}

    def write(relative, data):
        path = project / relative
        path.parent.mkdir(parents=True, exist_ok=True)
        with path.open('xb') as stream:
            stream.write(data)
        inputs.append(pin(path))
        return path

    def copy(source, relative, expected):
        record = pin(source)
        guard.need(record['sha256'] == expected, 'Exact copy source changed')
        target = write(relative, Path(source).read_bytes())
        guard.need(guard.sha(target) == guard.sha(source) == expected, 'Copied source raced or changed')
        sources.append(record)
        return target

    for relative in ('Packages/manifest.json', 'Packages/packages-lock.json', 'ProjectSettings/EditorSettings.asset',
                     'ProjectSettings/ProjectSettings.asset', 'ProjectSettings/ProjectVersion.txt',
                     'Assets/Resources/ShaderProbeControl.shader', 'Assets/Runtime/OriginalShaderRuntimeProbe.cs',
                     'Assets/Editor/AvoidSavingYamlShaders.cs', 'Assets/Editor/AvoidSavingYamlShaders.cs.meta'):
        # BuildPlayer legitimately changed the template's player settings. Copy
        # the still-pinned original Main settings read-only for that one input.
        source = HERE.parents[2] / 'RR23' / relative if relative == 'ProjectSettings/ProjectSettings.asset' else TEMPLATE / 'Project' / relative
        copy(source, relative, original_inputs[relative]['sha256'])
    guard.need(b'  m_SerializationMode: 0' in (project / 'ProjectSettings/EditorSettings.asset').read_bytes(), 'Mixed before import required')
    builder = copy(HERE / 'BuildOriginalShaderCollectionFixture.cs', 'Assets/Editor/BuildOriginalShaderCollectionFixture.cs', guard.sha(HERE / 'BuildOriginalShaderCollectionFixture.cs'))
    capture = copy(HERE / 'ShaderPackedBuildReportCapture.cs', 'Assets/Editor/ShaderPackedBuildReportCapture.cs', guard.sha(HERE / 'ShaderPackedBuildReportCapture.cs'))
    shaders = []
    for row in wrappers['shaders']:
        original = by_guid[row['guid']]
        for key in ('asset', 'meta', 'proof'):
            guard.checked(row[key])
        guard.need(row['name'] == original['name'] and row['meta']['sha256'] == original['meta']['sha256']
                   and row['expected_direct_shader_dependencies'] == original['expected_direct_shader_dependencies'], 'Exact wrapper identity/dependencies required')
        relative = 'Assets/Resources/OriginalShaders/' + row['guid'] + '.asset'
        asset = copy(Path(row['asset']['path']), relative, row['asset']['sha256'])
        copy(Path(row['meta']['path']), relative + '.meta', row['meta']['sha256'])
        sources.append(row['proof'])
        shaders.append({'path': relative, 'sha256': guard.sha(asset), 'meta_sha256': row['meta']['sha256'], 'guid': row['guid'], 'name': row['name'],
                        'dependencies': row['expected_direct_shader_dependencies']})
    graphics_source = TEMPLATE / 'Project/ProjectSettings/GraphicsSettings.asset'
    guard.need(guard.sha(graphics_source) == original_inputs['ProjectSettings/GraphicsSettings.asset']['sha256'], 'Proven template GraphicsSettings changed')
    sources.append(pin(graphics_source))
    replacement = ('  m_AlwaysIncludedShaders:\n' + ''.join('  - {fileID: 4800000, guid: ' + row['guid'] + ', type: 2}\n' for row in shaders)).encode()
    graphics, count = re.subn(rb'(?ms)^  m_AlwaysIncludedShaders:\r?\n.*?(?=^  [A-Za-z_])', replacement, graphics_source.read_bytes())
    guard.need(count == 1 and b'  m_CustomRenderPipeline: {fileID: 0}' in graphics, 'Explicit179 keep-list and null diagnostic pipeline required')
    graphics_path = write('ProjectSettings/GraphicsSettings.asset', graphics)
    config = out / 'config.json'
    save(config, {'project': str(project), 'graphics_sha256': guard.sha(graphics_path), 'shaders': shaders})
    refs = base['compile_checks'][0]['references']
    response = out / 'fixture.rsp'
    response.write_text('\n'.join(['/nologo', '/nostdlib+', '/target:library', '/langversion:8'] + ['/reference:"' + row['path'] + '"' for row in refs]
                                  + ['"' + str(source) + '"' for source in (builder, capture, project / 'Assets/Runtime/OriginalShaderRuntimeProbe.cs')]) + '\n', encoding='utf-8')
    plan = {'schema': 'prepared-original179-Shader-native-import-build/v1', 'status': 'prepared_no_child_started', 'fixture': str(out), 'project': str(project),
            'runner': pin(Path(__file__)), 'guard': pin(HERE / 'run_windows_development_define_probe.py'), 'launcher': pin(HERE / 'owned_suspended_launch.py'),
            'editor': base['editor'], 'cli': base['cli'], 'compiler': base['compiler'], 'config': pin(config), 'inputs': inputs, 'read_only_sources': sources,
            'compile_checks': [{'name': 'original179-builder-capture-runtime', 'source': pin(builder), 'additional_sources': [pin(capture)], 'response': pin(response), 'references': refs}],
            'Main_modified': False, 'original_game_code_executed': False, 'cap_bytes': CAP, 'reserve_bytes': guard.RESERVE,
            'limitations': ['Original asset import, dependency witnesses and actual packed Shader API capture only.', 'No cooked-program retention, gameplay, actual URP renderer or visual fidelity claim.']}
    path = out / 'plan.json'
    save(path, plan)
    return path


def verify(path, expected):
    guard.need(guard.sha(path) == expected, 'Explicit reviewed plan hash required')
    plan = json.loads(path.read_bytes())
    fixture, project = path.parent.resolve(strict=True), Path(plan['project']).resolve(strict=True)
    guard.need(fixture.is_relative_to(ROOT / 'AssetRecovery') and fixture.name.startswith('OriginalShaderCollectionFixture-') and project == fixture / 'Project'
               and plan['schema'] == 'prepared-original179-Shader-native-import-build/v1' and plan['cap_bytes'] == CAP, 'Exact isolated fixture layout/cap required')
    for row in [plan[key] for key in ('runner', 'guard', 'launcher', 'editor', 'cli', 'compiler', 'config')] + plan['inputs'] + plan['read_only_sources']:
        guard.checked(row)
    for check in plan['compile_checks']:
        for row in [check['source'], check['response']] + check['additional_sources'] + check['references']:
            guard.checked(row)
    guard.need(not (project / 'Library').exists(), 'Never-launched collection fixture required')
    guard.safety.assert_editor_closed()
    return plan, project


def run(path, plan, project):
    out = path.parent / ('Run-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'guarded-original179-Shader-native-import-build/v1', 'status': 'starting', 'plan': pin(path), 'phases': [],
              'Main_modified': False, 'original_game_code_executed': False, 'player_launched': False}
    try:
        guard.compile_sources(plan, project, out, report)
        player = out / 'Player/OriginalShaderCollectionDiagnostic.exe'
        player.parent.mkdir()
        result, log = out / 'build-report.json', out / 'Editor.log'
        extra = shlex.join(['-disable-assembly-updater', '-job-worker-count', '1', '-shaderBuildReport', result.as_posix(), '-shaderBuildConfig', Path(plan['config']['path']).as_posix()])
        command = [guard.CLI.as_posix(), 'build', project.as_posix(), '--target', 'StandaloneWindows64', '--execute-method', 'BuildOriginalShaderCollectionFixture.Run',
                   '--output-path', player.as_posix(), '--editor-path', guard.EDITOR.as_posix(), '--args', extra, '--timeout', '360', '--allow-dirty-build',
                   '--no-tail', '--no-accelerator', '--log-file', log.as_posix(), '--provenance-path', (out / 'provenance.json').as_posix(), '--format', 'json']
        try:
            guard.bounded(command, project, out, 'original179-native-import-and-build', CAP, 360, report)
        finally:
            if result.is_file():
                report['build'] = {'report': pin(result), 'result': json.loads(result.read_bytes())}
            if log.is_file():
                text = log.read_text(encoding='utf-8', errors='replace')
                report['full_editor_log'] = pin(log)
                report['partial_constant_buffer_full_log_count'] = text.count('Partial constant buffer not found.')
                report['full_log_failure_lines'] = [line[:1024] for line in text.splitlines() if re.search(r'Partial constant buffer not found\.|error CS\d+|Shader error in|ERROR: Shader|Failed to find expected binary shader data|is corrupted|Position out of bounds|Fatal error|Aborting batchmode', line, re.I)][:64]
            guard.save(out, report)
        built = report['build']['result']
        guard.need(built['status'] == 'Succeeded' and built['total_errors'] == built['partial_constant_buffer_messages'] == 0 and built['shader_count'] == 179
                   and built['input_assets_and_metas_unchanged'] and built['required_project_dependency_closure_verified'] and player.is_file(), 'Actual original179 import/build gate failed')
        guard.need(report['partial_constant_buffer_full_log_count'] == 0 and not report['full_log_failure_lines'], 'Whole log must have zero shader/compiler/native import errors')
        for row in plan['read_only_sources'] + [row for row in plan['inputs'] if not Path(row['path']).is_relative_to(project / 'ProjectSettings')]:
            guard.checked(row)
        report['diagnostic_player'] = pin(player)
        report['status'] = 'original179_Shader_import_dependency_and_Windows_build_verified_program_retention_UNPROVEN'
    except BaseException as error:
        report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        report['finished_utc'] = dt.datetime.now(dt.timezone.utc).isoformat()
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'report': pin(out / 'run-report.json'), 'error': report.get('error')}), flush=True)
    return 0 if report['status'].startswith('original179_Shader_import_') else 1


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--fixture', type=Path)
    parser.add_argument('--plan-sha256')
    parser.add_argument('--run', action='store_true')
    parser.add_argument('--manifest', type=Path)
    parser.add_argument('--manifest-sha256')
    parser.add_argument('--wrappers', type=Path)
    parser.add_argument('--wrappers-sha256')
    args = parser.parse_args()
    if args.fixture:
        path = (args.fixture / 'plan.json').resolve(strict=True)
        plan, project = verify(path, args.plan_sha256)
    else:
        guard.need(not args.run and all((args.manifest, args.manifest_sha256, args.wrappers, args.wrappers_sha256)), 'Prepare explicit pinned179 inputs before launch')
        path = prepare(args)
        plan, project = verify(path, guard.sha(path))
    if args.run:
        return run(path, plan, project)
    print(json.dumps({'status': 'prepared_verified_no_child_started', 'plan': pin(path), 'cap_bytes': CAP, 'Main_modified': False}))
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
