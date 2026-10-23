"""Stage three original-owner startup members from Root's inert native decode.

Data only: original metadata/CFG joins, no target assembly loading or child.
The native cast-support calls are recorded as a checked-cast code-generation
pattern; their framework implementation is not replaced by game code.
"""
from pathlib import Path
import copy,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata
from resolve_startup_foundation_native_joins import rgctx,literal
from prepare_startup_foundation_slice import SOURCE_PINS
from prove_recroom_ondestroy_native_cfg import aliases

SLICE=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207'
DECODE=SLICE/'RootDecodePlan-20261023T064445Z-3d511bf4'
RECEIPT_SHA='141739ddd8ee6d3d1598431daaf838f2ac778ed85d66c92426cc3f789ece59ce'
VLAYOUT=WS/'Tools/RecoveryTools/Cpp2IL-development-b5ad444b-SelectedRecovery/Source/Cpp2IL-b5ad444b82267cb1e4b88b8b373c008105bdea52/Cpp2IL.Core/Il2CppClassUsefulOffsets.cs'

def need(v,m):
    if not v:raise ValueError(m)
def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def pin(p):
    p=Path(p).resolve(strict=True);return {'path':str(p),'bytes':p.stat().st_size,'sha256':sha(p)}
def save(p,v):
    with p.open('x',encoding='utf-8') as f:json.dump(v,f,indent=2);f.write('\n')

# Every semantic block has exact original instruction contracts. All omitted
# instruction positions are still covered by the pinned, byte-exact decoder
# output and the whole CFG/known-callee checks below; they are not discarded.
CONTRACTS={
66500:{
0x18333e461:'mov rax,[rdi+18h]',0x18333e465:'mov rcx,[rax+0C0h]',0x18333e46c:'mov rbx,[rcx]',
0x18333e4fe:'mov rax,[rbx+0B8h]',0x18333e50c:'mov rbx,[rax]',
0x18333e51f:'xor r8d,r8d',0x18333e522:'xor edx,edx',0x18333e524:'mov rcx,rbx',
0x18333e527:'call 0000000183172430h',0x18333e52e:'je 000000018333E6A7h',
0x18333e54d:'mov rbx,[rbx+18h]',0x18333e563:'mov rcx,rbx',0x18333e566:'call 0000000183D98380h',
0x18333e56e:'je 000000018333E7B0h',0x18333e574:'mov r8,[rax]',0x18333e577:'mov rcx,rax',
0x18333e57a:'mov rdx,[r8+170h]',0x18333e581:'call qword ptr [r8+168h]',
0x18333e588:'mov r8,[18880D198h]',0x18333e592:'mov rcx,[188761D40h]',0x18333e599:'mov rdx,rax',
0x18333e59c:'call 000000018476BDE0h',0x18333e5c4:'mov rcx,rbx',0x18333e5c7:'call 0000000183EBFF40h',
0x18333e662:'mov rax,[rbx+0B8h]',0x18333e669:'mov rcx,[rax]',0x18333e66f:'je 000000018333E7B0h',
0x18333e677:'call 0000000183EBA740h',0x18333e69f:'mov rcx,rbx',0x18333e6a2:'call 0000000183170670h',
0x18333e729:'mov rbx,[rcx+10h]',0x18333e743:'test rbp,rbp',0x18333e746:'jne short 000000018333E74Ch',
0x18333e748:'xor esi,esi',0x18333e74a:'jmp short 000000018333E75Fh',0x18333e74c:'mov rdx,rbx',
0x18333e74f:'mov rcx,rbp',0x18333e752:'call 00000001806BFD40h',0x18333e757:'mov rsi,rax',
0x18333e75a:'test rax,rax',0x18333e75d:'je short 000000018333E7A4h',
0x18333e77e:'mov rcx,[rbx+0B8h]',0x18333e785:'mov rdx,rsi',0x18333e788:'mov [rcx],rsi',
0x18333e79f:'jmp 00000001806BFD30h',0x18333e7a4:'mov rdx,rbx',0x18333e7a7:'mov rcx,rbp',
0x18333e7aa:'call 00000001806BFD70h',0x18333e7af:'int3',0x18333e7b0:'call 00000001806C0390h',0x18333e7b5:'int3'},
66501:{
0x18333e7d6:'mov rbx,rdx',0x18333e7d9:'mov rsi,rcx',0x18333e7f1:'mov rax,[rbx+18h]',
0x18333e7f5:'mov r8,[rax+0C0h]',0x18333e7fc:'mov rdi,[r8]',0x18333e88e:'mov rax,[rdi+0B8h]',
0x18333e89c:'mov rdi,[rax]',0x18333e8af:'xor r8d,r8d',0x18333e8b2:'mov rdx,rsi',
0x18333e8b5:'mov rcx,rdi',0x18333e8b8:'call 00000001831721F0h',0x18333e8bf:'je 000000018333E967h',
0x18333e95b:'mov rax,[rbx+0B8h]',0x18333e962:'xor ecx,ecx',0x18333e964:'mov [rax],rcx',
0x18333e967:'mov rbx,[rsp+30h]',0x18333e976:'ret'},
47948:{
0x186743bb0:'test cl,cl',0x186743bb2:'jne short 0000000186743BB5h',0x186743bb4:'ret',
0x186743bba:'lea rcx,[1887B5780h]',0x186743bc6:'mov rdi,rdx',0x186743bc9:'call 00000001806C01E0h',
0x186743bce:'mov rcx,rax',0x186743bd1:'call 00000001806C0340h',0x186743bd6:'xor r8d,r8d',
0x186743bd9:'mov rdx,rdi',0x186743bdc:'mov rcx,rax',0x186743bdf:'mov rbx,rax',
0x186743be2:'call 00000001840A05E0h',0x186743be7:'lea rcx,[1887119F0h]',
0x186743bee:'call 00000001806C01E0h',0x186743bf3:'mov rdx,rax',0x186743bf6:'mov rcx,rbx',
0x186743bf9:'call 00000001806C0360h',0x186743bfe:'mov rbx,[rsp+30h]'}
}
ALLOWED_CALLS={
66500:{0x1806c01e0,0x1806846d0,0x180640f10,0x183172430,0x183d98380,0x18476bde0,0x183ebff40,0x183eba740,0x183170670,0x1806bfd40,0x1806bfd70,0x1806c0390},
66501:{0x1806c01e0,0x1806846d0,0x180640f10,0x1831721f0},
47948:{0x1806c01e0,0x1806c0340,0x1840a05e0,0x1806c0360}}

