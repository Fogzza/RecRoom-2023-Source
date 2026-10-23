"""Read only original serialized metadata, bounded owned pure-data child."""
from pathlib import Path
import ctypes, datetime as dt, hashlib, importlib.util, json, re, shutil, struct, subprocess, sys, time, uuid
HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE))
import read_original_ag_shader_models as guard
ROOT=guard.ROOT
BASE=ROOT/'AssetRecovery/OriginalShaderSourceProbe-20261022T184321Z-dfa2d738/report.json'
PARSER=ROOT/'AssetRecovery/OriginalFallbackNativeSerializedInput-20261022T205430Z-cab1d2e4/stage_input.py'
def need(x,m):
    if not x: raise ValueError(m)
def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def pin(p):return {'path':str(p),'bytes':p.stat().st_size,'sha256':sha(p)}
def worker(out):
    need(sha(BASE)=='466da3d8ddab16fe33dede9d4f900262ba99a6a901fb836282df0188e2536847','Frozen source index changed')
    need(sha(PARSER)=='98b4cd637d310605981a57a7284660096dc4d2d4e8fa6b0f5240a41d4e2b02ae','Frozen native parser changed')
    spec=importlib.util.spec_from_file_location('proven_native',PARSER); parser=importlib.util.module_from_spec(spec);spec.loader.exec_module(parser)
    base=json.loads(BASE.read_bytes());rows=list(base['known_shader_names_and_native_identity'])
    original=ROOT/'VerifiedSource/RecRoom_Data'
    inventory_path=ROOT/'Preflight/public-archive-inventory.json'
    inventory={r[0]:r for r in json.loads(inventory_path.read_bytes())['files']}
    existing={(r['source_path'],str(r['path_id'])) for r in rows}
    paths=sorted(p for p in original.iterdir() if p.is_file() and re.fullmatch(r'(?:sharedassets\d+\.assets|level\d+|resources\.assets|globalgamemanagers\.assets)',p.name))
    paths += [original/'Resources/unity_builtin_extra',original/'Resources/unity default resources']
    report={'schema':'bounded-complete-original-native-Shader-index/v1','status':'starting','source_index':pin(BASE),'native_parser':pin(PARSER),'archive_inventory':pin(inventory_path),'known_shader_names_and_native_identity':rows,'native_containers':[], 'Main_modified':False,'Unity_or_compiler_launched':False,'full_containers_hashed_or_read':False}
    for p in paths:
        before=p.stat();relative=p.relative_to(ROOT/'VerifiedSource').as_posix();expected=inventory[relative]
        need(before.st_size==expected[1],'Original file length changed')
        with p.open('rb') as f:
            header=f.read(48);legacy=struct.unpack_from('>IIII',header);ms,size,offset,unknown=struct.unpack_from('>IQQQ',header,20)
            need(legacy==(0,0,22,0) and header[16:20]==bytes(4) and unknown==0 and size==before.st_size and 0<ms<=16*1024**2 and 48+ms<=offset<=size,'Pinned v22 metadata bounds')
            metadata=f.read(ms)
        need(len(metadata)==ms,'Complete metadata read')
        parsed=parser.parse_metadata(metadata,offset,size)
        need(parsed['platform']==19 and not parsed['has_type_tree'],'Original Windows player metadata required')
        shaders=[]
        for obj in parsed['objects']:
            typ=parsed['types'][obj['type_index']]
            if typ['class_id']!=48:continue
            row={'origin':'original_native_container','source_file':str(p),'source_path':str(p),'name':'','path_id':str(obj['path_id']),'byte_offset':obj['offset'],'byte_size':obj['size'],'class_id':48,'type_index':obj['type_index'],'old_type_hash':typ['old_type_hash']}
            shaders.append(row)
            if (str(p),row['path_id']) not in existing:
                rows.append(row);existing.add((str(p),row['path_id']))
        report['native_containers'].append({'path':str(p),'bytes':size,'expected_original_archive_sha256':expected[2],'metadata_bytes':ms,'metadata_sha256':hashlib.sha256(metadata).hexdigest(),'header_sha256':hashlib.sha256(header).hexdigest(),'engine':parsed['engine'],'platform':parsed['platform'],'entire_metadata_consumed':True,'object_count':len(parsed['objects']),'shader_objects':shaders,'externals':parsed['externals']})
        need((p.stat().st_size,p.stat().st_mtime_ns)==(before.st_size,before.st_mtime_ns),'Original metadata source changed during read')
        del parsed,metadata
    report['status']='all_original_native_metadata_indexed_no_shader_identity_inferred'
    report['summary']={'native_containers':len(paths),'native_shaders':sum(len(r['shader_objects']) for r in report['native_containers']),'source_rows':len(rows),'metadata_bytes_read':sum(r['metadata_bytes'] for r in report['native_containers'])}
    (out/'report.json').write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'report':pin(out/'report.json'),'summary':report['summary']}),flush=True)
def main():
    if len(sys.argv)==3 and sys.argv[1]=='--worker':return worker(Path(sys.argv[2]))
    need(len(sys.argv)==1,'No arbitrary inputs')
    out=ROOT/'AssetRecovery'/('AllOriginalNativeShaderIndex-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    cap,reserve=512*1024**2,int(1.5*1024**3)
    need(guard.memory().available_commit>=cap+reserve and shutil.disk_usage(out).free>=4*1024**3,'Owned metadata reader reserve refused')
    job=guard.ChildJob(); limits=guard.ExtendedJob();limits.basic.flags=0x2000|0x200;limits.job_memory=cap
    need(job.kernel.SetInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits)),'Cannot set metadata cap')
    child=None;receipt={'cap_bytes':cap,'reserve_bytes':reserve,'maximum_seconds':180,'tool':pin(Path(__file__))}
    try:
        with (out/'worker.log').open('xb') as log:
            child,receipt['launch']=guard.launch_suspended_in_job([sys.executable,'-B',str(Path(__file__).resolve()),'--worker',str(out)],job=job,cwd=out,stdout=log,stderr=subprocess.STDOUT)
            start=time.monotonic()
            while child.poll() is None:
                need(guard.memory().available_commit>=reserve and time.monotonic()-start<=180,'Owned metadata reader time/commit reserve')
                time.sleep(.1)
            receipt['exit_code']=child.returncode
        q=job.kernel.QueryInformationJobObject;q.argtypes=[ctypes.c_void_p,ctypes.c_int,ctypes.c_void_p,ctypes.c_ulong,ctypes.c_void_p];q.restype=ctypes.c_int
        need(q(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits),None),'Cannot query metadata peak');receipt['peak_job_bytes']=int(limits.peak_job)
    except BaseException as error:receipt['error']=repr(error)
    finally:
        job.close()
        if child is not None:child.wait(timeout=10)
        (out/'outer-job-report.json').write_text(json.dumps(receipt,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'directory':str(out),**receipt}),flush=True)
    return 0 if receipt.get('exit_code')==0 and not receipt.get('error') else 1
if __name__=='__main__':raise SystemExit(main())
