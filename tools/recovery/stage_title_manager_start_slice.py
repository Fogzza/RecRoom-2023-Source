"""Stage only the complete original1053B TitleScreenManager.Start caller.

All native instruction bytes/edges/typed interfaces are checked. This is not a
replacement for the separate UI, scheduling, platform or callback bodies.
No Main write, compiler, Unity, player, network or native-library execution.
"""
from pathlib import Path
import base64,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_ogpeg_constructors import Decoder
from collect_title_page_route_native import pin
from stage_title_page_route_slice import dispatch,property_for
from stage_browser_navigation_slice import projected_property
from prove_service_container_getter_native import header_layout
from audit_original_rendering_sdk_candidates import h
JOINS=ROOT/'Validation/TitleStartTypedJoins-20261023T074947Z-228b743e/report.json'
DISPATCH=ROOT/'Validation/TitleStartDispatchJoins-20261023T075110Z-cb04b89a/report.json'

def shape(code,va):
    d=Decoder(code,va);d.literal('40 56 48 83 ec 40');flag=d.relative('80 3d','00');d.literal('48 8b f1');ready=d.short('75');usages=[];initializers=[]
    for _ in range(10):usages.append(d.relative('48 8d 0d'));initializers.append(d.relative('e8'))
    written=d.relative('c6 05','01');atready=va+d.at
    d.literal('48 8b 4e 18 48 89 5c 24 50 48 89 6c 24 58 48 89 7c 24 60 4c 89 74 24 68 48 85 c9');nulls=[d.relative('0f 84')]
    d.literal('45 33 c0 41 8d 50 02');render1=d.relative('e8');ui1=d.relative('48 8b 05');d.literal('48 8b 5e 18 f6 80 33 01 00 00 04');skipui1=d.short('74');d.literal('83 b8 e0 00 00 00 00');initedui1=d.short('75');d.literal('48 8b c8');cctorui1=d.relative('e8');reloadui1=d.relative('48 8b 05');ui1ready=va+d.at
    d.literal('48 8b 80 b8 00 00 00 48 8b 10 48 85 d2');nulls.append(d.relative('0f 84'));d.literal('48 85 db');nulls.append(d.relative('0f 84'));d.literal('48 8b 92 88 00 00 00 45 33 c0 48 8b cb');camera1=d.relative('e8')
    d.literal('48 8b 4e 18 48 85 c9');nulls.append(d.relative('0f 84'));d.literal('33 d2');transform1=d.relative('e8');d.literal('48 85 c0');nulls.append(d.relative('0f 84'));d.literal('45 33 c0 48 8d 4c 24 30 48 8b d0');position=d.relative('e8')
    d.literal('48 8b 4e 18 f2 0f 10 00 f2 0f 11 46 68 8b 40 08 89 46 70 48 85 c9');nulls.append(d.relative('0f 84'));d.literal('33 d2');transform2=d.relative('e8');d.literal('48 85 c0');nulls.append(d.relative('0f 84'));d.literal('45 33 c0 48 8d 4c 24 30 48 8b d0');scale=d.relative('e8')
    d.literal('48 8b 4e 18 f2 0f 10 00 f2 0f 11 46 74 8b 40 08 89 46 7c 48 85 c9');nulls.append(d.relative('0f 84'));d.literal('33 d2');transform3=d.relative('e8');d.literal('48 85 c0');nulls.append(d.relative('0f 84'));d.literal('45 33 c0 48 8d 4c 24 30 48 8b d0');rotation=d.relative('e8')
    d.literal('48 8b 4e 20 33 ed 0f 10 00 0f 11 86 80 00 00 00 48 85 c9');skiparray=d.relative('0f 84');d.literal('8b dd 8b d5 48 8b c1 0f 1f 00');loop=va+d.at
    d.literal('3b 51 18');loopexit=d.relative('0f 8d');d.literal('48 85 c0');nulls.append(d.relative('0f 84'));d.literal('48 63 fb 3b 58 18');range1=d.relative('0f 83');d.literal('48 8b 4c f8 20 48 85 c9');nulls.append(d.relative('0f 84'));d.literal('45 33 c0 41 8d 50 02');render2=d.relative('e8')
    d.literal('48 8b 46 20 48 85 c0');nulls.append(d.relative('0f 84'));d.literal('3b 58 18');range2=d.relative('0f 83');d.literal('48 8b 7c f8 20');ui2=d.relative('48 8b 05');d.literal('f6 80 33 01 00 00 04');skipui2=d.short('74');d.literal('39 a8 e0 00 00 00');initedui2=d.short('75');d.literal('48 8b c8');cctorui2=d.relative('e8');reloadui2=d.relative('48 8b 05');ui2ready=va+d.at
    d.literal('48 8b 80 b8 00 00 00 48 8b 10 48 85 d2');nulls.append(d.relative('0f 84'));d.literal('48 85 ff');nulls.append(d.relative('0f 84'));d.literal('48 8b 92 88 00 00 00 45 33 c0 48 8b cf');camera2=d.relative('e8')
    d.literal('48 8b 4e 20 ff c3 8b d3 48 8b c1 48 85 c9');nulls.append(d.relative('0f 84'));loopback=d.relative('e9');afterloop=va+d.at
    d.literal('4c 8b b6 98 00 00 00 4d 85 f6');nulls.append(d.relative('0f 84'));interfaceget=d.relative('48 8b 15');d.literal('b9 03 00 00 00 4d 8b c6');getter=d.relative('e8');actionclass=d.relative('48 8b 0d');d.literal('48 8b f8');allocateaction=d.relative('e8');actioncallback=d.relative('4c 8b 05');d.literal('45 33 c9 48 8b d6 48 8b c8 48 8b d8');actionctor=d.relative('e8')
    d.literal('45 33 c0 48 8b d3 48 8b cf');combine=d.relative('e8');casttype=d.relative('48 8b 15');d.literal('48 85 c0');nullcombine=d.short('74');d.literal('48 39 10 48 0f 44 e8 48 85 ed');badcast=d.relative('0f 84');aftercast=va+d.at
    interfaceset=d.relative('48 8b 15');d.literal('b9 04 00 00 00 4c 8b cd 4d 8b c6');setter=d.relative('e8');d.literal('33 d2 48 8b ce');callbackdirect=d.relative('e8')
    platformclass=d.relative('48 8b 0d');d.literal('48 8b 9e 90 00 00 00 f6 81 33 01 00 00 04');skipplatform=d.short('74');d.literal('83 b9 e0 00 00 00 00');initedplatform=d.short('75');cctorplatform=d.relative('e8');platformready=va+d.at
    instanceinfo=d.relative('48 8b 0d');platforminstance=d.relative('e8');d.literal('48 85 c0');nulls.append(d.relative('0f 84'));d.literal('33 d2 48 8b c8');layout=d.relative('e8');d.literal('48 85 db');nulls.append(d.short('74'));interfacelayout=d.relative('48 8b 15');d.literal('b9 03 00 00 00 44 8b c8 c6 44 24 20 01 4c 8b c3');layoutsetter=d.relative('e8')
    floatclass=d.relative('48 8b 0d');allocatefloat=d.relative('e8');floatctorinfo=d.relative('4c 8b 0d');d.literal('48 8b d6');floatcallback=d.relative('4c 8b 05');d.literal('48 8b c8 48 8b d8');floatctor=d.relative('e8');d.literal('45 33 c9 41 b0 01 48 8b d3 48 8b ce 4c 8b 74 24 68 48 8b 7c 24 60 48 8b 6c 24 58 48 8b 5c 24 50 48 83 c4 40 5e');scheduler=d.relative('e9')
    castfailure=va+d.at;d.literal('48 8b c8');throwcast=d.relative('e8');d.literal('cc');nullfailure=va+d.at;thrownull=d.relative('e8');d.literal('cc');rangefailure2=va+d.at;factory2=d.relative('e8');d.literal('48 8b c8 33 d2');throw2=d.relative('e8');d.literal('cc');rangefailure1=va+d.at;factory1=d.relative('e8');d.literal('48 8b c8 33 d2');throw1=d.relative('e8');d.literal('cc');d.end()
    expected=[0x188870a38,0x18876b5d0,0x188767870,0x188832d28,0x1888923d0,0x188712308,0x188806168,0x188878ed0,0x188879148,0x1887d5990]
    need(len(code)==1053 and flag==written and ready==atready and usages==expected,'All original metadata initialization/load identities')
    need(ui1==reloadui1==ui2==reloadui2==usages[9] and interfaceget==interfaceset==usages[3] and interfacelayout==usages[4] and platformclass==usages[6] and instanceinfo==usages[5] and actionclass==casttype==usages[2] and actioncallback==usages[8] and floatclass==usages[1] and floatctorinfo==usages[0] and floatcallback==usages[7],'Every hidden type/MethodInfo/callback operand joins the initialized original usage')
    need(all(x==0x1806c01e0 for x in initializers) and cctorui1==cctorui2==cctorplatform==0x180640f10 and allocateaction==allocatefloat==0x1806c0340 and throwcast==0x1806bfd70 and thrownull==0x1806c0390 and factory1==factory2==0x1806bff80 and throw1==throw2==0x1806c0360,'Exact original ordinary metadata/class/allocation/cast/null/range runtime support')
    need(skipui1==initedui1==ui1ready and skipui2==initedui2==ui2ready and skipplatform==initedplatform==platformready and skiparray==loopexit==afterloop and loopback==loop and all(x==nullfailure for x in nulls) and range1==rangefailure1 and range2==rangefailure2 and badcast==castfailure and nullcombine==aftercast,'Every original branch/loop/null/cast/index failure closes in the exact1053B region')
    need(render1==render2==0x1867a5d30 and camera1==camera2==0x1867a5f10 and transform1==transform2==transform3==0x183eba7f0 and position==0x184543140 and scale==0x184542f50 and rotation==0x1845432b0 and getter==0x180157240 and setter==0x180156f80 and actionctor==floatctor==0x1807df4f0 and combine==0x184f6cd70 and callbackdirect==0x181ae42c0 and platforminstance==0x1806f6230 and layout==0x180cda1e0 and layoutsetter==0x1801570e0 and scheduler==0x18555c8e0,'Every original typed application call and tail dispatch')
    return {'all1053bytes_checked':True,'all_original_CFG_edges_checked':True,'all_saved_register_and_stack_effects_recognized':True,'mainCanvas_evaluated_separately_for_each_access':True,'three_transform_getters_not_cached':True,'otherCanvases_initial_null_skips_loop_only':True,'otherCanvases_field_reread_after_each_setter_and_at_loop_condition':True,'loop_index_original_Int32':True,'each_otherCanvas_element_reread_before_worldCamera_set':True,'interface_property_receiver_evaluated_once_for_get_combine_set':True,'callback_directly_called_after_property_set':True,'layout_receiver_read_before_platform_getters_and_null_checked_after_arguments':True,'final_scheduler_true_argument_and_ignored_IDisposable_result':True}

