"""Whole-opcode proof/candidates for exactly the123B factory and156B ctor."""
from pathlib import Path
import argparse
import hashlib
import json
import mmap
import struct
import sys

HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]
ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from audit_ogpeg_constructors import Decoder,runtime_helpers
from collect_all_pinvoke_native import ExternMetadata,need
from collect_nameserver_request_factory_native import pin,fields
from audit_original_rendering_sdk_candidates import h,body

INPUT=ROOT/'Validation/NativeRequestFactory-20261023T063058Z-4b09cc33/factory-native-inputs.json'


def factory_shape(code,va):
    d=Decoder(code,va)
    d.literal('48 89 5c 24 08 48 89 6c 24 10 48 89 74 24 18 57 48 83 ec 30')
    flag=d.relative('80 3d','00');d.literal('49 8b f8 0f b6 f2 48 8b e9');ready=d.short('75')
    klass=d.relative('48 8d 0d');init=d.relative('e8');written=d.relative('c6 05','01');at_ready=va+d.at
    loaded=d.relative('48 8b 0d');allocate=d.relative('e8')
    d.literal('4c 8b cf 48 c7 44 24 20 00 00 00 00 44 0f b6 c6 48 8b d5 48 8b c8 48 8b d8')
    ctor=d.relative('e8')
    d.literal('48 8b 6c 24 48 48 8b c3 48 8b 5c 24 40 48 8b 74 24 50 48 83 c4 30 5f c3');d.end()
    need(flag==written and ready==at_ready and klass==loaded==0x1887ca7b8
         and init==0x1806c01e0 and allocate==0x1806c0340 and ctor==0x1831a5680,
         'Exact allocation/constructor/class metadata/guard/branch targets required')
    return {'all_native_bytes_checked':len(code),'allocated_class_usage':hex(klass),'constructor_target':hex(ctor),
            'argument0_Uri':'preserved identity','argument1_HTTPMethods':'zero-extended original byte ABI',
            'argument2_Action':'preserved identity','returns_same_new_concrete_instance':True,
            'no_other_application_callees':True}


def ctor_shape(code,va):
    d=Decoder(code,va)
    d.literal('48 89 5c 24 08 48 89 6c 24 10 48 89 74 24 18 57 48 83 ec 30')
    flag=d.relative('80 3d','00');d.literal('49 8b d9 41 0f b6 f8 48 8b f2 48 8b e9');ready=d.short('75')
    klass=d.relative('48 8d 0d');init=d.relative('e8');written=d.relative('c6 05','01');at_ready=va+d.at
    d.literal('4c 8b cb 48 c7 44 24 20 00 00 00 00 44 0f b6 c7 48 8b d6 48 8b cd')
    base=d.relative('e8');loaded=d.relative('48 8b 0d');allocate=d.relative('e8')
    d.literal('45 33 c9 44 0f b6 c7 48 8b d6 48 8b c8 48 8b d8');http_ctor=d.relative('e8')
    d.literal('48 8d 4d 38 48 8b d3 48 89 19 48 8b 5c 24 40 48 8b 6c 24 48 48 8b 74 24 50 48 83 c4 30 5f')
    barrier=d.relative('e9');d.end()
    need(flag==written and ready==at_ready and klass==loaded==0x1886f9890 and init==0x1806c01e0
         and base==0x183b63860 and allocate==0x1806c0340 and http_ctor==0x1831697d0
         and barrier==0x1806bfd30,'Exact base/HTTP ctor/field write and runtime barrier targets required')
    return {'all_native_bytes_checked':len(code),'base_constructor_target':hex(base),
        'base_arguments':'same Uri, original byte enum, original Action, unchanged order',
        'allocated_type_usage':hex(klass),'HTTP_constructor_target':hex(http_ctor),
        'HTTP_ctor_explicit_arguments':'same Uri and byte enum; hidden MethodInfo null is not an explicit callback argument',
        'field_store_offset':56,'field_value':'the new HTTPRequest','write_barrier':hex(barrier),
        'base_call_before_HTTP_allocation_and_field_store':True,'no_validation_logic_added_or_removed':True}


