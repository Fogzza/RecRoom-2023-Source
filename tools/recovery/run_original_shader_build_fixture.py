"""Review by default; --run performs only the isolated original-shader diagnostic."""
from pathlib import Path
import argparse,datetime as dt,json,os,re,shlex,struct,sys,uuid
import run_windows_development_define_probe as guard
from shader_program_data import model_program,program_facts
from probe_original_shader_sources import native_objects
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sha=guard.sha;need=guard.need;row=lambda p:{'path':str(p.resolve()),'sha256':sha(p),'bytes':p.stat().st_size}

def native_outputs(plan,project,out,report,player):
    expected=json.loads(Path(plan['original_programs']['path']).read_bytes())['shaders']
    wanted={r['name']:r for r in expected};found={};read_bytes=0
    data=player.parent/(player.stem+'_Data');need(data.is_dir(),'Built native Data directory absent')
    containers=[p for p in sorted(data.iterdir()) if p.is_file() and p.suffix=='.assets']
    need(0<len(containers)<=12,'Bounded built native container inventory')
    for path in containers:
        table=native_objects(path);need(table['engine']=='2020.3.33f1' and table['endian']=='<','Matching native build metadata required')
        for entry in table['shader_objects']:
            if entry['byte_size']>8*1024**2:continue
            read_bytes+=entry['byte_size'];need(read_bytes<=128*1024**2,'Built Shader discovery read allowance')
            with path.open('rb') as stream:stream.seek(entry['byte_offset']);raw=stream.read(entry['byte_size'])
            need(len(raw)==entry['byte_size'],'Built Shader range truncated')
            hits=[name for name in wanted if struct.pack('<I',len(name.encode()))+name.encode() in raw]
            need(len(hits)<=1,'Ambiguous built Shader discovery')
            if hits:
                name=hits[0];need(name not in found,'Duplicate built Shader identity requires review')
                rawpath=out/('BuiltShader-'+str(len(found))+'.bin');rawpath.write_bytes(raw)
                found[name]={'container':row(path),'object':entry,'raw':row(rawpath)}
    need(set(found)==set(wanted),'Not all three authentic Shader objects survived the real Windows build: '+str(sorted(set(wanted)-set(found))))
    observations=[];dotnethome=out/'DotnetHome';dotnethome.mkdir()
    env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1',DOTNET_NOLOGO='1',DOTNET_CLI_HOME=str(dotnethome))
    for index,(name,source) in enumerate(found.items()):
        target=out/('BuiltShaderModel-'+str(index));rawpath=Path(source['raw']['path'])
        command=[plan['dotnet']['path'],plan['reader']['path'],str(rawpath),source['raw']['sha256'],source['object']['path_id'],name,str(target)]
        guard.bounded(command,project,out,'native-shader-reader-'+str(index),512*1024**2,60,report,env=env)
        modelpath=target/'report.json';need(modelpath.is_file(),'Native Shader model report absent');model=json.loads(modelpath.read_bytes())
        need(model['status']=='parsed_entire_original_object' and model['actual_name']==name and model['consumed_bytes']==model['total_bytes']==rawpath.stat().st_size,'Entire native Shader identity/model proof failed')
        actual=program_facts(model_program(model,rawpath.read_bytes()));original=wanted[name]['program']
        actualset=set(actual['unique_dxbc_sha256']);originalset=set(original['unique_dxbc_sha256'])
        comparison={'all_built_DXBC_chunks_are_exact_original_programs':bool(actualset) and actualset<=originalset,
            'all_unique_original_DXBC_programs_retained':actualset==originalset,'built_unique_programs':len(actualset),'original_unique_programs':len(originalset),
            'stripped_original_unique_programs':len(originalset-actualset),'unexpected_built_unique_programs':len(actualset-originalset)}
        observations.append({'name':name,'source':source,'model':row(modelpath),'built_program':actual,'comparison':comparison})
        report['native_output_shader_observations']=observations;guard.save(out,report)
        need(comparison['all_built_DXBC_chunks_are_exact_original_programs'],'Built Shader contains a nonoriginal DXBC program')
    report['native_output_programs_verified']=True

