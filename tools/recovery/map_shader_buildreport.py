"""Pure, bounded Unity 2020.3 BuildReport/native Shader mapping.

No Unity or managed code is loaded. Type trees from the actual retained report
are the schema authority. Exact range corroboration is required; names are not
used to select native objects. Public numeric identities are emitted as strings.
"""
from pathlib import Path
import argparse
import hashlib
import importlib.util
import json
import re
import struct

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
PARSER = WS / 'Recovery/RecRoom-2023-04-18/AssetRecovery/OriginalFallbackNativeSerializedInput-20261022T205430Z-cab1d2e4/stage_input.py'
PARSER_SHA = '98b4cd637d310605981a57a7284660096dc4d2d4e8fa6b0f5240a41d4e2b02ae'
COMMON = WS / 'AR23Tool/Source/Source/AssetRipper.IO.Files/SerializedFiles/Parser/TypeTrees/CommonString.cs'


def need(value, message):
    if not value:
        raise ValueError(message)


def digest(data):
    return hashlib.sha256(data).hexdigest()


def pin(path):
    path = Path(path).resolve()
    with path.open('rb') as stream:
        value = hashlib.file_digest(stream, 'sha256').hexdigest()
    return {'path': str(path), 'bytes': path.stat().st_size, 'sha256': value}


def native(path, max_metadata=16 * 1024**2):
    path = Path(path).resolve()
    need(path.is_file() and not path.is_symlink(), 'Regular native file required')
    need(digest(PARSER.read_bytes()) == PARSER_SHA, 'Pinned native parser changed')
    spec = importlib.util.spec_from_file_location('shader_native_mapper_parser', PARSER)
    mod = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(mod)
    stat = path.stat()
    with path.open('rb') as stream:
        head = stream.read(48)
        need(len(head) == 48 and struct.unpack_from('>I', head, 8)[0] == 22,
             'Only genuine known v22 native files are supported')
        need(head[16:20] == bytes(4), 'Only little endian native files supported')
        size, total, start, unknown = struct.unpack_from('>IQQQ', head, 20)
        need(unknown == 0 and total == stat.st_size and 0 < size <= max_metadata
             and 48 + size <= start <= total, 'Bounded native header required')
        meta = stream.read(size)
    parsed = mod.parse_metadata(meta, start, total)
    need(path.stat().st_size == stat.st_size and path.stat().st_mtime_ns == stat.st_mtime_ns,
         'Native input changed while reading')
    return parsed, {'header_sha256': digest(head), 'metadata_sha256': digest(meta),
                    'data_start': start, 'engine': parsed['engine'], 'platform': parsed['platform']}


def tree(typ):
    raw = typ['raw']
    pos = 23 + (16 if typ['script_id'] is not None else 0)
    count, length = struct.unpack_from('<ii', raw, pos)
    pos += 8
    need(0 < count <= 100000 and 0 <= length <= 1024**2, 'Bounded native type tree')
    strings = raw[pos + count * 32:pos + count * 32 + length]
    common = {int(a): b for a, b in re.findall(r'\{(\d+),\s*"([^"\r\n]*)"\s*\}', COMMON.read_text())}
    def name(offset):
        if offset & 0x80000000:
            need((offset & 0x7fffffff) in common, 'Unknown common type-tree string')
            return common[offset & 0x7fffffff]
        need(offset < len(strings), 'Type-tree string offset out of bounds')
        end = strings.find(b'\0', offset)
        need(end >= offset, 'Unterminated type-tree string')
        return strings[offset:end].decode('utf-8')
    nodes = []
    for i in range(count):
        version, level, flags, ty, na, size, index, meta, ref = struct.unpack_from('<HBBIIiiiQ', raw, pos + 32*i)
        nodes.append({'type': name(ty), 'name': name(na), 'level': level,
                      'flags': flags, 'size': size, 'meta': meta, 'children': []})
    need(nodes[0]['level'] == 0, 'Single type-tree root required')
    stack = [nodes[0]]
    for node in nodes[1:]:
        while stack and stack[-1]['level'] >= node['level']:
            stack.pop()
        need(stack and stack[-1]['level'] + 1 == node['level'], 'Contiguous type-tree depth required')
        stack[-1]['children'].append(node)
        stack.append(node)
    return nodes[0]


