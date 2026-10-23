// Extra production gate beyond the isolated V5 fixture. No metadata/body edits.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public static class OriginalTypeContractChecks
    {
        private static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types)
        { foreach (var type in types) { yield return type; foreach (var child in Walk(type.NestedTypes)) yield return child; } }
        private static void Require(bool value, string message)
        { if (!value) throw new InvalidDataException("Original type contract refused: " + message); }
        private static string GenericAttributes(GenericParameter p)
        { return string.Join("|", p.CustomAttributes.Select(a => a.Constructor.FullName + ":" + BitConverter.ToString(a.GetBlob())).OrderBy(s => s)); }
        private static void Generic(IGenericParameterProvider actual, IGenericParameterProvider original, Func<TypeReference,string> project, string owner)
        {
            Require(actual.GenericParameters.Count == original.GenericParameters.Count, owner + " generic arity");
            for (int i = 0; i < actual.GenericParameters.Count; i++)
            {
                var a = actual.GenericParameters[i]; var o = original.GenericParameters[i];
                Require(a.Position == o.Position && a.Type == o.Type && a.Attributes == o.Attributes, owner + " generic flags/owner/position " + i);
                var ac = a.Constraints.Select(c => CanonicalMetadataSignatures.Type(c.ConstraintType)).OrderBy(s => s).ToArray();
                var oc = o.Constraints.Select(c => ProjectedCanonicalSignatures.Type(c.ConstraintType, project)).OrderBy(s => s).ToArray();
                Require(ac.SequenceEqual(oc), owner + " generic constraints " + i);
                // Compiler-added unmanaged marker annotations cannot silently
                // masquerade as original custom-attribute ownership.
                Require(GenericAttributes(a) == GenericAttributes(o), owner + " generic custom attributes " + i);
            }
        }
        public static void VerifyProjected(ModuleDefinition compiled, ModuleDefinition raw, ExactTypePlan[] plans, TypeReferenceAlias[] aliases)
        {
            var ca = Walk(compiled.Types).ToDictionary(t => t.FullName);
            var ra = Walk(raw.Types).ToDictionary(t => t.FullName);
            var names = aliases.ToDictionary(a => a.Assembly + ":" + a.OriginalFullName, a => a.CompiledFullName);
            Func<TypeReference,string> project = t => { string name; return names.TryGetValue(CanonicalMetadataSignatures.Assembly(t) + ":" + t.FullName, out name) ? name : t.FullName; };
            foreach (var plan in plans)
            {
                var a = ca[plan.CompiledFullName]; var o = ra[plan.OriginalFullName];
                Require(a.Attributes == o.Attributes, o.FullName + " TypeAttributes (incl BeforeFieldInit/layout/visibility)");
                Require(a.PackingSize == o.PackingSize && a.ClassSize == o.ClassSize, o.FullName + " class layout size/packing");
                Require((a.BaseType == null) == (o.BaseType == null), o.FullName + " base presence");
                if (a.BaseType != null) Require(CanonicalMetadataSignatures.Type(a.BaseType) == ProjectedCanonicalSignatures.Type(o.BaseType, project), o.FullName + " exact original base type");
                Require(a.Interfaces.Select(i => CanonicalMetadataSignatures.Type(i.InterfaceType)).OrderBy(s => s)
                    .SequenceEqual(o.Interfaces.Select(i => ProjectedCanonicalSignatures.Type(i.InterfaceType, project)).OrderBy(s => s)), o.FullName + " interfaces");
                Generic(a, o, project, o.FullName);
                foreach (var mp in plan.Methods)
                {
                    var am = a.Methods.Single(m => CanonicalMetadataSignatures.Method(m) == mp.CompiledCanonicalSignature);
                    var om = o.Methods.Single(m => CanonicalMetadataSignatures.Method(m) == mp.OriginalCanonicalSignature);
                    Generic(am, om, project, om.FullName);
                }
            }
        }
    }
}
