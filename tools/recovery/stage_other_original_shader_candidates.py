"""Stage exact original Decal/Lens six-field candidates; no Main, Unity or compiler writes."""
from pathlib import Path
import datetime as dt
import hashlib
import json
import struct
import sys
import uuid

HERE = Path(__file__).resolve().parent
WS = HERE.parents[2]
ROOT = WS / 'Recovery/RecRoom-2023-04-18'
sys.path.insert(0, str(HERE))
from read_original_ag_shader_models import phase, pin, sha, need
from stage_original_ag_shader_candidate import typed_identity, compatible
from stage_original_stencil_shader import spans, strip_fields, NAMES, uint_hex
from compare_shader_parsed_form import compare

MODELS = ROOT/'AssetRecovery/OtherOriginalShaderModels-20261022T204527Z-eef10a5d'
MODELS_SHA = 'a983d0d58b828393e0050585d7bcd42383f6f84a884bd43e8cceef342be3e281'
TARGETS = {
    'AG/Standard-Opaque-Decal': ('AG_Standard-Opaque-Decal.asset', 'd9ec87b7cbbfb4e4e017ab1b2943fe00c1eb905f5054ba3971cc190d75e9499a', '11fa88e7c754fcabce43c8b82c4186e78836c98b19713a4cb1811cb531e0e0c6'),
    'Props/LensRender': ('Props_LensRender.asset', '368eda540fd06af72d0870afdb8aa54311b42a985d6717835f5a0a57371964db', '3de1518a23e1b9f68039944bd15072c7a8506342f36188e4ce080d8683411c77'),
}

def digest(data):
    return hashlib.sha256(data).hexdigest()