class Reader:
    FORMATS = {'bool': '?', 'char': 'B', 'UInt8': 'B', 'SInt8': 'b',
               'short': 'h', 'SInt16': 'h', 'UInt16': 'H', 'unsigned short': 'H',
               'int': 'i', 'SInt32': 'i', 'UInt32': 'I', 'unsigned int': 'I',
               'long long': 'q', 'SInt64': 'q', 'UInt64': 'Q', 'unsigned long long': 'Q',
               'float': 'f', 'double': 'd', 'FileSize': 'Q'}
    def __init__(self, data):
        self.data, self.pos, self.items = data, 0, 0
    def take(self, length):
        need(0 <= length <= len(self.data) - self.pos, 'Type-tree object read out of bounds')
        start = self.pos
        self.pos += length
        return self.data[start:self.pos]
    def scalar(self, fmt):
        return struct.unpack('<' + fmt, self.take(struct.calcsize('<' + fmt)))[0]
    def align(self):
        self.take((-self.pos) % 4)
    def value(self, node):
        self.items += 1
        need(self.items <= 1000000, 'Object property limit exceeded')
        typ, kids = node['type'], node['children']
        if typ == 'string':
            size = self.scalar('i')
            need(0 <= size <= 1024**2, 'Bounded native string')
            val = self.take(size).decode('utf-8')
            self.align()
        elif typ == 'Array':
            need(len(kids) == 2 and kids[0]['name'] == 'size' and kids[1]['name'] == 'data', 'Exact array schema required')
            count = self.scalar('i')
            need(0 <= count <= 100000, 'Bounded native array')
            val = [self.value(kids[1]) for _ in range(count)]
        elif typ in self.FORMATS:
            need(not kids, 'Primitive with unexpected children')
            val = self.scalar(self.FORMATS[typ])
        elif kids:
            need(len({k['name'] for k in kids}) == len(kids), 'Duplicate native struct fields unsupported')
            val = {k['name']: self.value(k) for k in kids}
        else:
            need(0 <= node['size'] <= 4096, 'Unsupported variable leaf type: ' + typ)
            val = {'opaque_type': typ, 'hex': self.take(node['size']).hex()}
        if node['meta'] & 0x4000:
            self.align()
        return val


def decode_report(path):
    parsed, layout = native(path, 2 * 1024**2)
    need(parsed['has_type_tree'] and parsed['platform'] == -2,
         'Genuine Editor report type trees required')
    need(len(parsed['objects']) <= 10000, 'Bounded report objects')
    decoded = []
    with Path(path).open('rb') as stream:
        for obj in parsed['objects']:
            need(obj['size'] <= 16*1024**2, 'Bounded BuildReport object')
            typ = parsed['types'][obj['type_index']]
            root = tree(typ)
            stream.seek(obj['offset'])
            payload = stream.read(obj['size'])
            reader = Reader(payload)
            value = reader.value(root)
            need(reader.pos == len(payload), 'Entire actual report object must be consumed: ' + root['type'])
            decoded.append({'class_id': typ['class_id'], 'path_id': str(obj['path_id']),
                            'type': root['type'], 'object_sha256': digest(payload), 'value': value})
    return {'schema': 'native-Unity2020-BuildReport-decoded/v1', 'input': pin(path),
            'layout': layout, 'externals': parsed['externals'], 'objects': decoded, 'common_string_source': pin(COMMON),
            'native_parser': pin(PARSER)}


def unsigned(value, maximum=2**64-1):
    need(isinstance(value, str) and re.fullmatch(r'0|[1-9][0-9]*', value), 'Canonical invariant unsigned integer string required')
    number = int(value)
    need(number <= maximum, 'Unsigned identity overflow')
    return number


def corroborate(data, expected, player_root):
    """Join actual API records to exact native Class48 table id/offset/size.

    `expected` has guid + source_path, and optional count (default one).
    All fields come from actual API capture or its genuine type-tree adapter.
    Multiple output placements must be explicitly expected; duplicate native
    identities and unknown/missing expected GUIDs fail closed.
    """
    need(data['schema'] == 'Unity2020-actual-packed-Shader-API-records/v1', 'Actual API capture schema required')
    root = Path(player_root).resolve(strict=True)
    need(root.is_dir(), 'Exact isolated player root required')
    need(0 < len(expected) <= 10000 and len(data['files']) <= 100000 and len(data['shaders']) <= 100000,
         'Bounded expected/file/Shader records')
    wanted = {r['guid']: r for r in expected}
    need(len(wanted) == len(expected) and all(re.fullmatch('[0-9a-f]{32}', k) for k in wanted),
         'Unique canonical expected project GUIDs required')
    files = {}
    for row in data['files']:
        index = unsigned(row['id'])
        need(index not in files, 'Duplicate BuildFile identity')
        files[index] = row['path']
    found, used, containers = [], set(), {}
    for item in data['shaders']:
        if item['source_guid'] not in wanted:
            continue
        expectation = wanted[item['source_guid']]
        need(item['type'] == 'UnityEngine.Shader' and item['source_path'] == expectation['source_path'],
             'Exact expected source GUID/path/Shader type required')
        file_id, path_id = unsigned(item['file_id']), unsigned(item['id'], 2**63-1)
        offset, length = unsigned(item['offset']), unsigned(item['packed_size'], 2**32-1)
        need(file_id in files and path_id != 0 and length > 0, 'Known nonnull BuildFile/native object identity required')
        path = Path(files[file_id]).resolve(strict=True)
        need(path.is_relative_to(root) and path.is_file() and path.name == item['short_path'],
             'BuildFile path must resolve inside isolated player and match exact packed shortPath')
        key = (str(path), path_id)
        need(key not in used, 'Duplicate packed native target identity')
        used.add(key)
        if path not in containers:
            parsed, layout = native(path)
            need(parsed['platform'] == 19, 'Matching Windows player native platform required')
            containers[path] = (parsed, layout, pin(path))
        parsed, layout, filepin = containers[path]
        matches = [o for o in parsed['objects'] if o['path_id'] == path_id]
        need(len(matches) == 1, 'Exactly one native table object must match PackedAssetInfo.id')
        obj = matches[0]
        need(parsed['types'][obj['type_index']]['class_id'] == 48,
             'Native target must independently be Class48')
        need(obj['offset'] == offset and obj['size'] == length,
             'Actual packed offset/size must equal exact absolute native object range')
        need(length <= 32*1024**2, 'Bounded selected native Shader read')
        with path.open('rb') as stream:
            stream.seek(offset)
            payload = stream.read(length)
        need(len(payload) == length, 'Complete selected native object read')
        found.append({'guid': item['source_guid'], 'source_path': item['source_path'],
            'container': filepin, 'build_file_id': str(file_id), 'path_id': str(path_id),
            'absolute_offset': str(offset), 'byte_size': str(length), 'class_id': 48,
            'raw_sha256': digest(payload), 'native_layout': layout,
            'id_and_absolute_range_independently_corroborated': True,
            'name_used_as_identity_selector': False})
    for guid, expectation in wanted.items():
        need(sum(r['guid'] == guid for r in found) == expectation.get('count', 1),
             'Exact expected packed placement count required for ' + guid)
    return {'schema': 'GUID-to-native-Class48-BuildReport-corroboration/v1',
            'status': 'all_expected_GUID_native_id_absolute_offset_size_corroborated',
            'mappings': found, 'count': len(found), 'Main_modified': False,
            'Unity_launched': False, 'program_retention_or_rendering_claimed': False}


