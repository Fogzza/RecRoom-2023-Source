"""Stage six model-proven original fields; never edit the live project."""
from pathlib import Path
import datetime as dt,difflib,hashlib,json,re,struct,uuid
from compare_shader_parsed_form import field_lines
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
PROBE=ROOT/'AssetRecovery/OriginalShaderModelProbe-20261022T192955Z-851f2959'
MAIN=WS/'RR23/Assets/Shader/Hidden_Universal Render Pipeline_StencilDeferred.asset'
EXPECTED_MAIN='0b42b068f494eb30a07db27589a43b60314fa609ac11be68e87fa592e7735f51'
NAMES=('m_ParsedForm','platforms','offsets','compressedLengths','decompressedLengths','compressedBlob')
def sha(b):return hashlib.sha256(b).hexdigest()
def record(p):return {'path':str(p),'bytes':p.stat().st_size,'sha256':sha(p.read_bytes())}
def spans(raw):
 rows=raw.splitlines(keepends=True);offset=0;found=[]
 for row in rows:
  hit=re.match(rb'^  ([A-Za-z_][A-Za-z_0-9]*):',row)
  if hit:found.append((hit.group(1).decode(),offset))
  offset+=len(row)
 result={}
 for i,(name,start) in enumerate(found):
  if name in result:raise ValueError('Duplicate shader root field '+name)
  result[name]=(start,found[i+1][1] if i+1<len(found) else len(raw))
 if not all(n in result for n in NAMES):raise ValueError('Missing root field')
 return result
def strip_fields(raw):
 s=spans(raw)
 for a,b in sorted([s[n] for n in NAMES],reverse=True):raw=raw[:a]+raw[b:]
 return raw
def uint_hex(values):
 if not all(isinstance(x,int) and 0<=x<=0xffffffff for x in values):raise ValueError('uint32 data required')
 return b''.join(struct.pack('<I',x) for x in values).hex()
