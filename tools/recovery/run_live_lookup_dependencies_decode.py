"""Prepare or Root-run inert decoding of two original lookup dependencies."""
from pathlib import Path
import argparse, datetime as dt, hashlib, json, mmap, struct, uuid
import run_startup_foundation_decode as base
from run_startup_foundation_decode import guard, pin, need, save, check, DECODER, GUARD_SHA, LAUNCHER_SHA, DECODER_SHA
from collect_all_pinvoke_native import ExternMetadata
from prepare_startup_foundation_slice import SOURCE_PINS
from audit_custom_urp_native_loop import pdata

HERE = Path(__file__).resolve().parent
ROOT = HERE.parents[2] / 'Recovery/RecRoom-2023-04-18'
SCHEMA = 'prepared-two-original-live-lookup-dependency-scopes-inert-decode/v1'
INDICES = [47884, 47900]

def connected_scope(view, pointer, rows, parents):
    hits = [row for row in rows if row[0] == pointer - view.base]
    need(len(hits) == 1 and hits[0] not in parents, 'Exact unchained original registered root')
    selected = {hits[0]}
    while True:
        more = {child for child, parent in parents.items() if parent in selected} - selected
        if not more:
            break
        selected |= more
        need(len(selected) <= 32, 'Bounded genuine connected chain')
    ordered = sorted(selected)
    details = []
    for index, (start, end, unwind) in enumerate(ordered):
        need(index == 0 or ordered[index - 1][1] == start, 'Only contiguous proved chained regions')
        at = view.raw(view.base + start, end - start)
        code = bytes(view.b[at:at + end - start])
        details.append({'start_rva': start, 'end_rva': end, 'unwind_rva': unwind, 'bytes': code.hex(), 'sha256': hashlib.sha256(code).hexdigest(), 'chain_parent': list(parents[(start, end, unwind)]) if (start, end, unwind) in parents else None})
    code = b''.join(bytes.fromhex(row['bytes']) for row in details)
    need(0 < len(code) <= 32768, 'Finite complete per-method native scope')
    return {'native_pointer': hex(pointer), 'runtime_function': {'bytes': code.hex(), 'sha256': hashlib.sha256(code).hexdigest()}, 'original_connected_regions': details, 'complete_connected_chain_regions': len(details), 'whole_CFG_or_CSharp_recovery_claimed': False}

