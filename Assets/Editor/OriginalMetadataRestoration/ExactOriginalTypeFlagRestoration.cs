// Two exact compiler-only BeforeFieldInit additions, independently native-proven.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public static class ExactOriginalTypeFlagRestoration
    {
        private static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types)
        { foreach(var type in types){yield return type;foreach(var child in Walk(type.NestedTypes))yield return child;} }
        public static void Apply(ModuleDefinition compiled, ModuleDefinition raw, ExactTypePlan[] plans)
        {
            var originals=Walk(raw.Types).ToDictionary(t=>t.FullName);var actual=Walk(compiled.Types).ToDictionary(t=>t.FullName);
            string[] names={"PrivateImplementationDetailsQOELAJF.ArrayCopy148","PrivateImplementationDetailsQOELAJF.ArrayCopy148/$ArrayType$151"};
            int[] flags={131072,275};
            for(int i=0;i<names.Length;i++)
            {
                var plan=plans.SingleOrDefault(p=>p.OriginalFullName==names[i]);
                if(plan==null||!originals.ContainsKey(names[i])||!actual.ContainsKey(plan.CompiledFullName))throw new InvalidDataException("Missing native-proven type flag correction identity");
                var original=originals[names[i]];var emitted=actual[plan.CompiledFullName];
                if((int)original.Attributes!=flags[i]||((int)emitted.Attributes!=flags[i]&&(int)emitted.Attributes!=(flags[i]|0x100000)))throw new InvalidDataException("Unreviewed original/compiler type flag difference");
                if(emitted.HasMethods!=original.HasMethods||emitted.Fields.Count!=original.Fields.Count||emitted.PackingSize!=original.PackingSize||emitted.ClassSize!=original.ClassSize)throw new InvalidDataException("Type flag correction shape differs");
                emitted.Attributes=original.Attributes;
            }
        }
    }
}
