"""Pure bounded postprocessing of the frozen successful tiny Windows build only."""
from pathlib import Path
import datetime as dt,hashlib,json,os,shutil,struct,uuid
import run_windows_development_define_probe as guard
from probe_original_shader_sources import native_objects,object_name
from shader_program_data import model_program,program_facts
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
FIXTURE=ROOT/'AssetRecovery/OriginalShaderWindowsBuildFixture-20261022T210316Z-7924a487'
RUN=FIXTURE/'Run-20261022T210416Z-d30b50c9'
need=guard.need;sha=guard.sha
def row(path):return {'path':str(path.resolve()),'sha256':sha(path),'bytes':path.stat().st_size}
def main():
    frozen=[(FIXTURE/'plan.json','3cddd62d6db9ce18d3a60466d2498995a5e4f06e100016952af809dc447b7662'),
        (RUN/'run-report.json','8a540840050391adfbdcc99c63f172dbf80ef08257393a29ba00c246781a86ea'),
        (RUN/'build-report.json','619bfcc13b8f2ea6fa4af4215b5b9f8ad98386855abab528a2982fa402a8a3ff'),
        (HERE/'run_original_shader_build_fixture.py','86c667115dce0374a6bb25711201c5187fe3196a28f607dd2b778c361de295af')]
    for path,wanted in frozen:need(sha(path)==wanted,'Frozen existing build evidence changed')
    plan=json.loads(frozen[0][0].read_bytes());previous=json.loads(frozen[1][0].read_bytes());built=json.loads(frozen[2][0].read_bytes())
    phase=[p for p in previous['phases'] if p['phase']=='tiny-original-shader-Windows-build'];need(len(phase)==1 and phase[0]['exit_code']==0 and phase[0]['owned_cli_or_compiler_exit_confirmed'] and phase[0]['Editor_closed_after_job'],'Successful closed owned CLI build required')
    need(built['status']=='Succeeded' and built['total_errors']==built['total_warnings']==built['partial_constant_buffer_messages']==0 and built['input_bytes_unchanged'] and built['backend']=='Mono2x' and built['target']=='StandaloneWindows64' and not built['exception'],'Exact successful tiny build required')
    need(previous['partial_constant_buffer_log_count']==0 and not previous['failure_log_lines'],'Frozen build shader errors')
    config=json.loads(Path(plan['expected_data']['path']).read_bytes());project=Path(plan['project'])
    for pin in plan['read_only_sources']+plan['support_sources']+plan['reader_pins']+[plan[k] for k in ('launcher','dotnet','reader','expected_data','original_programs')]:guard.checked(pin)
    for pin in plan['inputs']:
        if not Path(pin['path']).is_relative_to(project/'ProjectSettings'):guard.checked(pin)
    guard.checked(previous['diagnostic_player']);guard.safety.assert_editor_closed()
    out=FIXTURE/('NativePostprocess-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();backup=out/'FrozenEvidenceBackup';backup.mkdir()
    for index,(path,wanted) in enumerate(frozen):shutil.copyfile(path,backup/(str(index)+'-'+path.name))
    old=frozen[-1][0].read_text();anchor="hits=[name for name in wanted if struct.pack('<I',len(name.encode()))+name.encode() in raw]"
    need(old.count(anchor)==1,'Exact discovery amendment anchor')
    new="count=struct.unpack_from('<I',raw)[0];need(count<=min(508,len(raw)-4),'Exact leading native NamedObject string bounds');leading_name=raw[4:4+count].decode('utf-8');hits=[name for name in wanted if leading_name==name]"
    revised=out/'runner.discovery-fix.proposed.py';revised.write_bytes(old.replace(anchor,new).encode())
    report={'schema':'pure-postprocessing-existing-original-shader-Windows-build/v1','status':'starting','frozen_inputs':[row(p) for p,h in frozen],'finder_proposal':row(revised),'phases':[],
        'build_repeated':False,'Editor_launched':False,'compiler_launched':False,'Main_modified':False,'gpu_rendering_verified':False,'observations':[],'tool':row(Path(__file__))}
    try:
        expected={r['name']:r['program'] for r in json.loads(Path(plan['original_programs']['path']).read_bytes())['shaders']};found={}
        player=Path(previous['diagnostic_player']['path']);data=player.parent/(player.stem+'_Data')
        for path in sorted(data.glob('*.assets')):
            table=native_objects(path);need(table['engine']=='2020.3.33f1' and table['endian']=='<','Exact native model version')
            for entry in table['shader_objects']:
                name=object_name(path,entry,table['endian'])
                if name not in expected:continue
                need(name not in found and entry['byte_size']<=8*1024**2,'Unique bounded leading Shader identity')
                with path.open('rb') as stream:stream.seek(entry['byte_offset']);raw=stream.read(entry['byte_size'])
                need(len(raw)==entry['byte_size'],'Built native selected range truncated')
                rawpath=out/('Shader-'+str(len(found))+'.bin');rawpath.write_bytes(raw);found[name]={'container':row(path),'object':entry,'raw':row(rawpath)}
        need(set(found)==set(expected),'Exactly three leading-name-selected native Shaders required')
        home=out/'DotnetHome';home.mkdir();env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1',DOTNET_NOLOGO='1',DOTNET_CLI_HOME=str(home));all_valid=True
        for index,(name,source) in enumerate(found.items()):
            target=out/('Model-'+str(index));rawpath=Path(source['raw']['path'])
            command=[plan['dotnet']['path'],plan['reader']['path'],str(rawpath),source['raw']['sha256'],source['object']['path_id'],name,str(target)]
            guard.bounded(command,project,out,'native-reader-'+str(index),512*1024**2,60,report,env=env)
            modelpath=target/'report.json';model=json.loads(modelpath.read_bytes())
            need(model['actual_name']==name and model['status']=='parsed_entire_original_object' and model['total_bytes']==model['consumed_bytes']==rawpath.stat().st_size,'Full original schema name/consumption check')
            observation={'name':name,'source':source,'model':row(modelpath),'fields':model['fields'],'full_model_consumption':True};report['observations'].append(observation)
            try:
                actual=program_facts(model_program(model,rawpath.read_bytes()));original=expected[name];a=set(actual['unique_dxbc_sha256']);b=set(original['unique_dxbc_sha256'])
                observation['built_program']=actual;observation['all_built_DXBC_chunks_are_exact_original_programs']=bool(a) and a<=b;observation['all_original_unique_DXBC_retained']=a==b;observation['stripped_original_unique_programs']=len(b-a)
                all_valid &= observation['all_built_DXBC_chunks_are_exact_original_programs']
            except ValueError as error:observation['program_gate_error']=str(error);all_valid=False
            guard.save(out,report)
        report['status']='original_DXBC_fidelity_verified' if all_valid else 'build_succeeded_native_program_fidelity_failed'
    except BaseException as error:report.update(status='failed_or_guard_refused',error=repr(error))
    finally:
        report['frozen_inputs_unchanged']=all(sha(p)==h for p,h in frozen);need(report['frozen_inputs_unchanged'],'Frozen evidence mutated')
        report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();guard.save(out,report)
        print(json.dumps({'status':report['status'],'receipt':row(out/'run-report.json'),'shaders':[{'name':x['name'],'fields':x['fields'],'program_gate_error':x.get('program_gate_error'),'fidelity':x.get('all_built_DXBC_chunks_are_exact_original_programs')} for x in report['observations']]}))
    return 0 if report['status']=='original_DXBC_fidelity_verified' else 1
if __name__=='__main__':raise SystemExit(main())
