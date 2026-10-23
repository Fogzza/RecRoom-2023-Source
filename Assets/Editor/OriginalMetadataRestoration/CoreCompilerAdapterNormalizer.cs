// Exact inverse of proven C# forwarding adapters. Never manufactures a method body.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace RR23.MetadataRestoration
{
    public sealed class CoreCompilerAdapterPlan
    {
        public string OriginalOwner, CompiledOwner, OriginalCanonical;
        public string AdapterCanonical, RetainedCanonical, PlannedRetainedCanonical;
    }
    public sealed class CoreCompilerConstructorInversePlan { public string CompiledOwner, Canonical; }
    public sealed class CoreCompilerRetainedAlias
    {
        public string CompiledOwner, BeforeCanonical, AfterCanonical, OriginalCanonical;
    }
    public sealed class CoreCompilerAdapterNormalizationResult
    {
        public int RemovedForwarders, RemovedImplicitConstructors, ReboundPropertyAccessors, ReboundEventAccessors;
        public int ReferenceAliasReversals;
        public readonly List<CoreCompilerRetainedAlias> RetainedAliases = new List<CoreCompilerRetainedAlias>();
    }

    public static class CoreCompilerAdapterNormalizer
    {
        private static void Need(bool value, string text) { if (!value) throw new InvalidDataException(text); }
        private static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types)
        { foreach (var type in types) { yield return type; foreach (var child in Walk(type.NestedTypes)) yield return child; } }
        private static string Canon(MethodReference method) { return CanonicalMetadataSignatures.Method(method); }
        private static string Type(TypeReference type) { return CanonicalMetadataSignatures.Type(type); }
        private static T One<T>(IEnumerable<T> values, string why)
        { var items = values.Take(2).ToArray(); Need(items.Length == 1, why); return items[0]; }
        private static TypeReference WithoutCompilerIn(TypeReference type)
        {
            var modifier = type as RequiredModifierType;
            if (modifier != null && modifier.ModifierType.FullName == "System.Runtime.InteropServices.InAttribute"
                && CanonicalMetadataSignatures.Assembly(modifier.ModifierType) == "mscorlib"
                && modifier.ElementType is ByReferenceType) return modifier.ElementType;
            return type;
        }
        private static bool Readonly(ICustomAttributeProvider owner)
        { return owner.CustomAttributes.Any(a => a.AttributeType.FullName == "System.Runtime.CompilerServices.IsReadOnlyAttribute"); }
        private static bool CompilerInOwnership(MethodDefinition method)
        {
            if (!ReferenceEquals(method.ReturnType, WithoutCompilerIn(method.ReturnType)) && !Readonly(method.MethodReturnType)) return false;
            return method.Parameters.All(p => ReferenceEquals(p.ParameterType, WithoutCompilerIn(p.ParameterType)) || (p.IsIn && Readonly(p)));
        }
        private static string CanonWithoutIn(MethodReference method, string name)
        {
            var clone = new MethodReference(name, WithoutCompilerIn(method.ReturnType), method.DeclaringType)
            { HasThis = method.HasThis, ExplicitThis = method.ExplicitThis, CallingConvention = method.CallingConvention };
            foreach (var gp in method.GenericParameters) clone.GenericParameters.Add(new GenericParameter(gp.Name, clone));
            foreach (var p in method.Parameters) clone.Parameters.Add(new ParameterDefinition(WithoutCompilerIn(p.ParameterType)));
            return Canon(clone);
        }
        private static int Arg(Instruction instruction, MethodDefinition method)
        {
            switch (instruction.OpCode.Code)
            {
                case Code.Ldarg_0: return 0; case Code.Ldarg_1: return 1; case Code.Ldarg_2: return 2; case Code.Ldarg_3: return 3;
                case Code.Ldarg: case Code.Ldarg_S:
                    var p = instruction.Operand as ParameterDefinition; return p == null ? -1 : p.Index + (method.HasThis ? 1 : 0);
                default: return -1;
            }
        }
        private static MethodDefinition OwnTarget(MethodReference method, ModuleDefinition module)
        {
            if (method == null || method.Module != module || CanonicalMetadataSignatures.Assembly(method.DeclaringType) != module.Assembly.Name.Name) return null;
            return method.Resolve(); // Only this already-read module is eligible.
        }
        private static void Forwarder(MethodDefinition adapter, MethodDefinition target, MethodDefinition raw,
            Func<TypeReference, string> projectedType, Dictionary<string, MethodReferenceAlias> methodAliases, WholeMetadataManifest manifest)
        {
            Need(adapter.HasThis && target.HasThis && !adapter.IsStatic && !target.IsStatic
                && adapter.GenericParameters.Count == 0 && target.GenericParameters.Count == 0 && adapter.HasBody
                && adapter.Body.ExceptionHandlers.Count == 0 && ReferenceEquals(adapter.DeclaringType, target.DeclaringType), "Adapter instance/owner/body differs");
            Need(adapter.Parameters.Count == target.Parameters.Count && Type(WithoutCompilerIn(adapter.ReturnType)) == Type(WithoutCompilerIn(target.ReturnType))
                && adapter.Parameters.Select(p => Type(WithoutCompilerIn(p.ParameterType))).SequenceEqual(target.Parameters.Select(p => Type(WithoutCompilerIn(p.ParameterType))))
                && CompilerInOwnership(adapter), "Adapter changed parameter/return values or readonly ownership");
            var code = adapter.Body.Instructions.Where(i => i.OpCode.Code != Code.Nop).ToArray();
            int call = Array.FindIndex(code, i => i.OpCode.Code == Code.Call);
            Need(call == adapter.Parameters.Count + 1 && code.Count(i => i.OpCode.Code == Code.Call) == 1
                && code.All(i => i.OpCode.Code != Code.Callvirt) && code[call].Operand is MethodReference
                && !(code[call].Operand is GenericInstanceMethod), "Not the proven single nonvirtual CALL wrapper");
            Need(Enumerable.Range(0, call).All(i => Arg(code[i], adapter) == i)
                && ReferenceEquals(OwnTarget((MethodReference)code[call].Operand, adapter.Module), target), "Adapter does not forward exact unchanged arguments to the retained body");
            var tail = code.Skip(call + 1).ToArray();
            bool direct = tail.Length == 1 && tail[0].OpCode.Code == Code.Ret;
            bool debug = tail.Length == 4 && adapter.Body.Variables.Count == 1
                && Type(adapter.Body.Variables[0].VariableType) == Type(adapter.ReturnType)
                && tail[0].OpCode.Code == Code.Stloc_0 && (tail[1].OpCode.Code == Code.Br || tail[1].OpCode.Code == Code.Br_S)
                && ReferenceEquals(tail[1].Operand, tail[2]) && tail[2].OpCode.Code == Code.Ldloc_0 && tail[3].OpCode.Code == Code.Ret;
            Need(direct || debug, "Adapter has additional control flow or effects");
            Need(adapter.Overrides.Count == raw.Overrides.Count, "Original MethodImpl declaration count differs");
            Need(CanonWithoutIn(target, raw.Name) == ProjectedCanonicalSignatures.Method(raw, projectedType),
                "Retained body signature does not equal the original projected contract");
            var expected = raw.Overrides.Select(declaration => {
                string assembly = CanonicalMetadataSignatures.Assembly(declaration.DeclaringType);
                string key = assembly + "|" + declaration.DeclaringType.GetElementType().FullName + "|" + Canon(declaration);
                MethodReferenceAlias alias;
                string signature;
                if (methodAliases.TryGetValue(key, out alias)) signature = alias.CompiledCanonicalSignature;
                else if (assembly == adapter.Module.Assembly.Name.Name)
                {
                    // A same-core virtual `in` declaration has a compiler-only
                    // InAttribute modreq even when no MemberRef alias was emitted.
                    // Bind its exact proven MethodDef projection, never strip it.
                    var ownerPlan = One(manifest.Definitions.Where(p => p.OriginalFullName == declaration.DeclaringType.GetElementType().FullName), "Own override owner plan is not unique");
                    var declarationPlan = One(ownerPlan.Methods.Where(p => p.OriginalCanonicalSignature == Canon(declaration)), "Own override MethodDef projection is not unique");
                    signature = declarationPlan.CompiledCanonicalSignature;
                }
                else signature = ProjectedCanonicalSignatures.Method(declaration, projectedType);
                return ProjectedCanonicalSignatures.Type(declaration.DeclaringType, projectedType) + "|" + signature;
            }).OrderBy(s => s).ToArray();
            var actual = adapter.Overrides.Select(declaration => Type(declaration.DeclaringType) + "|" + Canon(declaration)).OrderBy(s => s).ToArray();
            Need(expected.SequenceEqual(actual), "Original/compiled MethodImpl declaration identities differ: owner=" + adapter.DeclaringType.FullName
                + " raw=" + Canon(raw) + " retained=" + Canon(target) + " adapter=" + Canon(adapter)
                + " expected=[" + string.Join(" | ", expected) + "] actual=[" + string.Join(" | ", actual) + "]");
        }
        private static string Name(string canonical)
        {
            Need(canonical.StartsWith("M", StringComparison.Ordinal), "Expected method canonical selector");
            int colon = canonical.IndexOf(':'); int length = int.Parse(canonical.Substring(1, colon - 1), System.Globalization.CultureInfo.InvariantCulture);
            return canonical.Substring(colon + 1, length);
        }
        private static string Renamed(MethodDefinition method, string name)
        {
            var clone = new MethodReference(name, method.ReturnType, method.DeclaringType)
            { HasThis = method.HasThis, ExplicitThis = method.ExplicitThis, CallingConvention = method.CallingConvention };
            foreach (var gp in method.GenericParameters) clone.GenericParameters.Add(new GenericParameter(gp.Name, clone));
            foreach (var p in method.Parameters) clone.Parameters.Add(new ParameterDefinition(p.ParameterType));
            return Canon(clone);
        }

        public static CoreCompilerAdapterNormalizationResult Normalize(ModuleDefinition compiled, ModuleDefinition raw, WholeMetadataManifest manifest)
        {
            var result = new CoreCompilerAdapterNormalizationResult();
            var currentTypes = Walk(compiled.Types).ToDictionary(t => t.FullName);
            var rawTypes = Walk(raw.Types).ToDictionary(t => t.FullName);
            var typeAliases = (manifest.Types ?? new TypeReferenceAlias[0]).ToDictionary(p => p.Assembly + "|" + p.OriginalFullName, p => p.CompiledFullName);
            Func<TypeReference, string> projectedType = t => { string value; return typeAliases.TryGetValue(CanonicalMetadataSignatures.Assembly(t) + "|" + t.FullName, out value) ? value : t.FullName; };
            var methodAliases = new Dictionary<string, MethodReferenceAlias>();
            foreach (var alias in manifest.Methods ?? new MethodReferenceAlias[0])
            {
                string key = alias.Assembly + "|" + alias.OriginalDeclaringType + "|" + alias.OriginalCanonicalSignature;
                MethodReferenceAlias existing;
                if (methodAliases.TryGetValue(key, out existing)) Need(existing.CompiledCanonicalSignature == alias.CompiledCanonicalSignature, "Conflicting original MethodRef aliases");
                else methodAliases.Add(key, alias);
            }
            var removals = new Dictionary<MethodDefinition, MethodDefinition>();
            var originals = new HashSet<MethodDefinition>();
            var constructors = new HashSet<MethodDefinition>();
            foreach (var plan in manifest.CompilerAdapters ?? new CoreCompilerAdapterPlan[0])
            {
                var owner = currentTypes[plan.CompiledOwner]; var originalOwner = rawTypes[plan.OriginalOwner];
                var adapter = One(owner.Methods.Where(m => Canon(m) == plan.AdapterCanonical), "Adapter selector is not unique");
                var target = One(owner.Methods.Where(m => Canon(m) == plan.RetainedCanonical), "Retained original-body selector is not unique");
                var original = One(originalOwner.Methods.Where(m => Canon(m) == plan.OriginalCanonical), "Original raw selector is not unique");
                Need(adapter != target && !removals.ContainsKey(adapter), "Duplicate or self adapter");
                Forwarder(adapter, target, original, projectedType, methodAliases, manifest);
                Need(Renamed(target, Name(plan.PlannedRetainedCanonical)) == plan.PlannedRetainedCanonical, "Planned retained selector changes more than the name");
                if (originals.Contains(adapter)) throw new InvalidDataException("An original body was also classified as removable");
                originals.Add(target); removals.Add(adapter, target);
                result.RetainedAliases.Add(new CoreCompilerRetainedAlias { CompiledOwner = plan.CompiledOwner,
                    BeforeCanonical = plan.RetainedCanonical, AfterCanonical = plan.PlannedRetainedCanonical, OriginalCanonical = plan.OriginalCanonical });
            }
            foreach (var plan in manifest.CompilerAddedConstructors ?? new CoreCompilerConstructorInversePlan[0])
            {
                const string marker = "PrivateImplementationDetailsKQPLETG.__BB_OBFUSCATOR_VERSION_3_8_2";
                Need(plan.CompiledOwner == marker, "Only the independently proven marker ctor inverse is eligible");
                var owner = currentTypes[marker]; var original = rawTypes[marker];
                var method = One(owner.Methods.Where(m => Canon(m) == plan.Canonical), "Marker ctor selector differs");
                Need(original.Methods.Count == 0 && original.Fields.Count == 0 && original.Properties.Count == 0 && original.Events.Count == 0
                    && original.GenericParameters.Count == 0 && !original.IsValueType && !original.IsInterface && original.BaseType.FullName == "System.Object", "Original marker is not a zero-method Object class");
                Need(owner.Methods.Count == 1 && owner.Fields.Count == 0 && owner.Properties.Count == 0 && owner.Events.Count == 0
                    && owner.GenericParameters.Count == 0 && owner.BaseType.FullName == "System.Object" && method.IsPublic && method.IsConstructor
                    && method.Name == ".ctor" && method.Parameters.Count == 0 && method.HasThis && method.HasBody && !method.HasCustomAttributes
                    && method.Overrides.Count == 0 && method.Body.ExceptionHandlers.Count == 0 && method.Body.Variables.Count == 0, "Compiler marker ctor contract differs");
                var code = method.Body.Instructions.Where(i => i.OpCode.Code != Code.Nop).ToArray();
                var parent = code.Length == 3 ? code[1].Operand as MethodReference : null;
                Need(code.Length == 3 && code[0].OpCode.Code == Code.Ldarg_0 && code[1].OpCode.Code == Code.Call && parent != null
                    && parent.Name == ".ctor" && parent.Parameters.Count == 0 && parent.DeclaringType.FullName == "System.Object"
                    && CanonicalMetadataSignatures.Assembly(parent.DeclaringType) == "mscorlib" && code[2].OpCode.Code == Code.Ret, "Compiler marker ctor body differs");
                constructors.Add(method);
            }
            // Nothing mutates before every original body and operand is checked.
            var retained = Walk(compiled.Types).SelectMany(t => t.Methods).Where(m => !removals.ContainsKey(m) && !constructors.Contains(m)).ToArray();
            foreach (var method in retained.Where(m => m.HasBody)) foreach (var instruction in method.Body.Instructions)
            {
                var reference = instruction.Operand as MethodReference;
                if (reference == null) continue; var target = OwnTarget(reference, compiled);
                Need(target == null || (!removals.ContainsKey(target) && !constructors.Contains(target)), "Retained original IL calls a removable compiler adapter; explicit operand proof required");
            }
            var bodies = BodyAndSymbolSafety.Capture(retained);
            foreach (var type in currentTypes.Values)
            {
                foreach (var property in type.Properties)
                {
                    MethodDefinition target;
                    if (property.GetMethod != null && removals.TryGetValue(property.GetMethod, out target)) { property.GetMethod = target; result.ReboundPropertyAccessors++; }
                    if (property.SetMethod != null && removals.TryGetValue(property.SetMethod, out target)) { property.SetMethod = target; result.ReboundPropertyAccessors++; }
                    Need(property.OtherMethods.All(m => !removals.ContainsKey(m)), "Unplanned other property accessor");
                }
                foreach (var item in type.Events)
                {
                    MethodDefinition target;
                    if (item.AddMethod != null && removals.TryGetValue(item.AddMethod, out target)) { item.AddMethod = target; result.ReboundEventAccessors++; }
                    if (item.RemoveMethod != null && removals.TryGetValue(item.RemoveMethod, out target)) { item.RemoveMethod = target; result.ReboundEventAccessors++; }
                    if (item.InvokeMethod != null && removals.TryGetValue(item.InvokeMethod, out target)) { item.InvokeMethod = target; result.ReboundEventAccessors++; }
                    Need(item.OtherMethods.All(m => !removals.ContainsKey(m)), "Unplanned other event accessor");
                }
            }
            foreach (var alias in result.RetainedAliases)
            {
                if (alias.BeforeCanonical == alias.AfterCanonical) continue;
                var target = One(currentTypes[alias.CompiledOwner].Methods.Where(m => Canon(m) == alias.BeforeCanonical), "Retained rename selector differs");
                // MemberRef aliases are metadata identities, not new IL. Direct
                // MethodDef operands already point to this exact retained body.
                foreach (var member in compiled.GetMemberReferences().OfType<MethodReference>())
                    if (CanonicalMetadataSignatures.Assembly(member.DeclaringType) == compiled.Assembly.Name.Name
                        && member.DeclaringType.GetElementType().FullName == alias.CompiledOwner && Canon(member) == alias.BeforeCanonical)
                    { member.Name = Name(alias.AfterCanonical); result.ReferenceAliasReversals++; }
                target.Name = Name(alias.AfterCanonical);
            }
            foreach (var method in removals.Keys) { method.DeclaringType.Methods.Remove(method); result.RemovedForwarders++; }
            foreach (var method in constructors) { method.DeclaringType.Methods.Remove(method); result.RemovedImplicitConstructors++; }
            bodies.VerifyObjectIdentity(retained);
            return result;
        }
    }
}
