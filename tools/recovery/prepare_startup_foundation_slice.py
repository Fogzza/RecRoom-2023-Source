"""Prepare proof-bound replacement members and three bounded native windows.

Data only. Never loads assemblies, compiles, starts Unity, or changes RR23.
Candidate members are for merging into their original metadata owners, never
new shadow classes in the game. Closure remains HOLD until every callee passes.
"""
from pathlib import Path
import datetime as dt
import hashlib
import json
import mmap
import struct
import sys
import uuid

HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]
ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata
from inventory_recroom_game_root_native import region
from prove_service_container_getter_native import decode as decode_getter
from prove_service_container_factory_native import decode as decode_factory
from prove_service_container_constructor_native import decode as decode_ctor
from prove_container_small_initializers_native import key as decode_key,aux as decode_aux
from audit_ogpeg_constructors import Decoder

PINS={
 'getter':('ServiceContainerGetterCFG-20261022T181446Z-208ec5d3','eaef8bcfe62906e44e58d1a7f587eeb2185485a8adc9dba8811f47cc9e6060f6'),
 'factory':('ServiceContainerFactoryCFG-20261022T182105Z-42400f6d','3e6fd771370d7135adb31be3a0c82b10caaf7875b54114a94497fcea186071a3'),
 'ctor':('ServiceContainerCtorCFG-20261022T181322Z-c199a46d','87a0159a74f277bc970c34eb1080ec1770ddf5048ab7a86793c114545b3252c0'),
 'initializers':('ContainerClosedInitializers-20261022T182144Z-99628e5a','d4a40fee686a1ae1d17d1668fd22e407c60a2a8627bd54519b9f6b1dea8e3746'),
 'awake':('RecRoomAwakeClosedCFG-20261022T172106Z-6b7b4e03','c671f9b39c2e9f3d93697b5b0e04cecb2fe5c654512d6c3277ca73ccbf751a7c'),
 'root_inventory':('RecRoomGameRootNative-20261022T162444Z-d9c732b7','9492989fb0f23794155b1e0bd6e9ae25eeae2fc86687a9e1016abfb14617d7f6'),
 'windows':('ServiceContainerNativeWindows-20261022T180635Z-6a8820b3','55ccd4ca6ab9aace322d1c159ba0cf7f88086de855d7a65e58724b5db98840cc'),
}
SOURCE_PINS={'GameAssembly.dll':'ba77682c3a51d9bf5461d933ce0a8569426260cd17ea6b4ce24b932b59ba129b','RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat':'1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474'}

def need(value,message):
    if not value:raise ValueError(message)
def sha(path):
    with Path(path).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def write(path,value):path.write_text(json.dumps(value,indent=2)+'\n',encoding='utf-8')

def decode_thin(code,va,parameters):
    d=Decoder(code,va)
    if parameters==0:d.literal('45 33 c9 45 33 c0 33 d2')
    elif parameters==1:d.literal('4c 8b c2 45 33 c9 33 d2')
    else:raise ValueError('Only exact zero/string overloads')
    target=d.relative('e9');semantic=d.at;d.literal('cc cc cc');d.end()
    need(target==0x186745480 and len(code)==16 and semantic==13,'Exact original private ctor tail and padding required')
    return {'all16bytes_checked':True,'semantic_bytes':13,'padding_bytes':3,'target':hex(target),'this_preserved':True,'parent':None,'name':'original string argument' if parameters else None,'native_hidden_MethodInfo':None,'tail_only_no_extra_effects':True}

