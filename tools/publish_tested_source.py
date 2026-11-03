"""Preview by default. Explicit tested-source publication: private push first."""
from pathlib import Path, PurePosixPath
import argparse, datetime as dt, hashlib, json, os, re, shutil, subprocess, sys, urllib.error, urllib.request, uuid
ROOT=Path(__file__).resolve().parents[1]
SOURCE_URL='https://github.com/Fogzza/SolarNet-source.git';UPDATES_URL='https://github.com/Fogzza/SolarNet-updates.git'
AUTHOR='177904833+Fogzza@users.noreply.github.com'
PUBLIC={'README.md','CHANGELOG.md','.gitignore','.gitattributes'}
SUPPORT={'README.md','AGENTS.md','.gitignore','.gitattributes','SOURCE_SNAPSHOT.json','RECOVERY_TOOLS_SNAPSHOT.json','tools/publish_tested_source.py','tools/test_publisher_offline.py'}
STATE='.publisher-state.json';PENDING='.publisher-pending.json'
SOURCE_ROOT_DOCS={'README.md'};UPDATES_ROOT_DOCS={'README.md','CHANGELOG.md'}
class Stop(Exception):pass
def need(v,m):
    if not v:raise Stop(m)
def sha(p):
    with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def save(p,v):
    t=p.with_suffix('.writing');t.write_text(json.dumps(v,indent=2)+'\n',encoding='utf-8');os.replace(t,p)
def safe_path(value):
    need(isinstance(value,str) and value and '\\' not in value and '\x00' not in value,'invalid_manifest_path')
    p=PurePosixPath(value);need(not p.is_absolute() and all(x not in ('','.','..','.git') for x in p.parts) and ':' not in value,'escaping_or_git_manifest_path')
    need(all(x==x.rstrip(' .') and not re.search(r'[<>"|?*\x00-\x1f]',x) and not re.fullmatch(r'(?i)(?:con|prn|aux|nul|com[1-9]|lpt[1-9])(?:\..*)?',x) for x in p.parts),'unsafe_windows_path')
    recovery=len(p.parts)==3 and p.parts[:2]==('tools','recovery') and p.suffix.lower() in ('.py','.cs')
    need(p.as_posix()==value and (p.parts[0] in ('Assets','CompilerSupport','ProjectSettings','Packages') or value=='SolarNet.Unity2020.props' or recovery),'path_outside_reviewed_project_namespaces');return value
def no_links(path,base):
    need(path.resolve().is_relative_to(base.resolve()),'path_escaped_root')
    for p in (path,*path.parents):
        if p==base.parent:break
        need(not p.is_symlink(),'reparse_or_symlink_refused')
        if p.exists():need(not(getattr(p.lstat(),'st_file_attributes',0)&0x400),'reparse_or_symlink_refused')
def title_text(title):
    need(isinstance(title,str) and 1<=len(title)<=120 and '\n' not in title and '\r' not in title,'explicit_one_line_title_required')
    public_text_safe(title);return title
def public_text_safe(combined):
    patterns=(r'`',r'(?m)^(?:diff --git|@@|--- |\+\+\+ )',r'(?i)(?:[a-z]:[\\/]|/(?:Users|home|mnt|workspace)/|file://|\\\\)',r'(?i)(?:gh[pousr]_[A-Za-z0-9]{20,}|github_pat_|-----BEGIN .*PRIVATE KEY|eyJ[A-Za-z0-9_-]{8,}\.[A-Za-z0-9_-]+\.)',r'(?i)discord(?:app)?\.com/api/webhooks/',r'(?i)(?:password|secret|access_token|api_key)\s*[:=]\s*\S+',r'(?i)(?:SolarNet-source/(?:blob|commit|tree)|https?://[^\s/]+:[^\s@]+@)',r'(?m)^\s*(?:using System|public (?:class|static)|function\s|def\s|import\s|#include)')
    need(not any(re.search(p,combined) for p in patterns),'public_note_contains_code_diff_path_or_secret_candidate')
