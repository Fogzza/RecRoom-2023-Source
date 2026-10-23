"""Exact original RecRoomGameRoot.Start control-flow and typed dependency audit.

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
from prove_service_container_getter_native import header_layout
from original_eh4_metadata import parse_function, state_at
from audit_custom_urp_native_loop import pdata, scopes
from audit_forwarding import EXPECTED


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
    first_site = va + d.at; first_call = d.relative('e8'); d.literal('48 8b f0')
    class_use = d.relative('48 8b 0d')
    d.literal('f6 81 33 01 00 00 04'); class_skip1 = d.short('74')
    d.literal('83 b9 e0 00 00 00 00'); class_skip2 = d.short('75')
    class_init = d.relative('e8'); class_ready = va + d.at
    d.literal('48 c7 44 24 28 00 00 00 00 c6 44 24 20 01 45 33 c9 4c 8b c6 48 8b d7 48 8d 4c 24 58')
    struct_site = va + d.at; struct_return_call = d.relative('e8')
    d.literal('0f 10 00 0f 11 44 24 38 0f 10 48 10 0f 11 4c 24 48')
    generic_use = d.relative('48 8b 15'); d.literal('48 8d 4c 24 38')
    handle_site = va + d.at; handle_call = d.relative('e8'); d.literal('48 85 c0'); null_result = d.short('74')
    d.literal('45 33 c0 b2 01 48 8b c8'); activation_site = va + d.at; activation_call = d.relative('e8')
    d.literal('48 8b 03 48 8b 90 a0 01 00 00 48 8b cb'); virtual_site = va + d.at; d.literal('ff 90 98 01 00 00 90')
    after_virtual = d.short('eb'); handler_start = va + d.at
    d.literal('48 8b 8c 24 90 00 00 00 48 85 c9'); handler_nonnull = d.short('75')
    normal_exit = va + d.at
    d.literal('4c 8d 9c 24 80 00 00 00 49 8b 5b 18 49 8b 73 20 49 8b e3 5f c3')
    first_handler_target = va + d.at; handler_call = d.relative('e8'); d.literal('90'); rethrow_prefix = va + d.at; d.literal('33 d2')
    rethrow_target = va + d.at; rethrow_call = d.relative('e8'); d.literal('cc'); d.end()
    need(len(code) == 288 and flag == written_flag and metadata_skip == ready, 'Start exact metadata guard')
    need(setup_calls == [0x1806c01e0] * 3, 'Start exact runtime metadata setup')
    need(class_skip1 == class_skip2 == class_ready and class_use == setup_uses[0], 'Start class-init edges')
    need(generic_use == setup_uses[1], 'Start generic method usage identity')
    need(after_virtual == normal_exit and null_result == first_handler_target and handler_nonnull == rethrow_prefix, 'Start result/handler branch edges')
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
        'call_sites': {k: hex(v) for k, v in [('get_transform', first_site), ('instantiate', struct_site), ('handle', handle_site), ('SetActive', activation_site), ('virtual_hook', virtual_site), ('null_exception', first_handler_target), ('rethrow', rethrow_target)]},
        'virtual_dispatch': {'method_pointer_offset': 408, 'method_info_offset': 416,
                             'raw_slot_owner_contract_proved_here': False},
        'exception_handler_entry': hex(handler_start),
        'rethrow_argument_setup': hex(rethrow_prefix),
        'exception_unwind_CSharp_semantics_proved_here': False,
        'source_body_accepted': False,
    }
def main():
    inventory = ROOT / 'Validation/RecRoomGameRootNative-20261022T162444Z-d9c732b7/report.json'
    need(sha(inventory) == '9492989fb0f23794155b1e0bd6e9ae25eeae2fc86687a9e1016abfb14617d7f6', 'Original native inventory pin')
    record = json.loads(inventory.read_bytes())
    original = next(x for x in record['methods'] if x['original']['index'] == 200263)
    code = bytes.fromhex(original['runtime_function']['bytes'])
    va = int(original['native_pointer'], 16)
    shape = decode_start(code, va)
    paths = [ROOT / 'CodeSource' / rel for rel in EXPECTED]
    for path in paths:
        need(sha(path) == EXPECTED[path.relative_to(ROOT/'CodeSource').as_posix()], 'Exact original source input')
    with paths[0].open('rb') as bf, paths[1].open('rb') as mf, mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b, mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        view = ExternMetadata(b,md)
        method = view.find_method('RecRoomGameRoot', 0x060026c0)
        need(method == dict(original['original'], declaring_type=view.type_info(30331)) and view.method_pointer(method) == va, 'Exact registered original Start identity including resolved owner')
        rs, parents = pdata(view)
        whole = scopes(view,method,rs,parents)
        need(bytes.fromhex(whole['runtime_function']['bytes']) == code and whole['complete_connected_chain_region_count'] == 1, 'Exactly the whole288B Start scope, not a prefix')
        uses = [view.usage(int(x,16)) for x in shape['metadata_uses']]
        direct_targets = {int(shape['direct_calls'][key],16) for key in ['receiver_first_call','struct_return_call','activation_call']}
        mapped,gaps = aliases(view,direct_targets)
        generic = view.generic_targets({uses[1]['index']}) if uses[1]['kind'] == 6 else {}
        layout = header_layout()
        need(layout['vtable_offset'] == 0x138 and layout['VirtualInvokeData_bytes'] == 16 and 0x138+6*16 == 408, 'Matching original AMD64 slot6 layout')
        virtuals = []
        for owner,token,index in [('GameRoot',0x06000004,66485),('RecRoomGameRoot',0x060026c1,200264)]:
            target = view.find_method(owner,token)
            need(target['index']==index and target['name']=='HPCJAAEDLCH' and target['return']=='System.Void' and not target['parameters'], 'Original parameterless bootstrap hook')
            slot = view.u16(md,view.row('methods',index,32)+28)
            td=view.row('typeDefinitions',target['owner_index'],88); start=view.i32(md,td+56); count=view.u16(md,td+74)
            need(slot==6 and slot<count, 'Exact original native hook slot6')
            encoded=view.u32(md,view.row('vtableMethods',start+slot,4))
            need(encoded>>29==3 and ((encoded&0x1fffffff)>>1)==index, 'Original vtable binds exact hook MethodDef')
            virtuals.append({'method':target,'slot':slot,'encoded':hex(encoded),'pointer':hex(view.method_pointer(target))})
        rf=original['runtime_function']
        eh=parse_function(view,(rf['start_rva'],rf['end_rva'],rf['unwind_rva']))
        need(len(eh['try_blocks'])==1 and len(eh['try_blocks'][0]['handlers'])==1, 'Exact one original EH handler')
        handler=eh['try_blocks'][0]['handlers'][0]
        need(handler['continuation_rvas']==['0xc87f00'] and handler['type_descriptor_rva']=='0x8c65330', 'Original exception wrapper catch and exact continuation')
        funclet_va=view.base+int(handler['handler_rva'],16)
        hits=[row for row in rs if row[0]==funclet_va-view.base]
        need(len(hits)==1 and hits[0] not in parents, 'Exact catch funclet runtime entry')
        start,end,unwind=hits[0]; at=view.raw(view.base+start,end-start)
        funclet={'pointer':hex(view.base+start),'runtime_function':list(hits[0]),'bytes':bytes(b[at:at+end-start]).hex(),'sha256':hashlib.sha256(bytes(b[at:at+end-start])).hexdigest()}
        states={key:state_at(eh,int(value,16)) for key,value in shape['call_sites'].items()}
        need(states == {'get_transform':0,'instantiate':0,'handle':0,'SetActive':0,'virtual_hook':0,'null_exception':0,'rethrow':-1}, 'Exact original protected call intervals and rethrow outside try')
    negatives=[]
    for label,old,new in [('startup-field','48 8b 7b 18','48 8b 7b 20'),('activation-value','45 33 c0 b2 01','45 33 c0 b2 00'),('hook-slot','ff 90 98 01 00 00','ff 90 a8 01 00 00'),('rethrow-prefix-branch','48 85 c9 75 1b','48 85 c9 75 1d')]:
        a=bytes.fromhex(old);need(code.count(a)==1,'Unique mutation anchor')
        try: decode_start(code.replace(a,bytes.fromhex(new)),va)
        except (ValueError,struct.error):negatives.append({'mutation':label,'rejected':True})
        else:raise ValueError('Changed original Start accepted: '+label)
    out=ROOT/'Validation'/('RecRoomStartFlow-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'original-RecRoomGameRoot-Start-whole-scope-typed-flow/v1','status':'native288B_shape_and_slot6_EH_bound_catch_funclet_semantics_pending','original':original,'shape':shape,'complete_connected_scope':whole,'metadata_uses':uses,'raw_backed_direct_aliases':mapped,'unbacked_alias_inventory_gaps':gaps,'handle_generic_targets':generic,'virtual_dispatch':virtuals,'native_class_layout':layout,'original_EH':eh,'callsite_protected_states':states,'catch_funclet':funclet,'negative_controls':negatives,'inputs':[{'path':str(p),'sha256':sha(p)} for p in [inventory,*paths,Path(__file__)]],'Main_modified':False,'CSharp_candidate_emitted':False,'working_startup_claimed':False}
    target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({'report':str(target),'sha256':sha(target),'uses':uses,'calls':{k:[x['owner']+'.'+x['name'] for x in values] for k,values in mapped.items()},'generic_targets':generic,'funclet':funclet,'negative_controls':len(negatives)}))

if __name__=='__main__':
    main()

