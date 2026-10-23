"""Close seven original preparation prerequisites from the existing inert decode.

This performs bounded pure data reads only. Two original closure constructors
are genuinely empty beyond System.Object construction and are retained as such.
Five changed bodies are staged with explicit legal aliases for existing raw
generated types/fields/methods; no new production closure/helper is proposed.
The main LNF body, graph algorithms and injection remain held separately.
"""
from pathlib import Path
import copy, datetime as dt, hashlib, json, mmap, sys, uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata
from audit_custom_urp_native_loop import fields
from audit_cli_marshal_contracts import Cli
from audit_hashable_scoped_vtable import Read
from run_startup_foundation_decode import pin,need,save,check
RUN=ROOT/'Validation/ContainerPreparationPrerequisites-20261023T094821Z-820cb745'
RECEIPT_SHA='8c50d8c5212367468175f945874701a469591f07b6a28ff17fb27eb6dbc45b4b'
JOINS=ROOT/'Validation/LiveLookupDependencyJoins-20261023T092659Z-6a69ffae/report.json'
JOINS_SHA='8484971c6c94665f60dfe388a07f5bd4dce89eaee317383c0077aa6664c85e2a'
SPECS={
47904:(0x186747410,89,'431c0e6d6c0b0a3107530d209cdf32153757b5e7d5e2e6f0035e06abaf71e3ed'),
47905:(0x180703570,16,'f750cbed6591a2031c4f78421469996b02fb108a4a8699baf4af7bb4c1e64e7e'),
47906:(0x1867472b0,57,'10bc88bc0c29d946c07c6cb591e8a70f6e332345c3ba5ec17a45924825e57006'),
47914:(0x1867465d0,383,'e35d2adb1c590daa4c9e7cb90996608232d14078d6214b5eb2deaef05f740ae9'),
47921:(0x1867473b0,89,'32696437758e93ef04b64609e4b97aa6613b7be972cd786483882f95f8305c7e'),
47922:(0x180703570,16,'f750cbed6591a2031c4f78421469996b02fb108a4a8699baf4af7bb4c1e64e7e'),
47925:(0x180ab42e0,31,'7a631fb6f5e04ad47517f6e3c39a36dfad3d9881f5f2793575983e8edc994115')}
EFFECTS={
47904:{0x18674741f:'lea rcx,[18883C9C0h]',0x186747439:'call 00000001806C0340h',0x18674743e:'xor edx,edx',0x186747443:'mov rbx,rax',0x186747446:'call 00000001806F84D0h',0x18674744b:'mov rcx,[18883C9C0h]',0x186747452:'mov rdx,rbx',0x186747455:'mov rcx,[rcx+0B8h]',0x18674745c:'mov [rcx],rbx',0x18674745f:'add rsp,20h',0x186747464:'jmp 00000001806BFD30h'},
47905:{0x180703570:'xor edx,edx',0x180703572:'jmp 00000001806F84D0h'},
47906:{0x1867472c2:'lea rcx,[18888BE78h]',0x1867472ce:'mov rax,[rbx+10h]',0x1867472df:'mov rax,[rdx+10h]'},
47914:{0x186746635:'mov rax,[rbx+20h]',0x186746639:'lea rsi,[rbx+20h]',0x18674663d:'test rax,rax',0x186746640:'jne 0000000186746744h',0x18674664b:'xor edx,edx',0x18674664d:'mov rcx,rbx',0x186746655:'call 00000001867464A0h',0x18674665a:'xor edx,edx',0x18674665c:'mov rcx,rax',0x18674665f:'call 0000000186746920h',0x18674666b:'mov rbp,rax',0x186746693:'mov rdi,[rax+18h]',0x186746697:'test rdi,rdi',0x18674669a:'jne short 0000000186746708h',0x1867466c7:'mov rbx,[rax]',0x1867466ca:'call 00000001806C0340h',0x1867466cf:'mov r9,[188708DD8h]',0x1867466d6:'mov rdx,rbx',0x1867466d9:'mov r8,[188864CB8h]',0x1867466e0:'mov rcx,rax',0x1867466e3:'mov rdi,rax',0x1867466e6:'call 00000001807DF4F0h',0x1867466fc:'add rcx,18h',0x186746700:'mov [rcx],rdi',0x186746708:'mov r8,[1888185D8h]',0x18674670f:'mov rdx,rdi',0x186746712:'mov rcx,rbp',0x186746715:'call 0000000180F0B9B0h',0x18674671a:'mov rdx,[1888732F8h]',0x186746721:'mov rcx,rax',0x186746724:'call 0000000181E0F6B0h',0x186746729:'mov rdx,rax',0x18674672c:'mov [rsi],rax',0x18674672f:'mov rcx,rsi',0x186746732:'call 00000001806BFD30h',0x186746737:'mov rax,[rsi]'},
47921:{0x1867473bf:'lea rcx,[1886FFF68h]',0x1867473d9:'call 00000001806C0340h',0x1867473de:'xor edx,edx',0x1867473e3:'mov rbx,rax',0x1867473e6:'call 00000001806F84D0h',0x1867473eb:'mov rcx,[1886FFF68h]',0x1867473f2:'mov rdx,rbx',0x1867473f5:'mov rcx,[rcx+0B8h]',0x1867473fc:'mov [rcx],rbx',0x186747404:'jmp 00000001806BFD30h'},
47922:{0x180703570:'xor edx,edx',0x180703572:'jmp 00000001806F84D0h'},
47925:{0x180ab42e4:'test r8,r8',0x180ab42e7:'je short 0000000180AB42F9h',0x180ab42e9:'movups xmm0,[r8+10h]',0x180ab42ee:'mov rax,rcx',0x180ab42f1:'movups [rcx],xmm0',0x180ab42f8:'ret',0x180ab42f9:'call 00000001806C0390h'}}

