"""Wrap proved original Shader conversions using genuine Editor metadata.

No target is inferred by name. The manifest must enumerate every typed PPtr,
resolved target and ordered external row with independently pinned evidence.
"""
from pathlib import Path
import argparse
import datetime as dt
import importlib.util
import json
import shutil
import struct
import sys
import uuid
import original_shader_collection_editor_conversion as common

HERE = common.HERE
ROOT = common.ROOT
BASE = HERE / 'stage_editor_shader_native_input.py'
BASE_SHA = 'abd134a9272de3365a3b492228e66bf526dffcd07bdae2851e6a1b6b5269c455'
TYPE_SHA = '0fbf2d2f8e6c2b23f21468a5a0528d28f361ca32775a5dec12d72f1f3a093171'


def load_base():
    common.need(common.digest(BASE) == BASE_SHA, 'Pinned genuine Editor metadata capture source')
    spec = importlib.util.spec_from_file_location('genuine_editor_metadata_only', BASE)
    base = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(base)
    return base


def native_wrapper(header, parsed, typ, payload, externals, parser):
    metadata = bytearray(parsed['prefix']) + struct.pack('<i', 1) + typ['raw'] + struct.pack('<i', 1)
    metadata += bytes((-len(metadata)) % 4) + struct.pack('<qqIi', 4800000, 0, len(payload), 0)
    metadata += struct.pack('<ii', 0, len(externals))
    for row in externals:
        asset_path, path = bytes.fromhex(row['asset_path_hex']), bytes.fromhex(row['path_hex'])
        guid = bytes.fromhex(row['guid_hex'])
        common.need(b'\0' not in asset_path + path and len(guid) == 16, 'Exact bounded external row fields')
        metadata += asset_path + b'\0' + guid + struct.pack('<i', row['type']) + path + b'\0'
    metadata += struct.pack('<i', 0) + parsed['user_raw']
    start = (48 + len(metadata) + 15) & ~15
    data = payload + bytes((-len(payload)) % 8)
    size = start + len(data)
    output_header = bytearray(header)
    struct.pack_into('>Iqq', output_header, 20, len(metadata), size, start)
    common.need(output_header[:20] == header[:20] and output_header[40:] == header[40:], 'Only genuine header metadata/file/data sizes change')
    result = bytes(output_header) + metadata + bytes(start - 48 - len(metadata)) + data
    decoded = parser.parse_metadata(bytes(metadata), start, size)
    common.need(decoded['prefix'] == parsed['prefix'] and decoded['user_raw'] == parsed['user_raw']
        and len(decoded['types']) == len(decoded['objects']) == 1 and decoded['types'][0]['raw'] == typ['raw'], 'Complete genuine Editor Class48 type/prefix/user bytes')
    common.need(decoded['externals'] == externals and decoded['script_type_count'] == decoded['ref_type_count'] == 0, 'Exact external rows and no script/reference type tables')
    obj = decoded['objects'][0]
    common.need(obj['path_id'] == 4800000 and obj['type_index'] == 0 and obj['size'] == len(payload)
        and result[obj['offset']:obj['offset'] + obj['size']] == payload, 'Whole Editor payload with explicit native localID4800000')
    return result, {'metadata_bytes': len(metadata), 'data_offset': start, 'file_bytes': size,
        'external_rows': externals, 'path_id': 4800000, 'class_id': 48, 'exact_genuine_Class48_type_raw_sha256': TYPE_SHA}


