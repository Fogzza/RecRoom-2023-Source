"""Read-only custom URP stub/registration/complete chained-region audit.

Only parses original PE/metadata and current CLI bytes. Emits inert decoder
inputs outside RR23; never loads target code or starts a child process.
"""
from pathlib import Path
import bisect, datetime as dt, hashlib, json, mmap, struct, sys, uuid

HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]
ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED
from audit_boot_candidate_dependency_closure import module_methods
from prove_service_container_getter_native import header_layout
from audit_ogpeg_constructors import Decoder

ASSEMBLY='Unity.RenderPipelines.Universal.Runtime.dll'
PREFIX='UnityEngine.Rendering.Universal.'
# Exact original token, native MethodDef index, registration, full chained bytes.
SPECS=[
 ('UniversalRenderPipelineAsset','CreatePipeline',0x0600006c,90725,0x1835dc940,420),
 ('UniversalRenderPipelineAsset','CreateRenderers',0x06000071,90730,0x1835dcaf0,447),
 ('UniversalRenderPipelineAsset','GetRenderer',0x06000074,90733,0x1835dcda0,848),
 ('ScriptableRenderer','.ctor',0x06000107,90880,0x183a6b7a0,1043),
 ('ScriptableRenderer','Execute',0x06000111,90890,0x183a66030,3700),
 ('ForwardRenderer','.ctor',0x06000141,90938,0x1836b1100,4160),
 ('ForwardRenderer','Setup',0x06000144,90941,0x1836af440,7349),
 ('ForwardRendererData','Create',0x06000152,90955,0x1836adcf0,84),
 ('ScriptableRendererData','InternalCreateRenderer',0x0600022d,91174,0x183a64db0,32),
 ('UniversalRenderPipeline','.ctor',0x060002b4,91309,0x1835e5a40,936),
 ('UniversalRenderPipeline','Render',0x060002b6,91311,0x1835e46d0,1096),
 ('UniversalRenderPipeline','RenderSingleCamera',0x060002b8,91313,0x1835e2ff0,775),
 ('UniversalRenderPipeline','RenderSingleCamera',0x060002ba,91315,0x1835e3300,5063),
 ('UniversalRenderPipeline','RenderCameraStack',0x060002bb,91316,0x1835e1970,5342),
 ('UniversalRenderPipeline','.cctor',0x060002d3,91340,0x1835e5700,830),
]

def pin(path):
    p=Path(path).resolve(strict=True)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}

def save(path,value):
    with Path(path).open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')

def pdata(v):
    opt=v.u32(v.b,60)+24;rva,size=struct.unpack_from('<II',v.b,opt+136)
    need(0<size<=16*1024**2 and size%12==0,'Bounded full pdata table')
    at=v.raw(v.base+rva,size);rows=list(struct.iter_unpack('<III',v.b[at:at+size]))
    need(rows==sorted(rows) and len({r[0] for r in rows})==len(rows),'Sorted unique native regions')
    parents={}
    for row in rows:
        start,end,unwind=row;need(start<end,'Positive native interval')
        p=v.raw(v.base+unwind,4);version=v.b[p]&7;flags=v.b[p]>>3;count=v.b[p+2]
        if flags&4:
            need(version==1 and flags==4,'Version1 pure chaininfo grammar')
            a=v.raw(v.base+unwind+((4+2*count+3)&~3),12)
            parent=struct.unpack_from('<III',v.b,a);parents[row]=parent
    rowset=set(rows)
    need(all(parent in rowset for parent in parents.values()),'Every chain parent is a real pdata row')
    return rows,parents

