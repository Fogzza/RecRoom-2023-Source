"""Independent pure-byte179 conversion/wrapper/Main-pin verification; no Unity."""
from pathlib import Path
import datetime as dt, hashlib, importlib.util, json, re, struct, sys, uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';AR=ROOT/'AssetRecovery'
MANIFEST=AR/'AllOriginalShaderEditorManifest-20261023T045350Z-9a03b91a/manifest.json'
CONVERSION=AR/'OriginalShaderCollectionEditorConversion-20261023T030625Z-b13c1f0d/Run-20261023T045642Z-cc9d401d/run-report.json'
WRAPPERS=AR/'OriginalShaderEditorWrapperCollection-20261023T050017Z-5ed9890d/wrapper-collection.json'
CLOSURE=AR/'AllOriginalShaderDependencyClosure-20261023T031117Z-132fb863/report.json'
PARSER=AR/'OriginalFallbackNativeSerializedInput-20261022T205430Z-cab1d2e4/stage_input.py'
TYPE_SHA='0fbf2d2f8e6c2b23f21468a5a0528d28f361ca32775a5dec12d72f1f3a093171'
FIXED=[(MANIFEST,'a4ff950561f8572c9d0663703b4525957aa5c6053c1c40a1517aa300ff2d4f74'),(CONVERSION,'df3604418a233d9b332d571c3b8fa15654137b1c07e17765da2835fa6335b694'),(WRAPPERS,'01fa7e829d8735f8772721b0ef0bea26442ab1ab45b8ca8b6702070e5dcc12b5'),(CLOSURE,'e49bd5bb3c1901521134fb0e6a3c1e3994f16e71f48fd3270ba86f7dc34f9199'),(PARSER,'98b4cd637d310605981a57a7284660096dc4d2d4e8fa6b0f5240a41d4e2b02ae')]
def need(v,m):
    if not v:raise ValueError(m)
def digest(data):return hashlib.sha256(data).hexdigest()
def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def pin(p):
    p=Path(p).resolve(strict=True);return {'path':str(p),'bytes':p.stat().st_size,'sha256':sha(p)}
def save(p,v):
    with p.open('x',encoding='utf-8') as f:json.dump(v,f,indent=2);f.write('\n')
def name_end(data):
    n=struct.unpack_from('<i',data)[0];need(0<=n<=1024 and 4+n<=len(data),'Bounded NamedObject prefix');return (4+n+3)&~3,data[4:4+n].decode('utf-8')
def header(data,size):
    need(len(data)==48 and struct.unpack_from('>IIII',data)==(0,0,22,0) and data[16:20]==bytes(4),'Exact v22 little-endian native header')
    ms,total,start,unknown=struct.unpack_from('>IQQQ',data,20);need(total==size and 0<ms<=16*1024**2 and 48+ms<=start<=total and unknown==0,'Native header length bounds');return ms,start
