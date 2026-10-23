"""Prove original PMNJIOHDABB connected PE chain scope, data only."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED
from collect_title_page_route_native import pin
from prepare_title_manager_start_native import save

def collect(v):
    method=v.find_method('TitleScreenManager',0x060008a2);va=v.method_pointer(method);need(method['index']==192553 and method['name']=='PMNJIOHDABB' and va==0x181ae42c0 and method['return']=='System.Void' and not method['parameters'],'Exact original immediate Start/display callback identity')
    opt=v.u32(v.b,60)+24;rva,size=struct.unpack_from('<II',v.b,opt+136);need(0<size<=16*1024**2 and size%12==0,'Bounded entire PE exception directory');at=v.raw(v.base+rva,size);rows=list(struct.iter_unpack('<III',v.b[at:at+size]));parents={}
    for r in rows:
        start,end,unwind=r;need(start<end,'Original runtime range');a=v.raw(v.base+unwind,4);version=v.b[a]&7;flags=v.b[a]>>3;count=v.b[a+2]
        if flags&4:
            need(version==1 and flags==4,'Version1 exact chaininfo grammar');p=v.raw(v.base+unwind+((4+2*count+3)&~3),12);parents[r]=struct.unpack_from('<III',v.b,p)
    roots=[r for r in rows if r[0]==va-v.base];need(len(roots)==1 and roots[0] not in parents,'One exact original unchained callback root');root=roots[0];linked={root}
    while True:
        more={child for child,parent in parents.items() if parent in linked}-linked
        if not more:break
        linked|=more;need(len(linked)<=32,'Bounded actual callback chain closure')
    ordered=sorted(linked);details=[]
    for i,r in enumerate(ordered):
        start,end,unwind=r;need(not i or ordered[i-1][1]==start,'Complete callback regions must be contiguous before one-stream decode');a=v.raw(v.base+unwind,4);raw=v.raw(v.base+start,end-start);code=bytes(v.b[raw:raw+end-start]);details.append({'start_rva':start,'end_rva':end,'unwind_rva':unwind,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'unwind_header':bytes(v.b[a:a+4]).hex(),'chained_parent_runtime_function':list(parents[r]) if r in parents else None})
    lo,hi=v.base+ordered[0][0],v.base+ordered[-1][1];code=b''.join(bytes.fromhex(r['bytes']) for r in details);need(lo==va and 0<len(code)<=16384,'Bounded genuine callback span');direct=[];gaps=[]
    for image,module in v.modules.items():
        if not module['count']:continue
        try:a=v.raw(module['pointers_va'],module['count']*8)
        except ValueError as e:gaps.append({'image':image,'table_pointer':hex(module['pointers_va']),'method_count':module['count'],'reason':str(e)});continue
        for i in range(module['count']):
            pointer=v.u64(v.b,a+i*8)
            if lo<=pointer<hi:direct.append({'image':image,'token':hex(0x06000000|i+1),'pointer':hex(pointer)})
    generic=[]
    for i in range(v.generic_pointer_count):
        pointer=v.u64(v.b,v.generic_pointers+i*8)
        if lo<=pointer<hi:generic.append({'generic_pointer_index':i,'pointer':hex(pointer)})
    need(all(int(r['pointer'],16)==lo for r in direct+generic) and any(r['image']=='Assembly-CSharp.dll' and r['token']=='0x60008a2' for r in direct),'Original callback registered entry, no other backed distinct starts absorbed');nextroot=min(r[0] for r in rows if r[0]>=hi-v.base)
    return {'original':method,'native_pointer':hex(va),'runtime_function':{'start_rva':ordered[0][0],'end_rva':ordered[-1][1],'unwind_rva':root[2],'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'scope':'Complete connected contiguous pdata chain closure; not assumed one pdata row'},'original_runtime_regions':details,'all_original_runtime_rows_examined':len(rows),'all_chaininfo_rows_examined':len(parents),'complete_connected_chain_region_count':len(linked),'registered_method_starts_inside_scope':{'raw_backed_direct':direct,'generic_pointer_rows':generic,'unbacked_module_tables_not_assumed_absent':gaps},'next_independent_runtime_entry':hex(v.base+nextroot),'padding_before_next_entry_bytes':v.base+nextroot-hi}

def main():
    paths=[ROOT/'CodeSource'/x for x in EXPECTED];inputs=[pin(x) for x in paths];need(all(x['sha256']==EXPECTED[Path(x['path']).relative_to(ROOT/'CodeSource').as_posix()] for x in inputs),'Original exact source pins')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:row=collect(ExternMetadata(b,md))
    out=ROOT/'Validation'/('TitleDisplayCallbackNative-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=out/'original-PMNJIOHDABB-complete-region.json';save(source,{'schema':'original-TitleScreenManager-PMNJIOHDABB-complete-chain-decode-input/v1','original_inputs':inputs,'methods':[row],'original_bytes':len(bytes.fromhex(row['runtime_function']['bytes'])),'original_chain_membership_proven':True,'whole_method_CSharp_recovery_claimed':False});report={'schema':'original-TitleScreenManager-PMNJIOHDABB-genuine-chained-PE-scope/v1','status':'complete_original_PMNJIOHDABB_scope_ready_for_inert_decode','original_inputs':inputs,'source':pin(source),'callback':row,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'CSharp_candidate_written':False,'producer':pin(Path(__file__))};target=out/'report.json';save(target,report);print(json.dumps({'report':pin(target),'decoder_input':pin(source),'native_bytes':len(bytes.fromhex(row['runtime_function']['bytes'])),'regions':len(row['original_runtime_regions']),'registered_starts_inside_scope':'original callback only in backed tables;12unbacked tables retained unknown','CSharp_recovered':False}))
if __name__=='__main__':main()
