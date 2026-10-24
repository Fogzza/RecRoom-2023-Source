// Serialization-only provider metadata has erased corelib PKTs. ECMA VOID is
// a primitive signature byte, not a scoped named TypeRef. Rebind only the
// proved marker ctor's primitive VOID (and FormerlySerializedAs STRING only)
// to this target's TypeSystem.
using System;using System.IO;using System.Linq;using Mono.Cecil;
namespace RR23.MetadataRestoration
{
    public static class ExactCliMarkerConstructor
    {
        public static MethodReference Import(ModuleDefinition target, MethodReference original)
        {
            if (target == null || original == null || original is MethodSpecification)
                throw new InvalidDataException("An exact ordinary marker constructor reference is required");
            var owner = original.DeclaringType;
            if (owner == null || owner is TypeSpecification || owner.DeclaringType != null || owner.IsValueType || owner.HasGenericParameters)
                throw new InvalidDataException("Only a nonnested nongeneric reference-class marker declaration is permitted");
            string name=owner.FullName;
            bool noArgument=new[]{"UnityEngine.SerializeField","UnityEngine.SerializeReference","System.Runtime.CompilerServices.IsReadOnlyAttribute"}.Contains(name);
            bool formerName=name=="UnityEngine.Serialization.FormerlySerializedAsAttribute";
            if((!noArgument&&!formerName)
                || original.Name!=".ctor" || !original.HasThis || original.ExplicitThis || original.CallingConvention!=MethodCallingConvention.Default
                || original.GenericParameters.Count!=0 || (noArgument && original.Parameters.Count!=0)
                || (formerName && (original.Parameters.Count!=1 || original.Parameters[0].ParameterType.MetadataType!=MetadataType.String || original.Parameters[0].ParameterType.FullName!="System.String"))
                || original.ReturnType.MetadataType!=MetadataType.Void || original.ReturnType.FullName!="System.Void")
                throw new InvalidDataException("Only exact serialization/readonly marker CLI primitive constructor signatures are permitted: "+original.FullName);
            var declarationScope = owner.Scope as AssemblyNameReference;
            var declarationModule = owner.Scope as ModuleDefinition;
            if (declarationScope == null && declarationModule != null && declarationModule.Assembly != null)
                declarationScope = declarationModule.Assembly.Name;
            string identity = declarationScope == null ? null : declarationScope.FullName;
            bool unityMarker = name != "System.Runtime.CompilerServices.IsReadOnlyAttribute";
            bool approvedScope = unityMarker
                ? identity == "UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null" && (int)declarationScope.Attributes == 0
                : (identity == "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null"
                    || identity == "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    && (declarationScope.Attributes & ~AssemblyAttributes.PublicKey) == 0;
            if (!approvedScope || original.MethodReturnType.HasMarshalInfo || original.MethodReturnType.HasCustomAttributes
                || original.Parameters.Any(p => p.HasMarshalInfo || p.HasCustomAttributes))
                throw new InvalidDataException("Only the exact marker declaring assembly and unextended CLI primitive parameter metadata are permitted");
            // Import the validated named declaration only. Importing the whole
            // provider MethodRef first can register its erased primitive corelib.
            // Named declaration identities remain exact; no reference is removed.
            var result = new MethodReference(original.Name, target.TypeSystem.Void, target.ImportReference(owner)) {
                HasThis = original.HasThis, ExplicitThis = original.ExplicitThis, CallingConvention = original.CallingConvention };
            result.MethodReturnType.Name = original.MethodReturnType.Name;
            result.MethodReturnType.Attributes = original.MethodReturnType.Attributes;
            if (original.MethodReturnType.HasConstant) result.MethodReturnType.Constant = original.MethodReturnType.Constant;
            if (formerName) {
                var parameter = original.Parameters[0];
                var copied = new ParameterDefinition(parameter.Name, parameter.Attributes, target.TypeSystem.String);
                if (parameter.HasConstant) copied.Constant = parameter.Constant;
                result.Parameters.Add(copied);
            }
            return result;
        }
    }
}
