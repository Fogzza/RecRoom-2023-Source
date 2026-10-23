"""Prepare, stage, or apply only user-owned Photon IDs and an explicit region.

Default preparation is data-only. Staging requires an application JSON file;
application requires the explicit apply subcommand and a closed Unity Editor.
No Photon SDK or backend is changed and no network request is made.
"""
from pathlib import Path
import argparse
import datetime as dt
import hashlib
import json
import re
import sys
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
PROJECT = WS / 'RR23'
TARGET = PROJECT / 'Assets/Resources/PhotonServerSettings.asset'
META = TARGET.with_suffix('.asset.meta')
PUN_SOURCE = PROJECT / 'Assets/Scripts/Assembly-CSharp/PUNNetworkManager.cs'
REGION_DOCUMENTATION = 'https://doc.photonengine.com/realtime/v4/connection-and-authentication/regions'
# Official current region snapshot is informational, not a permanent allowlist:
# Photon states regions can be added and removed over a project's lifetime.
DOCUMENTED_GAMING_REGIONS = {'asia', 'au', 'cae', 'cn', 'eu', 'hk', 'in', 'jp', 'za', 'sa', 'kr', 'tr', 'uae', 'us', 'usw', 'ussc'}
sys.path.insert(0, str(ROOT / 'Tools'))
import repair_rr23_wav_headers as safety


def need(value, message):
    if not value:
        raise ValueError(message)


def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()


def row(path):
    safety.assert_no_reparse(path)
    path = Path(path).resolve(strict=True)
    return {'path': str(path), 'sha256': sha(path), 'bytes': path.stat().st_size}


def write(path, contents):
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open('xb') as stream:
        stream.write(contents.encode('utf-8') if isinstance(contents, str) else contents)


def json_write(path, value):
    write(path, json.dumps(value, indent=2) + '\n')


def scalar(data, key, indent):
    values = re.findall(rb'(?m)^' + b' ' * indent + re.escape(key.encode('ascii')) + rb':([^\r\n]*)$', data)
    need(len(values) == 1, 'One exact scalar required: ' + key)
    return values[0].strip().decode('ascii')


def replace_scalar(data, key, indent, value):
    pattern = rb'(?m)^(' + b' ' * indent + re.escape(key.encode('ascii')) + rb':)[^\r\n]*$'
    result, count = re.subn(pattern, lambda match: match[1] + (b' ' + value.encode('ascii') if value else b''), data)
    need(count == 1, 'One exact scalar replacement required: ' + key)
    return result


def stamp():
    return dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]


def prepare():
    before, meta = row(TARGET), row(META)
    data = TARGET.read_bytes()
    need(scalar(data, 'UseNameServer', 4) == '1' and scalar(data, 'Server', 4) == '' and scalar(data, 'Port', 4) == '0', 'Existing Photon Cloud configuration required; direct-host mode must be separately planned')
    need(scalar(data, 'AppIdChat', 4) == '', 'Unexpected original Chat ID: preserve and review separately')
    script = re.findall(rb'(?m)^  m_Script: (.+)$', data)
    need(len(script) == 1, 'One original script reference required')
    out = ROOT / 'Validation' / ('OwnPhotonConfigurationPlan-' + stamp())
    out.mkdir()
    original = out / 'Original/PhotonServerSettings.asset'
    original_meta = out / 'Original/PhotonServerSettings.asset.meta'
    write(original, data)
    write(original_meta, META.read_bytes())
    plan = {'schema': 'prepared-own-photon-app-configuration/v1', 'status': 'waiting_for_user_owned_app_ids',
            'project': str(PROJECT), 'resource': before, 'resource_meta': meta, 'pun_original_identity_source': row(PUN_SOURCE),
            'runner': row(Path(__file__)), 'original_backup': row(original), 'original_meta_backup': row(original_meta),
            'existing_defaults': {'UseNameServer': 1, 'Server': '', 'Port': 0,
                                  'FixedRegion': scalar(data, 'FixedRegion', 4), 'DevRegion': scalar(data, 'DevRegion', 2),
                                  'AppIdRealtime': 'original-present-do-not-reuse', 'AppIdVoice': 'original-present-do-not-reuse', 'AppIdChat': 'empty'},
            'application_input_keys': ['realtime_app_id', 'voice_app_id'], 'optional_input_keys': ['chat_app_id', 'region'],
            'required_input_policy': 'User must explicitly supply own app IDs. Omitted region preserves FixedRegion and DevRegion bytes exactly; explicit region updates both. No original ID or silent region fallback.',
            'app_type_validation': 'UUID syntax cannot establish Photon product type. Realtime and Voice assignments are operator-supplied; no dashboard verification is claimed.',
            'region_documentation': REGION_DOCUMENTATION,
            'regional_limit': 'China requires another NameServer and the official docs exclude Voice there; this narrow global-Cloud+Voice configuration does not implement that separate route.',
            'only_allowed_scalar_changes': ['AppSettings.AppIdRealtime', 'AppSettings.AppIdVoice', 'AppSettings.AppIdChat (only when supplied)', 'AppSettings.FixedRegion', 'DevRegion'],
            'preservation': ['Original resource and .meta backup before any write.', 'm_Script reference, resource .meta GUID, complete RpcList, protocol/auth/offline settings, and every unrelated byte stay unchanged.', 'No managed/native SDK, source body, backend, Photon account or cloud edit.'],
            'limitations': ['Current recovered transport/room connection bodies are stubs; configuration is not proof of functional rooms.', 'Apply requires Unity closed to avoid changing an in-flight build.', 'This tool configures the client resource only; operator backend vars remain a separate explicit action.'],
            'Main_modified': False, 'Editor_or_SDK_launched': False, 'network_called': False}
    path = out / 'plan.json'
    json_write(path, plan)
    need(sha(TARGET) == before['sha256'] and sha(META) == meta['sha256'], 'Input changed during preparation')
    return {'status': plan['status'], 'plan': str(path), 'plan_sha256': sha(path), 'Main_modified': False}