def note_text(path,title):
    title_text(title);need(path.stat().st_size<=8192,'public_note_size_bound');text=path.read_text(encoding='utf-8-sig').strip();need(len(text)>=12,'explicit_human_public_note_required')
    public_text_safe(title+'\n'+text);return text
def publication_note(title,tests,note_file,no_note):
    need(title and tests and 1<=len(tests)<=2000,'explicit_title_and_truthful_test_summary_required');title_text(title)
    if no_note:need(note_file is None,'note_file_refused_in_no_generated_note_mode');return None
    need(note_file is not None,'explicit_note_file_required');return note_text(note_file,title)
def resume_matches(state,mhash,title,notehash,tests,no_note,remove_docs):
    return state['manifest_sha256']==mhash and state['title']==title and state['note_sha256']==notehash and state['tests']==tests and type(state.get('no_generated_note',False)) is bool and type(state.get('remove_readme_changelog',False)) is bool and state.get('no_generated_note',False)==no_note and state.get('remove_readme_changelog',False)==remove_docs
class Git:
    def __init__(self,path,url):self.path=path;self.url=url
    def run(self,args,data=None,ok=(0,)):
        env=dict(os.environ,GIT_TERMINAL_PROMPT='0',GIT_AUTHOR_NAME='Fogzza',GIT_AUTHOR_EMAIL=AUTHOR,GIT_COMMITTER_NAME='Fogzza',GIT_COMMITTER_EMAIL=AUTHOR)
        p=subprocess.run(['git','-C',str(self.path),*args],input=data,capture_output=True,env=env,timeout=180)
        need(p.returncode in ok,'git_command_failed_'+args[0]);return p.stdout
    def head(self):
        p=subprocess.run(['git','-C',str(self.path),'rev-parse','--verify','HEAD'],capture_output=True,timeout=10);return p.stdout.decode().strip() if p.returncode==0 else None
    def paths(self,args):return [x.decode('utf-8') for x in self.run(args).split(b'\0') if x]
    def guard(self,allowed,resume_hashes=None):
        need(Path(self.run(['rev-parse','--show-toplevel']).decode().strip()).resolve()==self.path.resolve(),'wrong_repository_root')
        need(self.run(['remote']).decode().split()==['origin'],'foreign_or_multiple_remotes_refused')
        for a in (['remote','get-url','--all','origin'],['remote','get-url','--push','--all','origin']):need(self.run(a).decode().splitlines()==[self.url],'foreign_or_credential_embedded_remote_refused')
        need(self.run(['symbolic-ref','--short','HEAD']).decode().strip()=='main','main_branch_required')
        staged=set(self.paths(['diff','--cached','--name-only','-z']));unstaged=set(self.paths(['diff','--name-only','-z']))
        if staged:
            need(resume_hashes is not None and staged<=set(resume_hashes) and not staged&unstaged,'preexisting_or_changed_staging_refused')
            for name in staged:
                path=self.path/name;no_links(path,self.path);expected=resume_hashes[name]
                need((not path.exists()) if expected is None else path.is_file() and sha(path)==expected,'staged_resume_bytes_changed')
        changed=unstaged|set(self.paths(['ls-files','--others','--exclude-standard','-z']))
        need(changed<=allowed,'unrelated_dirty_files_refused')
    def stage(self,paths):
        if paths:self.run(['--literal-pathspecs','add','--all','--pathspec-from-file=-','--pathspec-file-nul'],b''.join(x.encode()+b'\0' for x in sorted(paths)))
    def commit(self,title,test,identifier,allowed,allow_empty=False):
        need(set(self.paths(['diff','--cached','--name-only','-z']))<=allowed,'unrelated_staging_refused')
        need(not allow_empty or self.url==UPDATES_URL,'empty_commit_only_for_matching_updates')
        if not self.paths(['diff','--cached','--name-only','-z']) and not allow_empty:return self.head()
        body=title+'\n\nPublication-ID: '+identifier+ ('\nTests: '+test if test else '')+'\n'
        self.run(['commit',*(['--allow-empty'] if allow_empty else []),'--file=-'],body.encode());return self.head()
    def push(self,commit):
        need(self.head()==commit,'HEAD_changed_before_push')
        for a in (['remote','get-url','--all','origin'],['remote','get-url','--push','--all','origin']):need(self.run(a).decode().splitlines()==[self.url],'remote_changed_before_push')
        self.run(['-c','push.followTags=false','push','--porcelain','origin',commit+':refs/heads/main'])
    def remote_head(self):
        rows=self.run(['ls-remote','origin','refs/heads/main']).decode().split();return rows[0] if rows else None
    def recovered_commit(self,base,identifier):
        head=self.head()
        if head==base:return None
        message=self.run(['show','-s','--format=%B',head]).decode();parents=self.run(['show','-s','--format=%P',head]).decode().split()
        need('Publication-ID: '+identifier in message and parents==([base] if base else []),'unrelated_or_ambiguous_commit_HOLD');return head
