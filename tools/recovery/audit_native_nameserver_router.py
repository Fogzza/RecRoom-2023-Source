"""Pure Python/ctypes trusted Capstone disassembly; never calls original code."""
import ctypes,datetime,hashlib,json,mmap,re,struct,sys,uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';sys.path[:0]=[str(HERE),str(HERE.parent/'ConstructorEvidence')]
from collect_all_pinvoke_native import ExternMetadata,need
from inventory_recroom_game_root_native import region
from prove_recroom_ondestroy_native_cfg import aliases
CAP=WS/'Tools/RecoveryTools/AssetRipper-2.0.0/capstone.dll';CAPSHA='f03321188a1615d044314b1183dcd9a7ffda09286c31c369d109165d4892dcbb'
class Insn(ctypes.Structure):
 _fields_=[('id',ctypes.c_uint),('address',ctypes.c_uint64),('size',ctypes.c_uint16),('bytes',ctypes.c_uint8*16),('mnemonic',ctypes.c_char*32),('op_str',ctypes.c_char*160),('detail',ctypes.c_void_p)]
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
class Disassembler:
 def __init__(self):
  need(sha(CAP)==CAPSHA,'Pinned trusted disassembler bytes');self.lib=ctypes.CDLL(str(CAP));major=ctypes.c_int();minor=ctypes.c_int();self.lib.cs_version(ctypes.byref(major),ctypes.byref(minor));need((major.value,minor.value)==(4,0),'Pinned Capstone ABI4');self.handle=ctypes.c_size_t();self.lib.cs_open.argtypes=[ctypes.c_int,ctypes.c_int,ctypes.POINTER(ctypes.c_size_t)];self.lib.cs_open.restype=ctypes.c_int;need(self.lib.cs_open(3,8,ctypes.byref(self.handle))==0,'CapstoneAMD64');self.lib.cs_disasm.argtypes=[ctypes.c_size_t,ctypes.c_void_p,ctypes.c_size_t,ctypes.c_uint64,ctypes.c_size_t,ctypes.POINTER(ctypes.POINTER(Insn))];self.lib.cs_disasm.restype=ctypes.c_size_t;self.lib.cs_free.argtypes=[ctypes.POINTER(Insn),ctypes.c_size_t];self.lib.cs_close.argtypes=[ctypes.POINTER(ctypes.c_size_t)]
 def decode(self,code,va):
  need(0<len(code)<=16384,'Strict decoded function bound');buffer=ctypes.create_string_buffer(code);out=ctypes.POINTER(Insn)();count=self.lib.cs_disasm(self.handle,buffer,len(code),va,0,ctypes.byref(out));need(count>0,'Decoded instruction sequence');rows=[];seen=0
  try:
   for i in range(count):
    x=out[i];raw=bytes(x.bytes[:x.size]);need(x.address==va+seen and 0<x.size<=15 and raw==code[seen:seen+x.size],'Contiguous exact instruction bytes');rows.append({'VA':hex(x.address),'offset':seen,'bytes':raw.hex(),'mnemonic':x.mnemonic.decode(),'operand':x.op_str.decode(),'size':x.size});seen+=x.size
  finally:self.lib.cs_free(out,count)
  need(seen==len(code),'All function bytes decoded');return rows
 def close(self):self.lib.cs_close(ctypes.byref(self.handle))
def literal(v,index):
 at=v.row('stringLiteral',index,8);length,offset=struct.unpack_from('<ii',v.m,at);base,size=v.tables['stringLiteralData'];need(0<=length<=65536 and 0<=offset<=size-length,'Bounded original literal');raw=bytes(v.m[base+offset:base+offset+length]);text=raw.decode('utf-8');info={'index':index,'length':length,'sha256':hashlib.sha256(raw).hexdigest()}
 from urllib.parse import urlsplit
 if text.startswith(('https://','http://')):
  parsed=urlsplit(text);info['public_URL_origin']=parsed.scheme+'://'+(parsed.hostname or '')+(':'+str(parsed.port) if parsed.port else '');info['path_length']=len(parsed.path);info['query_or_credentials_present']=bool(parsed.query or parsed.fragment or parsed.username or parsed.password)
 elif re.fullmatch('[A-Za-z][A-Za-z0-9_/ .:-]{0,100}',text) and not re.search('secret|token|password|key',text,re.I):info['safe_noncredential_label']=text
 return info
