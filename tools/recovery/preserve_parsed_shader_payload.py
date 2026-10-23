"""Preserve the model-proven original byte array without loading managed tools."""
import hashlib,json,shutil,struct
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2]
OUT=WS/'Recovery/RecRoom-2023-04-18/AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
record=OUT/'Object/report.json';r=json.loads(record.read_text())
if r['status']!='parsed_entire_original_object' or r['consumed_bytes']!=r['total_bytes'] or r['engine']!='2020.3.33f1' or not r['no_pointer_yaml']:raise ValueError('Model evidence failed')
src=Path(r['source']);raw=src.read_bytes();digest=lambda b:hashlib.sha256(b).hexdigest()
if digest(raw)!=r['source_sha256']:raise ValueError('Original bounded object changed')
blob=r['fields']['compressedBlob'];prefix=struct.pack('<I',blob['bytes']);matches=[];start=0
while True:
 at=raw.find(prefix,start)
 if at<0:break
 start=at+1;data=raw[at+4:at+4+blob['bytes']]
 if len(data)==blob['bytes'] and digest(data)==blob['sha256']:matches.append((at+4,data))
if len(matches)!=1:raise ValueError('Model-proven blob not uniquely backed by original bytes')
target=OUT/'Object/original-compressedBlob.bin'
with target.open('xb') as stream:stream.write(matches[0][1])
snapshot=OUT/'OriginalShaderObjectProbe.cs';shutil.copyfile(HERE/snapshot.name,snapshot)
result={'schema':'original-shader-model-payload-provenance/v1','status':'original_payload_preserved',
 'input_model_report':{'path':str(record),'sha256':digest(record.read_bytes())},
 'original_object':{'path':str(src),'sha256':digest(raw)},
 'blob':{'path':str(target),'bytes':blob['bytes'],'sha256':digest(target.read_bytes()),'offset_in_original_object':matches[0][0]},
 'unique_length_prefixed_original_range_matches_model_proven_hash':True,
 'compiled_reader_source_snapshot':{'path':str(snapshot),'sha256':digest(snapshot.read_bytes())},
 'parsed_form_equivalence':'Refused: seven global keyword masks and two FOG name indices are absent from current export.',
 'complete_original_shader_candidate_written':False,'Main_modified':False,'Unity_launched':False,
 'next_safe_step':'Reviewed isolated staged original ParsedForm+five program fields, preserving other bytes and source .meta, followed by matching2020.3.33f1 import/program retention checks.'}
path=OUT/'payload-provenance.json';path.write_text(json.dumps(result,indent=2)+'\n');print(json.dumps({'report':str(path),'blob':result['blob']}))
