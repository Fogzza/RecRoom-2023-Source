"""Close Awake property/delegate/GC-barrier joins and stage four native methods.
Only original bytes/metadata are read. No project application or game execution.
"""
from pathlib import Path
import base64, datetime as dt, hashlib, json, mmap, struct, sys, uuid
HERE=Path(__file__).resolve().parent; WS=HERE.parents[2]; ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from prove_recroom_awake_native_cfg import decode
PROOF=ROOT/'Validation/RecRoomAwakeClosedCFG-20261022T172106Z-6b7b4e03/report.json'
PRIOR=ROOT/'Validation/RecRoomBootThreeMethodCandidate-20261022T171122Z-5030577a/report.json'
DELEGATE=ROOT/'Validation/RecRoomOnDestroyCandidate-20261022T164012Z-5abddbac/report.json'

def export(v,name):
    opt=v.u32(v.b,60)+24;table=v.raw(v.base+v.u32(v.b,opt+112),40);functions=v.u32(v.b,table+20);names=v.u32(v.b,table+24)
    need(0<names<=functions<=65536,'Bounded original PE exports')
    f=v.raw(v.base+v.u32(v.b,table+28),functions*4);n=v.raw(v.base+v.u32(v.b,table+32),names*4);o=v.raw(v.base+v.u32(v.b,table+36),names*2);hits=[]
    for i in range(names):
        text=v.cstr(v.base+v.u32(v.b,n+i*4))
        if text!=name:continue
        ordinal=v.u16(v.b,o+i*2);need(ordinal<functions,'Original export ordinal bound');hits.append(v.base+v.u32(v.b,f+ordinal*4))
    need(len(hits)==1,'Unique original runtime export required: '+name);return hits[0]

def native_property(v,method):
    t=v.row('typeDefinitions',method['owner_index'],88);first=v.i32(v.m,t+36);start=v.i32(v.m,t+44);count=v.u16(v.m,t+66);rows=[]
    for i in range(count):
        at=v.row('properties',start+i,20);get=v.i32(v.m,at+4);set=v.i32(v.m,at+8)
        if get>=0 and first+get==method['index']:
            rows.append({'native_index':start+i,'name':v.string(v.i32(v.m,at)),'token':hex(v.u32(v.m,at+16)),'flags':v.u32(v.m,at+12),'getter_native_method_index':first+get,'setter_native_method_index':first+set if set>=0 else None})
    need(len(rows)==1,'Exact original PropertyDef/getter ownership required');return rows[0]

