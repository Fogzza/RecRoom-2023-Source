"""Bounded original startup/login/loading leaf audit; data-only, no project edits."""
import hashlib,importlib.util,json,mmap,struct,sys
from pathlib import Path
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
TOOLS=ROOT/'Tools';sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_generic_forwarders import runtime_range
TARGETS={'LoadingScreen','TitleScreenManager','RRUI.Data.TitleScreenFlowModel','RRUI.Data.PasswordlessLoginModel','RecRoom.ScreenTitleScreenController','RecRoom.VRTitleScreenController'}
def load(name,path):
 s=importlib.util.spec_from_file_location(name,path);m=importlib.util.module_from_spec(s);s.loader.exec_module(m);return m
def main():
 out=Path(sys.argv[1]);need(not out.exists(),'Fresh audit output required');paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Original source changed');paths.append(p)
 scalar=load('startup_scalar_matcher',TOOLS/'audit_native_scalar_accessors.py');reader=load('startup_field_reader',scalar.READER);need(sha(scalar.READER)==scalar.READER_SHA,'Pinned reader changed');scalar.TARGETS=TARGETS
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);report=scalar.audit(b,md,reader);critical=[];original_types=[]
  for ti in range(v.count('typeDefinitions',88)):
   name=v.full_name(ti)
   if name not in TARGETS:continue
   td=v.row('typeDefinitions',ti,88);original_types.append(v.type_info(ti));start=v.i32(md,td+36);count=v.u16(md,td+64)
   for mi in range(start,start+count):
    method=v.method_info(mi);pointer=v.method_pointer(method)
    if method['name'] not in ('Awake','Start','Update','OnEnable','OnDisable','OnDestroy','IsOnTitleScreen','get_FlowModel') and not any(x in method['name'] for x in ('Login','LogIn','Launch','Room','Connect','Fade','Route','Play')):continue
    if not pointer or not v.executable(pointer):continue
    try:
     start_rva,end_rva,code=runtime_range(v,pointer);region={'start_rva':start_rva,'end_rva':end_rva,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'scope':'Exact entry PE runtime-function only; split tails not assumed complete.'}
    except ValueError as error:
     at=v.raw(pointer,32);code=bytes(b[at:at+32]);region={'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),'scope':'Bounded32-byte entry prefix only','range_error':str(error)}
    critical.append({'original':method,'native_pointer':hex(pointer),'native_region':region,'body_recovered':False})
 report.update(schema='original-startup-login-loading-leaf-audit/v1',original_types=original_types,critical_callback_inventory=critical,original_source_inputs=[{'path':str(p),'sha256':sha(p)} for p in paths],targets=sorted(TARGETS),source_or_meta_modified=False,game_code_executed=False,limitations=['Leaf accessors do not restore complete startup/login/loading behavior.','No callback body accepted from partial Cpp2IL output.','Named source bindings and original field-name joins remain required before any candidate patch.'])
 out.parent.mkdir(parents=True,exist_ok=True);out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'keys':list(report),'critical_callbacks':len(critical),'project_modified':False}))
if __name__=='__main__':main()
