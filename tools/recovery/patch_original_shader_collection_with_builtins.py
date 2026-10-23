"""Strict pure-data append-only Shader patcher with Material-proved builtins.

Every builtin binding requires the pinned four-ID actual Material/native chain.
Shader names never select targets. Project-target checks retain the reviewed
streaming implementation unchanged.
No complete player container is read into memory. Main/VerifiedSource are never
outputs; this creates new native files under AssetRecovery only.
"""
from pathlib import Path
import argparse
import hashlib
import json
import struct
import map_shader_buildreport as native
import map_builtin_material_shader_targets as builtin

ROOT = native.WS/'Recovery/RecRoom-2023-04-18/AssetRecovery'
TYPE_SHA = '0450a074a202f4507336401ebea9702ae846f2ed572d3a3750deb0f46f19b48a'
CHUNK = 1024**2
MAX_PAYLOAD = 8*1024**2
MAX_APPEND = 256*1024**2
MAGIC_GUID = '0000000000000000f000000000000000'
BUILTIN_IDS = {'6', '7', '46', '10490'}
need = native.need


def checked(row):
    path = Path(row['path']).resolve(strict=True)
    need(path.is_file() and path.is_relative_to(ROOT) and native.pin(path) == row, 'Exact isolated pinned input required')
    return path


def number(value):
    need(type(value) in (str, int) and str(int(value)) == str(value), 'Canonical signed64 identity required')
    result = int(value)
    need(-2**63 <= result < 2**63, 'Signed64 identity overflow')
    return result


def metadata(path):
    parsed, layout = native.native(path)
    need(parsed['platform'] == 19 and not parsed['has_type_tree'], 'Exact Windows Release native layout required')
    start = len(parsed['prefix'])+4+sum(len(t['raw']) for t in parsed['types'])+4
    start = (start+3)&~3
    with Path(path).open('rb') as stream:
        stream.seek(48+start)
        table = stream.read(24*len(parsed['objects']))
    ids = set()
    for index, obj in enumerate(parsed['objects']):
        need(obj['path_id'] not in ids, 'Duplicate native object PathID refused')
        ids.add(obj['path_id'])
        need(struct.unpack_from('<qqIi', table, index*24) == (obj['path_id'], obj['relative'], obj['size'], obj['type_index']),
             'Independently located fixed native object table must agree')
    return parsed, layout, start


def payload(row, typed):
    source = checked(row['source'])
    need(12 <= source.stat().st_size <= MAX_PAYLOAD, 'Bounded per-source original Shader required')
    data = source.read_bytes()
    deps = row['dependencies']
    need(typed['schema'] == 'resolved-original-Shader-generated-Editor-roundtrip/v1'
         and typed['status'] == 'original_bytes_preserved_except_name_and_manifest_typed_PPtrs'
         and typed['engine'] == '2020.3.33f1' and typed['source_bytes'] == len(data)
         and typed['release_consumed_bytes'] == len(data), 'Exact matching generated full-source-read receipt required')
    need(len(deps) <= 1024 and typed['guid'] == row['guid'] and typed['name'] == row['name']
         and typed['source_sha256'] == row['source']['sha256']
         and typed['all_bytes_outside_name_and_manifest_typed_PPtr_windows_equal']
         and typed['entire_ParsedForm_equal'] and typed['all_five_original_program_fields_equal']
         and typed['nonmodifiable_texture_count'] == 0 and typed['shader_is_baked']
         and typed['dependency_count'] == len(deps), 'Full generated typed source/preservation proof required')
    need(typed['original_program_fields'] == row['expected_program_fields']
         and typed['parsed_form_utf8_sha256'] == row['expected_ParsedForm_sha256'], 'Exact original ParsedForm and all program-field pins required')
    tail = len(data)-12-12*len(deps)
    need(tail >= 4 and struct.unpack_from('<i', data, tail)[0] == len(deps)
         and data[-8:] == b'\0\0\0\0\1\0\0\0', 'Exact typed dependency/texture0/baked1 tail required')
    original = []
    for index, dep in enumerate(deps):
        need(dep['index'] == index, 'Explicit ordered indexed source dependency required')
        file_id, path_id = struct.unpack_from('<iq', data, tail+4+12*index)
        need(file_id == dep['source_file_id'] and path_id == number(dep['source_path_id']), 'Every raw source PPtr must agree with canonical typed manifest')
        original.append({'file_id': file_id, 'path_id': path_id})
    need(original == typed['source_dependencies'], 'Full generated source dependency order must agree')
    return data, tail


