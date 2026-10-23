"""Evidence-only exact SDK/native overlay; never writes the client or executes it."""
import copy,datetime as dt,hashlib,json,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18'
NATIVE=ROOT/'Validation/NativeSteamworks14-20261022T141152Z-a6c2c16d/report.json';COMPILED=ROOT/'Validation/CompiledOfficialSteamworks14-20261022T141234Z-ba27e76b/report.json';LEDGER=ROOT/'Validation/AllPInvokeBindings-20261022T123600Z/ReviewedEvidencePackage/binding-ledger.json'
def need(ok,why):
 if not ok:raise ValueError(why)
def sha(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  while b:=f.read(1024*1024):h.update(b)
 return h.hexdigest()
def load_ref(ref):
 p=Path(ref['path']);need(sha(p)==ref['sha256'],'Pinned artifact changed:'+str(p));return json.loads(p.read_text())
def index(rows,key):
 result={}
 for r in rows:result.setdefault(key(r),[]).append(r)
 return result
def one(table,key):
 rows=table.get(key,[]);need(len(rows)==1,'Missing/duplicate exact source ownership:'+str(key));return rows[0]
def methodkey(r):return r['owner'],r['name'],r['return'],tuple(p['type'] for p in r['parameters'])
def attribute_matches(attrs,descriptor):
 need((descriptor is not None)==bool(attrs),'Source/compiled marshal ownership differs')
 if descriptor is None:return
 need(len(attrs)==1,'Exactly one genuine MarshalAs required');a=attrs[0];need(a['constructor_type']=='System.Runtime.InteropServices.MarshalAsAttribute' and len(a['constructor_arguments'])==1,'Marshal attribute constructor differs');kind=a['constructor_arguments'][0]['value'];need(type(kind)is int and kind==descriptor['native_type'],'UnmanagedType differs')
 expected={3:'MarshalInfo',38:'MarshalInfo',23:'FixedSysStringMarshalInfo',30:'FixedArrayMarshalInfo',42:'ArrayMarshalInfo'};need(expected.get(kind)==descriptor['kind'],'Unsupported/different exact MarshalInfo subclass')
 for named in a['named_arguments']:
  field={'SizeConst':'size','SizeParamIndex':'size_parameter_index','ArraySubType':'element_type'}.get(named['name']);need(field is not None and descriptor[field]==named['value']['value'],'Original source array/string shape differs')
def same_rows(actual,expected):
 need(actual.keys()==expected.keys(),'Overlay inventory categories differ')
 for category,rows in expected.items():
  need(len(actual[category])==len(rows),'Overlay row count changed:'+category)
  for a,e in zip(actual[category],rows):need(a==e,'Overlay native/source ownership or exact serialized shape differs:'+category)
def tests(rows):
 need(rows['fields'] and rows['parameters'] and rows['returns'] and rows['imports'],'All fixture families required');cases=[]
 def check(label,change):
  mutated=copy.deepcopy(rows);change(mutated)
  try:same_rows(mutated,rows)
  except ValueError:cases.append({'case':label,'result':'refused'});return
  raise ValueError('Negative overlay witness unexpectedly accepted:'+label)
 for cat in ('fields','parameters','returns','imports'):
  check(cat+'-missing-row',lambda r,c=cat:r[c].pop());check(cat+'-duplicate-row',lambda r,c=cat:r[c].append(copy.deepcopy(r[c][0])))
  for field in ('owner','native_method_token' if cat!='fields' else 'native_field_token','sdk_cli_token','native_owner_token' if cat=='fields' else 'name'):
   check(cat+'-wrong-'+field,lambda r,c=cat,f=field:r[c][0].__setitem__(f,'WRONG_ORIGINAL_OWNER_OR_TOKEN'))
 for cat in ('fields','parameters','returns'):
  check(cat+'-missing-marshal',lambda r,c=cat:r[c][0].__setitem__('marshal',None));check(cat+'-wrong-native-type',lambda r,c=cat:r[c][0]['marshal'].__setitem__('native_type',99));check(cat+'-wrong-subclass',lambda r,c=cat:r[c][0]['marshal'].__setitem__('kind','UnknownMarshal'));check(cat+'-unexpected-shape-field',lambda r,c=cat:r[c][0]['marshal'].__setitem__('cookie','invented'))
 for i,r in enumerate(rows['fields']):
  if 'size' in r['marshal']:
   check('fixed-native-field-'+str(i)+'-wrong-size',lambda x,j=i:x['fields'][j]['marshal'].__setitem__('size',x['fields'][j]['marshal']['size']+1))
   if len(cases)>=64:break
 while len(cases)<64:
  i=len(cases)%len(rows['parameters']);check('parameter-'+str(i)+'-wrong-ordinal-'+str(len(cases)),lambda r,j=i:r['parameters'][j].__setitem__('sequence',999))
 same_rows(copy.deepcopy(rows),rows);return cases
def main():
 out=ROOT/'Validation'/('SteamworksMarshalOverlay-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();n=json.loads(NATIVE.read_text());c=json.loads(COMPILED.read_text());need(c['status']=='compiled_and_metadata_extracted' and n['original_inputs_before_after_verified'],'Native/source compilation proof incomplete');sdk=load_ref(c['marshal_records']);syntax=load_ref(c['source_ownership']);need(not syntax['semantic_errors'],'Official source declarations not bound');official=load_ref({'path':c['official_source_report'],'sha256':c['official_source_report_sha256']});source_rows={r['local_path']:r for r in official['files']};need(all(sha(Path(r['local_path']))==r['sha256'] for r in official['files']),'Official source changed');need(sha(Path(c['compiled_assembly']['path']))==c['compiled_assembly']['sha256'],'Compiled SDK witness changed');ledger=json.loads(LEDGER.read_text());native_refs=n['original_inputs'];need(all(sha(Path(r['path']))==r['sha256'] for r in native_refs),'Original input hashes changed')
 fields=index(sdk['fields'],lambda r:(r['owner'],r['name'],r['type']));field_syntax=index(syntax['fields'],lambda r:(r['owner'],r['name'],r['type']));imports=index(sdk['methods'],methodkey);import_syntax=index(syntax['methods'],methodkey);bindings=index(ledger['bindings'],lambda r:(r['declaring_type'],r['method_name'],r['return_type'],tuple(p['type'] for p in r['parameters'])));overlay={'fields':[],'parameters':[],'returns':[],'imports':[]};unresolved=[]
 def witness(s):
  source=one({k:[v] for k,v in source_rows.items()},s['path']);return {'source_path':s['path'],'source_sha256':source['sha256'],'source_git_blob_sha1':source['git_blob_sha1'],'source_url':source['url'],'line':s['line']}
 for f in n['marshal_fields']:
  k=f['owner'],f['field_name'],f['type'];s=one(fields,k);ast=one(field_syntax,k);attribute_matches(ast['marshal'],s['marshal']);need(f['flags']==s['flags'] and f['flags']&0x1000,'Exact original field flags differ');overlay['fields'].append({'owner':f['owner'],'name':f['field_name'],'type':f['type'],'native_owner_token':f['owner_native_token'],'native_field_token':f['field_native_token'],'original_flags':f['flags'],'sdk_cli_token':s['token'],'marshal':s['marshal'],'source_witness':witness(ast),'authority':'genuine_exactSDKsource_restored','native_descriptor_blob_available':False})
 for m in n['native_steam_imports']:
  if not m['flags']&0x2000:continue
  k=methodkey(m);ss=imports.get(k,[])
  if len(ss)!=1:
   unresolved.append({'owner':m['owner'],'name':m['name'],'native_method_token':m['token'],'return':m['return'],'parameters':m['parameters'],'native_has_any_param_marshal_flag':any(p['native_type']['attributes']&0x2000 for p in m['parameters']),'reason':'Absent exact method signature in pinned official14.0.0 source; no descriptor inferred'});continue
  s=ss[0];ast=one(import_syntax,k);l=one(bindings,k);ef=l['effective_import'];p=s['pinvoke'];need(p['module']==ef['module'] and p['entry']==ef['entry_point'] and {256:0,512:1,768:2,1024:3,1280:4}.get(p['attributes']&0x700)==ef['native_calling_convention']['native_enum'] and {0:2,2:2,4:3,6:4}.get(p['attributes']&6)==ef['native_char_set']['native_enum'] and bool(p['attributes']&1)==ef['is_no_mangle'],'Genuine SDK source/native effective binding differs');need(m['flags']==s['flags'] and m['impl_flags']==s['impl_flags'] and int(m['token'],16)==int(l['original_native_MethodDef_token'],16),'Method native identity/flags differ');sw=witness(ast);base={'owner':m['owner'],'name':m['name'],'native_method_token':m['token'],'return':m['return'],'parameter_types':[x['type'] for x in m['parameters']],'sdk_cli_token':s['token'],'source_witness':sw}
  overlay['imports'].append(dict(base,pinvoke=p,native_effective_binding=ef,original_method_flags=m['flags'],original_method_impl_flags=m['impl_flags'],authority='genuine_exactSDKsource_and_original_native_effective_binding'))
  for np,sp,ap in zip(m['parameters'],s['parameters'],ast['parameters']):
   need(np['native_type']['attributes']==sp['flags'] and bool(np['native_type']['attributes']&0x2000)==bool(sp['marshal']),'Native/source parameter flags differ');attribute_matches(ap['marshal'],sp['marshal'])
   if sp['marshal'] is not None:overlay['parameters'].append(dict(base,sequence=sp['sequence'],parameter_name=np['name'],type=np['type'],original_flags=np['native_type']['attributes'],marshal=sp['marshal'],authority='genuine_exactSDKsource_restored',native_descriptor_blob_available=False))
  attribute_matches(ast['return_marshal'],s['return_marshal'])
  if s['return_marshal'] is not None:overlay['returns'].append(dict(base,sequence=0,type=m['return'],sdk_return_flags=s['return_flags'],marshal=s['return_marshal'],authority='genuine_exactSDKsource_restored',native_Param0_marshal_flag_not_authoritative=True,native_descriptor_blob_available=False))
 need(len(overlay['fields'])==111 and len(overlay['parameters'])==62 and len(overlay['returns'])==318 and len(overlay['imports'])==819 and len(unresolved)==1,'Unexpected exact native/source overlay inventory');negative=tests(overlay);report={'schema':'proven-native-official-sdk-marshalling-overlay/v1','status':'proven_candidate_only','target_assembly':'Assembly-CSharp','scope':'Windows-x64 original source profile; all official platform source files retained unchanged','sdk_witness_dll':c['compiled_assembly'],'compiled_source_proof':{'path':str(COMPILED),'sha256':sha(COMPILED)},'native_identity_proof':{'path':str(NATIVE),'sha256':sha(NATIVE)},'native_binding_ledger':{'path':str(LEDGER),'sha256':sha(LEDGER)},'native_original_inputs':native_refs,'source_official_commit':official['commit'],'counts':{k:len(v) for k,v in overlay.items()},'records':overlay,'unresolved':unresolved,'negative_fixture_count':len(negative),'negative_fixtures':negative,'positive_overlay_exact_witness_roundtrip':True,'runtime_or_sdk_code_executed':False,'project_modified':False,'metadata_overlay_applied':False,'limits':['Exact missing import method remains unresolved; its parameters have no dangling marshal flags.','Two nonSteam Win32 parameter descriptors are outside this SDK overlay.','318 return descriptors are explicitly genuine matchingSDK source authority, not recovered original native Param0 blobs.']};(out/'overlay.json').write_text(json.dumps(report,indent=2));print(json.dumps({'overlay':str(out/'overlay.json'),'sha256':sha(out/'overlay.json'),'counts':report['counts'],'negative_fixtures':len(negative),'unresolved':unresolved[0]['name']}),flush=True)
if __name__=='__main__':main()
