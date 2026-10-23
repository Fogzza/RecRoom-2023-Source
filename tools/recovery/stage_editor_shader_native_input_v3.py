"""Wrap the pinned original Shader with only its proved NamedObject normalization."""
from pathlib import Path
import hashlib
import importlib.util
import json
import struct

HERE = Path(__file__).resolve().parent
V2 = HERE / 'stage_editor_shader_native_input_v2.py'
if hashlib.sha256(V2.read_bytes()).hexdigest() != '4c9c3322496d0a3d65bdf06955e8fd251499257221d3f84f22e4af22d65695c8':
    raise ValueError('Frozen reviewed bounded wrapper runner changed')
spec = importlib.util.spec_from_file_location('frozen_bounded_editor_wrapper_runner', V2)
runner = importlib.util.module_from_spec(spec)
spec.loader.exec_module(runner)
base = runner.base
NAME = 'Hidden/Universal Render Pipeline/FallbackError'
PAYLOAD_SHA = 'd1fdae2cf6ba064c58410b35d7afbd2b54ecfc48e75e06b238911bc55142428d'
REPORT_SHA = 'db3e2acdc5b03aae8eaa702aa751bb557bb05b95a3a10e0fde2c604337a36551'
RUN_SHA = 'bbdd553e0ea025e3ed49de2ec8f60b3b4dd0538e258a3b120aa7856f22475051'
DXBC = sorted(['825772a22701469aa5be56ec8e1ae0197fd2fc89a79a5785321fc940d640355e',
               'e1db43b18c53b97e502c0853a8d4d6144ebec623c07db5c8a95c3a6dd7614dbb',
               'ee83a5e328c2677cea50372dea9329b5c74b411f5fc4396f9c07f7b53a34323b',
               'f168870ec3158748a69879644ac5db1d7c9e6f2fe5eaad62fd9fcf2fe1e88d96'])


