"""Bounded pure review/preflight for one actual native external row plus eight payloads."""
from pathlib import Path
import argparse
import copy
import datetime as dt
import json
import struct
import sys
import uuid
import map_shader_buildreport as native
import patch_original_shader_collection_with_external_extension as target
import orchestrate_eight_original_shader_restoration as context
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
BASE=context.AR/'EightOriginalShaderRestoration-20261023T065927Z-54a6afac'
BASE_SHA='5fa179210ad33566b98c816a01be4503fc576f49fe3e5ae414b2b228d0293eea'
PATCHER_SHA='885b2e830af7987aa4f10d9f79b5096de7ff7def8e3dc604b26926ef80a30c4f'
NAMESPACE=context.AR/'EightShaderNamespaceInspection-20261023T070341Z-f82eb982/namespace-report.json'
NAMESPACE_SHA='36f1adf5ffb8e213fe5b46bd54961fc364c5095105702c3fac15f2218ea01ff8'


def controls(plan,builtin_targets,player):
    results=[]
    def reject(name,change):
        candidate=copy.deepcopy(plan);change(candidate)
        try:target.preflight(candidate)
        except (ValueError,KeyError,TypeError,struct.error):results.append({'name':name,'rejected':True})
        else:raise AssertionError('Expanded namespace mutation accepted: '+name)
    reject('wrong new FileID reuses existing row1',lambda p:p['native_external_extensions'][0].__setitem__('new_file_id',1))
    reject('new FileID skips row',lambda p:p['native_external_extensions'][0].__setitem__('new_file_id',3))
    for key,value in [('guid_hex','1'*32),('type',2),('asset_path_hex','61'),('path_hex',b'../resources.assets'.hex())]:
        reject('unauthorized appended external '+key,lambda p,k=key,v=value:p['native_external_extensions'][0]['appended_external_row'].__setitem__(k,v))
    reject('changed original container SHA',lambda p:p['native_external_extensions'][0]['container'].__setitem__('sha256','0'*64))
    reject('extension target is own source',lambda p:p['native_external_extensions'][0].__setitem__('target_container',p['native_external_extensions'][0]['container']))
    reject('missing extension',lambda p:p.__setitem__('native_external_extensions',[]))
    reject('duplicate extension',lambda p:p['native_external_extensions'].append(copy.deepcopy(p['native_external_extensions'][0])))
    index=next(i for i,r in enumerate(plan['shaders']) if any(b['kind']=='builtin' for b in r['bindings']))
    edge=next(i for i,r in enumerate(plan['shaders'][index]['bindings']) if r['kind']=='builtin')
    reject('builtin binding wrongly uses default-resource row1',lambda p:p['shaders'][index]['bindings'][edge].__setitem__('output_file_id',1))
    reject('builtin binding targets wrong native PathID',lambda p:p['shaders'][index]['bindings'][edge].__setitem__('output_path_id','99999999'))
    reject('builtin binding omits its full new external witness',lambda p:p['shaders'][index]['bindings'][edge].pop('external_row'))
    reject('original dependency omitted',lambda p:p['shaders'][index]['bindings'].pop())
    reject('Shader omitted',lambda p:p['shaders'].pop())
    reject('duplicate Shader identity',lambda p:p['shaders'].append(copy.deepcopy(p['shaders'][0])))
    return {'schema':'one-native-external-extension-and-eight-original-payload-preflight-controls/v1','status':'passed',
        'positive_actual8Shader14PPtr_preflight':True,'negative_controls':results,'negative_count':len(results),
        'native_patch_or_managed_code_executed':False}


