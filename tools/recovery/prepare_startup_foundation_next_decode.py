"""Prepare the next three inert startup native windows for Root's frozen runner."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata
from inventory_recroom_game_root_native import region
from prepare_startup_foundation_slice import SOURCE_PINS
from run_startup_foundation_decode import pin,save,need,GUARD_SHA,LAUNCHER_SHA,DECODER_SHA,DECODER
SLICE=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207'
JOINS=SLICE/'TypedJoins-20261023T063732Z-89bb5d75/report.json'
def main():
    need(pin(JOINS)['sha256']=='277f6503fc8054a8937e81fe7b7dc709725efdb922a8b824726e46cb90122b3e','Exact typed join proof')
    joined=json.loads(JOINS.read_bytes());source=joined['extended_Singleton_input'];need(pin(source['path'])['sha256']==source['sha256'],'Extended original input changed');singleton=json.loads(Path(source['path']).read_bytes())['methods'][0];need(len(bytes.fromhex(singleton['runtime_function']['bytes']))==960,'Exact Singleton span')
    prior=ROOT/'Validation/ContainerBindingTailCFG-20261022T181708Z-5b7e300c/report.json';need(pin(prior)['sha256']=='1373f4678e8558aa0aa9a3eec487bf580c544e83846b7da9a75701f3991a33f1','Exact original disposed-check evidence');check=json.loads(prior.read_bytes())['condition_check_dependency']
    paths=[ROOT/'CodeSource'/name for name in SOURCE_PINS]
    for p in paths:need(pin(p)['sha256']==SOURCE_PINS[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source changed')
    rows=[singleton]
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as binary,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as metadata:
        v=ExternMetadata(binary,metadata);spec=306225;definition,ci,gi=struct.unpack_from('<iii',binary,v.method_specs+spec*12);original=v.method_info(definition);need(original['owner']=='SingletonMonoBehaviour`1' and original['name']=='OnDestroy' and [v.typename(t) for t in v.inst(ci)]==['GameRoot'] and not v.inst(gi),'Exact base cleanup MethodSpec')
        targets=v.generic_targets({spec})[spec];need(len(targets)==1 and targets[0]['pointer']=='0x18333e7c0' and targets[0]['adjustor_thunk_index']==-1,'Exact original base cleanup registration');rows.append({'label':'Singleton<GameRoot>.OnDestroy','original':original,'method_spec':spec,'class_arguments':['GameRoot'],'method_arguments':[],'native_pointer':'0x18333e7c0','registration':targets[0],'runtime_function':region(v,0x18333e7c0),'complete_method_CFG_claimed':False})
        original=v.find_method('MKECFLEMHEL',0x0600005f);need(v.method_pointer(original)==0x186743bb0 and original['index']==check['original']['index'],'Exact disposed-check target');native=region(v,0x186743bb0);need(native==check['first_pdata_region_not_assumed_complete'],'Original disposed-check bytes changed');rows.append({'label':'MKECFLEMHEL.GFKAFPHLKMJ','original':original,'native_pointer':'0x186743bb0','runtime_function':native,'complete_method_CFG_claimed':False})
    out=SLICE/('RootDecodePlan-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();input_path=out/'three-next-original-windows.json';save(input_path,{'schema':'bounded-next-startup-native-windows/v1','methods':rows,'original_bytes':sum(len(bytes.fromhex(r['runtime_function']['bytes'])) for r in rows),'whole_method_recovery_claimed':False})
    proof=out/'preparation-proof.json';save(proof,{'schema':'original-startup-second-batch-preparation/v1','status':'prepared_no_child_started','sources':[pin(p) for p in paths],'typed_joins':pin(JOINS),'disposed_check_proof':pin(prior),'producer':pin(Path(__file__)),'input':pin(input_path),'Main_changed':False,'compiler_Unity_game_network_executed':False})
    runner=pin(HERE/'run_startup_foundation_decode.py');need(runner['sha256']=='e64411ff3ee934e33d34608791dafaf09b91f60a5a9fd4f3e4b5f8f59b055ed6','Frozen Root runner changed');guard=pin(HERE/'original_shader_pair_editor_conversion.py');launcher=pin(HERE/'owned_suspended_launch.py');runtime=[pin(DECODER/x) for x in ['DisassemblePInvokeWrappers.dll','Iced.dll','DisassemblePInvokeWrappers.runtimeconfig.json']];need(guard['sha256']==GUARD_SHA and launcher['sha256']==LAUNCHER_SHA and runtime[0]['sha256']==DECODER_SHA,'Frozen runtime/owned guard changed')
    plan={'schema':'prepared-original-startup-foundation-inert-decode/v1','status':'prepared_no_child_started','fixture':str(out),'slice':pin(proof),'input':pin(input_path),'decoder_runtime':runtime,'guard':guard,'launcher':launcher,'runner':runner,'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'cap_bytes':256*1024**2,'reserve_bytes':int(1.5*1024**3),'maximum_seconds':90,'output':str(out/'decoded-instructions.jsonl'),'Main_modified':False,'compiler_Unity_game_network_executed':False,'whole_method_recovery_claimed':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'status':plan['status'],'plan':pin(target),'original_bytes':sum(len(bytes.fromhex(r['runtime_function']['bytes'])) for r in rows),'Root_run_command':['python','-B',runner['path'],'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
if __name__=='__main__':main()
