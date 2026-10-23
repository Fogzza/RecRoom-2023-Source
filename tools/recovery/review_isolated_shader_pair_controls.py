"""Data-only independent controls for the isolated AG/Fallback append patcher."""
from pathlib import Path
import ctypes
import datetime as dt
import hashlib
import json
import struct
import sys
import time
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
sys.path.insert(0, str(ROOT / 'Tools'))
CAP = 256 * 1024**2
RESERVE = int(1.5 * 1024**3)
TOOL_SHA = '686aec85844484845fa073b84989c138b25fa23d20826a8ebdf732c5c1a05934'
AG = ROOT / 'AssetRecovery/OriginalShaderRecoveryRoute-20261022T184808Z-356f2e1f/OriginalSerializedShaderObjects/native-6351.bin'
FALLBACK = ROOT / 'AssetRecovery/OriginalShaderEditorConversion-20261022T212623Z-fde1a98d/OriginalReleaseShader.bin'
MODEL = ROOT / 'AssetRecovery/OriginalAGShaderModels-20261022T203556Z-4b62253a/native-Object/report.json'
MODEL_SHA = '3c77fde3c14f517ec64c64e49194d372f4f884e11e5b4bcdc2caf60883f0f7b3'


def need(value, message):
    if not value:
        raise RuntimeError(message)


def digest(data):
    return hashlib.sha256(data).hexdigest()


def pin(path):
    return {'path': str(path.resolve()), 'bytes': path.stat().st_size,
            'sha256': digest(path.read_bytes())}


def save(path, value):
    with path.open('x', encoding='utf-8') as stream:
        json.dump(value, stream, indent=2)
        stream.write('\n')


def synthetic_container(prefix, raw_type, rows):
    # Three unrelated metadata features exercise complete prefix preservation.
    meta = bytearray(prefix) + struct.pack('<i', 2) + raw_type
    inert_type = struct.pack('<iBh', 1, 0, -1) + bytes.fromhex('112233445566778899aabbccddeeff00')
    meta += inert_type + struct.pack('<i', len(rows))
    meta += bytes((-len(meta)) % 4)
    body = bytearray()
    for path_id, payload, type_index in rows:
        body += bytes((-len(body)) % 16)
        meta += struct.pack('<qqIi', path_id, len(body), len(payload), type_index)
        body += payload
    meta += struct.pack('<ii', 1, 2)  # one script type, local file index2
    meta += bytes((-len(meta)) % 4) + struct.pack('<q', 123456789)
    meta += struct.pack('<i', 1) + b'untouched-asset-path\0'
    meta += bytes.fromhex('00112233445566778899aabbccddeeff')
    meta += struct.pack('<i', 2) + b'untouched-external-path\0'
    meta += struct.pack('<i', 0) + b'untouched-user-info\0'
    start = (48 + len(meta) + 15) & ~15
    body += bytes((-len(body)) % 8)
    size = start + len(body)
    header = struct.pack('>IIII', 0, 0, 22, 0) + bytes(4)
    header += struct.pack('>Iqqq', len(meta), size, start, 0)
    return header + meta + bytes(start - 48 - len(meta)) + body


