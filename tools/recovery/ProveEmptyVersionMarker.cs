// One exact Roslyn syntax proof. This never compiles or loads inspected code.
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
static class ProveEmptyVersionMarker
{
 static void Need(bool b,string s){if(!b)throw new InvalidDataException(s);}
 static string Sha(string p)=>Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(p))).ToLowerInvariant();
 static void Check(string text){var tree=CSharpSyntaxTree.ParseText(text,new CSharpParseOptions(LanguageVersion.CSharp8));Need(!tree.GetDiagnostics().Any(d=>d.Severity==DiagnosticSeverity.Error),"Source syntax error");var root=tree.GetRoot();Need(!root.ContainsDirectives,"Conditional source not admitted");var types=root.DescendantNodes().OfType<TypeDeclarationSyntax>().ToArray();Need(types.Length==1&&types[0] is ClassDeclarationSyntax,"Exact one ordinary class required");var c=(ClassDeclarationSyntax)types[0];Need(c.Identifier.ValueText=="__BB_OBFUSCATOR_VERSION_3_8_2"&&c.Ancestors().OfType<NamespaceDeclarationSyntax>().Single().Name.ToString()=="PrivateImplementationDetailsKQPLETG","Exact original version marker identity differs");Need(c.Members.Count==0&&!c.DescendantNodes().OfType<ConstructorDeclarationSyntax>().Any()&&c.BaseList==null&&c.TypeParameterList==null,"Only exact zero-member class without constructor/base/generics admitted");Need(c.Modifiers.Count==1&&c.Modifiers[0].IsKind(SyntaxKind.PublicKeyword),"Original source class kind/modifiers differ");}
 public static int Main(string[] args){Need(args.Length==2&&!File.Exists(args[1]),"Source and fresh proof path required");var source=Path.GetFullPath(args[0]);var meta=source+".meta";var before=Sha(source);var metaBefore=Sha(meta);var text=File.ReadAllText(source);Check(text);int tests=0;foreach(var addition in new[]{"public __BB_OBFUSCATOR_VERSION_3_8_2() {}","public int a;","public void M() {}","static __BB_OBFUSCATOR_VERSION_3_8_2() {}"}){var at=text.LastIndexOf("\t}",StringComparison.Ordinal);Need(at>=0,"Exact class close absent");try{Check(text.Insert(at,addition));throw new Exception("Non-empty marker mutation accepted");}catch(InvalidDataException){tests++;}}Need(before==Sha(source)&&metaBefore==Sha(meta),"Source/meta drift");var match=Regex.Match(File.ReadAllText(meta),"(?m)^guid: ([a-f0-9]{32})\\r?$");Need(match.Success,"Exact script GUID absent");using var output=File.Create(args[1]);JsonSerializer.Serialize(output,new{schema="exact-zero-member-marker-source-proof/v1",original_type="PrivateImplementationDetailsKQPLETG.__BB_OBFUSCATOR_VERSION_3_8_2",source,source_sha256=before,meta,meta_sha256=metaBefore,script_guid=match.Groups[1].Value,roslyn_language_version="CSharp8",class_members=0,explicit_instance_constructors=0,explicit_static_constructors=0,base_type_clause_absent=true,generic_parameters_absent=true,conditional_directives_absent=true,negative_nonempty_source_mutations_rejected=tests,source_and_meta_bytes_unchanged=true,inspected_game_code_compiled_or_executed=false,project_modified=false},new JsonSerializerOptions{WriteIndented=true});return 0;}
}
