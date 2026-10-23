"""Prepare or Root-run exact536B custom URP inert instruction decoding."""
from pathlib import Path
import argparse,datetime as dt,json,uuid
import run_startup_foundation_decode as base
from run_startup_foundation_decode import HERE,ROOT,guard,pin,need,save,check,DECODER,GUARD_SHA,LAUNCHER_SHA,DECODER_SHA

SCHEMA='prepared-original-custom-URP-three-factory-inert-decode/v1'
INDICES=[90725,90955,91174]
AUDIT_SHA='b6b0ad9a37a7e689efd73da61e03506ba211f62db5c84e11661a6c282ffbe2a3'
INPUT_SHA='c9745272f20907c24b343438f4d09332585e09fd326431eb8b9e37983f6c8d9c'

def inspect_input(p):
    need(pin(p)['sha256']==INPUT_SHA,'Exact reviewed536B native input')
    r=json.loads(Path(p).read_bytes());methods=r['methods']
    need(r['original_bytes']==536 and [x['original']['index'] for x in methods]==INDICES and [len(bytes.fromhex(x['runtime_function']['bytes'])) for x in methods]==[420,84,32],'Exact three factory ranges; leaf includes11 padding bytes')
    return r

def prepare(source,expected):
    source=source.resolve(strict=True)
    need(expected==AUDIT_SHA and pin(source)['sha256']==AUDIT_SHA and source.parent.parent==ROOT/'Validation' and source.parent.name.startswith('CustomURPNativeLoopAudit-'),'Exact reviewed native URP audit')
    r=json.loads(source.read_bytes());need(r['status']=='exact_native_scopes_and_current_stubs_inert_inputs_ready_CSharp_recovery_held' and not r['Main_modified'],'Audit remains evidence-only')
    rows=[x for x in r['inert_inputs'] if x['group']=='factory-wrappers'];need(len(rows)==1,'One exact factory input')
    spec={k:rows[0][k] for k in ['path','bytes','sha256']};check(spec);inspect_input(spec['path'])
    runtime=[pin(DECODER/x) for x in ['DisassemblePInvokeWrappers.dll','Iced.dll','DisassemblePInvokeWrappers.runtimeconfig.json']]
    need(runtime[0]['sha256']==DECODER_SHA and pin(HERE/'original_shader_pair_editor_conversion.py')['sha256']==GUARD_SHA and pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCHER_SHA,'Frozen inert decoder and assign-before-resume launcher')
    out=source.parent/('RootFactoryDecode-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    p={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'audit':pin(source),'input':spec,'decoder_runtime':runtime,'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'output':str(out/'decoded-original-factories.jsonl'),'Main_modified':False,'compiler_Unity_game_network_executed':False,'CSharp_body_recovery_claimed':False}
    target=out/'plan.json';save(target,p)
    print(json.dumps({'plan':pin(target),'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)), '--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed Root decode plan')
    p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent.parent==ROOT/'Validation' and out.parent.name.startswith('CustomURPNativeLoopAudit-') and out.name.startswith('RootFactoryDecode-'),'Exact decoder workspace')
    for row in [p[k] for k in ['runner','base_runner','audit','input','dotnet','guard','launcher']]+p['decoder_runtime']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['audit']['sha256']==AUDIT_SHA and p['input']['sha256']==INPUT_SHA and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCHER_SHA and p['decoder_runtime'][0]['sha256']==DECODER_SHA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90,'Exact sources and owned resource bounds')
    data=inspect_input(p['input']['path'])
    need(p['output']==str(out/'decoded-original-factories.jsonl'),'Fixed fresh decoded output')
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected}));return 0
    need(not Path(p['output']).exists() and not(out/'run-report.json').exists(),'Fresh one-shot decode; preserve failures')
    report={'schema':SCHEMA,'status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'compiler_Unity_game_network_executed':False,'CSharp_recovery_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['decoder_runtime'][0]['path'],p['input']['path'],p['output']],out,'decode-original-three-URP-factories',report)
        decoded=[json.loads(x) for x in Path(p['output']).read_text().splitlines()]
        need([x['native_method_index'] for x in decoded]==INDICES,'Exact three instruction streams')
        for original,result in zip(data['methods'],decoded):
            position=int(original['native_pointer'],16)
            need(result['native_pointer']==position,'Original native start')
            for instruction in result['instructions']:
                need(instruction['ip']==position and 1<=instruction['length']<=15 and instruction['code']!='INVALID','Contiguous inert instruction coverage')
                position+=instruction['length']
            need(position==int(original['native_pointer'],16)+len(bytes.fromhex(original['runtime_function']['bytes'])),'Every original byte decoded exactly once')
        report.update(status='original536B_factories_inert_decoded_typed_semantics_pending',output=pin(p['output']),original_bytes=536,decoded_methods=3)
    except BaseException as error:report.update(status='failed_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status']=='original536B_factories_inert_decoded_typed_semantics_pending' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--audit',type=Path);a.add_argument('--audit-sha256');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.audit:need(v.audit_sha256 and not v.plan and not v.run,'Prepare only; never implicitly launch');prepare(v.audit,v.audit_sha256);return 0
    need(v.plan and v.plan_sha256,'Explicit pinned plan');return execute(v.plan,v.plan_sha256,v.run)

if __name__=='__main__':raise SystemExit(main())
