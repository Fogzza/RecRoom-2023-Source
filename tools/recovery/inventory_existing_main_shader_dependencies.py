"""Bounded read-only Main dependency census; original-object identity is not inferred."""
from pathlib import Path
import argparse
import collections
import datetime as dt
import hashlib
import json
import re
import sys
import uuid
import run_windows_development_define_probe as guard

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
FOLDER = WS / 'RR23/Assets/Shader'
BUILTIN = '0000000000000000f000000000000000'
FALLBACK = 'd2a5536c48f6e914f900eb13ea2f4d68'
need = guard.need


def row(path):
    return {'path': str(path.resolve()), 'bytes': path.stat().st_size, 'sha256': guard.sha(path)}


def worker(out):
    results = []
    def digest(value): return hashlib.sha256(value).hexdigest()
    def block(tail, name):
        found = re.search(rb'(?ms)^  ' + name + rb':[^\n]*(?:\n(?!  [A-Za-z_])[^\n]*)*', tail)
        need(found is not None, 'Exact existing dependency field must fit bounded tail sample')
        return found.group(0)
    for path in sorted(FOLDER.glob('*.asset')):
        before = path.stat()
        meta = path.with_suffix('.asset.meta')
        meta_data = meta.read_bytes()
        guids = re.findall(rb'(?m)^guid: ([0-9a-f]{32})\r?$', meta_data)
        need(len(guids) == 1, 'Unique original Main meta GUID required')
        with path.open('rb') as stream:
            prefix = stream.read(min(8192, before.st_size))
            offset = max(0, before.st_size - 65536)
            stream.seek(offset)
            tail = stream.read(65536)
        names = re.findall(rb'(?m)^  m_Name: (.*)\r?$', prefix)
        need(len(names) == 1, 'Unique bounded Main YAML NamedObject field required')
        deps = block(tail, b'm_Dependencies')
        textures = block(tail, b'm_NonModifiableTextures')
        pointers = []
        for file_id, guid, kind in re.findall(rb'\{fileID: (-?[0-9]+), guid: ([0-9a-f]{32}), type: ([0-9]+)\}', deps):
            pointers.append({'local_file_id': int(file_id), 'guid': guid.decode(), 'YAML_type': int(kind)})
        need(deps.strip() == b'm_Dependencies: []' or pointers, 'No unparsed nonempty dependency block allowed')
        need(textures.strip() == b'm_NonModifiableTextures: {}', 'Unexpected Main Shader texture closure requires review')
        after = path.stat()
        need((before.st_size, before.st_mtime_ns) == (after.st_size, after.st_mtime_ns) and meta.read_bytes() == meta_data, 'Read-only Main samples must remain unchanged')
        results.append({'asset': str(path.resolve()), 'bytes': before.st_size, 'full_asset_sha256_computed': False,
                        'meta': row(meta), 'guid': guids[0].decode(), 'YAML_name_lexical_value': names[0].decode().rstrip('\r'),
                        'sampled_spans': [{'offset': 0, 'bytes': len(prefix), 'sha256': digest(prefix)}, {'offset': offset, 'bytes': len(tail), 'sha256': digest(tail)}],
                        'dependencies': pointers, 'nonmodifiable_texture_count': 0})
    need(len(results) == 179, 'Exact current Main Shader count required')
    by_guid = {item['guid']: item for item in results}
    need(len(by_guid) == len(results), 'Main Shader GUIDs must be unique')
    builtin_ids, external_guids = collections.Counter(), collections.Counter()
    for item in results:
        for pointer in item['dependencies']:
            if pointer['guid'] == BUILTIN and pointer['YAML_type'] == 0:
                pointer['classification'] = 'existing_Main_builtin_reference_native_encoding_not_yet_proved'
                builtin_ids[pointer['local_file_id']] += 1
            elif pointer['guid'] in by_guid and pointer['local_file_id'] == 4800000 and pointer['YAML_type'] == 2:
                pointer['classification'] = 'existing_Main_project_Shader_reference'
                pointer['target_asset'] = by_guid[pointer['guid']]['asset']
            else:
                pointer['classification'] = 'unresolved_existing_Main_reference'
                external_guids[pointer['guid']] += 1
    no_deps = sum(not item['dependencies'] for item in results)
    fallback_only = sum(item['dependencies'] == [{'local_file_id': 4800000, 'guid': FALLBACK, 'YAML_type': 2, 'classification': 'existing_Main_project_Shader_reference', 'target_asset': by_guid[FALLBACK]['asset']}] for item in results)
    report = {'schema': 'existing-Main-Shader-dependency-graph-source-comparison-only/v1', 'status': 'bounded_read_only_Main_dependency_graph_complete',
              'tool': row(Path(__file__)), 'shader_count': len(results), 'no_dependencies': no_deps, 'only_original_Fallback_dependency': fallback_only,
              'other_dependency_shapes': len(results) - no_deps - fallback_only, 'nonmodifiable_textures_empty_for_all': True,
              'builtin_local_id_edge_counts': dict(builtin_ids), 'unresolved_guid_edge_counts': dict(external_guids), 'shaders': results,
              'Main_modified': False, 'Unity_launched': False, 'compiler_launched': False, 'native_API_executed': False,
              'limitations': ['Existing YAML dependency identity is comparison evidence, not proof of original source PPtr namespace resolution.', 'Builtin reference GUID/native external encoding and original source target identities require genuine source metadata corroboration.', 'Entire original Shader object matching, ParsedForm equivalence and cooked-program provenance are supplied by a separate census.']}
    target = out / 'data-report.json'
    with target.open('x', encoding='utf-8') as stream: json.dump(report, stream, indent=2); stream.write('\n')


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--worker', type=Path)
    args = parser.parse_args()
    if args.worker:
        out = args.worker.resolve(strict=True)
        need(out.is_relative_to(ROOT / 'AssetRecovery'), 'Fresh recovery report output only')
        worker(out)
        return
    out = ROOT / 'AssetRecovery' / ('ExistingMainShaderDependencyGraph-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'guarded-read-only-Main-Shader-dependency-graph/v1', 'status': 'starting', 'phases': [], 'Main_modified': False, 'Editor_launched': False, 'compiler_launched': False}
    try:
        guard.bounded([sys.executable, '-B', str(Path(__file__).resolve()), '--worker', str(out)], WS, out, 'read-bounded-existing-Main-Shader-tails', 128 * 1024**2, 30, report)
        report.update(status='bounded_Main_dependency_graph_complete', data=row(out / 'data-report.json'))
    except BaseException as error: report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'receipt': row(out / 'run-report.json'), 'data': report.get('data'), 'error': report.get('error')}))


if __name__ == '__main__': main()
