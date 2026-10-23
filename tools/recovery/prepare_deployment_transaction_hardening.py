"""Create a minimal reviewed deployment-tool candidate; never edits Main/tool."""
from pathlib import Path
import datetime as dt, difflib, hashlib, json, uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def need(c,s):
    if not c:raise ValueError(s)

def main():
    source=ROOT/'Tools/deploy_compile_repairs.py';original=source.read_bytes();text=original.decode('utf-8')
    changes=[
        ("  for (row,target,source),record in zip(files,records):\n   target.parent.mkdir(parents=True,exist_ok=True);temporary=target.with_name(target.name+'.rr23-repair-'+uuid.uuid4().hex)",
         "  for (row,target,source),record in zip(files,records):\n   target=safe(target,PROJECT);source=safe(source,WORKSPACE)\n   target.parent.mkdir(parents=True,exist_ok=True);safe(target.parent,PROJECT);temporary=safe(target.with_name(target.name+'.rr23-repair-'+uuid.uuid4().hex),PROJECT)"),
        ("need(digest(temporary)==row['candidate_sha256'],'Staged write hash differs');safety.assert_editor_closed();need(",
         "need(digest(temporary)==row['candidate_sha256'],'Staged write hash differs');safety.assert_editor_closed();target=safe(target,PROJECT);source=safe(source,WORKSPACE);safe(temporary,PROJECT);need("),
        ("  result.update(status='applied',project_modified=True,existing_unmodified_script_plugin_metas_preserved=True)",
         "  need(all(digest(safe(target,PROJECT))==row['candidate_sha256'] for row,target,_ in files),'An applied compile-repair target changed before transaction completion')\n  result.update(status='applied',project_modified=True,existing_unmodified_script_plugin_metas_preserved=True)"),
        ("    target=Path(record['target']);need(target.exists()", "    target=safe(record['target'],PROJECT);need(target.exists()"),
        ("else:shutil.copyfile(record['backup'],target);need(digest(target)==record['original_sha256'],'Rollback hash failed')", "else:shutil.copyfile(safe(record['backup'],out/'Original'),target);need(digest(target)==record['original_sha256'],'Rollback hash failed')")
    ]
    # Preserve the existing source newline convention in original backup;
    # edits/diff are reviewed as LF text and candidate is explicit UTF-8/LF.
    normalized=text.replace('\r\n','\n')
    for before,after in changes:need(normalized.count(before)==1,'Exact expected deployment hunk absent/ambiguous');normalized=normalized.replace(before,after)
    need(source.read_bytes()==original,'Original tool changed during preparation')
    folder=ROOT/'CompilerRepairs'/('DeploymentTransactionHardening-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);(folder/'Original').mkdir(parents=True);(folder/'Candidate').mkdir()
    backup=folder/'Original/deploy_compile_repairs.py';backup.write_bytes(original);candidate=folder/'Candidate/deploy_compile_repairs.py';candidate.write_bytes(normalized.encode('utf-8'))
    diff=folder/'deploy_compile_repairs.diff';diff.write_text(''.join(difflib.unified_diff(text.replace('\r\n','\n').splitlines(True),normalized.splitlines(True),fromfile='Original/deploy_compile_repairs.py',tofile='Candidate/deploy_compile_repairs.py')))
    report={'schema':'review-only-minimal-compile-deployment-transaction-hardening/v1','status':'candidate_not_installed_not_applied','original_tool':{'path':str(source),'sha256':sha(source)},'backup':{'path':str(backup),'sha256':sha(backup)},'candidate':{'path':str(candidate),'sha256':sha(candidate)},'exact_diff':{'path':str(diff),'sha256':sha(diff)},'changes':['Fresh source/target/temporary/parent reparse checks near each write','Final rehash of every applied target before reporting success','Fresh safe rollback target/backup paths; existing independent-write refusal preserved'],'Main_or_original_tool_modified':False,'candidate_must_not_be_invoked_as_production_before_Root_review':True}
    path=folder/'manifest.json';path.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'manifest':str(path),'sha256':sha(path),'candidate_sha256':sha(candidate),'original_sha256':sha(source)}))

if __name__=='__main__':main()
