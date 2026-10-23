"""Pure bounded clone and source-backed GPU plan; never launches player/Unity."""
from pathlib import Path
import argparse
import datetime as dt
import json
import re
import shutil
import struct
import sys
import uuid
import map_shader_buildreport as native
import orchestrate_eight_original_shader_restoration as context
import patch_original_shader_collection_with_external_extension as patcher
import run_windows_development_define_probe as guard

HERE=Path(__file__).resolve().parent
PATCH=context.AR/'EightShaderExpandedNamespacePatch-20261023T070933Z-706d654d'
PATCH_SHA='99bc9b8fca63994a92f58da286ba11dc01fe316966982d2b53e951e0240356e9'
REPORT_SHA='0abe2ae837bacc53185eebda0e4c70c1b5b04b2c4785b0ede50c1a4c3f394f1b'
BASE=context.AR/'EightOriginalShaderRestoration-20261023T065927Z-54a6afac'
RUNTIME_SHA='4aedcbce38d4e503efd19b81a203417aabfbaa3fceba9a758e75f4951ab6b144'
URP_TAG='UniversalPipeline,LightweightPipeline'


def save(path,obj):
    with Path(path).open('x',encoding='utf-8') as stream:json.dump(obj,stream,indent=2);stream.write('\n')


def form_facts(pin):
    context.check(pin)
    text=Path(pin['path']).read_text(encoding='utf-8')
    native.need(len(text)<=32*1024**2,'Bounded original ParsedForm')
    lines=text.splitlines()
    native.need(lines[:3]==['%YAML 1.1','%TAG !u! tag:unity3d.com,2011:','--- m_ParsedForm:'],'Exact pinned generated Shader ParsedForm format')
    def unique(prefix):
        found=[line[len(prefix):] for line in lines if line.startswith(prefix)]
        native.need(len(found)==1,'Unique exact generated field '+prefix)
        value=found[0].strip()
        native.need(not value.startswith(('"',"'",'|','>','&','*')),'Only the actual simple scalar format in these source proofs')
        return value or None
    begin=lines.index('  m_SubShaders:');end=next(i for i in range(begin+1,len(lines)) if lines[i].startswith('  m_Name:'))
    properties=[line[len('    - m_Name: '):] for line in lines[:begin] if line.startswith('    - m_Name: ')]
    native.need(all(re.fullmatch('[A-Za-z_][A-Za-z_0-9]*',name) for name in properties),'Exact original simple property identifiers')
    starts=[i for i in range(begin+1,end) if lines[i].startswith('  - m_Passes:')]
    native.need(starts,'Actual generated subshader list required')
    subshaders=[]
    for index,start in enumerate(starts):
        stop=starts[index+1] if index+1<len(starts) else end;section=lines[start:stop]
        pass_starts=[i for i,line in enumerate(section) if line.startswith('    - m_EditorDataHash:')]
        native.need(section[0] in ('  - m_Passes:','  - m_Passes: []') and bool(pass_starts)==(section[0]=='  - m_Passes:'),'Exact generated pass-list shape')
        tags=[i for i,line in enumerate(section) if line=='    m_Tags:'];native.need(len(tags)==1,'Exact subshader tag block')
        tag_section=section[tags[0]:]
        pipeline=[line[len('        RenderPipeline: '):] for line in tag_section if line.startswith('        RenderPipeline: ')]
        native.need(len(pipeline)<=1,'Unique exact subshader RenderPipeline tag')
        def pass_values(prefix,convert=lambda x:x or None):
            found=[convert(line[len(prefix):].strip()) for line in section if line.startswith(prefix)]
            native.need(len(found)==len(pass_starts),'One exact field per pass: '+prefix);return found
        subshaders.append({'index':index,'pipeline_tag':pipeline[0] if pipeline else None,'pass_count':len(pass_starts),
            'pass_names':pass_values('      m_Name:'),'pass_types':pass_values('      m_Type:',int),
            'pass_use_names':pass_values('      m_UseName:')})
    return {'source_ParsedForm':pin,'name':unique('  m_Name:'),'property_names':properties,'property_count':len(properties),
        'subshaders':subshaders,'fallback_name':unique('  m_FallbackName:'),
        'count_reader':'Strict indentation/field cardinality for actual pinned generated Shader_2020_3_16 YAML; no arbitrary YAML evaluation'}


