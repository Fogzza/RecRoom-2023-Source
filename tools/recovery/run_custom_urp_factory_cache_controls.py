"""Prepare or Root-run seven original URP bindings and27 controlled effects.

Only explicit fake-dependency effects execute. Current URP and genuine Unity
DLLs are inspected as metadata; the production donor is never CLR loaded.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,re,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor'
SCHEMA='prepared-seven-original-custom-URP-member-bindings-effects/v1'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66';LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
PROOFS=[(ROOT/'Validation/CustomURPFactoryCandidates-20261023T090258Z-2306b14c/report.json','dbcbf2849f248b616cf22f7e3097c500462a410ce6e43c94b1e5c986fb679fd6'),(ROOT/'Validation/CustomURPSharedCacheCandidates-20261023T090948Z-75f9bd52/report.json','e5730cbe13871a04686a656fc0929194fac916fddf42a1a11ef7b4c0597e8d19')]

def need(v,m):
    if not v:raise ValueError(m)

def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}

def check(p):need(pin(p['path'])==p,'Pinned URP control input changed: '+p['path'])

def save(path,value):
    with Path(path).open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')

def proofs():
    output=[];members=[]
    for path,digest in PROOFS:
        need(pin(path)['sha256']==digest,'Exact native-proven member receipt')
        p=json.loads(path.read_bytes());need(not p['Main_modified'] and not p['safe_to_apply_as_working_renderer'],'Original downstream dependency boundary held')
        for row in p['candidates']:check(row);members.append(row)
        check(p['current_DLL']);output.append(pin(path))
    need(len(members)==5,'Five source fragments represent exact seven members')
    return output,members

def prepare():
    reports,members=proofs();lookup={Path(p['path']).name:p for p in members};template=HERE/'CustomUrpFactoryCacheControls.template.cs';data=template.read_bytes()
    mapping={'ORIGINAL_INTERNAL_CREATE':'ScriptableRendererData.InternalCreateRenderer.member.cs','ORIGINAL_FORWARD_CREATE':'ForwardRendererData.Create.member.cs','ORIGINAL_ASSET_CREATE':'UniversalRenderPipelineAsset.CreatePipeline.member.cs','ORIGINAL_ASSET_CACHE':'UniversalRenderPipelineAsset.RendererCache.members.cs','ORIGINAL_PIPELINE_ASSET':'UniversalRenderPipeline.asset.member.cs'}
    for marker,name in mapping.items():
        token=('/*'+marker+'*/').encode();need(data.count(token)==1,'Single exact original-member insertion');data=data.replace(token,Path(lookup[name]['path']).read_bytes())
    need(len(re.findall(rb'\bDone\("',data))==27 and b'Need(cases==27,' in data,'Finite27 actual controlled case definitions')
    out=ROOT/'Validation'/('CustomUrpFactoryCacheBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=out/'ExactCustomUrpFactoryCacheBindingsEffects.cs'
    with source.open('xb') as f:f.write(data)
    mono_api=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[mono_api/x for x in ['mscorlib.dll','System.dll','System.Core.dll']];facade=mono_api/'Facades/netstandard.dll';unity=EDITOR/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed/UnityEngine.CoreModule.dll';cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';shutil.copyfile(cecil,out/cecil.name)
    donor=out/'Unity.RenderPipelines.Universal.Runtime.dll';effects=out/'ExactCustomUrpFactoryCacheEffects.exe'
    def rsp(name,target,refs,define,kind):
        p=out/name;text='/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(target)+'"\n'+('/define:'+define+'\n' if define else '')+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n'
        p.write_text(text,encoding='utf-8',newline='\n');return pin(p)
    responses=[rsp('original-owner-donor.rsp',donor,framework+[unity],'','library'),rsp('controlled-effects.rsp',effects,framework+[cecil,facade],'URP_EFFECT_CONTROLS','exe')]
    original=WS/'RR23/Assets/Plugins/Unity.RenderPipelines.Universal.Runtime.dll';p={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'native_proofs':reports,'member_fragments':members,'template':pin(template),'source':pin(source),'selected_member_source_bytes_inserted_verbatim':True,'responses':responses,'references':[pin(x) for x in framework+[facade,unity,cecil]],'genuine_Unity':pin(unity),'copied_Cecil':pin(out/cecil.name),'current_original_DLL':pin(original),'current_original_meta':pin(original.with_suffix('.dll.meta')),'donor_output':str(donor),'controlled_effect_output':str(effects),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'selected_members':7,'controlled_effect_cases':27,'controlled_dependencies':'Test-only fake Unity null policy, settings/name/logger, Forward/Pipeline constructors and Dispose; not original implementations and never imported. Native original owner binding is separately checked against real matching Unity API.','Main_modified':False,'production_Donor_or_Unity_code_executed':False,'renderer_constructor_disposal_or_frame_closure_claimed':False}
    need(p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Frozen owned-job controls');target=out/'plan.json';save(target,p)
    print(json.dumps({'plan':pin(target),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run'],'selected_members':7,'controlled_effect_cases':27}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed URP control plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('CustomUrpFactoryCacheBindingEffects-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and p['selected_members']==7 and p['controlled_effect_cases']==27,'Exact finite control scope')
    for key in ['runner','template','source','genuine_Unity','copied_Cecil','current_original_DLL','current_original_meta','compiler','mono','guard','launcher']:check(p[key])
    for row in p['native_proofs']+p['member_fragments']+p['responses']+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Fixed trusted runner and bounds');proofs()
    need(p['donor_output']==str(out/'Unity.RenderPipelines.Universal.Runtime.dll') and p['controlled_effect_output']==str(out/'ExactCustomUrpFactoryCacheEffects.exe'),'Fixed fresh output artifacts')
    if not run:print(json.dumps({'status':'verified_no_child_started','selected_members':7,'controlled_effect_cases':27}));return 0
    need(not(out/'run-report.json').exists() and not Path(p['donor_output']).exists() and not Path(p['controlled_effect_output']).exists(),'Fresh one-shot controls; preserve failures')
    report={'schema':'guarded-seven-original-custom-URP-member-bindings-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'production_Donor_or_Unity_code_executed':False,'Unity_game_network_launched':False,'renderer_constructor_disposal_or_frame_closure_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][0]['path']],out,'compile-seven-URP-original-owner-donor',report)
        guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][1]['path']],out,'compile-seven-URP-controlled-effects',report)
        guard.bounded([p['mono']['path'],p['controlled_effect_output'],'--inspect',p['current_original_DLL']['path'],p['donor_output'],p['genuine_Unity']['path']],out,'inspect-seven-URP-actual-owner-bindings',report)
        text=(out/'inspect-seven-URP-actual-owner-bindings-stdout.log').read_text();need('RESULT seven_exact_URP_original_owner_member_bindings_passed_metadata_only; production_or_donor_loaded=false' in text,'Actual seven exact metadata bindings result')
        guard.bounded([p['mono']['path'],p['controlled_effect_output']],out,'twenty-seven-URP-controlled-effects',report)
        text=(out/'twenty-seven-URP-controlled-effects-stdout.log').read_text();need(len(re.findall(r'^PASS ',text,re.M))==27 and 'RESULT seven_exact_URP_members_twenty_seven_controlled_effects_passed; real_Unity_dependencies_executed=false; renderer_constructor_disposal_frame_closure=false' in text,'Actual finite27 controls result')
        check(p['current_original_DLL']);check(p['current_original_meta']);report.update(status='seven_original_URP_member_bindings_twenty_seven_controlled_effects_passed',compiled_donor=pin(p['donor_output']),compiled_effects=pin(p['controlled_effect_output']),selected_members=7,controlled_effect_cases=27)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='seven_original_URP_member_bindings_twenty_seven_controlled_effects_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit Root plan SHA');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0

if __name__=='__main__':raise SystemExit(main())
