using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
static class VerifyBodyDeclarations
{
 sealed class Bodies:CSharpSyntaxRewriter
 {
  public override SyntaxNode VisitBlock(BlockSyntax n)=>SyntaxFactory.Block();
  public override SyntaxNode VisitArrowExpressionClause(ArrowExpressionClauseSyntax n)=>SyntaxFactory.ArrowExpressionClause(SyntaxFactory.LiteralExpression(SyntaxKind.DefaultLiteralExpression));
 }
 static string Canonical(string text)
 {var tree=CSharpSyntaxTree.ParseText(text,new CSharpParseOptions(LanguageVersion.CSharp8));if(tree.GetDiagnostics().Any(d=>d.Severity==DiagnosticSeverity.Error))throw new InvalidDataException("Source syntax error");return new Bodies().Visit(tree.GetRoot()).WithoutTrivia().NormalizeWhitespace().ToFullString();}
 static void Need(bool value,string why){if(!value)throw new InvalidDataException(why);}
 static string Hash(string text)=>Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(text))).ToLowerInvariant();
 static int Main(string[] args)
 {
  string sample="class A:B { public int F; public int M(int p) { return 0; } }";
  Need(Canonical(sample)==Canonical(sample.Replace("return 0;","int x=2; return p+x;")),"Body-only positive control");
  foreach(var changed in new[]{sample.Replace("int F","float F"),sample.Replace("int p","float p"),sample.Replace("A:B","A:C"),sample.Replace("int M","int N")})Need(Canonical(sample)!=Canonical(changed),"Declaration mutation accepted");
  Need(args.Length==2&&!File.Exists(args[1]),"input-pairs.json fresh-result.json");using var input=JsonDocument.Parse(File.ReadAllText(args[0]));
  var rows=input.RootElement.EnumerateArray().Select(p=>{string before=p.GetProperty("before").GetString(),after=p.GetProperty("after").GetString();var a=Canonical(File.ReadAllText(before));var b=Canonical(File.ReadAllText(after));Need(a==b,"Declaration difference in "+before);return new{before,after,declaration_sha256=Hash(a),equal=true};}).ToArray();
  Need(rows.Length==3,"Exactly three source files required");File.WriteAllText(args[1],JsonSerializer.Serialize(new{schema="body-only-source-declaration-equivalence/v1",status="passed",rows,negative_declaration_controls=4,positive_body_control=true,game_code_executed=false},new JsonSerializerOptions{WriteIndented=true}));return 0;
 }
}