def visibility(private,public):
    # GCM is reached only through Git. Credential output stays in memory.
    raw=private.run(['credential','fill'],b'protocol=https\nhost=github.com\n\n');fields=dict(x.split(b'=',1) for x in raw.splitlines() if b'=' in x)
    token=fields.get(b'password');need(token,'GCM_credential_unavailable')
    class NoRedirect(urllib.request.HTTPRedirectHandler):
        def redirect_request(self,*a,**k):raise Stop('metadata_redirect_refused')
    opener=urllib.request.build_opener(urllib.request.ProxyHandler({}),NoRedirect())
    for name,want in (('SolarNet-source',True),('SolarNet-updates',True)):
        req=urllib.request.Request('https://api.github.com/repos/Fogzza/'+name,headers={'Authorization':'Bearer '+token.decode(),'Accept':'application/vnd.github+json','User-Agent':'SolarNetSourcePublisher/1','X-GitHub-Api-Version':'2022-11-28'},method='GET')
        try:
            with opener.open(req,timeout=15) as response:body=response.read(256*1024+1)
        except Exception:raise Stop('repository_visibility_metadata_failed') from None
        need(len(body)<=256*1024,'metadata_response_bound');v=json.loads(body);need(v.get('full_name','').lower()==('Fogzza/'+name).lower() and v.get('private') is want,'both_repositories_private_visibility_required')
    del token,raw,fields
def load_inputs(config):
    config=config.resolve(strict=True);cfg=json.loads(config.read_bytes());project=(config.parent/Path(cfg['project_root'])).resolve(strict=True);updates=(config.parent/Path(cfg['updates_root'])).resolve(strict=True);mp=(config.parent/Path(cfg['manifest'])).resolve(strict=True)
    h=sha(mp);need(h==cfg['manifest_sha256']==cfg['reviewed_manifest_sha256'],'fresh_reviewed_manifest_hash_required');m=json.loads(mp.read_bytes())
    need(m['schema']=='reviewed-Unity-code-only-publication-inputs/v1' and Path(m['project']).resolve()==project and m['exclude_all_unlisted'] is True and m['includes_original_metas'] is True,'exact_reviewed_code_only_scope_required')
    rows={}
    for r in m['files']:
        p=safe_path(r['path']);need(p not in rows,'duplicate_manifest_path');src=project/p;no_links(src,project)
        need(src.is_file() and src.stat().st_size==r['bytes'] and sha(src)==r['sha256'],'source_changed_since_review');rows[p]=dict(r,_source=src,_base=project)
    need(len(rows)==m['count'] and sum(x['bytes'] for x in rows.values())==m['bytes'],'manifest_count_or_size_mismatch')
    pins={'project':h}
    if cfg.get('recovery_manifest'):
        rp=(config.parent/Path(cfg['recovery_manifest'])).resolve(strict=True);rh=sha(rp)
        need(rh==cfg['recovery_manifest_sha256']==cfg['reviewed_recovery_manifest_sha256'],'fresh_reviewed_recovery_manifest_required');rm=json.loads(rp.read_bytes());base=Path(rm['source_directory']).resolve(strict=True)
        need(rm['schema']=='reviewed-recovery-source-publication-inputs/v1' and rm['exclude_all_unlisted'] is True and rm['destination_prefix']=='tools/recovery/' and rm['only_py_cs_source'] is True,'exact_recovery_scope_required')
        total=0
        for r in rm['files']:
            name=safe_path(r['path']);need(name.startswith('tools/recovery/') and name not in rows,'duplicate_or_invalid_recovery_path');src=Path(r['source']).resolve(strict=True);no_links(Path(r['source']),base)
            need(src.parent==base and src.name==PurePosixPath(name).name and src.is_file() and src.stat().st_size==r['bytes'] and sha(src)==r['sha256'],'recovery_source_changed_since_review');rows[name]=dict(r,_source=src,_base=base);total+=r['bytes']
        need(len(rm['files'])==rm['count'] and total==rm['bytes'],'recovery_manifest_count_or_size_mismatch');pins['recovery']=rh
    need(len({x.casefold() for x in rows})==len(rows),'case_colliding_manifest_paths')
    h=hashlib.sha256(json.dumps(pins,sort_keys=True).encode()).hexdigest()
    need(updates!=ROOT and not updates.is_relative_to(ROOT) and not ROOT.is_relative_to(updates),'separate_repository_roots_required')
    return cfg,project,updates,h,rows
