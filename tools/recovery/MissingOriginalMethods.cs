// Original/compiled method metadata matching via CLR table readers only.
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

sealed class SignatureNames : ISignatureTypeProvider<string,object?>
{
    readonly Dictionary<string,string> aliases;readonly bool project;
    public SignatureNames(Dictionary<string,string> aliases,bool project){this.aliases=aliases;this.project=project;}
    static string Part(string s)=>s.Length+":"+s;
    string Named(string assembly,string full){if(project&&aliases.TryGetValue(assembly+":"+full,out var value))full=value;return "N"+Part(assembly)+Part(full);}
    public static string Full(MetadataReader r,TypeDefinitionHandle h){var t=r.GetTypeDefinition(h);var parent=t.GetDeclaringType();var n=r.GetString(t.Name);if(!parent.IsNil)return Full(r,parent)+"/"+n;var ns=r.GetString(t.Namespace);return ns.Length==0?n:ns+"."+n;}
    static (string Assembly,string Full) Reference(MetadataReader r,TypeReferenceHandle h){var t=r.GetTypeReference(h);var n=r.GetString(t.Name);if(t.ResolutionScope.Kind==HandleKind.TypeReference){var p=Reference(r,(TypeReferenceHandle)t.ResolutionScope);return(p.Assembly,p.Full+"/"+n);}var ns=r.GetString(t.Namespace);var assembly=t.ResolutionScope.Kind==HandleKind.AssemblyReference?r.GetString(r.GetAssemblyReference((AssemblyReferenceHandle)t.ResolutionScope).Name):r.GetString(r.GetAssemblyDefinition().Name);return(assembly,ns.Length==0?n:ns+"."+n);}
    public string GetArrayType(string e,ArrayShape s){var dimensions=Enumerable.Range(0,s.Rank).Select(i=>{int? lower=i<s.LowerBounds.Length?s.LowerBounds[i]:null;int? upper=i<s.Sizes.Length?(lower??0)+s.Sizes[i]-1:null;return(lower?.ToString()??"?")+":"+(upper?.ToString()??"?");});return "A"+s.Rank+"("+e+")["+string.Join(",",dimensions)+"]";}
    public string GetByReferenceType(string e)=>"R("+e+")";
    public string GetFunctionPointerType(MethodSignature<string> s)=>"F"+(s.Header.RawValue&0x1f)+":"+(s.Header.IsInstance?"1":"0")+((s.Header.RawValue&0x40)!=0?"1":"0")+"("+s.ReturnType+")["+string.Join("",s.ParameterTypes)+"]";
    public string GetGenericInstantiation(string t,ImmutableArray<string>a)=>"G("+t+")["+string.Join("",a)+"]";
    public string GetGenericMethodParameter(object? c,int i)=>"!!"+i+";";
    public string GetGenericTypeParameter(object? c,int i)=>"!"+i+";";
    public string GetModifiedType(string m,string e,bool required)=>(required?"Q(":"O(")+m+","+e+")";
    public string GetPinnedType(string e)=>"I("+e+")";
    public string GetPointerType(string e)=>"P("+e+")";
    public string GetPrimitiveType(PrimitiveTypeCode c)=>Named("mscorlib","System."+(c==PrimitiveTypeCode.IntPtr?"IntPtr":c==PrimitiveTypeCode.UIntPtr?"UIntPtr":c.ToString()));
    public string GetSZArrayType(string e)=>"V("+e+")[?:?]";
    public string GetTypeFromDefinition(MetadataReader r,TypeDefinitionHandle h,byte kind)=>Named(r.GetString(r.GetAssemblyDefinition().Name),Full(r,h));
    public string GetTypeFromReference(MetadataReader r,TypeReferenceHandle h,byte kind){var t=Reference(r,h);return Named(t.Assembly,t.Full);}
    public string GetTypeFromSpecification(MetadataReader r,object? c,TypeSpecificationHandle h,byte kind)=>r.GetTypeSpecification(h).DecodeSignature(this,c);
    public string Method(MetadataReader r,MethodDefinitionHandle h){var m=r.GetMethodDefinition(h);var s=m.DecodeSignature(this,(object?)null);var n=r.GetString(m.Name);return "M"+Part(n)+s.GenericParameterCount+":"+(s.Header.RawValue&0x1f)+":"+(s.Header.IsInstance?"1":"0")+((s.Header.RawValue&0x40)!=0?"1":"0")+"("+s.ReturnType+")["+string.Join("",s.ParameterTypes)+"]";}
}
static class MissingOriginalMethods
{
    static int Count(BinaryReader b,int limit){var n=b.ReadInt32();if(n<0||n>limit)throw new InvalidDataException("Manifest bound");return n;}
    static void SkipStrings(BinaryReader b){for(int i=Count(b,1000);i>0;i--)b.ReadString();}
    static int Main(string[] args)
    {
        if(args.Length!=4||File.Exists(args[3]))throw new ArgumentException("raw-core.dll actual-compiled-core.dll current-manifest.bin fresh-output.jsonl");
        var types=new Dictionary<string,string>();var own=new Dictionary<string,string>();var methods=new Dictionary<string,string>();
        using(var stream=File.OpenRead(args[2]))using(var b=new BinaryReader(stream)){if(b.ReadString()!="RR23-METADATA-RESTORE-5")throw new InvalidDataException("Expected current V5 manifest");for(int i=0;i<5;i++)b.ReadString();b.ReadBoolean();SkipStrings(b);for(int i=Count(b,100000);i>0;i--){var a=b.ReadString();var o=b.ReadString();var c=b.ReadString();types.Add(a+":"+o,c);if(a=="Assembly-CSharp")own.Add(o,c);}for(int i=Count(b,1000000);i>0;i--){var a=b.ReadString();var o=b.ReadString();b.ReadString();b.ReadString();b.ReadString();var c=b.ReadString();var original=b.ReadString();b.ReadString();SkipStrings(b);if(a=="Assembly-CSharp")methods.Add(o+"|"+original,c);}}
        using var rs=File.OpenRead(args[0]);using var rp=new PEReader(rs);var raw=rp.GetMetadataReader();
        using var cs=File.OpenRead(args[1]);using var cp=new PEReader(cs);var actual=cp.GetMetadataReader();
        var originalNames=new SignatureNames(types,false);var projectedNames=new SignatureNames(types,true);
        var actualMethods=new HashSet<string>();var actualOwners=new HashSet<string>();
        foreach(var t in actual.TypeDefinitions){var owner=SignatureNames.Full(actual,t);actualOwners.Add(owner);foreach(var m in actual.GetTypeDefinition(t).GetMethods())if(!actualMethods.Add(owner+"|"+originalNames.Method(actual,m)))throw new InvalidDataException("Duplicate actual method identity");}
        var semantic=new Dictionary<MethodDefinitionHandle,int>();void Add(MethodDefinitionHandle h,int flags){if(!h.IsNil)semantic[h]=semantic.GetValueOrDefault(h)|flags;}
        foreach(var p in raw.PropertyDefinitions){var a=raw.GetPropertyDefinition(p).GetAccessors();Add(a.Getter,2);Add(a.Setter,1);foreach(var h in a.Others)Add(h,4);}
        foreach(var e in raw.EventDefinitions){var a=raw.GetEventDefinition(e).GetAccessors();Add(a.Adder,8);Add(a.Remover,16);Add(a.Raiser,32);foreach(var h in a.Others)Add(h,4);}
        using var output=new StreamWriter(new FileStream(args[3],FileMode.CreateNew));var missing=0;var matched=0;
        foreach(var th in raw.TypeDefinitions){var owner=SignatureNames.Full(raw,th);if(!own.TryGetValue(owner,out var compiledOwner)||!actualOwners.Contains(compiledOwner))continue;foreach(var mh in raw.GetTypeDefinition(th).GetMethods()){
            var method=raw.GetMethodDefinition(mh);var canonical=originalNames.Method(raw,mh);var projected=methods.GetValueOrDefault(owner+"|"+canonical)??projectedNames.Method(raw,mh);
            if(actualMethods.Contains(compiledOwner+"|"+projected)){matched++;continue;}
            var name=raw.GetString(method.Name);output.WriteLine(JsonSerializer.Serialize(new{original_type=owner,compiled_type=compiledOwner,original_name=name,original_canonical_signature=canonical,expected_compiled_canonical_signature=projected,
                original_provider_method_token="0x"+MetadataTokens.GetToken(mh).ToString("x8"),original_attributes=(int)method.Attributes,original_impl_attributes=(int)method.ImplAttributes,original_semantics=semantic.GetValueOrDefault(mh),
                classification=name==".cctor"?"unrecovered-original-static-constructor":name==".ctor"?"unrecovered-original-instance-constructor":"unrecovered-original-method",no_body_invented=true}));missing++;
        }}
        Console.WriteLine("Matched "+matched+" original method identities; "+missing+" explicitly missing methods in emitted original types. No IL decoded or game code executed.");return 0;
    }
}
