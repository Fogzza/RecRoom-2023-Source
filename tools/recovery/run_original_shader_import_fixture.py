"""Review by default. Explicit --run uses only the isolated original Shader fixture."""
from pathlib import Path
import argparse,ctypes,datetime as dt,hashlib,json,os,re,shlex,shutil,subprocess,sys,time,uuid
from ctypes import wintypes
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(ROOT/'Tools'))
from export_bundle_batches import ChildJob,ExtendedJob
from guarded_cpp2il import memory,ProcessMemory
import repair_rr23_wav_headers as safety
from owned_suspended_launch import launch_suspended_in_job
GIB=1024**3;RESERVE=int(1.5*GIB);EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor/Unity.exe';CLI=Path('C:/Users/andre/AppData/Local/Unity/bin/unity.exe')
def need(value,message):
 if not value:raise RuntimeError(message)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def input_check(row):
 p=Path(row['path']);safety.assert_no_reparse(p);need(p.is_file() and sha(p)==row['sha256'],'Pinned input changed: '+str(p))
def make_job(cap):
 job=ChildJob();limits=ExtendedJob();limits.basic.flags=0x2000|0x200;limits.job_memory=cap
 need(job.kernel.SetInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits)),'Cannot install owned-job memory cap')
 return job
def admission(project,cap):
 safety.assert_no_reparse(project);safety.assert_editor_closed()
 need(memory().available_commit>=cap+RESERVE,'Fresh1.5GiB commit-reserve admission refused')
 need(shutil.disk_usage(project).free>=4*GIB,'4GiB disk reserve refused')
def compile_only(plan,out,report):
 project=Path(plan['project']);cap=256*1024**2;admission(project,cap)
 for row in [plan['compiler'],plan['compiler_response']]+plan['compiler_references']:input_check(row)
 target=out/'CompileCheck'/Path(plan['compiler_output']).name;target.parent.mkdir(exist_ok=False);need(not target.exists(),'Fresh compiler output required')
 cmd=[str(Path(plan['compiler']['path'])),'@'+plan['compiler_response']['path'],'/out:'+str(target)]
 job=make_job(cap);child=None;start=time.monotonic();row={'phase':'matching2020-source-compile','command':cmd,'cap_bytes':cap,'reserve_bytes':RESERVE};report['phases'].append(row)
 try:
  with (out/'compile.log').open('xb') as log:
   child,launch=launch_suspended_in_job(cmd,job=job,cwd=project,stdout=log,stderr=subprocess.STDOUT);row['owned_pid']=child.pid;row['suspended_launch']=launch
   while child.poll() is None:
    need(memory().available_commit>=RESERVE and time.monotonic()-start<=30,'Compiler memory/time guard');time.sleep(.05)
  row['exit_code']=child.returncode;need(child.returncode==0 and target.is_file(),'Matching2020observer compile failed; Editor not launched')
  row['output_sha256']=sha(target)
 finally:
  job.close()
  if child is not None and child.poll() is None:child.wait(timeout=10)
  row['seconds']=round(time.monotonic()-start,3)
def kernel_api():
 k=ctypes.WinDLL('kernel32',use_last_error=True)
 k.OpenProcess.argtypes=[wintypes.DWORD,wintypes.BOOL,wintypes.DWORD];k.OpenProcess.restype=wintypes.HANDLE
 k.CloseHandle.argtypes=[wintypes.HANDLE];k.CloseHandle.restype=wintypes.BOOL
 k.GetExitCodeProcess.argtypes=[wintypes.HANDLE,ctypes.POINTER(wintypes.DWORD)];k.GetExitCodeProcess.restype=wintypes.BOOL
 k.WaitForSingleObject.argtypes=[wintypes.HANDLE,wintypes.DWORD];k.WaitForSingleObject.restype=wintypes.DWORD
 k.IsProcessInJob.argtypes=[wintypes.HANDLE,wintypes.HANDLE,ctypes.POINTER(wintypes.BOOL)];k.IsProcessInJob.restype=wintypes.BOOL
 k.QueryInformationJobObject.argtypes=[wintypes.HANDLE,ctypes.c_int,ctypes.c_void_p,wintypes.DWORD,ctypes.POINTER(wintypes.DWORD)];k.QueryInformationJobObject.restype=wintypes.BOOL
 return k
