"""Run harmless cache/forwarding controls against the exact isolated getter DLL."""
from pathlib import Path
import ctypes
import datetime as dt
import hashlib
import json
import shutil
import subprocess
import sys
import time
import uuid

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import compile_apply_original_protocol_version_getters as apply

CS = r'''using System;
using System.Reflection;
public static class GetterControls
{
    static void Need(bool value, string message) { if (!value) throw new Exception(message); }
    public static int Main()
    {
        Type owner = typeof(IDDIAODMAPP);
        FieldInfo cache = owner.GetField("EOGFAFNNICF", BindingFlags.NonPublic | BindingFlags.Static);
        Need(cache != null && cache.FieldType == typeof(string), "Exact private cache field required");
        object previous = cache.GetValue(null);
        try
        {
            cache.SetValue(null, null);
            Need(IDDIAODMAPP.OLGKJALIAAI == "20230414", "null cache did not return original protocol");
            Need((string)cache.GetValue(null) == "20230414", "null cache was not populated");
            cache.SetValue(null, "arbitrary-cache-control");
            Need(IDDIAODMAPP.OLGKJALIAAI == "arbitrary-cache-control", "nonnull cache was not preserved");
            cache.SetValue(null, "");
            Need(IDDIAODMAPP.OLGKJALIAAI == "" && (string)cache.GetValue(null) == "", "empty cache was not preserved");
            Type nested = owner.GetNestedType("ONPIJEFNLPD", BindingFlags.NonPublic);
            Need(nested != null, "Exact existing nested type required");
            object instance = Activator.CreateInstance(nested, true);
            PropertyInfo forwarded = nested.GetProperty("OLGKJALIAAI", BindingFlags.Public | BindingFlags.Instance);
            Need(forwarded != null && forwarded.PropertyType == typeof(string), "Exact nested getter required");
            cache.SetValue(null, "nested-forward-control");
            Need((string)forwarded.GetValue(instance, null) == "nested-forward-control", "nested getter did not forward current value");
            cache.SetValue(null, null);
            Need((string)forwarded.GetValue(instance, null) == "20230414", "nested getter did not forward null-cache initialization");
            Console.WriteLine("{\"status\":\"passed\",\"controls\":[\"null_cache_original_protocol\",\"cache_populated\",\"nonnull_preserved\",\"empty_preserved\",\"nested_forwards_current\",\"nested_forwards_null_initialization\"],\"network_requests\":0,\"Unity_native_calls\":0}");
            return 0;
        }
        finally { cache.SetValue(null, previous); }
    }
}
'''


def run_owned(command, out, phase):
    available = apply.memory().available_commit
    apply.need(available >= apply.CAP + apply.RESERVE, "256MiB job plus1.5GiB reserve admission refused")
    job = apply.ChildJob()
    limits = apply.ExtendedJob()
    limits.basic.flags = 0x2000 | 0x200
    limits.job_memory = apply.CAP
    apply.need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), "Cannot set tiny control job cap")
    child = None
    result = {"phase": phase, "command": command, "cap_bytes": apply.CAP, "reserve_bytes": apply.RESERVE, "admission_available_commit": available}
    try:
        with (out / (phase + ".log")).open("xb") as log:
            child, launched = apply.launch_suspended_in_job(command, job=job, cwd=out, stdout=log, stderr=subprocess.STDOUT)
            result["launch"] = launched
            start = time.monotonic()
            while child.poll() is None:
                apply.need(apply.memory().available_commit >= apply.RESERVE and time.monotonic() - start <= 30, "Tiny managed control memory/time guard")
                time.sleep(.02)
            result["exit_code"] = child.returncode
        query = job.kernel.QueryInformationJobObject
        query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_ulong, ctypes.c_void_p]
        query.restype = ctypes.c_int
        apply.need(query(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits), None), "Cannot query owned control job peak")
        result["peak_job_bytes"] = int(limits.peak_job)
        result["log"] = apply.pin(out / (phase + ".log"))
        apply.need(child.returncode == 0, "Managed getter " + phase + " failed")
        return result
    finally:
        job.close()
        if child is not None:
            child.wait(timeout=10)


