"""Offline review-only patches from fresh captured deployed modules. No deploy path."""
from pathlib import Path
import argparse
import datetime as dt
import hashlib
import json
import re
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]


def need(value, message):
    if not value:
        raise ValueError(message)


def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()


def row(path):
    path = Path(path).resolve(strict=True)
    return {'path': str(path), 'sha256': sha(path), 'bytes': path.stat().st_size}


def save(path, data):
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open('xb') as stream:
        stream.write(data.encode('utf-8') if isinstance(data, str) else data)


def replace_once(source, before, after):
    need(source.count(before) == 1, 'Expected one exact captured-source anchor')
    candidate = source.replace(before, after, 1)
    need(candidate.replace(after, before, 1) == source, 'All unrelated captured-source bytes must remain exact')
    return candidate


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--capture', type=Path, required=True)
    parser.add_argument('--application', type=Path, required=True)
    args = parser.parse_args()
    capture = args.capture.resolve(strict=True)
    need(capture.is_relative_to(WS / 'Rebuild/LiveCloudflareSnapshot') and capture.name.startswith('current-source-refresh-'), 'Fresh exact captured worker source required')
    private = capture / 'PrivatePhotonScope'
    names = {'ns': ('5', 'ns.app.js'), 'api': ('6', 'studio_api.app.js'), 'auth': ('7', 'auth.app.js'), 'match': ('8', 'match.app.js')}
    modules, input_rows = {}, []
    for worker, (prefix, name) in names.items():
        body = capture / (prefix + '-' + worker + '-source.body.bin')
        http = json.loads((capture / (prefix + '-' + worker + '-source.http.json')).read_bytes())
        need(http['status'] == 200 and sha(body) == http['sha256'], 'Capture source status/hash must be genuine')
        path = private / worker / name
        need(path.stat().st_size <= 8 * 1024**2, 'Bounded captured module required')
        modules[worker] = path.read_text(encoding='utf-8')
        need(path.read_bytes() in body.read_bytes(), 'Extracted module must be exact bytes in captured multipart')
        input_rows += [row(body), row(path)]
    settings_path = capture / '8-match-settings.body.bin'
    settings = json.loads(settings_path.read_bytes())['result']
    binding_rows = {entry['name']: entry for entry in settings['bindings']}
    application = json.loads(args.application.read_bytes())
    ids = {key: str(uuid.UUID(application[key])) for key in ('realtime_app_id', 'voice_app_id')}
    need(ids['realtime_app_id'] != ids['voice_app_id'], 'Operator service IDs must be distinct')
    stamp = dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]
    out = private / ('Review20230414-' + stamp)
    out.mkdir()
    save(out / '.gitignore', '*\n')

    auth_before = 'why=null;if(b!==null&&b>=20230000&&b<20240000)why="ver";'
    auth_after = 'why=null;if(v==="20230414")return null;if(b!==null&&b>=20230000&&b<20240000)why="ver";'
    auth = replace_once(modules['auth'], auth_before, auth_after)
    api_before = '    if (Date.now() < __NX23_OFF_AT) return false;\n    let m = /^(\\d{8})/.exec(String(v ?? "").trim());'
    api_after = '    if (Date.now() < __NX23_OFF_AT) return false;\n    if (v === "20230414") return false;\n    let m = /^(\\d{8})/.exec(String(v ?? "").trim());'
    api = replace_once(modules['api'], api_before, api_after)
    # This draft is deliberately not a deployable candidate: the captured auth
    # worker also stamps browser/MFA tokens with the default20230414 claim.
    match_before = 'let n=bS(e.env),i=await ee(e.env.DB,r),'
    match_after = 'let n=bS(e.env);if(await bm(e.req.raw,await e.env.JWT_SECRET.get())==="20230414"){n={...n,photonRealtimeAppId:' + json.dumps(ids['realtime_app_id']) + ',photonVoiceAppId:' + json.dumps(ids['voice_app_id']) + '}}let i=await ee(e.env.DB,r),'
    match_draft = replace_once(modules['match'], match_before, match_after)
    auth_target = out / 'CandidatesNotDeployed/auth/auth.app.js'
    api_target = out / 'CandidatesNotDeployed/api/studio_api.app.js'
    match_target = out / 'HELD_NOT_FOR_DEPLOYMENT/match.app.js'
    save(auth_target, auth)
    save(api_target, api)
    save(match_target, match_draft)
    save(out / 'HELD_NOT_FOR_DEPLOYMENT/REASON.txt', 'JWT rn.ver20230414 alone does not isolate original2023 clients. Existing browser/MFA and missing-form-ver minting paths default to this same claim. No match/global-binding change may be deployed from this draft. Resolve a distinct signed client/config marker and its refresh/MFA propagation first.\n')

    def auth_gate(version, user_agent='BestHTTP', grant='password', after_cutoff=True, patched=False):
        if not after_cutoff:
            return 'continue_existing_authentication'
        if patched and version == '20230414':
            return 'continue_existing_authentication'
        matched = re.match(r'^(\d{8})', version.strip()) if isinstance(version, str) and version else None
        build = int(matched[1]) if matched else None
        if build is not None and 20230000 <= build < 20240000:
            return 'reject_version_400'
        if version in (None, '') and grant != 'refresh_token' and re.match('BestHTTP', user_agent, re.I):
            return 'reject_missing_legacy_version_400'
        return 'continue_existing_authentication'

    auth_cases = []
    for version, ua, grant, cutoff in [('20230414','BestHTTP','password',True), ('20230616','BestHTTP','password',True), ('20231207','BestHTTP','password',True), ('20230414.0','BestHTTP','password',True), ('2026032301','BestHTTP','password',True), (None,'BestHTTP','password',True), (None,'BestHTTP','refresh_token',True), (None,'Mozilla','password',True), ('20230414','BestHTTP','password',False)]:
        before = auth_gate(version, ua, grant, cutoff)
        after = auth_gate(version, ua, grant, cutoff, True)
        need((before != after) == (version == '20230414' and cutoff), 'Auth version control failed')
        auth_cases.append({'form_ver': version, 'UA_family': ua, 'grant_type': grant, 'after_cutoff': cutoff, 'before': before, 'candidate': after})
    cutoff_values = {}
    for worker in ('auth', 'api'):
        matched = re.search(r'__NX23_OFF_AT\s*=\s*Date\.parse\("([^\"]+)"\)', modules[worker])
        need(matched is not None, 'Current captured version cutoff required')
        cutoff_values[worker] = matched[1]
    need(modules['auth'].count('let me=await nm(D,i,o,ee,ww(j),Sw(j),l,j?.hasPlus===!0)') == 1, 'Current form-grant minting path differs')
    need(modules['auth'].count('await nm(String(acct),j.platformId??"",Ew(j),ee,ww(j),Sw(j),Uo,j?.hasPlus===!0)') == 1, 'Current browser/MFA default-version minting path differs')
    need('a=Uo' in modules['auth'] and 'Uo="20230414"' in modules['auth'], 'Default-version collision proof differs')
    # No captured settings or binding value is copied into stdout or this report.
    comparisons = {'global_Realtime_ID_equals_operator': binding_rows.get('PHOTON_REALTIME_APP_ID', {}).get('text') == ids['realtime_app_id'],
                   'global_Voice_ID_equals_operator': binding_rows.get('PHOTON_VOICE_APP_ID', {}).get('text') == ids['voice_app_id']}
    report = {
        'schema': 'captured-deployed-exact20230414-backend-review-only/v1',
        'status': 'auth_and_api_gate_candidates_staged_match_change_HELD',
        'capture': str(capture), 'inputs': input_rows + [row(settings_path)],
        'source_workers_or_settings_changed': False, 'Main_changed': False, 'network_called': False, 'deployment_performed': False,
        'settings_ID_comparisons_only': comparisons,
        'current_NS': {'version_cutoff_observed': False, 'exact20230414_literal_present': False, 'behavior': 'GET / returns Vm(DOMAIN,SUBDOMAINS) endpoint map; appended iOS route wrapper. No NS modification proposed.'},
        'current_API': {'route': '/api/versioncheck/v4', 'version_input': 'query parameter v', 'allowlist_contains20230414': True,
                        'cutoff_utc': cutoff_values['api'], 'current_20230414_VersionStatus': 1,
                        'reason': 'Qb allows the version, but __nx23Vc forces all2023 builds to rejected VersionStatus after cutoff.',
                        'legacy_path_limit': 'No registered literal /api/VersionCheck/v20230414 handler in captured module; actual public response was not queried in this offline audit.'},
        'current_auth': {'cutoff_utc': cutoff_values['auth'], 'version_input': 'token endpoint form field ver; not a version header',
                         'current_20230414_result': 'early invalid_grant400 version gate before ordinary grant handling',
                         'candidate_scope': 'Only exact raw form ver20230414 passes this version gate. Credential/account/ban/MFA/rate/grant/anti-cheat code remains byte-identical.'},
        'candidates': {'auth': row(auth_target), 'api': row(api_target)},
        'exact_edits': [{'worker': 'auth', 'before': auth_before, 'after': auth_after}, {'worker': 'api', 'before': api_before, 'after': api_after}],
        'candidate_unrelated_bytes_proved_identical': True,
        'control_matrix_kind': 'Static predicate model checked against exact captured source statements; not live authentication/network tests.',
        'auth_gate_controls': auth_cases,
        'API_controls': [{'query_v': '20230414', 'current_VersionStatus': 1, 'candidate_VersionStatus': 0},
                         {'query_v': '20230616 or20231207', 'current_VersionStatus': 1, 'candidate_VersionStatus': 1},
                         {'query_v': '20230414.0', 'version_year_cutoff_unchanged': True},
                         {'query_v': 'valid2026 eight/ten-digit build', 'existing_Qb_behavior_unchanged': True}],
        'match_change_hold': {'status': 'NOT_SAFE_TO_DEPLOY', 'draft': row(match_target),
                              'proposed_version_source': 'Existing bm verifies Bearer JWT with HS256 and extracts rn.ver. This is stronger than a header but insufficient for this capture.',
                              'proven_collision': 'Main form grant passes form ver as l, but absent ver falls back to Uo20230414. Browser/MFA minting explicitly passes Uo20230414. Thus legitimate other client flows can carry the same claim.',
                              'missing_proof': 'Distinct signed original2023 client/config marker with safe issuance and preservation through every refresh/MFA/cached-login path; or another existing proven distinct authenticated input. No marker is invented by this draft.',
                              'global_bindings_change_proposed': False, 'current_other_clients_preserved_by_draft': 'UNPROVED; negative control fails for browser/MFA token tagged20230414.',
                              'control_cases': [{'verified_token_ver': '20230414 from explicit2023 form', 'draft_uses_operator_IDs': True},
                                                {'verified_token_ver': '20230414 from existing browser/MFA default', 'draft_uses_operator_IDs': True, 'must_preserve_existing_global_IDs': True, 'control_status': 'FAIL_HOLD'},
                                                {'verified_token_ver': '2026 build', 'draft_global_IDs_unchanged': True},
                                                {'request_header_only20230414': True, 'draft_no_override_from_header': True}]},
        'custom_auth_requirements': {'captured_provider_endpoint_proven': False, 'Photon_dashboard_auth_settings_queried': False,
                                     'token_source': 'match vm signs backend HS256 JWT; aud uses selected n.photonRealtimeAppId. Existing Bearer account auth runs before connection info. Existing return shape carries photonAuthToken and room coordinates.',
                                     'scope_limit': 'No captured Cloudflare route identified as a Photon Cloud Custom Authentication provider. Merely minting a backend JWT does not prove the supplied Photon apps accept it. Provider/app product-type configuration and client auth-value construction need separate proof before functional-room claims.',
                                     'preserved': ['All existing credentials, bans, MFA, auth token validation, backend anti-cheat, global Photon vars and region bindings remain unchanged.']},
        'original_hashes_rechecked': True,
        'tool': row(Path(__file__))}
    for entry in input_rows:
        need(sha(entry['path']) == entry['sha256'], 'Capture input changed during staging')
    need(sha(settings_path) == report['inputs'][-1]['sha256'], 'Capture settings changed during staging')
    path = out / 'review-report.json'
    save(path, json.dumps(report, indent=2) + '\n')
    print(json.dumps({'status': report['status'], 'report': str(path), 'sha256': sha(path),
                      'auth_candidate_sha256': sha(auth_target), 'api_candidate_sha256': sha(api_target),
                      'match_deployment_held': True, 'network_called': False, 'source_settings_or_Main_changed': False,
                      'ID_comparisons': comparisons}))


if __name__ == '__main__':
    main()
