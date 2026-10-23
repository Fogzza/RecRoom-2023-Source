"""Compile unchanged official SDK with installed2020 compiler; metadata only."""
import ctypes,datetime as dt,hashlib,importlib.util,json,os,shutil,subprocess,time,uuid
from ctypes import wintypes
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';OFFICIAL=ROOT/'Validation/OfficialSteamworks14-20261022T140058Z-91fe31a3/report.json'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
def phase(command,out,label,report,cap=.25,seconds=30):
 if g.memory().available_commit<(cap+1.5)*g.GIB:raise RuntimeError('System commit admission refused')
 api=ctypes.WinDLL('psapi',use_last_error=True);api.GetProcessMemoryInfo.argtypes=[wintypes.HANDLE,ctypes.POINTER(g.ProcessMemory),wintypes.DWORD];api.GetProcessMemoryInfo.restype=wintypes.BOOL;row={'phase':label,'max_private_bytes':int(cap*g.GIB),'minimum_commit_reserve_bytes':int(1.5*g.GIB),'maximum_seconds':seconds,'command':[str(x) for x in command]};report['phases'].append(row);child=None;start=time.monotonic()
 try:
  with (out/(label+'.log')).open('wb') as log:
   child=subprocess.Popen([str(x) for x in command],stdout=log,stderr=subprocess.STDOUT,cwd=out,creationflags=subprocess.CREATE_NO_WINDOW,env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1'));row['owned_pid']=child.pid
   while child.poll() is None:
    p=g.ProcessMemory();p.cb=ctypes.sizeof(p)
    if not api.GetProcessMemoryInfo(wintypes.HANDLE(int(child._handle)),ctypes.byref(p),p.cb):raise ctypes.WinError(ctypes.get_last_error())
    state=g.memory();row['peak_private_bytes']=max(row.get('peak_private_bytes',0),p.PrivateUsage);row['minimum_observed_commit_bytes']=min(row.get('minimum_observed_commit_bytes',state.available_commit),state.available_commit)
    if p.PrivateUsage>cap*g.GIB or state.available_commit<1.5*g.GIB or time.monotonic()-start>seconds or shutil.disk_usage(out).free<4*g.GIB:raise RuntimeError('Private/commit/time/disk guard triggered')
    time.sleep(.1)
  row['exit_code']=child.returncode
  if child.returncode:raise RuntimeError(label+' exited '+str(child.returncode))
 finally:
  if child is not None and child.poll() is None:child.kill();child.wait(timeout=10);row['owned_child_terminated']=True
  row['seconds']=round(time.monotonic()-start,3)
out=ROOT/'Validation'/('CompiledOfficialSteamworks14-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'compiled-official-steamworks14-source-proof/v1','phases':[],'project_modified':False,'sdk_or_game_code_executed':False,'compiled_profile':'STEAMWORKS_WIN;STEAMWORKS_X64','official_source_report':str(OFFICIAL),'official_source_report_sha256':g.sha(OFFICIAL)}
try:
 original=json.loads(OFFICIAL.read_text());sources=[Path(x['local_path']) for x in original['files']]
 if not all(g.sha(p)==r['sha256'] for p,r in zip(sources,original['files'])):raise ValueError('Official text input hash mismatch')
 editor=WS/'Tools/Editors/2020.3.33f1/Editor';compiler=editor/'Data/Tools/Roslyn/csc.exe';framework=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';target=out/'OfficialSteamworks14.dll';refs=[framework/'mscorlib.dll',framework/'System.dll',framework/'System.Core.dll'];rsp=out/'official-sdk.rsp';rsp.write_text('\n'.join(['/nologo','/nostdlib+','/target:library','/optimize+','/unsafe+','/langversion:8','/define:STEAMWORKS_WIN;STEAMWORKS_X64','/out:"'+str(target)+'"']+['/reference:"'+str(p)+'"' for p in refs]+['"'+str(p)+'"' for p in sources])+'\n');report['compiler_inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in [compiler]+refs];phase([compiler,'/noconfig','@'+str(rsp)],out,'exact-unity2020-compile-official-sdk',report)
 cecil=HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll';reader=out/'ExtractSdkMarshalling.dll';rsp=out/'reader.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/out:"'+str(reader)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+[cecil]]+['"'+str(HERE/'ExtractSdkMarshalling.cs')+'"'])+'\n');phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-metadata-only-reader',report,cap=.125);shutil.copyfile(cecil,out/cecil.name);runtime=json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}});reader.with_suffix('.runtimeconfig.json').write_text(runtime);record=out/'marshal-records.json';phase([g.DOTNET,reader,target,record],out,'extract-sdk-metadata-no-execution',report,cap=.125)
 semantic=out/'OfficialSteamMarshalSource.dll';rsp=out/'source-reader.rsp';roslyn=[g.SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.dll',g.SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.CSharp.dll'];rsp.write_text('\n'.join(['/nologo','/target:exe','/out:"'+str(semantic)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+roslyn]+['"'+str(HERE/'OfficialSteamMarshalSource.cs')+'"'])+'\n');phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-source-ownership-reader',report,cap=.125)
 for p in roslyn:shutil.copyfile(p,out/p.name)
 semantic.with_suffix('.runtimeconfig.json').write_text(runtime);source_records=out/'source-ownership.json';phase([g.DOTNET,semantic,Path(original['files'][0]['local_path']).parent,framework/'mscorlib.dll',source_records,framework/'System.dll',framework/'System.Core.dll'],out,'bind-source-MarshalAs-ownership',report,cap=.25)
 if not all(g.sha(p)==r['sha256'] for p,r in zip(sources,original['files'])):raise ValueError('Official text changed')
 if json.loads(source_records.read_text())['semantic_errors']:raise ValueError('Official source semantic errors remain')
 report.update(status='compiled_and_metadata_extracted',official_source_files=len(sources),compiled_assembly={'path':str(target),'sha256':g.sha(target)},marshal_records={'path':str(record),'sha256':g.sha(record)},source_ownership={'path':str(source_records),'sha256':g.sha(source_records)},tool_sources=[{'path':str(p),'sha256':g.sha(p)} for p in [Path(__file__),HERE/'ExtractSdkMarshalling.cs',HERE/'OfficialSteamMarshalSource.cs']])
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)
