"""Local controls and isolated temporary Git fixtures. No live repository mutation,
remote push, credential access or HTTP operation.
"""
import contextlib
import importlib.util
import io
import json
from pathlib import Path
import subprocess
import sys
import tempfile
import unittest
from unittest.mock import patch

SPEC=importlib.util.spec_from_file_location('publisher',Path(__file__).with_name('publish_tested_source.py'))
p=importlib.util.module_from_spec(SPEC);SPEC.loader.exec_module(p)

class FakeGit:
    def __init__(self,name,path,events,fail=None):
        self.name=name;self.path=path;self.events=events;self.fail=fail;self.current=name+'0';self.remote=name+'0';self.commits=0
    def recovered_commit(self,base,identifier):
        if self.current==base:return None
        p.need(self.current==self.name+'1','foreign_commit');return self.current
    def stage(self,paths):self.events.append(self.name+'_stage')
    def paths(self,args):return []
    def commit(self,*args,**kwargs):
        self.events.append(self.name+'_commit')
        if self.fail=='commit':self.fail=None;raise p.Stop('simulated_commit_failure')
        self.commits+=1;self.current=self.name+'1';return self.current
    def remote_head(self):return self.remote
    def push(self,commit):
        self.events.append(self.name+'_push')
        if self.fail=='push':self.fail=None;raise p.Stop('simulated_push_failure')
        self.remote=commit

