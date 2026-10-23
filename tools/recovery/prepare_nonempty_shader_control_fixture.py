"""Stage only: genuine nonempty Shader readback control; never launch Unity."""
from pathlib import Path
import datetime as dt, hashlib, json, re, shutil, struct, uuid
from compare_shader_parsed_form import field_lines
from stage_original_stencil_shader import spans

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS/'Recovery/RecRoom-2023-04-18'
SOURCE = WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_SubpixelMorphologicalAntialiasing.asset'
SOURCE_SHA = '79db2e11def4e0928f62e8ff36548771bf16b32d2ddf7edf9f4ae46002841509'
BASE_OBSERVER_SHA = 'f768aa9cd21a97d36a1f09737d5a653de1f1c6d264d45e2551d88764cfb316b1'
BASE_RUNNER_SHA = 'cdff379ff9b128ef745304a39c790a3c10d78bb3d7847c50ee87af05a3975bca'
EDITOR = WS/'Tools/Editors/2020.3.33f1/Editor/Unity.exe'
CLI = Path('C:/Users/andre/AppData/Local/Unity/bin/unity.exe')

def need(value, message):
    if not value: raise ValueError(message)
def sha(path):
    with Path(path).open('rb') as stream: return hashlib.file_digest(stream, 'sha256').hexdigest()
def record(path):
    return {'path':str(path.resolve()), 'sha256':sha(path), 'bytes':path.stat().st_size}
def write(path, text): path.write_bytes(text.encode('utf-8'))
def replace_once(text, old, new):
    need(text.count(old)==1, 'Exact source anchor: '+old[:85]); return text.replace(old,new)
def guid(path):
    hits=re.findall(rb'(?m)^guid: ([0-9a-f]{32})\s*$',path.read_bytes())
    need(len(hits)==1,'Exact existing meta GUID'); return hits[0].decode()
def ints(text, code):
    data=bytes.fromhex(text.strip()); width=struct.calcsize(code)
    need(len(data)%width==0,'Primitive element width'); return [item[0] for item in struct.iter_unpack('<'+code,data)]

