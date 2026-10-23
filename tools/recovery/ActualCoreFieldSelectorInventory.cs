// Read metadata only. Every candidate selector remains explicit; no name-only acceptance.
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using Mono.Cecil;
using RR23.MetadataRestoration;

static class ActualCoreFieldSelectorInventory
{
 static void Need(bool ok,string message){if(!ok)throw new InvalidDataException(message);}
 static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types){foreach(var type in types){yield return type;foreach(var child in Walk(type.NestedTypes))yield return child;}}
 static string Key(string assembly,string name)=>assembly+"\0"+name;
 public static int Main(string[] args){Need(args.Length==5&&!File.Exists(args[3])&&!File.Exists(args[4]),"Raw,actual,typeAliasesJSONL,freshRawJSONL,freshActualJSONL required");var aliases=new Dictionary<string,string>();foreach(var line in File.ReadLines(args[2])){using var document=JsonDocument.Parse(line);var row=document.RootElement;Need(aliases.TryAdd(Key(row.GetProperty("assembly").GetString()!,row.GetProperty("original_full_name").GetString()!),row.GetProperty("compiled_full_name").GetString()!),"Duplicate type alias");}string Project(TypeReference type){var key=Key(CanonicalMetadataSignatures.Assembly(type),type.FullName);return aliases.TryGetValue(key,out var name)?name:type.FullName;}
  for(int pass=0;pass<2;pass++){using var assembly=AssemblyDefinition.ReadAssembly(args[pass],new ReaderParameters{ReadingMode=ReadingMode.Deferred});Need(assembly.Name.Name=="Assembly-CSharp","Original core identity required");using var output=new StreamWriter(args[3+pass],false,new UTF8Encoding(false));foreach(var type in Walk(assembly.MainModule.Types)){if(type.Namespace.Equals("Cpp2ILInjected",StringComparison.OrdinalIgnoreCase))continue;foreach(var field in type.Fields){string? projected=null,error=null;if(pass==0){try{projected=ProjectedCanonicalSignatures.Type(field.FieldType,Project);}catch(Exception e){error=e.GetType().Name+":"+e.Message;}}output.WriteLine(JsonSerializer.Serialize(new{owner=type.FullName,name=field.Name,type=field.FieldType.FullName,canonical_type=CanonicalMetadataSignatures.Type(field.FieldType),projected_canonical_type=projected,cli_token="0x"+field.MetadataToken.ToUInt32().ToString("x8"),flags=(uint)field.Attributes,error}));}}}
  Console.WriteLine("Read-only actual/raw scoped field selectors emitted; no definitions or TypeSpecs changed.");return 0;
 }
}