def verify_patch():
    native.need(guard.sha(PATCH/'expanded-native-streaming-patch-plan.json')==PATCH_SHA
        and guard.sha(PATCH/'PatchedNativeFiles/streaming-patch-report.json')==REPORT_SHA,'Exact reviewed actual Root patch')
    plan=json.loads((PATCH/'expanded-native-streaming-patch-plan.json').read_bytes())
    report=json.loads((PATCH/'PatchedNativeFiles/streaming-patch-report.json').read_bytes())
    native.need(report['plan']==native.pin(PATCH/'expanded-native-streaming-patch-plan.json')
        and report['tool']==native.pin(Path(patcher.__file__)) and report['Shader_count']==8
        and report['status']=='explicit_original_Shader_payloads_and_proven_one_row_external_extension_streamed'
        and report['all_original_GPU_fields_unchanged_except_proved_dependency_PPtrs'],'Actual8 original program restoration receipt')
    player,containers,prepared=patcher.preflight(plan)
    by_guid={r['guid']:r for r in prepared};found=set();pointer_count=0
    for result in report['containers']:
        source=context.check(result['input']);output=context.check(result['output']);before=containers[source]
        native.need(result['every_other_preexisting_byte_exact'] and result['all_nontarget_object_rows_ranges_and_payloads_exact'],'Entire original non-target bytes preserved')
        digest=patcher.mask_compare(source,output,result['input']['bytes'],result['authorized_existing_file_edit_windows'])
        native.need(digest==result['masked_original_prefix_sha256'],'Recomputed exact masked original-file preservation')
        after,layout,_=patcher.metadata(output)
        native.need(after['externals']==before['parsed']['externals'] and layout['data_start']==before['layout']['data_start'],'Actual exact new external table/data offset')
        for item in result['objects']:
            row=by_guid[item['guid']];native.need(item['guid'] not in found,'Unique appended original Shader');found.add(item['guid'])
            data=bytearray(context.check(row['source']).read_bytes())
            for offset,file_id,path_id in row['edits']:struct.pack_into('<iq',data,offset,file_id,path_id)
            native.need(native.digest(data)==item['mapped_payload_sha256'] and native.digest(context.check(row['source']).read_bytes())==item['source_sha256'],'Entire mapped payload equals exact original plus only typed PPtr edits')
            obj=next(o for o in after['objects'] if str(o['path_id'])==item['path_id'])
            native.need(obj['offset']==int(item['new_absolute_offset']) and obj['size']==len(data),'Exact target table range')
            with output.open('rb') as stream:stream.seek(obj['offset']);actual=stream.read(obj['size'])
            native.need(actual==data,'Whole actual persisted original Shader payload readback')
            pointer_count+=len(row['edits'])
    native.need(found==set(context.projection.GUIDS) and pointer_count==14,'All eight actual payloads and fourteen restored pointers')
    return plan,report,player


