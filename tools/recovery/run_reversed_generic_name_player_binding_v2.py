"""Root-run the same consumer through the existing production manifest inverse.

No Main path is written. The consumer is genuinely compiled against the current
projected SDK in the prior diagnostic. Only its one manifest-authorized TypeRef
is now reversed using unchanged production MetadataReferenceReversal source.
The isolated matching player receives the unchanged raw SDK closure. No SDK
method/constructor, runtime metadata rename or production GameRoot is invoked.
"""
from pathlib import Path
import argparse,datetime as dt,json,mmap,re,shlex,uuid
import run_windows_development_define_probe as guard
from audit_original_rendering_sdk_candidates import h
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROOF=ROOT/'Validation/TitleLeafGenericNameProof-20261023T084249Z-e5b1d08f/report.json'
PROOF_SHA='d3611ad86b0fa94f7437f507eaa54b6002ccbda4bcbedbd2f228134b1a176286'
GUARD_SHA='685f87ada7d4c10a09421e11b59466b3e19e817bfdaabd5a233c0192f17529fc'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
CAP=2*1024**3;SCHEMA='prepared-production-reversed-same-consumer-raw-SDK-matching-player-binding/v2'
FAILED=ROOT/'Validation/ProjectedGenericNamePlayerBinding-v2-20261023T090339Z-f408cc7d/Run-20261023T090436Z-e03bc440/run-report.json'
FAILED_SHA='2e8f54c4675f1823f34f4ed61158437c1a2e9dc6b6246979c490089210ca2d93'
PRIOR=HERE/'run_projected_generic_name_player_binding_v2.py'
AUDIT=ROOT/'Validation/TitleGenericReferenceReversalAudit-20261023T091014Z-5def50e4/report.json'
AUDIT_SHA='ba60bc38b6d6e333d9e16ddbd6ea6db842d56f4e05ca39449cb1a1bfaa23400e'
CODEGEN=WS/'RR23/Assets/Editor/OriginalMetadataRestoration'
MANIFEST=WS/'RR23/CompilerSupport/Metadata/GeneralManifest.bin'
SUPPORT=HERE.parent/'RuntimeMetadataAudit/COMCompatibility-20261022T100736Z'
DIAGNOSIS=ROOT/'Validation/ProjectedConsumerEmissionDiagnosis-20261023T091845Z-69680d21/report.json'
DIAGNOSIS_SHA='95db727e9d45ae7ab2baa34691189ed084b58980737e30ffcfdbfb58fd82d1b3'
PRIOR_INVERSE=HERE/'run_reversed_generic_name_player_binding.py'
IDENTITY='RecRoom.Datastructures.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'

def need(v,m):
    if not v:raise ValueError(m)

def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p);return {'path':str(p),'bytes':p.stat().st_size,'sha256':guard.sha(p)}

def check(row):need(pin(row['path'])==row,'Pinned diagnostic input changed: '+row['path'])

def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')

def assembly(path):
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=h.m.cli.Cli(b);r=h.Read(c)
        return {'module':pin(path),'actual_identity':r.asm,'references':[h.m.identity(c,35,i) for i in range(1,c.rows[35]+1)],'Unity_runtime_initializer_attribute_references':[r.typeref(i) for i in range(1,c.rows[1]+1) if 'RuntimeInitializeOnLoadMethodAttribute' in r.typeref(i)],'module_initializer_methods':[m for i in range(1,c.rows[2]+1) if r.definition(i)=='<Module>' for m in r.methods(i) if m['name']=='.cctor']}

