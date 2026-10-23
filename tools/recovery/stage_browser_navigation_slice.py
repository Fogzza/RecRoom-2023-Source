"""Stage exact browser cache getter and Route-to-Uri GoTo caller bodies only.

Data-only original native/typed joins. No SDK replacement, source apply,
compiler, Unity, game or network. These are bodies to merge into exact owners.
"""
from pathlib import Path
import copy,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from collect_browser_navigation_native import getter_shape,goto_shape
from stage_title_page_route_slice import property_for
from audit_original_rendering_sdk_candidates import h
from collect_title_page_route_native import pin
INPUT=ROOT/'Validation/BrowserNavigationNative-20261023T070925Z-b170daf3/report.json'
INPUT_SHA='c8c6b050cdabdec2b07c7786398c3131f530197b7862591729015c258879f142'
IL2CPP=WS/'Tools/Editors/2020.3.33f1/Editor/Data/il2cpp/libil2cpp'
def projected_property(path,owner,property_token,getter_token):
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=h.m.cli.Cli(b);r=h.Read(c);ti=next(i for i in range(1,c.rows[2]+1) if r.definition(i)==owner);properties=[]
        for i in range(1,c.rows[21]+1):
            a=c.row(21,i)
            if c.value(a,c.index(2))!=ti:continue
            start=c.value(a+c.index(2),c.index(23));end=c.value(c.row(21,i+1)+c.index(2),c.index(23)) if i<c.rows[21] else c.rows[23]+1
            for rid in range(start,end):
                at=c.row(23,rid);name=c.string(c.value(at+2,c.strw));getters=[]
                for j in range(1,c.rows[24]+1):
                    a=c.row(24,j);association=c.value(a+2+c.index(6),c.coded(1,[20,23]))
                    if association==((rid<<1)|1) and c.u16(a)&2 and (0x06000000|c.value(a+2,c.index(6)))==getter_token:
                        getters.extend(m for m in r.methods(ti) if m['token']==hex(getter_token))
                if getters:properties.append({'property_token':hex(0x17000000|rid),'name':name,'getter':getters})
        need(len(properties)==1 and len(properties[0]['getter'])==1,'Exact projected PropertyDef joined through original owner and getter MethodDef, not assumed PropertyDef row equality')
        actual=properties[0]
        return {'module':pin(path),'owner':owner,'type_token':hex(0x02000000|ti),'original_property_token':hex(property_token),'projected_property_token':actual['property_token'],'name':actual['name'],'getter':actual['getter'][0],'join_basis':'same exact owner and stable original getter MethodDef token/signature; projected PropertyDef table row may differ'}
def reference_width(v,t):
    need(not t['byref'] and not t['num_mods'] and not t['pinned'],'Only exact ordinary reference fields')
    if t['kind']==21:
        generic=v.raw(t['data'],24);definition=v.type_at(v.u64(v.b,generic));need(definition['kind']==18,'Generic cache field must instantiate a class, not a value type')
    else:need(t['kind']==18,'Every appended cache must be an original class reference')
    return 8
def layout(v):
    generic=23982;closed=23979;td=v.row('typeDefinitions',generic,88);ctd=v.row('typeDefinitions',closed,88)
    need(v.full_name(generic)=='RRUI.Data.RRUIModel`1' and v.type_info(closed)['parent_type']=='RRUI.Data.RRUIModel`1<RRUI.Data.RRUIModel/AAHMEOHNDKA>' and v.u16(v.m,ctd+68)==0,'Exact nongeneric closed specialization has no extra fields')
    need(((v.u32(v.m,td+80)>>6)&15)==0 and ((v.u32(v.m,td+80)>>10)&1)==1,'Original generic cache class uses default pointer packing')
    source=next(x for x in data['methods'] if x['original']['index']==161296);fields=copy.deepcopy(source['declared_original_fields'])
    need(len(fields)==9 and all(f['native_type']['attributes']==1 for f in fields),'Nine ordered private instance cache fields')
    widths=[reference_width(v,f['native_type']) for f in fields];sizes_table=v.u64(v.b,v.raw(0x187f85ef0+104,8));entry=v.u64(v.b,v.raw(sizes_table+closed*8,8));raw=bytes(v.b[v.raw(entry,16):v.raw(entry,16)+16]);sizes=struct.unpack('<iiii',raw)
    need(sizes==(208,-1,0,0),'Exact native closed nongeneric instance size208')
    first=sizes[0]-sum(widths);need(first==136,'Terminal nine pointer fields give exact first offset136')
    for i,f in enumerate(fields):f['closed_specialization_proven_offset']=first+sum(widths[:i])
    need(fields[0]['name']=='AHHIIOJFNNL' and fields[0]['token']=='0x40005b0' and fields[0]['type']=='RRUI.Data.BrowserModel','Original first cache field identity')
    return {'closed_type':v.type_info(closed),'original_parent_generic_type':v.type_info(generic),'typeDefinitionSizes_entry_address':hex(entry),'entry_bytes':raw.hex(),'entry_sha256':hashlib.sha256(raw).hexdigest(),'instance_size':sizes[0],'default_packing':True,'nine_terminal_reference_fields':fields,'reference_widths':widths,'first_cache_offset':first,'offset_basis':'Matching IL2CPP FieldLayout appends original declared instance fields in order; every one is an8-byte aligned class reference with default packing. Exact closed nongeneric RRUIModel has no additional fields and native size208, so its final9pointers start at136. Generic template offset0 is not used as an instance offset.','primary_layout_sources':[pin(IL2CPP/'metadata/FieldLayout.cpp'),pin(IL2CPP/'metadata/FieldLayout.h')]}
