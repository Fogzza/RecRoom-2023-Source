"""Stage the already downloaded, pinned official Addressables tarball as inert data.

No package install, Editor launch, code execution, or existing-project write.
"""
from pathlib import Path, PurePosixPath
import hashlib
import json
import tarfile

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18/RuntimeSDKRecovery/Addressables-1.20.5'
ARCHIVE = ROOT / 'com.unity.addressables-1.20.5.tgz'
EXPECTED = 'e909683879ac318814a42023c2c2594011a923833beaa9285f7cd2a887f5ef47'


def sha(path):
    value = hashlib.sha256()
    with path.open('rb') as stream:
        while block := stream.read(1024 * 1024):
            value.update(block)
    return value.hexdigest()


def main():
    if sha(ARCHIVE) != EXPECTED or ARCHIVE.stat().st_size != 2721118:
        raise ValueError('The official tarball differs from the prior pinned audit.')
    target = ROOT / 'OfficialPackage'
    if target.exists():
        raise ValueError('Fresh package directory required; previous evidence is immutable.')
    rows = []
    with tarfile.open(ARCHIVE, 'r:gz') as archive:
        members = archive.getmembers()
        seen = set()
        total = 0
        for member in members:
            path = PurePosixPath(member.name)
            if (path.is_absolute() or not path.parts or path.parts[0] != 'package'
                    or any(part in ('', '..') or ':' in part or '\\' in part for part in path.parts)
                    or member.name.casefold() in seen or not (member.isfile() or member.isdir())):
                raise ValueError('Unsafe or duplicate archive member: ' + member.name)
            seen.add(member.name.casefold())
            if member.size > 16 * 1024 * 1024:
                raise ValueError('Unexpected large archive member.')
            total += member.size
        if total > 64 * 1024 * 1024 or len(members) > 10000:
            raise ValueError('Unexpected archive expansion.')
        target.mkdir()
        for member in members:
            relative = PurePosixPath(member.name).relative_to('package')
            path = target.joinpath(*relative.parts)
            if member.isdir():
                path.mkdir(parents=True, exist_ok=True)
                continue
            path.parent.mkdir(parents=True, exist_ok=True)
            stream = archive.extractfile(member)
            digest = hashlib.sha256()
            count = 0
            with path.open('xb') as output:
                while block := stream.read(1024 * 1024):
                    count += len(block)
                    output.write(block)
                    digest.update(block)
            if count != member.size:
                raise ValueError('Truncated member: ' + member.name)
            rows.append({'path': relative.as_posix(), 'bytes': count, 'sha256': digest.hexdigest()})
    package = json.loads((target / 'package.json').read_text(encoding='utf-8-sig'))
    if package['name'] != 'com.unity.addressables' or package['version'] != '1.20.5':
        raise ValueError('Unexpected package identity.')
    report = {'schema': 'official-addressables-source-stage/v1', 'status': 'hash-verified-source-only',
              'source_url': 'https://packages.unity.com/com.unity.addressables/-/com.unity.addressables-1.20.5.tgz',
              'archive': {'path': str(ARCHIVE), 'bytes': ARCHIVE.stat().st_size, 'sha256': EXPECTED},
              'tool': {'path': str(Path(__file__).resolve()), 'sha256': sha(Path(__file__).resolve())},
              'package_name': package['name'], 'package_version': package['version'],
              'minimum_unity': package['unity'], 'repository_revision': package['repository']['revision'],
              'dependencies': package['dependencies'], 'source_files': rows,
              'project_changed': False, 'game_code_executed': False, 'package_installed': False}
    (ROOT / 'source-provenance.json').write_text(json.dumps(report, indent=2) + '\n')
    print(json.dumps({'status': report['status'], 'files': len(rows), 'expanded_bytes': total,
                      'report': str(ROOT / 'source-provenance.json')}))


if __name__ == '__main__':
    main()
