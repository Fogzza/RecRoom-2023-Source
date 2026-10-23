#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SolarNet.Recovery.Editor
{
    public static class RecoveryWorkspace
    {
        const string WorkspaceName = "SolarNet Recovery Workspace";
        const string RootName = "Recovered inspection objects — not gameplay";
        const string RuntimeName = "Player Runtime — inactive, recovery incomplete";
        const string ValidationName = "Full-body validation geometry — not equipped avatar";
        const string SceneKey = "SolarNet.RecoveryWorkspace.V2.Scene";
        const string RootKey = "SolarNet.RecoveryWorkspace.V2.Root";
        const string RuntimePrefab = "Assets/Resources/_Player_.prefab";
        const string RuntimeGuid = "0f7246a5426701440a78489a68cba6ff";
        const string ValidationPrefab = "Assets/Resources/(PlayerValidationFullBodyDummy).prefab";
        const string BodyGuid = "0529b20d821066147b5bb8e36c716d54";
        const string NoseGuid = "d52288ca6829d1b4db3c2465fa23bf2c";
        static readonly string[] OriginalScenes = {
            "Assets/Core/Scenes/main_root.unity",
            "Assets/Core/Scenes/late_main_root.unity",
            "Assets/Activities/TitleScreen/Scenes/TitleScreen.unity",
            "Assets/Activities/Dormroom/Scenes/dormroom2.unity"
        };
        static double nextPoll;

        [Serializable] sealed class MeshCensus
        {
            public int game_objects, mesh_filters, null_mesh_filters, skinned_renderers, null_skinned_meshes;
        }
        [Serializable] sealed class SceneObservation
        {
            public string path, observation_error;
            public bool loaded_before, loaded_after, dirty_before, dirty_after;
            public int roots_before, roots_after;
            public int[] root_instance_ids_before, root_instance_ids_after;
            public bool root_set_comparison_available, root_instance_set_unchanged;
        }
        [Serializable] sealed class Inventory
        {
            public string status, error, active_before, active_after;
            public string[] original_scene_paths, opened_this_call, loaded_scene_paths;
            public int workspace_handle, validation_transform_count, validation_mesh_count;
            public string runtime_prefab_path, runtime_prefab_guid, runtime_instance_prefab_path;
            public MeshCensus runtime_source, runtime_instance;
            public SceneObservation[] original_scene_observations;
            public bool prefab_link_verified, inactive_parent_before_instantiation, runtime_active_in_hierarchy;
            public bool source_mesh_nulls_preserved, runtime_component_source_links_verified, source_mesh_references_preserved;
            public bool original_scenes_saved_by_helper = false;
            public bool helper_does_not_reparent_original_roots = true;
            public bool gameplay_started = false, avatar_playable_claimed = false;
            public string validation_geometry = "Separate original full-body LOD0 and nose; static bind pose, not an equipped classic avatar.";
            public string callback_boundary = "Original scenes use normal Editor load lifecycle. The actual _Player_ prefab is instantiated under an already inactive parent. Normal active-hierarchy Awake/OnEnable are not requested, but OnValidate/editor callbacks are not suppressed.";
            public string observation_boundary = "Root IDs/counts and dirty flags are observed at helper entry/completion only. Newly loaded scenes have no prior in-memory baseline; callbacks can change state after this observation.";
        }

        [InitializeOnLoadMethod]
        static void RegisterRequestOnly()
        {
            EditorApplication.update -= PollRequest;
            EditorApplication.update += PollRequest;
        }
        [MenuItem("Window/Recovery/Open Recovered Workspace")]
        public static void Open()
        {
            Scene before = SceneManager.GetActiveScene();
            var report = new Inventory { status = "starting", error = "", active_before = before.path, original_scene_paths = OriginalScenes };
            var opened = new List<string>();
            var observations = new List<SceneObservation>();
            Scene dorm = default(Scene);
            bool completed = false;
            try
            {
                if (EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isCompiling || EditorApplication.isUpdating)
                    throw new InvalidOperationException("Editor must be idle in Edit Mode to open the recovery workspace.");
                foreach (string path in OriginalScenes)
                {
                    Scene scene = SceneManager.GetSceneByPath(path);
                    var observation = new SceneObservation { path = path, loaded_before = scene.IsValid() && scene.isLoaded };
                    if (observation.loaded_before)
                    {
                        observation.root_instance_ids_before = RootIds(scene);
                        observation.roots_before = observation.root_instance_ids_before.Length;
                        observation.dirty_before = scene.isDirty;
                    }
                    observations.Add(observation);
                }
                // All source paths are fixed. Validate existence and bounded
                // source sizes before adding scenes or creating any objects.
                foreach (string path in OriginalScenes)
                {
                    RequireAssetFile(path, 16L * 1024 * 1024);
                    if (AssetDatabase.LoadAssetAtPath<SceneAsset>(path) == null)
                        throw new InvalidOperationException("Original scene asset not found: " + path);
                }
                RequireAssetFile(RuntimePrefab, 2L * 1024 * 1024);
                RequireAssetFile(ValidationPrefab, 512L * 1024);
                var originalPlayer = AssetDatabase.LoadAssetAtPath<GameObject>(RuntimePrefab);
                if (originalPlayer == null || AssetDatabase.AssetPathToGUID(RuntimePrefab) != RuntimeGuid)
                    throw new InvalidOperationException("Original _Player_ prefab identity did not match the verified source.");
                report.runtime_source = Census(originalPlayer);
                if (report.runtime_source.game_objects != 424)
                    throw new InvalidOperationException("Original _Player_ must retain the verified 424-object hierarchy.");
                report.runtime_prefab_path = RuntimePrefab;
                report.runtime_prefab_guid = RuntimeGuid;
                var validationSource = AssetDatabase.LoadAssetAtPath<GameObject>(ValidationPrefab);
                if (validationSource == null) throw new InvalidOperationException("Verified full-body validation prefab is missing.");

                foreach (string path in OriginalScenes)
                {
                    Scene scene = SceneManager.GetSceneByPath(path);
                    if (!scene.IsValid() || !scene.isLoaded)
                    {
                        scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Additive);
                        opened.Add(path);
                    }
                    if (path == OriginalScenes[3]) dorm = scene;
                }
                Scene workspace = FindOwnedWorkspace();
                GameObject root;
                if (workspace.IsValid())
                {
                    root = EditorUtility.InstanceIDToObject(SessionState.GetInt(RootKey, 0)) as GameObject;
                    if (root == null || root.scene.handle != workspace.handle || root.name != RootName)
                        throw new InvalidOperationException("The existing inspection workspace was edited; preserving it without replacement.");
                    Transform parent = root.transform.Find(RuntimeName);
                    if (parent == null || parent.childCount != 1)
                        throw new InvalidOperationException("Inactive original player branch changed; preserving existing objects.");
                    ValidateRuntimeInstance(parent.GetChild(0).gameObject, parent.gameObject, originalPlayer, workspace, report);
                    Transform validation = root.transform.Find(ValidationName);
                    if (validation == null) throw new InvalidOperationException("Separate validation branch is incomplete; preserving it without replacement.");
                    report.validation_transform_count = validation.GetComponentsInChildren<Transform>(true).Length - 1;
                    report.validation_mesh_count = validation.GetComponentsInChildren<MeshFilter>(true).Length;
                    if (report.validation_mesh_count != 2) throw new InvalidOperationException("Separate validation mesh branch changed; preserving it.");
                }
                else
                {
                    // Never close, replace or save the user's existing scenes.
                    workspace = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                    workspace.name = WorkspaceName;
                    Undo.IncrementCurrentGroup();
                    int group = Undo.GetCurrentGroup();
                    Undo.SetCurrentGroupName("Create recovered workspace inspection branches");
                    try
                    {
                        root = NewObject(RootName, null, workspace);
                        root.tag = "EditorOnly";
                        SessionState.SetInt(SceneKey, workspace.handle);
                        SessionState.SetInt(RootKey, root.GetInstanceID());

                        GameObject runtimeParent = NewObject(RuntimeName, root.transform, workspace);
                        runtimeParent.SetActive(false); // MUST precede prefab instantiation.
                        if (runtimeParent.activeSelf || runtimeParent.activeInHierarchy)
                            throw new InvalidOperationException("Runtime parent was not inactive before instantiation.");
                        report.inactive_parent_before_instantiation = true;
                        var instance = PrefabUtility.InstantiatePrefab(originalPlayer, runtimeParent.transform) as GameObject;
                        if (instance == null) throw new InvalidOperationException("Original _Player_ prefab instantiation returned null.");
                        Undo.RegisterCreatedObjectUndo(instance, "Add inactive original player hierarchy");
                        ValidateRuntimeInstance(instance, runtimeParent, originalPlayer, workspace, report);

                        var validation = NewObject(ValidationName, root.transform, workspace);
                        int count = 0, meshes = 0;
                        CloneValidationHierarchy(validationSource.transform, validation.transform, workspace, 0, ref count, ref meshes);
                        if (meshes != 2) throw new InvalidOperationException("Expected exactly the verified original LOD0 body and nose meshes.");
                        report.validation_transform_count = count;
                        report.validation_mesh_count = meshes;
                    }
                    finally { Undo.CollapseUndoOperations(group); }
                }
                report.workspace_handle = workspace.handle;
                Selection.activeGameObject = root;
                EditorGUIUtility.PingObject(root);
                completed = true;
                report.status = "original_scenes_loaded_inactive_original_player_hierarchy_and_separate_validation_geometry_ready";
            }
            catch (Exception exception)
            {
                report.status = "failed_preserve_all_open_scenes_and_partial_inspection_objects";
                report.error = exception.GetType().Name + ": " + exception.Message;
            }
            finally
            {
                // Dorm is the explicitly requested final inspection target.
                // A failure restores the previous active scene without closing.
                if (completed && dorm.IsValid() && dorm.isLoaded) SceneManager.SetActiveScene(dorm);
                else if (before.IsValid() && before.isLoaded) SceneManager.SetActiveScene(before);
                report.active_after = SceneManager.GetActiveScene().path;
                report.opened_this_call = opened.ToArray();
                var loaded = new List<string>();
                for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    Scene scene = SceneManager.GetSceneAt(i);
                    loaded.Add(string.IsNullOrEmpty(scene.path) ? "[untitled] " + scene.name : scene.path);
                }
                report.loaded_scene_paths = loaded.ToArray();
                foreach (var observation in observations)
                {
                    try
                    {
                        Scene scene = SceneManager.GetSceneByPath(observation.path);
                        observation.loaded_after = scene.IsValid() && scene.isLoaded;
                        if (observation.loaded_after)
                        {
                            observation.root_instance_ids_after = RootIds(scene);
                            observation.roots_after = observation.root_instance_ids_after.Length;
                            observation.dirty_after = scene.isDirty;
                        }
                        observation.root_set_comparison_available = observation.loaded_before && observation.loaded_after;
                        observation.root_instance_set_unchanged = observation.root_set_comparison_available &&
                            new HashSet<int>(observation.root_instance_ids_before).SetEquals(observation.root_instance_ids_after);
                    }
                    catch (Exception exception) { observation.observation_error = exception.Message; }
                }
                report.original_scene_observations = observations.ToArray();
                try { File.WriteAllText(TempFile("SolarNetRecoveryWorkspace.status.json"), JsonUtility.ToJson(report, true)); }
                catch { }
                EditorApplication.RepaintHierarchyWindow();
            }
            if (completed) EditorApplication.ExecuteMenuItem("Window/Recovery/Recovered Geometry");
        }

        static int[] RootIds(Scene scene)
        {
            GameObject[] roots = scene.GetRootGameObjects();
            if (roots.Length > 2048) throw new InvalidOperationException("Original scene root census exceeds the bounded 2048-root report scope.");
            var ids = new int[roots.Length];
            for (int i = 0; i < roots.Length; i++) ids[i] = roots[i].GetInstanceID();
            return ids;
        }

        static MeshCensus Census(GameObject root)
        {
            var result = new MeshCensus();
            result.game_objects = root.GetComponentsInChildren<Transform>(true).Length;
            if (result.game_objects > 1024) throw new InvalidOperationException("Player hierarchy exceeds the bounded 1024-object inspection limit.");
            foreach (var filter in root.GetComponentsInChildren<MeshFilter>(true))
            { result.mesh_filters++; if (filter.sharedMesh == null) result.null_mesh_filters++; }
            foreach (var renderer in root.GetComponentsInChildren<SkinnedMeshRenderer>(true))
            { result.skinned_renderers++; if (renderer.sharedMesh == null) result.null_skinned_meshes++; }
            return result;
        }
        static void ValidateRuntimeInstance(GameObject instance, GameObject parent, GameObject source, Scene scene, Inventory report)
        {
            if (parent.activeSelf || parent.activeInHierarchy || instance.activeInHierarchy ||
                instance.transform.parent != parent.transform || instance.scene.handle != scene.handle)
                throw new InvalidOperationException("Original player must remain under the inactive parent in the owned untitled scene.");
            report.runtime_active_in_hierarchy = instance.activeInHierarchy;
            report.runtime_instance_prefab_path = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(instance);
            report.prefab_link_verified = report.runtime_instance_prefab_path == RuntimePrefab &&
                PrefabUtility.GetCorrespondingObjectFromSource(instance) == source;
            if (!report.prefab_link_verified) throw new InvalidOperationException("Original player prefab connection was not preserved.");
            report.runtime_instance = Census(instance);
            MeshCensus a = report.runtime_source, b = report.runtime_instance;
            report.source_mesh_nulls_preserved = a.game_objects == b.game_objects && b.game_objects == 424 &&
                a.mesh_filters == b.mesh_filters && a.null_mesh_filters == b.null_mesh_filters &&
                a.skinned_renderers == b.skinned_renderers && a.null_skinned_meshes == b.null_skinned_meshes;
            bool links = true, references = true;
            foreach (var filter in instance.GetComponentsInChildren<MeshFilter>(true))
            {
                var original = PrefabUtility.GetCorrespondingObjectFromSource(filter);
                if (original == null || !original.transform.IsChildOf(source.transform)) { links = false; references = false; continue; }
                if (original.sharedMesh != filter.sharedMesh) references = false;
            }
            foreach (var renderer in instance.GetComponentsInChildren<SkinnedMeshRenderer>(true))
            {
                var original = PrefabUtility.GetCorrespondingObjectFromSource(renderer);
                if (original == null || !original.transform.IsChildOf(source.transform)) { links = false; references = false; continue; }
                if (original.sharedMesh != renderer.sharedMesh) references = false;
            }
            report.runtime_component_source_links_verified = links;
            report.source_mesh_references_preserved = references;
            report.source_mesh_nulls_preserved = report.source_mesh_nulls_preserved && links && references;
            if (!report.source_mesh_nulls_preserved)
                throw new InvalidOperationException("Original player hierarchy or runtime-assigned null mesh census changed; no replacement meshes are supplied.");
        }
        static Scene FindOwnedWorkspace()
        {
            int handle = SessionState.GetInt(SceneKey, 0);
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.handle == handle && scene.isLoaded)
                {
                    if (!string.IsNullOrEmpty(scene.path) || scene.name != WorkspaceName)
                        throw new InvalidOperationException("The session workspace changed identity; preserving it.");
                    return scene;
                }
            }
            return default(Scene);
        }
        static GameObject NewObject(string name, Transform parent, Scene scene)
        {
            var created = new GameObject(name);
            SceneManager.MoveGameObjectToScene(created, scene);
            Undo.RegisterCreatedObjectUndo(created, "Create recovered inspection object");
            if (parent != null) created.transform.SetParent(parent, false);
            return created;
        }
        static void CloneValidationHierarchy(Transform original, Transform parent, Scene scene, int depth, ref int count, ref int meshes)
        {
            if (depth > 64 || ++count > 512) throw new InvalidOperationException("Validation hierarchy exceeds the bounded inspection scope.");
            var created = NewObject(original.name, parent, scene);
            created.transform.localPosition = original.localPosition;
            created.transform.localRotation = original.localRotation;
            created.transform.localScale = original.localScale;
            var source = original.GetComponent<SkinnedMeshRenderer>();
            if (source != null && source.sharedMesh != null)
            {
                string guid; long id;
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(source.sharedMesh, out guid, out id) && (guid == BodyGuid || guid == NoseGuid))
                {
                    Undo.AddComponent<MeshFilter>(created).sharedMesh = source.sharedMesh;
                    Undo.AddComponent<MeshRenderer>(created).sharedMaterials = source.sharedMaterials;
                    meshes++;
                }
            }
            // Static validation copy contains only native transforms and the
            // two verified mesh references, no MonoBehaviours or skinning.
            for (int i = 0; i < original.childCount; i++)
                CloneValidationHierarchy(original.GetChild(i), created.transform, scene, depth + 1, ref count, ref meshes);
        }
        static void RequireAssetFile(string path, long maximumBytes)
        {
            string assets = Path.GetFullPath(Application.dataPath) + Path.DirectorySeparatorChar;
            string project = Directory.GetParent(Application.dataPath).FullName;
            string absolute = Path.GetFullPath(Path.Combine(project, path));
            if (!path.StartsWith("Assets/", StringComparison.Ordinal) || !absolute.StartsWith(assets, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Fixed recovery source must stay within this project's Assets folder.");
            var file = new FileInfo(absolute);
            if (!file.Exists || file.Length <= 0 || file.Length > maximumBytes || (file.Attributes & FileAttributes.ReparsePoint) != 0)
                throw new InvalidOperationException("Recovery source missing, unbounded or redirected: " + path);
        }
        static string TempFile(string name)
        {
            string folder = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Temp");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, name);
        }
        static void PollRequest()
        {
            if (EditorApplication.timeSinceStartup < nextPoll || EditorApplication.isCompiling || EditorApplication.isUpdating || EditorApplication.isPlayingOrWillChangePlaymode) return;
            nextPoll = EditorApplication.timeSinceStartup + 0.5;
            try
            {
                string path = TempFile("SolarNetRecoveryWorkspace.request");
                if (!File.Exists(path) || new FileInfo(path).Length > 16) return;
                string command = File.ReadAllText(path).Trim();
                File.Delete(path);
                if (command == "open") Open();
                else if (command == "scene") RecoveredSceneView.OpenInspection();
            }
            catch { }
        }
    }
}
#endif
