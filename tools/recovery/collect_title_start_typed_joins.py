"""Data-only complete original Start CFG and typed call/field/usage joins."""
from pathlib import Path
import datetime as dt,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from prove_recroom_ondestroy_native_cfg import aliases
from collect_nameserver_request_factory_native import fields
from collect_title_page_route_native import pin
CHAIN=ROOT/'Validation/TitleStartChainedNative-20261023T073646Z-4a484454'
DECODE=CHAIN/'RootDecodePlan-20261023T073703Z-bcc75a61'
def main():
    receipt=DECODE/'run-report.json';need(pin(receipt)['sha256']=='4c1270cee8d288ecc21b2d55c8081e896fcd2d2a1c66fb50b1c197702ebf9b30','Actual Root Start decoder receipt')
    done=json.loads(receipt.read_bytes());need(done['status']=='complete_original_Start_chain_decoded_CFG_and_typed_semantics_pending','Successful inert decode');need(pin(done['output']['path'])==done['output'],'Actual decoded output unchanged')
    sourcepath=CHAIN/'original-Start-single-complete-region.json';need(pin(sourcepath)['sha256']=='608453677f48b675739b553ec5a92da8c895b26dbcfc55dbed42dc118556657b','Exact complete Start original region')
    source=json.loads(sourcepath.read_bytes());row=source['methods'][0];decoded=json.loads(Path(done['output']['path']).read_bytes());need(decoded['native_method_index']==192548,'Original Start method index')
    ins=decoded['instructions'];byip={x['ip']:x for x in ins};lo=int(row['native_pointer'],16);hi=lo+1053;pos=lo;calls=set();edges={};uses={};unknown=[]
    for x in ins:need(x['ip']==pos and x['length']>0,'Original bytes decoded contiguously');pos+=x['length']
    need(pos==hi and len(ins)==len(byip),'Every1053 original bytes decoded once')
    for x in ins:
        ip=x['ip'];flow=x['flow'];nxt=ip+x['length'];target=x['operands'][0]['target'] if x['operands'] else 0
        if flow=='Call':calls.add(target);succ=[] if target in (0x1806c0390,0x1806c0360,0x1806bfd70) else [nxt]
        elif flow=='ConditionalBranch':need(target in byip,'Every condition stays inside exact complete region');succ=[target,nxt]
        elif flow=='UnconditionalBranch':
            if target in byip:succ=[target]
            else:need(target==0x18555c8e0,'Only typed original final tail call leaves Start');calls.add(target);succ=[]
        elif flow=='Interrupt':need(x['mnemonic']=='Int3','Only original throw terminator');succ=[]
        else:need(flow=='Next','No unclassified original control flow');succ=[nxt]
        edges[ip]=succ
    reached=set();todo=[lo]
    while todo:
        ip=todo.pop();need(ip in byip,'No control edge escapes complete Start')
        if ip in reached:continue
        reached.add(ip);todo.extend(edges[ip])
    need(all(byip[x]['mnemonic'] in ('Int3','Nop') for x in set(byip)-reached),'Only padding/throw terminators unreachable')
    for p in source['original_inputs']:need(pin(p['path'])==p,'Pinned actual original inputs')
    paths=[Path(x['path']) for x in source['original_inputs']]
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);need(bytes(b[v.raw(lo,1053):v.raw(lo,1053)+1053]).hex()==row['runtime_function']['bytes'],'Actual original complete Start1053B')
        for x in ins:
            m=x['memory']
            if m['ip_relative']:
                address=m['ip_relative_address']
                if hex(address) in uses or any(a['address']==hex(address) for a in unknown):continue
                try:uses[hex(address)]=v.usage(address)
                except ValueError as e:unknown.append({'address':hex(address),'reason':str(e),'instruction':x['text']})
        runtime={0x1806c01e0,0x180640f10,0x1806c0340,0x1806c0390,0x1806c0360,0x1806bfd70,0x1806bff80}
        direct,gaps=aliases(v,calls-runtime);generic=v.generic_targets({x['index'] for x in uses.values() if x['kind']==6});declared=fields(v,row['original']['owner_index'])
        owners=set()
        for a in direct.values():
            if len(a)<10:owners.update(x['owner_index'] for x in a)
        owner_fields={str(i):fields(v,i) for i in sorted(owners)}
    out=ROOT/'Validation'/('TitleStartTypedJoins-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'original-complete-TitleScreenManager-Start-CFG-and-typed-joins/v1','status':'complete_original_CFG_closed_typed_application_effect_review_pending','original_region_input':pin(sourcepath),'actual_decoder_receipt':pin(receipt),'actual_decoded_output':done['output'],'original_method':row['original'],'CFG':{'all1053bytes_decoded':True,'all_reachable_edges_closed':True,'instruction_count':len(ins),'reachable_instructions':len(reached),'unreachable_padding_or_throw_terminators':[hex(x) for x in sorted(set(byip)-reached)],'edges':{hex(k):[hex(v) for v in a] for k,a in edges.items()}},'original_fields':declared,'direct_target_owner_fields':owner_fields,'metadata_usages':uses,'non_metadata_RIP_flags_or_data':unknown,'direct_original_application_targets':direct,'generic_registrations':generic,'unbacked_direct_alias_tables_not_assumed_absent':gaps,'CSharp_candidate_written':False,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'producer':pin(Path(__file__))}
    target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'report':pin(target),'direct_targets':{k:([x['owner']+'.'+x['name'] for x in a] if len(a)<10 else {'shared_alias_count':len(a)}) for k,a in direct.items()},'usages':uses,'generic_registrations':generic,'CFG_closed':True}))
if __name__=='__main__':main()
