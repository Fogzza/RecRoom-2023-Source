// Synthetic CLI metadata only. No generated method is invoked.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using Mono.Cecil;
using Mono.Cecil.Cil;

internal static partial class SDKContractAudit
{
    static MethodDefinition FixtureMethod(TypeDefinition type,string name,TypeReference result,params TypeReference[] parameters) {
        var m=new MethodDefinition(name,MethodAttributes.Public|MethodAttributes.HideBySig,result);
        foreach(var p in parameters)m.Parameters.Add(new ParameterDefinition(p));
        type.Methods.Add(m);m.Body.Instructions.Add(Instruction.Create(OpCodes.Ldnull));m.Body.Instructions.Add(Instruction.Create(OpCodes.Throw));return m;
    }
    static void FixtureSeed(string file) {
        using(var a=AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("FixtureSDK",new Version(0,0,0,0)),"FixtureSDK",ModuleKind.Dll)) {
            var m=a.MainModule;var t=new TypeDefinition("Fixture","Cache",TypeAttributes.Public|TypeAttributes.BeforeFieldInit,m.TypeSystem.Object);m.Types.Add(t);
            t.Fields.Add(new FieldDefinition("value",FieldAttributes.Public,m.TypeSystem.Int32));t.Fields.Add(new FieldDefinition("other",FieldAttributes.Public,m.TypeSystem.String));
            var getter=FixtureMethod(t,"get_Value",m.TypeSystem.Int32);getter.IsSpecialName=true;
            var setter=FixtureMethod(t,"set_Value",m.TypeSystem.Void,m.TypeSystem.Int32);setter.IsSpecialName=true;
            t.Properties.Add(new PropertyDefinition("Value",PropertyAttributes.None,m.TypeSystem.Int32){GetMethod=getter,SetMethod=setter});
            var callback=new TypeDefinition("Fixture","Callback",TypeAttributes.Public|TypeAttributes.Sealed,m.ImportReference(typeof(MulticastDelegate)));m.Types.Add(callback);
            var invoke=FixtureMethod(callback,"Invoke",m.TypeSystem.Int32,m.TypeSystem.Int32);
            var added=FixtureMethod(t,"add_Changed",m.TypeSystem.Void,callback);added.IsSpecialName=true;
            var removed=FixtureMethod(t,"remove_Changed",m.TypeSystem.Void,callback);removed.IsSpecialName=true;
            t.Events.Add(new EventDefinition("Changed",EventAttributes.None,callback){AddMethod=added,RemoveMethod=removed});
            FixtureMethod(t,"Use",m.TypeSystem.Int32,m.TypeSystem.Int32);
            var en=new TypeDefinition("Fixture","Mode",TypeAttributes.Public|TypeAttributes.Sealed,m.ImportReference(typeof(Enum)));m.Types.Add(en);
            en.Fields.Add(new FieldDefinition("value__",FieldAttributes.Public|FieldAttributes.SpecialName|FieldAttributes.RTSpecialName,m.TypeSystem.Int32));
            en.Fields.Add(new FieldDefinition("Three",FieldAttributes.Public|FieldAttributes.Static|FieldAttributes.Literal|FieldAttributes.HasDefault,en){Constant=3});
            var generic=new TypeDefinition("Fixture","Holder`1",TypeAttributes.Public,m.TypeSystem.Object);m.Types.Add(generic);generic.GenericParameters.Add(new GenericParameter("T",generic){Attributes=GenericParameterAttributes.ReferenceTypeConstraint});
            a.Write(file);
        }
    }
    static int SDKContractFixtures(string directory) {
        try {
            if(Directory.Exists(directory)||File.Exists(directory))throw new InvalidDataException("Fresh fixture output required.");Directory.CreateDirectory(directory);
            var raw=Path.Combine(directory,"original.dll");FixtureSeed(raw);var rows=new List<object>();
            Action<string,Action<AssemblyDefinition>,bool> run=(name,mutate,shouldPass)=>{
                string candidate=Path.Combine(directory,name+".dll");using(var a=AssemblyDefinition.ReadAssembly(raw)){
                    // Materialize Cecil's lazy semantics before synthetic mutations.
                    foreach(var t in a.MainModule.Types.SelectMany(All)) { foreach(var m in t.Methods){var ignored=m.SemanticsAttributes;} foreach(var p in t.Properties){var g=p.GetMethod;var s=p.SetMethod;var o=p.OtherMethods.Count;} foreach(var e in t.Events){var ad=e.AddMethod;var rm=e.RemoveMethod;var iv=e.InvokeMethod;var ot=e.OtherMethods.Count;} }
                    mutate(a);a.Write(candidate);
                }
                object result=Compare(raw,raw,candidate);int issues=(int)result.GetType().GetProperty("issue_count").GetValue(result,null);
                if((issues==0)!=shouldPass)throw new InvalidDataException("Unexpected fixture acceptance: "+name+" issues="+issues);
                rows.Add(new {name,expected_accept=shouldPass,accepted=issues==0,issues});
            };
            Func<AssemblyDefinition,TypeDefinition> cache=a=>a.MainModule.Types.Single(t=>t.FullName=="Fixture.Cache");
            run("exact-positive",a=>{},true);
            run("missing-method",a=>cache(a).Methods.Remove(cache(a).Methods.Single(m=>m.Name=="Use")),false);
            run("missing-field",a=>cache(a).Fields.RemoveAt(1),false);
            run("parameter-type",a=>cache(a).Methods.Single(m=>m.Name=="Use").Parameters[0].ParameterType=a.MainModule.TypeSystem.String,false);
            run("return-type",a=>cache(a).Methods.Single(m=>m.Name=="Use").ReturnType=a.MainModule.TypeSystem.String,false);
            run("method-flags",a=>cache(a).Methods.Single(m=>m.Name=="Use").IsStatic=true,false);
            run("method-impl-flags",a=>cache(a).Methods.Single(m=>m.Name=="Use").ImplAttributes|=MethodImplAttributes.NoInlining,false);
            run("parameter-marshal",a=>cache(a).Methods.Single(m=>m.Name=="Use").Parameters[0].MarshalInfo=new MarshalInfo(NativeType.I4),false);
            run("return-marshal",a=>cache(a).Methods.Single(m=>m.Name=="Use").MethodReturnType.MarshalInfo=new MarshalInfo(NativeType.I4),false);
            run("field-marshal",a=>cache(a).Fields[0].MarshalInfo=new MarshalInfo(NativeType.I4),false);
            run("parameter-optional-default",a=>{var p=cache(a).Methods.Single(m=>m.Name=="Use").Parameters[0];p.IsOptional=true;p.Constant=4;},false);
            run("property-type",a=>cache(a).Properties[0].PropertyType=a.MainModule.TypeSystem.String,false);
            run("property-accessor",a=>cache(a).Properties[0].GetMethod=cache(a).Methods.Single(m=>m.Name=="Use"),false);
            run("event-handler",a=>cache(a).Events[0].EventType=a.MainModule.TypeSystem.Object,false);
            run("event-accessor",a=>cache(a).Events[0].RemoveMethod=null,false);
            run("delegate-invoke",a=>a.MainModule.Types.Single(t=>t.Name=="Callback").Methods.Single(m=>m.Name=="Invoke").ReturnType=a.MainModule.TypeSystem.String,false);
            run("enum-literal",a=>a.MainModule.Types.Single(t=>t.Name=="Mode").Fields.Single(f=>f.Name=="Three").Constant=4,false);
            run("generic-constraint",a=>a.MainModule.Types.Single(t=>t.Name=="Holder`1").GenericParameters[0].Attributes=GenericParameterAttributes.NotNullableValueTypeConstraint,false);
            run("type-flags",a=>cache(a).IsBeforeFieldInit=false,false);
            run("base-type",a=>cache(a).BaseType=a.MainModule.ImportReference(typeof(Exception)),false);
            run("field-order",a=>{var t=cache(a);var f=t.Fields[0];t.Fields.RemoveAt(0);t.Fields.Add(f);},false);
            run("field-flags",a=>cache(a).Fields[0].IsInitOnly=true,false);
            run("field-addition",a=>cache(a).Fields.Add(new FieldDefinition("extra",FieldAttributes.Public,a.MainModule.TypeSystem.Int32)),false);
            run("assembly-version",a=>a.Name.Version=new Version(1,0,0,0),false);
            run("required-modifier",a=>{var m=cache(a).Methods.Single(x=>x.Name=="Use");m.Parameters[0].ParameterType=new RequiredModifierType(a.MainModule.TypeSystem.Object,m.Parameters[0].ParameterType);},false);
            File.WriteAllText(Path.Combine(directory,"report.json"),new JavaScriptSerializer().Serialize(new {schema="sdk-contract-auditor-negative-fixtures/v1",status="passed",controls=rows.Count,fixtures=rows,game_or_sdk_code_executed=false}));
            Console.WriteLine("Passed "+rows.Count+" synthetic SDK metadata controls; no method invoked.");return 0;
        }catch(Exception error){Console.Error.WriteLine(error);return 1;}
    }
}
