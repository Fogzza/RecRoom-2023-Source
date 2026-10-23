"""Pin the new acquisition-only stage and exact prior tested-output identity."""
import argparse
import json
from pathlib import Path
import prepare_marshalling_integration as p

OLD = p.ROOT / 'Validation/CurrentCoreMarshalRoundtrip-20261022T162157Z-ad86540f/offline-gates-final-Mono-pending-actual-Unity.json'
OLD_SHA = '51534c2c03e3cf857a95c5ccdaa51929ca0d55a04816228fa0d9d4656017902b'
FOLDER = p.ROOT / 'Validation/CurrentCoreMarshalRoundtrip-20261022T174617Z-bf0c36e7'
FIXTURES = p.ROOT / 'Validation/GeneralManifestStreamingFixtures-20261022T174453Z-52e4d254/report.json'
RESOURCES = p.ROOT / 'Validation/GeneralManifestAllResources-World-20261022T175016Z-848ca6b5/report.json'


def value(doc, selector):
    for key in selector:
        doc = doc[key]
    return doc


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--actual-comparison', type=Path)
    args = parser.parse_args()
    p.pinned(OLD, OLD_SHA)
    gates = p.read(OLD)
    for i, name in enumerate(('integration-readiness.json', 'report.json', 'direct-cli-overlay-proof.json')):
        gates[i].update(p.pinned(FOLDER / name))
    def add(file, checks):
        document = p.read(file)
        for selector, expected in checks:
            p.need(value(document, selector) == expected, 'Explicit gate failed: ' + str(file) + ':' + str(selector))
        gates.append({**p.pinned(file), 'checks': [{'selector': selector, 'equals': expected} for selector, expected in checks]})
    add(FIXTURES, [(['status'], 'passed'), (['production_reader_unchanged'], True), (['exact_all4_embedded_resources'], True),
                   (['candidate_sha256'], 'd7d8da3cb6c0e75eed8221f3c0b8b5ff9bc1fc2057093f4a10cb77182711e07b')])
    add(FOLDER / 'unchanged-output-equality.json', [(['status'], 'passed'), (['matching_full_scope_IL_PDB_roundtrip_passed'], True),
              (['prior_full_Mono_walk_still_applies_by_exact_PE_identity'], True), (['new_gameplay_bodies_or_metadata_changes'], 0)])
    # Validate all inherited acceptance selectors against their pinned reports,
    # including the newly replaced readiness/roundtrip/direct-CLI reports.
    for gate in gates:
        doc = p.read(gate['path'])
        p.pinned(Path(gate['path']), gate['sha256'])
        for check in gate['checks']:
            p.need(value(doc, check['selector']) == check['equals'], 'Inherited acceptance selector failed')
    if args.actual_comparison:
        actual = p.read(args.actual_comparison)
        p.need(actual['inputs'][0]['sha256'] == '885953e1ae5b44cce72d742ad5817d33bb64594581b97565518d0799d4da95e5', 'Wrong expected actual-comparison core')
        add(args.actual_comparison, [(['status'], 'passed'), (['game_code_loaded_or_executed'], False), (['project_modified'], False)])
    target = FOLDER / ('offline-gates-final-with-actual-scoped-comparison.json' if args.actual_comparison else 'offline-gates-final-direct-stream-pending-actual-Unity.json')
    p.need(not target.exists(), 'Never overwrite gate history')
    target.write_text(json.dumps(gates, indent=2) + '\n')
    print(json.dumps({'gates': str(target), 'sha256': p.sha(target), 'reports': len(gates), 'actual_comparison_included': bool(args.actual_comparison)}))


if __name__ == '__main__':
    main()
