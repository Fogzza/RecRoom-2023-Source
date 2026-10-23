"""Fresh isolated seven-body staging with an exact, finite Cecil row mapping.

No Main apply path. The original v1/v2 failures stay frozen. This explicitly
reports raw RID changes and four unnamed ordinary Param record omissions;
semantic metadata, scoped refs, resources and all other bodies stay strict.
Only Root may request the guarded compiler/metadata stages with --run.
"""
from pathlib import Path
import argparse,copy,datetime as dt,difflib,json,os,shutil,uuid
import stage_custom_urp_factory_cache_bodies_v2 as v2
from stage_custom_urp_factory_cache_bodies_v2 import HERE,WS,ROOT,guard,pin,check,need,save,tested
import audit_custom_urp_cecil_reindex as raw
import audit_custom_urp_cecil_reindex_v2 as cil

SCHEMA='prepared-seven-tested-original-custom-URP-finite-reindex/v3'
BASE_CS_SHA='6320df929bbc412c265f49b32b0edd0c271a98c7cce94e2818be89d944d150d0'
BASE_RUNNER_SHA='58ec9b1db53b0c99fc660faeec5c42847ad4fea2eb508ae90039dc325df4f37d'
FAILED=ROOT/'Validation/CustomUrpSevenBodyStageV2-20261023T093103Z-251472b4/run-report.json'
FAILED_SHA='f225948f90a718c62fb7bd3222ecc2efeeeae1f9521fbbc493e3c8215bd35667'
DIAG=ROOT/'Validation/CustomUrpFiniteReindexDiagnosisV2-20261023T094548Z-7c2f814e/report.json'
DIAG_SHA='7eda8ad0bd0ec6b20da55574e72fcbfad0637e521869076c66480ade20db375b'
OMITTED=[0x080002d3,0x080004ad,0x080004ae,0x080004af]

def diagnostic():
    need(pin(DIAG)['sha256']==DIAG_SHA,'Frozen actual raw-CLI/CIL diagnosis');d=json.loads(DIAG.read_bytes())
    need(d['method_body_comparison']['unselected_scoped_entire_CIL_equal'] and d['method_body_comparison']['unselected']==1609 and set(map(lambda s:int(s,16),d['method_body_comparison']['changed_original_tokens']))==raw.SELECTED,'Exact 1609 preserved bodies and seven changed methods')
    need(len(d['removed_Param_row_complete_diagnosis'])==4 and all(x['empty_name_zero_flags_no_attachment'] for x in d['removed_Param_row_complete_diagnosis']),'Only explicit empty ordinary Param records')
    for row in d['inputs']:check(row)
    for row in [d['tool'],d['tool']['frozen_base'],d['writer_preservation_evidence']['assembly']]:need(pin(row['path'])['sha256']==row['sha256'],'Frozen pure diagnostic/writer source')
    return d

def finite_spec(d):
    tables=[]
    for t in [2,4,6,8,20,23,42]:
        m=d['definition_maps'][str(t)];tables.append({'table':t,'original_count':m['original_count'],'emitted_count':m['emitted_count'],'rows':[{'original_token':int(r['original_token'],16),'emitted_token':int(r['emitted_token'],16)} for r in m['bijection']]})
    return {'schema':'exact-frozen-URP-definition-reindex-and-four-empty-Param-omissions/v1','diagnosis':pin(DIAG),'tables':tables,'omitted_empty_Param_tokens':OMITTED,'raw_RID_preserved':False,'raw_Param_row_count_preserved':False,'semantic_parameter_slot_name_flags_type_attributes_constant_marshal_preserved':True}

