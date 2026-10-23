"""Record exact RAR rejections without changing any main/IDE input."""
import json,shutil,uuid
from pathlib import Path
from datetime import datetime,timezone
import prepare_marshalling_integration as p
import build_stage_guarded as b
old=p.ROOT/'Validation/SolarNetActualIDEDesignTime-20261022T165323Z-96d3996e/report.json';out=p.ROOT/'Validation'/('SolarNetIDERARRejection-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'actual-IDE-RAR-targeted-rejection-diagnostic/v1','phases':[],'project_modified':False,'source_compilation_executed':False,'game_code_executed':False}
try:
 prior=p.read(old);command=prior['phases'][0]['command'];target=out/'bin/Assembly-CSharp-firstpass.dll';target.parent.mkdir();shutil.copyfile(prior['firstpass_metadata_only_witness']['source']['path'],target);command=[s for s in command if not s.startswith(('/getProperty:','/getItem:'))];command=[('/v:diag' if s=='/v:q' else s.replace(str(old.parent),str(out))) for s in command]+['/p:SilentResolveWarnings=false'];b.reserved_phase(command,out,'actual-RAR-diagnostic',report,maximum=60,cap=.125)
 lines=(out/'actual-RAR-diagnostic.log').read_text(encoding='utf-8-sig',errors='replace').splitlines();selected={}
 for name in ('UnityEngine','UnityEngine.CoreModule','AstarPathfindingProject','mscorlib'):
  starts=[i for i,s in enumerate(lines) if 'Primary reference "'+name+'"' in s];snippets=[]
  for i in starts:
   end=next((j for j in range(i+1,len(lines)) if 'Primary reference "' in lines[j]),min(i+160,len(lines)));snippets.extend(lines[i:min(end,i+160)])
  selected[name]=snippets
 evidence=out/'targeted-rejection-lines.json';evidence.write_text(json.dumps(selected,indent=2)+'\n');report.update(status='diagnostic_recorded_not_reference_fix',targeted_lines=p.pinned(evidence),full_log=p.pinned(out/'actual-RAR-diagnostic.log'),original_reference_report=p.pinned(old))
except Exception as e:report.update(status='failed',error=str(e))
(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'targeted':report.get('targeted_lines'),'error':report.get('error')}))
