"""Write a reviewable proposal only; never edits the fixture runner or plan."""
from pathlib import Path
import ast
import datetime as dt
import difflib
import hashlib
import json
import uuid

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
ROOT = WORKSPACE / "Recovery/RecRoom-2023-04-18/AssetRecovery"
FIXTURE = ROOT / "OriginalStencilImportFixture-20261022T194521Z-be9d6ebe"
RUNNER = HERE / "run_original_shader_import_fixture.py"
HELPER = HERE / "owned_suspended_launch.py"
PROBE = ROOT / "OwnedSuspendedLaunchProbe-20261022T195802Z-d6865f06/report.json"


def sha(data):
    return hashlib.sha256(data).hexdigest()


def row(path):
    data = path.read_bytes()
    return {"path": str(path), "sha256": sha(data), "bytes": len(data)}


def replace_once(text, before, after):
    if text.count(before) != 1:
        raise RuntimeError("Unexpected runner shape: " + before)
    return text.replace(before, after)


def main():
    original = RUNNER.read_bytes()
    old_plan = (FIXTURE / "plan.json").read_bytes()
    if sha(original) != "8a8e97c5583a7ea280a292c34f464b46843da15660f4b1e933464916161f4ef1":
        raise RuntimeError("Original runner changed; proposal refused")
    if sha(old_plan) != "445465bdfaddb03639d063ebed625265c5fa328256e144f73e0af68857d913c1":
        raise RuntimeError("Original plan changed; proposal refused")
    proof = json.loads(PROBE.read_bytes())
    if proof["status"] != "passed" or not any(x["path"] == str(HELPER) and x["sha256"] == row(HELPER)["sha256"] for x in proof["sources"]):
        raise RuntimeError("Current helper lacks its matching benign passed proof")
    source = original.decode("utf-8")
    proposed = replace_once(source, "import repair_rr23_wav_headers as safety\n", "import repair_rr23_wav_headers as safety\nfrom owned_suspended_launch import launch_suspended_in_job\n")
    proposed = replace_once(proposed,
        "child=subprocess.Popen(cmd,cwd=project,stdout=log,stderr=subprocess.STDOUT,creationflags=subprocess.CREATE_NO_WINDOW);job.attach(child);row['owned_pid']=child.pid",
        "child,launch=launch_suspended_in_job(cmd,job=job,cwd=project,stdout=log,stderr=subprocess.STDOUT);row['owned_pid']=child.pid;row['suspended_launch']=launch")
    proposed = replace_once(proposed,
        "child=subprocess.Popen(cmd,cwd=project,stdout=stdout,stderr=stderr,creationflags=subprocess.CREATE_NO_WINDOW);job.attach(child)",
        "child,launch=launch_suspended_in_job(cmd,job=job,cwd=project,stdout=stdout,stderr=stderr);row['suspended_launch']=launch")
    proposed = replace_once(proposed,
        "[plan['runner'],plan['editor'],plan['cli'],plan['candidate_report'],plan['candidate_readiness']]",
        "[plan['runner'],plan['launcher_helper'],plan['launcher_probe_report'],plan['editor'],plan['cli'],plan['candidate_report'],plan['candidate_readiness']]")
    proposed = replace_once(proposed,
        " except BaseException as error:report.update(status='failed_or_guard_refused',error=repr(error))\n",
        " except BaseException as error:\n  report.update(status='failed_or_guard_refused',error=repr(error))\n  if getattr(error,'evidence',None) is not None:report['suspended_launch_failure']=error.evidence\n")
    ast.parse(proposed, filename=str(RUNNER))
    out = ROOT / ("OriginalShaderSuspendedLaunchProposal-" + dt.datetime.now(dt.timezone.utc).strftime("%Y%m%dT%H%M%SZ") + "-" + uuid.uuid4().hex[:8])
    out.mkdir()
    proposed_bytes = proposed.encode("utf-8")
    (out / "runner.before.py").write_bytes(original)
    (out / "runner.proposed.py").write_bytes(proposed_bytes)
    (out / "plan.before.json").write_bytes(old_plan)
    plan = json.loads(old_plan)
    plan["runner"].update(sha256=sha(proposed_bytes), bytes=len(proposed_bytes))
    plan["launcher_helper"] = row(HELPER)
    plan["launcher_probe_report"] = row(PROBE)
    plan.setdefault("preparation_amendments", []).append({
        "reason": "Create compiler and official CLI suspended; verify exact owned job and primary-thread owner before documented ResumeThread. Preserve failed-launch cleanup evidence.",
        "previous_plan": str(out / "plan.before.json"), "previous_plan_sha256": sha(old_plan),
        "only_inputs_changed": "runner source/hash; added launcher helper and benign proof source pins; project inputs, observer C#, candidate/meta/config unchanged",
        "proposal_only": True, "changed_utc": dt.datetime.now(dt.timezone.utc).isoformat()})
    new_plan = (json.dumps(plan, indent=2) + "\n").encode("utf-8")
    (out / "plan.proposed.json").write_bytes(new_plan)
    (out / "runner.patch").write_text("".join(difflib.unified_diff(source.splitlines(keepends=True), proposed.splitlines(keepends=True), fromfile="a/Tools/RecoveryTools/CompilerIntegrationAudit/run_original_shader_import_fixture.py", tofile="b/Tools/RecoveryTools/CompilerIntegrationAudit/run_original_shader_import_fixture.py")), encoding="utf-8")
    report = {"schema": "original-shader-suspended-launch-amendment-proposal/v1", "status": "staged_for_root_review_not_applied",
        "original_runner": {"path": str(RUNNER), "sha256": sha(original)},
        "original_plan": {"path": str(FIXTURE / "plan.json"), "sha256": sha(old_plan)},
        "proposed_runner": row(out / "runner.proposed.py"), "proposed_plan": row(out / "plan.proposed.json"),
        "patch": row(out / "runner.patch"), "launcher_helper": row(HELPER), "benign_probe_report": row(PROBE),
        "probe_source": row(HERE / "probe_owned_suspended_launch.py"), "preparer": row(Path(__file__).resolve()),
        "current_runner_unchanged": RUNNER.read_bytes() == original,
        "current_plan_unchanged": (FIXTURE / "plan.json").read_bytes() == old_plan,
        "sourcepin_amendments": ["Update plan.runner SHA256/bytes to proposed runner", "Add plan.launcher_helper exact path/SHA256/bytes and verify before launching", "Add plan.launcher_probe_report exact path/SHA256/bytes and verify before launching"],
        "documented_apis": [
            "https://learn.microsoft.com/en-us/windows/win32/procthread/process-creation-flags",
            "https://learn.microsoft.com/en-us/windows/win32/api/jobapi2/nf-jobapi2-assignprocesstojobobject",
            "https://learn.microsoft.com/en-us/windows/win32/api/tlhelp32/nf-tlhelp32-thread32first",
            "https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-openthread",
            "https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getprocessidofthread",
            "https://learn.microsoft.com/en-us/windows/win32/api/jobapi/nf-jobapi-isprocessinjob",
            "https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-resumethread"],
        "Editor_launched": False, "compiler_launched": False, "SDK_child_launched": False, "Main_modified": False,
        "limitations": ["Benign proof covers the helper's success and injected assignment-failure paths; it does not claim Unity or shader import passed.", "Existing fixture limits, matching-version checks, observation requirements and CLI quoting remain unchanged."]}
    (out / "report.json").write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"status": report["status"], "report": str(out / "report.json"), "helper_sha256": report["launcher_helper"]["sha256"]}))


if __name__ == "__main__":
    main()
