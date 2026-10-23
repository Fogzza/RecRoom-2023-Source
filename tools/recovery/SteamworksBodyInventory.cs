// Metadata/IL inventory only: inspected SDK and game assemblies are never loaded.
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

static class SteamworksBodyInventory
{
    static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types)
    { foreach(var type in types){ yield return type; foreach(var child in Walk(type.NestedTypes)) yield return child; } }
    static string MethodKey(MethodReference m) => m.Name+"|"+m.GenericParameters.Count+"|"+m.ReturnType.FullName+"|"+string.Join(";",m.Parameters.Select(p=>p.ParameterType.FullName));
    static string FieldKey(FieldReference f) => f.Name+"|"+f.FieldType.FullName;
    static void Need(bool value,string reason){ if(!value) throw new InvalidDataException(reason); }
    static int Main(string[] args)
    {
        Need(args.Length==3&&!File.Exists(args[2]),"official-SDK.dll original-metadata-core.dll fresh-output.json");
        using var sdk=ModuleDefinition.ReadModule(args[0],new ReaderParameters{ReadingMode=ReadingMode.Deferred});
        using var raw=ModuleDefinition.ReadModule(args[1],new ReaderParameters{ReadingMode=ReadingMode.Deferred});
        var sourceTypes=Walk(sdk.Types).Where(t=>t.FullName!="<Module>").ToArray();
        Need(sourceTypes.All(t=>t.Namespace=="Steamworks"||t.DeclaringType!=null),"Unexpected source SDK namespace");
        var nativeTypes=Walk(raw.Types).Where(t=>t.Namespace=="Steamworks"||t.DeclaringType?.Namespace=="Steamworks").ToDictionary(t=>t.FullName,StringComparer.Ordinal);
        var allSdkTypes=sourceTypes.ToDictionary(t=>t.FullName,StringComparer.Ordinal);
        var missingTypes=new List<string>();var typeRows=new List<object>();var methods=new List<object>();
        var joinedMethods=new Dictionary<string,MethodDefinition>(StringComparer.Ordinal);
        var joinedFields=new HashSet<string>(StringComparer.Ordinal);
        foreach(var type in sourceTypes)
        {
            if(!nativeTypes.TryGetValue(type.FullName,out var original)){missingTypes.Add(type.FullName);continue;}
            var originalMethods=original.Methods.GroupBy(MethodKey).ToDictionary(g=>g.Key,g=>g.ToArray(),StringComparer.Ordinal);
            var originalFields=original.Fields.GroupBy(FieldKey).ToDictionary(g=>g.Key,g=>g.ToArray(),StringComparer.Ordinal);
            int fieldsJoined=0, methodsJoined=0;
            foreach(var field in type.Fields)
                if(originalFields.TryGetValue(FieldKey(field),out var fieldMatches)&&fieldMatches.Length==1&&fieldMatches[0].Attributes==field.Attributes)
                {joinedFields.Add(type.FullName+"|"+FieldKey(field));fieldsJoined++;}
            foreach(var method in type.Methods)
                if(originalMethods.TryGetValue(MethodKey(method),out var matches)&&matches.Length==1)
                {joinedMethods.Add(type.FullName+"|"+MethodKey(method),matches[0]);methodsJoined++;}
            typeRows.Add(new{type=type.FullName,sdk_token=type.MetadataToken.ToUInt32(),raw_metadata_token=original.MetadataToken.ToUInt32(),
                sdk_flags=(int)type.Attributes,raw_flags=(int)original.Attributes,sdk_fields=type.Fields.Count,fields_exact_name_type_flags=fieldsJoined,
                sdk_methods=type.Methods.Count,methods_unique_full_signature=methodsJoined,
                base_type_matches=type.BaseType?.FullName==original.BaseType?.FullName,
                layout_matches=type.ClassSize==original.ClassSize&&type.PackingSize==original.PackingSize,
                interfaces_match=type.Interfaces.Select(i=>i.InterfaceType.FullName).OrderBy(x=>x).SequenceEqual(original.Interfaces.Select(i=>i.InterfaceType.FullName).OrderBy(x=>x))});
        }
        foreach(var type in sourceTypes) foreach(var method in type.Methods.Where(m=>m.HasBody))
        {
            var identity=type.FullName+"|"+MethodKey(method);var issues=new SortedSet<string>(StringComparer.Ordinal);
            if(!joinedMethods.TryGetValue(identity,out var original))issues.Add("no_unique_original_full_signature");
            else
            {
                if(method.Attributes!=original.Attributes)issues.Add("method_flags_differ");
                if(method.ImplAttributes!=original.ImplAttributes)issues.Add("method_impl_flags_differ");
                if(method.HasThis!=original.HasThis||method.ExplicitThis!=original.ExplicitThis||method.CallingConvention!=original.CallingConvention)issues.Add("calling_convention_differs");
                if(!method.Parameters.Select(p=>(int)p.Attributes).SequenceEqual(original.Parameters.Select(p=>(int)p.Attributes)))issues.Add("parameter_flags_differ");
            }
            var selfReferences=new SortedSet<string>(StringComparer.Ordinal);var externalReferences=new SortedSet<string>(StringComparer.Ordinal);
            void InspectType(TypeReference reference)
            {
                if(reference is GenericInstanceType generic){InspectType(generic.ElementType);foreach(var argument in generic.GenericArguments)InspectType(argument);return;}
                if(reference is TypeSpecification spec){InspectType(spec.ElementType);return;}
                if(reference is GenericParameter)return;
                string name=reference.FullName;
                if(allSdkTypes.ContainsKey(name)){selfReferences.Add("T|"+name);if(!nativeTypes.ContainsKey(name))issues.Add("unmapped_type:"+name);}
                else externalReferences.Add((reference.Scope?.ToString()??"<null>")+"|"+name);
            }
            foreach(var local in method.Body.Variables)InspectType(local.VariableType);
            foreach(var handler in method.Body.ExceptionHandlers)if(handler.CatchType!=null)InspectType(handler.CatchType);
            foreach(var instruction in method.Body.Instructions)
            {
                if(instruction.Operand is MethodReference target)
                {
                    var definition=target is GenericInstanceMethod generic?generic.ElementMethod:target;
                    InspectType(definition.DeclaringType);InspectType(definition.ReturnType);foreach(var parameter in definition.Parameters)InspectType(parameter.ParameterType);
                    var owner=definition.DeclaringType is GenericInstanceType instance?instance.ElementType.FullName:definition.DeclaringType.FullName;
                    if(allSdkTypes.ContainsKey(owner))
                    {string key=owner+"|"+MethodKey(definition);selfReferences.Add("M|"+key);if(!joinedMethods.ContainsKey(key))issues.Add("unmapped_method:"+key);}
                    if(target is GenericInstanceMethod constructed)foreach(var argument in constructed.GenericArguments)InspectType(argument);
                }
                else if(instruction.Operand is FieldReference field)
                {
                    InspectType(field.DeclaringType);InspectType(field.FieldType);
                    var owner=field.DeclaringType is GenericInstanceType instance?instance.ElementType.FullName:field.DeclaringType.FullName;
                    if(allSdkTypes.ContainsKey(owner)){string key=owner+"|"+FieldKey(field);selfReferences.Add("F|"+key);if(!joinedFields.Contains(key))issues.Add("unmapped_field:"+key);}
                }
                else if(instruction.Operand is TypeReference reference)InspectType(reference);
                else if(instruction.Operand is CallSite)issues.Add("standalone_callsite_requires_independent_mapping");
            }
            methods.Add(new{owner=type.FullName,name=method.Name,signature=MethodKey(method),sdk_token=method.MetadataToken.ToUInt32(),
                raw_metadata_token=original?.MetadataToken.ToUInt32(),il_instruction_count=method.Body.Instructions.Count,
                exception_handlers=method.Body.ExceptionHandlers.Count,issues=issues.ToArray(),self_reference_count=selfReferences.Count,
                self_references=selfReferences.ToArray(),external_references=externalReferences.ToArray()});
        }
        var payload=new{schema="official-Steamworks14-body-inventory/v1",status="inventory_only_no_bodies_transplanted",
            sdk_code_executed=false,game_code_executed=false,project_modified=false,source_assembly=sdk.Assembly.Name.FullName,
            source_types=sourceTypes.Length,raw_steamworks_types=nativeTypes.Count,missing_types=missingTypes,
            uniquely_joined_methods=joinedMethods.Count,exact_joined_fields=joinedFields.Count,managed_bodies=methods.Count,types=typeRows,methods,
            limitations=new[]{"SDK source restoration would use genuine pinned official source, not recovered native method bodies.","FullName joins are inventory candidates only; scoped identities, generic instantiation and native tokens require independent proof before transplantation.","No gameplay code is made playable by this inventory."}};
        File.WriteAllText(args[2],JsonSerializer.Serialize(payload,new JsonSerializerOptions{WriteIndented=true}));
        Console.WriteLine("SDK managed bodies inventoried: "+methods.Count+"; full-signature joined methods: "+joinedMethods.Count);return 0;
    }
}
