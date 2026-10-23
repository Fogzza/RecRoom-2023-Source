// Trusted metadata-only tests: never invoke inspected framework/game methods.
using System;using System.IO;using System.Linq;using Mono.Cecil;using RR23.MetadataRestoration;
static class FiniteAOTResolverFixtures
{
 static int count;static void Reject(Action a){bool yes=false;try{a();}catch(InvalidDataException){yes=true;}catch(AssemblyResolutionException){yes=true;}if(!yes)throw new Exception("Strict resolver negative accepted");count++;}
 static int Main(string[] args){try{var refs=new[]{args[0],args[1]};var noRuntime=new CuratedRuntimeMetadataReference[0];var inputs=OriginalFrameworkMetadataReferenceInputs.Values;
 using(var r=new ExactMetadataReferenceResolver(refs,noRuntime,inputs))
 {
  foreach(var input in inputs){var a=r.Resolve(AssemblyNameReference.Parse(input.FullName));if(a.Name.FullName!=input.FullName)throw new Exception("Exact finite AOT identity");count++;}
  var jit=r.Resolve(AssemblyNameReference.Parse("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));var aot=r.Resolve(AssemblyNameReference.Parse("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"));if(Object.ReferenceEquals(jit,aot)||jit.Name.FullName==aot.Name.FullName)throw new Exception("Distinct profile identities were aliased");count++;
  using(var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("EnumScopeFixture",new Version(1,0)),"EnumScopeFixture",new ModuleParameters{Kind=ModuleKind.Dll,AssemblyResolver=r}))
  {var scope=AssemblyNameReference.Parse(aot.Name.FullName);a.MainModule.AssemblyReferences.Add(scope);var type=new TypeReference("System.IO.Compression","CompressionLevel",a.MainModule,scope,true);var owner=new TypeDefinition("Fixture","Owner",TypeAttributes.Public,a.MainModule.TypeSystem.Object);a.MainModule.Types.Add(owner);var method=new MethodDefinition("NeverInvoked",MethodAttributes.Public|MethodAttributes.Abstract|MethodAttributes.Virtual|MethodAttributes.NewSlot,a.MainModule.TypeSystem.Void);owner.Methods.Add(method);method.Parameters.Add(new ParameterDefinition("mode",ParameterAttributes.Optional|ParameterAttributes.HasDefault,type){Constant=0});using(var b=new MemoryStream()){a.Write(b);if(b.Length<512)throw new Exception("Enum constant writer");}count++;}
  Reject(()=>r.Resolve(AssemblyNameReference.Parse("System, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e")));
 }
 using(var r=new ExactMetadataReferenceResolver(refs,noRuntime))Reject(()=>r.Resolve(AssemblyNameReference.Parse(inputs.Single(i=>i.FileName=="System.dll").FullName)));
 Reject(()=>{using(var r=new ExactMetadataReferenceResolver(refs,noRuntime,inputs.Concat(inputs.Take(1)))){}});
 Reject(()=>{using(var r=new ExactMetadataReferenceResolver(new[]{args[1]},noRuntime,inputs)){}});
 Reject(()=>{using(var r=new ExactMetadataReferenceResolver(refs,noRuntime,new[]{new CuratedFrameworkMetadataReference(inputs[0].FileName,inputs[0].FullName,new string('0',64))})){}});
 Reject(()=>{using(var r=new ExactMetadataReferenceResolver(refs,noRuntime,new[]{new CuratedFrameworkMetadataReference(inputs[0].FileName,inputs[0].FullName.Replace("4.0.0.0","5.0.0.0"),inputs[0].Sha256)})){}});
 Reject(()=>{using(var r=new ExactMetadataReferenceResolver(refs,noRuntime,new[]{new CuratedFrameworkMetadataReference("../System.dll",inputs[0].FullName,inputs[0].Sha256)})){}});
 Console.WriteLine("PASS "+count+" finite exact AOT/JIT identity/enum writer/refusal tests");return 0;}catch(Exception e){Console.Error.WriteLine(e);return 1;}}
}
