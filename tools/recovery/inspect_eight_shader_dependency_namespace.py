"""Read-only native external table and metadata-slack proof; no native SDK calls."""
from pathlib import Path
import argparse
import datetime as dt
import importlib.util
import json
import struct
import sys
import uuid
import map_shader_buildreport as native
import orchestrate_eight_original_shader_restoration as context
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
BASE=context.AR/'EightOriginalShaderRestoration-20261023T065927Z-54a6afac'


def inspect(path):
    parsed,layout=native.native(path)
    with path.open('rb') as stream:
        header=stream.read(48);size,total,start,_=struct.unpack_from('>IQQQ',header,20);metadata=stream.read(size);slack=stream.read(start-48-size)
    native.need(len(slack)<=1024**2 and slack==bytes(len(slack)),'Bounded all-zero existing metadata/data gap')
    spec=importlib.util.spec_from_file_location('exact_eight_namespace_parser',native.PARSER);mod=importlib.util.module_from_spec(spec);spec.loader.exec_module(mod)
    c=mod.Cursor(metadata);c.pos=len(parsed['prefix'])+4+sum(len(t['raw']) for t in parsed['types'])+4
    for obj in parsed['objects']:
        c.align4();native.need((c.scalar('q'),c.scalar('q'),c.scalar('I'),c.scalar('i'))==(obj['path_id'],obj['relative'],obj['size'],obj['type_index']),'Exact object-table traversal')
    script_count=c.count(100000)
    for _ in range(script_count):c.scalar('i');c.align4();c.scalar('q')
    count_at=c.pos;count=c.count(100000);rows=[]
    for _ in range(count):
        begin=c.pos
        row={'asset_path_hex':c.cstr().hex(),'guid_hex':c.take(16).hex(),'type':c.scalar('i'),'path_hex':c.cstr().hex()}
        rows.append({'fields':row,'start':begin,'end':c.pos,'raw_hex':metadata[begin:c.pos].hex(),
            'asset_path_utf8':bytes.fromhex(row['asset_path_hex']).decode('utf-8'),'path_utf8':bytes.fromhex(row['path_hex']).decode('utf-8')})
    native.need([r['fields'] for r in rows]==parsed['externals'],'Exact complete actual external table')
    tail_at=c.pos;tail=metadata[tail_at:]
    new_row={'asset_path_hex':'','guid_hex':'0'*32,'type':0,'path_hex':b'resources.assets'.hex()}
    encoded=b'\0'+bytes(16)+struct.pack('<i',0)+b'resources.assets\0'
    expanded=metadata[:count_at]+struct.pack('<i',count+1)+metadata[count_at+4:tail_at]+encoded+tail
    feasible=len(expanded)<=start-48
    verified=False
    if feasible:
        check=mod.parse_metadata(expanded,start,total)
        native.need(check['externals']==parsed['externals']+[new_row],'One appended row and same old order')
        for key in ('engine','platform','has_type_tree','prefix','types','objects','script_type_count','ref_type_count','ref_types','user_raw'):
            native.need(check[key]==parsed[key],'Every other parsed metadata field remains exact: '+key)
        native.need(expanded[count_at+4:tail_at]==metadata[count_at+4:tail_at]
            and expanded[tail_at+len(encoded):]==tail,'Existing raw external rows and complete trailing metadata byte-exact')
        verified=True
    return {'container':native.pin(path),'layout':layout,'metadata_bytes':size,'data_offset':start,'zero_metadata_gap_bytes':len(slack),
        'type_count':len(parsed['types']),'object_count':len(parsed['objects']),'external_count_offset_relative_to_metadata':count_at,
        'external_count':count,'external_rows':rows,'trailing_metadata_start':tail_at,'trailing_metadata_bytes':len(tail),'trailing_metadata_hex':tail.hex(),
        'simple_resources_external_row_already_present':any(r['fields']==new_row for r in rows),
        'append_one_resources_row_proposal':{'only_proposed_no_file_changed':True,'new_1based_file_id':count+1,'row':new_row,'serialized_bytes':len(encoded),
            'new_metadata_bytes':len(expanded),'fits_existing_zero_gap':feasible,'new_metadata_full_parser_equal_except_appended_external':verified,
            'data_offset_and_file_size_change_required':False if feasible else 'HOLD','original_object_ranges_unchanged':verified,
            'original_trailing_metadata_moved_exact_bytes':len(tail),'original_trailing_metadata_delta':len(encoded)}}


def worker(out):
    need=native.need
    mapping=json.loads((BASE/'NativeMapping/Shader-GUID-native-map.json').read_bytes())
    builtins=json.loads((BASE/'NativeMapping/builtin-native-Shader-targets.json').read_bytes())
    sources={r['container']['path'] for r in mapping['mappings']}
    targets={r['target']['container']['path'] for r in builtins['builtin_targets']}
    reports=[inspect(Path(path)) for path in sorted(sources|targets)]
    report={'schema':'actual-eight-Shader-native-external-namespace-and-slack/v1','status':'read_only_exact_metadata_proposal',
        'project_Shader_containers':sorted(sources),'Material_proven_builtin_Shader_containers':sorted(targets),
        'containers':reports,'Main_modified':False,'native_files_changed':False,'managed_Unity_player_network_launched':False,'tool':native.pin(Path(__file__))}
    with (out/'namespace-report.json').open('x',encoding='utf-8') as stream:json.dump(report,stream,indent=2);stream.write('\n')
    print(json.dumps({'report':native.pin(out/'namespace-report.json'),'containers':[{'name':Path(r['container']['path']).name,'external_count':r['external_count'],
        'external_paths':[x['path_utf8'] for x in r['external_rows']],'metadata_gap':r['zero_metadata_gap_bytes'],'proposal':r['append_one_resources_row_proposal']} for r in reports]}))


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);args=ap.parse_args()
    if args._worker:return worker(args._worker.resolve(strict=True))
    out=context.AR/('EightShaderNamespaceInspection-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    receipt={'schema':'guarded-pure-eight-Shader-native-namespace-inspection/v1','status':'starting','phases':[]}
    try:
        guard.bounded([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],guard.WS,out,'pure-actual-native-external-and-zero-gap-analysis',256*1024**2,30,receipt);receipt['status']='passed'
    except BaseException as error:receipt.update(status='held',error=repr(error))
    guard.save(out,receipt);print(json.dumps({'status':receipt['status'],'receipt':native.pin(out/'run-report.json'),'error':receipt.get('error')}))
    return 0 if receipt['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
