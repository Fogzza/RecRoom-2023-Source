"""Closed CPAM value constructor and OENED framework-only initializers.
Original bytes/identities only. Does not write a DLL/source or run game code.
"""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_ogpeg_constructors import Decoder,fields
from inventory_recroom_game_root_native import region

def key(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 57 48 83 ec 20 49 8b f8 48 89 11 48 8b d9');barrier1=d.relative('e8');d.literal('48 8d 4b 08 48 8b d7 48 89 39 48 8b 5c 24 30 48 83 c4 20 5f');barrier2=d.relative('e9');d.end();need(barrier1==barrier2==0x1806bfd30,'Original direct/tail reference-store barriers')
    return {'stores':[{'unboxed_offset':0,'value':'argument0 System.Type'},{'unboxed_offset':8,'value':'argument1 System.String'}],'callee_saved_and_stack_restored':True,'tail_barrier_equivalent_to_managed_reference_store':True,'native_all49bytes_checked':True}

def aux(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 57 48 83 ec 20');flag=d.relative('80 3d','00');d.literal('48 8b f9');skip=d.short('75')
    initial=[]
    for i in range(4):initial.append((d.relative('48 8d 0d'),d.relative('e8')))
    written=d.relative('c6 05','01');ready=va+d.at
    cls1=d.relative('48 8b 0d');alloc1=d.relative('e8');use1=d.relative('48 8b 15');d.literal('48 8b c8 48 8b d8');ctor1=d.relative('e8');d.literal('48 8d 4f 10 48 8b d3 48 89 19');barrier1=d.relative('e8')
    cls2=d.relative('48 8b 0d');alloc2=d.relative('e8');use2=d.relative('48 8b 15');d.literal('48 8b c8 48 8b d8');ctor2=d.relative('e8');d.literal('48 8d 4f 18 48 8b d3 48 89 19');barrier2=d.relative('e8')
    d.literal('33 d2 48 8b cf 48 8b 5c 24 30 48 83 c4 20 5f');obj=d.relative('e9');d.end()
    need(flag==written and skip==ready and {p for p,_ in initial}=={cls1,use1,cls2,use2},'Every original auxiliary metadata use/guard')
    need({t for _,t in initial}=={0x1806c01e0} and alloc1==alloc2==0x1806c0340 and barrier1==barrier2==0x1806bfd30 and obj==0x1806f84d0,'Exact framework/allocation/store anchors')
    return {'metadata_uses':{'dictionary_class':hex(cls1),'dictionary_ctor':hex(use1),'set_class':hex(cls2),'set_ctor':hex(use2)},'direct_constructors':{'dictionary_ctor':hex(ctor1),'set_ctor':hex(ctor2)},'stores_before_base_ctor':[{'offset':16,'value':'new Dictionary<CPAMAFPANDM,OENEDGPIOFN/NPDGPDKAHLN>'},{'offset':24,'value':'new HashSet<OENEDGPIOFN/NPDGPDKAHLN>'}],'base_is_original_empty_SystemObject_constructor':True,'callee_saved_and_stack_restored':True,'all_native_bytes_checked':True}

def main():
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source SHA differs')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);km=v.find_method('CPAMAFPANDM',0x0600004d);kp=v.method_pointer(km);kw=region(v,kp);ks=key(bytes.fromhex(kw['bytes']),kp);kf=fields(v,'CPAMAFPANDM');kt=v.type_info(km['owner_index'])
        need(kt['parent_type']=='System.ValueType' and len(kf)==2,'Exact original value type with two fields');need([(f['name'],f['type'],f['offset']) for f in kf]==[('AFJAGKNNCBE','System.Type',16),('FEKLPCPODAH','System.String',24)],'Exact original boxed offsets and fields');need([p['type'] for p in km['parameters']]==['System.Type','System.String'],'Original key constructor parameter contract')
        owners=[i for i in range(v.count('typeDefinitions',88)) if v.full_name(i)=='OENEDGPIOFN'];need(len(owners)==1,'Exact auxiliary owner');at=v.row('typeDefinitions',owners[0],88);start=v.i32(md,at+36);count=v.u16(md,at+64);ctors=[v.method_info(i) for i in range(start,start+count) if v.method_info(i)['name']=='.ctor' and not v.method_info(i)['parameters']];need(len(ctors)==1,'Exact original zero-argument auxiliary constructor');am=ctors[0];ap=v.method_pointer(am);aw=region(v,ap);ashape=aux(bytes.fromhex(aw['bytes']),ap);af=fields(v,'OENEDGPIOFN')
        uses={name:v.usage(int(p,16)) for name,p in ashape['metadata_uses'].items()};registrations=v.generic_targets({u['index'] for u in uses.values() if u['kind']==6})
        for cls,ctor in [('dictionary_class','dictionary_ctor'),('set_class','set_ctor')]:
            use=uses[ctor];need(use['kind']==6 and use['method']['name']=='.ctor' and not use['method']['parameters'],'Exact framework constructor shape');targets=registrations[use['index']];need(len(targets)==1 and targets[0]['pointer']==ashape['direct_constructors'][ctor],'Exact generic constructor registration');need(uses[cls]['type']==use['method']['owner']+'<'+','.join(use['class_argument_types'])+'>','Exact allocation type/constructor join')
        need([(f['name'],f['type'],f['offset']) for f in af]==[('NLDFDGJCKFH',uses['dictionary_class']['type'],16),('DJGFOAKOCAP',uses['set_class']['type'],24),('OMMELJLAGLB','System.Collections.Generic.List`1<CPAMAFPANDM>',32)],'Exact auxiliary full original field inventory; third list field is not written by native constructor')
    controls=[]
    for role,code,va,decoder,patterns in [('key',bytes.fromhex(kw['bytes']),kp,key,[('first_value','48 89 11',2),('second_field_offset','48 8d 4b 08',3),('tail','5f e9',1)]),('aux',bytes.fromhex(aw['bytes']),ap,aux,[('first_field_offset','48 8d 4f 10',3),('second_field_offset','48 8d 4f 18',3),('base_receiver','48 8b cf',2)])]:
        for label,pattern,bias in patterns:
            val=bytes.fromhex(pattern);need(code.count(val)==1,'Unique leaf mutation pattern');off=code.index(val)+bias;mutated=bytearray(code);mutated[off]^=1
            try:decoder(bytes(mutated),va)
            except (ValueError,struct.error):controls.append({'method':role,'mutation':label,'offset':off,'rejected':True})
            else:raise ValueError('Incorrect container leaf mutation accepted')
    out=ROOT/'Validation'/('ContainerClosedInitializers-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'original-container-closed-small-initializer-native-proofs/v1','status':'two_constructor_native_behaviors_proved_no_Dll_or_source_write','original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'key_constructor':{'original':km,'original_type':kt,'pointer':hex(kp),'native':kw,'shape':ks,'fields':kf,'value_type_header_adjustment':16,'candidate_effects':['this.AFJAGKNNCBE = KGFBELINAJD;','this.FEKLPCPODAH = JFKHNCFJNDG;']},'auxiliary_constructor':{'original':am,'pointer':hex(ap),'native':aw,'shape':ashape,'fields':af,'metadata_uses':uses,'registrations':registrations,'candidate_effects':['Field initializers before base: original dictionary field = new Dictionary<CPAMAFPANDM,OENEDGPIOFN.NPDGPDKAHLN>();','Field initializers before base: original set field = new HashSet<OENEDGPIOFN.NPDGPDKAHLN>();']},'negative_controls':controls,'actual_compiler_symbol_and_IL_proof_pending':True,'Main_changed':False,'managed_or_game_code_executed':False}
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'key_bytes':len(bytes.fromhex(kw['bytes'])),'auxiliary_bytes':len(bytes.fromhex(aw['bytes'])),'negative_controls':len(controls),'auxiliary_fields':af}))

if __name__=='__main__':main()
