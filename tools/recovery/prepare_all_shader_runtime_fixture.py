"""Pure clone/source/179 identity plans after actual native relocation success."""
from pathlib import Path
import argparse,copy,datetime as dt,json,re,struct,sys,uuid
import map_shader_buildreport as native
import orchestrate_all_original_shader_restoration as context
import patch_original_shader_collection_with_external_relocation as patcher
import prepare_eight_original_shader_gpu_fixture as forms
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent;AR=context.AR
BASE=AR/'All179ShaderRelocationProposal-20261023T081208Z-59459633'
PATCH_PLAN=BASE/'original179-relocated-streaming-patch-plan.json'
PLAN_SHA='9bd95329b9bdb6be78a220f432dab14ae641b144445a8ce6018b1ec105728a8b'
PATCH_REPORT=BASE/'PatchedNativeFiles-v3/streaming-patch-report.json'
REPORT_SHA='f4575cc49f3b183ef643ca1d7a318bca1c6e447a2c9969badba7135b15b942de'
JOB_SHA='dde3cc51cb46654287fce0f75795a64c180f09f4c7c108999ea9e1ab15f66841'
PATCHER_SHA='62b39e2d5d273870bb43d4415f8840a91bd8b6e2f4bb5700a747b37289ef69eb'
OLD_GPU=AR/'EightOriginalShaderGPUFixture-20261023T071953Z-2d7c4232/gpu-probe-plan.json'
OLD_GPU_SHA='1107364721e1ac35433c31c179febff25457196cd8185472cde2cc92ced986a1'
STANDARD=AR/'BuiltStandardNativePassProof-20261023T072631Z-a314e61c'
STANDARD_SHA='26001bc3d0a61403c71fa6ef16f5df714e538f32cb7ab99c848eba98158ddaee'
need=context.need;pin=native.pin;save=context.save


