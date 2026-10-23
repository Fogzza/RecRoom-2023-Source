"""Synthetic builtin evidence-chain controls; no genuine Class21/GPU claim.

Native v22 containers are constructed from a genuine Release Class48 type and
genuine preserved Shader payloads. Class21 payloads and their typed/build
receipts are explicitly test doubles. No Unity, compiler or native API runs.
"""
from pathlib import Path
import argparse, copy, json, struct
import patch_original_shader_collection_with_builtins as p

ROOT=p.ROOT
COLLECTION=ROOT/'OriginalShaderEditorWrapperCollection-20261023T030931Z-fb6fcab2/wrapper-collection.json'
G_MAP=ROOT/'ActualShaderPackedAPIMapping-20261023T045520Z-50d070fd/mapping-report.json'
AG='90510347b31afb84fba058c6708c7f5c';FB='d2a5536c48f6e914f900eb13ea2f4d68';SYN='1'*32
BIDS=['6','7','46','10490'];NIDS=[9006,9007,2**53+46,-10490]

def save(path,obj):
    with path.open('x',encoding='utf-8') as f:json.dump(obj,f,indent=2);f.write('\n')

def native_file(path,shader_type,objects,external=None):
    prefix=b'2020.3.33f1\0'+struct.pack('<iB',19,0)
    # The synthetic Class21 type/payload is a test double, never a native-read proof.
    types=[shader_type,struct.pack('<iBh',21,0,-1)+bytes(16)]
    meta=bytearray(prefix+struct.pack('<i',len(types))+b''.join(types)+struct.pack('<i',len(objects)))
    meta+=bytes((-len(meta))%4);body=bytearray();offsets=[]
    for pid,kind,data in objects:
        body+=bytes((-len(body))%8);offsets.append((pid,len(body),len(data),kind));body+=data
    for pid,offset,size,kind in offsets:meta+=struct.pack('<qqIi',pid,offset,size,kind)
    meta+=struct.pack('<ii',0,1 if external else 0)
    if external:meta+=b'\0'+bytes(16)+struct.pack('<i',0)+external.encode()+b'\0'
    meta+=struct.pack('<i',0)+b'\0'
    start=(48+len(meta)+15)&~15;body+=bytes((-len(body))%8)
    header=struct.pack('>IIII',0,0,22,0)+bytes(4)+struct.pack('>Iqqq',len(meta),start+len(body),start,0)
    path.write_bytes(header+meta+bytes(start-48-len(meta))+body)
    return p.native.native(path)

