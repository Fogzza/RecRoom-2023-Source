// Uses the exact production MetadataReferenceReversal source, one manifest alias.
// Only a new diagnostic consumer is emitted. The raw SDK is read, never written.
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using RR23.MetadataRestoration;
public static class ReverseProjectedGenericNameConsumerv2
{
    const string Identity="RecRoom.Datastructures.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
    static void Need(bool v,string message){if(!v)throw new InvalidDataException(message);}
    static int Count(BinaryReader r,int limit){int n=r.ReadInt32();Need(n>=0&&n<=limit,"existing manifest count bound");return n;}
    static TypeReferenceAlias ManifestAlias(string path)
    {
        using(var stream=File.OpenRead(path))using(var r=new BinaryReader(stream,Encoding.UTF8,true))
        {
            Need(r.ReadString()=="RR23-METADATA-RESTORE-6"&&r.ReadString()=="Assembly-CSharp","exact existing whole-Core manifest prefix");
            for(int i=0;i<4;i++)r.ReadString();r.ReadBoolean();for(int i=0,n=Count(r,1000);i<n;i++)r.ReadString();
            var rows=new List<TypeReferenceAlias>();for(int i=0,n=Count(r,100000);i<n;i++)rows.Add(new TypeReferenceAlias{Assembly=r.ReadString(),OriginalFullName=r.ReadString(),CompiledFullName=r.ReadString()});
            var alias=rows.Single(x=>x.Assembly=="RecRoom.Datastructures.Runtime"&&x.OriginalFullName=="HHOBPMOCKMJ");
            Need(alias.CompiledFullName=="HHOBPMOCKMJ`1","the exact alias must already exist in the production manifest");return alias;
        }
    }
    static string[] Refs(ModuleDefinition m){return m.GetTypeReferences().Select(t=>t.MetadataToken+"|"+t.Scope+"|"+t.FullName).ToArray();}
    static string[] ScopedRefs(ModuleDefinition m){return m.GetTypeReferences().Select(t=>t.Scope+"|"+t.FullName).ToArray();}
    static MethodDefinition[] Methods(ModuleDefinition m){return m.Types.SelectMany(t=>t.Methods).ToArray();}
    static TypeReference Requested(ModuleDefinition m,string name)
    {
        Need(m.Assembly.Name.Name=="Recovery.ProjectedGenericConsumer"&&m.Types.Count==2,"same original minimal consumer assembly and two TypeDefs");
        var owner=m.Types.Single(t=>t.FullName=="Recovery.ProjectedGenericBinding.Consumer");
        Need(owner.Methods.Count==2&&!owner.Methods.Any(x=>x.IsConstructor),"same exact two original static consumer methods and no initializer");
        var method=owner.Methods.Single(x=>x.Name=="ProjectedClosedType");var token=method.Body.Instructions.Single(i=>i.OpCode.Code==Code.Ldtoken);
        var closed=token.Operand as GenericInstanceType;Need(closed!=null&&closed.GenericArguments.Count==1&&closed.GenericArguments[0].FullName=="UnityEngine.GameObject"&&closed.GenericArguments[0].Scope.Name=="UnityEngine.CoreModule","unchanged genuine GameObject type argument");
        var type=closed.ElementType;Need(type.FullName==name&&type.Scope.ToString()==Identity,"exact expected consumer generic name and original SDK assembly identity");
        Need(m.GetTypeReferences().Count(t=>t.FullName==name&&t.Scope.ToString()==Identity)==1,"one actual target TypeRef, not a definition or a guessed name match");return type;
    }
    static ReferenceReversalResult Reverse(ModuleDefinition m,TypeReferenceAlias[] aliases)
    {
        var result=MetadataReferenceReversal.Reverse(m,aliases,new MethodReferenceAlias[0],new FieldReferenceAlias[0]);
        result.CompleteSignatureRestoration();result.VerifyFinalNames();return result;
    }
    static string[] Controls(string input,TypeReferenceAlias real)
    {
        var cases=new List<string>();
        foreach(var item in new[]{new[]{"wrong-assembly","Other.SDK",real.OriginalFullName,real.CompiledFullName},new[]{"wrong-compiled-name",real.Assembly,real.OriginalFullName,"HHOBPMOCKMJ`2"},new[]{"wrong-namespace",real.Assembly,real.OriginalFullName,"Other.HHOBPMOCKMJ`1"}})
        {
            using(var m=ModuleDefinition.ReadModule(input,new ReaderParameters{ReadSymbols=false,InMemory=true}))
            {
                var before=Refs(m);var result=Reverse(m,new[]{new TypeReferenceAlias{Assembly=item[1],OriginalFullName=item[2],CompiledFullName=item[3]}});
                Need(result.TypeReferences==0&&result.MethodReferences==0&&result.FieldReferences==0&&Refs(m).SequenceEqual(before),"nonmatching aliases cannot alter a reference");cases.Add(item[0]);
            }
        }
        using(var m=ModuleDefinition.ReadModule(input,new ReaderParameters{ReadSymbols=false,InMemory=true}))
        {
            var before=Refs(m);var result=Reverse(m,new TypeReferenceAlias[0]);Need(result.TypeReferences==0&&Refs(m).SequenceEqual(before),"no alias means no inferred suffix removal");cases.Add("missing-alias-no-inference");
        }
        using(var m=ModuleDefinition.ReadModule(input,new ReaderParameters{ReadSymbols=false,InMemory=true}))
        {
            bool refused=false;try{Reverse(m,new[]{real,real});}catch(InvalidDataException){refused=true;}Need(refused,"production reversal must reject duplicate exact alias selectors");cases.Add("duplicate-alias-refused");
        }
        using(var m=ModuleDefinition.ReadModule(input,new ReaderParameters{ReadSymbols=false,InMemory=true}))
        {
            var type=Requested(m,"HHOBPMOCKMJ`1");type.Namespace="Other";var before=Refs(m);var result=Reverse(m,new[]{real});Need(result.TypeReferences==0&&Refs(m).SequenceEqual(before),"same short name in another namespace is untouched");cases.Add("foreign-consumer-namespace-untouched");
        }
        using(var m=ModuleDefinition.ReadModule(input,new ReaderParameters{ReadSymbols=false,InMemory=true}))
        {
            var type=Requested(m,"HHOBPMOCKMJ`1");type.Scope=new AssemblyNameReference("Other.SDK",new Version(0,0,0,0));var before=Refs(m);var result=Reverse(m,new[]{real});Need(result.TypeReferences==0&&Refs(m).SequenceEqual(before),"same name in another assembly is untouched");cases.Add("foreign-consumer-assembly-untouched");
        }
        return cases.ToArray();
    }
    public static int Main(string[] args)
    {
        try
        {
            Need(args.Length==5&&!File.Exists(args[3])&&!File.Exists(args[4]),"manifest raw-SDK actual-consumer fresh-output fresh-report");
            var alias=ManifestAlias(args[0]);var controls=Controls(args[2],alias);Need(controls.Length==7,"seven actual production-reversal selector controls");
            using(var raw=ModuleDefinition.ReadModule(args[1],new ReaderParameters{ReadSymbols=false,InMemory=true}))
            using(var m=ModuleDefinition.ReadModule(args[2],new ReaderParameters{ReadSymbols=false,InMemory=true}))
            {
                var definition=raw.Types.Single(t=>t.FullName=="HHOBPMOCKMJ");Need(raw.Assembly.FullName==Identity&&definition.MetadataToken.ToUInt32()==0x02000032&&definition.GenericParameters.Count==1,"unchanged original raw SDK definition/token/arity");
                var target=Requested(m,"HHOBPMOCKMJ`1");var all=Methods(m);var tokens=all.Select(x=>x.MetadataToken.ToUInt32()).ToArray();var safety=BodyAndSymbolSafety.Capture(all);var originalIL=safety.CaptureNormalized(all);var originalRefs=Refs(m);string originalMetadata=MetadataRoundTripSafety.Fingerprint(m);Guid mvid=m.Mvid;
                var result=Reverse(m,new[]{alias});Need(result.TypeReferences==1&&result.MethodReferences==0&&result.FieldReferences==0&&result.MethodSignatureTypes==0,"exact one existing manifest-authorized TypeRef inverse only");Requested(m,"HHOBPMOCKMJ");safety.VerifyObjectIdentity(all);
                // Undo only that exact TypeRef name in memory to prove every
                // other metadata, definition, instruction, local and scope.
                target.Name="HHOBPMOCKMJ`1";Need(Refs(m).SequenceEqual(originalRefs)&&MetadataRoundTripSafety.Fingerprint(m)==originalMetadata&&safety.CaptureNormalized(all).SequenceEqual(originalIL),"all metadata/IL outside the one authorized reference name unchanged");target.Name="HHOBPMOCKMJ";
                var expectedRefs=Refs(m);var expectedScoped=ScopedRefs(m);Need(expectedScoped.Length==9&&expectedScoped.Distinct(StringComparer.Ordinal).Count()==9,"exact nine distinct original consumer reference identities");
                // The preserved v1 failure independently proved this precise
                // Cecil table permutation. Typed uses are verified below by
                // canonical metadata and every normalized instruction/operand.
                int[] originalIndicesInEmittedOrder={4,5,6,7,8,0,1,2,3};
                var expectedEmittedScoped=originalIndicesInEmittedOrder.Select(i=>expectedScoped[i]).ToArray();
                var expectedIL=safety.CaptureNormalized(all);string expectedMetadata=MetadataRoundTripSafety.Fingerprint(m);m.Write(args[3],new WriterParameters{WriteSymbols=false});
                using(var emitted=ModuleDefinition.ReadModule(args[3],new ReaderParameters{ReadSymbols=false,InMemory=true}))
                {
                    Requested(emitted,"HHOBPMOCKMJ");var methods=Methods(emitted);var actualScoped=ScopedRefs(emitted);
                    bool sameMvid=emitted.Mvid==mvid,sameTokens=methods.Select(x=>x.MetadataToken.ToUInt32()).SequenceEqual(tokens),sameMetadata=MetadataRoundTripSafety.Fingerprint(emitted)==expectedMetadata;
                    bool sameScopedBijection=actualScoped.Length==9&&actualScoped.Distinct(StringComparer.Ordinal).Count()==9&&actualScoped.OrderBy(x=>x,StringComparer.Ordinal).SequenceEqual(expectedScoped.OrderBy(x=>x,StringComparer.Ordinal));
                    bool exactProvenPermutation=actualScoped.SequenceEqual(expectedEmittedScoped);
                    File.WriteAllLines(args[4]+".gate-details.txt",new[]{"MVID_unchanged="+sameMvid,"MethodDef_tokens_unchanged="+sameTokens,"metadata_fingerprint_unchanged="+sameMetadata,"all_nine_scoped_TypeRefs_bijective="+sameScopedBijection,"exact_independently_proven_TypeRef_permutation="+exactProvenPermutation}.Concat(expectedRefs.Select(x=>"expected_original_row="+x)).Concat(Refs(emitted).Select(x=>"actual_emitted_row="+x)));
                    Need(sameMvid&&sameTokens&&sameMetadata&&sameScopedBijection&&exactProvenPermutation,"emitted individual metadata gates and exact proven nine-reference table permutation");safety.VerifyEmitted(expectedIL,methods);
                    File.WriteAllLines(args[4],new[]{"schema=production-manifest-authorized-consumer-reference-inverse/v2","status=one_existing_production_TypeRef_inverse_emitted_metadata_and_all_IL_preserved","original_requested_type=HHOBPMOCKMJ`1","requested_type=HHOBPMOCKMJ","requested_scope="+Identity,"raw_type=HHOBPMOCKMJ","raw_scope="+raw.Assembly.FullName,"raw_mvid="+raw.Mvid,"raw_generic_parameter_count=1","consumer_mvid="+emitted.Mvid,"type_reference_reversals=1","method_reference_reversals=0","field_reference_reversals=0","production_reversal_controls="+controls.Length,"control_names="+string.Join(",",controls),"all_consumer_IL_and_other_metadata_preserved=true","exact_proven_nine_TypeRef_permutation=true","raw_SDK_written=false","metadata_only_no_game_or_SDK_execution=true"});
                }
            }
            return 0;
        }
        catch(Exception error){Console.Error.WriteLine(error);return 1;}
    }
}
