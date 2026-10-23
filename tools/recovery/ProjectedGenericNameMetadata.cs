// Metadata-only. Never loads or invokes a game/SDK assembly.
using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
public static class ProjectedGenericNameMetadata
{
    static void Need(bool value,string message) { if(!value)throw new InvalidOperationException(message); }
    public static int Main(string[] args)
    {
        try
        {
            Need(args.Length==4&&!File.Exists(args[3]),"exact raw/projected/consumer/fresh-output arguments");
            var options=new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false};
            using(var raw=ModuleDefinition.ReadModule(args[0],options))
            using(var projected=ModuleDefinition.ReadModule(args[1],options))
            using(var consumer=ModuleDefinition.ReadModule(args[2],options))
            {
                const string identity="RecRoom.Datastructures.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
                Need(raw.Assembly.FullName==identity&&projected.Assembly.FullName==identity,"same original/projected assembly identity");
                var a=raw.Types.Single(t=>t.FullName=="HHOBPMOCKMJ");
                var b=projected.Types.Single(t=>t.FullName=="HHOBPMOCKMJ`1");
                Need(a.MetadataToken.ToUInt32()==0x02000032&&b.MetadataToken.ToUInt32()==0x02000032&&a.GenericParameters.Count==1&&b.GenericParameters.Count==1,"exact original/projected generic definition token and arity");
                Need(!raw.Types.Any(t=>t.FullName=="HHOBPMOCKMJ`1"),"raw SDK has no arity-suffixed alternative definition");
                var owner=consumer.Types.Single(t=>t.FullName=="Recovery.ProjectedGenericBinding.Consumer");
                var method=owner.Methods.Single(m=>m.Name=="ProjectedClosedType");
                Need(method.IsPublic&&method.IsStatic&&!method.HasParameters&&method.ReturnType.FullName=="System.Type"&&method.HasBody&&!method.Body.ExceptionHandlers.Any(),"minimal consumer method signature");
                var tokens=method.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldtoken).ToArray();
                Need(tokens.Length==1&&tokens[0].Operand is GenericInstanceType,"one actual compiled generic ldtoken");
                var requested=(GenericInstanceType)tokens[0].Operand;
                Need(requested.ElementType.FullName=="HHOBPMOCKMJ`1"&&requested.ElementType.Scope.ToString()==identity&&requested.GenericArguments.Count==1&&requested.GenericArguments[0].FullName=="UnityEngine.GameObject"&&requested.GenericArguments[0].Scope.Name=="UnityEngine.CoreModule","actual requested name/scope/argument unchanged");
                var calls=method.Body.Instructions.Where(i=>i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Callvirt||i.OpCode.Code==Code.Newobj).ToArray();
                Need(calls.Length==1&&((MethodReference)calls[0].Operand).FullName=="System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)","consumer only converts the actual generic type handle; no SDK method/constructor");
                Need(!owner.Methods.Any(m=>m.IsConstructor)&&!consumer.Types.Single(t=>t.Name=="<Module>").Methods.Any(),"no consumer type/module initializer");
                File.WriteAllLines(args[3],new[]{
                    "schema=actual-projected-generic-consumer-metadata/v1",
                    "status=actual_compiler_requested_name_and_raw_definition_proven",
                    "requested_type="+requested.ElementType.FullName,
                    "requested_scope="+requested.ElementType.Scope,
                    "requested_closed_type="+requested.FullName,
                    "raw_type="+a.FullName,
                    "raw_scope="+raw.Assembly.FullName,
                    "raw_token="+a.MetadataToken,
                    "raw_mvid="+raw.Mvid,
                    "projected_mvid="+projected.Mvid,
                    "consumer_mvid="+consumer.Mvid,
                    "raw_generic_parameter_count="+a.GenericParameters.Count,
                    "metadata_only_no_game_or_SDK_execution=true"});
            }
            return 0;
        }
        catch(Exception error){Console.Error.WriteLine(error);return 1;}
    }
}
