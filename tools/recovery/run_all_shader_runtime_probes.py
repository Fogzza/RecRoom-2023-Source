"""Root-only diagnostic Csc,179 structural load batches, or established8 draws.

No Unity Editor/game code/network/Main mutation. Csc replaces only a fresh
diagnostic clone's Assembly-CSharp DLL/PDB; native179 restored bytes stay exact.
"""
from pathlib import Path
import argparse,copy,datetime as dt,json,re,shutil,uuid
import prepare_all_shader_runtime_fixture as proof
import run_original_shader_null_dependency_fixture as telemetry
import run_windows_development_define_probe as guard

need=proof.need;pin=proof.pin;save=proof.save


def inventory(path,rows):
    root=Path(path).resolve(strict=True)
    need({p.resolve() for p in root.rglob('*') if p.is_file()}=={Path(r['clone']['path']).resolve() for r in rows},'Complete exact cloned file inventory')
    for row in rows:guard.checked(row['clone']);guard.checked(row['original'])


def verify(path,digest):
    path=path.resolve(strict=True);need(guard.sha(path)==digest,'Exact reviewed runtime plan SHA');plan=json.loads(path.read_bytes());root=path.parent
    need(root.parent==proof.AR and root.name.startswith('All179OriginalShaderRuntimeFixture-') and plan['fixture']==str(root)
        and plan['schema']=='actual-restored179-Shader-structural-and-eight-GPU-runtime-preparation/v1'
        and plan['expected_structural_shader_count']==179 and plan['expected_batches']==6 and plan['expected_GPU_Shader_cases']==8
        and plan['compiler_cap_bytes']==256*1024**2 and plan['runtime_cap_bytes']==6*1024**3 and plan['reserve_bytes']==guard.RESERVE
        and plan['compile_deadline_seconds']==30 and plan['runtime_deadline_seconds_each']==90,'Fixed isolated native179/runtime scope and caps')
    for key in ('runner','preparer','guard','launcher','native_patch_plan','actual_native_patch_report','native_owned_patch_receipt','player','preinstrumentation_inventory',
        'source_facts','actual_new_Standard_pass_proof','GPU_cases','runtime_registration','scripting_assemblies','compiler','compile_response'):guard.checked(plan[key])
    for row in plan['compile_sources']+plan['compile_references']+plan['load_batches']:guard.checked(row)
    need(plan['runner']==pin(Path(__file__)) and plan['guard']['sha256']=='685f87ada7d4c10a09421e11b59466b3e19e817bfdaabd5a233c0192f17529fc'
        and plan['launcher']['sha256']=='3d7e912711cf4babf2200efc1d93f07d89625fd39fe5f381f09356d89c5cd958'
        and guard.sha(Path(telemetry.__file__))=='806b319396d647bd5562b21caa4235348cd41ae13d82dc63d0ad28bceb7bff07','Exact new runner and frozen guard/telemetry/launcher')
    proof.verify_patch()
    expected=proof.context.canonical_guids();seen=[]
    for row in plan['load_batches']:
        value=json.loads(Path(row['path']).read_bytes());need(value['schema']=='explicit-original-Shader-structural-load-batch-input/v1' and 1<=len(value['shaders'])<=32,'Actual bounded structural input')
        for item in value['shaders']:
            need(item['resource_key']=='OriginalShaders/'+item['guid'] and item['pipeline_tag_argument'] in ('unchanged',proof.forms.URP_TAG),'Exact resource/pipeline contract');seen.append(item['guid'])
    need(tuple(seen)==expected,'Exactly179 original identities once, in canonical source order')
    cases=json.loads(Path(plan['GPU_cases']['path']).read_bytes());need(tuple(r['guid'] for r in cases)==proof.context.projection.GUIDS,'Exactly8 original source GPU cases')
    need(Path(plan['player_root'])==root/'Player' and Path(plan['compiled_diagnostic_directory'])==root/'CompiledDiagnostic','Owned fresh clone/diagnostic compiler output')
    return plan,root


