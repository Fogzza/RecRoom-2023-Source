"""Create NEW strict patcher sibling; the existing streaming patcher stays pinned."""
from pathlib import Path
import ast
import hashlib

HERE=Path(__file__).resolve().parent


def replacement(text,old,new):
    if text.count(old)!=1:raise ValueError('Unique reviewed source anchor absent: '+old[:80])
    return text.replace(old,new)


EXTENSION=r'''
def extend_external_metadata(spec, builtin_targets, player):
    """Append exactly one proved resources file row inside existing zero padding."""
    path, target = checked(spec['container']), checked(spec['target_container'])
    need(path.is_relative_to(player) and target.is_relative_to(player) and path != target
         and path.parent == target.parent and path.name == 'globalgamemanagers.assets' and target.name == 'resources.assets',
         'Only the explicit same-player GGM to resources native namespace extension is approved')
    need(any(row['container'] == spec['target_container'] for row in builtin_targets.values()),
         'New external target must be an actual Material-proved builtin Shader container')
    ideal = {'asset_path_hex':'', 'guid_hex':'0'*32, 'type':0, 'path_hex':b'resources.assets'.hex()}
    need(spec['appended_external_row'] == ideal, 'Only exact plain-relative zeroGUID actual resources target row')
    parsed, layout, table_start = metadata(path)
    need(ideal not in parsed['externals'] and spec['new_file_id'] == len(parsed['externals'])+1,
         'Exactly one new external at old count plus one; duplicate/reindexed rows refused')
    with path.open('rb') as stream:
        header = stream.read(48)
        size, total, data_start, unknown = struct.unpack_from('>IQQQ', header, 20)
        raw = stream.read(size)
        gap = stream.read(data_start-48-size)
    need(total == path.stat().st_size and unknown == 0 and size <= 16*1024**2
         and 0 <= len(gap) <= 1024**2 and gap == bytes(len(gap)), 'Bounded original all-zero metadata gap')
    specmod = importlib.util.spec_from_file_location('native_external_extension_parser', native.PARSER)
    parser = importlib.util.module_from_spec(specmod); specmod.loader.exec_module(parser)
    cursor = parser.Cursor(raw)
    cursor.pos = len(parsed['prefix'])+4+sum(len(t['raw']) for t in parsed['types'])+4
    for obj in parsed['objects']:
        cursor.align4()
        need((cursor.scalar('q'),cursor.scalar('q'),cursor.scalar('I'),cursor.scalar('i')) ==
             (obj['path_id'],obj['relative'],obj['size'],obj['type_index']), 'Exact original object-table traversal')
    scripts = cursor.count(100000)
    need(scripts == parsed['script_type_count'], 'Original script count')
    for _ in range(scripts):cursor.scalar('i');cursor.align4();cursor.scalar('q')
    count_at = cursor.pos; count = cursor.count(100000); rows = []
    for _ in range(count):
        rows.append({'asset_path_hex':cursor.cstr().hex(),'guid_hex':cursor.take(16).hex(),
                     'type':cursor.scalar('i'),'path_hex':cursor.cstr().hex()})
    need(rows == parsed['externals'], 'Every original external row decoded at exact original byte range')
    tail_at = cursor.pos; tail = raw[tail_at:]
    encoded = b'\0'+bytes(16)+struct.pack('<i',0)+b'resources.assets\0'
    expanded = raw[:count_at]+struct.pack('<i',count+1)+raw[count_at+4:tail_at]+encoded+tail
    need(len(expanded) == len(raw)+len(encoded) and 48+len(expanded) <= data_start,
         'New metadata must fit entirely in existing zero gap; data-offset relocation is outside scope')
    decoded = parser.parse_metadata(expanded,data_start,total)
    need(decoded['externals'] == parsed['externals']+[ideal], 'Preserved old external rows/order plus exact final new row')
    for key in ('engine','platform','has_type_tree','prefix','types','objects','script_type_count','ref_type_count','ref_types','user_raw'):
        need(decoded[key] == parsed[key], 'All non-external metadata fields exact: '+key)
    need(expanded[count_at+4:tail_at] == raw[count_at+4:tail_at]
         and expanded[tail_at+len(encoded):] == tail, 'Existing external raw bytes and complete trailing metadata byte-exact')
    proof = {'input_container':spec['container'],'target_container':spec['target_container'],
        'old_metadata_bytes':len(raw),'new_metadata_bytes':len(expanded),'inserted_external_bytes':len(encoded),
        'old_external_count':count,'new_external_count':count+1,'new_1based_file_id':count+1,
        'old_external_rows_raw_sha256':native.digest(raw[count_at+4:tail_at]),
        'existing_external_rows_and_order_byte_exact':True,'trailing_metadata_bytes':len(tail),
        'trailing_metadata_sha256':native.digest(tail),'trailing_metadata_shift_bytes':len(encoded),
        'data_offset_unchanged':True,'original_object_table_and_all_ranges_unchanged':True,
        'expanded_metadata_sha256':native.digest(expanded),'zero_gap_consumed_bytes':len(encoded),
        'all_other_parsed_metadata_exact':True}
    return {'parsed':decoded,'bytes':expanded,'old_raw':raw,'count_at':count_at,'tail_at':tail_at,
            'authorized_windows':[(20,4),(48+count_at,4),(48+tail_at,len(encoded)+len(tail))], 'proof':proof}


def checked_external_extensions(plan,builtin_targets,player):
    specs = plan['native_external_extensions']
    need(type(specs) is list and len(specs) == 1, 'Exactly one explicit isolated GGM resources extension')
    result = {}
    for spec in specs:
        path = checked(spec['container'])
        need(path not in result, 'No duplicate metadata extension')
        result[path] = extend_external_metadata(spec,builtin_targets,player)
    return result

'''


