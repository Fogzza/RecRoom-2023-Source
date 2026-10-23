"""Bounded source-only rebase; every byte outside one JSON array is preserved."""
import ctypes,datetime as dt,hashlib,importlib.util,json,os,shutil,subprocess,time,uuid
from pathlib import Path
from ctypes import wintypes
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
def need(value,why):
 if not value:raise ValueError(why)
def phase(command,out,label,report,cap=192*1024**2):
 reserve=int(1.5*g.GIB);need(g.memory().available_commit>=cap+reserve,'Bounded rebase helper admission')
 api=ctypes.WinDLL('psapi',use_last_error=True);api.GetProcessMemoryInfo.argtypes=[wintypes.HANDLE,ctypes.POINTER(g.ProcessMemory),wintypes.DWORD];api.GetProcessMemoryInfo.restype=wintypes.BOOL;child=None;start=time.monotonic();row={'phase':label,'maximum_private_bytes':cap,'minimum_commit_bytes':reserve,'maximum_seconds':60};report['phases'].append(row)
 try:
  with (out/(label+'.log')).open('xb') as log:
   child=subprocess.Popen([str(x) for x in command],stdout=log,stderr=subprocess.STDOUT,cwd=out,creationflags=subprocess.CREATE_NO_WINDOW,env=dict(os.environ,DOTNET_PROCESSOR_COUNT='1'));row['owned_pid']=child.pid
   while child.poll() is None:
    p=g.ProcessMemory();p.cb=ctypes.sizeof(p);need(api.GetProcessMemoryInfo(wintypes.HANDLE(int(child._handle)),ctypes.byref(p),p.cb),'Owned helper memory query');row['peak_private_bytes']=max(row.get('peak_private_bytes',0),p.PrivateUsage)
    need(p.PrivateUsage<=cap and g.memory().available_commit>=reserve and time.monotonic()-start<=60 and shutil.disk_usage(out).free>=4*g.GIB,'Owned helper memory/commit/time/disk guard');time.sleep(.1)
  row['exit_code']=child.returncode;need(child.returncode==0,label+' failed')
 finally:
  if child is not None and child.poll() is None:child.kill();child.wait(timeout=10);row['owned_child_terminated']=True
  row['seconds']=round(time.monotonic()-start,3)
