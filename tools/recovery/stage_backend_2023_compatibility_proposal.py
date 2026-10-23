"""Stage an exact 20230414 shutdown-gate exception; never deploy or edit snapshots."""
from pathlib import Path
import argparse
import ctypes
import datetime as dt
import difflib
import hashlib
import json
import mmap
import re
import shutil
import struct
import subprocess
import sys
import time
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / "Recovery/RecRoom-2023-04-18"
sys.path[:0] = [str(HERE), str(ROOT / "Tools"), str(HERE.parent / "ConstructorEvidence")]
SNAPSHOT = WS / "Rebuild/LiveCloudflareSnapshot/deployed/auth/src/auth.app.js"
CONFIG = SNAPSHOT.parents[1] / "wrangler.jsonc"
EXPECTED = "afefdae9437c892c2d817168a5ff591806f7be616b04bb91c55ef50e7875de28"
CAP = 256 * 1024**2
RESERVE = int(1.5 * 1024**3)


def need(value, message):
    if not value:
        raise RuntimeError(message)


def sha(path):
    return hashlib.sha256(Path(path).read_bytes()).hexdigest()


def pin(path):
    return {"path": str(path), "sha256": sha(path), "bytes": Path(path).stat().st_size}


def native_contract(out):
    # Read original files as data. Only the already pinned trusted Capstone decoder
    # is loaded; no original native or managed game code is executed.
    from collect_all_pinvoke_native import ExternMetadata
    from inventory_recroom_game_root_native import region
    from audit_native_nameserver_router import Disassembler, CAP as DECODER, CAPSHA
    paths = [ROOT / "VerifiedSource/GameAssembly.dll", ROOT / "VerifiedSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat"]
    before = [(p.stat().st_size, p.stat().st_mtime_ns) for p in paths]
    wanted = [(195787, None), (195794, None), (117176, (0x182519FFB, 0x18251A081)),
              (119807, (0x1836EA343, 0x1836EA3FD))]
    records = []
    decoder = Disassembler()
    try:
        with paths[0].open("rb") as bf, paths[1].open("rb") as mf, mmap.mmap(bf.fileno(), 0, access=mmap.ACCESS_READ) as binary, mmap.mmap(mf.fileno(), 0, access=mmap.ACCESS_READ) as metadata:
            view = ExternMetadata(binary, metadata)
            for index, span in wanted:
                method = view.method_info(index)
                va = view.method_pointer(method)
                native = region(view, va)
                decoded = decoder.decode(bytes.fromhex(native["bytes"]), va)
                selected = [r for r in decoded if span is None or span[0] <= int(r["VA"], 16) < span[1]]
                records.append({"original": method, "VA": hex(va), "whole_runtime_region_sha256": native["sha256"],
                                "whole_runtime_region_bytes": len(bytes.fromhex(native["bytes"])),
                                "selected_instruction_span_only": span is not None, "instructions": selected})
            method = view.method_info(113053)
            slot = view.u16(metadata, view.row("methods", 113053, 32) + 28)
            need(method["owner"] == "CNPIGGEIBGB" and method["name"] == "PAKNGFLMDPE" and slot == 0, "Exact original version interface slot")
            at = view.row("stringLiteral", 3451, 8)
            length, offset = struct.unpack_from("<ii", metadata, at)
            start, size = view.tables["stringLiteralData"]
            literal = bytes(metadata[start + offset:start + offset + length]).decode("utf-8")
            need(literal == "20230414", "Exact original protocol version literal")
    finally:
        decoder.close()
    need(before == [(p.stat().st_size, p.stat().st_mtime_ns) for p in paths], "Original source stats changed")
    result = {"schema": "original-network-version-bounded-static-dataflow/v1", "original_default_windows_protocol_version": "20230414",
              "original_literal_index": 3451, "interface_method": method, "interface_slot": slot, "methods": records,
              "trusted_decoder": {"path": str(DECODER), "sha256": CAPSHA},
              "source_paths": [str(p) for p in paths], "source_stats_unchanged": True,
              "whole_original_files_rehashed_in_this_small_probe": False,
              "interpretation": ["Original IDDIAODMAPP.PAKNGFLMDPE lazily caches exact original literal 20230414 in its static field.",
                "Original nested ONPIJEFNLPD.PAKNGFLMDPE tailcalls that getter and implements CNPIGGEIBGB slot 0.",
                "Original auth LoginHelper invokes interface slot 0 and supplies its result as the form value for literal ver.",
                "Original versioncheck invokes the same slot 0 and supplies its result for query key v.",
                "The original default protocol version is independent of PlayerSettings.bundleVersion; platform/version override routines are separate.",
                "Current recovered source has stubbed getter/static initialization. This evidence does not claim that a current build sends the original value or performs requests."],
              "game_or_managed_original_code_executed": False, "network_requests": 0, "Main_modified": False}
    path = out / "original-network-contract.json"
    path.write_text(json.dumps(result, indent=2) + "\n", encoding="utf-8")
    return path


