"""Read exact CLI MethodImpl/MethodSemantics for the one global:: name prefix.

Never load a game assembly. This authorizes one inspector association only;
source, interface declarations and runtime metadata names are not rewritten.
"""
from pathlib import Path
import datetime as dt,hashlib,json,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
from audit_cli_marshal_contracts import Cli
from audit_hashable_scoped_vtable import Read
from audit_finite_aot_system_core import identity
ORIGINAL=ROOT/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll'
COMPILED=ROOT/'Validation/BootEntryIteratorBindingEffects-v2-20261023T113127Z-5d1ff4f2/Assembly-CSharp.dll'
FAILED=COMPILED.parent/'run-report.json'
def need(v,m):
    if not v:raise ValueError(m)
def pin(p):
    p=Path(p).resolve(strict=True);return {'path':str(p),'bytes':p.stat().st_size,'sha256':hashlib.sha256(p.read_bytes()).hexdigest()}
def contract(path,token):
    c=Cli(path.read_bytes());r=Read(c);rid=token&0xffffff;a=c.row(6,rid);name=c.string(c.value(a+8,c.strw));sig=c.blob(c.value(a+8+c.strw,c.blobw));impl=[];w=c.coded(1,[6,10])
    for i in range(1,c.rows[25]+1):
        at=c.row(25,i);owner=c.value(at,c.index(2));body=c.value(at+c.index(2),w);decl=c.value(at+c.index(2)+w,w)
        if body==rid<<1:impl.append({'MethodImpl_RID':i,'owner':r.definition(owner),'body_MethodDef':hex(token),'declaration_tag':decl&1,'declaration_rid':decl>>1})
    need(len(impl)==1 and impl[0]['declaration_tag']==1,'One exact original interface MemberRef declaration for this MethodDef');d=impl[0];a2=c.row(10,d['declaration_rid']);mw=c.coded(3,[2,1,26,6,27]);parent=c.value(a2,mw);need(parent&7==1,'Exact interface TypeRef parent');d.update(declaration_owner=r.typeref(parent>>3),declaration_name=c.string(c.value(a2+mw,c.strw)),declaration_signature=c.blob(c.value(a2+mw+c.strw,c.blobw)).hex());properties=[];aw=c.coded(1,[20,23])
    for i in range(1,c.rows[24]+1):
        at=c.row(24,i);sem=c.u16(at);method=c.value(at+2,c.index(6));assoc=c.value(at+2+c.index(6),aw)
        if method==rid:
            need(sem==2 and assoc&1,'This exact method is solely a property getter');pa=c.row(23,assoc>>1);properties.append({'MethodSemantics_RID':i,'semantics':sem,'PropertyDef':hex(0x17000000|(assoc>>1)),'name':c.string(c.value(pa+2,c.strw)),'signature':c.blob(c.value(pa+2+c.strw,c.blobw)).hex()})
    need(len(properties)==1,'One exact getter-owned property');return {'MethodDef':hex(token),'name':name,'signature':sig.hex(),'flags':c.u16(a+6),'impl_flags':c.u16(a+4),'MethodImpl':d,'property':properties[0]}
def validate(original,compiled):
    need(original['MethodDef']=='0x60014fd' and compiled['MethodDef']=='0x6010126' and original['name']=='System.Collections.IEnumerator.get_Current' and compiled['name']=='global::System.Collections.IEnumerator.get_Current','Only this one known exact explicit-interface method name prefix')
    for row,token in [(original,'null'),(compiled,'b77a5c561934e089')]:
        need(row['signature']=='20001c' and row['flags']==2529 and row['impl_flags']==0,'Exact object(), private/final/virtual/newslot/SpecialName/managed flags');d=row['MethodImpl'];need(d['owner']=='BootSequence/NEKGMMPKEPF' and d['body_MethodDef']==row['MethodDef'] and d['declaration_owner']=='[mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken='+token+']System.Collections.IEnumerator' and d['declaration_name']=='get_Current' and d['declaration_signature']=='20001c','Exact distinct retained-generated-provider or genuine-compiler framework interface target');need(row['property']['semantics']==2 and row['property']['signature']=='28001c','Exact getter-associated object property signature')
    need(original['property']['name']=='System.Collections.IEnumerator.Current' and compiled['property']['name']=='global::System.Collections.IEnumerator.Current','Only the matching one getter-associated PropertyDef has same known exact prefix')
