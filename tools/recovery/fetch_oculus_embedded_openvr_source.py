"""Official OpenVR tag candidate, never infer an Oculus package version."""
import argparse,datetime as dt,hashlib,json,re,urllib.request,uuid
from pathlib import Path
parser=argparse.ArgumentParser();parser.add_argument('--tag',default='v1.0.17',choices=['v1.0.16','v1.0.17']);args=parser.parse_args();WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';BASE='https://api.github.com/repos/ValveSoftware/openvr';out=ROOT/'Validation'/('OfficialEmbeddedOpenVrCandidate-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'official-source-candidate-for-obfuscated-embedded-openvr/v1','tag':args.tag,'requests':[],'files':[],'oculus_package_version':'unknown','project_modified':False,'code_executed':False}
def fetch(url,target,limit=2*1024*1024):
 with urllib.request.urlopen(urllib.request.Request(url,headers={'User-Agent':'RecRoom-Recovery-Source-Provenance'}),timeout=30) as response:data=response.read(limit+1)
 if len(data)>limit:raise ValueError('Public text size bound exceeded')
 target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(data);report['requests'].append({'url':url,'path':str(target),'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest()});return data
try:
 ref=json.loads(fetch(BASE+'/git/ref/tags/'+args.tag,out/'ref.json'));commit=ref['object']['sha']
 if ref['object']['type']=='tag':commit=json.loads(fetch(BASE+'/git/tags/'+commit,out/'tag-object.json'))['object']['sha']
 report['commit']=commit;tree=json.loads(fetch(BASE+'/git/trees/'+commit+'?recursive=1',out/'tree.json'));assert not tree.get('truncated');rows={x['path']:x for x in tree['tree']}
 for path in ('headers/openvr_api.cs','LICENSE'):
  r=rows[path];data=fetch('https://raw.githubusercontent.com/ValveSoftware/openvr/'+commit+'/'+path,out/'Source'/path);blob=hashlib.sha1(b'blob '+str(len(data)).encode()+b'\0'+data).hexdigest()
  if blob!=r['sha']:raise ValueError('Official source Git blob differs')
  report['files'].append({'path':str(out/'Source'/path),'repository_path':path,'git_blob_sha1':blob,'sha256':hashlib.sha256(data).hexdigest(),'bytes':len(data)})
 text=(out/'Source/headers/openvr_api.cs').read_text(encoding='utf-8-sig');report['interface_versions']=dict(re.findall(r'public const string (IVR\w+_Version)\s*=\s*"([^"]+)"',text));report['status']='official_candidate_downloaded_not_yet_native_graph_matched'
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error'),'interfaces':report.get('interface_versions')}),flush=True)
