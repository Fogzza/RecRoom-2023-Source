"""Prove static original PInvokeArguments at the exact original resolver calls.

This does not reconstruct stripped ImplMap bits or execute an import. It follows
the unique cache-miss fallthrough into each resolver using bounded, decoded x64
instructions and byte-exact original function ranges/registrations.
"""
from pathlib import Path
import hashlib,json,mmap,struct,sys,collections
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
from audit_original_pinvoke_wrappers import resolver as resolver_proof
from audit_generic_forwarders import runtime_range
RESOLVE=0x1806c03f0
STACK_PROBE=0x1806c1650
STACK_PROBE_BYTES=bytes.fromhex('4883ec104c8914244c895c24084d33db4c8d5424184c2bd04d0f42d3654c8b1c25100000004d3bd37316664181e200f04d8d9b00f0ffff41c603004d3bd375f04c8b14244c8b5c24084883c410c3')
def stack_probe_proof(v,override=None):
 start,end,code=runtime_range(v,STACK_PROBE)
 if override is not None:code=override
 need(code==STACK_PROBE_BYTES and end-start==78,'Original complete stack-probe helper bytes differ')
 return {'address':hex(STACK_PROBE),'start_rva':start,'end_rva':end,'bytes':code.hex(),'sha256':hashlib.sha256(code).hexdigest(),
  'instruction_semantics':'SUB RSP,16; saveR10/R11; calculate requested stack target from callerRSP minusRAX; readGS:0x10; bounded page-touch loop; restoreR10/R11; ADD RSP,16; RET.',
  'RAX_unchanged':True,'all_other_GPRs_unchanged':True,'R10_R11_saved_and_restored':True,'RSP_restored_before_RET':True,'contains_any_call':False,'memory_effect':'Save/restore private scratch stack cells and zero-touch successive stack pages; caller argument buffer is fully reassigned after this helper.',
  'helper_original_symbol_name_claimed':False,'game_code_executed':False}
class Stack:
 def __init__(self,n):self.n=n
 def __repr__(self):return 'RSPentry'+str(self.n)
class Cache:
 def __init__(self,address):self.address=address
def full(r):
 r=r.upper()
 groups={'AL':'RAX','AH':'RAX','AX':'RAX','EAX':'RAX','CL':'RCX','CH':'RCX','CX':'RCX','ECX':'RCX','DL':'RDX','DH':'RDX','DX':'RDX','EDX':'RDX','BL':'RBX','BH':'RBX','BX':'RBX','EBX':'RBX','SIL':'RSI','SI':'RSI','ESI':'RSI','DIL':'RDI','DI':'RDI','EDI':'RDI','BPL':'RBP','BP':'RBP','EBP':'RBP','SPL':'RSP','SP':'RSP','ESP':'RSP'}
 if r in groups:return groups[r]
 if r.startswith('R') and r[1:].rstrip('DWBL').isdigit():return 'R'+r[1:].rstrip('DWBL')
 return r
def width(r):
 if r.startswith('XMM'):return 16
 if r.startswith('YMM'):return 32
 if r in ('AL','AH','BL','BH','CL','CH','DL','DH','SIL','DIL','BPL','SPL') or (r.startswith('R') and r.endswith(('B','L'))):return 1
 if r.startswith('E') or (r.startswith('R') and r.endswith('D')):return 4
 if r in ('AX','BX','CX','DX','SI','DI','BP','SP') or (r.startswith('R') and r.endswith('W')):return 2
 return 8
def signed(n):return n-(1<<64) if n>=(1<<63) else n
def location(i,registers):
 m=i['memory']
 if m['ip_relative']:return m['ip_relative_address']
 if m['index']!='None':return None
 base=registers.get(full(m['base_register']))
 if isinstance(base,Stack):return Stack(base.n+signed(m['displacement']))
 if isinstance(base,int):return base+signed(m['displacement'])
 return None
def literal(v,p,n,wide):
 need(isinstance(p,int) and 0<n<=512,'Bounded original literal pointer/length required')
 width=2 if wide else 1;at=v.raw(p,(n+1)*width);data=bytes(v.b[at:at+(n+1)*width]);need(data[-width:]==b'\0'*width,'Original literal terminator missing');text=data[:-width].decode('utf-16le' if wide else 'ascii');need('\0' not in text and text.isprintable(),'Non-printable/embedded-null native import literal')
 return {'value':text,'native_address':hex(p),'length_without_terminator':n,'character_width':width,'bytes_with_terminator':data.hex(),'sha256':hashlib.sha256(data).hexdigest()}

