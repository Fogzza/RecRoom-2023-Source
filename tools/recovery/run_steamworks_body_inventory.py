"""Small guarded SDK IL inventory; no inspected assemblies are executed or changed."""
import ctypes,datetime as dt,hashlib,importlib.util,json,os,shutil,subprocess,time,uuid
from ctypes import wintypes
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
def phase(command,out,label,report,cap=128*1024**2,seconds=30):
 if g.memory().available_commit<cap+int(1.5*g.GIB) or shutil.disk_usage(out).free<4*g.GIB:raise RuntimeError('System commit/disk admission refused')
 api=ctypes.WinDLL('psapi',use_last_error=True);api.GetProcessMemoryInfo.argtypes=[wintypes.HANDLE,ctypes.POINTER(g.ProcessMemory),wintypes.DWORD];api.GetProcessMemoryInfo.restype=wintypes.BOOL
 row={'phase':label,'command':[str(x) for x in command],'maximum_private_bytes':cap,'minimum_commit_reserve_bytes':int(1.5*g.GIB),'maximum_seconds':seconds};report['phases'].append(row);child=None;start=time.monotonic()
 try:
  with (out/(label+'.log')).open('xb') as log:
   child=subprocess.Popen([str(x) for x in command],stdout=log,stderr=subprocess.STDOUT,cwd=out,creationflags=subprocess.CREATE_NO_WINDOW,env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1'));row['owned_pid']=child.pid
   while child.poll() is None:
    p=g.ProcessMemory();p.cb=ctypes.sizeof(p)
    if not api.GetProcessMemoryInfo(wintypes.HANDLE(int(child._handle)),ctypes.byref(p),p.cb):raise ctypes.WinError(ctypes.get_last_error())
    state=g.memory();row['peak_private_bytes']=max(row.get('peak_private_bytes',0),p.PrivateUsage)
    if p.PrivateUsage>cap or state.available_commit<1.5*g.GIB or time.monotonic()-start>seconds or shutil.disk_usage(out).free<4*g.GIB:raise RuntimeError('Owned inventory private/commit/time/disk guard')
    time.sleep(.1)
  row['exit_code']=child.returncode
  if child.returncode:raise RuntimeError(label+' exited '+str(child.returncode))
 finally:
  if child is not None and child.poll() is None:child.kill();child.wait(timeout=10);row['owned_child_terminated']=True
  row['seconds']=round(time.monotonic()-start,3)
out=ROOT/'Validation'/('SteamworksManagedBodyInventory-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'guarded-Steamworks14-body-inventory/v1','phases':[],'game_or_sdk_code_executed':False,'project_modified':False}
try:
 witness=ROOT/'Validation/CompiledOfficialSteamworks14-20261022T141234Z-ba27e76b/report.json';original=json.loads(witness.read_text());sdk=Path(original['compiled_assembly']['path']);raw=ROOT/'ScriptRecoveryModernLayout/Attempt-20261022T021923Z-2fcf0245/Output/Assembly-CSharp.dll';cecil=HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll';source=HERE/'SteamworksBodyInventory.cs'
 if g.sha(sdk)!=original['compiled_assembly']['sha256'] or g.sha(raw)!='55f79f81c86eb0393e0a3dea838fe87d7f63f2e75fdefc8997ea6a808fa5af60':raise ValueError('Pinned SDK/original metadata changed')
 report['inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in (witness,sdk,raw,cecil,source)]
 target=out/'SteamworksBodyInventory.dll';rsp=out/'reader.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/out:"'+str(target)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+[cecil]]+['"'+str(source)+'"'])+'\n')
 phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-owned-inventory',report)
 shutil.copyfile(cecil,out/cecil.name);target.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}))
 result=out/'inventory.json';phase([g.DOTNET,target,sdk,raw,result],out,'read-SDK-and-native-metadata',report,cap=192*1024**2)
 if not all(g.sha(Path(p['path']))==p['sha256'] for p in report['inputs']):raise ValueError('Inventory input changed')
 data=json.loads(result.read_text());clean=[m for m in data['methods'] if not m['issues']];report.update(status='passed_inventory_only',inventory={'path':str(result),'sha256':g.sha(result)},source_types=data['source_types'],managed_bodies=data['managed_bodies'],clean_unscoped_join_candidates=len(clean),unique_method_joins=data['uniquely_joined_methods'],no_bodies_transplanted=True)
except BaseException as error:report.update(status='failed',error=repr(error))
finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'managed_bodies':report.get('managed_bodies'),'candidate_joins':report.get('clean_unscoped_join_candidates'),'error':report.get('error')}),flush=True)
