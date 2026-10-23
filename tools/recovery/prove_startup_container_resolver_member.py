"""Close the exact495-byte original resolver; stage an unapplied typed member."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from audit_ogpeg_constructors import Decoder
from collect_all_pinvoke_native import ExternMetadata
from prepare_startup_foundation_slice import SOURCE_PINS
SLICE=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207'
JOINS=SLICE/'TypedJoins-20261023T063732Z-89bb5d75/report.json'
JOINS_SHA='277f6503fc8054a8937e81fe7b7dc709725efdb922a8b824726e46cb90122b3e'
def need(value,message):
    if not value:raise ValueError(message)
def sha(path):
    with Path(path).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def decode(code,va):
    d=Decoder(code,va);d.literal('48 89 5c 24 10 48 89 6c 24 18 48 89 74 24 20 57 48 83 ec 40');flag=d.relative('80 3d','00');d.literal('49 8b f8 48 8b f2 48 8b e9');skip=d.short('75');type_use=d.relative('48 8d 0d');init1=d.relative('e8');disposed=d.relative('48 8d 0d');init2=d.relative('e8');written=d.relative('c6 05','01');ready=va+d.at
    loaded_disposed=d.relative('48 8b 15');d.literal('0f 57 c0 0f b6 4d 39 45 33 c0 0f 11 44 24 20 48 c7 44 24 50 00 00 00 00');check=d.relative('e8');loaded_type=d.relative('48 8b 0d');d.literal('48 8b 5f 30 f6 81 33 01 00 00 04 48 8b 1b');no_cctor1=d.short('74');d.literal('83 b9 e0 00 00 00 00');no_cctor2=d.short('75');cctor1=d.relative('e8');cctor1_ready=va+d.at
    d.literal('33 d2 48 8b cb');typeof1=d.relative('e8');d.literal('45 33 c9 48 8d 4c 24 20 4c 8b c6 48 8b d0');key_ctor=d.relative('e8');d.literal('48 8b 47 30 4c 8d 44 24 50 0f 28 44 24 20 48 8d 54 24 30 48 8b cd 66 0f 7f 44 24 30 4c 8b 50 08 4d 8b ca 41 ff 12 84 c0');miss=d.short('74')
    d.literal('48 8b 44 24 50 48 8b 5c 24 58 48 8b 6c 24 60 48 8b 74 24 68 48 83 c4 40 5f c3');miss_at=va+d.at
    d.literal('48 8b 5f 30');miss_type1=d.relative('48 8d 0d');d.literal('48 8b 1b');miss_init1=d.relative('e8');d.literal('f6 80 33 01 00 00 04');no_cctor3=d.short('74');miss_type2=d.relative('48 8d 0d');miss_init2=d.relative('e8');d.literal('83 b8 e0 00 00 00 00');no_cctor4=d.short('75');miss_type3=d.relative('48 8d 0d');miss_init3=d.relative('e8');d.literal('48 8b c8');cctor2=d.relative('e8');cctor2_ready=va+d.at
    d.literal('33 d2 48 8b cb');typeof2=d.relative('e8');format_use1=d.relative('48 8d 0d');d.literal('48 8b e8');format_init1=d.relative('e8');d.literal('48 8b f8 48 85 f6');null_name=d.short('74');format_use2=d.relative('48 8d 0d');format_init2=d.relative('e8');d.literal('48 8b f8');quote_use=d.relative('48 8d 0d');quote_init=d.relative('e8');prefix_use=d.relative('48 8d 0d');d.literal('48 8b d8');prefix_init=d.relative('e8');d.literal('48 8b c8 45 33 c9 4c 8b c3 48 8b d6');concat=d.relative('e8');joined=d.short('eb');null_at=va+d.at;empty_use=d.relative('48 8d 0d');empty_init=d.relative('e8');join_at=va+d.at
    d.literal('45 33 c9 4c 8b c0 48 8b d5 48 8b cf');format_call=d.relative('e8');exception_use=d.relative('48 8d 0d');d.literal('48 8b d8');exception_init=d.relative('e8');d.literal('48 8b c8');allocate=d.relative('e8');d.literal('45 33 c0 48 8b d3 48 8b c8 48 8b f8');exception_ctor=d.relative('e8');throw_context=d.relative('48 8d 0d');throw_context_init=d.relative('e8');d.literal('48 8b d0 48 8b cf');throw=d.relative('e8');d.literal('cc');d.end()
    need(len(code)==495 and flag==written and skip==ready and miss==miss_at and null_name==null_at and joined==join_at,'Complete init/success/miss/name-branch CFG changed')
    need(no_cctor1==no_cctor2==cctor1_ready and no_cctor3==no_cctor4==cctor2_ready,'Class initialization edges changed')
    need(type_use==loaded_type==miss_type1==miss_type2==miss_type3 and disposed==loaded_disposed and format_use1==format_use2,'Exact loaded metadata aliases changed')
    need({init1,init2,miss_init1,miss_init2,miss_init3,format_init1,format_init2,quote_init,prefix_init,empty_init,exception_init,throw_context_init}=={0x1806c01e0},'Exact original metadata initialization helper')
    need(cctor1==cctor2==0x180640f10 and allocate==0x1806c0340 and throw==0x1806c0360,'Original runtime helpers changed')
    need(check==0x186743bb0 and typeof1==typeof2==0x183d98380 and key_ctor==0x1807af930 and concat==0x18476bde0 and format_call==0x18476ea50 and exception_ctor==0x184782fd0,'Exact typed original callees changed')
    return {'all495bytes_checked':True,'all_normal_and_throw_edges_closed':True,'success_returns_exact_out_value':True,'disposed_field_offset':57,'rgctx_type_slot':0,'rgctx_resolve_method_slot':1,'try_resolve_out_stack_offset':80,'check':hex(check),'type_from_handle':hex(typeof1),'key_constructor':hex(key_ctor),'concat':hex(concat),'format':hex(format_call),'exception_ctor':hex(exception_ctor),'metadata_uses':{'type_class':hex(type_use),'disposed_message':hex(disposed),'missing_format':hex(format_use1),'suffix_quote':hex(quote_use),'suffix_prefix':hex(prefix_use),'empty_suffix':hex(empty_use),'exception_class':hex(exception_use),'native_throw_method_context':hex(throw_context)}}
def main():
    need(sha(JOINS)==JOINS_SHA,'Pinned typed native joins changed');joins=json.loads(JOINS.read_bytes());inputs=json.loads((SLICE/'bounded-next-native-windows.json').read_bytes());row=next(r for r in inputs['methods'] if r['method_spec']==452543);code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);shape=decode(code,va)
    context=next(r['method'] for r in joins['original_rgctx_contexts'] if r['label']==row['label']);need(context['count']==2 and context['rows'][0]['type']=='TInterface','Exact original generic return type context');callee=context['rows'][1];need(callee['kind']==3 and callee['method']['owner']=='MNALHHOLFGL' and callee['method']['name']=='NGBMOPMLJCM' and callee['method_arguments']==['TInterface'] and [p['type'] for p in callee['method']['parameters']]==['CPAMAFPANDM','TType&'],'Exact original TryResolve generic method context')
    paths=[ROOT/'CodeSource'/p for p in SOURCE_PINS]
    for p in paths:need(sha(p)==SOURCE_PINS[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source drift')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as binary,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as metadata:
        v=ExternMetadata(binary,metadata);at=v.raw(va,len(code));need(bytes(binary[at:at+len(code)])==code,'Original exact resolver bytes changed');need(v.method_info(row['original']['index'])==row['original'],'Original resolver metadata changed')
        gp=v.row('genericParameters',2891,16);owner,name,start,count,num,flags=struct.unpack_from('<iiHHHH',metadata,gp);generic_name=v.string(name);need(owner==1693 and generic_name=='TInterface' and num==0,'Exact original generic parameter ownership');need(flags in (0,4) and count==0,'Unsupported original generic constraints; do not guess')
        constraints=' where TInterface : class' if flags==4 else ''
        uses={key:v.usage(int(address,16)) for key,address in shape['metadata_uses'].items()};literals={key:joins['RIP_metadata_uses'][shape['metadata_uses'][key]]['literal']['utf8'] for key in ['disposed_message','missing_format','suffix_quote','suffix_prefix','empty_suffix']}
        need(literals=={'disposed_message':'You should not try to retrieve bindings from a disposed container!','missing_format':'No dependency of type {0} found{1}','suffix_quote':'"','suffix_prefix':' with customId "','empty_suffix':''},'Original exception/check literals changed')
        need(uses['exception_class']['type']=='System.ArgumentException' and uses['type_class']['type']=='System.Type','Exact original exception/Type class')
    controls=[]
    for label,pattern,bias in [('disposed_field','0f b6 4d 39',3),('rgctx_type','48 8b 1b',2),('out_storage','4c 8d 44 24 50',4),('rgctx_method','4c 8b 50 08',3),('return_value','48 8b 44 24 50',4),('name_test','48 85 f6',2),('throw_context','48 8b d0 48 8b cf',2)]:
        anchor=bytes.fromhex(pattern);need(code.count(anchor)>=1,'Exact mutation anchor absent');at=code.index(anchor)+bias;changed=bytearray(code);changed[at]^=1
        try:decode(bytes(changed),va)
        except (ValueError,struct.error):controls.append({'case':label,'rejected':True})
        else:raise ValueError('Incorrect original resolver mutation accepted')
    text='''// Replacement member within the existing original MNALHHOLFGL only.
// Preserve original generic/parameter/member metadata and all other declarations.
public TInterface HHCPOGCCGNF<TInterface>(string OGLHPPMJANF = null)CONSTRAINTS
{
    MKECFLEMHEL.GFKAFPHLKMJ(this.KBDIBPJIHNN, "You should not try to retrieve bindings from a disposed container!");
    CPAMAFPANDM key = new CPAMAFPANDM(typeof(TInterface), OGLHPPMJANF);
    TInterface value;
    if (this.NGBMOPMLJCM<TInterface>(key, out value))
        return value;
    string suffix = OGLHPPMJANF != null ? string.Concat(" with customId \\\"", OGLHPPMJANF, "\\\"") : "";
    throw new System.ArgumentException(string.Format("No dependency of type {0} found{1}", typeof(TInterface), suffix));
}
'''.replace('CONSTRAINTS',constraints)
    out=SLICE/('ResolverMember-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();candidate=out/'MNALHHOLFGL.resolver.member.cs';candidate.write_text(text,encoding='utf-8',newline='\n')
    report={'schema':'original-MNAL-required-resolver-complete-CFG-member-candidate/v1','status':'complete_original_CFG_typed_member_staged_CSharp_effects_and_callee_closure_pending','original':row['original'],'method_spec':452543,'concrete_boot_argument':'MFENCGHNPBJ','native_pointer':row['native_pointer'],'native_code_sha256':hashlib.sha256(code).hexdigest(),'exact_shape':shape,'generic_parameter':{'native_index':2891,'owner_generic_container':owner,'name':generic_name,'num':num,'flags':flags,'constraints_count':count},'typed_original_rgctx':context,'exact_literals':literals,'candidate':{'path':str(candidate),'sha256':sha(candidate),'format':'original-owner-replacement-member_not_standalone_type'},'negative_controls':controls,'typed_joins':{'path':str(JOINS),'sha256':JOINS_SHA},'blocking_original_callees':['MKECFLEMHEL.GFKAFPHLKMJ must retain original disposed-check behavior','MNALHHOLFGL.NGBMOPMLJCM<TType> original lookup/provider/parent/cycle/error behavior is not yet reconstructed','Actual MFENCGHNPBJ registration/provider must resolve without fake/default objects'],'CSharp_compiled_effects_proved':False,'safe_to_apply_as_working_bootstrap':False,'Main_changed':False,'compiler_Unity_game_network_executed':False}
    save(out/'report.json',report);print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'sha256':sha(out/'report.json'),'candidate':report['candidate'],'negative_controls':len(controls)}))
if __name__=='__main__':main()
