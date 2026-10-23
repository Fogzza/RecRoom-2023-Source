// Trusted synthetic metadata only: no inspected game assembly is loaded.
using System;
using System.IO;
using System.Reflection;
using Mono.Cecil;
static class NullImportMapProbe
{
    static int Main()
    {
        using(var assembly=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("TrustedNullImportFixture",new Version(1,0)),"Fixture",ModuleKind.Dll))
        {
            var type=new TypeDefinition("","Fixture",Mono.Cecil.TypeAttributes.Public,assembly.MainModule.TypeSystem.Object);assembly.MainModule.Types.Add(type);
            var method=new MethodDefinition("Native",Mono.Cecil.MethodAttributes.Private|Mono.Cecil.MethodAttributes.Static|Mono.Cecil.MethodAttributes.PInvokeImpl,assembly.MainModule.TypeSystem.Int64){ImplAttributes=Mono.Cecil.MethodImplAttributes.PreserveSig};type.Methods.Add(method);
            Console.WriteLine("Before: HasBody="+method.HasBody+" HasPInvokeInfo="+method.HasPInvokeInfo+" MapNull="+(method.PInvokeInfo==null));
            try{using(var pe=new MemoryStream()){assembly.Write(pe);Console.WriteLine("WRITE_PASSED bytes="+pe.Length);var reflected=Assembly.Load(pe.ToArray());Console.WriteLine("TYPE_LOAD_PASSED count="+reflected.GetTypes().Length);}}
            catch(Exception error){Console.WriteLine("NULL_MAP_REFUSED "+error.GetType().Name+": "+error.Message);}
        }
        return 0;
    }
}
