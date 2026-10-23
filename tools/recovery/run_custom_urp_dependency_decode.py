"""Prepare or Root-run finite complete-chain URP dependency inert decoding."""
from pathlib import Path
import argparse,datetime as dt,json,mmap,uuid
import run_startup_foundation_decode as base
from run_startup_foundation_decode import HERE,ROOT,guard,pin,need,save,check,DECODER,GUARD_SHA,LAUNCHER_SHA,DECODER_SHA
from collect_all_pinvoke_native import ExternMetadata
from audit_custom_urp_native_loop import pdata,scopes,PREFIX

SCHEMA='prepared-original-custom-URP-complete-dependencies-inert-decode/v1'
AUDIT=ROOT/'Validation/CustomURPNativeLoopAudit-20261023T085002Z-d903fd8a/report.json'
AUDIT_SHA='b6b0ad9a37a7e689efd73da61e03506ba211f62db5c84e11661a6c282ffbe2a3'
INDICES=[90726,90727,90730,90733,90880,90890,90938,90941,91309,91311,91313,91315,91316,91332,91340]
BYTES=31931

def verify_input(path):
    r=json.loads(Path(path).read_bytes());methods=r['methods']
    need([x['original']['index'] for x in methods]==INDICES and r['original_bytes']==BYTES and sum(len(bytes.fromhex(x['runtime_function']['bytes'])) for x in methods)==BYTES,'Exact15 original dependency scopes')
    intervals=sorted((int(x['native_pointer'],16),int(x['native_pointer'],16)+len(bytes.fromhex(x['runtime_function']['bytes']))) for x in methods)
    need(all(a[1]<=b[0] for a,b in zip(intervals,intervals[1:])) and all(x['complete_connected_chain_region_count']>=1 for x in methods),'Distinct genuine whole chained scopes')
    return r

