"""Meaningful fail-closed controls for the production static binding proof."""
from pathlib import Path
import copy,hashlib,json,mmap,sys
HERE=Path(__file__).resolve().parent;sys.path.insert(0,str(HERE))
from prove_all_pinvoke_resolver_args import prove,stack_probe_proof,STACK_PROBE_BYTES,RESOLVE,ExternMetadata,ROOT,EXPECTED,sha,need

def main():
 folder=Path(sys.argv[1]);out=Path(sys.argv[2]);need(not out.exists(),'Fresh fixture output required')
 inventory=json.loads((folder/'native-wrapper-inventory-v2.json').read_text());binding=json.loads((folder/'effective-bindings-v5.json').read_text());need(binding['proven_count']==846 and not binding['unresolved'],'Complete positive proof prerequisite')
 by_index={r['original']['index']:r for r in inventory['methods']};names={'SteamAPI_Init','SteamInternal_CreateInterface','SteamEncryptedAppTicket_BDecryptTicket','ISteamUGC_GetQueryUGCResult'}
 selected=set();seen_modules=set()
 for row in binding['methods']:
  module=row['effective_binding']['module']['value']
  if module not in seen_modules or row['original']['name'] in names:selected.add(row['original']['index']);seen_modules.add(module)
 decoded={}
 with (folder/'instructions.jsonl').open() as f:
  for line in f:
   d=json.loads(line)
   if d['native_method_index'] in selected:decoded[d['native_method_index']]=d
 need(set(decoded)==selected,'Fixture variants missing');paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Original native inputs changed');paths.append(p)
 checks=[]
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md)
  def negative(row,ins,label,mutate):
   r=copy.deepcopy(row);d=copy.deepcopy(ins);mutate(r,d)
   try:prove(v,r,d)
   except (ValueError,KeyError,IndexError,UnicodeError) as error:checks.append({'native_token':row['original']['token'],'name':row['original']['name'],'negative':label,'rejected':True,'error':str(error)})
   else:raise AssertionError('Unsafe mutation accepted: '+label+' '+row['original']['name'])
  for index in sorted(selected):
   row=by_index[index];ins=decoded[index];prove(v,row,copy.deepcopy(ins));checks.append({'native_token':row['original']['token'],'name':row['original']['name'],'positive_original':True})
   call_index=next(i for i,x in enumerate(ins['instructions']) if x['flow']=='Call' and x['operands'][0]['target']==RESOLVE)
   branch_index=next(i for i,x in enumerate(ins['instructions'][:call_index]) if x['mnemonic']=='Jne')
   argument_pointer=next(i for i,x in enumerate(ins['instructions'][:call_index]) if x['mnemonic']=='Lea' and x['operands'][0]['register']=='RCX')
   enum_store=next(i for i,x in enumerate(ins['instructions'][branch_index+1:call_index],branch_index+1) if x['mnemonic']=='Mov' and x['operands'][0]['kind']=='Memory' and x['operands'][1]['kind'].startswith('Immediate') and x['memory']['size']==4)
   def flip_bytes(r,d):
    code=bytearray.fromhex(r['runtime_function']['bytes']);code[0]^=1;r['runtime_function']['bytes']=code.hex()
   negative(row,ins,'original native function byte changed',flip_bytes)
   negative(row,ins,'original MethodDef token changed',lambda r,d:r['original'].__setitem__('token',hex(int(r['original']['token'],16)^1)))
   negative(row,ins,'cache hit join shifted one byte',lambda r,d:d['instructions'][branch_index]['operands'][0].__setitem__('target',d['instructions'][branch_index]['operands'][0]['target']+1))
   negative(row,ins,'cache branch condition reversed',lambda r,d:d['instructions'][branch_index].__setitem__('mnemonic','Je'))
   negative(row,ins,'resolver argument pointer misaligned one byte',lambda r,d:d['instructions'][argument_pointer]['memory'].__setitem__('displacement',d['instructions'][argument_pointer]['memory']['displacement']+1))
   negative(row,ins,'invalid native ABI enum or parameter size',lambda r,d:d['instructions'][enum_store]['operands'][1].__setitem__('immediate',0xffffffff))
   write_index=call_index+1
   if ins['instructions'][write_index]['operands'][0]['kind']=='Register':write_index+=1
   negative(row,ins,'resolved pointer cached at different native address',lambda r,d:d['instructions'][write_index]['memory'].__setitem__('ip_relative_address',d['instructions'][write_index]['memory']['ip_relative_address']+8))
  for i in range(len(STACK_PROBE_BYTES)):
   changed=bytearray(STACK_PROBE_BYTES);changed[i]^=1
   try:stack_probe_proof(v,bytes(changed))
   except ValueError:checks.append({'negative':'stack helper original opcode byte changed','byte':i,'rejected':True})
   else:raise AssertionError('Mutated stack helper accepted')
 report={'schema':'batch-native-binding-production-proof-controls/v1','passed':True,'positive_original_variant_count':len(selected),'negative_count':sum(c.get('rejected',False) for c in checks),'checks':checks,'production_proof_source':{'path':str(HERE/'prove_all_pinvoke_resolver_args.py'),'sha256':sha(HERE/'prove_all_pinvoke_resolver_args.py')},'fixture_source':{'path':str(Path(__file__).resolve()),'sha256':sha(Path(__file__))},'game_or_native_code_executed':False,'original_files_modified':False}
 out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'passed':True,'positive_variants':len(selected),'negative_count':report['negative_count'],'report':str(out)}))
if __name__=='__main__':main()