def worker(out):
    need(out.parent==AR and out.name.startswith('AllOriginalShaderOutputsIndependent-'),'Recovery-only output')
    for p,h in FIXED:need(sha(p)==h,'Pinned actual output/proof changed: '+p.name)
    cache={};observed={}
    def check(r):
        p=Path(r['path']).resolve(strict=True);s=p.stat();k=str(p).lower();need(p.is_relative_to(WS),'Input outside workspace')
        if k in cache:need(cache[k]==r and observed[k]==(s.st_size,s.st_mtime_ns),'Input changed during verification');return
        need(pin(p)==r,'Whole file SHA/size mismatch: '+p.name);cache[k]=r;observed[k]=(s.st_size,s.st_mtime_ns)
    m,c,w,canonical=[json.loads(p.read_bytes()) for p in (MANIFEST,CONVERSION,WRAPPERS,CLOSURE)]
    need(m['schema']=='resolved-original-Shader-Editor-collection/v1' and len(m['shaders'])==len(c['results'])==len(c['phases'])==len(w['shaders'])==179,'Exactly179 source/conversion/wrapper rows')
    need(c['status']=='all_manifest_original_Shader_Editor_conversions_verified' and w['status']=='all_mapped_original_Shader_Editor_wrappers_verified_native_import_unproven','Actual successful data conversion/wrapping statuses')
    need(c['manifest']==pin(MANIFEST) and w['manifest']==pin(MANIFEST) and w['conversion_report']==pin(CONVERSION),'Exact manifest and actual run bound')
    for phase in c['phases']:need(phase['exit_code']==0 and phase['owned_child_exit_confirmed'] and phase['launcher']['membership_verified_before_resume'] and phase['cap_bytes']==512*1024**2 and phase['reserve_bytes']==int(1.5*1024**3) and phase['peak_job_bytes']<=phase['cap_bytes'],'Each actual converter process owned, bounded, complete')
    rows={r['guid']:r for r in m['shaders']};results={r['guid']:r for r in c['results']};wrapped={r['guid']:r for r in w['shaders']};gold={r['Main_guid']:r for r in canonical['canonical_shaders']}
    need(len(rows)==len(results)==len(wrapped)==179 and set(rows)==set(results)==set(wrapped)==set(gold),'Unique and complete original GUID sets')
    for r in m['proofs']:check(r)
    check(c['compile_proof']);compiled=json.loads(Path(c['compile_proof']['path']).read_bytes());check(compiled['assembly'])
    spec=importlib.util.spec_from_file_location('pinned_readonly_native_parser',PARSER);parser=importlib.util.module_from_spec(spec);spec.loader.exec_module(parser)
    source=Path(w['genuine_Editor_source']['path']);before=source.stat()
    with source.open('rb') as f:
        gh=f.read(48);ms,start=header(gh,before.st_size);gm=f.read(ms)
    need(digest(gh)==w['genuine_Editor_source']['header_sha256'] and digest(gm)==w['genuine_Editor_source']['metadata_sha256'],'Genuine Editor metadata/header exact')
    genuine=parser.parse_metadata(gm,start,before.st_size);typ=genuine['types'][0]
    need(genuine['engine']=='2020.3.33f1' and genuine['platform']==-2 and genuine['has_type_tree'] and typ['class_id']==48 and typ['old_type_hash']=='888994cda549cb3b5380e3be28b6cd6d' and len(typ['raw'])==84260 and digest(typ['raw'])==TYPE_SHA,'Genuine full same-version Editor Shader tree')
    need((source.stat().st_size,source.stat().st_mtime_ns)==(before.st_size,before.st_mtime_ns),'Genuine source stable')
    verified=[];actual_guids={};external_count=0;pointer_count=0
    for guid,row in rows.items():
        r=results[guid];z=wrapped[guid]
        for k in ('spec','report','editor_payload','normalized_release','original_compiled_blob','ParsedForm'):check(r[k])
        for k in ('asset','meta','proof'):check(z[k])
        for p in [row['source'],row['meta'],row['current_asset']]+row['proofs']:check(p)
        need(json.loads(Path(r['spec']['path']).read_bytes())==row,'Executed per-shader spec exact manifest row')
        proof=json.loads(Path(r['report']['path']).read_bytes());wp=json.loads(Path(z['proof']['path']).read_bytes())
        need(proof['status']=='original_bytes_preserved_except_name_and_manifest_typed_PPtrs' and proof['guid']==guid and proof['name']==row['name'] and proof['source_sha256']==row['source']['sha256'] and proof['source_bytes']==proof['release_consumed_bytes']==row['source']['bytes'],'Actual complete original ReadRelease source/model proof')
        need(proof['editor_bytes']==proof['editor_consumed_bytes']==r['editor_payload']['bytes'] and proof['editor_sha256']==r['editor_payload']['sha256'] and proof['original_source_path_id']==row['original_path_id'],'Actual entire generated Editor ReadEditor/payload proof')
        need(proof['entire_ParsedForm_equal'] and proof['all_five_original_program_fields_equal'] and proof['all_bytes_outside_name_and_manifest_typed_PPtr_windows_equal'] and proof['nonmodifiable_texture_count']==0 and proof['shader_is_baked'] is True,'Typed whole-source field preservation gates')
        need(proof['original_program_fields']==row['expected_program_fields'] and proof['parsed_form_utf8_sha256']==r['ParsedForm']['sha256']==row['expected_ParsedForm_sha256'],'Every original program field and complete ParsedForm hash exact')
        original=Path(row['source']['path']).read_bytes();release=Path(r['normalized_release']['path']).read_bytes();oldend,oldname=name_end(original);newend,newname=name_end(release)
        need(oldname in ('',row['name']) and newname==row['name'],'Only known NamedObject name normalization')
        deps=row['dependencies'];tail=len(original)-12-12*len(deps);need(struct.unpack_from('<i',original,tail)[0]==len(deps) and original[-8:]==struct.pack('<iB3x',0,1),'Raw typed original dependency/texture/baked tail')
        expected=bytearray(original[oldend:]);windows=[]
        for index,d in enumerate(deps):
            need(d['index']==index and struct.unpack_from('<iq',original,tail+4+index*12)==(d['source_file_id'],d['source_path_id']),'Every source PPtr checked as exact signed32/signed64 raw bytes')
            struct.pack_into('<iq',expected,tail+4+index*12-oldend,d['output_file_id'],d['output_path_id']);pointer_count+=1
            windows.append({'index':index,'original_offset':tail+4+index*12,'bytes':12,'source':{'file_id':d['source_file_id'],'path_id':d['source_path_id']},'target':{'file_id':d['output_file_id'],'path_id':d['output_path_id']},'changed':(d['source_file_id'],d['source_path_id'])!=(d['output_file_id'],d['output_path_id'])})
        encoded_name=row['name'].encode();need(release[:newend]==struct.pack('<i',len(encoded_name))+encoded_name+bytes(newend-4-len(encoded_name)) and release[newend:]==expected and len(release)-len(original)==newend-oldend,'Independently reconstructed entire Release bytes match only allowed name+indexed12B PPtr changes')
        need(proof['authorized_typed_PPtr_windows']==windows and proof['source_dependencies']==[x['source'] for x in windows] and proof['mapped_dependencies']==[x['target'] for x in windows],'Actual typed conversion report windows match independent byte reconstruction')
        blob=gold[guid]['complete_original_identity_proof']['original_blob'];off=blob['offset_in_original'];need(Path(r['original_compiled_blob']['path']).read_bytes()==original[off:off+blob['bytes']] and r['original_compiled_blob']['sha256']==blob['sha256'],'Entire original compiled blob byte-exact')
        actual_guids[guid]={'guid':guid,'actual_native_GUID_hex':proof['native_GUID_hex'],'conversion_report':r['report']};need(proof['native_GUID_hex']==row['native_GUID_prediction']['hex'],'Actual UnityGuid.Parse agrees with expected GUID bytes')
        need(wp['conversion']==r['report'] and wp['manifest_source']==pin(MANIFEST) and wp['source']==row['source'] and wp['original_source_identity']==row['original_source_identity'] and wp['original_meta_bytes_and_GUID_preserved'] and wp['all_Release_bytes_outside_name_and_manifest_typed_PPtr_windows_equal'],'Exact wrapper proof binds this source/conversion/manifest')
        need(z['expected_direct_shader_dependencies']==row['expected_direct_shader_dependencies'] and z['original_source_identity']==row['original_source_identity'],'Exact fixture dependency expectations/source namespace')
        data=Path(z['asset']['path']).read_bytes();meta_size,data_start=header(data[:48],len(data));need(data[:20]==gh[:20] and data[40:48]==gh[40:48],'Genuine native header fields preserved except declared sizes')
        p=parser.parse_metadata(data[48:48+meta_size],data_start,len(data));need(p['prefix']==genuine['prefix'] and p['user_raw']==genuine['user_raw'] and len(p['types'])==len(p['objects'])==1 and p['types'][0]['raw']==typ['raw'] and p['script_type_count']==p['ref_type_count']==0,'Full genuine native metadata/type tree, one object, no script/ref types')
        obj=p['objects'][0];payload=Path(r['editor_payload']['path']).read_bytes();need(obj['path_id']==4800000 and obj['relative']==0 and obj['type_index']==0 and obj['size']==len(payload) and data[obj['offset']:obj['offset']+obj['size']]==payload,'Native singleton entire Editor payload and localID4800000')
        need(data_start%16==0 and data[48+meta_size:data_start]==bytes(data_start-48-meta_size) and data[obj['offset']+obj['size']:]==bytes((-len(payload))%8),'Exact wrapper zero padding/alignment only')
        externals=[{'asset_path_hex':e['asset_path_hex'],'guid_hex':e['native_guid_hex'],'type':e['type'],'path_hex':e['path_hex']} for e in row['externals']]
        need(p['externals']==externals==wp['output_shape']['external_rows'],'Entire ordered native external table exact')
        need({d['output_file_id'] for d in deps}==set(range(1,len(externals)+1)),'No unused/missing external row');external_count+=len(externals)
        for d in deps:need(1<=d['output_file_id']<=len(externals),'Each mapped PPtr resolves through explicit native external row')
        Main_meta=Path(row['meta']['path']).read_bytes();need(Path(z['meta']['path']).read_bytes()==Main_meta and z['meta']['sha256']==row['meta']['sha256'] and re.search(rb'(?m)^guid: '+guid.encode()+rb'\s*$',Main_meta),'Current Main meta and copied GUID bytes exact')
        verified.append({'guid':guid,'source_raw_sha256':row['source']['sha256'],'editor_payload_sha256':r['editor_payload']['sha256'],'wrapper_sha256':z['asset']['sha256'],'meta_sha256':z['meta']['sha256'],'conversion_report_sha256':r['report']['sha256'],'typed_dependency_count':len(deps),'native_external_rows':len(externals)})
    targets=sorted({e['target_guid'] for x in rows.values() for e in x['externals'] if e['kind']=='project'});need(len(targets)==13,'Exactly thirteen actual project GUID destinations')
    vectors=[]
    for target in targets:
        value=dict(actual_guids[target]);edges=[]
        for guid,row in rows.items():
            for e in row['externals']:
                if e['kind']=='project' and e['target_guid']==target:need(e['native_guid_hex']==value['actual_native_GUID_hex'],'Actual target CSharp GUID must match every native project external');edges.append(guid)
        value['referencing_wrapper_GUIDs']=edges;vectors.append(value)
    for row in rows.values():
        for e in row['externals']:
            if e['kind']=='builtin':need(e['target_guid']=='0000000000000000f000000000000000' and e['native_guid_hex']=='00000000000000000f00000000000000' and e['type']==0 and e['asset_path_hex']=='' and bytes.fromhex(e['path_hex'])==b'Resources/unity_builtin_extra' and set(e['target_local_file_ids'])<=set((6,7,46,10490)),'Only genuine builtin external namespace/IDs')
    for k,r in cache.items():s=Path(r['path']).stat();need(observed[k]==(s.st_size,s.st_mtime_ns),'Pinned input changed during independent verification')
    need(pointer_count==104,'All104 actual typed pointers checked')
    vp=out/'actual-13-project-GUID-vectors.json';save(vp,{'schema':'all13-actual-UnityGuid-serializer-target-vectors/v1','status':'all13_actual_CSharp_outputs_equal_every_manifest_and_native_project_external','actual_CSharp_shader_GUID_outputs_also_checked':179,'vectors':vectors,'native_Editor_import_or_GPU_proven':False})
    report={'schema':'all179-actual-Shader-conversion-wrapper-independent-verification/v1','status':'all179_actual_conversions_wrappers_and_Main_shader_pins_verified','manifest':pin(MANIFEST),'conversion':pin(CONVERSION),'wrapper_collection':pin(WRAPPERS),'actual13_GUID_vectors':pin(vp),'genuine_Editor_metadata_header_verified_without_whole_container_read':True,'genuine_Class48_tree_sha256':TYPE_SHA,'summary':{'shaders':179,'complete_original_Release_bytes_reconstructed_with_only_name_and_indexed_PPtr_changes':179,'all5_program_fields_and_entire_original_blobs_exact':179,'entire_ParsedForm_hashes_exact':179,'full_genuine_native_wrapper_metadata_and_payloads':179,'actual_CSharp_own_GUID_outputs_checked':179,'actual_project_GUID_targets':13,'typed_PPtr_edges':pointer_count,'native_external_rows':external_count,'Main_shader_asset_pins_matched':179,'Main_shader_meta_pins_matched':179,'nonmodifiable_textures':0,'all179_actual_converter_exit_codes_zero':True},'shaders':verified,'tool':pin(Path(__file__)),'Main_modified':False,'backend_modified':False,'Unity_or_compiler_or_managed_converter_launched_by_this_review':False,'native_Editor_import_or_BuildPlayer_or_GPU_verified_for_all179':False}
    save(out/'report.json',report);print(json.dumps({'report':pin(out/'report.json'),'summary':report['summary']}),flush=True)
