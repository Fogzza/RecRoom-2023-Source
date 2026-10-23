// Exact pinned definition bijection for two frozen prerequisite input assemblies.
// Does not relax semantic metadata, scoped operands, resources or body gates.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Mono.Cecil;
using RR23.MetadataRestoration;

static class PinnedPrerequisiteDefinitionMap
{
    static void Need(bool v,string m){if(!v)throw new InvalidDataException(m);}
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
    static string MethodKey(MethodReference m){return m.DeclaringType.FullName+"|"+CanonicalMetadataSignatures.Method(m);}
    public static Dictionary<uint,string> Capture(ModuleDefinition module)
    {
        var result=new Dictionary<uint,string>();
        Action<IMetadataTokenProvider,string> add=(row,key)=>{uint token=row.MetadataToken.ToUInt32();if((token&0x00ffffff)==0)return;Need(!result.ContainsKey(token),"Unique actual original/emitted definition token");result.Add(token,key);};
        foreach(var t in Types(module.Types))
        {
            add(t,"T|"+t.FullName);
            foreach(var g in t.GenericParameters)add(g,"G|T|"+t.FullName+"|"+g.Position);
            foreach(var f in t.Fields)add(f,"F|"+t.FullName+"|"+f.Name+"|"+CanonicalMetadataSignatures.Type(f.FieldType));
            foreach(var m in t.Methods)
            {
                string key=MethodKey(m);add(m,"M|"+key);
                foreach(var g in m.GenericParameters)add(g,"G|M|"+key+"|"+g.Position);
                add(m.MethodReturnType,"A|"+key+"|0");
                for(int i=0;i<m.Parameters.Count;i++)add(m.Parameters[i],"A|"+key+"|"+(i+1));
            }
            foreach(var p in t.Properties)add(p,"P|"+t.FullName+"|"+p.Name+"|"+CanonicalMetadataSignatures.Type(p.PropertyType)+"|"+string.Join(",",p.Parameters.Select(v=>CanonicalMetadataSignatures.Type(v.ParameterType))));
            foreach(var e in t.Events)add(e,"E|"+t.FullName+"|"+e.Name+"|"+CanonicalMetadataSignatures.Type(e.EventType));
        }
        return result;
    }
    public static void Verify(Dictionary<uint,string> before,ModuleDefinition emitted,JsonElement spec)
    {
        Need(spec.GetProperty("schema").GetString()=="exact-pinned-twelve-prerequisite-definition-bijection-zero-omissions/v1","Exact finite prerequisite map schema");
        Need(spec.GetProperty("omitted_empty_Param_tokens").GetArrayLength()==0,"ZERO omitted raw Param records authorized");
        var after=Capture(emitted);var oldSeen=new HashSet<uint>();var newSeen=new HashSet<uint>();var tables=spec.GetProperty("tables").EnumerateArray().ToArray();
        Need(tables.Select(t=>t.GetProperty("table").GetInt32()).SequenceEqual(new[]{2,4,6,8,20,23,42}),"Exactly seven definition tables");
        foreach(var table in tables)
        {
            uint t=table.GetProperty("table").GetUInt32();int count=table.GetProperty("original_count").GetInt32();var rows=table.GetProperty("rows").EnumerateArray().ToArray();
            Need(count==table.GetProperty("emitted_count").GetInt32()&&count==rows.Length&&before.Keys.Count(k=>k>>24==t)==count&&after.Keys.Count(k=>k>>24==t)==count,"Exact complete bijection counts, zero omissions/additions");
            foreach(var row in rows){uint a=row.GetProperty("original_token").GetUInt32(),b=row.GetProperty("emitted_token").GetUInt32();Need(a>>24==t&&b>>24==t&&oldSeen.Add(a)&&newSeen.Add(b)&&before.TryGetValue(a,out var x)&&after.TryGetValue(b,out var y)&&x==y,"Exact finite scoped identity and original/emitted row");}
        }
        Need(before.Count==oldSeen.Count&&before.Keys.All(oldSeen.Contains)&&after.Count==newSeen.Count&&after.Keys.All(newSeen.Contains),"Every original/emitted definition accounted for");
    }
}
