"""Read-only post-apply SDK byte/GUID/routing checkpoint, safe during import."""
import argparse
import importlib.util
import json
import re
import sys
from datetime import datetime, timezone
from pathlib import Path
from uuid import uuid4
from stage_original_native_sdk_dependencies import ROOT, WS, sha, need

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('receipt', type=Path)
    parser.add_argument('--receipt-sha256', required=True)
    args = parser.parse_args()
    need(sha(args.receipt) == args.receipt_sha256, 'Root installation receipt hash differs')
    receipt = json.loads(args.receipt.read_bytes())
    need(receipt['schema'] == 'original-native-SDK-add-only-installation-receipt/v1' and receipt['status'] == 'applied' and receipt['mode'] == 'apply', 'A successful actual SDK installation receipt is required')
    manifest = Path(receipt['manifest'])
    need(sha(manifest) == receipt['manifest_sha256'], 'Installed manifest changed')
    plan = json.loads(manifest.read_bytes())
    installer = Path(plan['installer']['path'])
    need(sha(installer) == plan['installer']['sha256'], 'Frozen applied installer changed')
    sys.path.insert(0, str(ROOT/'Tools'))
    spec = importlib.util.spec_from_file_location('native_sdk_read_only_checkpoint', installer)
    tool = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(tool)
    tool.validate_plan(plan)
    checks, errors, guids, routing = [], [], {}, []
    for row in plan['files']:
        target = tool.safe(tool.PROJECT/row['project_relative_path'], tool.PROJECT, True)
        actual_sha = sha(target)
        # Recheck lexical ancestors after reading too; do not accept a changed
        # reparse path merely because the content happened to match.
        tool.safe(target, tool.PROJECT, True)
        same = actual_sha == row['candidate_sha256']
        checks.append({'relative_path': row['project_relative_path'], 'sha256': actual_sha, 'expected_sha256': row['candidate_sha256'], 'bytes_equal': same, 'fresh_no_reparse_before_and_after_read': True})
        if not same:
            errors.append({'relative_path': row['project_relative_path'], 'issue': 'bytes_changed_since_reviewed_install_candidate'})
        if target.suffix == '.meta':
            text = target.read_text(encoding='utf-8')
            match = re.search(r'(?m)^guid: ([a-f0-9]{32})$', text)
            need(match is not None and match[1] not in guids, 'Missing/duplicate installed meta GUID')
            guids[match[1]] = row['project_relative_path']
            if row['kind'] == 'native_importer_meta':
                role = Path(row['project_relative_path']).name[:-5]
                routes = {'native_DLL': role, 'preloaded': bool(re.search(r'(?m)^  isPreloaded: 1$', text)),
                    'Any_platform': bool(re.search(r'Any:\s*\n\s*second:\s*\n\s*enabled: 1', text)),
                    'Editor_enabled': bool(re.search(r'Editor: Editor\s*\n\s*second:\s*\n\s*enabled: 1', text)),
                    'Win64_enabled': bool(re.search(r'Standalone: Win64\s*\n\s*second:\s*\n\s*enabled: 1', text))}
                need(not routes['preloaded'] and not routes['Any_platform'] and routes['Win64_enabled'] and routes['Editor_enabled'] == (role != 'EasyAntiCheat.dll'), 'Installed native platform routing differs from reviewed policy')
                routing.append(routes)
    need(len(checks) == 87 and len(routing) == 26, 'Exact installed dependency inventory required')
    need(sha(args.receipt) == args.receipt_sha256 and sha(manifest) == receipt['manifest_sha256'], 'Receipt/manifest changed during read-only checkpoint')
    report = {'schema': 'installed-original-native-SDK-read-only-checkpoint/v1', 'status': 'verified_installed_bytes_and_routing' if not errors else 'post_install_bytes_changed_requires_review',
        'captured_utc': datetime.now(timezone.utc).isoformat(), 'installation_receipt': {'path': str(args.receipt.absolute()), 'sha256': args.receipt_sha256},
        'manifest': {'path': str(manifest), 'sha256': receipt['manifest_sha256']}, 'files': checks, 'routing': routing, 'unique_meta_GUIDs': len(guids), 'errors': errors,
        'native_DLLs': 26, 'SteamVR_original_configs': 14, 'subsystem_manifest': 'XRSDKOpenVR only', 'Burst_and_orphan_Oculus_descriptor_installed': False,
        'native_SDK_or_game_methods_invoked_by_checkpoint': False, 'Unity_launched_by_checkpoint': False, 'Main_modified_by_checkpoint': False,
        'SDK_initialization_or_VR_device_functionality_proven': False, 'Android_Quest_iOS_native_payload_recovery_claimed': False}
    out = ROOT/'Validation'/('InstalledOriginalSDKCheckpoint-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid4().hex[:8])
    out.mkdir()
    result = out/'report.json'
    result.write_text(json.dumps(report, indent=2)+'\n')
    print(json.dumps({'report': str(result), 'sha256': sha(result), 'status': report['status'], 'errors': len(errors), 'files': len(checks)}))
if __name__ == '__main__':
    main()