def make_source():
    source=HERE/'StageCustomUrpFactoryCacheBodies.v2.cs';need(pin(source)['sha256']==BASE_CS_SHA,'Frozen executed v2 C#');text=source.read_text();replace=v2.replace_once
    text=replace(text,'static class StageCustomUrpFactoryCacheBodiesV2','static class StageCustomUrpFactoryCacheBodiesV3')
    text=replace(text,'static string Features(ModuleDefinition module)','static string Features(ModuleDefinition module,Dictionary<string,uint> originalTokens=null)')
    text=replace(text,'b.Append(m.MetadataToken.ToUInt32()).Append(\':\')','b.Append(originalTokens==null?m.MetadataToken.ToUInt32():originalTokens[MethodKey(m)]).Append(\':\')')
    text=replace(text,'seven-tested-custom-URP-body-only-import-input/v2','seven-tested-custom-URP-body-only-import-input/v3')
    old='var tokens=all.Select(m=>m.MetadataToken.ToUInt32()).ToArray();'
    new='var rawDefinitions=FiniteOriginalDefinitionReindex.Capture(target);var originalMethodTokens=all.ToDictionary(MethodKey,m=>m.MetadataToken.ToUInt32(),StringComparer.Ordinal);var originalSelected=selected.Select(m=>new{owner=m.DeclaringType.FullName,name=m.Name,current_MethodDef_token=m.MetadataToken.ToUInt32()}).ToArray();'
    text=replace(text,old,new)
    text=replace(text,'Need(methods.Select(m=>m.MetadataToken.ToUInt32()).SequenceEqual(tokens),"Every original MethodDef token/order retained");','FiniteOriginalDefinitionReindex.Verify(rawDefinitions,emitted,spec.GetProperty("finite_reindex"));')
    text=replace(text,'Features(emitted)==features','Features(emitted,originalMethodTokens)==features')
    text=replace(text,'selected_original_members=selected.Select(m=>new{owner=m.DeclaringType.FullName,name=m.Name,current_MethodDef_token=m.MetadataToken.ToUInt32()}).ToArray()','selected_original_members=originalSelected')
    text=replace(text,'all_original_MethodDef_tokens_preserved=true','all_original_MethodDef_tokens_preserved=false,finite_definition_token_reindex_verified=true,raw_empty_ordinary_Param_rows_omitted=4,raw_metadata_identity_claimed=false')
    text=replace(text,'seven-tested-original-custom-URP-body-only-staged-candidates/v2','seven-tested-original-custom-URP-body-only-staged-candidates/v3')
    text=replace(text,'modules=results,exact_pinned_metadata_resolver_used=true','modules=results,finite_reindex=spec.GetProperty("finite_reindex"),raw_RID_and_four_empty_Param_normalization_explicit=true,exact_pinned_metadata_resolver_used=true')
    text=replace(text,'Seven tested original URP members staged; all original metadata/references/other bodies verified; Main unchanged.','Seven tested original URP members staged; semantic metadata/refs/other bodies verified; exact finite RID remap and four empty Param omissions explicit; Main unchanged.')
    target=HERE/'StageCustomUrpFactoryCacheBodies.v3.cs';data=text.encode('utf-8')
    if target.exists():need(target.read_bytes()==data,'Never overwrite an existing v3 source')
    else:target.write_bytes(data)
    return source,target

def python_map_gate(spec,before,after):
    oldSeen=set();newSeen=set()
    need([t['table'] for t in spec['tables']]==[2,4,6,8,20,23,42],'Exact tables')
    for table in spec['tables']:
        t=table['table'];need(sum(k>>24==t for k in before)==table['original_count'] and sum(k>>24==t for k in after)==table['emitted_count'],'Exact counts');need(len(table['rows'])==table['emitted_count'],'Entire map')
        for row in table['rows']:
            a,b=row['original_token'],row['emitted_token'];need(a>>24==t and b>>24==t and a not in oldSeen and b not in newSeen,'Token uniqueness/table');oldSeen.add(a);newSeen.add(b);need(a in before and b in after and before[a]==after[b],'Exact finite owner identity')
    need(spec['omitted_empty_Param_tokens']==OMITTED,'Exact omissions')
    for token in OMITTED:need(token not in oldSeen and token in before and before[token] not in after.values(),'Exact absent Param');oldSeen.add(token)
    need(set(before)==oldSeen and set(after)==newSeen,'Whole original/emitted maps')

