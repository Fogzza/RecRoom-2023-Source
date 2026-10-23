"""Benign Python-only marker proof of the assign-before-resume helper."""
from pathlib import Path
import argparse
import ctypes
import datetime as dt
import hashlib
import json
import os
import subprocess
import sys
import time
import uuid

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
RECOVERY = WORKSPACE / "Recovery/RecRoom-2023-04-18"
sys.path.insert(0, str(RECOVERY / "Tools"))
sys.path.insert(0, str(HERE))
from export_bundle_batches import ChildJob, ExtendedJob
from guarded_cpp2il import memory
from owned_suspended_launch import SuspendedLaunchError, launch_suspended_in_job

CAP = 128 * 1024**2
RESERVE = int(1.5 * 1024**3)


def require(value, message):
    if not value:
        raise RuntimeError(message)


def make_job():
    require(memory().available_commit >= CAP + RESERVE, "128MiB cap plus 1.5GiB reserve admission refused")
    job = ChildJob()
    limits = ExtendedJob()
    limits.basic.flags = 0x2000 | 0x200
    limits.job_memory = CAP
    if not job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)):
        job.close()
        raise ctypes.WinError(ctypes.get_last_error())
    return job


class MarkerProofJob:
    def __init__(self, job, marker, evidence, fail_assignment=False):
        self.job, self.marker, self.evidence = job, marker, evidence
        self.handle = job.handle
        self.fail_assignment = fail_assignment

    def attach(self, child):
        self.evidence["owned_pid"] = child.pid
        self.evidence["marker_absent_before_assignment"] = not self.marker.exists()
        require(self.evidence["marker_absent_before_assignment"], "Marker appeared before assignment")
        if self.fail_assignment:
            self.evidence["injected_assignment_failure"] = True
            raise OSError("Intentional benign probe assignment failure; child remains suspended")
        self.job.attach(child)
        self.evidence["marker_absent_after_assignment_before_resume"] = not self.marker.exists()
        require(self.evidence["marker_absent_after_assignment_before_resume"], "Marker appeared while primary thread was suspended")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--run-benign-python-probe", action="store_true")
    args = parser.parse_args()
    require(args.run_benign_python_probe and os.name == "nt", "Explicit Windows benign-probe switch required")
    out = RECOVERY / "AssetRecovery" / ("OwnedSuspendedLaunchProbe-" + dt.datetime.now(dt.timezone.utc).strftime("%Y%m%dT%H%M%SZ") + "-" + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {"schema": "benign-python-assign-before-resume-probe/v1", "status": "starting",
              "maximum_owned_job_bytes": CAP, "minimum_system_commit_reserve_bytes": RESERVE,
              "python": sys.executable, "Editor_launched": False, "compiler_launched": False,
              "SDK_child_launched": False, "Main_modified": False, "cases": []}
    try:
        for failure in (False, True):
            name = "assignment_failure" if failure else "successful_resume"
            marker = out / (name + ".marker")
            evidence = {"case": name}
            report["cases"].append(evidence)
            # No imports of game/Unity/SDK code, network activity, or prolonged work.
            code = "from pathlib import Path; import sys; Path(sys.argv[1]).write_text('owned-python-ran\\n', encoding='utf-8')"
            command = [sys.executable, "-I", "-S", "-B", "-c", code, str(marker)]
            job = make_job()
            child = None
            try:
                with (out / (name + ".log")).open("xb") as log:
                    try:
                        child, launched = launch_suspended_in_job(command, job=MarkerProofJob(job, marker, evidence, failure), cwd=out, stdout=log, stderr=subprocess.STDOUT)
                        evidence["launcher"] = launched
                        require(not failure, "Injected assignment failure unexpectedly resumed")
                        started = time.monotonic()
                        while child.poll() is None:
                            require(memory().available_commit >= RESERVE and time.monotonic() - started <= 10, "Benign probe memory/time guard")
                            time.sleep(0.02)
                        evidence["exit_code"] = child.returncode
                        evidence["marker_present_after_resume"] = marker.exists()
                        require(child.returncode == 0 and marker.read_text(encoding="utf-8") == "owned-python-ran\n", "Benign resumed marker proof failed")
                        require(launched["membership_verified_before_resume"] and launched["resume_previous_suspend_count"] == 1, "Membership/resume proof absent")
                    except SuspendedLaunchError as error:
                        evidence["launcher"] = error.evidence
                        require(failure, "Unexpected launcher failure: " + str(error))
                        evidence["marker_absent_after_cleanup"] = not marker.exists()
                        require(error.evidence.get("owned_child_exit_confirmed") and error.evidence.get("cleanup_before_resume") and not error.evidence["resumed"] and not marker.exists(), "Assignment failure did not clean up the suspended owned child")
                limits = ExtendedJob()
                query = job.kernel.QueryInformationJobObject
                query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_ulong, ctypes.c_void_p]
                query.restype = ctypes.c_int
                require(query(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits), None), "Job peak query failed")
                evidence["peak_job_bytes"] = int(limits.peak_job)
                require(limits.peak_job <= CAP, "128MiB benign job cap exceeded")
                evidence["status"] = "passed"
            finally:
                job.close()
                if child is not None:
                    evidence["owned_child_exit_confirmed"] = child.wait(timeout=10) is not None
        report["status"] = "passed"
    except BaseException as error:
        report.update(status="failed", error=repr(error))
    finally:
        report["finished_utc"] = dt.datetime.now(dt.timezone.utc).isoformat()
        report["sources"] = [{"path": str(p), "sha256": hashlib.sha256(p.read_bytes()).hexdigest()} for p in (Path(__file__).resolve(), HERE / "owned_suspended_launch.py")]
        (out / "report.json").write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
        print(json.dumps({"status": report["status"], "report": str(out / "report.json"), "error": report.get("error")}))
    return 0 if report["status"] == "passed" else 1


if __name__ == "__main__":
    raise SystemExit(main())
