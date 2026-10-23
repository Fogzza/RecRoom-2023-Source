"""Prepare or Root-inert-decode NEK iterator basics and the Boot timer callback.

Two raw-current getters and Dispose are honest unwind-free terminal leaf scopes,
not fabricated .pdata entries. Reset and HKB use genuine entire chained scopes.
"""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,mmap,uuid
from run_startup_foundation_decode import HERE,ROOT,guard,pin,need,save,check,DECODER,GUARD_SHA,LAUNCHER_SHA,DECODER_SHA
import run_live_lookup_dependencies_decode as scopes
from audit_custom_urp_native_loop import pdata
from prepare_startup_foundation_slice import SOURCE_PINS
from collect_all_pinvoke_native import ExternMetadata

SCHEMA='prepared-original-Boot-iterator-basics-and-timer-callback-inert-decode/v1'
INDICES=[195712,195714,195715,195716,195679]
def prepare():
    paths=[ROOT/'CodeSource'/n for n in SOURCE_PINS]
    for p in paths:need(pin(p)['sha256']==SOURCE_PINS[p.relative_to(ROOT/'CodeSource').as_posix()],'Pinned original client source')
    methods=[]
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
        v=ExternMetadata(b,m);rows,parents=pdata(v);module=v.modules['Assembly-CSharp.dll'];pa=v.raw(module['pointers_va'],module['count']*8);direct=[v.u64(b,pa+i*8) for i in range(module['count'])];generics=[v.u64(b,v.generic_pointers+i*8) for i in range(v.generic_pointer_count)]
        for index in INDICES:
            original=v.method_info(index);ptr=v.method_pointer(original);need(original['image']=='Assembly-CSharp.dll' and original['owner']==('BootSequence' if index==195679 else 'BootSequence/NEKGMMPKEPF'),'Exact original owners')
            if index in [195712,195714,195716]:
                want=bytes.fromhex('c20000' if index==195712 else '488b4118c3');need(bytes(b[v.raw(ptr,len(want)):v.raw(ptr,len(want))+len(want)])==want,'Complete original no-stack terminal leaf opcode sequence');need(not any(start<=ptr-v.base<end for start,end,unwind in rows),'Unwind-free leaf is outside all .pdata runtime ranges')
                scope={'native_pointer':hex(ptr),'runtime_function':{'bytes':want.hex(),'sha256':hashlib.sha256(want).hexdigest()},'original_connected_regions':[],'complete_connected_chain_regions':0,'terminal_leaf_scope':{'no_stack_adjustment_or_calls':True,'ends_at_first_ret':True,'no_branch_or_fallthrough_after_ret':True,'whole_reachable_instruction_scope_not_fabricated_pdata_range':True,'expected_original_instructions':['ret 0'] if index==195712 else ['mov rax,[rcx+24]','ret']}}
            else:scope=scopes.connected_scope(v,ptr,rows,parents)
            end=ptr+len(bytes.fromhex(scope['runtime_function']['bytes']));need(not any(ptr<x<end for x in direct) and not any(ptr<x<end for x in generics),'No separate same-module direct or generic registered entry inside these small scopes');methods.append({'original':original,**scope,'all_same_module_direct_and_generic_interior_entries_absent':True})
    need([len(bytes.fromhex(x['runtime_function']['bytes'])) for x in methods]==[3,5,63,5,58],'Exact134 summed bytes,129 unique native bytes')
    out=ROOT/'Validation'/('BootIteratorBasicsNative-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=out/'five-original-Boot-iterator-basics-scopes.json';save(source,{'schema':SCHEMA,'methods':methods,'original_inputs':[pin(p) for p in paths],'original_bytes':134,'unique_native_bytes':129,'Main_modified':False})
    runtime=[pin(DECODER/n) for n in ['DisassemblePInvokeWrappers.dll','Iced.dll','DisassemblePInvokeWrappers.runtimeconfig.json']];need(runtime[0]['sha256']==DECODER_SHA,'Exact retained inert Iced decoder')
    p={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'scope_helper':pin(Path(scopes.__file__)),'input':pin(source),'original_inputs':[pin(x) for x in paths],'decoder_runtime':runtime,'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'output':str(out/'decoded-original-Boot-iterator-basics.jsonl'),'original_bytes':134,'Main_modified':False,'CSharp_recovery_claimed':False};need(p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCHER_SHA,'Exact suspended-owned guard');target=out/'plan.json';save(target,p);print(json.dumps({'plan':pin(target),'original_bytes':134,'Main_modified':False}))
def execute(path,digest,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==digest,'Explicit Root-reviewed iterator decoder plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True);need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('BootIteratorBasicsNative-'),'Exact owned output scope')
    for r in [p[k] for k in ['runner','scope_helper','input','dotnet','guard','launcher']]+p['original_inputs']+p['decoder_runtime']:check(r)
    need(p['runner']==pin(Path(__file__)) and p['scope_helper']==pin(Path(scopes.__file__)) and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCHER_SHA and p['decoder_runtime'][0]['sha256']==DECODER_SHA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90 and p['output']==str(out/'decoded-original-Boot-iterator-basics.jsonl'),'Exact trusted decoder and bounds');d=json.loads(Path(p['input']['path']).read_bytes());need([x['original']['index'] for x in d['methods']]==INDICES and d['original_bytes']==p['original_bytes']==134,'Five exact bounded original scopes')
    if not run:print(json.dumps({'status':'verified_no_child_started'}));return 0
    need(not Path(p['output']).exists() and not(out/'run-report.json').exists(),'Fresh one-shot inert decoder outputs');r={'schema':SCHEMA,'status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'original_game_Unity_or_network_executed':False,'CSharp_recovery_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['decoder_runtime'][0]['path'],p['input']['path'],p['output']],out,'decode-five-original-Boot-iterator-basics-and-timer-callback',r);actual=[json.loads(x) for x in Path(p['output']).read_text().splitlines()];need([x['native_method_index'] for x in actual]==INDICES,'Exact original instruction identity/order')
        for source,row in zip(d['methods'],actual):
            pos=int(source['native_pointer'],16);need(row['native_pointer']==pos,'Exact source entry')
            for i in row['instructions']:need(i['ip']==pos and i['code']!='INVALID' and 1<=i['length']<=15,'Contiguous complete valid instructions');pos+=i['length']
            need(pos==int(source['native_pointer'],16)+len(bytes.fromhex(source['runtime_function']['bytes'])),'All134 source bytes decoded exactly once')
        r.update(status='five_original_Boot_iterator_basics_and_timer_callback_inert_decoded_semantics_pending',output=pin(p['output']),original_bytes=134)
    except BaseException as error:r.update(status='failed_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',r)
    print(json.dumps({'status':r['status'],'report':pin(out/'run-report.json'),'error':r.get('error')}));return 0 if r['status']=='five_original_Boot_iterator_basics_and_timer_callback_inert_decoded_semantics_pending' else 1
def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.plan:need(v.plan_sha256,'Explicit reviewed plan SHA');return execute(v.plan,v.plan_sha256,v.run)
    need(not v.run and not v.plan_sha256,'Prepare without a child');prepare();return 0
if __name__=='__main__':raise SystemExit(main())
