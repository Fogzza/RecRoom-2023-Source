"""Strict complete Awake CFG and original identities, no invented C# body.

The first .pdata region is only116 bytes. This validates the full original
256-byte registration window, including the real exception tail and padding.
Run only when the parent's bounded static-parser slot has been released.
"""
from pathlib import Path
import datetime as dt, hashlib, json, mmap, struct, sys, uuid
HERE=Path(__file__).resolve().parent; WORKSPACE=HERE.parents[2]; ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE)); sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata, need
from audit_forwarding import EXPECTED, sha
from audit_ogpeg_constructors import Decoder
from prove_recroom_ondestroy_native_cfg import aliases

WINDOW=ROOT/'Validation/RecRoomAwakeWindow-20261022T170103Z-2d9ae12a/bounded-decoder-input.json'

def decode(code, va):
    d=Decoder(code,va)
    d.literal('40 57 48 83 ec 20')
    flag=d.relative('80 3d','00'); d.literal('48 8b f9'); skip=d.short('75')
    A=d.relative('48 8d 0d'); initA=d.relative('e8')
    B=d.relative('48 8d 0d'); initB=d.relative('e8')
    C=d.relative('48 8d 0d'); initC=d.relative('e8')
    D=d.relative('48 8d 0d'); initD=d.relative('e8')
    written=d.relative('c6 05','01'); ready=va+d.at
    loadedD=d.relative('48 8b 15'); d.literal('48 8b cf'); base=d.relative('e8')
    d.literal('33 c9'); service=d.relative('e8'); d.literal('48 85 c0'); null=d.relative('0f 84')
    loadedB=d.relative('4c 8b 05'); d.literal('33 d2 48 8b c8 48 89 5c 24 30'); value=d.relative('e8')
    d.literal('48 8d 4f 28 48 8b d0 48 89 01'); barrier=d.relative('e8')
    loadedA1=d.relative('48 8b 0d'); allocate1=d.relative('e8'); loadedC1=d.relative('4c 8b 05')
    d.literal('45 33 c9 48 8b d7 48 8b c8 48 8b d8'); ctor1=d.relative('e8')
    d.literal('33 d2 48 8b cb'); event1=d.relative('e8')
    loadedA2=d.relative('48 8b 0d'); allocate2=d.relative('e8'); loadedC2=d.relative('4c 8b 05')
    d.literal('45 33 c9 48 8b d7 48 8b c8 48 8b d8'); ctor2=d.relative('e8')
    d.literal('33 d2 48 8b cb 48 8b 5c 24 30 48 83 c4 20 5f'); event2=d.relative('e9')
    null_at=va+d.at; nre=d.relative('e8'); d.literal('cc')
    semantic_end=d.at
    need(len(code)==256 and all(x==0xcc for x in code[semantic_end:]),'Only original INT3 padding after closed exception tail')
    d.literal('cc '*(len(code)-semantic_end)); d.end()
    need(flag==written and skip==ready and A==loadedA1==loadedA2 and B==loadedB and C==loadedC1==loadedC2 and D==loadedD,'Exact metadata initialization/loaded-usage CFG')
    need(initA==initB==initC==initD==0x1806c01e0 and allocate1==allocate2==0x1806c0340 and nre==0x1806c0390 and null==null_at,'Exact anchored runtime helpers/null branch')
    need(ctor1==ctor2,'Both exact callbacks use same original delegate constructor')
    return {'metadata_A_delegate_class':hex(A),'metadata_B_value_method':hex(B),'metadata_C_callback_method':hex(C),'metadata_D_base_method':hex(D), 'base_call':hex(base),'service_getter_call':hex(service),'value_method_call':hex(value),'reference_field_store_offset':40,'post_store_barrier_call':hex(barrier),'delegate_constructor':hex(ctor1),'first_event_call':hex(event1),'second_event_tail_call':hex(event2),'null_exception_helper':hex(nre),'semantic_bytes_including_exception_tail':semantic_end,'padding_bytes':len(code)-semantic_end,'all256_bytes_checked':True,'complete_normal_and_exception_control_flow_and_stack_checked':True}

