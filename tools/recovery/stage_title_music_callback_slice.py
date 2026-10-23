"""Stage the complete original music callback and its narrow proved leaf callers.

Data only. Original iterator MoveNext, audio-manager implementations and flow
initialization remain dependencies; this does not claim that music plays.
"""
from pathlib import Path
import base64,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_ogpeg_constructors import Decoder
from collect_nameserver_request_factory_native import fields
from collect_title_page_route_native import pin
from stage_title_page_route_slice import property_for
from prepare_title_music_dependencies_native import collect
import prepare_title_music_dependencies_native as scopes
JOIN=ROOT/'Validation/TitleMusicDependenciesTypedJoins-20261023T094823Z-a9adc265/report.json'
CALLER=ROOT/'Validation/TitleRemainingCallbacksTypedJoins-20261023T092100Z-73e7efb3/report.json'
TITLE=WS/'RR23/Assets/Scripts/Assembly-CSharp/TitleScreenManager.cs'
FLOW=WS/'RR23/Assets/Scripts/Assembly-CSharp/RRUI/Data/TitleScreenFlowModel.cs'
STATE=WS/'RR23/Assets/Scripts/Assembly-CSharp/GONBPKCPFNK.cs'

def predicate(code,va,index):
    d=Decoder(code,va);d.literal('40534883ec20');flag=d.relative('803d','00');d.literal('488bd9');loaded=d.short('75');usage=d.relative('488d0d');init=d.relative('e8');written=d.relative('c605','01');loaded_at=va+d.at;d.literal('488b83e80200004885c0');null=d.short('74')
    if index in (225456,225457):
        bounds=(17,34) if index==225456 else (54,55);d.literal('0fb748286683f9'+format(bounds[0],'02x'));high=d.short('73');d.literal('32c04883c4205bc3');high_at=va+d.at;d.literal('6683f9'+format(bounds[1],'02x')+'0f96c04883c4205bc3');need(high==high_at,'Unsigned lower-bound exit');semantic={'unsigned_range_inclusive':list(bounds),'state_reads':1}
    elif index==225458:
        d.literal('66837828380f94c04883c4205bc3');semantic={'equals':56,'state_reads':1}
    else:
        d.literal('0fb748286683f921');other=d.short('75');d.literal('b0014883c4205bc3');other_at=va+d.at;d.literal('6683f9340f94c04883c4205bc3');need(other==other_at,'Two exact interstitial alternatives');semantic={'one_of':[33,52],'state_reads':1}
    null_at=va+d.at;throw=d.relative('e8');d.literal('cc');d.end();need(loaded==loaded_at and null==null_at and flag==written and usage==0x188741758 and init==0x1806c01e0 and throw==0x1806c0390,'Exact field offset/raw-null exit/generic state usage');return semantic

def start(code,va):
    d=Decoder(code,va);d.literal('48895c2408574883ec20488bda488bf933d2');stop=d.relative('e8');d.literal('4533c0488bd3488bcf');run=d.relative('e8');d.literal('488d4f58488bd0488901488b5c24304883c4205f');barrier=d.relative('e9');d.end();need((stop,run,barrier)==(0x181ae3ac0,0x18316f900,0x1806bfd30),'Stop then same iterator StartCoroutine then exact handle field store');return {'ordered_effects':['MLOEPDOPGJD()','StartCoroutine(same IEnumerator)','store returned Coroutine in this+88'],'same_captured_iterator':True,'store_only_after_success':True}