def main():
    source=HERE/'patch_original_shader_collection_with_builtins.py'
    if hashlib.sha256(source.read_bytes()).hexdigest()!='fbba70a207bf76f82f1257ef238e1b7c1858ae115b58f8fd1e8e47afd18b295f':raise ValueError('Pinned reviewed streaming patcher changed')
    text=source.read_text()
    text=replacement(text,'import hashlib\n','import hashlib\nimport importlib.util\n')
    text=replacement(text,'def preflight(plan):',EXTENSION+'\ndef preflight(plan):')
    text=text.replace('explicit-original-Shader-streaming-native-patch-with-builtin-Material-proof/v1','explicit-original-Shader-streaming-native-patch-with-one-proven-external/v1')
    text=replacement(text,'    builtin_targets = load_builtin_targets(plan, player)',
        '    builtin_targets = load_builtin_targets(plan, player)\n    extensions = checked_external_extensions(plan,builtin_targets,player)')
    text=replacement(text,"            containers[path] = {'pin': mapping['container'], 'parsed': parsed, 'layout': layout, 'table_start': start, 'targets': []}",
        "            extension = extensions.get(path)\n            if extension is not None: parsed = extension['parsed']\n            containers[path] = {'pin': mapping['container'], 'parsed': parsed, 'layout': layout, 'table_start': start, 'targets': [], 'metadata_extension':extension}")
    text=replacement(text,'    return player, containers, prepared','    need(set(extensions).issubset(containers), "Every planned metadata extension must belong to a selected Shader source container")\n    return player, containers, prepared')
    text=replacement(text,"        with destination.open('r+b') as target:\n            for row in container['targets']:",
        "        with destination.open('r+b') as target:\n            extension = container['metadata_extension']\n            if extension is not None:\n                target.seek(20);target.write(struct.pack('>I',len(extension['bytes'])))\n                target.seek(48);target.write(extension['bytes'])\n                windows += extension['authorized_windows']\n            for row in container['targets']:")
    text=replacement(text,"        mapped_by_id = {number(r['path_id']):r for r in rows}",
        "        need(after['externals'] == container['parsed']['externals'] and after['types'] == container['parsed']['types']\n             and after['prefix'] == container['parsed']['prefix'] and after['user_raw'] == container['parsed']['user_raw']\n             and after['script_type_count'] == container['parsed']['script_type_count']\n             and after['ref_type_count'] == container['parsed']['ref_type_count'], 'Actual expanded metadata fields must equal planned parsed view')\n        mapped_by_id = {number(r['path_id']):r for r in rows}")
    text=replacement(text,"results.append({'input': container['pin'], 'output': native.pin(destination), 'objects': rows,",
        "results.append({'input': container['pin'], 'output': native.pin(destination), 'objects': rows,\n            'metadata_extension': extension['proof'] if extension is not None else None,")
    text=text.replace('streaming-original-Shader-native-append-patch-with-builtin-proof/v1','streaming-original-Shader-native-append-patch-with-one-proven-external/v1')
    text=replacement(text,"'status': 'explicit_original_Shader_payloads_streamed_with_only_proven_typed_PPtr_remaps',",
        "'status': 'explicit_original_Shader_payloads_and_proven_one_row_external_extension_streamed',")
    ast.parse(text)
    target=HERE/'patch_original_shader_collection_with_external_extension.py'
    with target.open('x',encoding='utf-8',newline='\n') as stream:stream.write(text)
    print(str(target)+' '+hashlib.sha256(target.read_bytes()).hexdigest())


if __name__=='__main__':main()