class Controls(unittest.TestCase):
    def local_publication_fixture(self,folder,changed=True):
        """Actual index/commit behavior, confined to disposable repositories.

        Only push and remote-head operations are faked. No live clone is edited.
        """
        project=folder/'project';private=folder/'source-repo';public=folder/'updates-repo';events=[]
        for directory in(project,private,public):directory.mkdir()
        for directory in(private,public):
            subprocess.run(['git','init','--initial-branch=main',str(directory)],capture_output=True,check=True)
            hooks=directory/'.git/offline-no-hooks';hooks.mkdir();subprocess.run(['git','-C',str(directory),'config','core.hooksPath',str(hooks)],capture_output=True,check=True);subprocess.run(['git','-C',str(directory),'config','commit.gpgsign','false'],capture_output=True,check=True)
            (directory/'.gitignore').write_text('.publisher*\n',encoding='utf8')
            (directory/'README.md').write_text('User-written readme\n',encoding='utf8')
        (public/'CHANGELOG.md').write_text('User-written changelog\n',encoding='utf8')
        (private/'Assets').mkdir();(project/'Assets').mkdir();old=private/'Assets/a.cs';old.write_bytes(b'class Before {}\n');source=project/'Assets/a.cs';source.write_bytes(b'class After {}\n'if changed else old.read_bytes())
        for directory,url in((private,p.SOURCE_URL),(public,p.UPDATES_URL)):
            subprocess.run(['git','-C',str(directory),'remote','add','origin',url],capture_output=True,check=True)
            subprocess.run(['git','-C',str(directory),'add','--all'],capture_output=True,check=True)
            subprocess.run(['git','-C',str(directory),'-c','user.name=Offline Fixture','-c','user.email=offline@example.invalid','-c','commit.gpgsign=false','commit','-m','Temporary fixture'],capture_output=True,check=True)
        class LocalGit(p.Git):
            def __init__(self,path,url):
                super().__init__(path,url);self.name='private'if url==p.SOURCE_URL else'public';self.remote=self.head();self.initial=self.head();self.fail_push=False
            def stage(self,paths):
                super().stage(paths);events.append({'repository':self.name,'paths':set(paths),'staged':self.run(['diff','--cached','--name-status']).decode()})
            def push(self,commit):
                p.need(self.head()==commit,'HEAD_changed_before_fake_push');events.append(self.name+'_push')
                if self.fail_push:self.fail_push=False;raise p.Stop('simulated_push_failure')
                self.remote=commit
            def remote_head(self):return self.remote
        a,b=LocalGit(private,p.SOURCE_URL),LocalGit(public,p.UPDATES_URL)
        row={'path':'Assets/a.cs','bytes':source.stat().st_size,'sha256':p.sha(source)};manifest={'schema':'reviewed-Unity-code-only-publication-inputs/v1','project':str(project),'files':[row],'count':1,'bytes':row['bytes'],'exclude_all_unlisted':True,'includes_original_metas':True};mp=folder/'manifest.json';mp.write_text(json.dumps(manifest),encoding='utf8');config=folder/'config.json';config.write_text(json.dumps({'project_root':str(project),'updates_root':str(public),'manifest':str(mp),'manifest_sha256':p.sha(mp),'reviewed_manifest_sha256':p.sha(mp)}),encoding='utf8')
        (private/p.STATE).write_text(json.dumps({'owned':{'Assets/a.cs':p.sha(old)},'private_commit':a.head(),'public_commit':b.head()}),encoding='utf8');note=folder/'note.txt';note.write_text('A human-written update about the tested change.',encoding='utf8')
        def invoke(*flags,visibility=None):
            args=['publisher','--config',str(config),'--title','[Fixed] Tested fixture','--test-summary','Isolated offline checks passed',*flags]
            def factory(path,url):
                value=a if url==p.SOURCE_URL else b;self.assertEqual(Path(path).resolve(),value.path.resolve());return value
            with patch.object(p,'ROOT',private),patch.object(p,'Git',side_effect=factory),patch.object(p,'visibility',side_effect=visibility or(lambda *_:events.append('both_private_checked'))),patch.object(sys,'argv',args),contextlib.redirect_stdout(io.StringIO()):p.main()
        return a,b,invoke,note,events

    def test_document_removal_stages_actual_root_deletions_without_recreating_notes(self):
        with tempfile.TemporaryDirectory()as d:
            root=Path(d);a,b,invoke,_,events=self.local_publication_fixture(root);outside=root/'README.md';outside.write_text('Preserve unrelated document')
            invoke('--publish','--remove-readme-changelog')
            self.assertFalse((a.path/'README.md').exists());self.assertFalse((b.path/'README.md').exists());self.assertFalse((b.path/'CHANGELOG.md').exists());self.assertEqual(outside.read_text(),'Preserve unrelated document')
            source_stage=next(x for x in events if isinstance(x,dict)and x['repository']=='private');updates_stage=next(x for x in events if isinstance(x,dict)and x['repository']=='public')
            self.assertIn('README.md',source_stage['paths']);self.assertIn('D\tREADME.md',source_stage['staged']);self.assertIn('D\tREADME.md',updates_stage['staged']);self.assertIn('D\tCHANGELOG.md',updates_stage['staged']);self.assertNotIn('README.md',a.paths(['ls-tree','--name-only','-z','HEAD']));self.assertNotIn('CHANGELOG.md',b.paths(['ls-tree','--name-only','-z','HEAD']))
            self.assertLess(events.index('both_private_checked'),events.index('private_push'));self.assertLess(events.index('private_push'),next(i for i,x in enumerate(events)if isinstance(x,dict)and x['repository']=='public'));self.assertLess(events.index('private_push'),events.index('public_push'))
            ledger=json.loads(next((a.path/'.publisher-cache').glob('*.json')).read_bytes());self.assertTrue(ledger['no_generated_note']);self.assertTrue(ledger['remove_readme_changelog']);self.assertIsNone(ledger['note_sha256']);self.assertIsNone(ledger['private_stage_hashes']['README.md']);self.assertIsNone(ledger['public_stage_hashes']['CHANGELOG.md'])

    def test_no_generated_note_preserves_user_docs_and_allows_matching_empty_update(self):
        with tempfile.TemporaryDirectory()as d:
            a,b,invoke,_,events=self.local_publication_fixture(Path(d));before={str(path):path.read_bytes()for path in(a.path/'README.md',b.path/'README.md',b.path/'CHANGELOG.md')};old_tree=b.run(['rev-parse','HEAD^{tree}'])
            invoke('--publish','--no-generated-note')
            for name,body in before.items():self.assertEqual(Path(name).read_bytes(),body)
            self.assertNotEqual(a.head(),a.initial);self.assertNotEqual(b.head(),b.initial);self.assertEqual(b.run(['rev-parse','HEAD^{tree}']),old_tree);self.assertLess(events.index('private_push'),events.index('public_push'))
            ledger=json.loads(next((a.path/'.publisher-cache').glob('*.json')).read_bytes());self.assertTrue(ledger['no_generated_note']);self.assertFalse(ledger['remove_readme_changelog'])

    def test_document_removal_resume_binds_both_modes_and_reuses_commits(self):
        with tempfile.TemporaryDirectory()as d:
            a,b,invoke,_,events=self.local_publication_fixture(Path(d));b.fail_push=True
            with self.assertRaisesRegex(p.Stop,'simulated_push_failure'):invoke('--publish','--remove-readme-changelog')
            ledger=json.loads((a.path/p.PENDING).read_bytes());self.assertTrue(ledger['private_pushed']);heads=(a.head(),b.head())
            with self.assertRaisesRegex(p.Stop,'explicit_matching_resume_required'):invoke('--publish','--resume','--no-generated-note')
            with self.assertRaisesRegex(p.Stop,'explicit_matching_resume_required'):invoke('--publish','--resume','--note-file',str(Path(d)/'note.txt'))
            self.assertEqual((a.head(),b.head()),heads);invoke('--publish','--resume','--remove-readme-changelog');self.assertEqual((a.head(),b.head()),heads);self.assertEqual(events.count('private_push'),1);self.assertEqual(events.count('public_push'),2);self.assertFalse((b.path/'CHANGELOG.md').exists());self.assertFalse((a.path/p.PENDING).exists())

    def test_no_note_mode_keeps_private_visibility_gate_and_source_change_requirement(self):
        with tempfile.TemporaryDirectory()as d:
            a,b,invoke,_,events=self.local_publication_fixture(Path(d))
            def reject(*_):raise p.Stop('both_repositories_private_visibility_required')
            with self.assertRaisesRegex(p.Stop,'both_repositories_private_visibility_required'):invoke('--publish','--remove-readme-changelog',visibility=reject)
            self.assertEqual((a.head(),b.head()),(a.initial,b.initial));self.assertTrue((a.path/'README.md').is_file());self.assertTrue((b.path/'CHANGELOG.md').is_file());self.assertNotIn('private_push',events)
        with tempfile.TemporaryDirectory()as d:
            a,b,invoke,_,events=self.local_publication_fixture(Path(d),changed=False)
            with self.assertRaisesRegex(p.Stop,'new_private_checkpoint_required'):invoke('--publish','--no-generated-note')
            self.assertEqual(b.head(),b.initial);self.assertNotIn('public_push',events)

    def test_default_note_workflow_still_preserves_readmes_and_writes_changelog(self):
        with tempfile.TemporaryDirectory()as d:
            a,b,invoke,note,_=self.local_publication_fixture(Path(d));invoke('--publish','--note-file',str(note));self.assertTrue((a.path/'README.md').is_file());self.assertTrue((b.path/'README.md').is_file());text=(b.path/'CHANGELOG.md').read_text();self.assertIn('User-written changelog',text);self.assertIn(note.read_text(),text)

    def test_no_note_inputs_title_safety_and_legacy_mode_identity(self):
        with tempfile.TemporaryDirectory()as d:
            note=Path(d)/'note';note.write_text('A human development note.')
            self.assertIsNone(p.publication_note('[Fixed] Test update','Offline checks passed',None,True))
            for title,tests,note_file in((None,'tests',None),('Title',None,None),('Two\nlines','tests',None),('C:\\Users\\person','tests',None),('password=not-for-publication','tests',None),('Title','tests',note)):
                with self.subTest(title=title),self.assertRaises(p.Stop):p.publication_note(title,tests,note_file,True)
            legacy={'manifest_sha256':'m','title':'Title','note_sha256':'n','tests':'tests'};self.assertTrue(p.resume_matches(legacy,'m','Title','n','tests',False,False));self.assertFalse(p.resume_matches(legacy,'m','Title','n','tests',True,False))
            removal=dict(legacy,no_generated_note=True,remove_readme_changelog=True);self.assertFalse(p.resume_matches(removal,'m','Title','n','tests',True,False));self.assertFalse(p.resume_matches(removal,'m','Title','n','tests',False,True))

    def test_empty_commits_are_updates_only_and_default_empty_update_is_refused(self):
        with tempfile.TemporaryDirectory()as d:
            a,b,_,_,events=self.local_publication_fixture(Path(d));state={'id':'empty-control','private_base':a.head(),'public_base':b.head(),'title':'A test update','tests':'Offline checks'}
            with self.assertRaisesRegex(p.Stop,'empty_commit_only_for_matching_updates'):a.commit('A test update','checks','fixture',p.SUPPORT,allow_empty=True)
            project=Path(d)/'project';source=project/'Assets/a.cs';rows={'Assets/a.cs':{'bytes':source.stat().st_size,'sha256':p.sha(source)}}
            def sync():return p.sync_source(project,rows,{'Assets/a.cs':p.sha(a.path/'Assets/a.cs')},a)
            with self.assertRaisesRegex(p.Stop,'new_public_update_commit_required'):p.transaction(a,b,state,lambda:None,sync,lambda:None)
            self.assertNotIn('public_commit',state);self.assertNotIn('public_push',events)

    def test_both_private_visibility_metadata_gate_offline(self):
        # The credential helper and HTTPS opener are fakes; no live access.
        class FakeCredentials:
            def run(self,args,data):
                self.args=args;self.data=data
                return b'username=fixture\npassword=fixture-not-a-credential\n'
        class Reply:
            def __init__(self,value):self.body=json.dumps(value).encode()
            def __enter__(self):return self
            def __exit__(self,*a):pass
            def read(self,size):return self.body[:size]
        class Opener:
            def __init__(self,values):self.values=iter(values);self.requests=[]
            def open(self,request,timeout):self.requests.append((request.full_url,request.method,timeout));return Reply(next(self.values))
        for source_private,updates_private,passed in ((True,True,True),(True,False,False),(False,True,False),(False,False,False)):
            with self.subTest(source_private=source_private,updates_private=updates_private):
                credentials=FakeCredentials();opener=Opener([{'full_name':'Fogzza/SolarNet-source','private':source_private},{'full_name':'Fogzza/SolarNet-updates','private':updates_private}])
                with patch.object(p.urllib.request,'build_opener',return_value=opener):
                    if passed:p.visibility(credentials,None)
                    else:
                        with self.assertRaisesRegex(p.Stop,'both_repositories_private_visibility_required'):p.visibility(credentials,None)
                self.assertEqual(credentials.args,['credential','fill']);self.assertTrue(all(method=='GET' and timeout==15 for _,method,timeout in opener.requests));self.assertTrue(all(url.startswith('https://api.github.com/repos/Fogzza/') for url,_,_ in opener.requests))
        opener=Opener([{'full_name':'OtherOwner/SolarNet-source','private':True}])
        with patch.object(p.urllib.request,'build_opener',return_value=opener),self.assertRaises(p.Stop):p.visibility(FakeCredentials(),None)
    def test_manifest_paths(self):
        for value in ('Assets/Code.cs','Assets/Code.cs.meta','CompilerSupport/a.cs','ProjectSettings/ProjectSettings.asset','Packages/manifest.json','SolarNet.Unity2020.props','tools/recovery/a.py'):
            self.assertEqual(p.safe_path(value),value)
        for value in ('../x','/x','C:/x','Assets/../x','.git/config','Assets/.git/config','Assets//x','Assets/x:stream','Assets/NUL.cs','Assets/name.','tools/recovery/a.dll','tools/private.py','Assets\\x'):
            with self.subTest(value=value),self.assertRaises(p.Stop):p.safe_path(value)
    def test_notes(self):
        with tempfile.TemporaryDirectory() as d:
            path=Path(d)/'note';path.write_text('A small Windows test passed. The full import still needs work.')
            self.assertIn('Windows',p.note_text(path,'Shader recovery'))
            for value in ('Here is `source code`.', 'Local C:\\Users\\person\\project changed.', 'diff --git a/file b/file\nActual code follows.', 'password=not-for-publication', 'https://discord.com/api/webhooks/id/value', 'github_pat_'+('x'*35), 'public class RecoveredGame {}'):
                path.write_text(value)
                with self.subTest(value=value[:16]),self.assertRaises(p.Stop):p.note_text(path,'Update')
            path.write_text('A factual development update.')
            with self.assertRaises(p.Stop):p.note_text(path,'Two\nlines')
    def test_exact_sync_and_owned_removal(self):
        with tempfile.TemporaryDirectory() as d:
            base=Path(d);src=base/'source';repo=base/'repo';(src/'Assets').mkdir(parents=True);repo.mkdir()
            f=src/'Assets/a.cs';f.write_bytes(b'class A {}\r\n');rows={'Assets/a.cs':{'bytes':f.stat().st_size,'sha256':p.sha(f)}}
            touched=p.sync_scope(src,rows,{},repo);self.assertEqual(touched,{'Assets/a.cs'});self.assertEqual((repo/'Assets/a.cs').read_bytes(),f.read_bytes())
            (repo/'Assets/independent.cs').write_bytes(b'preserve')
            p.sync_scope(src,{}, {'Assets/a.cs':p.sha(f)},repo)
            self.assertFalse((repo/'Assets/a.cs').exists());self.assertEqual((repo/'Assets/independent.cs').read_bytes(),b'preserve')
    def test_refuse_independent_destination_change(self):
        with tempfile.TemporaryDirectory() as d:
            base=Path(d);src=base/'source';repo=base/'repo';(src/'Assets').mkdir(parents=True);(repo/'Assets').mkdir(parents=True)
            (src/'Assets/a.cs').write_bytes(b'new');(repo/'Assets/a.cs').write_bytes(b'independent')
            rows={'Assets/a.cs':{'bytes':3,'sha256':p.sha(src/'Assets/a.cs')}}
            with self.assertRaises(p.Stop):p.sync_scope(src,rows,{'Assets/a.cs':'0'*64},repo)
            self.assertEqual((repo/'Assets/a.cs').read_bytes(),b'independent')
    def test_source_changed_before_copy(self):
        with tempfile.TemporaryDirectory() as d:
            base=Path(d);src=base/'source';repo=base/'repo';(src/'Assets').mkdir(parents=True);repo.mkdir();f=src/'Assets/a.cs';f.write_bytes(b'old');rows={'Assets/a.cs':{'bytes':3,'sha256':p.sha(f)}};f.write_bytes(b'new')
            with self.assertRaises(p.Stop):p.sync_scope(src,rows,{},repo)
            self.assertFalse((repo/'Assets/a.cs').exists())
    def transaction_fixture(self,folder,private_fail=None,public_fail=None):
        events=[];private_path=folder/'private';public_path=folder/'public';private_path.mkdir();public_path.mkdir();(private_path/'README.md').write_text('private');(public_path/'README.md').write_text('public')
        a=FakeGit('private',private_path,events,private_fail);b=FakeGit('public',public_path,events,public_fail)
        state={'id':'fixture','private_base':'private0','public_base':'public0','title':'Tested update','tests':'Meaningful fixture checks passed'}
        def checkpoint():events.append('checkpoint')
        def sync():events.append('sync');return {'README.md'}
        def note():events.append('public_note');(public_path/'CHANGELOG.md').write_text('Human update')
        return a,b,state,checkpoint,sync,note,events
    def test_private_before_public(self):
        with tempfile.TemporaryDirectory() as d:
            a,b,s,c,x,n,events=self.transaction_fixture(Path(d));p.transaction(a,b,s,c,x,n)
            self.assertEqual(s['status'],'complete');self.assertLess(events.index('private_push'),events.index('public_note'));self.assertLess(events.index('private_push'),events.index('public_push'));self.assertEqual((a.commits,b.commits),(1,1))
    def test_private_failure_blocks_public_and_resume_reuses_commit(self):
        with tempfile.TemporaryDirectory() as d:
            a,b,s,c,x,n,events=self.transaction_fixture(Path(d),private_fail='push')
            with self.assertRaises(p.Stop):p.transaction(a,b,s,c,x,n)
            self.assertNotIn('public_note',events);self.assertEqual(a.commits,1)
            p.transaction(a,b,s,c,x,n);self.assertEqual((a.commits,b.commits),(1,1));self.assertEqual(s['status'],'complete')
    def test_public_failure_resume_does_not_duplicate(self):
        with tempfile.TemporaryDirectory() as d:
            a,b,s,c,x,n,events=self.transaction_fixture(Path(d),public_fail='push')
            with self.assertRaises(p.Stop):p.transaction(a,b,s,c,x,n)
            p.transaction(a,b,s,c,x,n);self.assertEqual((a.commits,b.commits),(1,1));self.assertEqual(events.count('public_note'),1)
    def test_ambiguous_commit_recovered(self):
        with tempfile.TemporaryDirectory() as d:
            a,b,s,c,x,n,events=self.transaction_fixture(Path(d));a.current='private1';p.transaction(a,b,s,c,x,n)
            self.assertNotIn('private_commit',events);self.assertEqual(b.commits,1)
    def test_unchanged_source_does_not_publish(self):
        with tempfile.TemporaryDirectory() as d:
            a,b,s,c,x,n,events=self.transaction_fixture(Path(d));a.commit=lambda *args:a.current
            with self.assertRaises(p.Stop):p.transaction(a,b,s,c,x,n)
            self.assertFalse(s.get('private_commit'));self.assertNotIn('public_note',events)
    def test_guard_foreign_remote_dirty_and_resume(self):
        with tempfile.TemporaryDirectory() as d:
            base=Path(d);(base/'README.md').write_text('owned');git=p.Git(base,p.SOURCE_URL);staged=[];dirty=[];url=p.SOURCE_URL
            def run(args,*a,**k):
                if args==['rev-parse','--show-toplevel']:return str(base).replace('\\','/').encode()+b'\n'
                if args==['remote']:return b'origin\n'
                if args[:2]==['remote','get-url']:return url.encode()+b'\n'
                if args[0]=='symbolic-ref':return b'main\n'
                if args[:2]==['diff','--cached']:return b''.join(x.encode()+b'\0' for x in staged)
                if args[0]=='diff':return b''.join(x.encode()+b'\0' for x in dirty)
                if args[0]=='ls-files':return b''
                self.fail('Unexpected Git command in fake guard')
            git.run=run;git.guard({'README.md'});url='https://github.com/foreign/repo.git'
            with self.assertRaises(p.Stop):git.guard({'README.md'})
            url=p.SOURCE_URL;dirty=['private-capture.json']
            with self.assertRaises(p.Stop):git.guard({'README.md'})
            dirty=[];staged=['README.md']
            with self.assertRaises(p.Stop):git.guard({'README.md'})
            git.guard({'README.md'},{'README.md':p.sha(base/'README.md')})
            (base/'README.md').write_text('independent')
            with self.assertRaises(p.Stop):git.guard({'README.md'},{'README.md':'0'*64})
    def test_combined_reviewed_manifest(self):
        with tempfile.TemporaryDirectory() as d:
            base=Path(d);project=base/'project';updates=base/'updates';tool=base/'tools';(project/'Assets').mkdir(parents=True);updates.mkdir();tool.mkdir();f=project/'Assets/a.cs';f.write_bytes(b'class A {}');tf=tool/'recover.py';tf.write_bytes(b'pass\n')
            m={'schema':'reviewed-Unity-code-only-publication-inputs/v1','project':str(project),'files':[{'path':'Assets/a.cs','bytes':f.stat().st_size,'sha256':p.sha(f)}],'count':1,'bytes':f.stat().st_size,'exclude_all_unlisted':True,'includes_original_metas':True};mp=base/'code.json';mp.write_text(json.dumps(m))
            rm={'schema':'reviewed-recovery-source-publication-inputs/v1','source_directory':str(tool),'destination_prefix':'tools/recovery/','files':[{'path':'tools/recovery/recover.py','source':str(tf),'bytes':tf.stat().st_size,'sha256':p.sha(tf)}],'count':1,'bytes':tf.stat().st_size,'exclude_all_unlisted':True,'only_py_cs_source':True};rp=base/'recovery.json';rp.write_text(json.dumps(rm))
            cfg={'project_root':'project','updates_root':'updates','manifest':'code.json','manifest_sha256':p.sha(mp),'reviewed_manifest_sha256':p.sha(mp),'recovery_manifest':'recovery.json','recovery_manifest_sha256':p.sha(rp),'reviewed_recovery_manifest_sha256':p.sha(rp)};cp=base/'config.json';cp.write_text(json.dumps(cfg));_,_,_,_,rows=p.load_inputs(cp)
            self.assertEqual(len(rows),2);repo=base/'repo';repo.mkdir();p.sync_scope(project,rows,{},repo);self.assertEqual((repo/'tools/recovery/recover.py').read_bytes(),tf.read_bytes())
            tf.write_bytes(b'changed')
            with self.assertRaises(p.Stop):p.load_inputs(cp)
    def test_snapshot_must_match_review(self):
        with tempfile.TemporaryDirectory() as d:
            base=Path(d);value={'schema':'SolarNet-reviewed-source-code-snapshot/v1','count':0,'files':[]};(base/'SOURCE_SNAPSHOT.json').write_text(json.dumps(value))
            with self.assertRaises(p.Stop):p.check_snapshots(base,{'Assets/a.cs':{'bytes':1,'sha256':'0'*64}})
    def test_actual_windows_clone_root_remote_and_branch_readonly(self):
        # These are the only real Git calls in this suite; all are read-only.
        for root,url in ((p.ROOT,p.SOURCE_URL),(p.ROOT.parent/'SolarNet-updates',p.UPDATES_URL)):
            git=p.Git(root,url);self.assertEqual(Path(git.run(['rev-parse','--show-toplevel']).decode().strip()).resolve(),root.resolve())
            self.assertEqual(git.run(['remote','get-url','--all','origin']).decode().splitlines(),[url]);self.assertEqual(git.run(['symbolic-ref','--short','HEAD']).decode().strip(),'main')

if __name__=='__main__':unittest.main(verbosity=2)
