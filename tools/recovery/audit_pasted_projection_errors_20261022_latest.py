"""Read-only bounded join of user diagnostics to the pinned whole source plan."""
import collections
import hashlib
import json
import re
import sys
import uuid
import xml.etree.ElementTree as ET
from datetime import datetime, timezone
from pathlib import Path
import prepare_marshalling_integration as p
sys.path.insert(0, str(Path(__file__).resolve().parent.parent))
from metadata_projection_subset import array_rows

ATTACHMENT = Path(r'C:\Users\andre\.codex\attachments\fc405d87-08f4-4419-a7a4-e37bf8bdffef\Pasted text.txt')
PLAN = p.ROOT / 'Validation/BodySourceStreamRebase-20261022T150601Z-f74c827a/metadata-restoration.json'
COMPILE = p.ROOT / 'Validation/BodyFullCompile-20261022T150337Z-5aa61f72/report.json'
PLAN_SHA = '9914cdfd2af4f5319f94315ae13a948b85d5e1260500f4408bc8ceeaad02e51f'


def normalize(value):
    value = value.replace('global::', '').replace('/', '.').replace('+', '.')
    out = []
    depth = 0
    for char in value:
        if char == '<':
            depth += 1
        elif char == '>':
            depth -= 1
        elif depth == 0:
            out.append(char)
    return re.sub(r'`\d+', '', ''.join(out)).strip()


def affected_symbol(line):
    quoted = re.findall(r"'([^']*)'", line)
    if not quoted:
        return None
    if 'for type ' in line or line.startswith('Type parameter '):
        return quoted[-1]
    if line.startswith('Inconsistent accessibility:'):
        return quoted[-1]
    return quoted[0]


