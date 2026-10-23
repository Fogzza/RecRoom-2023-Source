"""Compile ONLY trusted Windows-build helper against exact installed2020APIs.
No Editor, BuildPipeline, SDK/game code, or Main modification is performed.
"""
from pathlib import Path
import datetime as dt,json,shutil,uuid
from build_stage_guarded import reserved_phase
from audit_accessor_error_projection_static import sha
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'

def main():
    source=HERE/'BuildRecoveredWindows.cs';runner=HERE/'run_full_windows_build.py';before=sha(source)
    out=ROOT/'Validation'/('WindowsBuilderCompile2020-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    snapshot=out/source.name;shutil.copyfile(source,snapshot)
    editor=WS/'Tools/Editors/2020.3.33f1/Editor';framework=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'
    refs=[framework/'mscorlib.dll',framework/'System.dll',framework/'System.Core.dll',editor/'Data/Managed/UnityEditor.dll',editor/'Data/Managed/UnityEngine/UnityEngine.dll',editor/'Data/Managed/UnityEngine/UnityEngine.CoreModule.dll',editor/'Data/Managed/UnityEngine/UnityEngine.JSONSerializeModule.dll']
    compiler=editor/'Data/Tools/Roslyn/csc.exe';target=out/'RecoveryWindowsBuildHelper.dll';rsp=out/'compile.rsp'
    rsp.write_text('\n'.join(['/nologo','/nostdlib+','/target:library','/langversion:8','/out:"'+str(target)+'"']+['/reference:"'+str(p)+'"' for p in refs]+['"'+str(snapshot)+'"'])+'\n')
    report={'schema':'trusted-recovered-Windows-builder-exact2020-API-compile-only/v1','status':'prepared','source':{'path':str(source),'sha256':before},'snapshot':{'path':str(snapshot),'sha256':sha(snapshot)},'runner_reviewed':{'path':str(runner),'sha256':sha(runner)},'compiler':{'path':str(compiler),'sha256':sha(compiler)},'exact_references':[{'path':str(p),'sha256':sha(p)} for p in refs],'response':{'path':str(rsp),'sha256':sha(rsp)},'phases':[],'Main_modified':False,'Editor_or_BuildPipeline_launched':False,'game_SDK_or_compiled_helper_invoked':False}
    try:
        reserved_phase([compiler,'/noconfig','@'+str(rsp)],out,'compile-trusted-Windows-builder-only',report,maximum=30,cap=.25)
        if sha(source)!=before:raise ValueError('Original builder changed while snapshot was checked; exact current-source acceptance refused')
        report.update(status='compiled_zero_errors_no_game_build',compiled_helper={'path':str(target),'sha256':sha(target)},current_source_still_exact=True)
    except BaseException as error:report.update(status='failed_or_admission_refused',error=repr(error))
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'status':report['status'],'error':report.get('error'),'source_sha256':before}))

if __name__=='__main__':main()