def phase(plan,out,name,previous,report):
 project=Path(plan['project']);cap=GIB;admission(project,cap)
 # Unity can update its isolated version/settings files; original shader/meta,
 # helper code and expected data must remain exact across both sessions.
 for row in plan['inputs']:
  p=Path(row['path'])
  if p.is_relative_to(project/'ProjectSettings'):continue
  input_check(row)
 result=out/(name+'-observation.json');log=out/(name+'-Editor.log');need(not result.exists() and not log.exists(),'Fresh phase paths required')
 args=['-batchmode','-nographics','-disable-assembly-updater','-job-worker-count','1','-executeMethod','VerifyOriginalShaderImport.Run',
  '-shaderProbeConfig',Path(plan['expected_data']['path']).as_posix(),'-shaderProbePhase',name,'-shaderProbeReport',result.as_posix(),'-logFile',log.as_posix()]
 if previous:args+=['-shaderProbePrevious',Path(previous).as_posix()]
 cmd=[str(CLI),'open',str(project),'--editor-path',str(EDITOR),'--args',shlex.join(args),'--format','json']
 row={'phase':name,'command':cmd,'cap_bytes':cap,'reserve_bytes':RESERVE,'maximum_seconds':300,'samples':[]};report['phases'].append(row)
 job=make_job(cap);child=handle=None;k=kernel_api();started=time.monotonic()
 try:
  with (out/(name+'-cli.json')).open('xb') as stdout,(out/(name+'-cli-error.log')).open('xb') as stderr:
   child,launch=launch_suspended_in_job(cmd,job=job,cwd=project,stdout=stdout,stderr=stderr);row['suspended_launch']=launch
   while child.poll() is None:
    need(memory().available_commit>=RESERVE and time.monotonic()-started<=30,'CLI memory/time guard');time.sleep(.1)
  cli=json.loads((out/(name+'-cli.json')).read_text(encoding='utf-8-sig'))
  need(child.returncode==0 and cli['success'],'Official CLI refused fixture launch')
  need(Path(cli['data']['projectPath']).resolve()==project and Path(cli['data']['editorPath']).resolve()==EDITOR,'Unexpected Editor/project launch')
  pid=int(cli['data']['launchedPid']);row['owned_editor_pid']=pid
  handle=k.OpenProcess(0x100000|0x1000|0x0010|0x0100|0x0001,False,pid);need(bool(handle),'Cannot observe owned fixture Editor')
  member=wintypes.BOOL();need(k.IsProcessInJob(handle,job.handle,ctypes.byref(member)),'Cannot verify owned Editor job')
  if not member.value:need(job.kernel.AssignProcessToJobObject(job.handle,handle),'Cannot attach owned Editor to memory guard')
  next_sample=0
  while True:
   code=wintypes.DWORD();need(k.GetExitCodeProcess(handle,ctypes.byref(code)),'Cannot query owned Editor')
   if code.value!=259:row['exit_code']=int(code.value);break
   elapsed=time.monotonic()-started;available=memory().available_commit
   need(elapsed<=300 and available>=RESERVE and shutil.disk_usage(project).free>=4*GIB,'Fixture memory/time/disk guard')
   if elapsed>=next_sample:
    limits=ExtendedJob();need(k.QueryInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits),None),'Cannot query owned job telemetry')
    row['samples'].append({'seconds':round(elapsed,2),'available_commit_bytes':available,'peak_job_bytes':int(limits.peak_job),'peak_process_bytes':int(limits.peak_process)})
    (out/'run-report.json').write_text(json.dumps(report,indent=2)+'\n');next_sample=elapsed+5
   time.sleep(.2)
  need(result.is_file(),'Observer did not produce a report; import/compile/license failure remains unverified')
  observed=json.loads(result.read_bytes());row['observation']=observed;row['observation_sha256']=sha(result)
  need(row['exit_code']==0 and observed['status']=='passed','Shader observer refused phase '+name)
  need(observed['unity_version']=='2020.3.33f1' and observed['payload_retained'] and observed['keyword_masks_retained'] and observed['original_meta_guid_retained'] and observed['protected_save_bytes_unchanged'] and observed['dependency_guid_resolved'],'Incomplete original-data verification')
  need(name!='reload' or observed['fresh_process_reload_compared'],'Fresh-process reload proof absent')
  text=log.read_text(encoding='utf-8',errors='replace')
  diagnostics=re.findall(r'(?im)^.*(?:error CS\d+|Shader error in|Failed to read serialized|Fatal error|Aborting batchmode due to).*$' ,text)
  row['full_log_failure_lines']=diagnostics[:32];need(not diagnostics,'Editor log contains compile/import/Shader errors')
 finally:
  job.close()
  if child is not None and child.poll() is None:child.wait(timeout=10)
  if handle:
   stopped=k.WaitForSingleObject(handle,10000)==0;row['owned_editor_exit_confirmed']=stopped;k.CloseHandle(handle)
   need(stopped,'Owned Editor did not exit after job close; evidence retained')
  row['seconds']=round(time.monotonic()-started,3)
 return result
