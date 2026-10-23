"""Prepare exact original Singleton accessors/base-ctor for Root's inert decoder."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata
from inventory_recroom_game_root_native import region
from prepare_startup_foundation_slice import SOURCE_PINS
from run_startup_foundation_decode import pin,save,need,GUARD_SHA,LAUNCHER_SHA,DECODER_SHA,DECODER
SLICE=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207'
def main():
    sources=[ROOT/'CodeSource'/name for name in SOURCE_PINS]
    for path in sources:need(pin(path)['sha256']==SOURCE_PINS[path.relative_to(ROOT/'CodeSource').as_posix()],'Original source hash changed')
    rows=[]
    with sources[0].open('rb') as bf,sources[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as binary,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as metadata:
        v=ExternMetadata(binary,metadata)
        for spec,name,args,pointer,count in [(306226,'get_Instance',['GameRoot'],0x1806f6230,252),(306323,'get_IsInitialized',['PlatformManager'],0x18333e980,346),(306223,'.ctor',['GameRoot'],0x180d708b0,26)]:
            mi,ci,gi=struct.unpack_from('<iii',binary,v.method_specs+spec*12);original=v.method_info(mi);need(original['owner']=='SingletonMonoBehaviour`1' and original['name']==name and [v.typename(t) for t in v.inst(ci)]==args and not v.inst(gi),'Exact original concrete generic method identity')
            targets=v.generic_targets({spec})[spec];need(len(targets)==1 and int(targets[0]['pointer'],16)==pointer and targets[0]['adjustor_thunk_index']==-1,'Exact original native registration')
            native=region(v,pointer);need(len(bytes.fromhex(native['bytes']))==count,'Exact small registered entry span')
            rows.append({'label':'Singleton<'+args[0]+'>.'+name,'original':original,'method_spec':spec,'class_arguments':args,'method_arguments':[],'native_pointer':hex(pointer),'registration':targets[0],'runtime_function':native,'complete_method_CFG_claimed':False})
    out=SLICE/('RootDecodePlan-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();data=out/'three-original-accessor-windows.json';save(data,{'schema':'bounded-next-startup-native-windows/v1','methods':rows,'original_bytes':624,'whole_method_recovery_claimed':False})
    proof=out/'preparation-proof.json';save(proof,{'schema':'original-Singleton-accessor-base-ctor-preparation/v1','status':'prepared_no_child_started','sources':[pin(p) for p in sources],'producer':pin(Path(__file__)),'input':pin(data),'Main_modified':False,'compiler_Unity_game_network_executed':False})
    runner=pin(HERE/'run_startup_foundation_decode.py');need(runner['sha256']=='e64411ff3ee934e33d34608791dafaf09b91f60a5a9fd4f3e4b5f8f59b055ed6','Frozen Root inert runner');guard=pin(HERE/'original_shader_pair_editor_conversion.py');launcher=pin(HERE/'owned_suspended_launch.py');runtime=[pin(DECODER/name) for name in ['DisassemblePInvokeWrappers.dll','Iced.dll','DisassemblePInvokeWrappers.runtimeconfig.json']];need(guard['sha256']==GUARD_SHA and launcher['sha256']==LAUNCHER_SHA and runtime[0]['sha256']==DECODER_SHA,'Frozen original decoder/guard')
    plan={'schema':'prepared-original-startup-foundation-inert-decode/v1','status':'prepared_no_child_started','fixture':str(out),'slice':pin(proof),'input':pin(data),'decoder_runtime':runtime,'guard':guard,'launcher':launcher,'runner':runner,'dotnet':pin(Path('C:/Program Files/dotnet/dotnet.exe')),'cap_bytes':256*1024**2,'reserve_bytes':int(1.5*1024**3),'maximum_seconds':90,'output':str(out/'decoded-instructions.jsonl'),'Main_modified':False,'compiler_Unity_game_network_executed':False,'whole_method_recovery_claimed':False}
    target=out/'plan.json';save(target,plan);print(json.dumps({'plan':pin(target),'original_bytes':624,'Root_run_command':['python','-B',runner['path'],'--plan',str(target),'--plan-sha256',pin(target)['sha256'],'--run']}))
if __name__=='__main__':main()
