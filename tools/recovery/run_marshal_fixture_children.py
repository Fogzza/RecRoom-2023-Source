"""Only tiny synthetic fixture CSC/Mono children with fixed reviewed limits."""
import ctypes,importlib.util,json,os,subprocess,sys,time
from pathlib import Path
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];EDITOR=WORKSPACE/'Tools/Editors/2020.3.33f1/Editor'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'Cpp2IL-2022.0.7-ModuleCapFix/build_guarded.py');guard=importlib.util.module_from_spec(spec);spec.loader.exec_module(guard)
def main():
 mode=sys.argv[1];folder=Path(sys.argv[2]).resolve();name=sys.argv[3];need= lambda b,s: None if b else (_ for _ in ()).throw(ValueError(s))
 need(folder.parent==WORKSPACE/'Recovery/RecRoom-2023-04-18/Validation' and folder.name.startswith('MarshalFlagAssertionFixture-'),'Synthetic fixture folder only')
 if mode=='compile':
  need(name in ('Plain','Correct','MarshalWalker'),'Only three synthetic sources');command=[str(EDITOR/'Data/Tools/Roslyn/csc.exe'),'@'+str(folder/(name+'.rsp'))];cap=256*1024**2;seconds=15
 elif mode=='mono':
  need(name in ('Plain','Correct','Malformed'),'Only non-game fixture DLLs');command=[str(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),str(folder/'MarshalWalker.exe'),str(folder/(name+'.dll'))];cap=64*1024**2;seconds=10
 else:raise ValueError('Unknown fixture phase')
 reserve=int(1.5*1024**3);need(guard.guards.memory().available_commit>=cap+reserve,'Insufficient compile/fixture reserve');attempt=folder/(mode+'-'+name);attempt.mkdir();report={'mode':mode,'name':name,'command':command,'max_private_bytes':cap,'deadline_seconds':seconds,'minimum_available_commit_bytes':reserve,'no_native_import_or_game_invoked':True};started=time.monotonic();child=None;peak=0
 # Inherited suppression prevents Windows crash-dialog UI for the intentionally
 # malformed synthetic metadata child. No Unity/game process is affected.
 kernel=ctypes.WinDLL('kernel32',use_last_error=True);kernel.SetErrorMode.argtypes=[ctypes.c_uint];kernel.SetErrorMode.restype=ctypes.c_uint;prior=kernel.SetErrorMode(0x0001|0x0002|0x8000)
 try:
  with (attempt/'output.log').open('wb') as output:
   child=subprocess.Popen(command,cwd=attempt,stdin=subprocess.DEVNULL,stdout=output,stderr=subprocess.STDOUT,creationflags=subprocess.CREATE_NO_WINDOW)
   while child.poll() is None:
    private,_=guard.owned_private(child.pid);peak=max(peak,private);need(private<=cap and guard.guards.memory().available_commit>=reserve and time.monotonic()-started<=seconds,'Synthetic fixture resource/deadline reached');time.sleep(.05)
   report.update(status='exited',exit_code=child.returncode)
 except Exception as error:report.update(status='guard_stopped',error=repr(error))
 finally:
  if child is not None and child.poll() is None:
   subprocess.run(['taskkill','/PID',str(child.pid),'/T','/F'],stdout=subprocess.DEVNULL,stderr=subprocess.DEVNULL,creationflags=subprocess.CREATE_NO_WINDOW,timeout=5);child.wait(timeout=5)
  kernel.SetErrorMode(prior);report.update(seconds=round(time.monotonic()-started,3),peak_private_bytes=peak);(attempt/'report.json').write_text(json.dumps(report,indent=2)+'\n')
 print(json.dumps({'report':str(attempt/'report.json'),'status':report['status'],'exit_code':report.get('exit_code'),'peak_private':peak}))
 return 0 if report['status']=='exited' else 1
if __name__=='__main__':raise SystemExit(main())
