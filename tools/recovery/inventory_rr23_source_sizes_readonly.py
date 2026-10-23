"""Fast source-scope size inventory, without opening project file contents."""
from collections import defaultdict
from pathlib import Path
import datetime as dt, hashlib, json, subprocess, uuid

W=Path(__file__).resolve().parents[3]; P=W/'RR23'; A=W/'Recovery/RecRoom-2023-04-18/SourcePublicationAudit'
def main():
    names=subprocess.run(['rg','--files','--hidden','--no-ignore','Assets','Packages','ProjectSettings','CompilerSupport'],cwd=P,capture_output=True,text=True,encoding='utf-8',check=True).stdout.splitlines()+['SolarNet.Unity2020.props']
    rows=[];g=defaultdict(lambda:{'files':0,'bytes':0})
    for name in sorted(set(names)):
        path=P/name
        if path.is_symlink():raise RuntimeError('Source symlink requires review')
        n=name.replace('\\','/');s=path.stat().st_size;parts=Path(n).parts
        rows.append({'path':n,'bytes':s})
        for group in {parts[0],'/'.join(parts[:2]) if parts[0]=='Assets' else parts[0]}:
            g[group]['files']+=1;g[group]['bytes']+=s
    large=sorted([r for r in rows if r['bytes']>50*1024**2],key=lambda r:-r['bytes'])
    out=A/('Sizes-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir(parents=True)
    (out/'.gitignore').write_text('*\n!.gitignore\n',encoding='utf-8')
    d={'schema':'read-only-Unity-source-sizes/v1','files':len(rows),'bytes':sum(r['bytes'] for r in rows),'groups':dict(sorted(g.items())),'over50MiB':len(large),'over100MiB':sum(r['bytes']>100*1024**2 for r in large),'large_files':large,'source_files':rows,'scene_count':sum(r['path'].endswith('.unity') for r in rows),'modified':False,'copied':False,'published':False,'secret_scan':'separate streaming read-only scan pending'}
    f=out/'report.json';f.write_text(json.dumps(d,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({'report':str(f),'sha256':hashlib.sha256(f.read_bytes()).hexdigest(),'files':d['files'],'bytes':d['bytes'],'groups':d['groups'],'over50MiB':d['over50MiB'],'over100MiB':d['over100MiB'],'scene_count':d['scene_count']}))
if __name__=='__main__':main()
