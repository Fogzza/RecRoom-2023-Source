"""Derive a fresh import-only Shader / four-native-Material identity fixture."""
from pathlib import Path
import hashlib
import json

HERE = Path(__file__).resolve().parent

def read(name, expected):
    data = (HERE / name).read_bytes()
    if hashlib.sha256(data).hexdigest() != expected:
        raise RuntimeError('reviewed_fixture_source_changed')
    return data.decode('utf-8').replace('\r\n', '\n')

def once(text, old, new):
    if text.count(old) != 1:
        raise RuntimeError('unique_fixture_derivation_anchor_required')
    return text.replace(old, new)

def save(name, text):
    target = HERE / name
    with target.open('x', encoding='utf-8', newline='\n') as stream:
        stream.write(text)
    data = target.read_bytes()
    return {'path': str(target), 'bytes': len(data), 'sha256': hashlib.sha256(data).hexdigest()}

def main():
    builder = read('BuildOriginalShaderBuiltinIdentityFixture.cs', '99afdb63efa0579d31330ecd50c0b61c8ece2d9d56e3f8ddd4bdd7a4fffcd24c')
    builder = builder.replace('BuildOriginalShaderBuiltinIdentityFixture', 'BuildBuiltinMaterialIdentityFixture')
    builder = builder.replace('OriginalShaderBuiltinIdentityFixture-', 'BuiltinMaterialIdentityFixture-')
    builder = builder.replace('OriginalShaderBuiltinIdentityDiagnostic', 'BuiltinMaterialIdentityDiagnostic')
    builder = builder.replace('Assets/Resources/OriginalShaders/', 'Assets/EditorImportOnly/OriginalShaders/')
    builder = once(builder, 'public bool Main_modified = false, original_game_code_executed = false, GPU_tested = false;',
                   'public bool Main_modified = false, original_game_code_executed = false, GPU_tested = false;\n        public bool original_shaders_import_only = true, imported_original_shaders_excluded_from_player;')
    builder = once(builder, 'Need(matches == 1, "Exactly one actual packed record per selected project Shader required");',
                   'Need(matches == 0, "Import-only original Shader must be excluded from the player");')
    builder = once(builder, 'VerifyPackedProjectShaders(config);', 'VerifyPackedProjectShaders(config);\n            result.imported_original_shaders_excluded_from_player = true;')
    runner = read('run_original_shader_builtin_identity_fixture.py', '1ba8406a60d8ad13daad819240f1717d8ade7bd5a50561b11222c024279a56db')
    runner = runner.replace('BuildOriginalShaderBuiltinIdentityFixture', 'BuildBuiltinMaterialIdentityFixture')
    runner = runner.replace('OriginalShaderBuiltinIdentityFixture-', 'BuiltinMaterialIdentityFixture-')
    runner = runner.replace('OriginalShaderBuiltinIdentityDiagnostic', 'BuiltinMaterialIdentityDiagnostic')
    runner = runner.replace('Assets/Resources/OriginalShaders/', 'Assets/EditorImportOnly/OriginalShaders/')
    runner = runner.replace('prepared-selected-original-Shader-builtin-Material-import-build/v1', 'prepared-import-only-original-Shader-builtin-Material-build/v1')
    runner = runner.replace('guarded-selected-original-Shader-builtin-Material-import-build/v1', 'guarded-import-only-original-Shader-builtin-Material-build/v1')
    runner = once(runner, "replacement = ('  m_AlwaysIncludedShaders:\\n' + ''.join('  - {fileID: 4800000, guid: ' + row['guid'] + ', type: 2}\\n' for row in shaders)).encode()",
                  "replacement = b'  m_AlwaysIncludedShaders: []\\n'")
    runner = once(runner, "and built['four_builtin_material_witnesses_verified'] and built['serialization_mode'] == 'Mixed'",
                  "and built['four_builtin_material_witnesses_verified'] and built['original_shaders_import_only'] and built['imported_original_shaders_excluded_from_player'] and built['serialization_mode'] == 'Mixed'")
    runner = runner.replace('selected_original_Shader_import_dependency_and_Windows_build_verified_program_retention_UNPROVEN',
                            'original_Shader_import_and_four_builtin_Material_Windows_build_verified')
    runner = once(runner, "report['status'].startswith('selected_original_Shader_import_')", "report['status'].startswith('original_Shader_import_and_four_builtin_')")
    runner = once(runner, 'Out of memory\', line, re.I)', 'Out of memory|StackOverflowException|Internal Error in BuildPipeline|Received signal SIGSEGV\', line, re.I)')
    runner = runner.replace('Exact seven Shader keep-list and null diagnostic pipeline required', 'Empty original Shader keep-list and null diagnostic pipeline required')
    runner = runner.replace('Original asset import, dependency witnesses and actual packed Shader API capture only.', 'Original Shaders are import-only; only the four diagnostic builtin Materials and control resources are packaged.')
    runner = runner.replace('Actual seven Shader/four Material import/build gate failed', 'Actual import-only Shader/four Material build gate failed')
    runner = runner.replace('Prepare/review seven original Shaders and four builtin Material witnesses.', 'Prepare/review import-only original Shaders and four packed builtin Material witnesses.')
    files = [save('BuildBuiltinMaterialIdentityFixture.cs', builder), save('run_builtin_material_identity_fixture.py', runner)]
    compile(runner, files[1]['path'], 'exec')
    print(json.dumps({'status': 'fresh_import_only_fixture_sources_derived_no_child_started', 'files': files, 'Main_modified': False}))

if __name__ == '__main__':
    main()
