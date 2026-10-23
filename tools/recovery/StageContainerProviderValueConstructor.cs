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

static class StageContainerProviderValueConstructor
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
    static object[] NormalizeDonor(ModuleDefinition donor,ModuleDefinition target)
    {
        var names=new[]{"NPILHMLGJCC","JEMKLLFDDFD","PLIPHMBIGMM"};var pairs=names.Select(n=>Tuple.Create(donor.Types.Single(t=>t.FullName==n+"`1"),target.Types.Single(t=>t.FullName==n),n)).ToArray();foreach(var p in pairs)Need(p.Item1.GenericParameters.Count==1&&p.Item2.GenericParameters.Count==1&&(uint)p.Item1.GenericParameters[0].Attributes==0&&(uint)p.Item2.GenericParameters[0].Attributes==0&&p.Item1.GenericParameters[0].Constraints.Count==0&&p.Item2.GenericParameters[0].Constraints.Count==0,"Only three exact original unconstrained ctor-owner arity aliases");
        var methods=Types(donor.Types).SelectMany(t=>t.Methods).ToArray();var safety=BodyAndSymbolSafety.Capture(methods);var il=safety.CaptureNormalized(methods);string metadata=MetadataRoundTripSafety.Fingerprint(donor),features=Features(donor);foreach(var p in pairs)p.Item1.Name=p.Item3;foreach(var p in pairs)p.Item1.Name=p.Item3+"`1";Need(MetadataRoundTripSafety.Fingerprint(donor)==metadata&&Features(donor)==features&&safety.CaptureNormalized(methods).SequenceEqual(il),"Inverse donor-only name edits preserve every other metadata/body feature");safety.VerifyObjectIdentity(methods);foreach(var p in pairs)p.Item1.Name=p.Item3;
        return pairs.Select(p=>(object)new{donor_source_name=p.Item3+"`1",original_runtime_name=p.Item3,donor_only_comparison_view=true}).ToArray();
    }
    static void Copy(MethodDefinition source,MethodDefinition target)
    {
        Need(source.DeclaringType.FullName=="PLIPHMBIGMM"&&target.DeclaringType.FullName=="PLIPHMBIGMM"&&target.MetadataToken.ToUInt32()==0x06000057u&&source.Name==target.Name&&source.Attributes==target.Attributes&&source.ImplAttributes==target.ImplAttributes&&(uint)target.Attributes==6278&&CanonicalMetadataSignatures.Method(source)==CanonicalMetadataSignatures.Method(target),"Only exact public original PLIPH constructor057");
        foreach(var t in new[]{source.DeclaringType,target.DeclaringType})Need(t.GenericParameters.Count==1&&(uint)t.GenericParameters[0].Attributes==0&&t.GenericParameters[0].Constraints.Count==0,"No invented class constraint");Need(source.Body.Variables.Count==0&&target.Body.Variables.Count==0&&source.Body.ExceptionHandlers.Count==0&&target.Body.ExceptionHandlers.Count==0,"Exact simple ctor bodies have no locals or EH");var before=target.Body.Instructions;Need(before.Select(i=>i.OpCode.Code).SequenceEqual(new[]{Code.Ldarg_0,Code.Call,Code.Ret})&&before[1].Operand is MethodReference old&&old.Name==".ctor"&&old.DeclaringType is GenericInstanceType oldbase&&oldbase.ElementType.FullName=="JEMKLLFDDFD"&&oldbase.GenericArguments.Count==1&&oldbase.GenericArguments[0] is GenericParameter oldgp&&oldgp.Type==GenericParameterType.Type&&oldgp.Position==0&&old.Parameters.Count==0,"Only exact original generic-base-forwarding stub is replaced");
        var instructions=source.Body.Instructions;Need(instructions.Select(i=>i.OpCode.Code).SequenceEqual(new[]{Code.Ldarg_0,Code.Call,Code.Ldarg_0,Code.Ldarg_1,Code.Stfld,Code.Ret}),"Only entire tested base-then-same-value-store body");var call=(MethodReference)instructions[1].Operand;var field=(FieldReference)instructions[4].Operand;Need(call.Name==".ctor"&&call.DeclaringType is GenericInstanceType sg&&sg.ElementType.FullName=="JEMKLLFDDFD"&&sg.GenericArguments.Count==1&&sg.GenericArguments[0] is GenericParameter a&&a.Type==GenericParameterType.Type&&a.Position==0&&call.Parameters.Count==0,"Exact same class-generic JEM base call");Need(field.Name=="<LHGCALINHGC>k__BackingField"&&field.DeclaringType is GenericInstanceType sf&&sf.ElementType.FullName=="PLIPHMBIGMM"&&sf.GenericArguments.Count==1&&sf.GenericArguments[0] is GenericParameter b&&b.Type==GenericParameterType.Type&&b.Position==0&&field.FieldType is GenericParameter c&&c.Type==GenericParameterType.Type&&c.Position==0,"Exact readonly generic value field reference");
        var targetBase=target.Module.Types.Single(t=>t.FullName=="JEMKLLFDDFD");var baseCtor=targetBase.Methods.Single(m=>m.MetadataToken.ToUInt32()==0x0600005cu);Need(baseCtor.Name==".ctor"&&(uint)baseCtor.Attributes==6276&&baseCtor.Parameters.Count==0,"Original protected JEM base token retained");var baseOwner=new GenericInstanceType(targetBase);baseOwner.GenericArguments.Add(target.DeclaringType.GenericParameters[0]);var mappedCall=new MethodReference(baseCtor.Name,baseCtor.ReturnType,baseOwner){HasThis=baseCtor.HasThis,ExplicitThis=baseCtor.ExplicitThis,CallingConvention=baseCtor.CallingConvention};Need(CanonicalMetadataSignatures.Type(mappedCall.DeclaringType)==CanonicalMetadataSignatures.Type(call.DeclaringType)&&CanonicalMetadataSignatures.Method(mappedCall)==CanonicalMetadataSignatures.Method(call),"Exact scoped base-call identity after only donor-name aliases");
        var originalField=target.DeclaringType.Fields.Single(f=>f.MetadataToken.ToUInt32()==0x04000027u&&f.Name==field.Name);Need(originalField.IsPrivate&&originalField.IsInitOnly&&!originalField.IsStatic&&originalField.FieldType is GenericParameter gp&&gp.Type==GenericParameterType.Type&&gp.Position==0,"Exact original readonly generic field declaration");var fieldOwner=new GenericInstanceType(target.DeclaringType);fieldOwner.GenericArguments.Add(target.DeclaringType.GenericParameters[0]);var mappedField=new FieldReference(originalField.Name,originalField.FieldType,fieldOwner);Need(CanonicalMetadataSignatures.Type(mappedField.DeclaringType)==CanonicalMetadataSignatures.Type(field.DeclaringType)&&CanonicalMetadataSignatures.Type(mappedField.FieldType)==CanonicalMetadataSignatures.Type(field.FieldType),"Same raw original field/scoped generic context");
        var body=new MethodBody(target){InitLocals=source.Body.InitLocals,MaxStackSize=source.Body.MaxStackSize};foreach(var i in instructions){var n=Instruction.Create(OpCodes.Nop);n.OpCode=i.OpCode;if(i.Operand==null)n.Operand=null;else if(i==instructions[1])n.Operand=mappedCall;else if(i==instructions[4])n.Operand=mappedField;else throw new InvalidDataException("Unexpected operand in exact six-instruction donor");body.Instructions.Add(n);}target.Body=body;
    }
    static int Main(string[] args)
    {
        Need(args.Length==2&&!Directory.Exists(args[1]),"Exact spec/fresh output required");using var doc=JsonDocument.Parse(File.ReadAllBytes(args[0]));var row=doc.RootElement;Need(row.GetProperty("schema").GetString()=="one-tested-provider-value-constructor-on-verified-registration3-input/v1","Exact single-body schema");string original=row.GetProperty("original").GetProperty("path").GetString(),donor=row.GetProperty("donor").GetProperty("path").GetString();Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Exact immutable verified registration3 candidate/tested ctor donor");Directory.CreateDirectory(args[1]);using var target=ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true});using var source=ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true});Need(target.Assembly.FullName==source.Assembly.FullName&&target.Assembly.Name.Name=="UJect.Runtime","Same genuine original owner scope");var aliases=NormalizeDonor(source,target);var chosen=Types(target.Types).SelectMany(t=>t.Methods).Single(m=>m.MetadataToken.ToUInt32()==0x06000057u);var from=source.Types.Single(t=>t.FullName=="PLIPHMBIGMM").Methods.Single(m=>m.IsConstructor&&!m.IsStatic);var all=Types(target.Types).SelectMany(t=>t.Methods).ToArray();var untouched=all.Where(m=>m!=chosen).ToArray();var safe=BodyAndSymbolSafety.Capture(untouched);var kept=safe.CaptureNormalized(untouched);var donorSafe=BodyAndSymbolSafety.Capture(new[]{from});var donorIL=donorSafe.CaptureNormalized(new[]{from});string metadata=MetadataRoundTripSafety.Fingerprint(target),features=Features(target);var tokens=all.Select(m=>m.MetadataToken.ToUInt32()).ToArray();var refs=target.AssemblyReferences.Select(r=>r.FullName).ToArray();Copy(from,chosen);safe.VerifyObjectIdentity(untouched);Need(MetadataRoundTripSafety.Fingerprint(target)==metadata&&Features(target)==features&&target.AssemblyReferences.Select(r=>r.FullName).SequenceEqual(refs),"All original metadata/features/ordered references retained");var staged=BodyAndSymbolSafety.Capture(new[]{chosen});Need(staged.CaptureNormalized(new[]{chosen}).SequenceEqual(donorIL),"Entire tested ctor IL/scoped operands exactly retained through donor-only aliases");string output=Path.Combine(args[1],target.Name);target.Write(output,new WriterParameters{WriteSymbols=false});
        using(var emitted=ModuleDefinition.ReadModule(output,new ReaderParameters{ReadSymbols=false,InMemory=true}))
        {
            var methods=Types(emitted.Types).SelectMany(t=>t.Methods).ToArray();Need(methods.Select(m=>m.MetadataToken.ToUInt32()).SequenceEqual(tokens)&&MetadataRoundTripSafety.Fingerprint(emitted)==metadata&&Features(emitted)==features&&emitted.AssemblyReferences.Select(r=>r.FullName).SequenceEqual(refs),"Every original emitted metadata feature/token/name/reference unchanged");safe.VerifyEmitted(kept,methods.Where(m=>m.MetadataToken.ToUInt32()!=0x06000057u).ToArray());staged.VerifyEmitted(donorIL,new[]{methods.Single(m=>m.MetadataToken.ToUInt32()==0x06000057u)});
        }
        Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Input files unchanged");var report=new{schema="one-tested-provider-value-ctor-added-to-verified-registration3-candidate/v1",status="four_body_isolated_candidate_ready_original_metadata_and_other_bodies_preserved",original=row.GetProperty("original"),donor=row.GetProperty("donor"),candidate=new{path=output,bytes=new FileInfo(output).Length,sha256=Sha(output)},changed_in_this_stage=1,combined_changed_bodies=4,selected_original_MethodDef=0x06000057u,donor_only_exact_name_aliases=aliases,all_other_method_bodies_preserved=untouched.Length,original_metadata_fingerprint=metadata,original_features_fingerprint=features,all_original_runtime_type_names_preserved=true,all_original_MethodDef_tokens_preserved=true,Main_modified=false,game_or_SDK_code_executed=false,working_provider_or_registration_claimed=false};File.WriteAllText(Path.Combine(args[1],"report.json"),JsonSerializer.Serialize(report,new JsonSerializerOptions{WriteIndented=true})+"\n",new UTF8Encoding(false));Console.WriteLine("Only PLIPH value ctor added to verified isolated registration3 candidate; original bases untouched.");return 0;
    }
}
