"""Fresh empty-project legacy Editor probe; no activation or license-file edits."""
import argparse
import ctypes
import json
import shutil
import subprocess
import sys
import time
import uuid
from ctypes import wintypes
from datetime import datetime, timezone
from pathlib import Path
import run_sdk_runtime_fixture_strict as s

SOURCE = '''using System.IO;
using UnityEngine;
using UnityEditor;
public static class SolarNetLicenseProbe {
 public static void Run() {
  if (Application.unityVersion != "2020.3.33f1" || EditorApplication.isPlaying) throw new System.InvalidOperationException("Unexpected Editor or Play state");
  File.WriteAllText("license-probe-result.txt", "SolarNetLicenseProbe:2020.3.33f1:NoPlay");
  Debug.Log("SOLARNET_UNITY2020_LICENSE_EXECUTION_PROBE_OK");
 }
}
'''


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--run', action='store_true')
    args = parser.parse_args()
    stamp = datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]
    out = s.ROOT / 'Validation' / ('RefreshedUnity2020LicenseProbe-' + stamp)
    project = out / 'Project'
    for relative in ('Assets/Editor', 'Packages', 'ProjectSettings'):
        (project / relative).mkdir(parents=True)
    (project / 'Assets/Editor/SolarNetLicenseProbe.cs').write_text(SOURCE)
    (project / 'Packages/manifest.json').write_text('{"dependencies":{}}\n')
    (project / 'ProjectSettings/ProjectVersion.txt').write_text('m_EditorVersion: 2020.3.33f1\nm_EditorVersionWithRevision: 2020.3.33f1 (915a7af8b0d5)\n')
    report = {'schema': 'refreshed-matching-Unity2020-empty-license-marker-probe/v1', 'status': 'prepared_not_launched',
              'project': str(project), 'tool_sha256': s.sha(Path(__file__)), 'editor': str(s.EDITOR),
              'inputs': [{'path': str(p), 'sha256': s.sha(p)} for p in sorted(project.rglob('*')) if p.is_file()],
              'game_or_SDK_code_or_assets_included': False, 'PlayMode': False, 'main_RR23_changed': False,
              'activation_or_license_files_changed_by_probe': False, 'maximum_owned_job_bytes': 512 * 1024 ** 2,
              'minimum_system_commit_bytes': int(1.5 * s.GIB), 'maximum_seconds': 120, 'samples': []}
    if not args.run:
        (out / 'report.json').write_text(json.dumps(report, indent=2) + '\n')
        print(json.dumps({'status': report['status'], 'report': str(out / 'report.json')}))
        return 0
    s.safety.assert_editor_closed()
    s.need(s.memory().available_commit >= report['maximum_owned_job_bytes'] + report['minimum_system_commit_bytes'] and shutil.disk_usage(project).free >= 4 * s.GIB, 'License probe resource admission refused')
    kernel = ctypes.WinDLL('kernel32', use_last_error=True)
    kernel.OpenProcess.argtypes = [wintypes.DWORD, wintypes.BOOL, wintypes.DWORD]; kernel.OpenProcess.restype = wintypes.HANDLE
    kernel.GetExitCodeProcess.argtypes = [wintypes.HANDLE, ctypes.POINTER(wintypes.DWORD)]; kernel.GetExitCodeProcess.restype = wintypes.BOOL
    kernel.IsProcessInJob.argtypes = [wintypes.HANDLE, wintypes.HANDLE, ctypes.POINTER(wintypes.BOOL)]; kernel.IsProcessInJob.restype = wintypes.BOOL
    kernel.TerminateProcess.argtypes = [wintypes.HANDLE, wintypes.UINT]; kernel.CloseHandle.argtypes = [wintypes.HANDLE]
    api = ctypes.WinDLL('psapi', use_last_error=True).GetProcessMemoryInfo
    api.argtypes = [wintypes.HANDLE, ctypes.POINTER(s.ProcessMemory), wintypes.DWORD]; api.restype = wintypes.BOOL
    started = time.monotonic(); job = None; handle = None; launch = None; log = out / 'Editor.log'
    try:
        job = s.ChildJob(); limits = s.ExtendedJob(); limits.basic.flags = 0x2000 | 0x200; limits.job_memory = report['maximum_owned_job_bytes']
        s.need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), 'Cannot cap license probe job')
        extra = subprocess.list2cmdline(['-batchmode', '-nographics', '-disable-assembly-updater', '-job-worker-count', '1', '-executeMethod', 'SolarNetLicenseProbe.Run', '-logFile', str(log), '-quit'])
        command = [str(s.CLI), 'open', str(project), '--editor-path', str(s.EDITOR), '--args', extra, '--format', 'json']
        report['command'] = command
        stdout = out / 'cli-stdout.json'; stderr = out / 'cli-stderr.log'
        with stdout.open('xb') as output, stderr.open('xb') as errors:
            launch = subprocess.Popen(command, cwd=project, stdout=output, stderr=errors, creationflags=subprocess.CREATE_NO_WINDOW)
            report['owned_cli_pid'] = launch.pid; job.attach(launch)
            while launch.poll() is None:
                s.need(time.monotonic() - started < 30 and s.memory().available_commit >= report['minimum_system_commit_bytes'], 'License probe CLI launch guard')
                time.sleep(.1)
        s.need(stdout.stat().st_size <= 262144, 'Oversized CLI response')
        data = json.loads(stdout.read_text(encoding='utf-8-sig'))
        s.need(launch.returncode == 0 and data['success'], 'Official CLI open failed')
        data = data['data']
        s.need(Path(data['projectPath']).resolve() == project and Path(data['editorPath']).resolve() == s.EDITOR.resolve(), 'CLI returned different Editor/project')
        pid = int(data['launchedPid']); report['owned_editor_pid'] = pid
        handle = kernel.OpenProcess(0x1000 | 0x0010 | 0x0100 | 0x0001, False, pid)
        s.need(bool(handle), 'Cannot guard license probe Editor')
        contained = wintypes.BOOL(); s.need(kernel.IsProcessInJob(handle, job.handle, ctypes.byref(contained)), 'Cannot inspect license job membership')
        if not contained.value:
            s.need(job.kernel.AssignProcessToJobObject(job.handle, handle), 'Cannot assign license probe job')
        next_sample = 0
        while True:
            code = wintypes.DWORD(); s.need(kernel.GetExitCodeProcess(handle, ctypes.byref(code)), 'Cannot inspect license Editor')
            if code.value != 259:
                report['exit_code'] = code.value
                break
            elapsed = time.monotonic() - started; available = s.memory().available_commit
            s.need(elapsed <= 120 and available >= report['minimum_system_commit_bytes'] and shutil.disk_usage(project).free >= 4 * s.GIB, 'License probe time/system reserve/disk guard')
            state = s.ProcessMemory(); state.cb = ctypes.sizeof(state); s.need(api(handle, ctypes.byref(state), state.cb), 'Cannot inspect license probe private usage')
            if elapsed >= next_sample:
                sample = {'seconds': round(elapsed, 2), 'private_bytes': state.PrivateUsage, 'available_commit_bytes': available}
                report['samples'].append(sample); print(json.dumps(sample), flush=True); next_sample = elapsed + 10
            time.sleep(.25)
        text = log.read_text(encoding='utf-8-sig', errors='replace') if log.exists() else ''
        result = project / 'license-probe-result.txt'
        valid = result.exists() and result.read_text() == 'SolarNetLicenseProbe:2020.3.33f1:NoPlay'
        report['trusted_Editor_probe_executed'] = valid
        report['license_failure_message_detected'] = any(x in text for x in ('Machine identification is invalid for current license', 'Current license is invalid and cannot be activated', 'BatchMode: Unity has not been activated with a valid License'))
        report['status'] = 'passed_matching_Editor_executed_trusted_probe' if report['exit_code'] == 0 and valid and not report['license_failure_message_detected'] and 'SOLARNET_UNITY2020_LICENSE_EXECUTION_PROBE_OK' in text else 'failed_matching_Editor_license_or_probe'
    except BaseException as error:
        report.update(status='stopped', error=repr(error))
    finally:
        if job:
            job.close()
        if launch is not None and launch.poll() is None:
            launch.kill(); launch.wait(timeout=10)
        if handle:
            code = wintypes.DWORD()
            if kernel.GetExitCodeProcess(handle, ctypes.byref(code)) and code.value == 259:
                kernel.TerminateProcess(handle, 137); report['owned_editor_stopped'] = True
            kernel.CloseHandle(handle)
        report['seconds'] = round(time.monotonic() - started, 2)
        report['artifacts'] = [{'path': str(x), 'sha256': s.sha(x)} for x in (log, out / 'cli-stdout.json', out / 'cli-stderr.log', project / 'license-probe-result.txt') if x.exists()]
        (out / 'report.json').write_text(json.dumps(report, indent=2) + '\n')
        print(json.dumps({'status': report['status'], 'report': str(out / 'report.json'), 'error': report.get('error')}), flush=True)
    return 0 if report['status'] == 'passed_matching_Editor_executed_trusted_probe' else 1


if __name__ == '__main__':
    raise SystemExit(main())
