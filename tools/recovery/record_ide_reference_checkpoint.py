"""Pin live Visual Studio evidence separately from Unity/gameplay acceptance."""
import json
from datetime import datetime, timezone
from pathlib import Path
import uuid
import prepare_marshalling_integration as p

root = p.ROOT
candidate = root / 'CompilerRepairs/SolarNetIDESpecificVersion-20261022T170344Z-778604a7/manifest.json'
applied = candidate.parent / 'Applied-20261022T170530Z-9da1cb0b/report.json'
live = root / 'Validation/SolarNetLiveReferenceResolution-20261022T170707Z-968352bb/report.json'
c = p.read(candidate)
a = p.read(applied)
d = p.read(live)
p.need(a['manifest_sha256'] == p.sha(candidate), 'Applied candidate provenance changed')
p.need(d['schema'] == 'actual-open-Visual-Studio-reference-resolution/v1', 'Exact live DTE report required')
p.need(Path(d['solution']) == p.WORKSPACE / 'RR23/SolarNet.sln', 'Wrong solution')
p.need(not d['game_code_executed'], 'IDE-only evidence required')
projects = {r['Name']: r for r in d['projects']}
p.need(set(projects) == {'Assembly-CSharp', 'Assembly-CSharp-firstpass'}, 'Exact project pair required')
for name, count in (('Assembly-CSharp', 418), ('Assembly-CSharp-firstpass', 192)):
    r = projects[name]
    p.need(r['Saved'] and r['ActiveConfiguration'] == 'Debug' and r['Platform'] == 'Any CPU', 'No valid saved active project context')
    p.need(r['ReferenceCount'] == r['ResolvedCount'] == count and not r['Unresolved'], 'Some live references remain unresolved')
    p.need(len(r['References']) == count and all(s['Resolved'] and s['Path'] for s in r['References']), 'Live reference details disagree')
expected = {'UnityEngine.Vector3', 'UnityEngine.Quaternion', 'UnityEngine.Transform', 'TMPro.TextMeshProUGUI'}
p.need({r['Requested'] for r in d['types']} == expected and all(r['Resolved'] and r['FullName'] == r['Requested'] for r in d['types']), 'Live CodeModel type lookup mismatch')
for row in c['files']:
    p.pinned(Path(row['target']), row['candidate_sha256'])
    p.need(next(r for r in a['files'] if r['target'] == row['target'])['after_sha256'] == row['candidate_sha256'], 'Applied source hash mismatch')
out = root / 'Validation' / ('SolarNetIDEReferenceRepairVerified-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
out.mkdir()
report = {'schema': 'SolarNet-live-IDE-reference-repair-checkpoint/v1', 'status': 'live_IDE_reference_resolution_verified',
          'inputs': [p.pinned(x) for x in (candidate, applied, live)],
          'projects': [{'name': k, 'resolved': v['ResolvedCount'], 'unresolved': 0, 'configuration': 'Debug|Any CPU'} for k, v in projects.items()],
          'code_model_type_lookups': sorted(expected), 'specific_version_policy_changes': 609,
          'all_other_project_bytes_unchanged': True, 'runtime_plugins_and_game_sources_changed_by_this_fix': False,
          'actual_Unity_compile_or_ILPP_acceptance_claimed': False, 'gameplay_or_PlayMode_verified': False,
          'legacy_error_list_used_as_acceptance': False,
          'next_compile_gate': 'Final production CodeGen/marshal/native22 package is offline and Mono64-signature passed. Actual Unity code-only harness remains unrun, pending unchanged1792MiB job plus1.5GiB system-reserve admission.'}
target = out / 'report.json'
target.write_text(json.dumps(report, indent=2) + '\n')
print(json.dumps({'report': str(target), 'sha256': p.sha(target), 'status': report['status']}))
