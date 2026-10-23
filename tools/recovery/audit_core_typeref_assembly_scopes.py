"""Inventory original-vs-restored TypeRef full assembly scopes; no runtime loads."""
from pathlib import Path
from collections import Counter,defaultdict
import datetime as dt,hashlib,importlib.util,json,mmap,uuid
HERE=Path(__file__).resolve().parent;sp=importlib.util.spec_from_file_location('h',HERE/'audit_hashable_scoped_vtable.py');h=importlib.util.module_from_spec(sp);sp.loader.exec_module(h)
def read(path):
 digest=h.m.sha(path)
 with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
  c=h.m.cli.Cli(b);r=h.Read(c);rows=[]
  for rid in range(1,c.rows[1]+1):
   full=r.typeref(rid);h.m.need(full.startswith('[') and ']' in full,'Scoped TypeRef format');scope,name=full[1:].split(']',1);rows.append({'token':hex(0x01000000|rid),'name':name,'assembly_full_name':scope})
 h.m.need(h.m.sha(path)==digest,'Input changed');return {'path':str(path),'sha256':digest,'references':rows}
def main():
 root=h.m.ROOT;p=json.loads(h.PLAN.read_text());raw=read(root/'ScriptRecoveryModern/Attempt-20261022T013537Z-ae9c0c99/Output/Assembly-CSharp.dll');actual=read(Path(p['core']));by=defaultdict(list)
 for r in raw['references']:by[r['name']].append(r)
 exact=[];different=[];ambiguous=[];extra=[]
 for cur in actual['references']:
  candidates=by.get(cur['name'],[]);scopes={r['assembly_full_name'] for r in candidates}
  if cur['assembly_full_name'] in scopes:exact.append(cur)
  elif len(scopes)==1:different.append({'actual':cur,'original_scope':next(iter(scopes)),'original_reference_tokens':[r['token'] for r in candidates]})
  elif scopes:ambiguous.append({'actual':cur,'original_scope_candidates':sorted(scopes)})
  else:extra.append(cur)
 counter=Counter((r['original_scope'],r['actual']['assembly_full_name']) for r in different);out=root/'Validation'/('CoreTypeRefAssemblyScopes-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'scoped-TypeRef-identity-original-versus-current-core/v1','status':'audit_only_no_changes','original':{'path':raw['path'],'sha256':raw['sha256'],'type_refs':len(raw['references'])},'actual':{'path':actual['path'],'sha256':actual['sha256'],'type_refs':len(actual['references'])},'counts':{'exact_scope':len(exact),'unique_original_scope_mismatch':len(different),'ambiguous_original_scopes':len(ambiguous),'no_original_same_name':len(extra)},'scope_changes':[{'original':k[0],'actual':k[1],'type_ref_rows':v} for k,v in counter.most_common()],'scope_mismatches':different,'ambiguous':ambiguous,'extra':extra,'identity_scope_aliases_applied':False,'original_input_or_project_changed':False,'runtime_code_invoked':False};rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':h.m.sha(rp),'counts':report['counts'],'scope_changes':report['scope_changes']}))
if __name__=='__main__':main()