def sync_scope(project,rows,owned,repo):
    removed=set(owned)-set(rows)
    for p in sorted(set(rows)|removed):
        safe_path(p);dst=repo/p;no_links(dst,repo)
        if dst.exists():need(dst.is_file() and (sha(dst)==rows.get(p,{}).get('sha256') or sha(dst)==owned.get(p)),'independent_destination_edit_refused')
        if p in removed:
            if dst.exists():dst.unlink() # A verified owned file only; never recursive.
        elif not dst.exists() or sha(dst)!=rows[p]['sha256']:
            src=rows[p].get('_source',project/p);no_links(src,rows[p].get('_base',project));need(src.stat().st_size==rows[p]['bytes'] and sha(src)==rows[p]['sha256'],'source_changed_before_copy')
            dst.parent.mkdir(parents=True,exist_ok=True);temp=dst.with_name(dst.name+'.publisher-writing');need(not temp.exists() and not temp.is_symlink(),'unexpected_copy_temp');shutil.copyfile(src,temp)
            need(sha(temp)==rows[p]['sha256'],'source_changed_during_copy');os.replace(temp,dst)
    return set(rows)|removed
def check_snapshots(repo,rows):
    for filename,prefix,schema in (('SOURCE_SNAPSHOT.json',False,'SolarNet-reviewed-source-code-snapshot/v1'),('RECOVERY_TOOLS_SNAPSHOT.json',True,'SolarNet-reviewed-recovery-tool-snapshot/v1')):
        path=repo/filename
        if not path.exists():continue
        value=json.loads(path.read_bytes());expected={k:(r['bytes'],r['sha256']) for k,r in rows.items() if k.startswith('tools/recovery/') is prefix}
        actual={r['path']:(r['bytes'],r['sha256']) for r in value['files']}
        need(value['schema']==schema and len(actual)==len(value['files'])==value['count'] and actual==expected,'refresh_private_snapshot_to_exact_reviewed_manifest')
def remove_root_documents(git,names):
    tracked=set(git.paths(['ls-files','-z']));need(names<=SOURCE_ROOT_DOCS if git.url==SOURCE_URL else git.url==UPDATES_URL and names<=UPDATES_ROOT_DOCS,'only_exact_repository_root_documents_may_be_removed')
    for name in sorted(names):
        path=git.path/name;no_links(path,git.path);need(not path.exists() or name in tracked,'untracked_root_document_refused')
        if path.exists():need(path.is_file(),'root_document_not_a_file');path.unlink()
def sync_source(project,rows,owned,private,remove_docs=False):
    paths=sync_scope(project,rows,owned,private.path)
    if remove_docs:remove_root_documents(private,SOURCE_ROOT_DOCS)
    return paths|{x for x in SUPPORT if (private.path/x).is_file()}|(set(private.paths(['ls-files','-z']))&SUPPORT)
