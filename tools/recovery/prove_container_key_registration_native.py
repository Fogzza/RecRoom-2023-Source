"""Original JON generic key construction and direct registration dependency."""
from pathlib import Path
import datetime as dt,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_ogpeg_constructors import Decoder,fields
from inventory_recroom_game_root_native import region
from prove_recroom_ondestroy_native_cfg import aliases
from prove_container_binding_tail_native import rgctx

def decode(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 48 89 6c 24 10 48 89 74 24 18 48 89 7c 24 20 41 56 48 83 ec 70')
    flag=d.relative('80 3d','00');d.literal('49 8b f1 49 8b e8 4c 8b f2 48 8b f9');skip=d.short('75');A=d.relative('48 8d 0d');init=d.relative('e8');written=d.relative('c6 05','01');ready=va+d.at
    loadA=d.relative('48 8b 0d');d.literal('0f 57 c0 48 8b 5e 30 0f 57 c9 0f 11 44 24 40 0f 11 4c 24 30 f6 81 33 01 00 00 04 48 8b 1b');noinit1=d.short('74');d.literal('83 b9 e0 00 00 00 00');noinit2=d.short('75');cctor=d.relative('e8');cctor_done=va+d.at
    d.literal('33 d2 48 8b cb');type1=d.relative('e8');d.literal('45 33 c9 48 8d 4c 24 40 4d 8b c6 48 8b d0');key1=d.relative('e8')
    d.literal('48 8b 4e 30 33 d2 48 8b 49 08');type2=d.relative('e8');d.literal('45 33 c9 48 8d 4c 24 30 45 33 c0 48 8b d0');key2=d.relative('e8')
    d.literal('48 85 ff');null=d.short('74')
    d.literal('0f 28 44 24 30 4c 8d 44 24 50 0f 28 4c 24 40 48 8d 54 24 60 4c 8b cd 66 0f 7f 44 24 50 48 8b cf 66 0f 7f 4c 24 60 48 c7 44 24 20 00 00 00 00');register=d.relative('e8')
    d.literal('4c 8d 5c 24 70 49 8b 5b 10 49 8b 6b 18 49 8b 73 20 49 8b 7b 28 49 8b e3 41 5e c3');nulltarget=va+d.at;nre=d.relative('e8');d.literal('cc');d.end()
    need(flag==written and skip==ready and A==loadA and noinit1==noinit2==cctor_done and null==nulltarget,'Every original generic-key CFG branch')
    need(init==0x1806c01e0 and cctor==0x180640f10 and type1==type2==0x183d98380 and key1==key2 and nre==0x1806c0390,'Known original runtime/framework and common key constructor')
    return {'metadata_type':hex(A),'key_constructor':hex(key1),'direct_registration_call':hex(register),'generic_context_type_slots':[0,1],'key0_arguments':['typeof(TInterface)','original name'],'key1_arguments':['typeof(TImpl)',None],'registration_arguments':['original this','whole key0 byvalue copy atstack96','whole key1 byvalue copy atstack80','original provider','null hidden MethodInfo'],'null_this_exception_branch_checked':True,'whole16byte_key_copies_preserved':True,'all272native_bytes_checked':True,'callee_saved_and_stack_restored':True}

def loose_context(v,image,token):
    at=v.raw(v.modules[image]['va'],96);count=v.u64(v.b,at+64);p=v.raw(v.u64(v.b,at+72),count*12);total=v.u64(v.b,at+80);data=v.u64(v.b,at+88);hits=[]
    for i in range(count):
        t,s,l=struct.unpack_from('<Iii',v.b,p+i*12)
        if t==token:hits.append((s,l))
    need(len(hits)==1,'Original generic-key RGCTX range unique');s,l=hits[0];need(l==2 and 0<=s<s+l<=total,'Exact two generic-key type slots');result=[]
    for n in range(l):
        raw=v.raw(data+(s+n)*8,8);kind,index=struct.unpack_from('<ii',v.b,raw);need(kind==1,'Only original TYPE slots for two generic args');t=v.native_type(index);need(t['kind']==30,'Original method generic parameters');result.append({'slot':n,'kind':kind,'index':index,'type':v.typename(t),'native_type':t})
    return result

def main():
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source SHA differs')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);m=v.find_method('MNALHHOLFGL',0x06000017);registration=v.generic_targets({452784})[452784];need(len(registration)==1 and registration[0]['pointer']=='0x1813b9920','Exact original reference-shared registration')
        defidx,ci,gi=struct.unpack_from('<iii',b,v.method_specs+452784*12);need(defidx==m['index'] and ci==-1 and [v.typename(t) for t in v.inst(gi)]==['System.Object','System.Object'],'Exact reference-shared method definition and generic args')
        va=int(registration[0]['pointer'],16);window=region(v,va);code=bytes.fromhex(window['bytes']);need(len(code)==272,'Exact native key registration complete region');shape=decode(code,va)
        ctx=loose_context(v,m['image'],int(m['token'],16));usage=v.usage(int(shape['metadata_type'],16));need(usage['type']=='System.Type','Exact original Type class guard')
        direct,gaps=aliases(v,{int(shape[k],16) for k in ('key_constructor','direct_registration_call')});nextmethods=[]
        for calls in direct.values():
            for method in calls:
                pointer=v.method_pointer(method);nextmethods.append({'original':method,'pointer':hex(pointer),'first_pdata_not_assumed_complete':region(v,pointer)})
        owners={m['owner'] for calls in direct.values() for m in calls};fieldrows={owner:fields(v,owner) for owner in owners}
    controls=[]
    for label,pattern,bias in [('original_name_argument','4d 8b c6',2),('null_impl_key_name','45 33 c0',2),('impl_type_slot','48 8b 49 08',3),('provider_argument','4c 8b cd',2),('whole16byte_first_key_copy','66 0f 7f 44 24 50',5),('restore_frame','49 8b e3',2)]:
        val=bytes.fromhex(pattern);need(code.count(val)==1,'Unique mutation');at=code.index(val)+bias;changed=bytearray(code);changed[at]^=1
        try:decode(bytes(changed),va)
        except (ValueError,struct.error):controls.append({'mutation':label,'offset':at,'rejected':True})
        else:raise ValueError('Incorrect key registration mutation accepted')
    out=ROOT/'Validation'/('ContainerKeyRegistrationCFG-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    r={'schema':'original-container-generic-key-registration-CFG-and-next-dependencies/v1','status':'exact_reference_shared_body_typed_original_keys_not_complete_runtime_closure','original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'original_method':m,'registered_spec':452784,'generic_registration':registration[0],'reference_shared_body_not_falsely_claimed_closed_MNAL_registration':True,'native_runtime_function':window,'exact_shape':shape,'original_rgctx':ctx,'direct_original_targets':direct,'alias_inventory_gaps':gaps,'next_native_dependencies':nextmethods,'original_fields':fieldrows,'negative_controls':controls,'Main_changed':False,'managed_or_native_game_code_executed':False}
    p=out/'report.json';p.write_text(json.dumps(r,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'direct':direct,'fields':fieldrows,'negative_controls':len(controls)}))

if __name__=='__main__':main()
