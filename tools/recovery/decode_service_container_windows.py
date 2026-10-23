"""Already-built Iced decoder only, under an owned hard128MiB JobObject."""
import ctypes,datetime as dt,hashlib,importlib.util,json,os,shutil,subprocess,sys,time,uuid
from pathlib import Path
from ctypes import wintypes
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(ROOT/'Tools'))
from export_bundle_batches import ChildJob,ExtendedJob
from guarded_cpp2il import memory,ProcessMemory
SOURCE=ROOT/'Validation/ServiceContainerNativeWindows-20261022T180635Z-6a8820b3/bounded-decoder-input.json'
DECODER=HERE/'PInvokeDisassembler-20261022T124000Z/DisassemblePInvokeWrappers.dll'

def sha(p):return hashlib.sha256(Path(p).read_bytes()).hexdigest()
def need(b,s):
 if not b:raise ValueError(s)

def main():
 out=ROOT/'Validation'/('ServiceContainerStaticDecode-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();cap=128*1024**2;reserve=int(1.5*1024**3);report={'schema':'bounded-original-service-container-static-decoder/v1','project_modified':False,'game_or_native_code_executed':False,'managed_game_assemblies_loaded':False,'input':{'path':str(SOURCE),'sha256':sha(SOURCE)},'trusted_tool':{'path':str(DECODER),'sha256':sha(DECODER)},'cap_private_bytes':cap,'minimum_system_commit_bytes':reserve,'maximum_seconds':15};job=None;child=None;started=time.monotonic()
 try:
  need(memory().available_commit>=reserve+cap and shutil.disk_usage(out).free>=4*1024**3,'Fresh static decoder resource admission refused')
  job=ChildJob();limits=ExtendedJob();limits.basic.flags=0x2000|0x200;limits.job_memory=cap;need(job.kernel.SetInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits)),'Cannot hard-cap owned static decoder')
  api=ctypes.WinDLL('psapi',use_last_error=True).GetProcessMemoryInfo;api.argtypes=[wintypes.HANDLE,ctypes.POINTER(ProcessMemory),wintypes.DWORD];api.restype=wintypes.BOOL
  with (out/'output.log').open('wb')as log:
   child=subprocess.Popen([r'C:\Program Files\dotnet\dotnet.exe',str(DECODER),str(SOURCE),str(out/'instructions.jsonl')],cwd=out,stdin=subprocess.DEVNULL,stdout=log,stderr=subprocess.STDOUT,creationflags=subprocess.CREATE_NO_WINDOW,env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1'));job.attach(child);report['owned_pid']=child.pid
   while child.poll()is None:
    p=ProcessMemory();p.cb=ctypes.sizeof(p);need(api(wintypes.HANDLE(int(child._handle)),ctypes.byref(p),p.cb),'Cannot sample owned decoder');report['peak_private_bytes']=max(report.get('peak_private_bytes',0),p.PrivateUsage);need(p.PrivateUsage<=cap and memory().available_commit>=reserve and time.monotonic()-started<=15,'Static decoder memory/time guard triggered');time.sleep(.05)
  report['exit_code']=child.returncode;need(child.returncode==0,'Trusted static decoder failed');report.update(status='passed',output={'path':str(out/'instructions.jsonl'),'sha256':sha(out/'instructions.jsonl')})
 except BaseException as error:report.update(status='failed',error=str(error))
 finally:
  if job:job.close()
  if child is not None and child.poll()is None:child.kill();child.wait(timeout=10);report['owned_child_stopped']=True
  report['seconds']=round(time.monotonic()-started,3);(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error'),'peak':report.get('peak_private_bytes')}),flush=True)

if __name__=='__main__':main()
