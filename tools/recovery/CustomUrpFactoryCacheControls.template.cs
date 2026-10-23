// Only seven inserted original members are candidates. Compile once against
// genuine Unity API for metadata binding; a separate controlled executable
// uses explicit fake dependencies. Never load or ship this donor module.
using System;
#if URP_EFFECT_CONTROLS
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
namespace UnityEngine
{
    public class Object
    {
        public bool TestDestroyed;
        public string name {get {if(UrpControlState.ThrowName)throw new ApplicationException("name-marker");return TestName;}set{TestName=value;}}
        public string TestName;
        static bool Empty(Object x){return System.Object.ReferenceEquals(x,null)||x.TestDestroyed;}
        public static bool operator==(Object a,Object b){if(System.Object.ReferenceEquals(a,null))return Empty(b);if(System.Object.ReferenceEquals(b,null))return Empty(a);return System.Object.ReferenceEquals(a,b);}
        public static bool operator!=(Object a,Object b){return !(a==b);}
        public override bool Equals(object other){return System.Object.ReferenceEquals(this,other);}
        public override int GetHashCode(){return base.GetHashCode();}
    }
    public class ScriptableObject:Object {}
    public class Camera:Object {}
    public static class Debug
    {
        public static void LogError(object message,Object context){UrpControlState.Events.Add("log");UrpControlState.Message=(string)message;UrpControlState.Context=context;if(UrpControlState.ThrowLog)throw new ApplicationException("log-marker");}
    }
}
namespace UnityEngine.Rendering
{
    public struct ScriptableRenderContext {}
    public abstract class RenderPipeline {protected abstract void Render(ScriptableRenderContext context,UnityEngine.Camera[] cameras);}
    public abstract class RenderPipelineAsset:UnityEngine.ScriptableObject {protected abstract RenderPipeline CreatePipeline();}
    public static class GraphicsSettings
    {
        public static RenderPipelineAsset currentRenderPipeline {get{UrpControlState.SettingsReads++;return UrpControlState.Current;} }
    }
}
#endif
namespace UnityEngine.Rendering.Universal
{
    public abstract class ScriptableRenderer:IDisposable
    {
        public void Dispose()
        {
#if URP_EFFECT_CONTROLS
            UrpControlState.Events.Add("dispose:"+TestId);if(TestDispose!=null)TestDispose();
#else
            throw new NotImplementedException("Unselected original disposal body: metadata context only");
#endif
        }
#if URP_EFFECT_CONTROLS
        public string TestId;public Action TestDispose;
#endif
    }
    public sealed class ForwardRenderer:ScriptableRenderer
    {
        public ForwardRenderer(ForwardRendererData data)
        {
#if URP_EFFECT_CONTROLS
            UrpControlState.Events.Add("forward");UrpControlState.ForwardData=data;UrpControlState.Forward=this;if(UrpControlState.ThrowForward)throw new ApplicationException("forward-marker");
#else
            throw new NotImplementedException("Unselected original ForwardRenderer constructor");
#endif
        }
    }
    public abstract class ScriptableRendererData:UnityEngine.ScriptableObject
    {
        internal bool isInvalidated {get;set;}
        protected abstract ScriptableRenderer Create();
        /*ORIGINAL_INTERNAL_CREATE*/
    }
    public class ForwardRendererData:ScriptableRendererData
    {
        /*ORIGINAL_FORWARD_CREATE*/
#if URP_EFFECT_CONTROLS
        public ScriptableRenderer TestCreate(){return Create();}
#endif
    }
    public class UniversalRenderPipelineAsset:UnityEngine.Rendering.RenderPipelineAsset
    {
        private ScriptableRenderer[] m_Renderers;
        private int k_AssetVersion;
        private int k_AssetPreviousVersion;
        internal ScriptableRendererData[] m_RendererDataList;
        internal int m_DefaultRendererIndex;
        /*ORIGINAL_ASSET_CREATE*/
        /*ORIGINAL_ASSET_CACHE*/
#if URP_EFFECT_CONTROLS
        public ScriptableRenderer[] TestCache {get{return m_Renderers;}set{m_Renderers=value;}}
        public void TestVersions(int now,int previous){k_AssetVersion=now;k_AssetPreviousVersion=previous;}
        public UnityEngine.Rendering.RenderPipeline TestPipeline(){return CreatePipeline();}
        public void TestDestroyAll(){DestroyRenderers();}
        public void TestCreateAll(){CreateRenderers();}
        public void TestDestroyRef(ref ScriptableRenderer value){DestroyRenderer(ref value);}
#endif
    }
    public class UniversalRenderPipeline:UnityEngine.Rendering.RenderPipeline
    {
        public UniversalRenderPipeline(UniversalRenderPipelineAsset value)
        {
#if URP_EFFECT_CONTROLS
            UrpControlState.Events.Add("pipeline");UrpControlState.PipelineAsset=value;UrpControlState.Pipeline=this;if(UrpControlState.ThrowPipeline)throw new ApplicationException("pipeline-marker");
#else
            throw new NotImplementedException("Unselected original UniversalRenderPipeline constructor");
#endif
        }
        protected override void Render(UnityEngine.Rendering.ScriptableRenderContext context,UnityEngine.Camera[] cameras){throw new NotImplementedException("Unselected original frame loop");}
        /*ORIGINAL_PIPELINE_ASSET*/
    }
}
#if URP_EFFECT_CONTROLS
static class UrpControlState
{
    public static readonly List<string> Events=new List<string>();
    public static UnityEngine.Rendering.RenderPipelineAsset Current;
    public static UnityEngine.Rendering.Universal.ForwardRendererData ForwardData;
    public static UnityEngine.Rendering.Universal.ForwardRenderer Forward;
    public static UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset PipelineAsset;
    public static UnityEngine.Rendering.Universal.UniversalRenderPipeline Pipeline;
    public static string Message;public static UnityEngine.Object Context;
    public static bool ThrowLog,ThrowName,ThrowForward,ThrowPipeline;public static int SettingsReads;
    public static void Reset(){Events.Clear();Current=null;ForwardData=null;Forward=null;PipelineAsset=null;Pipeline=null;Message=null;Context=null;ThrowLog=ThrowName=ThrowForward=ThrowPipeline=false;SettingsReads=0;}
}
sealed class UrpTestRenderer:UnityEngine.Rendering.Universal.ScriptableRenderer {}
sealed class UrpDerivedRenderer:UnityEngine.Rendering.Universal.ScriptableRenderer {}
sealed class UrpTestData:UnityEngine.Rendering.Universal.ScriptableRendererData
{
    public string Id;public Func<UnityEngine.Rendering.Universal.ScriptableRenderer> Action;
    protected override UnityEngine.Rendering.Universal.ScriptableRenderer Create(){UrpControlState.Events.Add("create:"+Id);if(isInvalidated)throw new Exception("invalidation must clear before virtual dispatch");return Action==null?null:Action();}
}
sealed class UrpOtherAsset:UnityEngine.Rendering.RenderPipelineAsset {protected override UnityEngine.Rendering.RenderPipeline CreatePipeline(){throw new NotImplementedException("test-only other asset");}}
sealed class UrpChildAsset:UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset {}
static class CustomUrpFactoryCacheControls
{
    static int cases;
    static void Need(bool value,string message){if(!value)throw new Exception(message);}
    static bool Same(object a,object b){return System.Object.ReferenceEquals(a,b);}
    static void Done(string name){cases++;Console.WriteLine("PASS "+name);}
    static void Events(params string[] expected){Need(UrpControlState.Events.SequenceEqual(expected),"effect sequence: "+String.Join(",",UrpControlState.Events));}
    static bool Throws<T>(Action action,string message=null) where T:Exception {try{action();return false;}catch(Exception e){return e is T&&(message==null||e.Message==message);}}
    static UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset Fresh()
    {UrpControlState.Reset();return new UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset();}
    static UrpTestRenderer Renderer(string id){return new UrpTestRenderer{TestId=id};}
    static UrpTestData Data(string id,UnityEngine.Rendering.Universal.ScriptableRenderer result){return new UrpTestData{Id=id,isInvalidated=true,Action=()=>result};}
    static void Run()
    {
        var asset=Fresh();var renderer=Renderer("a");var data=Data("a",renderer);Need(Same(data.InternalCreateRenderer(),renderer)&&!data.isInvalidated,"exact result/field state");Events("create:a");Done("invalidation before virtual dispatch, same result");
        asset=Fresh();data=Data("a",null);Need(data.InternalCreateRenderer()==null&&!data.isInvalidated,"null virtual result");Done("null virtual result preserved");
        asset=Fresh();data=Data("a",null);data.Action=()=>{throw new ApplicationException("create-marker");};Need(Throws<ApplicationException>(()=>data.InternalCreateRenderer(),"create-marker")&&!data.isInvalidated,"virtual exception after field cleared");Done("virtual exception and field order");
        asset=Fresh();var forwardData=new UnityEngine.Rendering.Universal.ForwardRendererData();var forward=forwardData.TestCreate();Need(Same(forward,UrpControlState.Forward)&&Same(forwardData,UrpControlState.ForwardData),"same original data forwarded");Events("forward");Done("forward factory exact input and allocated result");
        asset=Fresh();UrpControlState.ThrowForward=true;Need(Throws<ApplicationException>(()=>new UnityEngine.Rendering.Universal.ForwardRendererData().TestCreate(),"forward-marker"),"constructor exception");Done("forward constructor exception propagates");
        asset=Fresh();Need(UnityEngine.Rendering.Universal.UniversalRenderPipeline.asset==null&&UrpControlState.SettingsReads==1,"null current asset");Done("asset getter null");
        asset=Fresh();UrpControlState.Current=new UrpOtherAsset();Need(UnityEngine.Rendering.Universal.UniversalRenderPipeline.asset==null,"wrong type is safe null");Done("asset getter safe wrong type");
        asset=Fresh();UrpControlState.Current=asset;Need(Same(UnityEngine.Rendering.Universal.UniversalRenderPipeline.asset,asset),"same current asset");var child=new UrpChildAsset();UrpControlState.Current=child;Need(Same(UnityEngine.Rendering.Universal.UniversalRenderPipeline.asset,child),"subclass accepted");Done("asset getter same reference and derived type");
        asset=Fresh();asset.TestDestroyAll();Need(asset.TestCache==null,"null cache unchanged");Events();Done("null cache destruction");
        asset=Fresh();var empty=new UnityEngine.Rendering.Universal.ScriptableRenderer[0];asset.TestCache=empty;asset.TestDestroyAll();Need(Same(asset.TestCache,empty),"empty array identity");Events();Done("empty cache identity preserved");
        asset=Fresh();renderer=Renderer("a");var second=Renderer("b");var original=new UnityEngine.Rendering.Universal.ScriptableRenderer[]{renderer,null,second};asset.TestCache=original;asset.TestDestroyAll();Need(Same(asset.TestCache,original)&&original.All(x=>x==null),"same slots cleared");Events("dispose:a","dispose:b");Done("nonnull slots disposed and cleared in order");
        asset=Fresh();renderer=Renderer("a");second=Renderer("b");second.TestDispose=()=>{throw new ApplicationException("dispose-marker");};original=new UnityEngine.Rendering.Universal.ScriptableRenderer[]{renderer,second};asset.TestCache=original;Need(Throws<ApplicationException>(()=>asset.TestDestroyAll(),"dispose-marker")&&original[0]==null&&Same(original[1],second),"clear only after successful dispose");Events("dispose:a","dispose:b");Done("disposal exception preserves uncleared ref");
        asset=Fresh();renderer=Renderer("a");original=new UnityEngine.Rendering.Universal.ScriptableRenderer[]{renderer,Renderer("old-later")};var replacement=new UnityEngine.Rendering.Universal.ScriptableRenderer[]{Renderer("new")};renderer.TestDispose=()=>asset.TestCache=replacement;asset.TestCache=original;asset.TestDestroyAll();Need(original[0]==null&&original[1]!=null&&Same(asset.TestCache,replacement)&&replacement[0]!=null,"captured ref clear and field reread");Events("dispose:a");Done("captured array ref and cache reread preserved");
        asset=Fresh();renderer=Renderer("old");var result=Renderer("new");original=new UnityEngine.Rendering.Universal.ScriptableRenderer[]{renderer};asset.TestCache=original;asset.m_RendererDataList=new[]{Data("a",result)};asset.TestCreateAll();Need(Same(asset.TestCache,original)&&Same(original[0],result),"matching cache reused");Events("dispose:old","create:a");Done("destroy precedes creation and same-length cache reused");
        asset=Fresh();original=new UnityEngine.Rendering.Universal.ScriptableRenderer[0];asset.TestCache=original;asset.m_RendererDataList=new UnityEngine.Rendering.Universal.ScriptableRendererData[]{null,null};asset.TestCreateAll();Need(!Same(asset.TestCache,original)&&asset.TestCache.Length==2,"different length allocated");Events();Done("cache resize exact data length");
        asset=Fresh();asset.m_RendererDataList=new UnityEngine.Rendering.Universal.ScriptableRendererData[0];asset.TestCreateAll();Need(asset.TestCache!=null&&asset.TestCache.Length==0,"null cache zero-length allocation");Done("null cache allocation including empty length");
        asset=Fresh();renderer=Renderer("old");original=new UnityEngine.Rendering.Universal.ScriptableRenderer[]{renderer};asset.TestCache=original;Need(Throws<NullReferenceException>(()=>asset.TestCreateAll())&&original[0]==null,"destroy occurs before null list exception");Events("dispose:old");Done("null data list preserves exception after destroy");
        asset=Fresh();data=Data("dead",Renderer("unused"));data.TestDestroyed=true;asset.m_RendererDataList=new UnityEngine.Rendering.Universal.ScriptableRendererData[]{null,data};asset.TestCreateAll();Need(asset.TestCache.All(x=>x==null)&&data.isInvalidated,"Unity-null and destroyed refs skipped");Events();Done("test-policy Unity-null data skipped");
        asset=Fresh();var typed=new UrpDerivedRenderer[1];asset.TestCache=typed;asset.m_RendererDataList=new[]{Data("a",Renderer("wrong-array-type"))};Need(Throws<ArrayTypeMismatchException>(()=>asset.TestCreateAll())&&Same(asset.TestCache,typed)&&typed[0]==null,"runtime array covariance check retained");Done("array covariance exception preserved");
        asset=Fresh();asset.m_RendererDataList=new[]{Data("a",Renderer("new"))};var pipeline=asset.TestPipeline();Need(Same(pipeline,UrpControlState.Pipeline)&&Same(asset,UrpControlState.PipelineAsset)&&asset.TestCache[0]!=null,"same asset and created cache");Events("create:a","pipeline");Done("pipeline factory cache before constructor");
        asset=Fresh();asset.TestVersions(2,1);asset.m_RendererDataList=new UnityEngine.Rendering.Universal.ScriptableRendererData[]{null};Need(asset.TestPipeline()==null&&UrpControlState.SettingsReads==0,"mismatched versions silent null");Events();Done("missing renderer version mismatch");
        asset=Fresh();asset.m_RendererDataList=new UnityEngine.Rendering.Universal.ScriptableRendererData[]{null};UrpControlState.Current=asset;asset.name="Original asset";Need(asset.TestPipeline()==null&&UrpControlState.Message=="Default Renderer is missing, make sure there is a Renderer assigned as the default on the current Universal RP asset:Original asset"&&Same(UrpControlState.Context,asset),"exact log/context");Events("log");Done("missing renderer exact error and context");
        asset=Fresh();asset.TestVersions(2,1);Need(asset.TestPipeline()==null&&asset.m_RendererDataList.Length==1&&asset.m_RendererDataList[0]==null,"one-slot null list allocation");Done("pipeline initializes absent data list exactly once");
        asset=Fresh();asset.m_RendererDataList=new UnityEngine.Rendering.Universal.ScriptableRendererData[0];Need(Throws<IndexOutOfRangeException>(()=>asset.TestPipeline()),"empty data-list bounds");asset.m_RendererDataList=new UnityEngine.Rendering.Universal.ScriptableRendererData[]{null};asset.m_DefaultRendererIndex=-1;Need(Throws<IndexOutOfRangeException>(()=>asset.TestPipeline()),"negative default index");Events();Done("default index exceptions preserved");
        asset=Fresh();asset.m_RendererDataList=new UnityEngine.Rendering.Universal.ScriptableRendererData[]{null};Need(Throws<NullReferenceException>(()=>asset.TestPipeline())&&UrpControlState.Message==null,"null current asset no invented name");Done("error branch null current asset exception");
        asset=Fresh();UrpControlState.Current=asset;UrpControlState.ThrowLog=true;asset.m_RendererDataList=new UnityEngine.Rendering.Universal.ScriptableRendererData[]{null};Need(Throws<ApplicationException>(()=>asset.TestPipeline(),"log-marker"),"logging exception");Events("log");Done("logging exception propagates");
        asset=Fresh();asset.m_RendererDataList=new[]{Data("a",Renderer("new"))};UrpControlState.ThrowPipeline=true;Need(Throws<ApplicationException>(()=>asset.TestPipeline(),"pipeline-marker")&&asset.TestCache[0]!=null,"constructor failure does not roll back cache");Events("create:a","pipeline");Done("pipeline constructor exception after cache effects");
        Need(cases==27,"exact finite27 controlled cases");Console.WriteLine("RESULT seven_exact_URP_members_twenty_seven_controlled_effects_passed; real_Unity_dependencies_executed=false; renderer_constructor_disposal_frame_closure=false");
    }
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
    static string TypeKey(TypeReference t){if(t is ByReferenceType r)return TypeKey(r.ElementType)+"&";if(t is ArrayType a)return TypeKey(a.ElementType)+"[]";return t.FullName;}
    static string Sig(MethodReference m){return TypeKey(m.ReturnType)+"("+String.Join(",",m.Parameters.Select(p=>TypeKey(p.ParameterType)))+")";}
    static void Inspect(string originalPath,string donorPath,string genuineUnityPath)
    {
        using(var original=ModuleDefinition.ReadModule(originalPath))using(var donor=ModuleDefinition.ReadModule(donorPath))using(var unity=ModuleDefinition.ReadModule(genuineUnityPath))
        {
            Need(original.Assembly.Name.FullName==donor.Assembly.Name.FullName,"same original assembly identity");
            var originals=Types(original.Types).ToDictionary(t=>t.FullName);var donors=Types(donor.Types).ToDictionary(t=>t.FullName);var unityTypes=Types(unity.Types).ToDictionary(t=>t.FullName);
            string ns="UnityEngine.Rendering.Universal.";var selected=new[]{Tuple.Create(ns+"UniversalRenderPipelineAsset","CreatePipeline",0),Tuple.Create(ns+"UniversalRenderPipelineAsset","DestroyRenderers",0),Tuple.Create(ns+"UniversalRenderPipelineAsset","DestroyRenderer",1),Tuple.Create(ns+"UniversalRenderPipelineAsset","CreateRenderers",0),Tuple.Create(ns+"ForwardRendererData","Create",0),Tuple.Create(ns+"ScriptableRendererData","InternalCreateRenderer",0),Tuple.Create(ns+"UniversalRenderPipeline","get_asset",0)};int count=0;
            foreach(var spec in selected)
            {
                var a=originals[spec.Item1].Methods.Single(m=>m.Name==spec.Item2&&m.Parameters.Count==spec.Item3);var b=donors[spec.Item1].Methods.Single(m=>m.Name==spec.Item2&&m.Parameters.Count==spec.Item3);
                Need(Sig(a)==Sig(b)&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&a.CallingConvention==b.CallingConvention&&a.HasThis==b.HasThis&&b.Body.ExceptionHandlers.Count==0,"original selected signature/flags "+spec);
                foreach(var i in b.Body.Instructions)
                {
                    if(i.Operand is FieldReference f){Need(originals.ContainsKey(f.DeclaringType.FullName),"only original-owned fields");var af=originals[f.DeclaringType.FullName].Fields.Single(x=>x.Name==f.Name);Need(TypeKey(af.FieldType)==TypeKey(f.FieldType),"exact original field name/type");}
                    if(i.Operand is MethodReference m)
                    {
                        if(donors.ContainsKey(m.DeclaringType.FullName)){Need(originals.ContainsKey(m.DeclaringType.FullName)&&originals[m.DeclaringType.FullName].Methods.Count(x=>x.Name==m.Name&&Sig(x)==Sig(m))==1,"exact original-owned callee");}
                        else if(m.DeclaringType.FullName.StartsWith("UnityEngine.",StringComparison.Ordinal)){Need(unityTypes.ContainsKey(m.DeclaringType.FullName)&&unityTypes[m.DeclaringType.FullName].Methods.Any(x=>x.Name==m.Name&&Sig(x)==Sig(m)),"genuine matching Unity external method");}
                        else Need(m.DeclaringType.FullName=="System.String"&&m.Name=="Concat"&&m.Parameters.Count==2,"only expected BCL string concatenation");
                    }
                }
                count++;
            }
            Need(count==7,"exact seven bindings");Console.WriteLine("RESULT seven_exact_URP_original_owner_member_bindings_passed_metadata_only; production_or_donor_loaded=false");
        }
    }
    static int Main(string[] args){try{if(args.Length==0)Run();else if(args.Length==4&&args[0]=="--inspect")Inspect(args[1],args[2],args[3]);else throw new Exception("fixture arguments");return 0;}catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}}
}
#endif
