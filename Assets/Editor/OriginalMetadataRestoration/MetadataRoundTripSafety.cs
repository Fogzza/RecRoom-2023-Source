// Metadata semantic fingerprint across Cecil emission. RVAs/tokens may relocate;
// identities, flags, constants, original data and accessor ownership may not.
using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public static class MetadataRoundTripSafety
    {
        private static void Attributes(StringBuilder value, ICustomAttributeProvider provider)
        {
            foreach (var attribute in provider.CustomAttributes)
                value.Append(ScopedMetadataSignatures.Type(attribute.Constructor.DeclaringType)+ScopedMetadataSignatures.Method(attribute.Constructor)).Append(':').Append(BitConverter.ToString(attribute.GetBlob())).Append('|');
        }
        private static void Generic(StringBuilder value, IGenericParameterProvider provider)
        {
            foreach (var generic in provider.GenericParameters)
            {
                value.Append(generic.Position).Append(':').Append(generic.Name).Append(':').Append((int)generic.Attributes).Append('|');
                foreach (var constraint in generic.Constraints) value.Append(ScopedMetadataSignatures.Type(constraint.ConstraintType)).Append('|');
                Attributes(value, generic);
            }
        }
        private static void Type(StringBuilder value, TypeDefinition type)
        {
            value.Append(type.FullName).Append(':').Append((int)type.Attributes).Append(':').Append(type.PackingSize).Append(':').Append(type.ClassSize).Append('|');
            if (type.BaseType != null) value.Append(ScopedMetadataSignatures.Type(type.BaseType)).Append('|');
            Generic(value, type); Attributes(value, type);
            foreach (var item in type.Interfaces) { value.Append(ScopedMetadataSignatures.Type(item.InterfaceType)).Append('|'); Attributes(value, item); }
            foreach (var field in type.Fields)
            {
                value.Append(field.Name).Append(':').Append(ScopedMetadataSignatures.Type(field.FieldType)).Append(':').Append((int)field.Attributes).Append(':')
                    .Append(field.Offset).Append(':').Append(field.HasConstant).Append(':').Append(Convert.ToString(field.Constant, CultureInfo.InvariantCulture)).Append(':')
                    .Append(BitConverter.ToString(field.InitialValue)).Append('|'); Attributes(value, field); value.Append(CanonicalMarshallingContracts.Canonical(field)).Append("|");
            }
            foreach (var method in type.Methods)
            {
                value.Append(ScopedMetadataSignatures.Method(method)).Append(':').Append((int)method.Attributes).Append(':').Append((int)method.ImplAttributes).Append(':')
                    .Append((int)method.SemanticsAttributes).Append('|'); Generic(value, method); Attributes(value, method); Attributes(value, method.MethodReturnType); value.Append(CanonicalMarshallingContracts.PInvokeDescriptor(method.PInvokeInfo)).Append("|").Append(CanonicalMarshallingContracts.Canonical(method.MethodReturnType)).Append("|");
                value.Append(method.MethodReturnType.Name).Append(':').Append((int)method.MethodReturnType.Attributes).Append('|');
                foreach (var parameter in method.Parameters)
                {
                    value.Append(parameter.Name).Append(':').Append((int)parameter.Attributes).Append(':').Append(parameter.HasConstant).Append(':')
                        .Append(Convert.ToString(parameter.Constant, CultureInfo.InvariantCulture)).Append('|'); Attributes(value, parameter); value.Append(CanonicalMarshallingContracts.Canonical(parameter)).Append("|");
                }
                foreach (var implementation in method.Overrides) value.Append(ScopedMetadataSignatures.Type(implementation.DeclaringType)).Append(':')
                    .Append(ScopedMetadataSignatures.Method(implementation)).Append('|');
            }
            foreach (var property in type.Properties)
            {
                value.Append(property.Name).Append(':').Append(ScopedMetadataSignatures.Type(property.PropertyType)).Append(':').Append((int)property.Attributes).Append('|');
                value.Append(property.GetMethod == null ? "" : ScopedMetadataSignatures.Method(property.GetMethod)).Append('|')
                    .Append(property.SetMethod == null ? "" : ScopedMetadataSignatures.Method(property.SetMethod)).Append('|'); Attributes(value, property);
            }
            foreach (var item in type.Events)
            {
                value.Append(item.Name).Append(':').Append(ScopedMetadataSignatures.Type(item.EventType)).Append(':').Append((int)item.Attributes).Append('|');
                foreach (var method in new[] { item.AddMethod, item.RemoveMethod, item.InvokeMethod })
                    value.Append(method == null ? "" : ScopedMetadataSignatures.Method(method)).Append('|'); Attributes(value, item);
            }
            foreach (var child in type.NestedTypes) Type(value, child);
        }
        public static string Fingerprint(ModuleDefinition module)
        {
            var value = new StringBuilder(); value.Append(module.Assembly.Name.FullName).Append('|');
            Attributes(value, module); Attributes(value, module.Assembly);
            foreach (var reference in module.AssemblyReferences) value.Append(reference.FullName).Append('|');
            foreach (var reference in module.ModuleReferences) value.Append(reference.Name).Append("|");
            foreach (var type in module.Types) Type(value, type);
            using (var sha = SHA256.Create()) return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(value.ToString()))).Replace("-", "");
        }
    }
}
