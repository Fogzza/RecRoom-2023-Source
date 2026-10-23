using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.Compilation;
using UnityEditor.SceneManagement;
using UnityEngine;

// Isolated fixture only. This method never reads, loads, or changes the game.
public static class WindowsDevelopmentDefineProbe
{
    [Serializable] private sealed class AssemblyRow
    {
        public string name;
        public string[] defines;
    }

    [Serializable] private sealed class Result
    {
        public string schema = "unity2020-windows64-mono-development-define-probe/v1";
        public string status = "starting", unity_version, target, backend, api_compatibility, output_path, exception;
        public string build_options;
        public int total_errors, total_warnings;
        public bool development;
        public bool main_modified = false, player_launched = false;
        public AssemblyRow[] player_assemblies;
    }

    private static string Arg(string name)
    {
        var args = Environment.GetCommandLineArgs();
        for (int i = 0; i + 1 < args.Length; i++) if (args[i] == name) return args[i + 1];
        throw new ArgumentException("Missing fixture argument " + name);
    }

    public static void Run()
    {
        var result = new Result { unity_version = Application.unityVersion };
        string reportPath = null;
        int exitCode = 1;
        try
        {
            reportPath = Path.GetFullPath(Arg("-defineProbeReport"));
            result.output_path = Path.GetFullPath(Arg("-buildOutput"));
            if (Application.unityVersion != "2020.3.33f1") throw new InvalidOperationException("Exact Editor version required");
            var expectedProject = Path.GetFullPath(Arg("-defineProbeProject"));
            if (Path.GetFullPath(Path.Combine(Application.dataPath, "..")).TrimEnd(Path.DirectorySeparatorChar) != expectedProject.TrimEnd(Path.DirectorySeparatorChar))
                throw new InvalidOperationException("Unexpected fixture project");
            if (File.Exists(result.output_path)) throw new IOException("Fresh player output required");
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("RR23_DEFINE_PROBE_RECORD_DIRECTORY")))
                throw new InvalidOperationException("Inherited ILPP record destination required");
            if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.StandaloneWindows64)
                throw new InvalidOperationException("CLI must select Windows64 before compilation");
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);
            EditorUserBuildSettings.development = true;
            result.target = EditorUserBuildSettings.activeBuildTarget.ToString();
            result.backend = PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone).ToString();
            result.api_compatibility = PlayerSettings.GetApiCompatibilityLevel(BuildTargetGroup.Standalone).ToString();
            result.development = EditorUserBuildSettings.development;
            if (result.backend != "Mono2x") throw new InvalidOperationException("Mono backend required");

            // Only this new empty fixture scene is constructed and saved.
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            Directory.CreateDirectory("Assets/Scenes");
            if (!EditorSceneManager.SaveScene(scene, "Assets/Scenes/DefineProbe.unity")) throw new IOException("Cannot save isolated scene");
            result.player_assemblies = CompilationPipeline.GetAssemblies(AssembliesType.Player)
                .Where(a => a.name == "RR23.WindowsDevelopment.DefineWitness")
                .Select(a => new AssemblyRow { name = a.name, defines = a.defines.OrderBy(d => d, StringComparer.Ordinal).ToArray() }).ToArray();
            if (result.player_assemblies.Length != 1) throw new InvalidOperationException("Exact fixture witness assembly required");
            var options = BuildOptions.Development | BuildOptions.StrictMode;
            result.build_options = options.ToString();
            File.WriteAllText(reportPath, JsonUtility.ToJson(result, true));
            var build = BuildPipeline.BuildPlayer(new BuildPlayerOptions {
                scenes = new[] { "Assets/Scenes/DefineProbe.unity" },
                locationPathName = result.output_path,
                target = BuildTarget.StandaloneWindows64,
                targetGroup = BuildTargetGroup.Standalone,
                options = options
            });
            if (build == null) throw new InvalidOperationException("BuildReport absent");
            result.status = build.summary.result.ToString();
            result.total_errors = build.summary.totalErrors;
            result.total_warnings = build.summary.totalWarnings;
            if (build.summary.result == BuildResult.Succeeded && result.total_errors == 0 && File.Exists(result.output_path)) exitCode = 0;
        }
        catch (Exception error)
        {
            result.status = "exception";
            result.exception = error.ToString();
            Debug.LogException(error);
        }
        finally
        {
            try { if (reportPath != null) File.WriteAllText(reportPath, JsonUtility.ToJson(result, true)); }
            catch (Exception error) { Debug.LogException(error); exitCode = 1; }
        }
        EditorApplication.Exit(exitCode);
    }
}
