"""Fetch pinned release-era Valve sources with the proved original API blob."""
import datetime as dt,hashlib,json,urllib.request,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';COMMIT='35c147129869a168be895e76c25c7cc071f8412e';TREE=ROOT/'Validation/OfficialOpenVrBinaryIdentity-20261022T152533Z-8f64b6da/Trees'/ (COMMIT+'.json');out=ROOT/'Validation'/('OfficialOpenVrReleaseSource-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'pinned-release-era-official-openvr-source/v1','commit':COMMIT,'tree_path':str(TREE),'tree_sha256':hashlib.sha256(TREE.read_bytes()).hexdigest(),'files':[],'project_modified':False,'code_executed':False,'overall_original_package_version_proven':False}
try:
 tree=json.loads(TREE.read_text());assert not tree.get('truncated')
 for row in tree['tree']:
  path=row['path']
  if row['type']!='blob' or not(path.startswith('com.valve.openvr/Runtime/') and path.endswith('.cs') or path in ('com.valve.openvr/package.json','LICENSE')):continue
  url='https://raw.githubusercontent.com/ValveSoftware/unity-xr-plugin/'+COMMIT+'/'+path
  with urllib.request.urlopen(urllib.request.Request(url,headers={'User-Agent':'RecRoom-Recovery-Source-Provenance'}),timeout=30) as response:data=response.read(2*1024*1024+1)
  if len(data)>2*1024*1024:raise ValueError('Source size bound exceeded')
  blob=hashlib.sha1(b'blob '+str(len(data)).encode()+b'\0'+data).hexdigest()
  if blob!=row['sha']:raise ValueError('Pinned Git blob mismatch')
  target=out/'Source'/path;target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(data);report['files'].append({'path':str(target),'repository_path':path,'url':url,'git_blob_sha1':blob,'sha256':hashlib.sha256(data).hexdigest(),'bytes':len(data)})
 report['package']=json.loads((out/'Source/com.valve.openvr/package.json').read_text());report['status']='source_downloaded_pending_native_contract_join'
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error'),'package_version':report.get('package',{}).get('version')}),flush=True)
