"""Pinned AG/Fallback regression for the generalized original-object converter."""
from pathlib import Path
import json
import original_shader_collection_editor_conversion as common

ROOT = common.ROOT
WS = common.WS
OLD = ROOT / 'AssetRecovery/OriginalAGGuidDependencyConversion-20261023T024930Z-08353e98'


def main():
    old_run = OLD / 'run-report.json'
    common.need(common.digest(old_run) == '1eda50f379e24fffad0f8f19d498ff6be2fca5733b7d3d22a797bb8396eaf786', 'Pinned actual successful two-shader proof')
    source_inputs = json.loads((OLD / 'two-shader-inputs.json').read_bytes())['shaders']
    old = json.loads(old_run.read_bytes())
    dependency = ROOT / 'AssetRecovery/OriginalShaderDependencyResolution-20261022T214505Z-bfbbb8ca/report.json'
    common.need(common.digest(dependency) == '3854edc3af40c1a960be8cba45e3b8c483cb724061bcaf00d5573c081b33d9f1', 'Exact original AG external namespace proof')
    guid_proof = ROOT / 'AssetRecovery/RuntimeShaderProofSupplement-20261023T024917Z-26d72acf/genuine-Editor-GUID-remap-proof.json'
    common.need(common.digest(guid_proof) == '2b4155bc4bc8e78ace255698152c332534c123db7e9b245005e7e2645d89a356', 'Exact genuine Editor GUID proof')
    serializer = WS / 'AR23Tool/Source/Source/AssetRipper.IO.Files/SerializedFiles/Parser/EndianExtensions.cs'
    proofs = [common.pin(path) for path in (old_run, dependency, guid_proof, serializer)]
    result = []
    identities = {
        'AG': ('90510347b31afb84fba058c6708c7f5c', 'AG_Standard-Opaque.asset', 'resources.assets'),
        'Fallback': ('d2a5536c48f6e914f900eb13ea2f4d68', 'Hidden_Universal Render Pipeline_FallbackError.asset', 'globalgamemanagers.assets')}
    for source in source_inputs:
        key = source['key']
        guid, filename, container = identities[key]
        prior = old['results'][key]
        proof_path = Path(prior['report']['path'])
        common.check(prior['report'])
        proof = json.loads(proof_path.read_bytes())
        meta = WS / 'RR23/Assets/Shader' / (filename + '.meta')
        asset = meta.with_suffix('')
        common.need(('guid: ' + guid) in meta.read_text(), 'Original GUID/meta identity')
        deps = [] if key == 'Fallback' else [{'index': 0, 'source_file_id': 1, 'source_path_id': 32, 'output_file_id': 1, 'output_path_id': 4800000}]
        external = [] if key == 'Fallback' else [{'index': 1, 'kind': 'project', 'target_guid': identities['Fallback'][0],
            'target_local_file_id': 4800000, 'native_guid_hex': '2d5a35c6846f9e419f00be31aef2d486', 'type': 2, 'asset_path_hex': '', 'path_hex': '',
            'resolution_proof': common.pin(dependency), 'GUID_proof': common.pin(guid_proof)}]
        result.append({'schema': 'resolved-original-Shader-Editor-conversion-input/v1',
            'name': source['name'], 'guid': guid, 'source': {key: source[key] for key in ('path', 'bytes', 'sha256')},
            'original_path_id': source['path_id'], 'expected_ParsedForm_sha256': proof['parsed_form_utf8_sha256'],
            'expected_program_fields': source['expected_program_fields'], 'expected_shader_is_baked': True,
            'dependencies': deps, 'externals': external, 'meta': common.pin(meta), 'current_asset': common.pin(asset),
            'proofs': [common.pin(proof_path), common.pin(dependency), common.pin(guid_proof)],
            'expected_direct_shader_dependencies': [] if key == 'Fallback' else [{'kind': 'project', 'guid': identities['Fallback'][0], 'local_file_id': 4800000}],
            'original_source_identity': {'source_file': str(ROOT / 'VerifiedSource/RecRoom_Data' / container), 'path_id': source['path_id'], 'raw_sha256': source['sha256']}})
    manifest = {'schema': 'resolved-original-Shader-Editor-collection/v1', 'status': 'known_proven_AG_Fallback_regression_manifest',
        'proofs': proofs, 'shaders': result, 'Main_modified': False}
    target = OLD / 'generalized-converter-regression-manifest.json'
    common.save(target, manifest)
    print(json.dumps({'manifest': common.pin(target)}))


if __name__ == '__main__':
    main()
