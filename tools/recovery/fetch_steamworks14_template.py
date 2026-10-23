"""Fetch exact tag14 codegen template for comparison, never execute."""
import datetime as dt,hashlib,json,urllib.request,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';OFFICIAL=ROOT/'Validation/OfficialSteamworks14-20261022T140058Z-91fe31a3';COMMIT='445c9559d981a864b0c35a0ac6b9151b4d11e91d';NAME='CodeGen/templates/nativemethods.txt';out=ROOT/'Validation'/('OfficialSteamTemplate14-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
rows=[x for x in json.loads((OFFICIAL/'tree.json').read_text())['tree'] if x['path']==NAME and x['type']=='blob']
if len(rows)!=1:raise ValueError('Exact template tree blob missing')
row=rows[0];url='https://raw.githubusercontent.com/rlabrecque/Steamworks.NET/'+COMMIT+'/'+NAME
with urllib.request.urlopen(urllib.request.Request(url,headers={'User-Agent':'OriginalRecoverySourceAudit'}),timeout=20) as r:data=r.read(1024*1024)
git=hashlib.sha1(b'blob '+str(len(data)).encode()+b'\0'+data).hexdigest()
if len(data)!=row['size'] or git!=row['sha']:raise ValueError('Official template source mismatch')
target=out/'nativemethods.txt';target.write_bytes(data);text=data.decode('utf-8-sig');lines=text.splitlines();hits=[]
for i,line in enumerate(lines):
 if 'SteamAPI_ManualDispatch_GetAPICallResult' in line:hits.append({'line':i+1,'context':'\n'.join(lines[max(0,i-3):i+2])})
report={'schema':'pinned-official-sdk14-template-comparison/v1','commit':COMMIT,'source':str(target),'url':url,'sha256':hashlib.sha256(data).hexdigest(),'git_blob_sha1':git,'matching_method_contexts':hits,'downloaded_source_executed':False,'project_modified':False};(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'hits':hits}),flush=True)
