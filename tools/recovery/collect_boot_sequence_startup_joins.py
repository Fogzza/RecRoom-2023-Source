"""Data-only seven BootSequence startup normal CFGs and typed dependencies. Indirect-call targets and EH remain explicit open checks."""
from pathlib import Path
import datetime as dt,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from prove_recroom_ondestroy_native_cfg import aliases
from collect_nameserver_request_factory_native import fields
from collect_title_page_route_native import pin
CHAIN=ROOT/'Validation/BootSequenceStartupScopes-20261023T103849Z-9e28ea4f'
DECODE=CHAIN
RUNTIME={0x1806c01e0,0x180640f10,0x1806c0340,0x1806c0390,0x1806c0360,0x1806bfd70,0x1806bff80,0x1806bfd30}
NORETURN={0x1806c0390,0x1806c0360,0x1806bfd70}

def main():
    receipt=DECODE/'run-report.json';need(pin(receipt)['sha256']=='77de2f7ff6430856fc0599dabe3e5101e550f6bedc3a59d3b36f92c02751029f','Actual Root three-callback inert decode');done=json.loads(receipt.read_bytes());need(done['status']=='original4456B_BootSequence_startup_whole_scopes_inert_decoded_semantics_pending' and pin(done['output']['path'])==done['output'],'Exact successful instruction stream')
    sourcepath=CHAIN/'original-BootSequence-startup-scopes.json';need(pin(sourcepath)['sha256']=='88ea8ab2078ccaab6ca72c29b0ba19a8efe8a14748c623180d76c6883022f98d','Complete actual native scopes');source=json.loads(sourcepath.read_bytes());decoded={r['native_method_index']:r for r in [json.loads(x) for x in Path(done['output']['path']).read_text().splitlines()]};results=[]
    for x in source['original_inputs']:need(pin(x['path'])==x,'Exact original metadata/native source pins')
    paths=[Path(x['path']) for x in source['original_inputs']]
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md)
        for row in source['methods']:
            original=row['original'];ins=decoded[original['index']]['instructions'];byip={x['ip']:x for x in ins};lo=int(row['native_pointer'],16);raw=bytes.fromhex(row['runtime_function']['bytes']);hi=lo+len(raw);pos=lo;edges={};calls=set();tails=[];indirect=[];uses={};unknown=[]
            need(bytes(b[v.raw(lo,len(raw)):v.raw(lo,len(raw))+len(raw)])==raw,'Whole original connected region exact')
            for x in ins:need(x['ip']==pos and x['length']>0,'Contiguous complete original decode');pos+=x['length']
            need(pos==hi and len(ins)==len(byip),'Every original callback byte decoded once')
            for x in ins:
                ip=x['ip'];flow=x['flow'];nxt=ip+x['length'];target=x['operands'][0]['target'] if x['operands'] else 0
                if flow=='Call':calls.add(target);succ=[] if target in NORETURN else [nxt]
                elif flow=='IndirectCall':indirect.append({'instruction':hex(ip),'text':x['text'],'typed_target_or_slot_proof_pending':True});succ=[nxt]
                elif flow=='ConditionalBranch':need(target in byip,'No original conditional edge outside proven scope');succ=[target,nxt]
                elif flow=='UnconditionalBranch':
                    if target in byip:succ=[target]
                    else:calls.add(target);tails.append({'instruction':hex(ip),'target':hex(target)});succ=[]
                elif flow=='Return':succ=[]
                elif flow=='Interrupt':need(x['mnemonic']=='Int3','Only original throw terminator');succ=[]
                else:need(flow=='Next','No unclassified control flow');succ=[nxt]
                edges[ip]=succ
            reached=set();todo=[lo]
            while todo:
                ip=todo.pop();need(ip in byip,'Every nonterminal edge stays in complete connected scope')
                if ip in reached:continue
                reached.add(ip);todo.extend(edges[ip])
            need(all(byip[x]['mnemonic'] in ('Int3','Nop') for x in set(byip)-reached),'Only original padding/throw terminators unreachable')
            for x in ins:
                if x['memory']['ip_relative']:
                    address=x['memory']['ip_relative_address']
                    if hex(address) in uses or any(y['address']==hex(address) for y in unknown):continue
                    try:uses[hex(address)]=v.usage(address)
                    except ValueError as error:unknown.append({'address':hex(address),'reason':str(error),'instruction':x['text']})
            direct,gaps=aliases(v,calls-RUNTIME);generic=v.generic_targets({x['index'] for x in uses.values() if x['kind']==6});owners={x['owner_index'] for group in direct.values() if len(group)<10 for x in group};owner_fields={}
            for i in sorted(owners):
                try:owner_fields[str(i)]={'status':'raw_backed_offsets','fields':fields(v,i)}
                except ValueError as error:owner_fields[str(i)]={'status':'unbacked_offsets_not_guessed','owner_index':i,'reason':str(error)}
            results.append({'original_method':original,'native_region':row['runtime_function'],'original_runtime_regions':row['original_runtime_regions'],'CFG':{'all_original_bytes_decoded':True,'all_normal_nonterminal_edges_inside_complete_scope':True,'exception_unwind_not_proved':True,'indirect_call_semantics_pending':indirect,'instruction_count':len(ins),'reachable_instruction_count':len(reached),'unreachable_padding_or_throw_terminators':[hex(x) for x in sorted(set(byip)-reached)],'external_tail_targets_pending_typed_effect_review':tails,'edges':{hex(k):[hex(z) for z in values] for k,values in edges.items()}},'original_fields':fields(v,original['owner_index']),'direct_target_owner_fields':owner_fields,'metadata_usages':uses,'non_metadata_RIP_flags_or_data':unknown,'direct_original_application_targets':direct,'generic_registrations':generic,'unbacked_direct_alias_tables_not_assumed_absent':gaps})
    out=ROOT/'Validation'/('BootSequenceStartupTypedJoins-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-seven-BootSequence-startup-normal-CFG-and-typed-joins/v1','status':'all_seven_original_startup_normal_CFGs_closed_typed_effect_and_EH_review_pending','original_region_input':pin(sourcepath),'actual_decoder_receipt':pin(receipt),'actual_decoded_output':done['output'],'startup_methods':results,'CSharp_candidate_written':False,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'producer':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'startup_methods':[{'name':r['original_method']['name'],'direct_targets':{k:([x['owner']+'.'+x['name'] for x in group] if len(group)<10 else {'shared_alias_count':len(group)}) for k,group in r['direct_original_application_targets'].items()},'metadata_usage_count':len(r['metadata_usages'])} for r in results],'CSharp_candidate_written':False}))
if __name__=='__main__':main()


