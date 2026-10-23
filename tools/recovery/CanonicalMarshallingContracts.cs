// Metadata-tool code only. No inspected SDK or client code is loaded/executed.
using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public static class CanonicalMarshallingContracts
    {
        private static string Number(int value) { return value.ToString(CultureInfo.InvariantCulture); }
        private static string Part(string value) { if (value == null) throw new InvalidDataException("Null import name"); return Number(value.Length) + ":" + value; }
        private static void NonnegativeOrAbsent(int value, string name) { if (value < -1) throw new InvalidDataException("Invalid marshal " + name); }
        private static bool Scalar(NativeType type)
        {
            int n = (int)type;
            // Exact known non-structured ECMA/Cecil native descriptors only.
            return Enum.IsDefined(typeof(NativeType), type) && ((n >= 2 && n <= 12) || n == 15 || (n >= 19 && n <= 22) || (n >= 25 && n <= 28) || (n >= 31 && n <= 38) || n == 40 || n == 43 || n == 45 || n == 46 || n == 48);
        }
        private static void Element(NativeType type) { if ((int)type != 80 && (int)type != 102 && !Scalar(type)) throw new NotSupportedException("Unsupported marshal element descriptor " + (int)type); }
        public static string MarshalDescriptor(MarshalInfo info)
        {
            if (info == null) return "null";
            Type exact = info.GetType();
            if (exact == typeof(MarshalInfo)) { if (!Scalar(info.NativeType)) throw new NotSupportedException("Unsupported scalar marshal descriptor " + (int)info.NativeType); return "base:" + Number((int)info.NativeType); }
            if (exact == typeof(FixedSysStringMarshalInfo)) { var value = (FixedSysStringMarshalInfo)info; if ((int)value.NativeType != 23 || value.Size < 0) throw new InvalidDataException("Invalid fixed-string marshal"); return "fixed-string:23:" + Number(value.Size); }
            if (exact == typeof(FixedArrayMarshalInfo)) { var value = (FixedArrayMarshalInfo)info; if ((int)value.NativeType != 30 || value.Size < 0) throw new InvalidDataException("Invalid fixed-array marshal"); Element(value.ElementType); return "fixed-array:30:" + Number(value.Size) + ":" + Number((int)value.ElementType); }
            if (exact == typeof(ArrayMarshalInfo)) { var value = (ArrayMarshalInfo)info; if ((int)value.NativeType != 42) throw new InvalidDataException("Invalid array marshal"); Element(value.ElementType); NonnegativeOrAbsent(value.Size, "array size"); NonnegativeOrAbsent(value.SizeParameterIndex, "array parameter index"); NonnegativeOrAbsent(value.SizeParameterMultiplier, "array multiplier"); if ((value.Size >= 0 && value.SizeParameterIndex < 0) || (value.SizeParameterMultiplier >= 0 && value.Size < 0)) throw new InvalidDataException("Nonrepresentable positional marshal array shape"); return "array:42:" + Number((int)value.ElementType) + ":" + Number(value.Size) + ":" + Number(value.SizeParameterIndex) + ":" + Number(value.SizeParameterMultiplier); }
            throw new NotSupportedException("Unsupported marshal descriptor class " + exact.FullName);
        }
        public static MarshalInfo Clone(MarshalInfo info)
        {
            MarshalDescriptor(info); // Validate all shape fields before allocating/mutating.
            if (info == null) return null;
            if (info.GetType() == typeof(MarshalInfo)) return new MarshalInfo(info.NativeType);
            if (info.GetType() == typeof(FixedSysStringMarshalInfo)) return new FixedSysStringMarshalInfo { Size = ((FixedSysStringMarshalInfo)info).Size };
            if (info.GetType() == typeof(FixedArrayMarshalInfo)) { var value = (FixedArrayMarshalInfo)info; return new FixedArrayMarshalInfo { Size = value.Size, ElementType = value.ElementType }; }
            var array = (ArrayMarshalInfo)info;
            return new ArrayMarshalInfo { ElementType = array.ElementType, Size = array.Size, SizeParameterIndex = array.SizeParameterIndex, SizeParameterMultiplier = array.SizeParameterMultiplier };
        }
        public static string Canonical(IMarshalInfoProvider provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            int flags, mask; string kind;
            if (provider is FieldDefinition) { flags = (int)((FieldDefinition)provider).Attributes; mask = 0x1000; kind = "field"; }
            else if (provider is ParameterDefinition) { flags = (int)((ParameterDefinition)provider).Attributes; mask = 0x2000; kind = "parameter"; }
            else if (provider is MethodReturnType) { flags = (int)((MethodReturnType)provider).Attributes; mask = 0x2000; kind = "return"; }
            else throw new NotSupportedException("Unknown marshal owner " + provider.GetType().FullName);
            bool has = provider.HasMarshalInfo; MarshalInfo info = provider.MarshalInfo;
            if (has != (info != null) || ((flags & mask) != 0) != has) throw new InvalidDataException("Dangling or inconsistent HasFieldMarshal owner flags");
            return kind + ":" + Number(flags) + ":" + (has ? "1:" : "0:") + MarshalDescriptor(info);
        }
        public static string PInvokeDescriptor(PInvokeInfo info)
        {
            if (info == null) return "null";
            if (info.Module == null || String.IsNullOrEmpty(info.Module.Name) || String.IsNullOrEmpty(info.EntryPoint)) throw new InvalidDataException("Missing exact import module/entry ownership");
            return "pinvoke:" + Number((int)info.Attributes) + ":" + Part(info.Module.Name) + ":" + Part(info.EntryPoint);
        }
        private static IEnumerable<TypeDefinition> Types(TypeDefinition type)
        {
            yield return type;
            foreach (var nested in type.NestedTypes) foreach (var child in Types(nested)) yield return child;
        }
        private static IEnumerable<IMarshalInfoProvider> Providers(ModuleDefinition module)
        {
            foreach (var root in module.Types) foreach (var type in Types(root))
            {
                foreach (var field in type.Fields) yield return field;
                foreach (var method in type.Methods)
                {
                    yield return method.MethodReturnType;
                    foreach (var parameter in method.Parameters) yield return parameter;
                }
            }
        }
        // Validation-only scope for integration callers. The genuine SDK
        // LPArray blob 2a50002000 already contains index0/size32/multiplier0;
        // no writer normalization or metadata mutation is necessary/permitted.
        public static IDisposable BeginWrite(ModuleDefinition module)
        {
            if (module == null) throw new ArgumentNullException("module");
            var seen = new HashSet<MarshalInfo>();
            foreach (var provider in Providers(module))
            {
                if (!provider.HasMarshalInfo) continue;
                MarshalInfo descriptor = provider.MarshalInfo;
                if (descriptor == null || !seen.Add(descriptor)) continue;
                MarshalDescriptor(descriptor);
            }
            return new NoMutationWriteScope();
        }
        private sealed class NoMutationWriteScope : IDisposable
        {
            public void Dispose() { }
        }
    }
}
