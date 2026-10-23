"""Compile-check the temporary Editor observer; do not install or run it."""
import datetime as dt
import json
import uuid
from pathlib import Path
from run_body_source_stream_rebase import ROOT, WS, g, phase


def main():
    out = ROOT / 'Validation' / ('StartupPlayObserver-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    source = Path(__file__).with_name('VerifyOriginalStartupPlay.cs')
    editor = WS / 'Tools/Editors/2020.3.33f1/Editor'
    refs = [editor / 'Data/Managed/UnityEditor.dll',
            editor / 'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',
            editor / 'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll',
            editor / 'Data/MonoBleedingEdge/lib/mono/unityjit/mscorlib.dll',
            editor / 'Data/MonoBleedingEdge/lib/mono/unityjit/System.dll']
    compiler = editor / 'Data/Tools/Roslyn/csc.exe'
    report = {'schema': 'startup-Play-observer-preparation/v1', 'phases': [], 'project_modified': False,
              'Play_mode_entered': False, 'game_code_executed': False,
              'inputs': [{'path': str(p), 'sha256': g.sha(p)} for p in [source, compiler] + refs]}
    response = out / 'compile.rsp'
    response.write_text('\n'.join(['/nologo', '/target:library', '/out:"' + str(out / 'StartupPlayObserver.dll') + '"']
        + ['/reference:"' + str(p) + '"' for p in refs] + ['"' + str(source) + '"']) + '\n')
    try:
        phase([compiler, '/noconfig', '@' + str(response)], out, 'compile-matching-Unity2020-observer', report,
              cap=384 * 1024**2)
        report['status'] = 'compile_checked_not_installed_or_run'
    except BaseException as error:
        report.update(status='failed', error=repr(error))
    (out / 'report.json').write_text(json.dumps(report, indent=2) + '\n')
    print(json.dumps({'status': report['status'], 'report': str(out / 'report.json')}), flush=True)
    return 0 if report['status'] == 'compile_checked_not_installed_or_run' else 1


if __name__ == '__main__':
    raise SystemExit(main())
