"""Hash-pinned examples of existing original-contract declaration inverses."""
import json
from pathlib import Path
import prepare_marshalling_integration as p
from audit_pasted_projection_errors import PLAN, PLAN_SHA
from metadata_projection_subset import array_rows

out = p.ROOT / 'Validation/PastedErrorProjectionJoin-20261022T172250Z-93c5ab85'
coverage = out / 'report.json'
p.need(p.sha(PLAN) == PLAN_SHA, 'Exact source plan required')
rows = {r['project_relative_path']: r for r in array_rows(PLAN, 'source_replacements')}
examples = []
for relative, before_needle, after_needle in (
    ('Assets/Scripts/Assembly-CSharp/AFFPGEJLDGB.cs', 'bool OJAOIFAINAN', 'bool global::NNBAJLCGAOK.GDJKLPKICBG'),
    ('Assets/Scripts/Assembly-CSharp/ADCLBHGPPKE.cs', 'internal static bool JLDBAFBNOBF', 'private static bool JLDBAFBNOBF')):
    r = rows[relative]
    source = p.WORKSPACE / 'RR23' / relative
    candidate = Path(r['candidate_path'])
    p.pinned(source, r['original_sha256']); p.pinned(candidate, r['candidate_sha256'])
    hits = []
    for path, needle in ((source, before_needle), (candidate, after_needle)):
        lines = path.read_text(encoding='utf-8-sig').splitlines()
        positions = [i for i, line in enumerate(lines) if needle in line]
        p.need(len(positions) == 1, 'Unique source declaration witness required')
        i = positions[0]
        hits.append({'file': p.pinned(path), 'line': i + 1, 'declaration': lines[i].strip(), 'following_lines': lines[i + 1:i + 5]})
    examples.append({'source_path': relative, 'declaration_witnesses': hits})
access = [r for r in array_rows(PLAN, 'additional_method_access_projections') if r['original_type'] == 'ADCLBHGPPKE' and r['original']['name'] == 'JLDBAFBNOBF']
p.need(len(access) == 1 and access[0]['original_attributes'] == 147 and access[0]['compiled_access'] == 'private' and access[0]['restore_access_only'], 'Exact compiler-only access inverse required')
wanted = {('AFFPGEJLDGB', 'BNEFLOCAECJ'), ('AFFPGEJLDGB', 'EACNDLKDBEA'), ('NNBAJLCGAOK', 'OJAOIFAINAN'), ('NNBAJLCGAOK', 'HLFPPNFHLNC'), ('ADCLBHGPPKE', 'JLDBAFBNOBF')}
raw = p.ROOT / 'Validation/CoreMethodFlagsInventory-20261022T110755Z-0be64abb/raw-core-methods.jsonl'
native = []
with raw.open() as stream:
    for line in stream:
        r = json.loads(line)
        identity = (r['owner'].split('`', 1)[0], r['name'])
        if identity in wanted:
            native.append(r)
            if len(native) == len(wanted):
                break
p.need(len(native) == len(wanted) and all(r['original_token_from_initial_attribute'] and not r['error'] for r in native), 'Native original full method identities required')
report = {'schema': 'pasted-error-original-interface-and-access-inverse-representatives/v1', 'status': 'original_contract_binding_examples_verified',
          'inputs': [p.pinned(coverage), p.pinned(PLAN), p.pinned(raw)], 'examples': examples,
          'exact_original_interface_property_plan': p.read(out / 'representative-original-interface-property.json'),
          'exact_access_inverse_plan': access, 'independently_native_joined_original_methods': native,
          'explanation': 'The original AFF getter/setter have explicit MethodImpl declarations pointing at the interface getter/setter. The C# projection expresses that relationship with an explicit interface property and the ILPP restores the original member identities. The accessibility projection is private only for C# legality; original internal flags147 are restored after compilation. These transforms preserve existing bodies and do not turn stub bodies into recovered gameplay.',
          'main_or_runtime_modified': False, 'new_bodies_invented_or_missing_members_hidden': False}
target = out / 'representative-original-contract-evidence.json'
target.write_text(json.dumps(report, indent=2) + '\n')
print(json.dumps({'report': str(target), 'sha256': p.sha(target), 'native_method_rows': len(native)}))
