"""Stage the original reference-constrained lookup body from its full native CFG.

Only original bytes and metadata are read. No managed target, SDK, Unity, game,
or network code runs. Provider discovery/initialization remain separate gaps.
"""
from pathlib import Path
import datetime as dt, hashlib, json, mmap, struct, sys, uuid
HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE.parent / 'ConstructorEvidence'))
from audit_ogpeg_constructors import Decoder
from collect_all_pinvoke_native import ExternMetadata
from prepare_startup_foundation_slice import SOURCE_PINS
from resolve_startup_foundation_native_joins import rgctx
from stage_title_page_route_slice import dispatch
from prove_nameserver_request_factory_cfg import no_chained_entries
from inventory_recroom_game_root_native import region
from audit_custom_urp_native_loop import fields

ROOT = HERE.parents[2] / 'Recovery/RecRoom-2023-04-18'
JOINS = ROOT / 'Validation/LiveLookupTypedJoins-20261023T091125Z-58b1b4b4/report.json'
JOINS_SHA = '53a9a3123fc8fe7976b1e92be066a10b8d808e1c71db6b98a93bf6452952bc71'
WINDOWS = ROOT / 'Validation/LiveContainerPathSlice-20261023T083125Z-cc7dd812/five-original-live-container-windows.json'

def need(value, message):
    if not value:
        raise ValueError(message)

def pin(path):
    with Path(path).open('rb') as stream:
        digest = hashlib.file_digest(stream, 'sha256').hexdigest()
    return {'path': str(path), 'bytes': Path(path).stat().st_size, 'sha256': digest}

def shape(code, va):
    d = Decoder(code, va)
    d.literal('48 89 5c 24 10 48 89 6c 24 18 56 57 41 56 48 83 ec 30')
    flag = d.relative('80 3d', '00')
    d.literal('49 8b e9 4d 8b f0 48 8b fa 48 8b d9')
    ready_branch = d.short('75')
    provider_use = d.relative('48 8d 0d')
    init1 = d.relative('e8')
    message_use = d.relative('48 8d 0d')
    init2 = d.relative('e8')
    written = d.relative('c6 05', '01')
    ready = va + d.at
    message_load = d.relative('48 8b 15')
    d.literal('33 f6 0f b6 4b 39 45 33 c0 48 89 74 24 50')
    disposed = d.relative('e8')
    d.literal('33 d2 48 8b cb')
    prepare = d.relative('e8')
    d.literal('48 8b 45 30 4c 8d 44 24 50 0f 10 07 48 8d 54 24 20 48 8b cb 4c 8b 10 4d 8b ca 0f 29 44 24 20 41 ff 12 84 c0')
    success = d.short('75')
    d.literal('33 c0 49 89 06')
    exit_at = va + d.at
    d.literal('48 8b 5c 24 58 48 8b 6c 24 60 48 83 c4 30 41 5e 5f 5e c3')
    success_at = va + d.at
    d.literal('4c 8b 44 24 50 4d 85 c0')
    null_provider = d.relative('0f 84')
    provider_load = d.relative('48 8b 15')
    d.literal('33 c9')
    invoke = d.relative('e8')
    d.literal('48 8b 4d 30 48 8b d8 48 8b 79 08 f6 87 32 01 00 00 01')
    initialized1 = d.short('75')
    d.literal('48 8b cf')
    initialize1 = d.relative('e8')
    initialized1_at = va + d.at
    d.literal('48 85 db')
    nonnull1 = d.short('75')
    d.literal('48 8b c6')
    result1 = d.short('eb')
    nonnull1_at = va + d.at
    d.literal('48 8b d7 48 8b cb')
    check1 = d.relative('e8')
    d.literal('48 85 c0')
    invalid1 = d.short('74')
    result1_at = va + d.at
    d.literal('49 89 06 48 8b 45 30 48 8b 78 08 f6 87 32 01 00 00 01')
    initialized2 = d.short('75')
    d.literal('48 8b cf')
    initialize2 = d.relative('e8')
    initialized2_at = va + d.at
    d.literal('48 85 db')
    null2 = d.short('74')
    d.literal('48 8b d7 48 8b cb')
    check2 = d.relative('e8')
    d.literal('48 8b f0 48 85 c0')
    invalid2 = d.short('74')
    result2_at = va + d.at
    d.literal('48 8b d6 49 8b ce')
    barrier = d.relative('e8')
    d.literal('b0 01')
    back = d.relative('e9')
    null_at = va + d.at
    nullthrow = d.relative('e8')
    d.literal('cc')
    invalid2_at = va + d.at
    d.literal('48 8b d7 48 8b cb')
    throw2 = d.relative('e8')
    d.literal('cc')
    invalid1_at = va + d.at
    d.literal('48 8b d7 48 8b cb')
    throw1 = d.relative('e8')
    d.literal('cc')
    d.end()
    need(len(code) == 350 and flag == written and ready_branch == ready, 'Exact complete lookup initialization CFG')
    need(provider_use == provider_load == 0x188788ca8 and message_use == message_load == 0x18885ddb8, 'Exact interface and disposed-message metadata')
    need(init1 == init2 == 0x1806c01e0 and disposed == 0x186743bb0 and prepare == 0x186744a30 and invoke == 0x180157240, 'Exact original metadata/check/preparation/interface calls')
    need(success == success_at and back == exit_at and null_provider == null_at and nonnull1 == nonnull1_at and result1 == result1_at and null2 == result2_at, 'All success/miss/null result branches close')
    need(initialized1 == initialized1_at and initialized2 == initialized2_at and initialize1 == initialize2 == 0x1806846d0, 'Original generic return-class initialization edges')
    need(check1 == check2 == 0x1806bfd40 and barrier == 0x1806bfd30 and nullthrow == 0x1806c0390 and throw1 == throw2 == 0x1806bfd70 and invalid1 == invalid1_at and invalid2 == invalid2_at, 'Exact original checked-cast/reference barrier and exception paths')
    return {'all350_native_bytes_and_CFG_edges_checked': True, 'disposed_field_offset': 57, 'method_rgctx_pointer_offset': 48, 'provider_lookup_rgctx_slot': 0, 'TType_class_rgctx_slot': 1, 'provider_interface_invoke_slot': 0, 'provider_null_throws': True, 'provider_result_null_allowed': True, 'missing_provider_sets_null_and_returns_false': True, 'successful_result_uses_checked_TType_cast_and_original_reference_write_barrier': True}

