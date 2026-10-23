// Removes only a compiler-facade InAttribute wrapper, and only when the entire
// resulting canonical TypeSpec equals the pinned original. No other guesses.
using System;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public static class ExactInModifierReversal
    {
        private static TypeReference Strip(TypeReference type)
        {
            var required = type as RequiredModifierType;
            if (required != null)
            {
                var element = Strip(required.ElementType);
                if (required.ModifierType.FullName == "System.Runtime.InteropServices.InAttribute"
                    && CanonicalMetadataSignatures.Assembly(required.ModifierType) == "mscorlib") return element;
                return ReferenceEquals(element, required.ElementType) ? type : new RequiredModifierType(required.ModifierType, element);
            }
            var optional = type as OptionalModifierType;
            if (optional != null)
            {
                var element = Strip(optional.ElementType);
                return ReferenceEquals(element, optional.ElementType) ? type : new OptionalModifierType(optional.ModifierType, element);
            }
            var byref = type as ByReferenceType;
            if (byref != null) { var element = Strip(byref.ElementType); return ReferenceEquals(element, byref.ElementType) ? type : new ByReferenceType(element); }
            var pointer = type as PointerType;
            if (pointer != null) { var element = Strip(pointer.ElementType); return ReferenceEquals(element, pointer.ElementType) ? type : new PointerType(element); }
            var array = type as ArrayType;
            if (array != null)
            {
                var element = Strip(array.ElementType); if (ReferenceEquals(element, array.ElementType)) return type;
                var clone = new ArrayType(element, array.Rank);
                for (int i = 0; i < array.Dimensions.Count; i++) clone.Dimensions[i] = array.Dimensions[i];
                return clone;
            }
            var generic = type as GenericInstanceType;
            if (generic != null)
            {
                var arguments = generic.GenericArguments.Select(Strip).ToArray();
                if (arguments.SequenceEqual(generic.GenericArguments)) return type;
                var clone = new GenericInstanceType(generic.ElementType); foreach (var argument in arguments) clone.GenericArguments.Add(argument); return clone;
            }
            if (type is PinnedType || type is SentinelType || type is FunctionPointerType)
                throw new InvalidDataException("Compiler InAttribute reversal does not support this wrapper");
            return type;
        }
        public static TypeReference Restore(TypeReference compiled, string originalCanonicalType)
        {
            if (CanonicalMetadataSignatures.Type(compiled) == originalCanonicalType) return compiled;
            var stripped = Strip(compiled);
            if (CanonicalMetadataSignatures.Type(stripped) != originalCanonicalType)
                throw new InvalidDataException("TypeSpec differs beyond the audited compiler InAttribute wrapper: compiled=" + CanonicalMetadataSignatures.Type(compiled) + " expected=" + originalCanonicalType);
            return stripped;
        }
    }
}
