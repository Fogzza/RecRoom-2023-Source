"""Root-approved final production CodeGen-only transaction; no Unity launch."""
from pathlib import Path
from datetime import datetime, timezone
import hashlib, json, sys, uuid
from run_win32_abi_compat_fixture import ROOT, phase, need

def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()

def main():
    helper = ROOT / 'Tools/revise_unrun_compile_harness_fast.py'
    need(sha(helper) == 'bf363f4abf57626a242795dddca61f65a882897f18ce8d5db1f3440a89af081f', 'Reviewed helper changed')
    prep = ROOT / 'Validation/ActualUnityCodeCompile-20261022T160416Z-73c46075/report.json'
    stage = ROOT / 'CompilerRepairs/CurrentCoreNativeScopeMarkerVoid-20261022T162050Z-52cd19e2/stage-plan.json'
    readiness = ROOT / 'Validation/CurrentCoreMarshalRoundtrip-20261022T162157Z-ad86540f/integration-readiness.json'
    need(sha(readiness) == 'c8e24bbac03062f697eb08120579c4d58aa0e4a6d43a538f01987c3cccc358a5', 'Final readiness changed')
    walk = ROOT / 'Validation/Mono64Native22CoreSignatures-20261022T162544Z-b62af215/diagnostic-run-report-r2.json'
    need(sha(walk) == '6d7a6f04b74a52b977e10200267a073691ad3a6a8166d69ab201d2f04581dbf7' and json.loads(walk.read_text())['status'] == 'passed', 'Final core reflection prerequisite changed')
    folder = ROOT / 'Validation' / ('FinalUnrunRevision-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    folder.mkdir()
    report = {'schema': 'reviewed-final-unrun-CodeGen-revision-execution/v1', 'status': 'started', 'phases': [], 'actual_RR23_modified': False, 'Unity_launched': False}
    try:
        report['phases'].append(phase([sys.executable, helper, '--preparation', prep, '--stage', stage, '--build-report', readiness], folder, 'prepare', 64*1024**2, 240))
        output = json.loads((folder / 'prepare/output.log').read_text().splitlines()[-1])
        manifest = Path(output['manifest'])
        report['manifest'] = {'path': str(manifest), 'sha256': sha(manifest)}
        report['phases'].append(phase([sys.executable, helper, '--manifest', manifest], folder, 'dryrun', 64*1024**2, 240))
        report['phases'].append(phase([sys.executable, helper, '--manifest', manifest, '--apply'], folder, 'apply', 64*1024**2, 600))
        report.update(status='applied', revised_preparation={'path': str(prep), 'sha256': sha(prep)})
    except BaseException as error:
        report.update(status='failed', error=repr(error))
    result = folder / 'report.json'
    result.write_text(json.dumps(report, indent=2) + '\n')
    print(json.dumps({'status': report['status'], 'report': str(result), 'sha256': sha(result), 'error': report.get('error'), 'preparation': report.get('revised_preparation')}))
    return 0 if report['status'] == 'applied' else 1

if __name__ == '__main__':
    raise SystemExit(main())
