"""Pure179 proposal/manifest only. No converter, compiler, Editor or player launch."""
from pathlib import Path
import argparse
import copy
import datetime as dt
import json
import struct
import sys
import uuid
import prepare_original_shader_null_dependency_projection as prior
import original_shader_collection_editor_conversion as common
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
AR=prior.AR
SMALL=AR/'OriginalShaderNullDependencyProjection-20261023T064548Z-76a33043/plan.json'
SMALL_SHA='282903a51ab8da009be418e08a88193830d2d613e7a90e779f5b01d41fd7eb91'
SMALL_BUILD=AR/'OriginalShaderNullDependencyFixture-20261023T065310Z-47a193e1/Run-20261023T065347Z-d8ac1778/run-report.json'
SMALL_BUILD_SHA='79339267677288296effdd4ed91da35eee59f00286e2df1c00a8c8876d8d61e2'
PROBUILDER=AR/'ProBuilderNativeFallbackGPU-20261023T072935Z-796b2027'


def save(path,value):
    with Path(path).open('x',encoding='utf-8') as stream:json.dump(value,stream,indent=2);stream.write('\n')


def aggregate_gate():
    paths=list(PROBUILDER.glob('Runtime-*/all-eight-aggregate.json'))
    found=[]
    for path in paths:
        data=json.loads(path.read_bytes())
        if data.get('status')=='all8_original_Shader_identities_original_or_proven_fallback_counts_pass0_and_D3D11_readback_verified':
            found.append((path,data))
    if not found:return {'status':'HOLD_until_Root_actual_all8_aggregate_pass','actual_aggregate':None}
    guard.need(len(found)==1,'One unique actual eight-case aggregate required')
    path,data=found[0];receipt=json.loads((path.parent/'run-report.json').read_bytes())
    guard.need(receipt['status']=='ProBuilder_original_builtin46_fallback_GPU_verified_all8_aggregate_complete'
        and receipt['aggregate']==common.pin(path) and len(data['results'])==8
        and {r['guid'] for r in data['results']}==set(prior.GUIDS),'Actual complete eight-case GPU aggregate')
    for row in data['results']:
        common.check(row['runtime_report']);common.check(row['full_player_log'])
        observed=row['runtime'];guard.need(observed['status']=='exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed'
            and observed['partial_constant_buffer_messages']==0 and not observed['shader_error_lines'],'Every original case passed actual source/native-derived runtime gates')
    return {'status':'actual_all8_original_payload_GPU_aggregate_passed','actual_aggregate':common.pin(path),'actual_receipt':common.pin(path.parent/'run-report.json'),
        'terrain_Lit_is_original_FallbackError_not_terrain_fidelity':True,'full_URP_or_gameplay_proven':False}