def controls(spec,d):
    before={};after={}
    for t,m in d['definition_maps'].items():
        for r in m['bijection']:before[int(r['original_token'],16)]=raw.key(r['identity']);after[int(r['emitted_token'],16)]=raw.key(r['identity'])
        for r in m['removed']:before[int(r['original_token'],16)]=raw.key(r['identity'])
    python_map_gate(spec,before,after);tests=['actual_frozen_6091_to_6087_definition_map_passed'];mutations=[]
    for table in [2,4,6,8,20,23,42]:
        def mutate(s,b,a,t=table):next(x for x in s['tables'] if x['table']==t)['rows'][0]['emitted_token']^=1
        mutations.append(('wrong_finite_token_table_'+str(table),mutate))
    mutations += [('wrong_original_count',lambda s,b,a:s['tables'][0].update(original_count=300)),('missing_finite_row',lambda s,b,a:s['tables'][2]['rows'].pop()),('different_omitted_Param',lambda s,b,a:s['omitted_empty_Param_tokens'].__setitem__(0,0x080002d2)),('extra_definition',lambda s,b,a:a.update({0x0600ffff:'extra'})),('changed_scoped_definition',lambda s,b,a:a.update({next(iter(a)):'different-scoped-owner'})),('unlisted_Param_omission',lambda s,b,a:a.pop(next(k for k in a if k>>24==8)))]
    for name,mutate in mutations:
        s,b,a=copy.deepcopy(spec),dict(before),dict(after);mutate(s,b,a)
        try:python_map_gate(s,b,a)
        except (ValueError,KeyError):tests.append(name+'_refused')
        else:raise ValueError('Negative control accepted '+name)
    return {'schema':'pure-finite-original-definition-map-admission-controls/v1','status':'passed','controls':len(tests),'cases':tests,'actual_managed_importer_executed':False,'scope':'Python map admission controls; Root must compile/run actual C# and all unchanged metadata/body gates','diagnosis':pin(DIAG)}

def verify_candidate(path,d):
    a=raw.Model(raw.ORIGINAL);b=raw.Model(path);previous=raw.Model(raw.CANDIDATE);need(b.r.asm==a.r.asm,'Exact full assembly identity')
    actual_counts={str(t):{'original':a.c.rows[t],'emitted':b.c.rows[t]} for t in range(45) if a.c.rows[t] or b.c.rows[t]};need(actual_counts==d['table_counts'],'No unlisted table count change')
    for t,m in d['definition_maps'].items():
        t=int(t);left={v:ri for (tt,ri),v in a.names.items() if tt==t};right={v:ri for (tt,ri),v in b.names.items() if tt==t};need(len(left)==a.c.rows[t] and len(right)==b.c.rows[t],'Unique definition identity')
        actual=[{'identity':json.loads(v) if v[0]=='{' else v,'original_token':hex(t<<24|left[v]),'emitted_token':hex(t<<24|right[v])} for v in sorted(left.keys()&right.keys())];need(actual==m['bijection'] and set(left)-set(right)=={raw.key(r['identity']) if isinstance(r['identity'],dict) else r['identity'] for r in m['removed']} and not(set(right)-set(left)),'Exact pinned finite definition map')
    aa=a.associations();bb=b.associations();need({k:raw.differences(aa.get(k,[]),bb.get(k,[])) for k in sorted(aa.keys()|bb.keys())}==d['scoped_metadata_deltas'],'All raw scoped metadata associations/constants/attributes exact except listed empty Params')
    for t,expected in d['reference_table_deltas'].items():
        t=int(t);actual={'original_count':a.c.rows[t],'emitted_count':b.c.rows[t],**raw.differences([a.token(t<<24|i) for i in range(1,a.c.rows[t]+1)],[b.token(t<<24|i) for i in range(1,b.c.rows[t]+1)])};need(actual==expected,'Exact scoped TypeRef/MemberRef/local/TypeSpec delta, no unlisted operand authority')
    bykey={v:ri for (t,ri),v in b.names.items() if t==6};oldkeys={v:ri for (t,ri),v in previous.names.items() if t==6};unselected=selected=0
    for mi in range(1,a.c.rows[6]+1):
        identity=a.names[6,mi];emitted=cil.decode(b,bykey[identity])
        if 6<<24|mi in raw.SELECTED:need(emitted==cil.decode(previous,oldkeys[identity]),'Entire selected CIL matches exact prior mapped tested donor');selected+=1
        else:need(cil.decode(a,mi)==emitted,'Entire unselected raw CIL/locals/maxstack/EH/branch/scoped operands');unselected+=1
    need(selected==7 and unselected==1609,'Exact original body counts')
    return {'schema':'independent-pure-raw-CLI-finite-URP-stage-validation/v1','status':'passed','candidate':pin(path),'diagnosis':pin(DIAG),'all_1609_unselected_entire_CIL_equal':True,'all_7_selected_entire_CIL_equal_previous_tested_mapping':True,'all_definition_maps_exact_pinned':True,'all_raw_scoped_metadata_deltas_exact_pinned':True,'all_reference_table_additions_exact_pinned':True,'raw_RID_preserved':False,'raw_empty_ordinary_Param_rows_omitted':4,'Main_modified':False}

