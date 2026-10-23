"""Temporary nameserver target evidence and original native method availability; data-only."""
import datetime,hashlib,json,mmap,struct,uuid
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
INDEX=ROOT/'Preflight/public-archive-inventory.json'
def need(v,s):
 if not v:raise ValueError(s)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def pin(p):return {'path':str(p),'sha256':sha(p)}
def main():
 target=WS/'Rebuild/backend-target.json';oldcheck=WS/'Rebuild/backend-verification.json';snapshot=WS/'Rebuild/CloudflareMigration/20261022T033530Z/source-metadata.json'
 config=json.loads(target.read_bytes());captured=json.loads(snapshot.read_bytes());verified=json.loads(oldcheck.read_bytes());domain=[r for r in captured['custom_domains'] if r.get('hostname')=='ns.nerlz.com'];need(len(domain)==1 and domain[0]['service']=='ns','Exact nameserver Worker customdomain witness')
 need(config['client']['nameServerUrl']=='https://ns.nerlz.com' and config['cloudflare']['nameServer']['url']=='https://ns.nerlz.com','Local existing target witnesses disagree')
 inventory=ROOT/'Validation/AllOriginalScripts-20261022T145115Z-25a68695/RecNet.Runtime.dll.methods.jsonl'
 selected=[]
 with inventory.open() as f:
  for line in f:
   r=json.loads(line)
   if r['owner']=='NDFLHBFOIGB' and r['name'] in ['OHFNGFDHOEG','.cctor','KBKOIKCIEKB']:selected.append(r)
 need(len(selected)==3,'Exact native router method metadata')
 source=ROOT/'VerifiedSource';paths=[source/'GameAssembly.dll',source/'RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat'];before=[(p.stat().st_size,p.stat().st_mtime_ns) for p in paths]
 names=('stringLiteral stringLiteralData string events properties methods parameterDefaultValues fieldDefaultValues fieldAndParameterDefaultValueData fieldMarshaledSizes parameters fields genericParameters genericParameterConstraints genericContainers nestedTypes interfaces vtableMethods interfaceOffsets typeDefinitions images assemblies fieldRefs referencedAssemblies attributesInfo attributeTypes unresolvedVirtualCallParameterTypes unresolvedVirtualCallParameterRanges windowsRuntimeTypeNames windowsRuntimeStrings exportedTypeDefinitions').split()
 with paths[0].open('rb') as bf,paths[1].open('rb') as mf,mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b,mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as m:
  u16=lambda d,a:struct.unpack_from('<H',d,a)[0];u32=lambda d,a:struct.unpack_from('<I',d,a)[0];u64=lambda d,a:struct.unpack_from('<Q',d,a)[0]
  need(b[:2]==b'MZ' and u32(m,0)==0xFAB11BAF and u32(m,4)==27,'Exact original binary formats');pe=u32(b,60);opt=pe+24;need(u16(b,pe+4)==0x8664 and u16(b,opt)==0x20b,'AMD64 PE32+');image=u64(b,opt+24);sections=[]
  for i in range(u16(b,pe+6)):
   at=opt+u16(b,pe+20)+i*40;vs,rva,size,off=struct.unpack_from('<IIII',b,at+8);need(off+size<=len(b),'Section bounds');sections.append((rva,size,off,u32(b,at+36)))
  def raw(va,width):
   matches=[off+va-image-rva for rva,size,off,_ in sections if rva<=va-image and va-image+width<=rva+size];need(len(matches)==1,'Unique backed VA');return matches[0]
  def string(va):
   at=raw(va,1);end=b.find(b'\0',at,min(at+512,len(b)));need(end>=at,'Native module string bound');return bytes(b[at:end]).decode()
  tables={n:struct.unpack_from('<ii',m,8+i*8) for i,n in enumerate(names)}
  for off,size in tables.values():need(off>=0 and size>=0 and off+size<=len(m),'Metadata table bounds')
  cr=raw(0x187F10DD0,120);count=u64(b,cr+104);need(count==tables['images'][1]//40==279,'Native registration modules/image count');mods=raw(u64(b,cr+112),count*8);found=[]
  for i in range(count):
   va=u64(b,mods+i*8);at=raw(va,40)
   if string(u64(b,at))=='RecNet.Runtime.dll':found.append((va,at))
  need(len(found)==1,'Unique RecNet native module');moduleva,module=found[0];methodcount=u64(b,module+8);pointers=raw(u64(b,module+16),methodcount*8)
  dd=opt+112;unwind_rva,unwind_bytes=struct.unpack_from('<II',b,dd+3*8);need(unwind_bytes%12==0,'Runtime function table');unwind=raw(image+unwind_rva,unwind_bytes)
  native=[]
  for row in selected:
   mi=row['native_method_index'];at=tables['methods'][0]+mi*32;need(at+32<=tables['methods'][0]+tables['methods'][1],'Native MethodDef bound');token=int(row['original_method_token'],16);need(u32(m,at+20)==token and u32(m,at+4)==row['native_type_index'],'Exact original metadata token/owner join');rid=token&0xffffff;need(1<=rid<=methodcount,'Original native method RID bound');va=u64(b,pointers+(rid-1)*8);rva=va-image
   need(any(base<=rva<base+size and flags&0x20000000 for base,size,_,flags in sections),'Executable original pointer')
   low,high=0,unwind_bytes//12
   while low<high:
    mid=(low+high)//2;begin=u32(b,unwind+mid*12)
    if begin<rva:low=mid+1
    else:high=mid
   need(low<unwind_bytes//12 and u32(b,unwind+low*12)==rva,'Exact .pdata function start');begin,end,info=struct.unpack_from('<III',b,unwind+low*12);need(0<end-begin<=65536,'Bounded exact function body');code=bytes(b[raw(va,end-begin):raw(va,end-begin)+end-begin])
   native.append({'owner':row['owner'],'name':row['name'],'original_method_token':row['original_method_token'],'native_method_index':mi,'original_type_token':row['original_type_token'],'module_VA':hex(moduleva),'module_method_pointer_count':methodcount,'pointer_VA':hex(va),'RVA':hex(rva),'pdata_begin_RVA':hex(begin),'pdata_end_RVA':hex(end),'native_body_bytes':len(code),'native_body_sha256':hashlib.sha256(code).hexdigest(),'first_32_native_bytes':code[:32].hex(),'native_logic_or_URL_literal_assignment_recovered':False})
 need(before==[(p.stat().st_size,p.stat().st_mtime_ns) for p in paths],'Original native sources changed')
 index=json.loads(INDEX.read_bytes());expected={r[0]:(r[1],r[2]) for r in index['files']};source_lineage=[{'path':str(p),'original_public_archive_size':expected[p.relative_to(source).as_posix()][0],'original_public_archive_sha256':expected[p.relative_to(source).as_posix()][1],'stat_size':before[i][0],'stat_unchanged':True,'whole_file_rehashed_in_this_small_probe':False} for i,p in enumerate(paths)]
 out=ROOT/'Validation'/('TemporaryExistingNameserverPlan-'+datetime.datetime.now(datetime.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 report={'schema':'existing-nameserver-temporary-client-target-read-only-plan/v1','status':'exact_existing_target_identified_not_applied','planned_temporary_nameserver_origin':'https://ns.nerlz.com','pending_destination_nameserver_origin':'https://ns.nerlz.dev','local_target_witness':pin(target),'local_historical_verification_witness':pin(oldcheck),'historical_http_status_only':verified.get('http_status'),'historical_game_login_tested':verified.get('game_login_tested'),'captured_live_metadata':pin(snapshot),'captured_live_metadata_utc':captured['created_utc'],'exact_customdomain_witness':{k:domain[0].get(k) for k in ['hostname','service','environment','zone_name']},'prior_client_endpoint_audit':pin(ROOT/'Validation/CurrentClientEndpointAudit-20261022T192226Z-099bc5ef/report.json'),'native_metadata_inventory':pin(inventory),'original_archive_index':pin(INDEX),'original_native_source_lineage':source_lineage,'native_router_bodies_available_for_future_recovery':native,'plan':['Keep existing backend/services unchanged. Usehttps://ns.nerlz.com as the temporary nameserver only when a reviewed client-routing repair is prepared.','Recover original routing/config initialization from the exact native methods; current OHFNGFDHOEG returnsnull and the staticinitializer returnsimmediately. A domain string replacement alone cannot restore this missing logic.','Preserve per-serviceNameServerResponse lookup/auth/session behavior; no public server contact or login has been tested bythisplan.','ns.nerlz.dev remains the later migration destination; do not silently switch to oldns.nerlz.com or infer current live health fromhistorical403.'],'Main_modified':False,'backend_modified':False,'network_requests':0,'config_credentials_or_tokens_logged':False,'managed_Unity_or_game_code_invoked':False,'tool':pin(Path(__file__))}
 p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'temporary_target':report['planned_temporary_nameserver_origin'],'native_methods':[{'name':r['name'],'token':r['original_method_token'],'RVA':r['RVA'],'native_bytes':r['native_body_bytes']} for r in native],'Main_modified':False}))
if __name__=='__main__':main()
