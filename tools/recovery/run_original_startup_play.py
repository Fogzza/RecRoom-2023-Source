"""Observe RR23's original startup scene after a passed compile deployment.

Uses an owned Unity2020 Editor, 2.5GiB job limit, 1.5GiB system-commit reserve,
and a 900s import deadline. Temporarily installs only the reviewed observer.
No scenes, game scripts, platform settings, or backend files are rewritten.
"""
import argparse
import ctypes
import datetime as dt
import hashlib
import json
import os
from pathlib import Path
import shutil
import subprocess
import sys
import time
import uuid
from ctypes import wintypes

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
PROJECT = WS / 'RR23'
sys.path.insert(0, str(ROOT / 'Tools'))
from export_bundle_batches import ChildJob, ExtendedJob
from guarded_cpp2il import ProcessMemory, memory
import repair_rr23_wav_headers as safety
import exact_handle_hash

GIB = 1024**3
EDITOR = WS / 'Tools/Editors/2020.3.33f1/Editor/Unity.exe'
CLI = Path(r'C:\Users\andre\AppData\Local\Unity\bin\unity.exe')


def need(value, message):
    if not value:
        raise ValueError(message)


def sha(path):
    return exact_handle_hash.sha(path)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--deployment-receipt', type=Path, required=True)
    parser.add_argument('--observer-preparation', type=Path, required=True)
    args = parser.parse_args()
    receipt = args.deployment_receipt.resolve(strict=True)
    observer_proof = args.observer_preparation.resolve(strict=True)
    need(receipt.is_relative_to(ROOT / 'CompilerRepairs') and receipt.parent.name.startswith('AppliedCompilePackage-'), 'Exact compile deployment receipt required')
    deployed = json.loads(receipt.read_bytes())
    need(deployed['status'] == 'applied' and deployed['project_modified'], 'Repairs must be applied after actual Unity loading passed')
    manifest = Path(deployed['manifest']).resolve(strict=True)
    need(manifest.is_relative_to(ROOT / 'CompilerRepairs') and sha(manifest) == deployed['manifest_sha256'], 'Deployment proof drift')
    plan = json.loads(manifest.read_bytes())
    need(Path(plan['project']) == PROJECT and plan['shipping_supported'] is False, 'Exact nonshipping RR23 compile package required')
    for gate in plan['integration_gates']:
        path = Path(gate['path']).resolve(strict=True)
        need(path.is_relative_to(ROOT) and sha(path) == gate['sha256'], 'Integration proof changed')
        data = json.loads(path.read_bytes())
        for check in gate['checks']:
            value = data
            for key in check['selector']:
                value = value[key]
            need(value == check['equals'], 'An integration gate no longer passes')
    for row in deployed['records']:
        target = Path(row['target']).resolve(strict=True)
        need(target.is_relative_to(PROJECT) and sha(target) == row['candidate_sha256'], 'Deployed compile input changed')
    for row in plan['unmodified_project_inputs']:
        target = Path(row['path']).resolve(strict=True)
        need(target.is_relative_to(PROJECT) and sha(target) == row['sha256'], 'Unmodified compile input changed')
    need(observer_proof.is_relative_to(ROOT / 'Validation'), 'Outside-project observer preparation required')
    preparation = json.loads(observer_proof.read_bytes())
    need(preparation['status'] == 'compile_checked_not_installed_or_run', 'Observer must compile in matching Editor')
    for row in preparation['inputs']:
        need(sha(Path(row['path'])) == row['sha256'], 'Observer source or matching compiler changed')
    source = HERE / 'VerifyOriginalStartupPlay.cs'
    need(any(Path(row['path']) == source for row in preparation['inputs']), 'Exact observer not checked')
    safety.assert_editor_closed()
    safety.assert_no_reparse(PROJECT)
    cap, reserve = int(2.5 * GIB), int(1.5 * GIB)
    need(memory().available_commit >= cap + reserve and shutil.disk_usage(PROJECT).free > 4 * GIB, 'Insufficient guarded Play test resources')
    stamp = dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]
    out = ROOT / 'Validation' / ('OriginalStartupPlay-' + stamp)
    out.mkdir()
    scene = PROJECT / 'Assets/Core/Scenes/main_root.unity'
    preserved = [p for p in (PROJECT / 'ProjectSettings').rglob('*') if p.is_file()]
    preserved += list((PROJECT / 'Assets').rglob('*.unity'))
    hashes = {str(p): sha(p) for p in preserved}
    (out / 'preserved-scene-and-settings-hashes.json').write_text(json.dumps(hashes, indent=2) + '\n')
    target_dir = PROJECT / 'Assets/Editor/StartupPlayObservation'
    target = target_dir / source.name
    need(not target_dir.exists() and not target_dir.with_suffix('.meta').exists(), 'Fresh temporary observer folder required')
    meta = target.with_suffix('.cs.meta')
    helper_guid = uuid.uuid4().hex
    meta_bytes = ('fileFormatVersion: 2\nguid: ' + helper_guid + '\nMonoImporter:\n  externalObjects: {}\n  serializedVersion: 2\n  defaultReferences: []\n  executionOrder: 0\n  icon: {instanceID: 0}\n  userData: \n  assetBundleName: \n  assetBundleVariant: \n').encode('utf-8')
    target_hash, meta_hash = sha(source), hashlib.sha256(meta_bytes).hexdigest()
    created_dir = False
    report = {'schema': 'guarded-original-RR23-startup-Play-test/v1', 'status': 'starting',
              'project': str(PROJECT), 'deployment_receipt': str(receipt), 'deployment_receipt_sha256': sha(receipt),
              'observer_preparation': str(observer_proof), 'observer_preparation_sha256': sha(observer_proof),
              'maximum_job_bytes': cap, 'minimum_commit_bytes': reserve, 'maximum_seconds': 900,
              'started_utc': dt.datetime.now(dt.timezone.utc).isoformat(), 'samples': [],
              'gameplay_verified': False, 'login_verified': False, 'dorm_verified': False}
    log, observation = out / 'Editor.log', out / 'play-observation.json'
    job = child = handle = None
    started = time.monotonic()
    kernel = ctypes.WinDLL('kernel32', use_last_error=True)
    kernel.OpenProcess.argtypes = [wintypes.DWORD, wintypes.BOOL, wintypes.DWORD]
    kernel.OpenProcess.restype = wintypes.HANDLE
    kernel.CloseHandle.argtypes = [wintypes.HANDLE]
    kernel.GetExitCodeProcess.argtypes = [wintypes.HANDLE, ctypes.POINTER(wintypes.DWORD)]
    kernel.GetExitCodeProcess.restype = wintypes.BOOL
    kernel.IsProcessInJob.argtypes = [wintypes.HANDLE, wintypes.HANDLE, ctypes.POINTER(wintypes.BOOL)]
    kernel.IsProcessInJob.restype = wintypes.BOOL
    kernel.WaitForSingleObject.argtypes = [wintypes.HANDLE, wintypes.DWORD]
    kernel.WaitForSingleObject.restype = wintypes.DWORD
    api = ctypes.WinDLL('psapi', use_last_error=True).GetProcessMemoryInfo
    api.argtypes = [wintypes.HANDLE, ctypes.POINTER(ProcessMemory), wintypes.DWORD]
    api.restype = wintypes.BOOL
    try:
        target_dir.mkdir(); created_dir = True
        with meta.open('xb') as stream:
            stream.write(meta_bytes)
        shutil.copyfile(source, target)
        need(sha(target) == target_hash and sha(meta) == meta_hash, 'Temporary helper copy changed')
        need(memory().available_commit >= cap + reserve and shutil.disk_usage(PROJECT).free > 4 * GIB, 'Fresh launch memory/disk admission failed')
        safety.assert_editor_closed()
        job = ChildJob()
        limits = ExtendedJob(); limits.basic.flags = 0x2000 | 0x200; limits.job_memory = cap
        need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), 'Cannot guard owned Play test job')
        extra = subprocess.list2cmdline(['-batchmode', '-nographics', '-disable-assembly-updater', '-job-worker-count', '1',
            '-openfile', str(scene), '-executeMethod', 'VerifyOriginalStartupPlay.Run',
            '-recoveryPlayProbeOutput', str(observation), '-logFile', str(log)])
        command = [str(CLI), 'open', str(PROJECT), '--editor-path', str(EDITOR), '--args', extra, '--format', 'json']
        with (out / 'cli-output.json').open('xb') as stdout, (out / 'cli-error.log').open('xb') as stderr:
            child = subprocess.Popen(command, stdout=stdout, stderr=stderr, cwd=PROJECT, creationflags=subprocess.CREATE_NO_WINDOW)
            job.attach(child)
            while child.poll() is None:
                need(time.monotonic() - started < 30 and memory().available_commit >= reserve, 'CLI launch resource/time guard')
                time.sleep(.1)
        cli = json.loads((out / 'cli-output.json').read_text(encoding='utf-8-sig'))
        need(child.returncode == 0 and cli['success'] and Path(cli['data']['projectPath']).resolve() == PROJECT
             and Path(cli['data']['editorPath']).resolve() == EDITOR, 'Official CLI launched unexpected Editor/project')
        pid = int(cli['data']['launchedPid']); report['owned_editor_pid'] = pid
        handle = kernel.OpenProcess(0x100000 | 0x1000 | 0x0010 | 0x0100 | 0x0001, False, pid)
        need(bool(handle), 'Cannot observe owned Editor')
        in_job = wintypes.BOOL()
        need(kernel.IsProcessInJob(handle, job.handle, ctypes.byref(in_job)), 'Cannot verify owned Editor job')
        if not in_job.value:
            need(job.kernel.AssignProcessToJobObject(job.handle, handle), 'Cannot attach owned Editor to guard')
        next_sample = 0
        while True:
            exit_code = wintypes.DWORD()
            need(kernel.GetExitCodeProcess(handle, ctypes.byref(exit_code)), 'Cannot query owned Editor')
            if exit_code.value != 259:
                report['exit_code'] = exit_code.value
                break
            elapsed = time.monotonic() - started
            need(elapsed <= 900 and memory().available_commit >= reserve and shutil.disk_usage(PROJECT).free > 4 * GIB, 'Play test time/memory/disk guard reached')
            if elapsed >= next_sample:
                info = ProcessMemory(); info.cb = ctypes.sizeof(info)
                need(api(handle, ctypes.byref(info), info.cb), 'Cannot query owned Editor memory')
                sample = {'seconds': round(elapsed, 2), 'editor_private_bytes': info.PrivateUsage, 'available_commit': memory().available_commit}
                report['samples'].append(sample)
                (out / 'run-report.json').write_text(json.dumps(report, indent=2) + '\n')
                print(json.dumps({'status': 'observing_original_startup', **sample}), flush=True)
                next_sample = elapsed + 10
            time.sleep(.25)
        result = json.loads(observation.read_bytes()) if observation.exists() else None
        report['observation'] = result
        passed = result is not None and report['exit_code'] == 0 and result['status'] == 'Play_mode_frames_advanced_startup_flow_unverified'
        passed = passed and result['enteredPlayMode'] and result['returnedToEditMode'] and result['observedSeconds'] >= 10
        passed = passed and result['lastFrame'] - result['firstFrame'] >= 10 and result['restoredRunInBackground']
        passed = passed and result['errorCount'] == result['exceptionCount'] == result['assertionCount'] == 0
        report['status'] = 'Play_mode_frames_verified_gameplay_unverified' if passed else 'failed'
    except BaseException as error:
        report.update(status='stopped', error=repr(error))
    finally:
        # Persist the outcome even when cleanup must refuse an independently changed file.
        (out / 'run-report.json').write_text(json.dumps(report, indent=2) + '\n')
        try:
            if job:
                job.close()
            if child is not None and child.poll() is None:
                child.kill(); child.wait(timeout=10)
            if handle:
                need(kernel.WaitForSingleObject(handle, 10000) == 0, 'Owned Editor did not exit after job closure')
            safety.assert_editor_closed()
            for path, expected in ((target, target_hash), (meta, meta_hash)):
                if path.exists():
                    safety.assert_no_reparse(path)
                    need(sha(path) == expected, 'Temporary observer changed; preserved for review')
                    path.unlink()
            if created_dir:
                target_dir.rmdir()  # Empty directory only; never remove an unknown child.
                folder_meta = target_dir.with_suffix('.meta')
                if folder_meta.exists():
                    safety.assert_no_reparse(folder_meta)
                    need(b'folderAsset: yes' in folder_meta.read_bytes(), 'Unexpected temporary folder metadata; preserved')
                    folder_meta.unlink()
            report['temporary_observer_removed'] = True
            current_paths = {str(p) for p in (PROJECT / 'ProjectSettings').rglob('*') if p.is_file()}
            current_paths.update(str(p) for p in (PROJECT / 'Assets').rglob('*.unity'))
            report['original_scenes_and_settings_unchanged'] = current_paths == set(hashes) and all(Path(p).is_file() and sha(Path(p)) == h for p, h in hashes.items())
            if not report['original_scenes_and_settings_unchanged']:
                report['status'] = 'original_scene_or_setting_changed_requires_review'
        except BaseException as cleanup_error:
            report.update(status='cleanup_blocked_requires_review', cleanup_error=repr(cleanup_error), temporary_observer_removed=False)
        finally:
            if handle:
                kernel.CloseHandle(handle)
        report['seconds'] = round(time.monotonic() - started, 2)
        report['finished_utc'] = dt.datetime.now(dt.timezone.utc).isoformat()
        (out / 'run-report.json').write_text(json.dumps(report, indent=2) + '\n')
        print(json.dumps({'status': report['status'], 'report': str(out / 'run-report.json')}), flush=True)
    return 0 if report['status'] == 'Play_mode_frames_verified_gameplay_unverified' else 1


if __name__ == '__main__':
    raise SystemExit(main())