def expected_target(row, index):
    dep = row['dependencies'][index]
    file_id, path_id = dep['output_file_id'], number(dep['output_path_id'])
    if file_id == 0:
        need(path_id == 0, 'Only explicit null source dependencies may omit an external row')
        return {'kind': 'null', 'guid': None}
    need(1 <= file_id <= len(row['externals']), 'Canonical Editor external index required')
    ext = row['externals'][file_id-1]
    need(ext['index'] == file_id and ext['kind'] in ('project', 'builtin'), 'Canonical explicit target namespace required')
    if ext['kind'] == 'project':
        need(path_id == 4800000 and ext['target_local_file_id'] == 4800000, 'Canonical project Shader ID4800000 required')
    else:
        need(path_id in ext['target_local_file_ids'], 'Canonical builtin local identity required')
    return {'kind': ext['kind'], 'guid': ext['target_guid'], 'builtin_id': path_id}


def mask_compare(before, after, length, windows):
    windows = sorted(windows)
    need(all(0 <= p and n > 0 and p+n <= length for p,n in windows), 'Authorized old-file mask bounds')
    need(all(a+n <= b for (a,n),(b,m) in zip(windows,windows[1:])), 'Overlapping authorized edit masks refused')
    hashed = hashlib.sha256()
    with Path(before).open('rb') as a, Path(after).open('rb') as b:
        position = 0
        while position < length:
            count = min(CHUNK, length-position)
            left, right = bytearray(a.read(count)), bytearray(b.read(count))
            need(len(left) == len(right) == count, 'Complete bounded masked stream reads required')
            for offset, size in windows:
                start, end = max(offset, position), min(offset+size, position+count)
                if start < end:
                    left[start-position:end-position] = right[start-position:end-position] = bytes(end-start)
            need(left == right, 'An unauthorized pre-existing byte changed')
            hashed.update(left)
            position += count
    return hashed.hexdigest()


def read_object(container, identity, class_id, maximum):
    """Corroborate an explicit table identity and whole bounded object hash."""
    parsed, layout = native.native(container)
    need(parsed['platform'] == 19 and not parsed['has_type_tree'], 'Exact Release Windows container required')
    matches = [o for o in parsed['objects'] if o['path_id'] == number(identity['path_id'])]
    need(len(matches) == 1, 'Unique explicit native object identity required')
    obj = matches[0]
    typ = parsed['types'][obj['type_index']]
    need(typ['class_id'] == class_id and obj['offset'] == number(identity['absolute_offset'])
         and obj['size'] == number(identity['byte_size']) and 0 < obj['size'] <= maximum,
         'Exact native ClassID and absolute object range required')
    with Path(container).open('rb') as stream:
        stream.seek(obj['offset']); data = stream.read(obj['size'])
    need(len(data) == obj['size'] and native.digest(data) == identity['raw_sha256'], 'Exact entire native object hash required')
    return parsed, layout, obj, typ


