"""Prepare, then Root-run actual raw SDK constructors in matching Editor-shipped Windows32 Mono.

This console probe never executes PHJ/JON/private registration or retrieval.
It does not build/launch Unity or claim a Unity Player/runtime client result.
"""
from pathlib import Path
import argparse, datetime as dt, hashlib, json, os, shutil, uuid
import original_shader_pair_editor_conversion as guard
from audit_cli_marshal_contracts import Cli

HERE=Path(__file__).resolve().parent; WS=HERE.parents[2]; ROOT=WS/'Recovery/RecRoom-2023-04-18'
STAGE=ROOT/'Validation/ContainerRegistrationValueConstructorStage-20261023T105027Z-0c64d72f'
STAGE_SHA='6bd9aaf467cc23ca69aec8a3bd167271f2460f124c027a0b3aed695faa533563'
RESULT_SHA='2c7716c4d4e93e10e27ce32e3b2336f8290b9b75c40276d4de622288df249054'
CANDIDATE_SHA='11d68c9f488ef1338f79188d9289a0747be5f398a298703c81080c60a61aff7e'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66'
LAUNCH_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor'; MONO=EDITOR/'Data/MonoBleedingEdge'
FAILED_V1=ROOT/'Validation/ContainerProviderActualMonoValues-20261023T110016Z-7a2d60f5/run-report.json'
SCHEMA='prepared-actual-raw-provider-constructor-matching-Windows32-Mono-console/v2'
def need(v,m):
    if not v: raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True); guard.safety.assert_no_reparse(p)
    with p.open('rb') as f: h=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':h}
def check(row): need(pin(row['path'])==row,'Pinned console-probe input changed: '+row['path'])
def save(path,data):
    with Path(path).open('x',encoding='utf-8') as f: json.dump(data,f,indent=2); f.write('\n')

def metadata(path,executed=False):
    c=Cli(Path(path).read_bytes()); at=c.row(0,1); index=c.value(at+2+c.strw,c.guidw); off,size=c.streams['#GUID']; need(index>0 and index*16<=size,'Exact Module MVID index'); mvid=str(uuid.UUID(bytes_le=bytes(c.b[off+(index-1)*16:off+index*16])))
    types=[]
    for i in range(1,c.rows[2]+1):
        a=c.row(2,i); name=c.string(c.value(a+4,c.strw)); first=c.value(a+4+2*c.strw+c.coded(2,[2,1,27])+c.index(4),c.index(6)); types.append((i,name,first))
    cctors=[]
    for j,(i,name,first) in enumerate(types):
        end=types[j+1][2] if j+1<len(types) else c.rows[6]+1
        for k in range(first,end):
            a=c.row(6,k)
            if c.string(c.value(a+8,c.strw))=='.cctor': cctors.append({'type':name,'TypeDef':hex(0x02000000|i),'MethodDef':hex(0x06000000|k)})
    need(not any(x['type']=='<Module>' for x in cctors),'No original module initializer permitted in load scope')
    if executed:
        names={0x26:'IKGLJOBBAAC',0x25:'NPILHMLGJCC',0x13:'PLIPHMBIGMM',0x14:'JEMKLLFDDFD'}
        need(all(next(t[1] for t in types if t[0]==i)==n for i,n in names.items()),'Four exact raw executed TypeDef names')
        need(not any(x['type'] in names.values() for x in cctors),'No type initializer in executed SDK constructor chain')
    runtime_attributes=[]
    for i in range(1,c.rows[1]+1):
        a=c.row(1,i); name=c.string(c.value(a+c.coded(2,[0,26,35,1]),c.strw))
        if name in ['RuntimeInitializeOnLoadMethodAttribute','ModuleInitializerAttribute']: runtime_attributes.append(name)
    need(not runtime_attributes,'No runtime/module initializer attribute in loaded SDK')
    return {'MVID':mvid,'declared_type_initializers':cctors,'module_initializer_present':False,'executed_scope_type_initializer_present':False if executed else None,'runtime_initializer_attribute_refs':runtime_attributes}

