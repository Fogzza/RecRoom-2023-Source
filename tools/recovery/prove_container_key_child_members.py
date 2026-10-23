"""Close four original key/child methods from a pinned inert native decode.

Only bounded native/CLI metadata is parsed. No compiler, SDK/game body, Unity,
player or network executes. The child method's real constructor dependency is
preserved; this is not a claim that container registration/providers work.
"""
from pathlib import Path
import copy,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata
from prepare_startup_foundation_slice import SOURCE_PINS
from prove_recroom_ondestroy_native_cfg import aliases
from prove_service_container_getter_native import exported,header_layout
from audit_boot_candidate_dependency_closure import module_methods
from audit_hashable_scoped_vtable import Read,m as audit
SLICE=ROOT/'Validation/LiveContainerPathSlice-20261023T083125Z-cc7dd812'
DECODE=SLICE/'RootDecodePlan-20261023T083145Z-9443a4a4'
DECODE_SHA='2fab1781c07756a35cb527f071fbf3a38a71386a69048419c63bcf9380ab3aa9'
INPUT_SHA='b72a3e6502d46260aba4bf47f597161b2ae8d7b888118505dd7b27f0f673dbac'
SPECS={
47897:(0x186745200,100,'980f530fb0681867c527bf6f86af33dd44046dfe71922daee61d06f2a7282676'),
47931:(0x186742150,156,'c2f825c8bf44a768fbd29661d0a589e1ad5c51862e5d6a5dd15ebb3bea2b8b68'),
47932:(0x186741ff0,238,'dc7c5a8b92e6b6190111e5488cc14a5596052d75d0b41388835e36767171c857'),
47933:(0x1867420e0,112,'9cf488fb3e976224a4d5dfb31fb38b95364a31152dd93e4d63b57c847562152f')}
# These are every behavior-bearing operand in the complete decoded bodies.
# Metadata initialization, saves/restores and branches are also frozen by the
# exact complete native bytes and the separately pinned Root decoder output.
EFFECTS={
47897:{0x186745216:'mov rdi,rdx',0x186745219:'mov rsi,rcx',0x18674521e:'lea rcx,[1887282A8h]',0x186745231:'mov rcx,[1887282A8h]',0x186745238:'call 00000001806C0340h',0x18674523d:'xor r9d,r9d',0x186745240:'mov r8,rdi',0x186745243:'mov rdx,rsi',0x186745246:'mov rcx,rax',0x186745249:'mov rbx,rax',0x18674524c:'call 0000000186745480h',0x186745256:'mov rax,rbx',0x186745263:'ret'},
47931:{0x186742166:'mov rbx,rdx',0x186742169:'mov rdi,rcx',0x18674216e:'lea rcx,[1887CAA40h]',0x186742181:'mov rcx,[1887CAA40h]',0x186742188:'mov rsi,[rdi]',0x1867421a2:'mov rdx,[rbx]',0x1867421a5:'xor r8d,r8d',0x1867421a8:'mov rcx,rsi',0x1867421ab:'call 0000000180BFDED0h',0x1867421b0:'test al,al',0x1867421b2:'jne short 00000001867421C4h',0x1867421c4:'movups xmm0,[rbx]',0x1867421c7:'mov rcx,[rdi+8]',0x1867421cb:'xor r8d,r8d',0x1867421ce:'psrldq xmm0,8',0x1867421d3:'movq rdx,xmm0',0x1867421e7:'jmp 000000018476E1B0h'},
47932:{0x186742001:'mov rbx,rdx',0x186742004:'mov rdi,rcx',0x186742009:'lea rcx,[188832098h]',0x18674201c:'test rbx,rbx',0x186742025:'mov r8,[rbx]',0x186742028:'xor eax,eax',0x18674202a:'mov rdx,[188832098h]',0x186742031:'cmp r8,rdx',0x186742034:'cmove rax,rbx',0x186742038:'test rax,rax',0x186742041:'mov rax,[rdx+40h]',0x186742045:'mov rcx,rbx',0x186742048:'cmp [r8+40h],rax',0x186742052:'call 0000000180640E30h',0x18674205e:'movups xmm0,[rax]',0x186742061:'movaps [rsp+20h],xmm0',0x18674207b:'mov rcx,[1887CAA40h]',0x186742082:'mov rbx,[rdi]',0x18674209c:'mov rdx,[rsp+20h]',0x1867420a1:'xor r8d,r8d',0x1867420a4:'mov rcx,rbx',0x1867420a7:'call 0000000180BFDED0h',0x1867420ae:'je short 00000001867420CBh',0x1867420b0:'mov rdx,[rsp+28h]',0x1867420b5:'xor r8d,r8d',0x1867420b8:'mov rcx,[rdi+8]',0x1867420c6:'jmp 000000018476E1B0h',0x1867420d0:'xor al,al',0x1867420d8:'call 00000001806BFD70h'},
47933:{0x1867420e6:'mov rbx,rcx',0x1867420e9:'mov rcx,[rcx]',0x1867420ec:'test rcx,rcx',0x1867420ef:'je short 000000018674214Ah',0x1867420f1:'mov rax,[rcx]',0x1867420f9:'mov rdx,[rax+160h]',0x186742100:'call qword ptr [rax+158h]',0x186742106:'mov rcx,[rbx+8]',0x18674210a:'mov edi,eax',0x18674210c:'test rcx,rcx',0x18674210f:'je short 0000000186742137h',0x186742111:'mov r8,[rcx]',0x186742114:'mov rdx,[r8+160h]',0x18674211b:'call qword ptr [r8+158h]',0x186742122:'mov ecx,eax',0x186742124:'imul eax,edi,18Dh',0x18674212f:'xor eax,ecx',0x186742137:'imul eax,edi,18Dh',0x186742142:'xor eax,ecx',0x18674214a:'call 00000001806C0390h'}}
def need(value,message):
    if not value:raise ValueError(message)