def transaction(private,public,state,checkpoint,sync,write_note):
    # Durable stages never automatically retry a failed command. --resume is
    # explicit; source push precedes the private updates push. Legacy public_*
    # ledger fields remain unchanged so completed and pending records resume.
    if not state.get('private_commit'):
        existing=private.recovered_commit(state['private_base'],state['id'])
        if existing:state['private_commit']=existing;checkpoint()
        else:
            paths=sync();state['private_stage_hashes']={x:sha(private.path/x) if (private.path/x).is_file() else None for x in paths};checkpoint();private.stage(paths);candidate=private.commit(state['title'],state['tests'],state['id'],paths);need(candidate and candidate!=state['private_base'],'new_private_checkpoint_required');state['private_commit']=candidate;checkpoint()
    if not state.get('private_pushed'):
        if private.remote_head()!=state['private_commit']:private.push(state['private_commit'])
        need(private.remote_head()==state['private_commit'],'private_push_not_confirmed');state['private_pushed']=True;checkpoint()
    if not state.get('public_commit'):
        existing=public.recovered_commit(state['public_base'],state['id'])
        if existing:state['public_commit']=existing;checkpoint()
        else:
            write_note();paths={x for x in PUBLIC if (public.path/x).is_file()}|set(public.paths(['ls-files','-z']));state['public_stage_hashes']={x:sha(public.path/x) if (public.path/x).is_file() else None for x in paths};checkpoint();public.stage(paths);candidate=public.commit(state['title'],'',state['id'],PUBLIC,allow_empty=state.get('no_generated_note',False));need(candidate and candidate!=state['public_base'],'new_public_update_commit_required');state['public_commit']=candidate;checkpoint()
    if not state.get('public_pushed'):
        if public.remote_head()!=state['public_commit']:public.push(state['public_commit'])
        need(public.remote_head()==state['public_commit'],'public_push_not_confirmed');state['public_pushed']=True;checkpoint()
    state['status']='complete';checkpoint()