def prepare(out):
    plan,patch_report,player=verify_patch()
    canonical=json.loads(context.check(plan['canonical_manifest']).read_bytes())
    canonical_rows={row['guid']:row for row in canonical['shaders']}
    facts=[];cases=[]
    for row in canonical['shaders']:
        candidates=[p for p in row['proofs'] if p['sha256']==row['expected_ParsedForm_sha256']]
        native.need(len(candidates)==1,'Unique pinned original ParsedForm authority')
        original_form_pin=candidates[0]
        fact=form_facts(original_form_pin);native.need(fact['name']==row['name'] and fact['subshaders'],'Original exact Shader name and explicit subshader list')
        first=fact['subshaders'][0];pipeline=first['pipeline_tag']
        native.need(pipeline in (None,'UniversalPipeline'),'Only exact original absent or URP subshader tag supported')
        passes=first['pass_count'];pass_source={'kind':'original_first_subshader','original_subshader':first}
        if passes==0:
            # Native identity is already fixed by the original indexed edge and
            # the actual Material chain. FallbackName validates that explicit
            # source dependency; no native object is selected by Shader name.
            fallback_candidates=[]
            for edge in row['expected_direct_shader_dependencies']:
                if edge['kind']=='project':
                    target_row=canonical_rows[edge['guid']]
                    target_forms=[pin for pin in target_row['proofs'] if pin['sha256']==target_row['expected_ParsedForm_sha256']]
                    native.need(len(target_forms)==1,'One exact original project fallback form')
                    fallback=form_facts(target_forms[0])
                    if fallback['name']==fact['fallback_name']:
                        fallback_candidates.append((edge,{'canonical_original_target_GUID':edge['guid'],'original_ParsedForm':target_forms[0]},fallback))
                    continue
                native.need(edge['kind']=='builtin','Only exact resolved project or builtin original dependencies')
                builtin_id=str(edge['local_file_id'])
                native.need(builtin_id in ('6','7','46','10490'),'Only four independently proved builtin identities')
                directory=context.AR/('GenuineEditorBuiltinShaderIdentities-20261023T031035Z-a16ac0b1/Model-'+builtin_id)
                proof=json.loads((directory/'report.json').read_bytes())
                native.need(proof['status']=='parsed_entire_genuine_Editor_object' and proof['path_id']==builtin_id and proof['class_id']==48
                    and proof['serialization_layout']=='Editor' and proof['consumed_bytes']==proof['total_bytes'],'Entire exact builtin typed ReadEditor proof')
                form_pin=native.pin(directory/'ParsedForm.yaml');native.need(form_pin['sha256']==proof['parsed_form']['sha256'],'Exact genuine builtin ParsedForm')
                fallback=form_facts(form_pin)
                if fallback['name']==fact['fallback_name']:
                    fallback_candidates.append((edge,{'genuine_builtin_model':native.pin(directory/'report.json'),'genuine_builtin_ParsedForm':form_pin},fallback))
            native.need(len(fallback_candidates)==1,'One explicit canonical dependency must validate the original fallback declaration for '+row['name'])
            edge,fallback_proof,fallback=fallback_candidates[0]
            passes=fallback['subshaders'][0]['pass_count'];native.need(passes>0,'Exact genuine builtin explicit first-subshader pass count')
            pass_source={'kind':'original_zero_own_passes_plus_explicit_canonical_fallback','original_own_pass_count':0,
                'canonical_fallback_edge':edge,'fallback_identity_proof':fallback_proof,'fallback_ParsedForm_facts':fallback}
        native.need(0<passes<=256 and 0<=fact['property_count']<=4096,'Source-derived bounded runtime expectation')
        fact['guid']=row['guid'];facts.append(fact)
        cases.append({'guid':row['guid'],'name':row['name'],'resource_key':'OriginalShaders/'+row['guid'],
            'expected_property_count':fact['property_count'],'expected_property_names':fact['property_names'],
            'expected_pass_count':passes,'pipeline_tag_argument':'unchanged' if pipeline is None else URP_TAG,
            'pipeline_tag_original_value':pipeline,'pass_count_source':pass_source,'ParsedForm':original_form_pin,
            'pixel_assertion':'none','pixel_values_to_be_reported_without_visual_fidelity_claim':True})
    target=out/'Player';target.mkdir();inventory=[]
    replacements={Path(r['input']['path']).resolve(strict=True):r for r in patch_report['containers']}
    paths=sorted(p for p in player.rglob('*') if p.is_file())
    native.need(len(paths)<=4096 and sum(p.stat().st_size for p in paths)<=2*1024**3,'Bounded complete diagnostic player clone')
    for source in paths:
        guard.safety.assert_no_reparse(source)
        original=native.pin(source);replacement=replacements.get(source.resolve(strict=True));copy_from=source if replacement is None else context.check(replacement['output'])
        destination=target/source.relative_to(player);destination.parent.mkdir(parents=True,exist_ok=True)
        with copy_from.open('rb') as a,destination.open('xb') as b:
            while chunk:=a.read(1024**2):b.write(chunk)
        expected=native.pin(copy_from);actual=native.pin(destination)
        native.need(actual['bytes']==expected['bytes'] and actual['sha256']==expected['sha256'] and native.pin(source)==original,'Exact clone file and unchanged original')
        inventory.append({'relative_path':source.relative_to(player).as_posix(),'original':original,'clone':actual,'is_patched_native_container':replacement is not None})
    fixture=json.loads((context.FIXTURE/'plan.json').read_bytes())
    runtime=Path(fixture['project'])/'Assets/Runtime/OriginalShaderRuntimeProbe.cs'
    native.need(guard.sha(runtime)==RUNTIME_SHA,'Existing actually compiled pipeline-tag runtime harness')
    exe=target/'OriginalShaderNullDependencyDiagnostic.exe'
    native.need(exe.is_file() and len(inventory)==len(paths),'Complete same-player clone')
    save(out/'player-clone-inventory.json',inventory);save(out/'source-Shader-GPU-facts.json',facts)
    gpu={'schema':'actual-restored-eight-original-Shader-Root-D3D11-probe-plan/v1','status':'prepared_verified_clone_NO_PLAYER_LAUNCHED',
        'fixture':str(out),'player':native.pin(exe),'player_root':str(target),'source_player_root':str(player),
        'source_project':fixture['project'],'source_runtime_harness':native.pin(runtime),
        'actual_build_report':plan['actual_same_build_report'],'actual_native_patch_report':native.pin(PATCH/'PatchedNativeFiles/streaming-patch-report.json'),
        'native_patch_plan':native.pin(PATCH/'expanded-native-streaming-patch-plan.json'),'clone_inventory':native.pin(out/'player-clone-inventory.json'),
        'source_facts':native.pin(out/'source-Shader-GPU-facts.json'),'cases':cases,
        'runner':native.pin(HERE/'run_eight_original_shader_gpu_probes.py'),'guard':native.pin(Path(guard.__file__)),
        'launcher':native.pin(HERE/'owned_suspended_launch.py'),'owned_job_cap_bytes':1536*1024**2,'reserve_bytes':int(1.5*1024**3),'deadline_seconds_each':60,
        'green_control_before_all_originals':True,'require_whole_player_log_zero_shader_CB_CS_errors':True,
        'limitations':['First source subshader pass counts are strict hypotheses falsified by actual native runtime if a different supported source subshader is selected.',
            'ProBuilder expected fallback count comes from actual genuine Editor builtin46 model, with zero own original passes explicitly retained.',
            'URP tag selects original URP subshaders only; no actual URP renderer/global bindings/gameplay/visual fidelity is claimed.',
            'Pixels are diagnostic observations; black can occur without scene/global material bindings.'],
        'Main_modified':False,'player_Unity_compiler_network_launched':False}
    save(out/'gpu-probe-plan.json',gpu)
    print(json.dumps({'plan':native.pin(out/'gpu-probe-plan.json'),'cloned_files':len(inventory),'cases':[{'guid':r['guid'],'properties':r['expected_property_count'],'passes':r['expected_pass_count'],'pipeline':r['pipeline_tag_argument']} for r in cases]}))


def main():
    ap=argparse.ArgumentParser();ap.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);args=ap.parse_args()
    if args._worker:return prepare(args._worker.resolve(strict=True))
    out=context.AR/('EightOriginalShaderGPUFixture-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    receipt={'schema':'guarded-pure-eight-original-Shader-native-clone-GPU-plan/v1','status':'starting','phases':[]}
    try:
        guard.bounded([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],guard.WS,out,'pure-native8-integrity-source-counts-and-player-clone',256*1024**2,60,receipt);receipt['status']='passed'
    except BaseException as error:receipt.update(status='held',error=repr(error))
    guard.save(out,receipt);print(json.dumps({'status':receipt['status'],'receipt':native.pin(out/'run-report.json'),'error':receipt.get('error')}))
    return 0 if receipt['status']=='passed' else 1


if __name__=='__main__':raise SystemExit(main())