def prepare(out):
    need=native.need
    need(guard.sha(HERE/'patch_original_shader_collection_with_external_extension.py')==PATCHER_SHA
        and guard.sha(NAMESPACE)==NAMESPACE_SHA,'Exact new patcher and actual metadata inspection')
    base,folder=context.load_plan(BASE/'restoration-plan.json',BASE_SHA)
    typed=BASE/'MaterialTypedProofs/run-report.json'
    need(guard.sha(typed)=='5e9f7929512f9a34531ce8011a3f35039314d1c1f1478f648c8cf86729e5b348','Actual Root four Class21 reader receipt')
    typed_report=json.loads(typed.read_bytes())
    need(typed_report['status']=='all_four_genuine_Class21_full_reads_and_entire_byte_roundtrips_passed'
        and len(typed_report['phases'])==4 and all(r['exit_code']==0 and r['launcher']['membership_verified_before_resume'] for r in typed_report['phases']),'Four genuine complete typed reads')
    builtin_path=BASE/'NativeMapping/builtin-native-Shader-targets.json'
    player=Path(base['player_root']).resolve(strict=True)
    builtin_targets=target.load_builtin_targets({'builtin_material_mapping_report':native.pin(builtin_path)},player)
    mappings=json.loads(context.check(base['Shader_mapping']).read_bytes());by_guid={r['guid']:r for r in mappings['mappings']}
    sources={r['container']['path'] for r in mappings['mappings']};destinations={r['container']['path'] for r in builtin_targets.values()}
    need(len(sources)==len(destinations)==1,'This exact bounded case is one project container and one builtin container')
    source=Path(next(iter(sources))).resolve(strict=True);destination=Path(next(iter(destinations))).resolve(strict=True)
    inspection=json.loads(NAMESPACE.read_bytes());entry=next(r for r in inspection['containers'] if Path(r['container']['path'])==source)
    need(entry['container']==native.pin(source) and entry['external_count']==1 and entry['metadata_bytes']==474
        and entry['data_offset']==4096 and entry['zero_metadata_gap_bytes']==3574,'Actual measured finite source layout')
    row={'asset_path_hex':'','guid_hex':'0'*32,'type':0,'path_hex':b'resources.assets'.hex()}
    extension={'container':native.pin(source),'target_container':native.pin(destination),'new_file_id':2,
        'appended_external_row':row,'actual_source_metadata_inspection':native.pin(NAMESPACE)}
    witness=target.extend_external_metadata(extension,builtin_targets,player)
    canonical=json.loads(context.check(base['canonical_manifest']).read_bytes())
    proofs={r['guid']:r['typed_source_proof'] for r in base['original_typed_source_proofs']};shaders=[]
    for original in canonical['shaders']:
        src=Path(by_guid[original['guid']]['container']['path']).resolve(strict=True);bindings=[]
        for index,dependency in enumerate(original['dependencies']):
            expected=target.expected_target(original,index);binding={'index':index,'kind':expected['kind'],'target_guid':expected['guid']}
            if expected['kind']=='null':binding.update(output_file_id=0,output_path_id='0')
            else:
                if expected['kind']=='project':mapped=by_guid[expected['guid']]
                else:
                    binding['builtin_local_id']=str(expected['builtin_id']);mapped=builtin_targets[binding['builtin_local_id']]
                dst=Path(mapped['container']['path']).resolve(strict=True)
                if dst==src:file_id,external=0,None
                else:
                    need(src==source and dst==destination,'Only the exact measured new cross-container namespace is authorized')
                    file_id,external=2,row
                binding.update(output_file_id=file_id,output_path_id=mapped['path_id'],target_container=mapped['container'])
                if external is not None:binding['external_row']=external
            bindings.append(binding)
        shaders.append({'guid':original['guid'],'typed_source_proof':proofs[original['guid']],'bindings':bindings})
    plan={'schema':'explicit-original-Shader-streaming-native-patch-with-one-proven-external/v1',
        'canonical_manifest':base['canonical_manifest'],'mapping_report':base['Shader_mapping'],'builtin_material_mapping_report':native.pin(builtin_path),
        'player_root':str(player),'shaders':shaders,'native_external_extensions':[extension],
        'actual_same_build_report':base['build_report'],'orchestration_plan':native.pin(BASE/'restoration-plan.json'),
        'Root_typed_Material_read_receipt':native.pin(typed),'patcher':native.pin(HERE/'patch_original_shader_collection_with_external_extension.py'),
        'Main_modified':False,'compiler_Unity_player_network_launched':False}
    _,containers,prepared=target.preflight(plan)
    need(len(prepared)==8 and sum(len(r['edits']) for r in prepared)==14,'Exact8 original payloads and14 typed pointer windows')
    tested=controls(plan,builtin_targets,player);save(out/'offline-controls.json',tested)
    patch_path=out/'expanded-native-streaming-patch-plan.json';save(patch_path,plan)
    patch_output=out/'PatchedNativeFiles';patch_output.mkdir()
    report={'schema':'actual-eight-original-payload-one-native-external-expansion-plan/v1','status':'native_preflight8Shaders14PPtrs_and16negative_controls_passed_NO_PATCH_EXECUTED',
        'patch_plan':native.pin(patch_path),'offline_controls':native.pin(out/'offline-controls.json'),'metadata_extension':witness['proof'],
        'new_patcher':native.pin(HERE/'patch_original_shader_collection_with_external_extension.py'),
        'Root_only_patch_command':[sys.executable,'-B',str(HERE/'patch_original_shader_collection_with_external_extension.py'),
            '--plan',str(patch_path),'--plan-sha256',guard.sha(patch_path),'--output',str(patch_output)],
        'scope':'Fresh diagnostic copies only; every original container remains read-only. Source GGM metadata474->512 consumes38 of3574zero bytes. FileSize grows only for appended exact original Shader payloads, not metadata.',
        'shader_source_replacements_used':False,'runtime_GPU_or_full_game_claimed':False,'Main_modified':False}
    save(out/'prepared-report.json',report)
    print(json.dumps({'status':report['status'],'report':native.pin(out/'prepared-report.json'),'patch_plan':native.pin(patch_path),
        'negative_controls':tested['negative_count'],'Root_only_patch_command':report['Root_only_patch_command']}))


def save(path,obj):
    with Path(path).open('x',encoding='utf-8') as stream:json.dump(obj,stream,indent=2);stream.write('\n')


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);args=ap.parse_args()
    if args._worker:return prepare(args._worker.resolve(strict=True))
    out=context.AR/('EightShaderExpandedNamespacePatch-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-pure-eight-Shader-metadata-extension-preparation/v1','status':'starting','phases':[]}
    try:
        guard.bounded([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],guard.WS,out,'pure-native-metadata-extension-preflight-and-controls',256*1024**2,60,report);report['status']='passed'
    except BaseException as error:report.update(status='held',error=repr(error))
    guard.save(out,report);print(json.dumps({'status':report['status'],'receipt':native.pin(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
