"""Independent resolved-manifest cross-check; no construction or managed execution."""
from pathlib import Path
import datetime as dt,hashlib,json,struct,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';A=ROOT/'AssetRecovery'
FOLDER=A/'AllOriginalShaderEditorManifest-20261023T045350Z-9a03b91a';SOURCE=HERE/'prepare_all_original_shader_editor_manifest.py'
def sha(p):
    with p.open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def need(v,m):
    if not v:raise RuntimeError(m)
def main():
    pins={SOURCE:'f5921de1afed4ea77ec0f81cc2b79f22ab4662dac935356a7cd767e45e3fb7c9',FOLDER/'manifest.json':'a4ff950561f8572c9d0663703b4525957aa5c6053c1c40a1517aa300ff2d4f74',FOLDER/'report.json':'ed66c66f9adb77b4cb92fd8e84c2901e61d4c4c33a376ff54376386d2f349d7f',FOLDER/'GUID-serialization-boundary-proof.json':'8533a5d43c4807d56c711181fdc4b33db8b1a89bb404b90dd5d8233a93e22f4d'}
    for p,h in pins.items():need(sha(p)==h,'Frozen artifact changed')
    m=json.loads((FOLDER/'manifest.json').read_bytes());report=json.loads((FOLDER/'report.json').read_bytes());gp=json.loads((FOLDER/'GUID-serialization-boundary-proof.json').read_bytes())
    controls=json.loads((FOLDER/'offline-controls.json').read_bytes());need(controls['status']=='passed' and controls['controls']==21 and controls['manifest']['sha256']==pins[FOLDER/'manifest.json'],'Actual21controls must bindexactmanifest')
    c=json.loads((A/'AllOriginalShaderDependencyClosure-20261023T031117Z-132fb863/report.json').read_bytes());v=json.loads((A/'AllOriginalShaderCoverage-v3-20261023T030801Z-3f3c3f65/report.json').read_bytes());cb={r['Main_guid']:r for r in c['canonical_shaders']}
    need(len(m['shaders'])==len(cb)==179 and len({r['guid'] for r in m['shaders']})==179,'All179 unique identities')
    project_targets=set();counts={'project':0,'builtin':0};large=negative=0;metabytes=0;bodybytes=0
    for r in m['shaders']:
        original=cb[r['guid']];index=r['source_index'];obj=v['source_objects'][index]
        need(r['source']==original['raw']==obj['raw'] and original['source']==obj['source'] and r['original_path_id']==int(obj['source']['path_id']),'Independent sourceindex and original rawidentity')
        for number in [r['original_path_id']]+[x['source_path_id'] for x in r['dependencies']]+[x['output_path_id'] for x in r['dependencies']]:
            need(type(number) is int and -(1<<63)<=number<(1<<63),'Exact signed64 JSONinteger');large+=abs(number)>2**53;negative+=number<0
        need(len(r['dependencies'])==len(original['dependencies']) and [x['index'] for x in r['dependencies']]==list(range(len(r['dependencies']))),'Every dependency index retained')
        raw=Path(r['source']['path']).read_bytes();need(hashlib.sha256(raw).hexdigest()==r['source']['sha256'],'Canonical original raw SHA')
        tail=len(raw)-12-12*len(r['dependencies']);need(struct.unpack_from('<i',raw,tail)[0]==len(r['dependencies']) and raw[-8:]==struct.pack('<iB3x',0,1),'Independent raw dependency tail')
        bodybytes+=len(raw)
        model=json.loads(Path(original['complete_original_identity_proof']['model']['path']).read_bytes());need(r['expected_program_fields']=={k:model['fields'][k] for k in r['expected_program_fields']} and r['expected_ParsedForm_sha256']==model['parsed_form']['sha256'],'All original program arrays/blob and ParsedForm retained')
        for k in ('meta','current_asset'):
            p=Path(r[k]['path']);need(sha(p)==r[k]['sha256'] and p.stat().st_size==r[k]['bytes'],'CurrentMain input/meta pin');metabytes+=p.stat().st_size if k=='meta' else 0
        need(('guid: '+r['guid']) in Path(r['meta']['path']).read_text(),'OriginalMainGUIDexact')
        need({x['output_file_id'] for x in r['dependencies']}==set(range(1,len(r['externals'])+1)),'All output externalrowsused')
        for i,(dep,edge) in enumerate(zip(r['dependencies'],original['dependencies'])):
            need(struct.unpack_from('<iq',raw,tail+4+12*i)==(dep['source_file_id'],dep['source_path_id']),'Raw signed source PPtr agrees with manifest')
            need((dep['source_file_id'],dep['source_path_id'])==(int(edge['original_PPtr']['file_id']),int(edge['original_PPtr']['path_id'])),'Original namespaceindexed edge preserved')
            e=r['externals'][dep['output_file_id']-1];need(e['index']==dep['output_file_id'],'Exact onebased externalrow')
            if edge['classification']=='exact_original_target_to_Main_project_Shader':
                counts['project']+=1;project_targets.add(e['target_guid']);need(e['kind']=='project' and e['target_guid']==edge['target_Main_guid'] and e['type']==2 and dep['output_path_id']==4800000 and e['target_local_file_id']==4800000 and e['asset_path_hex']==e['path_hex']=='','Resolved projecttarget exact')
            else:
                counts['builtin']+=1;need(e['kind']=='builtin' and e['target_guid']=='0000000000000000f000000000000000' and e['native_guid_hex']=='00000000000000000f00000000000000' and e['type']==0 and dep['output_path_id']==edge['target_Editor_builtin_path_id'] and dep['output_path_id'] in (6,7,46,10490) and dep['output_path_id'] in e['target_local_file_ids'],'Resolved builtinidentity exact')
    need(counts=={'project':77,'builtin':27} and len(project_targets)==13,'Exact independent edgecounts')
    need(gp['actual_CSharp_target_validation_still_required'] and len(gp['actual_CSharp_vectors'])==2 and len(gp['all13_project_targets'])==13,'GUIDpredictions notoverclaimed')
    result={'schema':'independent-all179-original-Shader-manifest-review/v1','status':'no_blocker_found_ready_for_guarded_generated_conversion_NOT_CONVERTED',
        'source_sha256':pins[SOURCE],'manifest_sha256':pins[FOLDER/'manifest.json'],'actual_owner_controls':21,'independent_source_index_raw_program_Mainmeta_and_all104mapped_edges_checked':True,
        'count':179,'project_edges':77,'builtin_edges':27,'unique_project_targets':13,'original_raw_bytes_checked':bodybytes,'original_Main_meta_bytes_checked':metabytes,'observed_negative_ID_values':negative,'observed_abs_ID_over_2pow53_values':large,
        'signed64_controls_cover_negative_and_above2pow53_even_if_canonical_values_small':True,'all13_actual_native_GUID_outputs_still_required_before_wrapper_emission':True,
        'original_programs_preserved_by_manifest':True,'converted_Editor_bytes_or_native_import_verified_by_this_review':False,'Main_modified':False,'Unity_or_compiler_or_managed_converter_launched':False,'network_or_backend_modified':False}
    out=A/('All179ManifestIndependentReview-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();p=out/'report.json';p.write_text(json.dumps(result,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':str(p),'sha256':sha(p),'status':result['status']}))
if __name__=='__main__':main()