def main():
 original=MAIN.read_bytes();meta=MAIN.with_suffix('.asset.meta');meta_before=meta.read_bytes()
 if sha(original)!=EXPECTED_MAIN:raise ValueError('Live shader changed; no stale candidate')
 model_path=PROBE/'Object/report.json';model=json.loads(model_path.read_text());fields=model['fields']
 if model['status']!='parsed_entire_original_object' or model['engine']!='2020.3.33f1' or model['actual_name']!='Hidden/Universal Render Pipeline/StencilDeferred' or model['consumed_bytes']!=102516 or model['total_bytes']!=102516 or not model['no_pointer_yaml']:raise ValueError('Exact model proof refused')
 classification=PROBE/'parsed-form-difference-classification.json';diff=json.loads(classification.read_text())
 if diff['substantive_hunk_count']!=8:raise ValueError('ParsedForm differences changed')
 if any('m_GlobalKeywordMask:' not in '\n'.join(h['original_lines']) and h['original_lines']!=['        FOG_EXP: 4','        FOG_EXP2: 5'] for h in diff['substantive_hunks']):raise ValueError('Unreviewed structural change')
 form=PROBE/'Object/ParsedForm.yaml'
 if sha(form.read_bytes())!=model['parsed_form']['sha256']:raise ValueError('Original ParsedForm changed')
 lines=field_lines(form,'m_ParsedForm');blob_path=PROBE/'Object/original-compressedBlob.bin';blob=blob_path.read_bytes()
 if len(blob)!=fields['compressedBlob']['bytes'] or sha(blob)!=fields['compressedBlob']['sha256']:raise ValueError('Original blob changed')
 # The stock pinned YamlWalker uses NumericListNode<T>/ReverseHexString for
 # primitive integer arrays. For UInt32, that emits each LE four-byte value.
 newline=b'\r\n' if b'\r\n' in original else b'\n'
 replacements={'m_ParsedForm':newline.join(('  '+line).encode() for line in lines)+newline,
  'platforms':('  platforms: '+uint_hex(fields['Platforms'])).encode()+newline,
  'compressedBlob':('  compressedBlob: '+blob.hex()).encode()+newline}
 for name,key in [('offsets','Offsets'),('compressedLengths','CompressedLengths'),('decompressedLengths','DecompressedLengths')]:
  values=fields[key+'_AssetList_AssetList_UInt32']
  if not values or len(values)!=len(fields['Platforms']):raise ValueError('Nested array platform dimensions')
  replacements[name]=newline.join([('  '+name+':').encode()]+[('  - '+uint_hex(row)).encode() for row in values])+newline
 s=spans(original);candidate=original
 for name in sorted(NAMES,key=lambda x:s[x][0],reverse=True):
  a,b=s[name];candidate=candidate[:a]+replacements[name]+candidate[b:]
 if strip_fields(candidate)!=strip_fields(original):raise ValueError('Unrelated byte modification')
 after=spans(candidate)
 for name in NAMES:
  a,b=after[name]
  if candidate[a:b]!=replacements[name]:raise ValueError('Field assembly mismatch '+name)
 # Re-decode every generated primitive byte form and compare exact model data.
 for name,key in [('offsets','Offsets'),('compressedLengths','CompressedLengths'),('decompressedLengths','DecompressedLengths')]:
  encoded=replacements[name].decode().splitlines()[1:]
  decoded=[[n[0] for n in struct.iter_unpack('<I',bytes.fromhex(line[4:]))] for line in encoded]
  if decoded!=fields[key+'_AssetList_AssetList_UInt32']:raise ValueError('Generated array did not roundtrip')
 platform_bytes=bytes.fromhex(replacements['platforms'].decode().strip().split(': ',1)[1])
 if [n[0] for n in struct.iter_unpack('<I',platform_bytes)]!=fields['Platforms']:raise ValueError('Platform bytes failed')
 out=ROOT/'AssetRecovery'/('OriginalStencilShaderCandidate-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 target=out/MAIN.name;target.write_bytes(candidate);target_meta=target.with_suffix('.asset.meta');target_meta.write_bytes(meta_before)
 patch=out/'six-original-fields.patch';patch.write_text(''.join(difflib.unified_diff(original.decode().splitlines(True),candidate.decode().splitlines(True),fromfile='Main/'+MAIN.name,tofile='Candidate/'+MAIN.name)))
 if MAIN.read_bytes()!=original or meta.read_bytes()!=meta_before:raise ValueError('Main input changed during staging')
 boundary=b''.join(original[a:b] for name,(a,b) in s.items() if name not in NAMES)
 counts={'properties':sum(line.startswith('    - m_Name:') for line in lines),
  'subshaders':sum(line.startswith('  - m_Passes:') for line in lines),
  'passes':sum(line.startswith('    - m_EditorDataHash:') for line in lines),
  'subprogram_blob_indices':sum(line.lstrip().startswith('m_BlobIndex:') for line in lines),
  'original_global_keyword_masks':sum('m_GlobalKeywordMask:' in line and line.split(':',1)[1].strip()!='' for line in lines)}
 report={'schema':'original-stencil-shader-six-field-candidate/v1','status':'staged_original_data_only_not_import_validated',
  'model_input':record(model_path),'original_object':record(Path(model['source'])),
  'original_parsed_form':record(form),'difference_classification':record(classification),
  'Main_before':record(MAIN),'Main_meta_before':record(meta),'candidate':record(target),'candidate_meta':record(target_meta),'patch':record(patch),
  'replaced_fields':list(NAMES),'field_spans':[{'name':name,'Main_start':s[name][0],'Main_end':s[name][1],'candidate_start':after[name][0],'candidate_end':after[name][1],'original_field_sha256':sha(original[s[name][0]:s[name][1]]),'candidate_field_sha256':sha(replacements[name])} for name in NAMES],
  'all_bytes_outside_six_fields_identical':True,'stripped_unchanged_bytes_sha256':sha(strip_fields(original)),
  'dependency_pptr_byte_block_preserved':original[s['m_Dependencies'][0]:s['m_Dependencies'][1]]==candidate[after['m_Dependencies'][0]:after['m_Dependencies'][1]],
  'meta_all_bytes_preserved':True,'structure_counts':counts,'platforms':fields['Platforms'],
  'platform_uint32_LE_hex':platform_bytes.hex(),'nested_array_dimensions':model['program_array_dimensions'],
  'program_fields':{name:replacements[name].decode().strip() if name!='compressedBlob' else {'bytes':len(blob),'sha256':sha(blob)} for name in NAMES if name!='m_ParsedForm'},
  'serialization_rule_sources':[record(WS/'AR23Tool/Source/Source/AssetRipper.Export.UnityProjects/YamlWalker.cs'),record(WS/'AR23Tool/Source/Source/AssetRipper.Yaml/YamlScalarNode.NumericListNode.cs'),record(WS/'AR23Tool/Source/Source/AssetRipper.Yaml/Extensions/ReverseHexString.cs')],
  'next_gate':'Isolated matchingUnity2020.3.33f1 import and retained-program/keyword verification. Main apply is not authorized by this report.',
  'Main_modified':False,'Unity_launched':False,'managed_child_launched':False,
  'tool':record(Path(__file__))}
 (out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'candidate':str(target),'counts':counts}))
if __name__=='__main__':main()
