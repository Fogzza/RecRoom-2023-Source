"""Bounded whole-manifest rebase retaining every source/type declaration."""
import ctypes,datetime as dt,importlib.util,json,os,shutil,subprocess,time,uuid
from pathlib import Path
from ctypes import wintypes
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
def phase(command,out,label,report,cap):
 reserve=int(1.5*g.GIB)
 if g.memory().available_commit<cap+reserve or shutil.disk_usage(out).free<4*g.GIB:raise RuntimeError('Rebase commit/disk admission refused')
 api=ctypes.WinDLL('psapi',use_last_error=True);api.GetProcessMemoryInfo.argtypes=[wintypes.HANDLE,ctypes.POINTER(g.ProcessMemory),wintypes.DWORD];api.GetProcessMemoryInfo.restype=wintypes.BOOL;child=None;start=time.monotonic();row={'phase':label,'private_cap_bytes':cap,'minimum_commit_bytes':reserve,'maximum_seconds':120,'command':[str(x) for x in command]};report['phases'].append(row)
 try:
  with (out/(label+'.log')).open('xb') as log:
   child=subprocess.Popen([str(x) for x in command],stdout=log,stderr=subprocess.STDOUT,cwd=out,creationflags=subprocess.CREATE_NO_WINDOW,env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_GCHeapHardLimit='0x20000000'));row['owned_pid']=child.pid
   while child.poll() is None:
    p=g.ProcessMemory();p.cb=ctypes.sizeof(p)
    if not api.GetProcessMemoryInfo(wintypes.HANDLE(int(child._handle)),ctypes.byref(p),p.cb):raise RuntimeError('Cannot inspect owned rebase process')
    row['peak_private_bytes']=max(row.get('peak_private_bytes',0),p.PrivateUsage)
    if p.PrivateUsage>cap or g.memory().available_commit<reserve or time.monotonic()-start>120 or shutil.disk_usage(out).free<4*g.GIB:raise RuntimeError('Owned rebase resource guard reached')
    time.sleep(.1)
  row['exit_code']=child.returncode
  if child.returncode:raise RuntimeError(label+' failed')
 finally:
  if child is not None and child.poll() is None:child.kill();child.wait(timeout=10);row['owned_child_terminated']=True
  row['seconds']=round(time.monotonic()-start,3)
def main():
 out=ROOT/'Validation'/('BodySourceRebase-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'guarded-full-source-body-rebase/v1','phases':[],'project_modified':False,'game_code_executed':False}
 try:
  old=ROOT/'CompilerRepairs/RuntimeSourcePlacementProjection-20261022T104037Z-a6651f58/metadata-restoration.json';partial=ROOT/'Validation/BodySourceProjection-20261022T144115Z-5a339b18/Projection/metadata-restoration.json';journal=ROOT/'NativeGameplayRepairs/AppliedBodyBatch-20261022T143919Z-d8d0e6b3/journal.json';source=HERE/'RebaseBodySourceProjection.cs'
  report['inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in (old,partial,journal,source)]
  if report['inputs'][0]['sha256']!='134970adfa7af635a99deedda72411104f1ea96618ad05d3c8a50e3f4655e1f1' or report['inputs'][1]['sha256']!='56abd366d0a44535be53581b90a4d090fa5ec3ddbbe756f673c352869757f159':raise ValueError('Pinned whole/partial source plan changed')
  target=out/'RebaseBodySourceProjection.dll';rsp=out/'reader.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/out:"'+str(target)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))]+['"'+str(source)+'"'])+'\n');phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-rebaser',report,128*1024**2)
  target.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));phase([g.DOTNET,target,old,partial,journal,out/'Projection'],out,'rebase-with-equal-declarations',report,768*1024**2)
  if not all(g.sha(Path(p['path']))==p['sha256'] for p in report['inputs']):raise ValueError('Rebase input drift')
  result=out/'Projection/report.json';report.update(status='passed',rebase_report={'path':str(result),'sha256':g.sha(result)})
 except BaseException as error:report.update(status='failed',error=repr(error))
 finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)
 return 0 if report['status']=='passed' else 1
if __name__=='__main__':raise SystemExit(main())
