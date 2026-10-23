"""Prepare/Root-read actual Material-proved builtin46 native Class48; no compilation."""
from pathlib import Path
import argparse
import datetime as dt
import json
import os
import sys
import uuid
import map_shader_buildreport as native
import patch_original_shader_collection_with_builtins as strict
import orchestrate_eight_original_shader_restoration as context
import prepare_eight_original_shader_gpu_fixture as forms
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
BASE=context.AR/'EightOriginalShaderRestoration-20261023T065927Z-54a6afac'
READER=context.AR/'OriginalShaderModelProbe-20261022T192955Z-851f2959'
HOST_SHA='2a5d74cc85591844d7d230042eec42308bc5a8abfcfae677464cc5191180e594'
SOURCE_SHA='c10e692d0d482e9a55ede144f2ceb89e7622d7dce4bcc8b9af7adadc345858c3'
COMPILE_SHA='e99d06254cd16e817a20e19cedecbedf8005c19608d7141d80461a9b9c6c8f97'


def save(path,obj):
    with Path(path).open('x',encoding='utf-8') as stream:json.dump(obj,stream,indent=2);stream.write('\n')


def reader_inputs():
    native.need(guard.sha(READER/'report.json')==COMPILE_SHA and guard.sha(READER/'OriginalShaderObjectProbe.dll')==HOST_SHA
        and guard.sha(READER/'OriginalShaderObjectProbe.cs')==SOURCE_SHA,'Exact already compiled and exercised generated Class48 reader')
    old=json.loads((READER/'report.json').read_bytes())
    native.need(old['status']=='parsed' and all(row['exit_code']==0 for row in old['phases']),'Actual generic reader original compile/read proof')
    for row in old['dependencies']:
        guard.checked(row);native.need(guard.sha(READER/Path(row['path']).name)==row['sha256'],'Exact matching generated-model runtime copy')
    return [native.pin(path) for path in sorted(READER.glob('*.dll'))]+[native.pin(READER/'OriginalShaderObjectProbe.runtimeconfig.json'),native.pin(READER/'OriginalShaderObjectProbe.deps.json')]


def prepare(out):
    inputs=reader_inputs()
    mapping=native.pin(BASE/'NativeMapping/builtin-native-Shader-targets.json')
    player=context.BUILD_RUN/'Player';targets=strict.load_builtin_targets({'builtin_material_mapping_report':mapping},player)
    target=targets['46'];source=context.check(target['container'])
    parsed,layout,obj,typ=strict.read_object(source,target,48,8*1024**2)
    native.need(target['path_id']=='7' and target['byte_size']=='56648' and target['raw_sha256']=='a4cf9cf5b038d7d16aaf19fb9216206033f642cc4faf6795f07bdc63cca89537','Exact same actual native builtin46 origin')
    raw=out/'MaterialProvedBuiltin46-NativeClass48.bin'
    with source.open('rb') as stream:stream.seek(obj['offset']);data=stream.read(obj['size'])
    native.need(native.digest(data)==target['raw_sha256'],'Whole exact builtin Shader native object')
    with raw.open('xb') as stream:stream.write(data)
    plan={'schema':'actual-native-builtin46-full-ReadRelease-pass-layout/v1','status':'prepared_no_managed_reader_started',
        'fixture':str(out),'actual_builtin_Material_chain':mapping,'target':target,'raw':native.pin(raw),
        'reader':native.pin(READER/'OriginalShaderObjectProbe.dll'),'source_snapshot':native.pin(READER/'OriginalShaderObjectProbe.cs'),
        'compile_read_receipt':native.pin(READER/'report.json'),'runtime_pins':inputs,'dotnet':native.pin(Path('C:/Program Files/dotnet/dotnet.exe')),
        'tool':native.pin(Path(__file__)),'Root_only_command':[sys.executable,'-B',str(Path(__file__)),'--plan',str(out/'plan.json'),'--plan-sha256','<PIN_PLAN>','--run-reader'],
        'selection':'actualMaterialGUID->fulltypedClass21.m_Shader->nativeClass48ID7; no name used to choose object',
        'expected_name_validation_only':'Standard','shader_pass_expectation_derived_from_failed_GPU_observation':False,
        'Main_modified':False,'Unity_compiler_player_network_launched':False}
    save(out/'plan.json',plan)
    print(json.dumps({'plan':native.pin(out/'plan.json'),'raw':native.pin(raw),'Root_only_command':plan['Root_only_command']}))


