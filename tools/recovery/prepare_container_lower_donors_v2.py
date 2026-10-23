"""Stage eight original lower-container member bodies in readable donor contexts.

Pure source preparation only. Nonselected declarations serve compilation and
must never replace original types, helpers, metadata, or unresolved providers.
Actual compilation/effects/body-only import are separate future Root gates.
"""
from pathlib import Path
import datetime as dt,hashlib,json,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
SLICE=ROOT/'Validation/StartupFoundationSlice-20261023T063133Z-8c701207'
RESOLVER=SLICE/'ResolverMember-20261023T064202Z-0d6ce17e/report.json'
RESOLVER_SHA='34b102177e1d9c00cf2bddfc200585e93926ef19333ceb45f5f8dabc69508348'
def need(v,m):
    if not v:raise ValueError(m)
def pin(path):
    p=Path(path).resolve(strict=True)
    with p.open('rb') as f:s=hashlib.file_digest(f,'sha256').hexdigest()
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':s}
def save(path,value):
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2);f.write('\n')
def stable_source(name,text):
    path=HERE/name;data=text.encode('utf-8')
    if path.exists():need(path.read_bytes()==data,'Never replace an existing reviewed donor source')
    else:
        with path.open('xb') as f:f.write(data)
    return pin(path)
def main():
    plan=SLICE/'plan.json';need(pin(plan)['sha256']=='0f78cf06c8fb62414cf2717934893a4111829482c42d48e62f6ab7f811b864fe','Original seven-member proof plan')
    p=json.loads(plan.read_bytes());members={Path(r['path']).name:r for r in p['members']}
    for row in p['prior_complete_CFG_proofs']:need(pin(row['path'])['sha256']==row['sha256'],'Frozen original lower-member proof')
    initializer=next(row for row in p['prior_complete_CFG_proofs'] if row['role']=='initializers');original_initializer=json.loads(Path(initializer['path']).read_bytes());ommel=next(row for row in original_initializer['auxiliary_constructor']['fields'] if row['name']=='OMMELJLAGLB');need(ommel['type']=='System.Collections.Generic.List`1<CPAMAFPANDM>' and ommel['native_type']['attributes']==1 and ommel['offset']==32,'Exact original private nonreadonly list-of-key field context')
    for r in members.values():need(pin(r['path'])['sha256']==r['sha256'],'Frozen original candidate member bytes')
    need(pin(RESOLVER)['sha256']==RESOLVER_SHA,'Complete resolver native/typed proof');resolve=json.loads(RESOLVER.read_bytes());rp=resolve['candidate'];need(pin(rp['path'])['sha256']==rp['sha256'],'Resolver member bytes')
    text=lambda name:Path(members[name]['path']).read_text(encoding='utf-8')
    resolver=Path(rp['path']).read_text(encoding='utf-8')
    # Compiler contexts deliberately omit unselected implementations. Selected
    # bodies below are inserted byte-for-byte from the already proved fragments.
    uject='''// Eight-body recovery source context, outside Assets compilation.
// Only the explicitly listed original member bodies/field initializer effects
// may be imported. Never deploy this donor DLL wholesale or import helper stubs.
using System;
using System.Collections.Generic;
public interface NJAICAFMPBE { } // original-name compiler context, not an implementation
public interface CKAJONGONMK { } // original-name compiler context, not an implementation
public sealed class MNALHHOLFGL
{
    private readonly MNALHHOLFGL DDFCHDGPJBN;
    private readonly string LGENGCEEBPB;
    private PFCPCBJDEMB MGADLDPDPGK;
    private bool KBDIBPJIHNN;
    private enum PFCPCBJDEMB:byte { CompileContextZero=0 }
'''+text('MNALHHOLFGL.members.cs')+'\n'+resolver+'''
    // Unrecovered callees are declarations for donor binding only.
    // They are not selected for transplantation or execution.
    public MNALHHOLFGL PHJOGIEDKPN<TClass>(TClass CMDPMJBEBAB,string OGLHPPMJANF=null) where TClass:class { throw new NotImplementedException("Unselected original provider/registration body"); }
    public MNALHHOLFGL MJHONDPGJFA(string name) { throw new NotImplementedException("Unselected original child-container body"); }
    private bool NGBMOPMLJCM<TType>(CPAMAFPANDM key,out TType value) where TType:class { throw new NotImplementedException("Unselected original lookup/provider body"); }
}
public struct CPAMAFPANDM
{
    public readonly Type AFJAGKNNCBE;
    public readonly string FEKLPCPODAH;
'''+text('CPAMAFPANDM.members.cs')+'''
}
internal sealed class OENEDGPIOFN
{
    private sealed class NPDGPDKAHLN { } // compilation context, never imported
    private List<CPAMAFPANDM> OMMELJLAGLB; // stays default/null; no initializer
'''+text('OENEDGPIOFN.members.cs')+'''
}
internal static class MKECFLEMHEL
{
'''+(HERE/'RecoveredDisposedGuardDonor.cs').read_text().split('public static class MKECFLEMHEL\n{\n',1)[1].rsplit('\n}\n',1)[0]+'''
}
'''
    initialization='''// Only original getter/factory bodies are selected, never this donor module.
// Genuine RecRoom.AgInitialization.Interfaces, RecRoom.Debugging.Runtime and
// UJect.Runtime metadata must supply the external types and callable members.
public static class MPAAIECKLGA
{
    private static MNALHHOLFGL OAEHHEPLLJE;
'''+text('MPAAIECKLGA.members.cs')+'\n}\n'
    donors=[stable_source('RecoveredUjectContainerLowerDonor.v2.cs',uject),stable_source('RecoveredInitializationLowerDonor.v2.cs',initialization)]
    selected=[{'assembly':'UJect.Runtime','owner':'MNALHHOLFGL','name':'.ctor','parameters':[]},{'assembly':'UJect.Runtime','owner':'MNALHHOLFGL','name':'.ctor','parameters':['System.String']},{'assembly':'UJect.Runtime','owner':'MNALHHOLFGL','name':'.ctor','parameters':['MNALHHOLFGL','System.String']},{'assembly':'UJect.Runtime','owner':'CPAMAFPANDM','name':'.ctor','parameters':['System.Type','System.String']},{'assembly':'UJect.Runtime','owner':'OENEDGPIOFN','name':'.ctor','parameters':[]},{'assembly':'UJect.Runtime','owner':'MNALHHOLFGL','name':'HHCPOGCCGNF','generic_arity':1,'parameters':['System.String']},{'assembly':'RecRoom.AgInitialization.Runtime','owner':'MPAAIECKLGA','original_name':'PNFLFFOAING','donor_property_getter':'get_CFHDLGEGDFD','property':'CFHDLGEGDFD','parameters':[]},{'assembly':'RecRoom.AgInitialization.Runtime','owner':'MPAAIECKLGA','name':'OBAIKOPBHAP','parameters':['System.String','MNALHHOLFGL']}]
    out=SLICE/('LowerContainerDonors-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'eight-original-lower-container-readable-donor-contexts/v2','status':'eight_proven_member_sources_staged_compilation_effects_import_pending','selected_members':selected,'donor_sources':donors,'original_seven_member_proof':pin(plan),'original_resolver_proof':pin(RESOLVER),'input_member_fragments':list(members.values())+[rp],'unselected_helper_bodies_explicitly_throw_and_never_imported':True,'all_selected_source_fragments_inserted_verbatim':True,'unselected_OMMEL_field_context_correction':'Original field is List<CPAMAFPANDM>; retains default/null, never written by selected constructor. Prior uncompiled v1 context retained.','future_gates':['Compile exact donor owners against current genuine compiler-visible external metadata, preserving original property-getter identity on import.','Verify selected constructors/getter/factory/resolver metadata signatures, generic constraints, readonly field identities and original external scopes.','Execute controlled constructor initializer-before-base/self-registration effect ordering, getter cached/miss/final shared-field reload, logging/parent factory branch, disposed guard, successful/null/missing/throwing lookup and exact exception payload cases.','Body-only import into freshly pinned current original plugins; retain the already tested disposed guard, all other bodies and all original metadata.','Actual production provider/registration/logger/color/lookup bodies remain unresolved and must not be replaced by donor stubs or fake services. RecRoomGameRoot.Awake activation stays held.'],'Main_modified':False,'compiler_Unity_game_network_executed':False,'working_boot_or_login_claimed':False}
    report['original_OMMEL_field_authority']={'proof':initializer,'field':ommel}
    path=out/'report.json';save(path,report);print(json.dumps({'report':pin(path),'selected_bodies':8,'readable_donors':donors,'status':report['status']}))
if __name__=='__main__':main()
