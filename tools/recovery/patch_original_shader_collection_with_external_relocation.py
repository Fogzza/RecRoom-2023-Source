"""Strict pure-data Shader append patcher with explicit metadata/data relocation.

Every builtin binding requires the pinned four-ID actual Material/native chain.
Shader names never select targets. Project-target checks retain canonical identity proofs; old data bytes survive at one explicit positive16-aligned shift.
No complete player container is read into memory. Main/VerifiedSource are never
outputs; this creates new native files under AssetRecovery only.
"""
from pathlib import Path
import argparse
import hashlib
import importlib.util
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



def extend_external_metadata(spec, builtin_targets, player):
    """Append one proved resources row and relocate the complete old data block.

    All old gap bytes are retained. The explicit delta is16-aligned and includes
    the38B new row plus10B new zero padding, not a guessed object rewrite.
    """
    path,target=checked(spec['container']),checked(spec['target_container'])
    need(path.is_relative_to(player) and target.is_relative_to(player) and path!=target
        and path.parent==target.parent and path.name=='globalgamemanagers.assets' and target.name=='resources.assets',
        'Only isolated same-player GGM/resources relocation is reviewed')
    need(any(row['container']==spec['target_container'] for row in builtin_targets.values()),'Target must be actual typed-Material-proved builtin container')
    ideal={'asset_path_hex':'','guid_hex':'0'*32,'type':0,'path_hex':b'resources.assets'.hex()}
    need(spec['appended_external_row']==ideal,'Exact plain-relative zeroGUID resources row only')
    parsed,layout,table_start=metadata(path)
    need(ideal not in parsed['externals'] and spec['new_file_id']==len(parsed['externals'])+1,'No duplicate or reindexed original rows')
    with path.open('rb') as stream:
        header=stream.read(48);size,total,data_start,unknown=struct.unpack_from('>IQQQ',header,20)
        need(unknown==0 and total==path.stat().st_size and 0<size<=16*1024**2 and data_start%16==0
            and 0<=data_start-48-size<=1024**2,'Bounded aligned known native header')
        raw=stream.read(size);gap=stream.read(data_start-48-size)
    need(len(raw)==size and gap==bytes(len(gap)),'Entire original metadata and zero gap')
    parser_spec=importlib.util.spec_from_file_location('relocated_native_external_parser',native.PARSER)
    parser=importlib.util.module_from_spec(parser_spec);parser_spec.loader.exec_module(parser)
    cursor=parser.Cursor(raw);cursor.pos=len(parsed['prefix'])+4+sum(len(t['raw']) for t in parsed['types'])+4
    for obj in parsed['objects']:
        cursor.align4();need((cursor.scalar('q'),cursor.scalar('q'),cursor.scalar('I'),cursor.scalar('i'))==
            (obj['path_id'],obj['relative'],obj['size'],obj['type_index']),'Exact original object-table bytes')
    scripts=cursor.count(100000);need(scripts==parsed['script_type_count'],'Original script count exact')
    for _ in range(scripts):cursor.scalar('i');cursor.align4();cursor.scalar('q')
    count_at=cursor.pos;count=cursor.count(100000);rows=[]
    for _ in range(count):rows.append({'asset_path_hex':cursor.cstr().hex(),'guid_hex':cursor.take(16).hex(),'type':cursor.scalar('i'),'path_hex':cursor.cstr().hex()})
    need(rows==parsed['externals'],'Every original external row at exact original location')
    tail_at=cursor.pos;tail=raw[tail_at:];encoded=b'\0'+bytes(16)+struct.pack('<i',0)+b'resources.assets\0'
    delta=(len(encoded)+15)&~15;new_start=data_start+delta
    need(len(encoded)==38 and 0<=len(gap)<len(encoded),'Relocation only when actual gap cannot fit exact38B row')
    need(spec['expected_old_metadata_bytes']==len(raw) and spec['expected_old_data_offset']==data_start
        and spec['relocation_delta']==delta and spec['new_data_offset']==new_start,'Explicit source-derived old/new layout required')
    expanded=raw[:count_at]+struct.pack('<i',count+1)+raw[count_at+4:tail_at]+encoded+tail
    extra=delta-len(encoded)
    need(len(expanded)==len(raw)+len(encoded) and new_start==48+len(expanded)+len(gap)+extra
        and delta>0 and delta%16==0 and new_start%16==0,'Retain original gap plus explicit new zero alignment')
    decoded=parser.parse_metadata(expanded,new_start,total+delta)
    need(decoded['externals']==parsed['externals']+[ideal],'Old external order plus one exact final row')
    for key in ('engine','platform','has_type_tree','prefix','types','script_type_count','ref_type_count','ref_types','user_raw'):
        need(decoded[key]==parsed[key],'All other metadata semantic/raw fields exact: '+key)
    need(len(decoded['objects'])==len(parsed['objects']),'Object count preserved')
    for before,after in zip(parsed['objects'],decoded['objects']):
        expected=dict(before);expected['offset']+=delta
        need(after==expected,'Only every absolute object offset shifts; all relative table words remain exact')
    need(expanded[count_at+4:tail_at]==raw[count_at+4:tail_at] and expanded[tail_at+len(encoded):]==tail,
        'Existing raw external rows and full trailing metadata remain byte-exact')
    proof={'input_container':spec['container'],'target_container':spec['target_container'],'old_metadata_bytes':len(raw),'new_metadata_bytes':len(expanded),
        'old_data_offset':data_start,'new_data_offset':new_start,'data_relocation_delta':delta,'inserted_external_bytes':len(encoded),
        'retained_original_gap_bytes':len(gap),'new_explicit_zero_alignment_bytes':extra,'old_external_count':count,'new_external_count':count+1,
        'new_1based_file_id':count+1,'old_external_rows_raw_sha256':native.digest(raw[count_at+4:tail_at]),
        'existing_external_rows_and_order_byte_exact':True,'trailing_metadata_bytes':len(tail),'trailing_metadata_sha256':native.digest(tail),
        'trailing_metadata_shift_bytes':len(encoded),'original_object_table_relative_words_and_all_IDs_exact':True,
        'all_object_absolute_offsets_shift_by_explicit_delta':True,'expanded_metadata_before_target_remaps_sha256':native.digest(expanded),
        'all_other_parsed_metadata_exact':True,'relocation_is_not_an_absolute_range_preservation_claim':True}
    return {'parsed':decoded,'bytes':expanded,'old_raw':raw,'old_header':header,'old_gap':gap,'old_data_start':data_start,'new_data_start':new_start,
        'delta':delta,'extra_zero_padding':extra,'count_at':count_at,'tail_at':tail_at,'proof':proof}