def stop(code,va):
    d=Decoder(code,va);d.literal('48895c2408574883ec20');flag=d.relative('803d','00');d.literal('488bf9');loaded=d.short('75');usage=d.relative('488d0d');init=d.relative('e8');written=d.relative('c605','01');loaded_at=va+d.at;again=d.relative('488b0d');d.literal('f6813301000004');noinit=d.short('74');d.literal('83b9e000000000');done=d.short('75');cctor=d.relative('e8');before_stop=va+d.at;d.literal('33c9');audio=d.relative('e8');d.literal('488b57584885d2');empty=d.short('74');d.literal('4533c0488bcf');coroutine=d.relative('e8');d.literal('33d248c7475800000000488d4f58');barrier=d.relative('e8');end=va+d.at;d.literal('488b5c24304883c4205fc3');d.end();need(flag==written and loaded==loaded_at and usage==again==0x188790938 and init==0x1806c01e0 and noinit==done==before_stop and cctor==0x180640f10 and audio==0x180faf170 and coroutine==0x18316fe80 and barrier==0x1806bfd30 and empty==end,'Audio first, then fresh raw Coroutine null check, stop, clear only after stop succeeds');return {'ordered_effects':['AudioManager.StopMusic()','capture this.HEGLMMJABEN','raw null check','StopCoroutine(captured handle)','clear HEGLMMJABEN'],'audio_always_called':True,'stop_failure_preserves_handle':True}

def factory(code,va,index):
    d=Decoder(code,va);d.literal('48895c2408574883ec20');flag=d.relative('803d','00');d.literal('488bf9');loaded=d.short('75');usage=d.relative('488d0d');init=d.relative('e8');written=d.relative('c605','01');loaded_at=va+d.at;again=d.relative('488b0d');allocation=d.relative('e8');d.literal('4533c033d2488bc8488bd8');ctor=d.relative('e8');d.literal('4885db');null=d.short('74');d.literal('488d4b20488bd7488939');barrier=d.relative('e8');d.literal('488bc3488b5c24304883c4205fc3');null_at=va+d.at;throw=d.relative('e8');d.literal('cc');d.end();expected=0x188852220 if index==192562 else 0x1888524a8;need(flag==written and loaded==loaded_at and usage==again==expected and init==0x1806c01e0 and allocation==0x1806c0340 and ctor==0x180871950 and barrier==0x1806bfd30 and null==null_at and throw==0x1806c0390,'Exact iterator type, state0 ctor and same this capture at+32');return {'type_usage':hex(usage),'constructor_state':0,'captured_this_offset':32,'ctor_target':hex(ctor)}

def instance_size(v,ti):
    mr=v.raw(0x187f85ef0,128);table=v.u64(v.b,mr+104);entry=v.u64(v.b,v.raw(table+ti*8,8));raw=bytes(v.b[v.raw(entry,16):v.raw(entry,16)+16]);return {'entry_address':hex(entry),'bytes':raw.hex(),'values':list(struct.unpack('<Iiii',raw))}

