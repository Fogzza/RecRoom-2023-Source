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
            string name=original.DeclaringType.FullName;
            bool noArgument=new[]{"UnityEngine.SerializeField","UnityEngine.SerializeReference","System.Runtime.CompilerServices.IsReadOnlyAttribute"}.Contains(name);
            bool formerName=name=="UnityEngine.Serialization.FormerlySerializedAsAttribute";
            if((!noArgument&&!formerName)
                || original.Name!=".ctor" || !original.HasThis || original.ExplicitThis || original.CallingConvention!=MethodCallingConvention.Default
                || original.GenericParameters.Count!=0 || (noArgument && original.Parameters.Count!=0)
                || (formerName && (original.Parameters.Count!=1 || original.Parameters[0].ParameterType.MetadataType!=MetadataType.String || original.Parameters[0].ParameterType.FullName!="System.String"))
                || original.ReturnType.MetadataType!=MetadataType.Void || original.ReturnType.FullName!="System.Void")
                throw new InvalidDataException("Only exact serialization/readonly marker CLI primitive constructor signatures are permitted: "+original.FullName);
            var result=target.ImportReference(original);
            // No named class/interface/enum, generic argument, or constructor
            // declaration scope is normalized or aliased.
            result.ReturnType=target.TypeSystem.Void;
            if(formerName)result.Parameters[0].ParameterType=target.TypeSystem.String;
            return result;
        }
    }
}
