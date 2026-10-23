"""Recover the complete genuine chained PE scope of TitleScreenManager.Start.

Data only: mmap original bytes/metadata, no executable/decoder/game load.
"""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED
from collect_title_page_route_native import pin
def save(p,v):
    with p.open('x',encoding='utf-8') as f:json.dump(v,f,indent=2);f.write('\n')
def collect(v):
    method=v.find_method('TitleScreenManager',0x0600089d);va=v.method_pointer(method);need(method['index']==192548 and va==0x181ae4860 and not method['parameters'] and method['return']=='System.Void','Exact original Start registration')
    opt=v.u32(v.b,60)+24;rva,size=struct.unpack_from('<II',v.b,opt+136);need(0<size<=16*1024**2 and size%12==0,'Complete bounded exception-directory table');offset=v.raw(v.base+rva,size);rows=list(struct.iter_unpack('<III',v.b[offset:offset+size]));parents={};details={}
    for row in rows:
        start,end,unwind=row;need(start<end,'Original runtime interval');at=v.raw(v.base+unwind,4);version=v.b[at]&7;flags=v.b[at]>>3;count=v.b[at+2]
        if flags&4:
            need(version==1 and flags==4,'Only genuine version1 chaininfo grammar');extra=v.raw(v.base+unwind+((4+2*count+3)&~3),12);parents[row]=struct.unpack_from('<III',v.b,extra)
    roots=[r for r in rows if r[0]==va-v.base];need(len(roots)==1 and roots[0] not in parents,'One unchained exact registered Start root');root=roots[0];linked={root}
    while True:
        more={child for child,parent in parents.items() if parent in linked}-linked
        if not more:break
        linked|=more;need(len(linked)<=32,'Bounded actual Start chain closure')
    ordered=sorted(linked);need(len(ordered)==1 and ordered[0][0]==0x1ae4860 and ordered[0][1]==0x1ae4c7d,'Exact original hot/root+zero cold/chain descendants')
    for i,row in enumerate(ordered):
        start,end,unwind=row;at=v.raw(v.base+unwind,4);raw=v.raw(v.base+start,end-start);code=bytes(v.b[raw:raw+end-start]);need(not i or ordered[i-1][1]==start,'Proved contiguous chained regions')
        details[start]={'start_rva':start,'end_rva':end,'unwind_rva':unwind,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'unwind_header':bytes(v.b[at:at+4]).hex(),'chained_parent_runtime_function':list(parents[row]) if row in parents else None}
    lo,hi=v.base+ordered[0][0],v.base+ordered[-1][1];combined=b''.join(bytes.fromhex(details[x[0]]['bytes']) for x in ordered);need(len(combined)==1053,'Exact complete linked1053B span')
    direct=[];unbacked=[]
    for image,module in v.modules.items():
        if not module['count']:continue
        try:at=v.raw(module['pointers_va'],module['count']*8)
        except ValueError as error:unbacked.append({'image':image,'table_pointer':hex(module['pointers_va']),'method_count':module['count'],'reason':str(error)});continue
        for rid in range(module['count']):
            pointer=v.u64(v.b,at+rid*8)
            if lo<=pointer<hi:direct.append({'image':image,'token':hex(0x06000000|(rid+1)),'pointer':hex(pointer)})
    generic=[]
    for index in range(v.generic_pointer_count):
        pointer=v.u64(v.b,v.generic_pointers+index*8)
        if lo<=pointer<hi:generic.append({'generic_pointer_index':index,'pointer':hex(pointer)})
    need(all(int(x['pointer'],16)==lo for x in direct+generic),'No distinct original registered method start may be absorbed into Start chain')
    need(any(x['image']=='Assembly-CSharp.dll' and x['token']=='0x600089d' for x in direct),'Actual original Start direct module registration among witnesses')
    nextroot=min(r[0] for r in rows if r[0]>=hi-v.base);need(nextroot==0x1ae4c80,'Next independent native root starts after3padding bytes')
    runtime={'start_rva':ordered[0][0],'end_rva':ordered[-1][1],'unwind_rva':root[2],'bytes':combined.hex(),'sha256':hashlib.sha256(combined).hexdigest(),'scope':'Complete contiguous single-region chain closure; this synthetic decode span is not claimed to be one pdata row'}
    return {'original':method,'native_pointer':hex(va),'runtime_function':runtime,'original_runtime_regions':[details[r[0]] for r in ordered],'all_original_runtime_rows_examined':len(rows),'all_chaininfo_rows_examined':len(parents),'complete_connected_chain_region_count':len(linked),'registered_method_starts_inside_scope':{'raw_backed_direct':direct,'generic_pointer_rows':generic,'unbacked_module_tables_not_assumed_absent':unbacked},'next_independent_runtime_entry':hex(v.base+nextroot),'padding_before_next_entry_bytes':3}
def main():
    paths=[ROOT/'CodeSource'/x for x in EXPECTED];inputs=[pin(x) for x in paths];need(all(x['sha256']==EXPECTED[Path(x['path']).relative_to(ROOT/'CodeSource').as_posix()] for x in inputs),'Exact original sources')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:row=collect(ExternMetadata(b,md))
    out=ROOT/'Validation'/('TitleStartChainedNative-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=out/'original-Start-single-complete-region.json';save(source,{'schema':'original-TitleScreenManager-Start-complete-chain-decode-input/v1','original_inputs':inputs,'methods':[row],'original_bytes':1053,'original_chain_membership_proven':True,'whole_method_CSharp_recovery_claimed':False})
    report={'schema':'original-TitleScreenManager-Start-genuine-chained-PE-scope/v1','status':'complete_original_single_region_Start_scope_ready_for_inert_decode','original_inputs':inputs,'source':pin(source),'Start':row,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'CSharp_candidate_written':False,'producer':pin(Path(__file__))};target=out/'report.json';save(target,report);print(json.dumps({'report':pin(target),'decoder_input':pin(source),'native_bytes':1053,'regions':1,'other_registered_starts_inside_scope':False,'CSharp_recovered':False}))
if __name__=='__main__':main()