def setter_dispatch(code,va,two=False):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 48 89 6c 24 10 48 89 74 24 18 57 48 83 ec 20 49 8b f8 0f b7 f1 4d 8b 00 33 c0')
    d.literal('41 8b e9' if two else '49 8b e9');d.literal('48 8b da 45 0f b7 98 2a 01 00 00 66 41 3b c3');none=d.short('73');d.literal('4d 8b 90 b0 00 00 00 66 0f 1f 44 00 00');loop=va+d.at;d.literal('0f b7 d0 8b ca 48 03 c9 49 39 1c ca');found=d.short('74');d.literal('66 ff c0 66 41 3b c3');again=d.short('72');slowat=va+d.at;d.literal('44 0f b7 c6 48 8b d3 48 8b cf');slow=d.relative('e8');invoke=va+d.at
    d.literal('4c 8b 48 08 8b d5 44 0f b6 44 24 50' if two else '4c 8b 40 08 48 8b d5');d.literal('48 8b cf 48 8b 5c 24 30 48 8b 6c 24 38 48 8b 74 24 40 48 83 c4 20 5f 48 ff 20');fast=va+d.at;d.literal('48 03 d2 8b c6 41 03 44 d2 08 48 98 48 c1 e0 04 48 05 38 01 00 00 49 03 c0');back=d.short('eb');d.end()
    need(len(code)==(167 if two else 162) and none==slowat and found==fast and again==loop and back==invoke and slow==0x18067bc00,'Whole original interface setter helper fast/slow/dispatch CFG')
    need(header_layout()['vtable_offset']==0x138 and header_layout()['VirtualInvokeData_bytes']==16,'Matching installed genuine interface dispatch layout')
    return {'all_bytes_checked':True,'all_CFG_edges_closed':True,'original_same_receiver_and_interface_and_slot':True,'dispatch_arguments':['same original receiver','same original Int32 enum','same original Boolean stack arg','selected MethodInfo'] if two else ['same original receiver','same original Action argument','selected MethodInfo'],'slow_lookup':hex(slow),'runtime_slow_lookup_not_reimplemented':True}

