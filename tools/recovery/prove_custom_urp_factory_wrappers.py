"""Prove original three URP factories and stage inert replacement members.

Original native bytes/metadata are authority. Cached URP is comparison only.
No target code, compiler, Unity, player, or network is launched.
"""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,tarfile,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_ogpeg_constructors import Decoder
from audit_custom_urp_native_loop import pin,save,fields,factory_shape,leaf_contract,ASSEMBLY,PREFIX
from prove_recroom_ondestroy_native_cfg import aliases
from audit_boot_candidate_dependency_closure import module_methods
from audit_hashable_scoped_vtable import Read
from audit_cli_marshal_contracts import Cli

AUDIT=ROOT/'Validation/CustomURPNativeLoopAudit-20261023T085002Z-d903fd8a'
DECODE=AUDIT/'RootFactoryDecode-20261023T085655Z-a7b595a6'
AUDIT_SHA='b6b0ad9a37a7e689efd73da61e03506ba211f62db5c84e11661a6c282ffbe2a3'
RECEIPT_SHA='1d807e6833943545268ee57d040390def99adc1d8d6c76788b6bd4df915250d8'
OUTPUT_SHA='2e3a696b414269e2d8e70e03492cfc623ebbbbfc65508d13d04044a5f1b3957c'

def create_pipeline(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 57 48 83 ec 20');flag=d.relative('80 3d','00');d.literal('48 8b f9');initialized=d.short('75')
    uses=[];initializers=[]
    for _ in range(5):uses.append(d.relative('48 8d 0d'));initializers.append(d.relative('e8'))
    written=d.relative('c6 05','01');ready=va+d.at
    d.literal('48 8b 4f 40 48 85 c9');exists=d.short('75');d.literal('8d 51 01');array_type=d.relative('48 8b 0d');newarray=d.relative('e8')
    d.literal('48 8b d0 48 89 47 40 48 8d 4f 40');barrier=d.relative('e8');d.literal('48 8b 4f 40 48 85 c9');null_array=d.relative('0f 84');array_ready=va+d.at
    d.literal('48 63 47 48 3b 41 18');bad_index=d.relative('0f 83');d.literal('48 8b 5c c1 20');object_class=d.relative('48 8b 0d')
    d.literal('f6 81 33 01 00 00 04');object_no_cctor=d.short('74');d.literal('83 b9 e0 00 00 00 00');object_cctor_finished=d.short('75');object_init=d.relative('e8');object_ready=va+d.at
    d.literal('45 33 c0 33 d2 48 8b cb');equal=d.relative('e8');d.literal('84 c0');missing=d.short('75')
    d.literal('33 d2 48 8b cf');renderers=d.relative('e8');pipeline_class=d.relative('48 8b 0d');allocate=d.relative('e8');d.literal('45 33 c0 48 8b d7 48 8b c8 48 8b d8');ctor=d.relative('e8')
    d.literal('48 8b c3 48 8b 5c 24 30 48 83 c4 20 5f c3');missing_start=va+d.at
    d.literal('8b 47 28 39 47 2c');version_mismatch=d.short('75');pipeline_error_class=d.relative('48 8b 0d')
    d.literal('f6 81 33 01 00 00 04');pipeline_no_cctor=d.short('74');d.literal('83 b9 e0 00 00 00 00');pipeline_cctor_finished=d.short('75');pipeline_init=d.relative('e8');pipeline_ready=va+d.at
    d.literal('33 c9');asset=d.relative('e8');d.literal('48 85 c0');null_asset=d.short('74');d.literal('33 d2 48 8b c8');name=d.relative('e8');message=d.relative('48 8b 0d');d.literal('45 33 c0 48 8b d0');concat=d.relative('e8')
    debug_class=d.relative('48 8b 0d');d.literal('48 8b d8 f6 81 33 01 00 00 04');debug_no_cctor=d.short('74');d.literal('83 b9 e0 00 00 00 00');debug_cctor_finished=d.short('75');debug_init=d.relative('e8');debug_ready=va+d.at
    d.literal('45 33 c0 48 8b d7 48 8b cb');log=d.relative('e8');return_null=va+d.at
    d.literal('48 8b 5c 24 30 33 c0 48 83 c4 20 5f c3');null_tail=va+d.at;nre=d.relative('e8');d.literal('cc');bounds_tail=va+d.at;index_exception=d.relative('e8');d.literal('48 8b c8 33 d2');raise_exception=d.relative('e8');d.literal('cc');d.end()
    need(len(code)==420 and flag==written==0x188c87400 and initialized==ready,'Exact metadata guard')
    need(uses==[0x188735040,0x1887f13e0,0x18888ce28,0x1887e0890,0x1887ffe28] and all(x==0x1806c01e0 for x in initializers),'Exact original metadata setup')
    need(exists==array_ready and null_array==null_asset==null_tail and bad_index==bounds_tail and missing==missing_start and version_mismatch==return_null,'All original branch edges closed')
    need(object_no_cctor==object_cctor_finished==object_ready and pipeline_no_cctor==pipeline_cctor_finished==pipeline_ready and debug_no_cctor==debug_cctor_finished==debug_ready,'All original class-initialization guard joins')
    need(array_type==uses[2] and object_class==uses[1] and pipeline_class==pipeline_error_class==uses[3] and message==uses[4] and debug_class==uses[0],'Metadata use ownership')
    need([newarray,barrier,object_init,pipeline_init,debug_init,allocate,nre,index_exception,raise_exception]==[0x1806bfdb0,0x1806bfd30,0x180640f10,0x180640f10,0x180640f10,0x1806c0340,0x1806c0390,0x1806bff80,0x1806c0360],'Original framework support anchors')
    need([equal,renderers,ctor,asset,name,concat,log]==[0x1831721f0,0x1835dcaf0,0x1835e5a40,0x1835e5fc0,0x183172180,0x18476b920,0x183ebf8b0],'Original typed callee addresses')
    return {'all420bytes_opcodes_and_CFG_checked':True,'metadata_uses':[hex(x) for x in uses],'call_targets':{k:hex(v) for k,v in dict(UnityObject_Equality=equal,CreateRenderers=renderers,UniversalRenderPipeline_ctor=ctor,UniversalRenderPipeline_asset=asset,UnityObject_name=name,String_Concat=concat,Debug_LogError=log).items()},'closed_branch_targets':{k:hex(v) for k,v in dict(metadata_ready=ready,array_ready=array_ready,missing_renderer=missing_start,null_return=return_null,null_exception=null_tail,index_exception=bounds_tail).items()},'field_accesses':{'m_RendererDataList':64,'m_DefaultRendererIndex':72,'k_AssetVersion':40,'k_AssetPreviousVersion':44},'array_bound_check':'unsigned index >= length, including negative indices; preserve standard C# array exception behavior','Unity_null_check':'original UnityEngine.Object.op_Equality(rendererData,null), including destroyed objects','type_initialization':'Original metadata/Runtime class-initialization support is preserved by existing CLR type contracts; no replacement cctor or skipped initialization is proposed'}

def current_fields(path,owner):
    with Path(path).open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=Cli(b);r=Read(c);ids=[i for i in range(1,c.rows[2]+1) if r.definition(i)==owner];need(len(ids)==1,'Exact current type')
        i=ids[0];offset=4+2*c.strw+c.coded(2,[2,1,27]);start=c.value(c.row(2,i)+offset,c.index(4));end=c.value(c.row(2,i+1)+offset,c.index(4)) if i<c.rows[2] else c.rows[4]+1;out=[]
        for n in range(start,end):
            at=c.row(4,n);sig=c.blob(c.value(at+2+c.strw,c.blobw));need(sig[0]==6,'Field signature grammar');typ,end_sig=r.type(sig,1);need(end_sig==len(sig),'Field signature fully consumed')
            out.append({'token':hex(0x04000000|n),'name':c.string(c.value(at+2,c.strw)),'flags':c.u16(at),'type':typ,'signature':sig.hex()})
        return out

def literal(v,index):
    at=v.row('stringLiteral',index,8);length,offset=struct.unpack_from('<ii',v.m,at);base,size=v.tables['stringLiteralData'];need(0<=length<=1024 and 0<=offset<=size-length,'Bounded original error message');raw=bytes(v.m[base+offset:base+offset+length]);return {'index':index,'utf8':raw.decode('utf-8'),'sha256':hashlib.sha256(raw).hexdigest()}

def main():
    need(pin(AUDIT/'report.json')['sha256']==AUDIT_SHA and pin(DECODE/'run-report.json')['sha256']==RECEIPT_SHA and pin(DECODE/'decoded-original-factories.jsonl')['sha256']==OUTPUT_SHA,'Exact Root successful decode pins')
    receipt=json.loads((DECODE/'run-report.json').read_bytes());need(receipt['status']=='original536B_factories_inert_decoded_typed_semantics_pending' and receipt['phases'][0]['exit_code']==0,'Root actual inert decode passed')
    audit=json.loads((AUDIT/'report.json').read_bytes());rows=json.loads((AUDIT/'factory-wrappers-inert-input.json').read_bytes())['methods'];need([r['original']['index'] for r in rows]==[90725,90955,91174],'Three original factories')
    original=[Path(p['path']) for p in audit['original_inputs']]
    need([pin(p) for p in original]==audit['original_inputs'],'Original native source unchanged')
    pipeline=create_pipeline(bytes.fromhex(rows[0]['runtime_function']['bytes']),int(rows[0]['native_pointer'],16))
    forward=factory_shape(bytes.fromhex(rows[1]['runtime_function']['bytes']),int(rows[1]['native_pointer'],16))
    controls=[]
    for row,decoder in [(rows[0],create_pipeline),(rows[1],factory_shape)]:
        code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16)
        for i in range(len(code)):
            changed=bytearray(code);changed[i]^=1
            try:decoder(bytes(changed),va)
            except (ValueError,struct.error):controls.append({'index':row['original']['index'],'offset':i,'rejected':True})
            else:raise ValueError('Changed factory byte accepted '+str((row['original']['index'],i)))
    with original[0].open('rb') as bf,original[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);native_fields=fields(v,rows[0]['original']['owner_index']);byoffset={f['offset']:f for f in native_fields if not f['flags']&16}
        for name,offset in pipeline['field_accesses'].items():need(byoffset[offset]['name']==name,'Original field ownership/type')
        uses={a:v.usage(int(a,16)) for a in pipeline['metadata_uses']};msg=literal(v,uses['0x1887ffe28']['index'])
        need(msg['utf8']=='Default Renderer is missing, make sure there is a Renderer assigned as the default on the current Universal RP asset:','Exact original error prefix')
        targetset={int(x,16) for x in pipeline['call_targets'].values()};calls,gaps=aliases(v,targetset)
        expected={0x1831721f0:('UnityEngine.Object','op_Equality'),0x1835dcaf0:(PREFIX+'UniversalRenderPipelineAsset','CreateRenderers'),0x1835e5a40:(PREFIX+'UniversalRenderPipeline','.ctor'),0x1835e5fc0:(PREFIX+'UniversalRenderPipeline','get_asset'),0x183172180:('UnityEngine.Object','get_name'),0x18476b920:('System.String','Concat'),0x183ebf8b0:('UnityEngine.Debug','LogError')}
        for pointer,(owner,name) in expected.items():need(any(x['owner']==owner and x['name']==name for x in calls[hex(pointer)]),'Typed original callee join')
        leaf=leaf_contract(v);accessors=[]
        for token,expected_bytes in [(0x06000228,'0fb64118c3'),(0x06000229,'885118c3')]:
            method=v.find_method(PREFIX+'ScriptableRendererData',token);va=v.method_pointer(method);code=bytes.fromhex(expected_bytes);at=v.raw(va,len(code));need(bytes(b[at:at+len(code)])==code,'Original invalidation accessor exact field operation');accessors.append({'original':method,'native_pointer':hex(va),'semantic_bytes':expected_bytes})
    dll=WS/'RR23/Assets/Plugins'/ASSEMBLY;need(pin(dll)==audit['current_inputs_unchanged'][0],'Exact current target DLL')
    current=module_methods(dll,[{'owner':PREFIX+o,'name':n,'parameters':p} for o,n,p in [('UniversalRenderPipelineAsset','CreateRenderers',0),('UniversalRenderPipeline','get_asset',0),('ScriptableRendererData','get_isInvalidated',0),('ScriptableRendererData','set_isInvalidated',1)]])
    backing=current_fields(dll,PREFIX+'ScriptableRendererData');backing=[x for x in backing if x['name']=='<isInvalidated>k__BackingField'];need(len(backing)==1 and backing[0]['flags']==1 and backing[0]['signature']=='0602','Current original private bool backing field')
    field_token=int(backing[0]['token'],16).to_bytes(4,'little').hex()
    need(current[2]['IL_bytes']=='027b'+field_token+'2a' and current[3]['IL_bytes']=='02037d'+field_token+'2a','Existing genuine get/set bodies already implement original backing field; no extra accessor restoration required')
    out=ROOT/'Validation'/('CustomURPFactoryCandidates-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    source_text={
      'UniversalRenderPipelineAsset.CreatePipeline.member.cs':'''// Replacement member within ORIGINAL UniversalRenderPipelineAsset only.
// Original MethodDef0600006C, current0600006A. All original fields remain.
protected override UnityEngine.Rendering.RenderPipeline CreatePipeline()
{
    if (m_RendererDataList == null)
        m_RendererDataList = new ScriptableRendererData[1];
    if (m_RendererDataList[m_DefaultRendererIndex] == null)
    {
        if (k_AssetPreviousVersion != k_AssetVersion)
            return null;
        UnityEngine.Debug.LogError(string.Concat("Default Renderer is missing, make sure there is a Renderer assigned as the default on the current Universal RP asset:", UniversalRenderPipeline.asset.name), this);
        return null;
    }
    CreateRenderers();
    return new UniversalRenderPipeline(this);
}
''',
      'ForwardRendererData.Create.member.cs':'''// Replacement member within ORIGINAL ForwardRendererData only.
// Original MethodDef06000152, current06000136. Native Windows-player behavior.
protected override ScriptableRenderer Create()
{
    return new ForwardRenderer(this);
}
''',
      'ScriptableRendererData.InternalCreateRenderer.member.cs':'''// Replacement member within ORIGINAL ScriptableRendererData only.
// Original MethodDef0600022D, current06000203. Existing setter is independently
// proved to store the original private bool backing field; no field is added.
internal ScriptableRenderer InternalCreateRenderer()
{
    isInvalidated = false;
    return Create();
}
'''}
    candidates=[]
    for name,text in source_text.items():
        p=out/name
        with p.open('x',encoding='utf-8',newline='\n') as f:f.write(text)
        candidates.append(pin(p))
    package=Path('C:/Users/andre/AppData/Local/Unity/cache/npm/packages.unity.com/com.unity.render-pipelines.universal/10.8.1/package.tgz');comparisons=[]
    with tarfile.open(package,'r:gz') as archive:
        for member in ['package/Runtime/Data/UniversalRenderPipelineAsset.cs','package/Runtime/ForwardRendererData.cs','package/Runtime/ScriptableRendererData.cs']:
            raw=archive.extractfile(member).read();comparisons.append({'member':member,'raw_sha256':hashlib.sha256(raw).hexdigest(),'comparison_only_native_equivalence_not_assumed':True})
    test_plan={'schema':'three-original-custom-URP-factory-binding-effect-test-plan/v1','status':'Root_compile_and_controlled_effect_tests_not_run','use_exact_existing_current_owner_field_and_method_tokens':True,'preserve_all_unselected_members_metadata_attributes_and_marshal_contracts':True,'cases':['Null data-list creates exactly one original ScriptableRendererData slot, then normal missing-renderer path.','Existing data-list reference and elements retained.','Negative and out-of-range default index preserves IndexOutOfRangeException.','Missing renderer with mismatched asset versions returns null without logging or constructor.','Missing renderer with equal versions logs exact prefix+original current pipeline asset.name, original this context, then null.','Destroyed Unity renderer-data wrapper follows genuine Object.op_Equality null path.','Null UniversalRenderPipeline.asset in error branch preserves NullReferenceException.','Valid renderer calls exact existing CreateRenderers before constructing UniversalRenderPipeline with same asset reference.','Exceptions from CreateRenderers, logging, name access, or constructors propagate.','Forward factory constructor receives same original data and returns exact allocated ForwardRenderer.','InternalCreateRenderer clears exact original backing field before virtual Create, returns same result; thrown Create still leaves false.','Derived virtual Create dispatch remains virtual, including override returning null.'],'native_constructor_and_cache_closure_still_required':True,'Main_modified':False}
    plan=out/'Root-binding-effect-test-plan.json';save(plan,test_plan)
    report={'schema':'three-original-custom-URP-factory-native-CFG-and-CSharp-candidates/v1','status':'three_factory_wrappers_native_proven_candidates_staged_binding_effect_and_constructor_closure_held','Root_decode_receipt':pin(DECODE/'run-report.json'),'Root_decode_output':pin(DECODE/'decoded-original-factories.jsonl'),'audit':pin(AUDIT/'report.json'),'original_inputs':[pin(p) for p in original],'current_DLL':pin(dll),'native_CreatePipeline':pipeline,'native_ForwardRendererData_Create':forward,'native_InternalCreateRenderer':leaf,'original_CreatePipeline_fields':[byoffset[o] for o in [64,72,40,44]],'metadata_uses':uses,'original_error_literal':msg,'raw_backed_native_callee_aliases':calls,'unbacked_alias_tables_not_assumed_empty':gaps,'native_invalidation_accessors':accessors,'current_invalidation_backing_field':backing[0],'current_dependencies':current,'existing_invalidation_get_set_are_original_simple_field_operations':True,'one_byte_negative_controls':controls,'candidates':candidates,'Root_test_plan':pin(plan),'stock_comparison_archive':pin(package),'stock_comparison_members':comparisons,'stock_body_transplant_or_editor_branch_added':False,'remaining_blockers':['Current CreateRenderers remains empty and must recover renderer disposal/cache/creation semantics.','Current UniversalRenderPipeline.asset getter is null; error-logging path requires its genuine original GraphicsSettings/type-cast chain.','UniversalRenderPipeline constructor936B/3regions, ForwardRenderer constructor4160B/6regions, ScriptableRenderer constructor1043B and their call dependencies remain unrecovered.','Full Render/Setup/Execute/pass/custom RecRoom quality graph is not made functional by these three wrappers.'],'safe_to_apply_as_working_renderer':False,'Main_modified':False,'compiler_managed_Unity_player_network_executed':False,'producer':pin(Path(__file__))}
    target=out/'report.json';save(target,report)
    print(json.dumps({'report':pin(target),'candidates':candidates,'negative_controls':len(controls),'existing_invalidation_accessors_proved':True,'current_blockers':[{k:x[k] for k in ['owner','name','IL_bytes','current_CLI_token_not_original_native']} for x in current[:2]],'Main_modified':False}))

if __name__=='__main__':main()
