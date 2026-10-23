"""Bounded pure reader for original AMD64 Microsoft FH4 exception tables.

The grammar is taken from the installed genuine Microsoft ehdata4_export.h.
This never executes a handler or target. It supports only an unseparated,
unchained original function whose EH handler is the observed1806c3c30 entry.
Caller must still bind every catch type, funclet, continuation and call effect.
"""
from pathlib import Path
import hashlib,struct
HEADER=Path('C:/Program Files/Microsoft Visual Studio/18/Community/VC/Tools/MSVC/14.51.36231/include/ehdata4_export.h')
LENGTH=(1,2,1,3,1,2,1,4,1,2,1,3,1,2,1,5)

def need(value,message):
    if not value:raise ValueError(message)

def source_authority():
    data=HEADER.read_bytes();text=data.decode()
    for token in ['namespace FH4','inline uint32_t ReadUnsigned','inline ptrdiff_t DecompFuncInfo','class TryBlockMap4','class HandlerMap4','class IPtoStateMap4','Note: with FH4 there is no magic number']:
        need(token in text,'Genuine installed FH4 grammar contract')
    return {'path':str(HEADER),'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest(),'sections':{'on_disk_grammar':'lines7-69','header_bits':'184-207','compressed_unsigned':'235-309','FuncInfo':'312-379','unwind_entries':'781-799','try_entries':'917-924','handlers':'1031-1076','IP_states':'1181-1187'},'matching_original_compiler_version_claimed':False,'format_note':'Unversioned FH4 data grammar; exact original bytes and resolved targets must also be checked.'}

def unsigned(data,at):
    need(0<=at<len(data),'FH4 compressed integer bound');size=LENGTH[data[at]&15];need(at+size<=len(data),'Complete FH4 compressed integer')
    value=int.from_bytes(data[at:at+size],'little')>>size if size<5 else int.from_bytes(data[at+1:at+5],'little')
    return value,at+size

class Reader:
    def __init__(self,view,rva):
        need(0<rva<2**31,'Positive original table RVA');self.view=view;self.rva=rva;self.at=0
    def take(self,count):
        need(0<count<=256 and self.at+count<=4096,'Bounded individual FH4 table read');raw=self.view.raw(self.view.base+self.rva+self.at,count);value=bytes(self.view.b[raw:raw+count]);self.at+=count;return value
    def byte(self):return self.take(1)[0]
    def int32(self):return int.from_bytes(self.take(4),'little',signed=True)
    def uint(self):
        first=self.take(1);size=LENGTH[first[0]&15];data=first+(self.take(size-1) if size>1 else b'');value,end=unsigned(data,0);need(end==size,'Exact unsigned decode');return value
    def count(self):
        value=self.uint();need(value<=128,'Finite original FH4 entry count');return value
    def evidence(self):
        raw=self.view.raw(self.view.base+self.rva,self.at);data=bytes(self.view.b[raw:raw+self.at]);return {'rva':hex(self.rva),'bytes':self.at,'hex':data.hex(),'sha256':hashlib.sha256(data).hexdigest()}

def parse_function(view,runtime_function):
    """Read one exact pdata(startRVA,endRVA,unwindRVA), without following code."""
    start,end,unwind=runtime_function;need(0<start<end and end-start<=32768,'Bounded original native function')
    raw=view.raw(view.base+unwind,4);head=bytes(view.b[raw:raw+4]);version=head[0]&7;flags=head[0]>>3;count=head[2]
    need(version==1 and flags==3 and count<=64,'Only observed unchained original EH+UH native unwind grammar')
    trailer=(4+2*count+3)&~3;at=view.raw(view.base+unwind+trailer,8);handler=view.u32(view.b,at);info=view.u32(view.b,at+4)
    need(handler==0x6c3c30,'Only the exact observed original FH4-handler entry; no arbitrary handler guessed')
    f=Reader(view,info);header=f.byte();need(not header&0x87 and header&0x20,'Unseparated noncatch/no-BBT/nonreserved EHs FuncInfo only')
    uw=f.int32() if header&8 else 0;tries=f.int32() if header&16 else 0;ip=f.int32();func_evidence=f.evidence();need(ip>0,'Original IP-to-state map required')
    tables=[func_evidence];unwinds=[]
    if uw:
        r=Reader(view,uw);n=r.count()
        for state in range(n):
            entry_at=r.at;encoded=r.uint();kind=encoded&3;row={'state':state,'encoded_entry_offset':entry_at,'next_offset':encoded>>2,'kind':kind}
            if kind:row['action_rva']=hex(r.int32())
            if kind in (1,2):row['object_offset']=r.uint()
            unwinds.append(row)
        tables.append(r.evidence())
    blocks=[]
    if tries:
        r=Reader(view,tries);n=r.count()
        for _ in range(n):
            low,high,catch=r.uint(),r.uint(),r.uint();handlers_rva=r.int32();need(low<=high<catch,'Finite ordered original try/catch states')
            handlers=[];hr=Reader(view,handlers_rva);hn=hr.count()
            for _ in range(hn):
                hh=hr.byte();need(not hh&0xc0 and ((hh>>4)&3)!=3,'Supported original handler header bits');h={'header':hh,'adjectives':hr.uint() if hh&1 else 0,'type_descriptor_rva':hex(hr.int32()) if hh&2 else None,'catch_object_frame_offset':hr.uint() if hh&4 else None,'handler_rva':hex(hr.int32())};number=(hh>>4)&3
                h['continuation_rvas']=[hex(hr.int32() if hh&8 else start+hr.uint()) for _ in range(number)];handlers.append(h)
            tables.append(hr.evidence());blocks.append({'try_low':low,'try_high':high,'catch_high':catch,'handlers':handlers})
        tables.append(r.evidence())
    r=Reader(view,ip);n=r.count();previous=0;states=[]
    for _ in range(n):
        previous+=r.uint();state=r.uint()-1;need(start<=start+previous<end and state>=-1,'Original IP-state row is inside exact function');states.append({'rva':hex(start+previous),'state':state})
    need(all(int(a['rva'],16)<int(b['rva'],16) for a,b in zip(states,states[1:])),'Strict ordered original IP-state intervals');tables.append(r.evidence())
    return {'format':'Microsoft FH4 unseparated EHs','source_authority':source_authority(),'original_runtime_function':[hex(x) for x in runtime_function],'unwind_header_hex':head.hex(),'handler_va':hex(view.base+handler),'FuncInfo_header':header,'try_blocks':blocks,'unwind_entries':unwinds,'IP_states':states,'exact_read_table_spans':tables,'handler_or_game_code_executed':False,'source_finally_equivalence_automatically_claimed':False}

def state_at(parsed,va,base=0x180000000):
    hits=[x['state'] for x in parsed['IP_states'] if int(x['rva'],16)<=va-base]
    return hits[-1] if hits else -1
