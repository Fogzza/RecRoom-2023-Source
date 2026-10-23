"""Stage one source-only Route getter from closed original caller/dispatch.

No callee body is replaced or assumed functional. The native interface helper
is recognized as an ordinary IL2CPP interface dispatch operation, with its
runtime slow lookup retained as runtime support rather than invented C# code.
"""
from pathlib import Path
import base64,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from inventory_recroom_game_root_native import region
from audit_ogpeg_constructors import Decoder
from prove_nameserver_request_factory_cfg import no_chained_entries
from collect_title_page_route_native import shape,pin
from prove_service_container_getter_native import header_layout
PRIOR=ROOT/'Validation/TitlePageRouteNative-20261023T064636Z-a3089193/report.json'
PRIOR_SHA='f2c17fd1958965814f883e6236e108c4708e4bc03c2499547c540b157cca09e0'
GETTER=ROOT/'Validation/ServiceContainerGetterCFG-20261022T181446Z-208ec5d3/report.json'
def dispatch(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 57 48 83 ec 20 49 8b d8 0f b7 f9 4d 8b 00 33 c0 4c 8b da 45 0f b7 90 2a 01 00 00 66 41 3b c2');none=d.short('73')
    d.literal('4d 8b 88 b0 00 00 00 0f 1f 00');loop=va+d.at
    d.literal('0f b7 d0 8b ca 48 03 c9 4d 39 1c c9');found=d.short('74');d.literal('66 ff c0 66 41 3b c2');again=d.short('72');slowat=va+d.at
    d.literal('44 0f b7 c7 49 8b d3 48 8b cb');slow=d.relative('e8');invoke=va+d.at
    d.literal('48 8b 50 08 48 8b cb 48 8b 5c 24 30 48 83 c4 20 5f 48 ff 20');fast=va+d.at
    d.literal('48 03 d2 8b c7 41 03 44 d1 08 48 98 48 c1 e0 04 48 05 38 01 00 00 49 03 c0');back=d.short('eb');d.end()
    need(len(code)==133 and none==slowat and found==fast and again==loop and back==invoke,'Complete interface fast/slow/invoke CFG')
    need(header_layout()['vtable_offset']==0x138 and header_layout()['VirtualInvokeData_bytes']==16,'Exact matching installed IL2CPP class/invoke layout')
    return {'all133bytes_checked':True,'all_internal_CFG_edges_closed':True,'incoming_arguments':{'RCX':'16-bit interface slot5','RDX':'exact original MCCKDPKLCIN class metadata','R8':'same resolved interface object'},'class_interfaceOffsets_offset':0xb0,'class_interfaceOffsets_count_offset':0x12a,'interfaceOffsetPair_bytes':16,'interfaceOffsetPair_type_offset':0,'interfaceOffsetPair_vtable_offset_field':8,'vtable_offset':0x138,'VirtualInvokeData_bytes':16,'method_pointer_offset':0,'MethodInfo_offset':8,'fast_path':'scan exact class interface-type pointers; take class.vtable[pair.offset+slot]','slow_path_call':hex(slow),'slow_path_arguments':['same object','same interface class','same16-bit slot'],'tail_dispatch':'RCX is same object; RDX is selected MethodInfo; tailjmp selected method pointer, retaining bool return','runtime_support_limit':'The133B invoker fast/slow/join/tail behavior is fully recognized. The called IL2CPP slow lookup internals are not recovered as game source; matching installed ClassInlines defines this runtime operation. No default implementation or fixed SupportsPortraitMode answer is introduced.'}
def property_for(v,method):
    td=v.row('typeDefinitions',method['owner_index'],88);first=v.i32(v.m,td+36);start=v.i32(v.m,td+44);count=v.u16(v.m,td+66);rows=[]
    for i in range(count):
        at=v.row('properties',start+i,20)
        if v.i32(v.m,at+4)>=0 and first+v.i32(v.m,at+4)==method['index']:rows.append({'name':v.string(v.i32(v.m,at)),'token':hex(v.u32(v.m,at+16)),'getter_index':method['index'],'setter_index_relative':v.i32(v.m,at+8)})
    need(len(rows)==1,'One exact original PropertyDef getter ownership');return rows[0]
def main():
    need(pin(PRIOR)['sha256']==PRIOR_SHA and pin(GETTER)['sha256']=='eaef8bcfe62906e44e58d1a7f587eeb2185485a8adc9dba8811f47cc9e6060f6','Frozen original caller and service PropertyDef proof')
    prior=json.loads(PRIOR.read_bytes());getter=json.loads(GETTER.read_bytes());need(getter['property']['name']=='CFHDLGEGDFD' and getter['original']['name']=='PNFLFFOAING','Original obfuscated getter is original CFHDLGEGDFD property')
    paths=[Path(x['path']) for x in prior['original_inputs']]
    for row in prior['original_inputs']:need(pin(row['path'])==row,'Exact original source inputs')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);m=v.find_method('RRUI.Data.TitleScreenFlowModel/TitleScreenPage',0x06008ab5);w=region(v,v.method_pointer(m));need(w==prior['runtime_function'],'Exact original caller region')
        shape(bytes.fromhex(w['bytes']),v.method_pointer(m));helper=region(v,0x180157240);code=bytes.fromhex(helper['bytes']);need(helper['sha256']=='d64eb680a6f5c43552bc4e0d5143409f0e8bc1a8cf5f96b6cff551c027f853fc','Original exact helper region')
        helperproof=dispatch(code,0x180157240);chains=no_chained_entries(v,[helper]);interface=v.find_method('MCCKDPKLCIN',0x0600000c);slot=v.u16(md,v.row('methods',interface['index'],32)+28)
        need(interface['name']=='get_SupportsPortraitMode' and interface['return']=='System.Boolean' and not interface['parameters'] and slot==5 and interface['image']=='RecRoom.GameSystems.Interfaces.dll','Original unique interface slot5 signature')
        prop=property_for(v,interface);need(prop['name']=='NFBNECNPLFE' and prop['token']=='0x1700000b','Exact original obfuscated PropertyDef NFBNECNPLFE owns get_SupportsPortraitMode')
        first=prior['metadata_usages']['0x188712590'];second=prior['direct_original_pointer_aliases']['0x1867680c0'];third=prior['metadata_usages']['0x1887276c0']
        need(first['kind']==6 and first['index']==306323 and first['method']['name']=='get_IsInitialized' and first['class_argument_types']==['PlatformManager'] and len(second)==1 and second[0]['token']=='0x600001e' and second[0]['owner']=='MPAAIECKLGA' and second[0]['return']=='MNALHHOLFGL' and not second[0]['parameters'] and third['kind']==6 and third['index']==452541 and third['method']['name']=='HHCPOGCCGNF' and third['method_argument_types']==['MCCKDPKLCIN'] and [p['type'] for p in third['method']['parameters']]==['System.String'],'Exact original application callees and null string argument')
    controls=[]
    for at in [14,25,34,51,65,81,99,120,132]:
        changed=bytearray(code);changed[at]^=1
        try:dispatch(bytes(changed),0x180157240)
        except (ValueError,struct.error):controls.append({'offset':at,'rejected':True})
        else:raise ValueError('Changed interface invoker accepted at '+str(at))
    source=WS/'RR23/Assets/Scripts/Assembly-CSharp/RRUI/Data/TitleScreenFlowModel.cs';before=source.read_bytes();old=b'\t\t\tpublic Route Route => null;';new=b'''\t\t\tpublic Route Route\r
\t\t\t{\r
\t\t\t\tget\r
\t\t\t\t{\r
\t\t\t\t\tif (!routeIsDifferentOnMobile || !SingletonMonoBehaviour<PlatformManager>.IsInitialized)\r
\t\t\t\t\t\treturn route;\r
\t\t\t\t\treturn MPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<MCCKDPKLCIN>(null).NFBNECNPLFE\r
\t\t\t\t\t\t? mobileRoute : route;\r
\t\t\t\t}\r
\t\t\t}'''
    need(before.count(old)==1,'Unique exact existing nested Route stub');at=before.index(old);candidate=before[:at]+new+before[at+len(old):]
    out=ROOT/'Validation'/('TitlePageRouteSlice-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();target=out/'TitleScreenFlowModel.cs';target.write_bytes(candidate)
    headers=[WS/'Tools/Editors/2020.3.33f1/Editor/Data/il2cpp/libil2cpp'/x for x in ['il2cpp-class-internals.h','vm/ClassInlines.h','vm/ClassInlines.cpp','codegen/il2cpp-codegen-il2cpp.h']]
    report={'schema':'original-TitleScreenPage-Route-source-caller-slice/v1','status':'closed_original_caller_staged_full_file_binding_effects_and_callee_bodies_UNVERIFIED','original_method':m,'caller_evidence':pin(PRIOR),'service_getter_PropertyDef_evidence':pin(GETTER),'runtime_interface_invoker':{'region':helper,'proof':helperproof,'no_chained_regions':chains},'original_interface_slot5':{'method':interface,'slot':slot,'property':prop},'matching_installed_runtime_primary_sources':[pin(p) for p in headers],'negative_controls':controls,'source':pin(source),'source_meta':pin(str(source)+'.meta'),'candidate':pin(target),'byte_edit':{'start':at,'length':len(old),'original_base64':base64.b64encode(old).decode(),'replacement_base64':base64.b64encode(new).decode()},'all_source_bytes_outside_Route_property_preserved':True,'all_original_serialized_fields_unchanged':True,'new_Route_objects_constructed':False,'callee_bodies_recovered_by_this_slice':False,'explicit_callee_dependencies':['SingletonMonoBehaviour<PlatformManager>.IsInitialized','MPAAIECKLGA.CFHDLGEGDFD','MNALHHOLFGL.HHCPOGCCGNF<MCCKDPKLCIN>(string)','MCCKDPKLCIN.SupportsPortraitMode concrete implementation'],'behavior_plan':['false routeIsDifferentOnMobile: return same regular Route, no initialization/service/predicate access','true flag but initialization false: return same regular Route, no service/predicate','true initialized: get service once; resolve same typed interface once with null name; read SupportsPortraitMode once','true predicate returns same mobileRoute; false predicate returns same regular route; null stored Route returned unchanged','null service/container result throws normal NRE before any following operation; dependency exceptions propagate'],'Main_modified':False,'compiler_Unity_game_network_started':False,'working_title_login_or_bootstrap_claimed':False,'tool':pin(Path(__file__))}
    receipt=out/'report.json';receipt.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(receipt),'candidate':pin(target),'native_helper_negative_controls':len(controls),'Main_modified':False,'compiled':False}))
if __name__=='__main__':main()