def checked_external_extensions(plan,builtin_targets,player):
    specs = plan['native_external_extensions']
    need(type(specs) is list and len(specs) == 1, 'Exactly one explicit isolated GGM resources extension')
    result = {}
    for spec in specs:
        path = checked(spec['container'])
        need(path not in result, 'No duplicate metadata extension')
        result[path] = extend_external_metadata(spec,builtin_targets,player)
    return result


def preflight(plan):
    need(plan['schema'] == 'explicit-original-Shader-streaming-native-patch-with-proven-external-relocation/v1', 'Explicit builtin-aware streaming plan schema required')
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
    extensions = checked_external_extensions(plan,builtin_targets,player)
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
            extension = extensions.get(path)
            external_view = parsed['externals'] if extension is None else extension['parsed']['externals']
            containers[path] = {'pin': mapping['container'], 'parsed': parsed, 'namespace_externals':external_view, 'layout': layout, 'table_start': start, 'targets': [], 'metadata_extension':extension}
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
                    need(1 <= out_file <= len(container['namespace_externals']), 'Builtin cross-container FileID must already exist')
                    external = container['namespace_externals'][out_file-1]
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
                    need(1 <= out_file <= len(container['namespace_externals']), 'Cross-container FileID must already exist in native metadata')
                    external = container['namespace_externals'][out_file-1]
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
    need(len(containers)==len(extensions)==1 and set(extensions)==set(containers),
         "This narrow relocation requires exactly one selected GGM source container and its one proved extension")
    return player, containers, prepared


def compare_shifted_data(before,after,old_start,new_start,length):
    """Every original data byte survives at exactly the recorded positive shift."""
    need(0<=old_start<new_start and 0<=length<=before.stat().st_size-old_start,'Explicit bounded source data region')
    hashed=hashlib.sha256()
    with before.open('rb') as source,after.open('rb') as destination:
        source.seek(old_start);destination.seek(new_start);remaining=length
        while remaining:
            count=min(CHUNK,remaining);left=source.read(count);right=destination.read(count)
            need(len(left)==len(right)==count and left==right,'An original data byte changed or did not survive at exact delta')
            hashed.update(left);remaining-=count
    return hashed.hexdigest()


