"""Hash actual current source files; bind native definitions to proven source maps.

Source absence and body absence remain distinct. No recovery is inferred from a
nonempty C# body or from a generated name. No project file is modified.
"""
from pathlib import Path
import collections,datetime as dt,hashlib,json,re,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';PROJECT=WS/'RR23';sys.path.insert(0,str(HERE.parent));from metadata_projection_subset import array_rows
NATIVE=ROOT/'Validation/AllOriginalScripts-20261022T145115Z-25a68695/report.json';MANIFEST=ROOT/'CompilerRepairs/RuntimeSourcePlacementProjection-20261022T104037Z-a6651f58/metadata-restoration.json';GENERATED=ROOT/'Validation/unmatched-original-types-classification.json';MISSING=ROOT/'Validation/CoreExtraAudit-20261022T111140Z/missing-originals.json';RAW_METHODS=ROOT/'Validation/CoreMethodFlagsInventory-20261022T110755Z-0be64abb/raw-core-methods.jsonl'
def need(b,s):
 if not b:raise ValueError(s)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def dump(f,r):f.write(json.dumps(r,separators=(',',':'))+'\n')
def main():
 native=json.loads(NATIVE.read_text());need(native['unaccounted_types']==native['unaccounted_methods']==0,'Native inventory incomplete');out=NATIVE.parent/('CurrentSources-'+dt.datetime.now(dt.timezone.utc).strftime('%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);need(not out.exists(),'Fresh source accounting output only');out.mkdir();before={p.relative_to(PROJECT).as_posix():{'path':str(p),'sha256':sha(p),'size':p.stat().st_size,'meta':str(p)+'.meta','meta_sha256':sha(str(p)+'.meta') if Path(str(p)+'.meta').is_file() else None} for p in (PROJECT/'Assets').rglob('*.cs')};mapped={};mappedfiles=set()
 for row in array_rows(MANIFEST,'source_type_inventory'):
  need(row['original_full_name'] not in mapped,'Duplicate source-native type identity');need(row['source_path'] in before,'Source mapping points to missing current source');mapped[row['original_full_name']]=row;mappedfiles.add(row['source_path'])
 generated=json.loads(GENERATED.read_text());generatedmap={r['original_full_name']:r for r in generated['types'] if r['native_type_found']};need(len(generatedmap)==709,'Expected exact709 genuine generated source gaps');missing=json.loads(MISSING.read_text());need(len(missing)==683,'Expected683 emitted-type method gaps');wanted={(r['owner'],r['original']):r for r in missing};found={}
 with RAW_METHODS.open() as f:
  for line in f:
   row=json.loads(line);key=(row['owner'],row['canonical_signature'])
   if key in wanted:need(key not in found,'Ambiguous original token witness');found[key]={'image':'Assembly-CSharp.dll','owner':row['owner'],'original_method_token':row['original_native_token'],'canonical_signature':row['canonical_signature'],'source_type_present':True,'managed_method_absent_in_validated_emitted_subset':True,'reason':'original_static_constructor_not_emitted' if row['name']=='.cctor' else 'original_callback_not_emitted','method_name':row['name']}
 need(len(found)==len(wanted),'Some explicit method gaps lack original token witness')
 with (out/'missing-emitted-methods-original-tokens.jsonl').open('w') as f:
  for r in sorted(found.values(),key=lambda r:int(r['original_method_token'],16)):dump(f,r)
 firstpass=[(key,Path(row['path']).read_text(encoding='utf-8-sig')) for key,row in before.items() if key.startswith('Assets/Plugins/Assembly-CSharp-firstpass/') and not key.endswith('/AssemblyInfo.cs')];counts=collections.Counter();missingtypes=[]
 with (out/'source-files.jsonl').open('w') as f:
  for rel,row in sorted(before.items()):
   category='original_core_CSharp' if rel.startswith('Assets/Scripts/Assembly-CSharp/') else 'original_firstpass_CSharp' if rel.startswith('Assets/Plugins/Assembly-CSharp-firstpass/') else 'recovery_Editor_helper_not_original';dump(f,{'relative_path':rel,**row,'source_role':category,'original_type_map_present':rel in mappedfiles});counts['files:'+category]+=1
 with (out/'native-types-source-presence.jsonl').open('w') as dest:
  for image in native['images']:
   need(sha(image['types']['path'])==image['types']['sha256'],'Native type inventory changed')
   with Path(image['types']['path']).open() as f:
    for line in f:
     row=json.loads(line);name=row['full_name'];record={k:row[k] for k in ['image','image_index','native_type_index','original_type_token','full_name','method_count']};record['managed_runtime_presence']='separate_runtime_metadata_join_pending';record['body_status']='not_inferred_from_source_presence'
     if name=='<Module>':record['source_status']='metadata_module_not_a_CSharp_class'
     elif image['image']=='Assembly-CSharp.dll':
      if name in mapped:record.update(source_status='original_type_source_present',source_path=mapped[name]['source_path'],source_sha256=before[mapped[name]['source_path']]['sha256'],identity_proof='pinned_original_to_source_type_inventory')
      else:
       need(name in generatedmap,'Unexpected previously unaccounted original core type');g=generatedmap[name];need(g['metadata_type_index']==row['native_type_index'] and int(g['original_token_hex'],16)==int(row['original_type_token'],16) and g['original_method_count']==row['method_count'],'Generated-gap original index/token/count mismatch');record.update(source_status='original_generated_type_absent_from_editable_source',absence_category=g['category'],original_methods_not_recovered=row['method_count']);missingtypes.append(record)
     elif image['image']=='Assembly-CSharp-firstpass.dll':
      outer=name.split('/')[0];ns,_,outername=outer.rpartition('.');leaf=name.split('/')[-1] if '/' in name else outername;hits=[]
      for rel,text in firstpass:
       namespaces=re.findall(r'^\s*namespace\s+([A-Za-z_][A-Za-z0-9_.]*)\s*\{',text,re.M);decl=lambda value:len(re.findall(r'^\s*(?:(?:public|protected|internal|private|abstract|static|sealed|partial)\s+)*(?:class|struct|enum|interface)\s+'+re.escape(value)+r'\b',text,re.M))
       if namespaces==([ns] if ns else []) and decl(outername)==1 and (leaf==outername or decl(leaf)==1):hits.append(rel)
      need(len(hits)==1,'Firstpass original source declaration is absent/nonunique: '+name);record.update(source_status='original_type_source_present',source_path=hits[0],source_sha256=before[hits[0]]['sha256'],identity_proof='exact_namespace_and_unique_literal_outer_nested_type_declarations')
     else:record['source_status']='binary_assembly_no_editable_CSharp_in_RR23'
     counts['types:'+record['source_status']]+=1;dump(dest,record)
 need(sum(r['original_methods_not_recovered'] for r in missingtypes)==3778,'Generated-type method gap total differs');need(counts['types:original_type_source_present']==12423,'Original source-type count differs')
 for row in before.values():need(sha(row['path'])==row['sha256'] and (sha(row['meta']) if row['meta_sha256'] else None)==row['meta_sha256'],'Source/meta changed during source accounting')
 inputs=[NATIVE,MANIFEST,GENERATED,MISSING,RAW_METHODS];report={'schema':'all-original-script-current-source-accounting/v1','status':'source_accounting_complete_explicit_gaps_runtime_body_join_pending','inputs':[{'path':str(p),'sha256':sha(p)} for p in inputs],'native_images':native['original_images'],'native_types_accounted':native['original_types'],'native_methods_accounted':native['original_methods'],'current_CSharp_files':len(before),'counts':dict(counts),'original_core_source_types':len(mapped),'original_core_source_files_with_types':len(mappedfiles),'genuine_original_generated_types_missing_source':len(missingtypes),'genuine_original_generated_methods_unrecovered':3778,'original_emitted_type_methods_absent':683,'emitted_type_method_gap_kinds':dict(collections.Counter(r['reason'] for r in found.values())),'body_completion_claim':False,'limitations':['Binary-only type metadata is not editable source or recovered behavior.','Source declarations can contain empty/default-return stubs. Native-proved applied bodies require separate exact original token/body/journal evidence.','The683 emitted-type gaps and709 generated-type gaps are retained as missing work, never synthesized or silently excluded.','Current runtime/plugin/engine method body classifications are a separate pending step.'],'project_modified':False,'game_code_executed':False};(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'source_types':counts['types:original_type_source_present'],'source_files':len(before),'missing_generated_types':709,'missing_generated_methods':3778,'missing_emitted_methods':683,'unexpected_missing_types':0}))
if __name__=='__main__':main()
