"""Close two original generic Singleton accessors; preserve proven empty/forward ctor.

Pure native/CLI parsing. No compiler, target code, Unity, player or network runs.
"""
from pathlib import Path
import copy,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata
from resolve_startup_foundation_native_joins import rgctx
from prove_recroom_ondestroy_native_cfg import aliases
from prepare_startup_foundation_slice import SOURCE_PINS
from audit_boot_candidate_dependency_closure import module_methods
from audit_cli_marshal_contracts import Cli
from audit_hashable_scoped_vtable import Read
SLICE=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207'
DECODE=SLICE/'RootDecodePlan-20261023T073503Z-73b93411'
DECODE_SHA='4325137d3b4ce1715af2f703325a3ac1470122c6d30007eaf429e909af4faa44'
BASE=SLICE/'SingletonDisposedMembers-20261023T065855Z-c81ffded/report.json'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True)
    with p.open('rb') as f:s=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':s}
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
CONTRACT={
66498:{0x1806f623a:'mov rbx,[rcx+18h]',0x1806f623e:'mov rdi,rcx',0x1806f6252:'mov rax,[rbx+0C0h]',0x1806f6259:'mov rbx,[rax]',0x1806f62e7:'mov rbx,[rdi+18h]',0x1806f62fc:'mov rax,[rbx+0C0h]',0x1806f6303:'mov rbx,[rax]',0x1806f6317:'mov rax,[rbx+0B8h]',0x1806f6323:'mov rax,[rax]',0x1806f632b:'ret'},
66499:{0x18333e996:'mov rbx,rcx',0x18333e99b:'lea rcx,[1887F13E0h]',0x18333e9ae:'mov rdi,[rbx+18h]',0x18333e9c3:'mov rax,[rdi+0C0h]',0x18333e9ca:'mov rdi,[rax]',0x18333ea58:'mov rsi,[rbx+18h]',0x18333ea85:'mov rax,[rdi+0C0h]',0x18333ea8c:'mov rcx,[rsi+0C0h]',0x18333ea93:'mov rdx,[rax+8]',0x18333ea97:'mov rcx,[rcx+8]',0x18333ea9b:'call qword ptr [rdx]',0x18333eaa4:'mov rbx,rax',0x18333eabe:'xor r8d,r8d',0x18333eac1:'xor edx,edx',0x18333eac3:'mov rcx,rbx',0x18333ead5:'jmp 0000000183172430h'},
66502:{0x180d708b0:'sub rsp,28h',0x180d708b4:'test rcx,rcx',0x180d708b7:'je short 0000000180D708C4h',0x180d708b9:'xor edx,edx',0x180d708bb:'add rsp,28h',0x180d708bf:'jmp 000000018316F0F0h',0x180d708c4:'call 00000001806C0390h',0x180d708c9:'int3'}}
def shape(row,source):
    mi=row['native_method_index'];ins=row['instructions'];byip={x['ip']:x for x in ins};lo=int(source['native_pointer'],16);end=lo+len(bytes.fromhex(source['runtime_function']['bytes']));at=lo
    for i in ins:need(i['ip']==at and i['length']>0,'Contiguous decoded original native bytes');at+=i['length']
    need(at==end and len(byip)==len(ins),'Exact complete input byte coverage')
    for ip,text in CONTRACT[mi].items():need(byip[ip]['text']==text,'Exact original accessor/ctor effect changed at '+hex(ip))
    allowed={0x1806846d0,0x180640f10} if mi==66498 else {0x1806c01e0,0x1806846d0,0x180640f10} if mi==66499 else {0x1806c0390}
    edges={};direct=set();indirect=[]
    for i in ins:
        ip=i['ip'];nxt=ip+i['length'];target=i['operands'][0]['target'] if i['operands'] else 0;flow=i['flow']
        if flow=='Call':need(target in allowed,'No unbound direct application callee');direct.add(target);succ=[] if target==0x1806c0390 else [nxt]
        elif flow=='IndirectCall':need(mi==66499 and ip==0x18333ea9b,'Only exact original Instance getter RGCTX call');indirect.append(ip);succ=[nxt]
        elif flow=='ConditionalBranch':need(target in byip,'Complete internal conditional CFG');succ=[target,nxt]
        elif flow=='UnconditionalBranch':need((mi==66499 and target==0x183172430)or(mi==66502 and target==0x18316f0f0),'Exact typed framework tail only');succ=[]
        elif flow in ('Return','Interrupt'):succ=[]
        else:need(flow=='Next','No unclassified original native flow');succ=[nxt]
        edges[ip]=succ
    seen=set();queue=[lo]
    while queue:
        ip=queue.pop();need(ip in byip,'No reachable fallthrough outside captured region')
        if ip in seen:continue
        seen.add(ip);queue.extend(edges[ip])
    need(all(byip[ip]['mnemonic']=='Int3' for ip in set(byip)-seen),'Only noreturn separator may be unreachable')
    return {'all_native_bytes':end-lo,'all_reachable_CFG_edges_closed':True,'instruction_count':len(ins),'exact_effect_contracts':len(CONTRACT[mi]),'direct_support_calls':[hex(x) for x in sorted(direct)],'typed_Instance_rgctx_call_sites':[hex(x) for x in indirect]}
