"""Stage four original URP cache/getter members from complete native scopes.

No compilation/execution of inspected code. These are review candidates only;
renderer construction/disposal behavior remains explicitly separate closure.
"""
from pathlib import Path
import datetime as dt,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from audit_custom_urp_native_loop import pin,save,fields,PREFIX
from collect_all_pinvoke_native import ExternMetadata,need
from audit_boot_candidate_dependency_closure import module_methods
from prove_recroom_ondestroy_native_cfg import aliases
from audit_ogpeg_constructors import Decoder

FOLDER=ROOT/'Validation/CustomURPCompleteDependencies-20261023T090444Z-851a7084'
RECEIPT_SHA='34220f997a961ec45ef388a337e86d2fa1241ba902e94e0bf629457e766bfcc5'
OUTPUT_SHA='38aec540fdedd3da8d27440053fd69064b1b2c8320eeb5204749dda426f1e756'

def destroy_one(code,va):
    d=Decoder(code,va);d.literal('40 53 48 83 ec 20 48 8b 0a 48 8b da 48 85 c9');empty=d.short('74');d.literal('33 d2');dispose=d.relative('e8');d.literal('33 d2 48 c7 03 00 00 00 00 48 8b cb 48 83 c4 20 5b');barrier=d.relative('e9');ret=va+d.at;d.literal('48 83 c4 20 5b c3');d.end()
    need(len(code)==52 and empty==ret and dispose==0x183a65970 and barrier==0x1806bfd30,'Exact original byref disposal/clear/return')
    return {'all52bytes_checked':True,'null_reference':'return without Dispose/store','nonnull_reference':'call original public ScriptableRenderer.Dispose(); then null the SAME captured ref location; retain GC barrier','Dispose_exceptions':'propagate before ref is cleared','Dispose':hex(dispose)}

def destroy_all(code,va):
    d=Decoder(code,va);d.literal('40 56 48 83 ec 20 48 8b 51 20 48 8b f1 48 85 d2');empty=d.short('74');d.literal('48 89 5c 24 30 48 89 6c 24 38 33 ed 48 89 7c 24 40 8b dd 44 8b c5 48 8b c2 0f 1f 44 00 00');loop=va+d.at
    d.literal('44 3b 42 18');finished=d.short('7d');d.literal('48 85 c0');null1=d.short('74');d.literal('3b 58 18');bounds=d.short('73');d.literal('48 63 cb 48 8b d0 48 8d 3c c8 48 8b 4c c8 20 48 85 c9');already_null=d.short('74');d.literal('33 d2');dispose=d.relative('e8');d.literal('33 d2 48 89 6f 20 48 8d 4f 20');barrier=d.relative('e8');d.literal('48 8b 56 20');next_iteration=va+d.at;d.literal('ff c3 48 8b c2 44 8b c3 48 85 d2');null2=d.short('74');back=d.short('eb');restore=va+d.at
    d.literal('48 8b 7c 24 40 48 8b 5c 24 30 48 8b 6c 24 38');epilog=va+d.at;d.literal('48 83 c4 20 5e c3');null_tail=va+d.at;nre=d.relative('e8');d.literal('cc');bounds_tail=va+d.at;index=d.relative('e8');d.literal('48 8b c8 33 d2');raise_=d.relative('e8');d.literal('cc');d.end()
    need(len(code)==168 and empty==epilog and finished==restore and null1==null2==null_tail and bounds==bounds_tail and already_null==next_iteration and back==loop,'Full four-region loop/normal/exception CFG')
    need([dispose,barrier,nre,index,raise_]==[0x183a65970,0x1806bfd30,0x1806c0390,0x1806bff80,0x1806c0360],'Exact original disposal/framework anchors')
    return {'all168bytes_four_original_regions_checked':True,'field_offset':32,'loop':'original int index starts0; each original m_Renderers slot passed by ref to inlined DestroyRenderer semantics; preserves original array ref capture across Dispose and original field re-read','all_internal_branch_edges_closed':True,'exception_behavior':'null initial m_Renderers returns; Dispose exceptions propagate before slot clear; standard null/bounds exception tails retained'}

def get_asset(code,va):
    d=Decoder(code,va);d.literal('48 83 ec 28');flag=d.relative('80 3d','00');initialized=d.short('75');typ=d.relative('48 8d 0d');init=d.relative('e8');written=d.relative('c6 05','01');ready=va+d.at;d.literal('33 c9');get_current=d.relative('e8');d.literal('48 8b d0 48 85 c0');nonnull=d.short('75');d.literal('48 83 c4 28 c3');check=va+d.at;loaded=d.relative('4c 8b 05');d.literal('48 8b 00 41 0f b6 88 2c 01 00 00 38 88 2c 01 00 00');shallow=d.short('72');d.literal('48 8b 80 c8 00 00 00 4c 39 44 c8 f8');wrong=d.short('75');d.literal('33 c0 b1 01 84 c9 48 0f 45 c2 48 83 c4 28 c3');failed=va+d.at;d.literal('33 c0 32 c9 84 c9 48 0f 45 c2 48 83 c4 28 c3');d.end()
    need(len(code)==122 and flag==written==0x188c873f8 and typ==loaded==0x1887e0b08 and initialized==ready and nonnull==check and shallow==wrong==failed and init==0x1806c01e0 and get_current==0x1844aa880,'Exact safe runtime type-test getter')
    return {'all122bytes_checked':True,'type_usage':hex(typ),'GraphicsSettings_get_currentRenderPipeline':hex(get_current),'semantics':'Return null for null or wrong/sub-base type; return SAME exact currentRenderPipeline reference if hierarchy contains UniversalRenderPipelineAsset. This is safe as, not checked cast; no invalid-cast exception is introduced.'}

