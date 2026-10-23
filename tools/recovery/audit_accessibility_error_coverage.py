"""Read-only exact accessibility-error coverage and native/emitted flag audit.

Uses bounded JSON rows, SQLite and mmap ECMA/native metadata. Never loads an
assembly or edits the recovered Unity project. Source declaration checks are
lexical corroboration; exact emitted MethodDef/FieldDef flags are independent.
"""
from pathlib import Path
import datetime as dt
import hashlib
import importlib.util
import json
import mmap
import re
import sqlite3
import sys
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
sys.path.insert(0, str(HERE.parent))
from metadata_projection_subset import array_rows, sha
sys.path.insert(0, str(HERE.parent / 'ConstructorEvidence'))
from native_metadata import NativeMetadata
spec = importlib.util.spec_from_file_location('access_cli', HERE / 'audit_cli_marshal_contracts.py')
cli_module = importlib.util.module_from_spec(spec)
spec.loader.exec_module(cli_module)

PASTE = Path('C:/Users/andre/.codex/attachments/1be4af08-a994-4d94-816a-f5e47c987405/Pasted text.txt')
EVIDENCE = ROOT / 'CompilerRepairs/SmallerFamilies/accessibility-original-member-metadata.json'
PLAN = ROOT / 'Validation/BodySourceStreamRebase-20261022T150601Z-f74c827a/metadata-restoration.json'
CACHE = ROOT / 'CompilerRepairs/CurrentCoreIntegration-20261022T132957Z-214498f6/bounded-manifest-cache.sqlite'
COMPILED = ROOT / 'Validation/BodyFullCompile-20261022T150337Z-5aa61f72/Assembly-CSharp.dll'
ROUNDTRIP = ROOT / 'Validation/CurrentCoreMarshalRoundtrip-20261022T162157Z-ad86540f'
RESTORED = ROUNDTRIP / 'ActualCurrentCoreOutput/Assembly-CSharp.dll'
PE = ROOT / 'CodeSource/GameAssembly.dll'
META = ROOT / 'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat'


def need(value, message):
    if not value:
        raise ValueError(message)


def record(path):
    return {'path': str(path.resolve()), 'sha256': sha(path)}


def declarations(path, member, kind):
    text = path.read_text(encoding='utf-8-sig')
    pattern = (r'^\s*(?:private|internal|public|protected)\b[^\n]*\b'
               + re.escape(member) + (r'(?:<[^\n;{}()]+>)?\s*\(' if kind == 'Method' else r'\b'))
    rows = list(re.finditer(pattern, text, flags=re.M))
    need(len(rows) == 1, 'Exact unique source declaration absent: ' + str(path) + ':' + member)
    match = rows[0]
    tail = text[match.start():]
    content_start = match.start() + len(tail) - len(tail.lstrip())
    line = text[content_start:].split('\n', 1)[0].strip()
    return {'line': text.count('\n', 0, content_start) + 1,
            'access': re.match(r'(private|internal|public|protected)\b', line).group(1),
            'declaration_line_sha256': hashlib.sha256(line.encode()).hexdigest()}


def cli_rows(path):
    """Only names/flags/RVA locators: no target execution or signature inference."""
    with path.open('rb') as stream, mmap.mmap(stream.fileno(), 0, access=mmap.ACCESS_READ) as data:
        c = cli_module.Cli(data)
        types = []
        for rid in range(1, c.rows[2] + 1):
            at = c.row(2, rid)
            types.append({'rid': rid, 'name': c.string(c.value(at + 4, c.strw)),
                          'namespace': c.string(c.value(at + 4 + c.strw, c.strw)), 'flags': c.u32(at),
                          'field_start': c.value(at + 4 + 2*c.strw + c.coded(2, [2, 1, 27]), c.index(4)),
                          'method_start': c.value(at + 4 + 2*c.strw + c.coded(2, [2, 1, 27]) + c.index(4), c.index(6))})
        parents = {}
        for rid in range(1, c.rows[41] + 1):
            at = c.row(41, rid)
            parents[c.value(at, c.index(2))] = c.value(at + c.index(2), c.index(2))

        def fullname(rid):
            t = types[rid - 1]
            return fullname(parents[rid]) + '/' + t['name'] if rid in parents else (t['namespace'] + '.' if t['namespace'] else '') + t['name']

        answer = {}
        for ix, t in enumerate(types):
            owner = fullname(t['rid'])
            answer[owner] = {'flags': t['flags'], 'token': hex(0x02000000 | t['rid']), 'methods': {}, 'fields': {}}
            for rid in range(t['method_start'], types[ix+1]['method_start'] if ix+1 < len(types) else c.rows[6] + 1):
                at = c.row(6, rid)
                name = c.string(c.value(at + 8, c.strw))
                answer[owner]['methods'].setdefault(name, []).append({'flags': c.u16(at+6), 'impl_flags': c.u16(at+4),
                    'token': hex(0x06000000 | rid), 'signature_blob_hex': c.blob(c.value(at+8+c.strw, c.blobw)).hex()})
            for rid in range(t['field_start'], types[ix+1]['field_start'] if ix+1 < len(types) else c.rows[4] + 1):
                at = c.row(4, rid)
                name = c.string(c.value(at+2, c.strw))
                answer[owner]['fields'].setdefault(name, []).append({'flags': c.u16(at), 'token': hex(0x04000000 | rid),
                    'signature_blob_hex': c.blob(c.value(at+2+c.strw, c.blobw)).hex()})
        rvas = {}
        for rid in range(1, c.rows[29] + 1):
            at = c.row(29, rid)
            rvas[hex(0x04000000 | c.value(at+4, c.index(4)))] = c.u32(at)
        for t in answer.values():
            for fs in t['fields'].values():
                for f in fs:
                    if f['token'] in rvas:
                        # The sole audited RVA field's native-proven extent is151.
                        at = c.raw(rvas[f['token']], 151)
                        f['initial_151_bytes_sha256'] = hashlib.sha256(data[at:at+151]).hexdigest()
        return answer


