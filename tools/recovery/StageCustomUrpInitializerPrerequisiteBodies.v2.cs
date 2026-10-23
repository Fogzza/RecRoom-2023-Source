// Inert metadata/body staging only. No inspected production assembly is loaded.
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

static class StageCustomUrpInitializerPrerequisiteBodies
{
    static void Need(bool value,string message){if(!value)throw new InvalidDataException(message);}
    static string Sha(string path){using var f=File.OpenRead(path);return Convert.ToHexString(SHA256.HashData(f)).ToLowerInvariant();}
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
    static string MethodKey(MethodReference m){return m.DeclaringType.FullName+"|"+CanonicalMetadataSignatures.Method(m);}
    static string Features(ModuleDefinition module,Dictionary<string,uint> tokens=null)
    {
        var b=new StringBuilder();b.Append(module.Name).Append('|').Append(module.Mvid).Append('|').Append(module.Architecture).Append('|').Append(module.Kind).Append('|').Append(module.RuntimeVersion).Append('|').Append(module.Attributes).Append('|').Append(module.Characteristics).Append('|');
        foreach(var r in module.ModuleReferences)b.Append(r.Name).Append('|');
        foreach(var r in module.ExportedTypes)b.Append(r.FullName).Append(':').Append(r.Attributes).Append(':').Append(r.Scope).Append('|');
        foreach(var r in module.Resources){Need(r is EmbeddedResource,"Only separately hashed embedded resources");b.Append(r.Name).Append(':').Append(r.Attributes).Append(':').Append(r.ResourceType).Append(':').Append(Convert.ToHexString(SHA256.HashData(((EmbeddedResource)r).GetResourceData()))).Append('|');}
        Need(module.Assembly.SecurityDeclarations.Count==0,"Assembly security declarations require separate audit");
        foreach(var t in Types(module.Types))
        {
            Need(t.SecurityDeclarations.Count==0&&t.Fields.All(f=>!f.HasMarshalInfo),"No unaudited type security or field marshal contract");
            foreach(var m in t.Methods)
            {
                Need(m.SecurityDeclarations.Count==0&&!m.MethodReturnType.HasMarshalInfo&&m.Parameters.All(p=>!p.HasMarshalInfo),"No unaudited method security/marshal contract");
                b.Append(tokens==null?m.MetadataToken.ToUInt32():tokens[MethodKey(m)]).Append(':').Append(m.CallingConvention).Append(':').Append(m.HasThis).Append(':').Append(m.ExplicitThis).Append('|');
                if(m.HasPInvokeInfo)b.Append(m.PInvokeInfo.Module.Name).Append(':').Append(m.PInvokeInfo.EntryPoint).Append(':').Append(m.PInvokeInfo.Attributes).Append('|');
            }
        }
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(b.ToString())));
    }
    sealed class BodyMap
    {
        readonly MethodDefinition source,destination;readonly ModuleDefinition target;readonly Dictionary<string,TypeDefinition> types;
        public int OriginalDictionaryConstructorMappings,OriginalDictionaryFieldMappings;
        public BodyMap(MethodDefinition from,MethodDefinition to){source=from;destination=to;target=to.Module;types=Types(target.Types).ToDictionary(t=>t.FullName,StringComparer.Ordinal);}
        TypeReference Type(TypeReference value)
        {
            if(value is GenericParameter p)
            {
                Need(p.Type==GenericParameterType.Type&&p.Position==0&&p.Owner is TypeReference own&&own.FullName=="Unity.Collections.NativeArray`1","Only exact NativeArray type VAR0 in these twelve bodies");
                var mapped=Type((TypeReference)p.Owner);Need(mapped.GenericParameters.Count==1,"One mapped NativeArray type parameter");return mapped.GenericParameters[0];
            }
            if(value is GenericInstanceType g){var n=new GenericInstanceType(Type(g.ElementType));foreach(var argument in g.GenericArguments)n.GenericArguments.Add(Type(argument));return n;}
            if(value is ArrayType a){Need(a.IsVector&&a.Rank==1,"Only exact vector arrays");return new ArrayType(Type(a.ElementType));}
            if(value is ByReferenceType r)return new ByReferenceType(Type(r.ElementType));
            Need(!(value is TypeSpecification),"No unproved pointer/modifier/function TypeSpec");
            string assembly=value.Scope is AssemblyNameReference external?external.Name:value.Scope is ModuleDefinition module?module.Assembly.Name.Name:null;
            if(assembly==source.Module.Assembly.Name.Name){Need(types.TryGetValue(value.FullName,out var definition),"No donor-only owner/declaration may enter target");return definition;}
            Need(value.Scope is AssemblyNameReference scope&&target.AssemblyReferences.Count(r=>r.FullName==scope.FullName)==1,"HOLD missing exact external identity; never append/retarget: "+value.FullName+" / "+value.Scope);
            return target.ImportReference(value);
        }
        bool CaptureInitializer=>destination.DeclaringType.FullName=="UnityEngine.Rendering.CameraCaptureBridge"&&destination.Name==".cctor";
        FieldDefinition OriginalDictionary(FieldReference donor)
        {
            Need(CaptureInitializer&&donor.DeclaringType.FullName=="UnityEngine.Rendering.CameraCaptureBridge"&&donor.Name=="actionDict","Only original CameraCapture actionDict context");
            var original=types["UnityEngine.Rendering.CameraCaptureBridge"].Fields.Single(f=>f.Name=="actionDict");
            Need(CanonicalMetadataSignatures.Type(original.FieldType)==CanonicalMetadataSignatures.Type(donor.FieldType),"Exact original dictionary shape/arguments before scoped authority mapping");
            var a=(GenericInstanceType)((GenericInstanceType)original.FieldType).GenericArguments[1];var b=(GenericInstanceType)((GenericInstanceType)donor.FieldType).GenericArguments[1];
            Need(a.ElementType.FullName=="System.Collections.Generic.HashSet`1"&&b.ElementType.FullName==a.ElementType.FullName&&((AssemblyNameReference)a.ElementType.Scope).FullName=="System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e"&&((AssemblyNameReference)b.ElementType.Scope).FullName=="System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089","Exact native original7cec versus genuine donor b77a finite mapping");
            return original;
        }
        FieldReference Field(FieldReference value)
        {
            if(CaptureInitializer&&value.Name=="actionDict"){OriginalDictionaryFieldMappings++;return OriginalDictionary(value);}
            var owner=Type(value.DeclaringType);Need(owner is TypeDefinition,"Only exact original same-module fields");var original=((TypeDefinition)owner).Fields.Single(f=>f.Name==value.Name);
            Need(CanonicalMetadataSignatures.Type(original.FieldType)==CanonicalMetadataSignatures.Type(Type(value.FieldType)),"Exact original field identity/type");return original;
        }
        MethodReference Method(MethodReference value)
        {
            Need(!(value is GenericInstanceMethod)&&!value.HasGenericParameters,"No MethodSpec/generic method in these twelve bodies");
            if(CaptureInitializer&&value.Name==".ctor"&&value.DeclaringType is GenericInstanceType g&&g.ElementType.FullName=="System.Collections.Generic.Dictionary`2")
            {
                Need(value.Parameters.Count==0&&value.HasThis&&!value.ExplicitThis&&value.ReturnType.FullName=="System.Void","Only original action dictionary zero-argument constructor");
                var donorField=source.DeclaringType.Fields.Single(f=>f.Name=="actionDict");Need(CanonicalMetadataSignatures.Type(donorField.FieldType)==CanonicalMetadataSignatures.Type(value.DeclaringType),"Actual typed constructor belongs to actionDict");var original=OriginalDictionary(donorField);OriginalDictionaryConstructorMappings++;
                return new MethodReference(value.Name,target.TypeSystem.Void,original.FieldType){HasThis=value.HasThis,ExplicitThis=value.ExplicitThis,CallingConvention=value.CallingConvention};
            }
            var owner=Type(value.DeclaringType);
            if(owner is TypeDefinition definition){var matches=definition.Methods.Where(m=>m.Name==value.Name&&CanonicalMetadataSignatures.Method(m)==CanonicalMetadataSignatures.Method(value)).ToArray();Need(matches.Length==1,"Exact original MethodDef callee");return matches[0];}
            var result=new MethodReference(value.Name,Type(value.ReturnType),owner){HasThis=value.HasThis,ExplicitThis=value.ExplicitThis,CallingConvention=value.CallingConvention};foreach(var p in value.Parameters)result.Parameters.Add(new ParameterDefinition(Type(p.ParameterType)));
            Need(CanonicalMetadataSignatures.Type(result.DeclaringType)==CanonicalMetadataSignatures.Type(value.DeclaringType)&&CanonicalMetadataSignatures.Method(result)==CanonicalMetadataSignatures.Method(value),"Every other external scoped type/method operand retained");return result;
        }
        public void Copy()
        {
            Need(source.HasBody&&source.Body.ExceptionHandlers.Count==0&&destination.HasBody&&destination.Body.Variables.Count==0&&destination.Body.ExceptionHandlers.Count==0,"Exact body-only source and current stub");
            var before=destination.Body.Instructions.Select(i=>i.OpCode.Code).ToArray();
            if(destination.ReturnType.FullName=="System.Void")Need(before.SequenceEqual(new[]{Code.Ret}),"Exact ret stub");
            else if(destination.ReturnType.FullName=="System.Single")Need(before.SequenceEqual(new[]{Code.Ldc_R4,Code.Ret})&&(float)destination.Body.Instructions[0].Operand==0f,"Exact original float-zero stub");
            else if(destination.ReturnType.FullName=="UnityEngine.Rendering.Universal.RecRoomQualityConfig")Need(before.SequenceEqual(new[]{Code.Ldnull,Code.Ret}),"Exact original null stub");
            else Need(before.SequenceEqual(new[]{Code.Ldc_I4_0,Code.Ret}),"Exact original bool/int/enum-zero stub");
            var body=new MethodBody(destination){InitLocals=source.Body.InitLocals,MaxStackSize=source.Body.MaxStackSize};foreach(var v in source.Body.Variables)body.Variables.Add(new VariableDefinition(Type(v.VariableType)));
            var map=new Dictionary<Instruction,Instruction>();foreach(var i in source.Body.Instructions){var n=Instruction.Create(OpCodes.Nop);n.OpCode=i.OpCode;map.Add(i,n);body.Instructions.Add(n);}
            foreach(var i in source.Body.Instructions)
            {
                var value=i.Operand;if(value==null)map[i].Operand=null;
                else if(value is Instruction b){Need(map.ContainsKey(b),"Branch remains within selected body");map[i].Operand=map[b];}
                else if(value is Instruction[])throw new InvalidDataException("No switch in exact twelve bodies");
                else if(value is VariableDefinition v)map[i].Operand=body.Variables[v.Index];
                else if(value is ParameterDefinition p)map[i].Operand=destination.Parameters[p.Index];
                else if(value is FieldReference f)map[i].Operand=Field(f);
                else if(value is MethodReference m)map[i].Operand=Method(m);
                else if(value is TypeReference t)map[i].Operand=Type(t);
                else{Need(value is string||value is sbyte||value is byte||value is int||value is long||value is float||value is double,"No unclassified operand");map[i].Operand=value;}
            }
            destination.Body=body;
            Need(OriginalDictionaryConstructorMappings==(CaptureInitializer?1:0)&&OriginalDictionaryFieldMappings==(CaptureInitializer?1:0),"Only one proven Dictionary ctor and original actionDict field mapping");
        }
    }
    static int Main(string[] args)
    {
        Need(args.Length==2&&!Directory.Exists(args[1]),"Pinned specification and fresh isolated candidate directory");using var doc=JsonDocument.Parse(File.ReadAllBytes(args[0]));var spec=doc.RootElement;
        Need(spec.GetProperty("schema").GetString()=="twelve-tested-custom-URP-initializer-body-import/v1","Finite twelve-body schema");
        var authorities=spec.GetProperty("metadata_references").EnumerateArray().ToArray();Need(authorities.Length>0&&authorities.Select(r=>r.GetProperty("full_name").GetString()).Distinct().Count()==authorities.Length,"Unique explicit full metadata authorities");
        foreach(var row in authorities){string path=row.GetProperty("path").GetString();Need(Sha(path)==row.GetProperty("sha256").GetString(),"Pinned metadata bytes");using var a=AssemblyDefinition.ReadAssembly(path,new ReaderParameters{ReadSymbols=false,InMemory=true});Need(a.Name.FullName==row.GetProperty("full_name").GetString(),"Exact metadata full identity");}
        using var resolver=new ExactMetadataReferenceResolver(authorities.Select(r=>r.GetProperty("path").GetString()),authorities.Select(r=>new CuratedRuntimeMetadataReference(Path.GetFileNameWithoutExtension(r.GetProperty("path").GetString()),r.GetProperty("sha256").GetString())),OriginalFrameworkMetadataReferenceInputs.Values);
        var modules=spec.GetProperty("modules").EnumerateArray().ToArray();Need(modules.Length==2,"Exactly Core and testedURP7 input");Directory.CreateDirectory(args[1]);var results=new List<object>();int total=0;
        foreach(var row in modules)
        {
            string original=row.GetProperty("original").GetProperty("path").GetString(),donor=row.GetProperty("donor").GetProperty("path").GetString();Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Actual current and tested donor pins");
            using var target=ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true,AssemblyResolver=resolver});using var from=ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true,AssemblyResolver=resolver});
            Need(target.Assembly.Name.FullName==from.Assembly.Name.FullName&&target.Assembly.Name.Name==row.GetProperty("assembly").GetString(),"Exact original module identity");var all=Types(target.Types).SelectMany(t=>t.Methods).ToArray();var pairs=new List<Tuple<MethodDefinition,MethodDefinition>>();
            foreach(var request in row.GetProperty("members").EnumerateArray())
            {
                string owner=request.GetProperty("owner").GetString(),name=request.GetProperty("name").GetString(),donorOwner=request.GetProperty("donor_owner").GetString(),donorName=request.GetProperty("donor_name").GetString();
                var a=Types(target.Types).Single(t=>t.FullName==owner).Methods.Single(m=>m.Name==name);var b=Types(from.Types).Single(t=>t.FullName==donorOwner).Methods.Single(m=>m.Name==donorName);
                Need(a.MetadataToken.ToUInt32()==request.GetProperty("current_token").GetUInt32()&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&a.HasThis==b.HasThis&&a.ExplicitThis==b.ExplicitThis&&a.CallingConvention==b.CallingConvention,"Exact pinned original member and donor flags");
                Need(CanonicalMetadataSignatures.Type(a.ReturnType)==CanonicalMetadataSignatures.Type(b.ReturnType)&&a.Parameters.Select(p=>CanonicalMetadataSignatures.Type(p.ParameterType)).SequenceEqual(b.Parameters.Select(p=>CanonicalMetadataSignatures.Type(p.ParameterType))),"Exact original signature independent of explicit callback alias names");Need(!pairs.Any(p=>p.Item1==a),"No duplicate selected member");pairs.Add(Tuple.Create(a,b));
            }
            Need(pairs.Count==(target.Assembly.Name.Name=="Unity.RenderPipelines.Core.Runtime"?3:9),"Exact three Core/nine URP selected bodies");pairs=pairs.OrderBy(p=>Array.IndexOf(all,p.Item1)).ToList();var selected=pairs.Select(p=>p.Item1).ToArray();var donors=pairs.Select(p=>p.Item2).ToArray();var others=all.Except(selected).ToArray();
            var untouched=BodyAndSymbolSafety.Capture(others);var oldIL=untouched.CaptureNormalized(others);var donorSafety=BodyAndSymbolSafety.Capture(donors);var donorIL=donorSafety.CaptureNormalized(donors);var definitions=PinnedPrerequisiteDefinitionMap.Capture(target);var tokens=all.ToDictionary(MethodKey,m=>m.MetadataToken.ToUInt32(),StringComparer.Ordinal);string metadata=MetadataRoundTripSafety.Fingerprint(target),features=Features(target);var references=target.AssemblyReferences.Select(a=>a.FullName).ToArray();
            for(int i=0;i<selected.Length;i++)new BodyMap(donors[i],selected[i]).Copy();untouched.VerifyObjectIdentity(others);Need(MetadataRoundTripSafety.Fingerprint(target)==metadata&&Features(target)==features&&target.AssemblyReferences.Select(a=>a.FullName).SequenceEqual(references),"All metadata/features/full scoped references unchanged in memory");
            var staged=BodyAndSymbolSafety.Capture(selected);Need(staged.CaptureNormalized(selected).SequenceEqual(donorIL),"Entire tested donor instructions/locals/branches retained; exact scoped audit follows independently");string output=Path.Combine(args[1],target.Name);target.Write(output,new WriterParameters{WriteSymbols=false});
            using(var emitted=ModuleDefinition.ReadModule(output,new ReaderParameters{ReadSymbols=false,InMemory=true,AssemblyResolver=resolver}))
            {
                PinnedPrerequisiteDefinitionMap.Verify(definitions,emitted,row.GetProperty("definition_map"));Need(MetadataRoundTripSafety.Fingerprint(emitted)==metadata&&Features(emitted,tokens)==features&&emitted.AssemblyReferences.Select(a=>a.FullName).SequenceEqual(references),"Exact emitted semantic metadata/features/reference identities and order");var methods=Types(emitted.Types).SelectMany(t=>t.Methods).ToArray();var keys=new HashSet<string>(selected.Select(MethodKey));var kept=methods.Where(m=>!keys.Contains(MethodKey(m))).ToArray();var changed=methods.Where(m=>keys.Contains(MethodKey(m))).ToArray();untouched.VerifyEmitted(oldIL,kept);staged.VerifyEmitted(donorIL,changed);Need(changed.Length==selected.Length,"Exact selected emitted count");total+=changed.Length;
                results.Add(new{original=row.GetProperty("original"),donor=row.GetProperty("donor"),candidate=new{path=output,bytes=new FileInfo(output).Length,sha256=Sha(output)},changed_methods=changed.Length,all_other_method_bodies_unchanged=kept.Length,exact_definition_map_verified=true,omitted_Param_records=0,assembly_references_appended=new string[0],original_scope_and_callback_identity_preserved=true,entire_tested_donor_IL_equal=true,metadata_fingerprint=metadata,module_features_fingerprint=features});
            }
            Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString(),"Input DLL unchanged");
        }
        Need(total==12,"Exactly twelve staged bodies");File.WriteAllText(Path.Combine(args[1],"report.json"),JsonSerializer.Serialize(new{schema="twelve-tested-custom-URP-initializer-staged-candidates/v1",status="twelve_tested_bodies_staged_semantic_metadata_other_bodies_preserved",modules=results,changed_method_bodies=12,Main_modified=false,production_code_loaded_or_executed=false,constructor_or_frame_closure_claimed=false},new JsonSerializerOptions{WriteIndented=true})+"\n",new UTF8Encoding(false));return 0;
    }
}