def decoded_cfg(native,decoded):
    start=int(native['native_pointer'],16);position=start;code=bytes.fromhex(native['runtime_function']['bytes']);instructions=decoded['instructions'];starts={i['ip'] for i in instructions};calls=[];branches=[]
    for i in instructions:
        need(i['ip']==position and i['code']!='INVALID','Actual Root instruction stream covers exact original scope');position+=i['length']
        targets=[p['target'] for p in i['operands'] if p['kind'].startswith('NearBranch')]
        if i['flow']=='Call':need(len(targets)==1,'Direct call operand');calls.append({'ip':hex(i['ip']),'target':hex(targets[0])})
        elif i['flow'] in ('ConditionalBranch','UnconditionalBranch'):
            need(len(targets)==1 and targets[0] in starts,'Every cache-control branch lands on an original decoded instruction');branches.append({'ip':hex(i['ip']),'target':hex(targets[0]),'instruction':i['text']})
        else:need(i['flow'] not in ('IndirectCall','IndirectBranch'),'No guessed indirect cache behavior')
    need(position==start+len(code),'All complete original bytes consumed')
    expected={0x1806c01e0,0x1835dccf0,0x1806bfdb0,0x1806bfd30,0x180640f10,0x183172430,0x183a64db0,0x1806bfd40,0x1801577c0,0x1806c0390,0x1806bff50,0x1806c0360,0x1806bff80}
    need({int(x['target'],16) for x in calls}==expected and len(code)==447,'All original cache calls accounted for')
    memory=[(i['ip'],i['memory']) for i in instructions]
    return {'all447_original_bytes_Root_decoded':True,'all_direct_calls':calls,'all_internal_controlflow_edges':branches,'source_mapping':'Call DestroyRenderers first; reuse m_Renderers only if nonnull with matching m_RendererDataList.Length, otherwise allocate same-length ScriptableRenderer[]; iterate current original data-list, use genuine Unity Object inequality, call original InternalCreateRenderer, store into captured original renderer array with original runtime covariance/null/bounds checks. No null/length/default catch is added.','native_array_store_type_check':'1806BFD40 +1801577C0 preserve standard typed array store/covariance semantics; no game implementation of runtime helper is introduced','metadata_array_usage':'0x18888cba8','metadata_Unity_Object_usage':'0x1887f13e0'}

