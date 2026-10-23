"""Bounded original registration joins for ReviveButton direct dependencies."""
from pathlib import Path
import bisect,hashlib,json,mmap,struct,sys,collections
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE));from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha

def main():
 folder=Path(sys.argv[1]);out=Path(sys.argv[2]);need(not out.exists(),'Fresh dependency report required');inventory=json.loads((folder/'inventory.json').read_text());methods={r['original']['index']:r for r in inventory['methods']};decoded={json.loads(l)['native_method_index']:json.loads(l) for l in (folder/'instructions.jsonl').read_text().splitlines()};targets=set();calls=[]
 for index,row in decoded.items():
  region=methods[index]['runtime_function'];lo=int(methods[index]['native_pointer'],16);hi=lo+len(bytes.fromhex(region['bytes']))
  for ins in row['instructions']:
   if ins['flow'] not in ('Call','UnconditionalBranch') or not ins['operands']:continue
   target=ins['operands'][0]['target']
   if not target:continue
   local=lo<=target<hi
   calls.append({'caller':methods[index]['original']['name'],'caller_token':methods[index]['original']['token'],'instruction_address':hex(ins['ip']),'flow':ins['flow'],'target':hex(target),'inside_same_recorded_region':local})
   if not local:targets.add(target)
 paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Original source changed');paths.append(p)
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);direct_hits={target:[] for target in targets};direct_counts=collections.Counter();wanted={};zero_fill_tables=[]
  for image,module in v.modules.items():
   if module['count']==0:continue
   try:at=v.raw(module['pointers_va'],module['count']*8)
   except ValueError:
    pe=v.u32(b,60);opt=pe+24;matched=[]
    for sn in range(v.u16(b,pe+6)):
     sa=opt+v.u16(b,pe+20)+sn*40;virtual_size,srva,raw_size,file_offset=struct.unpack_from('<IIII',b,sa+8);rv=module['pointers_va']-v.base
     if srva+raw_size<=rv and rv+module['count']*8<=srva+virtual_size:matched.append({'section_rva':srva,'section_virtual_size':virtual_size,'section_raw_size':raw_size,'table_rva':rv,'pointer_count':module['count']})
    need(len(matched)==1,'Unbacked table is not uniquely loader-zero-filled');zero_fill_tables.append({'image':image,'initial_file_image_pointer_table_values':0,'PE_zero_fill_evidence':matched[0]});continue
   for rid,(pointer,) in enumerate(struct.iter_unpack('<Q',b[at:at+module['count']*8]),1):
    if pointer in targets:
     direct_counts[pointer]+=1
     if direct_counts[pointer]<=128:wanted[(image,0x06000000|rid)]=pointer
  images=sorted(v.images,key=lambda i:i['start']);starts=[x['start'] for x in images];wanted_tokens={token for image,token in wanted}
  for index in range(v.count('methods',32)):
   ma=v.row('methods',index,32);token=v.u32(md,ma+20)
   if token not in wanted_tokens:continue
   owner=v.i32(md,ma+4);image=images[bisect.bisect_right(starts,owner)-1];need(image['start']<=owner<image['start']+image['count'],'Original image gap');pointer=wanted.get((image['name'],token))
   if pointer is None:continue
   try:info=v.method_info(index)
   except ValueError as error:info={'index':index,'owner':v.full_name(owner),'owner_index':owner,'name':v.string(v.i32(md,ma)),'token':hex(token),'image':image['name'],'flags':v.u16(md,ma+24),'impl_flags':v.u16(md,ma+26),'signature_unresolved':str(error)}
   direct_hits[pointer].append(info)
  generic_pointer_indexes={};generic_counts=collections.Counter();generic_hits={target:[] for target in targets}
  for n in range(v.generic_pointer_count):
   pointer=v.u64(b,v.generic_pointers+n*8)
   if pointer in targets:generic_pointer_indexes[n]=pointer
  for n in range(v.generic_table_count):
   spec,pointer_index,invoker,adjustor=struct.unpack_from('<iiii',b,v.generic_table+n*16);pointer=generic_pointer_indexes.get(pointer_index)
   if pointer is None:continue
   generic_counts[pointer]+=1
   if len(generic_hits[pointer])>=64:continue
   definition,ci,mi=struct.unpack_from('<iii',b,v.method_specs+spec*12)
   try:entry={'method_spec_index':spec,'method':v.method_info(definition),'class_arguments':[v.typename(t) for t in v.inst(ci)],'method_arguments':[v.typename(t) for t in v.inst(mi)],'registration_index':n,'adjustor_thunk_index':adjustor}
   except ValueError as error:entry={'method_spec_index':spec,'method_definition_index':definition,'class_inst_index':ci,'method_inst_index':mi,'registration_index':n,'unresolved_TypeSpec':str(error)}
   generic_hits[pointer].append(entry)
  dependency=[]
  for target in sorted(targets):dependency.append({'native_target':hex(target),'direct_MethodDef_pointer_match_count':direct_counts[target],'direct_MethodDefs':direct_hits[target],'generic_registration_match_count':generic_counts[target],'generic_MethodSpecs':generic_hits[target],'identity_is_ambiguous_if_multiple':True,'counts_above_record_limits_explicitly_truncated':direct_counts[target]>128 or generic_counts[target]>64})
  # Read only the actual inheritance chain, with original generic definition identities.
  ti=inventory['original_type']['index'];chain=[]
  while ti>=0 and len(chain)<8:
   ta=v.row('typeDefinitions',ti,88);count=v.u16(md,ta+68);first=v.i32(md,ta+32);ptr=v.u64(b,v.field_offsets+ti*8);offsets=v.raw(ptr,count*4) if count else None;fields=[]
   for ordinal in range(count):
    fa=v.row('fields',first+ordinal,12);nt=v.native_type(v.i32(md,fa+4))
    try:typename=v.typename(nt)
    except ValueError:typename=None
    fields.append({'ordinal':ordinal,'name':v.string(v.i32(md,fa)),'original_token':hex(v.u32(md,fa+8)),'type':typename,'native_type':nt,'registered_offset':v.i32(b,offsets+ordinal*4)})
   chain.append({'original_type':v.type_info(ti),'fields':fields});parent=v.i32(md,ta+16)
   if parent<0:break
   nt=v.native_type(parent)
   if nt['kind']==21:nt=v.type_at(v.u64(b,v.raw(nt['data'],8)))
   if nt['kind'] not in (17,18):break
   ti=nt['data']
  ctor=next(r for r in decoded.values() if methods[r['native_method_index']]['original']['name']=='.ctor');usage_instructions=[i for i in ctor['instructions'] if i['mnemonic']=='Lea' and i['memory']['ip_relative']];ctor_usages=[]
  for i in usage_instructions:
   try:ctor_usages.append(v.usage(i['memory']['ip_relative_address']))
   except ValueError as error:ctor_usages.append({'address':hex(i['memory']['ip_relative_address']),'unresolved':str(error)})
  report={'schema':'original-ReviveButton-native-dependencies/v1','inventory':{'path':str(folder/'inventory.json'),'sha256':sha(folder/'inventory.json')},'disassembly':{'path':str(folder/'instructions.jsonl'),'sha256':sha(folder/'instructions.jsonl')},'tool':{'path':str(Path(__file__).resolve()),'sha256':sha(Path(__file__))},'call_and_jump_sites':calls,'native_target_registration_matches':dependency,'PE_loader_zero_initialized_method_pointer_tables':zero_fill_tables,'original_inheritance_field_layouts':chain,'constructor_metadata_usages':ctor_usages,'managed_callees_not_inferred_when_native_body_shared':True,'source_bodies_rewritten':False,'project_modified':False,'game_code_executed':False}
 out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'external_native_targets':len(targets),'direct_pointer_matches':sum(direct_counts.values()),'generic_registration_matches':sum(generic_counts.values())}))
if __name__=='__main__':main()
