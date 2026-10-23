"""Exact actual-CLI signatures/flags -> proven original native marshal owners."""
import collections,hashlib,json,mmap,sys
from pathlib import Path
from audit_cli_marshal_contracts import Cli,need
class Signatures:
 def __init__(self,cli):
  self.v=cli;self.names={};self.parents={}
  for rid in range(1,cli.rows[41]+1):
   at=cli.row(41,rid);self.parents[cli.value(at,cli.index(2))]=cli.value(at+cli.index(2),cli.index(2))
 def integer(self,b,at):
  need(at<len(b),'Signature truncated');x=b[at]
  if x<128:return x,at+1
  if x&0xc0==0x80:need(at+2<=len(b),'Compressed UInt bounds');return ((x&0x3f)<<8)|b[at+1],at+2
  if x&0xe0==0xc0:need(at+4<=len(b),'Compressed UInt bounds');return ((x&31)<<24)|(b[at+1]<<16)|(b[at+2]<<8)|b[at+3],at+4
  raise ValueError('Invalid signature compressed UInt')
 def named(self,table,rid,seen=None):
  key=(table,rid)
  if key in self.names:return self.names[key]
  seen=set() if seen is None else seen;need(key not in seen,'Cyclic signature owner');seen.add(key);v=self.v;at=v.row(table,rid)
  if table==2:
   name=v.string(v.value(at+4,v.strw));ns=v.string(v.value(at+4+v.strw,v.strw));name=self.named(2,self.parents[rid],seen)+'/'+name if rid in self.parents else (ns+'.' if ns else '')+name
  elif table==1:
   width=v.coded(2,[0,26,35,1]);scope=v.value(at,width);name=v.string(v.value(at+width,v.strw));ns=v.string(v.value(at+width+v.strw,v.strw));name=self.named(1,scope>>2,seen)+'/'+name if scope&3==3 else (ns+'.' if ns else '')+name
  elif table==27:
   blob=v.blob(v.value(at,v.blobw));name,end=self.type(blob,0);need(end==len(blob),'TypeSpec trailing bytes')
  else:raise ValueError('Unsupported TypeDefOrRef tag')
  self.names[key]=name;return name
 def type(self,b,at):
  need(at<len(b),'Truncated TypeSpec');kind=b[at];at+=1;primitive={1:'Void',2:'Boolean',3:'Char',4:'SByte',5:'Byte',6:'Int16',7:'UInt16',8:'Int32',9:'UInt32',10:'Int64',11:'UInt64',12:'Single',13:'Double',14:'String',24:'IntPtr',25:'UIntPtr',28:'Object'}
  if kind in primitive:return 'System.'+primitive[kind],at
  if kind in (15,16,29):
   name,at=self.type(b,at);return name+{15:'*',16:'&',29:'[]'}[kind],at
  if kind in (17,18):
   code,at=self.integer(b,at);need(code&3 in (0,1,2),'Reserved TypeDefOrRef tag');return self.named({0:2,1:1,2:27}[code&3],code>>2),at
  if kind==21:
   name,at=self.type(b,at);count,at=self.integer(b,at);args=[]
   for _ in range(count):arg,at=self.type(b,at);args.append(arg)
   return name+'<'+','.join(args)+'>',at
  raise ValueError('Unsupported signature TypeSpec kind '+hex(kind))
 def method(self,hexdata):
  b=bytes.fromhex(hexdata);at=1;need(b and b[0]&15 in (0,1,2,3,4,5),'Supported call convention required');arity=0
  if b[0]&16:arity,at=self.integer(b,at)
  count,at=self.integer(b,at);ret,at=self.type(b,at);params=[]
  for _ in range(count):name,at=self.type(b,at);params.append(name)
  need(at==len(b),'Method signature trailing data');return {'return':ret,'parameters':params,'generic_arity':arity,'has_this':bool(b[0]&32),'call_convention':b[0]&15}
 def field(self,rid):
  v=self.v;at=v.row(4,rid);b=v.blob(v.value(at+2+v.strw,v.blobw));need(b and b[0]==6,'Field signature required');name,end=self.type(b,1);need(end==len(b),'Field signature trailing data');return name
def sha(p):
 with p.open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def main():
 folder=Path(sys.argv[1]);root=folder.parents[1];actual=json.loads((folder/'report-v3.json').read_bytes());source=Path(actual['input']['path']);need(sha(source)==actual['input']['sha256'],'Actual Unity core changed');nativepath=root/'Validation/NativeSteamworks14-20261022T140334Z-834003d4/report.json';native=json.loads(nativepath.read_bytes());ledgerpath=root/'Validation/AllPInvokeBindings-20261022T123600Z/ReviewedEvidencePackage/binding-ledger.json';ledger=json.loads(ledgerpath.read_bytes());binding={}
 for b in ledger['bindings']:binding.setdefault((b['declaring_type'],b['method_name']),[]).append(b)
 fields={(f['owner'],f['field_name']):f for f in native['marshal_fields']};params=[];joinedfields=[];errors=[]
 with source.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as data:
  cli=Cli(data);sigs=Signatures(cli)
  for row in actual['flagged_parameters']:
   m=row['method'];key=(m['owner']['display_owner'],m['name'])
   try:
    shape=sigs.method(m['signature_hex']);candidates=[b for b in binding.get(key,[]) if b['return_type']==shape['return'] and [p['type'] for p in b['parameters']]==shape['parameters'] and not shape['generic_arity'] and shape['has_this']==(not bool(b['original_MethodAttributes']&16))];need(len(candidates)==1,'Unique full original native PInvoke contract required');b=candidates[0];need(m['flags']==b['original_MethodAttributes'] and m['impl_flags']==b['original_MethodImplAttributes'],'Native method flags differ');need(row['sequence']>0,'No return owner guessed');p=b['parameters'][row['sequence']-1];need(row['flags']==p['native_Il2CppType_attribute_bits'] and row['parameter_name']==p['name'],'Native exact parameter flags/name differ')
    params.append({'actual':row,'actual_full_signature':shape,'original_method_token':b['original_native_MethodDef_token'],'original_parameter_token':p['original_ParameterDef_token'],'native_parameter':p,'effective_import':b['effective_import'],'full_signature_and_flags_exact':True})
   except ValueError as error:errors.append({'kind':'parameter','row':row,'error':str(error)})
  for row in actual['flagged_fields']:
   key=(row['owner']['display_owner'],row['name'])
   try:
    need(key in fields,'Exact original native field owner missing');n=fields[key];shape=sigs.field(int(row['current_field_token'],16)&0xffffff);need(shape==n['type'] and row['flags']==n['flags'],'Native field signature/flags differ');joinedfields.append({'actual':row,'actual_field_type':shape,'original_native':n,'full_signature_and_flags_exact':True})
   except ValueError as error:errors.append({'kind':'field','row':row,'error':str(error)})
 report={'schema':'actual-Unity-CLI-to-original-native-marshal-contract-join/v1','inputs':[{'path':str(p),'sha256':sha(p)} for p in (folder/'report-v3.json',source,nativepath,ledgerpath)],'exact_parameter_joins':params,'exact_field_joins':joinedfields,'unresolved':errors,'parameter_count':len(params),'field_count':len(joinedfields),'descriptor_blobs_recovered_by_this_join':False,'preserved_original_flag_proof_only':True,'game_code_loaded_or_executed':False,'project_modified':False};target=folder/'native-contract-join.json';need(not target.exists(),'Fresh join required');target.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(target),'parameters':len(params),'fields':len(joinedfields),'unresolved':len(errors),'examples':errors[:2]}))
if __name__=='__main__':main()
