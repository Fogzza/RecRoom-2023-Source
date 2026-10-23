"""Classify the bounded 1792MiB actual test without weakening any gate."""
import json
import re
from pathlib import Path
import prepare_marshalling_integration as p

out = p.ROOT / 'Validation/ActualUnityCodeCompile-20261022T172617Z-e30f5991'
run = p.read(out / 'run-report.json')
log = (out / 'Editor.log').read_text(encoding='utf-8-sig', errors='replace')
p.need(run['status'] == 'failed' and run['exit_code'] == 1 and run['max_job_private_bytes'] == 1792 * 1024**2, 'Exact failed 1792MiB attempt required')
lines = log.splitlines()
hits = [i for i, line in enumerate(lines) if 'System.OutOfMemoryException' in line]
p.need(hits and 'WholeMetadataRestorer.Resource' in log and not re.search(r'\berror CS\d+', log), 'Exact source-success/metadata-OOM evidence required')
stage = p.ROOT / 'CompilerRepairs/CurrentCoreNativeScopeMarkerVoid-20261022T162050Z-52cd19e2/stage-plan.json'
doc = p.read(stage)
source = stage.parent / 'Package/Assets/Editor/OriginalMetadataRestoration/WholeMetadataRestorer.cs'
manifest = p.pinned(Path(doc['manifest']['path']), doc['manifest']['sha256'])
report = {'schema': 'actual-Unity-1792MiB-metadata-resource-OOM-classification/v1', 'status': 'metadata_resource_allocation_failed',
          'inputs': [p.pinned(x) for x in (out / 'report.json', out / 'run-report.json', out / 'Editor.log', source)],
          'CSharp_error_CS_count': 0, 'not_a_successful_whole_Unity_compile': True,
          'first_OOM_line': hits[0] + 1, 'first_stack': lines[hits[0]:hits[0] + 11],
          'allocation_path': ['WholeMetadataRestorer.Resource', 'Stream.CopyTo', 'MemoryStream.Write', 'MemoryStream.EnsureCapacity', 'MemoryStream.Capacity', 'Object.AllocVector'],
          'first_restore_resource': {'input': manifest, 'size_bytes': Path(manifest['path']).stat().st_size},
          'resource_implementation': 'Growing MemoryStream.CopyTo followed by ToArray; no change proposed/applied for the identical2048MiB retry.',
          'observed_last_Editor_private_bytes': run['samples'][-1]['editor_private_bytes'],
          'observed_last_global_available_commit_bytes': run['samples'][-1]['available_commit'],
          'aggregate_job_peak_not_captured': True,
          'cause_limit': 'The allocation failure is consistent with the aggregate owned job cap; the report cannot identify aggregate peak from Editor-only samples.',
          'actual_signature_and_completion_marker_absent': run['signature_verification'] is None and run['verification_marker'] is None,
          'original_RR23_modified': False, 'retry_started_by_this_tool': False}
target = out / 'metadata-oom-classification.json'
target.write_text(json.dumps(report, indent=2) + '\n')
print(json.dumps({'report': str(target), 'sha256': p.sha(target), 'stack_start_line': hits[0] + 1}))
