"""Bounded pure reads for Decal/Lens original Class48 objects; no Unity/compiler/Main writes."""
from pathlib import Path
import datetime as dt
import hashlib
import json
import os
import struct
import sys
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
sys.path[:0] = [str(HERE), str(ROOT / 'Tools')]
from read_original_ag_shader_models import phase, PREVIOUS, HOST, DOTNET, sha, pin, need
from probe_original_shader_sources import native_objects, object_name
from stage_original_native_sdk_dependencies import regular, SOURCE, INDEX, INDEX_SHA
from stage_original_ag_shader_candidate import typed_identity, compatible
from native_dependencies import Cursor

RAW = ROOT / 'RawUnityFSRecovery/VerifiedAll-20261022T133109Z-2e17e8f8'
TARGETS = {
    'AG/Standard-Opaque-Decal': ('AG_Standard-Opaque-Decal.asset', 'd9ec87b7cbbfb4e4e017ab1b2943fe00c1eb905f5054ba3971cc190d75e9499a', '11fa88e7c754fcabce43c8b82c4186e78836c98b19713a4cb1811cb531e0e0c6'),
    'Props/LensRender': ('Props_LensRender.asset', '368eda540fd06af72d0870afdb8aa54311b42a985d6717835f5a0a57371964db', '3de1518a23e1b9f68039944bd15072c7a8506342f36188e4ce080d8683411c77'),
}

def native_type_hashes(path):
    with path.open('rb') as stream:
        header = stream.read(48)
        amount, declared, version, data_start = struct.unpack_from('>IIII', header)
        head = 20
        if version >= 22:
            amount, declared, data_start, _ = struct.unpack_from('>IQQQ', header, 20)
            head = 48
        need(17 <= version <= 22 and declared == path.stat().st_size and 0 < amount <= 16*1024**2, 'Native metadata bounds')
        stream.seek(head)
        metadata = stream.read(amount)
    c = Cursor(metadata, '>' if header[16] else '<')
    engine, platform, tree = c.string(), c.read('i'), bool(c.read('B'))
    types = []
    for _ in range(c.count(100000)):
        cls = c.read('i'); c.skip(3)
        if cls == 114: c.skip(16)
        old_hash = metadata[c.pos:c.pos+16].hex(); c.skip(16)
        types.append({'class_id': cls, 'old_type_hash': old_hash})
        if tree:
            nodes, strings = c.count(1000000), c.count(64*1024**2)
            c.skip(nodes * (32 if version >= 19 else 24) + strings)
        if tree and version >= 21: c.skip(c.count(1000000) * 4)
    objects = {}
    for _ in range(c.count(1000000)):
        c.align4(); path_id = str(c.read('q'))
        relative = c.read('q' if version >= 22 else 'I')
        length, index = c.read('Ii')
        need(0 <= index < len(types) and data_start+relative+length <= declared, 'Exact native object/type bound')
        if types[index]['class_id'] == 48:
            objects[path_id] = {'engine': engine, 'platform': platform, 'old_type_hash': types[index]['old_type_hash'],
                                'class_id': 48, 'byte_offset': data_start+relative, 'byte_size': length}
    return objects