def main():
 proof=ROOT/'Validation/TemporaryExistingNameserverPlan-20261022T192454Z-1426b7f7/report.json';need(sha(proof)=='2bd45f200303277fc8fa9034e3f8a077c6f31120a34ccdf1d5d4beaca5b34f86','Method availability receipt');prior=json.loads(proof.read_text());paths=[Path(x['path'])for x in prior['original_native_source_lineage']];before=[(p.stat().st_size,p.stat().st_mtime_ns)for p in paths];d=Disassembler();fixture=d.decode(bytes.fromhex('48 8b 41 50 c3'),0x1000);need([(x['mnemonic'],x['operand'])for x in fixture]==[('mov','rax, qword ptr [rcx + 0x50]'),('ret','')],'Trusted disassembler ABI/format fixture');methods=[];targets=set();usages={};gaps=[]
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md)
  for original in prior['native_router_bodies_available_for_future_recovery']:
   m=v.find_method(original['owner'],int(original['original_method_token'],16));va=v.method_pointer(m);w=region(v,va);need(w['sha256']==original['native_body_sha256'] and len(bytes.fromhex(w['bytes']))==original['native_body_bytes'],'Exact native function preserved');ins=d.decode(bytes.fromhex(w['bytes']),va)
   for row in ins:
    if row['mnemonic'] in ['call','jmp'] and re.fullmatch('0x[0-9a-f]+',row['operand']):targets.add(int(row['operand'],16))
    match=re.search(r'\[rip ([+-]) 0x([0-9a-f]+)\]',row['operand'])
    if match:
     delta=int(match[2],16)*(1 if match[1]=='+' else -1);address=int(row['VA'],16)+row['size']+delta;row['RIP_absolute_address']=hex(address)
     try:
      u=v.usage(address)
      if u['kind']==5:u['literal']=literal(v,u['index'])
      usages[hex(address)]=u
     except (ValueError,UnicodeError) as e:pass
   methods.append({'original':m,'native_pointer':hex(va),'runtime_function':w,'instructions':ins})
  direct,skipped=aliases(v,targets)
  specs={u['index']for u in usages.values()if u['kind']==6};generic=v.generic_targets(specs)
  td=v.row('typeDefinitions',methods[0]['original']['owner_index'],88);start=v.i32(md,td+32);count=v.u16(md,td+68);offsets=v.u64(b,v.field_offsets+methods[0]['original']['owner_index']*8);fields=[]
  for i in range(count):
   at=v.row('fields',start+i,12);t=v.native_type(v.i32(md,at+4));fields.append({'index':start+i,'token':hex(v.u32(md,at+8)),'name':v.string(v.i32(md,at)),'type':v.typename(t),'native_type':t,'offset':v.i32(b,v.raw(offsets+i*4,4))})
 d.close();need(before==[(p.stat().st_size,p.stat().st_mtime_ns)for p in paths],'Sources changed');out=ROOT/'Validation'/('NativeNameserverRouter-'+datetime.datetime.now(datetime.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-nameserver-native-bounded-disassembly-and-dependencies/v1','status':'native_evidence_only_not_reconstructed','source_availability_proof':{'path':str(proof),'sha256':sha(proof)},'trusted_capstone':{'path':str(CAP),'sha256':CAPSHA,'version':'4.0','fixture_passed':True},'methods':methods,'RIP_metadata_usages':usages,'direct_call_or_tail_targets':direct,'unbacked_alias_tables_or_unmatched_tokens':skipped,'generic_method_registrations':generic,'original_router_fields_and_offsets':fields,'current_planned_temporary_nameserver':'https://ns.nerlz.com','game_or_managed_or_Unity_code_invoked':False,'trusted_disassembler_only_native_library_loaded':True,'Main_or_backend_changed':False,'network_requests':0,'tool':{'path':str(Path(__file__)),'sha256':sha(Path(__file__))}};p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'instructions':[{'name':r['original']['name'],'count':len(r['instructions'])}for r in methods],'metadata_usages':len(usages),'alias_gaps':len(skipped)}))
 for m in methods:
  print('\nMETHOD '+m['original']['name'])
  for r in m['instructions']:print(r['VA']+' '+r['mnemonic']+' '+r['operand'])
if __name__=='__main__':main()