def shape(row,source):
    mi=row['native_method_index'];va,size,digest=SPECS[mi];code=bytes.fromhex(source['runtime_function']['bytes'])
    need(len(code)==size and hashlib.sha256(code).hexdigest()==digest and row['native_pointer']==va,'Exact complete original prerequisite bytes')
    ins=row['instructions'];at=va;byip={x['ip']:x for x in ins}
    for x in ins:need(x['ip']==at and x['length']>0,'Complete contiguous decode');at+=x['length']
    need(at==va+size and len(byip)==len(ins),'Every captured byte accounted for')
    for ip,text in EFFECTS[mi].items():need(byip[ip]['text']==text,'Exact prerequisite effect at '+hex(ip))
    direct={0x1806c01e0,0x1806c0340,0x1806f84d0,0x180640f10,0x1807df4f0,0x1867464a0,0x186746920,0x180f0b9b0,0x181e0f6b0,0x1806bfd30,0x1806c0390};edges={};tails=[]
    for x in ins:
        nxt=x['ip']+x['length'];target=x['operands'][0]['target'] if x['operands'] else 0
        if x['flow']=='Call':need(target in direct,'No unbound native direct call');nexts=[] if target==0x1806c0390 else [nxt]
        elif x['flow']=='ConditionalBranch':need(target in byip,'Every native conditional branch internal');nexts=[target,nxt]
        elif x['flow']=='UnconditionalBranch':need(target in {0x1806f84d0,0x1806bfd30},'Only original Object constructor or GC barrier tail');nexts=[];tails.append(hex(target))
        elif x['flow'] in ('Return','Interrupt'):nexts=[]
        else:need(x['flow']=='Next','No indirect call, switch or unsupported flow in these seven methods');nexts=[nxt]
        edges[x['ip']]=nexts
    seen=set();queue=[va]
    while queue:
        ip=queue.pop();need(ip in byip,'No reachable edge leaves full original span')
        if ip not in seen:seen.add(ip);queue.extend(edges[ip])
    need(all(byip[ip]['mnemonic']=='Int3' for ip in set(byip)-seen),'Only original observed padding/exception separator unreachable')
    return {'original_bytes':size,'native_sha256':digest,'all_native_CFG_edges_closed':True,'behavior_operand_contracts':len(EFFECTS[mi]),'external_tails':tails,'original_full_instruction_listing':[{'ip':hex(x['ip']),'text':x['text'],'flow':x['flow']} for x in ins]}

