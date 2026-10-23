"""Read-only full-scene Windows build preflight; never invokes Unity/builds."""
import hashlib
import json
import re
from datetime import datetime, timezone
from pathlib import Path
from uuid import uuid4
from stage_original_native_sdk_dependencies import ROOT, SOURCE, WS, sha, need, regular

MAIN = WS/'RR23'
EDITOR = WS/'Tools/Editors/2020.3.33f1/Editor'

def main():
    build_settings = MAIN/'ProjectSettings/EditorBuildSettings.asset'
    player_settings = MAIN/'ProjectSettings/ProjectSettings.asset'
    graphics = MAIN/'ProjectSettings/GraphicsSettings.asset'
    encoded = build_settings.read_bytes()
    text = encoded.decode('utf-8-sig').replace('\r\n', '\n')
    rows = re.findall(r'(?m)^  - enabled: ([01])\n    path: ([^\n]+)\n    guid: ([0-9a-f]{32})$', text)
    need(rows and len(rows) == text.count('  - enabled:'), 'Every original BuildSettings scene row must parse')
    scenes, errors = [], []
    seen = set()
    for i, (enabled, relative, guid) in enumerate(rows):
        need(not Path(relative).is_absolute() and '..' not in Path(relative).parts and relative.startswith('Assets/') and relative.endswith('.unity'), 'Safe original scene path required')
        path = MAIN/relative
        meta = path.with_name(path.name+'.meta')
        exists, meta_exists = path.is_file(), meta.is_file()
        actual_guid = None
        if exists:
            regular(path)
        if meta_exists:
            regular(meta)
            found = re.findall(r'(?m)^guid: ([0-9a-f]{32})$', meta.read_text().replace('\r\n', '\n'))
            actual_guid = found[0] if len(found) == 1 else None
        row = {'build_index': i, 'enabled': enabled == '1', 'path': relative, 'declared_guid': guid, 'scene_exists': exists,
            'scene_bytes': path.stat().st_size if exists else None, 'meta_exists': meta_exists, 'actual_meta_guid': actual_guid, 'guid_matches': guid == actual_guid,
            'meta_sha256': sha(meta) if meta_exists else None}
        if not exists or not meta_exists or guid != actual_guid or relative.casefold() in seen:
            errors.append(row)
        seen.add(relative.casefold())
        scenes.append(row)
    settings = player_settings.read_text(encoding='utf-8-sig')
    raw_fields = {}
    for key in ['productName', 'companyName', 'bundleVersion', 'scriptingBackend', 'il2cppCompilerConfiguration', 'scriptingDefineSymbols', 'apiCompatibilityLevelPerPlatform', 'apiCompatibilityLevel', 'scriptingRuntimeVersion', 'activeInputHandler', 'allowUnsafeCode', 'm_BuildTargetGraphicsAPIs']:
        hit = re.search(r'(?m)^  '+re.escape(key)+r':([^\r\n]*)', settings)
        raw_fields[key] = hit[1].strip() if hit else None
    module = EDITOR/'Data/PlaybackEngines/windowsstandalonesupport'
    variants = sorted(path.name for path in (module/'Variations').iterdir() if path.is_dir())
    win64 = {}
    for variant in [name for name in variants if name.startswith('win64_')]:
        folder = module/'Variations'/variant
        win64[variant] = {name: {'exists': (folder/name).is_file(), 'bytes': (folder/name).stat().st_size if (folder/name).is_file() else None} for name in ['WindowsPlayer.exe', 'UnityPlayer.dll']}
        win64[variant]['MonoBleedingEdge_exists'] = (folder/'MonoBleedingEdge').is_dir()
    pipeline_guid = re.search(r'(?m)^  m_CustomRenderPipeline: \{fileID: 11400000, guid: ([0-9a-f]{32}), type: 2\}', graphics.read_text())
    pipeline_asset = MAIN/'Assets/MonoBehaviour/URP-Default.asset'
    pipeline_meta = pipeline_asset.with_name(pipeline_asset.name+'.meta')
    pipeline_found = pipeline_guid is not None and pipeline_meta.exists() and ('guid: '+pipeline_guid[1]) in pipeline_meta.read_text()
    manifest = MAIN/'Packages/manifest.json'
    packages = json.loads(manifest.read_bytes())['dependencies']
    codegen = MAIN/'Assets/Editor/OriginalMetadataRestoration/Unity.RR23.OriginalMetadata.CodeGen.asmdef'
    codegen_data = json.loads(codegen.read_bytes())
    need(codegen_data['includePlatforms'] == ['Editor'], 'Metadata processor must remain Editor-only')
    source_inventory = json.loads((ROOT/'Preflight/public-archive-inventory.json').read_bytes())['files']
    aa = [row for row in source_inventory if row[0].startswith('RecRoom_Data/StreamingAssets/aa/')]
    aa_bundle_count = sum(row[0].endswith('.bundle') for row in aa)
    aa_bytes = sum(row[1] for row in aa)
    scene_sibling_paths = {path.relative_to(MAIN).as_posix() for path in (MAIN/'Assets').rglob('*.unity')}
    not_in_build = sorted(scene_sibling_paths-set(row['path'] for row in scenes))
    report = {'schema': 'original-project-full-Windows64-build-read-only-preflight/v1', 'status': 'scene_and_module_static_preflight_passed' if not errors else 'scene_preflight_requires_review',
        'project': str(MAIN), 'Unity_editor': str(EDITOR/'Unity.exe'), 'Unity_version': '2020.3.33f1', 'Unity_revision': '915a7af8b0d5',
        'pins': [{'path': str(path), 'sha256': sha(path)} for path in [build_settings, player_settings, graphics, manifest, codegen]],
        'scene_count': len(scenes), 'enabled_scene_count': sum(row['enabled'] for row in scenes), 'disabled_scene_count': sum(not row['enabled'] for row in scenes),
        'scenes': scenes, 'scene_errors': errors, 'unlisted_scene_asset_paths': not_in_build,
        'requested_build_target': 'StandaloneWindows64', 'player_settings_serialized_fields': raw_fields, 'installed_Windows_variations': variants, 'Windows64_player_files': win64,
        'backend_limit': 'scriptingBackend:{} is not an explicit stored Standalone override. The trusted Editor build method must record PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone), API compatibility and target support before building; do not silently alter them.',
        'original_client_backend': 'IL2CPP (original GameAssembly.dll)', 'Windows_IL2CPP_variation_installed': any('il2cpp' in name and name.startswith('win64_') for name in variants),
        'graphics_pipeline': {'serialized_GUID': pipeline_guid[1] if pipeline_guid else None, 'exact_URP_Default_asset_and_meta_present': pipeline_asset.exists() and pipeline_found, 'pipeline_changed': False},
        'packages': packages, 'compiler_support': {'CodeGen_Editor_only': True, 'facades_and_original_metadata_outside_Assets': (MAIN/'CompilerSupport/References').is_dir() and (MAIN/'CompilerSupport/Metadata').is_dir()},
        'original_Addressables_runtime_payload': {'source_files': len(aa), 'source_bundles': aa_bundle_count, 'source_bytes': aa_bytes,
            'Main_settings_json_present': (MAIN/'Assets/StreamingAssets/aa/settings.json').is_file(), 'Main_windows_bundle_folder_present': (MAIN/'Assets/StreamingAssets/aa/StandaloneWindows64').is_dir(),
            'status': 'not_in_Main_or_ordinary_BuildPipeline_output_until_explicit_original_StreamAssets_packaging',
            'originals_retained': str(SOURCE/'RecRoom_Data/StreamingAssets/aa')},
        'separate_known_gaps': ['Original shader/material compiled payload issues are not repaired by the zero-C#-error gate.',
            'The authentic original Addressables runtime payload is outside Main and needs an explicit packaging decision; raw archive preservation is not editable asset recovery.',
            'Many original game method bodies remain unrecovered; build success would not imply startup/login/gameplay works.',
            'The final metadata restoration engine passed actual Editor compile/signature loading; a full Standalone player compile remains a new required validation.',
            'Use the full original enabled scene list in exact order. The tiny facade fixture builder and AssetOnlyHost are not a full game build.'],
        'proposed_build': {'method': 'Trusted Editor-only BuildPipeline.BuildPlayer with BuildPlayerOptions', 'scenes': [row['path'] for row in scenes if row['enabled']],
            'target': 'BuildTarget.StandaloneWindows64', 'target_group': 'BuildTargetGroup.Standalone', 'output': 'fresh external directory SolarNet.exe; never original client/source paths',
            'required_before_call': ['Assert all enabled scene paths/GUIDs and settings hashes unchanged.', 'Record and honor actual scripting backend/API/profile/defines; fail if unsupported rather than migrate settings.',
                'Verify disk admission for native player assets plus original Addressables packaging if chosen.', 'Capture actual BuildReport result/errors/warnings/steps/size and all output paths; no success from exitcode alone.'],
            'settings_or_scenes_changed': False, 'Editor_launched': False, 'BuildPipeline_invoked': False},
        'Main_modified': False, 'original_client_or_game_code_executed': False}
    need(build_settings.read_bytes() == encoded, 'Build scene settings changed during read-only preflight')
    out = ROOT/'Validation'/('FullWindowsBuildPreflight-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid4().hex[:8])
    out.mkdir()
    path = out/'report.json'
    path.write_text(json.dumps(report, indent=2)+'\n')
    print(json.dumps({'report': str(path), 'sha256': sha(path), 'status': report['status'], 'enabled_scenes': report['enabled_scene_count'], 'scene_errors': len(errors), 'unlisted_scenes': len(not_in_build), 'source_Addressables_bundles_missing_Main': aa_bundle_count}))
if __name__ == '__main__':
    main()
