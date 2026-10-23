"""Inspect one bounded original AG shader segment as data; never execute GPU code."""
from pathlib import Path
import argparse
from collections import Counter
import ctypes
import datetime as dt
import hashlib
import json
import os
import struct
import subprocess
import sys
import time
import uuid

HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]
ROOT=WS/'Recovery/RecRoom-2023-04-18'
OBJECT=ROOT/'AssetRecovery/OriginalShaderRecoveryRoute-20261022T184808Z-356f2e1f/OriginalSerializedShaderObjects/native-6351.bin'
OBJECT_SHA='b7a537500bf6b84af05ea8c49110b291f1fb3d7e26eab787d0be2f3bd0433074'
MODEL=ROOT/'AssetRecovery/OriginalAGShaderModels-20261022T203556Z-4b62253a/native-Object/report.json'
MODEL_SHA='3c77fde3c14f517ec64c64e49194d372f4f884e11e5b4bcdc2caf60883f0f7b3'
CAP=256*1024**2
RESERVE=int(1.5*1024**3)


def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()


def need(v,message):
    if not v:raise RuntimeError(message)


def save(path,value):
    with path.open('xb') as f:f.write((json.dumps(value,indent=2)+'\n').encode())


def child(folder):
    need(sha(OBJECT)==OBJECT_SHA and sha(MODEL)==MODEL_SHA,'Pinned original AG inputs changed')
    from shader_program_data import model_program,lz4,dxbc
    model=json.loads(MODEL.read_bytes())
    program=model_program(model,OBJECT.read_bytes())
    need(program['platforms']==[4],'Original D3D11-only input required')
    off,size,count=program['offsets'][0][0],program['compressedLengths'][0][0],program['decompressedLengths'][0][0]
    need(0<count<=17*1024**2,'Only first original segment may be decompressed')
    data=lz4(program['blob'][off:off+size],count)
    rows=dxbc(data)
    chunks=Counter();profiles=Counter();debug=0;reflection=0;records=[]
    for row in rows:
        at=row['offset'];length=row['bytes'];n=struct.unpack_from('<I',data,at+28)[0]
        names=[];profile=None
        for i in range(n):
            p=at+struct.unpack_from('<I',data,at+32+4*i)[0]
            tag=data[p:p+4].decode('ascii');names.append(tag);chunks[tag]+=1
            if tag in ('SHDR','SHEX'):
                token=struct.unpack_from('<I',data,p+8)[0]
                typ=token>>16;major=(token>>4)&15;minor=token&15
                profile={0:'ps',1:'vs',2:'gs',3:'hs',4:'ds',5:'cs'}.get(typ,'unknown')+'_'+str(major)+'_'+str(minor)
                profiles[profile]+=1
        debug+=int(bool(set(names)&{'SDBG','SPDB','ILDB','PDBI'}));reflection+=int('RDEF' in names)
        if len(records)<8:records.append({**row,'profile':profile,'chunk_types':names})
    need(rows,'At least one valid original DXBC required')
    save(folder/'first-segment-dxbc-inspection.json',{'schema':'original-AG-one-segment-DXBC-source-feasibility/v1','status':'pure_data_inspection_complete',
        'original_object_sha256':OBJECT_SHA,'model_sha256':MODEL_SHA,'segment':0,'segments_total':len(program['offsets'][0]),
        'decompressed_segment_bytes':len(data),'decompressed_segment_sha256':hashlib.sha256(data).hexdigest(),
        'DXBC_programs_in_segment':len(rows),'unique_DXBC_sha256_in_segment':len({x['sha256'] for x in rows}),
        'chunk_type_counts':dict(chunks),'profile_counts':dict(profiles),'programs_with_RDEF':reflection,'programs_with_debug_chunks':debug,
        'first_eight_programs':records,'all_shader_segments_inspected':False,'original_HLSL_recovered':False,
        'Main_modified':False,'Editor_launched':False,'GPU_or_game_or_vendor_SDK_executed':False})


def main():
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--_internal',type=Path,help=argparse.SUPPRESS);args=parser.parse_args()
    if args._internal:return child(args._internal)
    sys.path.insert(0,str(ROOT/'Tools'))
    from export_bundle_batches import ChildJob,ExtendedJob
    from guarded_cpp2il import memory
    from owned_suspended_launch import launch_suspended_in_job
    need(os.name=='nt' and memory().available_commit>=CAP+RESERVE,'Owned256MiB+1.5GiB reserve required')
    stamp=dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]
    out=ROOT/'AssetRecovery'/('ShaderBuildableSourceFeasibility-'+stamp);out.mkdir()
    job=ChildJob();limits=ExtendedJob();limits.basic.flags=0x2000|0x200;limits.job_memory=CAP
    need(job.kernel.SetInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits)),'Cannot set owned job cap')
    proc=None;report={'status':'starting','cap_bytes':CAP,'reserve_bytes':RESERVE,'Main_modified':False,'Editor_launched':False,'tool_sha256':sha(__file__)}
    try:
        with (out/'private-stdout.log').open('xb') as stdout,(out/'private-stderr.log').open('xb') as stderr:
            proc,report['launcher']=launch_suspended_in_job([sys.executable,'-B',str(Path(__file__).resolve()),'--_internal',str(out)],job=job,cwd=HERE,stdout=stdout,stderr=stderr)
            start=time.monotonic()
            while proc.poll() is None:
                need(time.monotonic()-start<45 and memory().available_commit>=RESERVE,'Owned data-reader wall/memory guard');time.sleep(.1)
        need(proc.returncode==0,'Pure shader-data reader failed')
        q=job.kernel.QueryInformationJobObject;q.argtypes=[ctypes.c_void_p,ctypes.c_int,ctypes.c_void_p,ctypes.c_uint32,ctypes.c_void_p];q.restype=ctypes.c_int
        v=ExtendedJob();need(q(job.handle,9,ctypes.byref(v),ctypes.sizeof(v),None),'Cannot query owned peak')
        report.update(status='complete',peak_job_bytes=int(v.peak_job),inspection_sha256=sha(out/'first-segment-dxbc-inspection.json'))
    finally:
        job.close()
        if proc is not None:report['owned_child_exit_confirmed']=proc.wait(timeout=10) is not None
        save(out/'run-report.json',report)
    observed=json.loads((out/'first-segment-dxbc-inspection.json').read_bytes())
    print(json.dumps({'report':str(out/'run-report.json'),'sha256':sha(out/'run-report.json'),'peak_job_bytes':report['peak_job_bytes'],
                      'programs':observed['DXBC_programs_in_segment'],'unique':observed['unique_DXBC_sha256_in_segment'],
                      'chunk_types':observed['chunk_type_counts'],'profiles':observed['profile_counts'],'debug_programs':observed['programs_with_debug_chunks']}))


if __name__=='__main__':main()