def verify_patch():
    need(guard.sha(PATCH_PLAN)==PLAN_SHA and guard.sha(PATCH_REPORT)==REPORT_SHA
        and guard.sha(BASE/'PatchDiagnostics-v3/run-report.json')==JOB_SHA and guard.sha(Path(patcher.__file__))==PATCHER_SHA,'Exact actual native179 patch and reviewed sources')
    plan=json.loads(PATCH_PLAN.read_bytes());report=json.loads(PATCH_REPORT.read_bytes());job=json.loads((BASE/'PatchDiagnostics-v3/run-report.json').read_bytes())
    need(job['status']=='passed' and len(job['phases'])==1 and job['phases'][0]['exit_code']==0 and job['phases'][0]['launcher']['membership_verified_before_resume'],
        'Actual owned patch process success')
    need(report['plan']==pin(PATCH_PLAN) and report['tool']==pin(Path(patcher.__file__)) and report['Shader_count']==179
        and report['status']=='explicit_original_Shader_payloads_and_proven_external_metadata_data_relocation_streamed'
        and report['all_original_GPU_fields_unchanged_except_proved_dependency_PPtrs'],'Actual original179 payload/dependency patch receipt')
    player,containers,prepared=patcher.preflight(plan);need(len(containers)==1 and len(prepared)==179,'Exact single-container179 preflight')
    by_guid={r['guid']:r for r in prepared};found=set();pointers=0
    for result in report['containers']:
        source=patcher.checked(result['input']);output=patcher.checked(result['output']);container=containers[source];ext=container['metadata_extension']
        need(ext is not None and result['metadata_relocation']==ext['proof'],'Actual new namespace/data relocation equals source-derived proof')
        after,layout,table_start=patcher.metadata(output);delta=ext['delta'];expected_metadata=bytearray(ext['bytes'])
        need(layout['data_start']==ext['new_data_start'] and table_start==container['table_start'],'Exact relocated data/table boundaries')
        hashes=patcher.compare_shifted_data(source,output,ext['old_data_start'],ext['new_data_start'],result['whole_original_data_section_bytes'])
        need(hashes==result['whole_original_data_section_sha256'] and result['every_original_data_byte_exact_at_recorded_positive_shift'],
            'Independently recomputed every original data byte at exact recorded shift')
        expected_rows={}
        for item in result['objects']:
            need(item['guid'] not in found and item['guid'] in by_guid,'One unique exact original output object');found.add(item['guid']);row=by_guid[item['guid']]
            original=patcher.checked(row['source']).read_bytes();data=bytearray(original)
            for offset,file_id,path_id in row['edits']:struct.pack_into('<iq',data,offset,file_id,path_id)
            need(item['source_sha256']==native.digest(original) and item['mapped_payload_sha256']==native.digest(data)
                and item['typed_PPtr_edits']==[{'offset':o,'file_id':f,'path_id':str(p)} for o,f,p in row['edits']],
                'Every actual appended object equals full original plus only explicit typed words')
            obj=next(o for o in after['objects'] if str(o['path_id'])==item['path_id']);expected_rows[obj['path_id']]=obj
            need(obj['offset']==int(item['new_absolute_offset']) and obj['size']==len(data),'Exact mapped native table range')
            with output.open('rb') as f:f.seek(obj['offset']);actual=f.read(obj['size'])
            need(actual==data,'Whole persisted original program/ParsedForm/dependency payload readback')
            table=container['table_start']+24*row['table_index']+8
            expected_metadata[table:table+12]=struct.pack('<qI',obj['offset']-ext['new_data_start'],obj['size']);pointers+=len(row['edits'])
        for old,obj in zip(container['parsed']['objects'],after['objects']):
            if old['path_id'] not in expected_rows:
                expected=dict(old);expected['offset']+=delta;need(expected==obj,'All nontarget relative words/type/ID exact at explicit delta')
        with output.open('rb') as f:
            actual_header=f.read(48);actual_metadata=f.read(len(expected_metadata));old_gap=f.read(len(ext['old_gap']));new_zeros=f.read(ext['extra_zero_padding'])
        header=bytearray(ext['old_header']);struct.pack_into('>Iqq',header,20,len(expected_metadata),result['output']['bytes'],ext['new_data_start'])
        need(actual_header==header and actual_metadata==expected_metadata and old_gap==ext['old_gap'] and new_zeros==bytes(ext['extra_zero_padding']),
            'Entire actual header/metadata/gap derived exactly from old bytes and listed edits')
    need(found==set(context.canonical_guids()) and pointers==104,'Every actual original179 payload and104 pointers required')
    return plan,report,player


def source_facts(row):
    candidates=[p for p in row['proofs'] if p['sha256']==row['expected_ParsedForm_sha256']]
    need(len(candidates)==1,'One exact original ParsedForm authority');form=candidates[0]
    try:fact=forms.form_facts(form)
    except ValueError:
        # Explicit empty-subshader layout is valid original data. It is never
        # assigned an invented supported pass count in the structural probe.
        context.check(form);lines=Path(form['path']).read_text(encoding='utf-8').splitlines()
        need(lines[:3]==['%YAML 1.1','%TAG !u! tag:unity3d.com,2011:','--- m_ParsedForm:'] and lines.count('  m_SubShaders: []')==1,
            'Only exact original empty subshader extension supported')
        begin=lines.index('  m_SubShaders: []');props=[s[len('    - m_Name: '):] for s in lines[:begin] if s.startswith('    - m_Name: ')]
        need(all(re.fullmatch('[A-Za-z_][A-Za-z_0-9]*',s) for s in props),'Original property identifiers')
        def scalar(prefix):
            values=[s[len(prefix):].strip() for s in lines if s.startswith(prefix)];need(len(values)==1,'Unique exact root scalar');return values[0] or None
        fact={'source_ParsedForm':form,'name':scalar('  m_Name:'),'property_names':props,'property_count':len(props),'subshaders':[],'fallback_name':scalar('  m_FallbackName:'),'count_reader':'Exact empty-subshader generated layout; no invented pass count'}
    need(fact['name']==row['name'],'Original typed name/ParsedForm agreement');fact['guid']=row['guid'];return fact


