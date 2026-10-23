"""Preserve three exact Shader object payloads and a fail-closed next-test plan.

No Unity launch, managed helper, Shader invocation, or Main mutation occurs.
"""
import hashlib
import json
from datetime import datetime, timezone
from pathlib import Path
from uuid import uuid4
from stage_original_native_sdk_dependencies import ROOT, WS, sha, need, regular

PROBE = ROOT/'AssetRecovery/OriginalShaderSourceProbe-20261022T184321Z-dfa2d738/report.json'
PROBE_SHA = '466da3d8ddab16fe33dede9d4f900262ba99a6a901fb836282df0188e2536847'

def main():
    need(sha(PROBE) == PROBE_SHA, 'Exact targeted probe required')
    probe = json.loads(PROBE.read_bytes())
    out = ROOT/'AssetRecovery'/('OriginalShaderRecoveryRoute-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid4().hex[:8])
    out.mkdir()
    objects = []
    for shader in probe['selected_shaders']:
        for candidate in shader['original_source_candidates']:
            original = candidate['original_object']
            source = regular(Path(original['source_path']))
            target = out/'OriginalSerializedShaderObjects'/('native-' if original['origin'] == 'original_native_container' else 'bundle-')
            target = target.with_name(target.name+original['path_id']+'.bin')
            target.parent.mkdir(parents=True, exist_ok=True)
            digest = hashlib.sha256()
            before = source.stat()
            with source.open('rb') as incoming, target.open('xb') as outgoing:
                incoming.seek(original['byte_offset'])
                remaining = original['byte_size']
                while remaining:
                    block = incoming.read(min(1024*1024, remaining))
                    need(block, 'Original Shader range truncated')
                    outgoing.write(block)
                    digest.update(block)
                    remaining -= len(block)
            need(digest.hexdigest() == candidate['whole_original_object_sha256'] == sha(target), 'Preserved exact Shader object range SHA mismatch')
            after = source.stat()
            need((before.st_size, before.st_mtime_ns) == (after.st_size, after.st_mtime_ns), 'Original source changed while preserving selected range')
            objects.append({'requested_shader': shader['name'], 'source_object': original, 'range_copy': {'path': str(target), 'sha256': digest.hexdigest(), 'bytes': original['byte_size']},
                'raw_serialized_object_is_not_editor_importable_asset': True,
                'ParsedForm_name_and_program_fields_structurally_decoded': False})
    need(len(objects) == 3, 'Exact two native plus one bundled Shader object candidates required')
    exporter = WS/'AR23Tool/Source/Source/AssetRipper.Export.UnityProjects/Shaders/YamlShaderExportCollection.cs'
    shader_exporter = exporter.with_name('YamlShaderExporter.cs')
    save_guard = WS/'RR23/Assets/Editor/AssetRipperPatches/AvoidSavingYamlShaders.cs'
    report = {'schema': 'authentic-original-compiled-shader-recovery-route/v1', 'status': 'object_payloads_preserved_next_reader_and_isolated_import_not_run',
        'probe': {'path': str(PROBE), 'sha256': PROBE_SHA}, 'original_object_candidates': objects,
        'observed_current_failures': [{'name': row['name'], 'path': row['current_asset'], 'sha256': row['current_asset_sha256'],
            'compressed_blob_bytes': row['compressed_blob_bytes'], 'partial_CB_rows': row['partial_CB_yaml_rows'],
            'finding': 'Current compiled-program blob and platform offset/length arrays are empty while parsed shader declarations remain.'} for row in probe['selected_shaders']],
        'tool_source_evidence': [{'path': str(path), 'sha256': sha(path)} for path in [exporter, shader_exporter, save_guard]],
        'causation_limit': 'AssetRipper itself warns that Unity resaving these YAML Shader assets can corrupt them. Empty current payloads are proven; this probe does not prove which earlier write removed them, or yet establish whether each original native field contains nonempty programs.',
        'next_minimal_data_reader': {
            'scope': 'One original ClassID48 object at a time through the pinned2020.3.33f1 generated Shader ReadRelease/YAML model; no assembly manager, game objects, MonoBehaviour models or script export.',
            'inputs': 'Exact source file/CAB+PathID+type48+object byte ranges above. Confirm native old type hash against candidate type-tree/model before reading.',
            'mandatory_gates': ['Consume exactly the entire bounded original object with no ignored tail or default substitutions.',
                'Read ParsedForm.Name structurally and require exact expected name; current length-prefixed byte-pattern discovery is insufficient for acceptance.',
                'Record original platforms, offsets, compressedLengths, decompressedLengths and compressedBlob lengths/hashes. Refuse any fabricated empty/full payload.',
                'Compare all preserved ParsedForm properties/pass/parameter/constant-buffer values against current asset; report differences rather than copying by name alone.',
                'Bind source dependency PPtrs using source file/CAB+PathID and exact export provenance; never guess Shader or Texture identities from names.',
                'Write a fresh staged original Shader candidate only. Existing Main Shader GUIDs/fileIDs/material references must remain untouched until import tests pass.'],
            'proposed_owned_private_limit_MiB': 512, 'proposed_global_commit_reserve_GiB': 1.5, 'actual_reader_built_or_run': False},
        'isolated_matching_Editor_validation_plan': {
            'project': 'Fresh minimal2020.3.33f1 project outside Main, only selected original Shader data and exact proven Shader/Texture dependencies; no original scripts, plugins, game scenes, Play or startup callbacks.',
            'checks': ['Compare original compiled-program byte hashes before import and after any Unity-native save/reload.',
                'Require no missing-binary or partial-constant-buffer errors; preserve shader name/property/pass counts and material keyword/property/texture values.',
                'Compare candidate.meta GUID/fileID bindings against the proposed Main material references; do not write Main for testing.',
                'Treat Shader support on the actual desktop graphics backend as a separate test from parsing or no-graphics import.',
                'If testing native Shader asset capture, treat AssetDatabase serialization support as unproven until an isolated roundtrip demonstrates exact retained program data.'],
            'bundle_warning': 'The bundled AG candidate is in a mixed core bundle containing MonoBehaviour and MonoScript classes114/115. Do not LoadAllAssets or import that whole bundle as a script-free shader fixture. A dependency-complete class48-only path must be proved first.',
            'Unity_launched': False},
        'not_proposed': ['Standard or URP shader substitutions', 'render-pipeline upgrade', 'guessed HLSL source reconstruction', 'clearing partial-CB flags to hide errors', 'main Shader or material overwrites', 'whole-client native code execution'],
        'all_original_asset_context': {'raw_bundle_archive': str(ROOT/'RawUnityFSRecovery/VerifiedAll-20261022T133109Z-2e17e8f8/report.json'), 'raw_archive_is_editor_editable': False},
        'Main_modified': False, 'Editor_interacted_with': False, 'Unity_launched': False, 'managed_child_launched': False,
        'gameplay_or_original_shader_source_recovery_claimed': False}
    path = out/'report.json'
    path.write_text(json.dumps(report, indent=2)+'\n')
    print(json.dumps({'report': str(path), 'sha256': sha(path), 'exact_original_object_bytes_preserved': sum(row['range_copy']['bytes'] for row in objects), 'objects': len(objects), 'status': report['status']}))
if __name__ == '__main__':
    main()