def controls(out):
    import patch_isolated_room_shader_pair as pair
    import patch_isolated_player_shader as single
    need(pin(HERE / 'patch_isolated_room_shader_pair.py')['sha256'] == TOOL_SHA, 'Reviewed pair patcher changed')
    need(pin(MODEL)['sha256'] == MODEL_SHA, 'Original typed-model receipt changed')
    ag, fallback = AG.read_bytes(), FALLBACK.read_bytes()
    need(digest(ag) == pair.AG_SHA and digest(fallback) == pair.RELEASE_SHA, 'Original object source pins')
    model = json.loads(MODEL.read_bytes())
    need(model['source_sha256'] == pair.AG_SHA and model['consumed_bytes'] == len(ag), 'Actual generated model consumed exact AG')
    parser = single.parser_module()
    _, _, parsed_source, _, original_type, genuine_fallback = parser.inspect_source()
    need(genuine_fallback == fallback and digest(original_type['raw']) == pair.TYPE_SHA, 'Actual original type and Fallback agreement')
    old_ag, old_fallback, inert = b'old-built-AG-placeholder', b'old-built-Fallback-placeholder', b'non-target-object-unchanged'
    ag_id, fallback_id = 301, 302
    container = synthetic_container(parsed_source['prefix'], original_type['raw'],
        [(ag_id, old_ag, 0), (fallback_id, old_fallback, 0), (303, inert, 1)])
    output, proof = pair.patch_pair(container, ag, fallback, ag_id, fallback_id, digest(old_ag), digest(old_fallback))
    _, before, _, _ = single.inspect(container, parser)
    _, after, _, _ = single.inspect(output, parser)
    objects = {obj['path_id']: output[obj['offset']:obj['offset'] + obj['size']] for obj in after['objects']}
    mapped = objects[ag_id]
    pointer = len(ag) - 20
    need(mapped[:pointer] == ag[:pointer] and mapped[pointer + 12:] == ag[pointer + 12:], 'Exact original source bytes outside typed12B')
    need(struct.unpack_from('<iiq', mapped, len(mapped) - 24) == (1, 0, fallback_id), 'Typed dependency count1/file0/localFallback')
    need(objects[fallback_id] == fallback and objects[303] == inert, 'Exact Fallback and unrelated object')
    blob = model['fields']['compressedBlob']
    blob_start = len(ag) - 24 - blob['bytes']
    need(struct.unpack_from('<i', ag, blob_start - 4)[0] == blob['bytes'], 'Independent actual compressedBlob length prefix')
    need(digest(ag[blob_start:blob_start + blob['bytes']]) == blob['sha256'], 'Actual original blob agrees typed model')
    need(mapped[blob_start:blob_start + blob['bytes']] == ag[blob_start:blob_start + blob['bytes']], 'All original compiled blob bytes exact')
    need(before['externals'] == after['externals'] and before['script_type_count'] == after['script_type_count'] == 1
         and before['user_raw'] == after['user_raw'] and before['types'] == after['types'], 'All types/scripts/externals/user metadata exact')
    positive = {'status': 'passed', 'synthetic_native_input_sha256': digest(container),
        'output_sha256': digest(output), 'source_AG_last24_hex': ag[-24:].hex(),
        'mapped_AG_last24_hex': mapped[-24:].hex(), 'PPtr_offset': pointer,
        'source_model_blob_bytes': blob['bytes'], 'source_model_blob_sha256': blob['sha256'],
        'all_AG_bytes_outside12B_PPtr_exact': True, 'entire_Fallback_exact': True,
        'unrelated_object_exact': True, 'all_other_metadata_exact': True,
        'type_raw_bytes': len(original_type['raw']), 'type_raw_sha256': pair.TYPE_SHA,
        'patcher_proof': proof}
    results = []
    def reject(label, callback):
        try:
            callback()
        except (ValueError, RuntimeError, struct.error) as error:
            results.append({'control': label, 'status': 'rejected', 'reason': str(error)})
        else:
            raise RuntimeError('Negative control unexpectedly accepted: ' + label)
    args = (container, ag, fallback, ag_id, fallback_id, digest(old_ag), digest(old_fallback))
    reject('altered_original_AG_source', lambda: pair.patch_pair(container, bytes([ag[0] ^ 1]) + ag[1:], *args[2:]))
    reject('altered_original_Fallback_source', lambda: pair.patch_pair(container, ag, fallback[:-1] + bytes([fallback[-1] ^ 1]), *args[3:]))
    reject('wrong_built_AG_object_pin', lambda: pair.patch_pair(*args[:5], '0' * 64, args[6]))
    reject('wrong_built_Fallback_object_pin', lambda: pair.patch_pair(*args[:6], '0' * 64))
    reject('missing_local_Fallback', lambda: pair.patch_pair(*args[:4], 999, *args[5:]))
    reject('same_target_identity', lambda: pair.patch_pair(*args[:4], ag_id, *args[5:]))
    reject('null_target_identity', lambda: pair.patch_pair(*args[:3], 0, *args[4:]))
    altered_type = bytearray(original_type['raw']); altered_type[-1] ^= 1
    wrong_container = synthetic_container(parsed_source['prefix'], bytes(altered_type), [(ag_id, old_ag, 0), (fallback_id, old_fallback, 0)])
    reject('nonmatching_Class48_raw_type', lambda: pair.patch_pair(wrong_container, *args[1:]))
    wrong_header = bytearray(container); wrong_header[24] ^= 1
    reject('native_header_size_drift', lambda: pair.patch_pair(bytes(wrong_header), *args[1:]))
    # Invalid duplicate identities are a robustness boundary, not a real Unity output.
    duplicate = synthetic_container(parsed_source['prefix'], original_type['raw'],
        [(ag_id, mapped, 0), (ag_id, old_ag, 0), (fallback_id, old_fallback, 0)])
    reject('duplicate_target_identity', lambda: pair.patch_pair(duplicate, *args[1:]))
    report = {'schema': 'independent-isolated-original-AG-fallback-patch-controls/v1',
        'status': 'positive_and_ten_negative_controls_passed', 'tool': pin(HERE / 'patch_isolated_room_shader_pair.py'),
        'original_AG': pin(AG), 'original_Fallback': pin(FALLBACK), 'actual_source_model': pin(MODEL),
        'positive': positive, 'negative_controls': results,
        'unique_target_identity_guard_verified': True,
        'actual_Unity_container_or_GPU_test_claimed': False, 'Main_modified': False, 'Unity_launched': False}
    save(out / 'controls-report.json', report)


