// Exact finite metadata-row amendment for one frozen original URP assembly.
// Does not relax semantic metadata, scoped operands, resources or body gates.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Mono.Cecil;
using RR23.MetadataRestoration;

static class FiniteOriginalDefinitionReindex
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
        Need(spec.GetProperty("schema").GetString()=="exact-frozen-URP-definition-reindex-and-four-empty-Param-omissions/v1","Only explicit finite reindex schema");
        var after=Capture(emitted);var oldSeen=new HashSet<uint>();var newSeen=new HashSet<uint>();
        var tables=spec.GetProperty("tables").EnumerateArray().ToArray();
        Need(tables.Select(t=>t.GetProperty("table").GetInt32()).SequenceEqual(new[]{2,4,6,8,20,23,42}),"Exact seven definition tables including Param, Property, Event and generic ownership");
        foreach(var table in tables)
        {
            uint id=table.GetProperty("table").GetUInt32();var rows=table.GetProperty("rows").EnumerateArray().ToArray();
            int originalCount=table.GetProperty("original_count").GetInt32(),emittedCount=table.GetProperty("emitted_count").GetInt32();
            Need(before.Keys.Count(t=>t>>24==id)==originalCount&&after.Keys.Count(t=>t>>24==id)==emittedCount,"Exact pinned per-table original/emitted definition counts");
            Need(rows.Length==emittedCount,"Entire finite emitted definition bijection enumerated");
            foreach(var row in rows)
            {
                uint oldToken=row.GetProperty("original_token").GetUInt32(),newToken=row.GetProperty("emitted_token").GetUInt32();
                Need(oldToken>>24==id&&newToken>>24==id&&oldSeen.Add(oldToken)&&newSeen.Add(newToken),"Finite map token table/range uniqueness");
                Need(before.TryGetValue(oldToken,out var a)&&after.TryGetValue(newToken,out var b)&&a==b,"Exact original full owner/scoped definition identity at its one explicitly authorized emitted token");
            }
        }
        var omissions=spec.GetProperty("omitted_empty_Param_tokens").EnumerateArray().Select(v=>v.GetUInt32()).ToArray();
        Need(omissions.SequenceEqual(new uint[]{0x080002d3,0x080004ad,0x080004ae,0x080004af}),"Only four proven original unnamed ordinary Param records may be absent");
        foreach(uint token in omissions)
        {
            Need(oldSeen.Add(token)&&before.TryGetValue(token,out var key)&&!after.Values.Contains(key),"Exact omitted raw Param row, signature slot remains semantic fingerprint authority");
        }
        Need(before.Count==oldSeen.Count&&before.Keys.All(oldSeen.Contains)&&after.Count==newSeen.Count&&after.Keys.All(newSeen.Contains),"Every original and emitted actual definition row accounted for; no other row drop/add/reorder acceptance");
    }
}
