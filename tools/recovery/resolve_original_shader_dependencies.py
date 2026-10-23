"""Bounded existing-parser metadata-only resolution of three original Shader PPtrs."""
from pathlib import Path
import datetime as dt
import hashlib
import importlib.util
import json
import struct
import sys
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
BASE = ROOT / 'VerifiedSource/RecRoom_Data'
PARSER = ROOT / 'AssetRecovery/OriginalFallbackNativeSerializedInput-20261022T205430Z-cab1d2e4/stage_input.py'


def sha(data):
    return hashlib.sha256(data).hexdigest()


def worker(out):
    assert sha(PARSER.read_bytes()) == '98b4cd637d310605981a57a7284660096dc4d2d4e8fa6b0f5240a41d4e2b02ae'
    spec = importlib.util.spec_from_file_location('exact_existing_metadata_parser', PARSER)
    parser = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(parser)

    def read(path):
        before = path.stat()
        with path.open('rb') as stream:
            header = stream.read(48)
            assert len(header) == 48 and struct.unpack_from('>IIII', header) == (0, 0, 22, 0) and header[16:20] == bytes(4)
            size, total, start, unknown = struct.unpack_from('>Iqqq', header, 20)
            assert unknown == 0 and total == before.st_size and 0 < size <= 16 * 1024**2 and 48 + size <= start <= total
            metadata = stream.read(size)
            assert len(metadata) == size
        parsed = parser.parse_metadata(metadata, start, total)
        assert parsed['engine'] == '2020.3.33f1' and parsed['platform'] == 19 and not parsed['has_type_tree']
        assert (path.stat().st_size, path.stat().st_mtime_ns) == (before.st_size, before.st_mtime_ns)
        return parsed, {'path': str(path), 'file_bytes': total, 'header_sha256': sha(header), 'metadata_bytes_read': size, 'metadata_sha256': sha(metadata), 'engine': parsed['engine'], 'platform': parsed['platform'], 'serialized_version': 22, 'full_container_read_or_hash': False, 'entire_metadata_parsed': True}

    source = BASE / 'resources.assets'
    parsed, source_info = read(source)
    shaders = []
    for identity in (6351, 6286, 6358):
        matches = [o for o in parsed['objects'] if o['path_id'] == identity]
        assert len(matches) == 1
        obj = matches[0]
        typ = parsed['types'][obj['type_index']]
        assert typ['class_id'] == 48 and typ['old_type_hash'] == 'a30e3dcf6c6d25153d6f64e5e41caf4e'
        with source.open('rb') as stream:
            stream.seek(obj['offset'] + obj['size'] - 24)
            tail = stream.read(24)
        assert tail == struct.pack('<iiqii', 1, 1, 32, 0, 1)
        shaders.append(dict(obj, class_id=48, dependency_count=1, dependency={'file_id': 1, 'path_id': 32}, nonmodifiable_texture_count=0, shader_is_baked=True, exact_last24_bytes=tail.hex()))
    ext = parsed['externals'][0]
    external = {'one_based_row': 1, 'asset_path': bytes.fromhex(ext['asset_path_hex']).decode(), 'guid_hex': ext['guid_hex'], 'type': ext['type'], 'path': bytes.fromhex(ext['path_hex']).decode()}
    assert external == {'one_based_row': 1, 'asset_path': '', 'guid_hex': '00000000000000000000000000000000', 'type': 0, 'path': 'globalgamemanagers.assets'}
    # Original metadata is no longer needed before the second native table read.
    del parsed
    destination = BASE / external['path']
    parsed, dest_info = read(destination)
    matches = [o for o in parsed['objects'] if o['path_id'] == 32]
    assert len(matches) == 1
    obj = matches[0]
    typ = parsed['types'][obj['type_index']]
    assert typ['class_id'] == 48 and obj['offset'] == 2413648 and obj['size'] == 3656
    with destination.open('rb') as stream:
        stream.seek(obj['offset'])
        raw = stream.read(obj['size'])
    assert len(raw) == 3656 and sha(raw) == '9d68229325a824a746e3dcdca644dc7d5eb9c3677d724b118697785d8c714300'
    assert sha((PARSER.parent / 'report.json').read_bytes()) == '9e615d45be84597747ffa9094ba904ccb4a6977be7b86a8a893a1160597cc423'
    report = {'schema': 'exact-original-shader-external-dependency-resolution/v1', 'status': 'all_three_unique_Class48_dependencies_resolve_to_exact_original_FallbackError_Path32', 'source': source_info, 'source_shaders': shaders, 'external_row': external, 'destination': dest_info, 'destination_object': dict(obj, class_id=48, old_type_hash=typ['old_type_hash'], sha256=sha(raw)), 'destination_identity_and_closure_receipt': {'path': str(PARSER.parent / 'report.json'), 'sha256': '9e615d45be84597747ffa9094ba904ccb4a6977be7b86a8a893a1160597cc423'}, 'Main_modified': False, 'Unity_launched': False, 'compiler_launched': False, 'game_or_native_code_executed': False, 'selection_by_name_alone': False}
    (out / 'report.json').write_text(json.dumps(report, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'status': report['status'], 'report': str(out / 'report.json')}), flush=True)
    return 0


def main():
    if len(sys.argv) == 3 and sys.argv[1] == '--worker':
        return worker(Path(sys.argv[2]))
    assert len(sys.argv) == 1
    out = ROOT / 'AssetRecovery' / ('OriginalShaderDependencyResolution-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    import read_original_ag_shader_models as guard
    guard.CAP = 256 * 1024**2
    run = guard.phase([sys.executable, '-B', str(Path(__file__).resolve()), '--worker', str(out)], out, 'existing-parser-original-dependency-resolution')
    (out / 'outer-job-report.json').write_text(json.dumps(run, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'report': str(out / 'report.json'), 'job_report': str(out / 'outer-job-report.json'), 'exit_code': run.get('exit_code'), 'peak_job_bytes': run.get('peak_job_bytes'), 'error': run.get('error')}), flush=True)
    return 0 if run.get('exit_code') == 0 and not run.get('error') else 1


if __name__ == '__main__':
    raise SystemExit(main())
