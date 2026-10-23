"""Pin original SDK versions/platform evidence and separate installable proposals.

Read-only original metadata parsing and staged data copies; no native/Unity calls.
"""
import hashlib
import json
import mmap
import shutil
import struct
from datetime import datetime, timezone
from pathlib import Path
from uuid import uuid4

from stage_original_native_sdk_dependencies import ROOT, SOURCE, WS, INDEX, INDEX_SHA, need, regular, sha

NATIVE = ROOT/'RuntimeSDKRecovery/OriginalNativeDependencies-20261022T181919Z-ab0b5c62/report.json'
NATIVE_SHA = '0aecef17eeaaaecd1277275e06e970fd3bf44a59c22038ecd32be98c4ce74c26'
META = ROOT/'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat'
META_SHA = '1e7144d3370615f231ccbfec10e78fc98bb798f0eb46d7a929ee0eec6390d474'
SECTIONS = ('stringLiteral stringLiteralData string events properties methods parameterDefaultValues fieldDefaultValues fieldAndParameterDefaultValueData fieldMarshaledSizes parameters fields genericParameters genericParameterConstraints genericContainers nestedTypes interfaces vtableMethods interfaceOffsets typeDefinitions images assemblies fieldRefs referencedAssemblies attributesInfo attributeTypes unresolvedVirtualCallParameterTypes unresolvedVirtualCallParameterRanges windowsRuntimeTypeNames windowsRuntimeStrings exportedTypeDefinitions').split()

def assembly_identities():
    need(sha(META) == META_SHA, 'Exact original metadata required')
    rows = []
    with META.open('rb') as stream, mmap.mmap(stream.fileno(), 0, access=mmap.ACCESS_READ) as blob:
        need(struct.unpack_from('<II', blob, 0) == (0xfab11baf, 27), 'Original v27 metadata required')
        sections = {name: struct.unpack_from('<ii', blob, 8+i*8) for i, name in enumerate(SECTIONS)}
        offset, length = sections['assemblies']
        need(length == 279*64, 'Exact original 279 AssemblyDef64 table required')
        def text(index):
            start, size = sections['string']
            need(0 <= index < size, 'Metadata string bounds')
            end = blob.find(b'\0', start+index, start+size)
            need(end >= start+index, 'Metadata string terminator')
            return blob[start+index:end].decode('utf-8')
        for i in range(279):
            at = offset+i*64
            image, token, referenced_start, referenced_count = struct.unpack_from('<iIii', blob, at)
            ni, ci, pi, alg, hlen, flags, major, minor, build, revision = struct.unpack_from('<iiiIiIiiii', blob, at+16)
            pkt = bytes(blob[at+56:at+64]).hex()
            name, culture = text(ni), text(ci)
            version = '.'.join(map(str, [major, minor, build, revision]))
            rows.append({'name': name, 'image_index': image, 'native_assembly_token': hex(token), 'AssemblyVersion': version,
                'FullName': name+', Version='+version+', Culture='+(culture or 'neutral')+', PublicKeyToken='+(pkt if int(pkt, 16) else 'null'),
                'flags': flags, 'AssemblyVersion_is_UPM_package_version': False})
    need(sha(META) == META_SHA, 'Original metadata changed')
    return rows

