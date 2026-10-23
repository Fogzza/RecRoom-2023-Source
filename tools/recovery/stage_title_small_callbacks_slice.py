"""Prove/stage two complete small title callbacks; no Main or managed execution."""
from pathlib import Path
import base64,datetime as dt,hashlib,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_ogpeg_constructors import Decoder
from collect_title_page_route_native import pin
from stage_title_page_route_slice import property_for
JOINS=ROOT/'Validation/TitleRemainingCallbacksTypedJoins-20261023T092100Z-73e7efb3/report.json'
JOINS_SHA='63b0d9aae7dc0e692432485ae0f8afae6ca3866574a755e6825be1f93fb51c0a'
SOURCE=WS/'RR23/Assets/Scripts/Assembly-CSharp/TitleScreenManager.cs'
SOURCE_SHA='38ac36a43cb3f28f729d2f3d3570cd859d01f53d438dcc7ada3d3cd3c1e9671e'

def screen(code,va):
    d=Decoder(code,va);d.literal('4883ec2833d2b101');a=d.relative('e8');d.literal('33d2b101');b=d.relative('e8');d.literal('33d233c9');c=d.relative('e8');d.literal('33d233c9');e=d.relative('e8');d.literal('33d28d4a054883c428');f=d.relative('e9');d.end();need([a,b,c,e,f]==[0x18318c5b0,0x18318c5f0,0x18318c670,0x18318c630,0x18318c6f0] and len(code)==54,'Exact five original Screen setter targets and arguments');return {'ordered_targets':[hex(x) for x in [a,b,c,e,f]],'ordered_values':[True,True,False,False,5],'input_bool_argument_unused':True,'same_this_not_read':True,'all54_original_bytes_recognized':True}

def size(code,va):
    d=Decoder(code,va);d.literal('40534883ec40');flag=d.relative('803d','00');d.literal('488bd9');loaded=d.short('75');klass=d.relative('488d0d');init=d.relative('e8');written=d.relative('c605','01');at_loaded=va+d.at;d.literal('488b4b184885c9');null1=d.short('74');d.literal('33d2');transform=d.relative('e8');klass2=d.relative('488b15');d.literal('4885c0');null2=d.short('74');d.literal('33db483910480f44d84885db');cast=d.short('74');d.literal('33d2488bcb');delta=d.relative('e8');d.literal('4533c04889442450488bd3488d4c2430');lossy=d.relative('e8');d.literal('f20f10100f28caf30f595424500fc6c955f30f594c24540f28c20f14c166480f7ec04883c4405bc3');null_at=va+d.at;nullhelper=d.relative('e8');d.literal('cc');cast_at=va+d.at;d.literal('488bc8');casthelper=d.relative('e8');d.literal('cc');d.end()
    need(len(code)==165 and flag==written==0x188c76848 and loaded==at_loaded and klass==klass2==0x1886f1200 and init==0x1806c01e0 and transform==0x183eba7f0 and delta==0x183180380 and lossy==0x1845430a0 and null1==null2==null_at and cast==cast_at and nullhelper==0x1806c0390 and casthelper==0x1806bfd70,'Exact original cast, raw-null/invalid-cast exits, ordered getters, copied size, scalar arithmetic and all165 bytes');return {'mainCanvas_original_offset':24,'ordered_targets':[hex(x) for x in [transform,delta,lossy]],'cast_type_usage':hex(klass),'raw_reference_null_checks':True,'exact_class_cast_requires_original_RectTransform_sealed_proof':True,'sizeDelta_struct_copied_before_lossyScale_getter':True,'returned_components':['lossyScale.x * sizeDelta.x','lossyScale.y * sizeDelta.y'],'x_product_evaluated_before_y':True,'all165_original_bytes_recognized':True}

