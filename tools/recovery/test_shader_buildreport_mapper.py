"""Offline controls against the actual successful retained AG/Fallback build."""
from pathlib import Path
import argparse
import copy
import contextlib
import io
import json
import sys
import map_shader_buildreport as mapper

ROOT = mapper.WS / 'Recovery/RecRoom-2023-04-18/AssetRecovery'
FIXTURE = ROOT / 'OriginalAGDependencyFixture-20261023T030326Z-a1848347'
RUN = FIXTURE / 'Run-20261023T030352Z-c5544356'
RECEIPT_SHA = 'de27394d596fc5415485fcfd07dc0ecadd9930824f5a9912b2df4ee9725ab5ea'
COLLECTION = ROOT / 'OriginalShaderEditorWrapperCollection-20261023T030931Z-fb6fcab2/wrapper-collection.json'
COLLECTION_SHA = '95b8dfb4d5a2923bf032326bdf713738cee9168f65277be04f5eabae6f944c4d'


def checked(row):
    mapper.need(mapper.pin(row['path']) == row, 'Exact source pin required')


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument('--out', required=True, type=Path)
    args = ap.parse_args()
    out = args.out.resolve(strict=True)
    mapper.need(mapper.pin(RUN / 'run-report.json')['sha256'] == RECEIPT_SHA, 'Actual successful AG build receipt changed')
    receipt = json.loads((RUN / 'run-report.json').read_bytes())
    mapper.need(receipt['build']['result']['status'] == 'Succeeded'
                and receipt['partial_constant_buffer_full_log_count'] == 0
                and receipt['phases'][-1]['exit_code'] == 0, 'Actual successful CLI/build/zeroCB source required')
    mapper.need(mapper.pin(COLLECTION)['sha256'] == COLLECTION_SHA, 'Proven source-backed wrapper collection changed')
    collection = json.loads(COLLECTION.read_bytes())
    config = json.loads((FIXTURE / 'config.json').read_bytes())
    expected, evidence = [], []
    for row in collection['shaders']:
        checked(row['proof'])
        proof = json.loads(Path(row['proof']['path']).read_bytes())
        checked(proof['conversion'])
        conversion = json.loads(Path(proof['conversion']['path']).read_bytes())
        conf = next(r for r in config['shaders'] if r['guid'] == row['guid'])
        mapper.need(conversion['guid'] == row['guid'], 'Converter must bind textual GUID')
        expected.append({'guid': row['guid'], 'source_path': conf['path'],
                         'native_guid_hex': conversion['native_GUID_hex'], 'count': 1})
        evidence += [row['proof'], proof['conversion']]
    decoded = mapper.decode_report(FIXTURE / 'Project/Library/LastBuild.buildreport')
    capture = mapper.capture_from_native(decoded, expected)
    player = RUN / 'Player'
    result = mapper.corroborate(capture, expected, player)
    for row in result['mappings']:
        old = next(v for v in receipt['packaged_Shader_ranges_for_followup'].values()
                   if str(v['object']['path_id']) == row['path_id'])
        mapper.need(row['container'] == old['container'] and row['raw_sha256'] == old['raw']['sha256'],
                    'Independent earlier native table/raw payload witness must agree')
    cases = [{'name': 'actual_AG_and_Fallback_GUID_id_absolute_offset_size', 'passed': True}]
    def reject(name, mutate):
        changed = copy.deepcopy(capture)
        mutate(changed)
        try:
            mapper.corroborate(changed, expected, player)
        except ValueError as exc:
            cases.append({'name': name, 'passed': True, 'rejection': str(exc)})
        else:
            raise ValueError('Negative control unexpectedly passed: ' + name)
    reject('wrong_offset', lambda d: d['shaders'][0].update(offset=str(int(d['shaders'][0]['offset'])+1)))
    reject('wrong_size', lambda d: d['shaders'][0].update(packed_size=str(int(d['shaders'][0]['packed_size'])-1)))
    reject('wrong_native_id', lambda d: d['shaders'][0].update(id='999999'))
    reject('wrong_source_GUID', lambda d: d['shaders'][0].update(source_guid='0'*32))
    reject('wrong_source_path', lambda d: d['shaders'][0].update(source_path='Assets/Resources/Another.asset'))
    reject('duplicate_packed_target', lambda d: d['shaders'].append(copy.deepcopy(d['shaders'][0])))
    reject('missing_expected_target', lambda d: d['shaders'].pop())
    reject('unknown_BuildFile_id', lambda d: d['shaders'][0].update(file_id='999999'))
    reject('wrong_packed_shortPath', lambda d: d['shaders'][0].update(short_path='../globalgamemanagers.assets'))
    reject('noncanonical_integer', lambda d: d['shaders'][0].update(id='04'))
    reject('integer_overflow', lambda d: d['shaders'][0].update(offset=str(2**64)))
    reject('duplicate_BuildFile_id', lambda d: d['files'].append(copy.deepcopy(d['files'][0])))
    reject('wrong_asset_type', lambda d: d['shaders'][0].update(type='UnityEngine.Material'))
    reject('outside_player_path', lambda d: next(r for r in d['files'] if r['id']==d['shaders'][0]['file_id']).update(path=str(FIXTURE/'Project/Library/LastBuild.buildreport')))
    parsed, _ = mapper.native(Path(result['mappings'][0]['container']['path']))
    nonshader = next(o for o in parsed['objects'] if parsed['types'][o['type_index']]['class_id'] != 48)
    reject('native_nonShader_type', lambda d: d['shaders'][0].update(id=str(nonshader['path_id']), offset=str(nonshader['offset']), packed_size=str(nonshader['size'])))
    mapper.need(mapper.extract_capture({'packed_shader_capture': capture}) == capture
                and mapper.extract_capture({'packed_shader_build_report': capture}) == capture
                and mapper.extract_capture(capture) == capture, 'Both actual builder field aliases and bare capture must work')
    cases.append({'name': 'both_builder_capture_field_aliases', 'passed': True})
    try:
        mapper.extract_capture({'packed_shader_capture': capture, 'packed_shader_build_report': capture})
    except ValueError:
        cases.append({'name': 'ambiguous_nested_capture_refused', 'passed': True})
    else:
        raise ValueError('Ambiguous nested capture accepted')
    # End-to-end persisted artifacts; inputs are read-only and all names unique.
    artifacts = {'decoded-report.json': decoded, 'actual-native-report-capture.json': capture,
                 'expected-project-Shaders.json': expected, 'mapping-report.json': result}
    for name, value in artifacts.items():
        with (out/name).open('x', encoding='utf-8') as stream:
            json.dump(value, stream, indent=2); stream.write('\n')
    for alias in ('packed_shader_capture', 'packed_shader_build_report'):
        api_source = out/(alias+'-input.json')
        api_source.write_text(json.dumps({alias: capture}), encoding='utf-8')
        cli_out = out/(alias+'-CLI-mapping.json')
        previous = sys.argv
        try:
            sys.argv = [str(Path(mapper.__file__)), '--api-report', str(api_source), '--expected', str(out/'expected-project-Shaders.json'),
                        '--player-root', str(player), '--out', str(cli_out)]
            with contextlib.redirect_stdout(io.StringIO()) as text:
                mapper.main()
            message = json.loads(text.getvalue())
            mapper.need(message['object_or_mapping_count'] == 2 and json.loads(cli_out.read_bytes()) == result,
                        'Full API mapper CLI output/count/status must complete')
        finally:
            sys.argv = previous
        cases.append({'name': 'full_CLI_'+alias, 'passed': True})
    controls = {'schema': 'actual-native-Shader-BuildReport-mapper-offline-controls/v1', 'status': 'passed',
        'controls': cases, 'control_count': len(cases), 'mapper': mapper.pin(Path(mapper.__file__)),
        'control_source': mapper.pin(Path(__file__)), 'actual_successful_build_receipt': mapper.pin(RUN/'run-report.json'),
        'source_backed_native_GUID_evidence': evidence,
        'actual_CSharp_API_capture_executed': False,
        'result': mapper.pin(out/'mapping-report.json'),
        'native_Report_fields_corroborated': True, 'Main_modified': False,
        'Unity_launched': False, 'compiler_launched': False, 'production_credentials_used': False}
    with (out/'offline-controls.json').open('x', encoding='utf-8') as stream:
        json.dump(controls, stream, indent=2); stream.write('\n')
    print(json.dumps({'status': 'passed', 'controls': len(cases), 'report': mapper.pin(out/'offline-controls.json')}))


if __name__ == '__main__':
    main()