def prepare(out):
    patch_plan,report,player=verify_patch();canonical=json.loads(context.check(patch_plan['canonical_manifest']).read_bytes());rows={r['guid']:r for r in canonical['shaders']}
    facts=[source_facts(row) for row in canonical['shaders']];need(len(facts)==179,'All original179 property authorities')
    save(out/'original179-structural-source-facts.json',facts)
    builtins=patcher.load_builtin_targets(patch_plan,player);standard=builtins['46'];standard_file=patcher.checked(standard['container'])
    patcher.read_object(standard_file,standard,48,8*1024**2)
    with standard_file.open('rb') as stream:stream.seek(int(standard['absolute_offset']));raw=stream.read(int(standard['byte_size']))
    need(guard.sha(STANDARD/'native-vs-Editor-pass-layout.json')==STANDARD_SHA,'Prior full native Standard typed count proof')
    native_standard=json.loads((STANDARD/'native-vs-Editor-pass-layout.json').read_bytes());context.check(native_standard['native_model_report'])
    proof=json.loads(Path(native_standard['native_model_report']['path']).read_bytes())
    need(standard['raw_sha256']==native.digest(raw)=='a4cf9cf5b038d7d16aaf19fb9216206033f642cc4faf6795f07bdc63cca89537'
        and proof['consumed_bytes']==proof['total_bytes']==len(raw)==56648 and native_standard['first_native_subshader_pass_count']==4,
        'Actual new Material-resolved native Standard payload byte-identical to fully typed consumed source, no old ID inference')
    save(out/'actual-new-builtin46-pass-proof.json',{'schema':'new179-build-builtin46-whole-byte-identity-typed-count-transfer/v1','status':'exact_new_Class21_target_bytes_equal_full_typed_native_standard',
        'actual_new_builtin_target':standard,'actual_new_Material_mapping':patch_plan['builtin_material_mapping_report'],'whole_payload_bytes':len(raw),'whole_payload_sha256':native.digest(raw),
        'full_native_typed_model':native_standard['native_model_report'],'native_pass_layout':pin(STANDARD/'native-vs-Editor-pass-layout.json'),'subshader_pass_counts':[4,3],
        'old_native_pathID_or_offset_reused':False,'GPU_observation_used_to_set_count':False})
    need(guard.sha(OLD_GPU)==OLD_GPU_SHA,'Frozen exact8 original source case expectations')
    old_cases=json.loads(OLD_GPU.read_bytes())['cases'];cases=copy.deepcopy(old_cases)
    need(tuple(r['guid'] for r in cases)==context.projection.GUIDS,'Exact8 established source identities')
    for case in cases:
        row=rows[case['guid']];need(case['name']==row['name'] and case['ParsedForm']['sha256']==row['expected_ParsedForm_sha256'],'Same original property/pass authority in new179 collection')
        if case['guid']=='dbe0ca40b3618e44e9ef2664c6daae98':
            case['expected_pass_count']=4;case['pass_count_source']={'kind':'actual_new_Material_proved_builtin46_bytes_equal_full_typed_native','proof':pin(out/'actual-new-builtin46-pass-proof.json')}
    save(out/'eight-GPU-cases.json',cases)
    cloned=out/'Player';cloned.mkdir();inventory=[];replacements={Path(r['input']['path']).resolve():r for r in report['containers']}
    sources=sorted(p for p in player.rglob('*') if p.is_file());need(len(sources)<=1024 and sum(p.stat().st_size for p in sources)<=2*1024**3,'Bounded whole diagnostic player clone')
    for source in sources:
        guard.safety.assert_no_reparse(source);original=pin(source);replacement=replacements.get(source.resolve());copy_from=source if replacement is None else patcher.checked(replacement['output'])
        target=cloned/source.relative_to(player);target.parent.mkdir(parents=True,exist_ok=True)
        with copy_from.open('rb') as a,target.open('xb') as b:
            while chunk:=a.read(1024**2):b.write(chunk)
        actual=pin(target);expected=pin(copy_from);need(actual['bytes']==expected['bytes'] and actual['sha256']==expected['sha256'] and pin(source)==original,'Whole exact fresh clone and read-only original')
        inventory.append({'relative_path':source.relative_to(player).as_posix(),'original':original,'clone':actual,'native_container_restored':replacement is not None})
    save(out/'preinstrumentation-clone-inventory.json',inventory)
    batches=[]
    for index in range(0,179,32):
        selected=[]
        for fact in facts[index:index+32]:
            pipeline=fact['subshaders'][0]['pipeline_tag'] if fact['subshaders'] else None
            selected.append({'guid':fact['guid'],'resource_key':'OriginalShaders/'+fact['guid'],'name':fact['name'],'expected_property_count':fact['property_count'],
                'expected_property_names':fact['property_names'],'pipeline_tag_argument':forms.URP_TAG if pipeline=='UniversalPipeline' else 'unchanged'})
        path=out/('load-batch-'+str(index//32).zfill(2)+'.json');save(path,{'schema':'explicit-original-Shader-structural-load-batch-input/v1','shaders':selected});batches.append(pin(path))
    need(sum(len(json.loads(Path(p['path']).read_bytes())['shaders']) for p in batches)==179 and len(batches)==6,'Exactly six disjoint explicit batches cover179')
    managed=cloned/'AllOriginalShaderNullDependencyDiagnostic_Data/Managed';data=managed.parent
    init=json.loads((data/'RuntimeInitializeOnLoads.json').read_bytes());assemblies=json.loads((data/'ScriptingAssemblies.json').read_bytes())
    need(init['root']==[{'assemblyName':'Assembly-CSharp','nameSpace':'','className':'OriginalShaderRuntimeProbe','methodName':'StartProbe','loadTypes':0,'isUnityClass':False}]
        and 'Assembly-CSharp.dll' in assemblies['names'],'Actual same native runtime registration by assembly/class/method name')
    compile_dir=out/'CompiledDiagnostic';compile_dir.mkdir();editor=guard.EDITOR.parent;framework=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'
    references=[framework/n for n in ('mscorlib.dll','System.dll','System.Core.dll')]+[managed/n for n in ('UnityEngine.dll','UnityEngine.CoreModule.dll','UnityEngine.AssetBundleModule.dll','UnityEngine.JSONSerializeModule.dll')]
    sources=[HERE/'OriginalShaderRuntimeProbeWithLoadBatches.cs',HERE/'OriginalShaderLoadBatchProbe.cs']
    need(guard.sha(HERE/'OriginalShaderRuntimeProbeWithPipelineTag.cs')==forms.RUNTIME_SHA,'Frozen existing GPU harness')
    text=sources[0].read_text();old=(HERE/'OriginalShaderRuntimeProbeWithPipelineTag.cs').read_text()
    injection='        if (OriginalShaderLoadBatchProbe.IsRequested()) { OriginalShaderLoadBatchProbe.Begin(); return; }\n'
    need(text.count(injection)==1 and text.replace(injection,'')==old,'Default GPU source preserved completely except explicit batch dispatch')
    response=out/'diagnostic-assembly.rsp';response.write_text('/nologo\n/nostdlib+\n/target:library\n/langversion:8.0\n/debug:portable\n/optimize+\n/out:"'+str(compile_dir/'Assembly-CSharp.dll')+'"\n/pdb:"'+str(compile_dir/'Assembly-CSharp.pdb')+'"\n'+''.join('/reference:"'+str(r)+'"\n' for r in references)+''.join('"'+str(s)+'"\n' for s in sources),encoding='utf-8',newline='\n')
    plan={'schema':'actual-restored179-Shader-structural-and-eight-GPU-runtime-preparation/v1','status':'prepared_original_native_clone_ROOT_diagnostic_compile_required','fixture':str(out),
        'runner':pin(HERE/'run_all_shader_runtime_probes.py'),'preparer':pin(Path(__file__)),'guard':pin(Path(guard.__file__)),'launcher':pin(HERE/'owned_suspended_launch.py'),
        'native_patch_plan':pin(PATCH_PLAN),'actual_native_patch_report':pin(PATCH_REPORT),'native_owned_patch_receipt':pin(BASE/'PatchDiagnostics-v3/run-report.json'),
        'source_player_root':str(player),'player_root':str(cloned),'player':pin(cloned/'AllOriginalShaderNullDependencyDiagnostic.exe'),'source_project':str(context.FIXTURE/'Project'),
        'preinstrumentation_inventory':pin(out/'preinstrumentation-clone-inventory.json'),'source_facts':pin(out/'original179-structural-source-facts.json'),
        'actual_new_Standard_pass_proof':pin(out/'actual-new-builtin46-pass-proof.json'),'GPU_cases':pin(out/'eight-GPU-cases.json'),'load_batches':batches,
        'runtime_registration':pin(data/'RuntimeInitializeOnLoads.json'),'scripting_assemblies':pin(data/'ScriptingAssemblies.json'),
        'compile_sources':[pin(p) for p in sources],'compile_references':[pin(p) for p in references],'compiler':pin(editor/'Data/Tools/Roslyn/csc.exe'),'compile_response':pin(response),
        'compiled_diagnostic_directory':str(compile_dir),'diagnostic_managed_replacements':['AllOriginalShaderNullDependencyDiagnostic_Data/Managed/Assembly-CSharp.dll','AllOriginalShaderNullDependencyDiagnostic_Data/Managed/Assembly-CSharp.pdb'],
        'compiler_cap_bytes':256*1024**2,'runtime_cap_bytes':6*1024**3,'reserve_bytes':int(1.5*1024**3),'compile_deadline_seconds':30,'runtime_deadline_seconds_each':90,
        'expected_structural_shader_count':179,'expected_batches':6,'expected_GPU_Shader_cases':8,'Main_modified':False,'compiler_Unity_managed_reader_player_network_launched':False,
        'limitations':['Only the fresh diagnostic clone receives a compiled diagnostic Assembly-CSharp DLL/PDB; its actual RuntimeInitialize/ScriptingAssemblies JSON remain exact.','All179 structural probes require exact original names/properties and0native/Shader/CB errors; supported flags are reported separately and no drawing is attempted in that mode.','Eight GPU cases require true support/pass0/readback and source/native-derived counts. TerrainLit remains its original FallbackError rendering.','No original gamecode, full URP renderer, startup/login or full scene visual fidelity is tested.']}
    path=out/'plan.json';save(path,plan);print(json.dumps({'status':plan['status'],'plan':pin(path),'batch_count':6,'original_Shader_count':179,'GPU_cases':8,
        'Root_next_command':[sys.executable,'-B',str(HERE/'run_all_shader_runtime_probes.py'),'--plan',str(path),'--plan-sha256',guard.sha(path),'--compile-diagnostic']}))


def main():
    ap=argparse.ArgumentParser(description=__doc__);ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);args=ap.parse_args()
    if args._worker:return prepare(args._worker.resolve(strict=True))
    out=AR/('All179OriginalShaderRuntimeFixture-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    receipt={'schema':'guarded-pure179-restored-native-runtime-preparation/v1','status':'starting','phases':[],'Main_modified':False,'compiler_Unity_managed_reader_player_network_launched':False}
    try:guard.bounded([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],guard.WS,out,'pure179-native-integrity-source-expectations-and-diagnostic-clone',512*1024**2,180,receipt);receipt['status']='passed'
    except BaseException as error:receipt.update(status='held',error=repr(error))
    guard.save(out,receipt);print(json.dumps({'status':receipt['status'],'receipt':pin(out/'run-report.json'),'error':receipt.get('error')}));return 0 if receipt['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
