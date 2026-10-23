"""Guarded production-reader fixtures; no recovered game/SDK execution."""
import ast,ctypes,datetime as dt,importlib.util,json,os,shutil,struct,subprocess,time,uuid
from ctypes import wintypes
from pathlib import Path
HERE=Path(__file__).resolve().parent;WS=HERE.parents[2];ROOT=WS/'Recovery/RecRoom-2023-04-18'
spec=importlib.util.spec_from_file_location('guard',HERE.parent/'CompilerPropertyProjection/run_guarded.py');g=importlib.util.module_from_spec(spec);spec.loader.exec_module(g)
node=next(n for n in ast.parse((HERE/'compile_official_steamworks14.py').read_text()).body if isinstance(n,ast.FunctionDef) and n.name=='phase');exec(compile(ast.Module(body=[node],type_ignores=[]),'bounded-phase','exec'))
PLAN=ROOT/'CompilerRepairs/GeneralManifestStreamingCandidate-20261022T174037Z-6ace54f2/candidate-plan.json'

def need(value,message):
 if not value:raise ValueError(message)

def fixture():
 data=bytearray();positions={}
 def i(n):data.extend(struct.pack('<i',n))
 def count(k,n):positions[k]=len(data);i(n)
 def s(value):
  b=value.encode();n=len(b)
  while n>=128:data.append((n&127)|128);n>>=7
  data.append(n);data.extend(b)
 def strings(value):i(len(value));[s(x) for x in value]
 def many(n):
  for j in range(n):s('SyntheticValue'+str(j)+'_Ω😀')
 s('RR23-METADATA-RESTORE-6');s('FixtureCore_Ω😀');many(4);data.append(0);count('strings',1);s('SyntheticExcluded')
 count('types',1);many(3)
 count('methods',1);many(8);strings(['!0;'])
 count('fields',1);many(6)
 count('definitions',1);many(2);i(1);i(1)
 i(1);many(2);i(147);i(0);i(0)
 i(1);many(4);i(275)
 i(1);many(4);strings(['!0;']);strings(['!0;']);i(0)
 i(1);many(4);i(0)
 count('readonly',1);many(7);strings(['!0;']);many(3)
 i(0x02000001);i(0x17000001);i(0x06000001);count('blob',3);data.extend(bytes([1,0,255]));data.extend(bytes([1,0]))
 count('unrecovered',1);many(3);i(0x06000002);i(147);i(0);i(0);s('explicit-missing-synthetic')
 count('adapters',1);many(6)
 count('added_ctors',1);many(2)
 count('empty_externs',1);many(4);i(0x06000003);i(8337);i(128);i(0)
 count('serialization_witnesses',1);many(4);i(0x04000001);i(0x04000002);i(0x04000003);i(0x02000001)
 return bytes(data),positions

