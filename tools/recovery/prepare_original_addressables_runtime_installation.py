"""Prepare exact original runtime AA tree installation; no Main writes/network."""
import copy
import importlib.util
import json
import re
import shutil
import sys
from collections import Counter
from datetime import datetime, timezone
from pathlib import Path
from urllib.parse import urlsplit
from uuid import uuid4
from stage_original_native_sdk_dependencies import ROOT, SOURCE, WS, sha, need, regular

def main():
    installer = ROOT/'Tools/install_original_addressables_runtime.py'
    sys.path.insert(0, str(ROOT/'Tools'))
    spec = importlib.util.spec_from_file_location('original_aa_installation_plan', installer)
    tool = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(tool)
    originals = tool.inventory()
    rows, retained, bytes_new = [], 0, 0
    for relative, size, digest in originals:
        source = regular(SOURCE/relative)
        need(source.stat().st_size == size and sha(source) == digest, 'Original AA runtime payload hash mismatch')
        target_relative = tool.TARGET_PREFIX+relative[len(tool.SOURCE_PREFIX):]
        target = tool.safe(tool.PROJECT/target_relative, tool.PROJECT)
        if target.exists():
            need(target.is_file() and sha(target) == digest, 'Existing runtime payload differs; no overwrite allowed')
            retained += 1
        else:
            bytes_new += size
        rows.append({'source_relative_path': relative, 'project_relative_path': target_relative, 'bytes': size, 'sha256': digest})
    catalog = SOURCE/'RecRoom_Data/StreamingAssets/aa/catalog.json'
    settings = SOURCE/'RecRoom_Data/StreamingAssets/aa/settings.json'
    data = json.loads(catalog.read_bytes())
    config = json.loads(settings.read_bytes())
    ids = data.get('m_InternalIds', [])
    prefixes = data.get('m_InternalIdPrefixes', [])
    need(isinstance(ids, list) and all(isinstance(x, str) for x in ids), 'Original internal ID string table required')
    bundle_names = {Path(row[0]).name for row in originals if row[0].endswith('.bundle')}
    referenced_names = {name for value in ids+prefixes for name in re.findall(r'[0-9a-f]{32}\.bundle', value)}
    need(referenced_names == bundle_names, 'Catalog/runtime bundle filename set mismatch')
    remote = []
    for value in ids+prefixes:
        if value.startswith(('http://', 'https://')):
            parsed = urlsplit(value)
            remote.append({'scheme': parsed.scheme, 'host': parsed.hostname, 'path_prefix': parsed.path[:160], 'query_or_fragment_present': bool(parsed.query or parsed.fragment)})
    out = ROOT/'RuntimeSDKRecovery'/('OriginalAARuntimeInstallation-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid4().hex[:8])
    out.mkdir()
    evidence = {'schema': 'original-AA-runtime-path-and-catalog-data-evidence/v1', 'status': 'verified_all_original_runtime_files_no_network',
        'settings': {'path': str(settings), 'sha256': sha(settings), 'Addressables_version': config['m_AddressablesVersion'], 'build_target': config['m_buildTarget'],
            'catalog_internal_ids': [row['m_InternalId'] for row in config['m_CatalogLocations']], 'disable_catalog_update_on_start': config['m_DisableCatalogUpdateOnStart']},
        'catalog': {'path': str(catalog), 'sha256': sha(catalog), 'internal_id_count': len(ids), 'prefix_count': len(prefixes), 'bundle_names_matched_exactly': len(bundle_names),
            'runtime_path_placeholder_internal_ids': sum('{UnityEngine.AddressableAssets.Addressables.RuntimePath}' in value for value in ids),
            'internal_id_sample_categories': dict(Counter('runtime-path-template' if '{UnityEngine.AddressableAssets.Addressables.RuntimePath}' in value else 'remote-URL' if value.startswith(('https://', 'http://')) else 'asset-name-or-scene-ID' for value in ids)),
            'remote_URL_count': len(remote), 'remote_URL_host_counts': dict(Counter(row['host'] for row in remote)), 'remote_URL_samples_query_values_omitted': remote[:12]},
        'all_payload_bytes_preserved_without_edits': True, 'metas_to_invent': 0, 'cloud_requests': 0, 'backend_modified': False, 'Main_modified': False,
        'runtime_assets_are_not_new_editable_exports': True, 'game_code_recovery_claimed': False}
    evidence_path = out/'runtime-path-evidence.json'
    evidence_path.write_text(json.dumps(evidence, indent=2)+'\n')
    plan = {'schema': 'original-Addressables-runtime-add-only-installation/v1', 'project': str(tool.PROJECT), 'source': str(SOURCE),
        'installer': {'path': str(installer), 'sha256': sha(installer)}, 'source_inventory': {'path': str(tool.INDEX), 'sha256': tool.INDEX_SHA},
        'runtime_path_evidence': {'path': str(evidence_path), 'sha256': sha(evidence_path)}, 'files': rows, 'create_or_replace_metas': False, 'rewrite_catalog_or_URLs': False,
        'disk_reserve_bytes': 2*1024**3, 'source_tree_bytes': 2169249312, 'source_tree_files': 6502, 'bundles': 6499,
        'limitations': ['No source or catalog/runtime URL is changed. Original external services can still be referenced by original data.',
            'Raw runtime bundles preserve the original asset/reference data; their presence is not editable-asset or gameplay-body recovery.',
            'The current genuine Addressables1.20.5/ResourceManager DLLs passed a separate original texture provider load fixture; complete game initialization remains unverified.']}
    tool.validate_plan(plan)
    tests = []
    for label, change in [('missing_file', lambda p:p['files'].pop()), ('duplicate_path', lambda p:p['files'].append(copy.deepcopy(p['files'][0]))),
        ('source_SHA', lambda p:p['files'][0].update(sha256='0'*64)), ('source_path', lambda p:p['files'][0].update(source_relative_path='../GameAssembly.dll')),
        ('target_escape', lambda p:p['files'][0].update(project_relative_path='../outside')), ('invent_metas', lambda p:p.update(create_or_replace_metas=True)),
        ('rewrite_URLs', lambda p:p.update(rewrite_catalog_or_URLs=True)), ('wrong_project', lambda p:p.update(project=str(WS/'Other')))]:
        bad = copy.deepcopy(plan)
        change(bad)
        try:
            tool.validate_plan(bad)
        except ValueError:
            tests.append({'name': label, 'rejected': True})
        else:
            raise ValueError('Invalid AA installation plan accepted: '+label)
    manifest = out/'manifest.json'
    manifest.write_text(json.dumps(plan, indent=2)+'\n')
    report = {'schema': 'original-Addressables-runtime-installation-preparation/v1', 'status': 'prepared_all_source_SHA_verified_not_applied',
        'manifest': str(manifest), 'manifest_sha256': sha(manifest), 'installer': plan['installer'], 'runtime_evidence': plan['runtime_path_evidence'],
        'source_files': len(rows), 'original_bundles': len(bundle_names), 'bytes': 2169249312, 'new_bytes': bytes_new, 'existing_identical_files': retained,
        'free_project_volume_bytes': shutil.disk_usage(tool.PROJECT).free, 'disk_reserve_bytes': plan['disk_reserve_bytes'],
        'minimum_free_required_before_copy_bytes': bytes_new+plan['disk_reserve_bytes'], 'all_source_file_SHA_match_archive': True, 'negative_controls': tests,
        'Main_modified': False, 'Unity_launched': False, 'network_or_game_code_invoked': False}
    path = out/'preparation-report.json'
    path.write_text(json.dumps(report, indent=2)+'\n')
    print(json.dumps({'report': str(path), 'sha256': sha(path), 'manifest': str(manifest), 'manifest_sha256': sha(manifest), 'installer_sha256': sha(installer),
        'source_files': len(rows), 'source_bytes': 2169249312, 'new_bytes': bytes_new, 'remote_URL_count': len(remote), 'free_bytes': report['free_project_volume_bytes'], 'required_free_bytes': report['minimum_free_required_before_copy_bytes']}))
if __name__ == '__main__':
    main()
