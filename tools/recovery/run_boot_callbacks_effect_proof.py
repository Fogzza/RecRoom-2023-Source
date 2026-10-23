"""Compile exact two-callback candidate; inspect symbols/IL, never execute it."""
from pathlib import Path
import base64, datetime as dt, hashlib, json, shutil, sys, uuid
from run_win32_abi_compat_fixture import ROOT, EDITOR, phase, need

HERE = Path(__file__).resolve().parent
WORKSPACE = HERE.parents[2]
SDK = Path('C:/Program Files/dotnet/sdk/10.0.400')
DOTNET = Path('C:/Program Files/dotnet/dotnet.exe')
FRAMEWORK = Path('C:/Program Files/dotnet/packs/Microsoft.NETCore.App.Ref/10.0.11/ref/net10.0')

def sha(path):
    with Path(path).open('rb') as f: return hashlib.file_digest(f, 'sha256').hexdigest()

def main():
    proof = ROOT / 'Validation/RecRoomBootCallbacksCandidate-20261022T165119Z-3719e254/report.json'
    need(sha(proof) == '3ac8088174f89b846366a4055f5f35f1ecd7a6420a788f8c2407948721b363fa', 'Native/typed candidate drift')
    candidate = json.loads(proof.read_text())
    for key, hash_key in [('source', 'source_sha256'), ('candidate', 'candidate_sha256')]: need(sha(candidate[key]) == candidate[hash_key], key + ' changed')
    need(sha(candidate['source'] + '.meta') == candidate['source_meta_sha256'], 'Main script meta changed')
    references_file = ROOT / 'Validation/CurrentCoreMarshalRoundtrip-20261022T162157Z-ad86540f/exact-original-metadata-references.txt'
    core = ROOT / 'Validation/CurrentCoreMarshalRoundtrip-20261022T162157Z-ad86540f/ActualCurrentCoreOutput/Assembly-CSharp.dll'
    need(sha(core) == '885953e1ae5b44cce72d742ad5817d33bb64594581b97565518d0799d4da95e5', 'Approved actual core changed')
    approved_refs = [Path(p) for p in references_file.read_text().splitlines() if p.strip()]
    required = {'mscorlib.dll','System.dll','System.Core.dll','netstandard.dll','UnityEngine.CoreModule.dll','RecRoom.Datastructures.Singletons.Runtime.dll','RecRoom.MemoryStats.Runtime.dll','Unity.Addressables.dll','Unity.ResourceManager.dll'}
    refs = [p for p in approved_refs if p.name in required] + [core]
    need({p.name for p in refs} == required | {'Assembly-CSharp.dll'} and len(refs) == len(required)+1 and all(r.is_file() for r in refs), 'Missing/duplicate exact narrowed reference')
    folder = ROOT / 'Validation' / ('BootCallbacksSourceEffects-' + dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ') + '-' + uuid.uuid4().hex[:8])
    folder.mkdir()
    report = {'schema':'native-RecRoomGameRoot-two-callback-compiled-effect-proof/v1', 'status':'started', 'phases':[], 'main_project_modified':False, 'inspected_game_or_fixture_code_executed':False}
    try:
        fixture = folder / 'RecRoomBootCallbacksCandidate.dll'
        rsp = folder / 'matching2020.rsp'
        rsp.write_text('\n'.join(['/nologo', '/noconfig', '/nostdlib+', '/target:library', '/langversion:8.0', '/optimize+', '/out:"'+str(fixture)+'"'] + ['/reference:"'+str(r)+'"' for r in refs] + ['"'+candidate['candidate']+'"']) + '\n')
        report['phases'].append(phase([EDITOR/'Data/Tools/Roslyn/csc.exe', '@'+str(rsp)], folder, 'compile-exact-candidate-2020', 128*1024**2, 30))
        deps = [HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll', SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.dll', SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.CSharp.dll']
        host = folder / 'BootCallbacksEffectProof.dll'
        helper_source = HERE / 'BootCallbacksEffectProof.cs'
        hrsp = folder / 'trusted-inspector.rsp'
        hrsp.write_text('\n'.join(['/nologo','/target:exe','/langversion:latest','/out:"'+str(host)+'"'] + ['/reference:"'+str(r)+'"' for r in sorted(FRAMEWORK.glob('*.dll')) + deps] + ['"'+str(helper_source)+'"']) + '\n')
        report['phases'].append(phase([DOTNET, SDK/'Roslyn/bincore/csc.dll', '/noconfig', '@'+str(hrsp)], folder, 'compile-trusted-inspector', 128*1024**2, 30))
        for dep in deps: shutil.copyfile(dep, folder/dep.name)
        host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}))
        effects = folder / 'effects.json'
        report['phases'].append(phase([DOTNET, host, fixture, effects, candidate['candidate']] + refs, folder, 'inspect-symbols-IL-no-invocation', 128*1024**2, 30))
        need(json.loads(effects.read_text())['passed'], 'Effect proof failed')
        original = Path(candidate['source']).read_bytes()
        edited = original
        for e in sorted(candidate['byte_edits'], key=lambda x:x['start'], reverse=True):
            need(original[e['start']:e['start']+e['length']] == base64.b64decode(e['original_base64']), 'Original span changed')
            edited = edited[:e['start']] + base64.b64decode(e['replacement_base64']) + edited[e['start']+e['length']:]
        need(hashlib.sha256(edited).hexdigest() == candidate['candidate_sha256'], 'Exact body transaction differs')
        need(sha(candidate['source']) == candidate['source_sha256'] and sha(candidate['source']+'.meta') == candidate['source_meta_sha256'], 'Main changed during fixture')
        report.update(status='passed', source=candidate['source'], source_sha256=candidate['source_sha256'], source_meta_sha256=candidate['source_meta_sha256'], candidate=candidate['candidate'], candidate_sha256=candidate['candidate_sha256'], byte_edits=candidate['byte_edits'], original_method_count=2, input_proof=[{'path':str(p),'sha256':sha(p)} for p in [proof,effects,fixture,helper_source,references_file]+refs], native_proof={'path':str(proof),'sha256':sha(proof)}, compiled_effects={'path':str(effects),'sha256':sha(effects)}, native_BootSequence_body_recovered=False, native_GameRoot_OnDestroy_body_recovered=False)
    except BaseException as error: report.update(status='failed', error=repr(error))
    result = folder / 'report.json'; result.write_text(json.dumps(report,indent=2)+'\n')
    print(json.dumps({'status':report['status'],'report':str(result),'sha256':sha(result),'error':report.get('error')}))
    return 0 if report['status']=='passed' else 1

if __name__ == '__main__': raise SystemExit(main())
