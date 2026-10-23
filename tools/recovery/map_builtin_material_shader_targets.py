"""Pure two-stage Editor-builtin -> Material GUID -> native Class48 proof.

Extraction needs actual C# BuildReport Material records. Resolution additionally
needs full generated Class21 ReadRelease/exact WriteRelease roundtrip reports.
No builtin Shader name is used to choose a target.
"""
from pathlib import Path
import argparse
import json
import map_shader_buildreport as native

ROOT=native.WS/'Recovery/RecRoom-2023-04-18/AssetRecovery'
MAGIC='0000000000000000f000000000000000'
IDS={'6','7','46','10490'}
need=native.need


def checked(row):
    need(native.pin(row['path'])==row,'Pinned material/native input changed')
    return Path(row['path']).resolve(strict=True)


def number(value):
    need(type(value) is str and str(int(value))==value,'Canonical signed integer string required')
    result=int(value);need(-2**63<=result<2**63,'Signed64 overflow');return result


def save(path,value):
    with path.open('x',encoding='utf-8') as stream:
        json.dump(value,stream,indent=2);stream.write('\n')


def extract(build,project,player,out):
    project,player,out=(Path(p).resolve(strict=True) for p in (project,player,out))
    need(all(p.is_dir() and p.is_relative_to(ROOT) for p in (project,player,out)),'Isolated fixture-only paths required')
    need(build['status']=='Succeeded' and build['unity_version']=='2020.3.33f1'
         and build['target']=='StandaloneWindows64' and build['backend']=='Mono2x'
         and build['total_errors']==build['partial_constant_buffer_messages']==0,'Actual successful matching build required')
    witnesses=build['builtin_shader_material_witnesses']
    need(len(witnesses)==4 and {r['builtin_local_id'] for r in witnesses}==IDS,'Exact four actual Editor builtin witnesses required')
    capture=build['packed_material_build_report']
    need(capture['schema']=='Unity2020-actual-packed-Material-API-records/v1','Actual packed Material API capture required')
    files={r['id']:r['path'] for r in capture['files']}
    need(len(files)==len(capture['files']),'Unique actual BuildFile IDs required')
    result=[];used=set()
    for witness in witnesses:
        need(witness['builtin_guid']==MAGIC and witness['shader_instance_equal_after_native_import'] is True,
             'Actual Editor builtin GUID/id/instance witness required')
        relative=Path(witness['material_source_path'])
        need(not relative.is_absolute() and relative.parts[:3]==('Assets','Resources','BuiltinIdentityWitnesses')
             and '..' not in relative.parts,'Exact isolated diagnostic Material source path required')
        asset=(project/relative).resolve(strict=True)
        need(asset.is_relative_to(project) and native.pin(asset)['sha256']==witness['asset_sha256']
             and native.pin(str(asset)+'.meta')['sha256']==witness['meta_sha256'],'Diagnostic source Material/meta must remain unchanged')
        rows=[r for r in capture['materials'] if r['source_guid']==witness['material_guid']]
        need(len(rows)==1,'Exactly one packed placement per diagnostic Material GUID required')
        row=rows[0]
        need(row['source_path']==witness['material_source_path'] and row['type']=='UnityEngine.Material'
             and row['file_id'] in files,'Exact Material GUID/sourcepath/type/file join required')
        path=Path(files[row['file_id']]).resolve(strict=True)
        need(path.is_relative_to(player) and path.name==row['short_path'],'Exact actual native Material container required')
        parsed,layout=native.native(path)
        need(parsed['platform']==19,'Windows native player required')
        objects=[o for o in parsed['objects'] if o['path_id']==number(row['id'])]
        need(len(objects)==1,'Unique native Material identity required')
        obj=objects[0]
        need(parsed['types'][obj['type_index']]['class_id']==21 and obj['offset']==number(row['offset'])
             and obj['size']==number(row['packed_size']) and 0<obj['size']<=1024**2,'Exact Class21 native id/absolute range required')
        key=(str(path),obj['path_id']);need(key not in used,'Duplicate diagnostic native Material target');used.add(key)
        with path.open('rb') as stream:stream.seek(obj['offset']);raw=stream.read(obj['size'])
        need(len(raw)==obj['size'],'Complete bounded Material object read required')
        target=out/('Builtin-'+witness['builtin_local_id']+'-Class21.bin')
        with target.open('xb') as stream:stream.write(raw)
        result.append({'builtin_guid':MAGIC,'builtin_local_id':witness['builtin_local_id'],
            'material_guid':witness['material_guid'],'material_source_path':witness['material_source_path'],
            'source_Editor_material_identity_witness':witness,'container':native.pin(path),
            'native_material_path_id':str(obj['path_id']),'absolute_offset':str(obj['offset']),
            'byte_size':str(obj['size']),'class_id':21,'raw':native.pin(target),'native_layout':layout})
    return {'schema':'actual-Editor-builtin-Material-GUID-native-Class21-map/v1',
        'status':'all_four_Editor_builtin_origin_Material_GUID_Class21_ranges_corroborated',
        'materials':result,'Shader_targets_resolved':False,'Main_modified':False,'Unity_launched':False}