def dependency_closure():
    plugins=WS/'RR23/Assets/Plugins';editor=guard.EDITOR.parent
    engine=editor/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed';framework=editor/'Data/MonoBleedingEdge/lib/mono/unityjit'
    pending=[plugins/'RecRoom.Datastructures.Runtime.dll'];seen={};edges=[]
    while pending:
        path=pending.pop(0);name=path.stem
        if name in seen:continue
        row=assembly(path);row['kind']='original_game_SDK' if path.parent==plugins else 'installed_matching_engine_or_framework_resolution_candidate';seen[name]=row
        if row['kind']=='original_game_SDK':need(not row['Unity_runtime_initializer_attribute_references'] and not row['module_initializer_methods'],'The seven preserved SDKs must not add an automatically invoked Unity runtime or module initializer')
        need(len(seen)+len(pending)<=64,'Bounded genuine SDK/framework AssemblyRef closure')
        for ref in row['references']:
            dep=ref['name'];candidate=plugins/(dep+'.dll')
            if not candidate.is_file():
                need(dep in {'mscorlib','netstandard','Mono.Security','Mono.Posix'} or dep.startswith(('System','UnityEngine.')),'Only declared SDK or known framework namespace may resolve outside Plugins: '+dep)
                choices=[d/(dep+'.dll') for d in [engine,framework,framework/'Facades']];existing=[x for x in choices if x.is_file()];need(existing,'Every original AssemblyRef has an installed matching resolution candidate: '+dep);candidate=existing[0]
            resolved=assembly(candidate)
            need(resolved['actual_identity'].split(',')[0]==dep,'Exact AssemblyRef simple name; no alias/normalization')
            if candidate.parent==plugins:need(resolved['actual_identity']==ref['full_name'],'Exact original SDK dependency assembly identity')
            edges.append({'source':name,'requested_original_identity':ref['full_name'],'requested_name':dep,'resolution_candidate':resolved['module'],'candidate_identity':resolved['actual_identity'],'identities_equal':resolved['actual_identity']==ref['full_name'],'framework_runtime_resolution_claimed':False})
            if dep not in seen and candidate not in pending:pending.append(candidate)
    sdks=[x for x in seen.values() if x['kind']=='original_game_SDK'];names={Path(x['module']['path']).name for x in sdks}
    need(names=={'RecRoom.Datastructures.Runtime.dll','RecRoom.NoEngine.Common.Runtime.dll','RecRoom.Promises.Runtime.dll','System.Buffers.dll','Unity.Collections.dll','RecRoom.Attributes.Runtime.dll','Unity.Burst.dll'},'Exact seven required SDKs from whole recursive AssemblyRef traversal')
    return {'schema':'genuine-Datastructures-recursive-AssemblyRef-closure/v1','status':'all_original_AssemblyRefs_resolved_to_pinned_SDK_or_installed_framework_candidates','root':'RecRoom.Datastructures.Runtime','assemblies':list(seen.values()),'edges':edges,'required_original_SDK_count':len(sdks),'runtime_framework_binding_claimed':False,'Main_modified':False}

