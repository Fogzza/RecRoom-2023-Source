// Metadata-only isolated staging; inspected SDK and donor code never execute.
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

static class StageContainerPreparationBodies
{
    static void Need(bool v,string m){if(!v)throw new InvalidDataException(m);}
    static string Sha(string p){using var f=File.OpenRead(p);return Convert.ToHexString(SHA256.HashData(f)).ToLowerInvariant();}
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
    static string Key(MethodReference m){return m.DeclaringType.FullName+"|"+CanonicalMetadataSignatures.Method(m);}
    static readonly uint[] Tokens={0x0600002fu,0x06000033u,0x06000035u,0x0600003du,0x06000044u,0x06000048u,0x06000062u,0x06000064u};
    static string Features(ModuleDefinition module)
    {
        var b=new StringBuilder();b.Append(module.Name).Append('|').Append(module.Mvid).Append('|').Append(module.Architecture).Append('|').Append(module.Kind).Append('|').Append(module.RuntimeVersion).Append('|').Append(module.Attributes).Append('|').Append(module.Characteristics).Append('|');
        foreach(var row in module.ModuleReferences)b.Append(row.Name).Append('|');foreach(var row in module.ExportedTypes)b.Append(row.FullName).Append(':').Append(row.Attributes).Append(':').Append(row.Scope).Append('|');
        foreach(var r in module.Resources){Need(r is EmbeddedResource,"Nonembedded resource needs separate audit");b.Append(r.Name).Append(':').Append(r.Attributes).Append(':').Append(r.ResourceType).Append(':').Append(Convert.ToHexString(SHA256.HashData(((EmbeddedResource)r).GetResourceData()))).Append('|');}
        Need(module.Assembly.SecurityDeclarations.Count==0,"Assembly security declaration requires separate audit");
        foreach(var t in Types(module.Types)){Need(t.SecurityDeclarations.Count==0,"Type security declaration requires separate audit");foreach(var f in t.Fields)Need(!f.HasMarshalInfo,"Field marshaling requires separate comparer");foreach(var m in t.Methods){Need(m.SecurityDeclarations.Count==0&&!m.MethodReturnType.HasMarshalInfo&&m.Parameters.All(p=>!p.HasMarshalInfo),"Method security/marshaling requires separate comparer");b.Append(m.MetadataToken.ToUInt32()).Append(':').Append(m.CallingConvention).Append(':').Append(m.HasThis).Append(':').Append(m.ExplicitThis).Append('|');if(m.HasPInvokeInfo)b.Append(m.PInvokeInfo.Module.Name).Append(':').Append(m.PInvokeInfo.EntryPoint).Append(':').Append(m.PInvokeInfo.Attributes).Append('|');}}
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(b.ToString())));
    }
    static object NormalizeDonor(ModuleDefinition donor,ModuleDefinition target)
    {
        // Literal, invertible projection in the disposable donor only. Runtime
        // TypeDefs, fields, getters and method names are never renamed.
        var types=new[]{Tuple.Create("MNALHHOLFGL/ResolveClosureAlias","MNALHHOLFGL/<>c",0x02000009u),Tuple.Create("OENEDGPIOFN/SortedClosureAlias","OENEDGPIOFN/<>c",0x0200000eu)};
        var edits=new List<Tuple<IMemberDefinition,string,string>>();
        foreach(var row in types)
        {
            var a=Types(donor.Types).Single(t=>t.FullName==row.Item1);var b=Types(target.Types).Single(t=>t.FullName==row.Item2&&t.MetadataToken.ToUInt32()==row.Item3);
            Need(a.GenericParameters.Count==0&&b.GenericParameters.Count==0,"Exact nongeneric original closure owners");edits.Add(Tuple.Create((IMemberDefinition)a,a.Name,b.Name));
            foreach(var fields in new[]{Tuple.Create("Singleton","<>9"),Tuple.Create("CachedSelector",row.Item3==0x02000009u?"<>9__45_0":"<>9__13_0")}){var f=a.Fields.Single(x=>x.Name==fields.Item1);var g=b.Fields.Single(x=>x.Name==fields.Item2);Need(f.Attributes==g.Attributes,"Exact original closure field flags");edits.Add(Tuple.Create((IMemberDefinition)f,f.Name,g.Name));}
            var name=row.Item3==0x02000009u?"SelectProvider":"SelectKey";var raw=row.Item3==0x02000009u?"<TryResolveAll>b__45_0":"<Sorted>b__13_0";var method=a.Methods.Single(m=>m.Name==name);Need(b.Methods.Count(m=>m.Name==raw)==1,"Exact existing original selector");edits.Add(Tuple.Create((IMemberDefinition)method,method.Name,raw));
        }
        string metadata=MetadataRoundTripSafety.Fingerprint(donor),features=Features(donor);var methods=Types(donor.Types).SelectMany(t=>t.Methods).ToArray();var safe=BodyAndSymbolSafety.Capture(methods);var il=safe.CaptureNormalized(methods);
        foreach(var e in edits)e.Item1.Name=e.Item3;foreach(var e in edits)e.Item1.Name=e.Item2;
        Need(edits.Count==8&&MetadataRoundTripSafety.Fingerprint(donor)==metadata&&Features(donor)==features&&safe.CaptureNormalized(methods).SequenceEqual(il),"Inverse eight exact donor-only aliases preserve all other semantic metadata/bodies");safe.VerifyObjectIdentity(methods);
        foreach(var e in edits)e.Item1.Name=e.Item3;
        Need(!donor.GetTypeReferences().Any(t=>t.Scope is AssemblyNameReference ar&&ar.Name==donor.Assembly.Name.Name),"No separate donor self-TypeRef outside exact definition aliases");
        return new{exact_donor_only_name_edits=edits.Count,original_runtime_metadata_names_changed=false,inverse_semantic_metadata_and_all_bodies_verified=true};
    }
    static readonly Dictionary<string,uint> Helpers=new Dictionary<string,uint>(StringComparer.Ordinal)
    {
        {"MNALHHOLFGL::FIKOCEOODPI",0x06000024u},{"MNALHHOLFGL/<>c::.ctor",0x06000034u},{"MNALHHOLFGL/<>c::<TryResolveAll>b__45_0",0x06000035u},
        {"OENEDGPIOFN::IEPIDJGAOIN",0x06000036u},{"OENEDGPIOFN::HCILKBKIKOG",0x0600003cu},{"OENEDGPIOFN::IJAKDIKAJHP",0x0600003du},{"OENEDGPIOFN::LAEKFDEFKFK",0x0600003eu},
        {"OENEDGPIOFN/<>c::.ctor",0x06000045u},{"OENEDGPIOFN/<>c::<Sorted>b__13_0",0x06000048u},{"NJAICAFMPBE::AIKLEKDPIFH",0x06000053u},{"NJAICAFMPBE::DHABENNNOIJ",0x06000054u},
        {"DCDAPNDPFMI::IHEKMEOIBOI",0x0600005du},{"MKECFLEMHEL::LGKIDJCLIAD",0x06000062u},{"AGNPJIHDJFG::EJFNLENHABL",0x06000064u},{"CKAJONGONMK::IBOAFOPAJKI",0x06000080u}
    };
    sealed class BodyMap
    {
        readonly MethodDefinition source,destination;readonly ModuleDefinition target;readonly Dictionary<string,TypeDefinition> defs;readonly Dictionary<string,TypeReference> external=new Dictionary<string,TypeReference>(StringComparer.Ordinal);
        public BodyMap(MethodDefinition a,MethodDefinition b){source=a;destination=b;target=b.Module;defs=Types(target.Types).ToDictionary(t=>t.FullName,StringComparer.Ordinal);}
        TypeReference Type(TypeReference t,Dictionary<GenericParameter,TypeReference> methodArguments=null)
        {
            if(t is GenericParameter gp)
            {
                if(methodArguments!=null&&methodArguments.TryGetValue(gp,out var mapped))return mapped;
                if(gp.Type==GenericParameterType.Method){Need(ReferenceEquals(gp.Owner,source)&&gp.Position<destination.GenericParameters.Count,"Only selected member's own GP unless exact external method context supplied");return destination.GenericParameters[gp.Position];}
                Need(gp.Owner is TypeReference owner&&owner.Scope is AssemblyNameReference,"Only original foreign type generic parameter");var imported=Type((TypeReference)gp.Owner);Need(gp.Position<imported.GenericParameters.Count,"Exact external type GP arity");return imported.GenericParameters[gp.Position];
            }
            if(t is GenericInstanceType gi){var result=new GenericInstanceType(Type(gi.ElementType,methodArguments));foreach(var a in gi.GenericArguments)result.GenericArguments.Add(Type(a,methodArguments));return result;}
            if(t is ByReferenceType br)return new ByReferenceType(Type(br.ElementType,methodArguments));
            Need(!(t is TypeSpecification),"No unreviewed array/pointer/modifier TypeSpec in this exact slice");
            var scope=t.Scope is AssemblyNameReference ar?ar.Name:t.Scope is ModuleDefinition md?md.Assembly.Name.Name:null;
            if(scope==source.Module.Assembly.Name.Name){Need(defs.TryGetValue(t.FullName,out var found),"No donor-only declaration enters runtime module");return found;}
            Need(t.Scope is AssemblyNameReference&&((scope=="System.Core"&&t.FullName=="System.Linq.Enumerable")||(scope=="mscorlib"&&new[]{"System.Object","System.Void","System.Boolean","System.String","System.IntPtr","System.InvalidOperationException","System.IDisposable","System.Collections.IEnumerator","System.Collections.Generic.Dictionary`2","System.Collections.Generic.List`1","System.Collections.Generic.IEnumerable`1","System.Collections.Generic.IEnumerator`1","System.Collections.Generic.KeyValuePair`2","System.Nullable`1","System.Func`2"}.Contains(t.FullName))),"Exact tested framework type allowlist: "+t.FullName);
            var requested=(AssemblyNameReference)t.Scope;Need(requested.FullName==scope+", Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089","Exact original-owner donor framework identity");
            var retained=target.AssemblyReferences.Single(a=>a.Name==scope);Need(retained.FullName==scope+", Version=4.0.0.0, Culture=neutral, PublicKeyToken="+(scope=="System.Core"?"7cec85d7bea7798e":"b77a5c561934e089"),"Retain exact current original framework scope, no duplicate reference");
            // Keep ECMA primitive signature kinds (especially Void), rather
            // than constructing class TypeRefs with the same display name.
            if(t.MetadataType==MetadataType.Void)return target.TypeSystem.Void;if(t.MetadataType==MetadataType.Boolean)return target.TypeSystem.Boolean;if(t.MetadataType==MetadataType.String)return target.TypeSystem.String;if(t.MetadataType==MetadataType.Object)return target.TypeSystem.Object;if(t.MetadataType==MetadataType.IntPtr)return target.TypeSystem.IntPtr;
            if(external.TryGetValue(t.FullName,out var old))return old;
            var x=new TypeReference(t.Namespace,t.Name,target,retained,t.IsValueType);external.Add(t.FullName,x);foreach(var p in t.GenericParameters){Need(p.Constraints.Count==0,"External GP constraints remain definition authority");x.GenericParameters.Add(new GenericParameter(p.Name,x){Attributes=p.Attributes});}return x;
        }
        FieldReference Field(FieldReference f)
        {
            var owner=Type(f.DeclaringType) as TypeDefinition;Need(owner!=null,"Every selected field is an existing original same-module field");var original=owner.Fields.Single(x=>x.Name==f.Name);
            Need(new[]{"MNALHHOLFGL::AAHKPPMHGFI","MNALHHOLFGL::LMAFHCPPMAD","MNALHHOLFGL::OLGLBMGAHBO","MNALHHOLFGL::MGADLDPDPGK","MNALHHOLFGL/<>c::<>9","MNALHHOLFGL/<>c::<>9__45_0","OENEDGPIOFN::OMMELJLAGLB","OENEDGPIOFN/NPDGPDKAHLN::HDPNFBMCAHN","OENEDGPIOFN/<>c::<>9","OENEDGPIOFN/<>c::<>9__13_0"}.Contains(owner.FullName+"::"+f.Name),"Exact original field allowlist");
            Need(original.Attributes==f.Resolve().Attributes&&CanonicalMetadataSignatures.Type(original.FieldType)==CanonicalMetadataSignatures.Type(Type(f.FieldType)),"Preserve exact original field type/flags");return original;
        }
        MethodReference Method(MethodReference m)
        {
            if(m is GenericInstanceMethod gi){var result=new GenericInstanceMethod(Method(gi.ElementMethod));foreach(var a in gi.GenericArguments)result.GenericArguments.Add(Type(a));return result;}
            var owner=Type(m.DeclaringType);
            if(owner is TypeDefinition def)
            {
                string k=def.FullName+"::"+m.Name;Need(Helpers.TryGetValue(k,out var token),"Only literal existing original callee token: "+k);var found=def.Methods.Single(x=>x.MetadataToken.ToUInt32()==token);Need(found.Name==m.Name&&CanonicalMetadataSignatures.Method(found)==CanonicalMetadataSignatures.Method(m),"Exact original helper signature and generic arity");
                if(def.FullName=="NJAICAFMPBE")Need(found.IsGetter&&(uint)found.Attributes==3526u&&found.GenericParameters.Count==0,"Thin ordinary context resolves exact original SpecialName getter, never copied");return found;
            }
            string pair=m.DeclaringType.GetElementType().FullName+"::"+m.Name;
            Need(new[]{"System.Collections.Generic.KeyValuePair`2::get_Value","System.Collections.Generic.Dictionary`2::ContainsKey","System.Collections.Generic.Dictionary`2::TryGetValue","System.Collections.Generic.Dictionary`2::Add","System.Collections.Generic.IEnumerable`1::GetEnumerator","System.Collections.Generic.IEnumerator`1::get_Current","System.Collections.IEnumerator::MoveNext","System.IDisposable::Dispose","System.Func`2::.ctor","System.Nullable`1::.ctor","System.String::Format","System.InvalidOperationException::.ctor","System.Linq.Enumerable::Select","System.Linq.Enumerable::ToList"}.Contains(pair),"Exact tested external member allowlist: "+pair);
            Need(!m.HasGenericParameters||(m.DeclaringType.FullName=="System.Linq.Enumerable"&&((m.Name=="Select"&&m.GenericParameters.Count==2)||(m.Name=="ToList"&&m.GenericParameters.Count==1))),"Only exact two LINQ external method-generic templates");
            var resultMethod=new MethodReference(m.Name,target.TypeSystem.Void,owner){HasThis=m.HasThis,ExplicitThis=m.ExplicitThis,CallingConvention=m.CallingConvention};var gps=new Dictionary<GenericParameter,TypeReference>();
            foreach(var gp in m.GenericParameters){Need(gp.Constraints.Count==0,"Only framework reference template generic signatures");var mapped=new GenericParameter(gp.Name,resultMethod){Attributes=gp.Attributes};resultMethod.GenericParameters.Add(mapped);gps.Add(gp,mapped);}
            resultMethod.ReturnType=Type(m.ReturnType,gps);foreach(var p in m.Parameters)resultMethod.Parameters.Add(new ParameterDefinition(Type(p.ParameterType,gps)));
            Need(CanonicalMetadataSignatures.Type(owner)==CanonicalMetadataSignatures.Type(m.DeclaringType)&&CanonicalMetadataSignatures.Method(resultMethod)==CanonicalMetadataSignatures.Method(m),"Exact generic-owner/framework signature through original retained scope");return resultMethod;
        }
        public void Copy()
        {
            Need(source.HasBody&&destination.HasBody&&destination.Body.ExceptionHandlers.Count==0,"Current selected original stub has no EH");
            var old=destination.Body;var ops=old.Instructions.Select(i=>i.OpCode.Code).ToArray();uint token=destination.MetadataToken.ToUInt32();
            if(new uint[]{0x0600002fu,0x06000033u,0x06000044u,0x06000062u}.Contains(token))Need(old.Variables.Count==0&&ops.SequenceEqual(new[]{Code.Ret}),"Only exact original empty retained stub");
            else if(token==0x06000035u||token==0x0600003du)Need(old.Variables.Count==0&&ops.SequenceEqual(new[]{Code.Ldnull,Code.Ret}),"Only exact original null-return retained stub");
            else if(token==0x06000064u)Need(old.Variables.Count==0&&ops.SequenceEqual(new[]{Code.Ldc_I4_0,Code.Ret}),"Only exact original false predicate retained stub");
            else Need(token==0x06000048u&&old.Variables.Count==1&&old.Variables[0].VariableType.FullName=="CPAMAFPANDM"&&ops.SequenceEqual(new[]{Code.Ldloca_S,Code.Initobj,Code.Ldloc_0,Code.Ret})&&old.Instructions[1].Operand is TypeDefinition key&&key.FullName=="CPAMAFPANDM"&&key.MetadataToken.ToUInt32()==0x02000010u,"Only exact original value-default key-selector retained stub");
            if(destination.Name=="LNFNAIMOFOF")Need(source.Body.ExceptionHandlers.Count==2&&source.Body.ExceptionHandlers.All(h=>h.HandlerType==ExceptionHandlerType.Finally),"Exactly two original foreach finalizers");else Need(source.Body.ExceptionHandlers.Count==0,"Other seven selected donors have no EH");
            var body=new MethodBody(destination){InitLocals=source.Body.InitLocals,MaxStackSize=source.Body.MaxStackSize};foreach(var v in source.Body.Variables)body.Variables.Add(new VariableDefinition(Type(v.VariableType)));var map=new Dictionary<Instruction,Instruction>();foreach(var i in source.Body.Instructions){var n=Instruction.Create(OpCodes.Nop);n.OpCode=i.OpCode;map.Add(i,n);body.Instructions.Add(n);}
            foreach(var i in source.Body.Instructions){object o=i.Operand;if(o==null)map[i].Operand=null;else if(o is Instruction branch){Need(map.ContainsKey(branch),"Branch stays inside original selected body");map[i].Operand=map[branch];}else if(o is Instruction[])throw new InvalidDataException("No switch in exact8-member slice");else if(o is VariableDefinition v)map[i].Operand=body.Variables[v.Index];else if(o is ParameterDefinition p)map[i].Operand=destination.Parameters[p.Index];else if(o is MethodReference m)map[i].Operand=Method(m);else if(o is FieldReference f)map[i].Operand=Field(f);else if(o is TypeReference t)map[i].Operand=Type(t);else{Need(o is string||o is sbyte||o is byte||o is int||o is long||o is float||o is double,"No unclassified instruction operand");map[i].Operand=o;}}
            foreach(var h in source.Body.ExceptionHandlers){Need(h.HandlerType==ExceptionHandlerType.Finally&&h.CatchType==null&&h.FilterStart==null&&h.TryStart!=null&&h.HandlerStart!=null,"Only exact original foreach Finally shape");body.ExceptionHandlers.Add(new ExceptionHandler(h.HandlerType){TryStart=map[h.TryStart],TryEnd=h.TryEnd==null?null:map[h.TryEnd],HandlerStart=map[h.HandlerStart],HandlerEnd=h.HandlerEnd==null?null:map[h.HandlerEnd]});}destination.Body=body;
        }
    }
    static int Main(string[] args)
    {
        Need(args.Length==2&&!Directory.Exists(args[1]),"Exact pinned spec and fresh isolated output required");using var doc=JsonDocument.Parse(File.ReadAllBytes(args[0]));var spec=doc.RootElement;Need(spec.GetProperty("schema").GetString()=="eight-tested-container-preparation-body-only-input/v1","Exact8-member staging schema");var row=spec.GetProperty("module");string original=row.GetProperty("original").GetProperty("path").GetString(),donor=row.GetProperty("donor").GetProperty("path").GetString();Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Exact current original SDK and actually tested donor bytes");
        using var target=ModuleDefinition.ReadModule(original,new ReaderParameters{ReadSymbols=false,InMemory=true});using var from=ModuleDefinition.ReadModule(donor,new ReaderParameters{ReadSymbols=false,InMemory=true});Need(target.Assembly.FullName==from.Assembly.FullName&&target.Assembly.Name.Name=="UJect.Runtime","Exact original-owner assembly");var aliases=NormalizeDonor(from,target);var all=Types(target.Types).SelectMany(t=>t.Methods).ToArray();var selected=all.Where(m=>Tokens.Contains(m.MetadataToken.ToUInt32())).ToArray();Need(selected.Length==8,"Exact8 selected original MethodDefs");var donors=selected.Select(m=>Types(from.Types).Single(t=>t.FullName==m.DeclaringType.FullName).Methods.Single(x=>x.Name==m.Name&&x.GenericParameters.Count==m.GenericParameters.Count)).ToArray();
        for(int n=0;n<selected.Length;n++){var a=selected[n];var b=donors[n];Need(a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&a.CallingConvention==b.CallingConvention&&a.HasThis==b.HasThis&&a.ExplicitThis==b.ExplicitThis&&CanonicalMetadataSignatures.Method(a)==CanonicalMetadataSignatures.Method(b)&&a.Parameters.Select(p=>p.Attributes).SequenceEqual(b.Parameters.Select(p=>p.Attributes))&&a.GenericParameters.Select(g=>g.Attributes).SequenceEqual(b.GenericParameters.Select(g=>g.Attributes))&&a.GenericParameters.All(g=>g.Constraints.Count==0)&&b.GenericParameters.All(g=>g.Constraints.Count==0),"Exact original flags/signature/access/generic constraints");}
        var unselected=all.Except(selected).ToArray();var untouched=BodyAndSymbolSafety.Capture(unselected);var keptIL=untouched.CaptureNormalized(unselected);var donorSafety=BodyAndSymbolSafety.Capture(donors);var donorIL=donorSafety.CaptureNormalized(donors);string metadata=MetadataRoundTripSafety.Fingerprint(target),features=Features(target);var refs=target.AssemblyReferences.Select(a=>a.FullName).ToArray();var tokens=all.Select(m=>m.MetadataToken.ToUInt32()).ToArray();
        for(int n=0;n<selected.Length;n++)new BodyMap(donors[n],selected[n]).Copy();untouched.VerifyObjectIdentity(unselected);Need(MetadataRoundTripSafety.Fingerprint(target)==metadata&&Features(target)==features&&target.AssemblyReferences.Select(a=>a.FullName).SequenceEqual(refs),"Every original definition/semantic feature/ordered AssemblyRef retained in memory");var staged=BodyAndSymbolSafety.Capture(selected);Need(staged.CaptureNormalized(selected).SequenceEqual(donorIL),"Every selected instruction/scoped operand/local/branch/EH region equals tested donor through exact aliases");Directory.CreateDirectory(args[1]);string output=Path.Combine(args[1],target.Name);target.Write(output,new WriterParameters{WriteSymbols=false});
        using var emitted=ModuleDefinition.ReadModule(output,new ReaderParameters{ReadSymbols=false,InMemory=true});var methods=Types(emitted.Types).SelectMany(t=>t.Methods).ToArray();Need(methods.Select(m=>m.MetadataToken.ToUInt32()).SequenceEqual(tokens)&&MetadataRoundTripSafety.Fingerprint(emitted)==metadata&&Features(emitted)==features&&emitted.AssemblyReferences.Select(a=>a.FullName).SequenceEqual(refs),"All emitted original MethodDef tokens/definitions/semantic metadata/features/ordered references unchanged");var keys=new HashSet<string>(selected.Select(Key),StringComparer.Ordinal);var kept=methods.Where(m=>!keys.Contains(Key(m))).ToArray();var replaced=methods.Where(m=>keys.Contains(Key(m))).ToArray();untouched.VerifyEmitted(keptIL,kept);staged.VerifyEmitted(donorIL,replaced);Need(replaced.Single(m=>m.Name=="LNFNAIMOFOF").Body.ExceptionHandlers.Count==2&&replaced.Where(m=>m.Name!="LNFNAIMOFOF").All(m=>m.Body.ExceptionHandlers.Count==0),"Exact selected EH readback");Need(Sha(original)==row.GetProperty("original").GetProperty("sha256").GetString()&&Sha(donor)==row.GetProperty("donor").GetProperty("sha256").GetString(),"Original SDK and tested donor files unchanged");
        var report=new{schema="eight-tested-original-preparation-body-only-candidate/v1",status="eight_tested_preparation_bodies_staged_original_metadata_other_bodies_and_EH_preserved",original=row.GetProperty("original"),donor=row.GetProperty("donor"),candidate=new{path=output,bytes=new FileInfo(output).Length,sha256=Sha(output)},selected_original_members=selected.Select(m=>new{owner=m.DeclaringType.FullName,name=m.Name,token=m.MetadataToken.ToUInt32()}).ToArray(),donor_only_aliases=aliases,changed_method_bodies=8,all_other_method_bodies_unchanged=kept.Length,metadata_fingerprint=metadata,module_features_fingerprint=features,ordered_original_AssemblyRefs=refs,all_original_MethodDef_tokens_preserved=true,entire_donor_bodies_scoped_operands_locals_branches_and_EH_equal=true,body_owned_MemberRef_MethodSpec_TypeSpec_local_rows_may_be_emitted=true,original_runtime_metadata_names_changed=false,game_code_loaded_or_executed=false,Main_modified=false,LNF_Main_activation_held=true,graph_roots_sort_cycle_and_FIKO_still_unrecovered=true,working_bootstrap_claimed=false};File.WriteAllText(Path.Combine(args[1],"report.json"),JsonSerializer.Serialize(report,new JsonSerializerOptions{WriteIndented=true})+"\n",new UTF8Encoding(false));Console.WriteLine("Eight exact tested preparation bodies staged; definitions, ordered refs, all other bodies and two finalizers preserved. Main activation held.");return 0;
    }
}
