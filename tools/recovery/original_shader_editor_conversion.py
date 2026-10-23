"""Prepare by default; explicit --run compiles/runs only a bounded data converter."""
from pathlib import Path
import argparse,datetime as dt,hashlib,json,os,re,shutil,uuid
import run_windows_development_define_probe as guard
from shader_program_data import model_program,program_facts
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PREVIOUS=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
NATIVE=ROOT/'AssetRecovery/OriginalFallbackNativeSerializedInput-20261022T205430Z-cab1d2e4'
def row(p):return {'path':str(p.resolve()),'sha256':guard.sha(p),'bytes':p.stat().st_size}
def prepare():
    guard.need(guard.sha(PREVIOUS/'report.json')=='e99d06254cd16e817a20e19cedecbedf8005c19608d7141d80461a9b9c6c8f97','Existing exact matching reader compile proof')
    proof=NATIVE/'report.json';guard.need(guard.sha(proof)=='9e615d45be84597747ffa9094ba904ccb4a6977be7b86a8a893a1160597cc423','Exact original singleton/source closure proof')
    native=json.loads(proof.read_bytes());original=Path(native['output']['path']);guard.checked(native['output'])
    raw=original.read_bytes()[native['output']['data_offset']:][:3656]
    guard.need(len(raw)==3656 and hashlib.sha256(raw).hexdigest()=='9d68229325a824a746e3dcdca644dc7d5eb9c3677d724b118697785d8c714300','Entire original source32 raw object bytes')
    out=ROOT/'AssetRecovery'/('OriginalShaderEditorConversion-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    rawpath=out/'OriginalReleaseShader.bin';rawpath.write_bytes(raw)
    source=out/'ConvertOriginalShaderToEditor.cs';shutil.copyfile(HERE/source.name,source)
    output=out/'OriginalShaderObjectProbe.dll';rsp=out/'compile.rsp';text=(PREVIOUS/'compile.rsp').read_text()
    text,count=re.subn(r'(?m)^/out:.*$',lambda m:'/out:"'+str(output)+'"',text);guard.need(count==1,'Exact existing output anchor')
    old='"'+str(HERE/'OriginalShaderObjectProbe.cs')+'"';guard.need(text.count(old)==1,'Exact compiled-source anchor');text=text.replace(old,'"'+str(source)+'"');rsp.write_bytes(text.encode())
    runtime=[]
    for p in sorted(PREVIOUS.glob('*.dll')):
        if p.name==output.name:continue
        target=out/p.name;shutil.copyfile(p,target);guard.need(guard.sha(p)==guard.sha(target),'Matching runtime dependency copy');runtime.append(row(target))
    for ending in ('.runtimeconfig.json','.deps.json'):
        src=(PREVIOUS/'OriginalShaderObjectProbe.dll').with_suffix(ending);target=output.with_suffix(ending);shutil.copyfile(src,target);runtime.append(row(target))
    references=[row(Path(p)) for p in re.findall(r'(?m)^/reference:"([^"]+)"$',text)]
    plan={'schema':'prepared-pure-original-shader-Editor-conversion/v1','status':'prepared_not_compiled_or_run','fixture':str(out),'source':row(source),'release_input':row(rawpath),'source_closure_proof':row(proof),
        'response':row(rsp),'output':str(output),'dotnet':row(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':row(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),
        'runtime':runtime,'references':references,'runner':row(Path(__file__)),'launcher':row(HERE/'owned_suspended_launch.py'),
        'support':[row(HERE/'run_windows_development_define_probe.py'),row(HERE/'shader_program_data.py')],
        'maximum_owned_job_bytes':512*1024**2,'minimum_system_commit_reserve_bytes':int(1.5*1024**3),'Editor_launched':False,'Main_modified':False,
        'gate':'No native fixture until full ReadEditor consumption, exact original blob/arrays/ParsedForm and byte-exact complete WriteRelease roundtrip pass. Original DXBC hashes must be retained.'}
    p=out/'plan.json';p.write_bytes((json.dumps(plan,indent=2)+'\n').encode());print(json.dumps({'status':plan['status'],'plan':row(p),'command':['C:\\Python314\\python.exe','-B',str(Path(__file__)),'--plan',str(p),'--run']}))
def run(planpath,execute):
    guard.safety.assert_no_reparse(planpath);plan=json.loads(planpath.read_bytes());root=Path(plan['fixture']).resolve(strict=True)
    guard.need(plan['schema']=='prepared-pure-original-shader-Editor-conversion/v1' and root.is_relative_to(ROOT/'AssetRecovery') and root.name.startswith('OriginalShaderEditorConversion-'),'Exact prepared pure conversion fixture')
    pins=[plan[k] for k in ('source','release_input','source_closure_proof','response','dotnet','compiler','runner','launcher')]+plan['runtime']+plan['references']+plan['support']
    for pin in pins:guard.checked(pin)
    if not execute:print(json.dumps({'status':'prepared_verified_no_launch','plan':str(planpath)}));return
    output=Path(plan['output']);guard.need(not output.exists() and not(root/'Conversion').exists(),'Fresh conversion outputs')
    receipt={'schema':'guarded-pure-original-shader-Editor-conversion/v1','status':'starting','plan':row(planpath),'phases':[],'Editor_launched':False,'native_api_executed':False,'Main_modified':False}
    try:
        guard.bounded([plan['dotnet']['path'],plan['compiler']['path'],'/noconfig','@'+plan['response']['path']],root,root,'compile-data-converter',512*1024**2,30,receipt)
        guard.need(output.is_file(),'Converter assembly absent');receipt['converter']=row(output)
        home=root/'DotnetHome';home.mkdir();env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1',DOTNET_NOLOGO='1',DOTNET_CLI_HOME=str(home))
        guard.bounded([plan['dotnet']['path'],str(output),plan['release_input']['path'],plan['release_input']['sha256'],'Hidden/Universal Render Pipeline/FallbackError',str(root/'Conversion')],root,root,'roundtrip-Editor-layout',512*1024**2,60,receipt,env=env)
        p=root/'Conversion/report.json';proof=json.loads(p.read_bytes());guard.need(proof['status']=='all_original_release_bytes_and_program_fields_preserved_in_Editor_roundtrip' and proof['entire_release_object_byte_exact'] and proof['entire_ParsedForm_equal'] and proof['release_reserialized_sha256']==plan['release_input']['sha256'] and proof['editor_consumed_bytes']==proof['editor_bytes'],'Entire original data roundtrip failed')
        payload=root/'Conversion/EditorShaderObject.bin';guard.need(guard.sha(payload)==proof['editor_sha256'],'Converted Editor payload changed')
        facts=program_facts(model_program({'fields':proof['original_program_fields']},payload.read_bytes()));receipt['original_DXBC_after_Editor_roundtrip']=facts
        receipt['conversion_report']=row(p);receipt['editor_payload']=row(payload);receipt['status']='all_original_data_and_DXBC_preserved_in_Editor_roundtrip'
    except BaseException as error:receipt.update(status='failed_or_guard_refused',error=repr(error))
    finally:
        guard.save(root,receipt);print(json.dumps({'status':receipt['status'],'receipt':row(root/'run-report.json'),'editor_payload':receipt.get('editor_payload'),'error':receipt.get('error')}))
def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--plan',type=Path);p.add_argument('--run',action='store_true');a=p.parse_args()
    if a.plan:run(a.plan,a.run)
    else:guard.need(not a.run,'Prepare first; explicit pinned plan needed for run');prepare()
if __name__=='__main__':main()