def main():
    need(pin(ORIGINAL)['sha256']=='15cbc3614b2986da2813cfc82b640199029d8a9b5a60fd8f42db2bdaee7ea9fe' and pin(COMPILED)['sha256']=='82939fb7697bb8525cb01505678f134912404f94f74f1745e2abbc14ad667673' and pin(FAILED)['sha256']=='a4fedea13fef2d57963953e6dcf0347acc2d4ca95ea31a68fc569c17036a790b','Exact original metadata and actual v2 full compile/failure');failure=json.loads(FAILED.read_bytes());need([x['exit_code'] for x in failure['phases']]==[0,0,1] and not failure['Main_modified'],'Both compiler phases passed before inspector-only failure');a=contract(ORIGINAL,0x060014fd);b=contract(COMPILED,0x06010126);validate(a,b);controls=[]
    for name,side,key,value in [('wrong_original_method_name','original','name','get_Current'),('wrong_compiler_prefix','compiled','name','other::System.Collections.IEnumerator.get_Current'),('wrong_original_signature','original','signature','200008'),('missing_virtual_final_flags','compiled','flags',129),('wrong_interface_owner','compiled','MethodImpl.declaration_owner','System.Collections.Generic.IEnumerator'),('wrong_interface_member','original','MethodImpl.declaration_name','MoveNext'),('wrong_interface_signature','compiled','MethodImpl.declaration_signature','200002'),('wrong_getter_property','compiled','property.name','global::Other.Current'),('wrong_property_signature','original','property.signature','280002'),('wrong_MethodImpl_body','compiled','MethodImpl.body_MethodDef','0x6010125')]:
        x=json.loads(json.dumps(a));y=json.loads(json.dumps(b));row=x if side=='original' else y;parts=key.split('.')
        for part in parts[:-1]:row=row[part]
        row[parts[-1]]=value
        try:validate(x,y)
        except ValueError:controls.append({'control':name,'rejected':True})
        else:raise ValueError('Explicit-interface association mutation accepted '+name)
    api=WS/'Tools/Editors/2020.3.33f1/Editor/Data/MonoBleedingEdge/lib/mono/4.7.1-api/mscorlib.dll';c=Cli(api.read_bytes());read=Read(c);need(identity(c,32,1)['full_name']=='mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089','Exact genuine matching compiler API assembly identity');types=[i for i in range(1,c.rows[2]+1) if read.definition(i)=='System.Collections.IEnumerator'];need(len(types)==1 and c.u32(c.row(2,types[0]))&0x20,'Genuine framework IEnumerator interface');getters=[x for x in read.methods(types[0]) if x['name']=='get_Current'];need(len(getters)==1 and getters[0]['signature']['blob']=='20001c' and getters[0]['flags']&0x440==0x440,'Exact genuine API virtual/abstract Current getter and object() signature');framework={'file':pin(api),'identity':identity(c,32,1),'interface_TypeDef':hex(0x02000000|types[0]),'getter':getters[0]}
    out=ROOT/'Validation'/('BootCurrentMethodImplProjection-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();r={'schema':'one-original-to-source-Current-explicit-interface-MethodImpl-association/v1','status':'one_exact_global_prefix_association_proven_without_source_or_runtime_name_change','producer':pin(Path(__file__)),'original_metadata':pin(ORIGINAL),'actual_compiled_full_source':pin(COMPILED),'preserved_v2_inspector_failure':pin(FAILED),'original_contract':a,'compiled_contract':b,'compiler_exact_genuine_framework_definition':framework,'scope_distinction':'Retained generated InitialAssemblies provider refers to mscorlib4.0/null token; actual source compiler refers to matching genuine mscorlib4.0/b77 API. These exact distinct identities are recorded, not declared byte-identical or rewritten. Both MethodImpls explicitly target the same named IEnumerator.get_Current object() contract.','negative_controls':controls,'only_inspector_name_pair':{'original':a['name'],'compiled':b['name']},'source_declaration_or_runtime_metadata_changed':False,'SDK_or_game_code_executed':False};p=out/'report.json';p.write_text(json.dumps(r,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(p),'negative_controls':len(controls)}))
if __name__=='__main__':main()
