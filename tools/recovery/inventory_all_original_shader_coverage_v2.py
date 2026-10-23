"""Bounded read-only original cooked Shader coverage; never imports Unity/game code."""
from pathlib import Path
import ctypes
import datetime as dt
import hashlib
import json
import os
import shutil
import struct
import subprocess
import sys
import time
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
sys.path.insert(0, str(HERE))
import read_original_ag_shader_models as guard
from stage_original_ag_shader_candidate import typed_identity as identity_with_masks, compatible
from compare_shader_parsed_form import field_lines
from shader_program_data import yaml_program

AUDIT = ROOT / 'AssetRecovery/ShaderPackagingReadOnlyAudit-20261023T024005Z-8465b482/report.json'
PROBE = ROOT / 'AssetRecovery/OriginalShaderSourceProbe-20261022T184321Z-dfa2d738/report.json'
EMPTY = {'AG/Standard-Opaque': ('resources.assets', '6351'), 'AG/Standard-Opaque-Decal': ('resources.assets', '6286'), 'Props/LensRender': ('resources.assets', '6358'), 'Hidden/Universal Render Pipeline/StencilDeferred': ('globalgamemanagers.assets', '34')}


def need(value, message):
    if not value:
        raise ValueError(message)


def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()


def pin(path):
    return {'path': str(path.resolve()), 'bytes': path.stat().st_size, 'sha256': sha(path)}


def save(out, report):
    temporary = out / 'report.writing.json'
    temporary.write_text(json.dumps(report, indent=2) + '\n', encoding='utf-8')
    temporary.replace(out / 'report.json')


def blob_range(raw, size, wanted):
    matches, at = [], 0
    prefix = struct.pack('<I', size)
    while size and (at := raw.find(prefix, at)) >= 0:
        block = raw[at + 4:at + 4 + size]
        if len(block) == size and hashlib.sha256(block).hexdigest() == wanted:
            matches.append(at + 4)
        at += 1
    return matches


def closure(raw, offset, size):
    position = (offset + size + 3) & ~3
    need(raw[offset + size:position] == bytes(position - offset - size), 'Known program alignment must be zero')
    def take(fmt):
        nonlocal position
        count = struct.calcsize('<' + fmt)
        need(position + count <= len(raw), 'Dependency tail bounds')
        value = struct.unpack_from('<' + fmt, raw, position)
        position += count
        return value[0] if len(value) == 1 else value
    count = take('i'); need(0 <= count <= 128, 'Shader dependency bound')
    deps = [{'file_id': take('i'), 'path_id': take('q')} for _ in range(count)]
    textures = take('i'); need(0 <= textures <= 128, 'Nonmodifiable texture bound')
    entries = []
    for _ in range(textures):
        length = take('i'); need(0 <= length <= 4096 and position + length <= len(raw), 'Texture key bounds')
        key = raw[position:position + length].decode('utf-8'); position += length
        aligned = (position + 3) & ~3
        need(raw[position:aligned] == bytes(aligned - position), 'Texture key alignment')
        position = aligned
        entries.append({'key': key, 'file_id': take('i'), 'path_id': take('q')})
    baked = take('B'); need(baked in (0, 1), 'Known ShaderIsBaked boolean')
    need(raw[position:] == bytes((-position) % 4), 'Entire exact Shader dependency tail must be consumed')
    return {'dependency_count': count, 'dependencies': deps, 'nonmodifiable_texture_count': textures, 'nonmodifiable_textures': entries, 'shader_is_baked': bool(baked), 'entire_tail_consumed': True}


def typed_identity(path):
    try:
        return identity_with_masks(path)
    except RuntimeError:
        lines = field_lines(path, 'm_ParsedForm')
        need(not any(x.lstrip().startswith('- m_EditorDataHash:') for x in lines), 'A shader with any concrete pass must pass the full typed mask/map comparison')
        residual = [x.rstrip().replace("'<noninit>'", '<noninit>') for x in lines]
        return {'lines': lines, 'residual': residual, 'passes': [], 'presentation': {'trailing_YAML_whitespace': sum(x.rstrip() != x for x in lines), 'exact_noninit_string_quote_spelling': sum("'<noninit>'" in x for x in lines)}}