def main():
    if len(sys.argv)==3 and sys.argv[1]=='--worker':return worker(Path(sys.argv[2]).resolve(strict=True))
    need(len(sys.argv)==1,'Fixed completed output inputs only')
    import read_original_ag_shader_models as guard
    guard.CAP=256*1024**2
    out=AR/('AllOriginalShaderOutputsIndependent-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    result=guard.phase([sys.executable,'-B',str(Path(__file__).resolve()),'--worker',str(out)],out,'verify-179-converted-wrappers');save(out/'owned-job-report.json',result)
    need(result.get('exit_code')==0 and not result.get('error'),'Independent output verification held; preserve bounded receipt')
    report=json.loads((out/'report.json').read_bytes());checkpoint={'schema':'RR23-all179-original-Shader-data-converted-wrapped-checkpoint/v1','created_UTC':dt.datetime.now(dt.timezone.utc).isoformat(),'status':'independently_verified_all179_ready_for_isolated_native_import_build_fixture','manifest':pin(MANIFEST),'conversion':pin(CONVERSION),'wrapper_collection':pin(WRAPPERS),'independent_verification':pin(out/'report.json'),'actual13_GUID_vectors':report['actual13_GUID_vectors'],'owned_pure_job':pin(out/'owned-job-report.json'),'summary':report['summary'],'Main_shader_asset_and_meta_pins_unchanged':True,'Main_modified':False,'backend_modified':False,'Unity_or_compiler_or_managed_converter_launched_by_this_review':False,'all179_native_Editor_import_build_GPU_or_visual_fidelity_claimed':False,'next_required_proof':'Root isolated179-wrapper Editor import/dependency/build control with genuine builtins and proven BuildReport GUID/native mapper; no Main installation or unchanged full-game build implied.'}
    q=ROOT/'IncidentCheckpoints'/('OriginalShader179ConvertedWrapped-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]+'.json');save(q,checkpoint)
    print(json.dumps({'checkpoint':pin(q),'verification':pin(out/'report.json'),'owned_job':pin(out/'owned-job-report.json')}),flush=True)
if __name__=='__main__':main()