def method_api(path,owner,token):
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=h.m.cli.Cli(b);r=h.Read(c);types=[i for i in range(1,c.rows[2]+1) if r.definition(i)==owner];need(len(types)==1,'One exact projected owner '+owner);ms=[m for m in r.methods(types[0]) if int(m['token'],16)==token];need(len(ms)==1,'One exact projected MethodDef '+hex(token));return {'module':pin(path),'owner':owner,'method':ms[0]}

def typed(p,q,v):
    direct=p['direct_original_application_targets'];u=p['metadata_usages'];g=p['generic_registrations'];owners=q['original_owners'];bound=[]
    names=[('0x1867a5d30','UnityEngine.Canvas','set_renderMode','System.Void',['UnityEngine.RenderMode']),('0x1867a5f10','UnityEngine.Canvas','set_worldCamera','System.Void',['UnityEngine.Camera']),('0x183eba7f0','UnityEngine.Component','get_transform','UnityEngine.Transform',[]),('0x184543140','UnityEngine.Transform','get_position','UnityEngine.Vector3',[]),('0x184542f50','UnityEngine.Transform','get_localScale','UnityEngine.Vector3',[]),('0x1845432b0','UnityEngine.Transform','get_rotation','UnityEngine.Quaternion',[]),('0x184f6cd70','System.Delegate','Combine','System.Delegate',['System.Delegate','System.Delegate']),('0x181ae42c0','TitleScreenManager','PMNJIOHDABB','System.Void',[]),('0x180cda1e0','PlatformManager','get_DefaultLayout','HGMGOPODGJN',[]),('0x18555c8e0','JHIKKDDFDGA','PEOPJAFNOBD','System.IDisposable',['UnityEngine.MonoBehaviour','System.Action`1<System.Single>','System.Boolean'])]
    for addr,owner,name,ret,params in names:
        a=direct[addr];need(len(a)==1 and a[0]['owner']==owner and a[0]['name']==name and a[0]['return']==ret and [x['type'] for x in a[0]['parameters']]==params,'Exact direct application signature '+addr);bound.append(a[0])
    getter=[m for m in owners['CPBPJLLMKDB']['methods'] if m['original_virtual_slot']==3];setter=[m for m in owners['CPBPJLLMKDB']['methods'] if m['original_virtual_slot']==4];layout=[m for m in owners['DCCDAPLPICN']['methods'] if m['original_virtual_slot']==3]
    need(len(getter)==len(setter)==len(layout)==1,'Unique declared original interface slots3/4/3');getter=getter[0];setter=setter[0];layout=layout[0]
    need(getter['name']=='get_DisplayModeChange' and getter['token']=='0x6004362' and getter['return']=='System.Action' and not getter['parameters'] and setter['name']=='set_DisplayModeChange' and setter['token']=='0x6004363' and setter['return']=='System.Void' and [x['type'] for x in setter['parameters']]==['System.Action'],'Exact original Action property get/set signatures')
    need(layout['name']=='LEODHBOENKA' and layout['token']=='0x60000ca' and layout['return']=='System.Void' and [x['type'] for x in layout['parameters']]==['HGMGOPODGJN','System.Boolean'],'Exact original enum,bool interface method')
    prop=property_for(v,getter);need(prop['name']=='DNPLBGDKOJH' and prop['setter_index_relative']==4,'Original Action PropertyDef owns both slots');alias=projected_property(WS/'RR23/CompilerSupport/References/RecNet.Runtime.dll','CPBPJLLMKDB',int(prop['token'],16),int(getter['token'],16));need(alias['name']=='DisplayModeChange' and alias['getter']['name']==getter['name'],'Exact normalized source property alias')
    layout_api=method_api(WS/'RR23/CompilerSupport/References'/layout['image'],layout['owner'],int(layout['token'],16));schedule=bound[-1];schedule_api=method_api(WS/'RR23/CompilerSupport/References'/schedule['image'],schedule['owner'],int(schedule['token'],16));need(layout_api['method']['name']==layout['name'] and schedule_api['method']['name']==schedule['name'],'Original method source aliases unchanged')
    spec=u['0x188712308'];need(spec['kind']==6 and spec['index']==306322 and spec['method']['name']=='get_Instance' and spec['class_argument_types']==['PlatformManager'] and not spec['method']['parameters'] and g['306322'][0]['pointer']=='0x1806f6230','Exact PlatformManager singleton MethodSpec registration')
    ctor=u['0x188870a38'];need(ctor['kind']==6 and ctor['index']==28514 and ctor['method']['owner']=='System.Action`1' and ctor['method']['name']=='.ctor' and ctor['class_argument_types']==['System.Single'] and [x['type'] for x in ctor['method']['parameters']]==['System.Object','System.IntPtr'] and g['28514'][0]['pointer']=='0x1807df4f0','Exact Action<float> constructor usage and native registration')
    action=[m for m in direct['0x1807df4f0'] if m['owner']=='System.Action' and m['name']=='.ctor'];need(len(action)==1 and [x['type'] for x in action[0]['parameters']]==['System.Object','System.IntPtr'],'Exact non-generic Action constructor among shared original aliases')
    for addr,name,token,params in [('0x188879148','PMNJIOHDABB','0x60008a2',[]),('0x188878ed0','NMJIFHLPFNP','0x60008aa',['System.Single'])]:
        a=u[addr];need(a['kind']==3 and a['method']['owner']=='TitleScreenManager' and a['method']['name']==name and a['method']['token']==token and a['method']['return']=='System.Void' and [x['type'] for x in a['method']['parameters']]==params,'Exact original callback target '+name)
    for addr,typ in [('0x188767870','System.Action'),('0x18876b5d0','System.Action`1<System.Single>'),('0x188832d28','CPBPJLLMKDB'),('0x1888923d0','DCCDAPLPICN'),('0x188806168','SingletonMonoBehaviour`1<PlatformManager>'),('0x1887d5990','RecRoom.Core.UI.UIInputModule')]:need(u[addr]['kind']==1 and u[addr]['type']==typ,'Exact original type usage '+addr)
    for offset,name,typ in [(24,'mainCanvas','UnityEngine.Canvas'),(32,'otherCanvases','UnityEngine.Canvas[]'),(104,'AFFEJPNPKPM','UnityEngine.Vector3'),(116,'AHAPJIODLLJ','UnityEngine.Vector3'),(128,'BGMCKGNIMKN','UnityEngine.Quaternion'),(144,'IBDKAJJPLGA','DCCDAPLPICN'),(152,'LIPCPJMCHDF','CPBPJLLMKDB')]:
        f=[f for f in p['original_fields'] if f['offset']==offset and not(f['native_type']['attributes']&16)];need(len(f)==1 and f[0]['name']==name and f[0]['type']==typ,'Original Start field identity '+str(offset))
    ui=owners['RecRoom.Core.UI.UIInputModule'];instance=[f for f in ui['fields'] if f['name']=='Instance'];camera=[f for f in ui['fields'] if f['offset']==136 and not(f['native_type']['attributes']&16)];need(len(instance)==len(camera)==1 and instance[0]['offset']==0 and instance[0]['native_type']['attributes']==22 and camera[0]['name']=='<COMLJLOEGCA>k__BackingField' and camera[0]['type']=='UnityEngine.Camera','Exact original public static singleton and camera backing field')
    cameraget=v.find_method('RecRoom.Core.UI.UIInputModule',0x06012701);need(cameraget['name']=='get_ControllerCamera' and cameraget['return']=='UnityEngine.Camera' and not cameraget['parameters'],'Exact original ControllerCamera getter');pointer=v.method_pointer(cameraget);leaf=bytes(v.b[v.raw(pointer,16):v.raw(pointer,16)+16]);need(pointer==0x18091e5a0 and leaf==bytes.fromhex('48 8b 81 88 00 00 00 c3 cc cc cc cc cc cc cc cc'),'Complete original inlined camera getter mov same field136;ret;8 padding bytes');cameraprop=property_for(v,cameraget);need(cameraprop['name']=='JDIMEJBGLOD','Original camera PropertyDef owns get_ControllerCamera')
    render_ti=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)=='UnityEngine.RenderMode'];need(len(render_ti)==1,'Unique original RenderMode');td=v.row('typeDefinitions',render_ti[0],88);fs=v.i32(v.m,td+32);fc=v.u16(v.m,td+68);world=[]
    for i in range(fs,fs+fc):
        f=v.row('fields',i,12)
        if v.string(v.i32(v.m,f))=='WorldSpace':world.append(i)
    need(len(world)==1,'Unique original WorldSpace enum field');defaults=[]
    for i in range(v.count('fieldDefaultValues',12)):
        a=v.row('fieldDefaultValues',i,12)
        if v.i32(v.m,a)==world[0]:
            typ=v.typename(v.native_type(v.i32(v.m,a+4)));data=v.i32(v.m,a+8);need(data>=0 and data+4<=v.tables['fieldAndParameterDefaultValueData'][1],'Exact original enum default range');value=v.i32(v.m,v.tables['fieldAndParameterDefaultValueData'][0]+data);defaults.append({'field_index':world[0],'type':typ,'data_index':data,'value':value})
    need(len(defaults)==1 and defaults[0]['type']=='System.Int32' and defaults[0]['value']==2,'Original RenderMode.WorldSpace equals native argument2')
    return {'direct_typed_targets':bound,'Action_ctor':action[0],'property_getter':getter,'property_setter':setter,'original_property':prop,'projected_property_alias':alias,'layout_interface_method':layout,'layout_projected_API':layout_api,'scheduler_projected_API':schedule_api,'UIInputModule_static_Instance':instance[0],'UIInputModule_camera_field':camera[0],'camera_getter_inline_equivalence':{'method':cameraget,'property':cameraprop,'native_pointer':hex(pointer),'whole8byte_leaf_and_padding':leaf.hex(),'whole_leaf_sha256':hashlib.sha256(leaf[:8]).hexdigest(),'semantics':'mov rax,[same receiver+136];ret, no other effect or branch; caller independently null-checks receiver'},'RenderMode_WorldSpace_original_default':defaults[0],'all_touched_fields_and_application_targets_bound':True,'callee_bodies_recovered_by_this_slice':False}

