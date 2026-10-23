"""Static installed-worker architecture and first resource-allocation evidence."""
from pathlib import Path
import datetime as dt, hashlib, importlib.util, json, mmap, os, struct, uuid
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('cli',HERE/'audit_cli_marshal_contracts.py');cli=importlib.util.module_from_spec(spec);spec.loader.exec_module(cli)

def record(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  while data:=f.read(65536):h.update(data)
 return {'path':str(p),'sha256':h.hexdigest()}

def architecture(p):
 with p.open('rb')as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ)as b:
  u16=lambda a:struct.unpack_from('<H',b,a)[0];u32=lambda a:struct.unpack_from('<I',b,a)[0]
  pe=u32(60);opt=pe+24;magic=u16(opt);directory=opt+(112 if magic==0x20b else 96);clr=u32(directory+14*8);flags=None;mvid=None
  if clr:
   c=cli.Cli(b);flags=c.u32(c.raw(clr,72)+16);a=c.row(0,1);index=c.value(a+2+c.strw,c.guidw);a=c.streams['#GUID'][0]+(index-1)*16;mvid=str(uuid.UUID(bytes_le=bytes(b[a:a+16])))
  return dict(record(p),machine=hex(u16(pe+4)),PE_optional_magic=hex(magic),large_address_aware=bool(u16(pe+22)&0x20),CLR_flags=hex(flags)if flags is not None else None,MVID=mvid)

def main():
 editor=WS/'Tools/Editors/2020.3.33f1/Editor';core=editor/'Data/Managed/UnityEngine/UnityEditor.CoreModule.dll';methods=[]
 with core.open('rb')as f,mmap.mmap(f.fileno(),0,access=mmap.ACCESS_READ)as b:
  c=cli.Cli(b)
  for rid,name in [(0x7ff4,'PostProcessorTask.Start'),(0x7d0c,'ManagedProgram..ctor'),(0x7b00,'MonoInstallationFinder.GetMonoInstallation')]:
   a=c.row(6,rid);at=c.raw(c.u32(a),1);lead=b[at];header=1 if lead&3==2 else(c.u16(at)>>12)*4;length=lead>>2 if lead&3==2 else c.u32(at+4);body=bytes(b[at+header:at+header+length]);methods.append({'name':name,'provider_cli_token':hex(0x6000000|rid),'IL_hex':body.hex(),'IL_sha256':hashlib.sha256(body).hexdigest()})
  literal_presence={x:b.find(x.encode('utf-16le'))>=0 for x in ['MONO_GC_PARAMS','max-heap-size=','--gc-params']}
 base=ROOT/'Validation/ActualUnityCodeCompile-20261022T172617Z-e30f5991';source=base/'Project/Assets/Editor/OriginalMetadataRestoration';fixtures=ROOT/'Validation/GeneralManifestStreamingFixtures-20261022T174453Z-52e4d254/report.json';fixture=json.loads(fixtures.read_text())
 paths=[editor/'Data/Tools/ILPostProcessorRunner/ILPostProcessorRunner.exe',editor/'Data/MonoBleedingEdge/bin/mono.exe',editor/'Data/MonoBleedingEdge/bin/mono-2.0-sgen.dll',editor/'Data/MonoBleedingEdge/EmbedRuntime/mono-2.0-sgen.dll']
 report={'schema':'actual-Unity2020-ILPP-static-memory-evidence/v1','status':'completed','project_modified':False,'managed_child_launched_by_this_audit':False,
  'inputs':[record(p)for p in [core,base/'Editor.log',source/'WholeMetadataRestorer.cs',source/'WholeManifest.cs',source/'MetadataRoundTripSafety.cs',source/'ExactMetadataReferenceResolver.cs',fixtures]],
  'architecture':[architecture(p)for p in paths],
  'launch_producer_IL':methods,
  'launch_interpretation':'PostProcessorTask.Start passes GetMonoInstallation("MonoBleedingEdge"), null Mono arguments and null additional environment to ManagedProgram; that constructor builds root/bin/mono and appends .exe on WindowsEditor. Native mono.exe imports x86mono-2.0-sgen.dll including mono_main/mono_parse_env_options. This chain is32-bit non-LAA even with64-bit Editor; JobObject cap does not expand its address space.',
  'actual_worker_command_line':'Not recorded; CIM read denied. Installed launch producer IL is preserved above; no runtime swap performed.',
  'heap_configuration':{'literal_presence_in_UnityEditor_CoreModule':literal_presence,'explicit_ManagedProgram_environment_names':['MONO_PATH','MONO_CFG_DIR'],'Mono_arguments_passed_by_PostProcessorTask':'null','local_Codex_finite_GC_knobs_present':{k:k in os.environ for k in ['MONO_GC_PARAMS','MONO_GC_DEBUG','MONO_ENV_OPTIONS','MONO_RUNTIME_OPTIONS']},'actual_worker_inherited_GC_environment':'Not captured; no absence claim.','GC_parameters_changed':False},
  'observed_failure':{'first_site':'Resource(RR23.GeneralManifest) / MemoryStream.EnsureCapacity','ILPP_elapsed_seconds':0.081451,'manifest_parser_reached':False,'aggregate_metadata_checks_reached':False,'job_limit_bytes':1879048192,'last_sample_editor_private_bytes':584159232,'worker_or_total_job_peak_not_recorded':True},
  'matching_mscorlib_copy_model':{'MVID':'695d1cc9-3cca-4506-9c52-8c15c9fdd749','manifest_length':43088714,'CopyTo_default_block':81920,'final_doubling_capacity':83886080,'prior_growth_buffer':41943040,'capacity_plus_ToArray_bytes':126974794,'growth_peak_new_plus_prior_plus_copybuffer':125911040,'unrooted_prior_buffers_may_be_collected':True},
  'minimal_fix_validation':{'report':record(fixtures),'status':fixture['status'],'check_count':fixture['check_count'],'full_actual_manifest':fixture['full_actual_manifest'],'candidate_sha256':fixture['candidate_sha256'],'old_peak_private_bytes':fixture['phases'][-2]['peak_private_bytes'],'direct_peak_private_bytes':fixture['phases'][-1]['peak_private_bytes']},
  'other_lifetimes_not_changed':['Raw/serialization resources remain copied and hash checked; their bytes/modules live until Restore exits.','Resolver validates225curated paths but loads Cecil reference models on demand; all are disposed with resolver. Do not weaken identity checks or presume all225 are eager models.','Aggregate Fingerprint builds whole-assembly StringBuilder then UTF16string then UTF8bytearray; later transient hotspot, not this first-copy failure. Exact-byte streaming could preserve the same aggregate but is deliberately deferred.','IL/PDB identity and normalized snapshots coexist with reread module; every strict contract remains in place.','No pooling/fingerprint/GC/runtime/input/resource changes are in this first candidate.']}
 out=ROOT/'Validation'/('CodeGenMemoryStaticAudit-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();(out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'GC_literals':literal_presence}))

if __name__=='__main__':main()
