"""Read-only build/runtime boundary evidence. No Unity or inspected code runs."""
from pathlib import Path
import collections,datetime as dt,hashlib,json,mmap,re,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';MAIN=WS/'RR23'
sys.path.insert(0,str(HERE.parent))
from metadata_projection_subset import array_rows
from audit_cli_marshal_contracts import Cli
from audit_boot_candidate_dependency_closure import module_methods

def sha(path):
    with Path(path).open('rb')as f:return hashlib.file_digest(f,'sha256').hexdigest()
def ref(path):return {'path':str(Path(path).resolve()),'sha256':sha(path)}
def need(value,message):
    if not value:raise ValueError(message)
def scene(path):
    classes=collections.Counter();cameras=[];nav=[]
    with path.open(encoding='utf-8-sig')as f:
        for line in f:
            m=re.match(r'^--- !u!(\d+) &(-?\d+)',line)
            if m:
                classes[int(m[1])]+=1
                if m[1]=='20':cameras.append(m[2])
            if line.startswith('  m_NavMeshData:'):nav.append(line.strip())
    return {**ref(path),'GameObject_count':classes[1],'Camera_Class20_fileIDs':cameras,'NavMeshSettings_Class196_count':classes[196],'NavMeshData_references':nav}

def main():
    out=ROOT/'Validation'/('BuildVsPlayabilityBoundary-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    pins={}
    def pin(p):p=Path(p);pins[str(p)]=sha(p);return p
    paths={'game_root':pin(MAIN/'Assets/Scripts/Assembly-CSharp/RecRoomGameRoot.cs'),'boot':pin(MAIN/'Assets/Scripts/Assembly-CSharp/BootSequence.cs'),'movement':pin(MAIN/'Assets/Scripts/Assembly-CSharp/RecRoom/Core/Locomotion/PlayerMovement.cs'),'screen':pin(MAIN/'Assets/Scripts/Assembly-CSharp/RecRoom/ScreenPlayerController.cs')}
    sources={k:p.read_text()for k,p in paths.items()}
    checks={'RecRoomGameRoot.Awake_empty':bool(re.search(r'protected override void Awake\(\)\s*\{\s*\}',sources['game_root'])),'RecRoomGameRoot.Start_empty':bool(re.search(r'private void Start\(\)\s*\{\s*\}',sources['game_root'])),'BootSequence.Awake_empty':bool(re.search(r'protected override void Awake\(\)\s*\{\s*\}',sources['boot'])),'BootSequence.Start_returns_null':bool(re.search(r'private IEnumerator Start\(\)\s*\{\s*return null;\s*\}',sources['boot'])),'PlayerMovement.AuthorityUpdateMovement_empty':bool(re.search(r'public void AuthorityUpdateMovement\(float GGEPGCNHMDB, float OKBAJEAPIHG\)\s*\{\s*\}',sources['movement'])),'ScreenPlayerController.HasInputThisFrame_false':bool(re.search(r'public override bool HasInputThisFrame\s*=>\s*false;',sources['screen']))}
    need(all(checks.values()),'Observed startup/frame stub baseline changed; inspect current bodies before issuing stale finding')
    plugin=pin(MAIN/'Assets/Plugins/Unity.RenderPipelines.Universal.Runtime.dll')
    rendering=module_methods(plugin,[{'owner':'UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset','name':'CreatePipeline','parameters':0},{'owner':'UnityEngine.Rendering.Universal.UniversalRenderPipeline','name':'Render','parameters':2}])
    need([x['IL_bytes']for x in rendering]==['142a','2a'],'Render runtime changed; do not assume earlier stubs remain')
    graphics=pin(MAIN/'ProjectSettings/GraphicsSettings.asset');urp=pin(MAIN/'Assets/MonoBehaviour/URP-Default.asset');urpmeta=pin(urp.with_suffix('.asset.meta'));pluginmeta=pin(plugin.with_suffix('.dll.meta'))
    need('guid: aef5c40c26f695b44858e63d55700b2c' in graphics.read_text()and'guid: aef5c40c26f695b44858e63d55700b2c'in urpmeta.read_text(),'Configured original URP asset changed')
    need('guid: c88ab7b37c4f350242674d2efd621c19'in urp.read_text()and'guid: c88ab7b37c4f350242674d2efd621c19'in pluginmeta.read_text(),'Configured URP MonoScript assembly GUID changed')
    shaders=[]
    for filename in ['AG_Standard-Opaque.asset','Hidden_Universal Render Pipeline_StencilDeferred.asset']:
        p=pin(MAIN/'Assets/Shader'/filename);fields={}
        with p.open()as f:
            for line in f:
                m=re.match(r'^  (platforms|offsets|compressedLengths|decompressedLengths|compressedBlob):\s*(.*?)\s*$',line)
                if m:need(m[1]not in fields,'Duplicate top-level shader program field');fields[m[1]]=m[2]
        need(fields=={'platforms':'','offsets':'[]','compressedLengths':'[]','decompressedLengths':'[]','compressedBlob':''},'Current shader program state changed')
        shaders.append({**ref(p),'top_level_program_fields':fields,'compiledBlob_bytes':0,'all_program_index_arrays_empty':True})
    scene_rows=[scene(pin(MAIN/rel))for rel in ['Assets/Core/Scenes/main_root.unity','Assets/Activities/TitleScreen/Scenes/TitleScreen.unity','Assets/Activities/Dormroom/Scenes/dormroom2.unity','Assets/Activities/LockerRoom/Scenes/reccenter.unity']]
    main_text=(MAIN/'Assets/Core/Scenes/main_root.unity').read_text();need('m_AssetGUID: 740391ea1bc3ee64c9ebcdee9efd7bfb'in main_text,'Original startup Addressable reference changed')
    catalog=ROOT/'AddressablesAudit/Run-20261022T013413Z-e0b9b83a/original-key-to-source-map.json';startup=next(row for row in array_rows(catalog,'assets')if'740391ea1bc3ee64c9ebcdee9efd7bfb'in row.get('catalog_aliases',[]))
    need(startup['original_internal_id']=='Assets/Core/Content/Systems/(Startup).prefab','Exact original startup catalog identity changed')
    streaming=MAIN/'Assets/StreamingAssets';main_entries=sorted(x.name for x in streaming.iterdir());original_entries=sorted(x.name for x in(ROOT/'VerifiedSource/RecRoom_Data/StreamingAssets').iterdir())
    old_plan=pin(ROOT/'Validation/Mono64CoreSignature-20261022T151506Z-476ee90a/plan.json');marshal=[]
    for row in json.loads(old_plan.read_text())['references']:
        if not row.get('malformed_marshal_rows'):continue
        p=pin(MAIN/'Assets/Plugins'/row['image'])
        with p.open('rb')as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ)as b:observed=Cli(b).audit()
        marshal.append({**ref(p),'malformed_field_flags_without_rows':observed['malformed_field_count'],'malformed_parameter_flags_without_rows':observed['malformed_parameter_count'],'FieldMarshal_rows':len(observed['FieldMarshal_rows'])})
    sdkplan=pin(ROOT/'RuntimeSDKRecovery/OriginalSDKDependencyPlan-20261022T182212Z-f54bc83d/report.json');sdk=json.loads(sdkplan.read_text());install=pin(ROOT/'Validation/OriginalNativeSDKInstall-20261022T183143Z-ab41dfa0/report.json');native_proof=pin(ROOT/'RuntimeSDKRecovery/OriginalNativeSDKInstallation-20261022T182911Z-6af6415c/native-export-and-subsystem-proof.json')
    buildsettings=pin(MAIN/'ProjectSettings/EditorBuildSettings.asset');settings=pin(MAIN/'ProjectSettings/ProjectSettings.asset')
    enabled=re.findall(r'  - enabled: 1\s+path: (.+)',buildsettings.read_text());need(enabled and enabled[0]=='Assets/Core/Scenes/main_root.unity','Original build first scene/order changed')
    report={'schema':'current-Windows-build-versus-playability-boundary/v1','status':'read-only-current-evidence-build-result-still-parent-owned','project':str(MAIN),'compile_and_package_facts':{'enabled_original_scene_count':len(enabled),'first_scene':enabled[0],'actual_BuildPipeline_invoked_by_this_audit':False,'actual_build_result_not_inferred_from_Editor_compile':True,'backend_or_stripping_values_from_empty_export_maps_not_assumed':'Root must query actual PlayerSettings.GetScriptingBackend/GetManagedStrippingLevel for StandaloneWindows64.','native_installation_receipt':ref(install),'native_PE_import_plan':ref(sdkplan),'unresolved_original_native_PE_import_names':sdk['unresolved_PE_import_names'],'native_DLL_static_export_proof':ref(native_proof),'native_import_success_not_runtime_execution_proof':True},'definite_runtime_gaps':{'source_callback_and_frame_stubs':checks,'source_inputs':[ref(p)for p in paths.values()],'configured_URP_asset':ref(urp),'configured_URP_runtime':ref(plugin),'URP_method_bodies':rendering,'shader_program_payloads':shaders,'scene_camera_and_nav_references':scene_rows,'scene_role_limit':'No Camera in original main_root/TitleScreen and zero baked NavMeshData references are observations, not permission to add a fake camera or bake replacement navigation. Original startup/rig code must instantiate its real content.','original_startup_Addressable':{'GUID':'740391ea1bc3ee64c9ebcdee9efd7bfb','original_internal_id':startup['original_internal_id'],'catalog_entry_index':startup['entry_index'],'preserved_catalog_map':str(catalog),'dependency_bundles':startup['dependency_bundles']},'Main_StreamingAssets_top_level':main_entries,'verified_original_StreamingAssets_top_level':original_entries,'original_aa_catalog_present_in_Main':(streaming/'aa/catalog.json').is_file(),'managed_plugin_marshal_hazards':marshal,'total_dangling_plugin_marshal_owners':sum(x['malformed_field_flags_without_rows']+x['malformed_parameter_flags_without_rows']for x in marshal)},'actual_build_failure_triage_policy':['A missing body/default return is valid C# and may package successfully; it must not be credited as functional startup or movement.','The two empty compiled shader payloads are proven rendering defects. Whether BuildPipeline fails, warns, strips variants or packages unsupported shaders requires its actual log/report.','Malformed Marshal owner metadata is a real managed runtime hazard, but this audit does not claim every such row is traversed during this specific build.','No unresolved PE import names were reported for the installed original Windows SDK set. PInvoke route/entrypoint/marshaling correctness and SDK feature initialization remain separate runtime tests.'], 'small_authentic_next_fixes_if_error_matches':['Shader serialization/constant-buffer failure: decode exact original Class48 bounded object, verify every program/index/CB field and sourceGUID/fileID provenance, isolated matchingEditor import, then preserve Main Shader/material identities. Do not hide errors or substitute shaders.','Missing Addressables at runtime: stage the verified original aa catalog/settings and dependency-complete original bundles at their original StreamingAssets layout, with byte manifests. This alone does not repair the empty boot or renderer bodies.','Player-only C# or linker failure: repair the exact original runtime ownership/platform contract proved by metadata; do not globally exclude scenes/types or invent successful return values.','Native missing-library/entrypoint failure: match exact module/architecture/export against verified original source and importer platform routing; no shim/default callbacks.'], 'original_boot_closure_checkpoint':str(ROOT/'Validation/ServiceContainerBootCheckpoint-20261022T184012Z-4c3eaea5/readiness.json'),'source_geometry_settings_or_backend_modified':False,'Unity_or_game_or_native_code_launched':False,'managed_helper_child_launched':False,'inputs_before_after_unchanged':False}
    need(all(sha(Path(p))==h for p,h in pins.items()),'Source changed during read-only audit; regenerate against fresh state')
    report['inputs_before_after_unchanged']=True;report['input_pins']=[{'path':p,'sha256':h}for p,h in pins.items()];path=out/'report.json';path.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(path),'sha256':sha(path),'enabled_scenes':len(enabled),'dangling_plugin_marshal_owners':report['definite_runtime_gaps']['total_dangling_plugin_marshal_owners'],'actual_build_result_claimed':False}))

if __name__=='__main__':main()
