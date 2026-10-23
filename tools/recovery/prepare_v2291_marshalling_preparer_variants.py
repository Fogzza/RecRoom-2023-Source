"""NEW versioned preparers only; no harness preparation/deployment/Editor launch."""
from pathlib import Path
import ast,hashlib,json
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';TOOLS=ROOT/'Tools'
def need(b,s):
 if not b:raise ValueError(s)
def sha(p):return hashlib.sha256(Path(p).read_bytes()).hexdigest()
def replace_once(text,a,b):need(text.count(a)==1,'Exact original fragment missing/nonunique: '+a);return text.replace(a,b)
files=[]
for name in ('prepare_real_source_compile_harness','prepare_compile_deployment'):
 source=TOOLS/(name+'.py');target=TOOLS/(name+'_v2291_marshal.py');before=source.read_text();text=replace_once(before,'==2290','==2291');edits=[{'before':'==2290','after':'==2291'}]
 if name=='prepare_real_source_compile_harness':
  old=" for ref,relative in support.values():copy(Path(ref['path']),relative,ref['sha256'])"
  new=""" overlay=integration.get('marshalling_overlay');need(isinstance(overlay,dict) and overlay.get('shipping_supported') is False and overlay.get('counts')=={'fields':111,'parameters':64,'returns':318,'imports':819} and overlay.get('scope')=='Windows x64 Editor compile/signature-load validation only','Exact reviewed nonshipping Windows-x64 marshalling stage required')
 support['RR23.ProvenMarshallingOverlay']=(overlay['resource'],'CompilerSupport/Metadata/proven-marshalling-overlay.bin')
 need(len(support)==4,'Four exact metadata resources required')
 for ref,relative in support.values():copy(Path(ref['path']),relative,ref['sha256'])"""
  text=replace_once(text,old,new);edits.append({'before':old,'after':new})
  old="'original_RR23_modified':False,'execute_method':'VerifyRecoveredCompile.Run'"
  new="'original_RR23_modified':False,'marshalling_compatibility_scope':overlay['scope'],'shipping_supported':False,'metadata_resource_count':4,'execute_method':'VerifyRecoveredCompile.Run'"
  text=replace_once(text,old,new);edits.append({'before':old,'after':new})
 else:
  old=" source_rows=list(array_rows(source_path,'source_replacements'));"
  new=" deploy.need(config.get('metadata_resource_count')==4 and config.get('shipping_supported') is False and config.get('marshalling_compatibility_scope')=='Windows x64 Editor compile/signature-load validation only','Passed four-resource nonshipping Windows-x64 harness required')\n source_rows=list(array_rows(source_path,'source_replacements'));"
  text=replace_once(text,old,new);edits.append({'before':old,'after':new})
  old="'gameplay_functionality_verified':False,'original_RR23_modified':False}"
  new="'gameplay_functionality_verified':False,'original_RR23_modified':False,'shipping_supported':False,'marshalling_compatibility_scope':config['marshalling_compatibility_scope'],'metadata_resource_count':4}"
  text=replace_once(text,old,new);edits.append({'before':old,'after':new})
 ast.parse(before);ast.parse(text);inverse=text
 for e in reversed(edits):inverse=replace_once(inverse,e['after'],e['before'])
 need(inverse==before,'Unexpected extra preparer mutation');need(not target.exists(),'Versioned preparer exists; do not overwrite');target.write_text(text);need(sha(source)==hashlib.sha256(source.read_bytes()).hexdigest(),'Original preparer changed');files.append({'source':str(source),'source_sha256':sha(source),'candidate':str(target),'candidate_sha256':sha(target),'exact_allowed_text_edits':edits})
proof={'schema':'versioned2291-four-resource-marshalling-preparer-variants/v1','status':'source_prepared_AST_and_inverse_diff_validated_not_run','files':files,'original_helpers_unchanged':True,'project_modified':False,'harness_prepared':False,'deployment_prepared_or_applied':False,'Unity_launched':False,'scope':'Explicit nonshipping Windows-x64 compile/signature-load validation; original cross-platform code/settings unchanged.','controls':['Both old and new scripts parse as Python','Each allowed source fragment occurs exactly once','Inverse only the reviewed edits yields byte-normalized original source exactly','Exact2291 source rows required; old2290 rejected','Exact111/64/318/819 Marshal stage counts required','shipping_supported must remainFalse and scope exact','All four resources retain existing hash-pinned common.copy validation','Original225 plugin/facade/importer counts and5110 source count unchanged','All GUID/platform/settings/integration/load/zero-csc deployment gates retained']};out=TOOLS/'v2291-marshalling-preparer-provenance.json';need(not out.exists(),'Fresh provenance required');out.write_text(json.dumps(proof,indent=2)+'\n');print(json.dumps({'report':str(out),'sha256':sha(out),'files':len(files),'status':proof['status']}))
