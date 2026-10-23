"""Join Root's complete556B Awake decode to original fields/calls/usages."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from prove_recroom_ondestroy_native_cfg import aliases
from collect_nameserver_request_factory_native import fields
from collect_title_page_route_native import pin
CHAIN=ROOT/'Validation/TitleAwakeChainedNative-20261023T071929Z-448f466b'
DECODE=CHAIN/'RootDecodePlan-20261023T071942Z-45adcce3'
def main():
    receipt=DECODE/'run-report.json';need(pin(receipt)['sha256']=='abc385c40ef8749ed47ca39175138032fec63f07a635a7b8740f3bf13fe2396c','Actual successful complete-chain decoder receipt');done=json.loads(receipt.read_bytes());need(done['status']=='complete_original_Awake_chain_decoded_CFG_and_typed_semantics_pending','Root inert decode passed');need(pin(done['output']['path'])==done['output'],'Actual decoded bytes unchanged')
    source=json.loads((CHAIN/'original-Awake-three-chained-regions.json').read_bytes());row=source['methods'][0];decoded=json.loads(Path(done['output']['path']).read_text());need(decoded['native_method_index']==192547,'Exact Awake decoded identity');ins=decoded['instructions'];byip={x['ip']:x for x in ins};lo=int(row['native_pointer'],16);hi=lo+556;pos=lo;calls=set();edges={};uses={};unknown=[]
    for x in ins:need(x['ip']==pos and x['length']>0,'Every decoded original byte contiguous');pos+=x['length']
    need(pos==hi and len(byip)==len(ins),'Full556B decoded exactly once')
    for x in ins:
        ip=x['ip'];flow=x['flow'];nxt=ip+x['length'];target=x['operands'][0]['target'] if x['operands'] else 0
        if flow=='Call':calls.add(target);succ=[] if target==0x1806c0390 else [nxt]
        elif flow=='ConditionalBranch':need(target in byip,'Every original condition stays in the three-region Awake closure');succ=[target,nxt]
        elif flow=='UnconditionalBranch':need(target==0x1806bfd30,'Only original GC-barrier return tail outside method');succ=[]
        elif flow=='Interrupt':need(x['mnemonic']=='Int3','Only original throw separator');succ=[]
        else:need(flow=='Next','No unclassified original control flow');succ=[nxt]
        edges[ip]=succ
    reached=set();todo=[lo]
    while todo:
        ip=todo.pop();need(ip in byip,'No original edge escapes complete closure')
        if ip in reached:continue
        reached.add(ip);todo.extend(edges[ip])
    need(set(byip)-reached=={0x181ae357b},'Only final post-noreturn INT3 is unreachable')
    paths=[Path(x['path']) for x in source['original_inputs']]
    for p in source['original_inputs']:need(pin(p['path'])==p,'Pinned complete original source')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);need(bytes(b[v.raw(lo,556):v.raw(lo,556)+556]).hex()==row['runtime_function']['bytes'],'Actual complete original code span')
        for x in ins:
            memory=x['memory']
            if memory['ip_relative']:
                address=memory['ip_relative_address']
                if hex(address) in uses or any(a['address']==hex(address) for a in unknown):continue
                try:uses[hex(address)]=v.usage(address)
                except ValueError as e:unknown.append({'address':hex(address),'reason':str(e),'instruction':x['text']})
        direct,gaps=aliases(v,calls-{0x1806c01e0,0x180640f10,0x1806c0340,0x1806bfd30,0x1806c0390})
        generic=v.generic_targets({x['index'] for x in uses.values() if x['kind']==6});declared=fields(v,row['original']['owner_index'])
    out=ROOT/'Validation'/('TitleAwakeTypedJoins-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'original-complete-TitleScreenManager-Awake-CFG-and-typed-joins/v1','status':'complete_original_CFG_closed_typed_application_effect_review_pending','original_chain_input':pin(CHAIN/'original-Awake-three-chained-regions.json'),'actual_decoder_receipt':pin(receipt),'actual_decoded_output':done['output'],'original_method':row['original'],'CFG':{'all556bytes_decoded':True,'all_reachable_edges_closed':True,'reachable_instructions':len(reached),'instruction_count':len(ins),'unreachable_separator':[hex(x) for x in sorted(set(byip)-reached)],'return_tail':'ordinary original GC write barrier0x1806bfd30','edges':{hex(k):[hex(v) for v in a] for k,a in edges.items()}},'original_fields':declared,'metadata_usages':uses,'non_metadata_RIP_flags_or_data':unknown,'direct_original_application_targets':direct,'generic_registrations':generic,'unbacked_direct_alias_tables_not_assumed_absent':gaps,'CSharp_candidate_written':False,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'producer':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'calls':{k:[x['owner']+'.'+x['name'] for x in a] for k,a in direct.items()},'uses':uses,'generic_registrations':generic,'CFG_closed':True}))
if __name__=='__main__':main()
