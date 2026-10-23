"""Compile unchanged pinned API source with matching Unity csc, inspect only."""
import ast,ctypes,datetime as dt,importlib.util,json,os,shutil,subprocess,time,uuid
from ctypes import wintypes
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
node=next(n for n in ast.parse((HERE/'compile_official_steamworks14.py').read_text()).body if isinstance(n,ast.FunctionDef) and n.name=='phase');exec(compile(ast.Module(body=[node],type_ignores=[]),'guard-phase','exec'))
out=ROOT/'Validation'/('CompiledOfficialOpenVrApi-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'matching-official-openvr-api-compiled-witness/v1','project_modified':False,'sdk_or_game_code_executed':False,'phases':[]}
try:
 source=ROOT/'Validation/OfficialOpenVrHistory-20261022T152224Z-8ad5fe16/Revisions/0bc5102e728b0f3484f0fe2f14c0f5919fe2ea84/openvr_api.cs';expected='e05ba82c153018f63bc677967940c8778b89419e54b460e1bdd6413a0bc2141f'
 if g.sha(source)!=expected:raise ValueError('Pinned official source hash differs')
 editor=WS/'Tools/Editors/2020.3.33f1/Editor';compiler=editor/'Data/Tools/Roslyn/csc.exe';framework=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';refs=[framework/'mscorlib.dll',framework/'System.dll',framework/'System.Core.dll',editor/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll'];target=out/'OfficialOpenVrApi.dll';rsp=out/'api.rsp';rsp.write_text('\n'.join(['/nologo','/nostdlib+','/target:library','/optimize+','/unsafe+','/langversion:8','/define:UNITY_5_3_OR_NEWER;UNITY_STANDALONE_WIN','/out:"'+str(target)+'"']+['/reference:"'+str(p)+'"' for p in refs]+['"'+str(source)+'"'])+'\n');phase([compiler,'/noconfig','@'+str(rsp)],out,'compile-unchanged-official-api',report,cap=.25)
 reader=ROOT/'Validation/OpenVrProviderInventory-20261022T152014Z-8ff9c4c6/OpenVrMetadataInventory.dll';selection=out/'inputs.json';selection.write_text(json.dumps([str(target)]));inventory=out/'inventory.json';phase([g.DOTNET,reader,selection,inventory],out,'read-compiled-descriptors',report,cap=.125)
 report.update(status='passed',source={'path':str(source),'sha256':expected},compiler_inputs=[{'path':str(p),'sha256':g.sha(p)} for p in [compiler]+refs],compiled_witness={'path':str(target),'sha256':g.sha(target)},inventory={'path':str(inventory),'sha256':g.sha(inventory)})
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)
