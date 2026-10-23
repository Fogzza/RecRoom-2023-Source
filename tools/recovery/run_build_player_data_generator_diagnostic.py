"""Prepare, or explicitly run, the installed Unity metadata generator alone.

The original response bytes change only at their one -o argument. No Editor,
game entry point, SDK API, scene, ProjectSettings or Main source is invoked or
written by this driver. The trusted installed tool still inspects game metadata.
"""
import argparse,ctypes,datetime as dt,hashlib,json,os,re,shutil,subprocess,sys,time,uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';PROJECT=WS/'RR23'
EDITOR=WS/'Tools/Editors/2020.3.33f1/Editor';TOOL=EDITOR/'Data/Tools/BuildPlayerDataGenerator/BuildPlayerDataGenerator.exe'
sys.path.insert(0,str(ROOT/'Tools'))
from exact_handle_hash import sha
from export_bundle_batches import ChildJob,ExtendedJob
from guarded_cpp2il import memory
import repair_rr23_wav_headers as safety
GIB=1024**3;CAP=2560*1024**2;RESERVE=int(1.5*GIB)
DEFAULT_RESPONSE=PROJECT/'Library/BuildPlayerData/response.rsp'

def need(x,s):
    if not x:raise ValueError(s)
def pinned(p):return {'path':str(p),'sha256':sha(p),'bytes':p.stat().st_size}
def safe(p):safety.assert_no_reparse(p)
def pathkey(p):return os.path.normcase(os.path.abspath(p)).casefold()
def parse_response(data):
    need(len(data)<1024*1024 and b'\x00' not in data,'Bounded text response required')
    text=data.decode('utf-8-sig');rows=[]
    for line in text.splitlines(keepends=True):
        m=re.fullmatch(r'(-a|-s|-o|-rn|-tn)="([^"\r\n]*)"(\r?\n)?',line)
        need(m is not None,'Unknown or malformed generator argument')
        rows.append({'flag':m[1],'value':m[2],'line':line})
    need(sum(r['flag']=='-o' for r in rows)==1 and sum(r['flag']=='-rn' for r in rows)==1 and sum(r['flag']=='-tn' for r in rows)==1,'One output/report/type argument required')
    need(next(r['value'] for r in rows if r['flag']=='-rn')=='' and next(r['value'] for r in rows if r['flag']=='-tn')=='TypeDb-All.json','Preserve original generator report/type output names')
    need(any(r['flag']=='-a' for r in rows) and any(r['flag']=='-s' for r in rows),'Original assembly/search inventory required')
    return rows
def rewrite_only_output(data,target):
    rows=parse_response(data);result=[]
    for r in rows:
        if r['flag']=='-o':
            ending='\r\n' if r['line'].endswith('\r\n') else '\n' if r['line'].endswith('\n') else ''
            result.append('-o="'+str(target)+'"'+ending)
        else:result.append(r['line'])
    encoded=''.join(result).encode('utf-8')
    if data.startswith(b'\xef\xbb\xbf'):encoded=b'\xef\xbb\xbf'+encoded
    after=parse_response(encoded)
    need(len(after)==len(rows) and all(a['line']==b['line'] for a,b in zip(rows,after) if a['flag']!='-o'),'Non-output response bytes changed')
    return encoded
