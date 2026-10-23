"""Prepare/verify a Root-only owned decoder run. Default never starts a child."""
from pathlib import Path
import argparse
import datetime as dt
import hashlib
import json
import sys
import uuid
HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]
ROOT=WS/'Recovery/RecRoom-2023-04-18'
import original_shader_pair_editor_conversion as guard
guard.CAP=256*1024**2
DECODER=HERE/'PInvokeDisassembler-20261022T124000Z'
GUARD_SHA='f7d75d1b99bf241df9871291cf22eecbf6ce2596f42174fc2b37cdac2b75ce66'
LAUNCHER_SHA='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
DECODER_SHA='b23573bbdc7f27fc3d480c0b6925f000dcd59621d7667b8c5ce9be90dfbd2f72'

def need(value,message):
    if not value:raise ValueError(message)
def pin(path):
    path=Path(path).resolve(strict=True);guard.safety.assert_no_reparse(path)
    with path.open('rb') as f:digest=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(path),'bytes':path.stat().st_size,'sha256':digest}
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def check(row):need(pin(row['path'])==row,'Pinned decoder input changed')

def prepare(source,expected):
    source=source.resolve(strict=True);need(source.parent.parent==ROOT/'Validation' and source.parent.name.startswith('StartupFoundationSlice-') and pin(source)['sha256']==expected,'Exact prepared foundation slice required')
    s=json.loads(source.read_bytes());need(s['status']=='HOLD_not_applicable_as_working_bootstrap' and s['safe_to_apply_four_root_methods'] is False,'Foundation closure must remain held')
    spec=s['next_decoder_input'];input_pin=pin(spec['path']);need(input_pin['sha256']==spec['sha256'] and input_pin['bytes']<=32768,'Exact bounded inert original bytes required')
    data=json.loads(Path(input_pin['path']).read_bytes());need(len(data['methods'])==3 and data['original_bytes']==2222 and not data['whole_method_control_flow_or_CSharp_recovery_claimed'],'Only exact three original native windows')
    rows=[pin(p) for p in [DECODER/'DisassemblePInvokeWrappers.dll',DECODER/'Iced.dll',DECODER/'DisassemblePInvokeWrappers.runtimeconfig.json']]
    need(rows[0]['sha256']==DECODER_SHA,'Reviewed inert decoder changed')
    own_guard=pin(HERE/'original_shader_pair_editor_conversion.py');launcher=pin(HERE/'owned_suspended_launch.py');need(own_guard['sha256']==GUARD_SHA and launcher['sha256']==LAUNCHER_SHA,'Reviewed owned launch guard changed')
    out=source.parent/('RootDecodePlan-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    plan={'schema':'prepared-original-startup-foundation-inert-decode/v1','status':'prepared_no_child_started','fixture':str(out),'slice':pin(source),'input':input_pin,'decoder_runtime':rows,'guard':own_guard,'launcher':launcher,'runner':pin(Path(__file__)),'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'cap_bytes':256*1024**2,'reserve_bytes':int(1.5*1024**3),'maximum_seconds':90,'output':str(out/'decoded-instructions.jsonl'),'Main_modified':False,'compiler_Unity_game_network_executed':False,'whole_method_recovery_claimed':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'status':plan['status'],'plan':pin(target),'Root_run_command':['python','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Reviewed decoder plan changed');plan=json.loads(path.read_bytes());out=Path(plan['fixture']).resolve(strict=True)
    need(path.parent==out and out.parent.parent==ROOT/'Validation' and out.parent.name.startswith('StartupFoundationSlice-') and out.name.startswith('RootDecodePlan-'),'Exact foundation decoder output required')
    need(plan['schema']=='prepared-original-startup-foundation-inert-decode/v1' and plan['cap_bytes']==guard.CAP and plan['reserve_bytes']==guard.RESERVE and plan['maximum_seconds']==90,'Reviewed decoder resource bounds changed')
    for row in [plan[k] for k in ['slice','input','guard','launcher','runner','dotnet']]+plan['decoder_runtime']:check(row)
    need(plan['runner']==pin(Path(__file__)) and plan['guard']['sha256']==GUARD_SHA and plan['launcher']['sha256']==LAUNCHER_SHA and plan['decoder_runtime'][0]['sha256']==DECODER_SHA,'Fixed trusted decoder and guard scope required')
    command=[plan['dotnet']['path'],plan['decoder_runtime'][0]['path'],plan['input']['path'],plan['output']]
    if not run:print(json.dumps({'status':'verified_no_child_started','command':command,'cap_bytes':guard.CAP,'reserve_bytes':guard.RESERVE}));return
    need(not Path(plan['output']).exists() and not(out/'run-report.json').exists(),'Fresh owned decoder run required; no overwrite/retry')
    receipt={'schema':'guarded-original-startup-foundation-inert-decode/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'compiler_Unity_game_network_executed':False,'whole_method_recovery_claimed':False}
    try:
        guard.bounded(command,out,'decode-original-three-windows',receipt)
        rows=[json.loads(line) for line in Path(plan['output']).read_text().splitlines()]
        need(len(rows)==3,'Exactly three decoded original windows required');receipt.update(status='decoded_original_entry_windows_not_whole_method_recovery',output=pin(plan['output']),decoded_methods=len(rows))
    except BaseException as error:receipt.update(status='failed_preserve_outputs',error=repr(error));raise
    finally:save(out/'run-report.json',receipt)
    print(json.dumps({'status':receipt['status'],'receipt':pin(out/'run-report.json')}))

def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--slice-plan',type=Path);p.add_argument('--slice-sha256');p.add_argument('--plan',type=Path);p.add_argument('--plan-sha256');p.add_argument('--run',action='store_true');a=p.parse_args()
    if a.slice_plan:
        need(not a.plan and not a.run and a.slice_sha256,'Prepare only from an explicit pinned foundation slice');prepare(a.slice_plan,a.slice_sha256)
    else:
        need(a.plan and a.plan_sha256,'Explicit pinned prepared decoder plan required');execute(a.plan,a.plan_sha256,a.run)
if __name__=='__main__':main()
