"""Test two candidate marshal descriptors against our inert x64 native DLL.

This fixture never invokes Windows trust/device APIs, game or vendor code.
It contains only two exported native functions and has no imports/entry point.
"""
import ctypes,hashlib,importlib.util,json,os,struct,subprocess,sys,time
from pathlib import Path
from datetime import datetime,timezone
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18';EDITOR=WORKSPACE/'Tools/Editors/2020.3.33f1/Editor'
spec=importlib.util.spec_from_file_location('fixture_guard',HERE.parent/'Cpp2IL-2022.0.7-ModuleCapFix/build_guarded.py');guard=importlib.util.module_from_spec(spec);spec.loader.exec_module(guard)
def need(b,s):
 if not b:raise ValueError(s)
def sha(path):
 with path.open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def phase(command,folder,name,cap,deadline):
 out=folder/name;out.mkdir();reserve=int(1.5*1024**3);need(guard.guards.memory().available_commit>=cap+reserve,'Insufficient fixture memory reserve');started=time.monotonic();child=None;peak=0;report={'command':list(map(str,command)),'max_private_bytes':cap,'maximum_seconds':deadline,'minimum_available_commit_bytes':reserve}
 try:
  with (out/'output.log').open('wb') as output:
   child=subprocess.Popen(list(map(str,command)),cwd=folder,stdin=subprocess.DEVNULL,stdout=output,stderr=subprocess.STDOUT,creationflags=subprocess.CREATE_NO_WINDOW)
   while child.poll() is None:
    private,_=guard.owned_private(child.pid);peak=max(peak,private);need(private<=cap and guard.guards.memory().available_commit>=reserve and time.monotonic()-started<=deadline,'Fixture resource/deadline bound reached');time.sleep(.05)
  report.update(status='exited',exit_code=child.returncode);need(child.returncode==0,'Fixture child failed')
 except BaseException as error:report.update(status='failed',error=repr(error));raise
 finally:
  if child is not None and child.poll() is None:
   subprocess.run(['taskkill','/PID',str(child.pid),'/T','/F'],stdout=subprocess.DEVNULL,stderr=subprocess.DEVNULL,creationflags=subprocess.CREATE_NO_WINDOW,timeout=5);child.wait(timeout=5)
  report.update(seconds=round(time.monotonic()-started,3),peak_private_bytes=peak);(out/'report.json').write_text(json.dumps(report,indent=2)+'\n')
 return {'path':str(out/'report.json'),'sha256':sha(out/'report.json')}
def native_contract(path):
 b=path.read_bytes();u16=lambda p:struct.unpack_from('<H',b,p)[0];u32=lambda p:struct.unpack_from('<I',b,p)[0];pe=u32(60);opt=pe+24;need(b[:2]==b'MZ' and b[pe:pe+4]==b'PE\0\0' and u16(pe+4)==0x8664 and u16(opt)==0x20b,'AMD64 native fixture required');need(u32(opt+16)==0,'No DLL entry point admitted');need(u32(opt+112+8)==0 and u32(opt+112+8+4)==0,'Native fixture must have NO import table');need(u32(opt+112+9*8)==0,'Native fixture must have NO TLS initialization');segments=[]
 for n in range(u16(pe+6)):
  at=opt+u16(pe+20)+n*40;vs,rva,rs,fo=struct.unpack_from('<IIII',b,at+8);segments.append((rva,rs,fo))
 def raw(rva,size):
  matches=[fo+rva-start for start,count,fo in segments if start<=rva and rva+size<=start+count];need(len(matches)==1,'Native fixture export bounds');return matches[0]
 exp=raw(u32(opt+112),40);count=u32(exp+24);need(count==2,'Exactly two inert exports required');names=raw(u32(exp+32),count*4);exports=[]
 for n in range(count):
  p=raw(u32(names+4*n),1);end=b.find(b'\0',p,p+128);need(end>=p,'Export string bound');exports.append(b[p:end].decode('ascii'))
 need(set(exports)=={'CheckGuid','WriteUnsignedOut'},'Unexpected native fixture exports');return {'machine':'AMD64','entry_point_RVA':0,'import_directory_RVA':0,'TLS_directory_RVA':0,'exports':exports}
