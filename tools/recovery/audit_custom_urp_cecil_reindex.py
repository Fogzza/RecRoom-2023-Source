"""Bounded pure PE/CLI comparison of frozen URP staging inputs and output.

Never loads a managed assembly, rewrites a DLL, or changes staging acceptance.
Token operands are compared using full assembly-scoped CLI identities.
"""
from pathlib import Path
import argparse, collections, datetime as dt, hashlib, json, struct, uuid
from audit_cli_marshal_contracts import Cli, need
from audit_hashable_scoped_vtable import Read

ROOT=Path(__file__).resolve().parents[3]
ORIGINAL=ROOT/'RR23/Assets/Plugins/Unity.RenderPipelines.Universal.Runtime.dll'
CANDIDATE=ROOT/'Recovery/RecRoom-2023-04-18/Validation/CustomUrpSevenBodyStageV2-20261023T093103Z-251472b4/Candidates/Unity.RenderPipelines.Universal.Runtime.dll'
PINS={str(ORIGINAL):'2fe363b1e8eeaae41e1970eff2ad60fcf80c89bbe69b39bac7989eecfc61fc14',str(CANDIDATE):'d0db75ffffaba7f7a7d50ace7b114f5494c77486b8a07aec6dbf799ba7e36f1e'}
SELECTED={0x0600006a,0x0600006b,0x0600006c,0x0600006f,0x06000136,0x06000203,0x0600029c}

def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def key(x):return json.dumps(x,sort_keys=True,separators=(',',':'))
def sig(x):return {k:v for k,v in x.items() if k!='blob'}

