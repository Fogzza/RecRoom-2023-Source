"""Bounded pure data decoding for original/built D3D11 Shader program comparison."""
from pathlib import Path
import hashlib, re, struct
from stage_original_stencil_shader import spans

def need(value,message):
    if not value: raise ValueError(message)
def digest(data): return hashlib.sha256(data).hexdigest()
def uints(text):
    raw=bytes.fromhex(text.strip());need(len(raw)%4==0,'UInt32 field width')
    return [item[0] for item in struct.iter_unpack('<I',raw)]
def yaml_program(path):
    raw=Path(path).read_bytes();parts=spans(raw)
    field=lambda name:raw[slice(*parts[name])].decode().splitlines()
    return {'platforms':uints(field('platforms')[0].split(':',1)[1]),
        **{name:[uints(line.strip()[2:]) for line in field(name)[1:]] for name in ('offsets','compressedLengths','decompressedLengths')},
        'blob':bytes.fromhex(field('compressedBlob')[0].split(':',1)[1].strip())}
def model_program(model,raw):
    fields=model['fields'];size=fields['compressedBlob']['bytes'];wanted=fields['compressedBlob']['sha256']
    need(0<size<=8*1024**2,'Nonempty bounded output program data')
    prefix=struct.pack('<I',size);found=[];start=0
    while True:
        at=raw.find(prefix,start)
        if at<0:break
        start=at+1;block=raw[at+4:at+4+size]
        if len(block)==size and digest(block)==wanted:found.append(block)
    need(len(found)==1,'One model-proven original length-prefixed blob')
    return {'platforms':fields['Platforms'],**{name:fields[key+'_AssetList_AssetList_UInt32'] for name,key in [('offsets','Offsets'),('compressedLengths','CompressedLengths'),('decompressedLengths','DecompressedLengths')]},'blob':found[0]}
def lz4(data,expected):
    need(0<expected<=32*1024**2,'Shader decompression bound');out=bytearray();at=0
    def length(value):
        nonlocal at
        if value==15:
            while True:
                need(at<len(data),'LZ4 extension truncated');extra=data[at];at+=1;value+=extra
                if extra!=255:break
        return value
    while at<len(data):
        token=data[at];at+=1;n=length(token>>4)
        need(at+n<=len(data) and len(out)+n<=expected,'LZ4 literal bounds');out.extend(data[at:at+n]);at+=n
        if at==len(data):break
        need(at+2<=len(data),'LZ4 offset truncated');offset=int.from_bytes(data[at:at+2],'little');at+=2;n=length(token&15)+4
        need(0<offset<=len(out) and len(out)+n<=expected,'LZ4 match bounds')
        for _ in range(n):out.append(out[-offset])
    need(at==len(data) and len(out)==expected,'Exact Shader decompressed length');return bytes(out)
def dxbc(data):
    result=[];start=0
    while True:
        at=data.find(b'DXBC',start)
        if at<0:break
        start=at+4
        if at+32>len(data):continue
        version,total,count=struct.unpack_from('<III',data,at+20)
        if version!=1 or not 0<count<=64 or not 32+count*4<=total<=len(data)-at:continue
        offsets=struct.unpack_from('<'+'I'*count,data,at+32)
        valid=True
        for off in offsets:
            if not 32+count*4<=off<=total-8:valid=False;break
            size=struct.unpack_from('<I',data,at+off+4)[0]
            if size>total-off-8:valid=False;break
        if valid:result.append({'offset':at,'bytes':total,'sha256':digest(data[at:at+total])});start=at+total
    return result
def program_facts(program):
    need(program['platforms'].count(4)==1,'Exactly one original D3D11 platform required')
    p=program['platforms'].index(4);offsets=program['offsets'][p];compressed=program['compressedLengths'][p];decompressed=program['decompressedLengths'][p]
    need(len(offsets)==len(compressed)==len(decompressed)>0,'D3D11 program segment dimensions');segments=[];all_chunks=[]
    for index,(off,size,outsize) in enumerate(zip(offsets,compressed,decompressed)):
        need(0<=off and 0<size and off+size<=len(program['blob']),'Compressed program range')
        data=lz4(program['blob'][off:off+size],outsize);chunks=dxbc(data)
        segments.append({'segment':index,'decompressed_bytes':len(data),'decompressed_sha256':digest(data),'dxbc':chunks});all_chunks.extend(chunks)
    need(all_chunks,'No structurally valid original DXBC program chunks')
    return {'platform':4,'blob_bytes':len(program['blob']),'blob_sha256':digest(program['blob']),'segments':segments,'dxbc_chunks':len(all_chunks),'unique_dxbc_sha256':sorted({r['sha256'] for r in all_chunks})}