def main():
    need(pin(FOLDER/'run-report.json')['sha256']==RECEIPT_SHA and pin(FOLDER/'decoded-complete-original-dependencies.jsonl')['sha256']==OUTPUT_SHA,'Root complete-scope decode pins')
    receipt=json.loads((FOLDER/'run-report.json').read_bytes());need(receipt['status']=='original31931B_complete_URP_dependency_scopes_inert_decoded_semantics_pending' and receipt['phases'][0]['exit_code']==0,'Actual Root inert decode passed')
    data=json.loads((FOLDER/'complete-original-dependency-scopes.json').read_bytes());native={x['original']['index']:x for x in data['methods']};decoded={x['native_method_index']:x for x in map(json.loads,(FOLDER/'decoded-complete-original-dependencies.jsonl').read_text().splitlines())}
    shapes={}
    for index,decoder in [(90726,destroy_all),(90727,destroy_one),(91332,get_asset)]:
        row=native[index];shapes[str(index)]=decoder(bytes.fromhex(row['runtime_function']['bytes']),int(row['native_pointer'],16))
    shapes['90730']=decoded_cfg(native[90730],decoded[90730])
    sources=[Path(x['path']) for x in data['original_inputs']]
    for spec in data['original_inputs']:need(pin(spec['path'])==spec,'Original source remains pinned')
    with sources[0].open('rb') as bf,sources[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);uses={hex(x):v.usage(x) for x in [0x1887e0b08,0x18888cba8,0x1887f13e0]};need([uses[hex(x)]['type'] for x in [0x1887e0b08,0x18888cba8,0x1887f13e0]]==[PREFIX+'UniversalRenderPipelineAsset',PREFIX+'ScriptableRenderer[]','UnityEngine.Object'],'Original type-test/array/Unity null identities')
        targets={0x183a65970,0x1844aa880,0x183172430,0x183a64db0};calls,gaps=aliases(v,targets);required={0x183a65970:(PREFIX+'ScriptableRenderer','Dispose'),0x1844aa880:('UnityEngine.Rendering.GraphicsSettings','get_currentRenderPipeline'),0x183172430:('UnityEngine.Object','op_Inequality'),0x183a64db0:(PREFIX+'ScriptableRendererData','InternalCreateRenderer')}
        for pointer,(owner,name) in required.items():need(any(x['owner']==owner and x['name']==name for x in calls[hex(pointer)]),'Exact typed shared callee')
        fs=fields(v,native[90730]['original']['owner_index']);f=[x for x in fs if x['name'] in ('m_Renderers','m_RendererDataList')];need({x['name']:x['offset'] for x in f}=={'m_Renderers':32,'m_RendererDataList':64},'Exact original array fields')
    dll=WS/'RR23/Assets/Plugins/Unity.RenderPipelines.Universal.Runtime.dll'
    current=module_methods(dll,[{'owner':PREFIX+o,'name':n,'parameters':p} for o,n,p in [('UniversalRenderPipelineAsset','DestroyRenderers',0),('UniversalRenderPipelineAsset','DestroyRenderer',1),('UniversalRenderPipelineAsset','CreateRenderers',0),('UniversalRenderPipeline','get_asset',0),('ScriptableRenderer','Dispose',0)]])
    out=ROOT/'Validation'/('CustomURPSharedCacheCandidates-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    texts={'UniversalRenderPipelineAsset.RendererCache.members.cs':'''// Replace ONLY these existing original members in UniversalRenderPipelineAsset.
// Native DestroyRenderers0600006D,DestroyRenderer0600006E,CreateRenderers06000071.
private void DestroyRenderers()
{
    if (m_Renderers == null)
        return;
    for (int i = 0; i < m_Renderers.Length; i++)
        DestroyRenderer(ref m_Renderers[i]);
}

private void DestroyRenderer(ref ScriptableRenderer renderer)
{
    if (renderer != null)
    {
        renderer.Dispose();
        renderer = null;
    }
}

private void CreateRenderers()
{
    DestroyRenderers();
    if (m_Renderers == null || m_Renderers.Length != m_RendererDataList.Length)
        m_Renderers = new ScriptableRenderer[m_RendererDataList.Length];
    for (int i = 0; i < m_RendererDataList.Length; ++i)
    {
        if (m_RendererDataList[i] != null)
            m_Renderers[i] = m_RendererDataList[i].InternalCreateRenderer();
    }
}
''','UniversalRenderPipeline.asset.member.cs':'''// Replace ONLY existing original property getter UniversalRenderPipeline.asset.
// Native MethodDef060002CB/current0600029C; preserve its original property metadata.
public static UniversalRenderPipelineAsset asset
{
    get { return UnityEngine.Rendering.GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset; }
}
'''}
    candidates=[]
    for name,text in texts.items():
        p=out/name
        with p.open('x',encoding='utf-8',newline='\n') as file:file.write(text)
        candidates.append(pin(p))
    report={'schema':'four-original-custom-URP-shared-cache-getter-candidates/v1','status':'four_original_members_staged_typed_native_proven_binding_effect_and_constructor_closure_held','Root_decode_receipt':pin(FOLDER/'run-report.json'),'Root_decode_output':pin(FOLDER/'decoded-complete-original-dependencies.jsonl'),'source_input':pin(FOLDER/'complete-original-dependency-scopes.json'),'original_inputs':[pin(p) for p in sources],'original_members':[native[i] for i in [90726,90727,90730,91332]],'exact_shapes':shapes,'metadata_uses':uses,'original_fields':f,'typed_raw_backed_callees':calls,'unbacked_direct_tables_not_assumed_empty':gaps,'current_DLL':pin(dll),'current_methods':current,'candidates':candidates,'Root_binding_effect_cases':['DestroyRenderers null/empty array preserves array identity and returns.','Dispose every nonnull original slot once in index order, clear same captured original ref only after successful Dispose.','Throwing Dispose propagates with current and later refs unchanged.','CreateRenderers calls destroy before checking/replacing renderer array.','Matching-length array identity preserved; changed length or null cache allocates exactly original data-list length.','Null data-list preserves original NullReferenceException after destroy.','Null/destroyed Unity rendererData skipped using actual Unity inequality.','Virtual Create receives same rendererData and can return null or throw; covariance/null/bounds exceptions propagate.','Current render pipeline null or wrong type yields null; correct type/subclass returns identical reference.'],'safe_to_apply_as_working_renderer':False,'remaining_blockers':['Original ScriptableRenderer.Dispose and virtual concrete disposal closure remain required; its current body is ret.','All original constructors and full custom pipeline/frame/pass dependencies remain held.','Actual source binding and controlled compiled effects have not run.'],'Main_modified':False,'compiler_managed_Unity_player_network_executed':False,'producer':pin(Path(__file__))}
    target=out/'report.json';save(target,report)
    print(json.dumps({'report':pin(target),'candidates':candidates,'current_Dispose_IL':current[-1]['IL_bytes'],'Main_modified':False}))

if __name__=='__main__':main()
