"""Strict native-to-official metadata join; only exact scoped scalar marshal owners."""
import argparse,copy,datetime as dt,hashlib,json,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18'
def sha(path):return hashlib.sha256(Path(path).read_bytes()).hexdigest()
def need(test,message):
 if not test:raise ValueError(message)
def methodkey(method):return(method['name'],method['return_type'],tuple(p['type'] for p in method['parameters']))
def unique(rows,predicate,label):
 values=[x for x in rows if predicate(x)];need(len(values)==1,'Expected exact unique '+label);return values[0]
def join_type(native,source,scope):
 need(native['name']==source['name'],'Owner name differs');need(native['flags']==source['flags'],'Type flags differ: '+native['name']);need(len(native['fields'])==len(source['fields']),'Field inventory differs: '+native['name']);need(len(native['methods'])==len(source['methods']),'Method inventory differs: '+native['name'])
 for nf,sf in zip(native['fields'],source['fields']):
  need((nf['name'],nf['type'],nf['flags'])==(sf['name'],sf['type'],sf['flags']),'Field name/type/flags/order differ: '+native['name']+'::'+nf['name'])
  if 'constant' in nf:need(nf['constant']==sf['constant'],'Native constant differs')
 for nm in native['methods']:
  sm=unique(source['methods'],lambda x:methodkey(x)==methodkey(nm),'method '+native['name']+'::'+nm['name']);need((nm['flags'],nm['impl_flags'])==(sm['flags'],sm['impl_flags']),'Method flags differ')
  need(nm['return_flags']==sm['return_flags'],'Return flags differ')
  need([(p['name'],p['flags']) for p in nm['parameters']]==[(p['name'],p['flags']) for p in sm['parameters']],'Parameter names/flags differ')
def main():
 parser=argparse.ArgumentParser();parser.add_argument('--compiled-report',required=True);parser.add_argument('--api-only',action='store_true');parser.add_argument('--descriptor-scope',action='store_true');args=parser.parse_args();compiled_path=Path(args.compiled_report);compiled=json.loads(compiled_path.read_text());need(compiled['status']=='passed','Compiled witness not passed');inventory_path=Path(compiled['inventory']['path']);need(sha(inventory_path)==compiled['inventory']['sha256'],'Compiled inventory hash differs');source=json.loads(inventory_path.read_text())['modules'][0]
 native_path=ROOT/'Validation/NativeOpenVr-20261022T152339Z-f2c76343/report.json';native=json.loads(native_path.read_text());need(native['status']=='inventoried' and native['original_inputs_before_after_verified'],'Original witness incomplete');scope='Valve.VR.' if args.api_only else None;loader_scope=('Unity.XR.OpenVR.OpenVRLoader','Unity.XR.OpenVR.OpenVRLoader/UserDefinedSettings','Unity.XR.OpenVR.OpenVRLoader/TickCallbackDelegate');selected=[t for t in native['types'] if (t['name'].startswith(scope) if scope else t['name'].startswith('Valve.VR.') or t['name'] in loader_scope if args.descriptor_scope else t['name'] not in ('<Module>','<>f__AnonymousType0`2') and '<>c' not in t['name'])];joined=[]
 for nt in selected:
  st=unique(source['types'],lambda t:t['name']==nt['name'],'type '+nt['name']);join_type(nt,st,scope);joined.append((nt,st))
 out=ROOT/'Validation'/('OpenVrContractJoin-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();summary={'schema':'strict-original-native-official-openvr-contract-join/v1','status':'passed','project_modified':False,'sdk_or_game_code_executed':False,'native_report':{'path':str(native_path),'sha256':sha(native_path)},'compiled_report':{'path':str(compiled_path),'sha256':sha(compiled_path)},'type_count':len(joined),'field_count':sum(len(n['fields']) for n,s in joined),'method_count':sum(len(n['methods']) for n,s in joined),'full_names_flags_field_order_parameter_names_constants_exact':True,'scoped_assembly_identity':'Unity.XR.OpenVR','official_witness_self_scope':source['assembly'],'overall_original_package_version_proven':False,'notes':['All retained selected type/method/field declarations match the exact original native contract. This is source-contract identity evidence, not a claim that the complete original package distribution/version is proven.','Raw native flags do not contain the absent MarshalInfo descriptor bytes; descriptors are attributed explicitly to matched genuine official source.']}
 summary['descriptor_scope_only']=args.descriptor_scope;summary['joined_original_type_names']=[n['name'] for n,s in joined];summary['unrelated_original_source_difference']={'owner':'Unity.XR.OpenVR.OpenVRSettings','original_only_method':'System.String AbsolutePathToAssetPath(System.String)','has_marshaled_owners':False,'not_substituted':True}
 (out/'report.json').write_text(json.dumps(summary,indent=2));print(json.dumps({'report':str(out/'report.json'),'types':summary['type_count'],'fields':summary['field_count'],'methods':summary['method_count']}))
if __name__=='__main__':main()
