using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;

// Isolated diagnostic player only. Optional genuine URP shader selection tag;
// no render-pipeline implementation or real room rendering is claimed.
// Loads one Shader, never a bundle prefab/scene.
public sealed class OriginalShaderRuntimeProbe : MonoBehaviour
{
    [Serializable] public class BundleInput { public string path, sha256; }
    [Serializable] public class BundleConfig { public BundleInput[] bundles; public int target_index; public string asset_key; }
    [Serializable] public class Pixel { public int r, g, b, a; }
    [Serializable] public class Result
    {
        public string schema = "isolated-original-shader-runtime-probe/v1", status = "starting", mode, exception;
        public string unity_version, graphics_api, graphics_device, shader_name, resource_key, bundle_asset_key;
        public string pipeline_tag_before, pipeline_tag_requested, pipeline_tag_during_probe;
        public int property_count, material_pass_count, frames_at_probe, partial_constant_buffer_messages;
        public bool shader_supported, set_pass_succeeded, render_and_readback_completed, inputs_unchanged;
        public bool Main_modified = false, original_game_code_loaded = false, bundle_prefab_or_scene_loaded = false;
        public bool expected_magenta_check_requested, expected_magenta_check_passed;
        public Pixel center_pixel;
        public string[] property_names, shader_error_lines;
        public BundleInput[] original_bundle_inputs;
    }
    static Result result;
    static readonly List<string> shaderErrors = new List<string>();
    static string Argument(string name, string fallback = null)
    {
        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; ++i)
            if (args[i] == name) { Require(i + 1 < args.Length, "Missing value for " + name); return args[i + 1]; }
        if (fallback != null) return fallback;
        throw new ArgumentException("Required isolated probe argument absent: " + name);
    }
    static void Require(bool condition, string message) { if (!condition) throw new InvalidOperationException(message); }
    static string Sha(string path)
    {
        using (var input = File.OpenRead(path)) using (var hash = SHA256.Create())
            return BitConverter.ToString(hash.ComputeHash(input)).Replace("-", "").ToLowerInvariant();
    }
    static void CheckBundleInputs(BundleConfig config)
    {
        Require(config != null && config.bundles != null && config.bundles.Length > 0 && config.bundles.Length <= 16, "One bounded dependency-closed original bundle list required");
        Require(config.target_index >= 0 && config.target_index < config.bundles.Length && !String.IsNullOrEmpty(config.asset_key), "Exact original container key and target required");
        var paths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (BundleInput input in config.bundles)
        {
            Require(input != null && Path.IsPathRooted(input.path) && paths.Add(Path.GetFullPath(input.path)), "Unique absolute original bundle paths required");
            Require(input.sha256 != null && input.sha256.Length == 64 && File.Exists(input.path) && Sha(input.path) == input.sha256, "Original bundle byte pin changed");
        }
    }
    static void Log(string message, string trace, LogType kind)
    {
        if (message.Contains("Partial constant buffer not found.")) result.partial_constant_buffer_messages++;
        if (shaderErrors.Count < 32 && (kind == LogType.Error || kind == LogType.Exception || kind == LogType.Assert || message.Contains("Shader error") || message.Contains("shader is not supported")))
            shaderErrors.Add(message.Length <= 1024 ? message : message.Substring(0, 1024));
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void StartProbe()
    {
        var host = new GameObject("IsolatedOriginalShaderRuntimeProbe");
        DontDestroyOnLoad(host);
        host.AddComponent<OriginalShaderRuntimeProbe>().StartCoroutine(AfterOneFrame());
    }
    static IEnumerator AfterOneFrame() { yield return null; Execute(); }
    static void Execute()
    {
        string reportPath = null;
        int exit = 1;
        Material material = null;
        RenderTexture render = null;
        Texture2D pixels = null;
        RenderTexture oldActive = RenderTexture.active;
        string oldPipelineTag = Shader.globalRenderPipeline;
        var bundles = new List<AssetBundle>();
        BundleConfig bundleConfig = null;
        result = new Result { unity_version = Application.unityVersion, graphics_api = SystemInfo.graphicsDeviceType.ToString(), graphics_device = SystemInfo.graphicsDeviceName, frames_at_probe = Time.frameCount };
        Application.logMessageReceived += Log;
        try
        {
            reportPath = Path.GetFullPath(Argument("-shaderProbeOutput"));
            Require(!File.Exists(reportPath) && Directory.Exists(Path.GetDirectoryName(reportPath)), "Fresh report path in existing isolated output directory required");
            result.mode = Argument("-shaderProbeMode");
            Require(Application.unityVersion == "2020.3.33f1" && Application.platform == RuntimePlatform.WindowsPlayer, "Exact matching Windows player required");
            Require(SystemInfo.graphicsDeviceType == GraphicsDeviceType.Direct3D11, "D3D11 render device required; do not use -nographics");
            result.pipeline_tag_before = oldPipelineTag;
            result.pipeline_tag_requested = Argument("-shaderProbePipelineTag", "unchanged");
            Require(result.pipeline_tag_requested == "unchanged" || result.pipeline_tag_requested == "UniversalPipeline,LightweightPipeline", "Only unchanged or the genuine URP10.8.1 shader tag is allowed");
            if (result.pipeline_tag_requested != "unchanged") Shader.globalRenderPipeline = result.pipeline_tag_requested;
            result.pipeline_tag_during_probe = Shader.globalRenderPipeline;
            string expectedName = Argument("-shaderProbeExpectedName", "Hidden/Universal Render Pipeline/FallbackError");
            int expectedProperties = Int32.Parse(Argument("-shaderProbeExpectedProperties", "0"));
            int expectedPasses = Int32.Parse(Argument("-shaderProbeExpectedPasses", "1"));
            Require(expectedProperties >= 0 && expectedProperties <= 4096 && expectedPasses > 0 && expectedPasses <= 256, "Explicit bounded original Shader counts required");
            Shader shader;
            if (result.mode == "resources")
            {
                result.resource_key = Argument("-shaderProbeResource", "OriginalNativeFallback");
                shader = Resources.Load<Shader>(result.resource_key);
            }
            else if (result.mode == "bundle")
            {
                bundleConfig = JsonUtility.FromJson<BundleConfig>(File.ReadAllText(Argument("-shaderProbeBundleConfig")));
                CheckBundleInputs(bundleConfig);
                result.original_bundle_inputs = bundleConfig.bundles;
                foreach (BundleInput input in bundleConfig.bundles)
                {
                    AssetBundle loaded = AssetBundle.LoadFromFile(input.path);
                    Require(loaded != null, "Original AssetBundle.LoadFromFile failed: " + Path.GetFileName(input.path));
                    bundles.Add(loaded);
                }
                result.bundle_asset_key = bundleConfig.asset_key;
                shader = bundles[bundleConfig.target_index].LoadAsset<Shader>(bundleConfig.asset_key);
            }
            else throw new InvalidOperationException("Only resources or bundle probe mode is allowed");
            Require(shader != null && shader.name == expectedName, "Exact original runtime Shader identity failed");
            result.shader_name = shader.name; result.shader_supported = shader.isSupported;
            Require(result.shader_supported, "Runtime Shader is unsupported");
            result.property_count = shader.GetPropertyCount();
            Require(result.property_count == expectedProperties, "Original Shader property count changed");
            result.property_names = new string[result.property_count];
            for (int i = 0; i < result.property_count; ++i) result.property_names[i] = shader.GetPropertyName(i);
            material = new Material(shader);
            result.material_pass_count = material.passCount;
            Require(result.material_pass_count == expectedPasses, "Original Shader pass count changed");
            render = RenderTexture.GetTemporary(8, 8, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
            Require(render != null && render.Create(), "Cannot create diagnostic render target");
            RenderTexture.active = render;
            GL.Clear(true, true, Color.green);
            result.set_pass_succeeded = material.SetPass(0);
            Require(result.set_pass_succeeded, "Original Shader pass0 cannot be set");
            Graphics.Blit(Texture2D.whiteTexture, render, material, 0);
            RenderTexture.active = render;
            pixels = new Texture2D(8, 8, TextureFormat.RGBA32, false, true);
            pixels.ReadPixels(new Rect(0, 0, 8, 8), 0, 0, false); pixels.Apply(false, false);
            Color32 center = pixels.GetPixel(4, 4);
            result.center_pixel = new Pixel { r = center.r, g = center.g, b = center.b, a = center.a };
            result.render_and_readback_completed = true;
            string pixelCheck = Argument("-shaderProbePixelCheck", "none");
            Require(pixelCheck == "none" || pixelCheck == "magenta", "Only explicit none or magenta diagnostic pixel check allowed");
            result.expected_magenta_check_requested = pixelCheck == "magenta";
            result.expected_magenta_check_passed = center.r >= 251 && center.g <= 4 && center.b >= 251 && center.a >= 251;
            Require(!result.expected_magenta_check_requested || result.expected_magenta_check_passed, "Original fallback diagnostic pixel differs from explicit magenta expectation");
            if (bundleConfig != null) CheckBundleInputs(bundleConfig);
            result.inputs_unchanged = true;
            Require(result.partial_constant_buffer_messages == 0 && shaderErrors.Count == 0, "Runtime shader/constant-buffer error logged");
            result.status = "exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed"; exit = 0;
        }
        catch (Exception error) { result.status = "failed_or_guard_refused"; result.exception = error.ToString(); }
        finally
        {
            Shader.globalRenderPipeline = oldPipelineTag;
            RenderTexture.active = oldActive;
            if (pixels != null) Destroy(pixels);
            if (material != null) Destroy(material);
            if (render != null) RenderTexture.ReleaseTemporary(render);
            for (int i = bundles.Count - 1; i >= 0; --i) bundles[i].Unload(true);
            result.shader_error_lines = shaderErrors.ToArray();
            Application.logMessageReceived -= Log;
            try { if (reportPath != null) File.WriteAllText(reportPath, JsonUtility.ToJson(result, true)); }
            catch { exit = 1; }
            Application.Quit(exit);
        }
    }
}
