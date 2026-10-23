"""Close native metadata/event/delegate identities, then stage one body outside RR23.
The C# candidate is explicitly uncompiled and cannot be applied by this tool.
"""
from pathlib import Path
import base64,datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
PROOF=ROOT/'Validation/RecRoomOnDestroyCFG-20261022T163652Z-919f9279/report.json'
def only(values,label):
 need(len(values)==1,'Exactly one '+label);return values[0]
def validate(klass,ctor,callback,event,remove,base,pointer):
 need(klass['name']=='UnityEngine.Application/LowMemoryCallback' and klass['image']=='UnityEngine.CoreModule.dll' and klass['parent_type']=='System.MulticastDelegate','Exact native delegate class')
 need(ctor['owner']==klass['name'] and ctor['name']=='.ctor' and ctor['return']=='System.Void' and [p['type'] for p in ctor['parameters']]==['System.Object','System.IntPtr'] and pointer=='0x1807df4f0','Exact typed delegate ctor and registered shared pointer')
 need(callback['owner']=='RecRoomGameRoot' and callback['name']=='ADNHOPPILKF' and callback['token']=='0x60026c3' and callback['return']=='System.Void' and not callback['parameters'] and not callback['flags']&16,'Exact native callback target')
 need(event['name']=='lowMemory' and event['type']==klass['name'] and event['remove_method_index']==remove['index'],'Exact native EventDef ownership')
 need(remove['owner']=='UnityEngine.Application' and remove['name']=='remove_lowMemory' and remove['return']=='System.Void' and remove['flags']&16 and [p['type'] for p in remove['parameters']]==[klass['name']],'Exact original event remove API')
 need(base['owner']=='GameRoot' and base['image']=='RecRoom.Datastructures.Singletons.Runtime.dll' and base['name']=='OnDestroy' and base['return']=='System.Void' and not base['parameters'] and not base['flags']&16,'Exact original base call')
def main():
 need(sha(PROOF)=='6407a60cca199814f1404bfad4ce2641b644e8e1cee5da4b8b533ec3aac109ec','BoundedCFGpin');proof=json.loads(PROOF.read_text());shape=proof['exact_native_controlflow'];paths=[ROOT/'CodeSource'/rel for rel in EXPECTED]
 for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'OriginalsourceSHA')
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);ku=proof['original_metadata_uses']['metadata_class_usage'];mu=proof['original_metadata_uses']['metadata_callback_usage'];nt=v.native_type(ku['index']);need(nt['kind']==18 and not nt['byref'] and not nt['num_mods'],'Exact classUsage');ti=nt['data'];klass=v.type_info(ti);td=v.row('typeDefinitions',ti,88);start=v.i32(md,td+36);count=v.u16(md,td+64);ctor=only([v.method_info(mi) for mi in range(start,start+count) if v.string(v.i32(md,v.row('methods',mi,32)))=='.ctor'],'typed delegate constructor');ctorpointer=hex(v.method_pointer(ctor));callback=v.method_info(mu['index']);base=only(proof['raw_backed_original_direct_pointer_aliases'][shape['base_call']],'base call');remove=only(proof['raw_backed_original_direct_pointer_aliases'][shape['tail_call']],'event remove call');application=remove['owner_index'];at=v.row('typeDefinitions',application,88);es=v.i32(md,at+40);ec=v.u16(md,at+70);events=[]
  for ei in range(es,es+ec):
   er=v.row('events',ei,24);name=v.string(v.i32(md,er))
   if name=='lowMemory':
    owner_method_start=v.i32(md,at+36);add=v.i32(md,er+8);rem=v.i32(md,er+12);raise_=v.i32(md,er+16)
    events.append({'native_index':ei,'name':name,'token':hex(v.u32(md,er+20)),'type':v.typename(v.native_type(v.i32(md,er+4))),'declaring_type_first_method_index':owner_method_start,'raw_add_relative_method_index':add,'raw_remove_relative_method_index':rem,'raw_raise_relative_method_index':raise_,'add_method_index':owner_method_start+add if add>=0 else None,'remove_method_index':owner_method_start+rem if rem>=0 else None,'raise_method_index':owner_method_start+raise_ if raise_>=0 else None,'bytes':bytes(md[er:er+24]).hex()})
  event=only(events,'original lowMemory EventDef');validate(klass,ctor,callback,event,remove,base,ctorpointer)
  need(v.method_pointer(remove)==int(shape['tail_call'],16) and v.method_pointer(base)==int(shape['base_call'],16),'Exact native callee registration')
 controls=[]
 for label,which,key,value in [('wrong delegate class',0,'name','System.Action'),('wrong ctor pointer',6,None,'0x180000000'),('wrong callback',2,'name','Start'),('wrong event operation',3,'remove_method_index',event['add_method_index']),('wrong base',5,'name','Awake')]:
  args=[dict(klass),dict(ctor),dict(callback),dict(event),dict(remove),dict(base),ctorpointer]
  if key:args[which][key]=value
  else:args[which]=value
  try:validate(*args)
  except ValueError:controls.append({'mutation':label,'rejected':True})
  else:raise AssertionError('Typed metadata mutation admitted')
 source=WS/'RR23/Assets/Scripts/Assembly-CSharp/RecRoomGameRoot.cs';raw=source.read_bytes();before=sha(source);old=b'\tprotected override void OnDestroy()\r\n\t{\r\n\t}\r\n';need(raw.count(old)==1,'Exact unique original empty source declaration');start=raw.index(old);body_start=start+old.index(b'{');length=len(b'{\r\n\t}');new=b'{\r\n\t\tbase.OnDestroy();\r\n\t\tUnityEngine.Application.lowMemory -= new UnityEngine.Application.LowMemoryCallback(ADNHOPPILKF);\r\n\t}';need(raw[body_start:body_start+length]==b'{\r\n\t}','Exact original emptybody');candidate=raw[:body_start]+new+raw[body_start+length:];out=ROOT/'Validation'/('RecRoomOnDestroyCandidate-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();target=out/'RecRoomGameRoot.cs';target.write_bytes(candidate);need(sha(source)==before,'Sourcebaseline changed');report={'schema':'native-typed-RecRoomGameRoot-OnDestroy-source-candidate/v1','status':'original_native_body_proved_CSharp_binding_and_compile_pending','source':str(source),'source_sha256':before,'source_meta_sha256':sha(str(source)+'.meta'),'candidate':str(target),'candidate_sha256':sha(target),'byte_edits':[{'start':body_start,'length':length,'original_base64':base64.b64encode(raw[body_start:body_start+length]).decode(),'replacement_base64':base64.b64encode(new).decode(),'original_method_token':'0x060026c2'}],'input_proof':[{'path':str(PROOF),'sha256':sha(PROOF)}],'native_delegate_type':klass,'native_typed_constructor':ctor,'native_constructor_registered_pointer':ctorpointer,'native_callback':callback,'native_event_definition':event,'native_remove_api':remove,'native_base_api':base,'typed_negative_controls':controls,'shared_native_ctor_disambiguated_by_original_allocated_type_and_exact_ctor_registration':True,'unbacked_global_alias_table_gaps_do_not_substitute_for_typed_identity':proof['alias_inventory_unbacked_tables'],'original_base_callee_body_not_recovered_here':True,'CSharp_source_binding_and_exact2020_compiled_effect_proof_passed':False,'apply_authorized_by_this_tool':False,'main_project_or_meta_changed':False,'game_or_native_code_executed':False};rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':sha(rp),'candidate':str(target),'candidate_sha256':sha(target),'typed_controls':len(controls),'compiled':False,'project_modified':False}))
if __name__=='__main__':main()
