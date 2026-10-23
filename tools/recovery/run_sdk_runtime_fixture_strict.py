"""One reviewed SDK-only Unity2020 load, bounded owned job; no game code/Play."""
import argparse,ctypes,hashlib,json,shutil,subprocess,sys,time
from pathlib import Path
from datetime import datetime,timezone
from ctypes import wintypes

HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(ROOT/'Tools'))
from export_bundle_batches import ChildJob,ExtendedJob
from guarded_cpp2il import ProcessMemory,memory
import repair_rr23_wav_headers as safety
EDITOR=WORKSPACE/'Tools/Editors/2020.3.33f1/Editor/Unity.exe'
CLI=Path(r'C:\Users\andre\AppData\Local\Unity\bin\unity.exe')
GIB=1024**3


def need(value,message):
    if not value:raise ValueError(message)


def sha(path):
    with path.open('rb') as stream:return hashlib.file_digest(stream,'sha256').hexdigest()


def validate(path):
    config=json.loads(path.read_text());project=Path(config['project']).resolve(strict=True)
    need(path.parent.is_relative_to(ROOT/'RuntimeSDKRecovery') and path.parent.name.startswith('SDKTextureFixture-') and project==path.parent/'Project','Exact isolated SDK texture project required')
    need(config['status']=='prepared-not-launched' and config['SDK_DLLs']==2 and config['source_original_game_assemblies']==0 and config['source_scenes_or_prefabs']==0 and config['source_class_ids']==[28,142] and config['bundle_dependency_closure_files']==1 and config['execute_method']=='SDKTextureLoadFixture.Run' and config['genuine_SDK_methods_authorized_for_test'] and not config['original_client_or_game_methods_authorized'] and not config['PlayMode'] and not config['original_RR23_changed'],'Exact reviewed SDK-only fixture scope required')
    safety.assert_no_reparse(project)
    for row in config['inputs']:need(sha(Path(row['path']))==row['sha256'],'Fixture input/proof changed')
    expected={}
    for row in config['files']:
        relative=Path(row['path']);target=project/relative
        need(not relative.is_absolute() and target.resolve(strict=True).is_relative_to(project) and str(relative).casefold() not in expected,'Duplicate/escaping fixture path')
        safety.assert_no_reparse(target);need(sha(target)==row['sha256'],'Prepared fixture changed: '+str(relative));expected[str(relative).casefold()]=row
    need(len([r for r in config['files'] if r['path'].endswith('.dll')])==2 and len([r for r in config['files'] if r['path'].endswith('.cs')])==1,'Only two SDK DLLs and one trusted Editor source allowed')
    for file in (project/'Assets').rglob('*'):
        safety.assert_no_reparse(file)
        if file.is_file():need(str(file.relative_to(project)).casefold() in expected,'Unexpected fixture Asset file: '+str(file))
    for name in ('run-report.json','Editor.log','cli-stdout.json','cli-stderr.log'):need(not (path.parent/name).exists(),'Fresh fixture run outputs required')
    need(not (project/'FixtureInputs/result.json').exists() and not (project/'Temp/UnityLockfile').exists(),'No stale result/editor lock allowed')
    return config,project


