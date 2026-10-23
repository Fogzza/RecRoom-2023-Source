"""Stage one genuine Editor-layout AG Shader with a proved fallback GUID row.

Consumes an actual successful generated-model typed PathID conversion. Only
recovery staging is written. No Unity, game, SDK or GPU code is executed.
"""
from pathlib import Path
import argparse
import datetime as dt
import hashlib
import importlib.util
import json
import shutil
import struct
import sys
import uuid

HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
CONVERSION=ROOT/'AssetRecovery/OriginalAGGuidDependencyConversion-20261023T024930Z-08353e98'
CONVERSION_SHA='1eda50f379e24fffad0f8f19d498ff6be2fca5733b7d3d22a797bb8396eaf786'
GUID_PROOF=ROOT/'AssetRecovery/RuntimeShaderProofSupplement-20261023T024917Z-26d72acf/genuine-Editor-GUID-remap-proof.json'
GUID_PROOF_SHA='2b4155bc4bc8e78ace255698152c332534c123db7e9b245005e7e2645d89a356'
BASE=HERE/'stage_editor_shader_native_input.py'
BASE_SHA='abd134a9272de3365a3b492228e66bf526dffcd07bdae2851e6a1b6b5269c455'
AG_META=WS/'RR23/Assets/Shader/AG_Standard-Opaque.asset.meta'
AG_META_SHA='2aec33e50f23c224798affbba08b769a6171162063032e02963bd97560e018f0'
FALLBACK_META=WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_FallbackError.asset.meta'
FALLBACK_META_SHA='3c257fa4a38c8992e1aac730964f0a38d1c48ad3b8b48274db754ac68b3a39fe'
RAW_GUID='2d5a35c6846f9e419f00be31aef2d486'
FALLBACK_GUID='d2a5536c48f6e914f900eb13ea2f4d68'
AG_GUID='90510347b31afb84fba058c6708c7f5c'


def need(value,message):
    if not value:raise RuntimeError(message)


def sha(path):
    with Path(path).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()


def pin(path):return {'path':str(Path(path).resolve(strict=True)),'bytes':Path(path).stat().st_size,'sha256':sha(path)}


def check(path,digest):
    need(sha(path)==digest,'Pinned genuine conversion/GUID input changed: '+str(path));return pin(path)


def load_base():
    check(BASE,BASE_SHA)
    spec=importlib.util.spec_from_file_location('genuine_editor_shader_metadata_wrapper_only',BASE)
    base=importlib.util.module_from_spec(spec);spec.loader.exec_module(base);return base


def make_wrapper(header,parsed,typ,payload,parser):
    metadata=bytearray(parsed['prefix']);metadata+=struct.pack('<i',1)+typ['raw'];metadata+=struct.pack('<i',1)
    metadata+=bytes((-len(metadata))%4);metadata+=struct.pack('<qqIi',4800000,0,len(payload),0)
    metadata+=struct.pack('<ii',0,1)  # no script types; exactly one external row
    metadata+=b'\0'+bytes.fromhex(RAW_GUID)+struct.pack('<i',2)+b'\0'  # empty asset path, proved raw GUID/type, empty path
    metadata+=struct.pack('<i',0)+parsed['user_raw']  # no reference types; genuine user information
    start=(48+len(metadata)+15)&~15;data=payload+bytes((-len(payload))%8);size=start+len(data)
    output_header=bytearray(header);struct.pack_into('>Iqq',output_header,20,len(metadata),size,start)
    need(output_header[:20]==header[:20] and output_header[40:]==header[40:],'Only header metadata/file/data sizes may change')
    result=bytes(output_header)+metadata+bytes(start-48-len(metadata))+data
    verify=parser.parse_metadata(bytes(metadata),start,size)
    need(verify['prefix']==parsed['prefix'] and verify['user_raw']==parsed['user_raw'] and len(verify['types'])==len(verify['objects'])==1,'Exact genuine singleton metadata required')
    need(verify['types'][0]['raw']==typ['raw'] and verify['script_type_count']==verify['ref_type_count']==0,'Genuine Class48 tree/no scripts required')
    need(verify['externals']==[{'asset_path_hex':'','guid_hex':RAW_GUID,'type':2,'path_hex':''}],'Exact one-based fallback GUID external row required')
    obj=verify['objects'][0]
    need(obj['path_id']==4800000 and obj['type_index']==0 and obj['size']==len(payload) and result[obj['offset']:obj['offset']+obj['size']]==payload,'Entire Editor payload/table4800000 required')
    return result,{'metadata_bytes':len(metadata),'data_offset':start,'file_bytes':size,'object_count':1,'class_ids':[48],'path_ids':[4800000],
                   'external_rows':verify['externals'],'script_type_count':0,'ref_type_count':0,'typed_dependency':{'file_id':1,'path_id':4800000}}