class Model:
 def __init__(self,path):
  self.path=path;self.b=path.read_bytes();need(len(self.b)<2*1024*1024,'Bounded CLI inputs');self.c=Cli(self.b);self.r=Read(self.c);self.names={};self.values={};self.method={};self.field={};self.param={};self.owner={}
  c=self.c;r=self.r
  for ti in range(1,c.rows[2]+1):
   at=c.row(2,ti);typ=r.definition(ti);self.names[(2,ti)]='['+r.asm+']'+typ
   self.values[(2,ti)]={'flags':c.u32(at),'name':typ,'base':self.tocoded(c.value(at+4+2*c.strw,c.coded(2,[2,1,27])))}
   fs=c.value(at+4+2*c.strw+c.coded(2,[2,1,27]),c.index(4));fe=c.value(c.row(2,ti+1)+4+2*c.strw+c.coded(2,[2,1,27]),c.index(4)) if ti<c.rows[2] else c.rows[4]+1
   for fi in range(fs,fe):
    fa=c.row(4,fi);blob=c.blob(c.value(fa+2+c.strw,c.blobw));need(blob[0]==6,'Field signature');ft,end=r.type(blob,1);need(end==len(blob),'Field suffix');f={'owner':self.names[(2,ti)],'name':c.string(c.value(fa+2,c.strw)),'type':ft};self.field[fi]=f;self.names[(4,fi)]=key(f);self.values[(4,fi)]={'flags':c.u16(fa),**f}
   for method in r.methods(ti):
    mi=int(method['token'],16)&0xffffff;ma=c.row(6,mi);m={'owner':self.names[(2,ti)],'name':method['name'],'signature':sig(method['signature'])};self.method[mi]=m;self.names[(6,mi)]=key(m);self.values[(6,mi)]={'flags':method['flags'],'impl_flags':method['impl_flags'],**m};self.owner[mi]=ti
    ps=c.value(ma+8+c.strw+c.blobw,c.index(8));pe=c.value(c.row(6,mi+1)+8+c.strw+c.blobw,c.index(8)) if mi<c.rows[6] else c.rows[8]+1
    for pi in range(ps,pe):
     pa=c.row(8,pi);sequence=c.u16(pa+2);p={'method':m,'sequence':sequence};self.names[(8,pi)]=key(p);self.values[(8,pi)]={'flags':c.u16(pa),'name':c.string(c.value(pa+4,c.strw)),**p};self.param[pi]=(mi,sequence)
  # Tables whose identities are scoped owner/name/signature (not row positions).
  for map_table,item_table,kind in [(21,23,'property'),(18,20,'event')]:
   for ri in range(1,c.rows[map_table]+1):
    at=c.row(map_table,ri);owner=c.value(at,c.index(2));start=c.value(at+c.index(2),c.index(item_table));end=c.value(c.row(map_table,ri+1)+c.index(2),c.index(item_table)) if ri<c.rows[map_table] else c.rows[item_table]+1
    for ii in range(start,end):
     ia=c.row(item_table,ii);name=c.string(c.value(ia+2,c.strw));ty=sig(r.signature(c.blob(c.value(ia+2+c.strw,c.blobw)))) if item_table==23 else r.codedtype(c.value(ia+2+c.strw,c.coded(2,[2,1,27])));v={'owner':self.names[(2,owner)],'name':name,kind+'_type':ty};self.names[(item_table,ii)]=key(v);self.values[(item_table,ii)]={'flags':c.u16(ia),**v}
  for ii in range(1,c.rows[42]+1):
   at=c.row(42,ii);coded=c.value(at+4,c.coded(1,[2,6]));v={'owner':self.token((6 if coded&1 else 2)<<24|(coded>>1)),'number':c.u16(at)};self.names[(42,ii)]=key(v);self.values[(42,ii)]={'flags':c.u16(at+2),'name':c.string(c.value(at+4+c.coded(1,[2,6]),c.strw)),**v}
 def tocoded(self,v):return self.r.codedtype(v) if v else None
 def token(self,v):
  t,ri=v>>24,v&0xffffff;c=self.c;r=self.r
  if (t,ri) in self.names:return self.names[t,ri]
  need(ri>0,'Non-null operand token')
  if t==1:return r.typeref(ri)
  if t==27:
   blob=c.blob(c.value(c.row(t,ri),c.blobw));v,end=r.type(blob,0);need(end==len(blob),'TypeSpec suffix');return v
  if t==10:
   at=c.row(t,ri);w=c.coded(3,[2,1,26,6,27]);coded=c.value(at,w);tag,owner=coded&7,coded>>3;need(tag<5,'MemberRef owner tag');table=[2,1,26,6,27][tag];own=c.string(c.value(c.row(26,owner),c.strw)) if table==26 else self.token(table<<24|owner);blob=c.blob(c.value(at+w+c.strw,c.blobw));name=c.string(c.value(at+w,c.strw))
   if blob[0]==6:v,end=r.type(blob,1);need(end==len(blob),'MemberRef field suffix');return key({'owner':own,'name':name,'field_type':v})
   return key({'owner':own,'name':name,'signature':sig(r.signature(blob))})
  if t==17:
   blob=c.blob(c.value(c.row(17,ri),c.blobw))
   if blob[0]!=7:return key(sig(r.signature(blob)))
   count,at=r.comp(blob,1);items=[]
   for _ in range(count):v,at=r.type(blob,at);items.append(v)
   need(at==len(blob),'Local signature suffix');return key({'locals':items})
  if t==43:
   at=c.row(t,ri);w=c.coded(1,[6,10]);coded=c.value(at,w);blob=c.blob(c.value(at+w,c.blobw));need(blob[0]==10,'MethodSpec signature');count,at=r.comp(blob,1);args=[]
   for _ in range(count):v,at=r.type(blob,at);args.append(v)
   need(at==len(blob),'MethodSpec suffix');return key({'method':self.token((10 if coded&1 else 6)<<24|(coded>>1)),'arguments':args})
  if t==0x70:
   base,size=c.streams['#US'];need(ri<size,'User string index');length,at=r.comp(self.b,base+ri);need(at+length<=base+size and length>=1,'User string length');return {'user_string_bytes':self.b[at:at+length].hex()}
  raise ValueError('Unsupported metadata token '+hex(v))
 def associations(self):
  c=self.c;rows={}
  def add(name,value):rows.setdefault(name,[]).append(value)
  for t in [2,4,6,8,20,23,42]:
   for ri in range(1,c.rows[t]+1):add('definition_'+str(t),self.values[t,ri])
  for ri in range(1,c.rows[11]+1):
   at=c.row(11,ri);w=c.coded(2,[4,8,23]);v=c.value(at+2,w);owner=self.token([4,8,23][v&3]<<24|(v>>2));add('Constant',{'owner':owner,'type':c.u16(at),'blob':c.blob(c.value(at+2+w,c.blobw)).hex()})
  cat=[6,4,1,2,8,9,10,0,14,23,20,17,26,27,32,35,38,39,40,42,44,43]
  for ri in range(1,c.rows[12]+1):
   at=c.row(12,ri);w=c.coded(5,cat);v=c.value(at,w);ct=c.value(at+w,c.coded(3,[6,10]));parent_table,parent_rid=cat[v&31],v>>5
   if parent_table in (0,32):owner={'table':parent_table,'rid':parent_rid}
   elif parent_table==35:owner={'assembly_ref':self.r.m.identity(c,35,parent_rid)['full_name']} # unused in current inputs
   else:owner=self.token(parent_table<<24|parent_rid)
   need(ct&7 in (2,3),'CustomAttribute constructor tag');add('CustomAttribute',{'owner':owner,'constructor':self.token((6 if ct&7==2 else 10)<<24|(ct>>3)),'blob':c.blob(c.value(at+w+c.coded(3,[6,10]),c.blobw)).hex()})
  for ri in range(1,c.rows[9]+1):
   at=c.row(9,ri);add('InterfaceImpl',{'owner':self.token(2<<24|c.value(at,c.index(2))),'interface':self.tocoded(c.value(at+c.index(2),c.coded(2,[2,1,27])))})
  for ri in range(1,c.rows[15]+1):
   at=c.row(15,ri);add('ClassLayout',{'owner':self.token(2<<24|c.value(at+6,c.index(2))),'packing_size':c.u16(at),'class_size':c.u32(at+2)})
  for ri in range(1,c.rows[24]+1):
   at=c.row(24,ri);v=c.value(at+2+c.index(6),c.coded(1,[20,23]));add('MethodSemantics',{'flags':c.u16(at),'method':self.token(6<<24|c.value(at+2,c.index(6))),'association':self.token((23 if v&1 else 20)<<24|(v>>1))})
  for ri in range(1,c.rows[25]+1):
   at=c.row(25,ri);w=c.coded(1,[6,10]);a=c.value(at+c.index(2),w);b=c.value(at+c.index(2)+w,w);add('MethodImpl',{'owner':self.token(2<<24|c.value(at,c.index(2))),'body':self.token((10 if a&1 else 6)<<24|(a>>1)),'declaration':self.token((10 if b&1 else 6)<<24|(b>>1))})
  for ri in range(1,c.rows[41]+1):
   at=c.row(41,ri);add('NestedClass',{'nested':self.token(2<<24|c.value(at,c.index(2))),'owner':self.token(2<<24|c.value(at+c.index(2),c.index(2)))})
  for ri in range(1,c.rows[44]+1):
   at=c.row(44,ri);add('GenericParamConstraint',{'owner':self.token(42<<24|c.value(at,c.index(42))),'constraint':self.tocoded(c.value(at+c.index(42),c.coded(2,[2,1,27])))})
  return rows

