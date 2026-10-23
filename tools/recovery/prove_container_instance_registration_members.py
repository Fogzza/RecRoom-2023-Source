"""Stage three original registration members; no Main write or execution.

The provider constructor is checked across all168 bytes/three PE regions,
including its generic base call and the actual instance-provider allocation.
"""
from pathlib import Path
import datetime as dt, json, mmap, struct, sys, uuid
HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE.parent / 'ConstructorEvidence'))
from audit_ogpeg_constructors import Decoder
from collect_all_pinvoke_native import ExternMetadata
from run_startup_foundation_decode import ROOT, pin, need, save, check
from resolve_startup_foundation_native_joins import rgctx
from audit_custom_urp_native_loop import fields
from prove_container_binding_tail_native import decode as bind_shape
from prove_container_key_registration_native import decode as key_shape

RUN = ROOT / 'Validation/ContainerInstanceRegistration-20261023T095903Z-3eb76477'
RECEIPT_SHA = '440d74e24950a2df7249b41dbafdcdda7afad3b8fd2195c20a66f8970e08b372'
BIND = ROOT / 'Validation/ContainerBindingTailCFG-20261022T181708Z-5b7e300c/report.json'
BIND_SHA = '1373f4678e8558aa0aa9a3eec487bf580c544e83846b7da9a75701f3991a33f1'


def constructor(code, va):
    d = Decoder(code, va)
    d.literal('48896c24104889742418574883ec20498bf0488bea488bf94885c9')
    null = d.relative('0f84')
    d.literal('498b401848895c24304c8b88c0000000498b01488bd0ff10488b46184c8b80c0000000498b5810f6833201000001')
    ready_branch = d.short('75')
    d.literal('488bcb')
    initialize = d.relative('e8')
    ready = va + d.at
    d.literal('488bcb')
    allocate = d.relative('e8')
    d.literal('488b4e18488bd8488b91c0000000488bc84c8b4a18488bd54d8bc141ff11488d4f10488bd3488919488b5c2430488b6c2438488b7424404883c4205f')
    barrier = d.relative('e9')
    null_at = va + d.at
    null_helper = d.relative('e8')
    d.literal('cc')
    d.end()
    need(len(code) == 168 and ready_branch == ready and null == null_at and initialize == 0x1806846d0 and allocate == 0x1806c0340 and barrier == 0x1806bfd30 and null_helper == 0x1806c0390, 'Exact entire original constructor CFG/runtime targets')
    return {'all168_bytes_checked': True, 'base_constructor_rgctx_slot': 0, 'allocated_provider_class_slot': 2, 'provider_constructor_method_slot': 3, 'original_readonly_instance_provider_field_offset': 16, 'base_before_allocation_before_field_store': True, 'no_null_value_rejection_added': True}


def parameters(v, container):
    gc = struct.unpack_from('<iiii', v.m, v.row('genericContainers', container, 16))
    result = []
    for index in range(gc[3], gc[3] + gc[1]):
        owner, name, start, count, number, flags = struct.unpack_from('<iiHHHH', v.m, v.row('genericParameters', index, 16))
        need(owner == container, 'Exact original generic parameter ownership')
        result.append({'name': v.string(name), 'number': number, 'flags': flags, 'constraints': [v.typename(v.native_type(v.i32(v.m, v.row('genericParameterConstraints', start + i, 4)))) for i in range(count)]})
    return result


