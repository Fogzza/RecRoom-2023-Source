// Inert production donors use genuine engine metadata. Only INIT17_EFFECTS
// executes, with explicit fake engine boundaries and real BCL collections.
using System;
using System.Collections.Generic;
#if INIT17_EFFECTS
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
static class E17
{
    public static readonly List<string> Events=new List<string>();
    public static readonly List<string> ShaderNames=new List<string>();
    public static readonly List<UnityEngine.XR.XRDisplaySubsystem> Displays=new List<UnityEngine.XR.XRDisplaySubsystem>();
    public static int NullSamplerAt,ThrowRecorderAt,CreateCalls,GetRecorderCalls,Quality=0,QualityReads,Enumerations,InitialListCount;
    public static string ThrowAt;
    public static bool BaseSawComparison;
    public static void Event(string text){Events.Add(text);if(ThrowAt==text)throw new InvalidOperationException(text);}
    public static void Reset(){Events.Clear();ThrowAt=null;NullSamplerAt=ThrowRecorderAt=CreateCalls=GetRecorderCalls=QualityReads=Enumerations=InitialListCount=0;}
}
namespace UnityEngine
{
    public class Object{public int TestId;public int GetInstanceID(){return TestId;}}
    public class ScriptableObject:Object{}
    public class Camera:Object{public float depth;}
    public class Light:Object{}
    public class Mesh:Object{}
    public class Material:Object{}
    public class MaterialPropertyBlock{public MaterialPropertyBlock(){E17.Event("MaterialPropertyBlock.ctor");}}
    public enum RenderTextureFormat{Dummy}
    public struct Matrix4x4{}
    public struct Vector4
    {
        public float x,y,z,w;public Vector4(float a,float b,float c,float d){x=a;y=b;z=c;w=d;}
        public static Vector4 zero{get{return new Vector4(0,0,0,0);}}
        public static Vector4 one{get{return new Vector4(1,1,1,1);}}
    }
    public struct Color
    {
        public static Color black{get{return new Color();}}
        public static implicit operator Vector4(Color value){return new Vector4(0,0,0,1);}
    }
    public static class Shader
    {
        static string pipeline;public static int PropertyToID(string value){E17.ShaderNames.Add(value);return E17.ShaderNames.Count;}
        public static string globalRenderPipeline{get{return pipeline;}set{E17.Event("Shader.pipeline="+value);pipeline=value;}}
    }
    public static class QualitySettings
    {
        public static int antiAliasing{get{E17.QualityReads++;E17.Event("Quality.get");return E17.Quality;}set{E17.Event("Quality.set="+value);E17.Quality=value;}}
    }
    public static class Mathf
    {
        public static int NextPowerOfTwo(int value){E17.Event("NextPowerOfTwo="+value);unchecked{uint v=(uint)value;v--;v|=v>>1;v|=v>>2;v|=v>>4;v|=v>>8;v|=v>>16;return (int)(v+1);}}
        public static int Clamp(int value,int min,int max){E17.Event("Clamp="+value);return value<min?min:value>max?max:value;}
    }
    public static class SubsystemManager
    {
        public static void GetInstances<T>(List<T> values) where T:class
        {
            E17.Enumerations++;E17.InitialListCount=values.Count;E17.Event("GetInstances");values.Clear();foreach(var value in E17.Displays)values.Add((T)(object)value);
        }
    }
    namespace Experimental.Rendering{public enum GraphicsFormat{Dummy}public enum FormatUsage{Dummy}}
    namespace Experimental.GlobalIllumination
    {
        public struct LightDataGI{public int TestId,Generation;public void InitNoBake(int id){TestId=id;Generation++;}}
        public static class Lightmapping
        {
            public delegate void RequestLightsDelegate(Light[] requests,Unity.Collections.NativeArray<LightDataGI> output);
            public static RequestLightsDelegate Last;
            public static void SetDelegate(RequestLightsDelegate callback){E17.Event("Lightmapping.SetDelegate");Last=callback;}
        }
    }
    namespace Profiling
    {
        public class Recorder
        {
            readonly string name;bool state=true;public Recorder(string value){name=value;}
            public bool enabled{get{return state;}set{E17.Event("Recorder.enabled="+name+":"+value);state=value;}}
        }
        public class CustomSampler
        {
            public string Label;public bool Gpu;public Recorder TestRecorder;
            public static CustomSampler Create(string name,bool gpu)
            {
                E17.CreateCalls++;E17.Event("Sampler.Create="+(name??"<null>")+":"+gpu);
                return E17.CreateCalls==E17.NullSamplerAt?null:new CustomSampler{Label=name,Gpu=gpu,TestRecorder=new Recorder(name)};
            }
            public Recorder GetRecorder(){E17.GetRecorderCalls++;E17.Event("Sampler.GetRecorder="+Label);if(E17.GetRecorderCalls==E17.ThrowRecorderAt)throw new InvalidOperationException("recorder");return TestRecorder;}
        }
    }
    namespace XR
    {
        // Deliberately a plain reference type, matching IntegratedSubsystem
        // null semantics. It does not derive fake UnityEngine.Object.
        public class XRDisplaySubsystem
        {
            public string Label;public bool running;public int LastMsaa;public float LastScale;bool legacy;
            public bool disableLegacyRenderer{get{return legacy;}set{E17.Event("Legacy="+Label+":"+value);legacy=value;}}
            public float scaleOfAllRenderTargets{get{return LastScale;}set{E17.Event("Scale="+Label);LastScale=value;}}
            public void SetMSAALevel(int value){E17.Event("MSAA="+Label+":"+value);LastMsaa=value;}
        }
    }
    namespace Rendering
    {
        public struct ScriptableRenderContext{}
        public struct RenderTargetIdentifier
        {
            public int Value;public static implicit operator RenderTargetIdentifier(int value){E17.Event("RT.implicit="+value);return new RenderTargetIdentifier{Value=value};}
        }
        public struct ShaderTagId{public string Value;public ShaderTagId(string value){Value=value;}}
        public class CommandBuffer{}
        public abstract class RenderPipeline
        {
            protected RenderPipeline(){var f=GetType().GetField("cameraComparison",BindingFlags.NonPublic|BindingFlags.Instance);E17.BaseSawComparison=f!=null&&f.GetValue(this)!=null;E17.Event("RenderPipeline.base");}
            protected abstract void Render(ScriptableRenderContext context,Camera[] cameras);
        }
        public abstract class RenderPipelineAsset:ScriptableObject{protected abstract RenderPipeline CreatePipeline();}
    }
}
namespace Unity.Collections
{
    public struct NativeArray<T>{public T[] Values;public NativeArray(T[] values){Values=values;}public T this[int i]{get{return Values[i];}set{Values[i]=value;}}}
}
#endif

