"""Exact original service factory CFG including logging; never omit side effects."""
from pathlib import Path
import datetime as dt,hashlib,json,mmap,struct,sys,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from native_metadata import NativeMetadata
from audit_ogpeg_constructors import Decoder,need
from audit_forwarding import EXPECTED,sha
from prove_recroom_ondestroy_native_cfg import aliases
WINDOW=ROOT/'Validation/ServiceContainerNativeWindows-20261022T180635Z-6a8820b3/report.json'

def decode(code,va):
 d=Decoder(code,va);d.literal('48 89 5c 24 08 48 89 74 24 10 57 48 83 ec 60');flag=d.relative('80 3d','00');d.literal('48 8b da 48 8b f9');skip=d.short('75');uses=[];inits=[]
 for i in range(6):uses.append(d.relative('48 8d 0d'));inits.append(d.relative('e8'))
 written=d.relative('c6 05','01');ready=va+d.at;f=d.relative('4c 8b 05');d.literal('45 33 c9');e=d.relative('48 8b 0d');d.literal('48 8b d7');concat=d.relative('e8');a=d.relative('48 8b 0d');d.literal('48 8b f0 f6 81 33 01 00 00 04');a_skip1=d.short('74');d.literal('83 b9 e0 00 00 00 00');a_skip2=d.short('75');init_a=d.relative('e8');a_reload=d.relative('48 8b 0d');a_ready=va+d.at
 d.literal('48 8b 89 b8 00 00 00 48 8d 54 24 20');c=d.relative('4c 8b 05');d.literal('0f 57 c0 33 c0 0f 10 89 80 00 00 00 48 8d 4c 24 30 89 44 24 40 0f 11 44 24 30 66 0f 7f 4c 24 20');nullable=d.relative('e8');d.literal('0f 10 44 24 30');logclass=d.relative('48 8b 0d');d.literal('8b 44 24 40 0f 11 44 24 48 89 44 24 58 f6 81 33 01 00 00 04');l_skip1=d.short('74');d.literal('83 b9 e0 00 00 00 00');l_skip2=d.short('75');init_log=d.relative('e8');log_ready=va+d.at
 d.literal('45 33 c0 48 8d 54 24 48 48 8b ce');log=d.relative('e8');d.literal('48 85 db');no_parent=d.short('74');d.literal('45 33 c0 48 8b d7 48 8b cb');child=d.relative('e8');d.literal('48 8b 5c 24 70 48 8b 74 24 78 48 83 c4 60 5f c3');root_at=va+d.at;root_class=d.relative('48 8b 0d');alloc=d.relative('e8');d.literal('45 33 c0 48 8b d7 48 8b c8 48 8b d8');ctor=d.relative('e8');d.literal('48 8b 74 24 78 48 8b c3 48 8b 5c 24 70 48 83 c4 60 5f c3');semantic=d.at
 need(len(code)==384 and all(x==0xcc for x in code[semantic:]),'Only original padding allowed after two balanced returns');d.literal('cc '*(len(code)-semantic));d.end()
 need(flag==written and skip==ready and inits==[0x1806c01e0]*6,'Metadata guard/cache init differs')
 need(uses==[a,root_class,c,logclass,e,f] and a_reload==a,'Metadata loaded usage ownership differs')
 need(a_skip1==a_skip2==a_ready and l_skip1==l_skip2==log_ready and no_parent==root_at,'Class-init or parent branch edge differs')
 need(init_a==init_log==0x180640f10 and alloc==0x1806c0340,'Exact original runtime class-init/allocation helpers differ')
 need([concat,nullable,log,child,ctor]==[0x18476bde0,0x182670530,0x185673d90,0x186745200,0x186745460],'Original direct factory callees differ')
 return {'metadata_uses':[hex(x)for x in uses],'string_concat':hex(concat),'nullable_constructor':hex(nullable),'logger_call':hex(log),'nonnull_parent_child_factory':hex(child),'root_constructor':hex(ctor),'allocation_helper':hex(alloc),'class_init_runtime':hex(init_a),'static_color_field_offset':128,'semantic_bytes':semantic,'padding_bytes':len(code)-semantic,'all384bytes_checked':True,'all_branches_and_both_stack_balanced_returns_proven':True}

def literal(v,index):
 at=v.row('stringLiteral',index,8);length=v.u32(v.m,at);offset=v.u32(v.m,at+4);base,size=v.tables['stringLiteralData'];need(offset+length<=size,'Literal original bounds');raw=bytes(v.m[base+offset:base+offset+length]);return {'index':index,'utf8':raw.decode('utf-8'),'bytes_sha256':hashlib.sha256(raw).hexdigest()}