def no_chained_entries(v,roots):
    opt=v.u32(v.b,60)+24;rva,size=struct.unpack_from('<II',v.b,opt+136)
    need(0<size<=16*1024**2 and size%12==0,'Bounded complete PE runtime table required')
    at=v.raw(v.base+rva,size);entries=list(struct.iter_unpack('<III',v.b[at:at+size]))
    parents={}
    for row in entries:
        ui=v.raw(v.base+row[2],4);flags=v.b[ui]>>3;count=v.b[ui+2]
        if flags&4:
            parent=v.raw(v.base+row[2]+((4+2*count+3)&~3),12)
            parents[row]=struct.unpack_from('<III',v.b,parent)
    result=[]
    for root in roots:
        wanted=(root['start_rva'],root['end_rva'],root['unwind_rva'])
        need(wanted in entries and wanted not in parents,'Registered entry must be an unchained native root')
        linked={wanted}
        while True:
            more={child for child,parent in parents.items() if parent in linked}-linked
            if not more:break
            linked|=more;need(len(linked)<1024,'Bounded chained function graph')
        need(linked=={wanted},'Additional chained runtime regions require separate recovery')
        result.append({'root':list(wanted),'all_runtime_entries_examined':len(entries),'linked_child_regions':0})
    return result


def cli_type(c,r,owner):
    found=[rid for rid in range(1,c.rows[2]+1) if r.definition(rid)==owner]
    need(len(found)==1,'Unique exact current CLI owner required')
    rid=found[0];at=c.row(2,rid);off=4+2*c.strw+c.coded(2,[2,1,27]);start=c.value(at+off,c.index(4))
    end=c.value(c.row(2,rid+1)+off,c.index(4)) if rid<c.rows[2] else c.rows[4]+1
    fields=[]
    for fi in range(start,end):
        f=c.row(4,fi);sig=c.blob(c.value(f+2+c.strw,c.blobw));need(sig[0]==6,'CLI field signature')
        typ,pos=r.type(sig,1);need(pos==len(sig),'Entire CLI field signature')
        fields.append({'token':hex(0x04000000|fi),'name':c.string(c.value(f+2,c.strw)),'flags':c.u16(f),'type':typ})
    base=c.value(at+4+2*c.strw,c.coded(2,[2,1,27]))
    return {'owner':owner,'type_token':hex(0x02000000|rid),'flags':c.u32(at),'base':r.codedtype(base) if base else None,'fields':fields,
            'methods':[m|{'body':body(c,m['token'])} for m in r.methods(rid)]}


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--out',required=True,type=Path);args=ap.parse_args()
    out=args.out.resolve(strict=True)
    need(out.is_relative_to(ROOT/'Validation'),'New recovery evidence output only')
    need(not any((out/name).exists() for name in ('RequestFactoryReplacementMembers.cs.txt','mock-control-plan.json','factory-candidate-report.json')),'Fresh candidate/proof outputs required')
    need(pin(INPUT)['sha256']=='3832063c16f492b3d4e84ea2d5d1cfc5cfffbd8b8cbd10e12a42270d51ad9736','Frozen extraction evidence SHA required')
    source=json.loads(INPUT.read_bytes());f=source['factory'];ctors=source['concrete_constructor_regions']
    need(source['schema']=='exact-native-nameserver-request-factory-and-ctor-inputs/v1','Exact source evidence schema required')
    need(len(ctors)==1 and ctors[0]['original']['owner']=='FACHPIFDBPF','Exactly one concrete factory constructor')
    ctor=ctors[0];proofs=[];controls=[]
    for row,decoder in [(f,factory_shape),(ctor,ctor_shape)]:
        code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['VA'],16)
        proof=decoder(code,va);rejected=0
        for i in range(len(code)):
            changed=bytearray(code);changed[i]^=1
            try:decoder(bytes(changed),va)
            except (ValueError,struct.error):rejected+=1
            else:raise AssertionError('Changed native byte accepted '+str(i))
        controls.append({'method':row['original']['owner']+'.'+row['original']['name'],'one_byte_xor1_mutations':len(code),'all_rejected':rejected==len(code)})
        proofs.append({'original':row['original'],'native_SHA256':row['runtime_function']['sha256'],'whole_opcode_shape':proof})
    paths=[Path(p['path']) for p in source['inputs']]
    for record in source['inputs']:need(pin(record['path'])==record,'Pinned original source changed')
    original_stats=[(p.stat().st_size,p.stat().st_mtime_ns) for p in paths]
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md)
        for row in (f,ctor):
            fresh=v.find_method(row['original']['owner'],int(row['original']['token'],16))
            comparison={k:value for k,value in fresh.items() if k in row['original']}
            need(comparison==row['original'] and v.method_pointer(fresh)==int(row['VA'],16),'Fresh original MethodDef/signature/registration must equal frozen evidence')
            fn=row['runtime_function'];code=bytes.fromhex(fn['bytes']);at=v.raw(int(row['VA'],16),len(code))
            need(fn['start_rva']==int(row['VA'],16)-v.base and fn['end_rva']-fn['start_rva']==len(code)
                 and bytes(b[at:at+len(code)])==code and hashlib.sha256(code).hexdigest()==fn['sha256'],'Fresh original complete native bytes/bounds/SHA required')
        chains=no_chained_entries(v,[f['runtime_function'],ctor['runtime_function']])
        runtime=runtime_helpers(v)
        enum_index=next(i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)=='BestHTTP.HTTPMethods')
        td=v.row('typeDefinitions',enum_index,88);field=v.row('fields',v.i32(md,td+32),12)
        need(v.string(v.i32(md,field))=='value__','Exact original HTTPMethods enum value field')
        enum_type=v.native_type(v.i32(md,field+4));need(enum_type['kind']==5,'Exact original HTTPMethods byte ABI')
        allocated=f['RIP_metadata_usages']['0x1887ca7b8'];http=ctor['RIP_metadata_usages']['0x1886f9890']
        need(allocated['kind']==http['kind']==1 and allocated['type']=='FACHPIFDBPF' and http['type']=='BestHTTP.HTTPRequest','Exact native allocation metadata identities')
        need(v.usage(0x1887ca7b8)==allocated and v.usage(0x1886f9890)==http,'Fresh original allocation metadata usages required')
        field=ctor['declared_fields'][0]
        need(len(ctor['declared_fields'])==1 and field['name']=='FPBDBMAAJKE' and field['offset']==56
             and field['type']=='BestHTTP.HTTPRequest' and field['native_type']['attributes']==33,'Exact private readonly concrete request field')
        need(fields(v,ctor['original']['owner_index'])==ctor['declared_fields'],'Fresh exact original field metadata/layout required')
        concrete_type=v.type_info(ctor['original']['owner_index'])
        need(concrete_type['parent_type']=='CDMLNBEJKKH' and concrete_type['token']=='0x2000d89','Exact concrete parent identity required')
        dependencies=[v.find_method('CDMLNBEJKKH',0x06005de2),v.find_method('BestHTTP.HTTPRequest',0x060008ad)]
        need([v.method_pointer(x) for x in dependencies]==[0x183b63860,0x1831697d0],'Exact original dependency MethodDef registrations')
    need(original_stats==[(p.stat().st_size,p.stat().st_mtime_ns) for p in paths],'Read-only original source race')
    current=WS/'RR23/Assets/Plugins/RecNet.Runtime.dll'
    current_pin=pin(current)
    with current.open('rb') as stream,mmap.mmap(stream.fileno(),0,access=mmap.ACCESS_READ) as data:
        c=h.m.cli.Cli(data);r=h.Read(c)
        contract=[cli_type(c,r,name) for name in ('CDMLNBEJKKH','FACHPIFDBPF','BestHTTP.HTTPRequest','BestHTTP.HTTPMethods')]
    current_factory=next(m for m in contract[0]['methods'] if m['token']=='0x6005de1')
    current_ctor=next(m for m in contract[1]['methods'] if m['token']=='0x6005e14')
    current_base_ctor=next(m for m in contract[0]['methods'] if m['token']=='0x6005de2')
    current_http_ctor=next(m for m in contract[2]['methods'] if m['token']=='0x60008ad')
    current_field=next(x for x in contract[1]['fields'] if x['name']=='FPBDBMAAJKE')
    need(current_factory['name']=='GPGHDDABLEF' and len(current_factory['signature']['parameters'])==3
         and current_ctor['name']=='.ctor' and len(current_ctor['signature']['parameters'])==3
         and current_field['flags']==33 and current_field['token']=='0x4003552'
         and next(x for x in contract[3]['fields'] if x['name']=='value__')['type']=='byte','Exact current original owner/token/field/enum ABI contract')
    scope='[RecNet.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]'
    expected_params=['class [System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]System.Uri',
        'valuetype '+scope+'BestHTTP.HTTPMethods',
        'class [mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]System.Action`2<class '+scope+'CDMLNBEJKKH,class '+scope+'JIOJMFNAIND>']
    need(current_factory['signature']['parameters']==current_ctor['signature']['parameters']==current_base_ctor['signature']['parameters']==expected_params
         and current_http_ctor['signature']['parameters']==expected_params[:2]
         and current_factory['signature']['return']=='class '+scope+'CDMLNBEJKKH'
         and current_factory['flags']==150 and current_factory['signature']['callconv']==0
         and current_ctor['flags']==6278 and current_base_ctor['flags']==6276 and current_http_ctor['flags']==6278
         and all(m['signature']['callconv']==32 and m['signature']['return']=='void' for m in (current_ctor,current_base_ctor,current_http_ctor))
         and contract[1]['base']==scope+'CDMLNBEJKKH' and contract[1]['flags']==concrete_type['flags']
         and current_field['type']=='class '+scope+'BestHTTP.HTTPRequest','Exact scoped current signature/base/flags contract required')
    need(pin(current)==current_pin,'Read-only current DLL race')
    candidate=out/'RequestFactoryReplacementMembers.cs.txt'
    candidate.write_text('''// Exactly two original replacement members. Not standalone SDK source; not compiled/installed.
// Keep every other existing declaration, member, field, flag and initializer.
// CDMLNBEJKKH token 0x06005DE1; public static; native 0x183B633C0 / 123 bytes.
public static CDMLNBEJKKH GPGHDDABLEF(System.Uri FKFKJOJNCLM,
    BestHTTP.HTTPMethods PNMOPCJFNHG,
    System.Action<CDMLNBEJKKH, JIOJMFNAIND> ONAFALABHKI)
{
    return new FACHPIFDBPF(FKFKJOJNCLM, PNMOPCJFNHG, ONAFALABHKI);
}

// FACHPIFDBPF token 0x06005E14; public ctor; native 0x1831A5680 / 156 bytes.
// Existing FPBDBMAAJKE (0x04003552) remains private readonly BestHTTP.HTTPRequest.
public FACHPIFDBPF(System.Uri FKFKJOJNCLM,
    BestHTTP.HTTPMethods PNMOPCJFNHG,
    System.Action<CDMLNBEJKKH, JIOJMFNAIND> ONAFALABHKI)
    : base(FKFKJOJNCLM, PNMOPCJFNHG, ONAFALABHKI)
{
    FPBDBMAAJKE = new BestHTTP.HTTPRequest(FKFKJOJNCLM, PNMOPCJFNHG);
}
''',encoding='utf-8')
    mock_plan={'schema':'controlled-request-factory-mock-plan/v1','status':'planned_no_compile_or_execution',
        'candidate_members':pin(candidate),'controls':[
            'Factory returns exactly the constructed FACHPIFDBPF instance and forwards Uri/byteenum/Action identities unchanged.',
            'Constructor records base(Uri,method,Action) before constructing HTTPRequest(Uri,method), then assigns only FPBDBMAAJKE.',
            'Null Uri/callback and each original enum value are forwarded; no guessed validation or network policy is introduced.',
            'An injected base-constructor throw prevents HTTP allocation/field store; an HTTP-constructor throw propagates after base effects.',
            'A recording-only dependency harness never constructs a real HTTP/TLS object or invokes original classinitializers.',
            'This mock validates these two recovered call/argument/order shapes only; it cannot establish request send/response parsing/login/TLS behavior.'],
        'Main_modified':False,'compiler_or_Unity_or_game_launched':False,'network_requests':0}
    mp=out/'mock-control-plan.json';mp.write_text(json.dumps(mock_plan,indent=2)+'\n')
    report={'schema':'whole-opcode-original-request-factory-concrete-ctor-candidates/v1',
        'status':'factory123_and_concrete_ctor156_native_proven_candidates_not_installed',
        'native_input_evidence':pin(INPUT),'proofs':proofs,'negative_controls':controls,'complete_PE_unwind_chain_checks':chains,
        'byte_enum_ABI_proven':True,'original_native_field':field,'original_concrete_type':concrete_type,'original_runtime_helper_identity':runtime,
        'fresh_original_metadata_and_registered_native_bytes_rejoined':True,'actual_current_DLL':current_pin,'actual_CLI_contract':contract,
        'candidate_replacement_members':pin(candidate),'mock_control_plan':pin(mp),
        'remaining_original_native_dependencies_not_replaced':dependencies,
        'operational_nameserver_claimed':False,'request_send_response_map_population_or_TLS_recovered':False,
        'NDFLHBFOIGB_initializer_or_certificate_behavior_changed':False,'Main_modified':False,'network_requests':0,
        'compiler_Unity_managed_game_or_original_native_code_invoked':False,'tool':pin(Path(__file__))}
    rp=out/'factory-candidate-report.json';rp.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({'status':report['status'],'report':pin(rp),'candidate':pin(candidate),'negative_mutations':sum(x['one_byte_xor1_mutations'] for x in controls)}))


if __name__=='__main__':main()
