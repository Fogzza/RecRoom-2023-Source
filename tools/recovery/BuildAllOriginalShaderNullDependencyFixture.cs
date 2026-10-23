using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

// Recovery-only all179 import/build witness. No original game code is imported or run.
public static class BuildAllOriginalShaderNullDependencyFixture
{
    static readonly HashSet<string> ExpectedGuids = new HashSet<string>(StringComparer.Ordinal) {
        "b973edd63da683b4b91bc07a750eb14d",
        "730504b1bc9a6df46a61341f43eec0a3",
        "277e771a3edd140408f4b73794ec52d2",
        "5c9904f50bc32f145a937b83eb44a15c",
        "f697d7319df4be446970bba95ef50fd0",
        "9191c42a7729b4a4fb90e0b39de2fc81",
        "b5af695988fbbde4f892a19169d1f458",
        "79273e3c538a6f34f8ce8505bcda8638",
        "3ad4eb60260d5c842861ef2343d8a32f",
        "249cb435a09f39e4e8f6de7901b294b4",
        "ec4be7aa4044d3d469f8321ab3a7f758",
        "b5b5fadc9ee51bb48ba1195fadb5ed8f",
        "19e25a465b71c5d428af70fd5cf2ca14",
        "dad38ef62dfa5f549b2fba9e3d593aa2",
        "19867c76364cecc45a6146e869da41cb",
        "b3052168388b7a1459dfcfb8ef798a66",
        "9b24e3e87feabdf49aec716626a7ad3a",
        "77d51732ae3ee9c43ab8deff95a2a322",
        "a72b837be3fe0184b8870bd20ae29de9",
        "afa1693c92ff6fe4b9fd4d1447d3b9be",
        "9cd410d648b9e4a459343630a7c52de0",
        "ebb1e58eff6f87a408604d71a1ffaf6a",
        "16761fb91cf7acb47a28381e0d6ce72a",
        "2026962f1fc7dc54ab55b66bb800459d",
        "0493b09df1a3ee64ca080c5033aae76d",
        "7ca999f272674364b9a04c4cbc64b423",
        "cb825a5d469738d4d92aba1cf9cb32c1",
        "65fbb46ed9e9933419b9e965081c3cab",
        "d788e1d564944da40b89e1198f45c92e",
        "224f2d70c6a412247bced84b1575b9fb",
        "fb95a66fdcea33d48895883c8bbbdf47",
        "1876cba549c53ab498af524df61ddef4",
        "cd09b113a8e0b7e4c95a8ff65519bfee",
        "2df9f0b1a1982224a986f11c4cdaf2b2",
        "135f1c52a66e84d4f988f38084e92ff0",
        "516cc469c39d2c94eb6e2b697314645f",
        "0d67a56ad56316240ae28f11362b7489",
        "e81f2306a7de741479574aeadd4ee7f4",
        "ba16984f4f6133c49bae64f443741ae1",
        "135c6b7da3be52b4d92cf054cff624fd",
        "47260f0f02e34824b96fafeda257fa6c",
        "6f1e75c027ed63349b3ae0537dc3578b",
        "0f1faeb616952c444abb65a3d88066e2",
        "f2d1f41212603214e8ac5fabe1f3a3c8",
        "89d695ef33369a443a94d226a7d09da0",
        "db868ae357bf4634c985d2303bcc64cc",
        "53186f72a6a19ff419c387829335536c",
        "988a943d64eaf3d4985396b2fe8febf6",
        "5a0e5df236460a341a732a2275e1df34",
        "89cf1678d0214d34daf9a71e0939ea02",
        "7e9c4c9f716ff7f40989db66d2a56b1a",
        "3f8e231b8b9b14d4c8b6ef52d95043ab",
        "411f92d189ccd3043a7db1f40e1d7d33",
        "09cdffcd5479aa844b6a7bd9ce7ffb4f",
        "b7bfe91d82c093643ad59dbb066ac60d",
        "c30cfae8604786741960b08a3d2572c1",
        "124a1471e026aae4a9a95f3d7fea5300",
        "7397c6595a675cf4bab8db804c366a91",
        "90510347b31afb84fba058c6708c7f5c",
        "9b3c0ec5fac79b74dac00c3039b98c39",
        "23bcc9f21723cf242b095746b7d24ed5",
        "83f7db1b83de4d64698459f892c57e15",
        "7a5d770f05aa40d4d91f9268c363a4f8",
        "3592ff528bc55ff458047aa7cbc92600",
        "17fc203b91027d64cb42f8c3ded11d2f",
        "f5c2620c3e324934ba77cf29f0f1acfd",
        "2d76e068cd9b856459d0949f6f780791",
        "21bba9003659b084daf547207f9735d7",
        "f57b28c437615af4e9d73365e8b030a9",
        "87f6fc6e8b660b74c80cdf7b5dffd988",
        "6082b662098f7834fb9415142769e246",
        "53ec6449054fa3f43acb4e438a0cbdfe",
        "745bd023259bc014a864565651e106dd",
        "64766c0156b281845ad3165b8b4ff733",
        "94fdcb80d5a3e4f448450952c7774f85",
        "a4e49918bea0c5345a0572b9c8ae4ac6",
        "252ccb870b7194a409beed53180246af",
        "3c9225f14dd506c44bb0ee79b6f9ad4a",
        "b49c7e8e35b648244beb5c6005bd9520",
        "0b08c5f2323628846ab9907c4020a470",
        "e8290940fc4bb594ebe548753bb0a39b",
        "1245eccaa18a22b43a4f4c33f15af7ce",
        "9cdfbf5380c0f7e479c01e66cbade031",
        "d13aea5001fa6c54bb082b88af903c58",
        "dcd6de74b65d54641a5eeddbe1b7a05c",
        "0e37ba201cb215340b6fe5bafaeaf042",
        "2efba00811b7c1847ad3163efbd6b7f0",
        "bc26781a01439594d927187c181e6fe6",
        "8b83fe2723a22494b8b8d0ae63c2e06d",
        "ecc3db6c886d8ff47833e605893d2894",
        "63b2b4e66888f2645b62be138eae40e7",
        "a2017e1aed6dd13458068589f04a88bd",
        "218d78ff502feed4ca1d6cd806a3dfda",
        "4d041ee27d674854e91fb259a80b9ea1",
        "5eb2c211ef1def9489be6fd887405a96",
        "623deed7966c2ec4f80edad542ead410",
        "924c02d9275402549bda94ade8f3d71f",
        "cc3d067a3685271409a53b56239de994",
        "eb5e5a7835e7d7648adea005270fb6b6",
        "79507d98463dde94d8135d720fc7619b",
        "a33c5f6ae2c9e264985f274fedb24f91",
        "d214f3d592be94c4f8b8ce65295625c7",
        "159444bcf9e027b4d820056a1c88a19a",
        "7e3876d06d238ef40b58295bd5af4cec",
        "d2a5536c48f6e914f900eb13ea2f4d68",
        "5c476605d6fb8644bae823766e8c6901",
        "9d1e416958afaa34ead6bc7d2b6e4c09",
        "04c2e6aa5e6b9d144aab68b2717cb23e",
        "597b5ba5efd704a4386a338ce2d53edd",
        "012f2ad68013d334297da3e667cb909e",
        "30aef2fd3688bd34381c4930896c368c",
        "24defdf58f2d9374d95907ad4742defa",
        "004ea6f637cfe3e409bb48bbb45a115e",
        "f83a8c8aa21a39844bbe08c6a1b9f624",
        "e165d9f5aa841634a96892dbde699572",
        "4347cb758a6a3bb4a9ac412db70353ba",
        "596a5b3503116684484de067c9b717f5",
        "ef44147fa3b297c4b934c03f57435002",
        "f7efab54069bc444295f491f1ddf5b51",
        "e8b204ae22658f64a88cf88172cef9c7",
        "7eda6ccbad6ba14488e843023e0d8dfa",
        "2fd171dcf66b71e46aa3d383fa609f1f",
        "4a4d390e5414ccd4f8f9cca26f506018",
        "7685b3afc9cc09f42a864cb1c4779eaf",
        "d1f81ebc0e863c54f8c74746c13b7907",
        "6f8ba89a06437ba4ba3bfb5ec21a057c",
        "6fce6254d9fbefb4f9af062f836468ac",
        "c57624cc8ad7605489ea1de256a27ebd",
        "7e44c40450954a049b1ad1136774de50",
        "2d1e03db94938324f9fcaa82e1da4e4d",
        "21399184bfa6d38488c1c7aebacd539c",
        "b747d1c141f78424da5b8d43c97f2e12",
        "21bea9ff7bed5a647afaf7b4d30821b8",
        "302799edf75ded3439e61f2c5c76ec62",
        "c74f0b279d001c844a18479f9f03def4",
        "dbe0ca40b3618e44e9ef2664c6daae98",
        "0301ab1a529a0d943ba3251b35f65a48",
        "405cbb3bfd8493d429d4ed0cc6d7bfd3",
        "0f76e30547e5fb543834aa5f1c7fad9f",
        "3e5d05c27d8ba0a4c8d72d1fb41f7c14",
        "6bf3dcb46214915478c5fd5f04a8f11c",
        "69f9375fe18d829468b7a2f951c4eea5",
        "d9b1def389ba0a349916598852e2927a",
        "900324e1be995b047a280e927addf826",
        "678f65130ce41654dbb14f647c34e55b",
        "b7c705cb31e0b754597a0dabfa912612",
        "b59aa413068a4684db61d02c7a4e59c4",
        "154e49bca8a2a3b4897bcb5eaed3bdc2",
        "7594191f2a3044547a29edfb06b92011",
        "5b6fbf19f41fddd429a6f20f75749c67",
        "30434612dfb183f488499483c2721d52",
        "4b5d52c8a17c20c488ecc3fe0b3261c8",
        "bdd7fd325ea93a248be519e07d037b8f",
        "e67c5327a5e62cb468eeca8f87e088b8",
        "0fb44d6024c4b6042a272ad15d518dbc",
        "88a1fc3b1126e3c43a218496ec389cc8",
        "abeb63fdd051a4f449ad8129d2aa2728",
        "0f6851e2cde621a43a2923da3d30dfa8",
        "50a3c77d6e3ec854e9ba190edf8aed58",
        "4b1bb7e0c39453c4d8c3b53b7db9f1db",
        "08e70499cf6154e48a69d66a90ceb27c",
        "9d0fb09ffb3bf004ea7cd1f77ca07b27",
        "5c20c3ec531e1e24991b707fd39fa5b5",
        "bb2800d742e6f1845b95e91b6f897e3b",
        "2e7d54683b993ee45b5cc0a8583933a3",
        "a58633e1c9e66eb448ed51afa0bb8219",
        "f9406ec020c3e9c43b7aa15acd631b9d",
        "ea314794d9ec0ef419b8d5dc70f03097",
        "4a2db69e9a45b1843b366b21b2944bb4",
        "1ab811d499b5a8e48bfee808ef436fab",
        "ae89365cfd4e58645972d555b2061345",
        "c40c5d6c5c12ec649869949f8d5aba64",
        "eab8888f0d7bbc9439e369b13d5c49ba",
        "fc4f4d351a10096469f45df6e36d7daa",
        "524f6c8cabe1405498d1cfed91fdb556",
        "7ce2d45ea68e67849970ac6a613a8fa9",
        "3ad47b04ddcff8d479539e927e3b3c9c",
        "f4d82654d6455a64a91844e18d47d09c",
        "26b787feed4274148b666ca12bf09f34",
    };
    [Serializable] public class Dependency { public string kind, guid; public long local_file_id; }
    [Serializable] public class Input
    {
        public string path, sha256, meta_sha256, guid, name;
        public Dependency[] dependencies;
    }
    [Serializable] public class Config { public string project, graphics_sha256; public Input[] shaders; public bool Editor_dependency_projection; public BuiltinMaterialWitness[] copied_materials; }
    [Serializable] public class Seen { public string guid, local_id, path, name; }
    [Serializable] public class Witness { public string stage, guid; public Seen[] shaders; }
    [Serializable] public class BuiltinMaterialWitness
    {
        public string builtin_guid, builtin_local_id, builtin_name, material_guid, material_local_id, material_source_path, asset_sha256, meta_sha256;
        public bool shader_instance_equal_after_native_import;
    }
    [Serializable] public class MaterialRecord
    {
        public string file_id, short_path, id, offset, packed_size, source_guid, source_path, type;
    }
    [Serializable] public class PackedMaterials
    {
        public string schema = "Unity2020-actual-packed-Material-API-records/v1";
        public ShaderPackedBuildReportCapture.FileRecord[] files;
        public MaterialRecord[] materials;
    }
    [Serializable] public class Result
    {
        public string schema = "all179-original-Shader-Editor-projection-four-builtin-Material-build/v1", status = "starting", exception;
        public string unity_version, serialization_mode, target, backend, output_path;
        public int shader_count, total_errors, total_warnings, partial_constant_buffer_messages;
        public bool input_assets_and_metas_unchanged, required_project_dependency_closure_verified, four_builtin_material_witnesses_verified;
        public bool Main_modified = false, original_game_code_executed = false, GPU_tested = false;
        public bool Editor_only_null_dependency_projection = true, original_dependencies_restored_in_player = false;
        public Witness[] witnesses;
        public ShaderPackedBuildReportCapture.Data packed_shader_build_report;
        public BuiltinMaterialWitness[] builtin_shader_material_witnesses;
        public PackedMaterials packed_material_build_report;
    }
    static readonly List<Witness> witnesses = new List<Witness>();
    static readonly Dictionary<long, Shader> builtinShaders = new Dictionary<long, Shader>();
    static Result result;
    static void Need(bool value, string message) { if (!value) throw new InvalidOperationException(message); }
    static string Arg(string name)
    {
        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i + 1 < args.Length; ++i) if (args[i] == name) return args[i + 1];
        throw new ArgumentException("Missing " + name);
    }
    static string Sha(string path)
    {
        using (var stream = File.OpenRead(path)) using (var hash = SHA256.Create())
            return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
    }
    static Shader Load(Input row)
    {
        Need(ExpectedGuids.Contains(row.guid) && row.path == "Assets/Resources/OriginalShaders/" + row.guid + ".asset", "Exact selected isolated resource path/GUID required");
        Need(Sha(row.path) == row.sha256 && Sha(row.path + ".meta") == row.meta_sha256, "Input changed: " + row.guid);
        Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(row.path);
        string guid; long local;
        Need(shader != null && shader.name == row.name && AssetDatabase.TryGetGUIDAndLocalFileIdentifier(shader, out guid, out local)
             && guid == row.guid && local == 4800000, "Shader identity changed: " + row.guid);
        return shader;
    }
    static string Key(string guid, long local) { return guid + ":" + local.ToString(System.Globalization.CultureInfo.InvariantCulture); }
    static void OutputInsideFixture(string path, string project)
    {
        string root = Path.GetFullPath(Path.Combine(project, ".."));
        Need(Path.GetFileName(root).StartsWith("AllOriginalShaderNullDependencyFixture-", StringComparison.Ordinal), "Named isolated fixture required");
        string full = Path.GetFullPath(path), prefix = root.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
        string sourcePrefix = Path.GetFullPath(project).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
        Need(full.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) && !full.StartsWith(sourcePrefix, StringComparison.OrdinalIgnoreCase), "Output must be inside owned fixture, outside source project");
    }
    static void Reach(string guid, Dictionary<string, Input> inputs, HashSet<string> visited, HashSet<string> required)
    {
        if (!visited.Add(guid)) return;
        Input row = inputs[guid];
        foreach (Dependency dep in row.dependencies)
        {
            required.Add(Key(dep.guid, dep.local_file_id));
            if (dep.kind == "project")
            {
                Need(dep.local_file_id == 4800000 && inputs.ContainsKey(dep.guid), "Unresolved project dependency");
                Reach(dep.guid, inputs, visited, required);
            }
            else Need(dep.kind == "builtin" && dep.guid == "0000000000000000f000000000000000", "Unknown dependency kind");
        }
    }
    static void Check(Config config, string stage)
    {
        var inputs = new Dictionary<string, Input>();
        foreach (Input row in config.shaders) { Need(row.dependencies != null && row.dependencies.Length == 0 && !inputs.ContainsKey(row.guid), "Every projected Editor Shader has an explicitly empty resolved dependency graph"); inputs.Add(row.guid, row); }
        var expected = new HashSet<string>(ExpectedGuids);
        Need(expected.SetEquals(inputs.Keys), "Exactly the canonical179 original Shader identities required");
        foreach (Input row in config.shaders)
        {
            Shader shader = Load(row);
            var required = new HashSet<string>();
            Reach(row.guid, inputs, new HashSet<string>(), required);
            var seen = new HashSet<string>(); var records = new List<Seen>();
            foreach (UnityEngine.Object value in EditorUtility.CollectDependencies(new UnityEngine.Object[] { shader }))
            {
                Shader dependency = value as Shader;
                if (dependency == null) continue;
                string guid; long local;
                Need(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(dependency, out guid, out local), "Actual Shader GUID/local identity unavailable");
                string key = Key(guid, local); seen.Add(key);
                records.Add(new Seen { guid = guid, local_id = local.ToString(System.Globalization.CultureInfo.InvariantCulture), path = AssetDatabase.GetAssetPath(dependency), name = dependency.name });
                if (inputs.ContainsKey(guid))
                    Need(local == 4800000 && (guid == row.guid || required.Contains(key)), "Unexpected project Shader dependency: " + guid);
                else
                {
                    Need(guid == "0000000000000000f000000000000000", "Unexpected external Shader GUID");
                    if (local == 6 || local == 7 || local == 46 || local == 10490)
                    {
                        Need(!builtinShaders.ContainsKey(local) || builtinShaders[local] == dependency, "Builtin identity resolved to different objects");
                        builtinShaders[local] = dependency;
                    }
                }
            }
            foreach (string key in required) Need(seen.Contains(key), "Missing explicit original Shader dependency: " + key);
            witnesses.Add(new Witness { stage = stage, guid = row.guid, shaders = records.ToArray() });
        }
        result.required_project_dependency_closure_verified = true;
    }
    static BuiltinMaterialWitness[] ReadCopiedBuiltinWitnesses(Config config)
    {
        Need(config.copied_materials != null && config.copied_materials.Length == 4, "Exactly four already-native copied Material inputs required");
        var ids = new HashSet<string>(); var guids = new HashSet<string>();
        foreach (BuiltinMaterialWitness row in config.copied_materials)
        {
            Need(row.builtin_guid == "0000000000000000f000000000000000" && ids.Add(row.builtin_local_id) && guids.Add(row.material_guid), "Exact unique builtin and copied Material identities");
            long expectedId = long.Parse(row.builtin_local_id, System.Globalization.CultureInfo.InvariantCulture);
            Need(row.material_source_path == "Assets/Resources/BuiltinIdentityWitnesses/Builtin-" + row.builtin_local_id + ".mat", "Exact copied native Material path");
            Need(Sha(row.material_source_path) == row.asset_sha256 && Sha(row.material_source_path + ".meta") == row.meta_sha256, "Copied native Material bytes/meta changed");
            Material material = AssetDatabase.LoadAssetAtPath<Material>(row.material_source_path);
            string guid; long local; string shaderGuid; long shaderLocal;
            Need(material != null && material.shader != null && AssetDatabase.TryGetGUIDAndLocalFileIdentifier(material, out guid, out local)
                 && guid == row.material_guid && local.ToString(System.Globalization.CultureInfo.InvariantCulture) == row.material_local_id, "Actual copied Material identity");
            Need(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(material.shader, out shaderGuid, out shaderLocal)
                 && shaderGuid == row.builtin_guid && shaderLocal == expectedId, "Actual copied Material.m_Shader must bind exact genuine builtin GUID/localID");
            Need(!builtinShaders.ContainsKey(expectedId) || builtinShaders[expectedId] == material.shader, "One actual builtin object per exact identity");
            builtinShaders[expectedId] = material.shader;
            row.shader_instance_equal_after_native_import = true;
        }
        Need(ids.SetEquals(new[] { "6", "7", "46", "10490" }), "Exact four proven builtin localIDs");
        return config.copied_materials;
    }
    static PackedMaterials CaptureMaterials(BuildReport report)
    {
        var files = new List<ShaderPackedBuildReportCapture.FileRecord>();
        foreach (BuildFile file in report.files) files.Add(new ShaderPackedBuildReportCapture.FileRecord {
            id = file.id.ToString(System.Globalization.CultureInfo.InvariantCulture), path = file.path });
        var rows = new List<MaterialRecord>();
        foreach (PackedAssets packed in report.packedAssets) foreach (PackedAssetInfo asset in packed.contents)
        {
            if (asset.type != typeof(Material)) continue;
            rows.Add(new MaterialRecord { file_id = packed.file.ToString(System.Globalization.CultureInfo.InvariantCulture), short_path = packed.shortPath,
                id = asset.id.ToString(System.Globalization.CultureInfo.InvariantCulture), offset = asset.offset.ToString(System.Globalization.CultureInfo.InvariantCulture),
                packed_size = asset.packedSize.ToString(System.Globalization.CultureInfo.InvariantCulture), source_guid = asset.sourceAssetGUID.ToString(), source_path = asset.sourceAssetPath, type = asset.type.FullName });
        }
        return new PackedMaterials { files = files.ToArray(), materials = rows.ToArray() };
    }
    static void VerifyBuiltinWitnesses()
    {
        Need(result.builtin_shader_material_witnesses != null && result.builtin_shader_material_witnesses.Length == 4, "Exactly four diagnostic Material witnesses required");
        var verifiedIds = new HashSet<string>(); var verifiedMaterials = new HashSet<string>();
        foreach (BuiltinMaterialWitness row in result.builtin_shader_material_witnesses)
        {
            Need(verifiedIds.Add(row.builtin_local_id) && verifiedMaterials.Add(row.material_guid), "Unique builtin and diagnostic Material identities required");
            Material material = AssetDatabase.LoadAssetAtPath<Material>(row.material_source_path); string guid; long local;
            Need(Sha(row.material_source_path) == row.asset_sha256 && Sha(row.material_source_path + ".meta") == row.meta_sha256
                 && material != null && material.shader == builtinShaders[long.Parse(row.builtin_local_id, System.Globalization.CultureInfo.InvariantCulture)], "Diagnostic Material input or reference changed during build");
            Need(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(material, out guid, out local) && guid == row.material_guid
                 && local.ToString(System.Globalization.CultureInfo.InvariantCulture) == row.material_local_id, "Diagnostic Material identity changed during build");
            int matches = 0;
            foreach (MaterialRecord packed in result.packed_material_build_report.materials)
                if (packed.source_guid == row.material_guid) {
                    Need(packed.source_path == row.material_source_path && packed.type == "UnityEngine.Material", "Actual packed diagnostic Material source identity changed");
                    matches++;
                }
            Need(matches == 1, "Exactly one actual packed record per diagnostic Material GUID required");
        }
        Need(verifiedIds.SetEquals(new[] { "6", "7", "46", "10490" }), "Exactly four proven Editor builtin localIDs required");
        result.four_builtin_material_witnesses_verified = true;
    }
    static void VerifyPackedProjectShaders(Config config)
    {
        Need(result.packed_shader_build_report != null && result.packed_shader_build_report.shaders != null, "Actual Shader API capture required");
        foreach (Input row in config.shaders) {
            int matches = 0;
            foreach (ShaderPackedBuildReportCapture.ShaderRecord packed in result.packed_shader_build_report.shaders)
                if (packed.source_guid == row.guid) {
                    Need(packed.source_path == row.path && packed.type == "UnityEngine.Shader", "Actual packed Shader source identity changed");
                    matches++;
                }
            Need(matches == 1, "Exactly one actual packed record per selected project Shader required");
        }
    }
    static void Log(string message, string trace, LogType kind)
    {
        if (message.Contains("Partial constant buffer not found.")) result.partial_constant_buffer_messages++;
    }
    public static void Run()
    {
        result = new Result { unity_version = Application.unityVersion };
        string reportPath = null; bool reportPathVerified = false; int exit = 1;
        Application.logMessageReceived += Log;
        try
        {
            reportPath = Path.GetFullPath(Arg("-shaderBuildReport"));
            Config config = JsonUtility.FromJson<Config>(File.ReadAllText(Arg("-shaderBuildConfig")));
            OutputInsideFixture(reportPath, config.project);
            Need(!File.Exists(reportPath), "Fresh report path required");
            reportPathVerified = true;
            Need(config.Editor_dependency_projection && config.shaders != null && config.shaders.Length == 179, "Exactly179 explicit Editor-only null-dependency projections required");
            result.shader_count = config.shaders.Length;
            Need(Application.unityVersion == "2020.3.33f1" && EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows64, "Matching Editor/target required");
            Need(!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode, "Play mode forbidden in fixture builder");
            Need(Path.GetFullPath(Path.Combine(Application.dataPath, "..")).TrimEnd(Path.DirectorySeparatorChar) == Path.GetFullPath(config.project).TrimEnd(Path.DirectorySeparatorChar), "Exact fixture path required");
            Need(EditorSettings.serializationMode == SerializationMode.Mixed && Sha("ProjectSettings/GraphicsSettings.asset") == config.graphics_sha256, "Initial Mixed and exact keep-list required");
            result.serialization_mode = EditorSettings.serializationMode.ToString();
            Check(config, "after-native-import");
            result.builtin_shader_material_witnesses = ReadCopiedBuiltinWitnesses(config);
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneWindows64, false);
            PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { GraphicsDeviceType.Direct3D11 });
            EditorUserBuildSettings.development = true;
            result.target = EditorUserBuildSettings.activeBuildTarget.ToString();
            result.backend = PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone).ToString();
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            Directory.CreateDirectory("Assets/Scenes");
            Need(EditorSceneManager.SaveScene(scene, "Assets/Scenes/AllOriginalShaderNullDependencyDiagnostic.unity"), "Cannot save diagnostic scene");
            result.output_path = Path.GetFullPath(Arg("-buildOutput"));
            OutputInsideFixture(result.output_path, config.project);
            Need(!File.Exists(result.output_path), "Fresh build output required");
            BuildReport built = BuildPipeline.BuildPlayer(new BuildPlayerOptions {
                scenes = new[] { "Assets/Scenes/AllOriginalShaderNullDependencyDiagnostic.unity" }, locationPathName = result.output_path,
                target = BuildTarget.StandaloneWindows64, targetGroup = BuildTargetGroup.Standalone, options = BuildOptions.Development | BuildOptions.StrictMode });
            Need(built != null, "Actual BuildReport required");
            result.packed_shader_build_report = ShaderPackedBuildReportCapture.Capture(built);
            result.packed_material_build_report = CaptureMaterials(built);
            result.status = built.summary.result.ToString(); result.total_errors = built.summary.totalErrors; result.total_warnings = built.summary.totalWarnings;
            Check(config, "after-player-build");
            VerifyPackedProjectShaders(config);
            VerifyBuiltinWitnesses();
            Need(Sha("ProjectSettings/GraphicsSettings.asset") == config.graphics_sha256, "Keep-list changed during build");
            result.input_assets_and_metas_unchanged = true;
            Need(built.summary.result == BuildResult.Succeeded && result.total_errors == 0 && result.partial_constant_buffer_messages == 0 && File.Exists(result.output_path), "Actual collection build failed");
            exit = 0;
        }
        catch (Exception error) { result.exception = error.ToString(); result.status = "failed_or_guard_refused"; Debug.LogException(error); }
        finally
        {
            Application.logMessageReceived -= Log; result.witnesses = witnesses.ToArray();
            try { if (reportPathVerified) File.WriteAllText(reportPath, JsonUtility.ToJson(result, true)); } catch { exit = 1; }
        }
        EditorApplication.Exit(exit);
    }
}