def prepare():
    need(pin(Path(v2.__file__))['sha256']==BASE_RUNNER_SHA and pin(FAILED)['sha256']==FAILED_SHA,'Frozen v2 runner/failure');d=diagnostic();r,p=tested();failed=json.loads(FAILED.read_bytes());oldplan=json.loads(Path(failed['plan']['path']).read_bytes());check(failed['plan']);base,source=make_source();out=ROOT/'Validation'/('CustomUrpSevenBodyStageV3-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    spec=json.loads(Path(oldplan['spec']['path']).read_bytes());check(oldplan['spec']);spec['schema']='seven-tested-custom-URP-body-only-import-input/v3';spec['finite_reindex']=finite_spec(d);sp=out/'inputs.json';save(sp,spec)
    cp=out/'offline-controls.json';save(cp,controls(spec['finite_reindex'],d));dp=out/'finite-reindex-amendment.diff';dp.write_text(''.join(difflib.unified_diff(base.read_text().splitlines(True),source.read_text().splitlines(True),fromfile=str(base),tofile=str(source))))
    helper=HERE/'FiniteOriginalDefinitionReindex.cs';sources=[source]+[Path(x['path']) for x in oldplan['sources'][1:]]+[helper];refs=oldplan['references'];[check(x) for x in refs];cecil=next(Path(x['path']) for x in refs if Path(x['path']).name=='Mono.Cecil.dll');shutil.copyfile(cecil,out/cecil.name)
    output=out/'StageCustomUrpFactoryCacheBodiesV3.dll';rsp=out/'compile.rsp';rsp.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+x['path']+'"\n' for x in refs)+''.join('"'+str(x)+'"\n' for x in sources),encoding='utf-8',newline='\n');shutil.copyfile(Path(oldplan['output']).with_suffix('.runtimeconfig.json'),output.with_suffix('.runtimeconfig.json'))
    plan=copy.deepcopy(oldplan);plan.update(schema=SCHEMA,status='prepared_no_child_no_Main_write',fixture=str(out),runner=pin(Path(__file__)),base_v2_runner=pin(Path(v2.__file__)),base_v2_source=pin(base),failed_v2_receipt=pin(FAILED),failed_v2_plan=failed['plan'],diagnosis=pin(DIAG),diagnostic_tools=[d['tool'],d['tool']['frozen_base']],spec=pin(sp),sources=[pin(x) for x in sources],response=pin(rsp),runtime=[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],output=str(output),finite_reindex_amendment=pin(dp),offline_controls=pin(cp),all_original_metadata_reference_scopes_constants_and_other_bodies_preservation_gates_unchanged=True,raw_RID_and_four_empty_Param_normalization_explicit=True,independent_raw_CLI_validation_required=True)
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'controls':pin(cp),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Exact reviewed v3 plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('CustomUrpSevenBodyStageV3-') and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['changed_bodies']==7 and not p['Main_apply_supported'] and not p['automatic_reference_addition_supported'],'Exact bounded finite amendment only');d=diagnostic()
    for row in [p[k] for k in ['runner','base_runner','base_v2_runner','base_v2_source','failed_v1_receipt','failed_v1_plan','frozen_v1_source','failed_v2_receipt','failed_v2_plan','diagnosis','resolver_amendment','test_receipt','test_plan','spec','tested_donor_source','response','guard','launcher','dotnet','compiler','finite_reindex_amendment','offline_controls']]+p['native_proofs']+p['sources']+p['references']+p['framework_authority']+p['runtime']:check(row)
    for row in p['metadata_references']:check({k:row[k] for k in ['path','bytes','sha256']});need(v2.identity(row['path'])==row['full_name'],'Exact metadata full identity')
    for row in p['modules']:
        for k in ['original','donor','meta']:check(row[k])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==v2.GUARD_SHA and p['launcher']['sha256']==v2.LAUNCH_SHA and p['output']==str(out/'StageCustomUrpFactoryCacheBodiesV3.dll'),'Pinned runner/guard/fresh output');tested();spec=json.loads(Path(p['spec']['path']).read_bytes());need(spec['finite_reindex']==finite_spec(d),'Exact reviewed complete finite map');need(json.loads(Path(p['offline_controls']['path']).read_bytes())==controls(spec['finite_reindex'],d),'Fresh repeated pure map controls')
    if not run:print(json.dumps({'status':'verified_no_child_no_Main_apply','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh v3 outputs only')
    report={'schema':'guarded-seven-original-custom-URP-body-stage-finite-reindex/v3','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'game_Unity_network_launched':False,'constructor_disposal_frame_closure_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-pure-seven-URP-finite-reindex-importer',report)
        env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-readback-seven-original-URP-finite-reindex-candidate',report,env)
        result=out/'Candidates/report.json';proof=json.loads(result.read_bytes());need(proof['schema']=='seven-tested-original-custom-URP-body-only-staged-candidates/v3' and proof['status']=='seven_tested_URP_bodies_imported_all_original_metadata_other_bodies_preserved' and proof['exact_pinned_metadata_resolver_used'] and proof['raw_RID_and_four_empty_Param_normalization_explicit'] and proof['changed_method_bodies']==7 and len(proof['modules'])==1 and not proof['Main_modified'],'All unchanged C# semantic metadata/resource/ref/body gates and exact finite map')
        for row in proof['modules']:
            check(row['candidate']);need(row['entire_donor_bodies_and_scoped_operands_equal'] and not row['all_original_MethodDef_tokens_preserved'] and row['finite_definition_token_reindex_verified'] and row['raw_empty_ordinary_Param_rows_omitted']==4 and not row['raw_metadata_identity_claimed'] and row['changed_methods']==7 and row['assembly_references_appended']==[],'Explicit finite raw-row changes only');pure=verify_candidate(Path(row['candidate']['path']),d)
        pp=out/'independent-raw-CLI-validation.json';save(pp,pure)
        for row in p['modules']:check(row['original']);check(row['meta'])
        report.update(status='seven_tested_URP_bodies_staged_semantic_metadata_other_bodies_preserved_exact_finite_raw_reindex',result=pin(result),independent_raw_CLI_validation=pin(pp),candidates=[r['candidate'] for r in proof['modules']],Main_plugin_and_meta_unchanged=True,raw_RID_preserved=False,raw_empty_ordinary_Param_rows_omitted=4)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}));return 0 if report['status']=='seven_tested_URP_bodies_staged_semantic_metadata_other_bodies_preserved_exact_finite_raw_reindex' else 1

def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--plan',type=Path);p.add_argument('--plan-sha256');p.add_argument('--run',action='store_true');a=p.parse_args()
    if a.plan:need(a.plan_sha256,'Reviewed Root plan SHA');return execute(a.plan,a.plan_sha256,a.run)
    need(not a.run and not a.plan_sha256,'Prepare only first');prepare();return 0

if __name__=='__main__':raise SystemExit(main())
