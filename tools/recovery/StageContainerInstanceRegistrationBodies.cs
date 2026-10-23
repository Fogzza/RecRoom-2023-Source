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

static class StageContainerInstanceRegistrationBodies
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
    static readonly Dictionary<string,uint> AliasTargets=new Dictionary<string,uint>(StringComparer.Ordinal)
    {{"IKGLJOBBAAC",0x02000026u},{"NPILHMLGJCC",0x02000025u},{"PLIPHMBIGMM",0x02000013u},{"MOANAJANOIL",0x02000012u}};
    static object[] NormalizeDisposableDonor(ModuleDefinition donor,ModuleDefinition target)
    {
        var pairs=AliasTargets.Select(x=>Tuple.Create(donor.Types.Single(t=>t.FullName==x.Key+"`1"),target.Types.Single(t=>t.FullName==x.Key&&t.MetadataToken.ToUInt32()==x.Value),x.Key)).ToArray();
        foreach(var p in pairs)Need(p.Item1.GenericParameters.Count==1&&p.Item2.GenericParameters.Count==1&&p.Item1.GenericParameters[0].Attributes==p.Item2.GenericParameters[0].Attributes&&p.Item1.GenericParameters[0].Constraints.Count==0&&p.Item2.GenericParameters[0].Constraints.Count==0,"Four exact raw generic names and original unconstrained arities only");
        // These are disposable donor definitions, not runtime definitions.
        // Invert the four literal name edits and recheck the entire donor's
        // semantic metadata/body snapshots before using the projected view.
        string metadata=MetadataRoundTripSafety.Fingerprint(donor),features=Features(donor);var all=Types(donor.Types).SelectMany(t=>t.Methods).ToArray();var safe=BodyAndSymbolSafety.Capture(all);var il=safe.CaptureNormalized(all);
        foreach(var p in pairs)p.Item1.Name=p.Item3;
        foreach(var p in pairs)p.Item1.Name=p.Item3+"`1";
        Need(MetadataRoundTripSafety.Fingerprint(donor)==metadata&&Features(donor)==features&&safe.CaptureNormalized(all).SequenceEqual(il),"Inverse donor-only alias normalization preserves every other metadata/body feature");safe.VerifyObjectIdentity(all);
        foreach(var p in pairs)p.Item1.Name=p.Item3;
        Need(!donor.GetTypeReferences().Any(t=>t.Scope is AssemblyNameReference a&&a.Name==donor.Assembly.Name.Name&&AliasTargets.Keys.Any(n=>t.FullName==n+"`1")),"No separate donor self-TypeRef is silently normalized");
        return pairs.Select(p=>(object)new{donor_source_name=p.Item3+"`1",projected_original_name=p.Item3,original_TypeDef_token=p.Item2.MetadataToken.ToUInt32(),arity=1,normalization_only_in_disposable_donor_view=true}).ToArray();
    }
    static void SameGeneric(IGenericParameterProvider a,IGenericParameterProvider b)
    {
        Need(a.GenericParameters.Count==b.GenericParameters.Count,"Same original generic arity");
        for(int i=0;i<a.GenericParameters.Count;i++)Need(a.GenericParameters[i].Attributes==b.GenericParameters[i].Attributes&&a.GenericParameters[i].Constraints.Select(x=>CanonicalMetadataSignatures.Type(x.ConstraintType)).SequenceEqual(b.GenericParameters[i].Constraints.Select(x=>CanonicalMetadataSignatures.Type(x.ConstraintType))),"Exact original generic flags/dependent constraints");
    }
    sealed class BodyMap
    {
        readonly ModuleDefinition target;readonly MethodDefinition sourceMethod,targetMethod;readonly Dictionary<string,TypeDefinition> targetTypes;
        public BodyMap(MethodDefinition source,MethodDefinition destination){sourceMethod=source;targetMethod=destination;target=destination.Module;targetTypes=Types(target.Types).ToDictionary(t=>t.FullName,StringComparer.Ordinal);}
        TypeReference Type(TypeReference type)
        {
            if(type is GenericParameter g)
            {
                if(g.Type==GenericParameterType.Method)
                {
                    Need(g.Owner is MethodReference m&&m.Name==sourceMethod.Name&&g.Position<targetMethod.GenericParameters.Count,"Only the exact selected method's own GP argument");return targetMethod.GenericParameters[g.Position];
                }
                Need(g.Owner is TypeReference owner&&AliasTargets.ContainsKey(owner.GetElementType().FullName)&&g.Position==0,"Only exact four original class-generic0 contexts");var def=targetTypes[((TypeReference)g.Owner).GetElementType().FullName];Need(def.GenericParameters.Count==1,"One exact original class-generic parameter");return def.GenericParameters[0];
            }
            if(type is GenericInstanceType instance){var mapped=new GenericInstanceType(Type(instance.ElementType));foreach(var a in instance.GenericArguments)mapped.GenericArguments.Add(Type(a));return mapped;}
            Need(!(type is TypeSpecification),"No array/byref/modifier/pointer in these exact three donor bodies");
            var assembly=type.Scope is AssemblyNameReference reference?reference.Name:type.Scope is ModuleDefinition module?module.Assembly.Name.Name:null;
            if(assembly==sourceMethod.Module.Assembly.Name.Name){Need(targetTypes.TryGetValue(type.FullName,out var found),"Never import a donor-only declaration");return found;}
            Need(assembly=="mscorlib"&&type.Scope is AssemblyNameReference scope&&scope.FullName=="mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"&&new[]{"System.Type","System.RuntimeTypeHandle","System.String","System.Boolean","System.Void"}.Contains(type.FullName),"Only exact tested genuine framework Type/handle/primitive references");return target.ImportReference(type);
        }
        FieldReference Field(FieldReference field)
        {
            var owner=Type(field.DeclaringType);var open=owner.GetElementType() as TypeDefinition;Need(open!=null,"Same-module original field owner");var original=open.Fields.Single(f=>f.Name==field.Name);
            Need((open.FullName=="MNALHHOLFGL"&&field.Name=="KBDIBPJIHNN"&&original.MetadataToken.ToUInt32()==0x0400000bu&&original.FieldType.FullName=="System.Boolean"&&!original.IsStatic)||(open.FullName=="IKGLJOBBAAC"&&field.Name=="JPEDOBINBHH"&&original.MetadataToken.ToUInt32()==0x0400003cu&&original.IsPrivate&&original.IsInitOnly&&!original.IsStatic),"Only exact original disposed field or readonly provider field");
            var ft=Type(field.FieldType);Need(CanonicalMetadataSignatures.Type(original.FieldType)==CanonicalMetadataSignatures.Type(ft),"Original field type/class GP exactly retained");return owner is GenericInstanceType?new FieldReference(original.Name,ft,owner):original;
        }
        MethodReference Method(MethodReference method)
        {
            if(method is GenericInstanceMethod instance)
            {
                Need(method.Name=="JONINBOMMEP"&&instance.GenericArguments.Count==2,"Only exact selected generic registration MethodSpec");var result=new GenericInstanceMethod(Method(instance.ElementMethod));foreach(var a in instance.GenericArguments)result.GenericArguments.Add(Type(a));return result;
            }
            var declaring=Type(method.DeclaringType);var open=declaring.GetElementType() as TypeDefinition;
            if(open!=null)
            {
                var matches=open.Methods.Where(m=>m.Name==method.Name&&CanonicalMetadataSignatures.Method(m)==CanonicalMetadataSignatures.Method(method)).ToArray();Need(matches.Length==1,"Exact existing original MethodDef scope/signature: "+method.FullName);var found=matches[0];uint token=found.MetadataToken.ToUInt32();
                Need((open.FullName=="MKECFLEMHEL"&&method.Name=="GFKAFPHLKMJ"&&token==0x0600005fu)||(open.FullName=="MNALHHOLFGL"&&method.Name=="JONINBOMMEP"&&(token==0x06000017u||token==0x06000018u))||(open.FullName=="CPAMAFPANDM"&&method.Name==".ctor"&&token==0x0600004du)||(open.FullName=="IKGLJOBBAAC"&&method.Name==".ctor"&&token==0x06000084u)||(open.FullName=="NPILHMLGJCC"&&method.Name==".ctor"&&token==0x06000083u)||(open.FullName=="PLIPHMBIGMM"&&method.Name==".ctor"&&token==0x06000057u),"Only native-bound exact original callee tokens");
                if(!(declaring is GenericInstanceType))return found;
                Need(method.Name==".ctor"&&!method.HasGenericParameters&&AliasTargets.ContainsKey(open.FullName),"Only exact class-generic constructor MemberRefs");var reference=new MethodReference(found.Name,found.ReturnType,declaring){HasThis=found.HasThis,ExplicitThis=found.ExplicitThis,CallingConvention=found.CallingConvention};foreach(var p in found.Parameters)reference.Parameters.Add(new ParameterDefinition(p.ParameterType));
                Need(CanonicalMetadataSignatures.Method(reference)==CanonicalMetadataSignatures.Method(method)&&CanonicalMetadataSignatures.Type(reference.DeclaringType)==CanonicalMetadataSignatures.Type(declaring),"Exact scoped class-generic ctor signature preserved");return reference;
            }
            Need(method.DeclaringType.FullName=="System.Type"&&!method.HasGenericParameters&&((method.Name=="GetTypeFromHandle"&&!method.HasThis&&method.ReturnType.FullName=="System.Type"&&method.Parameters.Count==1&&method.Parameters[0].ParameterType.FullName=="System.RuntimeTypeHandle")||(method.Name=="get_IsInterface"&&method.HasThis&&method.ReturnType.FullName=="System.Boolean"&&method.Parameters.Count==0)),"Only exact framework TypeHandle conversion and final Type.IsInterface");var external=target.ImportReference(method,targetMethod);Need(CanonicalMetadataSignatures.Type(external.DeclaringType)==CanonicalMetadataSignatures.Type(method.DeclaringType)&&CanonicalMetadataSignatures.Method(external)==CanonicalMetadataSignatures.Method(method),"Full genuine external framework method signature retained");return external;
        }
        public void Copy()
        {
            Need(sourceMethod.HasBody&&sourceMethod.Body.ExceptionHandlers.Count==0&&targetMethod.HasBody&&targetMethod.Body.ExceptionHandlers.Count==0&&targetMethod.Body.Variables.Count==0,"Exact donor/current stub body/EH/locals scope");var old=targetMethod.Body.Instructions;var ops=old.Select(i=>i.OpCode.Code).ToArray();
            if(targetMethod.MetadataToken.ToUInt32()==0x06000013u)Need(ops.SequenceEqual(new[]{Code.Ldnull,Code.Ret}),"Only exact current null-return instance-bind stub");
            else if(targetMethod.MetadataToken.ToUInt32()==0x06000017u)Need(ops.SequenceEqual(new[]{Code.Ret}),"Only exact current empty generic-key-registration stub");
            else
            {
                Need(targetMethod.MetadataToken.ToUInt32()==0x06000084u&&ops.SequenceEqual(new[]{Code.Ldarg_0,Code.Call,Code.Ret})&&old[1].Operand is MethodReference ctor&&ctor.Name==".ctor"&&ctor.DeclaringType is GenericInstanceType baseType&&baseType.ElementType.FullName=="NPILHMLGJCC"&&baseType.GenericArguments.Count==1&&baseType.GenericArguments[0] is GenericParameter gp&&gp.Type==GenericParameterType.Type&&gp.Position==0&&ctor.Parameters.Count==0,"Only exact existing original generic-base-forwarding provider ctor stub");
            }
            var body=new MethodBody(targetMethod){InitLocals=sourceMethod.Body.InitLocals,MaxStackSize=sourceMethod.Body.MaxStackSize};foreach(var v in sourceMethod.Body.Variables)body.Variables.Add(new VariableDefinition(Type(v.VariableType)));var map=new Dictionary<Instruction,Instruction>();
            foreach(var i in sourceMethod.Body.Instructions){var n=Instruction.Create(OpCodes.Nop);n.OpCode=i.OpCode;map.Add(i,n);body.Instructions.Add(n);}
            foreach(var i in sourceMethod.Body.Instructions)
            {
                object o=i.Operand;if(o==null)map[i].Operand=null;else if(o is Instruction branch){Need(map.ContainsKey(branch),"Every branch stays inside exact selected body");map[i].Operand=map[branch];}else if(o is Instruction[])throw new InvalidDataException("No switch in exact selected bodies");else if(o is VariableDefinition local)map[i].Operand=body.Variables[local.Index];else if(o is ParameterDefinition param)map[i].Operand=targetMethod.Parameters[param.Index];else if(o is MethodReference m)map[i].Operand=Method(m);else if(o is FieldReference f)map[i].Operand=Field(f);else if(o is TypeReference t)map[i].Operand=Type(t);else{Need(o is string||o is sbyte||o is byte||o is int||o is long||o is float||o is double,"No unknown operand");map[i].Operand=o;}
            }
            targetMethod.Body=body;
        }
    }
    static int Main(string[] args)
    {
        Need(args.Length==2&&!Directory.Exists(args[1]),"Exact spec and fresh output directory required");using var doc=JsonDocument.Parse(File.ReadAllBytes(args[0]));var spec=doc.RootElement;Need(spec.GetProperty("schema").GetString()=="three-tested-container-instance-registration-body-only-input/v1","Exact staging schema");var rows=spec.GetProperty("modules").EnumerateArray().ToArray();Need(rows.Length==1,"Only current UJect module");Directory.CreateDirectory(args[1]);var results=new List<object>();int changed=0;
        foreach(var row in rows)
        {
            string original=row.GetProperty("original").GetProperty("path").GetString(),donor=row.GetProperty("donor").GetProperty("path").GetString();Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Exact actual tested donor and current SDK pins");
            using var target=ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true});using var from=ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true});Need(target.Assembly.FullName==from.Assembly.FullName&&target.Assembly.Name.Name=="UJect.Runtime","Same exact assembly owner identity");var aliases=NormalizeDisposableDonor(from,target);var requests=row.GetProperty("members").EnumerateArray().ToArray();Need(requests.Length==3,"Only three exact native-bound members");var all=Types(target.Types).SelectMany(t=>t.Methods).ToArray();var selected=new List<MethodDefinition>();var donors=new List<MethodDefinition>();
            foreach(var request in requests)
            {
                uint token=request.GetProperty("token").GetUInt32();Need(new uint[]{0x06000013u,0x06000017u,0x06000084u}.Contains(token),"Only three literal original tokens");var a=all.Single(m=>m.MetadataToken.ToUInt32()==token);string owner=token==0x06000084u?"IKGLJOBBAAC":"MNALHHOLFGL";string name=token==0x06000013u?"PHJOGIEDKPN":token==0x06000017u?"JONINBOMMEP":".ctor";Need(a.DeclaringType.FullName==owner&&a.Name==name,"Exact original owner/name/token");var b=Types(from.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==name&&m.GenericParameters.Count==a.GenericParameters.Count);
                Need(!selected.Contains(a)&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&CanonicalMetadataSignatures.Method(a)==CanonicalMetadataSignatures.Method(b)&&a.Parameters.Select(p=>p.Attributes).SequenceEqual(b.Parameters.Select(p=>p.Attributes)),"Original method signature/flags/parameter flags match exact tested donor");SameGeneric(a,b);SameGeneric(a.DeclaringType,b.DeclaringType);Need((uint)a.Attributes==(token==0x06000013u?134u:token==0x06000017u?131u:6278u),"Exact public/internal/public-constructor access");selected.Add(a);donors.Add(b);
            }
            Need(selected.Select(m=>m.MetadataToken.ToUInt32()).OrderBy(x=>x).SequenceEqual(new uint[]{0x06000013u,0x06000017u,0x06000084u}),"Exact unique three-member token set");var ordered=selected.Zip(donors,(a,b)=>Tuple.Create(a,b)).OrderBy(x=>Array.IndexOf(all,x.Item1)).ToArray();selected=ordered.Select(x=>x.Item1).ToList();donors=ordered.Select(x=>x.Item2).ToList();
            var unselected=all.Except(selected).ToArray();var keptSafety=BodyAndSymbolSafety.Capture(unselected);var keptIL=keptSafety.CaptureNormalized(unselected);var donorSafety=BodyAndSymbolSafety.Capture(donors.ToArray());var donorIL=donorSafety.CaptureNormalized(donors.ToArray());string metadata=MetadataRoundTripSafety.Fingerprint(target),features=Features(target);var refs=target.AssemblyReferences.Select(r=>r.FullName).ToArray();var tokens=all.Select(m=>m.MetadataToken.ToUInt32()).ToArray();
            for(int i=0;i<selected.Count;i++){new BodyMap(donors[i],selected[i]).Copy();changed++;}keptSafety.VerifyObjectIdentity(unselected);Need(MetadataRoundTripSafety.Fingerprint(target)==metadata&&Features(target)==features&&target.AssemblyReferences.Select(r=>r.FullName).SequenceEqual(refs),"Every original metadata feature and ordered reference retained in memory");var stagedSafety=BodyAndSymbolSafety.Capture(selected.ToArray());Need(stagedSafety.CaptureNormalized(selected.ToArray()).SequenceEqual(donorIL),"Every transplanted instruction/local/branch/scoped operand equals exact tested donor through only four name aliases");
            string output=Path.Combine(args[1],target.Name);Need(!File.Exists(output),"Fresh candidates only");target.Write(output,new WriterParameters{WriteSymbols=false});using(var emitted=ModuleDefinition.ReadModule(output,new ReaderParameters{ReadSymbols=false,InMemory=true}))
            {
                var methods=Types(emitted.Types).SelectMany(t=>t.Methods).ToArray();Need(methods.Select(m=>m.MetadataToken.ToUInt32()).SequenceEqual(tokens)&&MetadataRoundTripSafety.Fingerprint(emitted)==metadata&&Features(emitted)==features&&emitted.AssemblyReferences.Select(r=>r.FullName).SequenceEqual(refs),"All emitted original MethodDef tokens/metadata/features/ordered references unchanged");var keys=new HashSet<string>(selected.Select(MethodKey),StringComparer.Ordinal);var kept=methods.Where(m=>!keys.Contains(MethodKey(m))).ToArray();var replaced=methods.Where(m=>keys.Contains(MethodKey(m))).ToArray();keptSafety.VerifyEmitted(keptIL,kept);stagedSafety.VerifyEmitted(donorIL,replaced);
                results.Add(new{original=row.GetProperty("original"),donor=row.GetProperty("donor"),candidate=new{path=output,bytes=new FileInfo(output).Length,sha256=Sha(output)},selected_original_members=selected.Select(m=>new{owner=m.DeclaringType.FullName,name=m.Name,current_MethodDef_token=m.MetadataToken.ToUInt32()}).ToArray(),donor_only_exact_name_aliases=aliases,metadata_fingerprint=metadata,module_features_fingerprint=features,ordered_original_assembly_references=refs,all_other_method_bodies_unchanged=kept.Length,changed_methods=replaced.Length,entire_donor_bodies_and_scoped_operands_equal=true,all_original_MethodDef_tokens_preserved=true,all_original_runtime_type_names_preserved=true});
            }
            Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Original SDK and tested donor files remain byte-identical after staging");
        }
        Need(changed==3,"Exactly three existing bodies replaced; no helpers/declarations appended");var report=new{schema="three-tested-original-instance-registration-body-only-candidates/v1",status="three_tested_instance_registration_bodies_staged_all_original_metadata_other_bodies_preserved",modules=results,changed_method_bodies=3,game_code_loaded_or_executed=false,Main_modified=false,original_runtime_metadata_names_changed=false,instance_provider_or_working_boot_functionality_claimed=false};File.WriteAllText(Path.Combine(args[1],"report.json"),JsonSerializer.Serialize(report,new JsonSerializerOptions{WriteIndented=true})+"\n",new UTF8Encoding(false));Console.WriteLine("Three exact tested registration bodies staged; all runtime metadata and other bodies retained. No SDK execution.");return 0;
    }
}
