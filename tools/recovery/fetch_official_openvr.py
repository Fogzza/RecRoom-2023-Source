"""Fetch only bounded public Valve source/metadata; never binaries or execution."""
import datetime as dt,hashlib,json,urllib.request,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';BASE='https://api.github.com/repos/ValveSoftware/unity-xr-plugin'
out=ROOT/'Validation'/('OfficialOpenVrSource-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'official-valve-openvr-source-fetch/v1','project_modified':False,'code_executed':False,'requests':[],'files':[]}
def fetch(url,target,limit=4*1024*1024):
 request=urllib.request.Request(url,headers={'User-Agent':'RecRoom-Recovery-Source-Provenance','Accept':'application/vnd.github+json'})
 with urllib.request.urlopen(request,timeout=30) as response:
  data=response.read(limit+1)
  if len(data)>limit:raise ValueError('Bounded public source response too large')
  row={'url':url,'final_url':response.url,'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest(),'path':str(target)}
 target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(data);report['requests'].append(row);return data
try:
 ref=json.loads(fetch(BASE+'/git/ref/heads/master',out/'ref.json'));commit=ref['object']['sha'];tree=json.loads(fetch(BASE+'/git/trees/'+commit+'?recursive=1',out/'tree.json'));assert not tree.get('truncated');report['commit']=commit
 for row in tree['tree']:
  path=row['path']
  if row['type']!='blob' or not (path.startswith('com.valve.openvr/Runtime/') and path.endswith('.cs') or path in ('com.valve.openvr/package.json','LICENSE')):continue
  assert row.get('size',0)<=2*1024*1024
  target=out/'Source'/path;data=fetch('https://raw.githubusercontent.com/ValveSoftware/unity-xr-plugin/'+commit+'/'+path,target,2*1024*1024);actual=hashlib.sha1(b'blob '+str(len(data)).encode()+b'\0'+data).hexdigest()
  if actual!=row['sha']:raise ValueError('Official Git blob SHA mismatch')
  report['files'].append({'repository_path':path,'path':str(target),'git_blob_sha1':actual,'sha256':hashlib.sha256(data).hexdigest(),'bytes':len(data)})
 report['status']='downloaded_pinned_official_source_not_yet_version_matched'
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)