TEST = r'''import fs from 'node:fs';
import vm from 'node:vm';
import assert from 'node:assert/strict';
const dir = process.argv[2];
const original = fs.readFileSync(dir + '/shutdown-gate.original.js', 'utf8');
const proposed = fs.readFileSync(dir + '/shutdown-gate.proposed.js', 'utf8');
function call(source, body, ua, now) {
  class ProbeDate extends Date { static now() { return now; } }
  const context = {Date: ProbeDate, H: {info() {}}};
  vm.runInNewContext(source + ';globalThis.invoke=__nx23Refuse;', context, {timeout: 1000});
  const ctx = {req: {header: name => name === 'user-agent' ? ua : ''}, json: (body, status) => ({body, status})};
  const result = context.invoke(ctx, body);
  return result === null ? null : JSON.parse(JSON.stringify(result));
}
const cutoff = Date.parse('2026-10-03T01:20:00Z');
const after = cutoff + 1;
const cases = [
  ['exact original protocol', {ver:'20230414'}, 'BestHTTP', after, 'exception'],
  ['exact cached login', {ver:'20230414',grant_type:'cached_login'}, 'BestHTTP', after, 'exception'],
  ['exact account creation still reaches real auth', {ver:'20230414',grant_type:'create_account'}, 'BestHTTP', after, 'exception'],
  ['exact explicit refresh still reaches real auth', {ver:'20230414',grant_type:'refresh_token'}, 'BestHTTP', after, 'exception'],
  ['different 2023 day', {ver:'20230415'}, 'BestHTTP', after, 'same'],
  ['different 2023 build', {ver:'20231207'}, 'BestHTTP', after, 'same'],
  ['point release not authorized', {ver:'20230414.01'}, 'BestHTTP', after, 'same'],
  ['Xbox suffix not authorized', {ver:'20230414_Xbox'}, 'BestHTTP', after, 'same'],
  ['PS suffix not authorized', {ver:'20230414_PS'}, 'BestHTTP', after, 'same'],
  ['leading whitespace not authorized', {ver:' 20230414'}, 'BestHTTP', after, 'same'],
  ['trailing whitespace not authorized', {ver:'20230414 '}, 'BestHTTP', after, 'same'],
  ['prefix suffix not authorized', {ver:'20230414anything'}, 'BestHTTP', after, 'same'],
  ['numeric type not authorized', {ver:20230414}, 'BestHTTP', after, 'same'],
  ['missing version BestHTTP remains refused', {}, 'BestHTTP/2', after, 'same'],
  ['empty version BestHTTP remains refused', {ver:''}, 'BestHTTP/2', after, 'same'],
  ['missing refresh keeps original behavior', {grant_type:'refresh_token'}, 'BestHTTP/2', after, 'same'],
  ['non game caller keeps original behavior', {}, 'Mozilla/5.0', after, 'same'],
  ['malformed version keeps original behavior', {ver:'invalid'}, 'BestHTTP/2', after, 'same'],
  ['2025 behavior unchanged', {ver:'20250718.01'}, 'BestHTTP', after, 'same'],
  ['2026 display label behavior unchanged not schema approval', {ver:'20261022'}, 'BestHTTP', after, 'same'],
  ['before shutdown unchanged', {ver:'20230414'}, 'BestHTTP', cutoff-1, 'same'],
];
const result = cases.map(([name, body, ua, now, mode]) => {
  const before = call(original, body, ua, now), after = call(proposed, body, ua, now);
  if (mode === 'exception') { assert.equal(before.status, 400); assert.equal(before.body.error, 'invalid_grant'); assert.equal(after, null); }
  else assert.deepEqual(after, before);
  return {name, before_shutdown_gate: before === null ? 'continue_real_auth' : 'refuse', after_shutdown_gate: after === null ? 'continue_real_auth' : 'refuse', passed:true};
});
fs.writeFileSync(dir+'/pure-logic-test-results.json', JSON.stringify({schema:'narrow-20230414-shutdown-exception-pure-logic/v1',status:'passed',cases:result,network_requests:0,real_auth_or_JWT_or_DB_invoked:false},null,2)+'\n');
console.log(JSON.stringify({status:'passed',cases:result.length,network_requests:0,real_auth_or_JWT_or_DB_invoked:false}));
'''