def load_builtin_targets(plan, player):
    """Verify the mapper's pinned output and its complete Class21 evidence chain."""
    report_pin = plan['builtin_material_mapping_report']
    report = json.loads(checked(report_pin).read_bytes())
    need(report['schema'] == 'genuine-Editor-builtin-to-player-Class48-through-Material/v1'
         and report['status'] == 'all_four_Editor_builtin_ids_resolved_through_actual_Material_GUID_and_full_typed_native_PPtr',
         'Successful actual builtin Material-to-Class48 map required')
    need(report['tool'] == native.pin(Path(builtin.__file__)), 'Pinned builtin mapper implementation changed')
    material_map_pin = report['actual_input_report']
    material_map = json.loads(checked(material_map_pin).read_bytes())
    typed_pins = json.loads(checked(report['typed_report_pin_list']).read_bytes())
    need(type(typed_pins) is list and len(typed_pins) == 4
         and len({r['path'] for r in typed_pins}) == 4, 'Four unique pinned full typed Material reports required')
    for pin in typed_pins:
        checked(pin)
    need(material_map['tool'] == native.pin(Path(builtin.__file__)), 'Extraction must pin the same builtin mapper')
    build_pin = material_map['actual_input_report']
    build = json.loads(checked(build_pin).read_bytes())
    need(build['status'] == 'Succeeded' and build['unity_version'] == '2020.3.33f1'
         and build['target'] == 'StandaloneWindows64' and build['backend'] == 'Mono2x'
         and build['total_errors'] == build['partial_constant_buffer_messages'] == 0,
         'Successful matching actual Material-witness build receipt required')
    witnesses, capture = build['builtin_shader_material_witnesses'], build['packed_material_build_report']
    need(len(witnesses) == 4 and {r['builtin_local_id'] for r in witnesses} == BUILTIN_IDS
         and capture['schema'] == 'Unity2020-actual-packed-Material-API-records/v1', 'Exact four actual Editor builtin witnesses required')
    need(len(material_map['materials']) == len(report['builtin_targets']) == 4
         and {r['builtin_local_id'] for r in material_map['materials']} == BUILTIN_IDS
         and {r['builtin_local_id'] for r in report['builtin_targets']} == BUILTIN_IDS,
         'Exactly four distinct builtin identities6/7/46/10490 required')
    files = {r['id']:r['path'] for r in capture['files']}
    need(len(files) == len(capture['files']), 'Unique actual packed BuildFile IDs required')
    material_identities = set()
    for row in material_map['materials']:
        need(row['builtin_guid'] == MAGIC_GUID and row['class_id'] == 21, 'Genuine builtin magicGUID and Class21 origin required')
        matches = [r for r in witnesses if r['builtin_local_id'] == row['builtin_local_id']]
        need(len(matches) == 1 and row['source_Editor_material_identity_witness'] == matches[0], 'Exact actual Editor identity witness required')
        witness = matches[0]
        need(witness['builtin_guid'] == MAGIC_GUID and witness['shader_instance_equal_after_native_import'] is True
             and row['material_guid'] == witness['material_guid'] and row['material_source_path'] == witness['material_source_path'],
             'Original Editor builtin instance/GUID/localID-to-Material join required')
        packed = [r for r in capture['materials'] if r['source_guid'] == row['material_guid']]
        need(len(packed) == 1, 'Unique actual packed Material GUID placement required')
        packed = packed[0]
        path = checked(row['container'])
        need(path.is_relative_to(player) and packed['type'] == 'UnityEngine.Material'
             and packed['source_path'] == row['material_source_path'] and packed['file_id'] in files
             and Path(files[packed['file_id']]).resolve(strict=True) == path and path.name == packed['short_path']
             and number(packed['id']) == number(row['native_material_path_id'])
             and number(packed['offset']) == number(row['absolute_offset'])
             and number(packed['packed_size']) == number(row['byte_size']), 'Exact actual API Material placement/range join required')
        raw_path = checked(row['raw'])
        identity = {'path_id':row['native_material_path_id'], 'absolute_offset':row['absolute_offset'],
                    'byte_size':row['byte_size'], 'raw_sha256':row['raw']['sha256']}
        _, layout, obj, _ = read_object(path, identity, 21, 1024**2)
        need(row['raw']['bytes'] == obj['size'] and row['native_layout'] == layout
             and raw_path.stat().st_size == obj['size'], 'Extracted Material bytes and actual container layout must agree')
        key = (path, obj['path_id'])
        need(key not in material_identities, 'Duplicate native Material witness refused')
        material_identities.add(key)
    # This executes only the bounded pure-data resolver, never a native/managed reader.
    # Its exact typed-report checks include complete Class21 Read/Write equality,
    # then resolve the actual typed PPtr through the existing native externals.
    regenerated = builtin.resolve(material_map, typed_pins, player)
    for key in ('schema', 'status', 'builtin_targets', 'Main_modified', 'Unity_launched', 'GPU_or_runtime_proven'):
        need(report[key] == regenerated[key], 'Pinned builtin output must reproduce exactly from its full evidence chain')
    targets = {}
    for row in report['builtin_targets']:
        need(row['builtin_guid'] == MAGIC_GUID and row['no_Shader_name_used_as_identity_selector'] is True, 'No builtin name-based selection permitted')
        identity = row['target']; path = checked(identity['container'])
        need(path.is_relative_to(player) and identity['class_id'] == 48, 'Builtin target must be an actual Class48 in this player')
        _, layout, _, typ = read_object(path, identity, 48, MAX_PAYLOAD)
        need(native.digest(typ['raw']) == TYPE_SHA and identity['native_layout'] == layout, 'Exact genuine Class48 target metadata/layout required')
        targets[row['builtin_local_id']] = identity
    return targets


