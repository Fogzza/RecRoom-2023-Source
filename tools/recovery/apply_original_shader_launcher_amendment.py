"""Apply only the reviewed fixture runner/plan; recheck original Shader data, never run it."""
from pathlib import Path
import ast
import datetime as dt
import hashlib
import json
import os
import re
import struct
import sys
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / "Recovery/RecRoom-2023-04-18"
sys.path[:0] = [str(HERE), str(ROOT / "Tools")]
import repair_rr23_wav_headers as safety
from compare_shader_parsed_form import compare, field_lines
from stage_original_stencil_shader import spans, strip_fields, NAMES

PROPOSAL = ROOT / "AssetRecovery/OriginalShaderSuspendedLaunchProposal-20261022T195938Z-57f73e9e"
FIXTURE = ROOT / "AssetRecovery/OriginalStencilImportFixture-20261022T194521Z-be9d6ebe"
CANDIDATE = ROOT / "AssetRecovery/OriginalStencilShaderCandidate-20261022T193440Z-99839b22"


def need(value, message):
    if not value:
        raise RuntimeError(message)


def sha(path):
    with Path(path).open("rb") as stream:
        return hashlib.file_digest(stream, "sha256").hexdigest()


def pin(path):
    safety.assert_no_reparse(path)
    return {"path": str(path), "sha256": sha(path), "bytes": Path(path).stat().st_size}


def check(row, actual=None):
    path = Path(row["path"]) if actual is None else actual
    safety.assert_no_reparse(path)
    need(path.is_file() and sha(path) == row["sha256"], "Pinned input changed: " + str(path))


