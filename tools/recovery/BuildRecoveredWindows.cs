using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

// Builds the actual configured game. No substitute scene or startup code.
public static class BuildRecoveredWindows
{
    [Serializable]
    private sealed class Result
    {
        public string status, unityVersion, backend, originalVersion, buildVersion, outputPath, requestedBuildOptions, exception;
        public string[] scenes;
        public int totalErrors, totalWarnings;
        public ulong totalBytes;
        public bool gameplayVerified, loginVerified, dormVerified;
    }

    private static string Arg(string name)
    {
        var args = Environment.GetCommandLineArgs();
        for (int n = 0; n + 1 < args.Length; n++)
            if (args[n] == name) return args[n + 1];
        throw new ArgumentException("Missing build argument: " + name);
    }

    public static void Run()
    {
        var result = new Result { status = "starting", unityVersion = Application.unityVersion };
        string reportPath = null;
        int exitCode = 1;
        string originalVersion = null;
        try
        {
            reportPath = Arg("-recoveryBuildReport");
            originalVersion = PlayerSettings.bundleVersion;
            if (Application.unityVersion != "2020.3.33f1") throw new InvalidOperationException("Wrong Unity version");
            result.backend = PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone).ToString();
            result.originalVersion = originalVersion;
            result.buildVersion = Arg("-recoveryBuildVersion");
            result.scenes = EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
            if (result.scenes.Length != 107 || result.scenes.Distinct().Count() != 107 || result.scenes[0] != "Assets/Core/Scenes/main_root.unity" || result.scenes.Any(s => !File.Exists(s)))
                throw new InvalidOperationException("Original complete scene list is incomplete or changed");
            result.outputPath = Path.GetFullPath(Arg("-buildOutput"));
            if (File.Exists(result.outputPath)) throw new IOException("Refusing to overwrite an existing player");
            var options = BuildOptions.Development | BuildOptions.StrictMode;
            result.requestedBuildOptions = options.ToString();
            File.WriteAllText(reportPath, JsonUtility.ToJson(result, true));
            Debug.Log("SOLARNET_FULL_BUILD_BEGIN backend=" + result.backend + " scenes=" + result.scenes.Length);
            // Use the existing backend; never silently change Mono/IL2CPP or render settings.
            PlayerSettings.bundleVersion = result.buildVersion;
            var built = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = result.scenes,
                locationPathName = result.outputPath,
                targetGroup = BuildTargetGroup.Standalone,
                target = BuildTarget.StandaloneWindows64,
                options = options
            });
            if (built == null) throw new InvalidOperationException("BuildPipeline returned no BuildReport");
            result.status = built.summary.result.ToString();
            result.totalErrors = built.summary.totalErrors;
            result.totalWarnings = built.summary.totalWarnings;
            result.totalBytes = built.summary.totalSize;
            exitCode = built.summary.result == BuildResult.Succeeded && result.totalErrors == 0 && File.Exists(result.outputPath) ? 0 : 1;
            Debug.Log("SOLARNET_FULL_BUILD_END result=" + result.status + " errors=" + result.totalErrors + " bytes=" + result.totalBytes);
        }
        catch (Exception error)
        {
            result.status = "exception";
            result.exception = error.ToString();
            Debug.LogException(error);
        }
        finally
        {
            try
            {
                if (originalVersion != null) PlayerSettings.bundleVersion = originalVersion;
            }
            catch (Exception error)
            {
                result.exception = (result.exception ?? "") + "\nVersion restoration: " + error;
                exitCode = 1;
                Debug.LogException(error);
            }
            try
            {
                if (reportPath != null) File.WriteAllText(reportPath, JsonUtility.ToJson(result, true));
            }
            catch (Exception error)
            {
                exitCode = 1;
                Debug.LogException(error);
            }
        }
        EditorApplication.Exit(exitCode);
    }
}
