"""Prove all three original provider ctor CFGs and stage replacement members.

Data-only original native/metadata reading. NPIL/JEM are proven empty Object
forwarders, equivalent to retained bodies; PLIPH adds the missing value store.
"""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from audit_ogpeg_constructors import Decoder
from collect_title_page_route_native import pin
from collect_nameserver_request_factory_native import fields
from resolve_startup_foundation_native_joins import rgctx
from prove_container_instance_registration_members import parameters
from stage_title_page_route_slice import property_for
RUN=ROOT/'Validation/ContainerInstanceProviderConstructors-20261023T103719Z-937da9bf'
RECEIPT_SHA='3bac630043ca140cc44f1170f70fa219a3702b6f717478d6ab2f3e0248a4e01e'

def empty(code,va):
    d=Decoder(code,va);d.literal('4883ec284885c9');null=d.short('74');d.literal('33d24883c428');base=d.relative('e9');null_at=va+d.at;throw=d.relative('e8');d.literal('cc');d.end();need(len(code)==26 and null==null_at and base==0x1806f84d0 and throw==0x1806c0390,'Entire26B original constructor: receiver check then Object base tail, no field access/user effects');return {'all26_original_bytes_checked':True,'base_Object_ctor':hex(base),'no_user_fields_written':True,'no_value_type_constraint_added':True,'current_retained_Object_forwarder_semantics_already_match':True}

def value(code,va):
    d=Decoder(code,va);d.literal('48895c2408574883ec20488bfa488bd94885c9');null=d.short('74');d.literal('498b40184c8b80c0000000498b00488bd0ff10488d4b18488bd7488939488b5c24304883c4205f');barrier=d.relative('e9');null_at=va+d.at;throw=d.relative('e8');d.literal('cc');d.end();need(len(code)==71 and null==null_at and barrier==0x1806bfd30 and throw==0x1806c0390,'Entire71B original ctor: class-rgctx base0 then same captured value store24 and GC barrier');return {'all71_original_bytes_checked':True,'base_ctor_class_rgctx_slot':0,'input_value_captured_before_base':True,'readonly_value_field_offset_for_registered_object_shared_body':24,'same_original_value_stored_after_base':True,'value_null_not_rejected':True,'all_nonterminal_original_CFG_edges_closed':True}

