"""Build all original enabled RR23 scenes with owned-process and memory bounds."""
import argparse
import ctypes
import hashlib
import json
from pathlib import Path
import shlex
import shutil
import subprocess
import sys
import time
import uuid
from datetime import datetime, timezone

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
PROJECT = WS / 'RR23'
sys.path.insert(0, str(ROOT / 'Tools'))
from export_bundle_batches import ChildJob, ExtendedJob
from guarded_cpp2il import memory
import repair_rr23_wav_headers as safety
from owned_suspended_launch import launch_suspended_in_job

CLI = Path(r'C:\Users\andre\AppData\Local\Unity\bin\unity.exe')
EDITOR = WS / 'Tools/Editors/2020.3.33f1/Editor/Unity.exe'
GIB = 1024**3

def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()

def need(value, message):
    if not value:
        raise ValueError(message)

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--runtime-receipt', type=Path, required=True)
    parser.add_argument('--job-cap-mib', type=int, choices=(2048, 2560, 3072, 4096, 6144), default=2560)
    args = parser.parse_args()
    receipt = args.runtime_receipt.resolve(strict=True)
    need(receipt.is_relative_to(ROOT / 'Validation'), 'Original runtime install receipt required')
    installed = json.loads(receipt.read_bytes())
    need(installed['status'] == 'applied' and installed['final_all_original_runtime_SHA_verified'] and installed['files'] == 6524, 'Complete original runtime content must be installed')
    safety.assert_editor_closed()
    safety.assert_no_reparse(PROJECT)
    cap, reserve = args.job_cap_mib * 1024**2, int(1.5 * GIB)
    available = memory().available_commit
    need(available > cap + reserve, 'Build admission needs %.2f GiB; available %.2f GiB' % ((cap+reserve)/GIB, available/GIB))
    need(shutil.disk_usage(PROJECT).free > 20 * GIB, 'Build needs original output/staging plus disk reserve')
    stamp = datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]
    out = ROOT / 'Validation' / ('FullWindowsBuild-' + stamp)
    out.mkdir()
    player_dir = WS / 'Builds' / ('SolarNet-PC-' + stamp)
    safety.assert_no_reparse(player_dir)
    player_dir.mkdir(parents=True)
    player = player_dir / 'SolarNet.exe'
    preserved = [p for p in (PROJECT / 'ProjectSettings').rglob('*') if p.is_file()]
    preserved += list((PROJECT / 'Assets').rglob('*.unity'))
    hashes = {str(p): sha(p) for p in preserved}
    (out / 'original-scene-and-settings-hashes.json').write_text(json.dumps(hashes, indent=2)+'\n')
    for path in preserved:
        if path.is_relative_to(PROJECT / 'ProjectSettings'):
            backup = out / 'OriginalProjectSettings' / path.relative_to(PROJECT / 'ProjectSettings')
            backup.parent.mkdir(parents=True, exist_ok=True)
            shutil.copyfile(path, backup)
            need(sha(backup) == hashes[str(path)], 'Build settings backup differs')
    helper = HERE / 'BuildRecoveredWindows.cs'
    temporary = PROJECT / 'Assets/Editor/RecoveryBuildSupport'
    folder_meta = temporary.with_suffix('.meta')
    need(not temporary.exists() and not folder_meta.exists(), 'Temporary build helper already exists; preserve and inspect it')
    target = temporary / helper.name
    target_meta = target.with_suffix('.cs.meta')
    owned = {}
    report = {'schema': 'full-original-RR23-Windows-build-run/v1', 'status': 'starting', 'project': str(PROJECT), 'output': str(player), 'runtime_content_receipt': {'path': str(receipt), 'sha256': sha(receipt)}, 'helper_source': {'path': str(helper), 'sha256': sha(helper)}, 'job_cap_bytes': cap, 'minimum_available_commit_bytes': reserve, 'maximum_seconds': 1800, 'gameplay_verified': False, 'login_verified': False, 'dorm_verified': False, 'samples': []}
    def save():
        (out / 'run-report.json').write_text(json.dumps(report, indent=2)+'\n')
    save()
    child = job = None
    started = time.monotonic()
    try:
        temporary.mkdir()
        contents = {
            target: helper.read_bytes(),
            target_meta: ('fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\nMonoImporter:\n  externalObjects: {}\n  serializedVersion: 2\n  defaultReferences: []\n  executionOrder: 0\n  icon: {instanceID: 0}\n  userData: \n  assetBundleName: \n  assetBundleVariant: \n').encode(),
            folder_meta: ('fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\nfolderAsset: yes\nDefaultImporter:\n  externalObjects: {}\n  userData: \n  assetBundleName: \n  assetBundleVariant: \n').encode()
        }
        for path, data in contents.items():
            with path.open('xb') as stream:
                stream.write(data)
            owned[path] = hashlib.sha256(data).hexdigest()
        safety.assert_editor_closed()
        need(memory().available_commit > cap + reserve, 'Fresh build memory admission failed')
        job = ChildJob()
        limits = ExtendedJob()
        limits.basic.flags = 0x2000 | 0x200
        limits.job_memory = cap
        need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), 'Cannot cap owned build job')
        # The build command owns -nographics; forwarding it is rejected by the CLI.
        # --args uses shell splitting, not Windows CommandLineToArgvW. Forward
        # slashes also keep Windows paths intact through the CLI's tokenizer.
        extra = shlex.join(['-disable-assembly-updater', '-job-worker-count', '1', '-recoveryBuildReport', (out / 'build-report.json').as_posix(), '-recoveryBuildVersion', '20261022'])
        command = [str(CLI), 'build', str(PROJECT), '--target', 'StandaloneWindows64', '--execute-method', 'BuildRecoveredWindows.Run', '--output-path', str(player), '--editor-path', str(EDITOR), '--args', extra, '--timeout', '1800', '--allow-dirty-build', '--no-tail', '--log-file', str(out / 'Editor.log'), '--provenance-path', str(out / 'provenance.json'), '--format', 'json']
        (out / 'command.json').write_text(json.dumps(command, indent=2)+'\n')
        with (out / 'cli-output.json').open('xb') as stdout, (out / 'cli-error.log').open('xb') as stderr:
            child, launch = launch_suspended_in_job(command, job=job, cwd=PROJECT, stdout=stdout, stderr=stderr)
            report['owned_cli_pid'] = child.pid
            report['suspended_launch'] = launch
            next_sample = 0
            while child.poll() is None:
                elapsed, free = time.monotonic()-started, memory().available_commit
                need(elapsed < 1800 and free >= reserve and shutil.disk_usage(PROJECT).free > 4*GIB, 'Build time/system-memory/disk guard reached')
                if elapsed >= next_sample:
                    info = ExtendedJob()
                    query = job.kernel.QueryInformationJobObject
                    query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_uint32, ctypes.c_void_p]
                    query.restype = ctypes.c_int
                    need(query(job.handle, 9, ctypes.byref(info), ctypes.sizeof(info), None), 'Cannot query owned build memory')
                    sample = {'seconds': round(elapsed, 2), 'available_commit': free, 'peak_job_memory': int(info.peak_job), 'peak_process_memory': int(info.peak_process)}
                    report['samples'].append(sample)
                    save()
                    print(json.dumps({'status': 'building_full_original_project', **sample}), flush=True)
                    next_sample = elapsed + 15
                time.sleep(.25)
        child.wait(timeout=10)
        report['cli_exit_code'] = child.returncode
        result_path = out / 'build-report.json'
        built = json.loads(result_path.read_bytes()) if result_path.exists() else None
        report['build_report'] = built
        report['status'] = 'built_gameplay_unverified' if built and built['status'] == 'Succeeded' and built['totalErrors'] == 0 and child.returncode == 0 and player.is_file() else 'failed'
        report['player_created'] = player.is_file()
    except BaseException as error:
        report.update(status='stopped', error=repr(error))
        if hasattr(error, 'evidence'):
            report['suspended_launch'] = error.evidence
    finally:
        if job:
            job.close()
        if child is not None and child.poll() is None:
            try:
                child.wait(timeout=15)
            except subprocess.TimeoutExpired:
                report['owned_cli_did_not_exit_after_job_close'] = True
        try:
            for retry in range(41):
                try:
                    safety.assert_editor_closed()
                    break
                except RuntimeError:
                    if retry == 40:
                        raise
                    time.sleep(.25)
            for path, digest in owned.items():
                if path.exists():
                    safety.assert_no_reparse(path)
                    need(sha(path) == digest, 'Temporary helper changed; preserve it for review')
                    path.unlink()
            if temporary.exists():
                temporary.rmdir()
            report['temporary_build_helper_removed'] = True
            report['scenes_and_settings_byte_unchanged'] = all(Path(p).is_file() and sha(Path(p)) == digest for p, digest in hashes.items())
        except BaseException as error:
            report['cleanup_error'] = repr(error)
        if report['status'] == 'built_gameplay_unverified' and (report.get('cleanup_error') or not report.get('scenes_and_settings_byte_unchanged')):
            report['status'] = 'build_created_but_preservation_or_cleanup_failed'
        report['seconds'] = round(time.monotonic()-started, 2)
        save()
        print(json.dumps({'status': report['status'], 'report': str(out / 'run-report.json'), 'player': str(player), 'error': report.get('error')}), flush=True)
    return 0 if report['status'] == 'built_gameplay_unverified' else 1

if __name__ == '__main__':
    raise SystemExit(main())
