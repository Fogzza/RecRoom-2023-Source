// Synthetic reference metadata only, never any method invocation.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using Mono.Cecil;
using Mono.Cecil.Cil;

internal static partial class SDKReferenceAudit
{
    static int ReferenceFixtures(string directory,string editor) {
        try {
            if(Directory.Exists(directory)||File.Exists(directory))throw new InvalidDataException("Fresh reference fixture directory required");Directory.CreateDirectory(directory);
            var rows=new List<object>();
            Action<string,Action<AssemblyDefinition>,Action<AssemblyDefinition>,bool> run=(name,changeSdk,changeConsumer,positive)=>{
                string root=Path.Combine(directory,name),sdk=Path.Combine(root,"sdk");Directory.CreateDirectory(sdk);string plugin=Path.Combine(sdk,"Unity.ResourceManager.dll"),consumer=Path.Combine(root,"Consumer.dll");
                using(var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("Unity.ResourceManager",new Version(0,0,0,0)),"Unity.ResourceManager",ModuleKind.Dll)) {
                    var m=a.MainModule;var t=new TypeDefinition("Fixture","Data",TypeAttributes.Public,m.TypeSystem.Object);m.Types.Add(t);t.Fields.Add(new FieldDefinition("value",FieldAttributes.Public,m.TypeSystem.Int32));
                    var method=new MethodDefinition("Run",MethodAttributes.Public,m.TypeSystem.Int32);method.Parameters.Add(new ParameterDefinition(m.TypeSystem.Int32));method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4_0));method.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));t.Methods.Add(method);changeSdk(a);a.Write(plugin);
                }
                using(var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("Consumer",new Version(0,0,0,0)),"Consumer",ModuleKind.Dll)) {
                    var m=a.MainModule;var scope=new AssemblyNameReference("Unity.ResourceManager",new Version(0,0,0,0));m.AssemblyReferences.Add(scope);var reference=new TypeReference("Fixture","Data",m,scope);
                    var t=new TypeDefinition("Fixture","Consumer",TypeAttributes.Public,m.TypeSystem.Object);m.Types.Add(t);t.Fields.Add(new FieldDefinition("data",FieldAttributes.Public,reference));
                    var method=new MethodReference("Run",m.TypeSystem.Int32,reference){HasThis=true};method.Parameters.Add(new ParameterDefinition(m.TypeSystem.Int32));var field=new FieldReference("value",m.TypeSystem.Int32,reference);
                    var test=new MethodDefinition("NeverInvoked",MethodAttributes.Public|MethodAttributes.Static,m.TypeSystem.Void);t.Methods.Add(test);
                    foreach(var op in new[]{Instruction.Create(OpCodes.Ldnull),Instruction.Create(OpCodes.Ldc_I4_0),Instruction.Create(OpCodes.Callvirt,method),Instruction.Create(OpCodes.Pop),Instruction.Create(OpCodes.Ldnull),Instruction.Create(OpCodes.Ldfld,field),Instruction.Create(OpCodes.Pop),Instruction.Create(OpCodes.Ret)})test.Body.Instructions.Add(op);
                    changeConsumer(a);a.Write(consumer);
                }
                string inputs=Path.Combine(root,"inputs.txt"),report=Path.Combine(root,"report.json");File.WriteAllText(inputs,consumer+Environment.NewLine);
                int code=Main(new[]{inputs,sdk,editor,report});
                if((code==0)!=positive)throw new InvalidDataException("Unexpected SDK reference fixture acceptance: "+name+" exit="+code);
                rows.Add(new{name,accepted=code==0,expected_accept=positive});
            };
            Func<AssemblyDefinition,TypeDefinition> target=a=>a.MainModule.Types.Single(t=>t.Name=="Data");
            run("exact-positive",a=>{},a=>{},true);
            run("missing-field",a=>target(a).Fields.Clear(),a=>{},false);
            run("wrong-field-type",a=>target(a).Fields[0].FieldType=a.MainModule.TypeSystem.String,a=>{},false);
            run("missing-method",a=>target(a).Methods.Clear(),a=>{},false);
            run("wrong-parameter",a=>target(a).Methods[0].Parameters[0].ParameterType=a.MainModule.TypeSystem.String,a=>{},false);
            run("wrong-return",a=>target(a).Methods[0].ReturnType=a.MainModule.TypeSystem.String,a=>{},false);
            run("missing-type",a=>target(a).Name="Renamed",a=>{},false);
            run("wrong-assembly-version",a=>a.Name.Version=new Version(1,0,0,0),a=>{},false);
            File.WriteAllText(Path.Combine(directory,"fixture-report.json"),new JavaScriptSerializer().Serialize(new{schema="sdk-reference-resolution-fixtures/v1",status="passed",controls=rows.Count,rows,game_or_sdk_code_executed=false}));Console.WriteLine("Passed "+rows.Count+" SDK reference resolution controls; no method invoked.");return 0;
        }catch(Exception error){Console.Error.WriteLine(error);return 1;}
    }
}
