"""One bounded pure-Python static native audit, no managed target execution."""
from pathlib import Path
import datetime as dt, json, sys, uuid
from run_win32_abi_compat_fixture import ROOT, phase, sha
HERE=Path(__file__).resolve().parent
folder=ROOT/'Validation'/('RecRoomAwakeCandidateGuard-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);folder.mkdir()
report={'schema':'bounded-static-native-startup-Python-audit-execution/v1','status':'started','project_modified':False,'game_or_native_code_executed':False}
try:
    report['phase']=phase([sys.executable,HERE/'stage_recroom_awake_typed_candidate.py'],folder,'original-native-CFG-and-identities',64*1024**2,60)
    result=json.loads((folder/'original-native-CFG-and-identities/output.log').read_text().splitlines()[-1]);report.update(status='passed',result=result)
except BaseException as error:report.update(status='failed',error=repr(error))
path=folder/'report.json';path.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'status':report['status'],'report':str(path),'sha256':sha(path),'error':report.get('error'),'result':report.get('result')}));raise SystemExit(0 if report['status']=='passed' else 1)
