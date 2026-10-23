"""Read the actual RAR search policy without targets or source compilation."""
import json,uuid
from pathlib import Path
from datetime import datetime,timezone
import prepare_marshalling_integration as p
import build_stage_guarded as b
out=p.ROOT/'Validation'/('SolarNetIDEReferencePolicy-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'actual-project-MSBuild-reference-policy-evaluation/v1','phases':[],'project_modified':False,'source_compile_executed':False,'game_code_executed':False}
try:
 command=[Path(r'C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe'),p.WORKSPACE/'RR23/Assembly-CSharp.csproj','/nologo','/v:q','/nr:false','/getProperty:AssemblySearchPaths,AssemblySearchPath_UseHintPathFromItem,AssemblySearchPath_UseCandidateAssemblyFiles,AssemblySearchPath_UseTargetFrameworkDirectory,AssemblySearchPath_UseGAC,TargetFrameworkDirectory,TargetFrameworkRootPath,FrameworkPathOverride,SpecificVersion,ResolveAssemblyReferencesSilent,SilentResolveWarnings','/getItem:Reference'];b.reserved_phase(command,out,'policy-evaluation-only',report,maximum=30,cap=.125);text=(out/'policy-evaluation-only.log').read_text(encoding='utf-8-sig');data=json.loads(text[text.index('{'):]);(out/'evaluated-policy.json').write_text(json.dumps(data,indent=2)+'\n');report.update(status='evaluated_no_targets',properties=data['Properties'],reference_items=len(data['Items']['Reference']),evidence=p.pinned(out/'evaluated-policy.json'))
except Exception as e:report.update(status='failed',error=str(e))
(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'properties':report.get('properties'),'error':report.get('error')}))
