"""Read two pinned original AG objects with the existing generic model; no compilation/Editor."""
from pathlib import Path
import ctypes
import datetime as dt
import hashlib
import json
import os
import shutil
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
from compare_shader_parsed_form import compare

PREVIOUS = ROOT / "AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959"
ROUTE = ROOT / "AssetRecovery/OriginalShaderRecoveryRoute-20261022T184808Z-356f2e1f"
HOST = PREVIOUS / "OriginalShaderObjectProbe.dll"
DOTNET = Path("C:/Program Files/dotnet/dotnet.exe")
CAP = 512 * 1024**2
RESERVE = int(1.5 * 1024**3)
MAIN = WS / "RR23/Assets/Shader/AG_Standard-Opaque.asset"


def need(value, message):
    if not value:
        raise RuntimeError(message)


def sha(path):
    with Path(path).open("rb") as stream:
        return hashlib.file_digest(stream, "sha256").hexdigest()


def pin(path):
    return {"path": str(path), "sha256": sha(path), "bytes": Path(path).stat().st_size}


def phase(command, out, name):
    available = memory().available_commit
    need(available >= CAP + RESERVE and shutil.disk_usage(out).free >= 4 * 1024**3, "512MiB reader plus1.5GiB commit/4GiB disk reserve refused")
    job = ChildJob()
    limits = ExtendedJob()
    limits.basic.flags = 0x2000 | 0x200
    limits.job_memory = CAP
    need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), "Cannot set owned reader512MiB limit")
    child = None
    record = {"phase": name, "command": command, "cap_bytes": CAP, "reserve_bytes": RESERVE, "admission_available_commit": available, "deadline_seconds": 60}
    try:
        home = out / "DotnetHome"
        home.mkdir(exist_ok=True)
        env = dict(os.environ, DOTNET_PROCESSOR_COUNT="1", DOTNET_CLI_TELEMETRY_OPTOUT="1", DOTNET_SKIP_FIRST_TIME_EXPERIENCE="1", DOTNET_NOLOGO="1", DOTNET_CLI_HOME=str(home))
        with (out / (name + ".log")).open("xb") as log:
            child, launched = launch_suspended_in_job(command, job=job, cwd=out, stdout=log, stderr=subprocess.STDOUT, env=env)
            record["launch"] = launched
            started = time.monotonic()
            while child.poll() is None:
                need(memory().available_commit >= RESERVE and time.monotonic() - started <= 60, "Original object reader commit/time guard")
                time.sleep(.05)
            record["exit_code"] = child.returncode
        query = job.kernel.QueryInformationJobObject
        query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_ulong, ctypes.c_void_p]
        query.restype = ctypes.c_int
        need(query(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits), None), "Cannot query owned reader peak")
        record["peak_job_bytes"] = int(limits.peak_job)
        record["log"] = pin(out / (name + ".log"))
        need(child.returncode == 0, "Original object model reader failed")
    except BaseException as error:
        record["error"] = repr(error)
        if getattr(error, "evidence", None) is not None:
            record["suspended_launch_failure"] = error.evidence
    finally:
        job.close()
        if child is not None:
            child.wait(timeout=10)
    return record


