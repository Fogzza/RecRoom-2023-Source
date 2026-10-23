"""Bounded PHJOGIEDKPN original CFG and RGCTX dependency map, no execution."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_ogpeg_constructors import Decoder
from inventory_recroom_game_root_native import region
from prove_recroom_ondestroy_native_cfg import aliases
from audit_boot_candidate_dependency_closure import module_methods,PROPOSAL

def literal(v,index):
    at=v.row('stringLiteral',index,8);length,offset=struct.unpack_from('<ii',v.m,at);base,size=v.tables['stringLiteralData']
    need(0<=length<=4096 and 0<=offset<=offset+length<=size,'Original literal bounds')
    value=bytes(v.m[base+offset:base+offset+length]);return {'original_literal_index':index,'length':length,'data_index':offset,'bytes_hex':value.hex(),'value':value.decode('utf-8')}

def concrete_specs(v,definitions,actual_owner_index):
    found={name:[] for name in definitions}
    for i in range(v.method_spec_count):
        mi,ci,gi=struct.unpack_from('<iii',v.b,v.method_specs+i*12)
        for name,(wanted,ca,ma) in definitions.items():
            if mi!=wanted:continue
            classes=v.inst(ci);methods=v.inst(gi)
            if len(classes)!=ca or len(methods)!=ma:continue
            if not all(t['kind']==18 and t['data']==actual_owner_index and not(t['num_mods'] or t['byref'] or t['pinned']) for t in classes+methods):continue
            found[name].append({'method_spec_index':i,'method':v.method_info(mi),'class_arguments':[v.typename(t) for t in classes],'method_arguments':[v.typename(t) for t in methods],'class_inst_index':ci,'method_inst_index':gi})
    if not all(len(items)==1 for items in found.values()):
        return {'status':'not_statically_registered_or_not_unique_no_pointer_inferred','exact_matches':found,'note':'rgctx templates are inflated by original runtime; missing closed MethodSpec is not guessed from a shared pointer'}
    registrations=v.generic_targets({items[0]['method_spec_index'] for items in found.values()})
    for name,items in found.items():
        item=items[0];targets=registrations[item['method_spec_index']];need(len(targets)==1,'Concrete startup dependency registration missing/ambiguous');item['registration']=targets[0]
        try:item['first_pdata_region_not_assumed_complete']=region(v,int(targets[0]['pointer'],16))
        except ValueError as e:item['pdata_region_gap']=str(e)
    return {k:v[0] for k,v in found.items()}

def decode(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 48 89 6c 24 10 48 89 74 24 18 48 89 7c 24 20 41 56 48 83 ec 20')
    flag=d.relative('80 3d','00');d.literal('49 8b f9 49 8b e8 4c 8b f2 48 8b f1');skip=d.short('75')
    A=d.relative('48 8d 0d');init1=d.relative('e8');B=d.relative('48 8d 0d');init2=d.relative('e8');C=d.relative('48 8d 0d');init3=d.relative('e8');written=d.relative('c6 05','01');ready=va+d.at
    loadedC=d.relative('48 8b 15');d.literal('45 33 c0 0f b6 4e 39');check1=d.relative('e8')
    loadedA=d.relative('48 8b 0d');d.literal('48 8b 5f 30 f6 81 33 01 00 00 04 48 8b 1b');noinit1=d.short('74');d.literal('83 b9 e0 00 00 00 00');noinit2=d.short('75');cctor=d.relative('e8');cctor_ready=va+d.at
    d.literal('33 d2 48 8b cb');type_lookup=d.relative('e8');d.literal('48 85 c0');null=d.relative('0f 84');d.literal('33 d2 48 8b c8');type_predicate=d.relative('e8')
    loadedB=d.relative('48 8b 15');d.literal('45 33 c0 0f b6 c8');check2=d.relative('e8')
    d.literal('48 8b 47 30 48 8b 58 08 f6 83 32 01 00 00 01');initialized=d.short('75');d.literal('48 8b cb');classinit=d.relative('e8');initialized_target=va+d.at
    d.literal('48 8b cb');allocate=d.relative('e8')
    d.literal('48 8b 4f 30 49 8b d6 48 8b d8 4c 8b 49 10 48 8b c8 4d 8b c1 41 ff 11')
    d.literal('48 8b 4f 30 4c 8b c3 48 8b d5 4c 8b 51 18 48 8b ce 4d 8b ca 41 ff 12')
    d.literal('48 8b 5c 24 30 48 8b c6 48 8b 74 24 40 48 8b 6c 24 38 48 8b 7c 24 48 48 83 c4 20 41 5e c3');null_target=va+d.at;nre=d.relative('e8');d.literal('cc');d.end()
    need(flag==written and skip==ready and A==loadedA and B==loadedB and C==loadedC,'Exact method init uses/guard')
    need(init1==init2==init3==0x1806c01e0 and noinit1==noinit2==cctor_ready and initialized==initialized_target and null==null_target,'Exact complete branch targets')
    need(nre==0x1806c0390,'Exact previously proved original NRE raise helper')
    return {'metadata_uses':{'class_cctor_guard':hex(A),'second_check_arg':hex(B),'first_check_arg':hex(C)},'direct_calls':{'first_check':hex(check1),'second_check':hex(check2),'type_lookup':hex(type_lookup),'type_predicate':hex(type_predicate),'managed_class_cctor':hex(cctor),'initialize_allocated_class':hex(classinit),'allocate_rgctx_class':hex(allocate)},'rgctx_slots':{'0':'original Type/runtimehandle for method generic TClass','1':'allocated class','2':'allocated provider constructor receives original argument0','3':'registration method receives original this/name/new provider'},'all_branches_and_normal_exception_exits_checked':True,'returns_original_this':True,'all_callee_saved_and_stack_restored':True,'semantic_first_check_input':'this.KBDIBPJIHNN byte at57, not assumed always false','semantic_second_check_input':'original type predicate Boolean return'}

def rgctx(v,image,token):
    module=v.modules[image];at=v.raw(module['va'],96);count=v.u64(v.b,at+64);ptr=v.u64(v.b,at+72);total=v.u64(v.b,at+80);data=v.u64(v.b,at+88)
    need(0<count<65536 and 0<total<1000000,'Bounded module RGCTX metadata')
    base=v.raw(ptr,count*12);hits=[]
    for i in range(count):
        t,start,length=struct.unpack_from('<Iii',v.b,base+i*12)
        if t==token:hits.append((start,length))
    need(len(hits)==1,'Exact unique original MethodDef RGCTX range required');start,length=hits[0];need(0<=start<=start+length<=total and length==4,'Exact four original RGCTX slots')
    rows=[]
    for n in range(length):
        raw=v.raw(data+(start+n)*8,8);kind,index=struct.unpack_from('<ii',v.b,raw);r={'slot':n,'kind':kind,'index':index,'original_rgctx_bytes':bytes(v.b[raw:raw+8]).hex()}
        if kind in (1,2):r.update(type=v.typename(v.native_type(index)),native_type=v.native_type(index))
        elif kind==3:
            need(0<=index<v.method_spec_count,'Exact RGCTX MethodSpec bounds');mi,ci,gi=struct.unpack_from('<iii',v.b,v.method_specs+index*12)
            r.update(method=v.method_info(mi),class_argument_types=[v.typename(t) for t in v.inst(ci)],method_argument_types=[v.typename(t) for t in v.inst(gi)],class_inst_index=ci,method_inst_index=gi)
        else:raise ValueError('Unsupported reviewed RGCTX kind')
        rows.append(r)
    need([r['kind'] for r in rows]==[1,2,3,3],'Exact native RGCTX slot kinds')
    return {'module':image,'module_address':hex(module['va']),'range_start':start,'range_length':length,'rows':rows}

def main():
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source SHA differs')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);m=v.find_method('MNALHHOLFGL',0x06000013);registration=v.generic_targets({452803})[452803];need(len(registration)==1 and registration[0]['pointer']=='0x1813b9ce0','Original exact constructor-tail registration')
        defidx,ci,gi=struct.unpack_from('<iii',v.b,v.method_specs+452803*12);args=v.inst(gi)
        need(defidx==m['index'] and ci==-1 and len(args)==1 and args[0]['kind']==18 and args[0]['data']==m['owner_index'],'Exact original incoming MethodSpec definition/instantiation')
        va=int(registration[0]['pointer'],16);window=region(v,va);code=bytes.fromhex(window['bytes']);need(len(code)==308,'Exact original .pdata region size');shape=decode(code,va)
        uses={name:v.usage(int(pointer,16)) for name,pointer in shape['metadata_uses'].items()};ctx=rgctx(v,m['image'],int(m['token'],16));direct,gaps=aliases(v,{int(p,16) for p in shape['direct_calls'].values()})
        specs={r['index'] for r in ctx['rows'] if r['kind']==3};generic=v.generic_targets(specs)
        literals={name:literal(v,u['index']) for name,u in uses.items() if u['kind']==5}
        concrete=concrete_specs(v,{'instance_provider_constructor':(ctx['rows'][2]['method']['index'],1,0),'register_provider':(ctx['rows'][3]['method']['index'],0,2)},m['owner_index'])
        check_method=v.find_method('MKECFLEMHEL',0x0600005f);check_pointer=v.method_pointer(check_method);need(check_pointer==int(shape['direct_calls']['first_check'],16)==int(shape['direct_calls']['second_check'],16),'Original condition-check method pointer')
        check={'original':check_method,'native_pointer':hex(check_pointer),'first_pdata_region_not_assumed_complete':region(v,check_pointer)}
    proposal=json.loads(PROPOSAL.read_bytes());entry=next(r for r in proposal['assemblies'] if r['assembly']=='UJect.Runtime');staged=Path(entry['candidate']);need(sha(staged)==entry['candidate_sha256'],'Staged runtime UJect hash differs')
    current=[];selectors=[{'owner':'MNALHHOLFGL','name':'JONINBOMMEP','parameters':2,'generic':2},{'owner':'IKGLJOBBAAC','name':'.ctor','parameters':1},{'owner':'MKECFLEMHEL','name':'GFKAFPHLKMJ','parameters':2}]
    for scope,path in [('current_Main',WS/'RR23/Assets/Plugins/UJect.Runtime.dll'),('staged_runtime225',staged)]:
        for body in module_methods(path,selectors):current.append({**body,'scope':scope,'path':str(path),'file_sha256':sha(path)})
    mutations=[]
    for label,pattern,bias in [('original_bool_offset','0f b6 4e 39',3),('first_rgctx_type_slot','48 8b 1b',2),('provider_argument','49 8b d6',2),('provider_ctor_slot','4c 8b 49 10',3),('registration_slot','4c 8b 51 18',3),('return_this','48 8b c6',2)]:
        value=bytes.fromhex(pattern);need(code.count(value)==1,'Unique mutation pattern');at=code.index(value)+bias;changed=bytearray(code);changed[at]^=1
        try:decode(bytes(changed),va)
        except (ValueError,struct.error):mutations.append({'mutation':label,'offset':at,'rejected':True})
        else:raise ValueError('Incorrect native binding mutation accepted')
    out=ROOT/'Validation'/('ContainerBindingTailCFG-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'original-container-instance-binding-CFG-and-RGCTX-dependencies/v1','status':'closed_native_CFG_typed_dependencies_original_callees_not_recovered','original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'original_method':m,'original_method_spec':452803,'original_generic_registration':registration[0],'original_runtime_function':window,'exact_shape':shape,'typed_metadata_usages':uses,'original_check_messages':literals,'original_method_rgctx':ctx,'rgctx_method_registrations':generic,'concrete_startup_dependencies':concrete,'condition_check_dependency':check,'current_dependency_IL':current,'direct_call_aliases':direct,'alias_inventory_gaps':gaps,'negative_controls':mutations,'Main_changed':False,'game_or_managed_code_executed':False,'CSharp_written':False}
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'uses':uses,'context':ctx,'direct':direct,'generic':generic}))

if __name__=='__main__':main()