def enum(v):
    ti=4552;need(v.full_name(ti)=='UnityEngine.ScreenOrientation','Exact original ScreenOrientation enum');a=v.row('typeDefinitions',ti,88);start=v.i32(v.m,a+32);count=v.u16(v.m,a+68);selected=[i for i in range(start,start+count) if v.string(v.i32(v.m,v.row('fields',i,12)))=='AutoRotation'];need(len(selected)==1,'One original AutoRotation field');values=[]
    for i in range(v.count('fieldDefaultValues',12)):
        a=v.row('fieldDefaultValues',i,12)
        if v.i32(v.m,a)==selected[0]:
            typ=v.typename(v.native_type(v.i32(v.m,a+4)));at=v.i32(v.m,a+8);need(at>=0 and at+4<=v.tables['fieldAndParameterDefaultValueData'][1],'Exact original default range');values.append({'field_index':selected[0],'type':typ,'value':v.i32(v.m,v.tables['fieldAndParameterDefaultValueData'][0]+at)})
    need(values==[{'field_index':selected[0],'type':'System.Int32','value':5}],'Original native enum argument5 is AutoRotation');return values[0]

def accessor_property(v,method):
    if method['name'].startswith('get_'):return property_for(v,method)
    td=v.row('typeDefinitions',method['owner_index'],88);first=v.i32(v.m,td+36);start=v.i32(v.m,td+44);count=v.u16(v.m,td+66);rows=[]
    for i in range(count):
        at=v.row('properties',start+i,20);setter=v.i32(v.m,at+8)
        if setter>=0 and first+setter==method['index']:rows.append({'name':v.string(v.i32(v.m,at)),'token':hex(v.u32(v.m,at+16)),'setter_index':method['index'],'getter_index_relative':v.i32(v.m,at+4)})
    need(len(rows)==1,'One exact original setter-owned PropertyDef');return rows[0]

