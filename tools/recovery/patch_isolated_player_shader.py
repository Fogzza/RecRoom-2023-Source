"""Append a proven pointer-free original Shader to a cloned Unity 2020 player file.

No Editor/importer is involved. All other object table rows and payload bytes are
preserved. This is a diagnostic route, not yet an RR23 build integration.
"""
from pathlib import Path
import argparse
import hashlib
import importlib.util
import json
import struct

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
PARSER = ROOT / 'AssetRecovery/OriginalFallbackNativeSerializedInput-20261022T205430Z-cab1d2e4/stage_input.py'
PARSER_SHA = '98b4cd637d310605981a57a7284660096dc4d2d4e8fa6b0f5240a41d4e2b02ae'
RELEASE_SHA = '9d68229325a824a746e3dcdca644dc7d5eb9c3677d724b118697785d8c714300'
NAME = 'Hidden/Universal Render Pipeline/FallbackError'


def need(value, message):
    if not value:
        raise ValueError(message)


def digest(data):
    return hashlib.sha256(data).hexdigest()


def pin(path):
    return {'path': str(path.resolve()), 'sha256': digest(path.read_bytes()), 'bytes': path.stat().st_size}


def parser_module():
    need(digest(PARSER.read_bytes()) == PARSER_SHA, 'Reviewed metadata parser changed')
    spec = importlib.util.spec_from_file_location('original_release_shader_metadata', PARSER)
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    return module


def inspect(data, parser):
    need(48 <= len(data) <= 64 * 1024**2, 'Bounded diagnostic native container')
    need(struct.unpack_from('>IIII', data) == (0, 0, 22, 0), 'Exact v22 native header')
    need(data[16:20] == bytes(4), 'Only little endian native data supported')
    size, declared, start, unknown = struct.unpack_from('>Iqqq', data, 20)
    need(declared == len(data) and unknown == 0 and 0 < size <= 16 * 1024**2 and 48 + size <= start <= declared, 'Native header bounds')
    metadata = data[48:48 + size]
    parsed = parser.parse_metadata(metadata, start, declared)
    need(parsed['platform'] == 19 and not parsed['has_type_tree'], 'Only matching Windows64 Release player layout')
    # Prefix, type count, exact serialized type rows, object count, then fixed v22 object rows.
    table_start = len(parsed['prefix']) + 4 + sum(len(t['raw']) for t in parsed['types']) + 4
    table_start = (table_start + 3) & ~3
    for index, obj in enumerate(parsed['objects']):
        offset = table_start + index * 24
        need(struct.unpack_from('<qqIi', metadata, offset) == (obj['path_id'], obj['relative'], obj['size'], obj['type_index']), 'Object table location must independently agree with parsed values')
    return metadata, parsed, start, table_start