def main():
    p=argparse.ArgumentParser();p.add_argument('--preparation',type=Path,required=True);p.add_argument('--job-cap-mib',type=int,choices=(768,),default=768);p.add_argument('--run',action='store_true');a=p.parse_args()
    path=a.preparation.resolve(strict=True);config,project=validate(path)
    if not a.run:print(json.dumps({'status':'validated-not-launched','preparation':str(path),'sha256':sha(path),'project':str(project),'job_cap_mib':a.job_cap_mib}));return 0
    safety.assert_editor_closed();cap=a.job_cap_mib*1024**2;reserve=int(1.5*GIB)
    need(memory().available_commit>=cap+reserve and shutil.disk_usage(project).free>=4*GIB,'Insufficient reviewed SDK fixture commit/disk admission')
    report={'schema':'genuine-sdk-original-texture-Unity2020-runtime/v1','status':'starting','project':str(project),'preparation':str(path),'preparation_sha256':sha(path),'owned_job_cap_bytes':cap,'minimum_system_commit_bytes':reserve,'maximum_seconds':180,'original_client_or_game_methods_invoked':False,'SDK_methods_authorized':True,'PlayMode':False,'original_RR23_changed':False,'samples':[]}
    started=time.monotonic();job=None;handle=None;launch=None;log=path.parent/'Editor.log';kernel=ctypes.WinDLL('kernel32',use_last_error=True)
    kernel.OpenProcess.argtypes=[wintypes.DWORD,wintypes.BOOL,wintypes.DWORD];kernel.OpenProcess.restype=wintypes.HANDLE
    kernel.GetExitCodeProcess.argtypes=[wintypes.HANDLE,ctypes.POINTER(wintypes.DWORD)];kernel.GetExitCodeProcess.restype=wintypes.BOOL
    kernel.IsProcessInJob.argtypes=[wintypes.HANDLE,wintypes.HANDLE,ctypes.POINTER(wintypes.BOOL)];kernel.IsProcessInJob.restype=wintypes.BOOL
    kernel.TerminateProcess.argtypes=[wintypes.HANDLE,wintypes.UINT];kernel.TerminateProcess.restype=wintypes.BOOL;kernel.CloseHandle.argtypes=[wintypes.HANDLE]
    api=ctypes.WinDLL('psapi',use_last_error=True).GetProcessMemoryInfo;api.argtypes=[wintypes.HANDLE,ctypes.POINTER(ProcessMemory),wintypes.DWORD];api.restype=wintypes.BOOL
    try:
        job=ChildJob();limits=ExtendedJob();limits.basic.flags=0x2000|0x200;limits.job_memory=cap;need(job.kernel.SetInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits)),'Cannot cap owned SDK fixture job')
        extra=subprocess.list2cmdline(['-batchmode','-nographics','-disable-assembly-updater','-job-worker-count','1','-executeMethod',config['execute_method'],'-logFile',str(log),'-quit'])
        command=[str(CLI),'open',str(project),'--editor-path',str(EDITOR),'--args',extra,'--format','json'];report['command']=command
        stdout=path.parent/'cli-stdout.json';stderr=path.parent/'cli-stderr.log'
        with stdout.open('xb') as out,stderr.open('xb') as err:
            launch=subprocess.Popen(command,cwd=project,stdout=out,stderr=err,creationflags=subprocess.CREATE_NO_WINDOW);report['owned_cli_pid']=launch.pid;job.attach(launch)
            while launch.poll() is None:need(time.monotonic()-started<30 and memory().available_commit>=reserve,'CLI admission/launch bound');time.sleep(.1)
        need(stdout.stat().st_size<=262144,'Bounded CLI result required');returned=json.loads(stdout.read_text(encoding='utf-8-sig'));need(launch.returncode==0 and returned['success'],'Official Unity CLI launch failed');returned=returned['data']
        need(Path(returned['projectPath']).resolve()==project and Path(returned['editorPath']).resolve()==EDITOR.resolve(),'Different returned Editor/project refused')
        pid=int(returned['launchedPid']);report['owned_editor_pid']=pid;handle=kernel.OpenProcess(0x1000|0x0010|0x0100|0x0001,False,pid);need(bool(handle),'Cannot guard owned SDK Editor')
        contained=wintypes.BOOL();need(kernel.IsProcessInJob(handle,job.handle,ctypes.byref(contained)),'Cannot inspect owned job membership')
        if not contained.value:need(job.kernel.AssignProcessToJobObject(job.handle,handle),'Cannot assign owned SDK Editor job')
        report['owned_job_guarded']=True;next_sample=0
        while True:
            code=wintypes.DWORD();need(kernel.GetExitCodeProcess(handle,ctypes.byref(code)),'Cannot inspect owned SDK Editor')
            if code.value!=259:report['exit_code']=code.value;break
            elapsed=time.monotonic()-started;state=ProcessMemory();state.cb=ctypes.sizeof(state);need(api(handle,ctypes.byref(state),state.cb),'Cannot inspect private SDK Editor usage')
            available=memory().available_commit;need(elapsed<=180 and available>=reserve and shutil.disk_usage(project).free>=4*GIB,'SDK fixture elapsed/system commit/disk guard reached')
            if elapsed>=next_sample:
                row={'seconds':round(elapsed,2),'editor_private_bytes':state.PrivateUsage,'available_commit':available};report['samples'].append(row);print(json.dumps({'status':'genuine_sdk_original_texture_loading',**row}),flush=True);next_sample=elapsed+10
            time.sleep(.25)
        result_path=project/'FixtureInputs/result.json';result=json.loads(result_path.read_text()) if result_path.exists() else None
        text=log.read_text(errors='replace') if log.exists() else ''
        passed=report['exit_code']==0 and result is not None and result['status']=='passed' and result['genuine_sdk_methods_invoked'] and not result['original_client_or_game_methods_invoked'] and not result['PlayMode'] and not result['scene_or_prefab_loaded'] and 'GENUINE_SDK_ORIGINAL_TEXTURE_LOAD_OK' in text
        report.update(status='passed' if passed else 'failed',result={'path':str(result_path),'sha256':sha(result_path),'value':result} if result else None,gameplay_playability_claimed=False)
    except BaseException as error:report.update(status='stopped',error=repr(error))
    finally:
        if job:job.close()
        if launch is not None and launch.poll() is None:launch.kill();launch.wait(timeout=10)
        if handle:
            code=wintypes.DWORD()
            if kernel.GetExitCodeProcess(handle,ctypes.byref(code)) and code.value==259:kernel.TerminateProcess(handle,137);report['owned_editor_stopped']=True
            kernel.CloseHandle(handle)
        report['seconds']=round(time.monotonic()-started,2);report['completed_utc']=datetime.now(timezone.utc).isoformat();report['tool']={'path':str(Path(__file__).resolve()),'sha256':sha(Path(__file__).resolve())}
        (path.parent/'run-report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(path.parent/'run-report.json'),'error':report.get('error')}),flush=True)
    return 0 if report['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
