// Inspect pinned decompiler IL and original/compiled event/field metadata only.
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using RR23.MetadataRestoration;
static class InspectDecompilerEventCollision
{
 static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types){foreach(var type in types){yield return type;foreach(var child in Walk(type.NestedTypes))yield return child;}}
 static object Describe(TypeDefinition t)=>new{owner=t.FullName,fields=t.Fields.Select(f=>new{name=f.Name,canonical_type=CanonicalMetadataSignatures.Type(f.FieldType),token="0x"+f.MetadataToken.ToUInt32().ToString("x8"),flags=(uint)f.Attributes,attributes=f.CustomAttributes.Select(a=>new{name=a.AttributeType.FullName,blob=Convert.ToHexString(a.GetBlob()).ToLowerInvariant()}).ToArray()}).ToArray(),events=t.Events.Select(e=>new{name=e.Name,canonical_type=CanonicalMetadataSignatures.Type(e.EventType),token="0x"+e.MetadataToken.ToUInt32().ToString("x8"),add=e.AddMethod?.FullName,remove=e.RemoveMethod?.FullName}).ToArray()};
 public static int Main(string[] args){if(args.Length!=4||File.Exists(args[3]))throw new InvalidDataException("Decompiler,raw,actual,fresh output required");var methods=new List<object>();using(var decompiler=AssemblyDefinition.ReadAssembly(args[0])){foreach(var type in Walk(decompiler.MainModule.Types))foreach(var method in type.Methods.Where(m=>m.HasBody&&m.Body.Instructions.Any(i=>i.OpCode==OpCodes.Ldstr&&Equals(i.Operand,"m_")))){if(method.Body.Instructions.Count>4096)throw new InvalidDataException("Unexpected tool method bound");methods.Add(new{method=method.FullName,token="0x"+method.MetadataToken.ToUInt32().ToString("x8"),instructions=method.Body.Instructions.Select(i=>new{offset=i.Offset,opcode=i.OpCode.Name,operand=i.Operand is Instruction target?"IL_"+target.Offset.ToString("x4"):i.Operand?.ToString()}).ToArray()});}}var owners=new[]{"Steamworks.Callback`1","Steamworks.CallResult`1"};var inventories=new List<object>();for(int pass=1;pass<=2;pass++){using var assembly=AssemblyDefinition.ReadAssembly(args[pass]);inventories.Add(new{source=args[pass],types=Walk(assembly.MainModule.Types).Where(t=>owners.Contains(t.FullName)).Select(Describe).ToArray()});}File.WriteAllText(args[3],JsonSerializer.Serialize(new{schema="pinned-decompiler-event-collision-metadata-IL-inspection/v1",decompiler_m_prefix_methods=methods,field_event_inventories=inventories,project_modified=false,game_code_executed=false},new JsonSerializerOptions{WriteIndented=true}));Console.WriteLine("Pinned tool m_ IL methods="+methods.Count+"; original and actual owner inventories emitted.");return 0;}
}
