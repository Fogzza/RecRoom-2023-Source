"""Stage two original title/login source bodies from existing native evidence.

No Main writes, compilation, target invocation, Unity or network. This proves
caller-level control flow and typed joins; it does not recover their callees.
"""
from pathlib import Path
import base64, copy, datetime as dt, hashlib, json, re, struct, uuid

HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
EVIDENCE=ROOT/'Validation/StartupNativeLeaves-20261022T134300Z'
MAIN=WS/'RR23/Assets/Scripts/Assembly-CSharp'
def need(v,m):
    if not v:raise ValueError(m)
def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def pin(p):
    p=Path(p).resolve(strict=True);return {'path':str(p),'bytes':p.stat().st_size,'sha256':sha(p)}
def save(p,v):
    with p.open('x',encoding='utf-8') as f:json.dump(v,f,indent=2);f.write('\n')
def native_span(path,address,size):
    # Read PE headers and this already-recorded code span only, no loading.
    with path.open('rb') as f:
        dos=f.read(64);need(dos[:2]==b'MZ','Original PE signature')
        f.seek(struct.unpack_from('<I',dos,60)[0]);pe=f.read(24)
        need(pe[:4]==b'PE\0\0' and struct.unpack_from('<H',pe,4)[0]==0x8664,'Original x64 PE')
        count=struct.unpack_from('<H',pe,6)[0];optional=f.read(struct.unpack_from('<H',pe,20)[0])
        need(struct.unpack_from('<H',optional)[0]==0x20b,'Original PE32+')
        base=struct.unpack_from('<Q',optional,24)[0];rva=address-base;hits=[]
        for _ in range(count):
            row=f.read(40);virtual,va,raw,offset=struct.unpack_from('<IIII',row,8)
            if va<=rva and rva+size<=va+raw:hits.append(offset+rva-va)
        need(len(hits)==1,'Unique raw-backed original method span')
        f.seek(hits[0]);value=f.read(size);need(len(value)==size,'Complete recorded native method bytes')
        return value
def field(proof,owner,offset):
    types=[r for r in proof['original_owner_field_layouts'] if r['original_type']['name']==owner]
    need(len(types)==1,'Exact original owner layout')
    rows=[r for r in types[0]['fields'] if r['registered_offset']==offset]
    need(len(rows)==1,'Unique registered original field offset');return rows[0]
def target(proof,address):
    rows=[r for r in proof['native_target_registration_matches'] if r['native_target']==address]
    need(len(rows)==1 and not rows[0]['ambiguous_identity'],'Unique original call registration required');return rows[0]
