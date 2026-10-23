"""Stage native original Shader load/save plus tiny Windows build; never launch."""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,re,shutil,uuid
from shader_program_data import yaml_program,program_facts
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
BASE=ROOT/'AssetRecovery/OriginalShaderWindowsBuildFixture-20261022T210316Z-7924a487'
def need(x,m):
    if not x:raise ValueError(m)
def sha(p):
    with Path(p).open('rb') as s:return hashlib.file_digest(s,'sha256').hexdigest()
def row(p):return {'path':str(p.resolve()),'sha256':sha(p),'bytes':p.stat().st_size}
def main():
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--native-input',type=Path,required=True);parser.add_argument('--native-proof',type=Path,required=True);a=parser.parse_args()
    need(a.native_input.is_file() and a.native_proof.is_file(),'Proven singleton original native input required')
    need(a.native_input.resolve().is_relative_to(ROOT/'AssetRecovery'),'Native test input must remain outside Main')
    nativeproof=json.loads(a.native_proof.read_bytes());nativeoutput=nativeproof.get('output',{})
    need(nativeproof.get('schema')=='bounded-original-fallback-native-serialized-input/v1' and nativeproof.get('status')=='staged_untested_native_input_exact_original_class48_object','Exact original singleton construction proof')
    need(Path(nativeoutput.get('path','')).resolve()==a.native_input.resolve() and nativeoutput.get('sha256')==sha(a.native_input),'Exact proved singleton container bytes')
    need(nativeoutput.get('class_ids')==[48] and nativeoutput.get('object_count')==1 and nativeoutput.get('path_ids')==[4800000]
        and nativeoutput.get('script_type_count')==nativeoutput.get('external_file_count')==nativeoutput.get('ref_type_count')==0,'No scripts, other classes, or external binary input dependencies')
    need(nativeproof.get('original_selected_object',{}).get('sha256')=='9d68229325a824a746e3dcdca644dc7d5eb9c3677d724b118697785d8c714300'
        and nativeproof.get('closure',{}).get('dependency_count')==nativeproof.get('closure',{}).get('nonmodifiable_texture_count')==0,'Proven self-contained original source32 object required')
    base=json.loads((BASE/'plan.json').read_bytes());need(sha(BASE/'plan.json')=='3cddd62d6db9ce18d3a60466d2498995a5e4f06e100016952af809dc447b7662','Frozen successful tiny build plan')
    source=WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_FallbackError.asset';meta=source.with_suffix('.asset.meta')
    need(sha(source)=='782dc41ae622cd5b5ea5ae4d9ebb442d221038d3e6ae06993d97336dd6263e5d','Genuine original fallback data changed')
    fixture=ROOT/'AssetRecovery'/('OriginalShaderWindowsBuildFixture-Binary-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);fixture.mkdir();project=fixture/'Project';inputs=[];sources=[]
    def write(relative,data):
        p=project/relative;p.parent.mkdir(parents=True,exist_ok=True);p.write_bytes(data.encode() if isinstance(data,str) else data);inputs.append(row(p));return p
    def copy(src,relative):
        pin=row(src);target=write(relative,src.read_bytes());need(sha(src)==sha(target)==pin['sha256'],'Read-only source copy');sources.append(pin);return target
    native=fixture/'NativeInput.assets';shutil.copyfile(a.native_input,native);native_meta=fixture/'OriginalFallback.asset.meta';shutil.copyfile(meta,native_meta)
    need(sha(native)==sha(a.native_input) and sha(native_meta)==sha(meta),'Exact native input/meta copy')
    proof=fixture/'native-source-proof.json';shutil.copyfile(a.native_proof,proof)
    config0=json.loads((BASE/'expected-shaders.json').read_bytes());expected=[r for r in config0['shaders'] if r['name']=='Hidden/Universal Render Pipeline/FallbackError'];need(len(expected)==1,'Exact existing fallback contract')
    expected=expected[0];expected['asset_path']='Assets/Resources/OriginalNativeFallback.asset';expected['sha256']='assigned_from_native_binary_save_in_memory_before_build'
    text=(HERE/'BuildOriginalShaderPrograms.cs').read_text();need('Require(config.shaders.Length == 3' in text,'Exact reviewed builder source')
    text=text.replace('using UnityEditor.SceneManagement;','using UnityEditor.SceneManagement;\nusing UnityEditorInternal;')
    text=text.replace('public string project, graphics_sha256;','public string project, graphics_sha256, native_path, native_sha256, meta_source_path, meta_sha256;')
    text=text.replace('public int total_errors, total_warnings, partial_constant_buffer_messages;','public string native_input_sha256, saved_native_asset_sha256, imported_guid;\n        public long imported_file_id;\n        public bool original_native_loaded;\n        public int total_errors, total_warnings, partial_constant_buffer_messages;')
    old='''            Require(config.shaders.Length == 3, "Exactly Stencil, genuine FallbackError, and unchanged SMAA required");
            CheckInputs(config);'''
    new='''            Require(config.shaders.Length == 1, "Exactly one proven self-contained native Shader required");
            Require(Sha(config.native_path) == config.native_sha256 && Sha(config.meta_source_path) == config.meta_sha256, "Original native input/meta source changed");
            result.native_input_sha256 = config.native_sha256;
            UnityEngine.Object[] loaded = InternalEditorUtility.LoadSerializedFileAndForget(config.native_path);
            Require(loaded != null && loaded.Length == 1 && loaded[0] is Shader && loaded[0].name == config.shaders[0].name, "Singleton original native Shader load failed");
            result.original_native_loaded = true;
            string resource = config.shaders[0].asset_path;
            Require(!File.Exists(resource) && !File.Exists(resource + ".meta"), "Fresh native output resource required");
            Directory.CreateDirectory("Assets/Resources");
            InternalEditorUtility.SaveToSerializedFileAndForget(loaded, resource, false);
            Require(File.Exists(resource) && new FileInfo(resource).Length > 0, "Native binary save produced no file");
            File.WriteAllBytes(resource + ".meta", File.ReadAllBytes(config.meta_source_path));
            config.shaders[0].sha256 = Sha(resource); result.saved_native_asset_sha256 = config.shaders[0].sha256;
            AssetDatabase.ImportAsset(resource, ImportAssetOptions.ForceSynchronousImport);
            Shader imported = AssetDatabase.LoadAssetAtPath<Shader>(resource);
            string importedGuid = null; long importedFileId = 0;
            Require(imported != null && AssetDatabase.TryGetGUIDAndLocalFileIdentifier(imported, out importedGuid, out importedFileId), "Native resource import has no identity");
            result.imported_guid = importedGuid; result.imported_file_id = importedFileId;
            Require(importedGuid == config.shaders[0].guid && importedFileId == 4800000, "Native saved Shader identity differs from proven fixture binding");
            Require(Sha(config.native_path) == config.native_sha256, "Original native input changed during native load/save");
            CheckInputs(config);'''
    need(text.count(old)==1,'Exact native load/save insertion anchor');text=text.replace(old,new)
    write('Assets/Editor/BuildOriginalShaderPrograms.cs',text)
    guard=WS/'RR23/Assets/Editor/AssetRipperPatches/AvoidSavingYamlShaders.cs';copy(guard,'Assets/Editor/AvoidSavingYamlShaders.cs');copy(guard.with_suffix('.cs.meta'),'Assets/Editor/AvoidSavingYamlShaders.cs.meta')
    write('ProjectSettings/ProjectVersion.txt','m_EditorVersion: 2020.3.33f1\nm_EditorVersionWithRevision: 2020.3.33f1 (915a7af8b0d5)\n')
    copy(WS/'RR23/ProjectSettings/ProjectSettings.asset','ProjectSettings/ProjectSettings.asset')
    graphics=(BASE/'Project/ProjectSettings/GraphicsSettings.asset').read_bytes()
    always=('  m_AlwaysIncludedShaders:\n  - {fileID: 4800000, guid: '+expected['guid']+', type: 2}\n').encode()
    graphics,count=re.subn(rb'(?ms)^  m_AlwaysIncludedShaders:\r?\n.*?(?=^  [A-Za-z_])',always,graphics);need(count==1,'Exact singleton keep variant block')
    graphics_path=write('ProjectSettings/GraphicsSettings.asset',graphics);write('Packages/manifest.json','{"dependencies":{}}\n')
    config=fixture/'expected-shaders.json';config.write_bytes((json.dumps({'project':str(project),'graphics_sha256':sha(graphics_path),'shaders':[expected],
        'native_path':str(native),'native_sha256':sha(native),'meta_source_path':str(native_meta),'meta_sha256':sha(native_meta)},indent=2)+'\n').encode())
    original=fixture/'input-original-programs.json';original.write_bytes((json.dumps({'schema':'original-shader-D3D11-programs/v1','shaders':[{'name':expected['name'],'source':row(source),'source_meta':row(meta),'program':program_facts(yaml_program(source))}]},indent=2)+'\n').encode())
    runnertext=(HERE/'run_original_shader_build_fixture.py').read_text();anchor="hits=[name for name in wanted if struct.pack('<I',len(name.encode()))+name.encode() in raw]"
    need(runnertext.count(anchor)==1,'Exact leading-name finder amendment')
    runnertext=runnertext.replace(anchor,"leading_count=struct.unpack_from('<I',raw)[0];need(leading_count<=min(508,len(raw)-4),'Native leading name bounds');leading_name=raw[4:4+leading_count].decode('utf-8');hits=[name for name in wanted if name==leading_name]")
    runnertext=runnertext.replace("HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'","HERE=Path("+repr(str(HERE))+");WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'")
    runner=fixture/'run-binary-shader-build.py';runner.write_bytes(("import sys\nsys.path.insert(0,"+repr(str(HERE))+")\n"+runnertext).encode())
    sourcepath=project/'Assets/Editor/BuildOriginalShaderPrograms.cs';references=base['compile_checks'][0]['references'];rsp=fixture/'observer.rsp'
    rsp.write_bytes(('\n'.join(['/nologo','/nostdlib+','/target:library','/langversion:8']+['/reference:"'+r['path']+'"' for r in references]+['"'+str(sourcepath)+'"'])+'\n').encode())
    plan=dict(base);plan.update(status='prepared_native_route_not_compiled_or_launched',fixture=str(fixture),project=str(project),runner=row(runner),preparer=row(Path(__file__)),inputs=inputs,
        read_only_sources=sources+[row(a.native_input),row(a.native_proof),row(source),row(meta),row(native),row(native_meta),row(proof)],expected_data=row(config),original_programs=row(original),
        compile_checks=[{'name':'native-shader-builder','source':row(sourcepath),'response':row(rsp),'references':references}],
        native_input=row(native),native_source_proof=row(proof),native_route='Exact original singleton Class48 source container, native LoadSerializedFileAndForget then native binary SaveToSerializedFileAndForget(false), matching meta/GUID and localID4800000, real Windows build and output original DXBC check.',
        source_game_assemblies=0,original_non_shader_ClassIDs=0,
        limitations=['Native load/save/build retention is UNPROVEN until Root runs this exact fixture.','FallbackError is the genuine original shader under test, never a replacement for Stencil or AG materials.','No original game code, Play, GPU rendering or Main modification.'])
    planpath=fixture/'plan.json';planpath.write_bytes((json.dumps(plan,indent=2)+'\n').encode());print(json.dumps({'status':plan['status'],'plan':row(planpath),'runner':row(runner),'command':['C:\\Python314\\python.exe','-B',str(runner),'--fixture',str(fixture),'--run']}))
if __name__=='__main__':main()
