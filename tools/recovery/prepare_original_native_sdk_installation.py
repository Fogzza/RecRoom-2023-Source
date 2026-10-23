"""Prepare exact original PC SDK binaries/configuration and add-only install plan."""
import ast
import copy
import hashlib
import importlib.util
import json
import mmap
import re
import shutil
import sys
import tempfile
from datetime import datetime, timezone
from pathlib import Path
from uuid import uuid4
from stage_original_native_sdk_dependencies import ROOT, SOURCE, WS, PE, sha, need, regular, importer

NATIVE = ROOT/'RuntimeSDKRecovery/OriginalNativeDependencies-20261022T181919Z-ab0b5c62/report.json'
NATIVE_SHA = '0aecef17eeaaaecd1277275e06e970fd3bf44a59c22038ecd32be98c4ce74c26'
PLAN = ROOT/'RuntimeSDKRecovery/OriginalSDKDependencyPlan-20261022T182212Z-f54bc83d/report.json'
PLAN_SHA = '28411caa3617ff4c5cd058dd23e81612547b2fad93b137edd8c1e98ffd8e9bc9'
MAIN = WS/'RR23'

def export_names(blob):
    pe = PE(blob)
    rva, size = pe.u32(pe.dd), pe.u32(pe.dd+4)
    if not rva:
        return []
    at = pe.offset(rva, 40)
    count = pe.u32(at+24)
    need(count <= 200000, 'Export-name count bounded')
    names = pe.offset(pe.u32(at+32), count*4) if count else 0
    values = [pe.string(pe.u32(names+i*4)) for i in range(count)]
    need(len(set(values)) == len(values), 'Unique native export names required')
    return values

def data_meta(guid, kind):
    if kind == 'folder':
        return ('fileFormatVersion: 2\nguid: '+guid+'\nfolderAsset: yes\nDefaultImporter:\n  externalObjects: {}\n  userData:\n  assetBundleName:\n  assetBundleVariant:\n').encode()
    if kind == 'asset':
        return ('fileFormatVersion: 2\nguid: '+guid+'\nNativeFormatImporter:\n  externalObjects: {}\n  mainObjectFileID: 11400000\n  userData:\n  assetBundleName:\n  assetBundleVariant:\n').encode()
    return ('fileFormatVersion: 2\nguid: '+guid+'\nTextScriptImporter:\n  externalObjects: {}\n  userData:\n  assetBundleName:\n  assetBundleVariant:\n').encode()