def main():
    need(pin(JOINS)['sha256'] == JOINS_SHA, 'Exact original native typed joins')
    joins = json.loads(JOINS.read_bytes())
    row = next(item for item in json.loads(WINDOWS.read_bytes())['methods'] if item['original']['index'] == 47883)
    code = bytes.fromhex(row['runtime_function']['bytes'])
    va = int(row['native_pointer'], 16)
    cfg = shape(code, va)
    paths = [ROOT / 'CodeSource' / name for name in SOURCE_PINS]
    for path in paths:
        need(pin(path)['sha256'] == SOURCE_PINS[path.relative_to(ROOT / 'CodeSource').as_posix()], 'Original native client inputs')
    with paths[0].open('rb') as bf, paths[1].open('rb') as mf, mmap.mmap(bf.fileno(), 0, access=mmap.ACCESS_READ) as b, mmap.mmap(mf.fileno(), 0, access=mmap.ACCESS_READ) as m:
        v = ExternMetadata(b, m)
        at = v.raw(va, len(code))
        need(bytes(b[at:at + len(code)]) == code and v.method_info(47883) == row['original'], 'Exact original code and declaration')
        method = row['original']
        need(method['flags'] == 131 and method['generic_container_index'] == 1696 and method['return'] == 'System.Boolean', 'Original internal instance generic signature')
        gc = struct.unpack_from('<iiii', m, v.row('genericContainers', 1696, 16))
        gp = struct.unpack_from('<iiHHHH', m, v.row('genericParameters', 2894, 16))
        need(gc == (47883, 1, 1, 2894) and gp[0] == 1696 and v.string(gp[1]) == 'TType' and gp[3:] == (0, 0, 4), 'Original TType is explicitly reference-constrained with no additional constraints')
        context = rgctx(v, method['image'], int(method['token'], 16))
        need(context == joins['original_method_rgctx'] and context['count'] == 2, 'Exact native lookup RGCTX')
        callee = context['rows'][0]
        need(callee['kind'] == 3 and callee['method']['index'] == 47884 and callee['method_arguments'] == ['TType'] and [item['type'] for item in callee['method']['parameters']] == ['CPAMAFPANDM', 'NJAICAFMPBE&'], 'Exact typed provider-discovery boundary')
        need(context['rows'][1]['kind'] == 2 and context['rows'][1]['type'] == 'TType', 'Exact checked return class')
        disposed_field = [item for item in fields(v, method['owner_index']) if item['offset'] == 57]
        need(len(disposed_field) == 1 and disposed_field[0]['name'] == 'KBDIBPJIHNN' and disposed_field[0]['type'] == 'System.Boolean', 'Original disposed field ownership')
        prepare = joins['direct_original_calls']['0x186744a30']
        need(len(prepare) == 1 and prepare[0]['owner'] == 'MNALHHOLFGL' and prepare[0]['name'] == 'LNFNAIMOFOF' and prepare[0]['return'] == 'System.Void' and not prepare[0]['parameters'], 'Exact original preparation member')
        provider = v.type_info(6607)
        invoke = v.method_info(47936)
        need(provider['name'] == 'NJAICAFMPBE' and provider['flags'] & 32 and invoke['owner_index'] == 6607 and invoke['name'] == 'AIKLEKDPIFH' and invoke['return'] == 'System.Object' and not invoke['parameters'] and v.u16(m, v.row('methods', 47936, 32) + 28) == 0, 'Exact original interface return method slot0')
        helper = region(v, 0x180157240)
        helper_shape = dispatch(bytes.fromhex(helper['bytes']), 0x180157240)
        helper_chains = no_chained_entries(v, [helper])
    controls = []
    # Byte substitutions cover all instructions, including every call operand,
    # field offset, RGCTX slot, output address, branch, and return value.
    for offset in range(len(code)):
        changed = bytearray(code)
        changed[offset] ^= 1
        try:
            shape(bytes(changed), va)
        except (ValueError, struct.error):
            controls.append({'offset': offset, 'rejected': True})
        else:
            raise ValueError('Changed original lookup byte accepted at ' + str(offset))
    source = '''// Selected body within original MNALHHOLFGL only, outside Assets compilation.
// Keep the original internal member, reference constraint, fields and dependencies.
internal bool NGBMOPMLJCM<TType>(CPAMAFPANDM FDAIMOMOHIG, out TType FAEPBILJHEE) where TType : class
{
    MKECFLEMHEL.GFKAFPHLKMJ(this.KBDIBPJIHNN, "You should not try to retrieve bindings from a disposed container!");
    this.LNFNAIMOFOF();
    NJAICAFMPBE provider;
    if (!this.CPBMOKFMMMK<TType>(FDAIMOMOHIG, out provider))
    {
        FAEPBILJHEE = default(TType);
        return false;
    }
    FAEPBILJHEE = (TType)provider.AIKLEKDPIFH();
    return true;
}
'''
    out = ROOT / 'Validation' / ('LiveLookupMember-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    candidate = out / 'MNALHHOLFGL.lookup.member.cs'
    with candidate.open('x', encoding='utf-8', newline='\n') as target:
        target.write(source)
    report = {'schema': 'original-MNAL-reference-constrained-lookup-complete-CFG-member/v1', 'status': 'complete_original_lookup_caller_candidate_binding_effects_and_provider_closure_pending', 'producer': pin(Path(__file__)), 'typed_join_authority': pin(JOINS), 'original_sources': [pin(path) for path in paths], 'original': method, 'native_method_spec': row['exact_generic_method_spec'], 'native_pointer': row['native_pointer'], 'native_code_sha256': hashlib.sha256(code).hexdigest(), 'complete_shape': cfg, 'original_generic_container': list(gc), 'original_generic_parameter': {'index': 2894, 'name': 'TType', 'owner': 1696, 'flags': 4, 'constraints_count': 0}, 'original_disposed_field': disposed_field[0], 'original_method_rgctx': context, 'original_provider_interface': provider, 'original_provider_method': invoke, 'original_interface_invoke_helper': helper, 'complete_invoke_helper_shape': helper_shape, 'invoke_helper_no_chained_regions': helper_chains, 'original_preparation_boundary': prepare[0], 'candidate': pin(candidate), 'negative_controls': controls, 'CSharp_binding_or_effects_proved': False, 'unrecovered_callees': ['MNALHHOLFGL.LNFNAIMOFOF preparation', 'MNALHHOLFGL.CPBMOKFMMMK<TType> provider discovery', 'Concrete NJAICAFMPBE provider return implementation'], 'Main_modified': False, 'compiler_Unity_game_or_network_executed': False, 'working_service_resolution_or_boot_claimed': False}
    path = out / 'report.json'
    with path.open('x', encoding='utf-8') as target:
        json.dump(report, target, indent=2)
        target.write('\n')
    print(json.dumps({'report': pin(path), 'candidate': pin(candidate), 'complete_original_bytes': len(code), 'negative_controls': len(controls)}))

if __name__ == '__main__':
    main()
