"""Canonical original-native Shader identity/PPtr census; no Unity/Main writes."""
from pathlib import Path
import ctypes, datetime as dt, hashlib, json, shutil, struct, subprocess, sys, time, uuid, re
HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE))
import read_original_ag_shader_models as guard
ROOT=guard.ROOT
CENSUS=ROOT/'AssetRecovery/AllOriginalShaderCoverage-v3-20261023T030801Z-3f3c3f65/report.json'
NATIVE=ROOT/'AssetRecovery/AllOriginalNativeShaderIndex-20261023T030717Z-23472c40/report.json'
GRAPH=ROOT/'AssetRecovery/ExistingMainShaderDependencyGraph-20261023T030029Z-4d0169ae/data-report.json'
def need(x,m):
    if not x:raise ValueError(m)
def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def pin(p):return {'path':str(p),'bytes':p.stat().st_size,'sha256':sha(p)}
def key(path,pid):return (str(Path(path).resolve()).lower(),str(pid))
def worker(out):
    for p,h in [(CENSUS,'e7044451212244a3ce70839cc7f153f5636a2f53c4b10d816fe672f52c9b3e71'),(NATIVE,'5df700d8e636e15b1d54b4687f7ccbd30b50f77436946800f6e2b9506c3a1023'),(GRAPH,'cccaeb4d8a3bc4a88ce02056b4ce15e227ba19068869c9b8f92df7928a7edb60')]:need(sha(p)==h,'Frozen complete identity/namespace/Main graph changed')
    c,n,g=[json.loads(p.read_bytes()) for p in (CENSUS,NATIVE,GRAPH)]
    need(c['status']=='all179_original_cooked_and_retained_typed_data_validated' and len(c['Main_shaders'])==179,'Entire179 typed original identity required')
    containers={str(Path(a['path']).resolve()).lower():a for a in n['native_containers'] if 'externals' in a}
    source_rows={key(a['source_path'],a['path_id']):a for a in n['known_shader_names_and_native_identity'] if a['origin']=='original_native_container'}
    main_graph={a['guid']:a for a in g['shaders']}
    original_to_main={};canonical=[]
    for a in c['Main_shaders']:
        choices=[]
        for proof in a['validated_originals']:
            obj=c['source_objects'][proof['source_index']]
            if obj['source']['origin']!='original_native_container':continue
            k=key(obj['source']['source_path'],obj['source']['path_id'])
            need(k not in original_to_main or original_to_main[k]['guid']==a['guid'],'Original identity maps ambiguously to different Main shaders')
            original_to_main[k]={'guid':a['guid'],'name':a['name'],'asset':a['asset'],'raw':obj['raw'],'proof':proof}
            choices.append((obj,proof))
        need(choices,'Every Main Shader must have an exact native original')
        def priority(v):
            p=Path(v[0]['source']['source_path'])
            return ({'resources.assets':0,'globalgamemanagers.assets':1}.get(p.name,2),str(p),int(v[0]['source']['path_id']))
        obj,proof=min(choices,key=priority)
        canonical.append({'Main_name':a['name'],'Main_guid':a['guid'],'Main_asset':a['asset'],'Main_asset_sha256':a['sha256'],'Main_meta_sha256':a['meta_sha256'],'source':obj['source'],'raw':obj['raw'],'complete_original_identity_proof':proof,'equivalent_alternatives':a['validated_originals'],'dependencies':[]})
    unresolved={};edge_count=0
    for a in canonical:
        source=a['source'];container=containers[str(Path(source['source_path']).resolve()).lower()]
        deps=a['complete_original_identity_proof']['pointer_closure']['dependencies'];existing=main_graph[a['Main_guid']]['dependencies']
        need(len(deps)==len(existing),'Original typed dependency count differs from existing Main graph')
        for index,(dep,current) in enumerate(zip(deps,existing)):
            edge_count+=1;file_id,pid=dep['file_id'],dep['path_id'];external=None
            if file_id==0:destination=Path(source['source_path'])
            else:
                need(1<=file_id<=len(container['externals']),'Original external FileID outside exact metadata')
                external=container['externals'][file_id-1];s=bytes.fromhex(external['path_hex']).decode('utf-8')
                if s.startswith('Library/'):
                    destination=ROOT/'VerifiedSource/RecRoom_Data/Resources'/Path(s).name
                else:destination=ROOT/'VerifiedSource/RecRoom_Data'/s
                need(destination.resolve().is_relative_to(ROOT/'VerifiedSource/RecRoom_Data'),'Original external escaped verified source')
            k=key(destination,pid);target=source_rows.get(k)
            need(target is not None,'Typed Shader dependency destination is not indexed native Class48')
            edge={'dependency_index':index,'original_PPtr':dep,'original_external':external,'target_source':target,'existing_Main_reference':current}
            matched=original_to_main.get(k)
            if matched:
                need(current['guid']==matched['guid'] and current['local_file_id']==4800000 and current['YAML_type']==2,'Original target identity differs from current Main project dependency')
                edge.update(classification='exact_original_target_to_Main_project_Shader',target_Main_guid=matched['guid'],target_Main_name=matched['name'],target_Main_asset=matched['asset'],target_raw=matched['raw'],target_identity_proof=matched['proof']['proof_receipt'])
            else:
                need(current['guid']=='0000000000000000f000000000000000' and current['YAML_type']==0,'Unmapped target is not an existing known builtin')
                edge.update(classification='original_Class48_to_existing_builtin_requires_Editor_identity_witness',target_Editor_builtin_path_id=current['local_file_id'])
                unresolved.setdefault(k,{'source':target,'expected_Editor_builtin_path_id':current['local_file_id'],'edge_count':0})['edge_count']+=1
            a['dependencies'].append(edge)
    targets=[]
    for i,(k,target) in enumerate(sorted(unresolved.items())):
        source=target['source'];p=Path(source['source_path'])
        need(0<source['byte_size']<=8*1024**2,'Bounded native dependency object')
        with p.open('rb') as f:f.seek(source['byte_offset']);raw=f.read(source['byte_size'])
        need(len(raw)==source['byte_size'],'Complete exact native dependency range')
        rawpath=out/('Dependency-'+str(i)+'.bin');rawpath.write_bytes(raw)
        # Strings are discovery only. The complete generated model is the name authority.
        strings=[]
        for m in re.finditer(rb'[\x20-\x7e]{4,200}',raw):
            if b'/' in m[0] and m.start()>=4 and struct.unpack_from('<i',raw,m.start()-4)[0]==len(m[0]):strings.append(m[0].decode('ascii'))
        targets.append(dict(target,raw=pin(rawpath),length_prefixed_name_discovery_only=strings))
    report={'schema':'all179-original-native-Shader-canonical-PPtr-closure/v1','status':'project_Shader_closure_complete_builtin_identity_witness_pending','census':pin(CENSUS),'native_metadata_index':pin(NATIVE),'existing_Main_dependency_graph':pin(GRAPH),'canonical_shaders':canonical,'builtin_identity_targets':targets,'summary':{'Main_shaders':len(canonical),'canonical_source_namespaces':len({a['source']['source_path'] for a in canonical}),'typed_original_Shader_edges':edge_count,'project_edges':sum(e['classification']=='exact_original_target_to_Main_project_Shader' for a in canonical for e in a['dependencies']),'builtin_edges':sum(e['classification']!='exact_original_target_to_Main_project_Shader' for a in canonical for e in a['dependencies']),'unique_builtin_source_targets':len(targets),'nonmodifiable_textures':0,'source_original_to_Main_identity_pairs':len(original_to_main)},'selection_by_name_alone':False,'Main_modified':False,'Unity_or_compiler_launched':False}
    (out/'report.json').write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'report':pin(out/'report.json'),'summary':report['summary'],'builtin_targets':targets}),flush=True)
