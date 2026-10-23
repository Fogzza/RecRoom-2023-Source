"""Only a pure Python control/preparation child; no compiler/Editor/player."""
from pathlib import Path
import datetime as dt
import json
import sys
import uuid
import run_original_shader_builtin_identity_fixture as fixture


def main():
    out=fixture.ROOT/'AssetRecovery'/('BuiltinIdentityFixtureControls-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-pure-builtin-identity-fixture-controls/v1','status':'starting','phases':[],
        'Main_modified':False,'Unity_launched':False,'compiler_launched':False,'player_launched':False}
    original=fixture.guard.make_job
    fixture.guard.make_job=fixture.telemetry_factory(original,report)
    try:
        fixture.guard.bounded([sys.executable,'-B',str(fixture.HERE/'test_builtin_identity_fixture_preparation.py'),'--out',str(out)],
            fixture.HERE.parents[2],out,'pure-selected-Shader-fixture-controls-and-preparation',256*1024**2,120,report)
        controlled=json.loads((out/'offline-controls.json').read_bytes())
        report.update(status='passed_pure_controls_and_both_prepared_plans_no_Unity_or_compiler',controls=fixture.pin(out/'offline-controls.json'),prepared=controlled['prepared'])
    except BaseException as error:report.update(status='failed_or_guard_refused',error=repr(error))
    finally:
        fixture.guard.make_job=original
        fixture.guard.save(out,report)
        print(json.dumps({'status':report['status'],'receipt':fixture.pin(out/'run-report.json'),'error':report.get('error'),'prepared':report.get('prepared')}))
    return 0 if report['status'].startswith('passed_') else 1


if __name__=='__main__':raise SystemExit(main())
