using System;using System.IO;using System.Linq;using System.Collections.Generic;using System.Text.Json;
using Microsoft.CodeAnalysis;using Microsoft.CodeAnalysis.CSharp;using Microsoft.CodeAnalysis.CSharp.Syntax;
static class Program
{
 static string Owner(INamedTypeSymbol n)=>(n.ContainingType!=null?Owner(n.ContainingType)+"/":n.ContainingNamespace.IsGlobalNamespace?"":n.ContainingNamespace.ToDisplayString()+".")+n.MetadataName;
 static string Type(ITypeSymbol t){if(t is IArrayTypeSymbol a){if(a.Rank!=1)throw new InvalidDataException("Unsupported nonvector source array");return Type(a.ElementType)+"[]";}if(t is IPointerTypeSymbol p)return Type(p.PointedAtType)+"*";if(t is ITypeParameterSymbol g)return "!"+g.Ordinal;if(t is not INamedTypeSymbol n||t.TypeKind==TypeKind.Error)throw new InvalidDataException("Unbound source type: "+t);var name=Owner(n);return n.IsGenericType?name+"<"+string.Join(",",n.TypeArguments.Select(Type))+">":name;}
 static object Value(TypedConstant c){if(c.Kind==TypedConstantKind.Type)return new{kind="Type",type=Type((ITypeSymbol)c.Value)};if(c.Kind==TypedConstantKind.Array)return new{kind="Array",values=c.Values.Select(Value)};return new{kind=c.Kind.ToString(),type=c.Type==null?null:Type(c.Type),value=c.Value};}
 static object[] Attributes(IEnumerable<AttributeData> a)=>a.Where(x=>x.AttributeClass?.ToDisplayString()=="System.Runtime.InteropServices.MarshalAsAttribute").Select(x=>(object)new{constructor=x.AttributeConstructor.ToDisplayString(),arguments=x.ConstructorArguments.Select(Value).ToArray(),named=x.NamedArguments.Select(p=>new{name=p.Key,value=Value(p.Value)}).ToArray(),syntax=x.ApplicationSyntaxReference?.GetSyntax().ToString()}).ToArray();
 static int Main(string[] args)
 {
  var config=JsonDocument.Parse(File.ReadAllText(args[0])).RootElement;var symbols=config.GetProperty("defines").EnumerateArray().Select(x=>x.GetString()).ToArray();var parse=new CSharpParseOptions(LanguageVersion.CSharp8,preprocessorSymbols:symbols);var trees=config.GetProperty("sources").EnumerateArray().Select(x=>x.GetString()).Select(p=>CSharpSyntaxTree.ParseText(File.ReadAllText(p),parse,p)).ToArray();var refs=config.GetProperty("references").EnumerateArray().Select(x=>MetadataReference.CreateFromFile(x.GetString()));var compilation=CSharpCompilation.Create("OfficialOpenVrSource",trees,refs,new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,allowUnsafe:true));var fields=new List<object>();var methods=new List<object>();
  foreach(var tree in trees)
  {
   var model=compilation.GetSemanticModel(tree);
   foreach(var node in tree.GetRoot().DescendantNodes().OfType<FieldDeclarationSyntax>())foreach(var variable in node.Declaration.Variables){var f=(IFieldSymbol)model.GetDeclaredSymbol(variable);var attrs=Attributes(f.GetAttributes());if(attrs.Length>0)fields.Add(new{owner=Owner(f.ContainingType),name=f.Name,type=Type(f.Type),marshal=attrs,path=tree.FilePath,line=tree.GetLineSpan(node.Span).StartLinePosition.Line+1,source=node.ToString()});}
   foreach(var node in tree.GetRoot().DescendantNodes().Where(n=>n is MethodDeclarationSyntax||n is DelegateDeclarationSyntax))
   {
    IMethodSymbol m;string kind;
    if(node is DelegateDeclarationSyntax d){m=((INamedTypeSymbol)model.GetDeclaredSymbol(d)).DelegateInvokeMethod;kind="delegate_Invoke";}else{m=(IMethodSymbol)model.GetDeclaredSymbol(node);kind="method";}
    var returns=Attributes(m.GetReturnTypeAttributes());var parameters=m.Parameters.Select(p=>new{sequence=p.Ordinal+1,name=p.Name,type=Type(p.Type)+(p.RefKind==RefKind.None?"":"&"),marshal=Attributes(p.GetAttributes())}).ToArray();if(returns.Length==0&&!parameters.Any(p=>p.marshal.Length>0))continue;
    methods.Add(new{owner=Owner(m.ContainingType),name=m.Name,kind,return_type=Type(m.ReturnType),return_marshal=returns,parameters,path=tree.FilePath,line=tree.GetLineSpan(node.Span).StartLinePosition.Line+1,source=node.ToString()});
   }
  }
  var errors=compilation.GetDiagnostics().Where(d=>d.Severity==DiagnosticSeverity.Error).Select(d=>d.ToString()).ToArray();File.WriteAllText(args[1],JsonSerializer.Serialize(new{schema="official-openvr-semantic-marshal-ownership/v1",fields,methods,semantic_errors=errors},new JsonSerializerOptions{WriteIndented=true}));return errors.Length==0?0:2;
 }
}
