// Exact, token-backed reversal of the C# compiler's readonly-return projection.
// The old provider loses byref TypeSpecs, so it is never a shape authority.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public sealed class ReadonlyAttributePlan
    {
        public string OriginalType, CompiledType, OriginalProperty, CompiledProperty, OriginalGetterCanonical, CompiledGetterCanonical;
        public string CompiledCanonicalPropertyType;
        public string[] CompiledCanonicalPropertyParameters;
        public string ProviderHash, ConstructorFullName, ConstructorAssembly;
        public uint DeclaringTypeToken, PropertyToken, GetterToken;
        public byte[] Blob;
        public bool OriginalPropertyHasAttribute, OriginalGetterReturnHasAttribute;
    }
    public static class ReadonlyAttributeRestoration
    {
        private const string AttributeName = "System.Runtime.CompilerServices.IsReadOnlyAttribute";
        private static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> values)
        {
            foreach (var item in values) { yield return item; foreach (var child in Walk(item.NestedTypes)) yield return child; }
        }
        private static T One<T>(IEnumerable<T> values, string description)
        {
            var items = values.Take(2).ToArray(); if (items.Length != 1) throw new InvalidDataException("Readonly ownership join is ambiguous: " + description); return items[0];
        }
        private static uint OriginalToken(ICustomAttributeProvider owner)
        {
            var marker = One(owner.CustomAttributes.Where(a => a.AttributeType.FullName == "Cpp2IlInjected.TokenAttribute"), "original token marker");
            var field = One(marker.Fields.Where(f => f.Name == "Token"), "original token field");
            string value = field.Argument.Value as string;
            if (value == null || !value.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) throw new InvalidDataException("Invalid original token marker");
            return uint.Parse(value.Substring(2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
        }
        private static CustomAttribute[] Readonly(ICustomAttributeProvider owner)
        {
            return owner.CustomAttributes.Where(a => a.AttributeType.FullName == AttributeName).ToArray();
        }
        private static void Match(CustomAttribute attribute, ReadonlyAttributePlan plan)
        {
            if (attribute.Constructor.FullName != plan.ConstructorFullName
                || CanonicalMetadataSignatures.Assembly(attribute.AttributeType) != plan.ConstructorAssembly || !attribute.GetBlob().SequenceEqual(plan.Blob))
                throw new InvalidDataException("Readonly attribute constructor/blob differs from pinned provider");
        }
        private static void Remove(ICustomAttributeProvider owner)
        {
            for (int i = owner.CustomAttributes.Count - 1; i >= 0; i--)
                if (owner.CustomAttributes[i].AttributeType.FullName == AttributeName) owner.CustomAttributes.RemoveAt(i);
        }
        // One native-backed named marker identity. The serialization provider
        // erased this PKT; preserve its blob/ownership, not its erased identity.
        private static MethodReference ImportNativeReadonlyMarker(ModuleDefinition target, MethodReference original)
        {
            const string nativeScope = "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            const string providerScope = "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null";
            var owner = original == null ? null : original.DeclaringType;
            var scope = owner == null ? null : owner.Scope as AssemblyNameReference;
            if (original == null || original is MethodSpecification || owner.FullName != AttributeName || owner.DeclaringType != null
                || owner.IsValueType || scope == null || scope.FullName != providerScope || (int)scope.Attributes != 0
                || original.Name != ".ctor" || !original.HasThis || original.ExplicitThis
                || original.CallingConvention != MethodCallingConvention.Default || original.GenericParameters.Count != 0
                || original.Parameters.Count != 0 || original.ReturnType.MetadataType != MetadataType.Void || original.ReturnType.FullName != "System.Void")
                throw new InvalidDataException("Only the exact erased-key serialization readonly marker ctor is permitted");
            var signed = target.AssemblyReferences.Where(r => r.FullName == nativeScope && (int)r.Attributes == 0).ToArray();
            if (signed.Length != 1 || target.AssemblyReferences.Any(r => r.FullName == providerScope))
                throw new InvalidDataException("Exactly one existing native signed corelib reference and no erased-key corelib are required");
            // Do not ImportReference(original): that would first add the erased-key row.
            var nativeType = new TypeReference("System.Runtime.CompilerServices", "IsReadOnlyAttribute", target, signed[0], false);
            return new MethodReference(".ctor", target.TypeSystem.Void, nativeType) {
                HasThis = true, ExplicitThis = false, CallingConvention = MethodCallingConvention.Default };
        }

        public static Action Bind(ModuleDefinition compiled, ModuleDefinition raw, ModuleDefinition originalProvider,
            IEnumerable<ReadonlyAttributePlan> plans, string providerHash)
        {
            var originals = Walk(originalProvider.Types).ToDictionary(t => t.FullName); var rawTypes = Walk(raw.Types).ToDictionary(t => t.FullName);
            var compiledTypes = Walk(compiled.Types).ToArray(); var actions = new List<Action>();
            foreach (var plan in plans)
            {
                if (plan.ProviderHash != providerHash || !plan.OriginalPropertyHasAttribute) throw new InvalidDataException("Unsupported readonly ownership provider/projection");
                var originalType = originals[plan.OriginalType]; var rawType = rawTypes[plan.OriginalType];
                var originalProperty = One(originalType.Properties.Where(p => p.Name == plan.OriginalProperty && OriginalToken(p) == plan.PropertyToken), "provider property");
                var originalGetter = originalProperty.GetMethod;
                if (originalGetter == null || OriginalToken(originalType) != plan.DeclaringTypeToken || OriginalToken(originalGetter) != plan.GetterToken)
                    throw new InvalidDataException("Readonly original type/getter token differs");
                var rawProperty = One(rawType.Properties.Where(p => p.Name == plan.OriginalProperty && p.GetMethod != null
                    && CanonicalMetadataSignatures.Method(p.GetMethod) == plan.OriginalGetterCanonical), "modern byref property");
                if (rawProperty.GetMethod.Name != originalGetter.Name) throw new InvalidDataException("Original readonly accessor identities disagree");
                var target = One(compiledTypes.SelectMany(t => t.Properties).Where(p => p.Name == plan.CompiledProperty && p.GetMethod != null
                    && CanonicalMetadataSignatures.Method(p.GetMethod) == plan.CompiledGetterCanonical
                    && p.DeclaringType.FullName == plan.CompiledType), "compiled readonly property");
                var originalAttribute = One(Readonly(originalProperty), "provider readonly attribute"); Match(originalAttribute, plan);
                var originalReturnAttributes = Readonly(originalGetter.MethodReturnType);
                if (originalReturnAttributes.Length != (plan.OriginalGetterReturnHasAttribute ? 1 : 0)) throw new InvalidDataException("Original return attribute ownership differs");
                foreach (var attribute in originalReturnAttributes) Match(attribute, plan);
                var compiledReturn = One(Readonly(target.GetMethod.MethodReturnType), "compiler readonly getter return attribute"); Match(compiledReturn, plan);
                var compiledPropertyAttributes = Readonly(target);
                if (compiledPropertyAttributes.Length > 1) throw new InvalidDataException("Duplicate compiler readonly property attributes");
                foreach (var attribute in compiledPropertyAttributes) Match(attribute, plan);
                actions.Add(() => {
                    Remove(target); target.CustomAttributes.Add(new CustomAttribute(ImportNativeReadonlyMarker(compiled, originalAttribute.Constructor), originalAttribute.GetBlob()));
                    Remove(target.GetMethod.MethodReturnType);
                    foreach (var attribute in originalReturnAttributes)
                        target.GetMethod.MethodReturnType.CustomAttributes.Add(new CustomAttribute(ImportNativeReadonlyMarker(compiled, attribute.Constructor), attribute.GetBlob()));
                });
            }
            return () => { foreach (var action in actions) action(); };
        }
    }
}