def main():
    need(sha(PROOF)=='c671f9b39c2e9f3d93697b5b0e04cecb2fe5c654512d6c3277ca73ccbf751a7c','Awake native proof changed')
    need(sha(PRIOR)=='2a8dbccdbd86f42f4b056fe25e031dbb22bc2c6fcb17eb070f63727af5570ca7' and sha(DELEGATE)=='ff8ecfa5222433047ef318bf49b5c271ecea332ca149d4ae3573d1a827e50a77','Prior typed candidates changed')
    p=json.loads(PROOF.read_text());prior=json.loads(PRIOR.read_text());delegate=json.loads(DELEGATE.read_text());shape=p['exact_native_control_flow'];code=bytes.fromhex(p['native_code']);va=int(p['native_pointer'],16);need(decode(code,va)==shape,'Closed original Awake CFG drift')
    paths=[ROOT/'CodeSource'/r for r in EXPECTED]
    for path in paths:need(sha(path)==EXPECTED[path.relative_to(ROOT/'CodeSource').as_posix()],'Original full source changed')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);original=v.find_method('RecRoomGameRoot',0x060026bf);need(v.method_pointer(original)==va and bytes(b[v.raw(va,256):v.raw(va,256)+256])==code,'Fresh original Awake registration and all256bytes')
        base_use=v.usage(int(shape['metadata_D_base_method'],16));value_use=v.usage(int(shape['metadata_B_value_method'],16));class_use=v.usage(int(shape['metadata_A_delegate_class'],16));callback_use=v.usage(int(shape['metadata_C_callback_method'],16))
        need(base_use['kind']==6 and base_use['method']['owner']=='SingletonMonoBehaviour`1' and base_use['method']['name']=='Awake' and base_use['class_argument_types']==['GameRoot'] and not base_use['method_argument_types'],'Exact generic base Awake identity')
        need(value_use['kind']==6 and value_use['method']['owner']=='MNALHHOLFGL' and value_use['method']['name']=='HHCPOGCCGNF' and value_use['method']['image']=='UJect.Runtime.dll' and value_use['method_argument_types']==['MFENCGHNPBJ'] and not value_use['class_argument_types'] and [q['type'] for q in value_use['method']['parameters']]==['System.String'] and not value_use['method']['flags']&16,'Exact original typed memory-service resolver(null)')
        registrations=v.generic_targets({base_use['index'],value_use['index']})
        for use,key in [(base_use,'base_call'),(value_use,'value_method_call')]:need(len(registrations[use['index']])==1 and registrations[use['index']][0]['pointer']==shape[key] and registrations[use['index']][0]['adjustor_thunk_index']==-1,'Exact original generic target registration')
        service=p['raw_backed_direct_pointer_aliases'][shape['service_getter_call']];need(len(service)==1,'Unique original service getter pointer');service=service[0]
        need(service['owner']=='MPAAIECKLGA' and service['image']=='RecRoom.AgInitialization.Runtime.dll' and service['name']=='PNFLFFOAING' and service['return']=='MNALHHOLFGL' and not service['parameters'] and service['flags']&16 and v.method_pointer(service)==int(shape['service_getter_call'],16),'Exact static original service getter')
        prop=native_property(v,service);need(prop['name'].isidentifier(),'Legal exact original service property identifier required')
        need(class_use['kind']==1 and class_use['type']==delegate['native_delegate_type']['name'] and callback_use['kind']==3 and callback_use['method']['index']==delegate['native_callback']['index'],'Exact original lowMemory delegate/callback types')
        ctor=v.method_info(delegate['native_typed_constructor']['index']);need(v.method_pointer(ctor)==int(shape['delegate_constructor'],16),'Exact allocated typed delegate ctor registration')
        events=[]
        for key,name in [('first_event_call','remove_lowMemory'),('second_event_tail_call','add_lowMemory')]:
            rows=p['raw_backed_direct_pointer_aliases'][shape[key]];need(len(rows)==1,'Unique typed event accessor');m=rows[0]
            need(m['owner']=='UnityEngine.Application' and m['name']==name and m['image']=='UnityEngine.CoreModule.dll' and m['return']=='System.Void' and [a['type'] for a in m['parameters']]==['UnityEngine.Application/LowMemoryCallback'] and m['flags']&16 and v.method_pointer(m)==int(shape[key],16),'Exact original event remove/add ordering');events.append(m)
        barrier=int(shape['post_store_barrier_call'],16);barrier_bytes=bytes(b[v.raw(barrier,5):v.raw(barrier,5)+5]);need(barrier_bytes[0]==0xe9,'Original post-store barrier must be exact single tail jump');barrier_target=barrier+5+struct.unpack_from('<i',barrier_bytes,1)[0]
        exported=export(v,'il2cpp_gc_wbarrier_set_field');export_code=bytes(b[v.raw(exported,11):v.raw(exported,11)+11]);need(export_code[:7]==bytes.fromhex('488bca4c8902e9'),'Original public GC-barrier export must move field address/store then tail jump');export_target=exported+11+struct.unpack_from('<i',export_code,7)[0];need(export_target==barrier_target and v.executable(barrier_target),'Export-anchored exact same GC post-store target')
        barrier_proof={'post_store_helper':hex(barrier),'post_store_helper_code':barrier_bytes.hex(),'public_original_export':'il2cpp_gc_wbarrier_set_field','export_address':hex(exported),'export_code':export_code.hex(),'same_original_post_store_target':hex(barrier_target),'existing_stfld_is_preserved_and_managed_GC_handles_write_barrier':True}
    source=Path(prior['source']);need(sha(source)==prior['source_sha256'] and sha(str(source)+'.meta')==prior['source_meta_sha256'],'Main source/meta baseline drift');raw=source.read_bytes();declaration=b'\tprotected override void Awake()\r\n\t{\r\n\t}\r\n';need(raw.count(declaration)==1,'Unique actual empty Awake source')
    body=('{'+'\r\n\t\tbase.Awake();\r\n\t\tJBOKGAJENGP = global::MPAAIECKLGA.'+prop['name']+'.HHCPOGCCGNF<global::MFENCGHNPBJ>(null);\r\n\t\tUnityEngine.Application.lowMemory -= new UnityEngine.Application.LowMemoryCallback(ADNHOPPILKF);\r\n\t\tUnityEngine.Application.lowMemory += new UnityEngine.Application.LowMemoryCallback(ADNHOPPILKF);\r\n\t}').encode()
    start=raw.index(declaration)+declaration.index(b'{');edits=prior['byte_edits']+[{'start':start,'length':5,'original_base64':base64.b64encode(raw[start:start+5]).decode(),'replacement_base64':base64.b64encode(body).decode(),'original_method_token':'0x060026bf'}];spans=sorted(edits,key=lambda e:e['start']);need(all(a['start']+a['length']<=b['start'] for a,b in zip(spans,spans[1:])),'Four disjoint original method/initializer source edits');candidate=raw
    for e in reversed(spans):candidate=candidate[:e['start']]+base64.b64decode(e['replacement_base64'])+candidate[e['start']+e['length']:]
    out=ROOT/'Validation'/('RecRoomBootFourMethodCandidate-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();target=out/'RecRoomGameRoot.cs';target.write_bytes(candidate)
    report={'schema':'four-original-RecRoomGameRoot-source-method-candidates/v1','status':'native_allbytes_metadata_property_generic_GC_and_event_identities_proved_CSharp_compile_pending','source':str(source),'source_sha256':sha(source),'source_meta_sha256':sha(str(source)+'.meta'),'candidate':str(target),'candidate_sha256':sha(target),'byte_edits':edits,'input_proof':[{'path':str(p),'sha256':sha(p)} for p in [PROOF,PRIOR,DELEGATE]+paths],'exact_original_service_property':prop,'exact_original_service_getter':service,'exact_original_generic_service_resolver':value_use,'exact_original_base_call':base_use,'generic_registrations':registrations,'event_accessor_order':events,'GC_write_barrier_export_proof':barrier_proof,'native_method_count':4,'CSharp_bindings_and_compiled_effects_proven':False,'original_BootSequence_Singleton_or_service_bodies_recovered_by_this_candidate':False,'main_or_harness_modified':False,'game_or_native_code_executed':False};rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':sha(rp),'candidate_sha256':sha(target),'service_property':prop,'GC_barrier':barrier_proof,'native_method_count':4}))

if __name__=='__main__':main()
