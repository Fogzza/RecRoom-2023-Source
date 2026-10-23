"""Prepare or Root-run two tested getter-body imports outside Main only.

Requires actual successful owner-binding and 10-effect proof. The helper copies
only compiled member IL into current original modules, then verifies all other
bodies, original metadata, scoped operands, and MethodDef tokens after emission.
There is deliberately no Main apply option in this tool.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,re,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
TEST=ROOT/'Validation/ContainerLowerBindingEffects-20261023T082117Z-55631a6f/run-report.json'
TEST_SHA='6704e21076307dfdd2ac7f9f989d38811d9f6cc4b082b4c474ca6188367a2c8d'
APPLY=ROOT/'Validation/StartupThreeMemberExactApply-20261023T075506Z-0cb9bede/apply-receipt.json'
APPLY_SHA='686b35bc95bc1a1659f020650f08d63a6b0fd4f5244f46aa6263547352f10756'
SUPPORT=HERE.parent/'RuntimeMetadataAudit/COMCompatibility-20261022T100736Z'
PREVIOUS=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
SCHEMA='prepared-eight-tested-container-lower-body-only-import/v3'
LOGGER_PROOF=ROOT/'Validation/ContainerLoggingReferenceScope-20261023T084115Z-0801e690/report.json'
LOGGER_PROOF_SHA='645e805a0ef6d4c3d443be20d8b38892052a2ac79175cc1f6eb9f061a586d2a4'
SECOND=ROOT/'Validation/ContainerLowerBodyStage-20261023T083956Z-abc827b6'
SECOND_SHA='479d942c14e806e17bd9db80ddf799ebf77d62995a08ab0f58b15d177ab8db70'
DIAGNOSTIC=ROOT/'Validation/ContainerLowerBodyStage-20261023T083304Z-0f3f0b4b'
DIAGNOSTIC_SHA='9c20a27d844e9a3be41a6fd7d42ae5854baa8af50b86c16722cee64a8855000a'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:s=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':s}
def check(row):need(pin(row['path'])==row,'Pinned body-only import input changed: '+row['path'])
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def validate_append(before,after,refs,required):
    need(required=='RecRoom.Debugging.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' and required not in before and after.count(required)==1,'Only the exact genuinely missing native logger reference')
    need(refs and before.count(refs[0])==1,'Exact original reference block');start=before.index(refs[0]);need(before[start:start+len(refs)]==refs,'Original reference order');at=start+len(refs);need(after==before[:at]+[required]+before[at:],'Only one append after every original reference; all other metadata segments byte-identical')

def logger_scope():
    need(pin(LOGGER_PROOF)['sha256']==LOGGER_PROOF_SHA and pin(SECOND/'run-report.json')['sha256']==SECOND_SHA,'Frozen native SDK ownership and exact second diagnostic');proof=json.loads(LOGGER_PROOF.read_bytes());need(proof['status']=='one_exact_native_required_reference_proved_no_metadata_changed' and proof['native_logger']['index']==47093 and proof['native_logger']['image']=='RecRoom.Debugging.Runtime.dll','Exact native caller-to-assembly ownership')
    for key in ['native_factory_proof','actual_retained_SDK','actual_retained_SDK_meta','current_caller','current_caller_meta']:check(proof[key])
    prefix=SECOND/'Candidates';before=(prefix/'RecRoom.AgInitialization.Runtime.dll.before-metadata.txt').read_text().split('|');after=(prefix/'RecRoom.AgInitialization.Runtime.dll.after-metadata.txt').read_text().split('|');refs=proof['original_ordered_references'];required=proof['sole_proposed_append'];validate_append(before,after,refs,required)
    gates=json.loads((prefix/'RecRoom.AgInitialization.Runtime.dll.metadata-gates.json').read_bytes());need(gates['before_features']==gates['after_features'],'Second diagnostic has no module-feature changes')
    controls=[]
    for name,changed in [('duplicate',after+[required]),('extra-ref',after+['extra']),('missing-original',[x for x in after if x!=refs[0]]),('reordered-original',[refs[1] if x==refs[0] else refs[0] if x==refs[1] else x for x in after]),('changed-other-metadata',after[:-1]+['changed']),('wrong-version',[x.replace('Version=0.0.0.0','Version=1.0.0.0') if x==required else x for x in after]),('wrong-token',[x.replace('PublicKeyToken=null','PublicKeyToken=0011223344556677') if x==required else x for x in after]),('wrong-owner',[x.replace('RecRoom.Debugging.Runtime','Other.SDK') if x==required else x for x in after])]:
        try:validate_append(before,changed,refs,required)
        except ValueError:controls.append({'case':name,'rejected':True})
        else:raise ValueError('Changed reference/metadata accepted '+name)
    return proof,controls,[pin(LOGGER_PROOF),pin(SECOND/'run-report.json')]+[pin(prefix/name) for name in ['RecRoom.AgInitialization.Runtime.dll.before-metadata.txt','RecRoom.AgInitialization.Runtime.dll.after-metadata.txt','RecRoom.AgInitialization.Runtime.dll.metadata-gates.json']]

def tested():
    need(pin(TEST)['sha256']==TEST_SHA,'Exact actual eight-member binding/effect receipt');r=json.loads(TEST.read_bytes());check(r['plan']);p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['status']=='eight_original_member_bindings_and_twenty_six_controlled_cases_passed' and r['controlled_effect_cases']==26 and r['selected_member_count']==8 and not r['production_modules_executed'] and not r['Main_modified'],'Actual original-owner metadata binding and26 effects required')
    need([x['phase'] for x in r['phases']]==['compile-eight-member-Uject-donor','compile-eight-member-initialization-donor','compile-explicit-lower-member-effects-reader','inspect-eight-original-member-bindings','twenty-six-original-lower-member-controlled-effects'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'Exact five successful owned phases')
    for row in [p[k] for k in ['runner','proof','template','disposed_dependency_source','compiler','mono','constructor_access_metadata_authority']]+p['sources']+p['references']+p['reviewable_donor_sources']+r['compiled_donors']:check(row)
    for row in p['original_modules']:check(row['DLL']);check(row['meta'])
    need(len(p['original_modules'])==len(r['compiled_donors'])==2,'Exact two modules/donors')
    for source,readable in zip(p['sources'][:2],p['reviewable_donor_sources']):need(source['sha256']==readable['sha256'] and source['bytes']==readable['bytes'],'Fixed readable donor equals actual successfully compiled source')
    return r,p

def prepare():
    scope,append_controls,scope_pins=logger_scope();r,p=tested();readable=p['reviewable_donor_sources'];need(pin(DIAGNOSTIC/'run-report.json')['sha256']==DIAGNOSTIC_SHA,'Exact original metadata delta diagnostic');diagnostic_pins=[pin(DIAGNOSTIC/'run-report.json')]+[pin(DIAGNOSTIC/'Candidates'/name) for name in ['UJect.Runtime.dll.before-metadata.txt','UJect.Runtime.dll.after-metadata.txt','UJect.Runtime.dll.metadata-gates.json']]
    before=(DIAGNOSTIC/'Candidates/UJect.Runtime.dll.before-metadata.txt').read_text().split('|');after=(DIAGNOSTIC/'Candidates/UJect.Runtime.dll.after-metadata.txt').read_text().split('|');added='System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089';need(after.count(added)==1 and added not in before and [v for v in after if v!=added]==before,'Exactly one added donor System.Core reference, no other canonical metadata delta')
    out=ROOT/'Validation'/('ContainerLowerBodyStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    requests=[[
        {'owner':'MNALHHOLFGL','name':'.ctor','parameters':[],'generic_arity':0},
        {'owner':'MNALHHOLFGL','name':'.ctor','parameters':['System.String'],'generic_arity':0},
        {'owner':'MNALHHOLFGL','name':'.ctor','parameters':['MNALHHOLFGL','System.String'],'generic_arity':0},
        {'owner':'CPAMAFPANDM','name':'.ctor','parameters':['System.Type','System.String'],'generic_arity':0},
        {'owner':'OENEDGPIOFN','name':'.ctor','parameters':[],'generic_arity':0},
        {'owner':'MNALHHOLFGL','name':'HHCPOGCCGNF','parameters':['System.String'],'generic_arity':1}],
        [{'owner':'MPAAIECKLGA','name':'PNFLFFOAING','parameters':[],'generic_arity':0},
        {'owner':'MPAAIECKLGA','name':'OBAIKOPBHAP','parameters':['System.String','MNALHHOLFGL'],'generic_arity':0}]]
    modules=[{'original':original['DLL'],'meta':original['meta'],'donor':donor,'members':members} for original,donor,members in zip(p['original_modules'],r['compiled_donors'],requests)]
    need([Path(row['original']['path']).name for row in modules]==['UJect.Runtime.dll','RecRoom.AgInitialization.Runtime.dll'],'Exact fixed module/order')
    need(scope['current_caller']==modules[1]['original'] and scope['current_caller_meta']==modules[1]['meta'],'Exact original caller/metadata targeted by scope proof');modules[1]['native_required_reference_sdk']=scope['actual_retained_SDK']
    spec=out/'inputs.json';save(spec,{'schema':'eight-tested-container-lower-body-only-import-input/v1','modules':modules})
    sources=[HERE/'StageContainerLowerBodies.v3.cs']+[SUPPORT/name for name in ['CanonicalMetadataSignatures.cs','MetadataRoundTripSafety.cs','BodyAndSymbolSafety.cs']]
    old=(PREVIOUS/'compile.rsp').read_text(encoding='utf-8-sig');refs=[Path(s) for s in re.findall(r'(?m)^/reference:"([^"]+)"$',old) if '/packs/Microsoft.NETCore.App.Ref/' in s.replace('\\','/')];need(len(refs)>=100,'Exact existing framework reference pack')
    cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';refs.append(cecil);shutil.copyfile(cecil,out/cecil.name)
    output=out/'StageContainerLowerBodiesv3.dll';rsp=out/'compile.rsp';rsp.write_text('/nologo\n/target:exe\n/langversion:8.0\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(s)+'"\n' for s in refs)+''.join('"'+str(s)+'"\n' for s in sources),encoding='utf-8',newline='\n')
    shutil.copyfile(PREVIOUS/'OriginalShaderObjectProbe.runtimeconfig.json',output.with_suffix('.runtimeconfig.json'))
    plan={'schema':SCHEMA,'status':'prepared_no_child_and_no_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'test_receipt':pin(TEST),'test_plan':r['plan'],'spec':pin(spec),'sources':[pin(s) for s in sources],'reviewable_donor_sources':readable,'metadata_delta_diagnostic':diagnostic_pins,'native_required_reference_scope_proofs':scope_pins,'native_required_reference_SDK':scope['actual_retained_SDK'],'native_required_reference_meta':scope['actual_retained_SDK_meta'],'append_negative_controls':append_controls,'sole_approved_metadata_addition':scope['sole_proposed_append'],'metadata_contract':'All original metadata and ordered references preserved, with only the one native-required Debugging AssemblyRef appended; general fingerprint/feature and all-other-body gates remain active.','scope_correction':'Reuse exact existing original OENED.DJGFOAKOCAP HashSet element type/System.Core7cec scope, instead of adding donor System.Coreb77a. Entire metadata equality gate unchanged.','response':pin(rsp),'references':[pin(s) for s in refs],'runtime':[pin(out/cecil.name),pin(output.with_suffix('.runtimeconfig.json'))],'modules':modules,'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':pin(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),'output':str(output),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'Main_modified':False,'Main_apply_supported':False,'changed_bodies':8,'unselected_method_bodies_and_all_original_metadata_must_be_equal':True}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Reviewed owned suspended resource guard')
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed body-only stage plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerLowerBodyStage-'),'Exact isolated candidate scope')
    need(p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['changed_bodies']==8 and not p['Main_apply_supported'],'Fixed read-only-to-Main body staging')
    for row in [p[k] for k in ['runner','test_receipt','test_plan','spec','response','guard','launcher','dotnet','compiler']]+p['sources']+p['reviewable_donor_sources']+p['references']+p['runtime']+p['metadata_delta_diagnostic']+p['native_required_reference_scope_proofs']+[p['native_required_reference_SDK'],p['native_required_reference_meta']]:check(row)
    for row in p['modules']:
        for key in ['original','donor','meta']:check(row[key])
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed staging runner/guard');tested();logger_scope()
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_apply','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'Candidates').exists() and not(out/'run-report.json').exists(),'Fresh outputs only, preserve failed staging')
    report={'schema':'guarded-eight-tested-container-lower-body-only-stage/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'game_or_Unity_or_network_launched':False,'higher_bootstrap_activated':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-pure-eight-lower-member-body-importer',report)
        env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_NOLOGO='1');guard.bounded([p['dotnet']['path'],p['output'],p['spec']['path'],str(out/'Candidates')],out,'stage-and-readback-eight-original-lower-body-only-candidates',report,env)
        result=out/'Candidates/report.json';proof=json.loads(result.read_bytes());need(proof['status']=='eight_tested_lower_bodies_imported_original_metadata_preserved_with_one_native_required_reference' and proof['changed_method_bodies']==8 and len(proof['modules'])==2 and not proof['Main_modified'],'Exact emitted metadata and other-body proof required')
        for row in proof['modules']:check(row['candidate']);need(row['entire_donor_bodies_and_scoped_operands_equal'] and row['all_original_MethodDef_tokens_preserved'],'Full actual donor-body/token proof')
        for row in p['modules']:check(row['original']);check(row['meta'])
        report.update(status='eight_tested_lower_members_staged_original_metadata_retained_one_native_required_reference',result=pin(result),candidates=[row['candidate'] for row in proof['modules']],Main_plugins_and_metas_unchanged=True)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'result':report.get('result'),'error':report.get('error')}));return 0 if report['status']=='eight_tested_lower_members_staged_original_metadata_retained_one_native_required_reference' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare without child first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
