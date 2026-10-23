"""Verify local TMP3.0.6 runtime source against Unity's exact registry tarball.
Read-only for package cache/Main. Downloads only into a fresh Validation folder.
Never imports/installs package or executes any downloaded content.
"""
from pathlib import Path
import datetime as dt,hashlib,json,sys,tarfile,urllib.parse,urllib.request,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
CACHE=Path('C:/Users/andre/AppData/Local/Unity/cache/packages/packages.unity.com/com.unity.textmeshpro@3.0.6')

def need(c,s):
    if not c:raise ValueError(s)
def sha(path):
    with path.open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def download(url,path,limit):
    need(urllib.parse.urlparse(url).scheme=='https','HTTPS only')
    req=urllib.request.Request(url,headers={'User-Agent':'SolarNet-readonly-recovery-audit'})
    with urllib.request.urlopen(req,timeout=25) as response,path.open('xb') as target:
        need(urllib.parse.urlparse(response.url).scheme=='https','No plaintext redirect');length=0
        while True:
            b=response.read(65536)
            if not b:break
            length+=len(b);need(length<=limit,'Official response exceeds bounded download');target.write(b)
        return {'requested_url':url,'final_url':response.url,'bytes':length,'sha256':sha(path)}

def main():
    out=ROOT/'Validation'/('OfficialTextMeshPro306-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
    metadata=out/'registry.json';r=download('https://packages.unity.com/com.unity.textmeshpro',metadata,8*1024**2);registry=json.loads(metadata.read_bytes());version=registry['versions']['3.0.6'];need(version['name']=='com.unity.textmeshpro' and version['version']=='3.0.6','Exact official registry version required')
    dist=version['dist'];url=dist['tarball'];host=urllib.parse.urlparse(url).hostname;need(host in ('download.packages.unity.com','packages.unity.com'),'Unexpected registry tarball origin: '+str(host))
    archive=out/'com.unity.textmeshpro-3.0.6.tgz';a=download(url,archive,32*1024**2)
    with archive.open('rb') as f:actual_sha1=hashlib.file_digest(f,'sha1').hexdigest()
    need(actual_sha1==dist['shasum'],'Official registry tarball SHA1 mismatch')
    matched=[];missing=[];mismatched=[];seen=set();regular=0
    with tarfile.open(archive,'r|gz') as tar:
        for member in tar:
            need(member.name.startswith('package/'),'Unexpected package archive root');relative=member.name[8:]
            if member.isdir():continue
            need(member.isfile(),'No links/special tar entries admitted');regular+=1
            if not (relative.startswith('Scripts/Runtime/') or relative in ('package.json','LICENSE.md')):continue
            need(relative not in seen and '..' not in Path(relative).parts,'Unsafe/duplicate package source path');seen.add(relative)
            stream=tar.extractfile(member);need(stream is not None,'Exact regular file stream');h=hashlib.sha256();total=0
            while True:
                b=stream.read(65536)
                if not b:break
                total+=len(b);need(total<=4*1024**2,'Single runtime source member bound');h.update(b)
            p=CACHE/relative;expected=h.hexdigest();row={'relative':relative,'bytes':total,'official_sha256':expected}
            if not p.is_file():missing.append(row)
            elif sha(p)!=expected:mismatched.append({**row,'local_sha256':sha(p)})
            else:matched.append(row)
    extras=[p.relative_to(CACHE).as_posix() for p in (CACHE/'Scripts/Runtime').rglob('*') if p.is_file() and p.relative_to(CACHE).as_posix() not in seen]
    need(not missing and not mismatched and not extras,'Local cached runtime source differs from exact official package')
    report={'schema':'official-Unity-registry-TMP3.0.6-cache-source-byte-provenance/v1','status':'exact_local_runtime_source_matches_official_registry_tarball','registry':r,'tarball':a,'registry_version_dist':dist,'tarball_sha1_verified':actual_sha1,'official_package_version':'3.0.6','registry_version_fields':{k:version.get(k) for k in ('name','version','unity','unityRelease','dependencies','repository')},'cache_path':str(CACHE),'matched_runtime_and_package_files':matched,'missing':missing,'mismatched':mismatched,'extra_runtime_files':extras,'regular_archive_files':regular,'original_RecRoom_package_version_proven':False,'Main_cache_or_packages_modified':False,'package_installed_or_content_executed':False}
    p=out/'report.json';p.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(p),'sha256':sha(p),'status':report['status'],'matched':len(matched),'tarball_bytes':a['bytes']}))

if __name__=='__main__':main()
