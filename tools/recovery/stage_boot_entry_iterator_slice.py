"""Prove/stage Boot entry and iterator basics outside Main; no child launches.

MoveNext, state transition implementation, timer bodies and service/network
dependencies remain boundaries. Dispose already matches and is never rewritten.
"""
from pathlib import Path
import base64,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_ogpeg_constructors import Decoder
from collect_nameserver_request_factory_native import fields
from collect_title_page_route_native import pin
JOIN=ROOT/'Validation/BootSequenceStartupTypedJoins-20261023T104012Z-df5248ca/report.json'
JOIN_SHA='8cd37b831f74b602701c64c919869f411d1bf858b512483a27fc6be1cadf55b1'
BASIC=ROOT/'Validation/BootIteratorBasicsNative-20261023T111158Z-0b81d9f3'
BASIC_SHA='c987a6d5147c226d1c4390842f8d259069736cb965ebf2f972693a84c52923b7'
SOURCE=WS/'RR23/Assets/Scripts/Assembly-CSharp/BootSequence.cs'

def ctor(code,va):
    d=Decoder(code,va);d.literal('48895c2408574883ec208bfa488bd933d2');base=d.relative('e8');d.literal('897b10488b5c24304883c4205fc3');d.end();need(len(code)==36 and base==0x1806f84d0,'Exact whole state ctor: capture state, Object base then this+16 store');return {'Object_base_target':hex(base),'state_field_offset':16,'argument_capture_before_base':True,'state_store_only_after_base':True}
def start(code,va):
    d=Decoder(code,va);d.literal('48895c2408574883ec20');flag=d.relative('803d','00');d.literal('488bf9');loaded=d.short('75');usage=d.relative('488d0d');init=d.relative('e8');written=d.relative('c605','01');loaded_at=va+d.at;again=d.relative('488b0d');allocation=d.relative('e8');d.literal('4533c033d2488bc8488bd8');constructor=d.relative('e8');d.literal('4885db');null=d.short('74');d.literal('488d4b20488bd7488939');barrier=d.relative('e8');d.literal('488bc3488b5c24304883c4205fc3');null_at=va+d.at;throw=d.relative('e8');d.literal('cc');d.end();need(len(code)==109 and flag==written and loaded==loaded_at and usage==again==0x188719a90 and init==0x1806c01e0 and allocation==0x1806c0340 and constructor==0x180871950 and barrier==0x1806bfd30 and null==null_at and throw==0x1806c0390,'Whole original Start allocates exact NEK, ctor state0, captures same Boot this+32 and returns same iterator');return {'iterator_type_usage':hex(usage),'constructor_target':hex(constructor),'initial_state':0,'captured_Boot_this_field_offset':32,'same_allocated_iterator_returned':True,'iterator_MoveNext_not_executed_here':True}
def login(code,va,begin):
    d=Decoder(code,va);d.literal('40534883ec20');flag=d.relative('803d','00');d.literal('488bd9');loaded=d.short('75');usages=[];inits=[]
    for i in range(3):usages.append(d.relative('488d0d'));inits.append(d.relative('e8'))
    written=d.relative('c605','01');loaded_at=va+d.at;d.literal('488b8ba8000000c683d0000000'+('01' if begin else '00')+'4885c9');null1=d.short('74');u1=d.relative('488b15');d.literal('4533c0');call1=d.relative('e8');d.literal('488b8ba80000004885c9');null2=d.short('74');u2=d.relative('488b15');d.literal('4533c0');call2=d.relative('e8');d.literal('80bbb000000000');skip=d.short('74');d.literal('488b8ba80000004885c9');null3=d.short('74');u3=d.relative('488b15');d.literal('4533c04883c4205b');tail=d.relative('e9');end=va+d.at;d.literal('4883c4205bc3');null_at=va+d.at;throw=d.relative('e8');d.literal('cc');d.end();target=0x180707740 if begin else 0x180707ef0
    need(len(code)==175 and flag==written and loaded==loaded_at and inits==[0x1806c01e0]*3 and sorted(usages)==sorted([u1,u2,u3]) and [u1,u2,u3]==[0x18886dc98,0x188866600,0x18886c360] and [call1,call2,tail]==[target]*3 and null1==null2==null3==null_at and skip==end and throw==0x1806c0390,'Whole exact login flag/store, three timer operands, fresh reloads, conditional tail, null exits')
    return {'flag_value':begin,'first_timer_receiver_captured_before_flag_store':True,'flag_written_before_first_timer_null_failure':True,'timer_field_offset':168,'flag_field_offset':208,'conditional_field_offset':176,'ordered_string_usages':[hex(x) for x in [u1,u2,u3]],'ordered_timer_method_target':hex(target),'second_and_third_receivers_fresh_field_reads':True,'third_call_only_if_fresh_LIPOFDEAMPE_true':True}
