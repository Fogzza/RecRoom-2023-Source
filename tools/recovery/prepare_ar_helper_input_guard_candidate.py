"""Stage only the preparer guard for three existing AR Editor scripts/metas."""
from pathlib import Path
import datetime as dt,difflib,json,uuid
from prepare_deployment_transaction_hardening import ROOT,sha,need

source=ROOT/'Tools/prepare_compile_deployment_v2291_marshal.py';original=source.read_bytes();text=original.decode().replace('\r\n','\n')
helper='''AR_EDITOR_HELPER_AUDIT={'path':str(ROOT/'Validation/MainARHelpersStaticAPI-20261022T174619Z-e979f732/report.json'),'sha256':'b468aba69c5cf02b0ab8dcede76ae103815c8188bbe55b2ce760911632242925'}

def append_audited_AR_editor_inputs(unchanged):
 audit_path,audit=deploy.read_ref(AR_EDITOR_HELPER_AUDIT)
 deploy.need(audit['status']=='all_used_reflection_and_shader_registration_APIs_present_and_accessible','AR Editor helper API audit did not pass')
 helpers=audit['unchanged_Main_helpers'];expected={'AudioMixerPostprocessor.cs','AvoidSavingYamlShaders.cs','YamlShaderPostprocessor.cs'}
 deploy.need(len(helpers)==3 and {Path(r['path']).name for r in helpers}==expected,'Exactly three audited AR Editor helpers required')
 existing={str(Path(r['path'])).casefold():r for r in unchanged};admitted=set()
 for row in helpers:
  script=deploy.safe(row['path'],PROJECT);meta=deploy.safe(row['meta'],PROJECT)
  deploy.need(script.parent==PROJECT/'Assets/Editor/AssetRipperPatches' and meta==script.with_name(script.name+'.meta'),'Unexpected audited helper source/meta path')
  for path,expected_hash in ((script,row['sha256']),(meta,row['meta_sha256'])):
   deploy.need(path.is_file() and deploy.digest(path)==expected_hash,'Audited untouched AR Editor helper input drifted: '+str(path))
   key=str(path).casefold();deploy.need(key not in admitted,'Duplicate audited AR helper input');admitted.add(key)
   if key in existing:deploy.need(existing[key]['sha256']==expected_hash,'Conflicting unchanged-input hash for AR helper')
   else:record={'path':str(path),'sha256':expected_hash};unchanged.append(record);existing[key]=record
 deploy.need(len(admitted)==6,'Exactly six audited helper source/meta inputs required')
 return {'path':str(audit_path),'sha256':AR_EDITOR_HELPER_AUDIT['sha256'],'checks':[{'selector':['status'],'equals':'all_used_reflection_and_shader_registration_APIs_present_and_accessible'}]}

'''
need(text.count('def main():')==1,'Exact preparer main definition');text=text.replace('def main():',helper+'def main():')
before=" offline=json.loads(deploy.safe(a.offline_gates,ROOT).read_bytes());";need(text.count(before)==1,'Exact offline-gates insertion point');text=text.replace(before," ar_helper_gate=append_audited_AR_editor_inputs(unchanged)\n"+before)
before="'integration_gates':[actual,*offline]";need(text.count(before)==1,'Exact integration gate list');text=text.replace(before,"'integration_gates':[actual,*offline,ar_helper_gate]")
need(source.read_bytes()==original,'Production preparer changed during staging')
folder=ROOT/'CompilerRepairs'/('ARHelperInputGuard-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);(folder/'Original').mkdir(parents=True);(folder/'Candidate').mkdir();backup=folder/'Original/prepare_compile_deployment_v2291_marshal.py';backup.write_bytes(original);candidate=folder/'Candidate/prepare_compile_deployment_v2291_marshal.py';candidate.write_bytes(text.encode());diff=folder/'prepare_compile_deployment_v2291_marshal.diff';diff.write_text(''.join(difflib.unified_diff(original.decode().replace('\r\n','\n').splitlines(True),text.splitlines(True),fromfile='Original/prepare_compile_deployment_v2291_marshal.py',tofile='Candidate/prepare_compile_deployment_v2291_marshal.py')))
report={'schema':'review-only-AR-Editor-helper-unchanged-input-guard-candidate/v1','status':'candidate_not_installed','original_tool':{'path':str(source),'sha256':sha(source)},'backup':{'path':str(backup),'sha256':sha(backup)},'candidate':{'path':str(candidate),'sha256':sha(candidate)},'exact_diff':{'path':str(diff),'sha256':sha(diff)},'API_audit':{'path':str(ROOT/'Validation/MainARHelpersStaticAPI-20261022T174619Z-e979f732/report.json'),'sha256':'b468aba69c5cf02b0ab8dcede76ae103815c8188bbe55b2ce760911632242925'},'guarded_unchanged_files':6,'Main_or_original_tool_modified':False,'Editor_helpers_compiled_or_callbacks_executed':False};path=folder/'manifest.json';path.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'manifest':str(path),'sha256':sha(path),'candidate_sha256':sha(candidate),'original_sha256':sha(source)}))
