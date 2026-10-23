// Metadata-only compiler projection reversal. Never executes inspected code.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public sealed class TypeReferenceAlias
    {
        public string Assembly, OriginalFullName, CompiledFullName;
    }
    public sealed class MethodReferenceAlias
    {
        public string Assembly, OriginalDeclaringType, CompiledDeclaringType;
        public string OriginalName, CompiledName, CompiledCanonicalSignature;
        public string OriginalCanonicalSignature, OriginalCanonicalReturnType;
        public string[] OriginalCanonicalParameterTypes;
    }
    public sealed class FieldReferenceAlias
    {
        public string Assembly, OriginalDeclaringType, CompiledDeclaringType;
        public string OriginalName, CompiledName, CompiledCanonicalType;
    }
    public sealed class ReferenceReversalResult
    {
        public int MethodReferences, FieldReferences, TypeReferences;
        public int MethodSignatureTypes;
        internal readonly List<Tuple<TypeReference, string>> ExpectedTypes = new List<Tuple<TypeReference, string>>();
        internal readonly List<Tuple<MemberReference, string, string>> ExpectedMembers = new List<Tuple<MemberReference, string, string>>();
        internal readonly List<Tuple<MethodReference, MethodReferenceAlias>> ExpectedMethods = new List<Tuple<MethodReference, MethodReferenceAlias>>();
        public void CompleteSignatureRestoration()
        {
            foreach (var pair in ExpectedMethods)
            {
                var method = pair.Item1; var plan = pair.Item2;
                if (plan.OriginalCanonicalSignature == null || plan.OriginalCanonicalReturnType == null
                    || plan.OriginalCanonicalParameterTypes == null || method.Parameters.Count != plan.OriginalCanonicalParameterTypes.Length)
                    throw new InvalidDataException("Original reference signature proof is missing");
                var restoredReturn = ExactInModifierReversal.Restore(method.ReturnType, plan.OriginalCanonicalReturnType);
                if (!ReferenceEquals(restoredReturn, method.ReturnType)) { method.ReturnType = restoredReturn; MethodSignatureTypes++; }
                for (int i = 0; i < method.Parameters.Count; i++)
                {
                    var restored = ExactInModifierReversal.Restore(method.Parameters[i].ParameterType, plan.OriginalCanonicalParameterTypes[i]);
                    if (!ReferenceEquals(restored, method.Parameters[i].ParameterType)) { method.Parameters[i].ParameterType = restored; MethodSignatureTypes++; }
                }
                if (CanonicalMetadataSignatures.Method(method) != plan.OriginalCanonicalSignature)
                    throw new InvalidDataException("Restored MethodRef signature differs from pinned original");
            }
        }
        // Call after the caller has also restored its TypeDef identities.
        public void VerifyFinalNames()
        {
            foreach (var pair in ExpectedTypes)
                if (pair.Item1.FullName != pair.Item2) throw new InvalidDataException("TypeRef restoration failed: " + pair.Item2);
            foreach (var pair in ExpectedMembers)
                if (pair.Item1.Name != pair.Item3 || CanonicalMetadataSignatures.OpenDeclaringType(pair.Item1) != pair.Item2)
                    throw new InvalidDataException("MemberRef restoration failed: " + pair.Item2 + "::" + pair.Item3);
            foreach (var pair in ExpectedMethods)
                if (CanonicalMetadataSignatures.Method(pair.Item1) != pair.Item2.OriginalCanonicalSignature)
                    throw new InvalidDataException("MethodRef signature restoration was not completed");
        }
    }

    /// <summary>
    /// Bind every edit before changing a name. All matches are exact by assembly,
    /// open declaring type and canonical CLI signature. Generic source parameter
    /// names are never used. Caller owns definition/MethodImpl restoration.
    /// </summary>
    public static class MetadataReferenceReversal
    {
        private static string Key(params string[] parts)
        {
            return string.Join("", parts.Select(s => s.Length + ":" + s));
        }
        private static Dictionary<string, T> Unique<T>(IEnumerable<T> values, Func<T, string> key)
        {
            var output = new Dictionary<string, T>(StringComparer.Ordinal);
            foreach (var value in values)
            {
                string identity = key(value);
                if (output.ContainsKey(identity)) throw new InvalidDataException("Duplicate or ambiguous reverse-reference identity: " + identity);
                output.Add(identity, value);
            }
            return output;
        }
        private static MethodReference Element(MethodReference method)
        {
            var instance = method as GenericInstanceMethod;
            return instance == null ? method : instance.ElementMethod;
        }
        private static void AddMethod(HashSet<MethodReference> methods, MethodReference method)
        {
            if (method == null) return;
            methods.Add(Element(method));
        }
        private static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types)
        {
            foreach (var type in types) { yield return type; foreach (var child in Walk(type.NestedTypes)) yield return child; }
        }
        private static void AddType(HashSet<TypeReference> types, TypeReference type)
        {
            if (type == null || !types.Add(type)) return;
            var parameter = type as GenericParameter;
            if (parameter != null) return;
            var instance = type as GenericInstanceType;
            if (instance != null) foreach (var argument in instance.GenericArguments) AddType(types, argument);
            var modifier = type as IModifierType;
            if (modifier != null) AddType(types, modifier.ModifierType);
            var specification = type as TypeSpecification;
            if (specification != null) AddType(types, specification.ElementType);
            var function = type as FunctionPointerType;
            if (function != null)
            {
                AddType(types, function.ReturnType);
                foreach (var item in function.Parameters) AddType(types, item.ParameterType);
            }
            AddType(types, type.DeclaringType);
        }

        public static ReferenceReversalResult Reverse(ModuleDefinition module,
            IEnumerable<TypeReferenceAlias> typeAliases, IEnumerable<MethodReferenceAlias> methodAliases,
            IEnumerable<FieldReferenceAlias> fieldAliases)
        {
            var typeMap = Unique(typeAliases, a => Key(a.Assembly, a.CompiledFullName));
            var methodMap = Unique(methodAliases, a => Key(a.Assembly, a.CompiledDeclaringType, a.CompiledCanonicalSignature));
            var fieldMap = Unique(fieldAliases, a => Key(a.Assembly, a.CompiledDeclaringType, a.CompiledName, a.CompiledCanonicalType));
            var methodNames = new HashSet<string>(methodMap.Values.Select(a => Key(a.Assembly, a.CompiledDeclaringType, a.CompiledName)));
            var fieldNames = new HashSet<string>(fieldMap.Values.Select(a => Key(a.Assembly, a.CompiledDeclaringType, a.CompiledName)));
            var methods = new HashSet<MethodReference>();
            var fields = new HashSet<FieldReference>();
            var types = new HashSet<TypeReference>();
            foreach (var type in module.GetTypeReferences()) AddType(types, type);
            foreach (var member in module.GetMemberReferences())
            {
                if (member is MethodReference method) AddMethod(methods, method);
                else if (member is FieldReference field) fields.Add(field);
            }
            foreach (var type in Walk(module.Types))
            {
                AddType(types, type.BaseType);
                foreach (var item in type.Interfaces) AddType(types, item.InterfaceType);
                foreach (var field in type.Fields) AddType(types, field.FieldType);
                foreach (var method in type.Methods)
                {
                    AddType(types, method.ReturnType);
                    foreach (var parameter in method.Parameters) AddType(types, parameter.ParameterType);
                    foreach (var implementation in method.Overrides) AddMethod(methods, implementation);
                    if (!method.HasBody) continue;
                    foreach (var local in method.Body.Variables) AddType(types, local.VariableType);
                    foreach (var handler in method.Body.ExceptionHandlers) AddType(types, handler.CatchType);
                    foreach (var instruction in method.Body.Instructions)
                    {
                        if (instruction.Operand is MethodReference call)
                        {
                            AddMethod(methods, call);
                            var instance = call as GenericInstanceMethod;
                            if (instance != null) foreach (var argument in instance.GenericArguments) AddType(types, argument);
                        }
                        else if (instruction.Operand is FieldReference field) fields.Add(field);
                        else if (instruction.Operand is TypeReference target) AddType(types, target);
                    }
                }
            }
            foreach (var method in methods)
            {
                AddType(types, method.DeclaringType); AddType(types, method.ReturnType);
                foreach (var parameter in method.Parameters) AddType(types, parameter.ParameterType);
            }
            foreach (var field in fields) { AddType(types, field.DeclaringType); AddType(types, field.FieldType); }

            // No name changes before all candidate selectors have been checked.
            var pendingMethods = new List<Tuple<MethodReference, MethodReferenceAlias>>();
            foreach (var method in methods.Where(m => !(m is MethodDefinition)))
            {
                string assembly = CanonicalMetadataSignatures.Assembly(method.DeclaringType);
                string owner = CanonicalMetadataSignatures.OpenDeclaringType(method);
                MethodReferenceAlias alias;
                if (methodMap.TryGetValue(Key(assembly, owner, CanonicalMetadataSignatures.Method(method)), out alias))
                    pendingMethods.Add(Tuple.Create(method, alias));
                else if (methodNames.Contains(Key(assembly, owner, method.Name)))
                    throw new InvalidDataException("Known projected MethodRef has an unproved signature: " + method.FullName);
            }
            var pendingFields = new List<Tuple<FieldReference, FieldReferenceAlias>>();
            foreach (var field in fields.Where(f => !(f is FieldDefinition)))
            {
                string assembly = CanonicalMetadataSignatures.Assembly(field.DeclaringType);
                string owner = CanonicalMetadataSignatures.OpenDeclaringType(field);
                FieldReferenceAlias alias;
                if (fieldMap.TryGetValue(Key(assembly, owner, field.Name, CanonicalMetadataSignatures.Type(field.FieldType)), out alias))
                    pendingFields.Add(Tuple.Create(field, alias));
                else if (fieldNames.Contains(Key(assembly, owner, field.Name)))
                    throw new InvalidDataException("Known projected FieldRef has an unproved signature: " + field.FullName);
            }
            var pendingTypes = new List<Tuple<TypeReference, TypeReferenceAlias>>();
            foreach (var type in types.Where(t => !(t is TypeDefinition) && !(t is TypeSpecification) && !(t is GenericParameter)))
            {
                TypeReferenceAlias alias;
                if (typeMap.TryGetValue(Key(CanonicalMetadataSignatures.Assembly(type), type.FullName), out alias))
                    pendingTypes.Add(Tuple.Create(type, alias));
            }
            var result = new ReferenceReversalResult();
            foreach (var pair in pendingMethods)
            {
                if (pair.Item1.Name != pair.Item2.OriginalName) { pair.Item1.Name = pair.Item2.OriginalName; result.MethodReferences++; }
                result.ExpectedMembers.Add(Tuple.Create((MemberReference)pair.Item1, pair.Item2.OriginalDeclaringType, pair.Item2.OriginalName));
                result.ExpectedMethods.Add(pair);
            }
            foreach (var pair in pendingFields)
            {
                if (pair.Item1.Name != pair.Item2.OriginalName) { pair.Item1.Name = pair.Item2.OriginalName; result.FieldReferences++; }
                result.ExpectedMembers.Add(Tuple.Create((MemberReference)pair.Item1, pair.Item2.OriginalDeclaringType, pair.Item2.OriginalName));
            }
            foreach (var pair in pendingTypes)
            {
                var type = pair.Item1; string original = pair.Item2.OriginalFullName;
                int nested = original.LastIndexOf('/');
                int separator = nested >= 0 ? nested : original.LastIndexOf('.');
                string name = original.Substring(separator + 1);
                string ns = nested >= 0 ? type.Namespace : separator < 0 ? "" : original.Substring(0, separator);
                bool renamed = type.Name != name || type.Namespace != ns;
                // Cecil caches nested FullName independently of its parent.
                // Reassign the exact reviewed components even when unchanged,
                // invalidating stale child caches after a parent identity edit.
                type.Name = name; type.Namespace = ns;
                if (renamed) result.TypeReferences++;
                result.ExpectedTypes.Add(Tuple.Create(type, original));
            }
            return result;
        }
    }
}