#if INIT17_CORE || INIT17_EFFECTS
namespace UnityEngine.Rendering
{
    public static class TextureXR
    {
        private static int m_MaxViews;
        /*TEXTURE_XR*/
    }
    public class ProfilingSampler
    {
        internal UnityEngine.Profiling.CustomSampler sampler{get;private set;}
        internal UnityEngine.Profiling.CustomSampler inlineSampler{get;private set;}
        public string name{get;private set;}
        private UnityEngine.Profiling.Recorder m_Recorder,m_InlineRecorder;
        /*PROFILING_CTOR*/
    }
    public static class CameraCaptureBridge
    {
        private static Dictionary<UnityEngine.Camera,HashSet<Action<RenderTargetIdentifier,CommandBuffer>>> actionDict;
        private static bool _enabled;
        /*SUPPORT_CAPTURE*/
    }
}
#endif

#if INIT17_URP || INIT17_EFFECTS
namespace UnityEngine.Rendering.Universal
{
    /*ENUMS*/
    public class RecRoomQualityConfig:UnityEngine.ScriptableObject{}
    public class UniversalRenderPipelineAsset:UnityEngine.Rendering.RenderPipelineAsset
    {
        private RenderFeaturesetOption m_RenderFeatureset;private PostProcessingOption m_PostProcessing;
        private bool m_SupportsHDR;private MsaaQuality m_MSAA;private float m_RenderScale;private RecRoomQualityConfig m_RecRoomQualityConfig;
        /*SUPPORT_ASSET*/
        protected override UnityEngine.Rendering.RenderPipeline CreatePipeline(){throw new NotImplementedException("Unselected inert metadata scaffold");}
    }
    public static class RenderingUtils
    {
        private static List<UnityEngine.Rendering.ShaderTagId> m_LegacyShaderPassNames;
        private static UnityEngine.Mesh s_FullscreenMesh;private static bool? s_hasZeroMaxSupportedComputeBuffersInVertex,s_hasLimitedUniformCountInVertex;
        private static UnityEngine.Material s_ErrorMaterial;
        internal static readonly int UNITY_STEREO_MATRIX_V,UNITY_STEREO_MATRIX_IV,UNITY_STEREO_MATRIX_P,UNITY_STEREO_MATRIX_IP,UNITY_STEREO_MATRIX_VP,UNITY_STEREO_MATRIX_IVP,UNITY_STEREO_CAMERA_PROJECTION,UNITY_STEREO_CAMERA_INV_PROJECTION,UNITY_STEREO_VECTOR_CAMPOS;
        private static readonly StereoConstants stereoConstants;
        private static Dictionary<UnityEngine.RenderTextureFormat,bool> m_RenderTextureFormatSupport;
        private static Dictionary<UnityEngine.Experimental.Rendering.GraphicsFormat,Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>> m_GraphicsFormatSupport;
        internal class StereoConstants
        {
            /*STEREO_CTOR*/
        }
        /*RENDERING_CCTOR*/
        /*SUPPORT_CLEAR*/
    }
    internal struct XRView{}
    internal class XRPass
    {
        private static UnityEngine.Rendering.RenderTargetIdentifier invalidRT;
        private static UnityEngine.Rendering.ProfilingSampler _XRCustomMirrorProfilingSampler,_XROcclusionProfilingSampler;
        internal static readonly int UNITY_STEREO_MATRIX_V,UNITY_STEREO_MATRIX_IV,UNITY_STEREO_MATRIX_VP,UNITY_STEREO_MATRIX_IVP;
        /*XRPASS_CTOR*/
        /*XRPASS_CCTOR*/
    }
    internal class XRSystem
    {
        private static List<UnityEngine.XR.XRDisplaySubsystem> displayList;
        private UnityEngine.XR.XRDisplaySubsystem display;private static int msaaLevel;
        private static UnityEngine.Rendering.ProfilingSampler _XRMirrorProfilingSampler;
        /*XRSYSTEM_CTOR*/
        /*XRSYSTEM_CCTOR*/
        /*GET_DISPLAY*/
        /*REFRESH*/
        /*UPDATES*/
    }
    public sealed class UniversalRenderPipeline:UnityEngine.Rendering.RenderPipeline
    {
        private static int prevRenderingDataFrame;internal static XRSystem m_XRSystem;
        private static UnityEngine.Vector4 k_DefaultLightPosition,k_DefaultLightSpotDirection,k_DefaultLightsProbeChannel;
        public static UnityEngine.Vector4 k_DefaultLightColor,k_DefaultLightAttenuation;
        private static List<UnityEngine.Vector4> m_ShadowBiasData;private static List<UnityEngine.XR.XRDisplaySubsystem> displaySubsystemList;
        private static UnityEngine.Experimental.GlobalIllumination.Lightmapping.RequestLightsDelegate lightsDelegate;
        public static float ActiveRenderScale;public static RenderFeaturesetOption ActiveRenderFeatureset;public static PostProcessingOption ActivePostProcessing;public static bool ActiveSupportsHDR;
        internal static RecRoomQualityConfig ActiveRecRoomQualityConfig;
        internal sealed class OriginalCallbackBindings
        {
            public static readonly OriginalCallbackBindings Singleton;public static Comparison<UnityEngine.Camera> CachedComparison;
            /*CALLBACK_CCTOR*/
            internal int OriginalComparison(UnityEngine.Camera camera1,UnityEngine.Camera camera2)
            /*SUPPORT_COMPARISON*/
            internal void OriginalLights(UnityEngine.Light[] requests,Unity.Collections.NativeArray<UnityEngine.Experimental.GlobalIllumination.LightDataGI> lightsOutput)
            /*SUPPORT_LIGHTS*/
        }
        /*PIPELINE_CTOR*/
        /*PIPELINE_CCTOR*/
        protected override void Render(UnityEngine.Rendering.ScriptableRenderContext context,UnityEngine.Camera[] cameras){throw new NotImplementedException("Unselected frame scaffold, never executed");}
    }
}
#endif

