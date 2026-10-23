"""Compile every captured core source with the seven new original bodies."""
import datetime as dt,importlib.util,json,uuid
from pathlib import Path
from run_body_source_stream_rebase import phase,g,ROOT,WS
def need(value,why):
 if not value:raise ValueError(why)
def main():
 out=ROOT/'Validation'/('BodyFullCompile-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'fresh-full-core-native-seven-body-compile/v1','phases':[],'project_modified':False,'game_code_executed':False}
 try:
  baseline=ROOT/'Validation/CompileCheck-20261022T104058Z-8b5ef50d/report.json';old=json.loads(baseline.read_text());need(old['status']=='compiled' and old['exit_code']==0 and old['unique_errors']==0,'Passed full compiler baseline required')
  partial=ROOT/'Validation/BodySourceProjection-20261022T144115Z-5a339b18/Projection/metadata-restoration.json';p=json.loads(partial.read_text());updates={r['project_relative_path']:r for r in p['source_replacements']};replacements={};pins=[]
  caller_root=ROOT/'Validation/BodyCallerRepairs-20261022T150206Z-a5577583';callers=[]
  for name,key in [('PlayerMovement','Assets/Scripts/Assembly-CSharp/RecRoom/Core/Locomotion/PlayerMovement.cs'),('ReviveButton','Assets/Scripts/Assembly-CSharp/RecRoom/ReviveButton.cs')]:
   proof=caller_root/name/'report.json';r=json.loads(proof.read_text());need(g.sha(Path(r['source']))==r['source_sha256'] and g.sha(Path(r['candidate']))==r['candidate_sha256'] and all(g.sha(Path(x['path']))==x['sha256'] for x in r['inputs']),'Exact caller projection inputs changed');callers.append({'path':str(proof),'sha256':g.sha(proof)});updates[key]={'candidate_path':r['candidate'],'candidate_sha256':r['candidate_sha256']}
  for row in old['replacements']:
   source=Path(row['source']);key=str(source.relative_to(WS/'RR23')).replace('\\','/');candidate=Path(updates[key]['candidate_path']) if key in updates else Path(row['candidate']);expected=updates[key]['candidate_sha256'] if key in updates else row['candidate_sha256'];need(g.sha(candidate)==expected,'Candidate source/reference changed');replacements[str(source).casefold()]=candidate;pins.append({'source':str(source),'source_sha256':g.sha(source),'candidate':str(candidate),'candidate_sha256':expected})
  revive=WS/'RR23/Assets/Scripts/Assembly-CSharp/RecRoom/ReviveButton.cs';r=updates['Assets/Scripts/Assembly-CSharp/RecRoom/ReviveButton.cs'];replacements[str(revive).casefold()]=Path(r['candidate_path']);pins.append({'source':str(revive),'source_sha256':g.sha(revive),'candidate':r['candidate_path'],'candidate_sha256':r['candidate_sha256']})
  spec=importlib.util.spec_from_file_location('check',ROOT/'Tools/check_rr23_compile.py');check=importlib.util.module_from_spec(spec);spec.loader.exec_module(check)
  snapshot=Path(old['response_snapshot']);need(g.sha(snapshot)==old['response_snapshot_sha256'],'Compiler response snapshot changed');target=out/'Assembly-CSharp.dll';response=check.prepare_response(snapshot.read_text(encoding='utf-8-sig'),target,replacements)
  for row in old['additional_references']:
   path=Path(row['path']);need(g.sha(path)==row['sha256'],'Matching engine reference changed');response+='/reference:"'+str(path)+'"\n'
  rsp=out/'compile.rsp';rsp.write_text(response);need(g.sha(check.COMPILER)==old['compiler_sha256'],'Matching2020compiler changed');report.update(baseline={'path':str(baseline),'sha256':g.sha(baseline)},partial_source_plan={'path':str(partial),'sha256':g.sha(partial)},compiler={'path':str(check.COMPILER),'sha256':g.sha(check.COMPILER)},response_snapshot={'path':str(snapshot),'sha256':g.sha(snapshot)},replacements=pins,caller_projection_proofs=callers)
  phase([check.COMPILER,'/noconfig','@'+str(rsp)],out,'actual-full-core-csc',report,cap=1024*1024**2)
  need(all(g.sha(Path(x['source']))==x['source_sha256'] and g.sha(Path(x['candidate']))==x['candidate_sha256'] for x in pins),'Compiler input drift')
  errors=[line for line in (out/'actual-full-core-csc.log').read_text(errors='replace').splitlines() if 'error CS' in line];need(not errors,'CSharp compiler errors remain');report.update(status='passed',exit_code=0,compiler_errors=0,assembly={'path':str(target),'sha256':g.sha(target)},all_captured_core_sources_compiled=True,gameplay_playable_claimed=False)
 except BaseException as error:report.update(status='failed',error=repr(error))
 finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'assembly':report.get('assembly'),'error':report.get('error')}),flush=True)
 return 0 if report['status']=='passed' else 1
if __name__=='__main__':raise SystemExit(main())
