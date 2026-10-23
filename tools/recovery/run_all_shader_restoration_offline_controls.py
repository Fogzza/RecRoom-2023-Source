"""Bounded pure data controls for179 orchestration; does not run managed probes."""
from pathlib import Path
import datetime as dt,json,sys,uuid
import run_windows_development_define_probe as guard


def main():
    here=Path(__file__).resolve().parent;out=guard.ROOT/'AssetRecovery'/('All179RestorationOrchestrationControls-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-pure179-restoration-orchestration-controls/v1','status':'starting','phases':[],'Main_modified':False,'managed_compiler_Unity_game_network_launched':False}
    try:
        guard.bounded([sys.executable,'-B',str(here/'test_all_shader_restoration_orchestration.py'),'--out',str(out)],guard.WS,out,'pure179-known8-native-namespace-and-Root-reader-path-controls',256*1024**2,60,report);report['status']='passed'
    except BaseException as error:report.update(status='held',error=repr(error))
    guard.save(out,report);print(json.dumps({'status':report['status'],'receipt':str(out/'run-report.json'),'sha256':guard.sha(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