def main():
 p=argparse.ArgumentParser(description=__doc__);p.add_argument('--fixture',type=Path,required=True);p.add_argument('--run',action='store_true');p.add_argument('--compile-only',action='store_true');a=p.parse_args()
 safety.assert_no_reparse(a.fixture);fixture=a.fixture.resolve(strict=True)
 need(fixture.is_relative_to(ROOT/'AssetRecovery') and fixture.name.startswith('OriginalStencilImportFixture-'),'Exact isolated prepared fixture required')
 plan_path=fixture/'plan.json';plan=json.loads(plan_path.read_bytes());project=Path(plan['project']).resolve(strict=True)
 need(project==fixture/'Project' and plan['schema']=='prepared-original-shader-import-fixture/v1','Unexpected fixture shape')
 need(Path(plan['editor']['path'])==EDITOR and Path(plan['cli']['path'])==CLI,'Exact matching Editor/official CLI required')
 for row in [plan['runner'],plan['launcher_helper'],plan['launcher_probe_report'],plan['editor'],plan['cli'],plan['candidate_report'],plan['candidate_readiness']]+plan['inputs']+plan['read_only_sources']:input_check(row)
 if not a.run and not a.compile_only:
  print(json.dumps({'status':'prepared_verified_no_launch','plan':str(plan_path),'planned_sessions':plan['planned_sessions'],'Editor_launched':False}));return 0
 need(not(a.run and a.compile_only),'Choose run or compile-only')
 out=fixture/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 report={'schema':'guarded-isolated-original-shader-import/v1','status':'starting','fixture':str(fixture),'plan_sha256':sha(plan_path),'phases':[],'Main_modified':False,'Play_entered':False,'gpu_rendering_verified':False}
 try:
  compile_only(plan,out,report)
  if a.compile_only:report['status']='matching_source_compiled_Editor_not_launched'
  else:
   first=phase(plan,out,'import',None,report);phase(plan,out,'reload',first,report)
   report['status']='two_session_original_shader_import_and_retention_passed'
 except BaseException as error:
  report.update(status='failed_or_guard_refused',error=repr(error))
  if getattr(error,'evidence',None) is not None:report['suspended_launch_failure']=error.evidence
 finally:
  report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();(out/'run-report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(out/'run-report.json'),'error':report.get('error')}))
 return 0 if report['status'] in ('matching_source_compiled_Editor_not_launched','two_session_original_shader_import_and_retention_passed') else 1
if __name__=='__main__':raise SystemExit(main())
