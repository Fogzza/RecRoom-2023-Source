"""Inert Python/file fixtures for the reviewed deployment candidate.

All projects, source text and gates below are synthetic and outside Main. They
are not compilation/game evidence. The reparse case supplies a fresh simulated
Windows FILE_ATTRIBUTE_REPARSE_POINT observation to the real guard; it creates
no symlink/junction and executes no Editor/game/managed code.
"""
from pathlib import Path
import contextlib, datetime as dt, importlib.util, io, json, os, sys, types, uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(ROOT/'Tools'))
from audit_accessor_error_projection_static import sha

MANIFEST=ROOT/'CompilerRepairs/DeploymentTransactionHardening-20261022T175250Z-93fb91f6/manifest.json'
def need(c,s):
    if not c:raise ValueError(s)
def save(p,value):p.parent.mkdir(parents=True,exist_ok=True);p.write_text(json.dumps(value,indent=2)+'\n')
def ref(p):return {'path':str(p),'sha256':sha(p)}

def run_case(parent,label,tool,mode):
    folder=parent/label;folder.mkdir();project=folder/'SyntheticProject';evidence=folder/'Recovery';candidates=folder/'Candidates';targets=[];files=[];compiler_replacements=[];originals={};expected={}
    for n in range(2):
        rel=Path('Assets')/(f'Fixture{n}.cs');target=project/rel;candidate=candidates/rel;target.parent.mkdir(parents=True,exist_ok=True);candidate.parent.mkdir(parents=True,exist_ok=True)
        target.write_text(f'// Inert transaction fixture original {n}\n');candidate.write_text(f'// Inert transaction fixture candidate {n}\n');target.with_name(target.name+'.meta').write_text('fileFormatVersion: 2\nguid: '+format(n+1,'032x')+'\n');targets.append(target)
        originals[str(target)]=target.read_bytes();expected[str(target)]=candidate.read_bytes();files.append({'project_relative_path':rel.as_posix(),'candidate_path':str(candidate),'candidate_sha256':sha(candidate),'original_sha256':sha(target)})
        compiler_replacements.append({'source':str(target),'source_sha256':sha(target),'candidate':str(candidate),'candidate_sha256':sha(candidate)})
    compiled=evidence/'synthetic-compiler-gate.json';save(compiled,{'synthetic_fixture_only_not_real_compilation':True,'status':'compiled','exit_code':0,'unique_errors':0,'game_code_executed':False,'replacements':compiler_replacements})
    gates=[]
    for n in range(2):
        path=evidence/f'synthetic-gate{n}.json';save(path,{'synthetic_fixture_only':True,'status':'passed'});gates.append({**ref(path),'checks':[{'selector':['status'],'equals':'passed'}]})
    plan=evidence/'CompilerRepairs/manifest.json';save(plan,{'schema':'rr23-compile-repair-deployment/v1','project':str(project),'compile_report':ref(compiled),'integration_gates':gates,'files':files,'unmodified_project_inputs':[]})
    spec=importlib.util.spec_from_file_location('fixture_deploy_'+uuid.uuid4().hex,tool);module=importlib.util.module_from_spec(spec);spec.loader.exec_module(module)
    module.ROOT=evidence;module.WORKSPACE=folder;module.PROJECT=project
    original_closed=module.safety.assert_editor_closed;original_lstat=module.safety.os.lstat;original_replace=module.os.replace
    state={'closed_checks':0,'reparse_armed':False,'external_write_injected':False};external=b'// Independently edited after this target was installed\n';parent_path=project/'Assets'
    def closed():
        state['closed_checks']+=1
        if mode=='reparse' and state['closed_checks']==2:state['reparse_armed']=True
        return {'synthetic_fixture_editor_guard':True,'actual_Editor_inspected_or_modified':False}
    def lstat(path,*args,**kwargs):
        result=original_lstat(path,*args,**kwargs)
        if state['reparse_armed'] and os.path.abspath(path).casefold()==str(parent_path).casefold():
            return types.SimpleNamespace(st_mode=result.st_mode,st_file_attributes=getattr(result,'st_file_attributes',0)|0x400)
        return result
    def replace(source,target,*args,**kwargs):
        result=original_replace(source,target,*args,**kwargs)
        if mode=='external_write' and Path(target)==targets[1]:
            targets[0].write_bytes(external);state['external_write_injected']=True
        return result
    failure=None;output=io.StringIO()
    try:
        module.safety.assert_editor_closed=closed;module.safety.os.lstat=lstat;module.os.replace=replace
        with contextlib.redirect_stdout(output):
            try:module.run(plan,True)
            except BaseException as error:failure=repr(error)
    finally:
        module.safety.assert_editor_closed=original_closed;module.safety.os.lstat=original_lstat;module.os.replace=original_replace
    reports=list((evidence/'CompilerRepairs').glob('AppliedCompilePackage-*/report.json'));need(len(reports)==1,'Exactly one isolated deployment receipt');receipt=json.loads(reports[0].read_text())
    result={'case':label,'mode':mode,'receipt':ref(reports[0]),'reported_status':receipt['status'],'failure':failure,'synthetic_only':True,'new_files_written_only_under_test_root':str(folder),'state':state}
    if mode=='success':
        need(failure is None and receipt['status']=='applied' and all(p.read_bytes()==expected[str(p)] for p in targets),'Successful exact package transaction failed');result['all_target_final_hashes_match']=True
    elif mode=='external_write' and label.startswith('original'):
        need(failure is None and receipt['status']=='applied' and targets[0].read_bytes()==external and targets[1].read_bytes()==expected[str(targets[1])],'Original final-rehash omission was not reproduced');result['original_gap_reproduced']=True
    elif mode=='external_write':
        need(failure is not None and receipt['status']=='failed' and receipt.get('rollback_blocked') is True and targets[0].read_bytes()==external and targets[1].read_bytes()==originals[str(targets[1])],'Hardened final check failed to preserve independent edit/refuse unsafe rollback');result.update(external_edit_preserved=True,other_target_safely_rolled_back=True,success_not_falsely_reported=True)
    elif mode=='reparse':
        need(failure is not None and receipt['status']=='failed' and receipt.get('project_modified') is False and all(p.read_bytes()==originals[str(p)] for p in targets),'Fresh parent reparse guard did not prevent target writes');result.update(fresh_parent_reparse_attribute_observation_rejected=True,actual_reparse_or_junction_created=False,all_target_original_bytes_preserved=True)
    result['meta_GUID_bytes_preserved']=all(p.with_name(p.name+'.meta').read_text().splitlines()[1]=='guid: '+format(n+1,'032x') for n,p in enumerate(targets));need(result['meta_GUID_bytes_preserved'],'Synthetic script meta unexpectedly changed')
    return result

