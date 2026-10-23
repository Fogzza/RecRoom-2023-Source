// Only explicit native-token witnesses may bypass a legacy provider TypeSpec bug.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
namespace RR23.MetadataRestoration
{
    public sealed class SerializationFieldWitnessPlan
    {
        public string OriginalType,OriginalField,RawCanonicalType,LegacyCanonicalType;
        public uint RawProviderFieldToken,LegacyProviderFieldToken,OriginalNativeFieldToken,OriginalNativeOwnerToken;
    }
    public static class SerializationFieldIdentityWitness
    {
        static uint OriginalToken(ICustomAttributeProvider provider)
        {
            var attributes=provider.CustomAttributes.Where(a=>a.AttributeType.FullName.Equals("Cpp2IlInjected.TokenAttribute",StringComparison.OrdinalIgnoreCase)).Take(2).ToArray();
            if(attributes.Length!=1)throw new InvalidDataException("Serialization witness original TokenAttribute is not unique");
            var fields=attributes[0].Fields.Where(f=>f.Name=="Token").Take(2).ToArray();
            if(fields.Length!=1||!(fields[0].Argument.Value is string))throw new InvalidDataException("Serialization witness original TokenAttribute shape differs");
            string value=(string)fields[0].Argument.Value;if(!value.StartsWith("0x",StringComparison.Ordinal))throw new InvalidDataException("Serialization witness native token is not hex");
            return Convert.ToUInt32(value.Substring(2),16);
        }
        public static FieldDefinition Resolve(ModuleDefinition legacy,FieldDefinition raw,string expectedType,SerializationFieldWitnessPlan[] all)
        {
            var matches=all.Where(p=>p.OriginalType==raw.DeclaringType.FullName&&p.OriginalField==raw.Name).Take(2).ToArray();
            if(matches.Length!=1)throw new InvalidDataException("No exact native serialization field witness: "+raw.FullName);
            var plan=matches[0];var field=legacy.LookupToken(new MetadataToken(plan.LegacyProviderFieldToken)) as FieldDefinition;
            if(raw.MetadataToken.ToUInt32()!=plan.RawProviderFieldToken||field==null||field.DeclaringType.FullName!=plan.OriginalType||field.Name!=plan.OriginalField
                ||CanonicalMetadataSignatures.Type(raw.FieldType)!=plan.RawCanonicalType||expectedType!=plan.RawCanonicalType
                ||CanonicalMetadataSignatures.Type(field.FieldType)!=plan.LegacyCanonicalType||OriginalToken(field)!=plan.OriginalNativeFieldToken||OriginalToken(field.DeclaringType)!=plan.OriginalNativeOwnerToken
                ||plan.OriginalNativeFieldToken>>24!=4||plan.OriginalNativeOwnerToken>>24!=2)
                throw new InvalidDataException("Native serialization field witness/token/TypeSpec differs: "+raw.FullName);
            return field;
        }
    }
}
