// Recovery-tool utility only. It reads metadata; it never loads inspected code.
using System;
using System.Globalization;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    /// <summary>
    /// An unambiguous, name-independent identity for TypeSpecs in MethodRefs.
    /// External MemberRefs often retain !0 but cannot retain a source parameter
    /// name such as T. FullName string matching is therefore insufficient.
    /// </summary>
    public static class CanonicalMetadataSignatures
    {
        private static string Part(string value)
        {
            value = value ?? "";
            return value.Length.ToString(CultureInfo.InvariantCulture) + ":" + value;
        }

        public static string Assembly(TypeReference type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (type is GenericParameter) throw new InvalidOperationException("A generic parameter has no assembly identity");
            if (type is TypeSpecification specification) return Assembly(specification.ElementType);
            if (type.DeclaringType != null) return Assembly(type.DeclaringType);
            var assembly = type.Scope as AssemblyNameReference;
            if (assembly != null) return assembly.Name;
            var module = type.Scope as ModuleDefinition;
            if (module != null && module.Assembly != null) return module.Assembly.Name.Name;
            throw new InvalidOperationException("Unsupported TypeRef scope: " + type.FullName);
        }

        public static string Type(TypeReference type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var parameter = type as GenericParameter;
            if (parameter != null)
                return (parameter.Type == GenericParameterType.Method ? "!!" : "!")
                    + parameter.Position.ToString(CultureInfo.InvariantCulture) + ";";
            var instance = type as GenericInstanceType;
            if (instance != null)
                return "G(" + Type(instance.ElementType) + ")[" + string.Join("", instance.GenericArguments.Select(Type)) + "]";
            var array = type as ArrayType;
            if (array != null)
            {
                string dimensions = string.Join(",", array.Dimensions.Select(d =>
                    (d.LowerBound.HasValue ? d.LowerBound.Value.ToString(CultureInfo.InvariantCulture) : "?") + ":"
                    + (d.UpperBound.HasValue ? d.UpperBound.Value.ToString(CultureInfo.InvariantCulture) : "?")));
                return (array.IsVector ? "V(" : "A" + array.Rank.ToString(CultureInfo.InvariantCulture) + "(" )
                    + Type(array.ElementType) + ")[" + dimensions + "]";
            }
            var byref = type as ByReferenceType;
            if (byref != null) return "R(" + Type(byref.ElementType) + ")";
            var pointer = type as PointerType;
            if (pointer != null) return "P(" + Type(pointer.ElementType) + ")";
            var required = type as RequiredModifierType;
            if (required != null) return "Q(" + Type(required.ModifierType) + "," + Type(required.ElementType) + ")";
            var optional = type as OptionalModifierType;
            if (optional != null) return "O(" + Type(optional.ModifierType) + "," + Type(optional.ElementType) + ")";
            var pinned = type as PinnedType;
            if (pinned != null) return "I(" + Type(pinned.ElementType) + ")";
            var sentinel = type as SentinelType;
            if (sentinel != null) return "S(" + Type(sentinel.ElementType) + ")";
            var function = type as FunctionPointerType;
            if (function != null)
                return "F" + (int)function.CallingConvention + ":" + (function.HasThis ? "1" : "0")
                    + (function.ExplicitThis ? "1" : "0") + "(" + Type(function.ReturnType) + ")["
                    + string.Join("", function.Parameters.Select(p => Type(p.ParameterType))) + "]";
            if (type is TypeSpecification)
                throw new InvalidOperationException("Unsupported TypeSpec: " + type.GetType().FullName);
            return "N" + Part(Assembly(type)) + Part(type.FullName);
        }

        public static string Method(MethodReference method)
        {
            var instance = method as GenericInstanceMethod;
            if (instance != null)
                return "J(" + Method(instance.ElementMethod) + ")[" + string.Join("", instance.GenericArguments.Select(Type)) + "]";
            return "M" + Part(method.Name) + method.GenericParameters.Count.ToString(CultureInfo.InvariantCulture)
                + ":" + (int)method.CallingConvention + ":" + (method.HasThis ? "1" : "0")
                + (method.ExplicitThis ? "1" : "0") + "(" + Type(method.ReturnType) + ")["
                + string.Join("", method.Parameters.Select(p => Type(p.ParameterType))) + "]";
        }

        public static string OpenDeclaringType(MemberReference member)
        {
            if (member.DeclaringType == null) throw new InvalidOperationException("Missing declaring type");
            return member.DeclaringType.GetElementType().FullName;
        }
    }
}
