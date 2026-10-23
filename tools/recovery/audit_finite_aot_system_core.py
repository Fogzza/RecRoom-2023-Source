"""Static finite-profile identity proof; does not load CLR/Mono or mutate projects."""
from pathlib import Path
import datetime as dt,hashlib,importlib.util,json,mmap,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROFILE=WS/'Tools/Editors/2020.3.33f1/Editor/Data/MonoBleedingEdge/lib/mono/unityaot'
OLD=ROOT/'Validation/Mono64CoreSignatureI18N-20261022T152916Z-f45af857'
spec=importlib.util.spec_from_file_location('cli',HERE/'audit_cli_marshal_contracts.py');cli=importlib.util.module_from_spec(spec);spec.loader.exec_module(cli)
spec2=importlib.util.spec_from_file_location('finite',HERE/'stage_finite_mono_i18n_dependencies.py');finite=importlib.util.module_from_spec(spec2);spec2.loader.exec_module(finite)
def need(x,s):
 if not x:raise ValueError(s)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def identity(c,table,rid):
 at=c.row(table,rid)
 if table==32:
  version=[c.u16(at+4+i*2) for i in range(4)];flags=c.u32(at+12);offset=16
 else:version=[c.u16(at+i*2) for i in range(4)];flags=c.u32(at+8);offset=12
 key=c.blob(c.value(at+offset,c.blobw));name=c.string(c.value(at+offset+c.blobw,c.strw));culture=c.string(c.value(at+offset+c.blobw+c.strw,c.strw));token=(hashlib.sha1(key).digest()[-8:][::-1] if flags&1 else key).hex() if key else 'null'
 return {'name':name,'version':'.'.join(map(str,version)),'flags':flags,'full_name':name+', Version='+'.'.join(map(str,version))+', Culture='+(culture or 'neutral')+', PublicKeyToken='+token}
def inspect(path):
 digest=sha(path)
 with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
  c=cli.Cli(b);need(c.rows[32]==1,'One Assembly required');ident=identity(c,32,1);refs=[identity(c,35,i) for i in range(1,c.rows[35]+1)];audit=c.audit();module=finite.module_methods(c)
  row={'path':str(path),'sha256':digest,'identity':ident,'assembly_full_name':ident['full_name'],'assembly_refs':refs,'module_methods':module,'malformed_field_count':audit['malformed_field_count'],'malformed_parameter_count':audit['malformed_parameter_count'],'marshal_row_count':len(audit['FieldMarshal_rows']),'type_count':c.rows[2],'method_count':c.rows[6]}
 need(sha(path)==digest,'Input changed');return row
def main():
 prior=json.loads((OLD/'plan.json').read_text());known={x['assembly_full_name']:x for x in prior['references']};p=PROFILE/'System.Core.dll';row=inspect(p);need(row['assembly_full_name']=='System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e','Exact refused assembly identity');need(not row['module_methods'] and not row['malformed_field_count'] and not row['malformed_parameter_count'],'AOT candidate metadata gate')
 deps=[]
 for ref in row['assembly_refs']:
  entry={'requested':ref,'in_previous_exact_whitelist':ref['full_name'] in known}
  if ref['full_name'] in known:entry['existing']=known[ref['full_name']]
  else:
   candidate=PROFILE/(ref['name']+'.dll');entry['same_profile_candidate_exists']=candidate.is_file()
   if candidate.is_file():entry['same_profile_candidate']=inspect(candidate)
  deps.append(entry)
 out=ROOT/'Validation'/('FiniteAOTSystemCore-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'finite-same-editor-AOT-System-Core-static-metadata-proof/v1','status':'static_candidate_not_whitelisted_not_invoked','refused_full_name':row['assembly_full_name'],'candidate':row,'direct_dependency_proof':deps,'source_prior_plan':{'path':str(OLD/'plan.json'),'sha256':sha(OLD/'plan.json')},'known_vendor_malformed_marshal_owners_preserved':790,'original_native_inventory_unchanged':True,'no_aliases_or_fallback_added':True,'host_invoked':False,'project_or_harness_modified':False};r=out/'report.json';r.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(r),'sha256':sha(r),'candidate':row['assembly_full_name'],'dependencies':[(x['requested']['full_name'],x['in_previous_exact_whitelist']) for x in deps]}))
if __name__=='__main__':main()