def main():
 evidence=json.loads(WINDOW.read_text());row=next(r for r in evidence['methods']if r['original']['name']=='OBAIKOPBHAP');code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);shape=decode(code,va);paths=[ROOT/'CodeSource'/x for x in EXPECTED]
 for p in paths:need(sha(p)==EXPECTED[p.relative_to(ROOT/'CodeSource').as_posix()],'Original source SHA changed')
 with paths[0].open('rb')as f,paths[1].open('rb')as g,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ)as b,mmap.mmap(g.fileno(),0,access=mmap.ACCESS_READ)as md:
  v=NativeMetadata(b,md);method=v.find_method('MPAAIECKLGA',0x06000028);need(v.method_pointer(method)==va and method['name']=='OBAIKOPBHAP' and [p['type']for p in method['parameters']]==['System.String','MNALHHOLFGL'] and method['return']=='MNALHHOLFGL','Original factory signature/registration differs');a=v.raw(va,len(code));need(bytes(b[a:a+len(code)])==code,'Original factory bytes differ');uses=[v.usage(int(a,16))for a in shape['metadata_uses']]
  need([r['kind']for r in uses]==[1,1,6,1,5,5] and uses[0]['type']=='HJDBOADFHMC' and uses[1]['type']=='MNALHHOLFGL' and uses[3]['type']=='PNAABCMOHGM','Exact metadata kinds/classes differ')
  nullable=uses[2];need(nullable['method']['owner']=='System.Nullable`1' and nullable['method']['name']=='.ctor' and nullable['method']['image']=='mscorlib.dll' and nullable['class_argument_types']==['HJDBOADFHMC'],'Exact Nullable<Color> constructor identity differs');targets=v.generic_targets({nullable['index']})[nullable['index']];need(targets and {x['pointer']for x in targets}=={shape['nullable_constructor']},'Nullable generic registration differs')
  mapped,gaps=aliases(v,{int(shape[k],16)for k in ['string_concat','logger_call','nonnull_parent_child_factory','root_constructor']})
  for key,owner,name in [('string_concat','System.String','Concat'),('logger_call','PNAABCMOHGM','FPNMONCCAAE'),('nonnull_parent_child_factory','MNALHHOLFGL','MJHONDPGJFA'),('root_constructor','MNALHHOLFGL','.ctor')]:
   matches=mapped[shape[key]];need(len(matches)==1 and matches[0]['owner']==owner and matches[0]['name']==name,'Original exact call alias differs:'+key)
  ti=next(i for i in range(v.count('typeDefinitions',88))if v.full_name(i)=='HJDBOADFHMC');td=v.row('typeDefinitions',ti,88);first=v.i32(md,td+32);count=v.u16(md,td+68);off=v.raw(v.u64(b,v.field_offsets+ti*8),count*4);colors=[]
  for i in range(count):
   q=v.row('fields',first+i,12);nt=v.native_type(v.i32(md,q+4));at=v.i32(b,off+i*4)
   if nt['attributes']&16 and at==128:colors.append({'name':v.string(v.i32(md,q)),'type':v.typename(nt),'flags':nt['attributes'],'token':hex(v.u32(md,q+8)),'static_offset':at})
  need(len(colors)==1 and colors[0]['type']=='HJDBOADFHMC','Exact static logging color field missing/ambiguous');strings=[literal(v,x['index'])for x in uses[4:]]
 controls=[]
 for label,old,new in [('preserve_parent','48 8b da 48 8b f9','48 8b d9 48 8b f9'),('logging_color_offset','0f 10 89 80 00 00 00','0f 10 89 90 00 00 00'),('log_nullable_stack','48 8d 54 24 48 48 8b ce','48 8d 54 24 40 48 8b ce'),('root_name_argument','45 33 c0 48 8b d7 48 8b c8','45 33 c0 48 8b d3 48 8b c8')]:
  a=bytes.fromhex(old);need(code.count(a)==1,'Semantic mutation anchor notunique');changed=code.replace(a,bytes.fromhex(new))
  try:decode(changed,va)
  except (ValueError,struct.error):controls.append({'case':label,'rejected':True})
  else:raise AssertionError('Changed original factory semantics accepted:'+label)
 report={'schema':'original-service-container-factory-full-native-CFG/v1','status':'complete_factory_body_proven_callees_not_yet_all_recovered','original':method,'native_pointer':hex(va),'all384bytes':code.hex(),'native_sha256':hashlib.sha256(code).hexdigest(),'shape':shape,'metadata_uses':uses,'logging_string_literals':strings,'logging_color_field':colors[0],'nullable_registration':targets,'direct_original_aliases':mapped,'alias_tables_unbacked_or_unsupported':gaps,'original_call_order':['String.Concat(originalprefix,name,originalsuffix)','Read exact original logging color; construct genuine Nullable<color>','PNAABCMOHGM.FPNMONCCAAE(message,incolor)','If parent!=null: return originalparent.MJHONDPGJFA(name)','If parent==null: allocate realMNAL and invoke original stringconstructor(name);returnallocatedobject'],'no_logging_or_parent_behavior_removed':True,'boot_getter_supplies_null_parent':True,'all_boot_dependencies_closed':False,'pending_dependencies':['HJDBOADFHMC static color initialization','PNAABCMOHGM.FPNMONCCAAE original logging behavior','MNAL string/private constructor and final PHJ/JON service-registration chain','MFENCGHNPBJ memory-service registration/resolution required by Awake'], 'negative_controls':controls,'input':[{'path':str(p),'sha256':sha(p)}for p in [WINDOW]+paths],'project_modified':False,'game_or_native_code_executed':False}
 out=ROOT/'Validation'/('ServiceContainerFactoryCFG-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'semantic_bytes':shape['semantic_bytes'],'pending':report['pending_dependencies']}))

if __name__=='__main__':main()
