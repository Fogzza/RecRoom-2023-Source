"""Prepare/run bounded generated-model shader conversions outside Main only.

The explicit manifest is an input from the independently reviewed original
namespace resolution audit. This runner does not infer targets by shader name.
"""
from pathlib import Path
import argparse
import datetime as dt
import hashlib
import json
import os
import re
import shutil
import sys
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
PREVIOUS = ROOT / 'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
sys.path.insert(0, str(ROOT / 'Tools'))
import original_shader_pair_editor_conversion as guard
guard.CAP = 512 * 1024**2
SOURCE_NAME = 'ConvertOriginalShaderCollectionToEditor.cs'


def need(value, message):
    if not value:
        raise RuntimeError(message)


def digest(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()


def pin(path):
    path = Path(path).resolve(strict=True)
    return {'path': str(path), 'bytes': path.stat().st_size, 'sha256': digest(path)}


def save(path, value):
    with path.open('x', encoding='utf-8') as stream:
        json.dump(value, stream, indent=2)
        stream.write('\n')


def check(row):
    need(pin(row['path']) == {key: row[key] for key in ('path', 'bytes', 'sha256')}, 'Pinned input/proof changed')


def compile_plan():
    out = ROOT / 'AssetRecovery' / ('OriginalShaderCollectionEditorConversion-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    source = out / SOURCE_NAME
    shutil.copyfile(HERE / SOURCE_NAME, source)
    response = out / 'compile.rsp'
    assembly = out / 'OriginalShaderObjectProbe.dll'
    text = (PREVIOUS / 'compile.rsp').read_text()
    text, count = re.subn(r'(?m)^/out:.*$', lambda _: '/out:"' + str(assembly) + '"', text)
    need(count == 1, 'Proven Csc response output anchor')
    original = '"' + str(HERE / 'OriginalShaderObjectProbe.cs') + '"'
    need(text.count(original) == 1, 'Proven Csc source anchor')
    text = text.replace(original, '"' + str(source) + '"')
    response.write_text(text, encoding='utf-8', newline='\n')
    runtime = []
    for path in sorted(PREVIOUS.glob('*.dll')):
        if path.name == assembly.name:
            continue
        target = out / path.name
        shutil.copyfile(path, target)
        need(digest(path) == digest(target), 'Exact proven runtime copy')
        runtime.append(pin(target))
    for suffix in ('.runtimeconfig.json', '.deps.json'):
        target = assembly.with_suffix(suffix)
        shutil.copyfile((PREVIOUS / assembly.name).with_suffix(suffix), target)
        runtime.append(pin(target))
    references = [pin(Path(value)) for value in re.findall(r'(?m)^/reference:"([^"]+)"$', text)]
    plan = {'schema': 'prepared-original-Shader-Editor-collection-converter/v1', 'status': 'prepared_no_child_started',
        'fixture': str(out), 'source': pin(source), 'response': pin(response), 'output': str(assembly),
        'runtime': runtime, 'references': references, 'runner': pin(Path(__file__)),
        'guard': pin(HERE / 'original_shader_pair_editor_conversion.py'),
        'launcher': pin(HERE / 'owned_suspended_launch.py'),
        'dotnet': pin(Path('C:/Program Files/dotnet/dotnet.exe')),
        'compiler': pin(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),
        'cap_bytes': guard.CAP, 'reserve_bytes': guard.RESERVE, 'Main_modified': False, 'Unity_launched': False}
    need(plan['launcher']['sha256'] == '3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958', 'Reviewed suspended launcher required')
    path = out / 'plan.json'
    save(path, plan)
    print(json.dumps({'plan': pin(path), 'compile_command': ['python', '-B', str(Path(__file__)), '--plan', str(path), '--plan-sha256', digest(path), '--compile']}))


def execute(plan_path, expected, compile_only, manifest_path=None, manifest_sha=None):
    need(digest(plan_path) == expected, 'Reviewed conversion plan changed')
    plan = json.loads(plan_path.read_bytes())
    out = Path(plan['fixture']).resolve(strict=True)
    need(out.is_relative_to(ROOT / 'AssetRecovery') and out.name.startswith('OriginalShaderCollectionEditorConversion-') and plan_path.parent.resolve() == out, 'Recovery-only conversion workspace')
    for row in [plan[key] for key in ('source', 'response', 'runner', 'guard', 'launcher', 'dotnet', 'compiler')] + plan['runtime'] + plan['references']:
        check(row)
    receipt = {'schema': 'guarded-original-Shader-Editor-collection-conversion/v1', 'status': 'starting',
        'plan': pin(plan_path), 'phases': [], 'Main_modified': False, 'Unity_launched': False, 'native_API_or_game_code_executed': False}
    if compile_only:
        need(not Path(plan['output']).exists(), 'Fresh compile output required')
        guard.bounded([plan['dotnet']['path'], plan['compiler']['path'], '/noconfig', '@' + plan['response']['path']], out, 'compile-collection-converter', receipt)
        receipt.update(status='compiled_pure_converter', assembly=pin(plan['output']))
        path = out / 'compile-report.json'
        save(path, receipt)
        print(json.dumps({'status': receipt['status'], 'report': pin(path)}))
        return
    need(manifest_path is not None and manifest_sha is not None and digest(manifest_path) == manifest_sha, 'Explicit pinned independently resolved manifest required')
    compiled = json.loads((out / 'compile-report.json').read_bytes())
    need(compiled['status'] == 'compiled_pure_converter', 'Actual bounded successful compile proof required')
    check(compiled['assembly'])
    manifest = json.loads(manifest_path.read_bytes())
    need(manifest['schema'] == 'resolved-original-Shader-Editor-collection/v1' and 1 <= len(manifest['shaders']) <= 179, 'Bounded explicit shader manifest')
    for proof in manifest['proofs']:
        check(proof)
    ids = [row['guid'] for row in manifest['shaders']]
    need(len(ids) == len(set(ids)) and all(re.fullmatch('[0-9a-f]{32}', value) for value in ids), 'Unique original shader GUID identities')
    run = out / ('Run-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    run.mkdir()
    save(run / 'manifest.json', manifest)
    home = run / 'DotnetHome'
    home.mkdir()
    env = dict(os.environ, DOTNET_PROCESSOR_COUNT='1', DOTNET_CLI_TELEMETRY_OPTOUT='1', DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1', DOTNET_NOLOGO='1', DOTNET_CLI_HOME=str(home))
    receipt.update(manifest=pin(manifest_path), compile_proof=pin(out / 'compile-report.json'), results=[])
    try:
        for index, row in enumerate(manifest['shaders']):
            need(row['schema'] == 'resolved-original-Shader-Editor-conversion-input/v1', 'Explicit per-source conversion schema')
            for source in [row['source']] + row['proofs']:
                check(source)
            spec_path = run / (row['guid'] + '.json')
            save(spec_path, row)
            target = run / row['guid']
            guard.bounded([plan['dotnet']['path'], plan['output'], str(spec_path), str(target)], run, 'shader-' + str(index).zfill(3), receipt, env)
            proof = json.loads((target / 'report.json').read_bytes())
            need(proof['status'] == 'original_bytes_preserved_except_name_and_manifest_typed_PPtrs'
                 and proof['guid'] == row['guid'] and proof['source_sha256'] == row['source']['sha256']
                 and proof['entire_ParsedForm_equal'] and proof['all_five_original_program_fields_equal']
                 and proof['all_bytes_outside_name_and_manifest_typed_PPtr_windows_equal'], 'Exact original-object conversion proof')
            receipt['results'].append({'guid': row['guid'], 'name': row['name'], 'spec': pin(spec_path), 'report': pin(target / 'report.json'),
                'editor_payload': pin(target / 'EditorShaderObject.bin'), 'normalized_release': pin(target / 'ReleaseReserialized.bin'),
                'original_compiled_blob': pin(target / 'OriginalCompiledBlob.bin'), 'ParsedForm': pin(target / 'ParsedForm.yaml')})
        receipt['status'] = 'all_manifest_original_Shader_Editor_conversions_verified'
    except BaseException as error:
        receipt.update(status='stopped_preserve_completed_outputs', error=str(error))
    save(run / 'run-report.json', receipt)
    print(json.dumps({'status': receipt['status'], 'report': pin(run / 'run-report.json'), 'completed': len(receipt['results']), 'error': receipt.get('error')}))
    need('error' not in receipt, 'Collection conversion held; inspect bounded receipt')


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--plan', type=Path)
    parser.add_argument('--plan-sha256')
    parser.add_argument('--compile', action='store_true')
    parser.add_argument('--manifest', type=Path)
    parser.add_argument('--manifest-sha256')
    args = parser.parse_args()
    if args.plan:
        execute(args.plan.resolve(strict=True), args.plan_sha256, args.compile, args.manifest, args.manifest_sha256)
    else:
        need(not args.compile and args.manifest is None, 'Prepare first')
        compile_plan()


if __name__ == '__main__':
    main()