def prepare():
    paths = [ROOT / 'CodeSource' / name for name in SOURCE_PINS]
    for path in paths:
        need(pin(path)['sha256'] == SOURCE_PINS[path.relative_to(ROOT / 'CodeSource').as_posix()], 'Actual original client pins')
    with paths[0].open('rb') as bf, paths[1].open('rb') as mf, mmap.mmap(bf.fileno(), 0, access=mmap.ACCESS_READ) as b, mmap.mmap(mf.fileno(), 0, access=mmap.ACCESS_READ) as m:
        view = ExternMetadata(b, m)
        spec = 452445
        mi, ci, gi = struct.unpack_from('<iii', b, view.method_specs + spec * 12)
        need(mi == 47884 and not view.inst(ci) and [view.typename(t) for t in view.inst(gi)] == ['System.Object'], 'Exact original concrete object-shared provider-discovery MethodSpec')
        targets = view.generic_targets({spec})[spec]
        need(len(targets) == 1 and targets[0]['pointer'] == '0x1813b9290', 'Exact original generic pointer-table registration')
        rows, parents = pdata(view)
        methods = []
        for index, name, pointer in [(47884, 'CPBMOKFMMMK', 0x1813b9290), (47900, 'LNFNAIMOFOF', 0x186744a30)]:
            method = view.method_info(index)
            need(method['owner'] == 'MNALHHOLFGL' and method['name'] == name and (index == 47884 or view.method_pointer(method) == pointer), 'Exact original owner/direct or separately proved generic registration')
            scope = connected_scope(view, pointer, rows, parents)
            if index == 47884:
                scope.update(original_MethodSpec=spec, class_arguments=[], method_arguments=['System.Object'], original_generic_registration=targets[0])
            end = pointer + len(bytes.fromhex(scope['runtime_function']['bytes']))
            generics = [{'pointer_index': i, 'pointer': hex(view.u64(b, view.generic_pointers + i * 8))} for i in range(view.generic_pointer_count) if pointer < view.u64(b, view.generic_pointers + i * 8) < end]
            module = view.modules['UJect.Runtime.dll']
            at = view.raw(module['pointers_va'], module['count'] * 8)
            direct = [{'token': hex(0x06000000 | (i + 1)), 'pointer': hex(view.u64(b, at + i * 8))} for i in range(module['count']) if pointer < view.u64(b, at + i * 8) < end]
            need(not generics and not direct, 'No other registered generic or same-module direct primary absorbed')
            methods.append({'original': method, **scope, 'all_generic_and_same_module_direct_entry_interior_empty': True, 'other_unbacked_module_tables_not_assumed_empty': True})
    out = ROOT / 'Validation' / ('LiveLookupDependencies-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    source = out / 'two-original-complete-dependency-scopes.json'
    total = sum(len(bytes.fromhex(row['runtime_function']['bytes'])) for row in methods)
    save(source, {'schema': SCHEMA, 'methods': methods, 'original_inputs': [pin(path) for path in paths], 'original_bytes': total, 'Main_modified': False, 'CSharp_recovery_claimed': False})
    runtime = [pin(DECODER / name) for name in ['DisassemblePInvokeWrappers.dll', 'Iced.dll', 'DisassemblePInvokeWrappers.runtimeconfig.json']]
    need(runtime[0]['sha256'] == DECODER_SHA, 'Reviewed inert decoder')
    plan = {'schema': SCHEMA, 'status': 'prepared_no_child_started', 'fixture': str(out), 'runner': pin(Path(__file__)), 'base_runner': pin(Path(base.__file__)), 'input': pin(source), 'original_inputs': [pin(path) for path in paths], 'decoder_runtime': runtime, 'dotnet': pin(Path('C:/Program Files/dotnet/dotnet.exe')), 'guard': pin(HERE / 'original_shader_pair_editor_conversion.py'), 'launcher': pin(HERE / 'owned_suspended_launch.py'), 'cap_bytes': 256 * 1024**2, 'reserve_bytes': guard.RESERVE, 'maximum_seconds': 90, 'output': str(out / 'decoded-complete-lookup-dependencies.jsonl'), 'original_bytes': total, 'Main_modified': False, 'compiler_Unity_game_network_executed': False}
    need(plan['guard']['sha256'] == GUARD_SHA and plan['launcher']['sha256'] == LAUNCHER_SHA, 'Reviewed assign-before-resume launcher/guard')
    target = out / 'plan.json'
    save(target, plan)
    print(json.dumps({'plan': pin(target), 'methods': [{'index': row['original']['index'], 'bytes': len(bytes.fromhex(row['runtime_function']['bytes'])), 'regions': row['complete_connected_chain_regions']} for row in methods]}))

def execute(path, digest, run):
    path = path.resolve(strict=True)
    need(pin(path)['sha256'] == digest, 'Explicit Root-reviewed decoder plan')
    plan = json.loads(path.read_bytes())
    out = Path(plan['fixture']).resolve(strict=True)
    need(path.parent == out and out.parent == ROOT / 'Validation' and out.name.startswith('LiveLookupDependencies-') and plan['schema'] == SCHEMA, 'Exact isolated output scope')
    for row in [plan[key] for key in ['runner', 'base_runner', 'input', 'dotnet', 'guard', 'launcher']] + plan['original_inputs'] + plan['decoder_runtime']:
        check(row)
    need(plan['runner'] == pin(Path(__file__)) and plan['guard']['sha256'] == GUARD_SHA and plan['launcher']['sha256'] == LAUNCHER_SHA and plan['decoder_runtime'][0]['sha256'] == DECODER_SHA and plan['cap_bytes'] == 256 * 1024**2 and plan['reserve_bytes'] == guard.RESERVE and plan['maximum_seconds'] == 90, 'Exact trusted inputs and bounds')
    data = json.loads(Path(plan['input']['path']).read_bytes())
    need([row['original']['index'] for row in data['methods']] == INDICES and data['original_bytes'] == plan['original_bytes'] <= 65536 and plan['output'] == str(out / 'decoded-complete-lookup-dependencies.jsonl'), 'Exactly two finite original scopes')
    if not run:
        print(json.dumps({'status': 'verified_no_child_started'}))
        return 0
    need(not Path(plan['output']).exists() and not (out / 'run-report.json').exists(), 'Fresh one-shot diagnostic; never overwrite a failed attempt')
    report = {'schema': SCHEMA, 'status': 'starting', 'plan': pin(path), 'phases': [], 'Main_modified': False, 'compiler_Unity_game_network_executed': False, 'CSharp_recovery_claimed': False}
    try:
        guard.CAP = plan['cap_bytes']
        guard.bounded([plan['dotnet']['path'], plan['decoder_runtime'][0]['path'], plan['input']['path'], plan['output']], out, 'decode-two-complete-original-lookup-dependencies', report)
        decoded = [json.loads(line) for line in Path(plan['output']).read_text().splitlines()]
        need([row['native_method_index'] for row in decoded] == INDICES, 'Exact two original instruction streams')
        for original, actual in zip(data['methods'], decoded):
            position = int(original['native_pointer'], 16)
            for instruction in actual['instructions']:
                need(instruction['ip'] == position and 1 <= instruction['length'] <= 15 and instruction['code'] != 'INVALID', 'Contiguous exact native instruction coverage')
                position += instruction['length']
            need(position == int(original['native_pointer'], 16) + len(bytes.fromhex(original['runtime_function']['bytes'])), 'Every original byte decoded exactly once')
        report.update(status='two_original_lookup_dependencies_inert_decoded_semantics_pending', output=pin(plan['output']), original_bytes=plan['original_bytes'])
    except BaseException as error:
        report.update(status='failed_preserve_outputs', error=repr(error))
    finally:
        save(out / 'run-report.json', report)
    print(json.dumps({'status': report['status'], 'report': pin(out / 'run-report.json'), 'error': report.get('error')}))
    return 0 if report['status'] == 'two_original_lookup_dependencies_inert_decoded_semantics_pending' else 1

if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--prepare', action='store_true')
    parser.add_argument('--plan', type=Path)
    parser.add_argument('--plan-sha256')
    parser.add_argument('--run', action='store_true')
    args = parser.parse_args()
    if args.prepare:
        need(not args.plan and not args.run, 'Preparation never implicitly launches')
        prepare()
    else:
        need(args.plan and args.plan_sha256, 'Pinned plan required')
        raise SystemExit(execute(args.plan, args.plan_sha256, args.run))