def pin(path):
    p=Path(path).resolve(strict=True)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')
def shape(decoded,source):
    mi=decoded['native_method_index'];va,size,digest=SPECS[mi];code=bytes.fromhex(source['runtime_function']['bytes']);need(len(code)==size and hashlib.sha256(code).hexdigest()==digest and decoded['native_pointer']==va,'Exact complete native byte identity')
    ins=decoded['instructions'];byip={x['ip']:x for x in ins};at=va
    for x in ins:need(x['ip']==at and x['length']>0,'Contiguous complete original decode');at+=x['length']
    need(at==va+size and len(byip)==len(ins),'All original native bytes accounted for')
    for ip,text in EFFECTS[mi].items():need(byip[ip]['text']==text,'Exact original key/child effect operand at '+hex(ip))
    direct={47897:{0x1806c01e0,0x1806c0340,0x186745480},47931:{0x1806c01e0,0x180640f10,0x180bfded0},47932:{0x1806c01e0,0x180640f10,0x180640e30,0x180bfded0,0x1806bfd70},47933:{0x1806c0390}}[mi]
    noreturn={0x1806bfd70,0x1806c0390};edges={};indirect=[];tails=[]
    for x in ins:
        nxt=x['ip']+x['length'];target=x['operands'][0]['target'] if x['operands'] else 0;flow=x['flow']
        if flow=='Call':need(target in direct,'No unbound direct callee');successors=[] if target in noreturn else [nxt]
        elif flow=='IndirectCall':need(mi==47933 and x['ip'] in (0x186742100,0x18674211b),'Only original two slot2 hash calls');indirect.append(hex(x['ip']));successors=[nxt]
        elif flow=='ConditionalBranch':need(target in byip,'Internal branch target closes in exact original window');successors=[target,nxt]
        elif flow=='UnconditionalBranch':need(mi in (47931,47932) and target==0x18476e1b0,'Only exact genuine string equality tail');tails.append(hex(target));successors=[]
        elif flow in ('Return','Interrupt'):successors=[]
        else:need(flow=='Next','No unsupported native control flow');successors=[nxt]
        edges[x['ip']]=successors
    seen=set();queue=[va]
    while queue:
        ip=queue.pop();need(ip in byip,'No reachable native edge escapes captured bytes')
        if ip not in seen:seen.add(ip);queue.extend(edges[ip])
    need(all(byip[ip]['mnemonic']=='Int3' for ip in set(byip)-seen),'Only exception separator after known noreturn may be unreachable')
    return {'complete_native_bytes':size,'native_sha256':digest,'all_CFG_edges_closed':True,'all_instructions':[{'ip':hex(x['ip']),'length':x['length'],'text':x['text'],'flow':x['flow']} for x in ins],'behavior_operand_contracts':len(EFFECTS[mi]),'hash_virtual_slot2_call_sites':indirect,'genuine_framework_tail_targets':tails,'first_pdata_region_not_mistaken_for_whole_method':mi==47933}
