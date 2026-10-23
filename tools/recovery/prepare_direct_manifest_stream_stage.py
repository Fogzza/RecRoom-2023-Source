"""Derive a fresh package with only the reviewed GeneralManifest read changed."""
import argparse
import json
import shutil
import uuid
from datetime import datetime, timezone
from pathlib import Path
import prepare_marshalling_integration as p

BASE = p.ROOT / 'CompilerRepairs/CurrentCoreNativeScopeMarkerVoid-20261022T162050Z-52cd19e2'
BASE_SHA = 'a340793cb4da5552ac9859eaee5d1da94fa090b3de3c2e60222272a663109284'
CANDIDATE_PLAN = p.ROOT / 'CompilerRepairs/GeneralManifestStreamingCandidate-20261022T174037Z-6ace54f2/candidate-plan.json'
CANDIDATE_SHA = 'd7d8da3cb6c0e75eed8221f3c0b8b5ff9bc1fc2057093f4a10cb77182711e07b'
ENGINE = 'Assets/Editor/OriginalMetadataRestoration/WholeMetadataRestorer.cs'
OLD = b'            using (var stream = new MemoryStream(Resource("RR23.GeneralManifest"))) manifest = WholeMetadataManifest.Read(stream);'
NEW = b'''            using (var stream = typeof(WholeMetadataRestorer).Assembly.GetManifestResourceStream("RR23.GeneralManifest"))
            {
                if (stream == null) throw new InvalidDataException("Missing pinned resource: RR23.GeneralManifest");
                manifest = WholeMetadataManifest.Read(stream);
            }'''


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--fixture-proof', required=True, type=Path)
    args = parser.parse_args()
    p.pinned(BASE / 'stage-plan.json', BASE_SHA)
    cp = p.read(CANDIDATE_PLAN)
    source = Path(cp['candidate']['path'])
    p.pinned(source, CANDIDATE_SHA)
    baseline = BASE / 'Package' / ENGINE
    before = baseline.read_bytes()
    after = source.read_bytes()
    newline = b'\r\n' if b'\r\n' in before else b'\n'
    replacement = NEW.replace(b'\n', newline)
    p.need(before.count(OLD) == 1 and before.replace(OLD, replacement) == after, 'Only exact GeneralManifest acquisition block may differ')
    fixtures = p.read(args.fixture_proof)
    p.need(fixtures['status'] == 'passed' and fixtures['candidate_sha256'] == CANDIDATE_SHA and fixtures['baseline_sha256'] == p.sha(baseline), 'Matching tested frozen candidate required')
    p.need(fixtures['production_reader_unchanged'] and fixtures['exact_all4_embedded_resources'], 'Unchanged binary parser and resource-byte proof required')
    out = p.ROOT / 'CompilerRepairs' / ('CurrentCoreDirectManifestStream-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    shutil.copytree(BASE / 'Package', out / 'Package')
    shutil.copytree(BASE / 'OriginalGaps', out / 'OriginalGaps')
    (out / 'ToolBuild').mkdir()
    for name in ('CurrentCoreChecks.cs', 'compile-checker.rsp', 'compile-codegen.rsp', 'proposed-project-csc.rsp', 'current-core-manifest.bin', 'proven-marshalling-overlay.bin', 'overlay-binding-proof.json'):
        src = BASE / name; dst = out / name
        if name.endswith(('.cs', '.rsp', '.json')):
            dst.write_text(src.read_text().replace(str(BASE), str(out)))
        else:
            shutil.copyfile(src, dst)
    plan = p.rebase(p.read(BASE / 'stage-plan.json'), BASE, out)
    for row in plan['tool_dependencies']:
        p.pinned(Path(row['path']), row['sha256'])
        shutil.copyfile(row['path'], out / 'ToolBuild' / Path(row['path']).name)
    target = out / 'Package' / ENGINE
    target.write_bytes(after)
    original_files = {str(x.relative_to(BASE / 'Package')): p.sha(x) for x in (BASE / 'Package').rglob('*') if x.is_file()}
    new_files = {str(x.relative_to(out / 'Package')): p.sha(x) for x in (out / 'Package').rglob('*') if x.is_file()}
    p.need(original_files.keys() == new_files.keys(), 'Package file inventory changed')
    deltas = [name for name in new_files if original_files[name] != new_files[name]]
    p.need(deltas == [str(Path(ENGINE))], 'Only one CodeGen file may change; metas/facades/resources must stay byte-identical')
    folder = target.parent
    plan['source_snapshots'] = [{'source': str(source) if x == target else str(x), 'copy': str(x), 'sha256': p.sha(x)} for x in sorted(folder.glob('*.cs'))]
    plan['patched_engine']['sha256'] = p.sha(target)
    plan['patched_engine']['change'] += '; read only RR23.GeneralManifest directly from its exact embedded stream, with the same parser/null/EOF checks'
    plan['marshalling_overlay']['binding_proof'] = p.pinned(out / 'overlay-binding-proof.json')
    plan['general_manifest_direct_stream'] = {'schema': 'one-resource-byte-preserving-acquisition-change/v1',
        'candidate': p.pinned(source, CANDIDATE_SHA), 'candidate_plan': p.pinned(CANDIDATE_PLAN),
        'fixtures': p.pinned(args.fixture_proof), 'base_stage': p.pinned(BASE / 'stage-plan.json', BASE_SHA),
        'changed_package_files': deltas, 'all_other_package_bytes_identical': True, 'all4_resource_bytes_identical': True,
        'reader_count_schema_and_end_checks_changed': False, 'other_resource_paths_changed': False,
        'fingerprint_pooling_GC_native_lowering_or_coverage_changes': False, 'main_project_modified': False}
    plan['inputs'] += [p.pinned(BASE / 'stage-plan.json', BASE_SHA), p.pinned(CANDIDATE_PLAN), p.pinned(args.fixture_proof)]
    file = out / 'stage-plan.json'
    file.write_text(json.dumps(plan, indent=2) + '\n')
    print(json.dumps({'stage': str(out), 'stage_plan': str(file), 'sha256': p.sha(file), 'changed_package_files': deltas}))


if __name__ == '__main__':
    main()
