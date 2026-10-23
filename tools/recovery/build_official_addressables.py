"""Compile and inspect the unmodified official 1.20.5 runtime sources in isolation.

This is a candidate SDK, not a package install or runtime replacement. SDK code
is compiled but NEVER invoked. Only the trusted metadata comparison helper runs.
"""
from pathlib import Path
from datetime import datetime, timezone
import argparse
import hashlib
import importlib.util
import json
import shutil
import uuid

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18'
SDK = ROOT / 'RuntimeSDKRecovery/Addressables-1.20.5'
EDITOR = WORKSPACE / 'Tools/Editors/2020.3.33f1/Editor'
RESPONSE = ROOT / 'Validation/CompileResponseSnapshot/Assembly-CSharp-runtime-ownership-20261022T104037Z-a6651f58.rsp'
RUNTIME_MANIFEST = ROOT / 'NativeGameplayRepairs/RuntimePluginMonoCompatibility-20261022T100750Z/report.json'
RAW = ROOT / 'ScriptRecoveryModernLayout/Attempt-20261022T021923Z-2fcf0245/Output'
CECIL = WORKSPACE / 'Tools/RecoveryTools/MetadataProbe/Published/Mono.Cecil.dll'
spec = importlib.util.spec_from_file_location('sdk_bounded_phase', HERE / 'build_stage_guarded.py')
guard = importlib.util.module_from_spec(spec); spec.loader.exec_module(guard)


