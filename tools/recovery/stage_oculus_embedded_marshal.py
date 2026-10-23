"""Bounded descriptor-only partial stage. Never edits RR23 or runs SDK code."""
import ast,ctypes,datetime as dt,importlib.util,json,os,shutil,subprocess,time,uuid
from ctypes import wintypes
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
node=next(n for n in ast.parse((HERE/'compile_official_steamworks14.py').read_text()).body if isinstance(n,ast.FunctionDef) and n.name=='phase');exec(compile(ast.Module(body=[node],type_ignores=[]),'guard-phase','exec'))
out=ROOT/'Validation'/('OculusEmbeddedMarshalStage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'bounded-isolated-oculus335-partial-descriptor-stage/v1','project_modified':False,'sdk_or_game_code_executed':False,'phases':[]}
try:
    overlay=ROOT/'Validation/EmbeddedOculusOpenVrProof-20261022T162420Z-469c22f2/report.json';data=json.loads(overlay.read_text());expected=g.sha(overlay)
    if data['status']!='native_source_descriptor_ownership_proven' or len(data['unresolved'])!=20:raise ValueError('Reviewed335proof/20gaps absent')
    for r in data['inputs'].values():
        if g.sha(r['path'])!=r['sha256']:raise ValueError('Proof input changed')
    fixtures=ROOT/'Validation/EmbeddedOculusOpenVrFixtures-20261022T162416Z-892b1e13/report.json';fixture=json.loads(fixtures.read_text())
    if fixture['status']!='passed' or len(fixture['negative_controls'])!=20 or g.sha(fixture['tool']['path'])!=fixture['tool']['sha256']:raise ValueError('Production proof mutation controls absent')
    pilot=ROOT/'CompilerRepairs/MetadataRestorationPilot';sources=[HERE/'OculusEmbeddedMarshalStage.cs',HERE/'CanonicalMarshallingContracts.cs',pilot/'CanonicalMetadataSignatures.cs',pilot/'MetadataRoundTripSafety.cs',pilot/'BodyAndSymbolSafety.cs'];cecil=HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll';host=out/'OculusEmbeddedMarshalStage.dll';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+[cecil]]+['"'+str(p)+'"' for p in sources])+'\n');report['source_inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in sources]
    phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-metadata-only-partial-stager',report,cap=.125)
    shutil.copyfile(cecil,out/cecil.name);host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));target=out/'Candidate/Oculus.VR.dll';target.parent.mkdir();proof=out/'stage-proof.json'
    phase([g.DOTNET,host,overlay,target,proof],out,'native-source-bind-controls-and-stage',report,cap=.25)
    result=json.loads(proof.read_text())
    assert result['status']=='passed' and result['negative_controls']==24 and result['marshal_owners']==335 and result['unresolved_owners']==20 and not result['project_modified']
    if not all(g.sha(r['path'])==r['sha256'] for r in report['source_inputs']):raise ValueError('Tool source changed')
    report.update(status='passed',overlay={'path':str(overlay),'sha256':expected},native_proof_fixtures={'path':str(fixtures),'sha256':g.sha(fixtures)},candidate={'path':str(target),'sha256':g.sha(target)},proof={'path':str(proof),'sha256':g.sha(proof)},limitations=['Only335 missing descriptor records restored in an isolated candidate. Twenty dangling native marshal owners remain explicitly unresolved.','No runtime/Unity smoke and no deployment. No SDK bodies or platform settings changed.','Original Oculus wrapper version1.78.0 is proven, overall package release remains unknown.'])
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)
