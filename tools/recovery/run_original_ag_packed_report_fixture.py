"""Fresh AG/Fallback fixture with actual reusable packed-Shader API capture.

Preparation only by default. Root alone may supply --run. Frozen v3 fixtures,
builders and plans remain untouched. No Main or production backend changes.
"""
from pathlib import Path
import argparse
import json
import run_original_ag_dependency_fixture_v3 as base

HERE = Path(__file__).resolve().parent
BASE_SHA = '5e3de0dab9e0cc96543608fd3ce420705609811b76f1c570689e55b1c1ee1d52'


def prepare(args):
    base.need(base.sha(Path(base.__file__)) == BASE_SHA, 'Frozen v3 prep/runner changed')
    path = base.prepare(args)
    plan = json.loads(path.read_bytes())
    project = Path(plan['project'])
    source = HERE / 'BuildOriginalAGDependencyFixture.cs'
    original = source.read_bytes()
    insertion1 = b'        public Witness[] dependency_witnesses;'
    insertion2 = b'            CheckDependency(config, "after-player-build");'
    base.need(original.count(insertion1) == original.count(insertion2) == 1, 'Exact original builder anchors required')
    prepared = original.replace(insertion1, insertion1 + b'\n        public ShaderPackedBuildReportCapture.Data packed_shader_build_report;')
    prepared = prepared.replace(insertion2, b'            result.packed_shader_build_report = ShaderPackedBuildReportCapture.Capture(built);\n' + insertion2)
    sibling = path.parent / 'BuildOriginalAGDependencyFixtureWithPackedAssets.cs'
    sibling.write_bytes(prepared)
    target = project / 'Assets/Editor/BuildOriginalAGDependencyFixture.cs'
    target.write_bytes(prepared)
    helper = HERE / 'ShaderPackedBuildReportCapture.cs'
    helper_target = project / 'Assets/Editor/ShaderPackedBuildReportCapture.cs'
    helper_target.write_bytes(helper.read_bytes())
    plan['inputs'] = [base.pin(target) if Path(r['path']) == target else r for r in plan['inputs']]
    plan['inputs'].append(base.pin(helper_target))
    plan['read_only_sources'] += [base.pin(helper), base.pin(sibling), base.pin(Path(base.__file__))]
    check = plan['compile_checks'][0]
    response = Path(check['response']['path'])
    response.write_text(response.read_text() + '"' + str(helper_target) + '"\n', encoding='utf-8')
    check['source'], check['response'] = base.pin(target), base.pin(response)
    check['additional_sources'] = [base.pin(helper_target)]
    plan['runner'] = base.pin(Path(__file__))
    plan['packed_Shader_API_capture'] = {'helper': base.pin(helper), 'sibling_builder': base.pin(sibling),
        'all_Shader_records_including_builtin_duplicates': True, 'all_numeric_fields_invariant_strings': True,
        'native_mapping_must_be_corroborated_by_pure_parser': True,
        'original_builder_bytes_outside_two_insertions_exact': True}
    path.write_text(json.dumps(plan, indent=2) + '\n', encoding='utf-8')
    return path


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument('--fixture', type=Path)
    ap.add_argument('--run', action='store_true')
    ap.add_argument('--ag-asset', type=Path)
    ap.add_argument('--ag-sha')
    ap.add_argument('--ag-proof', type=Path)
    ap.add_argument('--ag-proof-sha')
    args = ap.parse_args()
    base.need(base.sha(Path(base.__file__)) == BASE_SHA, 'Frozen v3 runner changed')
    if args.fixture:
        path = (args.fixture / 'plan.json').resolve(strict=True)
    else:
        base.need(all([args.ag_asset, args.ag_sha, args.ag_proof, args.ag_proof_sha]), 'Exact AG wrapper/proof pins required')
        path = prepare(args).resolve(strict=True)
    plan, project = base.verify(path)
    base.need('packed_Shader_API_capture' in plan and plan['runner']['path'] == str(Path(__file__).resolve()), 'Packed API sibling plan required')
    for check in plan['compile_checks']:
        for row in check.get('additional_sources', []): base.guard.checked(row)
    if args.run:
        return base.run(path, plan, project)
    print(json.dumps({'status': 'prepared_verified_no_launch', 'plan': base.pin(path),
                      'Editor_launched': False, 'compiler_launched': False,
                      'command': ['C:\\Python314\\python.exe', '-B', str(Path(__file__).resolve()), '--fixture', str(path.parent), '--run']}))
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