def differences(a,b):
 ca=collections.Counter(map(key,a));cb=collections.Counter(map(key,b));return {'removed':[json.loads(v) for v in (ca-cb).elements()],'added':[json.loads(v) for v in (cb-ca).elements()]}

def compare():
 for p,h in PINS.items():need(sha(Path(p))==h,'Frozen input SHA: '+p)
 a=Model(ORIGINAL);b=Model(CANDIDATE);maps={}
 for t in [2,4,6,8,20,23,42]:
  aa={v:ri for (tt,ri),v in a.names.items() if tt==t};bb={v:ri for (tt,ri),v in b.names.items() if tt==t};need(len(aa)==a.c.rows[t] and len(bb)==b.c.rows[t],'Unique full definition identities');common=aa.keys()&bb.keys();maps[str(t)]={'original_count':len(aa),'emitted_count':len(bb),'removed':[{'identity':json.loads(v) if v[0]=='{' else v,'original_token':hex(t<<24|aa[v]),'original_value':a.values[t,aa[v]]} for v in sorted(aa.keys()-bb.keys())],'added':[{'identity':v,'emitted_token':hex(t<<24|bb[v])} for v in sorted(bb.keys()-aa.keys())],'moved':sum(aa[v]!=bb[v] for v in common),'bijection':[{'identity':json.loads(v) if v[0]=='{' else v,'original_token':hex(t<<24|aa[v]),'emitted_token':hex(t<<24|bb[v])} for v in sorted(common)]}
 aa=a.associations();bb=b.associations();assoc={k:differences(aa.get(k,[]),bb.get(k,[])) for k in sorted(aa.keys()|bb.keys())}
 reference_tables={}
 for t in [1,10,17,27,43]:reference_tables[str(t)]={'original_count':a.c.rows[t],'emitted_count':b.c.rows[t],**differences([a.token(t<<24|i) for i in range(1,a.c.rows[t]+1)],[b.token(t<<24|i) for i in range(1,b.c.rows[t]+1)])}
 return {'schema':'frozen-custom-URP-raw-CLI-finite-reindex-diagnosis/v1','status':'data_only_no_acceptance_gate_changed','inputs':[{'path':str(p),'bytes':p.stat().st_size,'sha256':h} for p,h in [(ORIGINAL,PINS[str(ORIGINAL)]),(CANDIDATE,PINS[str(CANDIDATE)])]],'table_counts':{str(t):{'original':a.c.rows[t],'emitted':b.c.rows[t]} for t in range(45) if a.c.rows[t] or b.c.rows[t]},'definition_maps':maps,'scoped_metadata_deltas':assoc,'reference_table_deltas':reference_tables,'managed_code_loaded':False,'Main_modified':False,'stage_acceptance_changed':False}

def main():
 parser=argparse.ArgumentParser();parser.add_argument('--out',type=Path);args=parser.parse_args();out=args.out or ROOT/'Recovery/RecRoom-2023-04-18/Validation'/('CustomUrpFiniteReindexDiagnosis-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);need(not out.exists(),'Fresh diagnostic directory');report=compare();out.mkdir(parents=True);report['tool']={'path':str(Path(__file__).resolve()),'sha256':sha(Path(__file__))};p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'definitions':{k:{x:v[x] for x in ['original_count','emitted_count','moved','removed','added']} for k,v in report['definition_maps'].items()},'metadata_delta_counts':{k:{x:len(v[x]) for x in ['removed','added']} for k,v in report['scoped_metadata_deltas'].items()},'reference_table_deltas':report['reference_table_deltas']}))

if __name__=='__main__':main()
