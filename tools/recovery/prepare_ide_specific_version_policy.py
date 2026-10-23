"""Stage an IDE-only simple-name reference policy; never edit the project."""
import hashlib
import json
import uuid
import xml.etree.ElementTree as ET
from datetime import datetime, timezone
from pathlib import Path

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
PROJECT = WORKSPACE / 'RR23'
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18'
NS = {'m': 'http://schemas.microsoft.com/developer/msbuild/2003'}
BEFORE = b'<SpecificVersion>true</SpecificVersion>'
AFTER = b'<SpecificVersion>false</SpecificVersion>'


def need(value, why):
    if not value:
        raise ValueError(why)


def digest(data):
    return hashlib.sha256(data).hexdigest()


def policy(data, expected):
    xml = ET.fromstring(data)
    refs = xml.findall('.//m:Reference', NS)
    need(len(refs) == expected, 'Exact reference count required')
    need(data.count(BEFORE) == expected, 'Exactly one true policy per reference required')
    for ref in refs:
        name = ref.get('Include')
        need(name and ',' not in name and '/' not in name and '\\' not in name,
             'Only existing simple assembly-name references admitted')
        specific = ref.findall('m:SpecificVersion', NS)
        need(len(specific) == 1 and specific[0].text == 'true' and not specific[0].attrib,
             'Exact unconditional existing policy required')
        need(ref.find('m:HintPath', NS) is not None, 'Existing HintPath required')
    result = data.replace(BEFORE, AFTER)
    need(result.replace(AFTER, BEFORE) == data, 'Byte-exact inverse required')
    changed = ET.fromstring(result)
    for old, new in zip(refs, changed.findall('.//m:Reference', NS)):
        need(old.attrib == new.attrib, 'Reference Include or attributes changed')
        new.find('m:SpecificVersion', NS).text = 'true'
        need(ET.tostring(old) == ET.tostring(new), 'Non-policy reference metadata changed')
    return result


def controls(data, expected):
    cases = []
    def rejected(label, altered, count=expected):
        try:
            policy(altered, count)
        except ValueError:
            cases.append({'case': label, 'rejected': True})
            return
        raise ValueError('Negative control unexpectedly admitted: ' + label)
    rejected('wrong-count', data, expected + 1)
    rejected('missing-policy', data.replace(BEFORE, b'', 1))
    rejected('mixed-policy', data.replace(BEFORE, AFTER, 1))
    rejected('conditional-policy', data.replace(BEFORE, b'<SpecificVersion Condition="true">true</SpecificVersion>', 1))
    rejected('full-identity-not-simple', data.replace(b'<Reference Include="', b'<Reference Include="Version=1,', 1))
    rejected('missing-HintPath', data.replace(b'<HintPath>', b'<OtherPath>', 1).replace(b'</HintPath>', b'</OtherPath>', 1))
    return cases


def main():
    out = ROOT / 'CompilerRepairs' / ('SolarNetIDESpecificVersion-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    out.mkdir()
    files = []
    tests = []
    for name, count in (('Assembly-CSharp.csproj', 417), ('Assembly-CSharp-firstpass.csproj', 192)):
        source = PROJECT / name
        original = source.read_bytes()
        candidate = policy(original, count)
        path = out / name
        path.write_bytes(candidate)
        tests.extend({'project': name, **row} for row in controls(original, count))
        need(source.read_bytes() == original, 'Main project changed during staging')
        files.append({'target': str(source), 'original_sha256': digest(original),
                      'candidate_path': str(path), 'candidate_sha256': digest(candidate),
                      'specific_version_changes': count, 'all_other_bytes_unchanged': True})
    evidence = {
        'official_task_documentation': 'https://learn.microsoft.com/en-us/visualstudio/msbuild/resolveassemblyreference-task?view=visualstudio',
        'official_resolver_source': 'https://github.com/dotnet/msbuild/blob/main/src/Tasks/AssemblyDependency/Resolver.cs',
        'source_method': 'Resolver.FileMatchesAssemblyName',
        'specific_true_predicate': 'wantSpecificVersion && assemblyName.Equals(targetAssemblyName)',
        'source_observation': 'SpecificVersion true requires the full identity to equal Include; all 609 current Includes are simple names. SpecificVersion false permits the same simple name at the existing HintPath.',
        'diagnostic_status': 'Actual RAR reason and post-change resolution must still be checked; no live Visual Studio success claim.'}
    manifest = {'schema': 'solarnet-IDE-simple-reference-specific-version-repair/v1',
                'status': 'staged_not_applied_requires_resolution_validation', 'project': str(PROJECT),
                'files': files, 'total_policy_changes': 609, 'negative_controls': tests,
                'official_evidence': evidence, 'main_project_modified': False,
                'game_sources_runtime_plugins_CodeGen_platform_settings_unchanged': True,
                'compile_or_runtime_code_executed': False}
    report = out / 'manifest.json'
    report.write_text(json.dumps(manifest, indent=2) + '\n')
    print(json.dumps({'manifest': str(report), 'sha256': digest(report.read_bytes()),
                      'changes': 609, 'negative_controls_passed': len(tests), 'main_modified': False}))


if __name__ == '__main__':
    main()
