"""Stage original CPBM provider lookup, including its inlined null assertion.

No target code runs. This follows the original native behavior: a local entry
shadows the parent, a stored null entry throws after setting the out argument,
and a missing entry can resolve through the exact original parent container.
"""
from pathlib import Path
import datetime as dt, hashlib, json, mmap, struct, sys, uuid
HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE.parent / 'ConstructorEvidence'))
from audit_ogpeg_constructors import Decoder
from collect_all_pinvoke_native import ExternMetadata
from run_startup_foundation_decode import pin, need, save, check
from prepare_startup_foundation_slice import SOURCE_PINS

ROOT = HERE.parents[2] / 'Recovery/RecRoom-2023-04-18'
RUN = ROOT / 'Validation/LiveLookupDependencies-20261023T092454Z-8f9207ed'
JOINS = ROOT / 'Validation/LiveLookupDependencyJoins-20261023T092659Z-6a69ffae/report.json'
JOINS_SHA = '8484971c6c94665f60dfe388a07f5bd4dce89eaee317383c0077aa6664c85e2a'

def shape(code, va):
    d = Decoder(code, va)
    d.literal('48 89 5c 24 10 48 89 6c 24 18 48 89 74 24 20 57 48 83 ec 40')
    flag = d.relative('80 3d', '00')
    d.literal('49 8b e9 49 8b d8 48 8b f2 48 8b f9')
    ready_branch = d.short('75')
    uses, initializers = [], []
    for _ in range(4):
        uses.append(d.relative('48 8d 0d'))
        initializers.append(d.relative('e8'))
    written = d.relative('c6 05', '01')
    ready = va + d.at
    message = d.relative('48 8b 15')
    d.literal('45 33 c0 0f b6 4f 39 48 c7 44 24 50 00 00 00 00 48 c7 44 24 20 00 00 00 00')
    disposed = d.relative('e8')
    d.literal('33 d2 48 8b cf')
    prepare = d.relative('e8')
    d.literal('48 8b 4f 10 48 85 c9')
    null_dictionary = d.relative('0f 84')
    d.literal('0f 10 06')
    dictionary_method = d.relative('4c 8b 0d')
    d.literal('4c 8d 44 24 50 48 8d 54 24 30 0f 29 44 24 30')
    try_get = d.relative('e8')
    d.literal('84 c0')
    local_found = d.short('75')
    d.literal('48 8b 4f 28 48 85 c9')
    no_parent = d.short('74')
    d.literal('48 8b 45 30 4c 8d 44 24 20 0f 10 06 48 8d 54 24 30 4c 8b 10 4d 8b ca 0f 29 44 24 30 41 ff 12 84 c0')
    parent_miss = d.short('74')
    d.literal('48 8b 54 24 20 48 8b cb 48 89 13')
    barrier_parent = d.relative('e8')
    true_at = va + d.at
    d.literal('b0 01')
    exit_at = va + d.at
    d.literal('48 8b 5c 24 58 48 8b 6c 24 60 48 8b 74 24 68 48 83 c4 40 5f c3')
    missing_at = va + d.at
    d.literal('33 d2 48 c7 03 00 00 00 00 48 8b cb')
    barrier_missing = d.relative('e8')
    d.literal('32 c0')
    false_return = d.short('eb')
    found_at = va + d.at
    d.literal('48 8b 54 24 50 48 8b cb 48 89 13')
    barrier_found = d.relative('e8')
    d.literal('48 83 7c 24 50 00')
    null_assert_method = d.relative('48 8b 0d')
    null_provider = d.short('74')
    true_return = d.short('eb')
    null_dictionary_at = va + d.at
    null_throw = d.relative('e8')
    d.literal('cc')
    null_provider_at = va + d.at
    d.literal('0f 10 06 48 8b 49 30')
    format_use = d.relative('48 8b 1d')
    d.literal('0f 11 44 24 30 48 8b 49 10')
    box_type = d.relative('e8')
    d.literal('48 8b c8 48 8d 54 24 30')
    box = d.relative('e8')
    d.literal('45 33 c9 4c 8b c0 48 8b d7 48 8b cb')
    format_call = d.relative('e8')
    exception_use = d.relative('48 8d 0d')
    d.literal('48 8b d8')
    exception_init = d.relative('e8')
    d.literal('48 8b c8')
    allocate = d.relative('e8')
    d.literal('45 33 c0 48 8b d3 48 8b c8 48 8b f8')
    exception_ctor = d.relative('e8')
    throw_context = d.relative('48 8d 0d')
    context_init = d.relative('e8')
    d.literal('48 8b d0 48 8b cf')
    throw = d.relative('e8')
    d.literal('cc')
    d.end()
    need(len(code) == 455 and flag == written and ready_branch == ready, 'Entire original provider-discovery metadata CFG')
    need(uses == [0x18887d798, 0x188710ac8, 0x188762330, 0x18885ddb8] and message == uses[3] and dictionary_method == uses[0] and null_assert_method == uses[1] and format_use == uses[2], 'Exact original loaded Dictionary/null-assert/literal metadata aliases')
    need(set(initializers + [exception_init, context_init]) == {0x1806c01e0} and disposed == 0x186743bb0 and prepare == 0x186744a30 and try_get == 0x18491abf0, 'Exact original check/preparation/Dictionary callees')
    need(local_found == found_at and no_parent == parent_miss == missing_at and false_return == exit_at and true_return == true_at and null_dictionary == null_dictionary_at and null_provider == null_provider_at, 'Every found/missing/parent/null return or throw branch closes')
    need(barrier_parent == barrier_missing == barrier_found == 0x1806bfd30 and null_throw == 0x1806c0390 and box_type == 0x18010bba0 and box == 0x180641680 and format_call == 0x18476ea50 and exception_use == 0x1887b5780 and allocate == 0x1806c0340 and exception_ctor == 0x1840a05e0 and throw_context == 0x188710d50 and throw == 0x1806c0360, 'Exact original reference barriers, key box, format and InvalidOperationException flow')
    return {'all455_original_bytes_and_CFG_edges_checked': True, 'disposed_offset': 57, 'provider_dictionary_offset': 16, 'parent_container_offset': 40, 'parent_method_rgctx_slot': 0, 'local_out_stack_offset': 80, 'parent_out_stack_offset': 32, 'out_assigned_before_stored_null_assertion': True, 'parent_out_copied_only_after_success': True, 'native_inlined_null_assertion_recovered_in_caller': True}

