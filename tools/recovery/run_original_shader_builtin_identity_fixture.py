"""Prepare/review seven original Shaders and four builtin Material witnesses.

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
import ctypes
import run_windows_development_define_probe as guard

HERE = Path(__file__).resolve().parent
ROOT = HERE.parents[2] / 'Recovery/RecRoom-2023-04-18'
TEMPLATE = ROOT / 'AssetRecovery/OriginalAGDependencyFixture-20261023T030326Z-a1848347'
TEMPLATE_SHA = '1012a5935462ac9034da85aa0b11b212488d0df03440570174a438db1ca54549'
CAP = 2 * 1024**3
sha = guard.sha
SELECTED = (
    'dbe0ca40b3618e44e9ef2664c6daae98', '249cb435a09f39e4e8f6de7901b294b4',
    '1ab811d499b5a8e48bfee808ef436fab', 'd2a5536c48f6e914f900eb13ea2f4d68',
    'f7efab54069bc444295f491f1ddf5b51', 'e8b204ae22658f64a88cf88172cef9c7',
    '7eda6ccbad6ba14488e843023e0d8dfa')
MAGIC = '0000000000000000f000000000000000'
BUILTINS = {6, 7, 46, 10490}
MAX_WRAPPER_BYTES = 3 * 1024**2
ALPHA_CLIP = '988a943d64eaf3d4985396b2fe8febf6'


def select_inputs(manifest, wrappers, manifest_sha, include_alpha_clip=False):
    selected_guids = SELECTED + ((ALPHA_CLIP,) if include_alpha_clip else ())
    guard.need(manifest['schema'] == 'resolved-original-Shader-Editor-collection/v1'
               and len(manifest['shaders']) == 179, 'Full canonical179 source authority required')
    guard.need(wrappers['schema'] == 'original-Shader-Editor-wrapper-collection/v1'
               and wrappers['status'] == 'all_mapped_original_Shader_Editor_wrappers_verified_native_import_unproven'
               and wrappers['manifest']['sha256'] == manifest_sha
               and wrappers['count'] == len(wrappers['shaders']) == 179, 'Actual complete179 wrapper source required')
    originals = {r['guid']: r for r in manifest['shaders']}
    wrapped = {r['guid']: r for r in wrappers['shaders']}
    guard.need(len(originals) == len(wrapped) == 179 and set(originals) == set(wrapped), 'Unique exact source identity sets required')
    guard.need(set(selected_guids).issubset(originals), 'Every reviewed selected GUID must exist')
    output, builtin_ids = [], set()
    for guid in selected_guids:
        original, row = originals[guid], wrapped[guid]
        guard.need(row['name'] == original['name'] and row['meta']['sha256'] == original['meta']['sha256']
                   and row['expected_direct_shader_dependencies'] == original['expected_direct_shader_dependencies'], 'Exact original selected Shader identity/meta/dependencies required')
        for dep in row['expected_direct_shader_dependencies']:
            if dep['kind'] == 'project':
                guard.need(dep['guid'] in selected_guids and dep['local_file_id'] == 4800000, 'Selected project dependency closure must be complete')
            else:
                guard.need(dep['kind'] == 'builtin' and dep['guid'] == MAGIC
                           and dep['local_file_id'] in BUILTINS, 'Only the exact four builtin identities may occur')
                builtin_ids.add(dep['local_file_id'])
        output.append(row)
    guard.need(builtin_ids == BUILTINS and len(output) == len(selected_guids)
               and sum(r['asset']['bytes'] for r in output) <= (5 * 1024**2 if include_alpha_clip else MAX_WRAPPER_BYTES), 'Exact selected Shader / four builtin / bounded-size selection required')
    return originals, output


def query_final_job(job):
    info = guard.ExtendedJob()
    query = job.kernel.QueryInformationJobObject
    query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_uint32, ctypes.c_void_p]
    query.restype = ctypes.c_int
    if not query(job.handle, 9, ctypes.byref(info), ctypes.sizeof(info), None):
        raise ctypes.WinError(ctypes.get_last_error())
    return {'peak_job_bytes': int(info.peak_job), 'peak_process_bytes': int(info.peak_process),
            'available_commit_bytes': guard.memory().available_commit, 'QueryInformationJobObject_class': 9,
            'captured_immediately_before_owned_job_close': True}


class FinalTelemetryJob:
    """Forward all job operations; real close always runs exactly as requested."""
    def __init__(self, job, phase, query=query_final_job):
        self._job, self._phase, self._query = job, phase, query
    def __getattr__(self, name):
        return getattr(self._job, name)
    def close(self):
        try:
            try:
                self._phase()['final_job_telemetry_before_close'] = self._query(self._job)
            except Exception as error:
                self._phase()['final_job_telemetry_before_close'] = {'query_failed': type(error).__name__,
                    'captured_immediately_before_owned_job_close': False}
        finally:
            self._job.close()


def telemetry_factory(original, report, query=query_final_job):
    def make_job(cap):
        return FinalTelemetryJob(original(cap), lambda: report['phases'][-1], query)
    return make_job


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
    by_guid, selected = select_inputs(manifest, wrappers, args.manifest_sha256, args.include_alpha_clip)
    out = ROOT / 'AssetRecovery' / ('OriginalShaderBuiltinIdentityFixture-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
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
    builder = copy(HERE / 'BuildOriginalShaderBuiltinIdentityFixture.cs', 'Assets/Editor/BuildOriginalShaderBuiltinIdentityFixture.cs', guard.sha(HERE / 'BuildOriginalShaderBuiltinIdentityFixture.cs'))
    capture = copy(HERE / 'ShaderPackedBuildReportCapture.cs', 'Assets/Editor/ShaderPackedBuildReportCapture.cs', guard.sha(HERE / 'ShaderPackedBuildReportCapture.cs'))
    shaders = []
    for row in selected:
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
    guard.need(count == 1 and b'  m_CustomRenderPipeline: {fileID: 0}' in graphics, 'Exact seven Shader keep-list and null diagnostic pipeline required')
    graphics_path = write('ProjectSettings/GraphicsSettings.asset', graphics)
    config = out / 'config.json'
    save(config, {'project': str(project), 'graphics_sha256': guard.sha(graphics_path), 'shaders': shaders, 'include_alpha_clip': args.include_alpha_clip})
    refs = base['compile_checks'][0]['references']
    response = out / 'fixture.rsp'
    response.write_text('\n'.join(['/nologo', '/nostdlib+', '/target:library', '/langversion:8'] + ['/reference:"' + row['path'] + '"' for row in refs]
                                  + ['"' + str(source) + '"' for source in (builder, capture, project / 'Assets/Runtime/OriginalShaderRuntimeProbe.cs')]) + '\n', encoding='utf-8')
    plan = {'schema': 'prepared-selected-original-Shader-builtin-Material-import-build/v1', 'status': 'prepared_no_child_started', 'fixture': str(out), 'project': str(project),
            'runner': pin(Path(__file__)), 'guard': pin(HERE / 'run_windows_development_define_probe.py'), 'launcher': pin(HERE / 'owned_suspended_launch.py'),
            'editor': base['editor'], 'cli': base['cli'], 'compiler': base['compiler'], 'config': pin(config), 'inputs': inputs, 'read_only_sources': sources,
            'compile_checks': [{'name': 'selected-Shader-builder-capture-runtime', 'source': pin(builder), 'additional_sources': [pin(capture), pin(project / 'Assets/Runtime/OriginalShaderRuntimeProbe.cs')], 'response': pin(response), 'references': refs}],
            'Main_modified': False, 'original_game_code_executed': False, 'cap_bytes': CAP, 'reserve_bytes': guard.RESERVE,
            'selected_GUIDs': [r['guid'] for r in selected], 'required_builtin_local_ids': sorted(BUILTINS), 'shader_count': len(selected),
            'include_alpha_clip': args.include_alpha_clip, 'final_owned_job_telemetry_enabled': True,
            'native_wrapper_bytes': sum(r['asset']['bytes'] for r in selected),
            'source_authority_shader_count': 179, 'player_launch_authorized_by_this_runner': False,
            'protected_existing_processes': [{'pid': 3040, 'action': 'no termination or modification; existing shared process-safety classification retained'}],
            'process_safety': pin(Path(guard.safety.__file__)),
            'limitations': ['Original asset import, dependency witnesses and actual packed Shader API capture only.', 'No cooked-program retention, gameplay, actual URP renderer or visual fidelity claim.']}
    path = out / 'plan.json'
    save(path, plan)
    return path


def verify(path, expected, launch=False):
    guard.need(guard.sha(path) == expected, 'Explicit reviewed plan hash required')
    plan = json.loads(path.read_bytes())
    fixture, project = path.parent.resolve(strict=True), Path(plan['project']).resolve(strict=True)
    guard.need(fixture.is_relative_to(ROOT / 'AssetRecovery') and fixture.name.startswith('OriginalShaderBuiltinIdentityFixture-') and project == fixture / 'Project'
               and plan['schema'] == 'prepared-selected-original-Shader-builtin-Material-import-build/v1' and plan['cap_bytes'] == CAP
               and type(plan['include_alpha_clip']) is bool
               and plan['reserve_bytes'] == guard.RESERVE
               and plan['selected_GUIDs'] == list(SELECTED + ((ALPHA_CLIP,) if plan['include_alpha_clip'] else ()))
               and plan['required_builtin_local_ids'] == sorted(BUILTINS)
               and plan['shader_count'] == (8 if plan['include_alpha_clip'] else 7)
               and plan['final_owned_job_telemetry_enabled'], 'Exact isolated fixture layout/cap/identity set required')
    guard.need(Path(plan['editor']['path']) == guard.EDITOR and Path(plan['cli']['path']) == guard.CLI, 'Matching fixed native tool paths required')
    for row in [plan[key] for key in ('runner', 'guard', 'launcher', 'editor', 'cli', 'compiler', 'config', 'process_safety')] + plan['inputs'] + plan['read_only_sources']:
        guard.checked(row)
    for check in plan['compile_checks']:
        for row in [check['source'], check['response']] + check['additional_sources'] + check['references']:
            guard.checked(row)
    guard.need(not (project / 'Library').exists(), 'Never-launched collection fixture required')
    expected_files = {Path(r['path']).resolve() for r in plan['inputs']}
    guard.need({p.resolve() for p in project.rglob('*') if p.is_file()} == expected_files, 'Initial fixture inventory must be exactly the pinned files')
    config = json.loads(Path(plan['config']['path']).read_bytes())
    guard.need(config['project'] == str(project) and [r['guid'] for r in config['shaders']] == plan['selected_GUIDs']
               and config['include_alpha_clip'] == plan['include_alpha_clip'], 'Exact selected config order/project required')
    if launch:
        guard.admission(project, CAP)
    return plan, project


def run(path, plan, project):
    out = path.parent / ('Run-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'guarded-selected-original-Shader-builtin-Material-import-build/v1', 'status': 'starting', 'plan': pin(path), 'phases': [],
              'shader_count': plan['shader_count'], 'include_alpha_clip': plan['include_alpha_clip'],
              'Main_modified': False, 'original_game_code_executed': False, 'player_launched': False}
    original_job_factory = guard.make_job
    guard.make_job = telemetry_factory(original_job_factory, report)
    try:
        guard.compile_sources(plan, project, out, report)
        player = out / 'Player/OriginalShaderBuiltinIdentityDiagnostic.exe'
        player.parent.mkdir()
        result, log = out / 'build-report.json', out / 'Editor.log'
        extra = shlex.join(['-disable-assembly-updater', '-job-worker-count', '1', '-shaderBuildReport', result.as_posix(), '-shaderBuildConfig', Path(plan['config']['path']).as_posix()])
        command = [guard.CLI.as_posix(), 'build', project.as_posix(), '--target', 'StandaloneWindows64', '--execute-method', 'BuildOriginalShaderBuiltinIdentityFixture.Run',
                   '--output-path', player.as_posix(), '--editor-path', guard.EDITOR.as_posix(), '--args', extra, '--timeout', '360', '--allow-dirty-build',
                   '--no-tail', '--no-accelerator', '--log-file', log.as_posix(), '--provenance-path', (out / 'provenance.json').as_posix(), '--format', 'json']
        try:
            guard.bounded(command, project, out, 'selected-original-Shader-native-import-and-build', CAP, 360, report)
        finally:
            if result.is_file():
                report['build'] = {'report': pin(result), 'result': json.loads(result.read_bytes())}
            if log.is_file():
                text = log.read_text(encoding='utf-8', errors='replace')
                report['full_editor_log'] = pin(log)
                report['partial_constant_buffer_full_log_count'] = text.count('Partial constant buffer not found.')
                report['full_log_failure_lines'] = [line[:1024] for line in text.splitlines() if re.search(r'Partial constant buffer not found\.|error CS\d+|Shader error in|ERROR: Shader|Failed to find expected binary shader data|is corrupted|Position out of bounds|Fatal error|Aborting batchmode|Could not allocate memory|Failed to allocate|Out of memory', line, re.I)][:64]
            guard.save(out, report)
        built = report['build']['result']
        guard.need(built['status'] == 'Succeeded' and built['total_errors'] == built['partial_constant_buffer_messages'] == 0 and built['shader_count'] == plan['shader_count']
                   and built['input_assets_and_metas_unchanged'] and built['required_project_dependency_closure_verified']
                   and built['four_builtin_material_witnesses_verified'] and built['serialization_mode'] == 'Mixed'
                   and built['backend'] == 'Mono2x' and built['target'] == 'StandaloneWindows64' and player.is_file(), 'Actual seven Shader/four Material import/build gate failed')
        guard.need(report['partial_constant_buffer_full_log_count'] == 0 and not report['full_log_failure_lines'], 'Whole log must have zero shader/compiler/native import errors')
        for row in plan['read_only_sources'] + [row for row in plan['inputs'] if not Path(row['path']).is_relative_to(project / 'ProjectSettings')]:
            guard.checked(row)
        report['diagnostic_player'] = pin(player)
        report['status'] = 'selected_original_Shader_import_dependency_and_Windows_build_verified_program_retention_UNPROVEN'
    except BaseException as error:
        report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        guard.make_job = original_job_factory
        report['finished_utc'] = dt.datetime.now(dt.timezone.utc).isoformat()
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'report': pin(out / 'run-report.json'), 'error': report.get('error')}), flush=True)
    return 0 if report['status'].startswith('selected_original_Shader_import_') else 1


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--fixture', type=Path)
    parser.add_argument('--plan-sha256')
    parser.add_argument('--run', action='store_true')
    parser.add_argument('--manifest', type=Path)
    parser.add_argument('--manifest-sha256')
    parser.add_argument('--wrappers', type=Path)
    parser.add_argument('--wrappers-sha256')
    parser.add_argument('--include-alpha-clip', action='store_true', help='Include only the exact eighth AlphaClip GUID in addition to the required seven')
    args = parser.parse_args()
    if args.fixture:
        path = (args.fixture / 'plan.json').resolve(strict=True)
        plan, project = verify(path, args.plan_sha256, launch=args.run)
    else:
        guard.need(not args.run and all((args.manifest, args.manifest_sha256, args.wrappers, args.wrappers_sha256)), 'Prepare explicit pinned source authority before launch')
        path = prepare(args)
        plan, project = verify(path, guard.sha(path))
    if args.run:
        return run(path, plan, project)
    admission = {'status': 'not_checked'}
    try:
        guard.admission(project, CAP)
        admission = {'status': 'passed', 'available_commit_bytes': guard.memory().available_commit, 'safety': guard.safety.assert_editor_closed()}
    except RuntimeError as error:
        admission = {'status': 'HOLD', 'reason': str(error)}
    print(json.dumps({'status': 'prepared_verified_no_child_started', 'plan': pin(path), 'cap_bytes': CAP,
                      'admission_read_only': admission, 'Main_modified': False,
                      'command': [str(Path('C:/Python314/python.exe')), '-B', str(Path(__file__).resolve()), '--fixture', str(path.parent), '--plan-sha256', guard.sha(path), '--run']}))
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
