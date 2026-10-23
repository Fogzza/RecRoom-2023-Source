// Cecil metadata only: neither production donor nor original SDK CLR-loads.
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
static class InspectInitializer17
{
    static readonly List<ModuleDefinition> Modules=new List<ModuleDefinition>();
    static readonly HashSet<uint> Retargets=new HashSet<uint>();
    const string Bcl4="mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
    const string Bcl2="mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
    const string Subsystems="UnityEngine.SubsystemsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
    const string OriginalAlias="UnityEngine.Rendering.Universal.UniversalRenderPipeline/<>c";
    const string DonorAlias="UnityEngine.Rendering.Universal.UniversalRenderPipeline/OriginalCallbackBindings";
    static void Need(bool value,string why){if(!value)throw new Exception(why);}
    static string Name(string name){return name==DonorAlias?OriginalAlias:name;}
    static string Member(TypeReference owner,string name){if(owner.FullName!=DonorAlias||Assembly(owner)!="Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")return name;return name=="Singleton"?"<>9":name=="CachedComparison"?"<>9__32_0":name=="OriginalComparison"?"<.ctor>b__32_0":name=="OriginalLights"?"<.cctor>b__73_0":name;}
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> types){foreach(var t in types){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
    static IEnumerable<TypeDefinition> OwnedTypes(ModuleDefinition module)
    {
        var pseudo=module.Types.Where(t=>t.Name=="<Module>").ToArray();
        Need(pseudo.Length==1&&pseudo[0].DeclaringType==null&&pseudo[0].MetadataToken.ToUInt32()==0x02000001u&&pseudo[0].Namespace==string.Empty&&pseudo[0].BaseType==null,"Exactly one genuine top-level ECMA pseudoModule row per module");
        return Types(module.Types).Where(t=>!object.ReferenceEquals(t,pseudo[0]));
    }
    static string Assembly(TypeReference type)
    {
        var element=type;while(element is TypeSpecification specification)element=specification.ElementType;
        if(element.Scope is AssemblyNameReference assembly)return assembly.FullName;
        if(element.Scope is ModuleDefinition module)return module.Assembly.Name.FullName;
        throw new Exception("Unknown type scope "+type.FullName);
    }
    static string TypeKey(TypeReference type)
    {
        if(type is GenericParameter p)return(p.Type==GenericParameterType.Type?"!":"!!")+p.Position;
        // Exactly seven literal ECMA tags observed at all172 primitive
        // leaves of the114 actual called signatures. Their byte tags carry
        // value/reference kind; Cecil corlib/IsValueType projection is not an
        // encoded named-TypeRef contract. Named class/value types fall through.
        string primitiveName=null,primitiveKey=null;
        switch(type.MetadataType)
        {
            case MetadataType.Void:primitiveName="System.Void";primitiveKey="void";break;
            case MetadataType.Boolean:primitiveName="System.Boolean";primitiveKey="primitive-value:02:System.Boolean";break;
            case MetadataType.Int32:primitiveName="System.Int32";primitiveKey="primitive-value:08:System.Int32";break;
            case MetadataType.Single:primitiveName="System.Single";primitiveKey="primitive-value:0c:System.Single";break;
            case MetadataType.String:primitiveName="System.String";primitiveKey="primitive-reference:0e:System.String";break;
            case MetadataType.IntPtr:primitiveName="System.IntPtr";primitiveKey="primitive-value:18:System.IntPtr";break;
            case MetadataType.Object:primitiveName="System.Object";primitiveKey="primitive-reference:1c:System.Object";break;
        }
        if(primitiveKey!=null){Need(type.FullName==primitiveName&&(Assembly(type)==Bcl4||Assembly(type)==Bcl2),"Only proven seven literal primitive tags/fullnames in genuine strongnamed corlib contexts");return primitiveKey;}
        if(type is GenericInstanceType generic)return TypeKey(generic.ElementType)+"<"+string.Join(",",generic.GenericArguments.Select(TypeKey))+">";
        if(type is ArrayType array)return TypeKey(array.ElementType)+(array.IsVector?"[]":"["+string.Join(",",array.Dimensions.Select(d=>(d.LowerBound.HasValue?d.LowerBound.ToString():"")+":"+(d.UpperBound.HasValue?d.UpperBound.ToString():"")))+"]");
        if(type is ByReferenceType byref)return TypeKey(byref.ElementType)+"&";
        if(type is PointerType pointer)return TypeKey(pointer.ElementType)+"*";
        Need(!(type is TypeSpecification),"Unlisted type specification");return(type.IsValueType?"valuetype ":"class ")+"["+Assembly(type)+"]"+Name(type.FullName);
    }
    static string Sig(MethodReference method){if(method is GenericInstanceMethod generic)return Sig(generic.ElementMethod);return(method.HasThis?"instance ":"static ")+method.CallingConvention+"/"+method.GenericParameters.Count+" "+TypeKey(method.ReturnType)+"("+string.Join(",",method.Parameters.Select(p=>TypeKey(p.ParameterType)))+")";}
    static bool ExactListMethodVar0(TypeReference type,string scope)
    {
        if(!(type is GenericInstanceType list)||list.ElementType.FullName!="System.Collections.Generic.List`1"||Assembly(list.ElementType)!=scope||list.ElementType.IsValueType||list.GenericArguments.Count!=1)return false;
        return list.GenericArguments[0] is GenericParameter parameter&&parameter.Type==GenericParameterType.Method&&parameter.Position==0;
    }
    static bool SameCallee(MethodDefinition actual,MethodReference requested)
    {
        if(Sig(actual)==Sig(requested))return true;
        // One actual Csc/genuine API compile-retarget record. All other named
        // type scopes and class/value kinds remain under the strict Sig key.
        if(actual.Module!=Modules[4]||actual.MetadataToken.ToUInt32()!=0x06000047u||actual.DeclaringType.FullName!="UnityEngine.SubsystemManager"||Assembly(actual.DeclaringType)!=Subsystems||actual.Name!="GetInstances")return false;
        if(!(requested is GenericInstanceMethod instance)||instance.GenericArguments.Count!=1||instance.GenericArguments[0].FullName!="UnityEngine.XR.XRDisplaySubsystem"||Assembly(instance.GenericArguments[0])!="UnityEngine.XRModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"||instance.GenericArguments[0].IsValueType)return false;
        var reference=instance.ElementMethod;
        if(reference.Name!="GetInstances"||reference.DeclaringType.FullName!="UnityEngine.SubsystemManager"||Assembly(reference.DeclaringType)!=Subsystems||actual.HasThis||reference.HasThis||actual.ExplicitThis||reference.ExplicitThis||actual.CallingConvention!=MethodCallingConvention.Generic||reference.CallingConvention!=MethodCallingConvention.Generic||actual.GenericParameters.Count!=1||reference.GenericParameters.Count!=1||actual.Parameters.Count!=1||reference.Parameters.Count!=1||actual.ReturnType.MetadataType!=MetadataType.Void||reference.ReturnType.MetadataType!=MetadataType.Void||TypeKey(actual.ReturnType)!="void"||TypeKey(reference.ReturnType)!="void")return false;
        if(!ExactListMethodVar0(actual.Parameters[0].ParameterType,Bcl2)||!ExactListMethodVar0(reference.Parameters[0].ParameterType,Bcl4))return false;
        Retargets.Add(0x06000047u);return true;
    }
    static string OwnerKey(TypeReference type){return Assembly(type)+"::"+Name(type.FullName);}
    static string OwnerKey(ModuleDefinition module,string fullName){return module.Assembly.Name.FullName+"::"+Name(fullName);}
    static string MethodKey(MethodReference method){return TypeKey(method.DeclaringType)+"::"+Member(method.DeclaringType,method.Name)+" "+Sig(method);}
    static string FieldKey(FieldReference field){return TypeKey(field.DeclaringType)+"::"+Member(field.DeclaringType,field.Name)+" "+TypeKey(field.FieldType);}
    static TypeDefinition FindType(TypeReference reference)
    {
        var type=reference is GenericInstanceType generic?generic.ElementType:reference;
        var matches=Modules.Where(m=>m.Assembly.Name.FullName==Assembly(type)).SelectMany(m=>Types(m.Types)).Where(t=>t.FullName==Name(type.FullName)).ToArray();
        Need(matches.Length==1,"Unique pinned genuine/original type "+TypeKey(type));return matches[0];
    }
    static MethodDefinition FindMethodAt(TypeDefinition owner,MethodReference reference)
    {
        var name=Member(reference.DeclaringType,reference.Name);
        var matches=owner.Methods.Where(m=>m.Name==name&&SameCallee(m,reference)).ToArray();
        if(matches.Length==0)
        {
            Console.WriteLine("NO_MATCH requested="+MethodKey(reference)+"; current_owner="+TypeKey(owner)+"; actual_named_candidates="+string.Join(" | ",owner.Methods.Where(m=>m.Name==name).Select(m=>MethodKey(m))));
            if(owner.BaseType!=null)return FindMethodAt(FindType(owner.BaseType),reference);
        }
        Need(matches.Length==1,"Unique actual callee "+MethodKey(reference));return matches[0];
    }
    static MethodDefinition FindMethod(MethodReference reference){return FindMethodAt(FindType(reference.DeclaringType),reference);}
    static string Operand(object operand)
    {
        if(operand is MethodReference method)return MethodKey(method);
        if(operand is FieldReference field)return FieldKey(field);
        if(operand is TypeReference type)return TypeKey(type);
        if(operand is Instruction branch)return"branch:"+branch.Offset;
        if(operand is Instruction[] branches)return string.Join(",",branches.Select(i=>i.Offset));
        if(operand is VariableDefinition local)return"local:"+local.Index;
        if(operand is ParameterDefinition parameter)return"param:"+parameter.Index;
        return operand==null?"":operand.ToString();
    }
    static string[] Normal(MethodDefinition method){return method.Body.Instructions.Select(i=>i.OpCode.Code+" "+Operand(i.Operand)).ToArray();}
    static void PreBase(MethodDefinition method,string baseOwner,string[] names)
    {
        var instructions=method.Body.Instructions.ToArray();var calls=instructions.Select((i,n)=>new{i,n}).Where(v=>v.i.OpCode.Code==Code.Call&&v.i.Operand is MethodReference m&&m.Name==".ctor"&&m.DeclaringType.FullName==baseOwner).ToArray();
        Need(calls.Length==1,"One genuine base constructor "+method.FullName);int at=calls[0].n;
        var stores=instructions.Take(at).Where(i=>i.OpCode.Code==Code.Stfld).Select(i=>((FieldReference)i.Operand).Name).ToArray();Need(stores.SequenceEqual(names),"Exact initializers BEFORE base "+method.FullName);
        Need(!instructions.Skip(at+1).Any(i=>i.OpCode.Code==Code.Stfld),"No moved/repeated instance field assignment after base");
    }
    static int Main(string[] args)
    {
        try
        {
            Need(args.Length==9,"core urp coreDonor urpDonor genuineCore genuineXR genuineSubsystems mscorlib System.Core");
            var originalCore=ModuleDefinition.ReadModule(args[0]);var originalUrp=ModuleDefinition.ReadModule(args[1]);var coreDonor=ModuleDefinition.ReadModule(args[2]);var urpDonor=ModuleDefinition.ReadModule(args[3]);
            Modules.Add(originalCore);Modules.Add(originalUrp);for(int i=4;i<args.Length;i++)Modules.Add(ModuleDefinition.ReadModule(args[i]));
            Need(originalCore.Assembly.Name.FullName==coreDonor.Assembly.Name.FullName&&originalUrp.Assembly.Name.FullName==urpDonor.Assembly.Name.FullName,"Exact original two production assembly identities");
            var donors=new[]{coreDonor,urpDonor}.SelectMany(m=>OwnedTypes(m)).ToDictionary(t=>OwnerKey(t));var originals=Modules.Take(2).SelectMany(m=>OwnedTypes(m)).ToDictionary(t=>OwnerKey(t));
            Need(donors.Count==Types(coreDonor.Types).Count()+Types(urpDonor.Types).Count()-2&&originals.Count==Types(originalCore.Types).Count()+Types(originalUrp.Types).Count()-2,"Every real scoped owner retained, exactly two asserted pseudoModules excluded per pair");
            Console.WriteLine("OWNERS all_real_scoped_unique original="+originals.Count+" donor="+donors.Count+"; only_pseudoModule_excluded=true");
            // Generated from the complete frozen native/CLI report. Each row:
            // actual assembly, current MethodDef token, exact original owner/name,
            // donor alias name, native TypeDef flags. No overload/name discovery.
            var specs=new[]{
                /*EXACT_SPECS*/
            };
            int checkedMethods=0;
            foreach(var spec in specs)
            {
                var originalModule=spec.Item1=="Core"?originalCore:originalUrp;var original=(MethodDefinition)originalModule.LookupToken(checked((int)spec.Item2));
                Need(original.DeclaringType.FullName==spec.Item3&&original.Name==spec.Item4&&(uint)original.DeclaringType.Attributes==spec.Item6,"Exact original token/type flags including BeforeFieldInit "+original.FullName);
                var candidates=donors[OwnerKey(originalModule,spec.Item3)].Methods.Where(m=>m.Name==spec.Item5&&Sig(m)==Sig(original)).ToArray();Need(candidates.Length==1,"Unique original signature donor "+original.FullName);var donor=candidates[0];
                Need(original.Attributes==donor.Attributes&&original.ImplAttributes==donor.ImplAttributes&&original.HasThis==donor.HasThis&&original.ExplicitThis==donor.ExplicitThis&&original.CallingConvention==donor.CallingConvention&&donor.HasBody&&donor.Body.ExceptionHandlers.Count==0,"All original selected method contracts retained");
                foreach(var instruction in donor.Body.Instructions)
                {
                    if(instruction.Operand is FieldReference field)
                    {
                        var owner=FindType(field.DeclaringType);var matches=owner.Fields.Where(f=>f.Name==Member(field.DeclaringType,field.Name)&&TypeKey(f.FieldType)==TypeKey(field.FieldType)).ToArray();Need(matches.Length==1,"Exact owned field "+FieldKey(field));
                        bool isStatic=instruction.OpCode.Code==Code.Ldsfld||instruction.OpCode.Code==Code.Ldsflda||instruction.OpCode.Code==Code.Stsfld;Need(matches[0].IsStatic==isStatic,"Exact field static/instance usage");
                        var donorField=donors[OwnerKey(field.DeclaringType)].Fields.Single(f=>f.Name==field.Name);Need(matches[0].Attributes==donorField.Attributes,"Original field flags/readonly retained "+field.Name);
                    }
                    if(instruction.Operand is MethodReference method)
                    {
                        if(method is GenericInstanceMethod generic){Need(generic.GenericArguments.Count==generic.ElementMethod.GenericParameters.Count,"Exact MethodSpec arity");foreach(var argument in generic.GenericArguments)FindType(argument);}
                        var resolved=FindMethod(method);Need(SameCallee(resolved,method),"Exact original/genuine callee signature or sole pinned API parameter compile-retarget");
                        // Every original SDK callee must be selected, previously
                        // tested support, or the proven existing Object-only
                        // generated callback constructor. No return-stub call.
                        if(Modules.Take(2).Contains(resolved.Module))
                        {
                            bool selected=specs.Any(s=>s.Item3==resolved.DeclaringType.FullName&&s.Item4==resolved.Name&&Sig((MethodDefinition)(s.Item1=="Core"?originalCore:originalUrp).LookupToken(checked((int)s.Item2)))==Sig(resolved));
                            bool isSupport=(resolved.DeclaringType.FullName=="UnityEngine.Rendering.ProfilingSampler"&&new[]{"get_sampler","set_sampler","get_inlineSampler","set_inlineSampler","get_name","set_name"}.Contains(resolved.Name))||
                                (resolved.DeclaringType.FullName=="UnityEngine.Rendering.CameraCaptureBridge"&&resolved.Name=="set_enabled")||
                                (resolved.DeclaringType.FullName=="UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset"&&new[]{"get_msaaSampleCount","get_renderScale","get_renderFeatureset","get_postProcessing","get_supportsHDR","get_RecRoomQualityConfig"}.Contains(resolved.Name))||
                                (resolved.DeclaringType.FullName=="UnityEngine.Rendering.Universal.RenderingUtils"&&resolved.Name=="ClearSystemInfoCache")||
                                (resolved.DeclaringType.FullName==OriginalAlias&&new[]{".ctor","<.ctor>b__32_0","<.cctor>b__73_0"}.Contains(resolved.Name));
                            Need(selected||isSupport,"No assumed stub SDK callee "+resolved.FullName);
                        }
                    }
                    if(instruction.Operand is TypeReference type)FindType(type is ArrayType a?a.ElementType:type);
                }
                checkedMethods++;Console.WriteLine("BIND "+original.MetadataToken+" "+original.FullName+"; original_BeforeFieldInit="+original.DeclaringType.IsBeforeFieldInit+"; donor_type_flags_NOT_imported=true");
            }
            var profiling=donors[OwnerKey(coreDonor,"UnityEngine.Rendering.ProfilingSampler")];var oldProfiling=originals[OwnerKey(originalCore,profiling.FullName)];
            foreach(var name in new[]{"get_sampler","set_sampler","get_inlineSampler","set_inlineSampler","get_name","set_name"}){var a=oldProfiling.Methods.Single(m=>m.Name==name);var b=profiling.Methods.Single(m=>m.Name==name);Need(Sig(a)==Sig(b)&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&Normal(a).SequenceEqual(Normal(b)),"Existing real autoaccessor verbatim CIL "+name);}
            var support=new List<Tuple<string,string,string>>{Tuple.Create("UnityEngine.Rendering.CameraCaptureBridge","set_enabled","set_enabled"),Tuple.Create("UnityEngine.Rendering.Universal.RenderingUtils","ClearSystemInfoCache","ClearSystemInfoCache"),Tuple.Create(OriginalAlias,"<.ctor>b__32_0","OriginalComparison"),Tuple.Create(OriginalAlias,"<.cctor>b__73_0","OriginalLights"),Tuple.Create(OriginalAlias,".ctor",".ctor")};
            foreach(var name in new[]{"get_msaaSampleCount","get_renderScale","get_renderFeatureset","get_postProcessing","get_supportsHDR","get_RecRoomQualityConfig"})support.Add(Tuple.Create("UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset",name,name));
            foreach(var row in support){var originalOwner=row.Item1=="UnityEngine.Rendering.CameraCaptureBridge"?originalCore:originalUrp;var donorOwner=row.Item1=="UnityEngine.Rendering.CameraCaptureBridge"?coreDonor:urpDonor;var a=originals[OwnerKey(originalOwner,row.Item1)].Methods.Single(m=>m.Name==row.Item2);var b=donors[OwnerKey(donorOwner,row.Item1)].Methods.Single(m=>m.Name==row.Item3);Need(Sig(a)==Sig(b)&&a.Body.InitLocals==b.Body.InitLocals&&a.Body.Variables.Select(v=>TypeKey(v.VariableType)).SequenceEqual(b.Body.Variables.Select(v=>TypeKey(v.VariableType)))&&a.Body.ExceptionHandlers.Count==b.Body.ExceptionHandlers.Count&&a.Body.ExceptionHandlers.Count==0&&Normal(a).SequenceEqual(Normal(b)),"Existing tested support body CIL, not an assumed stub "+a.FullName);}
            PreBase(donors[OwnerKey(urpDonor,"UnityEngine.Rendering.Universal.RenderingUtils/StereoConstants")].Methods.Single(m=>m.Name==".ctor"),"System.Object",new[]{"viewProjMatrix","invViewMatrix","invProjMatrix","invViewProjMatrix","invCameraProjMatrix","worldSpaceCameraPos"});
            PreBase(donors[OwnerKey(urpDonor,"UnityEngine.Rendering.Universal.XRPass")].Methods.Single(m=>m.Name==".ctor"),"System.Object",new[]{"views","stereoEyeIndices","stereoProjectionMatrix","stereoViewMatrix","stereoCameraProjectionMatrix"});
            PreBase(donors[OwnerKey(urpDonor,"UnityEngine.Rendering.Universal.XRSystem")].Methods.Single(m=>m.Name==".ctor"),"System.Object",new[]{"emptyPass","framePasses","mirrorViewMaterialProperty"});
            PreBase(donors[OwnerKey(urpDonor,"UnityEngine.Rendering.Universal.UniversalRenderPipeline")].Methods.Single(m=>m.Name==".ctor"),"UnityEngine.Rendering.RenderPipeline",new[]{"cameraComparison"});
            var ru=donors[OwnerKey(urpDonor,"UnityEngine.Rendering.Universal.RenderingUtils")].Methods.Single(m=>m.Name==".cctor");var xp=donors[OwnerKey(urpDonor,"UnityEngine.Rendering.Universal.XRPass")].Methods.Single(m=>m.Name==".cctor");
            Need(ru.Body.Instructions.Any(i=>i.OpCode.Code==Code.Ldstr&&(string)i.Operand=="unity_StereoMatrixInvVP")&&!ru.Body.Instructions.Any(i=>i.OpCode.Code==Code.Ldstr&&(string)i.Operand=="unity_StereoMatrixIVP")&&xp.Body.Instructions.Any(i=>i.OpCode.Code==Code.Ldstr&&(string)i.Operand=="unity_StereoMatrixIVP")&&!xp.Body.Instructions.Any(i=>i.OpCode.Code==Code.Ldstr&&(string)i.Operand=="unity_StereoMatrixInvVP"),"Native IVP and InvVP distinction");
            Need(checkedMethods==17&&support.Count==11&&Retargets.SetEquals(new[]{0x06000047u}),"Exactly17 selected methods,11 existing support bodies and one pinned API parameter compile-retarget");Console.WriteLine("RESULT seventeen_exact_original_initializer_XR_bindings_passed_metadata_only; original_BeforeFieldInit_retained=true; initializers_before_base=true; existing_autoaccessor6_CIL_equal=true; support11_CIL_equal=true; production_donors_loaded=false; no_stub_SDK_callee=true");return 0;
        }
        catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}
        finally{foreach(var module in Modules)module.Dispose();}
    }
}
