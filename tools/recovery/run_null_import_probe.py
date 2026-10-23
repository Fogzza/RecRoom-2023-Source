from pathlib import Path
import importlib.util,json,shutil,uuid
from datetime import datetime,timezone
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'MovementRequestEvidence/run_guarded.py');guard=importlib.util.module_from_spec(spec);spec.loader.exec_module(guard)
out=ROOT/'Validation'/('NullImportMapProbe-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
cecil=WS/'Tools/RecoveryTools/MetadataProbe/Published/Mono.Cecil.dll';shutil.copyfile(cecil,out/cecil.name);source=out/'NullImportMapProbe.cs';shutil.copyfile(HERE/source.name,source)
api=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';exe=out/'NullImportMapProbe.exe';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/noconfig','/nostdlib+','/langversion:8.0','/target:exe',f'/out:"{exe}"']+[f'/reference:"{api/name}"' for name in ('mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll')]+[f'/reference:"{cecil}"',f'"{source}"'])+'\n')
report={'schema':'trusted-synthetic-null-import-map-probe/v1','phases':[],'game_code_executed':False,'project_modified':False,'source_sha256':guard.sha(source)}
try:
 guard.phase([EDITOR/'Data/Tools/Roslyn/csc.exe','@'+str(rsp)],out,'compile',report,maximum=60,cap=.2)
 guard.phase([EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',exe],out,'metadata-write-and-trusted-fixture-type-load',report,maximum=60,cap=.2);report['status']='probed'
except Exception as e:report.update(status='failed',error=str(e))
(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(out/'report.json')}))
