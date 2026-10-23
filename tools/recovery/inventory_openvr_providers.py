"""Read existing OpenVR metadata providers without executing their code."""
import ast,ctypes,datetime as dt,hashlib,importlib.util,json,os,shutil,subprocess,time,uuid
from ctypes import wintypes
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
# Reuse the reviewed 1.5GiB-reserve phase function, not the SDK runner's top level.
tree=ast.parse((HERE/'compile_official_steamworks14.py').read_text());phase_node=next(n for n in tree.body if isinstance(n,ast.FunctionDef) and n.name=='phase');exec(compile(ast.Module(body=[phase_node],type_ignores=[]),'guard-phase','exec'))
out=ROOT/'Validation'/('OpenVrProviderInventory-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'existing-openvr-provider-audit/v1','project_modified':False,'inspected_code_executed':False,'phases':[]}
try:
 rels=['ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/Output/Unity.XR.OpenVR.dll','ScriptRecoveryModernLayout/Attempt-20261022T021923Z-2fcf0245/Output/Unity.XR.OpenVR.dll','Attempt-20261022T011039Z-e4251f74/Export/AuxiliaryFiles/GameAssemblies/Unity.XR.OpenVR.dll','NativeGameplayRepairs/RuntimePluginMonoCompatibility-20261022T100750Z/Unity.XR.OpenVR.dll']
 inputs=[ROOT/p for p in rels];report['inputs']=[{'path':str(p),'sha256':g.sha(p),'bytes':p.stat().st_size} for p in inputs]
 cecil=HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll';host=out/'OpenVrMetadataInventory.dll';source=HERE/'OpenVrMetadataInventory.cs';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+[cecil]]+['"'+str(source)+'"'])+'\n');phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-reader',report,cap=.125)
 shutil.copyfile(cecil,out/cecil.name);host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));selection=out/'inputs.json';selection.write_text(json.dumps([str(p) for p in inputs]));inventory=out/'inventory.json';phase([g.DOTNET,host,selection,inventory],out,'metadata-only-inventory',report,cap=.25)
 if any(g.sha(Path(x['path']))!=x['sha256'] for x in report['inputs']):raise ValueError('Input changed')
 report.update(status='passed',inventory={'path':str(inventory),'sha256':g.sha(inventory)},helper_source={'path':str(source),'sha256':g.sha(source)})
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)
