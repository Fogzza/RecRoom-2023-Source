// Metadata-only exact projection reversal. This is not a gameplay implementation.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public sealed class ExactMethodPlan
    {
        public string OriginalCanonicalSignature, CompiledCanonicalSignature;
        public int OriginalAttributes, OriginalImplAttributes, OriginalSemantics;
    }
    public sealed class ExactFieldPlan
    {
        public string OriginalName, CompiledName, OriginalCanonicalType, CompiledCanonicalType;
        public int OriginalAttributes;
    }
    public sealed class ExactPropertyPlan
    {
        public string OriginalName, CompiledName, OriginalCanonicalType, CompiledCanonicalType;
        public string[] OriginalCanonicalParameters, CompiledCanonicalParameters;
        public int OriginalAttributes;
    }
    public sealed class ExactTypePlan
    {
        public string OriginalFullName, CompiledFullName;
        public int OriginalMethodCount, OriginalFieldCount, MissingOriginalMethodCount;
        public ExactMethodPlan[] Methods;
        public ExactFieldPlan[] Fields;
        public ExactPropertyPlan[] Properties;
        public ExactEventPlan[] Events;
    }
    public sealed class ExactEventPlan
    {
        public string OriginalName, CompiledName, OriginalCanonicalType, CompiledCanonicalType;
        public int OriginalAttributes;
    }
    public sealed class DefinitionRestorationResult
    {
        public int Types, Methods, Fields, Properties, Events, SerializationAttributes, MethodImplementations, InitialValueBytes;
    }

    public static class MetadataDefinitionRestoration
    {
        private static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> values)
        {
            foreach (var type in values) { yield return type; foreach (var child in Walk(type.NestedTypes)) yield return child; }
        }
        private static T One<T>(IEnumerable<T> values, string description)
        {
            var matches = values.Take(2).ToArray();
            if (matches.Length != 1) throw new InvalidDataException("Expected exactly one " + description);
            return matches[0];
        }
        private static bool Serialization(CustomAttribute attribute)
        {
            string name = attribute.AttributeType.FullName;
            return name == "UnityEngine.SerializeField" || name == "UnityEngine.SerializeReference"
                || name == "UnityEngine.Serialization.FormerlySerializedAsAttribute";
        }
        private static bool PropertyMatches(PropertyDefinition property, string name, string type, string[] parameters)
        {
            return property.Name == name && CanonicalMetadataSignatures.Type(property.PropertyType) == type
                && property.Parameters.Select(p => CanonicalMetadataSignatures.Type(p.ParameterType)).SequenceEqual(parameters);
        }
        private sealed class Binding
        {
            public ExactTypePlan Plan;
            public TypeDefinition Compiled, Original, Serialization;
            public readonly List<Tuple<MethodDefinition, MethodDefinition>> Methods = new List<Tuple<MethodDefinition, MethodDefinition>>();
            public readonly List<Tuple<FieldDefinition, FieldDefinition, FieldDefinition>> Fields = new List<Tuple<FieldDefinition, FieldDefinition, FieldDefinition>>();
            public readonly List<Tuple<PropertyDefinition, PropertyDefinition>> Properties = new List<Tuple<PropertyDefinition, PropertyDefinition>>();
            public readonly List<Tuple<EventDefinition, EventDefinition>> Events = new List<Tuple<EventDefinition, EventDefinition>>();
        }

        /// <summary>
        /// Resolve before any reference/type renaming. Every count, selector and
        /// manifest flag is checked against pinned original metadata. The returned
        /// action changes definitions only; call after reversing compiled refs.
        /// </summary>
        public static Action<DefinitionRestorationResult> Bind(ModuleDefinition compiled, ModuleDefinition original,
            ModuleDefinition serialization, IEnumerable<ExactTypePlan> plans, SerializationFieldWitnessPlan[] serializationWitnesses)
        {
            var compiledTypes = Walk(compiled.Types).ToDictionary(t => t.FullName);
            var rawTypes = Walk(original.Types).ToDictionary(t => t.FullName);
            var serializationTypes = Walk(serialization.Types).ToDictionary(t => t.FullName);
            var bindings = new List<Binding>();
            var uniqueTypes = new HashSet<TypeDefinition>();
            var uniqueMethods = new HashSet<MethodDefinition>();
            foreach (var plan in plans)
            {
                var binding = new Binding { Plan = plan,
                    Compiled = compiledTypes[plan.CompiledFullName],
                    Original = rawTypes[plan.OriginalFullName],
                    Serialization = serializationTypes[plan.OriginalFullName] };
                if (!uniqueTypes.Add(binding.Compiled)) throw new InvalidDataException("Duplicate definition type plan");
                if (binding.Compiled.Methods.Count + plan.MissingOriginalMethodCount != plan.OriginalMethodCount || binding.Original.Methods.Count != plan.OriginalMethodCount
                    || binding.Compiled.Fields.Count != plan.OriginalFieldCount || binding.Original.Fields.Count != plan.OriginalFieldCount
                    || plan.Fields.Length != plan.OriginalFieldCount)
                    throw new InvalidDataException("Original method/field count differs: " + plan.OriginalFullName);
                foreach (var methodPlan in plan.Methods)
                {
                    var method = One(binding.Compiled.Methods.Where(m => CanonicalMetadataSignatures.Method(m) == methodPlan.CompiledCanonicalSignature), "compiled method");
                    var raw = One(binding.Original.Methods.Where(m => CanonicalMetadataSignatures.Method(m) == methodPlan.OriginalCanonicalSignature), "raw method");
                    if (!uniqueMethods.Add(method)) throw new InvalidDataException("Duplicate accessor binding");
                    if ((int)raw.Attributes != methodPlan.OriginalAttributes || (int)raw.ImplAttributes != methodPlan.OriginalImplAttributes
                        || (int)raw.SemanticsAttributes != methodPlan.OriginalSemantics)
                        throw new InvalidDataException("Manifest method flags differ from pinned metadata");
                    if (method.Parameters.Count != raw.Parameters.Count || method.GenericParameters.Count != raw.GenericParameters.Count
                        || method.HasBody != raw.HasBody || method.IsPInvokeImpl != raw.IsPInvokeImpl || (raw.IsPInvokeImpl && (method.PInvokeInfo != null || raw.PInvokeInfo != null)))
                        throw new InvalidDataException("Unsupported method shape change: " + raw.FullName + " rawBody=" + raw.HasBody + " compiledBody=" + method.HasBody + " rawPInvoke=" + raw.IsPInvokeImpl + " compiledPInvoke=" + method.IsPInvokeImpl + " rawImpl=" + raw.ImplAttributes + " compiledImpl=" + method.ImplAttributes);
                    if (method.Parameters.Any(p => p.HasMarshalInfo) || raw.Parameters.Any(p => p.HasMarshalInfo)
                        || method.MethodReturnType.HasMarshalInfo || raw.MethodReturnType.HasMarshalInfo)
                        throw new InvalidDataException("Marshal metadata requires an explicit plan");
                    for (int p = 0; p < method.Parameters.Count; p++)
                        if (method.Parameters[p].HasConstant && !raw.Parameters[p].HasConstant)
                            throw new InvalidDataException("Unexpected compiler parameter constant");
                    binding.Methods.Add(Tuple.Create(method, raw));
                }
                var seenFields = new HashSet<FieldDefinition>();
                foreach (var fieldPlan in plan.Fields)
                {
                    var field = One(binding.Compiled.Fields.Where(f => f.Name == fieldPlan.CompiledName
                        && CanonicalMetadataSignatures.Type(f.FieldType) == fieldPlan.CompiledCanonicalType), "compiled field " + plan.OriginalFullName + "::" + fieldPlan.OriginalName + " planned=" + fieldPlan.CompiledName + ":" + fieldPlan.CompiledCanonicalType);
                    var raw = One(binding.Original.Fields.Where(f => f.Name == fieldPlan.OriginalName
                        && CanonicalMetadataSignatures.Type(f.FieldType) == fieldPlan.OriginalCanonicalType), "raw field");
                    var serialMatches = binding.Serialization.Fields.Where(f => f.Name == fieldPlan.OriginalName
                        && CanonicalMetadataSignatures.Type(f.FieldType) == fieldPlan.OriginalCanonicalType).Take(2).ToArray();
                    var serial = serialMatches.Length == 1 ? serialMatches[0] : SerializationFieldIdentityWitness.Resolve(serialization, raw, fieldPlan.OriginalCanonicalType, serializationWitnesses);
                    if (!seenFields.Add(field) || (int)raw.Attributes != fieldPlan.OriginalAttributes || field.HasMarshalInfo || raw.HasMarshalInfo)
                        throw new InvalidDataException("Ambiguous field or unsupported field flags");
                    if (field.HasConstant != raw.HasConstant || (field.HasConstant && !Equals(field.Constant, raw.Constant)))
                        throw new InvalidDataException("Compiler field constant differs from original");
                    binding.Fields.Add(Tuple.Create(field, raw, serial));
                }
                foreach (var propertyPlan in plan.Properties)
                {
                    var property = One(binding.Compiled.Properties.Where(p => PropertyMatches(p, propertyPlan.CompiledName,
                        propertyPlan.CompiledCanonicalType, propertyPlan.CompiledCanonicalParameters)), "compiled property");
                    var raw = One(binding.Original.Properties.Where(p => PropertyMatches(p, propertyPlan.OriginalName,
                        propertyPlan.OriginalCanonicalType, propertyPlan.OriginalCanonicalParameters)), "raw property");
                    if ((int)raw.Attributes != propertyPlan.OriginalAttributes || raw.HasOtherMethods || property.HasOtherMethods
                        || property.HasConstant != raw.HasConstant || (property.HasConstant && !Equals(property.Constant, raw.Constant)))
                        throw new InvalidDataException("Property shape differs from original");
                    foreach (var pair in new[] { Tuple.Create(property.GetMethod, raw.GetMethod), Tuple.Create(property.SetMethod, raw.SetMethod) })
                    {
                        if ((pair.Item1 == null) != (pair.Item2 == null)
                            || (pair.Item1 != null && !binding.Methods.Any(m => ReferenceEquals(m.Item1, pair.Item1) && ReferenceEquals(m.Item2, pair.Item2))))
                            throw new InvalidDataException("Property accessor ownership is not proven");
                    }
                    binding.Properties.Add(Tuple.Create(property, raw));
                }
                foreach (var eventPlan in plan.Events ?? new ExactEventPlan[0])
                {
                    var item = One(binding.Compiled.Events.Where(e => e.Name == eventPlan.CompiledName
                        && CanonicalMetadataSignatures.Type(e.EventType) == eventPlan.CompiledCanonicalType), "compiled event");
                    var raw = One(binding.Original.Events.Where(e => e.Name == eventPlan.OriginalName
                        && CanonicalMetadataSignatures.Type(e.EventType) == eventPlan.OriginalCanonicalType), "raw event");
                    if ((int)raw.Attributes != eventPlan.OriginalAttributes || raw.HasOtherMethods || item.HasOtherMethods)
                        throw new InvalidDataException("Event shape differs from original");
                    foreach (var pair in new[] { Tuple.Create(item.AddMethod, raw.AddMethod), Tuple.Create(item.RemoveMethod, raw.RemoveMethod), Tuple.Create(item.InvokeMethod, raw.InvokeMethod) })
                        if ((pair.Item1 == null) != (pair.Item2 == null)
                            || (pair.Item1 != null && !binding.Methods.Any(m => ReferenceEquals(m.Item1, pair.Item1) && ReferenceEquals(m.Item2, pair.Item2))))
                            throw new InvalidDataException("Event accessor ownership is not proven");
                    binding.Events.Add(Tuple.Create(item, raw));
                }
                bindings.Add(binding);
            }
            return result =>
            {
                foreach (var binding in bindings)
                {
                    // All identity-bearing definitions were resolved before this action.
                    binding.Compiled.Name = binding.Original.Name;
                    binding.Compiled.Namespace = binding.Original.Namespace;
                    result.Types++;
                    foreach (var pair in binding.Fields)
                    {
                        var field = pair.Item1; var raw = pair.Item2; var serial = pair.Item3;
                        field.Name = raw.Name; field.Attributes = raw.Attributes;
                        if ((raw.Attributes & FieldAttributes.HasFieldRVA) != 0)
                        {
                            if (raw.InitialValue == null || raw.InitialValue.Length == 0) throw new InvalidDataException("Original RVA data missing");
                            field.InitialValue = (byte[])raw.InitialValue.Clone(); result.InitialValueBytes += raw.InitialValue.Length;
                        }
                        else if (field.InitialValue != null && field.InitialValue.Length != 0)
                            throw new InvalidDataException("Unexpected compiler RVA data");
                        for (int i = field.CustomAttributes.Count - 1; i >= 0; i--)
                            if (Serialization(field.CustomAttributes[i])) field.CustomAttributes.RemoveAt(i);
                        foreach (var attribute in serial.CustomAttributes.Where(Serialization))
                        {
                            field.CustomAttributes.Add(new CustomAttribute(ExactCliMarkerConstructor.Import(compiled, attribute.Constructor), attribute.GetBlob()));
                            result.SerializationAttributes++;
                        }
                        result.Fields++;
                    }
                    foreach (var pair in binding.Methods)
                    {
                        var method = pair.Item1; var raw = pair.Item2;
                        method.Name = raw.Name; method.Attributes = raw.Attributes; method.ImplAttributes = raw.ImplAttributes;
                        // Cecil 0.11.4 setter does not mark its image-backed cache ready.
                        // Materialize the compiled value before assigning the exact raw value.
                        if (method.SemanticsAttributes != raw.SemanticsAttributes)
                            method.SemanticsAttributes = raw.SemanticsAttributes;
                        for (int p = 0; p < method.Parameters.Count; p++)
                        {
                            method.Parameters[p].Name = raw.Parameters[p].Name; method.Parameters[p].Attributes = raw.Parameters[p].Attributes;
                            if (raw.Parameters[p].HasConstant) method.Parameters[p].Constant = raw.Parameters[p].Constant;
                        }
                        method.MethodReturnType.Name = raw.MethodReturnType.Name;
                        method.MethodReturnType.Attributes = raw.MethodReturnType.Attributes;
                        method.Overrides.Clear();
                        foreach (var implementation in raw.Overrides)
                        {
                            method.Overrides.Add(compiled.ImportReference(implementation, method)); result.MethodImplementations++;
                        }
                        result.Methods++;
                    }
                    foreach (var pair in binding.Properties)
                    {
                        pair.Item1.Name = pair.Item2.Name; pair.Item1.Attributes = pair.Item2.Attributes; result.Properties++;
                    }
                    foreach (var pair in binding.Events) { pair.Item1.Name = pair.Item2.Name; pair.Item1.Attributes = pair.Item2.Attributes; result.Events++; }
                }
                foreach (var binding in bindings)
                    if (binding.Compiled.FullName != binding.Plan.OriginalFullName)
                        throw new InvalidDataException("Restored nested TypeDef identity differs");
                foreach (var binding in bindings)
                    foreach (var pair in binding.Methods)
                    {
                        pair.Item1.ReturnType = ExactInModifierReversal.Restore(pair.Item1.ReturnType, CanonicalMetadataSignatures.Type(pair.Item2.ReturnType));
                        for (int p = 0; p < pair.Item1.Parameters.Count; p++)
                            pair.Item1.Parameters[p].ParameterType = ExactInModifierReversal.Restore(pair.Item1.Parameters[p].ParameterType,
                                CanonicalMetadataSignatures.Type(pair.Item2.Parameters[p].ParameterType));
                        if (CanonicalMetadataSignatures.Method(pair.Item1) != CanonicalMetadataSignatures.Method(pair.Item2))
                            throw new InvalidDataException("Restored MethodDef signature differs from pinned original");
                    }
                foreach (var binding in bindings)
                    foreach (var pair in binding.Properties)
                    {
                        pair.Item1.PropertyType = ExactInModifierReversal.Restore(pair.Item1.PropertyType, CanonicalMetadataSignatures.Type(pair.Item2.PropertyType));
                        for (int p = 0; p < pair.Item1.Parameters.Count; p++)
                            pair.Item1.Parameters[p].ParameterType = ExactInModifierReversal.Restore(pair.Item1.Parameters[p].ParameterType,
                                CanonicalMetadataSignatures.Type(pair.Item2.Parameters[p].ParameterType));
                    }
            };
        }
    }
}