def worker(out):
    report={'schema':'two-original-shader-six-field-candidates/v1','status':'starting','candidates':[],
            'Main_modified':False,'Unity_launched':False,'compiler_launched':False,'GPU_support_claimed':False,
            'Main_import_or_player_build_success_claimed':False}
    try:
        need(sha(MODELS/'models-report.json')==MODELS_SHA,'Exact complete original model mapping receipt required')
        models=json.loads((MODELS/'models-report.json').read_bytes())
        need(models['status']=='both_original_type48_objects_structurally_parsed_unique_retained_data_mapping','Previous unique original source proof failed')
        report['original_models_receipt']=pin(MODELS/'models-report.json')
        for name,(basename,main_sha,meta_sha) in TARGETS.items():
            main=WS/'RR23/Assets/Shader'/basename; main_meta=Path(str(main)+'.meta')
            need(sha(main)==main_sha and sha(main_meta)==meta_sha,'Current Main shader/meta differs from original retained-data witness')
            before=main.read_bytes(); meta=main_meta.read_bytes(); current=typed_identity(main)
            compared=[]; accepted=[]
            for entry in models['models']:
                if entry['target']!=name: continue
                model_path=Path(entry['model']['path'])
                need(sha(model_path)==entry['model']['sha256'],'Exact model receipt changed')
                model=json.loads(model_path.read_bytes()); form=Path(model['parsed_form']['path'])
                need(sha(form)==model['parsed_form']['sha256'],'Exact original ParsedForm changed')
                identity=typed_identity(form); proof=compatible(identity,current)
                compared.append({'original_provenance':entry['original_provenance'],'model':pin(model_path),'proof':proof})
                if proof['matches_all_retained_typed_data']: accepted.append((entry,model_path,model,form,identity))
            need(len(accepted)==1,'Unique complete retained-data source selection required, never name-only')
            entry,model_path,model,form,identity=accepted[0]
            need(entry['original_provenance']['origin']=='native' and model['class_id']==48 and model['engine']=='2020.3.33f1'
                 and model['actual_name']==name and model['status']=='parsed_entire_original_object' and model['no_pointer_yaml'], 'Exact original native Class48 model identity')
            raw_path=Path(model['source']); raw=raw_path.read_bytes()
            need(digest(raw)==model['source_sha256']==entry['original_provenance']['raw_object']['sha256']
                 and model['consumed_bytes']==model['total_bytes']==len(raw)<=8*1024**2,'Exact complete raw source object differs')
            fields=model['fields']; blob_info=fields['compressedBlob']; size=blob_info['bytes']
            need(0<size<=len(raw),'Nonempty bounded original program payload required')
            needle=struct.pack('<I',size); matches=[]; start=0
            while True:
                at=raw.find(needle,start)
                if at<0: break
                start=at+1; blob=raw[at+4:at+4+size]
                if len(blob)==size and digest(blob)==blob_info['sha256']: matches.append((at+4,blob))
            need(len(matches)==1,'Unique exact length-prefixed original blob range required')
            blob_offset,blob=matches[0]
            newline=b'\r\n' if b'\r\n' in before else b'\n'
            replacements={'m_ParsedForm':newline.join(('  '+line).encode() for line in identity['lines'])+newline,
                          'platforms':('  platforms: '+uint_hex(fields['Platforms'])).encode()+newline,
                          'compressedBlob':('  compressedBlob: '+blob.hex()).encode()+newline}
            arrays={}
            for field,key in [('offsets','Offsets'),('compressedLengths','CompressedLengths'),('decompressedLengths','DecompressedLengths')]:
                values=fields[key+'_AssetList_AssetList_UInt32']
                need(values and len(values)==len(fields['Platforms']),'Original platform/program dimensions disagree')
                replacements[field]=newline.join([('  '+field+':').encode()]+[('  - '+uint_hex(row)).encode() for row in values])+newline
                decoded=[[value[0] for value in struct.iter_unpack('<I',bytes.fromhex(line[4:]))]
                         for line in replacements[field].decode().splitlines()[1:]]
                need(decoded==values,'Encoded primitive program arrays did not exactly roundtrip')
                arrays[field]=values
            platform_hex=replacements['platforms'].decode().strip().split(': ',1)[1]
            need([x[0] for x in struct.iter_unpack('<I',bytes.fromhex(platform_hex))]==fields['Platforms'],'Encoded platform primitive array differs')
            old=spans(before); candidate=before
            for field in sorted(NAMES,key=lambda item:old[item][0],reverse=True):
                a,b=old[field]; candidate=candidate[:a]+replacements[field]+candidate[b:]
            after=spans(candidate)
            need(strip_fields(candidate)==strip_fields(before),'Bytes outside exact six original shader fields changed')
            need(all(candidate[slice(*after[field])]==replacements[field] for field in NAMES),'Exact original shader field assembly mismatch')
            need(before[slice(*old['m_Dependencies'])]==candidate[slice(*after['m_Dependencies'])],'Existing dependency PPtr block changed')
            target_folder=out/basename.removesuffix('.asset'); target_folder.mkdir()
            target=target_folder/basename; target.write_bytes(candidate)
            target_meta=Path(str(target)+'.meta'); target_meta.write_bytes(meta)
            blob_path=target_folder/'original-compressedBlob.bin'; blob_path.write_bytes(blob)
            comparison=compare(form,target)
            need(comparison['status']=='exact','Entire staged ParsedForm does not equal original model output')
            selection_path=target_folder/'retained-data-source-selection.json'
            selection_path.write_text(json.dumps({'selected_original':entry['original_provenance'],'all_original_variant_comparisons':compared,
                'unique_complete_retained_data_mapping':True,'selection_by_name_alone':False},indent=2)+'\n')
            counts={'properties':sum(x.startswith('    - m_Name:') for x in identity['lines']),
                    'passes':len(identity['passes']),'subprogram_blob_indices':sum(x.lstrip().startswith('m_BlobIndex:') for x in identity['lines']),
                    'partial_CB_rows_original':sum('m_IsPartialCB: 1' in x for x in identity['lines'])}
            receipt={'schema':'original-six-field-shader-candidate/v1','status':'staged_exact_original_data_not_build_or_import_validated',
                     'name':name,'Main_before':pin(main),'Main_meta_before':pin(main_meta),'candidate':pin(target),'candidate_meta':pin(target_meta),
                     'selected_original_model':pin(model_path),'selected_original_object':pin(raw_path),'original_parsed_form':pin(form),
                     'selected_original_container_identity':entry['original_provenance']['original_object'],'selection_proof':pin(selection_path),
                     'replaced_fields':list(NAMES),'all_bytes_outside_six_fields_exact':True,'stripped_unchanged_bytes_sha256':digest(strip_fields(before)),
                     'current_dependency_pptr_block_exact':True,'original_meta_all_bytes_preserved':True,'entire_original_ParsedForm_exact':comparison,
                     'original_program_blob':{'path':str(blob_path),'bytes':size,'sha256':digest(blob),'offset_in_original_object':blob_offset,'unique_length_prefixed_range_matches':True},
                     'platforms':fields['Platforms'],'program_array_dimensions':model['program_array_dimensions'],'program_arrays':arrays,'counts':counts,
                     'no_partial_CB_flags_cleared':True,'no_shader_or_pipeline_substitution':True,'fallback_and_all_other_root_fields_byte_unchanged':True,
                     'Main_modified':False,'Unity_launched':False,'compiler_launched':False,'Main_import_or_player_build_success_claimed':False,'GPU_support_claimed':False,
                     'next_gate':'Real matching Windows shader-only build proof; observer blob0 gate is inconclusive and no Main apply is authorized by this receipt.'}
            receipt_path=target_folder/'report.json'; receipt_path.write_text(json.dumps(receipt,indent=2)+'\n')
            need(sha(main)==main_sha and sha(main_meta)==meta_sha,'Main changed during pure candidate staging')
            report['candidates'].append({'name':name,'receipt':pin(receipt_path),'candidate':pin(target),'candidate_meta':pin(target_meta),
                                          'original_program_blob':receipt['original_program_blob'],'counts':counts})
        report['status']='two_exact_original_six_field_candidates_staged_pending_real_build_gate'
    except BaseException as error:
        report.update(status='stopped_preserve_for_review',error=repr(error))
    finally:
        (out/'report.json').write_text(json.dumps(report,indent=2)+'\n')
        print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'candidates':len(report['candidates']),'error':report.get('error')}),flush=True)
    return 0 if len(report['candidates'])==2 else 1

def main():
    if len(sys.argv)==3 and sys.argv[1]=='--worker': return worker(Path(sys.argv[2]))
    out=ROOT/'AssetRecovery'/('OtherOriginalShaderCandidates-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    run=phase([sys.executable,'-B',str(Path(__file__).resolve()),'--worker',str(out)],out,'bounded-six-field-staging')
    (out/'outer-job-report.json').write_text(json.dumps(run,indent=2)+'\n')
    print(json.dumps({'report':str(out/'report.json'),'outer_job_report':str(out/'outer-job-report.json'),'exit_code':run.get('exit_code'),'peak_job_bytes':run.get('peak_job_bytes'),'error':run.get('error')}),flush=True)
    return 0 if run.get('exit_code')==0 and not run.get('error') else 1

if __name__=='__main__': raise SystemExit(main())
