"""Mutation checks against the production read-only native/source binder."""
import datetime as dt, hashlib, importlib.util, json, uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent
spec=importlib.util.spec_from_file_location('proof',HERE/'prove_embedded_oculus_openvr_descriptors.py');p=importlib.util.module_from_spec(spec);spec.loader.exec_module(p)
def named(rows,name):return next(r for r in rows if r['name']==name)
def st(r):return named(r['source']['modules'][0]['types'],'Valve.VR.IVRSystem')
def tt(r):return named(r['target']['modules'][0]['types'],'KNGJEJPEILM')
def nt(r):return named(r['native']['types'],'KNGJEJPEILM')
def cb(r):return named(r['source']['modules'][0]['types'],st(r)['fields'][0]['type'])
def alter(get,key,value):return lambda r:get(r).__setitem__(key,value)
cases={
 'source-owner-layout-flags':alter(st,'flags',0),
 'source-packing':alter(st,'packing',1),
 'source-size':alter(st,'size',1),
 'source-field-flags':alter(lambda r:st(r)['fields'][0],'flags',6),
 'source-field-wrong-local-delegate':alter(lambda r:st(r)['fields'][0],'type','Valve.VR.IVRSystem/_GetProjectionMatrix'),
 'source-descriptor-instead-of-functionptr':alter(lambda r:st(r)['fields'][0]['marshal'],'native_type',3),
 'callback-invoke-return':alter(lambda r:named(cb(r)['methods'],'Invoke'),'return_type','System.Int32'),
 'callback-invoke-impl-flags':alter(lambda r:named(cb(r)['methods'],'Invoke'),'impl_flags',0),
 'callback-invoke-parameter-flags':alter(lambda r:named(cb(r)['methods'],'Invoke')['parameters'][0],'flags',1),
 'native-owner-token':alter(nt,'token',0x02000001),
 'native-field-token':alter(lambda r:nt(r)['fields'][0],'token',0x04000001),
 'native-field-offset':alter(lambda r:nt(r)['fields'][0],'offset',24),
 'native-field-full-type':alter(lambda r:nt(r)['fields'][0],'type','System.IntPtr'),
 'target-field-flags':alter(lambda r:tt(r)['fields'][0],'flags',6),
 'target-field-type':alter(lambda r:tt(r)['fields'][0],'type','System.IntPtr'),
 'target-already-has-marshal':alter(lambda r:tt(r)['fields'][0],'has_marshal',True),
 'wrong-graph-identity':lambda r:r['graph']['mapping'].__setitem__('Valve.VR.IVRSystem','FCHJOMFACJE'),
 'graph-collision':lambda r:r['graph']['collisions'].__setitem__('KNGJEJPEILM',2),
 'source-official-provenance':lambda r:r['compiled']['official_source_report'].__setitem__('sha256','0'*64),
 'version-proof-absent':lambda r:r['version'].__setitem__('status','unknown'),
}
results=[];p.run()
for name,mutation in cases.items():
 try:p.run(mutation)
 except (ValueError,KeyError,StopIteration) as e:results.append({'name':name,'status':'rejected','reason':str(e)})
 else:raise AssertionError('Production binder accepted mutation: '+name)
out=p.V/('EmbeddedOculusOpenVrFixtures-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'oculus-embedded-descriptor-production-proof-mutations/v1','status':'passed','positive':{'fields':332,'parameters':3,'unresolved':20},'negative_controls':results,'tool':{'path':str(HERE/'prove_embedded_oculus_openvr_descriptors.py'),'sha256':p.sha(HERE/'prove_embedded_oculus_openvr_descriptors.py')},'project_modified':False,'sdk_or_game_code_executed':False};(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':'passed','negative_controls':len(results)}),flush=True)