def prove(v,row,decoded):
 original=row['original'];code=bytes.fromhex(row['runtime_function']['bytes']);va=int(row['native_pointer'],16);at=v.raw(va,len(code));need(bytes(v.b[at:at+len(code)])==code and hashlib.sha256(code).hexdigest()==row['runtime_function']['sha256'],'Complete wrapper bytes changed')
 actual=v.method_info(original['index']);actual['declaring_type']=v.type_info(actual['owner_index']);need(actual==original and actual['image']=='Assembly-CSharp.dll' and actual['flags']&0x2000 and v.method_pointer(actual)==va,'Original native MethodDef/owner/token/registration join differs')
 ins=decoded['instructions'];need(ins and ins[0]['ip']==va and sum(i['length'] for i in ins)==len(code),'Decoded function extent differs')
 for a,b in zip(ins,ins[1:]):need(a['ip']+a['length']==b['ip'],'Instruction range is not contiguous')
 calls=[n for n,i in enumerate(ins) if i['flow']=='Call' and i['operands'][0]['target']==RESOLVE];need(len(calls)==1,'Unique original resolver call required');call_index=calls[0]
 registers={'RSP':Stack(0)};memory={};provenance={};branches=[];first_argument_store=None;cache_loads=[];last_condition=None;prior_helpers=[]
 def value(op):
  if op['kind']=='Register':
   x=registers.get(full(op['register']))
   if isinstance(x,int):return x&((1<<(8*width(op['register'])))-1)
   if isinstance(x,(Stack,Cache)) and width(op['register'])!=8:return None
   return x
  if op['kind'].startswith('Immediate'):return op['immediate']
  return None
 def store(address,n,val,ip):
  if not isinstance(address,Stack):return
  if isinstance(val,int):data=(val&((1<<(8*n))-1)).to_bytes(n,'little')
  elif isinstance(val,bytes) and len(val)==n:data=val
  else:data=None
  for k in range(n):
   if data is None:memory.pop(address.n+k,None);provenance.pop(address.n+k,None)
   else:memory[address.n+k]=data[k];provenance[address.n+k]=ip
 for index,i in enumerate(ins[:call_index]):
  op=i['operands'];mn=i['mnemonic'];p=location(i,registers)
  if mn=='Push':
   need(isinstance(registers.get('RSP'),Stack),'Stack pointer became unknown');registers['RSP']=Stack(registers['RSP'].n-8);continue
  if mn in ('Sub','Add') and op[0]['kind']=='Register' and full(op[0]['register'])=='RSP':
   amount=value(op[1]);need(isinstance(amount,int) and amount<=65536,'Unknown or excessive stack frame');need(isinstance(registers.get('RSP'),Stack),'Stack base unknown');registers['RSP']=Stack(registers['RSP'].n+(-amount if mn=='Sub' else amount));last_condition=None;continue
  if mn in ('Mov','Movaps','Movups','Movdqa','Movdqu','Movzx','Movsx','Movsxd'):
   if op[0]['kind']=='Register':
    target=full(op[0]['register'])
    if op[1]['kind']=='Memory':
     if i['memory']['ip_relative'] and i['memory']['size']==8:
      cache_loads.append((i['ip'],target,i['memory']['ip_relative_address']));registers[target]=Cache(i['memory']['ip_relative_address'])
     else:registers[target]=None
    else:
     incoming=value(op[1])
     if isinstance(incoming,(Stack,Cache)) and (mn!='Mov' or width(op[0]['register'])!=8):incoming=None
     if isinstance(incoming,int) and mn in ('Movsx','Movsxd'):
      bits=8*width(op[1]['register']);incoming=incoming-(1<<bits) if incoming&(1<<(bits-1)) else incoming
     registers[target]=incoming
   elif op[0]['kind']=='Memory':
    if isinstance(p,Stack) and first_argument_store is None and op[1]['kind'].startswith('Immediate'):first_argument_store=i['ip']
    store(p,i['memory']['size'],value(op[1]),i['ip'])
   else:raise ValueError('Unsupported MOV destination')
   continue
  if mn=='Lea':
   need(op[0]['kind']=='Register' and op[1]['kind']=='Memory','Unexpected LEA shape');registers[full(op[0]['register'])]=p;continue
  if mn=='Xor' and op[0]['kind']==op[1]['kind']=='Register' and op[0]['register']==op[1]['register']:
   registers[full(op[0]['register'])]=0;last_condition=None;continue
  if mn in ('Test','Cmp'):last_condition=i;continue
  if mn=='Jne':
   need(i['flow']=='ConditionalBranch' and last_condition is not None,'Unexpected cache branch flow');branches.append((i,last_condition))
   # Along this exact JNE fallthrough a full-width TEST r,r proves r==0.
   # Some native wrappers reuse that zero register for isNoMangle.
   condition_ops=last_condition['operands']
   if last_condition['mnemonic']=='Test' and len(condition_ops)==2 and condition_ops[0]['kind']==condition_ops[1]['kind']=='Register' and condition_ops[0]['register']==condition_ops[1]['register'] and width(condition_ops[0]['register'])==8:
    reg=full(condition_ops[0]['register']);need(isinstance(registers.get(reg),Cache),'Cache test register does not retain exact cache load');last_condition['proven_live_cache_address']=registers[reg].address;registers[reg]=0
   continue
  if mn=='Call':
   need(op[0]['target']==STACK_PROBE and isinstance(registers.get('RAX'),int) and 0<registers['RAX']<=65536,'Prior call requires separate runtime-helper proof: '+hex(op[0]['target']))
   stack_probe_proof(v);prior_helpers.append({'call_address':hex(i['ip']),'target':hex(STACK_PROBE),'native_requested_stack_bytes':registers['RAX'],'all_GPRs_and_RSP_proved_preserved':True});memory.clear();provenance.clear();last_condition=None;continue
  raise ValueError('Unsupported resolver-prefix operation: '+i['text'])
 need(len(branches)==1,'Exactly one cache branch before resolver required')
 call=ins[call_index];base=registers.get('RCX');need(isinstance(base,Stack),'Resolver argument is not proven stack address')
 need(all(base.n+k in memory for k in range(45)),'PInvokeArguments has unknown bytes')
 buf=bytes(memory[base.n+k] for k in range(45));mp,ml,ep,el,conv,charset,size,nm=struct.unpack('<QQQQiiiB',buf)
 need(conv in range(6) and charset in range(3) and nm in (0,1) and 0<=size<=8192,'Native resolver ABI enum/size values invalid')
 module=literal(v,mp,ml,True);entry=literal(v,ep,el,False)
 need(call_index+1<len(ins),'Resolver return/cache store absent');cache_index=call_index+1;return_copies=[]
 if ins[cache_index]['mnemonic']=='Mov' and len(ins[cache_index]['operands'])==2 and all(o['kind']=='Register' for o in ins[cache_index]['operands']):
  copy=ins[cache_index];need(copy['operands'][1]['register']=='RAX' and width(copy['operands'][0]['register'])==8,'Resolver return copy differs');return_copies.append({'address':hex(copy['ip']),'destination_register':copy['operands'][0]['register'],'source_register':'RAX'});cache_index+=1
 need(cache_index<len(ins),'Cache store after return copy absent');cache_write=ins[cache_index]
 need(cache_write['mnemonic']=='Mov' and cache_write['operands'][0]['kind']=='Memory' and cache_write['memory']['ip_relative'] and cache_write['operands'][1]['kind']=='Register' and cache_write['operands'][1]['register']=='RAX' and cache_write['memory']['size']==8,'Resolver result must enter exact static cache')
 cache=cache_write['memory']['ip_relative_address'];branch,condition=branches[0];need(branch['operands'][0]['target']==cache_write['ip']+cache_write['length'],'Cache-hit branch must join immediately after cache write')
 if condition['mnemonic']=='Test':
  condition_ops=condition['operands'];need(len(condition_ops)==2 and condition_ops[0]['kind']==condition_ops[1]['kind']=='Register' and condition_ops[0]['register']==condition_ops[1]['register'] and width(condition_ops[0]['register'])==8,'Cache test must be identical64-bit registers');need(condition.get('proven_live_cache_address')==cache,'Cache test/load address differs')
 else:
  need(condition['mnemonic']=='Cmp' and condition['operands'][0]['kind']=='Memory' and condition['memory']['ip_relative'] and condition['memory']['ip_relative_address']==cache and value(condition['operands'][1])==0,'Cache compare address/value differs')
 stores=sorted(set(provenance[base.n+k] for k in range(45)));need(stores and stores[0]>branch['ip'],'Resolver arguments must be fully assigned after cache branch')
 native_calls=[i for i in ins[cache_index+1:] if i['flow']=='IndirectCall']
 return {'original':original,'original_native_pointer':hex(va),'registered_runtime_function_region':row['runtime_function'],
   'effective_binding':{'module':module,'entry_point':entry,'calling_convention':{'native_enum':conv,'native_name':['IL2CPP_CALL_DEFAULT','IL2CPP_CALL_C','IL2CPP_CALL_STDCALL','IL2CPP_CALL_THISCALL','IL2CPP_CALL_FASTCALL','IL2CPP_CALL_VARARG'][conv]},'char_set':{'native_enum':charset,'native_name':['CHARSET_ANSI','CHARSET_UNICODE','CHARSET_NOT_SPECIFIED'][charset]},'parameter_size_bytes':size,'is_no_mangle':bool(nm)},
   'resolver_call':{'address':hex(call['ip']),'target':hex(RESOLVE),'stack_base_relative_entry_rsp':base.n,'exact_45_argument_bytes':buf.hex(),'field_assignment_instruction_addresses':[hex(x) for x in stores],'proved_prior_runtime_helpers':prior_helpers},
   'native_cache':{'address':hex(cache),'cache_miss_branch':hex(branch['ip']),'cache_hit_join':hex(branch['operands'][0]['target']),'resolver_return_register_copies':return_copies,'resolver_return_store':hex(cache_write['ip'])},
   'original_method_flags':original['flags'],'original_method_impl_flags':original['impl_flags'],'native_indirect_call_sites':[{'address':hex(i['ip']),'instruction':i['text']} for i in native_calls],
   'managed_marshaling_metadata_fully_restored':False,'full_native_body_control_flow_or_split_unwind_regions_recovered':False,'stripped_ImplMap_original_attribute_bits_fully_recovered':False,'unobserved_import_flags':['SetLastError pending complete native wrapper region analysis','BestFitMapping','ThrowOnUnmappableChar','full original ImplMap flag bytes'],'claim_scope':'Effective original resolver inputs and cache-miss control flow only. A PE runtime-function region is not assumed to contain every split-unwind body region. Native marshaling/call behavior remains original evidence, not an invented managed binding.'}

