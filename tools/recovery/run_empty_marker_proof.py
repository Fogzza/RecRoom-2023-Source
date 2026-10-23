"""Tiny Roslyn AST proof for the single compiler-added marker constructor."""
import datetime as dt,importlib.util,json,shutil,uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent
spec=importlib.util.spec_from_file_location('marker_guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
def main():
 out=g.ROOT/'Validation'/('EmptyMarkerSourceProof-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'phases':[],'project_modified':False}
 try:
  source=HERE/'ProveEmptyVersionMarker.cs';host=out/'ProveEmptyVersionMarker.dll';deps=[g.SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.dll',g.SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.CSharp.dll'];rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/nullable:enable','/langversion:latest','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+deps]+['"'+str(source)+'"'])+'\n');report['tool']={'path':str(source),'sha256':g.sha(source)};g.phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile',report,maximum=60,cap=.125)
  for p in deps:shutil.copyfile(p,out/p.name)
  host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));proof=out/'source-proof.json';g.phase([g.DOTNET,host,g.WORKSPACE/'RR23/Assets/Scripts/Assembly-CSharp/PrivateImplementationDetailsKQPLETG/__BB_OBFUSCATOR_VERSION_3_8_2.cs',proof],out,'readonly-Roslyn-source-proof',report,maximum=60,cap=.125);report['source_proof']={'path':str(proof),'sha256':g.sha(proof)};report['status']='completed';return 0
 except Exception as e:report['status']='failed';report['error']=str(e);return 1
 finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'output':str(out),'status':report['status'],'error':report.get('error')}))
if __name__=='__main__':raise SystemExit(main())