def main():
    need(pin(JOINS)['sha256'] == JOINS_SHA, 'Actual original typed native dependency joins')
    joins = json.loads(JOINS.read_bytes())
    scopes = json.loads((RUN / 'two-original-complete-dependency-scopes.json').read_bytes())
    row = next(item for item in scopes['methods'] if item['original']['index'] == 47884)
    code, va = bytes.fromhex(row['runtime_function']['bytes']), int(row['native_pointer'], 16)
    cfg = shape(code, va)
    paths = [ROOT / 'CodeSource' / name for name in SOURCE_PINS]
    for path in paths:
        need(pin(path)['sha256'] == SOURCE_PINS[path.relative_to(ROOT / 'CodeSource').as_posix()], 'Actual original native client bytes')
    context = joins['method_contexts'][0]
    need(context['original_method'] == row['original'] and row['original']['flags'] == 129 and row['original']['generic_container_index'] == 1697, 'Exact original private generic signature')
    refs = context['method_rgctx']['rows']
    need(len(refs) == 1 and refs[0]['kind'] == 3 and refs[0]['method']['index'] == 47884 and refs[0]['method_arguments'] == ['TType'], 'Exact self-recursive parent method context')
    usages = joins['RIP_metadata_and_literal_uses']
    dictionary = usages['0x18887d798']['original_usage']
    assertion = usages['0x188710ac8']['original_usage']
    need(dictionary['method']['owner'] == 'System.Collections.Generic.Dictionary`2' and dictionary['method']['name'] == 'TryGetValue' and dictionary['class_argument_types'] == ['CPAMAFPANDM', 'NJAICAFMPBE'], 'Exact original Dictionary key/provider specialization')
    need(assertion['method']['index'] == 47950 and assertion['method_argument_types'] == ['NJAICAFMPBE', 'MNALHHOLFGL', 'CPAMAFPANDM'], 'Exact original inlined generic null assertion argument ownership')
    message = usages['0x188762330']['original_usage']['literal']['utf8']
    need(message == 'Null dependency detected in: {0} for key {1}. It should have been unregistered!' and usages['0x1887b5780']['original_usage']['type'] == 'System.InvalidOperationException', 'Exact original null-entry exception and format')
    declared = joins['original_container_fields']
    need([(item['name'], item['type']) for item in declared if item['offset'] in [16, 40, 57]] == [('AAHKPPMHGFI', 'System.Collections.Generic.Dictionary`2<CPAMAFPANDM,NJAICAFMPBE>'), ('DDFCHDGPJBN', 'MNALHHOLFGL'), ('KBDIBPJIHNN', 'System.Boolean')], 'Exact original dictionary/parent/disposed field ownership')
    with paths[0].open('rb') as bf, paths[1].open('rb') as mf, mmap.mmap(bf.fileno(), 0, access=mmap.ACCESS_READ) as b, mmap.mmap(mf.fileno(), 0, access=mmap.ACCESS_READ) as m:
        view = ExternMetadata(b, m)
        at = view.raw(va, len(code))
        need(bytes(b[at:at + len(code)]) == code and view.method_info(47884) == row['original'], 'Original exact body and declaration')
        gc = struct.unpack_from('<iiii', m, view.row('genericContainers', 1697, 16))
        gp = struct.unpack_from('<iiHHHH', m, view.row('genericParameters', 2895, 16))
        need(gc == (47884, 1, 1, 2895) and gp[0] == 1697 and view.string(gp[1]) == 'TType' and gp[3:] == (0, 0, 0), 'Original provider-discovery generic parameter is unconstrained and used only in recursive method context')
        registered = view.generic_targets({82735})[82735]
        need(any(item['pointer'] == '0x18491abf0' for item in registered), 'Exact registered original Dictionary specialization pointer')
    controls = []
    for offset in range(len(code)):
        mutated = bytearray(code)
        mutated[offset] ^= 1
        try:
            shape(bytes(mutated), va)
        except (ValueError, struct.error):
            controls.append({'offset': offset, 'rejected': True})
        else:
            raise ValueError('Changed original provider-discovery byte accepted at ' + str(offset))
    source = '''// Original private MNALHHOLFGL member; no new declarations or helpers.
// Preserve the native-inlined null assertion, including out assignment order.
private bool CPBMOKFMMMK<TType>(CPAMAFPANDM FDAIMOMOHIG, out NJAICAFMPBE FAEPBILJHEE)
{
    MKECFLEMHEL.GFKAFPHLKMJ(this.KBDIBPJIHNN, "You should not try to retrieve bindings from a disposed container!");
    this.LNFNAIMOFOF();
    NJAICAFMPBE localProvider;
    if (this.AAHKPPMHGFI.TryGetValue(FDAIMOMOHIG, out localProvider))
    {
        FAEPBILJHEE = localProvider;
        if (localProvider == null)
            throw new System.InvalidOperationException(string.Format("Null dependency detected in: {0} for key {1}. It should have been unregistered!", this, FDAIMOMOHIG));
        return true;
    }
    MNALHHOLFGL parent = this.DDFCHDGPJBN;
    NJAICAFMPBE parentProvider;
    if (parent != null && parent.CPBMOKFMMMK<TType>(FDAIMOMOHIG, out parentProvider))
    {
        FAEPBILJHEE = parentProvider;
        return true;
    }
    FAEPBILJHEE = null;
    return false;
}
'''
    out = ROOT / 'Validation' / ('LiveProviderDiscoveryMember-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    candidate = out / 'MNALHHOLFGL.provider-discovery.member.cs'
    with candidate.open('x', encoding='utf-8', newline='\n') as target:
        target.write(source)
    report = {'schema': 'original-MNAL-provider-discovery-complete-native-CFG-member/v1', 'status': 'complete_original_provider_discovery_caller_staged_binding_effects_and_preparation_closure_pending', 'producer': pin(Path(__file__)), 'original_typed_dependency_joins': pin(JOINS), 'actual_Root_decoder_receipt': joins['actual_Root_decode_receipt'], 'original': row['original'], 'native_MethodSpec': row['original_MethodSpec'], 'native_pointer': row['native_pointer'], 'native_code_sha256': hashlib.sha256(code).hexdigest(), 'complete_native_shape': cfg, 'original_method_rgctx': context['method_rgctx'], 'original_generic_container': list(gc), 'original_generic_parameter_flags': 0, 'original_dictionary_specialization': dictionary, 'original_inlined_assertion_specialization': assertion, 'candidate_inlines_native_assertion_in_existing_caller_without_new_helper_or_metadata': True, 'candidate': pin(candidate), 'negative_controls': controls, 'explicit_remaining_dependencies': ['MNALHHOLFGL.LNFNAIMOFOF preparation is not recovered', 'Original registration/provider creation must fill the dictionaries', 'Original container/key ToString behavior used by String.Format is not recovered'], 'CSharp_binding_or_effects_proven': False, 'Main_modified': False, 'compiler_Unity_game_network_or_native_library_executed': False, 'working_boot_or_registration_claimed': False}
    path = out / 'report.json'
    save(path, report)
    print(json.dumps({'report': pin(path), 'candidate': pin(candidate), 'complete_original_bytes': len(code), 'negative_controls': len(controls)}))

if __name__ == '__main__':
    main()
