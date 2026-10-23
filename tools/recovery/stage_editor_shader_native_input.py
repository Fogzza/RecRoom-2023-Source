"""Pure bounded metadata capture / singleton wrapper; no Unity or managed code."""
from pathlib import Path
import argparse
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
SOURCE = WS / 'Tools/Editors/2020.3.33f1/Editor/Data/Resources/unity_builtin_extra'
PREVIOUS = ROOT / 'AssetRecovery/OriginalFallbackNativeSerializedInput-20261022T205430Z-cab1d2e4'
PARSER = PREVIOUS / 'stage_input.py'
SOURCE_PROOF = PREVIOUS / 'report.json'
TYPE_SHA = '0fbf2d2f8e6c2b23f21468a5a0528d28f361ca32775a5dec12d72f1f3a093171'
RELEASE_SHA = '9d68229325a824a746e3dcdca644dc7d5eb9c3677d724b118697785d8c714300'
BLOB_SHA = '9b790d373ca12221c4cc3b81efab7712e70687d0ddf443db242a5dadc4c5cfbc'


def need(value, message):
    if not value:
        raise ValueError(message)


def digest(data):
    return hashlib.sha256(data).hexdigest()


def pin(path):
    need(path.is_file() and path.stat().st_size <= 16 * 1024**2, 'Bounded regular report/data input required')
    return {'path': str(path.resolve()), 'bytes': path.stat().st_size, 'sha256': digest(path.read_bytes())}


def load_parser():
    need(pin(PARSER)['sha256'] == '98b4cd637d310605981a57a7284660096dc4d2d4e8fa6b0f5240a41d4e2b02ae', 'Pinned existing pure metadata parser changed')
    spec = importlib.util.spec_from_file_location('existing_singleton_metadata_parser', PARSER)
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    return module


def inspect_source(out, parser):
    before = SOURCE.stat()
    need(before.st_size == 131446287, 'Genuine same-version Editor builtin file size changed')
    with SOURCE.open('rb') as stream:
        header = stream.read(48)
        need(len(header) == 48 and struct.unpack_from('>IIII', header) == (0, 0, 22, 0), 'Exact genuine v22 header required')
        need(header[16:20] == bytes(4), 'Little endian / genuine reserved header bytes required')
        size, declared, start, unknown = struct.unpack_from('>Iqqq', header, 20)
        need(declared == before.st_size and unknown == 0 and 0 < size <= 16 * 1024**2 and 48 + size <= start <= declared, 'Bounded exact genuine Editor metadata header')
        metadata = stream.read(size)
        need(len(metadata) == size, 'Complete bounded metadata capture required')
    parsed = parser.parse_metadata(metadata, start, declared)
    need(parsed['engine'] == '2020.3.33f1' and parsed['platform'] == -2 and parsed['has_type_tree'], 'Genuine full Editor layout is required')
    typ = parsed['types'][0]
    need(typ['index'] == 0 and typ['class_id'] == 48 and typ['script_type_index'] == -1 and typ['script_id'] is None and typ['stripped'] == 0, 'Exact first Editor Shader native type identity')
    need(typ['old_type_hash'] == '888994cda549cb3b5380e3be28b6cd6d' and len(typ['raw']) == 84260 and digest(typ['raw']) == TYPE_SHA, 'Genuine Editor Shader metadata/tree bytes changed')
    need(not typ['type_dependencies'], 'Cannot omit unresolved Editor type dependencies')
    after = SOURCE.stat()
    need((before.st_size, before.st_mtime_ns) == (after.st_size, after.st_mtime_ns), 'Genuine source changed during bounded read')
    for name, data in [('genuine-header.bin', header), ('genuine-metadata.bin', metadata), ('genuine-Shader-type0.bin', typ['raw'])]:
        with (out / name).open('xb') as stream:
            stream.write(data)
    info = {k: v for k, v in typ.items() if k != 'raw'}
    info.update(raw_bytes=len(typ['raw']), raw_sha256=digest(typ['raw']))
    report = {'path': str(SOURCE), 'file_bytes': before.st_size, 'full_source_hash_computed': False,
              'read_spans': [{'offset': 0, 'bytes': 48}, {'offset': 48, 'bytes': size}],
              'header_sha256': digest(header), 'metadata_sha256': digest(metadata),
              'engine': parsed['engine'], 'platform': parsed['platform'], 'has_type_tree': True,
              'source_type_count': len(parsed['types']), 'source_object_count': len(parsed['objects']),
              'source_script_type_count': parsed['script_type_count'], 'source_external_count': len(parsed['externals']),
              'source_reference_type_count': parsed['ref_type_count'], 'source_user_information_hex': parsed['user_raw'].hex(),
              'selected_type': info}
    return header, parsed, typ, report


