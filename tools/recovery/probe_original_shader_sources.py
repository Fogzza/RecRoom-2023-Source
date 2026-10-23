"""Targeted read-only original shader source/compiled-blob provenance probe.

Uses the existing verified raw object index; does not rescan/export all bundles.
Only three likely native containers' metadata and ClassID48 names are read.
"""
import hashlib
import json
import re
import struct
import sys
from datetime import datetime, timezone
from pathlib import Path
from uuid import uuid4
from stage_original_native_sdk_dependencies import ROOT, SOURCE, WS, sha, need, regular

sys.path.insert(0, str(ROOT/'Tools'))
from native_dependencies import Cursor
sys.path.insert(0, str(WS/'Tools/RecoveryTools'))
from metadata_projection_subset import array_rows

RAW = ROOT/'RawUnityFSRecovery/VerifiedAll-20261022T133109Z-2e17e8f8'
CATALOG = ROOT/'BundleInventory/Run-20261022T005620Z-05f26ec1/catalog.json'
DEPENDENCIES = CATALOG.with_name('dependencies.json')
TARGETS = {'AG/Standard-Opaque', 'Hidden/Universal Render Pipeline/StencilDeferred'}

def h(data):
    return hashlib.sha256(data).hexdigest()
def native_objects(path):
    regular(path)
    size = path.stat().st_size
    with path.open('rb') as stream:
        header = stream.read(48)
        meta_size, declared, version, data_start = struct.unpack_from('>IIII', header)
        head_size = 20
        if version >= 22:
            meta_size, declared, data_start, _ = struct.unpack_from('>IQQQ', header, 20)
            head_size = 48
        need(17 <= version <= 22 and declared == size and 0 < meta_size <= 16*1024*1024 and meta_size <= data_start-head_size, 'Bounded native metadata header required')
        stream.seek(head_size)
        metadata = stream.read(meta_size)
    c = Cursor(metadata, '>' if header[16] else '<')
    engine, platform, has_tree = c.string(), c.read('i'), c.read('B') != 0
    classes = []
    for _ in range(c.count(100000)):
        cls = c.read('i')
        classes.append(cls)
        c.skip(3)
        if cls == 114:
            c.skip(16)
        c.skip(16)
        if has_tree:
            nodes, strings = c.count(1000000), c.count(64*1024*1024)
            c.skip(nodes*(32 if version >= 19 else 24)+strings)
        if has_tree and version >= 21:
            c.skip(c.count(1000000)*4)
    shaders = []
    objects = c.count(1000000)
    for _ in range(objects):
        c.align4()
        path_id = c.read('q')
        relative = c.read('q' if version >= 22 else 'I')
        length, type_index = c.read('Ii')
        need(0 <= type_index < len(classes) and data_start+relative+length <= size, 'Bounded object/type identity')
        if classes[type_index] == 48:
            shaders.append({'path_id': str(path_id), 'byte_offset': data_start+relative, 'byte_size': length, 'class_id': 48})
    return {'engine': engine, 'platform': platform, 'metadata_bytes': meta_size, 'object_count': objects, 'shader_objects': shaders, 'endian': c.endian}

def object_name(path, row, endian='<'):
    with path.open('rb') as stream:
        stream.seek(row['byte_offset'])
        prefix = stream.read(min(row['byte_size'], 512))
    need(len(prefix) >= 4, 'Object name header bounds')
    count = struct.unpack_from(endian+'i', prefix)[0]
    need(0 <= count <= min(508, row['byte_size']-4), 'Class48 NamedObject first-field bounds')
    return prefix[4:4+count].decode('utf-8')

def selected_name_candidate(path, row, first_name):
    if first_name in TARGETS:
        return first_name, 'actual leading NamedObject string'
    if first_name:
        return None, None
    # Player shaders often store an empty NamedObject string and their display
    # name later in ParsedForm. Search is discovery only, never acceptance of
    # a guessed field layout or a replacement shader identity.
    need(row['byte_size'] <= 32*1024*1024, 'Shader discovery payload bound')
    with path.open('rb') as stream:
        stream.seek(row['byte_offset'])
        data = stream.read(row['byte_size'])
    matches = [name for name in TARGETS if struct.pack('<i', len(name.encode()))+name.encode() in data]
    need(len(matches) <= 1, 'Ambiguous requested shader-name pattern')
    return (matches[0], 'exact length-prefixed name pattern within Class48 payload; ParsedForm field ownership not yet decoded') if matches else (None, None)