def compile_diagnostic(path,plan,root):
    original_rows=json.loads(Path(plan['preinstrumentation_inventory']['path']).read_bytes());inventory(plan['player_root'],original_rows)
    ready=root/'runtime-ready.json';compiled=Path(plan['compiled_diagnostic_directory'])
    need(not ready.exists() and not(compiled/'Assembly-CSharp.dll').exists() and not(compiled/'Assembly-CSharp.pdb').exists(),'Fresh one-shot diagnostic compilation')
    out=root/('CompileRuntime-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'Root-owned-original179-diagnostic-runtime-compilation/v1','status':'starting','plan':pin(path),'phases':[],'Main_modified':False,'Unity_Editor_or_player_launched':False}
    factory=guard.make_job;guard.make_job=telemetry.telemetry_factory(factory,report)
    try:
        guard.bounded([plan['compiler']['path'],'/noconfig','@'+plan['compile_response']['path']],root,out,'matching-Csc-diagnostic-load-batch-and-original-GPU-probe',plan['compiler_cap_bytes'],30,report)
        outputs=[pin(compiled/'Assembly-CSharp.dll'),pin(compiled/'Assembly-CSharp.pdb')]
        need(all(r['bytes']>0 for r in outputs),'Actual matching DLL and portable PDB outputs')
        inventory(plan['player_root'],original_rows);changes={}
        expected_paths=['AllOriginalShaderNullDependencyDiagnostic_Data/Managed/Assembly-CSharp.dll','AllOriginalShaderNullDependencyDiagnostic_Data/Managed/Assembly-CSharp.pdb']
        need(plan['diagnostic_managed_replacements']==expected_paths,'Only diagnostic DLL/PDB replacement whitelist')
        for relative,source in zip(expected_paths,outputs):
            target=Path(plan['player_root'])/relative;before=pin(target);shutil.copyfile(source['path'],target);after=pin(target)
            need(after['sha256']==source['sha256'] and after['bytes']==source['bytes'],'Exact compiled diagnostic clone replacement');changes[relative]={'before':before,'after':after,'compiled':source}
        updated=copy.deepcopy(original_rows)
        for row in updated:
            if row['relative_path'] in changes:row['clone']=changes[row['relative_path']]['after'];row['diagnostic_managed_instrumentation']=True
        inventory(plan['player_root'],updated);save(compiled/'clone-inventory.json',updated)
        report.update(status='matching_diagnostic_only_assembly_and_PDB_compiled_and_installed_fresh_clone',outputs=outputs,changes=changes,
            all_original_native_Shader_files_unchanged_after_diagnostic_instrumentation=True,clone_inventory=pin(compiled/'clone-inventory.json'))
        save(ready,{'schema':'actual179-diagnostic-runtime-ready/v1','status':'compiled_diagnostic_only_clone_ready_for_Root_native_load_and_GPU_checks',
            'source_plan':pin(path),'compile_run_receipt_path':str(out/'run-report.json'),'compiled_outputs':outputs,'clone_inventory':pin(compiled/'clone-inventory.json'),
            'exact_two_diagnostic_managed_replacements':changes,'Main_modified':False})
    except BaseException as error:report.update(status='held_preserve_compiler_and_clone_outputs',error=repr(error))
    finally:guard.make_job=factory;guard.save(out,report)
    print(json.dumps({'status':report['status'],'receipt':pin(out/'run-report.json'),'runtime_ready':pin(ready) if ready.is_file() else None,'error':report.get('error')}));return 0 if report['status'].startswith('matching_diagnostic_only_') else 1


def ready_inputs(path,plan,root):
    ready=json.loads((root/'runtime-ready.json').read_bytes());need(ready['schema']=='actual179-diagnostic-runtime-ready/v1'
        and ready['status']=='compiled_diagnostic_only_clone_ready_for_Root_native_load_and_GPU_checks' and ready['source_plan']==pin(path),'Actual new matching diagnostic compilation required')
    receipt_path=Path(ready['compile_run_receipt_path']);receipt=json.loads(receipt_path.read_bytes())
    need(receipt['status']=='matching_diagnostic_only_assembly_and_PDB_compiled_and_installed_fresh_clone' and receipt['plan']==pin(path)
        and len(receipt['phases'])==1 and receipt['phases'][0]['exit_code']==0 and receipt['phases'][0]['launcher']['membership_verified_before_resume'],'Actual owned diagnostic Csc phase passed')
    for row in ready['compiled_outputs']+[ready['clone_inventory']]:guard.checked(row)
    rows=json.loads(Path(ready['clone_inventory']['path']).read_bytes());inventory(plan['player_root'],rows);return ready,rows


def failures(log):
    text=Path(log).read_text(encoding='utf-8',errors='replace')
    bad=[s[:1024] for s in text.splitlines() if re.search(r'Partial constant buffer not found\.|error CS\d+|Shader error in|ERROR: Shader|Failed to find expected binary shader data|is corrupted|Position out of bounds|Fatal error|StackOverflowException|Could not allocate memory|Out of memory|Unhandled Exception|TypeLoadException|ReflectionTypeLoadException',s,re.I)][:64]
    d3d=bool('Direct3D:' in text and re.search(r'(?im)^\s*Version:\s*Direct3D 11',text) and 'Renderer: Null Device' not in text)
    return bad,d3d


def run_runtime(path,plan,root,mode):
    ready,rows=ready_inputs(path,plan,root);out=root/(('StructuralLoads-' if mode=='loads' else 'GPU8-')+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'Root-owned-original179-structural-loads-or-eight-GPU/v1','status':'starting','mode':mode,'plan':pin(path),'runtime_ready':pin(root/'runtime-ready.json'),
        'phases':[],'results':[],'Main_modified':False,'compiler_or_Editor_launched':False,'all179_visual_correctness_claimed':False,'actual_URP_renderer_or_gameplay_claimed':False}
    factory=guard.make_job;guard.make_job=telemetry.telemetry_factory(factory,report)
    try:
        commands=[]
        if mode=='loads':
            for index,row in enumerate(plan['load_batches']):commands.append(('load-batch-'+str(index).zfill(2),row))
        else:
            control={'guid':None,'resource_key':'ShaderProbeControl','name':'SolarNet/Diagnostic/Green','expected_property_count':0,'expected_property_names':[],
                'expected_pass_count':1,'pipeline_tag_argument':'unchanged'}
            commands=[('green-control',control)]+[('original-'+r['guid'],r) for r in json.loads(Path(plan['GPU_cases']['path']).read_bytes())]
        for label,case in commands:
            result=out/(label+'-result.json');log=out/(label+'-Player.log')
            command=[plan['player']['path'],'-batchmode','-force-d3d11','-screen-fullscreen','0','-screen-width','64','-screen-height','64','-logFile',str(log)]
            if mode=='loads':command+=['-shaderLoadBatchConfig',case['path'],'-shaderLoadBatchOutput',str(result)]
            else:command+=['-shaderProbeMode','resources','-shaderProbeOutput',str(result),'-shaderProbeResource',case['resource_key'],'-shaderProbeExpectedName',case['name'],
                '-shaderProbeExpectedProperties',str(case['expected_property_count']),'-shaderProbeExpectedPasses',str(case['expected_pass_count']),
                '-shaderProbePipelineTag',case['pipeline_tag_argument'],'-shaderProbePixelCheck','none']
            error=None
            try:guard.bounded(command,root,out,label,plan['runtime_cap_bytes'],90,report)
            except BaseException as caught:error=repr(caught)
            observed=json.loads(result.read_bytes()) if result.is_file() else None;bad,d3d=failures(log) if log.is_file() else (['Full Player log missing'],False)
            entry={'label':label,'process_error':error,'runtime':observed,'runtime_report':pin(result) if result.is_file() else None,'full_player_log':pin(log) if log.is_file() else None,
                'full_log_failure_lines':bad,'actual_D3D11_initialized':d3d,'passed':False}
            if mode=='loads':
                expected=json.loads(Path(case['path']).read_bytes())['shaders']
                passed=bool(error is None and observed and observed['schema']=='actual-original-Shader-structural-load-batch/v1'
                    and observed['status']=='all_explicit_original_Shader_names_and_properties_loaded_without_errors' and observed['partial_constant_buffer_messages']==0
                    and not observed['shader_error_lines'] and not observed['GPU_draw_attempted'] and len(observed['shaders'])==len(expected) and not bad and d3d)
                if passed:
                    for want,got in zip(expected,observed['shaders']):
                        passed &= got['guid']==want['guid'] and got['resource_key']==want['resource_key'] and got['name']==want['name']
                        passed &= got['loaded_exact_original_identity'] and got['property_count']==want['expected_property_count'] and got['property_names']==want['expected_property_names']
                entry['passed']=bool(passed)
            else:
                entry['passed']=bool(error is None and observed and observed['status']=='exact_Shader_loaded_supported_pass_set_and_D3D11_render_readback_completed'
                    and observed['shader_name']==case['name'] and observed['property_count']==case['expected_property_count'] and observed['property_names']==case['expected_property_names']
                    and observed['material_pass_count']==case['expected_pass_count'] and observed['shader_supported'] and observed['set_pass_succeeded'] and observed['render_and_readback_completed']
                    and observed['partial_constant_buffer_messages']==0 and not observed['shader_error_lines'] and not bad and d3d)
                if label=='green-control':entry['passed'] &= observed is not None and observed['center_pixel']=={'r':0,'g':255,'b':0,'a':255}
            report['results'].append(entry);guard.save(out,report)
            need(entry['passed'],'Strict runtime case failed; preserve output before any further batch: '+label)
        inventory(plan['player_root'],rows)
        if mode=='loads':
            all_rows=[r for result in report['results'] for r in result['runtime']['shaders']]
            need(len(all_rows)==179 and tuple(r['guid'] for r in all_rows)==proof.context.canonical_guids(),'Actual all179 unique structural identities in source order')
            report.update(status='all179_original_Shader_names_and_ordered_properties_loaded_zero_native_Shader_CB_errors',loaded_Shader_count=179,
                supported_count=sum(bool(r['supported']) for r in all_rows),unsupported_GUIDs=[r['guid'] for r in all_rows if not r['supported']],all179_GPU_drawing_claimed=False)
        else:
            need(len(report['results'])==9,'Green plus exactly8 original GPU cases');report['status']='same179patched_player_green_and8_original_Shader_GPU_cases_passed'
    except BaseException as caught:report.update(status='held_or_failed_preserve_outputs',error=repr(caught))
    finally:guard.make_job=factory;guard.save(out,report)
    print(json.dumps({'status':report['status'],'receipt':pin(out/'run-report.json'),'error':report.get('error')}));return 0 if report['status'].startswith(('all179_','same179')) else 1


def main():
    ap=argparse.ArgumentParser(description=__doc__);ap.add_argument('--plan',required=True,type=Path);ap.add_argument('--plan-sha256',required=True)
    group=ap.add_mutually_exclusive_group();group.add_argument('--compile-diagnostic',action='store_true');group.add_argument('--run-load-batches',action='store_true');group.add_argument('--run-gpu',action='store_true');args=ap.parse_args()
    path=args.plan.resolve(strict=True);plan,root=verify(path,args.plan_sha256)
    if args.compile_diagnostic:return compile_diagnostic(path,plan,root)
    if args.run_load_batches or args.run_gpu:return run_runtime(path,plan,root,'loads' if args.run_load_batches else 'gpu')
    print(json.dumps({'status':'verified_no_child_started','plan':pin(path)}));return 0


if __name__=='__main__':raise SystemExit(main())
