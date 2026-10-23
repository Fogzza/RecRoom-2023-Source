"""Close the actual LNF null-or-dead assertion and its small predicate.

Only parses original data and a prior Root inert decode; never runs target
code. The generic assertion is symbolically reconstructed from its original
CPAM instantiation and exact method RGCTX, not credited as native execution.
"""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;ROOT=HERE.parents[2]/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from audit_ogpeg_constructors import Decoder
from collect_all_pinvoke_native import ExternMetadata
from audit_custom_urp_native_loop import pdata
from run_live_lookup_dependencies_decode import connected_scope
from run_startup_foundation_decode import pin,need,save,check
from resolve_startup_foundation_native_joins import rgctx
from prove_recroom_ondestroy_native_cfg import aliases
from stage_title_page_route_slice import dispatch
from inventory_recroom_game_root_native import region
RUN=ROOT/'Validation/LNFProviderAssertion-20261023T101726Z-99d8dd9b'
RECEIPT_SHA='1175ee0ac3bd408d2be2955e19869e00604782fcd63f2af13d65c209aaee2355'

def assertion_shape(code,va):
    d=Decoder(code,va);d.literal('48895c24084889742410574883ec30488bf2498bd933d2498bf8')
    predicate=d.relative('e8');d.literal('84c0');bad=d.short('75');d.literal('488b5c2440488b7424484883c4305fc3');failure=va+d.at
    d.literal('0f1007488b4b300f11442420488b09');klass=d.relative('e8');d.literal('488bc8488d542420');box=d.relative('e8');d.literal('4533c0488bd0488bce');formatting=d.relative('e8');exception=d.relative('488d0d');d.literal('488bd8');initialize=d.relative('e8');d.literal('488bc8');allocate=d.relative('e8');d.literal('4533c0488bd3488bc8488bf8');ctor=d.relative('e8');context=d.relative('488d0d');context_init=d.relative('e8');d.literal('488bd0488bcf');throw=d.relative('e8');d.literal('cc');d.end()
    need(len(code)==162 and bad==failure and predicate==0x186741dc0 and klass==0x18010bba0 and box==0x180641680 and formatting==0x18476ec80 and exception==0x1887b5780 and initialize==context_init==0x1806c01e0 and allocate==0x1806c0340 and ctor==0x1840a05e0 and context==0x1887114e0 and throw==0x1806c0360,'Complete original assertion CFG and every argument/runtime/format/throw target')
    return {'all162_native_bytes_and_CFG_checked':True,'predicate_before_all_boxing_formatting_allocation':True,'false_returns_without_side_effects':True,'original_MethodInfo_rgctx_slot':0,'original_concrete_value_copy_bytes':16,'one_argument_String_Format':True,'same_exception_type_and_message_preserved':True}

def predicate_shape(code,va):
    d=Decoder(code,va);d.literal('40534883ec20');flag=d.relative('803d','00');d.literal('488bd9');ready_branch=d.short('75');use=d.relative('488d0d');init=d.relative('e8');written=d.relative('c605','01');ready=va+d.at;d.literal('4885db');null=d.short('74');interface=d.relative('488b15');d.literal('b9010000004c8bc3');call=d.relative('e8');d.literal('84c0');dead=d.short('75');d.literal('4883c4205bc3');true_at=va+d.at;d.literal('b0014883c4205bc3');d.end()
    need(len(code)==80 and flag==written and ready_branch==ready and null==dead==true_at and use==interface==0x188788ca8 and init==0x1806c01e0 and call==0x180157240,'Complete original null-or-dead predicate and slot1 interface CFG')
    return {'all80_native_bytes_and_CFG_checked':True,'raw_null_returns_true_without_interface_call':True,'nonnull_reads_original_NJA_slot1_bool_once':True,'bool_result_true_normalized_by_original_branch':True}

