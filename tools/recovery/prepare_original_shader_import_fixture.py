"""Prepare only: two-session Unity2020 original Shader verification fixture."""
from pathlib import Path
import datetime as dt,hashlib,json,re,shutil,struct,uuid
from compare_shader_parsed_form import field_lines
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
CANDIDATE=ROOT/'AssetRecovery/OriginalStencilShaderCandidate-20261022T193440Z-99839b22'
PROBE=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor/Unity.exe'
CLI=Path('C:/Users/andre/AppData/Local/Unity/bin/unity.exe')
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def row(p):return {'path':str(p.resolve()),'sha256':sha(p),'bytes':p.stat().st_size}
def guid(p):
 hits=re.findall(rb'(?m)^guid: ([0-9a-f]{32})\s*$',p.read_bytes())
 if len(hits)!=1:raise ValueError('One exact existing GUID required: '+str(p))
 return hits[0].decode()
def main():
 ready=json.loads((CANDIDATE/'readiness.json').read_text());report=json.loads((CANDIDATE/'report.json').read_text())
 if ready['status']!='staged_awaiting_matching_unity_import' or not ready['candidate_parsed_form_exact_to_original_model']:raise ValueError('Candidate gate not ready')
 for entry in ready['artifacts']:
  if sha(entry['path'])!=entry['sha256']:raise ValueError('Candidate proof drift')
 source=Path(report['candidate']['path']);meta=Path(report['candidate_meta']['path'])
 if sha(source)!=report['candidate']['sha256'] or sha(meta)!=report['candidate_meta']['sha256']:raise ValueError('Candidate drift')
 dependency=WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_FallbackError.asset';dependency_meta=dependency.with_suffix('.asset.meta')
 if guid(dependency_meta)!='d2a5536c48f6e914f900eb13ea2f4d68':raise ValueError('Exact original dependency GUID required')
 # This existing dependency is already program-bearing, not a replacement.
 if not re.search(rb'(?m)^  compressedBlob: [0-9a-f]+\r?$',dependency.read_bytes()):raise ValueError('Unexpected empty fallback control')
 helper=WS/'RR23/Assets/Editor/AssetRipperPatches/AvoidSavingYamlShaders.cs';helper_meta=helper.with_suffix('.cs.meta')
 original_helper_sha='cdf4cd167fb80b36631476c23214c1321e4e24052613e73394982ddcab452cde'
 if sha(helper)!=original_helper_sha:raise ValueError('Original save-protection helper changed')
 out=ROOT/'AssetRecovery'/('OriginalStencilImportFixture-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 project=out/'Project';assets=project/'Assets';shader_dir=assets/'Shader';editor_dir=assets/'Editor';shader_dir.mkdir(parents=True);editor_dir.mkdir()
 sources=[];inputs=[]
 def copy(src,target):
  before=row(src);shutil.copyfile(src,target)
  if sha(target)!=before['sha256'] or sha(src)!=before['sha256']:raise ValueError('Read-only copy race')
  sources.append(before);inputs.append(row(target));return target
 target=copy(source,shader_dir/source.name);target_meta=copy(meta,target.with_suffix('.asset.meta'))
 dependency_target=copy(dependency,shader_dir/dependency.name);dependency_target_meta=copy(dependency_meta,dependency_target.with_suffix('.asset.meta'))
 verifier=copy(HERE/'VerifyOriginalShaderImport.cs',editor_dir/'VerifyOriginalShaderImport.cs')
 protection=copy(helper,editor_dir/helper.name);copy(helper_meta,protection.with_suffix('.cs.meta'))
 verifier_meta=verifier.with_suffix('.cs.meta');verifier_meta.write_text('fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\nMonoImporter:\n  externalObjects: {}\n  serializedVersion: 2\n  defaultReferences: []\n  executionOrder: 0\n  icon: {instanceID: 0}\n  userData:\n  assetBundleName:\n  assetBundleVariant:\n');inputs.append(row(verifier_meta))
 settings=project/'ProjectSettings';settings.mkdir();version=settings/'ProjectVersion.txt';version.write_text('m_EditorVersion: 2020.3.33f1\n');inputs.append(row(version))
 packages=project/'Packages';packages.mkdir();manifest=packages/'manifest.json';manifest.write_text('{"dependencies":{}}\n');inputs.append(row(manifest))
 model=json.loads((PROBE/'Object/report.json').read_text());fields=model['fields'];form=field_lines(PROBE/'Object/ParsedForm.yaml','m_ParsedForm')
 masks=[]
 for line in form:
  if line.lstrip().startswith('m_GlobalKeywordMask:'):
   raw=bytes.fromhex(line.split(':',1)[1].strip());masks.append({'values':[x[0] for x in struct.iter_unpack('<H',raw)]})
 if len(masks)!=7:raise ValueError('Expected seven original native masks')
 relative=lambda p:p.relative_to(project).as_posix()
 vector=lambda rows:[{'values':r} for r in rows]
 config={'asset_path':relative(target),'expected_name':model['actual_name'],'expected_guid':guid(target_meta),'expected_asset_sha256':sha(target),'expected_meta_sha256':sha(target_meta),
  'dependency_path':relative(dependency_target),'dependency_guid':guid(dependency_target_meta),'dependency_sha256':sha(dependency_target),'dependency_meta_sha256':sha(dependency_target_meta),
  'expected_blob_bytes':fields['compressedBlob']['bytes'],'expected_blob_sha256':fields['compressedBlob']['sha256'],
  'expected_properties':18,'expected_subshaders':1,'expected_passes':7,'expected_subprograms':298,
  'platforms':fields['Platforms'],'offsets':vector(fields['Offsets_AssetList_AssetList_UInt32']),
  'compressed_lengths':vector(fields['CompressedLengths_AssetList_AssetList_UInt32']),'decompressed_lengths':vector(fields['DecompressedLengths_AssetList_AssetList_UInt32']),
  'keyword_masks':masks}
 config_path=out/'expected-original-data.json';config_path.write_text(json.dumps(config,indent=2)+'\n');inputs.append(row(config_path))
 editor=EDITOR.parent;framework=editor/'Data/MonoBleedingEdge/lib/mono/unityjit'
 references=[framework/'mscorlib.dll',framework/'System.dll',framework/'System.Core.dll',editor/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',editor/'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll',editor/'Data/Managed/UnityEditor.dll']
 compiler=editor/'Data/Tools/Roslyn/csc.exe'
 if not all(p.is_file() for p in references+[compiler,EDITOR,CLI]):raise ValueError('Matching official Editor/CLI/compiler dependency absent')
 rsp=out/'verify-observer.rsp';output_assembly=out/'CompileCheck/VerifyOriginalShaderImport.dll'
 rsp.write_text('\n'.join(['/nologo','/noconfig','/nostdlib+','/target:library','/langversion:8','/out:"'+str(output_assembly)+'"']+['/reference:"'+str(p)+'"' for p in references]+['"'+str(verifier)+'"'])+'\n');inputs.append(row(rsp))
 runner=HERE/'run_original_shader_import_fixture.py'
 plan={'schema':'prepared-original-shader-import-fixture/v1','status':'prepared_not_compiled_or_launched','project':str(project),'fixture':str(out),
  'candidate_report':row(CANDIDATE/'report.json'),'candidate_readiness':row(CANDIDATE/'readiness.json'),
  'expected_data':row(config_path),'inputs':inputs,'read_only_sources':sources,
  'compiler':row(compiler),'editor':row(EDITOR),'cli':row(CLI),'compiler_references':[row(p) for p in references],
  'compiler_response':row(rsp),'compiler_output':str(output_assembly),'runner':row(runner),
  'planned_sessions':['import','reload'],'maximum_owned_job_bytes':1024**3,'minimum_system_commit_reserve_bytes':int(1.5*1024**3),
  'maximum_seconds_per_editor':300,'compile_check_executed':False,'Editor_launched':False,'Main_modified':False,
  'dependency_control':'Exact existing original FallbackError Shader plus its unchanged original meta; program blob is nonempty. No substitute shader.',
  'limitations':['No GPU render/backend support proof from batchmode-nographics.','Property layouts are required exactly; an unavailable native SerializedProperty is a failed/inconclusive gate, never a default.','Two fresh Editor processes are required for reload proof.','No Main application is performed by this fixture.']}
 (out/'plan.json').write_text(json.dumps(plan,indent=2)+'\n');print(json.dumps({'status':plan['status'],'plan':str(out/'plan.json'),'review_command':'python '+str(runner)+' --fixture "'+str(out)+'"','future_run_addition':'--run (only after root resource release)'}))
if __name__=='__main__':main()
