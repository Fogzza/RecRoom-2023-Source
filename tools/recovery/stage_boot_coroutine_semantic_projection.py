"""Stage an independently reviewable original boot-coroutine projection only.

The whole1294B native normal CFG is already decoded; exact typed joins below
bind its two states. This is not a full semantic proof, runtime closure, or a
Main change. Peer native review and actual compile/effects remain required.
"""
from pathlib import Path
import datetime as dt, hashlib, json, uuid
from run_startup_foundation_decode import HERE, WS, ROOT, need, pin, check, save
JOIN=ROOT/'Validation/BootSequenceStartupTypedJoins-20261023T104012Z-df5248ca/report.json'
JOIN_SHA='8cd37b831f74b602701c64c919869f411d1bf858b512483a27fc6be1cadf55b1'

MOVE='''\t\tprivate bool MoveNext()
\t\t{
\t\t\tint state = _003C_003E1__state;
\t\t\tBootSequence boot = _003C_003E4__this;
\t\t\tif (state == 0)
\t\t\t{
\t\t\t\t_003C_003E1__state = -1;
\t\t\t\tif (boot.CGCGDEEJADP == 0)
\t\t\t\t{
\t\t\t\t\tfloat processTime = PlatformManager.Instance.GetCurrentProcessTimeSinceBoot();
\t\t\t\t\tboot.KEEBMEBDMMH = processTime;
\t\t\t\t\tif (processTime > 0f)
\t\t\t\t\t{
\t\t\t\t\t\tvar processTimers = boot.AIDHPHJKAMP;
\t\t\t\t\t\tboot.LIPOFDEAMPE = true;
\t\t\t\t\t\tprocessTimers.OJFIFFKKFLH(KFLCEJHCAII, processTime);
\t\t\t\t\t}
\t\t\t\t}
\t\t\t\tboot.AIDHPHJKAMP.OJFIFFKKFLH(MDGBEFOBMLG, 0f);
\t\t\t\tboot.AIDHPHJKAMP.OJFIFFKKFLH(KFKHDPIOGDF, 0f);
\t\t\t\tboot.AIDHPHJKAMP.OJFIFFKKFLH(JIGCOAAHHCO, 0f);
\t\t\t\tboot.AIDHPHJKAMP.OJFIFFKKFLH(DPOPFLBCAKF, 0f);
\t\t\t\tPNAABCMOHGM.FPNMONCCAAE(string.Concat("Build version: ", IDDIAODMAPP.OLGKJALIAAI), new HJDBOADFHMC?(HJDBOADFHMC.NLODGHMOFNO));
\t\t\t\tboot.HLLLBLNAABH = null;
\t\t\t\tboot.PHFHOMMGCGJ = false;
\t\t\t\tNDFLHBFOIGB.IHEKMEOIBOI();
\t\t\t\tif (MPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<MCCKDPKLCIN>(null).CurrentUnityLauncher == (KDHPMLNMNNO)1)
\t\t\t\t{
\t\t\t\t\tMPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<GCLANALOAPO>(null).IHEKMEOIBOI();
\t\t\t\t}
\t\t\t\tif (!PlatformManager.Instance.RequiresLoginBeforeInternet)
\t\t\t\t{
\t\t\t\t\tboot.DKODHBLBHDC();
\t\t\t\t}
\t\t\t\t_003C_003E2__current = new UnityEngine.WaitForEndOfFrame();
\t\t\t\t_003C_003E1__state = 1;
\t\t\t\treturn true;
\t\t\t}
\t\t\tif (state == 1)
\t\t\t{
\t\t\t\t_003C_003E1__state = -1;
\t\t\t\tboot.HOMDODONEKI.IHEKMEOIBOI(0);
\t\t\t\tboot.CBFAAHKFJCI = JHIKKDDFDGA.FJNOABDJGMO(boot, boot.HKBJKPPPCPM, true);
\t\t\t}
\t\t\treturn false;
\t\t}'''

