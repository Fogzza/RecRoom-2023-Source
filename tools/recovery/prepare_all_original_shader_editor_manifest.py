"""Resolve179 original Shader inputs for later reviewed pure conversion.

Read-only original/Main validation. Writes only a fresh AssetRecovery directory;
never invokes Unity, a compiler, the managed converter, or game/native APIs.
"""
from pathlib import Path
import datetime as dt, hashlib, json, re, struct, sys, uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
ASSETS=ROOT/'AssetRecovery';VERIFIED=ROOT/'VerifiedSource/RecRoom_Data';MAIN=WS/'RR23/Assets/Shader'
CLOSURE=ASSETS/'AllOriginalShaderDependencyClosure-20261023T031117Z-132fb863/report.json'
COVERAGE=ASSETS/'AllOriginalShaderCoverage-v3-20261023T030801Z-3f3c3f65/report.json'
BUILTINS=ASSETS/'OriginalShaderBuiltinAliasClosure-20261023T031252Z-86706dee/report.json'
EDITOR=ASSETS/'GenuineEditorBuiltinShaderIdentities-20261023T031035Z-a16ac0b1/run-report.json'
GUID_CAPTURE=ASSETS/'RuntimeShaderProofSupplement-20261023T024917Z-26d72acf/genuine-Editor-GUID-remap-proof.json'
REGRESSION=ASSETS/'OriginalShaderCollectionEditorConversion-20261023T030625Z-b13c1f0d/Run-20261023T030746Z-8f5c6471/run-report.json'
RESUME=ROOT/'IncidentCheckpoints/DecompResumeReadOnly-v2-20261023T043712Z-048db677.json'
CS=HERE/'ConvertOriginalShaderCollectionToEditor.cs';SERIALIZER=WS/'AR23Tool/Source/Source/AssetRipper.IO.Files/SerializedFiles/Parser/EndianExtensions.cs'
PINS=[(CLOSURE,'e49bd5bb3c1901521134fb0e6a3c1e3994f16e71f48fd3270ba86f7dc34f9199'),(COVERAGE,'e7044451212244a3ce70839cc7f153f5636a2f53c4b10d816fe672f52c9b3e71'),(BUILTINS,'9eb6e54c9effef25bb568b0f9f20198c033c7a0c997463e599cb0db917a6e591'),(EDITOR,'eec9083d39b9e9e2f788d8778cfd100bb0877cc42dace9880c3d2f629891a991'),(GUID_CAPTURE,'2b4155bc4bc8e78ace255698152c332534c123db7e9b245005e7e2645d89a356'),(REGRESSION,'54e5e805cd2c14dfc02e5882e3d12852c0cd44f0619aa98453e698319f775432'),(RESUME,'e549bd2d7018a869f6ade7e547748336d862a283bc4e7bec1303ae3bf3e96642'),(CS,'b21a3c0d59faad1906a58ecd79be8cbd8c4ecb4f8f4ce55e232f3e6b8039a5f3')]
FIELDS=('Platforms','Offsets_AssetList_AssetList_UInt32','CompressedLengths_AssetList_AssetList_UInt32','DecompressedLengths_AssetList_AssetList_UInt32','compressedBlob')
KNOWN_EMPTY={'AG/Standard-Opaque-Decal','AG/Standard-Opaque','Hidden/Universal Render Pipeline/StencilDeferred','Props/LensRender'}
BUILTIN_GUID='0000000000000000f000000000000000';BUILTIN_RAW='00000000000000000f00000000000000'

def need(v,m):
    if not v:raise ValueError(m)
def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def digest(b):return hashlib.sha256(b).hexdigest()
def pin(p):
    p=Path(p).resolve(strict=True);return {'path':str(p),'bytes':p.stat().st_size,'sha256':sha(p)}
def save(p,v):
    with p.open('x',encoding='utf-8') as f:json.dump(v,f,indent=2);f.write('\n')
def key(s):return (str(Path(s['source_path']).resolve()).lower(),str(signed(s['path_id'])))
def signed(v):
    need((isinstance(v,int) and not isinstance(v,bool)) or (isinstance(v,str) and re.fullmatch(r'-?(?:0|[1-9][0-9]*)',v)),'Exact decimal signed64 PathID required')
    n=int(v);need(-(1<<63)<=n<(1<<63),'PathID outside signed64');return n
