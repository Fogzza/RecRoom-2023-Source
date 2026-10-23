"""Pure admission/source/owned-job controls; no actual fixture/native execution."""
from pathlib import Path
import argparse
import ast
import copy
import json
import run_original_shader_null_dependency_fixture as target
import prepare_original_shader_null_dependency_projection as projection

HERE=Path(__file__).resolve().parent
PLAN=projection.AR/'OriginalShaderNullDependencyProjection-20261023T064548Z-76a33043/plan.json'
PLAN_SHA='282903a51ab8da009be418e08a88193830d2d613e7a90e779f5b01d41fd7eb91'


def need(v,message):
    if not v:raise ValueError(message)


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--out',required=True,type=Path);args=ap.parse_args()
    out=args.out.resolve(strict=True)
    need(out.is_relative_to(projection.ROOT/'Validation'),'Recovery-only control outputs')
    need(target.sha(PLAN)==PLAN_SHA,'Actual reviewed projection plan')
    evidence=json.loads(PLAN.read_bytes());manifest=json.loads(Path(evidence['manifest']['path']).read_bytes())
    target.guard.checked(evidence['manifest'])
    project=out/'NeverLaunchedProject'
    rows=[{'path':'Assets/Resources/OriginalShaders/'+r['guid']+'.asset','guid':r['guid'],'dependencies':[],
        'name':r['name'],'sha256':r['source']['sha256'],'meta_sha256':r['meta']['sha256']} for r in manifest['shaders']]
    materials=[copy.deepcopy(r['witness']) for r in evidence['copied_native_Material_sources']]
    config={'project':str(project),'shaders':rows,'include_alpha_clip':True,'Editor_dependency_projection':True,'copied_materials':materials}
    plan={'selected_GUIDs':list(projection.GUIDS),'material_witnesses':copy.deepcopy(materials)}
    target.validate_config(config,plan,project)
    checks=[]
    def reject(name,change,change_plan=False):
        c,p=copy.deepcopy(config),copy.deepcopy(plan)
        change(c,p)
        try:target.validate_config(c,p,project)
        except (RuntimeError,ValueError,KeyError,TypeError):checks.append({'name':name,'rejected':True})
        else:raise AssertionError('Invalid fixture config accepted: '+name)
    reject('wrong project',lambda c,p:c.__setitem__('project',str(projection.ROOT.parents[1]/'RR23')))
    reject('seven not eight',lambda c,p:c['shaders'].pop())
    reject('duplicate Shader GUID',lambda c,p:c['shaders'].__setitem__(-1,copy.deepcopy(c['shaders'][0])))
    reject('Shader order changed',lambda c,p:c['shaders'].reverse())
    reject('unexpected Shader GUID',lambda c,p:c['shaders'][0].__setitem__('guid','0'*32))
    reject('retained project dependency',lambda c,p:c['shaders'][0]['dependencies'].append({'kind':'project','guid':projection.GUIDS[1],'local_file_id':4800000}))
    reject('Shader resource traversal',lambda c,p:c['shaders'][0].__setitem__('path','../RR23/Assets/Shader.asset'))
    reject('projection scope disabled',lambda c,p:c.__setitem__('Editor_dependency_projection',False))
    reject('eighth identity disabled',lambda c,p:c.__setitem__('include_alpha_clip',False))
    reject('missing Material',lambda c,p:c['copied_materials'].pop())
    reject('Material source bytes changed',lambda c,p:c['copied_materials'][0].__setitem__('asset_sha256','0'*64))
    reject('Material meta changed',lambda c,p:c['copied_materials'][0].__setitem__('meta_sha256','0'*64))
    for field,value in [('builtin_guid','1'*32),('builtin_local_id','999'),('material_local_id','1'),('material_source_path','Assets/Unexpected.mat')]:
        def both(c,p,k=field,v=value):
            c['copied_materials'][0][k]=v;p['material_witnesses'][0][k]=v
        reject('unproven '+field+' in both config and plan',both)
    def duplicate(c,p):
        c['copied_materials'][1]=copy.deepcopy(c['copied_materials'][0]);p['material_witnesses']=copy.deepcopy(c['copied_materials'])
    reject('duplicate Material/builtin identity in both config and plan',duplicate)
    old=projection.EIGHT
    try:target.verify(old,target.sha(old),False)
    except RuntimeError:checks.append({'name':'old cyclic fixture cannot be launched by new runner','rejected':True})
    else:raise AssertionError('Old original8 fixture accepted')
    old_runner=HERE/'run_original_shader_builtin_identity_fixture.py'
    old_guard=HERE/'run_windows_development_define_probe.py'
    old_builder=HERE/'BuildOriginalShaderBuiltinIdentityFixture.cs'
    need(target.sha(old_runner)=='1ba8406a60d8ad13daad819240f1717d8ade7bd5a50561b11222c024279a56db'
        and target.sha(old_guard)=='685f87ada7d4c10a09421e11b59466b3e19e817bfdaabd5a233c0192f17529fc'
        and target.sha(old_builder)=='99afdb63efa0579d31330ecd50c0b61c8ece2d9d56e3f8ddd4bdd7a4fffcd24c','Shared original fixture sources/guard unchanged')
    old_ast,new_ast=ast.parse(old_runner.read_text()),ast.parse(Path(target.__file__).read_text())
    for name in ('query_final_job','FinalTelemetryJob','telemetry_factory'):
        def shape(tree):return ast.dump(next(n for n in tree.body if getattr(n,'name',None)==name),include_attributes=False)
        need(shape(old_ast)==shape(new_ast),'Unchanged proven owned-job telemetry/closure semantics')
    job_controls=[]
    for query_fails in (False,True):
        for close_fails in (False,True):
            events=[];phase={}
            class FakeJob:
                def close(self):
                    events.append('real_close')
                    if close_fails:raise OSError('fake close failure')
            def query(job):
                events.append('query_before_close')
                if query_fails:raise OSError('fake query failure')
                return {'captured_immediately_before_owned_job_close':True}
            try:target.FinalTelemetryJob(FakeJob(),lambda:phase,query).close()
            except OSError:need(close_fails,'Unexpected propagated error')
            else:need(not close_fails,'Real-close error must propagate')
            need(events==['query_before_close','real_close'],'Always query first and always call real close exactly once')
            need('final_job_telemetry_before_close' in phase,'Either telemetry or explicit query-failure evidence retained')
            job_controls.append({'query_fails':query_fails,'close_fails':close_fails,'events':events,'passed':True})
    builder=HERE/'BuildOriginalShaderNullDependencyFixture.cs';text=builder.read_text()
    need('CreateBuiltinWitnesses' not in text and 'Shader.Find(' not in text and 'AssetDatabase.CreateAsset(new Material' not in text,'No regenerated or name-selected Materials')
    for anchor in ('ReadCopiedBuiltinWitnesses(config)','row.dependencies.Length == 0','config.shaders.Length == 8',
        'shaderGuid == row.builtin_guid && shaderLocal == expectedId','ShaderPackedBuildReportCapture.Capture(built)',
        'result.packed_material_build_report = CaptureMaterials(built)','original_dependencies_restored_in_player = false',
        'BuildOptions.Development | BuildOptions.StrictMode','SerializationMode.Mixed'):
        need(anchor in text,'Required source gate absent: '+anchor)
    report={'schema':'eight-null-Editor-projection-fixture-pure-controls/v1','status':'passed',
        'projection_plan':target.pin(PLAN),'positive_config_admission':True,'negative_controls':checks,'negative_count':len(checks),
        'owned_job_final_query_and_real_close_controls':job_controls,'unchanged_proven_job_closure_AST':True,
        'original_guard_runner_builder_hashes_unchanged':True,'new_builder':target.pin(builder),'new_runner':target.pin(Path(target.__file__)),
        'source_contract_checks_only_not_CSharp_compilation':True,'actual_projected_wrapper_and_BuildPlayer_UNTESTED':True,
        'Main_modified':False,'compiler_Unity_game_network_launched':False,'tool':target.pin(Path(__file__))}
    target.save(out/'offline-controls.json',report)
    print(json.dumps({'status':'passed','negative_count':len(checks),'job_close_controls':4,'report':target.pin(out/'offline-controls.json')}))


if __name__=='__main__':main()
