// Explicit original-method gaps. This never manufactures any missing body.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public sealed class UnrecoveredOriginalMethodPlan
    {
        public string OriginalType, OriginalCanonicalSignature, ExpectedCompiledCanonicalSignature, Classification;
        public uint OriginalProviderMethodToken;
        public int OriginalAttributes, OriginalImplAttributes, OriginalSemantics;
    }
    public static class EmittedOriginalMethodSubsetPolicy
    {
        public static MethodDefinition[] Select(ModuleDefinition raw, TypeDefinition original, TypeDefinition compiled, UnrecoveredOriginalMethodPlan[] all)
        {
            var rows=all.Where(r=>r.OriginalType==original.FullName).ToArray();
            if(rows.Select(r=>r.OriginalCanonicalSignature).Distinct().Count()!=rows.Length)
                throw new InvalidDataException("Duplicate explicit original-method gap");
            var absent=new HashSet<MethodDefinition>();
            foreach(var row in rows)
            {
                var found=original.Methods.Where(m=>CanonicalMetadataSignatures.Method(m)==row.OriginalCanonicalSignature).Take(2).ToArray();
                if(found.Length!=1)throw new InvalidDataException("Original-method gap does not uniquely bind pinned original metadata");
                var method=found[0];
                if(method.MetadataToken.ToUInt32()!=row.OriginalProviderMethodToken||(int)method.Attributes!=row.OriginalAttributes
                    ||(int)method.ImplAttributes!=row.OriginalImplAttributes||(int)method.SemanticsAttributes!=row.OriginalSemantics)
                    throw new InvalidDataException("Original-method gap token/flags/ownership differs from pinned raw provider");
                string expected=method.Name==".cctor"?"unrecovered-original-static-constructor":method.Name==".ctor"?"unrecovered-original-instance-constructor":"unrecovered-original-method";
                if(row.Classification!=expected||row.OriginalSemantics!=0)
                    throw new InvalidDataException("Unsupported original accessor/event gap or gap classification");
                if(compiled.Methods.Any(m=>CanonicalMetadataSignatures.Method(m)==row.ExpectedCompiledCanonicalSignature))
                    throw new InvalidDataException("Explicitly missing original method is actually emitted");
                absent.Add(method);
            }
            return original.Methods.Where(m=>!absent.Contains(m)).ToArray();
        }
        public static void VerifyScope(IEnumerable<TypeDefinition> originalTypes, UnrecoveredOriginalMethodPlan[] rows)
        {
            var names=new HashSet<string>(originalTypes.Select(t=>t.FullName));
            if(rows.Any(r=>!names.Contains(r.OriginalType)))throw new InvalidDataException("Original-method gap outside emitted original type scope");
        }
    }
}
