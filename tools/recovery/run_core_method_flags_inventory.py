"""Bounded raw core MethodDef flags vs exact original token/fullshape witness."""
import datetime as dt,hashlib,importlib.util,json,mmap,shutil,sqlite3,sys,uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent
spec=importlib.util.spec_from_file_location('core_flag_guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
VARIANT=HERE.parent/'PluginNativeFlagsInventory/ArrayVariant-20261022T101556Z'
def need(b,s):
 if not b:raise ValueError(s)
def native_join(out):
 spec=importlib.util.spec_from_file_location('native_shapes',VARIANT/'inventory_native_plugin_method_flags_arrays.py');n=importlib.util.module_from_spec(spec);spec.loader.exec_module(n);inputs=[]
 for relative,expected in n.INPUTS.items():p=g.ROOT/'CodeSource'/relative;need(g.sha(p)==expected,'Verified original source SHA differs');inputs.append(p)
 native=out/'Native';native.mkdir()
 with inputs[0].open('rb') as bf,inputs[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:summary=n.inventory(n.NativeMetadata(b,md),{'Assembly-CSharp'},native)
 db=sqlite3.connect(out/'native-contract-index.sqlite');db.execute('pragma cache_size=-8192');db.execute('create table methods(token text primary key,owner text,name text,arity integer,has_this integer,returns text,parameters text,flags integer,impl integer,error text)')
 with (native/'Assembly-CSharp.jsonl').open(encoding='utf-8') as f:
  for line in f:
   row=json.loads(line);token='0x'+format(int(row['original_method_token'],16),'08x');db.execute('insert into methods values(?,?,?,?,?,?,?,?,?,?)',(token,row['owner'],row['name'],row['generic_arity'],int(row['has_this']),row['return_shape'],json.dumps(row['parameters_shape'],separators=(',',':')),row['flags'],row['impl_flags'],row['shape_error']))
 db.commit();seen=set();differences=[];errors=[];oldDifferences=[];oldSignatureDifferences=[];count=0;exact=0;strictWitnesses=0
 with (out/'raw-core-methods.jsonl').open(encoding='utf-8') as f:
  for line in f:
   row=json.loads(line);count+=1;token=row['original_native_token']
   if token is None and row['error']=='Exact unique initial-provider owner+canonical signature+TokenAttribute witness absent':
    # Old2022 can mis-own generic parameter references. Never change or guess
    # its signature: select the original token independently by the COMPLETE
    # raw/native scoped shape, then require that same originalTokenAttribute
    # in exactly one old same-owner/name/arity/HasThis candidate.
    candidates=db.execute('select token from methods where owner=? and name=? and arity=? and has_this=? and returns=? and parameters=? and error is null',(row['owner'],row['name'],row['generic_arity'],int(row['has_this']),row['return_shape'],json.dumps(row['parameters_shape'],separators=(',',':')))).fetchall()
    if len(candidates)!=1:errors.append({'raw':row,'reason':'raw/native fullshape token join not unique','native_match_count':len(candidates)});continue
    selected=candidates[0][0];old=[x for x in row['initial_same_name_candidates'] or [] if x['original_token']==selected]
    if len(old)!=1:errors.append({'raw':row,'reason':'unique native fullshape token lacks exact old TokenAttribute owner/name/arity witness'});continue
    token=selected;oldSignatureDifferences.append({'owner':row['owner'],'name':row['name'],'original_native_token':token,'raw_canonical_signature':row['canonical_signature'],'old_initial_canonical_signature':old[0]['canonical_signature'],'original_token_independently_selected_by_unique_raw_native_fullshape':True,'same_original_token_attribute_exactly_present_on_old_owner_name_arity_candidate':True,'old_initial_signature_not_used_as_behavior_or_restoration_authority':True});row['initial_provider_flags']=old[0]['flags'];row['initial_provider_impl_flags']=old[0]['impl_flags']
   elif row['error'] or token is None:errors.append({'raw':row,'reason':'raw shape or original-token witness unresolved'});continue
   else:strictWitnesses+=1
   need(token not in seen,'Duplicate original native MethodDef token witness');seen.add(token);nativeRow=db.execute('select owner,name,arity,has_this,returns,parameters,flags,impl,error from methods where token=?',(token,)).fetchone()
   if nativeRow is None:errors.append({'raw':row,'reason':'original token absent from exact native core image'});continue
   owner,name,arity,has_this,returns,parameters,flags,impl,error=nativeRow
   if error or (row['owner'],row['name'],row['generic_arity'],row['has_this'],row['return_shape'],json.dumps(row['parameters_shape'],separators=(',',':')))!=(owner,name,arity,bool(has_this),returns,parameters):errors.append({'raw':row,'reason':'native owner/name/arity/fullshape differs or unsupported','native':{'owner':owner,'name':name,'arity':arity,'has_this':bool(has_this),'returns':returns,'parameters':json.loads(parameters),'error':error}});continue
   exact+=1
   if (row['flags'],row['impl_flags'])!=(flags,impl):differences.append({'owner':owner,'name':name,'original_native_token':token,'canonical_signature':row['canonical_signature'],'raw_flags':row['flags'],'raw_impl_flags':row['impl_flags'],'native_flags':flags,'native_impl_flags':impl,'initial_flags':row['initial_provider_flags'],'initial_impl_flags':row['initial_provider_impl_flags']})
   if (row['initial_provider_flags'],row['initial_provider_impl_flags'])!=(flags,impl):oldDifferences.append({'owner':owner,'name':name,'token':token,'initial_flags':row['initial_provider_flags'],'initial_impl_flags':row['initial_provider_impl_flags'],'native_flags':flags,'native_impl_flags':impl})
 missing=[]
 for token,owner,name in db.execute('select token,owner,name from methods'):
  if token not in seen:missing.append({'original_native_token':token,'owner':owner,'name':name})
 db.close();result={'schema':'original-core-method-flags-native-token-shape-audit/v1','inputs':[{'path':str(p),'sha256':g.sha(p)} for p in inputs],'raw_provider_methods':count,'original_native_methods':summary['original_method_count'],'exact_native_token_owner_name_fullshape_matches':exact,'strict_old_initial_canonical_token_witnesses':strictWitnesses,'old_initial_signature_discrepancy_count':len(oldSignatureDifferences),'old_initial_signature_discrepancies':oldSignatureDifferences,'raw_provider_flag_differences':differences,'initial_provider_flag_differences':oldDifferences,'unresolved_contracts':errors,'native_methods_absent_from_raw_provider':missing,'all_original_native_method_contracts_covered':not errors and not missing and exact==summary['original_method_count'],'all_raw_method_flags_exact_native':not errors and not missing and not differences,'helper_exclusions':json.loads((out/'raw-summary.json').read_text())['helper_exclusions'],'cli_row_tokens_never_used_as_original':True,'project_modified':False,'game_code_executed':False};(out/'native-join-report.json').write_text(json.dumps(result,indent=2)+'\n');print(json.dumps({k:v for k,v in result.items() if k not in ('inputs','raw_provider_flag_differences','initial_provider_flag_differences','unresolved_contracts','native_methods_absent_from_raw_provider','helper_exclusions','old_initial_signature_discrepancies')}|{'flag_differences':len(differences),'initial_differences':len(oldDifferences),'unresolved':len(errors),'missing':len(missing)}));return 0
def main():
 if len(sys.argv)==3 and sys.argv[1]=='--native-join':return native_join(Path(sys.argv[2]))
 out=g.ROOT/'Validation'/('CoreMethodFlagsInventory-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'phases':[],'project_modified':False,'game_code_executed':False}
 try:
  source=HERE/'CoreMethodFlagsInventory.cs';canonical=g.ROOT/'CompilerRepairs/MetadataRestorationPilot/CanonicalMetadataSignatures.cs';deps=[HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll'];raw=g.ROOT/'ScriptRecoveryModernLayout/Attempt-20261022T021923Z-2fcf0245/Output/Assembly-CSharp.dll';initial=g.ROOT/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll';records=[source,canonical,raw,initial,Path(__file__).resolve(),VARIANT/'inventory_native_plugin_method_flags_arrays.py'];report['inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in records];host=out/'CoreMethodFlagsInventory.dll';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/nullable:enable','/langversion:latest','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+deps]+['"'+str(source)+'"','"'+str(canonical)+'"'])+'\n');g.phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-metadata-reader',report,maximum=120,cap=.125)
  for p in deps:shutil.copyfile(p,out/p.name)
  host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));g.phase([g.DOTNET,host,raw,initial,out/'raw-core-methods.jsonl',out/'raw-summary.json'],out,'read-raw-initial-original-token-witness',report,maximum=120,cap=.275);g.phase([sys.executable,Path(__file__).resolve(),'--native-join',out],out,'stream-native-token-fullshape-flags-join',report,maximum=120,cap=.275);need(all(g.sha(Path(r['path']))==r['sha256'] for r in report['inputs']),'Pinned source/provider drift');joined=json.loads((out/'native-join-report.json').read_text());report['summary']={k:v for k,v in joined.items() if k not in ('inputs','raw_provider_flag_differences','initial_provider_flag_differences','unresolved_contracts','native_methods_absent_from_raw_provider','helper_exclusions','old_initial_signature_discrepancies')};report['flag_difference_count']=len(joined['raw_provider_flag_differences']);report['unresolved_count']=len(joined['unresolved_contracts']);report['missing_count']=len(joined['native_methods_absent_from_raw_provider']);report['native_join_report']={'path':str(out/'native-join-report.json'),'sha256':g.sha(out/'native-join-report.json')};report['status']='completed';return 0
 except Exception as error:report['status']='failed';report['error']=str(error);return 1
 finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'output':str(out),'status':report['status'],'summary':report.get('summary'),'flag_differences':report.get('flag_difference_count'),'unresolved':report.get('unresolved_count'),'missing':report.get('missing_count'),'error':report.get('error')}))
if __name__=='__main__':raise SystemExit(main())
