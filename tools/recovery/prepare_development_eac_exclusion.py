"""Read-only native dependency audit; stage one importer-only dev-test candidate."""
from pathlib import Path
import hashlib
import json
import re
import sys
from stage_original_native_sdk_dependencies import PE, regular

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
PROJECT = WS / 'RR23'


def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()


def row(path):
    path = regular(path)
    return {'path': str(path), 'sha256': sha(path), 'bytes': path.stat().st_size}


def need(value, message):
    if not value:
        raise ValueError(message)


def main():
    out = Path(sys.argv[1]).resolve(strict=True)
    need(out.is_relative_to(ROOT / 'Validation') and out.name.startswith('AntiCheatDevelopmentScope-'), 'Exact audit output required')
    managed_path = out / 'managed-metadata.json'
    managed = json.loads(managed_path.read_text(encoding='utf-8-sig'))
    need(managed['schema'] == 'read-only-current-anticheat-managed-metadata/v1' and not managed['main_modified'] and not managed['game_or_sdk_assembly_loaded'], 'Data-only metadata proof required')
    for entry in managed['assemblies']:
        need(sha(entry['path']) == entry['sha256'], 'Current managed input changed since metadata audit')
    native = PROJECT / 'Assets/Plugins/x86_64/EasyAntiCheat.dll'
    meta = native.with_suffix('.dll.meta')
    original = ROOT / 'VerifiedSource/RecRoom_Data/Plugins/x86_64/EasyAntiCheat.dll'
    before_native, before_meta, original_row = row(native), row(meta), row(original)
    need(before_native['sha256'] == original_row['sha256'] == 'a28868b356c034cba9aa93b2e88cb950fdde5f226a315d489bd9c1de219e784f', 'Installed original EAC bytes must remain exact')
    imports = []
    for path in sorted((PROJECT / 'Assets/Plugins').rglob('*.dll')):
        regular(path)
        with path.open('rb') as stream:
            first = stream.read(2)
        if first != b'MZ':
            continue
        pe = PE(path.read_bytes())
        description = pe.record()
        if description['has_managed_CLI_directory']:
            continue
        imports.append({'file': row(path), **description})
    dependents = [{'path': entry['file']['path'], 'imports': [name for name in entry['imports'] + entry['delay_imports'] if name.casefold() == 'easyanticheat.dll']}
                  for entry in imports if any(name.casefold() == 'easyanticheat.dll' for name in entry['imports'] + entry['delay_imports'])]
    need(not dependents, 'Another installed native DLL statically/delay-imports EAC; importer exclusion refused')
    before = meta.read_bytes()
    need(b'\r' not in before and b'  isPreloaded: 0\n' in before, 'Exact known native importer shape required')
    pattern = rb'(      Standalone: Win64\n    second:\n      enabled: )1(\n)'
    after, count = re.subn(pattern, rb'\g<1>0\2', before)
    need(count == 1 and after != before, 'One exact Windows64 enable bit required')
    guid = re.findall(rb'(?m)^guid: ([0-9a-f]{32})$', before)
    need(guid == [b'33278729866d3c89acec2267237782dd'] and re.findall(rb'(?m)^guid: ([0-9a-f]{32})$', after) == guid, 'Existing EAC importer GUID must remain identical')
    need(b'      Any:\n    second:\n      enabled: 0\n' in before and b'      Editor: Editor\n    second:\n      enabled: 0\n' in before, 'Editor and Any are already disabled')
    candidate = out / 'Candidate/Assets/Plugins/x86_64/EasyAntiCheat.dll.meta'
    candidate.parent.mkdir(parents=True)
    with candidate.open('xb') as stream:
        stream.write(after)
    backup = out / 'Before/EasyAntiCheat.dll.meta'
    backup.parent.mkdir()
    with backup.open('xb') as stream:
        stream.write(before)
    link = PROJECT / 'Assets/StreamingAssets/aa/AddressablesLink/link.xml'
    link_text = link.read_text(encoding='utf-8')
    anchors = []
    for number, text in enumerate(link_text.splitlines(), 1):
        if 'RecRoom.AntiCheat.EACManager' in text or 'CodeStage.AntiCheat.Detectors.' in text:
            anchors.append({'path': str(link), 'line': number, 'text': text.strip()})
    # Full-text scans of every scene and prefab are exact. Large .asset payloads
    # are not scanned here; the managed assemblies are deliberately retained.
    wanted = {'eac_managed': '62685ee57c0ec44c5e8a6147d06dfa24', 'rranticheat_managed': 'de49718ddcfd6ae904afc221198bb8f4',
              'codestage_managed': '41f908e71df54d894b27bc6bfd892a05', 'cheat_manager_source': '8a04f8798f1a4c52d6b75127fa260861',
              'advanced_motion_source': '0972949ada145355b0c837d6ea3bc76b'}
    hits, counts = [], {'.unity': 0, '.prefab': 0}
    for suffix in counts:
        for path in (PROJECT / 'Assets').rglob('*' + suffix):
            regular(path)
            counts[suffix] += 1
            data = path.read_bytes()
            for label, value in wanted.items():
                if value.encode('ascii') in data:
                    hits.append({'label': label, 'path': str(path), 'guid': value})
    recorders = {Path(entry['path']).name: entry for entry in managed['assemblies']}
    eac = recorders['EasyAntiCheat.Client.dll']
    rr = recorders['RecRoom.Rranticheat.Runtime.dll']
    core = recorders['Assembly-CSharp.dll']
    need(eac['impl_map_rows'] == 0 and not eac['module_refs'] and rr['impl_map_rows'] == 0 and not rr['module_refs'], 'Unexpected active native import metadata')
    need(not rr['anti_cheat_member_refs'] and not any('EasyAntiCheat' in name or 'Rranticheat' in name for name in core['assembly_refs']), 'Unexpected current EAC member path')
    proof = []
    for assembly, owners in ((eac, ('EasyAntiCheat.Client.Hydra.NativeClient', 'EasyAntiCheat.Client.Hydra.Runtime', 'EasyAntiCheat.Client.ClientAuth.ClientAuth')), (rr, ('RecRoom.AntiCheat.EACManager',))):
        for method in assembly['selected_methods']:
            if method['owner'] in owners and method['name'] in ('Initialize', 'IsStartedWithEasyAntiCheat', 'IsActive', 'Release', 'Dispose', 'WriteChallengeResponse', 'Start', 'Update', 'OnDestroy', 'OnApplicationQuit', 'GenerateChallengeResponse', 'PushNetworkMessage', 'PollStatus'):
                proof.append({'assembly': Path(assembly['path']).name, **method})
    report = {
        'schema': 'staged-windows-development-unneeded-eac-native-importer-exclusion/v1',
        'status': 'candidate_staged_not_applied', 'project_modified': False, 'Editor_or_compiler_launched': False,
        'game_or_native_SDK_methods_invoked': False, 'official_service_changed': False,
        'only_candidate_change': 'Assets/Plugins/x86_64/EasyAntiCheat.dll.meta: Standalone Win64 enabled 1 -> 0; Any/Editor remain 0, preloaded remains 0, existing GUID unchanged.',
        'current_native': before_native, 'verified_original_native': original_row,
        'before_importer': before_meta, 'before_backup': row(backup), 'candidate_importer': row(candidate),
        'native_PE_inputs_count': len(imports), 'native_static_and_delay_import_dependents_on_EAC': dependents,
        'native_PE_imports': imports, 'managed_metadata': row(managed_path), 'current_stub_evidence': proof,
        'serialized_scene_and_prefab_scan': {'full_file_counts': counts, 'GUIDs': wanted, 'hits': hits,
                                             'limitation': 'No claim of absence from every .asset or packed original Addressable bundle; no managed types, components, GUIDs, or serialized assets are removed.'},
        'retained_linker_anchors': anchors, 'linker_file': row(link),
        'keep_managed': ['EasyAntiCheat.Client.dll retains Rranticheat field/event type dependencies.',
                         'RecRoom.Rranticheat.Runtime.dll retains EACManager linker/serialized identity.',
                         'Codestage.Anticheattoolkit.Runtime.dll retains Obscured types used by Assembly-CSharp, PhotonRealtime, RecNet, OverridableFields, Maker and RoomLoading; ACTkDetectorBase is a live class inheritance dependency.'],
        'conclusion': 'The current recovered managed EAC startup wrappers are stubs and have no ImplMap/ModuleRef. No current managed EAC startup or installed native static dependency requires the original native EAC DLL. Disable its Windows64 importer only for this recovered development test configuration.',
        'future_genuine_body_audit_required': 'Any future restoration of genuine EACManager, wrapper, auth, native import, or dynamic LoadLibrary startup bodies invalidates this exclusion proof and requires a fresh dependency/startup audit before enabling that path. This audit does not manufacture responses, tickets, success states, or attestations.',
        'tool': row(Path(__file__))}
    need(sha(native) == before_native['sha256'] and sha(meta) == before_meta['sha256'] and sha(original) == original_row['sha256'], 'Main or original changed during staging')
    for entry in managed['assemblies']:
        need(sha(entry['path']) == entry['sha256'], 'Managed source changed during staging')
    result = out / 'native-and-candidate.json'
    result.write_text(json.dumps(report, indent=2) + '\n', encoding='utf-8')
    print(json.dumps({'status': report['status'], 'report': str(result), 'report_sha256': sha(result), 'candidate': row(candidate), 'native_inputs': len(imports), 'native_dependents': len(dependents), 'serialized_hits': len(hits)}))


if __name__ == '__main__':
    main()
