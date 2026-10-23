"""Prepare/review the isolated AG + Fallback binary fixture; Root alone uses --run."""
from pathlib import Path
import argparse
import datetime as dt
import json
import re
import shlex
import struct
import uuid
import run_windows_development_define_probe as guard
from probe_original_shader_sources import native_objects, object_name

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
BASE = ROOT / 'AssetRecovery/OriginalShaderRuntimePatchFixture-20261023T024141Z-2a543430'
BASE_SHA = '86ca8fa0bfceac622b41c0cd05283b5c49c89cfe8f272d91306fbba993261667'
BASE_RECEIPT = BASE / 'Run-20261023T024141Z-06257a67/run-report.json'
BASE_RECEIPT_SHA = 'c78a2385429ac165141ebb577d7200362ae65782c70959b9baca5c7f676a60ab'
FALLBACK = ROOT / 'AssetRecovery/EditorShaderNativeInput-v2-20261022T212847Z-346d554d/OriginalFallbackError-EditorLayout-FileID4800000.asset'
FALLBACK_SHA = 'cce3dfdb4f05a060a8621eb6abac2a4c2b76d36c73cda060acc0177eb9a9828c'
AG_META = WS / 'RR23/Assets/Shader/AG_Standard-Opaque.asset.meta'
FALLBACK_META = WS / 'RR23/Assets/Shader/Hidden_Universal Render Pipeline_FallbackError.asset.meta'
AG_GUID = '90510347b31afb84fba058c6708c7f5c'
FALLBACK_GUID = 'd2a5536c48f6e914f900eb13ea2f4d68'
need, sha = guard.need, guard.sha


def pin(path):
    return {'path': str(path.resolve()), 'sha256': sha(path), 'bytes': path.stat().st_size}