def checked_payload(args):
    base.need(args.payload_sha == PAYLOAD_SHA and args.converter_report_sha == REPORT_SHA and args.conversion_run_report_sha == RUN_SHA, 'Only exact actual successful normalized proof is authorized')
    payload_path = args.payload.resolve(strict=True)
    report_path = args.converter_report.resolve(strict=True)
    run_path = args.conversion_run_report.resolve(strict=True)
    for path in (payload_path, report_path, run_path):
        base.need(path.is_relative_to(base.ROOT / 'AssetRecovery'), 'Inputs must remain in recovery staging')
    payload_pin, report_pin, run_pin = base.pin(payload_path), base.pin(report_path), base.pin(run_path)
    base.need(payload_pin['sha256'] == PAYLOAD_SHA and payload_pin['bytes'] == 3783 and report_pin['sha256'] == REPORT_SHA and run_pin['sha256'] == RUN_SHA, 'Exact normalized converter inputs changed')
    report, run = json.loads(report_path.read_bytes()), json.loads(run_path.read_bytes())
    base.need(report['schema'] == 'original-shader-generated-Editor-layout-roundtrip/v2' and report['status'] == 'all_original_data_preserved_except_proven_NamedObject_name_normalization', 'Exact normalized conversion status required')
    base.need(report['engine'] == '2020.3.33f1' and report['name'] == NAME and report['source_sha256'] == base.RELEASE_SHA and report['source_bytes'] == report['release_consumed_bytes'] == 3656, 'Exact original source/version/consumption required')
    base.need(report['editor_bytes'] == report['editor_consumed_bytes'] == 3783 and report['editor_sha256'] == PAYLOAD_SHA, 'Entire Editor payload readback required')
    base.need(report['entire_release_object_byte_exact'] is False and report['known_named_object_metadata_normalization_only'] is True and report['all_bytes_after_aligned_NamedObject_equal'] is True and report['entire_ParsedForm_equal'] is True, 'Only the explicitly proven name normalization is permitted')
    base.need(report['original_NamedObject_name'] == '' and report['normalized_NamedObject_name'] == NAME and report['Main_modified'] is False and report['native_api_executed'] is False and report['Unity_launched'] is False, 'Exact allowed metadata normalization / pure conversion required')
    fields = {'Platforms': [4], 'Offsets_AssetList_AssetList_UInt32': [[0]], 'CompressedLengths_AssetList_AssetList_UInt32': [[991]], 'DecompressedLengths_AssetList_AssetList_UInt32': [[2620]], 'compressedBlob': {'bytes': 991, 'sha256': base.BLOB_SHA}}
    base.need(report['original_program_fields'] == fields, 'Every original program field must match exactly')
    base.need(run['schema'] == 'guarded-pure-original-shader-Editor-conversion/v1' and run['status'] == 'all_original_data_and_DXBC_preserved_with_proven_Name_metadata_normalization' and not run.get('error') and run['Editor_launched'] is False and run['native_api_executed'] is False and run['Main_modified'] is False, 'Actual successful normalized guarded run required')
    base.need(len(run['phases']) == 2, 'Actual compile and conversion phases required')
    for phase in run['phases']:
        launch = phase['launcher']
        base.need(phase['exit_code'] == 0 and phase['owned_cli_or_compiler_exit_confirmed'] is True and launch['membership_verified_before_resume'] is True and launch['resume_previous_suspend_count'] == 1, 'Both actual phases must pass within their assigned jobs')
    for key, path, expected in [('conversion_report', report_path, REPORT_SHA), ('editor_payload', payload_path, PAYLOAD_SHA)]:
        base.need(Path(run[key]['path']).resolve() == path and run[key]['sha256'] == expected, 'Successful run must pin exact output')
    facts = run['original_DXBC_after_Editor_roundtrip']
    base.need(facts['dxbc_chunks'] == 4 and facts['unique_dxbc_sha256'] == DXBC and facts['blob_bytes'] == 991 and facts['blob_sha256'] == base.BLOB_SHA and facts['platform'] == 4, 'Exact original four DXBC chunks required')
    source_path = run_path.parent / 'OriginalReleaseShader.bin'
    normalized_path = report_path.parent / 'ReleaseReserialized.bin'
    source_pin, normalized_pin = base.pin(source_path), base.pin(normalized_path)
    original, normalized = source_path.read_bytes(), normalized_path.read_bytes()
    base.need(source_pin['sha256'] == base.RELEASE_SHA and len(original) == 3656 and normalized_pin['sha256'] == report['release_reserialized_sha256'], 'Actual original and normalized release bytes must match proof')
    old_len, new_len = struct.unpack_from('<i', original)[0], struct.unpack_from('<i', normalized)[0]
    base.need(old_len == 0 and 0 <= new_len <= 256 and normalized[4:4 + new_len] == NAME.encode(), 'Only empty stripped name to exact original ParsedForm name permitted')
    old_end, new_end = (4 + old_len + 3) & ~3, (4 + new_len + 3) & ~3
    base.need(new_end - old_end == 48 and len(normalized) - len(original) == 48 and normalized[4 + new_len:new_end] == bytes(new_end - 4 - new_len) and original[old_end:] == normalized[new_end:], 'Independently require every byte after aligned NamedObject to remain exact')
    proof_pin = base.pin(base.SOURCE_PROOF)
    base.need(proof_pin['sha256'] == '9e615d45be84597747ffa9094ba904ccb4a6977be7b86a8a893a1160597cc423', 'Exact original source pointer closure receipt required')
    proof = json.loads(base.SOURCE_PROOF.read_bytes())
    base.need(proof['original_selected_object']['sha256'] == base.RELEASE_SHA and proof['closure']['dependency_count'] == proof['closure']['nonmodifiable_texture_count'] == 0 and proof['closure']['shader_is_baked'], 'Original self-contained pointer closure required')
    return payload_path.read_bytes(), {'payload': payload_pin, 'report': report_pin, 'successful_conversion_run': run_pin, 'original_release_pointer_closure': proof_pin, 'original_release': source_pin, 'normalized_release': normalized_pin, 'conversion_guard_wrapper': base.pin(Path(__file__)), 'whole_original_release_byte_exact_claimed': False, 'known_named_object_metadata_normalization_only': True, 'every_byte_after_aligned_name_independently_verified_equal': True, 'all_five_program_fields_exact': True, 'original_DXBC_chunks': 4}


base.checked_payload = checked_payload
# Reuse the frozen runner; only select this v3 file for its assigned worker.
runner.__file__ = __file__
if __name__ == '__main__':
    raise SystemExit(runner.main())
