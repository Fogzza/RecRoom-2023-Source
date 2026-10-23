"""Exact native MNALHHOLFGL two-argument constructor CFG/dependencies only.

Reads verified original PE/metadata through mmap. No managed/native/game code,
decompilation model, Editor, project writes, or guessed callee implementation.
"""
from pathlib import Path
import datetime as dt, hashlib, json, mmap, struct, sys, uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_ogpeg_constructors import Decoder,fields
from prove_recroom_ondestroy_native_cfg import aliases
from inventory_recroom_game_root_native import region
from audit_boot_candidate_dependency_closure import module_methods,PROPOSAL

WINDOW=ROOT/'Validation/ServiceContainerNativeWindows-20261022T180635Z-6a8820b3/report.json'

def decode(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 48 89 6c 24 10 48 89 74 24 18 48 89 7c 24 20 41 56 48 83 ec 20')
    flag=d.relative('80 3d','00');d.literal('49 8b e8 4c 8b f2 48 8b f9');skip=d.short('75')
    initial=[]
    for i in range(6):initial.append((d.relative('48 8d 0d'),d.relative('e8')))
    written=d.relative('c6 05','01');ready=va+d.at
    cls1=d.relative('48 8b 0d');alloc1=d.relative('e8');ctoruse1=d.relative('48 8b 15');d.literal('48 8b c8 48 8b d8');ctor1=d.relative('e8')
    d.literal('48 8d 4f 10 48 8b d3 48 89 19');barrier1=d.relative('e8')
    cls2=d.relative('48 8b 0d');alloc2=d.relative('e8');ctoruse2=d.relative('48 8b 15');d.literal('48 8b c8 48 8b d8');ctor2=d.relative('e8')
    d.literal('48 8d 4f 18 48 8b d3 48 89 19');barrier2=d.relative('e8')
    cls3=d.relative('48 8b 0d');alloc3=d.relative('e8');flag_inner=d.relative('80 3d','00');d.literal('48 8b f0');skip_inner=d.short('75')
    inner=[]
    for i in range(4):inner.append((d.relative('48 8d 0d'),d.relative('e8')))
    written_inner=d.relative('c6 05','01');ready_inner=va+d.at
    cls4=d.relative('48 8b 0d');alloc4=d.relative('e8');ctoruse4=d.relative('48 8b 15');d.literal('48 8b c8 48 8b d8');ctor4=d.relative('e8')
    d.literal('48 8d 4e 10 48 8b d3 48 89 19');barrier4=d.relative('e8')
    cls5=d.relative('48 8b 0d');alloc5=d.relative('e8');ctoruse5=d.relative('48 8b 15');d.literal('48 8b c8 48 8b d8');ctor5=d.relative('e8')
    d.literal('48 8d 4e 18 48 8b d3 48 89 19');barrier5=d.relative('e8')
    d.literal('33 d2 48 8b ce');obj_inner=d.relative('e8')
    d.literal('48 8d 4f 20 48 8b d6 48 89 31');barrier3=d.relative('e8')
    d.literal('33 d2 48 8b cf');obj_self=d.relative('e8')
    d.literal('48 8d 4f 28 49 8b d6 4c 89 31');barrier_parent=d.relative('e8')
    d.literal('48 8d 4f 30 48 8b d5 48 89 29');barrier_name=d.relative('e8')
    d.literal('c6 47 38 00 45 33 c0');tailuse=d.relative('4c 8b 0d')
    d.literal('48 8b d7 48 8b cf 48 8b 5c 24 30 48 8b 6c 24 38 48 8b 74 24 40 48 8b 7c 24 48 48 83 c4 20 41 5e');tail=d.relative('e9')
    end=d.at
    need(end==498 and len(code)==512 and all(x==0xcc for x in code[end:]),'Exact pdata end and INT3 padding')
    d.literal('cc '*(len(code)-end));d.end()
    need(flag==written and skip==ready and flag_inner==written_inner and skip_inner==ready_inner,'Both metadata guards close exactly')
    need({target for _,target in initial+inner}=={0x1806c01e0},'Exact known metadata initialization helper')
    need({alloc1,alloc2,alloc3,alloc4,alloc5}=={0x1806c0340},'Exact anchored original allocation helper')
    need({barrier1,barrier2,barrier3,barrier4,barrier5,barrier_parent,barrier_name}=={0x1806bfd30},'Exact anchored reference store barrier')
    need(obj_inner==obj_self==0x1806f84d0,'Exact previously native-proved empty System.Object constructor')
    usage={'dict1_class':cls1,'dict1_ctor':ctoruse1,'dict2_class':cls2,'dict2_ctor':ctoruse2,'aux_class':cls3,'aux_dict_class':cls4,'aux_dict_ctor':ctoruse4,'aux_set_class':cls5,'aux_set_ctor':ctoruse5,'final_method':tailuse}
    need({p for p,_ in initial}=={cls1,ctoruse1,cls2,ctoruse2,cls3,tailuse},'Every outer metadata use exactly initialized')
    need({p for p,_ in inner}=={cls4,ctoruse4,cls5,ctoruse5},'Every inlined auxiliary metadata use exactly initialized')
    return {'metadata_uses':{k:hex(x) for k,x in usage.items()},'typed_calls':{'dict1_ctor':hex(ctor1),'dict2_ctor':hex(ctor2),'aux_dict_ctor':hex(ctor4),'aux_set_ctor':hex(ctor5),'final_tail_method':hex(tail)},'state_stores':[{'receiver':'this','offset':16,'value':'new dict1'},{'receiver':'this','offset':24,'value':'new dict2'},{'receiver':'new aux','offset':16,'value':'new aux dict'},{'receiver':'new aux','offset':24,'value':'new aux set'},{'receiver':'this','offset':32,'value':'new aux initialized before own base call'},{'receiver':'this','offset':40,'value':'argument0 parent'},{'receiver':'this','offset':48,'value':'argument1 string'},{'receiver':'this','offset':56,'value':0}],'base_call_order':'aux fields, aux Object.ctor, this aux field, this Object.ctor, parent/name/state, final tail','final_tail_arguments':{'RCX':'original this','RDX':'original this','R8':'null','R9':'exact final MethodSpec usage'},'semantic_bytes':end,'padding_bytes':14,'stack_balanced_and_all_callee_saved_registers_restored':True,'all_512_original_bytes_checked':True}

def main():
    original=json.loads(WINDOW.read_bytes());row=next(r for r in original['methods'] if r['original']['owner']=='MNALHHOLFGL' and r['original']['token']=='0x600002a')
    code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);shape=decode(code,va)
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Verified original native full SHA differs')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);method=v.find_method('MNALHHOLFGL',0x0600002a)
        need(v.method_pointer(method)==va and bytes(b[v.raw(va,len(code)):v.raw(va,len(code))+len(code)])==code,'Original module MethodDef/complete byte join differs')
        uses={name:v.usage(int(address,16)) for name,address in shape['metadata_uses'].items()}
        generic=v.generic_targets({u['index'] for u in uses.values() if u['kind']==6})
        for name in ('dict1_ctor','dict2_ctor','aux_dict_ctor','aux_set_ctor','final_method'):
            u=uses[name];need(u['kind']==6,'Exact generic constructor/tail MethodSpec required')
            targets=generic[u['index']];call=shape['typed_calls']['final_tail_method' if name=='final_method' else name]
            need(len(targets)==1 and targets[0]['pointer']==call,'Exact original MethodSpec registration differs: '+name)
        for clsname,ctorname in [('dict1_class','dict1_ctor'),('dict2_class','dict2_ctor'),('aux_dict_class','aux_dict_ctor'),('aux_set_class','aux_set_ctor')]:
            u=uses[ctorname];need(u['method']['name']=='.ctor' and not u['method']['parameters'] and u['method']['return']=='System.Void' and not u['method_argument_types'],'Exact zero-arg framework constructor shape')
            need(uses[clsname]['type']==u['method']['owner']+'<'+','.join(u['class_argument_types'])+'>','Exact allocated class/constructor instantiation differs')
            need(u['method']['image']==('System.Core.dll' if ctorname=='aux_set_ctor' else 'mscorlib.dll'),'Exact original framework constructor scope')
        direct,gaps=aliases(v,{int(p,16) for p in shape['typed_calls'].values()})
        auxiliary=uses['aux_class']['type'];fieldrows={owner:fields(v,owner) for owner in ('MNALHHOLFGL',auxiliary)}
        byowner={owner:{f['offset']:f for f in values} for owner,values in fieldrows.items()}
        expected={'MNALHHOLFGL':{16:('AAHKPPMHGFI',uses['dict1_class']['type']),24:('LMAFHCPPMAD',uses['dict2_class']['type']),32:('OLGLBMGAHBO',auxiliary),40:('DDFCHDGPJBN','MNALHHOLFGL'),48:('LGENGCEEBPB','System.String'),56:('MGADLDPDPGK','MNALHHOLFGL/PFCPCBJDEMB')},auxiliary:{16:(None,uses['aux_dict_class']['type']),24:(None,uses['aux_set_class']['type'])}}
        for owner,rows in expected.items():
            for offset,(name,typ) in rows.items():
                f=byowner[owner][offset];need((name is None or f['name']==name) and f['type']==typ and not f['native_type']['attributes']&0x10,'Exact original instance store field/token/type/offset differs')
        u=uses['final_method'];need(u['method']['owner']=='MNALHHOLFGL' and u['method']['name']=='PHJOGIEDKPN' and u['method']['token']=='0x6000013' and u['method_argument_types']==['MNALHHOLFGL'],'Exact final plugin instance-binding dependency')
        tail_window=region(v,int(shape['typed_calls']['final_tail_method'],16))
    proposal=json.loads(PROPOSAL.read_bytes());runtime=next(r for r in proposal['assemblies'] if r['assembly']=='UJect.Runtime')
    staged=Path(runtime['candidate']);need(sha(staged)==runtime['candidate_sha256'],'Pinned staged UJect runtime changed')
    selectors=[{'owner':'MNALHHOLFGL','name':'.ctor','parameters':2},{'owner':'MNALHHOLFGL','name':'PHJOGIEDKPN','parameters':2,'generic':1},{'owner':'OENEDGPIOFN','name':'.ctor','parameters':0}]
    current=[]
    for scope,path in [('current_Main',WS/'RR23/Assets/Plugins/UJect.Runtime.dll'),('staged_runtime225',staged)]:
        for body in module_methods(path,selectors):current.append({**body,'scope':scope,'path':str(path),'file_sha256':sha(path)})
    controls=[]
    mutations=[('save_parent_argument','4c 8b f2',2),('first_field_offset','48 8d 4f 10',3),('parent_store_register','4c 89 31',2),('zero_state_offset','c6 47 38 00',2)]
    positions=[]
    for label,pattern,bias in mutations:
        value=bytes.fromhex(pattern);need(code.count(value)==1,'Mutation pattern must be unique');positions.append((label,code.index(value)+bias))
    positions += [('metadata_guard_branch',44),('tail_opcode',493)]
    for label,offset in positions:
        changed=bytearray(code);changed[offset]^=1
        try:decode(bytes(changed),va)
        except (ValueError,struct.error):controls.append({'mutation':label,'offset':offset,'rejected':True})
        else:raise ValueError('Native constructor mutation accepted: '+label)
    out=ROOT/'Validation'/('ServiceContainerCtorCFG-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'exact-native-service-container-constructor-CFG-and-dependencies/v1','status':'native_constructor_shape_proved_callee_runtime_closure_pending','input_window':{'path':str(WINDOW),'sha256':sha(WINDOW)},'original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'original':method,'native_pointer':hex(va),'native_bytes':code.hex(),'native_sha256':hashlib.sha256(code).hexdigest(),'exact_shape':shape,'typed_original_usages':uses,'original_generic_registrations':generic,'direct_call_aliases':direct,'alias_inventory_gaps':gaps,'original_fields':fieldrows,'final_plugin_tail_first_pdata_not_assumed_complete':tail_window,'current_dependency_IL':current,'negative_controls':controls,'project_changed':False,'managed_or_native_game_code_executed':False,'CSharp_candidate_written':False}
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({'report':str(p),'sha256':sha(p),'uses':uses,'generic':generic,'direct':direct,'alias_gaps':len(gaps),'negative_controls':len(controls)}))

if __name__=='__main__':main()
