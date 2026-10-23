// Only twelve verbatim inserted original bodies are candidates. Production
// donors compile against genuine engine metadata and are NEVER CLR loaded.
using System;
using System.Collections.Generic;
#if INIT_EFFECT_CONTROLS
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
namespace UnityEngine
{
    public class Object { public int TestId;public int GetInstanceID(){return TestId;} }
    public class ScriptableObject:Object {}
    public class Camera:Object { public string Label;public float Value;public float depth {get{PrereqState.Events.Add(Label);return Value;}} }
    public class Light:Object {}
    public enum RenderTextureFormat {Dummy}
    namespace Experimental.Rendering {public enum GraphicsFormat {Dummy}public enum FormatUsage {Dummy}}
    namespace Rendering {public struct RenderTargetIdentifier {}public class CommandBuffer {}public abstract class RenderPipeline {}public abstract class RenderPipelineAsset:ScriptableObject {protected abstract RenderPipeline CreatePipeline();}}
    namespace Experimental.GlobalIllumination
    {
        public struct LightDataGI {public int TestId,Generation;public void InitNoBake(int value){TestId=value;Generation++;}}
    }
}
namespace Unity.Collections
{
    public struct NativeArray<T>
    {
        public T[] Values;public NativeArray(T[] values){Values=values;}
        public T this[int index]{get{return Values[index];}set{PrereqState.Writes.Add(index);Values[index]=value;}}
    }
}
#endif

#if INIT_CORE_DONOR || INIT_EFFECT_CONTROLS
namespace UnityEngine.Rendering
{
    public static class CameraCaptureBridge
    {
        private static Dictionary<UnityEngine.Camera,HashSet<Action<RenderTargetIdentifier,CommandBuffer>>> actionDict;
        private static bool _enabled;
        /*ORIGINAL_CAMERA_CAPTURE*/
    }
}
#endif

#if INIT_URP_DONOR || INIT_EFFECT_CONTROLS
namespace UnityEngine.Rendering.Universal
{
    /*ORIGINAL_ENUM_DECLARATIONS*/
    // Existing exact original type identity for return-type metadata only;
    // this scaffold is not imported and no RecRoomQualityConfig behavior runs.
    public class RecRoomQualityConfig:UnityEngine.ScriptableObject {}
    public class UniversalRenderPipelineAsset:UnityEngine.Rendering.RenderPipelineAsset
    {
        private RenderFeaturesetOption m_RenderFeatureset;
        private PostProcessingOption m_PostProcessing;
        private bool m_SupportsHDR;
        private MsaaQuality m_MSAA;
        private float m_RenderScale;
        private RecRoomQualityConfig m_RecRoomQualityConfig;
        /*ORIGINAL_ASSET_GETTERS*/
        protected override UnityEngine.Rendering.RenderPipeline CreatePipeline(){throw new NotImplementedException("Unselected metadata scaffold; never copied or executed");}
    }
    public static class RenderingUtils
    {
        private static Dictionary<UnityEngine.RenderTextureFormat,bool> m_RenderTextureFormatSupport;
        private static Dictionary<UnityEngine.Experimental.Rendering.GraphicsFormat,Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>> m_GraphicsFormatSupport;
        /*ORIGINAL_CLEAR_CACHE*/
    }
    public abstract class UniversalRenderPipeline:UnityEngine.Rendering.RenderPipeline
    {
        // Explicit donor-only alias for original existing <>c owner and the two
        // exact callbacks. A later importer must map these identities; no new
        // generated declaration may be copied into the recovered SDK.
        internal sealed class OriginalCallbackBindings
        {
            internal int OriginalComparison(UnityEngine.Camera camera1,UnityEngine.Camera camera2)
            /*ORIGINAL_CAMERA_COMPARISON_BODY*/
            internal void OriginalLights(UnityEngine.Light[] requests,Unity.Collections.NativeArray<UnityEngine.Experimental.GlobalIllumination.LightDataGI> lightsOutput)
            /*ORIGINAL_LIGHT_CALLBACK_BODY*/
        }
    }
}
#endif