def main():
    receipt=RUN/'run-report.json';need(pin(receipt)['sha256']==RECEIPT_SHA,'Actual Root123B inert decode');done=json.loads(receipt.read_bytes());need(done['status']=='three_complete_original_provider_constructor_scopes_decoded_semantics_pending','Successful exact constructor decode');need(pin(done['plan']['path'])==done['plan'] and pin(done['output']['path'])==done['output'],'Exact actual decoder outputs');plan=json.loads(Path(done['plan']['path']).read_bytes());need(pin(plan['input']['path'])==plan['input'],'Original three complete scopes');data=json.loads(Path(plan['input']['path']).read_bytes());decoded=[json.loads(x) for x in Path(done['output']['path']).read_text().splitlines()];need([x['original']['index'] for x in data['methods']]==[47984,47940,47945] and [x['native_method_index'] for x in decoded]==[47984,47940,47945],'Exact three original constructors');shapes=[];controls=[]
    for row,stream in zip(data['methods'],decoded):
        code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);byip={x['ip']:x for x in stream['instructions']};position=va
        for i in stream['instructions']:need(i['ip']==position,'Whole instruction stream contiguous');position+=i['length']
        need(position==va+len(code),'Every original ctor byte decoded');fn=value if row['original']['index']==47940 else empty;shapes.append({'original':row['original'],'shape':fn(code,va)})
        for offset in range(len(code)):
            changed=bytearray(code);changed[offset]^=1
            try:fn(bytes(changed),va)
            except (ValueError,IndexError):controls.append({'original_method_index':row['original']['index'],'byte_offset':offset,'rejected':True})
            else:raise ValueError('Ctor byte mutation accepted '+str((row['original']['index'],offset)))
    paths=[Path(x['path']) for x in plan['original_inputs']]
    for x in plan['original_inputs']:need(pin(x['path'])==x,'Pinned genuine source authority')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);originals=[]
        for row in data['methods']:
            m=row['original'];need(v.method_info(m['index'])==m,'Every original ctor owner/token/signature retained');gp=parameters(v,v.type_info(m['owner_index'])['generic_container_index']);need(gp==[{'name':'TImpl','number':0,'flags':0,'constraints':[]}],'All three owner type parameters are genuinely unconstrained');originals.append({'type':v.type_info(m['owner_index']),'method':m,'generic_parameters':gp,'fields':fields(v,m['owner_index'])})
        context=rgctx(v,'UJect.Runtime.dll',0x02000013);need(len(context['rows'])==2 and context['rows'][0]['kind']==3 and context['rows'][0]['method']['index']==47945 and context['rows'][0]['class_arguments']==['TImpl'] and context['rows'][1]['type']=='JEMKLLFDDFD<TImpl>','PLIPH original class-rgctx slot0 is exact original JEM<TImpl> base ctor')
        need(v.type_info(6627)['parent_type']=='System.Object' and not fields(v,6627) and v.type_info(6610)['parent_type']=='System.Object','Two exact Object base ctor targets');jfields=fields(v,6610);pfields=fields(v,6609);need(len(jfields)==1 and jfields[0]['name']=='OEAONLGBBPN' and jfields[0]['type']=='System.Boolean' and jfields[0]['native_type']['attributes']==1,'One original base bool instance field, left at CLR default false');need(len(pfields)==1 and pfields[0]['token']=='0x4000027' and pfields[0]['name']=='<LHGCALINHGC>k__BackingField' and pfields[0]['type']=='TImpl' and pfields[0]['native_type']['attributes']==33 and v.type_info(6609)['parent_type']=='JEMKLLFDDFD<TImpl>','Exact original private readonly generic value field and class base')
        getter=v.method_info(47939);prop=property_for(v,getter);need(getter['name']=='BIPPELCLGMM' and prop['name']=='OAPFKCFKCOD' and prop['setter_index_relative']==-1,'Original property/getter is obfuscated independently of retained backing-field name')
        objectctor=v.find_method('System.Object',0x06001081);need(v.method_pointer(objectctor)==0x1806f84d0,'Exact shared Object base constructor native target');tdj=v.row('typeDefinitions',6610,88);tdp=v.row('typeDefinitions',6609,88)
        for td in [tdj,tdp]:need(((v.u32(v.m,td+80)>>6)&15)==0 and ((v.u32(v.m,td+80)>>10)&1)==1,'Original default packing')
        layout={'registered_class_argument':'System.Object','Object_header_bytes':16,'base_instance_field':jfields[0],'base_bool_offset':16,'base_field_end':17,'registered_reference_field_alignment':8,'derived_reference_field_offset':(17+7)&~7,'basis':'Matching official IL2CPP FieldLayout places the one base bool after16-byte Object header; whether inherited padding is reused or rounded, next8-byte object-shared generic reference aligns to24. Generic template offsets0 are not used as instance offsets. No unregistered value-type native layout is claimed.','official_sources':[pin(WS/'Tools/Editors/2020.3.33f1/Editor/Data/il2cpp/libil2cpp/metadata'/x) for x in ['FieldLayout.cpp','FieldLayout.h']]};need(layout['derived_reference_field_offset']==24,'Native store24 uniquely joins exact sole derived value field')
    text='''// Replacement constructors only in their original existing generic owners.
// NPILHMLGJCC<TImpl>, original protected constructor06000083.
// Retained Object-forwarding body already has these complete semantics.
protected NPILHMLGJCC() : base()
{
}

// JEMKLLFDDFD<TImpl>, original protected constructor0600005c.
// Its existing private bool field stays at its ordinary CLR default false.
protected JEMKLLFDDFD() : base()
{
}

// PLIPHMBIGMM<TImpl>, original public constructor06000057.
// In the thin compiler-only donor, a readonly auto-property LHGCALINHGC
// deliberately emits the exact original field <LHGCALINHGC>k__BackingField.
// That donor-only property declaration is NEVER transplanted: the actual
// original PropertyDef is OAPFKCFKCOD/getter BIPPELCLGMM and stays unchanged.
public PLIPHMBIGMM(TImpl MPDCNJJFJHP) : base()
{
    this.LHGCALINHGC = MPDCNJJFJHP;
}
'''
    out=ROOT/'Validation'/('ContainerInstanceProviderConstructorMembers-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();candidate=out/'original-instance-provider-constructor.members.cs';candidate.write_text(text,encoding='utf-8',newline='\n');report={'schema':'three-original-provider-constructor-complete-native-members/v1','status':'three_complete_ctor_semantics_proven_binding_effects_and_combined_staging_pending','actual_Root_decoder_receipt':pin(receipt),'actual_decoded_output':done['output'],'original_scopes':plan['input'],'original_inputs':plan['original_inputs'],'original_constructor_contracts':originals,'complete_shapes':shapes,'negative_controls':controls,'PLIPH_original_rgctx_base_join':context,'original_value_field':pfields[0],'original_JEM_bool_field':jfields[0],'original_getter_and_property':{'getter':getter,'property':prop},'object_shared_value_field_layout':layout,'Object_base_constructor':objectctor,'candidate':pin(candidate),'logical_ctor_members':3,'unique_native_body_bytes':97,'sum_native_bytes':123,'already_semantically_complete_retained_constructors':['NPILHMLGJCC..ctor06000083','JEMKLLFDDFD..ctor0600005c'],'constructor_with_missing_value_store':'PLIPHMBIGMM..ctor06000057','remaining_runtime_dependencies':['Actual matching-player generic ctor and stored-value observations still pending','Provider retrieval/callbacks, PHJ/JON/private registration paths remain untested production runtime boundaries'],'Main_modified':False,'compiler_Unity_player_network_executed':False,'working_instance_provider_or_boot_claimed':False,'producer':pin(Path(__file__))};target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'candidate':pin(candidate),'native_negative_controls':len(controls),'retained_empty_ctor_semantics_already_match':2,'new_value_storing_ctor':1}))
if __name__=='__main__':main()