def data_proof(plan):
    staged = json.loads((CANDIDATE / "report.json").read_bytes())
    for key in ("model_input", "original_object", "original_parsed_form", "difference_classification", "Main_before", "Main_meta_before", "candidate", "candidate_meta"):
        check(staged[key])
    for row in staged["serialization_rule_sources"]:
        check(row)
    asset = Path(staged["candidate"]["path"])
    meta = Path(staged["candidate_meta"]["path"])
    model_path = Path(staged["model_input"]["path"])
    model = json.loads(model_path.read_bytes())
    need(model["status"] == "parsed_entire_original_object" and model["consumed_bytes"] == model["total_bytes"] == 102516 and model["engine"] == "2020.3.33f1" and model["no_pointer_yaml"], "Full exact original Shader object model proof required")
    check(model["parsed_form"])
    raw, baseline = asset.read_bytes(), Path(staged["Main_before"]["path"]).read_bytes()
    blocks, old_blocks = spans(raw), spans(baseline)
    form = compare(Path(model["parsed_form"]["path"]), asset)
    need(form["status"] == "exact" and form["original"]["lines"] == form["current"]["lines"] == 8629, "Entire original ParsedForm must match exactly")
    fields = model["fields"]
    def uints(value):
        return [row[0] for row in struct.iter_unpack("<I", bytes.fromhex(value))]
    platforms = uints(raw[slice(*blocks["platforms"])].decode().strip().split(":", 1)[1].strip())
    need(platforms == fields["Platforms"] == [4], "Original platform array changed")
    arrays = {}
    for name, key in [("offsets", "Offsets"), ("compressedLengths", "CompressedLengths"), ("decompressedLengths", "DecompressedLengths")]:
        lines = raw[slice(*blocks[name])].decode().splitlines()[1:]
        arrays[name] = [uints(line.strip()[1:].strip()) for line in lines]
        need(arrays[name] == fields[key + "_AssetList_AssetList_UInt32"], "Original program range array changed: " + name)
    blob = bytes.fromhex(raw[slice(*blocks["compressedBlob"])].decode().strip().split(":", 1)[1].strip())
    blob_path = model_path.parent / "original-compressedBlob.bin"
    original_object = Path(model["source"]).read_bytes()
    need(len(blob) == fields["compressedBlob"]["bytes"] == 61761 and hashlib.sha256(blob).hexdigest() == fields["compressedBlob"]["sha256"] and blob == blob_path.read_bytes(), "Full original program bytes changed")
    offset = original_object.find(blob)
    need(offset >= 0 and original_object.find(blob, offset + 1) < 0, "Original compiled blob must be a unique unchanged contiguous source span")
    need(strip_fields(raw) == strip_fields(baseline), "Bytes outside original six fields changed")
    dependency = raw[slice(*blocks["m_Dependencies"])]
    need(dependency == baseline[slice(*old_blocks["m_Dependencies"])], "Original fallback PPtr block changed")
    config = json.loads(Path(plan["expected_data"]["path"]).read_bytes())
    dep_guid = config["dependency_guid"]
    need(dep_guid.encode() in dependency and config["expected_guid"].encode() in meta.read_bytes(), "Original Shader and fallback GUID identities changed")
    need(meta.read_bytes() == Path(staged["Main_meta_before"]["path"]).read_bytes(), "Original meta bytes changed")
    fixture_asset = Path(plan["project"]) / config["asset_path"]
    fixture_meta = Path(str(fixture_asset) + ".meta")
    fallback = Path(plan["project"]) / config["dependency_path"]
    fallback_meta = Path(str(fallback) + ".meta")
    main_fallback = WS / "RR23" / config["dependency_path"]
    need(fixture_asset.read_bytes() == raw and fixture_meta.read_bytes() == meta.read_bytes(), "Fixture original candidate/meta copies changed")
    need(fallback.read_bytes() == main_fallback.read_bytes() and fallback_meta.read_bytes() == Path(str(main_fallback) + ".meta").read_bytes(), "Original fallback copy/meta changed")
    need(sha(fallback) == config["dependency_sha256"] and sha(fallback_meta) == config["dependency_meta_sha256"] and dep_guid.encode() in fallback_meta.read_bytes(), "Exact original fallback source/meta/GUID pins changed")
    lines = field_lines(asset, "m_ParsedForm")
    need(sum("m_GlobalKeywordMask:" in line and line.split(":", 1)[1].strip() != "" for line in lines) == 7, "Original nonempty keyword masks changed")
    return {"schema": "reconfirmed-six-original-shader-fields-and-meta/v1", "status": "original_data_reconfirmed_not_imported", "entire_parsed_form": form,
            "program_fields": {"platforms": platforms, **arrays, "compressedBlob": {"bytes": len(blob), "sha256": hashlib.sha256(blob).hexdigest(), "original_object_unique_byte_offset": offset}},
            "all_bytes_outside_six_fields_exact": True, "all7_original_keyword_masks_retained": True, "original_dependency_pptr_exact": True,
            "original_shader_meta_all_bytes_exact": True, "fixture_candidate_and_meta_exact_copies": True,
            "original_fallback_and_meta_exact_copies": True, "fallback_GUID": dep_guid, "fallback_asset": pin(fallback), "fallback_meta": pin(fallback_meta),
            "candidate": pin(asset), "candidate_meta": pin(meta), "original_model": pin(model_path), "original_object": pin(Path(model["source"])),
            "Editor_import_or_GPU_support_proven": False, "Main_modified": False}


