"""Prepare or Root-stage two tested lookup/discovery bodies into current SDK metadata.

Default only prepares/verifies. Only Root --run launches the bounded metadata
importer; no Main apply path exists. Every original metadata feature and every
unselected method body must compare equal before and after candidate emission.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,re,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
TEST=ROOT/'Validation/ContainerProviderDiscoveryBindingEffects-20261023T100113Z-8a26a0bb/run-report.json'
TEST_SHA='245f3108fa4140b2388c51589313696fce9c40c5b35bc2dc70181268116dd9d3'
APPLY=ROOT/'Validation/ContainerKeyChildExactApply-20261023T092636Z-6f0addc4/apply-receipt.json'
APPLY_SHA='b7a6f206834ba24175d6da1cf48d98f5f6643e484439e076140d74545b2b27c8'
SUPPORT=HERE.parent/'RuntimeMetadataAudit/COMCompatibility-20261022T100736Z';PREVIOUS=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-two-tested-container-lookup-discovery-body-only-import/v1'
def need(value,message):
    if not value:raise ValueError(message)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned key/child staging input changed: '+row['path'])
def save(path,data):
    with path.open('x',encoding='utf-8') as f:json.dump(data,f,indent=2);f.write('\n')
def tested():
    import run_container_provider_discovery_harness_v3 as checked
    need(pin(TEST)['sha256']==TEST_SHA,'Exact actual combined provider-discovery30-effect receipt');r=json.loads(TEST.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['schema']=='guarded-original-provider-discovery-Dictionary-combined-effects/v3' and r['status']=='original_provider_discovery_binding_and_thirty_real_Dictionary_combined_cases_passed' and r['selected_members']==2 and r['controlled_cases']==30 and not r['production_SDK_donor_or_held_callees_executed'] and not r['Main_modified'],'Exact passed original-owner and controlled-effect scope')
    need([x['phase'] for x in r['phases']]==['compile-explicit-real-Dictionary-combined-effects-reader-v3','inspect-exact-provider-discovery-and-rechecked-lookup-bindings','thirty-real-Dictionary-discovery-and-combined-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'All three actual successful helper phases; prior native donor compile provenance required separately')
    need(checked.pin(Path(checked.__file__))==p['runner'],'Exact passed v3 validator');checked.execute(Path(r['plan']['path']),r['plan']['sha256'],False)
    need(r['compiled_donor']==p['reused_compiled_donor'] and not r['donor_recompiled'] and r['original_successful_donor_compile_reused']==p['prior_failed_receipt'],'Actual unchanged donor from successful original compile retained')
    for row in p['reviewable_sources']+[r['compiled_donor']]:check(row)
    need(p['sources'][0]['sha256']==p['reviewable_sources'][1]['sha256'] and Path(r['compiled_donor']['path']).name=='UJect.Runtime.dll','Readable exact donor source compiled and inspected with original owner scope')
    need(pin(APPLY)['sha256']==APPLY_SHA,'Exact Root prior four-key/child apply checkpoint');applied=json.loads(APPLY.read_bytes());need(applied['status']=='four_native_key_child_bodies_applied_one_SDK_meta_preserved' and applied['metas_unchanged'] and applied['changed_method_bodies']==4,'Current four-key/child checkpoint remains applied')
    need(len(applied['applied'])==1,'One current UJect module');baseline=applied['applied'][0];check(baseline['source']);check(baseline['meta']);need(baseline['source']==p['original_plugin'] and baseline['meta']==p['original_meta'],'Current applied SDK is the exact original-owner binding baseline')
    return r,p,baseline

def prepare():
    r,p,baseline=tested();out=ROOT/'Validation'/('ContainerLookupDiscoveryBodyStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    modules=[{'original':baseline['source'],'meta':baseline['meta'],'donor':r['compiled_donor'],'members':[{'owner':'MNALHHOLFGL','name':name} for name in ['NGBMOPMLJCM','CPBMOKFMMMK']]}]
    spec=out/'inputs.json';save(spec,{'schema':'two-tested-container-lookup-discovery-body-only-import-input/v1','modules':modules})
    sources=[HERE/'StageContainerLookupDiscoveryBodies.cs']+[SUPPORT/name for name in ['CanonicalMetadataSignatures.cs','MetadataRoundTripSafety.cs','BodyAndSymbolSafety.cs']];old=(PREVIOUS/'compile.rsp').read_text(encoding='utf-8-sig');refs=[Path(x) for x in re.findall(r'(?m)^/reference:"([^"]+)"$',old) if '/packs/Microsoft.NETCore.App.Ref/' in x.replace('\\','/')];need(len(refs)>=100,'Exact previously used framework reference pack')
    cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';refs.append(cecil);shutil.copyfile(cecil,out/cecil.name);output=out/'StageContainerLookupDiscoveryBodies.dll';response=out/'compile.rsp';response.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+''.join('"'+str(x)+'"\n' for x in sources),encoding='utf-8',newline='\n');shutil.copyfile(PREVIOUS/'OriginalShaderObjectProbe.runtimeconfig.json',output.with_suffix('.runtimeconfig.json'))
    plan={'schema':SCHEMA,'status':'prepared_no_child_or_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'test_receipt':pin(TEST),'test_plan':r['plan'],'baseline_Root_apply':pin(APPLY),'spec':pin(spec),'sources':[pin(x) for x in sources],'reviewable_donor_sources':p['reviewable_sources'],'response':pin(response),'references':[pin(x) for x in refs],'runtime':[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],'modules':modules,'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':pin(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),'output':str(output),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'Main_modified':False,'Main_apply_supported':False,'changed_bodies':2,'all_original_metadata_and_unselected_bodies_must_be_equal':True,'new_AssemblyRefs_permitted':False,'registration_or_provider_functionality_claimed':False,'original_LNF_or_provider_methods_executed':False,'actual_SDK_callers_executed':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed bounded owned suspended guard');target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed body stage plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerLookupDiscoveryBodyStage-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['changed_bodies']==2 and not p['Main_apply_supported'] and not p['new_AssemblyRefs_permitted'],'Exact isolated four-body scope with no metadata additions')
    for row in [p[k] for k in ['runner','test_receipt','test_plan','baseline_Root_apply','spec','response','guard','launcher','dotnet','compiler']]+p['sources']+p['reviewable_donor_sources']+p['references']+p['runtime']:check(row)
    for row in p['modules']:
        for key in ['original','donor','meta']:check(row[key])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact current reviewed stage helper/guards');tested()
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_apply','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh one-shot outputs only; failures preserved');report={'schema':'guarded-two-tested-container-lookup-discovery-body-only-stage/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'game_Unity_or_network_launched':False,'registration_or_provider_functionality_claimed':False,'original_LNF_or_provider_methods_executed':False,'actual_SDK_callers_executed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-pure-two-lookup-discovery-body-importer',report);env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-and-readback-two-original-lookup-discovery-bodies',report,env)
        result=out/'Candidates/report.json';data=json.loads(result.read_bytes());need(data['status']=='two_tested_lookup_discovery_bodies_imported_all_original_metadata_other_bodies_preserved' and data['changed_method_bodies']==2 and len(data['modules'])==1 and not data['Main_modified'],'All four emitted bodies and metadata preservation actual proof')
        for row in data['modules']:check(row['candidate']);need(row['entire_donor_bodies_and_scoped_operands_equal'] and row['all_original_MethodDef_tokens_preserved'],'All exact donor operands/MethodDef tokens preserved')
        for row in p['modules']:check(row['original']);check(row['meta'])
        report.update(status='two_tested_lookup_discovery_bodies_staged_all_metadata_and_other_bodies_preserved',result=pin(result),candidates=[row['candidate'] for row in data['modules']],Main_plugin_and_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}));return 0 if report['status']=='two_tested_lookup_discovery_bodies_staged_all_metadata_and_other_bodies_preserved' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