def sources():
    return {
 'MPAAIECKLGA.members.cs':'''// Merge these replacement members into the existing original MPAAIECKLGA.
// PNFLFFOAING is the original getter MethodDef of CFHDLGEGDFD, not a new API.
public static MNALHHOLFGL CFHDLGEGDFD
{
    get
    {
        if (OAEHHEPLLJE == null)
        {
            NAFLJHIHEAG zero = (NAFLJHIHEAG)0;
            object boxed = zero;
            string name = boxed.ToString();
            zero = (NAFLJHIHEAG)boxed;
            OAEHHEPLLJE = OBAIKOPBHAP(name, null);
        }
        return OAEHHEPLLJE;
    }
}

private static MNALHHOLFGL OBAIKOPBHAP(string LGENGCEEBPB, MNALHHOLFGL DDFCHDGPJBN)
{
    string message = string.Concat("DI: Creating Container (", LGENGCEEBPB, ")");
    HJDBOADFHMC? color = new HJDBOADFHMC?(HJDBOADFHMC.LMOLABKFOAB);
    PNAABCMOHGM.FPNMONCCAAE(message, in color);
    if (DDFCHDGPJBN != null)
        return DDFCHDGPJBN.MJHONDPGJFA(LGENGCEEBPB);
    return new MNALHHOLFGL(LGENGCEEBPB);
}
''',
 'MNALHHOLFGL.members.cs':'''// Replace the original field initializers and constructor bodies in MNALHHOLFGL.
// Preserve all other original fields/members/attributes. Do not add duplicate fields.
private readonly System.Collections.Generic.Dictionary<CPAMAFPANDM, NJAICAFMPBE> AAHKPPMHGFI = new System.Collections.Generic.Dictionary<CPAMAFPANDM, NJAICAFMPBE>();
private readonly System.Collections.Generic.Dictionary<CPAMAFPANDM, CKAJONGONMK> LMAFHCPPMAD = new System.Collections.Generic.Dictionary<CPAMAFPANDM, CKAJONGONMK>();
private readonly OENEDGPIOFN OLGLBMGAHBO = new OENEDGPIOFN();

public MNALHHOLFGL() : this(null, null) {}
public MNALHHOLFGL(string LGENGCEEBPB) : this(null, LGENGCEEBPB) {}

private MNALHHOLFGL(MNALHHOLFGL DDFCHDGPJBN, string LGENGCEEBPB)
{
    this.DDFCHDGPJBN = DDFCHDGPJBN;
    this.LGENGCEEBPB = LGENGCEEBPB;
    this.MGADLDPDPGK = (PFCPCBJDEMB)0;
    this.PHJOGIEDKPN<MNALHHOLFGL>(this, null);
}
''',
 'CPAMAFPANDM.members.cs':'''// Replacement constructor within the existing original CPAMAFPANDM value type.
// Both original readonly fields and the complete remainder of the type stay intact.
public CPAMAFPANDM(System.Type KGFBELINAJD, string JFKHNCFJNDG)
{
    this.AFJAGKNNCBE = KGFBELINAJD;
    this.FEKLPCPODAH = JFKHNCFJNDG;
}
''',
 'OENEDGPIOFN.members.cs':'''// Replace original field initializers and preserve the empty Object-base ctor body.
// OMMELJLAGLB is deliberately not initialized: the original ctor does not write it.
private readonly System.Collections.Generic.Dictionary<CPAMAFPANDM, NPDGPDKAHLN> NLDFDGJCKFH = new System.Collections.Generic.Dictionary<CPAMAFPANDM, NPDGPDKAHLN>();
private readonly System.Collections.Generic.HashSet<NPDGPDKAHLN> DJGFOAKOCAP = new System.Collections.Generic.HashSet<NPDGPDKAHLN>();
public OENEDGPIOFN() {}
'''}

