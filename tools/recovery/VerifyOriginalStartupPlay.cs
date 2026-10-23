// Temporary Editor-only observation. Never saves scenes or changes game scripts.
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class VerifyOriginalStartupPlay
{
    const string Key = "SolarNet.OriginalStartupPlay.";
    const string Startup = "Assets/Core/Scenes/main_root.unity";
    [Serializable] sealed class Result
    {
        public string schema = "original-startup-Play-mode-observation/v1";
        public string status, startedUtc, finishedUtc, sceneAtStart;
        public bool enteredPlayMode, framesAdvanced, returnedToEditMode;
        public bool startupFlowVerified, loginVerified, dormVerified;
        public bool originalScenesSaved, gameScriptsChanged;
        public bool previousRunInBackground, restoredRunInBackground;
        public int firstFrame, lastFrame, errorCount, exceptionCount, assertionCount;
        public double observedSeconds;
        public string[] loadedScenes;
        public int activeCameras;
    }
    static VerifyOriginalStartupPlay()
    {
        if (SessionState.GetBool(Key + "active", false)) Subscribe();
    }
    static void Subscribe()
    {
        EditorApplication.update -= Tick;
        EditorApplication.update += Tick;
        EditorApplication.playModeStateChanged -= Mode;
        EditorApplication.playModeStateChanged += Mode;
        Application.logMessageReceived -= Log;
        Application.logMessageReceived += Log;
    }
    static Result Read()
    {
        return JsonUtility.FromJson<Result>(SessionState.GetString(Key + "result", "{}"));
    }
    static void Write(Result value)
    {
        string json = JsonUtility.ToJson(value, true);
        SessionState.SetString(Key + "result", json);
        File.WriteAllText(SessionState.GetString(Key + "output", ""), json + "\n");
    }
    public static void Run()
    {
        string expectedProject = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
        if (!expectedProject.EndsWith(Path.DirectorySeparatorChar + "RR23", StringComparison.OrdinalIgnoreCase)
            || Application.unityVersion != "2020.3.33f1"
            || EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode
            || SessionState.GetBool(Key + "active", false)
            || SceneManager.sceneCount != 1 || SceneManager.GetActiveScene().path != Startup
            || SceneManager.GetActiveScene().isDirty)
            throw new InvalidOperationException("Expected clean original RR23 main_root in matching Editor.");
        var args = Environment.GetCommandLineArgs(); string output = null;
        for (int i = 0; i + 1 < args.Length; i++)
            if (args[i] == "-recoveryPlayProbeOutput") output = Path.GetFullPath(args[i + 1]);
        string allowed = Path.GetFullPath(Path.Combine(expectedProject, "..", "Recovery", "RecRoom-2023-04-18", "Validation"))
            + Path.DirectorySeparatorChar;
        if (output == null || !output.StartsWith(allowed, StringComparison.OrdinalIgnoreCase)
            || File.Exists(output) || !Directory.Exists(Path.GetDirectoryName(output)))
            throw new InvalidOperationException("Fresh outside-project observation output required.");
        SessionState.SetString(Key + "output", output);
        SessionState.SetBool(Key + "active", true);
        SessionState.SetFloat(Key + "started", (float)EditorApplication.timeSinceStartup);
        Write(new Result { status = "requesting_Play_mode", startedUtc = DateTime.UtcNow.ToString("o"),
            sceneAtStart = Startup, previousRunInBackground = Application.runInBackground });
        Subscribe(); EditorApplication.isPlaying = true;
    }
    static void Mode(PlayModeStateChange state)
    {
        if (!SessionState.GetBool(Key + "active", false)) return;
        var r = Read();
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            Application.runInBackground = true;
            r.enteredPlayMode = true; r.status = "observing_Play_mode";
            r.firstFrame = r.lastFrame = Time.frameCount;
            SessionState.SetFloat(Key + "playStarted", (float)EditorApplication.timeSinceStartup);
            Write(r);
        }
        if (state == PlayModeStateChange.EnteredEditMode)
        {
            Application.runInBackground = r.previousRunInBackground;
            r.restoredRunInBackground = Application.runInBackground == r.previousRunInBackground;
            r.returnedToEditMode = true; r.finishedUtc = DateTime.UtcNow.ToString("o");
            if (r.status == "observing_Play_mode" || r.status == "requesting_Play_mode") r.status = "Play_mode_stopped_before_observation_finished";
            Write(r); SessionState.SetBool(Key + "active", false);
            EditorApplication.update -= Tick; EditorApplication.playModeStateChanged -= Mode;
            Application.logMessageReceived -= Log;
            bool completed = r.status == "Play_mode_frames_advanced_startup_flow_unverified"
                && r.enteredPlayMode && r.observedSeconds >= 10
                && r.lastFrame - r.firstFrame >= 10 && r.framesAdvanced
                && r.restoredRunInBackground
                && r.errorCount == 0 && r.exceptionCount == 0 && r.assertionCount == 0;
            EditorApplication.Exit(completed ? 0 : 3);
        }
    }
    static void Tick()
    {
        if (!SessionState.GetBool(Key + "active", false)) return;
        var r = Read(); double now = EditorApplication.timeSinceStartup;
        if (now - SessionState.GetFloat(Key + "started", 0) > 90)
        {
            r.status = "observation_timeout"; Write(r);
            if (EditorApplication.isPlaying) EditorApplication.isPlaying = false;
            else { SessionState.SetBool(Key + "active", false); EditorApplication.Exit(4); }
            return;
        }
        if (!EditorApplication.isPlaying || !r.enteredPlayMode || r.status != "observing_Play_mode") return;
        EditorApplication.QueuePlayerLoopUpdate();
        r.lastFrame = Time.frameCount;
        r.observedSeconds = now - SessionState.GetFloat(Key + "playStarted", (float)now);
        r.framesAdvanced = r.lastFrame - r.firstFrame >= 10;
        if (r.observedSeconds < 10) { Write(r); return; }
        r.loadedScenes = new string[SceneManager.sceneCount];
        for (int i = 0; i < r.loadedScenes.Length; i++) r.loadedScenes[i] = SceneManager.GetSceneAt(i).path;
        r.activeCameras = Camera.allCamerasCount;
        r.status = r.framesAdvanced ? "Play_mode_frames_advanced_startup_flow_unverified" : "Play_mode_frames_did_not_advance";
        Write(r); EditorApplication.isPlaying = false;
    }
    static void Log(string message, string stack, LogType type)
    {
        if (!SessionState.GetBool(Key + "active", false)) return;
        if (type != LogType.Error && type != LogType.Exception && type != LogType.Assert) return;
        var r = Read(); if (type == LogType.Exception) r.exceptionCount++;
        else if (type == LogType.Assert) r.assertionCount++; else r.errorCount++;
        Write(r); // Counts only: account data and arbitrary log strings are excluded.
    }
}
