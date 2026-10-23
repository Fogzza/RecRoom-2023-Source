"""Exact original container storage insert CFG and original call identities."""
from pathlib import Path
import datetime as dt,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_ogpeg_constructors import Decoder
from inventory_recroom_game_root_native import region
from prove_recroom_ondestroy_native_cfg import aliases
from prove_container_binding_tail_native import literal

def decode(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 10 48 89 6c 24 18 48 89 74 24 20 57 48 83 ec 50');flag=d.relative('80 3d','00');d.literal('49 8b f1 49 8b e8 48 8b fa 48 8b d9');skip=d.short('75');A=d.relative('48 8d 0d');init1=d.relative('e8');B=d.relative('48 8d 0d');init2=d.relative('e8');written=d.relative('c6 05','01');ready=va+d.at
    d.literal('48 8b 4b 20 48 c7 44 24 60 00 00 00 00 48 85 c9');nrebranch1=d.relative('0f 84')
    d.literal('0f 10 45 00 41 b1 01 4c 8d 44 24 30 0f 10 0f 48 8d 54 24 40 48 c7 44 24 20 00 00 00 00 0f 29 44 24 30 0f 29 4c 24 40');mapcall=d.relative('e8')
    d.literal('48 8b 4b 20 48 85 c9');nrebranch2=d.relative('0f 84');d.literal('45 33 c0 48 8d 54 24 60');cyclecall=d.relative('e8');d.literal('84 c0');cyclebranch=d.relative('0f 85')
    d.literal('48 8b 4b 18 48 85 c9');nrebranch3=d.relative('0f 84');d.literal('0f 10 07');loadB=d.relative('4c 8b 05');d.literal('48 8d 54 24 40 0f 29 44 24 40');contains=d.relative('e8');d.literal('84 c0');duplicatebranch=d.short('75')
    d.literal('48 8b 4b 18 48 85 c9');nrebranch4=d.relative('0f 84');d.literal('0f 10 07');loadA=d.relative('4c 8b 0d');d.literal('48 8d 54 24 40 4c 8b c6 0f 29 44 24 40');add=d.relative('e8')
    d.literal('48 8b 6c 24 70 48 8b 74 24 78 c6 43 38 00 48 8b 5c 24 68 48 83 c4 50 5f c3');nre1_at=va+d.at;nre1=d.relative('e8');d.literal('cc')
    duplicate_at=va+d.at;E=d.relative('48 8d 0d');einit=d.relative('e8');d.literal('48 8b c8');eallocate=d.relative('e8');d.literal('0f 10 07 45 33 c0 48 8d 54 24 40 48 8b c8 48 8b d8 0f 29 44 24 40');ector=d.relative('e8');M=d.relative('48 8d 0d');minit=d.relative('e8');d.literal('48 8b d0 48 8b cb');raise1=d.relative('e8');d.literal('cc')
    nre2_at=va+d.at;nre2=d.relative('e8');d.literal('cc')
    cycle_at=va+d.at;d.literal('0f 10 07');K1=d.relative('48 8d 0d');d.literal('0f 11 44 24 40');kinit1=d.relative('e8');d.literal('48 8b c8 48 8d 54 24 40');box1=d.relative('e8')
    d.literal('0f 10 45 00');K2=d.relative('48 8d 0d');d.literal('48 8b f0 0f 11 44 24 30');kinit2=d.relative('e8');d.literal('48 8b c8 48 8d 54 24 30');box2=d.relative('e8')
    d.literal('48 8b 5c 24 60');S=d.relative('48 8d 0d');d.literal('48 8b f8');sinit=d.relative('e8');d.literal('48 8b c8 48 c7 44 24 20 00 00 00 00 4c 8b cb 4c 8b c7 48 8b d6');formatcall=d.relative('e8')
    E2=d.relative('48 8d 0d');d.literal('48 8b d8');einit2=d.relative('e8');d.literal('48 8b c8');eallocate2=d.relative('e8');d.literal('45 33 c0 48 8b d3 48 8b c8 48 8b f8');ector2=d.relative('e8');M2=d.relative('48 8d 0d');minit2=d.relative('e8');d.literal('48 8b d0 48 8b cf');raise2=d.relative('e8');d.literal('cc');d.end()
    need(len(code)==543 and flag==written and skip==ready and A==loadA and B==loadB,'Exact original metadata guard and store uses')
    need(nrebranch1==nrebranch2==nre1_at and nrebranch3==nrebranch4==nre2_at and cyclebranch==cycle_at and duplicatebranch==duplicate_at,'Exact normal/null/duplicate/cycle CFG targets')
    need({init1,init2,einit,minit,kinit1,kinit2,sinit,einit2,minit2}=={0x1806c01e0} and eallocate==eallocate2==0x1806c0340 and nre1==nre2==0x1806c0390 and raise1==raise2==0x1806c0360 and box1==box2 and K1==K2,'Exact known original runtime wrappers/box type agreement')
    return {'metadata_uses':{'dictionary_add':hex(A),'dictionary_contains':hex(B),'duplicate_exception_class':hex(E),'duplicate_raise_method':hex(M),'cycle_key_class':hex(K1),'cycle_format_literal':hex(S),'cycle_exception_class':hex(E2),'cycle_raise_method':hex(M2)},'direct_calls':{'dependency_map_add':hex(mapcall),'dependency_cycle_check':hex(cyclecall),'dictionary_contains':hex(contains),'dictionary_add':hex(add),'duplicate_exception_ctor':hex(ector),'cycle_format':hex(formatcall),'cycle_exception_ctor':hex(ector2),'box_key_value':hex(box1)},'normal_semantics':['register interface-key -> implementation-key dependency with true option','query dependency cycle details','reject cycle','reject preexisting interface key in LMAFHCPPMAD','LMAFHCPPMAD.Add(interface-key,provider)','this.MGADLDPDPGK = 0'],'exception_paths':['null dependency-map/dictionary => original NRE','duplicate interface-key => original exception constructed with full CPAM key','dependency cycle => box two complete CPAM keys, format with original cycle details, throw original message exception'],'all543native_bytes_and_all_branch_targets_checked':True,'whole16byte_value_copy_semantics_preserved':True,'normal_exit_stack_and_registers_restored':True}

def main():
    paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
    for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Original SHA differs')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);m=v.find_method('MNALHHOLFGL',0x06000018);va=v.method_pointer(m);need(va==0x1867446a0,'Original private registration pointer');window=region(v,va);code=bytes.fromhex(window['bytes']);shape=decode(code,va);uses={name:v.usage(int(p,16)) for name,p in shape['metadata_uses'].items()};messages={name:literal(v,u['index']) for name,u in uses.items() if u['kind']==5};direct,gaps=aliases(v,{int(p,16) for p in shape['direct_calls'].values()});generic=v.generic_targets({u['index'] for u in uses.values() if u['kind']==6})
        nextdeps=[]
        for target,methods in direct.items():
            for dm in methods:
                if dm['image']!='UJect.Runtime.dll':continue
                dep={'original':dm,'pointer':target}
                try:dep['first_pdata_not_assumed_complete']=region(v,int(target,16))
                except ValueError as e:
                    raw=v.raw(int(target,16),128);dep.update(pdata_gap=str(e),bounded128bytes_not_assumed_body=bytes(b[raw:raw+128]).hex())
                nextdeps.append(dep)
    controls=[]
    for label,pattern,bias in [('provider_source','4c 8b c6',2),('whole_impl_key_read','0f 10 45 00 41 b1 01',3),('true_dependency_option','41 b1 01',2),('state_reset_offset','c6 43 38 00',2),('cycle_out_pointer','48 8d 54 24 60',4)]:
        val=bytes.fromhex(pattern);need(code.count(val)==1,'Unique storage mutation pattern');at=code.index(val)+bias;mutated=bytearray(code);mutated[at]^=1
        try:decode(bytes(mutated),va)
        except (ValueError,struct.error):controls.append({'mutation':label,'offset':at,'rejected':True})
        else:raise ValueError('Incorrect storage mutation accepted')
    out=ROOT/'Validation'/('ContainerStorageRegistrationCFG-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    r={'schema':'original-container-storage-registration-exact-CFG-and-dependencies/v1','status':'closed_native_CFG_next_dependency_graph_and_custom_exceptions_pending','original_inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'original':m,'native_pointer':hex(va),'native_function':window,'exact_shape':shape,'typed_metadata_uses':uses,'original_literals':messages,'direct_original_calls':direct,'alias_inventory_gaps':gaps,'generic_registrations':generic,'next_UJect_dependencies':nextdeps,'negative_controls':controls,'Main_changed':False,'managed_or_game_code_executed':False}
    p=out/'report.json';p.write_text(json.dumps(r,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'next_UJect':[{'owner':d['original']['owner'],'name':d['original']['name'],'token':d['original']['token'],'pointer':d['pointer'],'bytes':len(bytes.fromhex(d.get('first_pdata_not_assumed_complete',{}).get('bytes',''))),'pdata_gap':d.get('pdata_gap')} for d in nextdeps],'uses':uses,'messages':messages,'negative_controls':len(controls)}))

if __name__=='__main__':main()
