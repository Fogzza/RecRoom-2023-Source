"""Prepare or Root-run the exact179 Editor-only Shader projection build.

Preparation copies successful generated wrappers and four native Materials.
Only --run may launch compiler/Unity; no player or recovered game code runs.
Original Release programs and all104 dependencies must be restored after build.
"""
from pathlib import Path
import argparse, datetime as dt, json, re, shlex, uuid
import run_windows_development_define_probe as guard
import run_original_shader_null_dependency_fixture as small
import prepare_original_shader_null_dependency_projection as projection

HERE=Path(__file__).resolve().parent
ROOT=small.ROOT
CAP=6*1024**3
SCHEMA='prepared-all179-original-Shader-null-Editor-projection-build/v1'
SMALL_SHA='806b319396d647bd5562b21caa4235348cd41ae13d82dc63d0ad28bceb7bff07'
AGGREGATE_SHA='258aab3483c3921068ea4c773e43c15d761924e9772e725a294c305e96d8b20f'
AGGREGATE_RECEIPT_SHA='21c9cd308e3747798e09e8a05491f2bac8e35946aeaea5f89b6d99e603b51cb4'
pin,save=small.pin,small.save


def authority():
    guard.need(guard.sha(projection.AUTHORITY)==projection.AUTHORITY_SHA,'Exact canonical179 authority')
    value=json.loads(projection.AUTHORITY.read_bytes())
    guard.need(len(value['shaders'])==179 and len({r['guid'] for r in value['shaders']})==179,'179 unique original identities')
    return value


def verify_aggregate(proposal):
    gate=proposal['aggregate_gate']
    guard.need(gate['status']=='actual_all8_original_payload_GPU_aggregate_passed'
        and gate['actual_aggregate']['sha256']==AGGREGATE_SHA and gate['actual_receipt']['sha256']==AGGREGATE_RECEIPT_SHA,
        'Actual complete eight-Shader native-payload/GPU gate is required')
    for key in ('actual_aggregate','actual_receipt'):guard.checked(gate[key])
    data=json.loads(Path(gate['actual_aggregate']['path']).read_bytes())
    receipt=json.loads(Path(gate['actual_receipt']['path']).read_bytes())
    guard.need(data['status']=='all8_original_Shader_identities_original_or_proven_fallback_counts_pass0_and_D3D11_readback_verified'
        and len(data['results'])==8 and {r['guid'] for r in data['results']}==set(projection.GUIDS)
        and receipt['status']=='ProBuilder_original_builtin46_fallback_GPU_verified_all8_aggregate_complete'
        and receipt['aggregate']==gate['actual_aggregate'],'Exact actual aggregate identities and receipt')
    for row in data['results']:
        guard.checked(row['runtime_report']);guard.checked(row['full_player_log'])
        observed=json.loads(Path(row['runtime_report']['path']).read_bytes())
        guard.need(observed==row['runtime'] and observed['status']=='exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed'
            and observed['partial_constant_buffer_messages']==0 and not observed['shader_error_lines'],'Every exact8 source/native-derived count and GPU case passed')


def validate_manifest(manifest,original):
    guard.need(manifest['schema']=='resolved-original-Shader-Editor-collection/v1' and manifest['Editor_projection_only'] is True
        and manifest['shipping_null_dependencies_authorized'] is False
        and manifest['original_Release_authority']==pin(projection.AUTHORITY)
        and [r['guid'] for r in manifest['shaders']]==[r['guid'] for r in original['shaders']],
        'Exact ordered canonical179 Editor-only projection required')
    for before,after in zip(original['shaders'],manifest['shaders']):projection.validate(before,after)
    guard.need(sum(len(r['dependencies']) for r in manifest['shaders'])==104,'Exactly104 explicitly typed output words only')


