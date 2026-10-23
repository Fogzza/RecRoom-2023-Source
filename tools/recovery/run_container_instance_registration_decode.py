"""Prepare or Root-decode three original complete generic registration scopes."""
from pathlib import Path
import argparse, datetime as dt, json, mmap, struct, uuid
import run_live_lookup_dependencies_decode as scope_source
from run_live_lookup_dependencies_decode import connected_scope
from run_startup_foundation_decode import HERE, ROOT, guard, pin, need, save, check, DECODER, GUARD_SHA, LAUNCHER_SHA, DECODER_SHA
from prepare_startup_foundation_slice import SOURCE_PINS
from collect_all_pinvoke_native import ExternMetadata
from audit_custom_urp_native_loop import pdata

SCHEMA = 'original-complete-instance-registration-inert-decode/v1'
SPECS = [(47872, 452803, 0x1813b9ce0, [], ['MNALHHOLFGL']), (47876, 452784, 0x1813b9920, [], ['System.Object', 'System.Object']), (47985, 173970, 0x181b39ff0, ['System.Object'], [])]


def prepare():
    paths = [ROOT / 'CodeSource' / name for name in SOURCE_PINS]
    for path in paths:
        need(pin(path)['sha256'] == SOURCE_PINS[path.relative_to(ROOT / 'CodeSource').as_posix()], 'Exact original client hashes')
    methods = []
    with paths[0].open('rb') as bf, paths[1].open('rb') as mf, mmap.mmap(bf.fileno(), 0, access=mmap.ACCESS_READ) as b, mmap.mmap(mf.fileno(), 0, access=mmap.ACCESS_READ) as m:
        v = ExternMetadata(b, m)
        rows, parents = pdata(v)
        targets = v.generic_targets({x[1] for x in SPECS})
        for index, spec, pointer, classes, arguments in SPECS:
            mi, ci, gi = struct.unpack_from('<iii', b, v.method_specs + spec * 12)
            need(mi == index and [v.typename(t) for t in v.inst(ci)] == classes and [v.typename(t) for t in v.inst(gi)] == arguments, 'Exact registered original MethodSpec specialization')
            need(len(targets[spec]) == 1 and int(targets[spec][0]['pointer'], 16) == pointer, 'Exact original generic registration')
            scope = connected_scope(v, pointer, rows, parents)
            end = pointer + len(bytes.fromhex(scope['runtime_function']['bytes']))
            need(not any(pointer < v.u64(b, v.generic_pointers + i * 8) < end for i in range(v.generic_pointer_count)), 'No separate registered generic start inside connected scope')
            methods.append({'original': v.method_info(index), 'original_MethodSpec': spec, 'class_arguments': classes, 'method_arguments': arguments, 'original_generic_registration': targets[spec][0], **scope})
    need([len(bytes.fromhex(r['runtime_function']['bytes'])) for r in methods] == [308, 272, 168] and [r['complete_connected_chain_regions'] for r in methods] == [1, 1, 3], 'Complete3-region provider ctor replaces the old37B partial window')
    out = ROOT / 'Validation' / ('ContainerInstanceRegistration-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    source = out / 'three-complete-original-generic-scopes.json'
    save(source, {'methods': methods, 'original_bytes': 748, 'shared_reference_generic_bodies_not_unregistered_closed_type_claims': True})
    runtime = [pin(DECODER / name) for name in ['DisassemblePInvokeWrappers.dll', 'Iced.dll', 'DisassemblePInvokeWrappers.runtimeconfig.json']]
    need(runtime[0]['sha256'] == DECODER_SHA, 'Exact previously reviewed inert decoder')
    plan = {'schema': SCHEMA, 'fixture': str(out), 'runner': pin(Path(__file__)), 'scope_source': pin(Path(scope_source.__file__)), 'input': pin(source), 'original_inputs': [pin(p) for p in paths], 'decoder_runtime': runtime, 'dotnet': pin(Path('C:/Program Files/dotnet/dotnet.exe')), 'guard': pin(HERE / 'original_shader_pair_editor_conversion.py'), 'launcher': pin(HERE / 'owned_suspended_launch.py'), 'cap_bytes': 256 * 1024**2, 'reserve_bytes': guard.RESERVE, 'maximum_seconds': 90, 'output': str(out / 'decoded-original-registration.jsonl'), 'Main_modified': False}
    need(plan['guard']['sha256'] == GUARD_SHA and plan['launcher']['sha256'] == LAUNCHER_SHA, 'Exact reviewed resource guard')
    target = out / 'plan.json'
    save(target, plan)
    print(json.dumps({'plan': pin(target), 'original_bytes': 748}))


def execute(path, digest, run):
    path = path.resolve(strict=True)
    need(pin(path)['sha256'] == digest, 'Explicit Root-reviewed plan hash')
    p = json.loads(path.read_bytes())
    out = Path(p['fixture']).resolve(strict=True)
    need(p['schema'] == SCHEMA and path.parent == out and out.parent == ROOT / 'Validation' and out.name.startswith('ContainerInstanceRegistration-'), 'Exact isolated workspace')
    for row in [p[k] for k in ['runner', 'scope_source', 'input', 'dotnet', 'guard', 'launcher']] + p['original_inputs'] + p['decoder_runtime']:
        check(row)
    need(p['runner'] == pin(Path(__file__)) and p['guard']['sha256'] == GUARD_SHA and p['launcher']['sha256'] == LAUNCHER_SHA and p['decoder_runtime'][0]['sha256'] == DECODER_SHA and p['cap_bytes'] == 256 * 1024**2 and p['reserve_bytes'] == guard.RESERVE and p['maximum_seconds'] == 90 and p['output'] == str(out / 'decoded-original-registration.jsonl'), 'Exact reviewed inputs and fixed owned bounds')
    data = json.loads(Path(p['input']['path']).read_bytes())
    need([r['original']['index'] for r in data['methods']] == [x[0] for x in SPECS] and data['original_bytes'] == 748, 'Exact original scopes')
    if not run:
        print(json.dumps({'status': 'verified_no_child_started'}))
        return 0
    need(not Path(p['output']).exists() and not (out / 'run-report.json').exists(), 'Fresh one-shot output')
    report = {'schema': SCHEMA, 'status': 'starting', 'plan': pin(path), 'phases': [], 'Main_modified': False, 'original_game_Unity_or_network_executed': False, 'CSharp_recovery_claimed': False}
    try:
        guard.CAP = p['cap_bytes']
        guard.bounded([p['dotnet']['path'], p['decoder_runtime'][0]['path'], p['input']['path'], p['output']], out, 'decode-three-complete-original-registration-scopes', report)
        decoded = [json.loads(line) for line in Path(p['output']).read_text().splitlines()]
        need([r['native_method_index'] for r in decoded] == [x[0] for x in SPECS], 'Exact output identities')
        for source, actual in zip(data['methods'], decoded):
            pos = int(source['native_pointer'], 16)
            need(actual['native_pointer'] == pos, 'Exact original entry')
            for instruction in actual['instructions']:
                need(instruction['ip'] == pos and instruction['code'] != 'INVALID' and 1 <= instruction['length'] <= 15, 'Contiguous valid original instructions')
                pos += instruction['length']
            need(pos == int(source['native_pointer'], 16) + len(bytes.fromhex(source['runtime_function']['bytes'])), 'Every complete-scope byte decoded')
        report.update(status='three_complete_original_registration_scopes_decoded_semantics_pending', output=pin(p['output']), original_bytes=748)
    except BaseException as error:
        report.update(status='failed_preserve_outputs', error=repr(error))
    finally:
        save(out / 'run-report.json', report)
    print(json.dumps({'status': report['status'], 'report': pin(out / 'run-report.json'), 'error': report.get('error')}))
    return 0 if report['status'] == 'three_complete_original_registration_scopes_decoded_semantics_pending' else 1


def main():
    a = argparse.ArgumentParser(description=__doc__)
    a.add_argument('--plan', type=Path)
    a.add_argument('--plan-sha256')
    a.add_argument('--run', action='store_true')
    args = a.parse_args()
    if args.plan:
        need(args.plan_sha256, 'Explicit reviewed plan hash')
        return execute(args.plan, args.plan_sha256, args.run)
    need(not args.run and not args.plan_sha256, 'Prepare only first')
    prepare()
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