def main():
    if len(sys.argv) == 3 and sys.argv[1] == '--worker':
        controls(Path(sys.argv[2])); return
    from export_bundle_batches import ChildJob, ExtendedJob
    from guarded_cpp2il import memory
    from owned_suspended_launch import launch_suspended_in_job
    launcher = HERE / 'owned_suspended_launch.py'
    need(pin(launcher)['sha256'] == '3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958', 'Reviewed suspended launcher')
    need(memory().available_commit >= CAP + RESERVE, 'Owned256MiB plus1.5GiB reserve')
    out = ROOT / 'AssetRecovery' / ('IndependentShaderPairPatchReview-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    job = ChildJob(); limits = ExtendedJob(); limits.basic.flags = 0x2000 | 0x200; limits.job_memory = CAP
    need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), 'Owned job cap')
    child = None
    receipt = {'cap_bytes': CAP, 'reserve_bytes': RESERVE, 'Main_modified': False, 'Unity_launched': False}
    try:
        with (out / 'stdout.log').open('xb') as stdout, (out / 'stderr.log').open('xb') as stderr:
            child, receipt['launcher'] = launch_suspended_in_job([sys.executable, '-B', str(Path(__file__)), '--worker', str(out)], job=job, cwd=WS, stdout=stdout, stderr=stderr)
            start = time.monotonic()
            while child.poll() is None:
                need(time.monotonic() - start < 60 and memory().available_commit >= RESERVE, 'Pure control time/memory bound')
                time.sleep(.1)
        receipt['exit_code'] = child.returncode
        q = job.kernel.QueryInformationJobObject
        q.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_uint32, ctypes.c_void_p]; q.restype = ctypes.c_int
        info = ExtendedJob(); need(q(job.handle, 9, ctypes.byref(info), ctypes.sizeof(info), None), 'Owned peak query')
        receipt['peak_job_bytes'] = int(info.peak_job)
    finally:
        job.close()
        if child is not None:
            receipt['owned_child_exit_confirmed'] = child.wait(timeout=10) is not None
        save(out / 'owned-job-report.json', receipt)
    need(receipt['exit_code'] == 0, 'Pure controls failed; inspect private local stderr')
    print(json.dumps({'report': pin(out / 'controls-report.json'), 'owned_job': pin(out / 'owned-job-report.json')}))


if __name__ == '__main__':
    main()
