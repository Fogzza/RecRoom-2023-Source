"""Bounded official Valve source history for exact API-version identification."""
import datetime as dt,hashlib,json,re,urllib.request,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';BASE='https://api.github.com/repos/ValveSoftware/unity-xr-plugin'
out=ROOT/'Validation'/('OfficialOpenVrHistory-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'official-openvr-source-history/v1','requests':[],'revisions':[],'project_modified':False,'code_executed':False}
def fetch(url,target,limit=2*1024*1024):
 with urllib.request.urlopen(urllib.request.Request(url,headers={'User-Agent':'RecRoom-Recovery-Source-Provenance'}),timeout=30) as response:data=response.read(limit+1)
 if len(data)>limit:raise ValueError('Source size bound exceeded')
 target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(data);report['requests'].append({'url':url,'path':str(target),'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest()});return data
try:
 path='com.valve.openvr/Runtime/openvr_api.cs';commits=json.loads(fetch(BASE+'/commits?path='+path+'&per_page=100',out/'commits.json'));report['commit_count']=len(commits)
 for item in commits:
  commit=item['sha'];data=fetch('https://raw.githubusercontent.com/ValveSoftware/unity-xr-plugin/'+commit+'/'+path,out/'Revisions'/commit/'openvr_api.cs');text=data.decode('utf-8-sig');constants=dict(re.findall(r'public const string (IVR\w+_Version)\s*=\s*"([^"]+)"',text));row={'commit':commit,'date':item['commit']['committer']['date'],'message':item['commit']['message'],'source_path':str(out/'Revisions'/commit/'openvr_api.cs'),'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest(),'git_blob_sha1':hashlib.sha1(b'blob '+str(len(data)).encode()+b'\0'+data).hexdigest(),'interface_constants':constants,'target_three_interfaces_match':all(constants.get(k)==v for k,v in {'IVRSystem_Version':'IVRSystem_022','IVRCompositor_Version':'IVRCompositor_026','IVROverlay_Version':'IVROverlay_024'}.items())};report['revisions'].append(row)
 report['status']='history_downloaded_not_yet_full_contract_matched'
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error'),'revisions':len(report['revisions']),'three_constant_matches':sum(r['target_three_interfaces_match'] for r in report['revisions'])}),flush=True)
