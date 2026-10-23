"""Direct CLI/native-evidence dependency closure; never loads a target assembly.

Body presence is not counted as recovered behavior. Exact ret/null/throw stubs
are exposed explicitly. Candidate compilation cannot waive these runtime gaps.
"""
from pathlib import Path
import datetime as dt, hashlib, json, mmap, struct, uuid
from audit_cli_marshal_contracts import Cli,need
from audit_accessor_error_projection_static import ROOT, WS, sha

PROPOSAL=ROOT/'NativeGameplayRepairs/RuntimePluginTestedSDKProposal-20261022T151723Z-bd6c18fa/report.json'
CORE=ROOT/'Validation/CurrentCoreMarshalRoundtrip-20261022T162157Z-ad86540f/ActualCurrentCoreOutput/Assembly-CSharp.dll'
CANDIDATE=ROOT/'Validation/RecRoomBootFourMethodCandidate-20261022T172416Z-1d03e90a/report.json'

def compressed(b,at):
    need(at<len(b),'Signature bound');first=b[at]
    if first<128:return first,at+1
    if first&0xc0==0x80:need(at+2<=len(b),'Signature compressed2 bound');return ((first&63)<<8)|b[at+1],at+2
    if first&0xe0==0xc0:need(at+4<=len(b),'Signature compressed4 bound');return ((first&31)<<24)|(b[at+1]<<16)|(b[at+2]<<8)|b[at+3],at+4
    raise ValueError('Invalid compressed method signature')

def method_shape(sig):
    need(len(sig)>=3,'Method signature minimum');at=1;generic=0
    if sig[0]&16:generic,at=compressed(sig,at)
    count,at=compressed(sig,at)
    return {'generic_arity':generic,'parameter_count':count,'has_this':bool(sig[0]&32),'signature_blob_hex':sig.hex(),'return_signature_start_hex':sig[at:].hex()}

