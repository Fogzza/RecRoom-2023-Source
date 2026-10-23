// Stage genuine matching SDK bodies only. Never execute an inspected assembly.
// This intentionally does not replace the SDK, add declarations, or repair its
// Rec Room-specific callback/context infrastructure by guessing.
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.Json;
using Mono.Cecil;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal static class Steamworks14SourceBodyStage
{
    static void Need(bool b,string m){if(!b)throw new InvalidDataException(m);}
    static string Sha(string p){using var s=File.OpenRead(p);return Convert.ToHexString(SHA256.HashData(s)).ToLowerInvariant();}
    static IEnumerable<TypeDefinition> All(IEnumerable<TypeDefinition> ts){foreach(var t in ts){yield return t;foreach(var n in All(t.NestedTypes))yield return n;}}
    static string Scope(TypeReference t){var s=t.Scope is AssemblyNameReference a?a.Name:t.Module.Assembly.Name.Name;return s=="OfficialSteamworks14"?"Assembly-CSharp":s;}
    static string T(TypeReference t)
    {
        if(t==null)return "-";
        if(t is GenericParameter gp)return(gp.Type==GenericParameterType.Method?"!!":"!")+gp.Position;
        if(t is GenericInstanceType g)return T(g.ElementType)+"<"+string.Join(",",g.GenericArguments.Select(T))+">";
        if(t is ArrayType ar){Need(ar.IsVector,"Only exact original SZ arrays supported");return T(ar.ElementType)+"[: ]".Replace(" ","");}
        if(t is ByReferenceType br)return T(br.ElementType)+"&";
        if(t is PointerType pt)return T(pt.ElementType)+"*";
        Need(!(t is TypeSpecification),"Unsupported modified/pinned/function-pointer TypeSpec");
        return "["+Scope(t)+"]"+t.FullName;
    }
    static string Owner(TypeReference t)=>t is GenericInstanceType g?g.ElementType.FullName:t.FullName;
    static string M(MethodReference m)=>m.Name+"``"+m.GenericParameters.Count+"("+string.Join(",",m.Parameters.Select(p=>T(p.ParameterType)))+")->"+T(m.ReturnType);
    static string MK(MethodReference m)=>Owner(m.DeclaringType)+"|"+M(m);
    static string FK(FieldReference f)=>Owner(f.DeclaringType)+"|"+f.Name+"|"+T(f.FieldType);
    static string O(INamedTypeSymbol t)=>(t.ContainingType==null?(t.ContainingNamespace.IsGlobalNamespace?"":t.ContainingNamespace.ToDisplayString()+"."):O(t.ContainingType)+"/")+t.MetadataName;
    static string S(ITypeSymbol t)
    {
        if(t is IArrayTypeSymbol a){Need(a.Rank==1&&a.IsSZArray,"Nonvector source array unsupported");return S(a.ElementType)+"[:]";}
        if(t is IPointerTypeSymbol p)return S(p.PointedAtType)+"*";
        if(t is ITypeParameterSymbol g)return(g.TypeParameterKind==TypeParameterKind.Method?"!!":"!")+g.Ordinal;
        Need(t is INamedTypeSymbol&&t.TypeKind!=TypeKind.Error,"Unbound source type:"+t);
        var n=(INamedTypeSymbol)t;var assembly=n.ContainingAssembly.Identity.Name;
        if(assembly=="OfficialSteamworks14Source"||assembly=="FrozenSteamworksTargetSource")assembly="Assembly-CSharp";
        string r="["+assembly+"]"+O(n.OriginalDefinition);
        if(n.IsGenericType)r+="<"+string.Join(",",n.TypeArguments.Select(S))+">";
        return r;
    }
    static string MS(IMethodSymbol m)=>m.MetadataName+"``"+m.Arity+"("+string.Join(",",m.Parameters.Select(p=>S(p.Type)+(p.RefKind==RefKind.None?"":"&")))+")->"+S(m.ReturnType)+(m.ReturnsByRef||m.ReturnsByRefReadonly?"&":"");
    static string Const(FieldDefinition f)=>f.HasConstant?(f.Constant==null?"null":f.Constant.GetType().FullName+":"+Convert.ToString(f.Constant,CultureInfo.InvariantCulture)):"-";
    sealed class Node
    {
        public string Key,Path;public SyntaxNode Declaration;public SyntaxNode ReplaceNode;public BlockSyntax Body;public IMethodSymbol Symbol;public SemanticModel Model;
        public int Start,Length;public string Old,New;public ConstructorInitializerSyntax Initializer;
    }
    sealed class Candidate
    {
        public string Key;public MethodDefinition Source,Target;public JsonElement Native;public Node SourceNode,TargetNode;
        public SortedSet<string> Issues=new(StringComparer.Ordinal),Dependencies=new(StringComparer.Ordinal);
    }
    static Dictionary<string,Node> Nodes(CSharpCompilation c)
    {
        var result=new Dictionary<string,Node>(StringComparer.Ordinal);
        foreach(var tree in c.SyntaxTrees){var model=c.GetSemanticModel(tree);foreach(var node in tree.GetRoot().DescendantNodes()){
            IMethodSymbol symbol=null;BlockSyntax body=null;SyntaxNode replacement=null;ConstructorInitializerSyntax initializer=null;
            if(node is BaseMethodDeclarationSyntax b){symbol=model.GetDeclaredSymbol(b)as IMethodSymbol;body=b.Body;initializer=(b as ConstructorDeclarationSyntax)?.Initializer;if(b.ExpressionBody!=null){body=Expr(symbol,b.ExpressionBody.Expression);replacement=b.ExpressionBody;}else replacement=body;}
            else if(node is AccessorDeclarationSyntax a){symbol=model.GetDeclaredSymbol(a)as IMethodSymbol;body=a.Body;if(a.ExpressionBody!=null){body=Expr(symbol,a.ExpressionBody.Expression);replacement=a.ExpressionBody;}else replacement=body;}
            else if(node is PropertyDeclarationSyntax p&&p.ExpressionBody!=null){var property=model.GetDeclaredSymbol(p);symbol=property?.GetMethod;body=Expr(symbol,p.ExpressionBody.Expression);replacement=p.ExpressionBody;}
            else continue;
            if(symbol==null||body==null||replacement==null||!O(symbol.ContainingType).StartsWith("Steamworks.",StringComparison.Ordinal))continue;
            string key;try{key=O(symbol.ContainingType)+"|"+MS(symbol);}catch(InvalidDataException){continue;}
            Need(!result.ContainsKey(key),"Duplicate source method definition:"+key);
            result.Add(key,new Node{Key=key,Path=tree.FilePath,Declaration=node,ReplaceNode=replacement,Body=body,Symbol=symbol,Model=model,Initializer=initializer});
        }}return result;
    }
    static BlockSyntax Expr(IMethodSymbol m,ExpressionSyntax e)=>SyntaxFactory.Block(m!=null&&m.ReturnsVoid?SyntaxFactory.ExpressionStatement(e):SyntaxFactory.ReturnStatement(e));
    static bool Zero(ExpressionSyntax e)
    {
        e=e is ParenthesizedExpressionSyntax par?par.Expression:e;
        if(e is DefaultExpressionSyntax||e.IsKind(SyntaxKind.DefaultLiteralExpression)||e.IsKind(SyntaxKind.NullLiteralExpression)||e.IsKind(SyntaxKind.FalseLiteralExpression))return true;
        if(e is LiteralExpressionSyntax lit&&lit.Token.Value!=null){try{return Convert.ToDecimal(lit.Token.Value,CultureInfo.InvariantCulture)==0;}catch{return false;}}
        if(e is CastExpressionSyntax cast)return Zero(cast.Expression);
        return false;
    }
    static bool Stub(Node n)
    {
        foreach(var s in n.Body.Statements){
            if(s is ReturnStatementSyntax r&&r.Expression!=null&&Zero(r.Expression))continue;
            if(s is ExpressionStatementSyntax es&&es.Expression is AssignmentExpressionSyntax a&&a.IsKind(SyntaxKind.SimpleAssignmentExpression)&&Zero(a.Right)){
                var bound=n.Model.GetSymbolInfo(a.Left).Symbol as IFieldSymbol;if(bound!=null&&!bound.IsStatic&&SymbolEqualityComparer.Default.Equals(bound.ContainingType,n.Symbol.ContainingType))continue;
            }
            return false;
        }return true;
    }
    static string PInvoke(MethodDefinition m)=>m.HasPInvokeInfo?m.PInvokeInfo.Module.Name+"|"+m.PInvokeInfo.EntryPoint+"|"+(int)m.PInvokeInfo.Attributes:"-";
    static object Ref(string path)=>new{path=Path.GetFullPath(path),sha256=Sha(path)};
    static HashSet<string> Close(HashSet<string> eligible,Dictionary<string,SortedSet<string>> deps,HashSet<string> terminals)
    {
        var accepted=new HashSet<string>(eligible,StringComparer.Ordinal);bool changed;
        do{changed=false;foreach(var key in accepted.ToArray())if(deps[key].Any(d=>!accepted.Contains(d)&&!terminals.Contains(d))){accepted.Remove(key);changed=true;}}while(changed);
        return accepted;
    }
    static int Fixtures(string framework,string output)
    {
        var cases=new List<string>();void Check(bool ok,string label){Need(ok,"Fixture failed:"+label);cases.Add(label);}
        using var module=ModuleDefinition.CreateModule("Fixture",ModuleKind.Dll);var a=new AssemblyNameReference("A",new Version(1,0));var b=new AssemblyNameReference("B",new Version(1,0));
        var ta=new TypeReference("N","Same",module,a);var tb=new TypeReference("N","Same",module,b);Check(T(ta)!=T(tb),"same-fullname-wrong-assembly-refused");
        Check(T(new ByReferenceType(module.TypeSystem.Int32))!=T(module.TypeSystem.Int32),"byref-and-value-differ");
        var owner=new TypeDefinition("N","G`2",TypeAttributes.Public);owner.GenericParameters.Add(new GenericParameter("X",owner));owner.GenericParameters.Add(new GenericParameter("Y",owner));var method=new MethodDefinition("M",MethodAttributes.Public,module.TypeSystem.Void);method.GenericParameters.Add(new GenericParameter("X",method));
        Check(T(owner.GenericParameters[0])!=T(owner.GenericParameters[1]),"generic-position-not-parameter-name");Check(T(owner.GenericParameters[0])!=T(method.GenericParameters[0]),"generic-owner-type-vs-method");
        try{T(new ArrayType(module.TypeSystem.Int32,2));throw new Exception("accepted array");}catch(InvalidDataException){cases.Add("nonvector-array-refused");}
        try{T(new RequiredModifierType(ta,module.TypeSystem.Int32));throw new Exception("accepted modifier");}catch(InvalidDataException){cases.Add("unknown-modifier-refused");}
        var pm=new MethodDefinition("P",MethodAttributes.Static|MethodAttributes.PInvokeImpl,module.TypeSystem.Int32){PInvokeInfo=new PInvokeInfo(PInvokeAttributes.CallConvCdecl,"entry",new ModuleReference("steam_api64"))};var desc=PInvoke(pm);pm.PInvokeInfo.EntryPoint="wrong";Check(desc!=PInvoke(pm),"import-entry-change-refused");pm.PInvokeInfo.EntryPoint="entry";pm.PInvokeInfo.Module=new ModuleReference("steam_api");Check(desc!=PInvoke(pm),"import-module-change-refused");pm.PInvokeInfo.Module=new ModuleReference("steam_api64");pm.PInvokeInfo.Attributes=PInvokeAttributes.CallConvStdCall;Check(desc!=PInvoke(pm),"import-calling-convention-change-refused");
        var deps=new Dictionary<string,SortedSet<string>>{{"A",new(new[]{"B"})},{"B",new(new[]{"A","P"})},{"C",new(new[]{"Missing"})},{"D",new(new[]{"C"})}};var closure=Close(new(deps.Keys),deps,new(new[]{"P"}));Check(closure.SetEquals(new[]{"A","B"}),"managed-SCC-closed-and-missing-chain-excluded");Check(!Close(new(deps.Keys),deps,new()).Any(),"missing-native-terminal-propagates-refusal");
        var parse=new CSharpParseOptions(LanguageVersion.CSharp8);var tree=CSharpSyntaxTree.ParseText("namespace Steamworks { class Fixture { int x; static int s; void A(){x=0;} void B(){s=0;} int C()=>7; int D()=>0; void E(){ F(); } void F(){} } }",parse);var compilation=CSharpCompilation.Create("FrozenSteamworksTargetSource",new[]{tree},new[]{MetadataReference.CreateFromFile(Path.Combine(framework,"mscorlib.dll"))},new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));var ns=Nodes(compilation);
        Check(Stub(ns["Steamworks.Fixture|A``0()->[mscorlib]System.Void"]),"only-own-instance-default-assignment-is-stub");Check(!Stub(ns["Steamworks.Fixture|B``0()->[mscorlib]System.Void"]),"static-state-assignment-not-overwritten-as-stub");Check(!Stub(ns["Steamworks.Fixture|C``0()->[mscorlib]System.Int32"]),"nondefault-constant-body-not-overwritten");Check(Stub(ns["Steamworks.Fixture|D``0()->[mscorlib]System.Int32"]),"exact-default-return-classified");Check(!Stub(ns["Steamworks.Fixture|E``0()->[mscorlib]System.Void"]),"existing-call-body-not-overwritten");
        File.WriteAllText(output,JsonSerializer.Serialize(new{status="passed",production_helpers_tested=true,count=cases.Count,cases,game_or_SDK_code_executed=false},new JsonSerializerOptions{WriteIndented=true}));return 0;
    }
    static int Main(string[] args)
    {
        if(args.Length==3&&args[0]=="--fixtures")return Fixtures(args[1],args[2]);
        Need(args.Length==7,"native-contracts official-sdk.dll restored-core.dll official-source-root frozen-source-root framework-dir NEW-output-dir");
        string output=Path.GetFullPath(args[6]);Need(!Directory.Exists(output),"Fresh proposal directory required");Directory.CreateDirectory(output);
        using var nativeDoc=JsonDocument.Parse(File.ReadAllText(args[0]));var native=nativeDoc.RootElement.GetProperty("types").EnumerateArray().ToDictionary(t=>t.GetProperty("owner").GetString(),StringComparer.Ordinal);
        using var sdk=ModuleDefinition.ReadModule(args[1],new ReaderParameters{ReadingMode=ReadingMode.Deferred});using var target=ModuleDefinition.ReadModule(args[2],new ReaderParameters{ReadingMode=ReadingMode.Deferred});
        Need(sdk.Assembly.Name.Name=="OfficialSteamworks14"&&target.Assembly.Name.Name=="Assembly-CSharp","Expected exact SDK source witness and core identities");
        var sourceTypes=All(sdk.Types).Where(t=>t.FullName.StartsWith("Steamworks.",StringComparison.Ordinal)).ToDictionary(t=>t.FullName,StringComparer.Ordinal);
        var targetTypes=All(target.Types).Where(t=>t.FullName.StartsWith("Steamworks.",StringComparison.Ordinal)).ToDictionary(t=>t.FullName,StringComparer.Ordinal);
        var sourceMethods=sourceTypes.Values.SelectMany(t=>t.Methods).ToDictionary(MK,StringComparer.Ordinal);var targetMethods=targetTypes.Values.SelectMany(t=>t.Methods).GroupBy(MK).ToDictionary(g=>g.Key,g=>g.ToArray(),StringComparer.Ordinal);
        var nativeMethods=native.Values.SelectMany(t=>t.GetProperty("methods").EnumerateArray().Select(m=>(owner:t.GetProperty("owner").GetString(),method:m))).Where(r=>r.method.GetProperty("signature").ValueKind==JsonValueKind.String).ToDictionary(r=>r.owner+"|"+r.method.GetProperty("signature").GetString(),r=>r.method,StringComparer.Ordinal);
        var nativeFields=native.Values.SelectMany(t=>t.GetProperty("fields").EnumerateArray().Select(f=>(owner:t.GetProperty("owner").GetString(),field:f))).ToDictionary(r=>r.owner+"|"+r.field.GetProperty("name").GetString()+"|"+r.field.GetProperty("type").GetString(),r=>r.field,StringComparer.Ordinal);
        var mappedFields=new HashSet<string>(StringComparer.Ordinal);var rejectedTypes=new HashSet<string>(StringComparer.Ordinal);var typeIssues=new List<object>();
        foreach(var st in sourceTypes.Values){if(!native.TryGetValue(st.FullName,out var nt)||!targetTypes.TryGetValue(st.FullName,out var tt)){rejectedTypes.Add(st.FullName);continue;}
            if(T(st.BaseType)!=nt.GetProperty("base_type").GetString()||!st.Interfaces.Select(i=>T(i.InterfaceType)).OrderBy(x=>x).SequenceEqual(nt.GetProperty("interfaces").EnumerateArray().Select(x=>x.GetString()).OrderBy(x=>x))){rejectedTypes.Add(st.FullName);typeIssues.Add(new{owner=st.FullName,reason="original-base-or-interface-contract-differs"});}
            foreach(var sf in st.Fields){string k=FK(sf);var found=tt.Fields.Where(f=>FK(f)==k).ToArray();if(nativeFields.TryGetValue(k,out var nf)&&found.Length==1&&(int)sf.Attributes==nf.GetProperty("flags").GetInt32()&&sf.Attributes==found[0].Attributes&&Const(sf)==Const(found[0]))mappedFields.Add(k);}
        }
        string[] officialFiles=Directory.GetFiles(args[3],"*.cs",SearchOption.AllDirectories),targetFiles=Directory.GetFiles(args[4],"*.cs",SearchOption.AllDirectories);
        // Exactly the existing official compiled witness. Other platform source
        // branches remain present as text, but are not claimed validated here.
        var parse=new CSharpParseOptions(LanguageVersion.CSharp8,preprocessorSymbols:new[]{"STEAMWORKS_WIN","STEAMWORKS_X64"});
        var framework=new[]{"mscorlib.dll","System.dll","System.Core.dll"}.Select(n=>MetadataReference.CreateFromFile(Path.Combine(args[5],n))).ToArray();
        var sourceCompilation=CSharpCompilation.Create("OfficialSteamworks14Source",officialFiles.Select(p=>CSharpSyntaxTree.ParseText(File.ReadAllText(p),parse,p)),framework,new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,allowUnsafe:true));
        Need(!sourceCompilation.GetDiagnostics().Any(d=>d.Severity==DiagnosticSeverity.Error),"Official source no longer compiles under matching framework");
        var targetCompilation=CSharpCompilation.Create("FrozenSteamworksTargetSource",targetFiles.Select(p=>CSharpSyntaxTree.ParseText(File.ReadAllText(p),parse,p)),framework.Concat(new[]{MetadataReference.CreateFromFile(args[2])}),new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,allowUnsafe:true));
        var sourceNodes=Nodes(sourceCompilation);var targetNodes=Nodes(targetCompilation);var candidates=new Dictionary<string,Candidate>(StringComparer.Ordinal);var pinvokes=new HashSet<string>(StringComparer.Ordinal);var runtime=new HashSet<string>(StringComparer.Ordinal);
        foreach(var pair in sourceMethods){var sm=pair.Value;var c=new Candidate{Key=pair.Key,Source=sm};
            if(!nativeMethods.TryGetValue(pair.Key,out var nm)){c.Issues.Add("no-exact-native-full-scoped-signature");}
            else {c.Native=nm;if((int)sm.Attributes!=nm.GetProperty("flags").GetInt32()||(int)sm.ImplAttributes!=nm.GetProperty("impl_flags").GetInt32()||!sm.Parameters.Select(p=>(int)p.Attributes).SequenceEqual(nm.GetProperty("parameter_flags").EnumerateArray().Select(x=>x.GetInt32())))c.Issues.Add("native-flags-or-parameter-contract-differs");}
            if(!targetMethods.TryGetValue(pair.Key,out var tm)||tm.Length!=1)c.Issues.Add("native-member-absent-or-ambiguous-in-current-core");else {c.Target=tm[0];if(c.Native.ValueKind!=JsonValueKind.Undefined&&((int)c.Target.Attributes!=nm.GetProperty("flags").GetInt32()||(int)c.Target.ImplAttributes!=nm.GetProperty("impl_flags").GetInt32()))c.Issues.Add("target-flags-not-native-exact");}
            if(rejectedTypes.Contains(sm.DeclaringType.FullName))c.Issues.Add("SDK-type-base-interface-or-owner-differs");
            if(sm.DeclaringType.FullName=="Steamworks.CallbackDispatcher"||sm.DeclaringType.FullName.StartsWith("Steamworks.Callback`1",StringComparison.Ordinal)||sm.DeclaringType.FullName.StartsWith("Steamworks.CallResult`1",StringComparison.Ordinal)||((sm.DeclaringType.FullName=="Steamworks.SteamAPI"||sm.DeclaringType.FullName=="Steamworks.GameServer")&&(sm.Name=="Init"||sm.Name=="Shutdown"||sm.Name=="RunCallbacks")))c.Issues.Add("original-manual-dispatch-backport-differs-from-tag14-callback-gateway");
            if(!sm.HasBody){if(c.Issues.Count==0&&sm.IsPInvokeImpl&&c.Target.IsPInvokeImpl&&PInvoke(sm)==PInvoke(c.Target))pinvokes.Add(pair.Key);else if(c.Issues.Count==0&&sm.IsRuntime&&c.Target.IsRuntime)runtime.Add(pair.Key);continue;}
            if(!sourceNodes.TryGetValue(pair.Key,out c.SourceNode))c.Issues.Add("no-explicit-official-method-body-source-e.g-field-initializer-cctor");
            if(!targetNodes.TryGetValue(pair.Key,out c.TargetNode))c.Issues.Add("no-exact-existing-projected-source-method");
            if(c.SourceNode!=null&&c.TargetNode!=null){if(!c.SourceNode.Symbol.Parameters.Select(p=>p.Name).SequenceEqual(c.TargetNode.Symbol.Parameters.Select(p=>p.Name)))c.Issues.Add("parameter-names-differ-no-textual-alpha-guess");if(!Stub(c.TargetNode))c.Issues.Add("existing-source-is-not-an-obvious-empty-or-default-stub");
                foreach(var node in c.SourceNode.Body.DescendantNodes().OfType<IdentifierNameSyntax>())if(c.SourceNode.Model.GetSymbolInfo(node).Symbol is IFieldSymbol f&&O(f.ContainingType).StartsWith("Steamworks.",StringComparison.Ordinal))if(!mappedFields.Contains(O(f.ContainingType)+"|"+f.Name+"|"+S(f.Type)))c.Issues.Add("source-field-or-inlined-constant-not-native-exact:"+O(f.ContainingType)+"::"+f.Name);
            }
            void TypeRef(TypeReference tr){if(tr is GenericInstanceType gi){TypeRef(gi.ElementType);foreach(var ga in gi.GenericArguments)TypeRef(ga);return;}if(tr is TypeSpecification spec){if(spec is RequiredModifierType||spec is OptionalModifierType||spec is FunctionPointerType)c.Issues.Add("unsupported-body-TypeSpec");TypeRef(spec.ElementType);return;}if(tr is GenericParameter)return;if(Scope(tr)=="Assembly-CSharp"&&(!native.ContainsKey(tr.FullName)||!targetTypes.ContainsKey(tr.FullName)||rejectedTypes.Contains(tr.FullName)))c.Issues.Add("body-type-not-native-and-target-exact:"+tr.FullName);else if(Scope(tr)!="Assembly-CSharp"&&!target.AssemblyReferences.Any(a=>a.FullName==(tr.Scope as AssemblyNameReference)?.FullName))c.Issues.Add("external-assembly-scope-absent-from-current-core:"+tr.Scope);}
            foreach(var l in sm.Body.Variables)TypeRef(l.VariableType);foreach(var eh in sm.Body.ExceptionHandlers)if(eh.CatchType!=null)TypeRef(eh.CatchType);
            foreach(var i in sm.Body.Instructions){if(i.Operand is MethodReference mr){var em=mr is GenericInstanceMethod gm?gm.ElementMethod:mr;TypeRef(em.DeclaringType);TypeRef(em.ReturnType);foreach(var p in em.Parameters)TypeRef(p.ParameterType);if(Scope(em.DeclaringType)=="Assembly-CSharp")c.Dependencies.Add(MK(em));if(mr is GenericInstanceMethod mg)foreach(var a in mg.GenericArguments)TypeRef(a);}
                else if(i.Operand is FieldReference fr){TypeRef(fr.DeclaringType);TypeRef(fr.FieldType);if(Scope(fr.DeclaringType)=="Assembly-CSharp"){if(!mappedFields.Contains(FK(fr)))c.Issues.Add("body-field-not-native-and-target-exact:"+FK(fr));if(sourceTypes.TryGetValue(Owner(fr.DeclaringType),out var ft)){var fd=ft.Fields.SingleOrDefault(f=>FK(f)==FK(fr));var cc=ft.Methods.SingleOrDefault(m=>m.Name==".cctor");if(fd!=null&&fd.IsStatic&&cc!=null)c.Dependencies.Add(MK(cc));}}}
                else if(i.Operand is TypeReference tr)TypeRef(tr);else if(i.Operand is CallSite)c.Issues.Add("calli-standalone-signature-not-supported");}
            candidates.Add(pair.Key,c);
        }
        var terminals=new HashSet<string>(pinvokes.Concat(runtime),StringComparer.Ordinal);var accepted=Close(candidates.Values.Where(c=>c.Issues.Count==0).Select(c=>c.Key).ToHashSet(StringComparer.Ordinal),candidates.ToDictionary(c=>c.Key,c=>c.Value.Dependencies,StringComparer.Ordinal),terminals);
        foreach(var c in candidates.Values.Where(c=>!accepted.Contains(c.Key)))foreach(var dep in c.Dependencies)if(!accepted.Contains(dep)&&!terminals.Contains(dep))c.Issues.Add("unrecovered-or-unmapped-SDK-body-dependency:"+dep);
        var edits=new Dictionary<string,List<(int start,int length,string text,string key)>>(StringComparer.OrdinalIgnoreCase);var rows=new List<object>();
        foreach(var key in accepted.OrderBy(x=>x,StringComparer.Ordinal)){var c=candidates[key];var sn=c.SourceNode;var tn=c.TargetNode;string text=File.ReadAllText(tn.Path);int start=tn.ReplaceNode.SpanStart,length=tn.ReplaceNode.Span.Length;string replacement=sn.Body.ToFullString();
            if(tn.ReplaceNode is ArrowExpressionClauseSyntax){var semicolon=tn.Declaration.DescendantTokens().Last(t=>t.IsKind(SyntaxKind.SemicolonToken));length=semicolon.Span.End-start;if(tn.Declaration is PropertyDeclarationSyntax)replacement="{ get "+replacement+" }";}
            if(!edits.TryGetValue(tn.Path,out var list))edits[tn.Path]=list=new();list.Add((start,length,replacement,key));
            if(tn.Declaration is ConstructorDeclarationSyntax tc){string sourceInit=sn.Initializer?.ToFullString()??"";if(tc.Initializer!=null)list.Add((tc.Initializer.SpanStart,tc.Initializer.Span.Length,sourceInit,key+"#initializer"));else if(sn.Initializer!=null)list.Add((tc.Body.SpanStart,0,sourceInit+" ",key+"#initializer"));}
            rows.Add(new{owner=c.Source.DeclaringType.FullName,signature=M(c.Source),native_method_token=c.Native.GetProperty("native_method_token").GetString(),native_method_index=c.Native.GetProperty("native_method_index").GetInt32(),official_method_token=c.Source.MetadataToken.ToUInt32(),current_core_method_token=c.Target.MetadataToken.ToUInt32(),official_source=Ref(sn.Path),frozen_source=Ref(tn.Path),official_body_sha256=Convert.ToHexString(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(sn.Body.ToFullString()))).ToLowerInvariant(),dependencies=c.Dependencies.ToArray(),claim="genuine-exact-version-SDK-source-restoration-not-native-body-equality"});
        }
        var files=new List<object>();var sourcesDir=Path.Combine(output,"Sources");Directory.CreateDirectory(sourcesDir);
        foreach(var item in edits){string before=File.ReadAllText(item.Key),after=before;int previous=before.Length+1;foreach(var e in item.Value.OrderByDescending(e=>e.start)){Need(e.start+e.length<=previous,"Overlapping SDK source body edits");after=after.Remove(e.start,e.length).Insert(e.start,e.text);previous=e.start;}
            var currentRoot=(CompilationUnitSyntax)CSharpSyntaxTree.ParseText(after,parse,item.Key).GetRoot();var imports=new List<UsingDirectiveSyntax>();var allImports=currentRoot.Usings.ToDictionary(u=>u.Alias?.Name.Identifier.ValueText??u.ToString(),u=>u.ToString(),StringComparer.Ordinal);
            foreach(var key in item.Value.Select(e=>e.key.Split('#')[0]).Distinct()){var sourceRoot=(CompilationUnitSyntax)candidates[key].SourceNode.Declaration.SyntaxTree.GetRoot();foreach(var u in sourceRoot.Usings){string identity=u.Alias?.Name.Identifier.ValueText??u.ToString();if(allImports.TryGetValue(identity,out var old)){Need(old==u.ToString(),"Conflicting source alias import");continue;}allImports.Add(identity,u.ToString());imports.Add(SyntaxFactory.ParseCompilationUnit(u.ToString()+Environment.NewLine).Usings.Single());}}
            if(imports.Count!=0)after=string.Join(Environment.NewLine,imports.Select(u=>u.ToString()))+Environment.NewLine+after;
            var tr=CSharpSyntaxTree.ParseText(after,parse,item.Key);Need(!tr.GetDiagnostics().Any(d=>d.Severity==DiagnosticSeverity.Error),"Staged source syntax invalid:"+item.Key);
            string relative=Path.GetRelativePath(args[4],item.Key);string dest=Path.Combine(sourcesDir,relative);Directory.CreateDirectory(Path.GetDirectoryName(dest));File.WriteAllText(dest,after);files.Add(new{relative_path=relative,input=Ref(item.Key),candidate=Ref(dest),method_body_edits=item.Value.Select(e=>new{offset=e.start,length=e.length,method=e.key}).ToArray()});}
        var report=new{schema="native-contract-scoped-Steamworks14-source-body-stage/v1",status="staged-body-proposal-not-compiled-or-installed",native_assembly="Assembly-CSharp",official_sdk="Steamworks.NET14.0.0-SteamSDK1.48",source_profile="STEAMWORKS_WIN;STEAMWORKS_X64",all_official_platform_source_preserved=true,other_platform_validation_pending=true,project_modified=false,SDK_or_game_code_executed=false,SDK_assembly_not_added=true,original_declarations_attributes_and_fields_not_replaced=true,official_managed_bodies=candidates.Count,within_body_SDK_dependency_closed_candidates=accepted.Count,existing_native_PInvoke_terminal_contracts=pinvokes.Count,runtime_delegate_terminals=runtime.Count,source_files=files,type_contract_gaps=typeIssues,methods=rows,excluded=candidates.Values.Where(c=>!accepted.Contains(c.Key)).Select(c=>new{method=c.Key,reasons=c.Issues.ToArray(),dependencies=c.Dependencies.ToArray()}).ToArray(),inputs=new[]{Ref(args[0]),Ref(args[1]),Ref(args[2])},limitations=new[]{"Only explicit existing method/accessor/constructor bodies are staged; missing static constructors/field initializers remain explicit gaps.","A dependency-closed individual body set does not establish complete SDK initialization, callbacks, Steam authentication, login, or a playable client.","The original Rec Room-specific callback/context declarations remain unchanged. No SDK type or field is added, removed, or replaced.","Same-version official SDK source restoration is not proof of equality to every original native body; the version14/manual-dispatch mixed contract is explicitly excluded.","Full exact Unity C# compile, IL binding/declaration equivalence and multi-platform validation are still required before any apply."}};
        File.WriteAllText(Path.Combine(output,"report.json"),JsonSerializer.Serialize(report,new JsonSerializerOptions{WriteIndented=true}));Console.WriteLine("Staged genuine SDK bodies: "+accepted.Count+" in "+files.Count+" files; no project mutation or inspected code execution.");return 0;
    }
}
