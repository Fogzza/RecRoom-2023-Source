"""Read exact original MemberRef signature bytes; no assembly load/execution."""
import json,mmap,uuid
from datetime import datetime,timezone
import prepare_marshalling_integration as p
from audit_cli_marshal_contracts import Cli
source=p.ROOT/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll';rows=[]
with source.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as data:
 c=Cli(data);names={}
 for rid in range(1,c.rows[1]+1):
  at=c.row(1,rid);off=c.coded(2,[0,26,35,1]);name=c.string(c.value(at+off,c.strw));ns=c.string(c.value(at+off+c.strw,c.strw));names[rid]=(ns+'.' if ns else '')+name
 for rid in range(1,c.rows[10]+1):
  at=c.row(10,rid);width=c.coded(3,[2,1,26,6,27]);parent=c.value(at,width);name=c.string(c.value(at+width,c.strw))
  if parent&7==1 and names[parent>>3] in {'UnityEngine.SerializeField','UnityEngine.SerializeReference','System.Runtime.CompilerServices.IsReadOnlyAttribute','UnityEngine.Serialization.FormerlySerializedAsAttribute'} and name=='.ctor':
   blob=c.blob(c.value(at+width+c.strw,c.blobw));former=names[parent>>3]=='UnityEngine.Serialization.FormerlySerializedAsAttribute';p.need(blob==bytes.fromhex('2001010e' if former else '200001'),'Exact marker ctor primitive VOID/STRING signature');rows.append({'original_MemberRef_token':hex(0x0a000000|rid),'declaring_type':names[parent>>3],'signature_hex':blob.hex(),'has_this':True,'parameter_count':1 if former else 0,'parameter_ELEMENT_TYPE_STRING':14 if former else None,'return_ELEMENT_TYPE_VOID':1,'return_TypeRef_or_assembly_token_encoded':False})
p.need(any(r['declaring_type']=='UnityEngine.SerializeField' for r in rows),'Actual original serialization ctor witness required');out=p.ROOT/'Validation'/('CliMarkerVoidEncoding-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'direct-original-CLI-noarg-marker-VOID-byte-proof/v1','status':'passed','original_provider':p.pinned(source),'constructors':rows,'return_primitive_type_has_no_scoped_TypeRef_token':True,'game_code_loaded_or_executed':False};(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'sha256':p.sha(out/'report.json'),'rows':len(rows)}))
