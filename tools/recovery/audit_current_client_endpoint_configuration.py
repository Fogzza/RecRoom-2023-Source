"""Read-only current endpoint evidence; never contacts services or logs configuration values."""
from pathlib import Path
import collections,datetime,hashlib,importlib.util,json,mmap,re,uuid
from urllib.parse import urlsplit
HERE=Path(__file__).resolve().parent
WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';PROJECT=WS/'RR23'
sp=importlib.util.spec_from_file_location('render',HERE/'audit_original_rendering_sdk_candidates.py');a=importlib.util.module_from_spec(sp);sp.loader.exec_module(a);h=a.h
TARGETS=['ns.nerlz.dev','nerlz.dev','ns.nerlz.com','oldns.nerlz.com']
def pin(p):return {'path':str(p),'sha256':a.sha(p)}
def us(c,r):
 if '#US' not in c.streams:return []
 base,size=c.streams['#US'];at=1;values=[]
 while at<size:
  if c.b[base+at]==0:at+=1;continue
  length,start=r.comp(c.b,base+at);end=start+length;a.need(end<=base+size and length>=1,'#US range');values.append(bytes(c.b[start:end-1]).decode('utf-16le'));at=end-base
 return values
class Scan:
 def __init__(self):self.checked=0;self.bytes=0;self.hits=[];self.skipped=collections.Counter()
 def file(self,p):
  if not p.is_file() or p.suffix.lower() not in {'.cs','.asset','.json','.txt','.bytes','.config'}:return
  size=p.stat().st_size
  if size>16*1024*1024:self.skipped['over_16MiB']+=1;return
  raw=p.read_bytes();self.checked+=1;self.bytes+=len(raw);lower=raw.lower()
  matches={target:lower.count(target.encode()) for target in TARGETS if target.encode() in lower}
  if matches:self.hits.append({'file':pin(p),'target_literal_occurrences':matches})
def main():
 scan=Scan()
 folders=[PROJECT/'Assets/Scripts',PROJECT/'Assets/Resources',PROJECT/'Assets/MonoBehaviour',PROJECT/'Assets/StreamingAssets',PROJECT/'ProjectSettings']
 for folder in folders:
  for p in folder.rglob('*'):scan.file(p)
 selected={'NDFLHBFOIGB':{'.cctor','OHFNGFDHOEG','KBKOIKCIEKB'},'PAJFMLEBPDP':{'IEIJPOCDEAH','NAFCNPEDAFM'}}
 dlls=[];critical=[];response_fields=[];target_DLL_hits=[]
 for p in sorted((PROJECT/'Assets/Plugins').glob('*.dll')):
  with p.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as data:
   c=h.m.cli.Cli(data);r=h.Read(c);values=us(c,r);constant_string_count=0;constant_hits=collections.Counter()
   for rid in range(1,c.rows[11]+1):
    at=c.row(11,rid)
    if c.u16(at)!=14:continue
    text=c.blob(c.value(at+2+c.coded(2,[4,8,23]),c.blobw)).decode('utf-16le');constant_string_count+=1
    for target in TARGETS:constant_hits[target]+=int(target in text.lower())
   counts={target:sum(target in text.lower() for text in values)+constant_hits[target] for target in TARGETS}
   if any(counts.values()):target_DLL_hits.append({'file':pin(p),'target_literals':counts})
   if p.name=='RecNet.Runtime.dll':
    for rid in range(1,c.rows[2]+1):
     owner=r.definition(rid)
     if owner=='NDFLHBFOIGB/NameServerResponse':
      off=4+2*c.strw+c.coded(2,[2,1,27]);start=c.value(c.row(2,rid)+off,c.index(4));end=c.value(c.row(2,rid+1)+off,c.index(4))
      for fi in range(start,end):
       at=c.row(4,fi);response_fields.append(c.string(c.value(at+2,c.strw)))
     if owner not in selected:continue
     for method in r.methods(rid):
      if method['name'] in selected[owner]:critical.append({'DLL':pin(p),'owner':owner,'current_method':method,'body':a.body(c,method['token'])})
   dlls.append({'file':pin(p),'assembly_full_identity':r.asm,'user_string_heap_bytes':c.streams.get('#US',(0,0))[1],'user_strings':len(values),'constant_string_rows':constant_string_count,'requested_endpoint_literal_occurrences':counts['ns.nerlz.dev']})
 native=ROOT/'Validation/AllOriginalScripts-20261022T145115Z-25a68695/RecNet.Runtime.dll.methods.jsonl'
 native_rows=[m for m in a.rows(native) if m['owner']=='NDFLHBFOIGB' and m['name'] in {'.cctor','OHFNGFDHOEG','KBKOIKCIEKB'}]
 out=ROOT/'Validation'/('CurrentClientEndpointAudit-'+datetime.datetime.now(datetime.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 report={'schema':'current-client-endpoint-static-configuration-audit/v1','status':'requested_endpoint_not_installed_router_bodies_unrecovered','requested_endpoint':'https://ns.nerlz.dev','checked_text_scope':[str(x) for x in folders],'checked_text_files':scan.checked,'checked_text_bytes':scan.bytes,'skipped_text_files':dict(scan.skipped),'matching_target_domain_text_files':scan.hits,'managed_plugin_count':len(dlls),'managed_plugins':dlls,'matching_target_domain_managed_files':target_DLL_hits,'live_endpoint_router_methods':critical,'original_native_method_inventory':pin(native),'original_native_endpoint_router_metadata':native_rows,'nameserver_response_field_names_only':response_fields,'current_core_sources':[pin(PROJECT/'Assets/Scripts/Assembly-CSharp'/name) for name in ['IDDIAODMAPP.cs','RecRoomGameRoot.cs']],'conclusions':['The requested ns.nerlz.dev URL is absent from the checked current Main source/config and all225 managed-plugin user-string/constant heaps; no endpoint redirect installation is evidenced.','Current RecNet.Runtime NDFLHBFOIGB.OHFNGFDHOEG returnsnull, its staticinitializer returnsimmediately, and KBKOIKCIEKB clears its Uri output andreturnsfalse. These are not recovered endpoint-selection behavior.','Therefore this inventory does not claim an active requested server or an active original server selection. It identifies an unrecovered network-routing/configuration gate.','NameServerResponse fields express expected service categories only; field names are not installed URL values.','No original native-proven functioning endpoint getter has been installed by this audit. Restoring original logic and applying the user-requested endpoint override must be a separately reviewed change preserving auth/session behavior.','The active Windows build was not read or modified; its result and runtime network behavior remain to be tested. OS/user PlayerPrefs, environment overrides and remote services were not accessed.'],'network_requests':0,'credentials_or_tokens_logged':False,'Main_modified':False,'managed_Unity_game_or_native_code_invoked':False,'tool':pin(Path(__file__))}
 path=out/'report.json';path.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(path),'sha256':a.sha(path),'text_files':scan.checked,'managed_plugins':len(dlls),'requested_domain_text_hits':len(scan.hits),'requested_domain_managed_hits':len(target_DLL_hits),'status':report['status']}))
if __name__=='__main__':main()
