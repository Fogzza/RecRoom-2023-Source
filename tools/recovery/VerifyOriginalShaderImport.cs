using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;

// Editor-only verification for an isolated, hash-pinned original shader copy.
// No scenes, game scripts, material changes, Play or GPU rendering are used.
public static class VerifyOriginalShaderImport
{
    [Serializable] public class Vector { public int[] values; }
    [Serializable] public class Config
    {
        public string asset_path, expected_name, expected_guid, expected_asset_sha256, expected_meta_sha256;
        public string dependency_path, dependency_guid, dependency_sha256, dependency_meta_sha256;
        public int expected_blob_bytes, expected_properties, expected_subshaders, expected_passes, expected_subprograms;
        public string expected_blob_sha256;
        public int[] platforms;
        public Vector[] offsets, compressed_lengths, decompressed_lengths, keyword_masks;
    }
    [Serializable] public class Message
    {
        public string message, details, file, severity, platform;
        public int line;
    }
    [Serializable] public class Pass
    {
        public string name;
        public int[] keyword_mask;
        public bool fog_exp_found, fog_exp2_found;
        public int fog_exp_index, fog_exp2_index;
    }
    [Serializable] public class Snapshot
    {
        public string shader_type, name, guid, blob_sha256, parsed_form_serialized_sha256, asset_sha256, meta_sha256;
        public int blob_bytes, properties, subshaders, pass_count, subprograms, parsed_form_property_rows;
        public int[] platforms;
        public Vector[] offsets, compressed_lengths, decompressed_lengths;
        public Pass[] passes;
        public bool is_supported_diagnostic_only;
        public Message[] messages;
        public string semantic_sha256;
    }
    [Serializable] public class Report
    {
        public string schema = "isolated-original-shader-import-verification/v1";
        public string status = "failed", phase, unity_version, config_sha256, error_type, error_message;
        public Snapshot imported, after_protected_save;
        public int save_protection_messages, console_error_count, console_exception_count, console_warning_count;
        public bool dirty_before_save, payload_retained, keyword_masks_retained, original_meta_guid_retained;
        public bool dependency_guid_resolved, protected_save_bytes_unchanged, fresh_process_reload_compared;
        public bool gpu_rendering_tested = false, Play_entered = false, Main_modified = false;
    }
    static readonly CultureInfo Invariant = CultureInfo.InvariantCulture;
    static Report report;
    static Config config;
    static string Arg(string name, bool optional = false)
    {
        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length - 1; i++) if (args[i] == name) return args[i + 1];
        if (optional) return null;
        throw new InvalidOperationException("Missing exact argument " + name);
    }
    static string Sha(byte[] value)
    {
        using (var sha = SHA256.Create()) return BitConverter.ToString(sha.ComputeHash(value)).Replace("-", "").ToLowerInvariant();
    }
    static string ShaFile(string path) { return Sha(File.ReadAllBytes(path)); }
    static string AssetFile(string path)
    {
        Require(path.StartsWith("Assets/", StringComparison.Ordinal) && path.IndexOf("..", StringComparison.Ordinal) < 0 && path.IndexOf('\\') < 0, "Exact fixture-relative asset path required");
        return Path.Combine(Directory.GetParent(Application.dataPath).FullName, path);
    }
    static void Require(bool value, string message) { if (!value) throw new InvalidOperationException(message); }
    static SerializedProperty Property(SerializedObject owner, string name)
    {
        SerializedProperty value = owner.FindProperty(name);
        Require(value != null, "SerializedObject property unavailable: " + name);
        return value;
    }
    static SerializedProperty Child(SerializedProperty owner, string name)
    {
        SerializedProperty value = owner.FindPropertyRelative(name);
        Require(value != null, "SerializedObject child unavailable: " + owner.propertyPath + "." + name);
        return value;
    }
    static int[] Integers(SerializedProperty array)
    {
        Require(array.isArray && array.propertyType != SerializedPropertyType.String, "Expected native array: " + array.propertyPath);
        int[] result = new int[array.arraySize];
        for (int i = 0; i < result.Length; i++)
        {
            SerializedProperty item = array.GetArrayElementAtIndex(i);
            Require(item.propertyType == SerializedPropertyType.Integer, "Expected native integer element: " + item.propertyPath);
            result[i] = unchecked((int)item.longValue);
        }
        return result;
    }
    static Vector[] Matrix(SerializedProperty array)
    {
        Require(array.isArray, "Expected native nested array: " + array.propertyPath);
        Vector[] result = new Vector[array.arraySize];
        for (int i = 0; i < result.Length; i++) result[i] = new Vector { values = Integers(array.GetArrayElementAtIndex(i)) };
        return result;
    }
    static bool Equal(int[] a, int[] b)
    {
        if (a == null || b == null || a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++) if (a[i] != b[i]) return false;
        return true;
    }
    static bool Equal(Vector[] a, Vector[] b)
    {
        if (a == null || b == null || a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++) if (!Equal(a[i].values, b[i].values)) return false;
        return true;
    }
    static string StructuralHash(SerializedProperty root, out int rows, out int subprograms)
    {
        var text = new StringBuilder();
        SerializedProperty item = root.Copy(), end = root.GetEndProperty();
        rows = 0; subprograms = 0;
        while (item.Next(true) && !SerializedProperty.EqualContents(item, end))
        {
            rows++;
            if (item.name == "m_BlobIndex") subprograms++;
            Require(rows <= 100000, "Native ParsedForm property walk bound");
            string value;
            switch (item.propertyType)
            {
                case SerializedPropertyType.Generic: value = item.isArray ? "array:" + item.arraySize : "object"; break;
                case SerializedPropertyType.Integer: value = item.longValue.ToString(Invariant); break;
                case SerializedPropertyType.Enum: case SerializedPropertyType.ArraySize: case SerializedPropertyType.Character:
                case SerializedPropertyType.LayerMask: value = item.intValue.ToString(Invariant); break;
                case SerializedPropertyType.Boolean: value = item.boolValue ? "1" : "0"; break;
                case SerializedPropertyType.Float: value = item.doubleValue.ToString("R", Invariant); break;
                case SerializedPropertyType.String: value = item.stringValue; break;
                case SerializedPropertyType.ObjectReference: throw new InvalidOperationException("Unexpected ParsedForm object pointer: " + item.propertyPath);
                default: throw new InvalidOperationException("Unreviewed ParsedForm property kind: " + item.propertyType + ":" + item.propertyPath);
            }
            text.Append(item.propertyPath.Length).Append(':').Append(item.propertyPath).Append('|').Append(item.propertyType).Append('|')
                .Append(item.type.Length).Append(':').Append(item.type).Append('|').Append(value.Length).Append(':').Append(value).Append('\n');
        }
        return Sha(Encoding.UTF8.GetBytes(text.ToString()));
    }
    static bool NameIndex(SerializedProperty map, string name, out int index)
    {
        // Native maps may expose direct named leaves or the standard first/second
        // pair array. No other guessed dictionary layout is accepted.
        SerializedProperty direct = map.FindPropertyRelative(name);
        if (direct != null && direct.propertyType == SerializedPropertyType.Integer) { index = direct.intValue; return true; }
        if (map.isArray)
        {
            for (int i = 0; i < map.arraySize; i++)
            {
                SerializedProperty pair = map.GetArrayElementAtIndex(i);
                SerializedProperty first = pair.FindPropertyRelative("first"), second = pair.FindPropertyRelative("second");
                if (first != null && second != null && first.propertyType == SerializedPropertyType.String && second.propertyType == SerializedPropertyType.Integer && first.stringValue == name)
                { index = second.intValue; return true; }
            }
        }
        index = -1; return false;
    }
    static object Member(object owner, string name)
    {
        Type type = owner.GetType();
        FieldInfo field = type.GetField(name, BindingFlags.Public | BindingFlags.Instance);
        if (field != null) return field.GetValue(owner);
        PropertyInfo property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
        return property == null ? null : property.GetValue(owner, null);
    }
    static Message[] Messages(Shader shader)
    {
        MethodInfo api = typeof(ShaderUtil).GetMethod("GetShaderMessages", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(Shader) }, null);
        Require(api != null, "Matching Editor ShaderUtil.GetShaderMessages API unavailable");
        var result = new List<Message>();
        foreach (object entry in (IEnumerable)api.Invoke(null, new object[] { shader }))
        {
            result.Add(new Message { message = Convert.ToString(Member(entry, "message"), Invariant), details = Convert.ToString(Member(entry, "messageDetails"), Invariant),
                file = Convert.ToString(Member(entry, "file"), Invariant), severity = Convert.ToString(Member(entry, "severity"), Invariant),
                platform = Convert.ToString(Member(entry, "platform"), Invariant), line = Convert.ToInt32(Member(entry, "line"), Invariant) });
            Require(result.Count <= 512, "Shader compiler message bound");
        }
        return result.ToArray();
    }
    static Snapshot Capture(Shader shader)
    {
        var owner = new SerializedObject(shader); owner.Update();
        var result = new Snapshot { shader_type = shader.GetType().AssemblyQualifiedName, name = shader.name,
            guid = AssetDatabase.AssetPathToGUID(config.asset_path), is_supported_diagnostic_only = shader.isSupported,
            asset_sha256 = ShaFile(AssetFile(config.asset_path)), meta_sha256 = ShaFile(AssetFile(config.asset_path + ".meta")) };
        int[] integers = Integers(Property(owner, "compressedBlob"));
        byte[] blob = new byte[integers.Length];
        for (int i = 0; i < blob.Length; i++) { Require(integers[i] >= 0 && integers[i] <= 255, "Native blob byte range"); blob[i] = (byte)integers[i]; }
        result.blob_bytes = blob.Length; result.blob_sha256 = Sha(blob);
        result.platforms = Integers(Property(owner, "platforms")); result.offsets = Matrix(Property(owner, "offsets"));
        result.compressed_lengths = Matrix(Property(owner, "compressedLengths")); result.decompressed_lengths = Matrix(Property(owner, "decompressedLengths"));
        SerializedProperty parsed = Property(owner, "m_ParsedForm");
        result.parsed_form_serialized_sha256 = StructuralHash(parsed, out result.parsed_form_property_rows, out result.subprograms);
        result.properties = Child(Child(parsed, "m_PropInfo"), "m_Props").arraySize;
        SerializedProperty subshaders = Child(parsed, "m_SubShaders"); result.subshaders = subshaders.arraySize;
        var passes = new List<Pass>();
        for (int i = 0; i < subshaders.arraySize; i++)
        {
            SerializedProperty group = Child(subshaders.GetArrayElementAtIndex(i), "m_Passes");
            for (int j = 0; j < group.arraySize; j++)
            {
                SerializedProperty pass = group.GetArrayElementAtIndex(j), indices = Child(pass, "m_NameIndices");
                var row = new Pass { name = Child(Child(pass, "m_State"), "m_Name").stringValue, keyword_mask = Integers(Child(pass, "m_GlobalKeywordMask")) };
                row.fog_exp_found = NameIndex(indices, "FOG_EXP", out row.fog_exp_index);
                row.fog_exp2_found = NameIndex(indices, "FOG_EXP2", out row.fog_exp2_index);
                passes.Add(row);
            }
        }
        result.passes = passes.ToArray(); result.pass_count = result.passes.Length; result.messages = Messages(shader);
        string semantic = result.name + "|" + result.guid + "|" + result.blob_sha256 + "|" + result.parsed_form_serialized_sha256 + "|" +
            JsonUtility.ToJson(new Config { platforms = result.platforms, offsets = result.offsets, compressed_lengths = result.compressed_lengths, decompressed_lengths = result.decompressed_lengths });
        result.semantic_sha256 = Sha(Encoding.UTF8.GetBytes(semantic));
        return result;
    }
    static void Validate(Snapshot value)
    {
        Require(value.name == config.expected_name && value.guid == config.expected_guid, "Imported Shader identity changed");
        Require(value.blob_bytes == config.expected_blob_bytes && value.blob_sha256 == config.expected_blob_sha256, "Original compiled program bytes changed");
        Require(Equal(value.platforms, config.platforms) && Equal(value.offsets, config.offsets) && Equal(value.compressed_lengths, config.compressed_lengths) && Equal(value.decompressed_lengths, config.decompressed_lengths), "Original program arrays changed");
        Require(value.properties == config.expected_properties && value.subshaders == config.expected_subshaders && value.pass_count == config.expected_passes && value.subprograms == config.expected_subprograms, "ParsedForm structure changed");
        Require(value.passes.Length == config.keyword_masks.Length, "ParsedForm pass mask count");
        for (int i = 0; i < value.passes.Length; i++) Require(Equal(value.passes[i].keyword_mask, config.keyword_masks[i].values), "Original keyword mask changed in pass " + i);
        Require(value.passes[5].fog_exp_found && value.passes[5].fog_exp_index == 4 && value.passes[5].fog_exp2_found && value.passes[5].fog_exp2_index == 5, "Original FOG keyword indices changed");
    }
    static void Log(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Assert) report.console_error_count++;
        if (type == LogType.Exception) report.console_exception_count++;
        if (type == LogType.Warning) report.console_warning_count++;
        if (condition == "Unity's attempt to overwrite the YAML Shader asset has been blocked: " + config.asset_path) report.save_protection_messages++;
    }
    public static void Run()
    {
        report = new Report(); string output = null; int exit = 1;
        try
        {
            output = Arg("-shaderProbeReport"); report.phase = Arg("-shaderProbePhase");
            Require(report.phase == "import" || report.phase == "reload", "Unknown fixture phase");
            string configPath = Arg("-shaderProbeConfig"); report.config_sha256 = ShaFile(configPath); config = JsonUtility.FromJson<Config>(File.ReadAllText(configPath));
            report.unity_version = Application.unityVersion; Require(report.unity_version == "2020.3.33f1", "Matching Editor version required");
            Require(!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode, "Play must remain stopped");
            Require(ShaFile(AssetFile(config.asset_path)) == config.expected_asset_sha256 && ShaFile(AssetFile(config.asset_path + ".meta")) == config.expected_meta_sha256, "Pinned fixture asset/meta changed before verification");
            Require(ShaFile(AssetFile(config.dependency_path)) == config.dependency_sha256 && ShaFile(AssetFile(config.dependency_path + ".meta")) == config.dependency_meta_sha256, "Pinned dependency asset/meta changed");
            Application.logMessageReceived += Log;
            AssetDatabase.ImportAsset(config.asset_path, ImportAssetOptions.ForceSynchronousImport);
            Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(config.asset_path); Require(shader != null, "Candidate did not import as a real Shader");
            Require(AssetDatabase.GUIDToAssetPath(config.dependency_guid) == config.dependency_path && AssetDatabase.LoadAssetAtPath<Shader>(config.dependency_path) != null, "Original dependency Shader GUID did not resolve");
            report.dependency_guid_resolved = true; report.imported = Capture(shader); Validate(report.imported);
            report.payload_retained = true; report.keyword_masks_retained = true; report.original_meta_guid_retained = true;
            if (report.phase == "reload")
            {
                Report previous = JsonUtility.FromJson<Report>(File.ReadAllText(Arg("-shaderProbePrevious")));
                Require(previous.status == "passed" && previous.imported.semantic_sha256 == report.imported.semantic_sha256, "Fresh-process native shader state differs from first import");
                report.fresh_process_reload_compared = true;
            }
            EditorUtility.SetDirty(shader); report.dirty_before_save = EditorUtility.IsDirty(shader);
            Require(report.dirty_before_save, "Save-protection test did not mark candidate dirty");
            AssetDatabase.SaveAssets();
            Require(report.save_protection_messages >= 1, "Original AvoidSavingYamlShaders protection was not observed");
            report.after_protected_save = Capture(shader); Validate(report.after_protected_save);
            Require(report.imported.semantic_sha256 == report.after_protected_save.semantic_sha256, "Native shader state changed after protected SaveAssets");
            Require(ShaFile(AssetFile(config.asset_path)) == config.expected_asset_sha256 && ShaFile(AssetFile(config.asset_path + ".meta")) == config.expected_meta_sha256, "Protected shader or meta bytes changed");
            report.protected_save_bytes_unchanged = true;
            foreach (Message message in report.after_protected_save.messages) Require(message.severity != "Error", "ShaderUtil reported a genuine compiler error");
            Require(report.console_error_count == 0 && report.console_exception_count == 0, "Isolated Editor logged errors/exceptions");
            report.status = "passed"; exit = 0;
        }
        catch (Exception error) { report.error_type = error.GetType().FullName; report.error_message = error.Message; }
        finally
        {
            Application.logMessageReceived -= Log;
            if (output != null) File.WriteAllText(output, JsonUtility.ToJson(report, true));
            EditorApplication.Exit(exit);
        }
    }
}
