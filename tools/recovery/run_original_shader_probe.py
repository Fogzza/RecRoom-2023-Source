"""One pinned original shader object; trusted tool only, fresh outputs, no Unity."""
from pathlib import Path
import ctypes,datetime as dt,hashlib,importlib.util,json,os,shutil,subprocess,sys,time,uuid
from ctypes import wintypes
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(ROOT/'Tools'))
from export_bundle_batches import ChildJob,ExtendedJob
from guarded_cpp2il import memory,ProcessMemory
GIB=1024**3;CAP=512*1024**2;RESERVE=int(1.5*GIB)
DOTNET=Path('C:/Program Files/dotnet/dotnet.exe');SDK=Path('C:/Program Files/dotnet/sdk/10.0.402');REF=Path('C:/Program Files/dotnet/packs/Microsoft.NETCore.App.Ref/10.0.13/ref/net10.0')
PUB=WS/'AR23Tool/Build-20261022T031925Z-3950f237/Published'
def sha(p):return hashlib.sha256(Path(p).read_bytes()).hexdigest()
def phase(cmd,out,name,report):
 if memory().available_commit<CAP+RESERVE:raise RuntimeError('1.5GiB reserve admission refused')
 if shutil.disk_usage(out).free<4*GIB:raise RuntimeError('4GiB disk reserve refused')
 job=ChildJob();limits=ExtendedJob();limits.basic.flags=0x2000|0x200;limits.job_memory=CAP
 if not job.kernel.SetInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits)):raise ctypes.WinError(ctypes.get_last_error())
 api=ctypes.WinDLL('psapi',use_last_error=True).GetProcessMemoryInfo;api.argtypes=[wintypes.HANDLE,ctypes.POINTER(ProcessMemory),wintypes.DWORD];api.restype=wintypes.BOOL
 p=None;start=time.monotonic();row={'name':name,'command':list(map(str,cmd)),'cap_bytes':CAP,'reserve_bytes':RESERVE};report['phases'].append(row)
 try:
  with (out/(name+'.log')).open('wb') as log:
   cli_home=out/'DotnetHome';cli_home.mkdir(exist_ok=True)
   p=subprocess.Popen(list(map(str,cmd)),cwd=out,stdout=log,stderr=subprocess.STDOUT,creationflags=subprocess.CREATE_NO_WINDOW,env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_CLI_HOME=str(cli_home),DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1',DOTNET_NOLOGO='1'));job.attach(p);row['owned_pid']=p.pid
   while p.poll() is None:
    m=ProcessMemory();m.cb=ctypes.sizeof(m)
    if not api(wintypes.HANDLE(int(p._handle)),ctypes.byref(m),m.cb):raise ctypes.WinError(ctypes.get_last_error())
    avail=memory().available_commit;row['peak_private_bytes']=max(row.get('peak_private_bytes',0),m.PrivateUsage)
    if avail<RESERVE or m.PrivateUsage>CAP or time.monotonic()-start>60:raise RuntimeError('Memory/commit/60s guard triggered')
    time.sleep(.05)
  row['exit_code']=p.returncode
  if p.returncode:raise RuntimeError(name+' exit '+str(p.returncode))
 finally:
  job.close()
  if p is not None and p.poll() is None:p.wait(timeout=10)
  row['seconds']=round(time.monotonic()-start,3)
def main():
 out=ROOT/'AssetRecovery'/('OriginalShaderModelProbe-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 report={'schema':'guarded-original-shader-model-probe/v1','phases':[],'Main_modified':False,'Unity_launched':False}
 try:
  src=HERE/'OriginalShaderObjectProbe.cs';host=out/'OriginalShaderObjectProbe.dll'
  refs=sorted(REF.glob('*.dll'))+sorted(PUB.glob('AssetRipper.*.dll'))
  report['source']={'path':str(src),'sha256':sha(src)}
  report['dependencies']=[{'path':str(p),'sha256':sha(p)} for p in refs if p.parent==PUB]
  rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/langversion:latest','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in refs]+['"'+str(src)+'"'])+'\n')
  phase([DOTNET,SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile',report)
  for p in PUB.glob('*.dll'):os.link(p,out/p.name)
  shutil.copyfile(PUB/'AssetRipper.GUI.Free.deps.json',host.with_suffix('.deps.json'))
  host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','frameworks':[{'name':'Microsoft.NETCore.App','version':'10.0.13'},{'name':'Microsoft.AspNetCore.App','version':'10.0.13'}]}}))
  obj=ROOT/'AssetRecovery/OriginalShaderRecoveryRoute-20261022T184808Z-356f2e1f/OriginalSerializedShaderObjects/native-34.bin'
  phase([DOTNET,host,obj,'4c9c59bdbf78031d605b90ee85c49c770dc358c6c1470e5d27871b6e7f5cc9ab','34','Hidden/Universal Render Pipeline/StencilDeferred',out/'Object'],out,'read-one-object',report)
  report.update(status='parsed',result=str(out/'Object/report.json'))
 except BaseException as e:report.update(status='failed',error=str(e))
 finally:
  (out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'error':report.get('error')}),flush=True)
 return 0 if report['status']=='parsed' else 1
if __name__=='__main__':raise SystemExit(main())
