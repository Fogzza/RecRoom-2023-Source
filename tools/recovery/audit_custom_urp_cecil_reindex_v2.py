"""Pure continuation: complete CIL operands, omitted Params, actual writer API/IL.

Does not waive or change any staging gate. Reads only frozen DLLs.
"""
from pathlib import Path
import collections, datetime as dt, hashlib, json, struct, uuid
import audit_custom_urp_cecil_reindex as base
from audit_cli_marshal_contracts import Cli, need
from audit_hashable_scoped_vtable import Read

BASE_SHA='eddab5f598a824116005ba3cfd173e9221f435f3b3aeb070bdd341396c2cee45'
CECIL=base.ROOT/'Tools/RecoveryTools/RuntimeMetadataAudit/COMCompatibility-20261022T100736Z/Mono.Cecil.dll'

# ECMA-335 CIL instruction operand encodings. Unlisted/reserved opcodes fail closed.
NONE=set(range(0x00,0x0e))|set(range(0x14,0x1f))|{0x25,0x26,0x2a}|set(range(0x46,0x6f))|{0x76,0x7a}|set(range(0x82,0x8c))|{0x8e}|set(range(0x90,0xa3))|set(range(0xb3,0xbb))|{0xc3}|set(range(0xd1,0xdd))|{0xdf,0xe0}|{0xfe00,0xfe01,0xfe02,0xfe03,0xfe04,0xfe05,0xfe0f,0xfe11,0xfe13,0xfe14,0xfe17,0xfe18,0xfe1a,0xfe1d,0xfe1e}
TOKENS={0x27,0x28,0x29,0x6f,0x70,0x71,0x72,0x73,0x74,0x75,0x79,0x7b,0x7c,0x7d,0x7e,0x7f,0x80,0x81,0x8c,0x8d,0x8f,0xa3,0xa4,0xa5,0xc2,0xc6,0xd0,0xfe06,0xfe07,0xfe15,0xfe16,0xfe1c}
SHORT_VAR=set(range(0x0e,0x14));VAR=set(range(0xfe09,0xfe0f));SHORT_BRANCH=set(range(0x2b,0x38))|{0xde};BRANCH=set(range(0x38,0x45))|{0xdd}

def decode(model,mi):
 c=model.c;at=c.row(6,mi);rva=c.u32(at)
 if not rva:return None
 off=c.raw(rva,1);first=model.b[off]
 if first&3==2:header=1;length=first>>2;maxstack=8;flags=2;local=0
 else:
  need(first&3==3,'CIL fat/tiny header');flags=c.u16(off);header=(flags>>12)*4;need(header==12,'Exact standard fat header');maxstack=c.u16(off+2);length=c.u32(off+4);local=c.u32(off+8)
 need(length<1024*1024,'Bounded method CIL');start=c.raw(rva+header,length);code=model.b[start:start+length];rows=[];at=0;offsets={}
 while at<len(code):
  position=at;op=code[at];at+=1
  if op==0xfe:need(at<len(code),'Two byte opcode');op=(op<<8)|code[at];at+=1
  need(position not in offsets,'Unique instruction start');offsets[position]=len(rows);kind='literal';v=None
  if op in NONE:pass
  elif op in TOKENS:
   need(at+4<=len(code),'Metadata operand range');v=model.token(struct.unpack_from('<I',code,at)[0]);at+=4
  elif op in SHORT_VAR|{0xfe12,0xfe19}:
   need(at<len(code),'Byte operand range');v=code[at];at+=1
  elif op in VAR:
   need(at+2<=len(code),'Variable operand range');v=struct.unpack_from('<H',code,at)[0];at+=2
  elif op in SHORT_BRANCH:
   need(at<len(code),'Short branch range');v=at+1+struct.unpack_from('<b',code,at)[0];kind='branch';at+=1
  elif op in BRANCH:
   need(at+4<=len(code),'Branch range');v=at+4+struct.unpack_from('<i',code,at)[0];kind='branch';at+=4
  elif op==0x45:
   need(at+4<=len(code),'Switch count range');count=struct.unpack_from('<I',code,at)[0];at+=4;need(count<65536 and at+4*count<=len(code),'Bounded switch');end=at+4*count;v=[end+struct.unpack_from('<i',code,at+4*i)[0] for i in range(count)];at=end;kind='switch'
  elif op==0x1f:
   need(at<len(code),'Int8 operand range');v=struct.unpack_from('<b',code,at)[0];at+=1
  elif op in (0x20,0x21,0x22,0x23):
   size={0x20:4,0x21:8,0x22:4,0x23:8}[op];need(at+size<=len(code),'Numeric operand range');v={'raw_little_endian':code[at:at+size].hex()};at+=size
  else:raise ValueError('Unclassified CIL opcode '+hex(op)+' in '+model.names[6,mi])
  rows.append({'opcode':hex(op),'operand':v,'kind':kind})
 need(at==len(code),'Complete CIL consumed');offsets[len(code)]=len(rows)
 def ordinal(value):need(value in offsets,'Branch/EH boundary at actual instruction');return offsets[value]
 for row in rows:
  if row['kind']=='branch':row['operand']=ordinal(row['operand'])
  if row['kind']=='switch':row['operand']=[ordinal(v) for v in row['operand']]
  del row['kind']
 eh=[]
 if flags&8:
  section=(start+length+3)&~3
  while True:
   kind=model.b[section];need(kind&0x3f==1,'Only EH extra CIL section');fat=bool(kind&0x40);size=int.from_bytes(model.b[section+1:section+4],'little') if fat else model.b[section+1];width=24 if fat else 12;need((size-4)%width==0,'EH section width')
   for pos in range(section+4,section+size,width):
    if fat:ef,to,tl,ho,hl,value=struct.unpack_from('<IIIIII',model.b,pos)
    else:ef,to,tl,ho,hl,value=struct.unpack_from('<HHBHB I',model.b,pos)
    need(ef in (0,1,2,4),'Known EH clause kind');eh.append({'flags':ef,'try_start':ordinal(to),'try_end':ordinal(to+tl),'handler_start':ordinal(ho),'handler_end':ordinal(ho+hl),'catch_type':model.token(value) if ef==0 else None,'filter_start':ordinal(value) if ef==1 else None})
   if not kind&0x80:break
   section=(section+size+3)&~3
 return {'init_locals':bool(flags&0x10),'max_stack':maxstack,'locals':model.token(local) if local else None,'instructions':rows,'exception_handlers':eh}

