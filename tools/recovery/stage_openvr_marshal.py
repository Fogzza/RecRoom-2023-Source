"""Bounded isolated395-descriptor stage, never edit RR23 or execute inspected code."""
import ast,ctypes,datetime as dt,importlib.util,json,os,shutil,subprocess,time,uuid
from ctypes import wintypes
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
node=next(n for n in ast.parse((HERE/'compile_official_steamworks14.py').read_text()).body if isinstance(n,ast.FunctionDef) and n.name=='phase');exec(compile(ast.Module(body=[node],type_ignores=[]),'guard-phase','exec'))
out=ROOT/'Validation'/('OpenVrMarshalStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'bounded-isolated-openvr395-descriptor-stage/v1','project_modified':False,'sdk_or_game_code_executed':False,'phases':[]}
try:
 overlay=ROOT/'Validation/OpenVrMarshalOverlay-20261022T154343Z-3e15b919/overlay.json';expected='052d620993cd0a12c4f6ebd9e833eb7060dc46e3e6cce0749d5aaa738ce9dee2'
 if g.sha(overlay)!=expected:raise ValueError('Reviewed overlay hash differs')
 pilot=ROOT/'CompilerRepairs/MetadataRestorationPilot';sources=[HERE/'OpenVrMarshalStage.cs',HERE/'CanonicalMarshallingContracts.cs',pilot/'CanonicalMetadataSignatures.cs',pilot/'MetadataRoundTripSafety.cs',pilot/'BodyAndSymbolSafety.cs'];cecil=HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll';host=out/'OpenVrMarshalStage.dll';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+[cecil]]+['"'+str(p)+'"' for p in sources])+'\n');report['source_inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in sources];phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-metadata-only-stager',report,cap=.125)
 shutil.copyfile(cecil,out/cecil.name);host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));target=out/'Candidate/Unity.XR.OpenVR.dll';target.parent.mkdir();proof=out/'stage-proof.json';phase([g.DOTNET,host,overlay,target,proof],out,'bind-negative-controls-and-stage',report,cap=.25)
 result=json.loads(proof.read_text());assert result['status']=='passed' and result['negative_controls']==19 and result['marshal_owners']==395 and result['project_modified']==False
 if not all(g.sha(Path(r['path']))==r['sha256'] for r in report['source_inputs']):raise ValueError('Tool source changed')
 report.update(status='passed',overlay={'path':str(overlay),'sha256':expected},candidate={'path':str(target),'sha256':g.sha(target)},proof={'path':str(proof),'sha256':g.sha(proof)},limitations=['Descriptor-only isolated candidate. No runtime plugin deployment or gameplay execution.','Original overall package version remains unknown. Genuine official source contracts are matched per owner; no official SDK method bodies substituted.'])
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)
