"""Preserve a strict no-success receipt for the final licensed Editor refusal."""
import json
from datetime import datetime, timezone
from pathlib import Path
import uuid
import prepare_marshalling_integration as p

attempt = p.ROOT / 'Validation/ActualUnityCodeCompile-20261022T160416Z-73c46075'
run = p.read(attempt / 'run-report.json')
p.need(run['status'] == 'failed' and run['exit_code'] == 0 and run['verification_marker'] is None and run['signature_verification'] is None, 'Exact refused attempt required')
p.need(not run['PlayMode_entered'] and not run['original_RR23_modified'], 'No gameplay/project mutation required')
log = (attempt / 'Editor.log').read_text(encoding='utf-8-sig', errors='replace')
needles = ('Machine identification is invalid for current license.', 'BatchMode: Unity has not been activated with a valid License.', 'Current license is invalid and cannot be activated.')
p.need(all(s in log for s in needles), 'License refusal evidence absent')
out = p.ROOT / 'Validation' / ('FinalUnityLicenseRefusal-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
out.mkdir()
report = {'schema': 'actual-Unity-before-compilation-license-refusal/v1', 'status': 'license_rejected_before_compile',
          'inputs': [p.pinned(attempt / n) for n in ('report.json', 'run-report.json', 'Editor.log', 'cli-stdout.json', 'cli-stderr.log')],
          'prepared_input_files_verified': run['verified_prepared_files'],
          'editor_exit_zero_not_accepted_as_success': True, 'strict_completion_marker_absent': True, 'safe_signature_report_absent': True,
          'license_message_lines': [i for i, s in enumerate(log.splitlines(), 1) if any(n in s for n in needles)],
          'source_compilation_result_available': False, 'actual_Unity_signature_acceptance_available': False,
          'main_project_modified': False, 'PlayMode_entered': False, 'retry_started': False,
          'license_files_or_activation_state_changed_by_this_tool': False,
          'next_action_owner': 'Parent investigating legitimate Unity Hub/CLI licensing; no retry or deployment until independently authorized conditions pass.'}
target = out / 'report.json'
target.write_text(json.dumps(report, indent=2) + '\n')
print(json.dumps({'report': str(target), 'sha256': p.sha(target), 'run_report': p.pinned(attempt / 'run-report.json')}))