def resolve(material_map,typed_reports,player):
    need(material_map['schema']=='actual-Editor-builtin-Material-GUID-native-Class21-map/v1'
         and material_map['status']=='all_four_Editor_builtin_origin_Material_GUID_Class21_ranges_corroborated',
         'Successful actual diagnostic Material map required')
    player=Path(player).resolve(strict=True)
    need(player.is_relative_to(ROOT),'Isolated fixture player required')
    typed=[(pin,json.loads(checked(pin).read_bytes())) for pin in typed_reports]
    need(len(typed)==4,'Four exact full generated Material read reports required')
    result=[]
    for row in material_map['materials']:
        source=checked(row['raw']);container=checked(row['container'])
        matches=[(pin,r) for pin,r in typed if Path(r['source']).resolve(strict=True)==source]
        need(len(matches)==1,'Exactly one full typed report for each actual Material raw object required')
        proof_pin,proof=matches[0]
        need(proof['schema']=='full-generated-Material-Release-Shader-pointer/v1'
             and proof['status']=='entire_Class21_read_and_exact_Release_roundtrip_verified'
             and proof['class_id']==21 and proof['engine']=='2020.3.33f1'
             and proof['material_native_path_id']==row['native_material_path_id']
             and proof['bytes']==proof['consumed_bytes']==proof['roundtrip_bytes']==row['raw']['bytes']
             and proof['source_sha256']==proof['roundtrip_sha256']==row['raw']['sha256']
             and proof['full_Release_bytes_equal'] is True,'Full genuine Class21 consumption/entire byte roundtrip required')
        parsed,_=native.native(container)
        file_id,path_id=number(proof['shader_file_id']),number(proof['shader_path_id'])
        need(file_id>=0 and path_id!=0,'Nonnull typed Material Shader pointer required')
        external=None
        if file_id==0:target=container
        else:
            need(1<=file_id<=len(parsed['externals']),'Typed FileID must resolve through actual native external table')
            external=parsed['externals'][file_id-1]
            path=bytes.fromhex(external['path_hex']).decode('utf-8')
            need(external['asset_path_hex']=='' and external['guid_hex']=='0'*32 and external['type']==0
                 and path not in ('','.','..') and '/' not in path and '\\' not in path,
                 'Only actual simple-relative zeroGUID native external identity supported; archive/GUID paths HOLD')
            target=(container.parent/path).resolve(strict=True)
        need(target.is_file() and target.is_relative_to(player),'Material Shader target container must exist inside actual player')
        target_parsed,layout=native.native(target)
        need(target_parsed['platform']==19,'Matching Windows target required')
        candidates=[o for o in target_parsed['objects'] if o['path_id']==path_id]
        need(len(candidates)==1,'Exactly one native target must match full typed Material Shader PPtr')
        obj=candidates[0]
        need(target_parsed['types'][obj['type_index']]['class_id']==48 and 0<obj['size']<=8*1024**2,
             'Independently proved native Class48 target required')
        with target.open('rb') as stream:stream.seek(obj['offset']);raw=stream.read(obj['size'])
        need(len(raw)==obj['size'],'Complete bounded target Shader read')
        result.append({'builtin_guid':row['builtin_guid'],'builtin_local_id':row['builtin_local_id'],
            'source_Editor_material_identity_witness':row['source_Editor_material_identity_witness'],
            'material_GUID_native_mapping':row,'full_typed_Material_report':proof_pin,
            'actual_Material_shader_pointer':{'file_id':str(file_id),'path_id':str(path_id),'external_row':external},
            'target':{'container':native.pin(target),'path_id':str(path_id),'absolute_offset':str(obj['offset']),
                      'byte_size':str(obj['size']),'class_id':48,'raw_sha256':native.digest(raw),'native_layout':layout},
            'no_Shader_name_used_as_identity_selector':True})
    need({r['builtin_local_id'] for r in result}==IDS,'Exact four builtin output identities required')
    return {'schema':'genuine-Editor-builtin-to-player-Class48-through-Material/v1',
        'status':'all_four_Editor_builtin_ids_resolved_through_actual_Material_GUID_and_full_typed_native_PPtr',
        'builtin_targets':result,'Main_modified':False,'Unity_launched':False,'GPU_or_runtime_proven':False}


def main():
    ap=argparse.ArgumentParser(description=__doc__)
    ap.add_argument('--build-report',type=Path)
    ap.add_argument('--project',type=Path)
    ap.add_argument('--player-root',type=Path,required=True)
    ap.add_argument('--material-map',type=Path)
    ap.add_argument('--typed-report-pins',type=Path)
    ap.add_argument('--input-sha256',required=True)
    ap.add_argument('--output',type=Path,required=True)
    args=ap.parse_args()
    need(bool(args.build_report)!=bool(args.material_map),'Choose extraction or full typed resolution')
    original=args.build_report if args.build_report else args.material_map
    need(native.pin(original)['sha256']==args.input_sha256,'Explicit actual input report SHA required')
    out=args.output.resolve(strict=True)
    need(out.is_dir() and out.is_relative_to(ROOT),'Isolated existing output folder required')
    if args.build_report:
        need(args.project is not None,'Exact fixture project required')
        result=extract(json.loads(args.build_report.read_bytes()),args.project,args.player_root,out)
        name='material-native-map-report.json'
    else:
        need(args.typed_report_pins is not None,'Pinned generated Material reports required')
        result=resolve(json.loads(args.material_map.read_bytes()),json.loads(args.typed_report_pins.read_bytes()),args.player_root)
        name='builtin-native-Shader-targets.json'
    result['tool']=native.pin(Path(__file__))
    result['actual_input_report']=native.pin(original)
    if args.typed_report_pins:result['typed_report_pin_list']=native.pin(args.typed_report_pins)
    save(out/name,result)
    print(json.dumps({'status':result['status'],'report':native.pin(out/name)}))


if __name__=='__main__':main()