def current_members(path,originals):
    # Direct metadata/IL read without the generic-default-only classifier.
    data=path.read_bytes();c=Cli(data);reader=Read(c);result=[]
    for mi in SPECS:
        original=originals[mi]['original'];owners=[rid for rid in range(1,c.rows[2]+1) if reader.definition(rid)==original['owner']];need(len(owners)==1,'Exact retained generated owner')
        methods=[r for r in reader.methods(owners[0]) if r['name']==original['name']];need(len(methods)==1,'Exact selected original name');row=methods[0];rid=int(row['token'],16)&0xffffff;at=c.row(6,rid);raw=c.raw(c.u32(at),1);first=data[raw]
        if first&3==2:body=data[raw+1:raw+1+(first>>2)]
        else:
            need(first&3==3,'Exact current IL header');head=(c.u16(raw)>>12)*4;size=c.u32(raw+4);need(12<=head<=64 and size<=65536,'Bounded current body');body=data[raw+head:raw+head+size]
        if mi in (47905,47922):
            need(len(body)==7 and body[:2]==bytes.fromhex('0228') and body[-1:]==b'\x2a','Already genuine empty constructor has only base Object call')
            token=int.from_bytes(body[2:6],'little');need(token>>24==10,'Existing Object constructor MemberRef');q=c.row(10,token&0xffffff);width=c.coded(3,[2,1,26,6,27]);parent=c.value(q,width);need(parent&7==1 and reader.typeref(parent>>3).endswith(']System.Object') and c.string(c.value(q+width,c.strw))=='.ctor' and c.blob(c.value(q+width+c.strw,c.blobw))==bytes.fromhex('200001'),'Exact existing Object constructor scope/signature')
        result.append({'owner':original['owner'],'name':original['name'],'current_CLI_token_not_original_native':row['token'],'flags':row['flags'],'impl_flags':row['impl_flags'],'signature':row['signature'],'IL_bytes':body.hex(),'IL_sha256':hashlib.sha256(body).hexdigest()})
    return result