def checked_payload(args):
    need(args.payload and args.payload_sha and args.converter_report and args.converter_report_sha, 'All converter payload/report paths and expected hashes are required')
    payload = args.payload.resolve(strict=True)
    report_path = args.converter_report.resolve(strict=True)
    need(payload.is_relative_to(ROOT / 'AssetRecovery') and report_path.is_relative_to(ROOT / 'AssetRecovery'), 'Converter files must remain in recovery staging outside Main')
    payload_pin, report_pin = pin(payload), pin(report_path)
    need(payload_pin['sha256'] == args.payload_sha and report_pin['sha256'] == args.converter_report_sha, 'Pinned converter payload/report changed')
    need(3656 < payload_pin['bytes'] <= 8 * 1024**2, 'Bounded Editor payload with actual Editor-only additions required')
    report = json.loads(report_path.read_bytes())
    need(report.get('schema') == 'original-shader-generated-Editor-layout-roundtrip/v1' and report.get('status') == 'all_original_release_bytes_and_program_fields_preserved_in_Editor_roundtrip', 'Exact successful converter schema/status required')
    need(report.get('engine') == '2020.3.33f1' and report.get('name') == 'Hidden/Universal Render Pipeline/FallbackError', 'Exact source32 fallback/version required')
    need(report.get('source_bytes') == report.get('release_consumed_bytes') == 3656 and report.get('source_sha256') == report.get('release_reserialized_sha256') == RELEASE_SHA, 'Whole original release bytes/consumption proof required')
    need(report.get('editor_bytes') == report.get('editor_consumed_bytes') == payload_pin['bytes'] and report.get('editor_sha256') == payload_pin['sha256'], 'Entire Editor payload readback/hash proof required')
    need(report.get('entire_release_object_byte_exact') is True and report.get('entire_ParsedForm_equal') is True and report.get('native_api_executed') is False and report.get('Main_modified') is False, 'Exact pure-data preservation assertions required')
    need(report.get('original_program_fields', {}).get('compressedBlob') == {'bytes': 991, 'sha256': BLOB_SHA}, 'Exact full original compiled blob proof required')
    proof_pin = pin(SOURCE_PROOF)
    need(proof_pin['sha256'] == '9e615d45be84597747ffa9094ba904ccb4a6977be7b86a8a893a1160597cc423', 'Pinned original source32 pointer-closure receipt changed')
    proof = json.loads(SOURCE_PROOF.read_bytes())
    closure = proof['closure']
    need(proof['original_selected_object']['sha256'] == RELEASE_SHA and closure['dependency_count'] == closure['nonmodifiable_texture_count'] == 0 and closure['shader_is_baked'] and closure['original_blob_sha256'] == BLOB_SHA, 'Self-contained exact original release object closure required')
    return payload.read_bytes(), {'payload': payload_pin, 'report': report_pin, 'original_release_pointer_closure': proof_pin}


def make_wrapper(header, parsed, typ, payload, parser):
    metadata = bytearray(parsed['prefix'])
    metadata += struct.pack('<i', 1) + typ['raw']
    metadata += struct.pack('<i', 1)
    metadata += bytes((-len(metadata)) % 4)
    metadata += struct.pack('<qqIi', 4800000, 0, len(payload), 0)
    metadata += struct.pack('<iii', 0, 0, 0)
    metadata += parsed['user_raw']
    start = (48 + len(metadata) + 15) & ~15
    data = payload + bytes((-len(payload)) % 8)
    size = start + len(data)
    output_header = bytearray(header)
    struct.pack_into('>Iqq', output_header, 20, len(metadata), size, start)
    need(output_header[:20] == header[:20] and output_header[40:] == header[40:], 'Only genuine header metadata/file/data sizes may change')
    result = bytes(output_header) + metadata + bytes(start - 48 - len(metadata)) + data
    verify = parser.parse_metadata(bytes(metadata), start, size)
    need(verify['prefix'] == parsed['prefix'] and verify['user_raw'] == parsed['user_raw'] and len(verify['types']) == len(verify['objects']) == 1, 'Genuine prefix/user info and singleton table roundtrip')
    need(verify['types'][0]['raw'] == typ['raw'], 'Every genuine Editor Shader metadata/tree byte must survive unchanged')
    need(verify['script_type_count'] == len(verify['externals']) == verify['ref_type_count'] == 0, 'No script, external or reference-type tables permitted')
    obj = verify['objects'][0]
    need(obj['path_id'] == 4800000 and obj['type_index'] == 0 and result[obj['offset']:obj['offset'] + obj['size']] == payload, 'Exact entire converted Editor object with table-only identity4800000')
    return result, {'metadata_bytes': len(metadata), 'data_offset': start, 'file_bytes': size, 'class_ids': [48], 'path_ids': [4800000], 'object_count': 1, 'script_type_count': 0, 'external_file_count': 0, 'ref_type_count': 0}