def fixture(out,cross=False):
    out.mkdir();player=out/'Player';player.mkdir()
    collection=json.loads(COLLECTION.read_bytes());canonical=json.loads(Path(collection['manifest']['path']).read_bytes())
    rows=copy.deepcopy(canonical['shaders']);by={r['guid']:r for r in rows}
    original=Path(by[FB]['source']['path']).read_bytes()
    fake=original[:-12]+struct.pack('<i',4)+b''.join(struct.pack('<iq',11+i,int(b)) for i,b in enumerate(BIDS))+bytes.fromhex('0000000001000000')
    fake_path=out/'SYNTHETIC-original-Shader.bin';fake_path.write_bytes(fake)
    synthetic=copy.deepcopy(by[FB]);synthetic.update(guid=SYN,name='SYNTHETIC builtin pointer control',source=p.native.pin(fake_path),dependencies=[{'index':i,'source_file_id':11+i,'source_path_id':int(b),'output_file_id':1,'output_path_id':int(b)} for i,b in enumerate(BIDS)],externals=[{'index':1,'kind':'builtin','target_guid':p.MAGIC_GUID,'target_local_file_ids':[int(b) for b in BIDS]}])
    rows.append(synthetic);canonical['shaders']=rows;manifest=out/'canonical.json';save(manifest,canonical)
    actualmap=json.loads(G_MAP.read_bytes());base=p.checked(actualmap['mappings'][0]['container']);parsed,_=p.native.native(base)
    st=next(t['raw'] for t in parsed['types'] if t['class_id']==48 and p.native.digest(t['raw'])==p.TYPE_SHA)
    main=player/'synthetic.assets';other=player/'builtin.assets'
    materials=[(100+i,1,struct.pack('<iq',1 if cross else 0,n)+b'SYNTHETIC-Class21-test-double') for i,n in enumerate(NIDS)]
    objects=[(1,0,original),(2,0,original),(3,0,original)]+materials
    builtin_objects=[(n,0,original) for n in NIDS]
    native_file(main,st,objects+([] if cross else builtin_objects),'builtin.assets' if cross else None)
    if cross:native_file(other,st,builtin_objects)
    container_pin=p.native.pin(main);main_parsed,layout=p.native.native(main)
    mappings=[]
    for guid,pid in [(AG,1),(FB,2),(SYN,3)]:
        obj=next(o for o in main_parsed['objects'] if o['path_id']==pid)
        mappings.append({'guid':guid,'class_id':48,'container':container_pin,'path_id':str(pid),'absolute_offset':str(obj['offset']),'byte_size':str(obj['size']),'raw_sha256':p.native.digest(original),'id_and_absolute_range_independently_corroborated':True,'name_used_as_identity_selector':False})
    mapping={'status':'all_expected_GUID_native_id_absolute_offset_size_corroborated','mappings':mappings};mp=out/'mapping.json';save(mp,mapping)
    proofs={}
    for r in collection['shaders']:
        proofs[r['guid']]=json.loads(Path(r['proof']['path']).read_bytes())['conversion']
    fbtyped=json.loads(p.checked(proofs[FB]).read_bytes());fbtyped.update(guid=SYN,name=synthetic['name'],source_bytes=len(fake),release_consumed_bytes=len(fake),source_sha256=synthetic['source']['sha256'],dependency_count=4,source_dependencies=[{'file_id':11+i,'path_id':int(b)} for i,b in enumerate(BIDS)])
    sp=out/'SYNTHETIC-Shader-typed-report.json';save(sp,fbtyped);proofs[SYN]=p.native.pin(sp)
    witnesses=[];packed=[];mm=[];typed=[]
    for i,bid in enumerate(BIDS):
        pid=100+i;obj=next(o for o in main_parsed['objects'] if o['path_id']==pid);raw=materials[i][2]
        guid=('%032x'%(100+i));source_path='Assets/Resources/BuiltinIdentityWitnesses/Builtin-'+bid+'.mat'
        witness={'builtin_guid':p.MAGIC_GUID,'builtin_local_id':bid,'shader_instance_equal_after_native_import':True,'material_guid':guid,'material_source_path':source_path,'asset_sha256':'0'*64,'meta_sha256':'0'*64}
        witnesses.append(witness);packed.append({'source_guid':guid,'source_path':source_path,'type':'UnityEngine.Material','file_id':'1','short_path':main.name,'id':str(pid),'offset':str(obj['offset']),'packed_size':str(obj['size'])})
        rp=out/('Builtin-'+bid+'-Class21.bin');rp.write_bytes(raw)
        mm.append({'builtin_guid':p.MAGIC_GUID,'builtin_local_id':bid,'material_guid':guid,'material_source_path':source_path,'source_Editor_material_identity_witness':witness,'container':container_pin,'native_material_path_id':str(pid),'absolute_offset':str(obj['offset']),'byte_size':str(obj['size']),'class_id':21,'raw':p.native.pin(rp),'native_layout':layout})
        proof={'schema':'full-generated-Material-Release-Shader-pointer/v1','status':'entire_Class21_read_and_exact_Release_roundtrip_verified','class_id':21,'engine':'2020.3.33f1','material_native_path_id':str(pid),'bytes':len(raw),'consumed_bytes':len(raw),'roundtrip_bytes':len(raw),'source_sha256':p.native.digest(raw),'roundtrip_sha256':p.native.digest(raw),'full_Release_bytes_equal':True,'source':str(rp),'shader_file_id':'1' if cross else '0','shader_path_id':str(NIDS[i])}
        tp=out/('SYNTHETIC-Material-'+bid+'-typed.json');save(tp,proof);typed.append(p.native.pin(tp))
    build={'status':'Succeeded','unity_version':'2020.3.33f1','target':'StandaloneWindows64','backend':'Mono2x','total_errors':0,'partial_constant_buffer_messages':0,'builtin_shader_material_witnesses':witnesses,'packed_material_build_report':{'schema':'Unity2020-actual-packed-Material-API-records/v1','files':[{'id':'1','path':str(main)}],'materials':packed}}
    bp=out/'SYNTHETIC-build-report.json';save(bp,build)
    materialmap={'schema':'actual-Editor-builtin-Material-GUID-native-Class21-map/v1','status':'all_four_Editor_builtin_origin_Material_GUID_Class21_ranges_corroborated','materials':mm,'tool':p.native.pin(Path(p.builtin.__file__)),'actual_input_report':p.native.pin(bp)}
    mmp=out/'SYNTHETIC-Material-map.json';save(mmp,materialmap)
    tpp=out/'typed-pin-list.json';save(tpp,typed)
    resolved=p.builtin.resolve(materialmap,typed,player);resolved.update(tool=p.native.pin(Path(p.builtin.__file__)),actual_input_report=p.native.pin(mmp),typed_report_pin_list=p.native.pin(tpp))
    br=out/'SYNTHETIC-builtin-targets.json';save(br,resolved)
    specs=[]
    for r in rows:
        bindings=[]
        for i,d in enumerate(r['dependencies']):
            if r['guid']==SYN:
                target=resolved['builtin_targets'][i]['target'];binding={'index':i,'kind':'builtin','target_guid':p.MAGIC_GUID,'builtin_local_id':BIDS[i],'target_container':target['container'],'output_file_id':1 if cross else 0,'output_path_id':target['path_id']}
                if cross:binding['external_row']=main_parsed['externals'][0]
            else:binding={'index':i,'kind':'project','target_guid':FB,'target_container':container_pin,'output_file_id':0,'output_path_id':'2'}
            bindings.append(binding)
        specs.append({'guid':r['guid'],'typed_source_proof':proofs[r['guid']],'bindings':bindings})
    plan={'schema':'explicit-original-Shader-streaming-native-patch-with-builtin-Material-proof/v1','canonical_manifest':p.native.pin(manifest),'mapping_report':p.native.pin(mp),'builtin_material_mapping_report':p.native.pin(br),'player_root':str(player),'shaders':specs}
    return plan,resolved,materialmap,typed,build

