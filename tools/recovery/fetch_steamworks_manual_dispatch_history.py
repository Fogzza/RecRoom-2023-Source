"""Official historical source witnesses only; not a SDK upgrade or executable."""
from pathlib import Path
import datetime as dt,hashlib,json,urllib.request,uuid
WS=Path(__file__).resolve().parents[3];ROOT=WS/'Recovery/RecRoom-2023-04-18'

def get(url,limit):
    with urllib.request.urlopen(urllib.request.Request(url,headers={'User-Agent':'OriginalRecoveryContractAudit'}),timeout=25)as response:
        data=response.read(limit+1)
        if len(data)>limit:raise ValueError('Bounded official source response exceeded')
        return data

def main():
    out=ROOT/'Validation'/('OfficialSteamManualDispatchHistory-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    report={'schema':'official-historical-steamworks-manual-dispatch-source/v1','tag':'15.0.0','source_only':True,'package_version_assignment_claimed':False,'project_modified':False,'code_executed':False,'files':[]}
    try:
        base='https://api.github.com/repos/rlabrecque/Steamworks.NET'
        tag=get(base+'/git/ref/tags/15.0.0',262144);(out/'tag.json').write_bytes(tag);obj=json.loads(tag)['object']
        if obj['type']=='tag':
            annotated=get(base+'/git/tags/'+obj['sha'],262144);(out/'annotated-tag.json').write_bytes(annotated);obj=json.loads(annotated)['object']
        if obj['type']!='commit' or len(obj['sha'])!=40:raise ValueError('Expected official commit')
        commit=obj['sha'];tree=get(base+'/git/trees/'+commit+'?recursive=1',4*1024*1024);(out/'tree.json').write_bytes(tree);rows=json.loads(tree)
        if rows.get('truncated'):raise ValueError('Truncated source tree')
        names={'CallbackDispatcher.cs','CallbackIdentity.cs','Steam.cs','NativeMethods.cs','SteamStructs.cs'}
        for row in rows['tree']:
            path=Path(row['path'])
            if row['type']!='blob' or path.name not in names or not row['path'].startswith('Plugins/Steamworks.NET/'):continue
            if path.is_absolute()or'..'in path.parts or row['size']>1024*1024:raise ValueError('Unsupported official text size/path')
            url='https://raw.githubusercontent.com/rlabrecque/Steamworks.NET/'+commit+'/'+row['path'];data=get(url,1024*1024);blob=hashlib.sha1(b'blob '+str(len(data)).encode()+b'\0'+data).hexdigest()
            if len(data)!=row['size']or blob!=row['sha']:raise ValueError('Official Git blob mismatch')
            data.decode('utf-8-sig');dest=out/'Source'/path;dest.parent.mkdir(parents=True,exist_ok=True);dest.write_bytes(data);report['files'].append({'path':str(dest),'repo_path':row['path'],'url':url,'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest(),'git_blob_sha1':blob})
        if {Path(x['repo_path']).name for x in report['files']}!=names:raise ValueError('Historical layout differs; no inferred paths accepted')
        report.update(status='official-text-retained-contract-comparison-pending',commit=commit)
    except Exception as e:report.update(status='failed-no-apply',error=str(e))
    (out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'files':len(report['files']),'commit':report.get('commit'),'error':report.get('error')}))

if __name__=='__main__':main()
