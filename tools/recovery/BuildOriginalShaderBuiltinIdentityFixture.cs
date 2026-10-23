using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

// Recovery-only import/build witness. It does not execute recovered game code.
public static class BuildOriginalShaderBuiltinIdentityFixture
{
    static readonly HashSet<string> ExpectedGuids = new HashSet<string>(StringComparer.Ordinal) {
        "dbe0ca40b3618e44e9ef2664c6daae98", "249cb435a09f39e4e8f6de7901b294b4",
        "1ab811d499b5a8e48bfee808ef436fab", "d2a5536c48f6e914f900eb13ea2f4d68",
        "f7efab54069bc444295f491f1ddf5b51", "e8b204ae22658f64a88cf88172cef9c7",
        "7eda6ccbad6ba14488e843023e0d8dfa"
    };
    [Serializable] public class Dependency { public string kind, guid; public long local_file_id; }
    [Serializable] public class Input
    {
        public string path, sha256, meta_sha256, guid, name;
        public Dependency[] dependencies;
    }
    const string AlphaClipGuid = "988a943d64eaf3d4985396b2fe8febf6";
    [Serializable] public class Config { public string project, graphics_sha256; public Input[] shaders; public bool include_alpha_clip; }
    [Serializable] public class Seen { public string guid, local_id, path, name; }
    [Serializable] public class Witness { public string stage, guid; public Seen[] shaders; }
    [Serializable] public class BuiltinMaterialWitness
    {
        public string builtin_guid, builtin_local_id, builtin_name, material_guid, material_local_id, material_source_path, asset_sha256, meta_sha256;
        public bool shader_instance_equal_after_native_import;
    }
    [Serializable] public class MaterialRecord
    {
        public string file_id, short_path, id, offset, packed_size, source_guid, source_path, type;
    }
    [Serializable] public class PackedMaterials
    {
        public string schema = "Unity2020-actual-packed-Material-API-records/v1";
        public ShaderPackedBuildReportCapture.FileRecord[] files;
        public MaterialRecord[] materials;
    }
    [Serializable] public class Result
    {
        public string schema = "original-selected-Shader-four-builtin-Material-import-build/v1", status = "starting", exception;
        public string unity_version, serialization_mode, target, backend, output_path;
        public int shader_count, total_errors, total_warnings, partial_constant_buffer_messages;
        public bool input_assets_and_metas_unchanged, required_project_dependency_closure_verified, four_builtin_material_witnesses_verified;
        public bool Main_modified = false, original_game_code_executed = false, GPU_tested = false;
        public Witness[] witnesses;
        public ShaderPackedBuildReportCapture.Data packed_shader_build_report;
        public BuiltinMaterialWitness[] builtin_shader_material_witnesses;
        public PackedMaterials packed_material_build_report;
    }
    static readonly List<Witness> witnesses = new List<Witness>();
    static readonly Dictionary<long, Shader> builtinShaders = new Dictionary<long, Shader>();
    static Result result;
    static void Need(bool value, string message) { if (!value) throw new InvalidOperationException(message); }
    static string Arg(string name)
    {
        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i + 1 < args.Length; ++i) if (args[i] == name) return args[i + 1];
        throw new ArgumentException("Missing " + name);
    }
    static string Sha(string path)
    {
        using (var stream = File.OpenRead(path)) using (var hash = SHA256.Create())
            return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
    }
    static Shader Load(Input row)
    {
        Need((ExpectedGuids.Contains(row.guid) || row.guid == AlphaClipGuid) && row.path == "Assets/Resources/OriginalShaders/" + row.guid + ".asset", "Exact selected isolated resource path/GUID required");
        Need(Sha(row.path) == row.sha256 && Sha(row.path + ".meta") == row.meta_sha256, "Input changed: " + row.guid);
        Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(row.path);
        string guid; long local;
        Need(shader != null && shader.name == row.name && AssetDatabase.TryGetGUIDAndLocalFileIdentifier(shader, out guid, out local)
             && guid == row.guid && local == 4800000, "Shader identity changed: " + row.guid);
        return shader;
    }
    static string Key(string guid, long local) { return guid + ":" + local.ToString(System.Globalization.CultureInfo.InvariantCulture); }
    static void OutputInsideFixture(string path, string project)
    {
        string root = Path.GetFullPath(Path.Combine(project, ".."));
        Need(Path.GetFileName(root).StartsWith("OriginalShaderBuiltinIdentityFixture-", StringComparison.Ordinal), "Named isolated fixture required");
        string full = Path.GetFullPath(path), prefix = root.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
        string sourcePrefix = Path.GetFullPath(project).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
        Need(full.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) && !full.StartsWith(sourcePrefix, StringComparison.OrdinalIgnoreCase), "Output must be inside owned fixture, outside source project");
    }
    static void Reach(string guid, Dictionary<string, Input> inputs, HashSet<string> visited, HashSet<string> required)
    {
        if (!visited.Add(guid)) return;
        Input row = inputs[guid];
        foreach (Dependency dep in row.dependencies)
        {
            required.Add(Key(dep.guid, dep.local_file_id));
            if (dep.kind == "project")
            {
                Need(dep.local_file_id == 4800000 && inputs.ContainsKey(dep.guid), "Unresolved project dependency");
                Reach(dep.guid, inputs, visited, required);
            }
            else Need(dep.kind == "builtin" && dep.guid == "0000000000000000f000000000000000", "Unknown dependency kind");
        }
    }
    static void Check(Config config, string stage)
    {
        var inputs = new Dictionary<string, Input>();
        foreach (Input row in config.shaders) { Need(row.dependencies != null && !inputs.ContainsKey(row.guid), "Unique explicit inputs required"); inputs.Add(row.guid, row); }
        var expected = new HashSet<string>(ExpectedGuids);
        if (config.include_alpha_clip) expected.Add(AlphaClipGuid);
        Need(expected.SetEquals(inputs.Keys), "Exactly the reviewed seven identities plus explicitly enabled AlphaClip required");
        foreach (Input row in config.shaders)
        {
            Shader shader = Load(row);
            var required = new HashSet<string>();
            Reach(row.guid, inputs, new HashSet<string>(), required);
            var seen = new HashSet<string>(); var records = new List<Seen>();
            foreach (UnityEngine.Object value in EditorUtility.CollectDependencies(new UnityEngine.Object[] { shader }))
            {
                Shader dependency = value as Shader;
                if (dependency == null) continue;
                string guid; long local;
                Need(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(dependency, out guid, out local), "Actual Shader GUID/local identity unavailable");
                string key = Key(guid, local); seen.Add(key);
                records.Add(new Seen { guid = guid, local_id = local.ToString(System.Globalization.CultureInfo.InvariantCulture), path = AssetDatabase.GetAssetPath(dependency), name = dependency.name });
                if (inputs.ContainsKey(guid))
                    Need(local == 4800000 && (guid == row.guid || required.Contains(key)), "Unexpected project Shader dependency: " + guid);
                else
                {
                    Need(guid == "0000000000000000f000000000000000", "Unexpected external Shader GUID");
                    if (local == 6 || local == 7 || local == 46 || local == 10490)
                    {
                        Need(!builtinShaders.ContainsKey(local) || builtinShaders[local] == dependency, "Builtin identity resolved to different objects");
                        builtinShaders[local] = dependency;
                    }
                }
            }
            foreach (string key in required) Need(seen.Contains(key), "Missing explicit original Shader dependency: " + key);
            witnesses.Add(new Witness { stage = stage, guid = row.guid, shaders = records.ToArray() });
        }
        result.required_project_dependency_closure_verified = true;
    }
    static BuiltinMaterialWitness[] CreateBuiltinWitnesses()
    {
        const string folder = "Assets/Resources/BuiltinIdentityWitnesses";
        Need(!AssetDatabase.IsValidFolder(folder), "Fresh builtin witness folder required");
        Need(!string.IsNullOrEmpty(AssetDatabase.CreateFolder("Assets/Resources", "BuiltinIdentityWitnesses")), "Cannot create diagnostic witness folder");
        var rows = new List<BuiltinMaterialWitness>();
        foreach (long id in new long[] { 6, 7, 46, 10490 })
        {
            Need(builtinShaders.ContainsKey(id), "Actual dependency closure did not expose required builtin identity");
            Shader shader = builtinShaders[id]; string builtinGuid; long builtinId;
            Need(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(shader, out builtinGuid, out builtinId)
                 && builtinGuid == "0000000000000000f000000000000000" && builtinId == id, "Actual builtin source identity changed");
            string path = folder + "/Builtin-" + id.ToString(System.Globalization.CultureInfo.InvariantCulture) + ".mat";
            Need(!File.Exists(path), "Fresh diagnostic Material required");
            AssetDatabase.CreateAsset(new Material(shader), path);
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport);
            Material material = AssetDatabase.LoadAssetAtPath<Material>(path); string guid; long local;
            Need(material != null && material.shader == shader, "Material reference must retain the exact builtin instance");
            Need(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(material, out guid, out local), "Material GUID/local identity unavailable");
            rows.Add(new BuiltinMaterialWitness { builtin_guid = builtinGuid, builtin_local_id = id.ToString(System.Globalization.CultureInfo.InvariantCulture),
                builtin_name = shader.name, material_guid = guid, material_local_id = local.ToString(System.Globalization.CultureInfo.InvariantCulture), material_source_path = path,
                asset_sha256 = Sha(path), meta_sha256 = Sha(path + ".meta"), shader_instance_equal_after_native_import = true });
        }
        return rows.ToArray();
    }
    static PackedMaterials CaptureMaterials(BuildReport report)
    {
        var files = new List<ShaderPackedBuildReportCapture.FileRecord>();
        foreach (BuildFile file in report.files) files.Add(new ShaderPackedBuildReportCapture.FileRecord {
            id = file.id.ToString(System.Globalization.CultureInfo.InvariantCulture), path = file.path });
        var rows = new List<MaterialRecord>();
        foreach (PackedAssets packed in report.packedAssets) foreach (PackedAssetInfo asset in packed.contents)
        {
            if (asset.type != typeof(Material)) continue;
            rows.Add(new MaterialRecord { file_id = packed.file.ToString(System.Globalization.CultureInfo.InvariantCulture), short_path = packed.shortPath,
                id = asset.id.ToString(System.Globalization.CultureInfo.InvariantCulture), offset = asset.offset.ToString(System.Globalization.CultureInfo.InvariantCulture),
                packed_size = asset.packedSize.ToString(System.Globalization.CultureInfo.InvariantCulture), source_guid = asset.sourceAssetGUID.ToString(), source_path = asset.sourceAssetPath, type = asset.type.FullName });
        }
        return new PackedMaterials { files = files.ToArray(), materials = rows.ToArray() };
    }
    static void VerifyBuiltinWitnesses()
    {
        Need(result.builtin_shader_material_witnesses != null && result.builtin_shader_material_witnesses.Length == 4, "Exactly four diagnostic Material witnesses required");
        var verifiedIds = new HashSet<string>(); var verifiedMaterials = new HashSet<string>();
        foreach (BuiltinMaterialWitness row in result.builtin_shader_material_witnesses)
        {
            Need(verifiedIds.Add(row.builtin_local_id) && verifiedMaterials.Add(row.material_guid), "Unique builtin and diagnostic Material identities required");
            Material material = AssetDatabase.LoadAssetAtPath<Material>(row.material_source_path); string guid; long local;
            Need(Sha(row.material_source_path) == row.asset_sha256 && Sha(row.material_source_path + ".meta") == row.meta_sha256
                 && material != null && material.shader == builtinShaders[long.Parse(row.builtin_local_id, System.Globalization.CultureInfo.InvariantCulture)], "Diagnostic Material input or reference changed during build");
            Need(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(material, out guid, out local) && guid == row.material_guid
                 && local.ToString(System.Globalization.CultureInfo.InvariantCulture) == row.material_local_id, "Diagnostic Material identity changed during build");
            int matches = 0;
            foreach (MaterialRecord packed in result.packed_material_build_report.materials)
                if (packed.source_guid == row.material_guid) {
                    Need(packed.source_path == row.material_source_path && packed.type == "UnityEngine.Material", "Actual packed diagnostic Material source identity changed");
                    matches++;
                }
            Need(matches == 1, "Exactly one actual packed record per diagnostic Material GUID required");
        }
        Need(verifiedIds.SetEquals(new[] { "6", "7", "46", "10490" }), "Exactly four proven Editor builtin localIDs required");
        result.four_builtin_material_witnesses_verified = true;
    }
    static void VerifyPackedProjectShaders(Config config)
    {
        Need(result.packed_shader_build_report != null && result.packed_shader_build_report.shaders != null, "Actual Shader API capture required");
        foreach (Input row in config.shaders) {
            int matches = 0;
            foreach (ShaderPackedBuildReportCapture.ShaderRecord packed in result.packed_shader_build_report.shaders)
                if (packed.source_guid == row.guid) {
                    Need(packed.source_path == row.path && packed.type == "UnityEngine.Shader", "Actual packed Shader source identity changed");
                    matches++;
                }
            Need(matches == 1, "Exactly one actual packed record per selected project Shader required");
        }
    }
    static void Log(string message, string trace, LogType kind)
    {
        if (message.Contains("Partial constant buffer not found.")) result.partial_constant_buffer_messages++;
    }
    public static void Run()
    {
        result = new Result { unity_version = Application.unityVersion };
        string reportPath = null; bool reportPathVerified = false; int exit = 1;
        Application.logMessageReceived += Log;
        try
        {
            reportPath = Path.GetFullPath(Arg("-shaderBuildReport"));
            Config config = JsonUtility.FromJson<Config>(File.ReadAllText(Arg("-shaderBuildConfig")));
            OutputInsideFixture(reportPath, config.project);
            Need(!File.Exists(reportPath), "Fresh report path required");
            reportPathVerified = true;
            Need(config.shaders != null && config.shaders.Length == (config.include_alpha_clip ? 8 : 7), "Exact explicitly selected Shader count required");
            result.shader_count = config.shaders.Length;
            Need(Application.unityVersion == "2020.3.33f1" && EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows64, "Matching Editor/target required");
            Need(!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode, "Play mode forbidden in fixture builder");
            Need(Path.GetFullPath(Path.Combine(Application.dataPath, "..")).TrimEnd(Path.DirectorySeparatorChar) == Path.GetFullPath(config.project).TrimEnd(Path.DirectorySeparatorChar), "Exact fixture path required");
            Need(EditorSettings.serializationMode == SerializationMode.Mixed && Sha("ProjectSettings/GraphicsSettings.asset") == config.graphics_sha256, "Initial Mixed and exact keep-list required");
            result.serialization_mode = EditorSettings.serializationMode.ToString();
            Check(config, "after-native-import");
            result.builtin_shader_material_witnesses = CreateBuiltinWitnesses();
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneWindows64, false);
            PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { GraphicsDeviceType.Direct3D11 });
            EditorUserBuildSettings.development = true;
            result.target = EditorUserBuildSettings.activeBuildTarget.ToString();
            result.backend = PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone).ToString();
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            Directory.CreateDirectory("Assets/Scenes");
            Need(EditorSceneManager.SaveScene(scene, "Assets/Scenes/OriginalShaderBuiltinIdentityDiagnostic.unity"), "Cannot save diagnostic scene");
            result.output_path = Path.GetFullPath(Arg("-buildOutput"));
            OutputInsideFixture(result.output_path, config.project);
            Need(!File.Exists(result.output_path), "Fresh build output required");
            BuildReport built = BuildPipeline.BuildPlayer(new BuildPlayerOptions {
                scenes = new[] { "Assets/Scenes/OriginalShaderBuiltinIdentityDiagnostic.unity" }, locationPathName = result.output_path,
                target = BuildTarget.StandaloneWindows64, targetGroup = BuildTargetGroup.Standalone, options = BuildOptions.Development | BuildOptions.StrictMode });
            Need(built != null, "Actual BuildReport required");
            result.packed_shader_build_report = ShaderPackedBuildReportCapture.Capture(built);
            result.packed_material_build_report = CaptureMaterials(built);
            result.status = built.summary.result.ToString(); result.total_errors = built.summary.totalErrors; result.total_warnings = built.summary.totalWarnings;
            Check(config, "after-player-build");
            VerifyPackedProjectShaders(config);
            VerifyBuiltinWitnesses();
            Need(Sha("ProjectSettings/GraphicsSettings.asset") == config.graphics_sha256, "Keep-list changed during build");
            result.input_assets_and_metas_unchanged = true;
            Need(built.summary.result == BuildResult.Succeeded && result.total_errors == 0 && result.partial_constant_buffer_messages == 0 && File.Exists(result.output_path), "Actual collection build failed");
            exit = 0;
        }
        catch (Exception error) { result.exception = error.ToString(); result.status = "failed_or_guard_refused"; Debug.LogException(error); }
        finally
        {
            Application.logMessageReceived -= Log; result.witnesses = witnesses.ToArray();
            try { if (reportPathVerified) File.WriteAllText(reportPath, JsonUtility.ToJson(result, true)); } catch { exit = 1; }
        }
        EditorApplication.Exit(exit);
    }
}
