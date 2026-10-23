// Clones TypeSpec graphs for comparison only. Original metadata is not changed.
using System;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public static class ProjectedCanonicalSignatures
    {
        public static TypeReference CloneType(TypeReference type, Func<TypeReference, string> projectedFullName)
        {
            if (type is GenericParameter) return type; // Identity uses owner kind + position, not name.
            var generic = type as GenericInstanceType;
            if (generic != null)
            {
                var clone = new GenericInstanceType(CloneType(generic.ElementType, projectedFullName));
                foreach (var argument in generic.GenericArguments) clone.GenericArguments.Add(CloneType(argument, projectedFullName));
                return clone;
            }
            var array = type as ArrayType;
            if (array != null)
            {
                var clone = new ArrayType(CloneType(array.ElementType, projectedFullName), array.Rank);
                for (int i = 0; i < array.Dimensions.Count; i++) clone.Dimensions[i] = array.Dimensions[i];
                return clone;
            }
            var byref = type as ByReferenceType;
            if (byref != null) return new ByReferenceType(CloneType(byref.ElementType, projectedFullName));
            var pointer = type as PointerType;
            if (pointer != null) return new PointerType(CloneType(pointer.ElementType, projectedFullName));
            var required = type as RequiredModifierType;
            if (required != null) return new RequiredModifierType(CloneType(required.ModifierType, projectedFullName), CloneType(required.ElementType, projectedFullName));
            var optional = type as OptionalModifierType;
            if (optional != null) return new OptionalModifierType(CloneType(optional.ModifierType, projectedFullName), CloneType(optional.ElementType, projectedFullName));
            var pinned = type as PinnedType;
            if (pinned != null) return new PinnedType(CloneType(pinned.ElementType, projectedFullName));
            var sentinel = type as SentinelType;
            if (sentinel != null) return new SentinelType(CloneType(sentinel.ElementType, projectedFullName));
            var function = type as FunctionPointerType;
            if (function != null)
            {
                var clone = new FunctionPointerType { HasThis = function.HasThis, ExplicitThis = function.ExplicitThis,
                    CallingConvention = function.CallingConvention, ReturnType = CloneType(function.ReturnType, projectedFullName) };
                foreach (var parameter in function.Parameters) clone.Parameters.Add(new ParameterDefinition(CloneType(parameter.ParameterType, projectedFullName)));
                return clone;
            }
            if (type is TypeSpecification) throw new InvalidOperationException("Unsupported projected TypeSpec: " + type.GetType().FullName);
            string fullName = projectedFullName(type);
            int nested = fullName.LastIndexOf('/'); int separator = nested >= 0 ? nested : fullName.LastIndexOf('.');
            string ns = nested >= 0 ? type.Namespace : separator >= 0 ? fullName.Substring(0, separator) : "";
            var result = new TypeReference(ns, fullName.Substring(separator + 1), type.Module, type.Scope, type.IsValueType);
            if (type.DeclaringType != null) result.DeclaringType = CloneType(type.DeclaringType, projectedFullName);
            if (result.FullName != fullName) throw new InvalidOperationException("Projected nested type mapping is inconsistent: " + fullName);
            return result;
        }

        public static string Type(TypeReference type, Func<TypeReference, string> projectedFullName)
        {
            return CanonicalMetadataSignatures.Type(CloneType(type, projectedFullName));
        }

        public static string Method(MethodReference method, Func<TypeReference, string> projectedFullName)
        {
            if (method is GenericInstanceMethod) throw new InvalidOperationException("Definition projection requires an open MethodDef");
            var clone = new MethodReference(method.Name, CloneType(method.ReturnType, projectedFullName), CloneType(method.DeclaringType, projectedFullName))
            { HasThis = method.HasThis, ExplicitThis = method.ExplicitThis, CallingConvention = method.CallingConvention };
            foreach (var parameter in method.GenericParameters) clone.GenericParameters.Add(new GenericParameter(parameter.Name, clone));
            foreach (var parameter in method.Parameters) clone.Parameters.Add(new ParameterDefinition(CloneType(parameter.ParameterType, projectedFullName)));
            return CanonicalMetadataSignatures.Method(clone);
        }
    }
}