def launch(code,va):
    d=Decoder(code,va);d.literal('48895c2408574883ec20');flag=d.relative('803d','00');d.literal('488bda488bf9');loaded=d.short('75');usage=d.relative('488d0d');init=d.relative('e8');written=d.relative('c605','01');loaded_at=va+d.at;d.literal('4885db');skip=d.short('74');d.literal('488d8f80000000488bd3488919');barrier=d.relative('e8');afterstore=va+d.at;d.literal('488b8fa80000004885c9');null=d.short('74');again=d.relative('488b15');d.literal('4533c0');timer=d.relative('e8');d.literal('4533c0488bcf418d5003488b5c24304883c4205f');state=d.relative('e9');null_at=va+d.at;throw=d.relative('e8');d.literal('cc');d.end();need(len(code)==125 and flag==written and loaded==loaded_at and usage==again==0x18886dc98 and init==0x1806c01e0 and skip==afterstore and barrier==0x1806bfd30 and null==null_at and timer==0x180707ef0 and state==0x180a57590 and throw==0x1806c0390,'Whole launch keeps prior target for raw-null arg, stores nonnull target before timer and state3');return {'raw_argument_null_test':True,'nonnull_launch_target_field_offset':128,'timer_field_offset':168,'timer_target':hex(timer),'timer_literal_usage':hex(usage),'state_transition_target':hex(state),'state_argument':3,'no_state_transition_if_timer_throws':True}
def leaf(code,va,index):
    want=bytes.fromhex('c20000' if index==195712 else '488b4118c3');need(code==want,'Complete terminal raw leaf body');return {'already_correct_empty_Dispose_no_rewrite':index==195712,'raw_current_field_offset':None if index==195712 else 24,'same_current_reference_or_null_returned':index!=195712,'no_calls_branches_stack_frame_or_field_writes':True}
def reset(code,va):
    d=Decoder(code,va);d.literal('40534883ec20');klass=d.relative('488d0d');init1=d.relative('e8');d.literal('488bc8');allocate=d.relative('e8');d.literal('33d2488bc8488bd8');construct=d.relative('e8');method=d.relative('488d0d');init2=d.relative('e8');d.literal('488bd0488bcb');throw=d.relative('e8');d.literal('cc');d.end();need(len(code)==63 and klass==0x1887b28e8 and method==0x1887d89b0 and init1==init2==0x1806c01e0 and allocate==0x1806c0340 and construct==0x18567ae20 and throw==0x1806c0360,'Whole reset allocates exact NotSupportedException, no-argument ctor, raises same object with original Reset method attribution');return {'exception_type_usage':hex(klass),'parameterless_exception_ctor_target':hex(construct),'exception_method_attribution_usage':hex(method),'original_raise_exception_helper':hex(throw),'does_not_read_or_write_iterator_fields':True}
def tick(code,va):
    d=Decoder(code,va);d.literal('40534883ec20488bd9488b89900000004885c9');null1=d.short('74');d.literal('33d2');first=d.relative('e8');d.literal('488b8b880000004885c9');null2=d.short('74');d.literal('33d24883c4205b');tail=d.relative('e9');null_at=va+d.at;throw=d.relative('e8');d.literal('cc');d.end();need(len(code)==58 and null1==null2==null_at and first==tail==0x1809a75f0 and throw==0x1806c0390,'Whole HKB first state90 then fresh second state88, same no-argument direct method, raw receiver null checks');return {'unused_float_argument':True,'ordered_original_field_offsets':[144,136],'ordered_same_original_method_target':hex(first),'second_field_read_only_after_first_call_returns':True,'callee_failure_propagated_no_later_call':True}
