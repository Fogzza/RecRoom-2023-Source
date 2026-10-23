"""Bounded pure generated ReadRelease/WriteEditor proof for original AG+fallback.

No Unity process or native SDK is launched. Original external FileID/PathID
values are retained and reported, never resolved, renumbered or remapped.
"""
from pathlib import Path
import argparse
import ctypes
import datetime as dt
import hashlib
import json
import os
import re
import shutil
import struct
import subprocess
import sys
import time
import uuid

HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PREVIOUS=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
OLD=ROOT/'AssetRecovery/OriginalShaderEditorConversion-20261022T212623Z-fde1a98d'
AG=ROOT/'AssetRecovery/OriginalShaderRecoveryRoute-20261022T184808Z-356f2e1f/OriginalSerializedShaderObjects/native-6351.bin'
AG_MODEL=ROOT/'AssetRecovery/OriginalAGShaderModels-20261022T203556Z-4b62253a/native-Object/report.json'
DEPENDENCY=ROOT/'AssetRecovery/OriginalShaderDependencyResolution-20261022T214505Z-bfbbb8ca/report.json'
CAP=512*1024**2;RESERVE=int(1.5*1024**3)
sys.path.insert(0,str(ROOT/'Tools'))
from export_bundle_batches import ChildJob,ExtendedJob
from guarded_cpp2il import memory
from owned_suspended_launch import launch_suspended_in_job
import repair_rr23_wav_headers as safety


def need(v,message):
    if not v:raise RuntimeError(message)


def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()


def row(p):
    p=Path(p).resolve(strict=True);safety.assert_no_reparse(p)
    return {'path':str(p),'bytes':p.stat().st_size,'sha256':sha(p)}


def save(p,data):
    with p.open('xb') as f:f.write((json.dumps(data,indent=2)+'\n').encode())


def pinned(p,expected):
    safety.assert_no_reparse(p);need(sha(p)==expected,'Pinned source/proof changed: '+str(p));return row(p)


def program_fields(fields):
    return {k:fields[k] for k in ['Platforms','Offsets_AssetList_AssetList_UInt32','CompressedLengths_AssetList_AssetList_UInt32','DecompressedLengths_AssetList_AssetList_UInt32','compressedBlob']}


def prepare():
    pins=[pinned(PREVIOUS/'report.json','e99d06254cd16e817a20e19cedecbedf8005c19608d7141d80461a9b9c6c8f97'),
          pinned(OLD/'run-report.json','bbdd553e0ea025e3ed49de2ec8f60b3b4dd0538e258a3b120aa7856f22475051'),
          pinned(OLD/'Conversion/report.json','db3e2acdc5b03aae8eaa702aa751bb557bb05b95a3a10e0fde2c604337a36551'),
          pinned(DEPENDENCY,'3854edc3af40c1a960be8cba45e3b8c483cb724061bcaf00d5573c081b33d9f1')]
    agpin=pinned(AG,'b7a537500bf6b84af05ea8c49110b291f1fb3d7e26eab787d0be2f3bd0433074')
    agmodel=pinned(AG_MODEL,'3c77fde3c14f517ec64c64e49194d372f4f884e11e5b4bcdc2caf60883f0f7b3');pins.append(agmodel)
    fallbackpin=pinned(OLD/'OriginalReleaseShader.bin','9d68229325a824a746e3dcdca644dc7d5eb9c3677d724b118697785d8c714300')
    agfields=program_fields(json.loads(AG_MODEL.read_bytes())['fields'])
    fallbackfields=json.loads((OLD/'Conversion/report.json').read_bytes())['original_program_fields']
    stamp=dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]
    out=ROOT/'AssetRecovery'/('OriginalAGFallbackEditorConversion-'+stamp);out.mkdir()
    inputs=[]
    for key,pin,pathid,name,fields,deps in [('AG',agpin,6351,'AG/Standard-Opaque',agfields,[{'file_id':1,'path_id':32}]),
         ('Fallback',fallbackpin,32,'Hidden/Universal Render Pipeline/FallbackError',fallbackfields,[])]:
        target=out/(key+'-OriginalRelease.bin');shutil.copyfile(pin['path'],target);need(sha(target)==pin['sha256'],'Original release copy changed')
        inputs.append({**row(target),'key':key,'path_id':pathid,'name':name,'blob_bytes':fields['compressedBlob']['bytes'],
                       'blob_sha256':fields['compressedBlob']['sha256'],'expected_program_fields':fields,
                       'expected_dependencies':deps,'nonmodifiable_texture_count':0,'shader_is_baked':True})
    source=out/'ConvertOriginalShaderPairToEditor.cs';shutil.copyfile(HERE/source.name,source)
    output=out/'OriginalShaderObjectProbe.dll';rsp=out/'compile.rsp';text=(PREVIOUS/'compile.rsp').read_text()
    text,count=re.subn(r'(?m)^/out:.*$',lambda _: '/out:"'+str(output)+'"',text);need(count==1,'Existing Csc output anchor required')
    old='"'+str(HERE/'OriginalShaderObjectProbe.cs')+'"';need(text.count(old)==1,'Existing Csc source anchor required');text=text.replace(old,'"'+str(source)+'"');rsp.write_text(text,encoding='utf-8',newline='\n')
    runtime=[]
    for p in sorted(PREVIOUS.glob('*.dll')):
        if p.name==output.name:continue
        target=out/p.name;shutil.copyfile(p,target);need(sha(p)==sha(target),'Pinned runtime dependency copy changed');runtime.append(row(target))
    for suffix in ('.runtimeconfig.json','.deps.json'):
        p=(PREVIOUS/'OriginalShaderObjectProbe.dll').with_suffix(suffix);target=output.with_suffix(suffix);shutil.copyfile(p,target);runtime.append(row(target))
    references=[row(Path(p)) for p in re.findall(r'(?m)^/reference:"([^"]+)"$',text)]
    spec=out/'two-shader-inputs.json';save(spec,{'shaders':inputs})
    plan={'schema':'prepared-original-AG-fallback-generated-Editor-conversion/v1','status':'prepared_no_child_started',
          'fixture':str(out),'source':row(source),'response':row(rsp),'output':str(output),'spec':row(spec),'inputs':inputs,'proofs':pins,
          'runtime':runtime,'references':references,'runner':row(Path(__file__)),'launcher':pinned(HERE/'owned_suspended_launch.py','3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'),
          'dotnet':row(Path('C:/Program Files/dotnet/dotnet.exe')),'compiler':row(Path('C:/Program Files/dotnet/sdk/10.0.402/Roslyn/bincore/csc.dll')),
          'cap_bytes':CAP,'reserve_bytes':RESERVE,'Main_modified':False,'Unity_launched':False,'external_IDs_remapped':False,
          'dependency_basis':'Original resources.assets Class48 Path6351 has PPtr_Shader_5 FileID1 PathID32. External row1 names globalgamemanagers.assets; exact destination Class48 Path32 is the independently proved fallback input. Original external row and IDs remain unmodified in this pure object conversion.'}
    path=out/'plan.json';save(path,plan)
    print(json.dumps({'status':plan['status'],'plan':row(path),'command':['python','-B',str(Path(__file__)),'--plan',str(path),'--plan-sha256',sha(path),'--run']}))


