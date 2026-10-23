"""Run only bounded pure streaming-patch controls, never Editor/managed code."""
from pathlib import Path
import datetime as dt
import json
import sys
import uuid
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
WS=HERE.parents[2]


def main():
    out=WS/'Recovery/RecRoom-2023-04-18/AssetRecovery'/('StreamingShaderPatchControls-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8])
    out.mkdir()
    report={'schema':'guarded-pure-streaming-Shader-patch-controls/v1','status':'starting','phases':[],
            'Main_modified':False,'Unity_launched':False,'compiler_launched':False}
    try:
        guard.bounded([sys.executable,'-B',str(HERE/'test_streaming_shader_patch.py'),'--out',str(out)],WS,out,
                      'pure-streaming-native-Shader-controls',256*1024**2,60,report)
        report['status']='passed_streaming_AG_Fallback_and_strict_negative_controls'
    except BaseException as exc: report.update(status='failed_or_guard_refused',error=repr(exc))
    finally:
        guard.save(out,report)
        print(json.dumps({'status':report['status'],'receipt':str(out/'run-report.json'),'sha256':guard.sha(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status'].startswith('passed_') else 1


if __name__=='__main__': raise SystemExit(main())