def unique_member(inventory, owner, group, name):
    need(owner in inventory, 'Exact emitted owner absent: ' + owner)
    rows = inventory[owner][group].get(name, [])
    need(len(rows) == 1, 'Exact emitted member not unique: ' + owner + '::' + name)
    return rows[0]


def main():
    old = json.loads(EVIDENCE.read_text())
    errors = [x for x in PASTE.read_text(encoding='utf-8-sig').splitlines() if x.startswith('Inconsistent accessibility:')]
    need(len(old) == len(errors) == 27, 'Exact accessibility inventory changed')
    expected_paths = {row['Source'] for row in old}
    sources = {row['project_relative_path']: row for row in array_rows(PLAN, 'source_replacements') if row['project_relative_path'] in expected_paths}
    need(set(sources) == expected_paths, 'Missing source projection')
    db = sqlite3.connect('file:' + CACHE.as_posix() + '?mode=ro', uri=True)
    db.execute('pragma cache_size=-1024')
    access = [json.loads(v) for v, in db.execute("select value from rows where kind='access'")]
    need(len(access) == 26, 'Exact production access projection inventory changed')
    compiled, restored = cli_rows(COMPILED), cli_rows(RESTORED)
    rows, unmatched, matched_errors = [], [], set()
    with PE.open('rb') as pf, META.open('rb') as mf, mmap.mmap(pf.fileno(), 0, access=mmap.ACCESS_READ) as pe, mmap.mmap(mf.fileno(), 0, access=mmap.ACCESS_READ) as meta:
        n = NativeMetadata(pe, meta)
        types = {n.full_name(i): i for i in range(n.count('typeDefinitions', 88))}
        for row in old:
            kind, member, original = row['Restore']['Kind'], row['CompileMember'], row['Restore']
            matches = [i for i, error in enumerate(errors) if re.search(r'\.' + re.escape(member) + (r'(?:<[^\n]+?>)?\(' if kind == 'Method' else r"'$"), error)]
            need(len(matches) == 1 and matches[0] not in matched_errors, 'Exact paste member join is missing/ambiguous: ' + member)
            matched_errors.add(matches[0])
            source = sources[row['Source']]
            current_path, candidate_path = WS/'RR23'/row['Source'], Path(source['candidate_path'])
            need(sha(candidate_path) == source['candidate_sha256'], 'Projected source changed')
            current = declarations(current_path, member, kind)
            projected = declarations(candidate_path, member, kind)
            need(current['access'] == 'internal' and projected['access'] == 'private', 'Source access projection differs')
            owner = original['Type']
            native_ti = types.get(owner)
            need(native_ti is not None, 'Exact original native owner absent: ' + owner)
            type_at = n.row('typeDefinitions', native_ti, 88)
            native_type = n.type_info(native_ti)
            inv_row = db.execute("select value from rows where kind='inventory' and owner=?", (owner,)).fetchone()
            need(inv_row is not None, 'Current emitted type identity map absent')
            compiled_owner = json.loads(inv_row[0])['compiled_full_name']
            if kind == 'Method':
                plans = [p for p in access if p['original_type'] == owner and p['original']['name'] == member]
                need(len(plans) == 1 and plans[0]['compiled_access'] == 'private' and plans[0]['restore_access_only'], 'Exact production access plan absent')
                start, count = n.i32(meta, type_at+36), n.u16(meta, type_at+64)
                native_methods = [n.method_info(i) for i in range(start, start+count) if n.string(n.i32(meta, n.row('methods', i, 32))) == member]
                need(len(native_methods) == 1, 'Original native method name is ambiguous')
                native = native_methods[0]
                c = unique_member(compiled, compiled_owner, 'methods', member)
                r = unique_member(restored, owner, 'methods', member)
                need(native['flags'] == plans[0]['original_attributes'] == original['AttributeBits'] == r['flags'] == 147 and c['flags'] == 145, 'Native/compiler/restored method flags differ')
                need(native['impl_flags'] == c['impl_flags'] == r['impl_flags'] == 0, 'Method implementation flags differ')
                original_parameter_types = [p['type'] for p in native['parameters']]
                nested = []
                for name in types:
                    if name.startswith(owner+'/') and any(name.split('/')[-1] in t for t in original_parameter_types):
                        info = n.type_info(types[name])
                        need(info['flags'] & 7 == 3, 'Referenced nested helper is not originally NestedPrivate')
                        nested.append(info)
                need(nested, 'No exact private nested helper parameter found')
                item = {'kind': kind, 'member': member, 'source_path': row['Source'], 'native': native,
                        'native_private_parameter_types': nested, 'compiled': c, 'restored': r,
                        'production_access_plan': plans[0]}
            else:
                start, count = n.i32(meta, type_at+32), n.u16(meta, type_at+68)
                native_fields = []
                for i in range(start, start+count):
                    at = n.row('fields', i, 12)
                    if n.string(n.i32(meta, at)) == original['OriginalName']:
                        nt = n.native_type(n.i32(meta, at+4))
                        native_fields.append({'name': original['OriginalName'], 'type': n.typename(nt), 'flags': nt['attributes'], 'token': hex(n.u32(meta, at+8))})
                need(len(native_fields) == 1, 'Original field identity absent/ambiguous')
                native = native_fields[0]
                c = unique_member(compiled, compiled_owner, 'fields', member)
                r = unique_member(restored, owner, 'fields', original['OriginalName'])
                need(native['flags'] == r['flags'] == original['AttributeBits'] == 275 and c['flags'] == 17, 'Native/compiler/restored field flags differ')
                value_hash = hashlib.sha256(bytes.fromhex(original['InitialValueHex'])).hexdigest()
                need(r['initial_151_bytes_sha256'] == value_hash and original['InitialValueBytes'] == 151, 'Original RVA bytes were not restored exactly')
                item = {'kind': kind, 'member': member, 'source_path': row['Source'], 'native': native,
                        'compiled': c, 'restored': r, 'initial_value_bytes': 151, 'initial_value_sha256': value_hash,
                        'source_comment_is_not_executable_field_initialization': True}
            item.update({'paste_line': matches[0]+1, 'current_source': record(current_path), 'current_declaration': current,
                         'candidate_source': record(candidate_path), 'candidate_declaration': projected,
                         'source_plan_original_hash_still_current': sha(current_path) == source['original_sha256']})
            rows.append(item)
    unmatched = [e for i, e in enumerate(errors) if i not in matched_errors]
    need(not unmatched and len(rows) == 27, 'Unmatched accessibility gap')
    report = {'schema': 'current-compiler-accessibility-error-native-projection-audit/v1', 'status': 'passed',
              'project_modified': False, 'game_or_sdk_code_executed': False, 'managed_process_launched': False,
              'counts': {'paste_errors': len(errors), 'unique_matched_errors': len(matched_errors), 'unmatched': len(unmatched),
                         'private_method_compile_projections': 26, 'private_field_compile_projections': 1,
                         'original_native_member_flags_restored': 27, 'source_files': len(sources), 'RVA_bytes_restored': 151},
              'all_current_source_hashes_still_match_source_plan': all(x['source_plan_original_hash_still_current'] for x in rows),
              'inputs': [record(p) for p in (PASTE, EVIDENCE, PLAN, COMPILED, RESTORED, ROUNDTRIP/'report.json', PE, META)],
              'rows': rows, 'unmatched_errors': unmatched,
              'conclusion': 'All27 pasted accessibility errors are covered by the existing staged source projections. The compiler sees private helpers/field while original native internal access and the exact RVA data are restored in the already-tested isolated output. No private helper type is promoted. This audits staged coverage, not deployment or a new Unity compile.'}
    out = ROOT/'Validation'/('AccessibilityCoverage-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8])
    out.mkdir()
    (out/'report.json').write_text(json.dumps(report, indent=2)+'\n')
    print(json.dumps({'report': str(out/'report.json'), 'status': report['status'], 'counts': report['counts'], 'source_hashes_current': report['all_current_source_hashes_still_match_source_plan']}))


if __name__ == '__main__':
    main()
