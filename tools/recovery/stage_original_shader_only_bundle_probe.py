"""Pure bounded preparation/reader proof for one exact original shader-only bundle."""
from pathlib import Path
import datetime as dt
import importlib.util
import json
import os
import shutil
import struct
import uuid
import run_windows_development_define_probe as guard
from shader_program_data import model_program, program_facts

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
BUNDLE_NAME = '1aa49636c51ce59027bc9b2b017069dd.bundle'
BUNDLE_SHA = '5e2dc425ee8ade1aa07ecbd64d60c56714e70bd258d30923898feebe9233508c'
SOURCE = ROOT / 'VerifiedSource/RecRoom_Data/StreamingAssets/aa/StandaloneWindows64' / BUNDLE_NAME
NODE = ROOT / 'RawUnityFSRecovery/Run-20261022T125655Z-2cc7ffa6/Nodes/1aa49636c51ce59027bc9b2b017069dd/CAB-167df2de76e6801a98aeddf97c1bf8b8'
NODE_SHA = '26e425717a45b2acba8a2ae270f0987ffa23404f5fdbfd8af93a1b4c52c04e64'
RAW_SHA = '84100bfc118f6bc47ffa1412ed250de3d19e0fc752f39d12ad69ab3e01232e07'
NAME = 'AG/ShareCameraOverwriteAlpha'
KEY = 'Assets/Core/Content/Recording/ShareCameraOverwriteAlpha.shader'
PATH_ID = 2068146408376674797
PARSER = ROOT / 'AssetRecovery/OriginalFallbackNativeSerializedInput-20261022T205430Z-cab1d2e4/stage_input.py'
BASE = ROOT / 'AssetRecovery/OriginalShaderWindowsBuildFixture-Mixed-20261022T214413Z-51ccf456/plan.json'
need = guard.need


def pin(path):
    return {'path': str(path.resolve()), 'bytes': path.stat().st_size, 'sha256': guard.sha(path)}


