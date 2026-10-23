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
    need(nativeproof.get('schema')=='genuine-editor-shader-native-singleton-input/v1' and nativeproof.get('status')=='genuine_editor_tree_and_exact_converted_payload_wrapped_native_import_unproven','Genuine Editor layout singleton construction proof')
    need(Path(nativeoutput.get('path','')).resolve()==a.native_input.resolve() and nativeoutput.get('sha256')==sha(a.native_input),'Exact proved Editor singleton bytes')
    need(nativeoutput.get('class_ids')==[48] and nativeoutput.get('object_count')==1 and nativeoutput.get('path_ids')==[4800000]
        and nativeoutput.get('script_type_count')==nativeoutput.get('external_file_count')==nativeoutput.get('ref_type_count')==0,'No scripts, other classes, or external binary input dependencies')
    genuine=nativeproof.get('source',{});conversion=nativeproof.get('converter',{})
    need(genuine.get('engine')=='2020.3.33f1' and genuine.get('platform')==-2 and genuine.get('has_type_tree') is True
        and genuine.get('selected_type',{}).get('old_type_hash')=='888994cda549cb3b5380e3be28b6cd6d'
        and genuine.get('selected_type',{}).get('raw_sha256')=='0fbf2d2f8e6c2b23f21468a5a0528d28f361ca32775a5dec12d72f1f3a093171','Exact same-version genuine full Editor Shader type tree')
    need(conversion.get('original_release_pointer_closure',{}).get('sha256')=='9e615d45be84597747ffa9094ba904ccb4a6977be7b86a8a893a1160597cc423','Exact original source32 zero-pointer closure')
    runpin=conversion.get('successful_conversion_run',{});runpath=Path(runpin.get('path',''))
    need(runpath.is_file() and sha(runpath)==runpin.get('sha256'),'Actual successful normalized conversion receipt required')
    converted=json.loads(runpath.read_bytes());need(converted.get('status')=='all_original_data_and_DXBC_preserved_with_proven_Name_metadata_normalization' and converted.get('original_DXBC_after_Editor_roundtrip',{}).get('dxbc_chunks')==4,'Original data and all four DXBC chunks must survive Editor roundtrip')
    base=json.loads((BASE/'plan.json').read_bytes());need(sha(BASE/'plan.json')=='3cddd62d6db9ce18d3a60466d2498995a5e4f06e100016952af809dc447b7662','Frozen successful tiny build plan')
    source=WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_FallbackError.asset';meta=source.with_suffix('.asset.meta')
    need(sha(source)=='782dc41ae622cd5b5ea5ae4d9ebb442d221038d3e6ae06993d97336dd6263e5d','Genuine original fallback data changed')
    fixture=ROOT/'AssetRecovery'/('OriginalShaderWindowsBuildFixture-ForceBinary-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);fixture.mkdir();project=fixture/'Project';inputs=[];sources=[]
    def write(relative,data):
        p=project/relative;p.parent.mkdir(parents=True,exist_ok=True);p.write_bytes(data.encode() if isinstance(data,str) else data);inputs.append(row(p));return p
    def copy(src,relative):
        pin=row(src);target=write(relative,src.read_bytes());need(sha(src)==sha(target)==pin['sha256'],'Read-only source copy');sources.append(pin);return target
    native=fixture/'NativeInput.assets';shutil.copyfile(a.native_input,native);native_meta=fixture/'OriginalFallback.asset.meta';shutil.copyfile(meta,native_meta)
    need(sha(native)==sha(a.native_input) and sha(native_meta)==sha(meta),'Exact native input/meta copy')
    proof=fixture/'native-source-proof.json';shutil.copyfile(a.native_proof,proof)
    config0=json.loads((BASE/'expected-shaders.json').read_bytes());expected=[r for r in config0['shaders'] if r['name']=='Hidden/Universal Render Pipeline/FallbackError'];need(len(expected)==1,'Exact existing fallback contract')
    expected=expected[0];expected['asset_path']='Assets/Resources/OriginalNativeFallback.asset';expected['sha256']=sha(native)
    write(expected['asset_path'],native.read_bytes());write(expected['asset_path']+'.meta',native_meta.read_bytes())
    text=(HERE/'BuildOriginalShaderPrograms.cs').read_text();need('Require(config.shaders.Length == 3' in text,'Exact reviewed builder source')
    text=text.replace('using UnityEditor.SceneManagement;','using UnityEditor.SceneManagement;\nusing UnityEditorInternal;')
    text=text.replace('public string project, graphics_sha256;','public string project, graphics_sha256, native_path, native_sha256, meta_source_path, meta_sha256;')
    text=text.replace('public int total_errors, total_warnings, partial_constant_buffer_messages;','public string native_input_sha256, saved_native_asset_sha256, imported_guid;\n        public long imported_file_id;\n        public bool original_native_loaded;\n        public int total_errors, total_warnings, partial_constant_buffer_messages;')
    old='''            Require(config.shaders.Length == 3, "Exactly Stencil, genuine FallbackError, and unchanged SMAA required");
            CheckInputs(config);'''
    new='''            Require(config.shaders.Length == 1, "Exactly one proven original binary Shader required");
            Require(Sha(config.native_path) == config.native_sha256 && Sha(config.meta_source_path) == config.meta_sha256, "Original proven binary input/meta source changed");
            result.native_input_sha256 = config.native_sha256;
            CheckInputs(config);
            AssetDatabase.ImportAsset(config.shaders[0].asset_path, ImportAssetOptions.ForceSynchronousImport);
            CheckInputs(config);
            Shader imported = AssetDatabase.LoadAssetAtPath<Shader>(config.shaders[0].asset_path);
            string importedGuid = null; long importedFileId = 0;
            Require(imported != null && AssetDatabase.TryGetGUIDAndLocalFileIdentifier(imported, out importedGuid, out importedFileId), "Original binary resource has no identity");
            result.imported_guid = importedGuid; result.imported_file_id = importedFileId;
            Require(importedGuid == config.shaders[0].guid && importedFileId == 4800000, "Original direct binary Shader identity changed");
            result.original_native_loaded = true;
            CheckInputs(config);'''
    need(text.count(old)==1,'Exact native load/save insertion anchor');text=text.replace(old,new)
    text=text.replace('original_native_loaded','direct_original_binary_imported').replace('saved_native_asset_sha256','unused_saved_asset_sha256')
    need('InternalEditorUtility.LoadSerializedFileAndForget' not in text and 'InternalEditorUtility.SaveToSerializedFileAndForget' not in text,'Direct fixture must not call native load/save API')
    anchor='''            CheckInputs(config); result.input_bytes_unchanged = true;'''
    replacement='''            CheckInputs(config);
            string afterGuid; long afterFileId;
            Shader afterShader = AssetDatabase.LoadAssetAtPath<Shader>(config.shaders[0].asset_path);
            Require(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(afterShader, out afterGuid, out afterFileId) && afterGuid == config.shaders[0].guid && afterFileId == 4800000, "Original direct binary identity changed after build");
            Require(Sha(config.native_path) == config.native_sha256, "Original proven binary input changed after build");
            result.input_bytes_unchanged = true;'''
    need(text.count(anchor)==1,'Exact postbuild preservation anchor');text=text.replace(anchor,replacement)
    text=text.replace('public string native_input_sha256,','public string serialization_mode, native_input_sha256,')
    mode_anchor='            Require(Application.unityVersion == "2020.3.33f1", "Exact matching Unity required");'
    mode_check=mode_anchor+'\n            result.serialization_mode = EditorSettings.serializationMode.ToString();\n            Require(EditorSettings.serializationMode == SerializationMode.ForceBinary, "ForceBinary must be configured before initial shader import");'
    need(text.count(mode_anchor)==1,'Exact runtime serializationMode gate anchor');text=text.replace(mode_anchor,mode_check)
    write('Assets/Editor/BuildOriginalShaderPrograms.cs',text)
    guard=WS/'RR23/Assets/Editor/AssetRipperPatches/AvoidSavingYamlShaders.cs';copy(guard,'Assets/Editor/AvoidSavingYamlShaders.cs');copy(guard.with_suffix('.cs.meta'),'Assets/Editor/AvoidSavingYamlShaders.cs.meta')
    write('ProjectSettings/ProjectVersion.txt','m_EditorVersion: 2020.3.33f1\nm_EditorVersionWithRevision: 2020.3.33f1 (915a7af8b0d5)\n')
    editor_settings_source=WS/'RR23/ProjectSettings/EditorSettings.asset';editor_settings_before=editor_settings_source.read_bytes();editor_source_pin=row(editor_settings_source)
    need(b'  serializedVersion: 11' in editor_settings_before,'Same matching original EditorSettings version11')
    editor_settings_after,mode_count=re.subn(rb'(?m)^(  m_SerializationMode: )2(?=\r?$)',rb'\g<1>1',editor_settings_before)
    need(mode_count==1 and len(editor_settings_before)==len(editor_settings_after),'Only exact original ForceText2 field changes toForceBinary1')
    changed_offsets=[i for i,(old,new) in enumerate(zip(editor_settings_before,editor_settings_after)) if old!=new]
    need(len(changed_offsets)==1 and editor_settings_before[changed_offsets[0]]==ord('2') and editor_settings_after[changed_offsets[0]]==ord('1'),'Every EditorSettings byte outside one mode byte must remain exact')
    need(sha(editor_settings_source)==editor_source_pin['sha256'],'Read-only EditorSettings source race');sources.append(editor_source_pin)
    editor_settings_target=write('ProjectSettings/EditorSettings.asset',editor_settings_after)

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
    plan=dict(base);plan.update(status='prepared_ForceBinary_before_initial_import_not_compiled_or_launched',fixture=str(fixture),project=str(project),runner=row(runner),preparer=row(Path(__file__)),inputs=inputs,
        read_only_sources=sources+[row(a.native_input),row(a.native_proof),row(source),row(meta),row(native),row(native_meta),row(proof)],expected_data=row(config),original_programs=row(original),
        compile_checks=[{'name':'native-shader-builder','source':row(sourcepath),'response':row(rsp),'references':references}],
        native_input=row(native),native_source_proof=row(proof),native_route='Exact proved Editor binary copied directly into Resources with unchanged original meta/GUID and fileID4800000. No LoadSerializedFileAndForget or SaveToSerializedFileAndForget calls. Require binary hash/meta/GUID/fileID preservation before and after Import/Build, zero partialCB, and real native output DXBC fidelity.',
        source_game_assemblies=0,original_non_shader_ClassIDs=0,
        limitations=['Native load/save/build retention is UNPROVEN until Root runs this exact fixture.','FallbackError is the genuine original shader under test, never a replacement for Stencil or AG materials.','No original game code, Play, GPU rendering or Main modification.'])
    plan['editor_serialization']={'mode':'ForceBinary','serialized_mode_value':1,'configured_before_first_Editor_launch':True,'source':editor_source_pin,'fixture_settings':row(editor_settings_target),'only_changed_byte_offsets':changed_offsets,'all_bytes_outside_mode_field_exact':True,'Main_setting_changed':False}
    planpath=fixture/'plan.json';planpath.write_bytes((json.dumps(plan,indent=2)+'\n').encode());print(json.dumps({'status':plan['status'],'plan':row(planpath),'runner':row(runner),'command':['C:\\Python314\\python.exe','-B',str(runner),'--fixture',str(fixture),'--run']}))
if __name__=='__main__':main()
