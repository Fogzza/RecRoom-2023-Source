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
    public sealed class ExactMetadataReferenceResolver : IAssemblyResolver
    {
        readonly Dictionary<string, string> paths = new Dictionary<string, string>(StringComparer.Ordinal);
        readonly Dictionary<string, AssemblyDefinition> cache = new Dictionary<string, AssemblyDefinition>(StringComparer.Ordinal);

        public ExactMetadataReferenceResolver(IEnumerable<string> references) : this(references, new CuratedRuntimeMetadataReference[0]) { }
        public ExactMetadataReferenceResolver(IEnumerable<string> references, IEnumerable<CuratedRuntimeMetadataReference> curatedReferences)
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
                    if(directory.Name=="ScriptAssemblies" && directory.Parent!=null && directory.Parent.Name=="Library" && directory.Parent.Parent!=null)
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
            if (!paths.TryGetValue(name.Name, out path)) throw new AssemblyResolutionException(name);
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