def scopes(v,method,rows,parents):
    pointer=v.method_pointer(method);matches=[r for r in rows if r[0]==pointer-v.base]
    if not matches:
        need(method['index']==91174 and pointer==0x183a64db0,'Only exact known leaf lacks pdata')
        starts=[r[0] for r in rows];n=bisect.bisect_left(starts,pointer-v.base)
        need(rows[n][0]+v.base==pointer+32 and rows[n-1][1]<pointer-v.base,'Leaf does not overlap pdata')
        a=v.raw(pointer,32);code=bytes(v.b[a:a+32])
        need(code==bytes.fromhex('488b01c6411800488b908001000048ffa078010000'+'cc'*11),'Exact21B tail plus11B padding')
        return {'native_pointer':hex(pointer),'runtime_function':{'start_rva':pointer-v.base,'end_rva':pointer-v.base+32,'unwind_rva':None,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'scope':'Registered leaf through next registered/pdata entry;21 semantic bytes plus11 int3 padding'},'original_runtime_regions':[],'complete_connected_chain_region_count':0,'leaf_semantic_bytes':21,'padding_bytes':11,'whole_method_CFG_or_CSharp_recovery_claimed':False}
    need(len(matches)==1 and matches[0] not in parents,'Exact original unchained registered root')
    root=matches[0];linked={root}
    while True:
        more={child for child,parent in parents.items() if parent in linked}-linked
        if not more:break
        linked|=more;need(len(linked)<=32,'Bounded chained descendants')
    ordered=sorted(linked);details=[]
    for i,(start,end,unwind) in enumerate(ordered):
        need(not i or ordered[i-1][1]==start,'Only proved contiguous chain closure admitted')
        a=v.raw(v.base+start,end-start);code=bytes(v.b[a:a+end-start]);u=v.raw(v.base+unwind,4)
        details.append({'start_rva':start,'end_rva':end,'unwind_rva':unwind,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'unwind_header':bytes(v.b[u:u+4]).hex(),'chained_parent_runtime_function':list(parents[(start,end,unwind)]) if (start,end,unwind) in parents else None})
    combined=b''.join(bytes.fromhex(r['bytes']) for r in details)
    need(len(combined)<=32768,'Finite per-method inert data budget')
    return {'native_pointer':hex(pointer),'runtime_function':{'start_rva':ordered[0][0],'end_rva':ordered[-1][1],'unwind_rva':root[2],'bytes':combined.hex(),'sha256':hashlib.sha256(combined).hexdigest(),'scope':'All contiguous descendants of exact original pdata root; not one fabricated pdata row'},'original_runtime_regions':details,'complete_connected_chain_region_count':len(ordered),'whole_method_CFG_or_CSharp_recovery_claimed':False}

def fields(v,ti):
    td=v.row('typeDefinitions',ti,88);start=v.i32(v.m,td+32);count=v.u16(v.m,td+68)
    at=v.raw(v.u64(v.b,v.field_offsets+ti*8),count*4);out=[]
    for n in range(count):
        f=v.row('fields',start+n,12);nt=v.native_type(v.i32(v.m,f+4))
        out.append({'name':v.string(v.i32(v.m,f)),'token':hex(v.u32(v.m,f+8)),'type':v.typename(nt),'flags':nt['attributes'],'offset':v.i32(v.b,at+n*4)})
    return out

def leaf_contract(v):
    method=v.method_info(91174);ti=method['owner_index'];fs=fields(v,ti)
    field=[f for f in fs if f['offset']==24]
    need(len(field)==1 and field[0]['name']=='<isInvalidated>k__BackingField' and field[0]['type']=='System.Boolean','Exact original backing field')
    layout=header_layout();need(layout['vtable_offset']==0x138 and layout['VirtualInvokeData_bytes']==16,'Matching genuine runtime vtable layout')
    target=v.find_method(PREFIX+'ForwardRendererData',0x06000152)
    abstract=v.find_method(PREFIX+'ScriptableRendererData',0x0600022a)
    slots=[v.u16(v.m,v.row('methods',r['index'],32)+28) for r in [target,abstract]]
    need(slots==[4,4] and abstract['flags']&1024,'Exact original Create override slot4')
    td=v.row('typeDefinitions',target['owner_index'],88);start=v.i32(v.m,td+56)
    encoded=v.u32(v.m,v.row('vtableMethods',start+4,4));need(encoded>>29==3 and (encoded&0x1fffffff)>>1==90955,'Concrete original forward slot4 mapping')
    return {'semantic_bytes':21,'padding_bytes':11,'field':field[0],'native_class_layout':layout,'virtual_slot':4,'method_pointer_offset':0x178,'MethodInfo_offset':0x180,'abstract_contract':abstract,'configured_forward_override':target,'concrete_vtable_encoded':hex(encoded),'fully_literal_shape':'load this klass; write original isInvalidated backing field false; tail dispatch unchanged this to actual virtual Create slot4 with its MethodInfo','source_replacement_emitted':False,'dependency_warning':'Restoring this wrapper alone still invokes the unrecovered ForwardRendererData.Create/ForwardRenderer constructor.'}