def worker(args, out):
    common.need(common.digest(args.manifest) == args.manifest_sha256 and common.digest(args.conversion_report) == args.conversion_report_sha256, 'Pinned manifest/conversion proof')
    manifest = json.loads(args.manifest.read_bytes())
    conversion = json.loads(args.conversion_report.read_bytes())
    common.need(manifest['schema'] == 'resolved-original-Shader-Editor-collection/v1'
        and conversion['status'] == 'all_manifest_original_Shader_Editor_conversions_verified'
        and conversion['manifest']['sha256'] == args.manifest_sha256, 'Actual successful exact manifest conversion')
    for proof in manifest['proofs']:
        common.check(proof)
    for phase in conversion['phases']:
        common.need(phase['exit_code'] == 0 and phase['owned_child_exit_confirmed'] and phase['launcher']['membership_verified_before_resume'], 'Every generated conversion must finish in its owned job')
    results = {row['guid']: row for row in conversion['results']}
    common.need(len(results) == len(manifest['shaders']) and set(results) == {row['guid'] for row in manifest['shaders']}, 'Every manifest Shader converted once')
    reports = {}
    for guid, result in results.items():
        for key in ('spec', 'report', 'editor_payload', 'normalized_release', 'original_compiled_blob', 'ParsedForm'):
            common.check(result[key])
        proof = json.loads(Path(result['report']['path']).read_bytes())
        common.need(proof['guid'] == guid and proof['all_bytes_outside_name_and_manifest_typed_PPtr_windows_equal'], 'Exact per-shader preservation proof')
        reports[guid] = proof
    base = load_base()
    parser = base.load_parser()
    header, parsed, typ, source = base.inspect_source(out, parser)
    common.need(len(typ['raw']) == 84260 and common.digest(out / 'genuine-Shader-type0.bin') == TYPE_SHA, 'Exact full genuine Editor Shader type tree')
    assets = out / 'Assets'
    assets.mkdir()
    output = []
    for row in manifest['shaders']:
        guid = row['guid']; result = results[guid]; proof = reports[guid]
        for item in row['proofs'] + [row['meta'], row['current_asset'], row['source']]:
            common.check(item)
        meta_source = Path(row['meta']['path'])
        common.need(('guid: ' + guid) in meta_source.read_text(), 'Exact existing Main GUID must match original copied meta')
        common.need(proof['source_sha256'] == row['source']['sha256'] and proof['name'] == row['name']
            and proof['mapped_dependencies'] == [{'file_id': value['output_file_id'], 'path_id': value['output_path_id']} for value in row['dependencies']], 'Exact indexed mapped namespace agreement')
        externals = []
        for index, external in enumerate(row['externals'], 1):
            common.need(external['index'] == index, 'External FileID rows must be explicit one-based order')
            common.check(external['resolution_proof']); common.check(external['GUID_proof'])
            if external['kind'] == 'project':
                target = external['target_guid']
                common.need(target in reports and reports[target]['native_GUID_hex'] == external['native_guid_hex']
                    and external['type'] == 2 and external['asset_path_hex'] == external['path_hex'] == ''
                    and external['target_local_file_id'] == 4800000, 'Project GUID bytes must come from proven generated UnityGuid serializer and explicit target')
            elif external['kind'] == 'builtin':
                common.need(external['target_guid'] == '0000000000000000f000000000000000'
                    and external['native_guid_hex'] == '00000000000000000f00000000000000' and external['type'] == 0
                    and external['asset_path_hex'] == '' and bytes.fromhex(external['path_hex']) == b'Resources/unity_builtin_extra', 'Only genuine captured builtin external resource row is permitted')
                # This evidence is prepared separately from the current Main YAML graph.
                common.check(external['builtin_identity_proof'])
            else:
                raise RuntimeError('Unresolved or unsupported dependency kind')
            externals.append({'asset_path_hex': external['asset_path_hex'], 'guid_hex': external['native_guid_hex'], 'type': external['type'], 'path_hex': external['path_hex']})
        used = {value['output_file_id'] for value in row['dependencies'] if value['output_file_id'] != 0}
        common.need(used == set(range(1, len(externals) + 1)), 'No missing/unused external table rows')
        for value in row['dependencies']:
            file_id, path_id = value['output_file_id'], value['output_path_id']
            common.need((file_id == 0 and path_id == 0) or (1 <= file_id <= len(externals)), 'Every nonnull output PPtr resolves through an explicit external row')
            if file_id and row['externals'][file_id - 1]['kind'] == 'project':
                common.need(path_id == 4800000, 'Exact project Shader localID4800000')
            elif file_id:
                common.need(path_id in row['externals'][file_id - 1]['target_local_file_ids'], 'Builtin output localID must occur in independent identity proof manifest')
        payload = Path(result['editor_payload']['path']).read_bytes()
        data, shape = native_wrapper(header, parsed, typ, payload, externals, parser)
        target = assets / (guid + '.asset')
        with target.open('xb') as stream:
            stream.write(data)
        meta = Path(str(target) + '.meta')
        shutil.copyfile(meta_source, meta)
        common.need(common.digest(meta) == row['meta']['sha256'] and target.read_bytes() == data, 'Persisted wrapper and original meta exact')
        per_proof = {'schema': 'original-Shader-Editor-native-wrapper-proof/v1', 'status': 'exact_original_payload_and_proven_external_table_wrapped',
            'name': row['name'], 'guid': guid, 'source': row['source'], 'original_source_identity': row['original_source_identity'],
            'conversion': result['report'], 'manifest_source': common.pin(args.manifest), 'output_shape': shape,
            'entire_ParsedForm_equal': True, 'all_original_program_fields_equal': True,
            'all_Release_bytes_outside_name_and_manifest_typed_PPtr_windows_equal': True,
            'original_meta_bytes_and_GUID_preserved': True, 'native_Editor_import_or_GPU_tested': False,
            'Main_modified': False, 'Unity_launched': False}
        proof_path = out / (guid + '.wrapper-proof.json')
        common.save(proof_path, per_proof)
        output.append({'name': row['name'], 'guid': guid, 'asset': common.pin(target), 'meta': common.pin(meta), 'proof': common.pin(proof_path),
            'expected_direct_shader_dependencies': row['expected_direct_shader_dependencies'], 'original_source_identity': row['original_source_identity']})
    report = {'schema': 'original-Shader-Editor-wrapper-collection/v1',
        'status': 'all_mapped_original_Shader_Editor_wrappers_verified_native_import_unproven',
        'manifest': common.pin(args.manifest), 'conversion_report': common.pin(args.conversion_report), 'genuine_Editor_source': source,
        'shaders': output, 'count': len(output), 'Main_modified': False, 'Unity_launched': False,
        'native_API_or_game_code_executed': False, 'native_Editor_import_or_BuildPlayer_or_GPU_tested': False}
    common.save(out / 'wrapper-collection.json', report)
    print(json.dumps({'status': report['status'], 'report': common.pin(out / 'wrapper-collection.json'), 'count': len(output)}))


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--manifest', type=Path, required=True)
    parser.add_argument('--manifest-sha256', required=True)
    parser.add_argument('--conversion-report', type=Path, required=True)
    parser.add_argument('--conversion-report-sha256', required=True)
    parser.add_argument('--_worker', type=Path, help=argparse.SUPPRESS)
    args = parser.parse_args()
    if args._worker:
        out = args._worker.resolve(strict=True)
        common.need(out.is_relative_to(ROOT / 'AssetRecovery') and out.name.startswith('OriginalShaderEditorWrapperCollection-'), 'Recovery-only fresh output')
        return worker(args, out)
    out = ROOT / 'AssetRecovery' / ('OriginalShaderEditorWrapperCollection-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    import read_original_ag_shader_models as bounded
    bounded.CAP = 512 * 1024**2
    command = [sys.executable, '-B', str(Path(__file__).resolve()), '--manifest', str(args.manifest.resolve(strict=True)), '--manifest-sha256', args.manifest_sha256,
        '--conversion-report', str(args.conversion_report.resolve(strict=True)), '--conversion-report-sha256', args.conversion_report_sha256, '--_worker', str(out)]
    result = bounded.phase(command, out, 'pure-generalized-native-Editor-wrappers')
    common.save(out / 'owned-job-report.json', result)
    common.need(result['exit_code'] == 0 and not result.get('error'), 'Pure wrapper collection held; inspect receipt')
    print(json.dumps({'report': common.pin(out / 'wrapper-collection.json'), 'owned_job': common.pin(out / 'owned-job-report.json')}))


if __name__ == '__main__':
    main()
