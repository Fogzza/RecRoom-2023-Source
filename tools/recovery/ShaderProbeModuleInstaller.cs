using System;
using System.IO;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;

// Isolated fixture only; Client API resolves the Editor's own built-in modules.
public static class ShaderProbeModuleInstaller
{
    static AddRequest request;
    static double deadline;
    static int index;
    static readonly string[] Modules = { "com.unity.modules.assetbundle@1.0.0", "com.unity.modules.jsonserialize@1.0.0" };
    public static void Run()
    {
        if (UnityEngine.Application.unityVersion != "2020.3.33f1") throw new InvalidOperationException("Exact fixture Editor required");
        index = 0;
        request = Client.Add(Modules[index]);
        deadline = EditorApplication.timeSinceStartup + 120;
        EditorApplication.update += Poll;
    }
    static void Poll()
    {
        if (!request.IsCompleted && EditorApplication.timeSinceStartup <= deadline) return;
        bool success = request.IsCompleted && request.Status == StatusCode.Success;
        if (success && ++index < Modules.Length)
        {
            request = Client.Add(Modules[index]);
            return;
        }
        EditorApplication.update -= Poll;
        if (!success) UnityEngine.Debug.LogError("Isolated shader probe module install failed: " + (request.Error == null ? "timeout" : request.Error.message));
        else UnityEngine.Debug.Log("ISOLATED_SHADER_MODULES_RESOLVED");
        EditorApplication.Exit(success ? 0 : 1);
    }
}
