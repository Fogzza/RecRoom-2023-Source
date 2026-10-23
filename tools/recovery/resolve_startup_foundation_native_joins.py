"""Resolve only the three proved startup input windows against native metadata.

No target code executes. The Singleton continuation is bounded by the next
known original generic cleanup pointer and is explicitly not accepted as a
complete method until its decoded control flow closes.
"""
from pathlib import Path
import datetime as dt
import hashlib
import json
import mmap
import struct
import sys
import uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata
from prove_recroom_ondestroy_native_cfg import aliases
from prepare_startup_foundation_slice import SOURCE_PINS

SLICE=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207'
DECODE=SLICE/'RootDecodePlan-20261023T063328Z-af3c7055'
RECEIPT_SHA='61ede9bc0d8d23d6a45904327962b893daf8059b5962280028c850e78bfe2a90'
def need(value,message):
    if not value:raise ValueError(message)
def sha(path):
    with Path(path).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def literal(v,index):
    at=v.row('stringLiteral',index,8);length,offset=struct.unpack_from('<ii',v.m,at);base,size=v.tables['stringLiteralData'];need(0<=length<=4096 and 0<=offset<=offset+length<=size,'Bounded original literal');b=bytes(v.m[base+offset:base+offset+length]);return {'index':index,'utf8':b.decode('utf-8'),'sha256':hashlib.sha256(b).hexdigest()}
def rgctx(v,image,token):
    module=v.modules[image];at=v.raw(module['va'],96);count=v.u64(v.b,at+64);ptr=v.u64(v.b,at+72);total=v.u64(v.b,at+80);data=v.u64(v.b,at+88);need(0<count<=65536 and 0<total<=1000000,'Bounded native RGCTX tables');first=v.raw(ptr,count*12);hits=[]
    for i in range(count):
        t,start,n=struct.unpack_from('<Iii',v.b,first+i*12)
        if t==token:hits.append((start,n))
    if not hits:return {'original_token':hex(token),'status':'no_range_no_context_guessed'}
    need(len(hits)==1,'Unique native RGCTX range');start,n=hits[0];need(0<=start<=start+n<=total and n<=32,'Bounded exact RGCTX range');rows=[]
    for slot in range(n):
        raw=v.raw(data+(start+slot)*8,8);kind,index=struct.unpack_from('<ii',v.b,raw);r={'slot':slot,'kind':kind,'index':index,'original_bytes':bytes(v.b[raw:raw+8]).hex()}
        if kind in (1,2):r.update(type=v.typename(v.native_type(index)),native_type=v.native_type(index))
        elif kind==3:
            need(0<=index<v.method_spec_count,'MethodSpec range');mi,ci,gi=struct.unpack_from('<iii',v.b,v.method_specs+index*12);r.update(method=v.method_info(mi),class_arguments=[v.typename(t) for t in v.inst(ci)],method_arguments=[v.typename(t) for t in v.inst(gi)])
        else:r['unresolved_kind']=True
        rows.append(r)
    return {'original_token':hex(token),'start':start,'count':n,'rows':rows}