def writer_proof():
 # Read the writer itself as inert bytes; no reflection/CLR execution.
 m=base.Model(CECIL);c=m.c;r=m.r;public=[];proof={}
 wanted={'AttachTokens','AttachTypeToken','AttachNestedTypesToken','AttachFieldsToken','AttachMethodsToken','AddParameters','RequiresParameterRow'}
 for ti in range(1,c.rows[2]+1):
  n=r.definition(ti)
  if n=='Mono.Cecil.WriterParameters':public=[{'name':row['name'],'signature':base.sig(row['signature'])} for row in r.methods(ti) if row['flags']&7==6]
  if n=='Mono.Cecil.MetadataBuilder':
   for row in r.methods(ti):
    if row['name'] in wanted:
     mi=int(row['token'],16)&0xffffff;proof[row['name']]={'token':row['token'],'visibility':row['flags']&7,'body':decode(m,mi)}
 return {'assembly':{'path':str(CECIL),'sha256':base.sha(CECIL)},'WriterParameters_public_methods':public,'RID_preservation_public_option_present':any('preserv' in x['name'].lower() or 'token' in x['name'].lower() for x in public),'writer_method_evidence':proof}

def run():
 need(base.sha(Path(base.__file__))==BASE_SHA,'Frozen prior diagnostic source');report=base.compare();a=base.Model(base.ORIGINAL);b=base.Model(base.CANDIDATE);bykey={v:ri for (t,ri),v in b.names.items() if t==6};body_rows=[];changed=[]
 for ri in range(1,a.c.rows[6]+1):
  identity=a.names[6,ri];other=bykey[identity];left=decode(a,ri);right=decode(b,other);equal=left==right;selected=(6<<24|ri) in base.SELECTED
  row={'identity':json.loads(identity),'original_token':hex(6<<24|ri),'emitted_token':hex(6<<24|other),'selected':selected,'scoped_entire_CIL_equal':equal,'original_body_sha256':hashlib.sha256(base.key(left).encode()).hexdigest(),'emitted_body_sha256':hashlib.sha256(base.key(right).encode()).hexdigest(),'original_has_body':left is not None,'emitted_has_body':right is not None}
  if not equal:row['original_body']=left;row['emitted_body']=right;changed.append(row)
  body_rows.append(row)
 report['method_body_comparison']={'definitions':len(body_rows),'unselected':len(body_rows)-len(base.SELECTED),'unselected_scoped_entire_CIL_equal':all(row['scoped_entire_CIL_equal'] for row in body_rows if not row['selected']),'changed_original_tokens':[x['original_token'] for x in changed],'rows':body_rows}
 # Every removed raw Param row has no metadata attachments; signatures retain the slot.
 removed=[]
 for row in report['definition_maps']['8']['removed']:
  ri=int(row['original_token'],16)&0xffffff;mi,sequence=a.param[ri];associations=[]
  for t,bits,tables in [(11,2,[4,8,23]),(12,5,[6,4,1,2,8,9,10,0,14,23,20,17,26,27,32,35,38,39,40,42,44,43]),(13,1,[4,8])]:
   for ar in range(1,a.c.rows[t]+1):
    at=a.c.row(t,ar)+(2 if t==11 else 0);v=a.c.value(at,a.c.coded(bits,tables));tag=v&((1<<bits)-1)
    if tag<len(tables) and tables[tag]==8 and v>>bits==ri:associations.append({'table':t,'rid':ar})
  need(sequence>=1 and sequence<=len(a.method[mi]['signature']['parameters']),'Ordinary argument metadata row');removed.append({**row,'ordinary_argument_signature_type':a.method[mi]['signature']['parameters'][sequence-1],'metadata_attachments':associations,'empty_name_zero_flags_no_attachment':row['original_value']['name']=='' and row['original_value']['flags']==0 and not associations})
 report['removed_Param_row_complete_diagnosis']=removed
 report['writer_preservation_evidence']=writer_proof()
 report['status']='data_only_full_finite_reindex_and_CIL_diagnosis_no_gate_changed'
 report['tool']={'path':str(Path(__file__).resolve()),'sha256':base.sha(Path(__file__)),'frozen_base':{'path':str(Path(base.__file__)),'sha256':BASE_SHA}}
 out=base.ROOT/'Recovery/RecRoom-2023-04-18/Validation'/('CustomUrpFiniteReindexDiagnosisV2-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':base.sha(p),'unselected_scoped_entire_CIL_equal':report['method_body_comparison']['unselected_scoped_entire_CIL_equal'],'changed_tokens':report['method_body_comparison']['changed_original_tokens'],'Param_omissions':len(removed),'all_omitted_Params_empty_zero_unattached':all(x['empty_name_zero_flags_no_attachment'] for x in removed),'writer_preserve_RIDs_option':report['writer_preservation_evidence']['RID_preservation_public_option_present']}))

if __name__=='__main__':run()