def patch(plan, output):
    player,containers,prepared=preflight(plan);output=Path(output).resolve(strict=True)
    need(output.is_dir() and output.is_relative_to(ROOT) and not any(output.iterdir())
        and not output.is_relative_to(player) and not player.is_relative_to(output),'Fresh empty recovery output outside source player')
    results=[]
    for path,container in containers.items():
        extension=container['metadata_extension']
        need(extension is not None,'This narrow relocation tool requires one selected source container with proven extension')
        destination=output/path.relative_to(player);destination.parent.mkdir(parents=True,exist_ok=True)
        old_size=path.stat().st_size;old_start=extension['old_data_start'];new_start=extension['new_data_start'];delta=extension['delta']
        header=bytearray(extension['old_header']);struct.pack_into('>Iqq',header,20,len(extension['bytes']),old_size+delta,new_start)
        with path.open('rb') as source,destination.open('xb') as target:
            target.write(header);target.write(extension['bytes']);target.write(extension['old_gap']);target.write(bytes(extension['extra_zero_padding']))
            need(target.tell()==new_start,'Exact predata output layout')
            source.seek(old_start)
            while chunk:=source.read(CHUNK):target.write(chunk)
            need(target.tell()==old_size+delta,'Every old data byte streamed once at exact positive shift')
        rows=[];expected_meta=bytearray(extension['bytes'])
        with destination.open('r+b') as target:
            for row in container['targets']:
                original=checked(row['source']).read_bytes();data=bytearray(original)
                for offset,file_id,path_id in row['edits']:struct.pack_into('<iq',data,offset,file_id,path_id)
                expected=bytearray(original)
                for offset,file_id,path_id in row['edits']:expected[offset:offset+12]=struct.pack('<iq',file_id,path_id)
                need(data==expected,'Only explicitly typed12B PPtr words may change original Release payload')
                target.seek(0,2);append=(target.tell()+15)&~15;target.write(bytes(append-target.tell()));target.write(data);target.write(bytes((-target.tell())%8))
                table_relative=container['table_start']+24*row['table_index']+8
                update=struct.pack('<qI',append-new_start,len(data));target.seek(48+table_relative);target.write(update);expected_meta[table_relative:table_relative+12]=update
                rows.append({'guid':row['guid'],'path_id':row['mapping']['path_id'],'new_absolute_offset':str(append),'byte_size':str(len(data)),
                    'source_sha256':native.digest(original),'mapped_payload_sha256':native.digest(data),
                    'typed_PPtr_edits':[{'offset':o,'file_id':f,'path_id':str(p)} for o,f,p in row['edits']]})
            target.seek(0,2);new_size=target.tell();need(new_size<2**63,'Signed64 native filesize bound');target.seek(24);target.write(struct.pack('>q',new_size))
        after,layout,table_start=metadata(destination)
        need(layout['data_start']==new_start and table_start==container['table_start'] and len(after['objects'])==len(container['parsed']['objects']),
            'New data offset explicit; table location/count unchanged')
        for key in ('externals','types','prefix','user_raw','script_type_count','ref_type_count','ref_types'):
            need(after[key]==extension['parsed'][key],'Exact planned metadata field: '+key)
        with destination.open('rb') as stream:
            actual_header=stream.read(48);actual_meta=stream.read(len(expected_meta));actual_gap=stream.read(len(extension['old_gap']));new_padding=stream.read(extension['extra_zero_padding'])
        final_header=bytearray(header);struct.pack_into('>q',final_header,24,new_size)
        need(actual_header==final_header and actual_meta==expected_meta,'Whole header/metadata equals original construction plus only named target range words')
        need(actual_gap==extension['old_gap'] and new_padding==bytes(extension['extra_zero_padding']),'Every original gap byte retained plus explicit new zero padding')
        by_id={number(r['path_id']):r for r in rows};nontargets=0
        for before,obj in zip(container['parsed']['objects'],after['objects']):
            if before['path_id'] not in by_id:
                expected=dict(before);expected['offset']+=delta
                need(obj==expected,'Every non-target ID/type/relative range exact and absolute offset shifts only by delta');nontargets+=1
            else:
                proof=by_id[before['path_id']]
                need(obj['path_id']==before['path_id'] and obj['type_index']==before['type_index'] and obj['offset']==number(proof['new_absolute_offset']) and obj['size']==number(proof['byte_size']),
                    'Only selected target range points to full appended original Shader')
                with destination.open('rb') as stream:stream.seek(obj['offset']);readback=stream.read(obj['size'])
                need(native.digest(readback)==proof['mapped_payload_sha256'],'Whole appended mapped original payload persisted exactly')
        data_hash=compare_shifted_data(path,destination,old_start,new_start,old_size-old_start)
        need(native.pin(path)==container['pin'],'Original input must remain byte-exact and read-only')
        results.append({'input':container['pin'],'output':native.pin(destination),'objects':rows,'metadata_relocation':extension['proof'],
            'whole_original_data_section_bytes':old_size-old_start,'whole_original_data_section_sha256':data_hash,
            'every_original_data_byte_exact_at_recorded_positive_shift':True,'all_nontarget_IDs_types_relative_ranges_and_payloads_exact':True,
            'nontarget_absolute_offsets_shift_only_by_recorded_delta':True,'nontarget_object_count':nontargets,
            'entire_metadata_equals_original_plus_external_insert_and_selected_range_words':True,
            'all_original_header_bytes_outside_explicit_size_and_dataOffset_fields_exact':True,'all_original_gap_bytes_retained':True})
    return {'schema':'streaming-original-Shader-native-append-patch-with-proven-external-data-relocation/v1',
        'status':'explicit_original_Shader_payloads_and_proven_external_metadata_data_relocation_streamed','containers':results,'Shader_count':len(prepared),
        'Main_modified':False,'Unity_launched':False,'compiler_launched':False,'runtime_or_GPU_tested':False,'builtin_output_edges_supported':True,
        'builtin_material_mapping_report':plan['builtin_material_mapping_report'],'builtin_ids_required':sorted(BUILTIN_IDS),
        'all_original_GPU_fields_unchanged_except_proved_dependency_PPtrs':True,
        'absolute_nontarget_range_preservation_claimed':False,'original_data_payload_preservation_at_explicit_shift_proved':True}


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
