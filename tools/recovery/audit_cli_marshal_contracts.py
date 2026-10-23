"""Read CLI metadata tables directly, never load a target assembly."""
import hashlib,json,mmap,struct,sys
from pathlib import Path
def need(v,s):
 if not v:raise ValueError(s)
class Cli:
 def __init__(self,b):
  self.b=b;self.u16=lambda x:struct.unpack_from('<H',b,x)[0];self.u32=lambda x:struct.unpack_from('<I',b,x)[0];self.u64=lambda x:struct.unpack_from('<Q',b,x)[0]
  pe=self.u32(60);need(b[:2]==b'MZ' and b[pe:pe+4]==b'PE\0\0','PE required');opt=pe+24;magic=self.u16(opt);need(magic in (0x10b,0x20b),'Unsupported PE');self.segments=[]
  for i in range(self.u16(pe+6)):
   at=opt+self.u16(pe+20)+i*40;vs,rva,rs,fo=struct.unpack_from('<IIII',b,at+8);self.segments.append((rva,rs,fo));need(fo+rs<=len(b),'PE section overflow')
  dd=opt+(112 if magic==0x20b else 96);cli=self.raw(self.u32(dd+14*8),72);self.meta=self.raw(self.u32(cli+8),self.u32(cli+12));need(self.u32(self.meta)==0x424a5342,'CLI metadata signature');at=self.meta+16+self.u32(self.meta+12);at=(at+3)&~3;stream_count=self.u16(at+2);at+=4;self.streams={}
  for _ in range(stream_count):
   off,size=struct.unpack_from('<II',b,at);name_at=at+8;end=b.find(b'\0',name_at,name_at+32);need(end>=name_at,'Stream name');name=bytes(b[name_at:end]).decode('ascii');need(name not in self.streams,'Duplicate metadata stream');self.streams[name]=(self.meta+off,size);at=(end+4)&~3
  tables,size=self.streams.get('#~',self.streams.get('#-',(None,None)));need(tables is not None,'Metadata tables absent');heap=b[tables+6];self.strw=4 if heap&1 else 2;self.guidw=4 if heap&2 else 2;self.blobw=4 if heap&4 else 2;valid=self.u64(tables+8);self.rows={};at=tables+24
  for table in range(64):
   self.rows[table]=self.u32(at) if valid&(1<<table) else 0
   if valid&(1<<table):at+=4
  need(not any(self.rows[x] for x in (3,5,7)),'Pointer tables need explicit logical-order implementation')
  s=self.strw;g=self.guidw;z=self.blobw;i=self.index;c=self.coded
  self.width={0:2+s+3*g,1:c(2,[0,26,35,1])+2*s,2:4+2*s+c(2,[2,1,27])+i(4)+i(6),3:i(4),4:2+s+z,5:i(6),6:8+s+z+i(8),7:i(8),8:4+s,9:i(2)+c(2,[2,1,27]),10:c(3,[2,1,26,6,27])+s+z,11:2+c(2,[4,8,23])+z,12:c(5,[6,4,1,2,8,9,10,0,14,23,20,17,26,27,32,35,38,39,40,42,44,43])+c(3,[6,10])+z,13:c(1,[4,8])+z}
  self.width.update({14:2+c(2,[2,6,32])+z,15:6+i(2),16:4+i(4),17:z,18:i(2)+i(20),19:i(20),20:2+s+c(2,[2,1,27]),21:i(2)+i(23),22:i(23),23:2+s+z,24:2+i(6)+c(1,[20,23]),25:i(2)+2*c(1,[6,10]),26:s,27:z,28:2+c(1,[4,6])+s+i(26),29:4+i(4),30:8,31:4,32:16+z+2*s,33:4,34:12,35:12+2*z+2*s,36:4+i(35),37:12+i(35),38:4+s+z,39:8+2*s+c(2,[38,35,39]),40:8+s+c(2,[38,35,39]),41:2*i(2),42:4+c(1,[2,6])+s,43:c(1,[6,10])+z,44:i(42)+c(2,[2,1,27])})
  need(not any(self.rows[t] for t in range(45,64)),'Unexpected non-ECMA PE table')
  self.offset={}
  for table in range(45):self.offset[table]=at;at+=self.width[table]*self.rows[table];need(at<=tables+size,'Metadata table overflow')
 def raw(self,rva,width):
  hits=[fo+rva-base for base,size,fo in self.segments if base<=rva and rva+width<=base+size];need(len(hits)==1,'Unbacked/ambiguous PE RVA');return hits[0]
 def index(self,table):return 4 if self.rows[table]>=65536 else 2
 def coded(self,bits,tables):return 4 if max(self.rows[x] for x in tables)>=(1<<(16-bits)) else 2
 def value(self,at,width):return self.u32(at) if width==4 else self.u16(at)
 def row(self,table,rid):need(1<=rid<=self.rows[table],'CLI RID out of bounds');return self.offset[table]+(rid-1)*self.width[table]
 def string(self,index):
  base,size=self.streams['#Strings'];need(0<=index<size,'CLI string bounds');end=self.b.find(b'\0',base+index,base+size);need(end>=base+index,'CLI string termination');return bytes(self.b[base+index:end]).decode('utf-8')
 def blob(self,index):
  base,size=self.streams['#Blob'];need(0<=index<size,'CLI blob bounds');at=base+index;lead=self.b[at]
  if lead<128:length=lead;header=1
  elif lead&0xc0==0x80:length=((lead&0x3f)<<8)|self.b[at+1];header=2
  elif lead&0xe0==0xc0:length=((lead&0x1f)<<24)|(self.b[at+1]<<16)|(self.b[at+2]<<8)|self.b[at+3];header=4
  else:raise ValueError('Invalid CLI compressed blob length')
  need(index+header+length<=size,'CLI blob range');return bytes(self.b[at+header:at+header+length])
 def audit(self):
  marshals={};marshal_rows=[]
  for rid in range(1,self.rows[13]+1):
   at=self.row(13,rid);parent=self.value(at,self.coded(1,[4,8]));key=(8 if parent&1 else 4,parent>>1);need(key not in marshals,'Duplicate FieldMarshal owner');blob=self.blob(self.value(at+self.coded(1,[4,8]),self.blobw));marshals[key]=rid;marshal_rows.append({'table_rid':rid,'owner_table':key[0],'owner_rid':key[1],'blob_hex':blob.hex()})
  types=[]
  for rid in range(1,self.rows[2]+1):
   at=self.row(2,rid);name=self.string(self.value(at+4,self.strw));ns=self.string(self.value(at+4+self.strw,self.strw));field_start=self.value(at+4+2*self.strw+self.coded(2,[2,1,27]),self.index(4));method_start=self.value(at+4+2*self.strw+self.coded(2,[2,1,27])+self.index(4),self.index(6));types.append({'rid':rid,'name':name,'namespace':ns,'display_owner':(ns+'.' if ns else '')+name,'method_start':method_start,'field_start':field_start})
  parents={}
  for rid in range(1,self.rows[41]+1):
   at=self.row(41,rid);child=self.value(at,self.index(2));parent=self.value(at+self.index(2),self.index(2));need(child not in parents and 1<=child<=len(types) and 1<=parent<=len(types) and child!=parent,'Invalid nested TypeDef ownership');parents[child]=parent
  def fullname(rid,seen=None):
   seen=set() if seen is None else seen;need(rid not in seen,'Cyclic nested TypeDefs');seen.add(rid);t=types[rid-1]
   return fullname(parents[rid],seen)+'/'+t['name'] if rid in parents else (t['namespace']+'.' if t['namespace'] else '')+t['name']
  for t in types:t['display_owner']=fullname(t['rid'])
  flagged=[];type_index=0
  for rid in range(1,self.rows[6]+1):
   while type_index+1<len(types) and types[type_index+1]['method_start']<=rid:type_index+=1
   at=self.row(6,rid);name=self.string(self.value(at+8,self.strw));params=self.value(at+8+self.strw+self.blobw,self.index(8));end=self.value(self.row(6,rid+1)+8+self.strw+self.blobw,self.index(8)) if rid<self.rows[6] else self.rows[8]+1;signature=self.blob(self.value(at+8+self.strw,self.blobw));method={'current_token':hex(0x06000000|rid),'method_rid':rid,'owner':types[type_index],'name':name,'flags':self.u16(at+6),'impl_flags':self.u16(at+4),'rva':self.u32(at),'signature_hex':signature.hex(),'param_list':params,'param_end':end}
   for pi in range(params,end):
    pa=self.row(8,pi);flags=self.u16(pa);sequence=self.u16(pa+2)
    if flags&0x2000 or (8,pi) in marshals:flagged.append({'method':method,'current_parameter_token':hex(0x08000000|pi),'sequence':sequence,'parameter_name':self.string(self.value(pa+4,self.strw)),'flags':flags,'has_FieldMarshal_flag':bool(flags&0x2000),'FieldMarshal_table_rid':marshals.get((8,pi)),'malformed_flag_without_blob':bool(flags&0x2000) and (8,pi) not in marshals})
  fields=[];type_index=0
  for rid in range(1,self.rows[4]+1):
   while type_index+1<len(types) and types[type_index+1]['field_start']<=rid:type_index+=1
   at=self.row(4,rid);flags=self.u16(at)
   if flags&0x1000 or (4,rid) in marshals:fields.append({'current_field_token':hex(0x04000000|rid),'owner':types[type_index],'name':self.string(self.value(at+2,self.strw)),'flags':flags,'has_FieldMarshal_flag':bool(flags&0x1000),'FieldMarshal_table_rid':marshals.get((4,rid)),'malformed_flag_without_blob':bool(flags&0x1000) and (4,rid) not in marshals})
  return {'schema':'direct-CLI-marshal-contract-inventory/v3','table_counts':self.rows,'declared_methods':self.rows[6],'flagged_parameters':flagged,'flagged_fields':fields,'FieldMarshal_rows':marshal_rows,'malformed_parameter_count':sum(x['malformed_flag_without_blob'] for x in flagged),'malformed_field_count':sum(x['malformed_flag_without_blob'] for x in fields),'methoddef_order_first_malformed_parameter':next((x for x in flagged if x['malformed_flag_without_blob']),None),'walk_order_note':'MethodDef order is metadata evidence; Reflection.GetMethods ordering is not guaranteed, so this is not asserted to be the exact crashing iteration. Nested owner names come from exact NestedClass rows.','game_code_loaded_or_executed':False,'project_modified':False}
def main():
 path=Path(sys.argv[1]);out=Path(sys.argv[2]);need(not out.exists(),'Fresh audit output required')
 with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:report=Cli(b).audit()
 with path.open('rb') as f:digest=hashlib.file_digest(f,'sha256').hexdigest()
 report['input']={'path':str(path),'sha256':digest};report['tool']={'path':str(Path(__file__).resolve()),'sha256':hashlib.sha256(Path(__file__).read_bytes()).hexdigest()};out.parent.mkdir(parents=True,exist_ok=True);out.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out),'malformed_parameters':report['malformed_parameter_count'],'malformed_fields':report['malformed_field_count'],'FieldMarshal_rows':len(report['FieldMarshal_rows']),'first':report['methoddef_order_first_malformed_parameter']}))
if __name__=='__main__':main()
