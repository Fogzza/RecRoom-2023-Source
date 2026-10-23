"""Match original native DLL Git blob hashes against official history, no downloads."""
import datetime as dt,hashlib,json,urllib.request,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';BASE='https://api.github.com/repos/ValveSoftware/unity-xr-plugin';out=ROOT/'Validation'/('OfficialOpenVrBinaryIdentity-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'native-original-official-openvr-git-blob-identity/v1','project_modified':False,'code_executed':False,'native_binaries_downloaded':False,'requests':[],'revisions':[]}
def fetch(url,target,limit=2*1024*1024):
 with urllib.request.urlopen(urllib.request.Request(url,headers={'User-Agent':'RecRoom-Recovery-Source-Provenance'}),timeout=30) as response:data=response.read(limit+1)
 if len(data)>limit:raise ValueError('Metadata size bound exceeded')
 target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(data);report['requests'].append({'url':url,'path':str(target),'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest()});return data
try:
 inputs=[]
 for name in ['XRSDKOpenVR.dll','openvr_api.dll']:
  p=ROOT/'VerifiedSource/RecRoom_Data/Plugins/x86_64'/name;data=p.read_bytes();inputs.append({'path':str(p),'name':name,'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest(),'git_blob_sha1':hashlib.sha1(b'blob '+str(len(data)).encode()+b'\0'+data).hexdigest(),'repository_path':'com.valve.openvr/Runtime/x64/'+name})
 report['original_inputs']=inputs;commits=json.loads(fetch(BASE+'/commits?path=com.valve.openvr/Runtime/x64/XRSDKOpenVR.dll&per_page=100',out/'commits.json'));report['history_count']=len(commits)
 # Source interface history proves the 2020-07 API remained until 2023-03-23.
 # Try the bounded release-era native revisions; this is an identity search,
 # not an assumption that the first release-era revision is the original.
 candidates=[x for x in commits if '2020-08'<=x['commit']['committer']['date']<'2023-03-23']
 report['candidate_count']=len(candidates)
 if len(candidates)>30:raise ValueError('Refuse unbounded history scan')
 for item in candidates:
  commit=item['sha'];tree=json.loads(fetch(BASE+'/git/trees/'+commit+'?recursive=1',out/'Trees'/(commit+'.json')));assert not tree.get('truncated');rows={r['path']:r for r in tree['tree']};matches=[{'name':p['name'],'expected_git_blob_sha1':p['git_blob_sha1'],'official_git_blob_sha1':rows.get(p['repository_path'],{}).get('sha'),'matches':rows.get(p['repository_path'],{}).get('sha')==p['git_blob_sha1']} for p in inputs];report['revisions'].append({'commit':commit,'date':item['commit']['committer']['date'],'message':item['commit']['message'],'native_blob_matches':matches,'both_match':all(x['matches'] for x in matches)})
  if all(x['matches'] for x in matches):
   report['source_files']=[]
   for path,row in rows.items():
    if row['type']!='blob' or not (path.startswith('com.valve.openvr/Runtime/') and path.endswith('.cs') or path in ('com.valve.openvr/package.json','LICENSE')):continue
    target=out/'Source'/path;data=fetch('https://raw.githubusercontent.com/ValveSoftware/unity-xr-plugin/'+commit+'/'+path,target);blob=hashlib.sha1(b'blob '+str(len(data)).encode()+b'\0'+data).hexdigest()
    if blob!=row['sha']:raise ValueError('Pinned official source Git blob differs')
    report['source_files'].append({'path':str(target),'repository_path':path,'git_blob_sha1':blob,'sha256':hashlib.sha256(data).hexdigest(),'bytes':len(data)})
   report['package']=json.loads((out/'Source/com.valve.openvr/package.json').read_text());break
 report['status']='official_native_blob_history_compared';report['matching_commits']=[r['commit'] for r in report['revisions'] if r['both_match']]
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error'),'matching_commits':report.get('matching_commits')}),flush=True)