def state_layout(v):
    generic=40403;closed=40405;child=40408;base=40397
    need(v.full_name(generic)=='GONBPKCPFNK' and v.full_name(closed)=='OOMEAMBGFPG' and v.full_name(child)=='MDEJADHJOEJ','Exact original state-machine hierarchy')
    need(v.type_info(generic)['parent_type']=='ILNJNAIHNJF' and v.type_info(closed)['parent_type']=='GONBPKCPFNK<OOMEAMBGFPG/JEGOKBPEODC>' and v.type_info(child)['parent_type']=='OOMEAMBGFPG','Exact closed class argument and original parent chain')
    base_types=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)=='ILNJNAIHNJF'];need(len(base_types)==1,'One exact state base');base=base_types[0]
    declared=fields(v,generic);types=[x['type'] for x in declared];need(types==['System.Collections.Generic.Dictionary`2<System.UInt32,T>','System.Boolean','ILNJNAIHNJF/DGKBCFAHNKA','System.UInt16','System.UInt16','System.UInt16','System.UInt16','ILNJNAIHNJF/HAMLJAHAGPF','ILNJNAIHNJF/HAMLJAHAGPF'],'Exact nine ordered generic fields')
    need(not [f for f in fields(v,base) if not f['native_type']['attributes']&0x10] and fields(v,closed)==[] and instance_size(v,base)['values']==[16,-1,0,0] and instance_size(v,closed)['values']==[64,-1,0,0],'Exact16-byte base with no instance fields and64-byte fieldless closed specialization')
    td=v.row('typeDefinitions',generic,88);need(((v.u32(v.m,td+80)>>6)&15)==0 and ((v.u32(v.m,td+80)>>10)&1)==1,'Original default packing')
    widths=[8,1,8,2,2,2,2,8,8];aligns=[8,1,8,2,2,2,2,8,8];offset=16;offsets=[]
    for width,align in zip(widths,aligns):offset=(offset+align-1)&~(align-1);offsets.append(offset);offset+=width
    need(offset==64 and offsets==[16,24,32,40,42,44,46,48,56],'Official sequential IL2CPP FieldLayout reproduces closed native size and state offset40')
    need(declared[3]['name']=='<MFHOAFKBLGN>k__BackingField' and declared[3]['token']=='0x400b505','Exact UInt16 backing field identity')
    method=v.method_info(262868);prop=property_for(v,method);need(method['owner_index']==generic and method['name']=='DAOIFPKEGOG' and method['return']=='System.UInt16' and not method['parameters'] and prop['name']=='CPDFJCCALIA','Exact original state getter MethodDef/PropertyDef')
    raw=bytes(v.b[v.raw(0x1822d04c0,5):v.raw(0x1822d04c0,5)+5]);need(raw==bytes.fromhex('0fb74128c3'),'Entire branchless original getter is UInt16 load this+40 and ret')
    sizes={str(i):instance_size(v,i) for i in [base,closed,child]};layout_source=WS/'Tools/Editors/2020.3.33f1/Editor/Data/il2cpp/libil2cpp/metadata'
    return {'generic_type':v.type_info(generic),'closed_type':v.type_info(closed),'derived_type':v.type_info(child),'ordered_declared_fields':declared,'calculated_closed_offsets':offsets,'native_instance_sizes':sizes,'original_getter':method,'original_property':prop,'generic_registered_pointer':'0x1822d04c0','exact_leaf_bytes':raw.hex(),'source_field_name':'MFHOAFKBLGN','field_export_rule':'Exact enclosed original CompilerGenerated backing-field identifier; original-provider/full-compile binding still required','official_layout_sources':[pin(layout_source/'FieldLayout.cpp'),pin(layout_source/'FieldLayout.h')]}

def edit(source,old,new,owner,member):
    need(source.count(old)==1,'Exactly one current stub '+owner+'.'+member);return {'owner':owner,'member':member,'start':source.index(old),'length':len(old),'original_base64':base64.b64encode(old).decode(),'replacement_base64':base64.b64encode(new).decode()}

def block(text):return text.replace('\n','\r\n').encode()

