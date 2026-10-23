"""Audit and stage verified original PC native dependencies without loading them.

Does not alter Main, its packages, platform settings or existing plugin importers.
Importer files are explicit reconstruction proposals, not recovered original metas.
"""
import hashlib
import json
import mmap
import os
import shutil
import struct
from datetime import datetime, timezone
from pathlib import Path
from uuid import uuid4

WS = Path(__file__).resolve().parents[3]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
SOURCE = ROOT / 'VerifiedSource'
MAIN = WS / 'RR23'
INDEX = ROOT / 'Preflight/public-archive-inventory.json'
INDEX_SHA = 'd3c2cbe890716d3c0d390876e059126a04772179d00c0c237fdaccf9622453e0'

def need(value, text):
    if not value:
        raise ValueError(text)
def sha(path):
    with Path(path).open('rb') as stream:
        return hashlib.file_digest(stream, 'sha256').hexdigest()
def regular(path):
    path = Path(path).absolute()
    for item in [path, *path.parents]:
        if item.exists():
            stat = item.lstat()
            need(not getattr(stat, 'st_file_attributes', 0) & 0x400, 'Reparse ancestry refused: ' + str(item))
    need(path.is_file() and not path.is_symlink(), 'Regular file required')
    return path

class PE:
    def __init__(self, blob):
        self.b = blob
        need(blob[:2] == b'MZ', 'PE DOS signature required')
        pe = self.u32(0x3c)
        need(blob[pe:pe+4] == b'PE\0\0', 'PE signature required')
        self.machine = self.u16(pe+4)
        count, opt_size = self.u16(pe+6), self.u16(pe+20)
        self.opt = pe+24
        magic = self.u16(self.opt)
        need(magic in (0x10b, 0x20b), 'Known PE optional-header format required')
        self.dd = self.opt + (112 if magic == 0x20b else 96)
        section_start = self.opt+opt_size
        need(0 < count <= 96, 'Bounded section count required')
        self.sections = []
        for index in range(count):
            row = section_start + index*40
            self.sections.append((self.u32(row+12), self.u32(row+8), self.u32(row+20), self.u32(row+16)))
    def u16(self, at):
        need(0 <= at <= len(self.b)-2, 'PE ushort bounds')
        return struct.unpack_from('<H', self.b, at)[0]
    def u32(self, at):
        need(0 <= at <= len(self.b)-4, 'PE uint bounds')
        return struct.unpack_from('<I', self.b, at)[0]
    def offset(self, rva, size=1):
        rows = [raw+rva-va for va, virtual, raw, length in self.sections if va <= rva and rva+size <= va+length]
        need(len(rows) == 1 and rows[0]+size <= len(self.b), 'Unique bounded PE RVA mapping required')
        return rows[0]
    def string(self, rva):
        start = self.offset(rva)
        end = self.b.find(b'\0', start, min(len(self.b), start+1024))
        need(end >= start, 'Bounded zero-terminated PE import name required')
        return self.b[start:end].decode('ascii')
    def imports(self, delayed=False):
        directory = 13 if delayed else 1
        rva, size = self.u32(self.dd+directory*8), self.u32(self.dd+directory*8+4)
        if not rva:
            return []
        width = 32 if delayed else 20
        need(width <= size <= 1024*1024, 'Bounded import directory size required')
        start = self.offset(rva, size)
        names = []
        for at in range(start, start+size-width+1, width):
            if self.b[at:at+width] == bytes(width):
                return names
            if delayed:
                need(self.u32(at) & 1, 'Delay-import names must use RVAs')
            names.append(self.string(self.u32(at+(4 if delayed else 12))))
        raise ValueError('Import descriptor terminator required')
    def record(self):
        return {'machine': hex(self.machine), 'is_x64': self.machine == 0x8664,
            'has_managed_CLI_directory': bool(self.u32(self.dd+14*8)),
            'imports': self.imports(), 'delay_imports': self.imports(True)}

