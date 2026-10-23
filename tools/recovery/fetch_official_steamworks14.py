"""Retain only official text source, pin Git blob/SHA256; never import/execute it."""
import datetime as dt,hashlib,json,urllib.request,uuid
from pathlib import Path
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18';COMMIT='445c9559d981a864b0c35a0ac6b9151b4d11e91d'
def get(url,limit):
 with urllib.request.urlopen(urllib.request.Request(url,headers={'User-Agent':'OriginalRecoverySourceAudit'}),timeout=25) as r:
  data=r.read(limit+1)
  if len(data)>limit:raise ValueError('Bounded official source read exceeded')
  return data
out=ROOT/'Validation'/('OfficialSteamworks14-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'official-steamworks-text-source/v1','repo':'https://github.com/rlabrecque/Steamworks.NET','tag':'14.0.0','commit':COMMIT,'files':[],'downloaded_code_executed':False}
try:
 tag=get('https://api.github.com/repos/rlabrecque/Steamworks.NET/git/ref/tags/14.0.0',262144);(out/'tag.json').write_bytes(tag)
 if json.loads(tag)['object']!={'sha':COMMIT,'type':'commit','url':'https://api.github.com/repos/rlabrecque/Steamworks.NET/git/commits/'+COMMIT}:raise ValueError('Official tag moved')
 tree=get('https://api.github.com/repos/rlabrecque/Steamworks.NET/git/trees/'+COMMIT+'?recursive=1',4*1024*1024);(out/'tree.json').write_bytes(tree);rows=json.loads(tree)
 if rows.get('truncated'):raise ValueError('Incomplete official tree')
 total=0
 for row in rows['tree']:
  name=row['path'];p=Path(name)
  if row['type']!='blob' or p.suffix!='.cs' or not name.startswith('Plugins/Steamworks.NET/'):continue
  if p.is_absolute() or '..' in p.parts or row['size']>4*1024*1024:raise ValueError('Unsupported source path/size')
  total+=row['size']
  if total>12*1024*1024:raise ValueError('Official text total exceeded')
  url='https://raw.githubusercontent.com/rlabrecque/Steamworks.NET/'+COMMIT+'/'+name;data=get(url,4*1024*1024)
  gitsha=hashlib.sha1(b'blob '+str(len(data)).encode()+b'\0'+data).hexdigest()
  if len(data)!=row['size'] or gitsha!=row['sha']:raise ValueError('Git source blob identity failed')
  data.decode('utf-8-sig');target=out/'Source'/name;target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(data);report['files'].append({'path':name,'local_path':str(target),'bytes':len(data),'git_blob_sha1':gitsha,'sha256':hashlib.sha256(data).hexdigest(),'url':url})
 report.update(status='source_retained',files_count=len(report['files']),bytes=total)
except BaseException as e:report.update(status='failed',error=str(e))
finally:(out/'report.json').write_text(json.dumps(report,indent=2));print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'files':len(report['files']),'error':report.get('error')}),flush=True)