def factory_shape(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 57 48 83 ec 20')
    flag=d.relative('80 3d','00');d.literal('48 8b f9');skip=d.short('75')
    klass=d.relative('48 8d 0d');init=d.relative('e8');written=d.relative('c6 05','01');ready=va+d.at
    loaded=d.relative('48 8b 0d');allocate=d.relative('e8')
    d.literal('45 33 c0 48 8b d7 48 8b c8 48 8b d8');ctor=d.relative('e8')
    d.literal('48 8b c3 48 8b 5c 24 30 48 83 c4 20 5f c3');d.end()
    need(len(code)==84 and flag==written and skip==ready and klass==loaded,'All original metadata-guard CFG edges')
    need(init==0x1806c01e0 and allocate==0x1806c0340 and ctor==0x1836b1100,'Exact original init/allocation/constructor anchors')
    return {'all84bytes_opcodes_and_CFG_checked':True,'metadata_guard_flag':hex(flag),'class_usage':hex(klass),'metadata_initialize_helper':hex(init),'allocation_helper':hex(allocate),'constructor':hex(ctor),'argument_flow':'RDI preserves original ForwardRendererData this; RCX receives new ForwardRenderer, RDX original data, R8 null hidden MethodInfo; return exact allocated instance in RBX','constructor_behavior_recovered':False}

def factory_contract(v,row):
    code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);shape=factory_shape(code,va)
    usage=v.usage(int(shape['class_usage'],16));need(usage['kind']==1 and usage['type']==PREFIX+'ForwardRenderer','Exact original allocation class')
    ctor=v.find_method(PREFIX+'ForwardRenderer',0x06000141)
    need(v.method_pointer(ctor)==int(shape['constructor'],16) and [p['type'] for p in ctor['parameters']]==[PREFIX+'ForwardRendererData'],'Exact typed constructor dependency')
    controls=[]
    for i in range(len(code)):
        changed=bytearray(code);changed[i]^=1
        try:factory_shape(bytes(changed),va)
        except (ValueError,struct.error):controls.append(i)
        else:raise ValueError('One-byte factory mutation accepted at '+str(i))
    return {'shape':shape,'allocation_class_usage':usage,'exact_original_constructor':ctor,'one_byte_mutations_rejected_at_every_original_byte':controls,'replacement_CSharp_written':False,'construction_closure_held':True}