def patched(data, path_id, payload, expected_payload_sha, expected_old_sha):
    need(digest(payload) == expected_payload_sha == RELEASE_SHA and len(payload) == 3656, 'Only proven pointer-free original Fallback32 payload is supported')
    parser = parser_module()
    _, _, _, original_obj, original_type, original_raw = parser.inspect_source()
    need(original_raw == payload, 'Source pointer-closure proof and payload must agree')
    metadata, parsed, data_start, table_start = inspect(data, parser)
    candidates = [(index, obj) for index, obj in enumerate(parsed['objects']) if obj['path_id'] == path_id]
    need(len(candidates) == 1, 'Unique target path ID required')
    index, obj = candidates[0]
    typ = parsed['types'][obj['type_index']]
    need(typ['class_id'] == 48 and typ['script_type_index'] == -1 and typ['script_id'] is None, 'Target must be a native Shader')
    need(typ['raw'] == original_type['raw'], 'Exact original Release Shader native type hash/layout required')
    old = data[obj['offset']:obj['offset'] + obj['size']]
    need(digest(old) == expected_old_sha, 'Exact original target bytes required')
    needle = struct.pack('<i', len(NAME.encode())) + NAME.encode()
    need(old.count(needle) >= 1 and payload.count(needle) == 1, 'Exact target and original ParsedForm Shader identity')
    # Append, rather than shifting existing objects: every non-target range stays
    # at its old address. The old target becomes unreachable unused data.
    append_offset = (len(data) + 15) & ~15
    result = bytearray(data)
    result += bytes(append_offset - len(result)) + payload
    result += bytes((-len(result)) % 8)
    struct.pack_into('>q', result, 24, len(result))
    row_offset = 48 + table_start + index * 24
    struct.pack_into('<qI', result, row_offset + 8, append_offset - data_start, len(payload))
    verified_meta, verified, verified_start, verified_table = inspect(bytes(result), parser)
    need(verified_start == data_start and verified_table == table_start and len(verified['objects']) == len(parsed['objects']), 'Native file structure must remain unchanged')
    masked_before, masked_after = bytearray(data), bytearray(result[:len(data)])
    for offset, length in [(24, 8), (row_offset + 8, 12)]:
        masked_before[offset:offset + length] = bytes(length)
        masked_after[offset:offset + length] = bytes(length)
    need(masked_before == masked_after, 'Only header file size and target relative-offset/size fields may change')
    unchanged = []
    for before, after in zip(parsed['objects'], verified['objects']):
        if before['path_id'] == path_id:
            need(after['path_id'] == before['path_id'] and after['type_index'] == before['type_index'] and result[after['offset']:after['offset'] + after['size']] == payload, 'Entire original replacement object must be byte exact')
        else:
            need(before == after and data[before['offset']:before['offset'] + before['size']] == result[after['offset']:after['offset'] + after['size']], 'All non-target object identities, addresses and payloads must remain exact')
            unchanged.append(before['path_id'])
    return bytes(result), {'target_path_id': path_id, 'original_source_path_id': original_obj['path_id'], 'target_type_hash': typ['old_type_hash'],
                           'old_object_sha256': digest(old), 'replacement_sha256': digest(payload), 'replacement_bytes': len(payload),
                           'replacement_offset': append_offset, 'non_target_object_count_preserved': len(unchanged),
                           'all_non_target_rows_ranges_and_payloads_exact': True, 'only_original_file_size_and_target_range_fields_changed': True,
                           'original_pointer_closure_zero': True, 'runtime_loading_and_rendering_tested': False}


def main():
    p = argparse.ArgumentParser(description=__doc__)
    p.add_argument('--input', type=Path, required=True)
    p.add_argument('--input-sha', required=True)
    p.add_argument('--target-path-id', type=int, required=True)
    p.add_argument('--old-shader-sha', required=True)
    p.add_argument('--payload', type=Path, required=True)
    p.add_argument('--output', type=Path, required=True)
    a = p.parse_args()
    for source in (a.input, a.payload):
        need(source.resolve(strict=True).is_relative_to(ROOT / 'AssetRecovery') and not source.is_symlink(), 'Diagnostic recovery input only')
    need(a.output.parent.resolve(strict=True).is_relative_to(ROOT / 'AssetRecovery') and not a.output.exists(), 'Fresh diagnostic output only; never Main or original files')
    data, payload = a.input.read_bytes(), a.payload.read_bytes()
    need(digest(data) == a.input_sha, 'Pinned native input changed')
    result, proof = patched(data, a.target_path_id, payload, RELEASE_SHA, a.old_shader_sha)
    with a.output.open('xb') as stream:
        stream.write(result)
    need(a.output.read_bytes() == result and digest(a.input.read_bytes()) == a.input_sha, 'Persisted patch exact; read-only source unchanged')
    report = {'schema': 'isolated-player-original-shader-append-patch/v1', 'status': 'exact_original_program_payload_restored_runtime_unverified',
              'input': pin(a.input), 'original_payload': pin(a.payload), 'output': pin(a.output), 'tool': pin(Path(__file__)),
              'proof': proof, 'Main_modified': False, 'Editor_launched': False, 'player_launched': False}
    report_path = a.output.with_name(a.output.name + '.patch-report.json')
    with report_path.open('x', encoding='utf-8') as stream:
        json.dump(report, stream, indent=2)
        stream.write('\n')
    print(json.dumps({'status': report['status'], 'report': pin(report_path), 'output': report['output']}))


if __name__ == '__main__':
    main()