#if INIT_EFFECT_CONTROLS
static class PrereqState {public static List<string> Events=new List<string>();public static List<int> Writes=new List<int>();}
static class PrerequisiteControls
{
    static int cases;
    static void Need(bool b,string message){if(!b)throw new Exception(message);}
    static void Done(string name){cases++;Console.WriteLine("PASS "+name);}
    static bool Throws<T>(Action a) where T:Exception {try{a();return false;}catch(T){return true;}}
    static readonly BindingFlags Flags=BindingFlags.Instance|BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Public;
    static void Set(object value,string name,object field){value.GetType().GetField(name,Flags).SetValue(value,field);}
    static FieldInfo Static(Type type,string name){return type.GetField(name,Flags);}
    static void Run()
    {
        var capture=typeof(UnityEngine.Rendering.CameraCaptureBridge);var dictionary=Static(capture,"actionDict");
        Need(((System.Collections.IDictionary)dictionary.GetValue(null)).Count==0,"actual BCL empty action dictionary");Done("capture_original_dictionary_cctor_empty_initialized");
        Need(!UnityEngine.Rendering.CameraCaptureBridge.enabled,"CLR bool default");Done("capture_enabled_default_false");
        var before=dictionary.GetValue(null);UnityEngine.Rendering.CameraCaptureBridge.enabled=true;Need(UnityEngine.Rendering.CameraCaptureBridge.enabled,"true");Done("capture_enabled_true_roundtrip");
        UnityEngine.Rendering.CameraCaptureBridge.enabled=false;Need(!UnityEngine.Rendering.CameraCaptureBridge.enabled&&ReferenceEquals(before,dictionary.GetValue(null)),"false and same dictionary");Done("capture_enabled_false_same_dictionary");
        var asset=new UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset();
        Set(asset,"m_RenderFeatureset",(UnityEngine.Rendering.Universal.RenderFeaturesetOption)123);Need((int)asset.renderFeatureset==123,"enum bits");Done("asset_renderFeatureset_exact_field_bits");
        Set(asset,"m_PostProcessing",(UnityEngine.Rendering.Universal.PostProcessingOption)(-456));Need((int)asset.postProcessing==-456,"enum bits");Done("asset_postProcessing_exact_field_bits");
        Set(asset,"m_SupportsHDR",true);Need(asset.supportsHDR,"true");Done("asset_supportsHDR_true");Set(asset,"m_SupportsHDR",false);Need(!asset.supportsHDR,"false");Done("asset_supportsHDR_false");
        Set(asset,"m_MSAA",(UnityEngine.Rendering.Universal.MsaaQuality)4);Need(asset.msaaSampleCount==4,"4");Done("asset_msaa_original_enum_underlying_int");
        Set(asset,"m_MSAA",(UnityEngine.Rendering.Universal.MsaaQuality)(-99));Need(asset.msaaSampleCount==-99,"no normalization");Done("asset_msaa_arbitrary_raw_bits_preserved");
        Set(asset,"m_RenderScale",-0.0f);Need(BitConverter.ToInt32(BitConverter.GetBytes(asset.renderScale),0)==unchecked((int)0x80000000),"negative zero");Done("asset_renderScale_negative_zero_bits");
        float nan=BitConverter.ToSingle(BitConverter.GetBytes(unchecked((int)0x7fc12345)),0);Set(asset,"m_RenderScale",nan);Need(BitConverter.ToInt32(BitConverter.GetBytes(asset.renderScale),0)==0x7fc12345,"NaN payload");Done("asset_renderScale_NaN_payload_bits");
        var quality=new UnityEngine.Rendering.Universal.RecRoomQualityConfig();Set(asset,"m_RecRoomQualityConfig",quality);Need(ReferenceEquals(asset.RecRoomQualityConfig,quality),"same quality");Done("asset_quality_same_reference");Set(asset,"m_RecRoomQualityConfig",null);Need(asset.RecRoomQualityConfig==null,"null");Done("asset_quality_null_preserved");
        var ru=typeof(UnityEngine.Rendering.Universal.RenderingUtils);var rf=Static(ru,"m_RenderTextureFormatSupport");var gf=Static(ru,"m_GraphicsFormatSupport");
        var r=new Dictionary<UnityEngine.RenderTextureFormat,bool>{{0,true}};var g=new Dictionary<UnityEngine.Experimental.Rendering.GraphicsFormat,Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>>{{0,new Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>{{0,true}}}};
        rf.SetValue(null,r);gf.SetValue(null,g);UnityEngine.Rendering.Universal.RenderingUtils.ClearSystemInfoCache();Need(r.Count==0&&g.Count==0,"clear");Done("cache_clear_both_real_BCL_dictionaries");Need(ReferenceEquals(r,rf.GetValue(null))&&ReferenceEquals(g,gf.GetValue(null)),"identity");Done("cache_clear_retains_dictionary_references");
        g[0]=new Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>();rf.SetValue(null,null);Need(Throws<NullReferenceException>(()=>UnityEngine.Rendering.Universal.RenderingUtils.ClearSystemInfoCache())&&g.Count==1,"first null before second");Done("cache_first_null_preserves_second");
        rf.SetValue(null,r);r[0]=true;gf.SetValue(null,null);Need(Throws<NullReferenceException>(()=>UnityEngine.Rendering.Universal.RenderingUtils.ClearSystemInfoCache())&&r.Count==0,"first cleared then second null");Done("cache_second_null_after_first_clear");
        var cb=new UnityEngine.Rendering.Universal.UniversalRenderPipeline.OriginalCallbackBindings();var a=new UnityEngine.Camera{Label="a",Value=1.9f};var b=new UnityEngine.Camera{Label="b",Value=1.2f};
        Need(cb.OriginalComparison(a,b)==0,"cast before subtract");Done("comparison_individual_positive_truncation");a.Value=-1.9f;b.Value=-1.2f;Need(cb.OriginalComparison(a,b)==0,"negative truncation");Done("comparison_individual_negative_truncation");a.Value=1.9f;b.Value=-1.2f;Need(cb.OriginalComparison(a,b)==2,"mixed truncation");Done("comparison_mixed_sign_truncation");
        PrereqState.Events.Clear();cb.OriginalComparison(a,b);Need(PrereqState.Events.SequenceEqual(new[]{"a","b"}),"getter order");Done("comparison_original_getter_order");
        PrereqState.Events.Clear();Need(Throws<NullReferenceException>(()=>cb.OriginalComparison(null,b))&&PrereqState.Events.Count==0,"first null");Done("comparison_first_null_before_second_read");
        PrereqState.Events.Clear();Need(Throws<NullReferenceException>(()=>cb.OriginalComparison(a,null))&&PrereqState.Events.SequenceEqual(new[]{"a"}),"second null");Done("comparison_second_null_after_first_read");
        a.Value=2147483520f;b.Value=-2147483648f;Need(cb.OriginalComparison(a,b)==-128,"unchecked int subtraction");Done("comparison_unchecked_subtraction_wraps");
        var output=new UnityEngine.Experimental.GlobalIllumination.LightDataGI[3];var array=new Unity.Collections.NativeArray<UnityEngine.Experimental.GlobalIllumination.LightDataGI>(output);PrereqState.Writes.Clear();cb.OriginalLights(new UnityEngine.Light[0],array);Need(PrereqState.Writes.Count==0,"empty");Done("lights_empty_requests_no_writes");
        cb.OriginalLights(new[]{new UnityEngine.Light{TestId=11},new UnityEngine.Light{TestId=22}},array);Need(output[0].TestId==11&&output[1].TestId==22&&output[0].Generation==1&&output[1].Generation==2&&PrereqState.Writes.SequenceEqual(new[]{0,1}),"one value struct initialized before loop");Done("lights_original_id_order_single_value_initialization");Need(output[2].Generation==0,"tail");Done("lights_unselected_output_tail_preserved");
        PrereqState.Writes.Clear();Need(Throws<NullReferenceException>(()=>cb.OriginalLights(null,array))&&PrereqState.Writes.Count==0,"null requests");Done("lights_null_requests_before_writes");
        Need(Throws<NullReferenceException>(()=>cb.OriginalLights(new UnityEngine.Light[]{null},array))&&PrereqState.Writes.Count==0,"first null request");Done("lights_first_null_element_before_writes");
        Need(Throws<NullReferenceException>(()=>cb.OriginalLights(new UnityEngine.Light[]{new UnityEngine.Light{TestId=33},null},array))&&output[0].TestId==33&&PrereqState.Writes.SequenceEqual(new[]{0}),"prior write survives later null");Done("lights_later_null_preserves_prior_write");
        Need(cases==31,"exact31 effects");Console.WriteLine("RESULT twelve_original_initializer_prerequisites_31_controlled_effects_passed; genuine_Unity_executed=false; renderer_closure=false");
    }
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
    static string TypeKey(TypeReference t){return t.FullName;}
    static string Sig(MethodReference m){return TypeKey(m.ReturnType)+"("+string.Join(",",m.Parameters.Select(p=>TypeKey(p.ParameterType)))+")";}
    static void Inspect(string corePath,string urpPath,string coreDonorPath,string urpDonorPath,string enginePath,string frameworkPath)
    {
        using(var core=ModuleDefinition.ReadModule(corePath))using(var urp=ModuleDefinition.ReadModule(urpPath))using(var cd=ModuleDefinition.ReadModule(coreDonorPath))using(var ud=ModuleDefinition.ReadModule(urpDonorPath))using(var engine=ModuleDefinition.ReadModule(enginePath))using(var framework=ModuleDefinition.ReadModule(frameworkPath))
        {
            Need(core.Assembly.Name.FullName==cd.Assembly.Name.FullName&&urp.Assembly.Name.FullName==ud.Assembly.Name.FullName,"exact two original assembly identities");
            string asset="UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset",generated="UnityEngine.Rendering.Universal.UniversalRenderPipeline/<>c",alias="UnityEngine.Rendering.Universal.UniversalRenderPipeline/OriginalCallbackBindings";
            var owners=new HashSet<string>{asset,generated,alias,"UnityEngine.Rendering.CameraCaptureBridge","UnityEngine.Rendering.Universal.RenderingUtils"};
            var original=Types(core.Types).Concat(Types(urp.Types)).Where(t=>owners.Contains(t.FullName)).ToDictionary(t=>t.FullName);var donors=Types(cd.Types).Concat(Types(ud.Types)).Where(t=>owners.Contains(t.FullName)).ToDictionary(t=>t.FullName);var external=Types(engine.Types).Concat(Types(framework.Types)).Where(t=>t.FullName.StartsWith("System.Collections.Generic.",StringComparison.Ordinal)||t.FullName.StartsWith("UnityEngine.",StringComparison.Ordinal)||t.FullName.StartsWith("Unity.Collections.",StringComparison.Ordinal)).ToDictionary(t=>t.FullName);
            var specs=new List<Tuple<string,string,string,string>>();foreach(var n in new[]{"get_enabled","set_enabled",".cctor"})specs.Add(Tuple.Create("UnityEngine.Rendering.CameraCaptureBridge",n,"UnityEngine.Rendering.CameraCaptureBridge",n));foreach(var n in new[]{"get_renderFeatureset","get_postProcessing","get_supportsHDR","get_msaaSampleCount","get_renderScale","get_RecRoomQualityConfig"})specs.Add(Tuple.Create(asset,n,asset,n));specs.Add(Tuple.Create("UnityEngine.Rendering.Universal.RenderingUtils","ClearSystemInfoCache","UnityEngine.Rendering.Universal.RenderingUtils","ClearSystemInfoCache"));specs.Add(Tuple.Create(generated,"<.ctor>b__32_0",alias,"OriginalComparison"));specs.Add(Tuple.Create(generated,"<.cctor>b__73_0",alias,"OriginalLights"));
            foreach(var s in specs)
            {
                var a=original[s.Item1].Methods.Single(m=>m.Name==s.Item2);var b=donors[s.Item3].Methods.Single(m=>m.Name==s.Item4);Need(Sig(a)==Sig(b)&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&a.HasThis==b.HasThis&&a.CallingConvention==b.CallingConvention&&b.Body.ExceptionHandlers.Count==0,"exact original method contract "+s.Item2);
                foreach(var i in b.Body.Instructions)
                {
                    if(i.Operand is FieldReference f){Need(original.ContainsKey(f.DeclaringType.FullName),"only exact original owned fields");var field=original[f.DeclaringType.FullName].Fields.Single(v=>v.Name==f.Name);Need(TypeKey(field.FieldType)==TypeKey(f.FieldType),"exact original field generic/enum identity");}
                    if(i.Operand is MethodReference method)
                    {
                        var owner=method.DeclaringType is GenericInstanceType gi?gi.ElementType.FullName:method.DeclaringType.FullName;Need(external.TryGetValue(owner,out var t)&&t.Methods.Any(v=>v.Name==method.Name&&Sig(v)==Sig(method)),"exact genuine Unity/BCL callee "+method.FullName);
                    }
                }
            }
            // Scope difference is recorded, never silently retargeted: a later
            // importer must clone the exact original actionDict field type for
            // its one Dictionary ctor, retaining original HashSet System.Core7cec.
            var oldField=original["UnityEngine.Rendering.CameraCaptureBridge"].Fields.Single(f=>f.Name=="actionDict");var donorField=donors["UnityEngine.Rendering.CameraCaptureBridge"].Fields.Single(f=>f.Name=="actionDict");
            var oldSet=(GenericInstanceType)((GenericInstanceType)oldField.FieldType).GenericArguments[1];var newSet=(GenericInstanceType)((GenericInstanceType)donorField.FieldType).GenericArguments[1];
            Console.WriteLine("SCOPE original_HashSet="+oldSet.ElementType.Scope+"; donor_HashSet="+newSet.ElementType.Scope+"; future_import_requires_exact_original_field_TypeSpec=true");
            Need(specs.Count==12,"exact12 bindings");Console.WriteLine("RESULT twelve_exact_original_initializer_prerequisite_bindings_passed_metadata_only; exact_two_generated_aliases_explicit=true; production_donors_loaded=false");
        }
    }
    static int Main(string[] args){try{if(args.Length==0)Run();else if(args.Length==7&&args[0]=="--inspect")Inspect(args[1],args[2],args[3],args[4],args[5],args[6]);else throw new Exception("fixture args");return 0;}catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}}
}
#endif
