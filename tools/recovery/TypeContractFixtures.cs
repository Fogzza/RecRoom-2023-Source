using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using RR23.MetadataRestoration;

static class TypeContractFixtures
{
#if RR23_METHOD_SUBSET
    static int CuratedResponseReferenceFixtures()
    {
        string root=Path.Combine(Path.GetTempPath(),"RR23Refs-"+Guid.NewGuid().ToString("N"));Directory.CreateDirectory(root);
        string first=Path.Combine(root,"Library","ScriptAssemblies","Assembly-CSharp-firstpass.dll"),plugin=Path.Combine(root,"Assets","Plugins","Fixture.Tags.dll");Directory.CreateDirectory(Path.GetDirectoryName(first));Directory.CreateDirectory(Path.GetDirectoryName(plugin));
        using(var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("Assembly-CSharp-firstpass",new Version(0,0,0,0)),"Assembly-CSharp-firstpass",ModuleKind.Dll))a.Write(first);
        using(var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("Fixture.Tags",new Version(0,0,0,0)),"Fixture.Tags",ModuleKind.Dll))
        {var t=new TypeDefinition("Fixture","OriginalEnum",TypeAttributes.Public|TypeAttributes.Sealed,a.MainModule.ImportReference(typeof(Enum)));a.MainModule.Types.Add(t);t.Fields.Add(new FieldDefinition("value__",FieldAttributes.Public|FieldAttributes.SpecialName|FieldAttributes.RTSpecialName,a.MainModule.TypeSystem.Int32));a.Write(plugin);}
        string hash;using(var sha=System.Security.Cryptography.SHA256.Create())hash=BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(plugin))).Replace("-","").ToLowerInvariant();
        for(int mutation=0;mutation<6;mutation++)
        {
            string reference=first,expected=hash;
            if(mutation==1)expected=new string('0',64);
            if(mutation==2){reference=Path.Combine(root,"Elsewhere","Assembly-CSharp-firstpass.dll");Directory.CreateDirectory(Path.GetDirectoryName(reference));File.Copy(first,reference);}
            if(mutation==3){reference=Path.Combine(root,"OtherProject","Library","ScriptAssemblies","Assembly-CSharp-firstpass.dll");Directory.CreateDirectory(Path.GetDirectoryName(reference));File.Copy(first,reference);}
            bool failed=false;
            try
            {
                var refs=mutation==4?new[]{first,plugin}:new[]{reference};
                using(var resolver=new ExactMetadataReferenceResolver(refs,new[]{new CuratedRuntimeMetadataReference("Fixture.Tags",mutation==4?new string('1',64):expected)}))
                {
                    if(mutation==5)resolver.Resolve(new AssemblyNameReference("Fixture.Tags",new Version(1,0,0,0)));
                    else using(var consumer=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("Consumer",new Version(1,0)),"Consumer",new ModuleParameters{Kind=ModuleKind.Dll,AssemblyResolver=resolver}))
                    {
                        var scope=new AssemblyNameReference("Fixture.Tags",new Version(0,0,0,0));consumer.MainModule.AssemblyReferences.Add(scope);var t=new TypeDefinition("","Consumer",TypeAttributes.Public,consumer.MainModule.TypeSystem.Object);consumer.MainModule.Types.Add(t);t.Fields.Add(new FieldDefinition("Value",FieldAttributes.Public|FieldAttributes.Static|FieldAttributes.Literal|FieldAttributes.HasDefault,new TypeReference("Fixture","OriginalEnum",consumer.MainModule,scope)){Constant=7});
                        using(var data=new MemoryStream())consumer.Write(data);
                    }
                }
            }
            catch(Exception e){if(!(e is InvalidDataException||e is AssemblyResolutionException))throw;failed=true;}
            if(failed!=(mutation!=0))throw new Exception("Curated omitted-response reference fixture "+mutation);
        }
        return 6;
    }
    static int SemanticsCacheFixtures()
    {
        byte[] image;
        using(var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("CacheFixture",new Version(1,0)),"CacheFixture",ModuleKind.Dll))
        {
            var t=new TypeDefinition("","Leaf",TypeAttributes.Public,a.MainModule.TypeSystem.Object);a.MainModule.Types.Add(t);
            var m=new MethodDefinition("Original",MethodAttributes.Public,a.MainModule.TypeSystem.Char);m.Parameters.Add(new ParameterDefinition(a.MainModule.TypeSystem.Int32));t.Methods.Add(m);
            m.Body.Instructions.Add(Mono.Cecil.Cil.Instruction.Create(Mono.Cecil.Cil.OpCodes.Ldc_I4_0));m.Body.Instructions.Add(Mono.Cecil.Cil.Instruction.Create(Mono.Cecil.Cil.OpCodes.Ret));
            using(var stream=new MemoryStream()){a.Write(stream);image=stream.ToArray();}
        }
        using(var failed=AssemblyDefinition.ReadAssembly(new MemoryStream(image)))
        {
            var m=failed.MainModule.Types.Single(t=>t.Name=="Leaf").Methods.Single();m.SemanticsAttributes=MethodSemanticsAttributes.Getter;
            if(m.SemanticsAttributes!=MethodSemanticsAttributes.None)throw new Exception("Pinned Cecil cache bug was not reproduced");
        }
        using(var a=AssemblyDefinition.ReadAssembly(new MemoryStream(image)))
        {
            var t=a.MainModule.Types.Single(x=>x.Name=="Leaf");var m=t.Methods.Single();var flags=m.Attributes;var impl=m.ImplAttributes;var first=m.Body.Instructions[0];
            if(m.SemanticsAttributes!=MethodSemanticsAttributes.Getter)m.SemanticsAttributes=MethodSemanticsAttributes.Getter;
            if(m.SemanticsAttributes!=MethodSemanticsAttributes.Getter)throw new Exception("Original getter semantics lost after exact cache materialization");
            t.Properties.Add(new PropertyDefinition("Named",PropertyAttributes.None,m.ReturnType){GetMethod=m});
            using(var stream=new MemoryStream())
            {
                a.Write(stream);using(var b=AssemblyDefinition.ReadAssembly(new MemoryStream(stream.ToArray())))
                {
                    var n=b.MainModule.Types.Single(x=>x.Name=="Leaf").Methods.Single();
                    if(n.SemanticsAttributes!=MethodSemanticsAttributes.Getter||n.Attributes!=flags||n.ImplAttributes!=impl||n.Body.Instructions.Count!=2||n.Body.Instructions[0].OpCode!=first.OpCode)throw new Exception("Exact getter metadata/body failed writer roundtrip");
                }
            }
        }
        return 3;
    }
    static int PropertyInverseFixtures()
    {
        for(int mutation=0;mutation<6;mutation++)using(var raw=Create(false))using(var actual=Create(false))
        {
            var ot=raw.MainModule.Types.Single(t=>t.Name=="Box");var ct=actual.MainModule.Types.Single(t=>t.Name=="Box");ot.Name=ct.Name="DJDADKAAOLE";
            var getter=new MethodDefinition("PGNPFMMCBMF",MethodAttributes.Public,raw.MainModule.TypeSystem.Char);getter.Parameters.Add(new ParameterDefinition(raw.MainModule.TypeSystem.Int32));ot.Methods.Add(getter);
            var current=new MethodDefinition("PGNPFMMCBMF",MethodAttributes.Public,actual.MainModule.TypeSystem.Char);current.Parameters.Add(new ParameterDefinition(actual.MainModule.TypeSystem.Int32));ct.Methods.Add(current);
            var prop=new PropertyDefinition("POFBPBHJKPE",PropertyAttributes.None,raw.MainModule.TypeSystem.Char){GetMethod=getter,MetadataToken=new MetadataToken(TokenType.Property,0x26de)};ot.Properties.Add(prop);
            if(mutation==1)prop.MetadataToken=new MetadataToken(TokenType.Property,0x26df);
            if(mutation==2){ct.Properties.Add(new PropertyDefinition("A",PropertyAttributes.None,current.ReturnType){GetMethod=current});ct.Properties.Add(new PropertyDefinition("B",PropertyAttributes.None,current.ReturnType){GetMethod=current});}
            if(mutation==3)prop.Name="Unproven";
            if(mutation==4)current.ReturnType=actual.MainModule.TypeSystem.Int32;
            if(mutation==5)prop.Attributes=PropertyAttributes.SpecialName;
            var plan=new WholeMetadataManifest {Types=new[]{new TypeReferenceAlias{Assembly="Assembly-CSharp",OriginalFullName=ot.FullName,CompiledFullName=ct.FullName}},Definitions=new[]{new ExactTypePlan{OriginalFullName=ot.FullName,CompiledFullName=ct.FullName,Methods=new[]{new ExactMethodPlan{OriginalCanonicalSignature=CanonicalMetadataSignatures.Method(getter),CompiledCanonicalSignature=CanonicalMetadataSignatures.Method(current)}}}}};
            bool failed=false;try{int added=ExactOriginalPropertyRestoration.Apply(actual.MainModule,raw.MainModule,plan);if(mutation==0&&(added!=1||ct.Properties.Single().GetMethod!=current||!ReferenceEquals(ct.Properties.Single().Parameters[0],current.Parameters[0])))throw new Exception("Property inverse lost original accessor identity");}catch(InvalidDataException){failed=true;}
            if(failed!=(mutation!=0))throw new Exception("Parameterized PropertyDef inverse fixture "+mutation);
        }
        return 6;
    }