def run_reader(path,wanted):
    native.need(guard.sha(path)==wanted,'Reviewed exact builtin46 native-read plan')
    plan=json.loads(path.read_bytes());out=path.parent.resolve(strict=True)
    native.need(plan['schema']=='actual-native-builtin46-full-ReadRelease-pass-layout/v1' and out.is_relative_to(context.AR)
        and out.name.startswith('BuiltStandardNativePassProof-'),'Exact isolated native read')
    for row in [plan[k] for k in ('reader','source_snapshot','compile_read_receipt','dotnet','tool','raw','actual_builtin_Material_chain')]+plan['runtime_pins']:guard.checked(row)
    reader_inputs();targets=strict.load_builtin_targets({'builtin_material_mapping_report':plan['actual_builtin_Material_chain']},context.BUILD_RUN/'Player')
    native.need(targets['46']==plan['target'],'Same actual builtin46 identity chain')
    target=out/'NativeStandardModel';report={'schema':'ROOT-bounded-native-builtin46-Class48-read/v1','status':'starting','phases':[],'plan':native.pin(path)}
    try:
        env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1')
        guard.bounded([plan['dotnet']['path'],plan['reader']['path'],plan['raw']['path'],plan['raw']['sha256'],plan['target']['path_id'],'Standard',str(target)],out,out,
            'actual-native-builtin46-full-generated-Class48-read',256*1024**2,30,report,env)
        actual=json.loads((target/'report.json').read_bytes())
        native.need(actual['status']=='parsed_entire_original_object' and actual['consumed_bytes']==actual['total_bytes']==plan['raw']['bytes']
            and actual['source_sha256']==plan['raw']['sha256'] and actual['actual_name']=='Standard','Entire actual built Standard typed read')
        native_pin=native.pin(target/'ParsedForm.yaml');native.need(native_pin['sha256']==actual['parsed_form']['sha256'],'Actual built Standard complete form')
        facts=forms.form_facts(native_pin)
        editor=context.AR/'GenuineEditorBuiltinShaderIdentities-20261023T031035Z-a16ac0b1/Model-46/ParsedForm.yaml'
        editor_facts=forms.form_facts(native.pin(editor))
        delta={'schema':'actual-player-vs-genuine-Editor-builtin46-typed-pass-layout/v1','status':'native_and_Editor_ParsedForms_independently_read_counts_recorded',
            'native_model_report':native.pin(target/'report.json'),'native_ParsedForm_facts':facts,'genuine_Editor_ParsedForm_facts':editor_facts,
            'actual_native_Material_identity_chain':plan['actual_builtin_Material_chain'],'entire_native_bytes_consumed':True,
            'first_native_subshader_pass_count':facts['subshaders'][0]['pass_count'],
            'first_Editor_subshader_pass_count':editor_facts['subshaders'][0]['pass_count'],
            'GPU_observation_used_to_set_expected_count':False,'runtime_or_GPU_launched':False,'Main_modified':False}
        save(out/'native-vs-Editor-pass-layout.json',delta)
        report.update(status='actual_native_builtin46_entire_Class48_and_pass_layout_proven',result=native.pin(out/'native-vs-Editor-pass-layout.json'))
    except BaseException as exc:report.update(status='held',error=repr(exc))
    guard.save(out,report);print(json.dumps({'status':report['status'],'receipt':native.pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}))
    return 0 if report['status'].startswith('actual_native_') else 1


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);ap.add_argument('--plan',type=Path);ap.add_argument('--plan-sha256');ap.add_argument('--run-reader',action='store_true');args=ap.parse_args()
    if args._worker:return prepare(args._worker.resolve(strict=True))
    if args.run_reader:
        native.need(args.plan and args.plan_sha256,'Root explicit plan required');return run_reader(args.plan.resolve(strict=True),args.plan_sha256)
    native.need(not args.plan,'No managed reader without explicit Root switch')
    out=context.AR/('BuiltStandardNativePassProof-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-pure-actual-builtin46-native-extraction/v1','status':'starting','phases':[]}
    try:
        guard.bounded([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],guard.WS,out,'pure-exact-Material46-to-native-Class48-extraction',256*1024**2,30,report);report['status']='passed'
    except BaseException as exc:report.update(status='held',error=repr(exc))
    save(out/'prepare-run-report.json',report);print(json.dumps({'status':report['status'],'receipt':native.pin(out/'prepare-run-report.json'),'error':report.get('error')}))
    return 0 if report['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
