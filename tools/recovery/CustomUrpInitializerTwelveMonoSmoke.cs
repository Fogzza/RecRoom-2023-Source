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
        public string schema="actual-original-custom-URP-initializer12-plus-seven-Mono-binding-smoke/v1",status="starting",unity_version,platform,assembly_full_name;
        public bool mono_runtime,Main_modified=false,working_renderer_claimed=false,constructors_Dispose_or_frame_executed=false;
        public int types,fields,methods,added_method_refs,core_types,core_fields,core_methods,core_added_method_refs,start_frame,end_frame;
        public string[] checks,errors,declared_assembly_references,loaded_dependency_identities,core_declared_assembly_references,core_loaded_dependency_identities;
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
    void Binding(Expected expected,bool core=false)
    {
        Assembly a=core?typeof(CameraCaptureBridge).Assembly:typeof(UniversalRenderPipelineAsset).Assembly;if(!core)result.assembly_full_name=a.FullName;Need(a.FullName==expected.assembly_full_name,"Actual exact custom URP identity");
        var types=a.GetTypes();Need(types.Length==expected.types.Length&&types.Length==(core?278:298),"All298 actual non-global types loaded");
        var byType=types.ToDictionary(t=>t.MetadataToken);var byField=types.SelectMany(t=>t.GetFields(All)).ToDictionary(f=>f.MetadataToken);
        var methodList=new List<MethodBase>();foreach(var t in types){methodList.AddRange(t.GetMethods(All));methodList.AddRange(t.GetConstructors(All));if(t.TypeInitializer!=null&&!methodList.Any(m=>m.MetadataToken==t.TypeInitializer.MetadataToken))methodList.Add(t.TypeInitializer);}
        var byMethod=methodList.ToDictionary(m=>m.MetadataToken);Need(byField.Count==(core?897:2015)&&byMethod.Count==(core?1695:1616),"All2015 fields and1616 methods present after finite token reindex");
        foreach(var row in expected.types)Need(byType.TryGetValue(row.token,out var t)&&Name(t)==row.name,"Exact native-emitted TypeDef token/owner identity "+row.token);
        foreach(var row in expected.fields)Need(byField.TryGetValue(row.token,out var f)&&Name(f.DeclaringType)==row.owner&&f.Name==row.name&&Canon(f.FieldType)==row.type,"Exact native-emitted scoped field binding "+row.token);
        foreach(var row in expected.methods)
        {
            Need(byMethod.TryGetValue(row.token,out var m)&&Name(m.DeclaringType)==row.owner&&m.Name==row.name,"Exact native-emitted method token/owner/name "+row.token);
            Need((m.IsGenericMethod?m.GetGenericArguments().Length:0)==row.arity&&((m.IsStatic?0:32)|(m.IsGenericMethod?16:0)|((m.CallingConvention&CallingConventions.ExplicitThis)!=0?64:0))==row.callconv,"Exact original method arity/calling convention");
            Need((m is MethodInfo info?Canon(info.ReturnType):"void")==row.return_type&&m.GetParameters().Select(p=>Canon(p.ParameterType)).SequenceEqual(row.parameters),"Every original parameter/return type resolves in actual matching Mono "+row.token);
        }
        foreach(var row in expected.added_method_refs){var m=a.ManifestModule.ResolveMethod(row.token);Need(Name(m.DeclaringType.IsGenericType?m.DeclaringType.GetGenericTypeDefinition():m.DeclaringType)==row.owner&&m.Name==row.name,"Actual newly imported Unity/BCL MemberRef binding");}
        var declared=a.GetReferencedAssemblies().Select(v=>v.FullName).ToArray();Need(declared.SequenceEqual(expected.referenced_assemblies),"Exact declared full assembly reference identities/order remain unchanged");
        var loaded=AppDomain.CurrentDomain.GetAssemblies().Where(v=>expected.referenced_assemblies.Any(r=>r.Split(',')[0]==v.GetName().Name)).Select(v=>v.FullName).OrderBy(v=>v,StringComparer.Ordinal).ToArray();
        if(core)
        {
            result.core_types=types.Length;result.core_fields=byField.Count;result.core_methods=byMethod.Count;result.core_added_method_refs=expected.added_method_refs.Length;result.core_declared_assembly_references=declared;result.core_loaded_dependency_identities=loaded;
            Check(expected.added_method_refs.Length==1,"278_Core_types_897_fields_1695_methods_one_imported_ctor_and_declared_scopes_bound");
        }
        else
        {
            result.types=types.Length;result.fields=byField.Count;result.methods=byMethod.Count;result.added_method_refs=expected.added_method_refs.Length;result.declared_assembly_references=declared;result.loaded_dependency_identities=loaded;
            Check(true,"298_original_types_2015_fields_1616_methods_exact_runtime_binding");Check(expected.added_method_refs.Length==12,"twelve_genuine_Unity_BCL_imported_operands_resolved_without_invocation");Check(true,"original_declared_full_AssemblyRef_identities_order_preserved");
        }
    }
    // Additional original12 observations; only called inside the real player.
    void InitializerPrerequisites(UniversalRenderPipelineAsset asset)
    {
        var capture=typeof(CameraCaptureBridge);var dictionary=Field(capture,"actionDict");var captured=dictionary.GetValue(null);
        Check(captured!=null&&((System.Collections.IDictionary)captured).Count==0&&!CameraCaptureBridge.enabled,"original_capture_dictionary_cctor_empty_and_enabled_false");
        CameraCaptureBridge.enabled=true;Check(CameraCaptureBridge.enabled&&ReferenceEquals(captured,dictionary.GetValue(null)),"original_capture_enabled_true_same_dictionary");
        CameraCaptureBridge.enabled=false;Check(!CameraCaptureBridge.enabled&&ReferenceEquals(captured,dictionary.GetValue(null)),"original_capture_enabled_false_same_dictionary");
        var t=typeof(UniversalRenderPipelineAsset);var field=Field(t,"m_RenderFeatureset");field.SetValue(asset,Enum.ToObject(field.FieldType,123));Check(Convert.ToInt32(Call(Method(t,"get_renderFeatureset"),asset))==123,"original_asset_renderFeatureset_raw_enum_field");
        field=Field(t,"m_PostProcessing");field.SetValue(asset,Enum.ToObject(field.FieldType,-456));Check(Convert.ToInt32(Call(Method(t,"get_postProcessing"),asset))==-456,"original_asset_postProcessing_raw_enum_field");
        Field(t,"m_SupportsHDR").SetValue(asset,true);bool hdr=(bool)Call(Method(t,"get_supportsHDR"),asset);Field(t,"m_SupportsHDR").SetValue(asset,false);Check(hdr&&!(bool)Call(Method(t,"get_supportsHDR"),asset),"original_asset_supportsHDR_true_false");
        field=Field(t,"m_MSAA");field.SetValue(asset,Enum.ToObject(field.FieldType,4));Check((int)Call(Method(t,"get_msaaSampleCount"),asset)==4,"original_asset_msaa_original_enum_int_conversion");
        Field(t,"m_RenderScale").SetValue(asset,-0.0f);float scale=(float)Call(Method(t,"get_renderScale"),asset);Check(BitConverter.ToInt32(BitConverter.GetBytes(scale),0)==unchecked((int)0x80000000),"original_asset_renderScale_negative_zero_bits");
        Field(t,"m_RecRoomQualityConfig").SetValue(asset,null);Check(Call(Method(t,"get_RecRoomQualityConfig"),asset)==null,"original_asset_RecRoomQualityConfig_null_preserved");
        var utils=typeof(RenderingUtils);var rf=Field(utils,"m_RenderTextureFormatSupport");var gf=Field(utils,"m_GraphicsFormatSupport");var oldR=rf.GetValue(null);var oldG=gf.GetValue(null);
        var r=new Dictionary<RenderTextureFormat,bool>{{RenderTextureFormat.Default,true}};var g=new Dictionary<UnityEngine.Experimental.Rendering.GraphicsFormat,Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>>{{UnityEngine.Experimental.Rendering.GraphicsFormat.None,new Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>()}};
        try
        {
            rf.SetValue(null,r);gf.SetValue(null,g);Call(Method(utils,"ClearSystemInfoCache"),null);Check(r.Count==0&&g.Count==0,"original_cache_clear_both_real_BCL_dictionaries");
            Check(ReferenceEquals(r,rf.GetValue(null))&&ReferenceEquals(g,gf.GetValue(null)),"original_cache_clear_keeps_original_dictionary_references");
            g[UnityEngine.Experimental.Rendering.GraphicsFormat.None]=new Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>();rf.SetValue(null,null);bool threw=false;try{Call(Method(utils,"ClearSystemInfoCache"),null);}catch(NullReferenceException){threw=true;}Check(threw&&g.Count==1,"original_cache_first_null_prevents_second_clear");
            rf.SetValue(null,r);r[RenderTextureFormat.Default]=true;gf.SetValue(null,null);threw=false;try{Call(Method(utils,"ClearSystemInfoCache"),null);}catch(NullReferenceException){threw=true;}Check(threw&&r.Count==0,"original_cache_second_null_follows_first_clear");
        }
        finally{rf.SetValue(null,oldR);gf.SetValue(null,oldG);}
        var generated=typeof(UniversalRenderPipeline).GetNestedType("<>c",BindingFlags.NonPublic);Need(generated!=null,"Exact existing generated callback owner");var callback=Activator.CreateInstance(generated,true);var comparison=Method(generated,"<.ctor>b__32_0");var lights=Method(generated,"<.cctor>b__73_0");
        GameObject cameraA=null,cameraB=null,lightA=null,lightB=null;
        try
        {
            cameraA=new GameObject("OriginalComparisonA");cameraB=new GameObject("OriginalComparisonB");var ca=cameraA.AddComponent<Camera>();var cb=cameraB.AddComponent<Camera>();ca.enabled=false;cb.enabled=false;ca.depth=1.9f;cb.depth=1.2f;
            Check((int)Call(comparison,callback,ca,cb)==0,"original_camera_comparison_casts_each_real_depth_before_subtraction");cb.depth=-1.2f;Check((int)Call(comparison,callback,ca,cb)==2,"original_camera_comparison_mixed_sign_real_engine_depths");
            Call(lights,callback,new Light[0],default(Unity.Collections.NativeArray<UnityEngine.Experimental.GlobalIllumination.LightDataGI>));Check(true,"original_light_callback_empty_input_no_native_array_write");
            lightA=new GameObject("OriginalLightRequestA");lightB=new GameObject("OriginalLightRequestB");var la=lightA.AddComponent<Light>();var lb=lightB.AddComponent<Light>();la.enabled=false;lb.enabled=false;
            var output=new Unity.Collections.NativeArray<UnityEngine.Experimental.GlobalIllumination.LightDataGI>(3,Unity.Collections.Allocator.Temp);
            try
            {
                Call(lights,callback,new[]{la,lb},output);Check(output[0].instanceID==la.GetInstanceID()&&output[1].instanceID==lb.GetInstanceID(),"original_light_callback_real_instance_ids_and_native_array_output_order");
                Check(output[2].instanceID==0,"original_light_callback_unselected_native_array_tail_unchanged");
            }
            finally{output.Dispose();}
        }
        finally{if(cameraA!=null)Destroy(cameraA);if(cameraB!=null)Destroy(cameraB);if(lightA!=null)Destroy(lightA);if(lightB!=null)Destroy(lightB);}
    }

    IEnumerator Start()
    {
        result.start_frame=Time.frameCount;result.unity_version=Application.unityVersion;result.platform=Application.platform.ToString();result.mono_runtime=Type.GetType("Mono.Runtime")!=null;
        Application.logMessageReceived+=Observe;
        UniversalRenderPipelineAsset asset=null;CustomUrpSmokeRendererData data=null;
        try
        {
            Check(result.mono_runtime&&result.unity_version=="2020.3.33f1"&&Application.platform==RuntimePlatform.WindowsPlayer,"actual_matching_Windows_Mono_engine");
            Binding(JsonUtility.FromJson<Expected>(File.ReadAllText(Arg("-urpSmokeBindingExpected"))));Binding(JsonUtility.FromJson<Expected>(File.ReadAllText(Arg("-urpSmokeCoreBindingExpected"))),true);
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
            InitializerPrerequisites(asset);
            Check(GraphicsSettings.currentRenderPipeline==null,"global_pipeline_unchanged_no_renderer_constructor_Dispose_or_frame_entered");
            result.status="actual_original_URP_initializer12_and_safe_seven_body_paths_passed";
        }
        catch(Exception e){errors.Add(e.ToString());result.status="failed";}
        finally
        {
            if(data!=null)Destroy(data);if(asset!=null)Destroy(asset);
        }
        yield return null;yield return null;
        Application.logMessageReceived-=Observe;result.end_frame=Time.frameCount;result.checks=checks.ToArray();result.errors=errors.ToArray();if(errors.Count!=0)result.status="failed";
        bool saved=true;try{File.WriteAllText(Path.GetFullPath(Arg("-urpSmokeResult")),JsonUtility.ToJson(result,true));}catch(Exception e){Debug.LogException(e);saved=false;}
        Application.Quit(!saved?2:result.status=="actual_original_URP_initializer12_and_safe_seven_body_paths_passed"?0:1);
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