def bounded(command,cwd,label,receipt,env=None):
    need(memory().available_commit>=CAP+RESERVE,'512MiB owned job +1.5GiB global reserve admission refused')
    need(shutil.disk_usage(cwd).free>=4*1024**3,'Disk reserve refused')
    job=ChildJob();limits=ExtendedJob();limits.basic.flags=0x2000|0x200;limits.job_memory=CAP
    need(job.kernel.SetInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits)),'Cannot set owned job cap')
    child=None;phase={'phase':label,'command':command,'cap_bytes':CAP,'reserve_bytes':RESERVE,'timeout_seconds':90};receipt['phases'].append(phase)
    try:
        with (cwd/(label+'-stdout.log')).open('xb') as stdout,(cwd/(label+'-stderr.log')).open('xb') as stderr:
            child,phase['launcher']=launch_suspended_in_job(command,job=job,cwd=cwd,stdout=stdout,stderr=stderr,env=env);start=time.monotonic()
            while child.poll() is None:
                need(time.monotonic()-start<90 and memory().available_commit>=RESERVE,'Owned pure converter memory/time guard');time.sleep(.1)
        phase['exit_code']=child.returncode
        q=job.kernel.QueryInformationJobObject;q.argtypes=[ctypes.c_void_p,ctypes.c_int,ctypes.c_void_p,ctypes.c_uint32,ctypes.c_void_p];q.restype=ctypes.c_int
        v=ExtendedJob();need(q(job.handle,9,ctypes.byref(v),ctypes.sizeof(v),None),'Cannot query owned peak');phase['peak_job_bytes']=int(v.peak_job)
        need(child.returncode==0,'Pure converter phase failed: '+label)
    finally:
        job.close()
        if child is not None:phase['owned_child_exit_confirmed']=child.wait(timeout=10) is not None


