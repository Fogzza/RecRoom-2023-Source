"""Evaluate ONLY the extracted reviewed count/scope guard expressions, no preparation."""
from pathlib import Path
import ast,hashlib,json
HERE=Path(__file__).resolve().parent;ROOT=HERE.parents[2]/'Recovery/RecRoom-2023-04-18';proof=ROOT/'Tools/v2291-marshalling-preparer-provenance.json';p=json.loads(proof.read_text());tests=[]
def need(b,s):
 if not b:raise ValueError(s)
def expression(path,predicate):
 tree=ast.parse(path.read_text());calls=[n for n in ast.walk(tree) if isinstance(n,ast.Call) and isinstance(n.func,(ast.Name,ast.Attribute)) and (n.func.id if isinstance(n.func,ast.Name) else n.func.attr)=='need' and n.args and predicate(ast.unparse(n.args[0]))];need(len(calls)==1,'Expected one reviewed guard');return compile(ast.Expression(calls[0].args[0]),str(path),'eval')
for row in p['files']:need(hashlib.sha256(Path(row['candidate']).read_bytes()).hexdigest()==row['candidate_sha256'],'Preparer changed')
h=Path(p['files'][0]['candidate']);d=Path(p['files'][1]['candidate']);hc=expression(h,lambda t:'len(replacements)' in t);dc=expression(d,lambda t:'len(source_rows)' in t);oc=expression(h,lambda t:"overlay.get('counts')" in t);cfg=expression(d,lambda t:"config.get('metadata_resource_count')" in t)
for n in (0,2289,2290,2291,2292):
 for name,code,scope in [('harness',hc,{'replacements':dict.fromkeys(range(n))}),('deployment',dc,{'source_rows':[None]*n,'plugins':{'assemblies':[None]*225},'importers':{'files':[None]*225}})]:
  actual=eval(code,{'len':len},scope);need(actual==(n==2291),'Strict2291 guard mismatch');tests.append({'test':name+' count '+str(n),'accepted':actual,'expected_acceptance':n==2291,'passed':True})
overlay={'shipping_supported':False,'counts':{'fields':111,'parameters':64,'returns':318,'imports':819},'scope':'Windows x64 Editor compile/signature-load validation only'}
for name,change in [('exact',{}),('wrong_shipping',{'shipping_supported':True}),('wrong_scope',{'scope':'Android'}),('wrong_count',{'counts':{'fields':111,'parameters':62,'returns':318,'imports':819}})]:
 value=dict(overlay,**change);actual=eval(oc,{'isinstance':isinstance,'dict':dict},{'overlay':value});need(actual==(name=='exact'),'Overlay guard mismatch');tests.append({'test':name,'accepted':actual,'passed':True})
for count in (3,4,5):
 actual=eval(cfg,{}, {'config':{'metadata_resource_count':count,'shipping_supported':False,'marshalling_compatibility_scope':overlay['scope']}});need(actual==(count==4),'Resource count guard mismatch');tests.append({'test':'deployresources '+str(count),'accepted':actual,'passed':True})
result={'schema':'versioned-preparer-extracted-guard-controls/v1','status':'passed','tests':tests,'tested_guard_expressions_only':True,'harness_or_deployment_prepared':False,'project_modified':False,'Unity_launched':False,'preparer_provenance':{'path':str(proof),'sha256':hashlib.sha256(proof.read_bytes()).hexdigest()}};out=ROOT/'Tools/v2291-marshalling-preparer-controls.json';need(not out.exists(),'Fresh control report');out.write_text(json.dumps(result,indent=2)+'\n');print(json.dumps({'report':str(out),'sha256':hashlib.sha256(out.read_bytes()).hexdigest(),'passed_controls':len(tests)}))
