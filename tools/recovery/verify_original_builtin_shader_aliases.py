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
    from compare_shader_parsed_form import field_lines
    closure=ROOT/'AssetRecovery/AllOriginalShaderDependencyClosure-20261023T031117Z-132fb863/report.json'
    editor=ROOT/'AssetRecovery/GenuineEditorBuiltinShaderIdentities-20261023T031035Z-a16ac0b1/run-report.json'
    need(sha(closure)=='e49bd5bb3c1901521134fb0e6a3c1e3994f16e71f48fd3270ba86f7dc34f9199','Frozen original closure changed')
    need(sha(editor)=='eec9083d39b9e9e2f788d8778cfd100bb0877cc42dace9880c3d2f629891a991','Frozen genuine Editor identity proof changed')
    c,e=[json.loads(p.read_bytes()) for p in (closure,editor)]
    need(e['status']=='all_four_genuine_Editor_builtin_Class48_IDs_entirely_ReadEditor_verified','Actual genuine Editor identities required')
    identities={i['native_path_id']:i for i in e['identities']};results=[];phases=[]
    for index,target in enumerate(c['builtin_identity_targets']):
        identity=identities[target['expected_Editor_builtin_path_id']]
        need(sha(Path(target['raw']['path']))==target['raw']['sha256'],'Frozen original target raw changed')
        name=identity['actual_name'];folder=out/('Model-'+str(index))
        phase=guard.phase([str(guard.DOTNET),str(guard.HOST),target['raw']['path'],target['raw']['sha256'],target['source']['path_id'],name,str(folder)],out,'original-builtin-'+str(index))
        phases.append(phase);need(phase.get('exit_code')==0 and not phase.get('error'),'Entire original target reader failed')
        model_path=folder/'report.json';model=json.loads(model_path.read_bytes())
        need(model['status']=='parsed_entire_original_object' and model['consumed_bytes']==model['total_bytes']==target['raw']['bytes'] and model['actual_name']==name,'Entire actual original semantic identity failed')
        need(sha(Path(identity['parsed_form']['path']))==identity['parsed_form']['sha256'],'Editor ParsedForm proof changed')
        raw_properties=field_lines(Path(model['parsed_form']['path']),'m_PropInfo');editor_properties=field_lines(Path(identity['parsed_form']['path']),'m_PropInfo')
        norm=lambda rows:[x.rstrip().replace("'<noninit>'",'<noninit>') for x in rows]
        equal=norm(raw_properties)==norm(editor_properties)
        original_names=[x.split(':',1)[1].strip() for x in raw_properties if x.lstrip().startswith('- m_Name:')]
        need(equal,'Original alias property descriptors differ from exact genuine Editor builtin')
        results.append({'original_source':target['source'],'original_raw':target['raw'],'entire_original_model':pin(model_path),'original_ParsedForm':pin(Path(model['parsed_form']['path'])),'actual_original_name':name,'original_property_names':original_names,'entire_property_descriptor_subtree_equal':equal,'Editor_identity':identity,'Editor_builtin_external':identity['genuine_external_target'],'original_full_ParsedForm_equal_to_Editor_claimed':False,'presentation_policy':['outer indentation/line terminators','trailing YAML whitespace','exact noninit quote spelling']})
    report={'schema':'all179-original-Shader-builtin-alias-semantic-closure/v1','status':'all_four_original_Class48_aliases_and_Editor_builtin_names_and_property_descriptors_verified','canonical_manifest':pin(closure),'genuine_Editor_identity_receipt':pin(editor),'identities':results,'phases':phases,'Main_modified':False,'Unity_or_compiler_launched':False,'native_API_or_game_code_executed':False}
    (out/'report.json').write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'report':pin(out/'report.json'),'status':report['status']}),flush=True)
def main():
    if len(sys.argv)==3 and sys.argv[1]=='--worker':return worker(Path(sys.argv[2]))
    need(len(sys.argv)==1,'No arbitrary inputs')
    out=ROOT/'AssetRecovery'/('OriginalShaderBuiltinAliasClosure-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    cap,reserve=512*1024**2,int(1.5*1024**3)
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
