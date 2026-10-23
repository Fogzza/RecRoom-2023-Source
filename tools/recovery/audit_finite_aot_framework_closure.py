"""Read only exact finite sameEditor AOT closure, starting with refused System.Core."""
from pathlib import Path
import datetime as dt,hashlib,importlib.util,json,uuid
HERE=Path(__file__).resolve().parent
sp=importlib.util.spec_from_file_location('finite_aot',HERE/'audit_finite_aot_system_core.py');m=importlib.util.module_from_spec(sp);sp.loader.exec_module(m)
def main():
 prior=json.loads((m.OLD/'plan.json').read_text());known={r['assembly_full_name']:r for r in prior['references']};pending=['System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e'];added={};edges=[]
 while pending:
  full=pending.pop(0)
  if full in added or full in known:continue
  m.need(len(added)<8,'Finite transitive closure limit8');name=full.split(',')[0];m.need(name in {'System.Core','System','System.Xml','System.Security','System.Data','System.Configuration','System.Numerics'},'Unreviewed profile file '+name);row=m.inspect(m.PROFILE/(name+'.dll'));m.need(row['assembly_full_name']==full,'Exact dependency identity mismatch');m.need(not row['module_methods'] and not row['malformed_field_count'] and not row['malformed_parameter_count'],'Module initializer or malformed owner');added[full]=row
  for ref in row['assembly_refs']:
   edges.append({'requester':full,'requested':ref['full_name'],'already_fixed_whitelist':ref['full_name'] in known})
   if ref['full_name'] not in known and ref['full_name'] not in added:pending.append(ref['full_name'])
 out=m.ROOT/'Validation'/('FiniteAOTFrameworkClosure-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();refs=[{'image':Path(r['path']).name,'path':r['path'],'sha256':r['sha256'],'assembly_full_name':r['assembly_full_name'],'role':'additional_exact_sameEditor_AOT_HOST_framework_required_by_native_signature_scope','marshal_rows':r['marshal_row_count'],'malformed_marshal_rows':0} for r in added.values()];report={'schema':'finite-exact-AOT-framework-transitive-host-closure/v1','status':'static_all_exact_identity_marshal_module_initializer_checks_passed','references':refs,'metadata_proof':list(added.values()),'dependency_edges':edges,'all_dependency_fullnames_already_fixed_or_added':all(e['requested'] in known or e['requested'] in added for e in edges),'known_vendor790_gaps_preserved':True,'native_original279_inventory_unchanged':True,'scope':'Host-only framework additions; no original client assembly replacements or aliases; same simple names with different full identity are distinct reviewed files','host_invoked':False,'project_or_harness_modified':False};r=out/'report.json';r.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(r),'sha256':m.sha(r),'added':[{k:x[k] for k in ['assembly_full_name','sha256']} for x in refs],'all_edges_closed':report['all_dependency_fullnames_already_fixed_or_added']}))
if __name__=='__main__':main()