def joins(p):
    calls=p['direct_original_pointer_aliases'];equal=calls['0x1831721f0'];guard=calls['0x18661e5f0'];ctor=calls['0x186786240'];go=calls['0x181da5a50'];uses=p['metadata_usages']
    need(len(equal)==len(guard)==len(ctor)==len(go)==1,'Unique original caller-target registrations')
    need(equal[0]['owner']=='UnityEngine.Object' and equal[0]['name']=='op_Equality' and equal[0]['return']=='System.Boolean' and [x['type'] for x in equal[0]['parameters']]==['UnityEngine.Object','UnityEngine.Object'],'Exact Unity fake-null equality target')
    lookup=uses['0x18878e420'];need(lookup['kind']==6 and lookup['index']==428440 and lookup['method']['owner']=='UnityEngine.Component' and lookup['method']['name']=='GetComponentInParent' and not lookup['method']['parameters'] and lookup['method_argument_types']==['RRUI.Data.BrowserModel'] and p['generic_registrations']['428440'][0]['pointer']=='0x181166aa0','Exact GetComponentInParent<BrowserModel>() zero-argument overload')
    need(guard[0]['owner']=='FIHGBEHGLGB' and guard[0]['token']=='0x600040d' and guard[0]['return']=='System.Boolean' and not guard[0]['parameters'],'Exact Boolean guard getter')
    need(ctor[0]['owner']=='RRUI.Navigation.Uri' and ctor[0]['name']=='.ctor' and [x['type'] for x in ctor[0]['parameters']]==['RRUI.Navigation.Route[]'] and uses['0x18888a848']['type']=='RRUI.Navigation.Route[]' and uses['0x1887e6d78']['type']=='RRUI.Navigation.Uri','Exact one-Route array and Uri constructor, not an inferred collection')
    need(go[0]['owner']=='RRUI.Data.BrowserModel' and go[0]['name']=='GoTo' and go[0]['token']=='0x600081b' and [x['type'] for x in go[0]['parameters']]==['RRUI.Navigation.Uri','System.Boolean','System.Boolean'],'Exact Uri navigation overload, third explicit Boolean false, not null callback')
    field=next(f for r in p['methods'] if r['original']['index']==160903 for f in r['declared_original_fields'] if f['offset']==208)
    need(field['name']=='OJGNCHCIBNC' and field['token']=='0x4000526' and field['type']=='FIHGBEHGLGB','Exact original navigation guard field')
    return {'Unity_equality':equal[0],'parent_component_lookup':lookup,'guard_getter':guard[0],'Uri_constructor':ctor[0],'Uri_GoTo':go[0],'guard_field':field}