def main():
    inventory = {row[0]: {'bytes': row[1], 'sha256': row[2]} for row in json.loads((ROOT/'Preflight/public-archive-inventory.json').read_bytes())['files']}
    selected, shader_rows, native_containers = [], [], []
    for basename in ['globalgamemanagers.assets', 'resources.assets', 'sharedassets0.assets']:
        source = SOURCE/'RecRoom_Data'/basename
        table = native_objects(source)
        native_containers.append({'path': str(source), 'expected_original_sha256': inventory['RecRoom_Data/'+basename]['sha256'],
            'full_container_rehash_this_probe': False, 'metadata_bytes_read': table['metadata_bytes'], 'shader_count': len(table['shader_objects'])})
        for obj in table['shader_objects']:
            name = object_name(source, obj, table['endian'])
            row = {'origin': 'original_native_container', 'source_file': str(source), 'source_path': str(source), 'name': name, **obj}
            shader_rows.append(row)
            target, evidence = selected_name_candidate(source, obj, name)
            if target:
                selected.append({**row, 'name': target, 'name_discovery_evidence': evidence})
    # Filter only existing Class48 rows before decoding JSON (the full verified
    # object index is streamed, never materialized or rebuilt).
    originals = []
    with (RAW/'original-objects.jsonl').open('rb') as stream:
        for line in stream:
            if b'"class_id":48,' in line:
                originals.append(json.loads(line))
    need(len(originals) == 92, 'Exact prior verified 92 bundle Shader objects')
    wanted_nodes = {(row['source_bundle'], row['source_file']) for row in originals}
    node_paths = {}
    with (RAW/'verified-nodes.jsonl').open('rb') as stream:
        for line in stream:
            row = json.loads(line)
            key = (row['source_bundle'], row['source_file'])
            if key in wanted_nodes:
                node_paths[key] = row
    for obj in originals:
        node = node_paths[(obj['source_bundle'], obj['source_file'])]
        source = regular(Path(node['path']))
        need(source.stat().st_size == node['bytes'] and node['sha256'] == obj['source_node_sha256'], 'Exact verified raw node identity')
        name = object_name(source, obj)
        row = {'origin': 'verified_original_bundle', 'source_path': str(source), 'name': name, **obj}
        shader_rows.append(row)
        target, evidence = selected_name_candidate(source, obj, name)
        if target:
            selected.append({**row, 'name': target, 'name_discovery_evidence': evidence})
    programs = []
    for shader_name, basename in [('AG/Standard-Opaque', 'AG_Standard-Opaque.asset'), ('Hidden/Universal Render Pipeline/StencilDeferred', 'Hidden_Universal Render Pipeline_StencilDeferred.asset')]:
        path = WS/'RR23/Assets/Shader'/basename
        if not path.exists():
            # Discovery by exact serialized m_Name is acceptable; no source
            # identity is accepted until the original compressed blob matches.
            candidates = []
            expected_name = b'  m_Name: '+shader_name.encode()+b'\n'
            for other in (WS/'RR23/Assets/Shader').glob('*.asset'):
                with other.open('rb') as stream:
                    prefix = stream.read(2048).replace(b'\r\n', b'\n')
                if expected_name in prefix:
                    candidates.append(other)
            need(len(candidates) == 1, 'One exact current Shader serialized name required')
            path = candidates[0]
        data = path.read_bytes()
        digest = h(data)
        match = re.search(rb'(?m)^  compressedBlob: ([0-9a-f]*)\r?$', data)
        need(match is not None, 'Current shader compressed blob required')
        blob = bytes.fromhex(match[1].decode('ascii'))
        matches = []
        for obj in selected:
            if obj['name'] != shader_name:
                continue
            need(obj['byte_size'] <= 16*1024*1024, 'Selected original shader payload bounded')
            with Path(obj['source_path']).open('rb') as stream:
                stream.seek(obj['byte_offset'])
                original = stream.read(obj['byte_size'])
            offset = original.find(blob) if blob else -1
            equal = bool(blob) and offset >= 4 and struct.unpack_from('<i', original, offset-4)[0] == len(blob) and original.count(blob) == 1
            matches.append({'original_object': obj, 'whole_original_object_sha256': h(original),
                'current_compressed_program_blob_is_exact_original_length_prefixed_range': equal,
                'original_blob_absolute_offset': obj['byte_offset']+offset if equal else None})
        need(sha(path) == digest, 'Current shader changed during read-only probe')
        programs.append({'name': shader_name, 'current_asset': str(path), 'current_asset_sha256': digest,
            'compressed_blob_bytes': len(blob), 'compressed_blob_sha256': h(blob), 'partial_CB_yaml_rows': data.count(b'm_IsPartialCB: 1'), 'original_source_candidates': matches})
    target_bundles = {row['source_bundle'] for row in selected if row['origin'] == 'verified_original_bundle'}
    bundle_rows = [row for row in array_rows(CATALOG, 'bundles') if row['bundle'] in target_bundles]
    dependency_rows = [row for row in array_rows(DEPENDENCIES, 'bundles') if row.get('bundle') in target_bundles]
    log = ROOT/'Validation/EditorRetry-20261022T035152Z-cedfda59/Editor.log'
    errors = log.read_text(encoding='utf-8-sig', errors='replace')
    report = {'schema': 'targeted-original-shader-source-and-compiled-blob-probe/v1', 'status': 'read_only_probe_complete',
        'native_containers': native_containers, 'bundle_class48_count_from_verified_index': len(originals), 'known_shader_names_and_native_identity': shader_rows,
        'selected_shaders': programs, 'selected_bundle_catalog': bundle_rows, 'selected_bundle_dependencies': dependency_rows,
        'prior_import_errors': {'path': str(log), 'sha256': sha(log), 'partial_constant_buffer_not_found': errors.count('Partial constant buffer not found.'), 'expected_binary_shader_data_failure': errors.count('Failed to find expected binary shader data')},
        'full_native_file_hash_revalidated_this_probe': False, 'original_raw_node_index_reused_not_reexported': True,
        'original_compiled_shader_source_HLSL_recovery_claimed': False, 'Main_modified': False, 'Unity_launched': False, 'original_client_executed': False}
    out = ROOT/'AssetRecovery'/('OriginalShaderSourceProbe-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid4().hex[:8])
    out.mkdir()
    path = out/'report.json'
    path.write_text(json.dumps(report, indent=2)+'\n')
    print(json.dumps({'report': str(path), 'sha256': sha(path), 'shader_objects_inspected': len(shader_rows), 'target_source_candidates_pending_schema_identity': len(selected), 'original_program_blob_equalities': sum(item['current_compressed_program_blob_is_exact_original_length_prefixed_range'] for row in programs for item in row['original_source_candidates']), 'target_bundles': len(target_bundles)}))
if __name__ == '__main__':
    main()
