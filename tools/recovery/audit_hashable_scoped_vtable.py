"""Pure PE/CLI scoped signatures for failing hashable vtables. No managed assembly load."""
from pathlib import Path
import datetime as dt,hashlib,importlib.util,json,mmap,uuid
HERE=Path(__file__).resolve().parent
sp=importlib.util.spec_from_file_location('aot',HERE/'audit_finite_aot_system_core.py');m=importlib.util.module_from_spec(sp);sp.loader.exec_module(m)
PLAN=m.ROOT/'Validation/Mono64CoreSignatureAOT-20261022T154205Z-cb91a4de/plan.json'
NAMES={'HashableScriptableObject','GiftPackageVariantMap','PlayerBackpackToolConfig','JMIIPNGAANF','GiftPackageVariant','RuntimeSpawnableToolConfig','RecRoom.ToolSet','IHashable'}
PRIM={1:'void',2:'bool',3:'char',4:'sbyte',5:'byte',6:'int16',7:'uint16',8:'int32',9:'uint32',10:'int64',11:'uint64',12:'float',13:'double',14:'string',24:'IntPtr',25:'UIntPtr',28:'object',22:'TypedReference'}
class Read:
 def __init__(self,c):
  self.c=c;self.asm=m.identity(c,32,1)['full_name'];self.defs={};self.parents={}
  for rid in range(1,c.rows[41]+1):
   at=c.row(41,rid);self.parents[c.value(at,c.index(2))]=c.value(at+c.index(2),c.index(2))
 def comp(self,data,at):
  v=data[at]
  if v<128:return v,at+1
  if v&192==128:return ((v&63)<<8)|data[at+1],at+2
  m.need(v&224==192,'Compressed data');return ((v&31)<<24)|(data[at+1]<<16)|(data[at+2]<<8)|data[at+3],at+4
 def definition(self,rid):
  if rid in self.defs:return self.defs[rid]
  c=self.c;at=c.row(2,rid);n=c.string(c.value(at+4,c.strw));ns=c.string(c.value(at+4+c.strw,c.strw));n=self.definition(self.parents[rid])+'/'+n if rid in self.parents else (ns+'.' if ns else '')+n;self.defs[rid]=n;return n
 def typeref(self,rid):
  c=self.c;at=c.row(1,rid);width=c.coded(2,[0,26,35,1]);scope=c.value(at,width);n=c.string(c.value(at+width,c.strw));ns=c.string(c.value(at+width+c.strw,c.strw));tag,owner=scope&3,scope>>2
  if tag==3:return self.typeref(owner)+'/'+n
  ident=m.identity(c,35,owner)['full_name'] if tag==2 else self.asm
  return '['+ident+']'+(ns+'.' if ns else '')+n
 def codedtype(self,v):
  tag,rid=v&3,v>>2
  if tag==0:return '['+self.asm+']'+self.definition(rid)
  if tag==1:return self.typeref(rid)
  m.need(tag==2,'TypeDefOrRef tag');at=self.c.row(27,rid);b=self.c.blob(self.c.value(at,self.c.blobw));s,end=self.type(b,0);m.need(end==len(b),'TypeSpec suffix');return s
 def type(self,b,at):
  k=b[at];at+=1
  if k in PRIM:return PRIM[k],at
  if k in (15,16,29,69):
   s,at=self.type(b,at);return {15:'ptr(',16:'ref(',29:'szarray(',69:'pinned('}[k]+s+')',at
  if k in (17,18):v,at=self.comp(b,at);return ('valuetype ' if k==17 else 'class ')+self.codedtype(v),at
  if k in (19,30):v,at=self.comp(b,at);return ('!' if k==19 else '!!')+str(v),at
  if k in (31,32):v,at=self.comp(b,at);s,at=self.type(b,at);return ('modreq(' if k==31 else 'modopt(')+self.codedtype(v)+','+s+')',at
  if k==21:
   owner,at=self.type(b,at);count,at=self.comp(b,at);args=[]
   for _ in range(count):s,at=self.type(b,at);args.append(s)
   return owner+'<'+','.join(args)+'>',at
  if k==20:
   elem,at=self.type(b,at);rank,at=self.comp(b,at);count,at=self.comp(b,at);sizes=[]
   for _ in range(count):v,at=self.comp(b,at);sizes.append(v)
   count,at=self.comp(b,at);bounds=[]
   for _ in range(count):v,at=self.comp(b,at);bounds.append(v)
   return 'array('+elem+','+str(rank)+','+str(sizes)+','+str(bounds)+')',at
  raise ValueError('Unsupported signature kind '+str(k))
 def signature(self,b):
  at=1;cc=b[0];arity=0
  if cc&16:arity,at=self.comp(b,at)
  count,at=self.comp(b,at);ret,at=self.type(b,at);params=[]
  for _ in range(count):s,at=self.type(b,at);params.append(s)
  m.need(at==len(b),'Method signature suffix');return {'callconv':cc,'arity':arity,'return':ret,'parameters':params,'blob':b.hex()}
 def methods(self,rid):
  c=self.c;offset=4+2*c.strw+c.coded(2,[2,1,27])+c.index(4);start=c.value(c.row(2,rid)+offset,c.index(6));end=c.value(c.row(2,rid+1)+offset,c.index(6)) if rid<c.rows[2] else c.rows[6]+1;rows=[]
  for mi in range(start,end):
   at=c.row(6,mi);name=c.string(c.value(at+8,c.strw));sig=c.blob(c.value(at+8+c.strw,c.blobw));flags=c.u16(at+6)
   rows.append({'token':hex(0x06000000|mi),'name':name,'flags':flags,'impl_flags':c.u16(at+4),'virtual':bool(flags&64),'new_slot':bool(flags&256),'abstract':bool(flags&1024),'signature':self.signature(sig)})
  return rows
def main():
 p=json.loads(PLAN.read_text());results=[]
 for row in p['references']:
  path=Path(row['path'])
  with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
   c=m.cli.Cli(b);r=Read(c)
   for rid in range(1,c.rows[2]+1):
    name=r.definition(rid)
    if name not in NAMES and not name.startswith('PlayerBackpackToolConfig/') and not name.startswith('GiftPackageVariant/'):continue
    at=c.row(2,rid);base=c.value(at+4+2*c.strw,c.coded(2,[2,1,27]));results.append({'module':row,'type':name,'type_token':hex(0x02000000|rid),'flags':c.u32(at),'base':r.codedtype(base) if base else None,'methods':r.methods(rid)})
 out=m.ROOT/'Validation'/('HashableScopedVTable-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'pure-CLI-scoped-hashable-vtable-contract-audit/v1','status':'metadata_evidence_only','input_plan':{'path':str(PLAN),'sha256':m.sha(PLAN)},'types':results,'code_invoked':False,'project_changed':False};rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':m.sha(rp),'types':len(results)}))
if __name__=='__main__':main()
