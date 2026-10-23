// Metadata only. Restores only independently native-proven external TypeRef
// scopes; no method body, method flag, source, or broad assembly alias changes.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public sealed class OriginalFrameworkScopeRow
    {
        public readonly string Name, CompiledScope, OriginalScope;
        public OriginalFrameworkScopeRow(string name, string compiledScope, string originalScope)
        { Name=name; CompiledScope=compiledScope; OriginalScope=originalScope; }
    }
    public static class ExactOriginalFrameworkScopes
    {
        public static int Apply(ModuleDefinition target, ModuleDefinition original, OriginalFrameworkScopeRow[] rows)
        {
            if (rows == null || rows.Length == 0 || rows.Length > 64 || rows.Select(r=>r.Name).Distinct().Count()!=rows.Length)
                throw new InvalidDataException("Invalid finite original framework TypeRef scope inventory");
            var all = target.GetTypeReferences().ToArray();
            var raw = original.GetTypeReferences().ToArray();
            var pending = new List<Tuple<TypeReference,AssemblyNameReference>>();
            foreach(var row in rows)
            {
                if (String.IsNullOrEmpty(row.Name) || row.CompiledScope==row.OriginalScope)
                    throw new InvalidDataException("Invalid exact framework scope row");
                var expected=raw.Where(t=>t.FullName==row.Name).Select(t=>t.Scope as AssemblyNameReference).ToArray();
                if(expected.Length==0 || expected.Any(a=>a==null || a.FullName!=row.OriginalScope))
                    throw new InvalidDataException("Original TypeRef scope is not uniquely proven: "+row.Name);
                var matches=all.Where(t=>t.FullName==row.Name && t.Scope is AssemblyNameReference && ((AssemblyNameReference)t.Scope).FullName==row.CompiledScope).ToArray();
                if(matches.Length!=1 || all.Any(t=>t.FullName==row.Name && (!(t.Scope is AssemblyNameReference) || (((AssemblyNameReference)t.Scope).FullName!=row.CompiledScope && ((AssemblyNameReference)t.Scope).FullName!=row.OriginalScope))))
                    throw new InvalidDataException("Compiled TypeRef scope is not exact and unique: "+row.Name);
                var scopes=target.AssemblyReferences.Where(a=>a.FullName==row.OriginalScope).ToArray();
                if(scopes.Length>1)throw new InvalidDataException("Duplicate original framework AssemblyRef");
                AssemblyNameReference scope;
                if(scopes.Length==1)
                {
                    scope=scopes[0];var authority=expected[0];
                    if(scope.Attributes!=authority.Attributes || scope.HashAlgorithm!=authority.HashAlgorithm || !(scope.Hash??new byte[0]).SequenceEqual(authority.Hash??new byte[0]))
                        throw new InvalidDataException("Existing original framework AssemblyRef flags/hash differ: "+row.Name);
                }
                else
                {
                    // Parse retains the exact public-key-token identity. Clone
                    // the original flags/hash rather than using compiler flags.
                    var authority=expected[0];scope=AssemblyNameReference.Parse(authority.FullName);
                    scope.Attributes=authority.Attributes;scope.HashAlgorithm=authority.HashAlgorithm;
                    scope.Hash=authority.Hash==null?null:(byte[])authority.Hash.Clone();
                }
                pending.Add(Tuple.Create(matches[0],scope));
            }
            // All selectors and original scopes must bind before mutation.
            foreach(var item in pending)
            {
                var scope=target.AssemblyReferences.SingleOrDefault(a=>a.FullName==item.Item2.FullName);
                if(scope==null){scope=item.Item2;target.AssemblyReferences.Add(scope);}
                item.Item1.Scope=scope;
            }
            foreach(var row in rows)
                if(all.Any(t=>t.FullName==row.Name && (!(t.Scope is AssemblyNameReference) || ((AssemblyNameReference)t.Scope).FullName!=row.OriginalScope)))
                    throw new InvalidDataException("Original framework scope postcondition failed: "+row.Name);
            return pending.Count;
        }
    }
}