#if INIT17_EFFECTS
static class Initializer17Effects
{
    static int cases;static readonly BindingFlags F=BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static;
    static void Need(bool value,string why){if(!value)throw new Exception(why);}
    static void Done(string label){cases++;Console.WriteLine("PASS "+label);}
    static bool Throws<T>(Action action)where T:Exception{try{action();return false;}catch(T){return true;}}
    static object Field(Type t,string name,object target=null){return t.GetField(name,F).GetValue(target);}
    static void Set(Type t,string name,object value,object target=null){t.GetField(name,F).SetValue(target,value);}
    static int Bits(float value){return BitConverter.ToInt32(BitConverter.GetBytes(value),0);}
    static bool Vector(UnityEngine.Vector4 v,float x,float y,float z,float w){return v.x==x&&v.y==y&&v.z==z&&v.w==w;}
    static readonly Type RU=typeof(RenderingUtils),XS=typeof(XRSystem),XP=typeof(XRPass),UP=typeof(UniversalRenderPipeline);
    static XRSystem NewSystem(params UnityEngine.XR.XRDisplaySubsystem[] rows){E17.Displays.Clear();E17.Displays.AddRange(rows);return new XRSystem();}
    static UnityEngine.XR.XRDisplaySubsystem Display(string name,bool running=true){return new UnityEngine.XR.XRDisplaySubsystem{Label=name,running=running};}
    static UniversalRenderPipelineAsset Asset(int aa=1,float scale=1){var a=new UniversalRenderPipelineAsset();Set(a.GetType(),"m_MSAA",(MsaaQuality)aa,a);Set(a.GetType(),"m_RenderScale",scale,a);return a;}
    static void Caches(){Set(RU,"m_RenderTextureFormatSupport",new Dictionary<RenderTextureFormat,bool>{{0,true}});Set(RU,"m_GraphicsFormatSupport",new Dictionary<UnityEngine.Experimental.Rendering.GraphicsFormat,Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>>{{0,new Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>()}});}
    static void Run()
    {
        Need(TextureXR.slices==1,"original static value1");Done("texture_default_one");
        TextureXR.maxViews=-7;Need(TextureXR.slices==-7,"no clamp");Done("texture_negative_raw_cache");
        TextureXR.maxViews=int.MaxValue;Need(TextureXR.slices==int.MaxValue,"raw max");TextureXR.maxViews=1;Done("texture_intmax_raw_cache");
        E17.Reset();var sampler=new ProfilingSampler("profile");Need(E17.Events.Take(2).SequenceEqual(new[]{"Sampler.Create=profile:True","Sampler.Create=Inl_profile:False"})&&sampler.name=="profile","two creations then metadata");Done("profiling_create_names_gpu_flags_order");
        Need(!sampler.sampler.TestRecorder.enabled&&!sampler.inlineSampler.TestRecorder.enabled&&E17.GetRecorderCalls==2,"both disabled");Done("profiling_both_recorders_disabled");
        E17.Reset();sampler=new ProfilingSampler(null);Need(sampler.name==null&&sampler.inlineSampler.Label=="Inl_","null concat");Done("profiling_null_name_concat_preserved");
        E17.Reset();E17.NullSamplerAt=1;Need(Throws<NullReferenceException>(()=>new ProfilingSampler("a"))&&E17.CreateCalls==2&&E17.GetRecorderCalls==0,"first null after both creates");Done("profiling_null_first_sampler_failure_order");
        E17.Reset();E17.NullSamplerAt=2;Need(Throws<NullReferenceException>(()=>new ProfilingSampler("a"))&&E17.GetRecorderCalls==1&&E17.Events.Last()=="Recorder.enabled=a:False","first disabled before second null");Done("profiling_null_inline_preserves_first_disable");
        E17.Reset();E17.ThrowRecorderAt=1;Need(Throws<InvalidOperationException>(()=>new ProfilingSampler("a"))&&E17.GetRecorderCalls==1&&!E17.Events.Any(x=>x.StartsWith("Recorder.enabled=")),"first recorder failure");Done("profiling_first_recorder_failure_stops_disable");
        E17.Reset();E17.ThrowRecorderAt=2;Need(Throws<InvalidOperationException>(()=>new ProfilingSampler("a"))&&E17.Events.Contains("Recorder.enabled=a:False"),"first disable retained");E17.Reset();Done("profiling_inline_recorder_failure_prior_disable");
        RuntimeHelpers.RunClassConstructor(RU.TypeHandle);var stereo=Field(RU,"stereoConstants");var arrays=stereo.GetType().GetFields(F).Where(f=>f.FieldType.IsArray).Select(f=>(Array)f.GetValue(stereo)).ToArray();Need(arrays.Length==6&&arrays.All(a=>a.Length==2),"six arrays2");Done("stereo_all_six_arrays_length_two");
        Need(arrays.Distinct().Count()==6&&arrays.Take(5).All(a=>a.GetType()==typeof(Matrix4x4[]))&&arrays[5].GetType()==typeof(Vector4[]),"separate typed arrays");Done("stereo_five_matrix_one_vector_distinct");
        Need(((List<ShaderTagId>)Field(RU,"m_LegacyShaderPassNames")).Select(v=>v.Value).SequenceEqual(new[]{"Always","ForwardBase","PrepassBase","Vertex","VertexLMRGBM","VertexLM"}),"six original tags");Done("rendering_original_six_legacy_tags");
        string[] ids={"unity_StereoMatrixV","unity_StereoMatrixInvV","unity_StereoMatrixP","unity_StereoMatrixInvP","unity_StereoMatrixVP","unity_StereoMatrixInvVP","unity_StereoCameraProjection","unity_StereoCameraInvProjection","unity_StereoWorldSpaceCameraPos"};Need(E17.ShaderNames.Take(9).SequenceEqual(ids),"exact original InvVP");Done("rendering_nine_property_literals_InvVP");
        Need(Field(RU,"s_FullscreenMesh")==null&&Field(RU,"s_ErrorMaterial")==null&&Field(RU,"s_hasZeroMaxSupportedComputeBuffersInVertex")==null&&Field(RU,"s_hasLimitedUniformCountInVertex")==null&&((System.Collections.IDictionary)Field(RU,"m_RenderTextureFormatSupport")).Count==0&&((System.Collections.IDictionary)Field(RU,"m_GraphicsFormatSupport")).Count==0,"original defaults and two collections");Done("rendering_null_defaults_and_empty_dictionaries");
        var pass=new XRPass();var eyes=(Vector4[])Field(XP,"stereoEyeIndices",pass);Need(pass.views.Count==0&&pass.views.Capacity==2&&eyes.Length==2&&Vector(eyes[0],0,0,0,0)&&Vector(eyes[1],1,1,1,1)&&new[]{"stereoProjectionMatrix","stereoViewMatrix","stereoCameraProjectionMatrix"}.All(n=>((Matrix4x4[])Field(XP,n,pass)).Length==2),"original pass allocations");Done("xrpass_two_views_eyes_and_three_matrix_arrays");
        Need(((RenderTargetIdentifier)Field(XP,"invalidRT")).Value==-1&&E17.ShaderNames.Skip(9).Take(4).SequenceEqual(new[]{"unity_StereoMatrixV","unity_StereoMatrixInvV","unity_StereoMatrixVP","unity_StereoMatrixIVP"}),"implicit -1 and different IVP");Done("xrpass_implicit_minus_one_and_original_IVP");
        Need(((ProfilingSampler)Field(XP,"_XRCustomMirrorProfilingSampler")).name=="XR Custom Mirror View"&&((ProfilingSampler)Field(XP,"_XROcclusionProfilingSampler")).name=="XR Occlusion Mesh","original two names");Done("xrpass_original_two_profilers");
        RuntimeHelpers.RunClassConstructor(XS.TypeHandle);Need((int)Field(XS,"msaaLevel")==1&&((System.Collections.IList)Field(XS,"displayList")).Count==0,"default level/list");Done("xrsystem_static_empty_list_msaa_one");
        Need(((ProfilingSampler)Field(XS,"_XRMirrorProfilingSampler")).name=="XR Mirror View","mirror name");Done("xrsystem_original_mirror_profiler");
        TextureXR.maxViews=5;var system=NewSystem();Need(system.emptyPass!=null&&Field(XS,"framePasses",system)!=null&&Field(XS,"mirrorViewMaterialProperty",system)!=null&&TextureXR.slices==5&&Field(XS,"display",system)==null,"allocations and max never shrinks");Done("xrsystem_ctor_fields_empty_display_max_preserved");
        var d=Display("one");system=NewSystem(d);Need(d.disableLegacyRenderer&&ReferenceEquals(Field(XS,"display",system),d)&&system.RefreshXrSdk(),"one running display");Done("refresh_one_running_exact_reference");
        E17.Displays.Clear();Need(!system.RefreshXrSdk()&&Field(XS,"display",system)==null,"empty clears");Done("refresh_empty_clears_display");
        E17.Displays.Add(d);E17.Displays.Add(Display("two"));Need(Throws<NotImplementedException>(()=>system.RefreshXrSdk()),"more than one throws");Done("refresh_multiple_displays_original_exception");
        E17.Displays.Clear();d=Display("stopped",false);E17.Displays.Add(d);Need(!system.RefreshXrSdk()&&d.disableLegacyRenderer,"running false still selected");Done("refresh_stopped_display_selected_but_false");
        E17.Displays.Clear();E17.Displays.Add(null);Need(Throws<NullReferenceException>(()=>system.RefreshXrSdk())&&Field(XS,"display",system)==null,"raw reference null semantics");Done("refresh_null_reference_throws_without_Unity_null_policy");
        E17.Displays.Clear();var seededDisplayList=(System.Collections.IList)Field(XS,"displayList");seededDisplayList.Clear();seededDisplayList.Add(d);E17.Reset();XS.GetMethod("GetDisplaySubsystem",F).Invoke(null,null);Need(E17.InitialListCount==1,"caller did not clear before engine");Done("get_displays_no_extra_clear_before_engine");
        Set(XS,"msaaLevel",4);E17.Reset();XRSystem.UpdateMSAALevel(4);Need(E17.Events.Count==0,"raw equal early return");Done("msaa_raw_equal_no_enumeration");
        d=Display("a");E17.Displays.Add(d);E17.Reset();XRSystem.UpdateMSAALevel(3);Need(d.LastMsaa==4&&(int)Field(XS,"msaaLevel")==4&&E17.Enumerations==1,"3 rounds4");Done("msaa_three_rounds_four");
        E17.Reset();XRSystem.UpdateMSAALevel(-4);Need(d.LastMsaa==1&&(int)Field(XS,"msaaLevel")==1,"low clamps1");Done("msaa_negative_clamps_one");
        E17.Reset();XRSystem.UpdateMSAALevel(32);Need(d.LastMsaa==8&&(int)Field(XS,"msaaLevel")==8,"high clamps8");Done("msaa_high_clamps_eight");
        Set(XS,"msaaLevel",4);E17.Reset();XRSystem.UpdateMSAALevel(3);Need(E17.Enumerations==1,"compare request before normalization");Done("msaa_normalized_equal_still_enumerates");
        E17.Displays.Clear();E17.Reset();XRSystem.UpdateMSAALevel(2);Need((int)Field(XS,"msaaLevel")==2,"empty commits");Done("msaa_empty_list_commits_after_enumeration");
        E17.Displays.Add(d);E17.Reset();E17.ThrowAt="MSAA=a:8";Need(Throws<InvalidOperationException>(()=>XRSystem.UpdateMSAALevel(8))&&(int)Field(XS,"msaaLevel")==2,"cache not committed");Done("msaa_first_failure_preserves_old_cache");
        var e=Display("b");E17.Displays.Add(e);E17.Reset();E17.ThrowAt="MSAA=b:8";Need(Throws<InvalidOperationException>(()=>XRSystem.UpdateMSAALevel(8))&&d.LastMsaa==8&&(int)Field(XS,"msaaLevel")==2,"earlier update retained");Done("msaa_later_failure_preserves_prior_update_old_cache");
        E17.Displays[1]=null;E17.Reset();Need(Throws<NullReferenceException>(()=>XRSystem.UpdateMSAALevel(8))&&d.LastMsaa==8&&(int)Field(XS,"msaaLevel")==2,"raw null entry");Done("msaa_null_entry_preserves_prior_update_old_cache");
        E17.Displays.RemoveAt(1);E17.Reset();XRSystem.UpdateRenderScale(-0.0f);Need(Bits(d.LastScale)==unchecked((int)0x80000000),"no clamp zero");Done("scale_negative_zero_bits_preserved");
        float nan=BitConverter.ToSingle(BitConverter.GetBytes(0x7fc12345),0);E17.Reset();XRSystem.UpdateRenderScale(nan);Need(Bits(d.LastScale)==0x7fc12345,"no NaN normalization");Done("scale_NaN_payload_preserved");
        E17.Displays.Add(e);E17.Reset();E17.ThrowAt="Scale=b";Need(Throws<InvalidOperationException>(()=>XRSystem.UpdateRenderScale(-2))&&d.LastScale==-2,"prior scale survives");Done("scale_later_failure_preserves_prior_assignment");
        E17.Displays.Clear();E17.Reset();RuntimeHelpers.RunClassConstructor(UP.TypeHandle);Need((int)Field(UP,"prevRenderingDataFrame")==-1&&Vector((Vector4)Field(UP,"k_DefaultLightPosition"),0,0,1,0)&&Vector(UniversalRenderPipeline.k_DefaultLightColor,0,0,0,1)&&Vector(UniversalRenderPipeline.k_DefaultLightAttenuation,0,1,-1,-1)&&Vector((Vector4)Field(UP,"k_DefaultLightSpotDirection"),0,0,1,0)&&Vector((Vector4)Field(UP,"k_DefaultLightsProbeChannel"),0,0,0,0),"custom attenuation not stock");Done("pipeline_static_original_frame_vectors_custom_attenuation");
        var callback=(UnityEngine.Experimental.GlobalIllumination.Lightmapping.RequestLightsDelegate)Field(UP,"lightsDelegate");var values=new UnityEngine.Experimental.GlobalIllumination.LightDataGI[1];callback(new[]{new Light{TestId=81}},new Unity.Collections.NativeArray<UnityEngine.Experimental.GlobalIllumination.LightDataGI>(values));Need(values[0].TestId==81&&((System.Collections.IList)Field(UP,"m_ShadowBiasData")).Count==0&&((System.Collections.IList)Field(UP,"displaySubsystemList")).Count==0,"real recovered callback body and collections");Done("pipeline_static_existing_callback_and_empty_lists");
        Caches();E17.Quality=0;E17.Reset();var asset=Asset();var pipeline=new UniversalRenderPipeline(asset);Need(E17.BaseSawComparison&&UniversalRenderPipeline.OriginalCallbackBindings.Singleton!=null&&ReferenceEquals(Field(UP,"cameraComparison",pipeline),UniversalRenderPipeline.OriginalCallbackBindings.CachedComparison),"field initializer before base");Done("pipeline_cached_comparison_initialized_before_base");
        Need(E17.QualityReads==1&&!E17.Events.Any(v=>v.StartsWith("Quality.set="))&&!E17.Events.Any(v=>v.StartsWith("MSAA="))&&E17.Enumerations==1,"nonpositive quality normalizes to1");Done("pipeline_nonpositive_quality_no_change_one_getter");
        d=Display("p");E17.Displays.Add(d);Set(XS,"msaaLevel",1);E17.Quality=0;E17.Reset();Caches();var quality=new RecRoomQualityConfig();asset=Asset(4,0.75f);Set(asset.GetType(),"m_RenderFeatureset",(RenderFeaturesetOption)7,asset);Set(asset.GetType(),"m_PostProcessing",(PostProcessingOption)(-3),asset);Set(asset.GetType(),"m_SupportsHDR",true,asset);Set(asset.GetType(),"m_RecRoomQualityConfig",quality,asset);pipeline=new UniversalRenderPipeline(asset);Need(E17.Quality==4&&d.LastMsaa==4&&d.LastScale==0.75f&&E17.QualityReads==1&&E17.Events.IndexOf("Quality.set=4")<E17.Events.IndexOf("MSAA=p:4")&&E17.Events.IndexOf("Scale=p")<E17.Events.IndexOf("Shader.pipeline=UniversalPipeline,LightweightPipeline")&&E17.Events.IndexOf("Shader.pipeline=UniversalPipeline,LightweightPipeline")<E17.Events.IndexOf("Lightmapping.SetDelegate"),"engine order");Done("pipeline_change_quality_then_xr_scale_pipeline_delegate");
        E17.Quality=4;E17.Reset();Caches();new UniversalRenderPipeline(asset);Need(E17.QualityReads==2&&!E17.Events.Any(v=>v.StartsWith("Quality.set=")),"positive reads twice");Done("pipeline_positive_quality_getter_twice");
        Need(CameraCaptureBridge.enabled&&UniversalRenderPipeline.ActiveRenderScale==0.75f&&(int)UniversalRenderPipeline.ActiveRenderFeatureset==7&&(int)UniversalRenderPipeline.ActivePostProcessing==-3&&UniversalRenderPipeline.ActiveSupportsHDR&&ReferenceEquals(UniversalRenderPipeline.ActiveRecRoomQualityConfig,quality)&&((System.Collections.IDictionary)Field(RU,"m_RenderTextureFormatSupport")).Count==0&&ReferenceEquals(UnityEngine.Experimental.GlobalIllumination.Lightmapping.Last,callback),"exact active fields after capture/cache");Done("pipeline_active_fields_exact_recovered_support_effects");
        var cached=UniversalRenderPipeline.OriginalCallbackBindings.CachedComparison;E17.Reset();Caches();pipeline=new UniversalRenderPipeline(asset);Need(ReferenceEquals(cached,Field(UP,"cameraComparison",pipeline)),"cached delegate reused");Done("pipeline_existing_comparison_cache_reused");
        E17.Reset();Need(Throws<NullReferenceException>(()=>new UniversalRenderPipeline(null))&&E17.Events.Contains("RenderPipeline.base")&&!E17.Events.Any(v=>v.StartsWith("Quality.set=")),"null asset after base and quality reads");Done("pipeline_null_asset_failure_after_base");
        E17.Quality=0;Set(XS,"msaaLevel",1);E17.Reset();E17.ThrowAt="MSAA=p:4";Need(Throws<InvalidOperationException>(()=>new UniversalRenderPipeline(asset))&&E17.Quality==4&&!E17.Events.Any(v=>v.StartsWith("Scale="))&&!E17.Events.Any(v=>v.StartsWith("Shader.pipeline=")),"MSAA failure stops remaining");Done("pipeline_msaa_failure_after_quality_write");
        E17.Quality=4;E17.Reset();E17.ThrowAt="Scale=p";Need(Throws<InvalidOperationException>(()=>new UniversalRenderPipeline(asset))&&!E17.Events.Any(v=>v.StartsWith("Shader.pipeline=")),"scale failure stops pipeline tag");Done("pipeline_scale_failure_before_shader_tag");
        CameraCaptureBridge.enabled=false;E17.Reset();E17.ThrowAt="Lightmapping.SetDelegate";Need(Throws<InvalidOperationException>(()=>new UniversalRenderPipeline(asset))&&E17.Events.Contains("Shader.pipeline=UniversalPipeline,LightweightPipeline")&&!CameraCaptureBridge.enabled,"delegate failure precedes capture");Done("pipeline_delegate_failure_after_tag_before_capture");
        Caches();Set(RU,"m_RenderTextureFormatSupport",null);UniversalRenderPipeline.ActiveRenderScale=99;E17.Reset();Need(Throws<NullReferenceException>(()=>new UniversalRenderPipeline(asset))&&CameraCaptureBridge.enabled&&UniversalRenderPipeline.ActiveRenderScale==99&&((System.Collections.IDictionary)Field(RU,"m_GraphicsFormatSupport")).Count==1,"first dictionary null before activewrites");Done("pipeline_first_cache_null_stops_active_fields");
        Caches();var first=(System.Collections.IDictionary)Field(RU,"m_RenderTextureFormatSupport");Set(RU,"m_GraphicsFormatSupport",null);E17.Reset();Need(Throws<NullReferenceException>(()=>new UniversalRenderPipeline(asset))&&first.Count==0&&UniversalRenderPipeline.ActiveRenderScale==99,"first cleared before second null");Done("pipeline_second_cache_null_preserves_prior_clear");
        Need(cases==53,"exact53 controlled cases");Console.WriteLine("RESULT seventeen_original_initializer_XR_bindings_53_controlled_effects_passed; genuine_Unity_executed=false; renderer_activation=false");
    }
    static int Main(){try{Run();return 0;}catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}}
}
#endif
