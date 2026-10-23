"""Pure namespace/Root-only-reader controls against the proven8 native output."""
from pathlib import Path
import argparse,ast,copy,json
import orchestrate_all_original_shader_restoration as target
import orchestrate_eight_original_shader_restoration as old


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--out',required=True,type=Path);args=ap.parse_args();out=args.out.resolve(strict=True)
    target.need(out.is_relative_to(target.AR),'Fresh recovery-only control outputs')
    pins=target.checked_tools();target.need(len(target.canonical_guids())==179,'Exact canonical179 identity positive')
    target.probe_inputs()  # hashes/source metadata only, never runs the reader
    base=target.AR/'EightOriginalShaderRestoration-20261023T065927Z-54a6afac'
    shader_path=base/'NativeMapping/Shader-GUID-native-map.json';builtin_path=base/'NativeMapping/builtin-native-Shader-targets.json'
    mapping=json.loads(shader_path.read_bytes());builtins=json.loads(builtin_path.read_bytes())
    target.need(target.guard.sha(shader_path)=='a8f2f1bb13b041b92ea7c66f78dcfb6c92bff8bf0a99e6132183f505dbf8ca23','Actual known8 GUID/native mapping')
    source=Path(mapping['mappings'][0]['container']['path']);targets={r['builtin_local_id']:r['target'] for r in builtins['builtin_targets']};destination=Path(targets['46']['container']['path'])
    source_pin=target.native.pin(source);destination_pin=target.native.pin(destination)
    parsed,_=target.native.native(source);facts=target.inspect_namespace(source)
    target.need(target.native_file_id(source,source,parsed['externals'])==(0,None),'Same container exact file0')
    target.need(target.native_file_id(source,destination,parsed['externals'])==(None,None),'Actual existing default-resource alias cannot masquerade as resources container')
    row={'asset_path_hex':'','guid_hex':'0'*32,'type':0,'path_hex':destination.name.encode().hex()};rows=parsed['externals']+[row]
    expected_index=len(parsed['externals'])+1
    target.need(target.native_file_id(source,destination,rows)==(expected_index,row),'Fresh index derives from actual row count')
    negatives=[]
    for name,key,value in [('nonzeroGUID','guid_hex','1'*32),('wrongtype','type',2),('assetpath','asset_path_hex',b'forged'.hex()),
        ('parentpath','path_hex',b'../resources.assets'.hex()),('archivepath','path_hex',b'archive:/resources.assets'.hex()),('wrongbasename','path_hex',b'other.assets'.hex())]:
        changed=copy.deepcopy(row);changed[key]=value
        target.need(target.native_file_id(source,destination,parsed['externals']+[changed])==(None,None),'Unproven namespace must not resolve: '+name);negatives.append({'name':name,'rejected':True})
    try:target.native_file_id(source,destination,rows+[row])
    except ValueError:negatives.append({'name':'duplicate matching native rows','rejected':True})
    else:raise AssertionError('Duplicate matching namespace rows accepted')
    spec={'container':source_pin,'target_container':destination_pin,'new_file_id':expected_index,'appended_external_row':row}
    player=Path(mapping['mappings'][0]['container']['path']).parent.parent
    # The actual player root is taken from the old pinned orchestration, never inferred for production.
    context=json.loads((base/'restoration-plan.json').read_bytes());player=Path(context['player_root'])
    extended=target.expanded.extend_external_metadata(spec,targets,player)
    target.need(extended['parsed']['externals']==rows and extended['proof']['data_offset_unchanged']
        and extended['proof']['existing_external_rows_and_order_byte_exact'] and extended['proof']['all_other_parsed_metadata_exact'],
        'Actual known8 proven extension positive; complete old metadata retained')
    for name,change in [('wrong external index',lambda s:s.__setitem__('new_file_id',expected_index+1)),
        ('wrong external fields',lambda s:s['appended_external_row'].__setitem__('type',2)),
        ('wrong container pin',lambda s:s['container'].__setitem__('sha256','0'*64)),
        ('wrong target pin',lambda s:s['target_container'].__setitem__('sha256','0'*64))]:
        modified=copy.deepcopy(spec);change(modified)
        try:target.expanded.extend_external_metadata(modified,targets,player)
        except (ValueError,RuntimeError):negatives.append({'name':name,'rejected':True})
        else:raise AssertionError('Invalid metadata extension accepted: '+name)
    try:target.configure_build(old.BUILD_RUN/'run-report.json',old.BUILD_RUN_SHA)
    except ValueError:negatives.append({'name':'known8 receipt rejected as179 build authority','rejected':True})
    else:raise AssertionError('Old8 native paths accepted')
    old_ast=ast.parse(Path(old.__file__).read_text());new_ast=ast.parse(Path(target.__file__).read_text())
    for name in ('probe_inputs','root_material_probes'):
        def shape(tree):return ast.dump(next(n for n in tree.body if getattr(n,'name',None)==name),include_attributes=False)
        target.need(shape(old_ast)==shape(new_ast),'Root-only compiled Class21 path preserves tested implementation: '+name)
    target.need(target.BUILD_RUN is None and target.BUILD_RUN_SHA is None,'No successful179 report fabricated or reused')
    target.need(target.native.pin(source)==source_pin and target.native.pin(destination)==destination_pin,'Known8 source containers untouched')
    result={'schema':'all179-restoration-orchestration-offline-controls/v1','status':'passed','positive_canonical_Shader_count':179,
        'actual_prior8_source_namespace':facts['container'],'actual_prior8_builtin_target':destination_pin,'actual_namespace_row_count_derived':expected_index,
        'known8_original_namespace_gap_and_complete_extension_checked':True,'negative_controls':negatives,'negative_count':len(negatives),
        'Root_only_typed_reader_path_AST_equal':True,'checked_tool_pins':pins,'new_orchestrator':target.native.pin(Path(target.__file__)),
        'actual179_BuildReport_material_reads_patch_UNTESTED':True,'Main_modified':False,'native_files_modified':False,
        'compiler_Unity_managed_reader_player_network_launched':False,'tool':target.native.pin(Path(__file__))}
    target.save(out/'offline-controls.json',result);print(json.dumps({'status':'passed','report':target.native.pin(out/'offline-controls.json'),'negative_count':len(negatives)}))


if __name__=='__main__':main()