def main():
    applied = apply.ROOT / "Validation/OriginalProtocolGettersCompileApply-20261022T202304Z-5cbf410e/report.json"
    receipt = json.loads(applied.read_bytes())
    apply.need(receipt["status"] == "matching_compile_passed_two_original_getter_bodies_applied", "Exact successful compile/apply receipt required")
    apply.need(apply.sha(apply.SOURCE) == apply.AFTER_SHA and apply.sha(apply.META) == apply.META_SHA, "Current applied source/meta pins changed")
    dll = Path(receipt["compiled_output"]["path"])
    apply.need(apply.sha(dll) == receipt["compiled_output"]["sha256"], "Exact isolated compiled candidate changed")
    mono = apply.EDITOR / "Data/MonoBleedingEdge/bin/mono.exe"
    out = applied.parent / ("ManagedControls-" + dt.datetime.now(dt.timezone.utc).strftime("%Y%m%dT%H%M%SZ") + "-" + uuid.uuid4().hex[:8])
    out.mkdir()
    report = {"schema": "isolated-original-protocol-version-getter-managed-controls/v1", "status": "starting", "applied_receipt": apply.pin(applied),
              "candidate_DLL": apply.pin(dll), "matching_Mono_runtime": apply.pin(mono), "phases": [], "dependency_copies": [],
              "Main_written_by_controls": False, "Editor_launched": False, "network_requests": 0, "Unity_native_calls": 0, "tool": apply.pin(Path(__file__))}
    try:
        shutil.copyfile(dll, out / dll.name)
        for ref in receipt["references"]:
            path = Path(ref["path"])
            apply.need(apply.sha(path) == ref["sha256"], "Exact genuine reference changed")
            if path.name not in ("mscorlib.dll", "System.dll", "System.Core.dll"):
                target = out / path.name
                shutil.copyfile(path, target)
                apply.need(apply.sha(target) == ref["sha256"], "Genuine runtime dependency copy changed")
                report["dependency_copies"].append(apply.pin(target))
        source = out / "GetterControls.cs"
        source.write_bytes(CS.encode("utf-8"))
        response = out / "GetterControls.rsp"
        target = out / "GetterControls.exe"
        response.write_bytes(("\n".join(["/nologo", "/nostdlib+", "/target:exe", "/langversion:8", '/out:"' + str(target) + '"'] + ['/reference:"' + x["path"] + '"' for x in receipt["references"]] + ['/reference:"' + str(dll) + '"', '"' + str(source) + '"']) + "\n").encode("utf-8"))
        report["control_source"] = apply.pin(source)
        report["phases"].append(run_owned([str(apply.CSC), "/noconfig", "@" + str(response)], out, "compile-controls"))
        report["phases"].append(run_owned([str(mono), str(target)], out, "execute-controls"))
        result = json.loads((out / "execute-controls.log").read_text(encoding="utf-8-sig"))
        apply.need(result["status"] == "passed" and len(result["controls"]) == 6, "All requested harmless getter controls required")
        report["managed_control_result"] = result
        apply.need(apply.sha(apply.SOURCE) == apply.AFTER_SHA and apply.sha(apply.META) == apply.META_SHA, "Applied Main source/meta changed during isolated controls")
        apply.need(apply.sha(apply.PROPOSAL / "report.json") == receipt["frozen_proposal_receipt"]["sha256"], "Frozen proposal receipt changed")
        report.update(status="passed", applied_source_verified=apply.pin(apply.SOURCE), applied_meta_verified=apply.pin(apply.META), frozen_proposal_receipt_unchanged=True)
    except BaseException as error:
        report.update(status="failed", error=repr(error))
    finally:
        report["finished_utc"] = dt.datetime.now(dt.timezone.utc).isoformat()
        (out / "verified-applied-receipt.json").write_bytes((json.dumps(report, indent=2) + "\n").encode("utf-8"))
        print(json.dumps({"status": report["status"], "receipt": str(out / "verified-applied-receipt.json"), "error": report.get("error")}))
    return 0 if report["status"] == "passed" else 1


if __name__ == "__main__":
    raise SystemExit(main())