def importer(guid, editor):
    return ('''fileFormatVersion: 2
guid: GUID
PluginImporter:
  externalObjects: {}
  serializedVersion: 2
  iconMap: {}
  executionOrder: {}
  defineConstraints: []
  isPreloaded: 0
  isOverridable: 0
  isExplicitlyReferenced: 0
  validateReferences: 0
  platformData:
  - first:
      Any:
    second:
      enabled: 0
      settings: {}
  - first:
      Editor: Editor
    second:
      enabled: EDITOR
      settings:
        CPU: x86_64
        OS: Windows
        DefaultValueInitialized: true
  - first:
      Standalone: Win64
    second:
      enabled: 1
      settings:
        CPU: x86_64
  userData:
  assetBundleName:
  assetBundleVariant:
''').replace('GUID', guid).replace('EDITOR', '1' if editor else '0').encode('utf-8')

def main():
    need(sha(INDEX) == INDEX_SHA, 'Verified public inventory changed')
    inventory = {row[0]: {'bytes': row[1], 'sha256': row[2]} for row in json.loads(INDEX.read_bytes())['files']}
    original_paths = sorted(path for path in inventory if path.startswith('RecRoom_Data/Plugins/x86_64/') and path.endswith('.dll'))
    need(len(original_paths) == 27, 'Exact original 27 native PC plugin DLLs required')
    root_before = {name: sha(MAIN/name) for name in ['Packages/manifest.json', 'Packages/packages-lock.json', 'ProjectSettings/ProjectSettings.asset']}
    out = ROOT / 'RuntimeSDKRecovery' / ('OriginalNativeDependencies-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid4().hex[:8])
    out.mkdir()
    files = []
    source_names = {Path(path).name.lower() for path in original_paths}
    main_dlls = {path.name.casefold(): path for path in (MAIN/'Assets/Plugins').rglob('*.dll')}
    for relative in original_paths:
        original = regular(SOURCE/relative)
        witness = inventory[relative]
        need(original.stat().st_size == witness['bytes'] and sha(original) == witness['sha256'], 'Original native DLL does not match verified inventory')
        with original.open('rb') as stream, mmap.mmap(stream.fileno(), 0, access=mmap.ACCESS_READ) as blob:
            pe = PE(blob).record()
        need(pe['is_x64'] and not pe['has_managed_CLI_directory'], 'Original source must be AMD64 native, never a replacement managed/runtime assembly')
        name = original.name
        candidate = out/'Binaries/Assets/Plugins/x86_64'/name
        candidate.parent.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(original, candidate)
        need(sha(candidate) == witness['sha256'], 'Staged native copy drift')
        existing = main_dlls.get(name.casefold())
        dependencies = []
        for imported in sorted(set(pe['imports']+pe['delay_imports'])):
            if imported.lower() in source_names:
                kind = 'retained_original_native_plugin'
            elif imported.lower().startswith(('api-ms-win-', 'ext-ms-win-')):
                kind = 'Windows_API_set_contract'
            elif (Path(os.environ.get('SystemRoot', r'C:\Windows'))/'System32'/imported).is_file():
                kind = 'installed_Windows_System32_dependency_not_copied'
            elif (SOURCE/imported).is_file():
                kind = 'original_player_root_dependency_not_an_Assets_plugin'
            else:
                kind = 'not_resolved_by_this_static_inventory'
            dependencies.append({'name': imported, 'classification': kind})
        guid = hashlib.sha256(('rr23-native-plugin-proposal/v1|'+relative+'|'+witness['sha256']).encode()).hexdigest()[:32]
        proposals = []
        for folder, enable in [('WindowsPlayerOnly', False), ('WindowsEditorAndPlayer', True)]:
            target = out/'ImporterProposals'/folder/(name+'.meta')
            target.parent.mkdir(parents=True, exist_ok=True)
            target.write_bytes(importer(guid, enable))
            proposals.append({'path': str(target), 'sha256': sha(target), 'Editor_Windows_x64_enabled': enable, 'Standalone_Win64_enabled': True, 'preloaded': False})
        files.append({'source_relative_path': relative, 'source_path': str(original), **witness,
            'candidate': str(candidate), 'project_relative_path': 'Assets/Plugins/x86_64/'+name,
            'existing_same_basename_in_Main': str(existing) if existing else None,
            'existing_sha256': sha(existing) if existing else None, 'PE': pe, 'dependencies': dependencies,
            'importer_proposals': proposals, 'original_meta_or_GUID_recovered': False,
            'routing_status': 'stage_only_original_platform_filter_unknown_requires_review',
            'build_generated_burst_artifact': name == 'lib_burst_generated.dll'})
    texts = []
    steam = 'RecRoom_Data/Plugins/Steamworks.NET.txt'
    need(sha(SOURCE/steam) == inventory[steam]['sha256'], 'Original Steamworks version witness changed')
    target = out/'Evidence/Steamworks.NET.txt'
    target.parent.mkdir()
    shutil.copyfile(SOURCE/steam, target)
    texts.append({'source': str(SOURCE/steam), 'candidate': str(target), **inventory[steam]})
    # Preserve original SteamVR input configuration as data, with no app-key edits.
    for relative, witness in sorted(inventory.items()):
        if not relative.startswith('RecRoom_Data/StreamingAssets/SteamVR/'):
            continue
        original = regular(SOURCE/relative)
        need(sha(original) == witness['sha256'], 'Original SteamVR configuration changed')
        candidate = out/'StreamingAssetsProposal/Assets/StreamingAssets/SteamVR'/Path(relative).name
        candidate.parent.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(original, candidate)
        need(sha(candidate) == witness['sha256'], 'SteamVR staged byte drift')
        texts.append({'source': str(original), 'candidate': str(candidate), 'project_relative_path': 'Assets/StreamingAssets/SteamVR/'+candidate.name, **witness,
            'existing_Main': (MAIN/'Assets/StreamingAssets/SteamVR'/candidate.name).exists()})
    need(all(sha(MAIN/name) == digest for name, digest in root_before.items()), 'Main inputs changed while staging')
    installed = sorted(path.name for path in (WS/'Tools/Editors/2020.3.33f1/Editor/Data/PlaybackEngines').iterdir() if path.is_dir())
    manifest = {'schema': 'verified-original-PC-native-SDK-dependency-stage/v1', 'status': 'staged_not_installed_or_loaded',
        'verified_source_inventory': {'path': str(INDEX), 'sha256': INDEX_SHA}, 'original_build': '2023-04-18T06-58-58Z',
        'Unity_version': '2020.3.33f1', 'native_originals': files, 'original_config_and_version_evidence': texts,
        'summary': {'original_PC_native_DLLs': len(files), 'native_bytes': sum(row['bytes'] for row in files),
            'missing_same_basename_from_Main': sum(not row['existing_same_basename_in_Main'] for row in files),
            'original_SteamVR_config_files': len(texts)-1, 'main_managed_and_other_plugin_DLLs': len(main_dlls),
            'installed_Editor_build_support_folders': installed},
        'platform_limitations': ['The verified archive is Windows x64. It supplies no Android/Quest .so/AAR or iOS .a/framework SDK payloads.',
            'Original native importer metas and their GUID/platform filters were not included in the player; proposals are explicitly reconstructed and inactive outside this staging directory.',
            'lib_burst_generated.dll is an original build-generated binary; copying it is preservation, not proof it matches editable-source Burst jobs.',
            'Do not install UPM copies of managed SDK assemblies already represented by the 225-plugin compiler/runtime plan.',
            'No security/bootstrap DLL, SDK initializer, original game code, or native library was loaded or invoked.'],
        'Main_input_hashes_unchanged': root_before, 'Main_modified': False, 'Unity_launched': False, 'native_code_loaded': False}
    report = out/'report.json'
    report.write_text(json.dumps(manifest, indent=2)+'\n', encoding='utf-8')
    print(json.dumps({'report': str(report), 'sha256': sha(report), **manifest['summary']}))
if __name__ == '__main__':
    main()
