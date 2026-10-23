"""Pure source/closure/preparation and fake-job telemetry controls. No Csc/Editor."""
from pathlib import Path
from types import SimpleNamespace
import argparse
import ast
import copy
import json
import re
import run_original_shader_builtin_identity_fixture as fixture

ROOT = fixture.ROOT/'AssetRecovery'
MANIFEST = ROOT/'AllOriginalShaderEditorManifest-20261023T045350Z-9a03b91a/manifest.json'
MANIFEST_SHA = 'a4ff950561f8572c9d0663703b4525957aa5c6053c1c40a1517aa300ff2d4f74'
WRAPPERS = ROOT/'OriginalShaderEditorWrapperCollection-20261023T050017Z-5ed9890d/wrapper-collection.json'
WRAPPERS_SHA = '01fa7e829d8735f8772721b0ef0bea26442ab1ab45b8ca8b6702070e5dcc12b5'
PRISTINE = {
    'BuildOriginalShaderCollectionFixture.cs': '2f8f9d324539d7a8b7cb58fc12c0560b01ab42d0697a46051cf4c889914b70c6',
    'run_original_shader_collection_fixture.py': 'e3dd9995623279d8182ce75aafcfaef24c3bd3822a8b8786b82e4ed850eeb4dd'}


def save(path,data):
    with path.open('x',encoding='utf-8') as stream:
        json.dump(data,stream,indent=2);stream.write('\n')


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--out',required=True,type=Path);args=ap.parse_args()
    out=args.out.resolve(strict=True)
    need=fixture.guard.need
    need(fixture.sha(MANIFEST)==MANIFEST_SHA and fixture.sha(WRAPPERS)==WRAPPERS_SHA,'Exact frozen original inputs required')
    for name,expected in PRISTINE.items():need(fixture.sha(fixture.HERE/name)==expected,'Existing179 tool changed')
    ast.parse(Path(fixture.__file__).read_text())
    manifest,wrappers=json.loads(MANIFEST.read_bytes()),json.loads(WRAPPERS.read_bytes())
    cases=[]
    for alpha,count,total in [(False,7,2751496),(True,8,4289520)]:
        originals,selected=fixture.select_inputs(manifest,wrappers,MANIFEST_SHA,alpha)
        need(len(selected)==count and sum(r['asset']['bytes'] for r in selected)==total,'Exact selected identity count and existing bytes required')
        cases.append({'name':'actual_selected_'+str(count)+'_closure_and_four_builtins','passed':True})
    def reject(name,change):
        m,w=copy.deepcopy(manifest),copy.deepcopy(wrappers);change(m,w)
        try:fixture.select_inputs(m,w,MANIFEST_SHA)
        except (RuntimeError,KeyError) as error:cases.append({'name':name,'passed':True,'rejection':str(error)})
        else:raise RuntimeError('Malformed input accepted: '+name)
    def selected(rows,guid=fixture.SELECTED[0]):return next(r for r in rows if r['guid']==guid)
    reject('wrong_manifest_schema',lambda m,w:m.update(schema='other'))
    reject('wrong_wrapper_binding',lambda m,w:w['manifest'].update(sha256='0'*64))
    reject('missing_original_identity',lambda m,w:m['shaders'].pop())
    reject('duplicate_wrapper_identity',lambda m,w:w['shaders'].__setitem__(0,copy.deepcopy(w['shaders'][1])))
    reject('selected_name_mismatch',lambda m,w:selected(w['shaders']).update(name='other'))
    reject('selected_meta_mismatch',lambda m,w:selected(w['shaders'])['meta'].update(sha256='0'*64))
    reject('selected_dependencies_mismatch',lambda m,w:selected(w['shaders'])['expected_direct_shader_dependencies'].clear())
    reject('oversized_selection',lambda m,w:selected(w['shaders'])['asset'].update(bytes=6*1024**2))
    def bad_dep(m,w,value):
        for data in (m,w):selected(data['shaders'])['expected_direct_shader_dependencies'][0].update(value)
    reject('unknown_builtin_id',lambda m,w:bad_dep(m,w,{'local_file_id':999}))
    reject('wrong_builtin_namespace',lambda m,w:bad_dep(m,w,{'guid':'0'*32}))
    reject('missing_required_46',lambda m,w:[selected(d['shaders'])['expected_direct_shader_dependencies'].pop(0) for d in (m,w)])
    reject('unclosed_project_edge',lambda m,w:bad_dep(m,w,{'kind':'project','guid':next(r['guid'] for r in m['shaders'] if r['guid'] not in fixture.SELECTED),'local_file_id':4800000}))
    reject('wrong_project_local_id',lambda m,w:bad_dep(m,w,{'kind':'project','guid':fixture.SELECTED[3],'local_file_id':1}))
    # A fake job verifies delegation, ordering and closure on query/close errors.
    class FakeJob:
        def __init__(self,events,fail_close=False):self.events,self.fail_close,self.handle=events,fail_close,123
        def attach(self,value):self.events.append(('attach',value))
        def close(self):
            self.events.append('real_close')
            if self.fail_close:raise RuntimeError('real close failure')
    for query_fail,close_fail in [(False,False),(True,False),(False,True),(True,True)]:
        events=[];phase={};job=FakeJob(events,close_fail)
        def query(job):
            need(job.handle==123,'Original owned job identity must be forwarded');events.append('query_before_close')
            if query_fail:raise RuntimeError('query failure')
            return {'peak_job_bytes':321,'peak_process_bytes':123,'available_commit_bytes':456,'captured_immediately_before_owned_job_close':True}
        wrapped=fixture.FinalTelemetryJob(job,lambda:phase,query)
        wrapped.attach('owned-child')
        raised=False
        try:wrapped.close()
        except RuntimeError:raised=True
        need(events==[('attach','owned-child'),'query_before_close','real_close'] and raised==close_fail,'Real owned close exactly once after query; close errors retain semantics')
        need(('query_failed' in phase['final_job_telemetry_before_close'])==query_fail,'Query failure recorded without suppressing real close')
        cases.append({'name':'job_query_fail_'+str(query_fail)+'_close_fail_'+str(close_fail),'passed':True})
    made=[];report={'phases':[{}]}
    original=lambda cap:(made.append(cap) or FakeJob([]))
    wrapped_factory=fixture.telemetry_factory(original,report,lambda job:{'captured_immediately_before_owned_job_close':True})
    wrapped_factory(99).close()
    need(made==[99] and report['phases'][0]['final_job_telemetry_before_close']['captured_immediately_before_owned_job_close'],'Factory preserves cap and current phase')
    cases.append({'name':'telemetry_factory_preserves_original_cap_and_phase','passed':True})
    # Source consistency is a static check; compilation remains Root-only.
    builder=fixture.HERE/'BuildOriginalShaderBuiltinIdentityFixture.cs'
    text=builder.read_text()
    allow=text[text.index('ExpectedGuids'):text.index('[Serializable] public class Dependency')]
    need(set(re.findall(r'"([0-9a-f]{32})"',allow))==set(fixture.SELECTED),'C# and Python reviewed seven-GUID allowlists must match')
    need('const string AlphaClipGuid = "'+fixture.ALPHA_CLIP+'"' in text and 'config.include_alpha_clip ? 8 : 7' in text,'Explicit eighth-GUID flag/count guards required')
    need('Shader.Find' not in text and 'new Material(shader)' in text and 'material.shader == shader' in text,'Builtin Material origin must use actual captured Shader instance')
    cases.append({'name':'CSharp_allowlist_alpha_and_actual_instance_chain_static','passed':True})
    prepared=[]
    for alpha in (False,True):
        a=SimpleNamespace(manifest=MANIFEST,manifest_sha256=MANIFEST_SHA,wrappers=WRAPPERS,wrappers_sha256=WRAPPERS_SHA,include_alpha_clip=alpha)
        path=fixture.prepare(a);plan,project=fixture.verify(path,fixture.sha(path))
        count=8 if alpha else 7
        need(plan['shader_count']==count and plan['include_alpha_clip'] is alpha and plan['cap_bytes']==2*1024**3,'Correct reviewed option/cap required')
        # Verify rejects an extra unpinned file; remove only our exact new marker.
        extra=project/'Unexpected-Offline-Control.txt';extra.write_text('owned pure control',encoding='utf-8')
        try:
            try:fixture.verify(path,fixture.sha(path))
            except RuntimeError:pass
            else:raise RuntimeError('Unpinned fixture input accepted')
        finally:extra.unlink()
        fixture.verify(path,fixture.sha(path))
        cases.append({'name':'prepared_'+str(count)+'_exact_file_inventory_and_extra_file_refusal','passed':True})
        admission={'status':'not_checked'}
        try:
            fixture.guard.admission(project,fixture.CAP)
            admission={'status':'passed','available_commit_bytes':fixture.guard.memory().available_commit,
                       'process_safety':fixture.guard.safety.assert_editor_closed()}
        except RuntimeError as error:admission={'status':'HOLD','reason':str(error)}
        prepared.append({'shader_count':count,'include_alpha_clip':alpha,'plan':fixture.pin(path),'admission_read_only':admission,
            'command':['C:\\Python314\\python.exe','-B',str(Path(fixture.__file__).resolve()),'--fixture',str(path.parent),'--plan-sha256',fixture.sha(path),'--run']})
    for name,expected in PRISTINE.items():need(fixture.sha(fixture.HERE/name)==expected,'Existing179 source changed during pure controls')
    report={'schema':'pure-selected-Shader-builtin-Material-fixture-controls/v1','status':'passed','control_count':len(cases),'controls':cases,
        'runner':fixture.pin(Path(fixture.__file__)),'builder':fixture.pin(builder),'prepared':prepared,'existing179_tools_unchanged':PRISTINE,
        'Main_modified':False,'Unity_launched':False,'compiler_launched':False,'player_launched':False,'CSharp_API_compile_or_native_import_claimed':False}
    save(out/'offline-controls.json',report)
    print(json.dumps({'status':'passed','controls':len(cases),'report':fixture.pin(out/'offline-controls.json'),'prepared':prepared}))


if __name__=='__main__':main()
