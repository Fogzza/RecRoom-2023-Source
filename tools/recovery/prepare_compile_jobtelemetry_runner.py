"""Create a telemetry-only derivative of the frozen reviewed Unity runner.

Never launches Unity or another child process. The live fixture creates an empty
owned JobObject, verifies its configured limits, and closes that object.
"""
import ast
import ctypes
import difflib
import hashlib
import importlib.util
import json
import sys
from datetime import datetime, timezone
from pathlib import Path
from uuid import uuid4

WORKSPACE = Path(__file__).resolve().parents[3]
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18'
BASE = ROOT / 'Tools/run_real_source_compile_harness_v2291_marshal_600.py'
TARGET = BASE.with_name('run_real_source_compile_harness_v2291_marshal_600_jobtelemetry_v2.py')
BASE_SHA = 'f1cf1b56e6e2b01e4a62580ffc4030bf5f784d6d0e498b7bbe2f32ad5a67dfda'

def sha_bytes(value):
    return hashlib.sha256(value).hexdigest()

def need(value, message):
    if not value:
        raise ValueError(message)

def main():
    original = BASE.read_bytes()
    need(sha_bytes(original) == BASE_SHA, 'Frozen reviewed runner changed')
    newline = '\r\n' if b'\r\n' in original else '\n'
    source = original.decode('utf-8')
    addition = '''def query_owned_job_memory(job):
 if not job.handle:raise ValueError('Owned job handle is closed; implicit current-job queries are forbidden')
 query=job.kernel.QueryInformationJobObject
 query.argtypes=[wintypes.HANDLE,ctypes.c_int,ctypes.c_void_p,wintypes.DWORD,ctypes.c_void_p]
 query.restype=wintypes.BOOL
 info=ExtendedJob()
 if not query(job.handle,9,ctypes.byref(info),ctypes.sizeof(info),None):raise ctypes.WinError(ctypes.get_last_error())
 return {'configured_job_limit_bytes':int(info.job_memory),'peak_job_memory_bytes':int(info.peak_job),'peak_process_memory_bytes':int(info.peak_process),'configured_limit_flags':int(info.basic.flags)}

'''.replace('\n', newline)
    old_sample = "sample={'seconds':round(elapsed,2),'editor_private_bytes':info.PrivateUsage,'available_commit':available};report['samples'].append(sample)"
    new_sample = "sample={'seconds':round(elapsed,2),'editor_private_bytes':info.PrivateUsage,'available_commit':available,'owned_job_memory':query_owned_job_memory(job)};report['samples'].append(sample)"
    old_close = '  if job:job.close()'
    new_close = '''  if job:
   try:report['owned_job_final_memory']=query_owned_job_memory(job)
   except BaseException as error:report['owned_job_telemetry_error']=repr(error)
   job.close()'''.replace('\n', newline)
    changes = [('def main():', addition + 'def main():'), (old_sample, new_sample), (old_close, new_close)]
    for before, after in changes:
        need(source.count(before) == 1, 'Exact telemetry edit anchor not unique')
        source = source.replace(before, after, 1)
    derivative = source.encode('utf-8')
    ast.parse(source, filename=str(TARGET))
    reversed_source = source
    for before, after in reversed(changes):
        need(reversed_source.count(after) == 1, 'Telemetry inverse anchor not unique')
        reversed_source = reversed_source.replace(after, before, 1)
    need(reversed_source.encode('utf-8') == original, 'Non-telemetry runner bytes changed')
    need(not TARGET.exists(), 'Fresh runner target already exists; never overwrite evidence')
    TARGET.write_bytes(derivative)

    # Test the actual generated production function with Windows' class-9 API.
    sys.path.insert(0, str(ROOT / 'Tools'))
    spec = importlib.util.spec_from_file_location('compile_jobtelemetry_fixture_target', TARGET)
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    cap = 2048 * 1024**2
    job = module.ChildJob()
    try:
        limit = module.ExtendedJob()
        limit.basic.flags = 0x2000 | 0x200
        limit.job_memory = cap
        need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limit), ctypes.sizeof(limit)), 'Cannot configure empty fixture job')
        result = module.query_owned_job_memory(job)
        need(result == {'configured_job_limit_bytes': cap, 'peak_job_memory_bytes': 0, 'peak_process_memory_bytes': 0, 'configured_limit_flags': 0x2200}, 'Live empty-job telemetry differs from exact configured values')
    finally:
        job.close()
    refused = False
    try:
        module.query_owned_job_memory(job)
    except (OSError, ValueError):
        refused = True
    need(refused, 'Closed-job QueryInformationJobObject must report failure')
    need(BASE.read_bytes() == original, 'Frozen source runner changed')

    out = ROOT / 'Validation' / ('CompileJobTelemetryRunner-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid4().hex[:8])
    out.mkdir()
    patch = ''.join(difflib.unified_diff(original.decode().splitlines(True), source.splitlines(True), fromfile=BASE.name, tofile=TARGET.name))
    (out / 'telemetry-only.patch').write_text(patch, encoding='utf-8', newline='')
    report = {'schema': 'Unity-compile-job-telemetry-derivative/v1', 'status': 'prepared_and_empty_job_api_tested',
        'base': {'path': str(BASE), 'sha256': BASE_SHA},
        'candidate': {'path': str(TARGET), 'sha256': sha_bytes(derivative)},
        'patch': {'path': str(out / 'telemetry-only.patch'), 'sha256': sha_bytes((out / 'telemetry-only.patch').read_bytes())},
        'checks': {'syntax_parses': True, 'inverse_edits_reproduce_every_base_byte': True, 'exact_three_edit_sites': True,
            'job_cap_choices_1792_2048_2560_unchanged': True, 'deadline_600_unchanged': True, 'reserve_1_5_GiB_unchanged': True,
            'input_inventory_hash_and_owned_process_guards_unchanged': True, 'existing_sample_cadence_unchanged': True,
            'sample_and_final_query_class_9_before_job_close': True, 'live_empty_owned_job_limit_and_zero_peaks': True,
            'closed_job_query_refuses': True, 'base_runner_unchanged': True},
        'empty_job_fixture_result': result, 'Unity_launched': False, 'child_process_launched': False,
        'Main_project_changed': False, 'CodeGen_changed': False,
        'notes': ['An initial empty-job fixture caught that QueryInformationJobObject with NULL means the caller job, not an invalid handle; the final candidate rejects a missing owned handle before invoking the API.',
            'Class 9 peaks include all owned processes accumulated over the JobObject lifetime.',
            'PeakProcessMemoryUsed is the highest single-process value, not the concurrent aggregate.',
            'Final query executes before kill-on-close releases the owned job. Final telemetry errors are recorded without replacing the test outcome.']}
    report_path = out / 'report.json'
    report_path.write_text(json.dumps(report, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'status': report['status'], 'report': str(report_path), 'report_sha256': sha_bytes(report_path.read_bytes()), 'candidate': report['candidate']}))

if __name__ == '__main__':
    main()
