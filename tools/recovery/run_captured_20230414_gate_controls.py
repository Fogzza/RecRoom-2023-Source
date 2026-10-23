"""Execute only extracted compatibility predicates, in an owned 256 MiB Node job.

No Worker module, credential helper, network client, Editor, or SDK is executed.
"""
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
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
CAPTURE = WS / 'Rebuild/LiveCloudflareSnapshot/current-source-refresh-20261022T205414Z-a85f3d3f'
REVIEW = CAPTURE / 'PrivatePhotonScope/Review20230414-20261022T210257Z-bbe99009'
REVIEW_SHA = 'c5bd93698cbbeadc435fea618f5421b82b8be3b4db1404897e27efabd6953818'
LAUNCHER_SHA = '3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
NODE = Path('C:/Program Files/nodejs/node.exe')
CAP = 256 * 1024**2
RESERVE = int(1.5 * 1024**3)


def need(value, message):
    if not value:
        raise RuntimeError(message)


def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()


def save(path, value):
    with path.open('xb') as stream:
        stream.write(value.encode('utf-8') if isinstance(value, str) else (json.dumps(value, indent=2) + '\n').encode('utf-8'))


def extract(source, first, last, maximum):
    need(source.count(first) == 1, 'Unique extracted gate start required')
    start = source.index(first)
    end = source.index(last, start)
    value = source[start:end]
    need(0 < len(value) <= maximum, 'Only the bounded predicate fragment may be executed')
    need(not any(text in value for text in ('fetch(', 'require(', 'import(', 'process.', 'Deno.', 'XMLHttpRequest', 'WebSocket')), 'Predicate fragment contains an unexpected capability')
    return value