def preflight(plan):
    need(plan['schema'] == 'explicit-original-Shader-streaming-native-patch-with-builtin-Material-proof/v1', 'Explicit builtin-aware streaming plan schema required')
    manifest_path, map_path = checked(plan['canonical_manifest']), checked(plan['mapping_report'])
    manifest, mappings = json.loads(manifest_path.read_bytes()), json.loads(map_path.read_bytes())
    need(manifest['schema'] == 'resolved-original-Shader-Editor-collection/v1'
         and mappings['status'] == 'all_expected_GUID_native_id_absolute_offset_size_corroborated', 'Canonical typed manifest and successful actual native map required')
    by_guid = {r['guid']:r for r in manifest['shaders']}
    mapped = {r['guid']:r for r in mappings['mappings']}
    need(len(by_guid) == len(manifest['shaders']) and len(mapped) == len(mappings['mappings'])
         and 0 < len(mapped) <= 179 and set(mapped) == set(by_guid), 'Exactly one mapped placement per canonical Shader required; duplicates HOLD')
    explicit = {r['guid']:r for r in plan['shaders']}
    need(len(explicit) == len(plan['shaders']) and set(explicit) == set(mapped), 'Every exact mapped Shader needs one explicit patch specification')
    player = Path(plan['player_root']).resolve(strict=True)
    need(player.is_dir() and player.is_relative_to(ROOT), 'Isolated source player root required')
    builtin_targets = load_builtin_targets(plan, player)
    project_identities = {(checked(r['container']), number(r['path_id'])) for r in mapped.values()}
    need(not any((checked(r['container']), number(r['path_id'])) in project_identities for r in builtin_targets.values()),
         'Builtin witness targets cannot also be replaced as project Shader objects')
    containers, prepared, total = {}, [], 0
    for guid, mapping in mapped.items():
        need(mapping['class_id'] == 48 and mapping['id_and_absolute_range_independently_corroborated'] is True
             and mapping['name_used_as_identity_selector'] is False, 'Independent GUID/native Class48 map required')
        path = checked(mapping['container'])
        need(path.is_relative_to(player), 'Every source native file must be inside exact isolated player root')
        if path not in containers:
            parsed, layout, start = metadata(path)
            containers[path] = {'pin': mapping['container'], 'parsed': parsed, 'layout': layout, 'table_start': start, 'targets': []}
        container = containers[path]
        matches = [(i,o) for i,o in enumerate(container['parsed']['objects']) if o['path_id'] == number(mapping['path_id'])]
        need(len(matches) == 1, 'Unique exact mapped native object required')
        index, obj = matches[0]
        typ = container['parsed']['types'][obj['type_index']]
        need(typ['class_id'] == 48 and native.digest(typ['raw']) == TYPE_SHA,
             'Exact genuine matching Release Class48 type metadata required')
        need(obj['offset'] == number(mapping['absolute_offset']) and obj['size'] == number(mapping['byte_size']), 'Mapped native target range changed')
        need(0 < obj['size'] <= MAX_PAYLOAD, 'Bounded prepatch native Shader read required')
        with path.open('rb') as stream:
            stream.seek(obj['offset']); old = stream.read(obj['size'])
        need(len(old) == obj['size'] and native.digest(old) == mapping['raw_sha256'], 'Exact prepatch native Shader payload required')
        row, spec = by_guid[guid], explicit[guid]
        proof = json.loads(checked(spec['typed_source_proof']).read_bytes())
        data, tail = payload(row, proof)
        total += len(data)+16
        need(total <= MAX_APPEND, 'Bounded aggregate append budget exceeded')
        need(len(spec['bindings']) == len(row['dependencies']), 'Every typed source pointer needs explicit output binding')
        edits = []
        for index_dep, binding in enumerate(spec['bindings']):
            need(binding['index'] == index_dep, 'Explicit dependency binding order required')
            target = expected_target(row, index_dep)
            need(binding['kind'] == target['kind'] and binding.get('target_guid') == target['guid'], 'Binding target must agree with canonical original namespace resolution')
            out_file, out_path = binding['output_file_id'], number(binding['output_path_id'])
            need(type(out_file) is int and 0 <= out_file < 2**31, 'Exact signed32 output FileID required')
            if target['kind'] == 'null':
                need(out_file == out_path == 0, 'Null pointers must remain null')
            elif target['kind'] == 'builtin':
                builtin_id = str(target['builtin_id'])
                need(target['guid'] == MAGIC_GUID and builtin_id in BUILTIN_IDS and binding['builtin_local_id'] == builtin_id,
                     'Binding must retain exact canonical Editor builtin GUID/localID')
                target_map = builtin_targets[builtin_id]
                target_path = checked(binding['target_container'])
                need(binding['target_container'] == target_map['container'] and out_path == number(target_map['path_id']),
                     'Builtin binding must equal actual Material-proved Class48 container/PathID')
                if target_path == path:
                    need(out_file == 0 and 'external_row' not in binding, 'Same-container builtin must use file0 without an external row')
                else:
                    need(1 <= out_file <= len(container['parsed']['externals']), 'Builtin cross-container FileID must already exist')
                    external = container['parsed']['externals'][out_file-1]
                    need(binding.get('external_row') == external, 'Entire existing builtin-target external row witness required')
                    relative = bytes.fromhex(external['path_hex']).decode('utf-8')
                    need(external['asset_path_hex'] == '' and external['guid_hex'] == '0'*32 and external['type'] == 0
                         and relative == target_path.name and relative not in ('.','..') and '/' not in relative and '\\' not in relative
                         and (path.parent/relative).resolve(strict=True) == target_path,
                         'Builtin target requires exact existing plain-relative zeroGUID container identity; no inserted/GUID/archive rows')
            else:
                need(target['guid'] in mapped, 'Every project target must have a native GUID mapping')
                target_map = mapped[target['guid']]
                target_path = checked(binding['target_container'])
                need(binding['target_container'] == target_map['container'] and out_path == number(target_map['path_id']), 'Explicit target container/PathID must equal actual GUID-native map')
                if target_path == path:
                    need(out_file == 0 and 'external_row' not in binding, 'Same-container target must use file0 with no inferred external row')
                else:
                    need(1 <= out_file <= len(container['parsed']['externals']), 'Cross-container FileID must already exist in native metadata')
                    external = container['parsed']['externals'][out_file-1]
                    need(binding.get('external_row') == external, 'Explicit entire native external row witness required')
                    relative = bytes.fromhex(external['path_hex']).decode('utf-8')
                    need(external['asset_path_hex'] == '' and external['guid_hex'] == '0'*32 and external['type'] == 0
                         and relative == target_path.name and relative not in ('.','..') and '/' not in relative and '\\' not in relative
                         and (path.parent/relative).resolve(strict=True) == target_path,
                         'Only exact existing plain-relative zeroGUID native container identity is supported; archive/GUID remaps HOLD')
            offset = tail+4+12*index_dep
            edits.append((offset, out_file, out_path))
        prepared.append({'guid': guid, 'source': row['source'], 'typed_proof': spec['typed_source_proof'], 'path': path,
                         'table_index': index, 'object': obj, 'mapping': mapping, 'edits': edits})
        container['targets'].append(prepared[-1])
    return player, containers, prepared