def main():
    need(sha(WINDOW)=='fdf0769584217c4ce1fdac328119dcffd51f3cc7e7dc531252fb70fad227da50','Original bounded window drift')
    old=json.loads(WINDOW.read_text()); row=old['methods'][0]; code=bytes.fromhex(row['runtime_function']['bytes']); va=int(row['native_pointer'],16)
    shape=decode(code,va)
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for path in paths: need(sha(path)==EXPECTED[path.relative_to(ROOT/'CodeSource').as_posix()],'Original full-file source SHA drift')
    with paths[0].open('rb') as bf, paths[1].open('rb') as mf, mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b, mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md); method=v.find_method('RecRoomGameRoot',0x060026bf)
        need(v.method_pointer(method)==va and bytes(b[v.raw(va,len(code)):v.raw(va,len(code))+len(code)])==code,'Exact original MethodDef/token/registration/window join')
        uses={k:v.usage(int(value,16)) for k,value in shape.items() if k.startswith('metadata_')}
        generic_indices={u['index'] for u in uses.values() if u['kind']==6}
        generic=v.generic_targets(generic_indices)
        targets={int(shape[k],16) for k in ['service_getter_call','delegate_constructor','first_event_call','second_event_tail_call']}
        mapped,gaps=aliases(v,targets)
        fields=[]; td=v.row('typeDefinitions',method['owner_index'],88); first=v.i32(md,td+32); count=v.u16(md,td+68); offsets=v.u64(b,v.field_offsets+method['owner_index']*8)
        for i in range(count):
            fi=first+i; at=v.row('fields',fi,12); kind=v.native_type(v.i32(md,at+4)); offset=struct.unpack_from('<i',b,v.raw(offsets+i*4,4))[0]
            if offset==40: fields.append({'owner':method['owner'],'owner_native_index':method['owner_index'],'native_field_index':fi,'token':hex(v.u32(md,at+8)),'name':v.string(v.i32(md,at)),'type':v.typename(kind),'native_type':kind,'offset':offset})
        need(len(fields)==1 and fields[0]['name']=='JBOKGAJENGP' and fields[0]['type']=='MFENCGHNPBJ','Exact original reference field40 join')
    controls=[]
    for label,offset in [('original_this_register',15),('metadata_setup_branch',16),('base_receiver',82),('reference_field_offset',129),('tail_opcode',238)]:
        mutation=bytearray(code); mutation[offset]^=1
        try: decode(bytes(mutation),va)
        except (ValueError,struct.error): controls.append({'mutation':label,'offset':offset,'rejected':True})
        else: raise AssertionError('Native Awake mutation accepted '+label)
    out=ROOT/'Validation'/('RecRoomAwakeClosedCFG-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]); out.mkdir()
    report={'schema':'original-RecRoomGameRoot-Awake-complete-native-CFG-dependencies/v1','status':'exact_CFG_and_original_metadata_dependencies_only_no_CSharp_candidate', 'original':method,'native_pointer':hex(va),'native_code_sha256':hashlib.sha256(code).hexdigest(),'native_code':code.hex(),'exact_native_control_flow':shape,'original_metadata_uses':uses,'original_generic_registrations':generic,'raw_backed_direct_pointer_aliases':mapped,'alias_inventory_unbacked_tables':gaps,'exact_original_reference_field':fields[0],'negative_controls':controls,'original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths], 'GC_barrier_semantics_and_all_typed_dependencies_complete':False,'game_or_native_code_executed':False,'main_or_harness_changed':False,'CSharp_body_written':False}
    path=out/'report.json'; path.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({'report':str(path),'sha256':sha(path),'shape':shape,'uses':uses,'generic':generic,'direct_typed_counts':{k:len(v) for k,v in mapped.items()},'negative_controls':len(controls)}))

if __name__=='__main__': main()