def main():
 out=ROOT/'Validation'/('GeneralManifestStreamingFixtures-'+dt.datetime.now(dt.timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir()
 report={'schema':'minimal-GeneralManifest-streaming-production-reader-fixtures/v1','phases':[],'project_modified':False,'game_or_SDK_code_executed':False,'fixture_checks':[]}
 try:
  plan=json.loads(PLAN.read_text())
  for key in ('baseline','candidate','original_CodeGen','GeneralManifest'):
   need(g.sha(plan[key]['path'])==plan[key]['sha256'],'Pinned candidate/input changed: '+key)
  old=Path(plan['baseline']['path']).read_bytes();new=Path(plan['candidate']['path']).read_bytes()
  old_block=b'            using (var stream = new MemoryStream(Resource("RR23.GeneralManifest"))) manifest = WholeMetadataManifest.Read(stream);'
  nl=b'\r\n' if b'\r\n' in old else b'\n'
  new_block=nl.join([b'            using (var stream = typeof(WholeMetadataRestorer).Assembly.GetManifestResourceStream("RR23.GeneralManifest"))',b'            {',b'                if (stream == null) throw new InvalidDataException("Missing pinned resource: RR23.GeneralManifest");',b'                manifest = WholeMetadataManifest.Read(stream);',b'            }'])
  need(old.count(old_block)==1 and new==old.replace(old_block,new_block),'Candidate changes exceed exact one block')
  payload,positions=fixture();cases={'Valid':payload,'WrongSchema':bytes([payload[0]])+b'X'+payload[2:],'Truncated':payload[:-1],'TrailingByte':payload+b'\0'}
  for name,key,value in [('NegativeTypeCount','types',-1),('TooManyTypes','types',100001),('NegativeStringCount','strings',-1),('TooManyStrings','strings',1001),('NegativeBlobCount','blob',-1),('TooLargeBlobCount','blob',65537)]:
   changed=bytearray(payload);struct.pack_into('<i',changed,positions[key],value);cases[name]=bytes(changed)
  cases['TruncatedBlob']=payload[:positions['blob']+4+2]
  for name,value in cases.items():(out/(name+'.bin')).write_bytes(value)
  codegen=Path(plan['original_CodeGen']['path']);shutil.copyfile(codegen,out/codegen.name)
  editor=WS/'Tools/Editors/2020.3.33f1/Editor';framework=editor/'Data/MonoBleedingEdge/lib/mono/4.7.1-api'
  for name in ('Unity.Cecil.dll','Unity.CompilationPipeline.Common.dll'):
   source=editor/'Data/Managed'/name
   if source.exists():shutil.copyfile(source,out/name)
  compiler=editor/'Data/Tools/Roslyn/csc.exe';target=out/'ManifestStreamingFixtures.exe';refs=[framework/'mscorlib.dll',framework/'System.dll',framework/'System.Core.dll',out/codegen.name]
  rsp=out/'fixture.rsp';rsp.write_text('\n'.join(['/nologo','/nostdlib+','/target:exe','/optimize+','/langversion:8','/out:"'+str(target)+'"']+['/reference:"'+str(p)+'"' for p in refs]+['/resource:"'+str(out/(name+'.bin'))+'",Fixture.'+name for name in cases]+['"'+str(HERE/'ManifestStreamingFixtures.cs')+'"'])+'\n')
  phase([compiler,'/noconfig','@'+str(rsp)],out,'compile-trusted-production-reader-fixtures',report,cap=.25,seconds=30)
  mono=editor/'Data/MonoBleedingEdge/bin/mono.exe';tiny=out/'synthetic-checks.json';phase([mono,target,str(len(payload)),tiny],out,'production-reader-resource-negatives-and-short-reads',report,cap=.125,seconds=30)
  tiny_result=json.loads(tiny.read_text());need(tiny_result['status']=='passed' and tiny_result['checks']==17,'Synthetic fixture count/status differs')
  report['fixture_checks']=['copied-vs-direct-full-V6-record-semantics','all11-record-kinds','short-reads1','short-reads3','short-reads7','wrong-schema','negative-type-count','too-many-types','negative-string-count','too-many-strings','negative-blob-count','too-large-blob-count','truncated-blob','trailing-byte','truncated-final-value','missing-resource','nonseekable-strict-end-refusal']
  for mode in ('legacy','direct'):
   phase([mono,target,'--full',mode,out/('full-'+mode+'.json')],out,'actual43088714B-manifest-'+mode,report,cap=.25,seconds=60)
  legacy=json.loads((out/'full-legacy.json').read_text());direct=json.loads((out/'full-direct.json').read_text());need(legacy['status']==direct['status']=='passed' and all(legacy[k]==direct[k] for k in ('model_sha256','model_values','exact_byte_consumption','types','methods','fields','definitions')),'Actual full manifest semantic/consumption mismatch')
  report.update(status='passed',candidate_sha256=plan['candidate']['sha256'],baseline_sha256=plan['baseline']['sha256'],candidate_plan={'path':str(PLAN),'sha256':g.sha(PLAN)},production_reader_unchanged=True,exact_all4_embedded_resources=plan['embedded_manifest_payload_exactly_equals_pinned_input'] and len(plan['actual_embedded_resources'])==4,all4_embedded_resources=plan['actual_embedded_resources'],production_reader_source={'path':str(Path(plan['baseline']['path']).with_name('WholeManifest.cs')),'sha256':g.sha(Path(plan['baseline']['path']).with_name('WholeManifest.cs'))},fixture_source={'path':str(HERE/'ManifestStreamingFixtures.cs'),'sha256':g.sha(HERE/'ManifestStreamingFixtures.cs')},check_count=17,full_actual_manifest={'legacy':legacy,'direct':direct,'separate_owned_processes_no_two_graphs_retained':True},copied_codegen_sha256=g.sha(out/codegen.name),old_block_hex=old_block.hex(),new_block_hex=new_block.hex())
 except BaseException as error:report.update(status='failed',error=str(error))
 finally:
  (out/'report.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps({'report':str(out/'report.json'),'status':report['status'],'error':report.get('error')}),flush=True)

if __name__=='__main__':main()