def main():
    need(pin(DECODE/'run-report.json')['sha256']==DECODE_SHA,'Root actual tiny decode proof');receipt=json.loads((DECODE/'run-report.json').read_bytes());need(receipt['status']=='decoded_original_entry_windows_not_whole_method_recovery' and pin(receipt['output']['path'])==receipt['output'],'Exact successful decoder output')
    need(pin(BASE)['sha256']=='a073ef5183c9d554509ae16689595bcb7981627e4328a50c7682d4c5c131b48a','Exact original Singleton field/type proof');base=json.loads(BASE.read_bytes())
    rows=json.loads((DECODE/'three-original-accessor-windows.json').read_bytes())['methods'];decoded=[json.loads(x) for x in Path(receipt['output']['path']).read_text().splitlines()];byindex={r['original']['index']:r for r in rows};need(set(byindex)=={66498,66499,66502},'Exact two getters and constructor')
    shapes={r['native_method_index']:shape(r,byindex[r['native_method_index']]) for r in decoded};sources=[ROOT/'CodeSource'/s for s in SOURCE_PINS]
    for p in sources:need(pin(p)['sha256']==SOURCE_PINS[p.relative_to(ROOT/'CodeSource').as_posix()],'Fresh original source SHA')
    with sources[0].open('rb') as bf,sources[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
        v=ExternMetadata(b,m)
        for r in rows:
            code=bytes.fromhex(r['runtime_function']['bytes']);at=v.raw(int(r['native_pointer'],16),len(code));need(bytes(b[at:at+len(code)])==code and v.method_info(r['original']['index'])==r['original'],'Fresh exact original method/bytes')
        context=rgctx(v,'RecRoom.Datastructures.Singletons.Runtime.dll',0x02000006);need(context==base['original_rgctx'] and context['rows'][0]['type']=='SingletonMonoBehaviour`1<T>' and context['rows'][1]['method']['index']==66498 and context['rows'][1]['class_arguments']==['T'],'Exact self-static-field / getter RGCTX slots0/1')
        use=v.usage(0x1887f13e0);need(use['type']=='UnityEngine.Object','Original actual Unity operator class metadata')
        calls,gaps=aliases(v,{0x183172430,0x18316f0f0});need(len(calls['0x183172430'])==1 and calls['0x183172430'][0]['owner']=='UnityEngine.Object' and calls['0x183172430'][0]['name']=='op_Inequality' and [p['type'] for p in calls['0x183172430'][0]['parameters']]==['UnityEngine.Object','UnityEngine.Object'],'Actual original Unity null comparison')
        # IL2CPP shares this native implementation among several Unity engine
        # constructors. Select the typed base constructor from original owner
        # inheritance/signature/registration, not pointer uniqueness.
        original_owner=v.type_info(9243);need(original_owner['name']=='SingletonMonoBehaviour`1' and original_owner['parent_type']=='UnityEngine.MonoBehaviour','Original singleton immediate base identity')
        base_ctors=[x for x in calls['0x18316f0f0'] if x['index']==34184 and x['owner']=='UnityEngine.MonoBehaviour' and x['name']=='.ctor' and x['image']=='UnityEngine.CoreModule.dll' and not x['parameters'] and x['return']=='System.Void']
        need(len(base_ctors)==1 and v.method_pointer(base_ctors[0])==0x18316f0f0,'Exact original genuine MonoBehaviour base constructor among retained shared aliases')
        mi,ci,gi=struct.unpack_from('<iii',b,v.method_specs+306311*12);need(mi==66503 and [v.typename(t) for t in v.inst(ci)]==['System.Object'] and not v.inst(gi),'Exact canonical shared static constructor identity');cctor=v.method_info(mi);targets=v.generic_targets({306311})[306311];need(len(targets)==1 and targets[0]['pointer']=='0x1806f84d0','Original empty static constructor registration');at=v.raw(0x1806f84d0,3);cctor_bytes=bytes(b[at:at+3]);need(cctor_bytes==bytes.fromhex('c20000'),'Exact native empty static constructor RET imm16=0')
    controls=[]
    for mi,ip in [(66498,0x1806f623a),(66498,0x1806f6259),(66498,0x1806f6317),(66498,0x1806f6323),(66499,0x18333ea93),(66499,0x18333ea97),(66499,0x18333ead5),(66502,0x180d708bf)]:
        changed=copy.deepcopy(next(x for x in decoded if x['native_method_index']==mi));next(x for x in changed['instructions'] if x['ip']==ip)['text']='wrong effect'
        try:shape(changed,byindex[mi])
        except ValueError:controls.append({'method':mi,'site':hex(ip),'rejected':True})
        else:raise ValueError('Changed semantic contract accepted')
    current=WS/'RR23/Assets/Plugins/RecRoom.Datastructures.Singletons.Runtime.dll';selectors=[{'owner':'SingletonMonoBehaviour`1','name':name,'parameters':0} for name in ['get_Instance','get_IsInitialized','.ctor','.cctor']];current_methods=module_methods(current,selectors);cli_byname={r['name']:r for r in current_methods}
    need(cli_byname['get_Instance']['IL_bytes'].startswith('1200fe15') and cli_byname['get_Instance']['IL_bytes'].endswith('062a') and cli_byname['get_IsInitialized']['IL_bytes']=='162a' and cli_byname['.cctor']['IL_bytes']=='2a','Current missing getters/proved empty static ctor classified exactly')
    ctor=bytes.fromhex(cli_byname['.ctor']['IL_bytes']);need(len(ctor)==7 and ctor[0:2]==bytes.fromhex('0228') and ctor[-1]==0x2a,'Current ctor only forwards this to base')
    with current.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=Cli(b);reader=Read(c);token=struct.unpack_from('<I',ctor,2)[0];need(token>>24==10,'Current scoped MemberRef base ctor');at=c.row(10,token&0xffffff);parent=c.value(at,c.coded(3,[2,1,26,6,27]));name=c.string(c.value(at+c.coded(3,[2,1,26,6,27]),c.strw));sig=c.blob(c.value(at+c.coded(3,[2,1,26,6,27])+c.strw,c.blobw));need(parent&7==1 and name=='.ctor' and sig.hex()=='200001','Current ctor exact instance void/noargs reference');owner=reader.typeref(parent>>3);need(owner.endswith(']UnityEngine.MonoBehaviour') and owner.startswith('[UnityEngine.CoreModule,'),'Current ctor genuine Unity scoped owner')
    text='''// Replacement properties inside the original SingletonMonoBehaviour<T> only.
// Preserve its original private static T CMDPMJBEBAB, self constraint and metadata.
public static T Instance
{
    get { return CMDPMJBEBAB; }
}
public static bool IsInitialized
{
    get { return Instance != null; }
}
'''
    fixed=HERE/'RecoveredSingletonAccessorMembers.cs'
    if fixed.exists():need(fixed.read_text()==text,'Never overwrite an existing reviewed member source')
    else:
        with fixed.open('x',encoding='utf-8',newline='\n') as f:f.write(text)
    out=SLICE/('AccessorMembers-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-Singleton-two-accessors-complete-CFG-and-preserved-ctors/v1','status':'two_missing_original_getter_bodies_staged_CSharp_binding_effects_import_pending','original_methods':[r['original'] for r in rows],'exact_shapes':shapes,'original_self_rgctx':context,'original_private_static_field':base['original_private_static_field'],'typed_framework_targets':calls,'unbacked_alias_inventory_tables_not_assumed_absent':gaps,'constructor_current_body_already_native-equivalent':{'current_IL':cli_byname['.ctor']['IL_bytes'],'scoped_base_constructor':owner,'replacement_needed':False},'static_ctor_native_proven_empty':{'original':cctor,'canonical_original_method_spec':306311,'class_arguments':['System.Object'],'registration':targets[0],'original_bytes':cctor_bytes.hex(),'native_instruction':'ret 0 (C2 immediate16=0; no stack arguments removed)','current_IL':cli_byname['.cctor']['IL_bytes'],'replacement_needed':False,'not_falsely_labeled_separate_GameRoot_cctor_registration':True},'current_CLI_methods':current_methods,'current_plugin':pin(current),'current_meta':pin(Path(str(current)+'.meta')),'candidate_members':pin(fixed),'Root_decode_receipt':pin(DECODE/'run-report.json'),'Root_decoded_output':receipt['output'],'original_sources':[pin(p) for p in sources],'negative_controls':controls,'Main_modified':False,'compiler_Unity_game_network_executed':False,'higher_bootstrap_activated':False,'working_boot_or_login_claimed':False}
    report['constructor_shared_native_target_typing']={'original_owner':original_owner,'selected_immediate_base_constructor':base_ctors[0],'all_shared_pointer_aliases_preserved':True,'raw_pointer_uniqueness_not_claimed':True}
    path=out/'report.json';save(path,report);print(json.dumps({'report':pin(path),'candidate':pin(fixed),'negative_controls':len(controls),'constructors_need_change':False}))
if __name__=='__main__':main()