def worker(out):
    result = {'schema': 'bounded-two-other-original-shader-models/v1', 'status': 'starting', 'Main_modified': False,
              'Unity_launched': False, 'compiler_launched': False, 'models': [], 'selected': {}, 'phases': [],
              'selection_by_name_alone': False, 'HLSL_or_fallback_rewritten': False}
    try:
        need(sha(INDEX) == INDEX_SHA, 'Pinned original archive inventory differs')
        need(sha(PREVIOUS/'report.json') == 'e99d06254cd16e817a20e19cedecbedf8005c19608d7141d80461a9b9c6c8f97'
             and sha(PREVIOUS/'OriginalShaderObjectProbe.cs') == 'c10e692d0d482e9a55ede144f2ceb89e7622d7dce4bcc8b9af7adadc345858c3', 'Exact existing generic reader required')
        previous = json.loads((PREVIOUS/'report.json').read_bytes())
        for dependency in previous['dependencies']:
            need(sha(Path(dependency['path'])) == dependency['sha256'] and sha(PREVIOUS/Path(dependency['path']).name) == dependency['sha256'], 'Pinned generic reader dependency changed')
        result['reader'] = pin(HOST)
        result['generic_compile_receipt'] = pin(PREVIOUS/'report.json')
        inventory = {row[0]: {'bytes': row[1], 'sha256': row[2]} for row in json.loads(INDEX.read_bytes())['files']}
        mains = {}
        for name, (basename, asset_sha, meta_sha) in TARGETS.items():
            asset = WS/'RR23/Assets/Shader'/basename
            need(sha(asset) == asset_sha and sha(Path(str(asset)+'.meta')) == meta_sha, 'Main shader/meta changed before read')
            mains[name] = {'path': asset, 'asset': pin(asset), 'meta': pin(Path(str(asset)+'.meta')), 'identity': typed_identity(asset)}
        candidates = []
        raw_out = out/'Raw'; raw_out.mkdir()
        def inspect(source, row, origin):
            need(row['class_id'] == 48 and row['byte_size'] <= 32*1024**2, 'Only bounded Class48 original discovery')
            before = source.stat()
            with source.open('rb') as stream:
                stream.seek(row['byte_offset']); data = stream.read(row['byte_size'])
            need(len(data) == row['byte_size'], 'Original range truncated')
            found = [name for name in TARGETS if struct.pack('<i',len(name.encode())) + name.encode() in data]
            need(len(found) <= 1, 'Ambiguous discovery name patterns')
            if not found: return
            name = found[0]
            need(len(data) <= 8*1024**2, 'Existing safe generic reader8MiB bound exceeded; hold for review')
            path = raw_out/(str(len(candidates))+'-'+('native' if origin == 'native' else 'bundle')+'-'+row['path_id']+'.bin')
            path.write_bytes(data)
            need(sha(path) == hashlib.sha256(data).hexdigest(), 'Copied original object hash differs')
            after = source.stat()
            need((before.st_size,before.st_mtime_ns)==(after.st_size,after.st_mtime_ns),'Original container changed during read')
            candidates.append({'expected_name': name, 'origin': origin, 'source_path': str(source), 'original_object': row,
                               'raw_object': pin(path), 'name_pattern_is_discovery_only': True})
        for basename in ('globalgamemanagers.assets','resources.assets','sharedassets0.assets'):
            source = regular(SOURCE/'RecRoom_Data'/basename)
            expected = inventory['RecRoom_Data/'+basename]
            need(source.stat().st_size == expected['bytes'], 'Verified original native container size differs')
            rows = native_type_hashes(source)
            for path_id, item in rows.items():
                need(item['engine'] == '2020.3.33f1', 'Matching original native engine required')
                inspect(source, {'path_id':path_id, 'expected_original_container_sha256':expected['sha256'],
                                 'container_full_hash_revalidated_this_run':False, **item}, 'native')
        shaders = []
        with (RAW/'original-objects.jsonl').open('rb') as stream:
            for line in stream:
                if b'"class_id":48,' in line: shaders.append(json.loads(line))
        need(len(shaders)==92,'Exact verified bundle Shader index coverage required')
        wanted = {(x['source_bundle'],x['source_file']) for x in shaders}; nodes = {}
        with (RAW/'verified-nodes.jsonl').open('rb') as stream:
            for line in stream:
                node=json.loads(line); key=(node['source_bundle'],node['source_file'])
                if key in wanted: nodes[key]=node
        for row in shaders:
            node=nodes[(row['source_bundle'],row['source_file'])]; source=regular(Path(node['path']))
            need(source.stat().st_size==node['bytes'] and node['sha256']==row['source_node_sha256'],'Exact verified original bundle node provenance')
            inspect(source,row,'bundle')
        (out/'discovered-original-objects.json').write_text(json.dumps(candidates,indent=2)+'\n')
        result['discovery_candidates'] = pin(out/'discovered-original-objects.json')
        need(all(any(x['expected_name']==name for x in candidates) for name in TARGETS),'An original target has no Class48 discovery candidates')
        for index, candidate in enumerate(candidates):
            name=candidate['expected_name']; raw=Path(candidate['raw_object']['path']); model_dir=out/('Model-'+str(index))
            command=[str(DOTNET),str(HOST),str(raw),candidate['raw_object']['sha256'],candidate['original_object']['path_id'],name,str(model_dir)]
            run=phase(command,out,'read-model-'+str(index)); result['phases'].append(run)
            need(run.get('exit_code')==0 and not run.get('error'),'Bounded original generic model read failed')
            model_path=model_dir/'report.json'; model=json.loads(model_path.read_bytes())
            need(model['status']=='parsed_entire_original_object' and model['consumed_bytes']==model['total_bytes']==raw.stat().st_size
                 and model['class_id']==48 and model['actual_name']==name and model['program_ranges_within_original_blob'] and model['no_pointer_yaml'], 'Entire original structural model proof differs')
            comparison=compatible(typed_identity(Path(model['parsed_form']['path'])),mains[name]['identity'])
            compared=out/('retained-data-comparison-'+str(index)+'.json'); compared.write_text(json.dumps(comparison,indent=2)+'\n')
            result['models'].append({'target':name,'original_provenance':candidate,'model':pin(model_path),
                                      'retained_data_comparison':pin(compared),'matches_all_retained_typed_data':comparison['matches_all_retained_typed_data'],
                                      'original_program_fields':model['fields'],'full_original_consumption':True})
        for name in TARGETS:
            matches=[x for x in result['models'] if x['target']==name and x['matches_all_retained_typed_data']]
            need(len(matches)==1,'Unique complete retained-data mapping not established: '+name)
            result['selected'][name]=matches[0]
            entry=mains[name]
            need(sha(entry['path'])==entry['asset']['sha256'] and sha(Path(str(entry['path'])+'.meta'))==entry['meta']['sha256'],'Main shader/meta changed during pure reads')
        result['Main_before']={name:{'asset':entry['asset'],'meta':entry['meta']} for name,entry in mains.items()}
        result['status']='both_original_type48_objects_structurally_parsed_unique_retained_data_mapping'
    except BaseException as error:
        result.update(status='stopped_preserve_raw_for_review',error=repr(error))
    finally:
        (out/'models-report.json').write_text(json.dumps(result,indent=2)+'\n')
        print(json.dumps({'status':result['status'],'models_report':str(out/'models-report.json'),'models':len(result['models']),'error':result.get('error')}),flush=True)
    return 0 if len(result['selected'])==2 else 1

def main():
    if len(sys.argv)==3 and sys.argv[1]=='--worker':
        return worker(Path(sys.argv[2]))
    out=ROOT/'AssetRecovery'/('OtherOriginalShaderModels-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]); out.mkdir()
    run=phase([sys.executable,'-B',str(Path(__file__).resolve()),'--worker',str(out)],out,'bounded-raw-and-model-worker')
    (out/'outer-job-report.json').write_text(json.dumps(run,indent=2)+'\n')
    print(json.dumps({'report':str(out/'models-report.json'),'outer_job_report':str(out/'outer-job-report.json'),'exit_code':run.get('exit_code'),'peak_job_bytes':run.get('peak_job_bytes'),'error':run.get('error')}),flush=True)
    return 0 if run.get('exit_code')==0 and not run.get('error') else 1

if __name__=='__main__':
    raise SystemExit(main())