def slot(v,ti,index):
    q=v.row('typeDefinitions',ti,88);start=v.i32(v.m,q+56);count=v.u16(v.m,q+74);need(index<count,'Original virtual slot in range');encoded=v.u32(v.m,v.row('vtableMethods',start+index,4));need(encoded>>29==3,'Original virtual slot is a MethodDef');method=v.method_info((encoded&0x1fffffff)>>1);need(v.u16(v.m,v.row('methods',method['index'],32)+28)==index,'Original declared virtual slot matches dispatch');return method
def main():
    need(pin(DECODE/'run-report.json')['sha256']==DECODE_SHA and pin(SLICE/'five-original-live-container-windows.json')['sha256']==INPUT_SHA,'Exact prior Root decode and original window capture')
    receipt=json.loads((DECODE/'run-report.json').read_bytes());need(receipt['status']=='decoded_original_entry_windows_not_whole_method_recovery' and pin(receipt['output']['path'])==receipt['output'],'Actual successful inert decoder output')
    sources=json.loads((SLICE/'five-original-live-container-windows.json').read_bytes());byindex={r['original']['index']:r for r in sources['methods']};decoded={r['native_method_index']:r for r in [json.loads(line) for line in Path(receipt['output']['path']).read_text().splitlines()]}
    shapes={str(mi):shape(decoded[mi],byindex[mi]) for mi in SPECS};paths=[ROOT/'CodeSource'/name for name in SOURCE_PINS]
    for p in paths:need(pin(p)['sha256']==SOURCE_PINS[p.relative_to(ROOT/'CodeSource').as_posix()],'Fresh verified original source authority')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
        v=ExternMetadata(b,m)
        for mi,(va,size,digest) in SPECS.items():
            original=v.method_info(mi);need(original==byindex[mi]['original'] and v.method_pointer(original)==va,'Exact original owner/token/native registration');raw=v.raw(va,size);need(bytes(b[raw:raw+size])==bytes.fromhex(byindex[mi]['runtime_function']['bytes']),'Fresh exact original native span')
        uses={hex(va):v.usage(va) for va in [0x1887282a8,0x1887caa40,0x188832098]};need([uses[hex(x)]['type'] for x in [0x1887282a8,0x1887caa40,0x188832098]]==['MNALHHOLFGL','System.Type','CPAMAFPANDM'],'Exact original allocation/type metadata namespaces')
        constructor=v.method_info(47895);need(v.method_pointer(constructor)==0x186745480 and constructor['owner']=='MNALHHOLFGL' and constructor['name']=='.ctor' and constructor['flags']==6275 and [x['type'] for x in constructor['parameters']]==['MNALHHOLFGL','System.String'],'Exact existing internal parent/name constructor target')
        candidates,gaps=aliases(v,{0x180bfded0,0x18476e1b0});typed=[x for x in candidates['0x180bfded0'] if x['index']==3682];strings=[x for x in candidates['0x18476e1b0'] if x['owner']=='System.String'];need(len(typed)==1 and typed[0]['owner']=='System.Type' and typed[0]['name']=='op_Equality' and [x['type'] for x in typed[0]['parameters']]==['System.Type','System.Type'] and typed[0]['return']=='System.Boolean','Field type and exact registration bind System.Type equality, not arbitrary shared aliases')
        need({x['index'] for x in strings}=={3161,3163} and all([p['type'] for p in x['parameters']]==['System.String','System.String'] and x['return']=='System.Boolean' for x in strings),'Both original string Equals/operator aliases share exactly the same native implementation')
        virtuals={name:slot(v,ti,2) for name,ti in [('System.Type',351),('System.String',330)]};need(all(x['owner']==name and x['name']=='GetHashCode' and x['return']=='System.Int32' and not x['parameters'] for name,x in virtuals.items()),'Both original virtual slot2 calls bind genuine hash methods')
        layout=header_layout();need(layout['vtable_offset']==0x138 and layout['VirtualInvokeData_bytes']==16,'Matching original x64 runtime vtable layout');layout.update(slot2_method_pointer_offset=0x158,slot2_MethodInfo_offset=0x160)
        need(exported(v,'il2cpp_object_unbox')==0x180640e30,'Original boxed CPAM unbox runtime export')
        td=v.row('typeDefinitions',6606,88);fs=v.i32(m,td+32);fc=v.u16(m,td+68);fo=v.raw(v.u64(b,v.field_offsets+6606*8),fc*4);fields=[]
        for i in range(fc):
            q=v.row('fields',fs+i,12);nt=v.native_type(v.i32(m,q+4));offset=v.i32(b,fo+i*4);fields.append({'name':v.string(v.i32(m,q)),'type':v.typename(nt),'flags':nt['attributes'],'token':hex(v.u32(m,q+8)),'registered_boxed_field_offset':offset,'native_unboxed_offset':offset-16})
        need([(x['name'],x['type'],x['registered_boxed_field_offset'],x['native_unboxed_offset'],x['flags']) for x in fields]==[('AFJAGKNNCBE','System.Type',16,0,38),('FEKLPCPODAH','System.String',24,8,38)],'Exact public readonly fields; registered boxed offsets16/24 versus native value offsets0/8')
        object_header=WS/'Tools/Editors/2020.3.33f1/Editor/Data/il2cpp/libil2cpp/il2cpp-object-internals.h';header_text=object_header.read_text();need('Il2CppClass *klass;' in header_text and 'Il2CppVTable *vtable;' in header_text and 'MonitorData *monitor;' in header_text,'Matching Il2CppObject header is two x64 pointer slots')
    current=WS/'RR23/Assets/Plugins/UJect.Runtime.dll';selectors=[{'owner':'MNALHHOLFGL','name':'MJHONDPGJFA','parameters':1}]+[{'owner':'CPAMAFPANDM','name':n,'parameters':count} for n,count in [('OFPEIHMPLIL',1),('Equals',1),('GetHashCode',0)]];methods=module_methods(current,selectors);need(len(methods)==4 and [x['IL_bytes'] for x in methods]==['142a','162a','162a','162a'],'Exact four current default stubs only')
    with current.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=audit.cli.Cli(b);reader=Read(c);ti=next(i for i in range(1,c.rows[2]+1) if reader.definition(i)=='CPAMAFPANDM');need(ti==16,'Exact retained key TypeDef');interfaces=[]
        for i in range(1,c.rows[9]+1):
            q=c.row(9,i)
            if c.value(q,c.index(2))==ti:interfaces.append(reader.codedtype(c.value(q+c.index(2),c.coded(2,[2,1,27]))))
        need(len(interfaces)==1 and 'System.IComparable`1<' in interfaces[0] and not any('IEquatable' in s for s in interfaces),'Original typed equality is a plain named method; do not invent an IEquatable declaration')
        for row,mi in zip(methods,SPECS):need(row['flags']==byindex[mi]['original']['flags'] and int(row['current_CLI_token_not_original_native'],16)==int(byindex[mi]['original']['token'],16),'Current exact original flags and MethodDef tokens')
    controls=[]
    for mi in SPECS:
        for ip in EFFECTS[mi]:
            changed=copy.deepcopy(decoded[mi]);next(x for x in changed['instructions'] if x['ip']==ip)['text']='changed original effect'
            try:shape(changed,byindex[mi])
            except ValueError:controls.append({'original_method_index':mi,'site':hex(ip),'rejected':True})
            else:raise ValueError('Changed behavior operand accepted')
    text='''// Exact selected-member recovery source. Outside Assets compilation.
// Preserve original fields, names, signatures, flags and all other members.
// MNALHHOLFGL.MJHONDPGJFA only:
public MNALHHOLFGL MJHONDPGJFA(string MIJDIKJDKAN)
{
    return new MNALHHOLFGL(this, MIJDIKJDKAN);
}

// CPAMAFPANDM only. This type implements IComparable<CPAMAFPANDM>,
// not IEquatable<CPAMAFPANDM>. Do not introduce a new interface or rename OFPE.
public bool OFPEIHMPLIL(CPAMAFPANDM HNPEBINPOBO)
{
    return this.AFJAGKNNCBE == HNPEBINPOBO.AFJAGKNNCBE
        && string.Equals(this.FEKLPCPODAH, HNPEBINPOBO.FEKLPCPODAH);
}
public override bool Equals(object ICHBECDKHOJ)
{
    if (!(ICHBECDKHOJ is CPAMAFPANDM))
        return false;
    CPAMAFPANDM other = (CPAMAFPANDM)ICHBECDKHOJ;
    return this.AFJAGKNNCBE == other.AFJAGKNNCBE
        && string.Equals(this.FEKLPCPODAH, other.FEKLPCPODAH);
}
public override int GetHashCode()
{
    int typeHash = this.AFJAGKNNCBE.GetHashCode();
    string name = this.FEKLPCPODAH;
    int nameHash = (object)name != null ? name.GetHashCode() : 0;
    return unchecked((typeHash * 397) ^ nameHash);
}
'''
    candidate=HERE/'RecoveredContainerKeyChildMembers.cs'
    if candidate.exists():need(candidate.read_text()==text,'Never overwrite frozen selected-member source')
    else:
        with candidate.open('x',encoding='utf-8',newline='\n') as f:f.write(text)
    out=ROOT/'Validation'/('ContainerKeyChildMembers-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();r={'schema':'original-four-container-key-child-complete-native-CFG/v1','status':'four_complete_native_bodies_and_typed_targets_staged_binding_effects_pending','producer':pin(Path(__file__)),'Root_decode_receipt':pin(DECODE/'run-report.json'),'Root_decoded_output':receipt['output'],'original_windows':pin(SLICE/'five-original-live-container-windows.json'),'original_sources':[pin(p) for p in paths],'native_methods':[byindex[mi]['original'] for mi in SPECS],'complete_native_shapes':shapes,'typed_metadata_uses':uses,'key_fields':fields,'typed_child_constructor_dependency':constructor,'typed_System_Type_equality':typed[0],'string_shared_native_aliases':strings,'CSharp_string_Equals_syntax_not_claimed_original_source':True,'typed_hash_virtual_slot2_methods':virtuals,'matching_x64_header_layout':layout,'unbacked_other_alias_tables_not_assumed_absent':gaps,'current_plugin':pin(current),'current_meta':pin(str(current)+'.meta'),'current_methods':methods,'original_key_interfaces':interfaces,'readable_selected_members':pin(candidate),'negative_controls':controls,'actual_CSharp_binding_or_effects_tested':False,'production_child_ctor_or_registration_execution_permitted':False,'remaining_service_path':['PHJ instance registration caller and provider construction/storage','NGB lookup caller plus LNF initializer and CPBM provider lookup','Concrete provider interface methods'], 'higher_bootstrap_activated':False,'working_startup_login_or_services_claimed':False,'Main_modified':False,'compiler_Unity_game_network_or_target_DLL_executed':False};target=out/'report.json';save(target,r);print(json.dumps({'report':pin(target),'candidate':pin(candidate),'negative_controls':len(controls),'native_bytes':sum(x[1] for x in SPECS.values())}))
if __name__=='__main__':main()