def validate(getter,go,proof,decoded):
    need(getter['original']['owner']=='TitleScreenManager' and getter['original']['name']=='get_FlowModel'
         and getter['original']['token']=='0x600089b' and getter['original']['return']=='AIOCIBMFJEJ'
         and getter['native_pointer']=='0x18075c700','Exact original FlowModel signature and entry')
    raw=bytes.fromhex(getter['runtime_function']['bytes'])
    need(raw[:5]==bytes.fromhex('488b4130c3') and raw[5:16]==b'\xcc'*11,'Closed5-byte field-load/ret leaf, padding bounds before next entry')
    f=field(proof,'TitleScreenManager',48)
    need(f['name']=='flowModel' and f['type']=='RRUI.Data.TitleScreenFlowModel' and f['original_token']=='0x400063a','Native+0x30 joins exact serialized flowModel field')
    need(go['original']['owner']=='RRUI.Data.TitleScreenFlowModel' and go['original']['name']=='GoToLogin'
         and go['original']['token']=='0x60089a7' and go['original']['return']=='System.Void' and not go['original']['parameters']
         and go['native_pointer']=='0x181ad5950','Exact original GoToLogin signature')
    native=bytes.fromhex(go['runtime_function']['bytes']);need(len(native)==117,'Exact117-byte complete recorded GoToLogin range')
    ins=decoded[go['original']['index']]['instructions'];by_ip={r['ip']:r for r in ins};lo=int(go['native_pointer'],16);hi=lo+len(native)
    need(len(by_ip)==len(ins) and min(by_ip)==lo and max(by_ip)<hi,'All decoded instructions in this method')
    for row in ins:
        if row['flow'] in ('ConditionalBranch','UnconditionalBranch'):
            need(row['operands'] and lo<=row['operands'][0]['target']<hi,'Every native branch target closed inside GoToLogin')
    required={0x181ad5983:'call 0000000184579E50h',0x181ad598b:'test rax,rax',0x181ad598e:'je short 0000000181AD59B4h',
              0x181ad5990:'mov rcx,[rbx+1E0h]',0x181ad5997:'test rcx,rcx',0x181ad599a:'je short 0000000181AD59BFh',
              0x181ad599e:'call 0000000180DADC70h',0x181ad59a3:'xor r9d,r9d',0x181ad59a6:'xor r8d,r8d',
              0x181ad59a9:'mov rdx,rax',0x181ad59ac:'mov rcx,rdi',0x181ad59af:'call 0000000181DA60F0h',
              0x181ad59be:'ret',0x181ad59bf:'call 00000001806C0390h',0x181ad59c4:'int3'}
    for ip,text in required.items():need(by_ip[ip]['text']==text,'Exact GoToLogin branch/register/call shape changed')
    lf=field(proof,'RRUI.Data.TitleScreenFlowModel',480)
    need(lf['name']=='loginPage' and lf['type']=='RRUI.Data.TitleScreenFlowModel/TitleScreenPage' and lf['original_token']=='0x4004eea','Native+0x1E0 is exact loginPage field')
    browser=target(proof,'0x184579e50');need(browser['direct_count']==0 and browser['generic_count']==1,'Unique BrowserModel getter MethodSpec')
    gm=browser['generic_methods'][0];m=gm['method']
    need(gm['method_spec']==283318 and gm['class_arguments']==['RRUI.Data.RRUIModel/AAHMEOHNDKA'] and not gm['method_arguments']
         and m['owner']=='RRUI.Data.RRUIModel`1' and m['name']=='get_BrowserModel' and m['token']=='0x60009a3'
         and m['image']=='RecRoom.RRUI.Data.Runtime.dll' and m['return']=='RRUI.Data.BrowserModel','Exact inherited BrowserModel typed getter')
    route=target(proof,'0x180dadc70');rm=route['direct_methods'][0]
    need(route['direct_count']==1 and route['generic_count']==0 and rm['owner']=='RRUI.Data.TitleScreenFlowModel/TitleScreenPage'
         and rm['name']=='get_Route' and rm['token']=='0x6008ab5' and rm['return']=='RRUI.Navigation.Route' and not rm['parameters'],'Exact loginPage.Route getter call')
    navigate=target(proof,'0x181da60f0');nm=navigate['direct_methods'][0]
    need(navigate['direct_count']==1 and navigate['generic_count']==0 and nm['owner']=='RRUI.Data.BrowserModel'
         and nm['name']=='GoTo' and nm['token']=='0x600081a' and nm['image']=='RecRoom.RRUI.Data.Runtime.dll'
         and [r['type'] for r in nm['parameters']]==['RRUI.Navigation.Route','System.Boolean'],'Exact BrowserModel.GoTo(Route,bool) target')
    return {'flowModel_field':f,'loginPage_field':lf,'BrowserModel_getter':browser,'Route_getter':route,'BrowserModel_GoTo':navigate}
def replace_body(path,old,new,token):
    data=path.read_bytes();need(data.count(old)==1,'Unique exact current stub source span')
    start=data.index(old);replacement=data[:start]+new+data[start+len(old):]
    return data,replacement,{'start':start,'length':len(old),'original_base64':base64.b64encode(old).decode(),
                            'replacement_base64':base64.b64encode(new).decode(),'original_method_token':token}