def stage():
    receipt=STAGE/'run-report.json'; result=STAGE/'Candidates/report.json'; need(pin(receipt)['sha256']==STAGE_SHA and pin(result)['sha256']==RESULT_SHA,'Exact actual four-body stage receipts')
    r=json.loads(receipt.read_bytes()); d=json.loads(result.read_bytes()); check(r['plan']); check(r['result']); p=json.loads(Path(r['plan']['path']).read_bytes())
    need(r['status']=='four_body_isolated_SDK_staged_all_metadata_other_bodies_and_two_empty_ctor_bytes_preserved' and r['result']==pin(result) and r['both_empty_base_CIL_byte_identical'] and r['Main_plugin_and_meta_unchanged'] and not r['Main_modified'],'Actual isolated4body stage passed')
    need([x['phase'] for x in r['phases']]==['compile-pure-single-value-constructor-importer','stage-and-readback-four-body-isolated-SDK'] and all(x['exit_code']==0 and x['owned_child_exit_confirmed'] for x in r['phases']),'Both actual fourth-body metadata-only stages passed')
    need(d['status']=='four_body_isolated_candidate_ready_original_metadata_and_other_bodies_preserved' and d['changed_in_this_stage']==1 and d['combined_changed_bodies']==4 and d['all_original_runtime_type_names_preserved'] and d['all_original_MethodDef_tokens_preserved'] and not d['Main_modified'] and not d['game_or_SDK_code_executed'],'Exact body-only metadata preservation result')
    check(d['candidate']); need(d['candidate']['sha256']==CANDIDATE_SHA and r['candidate']==d['candidate'],'Exact actual combined4body candidate')
    for x in [p[k] for k in ['runner','ctor_test','ctor_test_plan','registration3_stage','registration3_stage_plan','registration3_result','current_Main_plugin','current_Main_meta','registration3_candidate','ctor_donor','ctor_donor_source','spec','response','guard','launcher','dotnet','compiler']]+p['sources']+p['references']+p['runtime']:check(x)
    from stage_container_registration_and_value_constructor import raw_empty_bases
    need(raw_empty_bases(d['candidate']['path'])==p['already_correct_empty_bases_raw_CIL'],'Both untouched original base ctor CIL exact')
    return r,d,p