def worker(out):
    report = {'schema': 'all-current-Main-shaders-original-cooked-coverage/v1', 'status': 'starting', 'Main_modified': False, 'Unity_or_compiler_launched': False, 'game_code_invoked': False, 'models_completed': 0, 'Main_shaders': [], 'source_objects': [], 'phases': [], 'source_index': pin(PROBE), 'Main_snapshot': pin(AUDIT), 'tool': pin(Path(__file__))}
    try:
        need(sha(AUDIT) == '12308695986789318472c2dbf545356b5b5015c0caea0b87c5c2e2908296b83b', 'Exact Main shader snapshot changed')
        need(sha(PROBE) == '466da3d8ddab16fe33dede9d4f900262ba99a6a901fb836282df0188e2536847', 'Original verified object index changed')
        audit = json.loads(AUDIT.read_bytes())
        need(len(audit['rows']) == 179, 'Exact179 original Main Shader assets required')
        source_index = json.loads(PROBE.read_bytes())
        source_rows = list(source_index['known_shader_names_and_native_identity'])
        need(len(source_rows) == 300, 'Exact208 native plus92 verified-bundle Shader objects required')
        names, blob_index, sizes = {}, {}, set()
        for row in audit['rows']:
            path = Path(row['asset'])
            need(sha(path) == row['sha256'] and sha(Path(str(path) + '.meta')) == row['meta_sha256'], 'Main Shader or original meta changed before census')
            program = yaml_program(path)
            blob = program.pop('blob')
            item = dict(row, program_arrays=program, compressed_blob_sha256=hashlib.sha256(blob).hexdigest(), original_candidates=[], validated_originals=[])
            names[row['name']] = item
            report['Main_shaders'].append(item)
            if blob:
                blob_index.setdefault((len(blob), item['compressed_blob_sha256']), []).append(row['name'])
                sizes.add(len(blob))
        need(len(names) == 179 and len([x for x in report['Main_shaders'] if x['compressed_blob_bytes'] == 0]) == 4, 'Exact original Main names/empty-program inventory required')
        del blob, program
        raws = out / 'Raw'; raws.mkdir()
        for index, source in enumerate(source_rows):
            path = Path(source['source_path']); before = path.stat()
            need((path.is_relative_to(ROOT / 'VerifiedSource') or path.is_relative_to(ROOT / 'RawUnityFSRecovery')) and 0 < source['byte_size'] <= 8 * 1024**2, 'Bounded exact original native object required')
            with path.open('rb') as stream:
                stream.seek(source['byte_offset']); raw = stream.read(source['byte_size'])
            need(len(raw) == source['byte_size'] and (path.stat().st_size, path.stat().st_mtime_ns) == (before.st_size, before.st_mtime_ns), 'Original source changed during exact span read')
            matches = []
            for size in sizes:
                prefix, at = struct.pack('<I', size), 0
                while (at := raw.find(prefix, at)) >= 0:
                    if at + 4 + size <= len(raw):
                        wanted = (size, hashlib.sha256(raw[at + 4:at + 4 + size]).hexdigest())
                        if wanted in blob_index:
                            for name in blob_index[wanted]:
                                if struct.pack('<I', len(name.encode())) + name.encode() in raw:
                                    matches.append({'name': name, 'blob_offset': at + 4, 'blob_bytes': size, 'blob_sha256': wanted[1]})
                    at += 1
            for name, (filename, identity) in EMPTY.items():
                if path.name == filename and source['path_id'] == identity:
                    matches.append({'name': name, 'known_empty_Main_original_identity': True})
            if not matches:
                continue
            target = raws / (str(index) + '-' + path.name + '-' + source['path_id'] + '.bin')
            target.write_bytes(raw)
            entry = {'source': source, 'raw': pin(target), 'matches': matches}
            report['source_objects'].append(entry)
            for match in matches:
                names[match['name']]['original_candidates'].append({'source_index': len(report['source_objects']) - 1, **match})
        report['discovery'] = {'Main_count': 179, 'native_candidates_found_for': sum(bool(x['original_candidates']) for x in report['Main_shaders']), 'candidate_source_objects': len(report['source_objects']), 'missing_names': [x['name'] for x in report['Main_shaders'] if not x['original_candidates']], 'selection_by_name_alone': False, 'typed_ParsedForm_validation_complete': False}
        report['status'] = 'exact_blob_native_discovery_complete_typed_comparison_in_progress'
        save(out, report)
        print(json.dumps({'stage': 'discovery', **report['discovery']}), flush=True)
        # The compiled helper is the existing source-pinned, data-only reader.
        previous = json.loads((guard.PREVIOUS / 'report.json').read_bytes())
        need(sha(guard.PREVIOUS / 'report.json') == 'e99d06254cd16e817a20e19cedecbedf8005c19608d7141d80461a9b9c6c8f97' and sha(guard.PREVIOUS / 'OriginalShaderObjectProbe.cs') == 'c10e692d0d482e9a55ede144f2ceb89e7622d7dce4bcc8b9af7adadc345858c3', 'Existing exact generic-reader compilation proof required')
        report['existing_reader'] = pin(guard.HOST)
        report['existing_compile_receipt'] = pin(guard.PREVIOUS / 'report.json')
        for dependency in previous['dependencies']:
            need(sha(Path(dependency['path'])) == dependency['sha256'] and sha(guard.PREVIOUS / Path(dependency['path']).name) == dependency['sha256'], 'Existing genuine generic-reader dependency changed')
        prior_path = Path('C:\\Users\\andre\\Documents\\ChatGPT\\LunarNet\\Recovery\\RecRoom-2023-04-18\\AssetRecovery\\AllOriginalShaderCoverage-20261023T025535Z-b5a091fb\\report.json')
        need(sha(prior_path) == '9af980ce7e5a8fd5d6dbf77f8b731ff7ca01e189b50038405e67ddcb1f799a9b', 'Frozen partial census model-reuse receipt changed')
        prior = json.loads(prior_path.read_bytes()); cache = {}
        for phase in prior['phases']:
            if phase.get('exit_code') != 0 or phase.get('error'): continue
            model_path = Path(phase['command'][-1]) / 'report.json'
            if not model_path.is_file(): continue
            model = json.loads(model_path.read_bytes())
            need(model['status'] == 'parsed_entire_original_object' and model['actual_name'] == model['expected_name'] and sha(Path(model['parsed_form']['path'])) == model['parsed_form']['sha256'], 'Previously completed full reader model changed')
            cache[(model['source_sha256'], model['actual_name'])] = model_path
        report['reused_prior_model_receipt'] = pin(prior_path)
        for source_number, entry in enumerate(report['source_objects']):
            raw_path = Path(entry['raw']['path']); raw = raw_path.read_bytes()
            for match_number, match in enumerate(entry['matches']):
                name = match['name']; item = names[name]
                reused = cache.get((entry['raw']['sha256'], name))
                if reused:
                    model_dir = reused.parent
                    phase = {'phase': 'reused-existing-entire-original-model', 'exit_code': 0, 'prior_model': pin(reused), 'no_new_child_launched': True}
                else:
                    model_dir = out / ('Model-' + str(source_number) + '-' + str(match_number))
                    phase = guard.phase([str(guard.DOTNET), str(guard.HOST), str(raw_path), entry['raw']['sha256'], entry['source']['path_id'], name, str(model_dir)], out, 'model-' + str(source_number) + '-' + str(match_number))
                report['phases'].append(phase)
                if phase.get('exit_code') != 0 or phase.get('error'):
                    item.setdefault('reader_rejections', []).append({'source_index': source_number, 'phase': phase})
                    save(out, report); continue
                model_path = model_dir / 'report.json'; model = json.loads(model_path.read_bytes())
                need(model['status'] == 'parsed_entire_original_object' and model['consumed_bytes'] == model['total_bytes'] == len(raw) and model['actual_name'] == name and model['no_pointer_yaml'] and model['program_ranges_within_original_blob'], 'Entire original Shader model must be validated')
                comparison = compatible(typed_identity(Path(model['parsed_form']['path'])), typed_identity(Path(item['asset'])))
                fields = model['fields']
                ranges = blob_range(raw, fields['compressedBlob']['bytes'], fields['compressedBlob']['sha256'])
                need(len(ranges) == 1, 'Unique complete original program blob range required')
                pointers = closure(raw, ranges[0], fields['compressedBlob']['bytes'])
                arrays = {'platforms': fields['Platforms'], 'offsets': fields['Offsets_AssetList_AssetList_UInt32'], 'compressedLengths': fields['CompressedLengths_AssetList_AssetList_UInt32'], 'decompressedLengths': fields['DecompressedLengths_AssetList_AssetList_UInt32']}
                arrays_exact = arrays == item['program_arrays']
                program_match = arrays_exact or (name in EMPTY and item['compressed_blob_bytes'] == 0 and all(item['program_arrays'][k] == [] or item['program_arrays'][k] == v for k, v in arrays.items()))
                if item['compressed_blob_bytes']:
                    program_match = program_match and fields['compressedBlob']['bytes'] == item['compressed_blob_bytes'] and fields['compressedBlob']['sha256'] == item['compressed_blob_sha256']
                proof = {'source_index': source_number, 'model': pin(model_path), 'original_ParsedForm': pin(Path(model['parsed_form']['path'])), 'typed_retained_ParsedForm': comparison, 'all_existing_program_values_match_missing_only_for_known4': program_match, 'all_program_arrays_exact': arrays_exact, 'original_blob': dict(fields['compressedBlob'], offset_in_original=ranges[0]), 'pointer_closure': pointers, 'full_original_object_consumed': True}
                comparison_path = out / ('Comparison-' + str(source_number) + '-' + str(match_number) + '.json')
                comparison_path.write_text(json.dumps(proof, indent=2) + '\n', encoding='utf-8')
                if comparison['matches_all_retained_typed_data'] and program_match:
                    item['validated_originals'].append(dict(proof_receipt=pin(comparison_path), **proof))
                else:
                    item.setdefault('retained_data_rejections', []).append({'source_index': source_number, 'proof_receipt': pin(comparison_path)})
                report['models_completed'] += 1
                if report['models_completed'] % 10 == 0:
                    print(json.dumps({'stage': 'typed_models', 'completed': report['models_completed'], 'Main_validated': sum(bool(x['validated_originals']) for x in report['Main_shaders'])}), flush=True)
                save(out, report)
        for item in report['Main_shaders']:
            need(sha(Path(item['asset'])) == item['sha256'] and sha(Path(item['asset'] + '.meta')) == item['meta_sha256'], 'Main Shader/meta changed during read-only census')
        report['summary'] = {'Main_total': 179, 'Main_with_validated_original': sum(bool(x['validated_originals']) for x in report['Main_shaders']), 'unvalidated_names': [x['name'] for x in report['Main_shaders'] if not x['validated_originals']], 'objects_with_Shader_dependencies': sum(x['pointer_closure']['dependency_count'] > 0 for a in report['Main_shaders'] for x in a['validated_originals']), 'objects_with_nonmodifiable_textures': sum(x['pointer_closure']['nonmodifiable_texture_count'] > 0 for a in report['Main_shaders'] for x in a['validated_originals']), 'multiple_equivalent_original_sources': [x['name'] for x in report['Main_shaders'] if len(x['validated_originals']) > 1]}
        report['status'] = 'all179_original_cooked_and_retained_typed_data_validated' if report['summary']['Main_with_validated_original'] == 179 else 'partial_original_coverage_requires_review_no_substitution'
    except BaseException as error:
        report.update(status='stopped_preserve_data_for_review', error=repr(error))
    report['finished_utc'] = dt.datetime.now(dt.timezone.utc).isoformat()
    save(out, report)
    print(json.dumps({'status': report['status'], 'report': str(out / 'report.json'), 'summary': report.get('summary'), 'error': report.get('error')}), flush=True)
    return 0 if report['status'] != 'stopped_preserve_data_for_review' else 1


