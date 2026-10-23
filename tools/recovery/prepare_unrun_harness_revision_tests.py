"""Derive tests that call actual versioned guards, plus never-launched controls."""
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];TOOLS=WS/'Recovery/RecRoom-2023-04-18/Tools'
def main():
 text=(TOOLS/'test_cached_harness_revision_fast.py').read_text();text=text.replace('import copy, importlib.util, json','import copy, importlib.util, json, tempfile').replace("'revise_cached_compile_harness_fast.py'","'revise_unrun_compile_harness_fast.py'").replace("old={'manifest':","old={'marshalling_overlay':{'resource':{'sha256':'f'}},'manifest':").replace("'cached-harness-revision-fast-fixtures.json'","'unrun-harness-revision-fixtures.json'")
 extra="""
 changed=copy.deepcopy(old);changed['marshalling_overlay']['resource']['sha256']='wrong';checks.append({'case':'reject fourth marshalling resource drift','rejected':rejected(lambda:mod.validate_new_integration(old,changed))})
 with tempfile.TemporaryDirectory(prefix='UnrunHarnessGuardFixture-',dir=mod.ROOT/'Validation') as td:
  base=Path(td).resolve();assert base.is_relative_to((mod.ROOT/'Validation').resolve());project=base/'Project';project.mkdir();preparation=base/'report.json';preparation.write_text('{}')
  mod.assert_unrun(preparation,project);checks.append({'case':'genuinely empty unrun tree admitted','passed':True})
  for name in mod.UNRUN_EVIDENCE_NAMES:
   path=base/name;path.write_text('synthetic evidence');checks.append({'case':'reject prior '+name,'rejected':rejected(lambda:mod.assert_unrun(preparation,project))});path.unlink()
  for rel in ('Library','Temp','Logs'):
   path=project/rel;path.mkdir();checks.append({'case':'reject prior Editor cache '+rel,'rejected':rejected(lambda:mod.assert_unrun(preparation,project))});path.rmdir()
  for rel in ('CompilerSupport/unity-compile-verification.txt','CompilerSupport/unity-signature-verification.json'):
   path=project/rel;path.parent.mkdir(exist_ok=True);path.write_text('synthetic marker');checks.append({'case':'reject old completion marker '+rel,'rejected':rejected(lambda:mod.assert_unrun(preparation,project))});path.unlink()
"""
 anchor=' # The fixtures never call prepare/apply or inspect live project paths.'
 if text.count(anchor)!=1:raise ValueError('Fixture anchor')
 text=text.replace(anchor,extra+'\n'+anchor);target=TOOLS/'test_unrun_harness_revision_fast.py'
 if target.exists():raise ValueError('Fresh fixture source only')
 compile(text,str(target),'exec');target.write_text(text);print(target)
if __name__=='__main__':main()
