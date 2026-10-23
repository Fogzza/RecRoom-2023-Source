"""Pure append-only Release Shader recovery for an isolated two-shader player.

Only the proven AG6351 -> Fallback32 relationship is remapped. The two built
objects must already be local to the same native container. No Main writes.
"""
import hashlib
import struct
from patch_isolated_player_shader import parser_module, inspect, need, RELEASE_SHA

AG_SHA = 'b7a537500bf6b84af05ea8c49110b291f1fb3d7e26eab787d0be2f3bd0433074'
TYPE_SHA = '0450a074a202f4507336401ebea9702ae846f2ed572d3a3750deb0f46f19b48a'


def digest(b):
    return hashlib.sha256(b).hexdigest()


def patch_pair(container, ag_original, fallback_original, ag_id, fallback_id, old_ag_sha, old_fallback_sha):
    need(digest(ag_original) == AG_SHA and len(ag_original) == 6551992, 'Exact original AG6351 source required')
    need(digest(fallback_original) == RELEASE_SHA and len(fallback_original) == 3656, 'Exact original Fallback32 source required')
    need(ag_id != fallback_id and ag_id != 0 and fallback_id != 0, 'Distinct nonnull local output Shader identities required')
    # Typed source-model proof establishes this exact one-dependency tail.
    need(struct.unpack_from('<iiq', ag_original, len(ag_original) - 24) == (1, 1, 32), 'Original AG typed dependency count1/file1/path32 tail required')
    need(ag_original[-8:] == bytes.fromhex('0000000001000000'), 'Original AG nonmodifiable texture0 / baked1 tail required')
    need(fallback_original[-12:] == bytes.fromhex('000000000000000001000000'), 'Fallback must remain pointer-free')
    ag_mapped = bytearray(ag_original)
    pointer_offset = len(ag_mapped) - 20
    struct.pack_into('<iq', ag_mapped, pointer_offset, 0, fallback_id)
    need(ag_mapped[:pointer_offset] == ag_original[:pointer_offset] and ag_mapped[pointer_offset + 12:] == ag_original[pointer_offset + 12:], 'Every AG byte outside exactly one typed PPtr must remain original')
    parser = parser_module()
    metadata, parsed, data_start, table_start = inspect(container, parser)
    target_ids = {ag_id, fallback_id}
    targets = {o['path_id']: (i, o) for i, o in enumerate(parsed['objects']) if o['path_id'] in target_ids}
    need(set(targets) == target_ids and sum(o['path_id'] in target_ids for o in parsed['objects']) == 2, 'Both built target Shaders must have unique identities in the same native container')
    result = bytearray(container)
    edits = [(24, 8)]
    replacements = [(fallback_id, fallback_original, old_fallback_sha), (ag_id, bytes(ag_mapped), old_ag_sha)]
    rows = []
    for path_id, payload, old_sha in replacements:
        index, obj = targets[path_id]
        typ = parsed['types'][obj['type_index']]
        need(typ['class_id'] == 48 and digest(typ['raw']) == TYPE_SHA, 'Both targets must use the exact original Release Shader native type')
        old = container[obj['offset']:obj['offset'] + obj['size']]
        need(digest(old) == old_sha, 'Exact typed-reader-selected output object pin required')
        offset = (len(result) + 15) & ~15
        result += bytes(offset - len(result)) + payload
        result += bytes((-len(result)) % 8)
        row = 48 + table_start + index * 24
        struct.pack_into('<qI', result, row + 8, offset - data_start, len(payload))
        edits.append((row + 8, 12))
        rows.append({'path_id': path_id, 'original_sha256': AG_SHA if path_id == ag_id else RELEASE_SHA, 'mapped_payload_sha256': digest(payload),
                     'old_output_sha256': old_sha, 'payload_bytes': len(payload), 'new_absolute_offset': offset})
    struct.pack_into('>q', result, 24, len(result))
    _, verified, verified_start, verified_table = inspect(bytes(result), parser)
    need(verified_start == data_start and verified_table == table_start, 'Existing native metadata/data layout stays unchanged')
    masked_before, masked_after = bytearray(container), bytearray(result[:len(container)])
    for start, length in edits:
        masked_before[start:start + length] = bytes(length)
        masked_after[start:start + length] = bytes(length)
    need(masked_before == masked_after, 'Only file size and both authorized object ranges may change in the existing file')
    payload_by_id = {fallback_id: fallback_original, ag_id: bytes(ag_mapped)}
    for before, after in zip(parsed['objects'], verified['objects']):
        if before['path_id'] in target_ids:
            need(before['type_index'] == after['type_index'] and result[after['offset']:after['offset'] + after['size']] == payload_by_id[before['path_id']], 'Entire mapped original Shader payload must be exact')
        else:
            need(before == after and container[before['offset']:before['offset'] + before['size']] == result[after['offset']:after['offset'] + after['size']], 'Every nontarget object range/identity/payload must remain exact')
    return bytes(result), {'schema': 'isolated-original-AG-fallback-append-patch/v1', 'objects': rows,
                           'source_AG_dependency': {'file_id': 1, 'path_id': 32}, 'output_AG_dependency': {'file_id': 0, 'path_id': fallback_id},
                           'AG_pointer_relative_offset': pointer_offset, 'only_AG_source_change_one_typed_12_byte_PPtr': True,
                           'all_original_AG_shader_program_bytes_preserved': True, 'all_original_Fallback_bytes_preserved': True,
                           'every_existing_nontarget_object_row_range_and_payload_exact': True, 'Main_modified': False,
                           'runtime_AG_rendering_claimed': False}