def patch(plan, output):
    player, containers, prepared = preflight(plan)
    output = Path(output).resolve(strict=True)
    need(output.is_dir() and output.is_relative_to(ROOT) and not any(output.iterdir())
         and not output.is_relative_to(player) and not player.is_relative_to(output), 'Fresh empty isolated output directory outside input player required')
    results = []
    for path, container in containers.items():
        relative = path.relative_to(player)
        destination = output/relative
        destination.parent.mkdir(parents=True, exist_ok=True)
        old_size = path.stat().st_size
        with path.open('rb') as source, destination.open('xb') as target:
            while chunk := source.read(CHUNK):
                target.write(chunk)
        windows, rows = [(24,8)], []
        with destination.open('r+b') as target:
            for row in container['targets']:
                data = bytearray(checked(row['source']).read_bytes())
                original = bytes(data)
                for offset, file_id, path_id in row['edits']:
                    struct.pack_into('<iq', data, offset, file_id, path_id)
                # Constructing the expected data by only these typed writes is
                # the preservation proof; no shader field or program is edited.
                expected = bytearray(original)
                for offset, file_id, path_id in row['edits']:
                    expected[offset:offset+12] = struct.pack('<iq', file_id, path_id)
                need(data == expected, 'Only listed typed12B windows may change')
                target.seek(0,2)
                append = (target.tell()+15)&~15
                target.write(bytes(append-target.tell()))
                target.write(data)
                target.write(bytes((-target.tell())%8))
                table_offset = 48+container['table_start']+24*row['table_index']+8
                target.seek(table_offset)
                target.write(struct.pack('<qI', append-container['layout']['data_start'],len(data)))
                windows.append((table_offset,12))
                rows.append({'guid': row['guid'], 'path_id': row['mapping']['path_id'], 'new_absolute_offset': str(append),
                    'byte_size': str(len(data)), 'source_sha256': native.digest(original), 'mapped_payload_sha256': native.digest(data),
                    'typed_PPtr_edits': [{'offset': o,'file_id':f,'path_id':str(p)} for o,f,p in row['edits']]})
            target.seek(0,2)
            new_size = target.tell()
            need(new_size < 2**63, 'Native signed64 filesize bound')
            target.seek(24); target.write(struct.pack('>q',new_size))
        after, layout, table_start = metadata(destination)
        need(layout['data_start'] == container['layout']['data_start'] and table_start == container['table_start']
             and len(after['objects']) == len(container['parsed']['objects']), 'Native metadata/table/data boundaries must stay unchanged')
        mapped_by_id = {number(r['path_id']):r for r in rows}
        for before, obj in zip(container['parsed']['objects'],after['objects']):
            if before['path_id'] not in mapped_by_id:
                need(before == obj, 'Every nontarget native identity/range row must remain exact')
            else:
                proof = mapped_by_id[before['path_id']]
                need(obj['path_id'] == before['path_id'] and obj['type_index'] == before['type_index']
                     and obj['offset'] == number(proof['new_absolute_offset']) and obj['size'] == number(proof['byte_size']),
                     'Exact target table remap only')
                with destination.open('rb') as stream:
                    stream.seek(obj['offset']); readback = stream.read(obj['size'])
                need(native.digest(readback) == proof['mapped_payload_sha256'], 'Entire appended original mapped Shader persisted exactly')
        masked = mask_compare(path,destination,old_size,windows)
        need(native.pin(path) == container['pin'], 'Read-only original container changed')
        results.append({'input': container['pin'], 'output': native.pin(destination), 'objects': rows,
            'authorized_existing_file_edit_windows': windows, 'masked_original_prefix_sha256': masked,
            'every_other_preexisting_byte_exact': True, 'all_nontarget_object_rows_ranges_and_payloads_exact': True})
    return {'schema': 'streaming-original-Shader-native-append-patch-with-builtin-proof/v1',
        'status': 'explicit_original_Shader_payloads_streamed_with_only_proven_typed_PPtr_remaps',
        'containers': results, 'Shader_count': len(prepared), 'Main_modified': False,
        'Unity_launched': False, 'compiler_launched': False, 'runtime_or_GPU_tested': False,
        'builtin_output_edges_supported': True, 'builtin_material_mapping_report': plan['builtin_material_mapping_report'],
        'builtin_ids_required': sorted(BUILTIN_IDS), 'all_original_GPU_fields_unchanged_except_proved_dependency_PPtrs': True}


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument('--plan', required=True, type=Path)
    ap.add_argument('--plan-sha256', required=True)
    ap.add_argument('--output', required=True, type=Path)
    args = ap.parse_args()
    need(native.pin(args.plan)['sha256'] == args.plan_sha256, 'Explicit reviewed patch-plan SHA required')
    result = patch(json.loads(args.plan.read_bytes()),args.output)
    result['plan'] = native.pin(args.plan)
    result['tool'] = native.pin(Path(__file__))
    report = args.output/'streaming-patch-report.json'
    with report.open('x',encoding='utf-8') as stream:
        json.dump(result,stream,indent=2); stream.write('\n')
    print(json.dumps({'status': result['status'], 'report': native.pin(report)}))


if __name__ == '__main__':
    main()