def main():
    need(sha(PREVIOUS / "report.json") == "e99d06254cd16e817a20e19cedecbedf8005c19608d7141d80461a9b9c6c8f97", "Exact existing generic reader compilation receipt required")
    need(sha(PREVIOUS / "OriginalShaderObjectProbe.cs") == "c10e692d0d482e9a55ede144f2ceb89e7622d7dce4bcc8b9af7adadc345858c3", "Exact compiled generic source snapshot required")
    previous = json.loads((PREVIOUS / "report.json").read_bytes())
    need(previous["status"] == "parsed" and all(p["exit_code"] == 0 for p in previous["phases"]), "Existing generic reader was not successfully compiled and exercised")
    for ref in previous["dependencies"]:
        need(sha(Path(ref["path"])) == ref["sha256"] and sha(PREVIOUS / Path(ref["path"]).name) == ref["sha256"], "A matching reader dependency changed")
    route = json.loads((ROUTE / "report.json").read_bytes())
    objects = [x for x in route["original_object_candidates"] if x["requested_shader"] == "AG/Standard-Opaque"]
    need(len(objects) == 2, "Exactly two original AG object variants required")
    before = pin(MAIN)
    meta = pin(Path(str(MAIN) + ".meta"))
    out = ROOT / "AssetRecovery" / ("OriginalAGShaderModels-" + dt.datetime.now(dt.timezone.utc).strftime("%Y%m%dT%H%M%SZ") + "-" + uuid.uuid4().hex[:8])
    out.mkdir()
    result = {"schema": "bounded-existing-generic-original-AG-shader-model-read/v1", "status": "starting", "existing_generic_compile_receipt": pin(PREVIOUS / "report.json"),
              "reader": pin(HOST), "reader_source_snapshot": pin(PREVIOUS / "OriginalShaderObjectProbe.cs"), "dotnet": pin(DOTNET),
              "reader_runtimeconfig": pin(HOST.with_suffix(".runtimeconfig.json")), "reader_deps": pin(HOST.with_suffix(".deps.json")),
              "reader_directory_DLL_pins": [pin(p) for p in sorted(PREVIOUS.glob("*.dll"))], "Main_before": before, "Main_meta_before": meta,
              "phases": [], "models": [], "Editor_launched": False, "compiler_launched": False, "game_or_original_native_code_invoked": False, "Main_modified": False, "tool": pin(Path(__file__))}
    for index, obj in enumerate(objects):
        raw = Path(obj["range_copy"]["path"])
        need(sha(raw) == obj["range_copy"]["sha256"] and raw.stat().st_size == obj["range_copy"]["bytes"] <= 8 * 1024**2, "Exact bounded original object pins required")
        name = "native" if obj["source_object"]["origin"] == "original_native_container" else "bundle"
        target = out / (name + "-Object")
        command = [str(DOTNET), str(HOST), str(raw), obj["range_copy"]["sha256"], obj["source_object"]["path_id"], "AG/Standard-Opaque", str(target)]
        run = phase(command, out, name)
        result["phases"].append(run)
        if run.get("exit_code") != 0 or run.get("error"):
            result["status"] = "failed_or_guard_refused"
            break
        model_path = target / "report.json"
        model = json.loads(model_path.read_bytes())
        need(model["status"] == "parsed_entire_original_object" and model["consumed_bytes"] == model["total_bytes"] == raw.stat().st_size and model["actual_name"] == "AG/Standard-Opaque", "Entire original AG object/name proof failed")
        comparison = compare(Path(model["parsed_form"]["path"]), MAIN)
        comparison_path = out / (name + "-current-parsed-form-comparison.json")
        comparison_path.write_bytes((json.dumps(comparison, indent=2) + "\n").encode("utf-8"))
        result["models"].append({"variant": name, "original_provenance": obj, "model": pin(model_path), "ParsedForm": pin(Path(model["parsed_form"]["path"])), "current_comparison": pin(comparison_path), "original_program_fields": model["fields"], "full_model_consumption": True})
    else:
        result["status"] = "both_original_AG_variants_parsed_candidate_selection_pending"
    need(sha(MAIN) == before["sha256"] and sha(Path(str(MAIN) + ".meta")) == meta["sha256"], "Main shader/meta changed during pure object reads")
    result["finished_utc"] = dt.datetime.now(dt.timezone.utc).isoformat()
    (out / "report.json").write_bytes((json.dumps(result, indent=2) + "\n").encode("utf-8"))
    print(json.dumps({"status": result["status"], "report": str(out / "report.json"), "models": len(result["models"]), "peak_bytes": [x.get("peak_job_bytes") for x in result["phases"]]}))
    return 0 if len(result["models"]) == 2 else 1


if __name__ == "__main__":
    raise SystemExit(main())
