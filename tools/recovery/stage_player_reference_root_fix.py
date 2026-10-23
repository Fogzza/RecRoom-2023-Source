"""Stage one exact resolver path guard edit, compile and exercise toy metadata.
No Main writes, Unity launches, inspected code invocation, or broad path search.
"""
from pathlib import Path
import datetime as dt,difflib,hashlib,json,shutil,uuid
from build_stage_guarded import reserved_phase,EDITOR
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
def sha(p):
    with Path(p).open('rb')as f:return hashlib.file_digest(f,'sha256').hexdigest()
def pin(p):return {'path':str(p),'sha256':sha(p)}
def main():
    source=WS/'RR23/Assets/Editor/OriginalMetadataRestoration/ExactMetadataReferenceResolver.cs'
    fixture=HERE/'PlayerReferenceRootFixtures.cs'
    out=ROOT/'CompilerRepairs'/('PlayerMetadataReferenceRoot-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    before=source.read_bytes();old=b'directory.Name=="ScriptAssemblies" && directory.Parent!=null && directory.Parent.Name=="Library"'
    new=b'(directory.Name=="ScriptAssemblies" || directory.Name=="PlayerScriptAssemblies") && directory.Parent!=null && directory.Parent.Name=="Library"'
    if before.count(old)!=1:raise ValueError('Expected exact single original firstpass scope guard')
    candidate=out/source.name;candidate.write_bytes(before.replace(old,new));original=out/'OriginalExactMetadataReferenceResolver.cs';original.write_bytes(before)
    (out/'patch.diff').write_text(''.join(difflib.unified_diff(before.decode().splitlines(True),candidate.read_bytes().decode().splitlines(True),fromfile=str(source),tofile=str(candidate))))
    cecil=WS/'RR23/Assets/Editor/OriginalMetadataDependencies/Mono.Cecil.dll';shutil.copyfile(cecil,out/cecil.name)
    framework=EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api';compiler=EDITOR/'Data/Tools/Roslyn/csc.exe';mono=EDITOR/'Data/MonoBleedingEdge/bin/mono.exe'
    reference_names=('mscorlib.dll','System.dll','System.Core.dll','Facades/netstandard.dll')
    inputs=[source,fixture,compiler,mono,cecil]+[framework/n for n in reference_names]
    report={'schema':'exact-Unity2020-Windows-player-firstpass-resolver-root-fix/v1','status':'prepared','source':pin(source),'candidate':pin(candidate),'patch':pin(out/'patch.diff'),'inputs':[pin(p)for p in inputs],'phases':[],'mutation_scope':'ONE additive approved firstpass directory leaf; all original root, hash, identity and ambiguity refusals unchanged','actual_failure_evidence':{'log':pin(ROOT/'Validation/FullWindowsBuild-20261022T192033Z-0b7ac877/Editor.log'),'player_firstpass':pin(WS/'RR23/Library/PlayerScriptAssemblies/Assembly-CSharp-firstpass.dll'),'observed_path':'Library/PlayerScriptAssemblies/Assembly-CSharp-firstpass.dll'},'Main_modified':False,'Editor_launched':False,'game_or_SDK_code_executed':False}
    try:
        for name,src,mode in [('baseline',original,'baseline'),('candidate',candidate,'candidate')]:
            exe=out/(name+'.exe');rsp=out/(name+'.rsp');rsp.write_text('\n'.join(['/nologo','/nostdlib+','/target:exe','/langversion:7.3','/out:"'+str(exe)+'"']+['/reference:"'+str(framework/n)+'"' for n in reference_names]+['/reference:"'+str(cecil)+'"','"'+str(src)+'"','"'+str(fixture)+'"'])+'\n')
            reserved_phase([compiler,'/noconfig','@'+str(rsp)],out,'compile-'+name,report,maximum=30,cap=.25)
            reserved_phase([mono,exe,out/(name+'-fixture-files'),mode],out,'run-'+name+'-toy-metadata-only',report,maximum=30,cap=.25)
        if source.read_bytes()!=before:raise ValueError('Main resolver changed while candidate was checked')
        report.update(status='passed',baseline_actual_player_path_refusal_proved=True,candidate_controls=15,current_Main_source_unchanged=True,compiled_candidate=pin(out/'candidate.exe'))
    except BaseException as error:report.update(status='failed_or_admission_refused',error=repr(error))
    path=out/'report.json';path.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(path),'sha256':sha(path),'status':report['status'],'candidate':pin(candidate),'error':report.get('error')}))
if __name__=='__main__':main()
