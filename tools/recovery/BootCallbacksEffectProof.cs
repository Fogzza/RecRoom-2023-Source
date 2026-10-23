// Inspects metadata and C# symbols only; no inspected game/fixture IL is executed.
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

static class BootCallbacksEffectProof
{
    static void Need(bool condition, string message) { if (!condition) throw new InvalidDataException(message); }
    static bool Method(MethodReference m, string owner, string name) => m != null && m.DeclaringType.FullName == owner && m.Name == name;
    // Require exact optimized instructions, including discarded AddComponent result.
    static bool ExactBoot(IList<Instruction> il) => il.Count == 7
        && il[0].OpCode.Code == Code.Ldarg_0
        && il[1].OpCode.Code == Code.Call && Method(il[1].Operand as MethodReference, "GameRoot", "HPCJAAEDLCH")
        && il[2].OpCode.Code == Code.Ldstr && (string)il[2].Operand == "BootSequence"
        && il[3].OpCode.Code == Code.Newobj && il[3].Operand is MethodReference ctor && Method(ctor, "UnityEngine.GameObject", ".ctor") && ctor.Parameters.Count == 1 && ctor.Parameters[0].ParameterType.FullName == "System.String"
        && il[4].OpCode.Code == Code.Callvirt && il[4].Operand is GenericInstanceMethod add && Method(add, "UnityEngine.GameObject", "AddComponent") && add.GenericArguments.Count == 1 && add.GenericArguments[0].FullName == "BootSequence" && add.Parameters.Count == 0
        && il[5].OpCode.Code == Code.Pop && il[6].OpCode.Code == Code.Ret;
    static bool Destroy(IList<Instruction> il) => il.Count == 7
        && il[0].OpCode.Code == Code.Ldarg_0
        && il[1].OpCode.Code == Code.Call && Method(il[1].Operand as MethodReference, "GameRoot", "OnDestroy")
        && il[2].OpCode.Code == Code.Ldarg_0
        && il[3].OpCode.Code == Code.Ldftn && Method(il[3].Operand as MethodReference, "RecRoomGameRoot", "ADNHOPPILKF")
        && il[4].OpCode.Code == Code.Newobj && il[4].Operand is MethodReference ctor && Method(ctor, "UnityEngine.Application/LowMemoryCallback", ".ctor") && ctor.Parameters.Count == 2 && ctor.Parameters[0].ParameterType.FullName == "System.Object" && ctor.Parameters[1].ParameterType.FullName == "System.IntPtr"
        && il[5].OpCode.Code == Code.Call && Method(il[5].Operand as MethodReference, "UnityEngine.Application", "remove_lowMemory")
        && il[6].OpCode.Code == Code.Ret;

    static int Main(string[] args)
    {
        var tree = CSharpSyntaxTree.ParseText(File.ReadAllText(args[2]), new CSharpParseOptions(LanguageVersion.CSharp8), args[2]);
        var refs = args.Skip(3).Select(p => MetadataReference.CreateFromFile(p)).ToArray();
        var compilation = CSharpCompilation.Create("RecRoomBootCallbacksSourceProof", new[] { tree }, refs, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, optimizationLevel: OptimizationLevel.Release));
        Need(!compilation.GetDiagnostics().Any(d => d.Severity == DiagnosticSeverity.Error), string.Join("\n", compilation.GetDiagnostics().Where(d => d.Severity == DiagnosticSeverity.Error)));
        var semantic = compilation.GetSemanticModel(tree);
        var root = tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().Single(c => c.Identifier.ValueText == "RecRoomGameRoot");
        var rootSymbol = (INamedTypeSymbol)semantic.GetDeclaredSymbol(root);
        Need(rootSymbol.BaseType.Name == "GameRoot" && rootSymbol.BaseType.ContainingAssembly.Name == "RecRoom.Datastructures.Singletons.Runtime", "Exact original external base class not bound");
        var bootNode = root.Members.OfType<MethodDeclarationSyntax>().Single(m => m.Identifier.ValueText == "HPCJAAEDLCH");
        var destroyNode = root.Members.OfType<MethodDeclarationSyntax>().Single(m => m.Identifier.ValueText == "OnDestroy");
        foreach (var node in new[] { bootNode, destroyNode }) {
            var symbol = (IMethodSymbol)semantic.GetDeclaredSymbol(node);
            Need(symbol.IsOverride && symbol.OverriddenMethod.ContainingType.Name == "GameRoot", "Exact original base override binding differs");
        }
        var calls = bootNode.DescendantNodes().OfType<InvocationExpressionSyntax>().ToArray();
        Need(calls.Length == 2, "Boot callback must have precisely original two invocations");
        var baseCall = (IMethodSymbol)semantic.GetSymbolInfo(calls[0]).Symbol;
        var genericCall = (IMethodSymbol)semantic.GetSymbolInfo(calls[1]).Symbol;
        Need(baseCall.Name == "HPCJAAEDLCH" && baseCall.ContainingType.Name == "GameRoot", "Base startup call binding differs");
        Need(genericCall.Name == "AddComponent" && genericCall.ContainingType.ToDisplayString() == "UnityEngine.GameObject" && genericCall.TypeArguments.Single().ToDisplayString() == "BootSequence" && genericCall.TypeArguments[0].ContainingAssembly.Name == "Assembly-CSharp", "Original BootSequence type argument identity differs");
        var remove = destroyNode.DescendantNodes().OfType<AssignmentExpressionSyntax>().Single();
        var eventSymbol = semantic.GetSymbolInfo(remove.Left).Symbol as IEventSymbol;
        Need(remove.IsKind(SyntaxKind.SubtractAssignmentExpression) && eventSymbol != null && eventSymbol.Name == "lowMemory" && eventSymbol.ContainingType.ToDisplayString() == "UnityEngine.Application" && eventSymbol.Type.ToDisplayString() == "UnityEngine.Application.LowMemoryCallback", "Original lowMemory remove/delegate binding differs");
        var callback = destroyNode.DescendantNodes().OfType<IdentifierNameSyntax>().Single(x => x.Identifier.ValueText == "ADNHOPPILKF");
        var callbackSymbol = semantic.GetSymbolInfo(callback).Symbol as IMethodSymbol;
        Need(callbackSymbol != null && SymbolEqualityComparer.Default.Equals(callbackSymbol.ContainingType, rootSymbol) && callbackSymbol.ReturnsVoid && callbackSymbol.Parameters.Length == 0 && !callbackSymbol.IsStatic, "Original callback signature/owner not bound");

