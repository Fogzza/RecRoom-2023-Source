"""Prepare or Root-stage eight tested preparation bodies, outside Main only.

Exact existing closure aliases and both foreach EH regions are preserved through
body-only mapping. LNF activation is HELD pending real graph and FIKO closure.
No apply path exists. Default preparation/verification starts no child.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,re,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
TEST=ROOT/'Validation/ContainerPreparationBindingEffects-20261023T104654Z-1fb26c16/run-report.json'
TEST_SHA='0cb4de1a437f61beaec9ad2e3c86f6504c3fbca42704b820da3fa06a17fb0ba0'
SUPPORT=HERE.parent/'RuntimeMetadataAudit/COMCompatibility-20261022T100736Z';PREVIOUS=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-eight-tested-container-preparation-body-only-stage/v1'
TOKENS=[0x0600002f,0x06000033,0x06000035,0x0600003d,0x06000044,0x06000048,0x06000062,0x06000064]
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:h=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':h}
def check(r):need(pin(r['path'])==r,'Pinned preparation stage input changed: '+r['path'])
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def tested():
    import run_container_preparation_harness as tested
    need(pin(TEST)['sha256']==TEST_SHA,'Exact actual8-binding/50-effect successful receipt');r=json.loads(TEST.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['schema']=='guarded-eight-original-preparation-bindings-fifty-effects/v1' and r['status']=='eight_original_preparation_bindings_and_fifty_real_Dictionary_LINQ_controlled_effects_passed' and r['selected_changed_members']==8 and r['controlled_cases']==50 and not r['production_SDK_donor_graph_or_provider_code_executed'] and not r['Main_modified'] and not r['working_bootstrap_claimed'] and r['all_original_SDK_meta_and_Main_unchanged'],'Actual eight selected bodies and50 honest controlled effects')
    need([x['phase'] for x in r['phases']]==['compile-eight-original-owner-preparation-donor','compile-eight-preparation-metadata-reader','compile-exact-preparation-controlled-effects','inspect-eight-original-preparation-bindings-and-foreach-EH','fifty-real-Dictionary-LINQ-preparation-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'All five actual successful owned phases')
    tested.execute(Path(r['plan']['path']),r['plan']['sha256'],False)
    check(r['compiled_donor']);need(r['compiled_donor']['path']==p['donor_output'] and Path(r['compiled_donor']['path']).name=='UJect.Runtime.dll','Exact actually compiled original-owner donor');return r,p
def raw_tables(path):
    from audit_cli_marshal_contracts import Cli
    c=Cli(Path(path).read_bytes());return {str(i):c.rows[i] for i in range(45)}
def prepare():
    r,p=tested();out=ROOT/'Validation'/('ContainerPreparationBodyStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();module={'original':p['original_plugin'],'meta':p['original_meta'],'donor':r['compiled_donor']};spec=out/'inputs.json';save(spec,{'schema':'eight-tested-container-preparation-body-only-input/v1','module':module})
    sources=[HERE/'StageContainerPreparationBodies.cs']+[SUPPORT/x for x in ['CanonicalMetadataSignatures.cs','MetadataRoundTripSafety.cs','BodyAndSymbolSafety.cs']];old=(PREVIOUS/'compile.rsp').read_text(encoding='utf-8-sig');refs=[Path(x) for x in re.findall(r'(?m)^/reference:"([^"]+)"$',old) if '/packs/Microsoft.NETCore.App.Ref/' in x.replace('\\','/')];need(len(refs)>=100,'Existing genuine .NET reference pack');cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';refs.append(cecil);shutil.copyfile(cecil,out/cecil.name);output=out/'StageContainerPreparationBodies.dll';response=out/'compile.rsp';response.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+''.join('"'+str(x)+'"\n' for x in sources),encoding='utf-8',newline='\n');shutil.copyfile(PREVIOUS/'OriginalShaderObjectProbe.runtimeconfig.json',output.with_suffix('.runtimeconfig.json'))
    plan={'schema':SCHEMA,'status':'prepared_no_child_no_Main_apply','fixture':str(out),'runner':pin(Path(__file__)),'test_receipt':pin(TEST),'test_plan':r['plan'],'spec':pin(spec),'sources':[pin(x) for x in sources],'reviewable_test_sources':p['readable_selected_sources']+[p['template'],p['metadata_reader']],'native_proofs':p['native_proofs'],'module':module,'response':pin(response),'references':[pin(x) for x in refs],'runtime':[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':pin(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),'output':str(output),'selected_original_tokens':TOKENS,'original_raw_table_counts':raw_tables(module['original']['path']),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'changed_method_bodies':8,'donor_only_alias_edits':8,'unchanged_genuinely_empty_closure_constructors':2,'all_original_definitions_semantic_metadata_AssemblyRefs_and_unselected_bodies_must_be_equal':True,'body_owned_reference_local_rows_may_be_emitted':True,'Main_apply_supported':False,'LNF_Main_activation_held':True,'graph_roots_sort_cycle_and_FIKO_unrecovered':True,'working_bootstrap_claimed':False,'production_SDK_or_donor_executed':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed owned suspended launch guards');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed8-body staging plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerPreparationBodyStage-') and p['schema']==SCHEMA and p['selected_original_tokens']==TOKENS and p['changed_method_bodies']==8 and p['donor_only_alias_edits']==8 and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and not p['Main_apply_supported'] and p['LNF_Main_activation_held'] and p['graph_roots_sort_cycle_and_FIKO_unrecovered'] and not p['working_bootstrap_claimed'],'Exact isolated8-body scope and explicit LNF hold')
    for r in [p[k] for k in ['runner','test_receipt','test_plan','spec','response','guard','launcher','dotnet','compiler']]+p['sources']+p['reviewable_test_sources']+p['native_proofs']+p['references']+p['runtime']+list(p['module'].values()):check(r)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact current helper/guard');r,t=tested();need(p['test_plan']==r['plan'] and p['module']=={'original':t['original_plugin'],'meta':t['original_meta'],'donor':r['compiled_donor']} and json.loads(Path(p['spec']['path']).read_bytes())=={'schema':'eight-tested-container-preparation-body-only-input/v1','module':p['module']} and raw_tables(p['module']['original']['path'])==p['original_raw_table_counts'],'Exact actual8/50/current SDK and fixed importer input')
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_apply','selected_bodies':8,'LNF_Main_activation_held':True,'plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh one-shot outputs; preserve all failures');report={'schema':'guarded-eight-tested-container-preparation-body-only-stage/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Main_apply_supported':False,'LNF_Main_activation_held':True,'working_bootstrap_claimed':False,'production_SDK_or_donor_executed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-pure-eight-preparation-body-importer',report);env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-readback-eight-preparation-bodies-original-metadata-and-EH',report,env)
        result=out/'Candidates/report.json';data=json.loads(result.read_bytes());need(data['schema']=='eight-tested-original-preparation-body-only-candidate/v1' and data['status']=='eight_tested_preparation_bodies_staged_original_metadata_other_bodies_and_EH_preserved' and data['changed_method_bodies']==8 and sorted(x['token'] for x in data['selected_original_members'])==TOKENS and data['all_original_MethodDef_tokens_preserved'] and data['entire_donor_bodies_scoped_operands_locals_branches_and_EH_equal'] and not data['original_runtime_metadata_names_changed'] and not data['game_code_loaded_or_executed'] and not data['Main_modified'] and data['LNF_Main_activation_held'] and data['graph_roots_sort_cycle_and_FIKO_still_unrecovered'],'Exact actual8-body/EH preservation with no production activation');check(data['candidate']);before=p['original_raw_table_counts'];after=raw_tables(data['candidate']['path']);allowed={1,10,17,27,43};need(all(before[str(i)]==after[str(i)] for i in range(45) if i not in allowed),'No definition/attribute/interface/accessor/AssemblyRef row-count changes; body-owned reference/local tables only')
        for row in p['module'].values():check(row)
        report.update(status='eight_tested_preparation_bodies_staged_metadata_other_bodies_and_EH_preserved_LNF_activation_held',result=pin(result),candidate=data['candidate'],original_raw_table_counts=before,candidate_raw_table_counts=after,raw_table_count_changes={str(i):{'before':before[str(i)],'after':after[str(i)]} for i in range(45) if before[str(i)]!=after[str(i)]},body_owned_reference_local_tables_only=True,Main_plugin_and_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}));return 0 if report['status']=='eight_tested_preparation_bodies_staged_metadata_other_bodies_and_EH_preserved_LNF_activation_held' else 1
def main():
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--plan',type=Path);parser.add_argument('--plan-sha256');parser.add_argument('--run',action='store_true');a=parser.parse_args()
    if a.plan:need(a.plan_sha256,'Explicit reviewed plan SHA required');return execute(a.plan,a.plan_sha256,a.run)
    need(not a.run and not a.plan_sha256,'Prepare only first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