def main():
 out=ROOT/'Validation'/('BodySourceStreamRebase-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'streamed-whole-source-body-rebase/v1','phases':[],'project_modified':False,'game_code_executed':False}
 try:
  old=ROOT/'CompilerRepairs/RuntimeSourcePlacementProjection-20261022T104037Z-a6651f58/metadata-restoration.json';partial=ROOT/'Validation/BodySourceProjection-20261022T144115Z-5a339b18/Projection/metadata-restoration.json';journal=ROOT/'NativeGameplayRepairs/AppliedBodyBatch-20261022T143919Z-d8d0e6b3/journal.json';p=json.loads(partial.read_text());a=json.loads(journal.read_text());need(g.sha(old)=='134970adfa7af635a99deedda72411104f1ea96618ad05d3c8a50e3f4655e1f1' and g.sha(partial)=='56abd366d0a44535be53581b90a4d090fa5ec3ddbbe756f673c352869757f159','Pinned full/partial source plans required')
  caller_path=ROOT/'Validation/BodyCallerRepairs-20261022T150206Z-a5577583/source-reports.json';caller=json.loads(caller_path.read_text());need(caller['schema']=='three-current-body-compiler-source-reports/v1','Strict three-source caller proof required');replacements={r['project_relative_path']:{k:r[k] for k in ('project_relative_path','original_sha256','candidate_path','candidate_sha256')} for r in caller['source_reports']};need(len(replacements)==3 and a['status']=='applied' and a['method_bodies']==7,'Exact seven-body/three-syntax-projection rebase required');pairs=[]
  for row in a['rows']:
   current=Path(row['source']);need(g.sha(current)==row['after_sha256'] and g.sha(Path(str(current)+'.meta'))==row['meta_sha256'],'Applied body or GUID changed');rel=current.relative_to(WS/'RR23');candidate=Path(replacements[str(rel).replace('\\','/')]['candidate_path']) if str(rel).replace('\\','/') in replacements else current
   pairs.append({'before':str(ROOT/'Validation/ActualUnityCodeCompile-20261022T124157Z-933539fe/Project'/rel),'after':str(candidate)})
  pairs_path=out/'source-pairs.json';pairs_path.write_text(json.dumps(pairs,indent=2)+'\n');source=HERE/'VerifyBodyDeclarations.cs';target=out/'VerifyBodyDeclarations.dll';roslyn=[g.SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.dll',g.SDK/'Roslyn/bincore/Microsoft.CodeAnalysis.CSharp.dll'];rsp=out/'helper.rsp';rsp.write_text('\n'.join(['/nologo','/target:exe','/out:"'+str(target)+'"']+['/reference:"'+str(x)+'"' for x in sorted(g.REF.glob('*.dll'))+roslyn]+['"'+str(source)+'"'])+'\n');phase([g.DOTNET,g.SDK/'Roslyn/bincore/csc.dll','/noconfig','@'+str(rsp)],out,'compile-declaration-checker',report)
  for library in roslyn:shutil.copyfile(library,out/library.name)
  target.with_suffix('.runtimeconfig.json').write_text(json.dumps({'runtimeOptions':{'tfm':'net10.0','framework':{'name':'Microsoft.NETCore.App','version':'10.0.11'}}}));declarations=out/'declarations.json';phase([g.DOTNET,target,pairs_path,declarations],out,'prove-unchanged-compiler-declarations',report)
  target_plan=out/'metadata-restoration.json';outside=hashlib.sha256();new_outside=hashlib.sha256();found=False;count=0;validation_count_updates=0
  with old.open('rb') as reader,target_plan.open('xb') as writer:
   for line in reader:
    need(len(line)<=2*1024**2,'Bounded JSON line required')
    if line.rstrip(b'\r\n')==b'  "source_replacements": [':
     need(not found,'Unique source replacement array required');found=True;writer.write(line);outside.update(line);new_outside.update(line);buffer=bytearray(b'[')
     for nested in reader:
      need(len(buffer)+len(nested)<=8*1024**2,'Bounded source replacement array required')
      if nested.rstrip(b'\r\n')==b'  ],':closing=nested;buffer.extend(b']');break
      buffer.extend(nested)
     else:raise ValueError('Unterminated source replacement array')
     rows=json.loads(buffer);used=set();applied_by_rel={str(Path(r['source']).relative_to(WS/'RR23')).replace('\\','/'):r for r in a['rows']}
     for index,row in enumerate(rows):
      key=row['project_relative_path']
      if key in replacements:
       need(key not in used and row['original_sha256']==applied_by_rel[key]['before_sha256'] and replacements[key]['original_sha256']==applied_by_rel[key]['after_sha256'],'Source replacement original/after hashes must match actual body transaction');used.add(key);rows[index]=replacements[key]
     need(len(rows)==2290 and set(replacements)-used=={'Assets/Scripts/Assembly-CSharp/RecRoom/ReviveButton.cs'},'Only the new direct Revive caller may add a source replacement');rows.append(replacements['Assets/Scripts/Assembly-CSharp/RecRoom/ReviveButton.cs']);need(len(rows)==2291,'Full source replacement count must be2291');count=len(rows);encoded=json.dumps(rows,indent=2,ensure_ascii=True).splitlines();newline=b'\r\n' if line.endswith(b'\r\n') else b'\n';writer.write(newline.join(('  '+s).encode() for s in encoded[1:-1])+newline);writer.write(closing);outside.update(closing);new_outside.update(closing);continue
    if line.rstrip(b'\r\n')==b'    "candidate_files": 2290,':
     validation_count_updates+=1;writer.write(line.replace(b'2290',b'2291'));continue
    writer.write(line);outside.update(line);new_outside.update(line)
  need(found and validation_count_updates==1 and outside.digest()==new_outside.digest(),'All bytes outside source replacement array and its exact count must be preserved');report.update(status='passed',source_replacements=count,updated_replacements=sorted(replacements),outside_array_and_count_sha256=outside.hexdigest(),validation_candidate_count_change='2290 ->2291; one original direct-source caller now needs compiler-only spelling',all_other_metadata_bytes_unchanged=True,declaration_proof={'path':str(declarations),'sha256':g.sha(declarations)},source_application={'path':str(journal),'sha256':g.sha(journal)},projection={'path':str(target_plan),'sha256':g.sha(target_plan)},inputs=[{'path':str(x),'sha256':g.sha(x)} for x in (old,partial,source,journal,caller_path)],method_bodies=7,whole_assembly_coverage_preserved=True)
 except BaseException as error:report.update(status='failed',error=repr(error))
 finally:(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'projection':report.get('projection'),'error':report.get('error')}),flush=True)
 return 0 if report['status']=='passed' else 1
if __name__=='__main__':raise SystemExit(main())
