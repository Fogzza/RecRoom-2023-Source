"""Prepare or Root-decode seven complete original BootSequence startup scopes.

Awake and the coroutine state machine are dependencies, never synthesized
from stubs. The decoder consumes original native bytes as inert data only.
"""
from pathlib import Path
import argparse,datetime as dt,json,mmap,uuid
import run_startup_foundation_decode as base
from run_startup_foundation_decode import HERE,ROOT,guard,pin,need,save,check,DECODER,GUARD_SHA,LAUNCHER_SHA,DECODER_SHA
from collect_all_pinvoke_native import ExternMetadata
from audit_custom_urp_native_loop import pdata,scopes
SCHEMA='prepared-original-BootSequence-startup-whole-scopes-inert-decode/v1'
SPECS=[
 ('BootSequence/NEKGMMPKEPF',0x060014f8,195711,0x180871950,36),
 ('BootSequence/NEKGMMPKEPF',0x060014fa,195713,0x180b04c90,1294),
 ('BootSequence',0x060014a7,195630,0x180a56b50,2542),
 ('BootSequence',0x060014a8,195631,0x180a60ab0,109),
 ('BootSequence',0x060014aa,195633,0x180a58770,175),
 ('BootSequence',0x060014ab,195634,0x180a59b60,175),
 ('BootSequence',0x060014bd,195652,0x180a5e0c0,125)]
INDICES=[x[2] for x in SPECS]
AUDIT=ROOT/'Validation/CustomURPNativeLoopAudit-20261023T085002Z-d903fd8a/report.json'
AUDIT_SHA='b6b0ad9a37a7e689efd73da61e03506ba211f62db5c84e11661a6c282ffbe2a3'

def verify_input(path):
    p=json.loads(Path(path).read_bytes());rows=p['methods'];need([x['original']['index'] for x in rows]==INDICES and p['original_bytes']==4456 and [len(bytes.fromhex(r['runtime_function']['bytes'])) for r in rows]==[x[4] for x in SPECS],'Exact seven original initializer scopes')
    intervals=sorted((int(r['native_pointer'],16),int(r['native_pointer'],16)+len(bytes.fromhex(r['runtime_function']['bytes']))) for r in rows);need(all(a[1]<=b[0] for a,b in zip(intervals,intervals[1:])) and all(r['complete_connected_chain_region_count']>=1 for r in rows),'Distinct complete chained native scopes')
    return p

def prepare():
    need(pin(AUDIT)['sha256']==AUDIT_SHA,'Exact original native-source inventory');audit=json.loads(AUDIT.read_bytes());sources=[Path(x['path']) for x in audit['original_inputs']]
    for row in audit['original_inputs']:check(row)
    rows=[]
    with sources[0].open('rb') as bf,sources[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);rs,parents=pdata(v)
        for owner,token,index,pointer,size in SPECS:
            m=v.find_method(owner,token);need(m['index']==index and v.method_pointer(m)==pointer,'Exact original prerequisite token/owner/registration')
            r={'original':m,**scopes(v,m,rs,parents)};need(len(bytes.fromhex(r['runtime_function']['bytes']))==size,'Complete exact original scope size');rows.append(r)
    out=ROOT/'Validation'/('BootSequenceStartupScopes-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=out/'original-BootSequence-startup-scopes.json';save(source,{'schema':'original-BootSequence-startup-whole-scopes/v1','original_inputs':audit['original_inputs'],'methods':rows,'original_bytes':4456,'scope_distinctions_preserved':True,'complete_CSharp_or_renderer_recovery_claimed':False});verify_input(source)
    runtime=[pin(DECODER/x) for x in ['DisassemblePInvokeWrappers.dll','Iced.dll','DisassemblePInvokeWrappers.runtimeconfig.json']];need(runtime[0]['sha256']==DECODER_SHA and pin(HERE/'original_shader_pair_editor_conversion.py')['sha256']==GUARD_SHA and pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCHER_SHA,'Existing inert decoder/owned guard')
    p={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'audit':pin(AUDIT),'original_inputs':audit['original_inputs'],'input':pin(source),'decoder_runtime':runtime,'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'output':str(out/'decoded-original-BootSequence-startup-scopes.jsonl'),'Main_modified':False,'compiler_Unity_game_network_executed':False,'CSharp_recovery_claimed':False};target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'original_bytes':4456,'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit reviewed initializer decode plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('BootSequenceStartupScopes-'),'Exact fresh inert initializer workspace')
    for row in [p[k] for k in ['runner','base_runner','audit','input','dotnet','guard','launcher']]+p['decoder_runtime']+p['original_inputs']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['audit']['sha256']==AUDIT_SHA and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCHER_SHA and p['decoder_runtime'][0]['sha256']==DECODER_SHA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['output']==str(out/'decoded-original-BootSequence-startup-scopes.jsonl'),'Exact sources/resources/output')
    data=verify_input(p['input']['path'])
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':digest}));return 0
    need(not Path(p['output']).exists() and not(out/'run-report.json').exists(),'Fresh one-shot decode')
    report={'schema':SCHEMA,'status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'compiler_Unity_game_network_executed':False,'CSharp_recovery_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['decoder_runtime'][0]['path'],p['input']['path'],p['output']],out,'decode-complete-original-BootSequence-startup',report);decoded=[json.loads(l) for l in Path(p['output']).read_text().splitlines()];need([r['native_method_index'] for r in decoded]==INDICES,'Exactly seven decoded original scopes')
        for a,b in zip(data['methods'],decoded):
            pos=int(a['native_pointer'],16);need(b['native_pointer']==pos,'Original native start')
            for i in b['instructions']:need(i['ip']==pos and 1<=i['length']<=15 and i['code']!='INVALID','Contiguous original instruction coverage');pos+=i['length']
            need(pos==int(a['native_pointer'],16)+len(bytes.fromhex(a['runtime_function']['bytes'])),'Every original byte decoded exactly once')
        report.update(status='original4456B_BootSequence_startup_whole_scopes_inert_decoded_semantics_pending',output=pin(p['output']),original_bytes=4456,decoded_methods=7)
    except BaseException as error:report.update(status='failed_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='original4456B_BootSequence_startup_whole_scopes_inert_decoded_semantics_pending' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit Root plan SHA');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare only first');prepare();return 0

if __name__=='__main__':raise SystemExit(main())


