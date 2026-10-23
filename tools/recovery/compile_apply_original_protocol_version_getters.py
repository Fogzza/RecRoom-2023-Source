"""Compile final pinned getters against real DLLs, then apply only the pinned bodies."""
from pathlib import Path
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
WS = HERE.parents[2]
ROOT = WS / "Recovery/RecRoom-2023-04-18"
sys.path[:0] = [str(HERE), str(ROOT / "Tools")]
from export_bundle_batches import ChildJob, ExtendedJob
from guarded_cpp2il import memory
from owned_suspended_launch import launch_suspended_in_job
import repair_rr23_wav_headers as safety

PROPOSAL = ROOT / "Validation/OriginalProtocolVersionGetters-20261022T201838Z-e4485b51"
SOURCE = WS / "RR23/Assets/Scripts/Assembly-CSharp/IDDIAODMAPP.cs"
META = Path(str(SOURCE) + ".meta")
CANDIDATE = PROPOSAL / "IDDIAODMAPP.proposed.cs"
BEFORE_SHA = "60c70b6b7af7bdbd9735a0829fe9279a8001e17255cdf3f40cae0bfea70943a2"
AFTER_SHA = "4ee24d611166a4e03355c255ace840987b9436f356d95ad5bfebd61eee86e938"
META_SHA = "c96fac93f95b39473a1464601f38640ca238802cb9714b8b0280af120fab02e9"
EDITOR = WS / "Tools/Editors/2020.3.33f1/Editor"
CSC = EDITOR / "Data/Tools/Roslyn/csc.exe"
CSC_SHA = "2aa759f08eca317a94e1a7b8d04c068c8bcd06b84e40683ea71b1bdfc99f3526"
LAUNCH_SHA = "3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958"
CAP = 256 * 1024**2
RESERVE = int(1.5 * 1024**3)


def need(value, message):
    if not value:
        raise RuntimeError(message)


def sha(path):
    with Path(path).open("rb") as stream:
        return hashlib.file_digest(stream, "sha256").hexdigest()


def pin(path):
    safety.assert_no_reparse(path)
    return {"path": str(path), "sha256": sha(path), "bytes": Path(path).stat().st_size}


def span(text, declaration):
    need(text.count(declaration) == 1, "Unique exact getter declaration required")
    opening = text.index("{", text.index("get", text.index(declaration)))
    depth = 1
    end = opening + 1
    while depth:
        depth += (text[end] == "{") - (text[end] == "}")
        end += 1
    return opening, end


def outside(raw):
    text = raw.decode("utf-8")
    spans = [span(text, d) for d in ("public string OLGKJALIAAI", "public static string OLGKJALIAAI")]
    for begin, end in sorted(spans, reverse=True):
        text = text[:begin] + text[end:]
    return text.encode("utf-8")


