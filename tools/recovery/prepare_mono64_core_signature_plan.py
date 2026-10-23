"""Prepare fixed-scope signature-probe sources/plan only. Never launches a host."""
from pathlib import Path
import datetime as dt,hashlib,importlib.util,json,mmap,uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18';ED=WS/'Tools/Editors/2020.3.33f1/Editor';BASE=ROOT/'Validation/AllOriginalScripts-20261022T145115Z-25a68695/CurrentManaged-150130Z-ca7f6fba';PLUGIN=ROOT/'NativeGameplayRepairs/RuntimePluginMonoCompatibility-20261022T100750Z/report.json';CORE=ROOT/'Validation/CurrentCoreMarshalRoundtrip-20261022T150805Z-97bb598a/ActualCurrentCoreOutput/Assembly-CSharp.dll';REFS=ROOT/'Validation/CurrentCoreMarshalRoundtrip-20261022T150805Z-97bb598a/exact-original-metadata-references.txt'
sp=importlib.util.spec_from_file_location('cli',HERE/'audit_cli_marshal_contracts.py');cli=importlib.util.module_from_spec(sp);sp.loader.exec_module(cli)
def need(b,s):
 if not b:raise ValueError(s)
def sha(p):
 with Path(p).open('rb') as f:return hashlib.file_digest(f,'sha256').hexdigest()
def asm(c):
 need(c.rows[32]==1,'Exactly one AssemblyDef required');at=c.row(32,1);return {'hash_algorithm':c.u32(at),'version':[c.u16(at+4+i*2) for i in range(4)],'flags':c.u32(at+12),'publickey_blob_hex':c.blob(c.value(at+16,c.blobw)).hex(),'name':c.string(c.value(at+16+c.blobw,c.strw)),'culture':c.string(c.value(at+16+c.blobw+c.strw,c.strw))}
def read(path):
 with Path(path).open('rb') as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ) as b:
  c=cli.Cli(b);a=asm(c);r=c.audit();return a,r
def main():
 out=ROOT/'Validation'/('Mono64CoreSignature-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();plugin=json.loads(PLUGIN.read_text());need(len(plugin['assemblies'])==225 and sha(PLUGIN)=='93d8e5f2db2943ccbe410472365a0a2b296790cd36c005a7e3bd15efb0492ae7','Exact normalized225 plugin plan changed');targets={r['assembly']+'.dll':r for r in plugin['assemblies']};firstpass=Path(REFS.read_text().splitlines()[0]);need(firstpass.name=='Assembly-CSharp-firstpass.dll' and firstpass.is_file(),'Exact compiler firstpass required');inventory=json.loads((BASE/'Inventory/report.json').read_text());rows=[];malformed=[];module_initializers=[]
 for record in inventory['modules']:
  name=record['image'];old=Path(record['path']);target=Path(targets[name]['candidate']) if name in targets else CORE if name=='Assembly-CSharp.dll' else firstpass if name=='Assembly-CSharp-firstpass.dll' else old;digest=sha(target)
  if name in targets:need(digest==targets[name]['candidate_sha256'],'Runtime plugin candidate changed')
  orig,_unused=read(old);identity,marshals=read(target);need(identity==orig,'Runtime assembly identity changed: '+name);bad=[{'kind':'parameter','method':r['method']['owner']['display_owner']+'.'+r['method']['name'],'sequence':r['sequence'],'flags':r['flags']} for r in marshals['flagged_parameters'] if r['malformed_flag_without_blob']]+[{'kind':'field','owner':r['owner']['display_owner'],'name':r['name'],'flags':r['flags']} for r in marshals['flagged_fields'] if r['malformed_flag_without_blob']]
  if bad:malformed.append({'image':name,'count':len(bad),'first':bad[:12]})
  with Path(record['type_inventory']).open() as f:
   module=next(json.loads(line) for line in f if json.loads(line)['full_name']=='<Module>')
  if module['methods']:module_initializers.append({'image':name,'module_method_count':module['methods']})
  need(sha(target)==digest,'Signature input changed during static gates');rows.append({'image':name,'path':str(target),'sha256':digest,'assembly_full_name':record['assembly_identity'],'role':'normalized_runtime_plugin' if name in targets else record['role'],'marshal_rows':len(marshals['FieldMarshal_rows']),'malformed_marshal_rows':len(bad)})
 plan={'schema':'fixed-matching-Mono64-safe-core-signature-probe-plan/v1','status':'static_dependency_gates_passed_source_generation_pending' if not malformed and not module_initializers else 'blocked_by_explicit_dependency_metadata_gaps','host_invoked':False,'core':str(CORE),'core_sha256':sha(CORE),'references':rows,'reference_count':len(rows),'plugin_count':225,'malformed_dependency_marshal_owners':malformed,'original_module_initializer_blockers':module_initializers,'probe_scope':'GetTypes and declared field/method/constructor/property/event signature metadata on core only; no game/vendor/PInvoke methods or custom attribute constructors, values, entry points or PlayMode.','planned_native_preload_policy':'Install exact FullName-to-absolutePath preload hook after matching corelib init; unknown name or wrong full identity immediately exits, no fallback directory search.','runtime':{'path':str(ED/'Data/MonoBleedingEdge/EmbedRuntime/mono-2.0-bdwgc.dll'),'sha256':sha(ED/'Data/MonoBleedingEdge/EmbedRuntime/mono-2.0-bdwgc.dll')},'inputs':[{'path':str(p),'sha256':sha(p)} for p in [PLUGIN,REFS,BASE/'Inventory/report.json']], 'project_or_harness_modified':False};(out/'plan.json').write_text(json.dumps(plan,indent=2)+'\n');print(json.dumps({'plan':str(out/'plan.json'),'status':plan['status'],'malformed_modules':len(malformed),'module_initializer_blockers':len(module_initializers)}))
if __name__=='__main__':main()
