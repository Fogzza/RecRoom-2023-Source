"""Prepare an isolated matching-Unity define observation; never launch a child."""
from pathlib import Path
import datetime as dt
import hashlib
import json
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
EDITOR = WS / 'Tools/Editors/2020.3.33f1/Editor/Unity.exe'
CLI = Path('C:/Users/andre/AppData/Local/Unity/bin/unity.exe')


def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()


def row(path):
    path = Path(path).resolve(strict=True)
    return {'path': str(path), 'sha256': sha(path), 'bytes': path.stat().st_size}


def main():
    stamp = dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]
    fixture = ROOT / 'AssetRecovery' / ('WindowsDevelopmentDefineProbe-' + stamp)
    fixture.mkdir()
    project = fixture / 'Project'
    project.mkdir()
    inputs, sources = [], []

    def write(relative, data):
        path = project / relative
        path.parent.mkdir(parents=True, exist_ok=True)
        with path.open('xb') as stream:
            stream.write(data.encode('utf-8') if isinstance(data, str) else data)
        inputs.append(row(path))
        return path

    def copy(source, relative):
        pinned = row(source)
        target = write(relative, Path(source).read_bytes())
        if sha(target) != pinned['sha256'] or sha(source) != pinned['sha256']:
            raise ValueError('Read-only source changed during copy')
        sources.append(pinned)
        return target

    observer = copy(HERE / 'WindowsDevelopmentDefineProbe.cs', 'Assets/Editor/WindowsDevelopmentDefineProbe.cs')
    recorder = copy(HERE / 'WindowsDevelopmentDefineRecorder.cs', 'Assets/Editor/DefineRecorder/WindowsDevelopmentDefineRecorder.cs')
    write('Assets/Editor/DefineRecorder/Unity.RR23.WindowsDevelopmentDefineProbe.CodeGen.asmdef', json.dumps({
        'name': 'Unity.RR23.WindowsDevelopmentDefineProbe.CodeGen', 'references': [],
        'includePlatforms': ['Editor'], 'overrideReferences': True,
        'precompiledReferences': [], 'autoReferenced': False}, indent=2) + '\n')
    write('Assets/DefineWitness/WindowsDevelopmentDefineWitness.cs',
          '// Isolated compilation witness; no runtime callbacks or game code.\npublic static class WindowsDevelopmentDefineWitness { public const string Purpose = "Unity supplied define observation"; }\n')
    write('Assets/DefineWitness/RR23.WindowsDevelopment.DefineWitness.asmdef', json.dumps({
        'name': 'RR23.WindowsDevelopment.DefineWitness', 'references': [], 'autoReferenced': True,
        'noEngineReferences': True}, indent=2) + '\n')
    write('ProjectSettings/ProjectVersion.txt', 'm_EditorVersion: 2020.3.33f1\nm_EditorVersionWithRevision: 2020.3.33f1 (915a7af8b0d5)\n')
    # Preserve the game's exact API compatibility configuration/default. No game
    # assemblies, scene, prefab, input, SDK, resource, or graphics file is copied.
    copy(WS / 'RR23/ProjectSettings/ProjectSettings.asset', 'ProjectSettings/ProjectSettings.asset')
    write('Packages/manifest.json', '{"dependencies":{}}\n')
    editor = EDITOR.parent
    framework = editor / 'Data/MonoBleedingEdge/lib/mono/4.7.1-api'
    common = [framework / 'mscorlib.dll', framework / 'System.dll', framework / 'System.Core.dll']
    groups = [
        ('observer', observer, common + [editor / 'Data/Managed/UnityEditor.dll',
         editor / 'Data/Managed/UnityEngine/UnityEngine.dll',
         editor / 'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',
         editor / 'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll']),
        ('recorder', recorder, common + [editor / 'Data/Managed/Unity.CompilationPipeline.Common.dll'])]
    compile_checks = []
    for name, source, references in groups:
        rsp = fixture / (name + '.rsp')
        rsp.write_text('\n'.join(['/nologo', '/nostdlib+', '/target:library', '/langversion:8'] +
                       ['/reference:"' + str(path) + '"' for path in references] + ['"' + str(source) + '"']) + '\n', encoding='utf-8')
        compile_checks.append({'name': name, 'source': row(source), 'response': row(rsp),
                               'references': [row(path) for path in references]})
    helper = HERE / 'owned_suspended_launch.py'
    expected_helper = '3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
    if sha(helper) != expected_helper:
        raise ValueError('Reviewed assign-before-resume helper differs')
    plan = {
        'schema': 'prepared-unity2020-windows64-development-defines/v1',
        'status': 'prepared_not_compiled_or_launched', 'fixture': str(fixture), 'project': str(project),
        'editor': row(EDITOR), 'cli': row(CLI), 'compiler': row(editor / 'Data/Tools/Roslyn/csc.exe'),
        'runner': row(HERE / 'run_windows_development_define_probe.py'), 'launcher': row(helper),
        'preparer': row(Path(__file__)), 'inputs': inputs, 'read_only_sources': sources,
        'compile_checks': compile_checks,
        'primary_api_documentation': [row(editor / 'Data/Managed/UnityEditor.xml')],
        'target': 'StandaloneWindows64', 'backend': 'Mono2x',
        'build_options': ['Development', 'StrictMode'], 'custom_define_symbols': [],
        'maximum_owned_job_bytes': 1024**3, 'compile_owned_job_bytes': 256 * 1024**2,
        'minimum_system_commit_reserve_bytes': int(1.5 * 1024**3), 'maximum_editor_seconds': 300,
        'source_game_assemblies': 0, 'source_game_scenes_or_prefabs': 0, 'SDKs': 0,
        'metadata_mutated': False, 'Main_modified': False, 'Editor_launched': False,
        'player_launched': False,
        'evidence': ['Actual ICompiledAssembly.Defines supplied by the genuine Unity ILPP runner for the fixture witness.',
                     'CompilationPipeline.GetAssemblies(AssembliesType.Player).defines after selecting Windows64, Mono, Development.',
                     'Development|StrictMode BuildReport plus genuine empty fixture player output; player is never launched.'],
        'limitations': ['Fixture proves compiler scope only; it contains no game code and proves no game behavior.',
                        'API compatibility configuration is copied byte-for-byte from RR23, without reading or modifying its assets.',
                        'Preparation and default review do not launch a compiler, CLI, Editor, SDK, player, or owned job.']}
    plan_path = fixture / 'plan.json'
    plan_path.write_text(json.dumps(plan, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'status': plan['status'], 'plan': str(plan_path), 'plan_sha256': sha(plan_path),
                      'review_command': ['python', str(HERE / 'run_windows_development_define_probe.py'), '--fixture', str(fixture)],
                      'future_compile_switch': '--compile-only', 'future_build_switch': '--run'}))


if __name__ == '__main__':
    main()
