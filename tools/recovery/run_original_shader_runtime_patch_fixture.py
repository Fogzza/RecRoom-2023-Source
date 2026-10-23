"""Build a tiny new shader-only player; compare unpatched and exact Release patch.

Review is the default. --run builds/executes only the fresh isolated fixture.
This is not a playable Rec Room build and never writes RR23 or the backend.
"""
from pathlib import Path
import argparse
import datetime as dt
import json
import os
import re
import shlex
import shutil
import uuid

import run_windows_development_define_probe as guard
from patch_isolated_player_shader import patched, RELEASE_SHA, NAME
from probe_original_shader_sources import native_objects
from shader_program_data import model_program, program_facts, lz4

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
BASE = ROOT / 'AssetRecovery/OriginalShaderWindowsBuildFixture-Mixed-20261022T214413Z-51ccf456'
BASE_SHA = 'ff8427db7cdd28c60bab2b3e93d9d50c114f03fc58e7162ed798462a7f057b76'
PAYLOAD = ROOT / 'AssetRecovery/OriginalShaderEditorConversion-20261022T212623Z-fde1a98d/OriginalReleaseShader.bin'
need, sha = guard.need, guard.sha


def pin(path):
    return {'path': str(path.resolve()), 'sha256': sha(path), 'bytes': path.stat().st_size}