def module_methods(path,selectors):
    out=[]
    with Path(path).open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=Cli(b);types=[];parents={}
        for rid in range(1,c.rows[2]+1):
            at=c.row(2,rid);name=c.string(c.value(at+4,c.strw));ns=c.string(c.value(at+4+c.strw,c.strw));methods=c.value(at+4+2*c.strw+c.coded(2,[2,1,27])+c.index(4),c.index(6));types.append({'rid':rid,'name':name,'namespace':ns,'first_method':methods})
        for rid in range(1,c.rows[41]+1):
            at=c.row(41,rid);child=c.value(at,c.index(2));parent=c.value(at+c.index(2),c.index(2));need(child not in parents,'Duplicate nested owner');parents[child]=parent
        def fullname(rid,seen=None):
            seen=set() if seen is None else seen;need(rid not in seen,'Nested cycle');seen.add(rid);row=types[rid-1];return fullname(parents[rid],seen)+'/'+row['name'] if rid in parents else (row['namespace']+'.' if row['namespace'] else '')+row['name']
        for selector in selectors:
            hits=[t for t in types if fullname(t['rid'])==selector['owner']];need(len(hits)==1,'Exact required dependency owner absent or ambiguous: '+selector['owner']);t=hits[0];last=types[t['rid']]['first_method'] if t['rid']<len(types) else c.rows[6]+1;methods=[]
            for rid in range(t['first_method'],last):
                at=c.row(6,rid);name=c.string(c.value(at+8,c.strw))
                if name!=selector['name']:continue
                shape=method_shape(c.blob(c.value(at+8+c.strw,c.blobw)))
                if shape['parameter_count']!=selector['parameters'] or shape['generic_arity']!=selector.get('generic',0):continue
                rva=c.u32(at);impl=c.u16(at+4);flags=c.u16(at+6);body=b'';header=None;local_sig_token=0;local_sig=None
                if rva:
                    raw=c.raw(rva,1);first=b[raw]
                    if first&3==2:size=first>>2;body=bytes(b[c.raw(rva+1,size):c.raw(rva+1,size)+size]);header='tiny'
                    elif first&3==3:
                        word=c.u16(raw);head=(word>>12)*4;need(12<=head<=64,'Fat IL header bound');size=c.u32(raw+4);need(size<=65536,'Dependency IL size bound');start=c.raw(rva+head,size);body=bytes(b[start:start+size]);header='fat';local_sig_token=c.u32(raw+8)
                        if local_sig_token:
                            need(local_sig_token>>24==17,'Exact standalone local signature token required');local_sig=c.blob(c.value(c.row(17,local_sig_token&0xffffff),c.blobw))
                    else:raise ValueError('Invalid dependency IL header')
                classification='unverified_managed_body'
                if not rva:classification='no_IL_body_runtime_abstract_or_extern_contract'
                elif body==b'\x2a':classification='exact_void_return_stub_or_original_empty_body_requires_native_proof'
                elif body==b'\x14\x2a':classification='exact_unconditional_null_return_stub'
                elif body==b'\x14\x7a':classification='exact_null_throw_stub'
                generic_default_proof=None
                if len(body)==10 and body[:4]==bytes.fromhex('1200fe15') and body[-2:]==bytes.fromhex('062a'):
                    type_token=struct.unpack_from('<I',body,4)[0];need(type_token>>24==27,'Exact initobj TypeSpec token required');type_sig=c.blob(c.value(c.row(27,type_token&0xffffff),c.blobw))
                    if shape['generic_arity']==1 and shape['return_signature_start_hex'].startswith('1e00') and type_sig==bytes.fromhex('1e00') and local_sig==bytes.fromhex('07011e00'):
                        classification='exact_default_method_generic_parameter0_return_stub';generic_default_proof={'local0_signature_blob':local_sig.hex(),'initobj_TypeSpec_blob':type_sig.hex(),'return_type_is_method_generic_parameter0':True,'for_original_MFENCGHNPBJ_reference_interface_instantiation':'unconditional null return'}
                methods.append({**selector,**shape,'current_CLI_token_not_original_native':'0x%08x'%(0x06000000|rid),'current_RVA':rva,'flags':flags,'impl_flags':impl,'IL_header':header,'IL_bytes':body.hex(),'IL_sha256':hashlib.sha256(body).hexdigest() if rva else None,'classification':classification,'generic_default_static_proof':generic_default_proof,'native_behavior_recovered_from_body_presence':False})
            need(len(methods)==1,'Exact dependency method absent/overloaded: '+selector['owner']+'.'+selector['name']);out.extend(methods)
    return out