def main():
    receipt=DECODE/'run-report.json';need(sha(receipt)==RECEIPT_SHA,'Root actual decoder receipt drift');done=json.loads(receipt.read_bytes());need(done['status']=='decoded_original_entry_windows_not_whole_method_recovery','Root pure decoder success required');outpin=done['output'];decoded_path=Path(outpin['path']);need(sha(decoded_path)==outpin['sha256'],'Actual decoder output changed');decoded=[json.loads(line) for line in decoded_path.read_text().splitlines()];need(len(decoded)==3,'Exact three original windows')
    paths=[ROOT/'CodeSource'/p for p in SOURCE_PINS]
    for p in paths:need(sha(p)==SOURCE_PINS[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source changed')
    inputs=json.loads((SLICE/'bounded-next-native-windows.json').read_bytes());byindex={r['original']['index']:r for r in inputs['methods']};target=set();rip={};site_rows=[]
    for row in decoded:
        source=byindex[row['native_method_index']];lo=int(source['native_pointer'],16);hi=lo+len(bytes.fromhex(source['runtime_function']['bytes']))
        for ins in row['instructions']:
            if ins['flow'] in ('Call','UnconditionalBranch','ConditionalBranch') and ins['operands']:
                address=ins['operands'][0]['target']
                if address:
                    site_rows.append({'caller':source['label'],'instruction':ins,'target':hex(address),'inside_saved_region':lo<=address<hi})
                    if ins['flow'] in ('Call','UnconditionalBranch') and not lo<=address<hi:target.add(address)
            if ins['memory']['ip_relative']:rip[ins['memory']['ip_relative_address']]=None
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as binary,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as metadata:
        v=ExternMetadata(binary,metadata);direct,gaps=aliases(v,target)
        for address in rip:
            try:
                use=v.usage(address)
                if use['kind']==5:use['literal']=literal(v,use['index'])
                rip[address]=use
            except ValueError as error:rip[address]={'not_resolved_as_original_metadata_usage':str(error)}
        contexts=[]
        for row in inputs['methods']:
            method=row['original'];contexts.append({'label':row['label'],'method':rgctx(v,method['image'],int(method['token'],16)),'declaring_type':rgctx(v,method['image'],int(v.type_info(method['owner_index'])['token'],16))})
        # This exact next primary pointer is independently called by original
        # GameRoot.OnDestroy and is not inferred by searching for a RET byte.
        start=0x18333e400;end=0x18333e7c0;raw=v.raw(start,end-start);code=bytes(binary[raw:raw+end-start]);need(len(code)==960 and code[:830].hex()==inputs['methods'][0]['runtime_function']['bytes'],'Original Singleton continuation prefix changed')
        pointer_hits=[]
        for i in range(v.generic_pointer_count):
            address=v.u64(binary,v.generic_pointers+i*8)
            if start<address<end:pointer_hits.append({'pointer_index':i,'address':hex(address)})
        need(not pointer_hits,'Another registered generic primary lies inside proposed Singleton continuation')
        next_hits=[i for i in range(v.generic_pointer_count) if v.u64(binary,v.generic_pointers+i*8)==end];need(next_hits,'Bound must be an original registered generic cleanup pointer')
        extended=dict(inputs['methods'][0]);extended['runtime_function']={'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'bounded_window_bytes':len(code),'end_at_known_next_registered_generic_primary':hex(end),'first_pdata_region_bytes':830,'complete_method_CFG_claimed':False};extended['next_primary_generic_pointer_indices']=next_hits
    out=SLICE/('TypedJoins-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    save(out/'extended-Singleton-input.json',{'schema':'bounded-original-Singleton-Awake-continuation-input/v1','methods':[extended],'whole_method_CSharp_recovered':False})
    report={'schema':'original-startup-foundation-typed-native-joins/v1','status':'typed_original_calls_and_rgctx_recorded_no_guessed_method_body','Root_decode_receipt':{'path':str(receipt),'sha256':RECEIPT_SHA},'direct_original_pointer_aliases':direct,'alias_table_gaps':gaps,'controlflow_sites':site_rows,'RIP_metadata_uses':{hex(k):val for k,val in rip.items()},'original_rgctx_contexts':contexts,'Singleton_first_region_does_not_close':'830-byte entry region falls through at0x18333e73e and has conditional branch target0x18333e7b0 outside it. New960-byte input is bounded by registered generic cleanup0x18333e7c0; no full-method body is claimed before fresh decode/CFG proof.','extended_Singleton_input':{'path':str(out/'extended-Singleton-input.json'),'sha256':sha(out/'extended-Singleton-input.json')},'Main_changed':False,'compiler_Unity_game_network_executed':False}
    save(out/'report.json',report)
    print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'sha256':sha(out/'report.json'),'direct_targets':len(direct),'metadata_uses':len(rip),'extended_Singleton_input':report['extended_Singleton_input']}))
if __name__=='__main__':main()
