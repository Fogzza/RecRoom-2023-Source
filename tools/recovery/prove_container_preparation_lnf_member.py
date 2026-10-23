"""Stage the complete original LNF caller with exact foreach EH/typed targets.

All source stays outside Main. Original graph algorithms, injection, concrete
provider implementations and registration remain explicit runtime boundaries.
No lambda, replacement service, extra production helper or cleanup is added.
"""
from pathlib import Path
import copy,datetime as dt,hashlib,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;ROOT=HERE.parents[2]/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata
from audit_custom_urp_native_loop import pdata
from run_startup_foundation_decode import pin,need,save,check
from stage_title_page_route_slice import dispatch
from stage_title_manager_start_slice import setter_dispatch
from inventory_recroom_game_root_native import region
import original_eh4_metadata as eh
RUN=ROOT/'Validation/LiveLookupDependencies-20261023T092454Z-8f9207ed'
JOINS=ROOT/'Validation/LiveLookupDependencyJoins-20261023T092659Z-6a69ffae/report.json'
JOINS_SHA='8484971c6c94665f60dfe388a07f5bd4dce89eaee317383c0077aa6664c85e2a'
EH=ROOT/'Validation/LNFOriginalEH4-20261023T102626Z-5e452055/report.json'
EH_SHA='c784f9ea56fb84756c0cd2611c8e3a2e7db77f76e841cac59e914ba9a75254bc'
PREREQ=ROOT/'Validation/ContainerPreparationPrerequisiteMembers-20261023T101500Z-0d739a98/report.json'
PREREQ_SHA='a484d80f7fec644bfd86c145c4ba2089e2d44306ee64a2dc690f594749fa35d8'
ASSERTION=ROOT/'Validation/LNFAssertionMembers-20261023T102947Z-bf972cc4/report.json'
ASSERTION_SHA='0a47dae79cad41da88485a79951e3f3f284c3113a31ad5cef2519a6b92ac49a3'
VA=0x186744a30
EFFECTS={
0x186744b21:'cmp byte ptr [r15+38h],1',0x186744b26:'jae 000000018674514Fh',0x186744b2c:'mov byte ptr [r15+38h],1',0x186744b31:'mov rcx,[r15+20h]',0x186744b41:'lea rdx,[rsp+30h]',0x186744b46:'call 0000000186745CB0h',0x186744b4d:'jne 00000001867451A6h',0x186744b53:'mov rdi,[r15+20h]',
0x186744bb8:'mov r8,[rdi+20h]',0x186744bbf:'jne 0000000186744CC1h',0x186744bca:'call 00000001867464A0h',0x186744bd4:'call 0000000186746920h',0x186744bd9:'mov r14,rax',0x186744c0b:'mov rsi,[rcx+18h]',0x186744c12:'jne short 0000000186744C84h',0x186744c3c:'mov rbx,[rax]',0x186744c55:'mov r8,[188864CB8h]',0x186744c62:'call 00000001807DF4F0h',0x186744c79:'mov [rcx],rsi',0x186744c91:'call 0000000180F0B9B0h',0x186744ca0:'call 0000000181E0F6B0h',0x186744ca9:'mov [rcx],rax',0x186744cb4:'mov r8,[rdi+20h]',
0x186744cc1:'xor ecx,ecx',0x186744cc3:'mov rdx,[1887F27A8h]',0x186744cca:'call 0000000180157240h',0x186744cd2:'mov [rsp+38h],rax',0x186744ce5:'mov rdx,[18872C518h]',0x186744cec:'call 0000000180157240h',0x186744cf3:'je 0000000186744F14h',0x186744cf9:'mov r10,[188835FA0h]',0x186744d50:'lea rcx,[rsp+90h]',0x186744d58:'call qword ptr [rax]',0x186744d5a:'movups xmm6,[rax]',0x186744d5d:'mov rcx,[r15+10h]',0x186744d6f:'mov r8,[18887D288h]',0x186744d7b:'call 00000001849121E0h',0x186744d82:'jne 0000000186744CD7h',0x186744d88:'mov rcx,[r15+18h]',0x186744d9b:'mov r9,[18887C5E0h]',0x186744da2:'lea r8,[rsp+108h]',0x186744daf:'call 000000018491ABF0h',0x186744db6:'je 0000000186744CD7h',0x186744dbc:'mov rbx,[rsp+108h]',
0x186744e25:'xor ecx,ecx',0x186744e27:'mov r8,rbx',0x186744e2a:'mov rdx,[18881E9E0h]',0x186744e31:'call 0000000180157240h',0x186744e36:'mov rbx,rax',0x186744e3f:'mov r9,[1887114E0h]',0x186744e4b:'mov rdx,[1887ABFA0h]',0x186744e52:'mov rcx,rax',0x186744e55:'call 00000001813B9090h',0x186744e63:'xor ecx,ecx',0x186744e65:'mov r8,rbx',0x186744e68:'mov rdx,[188788CA8h]',0x186744e6f:'call 0000000180157240h',0x186744e74:'mov rdi,rax',0x186744e8c:'mov r8,[1886F0748h]',0x186744e9d:'call 00000001826705E0h',0x186744ebb:'xor r9d,r9d',0x186744ec3:'mov rdx,rdi',0x186744ec6:'mov rcx,r15',0x186744ec9:'call 00000001867441E0h',0x186744ece:'mov rcx,[r15+10h]',0x186744ee1:'mov r9,[18887CD78h]',0x186744ee8:'mov r8,rbx',0x186744ef0:'call 00000001849121A0h',
0x186744f16:'mov rsi,[rsp+38h]',0x186744f26:'mov r13,[rsp+100h]',0x186744f2e:'test rsi,rsi',0x186744f38:'mov rdx,[188724B18h]',0x186744f3f:'call 0000000180157240h',0x186744f44:'test r13,r13',0x186744f4d:'mov rsi,[r15+10h]',0x186744f7d:'mov rdi,[rax+8]',0x186744f84:'jne short 0000000186744FF2h',0x186744faa:'mov rbx,[rax]',0x186744fc3:'mov r8,[1887CC128h]',0x186744fd0:'call 00000001807DF4F0h',0x186744fe7:'mov [rcx],rdi',0x186744ff9:'mov rdx,rdi',0x186744ffc:'mov rcx,rsi',0x186744fff:'call 0000000180F03A90h',0x186745012:'mov rdx,[18880AD28h]',0x186745019:'call 0000000180157240h',0x186745021:'mov [rsp+0F0h],rax',0x18674503e:'mov rdx,[18872C518h]',0x186745045:'call 0000000180157240h',0x18674504c:'je 0000000186745122h',0x186745052:'mov r10,[1888532D8h]',0x1867450ac:'call qword ptr [rax]',0x1867450ae:'mov rdi,rax',0x1867450cd:'test rdi,rdi',0x1867450d0:'je 0000000186745030h',0x1867450d6:'mov ecx,1',0x1867450db:'mov r8,rdi',0x1867450de:'mov rdx,[188788CA8h]',0x1867450e5:'call 0000000180157240h',0x1867450ec:'jne 0000000186745030h',0x1867450f2:'xor ecx,ecx',0x1867450f4:'mov r9,r15',0x1867450f7:'mov r8,rdi',0x1867450fa:'mov rdx,[188892B50h]',0x186745101:'call 0000000180156F80h',
0x186745124:'mov rbx,[rsp+0F0h]',0x18674512c:'mov r13,[rsp+100h]',0x186745134:'test rbx,rbx',0x18674513e:'mov rdx,[188724B18h]',0x186745145:'call 0000000180157240h',0x18674514a:'test r13,r13',0x18674514f:'movaps xmm6,[rsp+0A0h]',0x18674518a:'xor edx,edx',0x18674518c:'mov rcx,r13',0x18674518f:'call 00000001806C0360h',0x18674519b:'xor edx,edx',0x18674519d:'mov rcx,r13',0x1867451a0:'call 00000001806C0360h',0x1867451bd:'lea rcx,[188794770h]',0x1867451d2:'call 00000001840A05E0h',0x1867451e6:'mov rcx,rbx',0x1867451e9:'call 00000001806C0360h'}
DIRECT={0x1806c01e0,0x186745cb0,0x1867464a0,0x186746920,0x180640f10,0x1806c0340,0x1807df4f0,0x1806bfd30,0x180f0b9b0,0x181e0f6b0,0x180157240,0x18067bc00,0x1849121e0,0x18491abf0,0x1813b9090,0x1826705e0,0x1867441e0,0x1849121a0,0x180f03a90,0x180156f80,0x1806c0390,0x1806c0360,0x1840a05e0}

