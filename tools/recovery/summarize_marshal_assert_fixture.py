"""Assert recorded nongame fixture outcomes without repeating the crash."""
from pathlib import Path
import hashlib,json,sys
def sha(p):
 with p.open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def main():
 folder=Path(sys.argv[1]);metadata=json.loads((folder/'metadata-proof.json').read_bytes());reports=[]
 for name in ('Plain','Correct','MarshalWalker'):
  p=folder/('compile-'+name)/'report.json';r=json.loads(p.read_bytes());assert r['exit_code']==0 and r['peak_private_bytes']<=256*1024**2 and r['seconds']<=15;reports.append({'path':str(p),'sha256':sha(p)})
 outcomes={}
 for name in ('Plain','Correct','Malformed'):
  p=folder/('mono-'+name)/'report.json';r=json.loads(p.read_bytes());log=p.with_name('output.log');text=log.read_text(errors='replace');assert r['status']=='exited' and r['peak_private_bytes']<=64*1024**2 and r['seconds']<=10
  if name=='Malformed':assert r['exit_code']!=0 and 'loader.c:2182' in text and "condition `tp' not met" in text and 'BEFORE_PARAMETERS' in text and 'AFTER_PARAMETERS' not in text
  else:assert r['exit_code']==0 and 'FIXTURE_METADATA_ONLY_OK' in text
  outcomes[name]={'report':{'path':str(p),'sha256':sha(p)},'log':{'path':str(log),'sha256':sha(log)},'exit_code':r['exit_code'],'peak_private_bytes':r['peak_private_bytes'],'seconds':r['seconds']}
 assert len(metadata['changed_byte_offsets'])==1;plain=Path(metadata['fixtures']['Plain']['path']).read_bytes();bad=Path(metadata['fixtures']['Malformed']['path']).read_bytes();assert len(plain)==len(bad) and [i for i,(a,b) in enumerate(zip(plain,bad)) if a!=b]==metadata['changed_byte_offsets']
 report={'schema':'matched-Unity2020-Mono-missing-marshal-assertion-proof/v1','assertion_cause_reproduced':True,'same_assertion_as_actual_Unity':'mono/metadata/loader.c:2182 condition tp','only_negative_fixture_mutation':'Set Param.HasFieldMarshal bit; no FieldMarshal row added','negative_has_valid_noninvoked_PInvoke_import_map':True,'positive_actual_marshal_blob':metadata['fixtures']['Correct']['audit']['FieldMarshal_rows'],'metadata_proof':{'path':str(folder/'metadata-proof.json'),'sha256':sha(folder/'metadata-proof.json')},'compile_reports':reports,'outcomes':outcomes,'game_code_or_native_import_invoked':False,'actual_RR23_or_harness_modified':False,'unsupported_fix_forbidden':'Do not clear original flags or invent marshal blobs to conceal missing ABI metadata.'};target=folder/'assertion-proof.json';target.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(target),'sha256':sha(target),'assertion_cause_reproduced':True}))
if __name__=='__main__':main()