        using var module = ModuleDefinition.ReadModule(args[0]);
        var type = module.GetType("RecRoomGameRoot");
        var boot = type.Methods.Single(m => m.Name == "HPCJAAEDLCH");
        var destroy = type.Methods.Single(m => m.Name == "OnDestroy");
        Need(ExactBoot(boot.Body.Instructions), "Compiled boot effect sequence is not exact: " + string.Join("; ", boot.Body.Instructions));
        Need(Destroy(destroy.Body.Instructions), "Compiled destroy effect sequence is not exact: " + string.Join("; ", destroy.Body.Instructions));
        var negatives = new List<object>();
        void Negative(string name, Instruction i, OpCode opcode, object operand, Func<bool> predicate) {
            var priorOpcode = i.OpCode; var priorOperand = i.Operand;
            i.OpCode = opcode; i.Operand = operand;
            bool rejected = !predicate(); i.OpCode = priorOpcode; i.Operand = priorOperand;
            Need(rejected && predicate(), "Mutation accepted or restore failed: " + name); negatives.Add(new { name, rejected });
        }
        var bi = boot.Body.Instructions; var di = destroy.Body.Instructions;
        Negative("wrong_boot_object_literal", bi[2], OpCodes.Ldstr, "ReplacementBootstrap", () => ExactBoot(bi));
        Negative("virtual_base_boot_call", bi[1], OpCodes.Callvirt, bi[1].Operand, () => ExactBoot(bi));
        Negative("missing_generic_call_pop", bi[5], OpCodes.Nop, null, () => ExactBoot(bi));
        Negative("virtual_base_destroy_call", di[1], OpCodes.Callvirt, di[1].Operand, () => Destroy(di));
        Negative("delegate_callback_loaded_virtually", di[3], OpCodes.Ldvirtftn, di[3].Operand, () => Destroy(di));
        var add = (GenericInstanceMethod)bi[4].Operand; var originalArg = add.GenericArguments[0]; add.GenericArguments[0] = module.TypeSystem.Object; bool rejectedArg = !ExactBoot(bi); add.GenericArguments[0] = originalArg;
        Need(rejectedArg && ExactBoot(bi), "Wrong generic argument mutation accepted"); negatives.Add(new { name = "wrong_AddComponent_type_argument", rejected = rejectedArg });
        var removeMethod = (MethodReference)di[5].Operand; var originalName = removeMethod.Name; removeMethod.Name = "add_lowMemory"; bool rejectedEvent = !Destroy(di); removeMethod.Name = originalName;
        Need(rejectedEvent && Destroy(di), "Event add mutation accepted"); negatives.Add(new { name = "event_add_instead_of_remove", rejected = rejectedEvent });
        object Row(MethodDefinition m) => new { owner = m.DeclaringType.FullName, name = m.Name, il = m.Body.Instructions.Select(i => new { op = i.OpCode.Name, operand = i.Operand is MethodReference mr ? mr.FullName : i.Operand?.ToString() }) };
        File.WriteAllText(args[1], JsonSerializer.Serialize(new { passed = true, actual_candidate_source_symbol_binding = true, exact_Unity2020_compiled_effects = true, native_bodies = 2, negative_controls = negatives, methods = new[] { Row(boot), Row(destroy) }, original_BootSequence_body_recovered = false, GameRoot_OnDestroy_body_recovered = false, game_or_fixture_IL_executed = false }, new JsonSerializerOptions { WriteIndented = true }));
        return 0;
    }
}
