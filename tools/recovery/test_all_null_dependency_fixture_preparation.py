"""Pure original179 authority/admission/closure controls; no native execution."""
from pathlib import Path
import argparse,ast,copy,json,re
import run_all_original_shader_null_dependency_fixture as target
import prepare_original_shader_null_dependency_projection as projection

HERE=Path(__file__).resolve().parent
PROPOSAL=projection.AR/'All179ShaderNullDependencyProposal-20261023T074348Z-e2fbfc75/proposal.json'
PROPOSAL_SHA='9f174b205d46b06e6a9832f6b2930434863c6e5fa2fa0808272c6d7e7d6fe01e'


def need(value,message):
    if not value:raise ValueError(message)


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--out',required=True,type=Path);args=ap.parse_args();out=args.out.resolve(strict=True)
    need(out.is_relative_to(projection.ROOT/'Validation'),'Fresh recovery-only controls output')
    need(target.guard.sha(PROPOSAL)==PROPOSAL_SHA,'Fresh179 proposal bound to actual8 aggregate')
    proposal=json.loads(PROPOSAL.read_bytes());target.verify_aggregate(proposal)
    target.guard.checked(proposal['manifest']);manifest=json.loads(Path(proposal['manifest']['path']).read_bytes());original=target.authority()
    target.validate_manifest(manifest,original)
    project=out/'NeverLaunchedProject'
    config={'project':str(project),'Editor_dependency_projection':True,'shaders':[
        {'guid':r['guid'],'name':r['name'],'sha256':r['source']['sha256'],'meta_sha256':r['meta']['sha256'],
         'dependencies':[],'path':'Assets/Resources/OriginalShaders/'+r['guid']+'.asset'} for r in manifest['shaders']],
        'copied_materials':[copy.deepcopy(r['witness']) for r in proposal['copied_native_Material_sources']]}
    plan={'selected_GUIDs':[r['guid'] for r in manifest['shaders']],'material_witnesses':copy.deepcopy(config['copied_materials'])}
    target.validate_config(config,plan,project);negative=[]
    def reject(name,change):
        c,p=copy.deepcopy(config),copy.deepcopy(plan);change(c,p)
        try:target.validate_config(c,p,project)
        except (RuntimeError,ValueError,KeyError,TypeError):negative.append({'name':name,'rejected':True})
        else:raise AssertionError('Invalid179 fixture config accepted: '+name)
    reject('wrong project',lambda c,p:c.__setitem__('project',str(HERE.parents[2]/'RR23')))
    reject('178 not179',lambda c,p:c['shaders'].pop())
    reject('duplicate Shader GUID',lambda c,p:c['shaders'].__setitem__(-1,copy.deepcopy(c['shaders'][0])))
    reject('reordered canonical identities',lambda c,p:c['shaders'].reverse())
    reject('unproven extra identity',lambda c,p:c['shaders'][0].__setitem__('guid','0'*32))
    reject('original name changed',lambda c,p:c['shaders'][0].__setitem__('name','Synthetic'))
    reject('original meta changed',lambda c,p:c['shaders'][0].__setitem__('meta_sha256','0'*64))
    reject('project dependency retained',lambda c,p:c['shaders'][0]['dependencies'].append({'kind':'project','guid':p['selected_GUIDs'][1],'local_file_id':4800000}))
    reject('builtin dependency retained',lambda c,p:c['shaders'][0]['dependencies'].append({'kind':'builtin','guid':target.small.MAGIC,'local_file_id':46}))
    reject('resource path traversal',lambda c,p:c['shaders'][0].__setitem__('path','../RR23/Assets/test.asset'))
    reject('projection scope disabled',lambda c,p:c.__setitem__('Editor_dependency_projection',False))
    reject('missing Material',lambda c,p:c['copied_materials'].pop())
    reject('Material source bytes changed',lambda c,p:c['copied_materials'][0].__setitem__('asset_sha256','0'*64))
    reject('Material meta changed',lambda c,p:c['copied_materials'][0].__setitem__('meta_sha256','0'*64))
    for key,value in [('builtin_guid','1'*32),('builtin_local_id','999'),('material_local_id','1'),('material_source_path','Assets/Unexpected.mat')]:
        def both(c,p,k=key,v=value):c['copied_materials'][0][k]=v;p['material_witnesses'][0][k]=v
        reject('unproven '+key+' in both config and plan',both)
    def duplicate(c,p):c['copied_materials'][1]=copy.deepcopy(c['copied_materials'][0]);p['material_witnesses']=copy.deepcopy(c['copied_materials'])
    reject('duplicate builtin/Material in both config and plan',duplicate)
    for name,change in [('shipping null dependencies',lambda m:m.__setitem__('shipping_null_dependencies_authorized',True)),
        ('not Editor projection',lambda m:m.__setitem__('Editor_projection_only',False)),
        ('source program expectation changed',lambda m:m['shaders'][0]['expected_program_fields'].__setitem__('CompressedBlob',{})),
        ('native projection nonzero PPtr',lambda m:next(r for r in m['shaders'] if r['dependencies'])['dependencies'][0].__setitem__('output_path_id',4800000))]:
        value=copy.deepcopy(manifest);change(value)
        try:target.validate_manifest(value,original)
        except (RuntimeError,ValueError,KeyError,TypeError):negative.append({'name':name,'rejected':True})
        else:raise AssertionError('Invalid canonical projection accepted: '+name)
    old=projection.AR/'OriginalShaderNullDependencyFixture-20261023T065310Z-47a193e1/plan.json'
    try:target.verify(old,target.guard.sha(old),False)
    except RuntimeError:negative.append({'name':'old eight fixture rejected by179 runner','rejected':True})
    else:raise AssertionError('Old8 plan accepted')
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
            try:target.small.FinalTelemetryJob(FakeJob(),lambda:phase,query).close()
            except OSError:need(close_fails,'Only real-close failure propagates')
            else:need(not close_fails,'Real-close error must propagate')
            need(events==['query_before_close','real_close'] and 'final_job_telemetry_before_close' in phase,'Query first and real close exactly once in all paths')
            job_controls.append({'query_fails':query_fails,'close_fails':close_fails,'events':events,'passed':True})
    old_builder=HERE/'BuildOriginalShaderNullDependencyFixture.cs';builder=HERE/'BuildAllOriginalShaderNullDependencyFixture.cs';runner=Path(target.__file__)
    need(target.guard.sha(old_builder)=='92a5dd65c4fb8d3f5be6671c8b8482ebd9443bd787a42691e457a67ca4d21c6b'
        and target.guard.sha(Path(target.small.__file__))==target.SMALL_SHA,'Frozen successful8 sources unchanged')
    text=builder.read_text();section=text.split('ExpectedGuids = new HashSet<string>(StringComparer.Ordinal) {',1)[1].split('};',1)[0]
    need(re.findall(r'"([a-f0-9]{32})"',section)==[r['guid'] for r in original['shaders']],'C# actual179 GUID set/order derived exactly from canonical authority')
    for bad in ('Shader.Find(','CreateBuiltinWitnesses','AssetDatabase.CreateAsset(new Material','config.include_alpha_clip'):need(bad not in text,'No synthetic/name-selected Materials or old subset control')
    for anchor in ('row.dependencies.Length == 0','config.shaders.Length == 179','ReadCopiedBuiltinWitnesses(config)',
        'shaderGuid == row.builtin_guid && shaderLocal == expectedId','ShaderPackedBuildReportCapture.Capture(built)',
        'result.packed_material_build_report = CaptureMaterials(built)','original_dependencies_restored_in_player = false',
        'BuildOptions.Development | BuildOptions.StrictMode','SerializationMode.Mixed','Need(matches == 1'):
        need(anchor in text,'Required native identity/build gate absent: '+anchor)
    ast.parse(runner.read_text());ast.parse(Path(__file__).read_text())
    report={'schema':'all179-null-Editor-projection-fixture-pure-controls/v1','status':'passed','positive_canonical179_authority_rows':179,
        'positive_original_typed_dependency_windows':104,'positive_config_admission':True,'actual8_aggregate':proposal['aggregate_gate'],
        'negative_controls':negative,'negative_count':len(negative),'owned_job_final_query_and_real_close_controls':job_controls,
        'new_builder':target.pin(builder),'new_runner':target.pin(runner),'proposal':target.pin(PROPOSAL),
        'source_contract_checks_only_not_CSharp_compilation':True,'all179_conversions_wrappers_and_BuildPlayer_UNTESTED':True,
        'Main_modified':False,'compiler_Unity_managed_reader_game_network_launched':False,'tool':target.pin(Path(__file__))}
    target.save(out/'offline-controls.json',report);print(json.dumps({'status':'passed','negative_count':len(negative),'job_close_controls':4,'report':target.pin(out/'offline-controls.json')}))


if __name__=='__main__':main()
