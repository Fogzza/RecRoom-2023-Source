"""Stage only the original288B Start sequence, with its exact EH and typed joins.

No Main mutation or managed execution. Addressables and bootstrap closure are
held explicitly; this source candidate is not a working startup implementation.
"""
from pathlib import Path
import base64, datetime as dt, hashlib, json, struct, uuid
from run_startup_foundation_decode import HERE, WS, ROOT, need, pin, check, save
import prove_recroom_start_native_cfg as proof
from original_eh4_metadata import source_authority

PROOF = ROOT / 'Validation/RecRoomStartFlow-20261023T102940Z-2d96430f/report.json'
PROOF_SHA = '01087a71b1b09bbdfa3f80eb349e51db332dc9ed0a348b22a5d96e833830584d'
EH_READER_SHA = '7ae871828475535effa0667a0fa5bbb4a7cc36523e75b8d4bebd330ca0b944f3'
MEMBER = '''\tprivate void Start()
\t{
\t\tvar operation = Addressables.InstantiateAsync(startupObjectReference, transform, false, true);
\t\toperation.WaitForCompletion().SetActive(true);
\t\tHPCJAAEDLCH();
\t}'''.replace('\n', '\r\n').encode()

def main():
    need(pin(PROOF)['sha256'] == PROOF_SHA, 'Exact Root whole288B flow and original typed/EH proof')
    r = json.loads(PROOF.read_bytes())
    for row in r['inputs']:
        need(pin(row['path'])['sha256'] == row['sha256'], 'Original proof input still exact')
    need(pin(HERE/'original_eh4_metadata.py')['sha256'] == EH_READER_SHA, 'Exact reviewed pure EH reader')
    authority = source_authority()
    need(authority == r['original_EH']['source_authority'], 'Exact genuine FH4 source authority')
    code = bytes.fromhex(r['original']['runtime_function']['bytes'])
    shape = proof.decode_start(code, int(r['original']['native_pointer'],16))
    need(shape == r['shape'], 'Whole native instruction/branch proof recomputed')
    calls = r['raw_backed_direct_aliases']
    expected = [('0x183eba7f0',34026,'UnityEngine.Component','get_transform',[]),('0x1830639a0',124371,'UnityEngine.AddressableAssets.Addressables','InstantiateAsync',['System.Object','UnityEngine.Transform','System.Boolean','System.Boolean']),('0x183ec37b0',34114,'UnityEngine.GameObject','SetActive',['System.Boolean'])]
    for address,index,owner,name,args in expected:
        need(len(calls[address]) == 1, 'Unique raw-backed source call target')
        m = calls[address][0]
        need((m['index'],m['owner'],m['name'],[x['type'] for x in m['parameters']]) == (index,owner,name,args), 'Exact original typed source call')
    generic = r['metadata_uses'][1]
    need(generic['kind']==6 and generic['index']==38366 and generic['method']['index']==94985 and generic['method']['name']=='WaitForCompletion' and generic['class_argument_types']==['UnityEngine.GameObject'] and not generic['method_argument_types'], 'Exact handle<GameObject> WaitForCompletion')
    need(r['handle_generic_targets']=={'38366':[{'generic_table_index':36500,'pointer_index':34129,'invoker_index':34377,'adjustor_thunk_index':618,'pointer':'0x183d18e60'}]} and shape['direct_calls']['handle_call']=='0x183d18e60', 'Exact original registered shared handle target')
    need(r['virtual_dispatch'][1]['method']['index']==200264 and r['virtual_dispatch'][1]['slot']==6 and r['callsite_protected_states']=={'get_transform':0,'instantiate':0,'handle':0,'SetActive':0,'virtual_hook':0,'null_exception':0,'rethrow':-1}, 'Exact hook receiver and all protected call intervals')
    eh=r['original_EH']; handler=eh['try_blocks'][0]['handlers'][0]
    need(eh['unwind_entries']==[{'state':0,'encoded_entry_offset':1,'next_offset':1,'kind':0},{'state':1,'encoded_entry_offset':2,'next_offset':2,'kind':0}] and handler['type_descriptor_rva']=='0x8c65330' and handler['continuation_rvas']==['0xc87f00'], 'Exactly original wrapper propagation with no cleanup action')
    funclet=bytes.fromhex(r['catch_funclet']['bytes'])
    need(funclet == bytes.fromhex('4889542410554883ec30488bea488b4530488b0848898d9000000048b800000000000000004883c4305dc3cc'), 'Exact44B catch only copies exception pointer and returns continuation0')
    need(shape['direct_calls']['null_result_handler']=='0x1806c0390' and shape['direct_calls']['handler_rethrow_call']=='0x1806c0360', 'Exact observed null and raise helpers; no swallowed exception')
    source=WS/'RR23/Assets/Scripts/Assembly-CSharp/RecRoomGameRoot.cs'; meta=Path(str(source)+'.meta')
    before=source.read_bytes(); old=b'\tprivate void Start()\r\n\t{\r\n\t}'
    need(before.count(old)==1, 'One exact original Start stub and all other source untouched')
    at=before.index(old); candidate=before[:at]+MEMBER+before[at+len(old):]
    negatives=[]
    for index in range(len(code)):
        changed=bytearray(code);changed[index]^=1
        try:need(proof.decode_start(bytes(changed),int(r['original']['native_pointer'],16)) == shape, 'Original native operands and control flow must stay exact')
        except (ValueError,struct.error):negatives.append(index)
        else:raise ValueError('Native-byte mutation accepted at '+str(index))
    out=ROOT/'Validation'/('RecRoomStartFlowCandidate-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    target=out/'RecRoomGameRoot.cs';target.write_bytes(candidate)
    report={'schema':'original-RecRoomGameRoot-Start-exact-native-source-candidate/v1','status':'one_original_Start_staged_full_compile_binding_effects_pending','native_proof':pin(PROOF),'producer':pin(Path(__file__)),'native_proof_helper':pin(Path(proof.__file__)),'EH_reader':pin(HERE/'original_eh4_metadata.py'),'EH_source_authority':authority,'source':pin(source),'meta':pin(meta),'candidate':pin(target),'start':at,'length':len(old),'original_base64':base64.b64encode(old).decode(),'replacement_base64':base64.b64encode(MEMBER).decode(),'member_sha256':hashlib.sha256(MEMBER).hexdigest(),'native_single_byte_mutations_rejected':negatives,'source_argument_and_effect_order':['capture original startupObjectReference','read same receiver transform','InstantiateAsync(key,parent,false,true)','copy returned exact handle value','WaitForCompletion on handle address','raw-null target throws; genuine instance SetActive(true)','virtual same-receiver HPCJAAEDLCH slot6'],'EH_projection':'Straight-line propagation; original C++ wrapper catches/copies/rethrows unchanged without cleanup, Dispose or Release. No C# catch/finally is added.','independent_peer_EH_review_received':True,'unused_IDisposable_metadata_setup_is_not_a_dispose_call':True,'Main_modified':False,'Main_activation_approved':False,'activation_requires':['Original Addressables.InstantiateAsync and WaitForCompletion runtime closure','GameRoot Awake/service closure','Original boot hook and BootSequence runtime state machine'],'working_startup_login_or_dorm_claimed':False}
    save(out/'report.json',report)
    print(json.dumps({'report':pin(out/'report.json'),'candidate':pin(target),'member_sha256':report['member_sha256'],'negative_controls':len(negatives),'Main_activation_approved':False}))

if __name__=='__main__':main()
