// Trusted test harness only. Calls genuine official SDK and Unity Engine APIs.
// It contains no recovered client/game method and never enters Play mode.
using System;
using System.IO;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

public static class SDKTextureLoadFixture
{
    [Serializable] sealed class Spec {
        public string bundle_path, bundle_sha256, internal_asset_path, expected_name, asset_bundle_name;
        public string addressables_sha256, resource_manager_sha256;
        public int expected_width, expected_height;
    }
    [Serializable] sealed class Result {
        public string status, error, name, asset_path, bundle_sha256, addressables_sha256, resource_manager_sha256;
        public int width, height;
        public bool genuine_sdk_methods_invoked, original_client_or_game_methods_invoked, PlayMode, scene_or_prefab_loaded;
    }
    static string Sha(string path) { using(var s=File.OpenRead(path))using(var h=SHA256.Create())return BitConverter.ToString(h.ComputeHash(s)).Replace("-","").ToLowerInvariant(); }
    static void Need(bool condition,string message) { if(!condition)throw new InvalidDataException(message); }
    public static void Run()
    {
        string root=Directory.GetParent(Application.dataPath).FullName;
        string output=Path.Combine(root,"FixtureInputs/result.json");
        var result=new Result {status="failed",original_client_or_game_methods_invoked=false,PlayMode=false,scene_or_prefab_loaded=false};
        ResourceManager manager=null;AsyncOperationHandle<Texture2D> handle=default(AsyncOperationHandle<Texture2D>);int exit=1;
        try {
            Need(Application.isEditor&&!EditorApplication.isPlaying&&!EditorApplication.isPlayingOrWillChangePlaymode,"Compile-only Editor context required.");
            Need(!File.Exists(output),"Fresh fixture result required.");
            var spec=JsonUtility.FromJson<Spec>(File.ReadAllText(Path.Combine(root,"FixtureInputs/spec.json")));
            string bundle=Path.GetFullPath(Path.Combine(root,spec.bundle_path));
            Need(bundle==Path.GetFullPath(Path.Combine(root,"FixtureInputs/OriginalTexture.bundle")),"Exact local fixture bundle required.");
            Need(Sha(bundle)==spec.bundle_sha256,"Original texture bundle bytes changed.");
            Need(spec.expected_width>=16&&spec.expected_width<=256&&spec.expected_height>=16&&spec.expected_height<=256,"Expected texture bounds.");
            string addr=typeof(Addressables).Assembly.Location,rm=typeof(ResourceManager).Assembly.Location;
            Need(Sha(addr)==spec.addressables_sha256&&Sha(rm)==spec.resource_manager_sha256,"Genuine SDK proposal bytes changed.");
            foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                string name=assembly.GetName().Name;
                Need(!name.StartsWith("RecRoom",StringComparison.Ordinal)&&name!="Assembly-CSharp"&&!name.StartsWith("Photon",StringComparison.Ordinal),"Original game/runtime assembly unexpectedly loaded: "+name);
            }
            // This official Addressables entry point creates its genuine manager;
            // InitializeAsync/catalog/scene loading is deliberately never requested.
            manager=Addressables.ResourceManager;
            manager.ResourceProviders.Add(new AssetBundleProvider());
            manager.ResourceProviders.Add(new BundledAssetProvider());
            var bundleLocation=new ResourceLocationBase("original-texture-bundle",bundle,typeof(AssetBundleProvider).FullName,typeof(IAssetBundleResource));
            bundleLocation.Data=new AssetBundleRequestOptions {BundleName=spec.asset_bundle_name,BundleSize=new FileInfo(bundle).Length,Crc=0,RetryCount=0,UseUnityWebRequestForLocalBundles=false};
            var assetLocation=new ResourceLocationBase("original-texture",spec.internal_asset_path,typeof(BundledAssetProvider).FullName,typeof(Texture2D),bundleLocation);
            result.genuine_sdk_methods_invoked=true;
            handle=manager.ProvideResource<Texture2D>(assetLocation);
            Texture2D texture=handle.WaitForCompletion();
            Need(handle.Status==AsyncOperationStatus.Succeeded&&texture!=null,"Genuine SDK texture load failed: "+handle.OperationException);
            Need(texture.name==spec.expected_name&&texture.width==spec.expected_width&&texture.height==spec.expected_height,"Loaded texture identity/dimensions differ from original type-tree proof.");
            result.name=texture.name;result.width=texture.width;result.height=texture.height;result.asset_path=spec.internal_asset_path;
            result.bundle_sha256=Sha(bundle);result.addressables_sha256=Sha(addr);result.resource_manager_sha256=Sha(rm);
            result.status="passed";exit=0;Debug.Log("GENUINE_SDK_ORIGINAL_TEXTURE_LOAD_OK "+texture.name+" "+texture.width+"x"+texture.height);
        } catch(Exception error) { result.error=error.ToString();Debug.LogException(error); }
        finally {
            try { if(handle.IsValid()&&manager!=null)manager.Release(handle);if(manager!=null)manager.Dispose(); }
            catch(Exception cleanup) { result.status="failed";result.error=(result.error??"")+" cleanup: "+cleanup;exit=1; }
            File.WriteAllText(output,JsonUtility.ToJson(result,true));EditorApplication.Exit(exit);
        }
    }
}