def sha(path):
    value = hashlib.sha256()
    with path.open('rb') as stream:
        while block := stream.read(1024 * 1024): value.update(block)
    return value.hexdigest()


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--run', action='store_true')
    parser.add_argument('--private-gib', type=float, default=.125)
    args = parser.parse_args()
    if not .125 <= args.private_gib <= .5: raise ValueError('Reviewed cap range is .125-.5GiB.')
    source_proof = json.loads((SDK / 'source-provenance.json').read_text())
    if source_proof['archive']['sha256'] != 'e909683879ac318814a42023c2c2594011a923833beaa9285f7cd2a887f5ef47': raise ValueError('Source archive provenance differs.')
    package = SDK / 'OfficialPackage'
    for row in source_proof['source_files']:
        if sha(package / row['path']) != row['sha256']: raise ValueError('Official source changed: ' + row['path'])
    output = SDK / ('Candidate-' + datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    output.mkdir()
    for name in ('PlayerWindows', 'EditorWindows'): (output / name).mkdir()
    framework = EDITOR / 'Data/MonoBleedingEdge/lib/mono/4.7.1-api'
    refs = []
    definitions = []
    for line in RESPONSE.read_text(encoding='utf-8-sig').splitlines():
        if line.startswith('/reference:'):
            path = Path(line[len('/reference:'):].strip('"'))
            if path.is_absolute() and path.is_relative_to(EDITOR) and path.is_file() and path.stat().st_size > 1:
                refs.append(path)
        elif line.startswith('/define:'):
            define = line[len('/define:'):]
            if define not in ('UNITY_INCLUDE_TESTS', 'DEBUG', 'ENABLE_MONO', 'ENABLE_MONO_BDWGC'): definitions.append(define)
    if len(refs) < 30: raise ValueError('Matching Editor reference set is incomplete.')
    base = ['/target:library', '/noconfig', '/nostdlib+', '/unsafe-', '/optimize+', '/debug:portable', '/langversion:8.0', '/deterministic+']
    runtime = package / 'Runtime'; resource = runtime / 'ResourceManager'
    all_sources = sorted(runtime.rglob('*.cs'))
    groups = {'Unity.ResourceManager': [p for p in all_sources if p.is_relative_to(resource)],
              'Unity.Addressables': [p for p in all_sources if not p.is_relative_to(resource)]}
    responses = []
    for profile in ('PlayerWindows', 'EditorWindows'):
        defines = [d for d in definitions if profile == 'EditorWindows' or not d.startswith('UNITY_EDITOR')]
        if profile == 'PlayerWindows': defines.append('ENABLE_IL2CPP')
        for assembly, sources in groups.items():
            references = refs + ([output / profile / 'Unity.ResourceManager.dll'] if assembly == 'Unity.Addressables' else [])
            lines = base + [f'/out:"{output / profile / (assembly + ".dll")}"']
            lines += ['/define:' + d for d in defines]
            lines += [f'/reference:"{p}"' for p in references]
            lines += [f'"{p}"' for p in sources]
            rsp = output / profile / (assembly + '.rsp'); rsp.write_text('\n'.join(lines) + '\n')
            responses.append({'profile': profile, 'assembly': assembly, 'response': str(rsp), 'response_sha256': sha(rsp), 'source_files': len(sources), 'defines': defines})
    auditor = output / 'SDKContractAudit.exe'
    shutil.copyfile(CECIL, output / 'Mono.Cecil.dll')
    audit_rsp = output / 'compile-auditor.rsp'
    audit_rsp.write_text('\n'.join(['/target:exe', '/nostdlib+', '/noconfig', '/langversion:7.3', '/out:"' + str(auditor) + '"'] +
                        ['/reference:"' + str(framework / name) + '"' for name in ('mscorlib.dll','System.dll','System.Core.dll','System.Web.Extensions.dll','Facades/netstandard.dll')] +
                        ['/reference:"' + str(CECIL) + '"', '"' + str(HERE / 'SDKContractAudit.cs') + '"', '"' + str(HERE / 'SDKContractFixtures.cs') + '"']) + '\n')
    reference_auditor=output/'SDKReferenceAudit.exe'
    reference_rsp=output/'compile-reference-auditor.rsp'
    reference_rsp.write_text('\n'.join(['/target:exe','/nostdlib+','/noconfig','/langversion:7.3','/out:"'+str(reference_auditor)+'"']+
                            ['/reference:"'+str(framework/name)+'"' for name in ('mscorlib.dll','System.dll','System.Core.dll','System.Web.Extensions.dll','Facades/netstandard.dll')]+
                            ['/reference:"'+str(CECIL)+'"','"'+str(HERE/'SDKReferenceAudit.cs')+'"','"'+str(HERE/'SDKReferenceFixtures.cs')+'"'])+'\n')
    manifests = json.loads(RUNTIME_MANIFEST.read_text())
    current = {row['assembly']: row for row in manifests['assemblies']}
    report = {'schema': 'genuine-official-addressables-isolated-candidate/v1', 'status': 'prepared-not-compiled', 'phases': [], 'profiles': responses,
              'project_changed': False, 'sdk_methods_executed': False, 'package_installed': False, 'runtime_replacement_applied': False,
              'owned_private_cap_bytes': int(args.private_gib * 1024**3), 'minimum_system_commit_bytes': int(1.5 * 1024**3),
              'inputs': [{'path': str(p), 'sha256': sha(p)} for p in (SDK / 'source-provenance.json', RESPONSE, RUNTIME_MANIFEST, CECIL, HERE / 'SDKContractAudit.cs', HERE / 'SDKContractFixtures.cs', HERE/'SDKReferenceAudit.cs', HERE/'SDKReferenceFixtures.cs', HERE/'audit_official_sdk_native_identity.py', Path(__file__).resolve())]}
    try:
        if args.run:
            guard.reserved_phase([EDITOR / 'Data/Tools/Roslyn/csc.exe', '@' + str(audit_rsp)], output, 'compile-trusted-metadata-auditor', report, maximum=60, cap=args.private_gib)
            guard.reserved_phase([EDITOR / 'Data/MonoBleedingEdge/bin/mono.exe', auditor, '--fixtures', output / 'ContractFixtures'], output, 'synthetic-contract-fixtures', report, maximum=60, cap=args.private_gib)
            for row in responses:
                label = row['profile'] + '-' + row['assembly']
                guard.reserved_phase([EDITOR / 'Data/Tools/Roslyn/csc.exe', '@' + row['response']], output, 'compile-' + label, report, maximum=90, cap=args.private_gib)
                native = RAW / (row['assembly'] + '.dll')
                original = Path(current[row['assembly']]['candidate'])
                if sha(original) != current[row['assembly']]['candidate_sha256']: raise ValueError('Current runtime baseline changed.')
                candidate = output / row['profile'] / (row['assembly'] + '.dll')
                comparison = output / row['profile'] / (row['assembly'] + '.contract-audit.json')
                guard.reserved_phase([EDITOR / 'Data/MonoBleedingEdge/bin/mono.exe', auditor, native, original, candidate, comparison], output, 'audit-' + label, report, maximum=60, cap=args.private_gib)
                row['candidate'] = {'path': str(candidate), 'sha256': sha(candidate)}
                row['contract_audit'] = {'path': str(comparison), 'sha256': sha(comparison)}
                if row['profile']=='PlayerWindows':
                    native_rows=candidate.with_suffix('.native-rows.json')
                    guard.reserved_phase([EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',auditor,'--native-rows',candidate,native_rows],output,'native-rows-'+row['assembly'],report,maximum=60,cap=args.private_gib)
                    native_report=candidate.with_suffix('.native-identity.json')
                    guard.reserved_phase(['C:/Python314/python.exe',HERE/'audit_official_sdk_native_identity.py','--rows',native_rows,'--output',native_report],output,'native-identity-'+row['assembly'],report,maximum=90,cap=args.private_gib)
                    row['native_identity']={'path':str(native_report),'sha256':sha(native_report)}
            guard.reserved_phase([EDITOR/'Data/Tools/Roslyn/csc.exe','@'+str(reference_rsp)],output,'compile-trusted-reference-auditor',report,maximum=60,cap=args.private_gib)
            inputs=[]
            for assembly,row in current.items():
                path=output/'PlayerWindows'/(assembly+'.dll') if assembly in groups else Path(row['candidate'])
                if assembly not in groups and sha(path)!=row['candidate_sha256']:raise ValueError('Original plugin changed before SDK reference audit.')
                inputs.append(path)
            inputs.append(ROOT/'Validation/CurrentCoreIntegrationBuild-20261022T133238Z-cc828054/ActualCurrentCoreOutput/Assembly-CSharp.dll')
            input_list=output/'explicit-current-core-and-runtime-inputs.txt';input_list.write_text('\n'.join(map(str,inputs))+'\n')
            closure=output/'target-sdk-reference-closure.json'
            guard.reserved_phase([EDITOR/'Data/MonoBleedingEdge/bin/mono.exe',reference_auditor,input_list,output/'PlayerWindows',EDITOR,closure],output,'all-current-runtime-and-core-target-sdk-reference-closure',report,maximum=90,cap=args.private_gib)
            report['sdk_reference_closure']={'path':str(closure),'sha256':sha(closure)}
            report['status'] = 'compiled-and-contract-audited-no-apply'
    except Exception as error:
        report.update(status='failed-no-apply', error=str(error))
    (output / 'report.json').write_text(json.dumps(report, indent=2) + '\n')
    print(json.dumps({'status': report['status'], 'report': str(output / 'report.json'), 'error': report.get('error')}))
    return 0 if report['status'] != 'failed-no-apply' else 1


if __name__ == '__main__': raise SystemExit(main())