def main():
    p.need(p.sha(PLAN) == PLAN_SHA, 'Final source plan changed')
    p.need(ATTACHMENT.stat().st_size == 111353, 'Exact attachment required')
    compile_doc = p.read(COMPILE)
    p.need(compile_doc['status'] == 'passed' and compile_doc['exit_code'] == 0 and compile_doc['compiler_errors'] == 0 and compile_doc['all_captured_core_sources_compiled'], 'Existing whole source compile proof required')
    source_rows = list(array_rows(PLAN, 'source_replacements'))
    p.need(len(source_rows) == 2291, 'Exact source replacement set required')
    replacements = {r['project_relative_path'].casefold(): r for r in source_rows}
    compiled_rows = {str(Path(r['source']).relative_to(p.WORKSPACE / 'RR23')).replace('\\', '/').casefold(): r for r in compile_doc['replacements'] if Path(r['source']).suffix == '.cs'}
    p.need(len(compiled_rows) == 2291, 'Exact matching compile source set required')
    for key, row in replacements.items():
        witness = compiled_rows[key]
        p.need(witness['candidate'] == row['candidate_path'] and witness['candidate_sha256'] == row['candidate_sha256'], 'A planned source differs from the actually compiled input')
    inventory = {}
    for row in array_rows(PLAN, 'source_type_inventory'):
        for name in (row['original_full_name'], row['compiled_full_name']):
            key = normalize(name)
            inventory.setdefault(key, set()).add(row['source_path'])
    firstpass_sources = []
    ns = {'m': 'http://schemas.microsoft.com/developer/msbuild/2003'}
    firstpass_project = p.WORKSPACE / 'RR23/Assembly-CSharp-firstpass.csproj'
    for node in ET.parse(firstpass_project).findall('.//m:Compile', ns):
        source = p.WORKSPACE / 'RR23' / node.get('Include')
        firstpass_sources.append(source)
        relative = source.relative_to(p.WORKSPACE / 'RR23').as_posix()
        for name in re.findall(r'\b(?:class|struct|interface|enum)\s+([A-Za-z_][A-Za-z_0-9]*)', source.read_text(encoding='utf-8-sig')):
            inventory.setdefault(name, set()).add(relative)
    # The pasted Error List omits namespaces. Admit a displayed suffix only
    # when it has one source path across the entire original/compiled inventory.
    suffix_inventory = {}
    for name, paths in inventory.items():
        segments = name.split('.')
        for offset in range(len(segments)):
            suffix_inventory.setdefault('.'.join(segments[offset:]), set()).update(paths)
    def owner_paths(symbol):
        if symbol is None:
            return None, []
        value = normalize(symbol).split('(', 1)[0]
        while value:
            if value in inventory:
                return value, sorted(inventory[value])
            if value in suffix_inventory:
                return value, sorted(suffix_inventory[value])
            if '.' not in value:
                break
            value = value.rsplit('.', 1)[0]
        return None, []
    out = p.ROOT / 'Validation' / ('PastedErrorProjectionJoin-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    lines = [s.strip() for s in ATTACHMENT.read_text(encoding='utf-8-sig').splitlines() if s.strip()]
    categories = collections.Counter()
    statuses = collections.Counter()
    owners = collections.Counter()
    selected_paths = set()
    unmatched = []
    warning_count = 0
    rows_path = out / 'diagnostic-source-joins.jsonl'
    source_cache = {}
    with rows_path.open('x', encoding='utf-8') as stream:
        for number, line in enumerate(lines, 1):
            category = re.sub(r"'[^']*'", "'…'", line)
            categories[category] += 1
            warning = any(s in line for s in ('is never used', 'hides inherited member', 'new keyword is not required', 'same name as the type parameter from outer type'))
            warning_count += warning
            owner, paths = owner_paths(affected_symbol(line))
            keys = [s.casefold() for s in paths]
            if len(paths) > 1:
                status = 'ambiguous_source_owner'
            elif not paths:
                status = 'unmatched_source_owner'
            elif keys[0] in replacements:
                status = 'directly_in_existing_zero_error_projection'
                selected_paths.add(paths[0])
            else:
                status = 'owner_source_not_directly_replaced'
            dependencies = []
            if status == 'owner_source_not_directly_replaced' and not warning:
                quoted = re.findall(r"'([^']*)'", line)
                candidates = quoted[1:]
                source = p.WORKSPACE / 'RR23' / paths[0]
                if paths[0] not in source_cache:
                    source_cache[paths[0]] = source.read_text(encoding='utf-8-sig')
                local_name = owner.rsplit('.', 1)[-1]
                declaration = re.search(r'\b(?:class|struct)\s+' + re.escape(local_name) + r'(?:<[^\n;{}]*>)?\s*:\s*([^\n{]+)', source_cache[paths[0]])
                if declaration:
                    # Do not split generic argument commas. The base type is
                    # enough here; direct interface errors have quoted owners.
                    candidates.append(declaration[1])
                seen_dependencies = set()
                for symbol in candidates:
                    dep_owner, dep_paths = owner_paths(symbol)
                    chain = []
                    while len(dep_paths) == 1 and dep_paths[0].casefold() not in replacements and dep_paths[0] not in seen_dependencies and len(chain) < 8:
                        seen_dependencies.add(dep_paths[0])
                        dep_source = p.WORKSPACE / 'RR23' / dep_paths[0]
                        if dep_paths[0] not in source_cache:
                            source_cache[dep_paths[0]] = dep_source.read_text(encoding='utf-8-sig')
                        dep_local = dep_owner.rsplit('.', 1)[-1]
                        parent = re.search(r'\b(?:class|struct)\s+' + re.escape(dep_local) + r'(?:<[^\n;{}]*>)?\s*:\s*([^\n{]+)', source_cache[dep_paths[0]])
                        if not parent:
                            break
                        chain.append({'source': p.pinned(dep_source), 'class': dep_owner, 'base_declaration': parent[1]})
                        dep_owner, dep_paths = owner_paths(parent[1])
                    if len(dep_paths) == 1 and dep_paths[0].casefold() in replacements:
                        dependencies.append({'display_symbol': symbol, 'source_owner': dep_owner, 'source_path': dep_paths[0], 'unchanged_base_chain': chain, 'replacement': replacements[dep_paths[0].casefold()]})
                        selected_paths.add(dep_paths[0])
                if dependencies:
                    status = 'unchanged_owner_with_existing_projected_contract_or_base'
            if warning and status in ('owner_source_not_directly_replaced', 'unmatched_source_owner'):
                status = 'warning_outside_replacement_set_not_a_compile_error'
            statuses[status] += 1
            if owner:
                owners[owner] += 1
            row = {'diagnostic_number': number, 'diagnostic_sha256': hashlib.sha256(line.encode()).hexdigest(), 'message': line, 'warning': warning,
                   'affected_symbol': affected_symbol(line), 'matched_source_owner': owner, 'source_paths': paths, 'projection_status': status}
            if dependencies:
                row['projected_contract_dependencies'] = dependencies
            if paths and keys[0] in replacements:
                row['replacement'] = replacements[keys[0]]
            if status not in ('directly_in_existing_zero_error_projection', 'unchanged_owner_with_existing_projected_contract_or_base', 'warning_outside_replacement_set_not_a_compile_error'):
                unmatched.append(row)
            stream.write(json.dumps(row) + '\n')
    file_proofs = []
    for relative in sorted(selected_paths):
        row = replacements[relative.casefold()]
        source = p.WORKSPACE / 'RR23' / relative
        candidate = Path(row['candidate_path'])
        actual_source = p.sha(source)
        actual_candidate = p.sha(candidate)
        p.need(actual_candidate == row['candidate_sha256'], 'Affected prepared source candidate changed')
        file_proofs.append({'source': p.pinned(source), 'candidate': p.pinned(candidate), 'matches_plan_original': actual_source == row['original_sha256']})
    representative = {}
    for row in array_rows(PLAN, 'types'):
        if row['original_full_name'] == 'AFFPGEJLDGB':
            representative['AFF_interface_property'] = [r for r in row['properties'] if r['compiled_name'] == 'global::NNBAJLCGAOK.GDJKLPKICBG']
        if len(representative) == 1:
            break
    representative_path = out / 'representative-original-interface-property.json'
    representative_path.write_text(json.dumps(representative, indent=2) + '\n')
    outside_path = out / 'not-directly-projected.json'
    outside_path.write_text(json.dumps(unmatched, indent=2) + '\n')
    file_path = out / 'affected-source-file-pins.json'
    file_path.write_text(json.dumps(file_proofs, indent=2) + '\n')
    report = {'schema': 'user-pasted-error-existing-whole-projection-coverage/v1', 'status': 'read_only_join_complete',
              'inputs': [p.pinned(x) for x in (ATTACHMENT, PLAN, COMPILE)], 'nonempty_diagnostic_lines': len(lines), 'unique_diagnostics': len(set(lines)),
              'warning_lines_by_message_pattern': warning_count, 'diagnostic_categories': dict(categories), 'source_join_counts': dict(statuses),
              'distinct_directly_projected_source_files': len(selected_paths), 'top_affected_owners': owners.most_common(15),
              'all_existing_2291_source_candidates_equal_actually_zero_error_compiled_inputs': True,
              'display_name_join_policy': 'Exact original/compiled full owner first, then unique displayed suffix across the full source inventory; no ambiguous owner is accepted.',
              'all_affected_candidates_current_hashes_match': True,
              'affected_main_sources_still_original_plan_bytes': sum(r['matches_plan_original'] for r in file_proofs),
              'diagnostic_joins': p.pinned(rows_path), 'outside_direct_projection': p.pinned(outside_path), 'source_file_pins': p.pinned(file_path),
              'representative_original_interface_property': p.pinned(representative_path),
              'compile_executed_for_this_audit': False, 'project_or_runtime_modified': False,
              'not_a_per_diagnostic_new_compile': True,
              'interpretation': 'Direct coverage means the affected owner source already has a hash-pinned candidate in the whole zero-error compiler input. It is not a claim of newly recovered gameplay bodies, current IDE zero errors, or Main deployment.'}
    target = out / 'report.json'
    target.write_text(json.dumps(report, indent=2) + '\n')
    print(json.dumps({'report': str(target), 'sha256': p.sha(target), 'counts': dict(statuses), 'warnings': warning_count, 'direct_source_files': len(selected_paths), 'top_owners': owners.most_common(5)}))


if __name__ == '__main__':
    main()
