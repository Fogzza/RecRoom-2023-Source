"""Prepare eight Editor-only typed-null dependency inputs; never run managed code.

Original Release objects, canonical namespace mappings and existing projects stay
read-only. Root must explicitly run the already compiled converter afterwards.
"""
from pathlib import Path
import argparse
import copy
import datetime as dt
import json
import struct
import sys
import uuid
import original_shader_collection_editor_conversion as common
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
ROOT=common.ROOT
AR=ROOT/'AssetRecovery'
AUTHORITY=AR/'AllOriginalShaderEditorManifest-20261023T045350Z-9a03b91a/manifest.json'
AUTHORITY_SHA='a4ff950561f8572c9d0663703b4525957aa5c6053c1c40a1517aa300ff2d4f74'
EIGHT=AR/'OriginalShaderBuiltinIdentityFixture-20261023T061331Z-f84938e0/plan.json'
EIGHT_SHA='b00d27786b29e11dc7f04be59302702eec9d84bfbb7397fb915b0db6ea049799'
CONVERTER=AR/'OriginalShaderCollectionEditorConversion-20261023T030625Z-b13c1f0d'
CONVERTER_PLAN_SHA='1ef005434acee2445e846ecdaabf34f2b11a533be2f59abb591e70acabcabecd'
COMPILED_SHA='fe54b00de9e6289ffcc9b9574f24e3803c8501d3400d0836e7b21318c86b4926'
MATERIAL=AR/'BuiltinMaterialIdentityFixture-20261023T063117Z-90e9df99'
MATERIAL_RUN=MATERIAL/'Run-20261023T063133Z-5984f754'
MATERIAL_REPORT_SHA='d093505fa37422bd7d07401d111dfaff17add52af01bf26a146fe36e3f252869'
BUILTIN_TARGETS=MATERIAL_RUN/'BuiltinMaterialProof/builtin-native-Shader-targets.json'
BUILTIN_SHA='f251b079331157b25b1dc855d416f6563dfb3875c8f69a9615a5c2bdbf5be30a'
GUIDS=('dbe0ca40b3618e44e9ef2664c6daae98','249cb435a09f39e4e8f6de7901b294b4',
    '1ab811d499b5a8e48bfee808ef436fab','d2a5536c48f6e914f900eb13ea2f4d68',
    'f7efab54069bc444295f491f1ddf5b51','e8b204ae22658f64a88cf88172cef9c7',
    '7eda6ccbad6ba14488e843023e0d8dfa','988a943d64eaf3d4985396b2fe8febf6')


def need(v,message):
    if not v:raise ValueError(message)


def project(row):
    result=copy.deepcopy(row)
    for dep in result['dependencies']:dep['output_file_id']=dep['output_path_id']=0
    result['externals']=[]
    result['expected_direct_shader_dependencies']=[]
    validate(row,result)
    return result


def validate(original,projected):
    need(len(projected['dependencies'])==len(original['dependencies']),'Dependency count/order retained')
    for a,b in zip(original['dependencies'],projected['dependencies']):
        target=dict(a,output_file_id=0,output_path_id=0)
        need(b==target,'Only indexed typed output FileID/PathID words may become null')
    need(projected['externals']==projected['expected_direct_shader_dependencies']==[],'Editor-only projection has no dependency edges or external rows')
    restored=copy.deepcopy(projected)
    for key in ('dependencies','externals','expected_direct_shader_dependencies'):restored[key]=copy.deepcopy(original[key])
    need(restored==original,'All other canonical source fields and proofs stay exact')


def controls(rows):
    row=next(r for r in rows if len(r['dependencies'])>=2)
    good=project(row);checks=[]
    def mutation(name,edit):
        changed=copy.deepcopy(good);edit(changed)
        try:validate(row,changed)
        except (ValueError,KeyError,TypeError):checks.append({'name':name,'rejected':True})
        else:raise AssertionError('Projection authority mutation accepted: '+name)
    for key in ('guid','name','original_path_id','expected_ParsedForm_sha256','expected_shader_is_baked','source_index'):
        mutation(key,lambda r,k=key:r.__setitem__(k,'unauthorized'))
    for key in ('source','meta','current_asset'):
        mutation(key,lambda r,k=key:r[k].__setitem__('sha256','0'*64))
    mutation('program bytes',lambda r:r['expected_program_fields']['compressedBlob'].__setitem__('bytes',0))
    mutation('dependency index',lambda r:r['dependencies'][0].__setitem__('index',999))
    mutation('source FileID',lambda r:r['dependencies'][0].__setitem__('source_file_id',999))
    mutation('source PathID',lambda r:r['dependencies'][0].__setitem__('source_path_id',999))
    mutation('nonnull output FileID',lambda r:r['dependencies'][0].__setitem__('output_file_id',1))
    mutation('nonnull output PathID',lambda r:r['dependencies'][0].__setitem__('output_path_id',4800000))
    mutation('missing pointer',lambda r:r['dependencies'].pop())
    mutation('extra pointer',lambda r:r['dependencies'].append(copy.deepcopy(r['dependencies'][0])))
    mutation('retained external row',lambda r:r['externals'].append({'index':1}))
    mutation('retained Editor edge',lambda r:r['expected_direct_shader_dependencies'].append({'kind':'project'}))
    mutation('missing proof',lambda r:r['proofs'].pop())
    need(all(validate(r,project(r)) is None for r in rows),'All eight positive authority comparisons')
    return {'status':'passed','positive_complete_rows':len(rows),'negative_controls':checks,'negative_count':len(checks)}


