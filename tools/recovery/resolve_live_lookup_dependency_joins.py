"""Read only original provider-discovery/preparation native type and call joins."""
from pathlib import Path
import datetime as dt, json, mmap, uuid
from collect_all_pinvoke_native import ExternMetadata
from prove_recroom_ondestroy_native_cfg import aliases
from resolve_startup_foundation_native_joins import rgctx, literal
from run_startup_foundation_decode import pin, need, save, check
from audit_custom_urp_native_loop import fields

HERE = Path(__file__).resolve().parent
ROOT = HERE.parents[2] / 'Recovery/RecRoom-2023-04-18'
RUN = ROOT / 'Validation/LiveLookupDependencies-20261023T092454Z-8f9207ed'
RECEIPT_SHA = '9b3a22851c2838fbf2982c99daf4e63ffa256fe04cf0fbde9eacb210e8dc062b'

def main():
    receipt = RUN / 'run-report.json'
    need(pin(receipt)['sha256'] == RECEIPT_SHA, 'Exact Root two-dependency decode')
    done = json.loads(receipt.read_bytes())
    check(done['plan'])
    plan = json.loads(Path(done['plan']['path']).read_bytes())
    check(plan['input'])
    check(done['output'])
    data = json.loads(Path(plan['input']['path']).read_bytes())
    decoded = [json.loads(line) for line in Path(done['output']['path']).read_text().splitlines()]
    need([row['native_method_index'] for row in decoded] == [47884, 47900], 'Exactly two original dependency windows')
    for row in plan['original_inputs']:
        check(row)
    paths = [Path(row['path']) for row in plan['original_inputs']]
    calls, usage_sites = set(), {}
    for row in decoded:
        for instruction in row['instructions']:
            if instruction['flow'] == 'Call' and instruction['operands'] and instruction['operands'][0]['target']:
                calls.add(instruction['operands'][0]['target'])
            if instruction['memory']['ip_relative']:
                address = instruction['memory']['ip_relative_address']
                usage_sites.setdefault(address, []).append({'caller_index': row['native_method_index'], 'ip': hex(instruction['ip']), 'instruction': instruction['text']})
    with paths[0].open('rb') as bf, paths[1].open('rb') as mf, mmap.mmap(bf.fileno(), 0, access=mmap.ACCESS_READ) as binary, mmap.mmap(mf.fileno(), 0, access=mmap.ACCESS_READ) as metadata:
        view = ExternMetadata(binary, metadata)
        mapped, gaps = aliases(view, calls)
        usages = {}
        for address, sites in usage_sites.items():
            try:
                usage = view.usage(address)
                if usage['kind'] == 5:
                    usage['literal'] = literal(view, usage['index'])
                usages[hex(address)] = {'original_usage': usage, 'sites': sites}
            except ValueError as error:
                usages[hex(address)] = {'not_resolved_as_original_metadata_usage': str(error), 'sites': sites}
        contexts = []
        for row in data['methods']:
            method = row['original']
            need(method == view.method_info(method['index']), 'Original owner/token/signature unchanged')
            contexts.append({'original_method': method, 'method_rgctx': rgctx(view, method['image'], int(method['token'], 16))})
        declared = fields(view, 6599)
        providers = []
        for owner in [6607]:
            td = view.row('typeDefinitions', owner, 88)
            start, count = view.i32(metadata, td + 36), view.u16(metadata, td + 64)
            methods = []
            for index in range(start, start + count):
                method = view.method_info(index)
                methods.append({**method, 'original_virtual_slot': view.u16(metadata, view.row('methods', index, 32) + 28)})
            providers.append({'type': view.type_info(owner), 'methods': methods})
    out = ROOT / 'Validation' / ('LiveLookupDependencyJoins-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'original-live-lookup-two-dependencies-typed-native-joins/v1', 'status': 'typed_original_calls_fields_rgctx_and_literals_recorded_CSharp_CFG_recovery_pending', 'producer': pin(Path(__file__)), 'actual_Root_decode_receipt': pin(receipt), 'actual_decoded_output': done['output'], 'original_scopes': plan['input'], 'original_inputs': plan['original_inputs'], 'original_container_fields': declared, 'original_provider_interfaces': providers, 'method_contexts': contexts, 'direct_original_call_aliases': mapped, 'unbacked_alias_tables_unknown': gaps, 'RIP_metadata_and_literal_uses': usages, 'whole_method_CFG_or_CSharp_body_claimed': False, 'Main_modified': False, 'compiler_Unity_game_network_or_native_library_executed': False}
    target = out / 'report.json'
    save(target, report)
    print(json.dumps({'report': pin(target), 'calls': {key: [row['owner'] + '.' + row['name'] for row in value] for key, value in mapped.items() if value}, 'fields': declared, 'metadata_uses': len(usages)}))

if __name__ == '__main__':
    main()