def inventory(data):
    rows=parse_response(data)
    approved_search={pathkey(p) for p in [EDITOR/'Data/Managed/UnityEngine',PROJECT/'Library/ScriptAssemblies',PROJECT/'Assets/Plugins',EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api',EDITOR/'Data/MonoBleedingEdge/lib/mono/4.7.1-api/Facades']}
    approved_assembly_roots=[PROJECT/'Assets/Plugins',PROJECT/'Library/ScriptAssemblies',PROJECT/'Library/PlayerScriptAssemblies']
    files={};dirs={}
    for r in rows:
        if r['flag'] not in ('-a','-s'):continue
        p=Path(r['value']);need(p.is_absolute() and '..' not in p.parts,'Exact absolute generator input required');safe(p)
        if r['flag']=='-a':
            need(p.suffix.lower()=='.dll' and p.is_file() and any(p.parent==root for root in approved_assembly_roots),'Unexpected explicit assembly input')
            files[pathkey(p)]=p
        else:
            need(pathkey(p) in approved_search and p.is_dir(),'Unexpected generator search directory')
            key=pathkey(p)
            if key in dirs:continue
            members=[]
            # Pin every immediate file available to the original finite search,
            # including symbols/configuration. Never recurse into other trees.
            for q in sorted(p.iterdir()):
                safe(q)
                if q.is_file():files[pathkey(q)]=q;members.append(q.name)
            dirs[key]={'path':str(p),'immediate_files':members}
    for p in sorted(TOOL.parent.iterdir()):
        safe(p)
        if p.is_file():files[pathkey(p)]=p
    for p in [Path(__file__),ROOT/'Tools/exact_handle_hash.py',ROOT/'Tools/export_bundle_batches.py',ROOT/'Tools/guarded_cpp2il.py',ROOT/'Tools/repair_rr23_wav_headers.py']:
        files[pathkey(p)]=p
    need(len(files)<2048,'Unbounded generator input inventory')
    return {'files':[pinned(p) for _,p in sorted(files.items())], 'search_directories':list(dirs.values()),'explicit_assembly_count':sum(r['flag']=='-a' for r in rows),'search_argument_count':sum(r['flag']=='-s' for r in rows)}
def verify_files(plan):
    safe(DEFAULT_RESPONSE);need(sha(DEFAULT_RESPONSE)==plan['original_response']['sha256'],'Original Main response changed')
    for r in plan['input_inventory']['search_directories']:
        p=Path(r['path']);safe(p)
        current=[]
        for q in sorted(p.iterdir()):
            safe(q)
            if q.is_file():current.append(q.name)
        need(current==r['immediate_files'],'Original search file set changed: '+str(p))
    for r in plan['input_inventory']['files']:need(sha(Path(r['path']))==r['sha256'],'Pinned metadata/tool input changed: '+r['path'])
def prepare():
    safety.assert_editor_closed();safe(DEFAULT_RESPONSE);safe(TOOL)
    original=DEFAULT_RESPONSE.read_bytes();rows=parse_response(original)
    need(next(r['value'] for r in rows if r['flag']=='-o')==str(PROJECT/'Library/BuildPlayerData/Editor'),'Original Editor-layout output differs; review the actual response')
    inv=inventory(original)
    out=ROOT/'Validation'/('BuildPlayerDataGeneratorIsolated-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);safe(out);out.mkdir()
    target=out/'Generated';response=out/'response.rsp';response.write_bytes(rewrite_only_output(original,target));(out/'original-response.rsp').write_bytes(original)
    plan={'schema':'installed-Unity2020-isolated-metadata-generator-plan/v1','status':'prepared_not_launched','project':str(PROJECT),'tool':pinned(TOOL),'runner':pinned(Path(__file__)),'original_response':pinned(DEFAULT_RESPONSE),'original_snapshot':pinned(out/'original-response.rsp'),'response':pinned(response),'output':str(target),'working_directory':str(out),'input_inventory':inv,'command':[str(TOOL),'@'+str(response)],'maximum_seconds':300,'job_cap_bytes':CAP,'minimum_available_commit_bytes':RESERVE,'minimum_disk_bytes':4*GIB,'Editor_or_game_entrypoint_invoked':False,'Main_written':False}
    p=out/'plan.json';p.write_text(json.dumps(plan,indent=2)+'\n');print(json.dumps({'status':plan['status'],'plan':str(p),'sha256':sha(p),'files':len(inv['files']),'assemblies':inv['explicit_assembly_count'],'output_only_rewrite':True,'child_started':False}))
def execute(plan_path,expected):
    safe(plan_path);need(plan_path.is_relative_to(ROOT/'Validation') and sha(plan_path)==expected,'Exact reviewed plan hash/path required')
    plan=json.loads(plan_path.read_bytes());out=plan_path.parent;target=out/'Generated';response=out/'response.rsp'
    need(plan['schema']=='installed-Unity2020-isolated-metadata-generator-plan/v1' and plan['status']=='prepared_not_launched','Original prepared generator plan required')
    need(plan['project']==str(PROJECT) and plan['tool']['path']==str(TOOL) and plan['runner']['path']==str(Path(__file__)),'Fixed project/tool/runner identity')
    need(plan['output']==str(target) and plan['working_directory']==str(out) and plan['command']==[str(TOOL),'@'+str(response)],'Stage-only output/command')
    need(plan['job_cap_bytes']==CAP and plan['minimum_available_commit_bytes']==RESERVE and plan['maximum_seconds']==300,'Reviewed fixed resource limits')
    need(not (out/'run-report.json').exists() and not target.exists(),'One fresh isolated invocation only')
    need(sha(response)==plan['response']['sha256'] and sha(TOOL)==plan['tool']['sha256'] and sha(Path(__file__))==plan['runner']['sha256'],'Reviewed staged command bytes changed')
    need(response.read_bytes()==rewrite_only_output(Path(plan['original_snapshot']['path']).read_bytes(),target),'Only original response output may differ')
    safety.assert_editor_closed();verify_files(plan)
    need(memory().available_commit>CAP+RESERVE,'Isolated generator needs 2.5GiB job +1.5GiB system reserve')
    need(shutil.disk_usage(out).free>4*GIB,'Isolated generator disk reserve')
    safe(target);target.mkdir();report={'schema':'installed-Unity2020-isolated-metadata-generator-run/v1','status':'starting','plan':pinned(plan_path),'samples':[],'Editor_launched':False,'game_or_SDK_method_invocation_requested':False,'Main_written_by_driver':False}
    def save():(out/'run-report.json').write_text(json.dumps(report,indent=2)+'\n')
    child=job=None;started=time.monotonic();save()
    try:
        job=ChildJob();limits=ExtendedJob();limits.basic.flags=0x2000|0x200;limits.job_memory=CAP
        need(job.kernel.SetInformationJobObject(job.handle,9,ctypes.byref(limits),ctypes.sizeof(limits)),'Cannot cap isolated owned job')
        need(memory().available_commit>CAP+RESERVE,'Fresh isolated generator memory admission failed')
        with (out/'generator.stdout.log').open('xb')as stdout,(out/'generator.stderr.log').open('xb')as stderr:
            child=subprocess.Popen(plan['command'],cwd=out,stdout=stdout,stderr=stderr,creationflags=subprocess.CREATE_NO_WINDOW);job.attach(child);report['owned_pid']=child.pid;next_sample=0
            while child.poll() is None:
                elapsed=time.monotonic()-started;available=memory().available_commit
                need(elapsed<300 and available>=RESERVE and shutil.disk_usage(out).free>4*GIB,'Owned generator time/system-memory/disk guard reached')
                if elapsed>=next_sample:
                    info=ExtendedJob();q=job.kernel.QueryInformationJobObject;q.argtypes=[ctypes.c_void_p,ctypes.c_int,ctypes.c_void_p,ctypes.c_uint32,ctypes.c_void_p];q.restype=ctypes.c_int
                    need(q(job.handle,9,ctypes.byref(info),ctypes.sizeof(info),None),'Cannot query owned generator memory')
                    row={'seconds':round(elapsed,2),'available_commit_bytes':available,'peak_job_bytes':int(info.peak_job),'peak_process_bytes':int(info.peak_process)};report['samples'].append(row);save();print(json.dumps(row),flush=True);next_sample=elapsed+2
                time.sleep(.1)
        report['exit_code']=child.returncode;report['status']='tool_exited_zero_outputs_unverified' if child.returncode==0 else 'tool_failed'
    except BaseException as e:report.update(status='guarded_failure_or_refusal',error=repr(e))
    finally:
        if job:job.close()
        if child is not None and child.poll() is None:
            try:child.wait(timeout=15)
            except subprocess.TimeoutExpired:report['owned_child_not_exited_after_job_close']=True
        try:verify_files(plan);report['all_pinned_inputs_unchanged']=True
        except BaseException as e:report.update(status='input_preservation_failed',input_preservation_error=repr(e))
        generated=[]
        for p in sorted(target.rglob('*')):
            safe(p)
            if p.is_file():generated.append(pinned(p))
        report['generated_files']=generated;report['TypeDb_present']=any(Path(r['path']).name=='TypeDb-All.json' for r in generated)
        if report['status']=='tool_exited_zero_outputs_unverified':report['status']='metadata_generated_gameplay_unverified' if report['TypeDb_present'] and all(r['bytes']>0 for r in generated) else 'zero_exit_missing_metadata_output'
        report['seconds']=round(time.monotonic()-started,2);save();print(json.dumps({'status':report['status'],'report':str(out/'run-report.json'),'error':report.get('error')}))
    return 0 if report['status']=='metadata_generated_gameplay_unverified' else 1
def fixtures():
    original=b'-a="C:\\Example\\A.dll"\r\n-s="C:\\Example"\r\n-o="C:\\Old"\r\n-rn=""\r\n-tn="TypeDb-All.json"\r\n'
    changed=rewrite_only_output(original,Path('C:/Stage/Generated'));need(changed.replace(b'-o="C:\\Stage\\Generated"',b'-o="C:\\Old"')==original,'Only output replacement')
    checks=1
    for data in [original+b'-execute="Anything"\r\n',original.replace(b'-tn="TypeDb-All.json"',b'-tn="../Outside.json"'),original.replace(b'-rn=""',b'-rn="outside"'),original+ b'-o="C:\\Other"\r\n',original.replace(b'-a="C:\\Example\\A.dll"',b'-a="bad"\x00')]:
        try:parse_response(data)
        except ValueError:checks+=1
        else:raise ValueError('Malformed response fixture accepted')
    print(json.dumps({'status':'parser_controls_passed','checks':checks,'child_started':False}))
if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--run',action='store_true');p.add_argument('--plan',type=Path);p.add_argument('--plan-sha');p.add_argument('--fixtures',action='store_true');a=p.parse_args()
    if a.fixtures:fixtures()
    elif a.run:
        need(a.plan is not None and a.plan_sha is not None,'Reviewed --plan and --plan-sha required');raise SystemExit(execute(a.plan.absolute(),a.plan_sha))
    else:need(a.plan is None and a.plan_sha is None,'Preparation does not accept arbitrary input plan');prepare()