def main():
    if len(sys.argv)==3 and sys.argv[1]=='--worker':return worker(Path(sys.argv[2]))
    need(len(sys.argv)==1,'No arbitrary inputs')
    out=ROOT/'AssetRecovery'/('AllOriginalShaderDependencyClosure-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    cap,reserve=256*1024**2,int(1.5*1024**3)
    need(guard.memory().available_commit>=cap+reserve,'Owned pure-data closure reserve refused')
    job=guard.ChildJob();limits=guard.ExtendedJob();limits.basic.flags=0x2000|0x200;limits.job_memory=cap
    need(job.kernel.SetInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits)),'Cannot set closure cap')
    child=None;receipt={'cap_bytes':cap,'reserve_bytes':reserve,'tool':pin(Path(__file__))}
    try:
        with (out/'worker.log').open('xb') as log:
            child,receipt['launch']=guard.launch_suspended_in_job([sys.executable,'-B',str(Path(__file__).resolve()),'--worker',str(out)],job=job,cwd=out,stdout=log,stderr=subprocess.STDOUT)
            start=time.monotonic()
            while child.poll() is None:
                need(guard.memory().available_commit>=reserve and time.monotonic()-start<=60,'Owned closure time/commit reserve');time.sleep(.1)
            receipt['exit_code']=child.returncode
        q=job.kernel.QueryInformationJobObject;q.argtypes=[ctypes.c_void_p,ctypes.c_int,ctypes.c_void_p,ctypes.c_ulong,ctypes.c_void_p];q.restype=ctypes.c_int
        need(q(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits),None),'Cannot query closure peak');receipt['peak_job_bytes']=int(limits.peak_job)
    except BaseException as error:receipt['error']=repr(error)
    finally:
        job.close()
        if child is not None:child.wait(timeout=10)
        (out/'outer-job-report.json').write_text(json.dumps(receipt,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'directory':str(out),**receipt}),flush=True)
    return 0 if receipt.get('exit_code')==0 and not receipt.get('error') else 1
if __name__=='__main__':raise SystemExit(main())
