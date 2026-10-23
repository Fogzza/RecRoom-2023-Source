"""Bounded synthetic target-reference controls plus the unchanged226-input closure."""
from pathlib import Path
from datetime import datetime,timezone
import importlib.util,json,shutil,uuid
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('sdk_reference_fixture_guard',HERE/'build_stage_guarded.py');guard=importlib.util.module_from_spec(spec);spec.loader.exec_module(guard)
output=ROOT/'RuntimeSDKRecovery'/('ReferenceFixtureControls-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);output.mkdir();(output/'Inputs').mkdir()
cecil=WORKSPACE/'Tools/RecoveryTools/MetadataProbe/Published/Mono.Cecil.dll';shutil.copyfile(cecil,output/'Mono.Cecil.dll')
sources=[]
for name in ('SDKReferenceAudit.cs','SDKReferenceFixtures.cs'):
    source=HERE/name;target=output/'Inputs'/name;shutil.copyfile(source,target);sources.append(target)
framework=guard.EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';exe=output/'SDKReferenceAudit.exe';rsp=output/'compile.rsp'
rsp.write_text('\n'.join(['/target:exe','/nostdlib+','/langversion:7.3','/out:"'+str(exe)+'"']+['/reference:"'+str(framework/name)+'"' for name in ('mscorlib.dll','System.dll','System.Core.dll','System.Web.Extensions.dll','Facades/netstandard.dll')]+['/reference:"'+str(cecil)+'"']+['"'+str(p)+'"' for p in sources])+'\n')
report={'schema':'sdk-reference-controls-and-current-closure/v1','status':'starting','phases':[],'SDK_or_game_methods_invoked':False,'project_changed':False,'source_snapshots':[{'path':str(p),'sha256':guard.guard.sha(p)} for p in sources]}
try:
    guard.reserved_phase([guard.EDITOR/'Data/Tools/Roslyn/csc.exe','@'+str(rsp)],output,'compile-trusted-reference-controls',report,maximum=60,cap=.25)
    guard.reserved_phase([guard.EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',exe,'--fixtures',output/'Cases',guard.EDITOR],output,'synthetic-reference-controls',report,maximum=60,cap=.25)
    proposal=ROOT/'RuntimeSDKRecovery/GenuineAddressablesProposal-20261022T140804Z-40686d7c'
    # Prior identical226-input closure measured32.8MB; this tighter128MiB cap
    # preserves the1.5GiB system reserve and limits the read-only audit further.
    guard.reserved_phase([guard.EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',exe,proposal/'explicit-current-core-and-runtime-inputs.txt',proposal/'PlayerWindows',guard.EDITOR,output/'proposed-sdk-current-closure.json'],output,'current226-runtime-core-target-sdk-closure',report,maximum=90,cap=.125)
    fixture=json.loads((output/'Cases/fixture-report.json').read_text());closure=json.loads((output/'proposed-sdk-current-closure.json').read_text())
    if fixture['status']!='passed' or fixture['controls']!=8 or closure['status']!='passed' or closure['unresolved']:raise ValueError('Strict reference controls and closure must pass')
    report.update(status='passed',synthetic_controls=8,explicit_current_runtime_assemblies=226,unresolved_sdk_references=0)
except Exception as error:report.update(status='failed',error=str(error))
(output/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(output/'report.json'),'error':report.get('error')}))
raise SystemExit(0 if report['status']=='passed' else 1)