def prepare():
    need(sha(BASE / 'plan.json') == BASE_SHA, 'Frozen Mixed shader build evidence changed')
    base = json.loads((BASE / 'plan.json').read_bytes())
    need(sha(PAYLOAD) == RELEASE_SHA, 'Exact original Release payload changed')
    fixture = ROOT / 'AssetRecovery' / ('OriginalShaderRuntimePatchFixture-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    fixture.mkdir()
    project = fixture / 'Project'
    sources, inputs = [], []

    def write(relative, data):
        path = project / relative
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_bytes(data.encode() if isinstance(data, str) else data)
        inputs.append(pin(path))
        return path

    for record in base['inputs']:
        source = Path(record['path'])
        relative = source.relative_to(Path(base['project']))
        if relative.as_posix() == 'ProjectSettings/ProjectSettings.asset':
            # The previous Editor updated its own settings after that test.
            # Reuse only the exact original source hash, never the modified copy.
            source = WS / 'RR23' / relative
            guard.checked(dict(record, path=str(source)))
        else:
            guard.checked(record)
        write(relative, source.read_bytes())
        sources.append(pin(source))
    runtime = HERE / 'OriginalShaderRuntimeProbe.cs'
    need(sha(runtime) == '25b558ca00b10fe774c8c692825fd220ea8cb0f96ceafbbe032957597df1937c', 'Reviewed diagnostic runtime source changed')
    # Install built-in modules before exposing the runtime assembly to Unity's
    # compiler. A player compile cannot reference disabled built-in modules.
    runtime_target = fixture / 'StagedRuntime/OriginalShaderRuntimeProbe.cs'
    runtime_target.parent.mkdir()
    runtime_target.write_bytes(runtime.read_bytes())
    installer = HERE / 'ShaderProbeModuleInstaller.cs'
    installer_target = write('Assets/Editor/ShaderProbeModuleInstaller.cs', installer.read_bytes())
    sources += [pin(runtime), pin(PAYLOAD), pin(installer)]
    control = '''Shader "SolarNet/Diagnostic/Green" { SubShader { Pass { ZTest Always Cull Off ZWrite Off
    CGPROGRAM
    #pragma vertex vert_img
    #pragma fragment frag
    #include "UnityCG.cginc"
    fixed4 frag(v2f_img i) : SV_Target { return fixed4(0,1,0,1); }
    ENDCG
    } } }
'''
    write('Assets/Resources/ShaderProbeControl.shader', control)
    config = fixture / 'expected-shaders.json'
    config_data = json.loads(Path(base['expected_data']['path']).read_bytes())
    config_data['project'] = str(project)
    config.write_text(json.dumps(config_data, indent=2) + '\n', encoding='utf-8')
    references = list(base['compile_checks'][0]['references'])
    module = WS / 'Tools/Editors/2020.3.33f1/Editor/Data/Managed/UnityEngine/UnityEngine.AssetBundleModule.dll'
    references.append(pin(module))
    rsp = fixture / 'fixture.rsp'
    builder = project / 'Assets/Editor/BuildOriginalShaderPrograms.cs'
    rsp.write_text('\n'.join(['/nologo', '/nostdlib+', '/target:library', '/langversion:8'] +
                            ['/reference:"' + r['path'] + '"' for r in references] +
                            ['"' + str(builder) + '"', '"' + str(runtime_target) + '"']) + '\n', encoding='utf-8')
    install_references = references
    installer_rsp = fixture / 'installer.rsp'
    installer_rsp.write_text('\n'.join(['/nologo', '/nostdlib+', '/target:library', '/langversion:8'] +
                                      ['/reference:"' + r['path'] + '"' for r in install_references] +
                                      ['"' + str(installer_target) + '"']) + '\n', encoding='utf-8')
    plan = {'schema': 'prepared-original-shader-runtime-patch-fixture/v1', 'project': str(project), 'fixture': str(fixture),
            'runner': pin(Path(__file__)), 'patcher': pin(HERE / 'patch_isolated_player_shader.py'),
            'guard': pin(HERE / 'run_windows_development_define_probe.py'), 'launcher': pin(HERE / 'owned_suspended_launch.py'),
            'editor': base['editor'], 'cli': base['cli'], 'compiler': base['compiler'], 'dotnet': base['dotnet'],
            'reader': base['reader'], 'reader_pins': base['reader_pins'], 'inputs': inputs, 'read_only_sources': sources,
            'config': pin(config), 'payload': pin(PAYLOAD),
            'staged_runtime': pin(runtime_target),
            'compile_checks': [{'name': 'runtime-shader-probe', 'response': pin(rsp), 'source': pin(runtime_target), 'references': references},
                               {'name': 'builtin-module-installer', 'response': pin(installer_rsp), 'source': pin(installer_target), 'references': install_references}],
            'Main_modified': False, 'backend_modified': False, 'original_game_assemblies_included': 0,
            'limitations': ['One pointer-free original Shader only; other Shader dependency remapping not implemented.',
                            'The diagnostic executable does not contain login, rooms or game code.',
                            'A successful GPU probe would prove this shader route only.']}
    path = fixture / 'plan.json'
    path.write_text(json.dumps(plan, indent=2) + '\n', encoding='utf-8')
    return path


def observe_raw_shader(plan, project, out, report, raw, path_id, label):
    raw_path = out / (label + '.bin')
    raw_path.write_bytes(raw)
    target = out / (label + '-Model')
    env = dict(os.environ, DOTNET_PROCESSOR_COUNT='1', DOTNET_CLI_TELEMETRY_OPTOUT='1', DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1', DOTNET_NOLOGO='1')
    guard.bounded([plan['dotnet']['path'], plan['reader']['path'], str(raw_path), sha(raw_path), str(path_id), NAME, str(target)], project, out, label + '-read', 512 * 1024**2, 60, report, env=env)
    model = json.loads((target / 'report.json').read_bytes())
    need(model['status'] == 'parsed_entire_original_object' and model['consumed_bytes'] == model['total_bytes'] == len(raw), 'Entire native Shader readback required')
    program = model_program(model, raw)
    if label == 'unpatched-original':
        need(program['platforms'] == [4] and program['offsets'] == [[0]] and program['compressedLengths'] == [[5]] and program['decompressedLengths'] == [[4]]
             and program['blob'] == bytes.fromhex('4000000000') and lz4(program['blob'], 4) == bytes(4), 'Exact independently proven empty-program encoding required')
        facts = {'dxbc_chunks': 0, 'blob_bytes': 5, 'expanded_bytes': 4, 'exact_empty_program_encoding_verified': True}
    else:
        facts = program_facts(program)
    return {'raw': pin(raw_path), 'model': pin(target / 'report.json'), 'program': facts}


def launch_probe(plan, project, out, report, player, label, original):
    result_path = out / (label + '-runtime.json')
    command = [str(player), '-batchmode', '-force-d3d11', '-screen-width', '64', '-screen-height', '64', '-logFile', str(out / (label + '-Player.log')),
               '-shaderProbeMode', 'resources', '-shaderProbeOutput', str(result_path)]
    if original:
        command += ['-shaderProbeResource', 'OriginalNativeFallback', '-shaderProbePixelCheck', 'magenta']
    else:
        command += ['-shaderProbeResource', 'ShaderProbeControl', '-shaderProbeExpectedName', 'SolarNet/Diagnostic/Green', '-shaderProbePixelCheck', 'none']
    error = None
    try:
        guard.bounded(command, project, out, label + '-player', 1536 * 1024**2, 60, report)
    except RuntimeError as caught:
        error = str(caught)
    need(result_path.is_file(), 'Diagnostic player produced no structured result: ' + str(error))
    result = json.loads(result_path.read_bytes())
    log_path = out / (label + '-Player.log')
    log_text = log_path.read_text(encoding='utf-8', errors='replace')
    error_lines = [line[:1024] for line in log_text.splitlines() if re.search(r'Partial constant buffer not found\.|Shader error in|ERROR: Shader|ShaderUnsupported|Failed to find expected binary shader data', line, re.I)]
    report[label] = {'report': pin(result_path), 'result': result, 'process_failure': error, 'full_player_log': pin(log_path), 'full_log_shader_diagnostics': error_lines[:64]}
    guard.save(out, report)
    return result


def run(plan_path):
    fixture = plan_path.parent.resolve(strict=True)
    need(fixture.is_relative_to(ROOT / 'AssetRecovery') and fixture.name.startswith('OriginalShaderRuntimePatchFixture-'), 'Isolated runtime fixture only')
    plan = json.loads(plan_path.read_bytes())
    project = Path(plan['project']).resolve(strict=True)
    need(plan['schema'] == 'prepared-original-shader-runtime-patch-fixture/v1' and project == fixture / 'Project', 'Exact fixture plan')
    for row in [plan[k] for k in ('runner', 'patcher', 'guard', 'launcher', 'editor', 'cli', 'compiler', 'dotnet', 'reader', 'config', 'payload')] + plan['reader_pins'] + plan['inputs'] + plan['read_only_sources']:
        guard.checked(row)
    for check in plan['compile_checks']:
        for row in [check['source'], check['response']] + check['references']:
            guard.checked(row)
    need(not (project / 'Library').exists(), 'Fresh never-launched fixture required')
    out = fixture / ('Run-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'guarded-original-shader-runtime-patch-fixture/v1', 'status': 'starting', 'plan': pin(plan_path), 'phases': [],
              'Main_modified': False, 'backend_modified': False, 'gameplay_tested': False, 'original_game_assemblies_loaded': False}
    try:
        guard.compile_sources(plan, project, out, report)
        module_log = out / 'ModuleInstaller-Editor.log'
        install = [str(guard.EDITOR), '-batchmode', '-projectPath', str(project), '-executeMethod', 'ShaderProbeModuleInstaller.Run',
                   '-disable-assembly-updater', '-job-worker-count', '1', '-logFile', str(module_log)]
        guard.bounded(install, project, out, 'install-two-builtin-shader-probe-modules', 2 * 1024**3, 180, report)
        manifest = json.loads((project / 'Packages/manifest.json').read_bytes())
        need(manifest['dependencies'].get('com.unity.modules.assetbundle') == '1.0.0' and manifest['dependencies'].get('com.unity.modules.jsonserialize') == '1.0.0', 'Client API must resolve both exact built-in modules')
        runtime_path = project / 'Assets/Runtime/OriginalShaderRuntimeProbe.cs'
        runtime_path.parent.mkdir()
        shutil.copyfile(plan['staged_runtime']['path'], runtime_path)
        need(sha(runtime_path) == plan['staged_runtime']['sha256'], 'Exact reviewed runtime harness introduced only after module install')
        report['resolved_builtin_modules'] = {'manifest': pin(project / 'Packages/manifest.json'), 'runtime': pin(runtime_path)}
        player = out / 'Unpatched/OriginalShaderRuntimeDiagnostic.exe'
        player.parent.mkdir()
        built_path = out / 'build-report.json'
        log = out / 'Editor.log'
        extra = shlex.join(['-disable-assembly-updater', '-job-worker-count', '1', '-shaderBuildReport', str(built_path), '-shaderBuildConfig', plan['config']['path']])
        command = [str(guard.CLI), 'build', str(project), '--target', 'StandaloneWindows64', '--execute-method', 'BuildOriginalShaderPrograms.Run',
                   '--output-path', str(player), '--editor-path', str(guard.EDITOR), '--args', extra, '--timeout', '300', '--allow-dirty-build',
                   '--no-tail', '--no-accelerator', '--log-file', str(log), '--provenance-path', str(out / 'provenance.json'), '--format', 'json']
        guard.bounded(command, project, out, 'build-runtime-shader-fixture', 2 * 1024**3, 300, report)
        built = json.loads(built_path.read_bytes())
        report['build'] = {'report': pin(built_path), 'status': built['status'], 'errors': built['total_errors'], 'warnings': built['total_warnings'], 'partial_constant_buffer_messages': built['partial_constant_buffer_messages']}
        need(built['status'] == 'Succeeded' and built['total_errors'] == built['partial_constant_buffer_messages'] == 0 and built['input_bytes_unchanged'] and built['direct_original_binary_imported'], 'Original native fixture build gate')
        log_text = log.read_text(encoding='utf-8', errors='replace')
        need('Partial constant buffer not found.' not in log_text and not re.search(r'error CS\d+', log_text), 'No shader/compiler errors allowed')
        positive = launch_probe(plan, project, out, report, player, 'builtin-source-positive-control', False)
        need(report['builtin-source-positive-control']['process_failure'] is None and positive['status'] == 'exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed' and positive['center_pixel'] == {'r': 0, 'g': 255, 'b': 0, 'a': 255}, 'Same-player buildable-source GPU positive control must render green and exit successfully')
        negative = launch_probe(plan, project, out, report, player, 'unpatched-original-negative-control', True)
        need(negative['status'] == 'failed_or_guard_refused' and negative['shader_name'] == NAME, 'Unpatched lost-program original must fail a runtime support/pass/render/log gate after exact identity was loaded')
        data = player.parent / (player.stem + '_Data')
        found = []
        import struct
        needle = struct.pack('<i', len(NAME.encode())) + NAME.encode()
        for container in sorted(data.glob('*.assets')):
            table = native_objects(container)
            for entry in table['shader_objects']:
                need(entry['byte_size'] <= 8 * 1024**2, 'Bounded Shader discovery')
                with container.open('rb') as stream:
                    stream.seek(entry['byte_offset'])
                    raw = stream.read(entry['byte_size'])
                if needle in raw:
                    found.append((container, entry, raw))
        need(len(found) == 1, 'Exactly one original fallback in built player')
        container, obj, raw = found[0]
        before = observe_raw_shader(plan, project, out, report, raw, obj['path_id'], 'unpatched-original')
        need(before['program']['dxbc_chunks'] == 0, 'Confirm actual unpatched GPU program loss')
        patched_player_dir = out / 'Patched'
        patched_player_dir.mkdir()
        for source in player.parent.rglob('*'):
            relative = source.relative_to(player.parent)
            target = patched_player_dir / relative
            if source.is_dir():
                target.mkdir(exist_ok=True)
            elif source != container:
                shutil.copyfile(source, target)
                need(sha(source) == sha(target), 'Every cloned player file must match')
        original_container = container.read_bytes()
        output, proof = patched(original_container, int(obj['path_id']), PAYLOAD.read_bytes(), RELEASE_SHA, before['raw']['sha256'])
        output_container = patched_player_dir / container.relative_to(player.parent)
        output_container.write_bytes(output)
        need(container.read_bytes() == original_container and output_container.read_bytes() == output, 'Original remains read-only; patched clone exact')
        report['patch'] = {'source_container': pin(container), 'output_container': pin(output_container), 'proof': proof}
        after = observe_raw_shader(plan, project, out, report, PAYLOAD.read_bytes(), obj['path_id'], 'patched-original')
        need(after['program']['dxbc_chunks'] == 4, 'All four exact original DXBC chunks must be restored')
        report['shader_program_before'] = before
        report['shader_program_after'] = after
        patched_player = patched_player_dir / player.name
        actual = launch_probe(plan, project, out, report, patched_player, 'patched-original-runtime', True)
        need(report['patched-original-runtime']['process_failure'] is None and not report['patched-original-runtime']['full_log_shader_diagnostics'] and actual['status'] == 'exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed' and actual['expected_magenta_check_passed'] and actual['partial_constant_buffer_messages'] == 0, 'Exact original Shader must be supported, set its pass and render explicit magenta on D3D11, exit successfully and have no errors anywhere in full Player.log')
        report['status'] = 'exact_original_release_shader_patch_passed_D3D11_runtime_positive_and_negative_controls'
    except BaseException as error:
        report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        report['finished_utc'] = dt.datetime.now(dt.timezone.utc).isoformat()
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'report': pin(out / 'run-report.json'), 'error': report.get('error')}), flush=True)
    return 0 if report['status'].startswith('exact_original_release_shader_patch_passed') else 1


def main():
    p = argparse.ArgumentParser(description=__doc__)
    p.add_argument('--fixture', type=Path)
    p.add_argument('--run', action='store_true')
    args = p.parse_args()
    if args.fixture:
        need(args.run, 'Existing fixture only accepted with --run')
        plan = args.fixture / 'plan.json'
    else:
        plan = prepare()
        print(json.dumps({'status': 'prepared_new_runtime_patch_diagnostic', 'plan': pin(plan), 'Editor_launched': False, 'player_launched': False}), flush=True)
    return run(plan) if args.run else 0


if __name__ == '__main__':
    raise SystemExit(main())
