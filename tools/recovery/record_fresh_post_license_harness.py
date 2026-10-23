"""Prove the fresh validation copy has exactly the previously reviewed inputs."""
import json
from pathlib import Path
import prepare_marshalling_integration as p

old = p.ROOT / 'Validation/ActualUnityCodeCompile-20261022T160416Z-73c46075'
new = p.ROOT / 'Validation/ActualUnityCodeCompile-20261022T172617Z-e30f5991'
license_probe = p.ROOT / 'Validation/RefreshedUnity2020LicenseProbe-20261022T172424Z-5574e2f0/report.json'
a = p.read(old / 'report.json'); b = p.read(new / 'report.json'); license_doc = p.read(license_probe)
p.need(license_doc['status'] == 'passed_matching_Editor_executed_trusted_probe' and license_doc['trusted_Editor_probe_executed'] and not license_doc['license_failure_message_detected'], 'Matching Editor trusted license probe required')
old_files = {r['target']: r['sha256'] for r in a['copied_files']}
new_files = {r['target']: r['sha256'] for r in b['copied_files']}
p.need(old_files == new_files and len(new_files) == 10946, 'Fresh input set differs')
p.need({r['path']: r['sha256'] for r in a['generated_files']} == {r['path']: r['sha256'] for r in b['generated_files']}, 'Generated response/verifier bytes differ')
for name in ('source_plan', 'integration_plan', 'plugins', 'importers'):
    p.need(a[name]['sha256'] == b[name]['sha256'], 'Core source/stage/plugin/importer plan hash changed')
report = {'schema': 'fresh-post-license-actual-Unity-harness-equivalence/v1', 'status': 'identical_inputs_fresh_output_only',
          'inputs': [p.pinned(x) for x in (old / 'report.json', old / 'run-report.json', new / 'report.json', license_probe)],
          'all_10946_relative_input_hashes_equal': True, 'generated_response_and_verifier_hashes_equal': True,
          'source_stage_plugins_importer_plan_hashes_equal': True, 'old_failed_output_logs_preserved': True,
          'main_RR23_changed_by_preparation': False, 'actual_Unity_launched_by_this_tool': False,
          'root_execution_context_required_for_legacy_license_probe': True,
          'actual_Unity_acceptance_claimed': False}
target = new / 'fresh-equivalence.json'
target.write_text(json.dumps(report, indent=2) + '\n')
print(json.dumps({'report': str(target), 'sha256': p.sha(target)}))
