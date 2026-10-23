using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

// Diagnostic-only project: original shader data, one new empty scene, no game code.
public static class BuildOriginalShaderPrograms
{
    [Serializable] public class Input { public string asset_path, sha256, meta_sha256, guid, name; }
    [Serializable] public class Config { public string project, graphics_sha256; public Input[] shaders; }
    [Serializable] public class Variant { public string shader, pass, pass_type, shader_type; public int variants; }
    [Serializable] public class Result
    {
        public string schema = "tiny-original-shader-windows-build/v1", status = "starting", unity_version, backend, target, build_options, output_path, exception;
        public int total_errors, total_warnings, partial_constant_buffer_messages;
        public ulong total_bytes;
        public bool development, input_bytes_unchanged, Main_modified = false, player_launched = false, gpu_rendering_tested = false;
        public Variant[] variants;
    }
    public static readonly List<Variant> Variants = new List<Variant>();
    static Result result;
    static string Arg(string name)
    {
        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i + 1 < args.Length; i++) if (args[i] == name) return args[i + 1];
        throw new ArgumentException("Missing exact fixture argument " + name);
    }
    static void Require(bool condition, string message) { if (!condition) throw new InvalidOperationException(message); }
    static string Sha(string path)
    {
        using (var stream = File.OpenRead(path)) using (var hash = SHA256.Create())
            return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
    }
    static void CheckInputs(Config config)
    {
        foreach (Input input in config.shaders)
        {
            Require(input.asset_path.StartsWith("Assets/Resources/", StringComparison.Ordinal) && !input.asset_path.Contains(".."), "Exact fixture resource path required");
            Require(Sha(input.asset_path) == input.sha256 && Sha(input.asset_path + ".meta") == input.meta_sha256, "Original shader/meta bytes changed: " + input.name);
            Require(AssetDatabase.AssetPathToGUID(input.asset_path) == input.guid, "Original GUID changed: " + input.name);
            Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(input.asset_path);
            Require(shader != null && shader.name == input.name, "Original Shader identity failed: " + input.name);
        }
    }
    static void Log(string text, string trace, LogType kind)
    {
        if (text.Contains("Partial constant buffer not found.")) result.partial_constant_buffer_messages++;
    }
    public static void Run()
    {
        result = new Result { unity_version = Application.unityVersion }; string reportPath = null; int exit = 1;
        try
        {
            reportPath = Path.GetFullPath(Arg("-shaderBuildReport"));
            Config config = JsonUtility.FromJson<Config>(File.ReadAllText(Arg("-shaderBuildConfig")));
            Require(Application.unityVersion == "2020.3.33f1", "Exact matching Unity required");
            Require(!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode, "Play must remain stopped");
            Require(Path.GetFullPath(Path.Combine(Application.dataPath, "..")).TrimEnd(Path.DirectorySeparatorChar) == Path.GetFullPath(config.project).TrimEnd(Path.DirectorySeparatorChar), "Unexpected diagnostic project");
            Require(EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows64, "CLI must select Windows64");
            Require(Sha("ProjectSettings/GraphicsSettings.asset") == config.graphics_sha256, "Fixture keep-variant configuration changed");
            Require(config.shaders.Length == 3, "Exactly Stencil, genuine FallbackError, and unchanged SMAA required");
            CheckInputs(config);
            Application.logMessageReceived += Log;
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneWindows64, false);
            PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { GraphicsDeviceType.Direct3D11 });
            EditorUserBuildSettings.development = true;
            result.backend = PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone).ToString();
            result.target = EditorUserBuildSettings.activeBuildTarget.ToString(); result.development = EditorUserBuildSettings.development;
            Require(result.backend == "Mono2x", "Mono backend required");
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            Directory.CreateDirectory("Assets/Scenes");
            Require(EditorSceneManager.SaveScene(scene, "Assets/Scenes/OriginalShaderDiagnostic.unity"), "Cannot save isolated empty scene");
            result.output_path = Path.GetFullPath(Arg("-buildOutput"));
            Require(!File.Exists(result.output_path), "Fresh diagnostic build required");
            BuildOptions options = BuildOptions.Development | BuildOptions.StrictMode; result.build_options = options.ToString();
            File.WriteAllText(reportPath, JsonUtility.ToJson(result, true));
            Debug.Log("ORIGINAL_SHADER_TINY_BUILD_BEGIN");
            var built = BuildPipeline.BuildPlayer(new BuildPlayerOptions { scenes = new[] { "Assets/Scenes/OriginalShaderDiagnostic.unity" },
                locationPathName = result.output_path, target = BuildTarget.StandaloneWindows64, targetGroup = BuildTargetGroup.Standalone, options = options });
            Require(built != null, "BuildReport absent"); result.status = built.summary.result.ToString();
            result.total_errors = built.summary.totalErrors; result.total_warnings = built.summary.totalWarnings; result.total_bytes = built.summary.totalSize;
            CheckInputs(config); result.input_bytes_unchanged = true;
            Require(result.partial_constant_buffer_messages == 0, "Partial constant buffer diagnostic in fixture");
            Require(built.summary.result == BuildResult.Succeeded && result.total_errors == 0 && File.Exists(result.output_path), "Tiny diagnostic Windows build failed");
            Debug.Log("ORIGINAL_SHADER_TINY_BUILD_END"); exit = 0;
        }
        catch (Exception error) { result.exception = error.ToString(); if (result.status == "starting") result.status = "exception"; Debug.LogException(error); }
        finally
        {
            Application.logMessageReceived -= Log; result.variants = Variants.ToArray();
            try { if (reportPath != null) File.WriteAllText(reportPath, JsonUtility.ToJson(result, true)); }
            catch (Exception error) { Debug.LogException(error); exit = 1; }
        }
        EditorApplication.Exit(exit);
    }
}

// Passive observation only: the supplied variants list is never changed.
public sealed class OriginalShaderBuildVariantWitness : IPreprocessShaders
{
    public int callbackOrder { get { return int.MinValue; } }
    public void OnProcessShader(Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data)
    {
        if (BuildOriginalShaderPrograms.Variants.Count >= 512) throw new InvalidOperationException("Shader variant observation bound");
        BuildOriginalShaderPrograms.Variants.Add(new BuildOriginalShaderPrograms.Variant { shader = shader.name, pass = snippet.passName,
            pass_type = snippet.passType.ToString(), shader_type = snippet.shaderType.ToString(), variants = data.Count });
    }
}
