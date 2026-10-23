"""Versioned derivative for a never-launched cached harness; source staging only."""
from pathlib import Path
import hashlib,json
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];TOOLS=WS/'Recovery/RecRoom-2023-04-18/Tools'
def main():
 source=TOOLS/'revise_cached_compile_harness_fast.py';text=source.read_text();changes=[]
 def change(old,new):
  nonlocal text
  if text.count(old)!=1:raise ValueError('Exact source change count: '+old[:90])
  text=text.replace(old,new);changes.append({'old':old,'new':new})
 change('one failed cached harness','one NEVER-LAUNCHED cached harness')
 change("ARCHIVE_NAMES=('report.json','run-report.json','Editor.log','cli-stdout.json','cli-stderr.log')","ARCHIVE_NAMES=('report.json',)\nUNRUN_EVIDENCE_NAMES=('run-report.json','Editor.log','cli-stdout.json','cli-stderr.log')")
 change(" need(old['tool_dependencies']==new['tool_dependencies'],'CodeGen binary/tool dependency changed')"," need(old['tool_dependencies']==new['tool_dependencies'],'CodeGen binary/tool dependency changed')\n need(old['marshalling_overlay']['resource']['sha256']==new['marshalling_overlay']['resource']['sha256'],'Fourth immutable marshalling resource changed')")
 change("def unchanged_dependency(rel,digest,old_rows):","def assert_unrun(preparation,project):\n markers_absent(project)\n for name in UNRUN_EVIDENCE_NAMES:need(not (preparation.parent/name).exists(),'Prior launch/refusal evidence exists: '+name)\n for rel in ('Library','Temp','Logs'):need(not (project/rel).exists(),'Harness has Editor/cache evidence: '+rel)\n\ndef unchanged_dependency(rel,digest,old_rows):")
 change('def prepare(preparation,stage,build,failed_sha):','def prepare(preparation,stage,build):')
 change(" markers_absent(project);editor=safety.assert_editor_closed();count=verify_prepared(config,project)\n failed=preparation.parent/'run-report.json';need(sha(failed)==failed_sha,'Failed attempt hash differs');run=json.loads(failed.read_bytes())\n need(run['status']=='failed' and run['project']==str(project) and run['preparation_sha256']==sha(preparation),'Only the exact failed preparation may be revised')\n need(not run['PlayMode_entered'] and not run['original_RR23_modified'] and run.get('verification_marker') is None and run.get('signature_verification') is None,'Failed attempt has success/signature evidence')"," assert_unrun(preparation,project);editor=safety.assert_editor_closed();count=verify_prepared(config,project)\n need(config.get('metadata_resource_count')==4,'Exactly four immutable metadata resources required')")
 change(" need(len(old_evidence)==5,'All five prior attempt evidence files required')"," need(len(old_evidence)==1,'Only original unrun preparation evidence admitted')")
 change("updated['cached_harness_revision']={'prior_preparation_sha256':sha(preparation),'prior_failed_report_sha256':failed_sha,","updated['unrun_harness_revision']={'prior_preparation_sha256':sha(preparation),")
 change("'CachedHarnessRevision-'+stamp","'UnrunHarnessRevision-'+stamp")
 change("'schema':'cached-real-harness-CodeGen-only-revision/v1'","'schema':'unrun-real-harness-CodeGen-only-revision/v1'")
 change("'failed_report':linked(failed),",'')
 change("m['schema']=='cached-real-harness-CodeGen-only-revision/v1'","m['schema']=='unrun-real-harness-CodeGen-only-revision/v1'")
 change(" markers_absent(project);safety.assert_editor_closed();old=read_pinned(m['preparation']);verify_prepared(old,project);read_pinned(m['failed_report']);new=read_pinned(m['proposed_preparation'])"," assert_unrun(preparation,project);safety.assert_editor_closed();old=read_pinned(m['preparation']);verify_prepared(old,project);need(old.get('metadata_resource_count')==4,'Exact four-resource preparation');new=read_pinned(m['proposed_preparation'])")
 change("expected['cached_harness_revision']=new['cached_harness_revision']","expected['unrun_harness_revision']=new['unrun_harness_revision']")
 change("p.add_argument('--failed-report-sha256');",'')
 change("need(not a.apply and all((a.preparation,a.stage,a.build_report,a.failed_report_sha256)),'Preparation needs all four exact pinned inputs');path=prepare(a.preparation,a.stage,a.build_report,a.failed_report_sha256)","need(not a.apply and all((a.preparation,a.stage,a.build_report)),'Preparation needs all three exact pinned inputs');path=prepare(a.preparation,a.stage,a.build_report)")
 # Guard a strict inverse delta: no unnoticed weakening of shared transaction code.
 inverse=text
 for row in reversed(changes):
  if row['new']:inverse=inverse.replace(row['new'],row['old'],1)
  else:continue
 # Empty-fragment deletions are proved by the complete forward transform/source hash.
 compile(text,'revise_unrun_compile_harness_fast.py','exec')
 target=TOOLS/'revise_unrun_compile_harness_fast.py'
 if target.exists():raise ValueError('Fresh versioned helper only')
 target.write_text(text);receipt=TOOLS/'unrun-harness-revision-helper-provenance.json';report={'schema':'never-launched-harness-package-only-helper-source-derivative/v1','old_helper':{'path':str(source),'sha256':hashlib.sha256(source.read_bytes()).hexdigest()},'new_helper':{'path':str(target),'sha256':hashlib.sha256(target.read_bytes()).hexdigest()},'reviewed_exact_source_changes':changes,'no_helper_applied_or_Unity_launched':True,'immutable_four_resources_required':True,'no_previous_launch_or_cache_admitted':True};receipt.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'helper':str(target),'sha256':report['new_helper']['sha256'],'provenance':str(receipt),'changes':len(changes),'applied':False}))
if __name__=='__main__':main()
