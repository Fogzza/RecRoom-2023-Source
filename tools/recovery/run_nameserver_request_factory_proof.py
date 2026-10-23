"""Guarded pure-data whole-opcode proof only; no compiler/Unity/game/network."""
from pathlib import Path
import datetime as dt
import json
import sys
import uuid
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]


def main():
    out=WS/'Recovery/RecRoom-2023-04-18/Validation'/('NativeRequestFactoryProof-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-narrow-native-request-factory-proof/v1','status':'starting','phases':[],
            'Main_modified':False,'Unity_or_compiler_or_game_launched':False,'network_requests':0,
            'tool_sha256':guard.sha(Path(__file__)),'proof_tool_sha256':guard.sha(HERE/'prove_nameserver_request_factory_cfg.py')}
    try:
        guard.bounded([sys.executable,'-B',str(HERE/'prove_nameserver_request_factory_cfg.py'),'--out',str(out)],WS,out,
                      'pure-whole-opcode-factory-and-constructor-proof',256*1024**2,60,report)
        report['status']='bounded_factory_ctor_whole_opcode_proof_passed'
    except BaseException as exc:report.update(status='failed_or_guard_refused',error=repr(exc))
    finally:
        guard.save(out,report);print(json.dumps({'status':report['status'],'receipt':str(out/'run-report.json'),'sha256':guard.sha(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status'].endswith('_passed') else 1


if __name__=='__main__':raise SystemExit(main())