def main():
    need(sha(MANIFEST)=='956bac1634edda2c5f9d7fcc4c46db70505869222c5c268fdd3e9b02801e3ec6','Prepared hardening manifest changed');m=json.loads(MANIFEST.read_text())
    for key in ('original_tool','backup','candidate','exact_diff'):need(sha(m[key]['path'])==m[key]['sha256'],'Pinned hardening input drift: '+key)
    out=ROOT/'Validation'/('DeploymentTransactionFixtures-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();results=[]
    for label,tool,mode in [('original_gap_control',Path(m['backup']['path']),'external_write'),('hardened_success',Path(m['candidate']['path']),'success'),('hardened_external_edit',Path(m['candidate']['path']),'external_write'),('hardened_reparse_parent',Path(m['candidate']['path']),'reparse')]:results.append(run_case(out,label,tool,mode))
    need(sha(m['original_tool']['path'])==m['original_tool']['sha256'],'Production tool unexpectedly modified')
    report={'schema':'isolated-Python-compile-deployment-final-state-and-reparse-controls/v1','status':'passed','candidate_manifest':ref(MANIFEST),'cases':results,'actual_Main_or_production_tool_modified':False,'actual_game_code_Editor_or_managed_code_executed':False,'all_gate_and_source_files_are_inert_test_fixtures_not_actual_compile_evidence':True,'reparse_control':'fresh synthetic FILE_ATTRIBUTE_REPARSE_POINT supplied to actual production no-reparse guard; no actual junction created'}
    p=out/'report.json';save(p,report);print(json.dumps({'report':str(p),'sha256':sha(p),'status':report['status'],'controls':len(results)}))

if __name__=='__main__':main()
