"""Compare original native-derived provider scope and current restored scope, as data."""
from pathlib import Path
import datetime as dt,importlib.util,json,mmap,uuid
HERE=Path(__file__).resolve().parent;sp=importlib.util.spec_from_file_location('hashable',HERE/'audit_hashable_scoped_vtable.py');h=importlib.util.module_from_spec(sp);sp.loader.exec_module(h)
def main():
 plan=json.loads(h.PLAN.read_text());root=h.m.ROOT;paths=[('modern_raw_original',root/'ScriptRecoveryModern/Attempt-20261022T013537Z-ae9c0c99/Output/Assembly-CSharp.dll'),('AR_Aux_original',root/'Attempt-20261022T011039Z-e4251f74/Export/AuxiliaryFiles/GameAssemblies/Assembly-CSharp.dll'),('old2022_original_metadata',root/'ScriptRecovery/Attempt-20261022T010255Z-f74fcb76/InitialAssemblies/Assembly-CSharp.dll'),('restored_current_core',Path(plan['core']))];rows=[]
 for role,path in paths:
  digest=h.m.sha(path)
  with path.open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
   c=h.m.cli.Cli(b);r=h.Read(c);types=[]
   for rid in range(1,c.rows[2]+1):
    name=r.definition(rid)
    if name not in h.NAMES:continue
    methods=[m for m in r.methods(rid) if m['name']=='AppendToHash'];types.append({'type':name,'methods':methods})
   rows.append({'role':role,'path':str(path),'sha256':digest,'types':types})
  h.m.need(h.m.sha(path)==digest,'Evidence input drift')
 out=root/'Validation'/('HashableOriginalScope-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();report={'schema':'original-provider-versus-restored-core-full-scope-evidence/v1','sources':rows,'native_original_metadata_or_CLI_tables_read_only':True,'game_code_invoked':False,'project_changed':False};rp=out/'report.json';rp.write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':h.m.sha(rp),'scopes':[(x['role'],[(t['type'],[m['signature']['parameters'] for m in t['methods']]) for t in x['types'] if t['methods']]) for x in rows]}))
if __name__=='__main__':main()
