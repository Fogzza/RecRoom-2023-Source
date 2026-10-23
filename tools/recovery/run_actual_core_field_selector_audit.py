"""Audit every compiled field selector against original/native identity and stage plans."""
import argparse, datetime as dt, importlib.util, json, shutil, sqlite3, uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent
spec=importlib.util.spec_from_file_location('actual_field_guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
NATIVE_PROOF=g.ROOT/'Validation/CoreFieldAttributeWitness-20261022T114004Z-f1c134b5'
def need(ok,message):
 if not ok:raise ValueError(message)
def key(*parts):return json.dumps(parts,separators=(',',':'))
def index_and_compare(out,stage):
 db=sqlite3.connect(out/'field-selectors.sqlite');db.execute('pragma cache_size=-8192');db.executescript('create table raw(k text primary key,row text);create table actual(owner text,name text,canonical text,token text primary key,row text);create index actual_identity on actual(owner,name,canonical);create table native(k text primary key,row text)')
 for line in (out/'raw-field-selectors.jsonl').open(encoding='utf-8'):
  row=json.loads(line);db.execute('insert into raw values(?,?)',(key(row['owner'],row['name'],row['canonical_type']),line))
 for line in (out/'actual-field-selectors.jsonl').open(encoding='utf-8'):
  row=json.loads(line);db.execute('insert into actual values(?,?,?,?,?)',(row['owner'],row['name'],row['canonical_type'],row['cli_token'],line))
 for line in (NATIVE_PROOF/'raw-core-fields.jsonl').open(encoding='utf-8'):
  row=json.loads(line);db.execute('insert into native values(?,?)',(key(row['owner'],row['name'],row['raw_canonical_type']),line))
 db.commit();cache=sqlite3.connect('file:'+str(stage)+'?mode=ro',uri=True);cache.execute('pragma cache_size=-8192');mismatches=[];problems=[];seen=set();exact=0;nativeProjected=0;total=0;typeCount=0
 for value, in cache.execute('select value from rows where kind=? order by ordinal',('definition',)):
  definition=json.loads(value);typeCount+=1
  for field in definition['fields']:
   total+=1;original=field['original'];compiled=field['compiled'];rawrows=db.execute('select row from raw where k=?',(key(definition['original'],original['name'],original['canonical_field_type']),)).fetchall();nativerows=db.execute('select row from native where k=?',(key(definition['original'],original['name'],original['canonical_field_type']),)).fetchall()
   if len(rawrows)!=1 or len(nativerows)!=1:problems.append({'owner':definition['original'],'field':field,'reason':'Unique raw/native original owner/name/canonical field absent','raw_count':len(rawrows),'native_count':len(nativerows)});continue
   raw=json.loads(rawrows[0][0]);native=json.loads(nativerows[0][0]);actualrows=db.execute('select row from actual where owner=? and name=? and canonical=?',(definition['compiled'],compiled['name'],compiled['canonical_field_type'])).fetchall();projectedrows=db.execute('select row from actual where owner=? and name=? and canonical=?',(definition['compiled'],compiled['name'],raw['projected_canonical_type'])).fetchall()
   if len(actualrows)==1:
    actual=json.loads(actualrows[0][0]);need(actual['cli_token'] not in seen,'Two original field plans target same actual CLI field');seen.add(actual['cli_token']);exact+=1
   if len(projectedrows)==1:nativeProjected+=1
   if len(actualrows)!=1 or compiled['canonical_field_type']!=raw['projected_canonical_type'] or raw['error']:
    candidates=[json.loads(r[0]) for r in db.execute('select row from actual where owner=? and name=?',(definition['compiled'],compiled['name']))]
    mismatches.append({'original_owner':definition['original'],'compiled_owner':definition['compiled'],'field_plan':field,'raw_provider':raw,'native_original_field_token':native['original_field_token'],'native_original_owner_token':native['original_owner_token'],'native_proven_raw_typespec':native['raw_canonical_type'],'actual_exact_plan_match_count':len(actualrows),'actual_exact_projected_native_match_count':len(projectedrows),'actual_same_name_candidates_for_diagnostics_only':candidates,'selector_fallback_used':False})
 unmatched=[]
 for token,row in db.execute('select token,row from actual'):
  if token not in seen:unmatched.append(json.loads(row))
 cache.close();db.close();result={'schema':'actual-emitted-core-field-selector-native-identity-audit/v1','stage_definition_types':typeCount,'stage_field_plans':total,'exact_current_plan_compiled_selectors':exact,'exact_projected_native_raw_typespec_matches':nativeProjected,'mismatch_count':len(mismatches),'mismatches':mismatches,'unresolved_original_native_bindings':problems,'unmatched_actual_fields':unmatched,'no_name_only_binding_or_source_changes':True,'all_planned_selectors_exact':not mismatches and not problems and total==exact,'project_modified':False,'game_code_executed':False};(out/'field-selector-audit.json').write_text(json.dumps(result,indent=2)+'\n');return {k:result[k] for k in ('stage_definition_types','stage_field_plans','exact_current_plan_compiled_selectors','exact_projected_native_raw_typespec_matches','mismatch_count','all_planned_selectors_exact')}|{'unresolved_original_native_bindings':len(problems),'unmatched_actual_fields':len(unmatched)}
def main():
 parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--stage-cache',required=True,type=Path);args=parser.parse_args();stage=args.stage_cache.resolve();need(stage.is_relative_to(g.ROOT/'CompilerRepairs') and stage.is_file(),'Existing isolated stage cache required');out=g.ROOT/'Validation'/('ActualCoreFieldSelectorAudit-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'phases':[],'project_modified':False,'game_code_executed':False}
 try:
  raw=g.ROOT/'ScriptRecoveryModernLayout/Attempt-20261022T021923Z-2fcf0245/Output/Assembly-CSharp.dll';actual=g.ROOT/'Validation/CompileCheck-20261022T104058Z-8b5ef50d/Assembly-CSharp.dll';pilot=g.ROOT/'CompilerRepairs/MetadataRestorationPilot';sources=[HERE/'ActualCoreFieldSelectorInventory.cs',pilot/'CanonicalMetadataSignatures.cs',pilot/'ProjectedCanonicalSignatures.cs'];deps=[HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll'];records=sources+deps+[Path(__file__).resolve(),raw,actual,stage,NATIVE_PROOF/'raw-core-fields.jsonl',NATIVE_PROOF/'field-witness-report.json',NATIVE_PROOF/'provenance.json'];report['inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in records];db=sqlite3.connect('file:'+str(stage)+'?mode=ro',uri=True)
  with (out/'type-aliases.jsonl').open('w',encoding='utf-8') as f:
   for value, in db.execute('select value from rows where kind=? order by ordinal',('typealias',)):f.write(value+'\n')
  db.close();host=out/'ActualCoreFieldSelectorInventory.dll';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/nullable:enable','/langversion:latest','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+deps]+['"'+str(p)+'"' for p in sources])+'\n');g.phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-actual-field-reader',report,maximum=120,cap=.125)
  for p in deps:shutil.copyfile(p,out/p.name)
  host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));g.phase([g.DOTNET,host,raw,actual,out/'type-aliases.jsonl',out/'raw-field-selectors.jsonl',out/'actual-field-selectors.jsonl'],out,'read-native-raw-and-actual-core-fields',report,maximum=120,cap=.275);report['summary']=index_and_compare(out,stage);need(all(g.sha(Path(row['path']))==row['sha256'] for row in report['inputs']),'Pinned inputs drifted');report['status']='completed';return 0
 except Exception as error:report['status']='failed';report['error']=str(error);return 1
 finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'output':str(out),'status':report['status'],'summary':report.get('summary'),'error':report.get('error')}))
if __name__=='__main__':raise SystemExit(main())