def main():
    need(pin(RUN/'run-report.json')['sha256']==RECEIPT_SHA,'Exact actual162-byte Root decoder pass');done=json.loads((RUN/'run-report.json').read_bytes());check(done['plan']);check(done['output']);p=json.loads(Path(done['plan']['path']).read_bytes());check(p['input']);original=json.loads(Path(p['input']['path']).read_bytes())['methods'][0];va=int(original['native_pointer'],16);code=bytes.fromhex(original['runtime_function']['bytes']);shape=assertion_shape(code,va)
    paths=[Path(x['path']) for x in p['original_inputs']]
    for row in p['original_inputs']:check(row)
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
        v=ExternMetadata(b,m);ranges,parents=pdata(v);need(v.usage(0x1887114e0)==original['original_LNF_usage'] and v.method_info(47951)==original['original'],'Exact original called assertion declaration/MethodSpec');targets=v.generic_targets({452439})[452439];need(len(targets)==1 and targets[0]['pointer']==hex(va),'Exact original concrete CPAM registration')
        pred=v.method_info(47953);need(pred['owner']=='AGNPJIHDJFG' and pred['name']=='EJFNLENHABL' and pred['return']=='System.Boolean' and [x['type'] for x in pred['parameters']]==['NJAICAFMPBE'] and v.method_pointer(pred)==0x186741dc0,'Exact native predicate method ownership')
        scope=connected_scope(v,0x186741dc0,ranges,parents);pred_code=bytes.fromhex(scope['runtime_function']['bytes']);pred_shape=predicate_shape(pred_code,0x186741dc0)
        context=rgctx(v,'UJect.Runtime.dll',0x06000062);need(len(context['rows'])==1 and context['rows'][0]['slot']==0 and context['rows'][0]['kind']==2 and context['rows'][0]['type']=='TArg','Only original assertion method RGCTX class TArg slot0')
        gc=struct.unpack_from('<iiii',m,v.row('genericContainers',1704,16));gp=struct.unpack_from('<iiHHHH',m,v.row('genericParameters',2904,16));need(gc==(47951,1,1,2904) and gp[0]==1704 and v.string(gp[1])=='TArg' and gp[3:]==(0,0,0),'Exact original unconstrained generic argument')
        uses={hex(x):v.usage(x) for x in [0x1887114e0,0x188788ca8,0x1887b5780]};need(uses['0x188788ca8']['type']=='NJAICAFMPBE' and uses['0x1887b5780']['type']=='System.InvalidOperationException','Original interface and exception class metadata')
        methods,gaps=aliases(v,{0x18476ec80,0x1840a05e0});formatters=methods['0x18476ec80'];need(len(formatters)==1 and formatters[0]['index']==3264 and formatters[0]['owner']=='System.String' and formatters[0]['name']=='Format' and [x['type'] for x in formatters[0]['parameters']]==['System.String','System.Object'],'Exact one-object genuine formatter')
        dh=v.method_info(47937);need(v.u16(m,v.row('methods',47937,32)+28)==1 and dh['owner']=='NJAICAFMPBE' and dh['return']=='System.Boolean' and not dh['parameters'],'Exact original dead-state property getter slot1')
        invoker=region(v,0x180157240);algorithm=dispatch(bytes.fromhex(invoker['bytes']),0x180157240)
    controls=[]
    for name,raw,pointer,validator in [('assertion',code,va,assertion_shape),('predicate',pred_code,0x186741dc0,predicate_shape)]:
        for offset in range(len(raw)):
            changed=bytearray(raw);changed[offset]^=1
            try:validator(bytes(changed),pointer)
            except (ValueError,struct.error):controls.append({'member':name,'offset':offset,'rejected':True})
            else:raise ValueError('Changed original byte accepted')
    out=ROOT/'Validation'/('LNFAssertionMembers-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();source=HERE/'RecoveredLnfAssertionMembers.cs'
    if source.exists():need(source.read_text()==CANDIDATE,'Preserve frozen exact assertion candidates')
    else:source.write_text(CANDIDATE,encoding='utf-8',newline='\n')
    result={'schema':'original-LNF-called-null-or-dead-assertion-two-member-CFG/v1','status':'two_complete_original_typed_candidates_staged_binding_effects_pending','producer':pin(Path(__file__)),'actual_Root_decode_receipt':pin(RUN/'run-report.json'),'original_scopes':p['input'],'original_inputs':p['original_inputs'],'original_assertion':original['original'],'assertion_shape':shape,'assertion_original_rgctx':context,'assertion_original_generic_container':list(gc),'original_predicate':pred,'original_predicate_scope':scope,'predicate_shape':pred_shape,'typed_original_metadata_uses':uses,'original_dead_property':dh,'original_String_Format':formatters[0],'reused_invoker_algorithm_only':{'runtime_function':invoker,'proof':algorithm,'caller_semantics_note':'The reused descriptor is prior Route prose only. This actual predicate supplies ECX1, exact NJA metadata and same provider; its own slot1 bool getter above is authoritative.'},'negative_controls':controls,'candidate':pin(source),'box_specialization_note':'Original native162-byte CPAM instantiation copies16B, boxes through exact RGCTX type slot0 and calls Format(string,object). The C# generic parameter remains unconstrained; other concrete instantiations have not been native-executed.','original_or_candidate_code_executed':False,'Main_modified':False,'working_boot_claimed':False};target=out/'report.json';save(target,result);print(json.dumps({'report':pin(target),'candidate':pin(source),'complete_original_bytes':242,'negative_controls':len(controls)}))

CANDIDATE='''// Exact original selected bodies only, outside Assets compilation.
// AGNPJIHDJFG original method47953; NJA property context is the raw getter.
public static bool EJFNLENHABL(NJAICAFMPBE ICHBECDKHOJ)
{
    return ICHBECDKHOJ==null || ICHBECDKHOJ.DHABENNNOIJ();
}
// MKECFLEMHEL original method47951; called, not inlined, by original LNF.
public static void LGKIDJCLIAD<TArg>(NJAICAFMPBE ICHBECDKHOJ,string NCIHNNHIIHE,TArg FGDJNNOBPEO)
{
    if(AGNPJIHDJFG.EJFNLENHABL(ICHBECDKHOJ))
        throw new System.InvalidOperationException(string.Format(NCIHNNHIIHE,FGDJNNOBPEO));
}
'''
if __name__=='__main__':main()
