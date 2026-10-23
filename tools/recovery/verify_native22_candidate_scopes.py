"""Independent fail-closed scope-only acceptance. Never loads candidate managed code.

API compare_candidate(candidate, expected_sha256) accepts only a hash-pinned file.
This proves TypeRef/full AssemblyName scope invariants, not whole IL/PDB equivalence.
"""
from pathlib import Path
from collections import Counter
import datetime as dt,importlib.util,json,mmap,sys,uuid
HERE=Path(__file__).resolve().parent
sp=importlib.util.spec_from_file_location('h',HERE/'audit_hashable_scoped_vtable.py');h=importlib.util.module_from_spec(sp);sp.loader.exec_module(h)
ROOT=h.m.ROOT
WITNESS=ROOT/'Validation/NativeFrameworkAssemblyScopes-20261022T154947Z-0d359b85/report.json'
WITNESS_SHA='8b3b7e9c03fc158d04ecbac21f280be433fed4deab9f7745efe1a55d88d3fac8'
BASE_SHA='6c8d11c850180380b6523b4d38416cac687f09428ac339b1859456081e7326cc'
def read(path):
 with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
  c=h.m.cli.Cli(b);r=h.Read(c);refs=[]
  for rid in range(1,c.rows[1]+1):
   full=r.typeref(rid);h.m.need(full.startswith('[') and ']' in full,'Malformed scope rendering');scope,name=full[1:].split(']',1);refs.append((name,scope))
  assembly_refs=[]
  for rid in range(1,c.rows[35]+1):
   row=h.m.identity(c,35,rid);assembly_refs.append((row['full_name'],row['flags']))
  return {'assembly':r.asm,'refs':refs,'assembly_refs':assembly_refs,'table_counts':c.rows}
def compare_candidate(candidate,expected_sha256):
 candidate=Path(candidate).resolve();h.m.need(len(expected_sha256)==64 and expected_sha256==expected_sha256.lower(),'Exact lowercaseSHA required');h.m.need(h.m.sha(WITNESS)==WITNESS_SHA,'Native witness drift');w=json.loads(WITNESS.read_text());p=Path(w['source_scope_audit']['path']);h.m.need(h.m.sha(p)==w['source_scope_audit']['sha256'],'Pinned originalscope audit drift');s=json.loads(p.read_text());baseline=Path(s['actual']['path']);h.m.need(h.m.sha(baseline)==BASE_SHA and s['actual']['sha256']==BASE_SHA,'Known original baseline drift');h.m.need(h.m.sha(candidate)==expected_sha256,'Candidate hash mismatch');before=read(baseline);after=read(candidate);h.m.need(before['assembly']==after['assembly'],'Core fullassembly identity drift')
 rows=w['rows'];h.m.need(len(rows)==22,'Exact22 witness count');mapping={row['current_TypeRef']['name']:(row['current_TypeRef']['assembly_full_name'],row['native_assembly']['full_name']) for row in rows};h.m.need(len(mapping)==22,'Unique native fulltypename map');expected=[];matched=[]
 for name,scope in before['refs']:
  if name in mapping:
   old,new=mapping[name];h.m.need(scope==old,'Unexpected baseline scope for native22');expected.append((name,new));matched.append(name)
  else:expected.append((name,scope))
 h.m.need(len(matched)==22 and len(set(matched))==22,'All22 baseline mappings exactlyonce');expected_counter=Counter(expected);actual_counter=Counter(after['refs']);missing=expected_counter-actual_counter;extra=actual_counter-expected_counter;h.m.need(not missing and not extra,'Candidate TypeRef multiset differs beyond exact22 native scopes: missing='+repr(list(missing.items())[:5])+' extra='+repr(list(extra.items())[:5]))
 old_asm=Counter(before['assembly_refs']);new_asm=Counter(after['assembly_refs']);removed=old_asm-new_asm;added=new_asm-old_asm;native_scopes={r['native_assembly']['full_name'] for r in rows};h.m.need(not removed,'Preexisting AssemblyRefs removed/changed');h.m.need(all(identity in native_scopes and flags==0 and count==1 for (identity,flags),count in added.items()),'Unexpected newAssemblyRef identity/flags/duplicates');h.m.need(h.m.sha(candidate)==expected_sha256 and h.m.sha(baseline)==BASE_SHA,'Evidence input changed')
 return {'schema':'independent-native22-TypeRef-full-identity-candidate-acceptance/v1','status':'passed_scope_only','candidate':{'path':str(candidate),'sha256':expected_sha256},'baseline':{'path':str(baseline),'sha256':BASE_SHA},'native_witness':{'path':str(WITNESS),'sha256':WITNESS_SHA},'validated_native_scope_rows':22,'total_TypeRef_rows_before':len(before['refs']),'total_TypeRef_rows_after':len(after['refs']),'all_other_TypeRef_rows_and_full_scopes_preserved':True,'preexisting_AssemblyRefs_preserved':True,'only_allowed_native_AssemblyRefs_added':[{'identity':identity,'flags':flags,'count':count} for (identity,flags),count in added.items()],'fallback_or_framework_identity_aliases_used':False,'whole_IL_PDB_other_metadata_equivalence_proven_by_this_scope_only_tool':False,'game_or_candidate_code_loaded_or_executed':False,'project_modified':False}
def main():
 h.m.need(len(sys.argv)==3,'Usage candidate.dll expectedSHA');out=ROOT/'Validation'/('Native22CandidateScopes-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 try:r=compare_candidate(sys.argv[1],sys.argv[2])
 except BaseException as e:r={'schema':'independent-native22-TypeRef-full-identity-candidate-acceptance/v1','status':'failed','candidate':str(Path(sys.argv[1]).resolve()),'error':repr(e),'candidate_code_loaded_or_executed':False}
 r['tool']={'path':str(Path(__file__).resolve()),'sha256':h.m.sha(Path(__file__).resolve())};rp=out/'report.json';rp.write_text(json.dumps(r,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':h.m.sha(rp),'status':r['status'],'error':r.get('error')}));return 0 if r['status']=='passed_scope_only' else 1
if __name__=='__main__':raise SystemExit(main())