def prepare():
    failed=json.loads(FAILED_V1.read_bytes()); need(failed['status']=='failed_or_guard_refused_preserve_outputs' and failed['phases'][0]['exit_code']==0 and failed['phases'][1]['exit_code']==1 and not failed['Main_modified'],'Preserved first host-architecture failure, no SDK proof claimed'); host=MONO/'bin/mono.exe'; b=host.read_bytes(); import struct; pe=struct.unpack_from('<I',b,60)[0]; need(struct.unpack_from('<H',b,pe+4)[0]==0x14c and struct.unpack_from('<H',b,pe+24)[0]==0x10b,'Genuine shipped Mono host is PE32/i386; this is deliberately not a64-bit Player proof')
    r,d,sp=stage(); out=ROOT/'Validation'/('ContainerProviderActualMonoValues-v2-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]); out.mkdir(); sdk=out/'UJect.Runtime.dll'; shutil.copyfile(d['candidate']['path'],sdk)
    annotation=WS/'RR23/Assets/Plugins/RecRoom.NoEngine.JetBrains.Annotations.dll'; target=out/annotation.name; shutil.copyfile(annotation,target)
    source=HERE/'ContainerProviderValueMonoProbe.v2.cs'; output=out/'ContainerProviderValueMonoProbe.exe'; rsp=out/'compile.rsp'; refs=[MONO/'lib/mono/4.7.1-api'/n for n in ['mscorlib.dll','System.dll','System.Core.dll']]
    rsp.write_text('/nologo\n/target:exe\n/platform:x86\n/langversion:7.3\n/out:"'+str(output)+'"\n'+''.join('/reference:"'+str(x)+'"\n' for x in refs)+'"'+str(source)+'"\n',encoding='utf-8',newline='\n')
    plan={'schema':SCHEMA,'status':'prepared_no_child_or_Main_write','fixture':str(out),'runner':pin(Path(__file__)),'source':pin(source),'response':pin(rsp),'references':[pin(x) for x in refs],'preserved_v1_host_architecture_failure':pin(FAILED_V1),'stage_receipt':pin(STAGE/'run-report.json'),'stage_plan':r['plan'],'stage_result':r['result'],'candidate':d['candidate'],'owned_candidate':pin(sdk),'current_Main_plugin':sp['current_Main_plugin'],'current_Main_meta':sp['current_Main_meta'],'annotation':pin(annotation),'annotation_meta':pin(annotation.with_suffix('.dll.meta')),'owned_annotation':pin(target),'compiler':pin(EDITOR/'Data/Tools/Roslyn/csc.exe'),'mono':pin(MONO/'bin/mono.exe'),'mono_native_runtime':pin(MONO/'bin/mono-2.0-bdwgc.dll'),'mono_config':pin(MONO/'etc/mono/config'),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'metadata_parser':pin(HERE/'audit_cli_marshal_contracts.py'),'stage_validation_helper':pin(HERE/'stage_container_registration_and_value_constructor.py'),'SDK_initializer_audit':metadata(sdk,True),'annotation_initializer_audit':metadata(target),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'output':str(output),'runtime_result':str(out/'actual-constructor-values.json'),'expected_checks':22,'explicit_original_ctor_tokens':['0x06000084','0x06000083','0x06000057','0x0600005c'],'production_registration_lookup_retrieval_injection_callbacks_executed':False,'execution_host':'matching Editor-shipped Windows32 Mono console; not Windows64 Unity Player','Main_modified':False,'Main_apply_supported':False}
    need(plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCH_SHA,'Exact suspended-owned guard'); path=out/'plan.json'; save(path,plan); print(json.dumps({'plan':pin(path),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(path),'--plan-sha256',pin(path)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True); need(pin(path)['sha256']==digest,'Explicit reviewed console-probe plan'); p=json.loads(path.read_bytes()); out=Path(p['fixture']).resolve(strict=True)
    need(path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('ContainerProviderActualMonoValues-v2-') and p['schema']==SCHEMA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['expected_checks']==22 and not p['Main_apply_supported'] and not p['production_registration_lookup_retrieval_injection_callbacks_executed'] and p['execution_host']=='matching Editor-shipped Windows32 Mono console; not Windows64 Unity Player','Exact console-only scope and guards')
    for row in [p[k] for k in ['runner','source','response','preserved_v1_host_architecture_failure','stage_receipt','stage_plan','stage_result','candidate','owned_candidate','current_Main_plugin','current_Main_meta','annotation','annotation_meta','owned_annotation','compiler','mono','mono_native_runtime','mono_config','guard','launcher','metadata_parser','stage_validation_helper']]+p['references']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCH_SHA,'Exact runner and guard'); r,d,sp=stage(); need(p['candidate']==d['candidate'] and p['owned_candidate']['sha256']==p['candidate']['sha256'] and p['owned_annotation']['sha256']==p['annotation']['sha256'],'Exact owned rawSDK binaries')
    need(metadata(p['owned_candidate']['path'],True)==p['SDK_initializer_audit'] and metadata(p['owned_annotation']['path'])==p['annotation_initializer_audit'],'No initializer change')
    need(Path(p['output'])==out/'ContainerProviderValueMonoProbe.exe' and Path(p['runtime_result'])==out/'actual-constructor-values.json' and Path(p['owned_candidate']['path'])==out/'UJect.Runtime.dll' and Path(p['owned_annotation']['path'])==out/'RecRoom.NoEngine.JetBrains.Annotations.dll','All outputs/load paths inside owned fixture')
    if not run:print(json.dumps({'status':'verified_no_child_started_no_Main_apply','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not Path(p['runtime_result']).exists() and not(out/'run-report.json').exists(),'Fresh one-shot compile/runtime outputs'); report={'schema':'guarded-actual-original-provider-constructor-Windows32-Mono-console-values/v2','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Unity_or_Player_launched':False,'production_registration_lookup_retrieval_injection_callbacks_executed':False}
    try:
        guard.CAP=p['cap_bytes']; env=dict(os.environ); env.pop('MONO_PATH',None); env.pop('MONO_ENV_OPTIONS',None); env.pop('MONO_CFG_DIR',None)
        guard.bounded([p['compiler']['path'],'/noconfig','@'+p['response']['path']],out,'compile-reflection-only-console-probe',report,env)
        guard.bounded([p['mono']['path'],'--config',p['mono_config']['path'],p['output'],p['owned_candidate']['path'],p['runtime_result'],p['SDK_initializer_audit']['MVID']],out,'actual-matching-Windows32-Mono-original-ctor-value-observation',report,env)
        result=json.loads(Path(p['runtime_result']).read_bytes()); need(result['schema']=='actual-matching-Windows32-Mono-console-original-provider-ctor-values/v2' and result['status']=='actual_original_constructor_chain_and_value_retention_passed' and result['host_platform']=='Win32NT' and result['host_pointer_bytes']==4 and result['host_Mono_Runtime_type_present'] and result['actual_SDK_constructor_bodies_executed'] and not result['production_registration_lookup_retrieval_injection_callbacks_executed'] and not result['working_client_or_registration_claimed'] and result['exception'] is None and len(result['checks'])==22 and len(set(result['checks']))==22 and result['executed_original_constructor_MethodDefs']==p['explicit_original_ctor_tokens'],'Actual SDK ctor chain and22 observations passed')
        need(result['execution_host']==p['execution_host'] and Path(result['SDK_location']).resolve()==Path(p['owned_candidate']['path']) and result['SDK_mvid']==p['SDK_initializer_audit']['MVID'],'Actual unchanged rawSDK load identity'); framework=Path(result['framework_location']).resolve(strict=True); need(framework.is_relative_to((MONO/'lib').resolve()) and framework.name=='mscorlib.dll' and result['framework_identity'].startswith('mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089') and metadata(framework)['MVID']==result['framework_mvid'],'Actual framework from exact matching Editor Mono runtime')
        for x in ['owned_candidate','owned_annotation','current_Main_plugin','current_Main_meta','annotation','annotation_meta','candidate']:check(p[x])
        report.update(status='actual_matching_Editor_shipped_Windows32_Mono_console_original_ctor_chain_and_22_value_observations_passed',actual_runtime_result=pin(p['runtime_result']),compiled_probe=pin(p['output']),actual_framework=pin(framework),checks=22,actual_original_SDK_constructor_bodies_executed=True,original_base_ctor_CIL_unchanged=True,Main_plugin_and_meta_unchanged=True,working_provider_registration_or_client_claimed=False)
    except BaseException as error:report.update(status='failed_or_guard_refused_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'actual_runtime_result':report.get('actual_runtime_result'),'error':report.get('error')}));return 0 if report['status']=='actual_matching_Editor_shipped_Windows32_Mono_console_original_ctor_chain_and_22_value_observations_passed' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare first without child');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
