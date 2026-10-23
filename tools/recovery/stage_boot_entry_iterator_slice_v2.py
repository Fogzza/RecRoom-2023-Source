"""Precise source-binding amendment: original Launch target is a property setter.

All prior754 native controls/scopes and failed full compile are frozen. Only
the Launch source syntax changes, to the independently joined original property.
"""
from pathlib import Path
import base64,datetime as dt,hashlib,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from collect_title_page_route_native import pin
from stage_title_small_callbacks_slice import accessor_property
OLD=ROOT/'Validation/BootEntryIteratorSlice-20261023T111820Z-512326d9/report.json'
FAILED=ROOT/'Validation/BootEntryIteratorBindingEffects-20261023T112532Z-7ba930b6/run-report.json'
def main():
    need(pin(OLD)['sha256']=='175efd654aed4ea71f62c8598312d5cf20416fc1ad3cb05e43540f01eab8b789' and pin(FAILED)['sha256']=='23f462d3cfd8c1088c2d2a0685279c62da0ef899b2cbc3983711c60e9c6e7823','Frozen native proof and actual first full-compile failure');p=json.loads(OLD.read_bytes());failure=json.loads(FAILED.read_bytes());need(len(failure['phases'])==1 and failure['phases'][0]['exit_code']==1 and not failure['Main_modified'],'Exact actual source-binding failure before helper/effects')
    for k in ['source','source_meta','candidate','producer']:need(pin(p[k]['path'])==p[k],'Frozen original v1 source/producer')
    paths=[Path(x['path']) for x in p['original_inputs']]
    for x in p['original_inputs']:need(pin(x['path'])==x,'Exact genuine source authority')
    with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
        v=ExternMetadata(b,md);setter=v.method_info(195614);prop=accessor_property(v,setter);need(setter['token']=='0x6001497' and setter['owner']=='BootSequence' and setter['name']=='BCOIAODGNGB' and setter['flags']==2177 and setter['flags']&0x800 and setter['return']=='System.Void' and [x['type'] for x in setter['parameters']]==['BootSequence/INFFBPOJOIJ'] and v.method_pointer(setter)==0x180a57590 and prop=={'name':'GAKFIBCGHNA','token':'0x1700038c','setter_index':195614,'getter_index_relative':5},'Exact original SpecialName setter and accessor-owned PropertyDef')
    before=Path(p['source']['path']).read_bytes();declaration=b'private INFFBPOJOIJ GAKFIBCGHNA\n{\nget \t{\r\n\t\treturn INFFBPOJOIJ.APP_SETUP;\r\n\t}\r\n\nset {\r\n\t}\n}\n';need(before.count(declaration)==1,'Exact existing source property type/name/accessors, mixed newlines unchanged by amendment')
    edits=json.loads(json.dumps(p['byte_edits']));launch=[x for x in edits if x['member']=='LaunchGame'];need(len(launch)==1,'One exact Launch member');old=base64.b64decode(launch[0]['replacement_base64']);a=b'this.BCOIAODGNGB(INFFBPOJOIJ.POST_LOGIN_RECNET_OPERATIONS);';z=b'this.GAKFIBCGHNA = INFFBPOJOIJ.POST_LOGIN_RECNET_OPERATIONS;';need(old.count(a)==1,'Only original target call expression replaced by property assignment');launch[0]['replacement_base64']=base64.b64encode(old.replace(a,z)).decode();after=before
    for e in sorted(edits,key=lambda x:x['start'],reverse=True):
        original=base64.b64decode(e['original_base64']);new=base64.b64decode(e['replacement_base64']);at=e['start'];need(before[at:at+e['length']]==original,'All nine original source spans preserved');after=after[:at]+new+after[at+e['length']:]
    oldafter=Path(p['candidate']['path']).read_bytes();need(oldafter.count(a)==1 and after==oldafter.replace(a,z,1),'Byte-exact entire v2 candidate differs from v1 by this sole accessor syntax correction')
    out=ROOT/'Validation'/('BootEntryIteratorSlice-v2-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();candidate=out/'BootSequence.cs';candidate.write_bytes(after);members=out/'RecoveredBootEntryIterator.members.cs';members.write_bytes(b'// Existing original-owner replacement spans only; not standalone classes.\r\n'+b'\r\n'.join(base64.b64decode(e['replacement_base64']) for e in edits));p.update(schema='nine-original-Boot-entry-iterator-basics-source-bodies/v2',status='nine_complete_original_bodies_staged_binding_and_controlled_effects_pending',producer=pin(Path(__file__)),preserved_original_native_proof=pin(OLD),preserved_failed_v1_full_compile=pin(FAILED),original_property_setter_association={'method':setter,'property':prop,'unchanged_current_source_declaration_sha256':hashlib.sha256(declaration).hexdigest(),'only_source_expression_changed':{'before':a.decode(),'after':z.decode()},'runtime_metadata_not_modified':True,'new_alias_method_or_wrapper_added':False},candidate=pin(candidate),readable_members=pin(members),byte_edits=edits);rp=out/'report.json';rp.write_text(json.dumps(p,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(rp),'candidate':pin(candidate),'only_accessor_syntax_amended':True,'Main_modified':False}))
if __name__=='__main__':main()