#endif
    static AssemblyDefinition Create(bool projected)
    {
        var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("Assembly-CSharp",new Version(1,0)),"Assembly-CSharp",ModuleKind.Dll);
        var t=new TypeDefinition("","Box"+(projected?"`1":""),TypeAttributes.Public|TypeAttributes.BeforeFieldInit,a.MainModule.TypeSystem.Object);a.MainModule.Types.Add(t);
        var g=new GenericParameter("T",t);g.Constraints.Add(new GenericParameterConstraint(a.MainModule.ImportReference(typeof(IDisposable))));t.GenericParameters.Add(g);
        var m=new MethodDefinition("Leaf",MethodAttributes.Public|MethodAttributes.Static,a.MainModule.TypeSystem.Void);m.GenericParameters.Add(new GenericParameter("U",m));t.Methods.Add(m);return a;
    }
    static int Main()
    {
        try
        {
            using(var raw=Create(false))
            {
                var ot=raw.MainModule.Types.Single(t=>t.Name=="Box");var om=ot.Methods.Single();
                var names=new[]{new TypeReferenceAlias{Assembly="Assembly-CSharp",OriginalFullName="Box",CompiledFullName="Box`1"}};
                Func<AssemblyDefinition,ExactTypePlan[]> plans=a=>new[]{new ExactTypePlan{OriginalFullName="Box",CompiledFullName="Box`1",Methods=new[]{new ExactMethodPlan{OriginalCanonicalSignature=CanonicalMetadataSignatures.Method(om),CompiledCanonicalSignature=CanonicalMetadataSignatures.Method(a.MainModule.Types.Single(t=>t.Name=="Box`1").Methods.Single())}}}};
                using(var good=Create(true))OriginalTypeContractChecks.VerifyProjected(good.MainModule,raw.MainModule,plans(good),names);
                int count=1;
                Action<string,Action<TypeDefinition>> reject=(label,mutation)=>{
                    using(var bad=Create(true)){var t=bad.MainModule.Types.Single(x=>x.Name=="Box`1");mutation(t);bool rejected=false;try{OriginalTypeContractChecks.VerifyProjected(bad.MainModule,raw.MainModule,plans(bad),names);}catch(InvalidDataException){rejected=true;}if(!rejected)throw new Exception("Unsafe contract mutation accepted: "+label);count++;}
                };
                reject("BeforeFieldInit",t=>t.IsBeforeFieldInit=false);
                reject("layout",t=>t.PackingSize=4);
                reject("base",t=>t.BaseType=t.Module.ImportReference(typeof(Exception)));
                reject("interface",t=>t.Interfaces.Add(new InterfaceImplementation(t.Module.ImportReference(typeof(IDisposable)))));
                reject("type-generic-flags",t=>t.GenericParameters[0].Attributes=GenericParameterAttributes.ReferenceTypeConstraint);
                reject("type-generic-constraint",t=>t.GenericParameters[0].Constraints.Clear());
                reject("method-generic-flags",t=>t.Methods[0].GenericParameters[0].Attributes=GenericParameterAttributes.ReferenceTypeConstraint);
                reject("inferred-generic-marker",t=>t.GenericParameters[0].CustomAttributes.Add(new CustomAttribute(new MethodReference(".ctor",t.Module.TypeSystem.Void,new TypeReference("System.Runtime.CompilerServices","IsUnmanagedAttribute",t.Module,t.Module.TypeSystem.CoreLibrary)){HasThis=true},new byte[]{1,0,0,0})));
#if RR23_METHOD_SUBSET
                using(var actual=Create(false))
                {
                    var current=actual.MainModule.Types.Single(t=>t.Name=="Box");
                    var missing=new MethodDefinition(".cctor",MethodAttributes.Private|MethodAttributes.Static|MethodAttributes.SpecialName|MethodAttributes.RTSpecialName,raw.MainModule.TypeSystem.Void);
                    missing.MetadataToken=new MetadataToken(TokenType.Method,17);ot.Methods.Add(missing);
                    Func<UnrecoveredOriginalMethodPlan> row=()=>new UnrecoveredOriginalMethodPlan { OriginalType="Box",OriginalCanonicalSignature=CanonicalMetadataSignatures.Method(missing),ExpectedCompiledCanonicalSignature=CanonicalMetadataSignatures.Method(missing),OriginalProviderMethodToken=missing.MetadataToken.ToUInt32(),OriginalAttributes=(int)missing.Attributes,OriginalImplAttributes=(int)missing.ImplAttributes,OriginalSemantics=0,Classification="unrecovered-original-static-constructor" };
                    if(EmittedOriginalMethodSubsetPolicy.Select(raw.MainModule,ot,current,new[]{row()}).Length!=1)throw new Exception("Explicit missing original subset positive");count++;
                    Action<Action<UnrecoveredOriginalMethodPlan>> bad=change=>{var r=row();change(r);bool refused=false;try{EmittedOriginalMethodSubsetPolicy.Select(raw.MainModule,ot,current,new[]{r});}catch(InvalidDataException){refused=true;}if(!refused)throw new Exception("Unsafe missing-original method accepted");count++;};
                    bad(r=>r.OriginalProviderMethodToken++);bad(r=>r.OriginalAttributes++);bad(r=>r.OriginalImplAttributes++);bad(r=>r.OriginalSemantics=1);bad(r=>r.Classification="invented-default-body");
                    var emitted=new MethodDefinition(".cctor",missing.Attributes,actual.MainModule.TypeSystem.Void);current.Methods.Add(emitted);
                    bool rejectEmitted=false;try{EmittedOriginalMethodSubsetPolicy.Select(raw.MainModule,ot,current,new[]{row()});}catch(InvalidDataException){rejectEmitted=true;}if(!rejectEmitted)throw new Exception("Already-emitted original accepted as missing");count++;
                    bool rejectScope=false;try{EmittedOriginalMethodSubsetPolicy.VerifyScope(new TypeDefinition[0],new[]{row()});}catch(InvalidDataException){rejectScope=true;}if(!rejectScope)throw new Exception("Gap outside emitted scope accepted");count++;
                }
#endif
                #if RR23_METHOD_SUBSET
                count+=PropertyInverseFixtures();
                count+=SemanticsCacheFixtures();
                count+=CuratedResponseReferenceFixtures();
                #endif
                Console.WriteLine("PASS "+count+" exact original type/generic contract fixtures; inspected/game code never executed.");return 0;
            }
        }
        catch(Exception e){Console.Error.WriteLine(e.ToString());return 1;}
    }
}