def main():
    guard.safety.assert_editor_closed()
    need(guard.sha(BASE) == 'ff8427db7cdd28c60bab2b3e93d9d50c114f03fc58e7162ed798462a7f057b76', 'Pinned reader base plan required')
    plan = json.loads(BASE.read_bytes())
    for row in plan['reader_pins'] + plan['support_sources'] + [plan[k] for k in ('reader', 'dotnet', 'launcher')]:
        guard.checked(row)
    need(SOURCE.stat().st_size == 18205 and guard.sha(SOURCE) == BUNDLE_SHA, 'Exact small original bundle required')
    need(NODE.stat().st_size == 81296 and guard.sha(NODE) == NODE_SHA, 'Exact original raw node required')
    need(guard.sha(PARSER) == '98b4cd637d310605981a57a7284660096dc4d2d4e8fa6b0f5240a41d4e2b02ae', 'Exact existing full metadata parser required')
    spec = importlib.util.spec_from_file_location('original_shader_bundle_metadata', PARSER)
    parser = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(parser)
    data = NODE.read_bytes()
    metadata_size, declared, data_start, unknown = struct.unpack_from('>Iqqq', data, 20)
    need(struct.unpack_from('>IIII', data) == (0, 0, 22, 0) and declared == len(data) and unknown == 0 and data[16:20] == bytes(4), 'Exact original little-endian v22 node required')
    metadata = parser.parse_metadata(data[48:48 + metadata_size], data_start, len(data))
    need(metadata['engine'] == '2020.3.33f1' and metadata['platform'] == 19 and metadata['has_type_tree'], 'Exact original Windows model/type trees required')
    need(sorted(t['class_id'] for t in metadata['types']) == [48, 142] and len(metadata['objects']) == 2 and metadata['script_type_count'] == metadata['ref_type_count'] == len(metadata['externals']) == 0, 'Only one Shader and original AssetBundle index; no script or external closure')
    shader = next(o for o in metadata['objects'] if o['path_id'] == PATH_ID)
    need(metadata['types'][shader['type_index']]['class_id'] == 48 and shader['offset'] == 74592 and shader['size'] == 6704, 'Exact original Shader object table identity')
    raw = data[shader['offset']:shader['offset'] + shader['size']]
    need(guard.sha(NODE) == NODE_SHA and len(raw) == 6704 and __import__('hashlib').sha256(raw).hexdigest() == RAW_SHA and raw[-12:] == bytes.fromhex('000000000000000001000000'), 'Entire raw Shader hash/dependency0/texture0/baked1 proof')
    owner = next(o for o in metadata['objects'] if metadata['types'][o['type_index']]['class_id'] == 142)
    bundle_raw = data[owner['offset']:owner['offset'] + owner['size']]
    c = parser.Cursor(bundle_raw)
    def string():
        length = c.count(4096)
        value = c.take(length).decode('utf-8')
        c.align4()
        return value
    internal_name = string()
    preload_count = c.count(100)
    preloads = [(c.scalar('i'), c.scalar('q')) for _ in range(preload_count)]
    count = c.count(100)
    entries = []
    for _ in range(count):
        entries.append({'key': string(), 'preload_index': c.scalar('i'), 'preload_count': c.scalar('i'), 'file_id': c.scalar('i'), 'path_id': c.scalar('q')})
    need(preloads == [(0, PATH_ID)] and entries == [{'key': KEY, 'preload_index': 0, 'preload_count': 1, 'file_id': 0, 'path_id': PATH_ID}], 'Exact original native container key and sole local Shader preload')
    out = ROOT / 'AssetRecovery' / ('OriginalShaderOnlyBundleRuntimeInput-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    local_bundle = out / BUNDLE_NAME
    shutil.copyfile(SOURCE, local_bundle)
    need(guard.sha(local_bundle) == BUNDLE_SHA, 'Unmodified original bundle copy required')
    rawpath = out / 'OriginalShader.bin'
    rawpath.write_bytes(raw)
    config = out / 'bundle-runtime-config.json'
    config.write_text(json.dumps({'bundles': [{'path': str(local_bundle), 'sha256': BUNDLE_SHA}], 'target_index': 0, 'asset_key': KEY}, indent=2) + '\n', encoding='utf-8')
    report = {'schema': 'exact-original-shader-only-bundle-runtime-input/v1', 'status': 'starting', 'phases': [], 'tool': pin(Path(__file__)),
              'original_bundle': pin(SOURCE), 'runtime_bundle_copy': pin(local_bundle), 'verified_raw_node': pin(NODE), 'raw_shader': pin(rawpath),
              'runtime_config': pin(config), 'engine': metadata['engine'], 'platform': metadata['platform'], 'class_ids': [48, 142],
              'object_count': 2, 'script_count': 0, 'external_count': 0, 'ref_type_count': 0,
              'native_container': {'internal_name': internal_name, 'object': owner, 'payload_bytes': len(bundle_raw), 'prefix_consumed_bytes': c.pos, 'entire_payload_claimed_parsed': False, 'preloads': preloads, 'entries': entries},
              'shader_dependency_count': 0, 'shader_nonmodifiable_texture_count': 0, 'shader_baked': True,
              'Main_modified': False, 'Editor_launched': False, 'compiler_launched': False, 'player_launched': False,
              'runtime_load_supported_or_GPU_render_claimed': False}
    try:
        home = out / 'DotnetHome'
        home.mkdir()
        env = dict(os.environ, DOTNET_PROCESSOR_COUNT='1', DOTNET_CLI_TELEMETRY_OPTOUT='1', DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1', DOTNET_NOLOGO='1', DOTNET_CLI_HOME=str(home))
        modeldir = out / 'Model'
        guard.bounded([plan['dotnet']['path'], plan['reader']['path'], str(rawpath), RAW_SHA, str(PATH_ID), NAME, str(modeldir)], out, out, 'read-one-original-shader-only-bundle-object', 512 * 1024**2, 60, report, env=env)
        model = json.loads((modeldir / 'report.json').read_bytes())
        need(model['actual_name'] == NAME and model['status'] == 'parsed_entire_original_object' and model['total_bytes'] == model['consumed_bytes'] == len(raw), 'Entire actual native Shader model/name required')
        facts = program_facts(model_program(model, raw))
        need(facts['dxbc_chunks'] > 0, 'Actual original D3D11 programs required')
        report.update(status='exact_original_shader_only_bundle_closed_and_programs_verified_runtime_unproven', model=pin(modeldir / 'report.json'), program=facts)
    except BaseException as error:
        report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        need(guard.sha(SOURCE) == BUNDLE_SHA and guard.sha(NODE) == NODE_SHA and guard.sha(local_bundle) == BUNDLE_SHA, 'All original inputs and copied bundle remain unchanged')
        guard.save(out, report)
        print(json.dumps({'status': report['status'], 'receipt': pin(out / 'run-report.json'), 'runtime_config': pin(config), 'original_DXBC': report.get('program', {}).get('dxbc_chunks'), 'error': report.get('error')}))
    return 0 if report['status'].startswith('exact_original_shader_only_bundle_closed') else 1


if __name__ == '__main__':
    raise SystemExit(main())
