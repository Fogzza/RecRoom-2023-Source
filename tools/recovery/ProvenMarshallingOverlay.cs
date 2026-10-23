// Late, explicitly sourced marshal/ImplMap metadata only. No IL or PDB edits.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Mono.Cecil;

namespace RR23.MetadataRestoration
{
    public sealed class ProvenMarshallingOverlayResult
    {
        public int Fields,Parameters,SourceReturns,Imports,WindowsX64CompatibilityParameters;
        public string SourceOverlayHash;
    }
    public static class ProvenMarshallingOverlay
    {
        sealed class Row
        {
            public int Kind,Sequence,Flags,ImplFlags,ImportFlags;
            public uint SourceToken,RawProviderToken;
            public string Owner,Name,Type,NativeToken,RawCanonical,Authority,ParameterName,Module,Entry;
            public string[] Arguments;
            public MarshalInfo Marshal;
        }
        static void Need(bool value,string why){if(!value)throw new InvalidDataException("Proven marshalling overlay refused: "+why);}
        static string Hash(byte[] bytes){using(var h=SHA256.Create())return BitConverter.ToString(h.ComputeHash(bytes)).Replace("-","").ToLowerInvariant();}
        static string Text(BinaryReader r){string text=r.ReadString();Need(text.Length<=8192,"oversized bounded identity");return text;}
        static int Count(BinaryReader r,int maximum){int count=r.ReadInt32();Need(count>=0&&count<=maximum,"bounded row/argument count");return count;}
        static IEnumerable<TypeDefinition> Walk(IEnumerable<TypeDefinition> types){foreach(var type in types){yield return type;foreach(var nested in Walk(type.NestedTypes))yield return nested;}}
        static MarshalInfo Descriptor(BinaryReader r)
        {
            int kind=r.ReadByte(),native=r.ReadInt32();MarshalInfo value;
            if(kind==0){Need(native==3||native==8||native==38||native==43,"unapproved scalar marshal tag");value=new MarshalInfo((NativeType)native);}
            else if(kind==1){Need(native==23,"fixed string tag");int size=r.ReadInt32();Need(size>0&&size<=1048576,"fixed string bound");value=new FixedSysStringMarshalInfo{Size=size};}
            else if(kind==2){Need(native==30,"fixed array tag");int element=r.ReadInt32(),size=r.ReadInt32();Need(element==102&&size>=0&&size<=1048576,"exact SDK fixed-array None102 and bounds");value=new FixedArrayMarshalInfo{ElementType=(NativeType)element,Size=size};}
            else if(kind==3){Need(native==42,"array tag");int element=r.ReadInt32(),size=r.ReadInt32(),index=r.ReadInt32(),multiplier=r.ReadInt32();Need(element>=0&&element<=80&&size>=-1&&size<=1048576&&index>=-1&&index<64&&multiplier>=-1&&multiplier<=1048576,"array descriptor bounds");value=new ArrayMarshalInfo{ElementType=(NativeType)element,Size=size,SizeParameterIndex=index,SizeParameterMultiplier=multiplier};}
            else throw new InvalidDataException("Unknown unproved marshal descriptor kind");
            Need((int)value.NativeType==native,"descriptor tag changed");CanonicalMarshallingContracts.MarshalDescriptor(value);return value;
        }
        static Row MethodRow(BinaryReader r,int kind)
        {
            var row=new Row{Kind=kind,Owner=Text(r),Name=Text(r),Type=Text(r),NativeToken=Text(r),RawProviderToken=r.ReadUInt32(),RawCanonical=Text(r),SourceToken=r.ReadUInt32()};
            int count=Count(r,64);row.Arguments=new string[count];for(int i=0;i<count;i++)row.Arguments[i]=Text(r);
            return row;
        }
        static Row[] Read(byte[] bytes,string expectedHash,out string sourceHash)
        {
            Need(bytes!=null&&bytes.Length<=4*1024*1024&&Hash(bytes)==expectedHash,"pinned immutable plan bytes");var rows=new List<Row>();
            using(var stream=new MemoryStream(bytes,false))using(var r=new BinaryReader(stream,Encoding.UTF8))
            {
                Need(Text(r)=="RR23-MARSHAL-OVERLAY/V1","binary schema");sourceHash=Text(r);Need(sourceHash.Length==64,"source overlay SHA");
                Need(Text(r)=="Assembly-CSharp","original target assembly");
                int fields=Count(r,111),parameters=Count(r,64),returns=Count(r,318),imports=Count(r,819);
                Need(fields==111&&parameters==64&&returns==318&&imports==819,"exact reviewed row counts");
                for(int i=0;i<fields;i++)rows.Add(new Row{Kind=0,Owner=Text(r),Name=Text(r),Type=Text(r),NativeToken=Text(r),RawProviderToken=r.ReadUInt32(),RawCanonical=Text(r),SourceToken=r.ReadUInt32(),Flags=r.ReadInt32(),Authority=Text(r),Marshal=Descriptor(r)});
                for(int i=0;i<parameters+returns;i++)
                {
                    bool returned=i>=parameters;var row=MethodRow(r,returned?2:1);row.Sequence=r.ReadInt32();row.Flags=r.ReadInt32();row.ParameterName=Text(r);row.Authority=Text(r);row.Marshal=Descriptor(r);rows.Add(row);
                }
                for(int i=0;i<imports;i++)
                {
                    var row=MethodRow(r,3);row.Flags=r.ReadInt32();row.ImplFlags=r.ReadInt32();row.Module=Text(r);row.Entry=Text(r);row.ImportFlags=r.ReadInt32();row.Authority=Text(r);rows.Add(row);
                }
                Need(stream.Position==stream.Length,"no trailing/unparsed binary fields");
            }
            return rows.ToArray();
        }
        static MethodDefinition Method(TypeDefinition owner,Row row)
        {
            var methods=owner.Methods.Where(m=>m.Name==row.Name&&m.GenericParameters.Count==0&&m.ReturnType.FullName==row.Type&&m.Parameters.Select(p=>p.ParameterType.FullName).SequenceEqual(row.Arguments)).Take(2).ToArray();
            Need(methods.Length==1,"exact complete method identity "+row.Owner+"::"+row.Name);return methods[0];
        }
        static ModuleReference Module(ModuleDefinition target,string name)
        {
            var existing=target.ModuleReferences.Where(m=>m.Name==name).Take(2).ToArray();Need(existing.Length<=1,"duplicate import module name");
            if(existing.Length==1)return existing[0];var added=new ModuleReference(name);target.ModuleReferences.Add(added);return added;
        }
        static void Coverage(ModuleDefinition module)
        {
            int descriptors=0;
            foreach(var type in Walk(module.Types))
            {
                foreach(var field in type.Fields){Need(((field.Attributes&FieldAttributes.HasFieldMarshal)!=0)==field.HasMarshalInfo,"dangling field marshal "+field.FullName);if(field.HasMarshalInfo){CanonicalMarshallingContracts.Canonical(field);descriptors++;}}
                foreach(var method in type.Methods)
                {
                    var returned=method.MethodReturnType;Need(((returned.Attributes&ParameterAttributes.HasFieldMarshal)!=0)==returned.HasMarshalInfo,"dangling return marshal "+method.FullName);if(returned.HasMarshalInfo){CanonicalMarshallingContracts.Canonical(returned);descriptors++;}
                    foreach(var parameter in method.Parameters){Need(((parameter.Attributes&ParameterAttributes.HasFieldMarshal)!=0)==parameter.HasMarshalInfo,"dangling parameter marshal "+method.FullName);if(parameter.HasMarshalInfo){CanonicalMarshallingContracts.Canonical(parameter);descriptors++;}}
                }
            }
            Need(descriptors==493,"exact111field+64parameter+318source-return descriptors");
        }
        // Nonshipping player symbols proved by genuine Unity2020.3.33f1 Windows-x64 Mono Development ILPP.
        // Player define record SHA256: 63fa050112df24ef69eec7e645261fc1d08c090b8e23927270447e6af9be1478.
        static void RequireSupportedScope(string[] defines)
        {
            var defined=new HashSet<string>(defines??new string[0],StringComparer.Ordinal);
            bool editor=defined.Contains("UNITY_EDITOR")&&defined.Contains("UNITY_EDITOR_WIN")&&defined.Contains("UNITY_EDITOR_64")
                &&!defined.Contains("UNITY_EDITOR_LINUX")&&!defined.Contains("UNITY_EDITOR_OSX");
            bool conflictingPlayerPlatform=new[]{"UNITY_STANDALONE_LINUX","UNITY_STANDALONE_OSX","UNITY_ANDROID","UNITY_IOS","UNITY_WEBGL","UNITY_WSA","UNITY_PS4","UNITY_PS5","UNITY_XBOXONE","UNITY_GAMECORE","UNITY_SWITCH"}.Any(defined.Contains);
            bool developmentPlayer=!defined.Contains("UNITY_EDITOR")&&!defined.Contains("UNITY_EDITOR_WIN")&&!defined.Contains("UNITY_EDITOR_64")
                &&!defined.Contains("UNITY_EDITOR_OSX")&&!defined.Contains("UNITY_EDITOR_LINUX")
                &&defined.Contains("UNITY_STANDALONE")&&defined.Contains("UNITY_STANDALONE_WIN")&&defined.Contains("UNITY_64")
                &&defined.Contains("ENABLE_MONO")&&defined.Contains("DEVELOPMENT_BUILD")&&!conflictingPlayerPlatform;
            Need(!defined.Contains("ENABLE_IL2CPP")&&!defined.Contains("UNITY_ARM")&&!defined.Contains("UNITY_ARM64")&&(editor||developmentPlayer),
                "nonshipping Windows-x64 Editor or Windows-x64 Mono Development player validation scope only");
        }
        public static ProvenMarshallingOverlayResult Apply(ModuleDefinition target,ModuleDefinition raw,byte[] bytes,string expectedHash,string[] defines)
        {
            Need(target.Assembly.Name.Name=="Assembly-CSharp"&&raw.Assembly.Name.FullName==target.Assembly.Name.FullName,"exact core assembly identity");
            RequireSupportedScope(defines);
            string sourceHash;var rows=Read(bytes,expectedHash,out sourceHash);var current=Walk(target.Types).ToDictionary(t=>t.FullName);var original=Walk(raw.Types).ToDictionary(t=>t.FullName);
            var actions=new List<Action>();var unique=new HashSet<string>(StringComparer.Ordinal);var result=new ProvenMarshallingOverlayResult{SourceOverlayHash=sourceHash};
            foreach(var row in rows)
            {
                Need(original.ContainsKey(row.Owner)&&current.ContainsKey(row.Owner),"original-restored owner exists "+row.Owner);
                var a=original[row.Owner];var b=current[row.Owner];
                if(row.Kind==0)
                {
                    Need(row.Authority=="genuine_exactSDKsource_restored"&&row.SourceToken>>24==4,"genuine SDK field witness");
                    var fs=a.Fields.Where(f=>f.Name==row.Name&&f.FieldType.FullName==row.Type).Take(2).ToArray();Need(fs.Length==1,"unique original field");var source=fs[0];
                    Need(source.MetadataToken.ToUInt32()==row.RawProviderToken&&CanonicalMetadataSignatures.Type(source.FieldType)==row.RawCanonical,"pinned original-native to exact provider-token/scoped-field-type binding");
                    var ts=b.Fields.Where(f=>f.Name==row.Name&&CanonicalMetadataSignatures.Type(f.FieldType)==row.RawCanonical).Take(2).ToArray();Need(ts.Length==1,"unique full-scoped target field");var field=ts[0];
                    Need(unique.Add("F:"+row.Owner+":"+row.Name)&&source.Attributes==(FieldAttributes)row.Flags&&field.Attributes==source.Attributes&&(source.Attributes&FieldAttributes.HasFieldMarshal)!=0&&!source.HasMarshalInfo&&!field.HasMarshalInfo,"unchanged original field flags and missing descriptor");
                    actions.Add(()=>{source.MarshalInfo=CanonicalMarshallingContracts.Clone(row.Marshal);field.MarshalInfo=CanonicalMarshallingContracts.Clone(row.Marshal);Need(CanonicalMarshallingContracts.Canonical(source)==CanonicalMarshallingContracts.Canonical(field),"field descriptor equality");});result.Fields++;continue;
                }
                var rawMethod=Method(a,row);string canonical=CanonicalMetadataSignatures.Method(rawMethod);
                Need(rawMethod.MetadataToken.ToUInt32()==row.RawProviderToken&&canonical==row.RawCanonical,"pinned original-native to exact provider-token/full-scoped-method binding");
                var found=b.Methods.Where(m=>CanonicalMetadataSignatures.Method(m)==canonical).Take(2).ToArray();Need(found.Length==1,"unique original-scoped target method");var method=found[0];
                Need(rawMethod.Attributes==method.Attributes&&rawMethod.ImplAttributes==method.ImplAttributes,"original method/implementation flags unchanged");
                if(row.Kind==3)
                {
                    Need(row.Authority=="genuine_exactSDKsource_and_original_native_effective_binding"&&row.SourceToken>>24==6&&row.Owner=="Steamworks.NativeMethods","SDK native import authority");
                    Need(unique.Add("I:"+row.Owner+":"+canonical)&&rawMethod.Attributes==(MethodAttributes)row.Flags&&rawMethod.ImplAttributes==(MethodImplAttributes)row.ImplFlags&&rawMethod.IsPInvokeImpl&&method.IsPInvokeImpl&&rawMethod.RVA==0&&method.RVA==0&&!rawMethod.HasBody&&!method.HasBody&&rawMethod.PInvokeInfo==null&&method.PInvokeInfo==null,"only original empty unmapped extern eligible");
                    Need((row.Module=="steam_api64"||row.Module=="sdkencryptedappticket64")&&!string.IsNullOrEmpty(row.Entry)&&row.ImportFlags==512,"exact two SDK Win64 Cdecl modules and independently proved per-row entry identity");
                    actions.Add(()=>{rawMethod.PInvokeInfo=new PInvokeInfo((PInvokeAttributes)row.ImportFlags,row.Entry,Module(raw,row.Module));method.PInvokeInfo=new PInvokeInfo((PInvokeAttributes)row.ImportFlags,row.Entry,Module(target,row.Module));Need(CanonicalMarshallingContracts.PInvokeDescriptor(rawMethod.PInvokeInfo)==CanonicalMarshallingContracts.PInvokeDescriptor(method.PInvokeInfo),"ImplMap equality");});result.Imports++;continue;
                }
                bool compatibility=row.Authority=="Windowsx64_ABI_compatibility_not_original_blob_recovered";
                Need(compatibility||row.Authority=="genuine_exactSDKsource_restored","explicit descriptor authority");
                Need(compatibility?row.Owner=="KNBDGFKMGCP"&&row.SourceToken==0:row.SourceToken>>24==6,"descriptor source witness identity");
                Need(unique.Add((row.Kind==2?"R:":"P:")+row.Owner+":"+canonical+":"+row.Sequence),"duplicate descriptor owner");
                if(row.Kind==2)
                {
                    Need(!compatibility&&row.Sequence==0&&row.Flags==8192&&rawMethod.MethodReturnType.Attributes==method.MethodReturnType.Attributes&&((int)method.MethodReturnType.Attributes&~8192)==0&&!rawMethod.MethodReturnType.HasMarshalInfo&&!method.MethodReturnType.HasMarshalInfo,"SDK return descriptor/HasFieldMarshal source restoration");
                    actions.Add(()=>{rawMethod.MethodReturnType.Attributes=(ParameterAttributes)row.Flags;method.MethodReturnType.Attributes=(ParameterAttributes)row.Flags;rawMethod.MethodReturnType.MarshalInfo=CanonicalMarshallingContracts.Clone(row.Marshal);method.MethodReturnType.MarshalInfo=CanonicalMarshallingContracts.Clone(row.Marshal);Need(CanonicalMarshallingContracts.Canonical(rawMethod.MethodReturnType)==CanonicalMarshallingContracts.Canonical(method.MethodReturnType),"return descriptor equality");});result.SourceReturns++;
                }
                else
                {
                    Need(row.Sequence>=1&&row.Sequence<=method.Parameters.Count,"parameter sequence");var rp=rawMethod.Parameters[row.Sequence-1];var tp=method.Parameters[row.Sequence-1];
                    Need(rp.Attributes==(ParameterAttributes)row.Flags&&tp.Attributes==rp.Attributes&&(rp.Attributes&ParameterAttributes.HasFieldMarshal)!=0&&rp.Name==row.ParameterName&&tp.Name==rp.Name&&!rp.HasMarshalInfo&&!tp.HasMarshalInfo,"original parameter identity/flags unchanged");
                    if(compatibility)Need((row.Name=="AAEPLCHCEAK"&&row.Sequence==3&&rp.ParameterType.FullName=="System.UInt32&"&&(int)row.Marshal.NativeType==8)||(row.Name=="DLHPCKIHJKB"&&row.Sequence==2&&rp.ParameterType.FullName=="System.Guid"&&(int)row.Marshal.NativeType==43),"exact two reviewed Win64 compatibility rows");
                    actions.Add(()=>{rp.MarshalInfo=CanonicalMarshallingContracts.Clone(row.Marshal);tp.MarshalInfo=CanonicalMarshallingContracts.Clone(row.Marshal);Need(CanonicalMarshallingContracts.Canonical(rp)==CanonicalMarshallingContracts.Canonical(tp),"parameter descriptor equality");});result.Parameters++;if(compatibility)result.WindowsX64CompatibilityParameters++;
                }
            }
            Need(result.Fields==111&&result.Parameters==64&&result.SourceReturns==318&&result.Imports==819&&result.WindowsX64CompatibilityParameters==2,"complete reviewed overlay coverage");
            foreach(var action in actions)action();Coverage(target);Coverage(raw);return result;
        }
    }
}