def capture_from_native(decoded, expected):
    """Adapt actual serialized report fields using independently pinned native GUID bytes.

    Textual GUID encoding is not guessed. Each expected native_guid_hex must
    come from the source-backed converter's genuine UnityGuid serialization.
    """
    reports = [o for o in decoded['objects'] if o['type'] == 'BuildReport' and o['class_id'] == 1125]
    need(len(reports) == 1, 'Exactly one genuine native BuildReport required')
    files = [{'id': str(r['id']), 'path': r['path']} for r in reports[0]['value']['m_Files']['Array']]
    by_native = {}
    for row in expected:
        raw = row['native_guid_hex']
        need(re.fullmatch('[0-9a-f]{32}', raw) and raw not in by_native,
             'Distinct source-backed native GUID bytes required')
        by_native[raw] = row
    entries = []
    for obj in decoded['objects']:
        if obj['type'] != 'PackedAssets':
            continue
        need(obj['class_id'] == 1126, 'Actual PackedAssets native class required')
        packed = obj['value']
        for item in packed['m_Contents']['Array']:
            typ = item['classID']
            need(typ['opaque_type'] == 'Type*' and len(bytes.fromhex(typ['hex'])) == 4,
                 'Exact native Type* class identifier width required')
            cls = struct.unpack('<i', bytes.fromhex(typ['hex']))[0]
            if cls != 48:
                continue
            native_guid = struct.pack('<IIII', *(item['sourceAssetGUID']['data[%d]' % i] for i in range(4))).hex()
            if native_guid not in by_native:
                continue
            expected_row = by_native[native_guid]
            entries.append({'file_id': str(packed['m_File']), 'short_path': packed['m_ShortPath'],
                'id': str(item['fileID']), 'offset': str(item['offset']), 'packed_size': str(item['packedSize']),
                'source_guid': expected_row['guid'], 'source_path': item['buildTimeAssetPath'], 'type': 'UnityEngine.Shader'})
    return {'schema': 'Unity2020-actual-packed-Shader-API-records/v1', 'files': files, 'shaders': entries,
            'adapter': 'actual_native_report_type_tree_fields_plus_proven_native_GUID_bytes',
            'actual_CSharp_API_capture_executed': False}


def extract_capture(source):
    keys = [key for key in ('packed_shader_build_report', 'packed_shader_capture') if key in source]
    need(len(keys) <= 1, 'Ambiguous nested packed Shader API reports refused')
    return source[keys[0]] if keys else source


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument('--decode-report')
    ap.add_argument('--api-report')
    ap.add_argument('--expected')
    ap.add_argument('--player-root')
    ap.add_argument('--out', required=True)
    args = ap.parse_args()
    need(bool(args.decode_report) != bool(args.api_report), 'Choose native decode or actual API report input')
    if args.decode_report:
        result = decode_report(Path(args.decode_report).resolve())
    else:
        need(args.expected and args.player_root, 'Expected GUID/path manifest and isolated player root required')
        source = json.loads(Path(args.api_report).read_bytes())
        result = corroborate(extract_capture(source), json.loads(Path(args.expected).read_bytes()), args.player_root)
    target = Path(args.out).resolve()
    with target.open('x', encoding='utf-8') as stream:
        json.dump(result, stream, indent=2)
        stream.write('\n')
    print(json.dumps({'status': result.get('status', 'decoded'), 'output': pin(target),
                      'object_or_mapping_count': len(result.get('objects', result.get('mappings', [])))}))


if __name__ == '__main__':
    main()