def worker(out):
    base=load_base();parser=base.load_parser()
    need(out.is_relative_to(ROOT/'AssetRecovery') and out.name.startswith('OriginalAGEditorGuidWrapper-'),'Recovery-only fresh destination required')
    report={'schema':'original-AG-Editor-native-wrapper-with-proved-fallback-GUID/v1','status':'starting','Main_modified':False,'Unity_launched':False,'native_API_or_GPU_or_game_code_executed':False}
    try:
        conversion_pin=check(CONVERSION/'run-report.json',CONVERSION_SHA);conversion=json.loads((CONVERSION/'run-report.json').read_bytes())
        need(conversion['status']=='AG_single_typed_PathID_remap_and_fallback_exact_roundtrip_passed' and len(conversion['phases'])==2,'Actual two-phase typed generated remap proof required')
        for phase in conversion['phases']:
            need(phase['exit_code']==0 and phase['owned_child_exit_confirmed'] and phase['launcher']['membership_verified_before_resume'] and phase['launcher']['resume_previous_suspend_count']==1,'Both generated conversion phases must pass in owned jobs')
        result=conversion['results']['AG'];payload_pin=check(Path(result['editor_payload']['path']),result['editor_payload']['sha256'])
        need(payload_pin['bytes']==6552199 and payload_pin['sha256']=='1315a20b4b063571590aa6a4e6e5a69d23a115d336911a602e7942bba042c1fb','Exact actual mapped AG Editor bytes required')
        check(Path(result['report']['path']),result['report']['sha256']);proof=json.loads(Path(result['report']['path']).read_bytes())
        need(proof['all_bytes_except_name_and_authorized_typed_PathID_equal'] and proof['typed_PathID_remapped'] and proof['authorized_PathID_bytes']==8 and proof['external_FileIDs_unchanged']
             and proof['entire_ParsedForm_equal'] and proof['all_five_original_program_fields_equal'] and proof['editor_consumed_bytes']==proof['editor_bytes']==payload_pin['bytes'],'Exact narrow semantic mutation proof required')
        payload=Path(payload_pin['path']).read_bytes();original=(CONVERSION/'AG-OriginalRelease.bin').read_bytes();release=Path(result['normalized_release']['path']).read_bytes()
        need(hashlib.sha256(original).hexdigest()=='b7a537500bf6b84af05ea8c49110b291f1fb3d7e26eab787d0be2f3bd0433074','Exact original AG6351 release bytes required')
        old_end=4;new_length=struct.unpack_from('<i',release)[0];new_end=(4+new_length+3)&~3
        expected=bytearray(original[old_end:]);need(struct.unpack_from('<iiq',original,len(original)-24)==(1,1,32),'Original typed AG tail must match independent native parser')
        struct.pack_into('<q',expected,len(original)-16-old_end,4800000)
        need(new_length==18 and release[4:22]==b'AG/Standard-Opaque' and release[new_end:]==bytes(expected),'Independent original release byte proof except leading name/typed8-bytePathID required')
        guid_pin=check(GUID_PROOF,GUID_PROOF_SHA);guid=json.loads(GUID_PROOF.read_bytes());capture=Path(guid['frozen_exact_capture']['path'])
        capture_pin=check(capture,guid['frozen_exact_capture']['sha256']);raw=capture.read_bytes()
        need(len(raw)==5633 and raw[5252:5268].hex()==RAW_GUID and struct.unpack_from('<i',raw,5268)[0]==2
             and struct.unpack_from('<iq',raw,5420)==(2,4800000),'Genuine Editor serialized GUID and typed PPtr evidence required')
        need(guid['Main_fallback_text_GUID']==FALLBACK_GUID and guid['same_fallback_raw_GUID_bytes']==RAW_GUID,'Genuine GUID authority mismatch')
        meta_pin=check(AG_META,AG_META_SHA);fallback_meta_pin=check(FALLBACK_META,FALLBACK_META_SHA)
        need(('guid: '+AG_GUID) in AG_META.read_text() and ('guid: '+FALLBACK_GUID) in FALLBACK_META.read_text(),'Original Main GUID identities required')
        header,parsed,typ,source=base.inspect_source(out,parser);data,shape=make_wrapper(header,parsed,typ,payload,parser)
        target=out/'AG_Standard-Opaque-EditorGuidBound.asset';target.write_bytes(data);shutil.copyfile(AG_META,Path(str(target)+'.meta'))
        persisted=target.read_bytes();meta_size,file_size,start,_=struct.unpack_from('>Iqqq',persisted,20)
        decoded=parser.parse_metadata(persisted[48:48+meta_size],start,file_size)
        need(decoded['externals']==shape['external_rows'] and persisted[decoded['objects'][0]['offset']:decoded['objects'][0]['offset']+len(payload)]==payload and sha(Path(str(target)+'.meta'))==AG_META_SHA,'Persisted native wrapper/meta must match proof')
        report.update(status='staged_pure_AG_Editor_wrapper_exact_typed_fallback_GUID_dependency_native_import_UNTESTED',
            successful_generated_conversion=conversion_pin,AG_conversion_report=result['report'],AG_editor_payload=payload_pin,
            original_ParsedForm_sha256=result['ParsedForm']['sha256'],original_compiled_blob=result['compiled_blob'],
            genuine_GUID_proof=guid_pin,genuine_GUID_capture=capture_pin,genuine_Editor_type_source=source,
            original_AG_meta=meta_pin,expected_fallback_meta=fallback_meta_pin,
            fallback_Unity_GUID=FALLBACK_GUID,external_native_GUID_hex=RAW_GUID,AG_Unity_GUID=AG_GUID,
            output={**pin(target),**shape},output_meta=pin(Path(str(target)+'.meta')),
            actual_Editor_GetDependencies_or_GUID_identity_or_BuildPlayer_or_GPU_tested=False,
            limitations=['Native Editor import must prove exact AG/Fallback objects and GUID/localIDs; this pure wrapper proves bytes/metadata only.',
                         'Fallback binary resource with original GUID d2a5536c48f6e914f900eb13ea2f4d68 and localID4800000 must exist in the isolated fixture.',
                         'Original release namespace FileID1 Path32 is changed only to the authorized GUID-bound fixture target. This is not a Main mutation or a future player-local remapping proof.'])
    except BaseException as error:report.update(status='failed_preserve_for_review',error=str(error))
    (out/'report.json').write_text(json.dumps(report,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'status':report['status'],'report':str(out/'report.json'),'report_sha256':sha(out/'report.json'),'output':report.get('output'),'output_meta':report.get('output_meta'),'error':report.get('error')}))
    return 1 if report.get('error') else 0


def main():
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--_worker',type=Path,help=argparse.SUPPRESS);args=parser.parse_args()
    if args._worker:return worker(args._worker.resolve(strict=True))
    out=ROOT/'AssetRecovery'/('OriginalAGEditorGuidWrapper-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    import read_original_ag_shader_models as guard
    guard.CAP=256*1024**2
    job=guard.phase([sys.executable,'-B',str(Path(__file__).resolve()),'--_worker',str(out)],out,'pure-generated-AG-GUID-native-wrapper')
    (out/'outer-job-report.json').write_text(json.dumps(job,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'status':'pure_wrapper_job_completed' if job.get('exit_code')==0 and not job.get('error') else 'failed_guard_or_wrapper',
                      'report':str(out/'report.json'),'report_sha256':sha(out/'report.json') if (out/'report.json').exists() else None,
                      'job_report':str(out/'outer-job-report.json'),'job_report_sha256':sha(out/'outer-job-report.json'),'peak_job_bytes':job.get('peak_job_bytes'),'error':job.get('error')}))
    return 0 if job.get('exit_code')==0 and not job.get('error') else 1


if __name__=='__main__':raise SystemExit(main())
