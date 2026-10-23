"""Read-only publication inventory. Never copies project files or prints values."""
from pathlib import Path
from collections import Counter, defaultdict
import datetime as dt
import hashlib
import json
import re
import subprocess
import uuid

WS = Path(__file__).resolve().parents[3]
PROJECT = WS / 'RR23'
OUT_BASE = WS / 'Recovery/RecRoom-2023-04-18/SourcePublicationAudit'
SOURCE_ROOTS = {'Assets', 'Packages', 'ProjectSettings', 'CompilerSupport'}
TEXT_EXTS = {'.cs', '.shader', '.compute', '.cginc', '.hlsl', '.glsl', '.json', '.yaml', '.yml', '.asset', '.meta', '.unity', '.prefab', '.mat', '.txt', '.xml', '.props', '.asmdef', '.asmref', '.rsp', '.config', '.ini', '.md', '.html', '.js', '.ts', '.py', '.bat', '.cmd', '.ps1', '.csv', '.uss', '.uxml'}
GENERATED = {'Library', 'Temp', 'Obj', 'obj', 'Logs', 'UserSettings', '.vs', '.idea', '.git'}
PATTERNS = {
    'private_key_header': re.compile(rb'-----BEGIN (?:RSA |EC |DSA |OPENSSH |ENCRYPTED )?PRIVATE KEY-----'),
    'github_token_format': re.compile(rb'(?<![A-Za-z0-9_])(?:gh[pousr]_[A-Za-z0-9]{30,255}|github_pat_[A-Za-z0-9_]{30,255})(?![A-Za-z0-9_])'),
    'aws_access_key_id_format': re.compile(rb'(?<![A-Z0-9])(?:AKIA|ASIA)[A-Z0-9]{16}(?![A-Z0-9])'),
    'cloudflare_token_format': re.compile(rb'(?<![A-Za-z0-9_])(?:cf_api_token|CLOUDFLARE_API_TOKEN|CLOUDFLARE_API_KEY)\s*[=:]\s*[\"\x27]?[A-Za-z0-9_-]{20,255}', re.I),
    'slack_token_format': re.compile(rb'(?<![A-Za-z0-9])xox[baprs]-[A-Za-z0-9-]{20,255}'),
    'jwt_literal_format': re.compile(rb'(?<![A-Za-z0-9_-])eyJ[A-Za-z0-9_-]{8,2048}\.[A-Za-z0-9_-]{8,4096}\.[A-Za-z0-9_-]{16,512}(?![A-Za-z0-9_-])'),
    'credential_in_url': re.compile(rb'https?://[^\s/\"\x27:@]{1,100}:[^\s/\"\x27@]{1,200}@', re.I),
    'possible_literal_secret_assignment': re.compile(rb'(?i)(?:password|passwd|client_secret|secret_key|api_secret|api_key|apikey|access_token|refresh_token|authorization)[A-Za-z0-9_]{0,64}[\"\x27]?\s*[:=]\s*[\"\x27]([^\"\x27\r\n]{8,500})[\"\x27]'),
}
TRIGGERS = {
    'private_key_header': (b'private key-----',),
    'github_token_format': (b'ghp_', b'gho_', b'ghu_', b'ghs_', b'ghr_', b'github_pat_'),
    'aws_access_key_id_format': (b'akia', b'asia'),
    'cloudflare_token_format': (b'cf_api_token', b'cloudflare_api_token', b'cloudflare_api_key'),
    'slack_token_format': (b'xox',),
    'jwt_literal_format': (b'eyj',),
    'credential_in_url': (b'http://', b'https://'),
    'possible_literal_secret_assignment': (b'password', b'passwd', b'client_secret', b'secret_key', b'api_secret', b'api_key', b'apikey', b'access_token', b'refresh_token', b'authorization'),
}

def dump(path, obj):
    with path.open('x', encoding='utf-8') as f:
        json.dump(obj, f, indent=2)
        f.write('\n')

