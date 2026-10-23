"""Bounded staging only; no compiler, Unity, inspected code or deployment."""
import argparse
from datetime import datetime, timezone
import importlib.util
import json
from pathlib import Path
import sys
import uuid

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18'
spec = importlib.util.spec_from_file_location('current_core_prepare_guard', HERE.parent / 'MovementRequestEvidence/run_guarded.py')
guard = importlib.util.module_from_spec(spec); spec.loader.exec_module(guard)


def main():
    p = argparse.ArgumentParser(); p.add_argument('--source', type=Path, required=True); p.add_argument('--references', type=Path, required=True);p.add_argument('--method-audit',type=Path);p.add_argument('--field-bindings',type=Path)
    args = p.parse_args()
    stamp = datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]
    run = ROOT / 'Validation' / ('CurrentCoreIntegrationPrepare-' + stamp); run.mkdir()
    target = ROOT / 'CompilerRepairs' / ('CurrentCoreIntegration-' + stamp)
    report = {'schema': 'guarded-current-core-integration-staging/v1', 'phases': [], 'project_changed': False, 'game_code_executed': False}
    try:
        command=[sys.executable, HERE / 'prepare_current_core.py', '--source', args.source.resolve(), '--references', args.references.resolve(), '--output', target, '--mode', 'emitted-original-subset']
        if args.method_audit:command+=['--method-audit',args.method_audit.resolve()]
        if args.field_bindings:command+=['--field-bindings',args.field_bindings.resolve()]
        guard.phase(command,
                    run, 'stream-manifests-and-stage-editor-only-pipeline', report, maximum=180, cap=.25)
        report.update(status='prepared', stage=str(target), stage_plan_sha256=guard.sha(target / 'stage-plan.json'))
    except Exception as e:
        report.update(status='failed', error=str(e), partial_stage=str(target))
    path = run / 'guard-report.json'; path.write_text(json.dumps(report, indent=2) + '\n')
    print(json.dumps({'status': report['status'], 'report': str(path), 'stage': report.get('stage'), 'error': report.get('error')}))
    return 0 if report['status'] == 'prepared' else 1


if __name__ == '__main__':
    raise SystemExit(main())
