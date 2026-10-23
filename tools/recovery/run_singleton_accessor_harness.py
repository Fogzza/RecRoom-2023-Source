"""Prepare or Root-run two native-proved accessor donor bindings and ten effects.

Only the test-only effects executable is invoked. The donor and original SDK
are inspected as metadata, never loaded. No Main writes or Unity/network jobs.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,shutil,uuid
import original_shader_pair_editor_conversion as guard
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROOF=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207/AccessorMembers-20261023T075552Z-590b5b12/report.json'
PROOF_SHA='fd35a6ce621052c6676e100e7120f849841f5ad1892cf582be19c653052d9073'
STAGE=ROOT/'Validation/StartupThreeMemberBodyStage-20261023T072237Z-29c9faaf'
STAGE_SHA='bc28f138814d1f1908848b2d9001a139d8df5c446edf45e6baa006af72490a85'
BODY_SHA='c08fcd0a9615607a7cb2a51f764b6a370d69d491c2934c3923e5f996deb355eb'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor'
SCHEMA='prepared-two-original-Singleton-accessor-bindings-controlled-effects/v1'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(p)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def check(row):need(pin(row['path'])==row,'Pinned accessor input changed: '+row['path'])
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def source():
    need(pin(PROOF)['sha256']==PROOF_SHA,'Frozen complete native accessor CFG proof');p=json.loads(PROOF.read_bytes());check(p['candidate_members']);need(len(p['negative_controls'])==8 and len(p['exact_shapes'])==3 and p['constructor_current_body_already_native-equivalent']['replacement_needed'] is False and p['static_ctor_native_proven_empty']['replacement_needed'] is False,'Exactly two missing getter bodies; preserve correct constructors')
    return Path(p['candidate_members']['path']).read_bytes(),p['candidate_members']
def baseline():
    need(pin(STAGE/'run-report.json')['sha256']==STAGE_SHA and pin(STAGE/'Candidates/report.json')['sha256']==BODY_SHA,'Previously tested/staged three-body baseline')
    r=json.loads((STAGE/'Candidates/report.json').read_bytes());m=[x for x in r['modules'] if Path(x['candidate']['path']).name=='RecRoom.Datastructures.Singletons.Runtime.dll'];need(len(m)==1 and m[0]['all_original_MethodDef_tokens_preserved'] and m[0]['entire_donor_bodies_and_scoped_operands_equal'],'Exact declared metadata of original Singleton');check(m[0]['candidate']);return m[0]['candidate']
def prepare():
    members,memberpin=source();original=baseline();need(pin(HERE/'original_shader_pair_editor_conversion.py')['sha256']==GUARD_SHA and pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCH_SHA,'Reviewed bounded assign-before-resume guard')
    out=ROOT/'Validation'/('SingletonAccessorBindingEffects-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    donor=out/'SingletonAccessorOriginalOwnerDonor.cs';donor.write_bytes(b'// Original owner, self constraint and private field. Import only the two getters.\npublic class SingletonMonoBehaviour<T>:UnityEngine.MonoBehaviour where T:SingletonMonoBehaviour<T>\n{\n    private static T CMDPMJBEBAB;\n'+members+b'\n}\n')
    fixed=HERE/'RecoveredSingletonAccessorDonor.cs'
    if fixed.exists():need(fixed.read_bytes()==donor.read_bytes(),'Preserve reviewed fixed donor source')
    else:
        with fixed.open('xb') as f:f.write(donor.read_bytes())
    template=HERE/'SingletonAccessorEffects.template.cs';data=template.read_bytes();need(data.count(b'/*EXACT_ACCESSOR_MEMBERS*/')==1,'Unique unchanged selected member insertion');effect=out/'ExactSingletonAccessorControlledEffects.cs';effect.write_bytes(data.replace(b'/*EXACT_ACCESSOR_MEMBERS*/',members))
    mono=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';framework=[mono/name for name in ['mscorlib.dll','System.dll','System.Core.dll']];unity=EDITOR/'Data/PlaybackEngines/windowsstandalonesupport/Variations/mono/Managed/UnityEngine.CoreModule.dll';cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';facade=mono/'Facades/netstandard.dll';shutil.copyfile(cecil,out/'Mono.Cecil.dll')
    def rsp(name,src,target,refs,kind):
        path=out/name;path.write_text('/nologo\n/nostdlib+\n/langversion:8.0\n/optimize+\n/target:'+kind+'\n/out:"'+str(target)+'"\n'+''.join('/reference:"'+str(p)+'"\n' for p in refs)+'"'+str(src)+'"\n',encoding='utf-8',newline='\n');return pin(path)
    donorout=out/'RecRoom.Datastructures.Singletons.Runtime.dll';effectout=out/'ExactSingletonAccessorControlledEffects.exe';responses=[rsp('accessor-donor.rsp',donor,donorout,framework+[unity],'library'),rsp('accessor-effects.rsp',effect,effectout,framework+[cecil,facade],'exe')]
    plan={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'proof':pin(PROOF),'members':memberpin,'baseline_stage_receipt':pin(STAGE/'run-report.json'),'baseline_metadata_report':pin(STAGE/'Candidates/report.json'),'original_metadata_module':original,'template':pin(template),'sources':[pin(donor),pin(effect)],'reviewable_fixed_donor':pin(fixed),'responses':responses,'references':[pin(p) for p in framework+[unity,cecil,facade]],'copied_Cecil':pin(out/'Mono.Cecil.dll'),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'donor_output':str(donorout),'effect_output':str(effectout),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds_per_phase':90,'controlled_effect_cases':10,'production_modules_executed':False,'Main_modified':False,'working_boot_or_login_claimed':False,'baseline_note':'Reads the previously proved staged SDK metadata; no current UI source or SDK Main byte is an input. Importing the new getters later must preserve all existing three tested bodies.'}
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
def execute(path,digest,run):
    need(pin(path)['sha256']==digest,'Explicit reviewed accessor plan hash');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('SingletonAccessorBindingEffects-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds_per_phase']==90 and p['controlled_effect_cases']==10,'Exact isolated bounded two-getter test')
    for k in ['runner','proof','members','baseline_stage_receipt','baseline_metadata_report','original_metadata_module','template','reviewable_fixed_donor','copied_Cecil','compiler','mono','guard','launcher']:check(p[k])
    for row in p['sources']+p['responses']+p['references']:check(row)
    members,memberpin=source();need(memberpin==p['members'] and baseline()==p['original_metadata_module'] and p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact reviewed original proof/context and runtime guard')
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':digest,'selected_bodies':2,'controlled_effect_cases':10}));return 0
    need(not(out/'run-report.json').exists() and not Path(p['donor_output']).exists() and not Path(p['effect_output']).exists(),'Fresh outputs; preserve failures without retry')
    report={'schema':'guarded-two-original-Singleton-accessor-bindings-effects/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'production_modules_executed':False,'Unity_or_game_or_network_invoked':False,'working_boot_or_login_claimed':False}
    try:
        guard.CAP=p['cap_bytes']
        for index,name in [(0,'compile-exact-Singleton-accessor-donor'),(1,'compile-explicit-accessor-controlled-effects-reader')]:guard.bounded([p['compiler']['path'],'/noconfig','@'+p['responses'][index]['path']],out,name,report)
        guard.bounded([p['mono']['path'],p['effect_output'],'--inspect',p['original_metadata_module']['path'],p['donor_output']],out,'inspect-two-original-accessor-metadata-bindings',report)
        guard.bounded([p['mono']['path'],p['effect_output']],out,'ten-exact-accessor-controlled-effects',report)
        for row in p['sources']+p['references']+[p['original_metadata_module']]:check(row)
        report.update(status='two_exact_original_accessor_bindings_and_ten_controlled_cases_passed',compiled_donor=pin(p['donor_output']),compiled_effects=pin(p['effect_output']),exact_original_metadata_binding=True,controlled_effect_cases=10)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='two_exact_original_accessor_bindings_and_ten_controlled_cases_passed' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA required');return execute(v.plan.resolve(strict=True),v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