def prepare(args):
    need(sha(BASE / 'plan.json') == BASE_SHA and sha(BASE_RECEIPT) == BASE_RECEIPT_SHA, 'Exact actual successful runtime template required')
    base = json.loads((BASE / 'plan.json').read_bytes())
    receipt = json.loads(BASE_RECEIPT.read_bytes())
    need(receipt['status'] == 'exact_original_release_shader_patch_passed_D3D11_runtime_positive_and_negative_controls', 'Actual successful runtime template required')
    ag = args.ag_asset.resolve(strict=True)
    proof = args.ag_proof.resolve(strict=True)
    need(ag.is_relative_to(ROOT / 'AssetRecovery') and proof.is_relative_to(ROOT / 'AssetRecovery'), 'Mapped native AG staging only, never Main')
    need(args.ag_sha == sha(ag) and args.ag_proof_sha == sha(proof), 'Explicit mapped native AG asset/proof pins required')
    proof_data = json.loads(proof.read_bytes())
    need(proof_data.get('schema') == 'original-AG-Editor-native-wrapper-with-proved-fallback-GUID/v1' and proof_data.get('status') == 'staged_pure_AG_Editor_wrapper_exact_typed_fallback_GUID_dependency_native_import_UNTESTED', 'Exact successful mapped AG wrapper proof required')
    need(proof_data['output']['sha256'] == sha(ag) and Path(proof_data['output']['path']).resolve() == ag, 'Proof must bind the entire AG binary')
    need(proof_data['fallback_Unity_GUID'] == FALLBACK_GUID and proof_data['AG_Unity_GUID'] == AG_GUID and proof_data['output']['typed_dependency'] == {'file_id': 1, 'path_id': 4800000}, 'Exact original Fallback external GUID/PPtr mapping required')
    need(proof_data['output']['class_ids'] == [48] and proof_data['output']['path_ids'] == [4800000] and proof_data['output']['object_count'] == 1 and proof_data['output']['script_type_count'] == proof_data['output']['ref_type_count'] == 0 and proof_data['output']['external_rows'] == [{'asset_path_hex': '', 'guid_hex': '2d5a35c6846f9e419f00be31aef2d486', 'type': 2, 'path_hex': ''}], 'Only genuine original Shader and proved GUID external row required')
    conversion_pins = [proof_data[k] for k in ('successful_generated_conversion', 'AG_conversion_report', 'AG_editor_payload', 'original_compiled_blob', 'genuine_GUID_proof', 'genuine_GUID_capture')]
    for record in conversion_pins: guard.checked(record)
    converted = json.loads(Path(proof_data['AG_conversion_report']['path']).read_bytes())
    need(converted['status'] == 'exact_except_name_and_authorized_typed_AG_PathID' and converted['entire_ParsedForm_equal'] is True and converted['all_five_original_program_fields_equal'] is True and converted['all_bytes_except_name_and_authorized_typed_PathID_equal'] is True and converted['external_FileIDs_unchanged'] is True and converted['authorized_PathID_bytes'] == 8, 'Complete original data preservation with only proved Name/PathID metadata changes required')
    need(sha(FALLBACK) == FALLBACK_SHA and ('guid: ' + AG_GUID) in AG_META.read_text() and ('guid: ' + FALLBACK_GUID) in FALLBACK_META.read_text(), 'Exact original two Shader/meta identities required')
    out = ROOT / 'AssetRecovery' / ('OriginalAGDependencyFixture-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    project = out / 'Project'
    inputs, sources = [], [pin(BASE / 'plan.json'), pin(BASE_RECEIPT), pin(ag), pin(proof), pin(FALLBACK), pin(AG_META), pin(FALLBACK_META)] + conversion_pins
    def write(relative, data):
        target = project / relative
        target.parent.mkdir(parents=True, exist_ok=True)
        target.write_bytes(data.encode() if isinstance(data, str) else data)
        inputs.append(pin(target))
        return target
    def copy(source, relative, expected=None):
        if expected is not None: need(sha(source) == expected, 'Exact source copy pin required')
        before = pin(source)
        target = write(relative, source.read_bytes())
        need(sha(target) == sha(source) == before['sha256'], 'Read-only source copy race')
        sources.append(before)
        return target
    template = BASE / 'Project'
    for relative, expected in [
        ('Packages/manifest.json', '45afbf7c55a726bec12a48904c46aa3c894bc3a682a8532913fab0dad1512928'),
        ('Packages/packages-lock.json', 'eed77dce0df69ff1d2c2039fc4f31aededdac1de4b3be804b59a0f1fdf66f103'),
        ('ProjectSettings/EditorSettings.asset', '5954ba3422f9cb372b418d7b0dcff5d0cbc959fed0d00c0717b956c52fb89ad7')]:
        copy(template / relative, relative, expected)
    need(b'  m_SerializationMode: 0' in (project / 'ProjectSettings/EditorSettings.asset').read_bytes(), 'Mixed configured before initial import')
    settings_pin = next(r for r in base['inputs'] if r['path'].endswith('ProjectSettings\\ProjectSettings.asset'))
    copy(WS / 'RR23/ProjectSettings/ProjectSettings.asset', 'ProjectSettings/ProjectSettings.asset', settings_pin['sha256'])
    copy(template / 'ProjectSettings/ProjectVersion.txt', 'ProjectSettings/ProjectVersion.txt')
    copy(template / 'Assets/Resources/ShaderProbeControl.shader', 'Assets/Resources/ShaderProbeControl.shader')
    copy(HERE / 'OriginalShaderRuntimeProbeWithPipelineTag.cs', 'Assets/Runtime/OriginalShaderRuntimeProbe.cs', '4aedcbce38d4e503efd19b81a203417aabfbaa3fceba9a758e75f4951ab6b144')
    guard_source = WS / 'RR23/Assets/Editor/AssetRipperPatches/AvoidSavingYamlShaders.cs'
    copy(guard_source, 'Assets/Editor/AvoidSavingYamlShaders.cs')
    copy(guard_source.with_suffix('.cs.meta'), 'Assets/Editor/AvoidSavingYamlShaders.cs.meta')
    builder = copy(HERE / 'BuildOriginalAGDependencyFixture.cs', 'Assets/Editor/BuildOriginalAGDependencyFixture.cs')
    shaders = []
    for source, meta, relative, guid, name in [
        (ag, AG_META, 'Assets/Resources/OriginalAG.asset', AG_GUID, 'AG/Standard-Opaque'),
        (FALLBACK, FALLBACK_META, 'Assets/Resources/OriginalNativeFallback.asset', FALLBACK_GUID, 'Hidden/Universal Render Pipeline/FallbackError')]:
        target = copy(source, relative)
        copy(meta, relative + '.meta')
        shaders.append({'path': relative, 'sha256': sha(target), 'meta_sha256': sha(meta), 'guid': guid, 'name': name})
    graphics_source = template / 'ProjectSettings/GraphicsSettings.asset'
    graphics = graphics_source.read_bytes()
    replacement = ('  m_AlwaysIncludedShaders:\n' + ''.join('  - {fileID: 4800000, guid: ' + s['guid'] + ', type: 2}\n' for s in shaders)).encode()
    graphics, count = re.subn(rb'(?ms)^  m_AlwaysIncludedShaders:\r?\n.*?(?=^  [A-Za-z_])', replacement, graphics)
    need(count == 1 and b'  m_CustomRenderPipeline: {fileID: 0}' in graphics, 'Exact two Shader keep list and null pipeline fixture required')
    sources.append(pin(graphics_source))
    graphics_path = write('ProjectSettings/GraphicsSettings.asset', graphics)
    config = out / 'config.json'
    config.write_text(json.dumps({'project': str(project), 'graphics_sha256': sha(graphics_path), 'shaders': shaders}, indent=2) + '\n', encoding='utf-8')
    references = base['compile_checks'][0]['references']
    runtime = project / 'Assets/Runtime/OriginalShaderRuntimeProbe.cs'
    response = out / 'fixture.rsp'
    response.write_text('\n'.join(['/nologo', '/nostdlib+', '/target:library', '/langversion:8'] + ['/reference:"' + r['path'] + '"' for r in references] + ['"' + str(builder) + '"', '"' + str(runtime) + '"']) + '\n', encoding='utf-8')
    plan = {'schema': 'prepared-original-AG-Fallback-dependency-fixture/v1', 'status': 'prepared_native_dependency_build_and_pipeline_tag_probe_unproven', 'fixture': str(out), 'project': str(project),
            'runner': pin(Path(__file__)), 'guard': pin(HERE / 'run_windows_development_define_probe.py'), 'launcher': pin(HERE / 'owned_suspended_launch.py'),
            'editor': base['editor'], 'cli': base['cli'], 'compiler': base['compiler'], 'config': pin(config), 'inputs': inputs, 'read_only_sources': sources,
            'compile_checks': [{'name': 'original-AG-dependency-builder-and-runtime', 'source': pin(builder), 'response': pin(response), 'references': references}],
            'Main_modified': False, 'original_game_assemblies': 0, 'player_launch_authorized_by_this_runner': False, 'runtime_pipeline_tag_probe_available': True,
            'limitations': ['Native AG dependency import and zero-CB player build only; cooked output programs require independent postbuild restoration.', 'Both original AG subshaders target UniversalPipeline; no AG visual correctness or supported active subshader is claimed in this Builtin fixture.']}
    path = out / 'plan.json'
    path.write_text(json.dumps(plan, indent=2) + '\n', encoding='utf-8')
    return path


def verify(plan_path):
    fixture = plan_path.parent.resolve(strict=True)
    need(fixture.is_relative_to(ROOT / 'AssetRecovery') and fixture.name.startswith('OriginalAGDependencyFixture-'), 'Fresh isolated AG diagnostic folder required')
    plan = json.loads(plan_path.read_bytes())
    project = Path(plan['project']).resolve(strict=True)
    need(plan['schema'] == 'prepared-original-AG-Fallback-dependency-fixture/v1' and project == fixture / 'Project', 'Exact isolated project shape required')
    need(Path(plan['editor']['path']) == guard.EDITOR and Path(plan['cli']['path']) == guard.CLI, 'Exact matching native tools required')
    for row in [plan[k] for k in ('runner', 'guard', 'launcher', 'editor', 'cli', 'compiler', 'config')] + plan['inputs'] + plan['read_only_sources']:
        guard.checked(row)
    for check in plan['compile_checks']:
        for row in [check['source'], check['response']] + check['references']: guard.checked(row)
    need(not (project / 'Library').exists(), 'Never-launched fixture required')
    guard.safety.assert_editor_closed()
    return plan, project


def run(plan_path, plan, project):
    out = plan_path.parent / ('Run-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'guarded-original-AG-Fallback-native-dependency-build/v1', 'status': 'starting', 'plan': pin(plan_path), 'phases': [], 'Main_modified': False, 'player_launched': False, 'GPU_rendering_tested': False}
    try:
        guard.compile_sources(plan, project, out, report)
        player = out / 'Player/OriginalAGDependencyDiagnostic.exe'
        player.parent.mkdir()
        build_report = out / 'build-report.json'
        log = out / 'Editor.log'
        extra = shlex.join(['-disable-assembly-updater', '-job-worker-count', '1', '-shaderBuildReport', build_report.as_posix(), '-shaderBuildConfig', Path(plan['config']['path']).as_posix()])
        command = [guard.CLI.as_posix(), 'build', project.as_posix(), '--target', 'StandaloneWindows64', '--execute-method', 'BuildOriginalAGDependencyFixture.Run', '--output-path', player.as_posix(),
                   '--editor-path', guard.EDITOR.as_posix(), '--args', extra, '--timeout', '300', '--allow-dirty-build', '--no-tail', '--no-accelerator', '--log-file', log.as_posix(), '--provenance-path', (out / 'provenance.json').as_posix(), '--format', 'json']
        try: guard.bounded(command, project, out, 'AG-Fallback-native-import-and-Windows-build', 2 * 1024**3, 300, report)
        finally:
            if build_report.is_file(): report['build'] = {'report': pin(build_report), 'result': json.loads(build_report.read_bytes())}
            if log.is_file():
                text = log.read_text(encoding='utf-8', errors='replace')
                report['partial_constant_buffer_full_log_count'] = text.count('Partial constant buffer not found.')
                report['full_log_failure_lines'] = [line[:1024] for line in text.splitlines() if re.search(r'Partial constant buffer not found\.|error CS\d+|Shader error in|ERROR: Shader|Failed to find expected binary shader data|is corrupted|Position out of bounds|Fatal error|Aborting batchmode', line, re.I)][:64]
                report['full_editor_log'] = pin(log)
            guard.save(out, report)
        need(build_report.is_file() and player.is_file(), 'Actual BuildReport/player required')
        built = report['build']['result']
        need(built['status'] == 'Succeeded' and built['total_errors'] == built['partial_constant_buffer_messages'] == 0 and built['exact_AG_Fallback_dependency_verified'] and built['input_assets_and_metas_unchanged'] and built['serialization_mode'] == 'Mixed' and built['backend'] == 'Mono2x' and built['target'] == 'StandaloneWindows64', 'Exact native dependency/build gate failed')
        need(report['partial_constant_buffer_full_log_count'] == 0 and report['full_log_failure_lines'] == [], 'Whole Editor log must have zero CB/shader/compiler/native-import errors')
        for row in plan['read_only_sources'] + [r for r in plan['inputs'] if not Path(r['path']).is_relative_to(project / 'ProjectSettings')]: guard.checked(row)
        report['diagnostic_player'] = pin(player)
        expected = {'AG/Standard-Opaque', 'Hidden/Universal Render Pipeline/FallbackError'}
        found = {}
        data_dir = player.parent / (player.stem + '_Data')
        for container in sorted(data_dir.glob('*.assets')):
            table = native_objects(container)
            for obj in table['shader_objects']:
                name = object_name(container, obj, table['endian'])
                if name not in expected: continue
                need(name not in found and obj['byte_size'] <= 8 * 1024**2, 'Unique bounded exact leading native Shader identity required')
                with container.open('rb') as stream:
                    stream.seek(obj['byte_offset']); raw = stream.read(obj['byte_size'])
                rawpath = out / ('BuiltShader-' + str(len(found)) + '.bin')
                rawpath.write_bytes(raw)
                found[name] = {'container': pin(container), 'object': obj, 'raw': pin(rawpath), 'full_typed_read_and_program_retention_claimed': False}
        need(set(found) == expected, 'Both original Shader identities must be present in packaged native data')
        report['packaged_Shader_ranges_for_followup'] = found
        report['status'] = 'AG_Fallback_native_dependency_and_clean_Windows_build_verified_cooked_program_retention_not_claimed'
    except BaseException as error: report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        report['finished_utc'] = dt.datetime.now(dt.timezone.utc).isoformat()
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'receipt': pin(out / 'run-report.json'), 'error': report.get('error')}))
    return 0 if report['status'].startswith('AG_Fallback_native_dependency_and_clean') else 1


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--fixture', type=Path)
    parser.add_argument('--run', action='store_true')
    parser.add_argument('--ag-asset', type=Path)
    parser.add_argument('--ag-sha')
    parser.add_argument('--ag-proof', type=Path)
    parser.add_argument('--ag-proof-sha')
    args = parser.parse_args()
    if args.fixture:
        plan_path = args.fixture / 'plan.json'
    else:
        need(args.ag_asset and args.ag_sha and args.ag_proof and args.ag_proof_sha, 'Explicit independent mapped AG wrapper and proof pins required')
        plan_path = prepare(args)
    plan_path = plan_path.resolve(strict=True)
    plan, project = verify(plan_path)
    if args.run: return run(plan_path, plan, project)
    print(json.dumps({'status': 'prepared_verified_no_launch', 'plan': pin(plan_path), 'Editor_launched': False, 'compiler_launched': False, 'command': ['C:\\Python314\\python.exe', '-B', str(Path(__file__).resolve()), '--fixture', str(plan_path.parent), '--run']}))
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
