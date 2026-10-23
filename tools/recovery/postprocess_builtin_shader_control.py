"""Read one ordinary built-in Shader from the existing tiny build; no rebuild."""
from pathlib import Path
import datetime as dt,json,os,uuid
import run_windows_development_define_probe as guard
from probe_original_shader_sources import native_objects
from shader_program_data import model_program,program_facts
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
FIXTURE=ROOT/'AssetRecovery/OriginalShaderWindowsBuildFixture-20261022T210316Z-7924a487'
RUN=FIXTURE/'Run-20261022T210416Z-d30b50c9'
def row(p):return {'path':str(p.resolve()),'sha256':guard.sha(p),'bytes':p.stat().st_size}
def main():
    planpath=FIXTURE/'plan.json';guard.need(guard.sha(planpath)=='3cddd62d6db9ce18d3a60466d2498995a5e4f06e100016952af809dc447b7662','Frozen tiny plan')
    plan=json.loads(planpath.read_bytes());guard.safety.assert_editor_closed()
    for pin in plan['reader_pins']+[plan['reader'],plan['dotnet'],plan['launcher']]+plan['support_sources']:guard.checked(pin)
    original=RUN/'run-report.json';guard.need(guard.sha(original)=='8a540840050391adfbdcc99c63f172dbf80ef08257393a29ba00c246781a86ea','Frozen tiny build receipt')
    out=FIXTURE/('BuiltinProgramControl-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    source=RUN/'Player/OriginalShaderDiagnostic_Data/globalgamemanagers.assets'
    objects=[r for r in native_objects(source)['shader_objects'] if r['path_id']=='3'];guard.need(len(objects)==1 and objects[0]['byte_size']==5432,'Exact existing builtin object')
    obj=objects[0]
    with source.open('rb') as stream:stream.seek(obj['byte_offset']);raw=stream.read(obj['byte_size'])
    rawpath=out/'Builtin-SpritesDefault.bin';rawpath.write_bytes(raw)
    report={'schema':'existing-build-ordinary-builtin-program-control/v1','status':'starting','phases':[],'source':row(source),'object':obj,'raw':row(rawpath),'frozen_tiny_build_receipt':row(original),'Main_modified':False,'Editor_launched':False,'compiler_launched':False,'player_launched':False}
    try:
        target=out/'Model';home=out/'DotnetHome';home.mkdir();env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1',DOTNET_NOLOGO='1',DOTNET_CLI_HOME=str(home))
        guard.bounded([plan['dotnet']['path'],plan['reader']['path'],str(rawpath),guard.sha(rawpath),'3','Sprites/Default',str(target)],Path(plan['project']),out,'read-built-builtin',512*1024**2,60,report,env=env)
        modelpath=target/'report.json';model=json.loads(modelpath.read_bytes());guard.need(model['actual_name']=='Sprites/Default' and model['total_bytes']==model['consumed_bytes']==5432,'Exact full native builtin read')
        report['model']=row(modelpath);report['fields']=model['fields'];report['program']=program_facts(model_program(model,raw));report['status']='ordinary_builtin_has_real_DXBC_in_same_build'
    except BaseException as error:report.update(status='failed_or_guard_refused',error=repr(error))
    finally:
        guard.need(guard.sha(original)=='8a540840050391adfbdcc99c63f172dbf80ef08257393a29ba00c246781a86ea','Frozen tiny receipt changed');guard.save(out,report)
        print(json.dumps({'status':report['status'],'receipt':row(out/'run-report.json'),'dxbc_chunks':report.get('program',{}).get('dxbc_chunks'),'error':report.get('error')}))
if __name__=='__main__':main()