def prepare(out):
    need(out.is_relative_to(AR) and out.name.startswith('OriginalShaderNullDependencyProjection-'),'Recovery-only new output')
    pinned=[(AUTHORITY,AUTHORITY_SHA),(EIGHT,EIGHT_SHA),(CONVERTER/'plan.json',CONVERTER_PLAN_SHA),
        (CONVERTER/'compile-report.json',COMPILED_SHA),(MATERIAL_RUN/'build-report.json',MATERIAL_REPORT_SHA),(BUILTIN_TARGETS,BUILTIN_SHA)]
    for path,wanted in pinned:need(common.digest(path)==wanted,'Reviewed source/receipt changed: '+path.name)
    authority=json.loads(AUTHORITY.read_bytes());eight=json.loads(EIGHT.read_bytes())
    need(authority['schema']=='resolved-original-Shader-Editor-collection/v1' and len(authority['shaders'])==179,'Full canonical source authority')
    need(tuple(eight['selected_GUIDs'])==GUIDS,'Exact previously imported eight GUIDs')
    by_guid={r['guid']:r for r in authority['shaders']};need(len(by_guid)==179,'Unique canonical GUIDs')
    originals=[by_guid[g] for g in GUIDS];checked=set();tail_proofs=[]
    def check(pin):
        key=(pin['path'],pin['sha256'])
        if key not in checked:common.check(pin);checked.add(key)
    for proof in authority['proofs']:check(proof)
    for row in originals:
        for proof in row['proofs']+[row['source'],row['meta'],row['current_asset']]:check(proof)
        data=Path(row['source']['path']).read_bytes();deps=row['dependencies'];tail=len(data)-12-len(deps)*12
        need(tail>=4 and struct.unpack_from('<i',data,tail)[0]==len(deps),'Exact bounded original dependency tail count')
        for index,dep in enumerate(deps):
            need(dep['index']==index and struct.unpack_from('<iq',data,tail+4+index*12)==(dep['source_file_id'],dep['source_path_id']),'Every canonical source pointer matches original raw words')
        need(data[-8:]==struct.pack('<iB3x',0,row['expected_shader_is_baked']),'Exact original empty texture map/baked/padding')
        tail_proofs.append({'guid':row['guid'],'source_sha256':row['source']['sha256'],'dependency_count':len(deps),
            'original_typed_pointer_words':[{'file_id':d['source_file_id'],'path_id':str(d['source_path_id'])} for d in deps],
            'output_pointer_words':[{'file_id':0,'path_id':'0'} for d in deps],'original_tail_count_and_every_pointer_word_exact':True})
    projected=[project(row) for row in originals]
    test=controls(originals);common.save(out/'offline-controls.json',test)
    manifest={'schema':authority['schema'],'status':'eight_Editor_only_null_dependency_projection_NOT_SHIPPING',
        'proofs':authority['proofs']+[common.pin(path) for path,_ in pinned],
        'shaders':projected,'Editor_projection_only':True,'original_Release_authority':common.pin(AUTHORITY),
        'original_dependency_graph_retained_in_canonical_manifest':True,'shipping_null_dependencies_authorized':False}
    common.save(out/'manifest.json',manifest)
    build=json.loads((MATERIAL_RUN/'build-report.json').read_bytes())
    need(build['status']=='Succeeded' and build['total_errors']==build['partial_constant_buffer_messages']==0
        and build['four_builtin_material_witnesses_verified'] and build['input_assets_and_metas_unchanged'],'Actual successful native Material build')
    targets=json.loads(BUILTIN_TARGETS.read_bytes());materials=[]
    need(targets['status']=='all_four_Editor_builtin_ids_resolved_through_actual_Material_GUID_and_full_typed_native_PPtr','Actual complete four-builtin native identity proof')
    for row in targets['builtin_targets']:
        witness=row['source_Editor_material_identity_witness'];path=MATERIAL/'Project'/witness['material_source_path']
        asset,meta=common.pin(path),common.pin(Path(str(path)+'.meta'))
        need(asset['sha256']==witness['asset_sha256'] and meta['sha256']==witness['meta_sha256'],'Already-native Material and original meta unchanged')
        need(witness in build['builtin_shader_material_witnesses'] and witness['builtin_guid']=='0000000000000000f000000000000000','Same actual native Editor Material witness')
        materials.append({'asset':asset,'meta':meta,'witness':witness,'fresh_build_native_target_must_be_rederived':True})
    need({r['witness']['builtin_local_id'] for r in materials}=={'6','7','46','10490'} and len(materials)==4,'Exact four genuine builtin identities')
    compile_plan=json.loads((CONVERTER/'plan.json').read_bytes());compiled=json.loads((CONVERTER/'compile-report.json').read_bytes())
    need(compiled['status']=='compiled_pure_converter','Existing converter genuinely compiled')
    for key in ('source','runner','guard','launcher','dotnet'):common.check(compile_plan[key])
    for pin in compile_plan['runtime']:common.check(pin)
    common.check(compiled['assembly'])
    manifest_pin=common.pin(out/'manifest.json')
    conversion_command=[sys.executable,'-B',str(HERE/'original_shader_collection_editor_conversion.py'),
        '--plan',str(CONVERTER/'plan.json'),'--plan-sha256',CONVERTER_PLAN_SHA,
        '--manifest',manifest_pin['path'],'--manifest-sha256',manifest_pin['sha256']]
    plan={'schema':'reviewed-eight-original-Shader-typed-null-Editor-projection-plan/v1','status':'prepared_no_managed_Editor_or_player_started',
        'fixture':str(out),'manifest':manifest_pin,'canonical_authority':common.pin(AUTHORITY),'imported_eight_plan':common.pin(EIGHT),
        'original_raw_tail_authority_checks':tail_proofs,'offline_controls':common.pin(out/'offline-controls.json'),
        'Root_only_next_conversion_command':conversion_command,'existing_compiled_converter':compiled['assembly'],
        'conversion_plan':common.pin(CONVERTER/'plan.json'),'conversion_compile_proof':common.pin(CONVERTER/'compile-report.json'),
        'conversion_bounds':{'job_bytes':512*1024**2,'reserve_bytes':int(1.5*1024**3),'assign_before_resume':True,'one_shader_per_owned_process':True},
        'Root_only_following_wrapper_command_template':[sys.executable,'-B',str(HERE/'stage_original_shader_collection_wrappers.py'),
            '--manifest',manifest_pin['path'],'--manifest-sha256',manifest_pin['sha256'],
            '--conversion-report','<ACTUAL_SUCCESSFUL_FRESH_CONVERSION_RUN_REPORT>','--conversion-report-sha256','<ACTUAL_REPORT_SHA256>'],
        'copied_native_Material_sources':materials,'actual_prior_builtin_identity_proof':common.pin(BUILTIN_TARGETS),
        'fresh_fixture_requirements':['Mixed serialization before import; exact eight binary wrappers/metas and four native Materials/metas unchanged before/after build.',
            'Each projected Shader native GUID/localID4800000; explicit null typed dependencies. ParsedForm and five GPU fields already proven by generated conversion and original byte authority.',
            'Validate each copied material.shader through actual TryGetGUIDAndLocalFileIdentifier magic GUID and exact6/7/46/10490; preserve Material GUID/localID2100000.',
            'Build Win64 Mono Development StrictMode D3D11; no original game code. Capture all Shader and Material packed API records from the SAME BuildReport.',
            'Fresh native GUID/range and Material full typed m_Shader proofs required; never reuse prior player pathIDs.',
            'Append exact original Release payloads with fully restored original indexed project/builtin PPtrs; all non-target bytes/metadata preserved. Do not run or ship null-dependency unpatched player.',
            'Root only: existing bounded streaming patcher with builtin-aware mapping then owned GPU probe; full logs zero partial constant buffer/errors.'],
        'uncertainties':['Actual BuildPipeline behavior with typed-null original cooked Shader dependencies is untested; ParsedForm UsePass/Fallback references or other native recursion may still block.',
            'BuildPlayer may discard programs as previously observed; authentic original Release postpatch remains mandatory.',
            'This eight-shader diagnostic does not establish full179 import/build memory, full URP pipeline, startup/login, or playable-game behavior.'],
        'Main_modified':False,'original_sources_or_existing_tools_changed':False,'compiler_Unity_game_network_launched':False,
        'tool':common.pin(Path(__file__))}
    common.save(out/'plan.json',plan)
    print(json.dumps({'plan':common.pin(out/'plan.json'),'manifest':manifest_pin,'controls':test['negative_count'],
        'typed_null_pointer_count':sum(len(r['dependencies']) for r in projected),'shader_count':len(projected),'native_Material_count':len(materials),
        'Root_only_next_conversion_command':conversion_command}))


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);args=ap.parse_args()
    if args._worker:return prepare(args._worker.resolve(strict=True))
    out=AR/('OriginalShaderNullDependencyProjection-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-pure-eight-Shader-null-Editor-projection-preparation/v1','status':'starting','phases':[],
        'Main_modified':False,'managed_compiler_Unity_game_network_launched':False}
    try:
        guard.bounded([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],common.WS,out,
            'pure-eight-projection-authority-admission-and-controls',256*1024**2,60,report)
        report['status']='pure_projection_plan_prepared_no_managed_child_started';report['prepared_plan']=common.pin(out/'plan.json')
    except BaseException as error:report.update(status='held',error=repr(error))
    finally:guard.save(out,report);print(json.dumps({'status':report['status'],'receipt':common.pin(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status'].startswith('pure_') else 1


if __name__=='__main__':raise SystemExit(main())
