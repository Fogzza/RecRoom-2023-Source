// Exact emitted-original PInvoke plans; only empty RVA0 C# externs are eligible.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
namespace RR23.MetadataRestoration
{
    public sealed class OriginalEmptyExternPlan
    {
        public string OriginalType,CompiledType,OriginalCanonical,CompiledCanonical;
        public uint OriginalProviderMethodToken;
        public int OriginalAttributes,OriginalImplAttributes,OriginalSemantics;
    }
    public static class OriginalEmptyExternRestoration
    {
        static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types){foreach(var t in types){yield return t;foreach(var n in Walk(t.NestedTypes))yield return n;}}
        static T One<T>(IEnumerable<T> values,string why){var rows=values.Take(2).ToArray();if(rows.Length!=1)throw new InvalidDataException("Original extern does not bind uniquely: "+why);return rows[0];}
        public static int Apply(ModuleDefinition compiled,ModuleDefinition raw,OriginalEmptyExternPlan[] plans)
        {
            var originals=Walk(raw.Types).ToDictionary(t=>t.FullName);var current=Walk(compiled.Types).ToDictionary(t=>t.FullName);
            var rows=new List<Tuple<MethodDefinition,MethodDefinition>>();var seen=new HashSet<MethodDefinition>();
            foreach(var plan in plans)
            {
                var source=One(originals[plan.OriginalType].Methods.Where(m=>CanonicalMetadataSignatures.Method(m)==plan.OriginalCanonical),plan.OriginalType+"::"+plan.OriginalCanonical);
                var method=One(current[plan.CompiledType].Methods.Where(m=>CanonicalMetadataSignatures.Method(m)==plan.CompiledCanonical),plan.CompiledType+"::"+plan.CompiledCanonical);
                if(!seen.Add(method)||source.MetadataToken.ToUInt32()!=plan.OriginalProviderMethodToken||(int)source.Attributes!=plan.OriginalAttributes||(int)source.ImplAttributes!=plan.OriginalImplAttributes||(int)source.SemanticsAttributes!=plan.OriginalSemantics
                    ||source.RVA!=0||source.HasBody||!source.IsPInvokeImpl||source.PInvokeInfo!=null||method.RVA!=0||method.ImplAttributes!=source.ImplAttributes||method.PInvokeInfo!=null
                    ||(int)method.Attributes!=((int)source.Attributes&~(int)MethodAttributes.PInvokeImpl))throw new InvalidDataException("Original empty extern token/signature/nativeflags/RVA0 proof differs: "+source.FullName);
                var body=method.Body;
                if(body==null||body.Instructions.Count!=0||body.Variables.Count!=0||body.ExceptionHandlers.Count!=0||body.CodeSize!=0||method.DebugInformation.HasSequencePoints||method.DebugInformation.Scope!=null||method.DebugInformation.CustomDebugInformations.Count!=0)
                    throw new InvalidDataException("Cannot normalize an extern with genuine IL/PDB data: "+source.FullName);
                rows.Add(Tuple.Create(method,source));
            }
            foreach(var row in rows){row.Item1.Attributes=row.Item2.Attributes;row.Item1.ImplAttributes=row.Item2.ImplAttributes;row.Item1.Body=null;if(row.Item1.HasBody||row.Item1.RVA!=0||row.Item1.PInvokeInfo!=null)throw new InvalidDataException("Original empty extern restoration differs");}
            return rows.Count;
        }
    }
}