def main():
    need(pin(RUN/'run-report.json')['sha256']==RECEIPT_SHA and pin(JOINS)['sha256']==JOINS_SHA,'Exact actual original decode and typed joins')
    receipt=json.loads((RUN/'run-report.json').read_bytes());check(receipt['plan']);check(receipt['output']);plan=json.loads(Path(receipt['plan']['path']).read_bytes());check(plan['input']);sources=json.loads(Path(plan['input']['path']).read_bytes());rows={r['native_method_index']:r for r in [json.loads(x) for x in Path(receipt['output']['path']).read_text().splitlines()]};originals={r['original']['index']:r for r in sources['methods']}
    need(set(rows)==set(originals)==set(SPECS) and receipt['original_bytes']==681,'Only exact seven decoded original prerequisites')
    shapes={str(mi):shape(rows[mi],originals[mi]) for mi in SPECS}
    joins=json.loads(JOINS.read_bytes());paths=[Path(x['path']) for x in joins['original_inputs']]
    for row in joins['original_inputs']:check(row)
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
        v=ExternMetadata(b,m)
        for mi,(va,size,digest) in SPECS.items():
            need(v.method_info(mi)==originals[mi]['original'] and v.method_pointer(originals[mi]['original'])==va,'Exact original method ownership/signature/registration');at=v.raw(va,size);need(bytes(b[at:at+size])==bytes.fromhex(originals[mi]['runtime_function']['bytes']),'Fresh original raw bytes')
        typed_fields={str(ti):fields(v,ti) for ti in [6598,6600,6603,6605]}
        need([(x['name'],x['flags'],x['offset']) for x in typed_fields['6598']]==[('<>9',54,0),('<>9__45_0',22,8)],'Original resolve closure singleton/cache identities')
        need([(x['name'],x['flags'],x['offset']) for x in typed_fields['6603']]==[('<>9',54,0),('<>9__3_0',22,8),('<>9__12_2',22,16),('<>9__13_0',22,24),('<>9__14_0',22,32)],'Original Sorted cached selector is exact offset24 field')
        need(typed_fields['6600'][0]['name']=='HDPNFBMCAHN' and typed_fields['6600'][0]['type']=='CPAMAFPANDM' and typed_fields['6600'][0]['offset']==16 and typed_fields['6600'][0]['flags']==38,'Original node selector readonly key field')
        need(typed_fields['6605'][2]['name']=='OMMELJLAGLB' and typed_fields['6605'][2]['type']=='System.Collections.Generic.List`1<CPAMAFPANDM>' and typed_fields['6605'][2]['offset']==32,'Original memoized list field')
        uses={hex(a):v.usage(a) for a in [0x18888be78,0x18883c9c0,0x1886fff68,0x1888185d8,0x1888732f8,0x188708dd8,0x188772180,0x188864cb8]}
        value=uses['0x18888be78'];need(value['kind']==6 and value['index']==200365 and value['method']['index']==12464 and value['method']['name']=='get_Value' and value['class_argument_types']==['CPAMAFPANDM','NJAICAFMPBE'],'Exact original inlined KeyValuePair.Value accessor specialization')
        need(uses['0x18883c9c0']['type']=='MNALHHOLFGL/<>c' and uses['0x1886fff68']['type']=='OENEDGPIOFN/<>c','Exact native closure class initialization/allocation identities')
        select,to_list,delegate=uses['0x1888185d8'],uses['0x1888732f8'],uses['0x188708dd8'];need(select['index']==444138 and select['method']['name']=='Select' and select['method_argument_types']==['OENEDGPIOFN/NPDGPDKAHLN','CPAMAFPANDM'] and to_list['index']==444931 and to_list['method']['name']=='ToList' and to_list['method_argument_types']==['CPAMAFPANDM'] and delegate['index']==162381 and delegate['method']['name']=='.ctor' and delegate['class_argument_types']==['OENEDGPIOFN/NPDGPDKAHLN','CPAMAFPANDM'] and uses['0x188864cb8']['method']['index']==47925,'Exact native LINQ and cached existing callback specialization')
        graph_dependencies=[v.method_info(x) for x in [47907,47915]];need(v.method_pointer(graph_dependencies[0])==0x1867464a0 and graph_dependencies[0]['flags']==2177 and v.method_pointer(graph_dependencies[1])==0x186746920 and graph_dependencies[1]['flags']==145,'Exact original private getter/static topological-list dependencies; bodies not recovered here')
        at=v.raw(0x1806f84d0,3);need(bytes(b[at:at+3])==bytes.fromhex('c20000'),'Original shared System.Object constructor target is exact RET0; no field effects guessed')
    controls=[]
    for mi in SPECS:
        for ip in EFFECTS[mi]:
            changed=copy.deepcopy(rows[mi]);next(x for x in changed['instructions'] if x['ip']==ip)['text']='mutated original effect'
            rejected=False
            try:shape(changed,originals[mi])
            except ValueError:rejected=True
            need(rejected,'Every changed meaningful original operand rejected');controls.append({'method':mi,'ip':hex(ip),'rejected':True})
    source=HERE/'RecoveredContainerPreparationPrerequisites.cs';text=CANDIDATE
    if source.exists():need(source.read_text()==text,'Never overwrite frozen prerequisite candidate')
    else:source.write_text(text,encoding='utf-8',newline='\n')
    current=WS/'RR23/Assets/Plugins/UJect.Runtime.dll';current_methods=current_members(current,originals)
    need(len(current_methods)==7 and all(int(row['current_CLI_token_not_original_native'],16)==int(originals[mi]['original']['token'],16) and row['flags']==originals[mi]['original']['flags'] for row,mi in zip(current_methods,SPECS)),'Exact retained current original MethodDef/token/flags')
    out=ROOT/'Validation'/('ContainerPreparationPrerequisiteMembers-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'original-container-preparation-seven-prerequisites-CFG-candidates/v1','status':'seven_complete_native_prerequisites_staged_five_changed_bodies_two_genuinely_empty_constructors','producer':pin(Path(__file__)),'actual_Root_decode_receipt':pin(RUN/'run-report.json'),'actual_decoded_output':receipt['output'],'original_scopes':plan['input'],'original_typed_joins':pin(JOINS),'original_inputs':joins['original_inputs'],'original_methods':[originals[mi]['original'] for mi in SPECS],'complete_shapes':shapes,'original_fields':typed_fields,'exact_original_metadata_uses':uses,'current_plugin':pin(current),'current_meta':pin(Path(str(current)+'.meta')),'current_selected_methods':current_methods,'readable_candidate':pin(source),'legal_generated_alias_map':ALIASES,'negative_controls':controls,'already_genuinely_empty_original_constructors':[47905,47922],'changed_body_targets':[47904,47906,47914,47921,47925],'held_real_dependency_methods':graph_dependencies,'constraints':'No new production types, fields, methods, closures or lambda-generated metadata. A future strict alias-aware importer must bind only existing raw generated identities.','full_LNF_recovered':False,'LNF_EH_and_called_LGK_assertion_still_held':True,'graph_cycle_toposort_or_injection_functionality_proved':False,'compiler_Unity_game_native_library_or_network_executed':False,'Main_modified':False}
    target=out/'report.json';save(target,report);print(json.dumps({'report':pin(target),'candidate':pin(source),'changed_bodies':5,'genuinely_empty_existing_constructors':2,'negative_controls':len(controls),'Main_modified':False}))

ALIASES={
 'MNALHHOLFGL.ResolveClosureAlias':{'raw_type':'MNALHHOLFGL/<>c','original_TypeDef':'0x02000009','Singleton':'<>9','CachedSelector':'<>9__45_0','SelectProvider':'<TryResolveAll>b__45_0'},
 'OENEDGPIOFN.SortedClosureAlias':{'raw_type':'OENEDGPIOFN/<>c','original_TypeDef':'0x0200000e','Singleton':'<>9','CachedSelector':'<>9__13_0','SelectKey':'<Sorted>b__13_0'}}
CANDIDATE='''// Native-proven selected members only, outside Assets compilation.
// Legal aliases below must map to the existing raw generated metadata exactly.
// Never import declarations wholesale or synthesize production lambda helpers.
using System;
using System.Collections.Generic;
using System.Linq;
public partial class MNALHHOLFGL
{
    // Alias for original MNALHHOLFGL/<>c; its two existing fields are retained.
    internal sealed class ResolveClosureAlias
    {
        public static readonly ResolveClosureAlias Singleton;
        public static Func<KeyValuePair<CPAMAFPANDM,NJAICAFMPBE>,NJAICAFMPBE> CachedSelector;
        // Original47904. The native allocation calls the genuinely empty ctor.
        static ResolveClosureAlias(){Singleton=new ResolveClosureAlias();}
        // Original47905 already has only System.Object construction; keep it.
        public ResolveClosureAlias(){}
        // Original47906; exact inlined MethodSpec200365 KeyValuePair.Value.
        internal NJAICAFMPBE SelectProvider(KeyValuePair<CPAMAFPANDM,NJAICAFMPBE> r)
        {
            return r.Value;
        }
    }
}
public partial class OENEDGPIOFN
{
    // Alias for original OENEDGPIOFN/<>c; other original fields stay untouched.
    internal sealed class SortedClosureAlias
    {
        public static readonly SortedClosureAlias Singleton;
        public static Func<NPDGPDKAHLN,CPAMAFPANDM> CachedSelector;
        // Original47921.
        static SortedClosureAlias(){Singleton=new SortedClosureAlias();}
        // Original47922 is genuinely empty beyond System.Object construction.
        public SortedClosureAlias(){}
        // Original47925; raw reference null behavior and readonly16B key copy.
        internal CPAMAFPANDM SelectKey(NPDGPDKAHLN n)
        {
            return n.HDPNFBMCAHN;
        }
    }
    // Original47914, full383B/three connected native regions.
    // IEPIDJGAOIN and LAEKFDEFKFK remain exact, unrecovered call boundaries.
    public IEnumerable<CPAMAFPANDM> IJAKDIKAJHP()
    {
        List<CPAMAFPANDM> cached=this.OMMELJLAGLB;
        if(cached!=null)return cached;
        List<NPDGPDKAHLN> ordered=LAEKFDEFKFK(this.IEPIDJGAOIN());
        Func<NPDGPDKAHLN,CPAMAFPANDM> selector=SortedClosureAlias.CachedSelector;
        if(selector==null)
        {
            selector=new Func<NPDGPDKAHLN,CPAMAFPANDM>(SortedClosureAlias.Singleton.SelectKey);
            SortedClosureAlias.CachedSelector=selector;
        }
        this.OMMELJLAGLB=Enumerable.ToList(Enumerable.Select(ordered,selector));
        return this.OMMELJLAGLB;
    }
}
'''
if __name__=='__main__':main()
