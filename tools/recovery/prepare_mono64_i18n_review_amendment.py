"""Finite six-framework dependency amendment; old reviewed artifacts preserved."""
from pathlib import Path
import datetime as dt,hashlib,json,subprocess,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';OLD=ROOT/'Validation/Mono64CoreSignature-20261022T151506Z-476ee90a';I18N=OLD/'finite-I18N-host-dependencies.json'
def need(b,s):
 if not b:raise ValueError(s)
def sha(p):return hashlib.sha256(Path(p).read_bytes()).hexdigest()
def main():
 need(sha(I18N)=='e41f5d272c96af9d53918cde5959aa20915978434f94f5cd7517622b05449d77','FiniteI18N proof changed');add=json.loads(I18N.read_text());need(len(add['references'])==6 and not add['missing_optional_names'],'Exact finite6genuine MonoI18N modules required');p=json.loads((OLD/'plan.json').read_text());need(p['reference_count']==279 and len(p['references'])==279,'Original279client reference whitelist changed');out=ROOT/'Validation'/('Mono64CoreSignatureI18N-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 for row in p['references']+add['references']:need(sha(row['path'])==row['sha256'],'Pinned signature input drifted')
 p.update(status='finite_I18N_amendment_sources_pending_parent_review',original_client_reference_count=279,extra_Mono_host_framework_count=6,references=p['references']+add['references'],reference_count=285,finite_host_I18N_dependency_proof={'path':str(I18N),'sha256':sha(I18N)},prior_failed_whitelist_diagnostic={'path':str(OLD/'diagnostic-run-report-r2.json'),'sha256':sha(OLD/'diagnostic-run-report-r2.json')});(out/'plan.json').write_text(json.dumps(p,indent=2)+'\n')
 result=subprocess.run([sys.executable,str(HERE/'stage_mono64_signature_probe_sources.py'),str(out/'plan.json')],capture_output=True,text=True);need(result.returncode==0,result.stderr);reviewpath=out/'source-review.json';r=json.loads(reviewpath.read_text());config=WS/'Tools/Editors/2020.3.33f1/Editor/Data/MonoBleedingEdge/etc/mono/config';r['source_inputs'].append({'path':str(config),'sha256':sha(config)});r.update(original_client_reference_count=279,additional_host_framework_count=6,finite_I18N_dependency_proof=p['finite_host_I18N_dependency_proof'],prior_failed_whitelist_diagnostic=p['prior_failed_whitelist_diagnostic'],SDK2_runtime_overlay_used=False,known_vendor_dangling_owner_count=790);reviewpath.write_text(json.dumps(r,indent=2)+'\n');print(json.dumps({'review':str(reviewpath),'sha256':sha(reviewpath),'native_inventory_unchanged':True,'host_invoked':False,'references':285}))
if __name__=='__main__':main()
