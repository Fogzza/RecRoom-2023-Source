// Trusted synthetic metadata only; no game or inspected assembly is executed.
using System;
using System.IO;
using System.Security.Cryptography;
using Mono.Cecil;
using RR23.MetadataRestoration;

static class PlayerReferenceRootFixtures
{
    static int checks;
    static string Digest(string p) { using(var f=File.OpenRead(p))using(var s=SHA256.Create())return BitConverter.ToString(s.ComputeHash(f)).Replace("-", "").ToLowerInvariant(); }
    static void Reject(string label, Action action)
    {
        bool rejected=false;
        try { action(); } catch(InvalidDataException) { rejected=true; } catch(AssemblyResolutionException) { rejected=true; }
        if(!rejected)throw new Exception("Negative accepted: "+label);
        checks++; Console.WriteLine("PASS refusal "+label);
    }
    static string Dll(string p, string name, bool enumType)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(p));
        using(var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition(name,new Version(1,0,0,0)),name,ModuleKind.Dll))
        {
            if(enumType)
            {
                var t=new TypeDefinition("Fixture","Mode",TypeAttributes.Public|TypeAttributes.Sealed,a.MainModule.ImportReference(typeof(Enum)));
                t.Fields.Add(new FieldDefinition("value__",FieldAttributes.Public|FieldAttributes.SpecialName|FieldAttributes.RTSpecialName,a.MainModule.TypeSystem.Int32));
                t.Fields.Add(new FieldDefinition("Zero",FieldAttributes.Public|FieldAttributes.Static|FieldAttributes.Literal|FieldAttributes.HasDefault,t){Constant=0});
                a.MainModule.Types.Add(t);
            }
            a.Write(p);
        }
        return p;
    }
    static string Firstpass(string root,string relative)
    { return Dll(Path.Combine(root,relative,"Assembly-CSharp-firstpass.dll"),"Assembly-CSharp-firstpass",false); }
    static string Runtime(string root)
    { return Dll(Path.Combine(root,"Assets","Plugins","RuntimeFixture.dll"),"RuntimeFixture",true); }
    static CuratedRuntimeMetadataReference[] Curated(string runtime)
    { return new[]{new CuratedRuntimeMetadataReference("RuntimeFixture",Digest(runtime))}; }
    static void ResolveAndEnumWrite(string label,string firstpass,string runtime)
    {
        using(var resolver=new ExactMetadataReferenceResolver(new[]{firstpass},Curated(runtime)))
        {
            var identity=new AssemblyNameReference("RuntimeFixture",new Version(1,0,0,0));
            var actual=resolver.Resolve(identity);
            if(actual.Name.FullName!=identity.FullName || Path.GetFullPath(actual.MainModule.FileName)!=Path.GetFullPath(runtime))throw new Exception("Wrong exact runtime path/identity");
            checks++;
            using(var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("Consumer",new Version(1,0)),"Consumer",new ModuleParameters{Kind=ModuleKind.Dll,AssemblyResolver=resolver}))
            {
                var scope=new AssemblyNameReference("RuntimeFixture",new Version(1,0,0,0));a.MainModule.AssemblyReferences.Add(scope);
                var enumRef=new TypeReference("Fixture","Mode",a.MainModule,scope,true);
                var t=new TypeDefinition("Fixture","Contract",TypeAttributes.Public|TypeAttributes.Interface|TypeAttributes.Abstract,a.MainModule.TypeSystem.Object);a.MainModule.Types.Add(t);
                var m=new MethodDefinition("NeverInvoked",MethodAttributes.Public|MethodAttributes.Abstract|MethodAttributes.Virtual|MethodAttributes.NewSlot,a.MainModule.TypeSystem.Void);t.Methods.Add(m);
                m.Parameters.Add(new ParameterDefinition("value",ParameterAttributes.Optional|ParameterAttributes.HasDefault,enumRef){Constant=0});
                using(var stream=new MemoryStream()){a.Write(stream);if(stream.Length<512)throw new Exception("Exact external enum serialization failed");}
                checks++;
            }
        }
        Console.WriteLine("PASS exact resolve+enum writer "+label);
    }
    static int Main(string[] args)
    {
        try
        {
            string root=Path.GetFullPath(args[0]);Directory.CreateDirectory(root);
            string player=Path.Combine(root,"Player"),p=Firstpass(player,Path.Combine("Library","PlayerScriptAssemblies")),r=Runtime(player);
            if(args.Length>1 && args[1]=="baseline")
            {
                Reject("actual Windows player path in unchanged resolver",()=>{using(var x=new ExactMetadataReferenceResolver(new[]{p},Curated(r))){};});
                Console.WriteLine("BASELINE_REFUSAL_PROVEN "+checks);return 0;
            }
            ResolveAndEnumWrite("Library/PlayerScriptAssemblies",p,r);
            string editor=Path.Combine(root,"Editor"),ep=Firstpass(editor,Path.Combine("Library","ScriptAssemblies")),er=Runtime(editor);
            ResolveAndEnumWrite("existing Library/ScriptAssemblies",ep,er);
            string temp=Path.Combine(root,"TempProject"),tp=Firstpass(temp,"Temp"),tr=Runtime(temp);
            ResolveAndEnumWrite("existing Temp",tp,tr);
            string bad=Path.Combine(root,"BadParent"),bp=Firstpass(bad,Path.Combine("Elsewhere","PlayerScriptAssemblies")),br=Runtime(bad);
            Reject("PlayerScriptAssemblies outside Library",()=>{using(var x=new ExactMetadataReferenceResolver(new[]{bp},Curated(br))){};});
            string bad2=Path.Combine(root,"BadLeaf"),bp2=Firstpass(bad2,Path.Combine("Library","OtherPlayerAssemblies")),br2=Runtime(bad2);
            Reject("unapproved Library leaf",()=>{using(var x=new ExactMetadataReferenceResolver(new[]{bp2},Curated(br2))){};});
            Reject("ambiguous two project firstpasses",()=>{using(var x=new ExactMetadataReferenceResolver(new[]{p,ep},Curated(r))){};});
            Reject("curated SHA mismatch",()=>{using(var x=new ExactMetadataReferenceResolver(new[]{p},new[]{new CuratedRuntimeMetadataReference("RuntimeFixture",new string('0',64))})){};});
            Reject("curated name traversal",()=>{using(var x=new ExactMetadataReferenceResolver(new[]{p},new[]{new CuratedRuntimeMetadataReference("../RuntimeFixture",Digest(r))})){};});
            using(var x=new ExactMetadataReferenceResolver(new[]{p},Curated(r)))
            {
                Reject("wrong assembly version",()=>x.Resolve(new AssemblyNameReference("RuntimeFixture",new Version(2,0,0,0))));
                Reject("no default resolver fallback",()=>x.Resolve(new AssemblyNameReference("NotSupplied",new Version(1,0,0,0))));
            }
            string facade=Path.Combine(player,"CompilerSupport","References","RuntimeFixture.dll");Dll(facade,"CompilerOnlyDifferentIdentity",false);
            using(var x=new ExactMetadataReferenceResolver(new[]{facade},Curated(r)))
            {
                var a=x.Resolve(new AssemblyNameReference("RuntimeFixture",new Version(1,0,0,0)));
                if(Path.GetFullPath(a.MainModule.FileName)!=Path.GetFullPath(r))throw new Exception("Facade was not replaced with original runtime metadata");checks++;
            }
            Reject("missing exact runtime file",()=>{using(var x=new ExactMetadataReferenceResolver(new[]{p},new[]{new CuratedRuntimeMetadataReference("MissingRuntime",Digest(r))})){};});
            Console.WriteLine("PASS "+checks+" player-root/unchanged Editor/Temp/identity/hash/facade/no-fallback controls");
            return 0;
        }
        catch(Exception e){Console.Error.WriteLine(e);return 1;}
    }
}
