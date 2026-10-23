"""Review by default; explicit switches alone can launch this isolated fixture."""
from pathlib import Path
import argparse
import ctypes
import datetime as dt
import hashlib
import json
import os
import re
import shlex
import shutil
import subprocess
import sys
import time
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
sys.path.insert(0, str(ROOT / 'Tools'))
from export_bundle_batches import ChildJob, ExtendedJob
from guarded_cpp2il import memory
import repair_rr23_wav_headers as safety
from owned_suspended_launch import launch_suspended_in_job

GIB = 1024**3
RESERVE = int(1.5 * GIB)
EDITOR = WS / 'Tools/Editors/2020.3.33f1/Editor/Unity.exe'
CLI = Path('C:/Users/andre/AppData/Local/Unity/bin/unity.exe')
WITNESS = 'RR23.WindowsDevelopment.DefineWitness'
REQUIRED = {'UNITY_STANDALONE_WIN', 'UNITY_64', 'ENABLE_MONO', 'DEVELOPMENT_BUILD'}
FORBIDDEN = {'UNITY_EDITOR', 'ENABLE_IL2CPP'}


def need(value, message):
    if not value:
        raise RuntimeError(message)


def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()


def checked(row):
    path = Path(row['path'])
    safety.assert_no_reparse(path)
    need(path.is_file() and sha(path) == row['sha256'], 'Pinned input changed: ' + str(path))


def admission(project, cap):
    safety.assert_no_reparse(project)
    safety.assert_editor_closed()
    need(memory().available_commit >= cap + RESERVE, 'Owned cap plus 1.5GiB commit reserve admission refused')
    need(shutil.disk_usage(project).free >= 4 * GIB, '4GiB disk reserve refused')


def make_job(cap):
    job = ChildJob()
    limits = ExtendedJob()
    limits.basic.flags = 0x2000 | 0x200
    limits.job_memory = cap
    if not job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)):
        job.close()
        raise ctypes.WinError(ctypes.get_last_error())
    return job


def save(out, report):
    (out / 'run-report.json').write_text(json.dumps(report, indent=2) + '\n', encoding='utf-8')


def bounded(command, project, out, name, cap, timeout, report, env=None):
    admission(project, cap)
    row = {'phase': name, 'command': command, 'cap_bytes': cap, 'reserve_bytes': RESERVE,
           'maximum_seconds': timeout, 'samples': []}
    report['phases'].append(row)
    job, child = make_job(cap), None
    started = time.monotonic()
    try:
        with (out / (name + '-stdout.log')).open('xb') as stdout, (out / (name + '-stderr.log')).open('xb') as stderr:
            child, evidence = launch_suspended_in_job(command, job=job, cwd=project, stdout=stdout, stderr=stderr, env=env)
            row['launcher'] = evidence
            need(evidence['membership_verified_before_resume'] and evidence['resume_previous_suspend_count'] == 1,
                 'Assign-before-resume evidence required')
            next_sample = 0
            while child.poll() is None:
                elapsed, free = time.monotonic() - started, memory().available_commit
                need(elapsed <= timeout and free >= RESERVE and shutil.disk_usage(project).free >= 4 * GIB,
                     'Owned process memory/time/disk guard')
                if elapsed >= next_sample:
                    info = ExtendedJob()
                    query = job.kernel.QueryInformationJobObject
                    query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_uint32, ctypes.c_void_p]
                    query.restype = ctypes.c_int
                    need(query(job.handle, 9, ctypes.byref(info), ctypes.sizeof(info), None), 'Cannot query owned job memory')
                    row['samples'].append({'seconds': round(elapsed, 2), 'available_commit_bytes': free,
                                           'peak_job_bytes': int(info.peak_job), 'peak_process_bytes': int(info.peak_process)})
                    save(out, report)
                    next_sample = elapsed + 5
                time.sleep(.1)
        row['exit_code'] = child.returncode
        need(child.returncode == 0, name + ' failed; see retained process logs')
    except BaseException as error:
        if hasattr(error, 'evidence'):
            row['failed_launcher'] = error.evidence
        raise
    finally:
        job.close()
        if child is not None:
            row['owned_cli_or_compiler_exit_confirmed'] = child.wait(timeout=10) is not None
        # No child process of this owned job may outlive its closed kill-on-close job.
        for retry in range(41):
            try:
                safety.assert_editor_closed()
                row['Editor_closed_after_job'] = True
                break
            except RuntimeError:
                if retry == 40:
                    raise
                time.sleep(.25)
        row['seconds'] = round(time.monotonic() - started, 3)
        save(out, report)


