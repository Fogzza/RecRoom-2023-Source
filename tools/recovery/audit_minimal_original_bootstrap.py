"""Small read-only original bootstrap assessment; never loads target assemblies.

The Start decoder records original dependencies, not a replacement C# body.
Windows exception/unwind behavior and virtual dispatch remain explicit gates.
"""
from pathlib import Path
import collections, datetime as dt, hashlib, json, mmap, struct, sys, uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
sys.path.insert(0, str(HERE.parent / 'ConstructorEvidence'))
from audit_ogpeg_constructors import Decoder, need
from collect_all_pinvoke_native import ExternMetadata
from prove_recroom_ondestroy_native_cfg import aliases
from audit_boot_candidate_dependency_closure import module_methods

def sha(p):
    with Path(p).open('rb') as f:
        return hashlib.file_digest(f, 'sha256').hexdigest()

def ref(p):
    return {'path': str(Path(p).resolve()), 'sha256': sha(p)}

def decode_start(code, va):
    d = Decoder(code, va)
    d.literal('48 89 5c 24 10 48 89 74 24 18 57 48 81 ec 80 00 00 00 48 8b d9')
    flag = d.relative('80 3d', '00'); metadata_skip = d.short('75')
    setup_uses = []; setup_calls = []
    for _ in range(3):
        setup_uses.append(d.relative('48 8d 0d')); setup_calls.append(d.relative('e8'))
    written_flag = d.relative('c6 05', '01'); ready = va + d.at
    d.literal('0f 57 c0 0f 11 44 24 38 0f 11 44 24 48 48 8b 7b 18 33 d2 48 8b cb')
    first_call = d.relative('e8'); d.literal('48 8b f0')
    class_use = d.relative('48 8b 0d')
    d.literal('f6 81 33 01 00 00 04'); class_skip1 = d.short('74')
    d.literal('83 b9 e0 00 00 00 00'); class_skip2 = d.short('75')
    class_init = d.relative('e8'); class_ready = va + d.at
    d.literal('48 c7 44 24 28 00 00 00 00 c6 44 24 20 01 45 33 c9 4c 8b c6 48 8b d7 48 8d 4c 24 58')
    struct_return_call = d.relative('e8')
    d.literal('0f 10 00 0f 11 44 24 38 0f 10 48 10 0f 11 4c 24 48')
    generic_use = d.relative('48 8b 15'); d.literal('48 8d 4c 24 38')
    handle_call = d.relative('e8'); d.literal('48 85 c0'); null_result = d.short('74')
    d.literal('45 33 c0 b2 01 48 8b c8'); activation_call = d.relative('e8')
    d.literal('48 8b 03 48 8b 90 a0 01 00 00 48 8b cb ff 90 98 01 00 00 90')
    after_virtual = d.short('eb'); handler_start = va + d.at
    d.literal('48 8b 8c 24 90 00 00 00 48 85 c9'); handler_nonnull = d.short('75')
    normal_exit = va + d.at
    d.literal('4c 8d 9c 24 80 00 00 00 49 8b 5b 18 49 8b 73 20 49 8b e3 5f c3')
    first_handler_target = va + d.at; handler_call = d.relative('e8'); d.literal('90 33 d2')
    rethrow_target = va + d.at; rethrow_call = d.relative('e8'); d.literal('cc'); d.end()
    need(len(code) == 288 and flag == written_flag and metadata_skip == ready, 'Start exact metadata guard')
    need(setup_calls == [0x1806c01e0] * 3, 'Start exact runtime metadata setup')
    need(class_skip1 == class_skip2 == class_ready and class_use == setup_uses[0], 'Start class-init edges')
    need(generic_use == setup_uses[1], 'Start generic method usage identity')
    need(after_virtual == normal_exit and null_result == first_handler_target and handler_nonnull == rethrow_target, 'Start result/handler branch edges')
    return {
        'all_288_bytes_matched': True,
        'metadata_uses': [hex(x) for x in setup_uses],
        'generic_method_use': hex(generic_use),
        'direct_calls': {k: hex(x) for k, x in {
            'receiver_first_call': first_call, 'class_init': class_init,
            'struct_return_call': struct_return_call, 'handle_call': handle_call,
            'activation_call': activation_call, 'null_result_handler': handler_call,
            'handler_rethrow_call': rethrow_call}.items()},
        'field_receiver_offset': 24,
        'virtual_dispatch': {'method_pointer_offset': 408, 'method_info_offset': 416,
                             'raw_slot_owner_contract_proved_here': False},
        'exception_handler_entry': hex(handler_start),
        'exception_unwind_CSharp_semantics_proved_here': False,
        'source_body_accepted': False,
    }