def shape(row,source):
    idx=row['native_method_index'];ins=row['instructions'];byip={i['ip']:i for i in ins};lo=int(source['native_pointer'],16);code=bytes.fromhex(source['runtime_function']['bytes']);hi=lo+len(code)
    need(len(byip)==len(ins) and ins[0]['ip']==lo,'Unique contiguous original instruction positions')
    pos=lo
    for i in ins:need(i['ip']==pos and i['length']>0,'No skipped decoded native byte');pos+=i['length']
    need(pos==hi,'Every original input byte is decoded')
    for ip,text in CONTRACTS[idx].items():need(ip in byip and byip[ip]['text']==text,'Original typed effect contract changed at '+hex(ip))
    terminal_calls={0x1806bfd70,0x1806c0390,0x1806c0360};external_tails={0x1806bfd30};edges={};calltargets=set();indirect=[]
    for i in ins:
        ip=i['ip'];nxt=ip+i['length'];flow=i['flow'];target=i['operands'][0]['target'] if i['operands'] else 0
        if flow=='Call':need(target in ALLOWED_CALLS[idx],'Unexpected direct original callee');calltargets.add(target);succ=[] if target in terminal_calls else [nxt]
        elif flow=='IndirectCall':
            need(idx==66500 and ip==0x18333e581,'Only original Type.ToString virtual call accepted');indirect.append(ip);succ=[nxt]
        elif flow=='ConditionalBranch':need(target in byip,'All original conditional edges close in input');succ=[target,nxt]
        elif flow=='UnconditionalBranch':
            need(target in byip or target in external_tails,'Only known original return tail allowed');succ=[target] if target in byip else []
        elif flow in ('Return','Interrupt'):succ=[]
        else:need(flow=='Next','No unclassified original native flow');succ=[nxt]
        edges[ip]=succ
    seen=set();queue=[lo]
    while queue:
        ip=queue.pop();need(ip in byip,'Reachable original CFG falls outside input')
        if ip in seen:continue
        seen.add(ip);queue.extend(edges[ip])
    if idx==47948:need(set(byip)-seen=={0x186743bfe},'Only unreachable epilogue fragment after original noreturn throw is permitted')
    elif idx==66500:need(all(byip[ip]['mnemonic']=='Int3' for ip in set(byip)-seen),'Only INT3 failure separators/alignment may be unreachable')
    else:need(seen==set(byip),'Entire singleton cleanup instruction stream must close')
    return {'all_original_bytes_decoded':len(code),'all_reachable_edges_closed':True,'instruction_count':len(ins),'reachable_instruction_count':len(seen),'unreachable_instruction_addresses':[hex(ip) for ip in sorted(set(byip)-seen)],'direct_calls':[hex(v) for v in sorted(calltargets)],'typed_indirect_ToString_sites':[hex(v) for v in indirect],'all_semantic_contracts_checked':len(CONTRACTS[idx]),'compiler_support_tail':'GC write barrier return tail' if idx==66500 else None}