def main():
 folder=Path(sys.argv[1]);need(folder.parent==ROOT/'Validation' and folder.name.startswith('Win32MarshalABICompatibility-') and not folder.exists(),'Fresh isolated validation folder required');folder.mkdir();report={'schema':'Windowsx64-ABI-compatibility-descriptor-fixture/v1','started_utc':datetime.now(timezone.utc).isoformat(),'original_lost_descriptor_blobs_recovered':False,'actual_RR23_or_harness_modified':False,'Windows_trust_device_game_or_vendor_APIs_invoked':False,'phases':[]}
 compiler=Path(r'C:\Program Files\Microsoft Visual Studio\18\Community\VC\Tools\MSVC\14.51.36231\bin\Hostx64\x64\cl.exe');linker=compiler.with_name('link.exe');need(compiler.is_file() and linker.is_file(),'Genuine installed matching x64 compiler/linker required')
 native=folder/'InertNative.c';obj=folder/'InertNative.obj';dll=folder/'SolarNet_InertMarshalABI.dll';native.write_text('__declspec(dllexport) int __cdecl WriteUnsignedOut(unsigned int* p) { if(!p) return 0; *p=0xDEADBEEFu; return 1; }\n__declspec(dllexport) int __cdecl CheckGuid(const unsigned char* p) { return p && '+ ' && '.join('p['+str(i)+']=='+str(i) for i in range(16))+'; }\n')
 managed=folder/'CompatibilityProbe.cs';exe=folder/'CompatibilityProbe.exe';managed.write_text('using System; using System.Runtime.InteropServices; public static class CompatibilityProbe { [DllImport(@"'+str(dll)+'", CallingConvention=CallingConvention.Cdecl, ExactSpelling=true)] private static extern int WriteUnsignedOut([Out,MarshalAs(UnmanagedType.U4)] out uint value); [DllImport(@"'+str(dll)+'", CallingConvention=CallingConvention.Cdecl, ExactSpelling=true)] private static extern int CheckGuid([In,MarshalAs(UnmanagedType.LPStruct)] Guid value); public static int Main() { uint value; if(WriteUnsignedOut(out value)!=1 || value!=0xDEADBEEF) return 10; Console.WriteLine("U4_OUT_ALL_BITS_OK "+value.ToString("X8")); byte[] bytes=new byte[16]; for(int i=0;i<16;i++) bytes[i]=(byte)i; if(CheckGuid(new Guid(bytes))!=1) return 11; for(int i=0;i<16;i++) { byte[] bad=(byte[])bytes.Clone(); bad[i]^=255; if(CheckGuid(new Guid(bad))!=0) return 12; } Console.WriteLine("LPSTRUCT_GUID_ALL16_BYTES_OK 16_NEGATIVES_REJECTED"); Console.WriteLine("INERT_NATIVE_ABI_COMPATIBILITY_OK"); return 0; } }\n')
 mscorlib=EDITOR/'Data/MonoBleedingEdge/lib/mono/unityjit/mscorlib.dll';rsp=folder/'compile-managed.rsp';rsp.write_text('/nologo\n/noconfig\n/nostdlib+\n/target:exe\n/out:"'+str(exe)+'"\n/reference:"'+str(mscorlib)+'"\n"'+str(managed)+'"\n')
 try:
  report['phases'].append(phase([compiler,'/nologo','/c','/O2','/GS-','/Zl','/TC','/Fo'+str(obj),native],folder,'compile-native',256*1024**2,15))
  report['phases'].append(phase([linker,'/NOLOGO','/DLL','/NOENTRY','/NODEFAULTLIB','/MACHINE:X64','/OUT:'+str(dll),obj],folder,'link-native',256*1024**2,15));report['native_binary_safety']=native_contract(dll)
  report['phases'].append(phase([EDITOR/'Data/Tools/Roslyn/csc.exe','@'+str(rsp)],folder,'compile-managed',256*1024**2,15))
  kernel=ctypes.WinDLL('kernel32',use_last_error=True);kernel.SetErrorMode.argtypes=[ctypes.c_uint];kernel.SetErrorMode.restype=ctypes.c_uint;prior=kernel.SetErrorMode(0x8003)
  try:report['phases'].append(phase([EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',exe],folder,'matching-Mono-run',64*1024**2,10))
  finally:kernel.SetErrorMode(prior)
  text=(folder/'matching-Mono-run/output.log').read_text();need('U4_OUT_ALL_BITS_OK DEADBEEF' in text and 'LPSTRUCT_GUID_ALL16_BYTES_OK 16_NEGATIVES_REJECTED' in text and 'INERT_NATIVE_ABI_COMPATIBILITY_OK' in text,'Expected descriptor behavior proof absent');report.update(status='passed',uint32_full_bit_pattern_preserved=True,Guid_all_16_bytes_preserved=True,bad_Guid_variants_rejected=16)
 except BaseException as error:report.update(status='failed',error=repr(error))
 report['files']=[{'path':str(p),'sha256':sha(p)} for p in (native,managed,obj,dll,exe,rsp) if p.is_file()];target=folder/'report.json';target.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(target),'error':report.get('error')}));return 0 if report['status']=='passed' else 1
if __name__=='__main__':raise SystemExit(main())