def select_inputs(manifest,wrappers,manifest_sha):
    original=authority();validate_manifest(manifest,original)
    guard.need(wrappers['schema']=='original-Shader-Editor-wrapper-collection/v1'
        and wrappers['status']=='all_mapped_original_Shader_Editor_wrappers_verified_native_import_unproven'
        and wrappers['manifest']['sha256']==manifest_sha and wrappers['count']==len(wrappers['shaders'])==179,
        'Actual successful complete179 wrapper collection required')
    guard.checked(wrappers['manifest']);guard.checked(wrappers['conversion_report'])
    conversion=json.loads(Path(wrappers['conversion_report']['path']).read_bytes())
    guard.need(conversion['status']=='all_manifest_original_Shader_Editor_conversions_verified'
        and conversion['manifest']==wrappers['manifest'] and len(conversion['results'])==179
        and {r['guid'] for r in conversion['results']}=={r['guid'] for r in manifest['shaders']},'Actual179 generated conversions must match this exact projected manifest')
    guard.need(all(r['exit_code']==0 and r['owned_child_exit_confirmed'] and r['launcher']['membership_verified_before_resume'] for r in conversion['phases']),
        'Every generated conversion ran successfully in its owned suspended-before-assign job')
    mapped={r['guid']:r for r in wrappers['shaders']}
    guard.need(len(mapped)==179 and set(mapped)=={r['guid'] for r in manifest['shaders']},'Every canonical identity wrapped exactly once')
    rows=[]
    for original in manifest['shaders']:
        row=mapped[original['guid']]
        for key in ('asset','meta','proof'):guard.checked(row[key])
        proof=json.loads(Path(row['proof']['path']).read_bytes())
        guard.need(row['name']==original['name'] and row['meta']['sha256']==original['meta']['sha256']
            and row['expected_direct_shader_dependencies']==[] and proof['guid']==row['guid']
            and proof['manifest_source']==wrappers['manifest'] and proof['source']==original['source']
            and proof['entire_ParsedForm_equal'] and proof['all_original_program_fields_equal']
            and proof['all_Release_bytes_outside_name_and_manifest_typed_PPtr_windows_equal']
            and proof['original_meta_bytes_and_GUID_preserved'] and proof['output_shape']['external_rows']==[],
            'Every full original ParsedForm/program field/meta and explicitly null Editor graph must be proved')
        guard.need(row['asset']['bytes']<=8*1024**2,'Per-wrapper8MiB bound')
        rows.append(row)
    guard.need(sum(r['asset']['bytes'] for r in rows)<=128*1024**2,'Complete179 wrappers bounded128MiB')
    return rows


def validate_config(config,plan,project):
    original=authority();guids=[r['guid'] for r in original['shaders']]
    guard.need(config['project']==str(project) and config['Editor_dependency_projection'] is True
        and [r['guid'] for r in config['shaders']]==guids and plan['selected_GUIDs']==guids,
        'Exact canonical179 config order/project/Editor projection required')
    for row,source in zip(config['shaders'],original['shaders']):
        guard.need(row['dependencies']==[] and row['name']==source['name'] and row['meta_sha256']==source['meta']['sha256']
            and row['path']=='Assets/Resources/OriginalShaders/'+row['guid']+'.asset','Exact original identities/metas and empty Editor-only graph')
    materials=config['copied_materials']
    guard.need(materials==plan['material_witnesses'] and len(materials)==4
        and {r['builtin_local_id'] for r in materials}=={'6','7','46','10490'}
        and len({r['material_guid'] for r in materials})==4,'Exactly four pinned native Material witnesses')
    for row in materials:
        guard.need(row['builtin_guid']==small.MAGIC and row['material_local_id']=='2100000'
            and row['material_source_path']=='Assets/Resources/BuiltinIdentityWitnesses/Builtin-'+row['builtin_local_id']+'.mat',
            'Exact genuine builtin/Material source contract')