def main():
    global data
    need(pin(INPUT)['sha256']==INPUT_SHA,'Frozen two-caller native evidence');data=json.loads(INPUT.read_bytes());typed=joins(data);paths=[Path(x['path']) for x in data['original_inputs']]
    for x in data['original_inputs']:need(pin(x['path'])==x,'Exact original source files')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);layout_proof=layout(v)
        for row in data['methods']:
            code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);need(bytes(b[v.raw(va,len(code)):v.raw(va,len(code))+len(code)])==code,'Exact fresh original caller bytes')
            (getter_shape if row['original']['index']==161296 else goto_shape)(code,va)
        guardprop=property_for(v,typed['guard_getter']);need(guardprop['name']=='OGFHDNBGHMH' and guardprop['token']=='0x170000b3','Original guard PropertyDef')
        browserprop=property_for(v,data['methods'][0]['original'])
    guardalias=projected_property(WS/'RR23/CompilerSupport/References/RecRoom.Datastructures.Runtime.dll','FIHGBEHGLGB',int(guardprop['token'],16),0x0600040d);browseralias=projected_property(WS/'RR23/CompilerSupport/References/RecRoom.RRUI.Data.Runtime.dll','RRUI.Data.RRUIModel`1',int(browserprop['token'],16),0x060009a3)
    need(guardalias['getter']['token']==typed['guard_getter']['token'] and guardalias['getter']['signature']['return']=='bool' and not guardalias['getter']['signature']['parameters'],'Projected guard getter identity/signature unchanged')
    need(browseralias['name']=='BrowserModel' and browseralias['getter']['token']=='0x60009a3' and not browseralias['getter']['signature']['parameters'],'Actual projected BrowserModel source property spelling')
    controls=[]
    for idx,offsets,decoder in [(161296,[18,30,61,72,114,131,147],getter_shape),(160903,[26,69,113,142,197,205,218],goto_shape)]:
        row=next(r for r in data['methods'] if r['original']['index']==idx);raw=bytes.fromhex(row['runtime_function']['bytes'])
        for offset in offsets:
            value=bytearray(raw);value[offset]^=1
            try:decoder(bytes(value),int(row['native_pointer'],16))
            except (ValueError,struct.error):controls.append({'method':idx,'offset':offset,'rejected':True})
            else:raise ValueError('Unrecognized byte mutation accepted '+str((idx,offset)))
    out=ROOT/'Validation'/('BrowserNavigationSlice-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    getter='''// Getter BODY ONLY: merge into existing RRUI.Data.RRUIModel<T>.BrowserModel.
// Preserve owner/interface constraints, field, PropertyDef and method attributes.
{
    if (AHHIIOJFNNL == null)
        AHHIIOJFNNL = GetComponentInParent<RRUI.Data.BrowserModel>();
    return AHHIIOJFNNL;
}
'''
    go='''// BODY ONLY for BrowserModel.GoTo(Route NBCNOLJOIIM,bool HHPJOMNOHPC).
// Preserve existing signature, original optional/default metadata and all fields.
{
    if (OJGNCHCIBNC.'''+guardalias['name']+''')
        return;
    GoTo(new RRUI.Navigation.Uri(new RRUI.Navigation.Route[] { NBCNOLJOIIM }), HHPJOMNOHPC, false);
}
'''
    members=[]
    for name,text in [('RRUIModel.BrowserModel.get.body.cs',getter),('BrowserModel.GoTo.Route.body.cs',go)]:p=out/name;p.write_text(text,encoding='utf-8',newline='\n');members.append(pin(p))
    plan='''No compiler or runtime effects have run for these two SDK bodies.

Root-only next checks:
1. Merge these bodies into complete original owner declarations outside Main; compile against exact current metadata contracts. Preserve every other field/method/attribute/property/default value. No shadow game type may enter Main.
2. Metadata-only verify original cache/guard fields, UnityEngine.Object.op_Equality, Component.GetComponentInParent<BrowserModel>() exact zero-argument overload; Uri(Route[]) constructor and GoTo(Uri,bool,bool) with third argument false.
3. Exact getter body controlled effects: cached valid reference suppresses lookup/store; CLR-null and Unity fake-null invoke lookup once; same this and zero explicit args; lookup result exact identity including null; equality/lookup failures before store; field is reread on return; Unity native lifecycle is not claimed.
4. Exact GoTo body effects: null guard field throws before allocation; true guard returns before array/Uri/navigation; false guard builds a one-element array with same route including null; constructor receives it once; navigation receives same new Uri, original bool and false. Both bool inputs, guard/constructor/navigation exceptions, and original this identity.
5. Current Uri constructor, three-argument GoTo and guard-state initialization remain independent runtime dependencies. Passing wrapper tests does not prove a title screen or real navigation.
'''
    test=out/'ROOT_TEST_PLAN.txt';test.write_text(plan,encoding='utf-8')
    report={'schema':'original-browser-getter-and-Route-GoTo-source-caller-slice/v1','status':'two_closed_original_SDK_callers_staged_full_owner_binding_and_effects_UNVERIFIED','native_evidence':pin(INPUT),'members':members,'original_methods':[r['original'] for r in data['methods']],'typed_joins':typed,'cache_field_closed_generic_layout':layout_proof,'original_guard_property':guardprop,'source_guard_property_alias':guardalias,'original_browser_property':browserprop,'source_browser_property_alias':browseralias,'negative_controls':controls,'prior_provisional_label_corrected':'The prior raw-shape report labeled the zero R9 argument as null callback. Original registered GoTo token0x0600081B proves it is a Boolean: candidate passes false. The saved raw bytes/metadata were already exact; no metadata or binary changed.','all_native_caller_bytes_and_typed_application_targets_proven':True,'runtime_support_note':'Original array allocation/type/bounds/barrier/exception helpers are compiler/runtime support. Ordinary C# one-element typed array retains those semantics; no helper implementation is replaced.','Root_test_plan':pin(test),'known_unrecovered_callee_bodies':['Component.GetComponentInParent native Unity implementation is provided by matching engine','FIHGBEHGLGB.OGFHDNBGHMH guard state semantics/initialization','RRUI.Navigation.Uri..ctor(Route[])','RRUI.Data.BrowserModel.GoTo(Uri,bool,bool)'],'candidate_application_to_SDK_or_Main_performed':False,'Main_modified':False,'compiler_Unity_game_network_or_native_library_executed':False,'working_browser_title_login_navigation_claimed':False,'producer':pin(Path(__file__))}
    target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'members':members,'negative_controls':len(controls),'Main_modified':False,'compiled':False}))
if __name__=='__main__':main()
