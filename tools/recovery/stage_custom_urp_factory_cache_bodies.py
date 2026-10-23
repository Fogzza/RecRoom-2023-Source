"""Prepare or Root-run seven tested URP body imports outside Main only.

Exact original definitions, all unselected IL, full assembly-reference identity
and order are mandatory. Missing reference scope is HOLD, never auto-appended.
There is no Main apply mode and no Unity/game code is executed.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,re,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
TEST=ROOT/'Validation/CustomUrpFactoryCacheBindingEffects-20261023T091654Z-bb6df7a6/run-report.json'
TEST_SHA='9898dff8b12aa55dc4d2c1bcdf64b927090febd4ba3df92a7c89af07421df6af'
SUPPORT=HERE.parent/'RuntimeMetadataAudit/COMCompatibility-20261022T100736Z';PREVIOUS=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-seven-tested-original-custom-URP-body-only-import/v1'

def need(v,m):
    if not v:raise ValueError(m)

def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:s=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':s}

def check(row):need(pin(row['path'])==row,'Pinned seven-member stage input changed: '+row['path'])

def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')

def tested():
    need(pin(TEST)['sha256']==TEST_SHA,'Exact Root seven-member owner binding/27-effects receipt');r=json.loads(TEST.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['status']=='seven_original_URP_member_bindings_twenty_seven_controlled_effects_passed' and r['selected_members']==7 and r['controlled_effect_cases']==27 and not r['Main_modified'] and not r['production_Donor_or_Unity_code_executed'] and not r['renderer_constructor_disposal_or_frame_closure_claimed'],'Actual bounded controls passed, downstream graph still held')
    phases=['compile-seven-URP-original-owner-donor','compile-seven-URP-controlled-effects','inspect-seven-URP-actual-owner-bindings','twenty-seven-URP-controlled-effects'];need([x['phase'] for x in r['phases']]==phases and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'All four actual Root owned phases passed')
    for row in [p[k] for k in ['runner','template','source','genuine_Unity','copied_Cecil','current_original_DLL','current_original_meta','compiler','mono','guard','launcher']]+p['native_proofs']+p['member_fragments']+p['responses']+p['references']+[r['compiled_donor'],r['compiled_effects']]:check(row)
    need(r['compiled_donor']['path']==p['donor_output'],'Use only exact successfully compiled/inspected donor')
    logs=Path(p['fixture']);text=(logs/'inspect-seven-URP-actual-owner-bindings-stdout.log').read_text();need('RESULT seven_exact_URP_original_owner_member_bindings_passed_metadata_only; production_or_donor_loaded=false' in text,'Actual original-owner metadata result')
    text=(logs/'twenty-seven-URP-controlled-effects-stdout.log').read_text();need(len(re.findall(r'^PASS ',text,re.M))==27 and 'RESULT seven_exact_URP_members_twenty_seven_controlled_effects_passed; real_Unity_dependencies_executed=false; renderer_constructor_disposal_frame_closure=false' in text,'Actual27 controlled effects and honest scope')
    return r,p

def prepare():
    r,p=tested();out=ROOT/'Validation'/('CustomUrpSevenBodyStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    specs=[('UniversalRenderPipelineAsset','CreatePipeline',0,0x0600006a),('UniversalRenderPipelineAsset','DestroyRenderers',0,0x0600006b),('UniversalRenderPipelineAsset','DestroyRenderer',1,0x0600006c),('UniversalRenderPipelineAsset','CreateRenderers',0,0x0600006f),('ForwardRendererData','Create',0,0x06000136),('ScriptableRendererData','InternalCreateRenderer',0,0x06000203),('UniversalRenderPipeline','get_asset',0,0x0600029c)]
    modules=[{'original':p['current_original_DLL'],'meta':p['current_original_meta'],'donor':r['compiled_donor'],'members':[{'owner':'UnityEngine.Rendering.Universal.'+o,'name':n,'parameter_count':count,'current_token':token} for o,n,count,token in specs]}]
    spec=out/'inputs.json';save(spec,{'schema':'seven-tested-custom-URP-body-only-import-input/v1','modules':modules})
    sources=[HERE/'StageCustomUrpFactoryCacheBodies.cs']+[SUPPORT/name for name in ['CanonicalMetadataSignatures.cs','MetadataRoundTripSafety.cs','BodyAndSymbolSafety.cs']]
    old=(PREVIOUS/'compile.rsp').read_text(encoding='utf-8-sig');refs=[Path(s) for s in re.findall(r'(?m)^/reference:"([^"]+)"$',old) if '/packs/Microsoft.NETCore.App.Ref/' in s.replace('\\','/')];need(len(refs)>=100,'Existing exact .NET reference pack')
    cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';refs.append(cecil);shutil.copyfile(cecil,out/cecil.name);output=out/'StageCustomUrpFactoryCacheBodies.dll';rsp=out/'compile.rsp';rsp.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(s)+'"\n' for s in refs)+''.join('"'+str(s)+'"\n' for s in sources),encoding='utf-8',newline='\n')
    shutil.copyfile(PREVIOUS/'OriginalShaderObjectProbe.runtimeconfig.json',output.with_suffix('.runtimeconfig.json'))
    plan={'schema':SCHEMA,'status':'prepared_no_child_no_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'test_receipt':pin(TEST),'test_plan':r['plan'],'native_proofs':p['native_proofs'],'spec':pin(spec),'sources':[pin(s) for s in sources],'tested_donor_source':p['source'],'response':pin(rsp),'references':[pin(s) for s in refs],'runtime':[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],'modules':modules,'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':pin(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),'output':str(output),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'Main_modified':False,'Main_apply_supported':False,'changed_bodies':7,'unselected_method_bodies_all_original_metadata_reference_identity_order_must_equal':True,'automatic_reference_addition_supported':False,'constructor_disposal_frame_closure_claimed':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Frozen guarded owned launcher');target=out/'plan.json';save(target,plan)
    print(json.dumps({'plan':pin(target),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed URP seven-body plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('CustomUrpSevenBodyStage-') and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['changed_bodies']==7 and not p['Main_apply_supported'] and not p['automatic_reference_addition_supported'],'Exact finite no-Main body staging')
    for row in [p[k] for k in ['runner','test_receipt','test_plan','spec','tested_donor_source','response','guard','launcher','dotnet','compiler']]+p['native_proofs']+p['sources']+p['references']+p['runtime']:check(row)
    for row in p['modules']:
        for key in ['original','donor','meta']:check(row[key])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Fixed reviewed runner/guard');tested()
    need(p['output']==str(out/'StageCustomUrpFactoryCacheBodies.dll'),'Fixed new importer output')
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_apply','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh stage outputs only; preserve failed evidence')
    report={'schema':'guarded-seven-tested-original-custom-URP-body-only-stage/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'game_Unity_network_launched':False,'constructor_disposal_frame_closure_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-pure-seven-URP-body-importer',report)
        env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-readback-seven-original-URP-body-only-candidate',report,env)
        result=out/'Candidates/report.json';proof=json.loads(result.read_bytes());need(proof['status']=='seven_tested_URP_bodies_imported_all_original_metadata_other_bodies_preserved' and proof['changed_method_bodies']==7 and len(proof['modules'])==1 and not proof['Main_modified'],'Exact persisted metadata/other-body proof')
        for row in proof['modules']:check(row['candidate']);need(row['entire_donor_bodies_and_scoped_operands_equal'] and row['all_original_MethodDef_tokens_preserved'] and row['changed_methods']==7 and row['assembly_references_appended']==[],'Exact donor-body/token/reference proof')
        for row in p['modules']:check(row['original']);check(row['meta'])
        report.update(status='seven_tested_URP_bodies_staged_all_metadata_references_other_bodies_preserved',result=pin(result),candidates=[row['candidate'] for row in proof['modules']],Main_plugin_and_meta_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}));return 0 if report['status']=='seven_tested_URP_bodies_staged_all_metadata_references_other_bodies_preserved' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed Root plan SHA');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0

if __name__=='__main__':raise SystemExit(main())
