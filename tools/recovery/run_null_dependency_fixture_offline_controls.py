"""Bounded Python-only controls; launches no managed/native application."""
from pathlib import Path
import datetime as dt
import json
import sys
import uuid
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent


def main():
    out=guard.ROOT/'Validation'/('NullDependencyFixtureControls-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-pure-null-dependency-fixture-controls/v1','status':'starting','phases':[],
        'Main_modified':False,'managed_compiler_Unity_game_network_launched':False}
    try:
        guard.bounded([sys.executable,'-B',str(HERE/'test_null_dependency_fixture_preparation.py'),'--out',str(out)],guard.WS,out,
            'pure-null-projection-fixture-admission-and-final-close-controls',128*1024**2,60,report)
        report['status']='passed'
    except BaseException as error:report.update(status='held',error=repr(error))
    finally:
        guard.save(out,report);print(json.dumps({'status':report['status'],'receipt':str(out/'run-report.json'),'sha256':guard.sha(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
