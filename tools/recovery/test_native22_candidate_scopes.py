"""Apply byte mutations to ISOLATED candidate copies, then the production scope gate.
Never writes the candidate/project or loads target code. No compiler/runtime launch.
"""
from pathlib import Path
import datetime as dt,hashlib,importlib.util,json,struct,sys,uuid
HERE=Path(__file__).resolve().parent;sp=importlib.util.spec_from_file_location('gate',HERE/'verify_native22_candidate_scopes.py');g=importlib.util.module_from_spec(sp);sp.loader.exec_module(g)
def main():
 g.h.m.need(len(sys.argv)==3,'candidate expectedSHA');candidate=Path(sys.argv[1]).resolve();digest=sys.argv[2];positive=g.compare_candidate(candidate,digest);out=g.ROOT/'Validation'/('Native22ScopeControls-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();data=candidate.read_bytes();c=g.h.m.cli.Cli(data);r=g.h.Read(c);arefs={g.h.m.identity(c,35,i)['full_name']:i for i in range(1,c.rows[35]+1)};jit='System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089';aot='System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e';g.h.m.need(jit in arefs and aot in arefs,'Exact distinct JIT/AOTrefs required');scope_width=c.coded(2,[0,26,35,1]);types={r.typeref(i):i for i in range(1,c.rows[1]+1)};key='['+aot+']System.Security.Cryptography.IncrementalHash';target=c.row(1,types[key]);other=c.row(1,types['['+aot+']System.Collections.Generic.HashSet`1']);asm=c.row(35,arefs[aot]);mutations=[]
 def mut(name,offset,blob):
  changed=bytearray(data);changed[offset:offset+len(blob)]=blob;g.h.m.need(changed!=data,'Actual mutation required');path=out/(name+'.dll');path.write_bytes(changed);actual_sha=g.h.m.sha(path)
  try:g.compare_candidate(path,actual_sha)
  except ValueError as e:mutations.append({'name':name,'path':str(path),'sha256':actual_sha,'expected_rejection':str(e),'offset':offset,'original_hex':data[offset:offset+len(blob)].hex(),'mutation_hex':blob.hex()});return
  raise ValueError('Mutation incorrectly accepted: '+name)
 mut('native_scope_reverted_to_JIT',target,(arefs[jit]<<2|2).to_bytes(scope_width,'little'))
 mut('native_typeref_name_changed',target+scope_width,data[other+scope_width:other+scope_width+c.strw])
 mut('native_framework_version_changed',asm,struct.pack('<H',5))
 mut('unapproved_AssemblyRef_flag',asm+8,struct.pack('<I',0x100))
 try:g.compare_candidate(candidate,'0'*64)
 except ValueError as e:mutations.append({'name':'wrong_input_SHA','expected_rejection':str(e)})
 else:raise ValueError('Wronghash accepted')
 g.h.m.need(g.h.m.sha(candidate)==digest,'Original candidate changed');receipt={'schema':'independent-native22-scope-production-negative-controls/v1','status':'passed','positive_scope_proof':positive,'negative_controls':mutations,'negative_count':len(mutations),'all_mutated_hashes_passed_as_expected_hash_so_rejection_is_semantic_except_explicit_wrong_SHA_control':True,'candidate_or_project_modified':False,'code_or_game_assemblies_loaded_or_executed':False};rp=out/'report.json';rp.write_text(json.dumps(receipt,indent=2)+'\n');print(json.dumps({'report':str(rp),'sha256':g.h.m.sha(rp),'positive':True,'negatives':len(mutations)}))
if __name__=='__main__':main()