def test(out):
    from export_bundle_batches import ChildJob, ExtendedJob
    from guarded_cpp2il import memory
    from owned_suspended_launch import launch_suspended_in_job
    node = shutil.which("node")
    need(node is not None, "Local Node unavailable; proposal retained untested")
    available = memory().available_commit
    need(available >= CAP + RESERVE, "256MiB pure-logic job plus1.5GiB reserve refused")
    job = ChildJob()
    limits = ExtendedJob()
    limits.basic.flags = 0x2000 | 0x200
    limits.job_memory = CAP
    need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), "Cannot set tiny Node owned-job cap")
    child = None
    record = {"cap_bytes": CAP, "reserve_bytes": RESERVE, "admission_available_commit": available, "network_requests": 0}
    try:
        with (out / "pure-logic-node.log").open("xb") as log:
            child, launch = launch_suspended_in_job([node, "--max-old-space-size=96", str(out / "pure-logic-matrix.mjs"), str(out)], job=job, cwd=out, stdout=log, stderr=subprocess.STDOUT)
            record["launch"] = launch
            started = time.monotonic()
            while child.poll() is None:
                need(memory().available_commit >= RESERVE and time.monotonic() - started <= 15, "Tiny pure-logic Node memory/time guard")
                time.sleep(.02)
            record["exit_code"] = child.returncode
            need(child.returncode == 0, "Pure-logic controls failed")
        query = job.kernel.QueryInformationJobObject
        query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_ulong, ctypes.c_void_p]
        query.restype = ctypes.c_int
        need(query(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits), None), "Cannot query owned Node telemetry")
        record["peak_job_bytes"] = int(limits.peak_job)
        need(record["peak_job_bytes"] <= CAP, "Tiny Node job cap exceeded")
        record["results"] = pin(out / "pure-logic-test-results.json")
    finally:
        job.close()
        if child is not None:
            child.wait(timeout=10)
        (out / "pure-logic-run-report.json").write_text(json.dumps(record, indent=2) + "\n", encoding="utf-8")
    return out / "pure-logic-run-report.json"


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--run-controlled-pure-logic-test", action="store_true")
    args = parser.parse_args()
    need(sha(SNAPSHOT) == EXPECTED, "Read-only deployed source snapshot changed")
    original_bytes = SNAPSHOT.read_bytes()
    original = original_bytes.decode("utf-8")
    start = original.index("var __NX23_OFF_AT=")
    end = original.index("async function a_(", start)
    gate = original[start:end]
    anchor = 'if(b!==null&&b>=20230000&&b<20240000)why="ver";'
    need(gate.count(anchor) == 1, "Exact deployed shutdown gate shape required")
    changed_gate = gate.replace(anchor, 'if(v==="20230414")return null;' + anchor)
    proposed = original[:start] + changed_gate + original[end:]
    need(proposed.replace(changed_gate, gate, 1) == original, "Only exact shutdown compatibility condition may differ")
    out = ROOT / "Validation" / ("Backend2023CompatibilityProposal-" + dt.datetime.now(dt.timezone.utc).strftime("%Y%m%dT%H%M%SZ") + "-" + uuid.uuid4().hex[:8])
    out.mkdir()
    (out / "shutdown-gate.original.js").write_text(gate + "\n", encoding="utf-8")
    (out / "shutdown-gate.proposed.js").write_text(changed_gate + "\n", encoding="utf-8")
    (out / "auth.app.proposed.js").write_bytes(proposed.encode("utf-8"))
    need((out / "auth.app.proposed.js").read_bytes() == proposed.encode("utf-8"), "Exact proposed worker bytes required")
    (out / "auth-exact-20230414-compatibility.patch").write_bytes("".join(difflib.unified_diff(original.splitlines(keepends=True), proposed.splitlines(keepends=True), fromfile="a/auth.app.js", tofile="b/auth.app.js")).encode("utf-8"))
    (out / "pure-logic-matrix.mjs").write_text(TEST, encoding="utf-8")
    contract = native_contract(out)
    report = {"schema": "exact-existing-backend-20230414-compatibility-proposal/v1", "status": "prepared_not_deployed",
              "temporary_nameserver": "https://ns.nerlz.com", "worker": "auth", "worker_origin": "https://auth.nerlz.com",
              "snapshot": pin(SNAPSHOT), "snapshot_configuration": pin(CONFIG), "source_metadata_witness": pin(WS / "Rebuild/CloudflareMigration/20261022T033530Z/source-metadata.json"),
              "source_config_inventory_witness": pin(WS / "Rebuild/CloudflareCopyPlan-20261022T033507Z/source-config-schema-inventory.json"),
              "source_snapshot_is_historical_not_a_fresh_remote_check": True,
              "original_network_contract": pin(contract), "original_default_protocol_version": "20230414", "requested_display_build_label": "20261022",
              "current_recovered_outgoing_ver_proven": False,
              "compatibility_entry": {"exact_full_auth_ver": "20230414", "effect": "Only continue past __nx23Refuse shutdown check into unchanged real authentication", "tokens_or_account_access_granted_by_this_condition": False},
              "proposed_worker": pin(out / "auth.app.proposed.js"), "patch": pin(out / "auth-exact-20230414-compatibility.patch"),
              "gate_original": pin(out / "shutdown-gate.original.js"), "gate_proposed": pin(out / "shutdown-gate.proposed.js"), "pure_logic_test": pin(out / "pure-logic-matrix.mjs"),
              "all_other_worker_source_bytes_unchanged": True,
              "preserved": ["Original cutoff and shutdown message", "Other2023 versions including point/platformsuffixes", "Missing-version BestHTTP refusal", "Credential/platform verification, bans, rate limits, signup caps, password checks, JWT and refresh handling", "Existing newer-version response behavior and all service/schema selection"],
              "excluded_wrong_backends": ["Backend/: lunarnet-api /v1 toy protocol on separate account", "Rebuild/BackendCandidate/: public recflare/server template, exact deployed fork not proved; do not deploy it over Nerlz"],
              "root_review_and_control_plan": ["Review the exact added condition and historical snapshot hash; refresh current auth source/config read-only before applying to detect deployment drift.", "Keep ns.nerlz.com until separately reviewed migration; do not change API/ns/schema version handling to20261022.", "Apply only this exact full-ver exception to the deployed auth worker after review, preserving all other worker bytes/bindings/security.", "Keep old deployed auth version/source as rollback; rollback removes only this exact condition.", "Confirm both nameserver-returned auth route and api/versioncheck behavior from actual deployed sources before treating login as enabled.", "Restore original client version/routing/auth request implementation first; current stubs cannot be repaired by this backend entry.", "A gate continuation is not a login/gameplay success; actual authenticated test remains separate and must use the unchanged real auth flow."],
              "pure_logic_tests_run": False, "cloud_mutations": 0, "network_requests": 0, "credentials_or_tokens_logged": False,
              "backend_snapshot_modified": False, "Main_modified": False, "Unity_or_compiler_or_SDK_child_launched": False, "tool": pin(Path(__file__))}
    if args.run_controlled_pure_logic_test:
        proof = test(out)
        report["pure_logic_tests_run"] = True
        report["pure_logic_run"] = pin(proof)
        report["pure_logic_results"] = pin(out / "pure-logic-test-results.json")
    need(SNAPSHOT.read_bytes() == original_bytes, "Deployed snapshot modified")
    (out / "report.json").write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"status": report["status"], "report": str(out / "report.json"), "pure_logic_tests_run": report["pure_logic_tests_run"]}))


if __name__ == "__main__":
    main()
