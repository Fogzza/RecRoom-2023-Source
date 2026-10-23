"""Bounded, data-only original RRUI browser getter/navigation caller evidence."""
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
from collect_title_page_route_native import pin
def getter_shape(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 08 48 89 74 24 10 57 48 83 ec 20');flag=d.relative('80 3d','00');d.literal('48 8b f9');ready=d.short('75')
    method=d.relative('48 8d 0d');init1=d.relative('e8');klass=d.relative('48 8d 0d');init2=d.relative('e8');written=d.relative('c6 05','01');loaded=va+d.at
    loadklass=d.relative('48 8b 0d');d.literal('48 8b b7 88 00 00 00 f6 81 33 01 00 00 04');noinit=d.short('74');d.literal('83 b9 e0 00 00 00 00');inited=d.short('75');classinit=d.relative('e8');atinit=va+d.at
    d.literal('45 33 c0 33 d2 48 8b ce');equal=d.relative('e8');d.literal('84 c0');cached=d.short('74');loadmethod=d.relative('48 8b 15');d.literal('48 8b cf');lookup=d.relative('e8')
    d.literal('48 8b d0 48 89 87 88 00 00 00 48 8d 8f 88 00 00 00');barrier=d.relative('e8');returned=va+d.at
    d.literal('48 8b 87 88 00 00 00 48 8b 5c 24 30 48 8b 74 24 38 48 83 c4 20 5f c3');d.end()
    need(len(code)==172 and flag==written and ready==loaded and method==loadmethod and klass==loadklass and noinit==inited==atinit and cached==returned,'All getter metadata/cache/control-flow joins')
    need(init1==init2==0x1806c01e0 and classinit==0x180640f10 and barrier==0x1806bfd30,'Exact standard runtime helper anchors')
    return {'all172bytes_recognized':True,'all_branches_closed':True,'cache_offset':136,'cached_object_equality_call':hex(equal),'lookup_call':hex(lookup),'metadata_usages':[hex(method),hex(klass)],'cache_effects':['read cached field at136','compare cached reference to null through original Unity equality helper','if equality false skip lookup and writes','if true invoke original lookup on same this','store returned reference at136 and perform ordinary GC barrier','reload shared cached field and return'],'Unity_fake_null_semantics_required':True,'field_identity_not_inferred_from_generic_template_offset_zero':True}
def goto_shape(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 10 48 89 6c 24 18 56 48 83 ec 30');flag=d.relative('80 3d','00');d.literal('41 0f b6 e8 48 8b da 48 8b f1');ready=d.short('75')
    arrayclass=d.relative('48 8d 0d');init1=d.relative('e8');collectionclass=d.relative('48 8d 0d');init2=d.relative('e8');written=d.relative('c6 05','01');loaded=va+d.at
    d.literal('48 8b 8e d0 00 00 00 48 89 7c 24 40 48 85 c9');nullfield=d.relative('0f 84');d.literal('33 d2');guard=d.relative('e8');d.literal('84 c0');stopped=d.short('75')
    loadarray=d.relative('48 8b 0d');d.literal('ba 01 00 00 00');allocatearray=d.relative('e8');d.literal('48 8b f8 48 85 c0');nullarray=d.short('74');d.literal('48 85 db');nullroute=d.short('74')
    d.literal('48 8b 10 48 8b cb 48 8b 52 40');checkstore=d.relative('e8');d.literal('48 85 c0');badtype=d.short('74');beforebounds=va+d.at;d.literal('83 7f 18 00');badbounds=d.short('76')
    d.literal('48 8d 4f 20 48 8b d3 48 89 19');barrier=d.relative('e8');loadcollection=d.relative('48 8b 0d');allocate=d.relative('e8');d.literal('45 33 c0 48 8b d7 48 8b c8 48 8b d8');ctor=d.relative('e8')
    d.literal('45 33 c9 48 c7 44 24 20 00 00 00 00 44 0f b6 c5 48 8b d3 48 8b ce');navigate=d.relative('e8');epilog=va+d.at
    d.literal('48 8b 7c 24 40 48 8b 5c 24 48 48 8b 6c 24 50 48 83 c4 30 5e c3');nre=va+d.at;nullthrow=d.relative('e8');d.literal('cc');bounds=va+d.at;makebounds=d.relative('e8');d.literal('48 8b c8 33 d2');throwbounds=d.relative('e8');d.literal('cc');typefail=va+d.at;maketype=d.relative('e8');d.literal('48 8b c8 33 d2');throwtype=d.relative('e8');d.literal('cc');d.end()
    need(len(code)==283 and flag==written and ready==loaded and arrayclass==loadarray and collectionclass==loadcollection,'Exact goto metadata joins')
    need(nullfield==nullarray==nre and stopped==epilog and nullroute==beforebounds and badtype==bounds and badbounds==typefail,'All goto normal/exception branches closed')
    need(init1==init2==0x1806c01e0 and allocatearray==0x1806bfdb0 and allocate==0x1806c0340 and checkstore==0x1806bfd40 and barrier==0x1806bfd30 and nullthrow==0x1806c0390 and throwbounds==throwtype==0x1806c0360,'Exact original array/allocation/barrier/throw support anchors')
    return {'all283bytes_recognized':True,'all_branches_closed':True,'guard_field_offset':208,'guard_call':hex(guard),'collection_constructor_call':hex(ctor),'navigation_call':hex(navigate),'metadata_usages':[hex(arrayclass),hex(collectionclass)],'runtime_array_allocation':hex(allocatearray),'runtime_array_store_typecheck':hex(checkstore),'runtime_bounds_exception_factory':hex(maketype),'runtime_array_type_exception_factory':hex(makebounds),'effects':['load field208; null fails before any route allocation','call exact guard on field208; true returns before allocation','allocate exact original typed one-element array','store same route reference, preserving null and ordinary array runtime checks','allocate exact original collection with that same array as sole explicit constructor argument','call navigation on same this with same collection, original bool and null third explicit callback argument','return without extra field writes'],'collection_or_guard_type_not_guessed':True}
def main():
    paths=[ROOT/'CodeSource'/x for x in EXPECTED];pins=[pin(x) for x in paths];need(all(x['sha256']==EXPECTED[Path(x['path']).relative_to(ROOT/'CodeSource').as_posix()] for x in pins),'Original source SHA pins')
    rows=[];targets=set();uses={}
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md)
        for owner,token,va,decode in [('RRUI.Data.RRUIModel`1',0x060009a3,0x184579e50,getter_shape),('RRUI.Data.BrowserModel',0x0600081a,0x181da60f0,goto_shape)]:
            method=v.find_method(owner,token);window=region(v,va);code=bytes.fromhex(window['bytes']);shape=decode(code,va);chains=no_chained_entries(v,[window]);declared=fields(v,method['owner_index'])
            for key,value in shape.items():
                if key.endswith('_call'):targets.add(int(value,16))
            for address in shape['metadata_usages']:uses[address]=v.usage(int(address,16))
            rows.append({'original':method,'native_pointer':hex(va),'runtime_function':window,'shape':shape,'no_chained_regions':chains,'declared_original_fields':declared})
        need(v.generic_targets({283318})[283318][0]['pointer']=='0x184579e50','Exact original RRUIModel<AAHMEOHNDKA> BrowserModel getter registration')
        direct,gaps=aliases(v,targets);generic=v.generic_targets({x['index'] for x in uses.values() if x['kind']==6})
    out=ROOT/'Validation'/('BrowserNavigationNative-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'original-browser-getter-and-GoTo-two-closed-native-callers/v1','status':'closed_native_shapes_typed_target_and_generic_field_join_review_pending','original_inputs':pins,'methods':rows,'metadata_usages':uses,'direct_original_pointer_aliases':direct,'generic_registrations':generic,'unbacked_alias_inventory_gaps':gaps,'CSharp_candidate_written':False,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'tool':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'calls':{k:[x['owner']+'.'+x['name'] for x in a] for k,a in direct.items()},'uses':uses,'generic_registrations':generic}))
if __name__=='__main__':main()