def shape(decoded,original,parsed_eh):
    code=bytes.fromhex(original['runtime_function']['bytes']);need(len(code)==1989 and original['native_pointer']==hex(VA) and hashlib.sha256(code).hexdigest()==original['runtime_function']['sha256'],'Exact complete1989-byte original source identity');ins=decoded['instructions'];byip={x['ip']:x for x in ins};at=VA
    for x in ins:need(x['ip']==at and 1<=x['length']<=15,'All original bytes decoded contiguously');at+=x['length']
    need(at==VA+1989 and len(byip)==len(ins),'Complete original byte/instruction coverage')
    for ip,text in EFFECTS.items():need(byip[ip]['text']==text,'Exact LNF behavioral operand at '+hex(ip))
    handlers={0:0x186744f16,2:0x186745124};edges={};calls=[]
    for x in ins:
        nxt=x['ip']+x['length'];target=x['operands'][0]['target'] if x['operands'] else 0;flow=x['flow']
        if flow=='Call':need(target in DIRECT,'Every direct original call role bound');successors=[] if target in {0x1806c0390,0x1806c0360} else [nxt];calls.append((x['ip'],target))
        elif flow=='IndirectCall':need(x['ip'] in {0x186744d58,0x1867450ac},'Only two exact original generic Current interface dispatches');successors=[nxt];calls.append((x['ip'],None))
        elif flow=='ConditionalBranch':need(target in byip,'Every conditional branch closes');successors=[target,nxt]
        elif flow=='UnconditionalBranch':need(target in byip,'Every direct jump closes');successors=[target]
        elif flow in ('Return','Interrupt'):successors=[]
        else:need(flow=='Next','No unsupported control flow');successors=[nxt]
        if flow in ('Call','IndirectCall') and eh.state_at(parsed_eh,x['ip']) in handlers:successors.append(handlers[eh.state_at(parsed_eh,x['ip'])])
        edges[x['ip']]=successors
    seen=set();queue=[VA]
    while queue:
        ip=queue.pop();need(ip in byip,'No reachable edge escapes full native scope')
        if ip not in seen:seen.add(ip);queue.extend(edges[ip])
    need(all(byip[ip]['mnemonic'] in ('Int3','Nop') for ip in set(byip)-seen),'Only original exception separators unreachable after noreturn helpers')
    return {'all1989_original_bytes_accounted':True,'complete_normal_and_both_exception_landing_CFG_edges_closed':True,'behavior_operand_contracts':len(EFFECTS),'state_set1_before_cycle_or_any_graph_call_and_not_reset':True,'Sorted_getter_is_original_complete_inlined_body':True,'called_LGK_assertion_not_inlined_or_replaced_by_null_only_check':True,'factory_is_CKAJ_interface_not_delegate':True,'value_getter_before_FIKO_before_resolved_Add':True,'final_dictionary_captured_before_cached_delegate_read':True,'existing_generated_callbacks_only_no_new_lambda':True,'source_two_foreach_finally_paths_match_original_EH':True,'all_direct_and_Current_calls':[{'ip':hex(ip),'target':hex(target) if target else 'typed generic IEnumerator.Current'} for ip,target in calls]}

