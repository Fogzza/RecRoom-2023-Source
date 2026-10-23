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

static class StageContainerLookupDiscoveryBodies
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
            if(type is GenericParameter generic)
            {
                if(generic.Type==GenericParameterType.Method)
                {Need(generic.Owner is MethodReference owner && owner.Name==sourceMethod.Name && generic.Position<targetMethod.GenericParameters.Count,"Only selected method's exact original generic argument");return targetMethod.GenericParameters[generic.Position];}
                Need(generic.Owner is TypeReference typeOwner && typeOwner.Scope is AssemblyNameReference,"Only foreign framework type generic parameters are otherwise supported");
                var imported=target.ImportReference((TypeReference)generic.Owner);while(imported.GenericParameters.Count<=generic.Position)imported.GenericParameters.Add(new GenericParameter("T"+imported.GenericParameters.Count,imported));return imported.GenericParameters[generic.Position];
            }
            if(type is GenericInstanceType instance){var result=new GenericInstanceType(Type(instance.ElementType));foreach(var argument in instance.GenericArguments)result.GenericArguments.Add(Type(argument));return result;}
            if(type is ByReferenceType byref)return new ByReferenceType(Type(byref.ElementType));
            if(type is RequiredModifierType required)return new RequiredModifierType(Type(required.ModifierType),Type(required.ElementType));
            if(type is OptionalModifierType optional)return new OptionalModifierType(Type(optional.ModifierType),Type(optional.ElementType));
            Need(!(type is TypeSpecification),"No unreviewed pointer/array TypeSpec in this exact slice");
            var assembly=type.Scope is AssemblyNameReference reference?reference.Name:type.Scope is ModuleDefinition module?module.Assembly.Name.Name:null;
            if(assembly==sourceMethod.Module.Assembly.Name.Name){Need(targetTypes.TryGetValue(type.FullName,out var found),"No donor-only declaration may enter target");return found;}
            Need(assembly=="mscorlib" && new[]{"System.Collections.Generic.Dictionary`2","System.Boolean","System.Object","System.String","System.Void","System.InvalidOperationException"}.Contains(type.FullName),"Only exact tested genuine framework types in these two callers");
            return target.ImportReference(type);
        }
        FieldReference Field(FieldReference field)
        {
            var owner=Type(field.DeclaringType);
            Need(owner is TypeDefinition && owner.FullName=="MNALHHOLFGL" && new[]{"KBDIBPJIHNN","AAHKPPMHGFI","DDFCHDGPJBN"}.Contains(field.Name),"Only exact original disposed/map/parent field declarations");
            var original=((TypeDefinition)owner).Fields.Single(f=>f.Name==field.Name);Need(CanonicalMetadataSignatures.Type(original.FieldType)==CanonicalMetadataSignatures.Type(Type(field.FieldType)),"Original selected field signature preserved");return original;
        }
        MethodReference Method(MethodReference method)
        {
            if(method is GenericInstanceMethod instance){var result=new GenericInstanceMethod(Method(instance.ElementMethod));foreach(var argument in instance.GenericArguments)result.GenericArguments.Add(Type(argument));return result;}
            var declaring=Type(method.DeclaringType);
            if(declaring is TypeDefinition originalOwner)
            {
                var found=originalOwner.Methods.Where(m=>m.Name==method.Name && CanonicalMetadataSignatures.Method(m)==CanonicalMetadataSignatures.Method(method)).ToArray();
                Need(found.Length==1,"Every same-module helper binds its exact existing original MethodDef: "+method.FullName);
                Need((originalOwner.FullName=="MNALHHOLFGL" && new[]{"LNFNAIMOFOF","CPBMOKFMMMK"}.Contains(method.Name)) || (originalOwner.FullName=="MKECFLEMHEL" && method.Name=="GFKAFPHLKMJ") || (originalOwner.FullName=="NJAICAFMPBE" && method.Name=="AIKLEKDPIFH"),"Only tested exact original helper/interface MethodDefs");
                if(originalOwner.FullName=="NJAICAFMPBE")Need(found[0].MetadataToken.ToUInt32()==0x06000053 && (uint)found[0].Attributes==3526 && found[0].IsGetter && found[0].ReturnType.FullName=="System.Object" && found[0].Parameters.Count==0,"Resolve thin ordinary-name context to exact existing original SpecialName property getter; no declaration copied");
                return found[0];
            }
            Need(!method.HasGenericParameters,"No unreviewed external generic-method template in this member slice");
            Need((method.DeclaringType is GenericInstanceType dictionary && dictionary.ElementType.FullName=="System.Collections.Generic.Dictionary`2" && method.Name=="TryGetValue") || (method.DeclaringType.FullName=="System.String" && method.Name=="Format") || (method.DeclaringType.FullName=="System.InvalidOperationException" && method.Name==".ctor"),"Only exact tested external Dictionary query, formatter and exception constructor");
            var resultMethod=new MethodReference(method.Name,Type(method.ReturnType),declaring){HasThis=method.HasThis,ExplicitThis=method.ExplicitThis,CallingConvention=method.CallingConvention};
            foreach(var parameter in method.Parameters)resultMethod.Parameters.Add(new ParameterDefinition(Type(parameter.ParameterType)));
            Need(CanonicalMetadataSignatures.Type(resultMethod.DeclaringType)==CanonicalMetadataSignatures.Type(method.DeclaringType)&&CanonicalMetadataSignatures.Method(resultMethod)==CanonicalMetadataSignatures.Method(method),"Exact external method/type-generic and scoped identity preserved");return resultMethod;
        }
        public void Copy()
        {
            Need(sourceMethod.HasBody && sourceMethod.Body.ExceptionHandlers.Count==0,"Exact two selected donors have no exception regions");
            var before=targetMethod.Body;
            Need(before!=null && before.ExceptionHandlers.Count==0,"Current selected stub has no EH region");var ops=before.Instructions.Select(i=>i.OpCode.Code).ToArray();
            Need(before.Variables.Count==0,"Exact current selected default stubs have no locals");
            if(targetMethod.Name=="NGBMOPMLJCM")
            {Need(ops.SequenceEqual(new[]{Code.Ldarg_2,Code.Initobj,Code.Ldc_I4_0,Code.Ret})&&before.Instructions[1].Operand is GenericParameter init&&init.Type==GenericParameterType.Method&&init.Position==0,"Only exact generic-out-default/false current lookup stub");}
            else Need(targetMethod.Name=="CPBMOKFMMMK"&&ops.SequenceEqual(new[]{Code.Ldarg_2,Code.Ldnull,Code.Stind_Ref,Code.Ldc_I4_0,Code.Ret}),"Only exact null-out/false current discovery stub");
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
        Need(spec.GetProperty("schema").GetString()=="two-tested-container-lookup-discovery-body-only-import-input/v1","Exact original-member staging schema");
        var rows=spec.GetProperty("modules").EnumerateArray().ToArray();Need(rows.Length==1,"Only the exact current UJect plugin module");Directory.CreateDirectory(args[1]);var results=new List<object>();int changed=0;
        foreach(var row in rows)
        {
            string original=row.GetProperty("original").GetProperty("path").GetString(),donor=row.GetProperty("donor").GetProperty("path").GetString();
            Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Exact tested source/donor pins");
            using var target=ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true});using var from=ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true});
            Need(target.Assembly.Name.FullName==from.Assembly.Name.FullName,"Exact donor/current assembly identity");
            var requests=row.GetProperty("members").EnumerateArray().ToArray();
            Need(target.Assembly.Name.Name=="UJect.Runtime"&&requests.Length==2,"Only exact selected UJect module/two named member counts");
            var all=Types(target.Types).SelectMany(t=>t.Methods).ToArray();var selected=new List<MethodDefinition>();var donors=new List<MethodDefinition>();
            foreach(var request in requests)
            {
                string owner=request.GetProperty("owner").GetString(),name=request.GetProperty("name").GetString();
                Need(owner=="MNALHHOLFGL" && new[]{"NGBMOPMLJCM","CPBMOKFMMMK"}.Contains(name),"No unreviewed member selection");
                var a=Types(target.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==name);var b=Types(from.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==name);
                Need(!selected.Contains(a)&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&CanonicalMetadataSignatures.Method(a)==CanonicalMetadataSignatures.Method(b)&&a.GenericParameters.Count==1&&a.GenericParameters.Select(g=>g.Attributes).SequenceEqual(b.GenericParameters.Select(g=>g.Attributes))&&a.GenericParameters.All(g=>g.Constraints.Count==0)&&b.GenericParameters.All(g=>g.Constraints.Count==0),"Original member signature/flags/generic constraints exactly match tested donor");
                Need(a.MetadataToken.ToUInt32()==(name=="NGBMOPMLJCM"?0x0600001eu:0x0600001fu)&&(uint)a.Attributes==(name=="NGBMOPMLJCM"?131u:129u)&&(uint)a.GenericParameters[0].Attributes==(name=="NGBMOPMLJCM"?4u:0u),"Exact original internal reference-constrained lookup versus private unconstrained discovery");selected.Add(a);donors.Add(b);
            }
            var ordered=selected.Zip(donors,(destination,source)=>Tuple.Create(destination,source)).OrderBy(item=>Array.IndexOf(all,item.Item1)).ToArray();selected=ordered.Select(item=>item.Item1).ToList();donors=ordered.Select(item=>item.Item2).ToList();
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
        Need(changed==2,"Exact two changed lookup/discovery bodies, no added helper/declarations");
        var report=new{schema="two-tested-original-container-lookup-discovery-body-only-staged-candidates/v1",status="two_tested_lookup_discovery_bodies_imported_all_original_metadata_other_bodies_preserved",modules=results,changed_method_bodies=2,game_code_loaded_or_executed=false,Main_modified=false,working_boot_or_login_claimed=false};
        File.WriteAllText(Path.Combine(args[1],"report.json"),JsonSerializer.Serialize(report,new JsonSerializerOptions{WriteIndented=true})+"\n",new UTF8Encoding(false));Console.WriteLine("Two tested lookup/discovery bodies staged with all original metadata and every other body verified; Main unchanged.");return 0;
    }
}