def main():
 inventory=Path(sys.argv[1]);instructions=Path(sys.argv[2]);out=Path(sys.argv[3]);need(not out.exists(),'Fresh proof required');d=json.loads(inventory.read_text());by_index={r['original']['index']:r for r in d['methods']}
 need(len(d['methods'])==len(by_index)==846 and not d['unresolved'],'Exact846 original native wrappers required');rows=[];gaps=[];paths=[];seen=set()
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Original source SHA changed');paths.append(p)
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);runtime=resolver_proof(v);probe=stack_probe_proof(v)
  with instructions.open() as stream:
   for line in stream:
    decoded=json.loads(line);index=decoded['native_method_index'];need(index in by_index and index not in seen,'Unexpected/duplicate disassembly');seen.add(index);row=by_index[index]
    try:rows.append(prove(v,row,decoded))
    except Exception as e:gaps.append({'original':row['original'],'error':type(e).__name__+': '+str(e)})
  need(len(seen)==846,'Incomplete disassembly inventory')
 report={'schema':'batch-original-effective-pinvoke-resolver-proof/v1','inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'inventory':{'path':str(inventory),'sha256':sha(inventory)},'disassembly':{'path':str(instructions),'sha256':sha(instructions)},'tool':{'path':str(Path(__file__).resolve()),'sha256':sha(Path(__file__))},'original_resolver_proof':runtime,'bounded_stack_probe_helper_proof':probe,'proven_count':len(rows),'original_extern_count':846,'methods':rows,'unresolved':gaps,'module_counts':dict(collections.Counter(r['effective_binding']['module']['value'] for r in rows)),'project_modified':False,'native_libraries_invoked':False,'game_code_executed':False}
 out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'proven':len(rows),'unresolved':len(gaps),'modules':report['module_counts']}))
if __name__=='__main__':main()
