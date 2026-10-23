// Diagnostic hashes only. This does not replace or relax the strict aggregate gate.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public static class MetadataRoundTripDiagnostics
    {
        private static void Attributes(StringBuilder value, ICustomAttributeProvider provider)
        {
            foreach (var attribute in provider.CustomAttributes)
                value.Append(attribute.Constructor.FullName).Append(':').Append(BitConverter.ToString(attribute.GetBlob())).Append('|');
        }
        private static void Generic(StringBuilder value, IGenericParameterProvider provider)
        {
            foreach (var generic in provider.GenericParameters)
            {
                value.Append(generic.Position).Append(':').Append(generic.Name).Append(':').Append((int)generic.Attributes).Append('|');
                foreach (var constraint in generic.Constraints) value.Append(CanonicalMetadataSignatures.Type(constraint.ConstraintType)).Append('|');
                Attributes(value, generic);
            }
        }
        private static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types)
        { foreach (var type in types) { yield return type; foreach (var child in Walk(type.NestedTypes)) yield return child; } }
        private static string Constant(bool hasConstant, object constant)
        { return hasConstant + ":" + Convert.ToString(constant, CultureInfo.InvariantCulture); }
        private struct DiagnosticRow
        {
            public string Label;
            public byte[] Digest;
        }
        public sealed class Snapshot
        {
            private const int RowsPerChunk=4096;
            private readonly List<byte[]> chunks=new List<byte[]>();
            public int Count { get; private set; }
            internal void Add(byte[] digest)
            {
                if(digest.Length!=32)throw new InvalidOperationException("SHA256 row required");
                if(Count%RowsPerChunk==0)chunks.Add(new byte[RowsPerChunk*32]);
                Buffer.BlockCopy(digest,0,chunks[Count/RowsPerChunk],(Count%RowsPerChunk)*32,32);Count++;
            }
            internal bool Matches(int row,byte[] actual)
            {
                if(row<0||row>=Count||actual.Length!=32)return false;
                var chunk=chunks[row/RowsPerChunk];int at=(row%RowsPerChunk)*32;
                for(int i=0;i<32;i++)if(chunk[at+i]!=actual[i])return false;
                return true;
            }
            internal string DigestText(int row)
            {
                var bytes=new byte[32];Buffer.BlockCopy(chunks[row/RowsPerChunk],(row%RowsPerChunk)*32,bytes,0,32);
                return Convert.ToBase64String(bytes);
            }
        }
        private static DiagnosticRow Row(SHA256 sha, string label, StringBuilder value)
        {
            // Bind the label/order as well as the value, without retaining either.
            return new DiagnosticRow {Label=label,Digest=sha.ComputeHash(Encoding.UTF8.GetBytes(label+"\0"+value.ToString()))};
        }
        private static IEnumerable<DiagnosticRow> Rows(ModuleDefinition module)
        {
            using (var sha = SHA256.Create())
            {
                var value = new StringBuilder(); value.Append(module.Assembly.Name.FullName).Append('|');
                yield return Row(sha, "module.assembly-header", value); value.Clear();
                Attributes(value,module); yield return Row(sha,"module.attrs",value); value.Clear();
                Attributes(value,module.Assembly); yield return Row(sha,"assembly.attrs",value); value.Clear();
                foreach (var reference in module.AssemblyReferences) value.Append(reference.FullName).Append('|');
                yield return Row(sha,"assembly.references-order",value); value.Clear();
                foreach (var type in module.Types) value.Append(type.FullName).Append('|');
                yield return Row(sha,"module.top-level-type-order",value); value.Clear();
                int ti=0;
                foreach (var type in Walk(module.Types))
                {
                    string t="T"+(ti++).ToString(CultureInfo.InvariantCulture);
                    value.Append(type.FullName).Append('|'); yield return Row(sha,t+".identity",value); value.Clear();
                    value.Append((int)type.Attributes).Append(':').Append(type.PackingSize).Append(':').Append(type.ClassSize).Append('|');
                    if(type.BaseType!=null)value.Append(CanonicalMetadataSignatures.Type(type.BaseType)).Append('|');
                    yield return Row(sha,t+".flags-layout-base",value); value.Clear();
                    Generic(value,type); yield return Row(sha,t+".generic",value); value.Clear();
                    Attributes(value,type); yield return Row(sha,t+".attrs",value); value.Clear();
                    foreach(var item in type.Interfaces){value.Append(CanonicalMetadataSignatures.Type(item.InterfaceType)).Append('|');Attributes(value,item);}
                    yield return Row(sha,t+".interfaces-order-attrs",value); value.Clear();
                    foreach(var child in type.NestedTypes)value.Append(child.FullName).Append('|');
                    yield return Row(sha,t+".nested-type-order",value); value.Clear();
                    int fi=0;
                    foreach(var field in type.Fields)
                    {
                        string f=t+".F"+(fi++).ToString(CultureInfo.InvariantCulture)+":"+field.Name;
                        value.Append(field.Name).Append(':').Append(CanonicalMetadataSignatures.Type(field.FieldType));
                        yield return Row(sha,f+".name-type",value);value.Clear();
                        value.Append((int)field.Attributes).Append(':').Append(field.Offset);
                        yield return Row(sha,f+".flags-offset",value);value.Clear();
                        value.Append(Constant(field.HasConstant,field.Constant));
                        yield return Row(sha,f+".hasconstant-value",value);value.Clear();
                        value.Append(BitConverter.ToString(field.InitialValue));
                        yield return Row(sha,f+".initial-data",value);value.Clear();
                        Attributes(value,field);yield return Row(sha,f+".attrs",value);value.Clear();
                    }
                    int mi=0;
                    foreach(var method in type.Methods)
                    {
                        string m=t+".M"+(mi++).ToString(CultureInfo.InvariantCulture)+":"+method.Name;
                        value.Append(CanonicalMetadataSignatures.Method(method));yield return Row(sha,m+".signature",value);value.Clear();
                        value.Append((int)method.Attributes).Append(':').Append((int)method.ImplAttributes).Append(':').Append((int)method.SemanticsAttributes);
                        yield return Row(sha,m+".flags-impl-semantics",value);value.Clear();
                        Generic(value,method);yield return Row(sha,m+".generic",value);value.Clear();
                        Attributes(value,method);yield return Row(sha,m+".attrs",value);value.Clear();
                        value.Append(method.MethodReturnType.Name).Append(':').Append((int)method.MethodReturnType.Attributes);
                        yield return Row(sha,m+".return-name-flags",value);value.Clear();
                        Attributes(value,method.MethodReturnType);yield return Row(sha,m+".return-attrs",value);value.Clear();
                        foreach(var parameter in method.Parameters)value.Append(parameter.Name).Append(':').Append((int)parameter.Attributes).Append('|');
                        yield return Row(sha,m+".parameter-name-flags",value);value.Clear();
                        foreach(var parameter in method.Parameters)value.Append(Constant(parameter.HasConstant,parameter.Constant)).Append('|');
                        yield return Row(sha,m+".parameter-hasconstant-values",value);value.Clear();
                        foreach(var parameter in method.Parameters){Attributes(value,parameter);value.Append("#|");}
                        yield return Row(sha,m+".parameter-attrs",value);value.Clear();
                        foreach(var implementation in method.Overrides)value.Append(CanonicalMetadataSignatures.Type(implementation.DeclaringType)).Append(':').Append(CanonicalMetadataSignatures.Method(implementation)).Append('|');
                        yield return Row(sha,m+".overrides-order",value);value.Clear();
                    }
                    int pi=0;
                    foreach(var property in type.Properties)
                    {
                        string p=t+".P"+(pi++).ToString(CultureInfo.InvariantCulture)+":"+property.Name;
                        value.Append(property.Name).Append(':').Append(CanonicalMetadataSignatures.Type(property.PropertyType)).Append(':').Append((int)property.Attributes);
                        yield return Row(sha,p+".name-type-flags",value);value.Clear();
                        value.Append(property.GetMethod==null?"":CanonicalMetadataSignatures.Method(property.GetMethod)).Append('|').Append(property.SetMethod==null?"":CanonicalMetadataSignatures.Method(property.SetMethod));
                        yield return Row(sha,p+".accessor-ownership",value);value.Clear();
                        Attributes(value,property);yield return Row(sha,p+".attrs",value);value.Clear();
                    }
                    int ei=0;
                    foreach(var item in type.Events)
                    {
                        string e=t+".E"+(ei++).ToString(CultureInfo.InvariantCulture)+":"+item.Name;
                        value.Append(item.Name).Append(':').Append(CanonicalMetadataSignatures.Type(item.EventType)).Append(':').Append((int)item.Attributes);
                        yield return Row(sha,e+".name-type-flags",value);value.Clear();
                        foreach(var method in new[]{item.AddMethod,item.RemoveMethod,item.InvokeMethod})value.Append(method==null?"":CanonicalMetadataSignatures.Method(method)).Append('|');
                        yield return Row(sha,e+".accessor-ownership",value);value.Clear();
                        Attributes(value,item);yield return Row(sha,e+".attrs",value);value.Clear();
                    }
                }
            }
        }
        public static Snapshot Capture(ModuleDefinition module)
        {
            var snapshot=new Snapshot();
            foreach(var row in Rows(module))snapshot.Add(row.Digest);
            return snapshot;
        }
        public static string Difference(Snapshot expectedSnapshot,ModuleDefinition actualModule)
        {
            const int maximum=128;int different=0,added=0,missing=0,rows=0;
            var owners=Walk(actualModule.Types).Select(t=>t.FullName).ToArray();var result=new StringBuilder();
            foreach(var row in Rows(actualModule))
            {
                int index=rows++;
                if(index>=expectedSnapshot.Count){added++;if(different+added<=maximum)result.Append("added row=").Append(index).Append(' ').Append(Label(row.Label,owners)).Append(" actual=").Append(Convert.ToBase64String(row.Digest)).AppendLine();}
                else if(!expectedSnapshot.Matches(index,row.Digest)){different++;if(different+added<=maximum)result.Append("changed row=").Append(index).Append(' ').Append(Label(row.Label,owners)).Append(" expected=").Append(expectedSnapshot.DigestText(index)).Append(" actual=").Append(Convert.ToBase64String(row.Digest)).AppendLine();}
            }
            for(int index=rows;index<expectedSnapshot.Count;index++){missing++;if(different+added+missing<=maximum)result.Append("missing row=").Append(index).Append(" expected=").Append(expectedSnapshot.DigestText(index)).AppendLine();}
            result.Insert(0,"metadata-row-diagnostic expectedRows="+expectedSnapshot.Count+" actualRows="+rows+" changed="+different+" added="+added+" missing="+missing+" shownMax="+maximum+Environment.NewLine);
            return result.ToString();
        }
        private static string Label(string label,string[] owners)
        {
            if(label.Length>1&&label[0]=='T'){int dot=label.IndexOf('.');int index;if(dot>1&&int.TryParse(label.Substring(1,dot-1),NumberStyles.None,CultureInfo.InvariantCulture,out index)&&index>=0&&index<owners.Length)return owners[index]+" ["+label+"]";}
            return label;
        }
    }
}