def main():
    need(sha(SOURCE) == BEFORE_SHA and sha(META) == META_SHA and sha(CANDIDATE) == AFTER_SHA, "Exact Main/meta/final candidate pins required")
    need(sha(CSC) == CSC_SHA and sha(HERE / "owned_suspended_launch.py") == LAUNCH_SHA, "Matching compiler and reviewed launcher pins required")
    original, meta_bytes, candidate = SOURCE.read_bytes(), META.read_bytes(), CANDIDATE.read_bytes()
    need(outside(original) == outside(candidate), "Candidate differs outside the two getter bodies")
    frozen = pin(PROPOSAL / "report.json")
    safety.assert_editor_closed()
    available = memory().available_commit
    need(available >= CAP + RESERVE, "256MiB compile cap plus1.5GiB reserve admission refused")
    out = ROOT / "Validation" / ("OriginalProtocolGettersCompileApply-" + dt.datetime.now(dt.timezone.utc).strftime("%Y%m%dT%H%M%SZ") + "-" + uuid.uuid4().hex[:8])
    out.mkdir()
    target = out / "OriginalProtocolVersionGetters.dll"
    refs = [EDITOR / "Data/MonoBleedingEdge/lib/mono/unityjit" / name for name in ("mscorlib.dll", "System.dll", "System.Core.dll")]
    refs += [EDITOR / "Data/Managed/UnityEngine/UnityEngine.CoreModule.dll", WS / "RR23/Assets/Plugins/RecNet.Runtime.dll", WS / "RR23/Assets/Plugins/UJect.Runtime.dll"]
    report = {"schema": "matching2020-real-dependencies-two-original-version-getters-compile-apply/v1", "status": "starting", "source_before": pin(SOURCE), "meta_before": pin(META),
              "candidate": pin(CANDIDATE), "frozen_proposal_receipt": frozen, "compiler": pin(CSC), "references": [pin(p) for p in refs], "launcher": pin(HERE / "owned_suspended_launch.py"),
              "cap_bytes": CAP, "reserve_bytes": RESERVE, "admission_available_commit": available, "maximum_seconds": 30, "samples": [],
              "invented_interface_or_dependency_source": False, "CSharp_sources": [str(CANDIDATE)], "Main_modified": False, "Editor_launched": False, "network_requests": 0, "tool": pin(Path(__file__))}
    response = out / "matching2020-real-dependencies.rsp"
    response.write_bytes(("\n".join(["/nologo", "/nostdlib+", "/target:library", "/langversion:8", '/out:"' + str(target) + '"'] + ['/reference:"' + str(p) + '"' for p in refs] + ['"' + str(CANDIDATE) + '"']) + "\n").encode("utf-8"))
    report["compiler_response"] = pin(response)
    child = None
    job = ChildJob()
    limits = ExtendedJob()
    limits.basic.flags = 0x2000 | 0x200
    limits.job_memory = CAP
    need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), "Cannot set owned compile job cap")
    try:
        started = time.monotonic()
        with (out / "compile.log").open("xb") as log:
            child, launch = launch_suspended_in_job([str(CSC), "/noconfig", "@" + str(response)], job=job, cwd=out, stdout=log, stderr=subprocess.STDOUT)
            report["suspended_launch"] = launch
            next_sample = 0
            while child.poll() is None:
                elapsed = time.monotonic() - started
                available = memory().available_commit
                need(elapsed <= 30 and available >= RESERVE, "Tiny compile memory/time guard")
                if elapsed >= next_sample:
                    report["samples"].append({"seconds": round(elapsed, 3), "available_commit": available})
                    next_sample = elapsed + 1
                time.sleep(.02)
        report["compile_exit_code"] = child.returncode
        report["compile_log"] = pin(out / "compile.log")
        query = job.kernel.QueryInformationJobObject
        query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_ulong, ctypes.c_void_p]
        query.restype = ctypes.c_int
        need(query(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits), None), "Cannot query tiny compile job peak")
        report["peak_job_bytes"] = int(limits.peak_job)
        need(child.returncode == 0 and target.is_file(), "Matching compiler rejected real dependencies; Main remains unchanged")
        report["compiled_output"] = pin(target)
        job.close()
        child.wait(timeout=10)
        report["compiler_exit_confirmed_before_apply"] = True
        safety.assert_editor_closed()
        need(sha(SOURCE) == BEFORE_SHA and sha(META) == META_SHA and sha(CANDIDATE) == AFTER_SHA and sha(PROPOSAL / "report.json") == frozen["sha256"], "Input or frozen proof changed before apply")
        for ref in report["references"]:
            need(sha(Path(ref["path"])) == ref["sha256"], "A genuine compile dependency changed before apply")
        backup = out / "Backup"
        backup.mkdir()
        (backup / SOURCE.name).write_bytes(original)
        (backup / META.name).write_bytes(meta_bytes)
        need(sha(backup / SOURCE.name) == BEFORE_SHA and sha(backup / META.name) == META_SHA, "Exact source/meta backup verification failed")
        report["backups"] = [pin(backup / SOURCE.name), pin(backup / META.name)]
        pending = out / "apply-exact-candidate.tmp"
        with pending.open("xb") as stream:
            stream.write(candidate)
            stream.flush()
            os.fsync(stream.fileno())
        need(sha(SOURCE) == BEFORE_SHA and sha(META) == META_SHA and sha(pending) == AFTER_SHA, "Last-moment source/meta/candidate pins changed")
        os.replace(pending, SOURCE)
        report["Main_modified"] = True
        need(sha(SOURCE) == AFTER_SHA and META.read_bytes() == meta_bytes and outside(SOURCE.read_bytes()) == outside(original), "Post-apply exact body/meta verification failed")
        need(sha(PROPOSAL / "report.json") == frozen["sha256"], "Frozen proposal receipt changed")
        report.update(status="matching_compile_passed_two_original_getter_bodies_applied", source_after=pin(SOURCE), meta_after=pin(META), all_bytes_outside_two_getter_bodies_exact=True, meta_all_bytes_unchanged=True, frozen_proposal_receipt_unchanged=True)
    except BaseException as error:
        report.update(status="failed_main_applied" if report["Main_modified"] else "failed_main_not_modified", error=repr(error))
        if getattr(error, "evidence", None) is not None:
            report["suspended_launch_failure"] = error.evidence
    finally:
        job.close()
        if child is not None:
            try:
                report["owned_compiler_exit_confirmed"] = child.wait(timeout=10) is not None
            except BaseException as error:
                report["cleanup_error"] = repr(error)
        report["finished_utc"] = dt.datetime.now(dt.timezone.utc).isoformat()
        (out / "report.json").write_bytes((json.dumps(report, indent=2) + "\n").encode("utf-8"))
        print(json.dumps({"status": report["status"], "report": str(out / "report.json"), "Main_modified": report["Main_modified"], "error": report.get("error")}))
    return 0 if report["status"] == "matching_compile_passed_two_original_getter_bodies_applied" else 1


if __name__ == "__main__":
    raise SystemExit(main())
