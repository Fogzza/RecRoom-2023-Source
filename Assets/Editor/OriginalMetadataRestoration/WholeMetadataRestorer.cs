// Strict general integration, not installed into the game project.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace RR23.MetadataRestoration
{
    public sealed class WholeRestoredBytes
    {
        public byte[] Pe, Pdb;
        public DefinitionRestorationResult Definitions;
        public ReferenceReversalResult References;
        public int Bodies, SequencePoints;
        public ProvenMarshallingOverlayResult MarshallingOverlay;
        public int NativeFrameworkTypeRefScopes;
    }
    public static class WholeMetadataRestorer
    {
        private static byte[] Resource(string name)
        {
            using (var source = typeof(WholeMetadataRestorer).Assembly.GetManifestResourceStream(name))
            {
                if (source == null) throw new InvalidDataException("Missing pinned resource: " + name);
                long length = source.Length;
                if (length < 0 || length > int.MaxValue)
                    throw new InvalidDataException("Pinned resource length is not representable: " + name);
                var bytes = new byte[(int)length];
                int position = 0;
                while (position < bytes.Length)
                {
                    int read = source.Read(bytes, position, bytes.Length - position);
                    if (read <= 0) throw new EndOfStreamException("Truncated pinned resource: " + name);
                    position += read;
                }
                if (source.ReadByte() != -1)
                    throw new InvalidDataException("Pinned resource length changed: " + name);
                return bytes;
            }
        }
        private static string Hash(byte[] bytes)
        {
            using (var sha = SHA256.Create()) return BitConverter.ToString(sha.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant();
        }
        private static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types)
        {
            foreach (var type in types) { yield return type; foreach (var child in Walk(type.NestedTypes)) yield return child; }
        }
        private static string TypeKey(string assembly, string fullName) { return assembly + ":" + fullName; }

        private static ExactTypePlan[] CompletePlans(WholeMetadataManifest manifest, ModuleDefinition compiled, ModuleDefinition raw)
        {
            var types = Walk(compiled.Types).ToDictionary(t => t.FullName);
            var originals = Walk(raw.Types).ToDictionary(t => t.FullName);
            // Only this precisely identified upstream tool helper may be omitted.
            // Any further omission requires a reviewed schema/policy change.
            foreach (string excluded in manifest.ExplicitDecompilerInjectedExclusions)
                if (excluded != "Cpp2ILInjected.Cpp2ILHelpers" || !originals.ContainsKey(excluded))
                    throw new InvalidDataException("Unapproved original-type exclusion: " + excluded);
            var own = manifest.Types.Where(t => t.Assembly == manifest.AssemblyName).ToArray();
            if (own.Select(t => t.OriginalFullName).Distinct().Count() != own.Length
                || own.Select(t => t.CompiledFullName).Distinct().Count() != own.Length)
                throw new InvalidDataException("Ambiguous whole-assembly type identities");
            if (!types.Keys.OrderBy(x => x).SequenceEqual(own.Select(t => t.CompiledFullName).OrderBy(x => x)))
                throw new InvalidDataException("Compiled assembly type inventory differs from the reviewed manifest");
            if (manifest.RequireWholeOriginalAssembly && !originals.Keys.Except(manifest.ExplicitDecompilerInjectedExclusions).OrderBy(x => x)
                .SequenceEqual(own.Select(t => t.OriginalFullName).OrderBy(x => x)))
                throw new InvalidDataException("Whole original type inventory is incomplete");
            var forward = manifest.Types.ToDictionary(t => TypeKey(t.Assembly, t.OriginalFullName), t => t.CompiledFullName);
            Func<TypeReference, string> project = type => {
                string value; return forward.TryGetValue(TypeKey(CanonicalMetadataSignatures.Assembly(type), type.FullName), out value) ? value : type.FullName;
            };
            var originalScopeNames = new HashSet<string>(own.Select(o => o.OriginalFullName));
            EmittedOriginalMethodSubsetPolicy.VerifyScope(originals.Values.Where(t => originalScopeNames.Contains(t.FullName)), manifest.UnrecoveredMethods);
            var detailed = manifest.Definitions.ToDictionary(t => t.OriginalFullName);
            var output = new List<ExactTypePlan>();
            foreach (var identity in own)
            {
                var rawType = originals[identity.OriginalFullName]; var compiledType = types[identity.CompiledFullName];
                var emittedOriginalMethods = EmittedOriginalMethodSubsetPolicy.Select(raw, rawType, compiledType, manifest.UnrecoveredMethods);
                if (rawType.GenericParameters.Count != compiledType.GenericParameters.Count)
                    throw new InvalidDataException("Generic arity differs from original: " + rawType.FullName);
                ExactTypePlan plan;
                if (!detailed.TryGetValue(identity.OriginalFullName, out plan))
                    plan = new ExactTypePlan { OriginalFullName = identity.OriginalFullName, CompiledFullName = identity.CompiledFullName,
                        OriginalMethodCount = rawType.Methods.Count, OriginalFieldCount = rawType.Fields.Count,
                        Methods = new ExactMethodPlan[0], Fields = new ExactFieldPlan[0], Properties = new ExactPropertyPlan[0], Events = new ExactEventPlan[0] };
                if (plan.CompiledFullName != identity.CompiledFullName) throw new InvalidDataException("Detailed and global type maps disagree");
                // Fill only unchanged identities proved uniquely by the original
                // metadata and the explicit forward TypeSpec projection.
                var methodPlans = plan.Methods.ToList();
                var originalMethodKeys = new HashSet<string>(methodPlans.Select(m => m.OriginalCanonicalSignature));
                foreach (var method in emittedOriginalMethods)
                    if (!originalMethodKeys.Contains(CanonicalMetadataSignatures.Method(method)))
                    {
                        var readonlyPlan = manifest.ReadonlyAttributes.SingleOrDefault(r => r.OriginalType == identity.OriginalFullName
                            && r.OriginalGetterCanonical == CanonicalMetadataSignatures.Method(method));
                        methodPlans.Add(new ExactMethodPlan { OriginalCanonicalSignature = CanonicalMetadataSignatures.Method(method),
                            CompiledCanonicalSignature = readonlyPlan == null ? ProjectedCanonicalSignatures.Method(method, project) : readonlyPlan.CompiledGetterCanonical, OriginalAttributes = (int)method.Attributes,
                            OriginalImplAttributes = (int)method.ImplAttributes, OriginalSemantics = (int)method.SemanticsAttributes });
                    }
                var fieldPlans = plan.Fields.ToList(); var originalFieldKeys = new HashSet<string>(fieldPlans.Select(f => f.OriginalName));
                foreach (var field in rawType.Fields)
                    if (!originalFieldKeys.Contains(field.Name)) fieldPlans.Add(new ExactFieldPlan { OriginalName = field.Name, CompiledName = field.Name,
                        OriginalCanonicalType = CanonicalMetadataSignatures.Type(field.FieldType), CompiledCanonicalType = ProjectedCanonicalSignatures.Type(field.FieldType, project),
                        OriginalAttributes = (int)field.Attributes });
                var propertyPlans = plan.Properties.ToList();
                var originalPropertyKeys = new HashSet<string>(propertyPlans.Select(p => p.OriginalName + ":" + p.OriginalCanonicalType + ":" + string.Join("|", p.OriginalCanonicalParameters)));
                Func<MethodDefinition, MethodDefinition> compiledAccessor = originalMethod => {
                    if (originalMethod == null) return null;
                    string originalSignature = CanonicalMetadataSignatures.Method(originalMethod);
                    var mapped = methodPlans.Single(p => p.OriginalCanonicalSignature == originalSignature);
                    var matches = compiledType.Methods.Where(m => CanonicalMetadataSignatures.Method(m) == mapped.CompiledCanonicalSignature).Take(2).ToArray();
                    if (matches.Length != 1) throw new InvalidDataException("Property/event original accessor is not uniquely bound: " + originalMethod.FullName);
                    return matches[0];
                };
                foreach (var property in rawType.Properties)
                {
                    string canonical = CanonicalMetadataSignatures.Type(property.PropertyType);
                    string[] parameters = property.Parameters.Select(p => CanonicalMetadataSignatures.Type(p.ParameterType)).ToArray();
                    if (!originalPropertyKeys.Contains(property.Name + ":" + canonical + ":" + string.Join("|", parameters)))
                    {
                        var readonlyPlan = manifest.ReadonlyAttributes.SingleOrDefault(r => r.OriginalType == identity.OriginalFullName && r.OriginalProperty == property.Name);
                        // Getter/setter object ownership is the identity proof;
                        // source-friendly names are never guessed from obfuscation.
                        var getter = compiledAccessor(property.GetMethod); var setter = compiledAccessor(property.SetMethod);
                        var matches = compiledType.Properties.Where(p => ReferenceEquals(p.GetMethod, getter) && ReferenceEquals(p.SetMethod, setter)).Take(2).ToArray();
                        if (matches.Length != 1) throw new InvalidDataException("Original property ownership is ambiguous: " + property.FullName);
                        if (readonlyPlan != null && matches[0].Name != readonlyPlan.CompiledProperty) throw new InvalidDataException("Readonly and accessor property identities disagree");
                        propertyPlans.Add(new ExactPropertyPlan { OriginalName = property.Name, CompiledName = matches[0].Name,
                            OriginalCanonicalType = canonical, CompiledCanonicalType = readonlyPlan == null ? ProjectedCanonicalSignatures.Type(property.PropertyType, project) : readonlyPlan.CompiledCanonicalPropertyType,
                            OriginalCanonicalParameters = parameters,
                            CompiledCanonicalParameters = readonlyPlan == null ? property.Parameters.Select(p => ProjectedCanonicalSignatures.Type(p.ParameterType, project)).ToArray() : readonlyPlan.CompiledCanonicalPropertyParameters,
                            OriginalAttributes = (int)property.Attributes });
                    }
                }
                var eventPlans = (plan.Events ?? new ExactEventPlan[0]).ToList(); var eventNames = new HashSet<string>(eventPlans.Select(e => e.OriginalName));
                foreach (var item in rawType.Events)
                    if (!eventNames.Contains(item.Name))
                    {
                        var add = compiledAccessor(item.AddMethod); var remove = compiledAccessor(item.RemoveMethod); var invoke = compiledAccessor(item.InvokeMethod);
                        var matches = compiledType.Events.Where(e => ReferenceEquals(e.AddMethod, add) && ReferenceEquals(e.RemoveMethod, remove) && ReferenceEquals(e.InvokeMethod, invoke)).Take(2).ToArray();
                        if (matches.Length != 1) throw new InvalidDataException("Original event ownership is ambiguous: " + item.FullName);
                        eventPlans.Add(new ExactEventPlan { OriginalName = item.Name, CompiledName = matches[0].Name,
                        OriginalCanonicalType = CanonicalMetadataSignatures.Type(item.EventType), CompiledCanonicalType = ProjectedCanonicalSignatures.Type(item.EventType, project),
                        OriginalAttributes = (int)item.Attributes });
                    }
                output.Add(new ExactTypePlan { OriginalFullName = plan.OriginalFullName, CompiledFullName = plan.CompiledFullName,
                    OriginalMethodCount = plan.OriginalMethodCount, OriginalFieldCount = plan.OriginalFieldCount, MissingOriginalMethodCount = rawType.Methods.Count - emittedOriginalMethods.Length,
                    Methods = methodPlans.ToArray(), Fields = fieldPlans.ToArray(), Properties = propertyPlans.ToArray(), Events = eventPlans.ToArray() });
            }
            if (detailed.Keys.Except(own.Select(t => t.OriginalFullName)).Any()) throw new InvalidDataException("Detailed type outside reviewed source inventory");
            return output.ToArray();
        }

        public static WholeRestoredBytes Restore(byte[] pe, byte[] pdb, string[] referencePaths, string[] defines)
        {
            WholeMetadataManifest manifest;
            using (var stream = typeof(WholeMetadataRestorer).Assembly.GetManifestResourceStream("RR23.GeneralManifest"))
            {
                if (stream == null) throw new InvalidDataException("Missing pinned resource: RR23.GeneralManifest");
                manifest = WholeMetadataManifest.Read(stream);
            }
            var rawBytes = Resource("RR23.RawMetadata"); var serialBytes = Resource("RR23.SerializationMetadata");
            if (Hash(rawBytes) != manifest.RawHash || Hash(serialBytes) != manifest.SerializationHash)
                throw new InvalidDataException("Original metadata resource hash changed");
            bool symbols = pdb != null && pdb.Length != 0;
            if (symbols && (pdb.Length < 4 || Encoding.ASCII.GetString(pdb, 0, 4) != "BSJB"))
                throw new InvalidDataException("Portable symbols required; unsupported PDB cannot be dropped");
            using (var resolver = new ExactMetadataReferenceResolver(referencePaths, OriginalRuntimeMetadataReferenceInputs.Values, OriginalFrameworkMetadataReferenceInputs.Values))
            {
            var reader = new ReaderParameters { InMemory = true, ReadSymbols = symbols, AssemblyResolver = resolver };
            if (symbols) { reader.SymbolReaderProvider = new PortablePdbReaderProvider(); reader.SymbolStream = new MemoryStream(pdb, false); }
            using (var assembly = AssemblyDefinition.ReadAssembly(new MemoryStream(pe, false), reader))
            using (var raw = AssemblyDefinition.ReadAssembly(new MemoryStream(rawBytes, false), new ReaderParameters { AssemblyResolver = resolver }))
            using (var serial = AssemblyDefinition.ReadAssembly(new MemoryStream(serialBytes, false), new ReaderParameters { AssemblyResolver = resolver }))
            {
                if (assembly.Name.Name != manifest.AssemblyName || raw.Name.Name != manifest.AssemblyName || serial.Name.Name != manifest.AssemblyName)
                    throw new InvalidDataException("Original assembly identity differs");
                var adapterNormalization = CoreCompilerAdapterNormalizer.Normalize(assembly.MainModule, raw.MainModule, manifest);
                var originalParameterizedProperties = ExactOriginalPropertyRestoration.Apply(assembly.MainModule, raw.MainModule, manifest);
                var originalEmptyExterns = OriginalEmptyExternRestoration.Apply(assembly.MainModule, raw.MainModule, manifest.EmptyExterns);
                var methods = Walk(assembly.MainModule.Types).SelectMany(t => t.Methods).ToArray();
                var safety = BodyAndSymbolSafety.Capture(methods);
                var plans = CompletePlans(manifest, assembly.MainModule, raw.MainModule);
                ExactOriginalTypeFlagRestoration.Apply(assembly.MainModule, raw.MainModule, plans);
                OriginalTypeContractChecks.VerifyProjected(assembly.MainModule, raw.MainModule, plans, manifest.Types);
                var apply = MetadataDefinitionRestoration.Bind(assembly.MainModule, raw.MainModule, serial.MainModule, plans, manifest.SerializationFieldWitnesses);
                var readonlyAttributes = ReadonlyAttributeRestoration.Bind(assembly.MainModule, raw.MainModule, serial.MainModule, manifest.ReadonlyAttributes, manifest.SerializationHash);
                var references = MetadataReferenceReversal.Reverse(assembly.MainModule, manifest.Types, EmittedReferencePlanCompletion.Complete(manifest, raw.MainModule, plans), manifest.Fields);
                var counts = new DefinitionRestorationResult(); apply(counts); references.CompleteSignatureRestoration(); references.VerifyFinalNames(); readonlyAttributes();
                var frameworkScopes = ExactOriginalFrameworkScopes.Apply(assembly.MainModule, raw.MainModule, OriginalFrameworkScopeInputs.Rows);
                var marshallingOverlay = ProvenMarshallingOverlay.Apply(assembly.MainModule, raw.MainModule, Resource(ProvenMarshallingOverlayInputs.ResourceName), ProvenMarshallingOverlayInputs.Sha256, defines);
                safety.VerifyObjectIdentity(methods);
                var result = new WholeRestoredBytes { Definitions = counts, References = references, MarshallingOverlay = marshallingOverlay, NativeFrameworkTypeRefScopes = frameworkScopes };
                using (var output = new MemoryStream()) using (var symbolOutput = new MemoryStream())
                {
                    var writer = new WriterParameters { WriteSymbols = symbols };
                    if (symbols) { writer.SymbolWriterProvider = new PortablePdbWriterProvider(); writer.SymbolStream = symbolOutput; }
                    var expected = safety.CaptureNormalized(methods);
                    var expectedMetadata = MetadataRoundTripSafety.Fingerprint(assembly.MainModule);
                    var expectedMetadataRows = MetadataRoundTripDiagnostics.Capture(assembly.MainModule);
                    assembly.Write(output, writer); result.Pe = output.ToArray(); result.Pdb = symbols ? symbolOutput.ToArray() : new byte[0];
                    var reread = new ReaderParameters { ReadSymbols = symbols, AssemblyResolver = resolver };
                    if (symbols) { reread.SymbolReaderProvider = new PortablePdbReaderProvider(); reread.SymbolStream = new MemoryStream(result.Pdb, false); }
                    using (var verified = AssemblyDefinition.ReadAssembly(new MemoryStream(result.Pe, false), reread))
                    {
                        var emitted = Walk(verified.MainModule.Types).SelectMany(t => t.Methods).ToArray();
                        safety.VerifyEmitted(expected, emitted);
                        if (expectedMetadata != MetadataRoundTripSafety.Fingerprint(verified.MainModule))
                            throw new InvalidDataException("Emitted original metadata did not round-trip exactly: " + MetadataRoundTripDiagnostics.Difference(expectedMetadataRows, verified.MainModule));
                        result.Bodies = emitted.Count(m => m.HasBody); result.SequencePoints = emitted.Sum(m => m.DebugInformation.SequencePoints.Count);
                    }
                }
                return result;
            }
            }
        }
    }
}
