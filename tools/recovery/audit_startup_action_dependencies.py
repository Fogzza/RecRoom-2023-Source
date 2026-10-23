"""Original native login-action CFG/call/metadata dependency evidence only."""
import bisect,collections,hashlib,json,mmap,struct,sys
from pathlib import Path
HERE=Path(__file__).resolve().parent;WORKSPACE=HERE.parents[2];ROOT=WORKSPACE/'Recovery/RecRoom-2023-04-18'
sys.path.insert(0,str(HERE));sys.path.insert(0,str(HERE.parent/'ConstructorEvidence'))
from collect_all_pinvoke_native import ExternMetadata,need
from audit_forwarding import EXPECTED,sha
def main():
 folder=Path(sys.argv[1]);out=folder/'login-action-dependencies.json';need(not out.exists(),'Fresh output required');inventory=json.loads((folder/'login-action-disassembly-input.json').read_bytes());methods={r['original']['index']:r for r in inventory['methods']};decoded={r['native_method_index']:r for r in map(json.loads,(folder/'login-action-instructions-v2.jsonl').read_text().splitlines())};targets=set();sites=[];rip=[]
 for index,row in decoded.items():
  lo=int(methods[index]['native_pointer'],16);hi=lo+len(bytes.fromhex(methods[index]['runtime_function']['bytes']))
  for ins in row['instructions']:
   if ins['flow'] in ('Call','UnconditionalBranch','ConditionalBranch') and ins['operands']:
    target=ins['operands'][0]['target']
    if target:
     local=lo<=target<hi;sites.append({'caller':methods[index]['original'],'instruction':ins,'target':hex(target),'inside_recorded_region':local})
     if not local:targets.add(target)
   if ins['memory']['ip_relative']:rip.append({'caller':methods[index]['original'],'instruction':ins})
 paths=[]
 for rel,digest in EXPECTED.items():
  p=ROOT/'CodeSource'/rel;need(sha(p)==digest,'Verified original source changed');paths.append(p)
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
  v=ExternMetadata(b,md);hits={t:[] for t in targets};counts=collections.Counter();wanted={};zero=[]
  for image,module in v.modules.items():
   if not module['count']:continue
   try:at=v.raw(module['pointers_va'],module['count']*8)
   except ValueError:
    pe=v.u32(b,60);opt=pe+24;matches=[]
    for n in range(v.u16(b,pe+6)):
     sa=opt+v.u16(b,pe+20)+n*40;vs,rva,rs,fo=struct.unpack_from('<IIII',b,sa+8);table=module['pointers_va']-v.base
     if rva+rs<=table and table+module['count']*8<=rva+vs:matches.append({'section_rva':rva,'virtual_size':vs,'raw_size':rs,'table_rva':table,'pointer_count':module['count']})
    need(len(matches)==1,'Unbacked module table not proved loader-zero-filled');zero.append({'image':image,'PE_zero_fill':matches[0]});continue
   for rid,(pointer,) in enumerate(struct.iter_unpack('<Q',b[at:at+module['count']*8]),1):
    if pointer in targets:
     counts[pointer]+=1
     if counts[pointer]<=64:wanted[(image,0x06000000|rid)]=pointer
  images=sorted(v.images,key=lambda x:x['start']);starts=[x['start'] for x in images];wanted_tokens={token for image,token in wanted}
  for mi in range(v.count('methods',32)):
   ma=v.row('methods',mi,32);token=v.u32(md,ma+20)
   if token not in wanted_tokens:continue
   owner=v.i32(md,ma+4);image=images[bisect.bisect_right(starts,owner)-1];need(image['start']<=owner<image['start']+image['count'],'Original owner image gap');pointer=wanted.get((image['name'],token))
   if pointer is None:continue
   try:m=v.method_info(mi)
   except ValueError as error:m={'index':mi,'name':v.string(v.i32(md,ma)),'owner':v.full_name(owner),'token':hex(token),'signature_unresolved':str(error)}
   hits[pointer].append(m)
  gp={};gc=collections.Counter();gh={t:[] for t in targets}
  for n in range(v.generic_pointer_count):
   pointer=v.u64(b,v.generic_pointers+n*8)
   if pointer in targets:gp[n]=pointer
  for n in range(v.generic_table_count):
   spec,pi,inv,adj=struct.unpack_from('<iiii',b,v.generic_table+n*16);pointer=gp.get(pi)
   if pointer is None:continue
   gc[pointer]+=1
   if len(gh[pointer])>=32:continue
   definition,ci,mi=struct.unpack_from('<iii',b,v.method_specs+spec*12)
   try:row={'method_spec':spec,'method':v.method_info(definition),'class_arguments':[v.typename(t) for t in v.inst(ci)],'method_arguments':[v.typename(t) for t in v.inst(mi)],'adjustor':adj}
   except ValueError as error:row={'method_spec':spec,'definition':definition,'unresolved':str(error)}
   gh[pointer].append(row)
  dependencies=[{'native_target':hex(t),'direct_count':counts[t],'direct_methods':hits[t],'generic_count':gc[t],'generic_methods':gh[t],'record_limit_direct':64,'record_limit_generic':32,'ambiguous_identity':counts[t]+gc[t]!=1} for t in sorted(targets)]
  usages=[]
  for row in rip:
   address=row['instruction']['memory']['ip_relative_address']
   try:usage=v.usage(address)
   except ValueError as error:usage={'unresolved_or_not_metadata_usage':str(error)}
   usages.append({**row,'decoded_original_usage':usage})
  layouts=[]
  for ti in sorted({r['original']['owner_index'] for r in inventory['methods']}):
   td=v.row('typeDefinitions',ti,88);fs=v.i32(md,td+32);fc=v.u16(md,td+68);fp=v.raw(v.u64(b,v.field_offsets+ti*8),fc*4) if fc else None;fields=[]
   for ordinal in range(fc):
    fa=v.row('fields',fs+ordinal,12);nt=v.native_type(v.i32(md,fa+4))
    try:name=v.typename(nt)
    except ValueError:name=None
    fields.append({'ordinal':ordinal,'name':v.string(v.i32(md,fa)),'original_token':hex(v.u32(md,fa+8)),'type':name,'native_type':nt,'registered_offset':v.i32(b,fp+ordinal*4)})
   layouts.append({'original_type':v.type_info(ti),'fields':fields})
 report={'schema':'original-login-action-CFG-and-dependencies/v1','inputs':[{'path':str(p),'sha256':sha(p)} for p in paths],'inventory':{'path':str(folder/'login-action-disassembly-input.json'),'sha256':sha(folder/'login-action-disassembly-input.json')},'disassembly':{'path':str(folder/'login-action-instructions-v2.jsonl'),'sha256':sha(folder/'login-action-instructions-v2.jsonl')},'call_and_branch_sites':sites,'native_target_registration_matches':dependencies,'RIP_metadata_usages':usages,'original_owner_field_layouts':layouts,'zero_filled_module_tables':zero,'all_native_shared_target_ambiguities_retained':True,'source_or_meta_modified':False,'game_code_executed':False,'complete_callback_body_recovery_claim':False};out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'methods':len(methods),'external_targets':len(targets),'unique_original_targets':sum(not x['ambiguous_identity'] for x in dependencies),'project_modified':False}))
if __name__=='__main__':main()
