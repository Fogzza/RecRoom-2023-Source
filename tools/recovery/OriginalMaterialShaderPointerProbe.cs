using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
using AssetRipper.Assets;
using AssetRipper.Assets.Bundles;
using AssetRipper.Assets.IO.Writing;
using AssetRipper.Assets.Metadata;
using AssetRipper.IO.Endian;
using AssetRipper.Primitives;
using AssetRipper.SourceGenerated;
using AssetRipper.SourceGenerated.Classes.ClassID_21;

// Pure matching generated-model read of one Class21 object. No Unity runtime,
// assembly manager, game assembly, native SDK, or external-object resolution.
internal static class OriginalMaterialShaderPointerProbe
{
    static void Need(bool value, string message) { if (!value) throw new InvalidDataException(message); }
    static string Sha(byte[] data) => Convert.ToHexString(SHA256.HashData(data)).ToLowerInvariant();
    static object Field(object value, string name)
    {
        FieldInfo field = value.GetType().GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        Need(field != null, "Exact generated Shader PPtr field missing: " + name);
        return field.GetValue(value);
    }
    static void Main(string[] args)
    {
        Need(args.Length == 4, "pinnedClass21Object expectedSHA nativePathID freshReport required");
        var info = new FileInfo(args[0]);
        Need(info.Length > 0 && info.Length <= 1024 * 1024, "Bounded isolated Material object required");
        byte[] data = File.ReadAllBytes(args[0]);
        Need(Sha(data) == args[1], "Exact native Class21 object SHA required");
        Need(!File.Exists(args[3]), "Fresh report required");
        long pathID = long.Parse(args[2], System.Globalization.CultureInfo.InvariantCulture);
        var version = UnityVersion.Parse("2020.3.33f1");
        var bundle = new ProcessedBundle("SingleDiagnosticMaterialShaderPointer");
        var collection = bundle.AddNewProcessedCollection("bounded-native-Class21-object", version);
        IUnityObjectBase asset = AssetFactory.CreateSerialized(new AssetInfo(collection, pathID, 21), version);
        Need(asset is IMaterial, "Actual factory must select the genuine Class21 Material model");
        var material = (IMaterial)asset;
        var reader = new EndianSpanReader(data, EndianType.LittleEndian);
        material.ReadRelease(ref reader);
        Need(reader.Position == reader.Length, "Entire native Material must be consumed by matching generated ReadRelease");
        object pointer = material.Shader_C21;
        Need(pointer != null && pointer.GetType().Name == "PPtr_Shader_5", "Exact generated 2020 Shader pointer layout required");
        object file = Field(pointer, "m_FileID_"), path = Field(pointer, "m_PathID_");
        Need(file is int && path is long, "Typed signed32 FileID/signed64 PathID required");
        byte[] serialized;
        using (var output = new MemoryStream())
        {
            using (var writer = new AssetWriter(output, material.Collection)) material.WriteRelease(writer);
            serialized = output.ToArray();
        }
        Need(data.SequenceEqual(serialized), "Entire Material Release bytes must roundtrip exactly");
        File.WriteAllText(args[3], JsonSerializer.Serialize(new {
            schema = "full-generated-Material-Release-Shader-pointer/v1", status = "entire_Class21_read_and_exact_Release_roundtrip_verified",
            source = Path.GetFullPath(args[0]), source_sha256 = Sha(data), bytes = data.Length,
            material_native_path_id = pathID.ToString(System.Globalization.CultureInfo.InvariantCulture), class_id = 21,
            engine = version.ToString(), concrete_model = material.GetType().FullName,
            consumed_bytes = reader.Position, roundtrip_bytes = serialized.Length, roundtrip_sha256 = Sha(serialized),
            full_Release_bytes_equal = true, shader_pointer_model = pointer.GetType().FullName,
            shader_file_id = ((int)file).ToString(System.Globalization.CultureInfo.InvariantCulture),
            shader_path_id = ((long)path).ToString(System.Globalization.CultureInfo.InvariantCulture),
            external_target_resolved = false, Main_modified = false, Unity_launched = false, game_or_native_code_executed = false
        }, new JsonSerializerOptions { WriteIndented = true }));
    }
}