def prepare(args):
    guard.need(guard.sha(Path(small.__file__))==SMALL_SHA and guard.sha(small.TEMPLATE/'plan.json')==small.TEMPLATE_SHA,'Frozen successful8 runner and matching two-Shader template')
    for path,sha in [(args.proposal,args.proposal_sha256),(args.wrappers,args.wrappers_sha256),(args.offline_controls,args.offline_controls_sha256)]:
        guard.need(path and sha and path.resolve(strict=True).is_relative_to(ROOT) and guard.sha(path)==sha,'Exact recovery-only proposal/wrappers/controls pins')
    proposal=json.loads(args.proposal.read_bytes());verify_aggregate(proposal)
    guard.need(proposal['original_count']==179 and proposal['typed_dependency_words_to_zero_only_in_Editor']==104
        and proposal['original_project_links_to_restore']==77 and proposal['original_builtin_links_to_restore']==27,'Exact179/104 original graph authority')
    for key in ('manifest','canonical_original_authority','controls','every104_original_raw_PPtr_and_tail_verified'):guard.checked(proposal[key])
    manifest=json.loads(Path(proposal['manifest']['path']).read_bytes());wrappers=json.loads(args.wrappers.read_bytes())
    selected=select_inputs(manifest,wrappers,proposal['manifest']['sha256'])
    controls=json.loads(args.offline_controls.read_bytes())
    guard.need(controls['schema']=='all179-null-Editor-projection-fixture-pure-controls/v1' and controls['status']=='passed'
        and controls['negative_count']>=20 and len(controls['owned_job_final_query_and_real_close_controls'])==4
        and controls['new_runner']==pin(Path(__file__)) and controls['new_builder']==pin(HERE/'BuildAllOriginalShaderNullDependencyFixture.cs'),
        'Actual offline controls must bind exact new runner/builder')
    out=ROOT/'AssetRecovery'/('AllOriginalShaderNullDependencyFixture-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    project=out/'Project';inputs=[];sources=[pin(args.proposal),pin(args.wrappers),pin(args.offline_controls),pin(Path(small.__file__)),pin(Path(projection.__file__)),pin(small.TEMPLATE/'plan.json')]
    sources += [proposal[k] for k in ('manifest','canonical_original_authority','controls','every104_original_raw_PPtr_and_tail_verified')]
    sources += [proposal['aggregate_gate'][k] for k in ('actual_aggregate','actual_receipt')]+manifest['proofs']+[wrappers['conversion_report']]
    base=json.loads((small.TEMPLATE/'plan.json').read_bytes());base_inputs={Path(r['path']).relative_to(small.TEMPLATE/'Project').as_posix():r for r in base['inputs']}
    def write(relative,data):
        target=project/relative;target.parent.mkdir(parents=True,exist_ok=True)
        with target.open('xb') as stream:stream.write(data)
        inputs.append(pin(target));return target
    def copy(source,relative,sha):
        record=pin(source);guard.need(record['sha256']==sha,'Exact read-only copy source')
        target=write(relative,Path(source).read_bytes());guard.need(pin(target)['sha256']==sha and pin(source)==record,'Copy source/persisted bytes must remain exact');sources.append(record);return target
    for relative in ('Packages/manifest.json','Packages/packages-lock.json','ProjectSettings/EditorSettings.asset','ProjectSettings/ProjectSettings.asset','ProjectSettings/ProjectVersion.txt','Assets/Resources/ShaderProbeControl.shader','Assets/Editor/AvoidSavingYamlShaders.cs','Assets/Editor/AvoidSavingYamlShaders.cs.meta'):
        source=HERE.parents[2]/'RR23'/relative if relative=='ProjectSettings/ProjectSettings.asset' else small.TEMPLATE/'Project'/relative
        copy(source,relative,base_inputs[relative]['sha256'])
    guard.need(b'  m_SerializationMode: 0' in (project/'ProjectSettings/EditorSettings.asset').read_bytes(),'Mixed before initial native import')
    builder=copy(HERE/'BuildAllOriginalShaderNullDependencyFixture.cs','Assets/Editor/BuildAllOriginalShaderNullDependencyFixture.cs',guard.sha(HERE/'BuildAllOriginalShaderNullDependencyFixture.cs'))
    capture=copy(HERE/'ShaderPackedBuildReportCapture.cs','Assets/Editor/ShaderPackedBuildReportCapture.cs',guard.sha(HERE/'ShaderPackedBuildReportCapture.cs'))
    runtime=copy(HERE/'OriginalShaderRuntimeProbeWithPipelineTag.cs','Assets/Runtime/OriginalShaderRuntimeProbe.cs','4aedcbce38d4e503efd19b81a203417aabfbaa3fceba9a758e75f4951ab6b144')
    by_guid={r['guid']:r for r in manifest['shaders']};shaders=[]
    for row in selected:
        original=by_guid[row['guid']];sources+=original['proofs']+[original['source'],original['meta'],original['current_asset'],row['proof']]
        relative='Assets/Resources/OriginalShaders/'+row['guid']+'.asset'
        asset=copy(Path(row['asset']['path']),relative,row['asset']['sha256']);copy(Path(row['meta']['path']),relative+'.meta',row['meta']['sha256'])
        shaders.append({'path':relative,'sha256':guard.sha(asset),'meta_sha256':row['meta']['sha256'],'guid':row['guid'],'name':row['name'],'dependencies':[]})
    graphics_source=small.TEMPLATE/'Project/ProjectSettings/GraphicsSettings.asset';guard.need(guard.sha(graphics_source)==base_inputs['ProjectSettings/GraphicsSettings.asset']['sha256'],'Exact proven template GraphicsSettings')
    sources.append(pin(graphics_source));replacement=('  m_AlwaysIncludedShaders:\n'+''.join('  - {fileID: 4800000, guid: '+r['guid']+', type: 2}\n' for r in shaders)).encode()
    graphics,count=re.subn(rb'(?ms)^  m_AlwaysIncludedShaders:\r?\n.*?(?=^  [A-Za-z_])',replacement,graphics_source.read_bytes())
    guard.need(count==1 and b'  m_CustomRenderPipeline: {fileID: 0}' in graphics,'Exact179 keep list and null diagnostic pipeline');graphics_path=write('ProjectSettings/GraphicsSettings.asset',graphics)
    materials=[]
    for material in proposal['copied_native_Material_sources']:
        witness=material['witness'];copy(Path(material['asset']['path']),witness['material_source_path'],material['asset']['sha256']);copy(Path(material['meta']['path']),witness['material_source_path']+'.meta',material['meta']['sha256']);materials.append(witness)
    config=out/'config.json';save(config,{'project':str(project),'graphics_sha256':guard.sha(graphics_path),'shaders':shaders,'Editor_dependency_projection':True,'copied_materials':materials})
    refs=base['compile_checks'][0]['references'];response=out/'fixture.rsp'
    response.write_text('\n'.join(['/nologo','/nostdlib+','/target:library','/langversion:8']+['/reference:"'+r['path']+'"' for r in refs]+['"'+str(p)+'"' for p in (builder,capture,runtime)])+'\n',encoding='utf-8')
    # Deduplicate repeated immutable source pins while refusing conflicting pins.
    unique={}
    for row in sources:
        guard.need(row['path'] not in unique or unique[row['path']]==row,'No conflicting source authority pins');unique[row['path']]=row
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'project':str(project),'runner':pin(Path(__file__)),'guard':pin(HERE/'run_windows_development_define_probe.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'process_safety':pin(Path(guard.safety.__file__)),'editor':base['editor'],'cli':base['cli'],'compiler':base['compiler'],'config':pin(config),'inputs':inputs,'read_only_sources':list(unique.values()),'compile_checks':[{'name':'all179-Shader-builder-capture-runtime','source':pin(builder),'additional_sources':[pin(capture),pin(runtime)],'response':pin(response),'references':refs}],
        'cap_bytes':CAP,'reserve_bytes':guard.RESERVE,'maximum_Editor_seconds':900,'selected_GUIDs':[r['guid'] for r in selected],'required_builtin_local_ids':sorted(small.BUILTINS),'shader_count':179,'material_witnesses':materials,'final_owned_job_telemetry_enabled':True,'Editor_only_null_dependency_projection':True,'original_typed_dependencies_to_restore':104,'native_wrapper_bytes':sum(r['asset']['bytes'] for r in selected),'proposal':pin(args.proposal),'offline_controls':pin(args.offline_controls),'Main_modified':False,'original_game_code_executed':False,'player_launch_authorized_by_this_runner':False,
        'protected_existing_processes':[{'pid':3040,'action':'no termination or modification; existing shared process-safety classification retained'}],
        'limitations':['Diagnostic179 Editor-only null dependency projection; original full Release programs and104 links must be postpatched before runtime.','Actual new BuildReport plus four typed Materials must derive every179 native placement and builtin target; no reuse of old IDs,external FileID,metadata length or gap.','No full URP renderer, original game startup/login, gameplay or visual fidelity is proved by this build.']}
    target=out/'plan.json';save(target,plan);return target


def verify(path,digest,launch=False):
    path=path.resolve(strict=True);guard.need(guard.sha(path)==digest,'Explicit reviewed plan SHA required');plan=json.loads(path.read_bytes());fixture=path.parent;project=Path(plan['project']).resolve(strict=True)
    guard.need(fixture.parent==ROOT/'AssetRecovery' and fixture.name.startswith('AllOriginalShaderNullDependencyFixture-') and project==fixture/'Project'
        and plan['schema']==SCHEMA and plan['cap_bytes']==CAP and plan['reserve_bytes']==guard.RESERVE and plan['maximum_Editor_seconds']==900
        and plan['shader_count']==179 and plan['required_builtin_local_ids']==sorted(small.BUILTINS) and plan['original_typed_dependencies_to_restore']==104
        and plan['final_owned_job_telemetry_enabled'] and plan['Editor_only_null_dependency_projection'] is True,'Exact isolated179 fixture/bounds')
    guard.need(Path(plan['editor']['path'])==guard.EDITOR and Path(plan['cli']['path'])==guard.CLI and plan['runner']==pin(Path(__file__))
        and guard.sha(Path(small.__file__))==SMALL_SHA,'Fixed matching tools and reviewed telemetry implementation')
    for row in [plan[k] for k in ('runner','guard','launcher','editor','cli','compiler','config','process_safety','proposal','offline_controls')]+plan['inputs']+plan['read_only_sources']:guard.checked(row)
    for group in plan['compile_checks']:
        for row in [group['source'],group['response']]+group['additional_sources']+group['references']:guard.checked(row)
    verify_aggregate(json.loads(Path(plan['proposal']['path']).read_bytes()))
    guard.need(not(project/'Library').exists() and not(project/'Temp').exists(),'Fresh never-launched project required')
    guard.need({p.resolve() for p in project.rglob('*') if p.is_file()}=={Path(r['path']).resolve() for r in plan['inputs']},'Exact initial fixture file inventory')
    validate_config(json.loads(Path(plan['config']['path']).read_bytes()),plan,project)
    if launch:guard.admission(project,CAP)
    return plan,project


def run(path,plan,project):
    path=path.resolve(strict=True);out=path.parent/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-all179-original-Shader-null-Editor-projection-build/v1','status':'starting','plan':pin(path),'phases':[],'shader_count':179,'Main_modified':False,'original_game_code_executed':False,'player_launched':False}
    original=guard.make_job;guard.make_job=small.telemetry_factory(original,report)
    try:
        guard.compile_sources(plan,project,out,report)
        player=out/'Player/AllOriginalShaderNullDependencyDiagnostic.exe';player.parent.mkdir();result=out/'build-report.json';log=out/'Editor.log'
        extra=shlex.join(['-disable-assembly-updater','-job-worker-count','1','-shaderBuildReport',result.as_posix(),'-shaderBuildConfig',Path(plan['config']['path']).as_posix()])
        command=[guard.CLI.as_posix(),'build',project.as_posix(),'--target','StandaloneWindows64','--execute-method','BuildAllOriginalShaderNullDependencyFixture.Run','--output-path',player.as_posix(),'--editor-path',guard.EDITOR.as_posix(),'--args',extra,'--timeout','900','--allow-dirty-build','--no-tail','--no-accelerator','--log-file',log.as_posix(),'--provenance-path',(out/'provenance.json').as_posix(),'--format','json']
        try:guard.bounded(command,project,out,'all179-original-Shader-native-import-and-build',CAP,900,report)
        finally:
            if result.is_file():report['build']={'report':pin(result),'result':json.loads(result.read_bytes())}
            if log.is_file():
                text=log.read_text(encoding='utf-8',errors='replace');report['full_editor_log']=pin(log);report['partial_constant_buffer_full_log_count']=text.count('Partial constant buffer not found.')
                report['full_log_failure_lines']=[line[:1024] for line in text.splitlines() if re.search(r'Partial constant buffer not found\.|error CS\d+|Shader error in|ERROR: Shader|Failed to find expected binary shader data|is corrupted|Position out of bounds|Fatal error|Aborting batchmode|Could not allocate memory|Failed to allocate|Out of memory|StackOverflowException',line,re.I)][:64]
            guard.save(out,report)
        built=report['build']['result']
        guard.need(built['schema']=='all179-original-Shader-Editor-projection-four-builtin-Material-build/v1' and built['status']=='Succeeded'
            and built['total_errors']==built['partial_constant_buffer_messages']==0 and built['shader_count']==179
            and built['input_assets_and_metas_unchanged'] and built['required_project_dependency_closure_verified'] and built['four_builtin_material_witnesses_verified']
            and built['Editor_only_null_dependency_projection'] and not built['original_dependencies_restored_in_player'] and built['serialization_mode']=='Mixed'
            and built['backend']=='Mono2x' and built['target']=='StandaloneWindows64' and player.is_file(),'Actual179/fourMaterial matching native build gate')
        guard.need(report['partial_constant_buffer_full_log_count']==0 and not report['full_log_failure_lines'],'Whole Editor log must have zero Shader/compiler/native errors')
        for row in plan['read_only_sources']+[r for r in plan['inputs'] if not Path(r['path']).is_relative_to(project/'ProjectSettings')]:guard.checked(row)
        report.update(status='all179_projected_original_Shader_Windows_build_verified_UNPATCHED_NOT_FOR_RUNTIME',diagnostic_player=pin(player))
    except BaseException as error:report.update(status='failed_or_guard_refused',error=repr(error))
    finally:
        guard.make_job=original;report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();guard.save(out,report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status'].startswith('all179_projected_') else 1


def main():
    ap=argparse.ArgumentParser(description=__doc__);ap.add_argument('--fixture',type=Path);ap.add_argument('--plan-sha256');ap.add_argument('--run',action='store_true')
    for key in ('proposal','wrappers','offline-controls'):ap.add_argument('--'+key,type=Path);ap.add_argument('--'+key+'-sha256')
    args=ap.parse_args()
    if args.fixture:path=(args.fixture/'plan.json').resolve(strict=True);plan,project=verify(path,args.plan_sha256,args.run)
    else:
        guard.need(not args.run and all((args.proposal,args.proposal_sha256,args.wrappers,args.wrappers_sha256,args.offline_controls,args.offline_controls_sha256)),'Prepare exact successful conversion/wrappers before Root launch')
        path=prepare(args);plan,project=verify(path,guard.sha(path))
    if args.run:return run(path,plan,project)
    print(json.dumps({'status':'prepared_verified_no_child_started','plan':pin(path),'minimum_available_commit_bytes':CAP+guard.RESERVE,'Root_command':[str(Path('C:/Python314/python.exe')),'-B',str(Path(__file__).resolve()),'--fixture',str(path.parent),'--plan-sha256',guard.sha(path),'--run']}));return 0


if __name__=='__main__':raise SystemExit(main())