def worker(args):
    out = args.output.resolve(strict=True)
    need(out.is_relative_to(ROOT / 'AssetRecovery'), 'Output must stay in recovery staging outside Main')
    report = {'schema': 'genuine-editor-shader-native-singleton-input/v1', 'status': 'starting', 'Main_modified': False, 'Unity_launched': False, 'compiler_launched': False, 'native_api_executed': False, 'game_code_executed': False}
    try:
        parser = load_parser()
        header, parsed, typ, source = inspect_source(out, parser)
        report.update(source=source, parser=pin(PARSER), writer=pin(Path(__file__)))
        report['status'] = 'genuine_editor_shader_metadata_captured_payload_pending'
        if args.payload:
            payload, evidence = checked_payload(args)
            data, shape = make_wrapper(header, parsed, typ, payload, parser)
            target = out / 'OriginalFallbackError-EditorLayout-FileID4800000.asset'
            with target.open('xb') as stream:
                stream.write(data)
            need(target.read_bytes() == data, 'Persisted singleton bytes differ')
            report.update(status='genuine_editor_tree_and_exact_converted_payload_wrapped_native_import_unproven', converter=evidence, output=dict(pin(target), **shape), persisted_metadata_and_object_roundtrip_verified=True)
        report['limitations'] = ['Actual native Editor load/build/program retention is unproven until the isolated fixture passes.', 'Original Release object pointer closure is proven; Editor-only constructor fields are converter defaults, not separately decoded by this wrapper.', 'No Main asset/meta/GUID binding, shader replacement, GPU rendering or playable game is claimed.']
    except BaseException as error:
        report.update(status='stopped_preserve_for_review', error=repr(error))
    (out / 'report.json').write_text(json.dumps(report, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'status': report['status'], 'report': str(out / 'report.json'), 'error': report.get('error')}), flush=True)
    return 1 if 'error' in report else 0


def main():
    p = argparse.ArgumentParser(description=__doc__)
    p.add_argument('--output', type=Path)
    p.add_argument('--payload', type=Path)
    p.add_argument('--payload-sha')
    p.add_argument('--converter-report', type=Path)
    p.add_argument('--converter-report-sha')
    p.add_argument('--worker', action='store_true')
    args = p.parse_args()
    need(bool(args.payload) == bool(args.payload_sha) == bool(args.converter_report) == bool(args.converter_report_sha), 'Specify complete converter payload/report pair or metadata-only inspection')
    if args.worker:
        need(args.output, 'Worker requires a fresh parent-created output directory')
        return worker(args)
    need(args.output is None, 'Parent creates a fresh output directory')
    out = ROOT / 'AssetRecovery' / ('EditorShaderNativeInput-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    import read_original_ag_shader_models as bounded
    bounded.CAP = 256 * 1024**2
    command = [sys.executable, '-B', str(Path(__file__).resolve()), '--worker', '--output', str(out)]
    if args.payload:
        command += ['--payload', str(args.payload.resolve()), '--payload-sha', args.payload_sha, '--converter-report', str(args.converter_report.resolve()), '--converter-report-sha', args.converter_report_sha]
    run = bounded.phase(command, out, 'pure-editor-shader-metadata-or-wrap')
    (out / 'outer-job-report.json').write_text(json.dumps(run, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'report': str(out / 'report.json'), 'job_report': str(out / 'outer-job-report.json'), 'exit_code': run.get('exit_code'), 'peak_job_bytes': run.get('peak_job_bytes'), 'error': run.get('error')}), flush=True)
    return 0 if run.get('exit_code') == 0 and not run.get('error') else 1


if __name__ == '__main__':
    raise SystemExit(main())
