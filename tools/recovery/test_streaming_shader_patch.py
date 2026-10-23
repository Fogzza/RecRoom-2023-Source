"""Pure controls on genuine AG/Fallback inputs; all outputs stay isolated."""
from pathlib import Path
import argparse
import copy
import json
import shutil
import struct
import patch_original_shader_collection_streaming as patcher

ROOT = patcher.ROOT
COLLECTION = ROOT/'OriginalShaderEditorWrapperCollection-20261023T030931Z-fb6fcab2/wrapper-collection.json'
MAPPING = ROOT/'ActualShaderPackedAPIMapping-20261023T045520Z-50d070fd/mapping-report.json'
PLAYER = ROOT/'OriginalAGDependencyFixture-20261023T045108Z-3fcc66c0/Run-20261023T045146Z-b9e37de3/Player'


def save(path, data):
    with path.open('x',encoding='utf-8') as stream:
        json.dump(data,stream,indent=2);stream.write('\n')


def main():
    ap=argparse.ArgumentParser()
    ap.add_argument('--out',type=Path,required=True)
    args=ap.parse_args()
    out=args.out.resolve(strict=True)
    collection=json.loads(COLLECTION.read_bytes())
    mapping=json.loads(MAPPING.read_bytes())
    by_guid={r['guid']:r for r in mapping['mappings']}
    specs=[]
    for row in collection['shaders']:
        proof=json.loads(Path(row['proof']['path']).read_bytes())
        bindings=[]
        for i,dep in enumerate(row['expected_direct_shader_dependencies']):
            target=by_guid[dep['guid']]
            bindings.append({'index':i,'kind':'project','target_guid':dep['guid'], 'target_container':target['container'],
                             'output_file_id':0,'output_path_id':target['path_id']})
        specs.append({'guid':row['guid'],'typed_source_proof':proof['conversion'],'bindings':bindings})
    plan={'schema':'explicit-original-Shader-streaming-native-patch/v1',
          'canonical_manifest':collection['manifest'],'mapping_report':patcher.native.pin(MAPPING),
          'player_root':str(PLAYER),'shaders':specs}
    save(out/'positive-plan.json',plan)
    target=out/'Positive';target.mkdir()
    result=patcher.patch(plan,target)
    patches={r['guid']:r for c in result['containers'] for r in c['objects']}
    patcher.need(patches['90510347b31afb84fba058c6708c7f5c']['mapped_payload_sha256']=='a8ec924055baadfca79bd3139d076cdaee15c107cc22477b7cfadc768a43a068',
                 'Mapped AG payload must equal previously real GPU-proven patch payload')
    patcher.need(patches['d2a5536c48f6e914f900eb13ea2f4d68']['mapped_payload_sha256']=='9d68229325a824a746e3dcdca644dc7d5eb9c3677d724b118697785d8c714300',
                 'Pointer-free Fallback payload must remain entirely original')
    cases=[{'name':'actual_AG_Fallback_typed_original_payload_and_masked_prefix','passed':True}]
    def reject(name,mutate):
        bad=copy.deepcopy(plan);mutate(bad)
        try: patcher.preflight(bad)
        except (ValueError,KeyError) as exc: cases.append({'name':name,'passed':True,'rejection':str(exc)})
        else: raise ValueError('Negative control accepted: '+name)
    reject('wrong_target_native_PathID',lambda p:p['shaders'][0]['bindings'][0].update(output_path_id='4'))
    reject('samecontainer_nonzero_FileID',lambda p:p['shaders'][0]['bindings'][0].update(output_file_id=1))
    reject('wrong_target_GUID',lambda p:p['shaders'][0]['bindings'][0].update(target_guid='0'*32))
    reject('missing_typed_pointer_binding',lambda p:p['shaders'][0]['bindings'].clear())
    reject('duplicate_patch_identity',lambda p:p['shaders'].append(copy.deepcopy(p['shaders'][0])))
    reject('missing_patch_identity',lambda p:p['shaders'].pop())
    reject('unproven_builtin_binding',lambda p:p['shaders'][0]['bindings'][0].update(kind='builtin'))
    reject('wrong_SourceProof',lambda p:p['shaders'][0].update(typed_source_proof=p['shaders'][1]['typed_source_proof']))
    reject('target_container_pin_mismatch',lambda p:p['shaders'][0]['bindings'][0]['target_container'].update(sha256='0'*64))
    reject('pointer_signed64_overflow',lambda p:p['shaders'][0]['bindings'][0].update(output_path_id=str(2**63)))
    cross=out/'UnprovedCrossContainer';cross.mkdir()
    copy_file=cross/Path(mapping['mappings'][0]['container']['path']).name
    shutil.copyfile(mapping['mappings'][0]['container']['path'],copy_file)
    cross_map=copy.deepcopy(mapping)
    cross_map['mappings'][1]['container']=patcher.native.pin(copy_file)
    cross_map_path=out/'unproved-crosscontainer-map.json';save(cross_map_path,cross_map)
    def cross_mutation(p):
        p['mapping_report']=patcher.native.pin(cross_map_path)
        p['player_root']=str(ROOT)
        p['shaders'][0]['bindings'][0].update(target_container=patcher.native.pin(copy_file),output_file_id=1)
    reject('actual_crosscontainer_without_existing_row_proof',cross_mutation)
    # Wrong native table/payload identities must fail even with a valid JSON pin.
    for name,change in [('wrong_native_range',lambda r:r.update(absolute_offset=str(int(r['absolute_offset'])+1))),
                        ('wrong_native_ClassID',lambda r:r.update(class_id=21)),
                        ('wrong_old_payload_SHA',lambda r:r.update(raw_sha256='0'*64))]:
        badmap=copy.deepcopy(mapping);change(badmap['mappings'][0]);mp=out/(name+'.json');save(mp,badmap)
        reject(name,lambda p,mp=mp:p.update(mapping_report=patcher.native.pin(mp)))
    source=Path(result['containers'][0]['input']['path']);patched=Path(result['containers'][0]['output']['path'])
    corrupt=out/'corrupt-prefix.assets';shutil.copyfile(patched,corrupt)
    with corrupt.open('r+b') as stream: stream.seek(4096);value=stream.read(1);stream.seek(4096);stream.write(bytes([value[0]^1]))
    try: patcher.mask_compare(source,corrupt,source.stat().st_size,result['containers'][0]['authorized_existing_file_edit_windows'])
    except ValueError: cases.append({'name':'unauthorized_nontarget_byte_changed','passed':True})
    else: raise ValueError('Corrupt nontarget byte accepted')
    # Reproduce the old64MiB failure boundary with genuine unchanged object data
    # and synthetic unused tail padding, explicitly a data-only capacity probe.
    synthetic=out/'Synthetic65MiBPlayer';synthetic.mkdir()
    synthetic_file=synthetic/source.name
    shutil.copyfile(source,synthetic_file)
    with synthetic_file.open('r+b') as stream:
        stream.seek(0,2)
        remaining=65*1024**2-stream.tell()
        while remaining:
            amount=min(patcher.CHUNK,remaining);stream.write(bytes(amount));remaining-=amount
        stream.seek(24);stream.write(struct.pack('>q',65*1024**2))
    large_map=copy.deepcopy(mapping)
    newpin=patcher.native.pin(synthetic_file)
    for row in large_map['mappings']: row['container']=newpin
    large_map_path=out/'synthetic65MiB-mapping.json';save(large_map_path,large_map)
    large_plan=copy.deepcopy(plan);large_plan.update(player_root=str(synthetic),mapping_report=patcher.native.pin(large_map_path))
    large_plan['shaders'][0]['bindings'][0]['target_container']=newpin
    large_output=out/'Synthetic65MiBOutput';large_output.mkdir()
    large_result=patcher.patch(large_plan,large_output)
    patcher.need(large_result['containers'][0]['output']['bytes']>65*1024**2,'Streaming output must exceed former64MiB cap')
    cases.append({'name':'synthetic65MiB_unused_tail_streaming_capacity','passed':True,'actual_Editor_or_runtime_claimed':False})
    save(out/'positive-patch-report.json',result)
    report={'schema':'pure-streaming-Shader-patcher-offline-controls/v1','status':'passed','controls':cases,'control_count':len(cases),
            'patcher':patcher.native.pin(Path(patcher.__file__)),'control_source':patcher.native.pin(Path(__file__)),
            'positive_plan':patcher.native.pin(out/'positive-plan.json'),'positive_report':patcher.native.pin(out/'positive-patch-report.json'),
            'positive_native_payloads_equal_previous_real_GPU_proof':True,'large_file_control_is_synthetic_unused_padding':True,
            'Main_modified':False,'Unity_launched':False,'compiler_launched':False,'runtime_or_GPU_tested':False,
            'builtin_edges_and_unproved_crosscontainer_identity_refused':True}
    save(out/'offline-controls.json',report)
    print(json.dumps({'status':'passed','controls':len(cases),'report':patcher.native.pin(out/'offline-controls.json')}))


if __name__=='__main__': main()
