// Metadata-only reference resolution. Never loads inspected code into the CLR.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public sealed class CuratedRuntimeMetadataReference
    {
        public readonly string Name, Sha256;
        public CuratedRuntimeMetadataReference(string name, string sha256) { Name=name; Sha256=sha256; }
    }
    public sealed class CuratedFrameworkMetadataReference { public readonly string FileName, FullName, Sha256; public CuratedFrameworkMetadataReference(string fileName,string fullName,string sha256) { FileName=fileName; FullName=fullName; Sha256=sha256; } }
    public sealed class ExactMetadataReferenceResolver : IAssemblyResolver
    {
        readonly Dictionary<string, string> paths = new Dictionary<string, string>(StringComparer.Ordinal);
        readonly Dictionary<string,string> frameworkPaths = new Dictionary<string,string>(StringComparer.Ordinal);
        readonly Dictionary<string, AssemblyDefinition> cache = new Dictionary<string, AssemblyDefinition>(StringComparer.Ordinal);

        public ExactMetadataReferenceResolver(IEnumerable<string> references) : this(references, new CuratedRuntimeMetadataReference[0]) { }
        public ExactMetadataReferenceResolver(IEnumerable<string> references, IEnumerable<CuratedRuntimeMetadataReference> curatedReferences) : this(references,curatedReferences,new CuratedFrameworkMetadataReference[0]) { }
        public ExactMetadataReferenceResolver(IEnumerable<string> references, IEnumerable<CuratedRuntimeMetadataReference> curatedReferences, IEnumerable<CuratedFrameworkMetadataReference> frameworkReferences)
        {
            var suppliedPaths=(references ?? new string[0]).Select(Path.GetFullPath).ToArray();
            foreach (var supplied in suppliedPaths)
            {
                var path = Path.GetFullPath(supplied);
                // Compiler facades use projected names. Once those names have
                // been reversed, constants must resolve against the matching
                // original runtime metadata, never the facade of that identity.
                var parent = new DirectoryInfo(Path.GetDirectoryName(path));
                if (parent.Name == "References" && parent.Parent != null && parent.Parent.Name == "CompilerSupport")
                {
                    var root = parent.Parent.Parent;
                    if (root == null) throw new InvalidDataException("Facade has no project root");
                    path = Path.Combine(root.FullName, "Assets", "Plugins", Path.GetFileName(path));
                }
                if (!File.Exists(path)) throw new InvalidDataException("Exact metadata reference missing: " + path);
                string name = Path.GetFileNameWithoutExtension(path), previous;
                if (paths.TryGetValue(name, out previous) && !String.Equals(previous, path, StringComparison.OrdinalIgnoreCase))
                    throw new InvalidDataException("Ambiguous exact metadata reference: " + name);
                paths[name] = path;
            }
            var frameworks=frameworkReferences.ToArray();
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
            var curated=curatedReferences.ToArray();
            if(curated.Length>512 || curated.Select(c=>c.Name).Distinct(StringComparer.Ordinal).Count()!=curated.Length)
                throw new InvalidDataException("Ambiguous curated runtime reference inventory");
            string project=null;
            if(curated.Any(c=>!paths.ContainsKey(c.Name)))
            {
                var roots=new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach(var path in suppliedPaths.Where(p=>Path.GetFileName(p)=="Assembly-CSharp-firstpass.dll"))
                {
                    var directory=new DirectoryInfo(Path.GetDirectoryName(path));
                    if((directory.Name=="ScriptAssemblies" || directory.Name=="PlayerScriptAssemblies") && directory.Parent!=null && directory.Parent.Name=="Library" && directory.Parent.Parent!=null)
                        roots.Add(directory.Parent.Parent.FullName);
                    else if(directory.Name=="Temp" && directory.Parent!=null) roots.Add(directory.Parent.FullName);
                }
                if(roots.Count!=1) throw new InvalidDataException("One exact firstpass project root is required for omitted response-file references");
                project=roots.Single();
            }
            foreach(var item in curated)
            {
                if(String.IsNullOrEmpty(item.Name)||item.Name.IndexOfAny(new[]{'/', '\\', ':'})>=0||item.Sha256==null||item.Sha256.Length!=64||item.Sha256.Any(c=>!((c>='0'&&c<='9')||(c>='a'&&c<='f'))))
                    throw new InvalidDataException("Invalid curated runtime reference identity");
                string path;
                if(!paths.TryGetValue(item.Name,out path))
                {
                    path=Path.Combine(project,"Assets","Plugins",item.Name+".dll");
                    if(!File.Exists(path))throw new InvalidDataException("Curated original runtime reference missing: "+item.Name);
                    paths.Add(item.Name,path);
                }
                string digest;
                using(var stream=File.OpenRead(path))using(var sha=SHA256.Create())digest=BitConverter.ToString(sha.ComputeHash(stream)).Replace("-","").ToLowerInvariant();
                if(digest!=item.Sha256)throw new InvalidDataException("Curated original runtime reference bytes changed: "+item.Name);
            }
        }

        public AssemblyDefinition Resolve(AssemblyNameReference name) { return Resolve(name, new ReaderParameters()); }
        public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters ignored)
        {
            AssemblyDefinition value;
            if (cache.TryGetValue(name.FullName, out value)) return value;
            string path;
            if (!frameworkPaths.TryGetValue(name.FullName,out path) && !paths.TryGetValue(name.Name, out path)) throw new AssemblyResolutionException(name);
            value = AssemblyDefinition.ReadAssembly(path, new ReaderParameters { InMemory = true, ReadSymbols = false, AssemblyResolver = this });
            if (value.Name.FullName != name.FullName)
            {
                string actual = value.Name.FullName; value.Dispose();
                throw new InvalidDataException("Exact metadata reference identity differs: requested " + name.FullName + " actual " + actual);
            }
            cache.Add(name.FullName, value);
            return value;
        }

        public void Dispose() { foreach (var assembly in cache.Values) assembly.Dispose(); cache.Clear(); }
    }
}
