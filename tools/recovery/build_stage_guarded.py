"""Build trusted current-core checker/CodeGen and run metadata-only fixtures.

The actual whole-core roundtrip requires an explicit --core/--pdb pair after
zero-error compilation, and a separately coordinated larger memory cap.
"""
import argparse
from datetime import datetime, timezone
import importlib.util
import json
from pathlib import Path
import shutil
import sys
import uuid
import ctypes, os, subprocess, time
from ctypes import wintypes

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
ROOT = WORKSPACE / 'Recovery/RecRoom-2023-04-18'
EDITOR = WORKSPACE / 'Tools/Editors/2020.3.33f1/Editor'
spec = importlib.util.spec_from_file_location('current_core_build_guard', HERE.parent / 'MovementRequestEvidence/run_guarded.py')
guard = importlib.util.module_from_spec(spec); spec.loader.exec_module(guard)

def reserved_phase(command, output, label, report, maximum=120, cap=.25):
    reserve=1.5*guard.GIB
    if guard.memory().available_commit < cap*guard.GIB+reserve or shutil.disk_usage(output).free<4*guard.GIB:
        raise RuntimeError('Insufficient1.5GiB commit reserve/disk before '+label)
    api=ctypes.WinDLL('psapi',use_last_error=True).GetProcessMemoryInfo
    api.argtypes=[wintypes.HANDLE,ctypes.POINTER(guard.ProcessMemory),wintypes.DWORD];api.restype=wintypes.BOOL
    row={'phase':label,'command':[str(s) for s in command],'samples':[],'minimum_system_commit_bytes':int(reserve)};report['phases'].append(row);child=None;started=time.monotonic()
    try:
        with (output/(label+'.log')).open('wb') as log:
            child=subprocess.Popen([str(s) for s in command],cwd=HERE,env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1'),stdout=log,stderr=subprocess.STDOUT,creationflags=subprocess.CREATE_NO_WINDOW);row['owned_pid']=child.pid;next_sample=0
            while child.poll() is None:
                info=guard.ProcessMemory();info.cb=ctypes.sizeof(info)
                if not api(wintypes.HANDLE(int(child._handle)),ctypes.byref(info),info.cb):raise ctypes.WinError(ctypes.get_last_error())
                available=guard.memory().available_commit;elapsed=time.monotonic()-started;row['peak_private_bytes']=max(row.get('peak_private_bytes',0),info.PrivateUsage)
                if info.PrivateUsage>cap*guard.GIB or available<reserve or elapsed>maximum or shutil.disk_usage(output).free<4*guard.GIB:raise RuntimeError('Owned private/1.5GiB commit/time/disk guard: '+label)
                if elapsed>=next_sample:row['samples'].append({'seconds':round(elapsed,2),'private_bytes':info.PrivateUsage,'available_commit_bytes':available});next_sample=elapsed+5
                time.sleep(.1)
        row['exit_code']=child.returncode
        if child.returncode:raise RuntimeError(label+' exited '+str(child.returncode))
    finally:
        if child is not None and child.poll() is None:child.kill();child.wait(timeout=10);row['owned_process_terminated']=True
        row['seconds']=round(time.monotonic()-started,2)


def main():
    p = argparse.ArgumentParser(); p.add_argument('--stage', type=Path, required=True); p.add_argument('--core', type=Path); p.add_argument('--pdb', type=Path)
    p.add_argument('--whole-private-gib', type=float, default=.25)
    p.add_argument('--reference-response', type=Path)
    p.add_argument('--runtime-plugin-manifest', type=Path)
    args = p.parse_args(); stage = args.stage.resolve(strict=True)
    if args.core or args.pdb:
        if not args.core or not args.pdb: raise ValueError('Both actual core and portable PDB required')
        if not args.reference_response or not args.runtime_plugin_manifest: raise ValueError('Actual reference response and verified runtime plugin manifest required')
        if not .25 <= args.whole_private_gib <= 1.5: raise ValueError('Whole-check cap outside reviewed range')
    stamp = datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8]
    output = ROOT / 'Validation' / ('CurrentCoreIntegrationBuild-' + stamp); output.mkdir()
    report = {'schema': 'guarded-current-core-metadata-tool-build/v1', 'phases': [], 'project_changed': False, 'game_code_executed': False,
              'stage_plan': {'path': str(stage / 'stage-plan.json'), 'sha256': guard.sha(stage / 'stage-plan.json')}}
    try:
        fixture = stage / 'TypeContractFixtures.cs'; shutil.copyfile(HERE / fixture.name, fixture)
        base = (stage / 'compile-codegen.rsp').read_text().splitlines()
        target = stage / 'ToolBuild/TypeContractFixtures.exe'
        lines = [line for line in base if not line.startswith(('/target:', '/out:'))]
        subset=json.loads((stage/'stage-plan.json').read_text()).get('method_subset_schema')==6
        if subset:lines.append('/define:RR23_METHOD_SUBSET')
        (stage / 'compile-contract-fixtures.rsp').write_text('\n'.join(lines + ['/target:exe', f'/out:"{target}"', f'"{fixture}"']) + '\n')
        for name in ('checker', 'codegen', 'contract-fixtures'):
            reserved_phase([EDITOR / 'Data/Tools/Roslyn/csc.exe', '@' + str(stage / ('compile-' + name + '.rsp'))], output, 'compile-' + name, report, maximum=120, cap=.25)
        reserved_phase([EDITOR / 'Data/MonoBleedingEdge/bin/mono.exe', target], output, 'contract-positive-and-negative-fixtures', report, maximum=60, cap=.25)
        report['contract_tests_passed'] = 32 if subset else 9
        report['runtime_files'] = [{'path': str(p), 'sha256': guard.sha(p)} for p in sorted((stage / 'ToolBuild').iterdir()) if p.is_file()]
        if args.core:
            report['actual_core_inputs'] = [{'path': str(p.resolve()), 'sha256': guard.sha(p)} for p in (args.core, args.pdb)]
            runtime_manifest=json.loads(args.runtime_plugin_manifest.read_text())
            runtime={row['assembly']:row for row in runtime_manifest['assemblies']}
            if len(runtime)!=225:raise ValueError('Expected exactly 225 runtime plugin identities')
            exact=[]
            for line in args.reference_response.read_text(encoding='utf-8-sig').splitlines():
                if not line.startswith('/reference:'):continue
                path=Path(line[len('/reference:'):].strip('"'))
                if not path.is_absolute():path=WORKSPACE/'RR23'/path
                if path.parent.name=='Plugins':
                    row=runtime[path.stem];path=Path(row['candidate'])
                    if guard.sha(path)!=row['candidate_sha256']:raise ValueError('Runtime plugin changed: '+path.stem)
                path=path.resolve(strict=True)
                if path not in exact:exact.append(path)
            if len(exact)<225:raise ValueError('Incomplete actual reference inventory')
            refs=output/'exact-metadata-reference-paths.txt';refs.write_text('\n'.join(map(str,exact))+'\n')
            report['exact_metadata_reference_inventory']={'path':str(refs),'sha256':guard.sha(refs),'inputs':[{'path':str(p.resolve()),'sha256':guard.sha(p)} for p in (args.reference_response,args.runtime_plugin_manifest)],'files':[{'path':str(p),'sha256':guard.sha(p)} for p in exact]}
            restored = output / 'ActualCurrentCoreOutput'
            reserved_phase([EDITOR / 'Data/MonoBleedingEdge/bin/mono.exe', stage / 'ToolBuild/CurrentCoreChecks.exe', args.core.resolve(), args.pdb.resolve(), restored, refs],
                        output, 'actual-current-core-whole-metadata-ilpp-roundtrip', report, maximum=180, cap=args.whole_private_gib)
            report['actual_core_roundtrip'] = {'path': str(restored / 'receipt.json'), 'sha256': guard.sha(restored / 'receipt.json')}
        report.update(status='built_and_tested', actual_core_roundtrip_executed=bool(args.core), actual_unity_editor_discovery_executed=False)
    except Exception as e:
        report.update(status='failed', error=str(e))
    path = output / 'report.json'; path.write_text(json.dumps(report, indent=2) + '\n')
    print(json.dumps({'status': report['status'], 'report': str(path), 'actual_core_roundtrip': report.get('actual_core_roundtrip'), 'error': report.get('error')}))
    return 0 if report['status'] == 'built_and_tested' else 1


if __name__ == '__main__':
    raise SystemExit(main())