def literal(v,index):
    at=v.row('stringLiteral',index,8);n,o=struct.unpack_from('<ii',v.m,at);base,size=v.tables['stringLiteralData'];need(0<=o and 0<=n<=256 and o+n<=size,'Bounded exact original string literal');return bytes(v.m[base+o:base+o+n]).decode('utf-8')
def unwind(v,rows):
    out=[]
    for x in rows:
        a=v.raw(v.base+x['unwind_rva'],4);lead=v.b[a];flags=lead>>3;need(lead&7==1 and not flags&3,'No language exception/finally handlers in selected original scopes');out.append({'unwind_rva':x['unwind_rva'],'version':lead&7,'flags':flags,'no_exception_or_unwind_handler':True})
    return out
def block(text):return text.replace('\n','\r\n').encode()
def edit(before,old,new,owner,name,lo=0,hi=None):
    hi=len(before) if hi is None else hi;start=before.find(old,lo,hi);need(start>=lo and before.find(old,start+1,hi)<0,'Exactly one selected current source span '+owner+'.'+name);return {'owner':owner,'member':name,'start':start,'length':len(old),'original_base64':base64.b64encode(old).decode(),'replacement_base64':base64.b64encode(new).decode()}

def main():
    need(pin(JOIN)['sha256']==JOIN_SHA and pin(BASIC/'run-report.json')['sha256']==BASIC_SHA,'Exact actual Root native scopes/decoder evidence');j=json.loads(JOIN.read_bytes());br=json.loads((BASIC/'run-report.json').read_bytes());need(br['status']=='five_original_Boot_iterator_basics_and_timer_callback_inert_decoded_semantics_pending','Actual five-scope inert decode passed')
    for x in [j['original_region_input'],j['actual_decoder_receipt'],j['actual_decoded_output'],br['plan'],br['output']]:need(pin(x['path'])==x,'Pinned actual decoder ancestry')
    bp=json.loads(Path(br['plan']['path']).read_bytes());need(pin(bp['input']['path'])==bp['input'],'Original iterator scope input');basic=json.loads(Path(bp['input']['path']).read_bytes());streams={x['native_method_index']:x for x in [json.loads(z) for z in Path(br['output']['path']).read_text().splitlines()]};selected=[]
    for r in j['startup_methods']:
        i=r['original_method']['index']
        if i in [195711,195631,195633,195634,195652]:selected.append({'original':r['original_method'],'native_pointer':hex(0x180000000+r['native_region']['start_rva']),'runtime_function':r['native_region'],'original_connected_regions':r['original_runtime_regions']})
    selected+=basic['methods'];need([x['original']['index'] for x in selected]==[195711,195631,195633,195634,195652,195712,195714,195715,195716,195679],'Exactly ten logical entries/basics, nine replacement bodies')
    shapes=[];controls=[]
    for r in selected:
        i=r['original']['index'];code=bytes.fromhex(r['runtime_function']['bytes']);va=int(r['native_pointer'],16);fn=ctor if i==195711 else start if i==195631 else (lambda c,a:login(c,a,True)) if i==195633 else (lambda c,a:login(c,a,False)) if i==195634 else launch if i==195652 else reset if i==195715 else tick if i==195679 else (lambda c,a:leaf(c,a,i));shape=fn(code,va);shapes.append({'original':r['original'],'complete_native_semantics':shape})
        for offset in range(len(code)):
            changed=bytearray(code);changed[offset]^=1
            try:fn(bytes(changed),va)
            except (ValueError,IndexError):controls.append({'original_index':i,'changed_byte':offset,'rejected':True})
            else:raise ValueError('Unproved native mutation accepted '+str((i,offset)))
    paths=[Path(x['path']) for x in basic['original_inputs']]
    for r in basic['original_inputs']:need(pin(r['path'])==r,'Exact native/metadata authorities')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);unwinds=[]
        for r in selected:
            current=v.method_info(r['original']['index'])
            if 'declaring_type' in r['original']:current['declaring_type']=v.type_info(current['owner_index'])
            need(current==r['original'],'Every selected original typed method and enriched declaring type identity');va=int(r['native_pointer'],16);raw=bytes.fromhex(r['runtime_function']['bytes']);need(bytes(b[v.raw(va,len(raw)):v.raw(va,len(raw))+len(raw)])==raw,'Exact genuine native method bytes');unwinds.append({'original_method_index':r['original']['index'],'rows':unwind(v,r['original_connected_regions'])})
        bindings=[]
        for i,owner,name,ret,args,ptr in [(235562,'OFDHBOEDNCN','FHBILIJBOGI','System.Void',['System.String'],0x180707740),(235563,'OFDHBOEDNCN','NOMPIEABHOP','System.Void',['System.String'],0x180707ef0),(262898,'OOMEAMBGFPG','CDJHKCNAIKI','System.Void',[],0x1809a75f0),(195614,'BootSequence','BCOIAODGNGB','System.Void',['BootSequence/INFFBPOJOIJ'],0x180a57590),(195711,'BootSequence/NEKGMMPKEPF','.ctor','System.Void',['System.Int32'],0x180871950)]:
            m=v.method_info(i);need((m['owner'],m['name'],m['return'],[x['type'] for x in m['parameters']])==(owner,name,ret,args) and not m['flags']&0x10 and v.method_pointer(m)==ptr,'Exact typed original direct target and instance signature');bindings.append({'original':m,'native_pointer':hex(ptr)})
        obj=v.find_method('System.Object',0x06001081);need(v.method_pointer(obj)==0x1806f84d0,'Exact shared empty Object base ctor');bindings.append({'original':obj,'native_pointer':'0x1806f84d0'})
        klass=v.usage(0x1887b28e8);attrib=v.usage(0x1887d89b0);need(klass['kind']==1 and klass['type']=='System.NotSupportedException' and attrib['kind']==3 and attrib['method']['index']==195715,'Original exception class and Reset method attribution')
        exc=v.find_type('System.NotSupportedException') if hasattr(v,'find_type') else None
        if exc is None:
            hits=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)=='System.NotSupportedException'];need(len(hits)==1,'One original NotSupportedException');exc=hits[0]
        need(isinstance(exc,int),'Concrete original exception type index');td=v.row('typeDefinitions',exc,88);first=v.i32(md,td+36);ms=[v.method_info(first+k) for k in range(v.u16(md,td+64))];ctors=[m for m in ms if m['name']=='.ctor' and not m['parameters'] and not m['flags']&0x10];need(len(ctors)==1 and v.method_pointer(ctors[0])==0x18567ae20,'Exact original no-argument NotSupportedException constructor');bindings.append({'original':ctors[0],'native_pointer':'0x18567ae20'})
        bootfields=fields(v,29848);iteratorfields=fields(v,29840);expected={168:('AIDHPHJKAMP','OFDHBOEDNCN'),208:('IHCDBPMANNH','System.Boolean'),176:('LIPOFDEAMPE','System.Boolean'),128:('OHDIFKONNPP','BootSequence/NJIJPADHPEC'),144:('HOMDODONEKI','MDEJADHJOEJ'),136:('DFECAIFGNCA','MDEJADHJOEJ')}
        selectedfields=[]
        for offset,pair in expected.items():
            rows=[f for f in bootfields if f['offset']==offset and (f['name'],f['type'])==pair and not f['native_type']['attributes']&0x10];need(len(rows)==1,'Exact original Boot field offset/type/name');selectedfields+=rows
        need([(x['offset'],x['name'],x['type']) for x in iteratorfields]==[(16,'<>1__state','System.Int32'),(24,'<>2__current','System.Object'),(32,'<>4__this','BootSequence')],'Exact original iterator state/current/owner capture fields');need(v.type_info(29840)['parent_type']=='System.Object' and v.type_info(29835)['parent_type']=='System.Object','Original iterator and ordinary launch-target class parents')
        need(v.type_info(40408)['parent_type']=='OOMEAMBGFPG','Both timer callback fields inherit the original no-argument base state method')
        literals=[]
        for address,index,text in [(0x18886dc98,1790,'(Waiting for Rec Room)'),(0x188866600,1743,'(Boot Start To User Interaction)'),(0x18886c360,1780,'(Process Start To User Interaction)')]:
            u=v.usage(address);need(u['kind']==5 and u['index']==index and literal(v,index)==text,'Exact ordered original timer string literal');literals.append({'metadata_usage':u,'literal':text})
        enum=29837;need(v.full_name(enum)=='BootSequence/INFFBPOJOIJ','Original private Boot state enum identity');td=v.row('typeDefinitions',enum,88);fs=v.i32(md,td+32);matches=[fs+k for k in range(v.u16(md,td+68)) if v.string(v.i32(md,v.row('fields',fs+k,12)))=='POST_LOGIN_RECNET_OPERATIONS'];need(len(matches)==1,'Exact original named state field');defaults=[]
        for k in range(v.count('fieldDefaultValues',12)):
            a=v.row('fieldDefaultValues',k,12)
            if v.i32(md,a)==matches[0]:defaults.append(v.i32(md,v.tables['fieldAndParameterDefaultValueData'][0]+v.i32(md,a+8)))
        need(defaults==[3],'Exact original state3 means POST_LOGIN_RECNET_OPERATIONS')
    before=SOURCE.read_bytes();lo=before.index(b'\tprivate sealed class NEKGMMPKEPF');hi=before.index(b'\tprivate sealed class HMPHEGFPPFD',lo);edits=[]
    def add(old,new,name,nested=False):edits.append(edit(before,block(old),block(new),'BootSequence/NEKGMMPKEPF' if nested else 'BootSequence',name,lo if nested else 0,hi if nested else None))
    add('\t\tpublic NEKGMMPKEPF(int _003C_003E1__state)\n\t\t{\n\t\t}\n','\t\tpublic NEKGMMPKEPF(int _003C_003E1__state)\n\t\t{\n\t\t\tthis._003C_003E1__state = _003C_003E1__state;\n\t\t}\n','.ctor',True)
    add('\tprivate IEnumerator Start()\n\t{\n\t\treturn null;\n\t}\n','\tprivate IEnumerator Start()\n\t{\n\t\treturn new NEKGMMPKEPF(0) { _003C_003E4__this = this };\n\t}\n','Start')
    for name,begin,method in [('BeginPlatformLogin',True,'FHBILIJBOGI'),('EndPlatformLogin',False,'NOMPIEABHOP')]:
        old='\tpublic void '+name+'()\n\t{\n\t}\n';new='\tpublic void '+name+'()\n\t{\n\t\tOFDHBOEDNCN timer = this.AIDHPHJKAMP;\n\t\tthis.IHCDBPMANNH = '+('true' if begin else 'false')+';\n\t\ttimer.'+method+'("(Waiting for Rec Room)");\n\t\tthis.AIDHPHJKAMP.'+method+'("(Boot Start To User Interaction)");\n\t\tif (this.LIPOFDEAMPE)\n\t\t{\n\t\t\tthis.AIDHPHJKAMP.'+method+'("(Process Start To User Interaction)");\n\t\t}\n\t}\n';add(old,new,name)
    add('\tpublic void LaunchGame(NJIJPADHPEC GFCPAMJILIO)\n\t{\n\t}\n','\tpublic void LaunchGame(NJIJPADHPEC GFCPAMJILIO)\n\t{\n\t\tif (GFCPAMJILIO != null)\n\t\t{\n\t\t\tthis.OHDIFKONNPP = GFCPAMJILIO;\n\t\t}\n\t\tthis.AIDHPHJKAMP.NOMPIEABHOP("(Waiting for Rec Room)");\n\t\tthis.BCOIAODGNGB(INFFBPOJOIJ.POST_LOGIN_RECNET_OPERATIONS);\n\t}\n','LaunchGame')
    # Only the two null expressions inside the original NEK owner are replaced;
    # attributes, explicit interface declaration syntax and other iterators stay.
    generic_start=before.index(b'\t\tobject IEnumerator<object>.Current',lo,hi);nongeneric_start=before.index(b' object global::System.Collections.IEnumerator.Current',generic_start,hi);constructor_start=before.index(b'\t\t[DebuggerHidden]\r\n\t\tpublic NEKGMMPKEPF',nongeneric_start,hi)
    for a,z,name in [(generic_start,nongeneric_start,'IEnumerator<object>.Current'),(nongeneric_start,constructor_start,'IEnumerator.Current')]:edits.append(edit(before,b'return null;',b'return this._003C_003E2__current;','BootSequence/NEKGMMPKEPF',name,a,z))
    add('\t\tvoid IEnumerator.Reset()\n\t\t{\n\t\t}\n','\t\tvoid IEnumerator.Reset()\n\t\t{\n\t\t\tthrow new NotSupportedException();\n\t\t}\n','IEnumerator.Reset',True)
    add('\tprivate void HKBJKPPPCPM(float FBFLLMKFMDL)\n\t{\n\t}\n','\tprivate void HKBJKPPPCPM(float FBFLLMKFMDL)\n\t{\n\t\tthis.HOMDODONEKI.CDJHKCNAIKI();\n\t\tthis.DFECAIFGNCA.CDJHKCNAIKI();\n\t}\n','HKBJKPPPCPM')
    need(len(edits)==9,'Exactly nine selected spans; Dispose already correct and untouched');ordered=sorted(edits,key=lambda x:x['start']);need(all(a['start']+a['length']<=b['start'] for a,b in zip(ordered,ordered[1:])),'No overlapping source spans');after=before
    for e in reversed(ordered):need(before[e['start']:e['start']+e['length']]==base64.b64decode(e['original_base64']),'Exact source span bytes');after=after[:e['start']]+base64.b64decode(e['replacement_base64'])+after[e['start']+e['length']:]
    out=ROOT/'Validation'/('BootEntryIteratorSlice-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();candidate=out/'BootSequence.cs';candidate.write_bytes(after);members=out/'RecoveredBootEntryIterator.members.cs';members.write_bytes(b'// Existing original-owner replacement spans only; not standalone classes.\r\n'+b'\r\n'.join(base64.b64decode(e['replacement_base64']) for e in edits));report={'schema':'nine-original-Boot-entry-iterator-basics-source-bodies/v1','status':'nine_complete_original_bodies_staged_binding_and_controlled_effects_pending','producer':pin(Path(__file__)),'startup_native_joins':pin(JOIN),'iterator_actual_decoder':pin(BASIC/'run-report.json'),'iterator_original_scopes':bp['input'],'original_inputs':basic['original_inputs'],'selected_logical_methods':[r['original'] for r in selected],'new_replacement_bodies':9,'already_correct_Dispose_not_rewritten':True,'complete_native_shapes':shapes,'single_byte_negative_controls':controls,'no_selected_method_language_EH_handlers':unwinds,'exact_typed_callee_bindings':bindings,'exact_original_fields':selectedfields+iteratorfields,'ordered_original_timer_literals':literals,'original_NotSupportedException_type_usage':klass,'original_Reset_attribution_usage':attrib,'original_state3_name':'POST_LOGIN_RECNET_OPERATIONS','source':pin(SOURCE),'source_meta':pin(Path(str(SOURCE)+'.meta')),'candidate':pin(candidate),'readable_members':pin(members),'byte_edits':edits,'all_unselected_source_bytes_preserved':True,'remaining_dependencies':['NEK.MoveNext is separately owned and not recovered by these9 bodies','BCOIAODGNGB transition body and original timer/state-machine bodies remain explicit boundaries','No original BootSequence startup, service resolution, login, rendering or scene transition has executed'],'Main_modified':False,'compiler_Unity_game_network_launched':False,'working_startup_login_claimed':False};rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(rp),'candidate':pin(candidate),'new_replacement_bodies':9,'native_negative_controls':len(controls),'Dispose_rewritten':False}))
if __name__=='__main__':main()