def main():
    receipt=DECODE/'run-report.json';need(sha(receipt)==RECEIPT_SHA,'Actual Root decode receipt changed');done=json.loads(receipt.read_bytes());need(done['status']=='decoded_original_entry_windows_not_whole_method_recovery','Successful inert decoder required');output=Path(done['output']['path']);need(pin(output)==done['output'],'Actual decoder bytes changed')
    sources=json.loads((DECODE/'three-next-original-windows.json').read_bytes())['methods'];decoded=[json.loads(s) for s in output.read_text().splitlines()];need(len(decoded)==len(sources)==3,'Exact original three members')
    byindex={s['original']['index']:s for s in sources};shapes={r['native_method_index']:shape(r,byindex[r['native_method_index']]) for r in decoded}
    original=[ROOT/'CodeSource'/r for r in SOURCE_PINS]
    for path in original:need(sha(path)==SOURCE_PINS[path.relative_to(ROOT/'CodeSource').as_posix()],'Pinned original source changed')
    with original[0].open('rb') as bf,original[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
        v=ExternMetadata(b,m)
        for source in sources:
            code=bytes.fromhex(source['runtime_function']['bytes']);raw=v.raw(int(source['native_pointer'],16),len(code));need(bytes(b[raw:raw+len(code)])==code,'Fresh complete original native span changed');need(v.method_info(source['original']['index'])=={k:val for k,val in source['original'].items() if k!='declaring_type'},'Original method metadata changed')
        td=v.row('typeDefinitions',9243,88);need(v.full_name(9243)=='SingletonMonoBehaviour`1','Exact generic owner');first=v.i32(m,td+32);count=v.u16(m,td+68);need(count==1,'One original singleton field')
        raw=v.row('fields',first,12);name,nt,token=struct.unpack_from('<iiI',m,raw);field={'index':first,'name':v.string(name),'type':v.typename(v.native_type(nt)),'native_type':v.native_type(nt),'token':hex(token)};need(field['name']=='CMDPMJBEBAB' and field['type']=='T' and field['native_type']['attributes']==17,'Exact private static original instance field')
        gp=v.row('genericParameters',4266,16);owner,name,start,count,num,flags=struct.unpack_from('<iiHHHH',m,gp);constraints=[v.typename(v.native_type(v.i32(m,v.row('genericParameterConstraints',start+i,4)))) for i in range(count)];need(owner==2686 and v.string(name)=='T' and num==0 and flags==0 and constraints==['SingletonMonoBehaviour`1<T>'],'Original self-referential generic constraint')
        context=rgctx(v,'RecRoom.Datastructures.Singletons.Runtime.dll',0x02000006);need([r.get('type') for r in context['rows']]==['SingletonMonoBehaviour`1<T>',None,'T','T'],'Exact original static owner/cast/typeof RGCTX slots')
        uses={hex(a):v.usage(a) for a in [0x1887b5780,0x1887119f0,0x1887caa40,0x188735040,0x188761d40,0x18880d198]}
        need(uses['0x1887b5780']['type']=='System.InvalidOperationException' and uses['0x1887119f0']['method']['index']==47948,'Exact original disposed exception/method context')
        strings={k:literal(v,uses[k]['index']) for k in ['0x188761d40','0x18880d198']};need([strings[k]['utf8'] for k in strings]==['Created more than one singleton of ','! Destroying the old one.'],'Exact original warning strings')
        typed_targets={
            0x1840a05e0:('System.InvalidOperationException','.ctor',['System.String'],'System.Void'),
            0x1831721f0:('UnityEngine.Object','op_Equality',['UnityEngine.Object','UnityEngine.Object'],'System.Boolean'),
            0x183172430:('UnityEngine.Object','op_Inequality',['UnityEngine.Object','UnityEngine.Object'],'System.Boolean'),
            0x183d98380:('System.Type','GetTypeFromHandle',['System.RuntimeTypeHandle'],'System.Type'),
            0x18476bde0:('System.String','Concat',['System.String','System.String','System.String'],'System.String'),
            0x183ebff40:('UnityEngine.Debug','LogWarning',['System.Object'],'System.Void'),
            0x183eba740:('UnityEngine.Component','get_gameObject',[],'UnityEngine.GameObject'),
            0x183170670:('UnityEngine.Object','Destroy',['UnityEngine.Object'],'System.Void')}
        calls,gaps=aliases(v,set(typed_targets))
        for address,expected in typed_targets.items():
            found=calls[hex(address)];need(len(found)==1,'Unique original typed direct target '+hex(address));method=found[0]
            actual=(method['owner'],method['name'],[p['type'] for p in method['parameters']],method['return'])
            need(actual==expected and v.method_pointer(method)==address,'Exact original method token/registration/signature join '+hex(address))
        to_string=v.method_info(3679);slot=v.u16(m,v.row('methods',3679,32)+28);need(to_string['owner']=='System.Type' and to_string['name']=='ToString' and to_string['return']=='System.String' and not to_string['parameters'] and slot==3 and 0x138+slot*16==0x168,'Exact original Type virtual slot3')
        need('new("vtable", 0x138, typeof(IntPtr), false)' in VLAYOUT.read_text(),'Pinned local IL2CPP64 vtable-offset witness')
        # A registered object-shared instantiation is retained explicitly. It is
        # not falsely labeled a separately registered MFEN instantiation.
        lookup=[]
        for spec in range(v.method_spec_count):
            mi,ci,gi=struct.unpack_from('<iii',b,v.method_specs+spec*12)
            if mi==47883:lookup.append({'method_spec':spec,'class_arguments':[v.typename(t) for t in v.inst(ci)],'method_arguments':[v.typename(t) for t in v.inst(gi)]})
        registrations=v.generic_targets({r['method_spec'] for r in lookup})
        for r in lookup:r['registrations']=registrations[r['method_spec']]
    controls=[]
    for idx,ip in [(66500,0x18333e52e),(66500,0x18333e54d),(66500,0x18333e6a2),(66500,0x18333e729),(66500,0x18333e75d),(66500,0x18333e788),(66501,0x18333e8b8),(66501,0x18333e8bf),(66501,0x18333e964),(47948,0x186743bb2),(47948,0x186743bd9),(47948,0x186743be2)]:
        changed=copy.deepcopy(next(r for r in decoded if r['native_method_index']==idx));ins=next(i for i in changed['instructions'] if i['ip']==ip);ins['text']='wrong semantic effect'
        try:shape(changed,byindex[idx])
        except ValueError:controls.append({'native_method_index':idx,'site':hex(ip),'rejected':True})
        else:raise ValueError('Changed original semantic instruction accepted')
    out=SLICE/('SingletonDisposedMembers-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    texts={'SingletonMonoBehaviour.members.cs':'''// Replacement members inside the original SingletonMonoBehaviour<T> only.
// Keep original private static CMDPMJBEBAB and constraint T : SingletonMonoBehaviour<T>.
protected virtual void Awake()
{
    if (CMDPMJBEBAB != null)
    {
        UnityEngine.Debug.LogWarning(string.Concat("Created more than one singleton of ", typeof(T).ToString(), "! Destroying the old one."));
        UnityEngine.Object.Destroy(CMDPMJBEBAB.gameObject);
    }
    CMDPMJBEBAB = (T)this;
}

protected virtual void OnDestroy()
{
    if (CMDPMJBEBAB == this)
        CMDPMJBEBAB = null;
}
''','MKECFLEMHEL.disposed.member.cs':'''// Replacement member within the existing original MKECFLEMHEL only.
public static void GFKAFPHLKMJ(bool NHJPBHJLFOD, string OFCFPGACNJB)
{
    if (NHJPBHJLFOD)
        throw new System.InvalidOperationException(OFCFPGACNJB);
}
'''}
    candidates=[]
    for name,text in texts.items():p=out/name;p.write_text(text,encoding='utf-8',newline='\n');candidates.append(pin(p))
    test='''Root-only next verification (no Main application yet):

1. Merge replacement spans into the exact full original metadata owners outside RR23; retain the original generic constraint, field visibility/static storage, virtual flags and all unrelated members. Compile the entire affected assemblies with genuine same-version Unity references. Verify exact changed methods via metadata, not current numeric tokens guessed from native tokens.
2. Controlled Singleton subject uses the exact candidate bodies and test-only Object/MonoBehaviour/Debug effects: absent previous instance; existing previous instance; warning mutates the stored instance; warning throws; Destroy throws; valid checked cast; invalid T cast; Unity destroyed/fake-null semantics; cleanup equality true/false and equality throwing. Check effect order, field reread after LogWarning, previous GameObject destruction, no invented hook, and no store if an earlier effect throws. This is a model effect test, not Unity lifecycle proof.
3. Controlled disposed guard: false returns for both null/non-null message; true throws exactly InvalidOperationException preserving message, with no fallback object or logging.
4. Compile and inspect original full getters/constructors/resolver independently from later runtime provider closure. Their application may be separately reviewed after tests; higher-level Awake activation remains held until required runtime services exist. Do not claim working login/dorm from these members.
5. GameRoot collection cleanup is not included: original native finally/unwind linkage must be proved before applying a source foreach/finally replacement. Keep current Main and metas unchanged throughout tests.
'''
    plan=out/'ROOT_TEST_PLAN.txt';plan.write_text(test,encoding='utf-8',newline='\n')
    report={'schema':'original-Singleton-and-disposed-three-member-native-CFG-candidates/v1','status':'three_original_typed_members_staged_actual_CSharp_binding_and_effects_pending','members':candidates,'original_methods':[r['original'] for r in sources],'native_spans':[{'method':r['original']['index'],'pointer':r['native_pointer'],'bytes':len(bytes.fromhex(r['runtime_function']['bytes'])),'sha256':hashlib.sha256(bytes.fromhex(r['runtime_function']['bytes'])).hexdigest()} for r in sources],'exact_shapes':shapes,'original_private_static_field':field,'original_generic_constraint':constraints,'original_rgctx':context,'original_warning_literals':strings,'additional_metadata_uses':uses,'unique_raw_backed_callees':calls,'unbacked_alias_inventory_tables_not_assumed_absent':gaps,'Type_ToString_virtual_witness':{'method':to_string,'slot':slot,'native_vtable_base':0x138,'native_function_offset':0x168,'native_MethodInfo_offset':0x170,'local_layout_source':pin(VLAYOUT)},'framework_cast_lowering':{'isinst_support_address':'0x1806bfd40','failed_cast_support_address':'0x1806bfd70','pattern':'null source is preserved; nonnull source uses RGCTX class T; null isinst result calls failure support then INT3; successful result stored into original static T field','CSharp_mapping':'checked cast (T)this; no helper implementation copied into game','separate_native_framework_helper_implementation_reconstructed':False},'disposed_entry_region_trailing_epilogue_note':'The 83-byte saved entry includes one unreachable register restore after the original noreturn throw. No reachable path or exception payload is guessed from that dead fragment.','negative_controls':controls,'Root_actual_decode_receipt':pin(receipt),'Root_actual_decode_output':pin(output),'input':pin(DECODE/'three-next-original-windows.json'),'original_source_inputs':[pin(p) for p in original],'producer':pin(Path(__file__)),'Root_test_plan':pin(plan),'next_original_lookup_method':{'definition':'MNALHHOLFGL.NGBMOPMLJCM<TType>(CPAMAFPANDM,out TType)','native_method_index':47883,'original_token':'0x0600001e','registered_instantiations':lookup,'separately_registered_MFEN_instantiation_found':False,'object_shared_body_pointer':'0x1813b9b80','no_unproved_concrete_MFEN_pointer_invented':True},'GameRoot_collection_cleanup_staged':False,'independent_lower_members_may_be_reviewed_for_application_after_binding_effect_tests':True,'safe_to_activate_higher_bootstrap':False,'CSharp_compiler_Unity_game_network_executed':False,'Main_modified':False}
    rp=out/'report.json';save(rp,report);print(json.dumps({'status':report['status'],'report':pin(rp),'candidates':candidates,'negative_controls':len(controls)}))
if __name__=='__main__':main()
