import json,shutil,uuid
from datetime import datetime,timezone
from pathlib import Path
import prepare_marshalling_integration as p
import build_stage_guarded as b
stage=p.ROOT/'CompilerRepairs/CurrentCoreNativeFrameworkScopes-20261022T155734Z-4d53f2ad';folder=stage/'Package/Assets/Editor/OriginalMetadataRestoration';out=p.ROOT/'Validation'/('FrameworkScopeFixtures-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'finite-original-framework-scope-production-fixtures/v1','phases':[],'game_code_executed':False,'project_modified':False}
try:
 cecil=stage/'ToolBuild/Mono.Cecil.dll';shutil.copyfile(cecil,out/cecil.name);framework=b.EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';exe=out/'FrameworkScopeFixtures.exe';sources=[p.HERE/'FrameworkScopeFixtures.cs',folder/'ExactOriginalFrameworkScopes.cs',folder/'ScopedMetadataSignatures.cs'];rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/target:exe','/nostdlib+','/langversion:7.3','/out:"'+str(exe)+'"']+['/reference:"'+str(framework/n)+'"' for n in ('mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll')]+['/reference:"'+str(cecil)+'"']+['"'+str(x)+'"' for x in sources])+'\n')
 b.reserved_phase([b.EDITOR/'Data/Tools/Roslyn/csc.exe','@'+str(rsp)],out,'compile',report,maximum=30,cap=.25);b.reserved_phase([b.EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',exe],out,'fixtures',report,maximum=30,cap=.25);report.update(status='passed',checks=9,source_inputs=[p.pinned(x) for x in sources])
except Exception as e:report.update(status='failed',error=str(e))
(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'error':report.get('error')}))