def prepare():
    need(pin(AUDIT)['sha256']==AUDIT_SHA,'Exact reviewed original native scope audit')
    audit=json.loads(AUDIT.read_bytes());sources=[Path(x['path']) for x in audit['original_inputs']]
    for p in audit['original_inputs']:check(p)
    groups={90730:'asset-cache',90733:'asset-cache',90880:'constructors',90890:'frame',90938:'constructors',90941:'frame',91309:'constructors',91311:'frame',91313:'frame',91315:'frame',91316:'frame',91340:'static-initializer'}
    methods=[]
    for row in audit['native_methods']:
        index=row['original']['index']
        if index in groups:methods.append({**row,'decode_group':groups[index]})
    with sources[0].open('rb') as bf,sources[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);rs,parents=pdata(v)
        for owner,token,index,pointer,size in [('UniversalRenderPipelineAsset',0x0600006d,90726,0x1835dccf0,168),('UniversalRenderPipelineAsset',0x0600006e,90727,0x1835dccb0,52),('UniversalRenderPipeline',0x060002cb,91332,0x1835e5fc0,122)]:
            method=v.find_method(PREFIX+owner,token);need(method['index']==index and v.method_pointer(method)==pointer,'Exact shared original dependency')
            row={'original':method,**scopes(v,method,rs,parents),'decode_group':'shared-factory-cache-dependencies'}
            need(len(bytes.fromhex(row['runtime_function']['bytes']))==size,'Exact full shared dependency chain')
            module=v.modules[method['image']];at=v.raw(module['pointers_va'],module['count']*8);hi=pointer+size
            direct=[{'token':hex(0x06000000|i+1),'pointer':hex(v.u64(b,at+i*8))} for i in range(module['count']) if pointer<=v.u64(b,at+i*8)<hi]
            generic=[{'generic_pointer_index':i,'pointer':hex(v.u64(b,v.generic_pointers+i*8))} for i in range(v.generic_pointer_count) if pointer<=v.u64(b,v.generic_pointers+i*8)<hi]
            need(all(int(x['pointer'],16)==pointer for x in direct+generic),'No distinct URP registered or generic method absorbed')
            row['registered_entries_inside_scope']={'same_original_URP_module':direct,'all_generic_pointer_rows':generic,'other_unbacked_module_tables_not_assumed_empty':True};methods.append(row)
    methods.sort(key=lambda x:x['original']['index'])
    out=ROOT/'Validation'/('CustomURPCompleteDependencies-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    source=out/'complete-original-dependency-scopes.json';save(source,{'schema':'complete-original-custom-URP-distinct-native-dependency-scopes/v1','original_inputs':audit['original_inputs'],'audit':pin(AUDIT),'methods':methods,'original_bytes':BYTES,'scope_distinctions_preserved':True,'all_chained_pdata_descendants_included':True,'whole_CFG_or_CSharp_recovery_claimed':False});verify_input(source)
    runtime=[pin(DECODER/x) for x in ['DisassemblePInvokeWrappers.dll','Iced.dll','DisassemblePInvokeWrappers.runtimeconfig.json']]
    need(runtime[0]['sha256']==DECODER_SHA and pin(HERE/'original_shader_pair_editor_conversion.py')['sha256']==GUARD_SHA and pin(HERE/'owned_suspended_launch.py')['sha256']==LAUNCHER_SHA,'Exact already-compiled inert decoder and owned launcher')
    p={'schema':SCHEMA,'status':'prepared_no_child_started','fixture':str(out),'runner':pin(Path(__file__)),'base_runner':pin(Path(base.__file__)),'audit':pin(AUDIT),'original_inputs':audit['original_inputs'],'input':pin(source),'decoder_runtime':runtime,'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'guard':pin(HERE/'original_shader_pair_editor_conversion.py'),'launcher':pin(HERE/'owned_suspended_launch.py'),'cap_bytes':256*1024**2,'reserve_bytes':guard.RESERVE,'maximum_seconds':90,'output':str(out/'decoded-complete-original-dependencies.jsonl'),'Main_modified':False,'compiler_Unity_game_network_executed':False,'CSharp_body_recovery_claimed':False}
    target=out/'plan.json';save(target,p)
    print(json.dumps({'plan':pin(target),'native_methods':len(methods),'original_bytes':BYTES,'Root_run_command':['C:/Python314/python.exe','-B',str(Path(__file__)),'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))

def execute(path,expected,run):
    path=path.resolve(strict=True);need(pin(path)['sha256']==expected,'Explicit reviewed dependency decode plan');p=json.loads(path.read_bytes());out=Path(p['fixture']).resolve(strict=True)
    need(p['schema']==SCHEMA and path.parent==out and out.parent==ROOT/'Validation' and out.name.startswith('CustomURPCompleteDependencies-'),'Exact fresh dependency output scope')
    for row in [p[k] for k in ['runner','base_runner','audit','input','dotnet','guard','launcher']]+p['decoder_runtime']+p['original_inputs']:check(row)
    need(p['runner']==pin(Path(__file__)) and p['audit']['sha256']==AUDIT_SHA and p['guard']['sha256']==GUARD_SHA and p['launcher']['sha256']==LAUNCHER_SHA and p['decoder_runtime'][0]['sha256']==DECODER_SHA and p['cap_bytes']==256*1024**2 and p['reserve_bytes']==guard.RESERVE and p['maximum_seconds']==90,'Fixed trusted resources and bounds')
    data=verify_input(p['input']['path']);need(p['output']==str(out/'decoded-complete-original-dependencies.jsonl'),'Fixed fresh decoded output')
    if not run:print(json.dumps({'status':'verified_no_child_started','plan_sha256':expected}));return 0
    need(not Path(p['output']).exists() and not(out/'run-report.json').exists(),'Fresh one-shot decode, no overwrite')
    report={'schema':SCHEMA,'status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'compiler_Unity_game_network_executed':False,'CSharp_recovery_claimed':False}
    try:
        guard.CAP=p['cap_bytes'];guard.bounded([p['dotnet']['path'],p['decoder_runtime'][0]['path'],p['input']['path'],p['output']],out,'decode-complete-original-URP-dependencies',report)
        decoded=[json.loads(x) for x in Path(p['output']).read_text().splitlines()];need([x['native_method_index'] for x in decoded]==INDICES,'Exactly15 original decoded scopes')
        for original,result in zip(data['methods'],decoded):
            position=int(original['native_pointer'],16);need(result['native_pointer']==position,'Original entry start')
            for i in result['instructions']:
                need(i['ip']==position and 1<=i['length']<=15 and i['code']!='INVALID','Contiguous exact native instruction coverage');position+=i['length']
            need(position==int(original['native_pointer'],16)+len(bytes.fromhex(original['runtime_function']['bytes'])),'All original bytes decoded exactly once')
        report.update(status='original31931B_complete_URP_dependency_scopes_inert_decoded_semantics_pending',output=pin(p['output']),original_bytes=BYTES,decoded_methods=15)
    except BaseException as error:report.update(status='failed_preserve_outputs',error=repr(error))
    finally:save(out/'run-report.json',report)
    print(json.dumps({'status':report['status'],'report':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='original31931B_complete_URP_dependency_scopes_inert_decoded_semantics_pending' else 1

def main():
    a=argparse.ArgumentParser(description=__doc__);a.add_argument('--prepare',action='store_true');a.add_argument('--plan',type=Path);a.add_argument('--plan-sha256');a.add_argument('--run',action='store_true');v=a.parse_args()
    if v.prepare:need(not v.plan and not v.run,'Prepare only, never implicit launch');prepare();return 0
    need(v.plan and v.plan_sha256,'Explicit pinned dependency plan');return execute(v.plan,v.plan_sha256,v.run)

if __name__=='__main__':raise SystemExit(main())
