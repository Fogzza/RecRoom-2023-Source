"""Pure production-alias/header and existing emitted-Core evidence; no managed load."""
from pathlib import Path
import datetime as dt,io,json,mmap,struct,uuid
from audit_original_rendering_sdk_candidates import h
from run_projected_generic_name_player_binding import HERE,WS,ROOT,pin,need

def aliases(path):
    data=path.read_bytes();stream=io.BytesIO(data)
    def count(limit):
        raw=stream.read(4);need(len(raw)==4,'Manifest bounded count');n=struct.unpack('<i',raw)[0];need(0<=n<=limit,'Manifest count bound');return n
    def text():
        size=0;shift=0
        for _ in range(5):
            raw=stream.read(1);need(len(raw)==1,'Manifest UTF8 string length');b=raw[0];size|=(b&127)<<shift
            if not b&128:break
            shift+=7
        else:raise ValueError('Manifest string length overflow')
        need(size<=1024*1024,'Bounded manifest string');raw=stream.read(size);need(len(raw)==size,'Manifest exact UTF8 string bytes');return raw.decode('utf-8')
    header=[text() for _ in range(6)];need(header[0]=='RR23-METADATA-RESTORE-6' and header[1]=='Assembly-CSharp','Exact existing schema and whole-Core target');whole=stream.read(1);need(whole in (b'\x00',b'\x01'),'Boolean grammar');exclusions=[text() for _ in range(count(1000))];rows=[dict(zip(['Assembly','OriginalFullName','CompiledFullName'],[text(),text(),text()])) for _ in range(count(100000))]
    selected=[x for x in rows if x['Assembly']=='RecRoom.Datastructures.Runtime' and x['OriginalFullName']=='HHOBPMOCKMJ'];need(selected==[{'Assembly':'RecRoom.Datastructures.Runtime','OriginalFullName':'HHOBPMOCKMJ','CompiledFullName':'HHOBPMOCKMJ`1'}],'Exactly one existing manifest-authorized inverse alias')
    return {'manifest':pin(path),'schema':header[0],'assembly':header[1],'whole_original_assembly':whole==b'\x01','type_alias_count':len(rows),'selected_alias':selected[0],'bytes_read_through_type_alias_prefix':stream.tell(),'full_manifest_bytes':len(data),'full_manifest_parser_executed':False,'explicit_exclusions':exclusions}

def core(path):
    with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
        c=h.m.cli.Cli(b);r=h.Read(c);refs=[{'TypeRef_token':hex(0x01000000|i),'scoped_name':r.typeref(i)} for i in range(1,c.rows[1]+1) if r.typeref(i).endswith((']HHOBPMOCKMJ',']HHOBPMOCKMJ`1'))];owners=[i for i in range(1,c.rows[2]+1) if r.definition(i)=='RecRoom.Core.UI.UIInputModule'];need(len(owners)==1,'Existing emitted Core exact UI owner');ti=owners[0];off=4+2*c.strw+c.coded(2,[2,1,27]);lo=c.value(c.row(2,ti)+off,c.index(4));hi=c.value(c.row(2,ti+1)+off,c.index(4)) if ti<c.rows[2] else c.rows[4]+1;fields=[]
        for i in range(lo,hi):
            at=c.row(4,i);name=c.string(c.value(at+2,c.strw))
            if name=='onPointerPressed':
                blob=c.blob(c.value(at+2+c.strw,c.blobw));need(blob[0]==6,'Original field signature prefix');typ,end=r.type(blob,1);need(end==len(blob),'Complete field signature');fields.append({'FieldDef_token':hex(0x04000000|i),'name':name,'scoped_field_type':typ})
        need(len(fields)==1,'Existing emitted Core named field unique')
        return {'module':pin(path),'assembly_identity':r.asm,'matching_TypeRefs':refs,'onPointerPressed_field':fields[0],'stale_prior_build_output_not_current_source_compile':True}

def main():
    manifest=WS/'RR23/CompilerSupport/Metadata/GeneralManifest.bin';codegen=WS/'RR23/Assets/Editor/OriginalMetadataRestoration';report={'schema':'production-title-generic-reference-inverse-evidence/v1','status':'existing_manifest_inverse_and_restored_Core_evidence_only','manifest_alias':aliases(manifest),'existing_emitted_Core':core(WS/'RR23/Library/ScriptAssemblies/Assembly-CSharp.dll'),'production_sources':[pin(codegen/x) for x in ['GeneralPostProcessor.cs','WholeMetadataRestorer.cs','MetadataReferenceReversal.cs','CanonicalMetadataSignatures.cs','ExactInModifierReversal.cs','WholeManifest.cs']],'postprocessor_scope':'GeneralRR23MetadataPostProcessor.WillProcess only Assembly-CSharp; the diagnostic Recovery.ProjectedGenericConsumer bypassed it','raw_SDK_modified':False,'direct_consumer_failure_does_not_prove_production_ILPP_failure':True,'Main_modified':False,'managed_Unity_game_network_executed':False,'producer':pin(Path(__file__))};out=ROOT/'Validation'/('TitleGenericReferenceReversalAudit-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();target=out/'report.json';target.write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8');print(json.dumps({'report':pin(target),'alias':report['manifest_alias']['selected_alias'],'existing_Core_evidence':report['existing_emitted_Core']}))
if __name__=='__main__':main()
