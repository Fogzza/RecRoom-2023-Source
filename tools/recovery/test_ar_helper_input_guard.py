"""Pure-Python, isolated fixtures for the six unchanged AR Editor inputs.

Synthetic compiler/gate files model deployment structure only. They are not
compile evidence. No Editor, managed/game code, Main writes, or deploy apply.
"""
from pathlib import Path
import datetime as dt, hashlib, importlib.util, json, sys, uuid

WS=Path(__file__).resolve().parents[3]
ROOT=WS/'Recovery/RecRoom-2023-04-18'
sys.path[:0]=[str(ROOT/'Tools'),str(WS/'Tools/RecoveryTools')]
MANIFEST=ROOT/'CompilerRepairs/ARHelperInputGuard-20261022T180324Z-9be2a650/manifest.json'
MANIFEST_SHA='f7eef1182de367edbf449ee2a3fc65456ec5ab2697277ecb70f4c7bbe2b7ea1a'
STATUS='all_used_reflection_and_shader_registration_APIs_present_and_accessible'
NAMES=('AudioMixerPostprocessor.cs','AvoidSavingYamlShaders.cs','YamlShaderPostprocessor.cs')

def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def need(c,s):
    if not c:raise ValueError(s)
def save(p,v):
    p.parent.mkdir(parents=True,exist_ok=True)
    p.write_text(json.dumps(v,indent=2)+'\n',encoding='utf-8')
def ref(p):return {'path':str(p),'sha256':sha(p)}
def refusal(action,expected):
    try:action()
    except ValueError as e:
        need(expected in str(e),'Wrong refusal: '+str(e));return str(e)
    raise ValueError('Expected refusal was not raised: '+expected)

def fixture(parent,label,module,mode):
    folder=parent/label;evidence=folder/'Recovery';project=folder/'Project'
    helpers=[]
    for i,name in enumerate(NAMES):
        source=project/'Assets/Editor/AssetRipperPatches'/name
        source.parent.mkdir(parents=True,exist_ok=True)
        source.write_text('// Inert helper fixture '+name+'\n',encoding='utf-8')
        meta=source.with_name(name+'.meta')
        meta.write_text('fileFormatVersion: 2\nguid: '+format(i+1,'032x')+'\n',encoding='utf-8')
        helpers.append({**ref(source),'meta':str(meta),'meta_sha256':sha(meta)})
    api=evidence/'Validation/synthetic-api-audit.json'
    save(api,{'synthetic_fixture_not_real_API_or_compile_evidence':True,'status':STATUS,'unchanged_Main_helpers':helpers})
    runtime=project/'Assets/FixtureRuntimeInput.txt';runtime.write_text('unchanged runtime input\n')
    unchanged=[ref(runtime)]
    d=module.deploy;old=(module.PROJECT,module.AR_EDITOR_HELPER_AUDIT,d.ROOT,d.WORKSPACE,d.PROJECT)
    try:
        module.PROJECT=project;module.AR_EDITOR_HELPER_AUDIT=ref(api)
        d.ROOT=evidence;d.WORKSPACE=folder;d.PROJECT=project
        result={'case':label,'synthetic_only':True,'helper_inputs_initially_absent_from_harness_inventory':True}
        if mode=='drift_before_prepare':
            Path(helpers[0]['path']).write_text('// independently changed helper\n')
            result['refusal']=refusal(lambda:module.append_audited_AR_editor_inputs(unchanged),'Audited untouched AR Editor helper input drifted')
            return result
        if mode=='duplicate':unchanged.append({**ref(Path(helpers[0]['path']))})
        if mode=='conflict':
            unchanged.append({'path':helpers[0]['path'],'sha256':'0'*64})
            result['refusal']=refusal(lambda:module.append_audited_AR_editor_inputs(unchanged),'Conflicting unchanged-input hash')
            return result
        if mode=='wrong_path':
            alternate=project/'Assets/Elsewhere'/NAMES[0];alternate.parent.mkdir(parents=True);alternate.write_bytes(Path(helpers[0]['path']).read_bytes())
            alternate_meta=alternate.with_name(alternate.name+'.meta');alternate_meta.write_bytes(Path(helpers[0]['meta']).read_bytes())
            altered=json.loads(api.read_bytes());altered['unchanged_Main_helpers'][0].update(path=str(alternate),meta=str(alternate_meta))
            save(api,altered);module.AR_EDITOR_HELPER_AUDIT=ref(api)
            result['refusal']=refusal(lambda:module.append_audited_AR_editor_inputs(unchanged),'Unexpected audited helper source/meta path')
            return result
        gate=module.append_audited_AR_editor_inputs(unchanged)
        need(len(unchanged)==7 and len({r['path'].casefold() for r in unchanged})==7,'Six exact helper inputs plus unrelated runtime input required')
        need(unchanged[0]==ref(runtime),'Unrelated runtime record changed')
        need(gate['sha256']==sha(api) and gate['checks']==[{'selector':['status'],'equals':STATUS}],'API audit gate must remain hash pinned')
        # An inert single-file transaction exercises production preflight only.
        target=project/'Assets/FixtureReplace.txt';target.write_text('old\n')
        candidate=folder/'Candidate.txt';candidate.write_text('new\n')
        compiled=evidence/'synthetic-csc.json'
        save(compiled,{'synthetic_only_not_compilation_evidence':True,'status':'compiled','exit_code':0,'unique_errors':0,'game_code_executed':False})
        other=evidence/'synthetic-metadata-gate.json';save(other,{'synthetic_only':True,'status':'passed'})
        plan=evidence/'CompilerRepairs/manifest.json'
        save(plan,{'schema':'rr23-compile-repair-deployment/v1','project':str(project),'compile_report':ref(compiled),'integration_gates':[gate,{**ref(other),'checks':[{'selector':['status'],'equals':'passed'}]}],'files':[{'project_relative_path':'Assets/FixtureReplace.txt','candidate_path':str(candidate),'candidate_sha256':sha(candidate),'original_sha256':sha(target)}],'unmodified_project_inputs':unchanged})
        d.preflight(plan)
        if mode in ('success','duplicate'):
            result.update(preflight_passed=True,guarded_helper_source_and_meta_inputs=6,identical_existing_input_deduplicated=mode=='duplicate')
        elif mode in ('source_drift','meta_drift'):
            changed=Path(helpers[1]['path'] if mode=='source_drift' else helpers[1]['meta'])
            changed.write_bytes(changed.read_bytes()+b'// external edit\n')
            result['refusal']=refusal(lambda:d.preflight(plan),'Unchanged compiler input drifted')
        elif mode=='audit_drift':
            api.write_bytes(api.read_bytes()+b'\n')
            result['refusal']=refusal(lambda:d.preflight(plan),'Pinned proof changed')
        else:raise ValueError('Unknown fixture mode')
        need(target.read_text()=='old\n','Preflight unexpectedly applied a target')
        return result
    finally:
        module.PROJECT,module.AR_EDITOR_HELPER_AUDIT,d.ROOT,d.WORKSPACE,d.PROJECT=old