def main():
    need(pin(JOINS)['sha256']=='13d28a4c53718afc9d2c7d484e4ddcb6da54d4152486e4df34eae09920e230ff' and pin(DISPATCH)['sha256']=='0624994ccfa1d9f553dcd8ecae58c0c670fdc321360afbbecac22567b2d4336f','Frozen complete caller and interface evidence')
    p=json.loads(JOINS.read_bytes());q=json.loads(DISPATCH.read_bytes());need(p['CFG']['all1053bytes_decoded'] and p['CFG']['all_reachable_edges_closed'],'Actual complete decoded Start CFG');need(pin(p['actual_decoder_receipt']['path'])==p['actual_decoder_receipt'] and pin(p['actual_decoded_output']['path'])==p['actual_decoded_output'],'Actual Root decode pins')
    source=json.loads(Path(p['original_region_input']['path']).read_bytes());row=source['methods'][0];code=bytes.fromhex(row['runtime_function']['bytes']);control=shape(code,int(row['native_pointer'],16));helpers=q['interface_helper_regions'];proofs=[dispatch(bytes.fromhex(helpers[0]['bytes']),0x180157240),setter_dispatch(bytes.fromhex(helpers[1]['bytes']),0x180156f80),setter_dispatch(bytes.fromhex(helpers[2]['bytes']),0x1801570e0,True)]
    # The reused getter invoker is generic in return type; its original tail
    # preserves RAX. Here slot3 returns Action, unlike Route slot5's Boolean.
    proofs[0]['incoming_arguments']['RCX']='16-bit interface slot3';proofs[0]['incoming_arguments']['RDX']='exact original CPBPJLLMKDB class';proofs[0]['tail_dispatch']='same object + selected MethodInfo; tailjmp selected method pointer preserving exact Action reference result'
    paths=[Path(x['path']) for x in source['original_inputs']]
    for x in source['original_inputs']:need(pin(x['path'])==x,'Original input pin')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:joins=typed(p,q,ExternMetadata(b,md))
    negatives=[]
    for offset in [0,15,24,144,172,224,261,293,337,386,437,469,503,536,579,627,664,692,739,785,825,866,908,947,977,988,1020,1052]:
        changed=bytearray(code);changed[offset]^=1
        try:shape(bytes(changed),int(row['native_pointer'],16))
        except (ValueError,struct.error):negatives.append({'native_offset':offset,'rejected':True})
        else:raise ValueError('Mutated original Start instruction accepted '+str(offset))
    for i,helper in enumerate(helpers[1:],1):
        raw=bytes.fromhex(helper['bytes'])
        for offset in [0,32,54,77,len(raw)-1]:
            changed=bytearray(raw);changed[offset]^=1
            try:setter_dispatch(bytes(changed),0x180156f80 if i==1 else 0x1801570e0,i==2)
            except (ValueError,struct.error):negatives.append({'helper_index':i,'native_offset':offset,'rejected':True})
            else:raise ValueError('Mutated original setter helper accepted')
    main=WS/'RR23/Assets/Scripts/Assembly-CSharp/TitleScreenManager.cs';need(pin(main)['sha256']=='423e772f68dcc826d63c0d1d76bac2232f9bdacd3522fefac197690e1f0b39ba','Rebased current Main with actual applied Awake and FlowModel');before=main.read_bytes();old=b'\tprivate void Start()\r\n\t{\r\n\t}\r\n';new=b'''\tprivate void Start()\r
\t{\r
\t\tmainCanvas.renderMode = RenderMode.WorldSpace;\r
\t\tmainCanvas.worldCamera = RecRoom.Core.UI.UIInputModule.Instance.ControllerCamera;\r
\t\tAFFEJPNPKPM = mainCanvas.transform.position;\r
\t\tAHAPJIODLLJ = mainCanvas.transform.localScale;\r
\t\tBGMCKGNIMKN = mainCanvas.transform.rotation;\r
\t\tif (otherCanvases != null)\r
\t\t{\r
\t\t\tfor (int i = 0; i < otherCanvases.Length; i++)\r
\t\t\t{\r
\t\t\t\totherCanvases[i].renderMode = RenderMode.WorldSpace;\r
\t\t\t\totherCanvases[i].worldCamera = RecRoom.Core.UI.UIInputModule.Instance.ControllerCamera;\r
\t\t\t}\r
\t\t}\r
\t\tLIPCPJMCHDF.DisplayModeChange += PMNJIOHDABB;\r
\t\tPMNJIOHDABB();\r
\t\tIBDKAJJPLGA.LEODHBOENKA(PlatformManager.Instance.DefaultLayout, true);\r
\t\tJHIKKDDFDGA.PEOPJAFNOBD(this, NMJIFHLPFNP, true);\r
\t}\r
''';need(before.count(old)==1,'Exact unique Start stub');at=before.index(old);after=before[:at]+new+before[at+len(old):]
    out=ROOT/'Validation'/('TitleManagerStartSlice-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();candidate=out/'TitleScreenManager.cs';candidate.write_bytes(after)
    report={'schema':'original-complete-TitleScreenManager-Start-source-caller-slice/v1','status':'complete_original_1053B_Start_caller_staged_binding_effects_UNVERIFIED','original_method':row['original'],'complete_native_typed_inventory':pin(JOINS),'dispatch_and_UI_field_inventory':pin(DISPATCH),'actual_decoder_receipt':p['actual_decoder_receipt'],'native_shape':control,'typed_joins':joins,'original_interface_helpers':{'regions':helpers,'proofs':proofs,'no_chained_regions':q['no_chained_regions']},'mutation_controls':negatives,'source':pin(main),'source_meta':pin(str(main)+'.meta'),'candidate':pin(candidate),'byte_edit':{'start':at,'length':len(old),'original_base64':base64.b64encode(old).decode(),'replacement_base64':base64.b64encode(new).decode()},'all_bytes_outside_Start_preserved':True,'all_original_meta_bytes_preserved':True,'existing_Awake_and_UI_members_preserved':True,'explicit_unrecovered_callee_dependencies':['UIInputModule static initialization/Instance population','Canvas and Transform Unity runtime','CPBPJLLMKDB concrete DisplayModeChange property','TitleScreenManager.PMNJIOHDABB() callback and direct activation','PlatformManager singleton and DefaultLayout getter','DCCDAPLPICN concrete LEODHBOENKA implementation','JHIKKDDFDGA.PEOPJAFNOBD scheduling implementation','TitleScreenManager.NMJIFHLPFNP(float) scheduled callback'],'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'working_boot_title_login_or_gameplay_claimed':False,'producer':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'candidate':pin(candidate),'all1053bytes_closed_and_bound':True,'negative_controls':len(negatives),'Main_modified':False,'compiled':False}))
if __name__=='__main__':main()
