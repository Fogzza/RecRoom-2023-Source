// Complete only explicit original/compiled MethodDef bindings; no name guessing.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public static class EmittedReferencePlanCompletion
    {
        static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types){foreach(var t in types){yield return t;foreach(var n in Walk(t.NestedTypes))yield return n;}}
        static string Name(string signature){if(signature.Length<3||signature[0]!='M')throw new InvalidDataException("Expected MethodDef canonical signature");int p=signature.IndexOf(':');int n=int.Parse(signature.Substring(1,p-1));if(n<0||p+1+n>signature.Length)throw new InvalidDataException("MethodDef canonical name bound");return signature.Substring(p+1,n);}
        static string Key(MethodReferenceAlias r){return r.Assembly+":"+r.CompiledDeclaringType+":"+r.CompiledCanonicalSignature;}
        public static MethodReferenceAlias[] Complete(WholeMetadataManifest manifest,ModuleDefinition raw,ExactTypePlan[] plans)
        {
            var aliases=manifest.Methods.ToDictionary(Key);var types=Walk(raw.Types).ToDictionary(t=>t.FullName);
            var names=manifest.Types.ToDictionary(t=>t.Assembly+":"+t.OriginalFullName,t=>t.CompiledFullName);
            Func<TypeReference,string> project=t=>{string n;return names.TryGetValue(CanonicalMetadataSignatures.Assembly(t)+":"+t.FullName,out n)?n:t.FullName;};
            foreach(var typePlan in plans)foreach(var methodPlan in typePlan.Methods)
            {
                var method=types[typePlan.OriginalFullName].Methods.Single(m=>CanonicalMetadataSignatures.Method(m)==methodPlan.OriginalCanonicalSignature);
                if(ProjectedCanonicalSignatures.Method(method,project)==methodPlan.CompiledCanonicalSignature)continue;
                var row=new MethodReferenceAlias{Assembly=manifest.AssemblyName,OriginalDeclaringType=typePlan.OriginalFullName,CompiledDeclaringType=typePlan.CompiledFullName,
                    OriginalName=method.Name,CompiledName=Name(methodPlan.CompiledCanonicalSignature),OriginalCanonicalSignature=methodPlan.OriginalCanonicalSignature,
                    CompiledCanonicalSignature=methodPlan.CompiledCanonicalSignature,OriginalCanonicalReturnType=CanonicalMetadataSignatures.Type(method.ReturnType),OriginalCanonicalParameterTypes=method.Parameters.Select(p=>CanonicalMetadataSignatures.Type(p.ParameterType)).ToArray()};
                MethodReferenceAlias old;if(aliases.TryGetValue(Key(row),out old)){if(old.OriginalCanonicalSignature!=row.OriginalCanonicalSignature||old.OriginalDeclaringType!=row.OriginalDeclaringType)throw new InvalidDataException("Conflicting explicit current MethodRef reverse identity");}
                else aliases.Add(Key(row),row);
            }
            return aliases.Values.ToArray();
        }
    }
}