def main():
    need(sha(CANDIDATE)=='776598f7d0d3b59366d934655d8ce38b6ae5f9ca42c72fcdd410ff0f70914c73','Four-body candidate drift');need(sha(CORE)=='885953e1ae5b44cce72d742ad5817d33bb64594581b97565518d0799d4da95e5','Accepted core drift')
    proposal=json.loads(PROPOSAL.read_text());files={r['assembly']+'.dll':r for r in proposal['assemblies']};rows=[];inputs=[PROPOSAL,CORE,CANDIDATE]
    cases={
        'RecRoom.Datastructures.Singletons.Runtime.dll':[{'owner':'SingletonMonoBehaviour`1','name':'Awake','parameters':0,'role':'original generic base Awake<GameRoot>'},{'owner':'GameRoot','name':'OnDestroy','parameters':0,'role':'original base cleanup'},{'owner':'GameRoot','name':'HPCJAAEDLCH','parameters':0,'role':'native-proved original empty base hook'},{'owner':'GameRoot','name':'.ctor','parameters':0,'role':'original base constructor'}],
        'RecRoom.AgInitialization.Runtime.dll':[{'owner':'MPAAIECKLGA','name':'PNFLFFOAING','parameters':0,'role':'static service-container property CFHDLGEGDFD getter'}],
        'UJect.Runtime.dll':[{'owner':'MNALHHOLFGL','name':'HHCPOGCCGNF','parameters':1,'generic':1,'role':'generic memory-service resolver<MFENCGHNPBJ>(null)'}]
    }
    for filename,selectors in cases.items():
        r=files[filename];candidate=Path(r['candidate']);need(sha(candidate)==r['candidate_sha256'],'Final225 runtime candidate drift: '+filename);inputs.append(candidate)
        for row in module_methods(candidate,selectors):row.update(assembly=filename,inspected='final_staged_runtime225',path=str(candidate),file_sha256=sha(candidate));rows.append(row)
        main=WS/'RR23/Assets/Plugins'/filename;inputs.append(main)
        for row in module_methods(main,selectors):row.update(assembly=filename,inspected='current_main_runtime_plugin',path=str(main),file_sha256=sha(main));rows.append(row)
    core_selectors=[{'owner':'BootSequence','name':'Awake','parameters':0,'role':'original newly-added component Awake callback'},{'owner':'BootSequence','name':'Start','parameters':0,'role':'original IEnumerator startup/login boot factory'},{'owner':'RecRoomGameRoot','name':'ADNHOPPILKF','parameters':0,'role':'original subscribed lowMemory handler'}]
    for row in module_methods(CORE,core_selectors):row.update(assembly='Assembly-CSharp.dll',inspected='accepted_core_baseline_before_four_body_candidate',path=str(CORE),file_sha256=sha(CORE));rows.append(row)
    required=[r for r in rows if r['inspected']=='final_staged_runtime225'];getter=next(r for r in required if r['owner']=='MPAAIECKLGA');resolver=next(r for r in required if r['owner']=='MNALHHOLFGL')
    blockers=[]
    if getter['classification']=='exact_unconditional_null_return_stub':blockers.append({'stage':'RecRoomGameRoot.Awake','dependency':'MPAAIECKLGA.CFHDLGEGDFD','reason':'proved current getter returns null unconditionally; immediately dereferenced by original generic resolver call, so restoring Awake currently raises NullReferenceException'})
    for r in required:
        if r['owner']=='GameRoot' and r['name']=='HPCJAAEDLCH':continue
        blockers.append({'stage':r['role'],'dependency':r['owner']+'.'+r['name'],'current_body_classification':r['classification'],'reason':'original required dependency behavior not restored or independently native-proved'})
    for r in rows:
        if r['assembly']=='Assembly-CSharp.dll':blockers.append({'stage':r['role'],'dependency':r['owner']+'.'+r['name'],'current_body_classification':r['classification'],'reason':'component/coroutine/low-memory original body still unrecovered'})
    need(blockers,'Unsafe to claim a closed boot graph without independent full-original proof')
    source_paths=[WS/'RR23/Assets/Scripts/Assembly-CSharp/RecRoomGameRoot.cs',WS/'RR23/Assets/Scripts/Assembly-CSharp/BootSequence.cs'];inputs+=source_paths
    report={'schema':'four-original-boot-method-candidate-actual-dependency-closure/v1','status':'not_closed_apply_for_PlayMode_held','four_candidate_bodies_native_proved_but_entire_boot_not_recovered':True,'safe_to_apply_as_working_bootstrap':False,'fallback_new_bootstrap_or_default_service_created':False,'methods':rows,'blocking_gaps':blockers,'framework_event_dependency':'genuine matching UnityEngine.Application lowMemory add/remove and LowMemoryCallback ctor are required; no fake local event implementation','native_proved_empty_base_hook_is_not_mislabeled_missing':True,'method_numeric_current_CLI_tokens_are_not_native_tokens':True,'all_dependencies_recovered':False,'game_CLR_or_native_code_executed':False,'main_or_harness_modified':False,'inputs':[{'path':str(p),'sha256':sha(p)} for p in inputs]}
    out=ROOT/'Validation'/('BootFourMethodDependencyClosure-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'status':report['status'],'methods':[{'owner':r['owner'],'name':r['name'],'scope':r['inspected'],'classification':r['classification'],'IL':r['IL_bytes']} for r in rows],'blocker_count':len(blockers)}))

if __name__=='__main__':main()