def main():
    need(sha(MANIFEST)==MANIFEST_SHA,'Pinned candidate manifest drift')
    manifest=json.loads(MANIFEST.read_bytes())
    for key in ('candidate','backup','exact_diff','API_audit'):
        need(sha(manifest[key]['path'])==manifest[key]['sha256'],'Pinned candidate input drift: '+key)
    original_before=sha(manifest['original_tool']['path'])
    need(original_before==manifest['original_tool']['sha256'],'Production preparer changed before fixture')
    api=json.loads(Path(manifest['API_audit']['path']).read_bytes())
    actual_inputs=[]
    for row in api['unchanged_Main_helpers']:
        for path,h in ((row['path'],row['sha256']),(row['meta'],row['meta_sha256'])):
            need(sha(path)==h,'Actual audited Main input drift before fixture')
            actual_inputs.append({'path':path,'sha256':h})
    spec=importlib.util.spec_from_file_location('ar_helper_preparer_fixture',manifest['candidate']['path'])
    module=importlib.util.module_from_spec(spec);spec.loader.exec_module(module)
    out=ROOT/'Validation'/('ARHelperInputGuardFixtures-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    modes=('success','duplicate','conflict','drift_before_prepare','source_drift','meta_drift','audit_drift','wrong_path')
    cases=[fixture(out,mode,module,mode) for mode in modes]
    need(sha(manifest['original_tool']['path'])==original_before,'Production preparer changed during fixture')
    need(sha(manifest['candidate']['path'])==manifest['candidate']['sha256'],'Frozen candidate changed')
    for row in actual_inputs:need(sha(row['path'])==row['sha256'],'Actual Main helper/meta changed during fixture')
    report={'schema':'isolated-Python-AR-Editor-helper-unchanged-input-guard-fixtures/v1','status':'passed','candidate_manifest':ref(MANIFEST),'candidate':manifest['candidate'],'cases':cases,'controls':len(cases),'actual_audited_Main_inputs_verified_unchanged':actual_inputs,'production_preparer_modified':False,'Main_modified':False,'Editor_managed_or_game_code_executed':False,'deploy_apply_executed':False,'synthetic_compile_gates_not_claimed_as_actual_compilation':True}
    path=out/'report.json';save(path,report)
    print(json.dumps({'report':str(path),'sha256':sha(path),'status':'passed','controls':len(cases)}))

if __name__=='__main__':main()