def main():
    inventory_path=EVIDENCE/'login-action-disassembly-input.json';proof_path=EVIDENCE/'login-action-dependencies.json';decoded_path=EVIDENCE/'login-action-instructions-v2.jsonl';audit_path=EVIDENCE/'report.json'
    inventory=json.loads(inventory_path.read_bytes());proof=json.loads(proof_path.read_bytes());audit=json.loads(audit_path.read_bytes())
    need(proof['schema']=='original-login-action-CFG-and-dependencies/v1' and proof['inventory']['sha256']==sha(inventory_path)
         and proof['disassembly']['sha256']==sha(decoded_path),'Existing original evidence chain pins')
    entries={r['original']['index']:r for r in inventory['methods']};decoded={r['native_method_index']:r for r in map(json.loads,decoded_path.read_text().splitlines())}
    getter,go=entries[192546],entries[225582];joins=validate(getter,go,proof,decoded)
    original=next(Path(r['path']) for r in proof['inputs'] if Path(r['path']).name=='GameAssembly.dll')
    spans=[]
    for row in (getter,go):
        recorded=bytes.fromhex(row['runtime_function']['bytes']);data=native_span(original,int(row['native_pointer'],16),len(recorded))
        need(data==recorded and hashlib.sha256(data).hexdigest()==row['runtime_function']['sha256'],'Recorded original code span still exact')
        spans.append({'method_index':row['original']['index'],'address':row['native_pointer'],'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest()})
    controls=[]
    for name in ['wrong_getter_field_offset','wrong_loginPage_offset','wrong_BrowserModel_MethodSpec','wrong_Route_target_type','wrong_GoTo_second_parameter','open_GoToLogin_branch','changed_force_argument']:
        g=copy.deepcopy(getter);p=copy.deepcopy(proof);d=copy.deepcopy(decoded)
        if name=='wrong_getter_field_offset':g['runtime_function']['bytes']='488b4128c3'+g['runtime_function']['bytes'][10:]
        elif name=='wrong_loginPage_offset':field(p,'RRUI.Data.TitleScreenFlowModel',480)['name']='loadingScreenPage'
        elif name=='wrong_BrowserModel_MethodSpec':target(p,'0x184579e50')['generic_methods'][0]['method_spec']=1
        elif name=='wrong_Route_target_type':target(p,'0x180dadc70')['direct_methods'][0]['return']='System.String'
        elif name=='wrong_GoTo_second_parameter':target(p,'0x181da60f0')['direct_methods'][0]['parameters'][1]['type']='System.Int32'
        elif name=='open_GoToLogin_branch':next(r for r in d[225582]['instructions'] if r['ip']==0x181ad598e)['operands'][0]['target']=0x181ad6000
        else:next(r for r in d[225582]['instructions'] if r['ip']==0x181ad59a6)['text']='mov r8d,1'
        try:validate(g,go,p,d)
        except (ValueError,KeyError):controls.append({'name':name,'rejected':True})
        else:raise ValueError('Typed source-boundary negative control accepted')
    manager=MAIN/'TitleScreenManager.cs';flow=MAIN/'RRUI/Data/TitleScreenFlowModel.cs'
    old=b'get \t{\r\n\t\treturn null;\r\n\t}\r\n';new=b'get \t{\r\n\t\treturn flowModel;\r\n\t}\r\n'
    # Pin the property wrapper as well as the unique selected getter body.
    raw=manager.read_bytes();marker=b'public AIOCIBMFJEJ FlowModel\n{\n'+old+b'\n}\n'
    need(raw.count(marker)==1,'Current exact FlowModel property source boundary')
    start=raw.index(marker)+marker.index(old);md=raw[:start]+new+raw[start+len(old):]
    me={'start':start,'length':len(old),'original_base64':base64.b64encode(old).decode(),'replacement_base64':base64.b64encode(new).decode(),'original_method_token':'0x0600089B'}
    oldgo=b'\t\tpublic void GoToLogin()\r\n\t\t{\r\n\t\t}\r\n'
    newgo=b'\t\tpublic void GoToLogin()\r\n\t\t{\r\n\t\t\tvar browser = BrowserModel;\r\n\t\t\tif (System.Object.ReferenceEquals(browser, null))\r\n\t\t\t\treturn;\r\n\t\t\tbrowser.GoTo(loginPage.Route, false);\r\n\t\t}\r\n'
    _,fd,fe=replace_body(flow,oldgo,newgo,'0x060089A7')
    out=ROOT/'Validation'/('TitleLoginTransitionSlice-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    sources=[]
    for path,data,edit in [(manager,md,me),(flow,fd,fe)]:
        relative=path.relative_to(MAIN);dst=out/'Sources'/relative;dst.parent.mkdir(parents=True,exist_ok=True);dst.write_bytes(data)
        before=path.read_bytes();after=dst.read_bytes();a=edit['start'];n=edit['length'];replacement=base64.b64decode(edit['replacement_base64'])
        need(before[:a]==after[:a] and before[a+n:]==after[a+len(replacement):],'Every byte outside exact chosen method span preserved')
        sources.append({'source':pin(path),'source_meta':pin(str(path)+'.meta'),'candidate':pin(dst),'byte_edits':[edit],'all_other_source_bytes_equal':True})
    held=[]
    for name in ('Awake','Start'):
        row=next(r for r in audit['critical_callback_inventory'] if r['original']['owner']=='TitleScreenManager' and r['original']['name']==name)
        held.append({'original':row['original'],'native_pointer':row['native_pointer'],'recorded_native_region_bytes':len(bytes.fromhex(row['native_region']['bytes'])),'scope':row['native_region']['scope'],'status':'NOT_STAGED','reason':'Existing evidence records an entry runtime-function only; Awake ends in an external conditional branch and no complete typed-call/tail closure is recorded for either method.'})
    held.append({'original':entries[225575]['original'],'native_pointer':entries[225575]['native_pointer'],'status':'NOT_STAGED','reason':'ManuallyLogin caller CFG exists, but typed interface-slot3/4 promise dispatch, helper/callback body semantics and float literal0x186F302B8 remain unresolved by this slice. No approximate credential/request flow accepted.'})
    testplan='''# Minimal behavior plan for the title/login slice\n\nNo compile or behavior test has run for these candidates.\n\n1. Compile both full candidate files in an isolated copy against the matching Unity2020.3.33f1/recovered assembly references. Verify the selected getter binds to the serialized flowModel field and the GoToLogin call binds to the original inherited BrowserModel getter, TitleScreenPage.Route getter and BrowserModel.GoTo(Route,bool) signatures.\n2. Use the actual compiled bodies in a local effect fixture with controlled dependencies and no network. FlowModel must return the exact injected interface-compatible object and preserve null.\n3. GoToLogin with a CLR-null browser must return without evaluating loginPage.Route or invoking GoTo. With a nonnull browser, evaluate Route exactly once and invoke GoTo with that same Route reference and false. A null loginPage must produce a normal NullReferenceException before GoTo. Use reference-null semantics, not Unity Object equality.\n4. Recheck byte edits and original source/meta pins; every other method remains unchanged.\n\n## Explicit blockers\n\nTitleScreenPage.Route still returns null in current Main source. BrowserModel getter/navigation are typed callees but their bodies are not recovered or verified by this slice. TitleScreenManager Awake/Start and ManuallyLogin are not staged. BootSequence's current Awake, Start, BeginPlatformLogin, EndPlatformLogin and LaunchGame methods remain outside this candidate. Service-container foundation and nameserver request/certificate prerequisites are separately owned. Passing this slice establishes neither a working title screen nor authentication, room join, dorm loading or a playable client.\n'''
    (out/'BEHAVIOR_TEST_PLAN.md').write_text(testplan,encoding='utf-8')
    report={'schema':'original-native-title-login-transition-source-slice/v1','status':'two_closed_native_callers_staged_CSharp_binding_and_behavior_UNVERIFIED','candidate_method_count':2,'methods':[getter['original'],go['original']],'typed_joins':joins,'original_native_spans_revalidated':spans,'recorded_original_inputs':proof['inputs'],'original_entire_GameAssembly_file_rehashed_by_this_slice':False,'evidence':[pin(p) for p in (inventory_path,decoded_path,proof_path,audit_path)],'sources':sources,'negative_controls':controls,'held_methods':held,'explicit_unrecovered_callees':[{'method':'RRUI.Data.RRUIModel<T>.get_BrowserModel','original_token':'0x060009A3','image':'RecRoom.RRUI.Data.Runtime.dll','body_verified_by_slice':False},{'method':'RRUI.Data.TitleScreenFlowModel.TitleScreenPage.get_Route','original_token':'0x06008AB5','current_source_behavior':'returns null','body_verified_by_slice':False},{'method':'RRUI.Data.BrowserModel.GoTo(Route,bool)','original_token':'0x0600081A','image':'RecRoom.RRUI.Data.Runtime.dll','body_verified_by_slice':False}],'compiler_runtime_support_note':'IL2CPP metadata initialization and compiler null-reference support are not retranscribed as game methods. Managed property dereference retains null failure; Object.ReferenceEquals preserves the native raw browser null test.','BootSequence_source':pin(MAIN/'BootSequence.cs'),'test_plan':pin(out/'BEHAVIOR_TEST_PLAN.md'),'Main_or_meta_modified':False,'compiler_or_Unity_or_game_or_network_launched':False,'working_boot_login_room_or_dorm_claimed':False}
    save(out/'report.json',report);print(json.dumps({'report':pin(out/'report.json'),'candidate_methods':2,'negative_controls':len(controls),'sources':[r['candidate'] for r in sources],'Main_modified':False,'compiled':False}))
if __name__=='__main__':main()