def main():
    need(pin(JOIN)['sha256']=='9e8f947b53a902eedda1b5142086282927c4eff0ed6f63c0cacf5eb3217ded85' and pin(CALLER)['sha256']=='63b0d9aae7dc0e692432485ae0f8afae6ca3866574a755e6825be1f93fb51c0a','Frozen complete native scopes/CFG/typed joins');need(pin(TITLE)['sha256']=='913efec0b61d45697af166e5de48eae9be20833a39b142be820bf2e983581c04','Current applied prior title callbacks')
    data=json.loads(JOIN.read_bytes());caller=json.loads(CALLER.read_bytes());shapes=[];controls=[]
    for report in [data,caller]:
        need(pin(report['actual_decoder_receipt']['path'])==report['actual_decoder_receipt'] and pin(report['actual_decoded_output']['path'])==report['actual_decoded_output'],'Actual Root inert-decoder outputs pinned')
    for row in data['callbacks']:
        index=row['original_method']['index'];raw=bytes.fromhex(row['native_region']['bytes']);va=0x180000000+row['native_region']['start_rva'];fn=(lambda b,a:predicate(b,a,index)) if index>200000 else start if index==192559 else stop if index==192560 else (lambda b,a:factory(b,a,index));shapes.append({'original':row['original_method'],'semantics':fn(raw,va)})
        # Full literal recognizers reject changes to instruction bytes, exact
        # targets and branch/receiver/store ordering. Runtime init flag identity
        # is compiler support; its actual address is retained in input evidence.
        for offset in range(len(raw)):
            changed=bytearray(raw);changed[offset]^=1
            try:fn(bytes(changed),va)
            except (ValueError,IndexError):controls.append({'index':index,'byte_offset':offset,'rejected':True})
            else:
                # Four literal init-flag address bytes can change identically
                # only if both operands change; a single-byte change cannot.
                raise ValueError('Native mutation accepted '+str((index,offset)))
    src=json.loads(Path(data['original_region_input']['path']).read_bytes());paths=[Path(x['path']) for x in src['original_inputs']]
    for x in src['original_inputs']:need(pin(x['path'])==x,'Exact genuine original authority')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);layout=state_layout(v);ctorrows=[]
        for ti,token in [(29516,0x060008b9),(29517,0x060008bf)]:
            method=v.find_method(v.full_name(ti),token);need(v.method_pointer(method)==0x180871950 and method['parameters'][0]['type']=='System.Int32','Allocation type uniquely selects its original shared ctor');fs=fields(v,ti);need([x['offset'] for x in fs]==[16,24,32] and fs[0]['name']=='<>1__state' and fs[2]['name']=='<>4__this','Exact original iterator state/capture fields');ctorrows.append({'original':method,'fields':fs})
        # Collect complete pdata scope for both exact aliases using the same
        # full-table chain/start guard as the eight decoded dependencies.
        oldtargets=scopes.TARGETS;scopes.TARGETS=[(r['original']['owner'],int(r['original']['token'],16),r['original']['index'],'.ctor','System.Void',['System.Int32']) for r in ctorrows]
        try:ctor_scopes=collect(v)
        finally:scopes.TARGETS=oldtargets
        for row in ctor_scopes:
            code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);d=Decoder(code,va);d.literal('48895c2408574883ec208bfa488bd933d2');base=d.relative('e8');d.literal('897b10488b5c24304883c4205fc3');d.end();need(base==0x1806f84d0 and len(code)==36,'Complete original shared ctor: Object base ctor before state store')
        objecttypes=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)=='System.Object'];need(len(objecttypes)==1,'One original System.Object');td=v.row('typeDefinitions',objecttypes[0],88);first=v.i32(v.m,td+36);count=v.u16(v.m,td+64);objectctors=[v.method_info(i) for i in range(first,first+count) if v.method_info(i)['name']=='.ctor' and not v.method_info(i)['parameters']];need(len(objectctors)==1 and v.method_pointer(objectctors[0])==0x1806f84d0,'Exact original System.Object parameterless base constructor')
        # Pointer-equivalent StartCoroutine_Auto is retained explicitly; source
        # chooses public StartCoroutine(IEnumerator), no unique-source-name claim.
        startrow=next(x for x in data['callbacks'] if x['original_method']['index']==192559);aliases=startrow['direct_original_application_targets']['0x18316f900'];need([x['name'] for x in aliases]==['StartCoroutine','StartCoroutine_Auto'] and all(x['owner']=='UnityEngine.MonoBehaviour' and x['return']=='UnityEngine.Coroutine' and [p['type'] for p in x['parameters']]==['System.Collections.IEnumerator'] for x in aliases),'Only exact native-equivalent public iterator coroutine overloads')
    title=TITLE.read_bytes();flow=FLOW.read_bytes();state=STATE.read_bytes();edits={str(TITLE):[],str(FLOW):[],str(STATE):[]};members=[]
    def add(path,old,new,owner,name):
        before={str(TITLE):title,str(FLOW):flow,str(STATE):state}[str(path)];e=edit(before,block(old),block(new),owner,name);edits[str(path)].append(e);members.append({'owner':owner,'name':name,'replacement':new})
    add(TITLE,'\tprivate void NDENAIFEGGC(IEnumerator KNMNCHEEHEI)\n\t{\n\t}\n','\tprivate void NDENAIFEGGC(IEnumerator KNMNCHEEHEI)\n\t{\n\t\tMLOEPDOPGJD();\n\t\tHEGLMMJABEN = StartCoroutine(KNMNCHEEHEI);\n\t}\n','TitleScreenManager','NDENAIFEGGC')
    add(TITLE,'\tprivate void MLOEPDOPGJD()\n\t{\n\t}\n','\tprivate void MLOEPDOPGJD()\n\t{\n\t\tAudioManager.StopMusic();\n\t\tCoroutine coroutine = HEGLMMJABEN;\n\t\tif (coroutine != null)\n\t\t{\n\t\t\tStopCoroutine(coroutine);\n\t\t\tHEGLMMJABEN = null;\n\t\t}\n\t}\n','TitleScreenManager','MLOEPDOPGJD')
    for name,typ in [('KJNOGCGEIHD','BBOMFKCKKEP'),('MDLLPIFKLJO','EPCGHFICLMA')]:
        add(TITLE,'\tprivate IEnumerator '+name+'()\n\t{\n\t\treturn null;\n\t}\n','\tprivate IEnumerator '+name+'()\n\t{\n\t\treturn new '+typ+'(0)\n\t\t{\n\t\t\t_003C_003E4__this = this\n\t\t};\n\t}\n','TitleScreenManager',name)
        add(TITLE,'\t\tpublic '+typ+'(int _003C_003E1__state)\n\t\t{\n\t\t}\n','\t\tpublic '+typ+'(int _003C_003E1__state)\n\t\t{\n\t\t\tthis._003C_003E1__state = _003C_003E1__state;\n\t\t}\n','TitleScreenManager/'+typ,'.ctor')
    music='''\tprivate void NMJIFHLPFNP(float OKBAJEAPIHG)
\t{
\t\tif (flowModel == null)
\t\t\treturn;
\t\tif (flowModel.IsInInterstitialState)
\t\t\treturn;
\t\tAudioClip currentMusic = AudioManager.CurrentMusicAudioClip();
\t\tif (flowModel.IsInChatState || flowModel.IsInFeedState)
\t\t{
\t\t\tif (currentMusic != null)
\t\t\t\tMLOEPDOPGJD();
\t\t\treturn;
\t\t}
\t\tif (flowModel.IsInAccountCreationState)
\t\t{
\t\t\tRecRoomAudioClip music = accountCreationMusic;
\t\t\tif (HEGLMMJABEN != null && currentMusic == (music == null ? null : music.audioClip))
\t\t\t\treturn;
\t\t\tNDENAIFEGGC(MDLLPIFKLJO());
\t\t\treturn;
\t\t}
\t\tif (PlatformManager.Instance.CurrentUnityLauncher == (KDHPMLNMNNO)1)
\t\t{
\t\t\tif (currentMusic != null)
\t\t\t\tMLOEPDOPGJD();
\t\t\treturn;
\t\t}
\t\tRecRoomAudioClip titleMusic = titleScreenMusic;
\t\tif (HEGLMMJABEN != null && currentMusic == (titleMusic == null ? null : titleMusic.audioClip))
\t\t\treturn;
\t\tNDENAIFEGGC(KJNOGCGEIHD());
\t}
'''
    add(TITLE,'\tprivate void NMJIFHLPFNP(float OKBAJEAPIHG)\n\t{\n\t}\n',music,'TitleScreenManager','NMJIFHLPFNP')
    for name,body in [('IsInAccountCreationState','ushort state = BGBIFFLGANM.CPDFJCCALIA;\n\t\treturn state >= 17 && state <= 34;'),('IsInChatState','ushort state = BGBIFFLGANM.CPDFJCCALIA;\n\t\treturn state >= 54 && state <= 55;'),('IsInFeedState','return BGBIFFLGANM.CPDFJCCALIA == 56;'),('IsInInterstitialState','ushort state = BGBIFFLGANM.CPDFJCCALIA;\n\t\treturn state == 33 || state == 52;')]:
        old=('public bool '+name+'\n{\nget \t\t{\r\n\t\t\treturn false;\r\n\t\t}\r\n\n}').encode();new=('public bool '+name+'\n{\nget \t\t{\r\n\t\t\t'+body.replace('\n\t\t','\r\n\t\t\t')+'\r\n\t\t}\r\n\n}').encode();need(flow.count(old)==1,'Exact mixed-line-ending original predicate stub '+name);edits[str(FLOW)].append(edit(flow,old,new,'RRUI.Data.TitleScreenFlowModel',name));members.append({'owner':'RRUI.Data.TitleScreenFlowModel','name':name,'replacement':new.decode()})
    prefix=b'public ushort CPDFJCCALIA\n{\nget \t{\r\n\t\treturn ';need(state.count(prefix)==1,'One exact generic state property');at=state.index(prefix)+len(prefix);need(state[at:at+3]==b'0;\r','Exact current state0 stub');edits[str(STATE)].append({'owner':'GONBPKCPFNK<T>','member':'get_CPDFJCCALIA','start':at,'length':1,'original_base64':base64.b64encode(b'0').decode(),'replacement_base64':base64.b64encode(b'this.MFHOAFKBLGN').decode()})
    out=ROOT/'Validation'/('TitleMusicCallbackSlice-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();files=[]
    for path in [TITLE,FLOW,STATE]:
        before=path.read_bytes();after=before;rows=edits[str(path)];need(all(a['start']+a['length']<=b['start'] for a,b in zip(sorted(rows,key=lambda e:e['start']),sorted(rows,key=lambda e:e['start'])[1:])),'Nonoverlapping exact original spans')
        for e in sorted(rows,key=lambda e:e['start'],reverse=True):after=after[:e['start']]+base64.b64decode(e['replacement_base64'])+after[e['start']+e['length']:]
        target=out/path.name;target.write_bytes(after);files.append({'source':pin(path),'source_meta':pin(str(path)+'.meta'),'candidate':pin(target),'byte_edits':rows})
    callback=next(x for x in caller['callbacks'] if x['original_method']['index']==192561);need(callback['CFG']['all_original_bytes_decoded'] and callback['CFG']['all_nonterminal_edges_closed'] and len(bytes.fromhex(callback['native_region']['bytes']))==988,'Complete original988B caller with all branch regions')
    report={'schema':'complete-original-title-music-callback-and-narrow-leaf-source-slice/v1','status':'twelve_original_members_staged_full_binding_effects_UNVERIFIED','original_music_988B_join_proof':pin(CALLER),'eight_dependency_join_proof':pin(JOIN),'original_inputs':src['original_inputs'],'eight_complete_native_shapes':shapes,'native_single_byte_negative_controls':controls,'state_getter_field_layout':layout,'iterator_constructor_originals':ctorrows,'iterator_ctor_complete_native_scopes':ctor_scopes,'StartCoroutine_pointer_equivalent_original_aliases':aliases,'source_choice':'StartCoroutine(IEnumerator) is the exact public native-equivalent alias; original source spelling is not claimed','files':files,'staged_member_count':12,'988B_caller_manual_typed_semantics_review_pending':True,'caller_inline_equivalences':{'interstitial_getter':'same freshly read flowModel/state33|52 before CurrentMusic','chat_feed_getters':'separate field/state reads with short-circuit54..55 then56','factory_calls':'exact allocation/ctor0/capture this sequences, recovered helpers retain original reads','argument_float_unused':True,'Coroutine_and_RecRoomAudioClip_raw_null_checks':True,'AudioClip_comparisons_use_genuine_Unity_Object_operators':True,'selected_music_reference_captured_before_handle_check':True},'remaining_runtime_dependencies':['TitleScreenModel initialization/state transitions and underlying field writes','TitleScreenManager iterator MoveNext/Current/Dispose bodies','RecRoom.Audio.AudioManager CurrentMusicAudioClip/StopMusic and playback bodies','PlatformManager/Singleton initialization and launcher getter','matching Unity engine coroutine and object-operator behavior'],'all_bytes_outside_twelve_exact_current_stub_spans_preserved':True,'all_script_metas_unchanged':True,'Main_modified':False,'compiler_Unity_game_network_executed':False,'music_or_working_title_login_claimed':False,'producer':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'files':[x['candidate'] for x in files],'member_count':12,'native_mutation_controls':len(controls),'Main_modified':False}))
if __name__=='__main__':main()