def main():
    paths=[ROOT/'CodeSource'/r for r in EXPECTED]
    native_pins=[pin(p) for p in paths]
    need(all(p['sha256']==EXPECTED[Path(p['path']).relative_to(ROOT/'CodeSource').as_posix()] for p in native_pins),'Original input SHA pins')
    dll=WS/'RR23/Assets/Plugins'/ASSEMBLY
    witnesses=[dll,dll.with_suffix('.dll.meta'),WS/'RR23/Assets/Plugins/Unity.RenderPipelines.Core.Runtime.dll',WS/'RR23/ProjectSettings/GraphicsSettings.asset',WS/'RR23/Assets/MonoBehaviour/URP-Default.asset',WS/'RR23/Assets/MonoBehaviour/ForwardRenderer.asset']
    before=[pin(p) for p in witnesses]
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);runtime_rows,parents=pdata(v);methods=[]
        for owner,name,token,index,pointer,size in SPECS:
            method=v.find_method(PREFIX+owner,token)
            need(method['index']==index and method['image']==ASSEMBLY and method['name']==name and v.method_pointer(method)==pointer,'Exact original member join')
            row={'original':method,**scopes(v,method,runtime_rows,parents)}
            need(len(bytes.fromhex(row['runtime_function']['bytes']))==size,'Exact original full native scope size')
            methods.append(row)
        registrations=[];unbacked=[]
        for image,module in v.modules.items():
            if not module['count']:continue
            try:a=v.raw(module['pointers_va'],module['count']*8)
            except ValueError as error:unbacked.append({'image':image,'reason':str(error)});continue
            registrations.extend((v.u64(b,a+i*8),image,hex(0x06000000|i+1)) for i in range(module['count']))
        generics=[(v.u64(b,v.generic_pointers+i*8),i) for i in range(v.generic_pointer_count)]
        for row in methods:
            lo=int(row['native_pointer'],16);hi=v.base+row['runtime_function']['end_rva']
            direct=[{'pointer':hex(p),'image':image,'token':token} for p,image,token in registrations if lo<=p<hi]
            generic=[{'pointer':hex(p),'generic_pointer_index':i} for p,i in generics if lo<=p<hi]
            need(all(int(r['pointer'],16)==lo for r in direct+generic),'No distinct registered start absorbed by native scope')
            row['registered_entries_inside_scope']={'raw_backed_direct':direct,'generic_rows':generic,'unbacked_direct_tables_not_assumed_empty':unbacked}
        leaf=leaf_contract(v)
        factory=factory_contract(v,next(r for r in methods if r['original']['index']==90955))
    current=[]
    for row in methods:
        m=row['original'];selector={'owner':m['owner'],'name':m['name'],'parameters':len(m['parameters'])}
        c=module_methods(dll,[selector])[0]
        # The two RenderSingleCamera overloads have different argument counts.
        current.append({'original_method_index':m['index'],'original_token':m['token'],**c})
    need(before==[pin(p) for p in witnesses] and native_pins==[pin(p) for p in paths],'All inspected original/current inputs unchanged')
    out=ROOT/'Validation'/('CustomURPNativeLoopAudit-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    groups={'factory-wrappers':[90725,90955,91174],'constructor-chain':[90880,90938,91309],'asset-renderer-cache':[90730,90733],'frame-render-chain':[90890,90941,91311,91313,91315,91316],'pipeline-static-initializer':[91340]}
    inputs=[]
    for label,indices in groups.items():
        rows=[r for r in methods if r['original']['index'] in indices]
        source=out/(label+'-inert-input.json')
        save(source,{'schema':'bounded-original-custom-URP-native-input/v1','original_inputs':native_pins,'methods':rows,'original_bytes':sum(len(bytes.fromhex(r['runtime_function']['bytes'])) for r in rows),'all_chained_pdata_descendants_included':True,'leaf_scope_includes_only_verified_int3_padding':True,'complete_CFG_or_CSharp_behavior_claimed':False})
        inputs.append({'group':label,**pin(source),'method_indices':indices,'original_bytes':sum(len(bytes.fromhex(r['runtime_function']['bytes'])) for r in rows)})
    prior=ROOT/'RuntimeSDKRecovery/OriginalRenderingSDKSourceAudit-20261022T191640Z-2b069d5d/report.json'
    report={'schema':'custom-original-URP-render-loop-read-only-native-scope-audit/v1','status':'exact_native_scopes_and_current_stubs_inert_inputs_ready_CSharp_recovery_held','original_inputs':native_pins,'current_inputs_unchanged':before,'producer':pin(Path(__file__)),'pdata_rows_examined':len(runtime_rows),'chaininfo_rows_examined':len(parents),'native_methods':methods,'actual_current_DLL_methods':current,'smallest_literal_wrapper_native_contract':leaf,'ForwardRendererData_Create_native_contract':factory,'inert_inputs':inputs,'prior_custom_fork_vs_cached_stock_audit':pin(prior),'smallest_next_recovery_slice':['Decode the536B three-factory input, including21B leaf plus11B padding. The leaf and84B ForwardRendererData.Create have literal/typed proofs here; CreatePipeline still needs complete decode and call/metadata/branch joins.','ForwardRendererData.Create invokes the exact original4160B ForwardRenderer constructor. Its closure, including possible1043B ScriptableRenderer constructor dependency, still requires decode. The936B pipeline constructor and447B renderer-cache creation are next exact scopes to inspect; their invocation by CreatePipeline is not inferred from names.','Then close render-loop1096B caller and genuine original camera/renderer/pass callees after actual instruction joins; no factory-only result may be called working URP.'],'stock_replacement_permitted':False,'Main_modified':False,'finalized_shader_tools_modified':False,'managed_compiler_Unity_player_network_or_target_library_executed':False,'CSharp_candidate_written':False}
    target=out/'report.json';save(target,report)
    print(json.dumps({'report':pin(target),'inputs':inputs,'stub_tokens':[{'original':r['original_token'],'current':r['current_CLI_token_not_original_native'],'IL':r['IL_bytes']} for r in current if r['original_method_index'] in [90725,90955,91174,91311]],'native_methods':len(methods),'Main_modified':False}))

if __name__=='__main__':main()