def main():
    need(sha(NATIVE) == NATIVE_SHA and sha(INDEX) == INDEX_SHA, 'Pinned staging/source inventory changed')
    native = json.loads(NATIVE.read_bytes())
    inventory = {row[0]: {'bytes': row[1], 'sha256': row[2]} for row in json.loads(INDEX.read_bytes())['files']}
    assemblies = assembly_identities()
    selected = [row for row in assemblies if any(x in row['name'].lower() for x in ['photon', 'oculus', 'steam', 'openvr', 'textmesh', 'addressable', 'resourcemanager', 'inputsystem', 'renderpipeline', 'xr.management', 'probuild', 'burst', 'firebase', 'speech'])]
    out = ROOT/'RuntimeSDKRecovery'/('OriginalSDKDependencyPlan-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid4().hex[:8])
    out.mkdir()
    subsystem_rows = []
    for relative, witness in sorted(inventory.items()):
        if not relative.startswith('RecRoom_Data/UnitySubsystems/') or not relative.endswith('/UnitySubsystemsManifest.json'):
            continue
        source = regular(SOURCE/relative)
        need(sha(source) == witness['sha256'], 'Original subsystem manifest drift')
        candidate = out/'OriginalSubsystemEvidence'/Path(relative).relative_to('RecRoom_Data')
        candidate.parent.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(source, candidate)
        descriptor = json.loads(candidate.read_bytes())
        library = descriptor['libraryName']
        matches = [row for row in native['native_originals'] if Path(row['source_relative_path']).stem.casefold() == library.casefold()]
        subsystem_rows.append({'original_relative_path': relative, 'candidate': str(candidate), **witness,
            'name': descriptor['name'], 'subsystem_manifest_version': descriptor['version'], 'library_name': library,
            'subsystem_version_is_SDK_package_version': False, 'verified_archive_matching_native_libraries': [row['source_relative_path'] for row in matches],
            'target_package_import_layout_not_recovered': True, 'Main_deployment_proposed': False})
    need(len(subsystem_rows) == 2, 'Exact original two subsystem manifest witnesses')
    settings_relative = 'RecRoom_Data/StreamingAssets/aa/settings.json'
    settings = SOURCE/settings_relative
    need(sha(settings) == inventory[settings_relative]['sha256'], 'Original Addressables settings changed')
    addressables = json.loads(settings.read_bytes())['m_AddressablesVersion']
    ovr = ROOT/'Validation/OculusWrapperVersionProof-20261022T160555Z-d6310247/report.json'
    ovr_doc = json.loads(ovr.read_bytes())
    need(ovr_doc['status'] == 'proven' and ovr_doc['native_wrapper_version'] == [1, 78, 0], 'Original native OVR version proof')
    sdk_versions = [
        {'SDK': 'Unity Editor/player serialization', 'version': '2020.3.33f1', 'authority': 'Original bundle headers and exact installed Editor revision915a7af8b0d5'},
        {'SDK': 'Addressables/ResourceManager', 'version': addressables, 'authority': {'path': str(settings), **inventory[settings_relative]}, 'genuine_2DLL_behavior_test_passed': True},
        {'SDK': 'Steamworks.NET', 'version': '14.0.0', 'Steamworks_SDK_version': '1.48', 'authority': {'path': str(SOURCE/'RecRoom_Data/Plugins/Steamworks.NET.txt'), **inventory['RecRoom_Data/Plugins/Steamworks.NET.txt']}},
        {'SDK': 'Oculus/OVR native wrapper', 'version': '1.78.0', 'UPM_or_asset_package_version': 'unknown', 'authority': {'path': str(ovr), 'sha256': sha(ovr)}},
        {'SDK': 'Firebase native App library', 'version': '8.5.0', 'managed_package_version': 'not_proven_by_filename', 'authority': {'path': str(SOURCE/'RecRoom_Data/Plugins/x86_64/FirebaseCppApp-8_5_0.dll'), **inventory['RecRoom_Data/Plugins/x86_64/FirebaseCppApp-8_5_0.dll']}}
    ]
    deployable = []
    held = []
    for row in native['native_originals']:
        need(sha(row['candidate']) == row['sha256'], 'Staged SDK bytes changed')
        payload = {'path': row['candidate'], 'sha256': row['sha256'], 'project_relative_path': row['project_relative_path'],
            'source_relative_path': row['source_relative_path'], 'bytes': row['bytes'], 'actual_native_execution_tested': False}
        if row['build_generated_burst_artifact']:
            payload.update(status='preservation_only_excluded_from_deployment', reason='Build-generated original Burst code; editable-source job/function-pointer compatibility is unproven. Empty import table does not prove reuse safety.')
            held.append(payload)
        else:
            payload.update(status='proposal_not_installed', importer_proposals=row['importer_proposals'],
                original_importer_meta_recovered=False, proposed_enablement='Windows x64 only; Editor enablement requires the selected importer proposal and dependency binding review; never Any Platform or preload')
            deployable.append(payload)
    unresolved = [(Path(row['source_relative_path']).name, dep['name']) for row in native['native_originals'] for dep in row['dependencies'] if dep['classification'] == 'not_resolved_by_this_static_inventory']
    report = {'schema': 'original-2023-SDK-dependency-inventory-and-staging-plan/v1', 'status': 'staged_pending_importer_and_runtime_binding_review',
        'source_native_stage': {'path': str(NATIVE), 'sha256': NATIVE_SHA}, 'native_metadata_authority': {'path': str(META), 'sha256': META_SHA},
        'known_versions': sdk_versions, 'original_SDK_AssemblyIdentities': selected,
        'native_plugin_proposals': deployable, 'build_generated_binaries_held': held,
        'original_subsystem_evidence': subsystem_rows, 'unresolved_PE_import_names': unresolved,
        'platforms': {'installed_build_support': ['windowsstandalonesupport'],
            'Android_and_Meta_Quest_build_support': 'not_installed_for_this_matching_Editor', 'iOS_build_support': 'not_installed_for_this_matching_Editor',
            'original_Android_Quest_iOS_native_SDK_payloads': 'not_present_in_the_verified_Windows_archive',
            'existing_multi_platform_settings_and_managed_conditional_source': 'preserved_by_this_stage; no platform reconstruction or migration'},
        'UPM_plan': {'Packages_manifest_changed': False, 'packages_to_add_now': [], 'reason': '225 original-identity managed plugins already supply these runtime assemblies. Installing modern/default UPM duplicates would create assembly and MonoScript identity conflicts. Exact editor package versions beyond native/runtime evidence remain unresolved.'},
        'counts': {'verified_native_DLLs_preserved': 27, 'ordinary_PC_native_plugin_proposals': len(deployable), 'Burst_preservation_only': len(held), 'subsystem_manifests': len(subsystem_rows), 'SteamVR_config_files': 14, 'managed_plugin_runtime_count': 225},
        'excluded_engine_client_payloads': ['GameAssembly.dll', 'UnityPlayer.dll', 'RecRoom.exe', 'Recroom_Release.exe', 'UnityCrashHandler64.exe', 'baselib.dll'],
        'Main_modified': False, 'managed_or_native_game_code_invoked': False, 'Unity_launched': False}
    path = out/'report.json'
    path.write_text(json.dumps(report, indent=2)+'\n', encoding='utf-8')
    print(json.dumps({'report': str(path), 'sha256': sha(path), 'counts': report['counts'], 'known_versions': [{'SDK': row['SDK'], 'version': row['version']} for row in sdk_versions]}))
if __name__ == '__main__':
    main()
