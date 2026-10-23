"""Original inline field/getter contracts and constants for display callback."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from collect_title_page_route_native import pin
from collect_nameserver_request_factory_native import fields
from stage_title_page_route_slice import property_for
from stage_browser_navigation_slice import projected_property
from prepare_title_manager_start_native import save
INPUT=ROOT/'Validation/TitlePMNJIOHDABBTypedJoins-20261023T081159Z-2227c3bb/report.json'
def main():
    need(pin(INPUT)['sha256']=='33f9bd36fd1c0789c3c52d33980c8251ad0df410900bfe0cc56b6300c25e9413','Frozen complete original callback joins');p=json.loads(INPUT.read_bytes());source=json.loads(Path(p['original_region_input']['path']).read_bytes());paths=[Path(x['path']) for x in source['original_inputs']]
    for x in source['original_inputs']:need(pin(x['path'])==x,'Original input pin')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);types=['RecRoom.Core.CameraRig','RecRoom.Core.ScreenHUD','RecRoom.Core.ScreenWorldSpaceUIAnchor','RecRoom.Core.UI.UIInputModule'];owners={};getters=[]
        selected=[('RecRoom.Core.CameraRig','get_ScreenModeHUD',168,'RecRoom.Core.ScreenHUD'),('RecRoom.Core.CameraRig','get_ScreenModeCamera',72,'UnityEngine.Camera'),('RecRoom.Core.ScreenHUD','get_WorldSpaceUIAnchor',24,'RecRoom.Core.ScreenWorldSpaceUIAnchor'),('RecRoom.Core.ScreenWorldSpaceUIAnchor','get_AttachedGameObject',48,'UnityEngine.GameObject'),('RecRoom.Core.UI.UIInputModule','get_ControllerCamera',136,'UnityEngine.Camera')]
        for owner in types:
            ts=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)==owner];need(len(ts)==1,'Unique exact owner');ti=ts[0];owners[owner]={'type':v.type_info(ti),'fields':fields(v,ti)};td=v.row('typeDefinitions',ti,88);start=v.i32(md,td+36);count=v.u16(md,td+64)
            for o,name,offset,ret in selected:
                if o!=owner:continue
                ms=[v.method_info(i) for i in range(start,start+count) if v.method_info(i)['name']==name];need(len(ms)==1 and ms[0]['return']==ret and not ms[0]['parameters'],'Exact leaf getter method');m=ms[0];f=[x for x in owners[owner]['fields'] if x['offset']==offset and not(x['native_type']['attributes']&16)];need(len(f)==1 and f[0]['type']==ret,'Same original field in caller and leaf getter');va=v.method_pointer(m);shape=bytes.fromhex('488b81')+struct.pack('<I',offset)+b'\xc3' if offset>=128 else bytes.fromhex('488b41')+bytes([offset])+b'\xc3';a=v.raw(va,len(shape));raw=bytes(b[a:a+len(shape)]);need(raw==shape,'Whole original leaf getter is exactly same field read then return');getters.append({'original':m,'property':property_for(v,m),'native_pointer':hex(va),'whole_native_leaf_hex':raw.hex(),'sha256':hashlib.sha256(raw).hexdigest(),'same_original_field':f[0],'whole_leaf_decoded':'mov rax,[rcx+'+str(offset)+']; ret; no other instruction, branch or side effect'})
        method=v.find_method('CPBPJLLMKDB',0x06004360);slot=v.u16(md,v.row('methods',method['index'],32)+28);need(slot==1 and method['name']=='get_InScreenDisplayMode' and method['return']=='System.Boolean' and not method['parameters'],'Exact original CPBP slot1 bool');prop=property_for(v,method);alias=projected_property(WS/'RR23/CompilerSupport/References/RecNet.Runtime.dll',method['owner'],int(prop['token'],16),int(method['token'],16));need(alias['name']=='InScreenDisplayMode' and alias['getter']['name']==method['name'],'Actual compiled source property alias')
        constants=[]
        for va,value in [(0x186f302e8,20.0),(0x186f302b8,1.0),(0x186f302c4,2.0)]:
            a=v.raw(va,4);raw=bytes(b[a:a+4]);actual=struct.unpack('<f',raw)[0];need(actual==value,'Exact original float literal');constants.append({'address':hex(va),'bytes':raw.hex(),'float32_value':actual})
    out=ROOT/'Validation'/('TitleDisplayInlineContracts-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-TitleScreenManager-display-callback-inline-leaf-contracts/v1','complete_callback_joins':pin(INPUT),'original_owners_and_fields':owners,'complete_inline_getter_contracts':getters,'interface_slot1':{'method':method,'original_slot':slot,'original_property':prop,'projected_source_property':alias},'original_float_literals':constants,'current_Main_leaf_bodies_restored_by_this_tool':False,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'producer':pin(Path(__file__))};target=out/'report.json';save(target,report);print(json.dumps({'report':pin(target),'exact_leaf_getters':len(getters),'all_original_fields_match':True,'Main_modified':False}))
if __name__=='__main__':main()