def main():
    inventory = ROOT / 'Validation/RecRoomGameRootNative-20261022T162444Z-d9c732b7/report.json'
    need(sha(inventory) == '9492989fb0f23794155b1e0bd6e9ae25eeae2fc86687a9e1016abfb14617d7f6', 'Original native inventory pin')
    original = json.loads(inventory.read_text())
    start = next(x for x in original['methods'] if x['original']['owner'] == 'RecRoomGameRoot' and x['original']['name'] == 'Start')
    code = bytes.fromhex(start['runtime_function']['bytes']); va = int(start['native_pointer'], 16)
    shape = decode_start(code, va)
    binary = ROOT / 'CodeSource/GameAssembly.dll'
    metadata = ROOT / 'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat'
    # Source archive/native-window proof pins full files; avoid a competing full-file scan during BuildPipeline.
    before = {str(p): (p.stat().st_size, p.stat().st_mtime_ns) for p in (binary, metadata)}
    with binary.open('rb') as f, metadata.open('rb') as g, mmap.mmap(f.fileno(), 0, access=mmap.ACCESS_READ) as b, mmap.mmap(g.fileno(), 0, access=mmap.ACCESS_READ) as md:
        v = ExternMetadata(b, md)
        method = v.find_method('RecRoomGameRoot', 0x060026c0)
        need(v.method_pointer(method) == va, 'Native original Start registration')
        at = v.raw(va, len(code)); need(bytes(b[at:at+len(code)]) == code, 'Native original Start window')
        uses = [v.usage(int(x, 16)) for x in shape['metadata_uses']]
        calls = shape['direct_calls']
        targets = {int(calls[k], 16) for k in ('receiver_first_call', 'struct_return_call', 'activation_call')}
        mapped, gaps = aliases(v, targets)
        generic_rows = {}
        if uses[1]['kind'] == 6:
            generic_rows = v.generic_targets({uses[1]['index']})
        raw_methods = []
        for ti in range(v.count('typeDefinitions', 88)):
            owner = v.full_name(ti)
            if owner != 'BootSequence' and not owner.startswith('BootSequence/'):
                continue
            td = v.row('typeDefinitions', ti, 88); first = v.i32(md, td+36); count = v.u16(md, td+64)
            for mi in range(first, first+count):
                m = v.method_info(mi)
                if owner == 'BootSequence' and m['name'] in ('Awake', 'Start', 'LaunchGame', 'BeginPlatformLogin', 'EndPlatformLogin') or owner.startswith('BootSequence/') and m['name'] == 'MoveNext':
                    p = v.method_pointer(m)
                    raw_methods.append({'original': m, 'native_pointer': hex(p) if p else None, 'body_recovered': False})
    need(all((Path(p).stat().st_size, Path(p).stat().st_mtime_ns) == stat for p, stat in before.items()), 'Source changed during window read')
    negative = []
    for name, old, new in [
        ('wrong_startup_field', '48 8b 7b 18', '48 8b 7b 20'),
        ('wrong_activation_bool', '45 33 c0 b2 01', '45 33 c0 b2 00'),
        ('wrong_virtual_slot', 'ff 90 98 01 00 00', 'ff 90 a8 01 00 00')]:
        need(code.count(bytes.fromhex(old)) == 1, 'Unique mutation anchor')
        try: decode_start(code.replace(bytes.fromhex(old), bytes.fromhex(new)), va)
        except (ValueError, struct.error): negative.append({'name': name, 'rejected': True})
        else: raise ValueError('Mutated startup decoder accepted ' + name)
    source_paths = [WS/'RR23/Assets/Scripts/Assembly-CSharp'/x for x in ('RecRoomGameRoot.cs', 'BootSequence.cs')]
    closure = ROOT/'Validation/ServiceContainerBootCheckpoint-20261022T184012Z-4c3eaea5/readiness.json'
    boundary = ROOT/'Validation/BuildVsPlayabilityBoundary-20261022T190218Z-a937710e/report.json'
    streaming = ROOT/'Validation/OriginalStreamingAssetsInstall-20261022T190647Z-4c43a4bc/report.json'
    plugin_rows = []
    for filename, selectors in {
        'RecRoom.AgInitialization.Runtime.dll': [{'owner':'MPAAIECKLGA','name':'PNFLFFOAING','parameters':0}],
        'UJect.Runtime.dll': [{'owner':'MNALHHOLFGL','name':'HHCPOGCCGNF','parameters':1,'generic':1}],
    }.items():
        p = WS/'RR23/Assets/Plugins'/filename
        plugin_rows.append({'file':ref(p), 'methods':module_methods(p, selectors)})
    old_boundary = json.loads(boundary.read_text())
    install = json.loads(streaming.read_text())
    need(install['status']=='applied' and install['files']==6524, 'Original runtime asset installation receipt')
    report = {
        'schema':'minimal-original-main-root-bootstrap-recovery-assessment/v1',
        'status':'original-dynamic-bootstrap-not-yet-functional',
        'current_source_inputs':[ref(p) for p in source_paths],
        'native_Start_original':start,
        'native_Start_exact_window_shape':shape,
        'native_Start_metadata_uses':uses,
        'native_Start_direct_call_aliases':mapped,
        'native_Start_alias_inventory_gaps':gaps,
        'native_Start_generic_registration':generic_rows,
        'BootSequence_next_original_targets':raw_methods,
        'current_Main_service_stubs':plugin_rows,
        'original_startup_Addressable':old_boundary['definite_runtime_gaps']['original_startup_Addressable'],
        'StreamingAssets_missing_observation_superseded':True,
        'original_StreamingAssets_installed':ref(streaming),
        'small_proved_bodies_staged_not_applied':[
            'RecRoomGameRoot.Awake (base Awake, original memory-service resolve, lowMemory remove/add)',
            'RecRoomGameRoot.HPCJAAEDLCH (base hook; new original BootSequence component)',
            'RecRoomGameRoot.OnDestroy (base cleanup then original lowMemory unsubscribe)',
            'RecRoomGameRoot constructor field initializer HKLOLBJDDDL=-60f before base .ctor',
            'CPAMAFPANDM Type/string key constructor and OENEDGPIOFN graph collections initializer'],
        'minimal_required_recovery_layers':[
            {'layer':1,'name':'Singleton/GameRoot lifetime','required':'Original SingletonMonoBehaviour<GameRoot>.Awake and GameRoot constructor/static/lifetime methods; no dummy singleton.', 'closed':False},
            {'layer':2,'name':'Awake service closure','required':'PNFL lazy factory, logger/color, MNAL initializers/PHJ/JON, genuine dependency graph add/cycle validation, memory-service registration plus HHC<MFEN> resolver.', 'closed':False},
            {'layer':3,'name':'Original dynamic startup content','required':'Fully prove RecRoomGameRoot.Start including handle generic target, virtual hook identity and exception/unwind edges, then use genuine matching Addressables; original asset catalog/bundles already installed.', 'closed':False},
            {'layer':4,'name':'BootSequence state machine','required':'Original Awake, Start coroutine factory and MoveNext; APP_SETUP→PRE_INITIALIZATION→LOGIN→post-login→LOAD_INITIAL_SCENE dependencies/async continuations. Empty factory or false MoveNext cannot progress.', 'closed':False},
            {'layer':5,'name':'Rendering and playable room','required':'Genuine matching URP/UGUI/TMP runtime behavior and actual player/scene initialization are separate from successful bootstrap or C# compilation.', 'closed':False}],
        'next_smallest_evidence_task':'Finish 288-byte RecRoomGameRoot.Start exact virtual dispatch/unwind proof, then BootSequence.Start factory and its concrete MoveNext state machine; keep Awake application held while service closure returns null.',
        'service_checkpoint':ref(closure),
        'inputs':[ref(inventory),ref(boundary)],
        'negative_controls':negative,
        'managed_compiler_Editor_game_or_native_code_executed':False,
        'Main_or_backend_modified':False,
        'source_or_DLL_candidate_applied':False,
        'playability_claimed':False,
    }
    out = ROOT/'Validation'/('MinimalOriginalBootstrap-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]); out.mkdir()
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({'report':str(p),'sha256':sha(p),'Start_uses':uses,'Start_calls':{k:[m['owner']+'.'+m['name'] for m in val] for k,val in mapped.items()},'generic_registration':generic_rows,'BootSequence_target_count':len(raw_methods),'negative_controls':len(negative),'project_modified':False}))

if __name__ == '__main__':
    main()