def main():
    need(sha(NATIVE) == NATIVE_SHA and sha(PLAN) == PLAN_SHA, 'Pinned original SDK plans required')
    native, plan = json.loads(NATIVE.read_bytes()), json.loads(PLAN.read_bytes())
    out = ROOT/'RuntimeSDKRecovery'/('OriginalNativeSDKInstallation-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid4().hex[:8])
    out.mkdir()
    rows, export_proofs = [], []
    guid_values = set()
    def stage(relative, candidate, kind, authority=None):
        target = MAIN/relative
        regular(candidate)
        digest = sha(candidate)
        original_sha = None
        if target.exists():
            regular(target)
            need(sha(target) == digest, 'No-overwrite preparation refuses existing differing file: '+relative)
            original_sha = digest
        row = {'project_relative_path': relative, 'candidate_path': str(candidate), 'candidate_sha256': digest,
            'original_sha256': original_sha, 'kind': kind, 'authority': authority}
        rows.append(row)
        return row
    def meta(relative, kind, payload=None):
        target = MAIN/(relative+'.meta')
        candidate = out/'MetadataCandidates'/(relative+'.meta')
        candidate.parent.mkdir(parents=True, exist_ok=True)
        if target.exists():
            regular(target)
            candidate.write_bytes(target.read_bytes())
            authority = 'existing_Main_meta_bytes_and_GUID_preserved'
        else:
            guid = hashlib.sha256(('rr23-original-native-dependency-meta/v1|'+relative).encode()).hexdigest()[:32]
            candidate.write_bytes(payload(guid) if payload else data_meta(guid, kind))
            authority = 'new_reconstructed_meta_original_importer_GUID_unavailable'
        text = candidate.read_text()
        found = re.search(r'(?m)^guid: ([a-f0-9]{32})$', text)
        need(found is not None and found[1] not in guid_values, 'Unique valid staged GUID required')
        guid_values.add(found[1])
        return stage(relative+'.meta', candidate, 'native_importer_meta' if kind == 'native' else 'folder_meta' if kind == 'folder' else 'data_meta', authority)
    for row in native['native_originals']:
        name = Path(row['source_relative_path']).name
        if row['build_generated_burst_artifact']:
            continue
        source, candidate = Path(row['source_path']), Path(row['candidate'])
        need(sha(source) == row['sha256'] and sha(candidate) == row['sha256'], 'Original/staged native bytes drift')
        with source.open('rb') as stream, mmap.mmap(stream.fileno(), 0, access=mmap.ACCESS_READ) as blob:
            names = export_names(blob)
            literals = {text: blob.find(text.encode('ascii')) for text in ['XRSDKOpenVR', 'OpenVR Display', 'OpenVR Input']} if name == 'XRSDKOpenVR.dll' else {}
        export_proofs.append({'name': name, 'source_sha256': row['sha256'], 'export_names': names,
            'export_names_sha256': hashlib.sha256('\n'.join(names).encode()).hexdigest(), 'provider_literals_offsets': literals,
            'PE_machine': row['PE']['machine'], 'imports': row['PE']['imports'], 'delay_imports': row['PE']['delay_imports'],
            'dependency_classification': row['dependencies'], 'DLL_loaded': False})
        relative = ('Assets/OriginalOpenVR/x86_64/' if name in ['XRSDKOpenVR.dll', 'openvr_api.dll'] else 'Assets/Plugins/x86_64/')+name
        stage(relative, candidate, 'native_DLL', {'source': str(source), 'sha256': row['sha256'], 'original_relative_path': row['source_relative_path']})
        editor = name != 'EasyAntiCheat.dll'
        meta(relative, 'native', lambda guid: importer(guid, editor))
    xr = next(row for row in export_proofs if row['name'] == 'XRSDKOpenVR.dll')
    need('UnityPluginLoad' in xr['export_names'] and all(offset >= 0 for offset in xr['provider_literals_offsets'].values()), 'Matching original XR lifecycle export/provider/id literals required')
    xr_manifest = next(row for row in plan['original_subsystem_evidence'] if row['name'] == 'XRSDKOpenVR')
    need(xr_manifest['library_name'] == 'XRSDKOpenVR' and len(xr_manifest['verified_archive_matching_native_libraries']) == 1, 'Exact original XR manifest/native library required')
    stage('Assets/OriginalOpenVR/UnitySubsystemsManifest.json', Path(xr_manifest['candidate']), 'subsystem_manifest', {'source_relative_path': xr_manifest['original_relative_path'], 'sha256': xr_manifest['sha256']})
    meta('Assets/OriginalOpenVR/UnitySubsystemsManifest.json', 'json')
    configs = [row for row in native['original_config_and_version_evidence'] if 'project_relative_path' in row]
    need(len(configs) == 14, 'Exact original SteamVR config set')
    for row in configs:
        stage(row['project_relative_path'], Path(row['candidate']), 'SteamVR_config', {'source': row['source'], 'sha256': row['sha256']})
        meta(row['project_relative_path'], 'asset' if row['project_relative_path'].endswith('.asset') else 'json')
    folder_paths = ['Assets/Plugins/x86_64', 'Assets/OriginalOpenVR', 'Assets/OriginalOpenVR/x86_64', 'Assets/StreamingAssets', 'Assets/StreamingAssets/SteamVR']
    for relative in folder_paths:
        meta(relative, 'folder')
    proof = out/'native-export-and-subsystem-proof.json'
    proof.write_text(json.dumps({'schema': 'original-native-export-and-XR-subsystem-binding/v1', 'status': 'static_source_contracts_proven_not_executed',
        'DLLs': export_proofs, 'original_XR_manifest': xr_manifest,
        'XR_layout': {'manifest': 'Assets/OriginalOpenVR/UnitySubsystemsManifest.json', 'native_library': 'Assets/OriginalOpenVR/x86_64/XRSDKOpenVR.dll', 'native_dependency': 'Assets/OriginalOpenVR/x86_64/openvr_api.dll'},
        'official_layout_authority': 'https://docs.unity3d.com/2020.3/Documentation/Manual/xrsdk-provider-setup.html',
        'official_name_authority': 'https://docs.unity3d.com/2020.3/Documentation/Manual/xrsdk-unity-subsystems-manifest-json.html',
        'orphan_Oculus_manifest_excluded': True, 'original_OculusXRPlugin_library_found': False, 'Main_modified': False}, indent=2)+'\n')
    installer = ROOT/'Tools/install_original_native_sdk_dependencies.py'
    manifest = {'schema': 'original-native-SDK-add-only-installation/v1', 'project': str(MAIN), 'native_DLL_count': 26, 'SteamVR_config_count': 14, 'valid_subsystem_manifests': 1,
        'UPM_changes': False, 'managed_DLL_changes': False, 'evidence': [{'path': str(NATIVE), 'sha256': NATIVE_SHA}, {'path': str(PLAN), 'sha256': PLAN_SHA}, {'path': str(proof), 'sha256': sha(proof)}],
        'installer': {'path': str(installer), 'sha256': sha(installer)}, 'files': rows,
        'excluded': ['lib_burst_generated.dll', 'GameAssembly.dll', 'UnityPlayer.dll', 'RecRoom.exe', 'baselib.dll', 'orphan OculusXRPlugin UnitySubsystemsManifest.json'],
        'scope': 'Original verified Windows x64 native SDK files. New importer metadata is reconstruction, not original GUID/platform-filter recovery. Editor+Win64 for ordinary SDKs; EasyAntiCheat player-only, nonpreloaded, no service or initialization action.',
        'new_native_functionality_invoked': False, 'Main_modified': False}
    manifest_path = out/'manifest.json'
    manifest_path.write_text(json.dumps(manifest, indent=2)+'\n')
    sys.path.insert(0, str(ROOT/'Tools'))
    spec = importlib.util.spec_from_file_location('native_add_only_install_fixture', installer)
    tool = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(tool)
    tool.validate_plan(manifest)
    # An actual exclusive-create helper must never overwrite an existing target.
    fixtures = []
    with tempfile.TemporaryDirectory(prefix='native-sdk-exclusive-', dir=out) as tmp:
        tmp = Path(tmp)
        src, dst = tmp/'source', tmp/'target'
        src.write_bytes(b'new')
        dst.write_bytes(b'existing')
        record = {'created': False}
        try:
            tool.exclusive_copy(src, dst, record)
        except FileExistsError:
            need(dst.read_bytes() == b'existing' and not record['created'], 'Existing destination changed')
            fixtures.append('atomic_existing_file_refusal_preserves_bytes')
        else:
            raise ValueError('Existing destination was overwritten')
        dst2 = tmp/'new-target'
        tool.exclusive_copy(src, dst2, {})
        need(dst2.read_bytes() == b'new', 'Exclusive new-file copy failed')
        fixtures.append('exclusive_new_file_copy')
    for relative in ['../outside', '/absolute', 'Assets/Plugins/x86_64/GameAssembly.dll', 'Assets/Plugins/x86_64/lib_burst_generated.dll', 'Assets/OculusXRPlugin/UnitySubsystemsManifest.json', 'Assets/../foo']:
        try:
            tool.target_allowed(relative)
        except ValueError:
            fixtures.append('reject_'+relative)
        else:
            raise ValueError('Forbidden target accepted')
    for label, mutate in [
        ('native_count', lambda p: p.update(native_DLL_count=25)),
        ('config_count', lambda p: p.update(SteamVR_config_count=13)),
        ('subsystem_count', lambda p: p.update(valid_subsystem_manifests=2)),
        ('UPM_changes', lambda p: p.update(UPM_changes=True)),
        ('managed_changes', lambda p: p.update(managed_DLL_changes=True)),
        ('duplicate_target', lambda p: p['files'].append(copy.deepcopy(p['files'][0]))),
        ('missing_row', lambda p: p['files'].pop(0)),
        ('wrong_original_DLL_SHA', lambda p: p['files'][0].update(candidate_sha256='0'*64)),
        ('unreviewed_DLL_path', lambda p: p['files'][0].update(project_relative_path='Assets/Plugins/x86_64/Other.dll')),
        ('wrong_payload_role', lambda p: p['files'][0].update(kind='SteamVR_config')),
        ('metadata_retarget', lambda p: p['files'][1].update(project_relative_path='Assets/Scripts/Other.cs.meta')),
    ]:
        negative = copy.deepcopy(manifest)
        mutate(negative)
        try:
            tool.validate_plan(negative)
        except ValueError:
            fixtures.append('reject_'+label)
        else:
            raise ValueError('Bad installation plan accepted: '+label)
    receipt = out/'preparation-report.json'
    receipt.write_text(json.dumps({'schema': 'original-native-SDK-add-only-preparation/v1', 'status': 'prepared_not_applied', 'manifest': str(manifest_path), 'manifest_sha256': sha(manifest_path),
        'installer': manifest['installer'], 'file_rows': len(rows), 'native_DLLs': 26, 'native_importer_metas': 26, 'SteamVR_configs': 14,
        'subsystem_manifests': 1, 'folder_metas': len(folder_paths), 'fixture_checks': fixtures, 'Main_modified': False, 'native_code_loaded': False}, indent=2)+'\n')
    print(json.dumps({'report': str(receipt), 'sha256': sha(receipt), 'manifest': str(manifest_path), 'manifest_sha256': sha(manifest_path), 'installer_sha256': sha(installer), 'file_rows': len(rows)}))
if __name__ == '__main__':
    main()