def prepare(out):
    guard.need(common.digest(prior.AUTHORITY)==prior.AUTHORITY_SHA and common.digest(SMALL)==SMALL_SHA
        and common.digest(SMALL_BUILD)==SMALL_BUILD_SHA,'Exact canonical179 and actual successful8 fixture basis')
    authority=json.loads(prior.AUTHORITY.read_bytes());small=json.loads(SMALL.read_bytes())
    guard.need(authority['schema']=='resolved-original-Shader-Editor-collection/v1' and len(authority['shaders'])==179,'Complete exact original179 manifest')
    rows=authority['shaders'];ids=[r['guid'] for r in rows];guard.need(len(set(ids))==179,'Unique original MainGUID identities')
    seen=set();raw_tail_proofs=[];project_edges=0;builtin_edges=0;null_pointers=0
    def check(pin):
        key=(pin['path'],pin['sha256'])
        if key not in seen:common.check(pin);seen.add(key)
    for pin in authority['proofs']:check(pin)
    for row in rows:
        for pin in row['proofs']+[row['source'],row['meta'],row['current_asset']]:check(pin)
        guard.need(row['expected_shader_is_baked'] and row['expected_program_fields']['Platforms']==[4],'Exact original cooked D3D11 source contract')
        data=Path(row['source']['path']).read_bytes();deps=row['dependencies'];tail=len(data)-12-12*len(deps)
        guard.need(0<len(data)<=8*1024**2 and tail>=4 and struct.unpack_from('<i',data,tail)[0]==len(deps)
            and data[-8:]==b'\0\0\0\0\1\0\0\0','Entire bounded original dependency/textures0/baked1 tail')
        for index,dep in enumerate(deps):
            guard.need(dep['index']==index and struct.unpack_from('<iq',data,tail+4+index*12)==(dep['source_file_id'],dep['source_path_id']),'Every original typed pointer source word/order must match canonical authority')
            if dep['output_file_id']==0:
                guard.need(dep['output_path_id']==0,'Canonical null remains null');null_pointers+=1;continue
            external=row['externals'][dep['output_file_id']-1]
            if external['kind']=='project':
                guard.need(external['target_guid'] in ids and dep['output_path_id']==4800000,'Every original project edge closes within179')
                project_edges+=1
            else:
                guard.need(external['kind']=='builtin' and external['target_guid']=='0000000000000000f000000000000000'
                    and str(dep['output_path_id']) in ('6','7','46','10490'),'Only four independently proved original builtin identities')
                builtin_edges+=1
        raw_tail_proofs.append({'guid':row['guid'],'source_sha256':row['source']['sha256'],'source_bytes':len(data),'typed_dependency_count':len(deps),
            'every_original_typed_pointer_word_and_order_verified':True,'nonmodifiable_textures':0,'shader_is_baked':True})
    guard.need(project_edges==77 and builtin_edges==27 and null_pointers==0,'Exactly104 original edges=77project+27builtin')
    projected=[prior.project(row) for row in rows]
    for original,candidate in zip(rows,projected):prior.validate(original,candidate)
    control=prior.controls(rows);control['positive_complete_rows']=179
    save(out/'projection-offline-controls.json',control)
    gate=aggregate_gate()
    proofs=authority['proofs']+[common.pin(prior.AUTHORITY),common.pin(SMALL),common.pin(SMALL_BUILD),common.pin(out/'projection-offline-controls.json')]
    if gate['actual_aggregate']:proofs+=[gate['actual_aggregate'],gate['actual_receipt']]
    manifest={'schema':authority['schema'],'status':'all179_Editor_only_typed_null_dependency_projection_NOT_SHIPPING',
        'proofs':proofs,'shaders':projected,'Editor_projection_only':True,'shipping_null_dependencies_authorized':False,
        'original_Release_authority':common.pin(prior.AUTHORITY),'original_dependency_graph_retained_in_canonical_manifest':True,
        'scope':'Only104 explicitly indexed outputFileID/PathID words become zero. All other179 row fields, source pins, ParsedForm/program expectations, baked state and originalmetas unchanged.'}
    save(out/'manifest.json',manifest)
    sources=sum(row['source']['bytes'] for row in rows);guard.need(sources<=96*1024**2,'Known original179 bounded aggregate payload budget')
    max_source=max(row['source']['bytes'] for row in rows)
    material_sources=copy.deepcopy(small['copied_native_Material_sources'])
    for row in material_sources:check(row['asset']);check(row['meta'])
    for key in ('canonical_authority','actual_prior_builtin_identity_proof'):check(small[key])
    save(out/'original-tail-authority-controls.json',raw_tail_proofs)
    build_cap=6*1024**3;reserve=int(1.5*1024**3);available=guard.memory().available_commit
    plan={'schema':'pure-proposal-all179-original-cooked-Shader-null-Editor-projection-expansion/v1',
        'status':'proposal_only_no_converter_compiler_Editor_or_player_started','fixture':str(out),'aggregate_gate':gate,
        'manifest':common.pin(out/'manifest.json'),'canonical_original_authority':common.pin(prior.AUTHORITY),
        'original_count':179,'typed_dependency_words_to_zero_only_in_Editor':104,'original_project_links_to_restore':77,'original_builtin_links_to_restore':27,
        'all_original_payload_bytes':sources,'largest_original_payload_bytes':max_source,
        'source_namespace_count':len({str(row['original_source_identity']['source_path']) for row in rows}),
        'all179_entire_row_comparisons_except_authorized_Editor_output_graph_equal':True,
        'controls':common.pin(out/'projection-offline-controls.json'),'every104_original_raw_PPtr_and_tail_verified':common.pin(out/'original-tail-authority-controls.json'),
        'copied_native_Material_sources':material_sources,'already_compiled_converter':small['existing_compiled_converter'],
        'conversion_plan':small['conversion_plan'],'conversion_compile_proof':small['conversion_compile_proof'],
        'Root_next_conversion_after_gate_command':[sys.executable,'-B',str(HERE/'original_shader_collection_editor_conversion.py'),
            '--plan',small['conversion_plan']['path'],'--plan-sha256',small['conversion_plan']['sha256'],
            '--manifest',str(out/'manifest.json'),'--manifest-sha256',common.digest(out/'manifest.json')],
        'conversion_cap_bytes_each':512*1024**2,'conversion_one_original_per_fresh_owned_process':True,'assign_before_resume_required':True,
        'fresh_build_proposal':{'location':'NEW isolated Project under AssetRecovery; no Main or published source project changes',
            'job_cap_bytes':build_cap,'commit_reserve_bytes':reserve,'minimum_available_commit_before_launch_bytes':build_cap+reserve,
            'current_read_only_available_commit_bytes':available,'current_commit_admission_would_pass':available>=build_cap+reserve,
            'physical_memory_and_CPU_are_not_reserved_by_this_proposal':True,'Editor_version':'2020.3.33f1','target':'StandaloneWindows64','backend':'Mono2x',
            'flags':'Development|StrictMode','graphics':'D3D11','serialization':'Mixed before initial import',
            'input_shaders':179,'input_Materials':4,'expected_unique_project_Shader_GUID_native_placements':179,
            'builder_required_changes':['Fresh generic sibling of successful8 null-dependency builder; exact canonical179 GUID set and counts pinned before launch.',
                'Copy179 binary wrappers with original metas from successful fresh generated conversions. All exact ParsedForm/five GPU fields and baked bits retained.',
                'Require every Editor resolved dependency graph empty; the104 original edges are restored only in the packagedRelease data.',
                'Copy4 native Material assets/metas unchanged and verify actual magicGUID+6/7/46/10490 and Material localIDs.',
                'Capture all179 Shader and4Material packed records with files/id/absoluteoffset/size/GUID/path from SAME actual BuildReport.',
                'Whole Editorlog0CB/CS/nativeShadererrors; original/binary/meta pins before/after; no original gamecode/scenes imported.']},
        'fresh_postbuild_proposal':['Re-derive179Class48 placements using actual GUID/API/native table/range agreement; no source name or previous nativeID reuse.',
            'Extract4actualClass21objects; Root runs alreadycompiled whole typed reader; derive each exact builtinClass48 target from m_Shader.',
            'Use unchanged full original179 Release objects and complete generated full-read proofs as source; restore77project+27builtin pointers through actual new namespaces.',
            'Do not assume FileID2, metadata size512 or even one container. Derive existing row order/count, target container, metadata zero gap and exact appended row(s) from THIS build.',
            'If metadata gap cannot hold needed rows without data relocation, HOLD for a separately reviewed relocation algorithm; no guessed insertion or SDK rewrite.',
            'Streaming append-only payloads bounded8MiB each/256MiBaggregate; only targetobject ranges/header size/explicit namespace metadata windows may change.',
            'Reparse all emitted headers/tables; compare every nontarget range/byte; re-read every179mapped payload exactsource+104typed pointer writes before any player launch.',
            'Runtime memory and shader-selection expectations require a separate reviewed plan; a179build alone proves neither fullURP pipeline nor recoveredgameplay/login.'],
        'Main_modified':False,'original_or_existing_tool_or_publication_files_modified':False,'compiler_Unity_managed_reader_game_network_launched':False,
        'tool':common.pin(Path(__file__))}
    save(out/'proposal.json',plan)
    print(json.dumps({'proposal':common.pin(out/'proposal.json'),'manifest':plan['manifest'],'aggregate_gate':gate['status'],
        'Shaders':179,'Editor_only_null_PPtrs':104,'original_payload_bytes':sources,'max_source_bytes':max_source,'current_commit_admission':available>=build_cap+reserve}))


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);args=ap.parse_args()
    if args._worker:return prepare(args._worker.resolve(strict=True))
    out=AR/('All179ShaderNullDependencyProposal-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-pure-all179-null-dependency-proposal/v1','status':'starting','phases':[],'Main_modified':False,'compiler_Unity_managed_reader_game_network_launched':False}
    try:
        guard.bounded([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],guard.WS,out,'pure179-authority-pins-104typed-tail-projection-and-controls',256*1024**2,60,report);report['status']='passed'
    except BaseException as exc:report.update(status='held',error=repr(exc))
    guard.save(out,report);print(json.dumps({'status':report['status'],'receipt':common.pin(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
