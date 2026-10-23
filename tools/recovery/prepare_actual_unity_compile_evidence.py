"""Adapt the passed real Unity harness to the deployment compiler-proof schema."""
import hashlib
import json
import re
import sys
import uuid
from datetime import datetime, timezone
from pathlib import Path

WS = Path(__file__).resolve().parents[3]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
MAIN = WS / 'RR23'
sys.path.insert(0, str(WS / 'Tools/RecoveryTools'))
from metadata_projection_subset import array_rows

def sha(p):
    with p.open('rb') as f:
        return hashlib.file_digest(f, 'sha256').hexdigest()

def need(value, message):
    if not value:
        raise ValueError(message)

def main():
    preparation = ROOT / 'Validation/ActualUnityCodeCompile-20261022T180516Z-237f1140/report.json'
    need(sha(preparation) == '0a06080980a0bd88c1e15fd77694dde0bb1cf4a95406cf23bb4056d84b8037d4', 'Preparation drift')
    config = json.loads(preparation.read_bytes())
    run_path = preparation.with_name('run-report.json')
    run = json.loads(run_path.read_bytes())
    need(run['status'] == 'passed' and run['exit_code'] == 0 and not run['PlayMode_entered'] and not run['original_RR23_modified'], 'Actual Unity did not pass')
    need(run['preparation_sha256'] == sha(preparation), 'Wrong actual Unity input proof')
    project = Path(config['project'])
    log = preparation.with_name('Editor.log')
    need(not re.search(r'\berror CS\d+\b', log.read_text(encoding='utf-8-sig', errors='replace')), 'C# error in actual Unity log')
    signature_path = Path(run['signature_verification']['path'])
    need(sha(signature_path) == run['signature_verification']['sha256'], 'Signature proof drift')
    signature = json.loads(signature_path.read_bytes())
    need(signature['status'] == 'passed' and not signature['errors'] and not signature['game_methods_invoked'] and not signature['PlayMode'], 'Type loading proof failed')
    need(signature['core_sha256'] == sha(project / 'Library/ScriptAssemblies/Assembly-CSharp.dll'), 'Actual core changed')
    source_plan = Path(config['source_plan']['path'])
    need(sha(source_plan) == config['source_plan']['sha256'], 'Source plan changed')
    projections = {r['project_relative_path']: r for r in array_rows(source_plan, 'source_replacements')}
    need(len(projections) == 2291, 'Incomplete source projections')
    replacements = []
    for row in config['copied_files']:
        relative = Path(row['target']).as_posix()
        if not (relative.endswith('.cs') and relative.startswith(('Assets/Scripts/', 'Assets/Plugins/Assembly-CSharp-firstpass/'))):
            continue
        original, candidate = MAIN / relative, project / relative
        original_hash = projections[relative]['original_sha256'] if relative in projections else row['sha256']
        need(sha(original) == original_hash and sha(candidate) == row['sha256'], 'Actual compiler source drift: ' + relative)
        if relative in projections:
            need(row['sha256'] == projections[relative]['candidate_sha256'], 'Wrong projected candidate')
        replacements.append({'source': str(original), 'source_sha256': original_hash, 'candidate': str(candidate), 'candidate_sha256': row['sha256']})
    need(len(replacements) == 5110, 'Incomplete actual compiled source inventory')
    out = ROOT / 'Validation' / ('ActualUnityCompileEvidence-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'actual-Unity2020-deployment-compiler-evidence/v1', 'status': 'compiled', 'exit_code': 0, 'unique_errors': 0, 'game_code_executed': False, 'project_modified': False, 'source_files': 5110, 'replacements': replacements, 'actual_run': {'path': str(run_path), 'sha256': sha(run_path)}, 'preparation': {'path': str(preparation), 'sha256': sha(preparation)}, 'signature_verification': {'path': str(signature_path), 'sha256': sha(signature_path)}, 'Editor_log': {'path': str(log), 'sha256': sha(log)}, 'gameplay_functionality_verified': False}
    target = out / 'report.json'
    target.write_text(json.dumps(report, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'status': 'compiled', 'report': str(target), 'sha256': sha(target), 'source_files': len(replacements)}))

if __name__ == '__main__':
    main()
