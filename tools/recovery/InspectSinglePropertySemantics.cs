using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using Mono.Cecil;
static class InspectSinglePropertySemantics
{
 static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types){foreach(var t in types){yield return t;foreach(var child in Walk(t.NestedTypes))yield return child;}}
 static object Method(MethodDefinition m)=>new{name=m.Name,token="0x"+m.MetadataToken.ToUInt32().ToString("x8"),flags=(uint)m.Attributes,impl_flags=(uint)m.ImplAttributes,semantics=(uint)m.SemanticsAttributes,signature=m.FullName};
 public static int Main(string[] args){if(args.Length!=2||File.Exists(args[1]))throw new InvalidDataException();using var a=AssemblyDefinition.ReadAssembly(args[0],new ReaderParameters{ReadingMode=ReadingMode.Deferred});var t=Walk(a.MainModule.Types).Single(x=>x.FullName=="DJDADKAAOLE");var method=t.Methods.Single(m=>m.Name=="PGNPFMMCBMF");var first=Method(method);var properties=t.Properties.Select(p=>new{name=p.Name,token="0x"+p.MetadataToken.ToUInt32().ToString("x8"),get=p.GetMethod==null?null:Method(p.GetMethod),set=p.SetMethod==null?null:Method(p.SetMethod),getter_is_exact_raw_target=ReferenceEquals(p.GetMethod,method)}).ToArray();var after=Method(method);File.WriteAllText(args[1],JsonSerializer.Serialize(new{before_explicit_property_enumeration=first,after_property_enumeration=after,properties,project_modified=false,game_code_executed=false},new JsonSerializerOptions{WriteIndented=true}));return 0;}
}
