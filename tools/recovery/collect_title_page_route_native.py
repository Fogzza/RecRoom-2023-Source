"""Read-only exact209B TitleScreenPage.Route shape and typed joins.

No disassembler/native library, game/managed assembly or network is invoked.
This records caller evidence; it does not substitute defaults for its callees.
"""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from inventory_recroom_game_root_native import region
from audit_ogpeg_constructors import Decoder
from prove_recroom_ondestroy_native_cfg import aliases
from collect_nameserver_request_factory_native import fields
from prove_nameserver_request_factory_cfg import no_chained_entries
from audit_forwarding import EXPECTED
def pin(path):
    p=Path(path).resolve(strict=True)
    with p.open('rb') as f:d=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':d}
def shape(code,va):
    d=Decoder(code,va);d.literal('40 53 48 83 ec 20');flag=d.relative('80 3d','00');d.literal('48 8b d9');ready=d.short('75')
    usages=[];initializers=[]
    for _ in range(4):usages.append(d.relative('48 8d 0d'));initializers.append(d.relative('e8'))
    written=d.relative('c6 05','01');loaded=va+d.at
    d.literal('80 7b 10 00');notdifferent=d.short('74');klass=d.relative('48 8b 0d')
    d.literal('f6 81 33 01 00 00 04');notinitialized=d.short('74');d.literal('83 b9 e0 00 00 00 00');initialized=d.short('75');classinit=d.relative('e8');classready=va+d.at
    staticarg=d.relative('48 8b 0d');first=d.relative('e8');d.literal('84 c0');firstfalse=d.short('74');d.literal('33 c9');second=d.relative('e8');d.literal('48 85 c0');firstnull=d.short('74')
    genericarg=d.relative('4c 8b 05');d.literal('33 d2 48 8b c8');third=d.relative('e8');d.literal('48 85 c0');secondnull=d.short('74')
    fourtharg=d.relative('48 8b 15');d.literal('b9 05 00 00 00 4c 8b c0');fourth=d.relative('e8');d.literal('84 c0');notmobile=d.short('74')
    d.literal('48 8b 43 20 48 83 c4 20 5b c3');regular=va+d.at;d.literal('48 8b 43 18 48 83 c4 20 5b c3');fail=va+d.at;nullhelper=d.relative('e8');d.literal('cc');d.end()
    need(len(code)==209 and flag==written and ready==loaded and usages[3]==klass and usages[2]==staticarg and usages[1]==genericarg and usages[0]==fourtharg,'Exact metadata initialization/load joins')
    need(all(x==0x1806c01e0 for x in initializers) and classinit==0x180640f10 and nullhelper==0x1806c0390,'Exact original runtime helper identities')
    need(notdifferent==firstfalse==notmobile==regular and firstnull==secondnull==fail and notinitialized==initialized==classready,'Every original branch is closed in this209B region')
    return {'all_209_bytes_recognized':True,'all_branches_closed':True,'receiver':'original this in RBX','field_offsets':{'routeIsDifferentOnMobile':16,'route':24,'mobileRoute':32},'regular_return_address':hex(regular),'null_failure_address':hex(fail),'calls':{'first_static_boolean':hex(first),'second_static_object':hex(second),'third_generic_object':hex(third),'fourth_static_predicate':hex(fourth)},'metadata_usages':[hex(x) for x in usages],'runtime_helpers':{'initialize_metadata':hex(initializers[0]),'class_initialize':hex(classinit),'throw_null_reference':hex(nullhelper)},'effect_order':['if original bool field false return original route field','ensure original static class initialized','call first static boolean with original class metadata pointer','if false return route','call second static with null hidden MethodInfo','if null throw','call third generic on same object with null explicit argument','if null throw','call fourth predicate with integer5, original MethodInfo and same third result','if predicate true return original mobileRoute field, else original route field'],'callee_saved_RBX_restored_and_stack_balanced':True}
def main():
    paths=[ROOT/'CodeSource'/x for x in EXPECTED];pins=[pin(x) for x in paths]
    need(all(p['sha256']==EXPECTED[Path(p['path']).relative_to(ROOT/'CodeSource').as_posix()] for p in pins),'Exact original source pins')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);method=v.find_method('RRUI.Data.TitleScreenFlowModel/TitleScreenPage',0x06008ab5);va=v.method_pointer(method);window=region(v,va);code=bytes.fromhex(window['bytes'])
        need(method['index']==225852 and va==0x180dadc70 and window['sha256']=='764af983a1cddaa9c2312afb10690c940b48be41e1010f02a98f8b993dcbd5a1','Exact original registered Route getter')
        result=shape(code,va);chains=no_chained_entries(v,[window]);uses={a:v.usage(int(a,16)) for a in result['metadata_usages']}
        targets={int(a,16) for a in result['calls'].values()};direct,gaps=aliases(v,targets)
        specs={u['index'] for u in uses.values() if u['kind']==6};generics=v.generic_targets(specs)
        declared=fields(v,method['owner_index']);need([(x['name'],x['type'],x['offset']) for x in declared]==[('routeIsDifferentOnMobile','System.Boolean',16),('route','RRUI.Navigation.Route',24),('mobileRoute','RRUI.Navigation.Route',32)],'Exact three original serialized fields')
    controls=[]
    for at in [0,12,67,76,139,167,180,207]:
        changed=bytearray(code);changed[at]^=1
        try:shape(bytes(changed),va)
        except (ValueError,struct.error):controls.append({'offset':at,'rejected':True})
        else:raise ValueError('Changed opcode/branch/metadata/field/argument accepted at '+str(at))
    out=ROOT/'Validation'/('TitlePageRouteNative-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'original-complete-TitleScreenPage-Route-native-caller-and-typed-joins/v1','status':'exact_closed_caller_evidence_typed_callee_semantics_review_pending','original_inputs':pins,'method':method,'runtime_function':window,'shape':result,'all_PE_chained_regions_checked':chains,'declared_original_fields':declared,'metadata_usages':uses,'direct_original_pointer_aliases':direct,'alias_inventory_gaps':gaps,'generic_method_registrations':generics,'negative_controls':controls,'source_candidate_written':False,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'tool':pin(Path(__file__))}
    target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'direct_calls':{k:[x['owner']+'.'+x['name'] for x in rows] for k,rows in direct.items()},'uses':uses,'generic_methods':generics,'gap_count':len(gaps)}))
if __name__=='__main__':main()