def run(path,digest,execute):
    need(sha(path)==digest,'Reviewed two-shader plan hash changed');safety.assert_no_reparse(path)
    plan=json.loads(path.read_bytes());out=Path(plan['fixture']).resolve(strict=True)
    need(out.is_relative_to(ROOT/'AssetRecovery') and out.name.startswith('OriginalAGFallbackEditorConversion-') and path.parent.resolve()==out,'Exact pure conversion workspace required')
    pins=[plan[k] for k in ('source','response','spec','runner','launcher','dotnet','compiler')]+plan['inputs']+plan['proofs']+plan['runtime']+plan['references']
    for p in pins:need(row(Path(p['path']))=={k:p[k] for k in ('path','bytes','sha256')},'Pinned conversion input changed')
    if not execute:print(json.dumps({'status':'verified_no_child_started','plan_sha256':digest}));return 0
    output=Path(plan['output']);need(not output.exists() and not(out/'Converted').exists(),'Fresh converter outputs required')
    receipt={'schema':'guarded-original-AG-fallback-generated-Editor-conversion/v1','status':'starting','plan':row(path),'phases':[],
             'Main_modified':False,'Unity_launched':False,'native_API_or_game_code_executed':False,'external_IDs_remapped':False}
    try:
        bounded([plan['dotnet']['path'],plan['compiler']['path'],'/noconfig','@'+plan['response']['path']],out,'compile-pure-model-converter',receipt)
        home=out/'DotnetHome';home.mkdir();env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1',DOTNET_CLI_TELEMETRY_OPTOUT='1',DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1',DOTNET_NOLOGO='1',DOTNET_CLI_HOME=str(home))
        bounded([plan['dotnet']['path'],str(output),plan['spec']['path'],str(out/'Converted')],out,'generated-two-shader-roundtrip',receipt,env)
        results={}
        for original in plan['inputs']:
            key=original['key'];folder=out/'Converted'/key;report=json.loads((folder/'report.json').read_bytes());source=Path(original['path']).read_bytes();release=(folder/'ReleaseReserialized.bin').read_bytes();editor=(folder/'EditorShaderObject.bin').read_bytes()
            need(report['status']=='exact_except_proven_leading_NamedObject_normalization' and report['source_sha256']==original['sha256']
                 and report['release_consumed_bytes']==len(source) and report['editor_consumed_bytes']==len(editor) and sha(folder/'EditorShaderObject.bin')==report['editor_sha256'], 'Exact source and Editor full consumption failed')
            a,b=struct.unpack_from('<i',source)[0],struct.unpack_from('<i',release)[0];oldend,newend=(4+a+3)&~3,(4+b+3)&~3
            need(a==0 and release[4:4+b]==original['name'].encode() and source[oldend:]==release[newend:] and len(release)-len(source)==newend-oldend,'Independent every-byte-after-name proof failed')
            need(report['original_program_fields']==original['expected_program_fields'] and sha(folder/'OriginalCompiledBlob.bin')==original['blob_sha256'],'Original program arrays/blob not exact')
            typed=report['typed_source_dependencies'];deps=typed['dependencies']
            need([{k:p[k] for k in ('file_id','path_id')} for p in deps]==original['expected_dependencies'] and all(p['concrete_type']=='AssetRipper.SourceGenerated.Subclasses.PPtr_Shader.PPtr_Shader_5' for p in deps)
                 and typed['nonmodifiable_texture_count']==0 and typed['shader_is_baked'] is True and report['typed_dependencies_equal'],'Typed source dependency namespace changed')
            need(report['entire_ParsedForm_equal'] and report['all_five_original_program_fields_equal'] and report['all_bytes_after_aligned_NamedObject_equal'] and report['external_IDs_remapped'] is False,'Semantic conversion proof failed')
            results[key]={'report':row(folder/'report.json'),'editor_payload':row(folder/'EditorShaderObject.bin'),'normalized_release':row(folder/'ReleaseReserialized.bin'),
                          'compiled_blob':row(folder/'OriginalCompiledBlob.bin'),'ParsedForm':row(folder/'ParsedForm.yaml'),'typed_source_dependencies':typed,
                          'independent_after_name_bytes_equal':True,'normalized_name_byte_delta':newend-oldend}
        receipt.update(status='both_original_shaders_exact_after_NamedObject_with_typed_dependencies_preserved',results=results,converter=row(output))
    except BaseException as error:receipt.update(status='failed_or_guard_refused',error=str(error))
    finally:
        save(out/'run-report.json',receipt)
        print(json.dumps({'status':receipt['status'],'report':row(out/'run-report.json'),'results':receipt.get('results'),'error':receipt.get('error')}))
    return 0 if receipt['status']=='both_original_shaders_exact_after_NamedObject_with_typed_dependencies_preserved' else 1


def main():
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--plan',type=Path);parser.add_argument('--plan-sha256');parser.add_argument('--run',action='store_true');a=parser.parse_args()
    if a.plan:need(a.plan_sha256 is not None,'Explicit reviewed plan hash required');return run(a.plan,a.plan_sha256,a.run)
    need(not a.run,'Prepare the bounded proof first');prepare()


if __name__=='__main__':raise SystemExit(main())
