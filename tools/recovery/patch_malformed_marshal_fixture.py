"""Introduce exactly one Param.HasFieldMarshal bit into a non-game fixture."""
import hashlib,json,sys
from pathlib import Path
from audit_cli_marshal_contracts import Cli,need
def sha(b):return hashlib.sha256(b).hexdigest()
def main():
 folder=Path(sys.argv[1]);plain=folder/'Plain.dll';correct=folder/'Correct.dll';target=folder/'Malformed.dll';need(not target.exists(),'Fresh synthetic malformed file required');before=plain.read_bytes();v=Cli(before);need(v.rows[8]==1 and v.rows[13]==0,'One synthetic Param and no marshaling rows required');at=v.row(8,1);flags=v.u16(at);need(flags==2,'Expected synthetic Out-only parameter');after=bytearray(before);after[at:at+2]=(flags|0x2000).to_bytes(2,'little');target.write_bytes(after)
 details={}
 for name,path in [('Plain',plain),('Malformed',target),('Correct',correct)]:
  data=path.read_bytes();reader=Cli(data);details[name]={'path':str(path),'sha256':sha(data),'audit':reader.audit()}
 need(details['Malformed']['audit']['malformed_parameter_count']==1 and details['Correct']['audit']['malformed_parameter_count']==0 and len(details['Correct']['audit']['FieldMarshal_rows'])==1,'Malformed versus actual-record fixture conditions')
 report={'schema':'synthetic-HasFieldMarshal-only-negative-fixture/v1','only_modified_span':{'offset':at,'before_hex':before[at:at+2].hex(),'after_hex':bytes(after[at:at+2]).hex()},'changed_byte_offsets':[i for i,(a,b) in enumerate(zip(before,after)) if a!=b],'fixtures':details,'native_library_name':'NeverInvokedNativeLibrary','native_import_invoked':False,'game_code_or_project_modified':False};(folder/'metadata-proof.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(folder/'metadata-proof.json'),'changed_bytes':report['changed_byte_offsets']}))
if __name__=='__main__':main()