HARNESS = r'''"use strict";
const fs = require("node:fs"), vm = require("node:vm"), assert = require("node:assert/strict");
const input = JSON.parse(fs.readFileSync(process.argv[2], "utf8"));
const out = process.argv[3];
const AFTER = Date.parse("2026-10-22T21:00:00Z"), BEFORE = Date.parse("2026-10-03T01:19:59Z");
const pieces = {};
for (const [key, value] of Object.entries(input.fragments)) {
  const source = fs.readFileSync(value.path, "utf8");
  assert(source.length > 0 && source.length < 4096);
  pieces[key] = source;
}
function context(now) {
  class ControlledDate extends Date { static now() { return now; } }
  return vm.createContext({Date:ControlledDate, H:{info(){}}}, {codeGeneration:{strings:false,wasm:false}});
}
function auth(name, c) {
  const cx = context(c.beforeCutoff ? BEFORE : AFTER);
  cx.form = {};
  if (c.hasVer) cx.form.ver = c.ver;
  if (c.hasGrant) cx.form.grant_type = c.grant;
  let logs = 0;
  cx.H = {info(){logs++;}};
  cx.request = {req:{header(key){
    if (key === "user-agent") return c.ua;
    if (key === "x-recroom-client-version") return c.spoofHeader;
    return undefined;
  }},json(body,status){assert.equal(body.error,"invalid_grant");return {status,error:body.error};}};
  vm.runInContext(pieces[name],cx,{timeout:100});
  const result = vm.runInContext("__nx23Refuse(request, form)",cx,{timeout:100});
  assert(logs === (result === null ? 0 : 1));
  return result === null ? "continue_existing_authentication" : "version_refusal_400";
}
function api(name,c) {
  const cx = context(c.beforeCutoff ? BEFORE : AFTER);
  cx.queryVersion = c.hasVer ? c.ver : undefined;
  cx.spoofHeader = c.spoofHeader;
  vm.runInContext(pieces.apiAllowlist + pieces[name],cx,{timeout:100});
  return vm.runInContext("Qb(queryVersion) && !__nx23Vc(queryVersion) ? 0 : 1",cx,{timeout:100});
}
const cases = [
  {name:"exact20230414",hasVer:true,ver:"20230414",changes:true},
  {name:"other2023June",hasVer:true,ver:"20230616"},
  {name:"other2023December",hasVer:true,ver:"20231207"},
  {name:"2023Unlisted",hasVer:true,ver:"20230101"},
  {name:"suffix",hasVer:true,ver:"20230414.0"},
  {name:"leadingSpace",hasVer:true,ver:" 20230414"},
  {name:"trailingSpace",hasVer:true,ver:"20230414 "},
  {name:"numeric20230414",hasVer:true,ver:20230414},
  {name:"2026EightDigits",hasVer:true,ver:"20260323"},
  {name:"2026TenDigits",hasVer:true,ver:"2026032301"},
  {name:"2026DotVersion",hasVer:true,ver:"20260323.01"},
  {name:"2025Version",hasVer:true,ver:"20250718.01"},
  {name:"missing",hasVer:false},
  {name:"empty",hasVer:true,ver:""},
  {name:"null",hasVer:true,ver:null},
  {name:"invalid",hasVer:true,ver:"invalid"},
  {name:"missingSpoofVersionHeader",hasVer:false,spoofHeader:"20230414"},
  {name:"precutoff20230414",hasVer:true,ver:"20230414",beforeCutoff:true}
];
const authRows=[],apiRows=[];
for (const base of cases) {
  const c={ua:"BestHTTP",hasGrant:true,grant:"password",...base};
  const before=auth("authOriginal",c),candidate=auth("authCandidate",c);
  assert.equal(before !== candidate,!!c.changes,c.name);
  if(c.changes){assert.equal(before,"version_refusal_400");assert.equal(candidate,"continue_existing_authentication");}
  authRows.push({case:c.name,before,candidate,passed:true});
  const apiBefore=api("apiOriginal",c),apiCandidate=api("apiCandidate",c);
  assert.equal(apiBefore !== apiCandidate,!!c.changes,c.name);
  if(c.changes){assert.equal(apiBefore,1);assert.equal(apiCandidate,0);}
  apiRows.push({case:c.name,before:apiBefore,candidate:apiCandidate,passed:true});
}
for (const c of [
 {name:"missingRefresh",hasVer:false,hasGrant:true,grant:"refresh_token",ua:"BestHTTP"},
 {name:"missingBrowser",hasVer:false,hasGrant:true,grant:"password",ua:"Mozilla"},
 {name:"missingGrantType",hasVer:false,hasGrant:false,ua:"BestHTTP"},
 {name:"missingUserAgent",hasVer:false,hasGrant:true,grant:"password"},
 {name:"exactRefresh",hasVer:true,ver:"20230414",hasGrant:true,grant:"refresh_token",ua:"BestHTTP",changes:true}
]) {
 const before=auth("authOriginal",c),candidate=auth("authCandidate",c);
 assert.equal(before !== candidate,!!c.changes,c.name);
 authRows.push({case:c.name,before,candidate,passed:true});
}
const report={schema:"actual-extracted-compatibility-predicate-controls/v1",status:"passed",
 proofKind:"Actual captured original and staged candidate predicate functions executed in Node vm with controlled Date/request/logger/JSON mocks; API Qb is the exact captured allowlist function.",
 wholeWorkerExecuted:false,networkCalled:false,credentialHelperCalled:false,SDKCalled:false,
 authenticationGrantOrCredentialOrBanOrMFAOrAntiCheatRuntimeTested:false,
 authenticationScope:"A null return only continues the unchanged existing authentication pipeline; it is not authentication success.",
 auth:authRows,api:apiRows};
fs.writeFileSync(out,JSON.stringify(report,null,2)+"\n",{flag:"wx"});
process.stdout.write(JSON.stringify({status:"passed",authCases:authRows.length,apiCases:apiRows.length})+"\n");
'''