def main():
    need(pin(JOINS)['sha256']==JOINS_SHA and pin(SOURCE)['sha256']==SOURCE_SHA,'Frozen complete callbacks and current TitleScreenManager with prior recovered bodies');p=json.loads(JOINS.read_bytes());need(pin(p['actual_decoder_receipt']['path'])==p['actual_decoder_receipt'] and pin(p['actual_decoded_output']['path'])==p['actual_decoded_output'],'Actual Root inert decode pins');chosen=[x for x in p['callbacks'] if x['original_method']['name'] in ['NBDKIBMNLCA','EKJBJGDALKG']];need(len(chosen)==2,'Exactly two complete small callback bodies');shapes=[];controls=[]
    for row,function in zip(chosen,[screen,size]):
        code=bytes.fromhex(row['native_region']['bytes']);va=0x180000000+row['native_region']['start_rva'];need(row['CFG']['all_original_bytes_decoded'] and row['CFG']['all_nonterminal_edges_closed'],'Whole native CFG already closed');shapes.append(function(code,va))
        # Reject any single-byte change throughout these small literal/native
        # shapes, including all branches, receiver offsets and float operations.
        for i in range(len(code)):
            changed=bytearray(code);changed[i]^=1
            try:function(bytes(changed),va)
            except (ValueError,IndexError):controls.append({'method':row['original_method']['name'],'changed_byte':i,'rejected':True})
            else:raise ValueError('Unproved native-byte mutation accepted '+str(i))
    source=json.loads(Path(p['original_region_input']['path']).read_bytes());paths=[Path(x['path']) for x in source['original_inputs']]
    for x in source['original_inputs']:need(pin(x['path'])==x,'Pinned genuine original inputs')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);aut=enum(v);rect=v.type_info(4725);need(rect['name']=='UnityEngine.RectTransform' and rect['image']=='UnityEngine.CoreModule.dll' and rect['flags']&0x100,'Original RectTransform is sealed, so native exact-class test equals managed cast');bindings=[]
        expected={'0x18318c5b0':('UnityEngine.Screen','set_autorotateToLandscapeLeft','System.Void',['System.Boolean'],True),'0x18318c5f0':('UnityEngine.Screen','set_autorotateToLandscapeRight','System.Void',['System.Boolean'],True),'0x18318c670':('UnityEngine.Screen','set_autorotateToPortrait','System.Void',['System.Boolean'],True),'0x18318c630':('UnityEngine.Screen','set_autorotateToPortraitUpsideDown','System.Void',['System.Boolean'],True),'0x18318c6f0':('UnityEngine.Screen','set_orientation','System.Void',['UnityEngine.ScreenOrientation'],True),'0x183eba7f0':('UnityEngine.Component','get_transform','UnityEngine.Transform',[],False),'0x183180380':('UnityEngine.RectTransform','get_sizeDelta','UnityEngine.Vector2',[],False),'0x1845430a0':('UnityEngine.Transform','get_lossyScale','UnityEngine.Vector3',[],False)}
        for row in chosen:
            targets=[]
            for address,items in row['direct_original_application_targets'].items():
                need(len(items)==1,'Every small callback application target uniquely bound');m=items[0];need(address in expected and (m['owner'],m['name'],m['return'],[a['type'] for a in m['parameters']],bool(m['flags']&0x10))==expected[address] and m['image']=='UnityEngine.CoreModule.dll','Exact original Unity accessor owner/signature/static-instance identity');prop=accessor_property(v,m);need(prop['name']==m['name'][4:],'Exact original accessor-owned engine property source name');targets.append({'native_address':address,'original_method':m,'original_property':prop})
            bindings.append(targets)
    before=SOURCE.read_bytes();old1=b'\tprivate void NBDKIBMNLCA(bool ICHBECDKHOJ)\r\n\t{\r\n\t}\r\n';old2=b'\tprivate Vector2 EKJBJGDALKG()\r\n\t{\r\n\t\treturn default;\r\n\t}\r\n'
    new1=b'\tprivate void NBDKIBMNLCA(bool ICHBECDKHOJ)\r\n\t{\r\n\t\tScreen.autorotateToLandscapeLeft = true;\r\n\t\tScreen.autorotateToLandscapeRight = true;\r\n\t\tScreen.autorotateToPortrait = false;\r\n\t\tScreen.autorotateToPortraitUpsideDown = false;\r\n\t\tScreen.orientation = ScreenOrientation.AutoRotation;\r\n\t}\r\n'
    new2=b'\tprivate Vector2 EKJBJGDALKG()\r\n\t{\r\n\t\tRectTransform rectTransform = (RectTransform)mainCanvas.transform;\r\n\t\tVector2 sizeDelta = rectTransform.sizeDelta;\r\n\t\tVector3 lossyScale = rectTransform.lossyScale;\r\n\t\treturn new Vector2\r\n\t\t{\r\n\t\t\tx = lossyScale.x * sizeDelta.x,\r\n\t\t\ty = lossyScale.y * sizeDelta.y\r\n\t\t};\r\n\t}\r\n'
    edits=[];after=before
    for old,new in [(old1,new1),(old2,new2)]:need(before.count(old)==1,'Exact current single stub span');edits.append({'start':before.index(old),'length':len(old),'original_base64':base64.b64encode(old).decode(),'replacement_base64':base64.b64encode(new).decode()});after=after.replace(old,new,1)
    out=ROOT/'Validation'/('TitleSmallCallbacksSlice-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();candidate=out/'TitleScreenManager.cs';candidate.write_bytes(after);members=out/'RecoveredTitleSmallCallbacks.members.cs';members.write_bytes(new1+b'\r\n'+new2);meta=Path(str(SOURCE)+'.meta');report={'schema':'two-original-small-title-callback-bodies-native-source-candidate/v1','status':'two_complete_native_bodies_staged_binding_and_effects_pending','native_join_proof':pin(JOINS),'original_inputs':source['original_inputs'],'actual_decoder_receipt':p['actual_decoder_receipt'],'actual_decoded_output':p['actual_decoded_output'],'original_methods':[x['original_method'] for x in chosen],'complete_native_shapes':shapes,'original_typed_accessor_bindings':bindings,'ScreenOrientation_AutoRotation_original_default':aut,'sealed_RectTransform_original_type':rect,'native_single_byte_negative_controls':controls,'source':pin(SOURCE),'source_meta':pin(meta),'candidate':pin(candidate),'readable_members':pin(members),'byte_edits':edits,'all_bytes_outside_two_exact_original_stubs_preserved':True,'current_Main_modified':False,'managed_compiler_Unity_game_network_executed':False,'complete_988byte_music_callback_recovered':False,'working_title_login_claimed':False,'producer':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'candidate':pin(candidate),'native_negative_controls':len(controls),'Main_modified':False}))
if __name__=='__main__':main()
