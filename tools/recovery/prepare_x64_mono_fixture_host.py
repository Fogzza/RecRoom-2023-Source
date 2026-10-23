"""Prepare/compile a fixed-path matching-Mono x64 host; no execution here."""
import hashlib,json,struct,sys
from pathlib import Path
from run_win32_abi_compat_fixture import phase,native_contract,need,EDITOR,ROOT,WORKSPACE
def sha(p):
 with p.open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def exports(path):
 b=path.read_bytes();u16=lambda p:struct.unpack_from('<H',b,p)[0];u32=lambda p:struct.unpack_from('<I',b,p)[0];pe=u32(60);opt=pe+24;need(u16(pe+4)==0x8664 and u16(opt)==0x20b,'Matching x64 runtime required');segments=[]
 for i in range(u16(pe+6)):
  at=opt+u16(pe+20)+i*40;vs,rva,rs,fo=struct.unpack_from('<IIII',b,at+8);segments.append((rva,rs,fo))
 def raw(rva,size):
  hits=[fo+rva-start for start,count,fo in segments if start<=rva and rva+size<=start+count];need(len(hits)==1,'Runtime export bounds');return hits[0]
 at=raw(u32(opt+112),40);count=u32(at+24);names=raw(u32(at+32),count*4);result=set()
 for i in range(count):
  p=raw(u32(names+4*i),1);end=b.find(b'\0',p,p+256);need(end>=p,'Runtime export name bound');result.add(b[p:end].decode('ascii'))
 return result
