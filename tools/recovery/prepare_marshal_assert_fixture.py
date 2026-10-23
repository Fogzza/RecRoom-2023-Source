"""Prepare tiny non-game Mono marshal metadata fixtures; never compiles game code."""
from pathlib import Path
import json,sys
HERE=Path(__file__).resolve().parent;ROOT=HERE.parents[2]/'Recovery/RecRoom-2023-04-18';WORKSPACE=ROOT.parents[1]
def main():
 out=Path(sys.argv[1]);out.mkdir(parents=True,exist_ok=False)
 plain='using System.Runtime.InteropServices; public static class InertMarshalFixture { [DllImport("NeverInvokedNativeLibrary")] public static extern bool Probe(out uint value); }\n'
 correct='using System.Runtime.InteropServices; public static class InertMarshalFixture { [DllImport("NeverInvokedNativeLibrary")] public static extern bool Probe([MarshalAs(UnmanagedType.U4)] out uint value); }\n'
 walker='using System; using System.Reflection; public static class MarshalWalker { public static int Main(string[] args) { Console.WriteLine("BEFORE_LOAD"); var assembly=Assembly.LoadFile(args[0]); var method=assembly.GetType("InertMarshalFixture",true).GetMethod("Probe",BindingFlags.Public|BindingFlags.Static); Console.WriteLine("BEFORE_PARAMETERS"); var parameters=method.GetParameters(); Console.WriteLine("AFTER_PARAMETERS "+parameters.Length); foreach(var p in parameters) Console.WriteLine(p.ParameterType.FullName); Console.WriteLine("FIXTURE_METADATA_ONLY_OK"); return 0; } }\n'
 editor=WORKSPACE/'Tools/Editors/2020.3.33f1/Editor';mscorlib=editor/'Data/MonoBleedingEdge/lib/mono/unityjit/mscorlib.dll'
 if not mscorlib.exists():raise ValueError('Genuine matching Mono mscorlib required')
 for name,text,kind in (('Plain',plain,'library'),('Correct',correct,'library'),('MarshalWalker',walker,'exe')):
  source=out/(name+'.cs');source.write_text(text);target=out/(name+('.dll' if kind=='library' else '.exe'));rsp=out/(name+'.rsp');rsp.write_text('/nologo\n/noconfig\n/nostdlib+\n/target:'+kind+'\n/out:"'+str(target)+'"\n/reference:"'+str(mscorlib)+'"\n"'+str(source)+'"\n')
 print(json.dumps({'fixture':str(out),'matching_compiler':str(editor/'Data/Tools/Roslyn/csc.exe'),'game_code_compiled':False}))
if __name__=='__main__':main()
