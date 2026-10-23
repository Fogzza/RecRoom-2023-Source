// Real production resolver and exact updated inventory; metadata-only fixture.
// No inspected SDK/game assembly is ever loaded by the CLR or invoked.
using System;using System.IO;using System.Linq;using System.Text.Json;using System.Collections.Generic;using Mono.Cecil;using RR23.MetadataRestoration;
static class RuntimeMetadataPinUpdateFixture
{
    static void Need(bool v,string m){if(!v)throw new InvalidDataException(m);}
    static readonly Dictionary<string,string> Old=new Dictionary<string,string>(StringComparer.Ordinal)
    {
        {"RecRoom.AgInitialization.Runtime","c24b477ce06386978e451bf0d288b9238bfda95403f5231b9e96ffa3f63045e6"},
        {"RecRoom.Datastructures.Singletons.Runtime","5c58d338afe2c0d8887291d8572fa8dc34c18b551a9f3c17b2e8a88558752668"},
        {"UJect.Runtime","e86cc2f7c05eb5b7dec176443edff813bd96c1e56f87bcf3a3d7672558ba0a2b"}
    };
    static readonly Dictionary<string,string> Current=new Dictionary<string,string>(StringComparer.Ordinal)
    {
        {"RecRoom.AgInitialization.Runtime","a23ba0d28cd224d0a81f553dd6fce8388199c3bffdfcba95e88ff4e94ef29b04"},
        {"RecRoom.Datastructures.Singletons.Runtime","39911ee1855adbae84037c5c08108ba2583d5627817b947d010b5ad9b80db15b"},
        {"UJect.Runtime","11d68c9f488ef1338f79188d9289a0747be5f398a298703c81080c60a61aff7e"}
    };
    static void RejectConstructor(string[] supplied,CuratedRuntimeMetadataReference[] values,string expectedName)
    {
        bool rejected=false;try{using(var resolver=new ExactMetadataReferenceResolver(supplied,values)){} }catch(InvalidDataException e){Need(e.Message=="Curated original runtime reference bytes changed: "+expectedName,"Negative control reached actual production byte-hash gate for exact named DLL");rejected=true;}Need(rejected,"Stale or mutated curated pin must fail closed");
    }
    static int Main(string[] args)
    {
        Need(args.Length==2&&!File.Exists(args[1]),"Exact metadata spec/fresh result only");using var doc=JsonDocument.Parse(File.ReadAllBytes(args[0]));var input=doc.RootElement;Need(input.GetProperty("schema").GetString()=="exact-three-tested-runtime-reference-pin-fixture-input/v1","Exact fixture schema");var rows=input.GetProperty("references").EnumerateArray().ToArray();var values=OriginalRuntimeMetadataReferenceInputs.Values;Need(rows.Length==225&&values.Length==225&&values.Select(x=>x.Name).Distinct(StringComparer.Ordinal).Count()==225,"Exact unchanged finite225 runtime inventory");
        for(int n=0;n<rows.Length;n++){Need(rows[n].GetProperty("name").GetString()==values[n].Name&&rows[n].GetProperty("sha256").GetString()==values[n].Sha256,"Actual production candidate inventory/order exactly equals frozen expected input");if(Current.ContainsKey(values[n].Name))Need(values[n].Sha256==Current[values[n].Name],"Only three literal recovered-body checkpoints");}
        string[] facades=rows.Select(x=>x.GetProperty("facade_path").GetString()).ToArray();Need(facades.All(File.Exists),"Actual existing225 CompilerSupport facade files");int resolved=0;var output=new List<object>();
        using(var resolver=new ExactMetadataReferenceResolver(facades,values))
        {
            foreach(var row in rows)
            {
                var name=AssemblyNameReference.Parse(row.GetProperty("full_name").GetString());var assembly=resolver.Resolve(name);string expected=Path.GetFullPath(row.GetProperty("runtime_path").GetString());Need(assembly.Name.FullName==name.FullName&&Path.GetFullPath(assembly.MainModule.FileName)==expected,"Real resolver selected exact original runtime metadata path/identity after facade remap");Need(Object.ReferenceEquals(assembly,resolver.Resolve(name)),"Exact requested-identity metadata cache reuse");output.Add(new{name=name.FullName,path=assembly.MainModule.FileName});resolved++;
            }
            var first=rows[0];var wrong=AssemblyNameReference.Parse(first.GetProperty("full_name").GetString());wrong.Version=new Version(99,0,0,0);bool rejected=false;try{resolver.Resolve(wrong);}catch(InvalidDataException e){Need(e.Message.StartsWith("Exact metadata reference identity differs: requested ",StringComparison.Ordinal),"Real identity gate");rejected=true;}Need(rejected,"Wrong requested metadata identity remains rejected");
        }
        foreach(var old in Old){var bad=values.Select(x=>new CuratedRuntimeMetadataReference(x.Name,x.Name==old.Key?old.Value:x.Sha256)).ToArray();RejectConstructor(facades,bad,old.Key);}
        string unchanged=values[0].Name;Need(!Current.ContainsKey(unchanged),"Mutate an unchanged inventory row");var changed=values.Select(x=>new CuratedRuntimeMetadataReference(x.Name,x.Name==unchanged?(x.Sha256[0]=='0'?"1":"0")+x.Sha256.Substring(1):x.Sha256)).ToArray();RejectConstructor(facades,changed,unchanged);
        Need(resolved==225,"All225 actual runtime metadata identities resolved");var result=new{schema="actual-production-resolver-exact-three-pin-update-fixture/v1",status="all225_original_runtime_metadata_hashes_facade_remaps_and_identities_verified_old3_and_mutated_pin_rejected",resolved_original_runtime_references=resolved,old_three_individual_pins_rejected=3,unchanged_row_mutated_pin_rejected=true,wrong_requested_assembly_identity_rejected=true,actual_production_resolver_source_used_unchanged=true,actual_candidate_inventory_source_used=true,inspected_SDK_or_game_code_executed=false,Main_modified=false,resolved=output};File.WriteAllText(args[1],JsonSerializer.Serialize(result,new JsonSerializerOptions{WriteIndented=true})+"\n");Console.WriteLine("RESULT225 real resolver remaps/identities; old3 pins, changed unrelated pin and wrong identity rejected. No SDK execution.");return 0;
    }
}
