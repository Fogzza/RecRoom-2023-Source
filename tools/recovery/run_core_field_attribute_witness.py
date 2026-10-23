"""Read-only bounded raw/old/native core FieldDef serialization ownership audit."""
import datetime as dt, importlib.util, json, mmap, shutil, sqlite3, struct, sys, uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent
spec=importlib.util.spec_from_file_location('field_guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
VARIANT=HERE.parent/'PluginNativeFlagsInventory/ArrayVariant-20261022T101556Z'
TARGETS={'UnityEngine.SerializeField','UnityEngine.SerializeReference'}
def need(ok,message):
 if not ok:raise ValueError(message)
def check_contract(raw,native):
 need(raw['original_field_token']==native['token'],'Original FieldDef token differs')
 need(raw['original_owner_token']==native['owner_token'],'Original TypeDef token differs')
 need((raw['owner'],raw['name'])==(native['owner'],native['name']),'Exact original field ownership/name differs')
 need(raw['raw_shape']==native['shape'] and native['shape_error'] is None,'Raw/native exact scoped TypeSpec differs or unsupported')
 oldattrs=raw['old_serialization_attributes'];need(oldattrs is not None,'Old attribute owner absent')
 expected=sorted(native['serialization_attributes'],key=lambda x:(x['name'],x['assembly']))
 actual=sorted([{'name':a['name'],'assembly':a['assembly']} for a in oldattrs],key=lambda x:(x['name'],x['assembly']))
 need(actual==expected,'Old serialization attribute presence/scope differs from original native')
 for attribute in oldattrs:
  need(attribute['blob']=='01000000' and not any(attribute[k] for k in ('constructor_parameter_count','constructor_argument_count','named_field_count','named_property_count')),'Only exact noarg/no-named-value original serialization markers admitted')
def native_join(out):
 spec=importlib.util.spec_from_file_location('native_field_shapes',VARIANT/'inventory_native_plugin_method_flags_arrays.py');n=importlib.util.module_from_spec(spec);spec.loader.exec_module(n)
 paths=[]
 for relative,expected in n.INPUTS.items():p=g.ROOT/'CodeSource'/relative;need(g.sha(p)==expected,'Original source SHA differs');paths.append(p)
 db=sqlite3.connect(out/'native-field-index.sqlite');db.execute('pragma cache_size=-8192');db.execute('create table fields(token text primary key,row text)')
 count=0
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as binary,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as metadata:
  v=n.NativeMetadata(binary,metadata);shapes=n.Shapes(v);images=[i for i in v.images if i['name']=='Assembly-CSharp.dll'];need(len(images)==1,'Original core image not unique');image=images[0];imageAt=v.row('images',image['index'],40);start,length=struct.unpack_from('<iI',metadata,imageAt+32);attributes={}
  for ai in range(start,start+length):
   at=v.row('attributesInfo',ai,12);token,first,amount=struct.unpack_from('<Iii',metadata,at);need(token not in attributes,'Duplicate original attribute token');values=[]
   for j in range(first,first+amount):
    nativeIndex=v.i32(metadata,v.row('attributeTypes',j,4));nativeType=v.native_type(nativeIndex);need(nativeType['kind'] in (17,18),'Original attribute must be named type');ti=nativeType['data'];name=v.full_name(ti)
    if name in TARGETS:values.append({'name':name,'assembly':shapes.image_by_type[ti]})
   if values:attributes[token]=values
  with (out/'native-core-fields.jsonl').open('w',encoding='utf-8') as target:
   for ti in range(image['start'],image['start']+image['count']):
    td=v.row('typeDefinitions',ti,88);owner=v.full_name(ti);ownerToken='0x'+format(v.u32(metadata,td+84),'08x');first=v.i32(metadata,td+32);amount=v.u16(metadata,td+68)
    for fi in range(first,first+amount):
     at=v.row('fields',fi,12);token=v.u32(metadata,at+8);need(token>>24==4,'Native FieldDef table differs');typeIndex=v.i32(metadata,at+4);shape=None;error=None
     try:shape=shapes.index(typeIndex)
     except (ValueError,IndexError,struct.error) as e:error=str(e)
     row={'token':'0x'+format(token,'08x'),'owner_token':ownerToken,'owner':owner,'name':v.string(v.i32(metadata,at)),'shape':shape,'shape_error':error,'flags':v.native_type(typeIndex)['attributes'],'metadata_field_index':fi,'local_ordinal':fi-first,'native_type_index':typeIndex,'serialization_attributes':attributes.get(token,[])}
     text=json.dumps(row,separators=(',',':'));target.write(text+'\n');db.execute('insert into fields values(?,?)',(row['token'],text));count+=1
 db.commit();seen=set();errors=[];mismatches=[];rawAttrDifferences=[];flagsDifferences=[];exact=0;attrs=0;role=[];fixtureRows=None
 with (out/'raw-core-fields.jsonl').open(encoding='utf-8') as stream:
  for line in stream:
   raw=json.loads(line);token=raw['original_field_token'];rows=db.execute('select row from fields where token=?',(token,)).fetchall() if token else []
   if raw['error'] or len(rows)!=1:errors.append({'raw':raw,'reason':'Old original-token witness or native token missing/ambiguous'});continue
   native=json.loads(rows[0][0])
   try:need(token not in seen,'Duplicate original field token witness');check_contract(raw,native)
   except ValueError as e:errors.append({'raw':raw,'native':native,'reason':str(e)});continue
   seen.add(token);exact+=1;attrs+=len(native['serialization_attributes'])
   if raw['raw_flags']!=native['flags']:flagsDifferences.append({'owner':raw['owner'],'name':raw['name'],'token':token,'raw':raw['raw_flags'],'native':native['flags']})
   if raw['raw_serialization_attributes']!=raw['old_serialization_attributes']:rawAttrDifferences.append({'owner':raw['owner'],'name':raw['name'],'token':token,'raw_attributes':raw['raw_serialization_attributes'],'old_attributes':raw['old_serialization_attributes']})
   if raw['raw_canonical_type']!=raw['old_canonical_type']:
    mismatches.append({'assembly':'Assembly-CSharp','owner':raw['owner'],'name':raw['name'],'original_owner_token':raw['original_owner_token'],'native_original_field_token':token,'raw_provider_field_cli_token':raw['raw_cli_token'],'old_provider_field_cli_token':raw['old_cli_token'],'old_original_token_attribute':token,'raw_canonical_type':raw['raw_canonical_type'],'old_canonical_type':raw['old_canonical_type'],'raw_shape':raw['raw_shape'],'old_shape':raw['old_shape'],'native_shape':native['shape'],'native_type_index':native['native_type_index'],'native_metadata_field_index':native['metadata_field_index'],'native_local_ordinal':native['local_ordinal'],'serialization_attributes':raw['old_serialization_attributes'],'native_serialization_attributes':native['serialization_attributes'],'exact_native_token_owner_name_raw_typespec_proven':True,'old_provider_attribute_ownership_only':True})
   if 'RolePermissionEditableBase' in raw['owner'] and raw['name']=='permission':role.append({'raw':raw,'native':native})
   if fixtureRows is None and native['serialization_attributes']:fixtureRows=(raw,native)
 missing=[json.loads(row) for token,row in db.execute('select token,row from fields') if token not in seen];db.close();checks=[]
 if fixtureRows:
  original,native=fixtureRows;check_contract(original,native);checks.append({'case':'exact native old token/owner/name/rawTypeSpec and attributes','passed':True})
  mutations=[('wrongFieldToken',lambda r:r.update(original_field_token='0x040fffff')),('wrongOwnerToken',lambda r:r.update(original_owner_token='0x020fffff')),('wrongOwner',lambda r:r.update(owner=r['owner']+'X')),('wrongName',lambda r:r.update(name=r['name']+'X')),('wrongRawTypeSpec',lambda r:r.update(raw_shape='V999')),('absentMarker',lambda r:r.update(old_serialization_attributes=[])),('wrongBlob',lambda r:r['old_serialization_attributes'][0].update(blob='01000100')),('wrongScope',lambda r:r['old_serialization_attributes'][0].update(assembly='mscorlib'))]
  for label,mutate in mutations:
   changed=json.loads(json.dumps(original));mutate(changed)
   try:check_contract(changed,native)
   except ValueError:checks.append({'case':label,'rejected':True})
   else:raise AssertionError('Invalid field witness admitted: '+label)
 need(len(role)==1,'Exact permission field not found uniquely')
 result={'schema':'original-core-field-token-typespec-serialization-witness/v1','original_native_fields':count,'exact_field_token_owner_name_raw_typespec_and_serialization_matches':exact,'native_serialization_marker_occurrences':attrs,'mismatch_witness_count':len(mismatches),'type_mismatch_witnesses':mismatches,'raw_provider_flag_differences':flagsDifferences,'raw_provider_serialization_attribute_differences':rawAttrDifferences,'unresolved':errors,'missing_native_fields':missing,'role_permission':role,'fixtures':checks,'all_contracts_proven':not errors and not missing and count==exact,'cli_tokens_not_assumed_original':True,'old_provider_type_signature_never_restoration_authority':True,'project_modified':False,'game_code_executed':False}
 (out/'field-witness-report.json').write_text(json.dumps(result,indent=2)+'\n');(out/'type-mismatch-witnesses.json').write_text(json.dumps({'schema':'native-proven-old-serialization-field-signature-witnesses/v1','witnesses':mismatches,'role_permission':role,'fixtures':checks},indent=2)+'\n');print(json.dumps({k:result[k] for k in ('original_native_fields','exact_field_token_owner_name_raw_typespec_and_serialization_matches','native_serialization_marker_occurrences','mismatch_witness_count','all_contracts_proven')}|{'unresolved':len(errors),'missing':len(missing),'flags_differences':len(flagsDifferences),'raw_serialization_differences':len(rawAttrDifferences)}));return 0
def main():
 if len(sys.argv)==3 and sys.argv[1]=='--native-join':return native_join(Path(sys.argv[2]))
 out=g.ROOT/'Validation'/('CoreFieldAttributeWitness-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'phases':[],'project_modified':False,'game_code_executed':False}
 try:
  source=HERE/'CoreFieldAttributeWitnessInventory.cs';canonical=g.ROOT/'CompilerRepairs/MetadataRestorationPilot/CanonicalMetadataSignatures.cs';dependencies=[HERE.parent/'ILCoverageAuditor/Published/Mono.Cecil.dll'];raw=g.ROOT/'ScriptRecoveryModernLayout/Attempt-20261022T021923Z-2fcf0245/Output/Assembly-CSharp.dll';old=g.ROOT/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll';inputs=[source,canonical,raw,old,Path(__file__).resolve(),VARIANT/'inventory_native_plugin_method_flags_arrays.py',HERE.parent/'ConstructorEvidence/native_metadata.py'];report['inputs']=[{'path':str(p),'sha256':g.sha(p)} for p in inputs];host=out/'CoreFieldAttributeWitnessInventory.dll';rsp=out/'compile.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/nullable:enable','/langversion:latest','/out:"'+str(host)+'"']+['/reference:"'+str(p)+'"' for p in sorted(g.REF.glob('*.dll'))+dependencies]+['"'+str(source)+'"','"'+str(canonical)+'"'])+'\n');g.phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-reader',report,maximum=120,cap=.125)
  for p in dependencies:shutil.copyfile(p,out/p.name)
  host.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));g.phase([g.DOTNET,host,raw,old,out/'raw-core-fields.jsonl',out/'raw-summary.json'],out,'read-raw-old-field-token-attributes',report,maximum=120,cap=.275);g.phase([sys.executable,Path(__file__).resolve(),'--native-join',out],out,'native-field-typespec-attribute-join',report,maximum=120,cap=.275);need(all(g.sha(Path(row['path']))==row['sha256'] for row in report['inputs']),'Pinned inputs drifted');joined=json.loads((out/'field-witness-report.json').read_text());report['summary']={k:joined[k] for k in ('original_native_fields','exact_field_token_owner_name_raw_typespec_and_serialization_matches','native_serialization_marker_occurrences','mismatch_witness_count','all_contracts_proven')};report['status']='completed';return 0
 except Exception as error:report['status']='failed';report['error']=str(error);return 1
 finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'output':str(out),'status':report['status'],'summary':report.get('summary'),'error':report.get('error')}))
if __name__=='__main__':raise SystemExit(main())