def main():
    p=argparse.ArgumentParser(description=__doc__);p.add_argument('--config',type=Path,default=ROOT/'.publisher.local.json');p.add_argument('--publish',action='store_true');p.add_argument('--resume',action='store_true');p.add_argument('--initialize',action='store_true');p.add_argument('--title');p.add_argument('--note-file',type=Path);p.add_argument('--test-summary');p.add_argument('--no-generated-note',action='store_true',help='Preserve user documents and publish only a matching update commit.');p.add_argument('--remove-readme-changelog',action='store_true',help='Remove the three tracked root documents once; implies --no-generated-note.');a=p.parse_args();no_note=a.no_generated_note or a.remove_readme_changelog
    cfg,project,updates,mhash,rows=load_inputs(a.config);check_snapshots(ROOT,rows);private,public=Git(ROOT,SOURCE_URL),Git(updates,UPDATES_URL)
    prior=json.loads((ROOT/STATE).read_bytes()) if (ROOT/STATE).is_file() else {'owned':{}};owned=prior.get('owned',{});pending=ROOT/PENDING
    need(not any(x.startswith('tools/recovery/') for x in owned) or cfg.get('recovery_manifest'),'previous_recovery_scope_requires_fresh_manifest')
    resumed=json.loads(pending.read_bytes()) if a.resume and pending.is_file() else {}
    private.guard(set(rows)|set(owned)|SUPPORT,resumed.get('private_stage_hashes'));public.guard(PUBLIC,resumed.get('public_stage_hashes'));need(set(public.paths(['ls-files','-z']))<=PUBLIC,'public_repository_contains_non_documentation_file')
    if a.initialize:
        need(not a.publish and not a.resume and not no_note and not pending.exists() and private.head(),'initialize_existing_private_commit_only')
        need(all((ROOT/k).is_file() and sha(ROOT/k)==r['sha256'] for k,r in rows.items()),'initial_private_snapshot_not_exact_manifest')
        save(ROOT/STATE,{'schema':'SolarNet-source-publication-state/v1','owned':{k:r['sha256'] for k,r in rows.items()},'private_commit':private.head(),'manifest_sha256':mhash});print(json.dumps({'status':'ownership_initialized_no_commit_or_push','files':len(rows)}));return
    note=publication_note(a.title,a.test_summary,a.note_file,no_note)
    need(set(private.paths(['ls-files','-z']))<=set(rows)|set(owned)|SUPPORT,'tracked_private_files_outside_owned_scope_refused')
    need(owned or not any((ROOT/k).exists() and sha(ROOT/k)!=r['sha256'] for k,r in rows.items()),'initialize_previous_snapshot_before_source_changes')
    if not a.publish:print(json.dumps({'status':'preview_no_copy_commit_push_or_credentials','source_files':len(rows),'source_bytes':sum(x['bytes'] for x in rows.values()),'remove_owned_files':len(set(owned)-set(rows)),'private_then_public':True,'private_visibility_checked_during_explicit_publish':True,'no_generated_note':no_note,'remove_readme_changelog':a.remove_readme_changelog,'root_documents_to_remove':{'source':sorted(SOURCE_ROOT_DOCS&set(private.paths(['ls-files','-z']))),'updates':sorted(UPDATES_ROOT_DOCS&set(public.paths(['ls-files','-z'])))} if a.remove_readme_changelog else {}}));return
    visibility(private,public)
    notehash=hashlib.sha256(note.encode()).hexdigest() if note is not None else None
    if pending.exists():
        state=json.loads(pending.read_bytes());need(a.resume and resume_matches(state,mhash,a.title,notehash,a.test_summary,no_note,a.remove_readme_changelog),'explicit_matching_resume_required')
    else:
        need(not a.resume,'no_pending_publication_to_resume');state={'schema':'SolarNet-source-then-public-update/v1','id':uuid.uuid4().hex,'status':'starting','title':a.title,'tests':a.test_summary,'note_sha256':notehash,'manifest_sha256':mhash,'no_generated_note':no_note,'remove_readme_changelog':a.remove_readme_changelog,'private_base':private.head(),'public_base':public.head()};save(pending,state)
    def checkpoint():save(pending,state)
    def sync():return sync_source(project,rows,owned,private,a.remove_readme_changelog)
    def write_note():
        if a.remove_readme_changelog:remove_root_documents(public,UPDATES_ROOT_DOCS)
        if no_note:return
        path=updates/'CHANGELOG.md';old=path.read_text(encoding='utf-8') if path.exists() else '# Development updates\n'
        marker='<!-- publication: '+state['id']+' -->'
        if marker not in old:path.write_text(old.rstrip()+'\n\n## '+dt.datetime.now(dt.timezone.utc).date().isoformat()+' — '+a.title+'\n\n'+note+'\n\n'+marker+'\n',encoding='utf-8',newline='\n')
    try:transaction(private,public,state,checkpoint,sync,write_note)
    except Exception:state['status']='HOLD_inspect_pending_no_automatic_retry';checkpoint();raise
    save(ROOT/STATE,{'schema':'SolarNet-source-publication-state/v1','owned':{k:r['sha256'] for k,r in rows.items()},'manifest_sha256':mhash,'private_commit':state['private_commit'],'public_commit':state['public_commit']});archive=ROOT/'.publisher-cache';archive.mkdir(exist_ok=True);os.replace(pending,archive/(state['id']+'.json'))
    print(json.dumps({'status':'published_private_source_then_matching_update' if no_note else 'published_private_source_then_matching_public_note','private_commit':state['private_commit'],'public_commit':state['public_commit'],'source_files':len(rows),'no_generated_note':no_note,'remove_readme_changelog':a.remove_readme_changelog}))
if __name__=='__main__':
    try:main()
    except (Stop,KeyError,ValueError,OSError,subprocess.SubprocessError):print(json.dumps({'status':'HOLD_no_automatic_retry','message':'Check local inputs, repository state, and the ignored pending ledger. No credential or raw Git output is printed.'}));raise SystemExit(1)
