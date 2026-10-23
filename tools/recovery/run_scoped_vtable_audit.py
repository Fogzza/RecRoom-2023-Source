import json,shutil,uuid
from datetime import datetime,timezone
from pathlib import Path
import build_stage_guarded as b
import prepare_marshalling_integration as p
out=p.ROOT/'Validation'/('COMLEScopedVtable-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'guarded-scoped-vtable-readonly-audit/v1','phases':[],'game_code_executed':False}
try:
 cecil=p.WORKSPACE/'Tools/RecoveryTools/MetadataProbe/Published/Mono.Cecil.dll';shutil.copyfile(cecil,out/cecil.name);source=p.HERE/'ScopedVtableAudit.cs';exe=out/'ScopedVtableAudit.exe';framework=b.EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/target:exe','/nostdlib+','/langversion:7.3','/out:"'+str(exe)+'"']+['/reference:"'+str(framework/n)+'"' for n in ('mscorlib.dll','System.dll','System.Core.dll','System.Web.Extensions.dll','Facades/netstandard.dll')]+['/reference:"'+str(cecil)+'"','"'+str(source)+'"'])+'\n')
 b.reserved_phase([b.EDITOR/'Data/Tools/Roslyn/csc.exe','@'+str(rsp)],out,'compile',report,cap=.25,maximum=30)
 raw=p.ROOT/'ScriptRecoveryModernLayout/Attempt-20261022T021923Z-2fcf0245/Output/Assembly-CSharp.dll';actual=p.ROOT/'Validation/CurrentCoreMarshalRoundtrip-20261022T153628Z-c5c43a1f/ActualCurrentCoreOutput/Assembly-CSharp.dll';data=out/'vtable.json'
 refs=p.ROOT/'Validation/CurrentCoreMarshalRoundtrip-20261022T153628Z-c5c43a1f/exact-original-metadata-references.txt'
 b.reserved_phase([b.EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',exe,raw,actual,data,refs],out,'metadata',report,cap=.25,maximum=30)
 report.update(status='passed',inputs=[p.pinned(x) for x in (source,cecil,raw,actual)],metadata=p.pinned(data))
except Exception as e:report.update(status='failed',error=str(e))
(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'error':report.get('error')}))