def build(plan,project,out,report):
    result=out/'build-report.json';player=out/'Player/OriginalShaderDiagnostic.exe';player.parent.mkdir();log=out/'Editor.log'
    extra=shlex.join(['-disable-assembly-updater','-job-worker-count','1','-shaderBuildReport',result.as_posix(),'-shaderBuildConfig',Path(plan['expected_data']['path']).as_posix()])
    command=[guard.CLI.as_posix(),'build',project.as_posix(),'--target','StandaloneWindows64','--execute-method','BuildOriginalShaderPrograms.Run',
        '--output-path',player.as_posix(),'--editor-path',guard.EDITOR.as_posix(),'--args',extra,'--timeout','300','--allow-dirty-build','--no-tail','--no-accelerator',
        '--log-file',log.as_posix(),'--provenance-path',(out/'provenance.json').as_posix(),'--format','json']
    try:guard.bounded(command,project,out,'tiny-original-shader-Windows-build',2*1024**3,300,report)
    finally:
        if result.is_file():report['build_result']=json.loads(result.read_bytes());report['build_report']=row(result)
        if log.is_file():
            text=log.read_text(encoding='utf-8',errors='replace');report['partial_constant_buffer_log_count']=text.count('Partial constant buffer not found.')
            report['failure_log_lines']=re.findall(r'(?im)^.*(?:Partial constant buffer not found\.|error CS\d+|Shader error in|Failed to read serialized|Fatal error|Aborting batchmode due to).*$',text)[:48]
        guard.save(out,report)
    need(result.is_file() and player.is_file(),'Tiny BuildReport/player absent');built=report['build_result']
    need(built['status']=='Succeeded' and built['total_errors']==0 and built['unity_version']=='2020.3.33f1' and built['backend']=='Mono2x'
        and built['target']=='StandaloneWindows64' and built['development'] and built['input_bytes_unchanged']
        and 'Development' in built['build_options'] and 'StrictMode' in built['build_options'],'Matching tiny diagnostic build gate failed')
    need(report.get('partial_constant_buffer_log_count')==0 and not report.get('failure_log_lines'),'Tiny fixture logged shader/constant-buffer/compiler failure')
    report['diagnostic_player']=row(player)
    for record in plan['read_only_sources']+[r for r in plan['inputs'] if Path(r['path']).suffix=='.asset' and '/Resources/' in Path(r['path']).as_posix() or Path(r['path']).name.endswith('.asset.meta')]:guard.checked(record)
    native_outputs(plan,project,out,report,player)

def main():
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--fixture',type=Path,required=True);parser.add_argument('--run',action='store_true');parser.add_argument('--compile-only',action='store_true');args=parser.parse_args()
    need(not(args.run and args.compile_only),'Choose run or compile-only');guard.safety.assert_no_reparse(args.fixture);fixture=args.fixture.resolve(strict=True)
    need(fixture.is_relative_to(ROOT/'AssetRecovery') and fixture.name.startswith('OriginalShaderWindowsBuildFixture-'),'Exact diagnostic fixture required')
    planpath=fixture/'plan.json';plan=json.loads(planpath.read_bytes());project=Path(plan['project']).resolve(strict=True)
    need(plan['schema']=='prepared-tiny-original-shader-windows-build/v1' and project==fixture/'Project','Unexpected fixture shape')
    need(Path(plan['editor']['path'])==guard.EDITOR and Path(plan['cli']['path'])==guard.CLI,'Matching Editor and CLI required')
    pins=[plan[k] for k in ('runner','launcher','preparer','editor','cli','compiler','dotnet','expected_data','original_programs','reader')]+plan['inputs']+plan['read_only_sources']+plan['support_sources']+plan['reader_pins']
    for check in plan['compile_checks']:pins += [check['source'],check['response']]+check['references']
    for pin in pins:guard.checked(pin)
    allowed={Path(r['path']).resolve() for r in plan['inputs']}
    for path in (project/'Assets').rglob('*'):
        guard.safety.assert_no_reparse(path)
        if path.is_file():need(path.resolve() in allowed,'Unexpected fixture asset: '+str(path))
    need(not(project/'Library').exists() and not(project/'Temp').exists(),'Fresh never-launched fixture required')
    if not args.run and not args.compile_only:
        print(json.dumps({'status':'prepared_verified_no_launch','plan':str(planpath),'plan_sha256':sha(planpath),'Editor_launched':False,'compiler_launched':False}));return 0
    out=fixture/('Run-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'guarded-tiny-original-shader-windows-build/v1','status':'starting','fixture':str(fixture),'plan_sha256':sha(planpath),'phases':[],
        'Main_modified':False,'player_launched':False,'gpu_rendering_verified':False,'native_output_programs_verified':False}
    try:
        guard.compile_sources(plan,project,out,report)
        if args.compile_only:report['status']='matching_source_compiled_Editor_not_launched'
        else:build(plan,project,out,report);report['status']='tiny_Windows_build_original_DXBC_program_subset_verified'
    except BaseException as error:report.update(status='failed_or_guard_refused',error=repr(error))
    finally:
        report['finished_utc']=dt.datetime.now(dt.timezone.utc).isoformat();guard.save(out,report)
        print(json.dumps({'status':report['status'],'report':str(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status'] in ('matching_source_compiled_Editor_not_launched','tiny_Windows_build_original_DXBC_program_subset_verified') else 1
if __name__=='__main__':raise SystemExit(main())
