"""Stage a tiny real Windows shader build and strict native-program checks only."""
from pathlib import Path
import datetime as dt,hashlib,json,re,shutil,uuid
from shader_program_data import yaml_program,program_facts
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor/Unity.exe';CLI=Path('C:/Users/andre/AppData/Local/Unity/bin/unity.exe')
MODEL=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
def need(value,message):
    if not value:raise ValueError(message)
def sha(path):
    with Path(path).open('rb') as stream:return hashlib.file_digest(stream,'sha256').hexdigest()
def row(path):return {'path':str(path.resolve()),'sha256':sha(path),'bytes':path.stat().st_size}
def guid(path):
    values=re.findall(rb'(?m)^guid: ([0-9a-f]{32})\s*$',path.read_bytes());need(len(values)==1,'One existing meta GUID');return values[0].decode()
def main():
    specs=[(ROOT/'AssetRecovery/OriginalStencilShaderCandidate-20261022T193440Z-99839b22/Hidden_Universal Render Pipeline_StencilDeferred.asset','dde827ae07a553b9b27531b774199853f0837f082bf2d3c13a9b1c1f8a2b5697'),
        (WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_FallbackError.asset','782dc41ae622cd5b5ea5ae4d9ebb442d221038d3e6ae06993d97336dd6263e5d'),
        (WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_SubpixelMorphologicalAntialiasing.asset','79db2e11def4e0928f62e8ff36548771bf16b32d2ddf7edf9f4ae46002841509')]
    need(all(sha(path)==expected for path,expected in specs),'Frozen candidate or genuine controls changed')
    fixture=ROOT/'AssetRecovery'/('OriginalShaderWindowsBuildFixture-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);fixture.mkdir()
    project=fixture/'Project';inputs=[];sources=[]
    def write(relative,data):
        path=project/relative;path.parent.mkdir(parents=True,exist_ok=True);path.write_bytes(data.encode() if isinstance(data,str) else data);inputs.append(row(path));return path
    def copy(source,relative):
        before=row(source);target=write(relative,source.read_bytes());need(sha(source)==sha(target)==before['sha256'],'Read-only copy race');sources.append(before);return target
    configs=[];facts=[]
    for source,expected in specs:
        target=copy(source,'Assets/Resources/'+source.name);meta=copy(source.with_suffix('.asset.meta'),target.relative_to(project).as_posix()+'.meta')
        name=re.findall(rb'(?m)^  m_Name: (.*)\r?$',source.read_bytes())[0].decode().strip()
        configs.append({'asset_path':target.relative_to(project).as_posix(),'sha256':sha(target),'meta_sha256':sha(meta),'guid':guid(meta),'name':name})
        facts.append({'name':name,'source':row(source),'source_meta':row(source.with_suffix('.asset.meta')),'program':program_facts(yaml_program(source))})
    observer=copy(HERE/'BuildOriginalShaderPrograms.cs','Assets/Editor/BuildOriginalShaderPrograms.cs')
    guard=WS/'RR23/Assets/Editor/AssetRipperPatches/AvoidSavingYamlShaders.cs';need(sha(guard)=='cdf4cd167fb80b36631476c23214c1321e4e24052613e73394982ddcab452cde','Save protection changed')
    copy(guard,'Assets/Editor/AvoidSavingYamlShaders.cs');copy(guard.with_suffix('.cs.meta'),'Assets/Editor/AvoidSavingYamlShaders.cs.meta')
    write('ProjectSettings/ProjectVersion.txt','m_EditorVersion: 2020.3.33f1\nm_EditorVersionWithRevision: 2020.3.33f1 (915a7af8b0d5)\n')
    copy(WS/'RR23/ProjectSettings/ProjectSettings.asset','ProjectSettings/ProjectSettings.asset')
    graphics_source=WS/'RR23/ProjectSettings/GraphicsSettings.asset';graphics=graphics_source.read_bytes();before=row(graphics_source)
    always=b'  m_AlwaysIncludedShaders:\n'+b''.join(('  - {fileID: 4800000, guid: '+r['guid']+', type: 2}\n').encode() for r in configs)
    graphics,count=re.subn(rb'(?ms)^  m_AlwaysIncludedShaders:\r?\n.*?(?=^  [A-Za-z_])',always,graphics);need(count==1,'Exact always included block')
    graphics,count=re.subn(rb'(?m)^  m_CustomRenderPipeline:.*$',b'  m_CustomRenderPipeline: {fileID: 0}',graphics);need(count==1,'Exact fixture pipeline field')
    need(sha(graphics_source)==before['sha256'],'Graphics source race');sources.append(before)
    graphics_path=write('ProjectSettings/GraphicsSettings.asset',graphics)
    write('Packages/manifest.json','{"dependencies":{}}\n')
    config=fixture/'expected-shaders.json';config.write_bytes((json.dumps({'project':str(project),'graphics_sha256':sha(graphics_path),'shaders':configs},indent=2)+'\n').encode())
    original=fixture/'input-original-programs.json';original.write_bytes((json.dumps({'schema':'original-shader-D3D11-programs/v1','shaders':facts},indent=2)+'\n').encode())
    editor=EDITOR.parent;framework=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'
    refs=[framework/'mscorlib.dll',framework/'System.dll',framework/'System.Core.dll',editor/'Data/Managed/UnityEditor.dll',editor/'Data/Managed/UnityEngine/UnityEngine.dll',editor/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',editor/'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll']
    rsp=fixture/'observer.rsp';rsp.write_bytes(('\n'.join(['/nologo','/nostdlib+','/target:library','/langversion:8']+['/reference:"'+str(p)+'"' for p in refs]+['"'+str(observer)+'"'])+'\n').encode())
    host=MODEL/'OriginalShaderObjectProbe.dll';need(sha(MODEL/'report.json')=='e99d06254cd16e817a20e19cedecbedf8005c19608d7141d80461a9b9c6c8f97','Existing reader compile witness')
    need(sha(MODEL/'OriginalShaderObjectProbe.cs')=='c10e692d0d482e9a55ede144f2ceb89e7622d7dce4bcc8b9af7adadc345858c3','Generic reader source')
    readerpins=[row(p) for p in sorted(MODEL.glob('*.dll'))]+[row(host.with_suffix('.runtimeconfig.json')),row(host.with_suffix('.deps.json')),row(MODEL/'report.json'),row(MODEL/'OriginalShaderObjectProbe.cs')]
    helper=HERE/'owned_suspended_launch.py';need(sha(helper)=='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958','Reviewed assign-before-resume helper')
    plan={'schema':'prepared-tiny-original-shader-windows-build/v1','status':'prepared_not_compiled_or_launched','fixture':str(fixture),'project':str(project),
        'editor':row(EDITOR),'cli':row(CLI),'compiler':row(editor/'Data/Tools/Roslyn/csc.exe'),'dotnet':row(Path('C:/Program Files/dotnet/dotnet.exe')),
        'runner':row(HERE/'run_original_shader_build_fixture.py'),'launcher':row(helper),'preparer':row(Path(__file__)),
        'support_sources':[row(HERE/'run_windows_development_define_probe.py'),row(HERE/'shader_program_data.py'),row(HERE/'stage_original_stencil_shader.py'),row(HERE/'probe_original_shader_sources.py')],
        'inputs':inputs,'read_only_sources':sources,'expected_data':row(config),'original_programs':row(original),
        'compile_checks':[{'name':'shader-builder','source':row(observer),'response':row(rsp),'references':[row(p) for p in refs]}],
        'reader':row(host),'reader_pins':readerpins,'target':'StandaloneWindows64','backend':'Mono2x','build_options':['Development','StrictMode'],'graphics_api':'Direct3D11',
        'maximum_owned_job_bytes':2*1024**3,'compile_owned_job_bytes':256*1024**2,'reader_owned_job_bytes':512*1024**2,'minimum_system_commit_reserve_bytes':int(1.5*1024**3),'maximum_editor_seconds':300,
        'shader_retention':'Three exact source GUIDs in Resources and fixture AlwaysIncludedShaders; existing keep-lightmap/fog/instancing settings retained. Passive variant witness never changes entries.',
        'native_output_gate':['BuildReport Succeeded, zero errors, real diagnostic exe exists, no player launch.','Any full Editor log Partial constant buffer not found message fails this gate.','Extract only selected Class48 byte ranges from built native containers; generic original reader must consume each entire object with exact Shader name and nonempty D3D11 program arrays/blob.','Bounded pure LZ4 exact decoded lengths, structural DXBC validation; every built DXBC hash must occur in same original input Shader. Report stripped original hashes, do not equate compressed blob hashes.'],
        'fixture_settings_changes':['GraphicsSettings alwaysIncludedShaders narrowed to three actual input Shader GUIDs.','CustomRenderPipeline cleared in isolated project only; original pipeline/game code absent.','Windows64 Mono Development StrictMode D3D11 selected in fixture only.'],
        'Main_modified':False,'Editor_launched':False,'compiler_launched':False,'player_launched':False,'limitations':['Diagnostic fixture is not a game test build.','No GPU rendering, gameplay, URP renderer, login or original full-game behavior proof.','DXBC subset proves retained code identity; stripped variants and full original pass-to-program mappings remain explicit limitations.']}
    path=fixture/'plan.json';path.write_bytes((json.dumps(plan,indent=2)+'\n').encode())
    print(json.dumps({'status':plan['status'],'plan':row(path),'program_chunks':[(f['name'],f['program']['dxbc_chunks']) for f in facts],'future_command':['C:\\Python314\\python.exe','-B',str(HERE/'run_original_shader_build_fixture.py'),'--fixture',str(fixture),'--run']}))
if __name__=='__main__':main()