def load_plan(path):
    path = Path(path).resolve(strict=True)
    need(path.parent.is_relative_to(ROOT / 'Validation') and path.parent.name.startswith('OwnPhotonConfigurationPlan-'), 'Exact prepared plan required')
    plan = json.loads(path.read_bytes())
    need(plan['schema'] == 'prepared-own-photon-app-configuration/v1' and Path(plan['resource']['path']) == TARGET and Path(plan['resource_meta']['path']) == META, 'Unexpected plan target')
    for key in ('resource', 'resource_meta', 'pun_original_identity_source', 'runner', 'original_backup', 'original_meta_backup'):
        checked = plan[key]
        safety.assert_no_reparse(checked['path'])
        need(sha(checked['path']) == checked['sha256'], 'Pinned input changed: ' + key)
    return path, plan


def stage(plan_path, application_path):
    path, plan = load_plan(plan_path)
    application_path = Path(application_path).resolve(strict=True)
    application = json.loads(application_path.read_bytes())
    need(set(application) <= {'realtime_app_id', 'voice_app_id', 'chat_app_id', 'region'} and {'realtime_app_id', 'voice_app_id'} <= set(application), 'Only the requested app ID and optional region input keys are allowed')
    old = Path(plan['original_backup']['path']).read_bytes()
    original_ids = set(re.findall(r'[0-9a-fA-F]{8}-(?:[0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}', old.decode('utf-8') + PUN_SOURCE.read_text(encoding='utf-8')))
    original_ids = {str(uuid.UUID(value)) for value in original_ids}
    values = {}
    for key in ('realtime_app_id', 'voice_app_id', 'chat_app_id'):
        if key not in application:
            continue
        need(isinstance(application[key], str), 'App ID must be a UUID string')
        identity = uuid.UUID(application[key].strip())
        value = str(identity)
        need(identity.int and value not in original_ids, 'Own nonempty application ID required; original export IDs cannot be reused')
        values[key] = value
    need(len(set(values.values())) == len(values), 'Use a distinct own app ID for each Photon service')
    supplied_region = 'region' in application
    region = application.get('region')
    if supplied_region:
        # An empty FixedRegion uses Photon's automatic/best-region path. Region
        # names are case insensitive according to the official documentation.
        need(isinstance(region, str) and (region == '' or re.fullmatch(r'[a-zA-Z][a-zA-Z0-9-]{1,15}', region)), 'Explicit Photon region code or empty automatic selection required')
        region = region.lower()
        need(region != 'cn', 'China requires a separate NameServer route and has no Photon Voice service; outside this global Cloud+Voice configuration')
    candidate = old
    allowed = {'AppIdRealtime': values['realtime_app_id'], 'AppIdVoice': values['voice_app_id']}
    if supplied_region:
        allowed['FixedRegion'] = region
    if 'chat_app_id' in values:
        allowed['AppIdChat'] = values['chat_app_id']
    for key, value in allowed.items():
        candidate = replace_scalar(candidate, key, 4, value)
    if supplied_region:
        candidate = replace_scalar(candidate, 'DevRegion', 2, region)
    # Mask exactly the allowed field values; the remaining bytes must match.
    fields = b'|'.join(re.escape(key.encode('ascii')) for key in allowed)
    mask = lambda data: re.sub(rb'(?m)^((?:    (?:' + fields + rb')' + (rb'|  DevRegion' if supplied_region else b'') + rb'):)[^\r\n]*$', rb'\1 <allowed-value>', data)
    need(mask(old) == mask(candidate), 'Unrelated resource byte changed')
    out = path.parent / ('Staged-' + stamp())
    target = out / 'Candidate/Assets/Resources/PhotonServerSettings.asset'
    write(target, candidate)
    record = {'schema': 'staged-own-photon-app-configuration/v1', 'status': 'staged_not_applied', 'plan': row(path),
              'application_input_sha256': sha(application_path), 'candidate': row(target), 'original_resource': plan['resource'],
              'resource_meta': plan['resource_meta'], 'original_backup': plan['original_backup'], 'runner': row(Path(__file__)),
              'configured_services': sorted(values), 'region': region,
              'region_mode': 'explicit_automatic' if supplied_region and region == '' else 'explicit_fixed' if supplied_region else 'preserved_original_bytes',
              'region_in_current_official_snapshot': region in DOCUMENTED_GAMING_REGIONS if supplied_region and region else None,
              'region_documentation': REGION_DOCUMENTATION,
              'app_types_dashboard_verified': False, 'app_type_assignment': 'operator_supplied_input_field_names',
              'changed_fields': sorted(allowed) + (['DevRegion'] if supplied_region else []),
              'unrelated_resource_bytes_verified_equal': True, 'script_reference_preserved': True,
              'Main_modified': False, 'runtime_networking_verified': False}
    receipt = out / 'staged.json'
    json_write(receipt, record)
    return {'status': record['status'], 'staged': str(receipt), 'staged_sha256': sha(receipt), 'candidate_sha256': sha(target), 'configured_services': sorted(values), 'region': region, 'Main_modified': False}


