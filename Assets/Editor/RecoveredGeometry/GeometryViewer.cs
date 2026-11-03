#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UILabel = UnityEngine.UIElements.Label;

namespace SolarNet.Recovery.Editor
{
    // Read-only source geometry. All cameras, lights and material copies belong
    // to PreviewRenderUtility, never the recovered scene or prefab.
    public sealed class GeometryViewer : EditorWindow
    {
        const string Styles = "Assets/Editor/RecoveredGeometry/GeometryViewer.uss";
        const string PlayerPrefab = "Assets/Resources/(PlayerValidationFullBodyDummy).prefab";
        const string BodyGuid = "0529b20d821066147b5bb8e36c716d54";
        const string NoseGuid = "d52288ca6829d1b4db3c2465fa23bf2c";
        const string BuiltinGuid = "0000000000000000f000000000000000";
        const string SessionKey = "SolarNet.RecoveredGeometry.Opened";
        const int MaxParts = 4096;

        sealed class Part
        {
            public Mesh mesh;
            public Matrix4x4 matrix;
            public Material[] materials;
            public int firstSubMesh, subMeshCount;
        }
        [Serializable] sealed class Status
        {
            public string view, scene, error, image;
            public int meshes, submeshes, vertices;
            public bool original_geometry = true, temporary_materials = true;
            public bool playable = false, player_bind_pose;
            public Vector3 bounds_center, bounds_size;
        }
        readonly List<Part> parts = new List<Part>();
        readonly Dictionary<int, Material> materials = new Dictionary<int, Material>();
        PreviewRenderUtility preview;
        Material builtin;
        UILabel statusLabel;
        IMGUIContainer viewport;
        Bounds bounds;
        string view = "dorm", error = "";
        int submeshes, vertices;
        float yaw, pitch, distance = 5;
        double nextPoll, captureAfter;
        bool capturePending;
        bool interior;
        Vector3 interiorPosition;
        Quaternion interiorRotation;
        float interiorFieldOfView;