def main():
    frozen = pin(PROPOSAL / "report.json")
    proposal = json.loads((PROPOSAL / "report.json").read_bytes())
    for key in ("original_runner", "original_plan", "proposed_runner", "proposed_plan", "patch", "launcher_helper", "benign_probe_report", "probe_source", "preparer"):
        check(proposal[key])
    runner, plan_path = Path(proposal["original_runner"]["path"]), Path(proposal["original_plan"]["path"])
    original_runner, original_plan = runner.read_bytes(), plan_path.read_bytes()
    new_runner = Path(proposal["proposed_runner"]["path"]).read_bytes()
    new_plan = Path(proposal["proposed_plan"]["path"]).read_bytes()
    ast.parse(new_runner.decode("utf-8"), filename=str(runner))
    plan, before_plan = json.loads(new_plan), json.loads(original_plan)
    for name in ("project", "fixture", "inputs", "read_only_sources", "expected_data", "compiler", "compiler_references", "compiler_response", "editor", "cli", "planned_sessions", "maximum_owned_job_bytes", "minimum_system_commit_reserve_bytes"):
        need(plan[name] == before_plan[name], "Tool-only amendment changed fixture inputs/policy: " + name)
    pinned = [plan["runner"], plan["launcher_helper"], plan["launcher_probe_report"], plan["editor"], plan["cli"], plan["candidate_report"], plan["candidate_readiness"], plan["compiler"], plan["compiler_response"]] + plan["inputs"] + plan["read_only_sources"] + plan["compiler_references"]
    for row in pinned:
        check(row, Path(proposal["proposed_runner"]["path"]) if Path(row["path"]) == runner else None)
    proof = data_proof(plan)
    out = ROOT / "AssetRecovery" / ("OriginalShaderSuspendedLaunchApplied-" + dt.datetime.now(dt.timezone.utc).strftime("%Y%m%dT%H%M%SZ") + "-" + uuid.uuid4().hex[:8])
    out.mkdir()
    backup = out / "Backup"
    backup.mkdir()
    (backup / runner.name).write_bytes(original_runner)
    (backup / "plan.json").write_bytes(original_plan)
    need(sha(backup / runner.name) == proposal["original_runner"]["sha256"] and sha(backup / "plan.json") == proposal["original_plan"]["sha256"], "Exact original tool/plan backup required")
    for target, before, after in ((runner, original_runner, new_runner), (plan_path, original_plan, new_plan)):
        safety.assert_no_reparse(target)
        need(target.read_bytes() == before, "Target changed before tool-only apply")
        temporary = out / (target.name + ".apply.tmp")
        temporary.write_bytes(after)
        os.replace(temporary, target)
    need(sha(runner) == proposal["proposed_runner"]["sha256"] and sha(plan_path) == proposal["proposed_plan"]["sha256"], "Applied tool/plan bytes differ")
    need(sha(PROPOSAL / "report.json") == frozen["sha256"], "Frozen proposal receipt changed")
    for row in pinned:
        check(row)
    (out / "original-data-reconfirmation.json").write_bytes((json.dumps(proof, indent=2) + "\n").encode("utf-8"))
    command = [sys.executable, "-B", str(runner), "--fixture", str(FIXTURE), "--run"]
    result = {"schema": "applied-original-shader-assign-before-resume-tool-amendment/v1", "status": "runner_plan_applied_fixture_not_launched",
              "runner": pin(runner), "plan": pin(plan_path), "frozen_proposal_receipt": frozen, "frozen_proposal_receipt_unchanged": True,
              "backups": [pin(backup / runner.name), pin(backup / "plan.json")], "verified_prospective_source_pin_rows": len(pinned),
              "original_data_reconfirmation": pin(out / "original-data-reconfirmation.json"), "launcher_helper": pin(Path(plan["launcher_helper"]["path"])),
              "ready_command_after_parent_build_and_editor_exit": command,
              "launch_policy": {"matching_source_compile_job_bytes": 268435456, "Editor_job_bytes": 1073741824, "minimum_commit_reserve_bytes": 1610612736, "two_fresh_sessions": ["import", "reload"]},
              "Main_modified": False, "fixture_Project_modified": False, "Editor_launched": False, "compiler_launched": False, "fixture_executed": False,
              "full_parent_build_active_during_tool_only_apply": True, "tool": pin(Path(__file__)), "finished_utc": dt.datetime.now(dt.timezone.utc).isoformat()}
    (out / "report.json").write_bytes((json.dumps(result, indent=2) + "\n").encode("utf-8"))
    print(json.dumps({"status": result["status"], "report": str(out / "report.json"), "verified_pins": len(pinned), "Main_modified": False, "fixture_executed": False}))


if __name__ == "__main__":
    main()
