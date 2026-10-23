"""Bounded local controls. No real commit, push, credential, or HTTP operation."""
import importlib.util
import json
from pathlib import Path
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
    def commit(self,*args):
        self.events.append(self.name+'_commit')
        if self.fail=='commit':self.fail=None;raise p.Stop('simulated_commit_failure')
        self.commits+=1;self.current=self.name+'1';return self.current
    def remote_head(self):return self.remote
    def push(self,commit):
        self.events.append(self.name+'_push')
        if self.fail=='push':self.fail=None;raise p.Stop('simulated_push_failure')
        self.remote=commit

class Controls(unittest.TestCase):
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
