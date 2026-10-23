// Changes source hashes/paths only after proving every declaration contract equal.
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Security.Cryptography;
using System.Collections.Generic;
static class RebaseBodySourceProjection
{
 static void Need(bool value,string reason){if(!value)throw new InvalidDataException(reason);}
 static string Sha(string path){using var f=File.OpenRead(path);return Convert.ToHexString(SHA256.HashData(f)).ToLowerInvariant();}
 static string Value(JsonElement value)=>JsonSerializer.Serialize(value);
 static int Main(string[] args)
 {
  Need(args.Length==4&&!Directory.Exists(args[3]),"whole-source-plan partial-source-plan applied-body-journal fresh-output-folder");Directory.CreateDirectory(args[3]);
  using var before=JsonDocument.Parse(File.OpenRead(args[0]));using var partial=JsonDocument.Parse(File.OpenRead(args[1]));using var application=JsonDocument.Parse(File.OpenRead(args[2]));
  var old=before.RootElement;var next=partial.RootElement;var applied=application.RootElement;
  bool whole=old.TryGetProperty("source_projection_scope",out var oldScope)?oldScope.GetProperty("kind").GetString()=="whole-assembly":
    Sha(args[0])=="134970adfa7af635a99deedda72411104f1ea96618ad05d3c8a50e3f4655e1f1"&&old.GetProperty("source_type_inventory").GetArrayLength()==12408;
  Need(whole&&next.GetProperty("source_projection_scope").GetProperty("kind").GetString()=="partial-explicit-files","Whole baseline and explicit partial projection required");
  Need(applied.GetProperty("status").GetString()=="applied"&&applied.GetProperty("method_bodies").GetInt32()==7&&applied.GetProperty("source_metadata_unchanged").GetBoolean(),"Applied seven-body transaction required");
  var unchanged=new List<object>();
  foreach(string key in new[]{"types","all_field_identity_mappings","source_type_inventory","event_projections","additional_method_access_projections","additional_field_access_projections","additional_method_identity_projections","property_return_attribute_projections"})
  {
   var subset=next.GetProperty(key).EnumerateArray().ToArray();if(subset.Length==0){unchanged.Add(new{key,checked_rows=0});continue;}
   string identity=key=="all_field_identity_mappings"?"original_type":"original_full_name";
   var ownerNames=new HashSet<string>(subset.Select(r=>r.GetProperty(identity).GetString()),StringComparer.Ordinal);
   var wanted=new HashSet<string>(subset.Select(Value),StringComparer.Ordinal);var found=new HashSet<string>(StringComparer.Ordinal);
   foreach(var row in old.GetProperty(key).EnumerateArray())
   {if(!ownerNames.Contains(row.GetProperty(identity).GetString()))continue;var serialized=Value(row);if(wanted.Contains(serialized))found.Add(serialized);}
   Need(found.SetEquals(wanted),"Partial projection changed declaration contracts: "+key);unchanged.Add(new{key,checked_rows=subset.Length});
  }
  Need(Value(old.GetProperty("all_type_identity_mappings"))==Value(next.GetProperty("all_type_identity_mappings")),"Original type aliases changed");
  var replacements=next.GetProperty("source_replacements").EnumerateArray().ToDictionary(e=>e.GetProperty("project_relative_path").GetString(),StringComparer.Ordinal);
  Need(replacements.Count==2,"Expected two syntax-projected files; Revive remains a direct source");var written=new HashSet<string>(StringComparer.Ordinal);int count=0;
  string target=Path.Combine(args[3],"metadata-restoration.json");
  using(var stream=File.Create(target))using(var writer=new Utf8JsonWriter(stream,new JsonWriterOptions{Indented=true}))
  {
   writer.WriteStartObject();foreach(var property in old.EnumerateObject())
   {
    writer.WritePropertyName(property.Name);
    if(property.Name!="source_replacements"){property.Value.WriteTo(writer);continue;}
    writer.WriteStartArray();foreach(var row in property.Value.EnumerateArray())
    {
     string path=row.GetProperty("project_relative_path").GetString();
     if(replacements.TryGetValue(path,out var replacement)){replacement.WriteTo(writer);Need(written.Add(path),"Duplicate baseline source replacement");}
     else row.WriteTo(writer);count++;
    }
    writer.WriteEndArray();
   }
   writer.WritePropertyName("native_body_rebase");JsonSerializer.Serialize(writer,new{baseline=new{path=Path.GetFullPath(args[0]),sha256=Sha(args[0])},partial_projection=new{path=Path.GetFullPath(args[1]),sha256=Sha(args[1])},source_application=new{path=Path.GetFullPath(args[2]),sha256=Sha(args[2])},method_bodies=7,declaration_contracts_unchanged=true,checked_declaration_arrays=unchanged});writer.WriteEndObject();
  }
  Need(written.SetEquals(replacements.Keys),"A partial projection was absent from the full plan");
  Need(new FileInfo(target).Length>0&&count==old.GetProperty("source_replacements").GetArrayLength(),"Whole source replacement coverage changed");
  var report=new{schema="whole-source-plan-native-body-rebase/v1",status="passed",source_replacements=count,updated_source_replacements=written.OrderBy(x=>x).ToArray(),method_bodies=7,whole_assembly_coverage_preserved=true,all_type_aliases_unchanged=true,declaration_contracts_unchanged=true,checked_arrays=unchanged,projection=new{path=target,sha256=Sha(target)},game_code_executed=false,project_modified=false};
  File.WriteAllText(Path.Combine(args[3],"report.json"),JsonSerializer.Serialize(report,new JsonSerializerOptions{WriteIndented=true}));Console.WriteLine("Full source plan rebased with unchanged declaration contracts: "+count+" replacements.");return 0;
 }
}