def main():
    receipt = RUN / 'run-report.json'
    need(pin(receipt)['sha256'] == RECEIPT_SHA and pin(BIND)['sha256'] == BIND_SHA, 'Exact Root complete decode and original binding proof')
    actual = json.loads(receipt.read_bytes())
    check(actual['plan']); check(actual['output'])
    plan = json.loads(Path(actual['plan']['path']).read_bytes())
    check(plan['input'])
    for row in plan['original_inputs']:
        check(row)
    native = json.loads(Path(plan['input']['path']).read_bytes())['methods']
    shapes = [bind_shape(bytes.fromhex(native[0]['runtime_function']['bytes']), int(native[0]['native_pointer'], 16)), key_shape(bytes.fromhex(native[1]['runtime_function']['bytes']), int(native[1]['native_pointer'], 16)), constructor(bytes.fromhex(native[2]['runtime_function']['bytes']), int(native[2]['native_pointer'], 16))]
    originals = [Path(row['path']) for row in plan['original_inputs']]
    with originals[0].open('rb') as bf, originals[1].open('rb') as mf, mmap.mmap(bf.fileno(), 0, access=mmap.ACCESS_READ) as b, mmap.mmap(mf.fileno(), 0, access=mmap.ACCESS_READ) as m:
        v = ExternMetadata(b, m)
        for row in native:
            need(v.method_info(row['original']['index']) == row['original'], 'Exact original method declarations')
            code = bytes.fromhex(row['runtime_function']['bytes']); at = v.raw(int(row['native_pointer'], 16), len(code))
            need(bytes(b[at:at + len(code)]) == code, 'Every original source byte unchanged')
        generic = [parameters(v, 1689), parameters(v, 1692), parameters(v, 1707)]
        need(generic[0] == [{'name': 'TClass', 'number': 0, 'flags': 4, 'constraints': []}], 'Original reference-only TClass constraint')
        need(generic[1] == [{'name': 'TFrom', 'number': 0, 'flags': 0, 'constraints': []}, {'name': 'TTo', 'number': 1, 'flags': 0, 'constraints': ['TFrom']}], 'Original unconstrained source and dependent TTo:TFrom constraint')
        need(generic[2] == [{'name': 'TImpl', 'number': 0, 'flags': 0, 'constraints': []}], 'Original IKGL implementation type is unconstrained; reference-shared native registration does not add a class constraint')
        context = rgctx(v, 'UJect.Runtime.dll', 0x02000026)
        rows = context['rows']
        need(len(rows) == 4 and [r['kind'] for r in rows] == [3, 2, 2, 3] and rows[0]['method']['index'] == 47984 and rows[0]['class_arguments'] == ['TImpl'] and rows[1]['type'] == 'NPILHMLGJCC<TImpl>' and rows[2]['type'] == 'PLIPHMBIGMM<TImpl>' and rows[3]['method']['index'] == 47940 and rows[3]['class_arguments'] == ['TImpl'], 'Exact original generic base and concrete instance-provider allocation/ctor slots')
        original_fields = fields(v, 6628)
        need(len(original_fields) == 1 and original_fields[0]['name'] == 'JPEDOBINBHH' and original_fields[0]['type'] == 'MOANAJANOIL<TImpl>' and original_fields[0]['flags'] == 33, 'Exact original private readonly interface field')
    text = '''// Replacement members only in their original owners. Not a standalone DLL.
// MNALHHOLFGL, original public MethodDef06000013:
public MNALHHOLFGL PHJOGIEDKPN<TClass>(TClass CMDPMJBEBAB, string OGLHPPMJANF = null) where TClass : class
{
    MKECFLEMHEL.GFKAFPHLKMJ(this.KBDIBPJIHNN, "You should not try to bind to a disposed container!");
    MKECFLEMHEL.GFKAFPHLKMJ(typeof(TClass).IsInterface, "You should not try to bind an instance of an interface!");
    this.JONINBOMMEP<TClass, TClass>(OGLHPPMJANF, new IKGLJOBBAAC<TClass>(CMDPMJBEBAB));
    return this;
}

// MNALHHOLFGL, original internal MethodDef06000017:
internal void JONINBOMMEP<TFrom, TTo>(string OGLHPPMJANF, CKAJONGONMK MMNOGBABODM) where TTo : TFrom
{
    CPAMAFPANDM interfaceKey = new CPAMAFPANDM(typeof(TFrom), OGLHPPMJANF);
    CPAMAFPANDM implementationKey = new CPAMAFPANDM(typeof(TTo), null);
    this.JONINBOMMEP(interfaceKey, implementationKey, MMNOGBABODM);
}

// IKGLJOBBAAC<TImpl>, original public constructor MethodDef06000084:
public IKGLJOBBAAC(TImpl CMDPMJBEBAB) : base()
{
    this.JPEDOBINBHH = new PLIPHMBIGMM<TImpl>(CMDPMJBEBAB);
}
'''
    out = ROOT / 'Validation' / ('ContainerInstanceRegistrationMembers-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    candidate = out / 'original-instance-registration.members.cs'
    candidate.write_text(text, encoding='utf-8', newline='\n')
    report = {'schema': 'three-original-instance-registration-native-members/v1', 'status': 'three_original_typed_candidates_staged_binding_effects_and_provider_closure_pending', 'producer': pin(Path(__file__)), 'actual_Root_decode': pin(receipt), 'actual_decoded_output': actual['output'], 'original_scopes': plan['input'], 'original_binding_proof': pin(BIND), 'original_generic_parameter_contracts': generic, 'complete_native_shapes': shapes, 'provider_constructor_original_class_rgctx': context, 'original_instance_provider_field': original_fields, 'candidate': pin(candidate), 'original_native_bytes': 748, 'Main_modified': False, 'CSharp_compiled_or_runtime_behavior_claimed': False, 'pending': ['Original NPILHMLGJCC<TImpl> base constructor', 'Original PLIPHMBIGMM<TImpl> constructor and runtime instance-provider/injection callbacks', 'Private three-argument registration dependency graph/cycle/duplicate exception bodies', 'Compile and inspect the selected original-owner bodies; controlled effects before transplantation']}
    save(out / 'report.json', report)
    print(json.dumps({'report': pin(out / 'report.json'), 'candidate': pin(candidate), 'Main_modified': False}))


if __name__ == '__main__':
    main()