def prepare():
    need(pin(DIAGNOSIS)['sha256']==DIAGNOSIS_SHA,'Frozen exact nine-reference reindex diagnosis');diagnosis=json.loads(DIAGNOSIS.read_bytes());need(diagnosis['status']=='exact_nine_reference_permutation_and_one_name_inverse_proven_full_Cecil_gates_pending' and [(x['original_row'],x['emitted_row']) for x in diagnosis['exact_TypeRef_row_bijection']]==[(1,6),(2,7),(3,8),(4,9),(5,1),(6,2),(7,3),(8,4),(9,5)],'Only the independently demonstrated exact permutation');check(diagnosis['failed_receipt']);check(diagnosis['failed_plan']);check(diagnosis['original']['module']);check(diagnosis['emitted']['module'])
    need(pin(FAILED)['sha256']==FAILED_SHA,'Retain actual direct-consumer runtime failure');failed=json.loads(FAILED.read_bytes());need(failed['status']=='actual_matching_player_generic_name_binding_diagnostic_completed' and failed['projected_consumer_binding_succeeded'] is False and failed['resolution_status']=='diagnostic_completed_projected_name_does_not_resolve','Actual previous consumer observation; not a production ILPP failure claim');check(failed['actual_projected_consumer']);original_consumer=failed['actual_projected_consumer']
    need(pin(AUDIT)['sha256']==AUDIT_SHA,'Exact existing production inverse audit');audit=json.loads(AUDIT.read_bytes());need(audit['manifest_alias']['manifest']==pin(MANIFEST) and audit['manifest_alias']['selected_alias']=={'Assembly':'RecRoom.Datastructures.Runtime','OriginalFullName':'HHOBPMOCKMJ','CompiledFullName':'HHOBPMOCKMJ`1'},'Only the already authorized production manifest alias')
    for row in audit['production_sources']:check(row)
    closure=dependency_closure()
    need(pin(PROOF)['sha256']==PROOF_SHA,'Exact native/raw/projected arity-name evidence');proof=json.loads(PROOF.read_bytes())
    need(proof['status']=='same_original_type_token_assembly_arity_proven_for_one_field_only','Original semantic evidence is not a runtime resolution claim')
    raw=Path(proof['raw_runtime_contract']['module']['path']);projected=Path(proof['projected_compiler_contract']['module']['path']);check(proof['raw_runtime_contract']['module']);check(proof['projected_compiler_contract']['module'])
    need(raw==WS/'RR23/Assets/Plugins/RecRoom.Datastructures.Runtime.dll' and projected==WS/'RR23/CompilerSupport/References/RecRoom.Datastructures.Runtime.dll','Only the actual retained runtime and its actual compiler projection')
    need(pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCH_SHA and pin(HERE/'run_windows_development_define_probe.py')['sha256']==GUARD_SHA,'Reviewed suspended-owned guard')
    fixture=ROOT/'Validation'/('ReversedGenericNamePlayerBinding-v2-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);fixture.mkdir();project=fixture/'Project';inputs=[];sources=[pin(PROOF),pin(projected),pin(FAILED),pin(PRIOR),pin(AUDIT),pin(MANIFEST),pin(DIAGNOSIS),pin(PRIOR_INVERSE),original_consumer]+audit['production_sources']
    closure_path=fixture/'dependency-closure.json';save(closure_path,closure)
    sources.extend(x['module'] for x in closure['assemblies'])
    def write(relative,data):
        path=project/relative;path.parent.mkdir(parents=True,exist_ok=True)
        with path.open('xb') as f:f.write(data.encode() if isinstance(data,str) else data)
        inputs.append(pin(path));return path
    def copy(source,relative):
        record=pin(source);target=write(relative,Path(source).read_bytes());need(pin(target)['sha256']==record['sha256'] and pin(source)==record,'Exact source copy');sources.append(record);return target
    sdk=copy(raw,'Assets/Plugins/RecRoom.Datastructures.Runtime.dll');meta=copy(Path(str(raw)+'.meta'),'Assets/Plugins/RecRoom.Datastructures.Runtime.dll.meta')
    text=meta.read_text();need('isExplicitlyReferenced: 1' in text and 'Editor: Editor' in text and 'enabled: 0' in text and 'validateReferences: 0' in text,'Preserve actual original raw SDK importer filters')
    dependencies=[{'origin':pin(raw),'meta_origin':pin(Path(str(raw)+'.meta')),'fixture':pin(sdk),'fixture_meta':pin(meta)}]
    for row in closure['assemblies']:
        if row['kind']!='original_game_SDK' or Path(row['module']['path'])==raw:continue
        source=Path(row['module']['path']);m=Path(str(source)+'.meta');d=copy(source,'Assets/Plugins/'+source.name);dm=copy(m,'Assets/Plugins/'+m.name);t=dm.read_text();need('isExplicitlyReferenced: 1' in t and 'Editor: Editor' in t and 'enabled: 0' in t and 'validateReferences: 0' in t,'Preserve every exact genuine dependency importer filter');dependencies.append({'origin':pin(source),'meta_origin':pin(m),'fixture':pin(d),'fixture_meta':pin(dm)})
    runtime=copy(HERE/'ReversedGenericNamePlayerProbe.cs','Assets/Runtime/ReversedGenericNamePlayerProbe.cs');builder=copy(HERE/'BuildStartupSdkLifecycleSmoke.cs','Assets/Editor/BuildStartupSdkLifecycleSmoke.cs')
    consumer_name='Recovery.ProjectedGenericConsumer.dll';consumer=project/'Assets/Plugins'/consumer_name
    consumer_meta=write('Assets/Plugins/'+consumer_name+'.meta','fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\nPluginImporter:\n  serializedVersion: 2\n  externalObjects: {}\n  iconMap: {}\n  executionOrder: {}\n  defineConstraints: []\n  isPreloaded: 0\n  isOverridable: 0\n  isExplicitlyReferenced: 1\n  validateReferences: 0\n  platformData:\n  - first:\n      Any:\n    second:\n      enabled: 1\n      settings: {}\n  - first:\n      Editor: Editor\n    second:\n      enabled: 0\n      settings: {}\n  userData:\n  assetBundleName:\n  assetBundleVariant:\n')
    write('Assets/Runtime/Recovery.ProjectedGenericBinding.Probe.asmdef',json.dumps({'name':'Recovery.ProjectedGenericBinding.Probe','references':[],'excludePlatforms':['Editor'],'overrideReferences':True,'precompiledReferences':[Path(x['origin']['path']).name for x in dependencies]+[consumer_name],'autoReferenced':True},indent=2)+'\n')
    write('Assets/Runtime/link.xml','<linker>\n  <assembly fullname="Recovery.ProjectedGenericBinding.Probe" preserve="all" />\n  <assembly fullname="Recovery.ProjectedGenericConsumer" preserve="all" />\n'+''.join('  <assembly fullname="'+Path(x['origin']['path']).stem+'" preserve="all" />\n' for x in dependencies)+'</linker>\n')
    write('ProjectSettings/ProjectVersion.txt','m_EditorVersion: 2020.3.33f1\nm_EditorVersionWithRevision: 2020.3.33f1 (915a7af8b0d5)\n');copy(WS/'RR23/ProjectSettings/ProjectSettings.asset','ProjectSettings/ProjectSettings.asset')
    package=guard.EDITOR.parent/'Data/Resources/PackageManager/BuiltInPackages/com.unity.modules.jsonserialize/package.json';need(json.loads(package.read_bytes())['version']=='1.0.0','Matching builtin JSON module');sources.append(pin(package));write('Packages/manifest.json','{"dependencies":{"com.unity.modules.jsonserialize":"1.0.0"}}\n')
    editor=guard.EDITOR.parent;monoapi=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';common=[monoapi/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];playerengine=editor/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed';core=playerengine/'UnityEngine.CoreModule.dll';jsonref=playerengine/'UnityEngine.JSONSerializeModule.dll';cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll'
    checks=[]
    groups=[('empty-scene-Editor-builder',builder,common+[editor/'Data/Managed/UnityEditor.dll',editor/'Data/Managed/UnityEngine/UnityEngine.dll',editor/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',editor/'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll'],'library'),('actual-player-reflection-only-probe',runtime,common+[core,jsonref],'library'),('existing-production-reference-inverse-reader',HERE/'ReverseProjectedGenericNameConsumer.v2.cs',common+[monoapi/'Facades/netstandard.dll',cecil],'exe')]
    for name,source,refs,target in groups:
        additional=[CODEGEN/x for x in ['CanonicalMetadataSignatures.cs','MetadataReferenceReversal.cs','ExactInModifierReversal.cs']]+[SUPPORT/x for x in ['MetadataRoundTripSafety.cs','BodyAndSymbolSafety.cs']] if name=='existing-production-reference-inverse-reader' else []
        rsp=fixture/(name+'.rsp');rsp.write_text('/nologo\n/nostdlib+\n/target:'+target+'\n/langversion:8.0\n'+''.join('/reference:"'+str(p)+'"\n' for p in refs)+''.join('"'+str(s)+'"\n' for s in [source]+additional),encoding='utf-8',newline='\n');checks.append({'name':name,'source':pin(source),'additional_sources':[pin(s) for s in additional],'response':pin(rsp),'references':[pin(p) for p in refs],'target':target})
    plan={'schema':SCHEMA,'status':'prepared_no_compiler_Editor_player_started','fixture':str(fixture),'project':str(project),'runner':pin(Path(__file__)),'guard':pin(HERE/'run_windows_development_define_probe.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'process_safety':pin(Path(guard.safety.__file__)),'editor':pin(guard.EDITOR),'cli':pin(guard.CLI),'compiler':pin(editor/'Data/Tools/Roslyn/csc.exe'),'mono':pin(editor/'Data/MonoBleedingEdge/bin/mono.exe'),'Cecil':pin(cecil),'inputs':inputs,'read_only_sources':sources,'raw_SDK':pin(raw),'raw_SDK_meta':pin(Path(str(raw)+'.meta')),'fixture_SDK':pin(sdk),'fixture_SDK_meta':pin(meta),'projected_SDK':pin(projected),'consumer_output':str(consumer),'consumer_meta':pin(consumer_meta),'compile_checks':checks,'cap_bytes':CAP,'compile_cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'Editor_timeout_seconds':300,'player_timeout_seconds':60,'SDK_bodies_invoked':False,'production_GameRoot_instantiated':False,'Main_modified':False,'no_binding_success_assumption':True,'no_runtime_metadata_normalization_or_rename':True}
    plan.update(prior_failed_receipt=pin(FAILED),prior_runner=pin(PRIOR),dependency_closure=pin(closure_path),exact_original_SDK_dependency_closure=dependencies,all_recursive_AssemblyRefs_audited=True)
    plan.update(production_inverse_audit=pin(AUDIT),production_manifest=pin(MANIFEST),same_original_compiled_consumer=original_consumer,production_inverse_sources=audit['production_sources'],entire_production_ILPP_executed=False,only_one_existing_production_TypeRef_alias_reversed=True,expected_resolution_success=True)
    plan.update(exact_emission_reindex_diagnosis=pin(DIAGNOSIS),prior_failed_inverse_receipt=diagnosis['failed_receipt'],prior_inverse_runner=pin(PRIOR_INVERSE),exact_original_to_emitted_TypeRef_rows=[[1,6],[2,7],[3,8],[4,9],[5,1],[6,2],[7,3],[8,4],[9,5]])
    target=fixture/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'required_SDKs':len(dependencies),'closure_assemblies':len(closure['assemblies']),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def verify(path,digest):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed diagnostic plan');p=json.loads(path.read_bytes());fixture=path.parent;project=Path(p['project']).resolve(strict=True)
    need(p['schema']==SCHEMA and fixture.parent==ROOT/'Validation' and fixture.name.startswith('ReversedGenericNamePlayerBinding-') and project==fixture/'Project' and p['cap_bytes']==CAP and p['compile_cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['Editor_timeout_seconds']==300 and p['player_timeout_seconds']==60,'Exact bounded isolated matching fixture')
    for row in [p[k] for k in ['runner','guard','launcher','process_safety','editor','cli','compiler','mono','Cecil','raw_SDK','raw_SDK_meta','fixture_SDK','fixture_SDK_meta','projected_SDK','consumer_meta','prior_failed_receipt','prior_runner','dependency_closure','production_inverse_audit','production_manifest','same_original_compiled_consumer','exact_emission_reindex_diagnosis','prior_failed_inverse_receipt','prior_inverse_runner']]+p['inputs']+p['read_only_sources']+p['production_inverse_sources']:check(row)
    need(p['exact_emission_reindex_diagnosis']['sha256']==DIAGNOSIS_SHA and p['prior_failed_inverse_receipt']['sha256']=='9eb95afa02a93cc7948b77be7b7e3b41db3bcc631ad61cfb38f9e6d86a2264aa' and p['exact_original_to_emitted_TypeRef_rows']==[[1,6],[2,7],[3,8],[4,9],[5,1],[6,2],[7,3],[8,4],[9,5]],'Exact retained failure and independently proven reference-row permutation only')
    need(p['prior_failed_receipt']['sha256']==FAILED_SHA and json.loads(Path(p['dependency_closure']['path']).read_bytes())==dependency_closure() and len(p['exact_original_SDK_dependency_closure'])==7,'Exact current full seven-SDK dependency closure')
    for sdk in p['exact_original_SDK_dependency_closure']:
        for row in sdk.values():check(row)
    for group in p['compile_checks']:
        for row in [group['source'],group['response']]+group['references']+group['additional_sources']:check(row)
    need(p['production_inverse_audit']['sha256']==AUDIT_SHA and p['production_manifest']==pin(MANIFEST) and p['same_original_compiled_consumer']==json.loads(FAILED.read_bytes())['actual_projected_consumer'] and p['expected_resolution_success'] is True and p['entire_production_ILPP_executed'] is False,'Exact same compiled consumer and only the existing production reference inverse')
    need(p['runner']==pin(Path(__file__)) and p['launcher']['sha256']==LAUNCH_SHA and p['guard']['sha256']==GUARD_SHA and len(p['compile_checks'])==3 and Path(p['editor']['path'])==guard.EDITOR and Path(p['cli']['path'])==guard.CLI,'Exact reviewed runner/matching Editor/assign-before-resume guard')
    need(Path(p['consumer_output'])==project/'Assets/Plugins/Recovery.ProjectedGenericConsumer.dll' and not Path(p['consumer_output']).exists() and not(project/'Library').exists() and not(project/'Temp').exists(),'Fresh fixture and consumer output')
    need({x.resolve() for x in project.rglob('*') if x.is_file()}=={Path(x['path']).resolve() for x in p['inputs']},'Exact initial fixture inventory');return p,fixture,project

def execute(path,digest,run):
    p,fixture,project=verify(path,digest)
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_write','plan_sha256':digest}));return 0
    out=fixture/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'guarded-actual-production-reversed-same-consumer-raw-SDK-binding/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'SDK_bodies_invoked':False,'production_GameRoot_instantiated':False,'working_startup_claimed':False,'entire_production_ILPP_executed':False,'prior_direct_consumer_runtime_observation':p['prior_failed_receipt'],'same_original_compiled_consumer':p['same_original_compiled_consumer']}
    try:
        compiled={}
        for group in p['compile_checks']:
            target=out/(group['name']+('.exe' if group['target']=='exe' else '.dll'))
            guard.bounded([Path(p['compiler']['path']).as_posix(),'@'+Path(group['response']['path']).as_posix(),'/out:'+target.as_posix()],project,out,'compile-'+group['name'],p['compile_cap_bytes'],30,report);compiled[group['name']]=pin(target)
        report['compiled_outputs']=compiled
        copied=out/'Mono.Cecil.dll'
        with copied.open('xb') as f:f.write(Path(p['Cecil']['path']).read_bytes())
        need(pin(copied)['sha256']==p['Cecil']['sha256'],'Exact metadata reader dependency')
        metadata=out/'actual-production-inverse-and-raw-metadata.txt';helper=compiled['existing-production-reference-inverse-reader']
        guard.bounded([Path(p['mono']['path']).as_posix(),helper['path'],p['production_manifest']['path'],p['raw_SDK']['path'],p['same_original_compiled_consumer']['path'],p['consumer_output'],str(metadata)],project,out,'reverse-one-existing-production-manifest-reference-and-seven-controls',p['compile_cap_bytes'],30,report)
        lines=metadata.read_text().splitlines();pairs=[line.split('=',1) for line in lines];need(all(len(x)==2 for x in pairs) and len({x[0] for x in pairs})==len(pairs),'Exact unique metadata record keys');m=dict(pairs)
        need(m['schema']=='production-manifest-authorized-consumer-reference-inverse/v2' and m['status']=='one_existing_production_TypeRef_inverse_emitted_metadata_and_all_IL_preserved' and m['original_requested_type']=='HHOBPMOCKMJ`1' and m['requested_type']==m['raw_type']=='HHOBPMOCKMJ' and m['requested_scope']==m['raw_scope']==IDENTITY and m['raw_generic_parameter_count']=='1' and m['metadata_only_no_game_or_SDK_execution']=='true' and m['type_reference_reversals']=='1' and m['method_reference_reversals']==m['field_reference_reversals']=='0' and m['production_reversal_controls']=='7' and m['all_consumer_IL_and_other_metadata_preserved']=='true' and m['exact_proven_nine_TypeRef_permutation']=='true' and m['raw_SDK_written']=='false','Exact existing production TypeRef inverse and all consumer preservation gates');report['metadata_observation']=m;report['metadata_evidence']=pin(metadata);report['individual_emitted_gate_details']=pin(Path(str(metadata)+'.gate-details.txt'))
        consumer_pin=pin(p['consumer_output']);report['actual_reversed_same_consumer']=consumer_pin
        player=out/'Player/ProjectedGenericBinding.exe';player.parent.mkdir();buildresult=out/'build-report.json';editorlog=out/'Editor.log'
        extra=shlex.join(['-disable-assembly-updater','-job-worker-count','1','-startupSdkBuildReport',buildresult.as_posix(),'-startupSdkProject',project.as_posix()])
        command=[guard.CLI.as_posix(),'build',project.as_posix(),'--target','StandaloneWindows64','--execute-method','BuildStartupSdkLifecycleSmoke.Run','--output-path',player.as_posix(),'--editor-path',guard.EDITOR.as_posix(),'--args',extra,'--timeout','300','--allow-dirty-build','--no-tail','--no-accelerator','--log-file',editorlog.as_posix(),'--provenance-path',(out/'provenance.json').as_posix(),'--format','json']
        guard.bounded(command,project,out,'matching-Unity-raw-SDK-projected-consumer-build',CAP,300,report)
        built=json.loads(buildresult.read_bytes());need(built['status']=='Succeeded' and built['errors']==0 and built['unity_version']=='2020.3.33f1' and built['backend']=='Mono2x' and built['target']=='StandaloneWindows64' and built['development'] and all(x in built['build_options'] for x in ['Development','StrictMode']),'Actual clean matching Mono Development Strict build')
        report['build_result']=pin(buildresult);report['player']=pin(player);report['full_Editor_log']=pin(editorlog);managed=player.parent/'ProjectedGenericBinding_Data/Managed';packaged=[]
        for source in [x['origin'] for x in p['exact_original_SDK_dependency_closure']]+[consumer_pin]:
            record=pin(managed/Path(source['path']).name);need(record['sha256']==source['sha256'],'Exact unchanged raw SDK and actual projected consumer packaged');packaged.append(record)
        report['actual_packaged_DLLs']=packaged
        result=out/'runtime-result.json';playerlog=out/'Player.log';guard.bounded([player.as_posix(),'-batchmode','-force-d3d11','-screen-fullscreen','0','-screen-width','64','-screen-height','64','-startupSdkResult',result.as_posix(),'-logFile',playerlog.as_posix()],project,out,'actual-Windows-Mono-projected-name-binding',CAP,60,report)
        observed=json.loads(result.read_bytes());need(observed['schema']=='actual-Windows-Mono-production-reversed-generic-name-binding/v1' and observed['status']=='diagnostic_completed_projected_name_resolves_to_raw_definition' and observed['original_projected_type_name']=='HHOBPMOCKMJ`1' and observed['projected_consumer_binding_succeeded'] and observed['raw_and_resolved_same_type'] and observed['mono_runtime'] and observed['unity_version']=='2020.3.33f1' and observed['platform']=='WindowsPlayer' and observed['raw_generic_constructible'] and not observed['SDK_bodies_invoked'] and not observed['production_GameRoot_instantiated'] and not observed['exception'] and not observed['errors'],'Actual same-consumer resolution through the production inverse must succeed against unchanged raw SDK')
        need(observed['requested_SDK_identity']==observed['raw_SDK_identity']==IDENTITY and observed['requested_type_name']==m['requested_type'] and observed['raw_type_name']==m['raw_type'] and observed['raw_type_token']=='0x02000032' and observed['raw_SDK_mvid'].lower()==m['raw_mvid'].lower(),'Actual requested/raw identities agree with independent compiled metadata')
        need(observed['projected_consumer_binding_succeeded']==(observed['status']=='diagnostic_completed_projected_name_resolves_to_raw_definition') and (observed['raw_and_resolved_same_type'] if observed['projected_consumer_binding_succeeded'] else bool(observed['projected_resolution_exception_type'])),'Resolution success and observed failure are distinct')
        editorerrors=re.findall(r'(?im)^.*(?:error CS\d+|Fatal error|Aborting batchmode|TypeLoadException|ReflectionTypeLoadException).*$',editorlog.read_text(encoding='utf-8',errors='replace'));playertext=playerlog.read_text(encoding='utf-8',errors='replace');playererrors=re.findall(r'(?im)^.*(?:Unhandled Exception|Fatal error|ERROR: Shader|Partial constant buffer not found).*$',playertext);need(not editorerrors and not playererrors,'Clean complete logs, with caught binding exception retained only as diagnostic data')
        need('Direct3D:' in playertext and re.search(r'(?im)^\s*Version:\s*Direct3D 11',playertext) and 'Renderer: Null Device' not in playertext,'Actual D3D11 initialization')
        for key in ['raw_SDK','raw_SDK_meta','fixture_SDK','fixture_SDK_meta','projected_SDK','consumer_meta']:check(p[key])
        for sdk in p['exact_original_SDK_dependency_closure']:
            for record in sdk.values():check(record)
        check(consumer_pin);check(p['same_original_compiled_consumer']);check(p['production_manifest']);report.update(status='actual_matching_player_same_consumer_production_reference_inverse_binding_passed',runtime_result=pin(result),projected_consumer_binding_succeeded=observed['projected_consumer_binding_succeeded'],resolution_status=observed['status'],actual_checks=observed['checks'],full_Player_log=pin(playerlog),full_log_error_counts={'Editor':len(editorerrors),'Player':len(playererrors)},all_selected_Main_SDK_and_meta_bytes_unchanged=True,no_runtime_metadata_normalization_or_rename=True,production_reversal_controls=7)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();guard.save(out,report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'projected_consumer_binding_succeeded':report.get('projected_consumer_binding_succeeded'),'error':report.get('error')}));return 0 if report['status']=='actual_matching_player_same_consumer_production_reference_inverse_binding_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without launching');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
