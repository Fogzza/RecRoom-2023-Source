"""Stage complete original TitleScreenManager.Awake caller body from556B.

Every hot+cold opcode is recognized; typed original metadata joins bind every
application call/field. Callee bodies are explicitly separate dependencies.
Data only: no Main write, compiler, Unity, game, network or native-library load.
"""
from pathlib import Path
import base64,datetime as dt,hashlib,json,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import need
from audit_ogpeg_constructors import Decoder
from collect_title_page_route_native import pin
JOINS=ROOT/'Validation/TitleAwakeTypedJoins-20261023T072219Z-9a225df8/report.json'
JOINS_SHA='ecb0b620197c7c0c37c32bd474da26c9fa2e47d18900e59cbbdeab59f1056f42'
def shape(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 48 89 74 24 10 57 48 83 ec 60');flag=d.relative('80 3d','00');d.literal('48 8b f9');ready=d.short('75');usages=[];init=[]
    for _ in range(10):usages.append(d.relative('48 8d 0d'));init.append(d.relative('e8'))
    written=d.relative('c6 05','01');atready=va+d.at;baseinfo=d.relative('48 8b 15');d.literal('48 8b cf');base=d.relative('e8');loadingclass=d.relative('48 8b 0d');d.literal('f6 81 33 01 00 00 04');noinit=d.short('74');d.literal('83 b9 e0 00 00 00 00');inited=d.short('75');classinit=d.relative('e8');initdone=va+d.at
    instanceinfo=d.relative('48 8b 0d');instance=d.relative('e8');actionclass=d.relative('48 8b 0d');d.literal('48 8b d8');allocate=d.relative('e8');ctorinfo=d.relative('4c 8b 0d');d.literal('48 8b d7');callback=d.relative('4c 8b 05');d.literal('48 8b c8 48 8b f0');ctor=d.relative('e8');d.literal('48 85 db');nullloading=d.relative('0f 84')
    d.literal('0f 29 74 24 50 45 33 c0 48 8b d6 0f 29 7c 24 40 48 8b cb');subscribe=d.relative('e8');d.literal('48 8b 5f 38 48 8d 4c 24 20 33 d2');zero=d.relative('e8');d.literal('33 d2 48 8d 4c 24 30 f2 0f 10 30 8b 70 08');identity=d.relative('e8');unityclass=d.relative('48 8b 0d');d.literal('0f 10 38 f6 81 33 01 00 00 04');nounityinit=d.short('74');d.literal('83 b9 e0 00 00 00 00');unityinited=d.short('75');unityinit=d.relative('e8');unityready=va+d.at
    instantiateinfo=d.relative('4c 8b 0d');d.literal('4c 8d 44 24 30 48 8d 54 24 20 66 0f 7f 7c 24 30 48 8b cb f2 0f 11 74 24 20 89 74 24 28');instantiate=d.relative('e8');d.literal('48 8b d0 48 89 47 60 48 8d 4f 60');barrier1=d.relative('e8');d.literal('48 8b 4f 60 0f 28 7c 24 40 0f 28 74 24 50 48 85 c9');nullkeyboard=d.short('74');d.literal('45 33 c0 b2 01');hide=d.relative('e8')
    d.literal('33 c9');service1=d.relative('e8');d.literal('48 85 c0');nullservice1=d.short('74');resolve1info=d.relative('4c 8b 05');d.literal('33 d2 48 8b c8');resolve1=d.relative('e8');d.literal('48 8d 8f 90 00 00 00 48 8b d0 48 89 01');barrier2=d.relative('e8');d.literal('33 c9');service2=d.relative('e8');d.literal('48 85 c0');nullservice2=d.short('74');resolve2info=d.relative('4c 8b 05');d.literal('33 d2 48 8b c8');resolve2=d.relative('e8');d.literal('48 8d 8f 98 00 00 00 48 8b d0 48 89 01 48 8b 5c 24 70 48 8b 74 24 78 48 83 c4 60 5f');tail=d.relative('e9');failure=va+d.at;throw=d.relative('e8');d.literal('cc');d.end()
    expected=[0x188821fe8,0x188732f68,0x18871c890,0x18871cb08,0x18877c9c8,0x1887f13e0,0x18871d170,0x18870ac50,0x188803e70,0x188878c50]
    need(len(code)==556 and usages==expected and flag==written and ready==atready and baseinfo==usages[6] and loadingclass==usages[8] and instanceinfo==usages[7] and actionclass==usages[1] and ctorinfo==usages[0] and callback==usages[9] and unityclass==usages[5] and instantiateinfo==usages[4] and resolve1info==usages[3] and resolve2info==usages[2],'Every original metadata guard/load/hidden generic MethodInfo join')
    need(noinit==inited==initdone and nounityinit==unityinited==unityready and nullloading==nullkeyboard==nullservice1==nullservice2==failure,'Every hot/cold branch closes with exact original null failure')
    need(all(x==0x1806c01e0 for x in init) and classinit==unityinit==0x180640f10 and allocate==0x1806c0340 and barrier1==barrier2==tail==0x1806bfd30 and throw==0x1806c0390,'Exact ordinary runtime metadata/class/allocation/GC/null support')
    need([base,instance,ctor,subscribe,zero,identity,instantiate,hide,service1,resolve1,service2,resolve2]==[0x18333e400,0x1806f6230,0x1807df4f0,0x180ee7ce0,0x18454a5d0,0x18317c7d0,0x18205dc20,0x180ba9f30,0x1867680c0,0x1813b9460,0x1867680c0,0x1813b9460],'Every original typed application call and evaluation order')
    return {'all556bytes_checked':True,'all_hot_cold_CFG_edges_closed':True,'all_callee_saved_and_stack_return_effects_recognized':True,'base_Awake_first':True,'event_receiver_evaluated_before_delegate_creation':True,'event_delegate':'Action<bool>(same this,NBDKIBMNLCA)','subscribe_before_prefab_read_or_instantiation':True,'instantiate_arguments_in_order':['keyboardPrefab original field@56','copy Vector3.zero value before following getter','copy Quaternion.identity value'],'keyboard_field_assignment_before_null_check_and_hide':True,'ForceHideKeyboard_argument':True,'service_getter_evaluated_twice_no_cache':True,'resolve1':'DCCDAPLPICN,null explicit name →field144','resolve2':'CPBPJLLMKDB,null explicit name →field152','ordinary_runtime_helpers_not_reimplemented':True}
def typed(p):
    u=p['metadata_usages'];g=p['generic_registrations'];direct=p['direct_original_application_targets'];fields=p['original_fields']
    specs=[('0x18871d170',306409,'Awake','SingletonMonoBehaviour`1',['TitleScreenManager'],[],0x18333e400),('0x18870ac50',306260,'get_Instance','SingletonMonoBehaviour`1',['LoadingScreen'],[],0x1806f6230),('0x188821fe8',27514,'.ctor','System.Action`1',['System.Boolean'],[],0x1807df4f0),('0x18877c9c8',456319,'Instantiate','UnityEngine.Object',[],['RecRoom.AGVirtualKeyboard'],0x18205dc20),('0x18871cb08',452472,'HHCPOGCCGNF','MNALHHOLFGL',[],['DCCDAPLPICN'],0x1813b9460),('0x18871c890',452471,'HHCPOGCCGNF','MNALHHOLFGL',[],['CPBPJLLMKDB'],0x1813b9460)]
    for addr,spec,name,owner,ca,ma,va in specs:
        a=u[addr];need(a['kind']==6 and a['index']==spec and a['method']['name']==name and a['method']['owner']==owner and a['class_argument_types']==ca and a['method_argument_types']==ma and len(g[str(spec)])==1 and int(g[str(spec)][0]['pointer'],16)==va,'Exact original MethodSpec and native registration '+str(spec))
    callback=u['0x188878c50'];need(callback['kind']==3 and callback['method']['owner']=='TitleScreenManager' and callback['method']['name']=='NBDKIBMNLCA' and callback['method']['token']=='0x60008a1' and callback['method']['return']=='System.Void' and [x['type'] for x in callback['method']['parameters']]==['System.Boolean'],'Exact Action<bool> callback, not guessed event behavior')
    need(u['0x188732f68']['type']=='System.Action`1<System.Boolean>' and u['0x188803e70']['type']=='SingletonMonoBehaviour`1<LoadingScreen>','Exact allocated delegate and static singleton class')
    names=[('0x180ee7ce0','LoadingScreen','add_IsVisibleChangeEvent','System.Void',['System.Action`1<System.Boolean>']),('0x18454a5d0','UnityEngine.Vector3','get_zero','UnityEngine.Vector3',[]),('0x18317c7d0','UnityEngine.Quaternion','get_identity','UnityEngine.Quaternion',[]),('0x180ba9f30','RecRoom.AGVirtualKeyboard','ForceHideKeyboard','System.Void',['System.Boolean']),('0x1867680c0','MPAAIECKLGA','PNFLFFOAING','MNALHHOLFGL',[])]
    for addr,owner,name,ret,params in names:
        rows=direct[addr];need(len(rows)==1,'Unique typed direct target '+addr);m=rows[0];need(m['owner']==owner and m['name']==name and m['return']==ret and [x['type'] for x in m['parameters']]==params,'Exact typed direct application signature '+addr)
    for offset,name,typ in [(56,'keyboardPrefab','RecRoom.AGVirtualKeyboard'),(96,'KMNIAGFPHEN','RecRoom.AGVirtualKeyboard'),(144,'IBDKAJJPLGA','DCCDAPLPICN'),(152,'LIPCPJMCHDF','CPBPJLLMKDB')]:
        f=[f for f in fields if f['offset']==offset and f['native_type']['attributes']==1];need(len(f)==1 and f[0]['name']==name and f[0]['type']==typ,'Exact original field '+str(offset))
    return {'all_original_application_targets_bound':True,'all_four_touched_fields_bound':True,'callback_body_recovered':False}
def main():
    need(pin(JOINS)['sha256']==JOINS_SHA,'Frozen complete Awake typed evidence');p=json.loads(JOINS.read_bytes());need(p['CFG']['all556bytes_decoded'] and p['CFG']['all_reachable_edges_closed'],'Actual closed decoded complete method');need(pin(p['actual_decoder_receipt']['path'])==p['actual_decoder_receipt'] and pin(p['actual_decoded_output']['path'])==p['actual_decoded_output'],'Actual Root decoder proof unchanged')
    source=json.loads(Path(p['original_chain_input']['path']).read_bytes());row=source['methods'][0];code=bytes.fromhex(row['runtime_function']['bytes']);control=shape(code,int(row['native_pointer'],16));joins=typed(p)
    controls=[]
    for offset in [0,18,34,168,202,264,279,328,375,399,436,473,508,545,555]:
        change=bytearray(code);change[offset]^=1
        try:shape(bytes(change),int(row['native_pointer'],16))
        except (ValueError,struct.error):controls.append({'native_offset':offset,'rejected':True})
        else:raise ValueError('Changed original Awake instruction accepted '+str(offset))
    main=WS/'RR23/Assets/Scripts/Assembly-CSharp/TitleScreenManager.cs';before=main.read_bytes();old=b'\tprotected override void Awake()\r\n\t{\r\n\t}\r\n';new=b'''\tprotected override void Awake()\r
\t{\r
\t\tbase.Awake();\r
\t\tLoadingScreen.Instance.IsVisibleChangeEvent += NBDKIBMNLCA;\r
\t\tKMNIAGFPHEN = UnityEngine.Object.Instantiate<AGVirtualKeyboard>(keyboardPrefab, Vector3.zero, Quaternion.identity);\r
\t\tKMNIAGFPHEN.ForceHideKeyboard(true);\r
\t\tIBDKAJJPLGA = MPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<DCCDAPLPICN>(null);\r
\t\tLIPCPJMCHDF = MPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<CPBPJLLMKDB>(null);\r
\t}\r
'''
    need(before.count(old)==1,'Unique exact current protected override Awake stub');a=before.index(old);after=before[:a]+new+before[a+len(old):]
    out=ROOT/'Validation'/('TitleManagerAwakeSlice-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();target=out/'TitleScreenManager.cs';target.write_bytes(after)
    test='''Root-only next compile/effects; no Main application yet.

1. Compile this full current TitleScreenManager file via the exact current5095-source Unity2020 Windows MonoDev response with one candidate substitution. Inspect original base Awake call, LoadingScreen singleton/event/action<bool> callback, Instantiate<AGVirtualKeyboard>(same prefab,Vector3.zero,Quaternion.identity), ForceHideKeyboard(true), and exactly two separately evaluated CFHDLGEGDFD getters/resolutions with null name into the original two fields.
2. Exact source-body controlled test subject: base effect first; loading instance evaluation before delegate creation/subscription; no keyboard read on failing subscription; prefab/zero/identity evaluation order and copied Vector3 value; same instantiated keyboard stored before ForceHide(true); service getter called twice; exact generic DCCD/CPBP and null names; independent returns stored in original fields. Propagate each dependency failure at the original position, retaining prior effects/stores only.
3. Null loading instance must fail after delegate creation and before keyboard instantiation. Null instantiated keyboard is stored then fails before services. Null first/second container fails before its resolve/store; do not add skips/defaults. Callback target must remain original NBDKIBMNLCA(bool), never a guessed handler.
4. Preserve every byte outside Awake and all meta bytes. Base Singleton behavior, LoadingScreen Instance/event storage, callback body, keyboard implementation, service registrations/resolution and later Start remain independently incomplete until tested/restored. Passing this caller establishes no working title/login/gameplay.
'''
    plan=out/'ROOT_TEST_PLAN.txt';plan.write_text(test,encoding='utf-8')
    report={'schema':'original-complete-TitleScreenManager-Awake-source-caller-slice/v1','status':'complete_original_556B_Awake_caller_staged_full_file_binding_effects_UNVERIFIED','original_method':row['original'],'genuine_chain_input':p['original_chain_input'],'actual_decoder_receipt':p['actual_decoder_receipt'],'typed_evidence':pin(JOINS),'complete_native_shape':control,'typed_callee_field_proof':joins,'negative_controls':controls,'source':pin(main),'source_meta':pin(str(main)+'.meta'),'candidate':pin(target),'byte_edit':{'start':a,'length':len(old),'original_base64':base64.b64encode(old).decode(),'replacement_base64':base64.b64encode(new).decode()},'all_other_source_bytes_preserved':True,'all_original_meta_bytes_preserved':True,'current_UIFlowModel_checkpoint':pin(WS/'RR23/Assets/Scripts/Assembly-CSharp/RRUI/Data/TitleScreenFlowModel.cs'),'Root_test_plan':pin(plan),'callee_bodies_recovered_by_this_slice':False,'TitleScreenManager_Start_recovered':False,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'working_boot_title_login_or_gameplay_claimed':False,'producer':pin(Path(__file__))};receipt=out/'report.json';receipt.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(receipt),'candidate':pin(target),'all556bytes_closed':True,'negative_controls':len(controls),'Main_modified':False,'compiled':False}))
if __name__=='__main__':main()
