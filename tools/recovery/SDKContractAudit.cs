// Metadata-only comparison. Inspected assemblies are never loaded into the CLR.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using Mono.Cecil;

internal static partial class SDKContractAudit
{
    static string Sha(string path) { using(var s=File.OpenRead(path)) using(var h=SHA256.Create()) return BitConverter.ToString(h.ComputeHash(s)).Replace("-", "").ToLowerInvariant(); }
    static IEnumerable<TypeDefinition> All(TypeDefinition t) { yield return t; foreach(var n in t.NestedTypes) foreach(var x in All(n)) yield return x; }
    static string T(TypeReference t) {
        if(t==null) return "-";
        var p=t as GenericParameter; if(p!=null) return (p.Type==GenericParameterType.Method?"!!":"!")+p.Position;
        var g=t as GenericInstanceType; if(g!=null) return T(g.ElementType)+"<"+String.Join(",",g.GenericArguments.Select(T))+">";
        var a=t as ArrayType; if(a!=null) return T(a.ElementType)+"["+String.Join(",",a.Dimensions.Select(d=>(d.LowerBound.HasValue?d.LowerBound.ToString():"")+":"+(d.UpperBound.HasValue?d.UpperBound.ToString():"")))+"]";
        var r=t as ByReferenceType; if(r!=null) return T(r.ElementType)+"&";
        var ptr=t as PointerType; if(ptr!=null) return T(ptr.ElementType)+"*";
        var rq=t as RequiredModifierType; if(rq!=null) return "modreq("+T(rq.ModifierType)+")"+T(rq.ElementType);
        var op=t as OptionalModifierType; if(op!=null) return "modopt("+T(op.ModifierType)+")"+T(op.ElementType);
        var pin=t as PinnedType; if(pin!=null) return "pinned("+T(pin.ElementType)+")";
        string scope=t.Scope is AssemblyNameReference?((AssemblyNameReference)t.Scope).Name:t.Module.Assembly.Name.Name;
        return "["+scope+"]"+t.FullName;
    }
    static string M(MethodDefinition m) { return m.Name+"``"+m.GenericParameters.Count+"("+String.Join(",",m.Parameters.Select(p=>T(p.ParameterType)))+")->"+T(m.ReturnType); }
    static string P(PropertyDefinition p) { return p.Name+"("+String.Join(",",p.Parameters.Select(x=>T(x.ParameterType)))+")->"+T(p.PropertyType); }
    static string Access(MethodDefinition m) { return m==null?"-":M(m); }
    static string C(object value) { return value==null?"null":value.GetType().FullName+":"+Convert.ToString(value,System.Globalization.CultureInfo.InvariantCulture); }
    static string Marshal(IMarshalInfoProvider provider) {
        if(!provider.HasMarshalInfo)return "-";
        var value=provider.MarshalInfo;
        return value.GetType().FullName+":"+String.Join("|",value.GetType().GetProperties(System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.Public).OrderBy(p=>p.Name,StringComparer.Ordinal).Select(p=>{var v=p.GetValue(value,null);return p.Name+"="+(v is TypeReference?T((TypeReference)v):C(v));}));
    }
    static string Param(ParameterDefinition p) { return ((int)p.Attributes)+":"+(p.HasConstant?C(p.Constant):"-")+":"+Marshal(p); }
    static bool Generated(TypeDefinition t) { return t.Name.StartsWith("<",StringComparison.Ordinal)||t.CustomAttributes.Any(a=>a.AttributeType.FullName=="System.Runtime.CompilerServices.CompilerGeneratedAttribute"); }
    static bool Public(TypeDefinition t) { return t.IsPublic || t.IsNestedPublic || t.IsNestedFamily || t.IsNestedFamilyOrAssembly; }
    static string Constraints(IEnumerable<GenericParameter> ps) { return String.Join("|",ps.Select(p=>p.Position+":"+(int)p.Attributes+":"+String.Join(",",p.Constraints.Select(c=>T(c.ConstraintType)).OrderBy(s=>s,StringComparer.Ordinal)))); }
    static bool Serialized(FieldDefinition f) { return f.CustomAttributes.Any(a=>a.AttributeType.FullName=="UnityEngine.SerializeField"||a.AttributeType.FullName=="UnityEngine.SerializeReference"); }
    static string Constant(FieldDefinition f) { return f.HasConstant ? (f.Constant==null?"null":f.Constant.GetType().FullName+":"+Convert.ToString(f.Constant,System.Globalization.CultureInfo.InvariantCulture)) : "-"; }
    static object Compare(string nativePath,string currentPath,string candidatePath) {
        var issues=new List<object>();var pairs=new List<object>();int originalTypes=0,originalFields=0,originalMethods=0,matchedTypes=0,matchedFields=0,matchedMethods=0,implemented=0,publicGaps=0,layoutGaps=0,generatedMissing=0;
        using(var original=AssemblyDefinition.ReadAssembly(nativePath))
        using(var current=AssemblyDefinition.ReadAssembly(currentPath))
        using(var candidate=AssemblyDefinition.ReadAssembly(candidatePath)) {
            if(original.Name.FullName!=candidate.Name.FullName) {issues.Add(new {kind="assembly-identity",original=original.Name.FullName,candidate=candidate.Name.FullName});publicGaps++;}
            var candidates=candidate.MainModule.Types.SelectMany(All).ToDictionary(t=>t.FullName,StringComparer.Ordinal);
            var currentTypes=current.MainModule.Types.SelectMany(All).ToDictionary(t=>t.FullName,StringComparer.Ordinal);
            foreach(var raw in original.MainModule.Types.SelectMany(All).Where(t=>t.Name!="<Module>"&&t.FullName!="Cpp2ILInjected.Cpp2ILHelpers")) {
                originalTypes++; TypeDefinition actual;
                if(!candidates.TryGetValue(raw.FullName,out actual)) { if(Generated(raw)) generatedMissing++;else {issues.Add(new {kind="missing-original-type",owner=raw.FullName,original_token=raw.MetadataToken.ToUInt32(),is_public=Public(raw)});if(Public(raw))publicGaps++;}continue; }
                matchedTypes++;bool pub=Public(raw);int before=issues.Count;TypeDefinition baseline;
                currentTypes.TryGetValue(raw.FullName,out baseline);
                if(raw.Attributes!=actual.Attributes||T(raw.BaseType)!=T(actual.BaseType)||raw.IsValueType!=actual.IsValueType||raw.IsEnum!=actual.IsEnum||raw.IsExplicitLayout!=actual.IsExplicitLayout||raw.IsSequentialLayout!=actual.IsSequentialLayout||raw.PackingSize!=actual.PackingSize||raw.ClassSize!=actual.ClassSize||Constraints(raw.GenericParameters)!=Constraints(actual.GenericParameters)||!raw.Interfaces.Select(i=>T(i.InterfaceType)).OrderBy(s=>s).SequenceEqual(actual.Interfaces.Select(i=>T(i.InterfaceType)).OrderBy(s=>s))) {
                    issues.Add(new {kind="type-layout-or-contract",owner=raw.FullName,original_base=T(raw.BaseType),candidate_base=T(actual.BaseType),original_flags=(int)raw.Attributes,candidate_flags=(int)actual.Attributes,original_size=raw.ClassSize,candidate_size=actual.ClassSize,original_pack=raw.PackingSize,candidate_pack=actual.PackingSize,original_generic=Constraints(raw.GenericParameters),candidate_generic=Constraints(actual.GenericParameters)});layoutGaps++;if(pub)publicGaps++;
                }
                foreach(var field in raw.Fields) {
                    originalFields++;var found=actual.Fields.Where(f=>f.Name==field.Name&&T(f.FieldType)==T(field.FieldType)).ToArray();
                    if(found.Length!=1) {issues.Add(new {kind="missing-or-ambiguous-original-field",owner=raw.FullName,name=field.Name,type=T(field.FieldType),token=field.MetadataToken.ToUInt32(),serialized=Serialized(field),is_public=field.IsPublic});layoutGaps++;if(pub&&field.IsPublic)publicGaps++;continue;}
                    var cf=found[0];matchedFields++;
                    var markerOwner=baseline==null?new FieldDefinition[0]:baseline.Fields.Where(f=>f.Name==field.Name&&T(f.FieldType)==T(field.FieldType)).ToArray();
                    bool serialized=markerOwner.Length==1?Serialized(markerOwner[0]):Serialized(field);
                    if(field.Attributes!=cf.Attributes||field.Offset!=cf.Offset||Constant(field)!=Constant(cf)||serialized!=Serialized(cf)||Marshal(field)!=Marshal(cf)) {issues.Add(new {kind="field-contract",owner=raw.FullName,name=field.Name,type=T(field.FieldType),original_flags=(int)field.Attributes,candidate_flags=(int)cf.Attributes,original_offset=field.Offset,candidate_offset=cf.Offset,original_serialized=serialized,candidate_serialized=Serialized(cf),original_marshal=Marshal(field),candidate_marshal=Marshal(cf)});layoutGaps++;if(pub&&field.IsPublic)publicGaps++;}
                }
                var rawInstanceFields=raw.Fields.Where(f=>!f.IsStatic&&!f.IsLiteral).Select(f=>f.Name+":"+T(f.FieldType)).ToArray();
                var candidateInstanceFields=actual.Fields.Where(f=>!f.IsStatic&&!f.IsLiteral).Select(f=>f.Name+":"+T(f.FieldType)).ToArray();
                if(!rawInstanceFields.SequenceEqual(candidateInstanceFields)) {issues.Add(new {kind="instance-field-order-or-addition",owner=raw.FullName,original_order=rawInstanceFields,candidate_order=candidateInstanceFields});layoutGaps++;}
                var methods=actual.Methods.GroupBy(M).ToDictionary(g=>g.Key,g=>g.ToArray(),StringComparer.Ordinal);
                foreach(var method in raw.Methods) {
                    originalMethods++;MethodDefinition[] found;string shape=M(method);
                    if(!methods.TryGetValue(shape,out found)||found.Length!=1) {if(!Generated(raw)){issues.Add(new {kind="missing-or-ambiguous-original-method",owner=raw.FullName,signature=shape,token=method.MetadataToken.ToUInt32(),is_public=method.IsPublic});if(pub&&method.IsPublic)publicGaps++;}continue;}
                    matchedMethods++;var cm=found[0];if(cm.HasBody)implemented++;
                    if(method.Attributes!=cm.Attributes||method.ImplAttributes!=cm.ImplAttributes||method.CallingConvention!=cm.CallingConvention||method.HasThis!=cm.HasThis||method.ExplicitThis!=cm.ExplicitThis||Constraints(method.GenericParameters)!=Constraints(cm.GenericParameters)||!method.Parameters.Select(Param).SequenceEqual(cm.Parameters.Select(Param))||method.MethodReturnType.Attributes!=cm.MethodReturnType.Attributes||Marshal(method.MethodReturnType)!=Marshal(cm.MethodReturnType)) {issues.Add(new {kind="method-contract",owner=raw.FullName,signature=shape,original_flags=(int)method.Attributes,candidate_flags=(int)cm.Attributes,original_impl=(int)method.ImplAttributes,candidate_impl=(int)cm.ImplAttributes,original_generic=Constraints(method.GenericParameters),candidate_generic=Constraints(cm.GenericParameters),original_parameter_flags=method.Parameters.Select(p=>(int)p.Attributes).ToArray(),candidate_parameter_flags=cm.Parameters.Select(p=>(int)p.Attributes).ToArray(),original_return_marshal=Marshal(method.MethodReturnType),candidate_return_marshal=Marshal(cm.MethodReturnType)});if(pub&&method.IsPublic)publicGaps++;}
                    if(method.IsPublic||method.Name==".cctor") pairs.Add(new {owner=raw.FullName,signature=shape,original_token=method.MetadataToken.ToUInt32(),candidate_token=cm.MetadataToken.ToUInt32(),candidate_has_body=cm.HasBody,instruction_count=cm.HasBody?cm.Body.Instructions.Count:0});
                }
                foreach(var property in raw.Properties) {
                    var found=actual.Properties.Where(p=>P(p)==P(property)).ToArray();
                    if(found.Length!=1||found[0].Attributes!=property.Attributes||Access(found[0].GetMethod)!=Access(property.GetMethod)||Access(found[0].SetMethod)!=Access(property.SetMethod)||!found[0].OtherMethods.Select(Access).OrderBy(s=>s).SequenceEqual(property.OtherMethods.Select(Access).OrderBy(s=>s))||found[0].HasConstant!=property.HasConstant||(property.HasConstant&&C(found[0].Constant)!=C(property.Constant))) {issues.Add(new {kind="property-contract",owner=raw.FullName,property=P(property),original_getter=Access(property.GetMethod),original_setter=Access(property.SetMethod)});if(pub)publicGaps++;}
                }
                foreach(var ev in raw.Events) {
                    var found=actual.Events.Where(e=>e.Name==ev.Name&&T(e.EventType)==T(ev.EventType)).ToArray();
                    if(found.Length!=1||found[0].Attributes!=ev.Attributes||Access(found[0].AddMethod)!=Access(ev.AddMethod)||Access(found[0].RemoveMethod)!=Access(ev.RemoveMethod)||Access(found[0].InvokeMethod)!=Access(ev.InvokeMethod)||!found[0].OtherMethods.Select(Access).OrderBy(s=>s).SequenceEqual(ev.OtherMethods.Select(Access).OrderBy(s=>s))) {issues.Add(new {kind="event-contract",owner=raw.FullName,name=ev.Name,type=T(ev.EventType),original_add=Access(ev.AddMethod),original_remove=Access(ev.RemoveMethod)});if(pub)publicGaps++;}
                }
            }
            return new {original_identity=original.Name.FullName,candidate_identity=candidate.Name.FullName,current_identity=current.Name.FullName,native_metadata=new {path=nativePath,sha256=Sha(nativePath)},current_runtime=new {path=currentPath,sha256=Sha(currentPath)},candidate=new {path=candidatePath,sha256=Sha(candidatePath)},explicit_excluded_tool_type="Cpp2ILInjected.Cpp2ILHelpers",original_types=originalTypes,matched_types=matchedTypes,generated_types_missing=generatedMissing,original_fields=originalFields,matched_fields=matchedFields,original_methods=originalMethods,matched_methods=matchedMethods,matched_methods_with_genuine_package_bodies=implemented,public_api_gaps=publicGaps,layout_or_serialization_gaps=layoutGaps,issue_count=issues.Count,issues,public_method_and_cctor_bindings=pairs,all_original_contracts_match=issues.Count==0};
        }
    }
    static int Main(string[] args) {
        if(args.Length==2&&args[0]=="--fixtures")return SDKContractFixtures(args[1]);
        if(args.Length==3&&args[0]=="--native-rows") {
            if(File.Exists(args[2]))throw new InvalidDataException("Fresh rows required.");
            using(var a=AssemblyDefinition.ReadAssembly(args[1])) {
                var rows=a.MainModule.Types.SelectMany(All).Where(t=>t.Name!="<Module>").Select(t=>new {owner=t.FullName,flags=(uint)t.Attributes,fields=t.Fields.Select(f=>new{name=f.Name,type=T(f.FieldType),flags=(uint)f.Attributes}).ToArray(),methods=t.Methods.Select(m=>new{signature=M(m),flags=(uint)m.Attributes,impl_flags=(uint)m.ImplAttributes,parameter_flags=m.Parameters.Select(p=>(uint)p.Attributes).ToArray(),return_flags=(uint)m.MethodReturnType.Attributes}).ToArray()}).ToArray();
                File.WriteAllText(args[2],new JavaScriptSerializer{MaxJsonLength=32*1024*1024}.Serialize(new{assembly=a.Name.Name,sha256=Sha(args[1]),types=rows}));return 0;
            }
        }
        try {if(args.Length!=4||File.Exists(args[3]))throw new ArgumentException("native current candidate fresh-report");var row=Compare(args[0],args[1],args[2]);var report=new {schema="official-sdk-versus-original-contracts/v1",status="comparison-only-no-apply",project_changed=false,game_code_executed=false,assembly=row};File.WriteAllText(args[3],new JavaScriptSerializer{MaxJsonLength=32*1024*1024,RecursionLimit=100}.Serialize(report));Console.WriteLine("SDK metadata comparison saved; no project changed or SDK methods executed.");return 0;}catch(Exception error){Console.Error.WriteLine(error);return 1;}
    }
}
