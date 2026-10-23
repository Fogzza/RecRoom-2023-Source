"""Prepare or Root-run inert decoding of three original title callbacks only."""
from pathlib import Path
import argparse,datetime as dt,json,uuid
import run_startup_foundation_decode as base
from run_startup_foundation_decode import HERE,ROOT,guard,pin,need,save,check,DECODER,GUARD_SHA,LAUNCHER_SHA,DECODER_SHA
SCHEMA='prepared-original-three-title-callbacks-complete-chain-inert-decode/v1'
INDICES={192552,192561,192568}

def prepare(source,expected):
    source=source.resolve(strict=True);need(pin(source)['sha256']==expected and source.parent.parent==ROOT/'Validation' and source.parent.name.startswith('TitleRemainingCallbacksNative-'),'Exact fresh three-callback chain evidence');r=json.loads(source.read_bytes());need(r['status']=='three_complete_original_callback_scopes_ready_for_inert_decode','Actual connected PE chain proof');check(r['source']);data=json.loads(Path(r['source']['path']).read_bytes());need({x['original']['index'] for x in data['methods']}==INDICES and len(data['methods'])==3 and data['original_chain_membership_proven'] and 0<data['original_bytes']<=3*16384,'Exactly three bounded genuine original callbacks')
    runtime=[pin(DECODER/x) for x in ['DisassemblePInvokeWrappers.dll','Iced.dll','DisassemblePInvokeWrappers.runtimeconfig.json']];need(runtime[0]['sha256']==DECODER_SHA and pin(HERE/'original_shader_pair_editor_conversion.py')['sha256']==GUARD_SHA and pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCHER_SHA,'Reviewed inert decoder and suspended-owned guard')
    out=source.parent/('RootDecodePlan-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();p={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'chain_evidence':pin(source),'input':r['source'],'decoder_runtime':runtime,'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'output':str(out/'decoded-three-title-callbacks.jsonl'),'Main_modified':False,'compiler_Unity_game_network_executed':False,'CSharp_body_recovery_claimed':False};target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed complete-chain decode plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(p['schema']==SCHEMA and path.parent==out and out.parent.parent==ROOT/'Validation' and out.parent.name.startswith('TitleRemainingCallbacksNative-') and out.name.startswith('RootDecodePlan-'),'Exact isolated decoder output scope')
    for row in [p[k] for k in ['runner','base_runner','chain_evidence','input','dotnet','guard','launcher']]+p['decoder_runtime']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCHER_SHA and p['decoder_runtime'][0]['sha256']==DECODER_SHA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90,'Fixed trusted decoder and owned bounds')
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected}));return 0
    need(not Path(p['output']).exists() and not(out/'run-report.json').exists(),'Fresh one-shot inert decoder');report={'schema':SCHEMA,'status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'compiler_Unity_game_network_executed':False,'CSharp_recovery_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['decoder_runtime'][0]['path'],p['input']['path'],p['output']],out,'decode-three-complete-original-title-callbacks',report);rows=[json.loads(x) for x in Path(p['output']).read_text().splitlines()];need(len(rows)==3 and {x['native_method_index'] for x in rows}==INDICES,'Exactly three requested original native instruction streams');report.update(status='three_complete_original_title_callbacks_decoded_CFG_and_typed_semantics_pending',output=pin(p['output']))
    except BaseException as error:report.update(status='failed_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='three_complete_original_title_callbacks_decoded_CFG_and_typed_semantics_pending' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--chain-report',type=Path);a.add_argument('--chain-report-sha256');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.chain_report:need(v.chain_report_sha256 and not v.plan and not v.run,'Prepare only from pinned genuine scope report');prepare(v.chain_report,v.chain_report_sha256);return 0
    need(v.plan and v.plan_sha256,'Explicit reviewed inert decode plan');return execute(v.plan,v.plan_sha256,v.run)
if __name__=='__main__':raise SystemExit(main())
