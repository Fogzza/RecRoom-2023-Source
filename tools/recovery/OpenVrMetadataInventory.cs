using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using Mono.Cecil;

// Metadata reader only. The inspected modules are never loaded for execution.
static class Program
{
    static IEnumerable<TypeDefinition> Types(TypeDefinition type)
    { yield return type; foreach (var nested in type.NestedTypes) foreach (var t in Types(nested)) yield return t; }
    static object Marshal(MarshalInfo value)
    {
        if (value == null) return null;
        if (value is ArrayMarshalInfo a) return new { kind=value.GetType().Name, native_type=(int)value.NativeType, element_type=(int)a.ElementType, size=a.Size, index=a.SizeParameterIndex, multiplier=a.SizeParameterMultiplier };
        if (value is FixedArrayMarshalInfo f) return new { kind=value.GetType().Name, native_type=(int)value.NativeType, element_type=(int)f.ElementType, size=f.Size };
        if (value is FixedSysStringMarshalInfo s) return new { kind=value.GetType().Name, native_type=(int)value.NativeType, size=s.Size };
        if (value is CustomMarshalInfo c) return new { kind=value.GetType().Name, native_type=(int)value.NativeType, guid=c.Guid.ToString(), unmanaged_type=c.UnmanagedType, managed_type=c.ManagedType?.FullName, cookie=c.Cookie };
        if (value is SafeArrayMarshalInfo b) return new { kind=value.GetType().Name, native_type=(int)value.NativeType, element_type=(int)b.ElementType };
        return new { kind=value.GetType().Name, native_type=(int)value.NativeType };
    }
    static object Attributes(ICustomAttributeProvider p) => p.CustomAttributes.Select(a=>new { type=a.AttributeType.FullName, scope=a.AttributeType.Scope.Name, ctor=a.Constructor.FullName, args=a.ConstructorArguments.Select(x=>new { type=x.Type.FullName, value=Convert.ToString(x.Value) }).ToArray(), fields=a.Fields.Select(x=>new { name=x.Name, value=Convert.ToString(x.Argument.Value) }).ToArray() }).ToArray();
    static object Field(FieldDefinition f) => new { name=f.Name, token=f.MetadataToken.ToUInt32(), type=f.FieldType.FullName, scope=f.FieldType.Scope.Name, flags=(int)f.Attributes, has_constant=f.HasConstant, constant=f.HasConstant ? f.Constant : null, has_marshal=f.HasMarshalInfo, marshal=Marshal(f.MarshalInfo), attrs=Attributes(f) };
    static object Method(MethodDefinition m) => new { name=m.Name, token=m.MetadataToken.ToUInt32(), signature=m.FullName, flags=(int)m.Attributes, impl_flags=(int)m.ImplAttributes, has_body=m.HasBody, rva=m.RVA, pinvoke=m.PInvokeInfo==null?null:new { module=m.PInvokeInfo.Module.Name, entry=m.PInvokeInfo.EntryPoint, flags=(int)m.PInvokeInfo.Attributes }, return_type=m.ReturnType.FullName, return_scope=m.ReturnType.Scope.Name, return_flags=(int)m.MethodReturnType.Attributes, return_has_marshal=m.MethodReturnType.HasMarshalInfo, return_marshal=Marshal(m.MethodReturnType.MarshalInfo), parameters=m.Parameters.Select(p=>new { sequence=p.Index+1, name=p.Name, type=p.ParameterType.FullName, scope=p.ParameterType.Scope.Name, flags=(int)p.Attributes, has_marshal=p.HasMarshalInfo, marshal=Marshal(p.MarshalInfo) }).ToArray(), attrs=Attributes(m) };
    static int Main(string[] args)
    {
        var paths=JsonSerializer.Deserialize<string[]>(File.ReadAllText(args[0]));
        var result=new List<object>();
        foreach(var path in paths)
        {
            using(var module=ModuleDefinition.ReadModule(path,new ReaderParameters { ReadingMode=ReadingMode.Deferred }))
                result.Add(new { path, assembly=module.Assembly.Name.FullName, attrs=Attributes(module.Assembly), types=module.Types.SelectMany(Types).Select(t=>new { name=t.FullName, token=t.MetadataToken.ToUInt32(), flags=(int)t.Attributes, packing=t.PackingSize, size=t.ClassSize, fields=t.Fields.Select(Field).ToArray(), methods=t.Methods.Select(Method).ToArray(), attrs=Attributes(t) }).ToArray() });
            GC.Collect();
        }
        File.WriteAllText(args[1],JsonSerializer.Serialize(new { schema="readonly-openvr-metadata-inventory/v1", modules=result },new JsonSerializerOptions { WriteIndented=true }));
        return 0;
    }
}