def main():
 folder=Path(sys.argv[1]);fixture=Path(sys.argv[2]);need(folder.parent==ROOT/'Validation' and folder.name.startswith('MonoX64MarshalCompatibility-') and not folder.exists(),'Fresh isolated host folder required');need(fixture.parent==ROOT/'Validation' and fixture.name=='Win32MarshalABICompatibility-20261022T141500Z','Only reviewed nongame fixture allowed');folder.mkdir()
 runtime=EDITOR/'Data/MonoBleedingEdge/EmbedRuntime/mono-2.0-bdwgc.dll';required=['mono_set_dirs','mono_set_assemblies_path','mono_config_parse','mono_jit_init_version','mono_domain_assembly_open','mono_jit_exec','mono_jit_cleanup'];found=exports(runtime);need(set(required)<=found,'Required exact matching runtime exports missing');probe=fixture/'CompatibilityProbe.exe';toy=fixture/'SolarNet_InertMarshalABI.dll';safety=native_contract(toy);corelib=EDITOR/'Data/MonoBleedingEdge/lib/mono/unityjit/mscorlib.dll';lib=EDITOR/'Data/MonoBleedingEdge/lib';etc=EDITOR/'Data/MonoBleedingEdge/etc';config=etc/'mono/config';need(all(p.is_file() for p in (probe,toy,corelib,config)),'Fixed matching runtime/probe inputs missing')
 q=lambda p:json.dumps(str(p));c='''/* Fixed reviewed SDK runtime + own probe only. No game, trust or device APIs. */
typedef void* HMODULE;
__declspec(dllimport) HMODULE __stdcall LoadLibraryExW(const unsigned short*,void*,unsigned long);
__declspec(dllimport) void* __stdcall GetProcAddress(HMODULE,const char*);
__declspec(dllimport) void __stdcall ExitProcess(unsigned int);
typedef void (__cdecl *SetDirs)(const char*,const char*);
typedef void (__cdecl *SetPath)(const char*);
typedef void* (__cdecl *Init)(const char*,const char*);
typedef void* (__cdecl *Open)(void*,const char*);
typedef int (__cdecl *Exec)(void*,void*,int,char**);
typedef void (__cdecl *Cleanup)(void*);
void __stdcall HostEntry(void) {
 HMODULE runtime=LoadLibraryExW(LRUNTIME_PATH,0,0x00000100UL|0x00000800UL);
 if(!runtime) ExitProcess(80);
 SetDirs dirs=(SetDirs)GetProcAddress(runtime,"mono_set_dirs");
 SetPath path=(SetPath)GetProcAddress(runtime,"mono_set_assemblies_path");
 SetPath config=(SetPath)GetProcAddress(runtime,"mono_config_parse");
 Init init=(Init)GetProcAddress(runtime,"mono_jit_init_version");
 Open open=(Open)GetProcAddress(runtime,"mono_domain_assembly_open");
 Exec exec=(Exec)GetProcAddress(runtime,"mono_jit_exec");
 Cleanup cleanup=(Cleanup)GetProcAddress(runtime,"mono_jit_cleanup");
 if(!dirs||!path||!config||!init||!open||!exec||!cleanup) ExitProcess(81);
 dirs(LIB_PATH,ETC_PATH); path(CORELIB_DIRECTORY); config(CONFIG_PATH);
 void* domain=init("SolarNet_Own_Nongame_Marshal_Probe","v4.0.30319");
 if(!domain) ExitProcess(82);
 void* assembly=open(domain,PROBE_PATH);
 if(!assembly) ExitProcess(83);
 char* args[1]={PROBE_PATH};
 int result=exec(domain,assembly,1,args);
 cleanup(domain); ExitProcess((unsigned int)result);
}
'''
 for key,value in {'RUNTIME_PATH':q(runtime),'LIB_PATH':q(lib),'ETC_PATH':q(etc),'CORELIB_DIRECTORY':q(corelib.parent),'CONFIG_PATH':q(config),'PROBE_PATH':q(probe)}.items():c=c.replace(key,value)
 source=folder/'FixedMonoX64Host.c';source.write_text(c);obj=folder/'FixedMonoX64Host.obj';host=folder/'FixedMonoX64Host.exe';compiler=Path(r'C:\Program Files\Microsoft Visual Studio\18\Community\VC\Tools\MSVC\14.51.36231\bin\Hostx64\x64\cl.exe');kernel=Path(r'C:\Program Files (x86)\Windows Kits\10\Lib\10.0.26100.0\um\x64\kernel32.lib');need(kernel.is_file(),'Installed genuine SDK kernel32 import library required');plan={'schema':'fixed-matching-Mono-x64-nongame-host/v1','status':'source_staged_not_invoked','required_exports':required,'source':{'path':str(source),'sha256':sha(source)},'inputs':[{'path':str(p),'sha256':sha(p)} for p in (runtime,corelib,config,probe,toy,compiler,compiler.with_name('link.exe'),kernel)],'toy_binary_safety':safety,'source_host_uses_only_fixed_absolute_paths':True,'DLL_search_flags':'LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR | LOAD_LIBRARY_SEARCH_SYSTEM32','Mono_embedding_API_primary_source':'https://www.mono-project.com/docs/advanced/embedding/','game_Windows_trust_device_or_vendor_code_invoked':False,'actual_RR23_or_harness_modified':False,'host_invoked':False,'compile_reports':[]}
 try:
  plan['compile_reports'].append(phase([compiler,'/nologo','/c','/O2','/GS-','/Zl','/TC','/Fo'+str(obj),source],folder,'compile-host',256*1024**2,15))
  plan['compile_reports'].append(phase([compiler.with_name('link.exe'),'/NOLOGO','/NODEFAULTLIB','/ENTRY:HostEntry','/SUBSYSTEM:CONSOLE','/MACHINE:X64','/OUT:'+str(host),obj,kernel],folder,'link-host',256*1024**2,15));plan['host']={'path':str(host),'sha256':sha(host)};plan['status']='compiled_not_invoked'
 except Exception as error:plan.update(status='compile_failed',error=repr(error))
 target=folder/'plan.json';target.write_text(json.dumps(plan,indent=2)+'\n');print(json.dumps({'status':plan['status'],'plan':str(target),'error':plan.get('error'),'host_invoked':False}));return 0 if plan['status']=='compiled_not_invoked' else 1
if __name__=='__main__':raise SystemExit(main())
