"""Sources only: fixed approved-runtime host + safe metadata walker, never run."""
from pathlib import Path
import hashlib,json,sys
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';PLAN=ROOT/'Validation/Mono64CoreSignature-20261022T151506Z-476ee90a/plan.json';ED=WS/'Tools/Editors/2020.3.33f1/Editor'
def need(b,s):
 if not b:raise ValueError(s)
def sha(p):return hashlib.sha256(Path(p).read_bytes()).hexdigest()
def q(x):need(str(x).isascii(),'Fixed source paths must be ASCII');return json.dumps(str(x))
def main():
 p=json.loads(PLAN.read_text());out=PLAN.parent;need(not (out/'SafeCoreSignatureProbe.cs').exists(),'New reviewed source only');need(p['reference_count'] in (279,285) and p['plugin_count']==225 and not p['host_invoked'] and not p['original_module_initializer_blockers'],'Exact279client plusoptional6finite host references, no module initializer and no prior host invocation required');rows=p['references'];need(len({r['assembly_full_name'] for r in rows})==len(rows),'Ambiguous assemblyFullName whitelist')
 # Reuse the already-reviewed walk logic; replace only Unity integration/logging.
 original=ROOT/'Tools/VerifyRecoveredCompile.cs';text=original.read_text();cut=text.index('    public static void Run()');text=text[:cut];text=text.replace('using UnityEditor;\n','').replace('using UnityEngine;\n','');text=text.replace('public static class VerifyRecoveredCompile','public static class SafeCoreSignatureProbe').replace('Debug.LogError(','Console.Error.WriteLine(')
 text=text.replace('        foreach (var parameter in method.GetParameters()) Parameter(parameter);','        Console.WriteLine("BEFORE_PARAMETERS " + method.DeclaringType.FullName + "::" + method.Name + " token=" + method.MetadataToken.ToString("x8")); Console.Out.Flush();\n        foreach (var parameter in method.GetParameters()) Parameter(parameter);')
 text+='''    private static string HashFile(string path) { using (var file=File.OpenRead(path)) using (var hash=SHA256.Create()) return BitConverter.ToString(hash.ComputeHash(file)).Replace("-", "").ToLowerInvariant(); }
    private static void AuditLoaded() {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
            if (assembly == Assembly.GetExecutingAssembly()) continue;
            var row=PinnedInputs.All.SingleOrDefault(r=>r.FullName==assembly.FullName);
            if (row==null || !String.Equals(Path.GetFullPath(assembly.Location),Path.GetFullPath(row.Path),StringComparison.OrdinalIgnoreCase) || HashFile(row.Path)!=row.Sha) throw new InvalidOperationException("Unwhitelisted loaded assembly: "+assembly.FullName);
        }
    }
    public static int Main() {
        string hash="";bool passed=false;
        try {
            foreach(var row in PinnedInputs.All) {
                if(HashFile(row.Path)!=row.Sha || AssemblyName.GetAssemblyName(row.Path).FullName!=row.FullName) throw new InvalidDataException("Pinned reference identity/hash changed: "+row.FullName);
            }
            AuditLoaded();hash=HashFile(PinnedInputs.Core);
            var core=Assembly.LoadFile(PinnedInputs.Core);Type[] types;
            try {types=core.GetTypes();} catch(ReflectionTypeLoadException error) {types=error.Types.Where(t=>t!=null).ToArray();LoaderErrors("Core.GetTypes",error);}
            if(types.Length<12000 || types.Length>MaximumTypes)throw new TypeLoadException("Unexpected recovered core type count "+types.Length);
            foreach(var type in types) {Console.WriteLine("BEFORE_TYPE "+Label(type));Console.Out.Flush();Walk(type);}
            AuditLoaded();passed=Errors.Count==0&&!StoppedAtLimit;
        } catch(VerificationLimit) {StoppedAtLimit=true;}
          catch(ReflectionTypeLoadException e) {try{LoaderErrors("Checker",e);}catch(VerificationLimit){}}
          catch(Exception e) {try{Error("Checker",e);}catch(VerificationLimit){}}
        File.WriteAllText(PinnedInputs.Report,Report(passed,hash));
        Console.WriteLine(passed?"PINNED_MONO64_CORE_SIGNATURES_OK":"PINNED_MONO64_CORE_SIGNATURES_FAILED");return passed?0:2;
    }
}
'''
 probe=out/'SafeCoreSignatureProbe.cs';probe.write_text(text);references='''// Fixed metadata dependencies only. No constructors or game code are invoked.
internal static class PinnedInputs {
 internal sealed class Row {internal readonly string FullName,Path,Sha;internal Row(string n,string p,string s){FullName=n;Path=p;Sha=s;}}
 internal const string Core=CORE;
 internal const string Report=REPORT;
 internal static readonly Row[] All=new Row[]{ROWS};
}
'''.replace('CORE',q(p['core'])).replace('REPORT',q(out/'signature-walk.json')).replace('ROWS',',\n'.join('new Row('+q(r['assembly_full_name'])+','+q(r['path'])+','+q(r['sha256'])+')' for r in rows));(out/'PinnedInputs.cs').write_text(references)
 # Preload hook returns only exact file-loaded known assemblies. Unknown/mismatched
 # names terminate the OWN host; returningnull would permit fallback directory search.
 oldhost=ROOT/'Validation/MonoX64MarshalCompatibility-20261022T142400Z/FixedMonoX64Host.c';host=oldhost.read_text();oldprobe=ROOT/'Validation/Win32MarshalABICompatibility-20261022T141500Z/CompatibilityProbe.exe';newprobe=out/'SafeCoreSignatureProbe.exe';need(host.count(q(oldprobe))==2,'Pinned old host exact probe fragment changed');host=host.replace(q(oldprobe),q(newprobe)).replace('SolarNet_Own_Nongame_Marshal_Probe','SolarNet_MetadataOnly_CoreSignature_Probe');hook='''
__declspec(dllimport) void* __stdcall GetStdHandle(unsigned long);
__declspec(dllimport) int __stdcall WriteFile(void*,const void*,unsigned long,unsigned long*,void*);
typedef void* (__cdecl *NativeAssemblyOpen)(const char*,int*);
typedef char* (__cdecl *StringifyName)(void*);
typedef void (__cdecl *MonoFree)(void*);
typedef void* (__cdecl *PreloadCallback)(void*,char**,void*);
typedef void (__cdecl *InstallPreload)(PreloadCallback,void*);
static NativeAssemblyOpen exactOpen; static StringifyName stringify;static MonoFree freeMono;
struct Reference {const char* full;const char* path;void* cached;int opening;};
static struct Reference refs[]={ROWS};
static unsigned long len(const char* s){unsigned long n=0;while(s[n])n++;return n;}
static int equal(const char*a,const char*b){while(*a&&*b){if(*a++!=*b++)return0;}return *a==*b;}
static void message(const char*s){unsigned long written;WriteFile(GetStdHandle((unsigned long)-12),s,len(s),&written,0);}
static void* __cdecl ExactPreload(void* name,char** ignored,void* data) {
 char* full=stringify(name);if(!full)ExitProcess(90);
 for(unsigned int i=0;i<sizeof(refs)/sizeof(refs[0]);i++) if(equal(full,refs[i].full)) {
  freeMono(full);if(refs[i].cached)return refs[i].cached;if(refs[i].opening)ExitProcess(91);refs[i].opening=1;
  int status=0;refs[i].cached=exactOpen(refs[i].path,&status);refs[i].opening=0;if(status||!refs[i].cached)ExitProcess(92);return refs[i].cached;
 }
 message("BLOCKED_UNWHITELISTED_ASSEMBLY ");message(full);message("\\n");freeMono(full);ExitProcess(93);return0;
}
'''.replace('return0','return 0').replace('ROWS',',\n'.join('{'+q(r['assembly_full_name'])+','+q(r['path'])+',0,0}' for r in rows));host=host.replace('void __stdcall HostEntry(void) {',hook+'\nvoid __stdcall HostEntry(void) {');insert='''
 InstallPreload install=(InstallPreload)GetProcAddress(runtime,"mono_install_assembly_preload_hook");
 exactOpen=(NativeAssemblyOpen)GetProcAddress(runtime,"mono_assembly_open");stringify=(StringifyName)GetProcAddress(runtime,"mono_stringify_assembly_name");freeMono=(MonoFree)GetProcAddress(runtime,"mono_free");
 if(!install||!exactOpen||!stringify||!freeMono)ExitProcess(84);
 install(ExactPreload,0);
 path(EMPTY);
'''.replace('EMPTY',q(out/'EmptySearchPath'));host=host.replace(' if(!domain) ExitProcess(82);',' if(!domain) ExitProcess(82);'+insert);(out/'EmptySearchPath').mkdir();hostpath=out/'FixedMono64CoreSignatureHost.c';hostpath.write_text(host)
 report={'schema':'safe-signature-host-and-checker-source-review/v1','status':'sources_staged_not_compiled_or_invoked','prior_plan':{'path':str(PLAN),'sha256':sha(PLAN)},'source_inputs':[{'path':str(x),'sha256':sha(x)} for x in [original,oldhost]],'sources':[{'path':str(x),'sha256':sha(x)} for x in [probe,out/'PinnedInputs.cs',hostpath]],'core':p['core'],'core_sha256':p['core_sha256'],'runtime':p['runtime'],'references':rows,'required_additional_exports':['mono_install_assembly_preload_hook','mono_assembly_open','mono_stringify_assembly_name','mono_free'],'dependency_marshal_gaps_preserved':p['malformed_dependency_marshal_owners'],'run_requires_parent_review_and_explicit_diagnostic_authorization':True,'runtime_scope':'Only checkerMain and matchingMono/framework reflection APIs execute. Game/vendor method bodies, custom attribute constructors, GetValue, entrypoint/functionpointer/PInvoke APIs and PlayMode are not invoked.','native_dependency_resolution':'Exact assemblyFullName whitelist via native preload hook; unknownname/wrongidentity exits93, missingfile exits92. Empty general managed search path after matchingcorelib initialized. Loaded assemblies are audited by exact path/hash.','planned_guard':{'maximum_owned_private_bytes':512*1024**2,'deadline_seconds':60,'minimum_available_commit_bytes':1536*1024**2},'project_or_harness_modified':False,'host_invoked':False};(out/'source-review.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'review':str(out/'source-review.json'),'sha256':sha(out/'source-review.json'),'sources_staged':3,'host_invoked':False}))
if __name__=='__main__':
 if len(sys.argv)==2:PLAN=Path(sys.argv[1]).resolve();need(PLAN.parent.parent==ROOT/'Validation' and PLAN.name=='plan.json','Exact validation plan only')
 main()