def main():
    need(os.name == 'nt', 'Windows owned job required')
    need(sha(REVIEW / 'review-report.json') == REVIEW_SHA, 'Pinned candidate review changed')
    need(sha(HERE / 'owned_suspended_launch.py') == LAUNCHER_SHA, 'Reviewed owned launcher changed')
    review = json.loads((REVIEW / 'review-report.json').read_bytes())
    originals = {'auth': (CAPTURE / 'PrivatePhotonScope/auth/auth.app.js', '119b5549c2fd6067fe59fa73858273abfdd3ce86041e52bd94789bcd5afdfd47'),
                 'api': (CAPTURE / 'PrivatePhotonScope/api/studio_api.app.js', '9868eefc4139e8de488a3e0fc94ae97f79b04f187179823e9955d55aa04d5a5c')}
    sources = {}
    for worker, (original, digest) in originals.items():
        candidate = Path(review['candidates'][worker]['path'])
        need(sha(original) == digest and sha(candidate) == review['candidates'][worker]['sha256'], 'Pinned predicate source changed')
        sources[worker + 'Original'] = original.read_text(encoding='utf-8')
        sources[worker + 'Candidate'] = candidate.read_text(encoding='utf-8')
    stamp = dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]
    out = REVIEW / ('ActualGateControls-' + stamp)
    out.mkdir(mode=0o700)
    save(out / '.gitignore', '*\n')
    fragments = {}
    for key, source in sources.items():
        value = extract(source, 'var __NX23_OFF_AT', 'async function a_' if key.startswith('auth') else '__name(__nx23Vc', 2048)
        path = out / (key + '.js')
        save(path, value)
        fragments[key] = {'path': str(path), 'sha256': sha(path), 'bytes': path.stat().st_size}
    path = out / 'apiAllowlist.js'
    save(path, extract(sources['apiOriginal'], 'var Ut =', '__name(Qb', 1024))
    fragments['apiAllowlist'] = {'path': str(path), 'sha256': sha(path), 'bytes': path.stat().st_size}
    save(out / 'fragments.json', {'fragments': fragments})
    save(out / 'controls.cjs', HARNESS)
    sys.path.insert(0, str(ROOT / 'Tools'))
    from export_bundle_batches import ChildJob, ExtendedJob
    from guarded_cpp2il import memory
    from owned_suspended_launch import launch_suspended_in_job
    need(memory().available_commit >= CAP + RESERVE, '256MiB job plus 1.5GiB reserve admission refused')
    job, child = ChildJob(), None
    report = {'schema': 'owned-extracted-gate-control-run/v1', 'status': 'starting', 'cap_bytes': CAP, 'reserve_bytes': RESERVE,
              'Main_changed': False, 'network_called': False, 'whole_Worker_executed': False,
              'review_sha256': REVIEW_SHA, 'tool_sha256': sha(__file__), 'node_sha256': sha(NODE), 'fragments': fragments}
    try:
        limits = ExtendedJob()
        limits.basic.flags = 0x2000 | 0x200
        limits.job_memory = CAP
        need(job.kernel.SetInformationJobObject(job.handle, 9, ctypes.byref(limits), ctypes.sizeof(limits)), 'Cannot set owned job cap')
        env = {key: value for key, value in os.environ.items() if key.upper() not in ('NODE_OPTIONS', 'NODE_PATH')}
        command = [str(NODE), '--max-old-space-size=96', '--no-addons', str(out / 'controls.cjs'), str(out / 'fragments.json'), str(out / 'actual-controls.json')]
        report['command'] = command
        started = time.monotonic()
        with (out / 'private-stdout.log').open('xb') as stdout, (out / 'private-stderr.log').open('xb') as stderr:
            child, report['launcher'] = launch_suspended_in_job(command, job=job, cwd=out, stdout=stdout, stderr=stderr, env=env)
            while child.poll() is None:
                need(time.monotonic() - started < 20 and memory().available_commit >= RESERVE, 'Owned job wall/memory guard reached')
                time.sleep(.05)
        report['exit_code'] = child.returncode
        query = job.kernel.QueryInformationJobObject
        query.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_void_p, ctypes.c_uint32, ctypes.c_void_p]
        query.restype = ctypes.c_int
        final = ExtendedJob()
        need(query(job.handle, 9, ctypes.byref(final), ctypes.sizeof(final), None), 'Cannot query owned job memory')
        report['peak_job_bytes'] = int(final.peak_job)
        need(child.returncode == 0, 'Extracted predicate controls failed; private process logs retained')
        result = out / 'actual-controls.json'
        need(result.is_file() and result.stat().st_size <= 64 * 1024, 'Bounded actual control report required')
        data = json.loads(result.read_bytes())
        need(data.get('status') == 'passed', 'Extracted predicate result did not pass')
        report.update(status='passed', controls_path=str(result), controls_sha256=sha(result), auth_cases=len(data['auth']), API_cases=len(data['api']))
    except BaseException as error:
        report['status'] = 'failed'
        report['local_error'] = str(error)
        raise
    finally:
        job.close()
        if child is not None:
            report['owned_child_exit_confirmed'] = child.wait(timeout=10) is not None
        save(out / 'run-report.json', report)
    print(json.dumps({'status': report['status'], 'report': str(out / 'run-report.json'), 'report_sha256': sha(out / 'run-report.json'),
                      'auth_cases': report['auth_cases'], 'API_cases': report['API_cases'], 'peak_job_bytes': report['peak_job_bytes'],
                      'network_called': False, 'whole_Worker_executed': False}))


if __name__ == '__main__':
    main()
