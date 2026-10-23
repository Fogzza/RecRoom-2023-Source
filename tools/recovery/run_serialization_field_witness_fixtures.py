"""Bounded production resolver tests; reads metadata only, never client code."""
import datetime as dt, importlib.util, json, shutil, uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent
spec=importlib.util.spec_from_file_location('serial_fixture_guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
def main():
 out=g.ROOT/'Validation'/('SerializationFieldWitnessFixtures-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'production-serialization-field-resolver-fixtures/v1','phases':[],'project_modified':False,'game_code_executed':False}
 try:
  sources=[HERE/'SerializationFieldWitnessFixtures.cs',HERE/'SerializationFieldIdentityWitness.cs',g.ROOT/'CompilerRepairs/MetadataRestorationPilot/CanonicalMetadataSignatures.cs'];deps=[HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll'];inputs=sources+deps+[Path(__file__).resolve()];report['inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in inputs];host=out/'SerializationFieldWitnessFixtures.dll';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/langversion:latest','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+deps]+['"'+str(p)+'"' for p in sources])+'\n');g.phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-production-resolver-fixtures',report,maximum=120,cap=.125)
  for p in deps:shutil.copyfile(p,out/p.name)
  host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));g.phase([g.DOTNET,host],out,'production-resolver-positive-and-negative-fixtures',report,maximum=30,cap=.125)
  if not all(g.sha(Path(row['path']))==row['sha256'] for row in report['inputs']):raise ValueError('Pinned source/dependency drift')
  report['status']='passed';return 0
 except Exception as error:report['status']='failed';report['error']=str(error);return 1
 finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'output':str(out),'status':report['status'],'error':report.get('error')}))
if __name__=='__main__':raise SystemExit(main())
