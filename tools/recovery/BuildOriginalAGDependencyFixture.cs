using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

// Isolated two-Shader binary import/build test; no original game code or scenes.
public static class BuildOriginalAGDependencyFixture
{
    [Serializable] public class Input { public string path, sha256, meta_sha256, guid, name; }
    [Serializable] public class Config { public string project, graphics_sha256; public Input[] shaders; }
    [Serializable] public class Dependency { public string path, type, name, guid; public long local_file_id; }
    [Serializable] public class Witness { public string stage; public string[] asset_database_paths; public Dependency[] collected; }
    [Serializable] public class Result
    {
        public string schema = "original-AG-Fallback-binary-import-build/v1", status = "starting", exception, unity_version, serialization_mode, backend, target, output_path;
        public int total_errors, total_warnings, partial_constant_buffer_messages;
        public ulong total_bytes;
        public bool exact_AG_Fallback_dependency_verified, input_assets_and_metas_unchanged, Main_modified = false, player_launched = false;
        public Witness[] dependency_witnesses;
    }
    static Result result;
    static readonly List<Witness> witnesses = new List<Witness>();
    static void Need(bool condition, string message) { if (!condition) throw new InvalidOperationException(message); }
    static string Arg(string name)
    {
        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i + 1 < args.Length; ++i) if (args[i] == name) return args[i + 1];
        throw new ArgumentException("Missing fixture argument " + name);
    }
    static string Sha(string path)
    {
        using (var stream = File.OpenRead(path)) using (var hash = SHA256.Create())
            return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
    }
    static Shader Check(Input input)
    {
        Need(input.path.StartsWith("Assets/Resources/", StringComparison.Ordinal) && !input.path.Contains(".."), "Exact isolated Shader resource required");
        Need(Sha(input.path) == input.sha256 && Sha(input.path + ".meta") == input.meta_sha256, "Original Shader or meta bytes changed: " + input.name);
        Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(input.path);
        Need(shader != null && shader.name == input.name, "Actual Shader identity mismatch: " + input.name);
        string guid; long localId;
        Need(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(shader, out guid, out localId) && guid == input.guid && localId == 4800000, "Original GUID/localFileID changed: " + input.name);
        return shader;
    }
    static void CheckDependency(Config config, string stage)
    {
        Need(config.shaders.Length == 2, "Exactly original AG and original Fallback required");
        Need(config.shaders[0].name == "AG/Standard-Opaque" && config.shaders[0].guid == "90510347b31afb84fba058c6708c7f5c" && config.shaders[1].name == "Hidden/Universal Render Pipeline/FallbackError" && config.shaders[1].guid == "d2a5536c48f6e914f900eb13ea2f4d68", "Exact two original shader identities required");
        Shader ag = Check(config.shaders[0]), fallback = Check(config.shaders[1]);
        string[] paths = AssetDatabase.GetDependencies(config.shaders[0].path, true);
        int pathMatches = 0;
        foreach (string path in paths) if (path == config.shaders[1].path) pathMatches++;
        Need(pathMatches == 1, "AssetDatabase must resolve the exact original Fallback dependency path once");
        UnityEngine.Object[] values = EditorUtility.CollectDependencies(new UnityEngine.Object[] { ag });
        var entries = new List<Dependency>(); int fallbackMatches = 0;
        foreach (UnityEngine.Object value in values)
        {
            if (value == null) continue;
            string guid = null; long localId = 0;
            AssetDatabase.TryGetGUIDAndLocalFileIdentifier(value, out guid, out localId);
            entries.Add(new Dependency { path = AssetDatabase.GetAssetPath(value), type = value.GetType().FullName, name = value.name, guid = guid, local_file_id = localId });
            if (value is Shader)
            {
                Need(value == ag || value == fallback, "Unexpected Shader in original AG dependency closure");
                if (value == fallback)
                {
                    Need(guid == config.shaders[1].guid && localId == 4800000 && AssetDatabase.GetAssetPath(value) == config.shaders[1].path, "Actual native AG PPtr did not resolve to original Fallback GUID/fileID");
                    fallbackMatches++;
                }
            }
        }
        Need(fallbackMatches == 1, "CollectDependencies must return the actual original Fallback object once");
        witnesses.Add(new Witness { stage = stage, asset_database_paths = paths, collected = entries.ToArray() });
        result.exact_AG_Fallback_dependency_verified = true;
    }
    static void Log(string message, string trace, LogType kind)
    {
        if (message.Contains("Partial constant buffer not found.")) result.partial_constant_buffer_messages++;
    }
    public static void Run()
    {
        result = new Result { unity_version = Application.unityVersion }; string reportPath = null; int exit = 1;
        Application.logMessageReceived += Log;
        try
        {
            reportPath = Path.GetFullPath(Arg("-shaderBuildReport"));
            Config config = JsonUtility.FromJson<Config>(File.ReadAllText(Arg("-shaderBuildConfig")));
            Need(Application.unityVersion == "2020.3.33f1" && EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows64, "Matching Unity2020 Windows64 required");
            Need(!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode, "No Play permitted");
            Need(Path.GetFullPath(Path.Combine(Application.dataPath, "..")).TrimEnd(Path.DirectorySeparatorChar) == Path.GetFullPath(config.project).TrimEnd(Path.DirectorySeparatorChar), "Exact isolated project required");
            result.serialization_mode = EditorSettings.serializationMode.ToString();
            Need(EditorSettings.serializationMode == SerializationMode.Mixed, "Mixed must be configured before first import");
            Need(Sha("ProjectSettings/GraphicsSettings.asset") == config.graphics_sha256, "Exact keep-variant GraphicsSettings changed");
            CheckDependency(config, "after-initial-native-import");
            foreach (Input input in config.shaders) AssetDatabase.ImportAsset(input.path, ImportAssetOptions.ForceSynchronousImport);
            CheckDependency(config, "after-explicit-synchronous-import");
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneWindows64, false);
            PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { GraphicsDeviceType.Direct3D11 });
            EditorUserBuildSettings.development = true;
            result.backend = PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone).ToString();
            result.target = EditorUserBuildSettings.activeBuildTarget.ToString();
            Need(result.backend == "Mono2x", "Mono player required");
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            Directory.CreateDirectory("Assets/Scenes");
            Need(EditorSceneManager.SaveScene(scene, "Assets/Scenes/OriginalAGDependencyDiagnostic.unity"), "Cannot save isolated empty scene");
            result.output_path = Path.GetFullPath(Arg("-buildOutput"));
            Need(!File.Exists(result.output_path), "Fresh diagnostic player required");
            BuildReport built = BuildPipeline.BuildPlayer(new BuildPlayerOptions { scenes = new[] { "Assets/Scenes/OriginalAGDependencyDiagnostic.unity" }, locationPathName = result.output_path,
                target = BuildTarget.StandaloneWindows64, targetGroup = BuildTargetGroup.Standalone, options = BuildOptions.Development | BuildOptions.StrictMode });
            Need(built != null, "BuildReport required");
            result.status = built.summary.result.ToString(); result.total_errors = built.summary.totalErrors; result.total_warnings = built.summary.totalWarnings; result.total_bytes = built.summary.totalSize;
            CheckDependency(config, "after-player-build");
            Need(Sha("ProjectSettings/GraphicsSettings.asset") == config.graphics_sha256, "Exact shader keep settings changed after build");
            result.input_assets_and_metas_unchanged = true;
            Need(built.summary.result == BuildResult.Succeeded && result.total_errors == 0 && result.partial_constant_buffer_messages == 0 && File.Exists(result.output_path), "AG dependency build/constant-buffer gate failed");
            exit = 0;
        }
        catch (Exception error) { result.exception = error.ToString(); if (result.status == "starting") result.status = "failed_or_guard_refused"; Debug.LogException(error); }
        finally
        {
            Application.logMessageReceived -= Log; result.dependency_witnesses = witnesses.ToArray();
            try { if (reportPath != null) File.WriteAllText(reportPath, JsonUtility.ToJson(result, true)); } catch { exit = 1; }
        }
        EditorApplication.Exit(exit);
    }
}
