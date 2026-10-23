"""Finite matching-Editor host framework additions only; no probe launch."""
from pathlib import Path
import hashlib,importlib.util,json,mmap
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';PROFILE=WS/'Tools/Editors/2020.3.33f1/Editor/Data/MonoBleedingEdge/lib/mono/unityjit';OUT=ROOT/'Validation/Mono64CoreSignature-20261022T151506Z-476ee90a';NAMES=['I18N.dll','I18N.West.dll','I18N.CJK.dll','I18N.MidEast.dll','I18N.Other.dll','I18N.Rare.dll']
sp=importlib.util.spec_from_file_location('cli',HERE/'audit_cli_marshal_contracts.py');cli=importlib.util.module_from_spec(sp);sp.loader.exec_module(cli)
def need(b,s):
 if not b:raise ValueError(s)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def module_methods(c):
 found=[]
 for rid in range(1,c.rows[2]+1):
  at=c.row(2,rid);name=c.string(c.value(at+4,c.strw))
  if name!='<Module>':continue
  offset=4+2*c.strw+c.coded(2,[2,1,27])+c.index(4);start=c.value(at+offset,c.index(6));end=c.value(c.row(2,rid+1)+offset,c.index(6)) if rid<c.rows[2] else c.rows[6]+1
  found.extend(c.string(c.value(c.row(6,m)+8,c.strw)) for m in range(start,end))
 return found
def main():
 rows=[];missing=[]
 for name in NAMES:
  path=PROFILE/name
  if not path.is_file():missing.append(name);continue
  digest=sha(path)
  with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
   c=cli.Cli(b);need(c.rows[32]==1,'Single assembly required');at=c.row(32,1);major,minor,build,revision=[c.u16(at+4+i*2) for i in range(4)];flags=c.u32(at+12);publickey=c.blob(c.value(at+16,c.blobw));aname=c.string(c.value(at+16+c.blobw,c.strw));culture=c.string(c.value(at+16+c.blobw+c.strw,c.strw));need(aname+'.dll'==name and flags&1 and publickey and not flags&0x100,'Exact signed non-retargetable matching I18N assembly expected');token=hashlib.sha1(publickey).digest()[-8:][::-1].hex();full=aname+', Version='+'.'.join(map(str,[major,minor,build,revision]))+', Culture='+(culture or 'neutral')+', PublicKeyToken='+token;audit=c.audit();methods=module_methods(c);need(not methods,'Module initializer/methods not allowed');need(audit['malformed_parameter_count']==audit['malformed_field_count']==0,'I18N malformed marshal records');need(all(r['has_FieldMarshal_flag'] and r['FieldMarshal_table_rid'] is not None for r in audit['flagged_fields']+audit['flagged_parameters']),'I18N unflagged marshal owner');rows.append({'image':name,'path':str(path),'sha256':digest,'assembly_full_name':full,'role':'additional_matching_Mono_HOST_encoding_framework_not_original_client_script','marshal_rows':len(audit['FieldMarshal_rows']),'malformed_marshal_rows':0,'module_methods':methods})
  need(sha(path)==digest,'Framework dependency changed')
 out=OUT/'finite-I18N-host-dependencies.json';need(not out.exists(),'Fresh finite I18N audit');report={'schema':'finite-exact-matching-Mono-host-I18N-framework-dependencies/v1','status':'static_identity_hash_marshal_module_initializer_gates_passed','exact_requested_names':NAMES,'references':rows,'missing_optional_names':missing,'native_original279_inventory_unchanged':True,'original_client_replacement_code':False,'default_directory_search_added':False,'host_invoked':False,'project_or_harness_modified':False,'authority':'Parent explicitly authorized finite sameEditor I18N encoding support after fail-closed unknown I18N4.0 request; no new game/vendor code.'};out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'sha256':sha(out),'references':len(rows),'missing_optional':missing}))
if __name__=='__main__':main()
