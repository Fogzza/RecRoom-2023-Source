using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json;
using AssetRipper.Assets;
using AssetRipper.Assets.Bundles;
using AssetRipper.Assets.Metadata;
using AssetRipper.IO.Endian;
using AssetRipper.Primitives;
using AssetRipper.SourceGenerated.Classes.ClassID_48;
using AssetRipper.Export.UnityProjects;
using AssetRipper.Yaml;

// Reads one pinned original object. No game assembly manager or recovered code.
internal static class OriginalShaderObjectProbe
{
    static string Sha(byte[] b) => Convert.ToHexString(SHA256.HashData(b)).ToLowerInvariant();
    static object Shape(object value)
    {
        if (value is IEnumerable items && !(value is string))
        {
            var result = new List<object>();
            foreach (var item in items) result.Add(Shape(item));
            return result;
        }
        return value;
    }
    static List<List<uint>> Matrix(object value)
    {
        if (value == null) return null;
        var result = new List<List<uint>>();
        foreach (var row in (IEnumerable)value)
        {
            var numbers = new List<uint>();
            foreach (var item in (IEnumerable)row) numbers.Add(Convert.ToUInt32(item));
            result.Add(numbers);
        }
        return result;
    }
    static void Main(string[] args)
    {
        if (args.Length != 5) throw new ArgumentException("object expectedSha pathId expectedName freshOutput");
        var info = new FileInfo(args[0]);
        if (info.Length <= 0 || info.Length > 8 * 1024 * 1024) throw new InvalidDataException("Object size bound");
        byte[] bytes = File.ReadAllBytes(args[0]);
        if (Sha(bytes) != args[1]) throw new InvalidDataException("Pinned object hash mismatch");
        if (Directory.Exists(args[4])) throw new IOException("Output must be fresh");
        Directory.CreateDirectory(args[4]);
        var version = UnityVersion.Parse("2020.3.33f1");
        var bundle = new ProcessedBundle("SingleOriginalShaderObject");
        var collection = bundle.AddNewProcessedCollection("bounded-original-object", version);
        IShader shader = Shader.Create(new AssetInfo(collection, long.Parse(args[2]), 48), version);
        var reader = new EndianSpanReader(bytes, EndianType.LittleEndian);
        shader.ReadRelease(ref reader);
        if (reader.Position != reader.Length) throw new InvalidDataException("Original object not fully consumed");
        if (shader.Name_R.ToString() != args[3]) throw new InvalidDataException("Structural shader name mismatch");
        if (shader.GetType().Name != "Shader_2020_3_16") throw new InvalidDataException("Unexpected Unity2020.3 model");
        var fields = new Dictionary<string, object>();
        foreach (string name in new[]{"Platforms", "Offsets_AssetList_UInt32", "Offsets_AssetList_AssetList_UInt32", "CompressedLengths_AssetList_UInt32", "CompressedLengths_AssetList_AssetList_UInt32", "DecompressedLengths_AssetList_UInt32", "DecompressedLengths_AssetList_AssetList_UInt32"})
        {
            var property = typeof(IShader).GetProperty(name);
            if (property == null) throw new MissingMemberException(name);
            var value = property.GetValue(shader);
            fields[name] = value == null ? null : Shape(value);
        }
        byte[] blob = shader.CompressedBlob;
        fields["compressedBlob"] = new { bytes = blob.Length, sha256 = Sha(blob) };
        var offsets = Matrix(typeof(IShader).GetProperty("Offsets_AssetList_AssetList_UInt32").GetValue(shader));
        var compressed = Matrix(typeof(IShader).GetProperty("CompressedLengths_AssetList_AssetList_UInt32").GetValue(shader));
        var decompressed = Matrix(typeof(IShader).GetProperty("DecompressedLengths_AssetList_AssetList_UInt32").GetValue(shader));
        if (offsets == null || compressed == null || decompressed == null ||
            offsets.Count != compressed.Count || offsets.Count != decompressed.Count || offsets.Count != shader.Platforms.Count)
            throw new InvalidDataException("Unexpected Unity2020 nested program array shape");
        for (int platform = 0; platform < offsets.Count; platform++)
        {
            if (offsets[platform].Count != compressed[platform].Count || offsets[platform].Count != decompressed[platform].Count)
                throw new InvalidDataException("Program-array per-platform dimensions disagree");
            for (int program = 0; program < offsets[platform].Count; program++)
                if ((ulong)offsets[platform][program] + compressed[platform][program] > (ulong)blob.Length)
                    throw new InvalidDataException("Program compressed-range escapes original blob");
        }
        var walker = new NoPointerWalker(); walker.WithUnityVersion(version);
        var document = new YamlDocument();
        document.CreateMappingRoot().Add("m_ParsedForm", walker.ExportYamlNode(shader.ParsedForm));
        var writer = new YamlWriter(); writer.AddDocument(document);
        var form = Path.Combine(args[4], "ParsedForm.yaml");
        using (var output = new StreamWriter(form, false, new System.Text.UTF8Encoding(false))) writer.Write(output);
        File.WriteAllText(Path.Combine(args[4], "report.json"), JsonSerializer.Serialize(new {
            schema = "bounded-original-shader-object-probe/v1", status = "parsed_entire_original_object",
            source = Path.GetFullPath(args[0]), source_sha256 = Sha(bytes), path_id = args[2], class_id = 48,
            engine = version.ToString(), concrete_model = shader.GetType().FullName,
            expected_name = args[3], actual_name = shader.Name_R.ToString(),
            consumed_bytes = reader.Position, total_bytes = reader.Length, fields,
            program_array_dimensions = offsets.Select(row => row.Count).ToArray(),
            program_ranges_within_original_blob = true,
            parsed_form = new { path = form, sha256 = Sha(File.ReadAllBytes(form)) },
            no_pointer_yaml = true, Main_modified = false, Unity_launched = false,
            editor_importability_proven = false
        }, new JsonSerializerOptions { WriteIndented = true }));
    }
    sealed class NoPointerWalker : YamlWalker
    {
        public override YamlNode CreateYamlNodeForPPtr<TAsset>(PPtr<TAsset> ptr)
        { throw new InvalidDataException("ParsedForm unexpectedly contains a pointer; binding required"); }
    }
}