def digest(path):
    with path.open('rb') as f:
        return hashlib.file_digest(f, 'sha256').hexdigest()

def main():
    result = subprocess.run(['rg', '--files', '--hidden', '--no-ignore', 'Assets', 'Packages', 'ProjectSettings', 'CompilerSupport'], cwd=PROJECT, capture_output=True, text=True, encoding='utf-8', errors='strict', check=True)
    names = sorted(set(line.replace('\\', '/') for line in result.stdout.splitlines()) | {'SolarNet.Unity2020.props'})
    groups = defaultdict(lambda: {'files': 0, 'bytes': 0})
    source, large, sensitive_names, source_changes, skipped = [], [], [], [], []
    findings = []
    by_rule = Counter()
    scene_paths, script_groups = [], defaultdict(lambda: {'files': 0, 'bytes': 0})
    scanned_bytes = scanned_files = 0
    for relative in names:
        path = PROJECT / relative
        if path.is_symlink():
            skipped.append({'path': relative, 'reason': 'symlink'})
            continue
        before = path.stat()
        parts = Path(relative).parts
        first = parts[0]
        for group in {first, '/'.join(parts[:2]) if first == 'Assets' and len(parts) > 1 else first}:
            groups[group]['files'] += 1
            groups[group]['bytes'] += before.st_size
        selected = first in SOURCE_ROOTS or relative == 'SolarNet.Unity2020.props'
        if not selected:
            continue
        source.append({'path': relative, 'bytes': before.st_size})
        if before.st_size > 50 * 1024**2:
            large.append({'path': relative, 'bytes': before.st_size, 'over_100_MiB': before.st_size > 100 * 1024**2})
        if path.suffix.lower() == '.unity':
            scene_paths.append(relative)
        if relative.startswith('Assets/Scripts/') and path.suffix.lower() == '.cs':
            g = '/'.join(parts[:3]) if len(parts) > 3 else 'Assets/Scripts/(root)'
            script_groups[g]['files'] += 1
            script_groups[g]['bytes'] += before.st_size
        if re.search(r'(?i)(?:^|/)(?:\.env(?:\.[^/]*)?|credentials?[^/]*|id_rsa|id_ed25519|.*\.(?:p12|pfx|pem|key|keystore|jks))$', relative):
            sensitive_names.append({'path': relative, 'bytes': before.st_size})
        if path.suffix.lower() not in TEXT_EXTS:
            continue
        with path.open('rb') as f:
            first_chunk = f.read(1024 * 1024)
            if b'\x00' in first_chunk[:4096]:
                skipped.append({'path': relative, 'reason': 'binary_or_UTF16_text_no_pattern_scan'})
                continue
            chunk = first_chunk
            consumed = 0
            carry = b''
            hits = set()
            while chunk:
                data = carry + chunk
                lower_data = data.lower()
                data_start = consumed - len(carry)
                for rule, regex in PATTERNS.items():
                    if not any(trigger in lower_data for trigger in TRIGGERS[rule]):
                        continue
                    for match in regex.finditer(data):
                        offset = data_start + match.start()
                        key = (rule, offset)
                        if key in hits:
                            continue
                        if rule == 'possible_literal_secret_assignment':
                            literal = match.group(1).strip()
                            # These fixed examples/placeholders are not usable secrets.
                            if literal.lower() in {b'password', b'xxxxxxxx', b'your_api_key', b'your-api-key', b'changeme', b'********'} or literal.startswith((b'http://', b'https://', b'{', b'{{', b'$(', b'REPLACE_', b'YOUR_')):
                                continue
                        hits.add(key)
                        findings.append({'path': relative, 'rule': rule, 'byte_offset': offset, 'classification': 'candidate_requires_context_review_no_value_saved'})
                        by_rule[rule] += 1
                consumed += len(chunk)
                carry = data[-8192:]
                chunk = f.read(1024 * 1024)
            scanned_bytes += consumed
            scanned_files += 1
        after = path.stat()
        if (before.st_size, before.st_mtime_ns) != (after.st_size, after.st_mtime_ns):
            source_changes.append(relative)
    stamp = dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')
    out = OUT_BASE / ('Inventory-' + stamp + '-' + uuid.uuid4().hex[:8])
    out.mkdir(parents=True)
    (out / '.gitignore').write_text('*\n!.gitignore\n', encoding='utf-8')
    dump(out / 'source-file-inventory.json', {'scope': sorted(SOURCE_ROOTS) + ['SolarNet.Unity2020.props'], 'files': source})
    dump(out / 'secret-scan-redacted.json', {'findings': findings, 'sensitive_filenames': sensitive_names, 'skipped': skipped, 'no_secret_values_saved': True})
    dump(out / 'large-source-files.json', sorted(large, key=lambda r: (-r['bytes'], r['path'])))
    dump(out / 'scene-paths.json', scene_paths)
    lfs = subprocess.run(['git', 'lfs', 'version'], capture_output=True, text=True, check=True).stdout.strip()
    summary = {
        'schema': 'read-only-Unity-source-publication-inventory/v1', 'finished_utc': dt.datetime.now(dt.timezone.utc).isoformat(),
        'project': str(PROJECT), 'source_scope': sorted(SOURCE_ROOTS) + ['SolarNet.Unity2020.props'],
        'project_file_count': len(names), 'groups': dict(sorted(groups.items())),
        'selected_file_count': len(source), 'selected_bytes': sum(x['bytes'] for x in source),
        'selected_over_50_MiB_count': len(large), 'selected_over_100_MiB_count': sum(r['over_100_MiB'] for r in large),
        'scene_count': len(scene_paths), 'script_assemblies': dict(sorted(script_groups.items())),
        'secret_scan': {'text_files': scanned_files, 'text_bytes': scanned_bytes, 'finding_count': len(findings), 'finding_files': len({r['path'] for r in findings}), 'by_rule': dict(by_rule), 'sensitive_filename_count': len(sensitive_names), 'skipped_count': len(skipped), 'limitations': 'Heuristic redacted text-pattern scan; candidates are not confirmed credentials; native/binary payloads and UTF16 are not scanned. No proof of secret absence.'},
        'files_changed_during_scan': source_changes, 'git_lfs': lfs,
        'recommendation': {'include': ['Assets/** including every .meta', 'Packages/manifest.json', 'Packages/packages-lock.json', 'ProjectSettings/**', 'CompilerSupport/** required metadata/reference inputs', 'SolarNet.Unity2020.props after relative Editor-root portability review'], 'exclude': ['Library/**', 'Temp/**', 'obj/**', 'Logs/**', 'UserSettings/**', '.vs/**', '.idea/**', '*.csproj and *.sln generated IDE files', 'all workspace sibling Backend/Rebuild/Recovery/Tools histories and private captures'], 'requires_review_before_copy': ['secret-scan-redacted.json candidates and sensitive filenames', 'absolute path in Assets/Editor/OriginalMetadataRestoration/csc.rsp', 'large-file LFS selection and storage budget', 'native/plugin/reference inputs retain current required types; do not blanket delete DLLs']},
        'project_modified': False, 'project_copied': False, 'repository_created': False, 'network_or_remote_mutation': False,
    }
    dump(out / 'report.json', summary)
    print(json.dumps({'report': str(out / 'report.json'), 'sha256': digest(out / 'report.json'), 'selected_files': len(source), 'selected_bytes': summary['selected_bytes'], 'over50MiB': len(large), 'over100MiB': summary['selected_over_100_MiB_count'], 'secret_candidates': len(findings), 'candidate_files': summary['secret_scan']['finding_files'], 'scenes': len(scene_paths), 'git_lfs': lfs, 'changed_during_scan': len(source_changes)}))

if __name__ == '__main__':
    main()
