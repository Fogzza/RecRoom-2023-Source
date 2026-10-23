"""New fixed288-reference review: finite AOT closure plus passed tested SDK2 plan."""
from pathlib import Path
import datetime as dt,hashlib,importlib.util,json,subprocess,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
OLD=ROOT/'Validation/Mono64CoreSignatureI18N-20261022T152916Z-f45af857'
CLOSURE=ROOT/'Validation/FiniteAOTFrameworkClosure-20261022T154113Z-e47f6b5a/report.json'
SDK=ROOT/'NativeGameplayRepairs/RuntimePluginTestedSDKProposal-20261022T151723Z-bd6c18fa/report.json'
ROUND=ROOT/'Validation/CurrentCoreMarshalRoundtrip-20261022T153628Z-c5c43a1f'
def need(x,s):
 if not x:raise ValueError(s)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def main():
 need(sha(CLOSURE)=='542f53b98b1bb38c3cfa3b498ad3ce7b800203452538958998de634b3189b918','Reviewed finite closure drift');closed=json.loads(CLOSURE.read_text());need(len(closed['references'])==3 and closed['all_dependency_fullnames_already_fixed_or_added'],'Exact three-file closed AOT table');p=json.loads((OLD/'plan.json').read_text());need(len(p['references'])==285,'PreviousI18N count');sdk=json.loads(SDK.read_text());need(len(sdk['assemblies'])==225,'ExactSDK225');by={r['assembly']+'.dll':r for r in sdk['assemblies']};rows=[];changes=[]
 sp=importlib.util.spec_from_file_location('aot',HERE/'audit_finite_aot_system_core.py');m=importlib.util.module_from_spec(sp);sp.loader.exec_module(m)
 core=ROUND/'ActualCurrentCoreOutput/Assembly-CSharp.dll';need(sha(core)==p['core_sha256'],'SDK2 output core byteidentity drift')
 for row in p['references']:
  row=dict(row);old=dict(row)
  if row['image'] in by:
   candidate=by[row['image']];need(sha(candidate['candidate'])==candidate['candidate_sha256'],'ExactSDKcandidate drift');row['path']=candidate['candidate'];row['sha256']=candidate['candidate_sha256']
  elif row['image']=='Assembly-CSharp.dll':row['path']=str(core)
  if row['path']!=old['path']:
   inspected=m.inspect(Path(row['path']));need(inspected['assembly_full_name']==old['assembly_full_name'] and not inspected['module_methods'],'SDK identity/module initializer changed');need(inspected['malformed_field_count']+inspected['malformed_parameter_count']==old['malformed_marshal_rows'],'SDK Marshal gap inventory changed');changes.append({'assembly':row['assembly_full_name'],'before':old,'after':row,'static_metadata':inspected})
  need(sha(row['path'])==row['sha256'],'Pinned existing reference drift');rows.append(row)
 rows+=closed['references'];need(len(rows)==288 and len({r['assembly_full_name'] for r in rows})==288,'288 distinct full identities');out=ROOT/'Validation'/('Mono64CoreSignatureAOT-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();p.update(status='finite_AOT_and_passed_SDK2_sources_pending_root_review',references=rows,reference_count=288,original_client_reference_count=279,extra_Mono_host_framework_count=9,core=str(core),finite_AOT_dependency_proof={'path':str(CLOSURE),'sha256':sha(CLOSURE)},prior_failed_whitelist_diagnostic={'path':str(OLD/'diagnostic-run-report-r1.json'),'sha256':sha(OLD/'diagnostic-run-report-r1.json')},tested_SDK2_runtime_plan={'path':str(SDK),'sha256':sha(SDK)},passed_SDK2_exact_reference_file={'path':str(ROUND/'exact-original-metadata-references.txt'),'sha256':sha(ROUND/'exact-original-metadata-references.txt')},changed_reference_rows=changes);(out/'plan.json').write_text(json.dumps(p,indent=2)+'\n')
 source=(HERE/'stage_mono64_signature_probe_sources.py').read_text();needle="p['reference_count'] in (279,285)";need(source.count(needle)==1,'Exact source-generator guard');source=source.replace(needle,"p['reference_count'] == 288").replace('Exact279client plusoptional6finite host references','Exact279client plus9finite host references');generator=out/'stage_fixed_288_sources.py';generator.write_text(source.replace("HERE=Path(__file__).resolve().parent;WS=HERE.parents[2]","HERE=Path("+repr(str(HERE))+");WS=HERE.parents[2]"));result=subprocess.run([sys.executable,str(generator),str(out/'plan.json')],capture_output=True,text=True);need(result.returncode==0,result.stdout+result.stderr);reviewpath=out/'source-review.json';review=json.loads(reviewpath.read_text());config=WS/'Tools/Editors/2020.3.33f1/Editor/Data/MonoBleedingEdge/etc/mono/config';review['source_inputs'].extend([{'path':str(config),'sha256':sha(config)},{'path':str(CLOSURE),'sha256':sha(CLOSURE)},{'path':str(SDK),'sha256':sha(SDK)}]);review.update(original_client_reference_count=279,additional_host_framework_count=9,known_vendor_dangling_owner_count=790,finite_AOT_dependency_proof=p['finite_AOT_dependency_proof'],prior_failed_whitelist_diagnostic=p['prior_failed_whitelist_diagnostic'],tested_SDK2_runtime_plan=p['tested_SDK2_runtime_plan'],changed_reference_rows=changes,scope_amendment='Three exact sameEditor AOT identities added alongside distinct JIT identities, no alias/type stripping/fallback; original279inventory unchanged. Two genuine SDK plugin files and byteidentical newcore use passed final SDK2 plan.');reviewpath.write_text(json.dumps(review,indent=2)+'\n');print(json.dumps({'review':str(reviewpath),'sha256':sha(reviewpath),'sources':review['sources'],'references':288,'host_invoked':False}))
if __name__=='__main__':main()
