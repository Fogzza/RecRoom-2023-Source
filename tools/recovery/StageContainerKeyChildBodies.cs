// Metadata-only candidate staging. Never load, invoke, or overwrite game code.
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Globalization;
using System.Security.Cryptography;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using RR23.MetadataRestoration;

static class StageContainerKeyChildBodies
{
    static void Need(bool value,string message) { if(!value)throw new InvalidDataException(message); }
    static string Sha(string path) { using var f=File.OpenRead(path);return Convert.ToHexString(SHA256.HashData(f)).ToLowerInvariant(); }
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows) { foreach(var row in rows){yield return row;foreach(var t in Types(row.NestedTypes))yield return t;} }
    static string MethodKey(MethodReference m) { return m.DeclaringType.FullName+"|"+CanonicalMetadataSignatures.Method(m); }
    static string Features(ModuleDefinition module)
    {
        var b=new StringBuilder();
        b.Append(module.Name).Append('|').Append(module.Mvid).Append('|').Append(module.Architecture).Append('|').Append(module.Kind).Append('|').Append(module.RuntimeVersion).Append('|').Append(module.Attributes).Append('|').Append(module.Characteristics).Append('|');
        foreach(var row in module.ModuleReferences)b.Append(row.Name).Append('|');
        foreach(var row in module.ExportedTypes)b.Append(row.FullName).Append(':').Append(row.Attributes).Append(':').Append(row.Scope).Append('|');
        foreach(var r in module.Resources)
        {
            b.Append(r.Name).Append(':').Append(r.Attributes).Append(':').Append(r.ResourceType).Append('|');
            Need(r is EmbeddedResource,"Nonembedded resource needs separate original-file audit");b.Append(Convert.ToHexString(SHA256.HashData(((EmbeddedResource)r).GetResourceData()))).Append('|');
        }
        Need(module.Assembly.SecurityDeclarations.Count==0,"Assembly security declarations need separate original metadata audit");
        foreach(var type in Types(module.Types))
        {
            Need(type.SecurityDeclarations.Count==0,"Type security declarations require an explicit audit");
            foreach(var f in type.Fields)Need(!f.HasMarshalInfo,"Field marshaling is not modified but needs a separate roundtrip comparer");
            foreach(var m in type.Methods)
            {
                Need(m.SecurityDeclarations.Count==0,"Method security declarations require an explicit audit");
                b.Append(m.MetadataToken.ToUInt32()).Append(':').Append(m.CallingConvention).Append(':').Append(m.HasThis).Append(':').Append(m.ExplicitThis).Append('|');
                Need(!m.MethodReturnType.HasMarshalInfo && m.Parameters.All(p=>!p.HasMarshalInfo),"Marshaled member contract requires an explicit roundtrip comparer");
                if(m.HasPInvokeInfo)b.Append(m.PInvokeInfo.Module.Name).Append(':').Append(m.PInvokeInfo.EntryPoint).Append(':').Append(m.PInvokeInfo.Attributes).Append('|');
            }
        }
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(b.ToString())));
    }
    sealed class BodyMap
    {
        readonly ModuleDefinition target;
        readonly MethodDefinition sourceMethod,targetMethod;
        readonly Dictionary<string,TypeDefinition> targetTypes;
        public BodyMap(MethodDefinition source,MethodDefinition destination)
        {
            sourceMethod=source;targetMethod=destination;target=destination.Module;targetTypes=Types(target.Types).ToDictionary(t=>t.FullName,StringComparer.Ordinal);
        }
        TypeReference Type(TypeReference type)
        {
            Need(!(type is TypeSpecification) && !(type is GenericParameter),"No generic/array/modifier/pointer type in four exact selected bodies");
            var scope=type.Scope is AssemblyNameReference reference?reference.Name:type.Scope is ModuleDefinition module?module.Assembly.Name.Name:null;
            if(scope==sourceMethod.Module.Assembly.Name.Name)
            {Need(targetTypes.TryGetValue(type.FullName,out var original),"No donor-only helper declaration may enter target");return original;}
            Need(scope=="mscorlib" && new[]{"System.Type","System.String","System.Object","System.Int32","System.Boolean","System.Void"}.Contains(type.FullName),"Only exact genuine framework types from four tested bodies");
            return target.ImportReference(type);
        }
        FieldReference Field(FieldReference field)
        {
            Need(field.DeclaringType.FullName=="CPAMAFPANDM" && new[]{"AFJAGKNNCBE","FEKLPCPODAH"}.Contains(field.Name),"Only original two readonly key fields");
            var owner=Type(field.DeclaringType);Need(owner is TypeDefinition,"Exact same-module key owner");
            var original=((TypeDefinition)owner).Fields.Single(f=>f.Name==field.Name);
            Need(original.IsPublic && original.IsInitOnly && !original.IsStatic && CanonicalMetadataSignatures.Type(original.FieldType)==CanonicalMetadataSignatures.Type(Type(field.FieldType)),"Exact original public readonly key field contract");return original;
        }
        MethodReference Method(MethodReference method)
        {
            Need(!(method is GenericInstanceMethod) && method.GenericParameters.Count==0,"No unreviewed MethodSpec in these four selected bodies");
            var declaring=Type(method.DeclaringType);
            if(declaring is TypeDefinition owner)
            {
                Need(owner.FullName=="MNALHHOLFGL" && method.Name==".ctor" && method.HasThis && method.Parameters.Count==2 && method.Parameters[0].ParameterType.FullName=="MNALHHOLFGL" && method.Parameters[1].ParameterType.FullName=="System.String" && method.ReturnType.FullName=="System.Void","Only exact original internal child constructor target");
                var original=owner.Methods.Single(m=>m.Name==".ctor" && m.Parameters.Count==2);
                Need((uint)original.Attributes==6275 && CanonicalMetadataSignatures.Method(original)==CanonicalMetadataSignatures.Method(method),"Original constructor flags/signature unchanged");return original;
            }
            Need((method.DeclaringType.FullName=="System.Type" && (method.Name=="op_Equality" || method.Name=="GetHashCode")) || (method.DeclaringType.FullName=="System.String" && (method.Name=="Equals" || method.Name=="GetHashCode")) || (method.DeclaringType.FullName=="System.Object" && method.Name=="GetHashCode"),"Only exact tested genuine equality/hash declarations");
            var result=target.ImportReference(method,targetMethod);
            Need(CanonicalMetadataSignatures.Type(result.DeclaringType)==CanonicalMetadataSignatures.Type(method.DeclaringType) && CanonicalMetadataSignatures.Method(result)==CanonicalMetadataSignatures.Method(method),"Genuine external framework scoped operand retained");return result;
        }
        public void Copy()
        {
            Need(sourceMethod.HasBody && sourceMethod.Body.ExceptionHandlers.Count==0,"Exact four selected donors have no exception regions");
            var before=targetMethod.Body;
            Need(before!=null && before.ExceptionHandlers.Count==0,"Current selected body has no exception region");
            var ops=before.Instructions.Select(i=>i.OpCode.Code).ToArray();
            Need(before.Variables.Count==0 && ops.SequenceEqual(targetMethod.Name=="MJHONDPGJFA" ? new[]{Code.Ldnull,Code.Ret} : new[]{Code.Ldc_I4_0,Code.Ret}),"Only exact original null/false/zero selected stubs may be replaced");
            var body=new MethodBody(targetMethod){InitLocals=sourceMethod.Body.InitLocals,MaxStackSize=sourceMethod.Body.MaxStackSize};
            foreach(var variable in sourceMethod.Body.Variables)body.Variables.Add(new VariableDefinition(Type(variable.VariableType)));
            var map=new Dictionary<Instruction,Instruction>();
            foreach(var i in sourceMethod.Body.Instructions){var n=Instruction.Create(OpCodes.Nop);n.OpCode=i.OpCode;map.Add(i,n);body.Instructions.Add(n);}
            foreach(var i in sourceMethod.Body.Instructions)
            {
                object o=i.Operand;
                if(o==null)map[i].Operand=null;
                else if(o is Instruction branch){Need(map.ContainsKey(branch),"Branch remains inside exact body");map[i].Operand=map[branch];}
                else if(o is Instruction[])throw new InvalidDataException("No switch in this original member slice");
                else if(o is VariableDefinition local)map[i].Operand=body.Variables[local.Index];
                else if(o is ParameterDefinition parameter)map[i].Operand=targetMethod.Parameters[parameter.Index];
                else if(o is MethodReference method)map[i].Operand=Method(method);
                else if(o is FieldReference field)map[i].Operand=Field(field);
                else if(o is TypeReference type)map[i].Operand=Type(type);
                else {Need(o is string || o is sbyte || o is byte || o is int || o is long || o is float || o is double,"No unclassified operand in exact selected body");map[i].Operand=o;}
            }
            targetMethod.Body=body;
        }
    }
    static int Main(string[] args)
    {
        Need(args.Length==2&&!Directory.Exists(args[1]),"spec fresh-output-directory required");
        using var doc=JsonDocument.Parse(File.ReadAllBytes(args[0]));var spec=doc.RootElement;
        Need(spec.GetProperty("schema").GetString()=="four-tested-container-key-child-body-only-import-input/v1","Exact original-member staging schema");
        var rows=spec.GetProperty("modules").EnumerateArray().ToArray();Need(rows.Length==1,"Only the exact current UJect plugin module");Directory.CreateDirectory(args[1]);var results=new List<object>();int changed=0;
        foreach(var row in rows)
        {
            string original=row.GetProperty("original").GetProperty("path").GetString(),donor=row.GetProperty("donor").GetProperty("path").GetString();
            Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Exact tested source/donor pins");
            using var target=ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true});using var from=ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true});
            Need(target.Assembly.Name.FullName==from.Assembly.Name.FullName,"Exact donor/current assembly identity");
            var requests=row.GetProperty("members").EnumerateArray().ToArray();
            Need(target.Assembly.Name.Name=="UJect.Runtime"&&requests.Length==4,"Only exact selected UJect module/four named member counts");
            var all=Types(target.Types).SelectMany(t=>t.Methods).ToArray();var selected=new List<MethodDefinition>();var donors=new List<MethodDefinition>();
            foreach(var request in requests)
            {
                string owner=request.GetProperty("owner").GetString(),name=request.GetProperty("name").GetString();
                Need((owner=="MNALHHOLFGL"&&name=="MJHONDPGJFA")||(owner=="CPAMAFPANDM"&&new[]{"OFPEIHMPLIL","Equals","GetHashCode"}.Contains(name)),"No unreviewed member selection");
                var a=Types(target.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==name);var b=Types(from.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==name);
                Need(!selected.Contains(a)&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&CanonicalMetadataSignatures.Method(a)==CanonicalMetadataSignatures.Method(b),"Original member signature/flags exactly match tested donor");selected.Add(a);donors.Add(b);
            }
            var unselected=all.Except(selected).ToArray();var untouched=BodyAndSymbolSafety.Capture(unselected);var untouchedIL=untouched.CaptureNormalized(unselected);
            var donorSafety=BodyAndSymbolSafety.Capture(donors.ToArray());var donorIL=donorSafety.CaptureNormalized(donors.ToArray());
            string beforeMetadata=MetadataRoundTripSafety.Fingerprint(target),beforeFeatures=Features(target);var originalTokens=all.Select(m=>m.MetadataToken.ToUInt32()).ToArray();
            for(int n=0;n<selected.Count;n++){new BodyMap(donors[n],selected[n]).Copy();changed++;}
            untouched.VerifyObjectIdentity(unselected);
            Need(MetadataRoundTripSafety.Fingerprint(target)==beforeMetadata&&Features(target)==beforeFeatures,"All original metadata/module features preserved in memory");
            var staged=BodyAndSymbolSafety.Capture(selected.ToArray());Need(staged.CaptureNormalized(selected.ToArray()).SequenceEqual(donorIL),"Imported full IL is semantically identical to exact tested donor including all scoped operands/branches/locals");
            string output=Path.Combine(args[1],target.Name);Need(!File.Exists(output),"Fresh candidate output only");target.Write(output,new WriterParameters{WriteSymbols=false});
            using(var emitted=ModuleDefinition.ReadModule(output,new ReaderParameters{ReadSymbols=false,InMemory=true}))
            {
                var methods=Types(emitted.Types).SelectMany(t=>t.Methods).ToArray();Need(methods.Select(m=>m.MetadataToken.ToUInt32()).SequenceEqual(originalTokens),"Every original MethodDef token/order retained");
                Need(MetadataRoundTripSafety.Fingerprint(emitted)==beforeMetadata&&Features(emitted)==beforeFeatures,"All emitted original metadata/attributes/constants/interfaces/accessors/module features unchanged");
                var keys=new HashSet<string>(selected.Select(MethodKey),StringComparer.Ordinal);var kept=methods.Where(m=>!keys.Contains(MethodKey(m))).ToArray();var replaced=methods.Where(m=>keys.Contains(MethodKey(m))).ToArray();
                untouched.VerifyEmitted(untouchedIL,kept);staged.VerifyEmitted(donorIL,replaced);
                results.Add(new { original=row.GetProperty("original"),donor=row.GetProperty("donor"),candidate=new{path=output,bytes=new FileInfo(output).Length,sha256=Sha(output)},selected_original_members=selected.Select(m=>new{owner=m.DeclaringType.FullName,name=m.Name,current_MethodDef_token=m.MetadataToken.ToUInt32()}).ToArray(),metadata_fingerprint=beforeMetadata,module_features_fingerprint=beforeFeatures,all_other_method_bodies_unchanged=kept.Length,changed_methods=replaced.Length,entire_donor_bodies_and_scoped_operands_equal=true,all_original_MethodDef_tokens_preserved=true });
            }
            Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString(),"Original plugin changed during data staging");
        }
        Need(changed==4,"Exact four changed key/child bodies, no added helper/declarations");
        var report=new{schema="four-tested-original-container-key-child-body-only-staged-candidates/v1",status="four_tested_key_child_bodies_imported_all_original_metadata_other_bodies_preserved",modules=results,changed_method_bodies=4,game_code_loaded_or_executed=false,Main_modified=false,working_boot_or_login_claimed=false};
        File.WriteAllText(Path.Combine(args[1],"report.json"),JsonSerializer.Serialize(report,new JsonSerializerOptions{WriteIndented=true})+"\n",new UTF8Encoding(false));Console.WriteLine("Four tested key/child bodies staged with all original metadata and every other body verified; Main unchanged.");return 0;
    }
}