def predicted_guid(guid):
    need(isinstance(guid,str) and re.fullmatch('[0-9a-f]{32}',guid),'Exact lower-case GUID required')
    # A prediction only. Each target's actual generated UnityGuid.Parse output
    # MUST match this before wrappers can be emitted; see GUID proof receipt.
    return bytes.fromhex(''.join(guid[i+1]+guid[i] for i in range(0,32,2))).hex()
def unique_pins(rows):
    result={}
    for r in rows:result[(r['path'],r['sha256'])]=r
    return list(result.values())

def worker(out):
    need(out.parent==ASSETS and out.name.startswith('AllOriginalShaderEditorManifest-'),'Recovery-only output required')
    checked={};stats={}
    def check(row):
        p=Path(row['path']).resolve(strict=True);need(p.is_relative_to(WS),'Input escaped workspace')
        k=str(p).lower();s=p.stat();shape=(s.st_size,s.st_mtime_ns)
        if k in checked:
            need(checked[k]==row and stats[k]==shape,'Previously pinned source changed');return
        need(pin(p)==row,'Pinned source bytes changed: '+p.name);checked[k]=row;stats[k]=shape
    for p,h in PINS:need(sha(p)==h,'Frozen independent source proof changed: '+p.name)
    c,v,b=[json.loads(p.read_bytes()) for p in (CLOSURE,COVERAGE,BUILTINS)]
    need(v['status']=='all179_original_cooked_and_retained_typed_data_validated' and len(c['canonical_shaders'])==len(v['Main_shaders'])==179,'Complete179 original identity proof required')
    need(b['status']=='all_four_original_Class48_aliases_and_Editor_builtin_names_and_property_descriptors_verified','Entire original+Editor builtin witness required')
    for p in (c['native_metadata_index'],c['existing_Main_dependency_graph'],b['genuine_Editor_identity_receipt']):check(p)
    n=json.loads(Path(c['native_metadata_index']['path']).read_bytes());graph=json.loads(Path(c['existing_Main_dependency_graph']['path']).read_bytes())
    rows=c['canonical_shaders'];by_guid={x['Main_guid']:x for x in rows};need(len(by_guid)==179,'Main GUID ambiguity')
    coverage_by={x['guid']:x for x in v['Main_shaders']};need({x['name'] for x in v['Main_shaders'] if x['compressed_blob_bytes']==0}==KNOWN_EMPTY,'Exact four previously proved missing Main program sets')
    native={str(Path(x['path']).resolve()).lower():x for x in n['native_containers']}
    sources={key(x):x for x in n['known_shader_names_and_native_identity'] if x['origin']=='original_native_container'}
    aliases={key(x['original_source']):x for x in b['identities']};need(len(aliases)==4,'Exact four builtin source identities')
    for a in aliases.values():
        e=a['Editor_identity'];need(a['entire_property_descriptor_subtree_equal'] and e['entire_Editor_object_consumed'] and e['class_id']==48 and e['native_path_id'] in (6,7,46,10490) and a['actual_original_name']==e['actual_name'],'Builtin semantic identity not proved')
        for p in (a['original_raw'],a['entire_original_model'],a['original_ParsedForm'],e['raw'],e['typed_model']):check(p)
        need(a['original_full_ParsedForm_equal_to_Editor_claimed'] is False,'Do not substitute full builtin ParsedForm equivalence claim')
    project_targets=sorted({d['target_Main_guid'] for x in rows for d in x['dependencies'] if d['classification']=='exact_original_target_to_Main_project_Shader'})
    need(len(project_targets)==13,'Expected exact thirteen project GUID destinations')
    regression=json.loads(REGRESSION.read_bytes());vectors=[]
    for x in regression['results']:
        check(x['report']);actual=json.loads(Path(x['report']['path']).read_bytes());need(actual['native_GUID_hex']==predicted_guid(x['guid']),'Expected GUID prediction disagrees with actual regression')
        vectors.append({'guid':x['guid'],'actual_native_GUID_hex':actual['native_GUID_hex'],'actual_CSharp_report':x['report']})
    capture=json.loads(GUID_CAPTURE.read_bytes());need(predicted_guid(capture['Main_fallback_text_GUID'])==capture['same_fallback_raw_GUID_bytes'],'Genuine fallback GUID vector')
    guid_proof={'schema':'predicted-project-GUID-serialization-with-mandatory-actual-converter-check/v1','status':'predictions_only_all13_future_converter_outputs_must_match','source_backed_CSharp_serializer':pin(CS),'four_UInt32_native_writer':pin(SERIALIZER),'genuine_Editor_capture':pin(GUID_CAPTURE),'actual_CSharp_vectors':vectors,'all13_project_targets':[{'guid':g,'expected_native_guid_hex':predicted_guid(g)} for g in project_targets],'no_local_UnityGuid_Parse_implementation_source_claimed':True,'actual_CSharp_target_validation_still_required':True,'wrapper_enforcement':'stage_original_shader_collection_wrappers.py requires reports[target].native_GUID_hex == manifest.external.native_guid_hex for every project external before emission','wrapper_tool':pin(HERE/'stage_original_shader_collection_wrappers.py')}
    gp=out/'GUID-serialization-boundary-proof.json';save(gp,guid_proof)
    # Revalidate only20 exact namespace headers/metadata, never entire containers.
    namespace_paths={x['source']['source_path'] for x in rows}|{d['target_source']['source_path'] for x in rows for d in x['dependencies']};namespaces=[]
    for path in sorted(namespace_paths):
        p=Path(path).resolve(strict=True);need(p.is_relative_to(VERIFIED),'Original namespace escaped VerifiedSource');ref=native[str(p).lower()];before=p.stat()
        with p.open('rb') as f:
            head=f.read(48);need(struct.unpack_from('>IIII',head)==(0,0,22,0) and head[16:20]==bytes(4),'Original v22 header')
            ms,size,start,unknown=struct.unpack_from('>IQQQ',head,20);need(size==before.st_size==ref['bytes'] and 0<ms<=16*1024**2 and ms==ref['metadata_bytes'] and 48+ms<=start<=size and unknown==0,'Original metadata bounds')
            meta=f.read(ms)
        need(digest(head)==ref['header_sha256'] and digest(meta)==ref['metadata_sha256'],'Native namespace metadata/header changed')
        need(ref.get('entire_metadata_consumed') is True and ref.get('platform')==19 and ref['engine']=='2020.3.33f1','Original full parsed Windows namespace required')
        need((p.stat().st_size,p.stat().st_mtime_ns)==(before.st_size,before.st_mtime_ns),'Original namespace changed during read')
        namespaces.append({k:ref[k] for k in ('path','bytes','metadata_bytes','metadata_sha256','header_sha256','engine','platform','expected_original_archive_sha256')});del meta
    graph_by={x['guid']:x for x in graph['shaders']};output=[];span_bytes=0;expected_edges=0;builtin_edges=0
    for index,x in enumerate(rows):
        identity=x['complete_original_identity_proof'];source_index=identity['source_index'];obj=v['source_objects'][source_index]
        need(obj['source']==x['source'] and obj['raw']==x['raw'],'Source index must match canonical original container+object')
        source=x['source'];pid=signed(source['path_id']);original_key=key(source);record=sources[original_key]
        need(record['class_id']==source['class_id']==48 and (record['byte_offset'],record['byte_size'])==(source['byte_offset'],source['byte_size']),'Exact original Class48 metadata span required')
        need(identity['full_original_object_consumed'] and identity['all_existing_program_values_match_missing_only_for_known4'] and identity['typed_retained_ParsedForm']['matches_all_retained_typed_data'],'Full original typed Main identity required')
        missing_programs=not identity['all_program_arrays_exact']
        if missing_programs:need(x['Main_name'] in KNOWN_EMPTY and coverage_by[x['Main_guid']]['compressed_blob_bytes']==0 and coverage_by[x['Main_guid']]['program_arrays']=={'platforms':[],'offsets':[],'compressedLengths':[],'decompressedLengths':[]},'Missing programs are permitted only for four exact proven empty Main field sets')
        else:need(x['Main_name'] not in KNOWN_EMPTY,'Known empty program set unexpectedly claimed exact')
        pointers=identity['pointer_closure'];need(pointers['nonmodifiable_texture_count']==0 and pointers['entire_tail_consumed'] and pointers['shader_is_baked'] is True,'Only original empty-texture baked Shader scope')
        for p in (x['raw'],identity['proof_receipt'],identity['model'],identity['original_ParsedForm']):check(p)
        model=json.loads(Path(identity['model']['path']).read_bytes());need(model['status']=='parsed_entire_original_object' and model['source_sha256']==x['raw']['sha256'] and model['actual_name']==x['Main_name'] and model['consumed_bytes']==model['total_bytes']==x['raw']['bytes'],'Exact independent original full model')
        programs={k:model['fields'][k] for k in FIELDS};need(model['program_ranges_within_original_blob'] and model['parsed_form']['sha256']==identity['original_ParsedForm']['sha256'],'Exact ParsedForm/program source proof')
        current=Path(x['Main_asset']);meta=Path(str(current)+'.meta');need(current.resolve().parent==MAIN,'Existing Main Shader directory only')
        current_pin=pin(current);meta_pin=pin(meta);need(current_pin['sha256']==x['Main_asset_sha256'] and meta_pin['sha256']==x['Main_meta_sha256'] and re.search(r'(?m)^guid: '+x['Main_guid']+r'\s*$',meta.read_text()),'Existing Main asset/meta/GUID changed')
        check(current_pin);check(meta_pin)
        raw=Path(x['raw']['path']).read_bytes();need(len(raw)==source['byte_size']<=32*1024**2,'Original raw span bound')
        with Path(source['source_path']).open('rb') as f:f.seek(source['byte_offset']);direct=f.read(source['byte_size'])
        span_bytes+=len(direct);need(direct==raw,'Extracted original body differs from exact VerifiedSource span')
        blob=identity['original_blob'];off=blob['offset_in_original'];need(digest(raw[off:off+blob['bytes']])==blob['sha256']==programs['compressedBlob']['sha256'] and blob['bytes']==programs['compressedBlob']['bytes'],'Exact compressed original program bytes')
        deps=x['dependencies'];need(len(deps)==pointers['dependency_count']==len(pointers['dependencies'])==len(graph_by[x['Main_guid']]['dependencies']),'Every original Shader PPtr enumerated once')
        tail=len(raw)-12-12*len(deps);need(struct.unpack_from('<i',raw,tail)[0]==len(deps) and raw[-8:]==struct.pack('<iB3x',0,1),'Independent raw empty-texture/baked dependency tail')
        external=[];external_keys={};mapped=[];expected=[];resolved=[]
        for di,d in enumerate(deps):
            need(d['dependency_index']==di and d['original_PPtr']==pointers['dependencies'][di],'Exact indexed dependency order')
            original=d['original_PPtr'];spid=signed(original['path_id']);sfid=original['file_id'];need(type(sfid) is int and -(1<<31)<=sfid<(1<<31),'Exact signed32 source FileID')
            need(struct.unpack_from('<iq',raw,tail+4+di*12)==(sfid,spid),'Raw typed original PPtr differs from indexed source')
            namespace=native[str(Path(source['source_path']).resolve()).lower()]
            if sfid==0:need(d['original_external'] is None and Path(d['target_source']['source_path']).resolve()==Path(source['source_path']).resolve(),'Exact local original namespace')
            else:need(1<=sfid<=len(namespace['externals']) and namespace['externals'][sfid-1]==d['original_external'],'Exact original one-based external row')
            target_key=key(d['target_source']);need(target_key in sources and sources[target_key]['class_id']==48 and signed(d['target_source']['path_id'])==spid,'Resolved original target must be indexed exact Class48 PathID')
            if d['classification']=='exact_original_target_to_Main_project_Shader':
                target=d['target_Main_guid'];need(target in by_guid and d['target_raw']['sha256']==by_guid[target]['raw']['sha256'] and d['existing_Main_reference']['guid']==target and d['existing_Main_reference']['local_file_id']==4800000,'Exact original project target/Main identity')
                check(d['target_raw']);check(d['target_identity_proof']);ek=('project',target);kind='project';outpid=4800000
                er={'kind':kind,'target_guid':target,'target_local_file_id':outpid,'native_guid_hex':predicted_guid(target),'type':2,'asset_path_hex':'','path_hex':'','resolution_proof':pin(CLOSURE),'GUID_proof':pin(gp),'native_GUID_prediction_requires_actual_target_converter_match':True}
                target_identity={'source':d['target_source'],'raw':d['target_raw'],'Main_guid':target,'canonical_source_index':by_guid[target]['complete_original_identity_proof']['source_index'],'identity_proof':d['target_identity_proof']}
            else:
                need(d['classification']=='original_Class48_to_existing_builtin_requires_Editor_identity_witness' and target_key in aliases,'No unknown dependency classification')
                a=aliases[target_key];outpid=signed(a['Editor_identity']['native_path_id']);need(outpid==d['target_Editor_builtin_path_id']==d['existing_Main_reference']['local_file_id'] and d['existing_Main_reference']['guid']==BUILTIN_GUID,'Genuine builtin destination differs from current reference')
                target=BUILTIN_GUID;ek=('builtin',target);kind='builtin';builtin_edges+=1
                er={'kind':kind,'target_guid':target,'native_guid_hex':BUILTIN_RAW,'type':0,'asset_path_hex':'','path_hex':b'Resources/unity_builtin_extra'.hex(),'target_local_file_ids':[],'resolution_proof':pin(BUILTINS),'GUID_proof':pin(GUID_CAPTURE),'builtin_identity_proof':pin(BUILTINS)}
                target_identity={'source':d['target_source'],'raw':a['original_raw'],'Editor_builtin_path_id':outpid,'actual_name':a['actual_original_name'],'entire_original_and_Editor_property_subtree_equal':True,'original_full_ParsedForm_equals_Editor_claimed':False,'identity_proof':pin(BUILTINS),'genuine_Editor_raw':a['Editor_identity']['raw']}
            if ek not in external_keys:external_keys[ek]=len(external)+1;external.append(dict(er,index=len(external)+1))
            ofid=external_keys[ek]
            if kind=='builtin' and outpid not in external[ofid-1]['target_local_file_ids']:external[ofid-1]['target_local_file_ids'].append(outpid)
            mapped.append({'index':di,'source_file_id':sfid,'source_path_id':spid,'output_file_id':ofid,'output_path_id':outpid})
            expected.append({'kind':kind,'guid':target,'local_file_id':outpid})
            resolved.append({'index':di,'original_PPtr':{'file_id':sfid,'path_id':spid,'path_id_decimal':str(spid)},'original_external':d['original_external'],'target':target_identity,'output_external_row':ofid,'output_path_id_decimal':str(outpid)})
            expected_edges+=1
        need({d['output_file_id'] for d in mapped}==set(range(1,len(external)+1)),'No missing or unused output external row')
        alternatives=[]
        for alt in x['equivalent_alternatives']:
            aobj=v['source_objects'][alt['source_index']];alternatives.append({'source_index':alt['source_index'],'source':aobj['source'],'raw':aobj['raw'],'identity_proof':alt['proof_receipt']})
        proofs=unique_pins([identity['proof_receipt'],identity['model'],identity['original_ParsedForm'],pin(CLOSURE),pin(BUILTINS),pin(gp),current_pin,meta_pin])
        entry={'schema':'resolved-original-Shader-Editor-conversion-input/v1','name':x['Main_name'],'guid':x['Main_guid'],'source':x['raw'],'original_path_id':pid,'original_path_id_decimal':str(pid),'source_index':source_index,'expected_ParsedForm_sha256':model['parsed_form']['sha256'],'expected_program_fields':programs,'expected_program_fields_canonical_JSON_sha256':digest(json.dumps(programs,sort_keys=True,separators=(',',':')).encode()),'expected_shader_is_baked':True,'dependencies':mapped,'externals':external,'meta':meta_pin,'current_asset':current_pin,'proofs':proofs,'expected_direct_shader_dependencies':expected,'restores_known_empty_Main_program_fields':missing_programs,'original_source_identity':{'source_file':source['source_file'],'source_path':source['source_path'],'path_id':pid,'path_id_decimal':str(pid),'class_id':48,'byte_offset':source['byte_offset'],'byte_size':source['byte_size'],'raw_sha256':x['raw']['sha256'],'source_index':source_index},'resolved_original_indexed_edges':resolved,'equivalent_original_sources':alternatives,'native_GUID_prediction':{'hex':predicted_guid(x['Main_guid']),'actual_CSharp_output_required':True,'proof':pin(gp)}}
        need(len(json.dumps(entry,indent=2).encode())<=256*1024,'Per-shader manifest exceeds existing converter256KiB bound')
        output.append(entry)
    need(expected_edges==104 and builtin_edges==27 and sum(len(x['dependencies']) for x in output)-builtin_edges==77,'Exact104 resolved edge census')
    manifest={'schema':'resolved-original-Shader-Editor-collection/v1','status':'all179_independently_resolved_original_sources_ready_for_review_NOT_CONVERTED','proofs':unique_pins([pin(p) for p,_ in PINS]+[c['native_metadata_index'],c['existing_Main_dependency_graph'],pin(gp)]),'shaders':output,'summary':{'shaders':179,'canonical_source_namespaces':19,'all_source_and_target_namespaces':len(namespaces),'source_objects':len(v['source_objects']),'typed_original_edges':104,'project_edges':77,'builtin_edges':27,'unique_project_GUID_targets':13,'unique_builtin_targets':4,'nonmodifiable_textures':0,'exact_VerifiedSource_body_bytes_read':span_bytes,'namespace_metadata_bytes_read':sum(x['metadata_bytes'] for x in namespaces),'largest_source_bytes':max(x['source']['bytes'] for x in output),'signed64_values_encoded_as_exact_JSON_integers':True,'all13_target_GUID_predictions_require_actual_CSharp_comparison':True},'source_namespaces':namespaces,'Main_modified':False,'Unity_or_compiler_launched':False,'managed_converter_executed':False,'native_API_or_game_code_executed':False,'tool':pin(Path(__file__))}
    # JSON transport itself must preserve every64-bit integer exactly.
    encoded=json.dumps(manifest,indent=2)+'\n';decoded=json.loads(encoded);need(decoded==manifest,'Lossless Python JSON manifest roundtrip')
    for p in checked:
        s=Path(checked[p]['path']).stat();need((s.st_size,s.st_mtime_ns)==stats[p],'Input changed during preparation')
    target=out/'manifest.json'
    with target.open('x',encoding='utf-8') as f:f.write(encoded)
    controls=[]
    for number in (-(1<<63),-9007199254740993,-1,0,9007199254740993,(1<<63)-1):need(json.loads(json.dumps({'id':number}))['id']==signed(number),'Signed64 exact JSON boundary');controls.append('signed64_roundtrip_'+str(number))
    for bad in ((1<<63),-(1<<63)-1,1.0,True,'1.0','+1'):
        rejected=False
        try:signed(bad)
        except ValueError:rejected=True
        need(rejected,'Invalid signed64 input was accepted');controls.append('reject_signed64_'+repr(bad))
    controls+=['all179_source_indices_raw_SHA_and_Main_meta_pins','all179_VerifiedSource_native_object_spans_exact','all179_original_compressed_program_bytes_exact','all104_original_raw_tail_PPtrs_match_indices','all104_resolved_destinations_and_ordered_externals_complete','all4_builtin_original_to_genuine_Editor_names_and_property_subtrees','two_actual_CSharp_GUID_vectors_and_genuine_fallback_capture','all179_per_entry_existing_converter256KiB_limit','all_input_files_stable_during_manifest_preparation']
    save(out/'offline-controls.json',{'schema':'all179-original-Shader-resolved-manifest-offline-controls/v1','status':'passed','controls':len(controls),'scenarios':controls,'manifest':pin(target),'tool':pin(Path(__file__)),'Main_modified':False,'Unity_or_compiler_or_managed_converter_launched':False})
    save(out/'report.json',{'schema':'all179-original-Shader-Editor-manifest-preparation/v1','status':'all179_manifest_and_offline_identity_controls_passed_NOT_CONVERTED','manifest':pin(target),'offline_controls':pin(out/'offline-controls.json'),'GUID_boundary_proof':pin(gp),'summary':manifest['summary'],'tool':pin(Path(__file__)),'Main_modified':False,'Unity_or_compiler_or_managed_converter_launched':False})
    print(json.dumps({'report':pin(out/'report.json'),'manifest':pin(target),'summary':manifest['summary']}),flush=True)

def main():
    if len(sys.argv)==3 and sys.argv[1]=='--worker':return worker(Path(sys.argv[2]).resolve(strict=True))
    need(len(sys.argv)==1,'Fixed proof inputs only')
    import read_original_ag_shader_models as guard
    guard.CAP=512*1024**2
    out=ASSETS/('AllOriginalShaderEditorManifest-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    result=guard.phase([sys.executable,'-B',str(Path(__file__).resolve()),'--worker',str(out)],out,'prepare-179-resolved-manifest')
    save(out/'owned-job-report.json',result)
    need(result.get('exit_code')==0 and not result.get('error'),'Manifest preparation held; preserve bounded receipt')
    print(json.dumps({'report':pin(out/'report.json'),'manifest':pin(out/'manifest.json'),'owned_job':pin(out/'owned-job-report.json')}),flush=True)
if __name__=='__main__':main()
