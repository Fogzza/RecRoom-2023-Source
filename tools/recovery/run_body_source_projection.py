"""Reproject only the three changed source files using the verified existing tool."""
import ctypes,datetime as dt,hashlib,importlib.util,json,os,shutil,subprocess,time,uuid
from ctypes import wintypes
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
def need(value,reason):
 if not value:raise ValueError(reason)
def main():
 out=ROOT/'Validation'/('BodySourceProjection-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'three-file-source-body-projection/v1','status':'starting','project_modified':False,'game_code_executed':False};child=None;started=time.monotonic()
 try:
  witness=HERE.parent/'CompilerPropertyProjection/Build-20261022T103441Z-6c4753f9/report.json';build=json.loads(witness.read_text());need(build['status']=='completed','Verified projection tool build required')
  pins=build['source_files']+build['dependencies']+[build['host']]
  need(all(g.sha(Path(p['path']))==p['sha256'] for p in pins),'Existing source projection executable/source/dependency drift')
  journal=ROOT/'NativeGameplayRepairs/AppliedBodyBatch-20261022T143919Z-d8d0e6b3/journal.json';applied=json.loads(journal.read_text());need(applied['status']=='applied' and applied['method_bodies']==7,'Seven applied native bodies required')
  need(all(g.sha(Path(row['source']))==row['after_sha256'] and g.sha(Path(row['source']+'.meta'))==row['meta_sha256'] for row in applied['rows']),'Applied source or GUID changed')
  paths=[str(Path(row['source']).relative_to(WS/'RR23')).replace('\\','/') for row in applied['rows']];scope=out/'source-scope.json';scope.write_text(json.dumps(paths,indent=2)+'\n');candidate=out/'Projection'
  command=[g.DOTNET,build['host']['path'],'--project',WS/'RR23','--raw',ROOT/'ScriptRecoveryModernLayout/Attempt-20261022T021923Z-2fcf0245/Output/Assembly-CSharp.dll','--processed',ROOT/'Attempt-20261022T005949Z-c8385579/Export/AuxiliaryFiles/GameAssemblies/Assembly-CSharp.dll','--attributes',ROOT/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll','--baseline',ROOT/'Validation/native-hybrid-compile-baseline.json','--accessibility-evidence',ROOT/'CompilerRepairs/SmallerFamilies/candidate-evidence.json','--output',candidate,'--only-sources',scope]
  cap=768*1024**2;reserve=int(1.5*g.GIB);need(g.memory().available_commit>=cap+reserve and shutil.disk_usage(out).free>=4*g.GIB,'Projection admission refused')
  api=ctypes.WinDLL('psapi',use_last_error=True);api.GetProcessMemoryInfo.argtypes=[wintypes.HANDLE,ctypes.POINTER(g.ProcessMemory),wintypes.DWORD];api.GetProcessMemoryInfo.restype=wintypes.BOOL
  report.update(command=[str(x) for x in command],maximum_private_bytes=cap,minimum_commit_reserve_bytes=reserve,maximum_seconds=120,tool_build={'path':str(witness),'sha256':g.sha(witness)},source_application={'path':str(journal),'sha256':g.sha(journal)},source_paths=paths)
  with (out/'projection.log').open('xb') as log:
   child=subprocess.Popen([str(x) for x in command],cwd=out,stdout=log,stderr=subprocess.STDOUT,creationflags=subprocess.CREATE_NO_WINDOW,env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1'));report['owned_pid']=child.pid
   while child.poll() is None:
    info=g.ProcessMemory();info.cb=ctypes.sizeof(info);need(api.GetProcessMemoryInfo(wintypes.HANDLE(int(child._handle)),ctypes.byref(info),info.cb),'Cannot inspect owned projection process');report['peak_private_bytes']=max(report.get('peak_private_bytes',0),info.PrivateUsage)
    need(info.PrivateUsage<=cap and g.memory().available_commit>=reserve and time.monotonic()-started<=120 and shutil.disk_usage(out).free>=4*g.GIB,'Owned projection resource guard reached');time.sleep(.1)
  report['exit_code']=child.returncode;need(child.returncode==0,'Projection failed')
  result=candidate/'metadata-restoration.json';manifest=json.loads(result.read_text());need(manifest['source_projection_scope']['kind']=='partial-explicit-files' and manifest['source_projection_scope']['source_paths']==sorted(paths) and manifest['validation']['source_files']==3 and not manifest['blocked'],'Exactly three unblocked source projections required')
  need(all(g.sha(Path(p['path']))==p['sha256'] for p in pins),'Projection tool inputs changed')
  report.update(status='passed_partial_projection_only',projection={'path':str(result),'sha256':g.sha(result)},candidate_files=manifest['validation']['candidate_files'],full_manifest_rebase_required=True)
 except BaseException as error:report.update(status='failed',error=repr(error))
 finally:
  if child is not None and child.poll() is None:child.kill();child.wait(timeout=10);report['owned_child_terminated']=True
  report['seconds']=round(time.monotonic()-started,3);(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'peak_MiB':round(report.get('peak_private_bytes',0)/1024**2,1),'error':report.get('error')}),flush=True)
 return 0 if report['status']=='passed_partial_projection_only' else 1
if __name__=='__main__':raise SystemExit(main())