def compile_sources(plan, project, out, report):
    for check in plan['compile_checks']:
        target = out / (check['name'] + '-compile.dll')
        command = [Path(plan['compiler']['path']).as_posix(), '@' + Path(check['response']['path']).as_posix(), '/out:' + target.as_posix()]
        bounded(command, project, out, check['name'] + '-compile', 256 * 1024**2, 30, report)
        need(target.is_file(), 'Matching compiler produced no fixture assembly')
        report['phases'][-1]['output_sha256'] = sha(target)


def genuine_build(plan, project, out, report):
    records = out / 'ILPPRecords'
    records.mkdir()
    result = out / 'build-report.json'
    player = out / 'Player/DefineProbe.exe'
    player.parent.mkdir()
    log = out / 'Editor.log'
    # unity build owns batchmode/quit/nographics. Its --args uses shell splitting.
    extra = shlex.join(['-disable-assembly-updater', '-job-worker-count', '1',
                        '-defineProbeReport', result.as_posix(), '-defineProbeProject', project.as_posix()])
    command = [CLI.as_posix(), 'build', project.as_posix(), '--target', 'StandaloneWindows64',
               '--execute-method', 'WindowsDevelopmentDefineProbe.Run', '--output-path', player.as_posix(),
               '--editor-path', EDITOR.as_posix(), '--args', extra, '--timeout', '300', '--allow-dirty-build',
               '--no-tail', '--no-accelerator', '--log-file', log.as_posix(),
               '--provenance-path', (out / 'provenance.json').as_posix(), '--format', 'json']
    env = dict(os.environ)
    env['RR23_DEFINE_PROBE_RECORD_DIRECTORY'] = records.as_posix()
    bounded(command, project, out, 'genuine-development-build', GIB, 300, report, env=env)
    need(result.is_file() and player.is_file(), 'Genuine fixture build result or player absent')
    built = json.loads(result.read_bytes())
    report['build_result'] = built
    need(built['status'] == 'Succeeded' and built['total_errors'] == 0 and built['unity_version'] == '2020.3.33f1'
         and built['backend'] == 'Mono2x' and built['target'] == 'StandaloneWindows64' and built['development']
         and 'Development' in built['build_options'] and 'StrictMode' in built['build_options'], 'Matching genuine development build refused')
    ilpp = []
    for path in sorted(records.glob('*.json')):
        need(path.stat().st_size <= 128 * 1024, 'Bounded ILPP record required')
        record = json.loads(path.read_bytes())
        need(record['schema'] == 'genuine-unity-ilpp-assembly-defines/v1' and record['assembly_name'] == WITNESS
             and record['returned_original_in_memory_assembly'] and not record['metadata_mutated'], 'Unexpected ILPP observation')
        ilpp.append({'path': str(path), 'sha256': sha(path), 'observation': record})
    player_records = [r for r in ilpp if 'UNITY_EDITOR' not in r['observation']['defines']]
    need(player_records, 'No genuine player ICompiledAssembly.Defines record; scope remains unproved')
    sets = [set(r['observation']['defines']) for r in player_records]
    need(all(REQUIRED <= symbols and not FORBIDDEN & symbols for symbols in sets), 'Player symbols do not meet reviewed Windows64 Mono Development scope')
    need(all(symbols == sets[0] for symbols in sets), 'Actual player ILPP defines disagree')
    pipeline = built['player_assemblies']
    need(len(pipeline) == 1 and pipeline[0]['name'] == WITNESS, 'CompilationPipeline witness absent')
    report['actual_player_ilpp_defines'] = sorted(sets[0])
    report['pipeline_defines_equal_actual_ilpp'] = set(pipeline[0]['defines']) == sets[0]
    report['ilpp_records'] = ilpp
    report['build_report_sha256'] = sha(result)
    report['player_sha256'] = sha(player)
    need(log.is_file(), 'Full Editor log absent')
    diagnostics = re.findall(r'(?im)^.*(?:error CS\d+|Fatal error|Aborting batchmode due to|Define observation failed:).*$', log.read_text(encoding='utf-8', errors='replace'))
    report['failure_log_lines'] = diagnostics[:32]
    need(not diagnostics, 'Editor log contains compile/observer failure')


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--fixture', type=Path, required=True)
    parser.add_argument('--compile-only', action='store_true')
    parser.add_argument('--run', action='store_true')
    args = parser.parse_args()
    need(not (args.compile_only and args.run), 'Choose compile-only or run')
    safety.assert_no_reparse(args.fixture)
    fixture = args.fixture.resolve(strict=True)
    need(fixture.is_relative_to(ROOT / 'AssetRecovery') and fixture.name.startswith('WindowsDevelopmentDefineProbe-'), 'Exact isolated fixture required')
    plan_path = fixture / 'plan.json'
    plan = json.loads(plan_path.read_bytes())
    project = Path(plan['project']).resolve(strict=True)
    need(plan['schema'] == 'prepared-unity2020-windows64-development-defines/v1' and project == fixture / 'Project', 'Unexpected fixture shape')
    need(Path(plan['editor']['path']) == EDITOR and Path(plan['cli']['path']) == CLI, 'Exact matching Editor/official CLI required')
    pinned = [plan[key] for key in ('runner', 'launcher', 'preparer', 'editor', 'cli', 'compiler')]
    pinned += plan['inputs'] + plan['read_only_sources'] + plan['primary_api_documentation']
    for check in plan['compile_checks']:
        pinned += [check['source'], check['response']] + check['references']
    for row in pinned:
        checked(row)
    allowed = {Path(r['path']).resolve() for r in plan['inputs']}
    for path in (project / 'Assets').rglob('*'):
        safety.assert_no_reparse(path)
        if path.is_file():
            need(path.resolve() in allowed, 'Unexpected fixture asset: ' + str(path))
    need(not (project / 'Library').exists() and not (project / 'Temp').exists(), 'Fresh never-launched project required')
    if not args.compile_only and not args.run:
        print(json.dumps({'status': 'prepared_verified_no_launch', 'plan': str(plan_path), 'plan_sha256': sha(plan_path),
                          'Editor_launched': False, 'compiler_launched': False, 'owned_job_created': False}))
        return 0
    out = fixture / ('Run-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {'schema': 'guarded-unity2020-windows64-development-define-probe/v1', 'status': 'starting',
              'plan_sha256': sha(plan_path), 'fixture': str(fixture), 'phases': [],
              'Main_modified': False, 'SDK_launched': False, 'player_launched': False, 'metadata_mutated': False}
    try:
        compile_sources(plan, project, out, report)
        if args.compile_only:
            report['status'] = 'matching_source_compiled_Editor_not_launched'
        else:
            genuine_build(plan, project, out, report)
            report['status'] = 'genuine_windows64_mono_development_defines_proved'
    except BaseException as error:
        report.update(status='failed_or_guard_refused', error=repr(error))
    finally:
        report['finished_utc'] = dt.datetime.now(dt.timezone.utc).isoformat()
        save(out, report)
        print(json.dumps({'status': report['status'], 'report': str(out / 'run-report.json'), 'error': report.get('error')}))
    return 0 if report['status'] in ('matching_source_compiled_Editor_not_launched', 'genuine_windows64_mono_development_defines_proved') else 1


if __name__ == '__main__':
    raise SystemExit(main())
