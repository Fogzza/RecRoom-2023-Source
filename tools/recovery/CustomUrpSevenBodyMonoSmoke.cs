// Diagnostic only. Actual original SDK types and genuine Unity engine, no game root.
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public sealed class CustomUrpSevenBodyMonoSmoke : MonoBehaviour
{
    [Serializable] public sealed class TypeRow { public int token;public string name; }
    [Serializable] public sealed class FieldRow { public int token;public string owner,name,type; }
    [Serializable] public sealed class MethodRow { public int token,arity,callconv;public string owner,name,return_type;public string[] parameters; }
    [Serializable] public sealed class RefRow { public int token;public string owner,name; }
    [Serializable] public sealed class Expected { public string assembly_full_name;public string[] referenced_assemblies;public TypeRow[] types;public FieldRow[] fields;public MethodRow[] methods;public RefRow[] added_method_refs; }
    [Serializable] public sealed class Result
    {
        public string schema="actual-original-custom-URP-seven-body-Mono-binding-smoke/v1",status="starting",unity_version,platform,assembly_full_name;
        public bool mono_runtime,Main_modified=false,working_renderer_claimed=false,constructors_Dispose_or_frame_executed=false;
        public int types,fields,methods,added_method_refs,start_frame,end_frame;
        public string[] checks,errors,declared_assembly_references,loaded_dependency_identities;
    }
    static readonly BindingFlags All=BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance|BindingFlags.DeclaredOnly;
    readonly List<string> checks=new List<string>(),errors=new List<string>();Result result=new Result();
    static string Arg(string name){var a=Environment.GetCommandLineArgs();for(int i=0;i+1<a.Length;i++)if(a[i]==name)return a[i+1];throw new ArgumentException("Missing "+name);}
    void Need(bool value,string message){if(!value)throw new InvalidOperationException(message);}
    void Check(bool value,string name){Need(value,name);checks.Add(name);}
    static string Name(Type t){return t.FullName.Replace('+','/');}
    static string Canon(Type t)
    {
        var primitive=new Dictionary<Type,string>{{typeof(void),"void"},{typeof(bool),"bool"},{typeof(char),"char"},{typeof(sbyte),"sbyte"},{typeof(byte),"byte"},{typeof(short),"int16"},{typeof(ushort),"uint16"},{typeof(int),"int32"},{typeof(uint),"uint32"},{typeof(long),"int64"},{typeof(ulong),"uint64"},{typeof(float),"float"},{typeof(double),"double"},{typeof(string),"string"},{typeof(object),"object"},{typeof(IntPtr),"IntPtr"},{typeof(UIntPtr),"UIntPtr"},{typeof(TypedReference),"TypedReference"}};
        if(primitive.TryGetValue(t,out var p))return p;
        if(t.IsByRef)return "ref("+Canon(t.GetElementType())+")";
        if(t.IsPointer)return "ptr("+Canon(t.GetElementType())+")";
        if(t.IsArray)return t.GetArrayRank()==1&&t==t.GetElementType().MakeArrayType()?"szarray("+Canon(t.GetElementType())+")":"array("+Canon(t.GetElementType())+","+t.GetArrayRank()+")";
        if(t.IsGenericParameter)return (t.DeclaringMethod==null?"!":"!!")+t.GenericParameterPosition;
        Type def=t.IsGenericType?t.GetGenericTypeDefinition():t;
        string value=(t.IsValueType?"valuetype ":"class ")+"["+def.Assembly.GetName().Name+"]"+Name(def);
        return t.IsGenericType?value+"<"+string.Join(",",t.GetGenericArguments().Select(Canon))+">":value;
    }
    static object Call(MethodInfo method,object target,params object[] args){try{return method.Invoke(target,args);}catch(TargetInvocationException e){throw e.InnerException;}}
    static FieldInfo Field(Type t,string name){return t.GetField(name,All)??throw new MissingFieldException(t.FullName,name);}
    static MethodInfo Method(Type t,string name){return t.GetMethods(All).Single(m=>m.Name==name);}
    void Binding(Expected expected)
    {
        Assembly a=typeof(UniversalRenderPipelineAsset).Assembly;result.assembly_full_name=a.FullName;Need(a.FullName==expected.assembly_full_name,"Actual exact custom URP identity");
        var types=a.GetTypes();Need(types.Length==expected.types.Length&&types.Length==298,"All298 actual non-global types loaded");
        var byType=types.ToDictionary(t=>t.MetadataToken);var byField=types.SelectMany(t=>t.GetFields(All)).ToDictionary(f=>f.MetadataToken);
        var methodList=new List<MethodBase>();foreach(var t in types){methodList.AddRange(t.GetMethods(All));methodList.AddRange(t.GetConstructors(All));if(t.TypeInitializer!=null&&!methodList.Any(m=>m.MetadataToken==t.TypeInitializer.MetadataToken))methodList.Add(t.TypeInitializer);}
        var byMethod=methodList.ToDictionary(m=>m.MetadataToken);Need(byField.Count==2015&&byMethod.Count==1616,"All2015 fields and1616 methods present after finite token reindex");
        foreach(var row in expected.types)Need(byType.TryGetValue(row.token,out var t)&&Name(t)==row.name,"Exact native-emitted TypeDef token/owner identity "+row.token);
        foreach(var row in expected.fields)Need(byField.TryGetValue(row.token,out var f)&&Name(f.DeclaringType)==row.owner&&f.Name==row.name&&Canon(f.FieldType)==row.type,"Exact native-emitted scoped field binding "+row.token);
        foreach(var row in expected.methods)
        {
            Need(byMethod.TryGetValue(row.token,out var m)&&Name(m.DeclaringType)==row.owner&&m.Name==row.name,"Exact native-emitted method token/owner/name "+row.token);
            Need((m.IsGenericMethod?m.GetGenericArguments().Length:0)==row.arity&&((m.IsStatic?0:32)|(m.IsGenericMethod?16:0)|((m.CallingConvention&CallingConventions.ExplicitThis)!=0?64:0))==row.callconv,"Exact original method arity/calling convention");
            Need((m is MethodInfo info?Canon(info.ReturnType):"void")==row.return_type&&m.GetParameters().Select(p=>Canon(p.ParameterType)).SequenceEqual(row.parameters),"Every original parameter/return type resolves in actual matching Mono "+row.token);
        }
        foreach(var row in expected.added_method_refs){var m=a.ManifestModule.ResolveMethod(row.token);Need(Name(m.DeclaringType)==row.owner&&m.Name==row.name,"Actual newly imported Unity/BCL MemberRef binding");}
        result.declared_assembly_references=a.GetReferencedAssemblies().Select(v=>v.FullName).ToArray();Need(result.declared_assembly_references.SequenceEqual(expected.referenced_assemblies),"Exact declared full assembly reference identities/order remain unchanged");
        result.loaded_dependency_identities=AppDomain.CurrentDomain.GetAssemblies().Where(v=>expected.referenced_assemblies.Any(r=>r.Split(',')[0]==v.GetName().Name)).Select(v=>v.FullName).OrderBy(v=>v,StringComparer.Ordinal).ToArray();
        result.types=types.Length;result.fields=byField.Count;result.methods=byMethod.Count;result.added_method_refs=expected.added_method_refs.Length;
        Check(true,"298_original_types_2015_fields_1616_methods_exact_runtime_binding");Check(expected.added_method_refs.Length==6,"six_genuine_Unity_BCL_imported_operands_resolved_without_invocation");Check(true,"original_declared_full_AssemblyRef_identities_order_preserved");
    }
    IEnumerator Start()
    {
        result.start_frame=Time.frameCount;result.unity_version=Application.unityVersion;result.platform=Application.platform.ToString();result.mono_runtime=Type.GetType("Mono.Runtime")!=null;
        Application.logMessageReceived+=Observe;
        UniversalRenderPipelineAsset asset=null;CustomUrpSmokeRendererData data=null;
        try
        {
            Check(result.mono_runtime&&result.unity_version=="2020.3.33f1"&&Application.platform==RuntimePlatform.WindowsPlayer,"actual_matching_Windows_Mono_engine");
            var text=Resources.Load<TextAsset>("CustomUrpBindingExpected");Need(text!=null,"Pinned original binding manifest Resources present");Binding(JsonUtility.FromJson<Expected>(text.text));
            Check(GraphicsSettings.currentRenderPipeline==null,"genuine_Builtin_pipeline_precondition");
            var t=typeof(UniversalRenderPipelineAsset);var cache=Field(t,"m_Renderers");var list=Field(t,"m_RendererDataList");var create=Method(t,"CreateRenderers");var destroy=Method(t,"DestroyRenderers");var destroyOne=Method(t,"DestroyRenderer");var factory=Method(t,"CreatePipeline");
            asset=ScriptableObject.CreateInstance<UniversalRenderPipelineAsset>();Need(asset!=null,"Actual SDK ScriptableObject allocated");
            Field(t,"m_DefaultRendererIndex").SetValue(asset,0);Field(t,"k_AssetVersion").SetValue(asset,1);Field(t,"k_AssetPreviousVersion").SetValue(asset,0);list.SetValue(asset,null);
            Check(Call(factory,asset)==null&&((ScriptableRendererData[])list.GetValue(asset)).Length==1,"original_CreatePipeline_null_list_allocates_one_then_version_mismatch_returns_null");
            list.SetValue(asset,new ScriptableRendererData[1]);Check(Call(factory,asset)==null,"original_CreatePipeline_existing_missing_default_version_mismatch_returns_null");
            cache.SetValue(asset,null);Call(destroy,asset);Check(cache.GetValue(asset)==null,"original_DestroyRenderers_null_cache_returns");
            object[] byref={null};Call(destroyOne,asset,byref);Check(byref[0]==null,"original_DestroyRenderer_null_ref_returns_without_Dispose");
            list.SetValue(asset,new ScriptableRendererData[0]);cache.SetValue(asset,null);Call(create,asset);var first=(ScriptableRenderer[])cache.GetValue(asset);Check(first!=null&&first.Length==0,"original_CreateRenderers_allocates_empty_cache");
            Call(create,asset);Check(ReferenceEquals(first,cache.GetValue(asset)),"original_CreateRenderers_reuses_same_length_empty_cache");
            cache.SetValue(asset,new ScriptableRenderer[2]);Call(create,asset);var resized=(ScriptableRenderer[])cache.GetValue(asset);Check(resized.Length==0&&!ReferenceEquals(first,resized),"original_CreateRenderers_resizes_null_only_cache_no_Dispose");
            list.SetValue(asset,new ScriptableRendererData[2]);Call(create,asset);var missing=(ScriptableRenderer[])cache.GetValue(asset);Check(missing.Length==2&&missing.All(v=>v==null),"original_CreateRenderers_genuine_Unity_null_entries_skipped");
            data=ScriptableObject.CreateInstance<CustomUrpSmokeRendererData>();Need(data!=null,"Test-only original SDK subclass allocated");
            var invalidated=Field(typeof(ScriptableRendererData),"<isInvalidated>k__BackingField");var internalCreate=Method(typeof(ScriptableRendererData),"InternalCreateRenderer");invalidated.SetValue(data,true);
            Check(Call(internalCreate,data)==null&&data.calls==1&&!data.flag_at_callback&&!((bool)invalidated.GetValue(data)),"original_InternalCreateRenderer_clears_flag_before_actual_virtual_dispatch");
            invalidated.SetValue(data,true);data.throw_marker=true;bool threw=false;try{Call(internalCreate,data);}catch(CustomUrpSmokeMarker){threw=true;}
            Check(threw&&data.calls==2&&!data.flag_at_callback&&!((bool)invalidated.GetValue(data)),"original_InternalCreateRenderer_propagates_callback_exception_after_flag_clear");data.throw_marker=false;
            list.SetValue(asset,new ScriptableRendererData[]{data});Call(create,asset);Check(data.calls==3&&((ScriptableRenderer[])cache.GetValue(asset)).Length==1&&((ScriptableRenderer[])cache.GetValue(asset))[0]==null,"original_CreateRenderers_calls_real_InternalCreateRenderer_and_stores_callback_null");
            Call(destroy,asset);Check(((ScriptableRenderer[])cache.GetValue(asset))[0]==null,"original_DestroyRenderers_null_slot_preserves_array");
            Check(Call(Method(typeof(UniversalRenderPipeline),"get_asset"),null)==null,"original_pipeline_asset_safe_as_current_builtin_null");
            Check(Method(typeof(ForwardRendererData),"Create").ReturnType==typeof(ScriptableRenderer)&&typeof(ForwardRenderer).GetConstructor(new[]{typeof(ForwardRendererData)})!=null,"original_ForwardRenderer_factory_constructor_contract_bound_not_executed");
            Check(GraphicsSettings.currentRenderPipeline==null,"global_pipeline_unchanged_no_renderer_constructor_Dispose_or_frame_entered");
            result.status="actual_original_URP_metadata_binding_and_safe_seven_body_paths_passed";
        }
        catch(Exception e){errors.Add(e.ToString());result.status="failed";}
        finally
        {
            if(data!=null)Destroy(data);if(asset!=null)Destroy(asset);
        }
        yield return null;yield return null;
        Application.logMessageReceived-=Observe;result.end_frame=Time.frameCount;result.checks=checks.ToArray();result.errors=errors.ToArray();if(errors.Count!=0)result.status="failed";
        bool saved=true;try{File.WriteAllText(Path.GetFullPath(Arg("-urpSmokeResult")),JsonUtility.ToJson(result,true));}catch(Exception e){Debug.LogException(e);saved=false;}
        Application.Quit(!saved?2:result.status=="actual_original_URP_metadata_binding_and_safe_seven_body_paths_passed"?0:1);
    }
    void Observe(string text,string stack,LogType type){if(type==LogType.Error||type==LogType.Exception||type==LogType.Assert)errors.Add(type+": "+text+"\n"+stack);}
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]static void Boot(){new GameObject("OriginalCustomUrpSafeSmoke").AddComponent<CustomUrpSevenBodyMonoSmoke>();}
}

public sealed class CustomUrpSmokeMarker : Exception {}
public sealed class CustomUrpSmokeRendererData : ScriptableRendererData
{
    public int calls;public bool throw_marker,flag_at_callback;
    protected override ScriptableRenderer Create()
    {
        calls++;flag_at_callback=(bool)typeof(ScriptableRendererData).GetField("<isInvalidated>k__BackingField",BindingFlags.Instance|BindingFlags.NonPublic).GetValue(this);
        if(throw_marker)throw new CustomUrpSmokeMarker();return null;
    }
}
