"""Finite same-Editor metadata-only AOT resolver, no assembly identity aliases."""
import json,shutil,uuid
from pathlib import Path
from datetime import datetime,timezone
import prepare_marshalling_integration as p
BASE=p.ROOT/'CompilerRepairs/CurrentCoreNativeFrameworkScopes-20261022T155734Z-4d53f2ad'
PROOF=p.ROOT/'Validation/FiniteAOTFrameworkClosure-20261022T154113Z-e47f6b5a/report.json'
def main():
 proof=p.read(PROOF);p.need(proof['status']=='static_all_exact_identity_marshal_module_initializer_checks_passed','Pinned finite AOT proof');rows=proof['references'];p.need(len(rows)==3 and {r['image'] for r in rows}=={'System.dll','System.Core.dll','System.Xml.dll'},'Finite exact AOT3 required')
 for row in rows:p.pinned(Path(row['path']),row['sha256'])
 out=p.ROOT/'CompilerRepairs'/('CurrentCoreExactAOTScopes-'+datetime.now(timezone.utc).strftime('%Y%m%dT%H%M%SZ')+'-'+uuid.uuid4().hex[:8]);out.mkdir();shutil.copytree(BASE/'Package',out/'Package');shutil.copytree(BASE/'OriginalGaps',out/'OriginalGaps');(out/'ToolBuild').mkdir()
 for name in ('CurrentCoreChecks.cs','compile-checker.rsp','compile-codegen.rsp','proposed-project-csc.rsp','current-core-manifest.bin','proven-marshalling-overlay.bin','overlay-binding-proof.json'):
  src=BASE/name;dst=out/name
  if name.endswith(('.cs','.rsp','.json')):dst.write_text(src.read_text().replace(str(BASE),str(out)))
  else:shutil.copyfile(src,dst)
 plan=p.rebase(p.read(BASE/'stage-plan.json'),BASE,out)
 for row in plan['tool_dependencies']:p.pinned(Path(row['path']),row['sha256']);shutil.copyfile(row['path'],out/'ToolBuild'/Path(row['path']).name)
 folder=out/'Package/Assets/Editor/OriginalMetadataRestoration';shutil.copyfile(p.HERE/'ExactOriginalFrameworkScopes.cs',folder/'ExactOriginalFrameworkScopes.cs')
 generated='namespace RR23.MetadataRestoration { public static class OriginalFrameworkMetadataReferenceInputs { public static readonly CuratedFrameworkMetadataReference[] Values = new CuratedFrameworkMetadataReference[] {\n'
 for row in rows:generated+='new CuratedFrameworkMetadataReference('+','.join(json.dumps(v) for v in (row['image'],row['assembly_full_name'],row['sha256']))+'),\n'
 generated+='}; } }\n';(folder/'OriginalFrameworkMetadataReferenceInputs.cs').write_text(generated);(folder/'OriginalFrameworkMetadataReferenceInputs.cs.meta').write_text('fileFormatVersion: 2\nguid: '+uuid.uuid4().hex+'\n')
 file=folder/'ExactMetadataReferenceResolver.cs';text=file.read_text();text=p.replace_once(text,'public sealed class ExactMetadataReferenceResolver : IAssemblyResolver','public sealed class CuratedFrameworkMetadataReference { public readonly string FileName, FullName, Sha256; public CuratedFrameworkMetadataReference(string fileName,string fullName,string sha256) { FileName=fileName; FullName=fullName; Sha256=sha256; } }\n    public sealed class ExactMetadataReferenceResolver : IAssemblyResolver')
 text=p.replace_once(text,'readonly Dictionary<string, AssemblyDefinition> cache','readonly Dictionary<string,string> frameworkPaths = new Dictionary<string,string>(StringComparer.Ordinal);\n        readonly Dictionary<string, AssemblyDefinition> cache')
 old='public ExactMetadataReferenceResolver(IEnumerable<string> references, IEnumerable<CuratedRuntimeMetadataReference> curatedReferences)\n        {';new='public ExactMetadataReferenceResolver(IEnumerable<string> references, IEnumerable<CuratedRuntimeMetadataReference> curatedReferences) : this(references,curatedReferences,new CuratedFrameworkMetadataReference[0]) { }\n        public ExactMetadataReferenceResolver(IEnumerable<string> references, IEnumerable<CuratedRuntimeMetadataReference> curatedReferences, IEnumerable<CuratedFrameworkMetadataReference> frameworkReferences)\n        {';text=p.replace_once(text,old,new)
 needle='''            var curated=curatedReferences.ToArray();'''
 block='''            var frameworks=frameworkReferences.ToArray();
            if(frameworks.Length>3 || frameworks.Select(f=>f.FullName).Distinct(StringComparer.Ordinal).Count()!=frameworks.Length)throw new InvalidDataException("Ambiguous finite AOT framework metadata inventory");
            if(frameworks.Length!=0)
            {
                var roots=new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach(var input in suppliedPaths.Where(f=>Path.GetFileName(f)=="mscorlib.dll"))
                {
                    var profile=new DirectoryInfo(Path.GetDirectoryName(input));
                    if((profile.Name=="4.7.1-api"||profile.Name=="unityjit"||profile.Name=="unityaot") && profile.Parent!=null && profile.Parent.Name=="mono") roots.Add(profile.Parent.FullName);
                }
                if(roots.Count!=1)throw new InvalidDataException("One exact supplied matching-Editor Mono framework root required");
                foreach(var item in frameworks)
                {
                    if(!new[]{"System.dll","System.Core.dll","System.Xml.dll"}.Contains(item.FileName) || item.Sha256==null || item.Sha256.Length!=64 || item.Sha256.Any(c=>!((c>='0'&&c<='9')||(c>='a'&&c<='f'))))throw new InvalidDataException("Invalid finite AOT framework record");
                    string fullPath=Path.Combine(roots.Single(),"unityaot",item.FileName);if(!File.Exists(fullPath))throw new InvalidDataException("Exact AOT framework metadata missing");
                    string digest;using(var stream=File.OpenRead(fullPath))using(var sha=SHA256.Create())digest=BitConverter.ToString(sha.ComputeHash(stream)).Replace("-","").ToLowerInvariant();
                    if(digest!=item.Sha256)throw new InvalidDataException("Exact AOT framework metadata bytes changed");
                    using(var metadata=AssemblyDefinition.ReadAssembly(fullPath,new ReaderParameters { ReadSymbols=false }))if(metadata.Name.FullName!=item.FullName)throw new InvalidDataException("Exact AOT framework metadata identity changed");
                    frameworkPaths.Add(item.FullName,fullPath);
                }
            }
''';text=p.replace_once(text,needle,block+needle);text=p.replace_once(text,'if (!paths.TryGetValue(name.Name, out path)) throw new AssemblyResolutionException(name);','if (!frameworkPaths.TryGetValue(name.FullName,out path) && !paths.TryGetValue(name.Name, out path)) throw new AssemblyResolutionException(name);');file.write_text(text)
 file=folder/'WholeMetadataRestorer.cs';text=file.read_text();text=p.replace_once(text,'new ExactMetadataReferenceResolver(referencePaths, OriginalRuntimeMetadataReferenceInputs.Values)','new ExactMetadataReferenceResolver(referencePaths, OriginalRuntimeMetadataReferenceInputs.Values, OriginalFrameworkMetadataReferenceInputs.Values)');file.write_text(text)
 for name in ('compile-checker.rsp','compile-codegen.rsp'):
  file=out/name;file.write_text(file.read_text()+'"'+str(folder/'OriginalFrameworkMetadataReferenceInputs.cs')+'"\n')
 plan['exact_finite_AOT_framework_metadata']={'proof':p.pinned(PROOF),'files':[p.pinned(Path(r['path']),r['sha256']) for r in rows],'full_identities':[r['assembly_full_name'] for r in rows],'purpose':'metadata-only native-scope enum constant serialization','identity_aliasing':False,'root_derived_only_from_supplied_matching_Editor_mscorlib':True};plan['inputs'].append(p.pinned(PROOF));plan['inputs'].append(p.pinned(BASE/'stage-plan.json'));plan['marshalling_overlay']['binding_proof']=p.pinned(out/'overlay-binding-proof.json');plan['source_snapshots']=[{'source':str(x),'copy':str(x),'sha256':p.sha(x)} for x in sorted(folder.glob('*.cs'))];plan['patched_engine']['sha256']=p.sha(folder/'WholeMetadataRestorer.cs');(out/'stage-plan.json').write_text(json.dumps(plan,indent=2)+'\n');print(json.dumps({'stage':str(out),'sha256':p.sha(out/'stage-plan.json')}))
if __name__=='__main__':main()
