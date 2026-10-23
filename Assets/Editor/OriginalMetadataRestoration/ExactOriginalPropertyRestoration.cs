// Restore only parameterized PropertyDefs that C# cannot express. No new body.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public static class ExactOriginalPropertyRestoration
    {
        static void Need(bool value,string text){if(!value)throw new InvalidDataException("Original PropertyDef inverse refused: "+text);}
        static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types){foreach(var t in types){yield return t;foreach(var n in Walk(t.NestedTypes))yield return n;}}
        static T One<T>(IEnumerable<T> values,string text){var rows=values.Take(2).ToArray();Need(rows.Length==1,text);return rows[0];}
        public static int Apply(ModuleDefinition compiled,ModuleDefinition raw,WholeMetadataManifest manifest)
        {
            var current=Walk(compiled.Types).ToDictionary(t=>t.FullName);var original=Walk(raw.Types).ToDictionary(t=>t.FullName);
            var aliases=manifest.Types.ToDictionary(t=>t.Assembly+"|"+t.OriginalFullName,t=>t.CompiledFullName);
            Func<TypeReference,string> names=t=>{string name;return aliases.TryGetValue(CanonicalMetadataSignatures.Assembly(t)+"|"+t.FullName,out name)?name:t.FullName;};
            var additions=new List<Tuple<TypeDefinition,PropertyDefinition>>();
            var eligible=new Dictionary<string,uint>{{"DJDADKAAOLE",0x170026de},{"EDPNALIEGFA",0x17000917},{"LACGBOPLMDD",0x1700090d},{"PDMBBGPNNAH",0x1700147d},{"RecRoom.Core.Rendering.RendererEffectBase`2/JJBOMPKOMPB",0x17003994}};
            foreach(var plan in manifest.Definitions)
            {
                var owner=current[plan.CompiledFullName];var source=original[plan.OriginalFullName];
                Func<MethodDefinition,MethodDefinition> accessor=method=>{
                    if(method==null)return null;
                    string signature=CanonicalMetadataSignatures.Method(method);
                    var mapping=One(plan.Methods.Where(p=>p.OriginalCanonicalSignature==signature),"Original property accessor is not exactly bound");
                    return One(owner.Methods.Where(m=>CanonicalMetadataSignatures.Method(m)==mapping.CompiledCanonicalSignature),"Compiled property accessor is not exactly bound: "+source.FullName+" raw="+signature+" planned="+mapping.CompiledCanonicalSignature);
                };
                foreach(var property in source.Properties)
                {
                    var getter=accessor(property.GetMethod);var setter=accessor(property.SetMethod);
                    var matches=owner.Properties.Where(p=>ReferenceEquals(p.GetMethod,getter)&&ReferenceEquals(p.SetMethod,setter)).Take(2).ToArray();
                    Need(matches.Length<=1,"Competing existing property accessor ownership: "+property.FullName);
                    if(matches.Length==1)continue;
                    uint token;Need(eligible.TryGetValue(source.FullName,out token)&&property.Name=="POFBPBHJKPE"&&property.MetadataToken.ToUInt32()==token,"Missing property is outside the independently inventoried five original identities: "+property.FullName);
                    Need(property.Parameters.Count>0&&!property.HasOtherMethods&&!property.HasConstant&&!property.HasCustomAttributes&&(int)property.Attributes==0&&(getter!=null||setter!=null),"Only exact absent named parameterized PropertyDefs are eligible: "+property.FullName);
                    string expectedType=ProjectedCanonicalSignatures.Type(property.PropertyType,names);
                    var witness=getter!=null?getter.ReturnType:setter.Parameters.Last().ParameterType;
                    Need(CanonicalMetadataSignatures.Type(witness)==expectedType,"Property type is not proved by retained original accessor");
                    if(setter!=null)Need(CanonicalMetadataSignatures.Type(setter.Parameters.Last().ParameterType)==expectedType,"Setter property type differs");
                    var parameters=getter!=null?getter.Parameters.ToArray():setter.Parameters.Take(setter.Parameters.Count-1).ToArray();
                    Need(parameters.Length==property.Parameters.Count,"Original accessor parameter count differs");
                    var restored=new PropertyDefinition(property.Name,property.Attributes,witness){GetMethod=getter,SetMethod=setter,HasThis=property.HasThis};
                    for(int i=0;i<parameters.Length;i++)
                    {
                        string expected=ProjectedCanonicalSignatures.Type(property.Parameters[i].ParameterType,names);
                        Need(CanonicalMetadataSignatures.Type(parameters[i].ParameterType)==expected,"Original accessor parameter TypeSpec differs");
                        if(setter!=null)Need(CanonicalMetadataSignatures.Type(setter.Parameters[i].ParameterType)==expected,"Original setter parameter TypeSpec differs");
                        // Cecil 0.11.4 PropertyDef.Parameters mirrors accessor
                        // parameters. Reuse those exact retained owner objects;
                        // no raw-module GenericParameter may be imported here.
                        Need(ReferenceEquals(restored.Parameters[i],parameters[i]),"Restored property parameter lost retained accessor ownership");
                    }
                    Need(!owner.Properties.Any(p=>p.Name==restored.Name),"Named parameterized property already has a competing definition");
                    Need(!additions.Any(p=>ReferenceEquals(p.Item1,owner)&&p.Item2.Name==restored.Name),"Duplicate planned parameterized property");
                    additions.Add(Tuple.Create(owner,restored));
                }
                Need(owner.Properties.Count+additions.Count(p=>ReferenceEquals(p.Item1,owner))==source.Properties.Count,"Original/compiler PropertyDef inventory differs: "+source.FullName);
            }
            foreach(var item in additions)item.Item1.Properties.Add(item.Item2);
            return additions.Count;
        }
    }
}