def main():
    need(pin(JOIN)['sha256']==JOIN_SHA,'Exact full normal CFG and original typed dependencies')
    r=json.loads(JOIN.read_bytes())
    for row in [r['original_region_input'],r['actual_decoder_receipt'],r['actual_decoded_output'],r['producer']]:check(row)
    member=next(x for x in r['startup_methods'] if x['original_method']['index']==195713)
    need(member['CFG']['all_original_bytes_decoded'] and member['CFG']['all_normal_nonterminal_edges_inside_complete_scope'] and len(member['CFG']['indirect_call_semantics_pending'])==2,'Exact whole coroutine normal CFG; two virtual targets still separately bound below')
    decoded={x['native_method_index']:x for x in [json.loads(l) for l in Path(r['actual_decoded_output']['path']).read_text().splitlines()]}
    instructions={i['ip']:i['text'] for i in decoded[195713]['instructions']}
    anchors={0x180b04dad:'mov eax,[rsi+10h]',0x180b04db0:'mov rdi,[rsi+20h]',0x180b04dc9:'mov dword ptr [rsi+10h],0FFFFFFFFh',0x180b04ddc:'cmp [rdi+0B4h],eax',0x180b04e2d:'movss [rdi+0B8h],xmm0',0x180b04e3e:'mov byte ptr [rdi+0B0h],1',0x180b04e4e:'mov rdx,[18886C360h]',0x180b04e70:'mov rdx,[18886D280h]',0x180b04e92:'mov rdx,[18886DC98h]',0x180b04eb4:'mov rdx,[188866378h]',0x180b04ed6:'mov rdx,[188866600h]',0x180b04f5f:'movups xmm1,[rcx+340h]',0x180b04fc5:'mov qword ptr [rcx],0',0x180b04fcc:'mov byte ptr [rdi+70h],0',0x180b05038:'cmp eax,1',0x180b0506e:'mov ecx,4',0x180b050f0:'mov [rcx],rbx',0x180b050fa:'mov dword ptr [rsi+10h],1',0x180b05103:'cmp eax,1',0x180b05108:'mov dword ptr [rsi+10h],0FFFFFFFFh',0x180b05114:'mov rcx,[rdi+90h]',0x180b05155:'mov r8b,1',0x180b0516d:'mov [rcx],rax'}
    for address,text in anchors.items():need(instructions[address]==text,'Exact original state/field/argument/branch anchor')
    uses=member['metadata_usages'];need(uses['0x18880a050']['method']['index']==195679 and uses['0x1887fa540']['type']=='UnityEngine.WaitForEndOfFrame' and uses['0x188870a38']['class_argument_types']==['System.Single'],'Original update callback/yield object/Action<float> construction')
    need(uses['0x188721570']['method_argument_types']==['GCLANALOAPO'] and uses['0x1887276c0']['method_argument_types']==['MCCKDPKLCIN'] and uses['0x188712308']['class_argument_types']==['PlatformManager'],'Exact original specialized lookup/singleton contexts')
    fields=next(x for x in r['startup_methods'] if x['original_method']['index']==195630)['original_fields']
    expected={112:('PHFHOMMGCGJ','System.Boolean'),120:('HLLLBLNAABH','System.String'),144:('HOMDODONEKI','MDEJADHJOEJ'),152:('CBFAAHKFJCI','System.IDisposable'),168:('AIDHPHJKAMP','OFDHBOEDNCN'),176:('LIPOFDEAMPE','System.Boolean'),180:('CGCGDEEJADP','System.Int32'),184:('KEEBMEBDMMH','System.Single')}
    for offset,value in expected.items():
        found=[f for f in fields if not f['native_type']['attributes']&16 and f['offset']==offset];need(len(found)==1 and (found[0]['name'],found[0]['type'])==value,'Exact original boot object field projection')
    source=WS/'RR23/Assets/Scripts/Assembly-CSharp/BootSequence.cs';before=source.read_bytes();old=b'\t\tprivate bool MoveNext()\r\n\t\t{\r\n\t\t\treturn false;\r\n\t\t}'
    nested=before.index(b'private sealed class NEKGMMPKEPF');at=before.index(old,nested);end=before.index(b'private sealed class HMPHEGFPPFD',nested);need(at<end,'Select original NEK coroutine only, not the other two MoveNext bodies')
    replacement=MOVE.replace('\n','\r\n').encode();out=ROOT/'Validation'/('BootCoroutineSemanticProjection-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();candidate=out/'BootSequence.cs';candidate.write_bytes(before[:at]+replacement+before[at+len(old):]);member_path=out/'BootSequence.NEKGMMPKEPF.MoveNext.member.cs';member_path.write_bytes(replacement)
    report={'schema':'original-boot-coroutine-reviewable-semantic-projection/v1','status':'reviewable_projection_only_NOT_full_native_semantic_proof_or_compiled_candidate','whole_native_normal_CFG_and_typed_joins':pin(JOIN),'decoded_original':r['actual_decoded_output'],'producer':pin(Path(__file__)),'source':pin(source),'meta':pin(Path(str(source)+'.meta')),'candidate':pin(candidate),'member':pin(member_path),'exact_native_anchors':{hex(a):t for a,t in anchors.items()},'Main_modified':False,'Main_activation_approved':False,'pending_before_acceptance':['Independent whole1294B semantic review including two PlatformManager virtual slots, two interface slots, raw-null/effect order and float branch','Original HJDB static color offset340 and const timer/log literal projections verified against original metadata','Generated interface getters/Dispose/Reset and HKB callback remain separate original dependencies','Actual full source metadata binding and controlled effect checks'],'production_SDK_or_bootstrap_executed':False,'working_login_or_dorm_claimed':False}
    save(out/'report.json',report);print(json.dumps({'report':pin(out/'report.json'),'member':pin(member_path),'acceptance':'pending independent native semantics review and actual tests','Main_activation_approved':False}))

if __name__=='__main__':main()
