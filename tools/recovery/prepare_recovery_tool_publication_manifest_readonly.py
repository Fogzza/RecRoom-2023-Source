"""Pin only approved recovery-tool source files; never copy or contact services."""
from pathlib import Path
from collections import Counter
import datetime as dt, fnmatch, hashlib, json, re, subprocess, uuid
import prepare_rr23_code_publication_manifest_readonly as scan

HERE=Path(__file__).resolve().parent
EXACT={'create_solarnet_github_repositories.py','configure_solarnet_discord_updates.py','name_solarnet_discord_webhook.py','copy_reviewed_solarnet_source_snapshot.py'}
def main():
    result=subprocess.run(['rg','--files','--hidden','--no-ignore','-g','*.py','-g','*.cs','.'],cwd=HERE,capture_output=True,text=True,encoding='utf-8',check=True)
    paths=sorted({(HERE/n).resolve(strict=True) for n in result.stdout.splitlines()})
    rows=[];excluded=[];findings=[];counts=Counter()
    for p in paths:
        name=p.name
        if p.parent!=HERE or name in EXACT or fnmatch.fnmatch(name.lower(),'*github*setup*auth*'):
            excluded.append({'path':str(p.relative_to(HERE)),'reason':'explicit_setup_only_exclusion_or_other_subtree'});continue
        scan.require(not p.is_symlink(),'Tool symlink refused')
        before=p.stat();data=p.read_bytes();scan.require(len(data)<=4*1024**2,'Unexpected oversized recovery source')
        after=p.stat();scan.require((before.st_size,before.st_mtime_ns)==(after.st_size,after.st_mtime_ns),'Tool changed during read')
        rows.append({'path':'tools/recovery/'+name,'source':str(p),'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest()})
        for rule,rx in scan.RX.items():
            for m in rx.finditer(data):
                counts[rule]+=1;findings.append({'path':'tools/recovery/'+name,'source':str(p),'rule':rule,'byte_offset':m.start(),'no_value_saved':True})
        for m in scan.GENERIC.finditer(data):
            val=m.group(1).strip()
            if val.lower() in {b'password',b'xxxxxxxx',b'your_api_key',b'your-api-key',b'changeme',b'********'} or val.startswith((b'http://',b'https://',b'{',b'{{',b'$(',b'REPLACE_',b'YOUR_')):continue
            counts['possible_literal_secret_assignment']+=1;findings.append({'path':'tools/recovery/'+name,'source':str(p),'rule':'possible_literal_secret_assignment','byte_offset':m.start(),'no_value_saved':True})
    out=scan.BASE/('RecoveryTools-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir(parents=True);(out/'.gitignore').write_text('*\n!.gitignore\n',encoding='utf-8')
    manifest={'schema':'reviewed-recovery-source-publication-inputs/v1','source_directory':str(HERE),'destination_prefix':'tools/recovery/','status':'credential_scan_review_required' if findings else 'credential_patterns_clear_no_copy','files':rows,'count':len(rows),'bytes':sum(r['bytes'] for r in rows),'exclude_all_unlisted':True,'excluded':excluded,'only_py_cs_source':True,'copied':False,'remote_mutation':False}
    scan.save(out/'manifest.json',manifest)
    scan.save(out/'credential-candidates-redacted.json',{'findings':findings,'counts':dict(counts),'no_secret_values_saved_or_printed':True,'coverage':'Strong token prefixes, private-key headers and generic quoted credential assignments in approved .py/.cs source only; heuristic, not proof of absence.'})
    report={'schema':'read-only-recovery-tools-publication-audit/v1','status':manifest['status'],'manifest':{'path':str(out/'manifest.json'),'sha256':scan.sha(out/'manifest.json')},'files':len(rows),'bytes':manifest['bytes'],'excluded':excluded,'candidate_count':len(findings),'candidate_files':len({r['path'] for r in findings}),'by_rule':dict(counts),'scan':{'path':str(out/'credential-candidates-redacted.json'),'sha256':scan.sha(out/'credential-candidates-redacted.json')},'source_modified':False,'copied':False,'network_or_remote_mutation':False}
    scan.save(out/'report.json',report)
    print(json.dumps({'report':str(out/'report.json'),'sha256':scan.sha(out/'report.json'),'manifest':report['manifest'],'files':len(rows),'bytes':manifest['bytes'],'candidate_count':len(findings),'candidate_files':report['candidate_files'],'by_rule':dict(counts),'excluded_count':len(excluded)}))
if __name__=='__main__':main()