def main():
    need(sha(SOURCE)==SOURCE_SHA,'Genuine current nonempty control source changed')
    observer=HERE/'VerifyOriginalShaderImport.cs'; runner=HERE/'run_original_shader_import_fixture.py'
    need(sha(observer)==BASE_OBSERVER_SHA and sha(runner)==BASE_RUNNER_SHA,'Reviewed base observer/runner changed')
    raw=SOURCE.read_bytes(); fieldspans=spans(raw); form=field_lines(SOURCE,'m_ParsedForm')
    need(raw.count(b'm_IsPartialCB: 1')==0,'Control must have no partialCB flags')
    need(raw[fieldspans['m_Dependencies'][0]:fieldspans['m_Dependencies'][1]].strip()==b'm_Dependencies: []','Control dependencies must be empty')
    field=lambda name:raw[slice(*fieldspans[name])].decode().splitlines()
    platform=ints(field('platforms')[0].split(':',1)[1],'I')
    matrices={name:[ints(line.strip()[2:],'I') for line in field(name)[1:]] for name in ('offsets','compressedLengths','decompressedLengths')}
    blob=bytes.fromhex(field('compressedBlob')[0].split(':',1)[1].strip())
    need(0<len(blob)<=256*1024,'Nonempty bounded existing blob')
    need(len(platform)==len(matrices['offsets'])==len(matrices['compressedLengths'])==len(matrices['decompressedLengths']),'Program array platform dimensions')
    for offsets, compressed, decompressed in zip(matrices['offsets'],matrices['compressedLengths'],matrices['decompressedLengths']):
        need(len(offsets)==len(compressed)==len(decompressed),'Program segment dimensions')
        need(all(off+length<=len(blob) for off,length in zip(offsets,compressed)),'Blob compressed ranges')
    starts=[i for i,line in enumerate(form) if line.startswith('    - m_EditorDataHash:')]
    passes=[]
    for begin,end in zip(starts,starts[1:]+[len(form)]):
        lines=form[begin:end]
        local=[line for line in lines if line.startswith('      m_LocalKeywordMask:')]
        global_=[line for line in lines if line.startswith('      m_GlobalKeywordMask:')]
        need(len(local)==len(global_)==1,'Exact per-pass local/global mask fields')
        at=lines.index('      m_NameIndices:'); entries=[]
        for line in lines[at+1:]:
            if not line.startswith('        '):break
            key,value=line.strip().rsplit(': ',1); entries.append({'name':key,'value':int(value)})
        states=[i for i,line in enumerate(lines) if line=='      m_State:'];need(len(states)==1,'One native pass state')
        names=[line.split(':',1)[1].strip() for line in lines[states[0]+1:] if line.startswith('        m_Name:')]
        need(len(names)==1,'One native pass name')
        passes.append({'name':names[0],'local_mask':ints(local[0].split(':',1)[1],'H'),'global_mask':ints(global_[0].split(':',1)[1],'H'),'name_indices':entries})
    need(len(passes)==3 and all(p['local_mask'] and p['global_mask'] and p['name_indices'] for p in passes),'Exact nonempty local/global/name-index control')
    counts={'properties':sum(line.startswith('    - m_Name:') for line in form),
        'subshaders':sum(line.startswith('  - m_Passes:') for line in form),'passes':len(passes),
        'subprograms':sum(line.lstrip().startswith('m_BlobIndex:') for line in form)}
    # Independently compare stock LE hex output to explicit numeric sequences.
    # This establishes logical equivalence only, not what Unity will accept.
    checks=[]
    for name,values,code in [('platforms',platform,'I')]+[(name+'['+str(i)+']',v,'I') for name,rows in matrices.items() for i,v in enumerate(rows)]+[(kind+'['+str(i)+']',p[kind],'H') for i,p in enumerate(passes) for kind in ('local_mask','global_mask')]:
        packed=b''.join(struct.pack('<'+code,value) for value in values)
        sequence='\n'.join('- '+str(value) for value in values)
        reread=[int(line[2:]) for line in sequence.splitlines()]
        need(reread==values and ints(packed.hex(),code)==values,'Independent primitive encodings disagree')
        checks.append({'field':name,'element_type':'UInt32' if code=='I' else 'UInt16','values':values,'stock_LE_hex':packed.hex(),'explicit_numeric_sequence':sequence,'typed_values_identical':True})
    out=ROOT/'AssetRecovery'/('OriginalKnownNonemptyShaderControl-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    project=out/'Project';shaderdir=project/'Assets/Shader';editordir=project/'Assets/Editor';shaderdir.mkdir(parents=True);editordir.mkdir()
    inputs=[];sources=[]
    def copy(source,target):
        before=record(source);shutil.copyfile(source,target)
        need(sha(source)==sha(target)==before['sha256'],'Read-only source copy race')
        sources.append(before);inputs.append(record(target));return target
    target=copy(SOURCE,shaderdir/SOURCE.name);meta=copy(SOURCE.with_suffix('.asset.meta'),target.with_suffix('.asset.meta'))
    dependency=WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_FallbackError.asset'
    dep=copy(dependency,shaderdir/dependency.name);depmeta=copy(dependency.with_suffix('.asset.meta'),dep.with_suffix('.asset.meta'))
    helper=WS/'RR23/Assets/Editor/AssetRipperPatches/AvoidSavingYamlShaders.cs'
    need(sha(helper)=='cdf4cd167fb80b36631476c23214c1321e4e24052613e73394982ddcab452cde','Original save protection drift')
    copy(helper,editordir/helper.name);copy(helper.with_suffix('.cs.meta'),editordir/helper.with_suffix('.cs.meta').name)
    text=observer.read_text()
    text=replace_once(text,'public Vector[] offsets, compressed_lengths, decompressed_lengths, keyword_masks;','public Vector[] offsets, compressed_lengths, decompressed_lengths, keyword_masks;\n        public ExpectedPass[] expected_pass_data;')
    text=replace_once(text,'    [Serializable] public class Message','    [Serializable] public class ExpectedIndex { public string name; public int value; }\n    [Serializable] public class ExpectedPass { public string name; public int[] local_mask, global_mask; public ExpectedIndex[] name_indices; }\n    [Serializable] public class ObservedIndex { public string name; public int value; public bool found; }\n    [Serializable] public class Message')
    text=replace_once(text,'        public int[] keyword_mask;','        public int[] keyword_mask, local_keyword_mask;\n        public ObservedIndex[] name_indices;')
    text=replace_once(text,'Require(rows <= 100000, "Native ParsedForm property walk bound");','Require(rows <= 1000000, "Native ParsedForm property walk bound");')
    anchor='                row.fog_exp_found = NameIndex(indices, "FOG_EXP", out row.fog_exp_index);'
    addition='''                row.local_keyword_mask = Integers(Child(pass, "m_LocalKeywordMask"));
                Require(passes.Count < config.expected_pass_data.Length, "Unexpected native pass count");
                var expectedIndices = config.expected_pass_data[passes.Count].name_indices;
                row.name_indices = new ObservedIndex[expectedIndices.Length];
                for (int index = 0; index < expectedIndices.Length; index++)
                {
                    int value; bool found = NameIndex(indices, expectedIndices[index].name, out value);
                    row.name_indices[index] = new ObservedIndex { name = expectedIndices[index].name, value = value, found = found };
                }
'''+anchor
    text=replace_once(text,anchor,addition)
    old='        Require(value.passes[5].fog_exp_found && value.passes[5].fog_exp_index == 4 && value.passes[5].fog_exp2_found && value.passes[5].fog_exp2_index == 5, "Original FOG keyword indices changed");'
    new='''        Require(value.passes.Length == config.expected_pass_data.Length, "Expected pass data count");
        for (int i = 0; i < value.passes.Length; i++)
        {
            var actual = value.passes[i]; var expected = config.expected_pass_data[i];
            Require(actual.name == expected.name, "Original pass name changed in pass " + i);
            Require(Equal(actual.local_keyword_mask, expected.local_mask) && Equal(actual.keyword_mask, expected.global_mask), "Original local/global masks changed in pass " + i);
            Require(actual.name_indices.Length == expected.name_indices.Length, "Name index count " + i);
            for (int k = 0; k < actual.name_indices.Length; k++)
                Require(actual.name_indices[k].found && actual.name_indices[k].name == expected.name_indices[k].name && actual.name_indices[k].value == expected.name_indices[k].value, "Original name index changed in pass " + i + ":" + expected.name_indices[k].name);
        }'''
    text=replace_once(text,old,new)
    text=replace_once(text,'isolated-original-shader-import-verification/v1','genuine-nonempty-shader-readback-control/v1')
    source=editordir/'VerifyOriginalShaderImport.cs';write(source,text);inputs.append(record(source))
    sourcemeta=source.with_suffix('.cs.meta');write(sourcemeta,'fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\nMonoImporter:\n  externalObjects: {}\n  serializedVersion: 2\n  defaultReferences: []\n  executionOrder: 0\n  icon: {instanceID: 0}\n  userData:\n  assetBundleName:\n  assetBundleVariant:\n');inputs.append(record(sourcemeta))
    settings=project/'ProjectSettings';settings.mkdir();version=settings/'ProjectVersion.txt';write(version,'m_EditorVersion: 2020.3.33f1\n');inputs.append(record(version))
    packages=project/'Packages';packages.mkdir();manifest=packages/'manifest.json';write(manifest,'{"dependencies":{}}\n');inputs.append(record(manifest))
    name=re.findall(rb'(?m)^  m_Name: (.*)\r?$',raw)[0].decode().strip()
    vector=lambda rows:[{'values':values} for values in rows]
    config={'asset_path':target.relative_to(project).as_posix(),'expected_name':name,'expected_guid':guid(meta),'expected_asset_sha256':sha(target),'expected_meta_sha256':sha(meta),
        'dependency_path':dep.relative_to(project).as_posix(),'dependency_guid':guid(depmeta),'dependency_sha256':sha(dep),'dependency_meta_sha256':sha(depmeta),
        'expected_blob_bytes':len(blob),'expected_blob_sha256':hashlib.sha256(blob).hexdigest(),
        'expected_properties':counts['properties'],'expected_subshaders':counts['subshaders'],'expected_passes':counts['passes'],'expected_subprograms':counts['subprograms'],
        'platforms':platform,'offsets':vector(matrices['offsets']),'compressed_lengths':vector(matrices['compressedLengths']),'decompressed_lengths':vector(matrices['decompressedLengths']),
        'keyword_masks':vector([p['global_mask'] for p in passes]),'expected_pass_data':passes}
    configpath=out/'expected-control-data.json';write(configpath,json.dumps(config,indent=2)+'\n');inputs.append(record(configpath))
    editor=EDITOR.parent;framework=editor/'Data/MonoBleedingEdge/lib/mono/unityjit'
    refs=[framework/'mscorlib.dll',framework/'System.dll',framework/'System.Core.dll',editor/'Data/Managed/UnityEngine/UnityEngine.dll',editor/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',editor/'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll',editor/'Data/Managed/UnityEditor.dll']
    compiler=editor/'Data/Tools/Roslyn/csc.exe';need(all(p.is_file() for p in refs+[compiler,EDITOR,CLI]),'Matching modular references missing')
    rsp=out/'verify-observer.rsp';assembly=out/'CompileCheck/VerifyOriginalShaderImport.dll'
    write(rsp,'\n'.join(['/nologo','/noconfig','/nostdlib+','/target:library','/langversion:8','/out:"'+str(assembly)+'"']+['/reference:"'+str(p)+'"' for p in refs]+['"'+str(source)+'"'])+'\n');inputs.append(record(rsp))
    runtext=runner.read_text();runtext=replace_once(runtext,"fixture.name.startswith('OriginalStencilImportFixture-')","fixture.name.startswith('OriginalKnownNonemptyShaderControl-')")
    runtext=runtext.replace('two_session_original_shader_import_and_retention_passed','two_session_known_nonempty_shader_control_passed')
    runpath=out/'run-control-fixture.py'
    # Keep helper resolution fixed to the reviewed workspace tool directory,
    # since this fresh runner snapshot lives outside that directory.
    runtext=replace_once(runtext,"HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'","HERE=Path("+repr(str(HERE))+");WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE))")
    write(runpath,runtext)
    cross=out/'primitive-encoding-crosscheck.json';write(cross,json.dumps({'schema':'typed-stock-YAML-primitive-encoding-crosscheck/v1','status':'logical_values_identical_Unity_acceptance_untested','checks':checks,'blob_hex_decoded_sha256':hashlib.sha256(blob).hexdigest(),'sequence_variant_asset_created':False,'stock_writer_sources':[record(WS/'AR23Tool/Source/Source/AssetRipper.Export.UnityProjects/YamlWalker.cs'),record(WS/'AR23Tool/Source/Source/AssetRipper.Yaml/YamlScalarNode.NumericListNode.cs'),record(WS/'AR23Tool/Source/Source/AssetRipper.Yaml/Extensions/ReverseHexString.cs')]},indent=2)+'\n')
    evidence={'schema':'prepared-genuine-nonempty-shader-readback-control/v1','status':'source_and_plan_only_not_compiled_or_launched',
        'source':record(SOURCE),'source_meta':record(SOURCE.with_suffix('.asset.meta')),'name':name,'counts':counts,'blob_bytes':len(blob),'blob_sha256':config['expected_blob_sha256'],'partial_CB_rows':0,
        'existing_Shader_is_not_yet_a_proven_rendering_positive_control':True,'rationale':'Genuine current Shader with nonempty existing serialized program fields, three nonempty local/global masks and name-index maps. None of the zero-partialCB Shader assets had a blob near200KiB; this bounded11341byte source is the largest zero-partialCB candidate found.',
        'input_shader_and_meta_bytes_unchanged':True,'control_expected_data':record(configpath),'encoding_crosscheck':record(cross),'observer_base':record(observer),'runner_base':record(runner),
        'strict_assertions':'All existing program byte/hash/arrays/counts/GUID/meta/save/reload assertions retained. Replaces Stencil-specific FOG constants with exact control pass local/global masks and every existing name-index value. Does not alter frozen failed observer/plan/receipt.',
        'limitations':['A zero readback can reflect import failure, YAML decoding, or post-load internal consumption; this test alone cannot distinguish those causes.','Known serialized nonempty control has no prior GPU rendering proof.','No GPU rendering or original shader restoration is claimed.','No Main mutation, Editor/compiler launch, cloud or native object execution performed.'],
        'tool':record(Path(__file__))}
    provenance=out/'control-provenance.json';write(provenance,json.dumps(evidence,indent=2)+'\n')
    readiness=out/'control-readiness.json';write(readiness,json.dumps({'status':'prepared_not_compiled_or_launched','source_pins':[record(provenance),record(source),record(cross)]},indent=2)+'\n')
    plan={'schema':'prepared-original-shader-import-fixture/v1','status':'prepared_not_compiled_or_launched','project':str(project),'fixture':str(out),
        'candidate_report':record(provenance),'candidate_readiness':record(readiness),'expected_data':record(configpath),'inputs':inputs,'read_only_sources':sources,
        'compiler':record(compiler),'editor':record(EDITOR),'cli':record(CLI),'compiler_references':[record(p) for p in refs],'compiler_response':record(rsp),'compiler_output':str(assembly),'runner':record(runpath),
        'launcher_helper':record(HERE/'owned_suspended_launch.py'),'launcher_probe_report':record(ROOT/'AssetRecovery/OwnedSuspendedLaunchProbe-20261022T195802Z-d6865f06/report.json'),
        'planned_sessions':['import','reload'],'maximum_owned_job_bytes':1024**3,'minimum_system_commit_reserve_bytes':int(1.5*1024**3),'maximum_seconds_per_editor':300,
        'compile_check_executed':False,'Editor_launched':False,'Main_modified':False,
        'auxiliary_shader':'Exact genuine FallbackError Shader/meta copied solely as the original verifier auxiliary Shader resolution control. SMAA has no Shader dependencies; no shader substitution occurs.',
        'limitations':evidence['limitations']}
    planpath=out/'plan.json';write(planpath,json.dumps(plan,indent=2)+'\n')
    need(sha(SOURCE)==SOURCE_SHA and sha(observer)==BASE_OBSERVER_SHA and sha(runner)==BASE_RUNNER_SHA,'Read-only source drift during stage')
    print(json.dumps({'status':plan['status'],'plan':record(planpath),'runner':record(runpath),'observer':record(source),'source_counts':counts,'control_blob_bytes':len(blob),'review_command':'C:\\Python314\\python.exe -B "'+str(runpath)+'" --fixture "'+str(out)+'"','future_run_addition':'--run only after root explicit authorization/resource release'}))

if __name__=='__main__': main()