        [InitializeOnLoadMethod]
        static void QueueOpen() { EditorApplication.delayCall += OpenOnce; }
        static void OpenOnce()
        {
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
            { EditorApplication.delayCall += OpenOnce; return; }
            if (SessionState.GetBool(SessionKey, false)) return;
            SessionState.SetBool(SessionKey, true);
            Open();
        }
        [MenuItem("Window/Recovery/Recovered Geometry")]
        public static void Open()
        {
            var window = GetWindow<GeometryViewer>();
            window.titleContent = new GUIContent("Recovered Geometry");
            window.minSize = new Vector2(520, 380);
            window.Show();
            window.Focus();
        }
        void OnEnable()
        {
            var root = rootVisualElement;
            root.Clear();
            root.AddToClassList("geometry-viewer");
            var sheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(Styles);
            if (sheet != null) root.styleSheets.Add(sheet);
            var toolbar = new Toolbar();
            toolbar.AddToClassList("geometry-toolbar");
            toolbar.Add(new ToolbarButton(() => Select("dorm")) { text = "Dorm" });
            toolbar.Add(new ToolbarButton(() => Select("player")) { text = "Player" });
            toolbar.Add(new ToolbarButton(Frame) { text = "Frame all" });
            toolbar.Add(new ToolbarButton(RecoveredSceneView.OpenInspection) { text = "Scene view" });
            root.Add(toolbar);
            var caption = new UILabel("Original meshes · temporary preview materials · not Play Mode");
            caption.AddToClassList("geometry-caption");
            root.Add(caption);
            statusLabel = new UILabel();
            statusLabel.AddToClassList("geometry-status");
            root.Add(statusLabel);
            viewport = new IMGUIContainer(DrawViewport);
            viewport.AddToClassList("geometry-preview");
            root.Add(viewport);
            EditorApplication.update += PollRequest;
            Select("dorm");
        }
        void OnDisable()
        {
            EditorApplication.update -= PollRequest;
            if (preview != null) { preview.Cleanup(); preview = null; }
            ClearMaterials();
        }
        void ClearMaterials()
        {
            foreach (var material in materials.Values)
                if (material != null) DestroyImmediate(material);
            materials.Clear();
        }
        void EnsurePreview()
        {
            if (preview != null) return;
            builtin = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Material.mat");
            string guid; long id;
            if (builtin == null || builtin.shader == null ||
                !AssetDatabase.TryGetGUIDAndLocalFileIdentifier(builtin.shader, out guid, out id) ||
                guid != BuiltinGuid || id != 46)
                throw new InvalidOperationException("Genuine Editor Standard shader identity did not match builtin fileID 46.");
            preview = new PreviewRenderUtility();
            preview.ambientColor = new Color(0.6f, 0.6f, 0.6f, 1);
            preview.camera.clearFlags = CameraClearFlags.Color;
            preview.camera.backgroundColor = new Color(0.09f, 0.11f, 0.15f, 1);
            preview.camera.fieldOfView = 50;
            preview.lights[0].intensity = 1.2f;
            preview.lights[0].transform.rotation = Quaternion.Euler(35, 35, 0);
            preview.lights[1].intensity = 0.8f;
            preview.lights[1].transform.rotation = Quaternion.Euler(340, 215, 0);
        }
        Material PreviewMaterial(Material original)
        {
            int key = original == null ? 0 : original.GetInstanceID();
            Material result;
            if (materials.TryGetValue(key, out result)) return result;
            result = new Material(builtin) { hideFlags = HideFlags.HideAndDontSave, name = "Temporary Geometry Preview" };
            if (original != null)
            {
                string textureProperty = original.HasProperty("_MainTex") && original.GetTexture("_MainTex") != null ? "_MainTex" :
                    original.HasProperty("_BaseMap") && original.GetTexture("_BaseMap") != null ? "_BaseMap" : null;
                if (textureProperty != null)
                {
                    result.SetTexture("_MainTex", original.GetTexture(textureProperty));
                    result.SetTextureScale("_MainTex", original.GetTextureScale(textureProperty));
                    result.SetTextureOffset("_MainTex", original.GetTextureOffset(textureProperty));
                }
                if (original.HasProperty("_BaseColor")) result.SetColor("_Color", original.GetColor("_BaseColor"));
                else if (original.HasProperty("_Color")) result.SetColor("_Color", original.GetColor("_Color"));
            }
            materials.Add(key, result);
            return result;
        }
        void Add(Mesh mesh, Transform transform, Renderer renderer)
        {
            if (mesh == null || mesh.vertexCount == 0 || renderer == null || !renderer.enabled) return;
            if (view == "dorm" && !renderer.gameObject.activeInHierarchy) return;
            if (parts.Count >= MaxParts) throw new InvalidOperationException("Preview geometry exceeds the bounded 4096 mesh limit.");
            // Static-batch vertices already use the native renderer's matrix.
            // The object's Transform can retain its pre-batch authoring offset.
            Matrix4x4 matrix = transform.localToWorldMatrix;
            int firstSubMesh = 0, subMeshCount = mesh.subMeshCount;
            var local = mesh.bounds;
            if (renderer.isPartOfStaticBatch)
            {
                matrix = renderer.localToWorldMatrix;
                var state = new SerializedObject(renderer);
                var batch = state.FindProperty("m_StaticBatchInfo");
                var first = batch == null ? null : batch.FindPropertyRelative("firstSubMesh");
                var count = batch == null ? null : batch.FindPropertyRelative("subMeshCount");
                if (first == null || count == null)
                    throw new InvalidOperationException("Original static-batch submesh range is unavailable.");
                firstSubMesh = first.intValue; subMeshCount = count.intValue;
                if (firstSubMesh < 0 || subMeshCount <= 0 || subMeshCount > mesh.subMeshCount || firstSubMesh > mesh.subMeshCount - subMeshCount)
                    throw new InvalidOperationException("Original static-batch submesh range is outside its shared mesh.");
                local = mesh.GetSubMesh(firstSubMesh).bounds;
                for (int sub = 1; sub < subMeshCount; sub++)
                    local.Encapsulate(mesh.GetSubMesh(firstSubMesh + sub).bounds);
            }
            for (int i = 0; i < 8; i++)
            {
                var corner = local.center + Vector3.Scale(local.extents, new Vector3((i & 1) == 0 ? -1 : 1, (i & 2) == 0 ? -1 : 1, (i & 4) == 0 ? -1 : 1));
                Vector3 world = matrix.MultiplyPoint3x4(corner);
                if (float.IsNaN(world.x) || float.IsInfinity(world.x) || float.IsNaN(world.y) || float.IsInfinity(world.y) || float.IsNaN(world.z) || float.IsInfinity(world.z))
                    throw new InvalidOperationException("Non-finite original mesh bounds.");
                if (parts.Count == 0 && i == 0) bounds = new Bounds(world, Vector3.zero);
                else bounds.Encapsulate(world);
            }
            parts.Add(new Part { mesh = mesh, matrix = matrix, materials = renderer.sharedMaterials, firstSubMesh = firstSubMesh, subMeshCount = subMeshCount });
            submeshes += subMeshCount;
            vertices += mesh.vertexCount;
        }
        void Select(string selected)
        {
            view = selected; error = ""; parts.Clear(); submeshes = vertices = 0; ClearMaterials();
            try
            {
                EnsurePreview();
                if (view == "dorm")
                {
                    Scene scene = SceneManager.GetActiveScene();
                    if (!scene.IsValid() || !scene.isLoaded || scene.name.IndexOf("Dorm", StringComparison.OrdinalIgnoreCase) < 0)
                        throw new InvalidOperationException("Open the recovered Dorm scene, then press Dorm.");
                    foreach (var root in scene.GetRootGameObjects())
                    {
                        foreach (var filter in root.GetComponentsInChildren<MeshFilter>(true))
                            Add(filter.sharedMesh, filter.transform, filter.GetComponent<MeshRenderer>());
                        foreach (var skin in root.GetComponentsInChildren<SkinnedMeshRenderer>(true))
                            Add(skin.sharedMesh, skin.transform, skin);
                    }
                }
                else
                {
                    var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(PlayerPrefab);
                    if (prefab == null) throw new InvalidOperationException("Original full-body validation prefab was not found.");
                    bool body = false, nose = false;
                    foreach (var skin in prefab.GetComponentsInChildren<SkinnedMeshRenderer>(true))
                    {
                        string guid; long id;
                        if (skin.sharedMesh == null || !AssetDatabase.TryGetGUIDAndLocalFileIdentifier(skin.sharedMesh, out guid, out id)) continue;
                        if (guid == BodyGuid) { Add(skin.sharedMesh, skin.transform, skin); body = true; }
                        else if (guid == NoseGuid) { Add(skin.sharedMesh, skin.transform, skin); nose = true; }
                    }
                    if (!body || !nose) throw new InvalidOperationException("Original LOD0 body and nose mesh identities were not both found.");
                }
                if (parts.Count == 0) throw new InvalidOperationException("No nonempty original meshes were loaded for this view.");
                Frame();
                if (view == "dorm")
                    foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
                        foreach (var camera in root.GetComponentsInChildren<Camera>(true))
                            if (camera.name == "[PerfCam]")
                            {
                                interiorPosition = camera.transform.position;
                                interiorRotation = camera.transform.rotation;
                                interiorFieldOfView = camera.fieldOfView;
                                interior = true;
                            }
            }
            catch (Exception e) { error = e.GetType().Name + ": " + e.Message; }
            UpdateStatus(null);
            Repaint();
        }
        void Frame()
        {
            interior = false;
            yaw = view == "player" ? 180 : 135;
            pitch = view == "player" ? 8 : 25;
            distance = Mathf.Max(1, bounds.extents.magnitude / Mathf.Sin(25 * Mathf.Deg2Rad) * 1.12f);
            QueueCapture();
            Repaint();
        }
        void QueueCapture() { capturePending = true; captureAfter = EditorApplication.timeSinceStartup + 0.25; }
        void DrawViewport()
        {
            Rect rect = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            if (rect.width < 2 || rect.height < 2) return;
            Event e = Event.current;
            int control = GUIUtility.GetControlID(FocusType.Passive, rect);
            if (e.type == EventType.MouseDown && e.button == 0 && rect.Contains(e.mousePosition))
            { GUIUtility.hotControl = control; e.Use(); }
            if (e.type == EventType.MouseDrag && GUIUtility.hotControl == control)
            { interior = false; yaw += e.delta.x * 0.6f; pitch = Mathf.Clamp(pitch + e.delta.y * 0.4f, -85, 85); e.Use(); QueueCapture(); Repaint(); }
            if (e.type == EventType.MouseUp && GUIUtility.hotControl == control)
            { GUIUtility.hotControl = 0; e.Use(); QueueCapture(); Repaint(); }
            if (e.type == EventType.ScrollWheel && rect.Contains(e.mousePosition))
            { interior = false; distance = Mathf.Clamp(distance * Mathf.Pow(1.08f, e.delta.y), 0.1f, Mathf.Max(100, bounds.extents.magnitude * 100)); e.Use(); QueueCapture(); Repaint(); }
            if (e.type != EventType.Repaint || preview == null || parts.Count == 0) return;
            bool previousPipelineFlag = Unsupported.useScriptableRenderPipeline;
            bool begun = false;
            Texture texture = null;
            try
            {
                preview.BeginPreview(rect, GUIStyle.none); begun = true;
                preview.camera.clearFlags = CameraClearFlags.Color;
                preview.camera.backgroundColor = new Color(0.09f, 0.11f, 0.15f, 1);
                Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
                preview.camera.transform.SetPositionAndRotation(interior ? interiorPosition : bounds.center - rotation * Vector3.forward * distance, interior ? interiorRotation : rotation);
                preview.camera.fieldOfView = interior ? interiorFieldOfView : 50;
                preview.camera.nearClipPlane = interior ? 0.05f : Mathf.Max(0.01f, distance * 0.001f);
                preview.camera.farClipPlane = Mathf.Max(1000, distance * 5);
                foreach (var part in parts)
                    for (int sub = 0; sub < part.subMeshCount; sub++)
                        preview.DrawMesh(part.mesh, part.matrix, PreviewMaterial(part.materials.Length == 0 ? null : part.materials[Mathf.Min(sub, part.materials.Length - 1)]), part.firstSubMesh + sub);
                preview.Render(false, false);
                texture = preview.EndPreview(); begun = false;
            }
            catch (Exception exception) { error = exception.GetType().Name + ": " + exception.Message; UpdateStatus(null); }
            finally
            {
                try { if (begun) { try { preview.EndPreview(); } catch { } } }
                finally { Unsupported.useScriptableRenderPipeline = previousPipelineFlag; }
            }
            if (texture != null)
            {
                GUI.DrawTexture(rect, texture, ScaleMode.StretchToFill, false);
                if (capturePending && EditorApplication.timeSinceStartup >= captureAfter)
                {
                    capturePending = false;
                    try { SavePreview(texture as RenderTexture); }
                    catch (Exception exception) { error = "Preview export: " + exception.Message; UpdateStatus(null); }
                }
            }
        }
        static string TempFile(string name)
        {
            string project = Directory.GetParent(Application.dataPath).FullName;
            string folder = Path.Combine(project, "Temp");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, name);
        }
        void SavePreview(RenderTexture source)
        {
            if (source == null) { UpdateStatus(null); return; }
            RenderTexture previous = RenderTexture.active;
            Texture2D pixels = null;
            string file = TempFile("SolarNetGeometryPreview.png");
            try
            {
                RenderTexture.active = source;
                pixels = new Texture2D(source.width, source.height, TextureFormat.RGB24, false) { hideFlags = HideFlags.HideAndDontSave };
                pixels.ReadPixels(new Rect(0, 0, source.width, source.height), 0, 0);
                pixels.Apply(false, false);
                File.WriteAllBytes(file, pixels.EncodeToPNG());
            }
            finally { RenderTexture.active = previous; if (pixels != null) DestroyImmediate(pixels); }
            UpdateStatus(file);
        }
        void UpdateStatus(string image)
        {
            if (statusLabel != null) statusLabel.text = error.Length != 0 ? error :
                (view == "player" ? "Original player LOD0 + nose · static bind pose" : "Loaded Dorm geometry") + " · " + parts.Count + " meshes · drag to orbit, wheel to zoom";
            try
            {
                File.WriteAllText(TempFile("SolarNetGeometryPreview.status.json"), JsonUtility.ToJson(new Status {
                    view = view, scene = SceneManager.GetActiveScene().path, error = error,
                    image = image, meshes = parts.Count, submeshes = submeshes, vertices = vertices,
                    player_bind_pose = view == "player", bounds_center = bounds.center, bounds_size = bounds.size
                }, true));
            }
            catch { }
        }
        void PollRequest()
        {
            if (EditorApplication.timeSinceStartup < nextPoll) return;
            nextPoll = EditorApplication.timeSinceStartup + 0.25;
            try
            {
                string file = TempFile("SolarNetGeometryPreview.request");
                if (File.Exists(file) && new FileInfo(file).Length <= 16)
                {
                    string request = File.ReadAllText(file).Trim();
                    File.Delete(file);
                    if (request == "dorm" || request == "player") Select(request);
                    else if (request == "scene") RecoveredSceneView.OpenInspection();
                }
            }
            catch (Exception exception) { error = "Preview request: " + exception.Message; UpdateStatus(null); }
            if (capturePending) Repaint();
        }
    }

    // Uses the native SceneView tools, with a per-window replacement shader.
    // The global rendering flag is restored even on ExitGUIException. This
    // inspection view does not repair or replace the game's render pipeline.
    [EditorWindowTitle(title = "Recovery Scene · inspection", icon = "", useTypeNameAsIconName = false)]
    public sealed class RecoveredSceneView : SceneView
    {
        [Serializable] sealed class ViewStatus
        {
            public string image, capture_error;
            public bool base_gui_returned, pipeline_flag_restored;
            public bool Editor_inspection_only = true, game_pipeline_modified = false;
            public int captured_width, captured_height;
        }
        Shader inspectionShader;
        bool captured, receiptWritten;
        readonly ViewStatus status = new ViewStatus();

        [MenuItem("Window/Recovery/Recovered Scene View")]
        public static void OpenInspection()
        {
            bool existing = Resources.FindObjectsOfTypeAll<RecoveredSceneView>().Length != 0;
            var window = GetWindow<RecoveredSceneView>("Recovery Scene · inspection", true, new Type[] { typeof(SceneView) });
            window.captured = false;
            window.receiptWritten = false;
            window.status.image = null;
            window.status.capture_error = null;
            window.status.base_gui_returned = false;
            window.status.pipeline_flag_restored = false;
            window.titleContent = new GUIContent("Recovery Scene · inspection");
            window.sceneLighting = false;
            window.Show();
            window.Focus();
            var scene = SceneManager.GetActiveScene();
            bool hasBounds = false;
            Bounds bounds = default(Bounds);
            if (scene.IsValid() && scene.isLoaded && scene.name.IndexOf("Dorm", StringComparison.OrdinalIgnoreCase) >= 0)
                foreach (var root in scene.GetRootGameObjects())
                    foreach (var renderer in root.GetComponentsInChildren<Renderer>(true))
                        if (renderer.enabled && renderer.gameObject.activeInHierarchy)
                        {
                            if (!hasBounds) { bounds = renderer.bounds; hasBounds = true; }
                            else bounds.Encapsulate(renderer.bounds);
                        }
            if (!existing && hasBounds && bounds.extents.magnitude > 0 && !float.IsInfinity(bounds.extents.magnitude))
                window.Frame(bounds, true);
            window.Repaint();
        }

        protected override void OnGUI()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) { base.OnGUI(); return; }
            if (inspectionShader == null)
            {
                var material = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Material.mat");
                string guid; long id;
                if (material == null || material.shader == null ||
                    !AssetDatabase.TryGetGUIDAndLocalFileIdentifier(material.shader, out guid, out id) ||
                    guid != "0000000000000000f000000000000000" || id != 46)
                    throw new InvalidOperationException("Genuine Editor Standard shader identity did not match builtin fileID 46.");
                inspectionShader = material.shader;
            }
            SetSceneViewShaderReplace(inspectionShader, "");
            bool prior = Unsupported.useScriptableRenderPipeline;
            bool repaint = Event.current != null && Event.current.type == EventType.Repaint;
            try
            {
                Unsupported.useScriptableRenderPipeline = false;
                Camera.onPostRender += CaptureCamera;
                try { base.OnGUI(); status.base_gui_returned = true; }
                finally { Camera.onPostRender -= CaptureCamera; }
            }
            finally
            {
                Unsupported.useScriptableRenderPipeline = prior;
                status.pipeline_flag_restored = Unsupported.useScriptableRenderPipeline == prior;
                if (repaint && !receiptWritten)
                {
                    receiptWritten = true;
                    try { File.WriteAllText(TempPath("SolarNetRecoveredSceneView.status.json"), JsonUtility.ToJson(status, true)); }
                    catch { }
                }
            }
        }

        void CaptureCamera(Camera rendered)
        {
            if (captured || rendered != camera) return;
            RenderTexture source = RenderTexture.active;
            if (source == null || (rendered.targetTexture != null && source != rendered.targetTexture) ||
                source.width < 2 || source.height < 2 || source.width > 2048 || source.height > 2048)
            { status.capture_error = "No bounded camera render target was available; no image captured."; return; }
            Texture2D pixels = null;
            try
            {
                pixels = new Texture2D(source.width, source.height, TextureFormat.RGB24, false) { hideFlags = HideFlags.HideAndDontSave };
                pixels.ReadPixels(new Rect(0, 0, source.width, source.height), 0, 0, false);
                pixels.Apply(false, false);
                string path = TempPath("SolarNetRecoveredSceneView.png");
                File.WriteAllBytes(path, pixels.EncodeToPNG());
                status.image = path; status.captured_width = source.width; status.captured_height = source.height;
                status.capture_error = ""; captured = true; receiptWritten = false;
            }
            catch (Exception error) { status.capture_error = error.GetType().Name + ": " + error.Message; }
            finally { if (pixels != null) DestroyImmediate(pixels); }
        }
        static string TempPath(string filename)
        {
            string folder = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Temp");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, filename);
        }
    }
}
#endif