def main():
    proof={};proof_refs=[]
    for name,(folder,digest) in PINS.items():
        path=ROOT/'Validation'/folder/'report.json';need(sha(path)==digest,'Pinned native proof changed: '+name);proof[name]=json.loads(path.read_bytes());proof_refs.append({'role':name,'path':str(path),'sha256':digest})
    native=[ROOT/'CodeSource'/rel for rel in SOURCE_PINS]
    for path in native:need(sha(path)==SOURCE_PINS[path.relative_to(ROOT/'CodeSource').as_posix()],'Original input SHA changed')
    g=proof['getter'];f=proof['factory'];c=proof['ctor'];initializers=proof['initializers'];awake=proof['awake'];controls=[]
    need(decode_getter(bytes.fromhex(g['all240_native_bytes']),int(g['native_pointer'],16))==g['exact_control_flow'],'Getter full CFG changed')
    need(decode_factory(bytes.fromhex(f['all384bytes']),int(f['native_pointer'],16))==f['shape'],'Factory full CFG changed')
    need(decode_ctor(bytes.fromhex(c['native_bytes']),int(c['native_pointer'],16))==c['exact_shape'],'Private constructor full CFG changed')
    for name,decoder in [('key_constructor',decode_key),('auxiliary_constructor',decode_aux)]:
        row=initializers[name];need(decoder(bytes.fromhex(row['native']['bytes']),int(row['pointer'],16))==row['shape'],'Exact initializer CFG changed')
    native_windows=[];thin=[]
    with native[0].open('rb') as bf,native[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as binary,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as metadata:
        v=ExternMetadata(binary,metadata)
        # Revalidate the two concrete generic MethodSpecs, not a shared-pointer name guess.
        for usage_name,spec,pointer,label in [('metadata_D_base_method',306224,'0x18333e400','Singleton<GameRoot>.Awake'),('metadata_B_value_method',452543,'0x1813b9460','MNAL.HHCPOGCCGNF<MFENCGHNPBJ>')]:
            use=awake['original_metadata_uses'][usage_name];need(use['index']==spec,'Exact MethodSpec changed');definition,ci,gi=struct.unpack_from('<iii',binary,v.method_specs+spec*12)
            need(definition==use['method']['index'] and [v.typename(t) for t in v.inst(ci)]==use['class_argument_types'] and [v.typename(t) for t in v.inst(gi)]==use['method_argument_types'],'Typed original generic instantiation changed')
            targets=v.generic_targets({spec})[spec];need(len(targets)==1 and targets[0]['pointer']==pointer and targets[0]['adjustor_thunk_index']==-1,'Exact original generic target registration changed')
            window=region(v,int(pointer,16));native_windows.append({'label':label,'original':use['method'],'method_spec':spec,'class_arguments':use['class_argument_types'],'method_arguments':use['method_argument_types'],'native_pointer':pointer,'registration':targets[0],'runtime_function':window,'complete_method_CFG_claimed':False,'CSharp_candidate':None})
        cleanup=v.find_method('GameRoot',0x06000003);need(v.method_pointer(cleanup)==0x18680d960,'Original GameRoot cleanup pointer changed');window=region(v,0x18680d960)
        old=next(r for r in proof['root_inventory']['methods'] if r['original']['owner']=='GameRoot' and r['original']['name']=='OnDestroy');need(window==old['runtime_function'],'Saved GameRoot cleanup native region changed')
        native_windows.append({'label':'GameRoot.OnDestroy','original':cleanup,'native_pointer':'0x18680d960','runtime_function':window,'complete_method_CFG_claimed':False,'CSharp_candidate':None})
        for token,count in [(0x06000028,0),(0x06000029,1)]:
            method=v.find_method('MNALHHOLFGL',token);need(len(method['parameters'])==count and method['name']=='.ctor','Thin constructor metadata changed');pointer=v.method_pointer(method);raw=v.raw(pointer,16);code=bytes(binary[raw:raw+16]);shape=decode_thin(code,pointer,count)
            original=next(r for r in proof['windows']['methods'] if r['original']['index']==method['index']);need(original['runtime_function']['bytes']==code.hex(),'Saved thin constructor input changed')
            thin.append({'original':method,'native_pointer':hex(pointer),'all16bytes':code.hex(),'native_sha256':hashlib.sha256(code).hexdigest(),'shape':shape})
            for offset in (0,2,8,9,13):
                changed=bytearray(code);changed[offset]^=1
                try:decode_thin(bytes(changed),pointer,count)
                except (ValueError,struct.error):controls.append({'case':'thin_ctor_'+str(count)+'_byte_'+str(offset),'rejected':True})
                else:raise ValueError('Changed thin ctor accepted')
        # New report reuses full saved typed proofs and fresh exact original byte spans.
        for row,field in [(g,'all240_native_bytes'),(f,'all384bytes'),(c,'native_bytes')]:
            code=bytes.fromhex(row[field]);at=v.raw(int(row['native_pointer'],16),len(code));need(bytes(binary[at:at+len(code)])==code,'Native candidate input bytes changed')
    out=ROOT/'Validation'/('StartupFoundationSlice-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    members=[]
    for name,text in sources().items():
        path=out/name;path.write_text(text,encoding='utf-8',newline='\n');members.append({'path':str(path),'sha256':sha(path),'format':'replacement_member_declarations_within_original_metadata_owner_not_standalone_compilation_unit'})
    write(out/'new-thin-constructor-proof.json',{'schema':'original-container-thin-constructor-complete-CFG/v1','status':'both_public_overloads_complete_all_native_bytes_typed_target_proved','methods':thin,'negative_controls':controls,'source_inputs':[{'path':str(p),'sha256':SOURCE_PINS[p.relative_to(ROOT/'CodeSource').as_posix()]} for p in native]})
    write(out/'bounded-next-native-windows.json',{'schema':'exact-startup-foundation-three-method-native-input/v1','status':'bounded_exact_registered_inputs_for_Root_controlled_decoder_only','methods':native_windows,'original_bytes':sum(len(bytes.fromhex(r['runtime_function']['bytes'])) for r in native_windows),'whole_method_control_flow_or_CSharp_recovery_claimed':False})
    blockers=[
      {'target':'SingletonMonoBehaviour<GameRoot>.Awake','native_pointer':'0x18333e400','gap':'Exact generic registration and first pdata region now captured; complete CFG/metadata calls and singleton static storage semantics still require decoding. Preserve current body until closed.'},
      {'target':'GameRoot.OnDestroy','native_pointer':'0x18680d960','gap':'897-byte entry region is original and revalidated; collection cleanup/finally paths, metadata calls, and base semantics have no closed replacement body yet.'},
      {'target':'MNALHHOLFGL.HHCPOGCCGNF<MFENCGHNPBJ>','native_pointer':'0x1813b9460','gap':'Concrete original MethodSpec452543 and exact native entry region captured; resolution/null/exception paths not reconstructed.'},
      {'target':'MPAA factory callees','gap':'HJDBOADFHMC static color initialization, PNAABCMOHGM.FPNMONCCAAE logging, and parent MJHONDPGJFA behavior remain original dependencies; logging is preserved, never bypassed.'},
      {'target':'MNAL private constructor registration tail','gap':'PHJOGIEDKPN<MNALHHOLFGL> body has prior closed CFG, but provider construction/registration, dependency-map insertion, cycle/duplicate/disposed checks and original exceptions are not a closed runtime graph.'},
      {'target':'MFENCGHNPBJ','gap':'Required memory-service original registration/provider remains unproved; never substitute a default/new service.'},
    ]
    plan={'schema':'original-startup-foundation-member-candidate-and-Root-test-plan/v1','status':'HOLD_not_applicable_as_working_bootstrap','all_boot_dependencies_closed':False,'safe_to_apply_four_root_methods':False,'members':members,'proved_candidate_method_count':7,'CSharp_compiled_or_effects_proved':False,'new_thin_ctor_proof':{'path':str(out/'new-thin-constructor-proof.json'),'sha256':sha(out/'new-thin-constructor-proof.json')},'next_decoder_input':{'path':str(out/'bounded-next-native-windows.json'),'sha256':sha(out/'bounded-next-native-windows.json')},'prior_complete_CFG_proofs':proof_refs,'blockers':blockers,'Root_only_test_plan':[
      'Decode only the three pinned original native windows under owned256MiB job/reserve1.5GiB; entry pdata is not a whole-method proof. Follow every external branch/exception/finally target before reconstructing source.',
      'For each candidate, compile replacement members only in exact original owner/field/signature context outside RR23; copy no shadow type into Main. Bind original PNFLFFOAING to property CFHDLGEGDFD using original PropertyDef ownership.',
      'Compare compiled field targets, generic scopes, calls, exception edges and initializer-before-base order against the native proofs. Preserve original attributes, field metadata and all unmodified members.',
      'Run cache-hit/cache-miss getter controls, same-reference final shared-field reload, enum-name/factory exception propagation, parent-null and nonnull factory branches, exact logging-first sequence, constructor allocation/registration order and rejected duplicate/cycle/disposed paths only after those original bodies close.',
      'Retain negative controls for wrong field/method scope, wrong generic args, removed logging, wrong parent/name, omitted registration, null/default resolver and changed exception behavior.',
      'Require all dependencies and actual MFENCGHNPBJ provider closed before combining existing RecRoomBootFourMethodCandidate. Root must review compiled effect and isolated actual startup evidence before any Main application.',
    ],'preserve_genuine_empty_base_hook':{'owner':'GameRoot','name':'HPCJAAEDLCH','native_pointer':'0x1806f84d0','do_not_replace_native_proven_empty_behavior':True},'Main_changed':False,'publication_changed':False,'Unity_compiler_game_network_executed':False,'pure_controls':len(controls)}
    write(out/'plan.json',plan)
    readme='''This is an unapplied, uncompiled replacement-member candidate set, not an assembly or a functional bootstrap. Merge member declarations only into their existing original metadata owners; preserve every omitted declaration/attribute. Do not add shadow classes to RR23. The two public MNAL constructor tails are newly closed against all16 original bytes. Getter/factory/private ctor/key+aux initialization reuse full native proofs. Seven C# candidate methods retain unresolved original callees. Singleton Awake, GameRoot cleanup and memory resolver have exact fresh native windows only; no C# behavior is guessed. See plan.json for blocking dependencies and the controlled Root-only compilation/runtime gates. No Main or publication file was changed.\n'''
    (out/'README.txt').write_text(readme,encoding='utf-8')
    print(json.dumps({'status':plan['status'],'plan':str(out/'plan.json'),'plan_sha256':sha(out/'plan.json'),'candidate_methods':7,'new_complete_native_constructor_bodies':2,'pure_negative_controls':len(controls),'next_native_window_bytes':sum(len(bytes.fromhex(r['runtime_function']['bytes'])) for r in native_windows),'members':members}))

if __name__=='__main__':main()