def main():
    if len(sys.argv) == 3 and sys.argv[1] == '--worker':
        return worker(Path(sys.argv[2]))
    need(len(sys.argv) == 1, 'No arbitrary inputs supported')
    out = ROOT / 'AssetRecovery' / ('AllOriginalShaderCoverage-v2-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]); out.mkdir()
    cap, reserve = 512 * 1024**2, int(1.5 * 1024**3)
    need(guard.memory().available_commit >= cap + reserve and shutil.disk_usage(out).free >= 4 * 1024**3, '512MiB aggregate job plus1.5GiB commit/4GiB disk reserve refused')
    job, child = guard.ChildJob(), None
    limits = guard.ExtendedJob(); limits.basic.flags = 0x2000 | 0x200; limits.job_memory = cap
    need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), 'Cannot set aggregate pure-data census job limit')
    receipt = {'schema': 'bounded-all-original-shader-coverage-job/v1', 'cap_bytes': cap, 'reserve_bytes': reserve, 'maximum_seconds': 900}
    try:
        with (out / 'worker.log').open('xb') as log:
            child, launched = guard.launch_suspended_in_job([sys.executable, '-B', str(Path(__file__).resolve()), '--worker', str(out)], job=job, cwd=out, stdout=log, stderr=subprocess.STDOUT)
            receipt['launch'] = launched
            start = time.monotonic()
            while child.poll() is None:
                need(guard.memory().available_commit >= reserve and time.monotonic() - start <= 900, 'Pure census aggregate time/commit guard')
                time.sleep(.1)
            receipt['exit_code'] = child.returncode
        query = job.kernel.QueryInformationJobObject; query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_ulong, ctypes.c_void_p]; query.restype = ctypes.c_int
        need(query(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits), None), 'Cannot query aggregate census job peak')
        receipt['peak_job_bytes'] = int(limits.peak_job)
    except BaseException as error:
        receipt['error'] = repr(error)
    finally:
        job.close()
        if child is not None:child.wait(timeout=10)
        (out / 'outer-job-report.json').write_text(json.dumps(receipt, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'report': str(out / 'report.json'), 'outer_job_report': str(out / 'outer-job-report.json'), **{k:receipt.get(k) for k in ('exit_code','peak_job_bytes','error')}}), flush=True)
    return 0 if receipt.get('exit_code') == 0 and not receipt.get('error') else 1


if __name__ == '__main__':
    raise SystemExit(main())
