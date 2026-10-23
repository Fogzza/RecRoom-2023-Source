"""Bounded CLR table inventory joined to streaming source projection rows."""
import argparse
from datetime import datetime, timezone
import importlib.util
import json
from pathlib import Path
import sys
import uuid

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18'
sys.path.insert(0, str(HERE.parent))
from metadata_projection_subset import array_rows, sha
spec = importlib.util.spec_from_file_location('core_inventory_guard', HERE.parent / 'MovementRequestEvidence/run_guarded.py')
guard = importlib.util.module_from_spec(spec); spec.loader.exec_module(guard)


def main():
    p = argparse.ArgumentParser(); p.add_argument('--manifest', type=Path, required=True); p.add_argument('--core', type=Path, required=True)
    args = p.parse_args()
    output = ROOT / 'Validation' / ('ActualCoreInventory-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]); output.mkdir()
    report = {'schema': 'actual-core-type-inventory-against-source/v1', 'phases': [], 'project_changed': False, 'game_code_executed': False}
    try:
        source = HERE / 'ManagedTypeInventory.cs'; host = output / 'ManagedTypeInventory.dll'
        response = output / 'compile.rsp'; response.write_text('\n'.join(['/nologo', '/target:exe', '/nullable:enable', '/langversion:latest', f'/out:"{host}"'] + [f'/reference:"{p}"' for p in sorted(guard.REF.glob('*.dll'))] + [f'"{source}"']) + '\n')
        guard.phase([guard.DOTNET, guard.SDK / 'Roslyn/bincore/csc.dll', '/noconfig', '@' + str(response)], output, 'compile-CLR-data-reader', report, maximum=60, cap=.15)
        host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions': {'tfm': 'net10.0', 'framework': {'name': 'Microsoft.NETCore.App', 'version': '10.0.11'}}}))
        rows = output / 'actual-typedefs.jsonl'
        guard.phase([guard.DOTNET, host, args.core.resolve(), rows], output, 'read-actual-CLR-tables', report, maximum=60, cap=.15)
        actual = {}
        with rows.open() as stream:
            for line in stream:
                row = json.loads(line)
                if row['full_name'] in actual: raise ValueError('Duplicate actual TypeDef identity')
                actual[row['full_name']] = row
        expected = {}
        for row in array_rows(args.manifest, 'source_type_inventory'):
            if row['compiled_full_name'] in expected: raise ValueError('Duplicate expected TypeDef identity')
            expected[row['compiled_full_name']] = row
        expected['<Module>'] = {'original_full_name': '<Module>', 'compiled_full_name': '<Module>', 'expected_original_method_count': 0, 'expected_original_field_count': 0}
        missing = [expected[n] for n in sorted(expected.keys() - actual.keys())]
        extra = [actual[n] for n in sorted(actual.keys() - expected.keys())]
        mismatches = [{'expected': row, 'actual': actual[name]} for name, row in expected.items() if name in actual and
                      (row['expected_original_method_count'] != actual[name]['methods'] or row['expected_original_field_count'] != actual[name]['fields'])]
        report.update(status='inventoried', actual_type_count=len(actual), expected_current_source_type_count=len(expected), missing_types=missing,
                      extra_types=extra, field_or_method_count_mismatches=mismatches, exact_expected_inventory=not missing and not extra,
                      expected_counts_match=not mismatches, inputs=[{'path': str(p.resolve()), 'sha256': sha(p)} for p in (args.manifest, args.core)],
                      raw_type_inventory={'path': str(rows), 'sha256': sha(rows)}, compiler_reader={'path': str(source), 'sha256': sha(source)})
    except Exception as e:
        report.update(status='failed', error=str(e))
    result = output / 'report.json'; result.write_text(json.dumps(report, indent=2) + '\n')
    print(json.dumps({'status': report['status'], 'report': str(result), 'missing': len(report.get('missing_types', [])), 'extra': len(report.get('extra_types', [])), 'member_count_mismatches': len(report.get('field_or_method_count_mismatches', [])), 'error': report.get('error')}))
    return 0 if report['status'] == 'inventoried' else 1


if __name__ == '__main__':
    raise SystemExit(main())
