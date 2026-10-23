from pathlib import Path
import base64,datetime as dt,hashlib,importlib.util,json,shutil,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sp=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(sp);sp.loader.exec_module(g)
def need(b,s):
 if not b:raise ValueError(s)
def sha(p):return hashlib.sha256(Path(p).read_bytes()).hexdigest()
out=ROOT/'Validation'/('ReviveSourceEffect-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
proof=ROOT/'Validation/ReviveButtonNative-20261022T131500Z/LeafCandidates/report.json';p=json.loads(proof.read_text());files=p['files'];need(len(files)==2,'Two exact sources required');post_apply='--post-apply-addendum' in sys.argv;backup=ROOT/'NativeGameplayRepairs/AppliedBodyBatch-20261022T143919Z-d8d0e6b3/Backups';original_paths={}
for f in files:
 original=backup/f['project_relative_path'] if post_apply else Path(f['source']);original_paths[f['source']]=original;need(sha(original)==f['source_sha256'],'Original baseline/backup changed')
 for a,b in [('meta','meta_sha256'),('candidate','candidate_sha256')]:need(sha(f[a])==f[b],a+' changed')
 if post_apply:need(sha(f['source'])==f['candidate_sha256'],'Applied current source is not exact historical candidate')
ed=WS/'Tools/Editors/2020.3.33f1/Editor';refs=[ed/'Data/MonoBleedingEdge/lib/mono/4.7.1-api/mscorlib.dll',ed/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',WS/'RR23/Assets/Plugins/Unity.TextMeshPro.dll',WS/'RR23/Assets/Plugins/UnityEngine.UI.dll']
stub=out/'OnlyOtherClassDeclarations.cs';stub.write_text('namespace AGUI.StackedUI { public abstract class Button3DBase : UnityEngine.MonoBehaviour {} public class Button3D : Button3DBase {} }\n')
fixture=out/'ReviveFixture.dll';rsp=out/'fixture.rsp';rsp.write_text('\n'.join(['/nologo','/noconfig','/nostdlib+','/target:library','/langversion:8.0','/optimize+','/out:"'+str(fixture)+'"']+['/reference:"'+str(r)+'"' for r in refs]+['"'+str(f['candidate'])+'"' for f in files]+['"'+str(stub)+'"'])+'\n')
report={'schema':'exact-Unity2020-native-Revive-source-effects/v1','phases':[],'project_modified':False,'source_meta_unchanged_by_this_tool':True,'fixture_is_compile_only':True,'post_apply_application_journal_addendum':post_apply}
try:
 g.phase([ed/'Data/Tools/Roslyn/csc.exe','@'+str(rsp)],out,'matching2020compile',report,maximum=30,cap=.125)
 deps=[HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll',g.SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.dll',g.SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.CSharp.dll'];host=out/'ReviveSourceEffectProof.dll';source=HERE/'ReviveSourceEffectProof.cs';hrsp=out/'helper.rsp';hrsp.write_text('\n'.join(['/nologo','/target:exe','/langversion:latest','/out:"'+str(host)+'"']+['/reference:"'+str(r)+'"' for r in list(sorted(g.REF.glob('*.dll')))+deps]+['"'+str(source)+'"'])+'\n')
 g.phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(hrsp)],out,'compileTrustedInspector',report,maximum=30,cap=.125)
 for d in deps:shutil.copyfile(d,out/d.name)
 host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}))
 effect=out/'effects.json';g.phase([g.DOTNET,host,fixture,effect]+[Path(f['candidate']) for f in files]+[stub]+refs,out,'inspectOnlyNoInvocation',report,maximum=30,cap=.125)
 need(json.loads(effect.read_text())['passed'],'Effect proof failed');rows=[];tokens={'GJDIGNBBMNF':'0x06004205','base.FNINFCOHBOK':'0x0600420e','derived.FNINFCOHBOK':'0x0600afcd'}
 for f in files:
  data=original_paths[f['source']].read_bytes();candidate=data;edits=[]
  for e in f['byte_edits']:
   before=bytes.fromhex(e['original_hex']);after=bytes.fromhex(e['replacement_hex']);need(data[e['start']:e['start']+e['length']]==before,'Exact source span changed');edits.append({'start':e['start'],'length':e['length'],'original_base64':base64.b64encode(before).decode(),'replacement_base64':base64.b64encode(after).decode(),'original_method_token':tokens[e['method']]})
  for e in sorted(edits,key=lambda x:x['start'],reverse=True):candidate=candidate[:e['start']]+base64.b64decode(e['replacement_base64'])+candidate[e['start']+e['length']:]
  need(hashlib.sha256(candidate).hexdigest()==f['candidate_sha256'],'Exact candidate body edits differ')
  rows.append({**{k:f[k] for k in ['source','source_sha256','candidate','candidate_sha256','meta','meta_sha256','script_guid','project_relative_path']},'byte_edits':edits,'input_proof':[{'path':str(x),'sha256':sha(x)} for x in [proof,effect,fixture,source,original_paths[f['source']]]+refs],'historical_baseline_from_application_backup':post_apply,'current_source_equals_proved_candidate':post_apply})
 for f in files:need(sha(f['source'])==(f['candidate_sha256'] if post_apply else f['source_sha256']) and sha(f['meta'])==f['meta_sha256'],'Source changed during fixture')
 report.update(status='passed',files=rows,native_proof={'path':str(proof),'sha256':sha(proof)},compiled_effect_proof={'path':str(effect),'sha256':sha(effect)},fixture={'path':str(fixture),'sha256':sha(fixture)},method_count=3)
except BaseException as e:report.update(status='failed',error=str(e))
(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)
raise SystemExit(0 if report['status']=='passed' else 1)
