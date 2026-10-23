"""Only root-reviewed fixed sources/runtime/dependencies; core metadata walk only."""
from pathlib import Path
import ctypes,hashlib,json
from run_win32_abi_compat_fixture import phase,need,EDITOR,ROOT
from prepare_x64_mono_fixture_host import exports
FOLDER=ROOT/'Validation/Mono64CoreSignatureAOT-20261022T154205Z-cb91a4de';REVIEW_SHA='fa19177ba3db2dad4bd128f78de5e0fbb6730d1cb6aad4bfd013132d9f314f0b'
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def main():
 reviewpath=FOLDER/'source-review.json';need(sha(reviewpath)==REVIEW_SHA,'Root-reviewed source plan changed');p=json.loads(reviewpath.read_text());need(not p['host_invoked'] and p['planned_guard']=={'maximum_owned_private_bytes':512*1024**2,'deadline_seconds':60,'minimum_available_commit_bytes':1536*1024**2},'Reviewed fixed diagnostic guard changed')
 for r in p['sources']+p['source_inputs']+[p['runtime']]+p['references']:need(sha(Path(r['path']))==r['sha256'],'Reviewed source/runtime/reference changed')
 need(sha(Path(p['prior_plan']['path']))==p['prior_plan']['sha256'],'Reviewed static prerequisite inventory changed');required=['mono_set_dirs','mono_set_assemblies_path','mono_config_parse','mono_jit_init_version','mono_domain_assembly_open','mono_jit_exec','mono_jit_cleanup']+p['required_additional_exports'];need(set(required)<=exports(Path(p['runtime']['path'])),'Exact runtime required exports absent');need(p['runtime']['sha256']=='5d6e5041c8d0cf6b6969d0425cce16229778d3da5e67ecb2b015dc206cf12fb9','Matching Editor runtime drift')
 suffix='-r1';result=FOLDER/('diagnostic-run-report'+suffix+'.json');need(not result.exists() and not (FOLDER/'core-signature-diagnostic').exists(),'One reviewed host invocation only; prior failure must be compile-only');report={'schema':'root-reviewed-matching-Mono64-core-only-signature-diagnostic/v1','source_review':{'path':str(reviewpath),'sha256':REVIEW_SHA},'prior_whitelist_failure_preserved':str(ROOT/'Validation/Mono64CoreSignatureI18N-20261022T152916Z-f45af857/diagnostic-run-report-r1.json'),'vendor_dependency_marshal_metadata_clean':False,'vendor_dangling_owners':sum(r['count'] for r in p['dependency_marshal_gaps_preserved']),'game_methods_or_native_imports_custom_attribute_constructors_values_invoked':False,'project_or_harness_modified':False,'scope':'core-only metadata/signature reflection; no vendor member enumeration; vendor790 known metadata gaps preserved','phases':[]}
 compiler=Path(r'C:\Program Files\Microsoft Visual Studio\18\Community\VC\Tools\MSVC\14.51.36231\bin\Hostx64\x64\cl.exe');kernel=Path(r'C:\Program Files (x86)\Windows Kits\10\Lib\10.0.26100.0\um\x64\kernel32.lib');host=FOLDER/'FixedMono64CoreSignatureHost.exe';obj=host.with_suffix('.obj');source=host.with_suffix('.c');checker=FOLDER/'SafeCoreSignatureProbe.exe';rsp=FOLDER/('compile-probe'+suffix+'.rsp');profile=EDITOR/'Data/MonoBleedingEdge/lib/mono/unityjit';refs=[profile/'mscorlib.dll',profile/'System.Core.dll',profile/'System.dll'];rsp.write_text('\n'.join(['/nologo','/nostdlib+','/target:exe','/langversion:8.0','/out:"'+str(checker)+'"']+['/reference:"'+str(r)+'"' for r in refs]+['"'+str(FOLDER/'SafeCoreSignatureProbe.cs')+'"','"'+str(FOLDER/'PinnedInputs.cs')+'"'])+'\n')
 try:
  report['phases'].append(phase([EDITOR/'Data/Tools/Roslyn/csc.exe','/noconfig','@'+str(rsp)],FOLDER,'compile-trusted-signature-checker'+suffix,256*1024**2,15));report['phases'].append(phase([compiler,'/nologo','/c','/O2','/GS-','/Zl','/TC','/Fo'+str(obj),source],FOLDER,'compile-fixed-native-host'+suffix,256*1024**2,15));report['phases'].append(phase([compiler.with_name('link.exe'),'/NOLOGO','/NODEFAULTLIB','/ENTRY:HostEntry','/SUBSYSTEM:CONSOLE','/MACHINE:X64','/OUT:'+str(host),obj,kernel],FOLDER,'link-fixed-native-host'+suffix,256*1024**2,15))
  report['built']=[{'path':str(r),'sha256':sha(r)} for r in [checker,host,obj,rsp]]
  for r in p['sources']+[p['runtime']]+p['references']:need(sha(Path(r['path']))==r['sha256'],'Reviewed input changed before invocation')
  k=ctypes.WinDLL('kernel32',use_last_error=True);k.SetErrorMode.argtypes=[ctypes.c_uint];k.SetErrorMode.restype=ctypes.c_uint;prior=k.SetErrorMode(0x8003)
  try:report['phases'].append(phase([host],FOLDER,'core-signature-diagnostic',512*1024**2,60))
  finally:k.SetErrorMode(prior)
  marker=FOLDER/'signature-walk.json';need(marker.is_file(),'Core signature report missing');walk=json.loads(marker.read_text());need(walk['status']=='passed' and walk['core_sha256']==p['core_sha256'] and walk['game_methods_invoked'] is False and walk['PlayMode'] is False and not walk['stopped_at_bound'],'Core-only signature verification did not pass');report.update(status='passed',core_signatures_passed=True,marker={'path':str(marker),'sha256':sha(marker)},walk_counts={x:walk[x] for x in ['types','fields','methods','constructors','properties','events','parameter_signatures']})
 except BaseException as e:report.update(status='failed',error=repr(e),core_signatures_passed=False)
 log=FOLDER/'core-signature-diagnostic/output.log'
 if log.is_file():
  report['log']={'path':str(log),'sha256':sha(log)};tail=log.read_text(errors='replace').splitlines()[-25:];report['last_progress_or_failure_lines']=tail
 result.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(result),'status':report['status'],'sha256':sha(result),'error':report.get('error')}));return 0 if report['status']=='passed' else 1
if __name__=='__main__':raise SystemExit(main())
