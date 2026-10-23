"""Bounded original request-factory/ctor data only; never calls game/managed code."""
from pathlib import Path
import argparse
import hashlib
import json
import mmap
import re
import struct
import sys

HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]
ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED
from audit_native_nameserver_router import Disassembler
from inventory_recroom_game_root_native import region


def pin(path):
    path=Path(path).resolve()
    with path.open('rb') as stream:digest=hashlib.file_digest(stream,'sha256').hexdigest()
    return {'path':str(path),'bytes':path.stat().st_size,'sha256':digest}


def code(v,d,method):
    va=v.method_pointer(method)
    need(va and v.executable(va),'Executable exact registered original method required')
    runtime=region(v,va)
    ins=d.decode(bytes.fromhex(runtime['bytes']),va)
    usages={};targets=set()
    for row in ins:
        if row['mnemonic'] in ('call','jmp') and re.fullmatch('0x[0-9a-f]+',row['operand']):targets.add(int(row['operand'],16))
        match=re.search(r'\[rip ([+-]) 0x([0-9a-f]+)\]',row['operand'])
        if match:
            address=int(row['VA'],16)+row['size']+int(match[2],16)*(1 if match[1]=='+' else -1)
            row['RIP_absolute_address']=hex(address)
            try:
                usage=v.usage(address)
                if usage['kind']==5:usage['literal_values_not_exported']=True
                usages[hex(address)]=usage
            except ValueError:pass
    return {'original':method,'VA':hex(va),'runtime_function':runtime,'instructions':ins,'RIP_metadata_usages':usages},targets


def fields(v,owner):
    t=v.row('typeDefinitions',owner,88)
    start,count=v.i32(v.m,t+32),v.u16(v.m,t+68)
    offsets=v.u64(v.b,v.field_offsets+owner*8)
    result=[]
    for i in range(count):
        f=v.row('fields',start+i,12);typ=v.native_type(v.i32(v.m,f+4))
        result.append({'index':start+i,'token':hex(v.u32(v.m,f+8)),'name':v.string(v.i32(v.m,f)),
                       'type':v.typename(typ),'native_type':typ,'offset':v.i32(v.b,v.raw(offsets+i*4,4))})
    return result


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--out',required=True,type=Path);args=ap.parse_args()
    out=args.out.resolve(strict=True)
    need(out.is_relative_to(ROOT/'Validation'),'New recovery evidence output only')
    paths=[ROOT/'CodeSource'/name for name in EXPECTED]
    inputs=[]
    for path in paths:
        record=pin(path);need(record['sha256']==EXPECTED[path.relative_to(ROOT/'CodeSource').as_posix()],'Exact original input SHA required');inputs.append(record)
    before=[(p.stat().st_size,p.stat().st_mtime_ns) for p in paths]
    d=Disassembler()
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as binary,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(binary,md)
        factory=v.find_method('CDMLNBEJKKH',0x06005de1)
        evidence,targets=code(v,d,factory)
        need(len(bytes.fromhex(evidence['runtime_function']['bytes']))==123
             and evidence['runtime_function']['sha256']=='17d89c7e8d4539a3a8d0b3d419f21535e633634d0d7c2e10d650208ca91f385e','Exact prior123-byte factory region')
        image=next(i for i in v.images if i['name']=='RecNet.Runtime.dll')
        methods=[]
        for ti in range(image['start'],image['start']+image['count']):
            td=v.row('typeDefinitions',ti,88);start,count=v.i32(md,td+36),v.u16(md,td+64)
            for mi in range(start,start+count):methods.append(v.method_info(mi))
        direct={hex(target):[m for m in methods if v.method_pointer(m)==target] for target in targets}
        constructors=[]
        for group in direct.values():
            for m in group:
                if m['name']=='.ctor':
                    ctor,calltargets=code(v,d,m)
                    ctor['declared_fields']=fields(v,m['owner_index'])
                    ctor['direct_original_RecNet_targets']={hex(t):[a for a in methods if v.method_pointer(a)==t] for t in calltargets}
                    constructors.append(ctor)
        types=[]
        for usage in evidence['RIP_metadata_usages'].values():
            if usage['kind'] in (1,2):
                name=usage['type'];matches=[i for i in range(image['start'],image['start']+image['count']) if v.full_name(i)==name]
                for ti in matches:
                    types.append({'type':v.type_info(ti),'fields':fields(v,ti),
                        'methods':[m for m in methods if m['owner_index']==ti]})
        report={'schema':'exact-native-nameserver-request-factory-and-ctor-inputs/v1','status':'bounded_original_data_extracted_not_yet_CFG_proven',
                'inputs':inputs,'factory':evidence,'direct_original_RecNet_targets':direct,'concrete_constructor_regions':constructors,
                'factory_metadata_type_declarations':types,'scope':'Factory123B and directly called native RecNet constructors only; other module aliases not inferred',
                'Main_modified':False,'managed_Unity_game_or_original_native_code_called':False,'network_requests':0,'tool':pin(Path(__file__))}
    d.close()
    need(before==[(p.stat().st_size,p.stat().st_mtime_ns) for p in paths],'Read-only original source race')
    path=out/'factory-native-inputs.json'
    with path.open('x',encoding='utf-8') as stream:json.dump(report,stream,indent=2);stream.write('\n')
    print(json.dumps({'report':pin(path),'factory':factory,'constructors':[c['original'] for c in constructors]}))


if __name__=='__main__':main()