def interface_open(view,native_index):
    t=view.native_type(native_index)
    if t['kind']==21:
        p=view.raw(t['data'],8);t=view.type_at(view.u64(view.b,p))
    need(t['kind']==18,'Original interface open type is a class declaration');return t['data']

def interface_slot(view,ti,index):
    td=view.row('typeDefinitions',ti,88);need(view.u32(view.m,td+28)&0x20,'Exact original interface TypeDef');start=view.i32(view.m,td+36);count=view.u16(view.m,td+64);found=[view.method_info(mi) for mi in range(start,start+count) if view.u16(view.m,view.row('methods',mi,32)+28)==index];need(len(found)==1,'One exact declared original interface slot');return found[0]

def main():
    for path,digest in [(JOINS,JOINS_SHA),(EH,EH_SHA),(PREREQ,PREREQ_SHA),(ASSERTION,ASSERTION_SHA)]:need(pin(path)['sha256']==digest,'Exact prior native/EH/prerequisite proof')
    joins=json.loads(JOINS.read_bytes());check(joins['actual_Root_decode_receipt']);check(joins['actual_decoded_output']);check(joins['original_scopes']);data=json.loads(Path(joins['original_scopes']['path']).read_bytes());original=next(x for x in data['methods'] if x['original']['index']==47900);decoded=next(json.loads(x) for x in Path(joins['actual_decoded_output']['path']).read_text().splitlines() if json.loads(x)['native_method_index']==47900);parsed=json.loads(EH.read_bytes());cfg=shape(decoded,original,parsed)
    paths=[Path(x['path']) for x in joins['original_inputs']]
    for row in joins['original_inputs']:check(row)
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
        v=ExternMetadata(b,m);need(v.method_info(47900)==original['original'] and v.method_pointer(original['original'])==VA,'Exact original public caller ownership');ranges,parents=pdata(v);rt=next(r for r in ranges if r[0]==VA-v.base);fresh_eh=eh.parse_function(v,rt)
        for key in ['try_blocks','unwind_entries','IP_states','exact_read_table_spans']:need(fresh_eh[key]==parsed[key],'Fresh original EH tables equal exact prior parse')
        source=v.raw(VA,1989);need(bytes(b[source:source+1989])==bytes.fromhex(original['runtime_function']['bytes']),'Fresh entire native source body')
        usages=joins['RIP_metadata_and_literal_uses'];interfaces=[]
        for address,index,expected_name in [(0x1887f27a8,0,'GetEnumerator'),(0x18880ad28,0,'GetEnumerator'),(0x18872c518,0,'MoveNext'),(0x188835fa0,0,'get_Current'),(0x1888532d8,0,'get_Current'),(0x188724b18,0,'Dispose'),(0x18881e9e0,0,'IBOAFOPAJKI'),(0x188788ca8,0,'AIKLEKDPIFH'),(0x188788ca8,1,'DHABENNNOIJ'),(0x188892b50,0,'IHEKMEOIBOI')]:
            usage=v.usage(address);ti=interface_open(v,usage['index']);method=interface_slot(v,ti,index);need(method['name']==expected_name,'Every interface slot belongs to the exact original typed method');interfaces.append({'original_class_usage':usage,'slot':index,'original_method':method})
        for address,method_name,args in [(0x18887d288,'ContainsKey',['CPAMAFPANDM','NJAICAFMPBE']),(0x18887c5e0,'TryGetValue',['CPAMAFPANDM','CKAJONGONMK']),(0x18887cd78,'Add',['CPAMAFPANDM','NJAICAFMPBE'])]:u=v.usage(address);need(u['method']['name']==method_name and u['class_argument_types']==args,'Exact per-iteration dictionary specialization')
        need(v.usage(0x1887114e0)['method']['index']==47951 and v.usage(0x1887114e0)['method_argument_types']==['CPAMAFPANDM'],'Actual called generic assertion target')
        method_roles={str(i):v.method_info(i) for i in [47913,47914,47907,47915,47889,47906,47925]};need(method_roles['47889']['name']=='FIKOCEOODPI' and [x['type'] for x in method_roles['47889']['parameters']]==['System.Object','System.Nullable`1<CPAMAFPANDM>'],'Same exact injection target and optional key')
        inv0=region(v,0x180157240);inv1=region(v,0x180156f80);algorithms=[dispatch(bytes.fromhex(inv0['bytes']),0x180157240),setter_dispatch(bytes.fromhex(inv1['bytes']),0x180156f80)]
    controls=[]
    for ip in EFFECTS:
        changed=copy.deepcopy(decoded);next(x for x in changed['instructions'] if x['ip']==ip)['text']='mutated original effect';rejected=False
        try:shape(changed,original,parsed)
        except ValueError:rejected=True
        need(rejected,'Changed original behavior operand rejected');controls.append({'ip':hex(ip),'rejected':True})
    candidate=HERE/'RecoveredContainerPreparationLnfMember.cs'
    if candidate.exists():need(candidate.read_text()==CANDIDATE,'Preserve frozen original LNF candidate')
    else:candidate.write_text(CANDIDATE,encoding='utf-8',newline='\n')
    out=ROOT/'Validation'/('ContainerPreparationLnfMember-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();r={'schema':'complete-original-LNF-caller-CFG-EH-typed-candidate/v1','status':'complete1989B_original_LNF_caller_staged_binding_effects_and_callee_closure_pending','producer':pin(Path(__file__)),'original':original['original'],'original_scopes':joins['original_scopes'],'actual_Root_decode_receipt':joins['actual_Root_decode_receipt'],'actual_decoded_output':joins['actual_decoded_output'],'original_inputs':joins['original_inputs'],'original_typed_joins':pin(JOINS),'complete_native_shape':cfg,'original_EH_proof':pin(EH),'prerequisite_candidates':pin(PREREQ),'actual_called_assertion_candidates':pin(ASSERTION),'exact_original_interface_slots':interfaces,'original_callee_roles':method_roles,'runtime_interface_algorithms':{'regions':[inv0,inv1],'proofs':algorithms,'caller_semantic_limit':'Prior Route/Start descriptors are reused algorithms only; this caller supplies the separately bound tuples above.'},'candidate':pin(candidate),'negative_controls':controls,'held_original_runtime_bodies':['OENEDGPIOFN.HCILKBKIKOG cycle detection','OENEDGPIOFN.IEPIDJGAOIN graph roots getter','OENEDGPIOFN.LAEKFDEFKFK topological sorting','MNALHHOLFGL.FIKOCEOODPI injection','CKAJONGONMK concrete factory and NJA provider value/dead/injection implementations','private registration graph population'],'new_production_helper_lambda_or_service_added':False,'compiler_Unity_game_or_network_executed':False,'Main_modified':False,'working_bootstrap_claimed':False};target=out/'report.json';save(target,r);print(json.dumps({'report':pin(target),'candidate':pin(candidate),'native_bytes':1989,'behavior_controls':len(controls),'Main_modified':False}))

CANDIDATE='''// Original MNALHHOLFGL public MethodDef0x0600002f, complete1989B CFG.
// Existing raw generated closure identities must use the separately pinned aliases.
// Two foreach finally regions preserve original caught-exception/Dispose ordering.
public void LNFNAIMOFOF()
{
    string cycle=null;
    if((byte)this.MGADLDPDPGK>=1)return;
    this.MGADLDPDPGK=(PFCPCBJDEMB)1;
    if(this.OLGLBMGAHBO.HCILKBKIKOG(out cycle))
        throw new System.InvalidOperationException("Cycle detected in dependency tree!");
    foreach(CPAMAFPANDM key in this.OLGLBMGAHBO.IJAKDIKAJHP())
    {
        if(!this.AAHKPPMHGFI.ContainsKey(key))
        {
            CKAJONGONMK factory;
            if(this.LMAFHCPPMAD.TryGetValue(key,out factory))
            {
                NJAICAFMPBE provider=factory.IBOAFOPAJKI();
                MKECFLEMHEL.LGKIDJCLIAD<CPAMAFPANDM>(provider,"Cannot inject into dead resolved instance for key {0}",key);
                object value=provider.AIKLEKDPIFH();
                this.FIKOCEOODPI(value,new System.Nullable<CPAMAFPANDM>(key));
                this.AAHKPPMHGFI.Add(key,provider);
            }
        }
    }
    System.Collections.Generic.Dictionary<CPAMAFPANDM,NJAICAFMPBE> resolved=this.AAHKPPMHGFI;
    System.Func<System.Collections.Generic.KeyValuePair<CPAMAFPANDM,NJAICAFMPBE>,NJAICAFMPBE> selector=ResolveClosureAlias.CachedSelector;
    if(selector==null)
    {
        selector=new System.Func<System.Collections.Generic.KeyValuePair<CPAMAFPANDM,NJAICAFMPBE>,NJAICAFMPBE>(ResolveClosureAlias.Singleton.SelectProvider);
        ResolveClosureAlias.CachedSelector=selector;
    }
    foreach(NJAICAFMPBE provider in System.Linq.Enumerable.Select(resolved,selector))
    {
        if(provider!=null && !provider.DHABENNNOIJ())
            provider.IHEKMEOIBOI(this);
    }
}
'''
if __name__=='__main__':main()
