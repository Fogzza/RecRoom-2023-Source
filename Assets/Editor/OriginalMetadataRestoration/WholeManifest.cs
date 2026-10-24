// Compact embedded runtime manifest. JSON is only an offline preparation format.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RR23.MetadataRestoration
{
    public sealed class WholeMetadataManifest
    {
        public string AssemblyName, RawHash, SerializationHash, SourceManifestHash, ReferenceManifestHash;
        public bool RequireWholeOriginalAssembly;
        public string[] ExplicitDecompilerInjectedExclusions;
        public TypeReferenceAlias[] Types;
        public MethodReferenceAlias[] Methods;
        public FieldReferenceAlias[] Fields;
        public ExactTypePlan[] Definitions;
        public ReadonlyAttributePlan[] ReadonlyAttributes;
        public UnrecoveredOriginalMethodPlan[] UnrecoveredMethods;
        public CoreCompilerAdapterPlan[] CompilerAdapters;
        public CoreCompilerConstructorInversePlan[] CompilerAddedConstructors;
        public OriginalEmptyExternPlan[] EmptyExterns;
        public SerializationFieldWitnessPlan[] SerializationFieldWitnesses;
        private sealed class ManifestReader : BinaryReader
        {
            private readonly Dictionary<string, string> strings = new Dictionary<string, string>(StringComparer.Ordinal);
            public ManifestReader(Stream stream) : base(stream, Encoding.UTF8, true) { }
            public override string ReadString()
            {
                string value = base.ReadString();
                string existing;
                if (strings.TryGetValue(value, out existing)) return existing;
                strings.Add(value, value);
                return value;
            }
        }
        private static int Count(BinaryReader reader, int limit)
        {
            int value = reader.ReadInt32();
            if (value < 0 || value > limit) throw new InvalidDataException("Manifest count exceeds its fixed bound");
            return value;
        }
        private static string[] Strings(BinaryReader reader)
        {
            return Enumerable.Range(0, Count(reader, 1000)).Select(_ => reader.ReadString()).ToArray();
        }
        public static WholeMetadataManifest Read(Stream stream)
        {
            using (var reader = new ManifestReader(stream))
            {
                if (reader.ReadString() != "RR23-METADATA-RESTORE-6") throw new InvalidDataException("General manifest schema mismatch");
                var result = new WholeMetadataManifest { AssemblyName = reader.ReadString(), RawHash = reader.ReadString(),
                    SerializationHash = reader.ReadString(), SourceManifestHash = reader.ReadString(), ReferenceManifestHash = reader.ReadString(),
                    RequireWholeOriginalAssembly = reader.ReadBoolean(), ExplicitDecompilerInjectedExclusions = Strings(reader) };
                result.Types = new TypeReferenceAlias[Count(reader, 100000)];
                for (int i = 0; i < result.Types.Length; i++) result.Types[i] = new TypeReferenceAlias {
                    Assembly = reader.ReadString(), OriginalFullName = reader.ReadString(), CompiledFullName = reader.ReadString() };
                result.Methods = new MethodReferenceAlias[Count(reader, 1000000)];
                for (int i = 0; i < result.Methods.Length; i++) result.Methods[i] = new MethodReferenceAlias {
                    Assembly = reader.ReadString(), OriginalDeclaringType = reader.ReadString(), CompiledDeclaringType = reader.ReadString(),
                    OriginalName = reader.ReadString(), CompiledName = reader.ReadString(), CompiledCanonicalSignature = reader.ReadString(),
                    OriginalCanonicalSignature = reader.ReadString(), OriginalCanonicalReturnType = reader.ReadString(), OriginalCanonicalParameterTypes = Strings(reader) };
                result.Fields = new FieldReferenceAlias[Count(reader, 1000000)];
                for (int i = 0; i < result.Fields.Length; i++) result.Fields[i] = new FieldReferenceAlias {
                    Assembly = reader.ReadString(), OriginalDeclaringType = reader.ReadString(), CompiledDeclaringType = reader.ReadString(),
                    OriginalName = reader.ReadString(), CompiledName = reader.ReadString(), CompiledCanonicalType = reader.ReadString() };
                result.Definitions = new ExactTypePlan[Count(reader, 100000)];
                for (int i = 0; i < result.Definitions.Length; i++)
                {
                    var type = new ExactTypePlan { OriginalFullName = reader.ReadString(), CompiledFullName = reader.ReadString(),
                        OriginalMethodCount = Count(reader, 100000), OriginalFieldCount = Count(reader, 100000) };
                    type.Methods = new ExactMethodPlan[Count(reader, 100000)];
                    for (int m = 0; m < type.Methods.Length; m++) type.Methods[m] = new ExactMethodPlan {
                        OriginalCanonicalSignature = reader.ReadString(), CompiledCanonicalSignature = reader.ReadString(),
                        OriginalAttributes = reader.ReadInt32(), OriginalImplAttributes = reader.ReadInt32(), OriginalSemantics = reader.ReadInt32() };
                    type.Fields = new ExactFieldPlan[Count(reader, 100000)];
                    for (int f = 0; f < type.Fields.Length; f++) type.Fields[f] = new ExactFieldPlan {
                        OriginalName = reader.ReadString(), CompiledName = reader.ReadString(), OriginalCanonicalType = reader.ReadString(),
                        CompiledCanonicalType = reader.ReadString(), OriginalAttributes = reader.ReadInt32() };
                    type.Properties = new ExactPropertyPlan[Count(reader, 100000)];
                    for (int p = 0; p < type.Properties.Length; p++) type.Properties[p] = new ExactPropertyPlan {
                        OriginalName = reader.ReadString(), CompiledName = reader.ReadString(), OriginalCanonicalType = reader.ReadString(),
                        CompiledCanonicalType = reader.ReadString(), OriginalCanonicalParameters = Strings(reader), CompiledCanonicalParameters = Strings(reader),
                        OriginalAttributes = reader.ReadInt32() };
                    type.Events = new ExactEventPlan[Count(reader, 100000)];
                    for (int e = 0; e < type.Events.Length; e++) type.Events[e] = new ExactEventPlan {
                        OriginalName = reader.ReadString(), CompiledName = reader.ReadString(), OriginalCanonicalType = reader.ReadString(),
                        CompiledCanonicalType = reader.ReadString(), OriginalAttributes = reader.ReadInt32() };
                    result.Definitions[i] = type;
                }
                result.ReadonlyAttributes = new ReadonlyAttributePlan[Count(reader, 10000)];
                for (int i = 0; i < result.ReadonlyAttributes.Length; i++)
                {
                    var plan = new ReadonlyAttributePlan { OriginalType = reader.ReadString(), CompiledType = reader.ReadString(),
                        OriginalProperty = reader.ReadString(), CompiledProperty = reader.ReadString(), OriginalGetterCanonical = reader.ReadString(), CompiledGetterCanonical = reader.ReadString(),
                        CompiledCanonicalPropertyType = reader.ReadString(), CompiledCanonicalPropertyParameters = Strings(reader),
                        ProviderHash = reader.ReadString(), ConstructorFullName = reader.ReadString(), ConstructorAssembly = reader.ReadString(),
                        DeclaringTypeToken = reader.ReadUInt32(), PropertyToken = reader.ReadUInt32(), GetterToken = reader.ReadUInt32() };
                    int bytes = Count(reader, 65536); plan.Blob = reader.ReadBytes(bytes);
                    if (plan.Blob.Length != bytes) throw new InvalidDataException("Truncated readonly attribute blob");
                    plan.OriginalPropertyHasAttribute = reader.ReadBoolean(); plan.OriginalGetterReturnHasAttribute = reader.ReadBoolean();
                    result.ReadonlyAttributes[i] = plan;
                }
                result.UnrecoveredMethods = new UnrecoveredOriginalMethodPlan[Count(reader, 1000000)];
                for (int i = 0; i < result.UnrecoveredMethods.Length; i++) result.UnrecoveredMethods[i] = new UnrecoveredOriginalMethodPlan {
                    OriginalType = reader.ReadString(), OriginalCanonicalSignature = reader.ReadString(), ExpectedCompiledCanonicalSignature = reader.ReadString(),
                    OriginalProviderMethodToken = reader.ReadUInt32(), OriginalAttributes = reader.ReadInt32(), OriginalImplAttributes = reader.ReadInt32(), OriginalSemantics = reader.ReadInt32(), Classification = reader.ReadString() };
                result.CompilerAdapters = new CoreCompilerAdapterPlan[Count(reader, 100000)];
                for (int i=0;i<result.CompilerAdapters.Length;i++) result.CompilerAdapters[i]=new CoreCompilerAdapterPlan {
                    OriginalOwner=reader.ReadString(),CompiledOwner=reader.ReadString(),OriginalCanonical=reader.ReadString(),
                    AdapterCanonical=reader.ReadString(),RetainedCanonical=reader.ReadString(),PlannedRetainedCanonical=reader.ReadString() };
                result.CompilerAddedConstructors = new CoreCompilerConstructorInversePlan[Count(reader, 1000)];
                for (int i=0;i<result.CompilerAddedConstructors.Length;i++) result.CompilerAddedConstructors[i]=new CoreCompilerConstructorInversePlan {
                    CompiledOwner=reader.ReadString(),Canonical=reader.ReadString() };
                result.EmptyExterns=new OriginalEmptyExternPlan[Count(reader,100000)];
                for (int i=0;i<result.EmptyExterns.Length;i++) result.EmptyExterns[i]=new OriginalEmptyExternPlan {
                    OriginalType=reader.ReadString(),CompiledType=reader.ReadString(),OriginalCanonical=reader.ReadString(),CompiledCanonical=reader.ReadString(),
                    OriginalProviderMethodToken=reader.ReadUInt32(),OriginalAttributes=reader.ReadInt32(),OriginalImplAttributes=reader.ReadInt32(),OriginalSemantics=reader.ReadInt32() };
                result.SerializationFieldWitnesses=new SerializationFieldWitnessPlan[Count(reader,1000)];
                for(int i=0;i<result.SerializationFieldWitnesses.Length;i++) result.SerializationFieldWitnesses[i]=new SerializationFieldWitnessPlan {
                    OriginalType=reader.ReadString(),OriginalField=reader.ReadString(),RawCanonicalType=reader.ReadString(),LegacyCanonicalType=reader.ReadString(),
                    RawProviderFieldToken=reader.ReadUInt32(),LegacyProviderFieldToken=reader.ReadUInt32(),OriginalNativeFieldToken=reader.ReadUInt32(),OriginalNativeOwnerToken=reader.ReadUInt32() };
                if (stream.Position != stream.Length) throw new InvalidDataException("Unexpected trailing general manifest data");
                return result;
            }
        }
    }
}