def main():
    ap=argparse.ArgumentParser();ap.add_argument('--out',type=Path,required=True);args=ap.parse_args();out=args.out.resolve(strict=True)
    p.need(out.is_dir() and out.is_relative_to(ROOT) and not any(out.iterdir()),'Fresh isolated control folder required')
    plan,report,materialmap,typed,build=fixture(out/'SameContainer');cases=[]
    def record(name):cases.append({'name':name,'passed':True})
    positive=out/'Positive';positive.mkdir();result=p.patch(plan,positive)
    synthetic=next(o for c in result['containers'] for o in c['objects'] if o['guid']==SYN)
    p.need([int(e['path_id']) for e in synthetic['typed_PPtr_edits']]==NIDS,'Every builtin maps by actual typed Material target, including signed/above2pow53 IDs')
    p.need(all(c['every_other_preexisting_byte_exact'] and c['all_nontarget_object_rows_ranges_and_payloads_exact'] for c in result['containers']),'Entire old-prefix/nontarget masks must pass')
    record('synthetic_four_builtins_samecontainer_full_append_and_oldbyte_preservation')
    record('signed64_negative_and_above2pow53_builtin_output_IDs_preserved')
    ag=next(o for c in result['containers'] for o in c['objects'] if o['guid']==AG)
    canonical=json.loads(Path(plan['canonical_manifest']['path']).read_bytes());ag_source=next(r['source'] for r in canonical['shaders'] if r['guid']==AG)
    expected_ag=bytearray(p.checked(ag_source).read_bytes());struct.pack_into('<iq',expected_ag,len(expected_ag)-20,0,2)
    p.need(ag['mapped_payload_sha256']==p.native.digest(expected_ag),'Genuine original AG bytes must match exactly except its one proved12B PPtr write')
    cross,_,_,_,_=fixture(out/'CrossContainer',True);dest=out/'CrossPositive';dest.mkdir();cr=p.patch(cross,dest)
    p.need(next(o for c in cr['containers'] for o in c['objects'] if o['guid']==SYN)['typed_PPtr_edits'][0]['file_id']==1,'Existing exact zeroGUID-relative builtin target external required')
    record('synthetic_existing_relative_zeroGUID_crosscontainer_binding')
    def reject(name,mutate):
        bad=copy.deepcopy(plan);mutate(bad)
        try:p.preflight(bad)
        except (ValueError,KeyError,FileNotFoundError):record(name)
        else:raise ValueError('Negative control accepted: '+name)
    def nested(name,key,mutate):
        r=copy.deepcopy(report);mutate(r);rp=out/(name+'.json');save(rp,r);reject(name,lambda q:q.update(builtin_material_mapping_report=p.native.pin(rp)))
    reject('required_builtin_receipt_missing',lambda q:q.pop('builtin_material_mapping_report'))
    reject('old_schema_refused',lambda q:q.update(schema='explicit-original-Shader-streaming-native-patch/v1'))
    reject('wrong_Editor_builtin_binding_ID',lambda q:q['shaders'][2]['bindings'][0].update(builtin_local_id='7'))
    reject('wrong_builtin_magic_GUID_binding',lambda q:q['shaders'][2]['bindings'][0].update(target_guid='0'*32))
    reject('wrong_builtin_output_PathID',lambda q:q['shaders'][2]['bindings'][0].update(output_path_id='6'))
    reject('samecontainer_builtin_nonzero_FileID',lambda q:q['shaders'][2]['bindings'][0].update(output_file_id=1))
    reject('unproved_external_on_samecontainer_builtin',lambda q:q['shaders'][2]['bindings'][0].update(external_row={}))
    reject('builtin_signed64_overflow',lambda q:q['shaders'][2]['bindings'][0].update(output_path_id=str(2**63)))
    reject('missing_typed_builtin_binding',lambda q:q['shaders'][2]['bindings'].pop())
    reject('project_target_checks_unchanged_wrong_GUID',lambda q:q['shaders'][0]['bindings'][0].update(target_guid='0'*32))
    reject('project_target_checks_unchanged_wrong_PathID',lambda q:q['shaders'][0]['bindings'][0].update(output_path_id='1'))
    nested('builtin_wrong_report_schema','',lambda r:r.update(schema='unproved/v1'))
    nested('builtin_missing_identity','',lambda r:r['builtin_targets'].pop())
    nested('builtin_duplicate_identity','',lambda r:r['builtin_targets'][0].update(builtin_local_id='7'))
    nested('builtin_wrong_magic_GUID_receipt','',lambda r:r['builtin_targets'][0].update(builtin_guid='0'*32))
    nested('builtin_name_selection_refused','',lambda r:r['builtin_targets'][0].update(no_Shader_name_used_as_identity_selector=False))
    nested('builtin_target_wrong_native_range','',lambda r:r['builtin_targets'][0]['target'].update(absolute_offset=str(int(r['builtin_targets'][0]['target']['absolute_offset'])+1)))
    nested('builtin_target_wrong_native_ClassID','',lambda r:r['builtin_targets'][0]['target'].update(class_id=21))
    nested('builtin_target_wrong_raw_hash','',lambda r:r['builtin_targets'][0]['target'].update(raw_sha256='0'*64))
    nested('builtin_bad_mapper_pin','',lambda r:r['tool'].update(sha256='0'*64))
    # Rewrite and repin typed test doubles: failures must reach semantic checks,
    # rather than merely rejecting a changed report SHA.
    def typed_bad(name,mutate):
        tp=copy.deepcopy(typed);body=json.loads(Path(tp[0]['path']).read_bytes());mutate(body);fp=out/(name+'-typed.json');save(fp,body);tp[0]=p.native.pin(fp);lp=out/(name+'-pins.json');save(lp,tp)
        nested(name,'',lambda r:r.update(typed_report_pin_list=p.native.pin(lp)))
    typed_bad('Class21_partial_read_refused',lambda r:r.update(consumed_bytes=r['bytes']-1))
    typed_bad('Class21_wrong_roundtrip_hash_refused',lambda r:r.update(roundtrip_sha256='0'*64))
    typed_bad('Class21_full_equality_false_refused',lambda r:r.update(full_Release_bytes_equal=False))
    typed_bad('Class21_wrong_class_refused',lambda r:r.update(class_id=48))
    typed_bad('Class21_wrong_engine_refused',lambda r:r.update(engine='2021.3.0f1'))
    typed_bad('Class21_changed_shader_PPtr_refused',lambda r:r.update(shader_path_id=str(NIDS[1])))
    typed_bad('Class21_wrong_native_Material_ID_refused',lambda r:r.update(material_native_path_id='101'))
    # The output map must also remain linked to the exact actual Material range.
    badmap=copy.deepcopy(materialmap);badmap['materials'][0]['absolute_offset']=str(int(badmap['materials'][0]['absolute_offset'])+1);bm=out/'wrong-Material-range-map.json';save(bm,badmap)
    nested('Class21_actual_native_range_mismatch_refused','',lambda r:r.update(actual_input_report=p.native.pin(bm)))
    badmap=copy.deepcopy(materialmap);badmap['materials'][0]['raw']['sha256']='0'*64;bm2=out/'wrong-Material-raw-map.json';save(bm2,badmap)
    nested('Class21_actual_payload_hash_mismatch_refused','',lambda r:r.update(actual_input_report=p.native.pin(bm2)))
    badcross=copy.deepcopy(cross);badcross['shaders'][2]['bindings'][0]['external_row']['guid_hex']='f'*32
    try:p.preflight(badcross)
    except ValueError:record('crosscontainer_wrong_existing_external_witness_refused')
    else:raise ValueError('Wrong crosscontainer witness accepted')
    save(out/'positive-plan.json',plan);save(out/'positive-report.json',result)
    receipt={'schema':'synthetic-builtin-aware-streaming-Shader-patcher-controls/v1','status':'passed','count':len(cases),'controls':cases,'tool':p.native.pin(Path(p.__file__)),'test_source':p.native.pin(Path(__file__)),'plan':p.native.pin(out/'positive-plan.json'),'positive_report':p.native.pin(out/'positive-report.json'),'Class21_payloads_and_typed_build_receipts_are_synthetic_test_doubles':True,'actual_four_builtin_fixture_accepted':False,'genuine_AG_Fallback_original_GPU_fields_preserved_in_positive_patch':True,'Unity_or_compiler_or_player_or_network_launched':False,'Main_modified':False}
    save(out/'offline-controls.json',receipt);print(json.dumps({'status':'passed','count':len(cases),'report':p.native.pin(out/'offline-controls.json')}))
if __name__=='__main__':main()
