// Metadata-only candidate staging. Never CLR-load, invoke, or overwrite game code.
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using RR23.MetadataRestoration;

static class StageCustomUrpFactoryCacheBodiesV2
{
    static void Need(bool value,string message){if(!value)throw new InvalidDataException(message);}
    static string Sha(string path){using var f=File.OpenRead(path);return Convert.ToHexString(SHA256.HashData(f)).ToLowerInvariant();}
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var row in rows){yield return row;foreach(var t in Types(row.NestedTypes))yield return t;}}
    static string MethodKey(MethodReference m){return m.DeclaringType.FullName+"|"+CanonicalMetadataSignatures.Method(m);}
    static string Features(ModuleDefinition module)
    {
        var b=new StringBuilder();
        b.Append(module.Name).Append('|').Append(module.Mvid).Append('|').Append(module.Architecture).Append('|').Append(module.Kind).Append('|').Append(module.RuntimeVersion).Append('|').Append(module.Attributes).Append('|').Append(module.Characteristics).Append('|');
        foreach(var row in module.ModuleReferences)b.Append(row.Name).Append('|');
        foreach(var row in module.ExportedTypes)b.Append(row.FullName).Append(':').Append(row.Attributes).Append(':').Append(row.Scope).Append('|');
        foreach(var r in module.Resources){b.Append(r.Name).Append(':').Append(r.Attributes).Append(':').Append(r.ResourceType).Append('|');Need(r is EmbeddedResource,"Nonembedded resource requires separate original-file audit");b.Append(Convert.ToHexString(SHA256.HashData(((EmbeddedResource)r).GetResourceData()))).Append('|');}
        Need(module.Assembly.SecurityDeclarations.Count==0,"Assembly security declarations require separate audit");
        foreach(var type in Types(module.Types))
        {
            Need(type.SecurityDeclarations.Count==0,"Type security declarations require separate audit");
            foreach(var f in type.Fields)Need(!f.HasMarshalInfo,"Field marshal descriptors require separate roundtrip comparer");
            foreach(var m in type.Methods)
            {
                Need(m.SecurityDeclarations.Count==0,"Method security declarations require separate audit");
                b.Append(m.MetadataToken.ToUInt32()).Append(':').Append(m.CallingConvention).Append(':').Append(m.HasThis).Append(':').Append(m.ExplicitThis).Append('|');
                Need(!m.MethodReturnType.HasMarshalInfo&&m.Parameters.All(p=>!p.HasMarshalInfo),"Marshaled member contract requires separate comparer");
                if(m.HasPInvokeInfo)b.Append(m.PInvokeInfo.Module.Name).Append(':').Append(m.PInvokeInfo.EntryPoint).Append(':').Append(m.PInvokeInfo.Attributes).Append('|');
            }
        }
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(b.ToString())));
    }
    sealed class BodyMap
    {
        readonly ModuleDefinition target;readonly MethodDefinition sourceMethod,targetMethod;readonly Dictionary<string,TypeDefinition> targetTypes;
        public BodyMap(MethodDefinition source,MethodDefinition destination){sourceMethod=source;targetMethod=destination;target=destination.Module;targetTypes=Types(target.Types).ToDictionary(t=>t.FullName,StringComparer.Ordinal);}
        TypeReference Type(TypeReference type)
        {
            if(type is ArrayType array){Need(array.IsVector&&array.Rank==1,"Only exact original vector array operands");return new ArrayType(Type(array.ElementType));}
            if(type is ByReferenceType byref)return new ByReferenceType(Type(byref.ElementType));
            Need(!(type is TypeSpecification)&&!(type is GenericParameter),"No generic/pointer/modifier TypeSpec in these seven members");
            string assembly=type.Scope is AssemblyNameReference reference?reference.Name:type.Scope is ModuleDefinition module?module.Assembly.Name.Name:null;
            if(assembly==sourceMethod.Module.Assembly.Name.Name){Need(targetTypes.TryGetValue(type.FullName,out var found),"No donor-only declaration can enter target");return found;}
            Need(type.Scope is AssemblyNameReference external&&target.AssemblyReferences.Count(a=>a.FullName==external.FullName)==1,"HOLD: required external full identity absent/ambiguous; explicit native proof and fresh reviewed amendment required, never append automatically: "+type.FullName+" / "+type.Scope);
            return target.ImportReference(type);
        }
        FieldReference Field(FieldReference field)
        {
            var owner=Type(field.DeclaringType);Need(owner is TypeDefinition,"Only original same-module fields are used");
            var original=((TypeDefinition)owner).Fields.Single(f=>f.Name==field.Name);
            Need(CanonicalMetadataSignatures.Type(original.FieldType)==CanonicalMetadataSignatures.Type(Type(field.FieldType)),"Exact original field type and owner preserved");return original;
        }
        MethodReference Method(MethodReference method)
        {
            Need(!(method is GenericInstanceMethod)&&!method.HasGenericParameters,"No MethodSpec in these exact seven members");
            var owner=Type(method.DeclaringType);
            if(owner is TypeDefinition originalOwner)
            {
                var matches=originalOwner.Methods.Where(m=>m.Name==method.Name&&CanonicalMetadataSignatures.Method(m)==CanonicalMetadataSignatures.Method(method)).ToArray();
                Need(matches.Length==1,"Every original-owned helper/constructor/accessor binds exact existing MethodDef: "+method.FullName);return matches[0];
            }
            var result=new MethodReference(method.Name,Type(method.ReturnType),owner){HasThis=method.HasThis,ExplicitThis=method.ExplicitThis,CallingConvention=method.CallingConvention};
            foreach(var p in method.Parameters)result.Parameters.Add(new ParameterDefinition(Type(p.ParameterType)));
            Need(CanonicalMetadataSignatures.Type(result.DeclaringType)==CanonicalMetadataSignatures.Type(method.DeclaringType)&&CanonicalMetadataSignatures.Method(result)==CanonicalMetadataSignatures.Method(method),"External scoped method/type operands preserved");return result;
        }
        public void Copy()
        {
            Need(sourceMethod.HasBody&&sourceMethod.Body.ExceptionHandlers.Count==0,"Selected tested donor has no EH region");
            var before=targetMethod.Body;Need(before!=null&&before.ExceptionHandlers.Count==0&&before.Variables.Count==0,"Current original exact stub has no local/EH");var ops=before.Instructions.Select(i=>i.OpCode.Code).ToArray();
            if(targetMethod.ReturnType.FullName=="System.Void")Need(ops.SequenceEqual(new[]{Code.Ret}),"Replace only exact current ret stub");
            else Need(ops.SequenceEqual(new[]{Code.Ldnull,Code.Ret}),"Replace only exact current null-return stub");
            var body=new MethodBody(targetMethod){InitLocals=sourceMethod.Body.InitLocals,MaxStackSize=sourceMethod.Body.MaxStackSize};foreach(var v in sourceMethod.Body.Variables)body.Variables.Add(new VariableDefinition(Type(v.VariableType)));
            var map=new Dictionary<Instruction,Instruction>();foreach(var i in sourceMethod.Body.Instructions){var n=Instruction.Create(OpCodes.Nop);n.OpCode=i.OpCode;map.Add(i,n);body.Instructions.Add(n);}
            foreach(var i in sourceMethod.Body.Instructions)
            {
                object o=i.Operand;
                if(o==null)map[i].Operand=null;
                else if(o is Instruction branch){Need(map.ContainsKey(branch),"Branch stays inside exact selected body");map[i].Operand=map[branch];}
                else if(o is Instruction[])throw new InvalidDataException("No switch in this exact native-proven slice");
                else if(o is VariableDefinition local)map[i].Operand=body.Variables[local.Index];
                else if(o is ParameterDefinition parameter)map[i].Operand=targetMethod.Parameters[parameter.Index];
                else if(o is MethodReference method)map[i].Operand=Method(method);
                else if(o is FieldReference field)map[i].Operand=Field(field);
                else if(o is TypeReference type)map[i].Operand=Type(type);
                else{Need(o is string||o is sbyte||o is byte||o is int||o is long||o is float||o is double,"No unclassified operand");map[i].Operand=o;}
            }
            targetMethod.Body=body;
        }
    }
    static int Main(string[] args)
    {
        Need(args.Length==2&&!Directory.Exists(args[1]),"spec and fresh isolated candidate directory required");
        using var doc=JsonDocument.Parse(File.ReadAllBytes(args[0]));var spec=doc.RootElement;Need(spec.GetProperty("schema").GetString()=="seven-tested-custom-URP-body-only-import-input/v2","Exact seven-member staging schema");
        var resolverRows=spec.GetProperty("metadata_references").EnumerateArray().ToArray();
        Need(resolverRows.Length==11&&resolverRows.Select(r=>Path.GetFileName(r.GetProperty("path").GetString())).Distinct(StringComparer.Ordinal).Count()==11,"Exact eleven explicit original SDK/engine/reference identities, no directory search");
        foreach(var metadata in resolverRows)
        {
            string path=metadata.GetProperty("path").GetString();Need(Sha(path)==metadata.GetProperty("sha256").GetString(),"Pinned exact enum/constant metadata bytes");
            using var authority=AssemblyDefinition.ReadAssembly(path,new ReaderParameters{ReadSymbols=false,InMemory=true});Need(authority.Name.FullName==metadata.GetProperty("full_name").GetString(),"Pinned exact enum/constant full identity");
        }
        using var resolver=new ExactMetadataReferenceResolver(resolverRows.Select(r=>r.GetProperty("path").GetString()),resolverRows.Select(r=>new CuratedRuntimeMetadataReference(Path.GetFileNameWithoutExtension(r.GetProperty("path").GetString()),r.GetProperty("sha256").GetString())),OriginalFrameworkMetadataReferenceInputs.Values);
        var rows=spec.GetProperty("modules").EnumerateArray().ToArray();Need(rows.Length==1,"Exactly current original custom URP DLL");Directory.CreateDirectory(args[1]);var results=new List<object>();
        foreach(var row in rows)
        {
            string original=row.GetProperty("original").GetProperty("path").GetString(),donor=row.GetProperty("donor").GetProperty("path").GetString();Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Exact current original/tested donor pins");
            using var target=ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true,AssemblyResolver=resolver});using var from=ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true,AssemblyResolver=resolver});Need(target.Assembly.Name.FullName==from.Assembly.Name.FullName&&target.Assembly.Name.Name=="Unity.RenderPipelines.Universal.Runtime","Exact original custom URP assembly identity");
            var expected=new Dictionary<string,uint>(StringComparer.Ordinal){["UniversalRenderPipelineAsset.CreatePipeline"]=0x0600006a,["UniversalRenderPipelineAsset.DestroyRenderers"]=0x0600006b,["UniversalRenderPipelineAsset.DestroyRenderer"]=0x0600006c,["UniversalRenderPipelineAsset.CreateRenderers"]=0x0600006f,["ForwardRendererData.Create"]=0x06000136,["ScriptableRendererData.InternalCreateRenderer"]=0x06000203,["UniversalRenderPipeline.get_asset"]=0x0600029c};
            var requests=row.GetProperty("members").EnumerateArray().ToArray();Need(requests.Length==7,"Exact seven selected member requests");var all=Types(target.Types).SelectMany(t=>t.Methods).ToArray();var pairs=new List<Tuple<MethodDefinition,MethodDefinition>>();
            foreach(var request in requests)
            {
                string owner=request.GetProperty("owner").GetString(),name=request.GetProperty("name").GetString();int count=request.GetProperty("parameter_count").GetInt32();string shortKey=owner.Substring("UnityEngine.Rendering.Universal.".Length)+"."+name;Need(owner.StartsWith("UnityEngine.Rendering.Universal.",StringComparison.Ordinal)&&expected.ContainsKey(shortKey),"Only exact reviewed seven original owners/methods");
                var a=Types(target.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==name&&m.Parameters.Count==count);var b=Types(from.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==name&&m.Parameters.Count==count);
                Need(a.MetadataToken.ToUInt32()==expected[shortKey]&&request.GetProperty("current_token").GetUInt32()==expected[shortKey]&&!pairs.Any(p=>p.Item1==a)&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&CanonicalMetadataSignatures.Method(a)==CanonicalMetadataSignatures.Method(b),"Exact current original token/signature/flags and tested donor");pairs.Add(Tuple.Create(a,b));
            }
            pairs=pairs.OrderBy(p=>Array.IndexOf(all,p.Item1)).ToList();var selected=pairs.Select(p=>p.Item1).ToArray();var donors=pairs.Select(p=>p.Item2).ToArray();var unselected=all.Except(selected).ToArray();
            var untouched=BodyAndSymbolSafety.Capture(unselected);var untouchedIL=untouched.CaptureNormalized(unselected);var donorSafety=BodyAndSymbolSafety.Capture(donors);var donorIL=donorSafety.CaptureNormalized(donors);
            string metadata=MetadataRoundTripSafety.Fingerprint(target),features=Features(target);var tokens=all.Select(m=>m.MetadataToken.ToUInt32()).ToArray();var references=target.AssemblyReferences.Select(a=>a.FullName).ToArray();
            for(int i=0;i<selected.Length;i++)new BodyMap(donors[i],selected[i]).Copy();untouched.VerifyObjectIdentity(unselected);
            Need(MetadataRoundTripSafety.Fingerprint(target)==metadata&&Features(target)==features&&target.AssemblyReferences.Select(a=>a.FullName).SequenceEqual(references),"Every original metadata/module feature/reference full identity and order preserved; no implicit additions");
            var staged=BodyAndSymbolSafety.Capture(selected);Need(staged.CaptureNormalized(selected).SequenceEqual(donorIL),"Entire tested donor IL equals mapped selected bodies including every scope/field/call/branch/local");
            string output=Path.Combine(args[1],target.Name);Need(!File.Exists(output),"Fresh isolated output only");target.Write(output,new WriterParameters{WriteSymbols=false});
            using(var emitted=ModuleDefinition.ReadModule(output,new ReaderParameters{ReadSymbols=false,InMemory=true,AssemblyResolver=resolver}))
            {
                var methods=Types(emitted.Types).SelectMany(t=>t.Methods).ToArray();Need(methods.Select(m=>m.MetadataToken.ToUInt32()).SequenceEqual(tokens),"Every original MethodDef token/order retained");Need(MetadataRoundTripSafety.Fingerprint(emitted)==metadata&&Features(emitted)==features&&emitted.AssemblyReferences.Select(a=>a.FullName).SequenceEqual(references),"Emitted original metadata/features/references exact");
                var keys=new HashSet<string>(selected.Select(MethodKey),StringComparer.Ordinal);var kept=methods.Where(m=>!keys.Contains(MethodKey(m))).ToArray();var changed=methods.Where(m=>keys.Contains(MethodKey(m))).ToArray();untouched.VerifyEmitted(untouchedIL,kept);staged.VerifyEmitted(donorIL,changed);Need(changed.Length==7,"Exact seven emitted changed members");
                results.Add(new{original=row.GetProperty("original"),donor=row.GetProperty("donor"),candidate=new{path=output,bytes=new FileInfo(output).Length,sha256=Sha(output)},selected_original_members=selected.Select(m=>new{owner=m.DeclaringType.FullName,name=m.Name,current_MethodDef_token=m.MetadataToken.ToUInt32()}).ToArray(),metadata_fingerprint=metadata,module_features_fingerprint=features,assembly_references=references,assembly_references_appended=new string[0],all_other_method_bodies_unchanged=kept.Length,changed_methods=7,entire_donor_bodies_and_scoped_operands_equal=true,all_original_MethodDef_tokens_preserved=true});
            }
            Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString(),"Original DLL unchanged during staging");
        }
        var report=new{schema="seven-tested-original-custom-URP-body-only-staged-candidates/v2",status="seven_tested_URP_bodies_imported_all_original_metadata_other_bodies_preserved",modules=results,exact_pinned_metadata_resolver_used=true,metadata_references=resolverRows,changed_method_bodies=7,game_code_loaded_or_executed=false,Main_modified=false,working_renderer_or_constructor_disposal_frame_closure_claimed=false};File.WriteAllText(Path.Combine(args[1],"report.json"),JsonSerializer.Serialize(report,new JsonSerializerOptions{WriteIndented=true})+"\n",new UTF8Encoding(false));Console.WriteLine("Seven tested original URP members staged; all original metadata/references/other bodies verified; Main unchanged.");return 0;
    }
}
