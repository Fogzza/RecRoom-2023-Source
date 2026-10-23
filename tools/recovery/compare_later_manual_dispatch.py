"""Official later declaration and exact original ABI evidence, comparison only."""
import datetime as dt,hashlib,json,urllib.request,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';BASE='https://api.github.com/repos/rlabrecque/Steamworks.NET';NAME='SteamAPI_ManualDispatch_GetAPICallResult';out=ROOT/'Validation'/('ManualDispatchComparison-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
def get(url,limit=1024*1024):
 with urllib.request.urlopen(urllib.request.Request(url,headers={'User-Agent':'OriginalRecoverySourceAudit'}),timeout=20) as r:data=r.read(limit+1)
 if len(data)>limit:raise ValueError('Bounded official source fetch exceeded')
 return data
tag=get(BASE+'/git/ref/tags/15.0.0',262144);(out/'tag.json').write_bytes(tag);obj=json.loads(tag)['object']
for depth in range(4):
 if obj['type']=='commit':break
 if obj['type']!='tag' or not obj['url'].startswith(BASE+'/git/tags/'):raise ValueError('Unsupported official Git object')
 annotation=get(obj['url'],262144);(out/('annotated-tag-'+str(depth)+'.json')).write_bytes(annotation);obj=json.loads(annotation)['object']
if obj['type']!='commit':raise ValueError('Official Git tag chain exceeded')
commit=obj['sha'];tree=get(BASE+'/git/trees/'+commit+'?recursive=1',4*1024*1024);(out/'tree.json').write_bytes(tree);rows=json.loads(tree)
if rows.get('truncated'):raise ValueError('Incomplete official tree')
files=[x for x in rows['tree']if x['type']=='blob'and x['path']=='Plugins/Steamworks.NET/autogen/NativeMethods.cs']
if len(files)!=1:raise ValueError('Later official exact source path missing')
f=files[0];url='https://raw.githubusercontent.com/rlabrecque/Steamworks.NET/'+commit+'/'+f['path'];source=get(url);gitsha=hashlib.sha1(b'blob '+str(len(source)).encode()+b'\0'+source).hexdigest()
if gitsha!=f['sha']or len(source)!=f['size']:raise ValueError('Official later Gitblob verification failed')
(out/'NativeMethods-15.0.0.cs').write_bytes(source);lines=source.decode('utf-8-sig').splitlines();hits=[i for i,x in enumerate(lines)if 'extern bool '+NAME+'(' in x]
if len(hits)!=1:raise ValueError('Later exact method declaration not unique')
i=hits[0];context='\n'.join(lines[i-2:i+1]);needles=['[DllImport(NativeLibraryName, EntryPoint = "'+NAME+'", CallingConvention = CallingConvention.Cdecl)]','[return: MarshalAs(UnmanagedType.I1)]','public static extern bool '+NAME+'(HSteamPipe hSteamPipe, SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed);']
if [x.strip()for x in lines[i-2:i+1]]!=needles:raise ValueError('Later source declaration changed')
proofroot=ROOT/'Validation/AllPInvokeBindings-20261022T123600Z';inventory=json.loads((proofroot/'native-wrapper-inventory-v2.json').read_text());native=[x for x in inventory['methods']if x['original']['name']==NAME]
if len(native)!=1:raise ValueError('Native method owner not unique')
n=native[0];code=bytes.fromhex(n['runtime_function']['bytes']);expected_sha='7ddfa19f0ca425308da130a020d364c0f2ebe743cd8f68abaa76eae4c7c31770'
if len(code)!=213 or hashlib.sha256(code).hexdigest()!=expected_sha:raise ValueError('Original native wrapper bytes differ')
matches=[]
for line in (proofroot/'instructions.jsonl').open():
 r=json.loads(line)
 if r['native_method_index']==n['original']['index']:matches.append(r)
if len(matches)!=1:raise ValueError('Exact decoded native method missing')
ins=matches[0]['instructions'];texts=[x['text']for x in ins]
if len(ins)!=49 or sum(x['length']for x in ins)!=213 or [x['text']for x in ins if x['flow']=='IndirectCall']!=['call rax']:raise ValueError('Full native wrapper decode differs')
expected_tail=['lea rcx,[rsp+30h]','mov dword ptr [rsp+30h],0','mov [rsp+28h],rcx','mov r9d,esi','mov ecx,[rsp+0A0h]','mov r8,rbp','mov [rsp+20h],ecx','mov rdx,rbx','mov ecx,edi','call rax','cmp dword ptr [rsp+30h],0','lea r11,[rsp+70h]','mov rcx,[rsp+0A8h]','mov rbx,[r11+10h]','setne dl','mov rbp,[r11+18h]','test al,al','mov rsi,[r11+20h]','setne al','mov [rcx],dl','mov rsp,r11','pop rdi','ret']
if texts[-23:]!=expected_tail:raise ValueError('Original return/out ABI instructions differ')
report={'schema':'later-official-source-original-native-manual-dispatch-comparison/v1','status':'comparison_only_not_overlay_authorized','later_official_tag':'15.0.0','later_official_commit':commit,'later_official_source_url':url,'later_official_source_sha256':hashlib.sha256(source).hexdigest(),'later_git_blob_sha1':gitsha,'declaration_line':i+1,'declaration':context,'original_method':n['original'],'native_pointer':n['native_pointer'],'native_runtime':n['runtime_function'],'instructions':ins,'proven_native_ABI':{'native_import_return_width_bits':8,'evidence':'test al,al; setne al after indirect native call, no intervening call','native_pbFailed_out_storage_bits':32,'evidence':'zero dword [rsp+30h]; pass its address as sixth native argument; cmp dword storage,0 after native call','managed_pbFailed_copyback_width_bits':8,'copyback':'setne dl; mov [managed out-pointer],dl','native_binding_and_fullsignature_previously_proven':True},'original14source_lacks_this_declaration':True,'same_version_source_authority_claimed':False,'overlay_applied':False,'project_modified':False,'game_or_sdk_executed':False,'limitations':['Later15 source is comparison evidence only, not assumed to be the original declaration.','The exact original wrapper independently proves an8bit bool return and4byte native out-bool temporary; the lost managed Param0 descriptor bytes remain unavailable.']};(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'later_commit':commit,'native_return_bits':8,'native_out_bool_bits':32,'project_modified':False}),flush=True)
