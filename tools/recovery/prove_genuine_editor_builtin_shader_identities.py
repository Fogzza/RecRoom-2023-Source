"""Pure owned data compiler/reader for four genuine Editor builtin Shader IDs."""
from pathlib import Path
import datetime as dt
import hashlib
import importlib.util
import json
import os
import re
import shutil
import struct
import uuid
import run_windows_development_define_probe as guard

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
SOURCE = WS / 'Tools/Editors/2020.3.33f1/Editor/Data/Resources/unity_builtin_extra'
PARSER = ROOT / 'AssetRecovery/OriginalFallbackNativeSerializedInput-20261022T205430Z-cab1d2e4/stage_input.py'
PREVIOUS = ROOT / 'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
GUID_PROOF = ROOT / 'AssetRecovery/RuntimeShaderProofSupplement-20261023T024917Z-26d72acf/genuine-Editor-GUID-remap-proof.json'
IDS = (6, 7, 46, 10490)
need = guard.need


def pin(path):
    return {'path': str(path.resolve()), 'bytes': path.stat().st_size, 'sha256': guard.sha(path)}


def main():
    need(guard.sha(PARSER) == '98b4cd637d310605981a57a7284660096dc4d2d4e8fa6b0f5240a41d4e2b02ae', 'Exact full metadata parser required')
    need(guard.sha(GUID_PROOF) == '2b4155bc4bc8e78ace255698152c332534c123db7e9b245005e7e2645d89a356', 'Genuine native external row proof required')
    guid_proof = json.loads(GUID_PROOF.read_bytes())
    external = guid_proof['external_rows'][0]
    need(external['row'] == 1 and external['guid_raw_hex'] == '00000000000000000f00000000000000' and external['type'] == 0 and external['asset_path'] == '' and external['path'] == 'Resources/unity_builtin_extra', 'Exact observed builtin external row required')
    guard.checked(guid_proof['frozen_exact_capture'])
    spec = importlib.util.spec_from_file_location('genuine_builtin_metadata_parser', PARSER)
    parser = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(parser)
    before = SOURCE.stat()
    need(before.st_size == 131446287, 'Exact matching Editor builtin file size')
    with SOURCE.open('rb') as stream:
        header = stream.read(48)
        size, declared, start, unknown = struct.unpack_from('>Iqqq', header, 20)
        need(struct.unpack_from('>IIII', header) == (0, 0, 22, 0) and header[16:20] == bytes(4) and declared == before.st_size and unknown == 0 and size == 107449, 'Exact bounded genuine Editor header')
        metadata = stream.read(size)
    need(hashlib.sha256(header).hexdigest() == '8d4ccb9c1485c0f0d82eef4eec0abaa9972043fbbfb08ddc404ea98311d693bc' and hashlib.sha256(metadata).hexdigest() == '81662d3405ed5c0c44fb5a2848c4697bdc8f66c39853830fc77f65945573e1ef', 'Exact captured genuine Editor header/metadata')
    parsed = parser.parse_metadata(metadata, start, declared)
    need(parsed['engine'] == '2020.3.33f1' and parsed['platform'] == -2 and parsed['has_type_tree'] and parsed['script_type_count'] == parsed['ref_type_count'] == len(parsed['externals']) == 0, 'Exact genuine Editor serialization context')
    out = ROOT / 'AssetRecovery' / ('GenuineEditorBuiltinShaderIdentities-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    raw_inputs = []
    with SOURCE.open('rb') as stream:
        for path_id in IDS:
            matches = [o for o in parsed['objects'] if o['path_id'] == path_id]
            need(len(matches) == 1, 'Exact unique native builtin object ID required')
            obj = matches[0]
            typ = parsed['types'][obj['type_index']]
            need(typ['class_id'] == 48 and typ['script_type_index'] == -1 and typ['script_id'] is None and typ['old_type_hash'] == '888994cda549cb3b5380e3be28b6cd6d' and hashlib.sha256(typ['raw']).hexdigest() == '0fbf2d2f8e6c2b23f21468a5a0528d28f361ca32775a5dec12d72f1f3a093171', 'Genuine same-version full native Class48 Editor type required')
            need(0 < obj['size'] <= 8 * 1024**2, 'Bounded native builtin Shader object required')
            stream.seek(obj['offset'])
            raw = stream.read(obj['size'])
            need(len(raw) == obj['size'], 'Complete native builtin range required')
            path = out / ('Builtin-' + str(path_id) + '.bin')
            path.write_bytes(raw)
            raw_inputs.append({'path_id': path_id, 'object': obj, 'type_index': typ['index'], 'class_id': 48, 'old_type_hash': typ['old_type_hash'], 'raw': pin(path)})
    # Reuse the proved reader dependency set. The tiny source amendment changes
    # only the serialization layout and permits name discovery from the full
    # genuine Editor model rather than guessing a display name from raw text.
    source = out / 'GenuineEditorBuiltinShaderObjectProbe.cs'
    text = (HERE / 'OriginalShaderObjectProbe.cs').read_text()
    need(text.count('shader.ReadRelease(ref reader);') == 1 and text.count('if (shader.Name_R.ToString() != args[3]) throw new InvalidDataException("Structural shader name mismatch");') == 1, 'Exact existing reader amendment anchors required')
    text = text.replace('shader.ReadRelease(ref reader);', 'shader.ReadEditor(ref reader);')
    text = text.replace('if (shader.Name_R.ToString() != args[3]) throw new InvalidDataException("Structural shader name mismatch");', 'if (String.IsNullOrEmpty(shader.Name_R.ToString())) throw new InvalidDataException("Genuine builtin Shader name is empty");')
    text = text.replace('bounded-original-shader-object-probe/v1', 'bounded-genuine-Editor-builtin-shader-object-probe/v1').replace('parsed_entire_original_object', 'parsed_entire_genuine_Editor_object')
    text = text.replace('expected_name = args[3], actual_name = shader.Name_R.ToString(),', 'serialization_layout = "Editor", name_discovered_by_entire_typed_ReadEditor = true, actual_name = shader.Name_R.ToString(),')
    source.write_text(text)
    output = out / 'OriginalShaderObjectProbe.dll'
    response_text = (PREVIOUS / 'compile.rsp').read_text()
    response_text, count = re.subn(r'(?m)^/out:.*$', lambda m: '/out:"' + str(output) + '"', response_text)
    need(count == 1, 'Exact existing data compiler output anchor')
    old_source = '"' + str(HERE / 'OriginalShaderObjectProbe.cs') + '"'
    need(response_text.count(old_source) == 1, 'Exact original generic reader source reference required')
    response_text = response_text.replace(old_source, '"' + str(source) + '"')
    response = out / 'compile.rsp'
    response.write_text(response_text)
    runtime_pins = []
    for dependency in PREVIOUS.glob('*.dll'):
        if dependency.name == output.name: continue
        target = out / dependency.name
        shutil.copyfile(dependency, target)
        need(guard.sha(target) == guard.sha(dependency), 'Exact existing reader runtime dependency copy required')
        runtime_pins.append(pin(target))
    for suffix in ('.runtimeconfig.json', '.deps.json'):
        old = (PREVIOUS / 'OriginalShaderObjectProbe.dll').with_suffix(suffix)
        target = output.with_suffix(suffix)
        shutil.copyfile(old, target)
        runtime_pins.append(pin(target))
    dotnet = Path('C:/Program Files/dotnet/dotnet.exe')
    compiler = Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')
    report = {'schema': 'genuine-same-Editor-builtin-Shader-identities/v1', 'status': 'starting', 'phases': [], 'tool': pin(Path(__file__)), 'reader_source': pin(source), 'response': pin(response),
              'native_source': {'path': str(SOURCE), 'file_bytes': before.st_size, 'full_file_sha256_computed': False, 'engine': parsed['engine'], 'platform': parsed['platform'], 'has_type_tree': True,
                                'header_sha256': hashlib.sha256(header).hexdigest(), 'metadata_sha256': hashlib.sha256(metadata).hexdigest(), 'read_metadata_spans': [{'offset': 0, 'bytes': 48}, {'offset': 48, 'bytes': size}]},
              'genuine_native_external_row_proof': pin(GUID_PROOF), 'genuine_native_external_row': external, 'native_inputs': raw_inputs, 'identities': [],
              'runtime_dependency_pins': runtime_pins, 'dotnet': pin(dotnet), 'compiler': pin(compiler), 'Main_modified': False, 'Editor_launched': False, 'Unity_native_API_or_game_code_executed': False}
    try:
        guard.bounded([str(dotnet), str(compiler), '/noconfig', '@' + str(response)], out, out, 'compile-pure-Editor-layout-reader', 512 * 1024**2, 30, report)
        need(output.is_file(), 'Exact pure data reader assembly required')
        report['compiled_reader'] = pin(output)
        home = out / 'DotnetHome'
        home.mkdir()
        env = dict(os.environ, DOTNET_PROCESSOR_COUNT='1', DOTNET_CLI_TELEMETRY_OPTOUT='1', DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1', DOTNET_NOLOGO='1', DOTNET_CLI_HOME=str(home))
        for item in raw_inputs:
            modeldir = out / ('Model-' + str(item['path_id']))
            guard.bounded([str(dotnet), str(output), item['raw']['path'], item['raw']['sha256'], str(item['path_id']), 'discover_actual_genuine_Editor_name', str(modeldir)], out, out, 'read-genuine-Editor-builtin-' + str(item['path_id']), 512 * 1024**2, 60, report, env=env)
            modelpath = modeldir / 'report.json'
            model = json.loads(modelpath.read_bytes())
            need(model['status'] == 'parsed_entire_genuine_Editor_object' and model['serialization_layout'] == 'Editor' and model['name_discovered_by_entire_typed_ReadEditor'] and model['consumed_bytes'] == model['total_bytes'] == item['raw']['bytes'] and model['class_id'] == 48 and model['engine'] == '2020.3.33f1', 'Full genuine native builtin Shader identity proof required')
            form = modeldir / 'ParsedForm.yaml'
            form_text = form.read_text()
            properties = [line.split(': ', 1)[1] for line in form_text.splitlines() if line.startswith('    - m_Name: ')]
            report['identities'].append({'native_path_id': item['path_id'], 'class_id': 48, 'actual_name': model['actual_name'], 'object': item['object'], 'raw': item['raw'],
                                         'typed_model': pin(modelpath), 'entire_Editor_object_consumed': True, 'parsed_form': pin(form), 'property_names': properties, 'property_count': len(properties),
                                         'genuine_external_target': {'asset_path': '', 'guid_raw_hex': external['guid_raw_hex'], 'type': 0, 'path': external['path'], 'target_path_id': item['path_id']}})
            guard.save(out, report)
        need({x['native_path_id'] for x in report['identities']} == set(IDS), 'All four exact builtin identities required')
        report['status'] = 'all_four_genuine_Editor_builtin_Class48_IDs_entirely_ReadEditor_verified'
    except BaseException as error: report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        after = SOURCE.stat()
        need((before.st_size, before.st_mtime_ns) == (after.st_size, after.st_mtime_ns), 'Genuine installed Editor source unchanged')
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'receipt': pin(out / 'run-report.json'), 'identities': [{'id': x['native_path_id'], 'name': x['actual_name'], 'properties': x['property_count']} for x in report['identities']], 'error': report.get('error')}))
    return 0 if report['status'].startswith('all_four_genuine') else 1


if __name__ == '__main__': raise SystemExit(main())