def apply(staged_path):
    staged_path = Path(staged_path).resolve(strict=True)
    staged = json.loads(staged_path.read_bytes())
    need(staged['schema'] == 'staged-own-photon-app-configuration/v1' and staged['status'] == 'staged_not_applied', 'Exact staged candidate required')
    load_plan(staged['plan']['path'])
    need(sha(staged['plan']['path']) == staged['plan']['sha256'] and Path(staged['original_resource']['path']) == TARGET, 'Staged plan/target changed')
    need(staged_path.parent.parent.name.startswith('OwnPhotonConfigurationPlan-') and staged_path.parent.parent.is_relative_to(ROOT / 'Validation'), 'Staged candidate must belong to prepared plan')
    for key in ('candidate', 'original_resource', 'resource_meta', 'original_backup', 'runner'):
        need(sha(staged[key]['path']) == staged[key]['sha256'], 'Staged input changed: ' + key)
    safety.assert_editor_closed()
    safety.assert_no_reparse(TARGET)
    before = TARGET.read_bytes()
    contents = Path(staged['candidate']['path']).read_bytes()
    need(sha(TARGET) == staged['original_resource']['sha256'], 'Fresh original resource pin required')
    # Single existing file write after the complete original and meta backups are pinned.
    with TARGET.open('r+b') as stream:
        need(hashlib.sha256(stream.read()).hexdigest() == staged['original_resource']['sha256'], 'Resource changed at write admission')
        stream.seek(0)
        stream.write(contents)
        stream.truncate()
        stream.flush()
    need(sha(TARGET) == staged['candidate']['sha256'] and sha(META) == staged['resource_meta']['sha256'], 'Applied bytes or unchanged meta verification failed')
    result = {'schema': 'applied-own-photon-client-resource/v1', 'status': 'applied', 'staged': row(staged_path),
              'before_sha256': hashlib.sha256(before).hexdigest(), 'after': row(TARGET), 'meta_unchanged': row(META),
              'configured_services': staged['configured_services'], 'region': staged['region'],
              'only_requested_resource_fields_changed': True, 'runtime_networking_verified': False,
              'SDK_backend_or_cloud_changed': False, 'original_backup': staged['original_backup']}
    receipt = staged_path.parent / 'applied.json'
    json_write(receipt, result)
    return {'status': 'applied', 'receipt': str(receipt), 'receipt_sha256': sha(receipt), 'runtime_networking_verified': False}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    commands = parser.add_subparsers(dest='command', required=True)
    commands.add_parser('prepare')
    staging = commands.add_parser('stage')
    staging.add_argument('--plan', type=Path, required=True)
    staging.add_argument('--application', type=Path, required=True)
    applying = commands.add_parser('apply')
    applying.add_argument('--staged', type=Path, required=True)
    args = parser.parse_args()
    result = prepare() if args.command == 'prepare' else stage(args.plan, args.application) if args.command == 'stage' else apply(args.staged)
    print(json.dumps(result))


if __name__ == '__main__':
    main()
