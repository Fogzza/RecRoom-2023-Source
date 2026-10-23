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

static class StageContainerLowerBodiesv3
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
            if(type.FullName=="System.Collections.Generic.HashSet`1")
            {
                Need(sourceMethod.Module.Assembly.Name.Name=="UJect.Runtime"&&type.Scope is AssemblyNameReference donorScope&&donorScope.FullName=="System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089","Only the demonstrated donor HashSet framework scope difference");
                var field=targetTypes["OENEDGPIOFN"].Fields.Single(f=>f.Name=="DJGFOAKOCAP");
                Need(field.FieldType is GenericInstanceType collection&&collection.ElementType.FullName==type.FullName&&collection.GenericArguments.Count==1&&collection.GenericArguments[0].FullName=="OENEDGPIOFN/NPDGPDKAHLN","Exact original native-proved auxiliary HashSet field type");
                var original=((GenericInstanceType)field.FieldType).ElementType;
                Need(original.Scope is AssemblyNameReference originalScope&&originalScope.FullName=="System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e","Preserve the precise existing original System.Core identity");
                return original;
            }
            return target.ImportReference(type);
        }
        FieldReference Field(FieldReference field)
        {
            var owner=Type(field.DeclaringType);
            if(!(owner is TypeDefinition))
            {
                Need(field.DeclaringType.FullName=="HJDBOADFHMC"&&field.Name=="LMOLABKFOAB"&&field.FieldType.FullName=="HJDBOADFHMC","Only exact original external logging-color field");
                return new FieldReference(field.Name,Type(field.FieldType),owner);
            }
            var original=((TypeDefinition)owner).Fields.Single(f=>f.Name==field.Name);Need(CanonicalMetadataSignatures.Type(original.FieldType)==CanonicalMetadataSignatures.Type(Type(field.FieldType)),"Original selected field signature preserved");return original;
        }
        MethodReference Method(MethodReference method)
        {
            if(method is GenericInstanceMethod instance){var result=new GenericInstanceMethod(Method(instance.ElementMethod));foreach(var argument in instance.GenericArguments)result.GenericArguments.Add(Type(argument));return result;}
            var declaring=Type(method.DeclaringType);
            if(declaring is TypeDefinition originalOwner)
            {
                var found=originalOwner.Methods.Where(m=>m.Name==method.Name && CanonicalMetadataSignatures.Method(m)==CanonicalMetadataSignatures.Method(method)).ToArray();
                Need(found.Length==1,"Every same-module constructor/helper binds its exact existing original MethodDef: "+method.FullName);return found[0];
            }
            Need(!method.HasGenericParameters,"No unreviewed external generic-method template in this member slice");
            var resultMethod=new MethodReference(method.Name,Type(method.ReturnType),declaring){HasThis=method.HasThis,ExplicitThis=method.ExplicitThis,CallingConvention=method.CallingConvention};
            foreach(var parameter in method.Parameters)resultMethod.Parameters.Add(new ParameterDefinition(Type(parameter.ParameterType)));
            Need(CanonicalMetadataSignatures.Type(resultMethod.DeclaringType)==CanonicalMetadataSignatures.Type(method.DeclaringType)&&CanonicalMetadataSignatures.Method(resultMethod)==CanonicalMetadataSignatures.Method(method),"Exact external method/type-generic and scoped identity preserved");return resultMethod;
        }
        public void Copy()
        {
            Need(sourceMethod.HasBody && sourceMethod.Body.ExceptionHandlers.Count==0,"Exact two selected donors have no exception regions");
            var before=targetMethod.Body;
            Need(before!=null && before.ExceptionHandlers.Count==0,"Current selected stub has no EH region");var ops=before.Instructions.Select(i=>i.OpCode.Code).ToArray();
            if(targetMethod.Name==".ctor" && targetMethod.DeclaringType.FullName!="CPAMAFPANDM")
            {Need(ops.SequenceEqual(new[]{Code.Ldarg_0,Code.Call,Code.Ret})&&before.Variables.Count==0&&before.Instructions[1].Operand is MethodReference baseCtor&&baseCtor.Name==".ctor"&&baseCtor.DeclaringType.FullName=="System.Object","Only exact current base-Object forwarding constructor stub");}
            else if(targetMethod.Name==".ctor")
            {Need(ops.SequenceEqual(new[]{Code.Ldarg_0,Code.Ldnull,Code.Stfld,Code.Ldarg_0,Code.Ldnull,Code.Stfld,Code.Ret})&&before.Variables.Count==0&&((FieldReference)before.Instructions[2].Operand).Name=="AFJAGKNNCBE"&&((FieldReference)before.Instructions[5].Operand).Name=="FEKLPCPODAH","Only exact original key constructor null-field stub");}
            else if(targetMethod.Name=="HHCPOGCCGNF")
            {Need(ops.SequenceEqual(new[]{Code.Ldloca_S,Code.Initobj,Code.Ldloc_0,Code.Ret})&&before.Variables.Count==1&&before.Variables[0].VariableType is GenericParameter local&&local.Type==GenericParameterType.Method&&local.Position==0&&before.Instructions[1].Operand is GenericParameter init&&init.Type==GenericParameterType.Method&&init.Position==0,"Only exact default method-generic T stub");}
            else Need((targetMethod.Name=="PNFLFFOAING"||targetMethod.Name=="OBAIKOPBHAP")&&ops.SequenceEqual(new[]{Code.Ldnull,Code.Ret})&&before.Variables.Count==0,"Only exact original null getter/factory stubs");
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
        Need(spec.GetProperty("schema").GetString()=="eight-tested-container-lower-body-only-import-input/v1","Exact original-member staging schema");
        var rows=spec.GetProperty("modules").EnumerateArray().ToArray();Need(rows.Length==2,"Only exact UJect and AgInitialization current modules");Directory.CreateDirectory(args[1]);var results=new List<object>();int changed=0;
        foreach(var row in rows)
        {
            string original=row.GetProperty("original").GetProperty("path").GetString(),donor=row.GetProperty("donor").GetProperty("path").GetString();
            Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Exact tested source/donor pins");
            using var target=ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true});using var from=ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true});
            Need(target.Assembly.Name.FullName==from.Assembly.Name.FullName,"Exact donor/current assembly identity");
            var requests=row.GetProperty("members").EnumerateArray().ToArray();
            Need(target.Assembly.Name.Name=="UJect.Runtime"&&requests.Length==6 || target.Assembly.Name.Name=="RecRoom.AgInitialization.Runtime"&&requests.Length==2,"Only exact selected Singleton module/two getter counts");
            var all=Types(target.Types).SelectMany(t=>t.Methods).ToArray();var selected=new List<MethodDefinition>();var donors=new List<MethodDefinition>();
            foreach(var request in requests)
            {
                string owner=request.GetProperty("owner").GetString(),name=request.GetProperty("name").GetString();
                Need(owner=="MNALHHOLFGL"&&(name==".ctor"||name=="HHCPOGCCGNF") || (owner=="CPAMAFPANDM"||owner=="OENEDGPIOFN")&&name==".ctor" || owner=="MPAAIECKLGA"&&(name=="PNFLFFOAING"||name=="OBAIKOPBHAP"),"No unreviewed member selection");
                var parameters=request.GetProperty("parameters").EnumerateArray().Select(v=>v.GetString()).ToArray();int arity=request.GetProperty("generic_arity").GetInt32();
                var a=Types(target.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==name&&m.GenericParameters.Count==arity&&m.Parameters.Select(p=>p.ParameterType.FullName).SequenceEqual(parameters));
                string donorName=name=="PNFLFFOAING"?"get_CFHDLGEGDFD":name;var b=Types(from.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==donorName&&m.GenericParameters.Count==arity&&m.Parameters.Select(p=>p.ParameterType.FullName).SequenceEqual(parameters));
                Need(!selected.Contains(a)&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&a.CallingConvention==b.CallingConvention&&a.HasThis==b.HasThis&&a.ExplicitThis==b.ExplicitThis&&CanonicalMetadataSignatures.Type(a.ReturnType)==CanonicalMetadataSignatures.Type(b.ReturnType)&&a.Parameters.Select(p=>CanonicalMetadataSignatures.Type(p.ParameterType)).SequenceEqual(b.Parameters.Select(p=>CanonicalMetadataSignatures.Type(p.ParameterType)))&&a.GenericParameters.Select(g=>g.Attributes).SequenceEqual(b.GenericParameters.Select(g=>g.Attributes)),"Original exact selected signature/flags/constraints match tested donor; only explicit property getter alias differs");selected.Add(a);donors.Add(b);
            }
            // The manifest groups related bodies for readability. Normalize
            // donor/target pairing to original metadata traversal order before
            // comparing emitted bodies; never rely on request-list order.
            var ordered=selected.Zip(donors,(destination,source)=>Tuple.Create(destination,source)).OrderBy(item=>Array.IndexOf(all,item.Item1)).ToArray();selected=ordered.Select(item=>item.Item1).ToList();donors=ordered.Select(item=>item.Item2).ToList();
            var unselected=all.Except(selected).ToArray();var untouched=BodyAndSymbolSafety.Capture(unselected);var untouchedIL=untouched.CaptureNormalized(unselected);
            var donorSafety=BodyAndSymbolSafety.Capture(donors.ToArray());var donorIL=donorSafety.CaptureNormalized(donors.ToArray());
            string originalMetadata=MetadataRoundTripSafety.Fingerprint(target),beforeFeatures=Features(target);var originalReferences=target.AssemblyReferences.Select(r=>r.FullName).ToArray();string addedReference=null;
            if(target.Assembly.Name.Name=="RecRoom.AgInitialization.Runtime")
            {
                const string required="RecRoom.Debugging.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
                Need(!originalReferences.Any(r=>r.StartsWith("RecRoom.Debugging.Runtime,",StringComparison.Ordinal)),"No duplicate/replacement Debugging reference permitted");
                var sdk=row.GetProperty("native_required_reference_sdk");Need(Sha(sdk.GetProperty("path").GetString())==sdk.GetProperty("sha256").GetString(),"Exact native-owned retained logger SDK");
                using var referenceSource=ModuleDefinition.ReadModule(sdk.GetProperty("path").GetString(),new ReaderParameters{ReadSymbols=false,InMemory=true});Need(referenceSource.Assembly.Name.FullName==required,"Exact proven native-required SDK identity");
                var append=new AssemblyNameReference(referenceSource.Assembly.Name.Name,referenceSource.Assembly.Name.Version){Culture=referenceSource.Assembly.Name.Culture,PublicKeyToken=referenceSource.Assembly.Name.PublicKeyToken};Need(append.FullName==required,"No identity/flags substitution in sole added reference");target.AssemblyReferences.Add(append);addedReference=required;
            }
            else Need(!row.TryGetProperty("native_required_reference_sdk",out var ignored),"Only the proven initialization caller may add this one reference");
            string beforeMetadata=MetadataRoundTripSafety.Fingerprint(target);var expectedReferences=addedReference==null?originalReferences:originalReferences.Concat(new[]{addedReference}).ToArray();Need(target.AssemblyReferences.Select(r=>r.FullName).SequenceEqual(expectedReferences)&&Features(target)==beforeFeatures,"Only the one proven append; original ordered references and all features retained");var originalTokens=all.Select(m=>m.MetadataToken.ToUInt32()).ToArray();
            for(int n=0;n<selected.Count;n++){new BodyMap(donors[n],selected[n]).Copy();changed++;}
            untouched.VerifyObjectIdentity(unselected);
            Need(target.AssemblyReferences.Select(r=>r.FullName).SequenceEqual(expectedReferences)&&MetadataRoundTripSafety.Fingerprint(target)==beforeMetadata&&Features(target)==beforeFeatures,"All original metadata/module features preserved in memory");
            var staged=BodyAndSymbolSafety.Capture(selected.ToArray());Need(staged.CaptureNormalized(selected.ToArray()).SequenceEqual(donorIL),"Imported full IL is semantically identical to exact tested donor including all scoped operands/branches/locals");
            string output=Path.Combine(args[1],target.Name);Need(!File.Exists(output),"Fresh candidate output only");target.Write(output,new WriterParameters{WriteSymbols=false});
            using(var emitted=ModuleDefinition.ReadModule(output,new ReaderParameters{ReadSymbols=false,InMemory=true}))
            {
                var methods=Types(emitted.Types).SelectMany(t=>t.Methods).ToArray();Need(methods.Select(m=>m.MetadataToken.ToUInt32()).SequenceEqual(originalTokens),"Every original MethodDef token/order retained");
                Need(emitted.AssemblyReferences.Select(r=>r.FullName).SequenceEqual(expectedReferences)&&MetadataRoundTripSafety.Fingerprint(emitted)==beforeMetadata&&Features(emitted)==beforeFeatures,"All emitted original metadata/attributes/constants/interfaces/accessors/module features unchanged");
                var keys=new HashSet<string>(selected.Select(MethodKey),StringComparer.Ordinal);var kept=methods.Where(m=>!keys.Contains(MethodKey(m))).ToArray();var replaced=methods.Where(m=>keys.Contains(MethodKey(m))).ToArray();
                untouched.VerifyEmitted(untouchedIL,kept);staged.VerifyEmitted(donorIL,replaced);
                results.Add(new { original=row.GetProperty("original"),donor=row.GetProperty("donor"),candidate=new{path=output,bytes=new FileInfo(output).Length,sha256=Sha(output)},selected_original_members=selected.Select(m=>new{owner=m.DeclaringType.FullName,name=m.Name,current_MethodDef_token=m.MetadataToken.ToUInt32()}).ToArray(),unmodified_original_metadata_fingerprint=originalMetadata,metadata_fingerprint_after_sole_proven_append=beforeMetadata,original_ordered_assembly_references=originalReferences,sole_native_required_reference_append=addedReference,module_features_fingerprint=beforeFeatures,all_other_method_bodies_unchanged=kept.Length,changed_methods=replaced.Length,entire_donor_bodies_and_scoped_operands_equal=true,all_original_MethodDef_tokens_preserved=true });
            }
            Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString(),"Original plugin changed during data staging");
        }
        Need(changed==8,"Exact eight changed lower-container bodies, no added helper/declarations");
        var report=new{schema="eight-tested-original-container-lower-body-only-staged-candidates/v1",status="eight_tested_lower_bodies_imported_original_metadata_preserved_with_one_native_required_reference",modules=results,changed_method_bodies=8,game_code_loaded_or_executed=false,Main_modified=false,working_boot_or_login_claimed=false};
        File.WriteAllText(Path.Combine(args[1],"report.json"),JsonSerializer.Serialize(report,new JsonSerializerOptions{WriteIndented=true})+"\n",new UTF8Encoding(false));Console.WriteLine("Eight tested lower-container bodies staged with all original metadata and every other body verified; Main unchanged.");return 0;
    }
}
