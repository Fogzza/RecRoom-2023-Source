// Explicit test-only models. The exact candidate Start method is inserted
// unchanged. Real binding uses a separate full5095-source compile/Cecil read.
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using UnityEngine;
using FX=RecoveryTitleStartControlledEffects.State;
namespace UnityEngine
{
    public enum RenderMode {ScreenSpaceOverlay=0,ScreenSpaceCamera=1,WorldSpace=2}
    public struct Vector3 {public float x,y,z;public Vector3(float a,float b,float c){x=a;y=b;z=c;}}
    public struct Quaternion {public float x,y,z,w;public Quaternion(float a,float b,float c,float d){x=a;y=b;z=c;w=d;}}
    public sealed class Camera {}
    public class MonoBehaviour {}
    public sealed class Transform
    {
        public string Name;public Vector3 Position,Scale;public Quaternion Rotation;
        public Vector3 position {get {FX.Event("position:"+Name);if(FX.OnPosition!=null)FX.OnPosition();return Position;}}
        public Vector3 localScale {get {FX.Event("scale:"+Name);if(FX.OnScale!=null)FX.OnScale();return Scale;}}
        public Quaternion rotation {get {FX.Event("rotation:"+Name);return Rotation;}}
    }
    public sealed class Canvas
    {
        public string Name;public Transform Value;public RenderMode SeenMode;public Camera SeenCamera;public int TransformReads;
        public RenderMode renderMode {set {FX.Event("render:"+Name);SeenMode=value;if(FX.OnRender!=null)FX.OnRender(this);}}
        public Camera worldCamera {set {FX.Event("world:"+Name);SeenCamera=value;if(FX.OnWorld!=null)FX.OnWorld(this);}}
        public Transform transform {get {FX.Event("transform:"+Name+":"+(++TransformReads));if(FX.OnTransform!=null)FX.OnTransform(this);return Value;}}
    }
}
namespace RecRoom.Core.UI
{
    public sealed class UIInputModule
    {
        public static UIInputModule Instance;
        public Camera Value;
        public Camera ControllerCamera {get {FX.Event("camera:input");if(FX.OnCamera!=null)FX.OnCamera();return Value;}}
    }
}
namespace RecoveryTitleStartControlledEffects
{
    enum HGMGOPODGJN {First=17,Other=29}
    sealed class CPBPJLLMKDB
    {
        public Action Current;
        public Action DisplayModeChange
        {
            get {State.Event("service:get");if(State.OnServiceGet!=null)State.OnServiceGet();return Current;}
            set {State.Event("service:set");Current=value;State.PropertySetReceiver=this;}
        }
    }
    sealed class DCCDAPLPICN
    {
        public void LEODHBOENKA(HGMGOPODGJN layout,bool flag)
        {State.Event("layout:set");State.LayoutReceiver=this;State.SeenLayout=layout;State.LayoutFlag=flag;}
    }
    sealed class PlatformManager
    {
        public static PlatformManager Instance {get {State.Event("platform:instance");return State.Platform;}}
        public HGMGOPODGJN DefaultLayout {get {State.Event("layout:get");if(State.OnLayout!=null)State.OnLayout();return State.Layout;}}
    }
    static class JHIKKDDFDGA
    {
        public static IDisposable PEOPJAFNOBD(MonoBehaviour owner,Action<float> callback,bool flag)
        {State.Event("schedule");State.ScheduleOwner=owner;State.Tick=callback;State.ScheduleFlag=flag;return State.Disposable;}
    }
    sealed class TitleStartSubject:MonoBehaviour
    {
        private Canvas mainCanvas;
        private Canvas[] otherCanvases;
        private Vector3 AFFEJPNPKPM;
        private Vector3 AHAPJIODLLJ;
        private Quaternion BGMCKGNIMKN;
        private DCCDAPLPICN IBDKAJJPLGA;
        private CPBPJLLMKDB LIPCPJMCHDF;
        public TitleStartSubject(Canvas main,Canvas[] others,DCCDAPLPICN layout,CPBPJLLMKDB display)
        {mainCanvas=main;otherCanvases=others;IBDKAJJPLGA=layout;LIPCPJMCHDF=display;AFFEJPNPKPM=new Vector3(-1,-1,-1);AHAPJIODLLJ=new Vector3(-2,-2,-2);BGMCKGNIMKN=new Quaternion(-3,-3,-3,-3);}
        /*EXACT_START_METHOD*/
        private void PMNJIOHDABB(){State.Event("callback");State.DirectReceiver=this;if(State.OnCallback!=null)State.OnCallback();}
        private void NMJIFHLPFNP(float value){State.Event("tick");State.TickReceiver=this;State.TickValue=value;}
        public void Run(){Start();}
        public void SetMain(Canvas value){mainCanvas=value;}
        public void SetOthers(Canvas[] value){otherCanvases=value;}
        public void SetDisplay(CPBPJLLMKDB value){LIPCPJMCHDF=value;}
        public void SetLayout(DCCDAPLPICN value){IBDKAJJPLGA=value;}
        public Vector3 Position {get{return AFFEJPNPKPM;}}
        public Vector3 Scale {get{return AHAPJIODLLJ;}}
        public Quaternion Rotation {get{return BGMCKGNIMKN;}}
    }
    sealed class DisposableProbe:IDisposable {public bool Called;public void Dispose(){Called=true;}}
    static class State
    {
        public static readonly List<string> Events=new List<string>();
        public static int FailAt;
        public static Canvas Main,A,B;
        public static Camera Camera;
        public static CPBPJLLMKDB Display,PropertySetReceiver;
        public static DCCDAPLPICN LayoutService,LayoutReceiver;
        public static PlatformManager Platform;
        public static HGMGOPODGJN Layout,SeenLayout;
        public static bool LayoutFlag,ScheduleFlag;
        public static MonoBehaviour ScheduleOwner;
        public static Action<float> Tick;
        public static object DirectReceiver,TickReceiver;
        public static float TickValue;
        public static DisposableProbe Disposable;
        public static TitleStartSubject Subject;
        public static Action<Canvas> OnRender,OnWorld,OnTransform;
        public static Action OnCamera,OnPosition,OnScale,OnServiceGet,OnLayout,OnCallback;
        public static void Event(string name){Events.Add(name);if(FailAt==Events.Count)throw new ApplicationException("controlled-"+name);}
        public static Canvas NewCanvas(string name,float n)
        {return new Canvas{Name=name,Value=new Transform{Name=name,Position=new Vector3(n,n+1,n+2),Scale=new Vector3(n+3,n+4,n+5),Rotation=new Quaternion(n+6,n+7,n+8,n+9)}};}
        public static void Reset()
        {
            Events.Clear();FailAt=0;Main=NewCanvas("main",10);A=NewCanvas("a",20);B=NewCanvas("b",30);Camera=new Camera();RecRoom.Core.UI.UIInputModule.Instance=new RecRoom.Core.UI.UIInputModule{Value=Camera};Display=new CPBPJLLMKDB();LayoutService=new DCCDAPLPICN();Platform=new PlatformManager();Layout=HGMGOPODGJN.Other;SeenLayout=default(HGMGOPODGJN);PropertySetReceiver=null;LayoutReceiver=null;LayoutFlag=ScheduleFlag=false;ScheduleOwner=null;Tick=null;DirectReceiver=TickReceiver=null;TickValue=0;Disposable=new DisposableProbe();Subject=new TitleStartSubject(Main,new[]{A,B},LayoutService,Display);OnRender=OnWorld=OnTransform=null;OnCamera=OnPosition=OnScale=OnServiceGet=OnLayout=OnCallback=null;
        }
    }
    static class Program
    {
        static int cases;
        static readonly string[] Normal={"render:main","camera:input","world:main","transform:main:1","position:main","transform:main:2","scale:main","transform:main:3","rotation:main","render:a","camera:input","world:a","render:b","camera:input","world:b","service:get","service:set","callback","platform:instance","layout:get","layout:set","schedule"};
        static void Need(bool value,string message){if(!value)throw new Exception(message);}
        static bool Same(object a,object b){return System.Object.ReferenceEquals(a,b);}
        static void Events(IEnumerable<string> expected){Need(State.Events.SequenceEqual(expected),"effect order: "+String.Join(",",State.Events));}
        static void Done(){cases++;}
        static bool Throws<T>() where T:Exception {try{State.Subject.Run();return false;}catch(T){return true;}}
        static void Pose(bool pos,bool scale,bool rotation)
        {Need(State.Subject.Position.x==(pos?10:-1)&&State.Subject.Scale.x==(scale?13:-2)&&State.Subject.Rotation.x==(rotation?16:-3),"exact original pose store boundaries");}
        static void Effects()
        {
            State.Reset();State.Subject.Run();Events(Normal);Pose(true,true,true);Need(State.Main.SeenMode==RenderMode.WorldSpace&&State.A.SeenMode==RenderMode.WorldSpace&&State.B.SeenMode==RenderMode.WorldSpace&&Same(State.Main.SeenCamera,State.Camera)&&Same(State.A.SeenCamera,State.Camera)&&Same(State.B.SeenCamera,State.Camera),"three same cameras, WorldSpace2");Need(Same(State.PropertySetReceiver,State.Display)&&Same(State.DirectReceiver,State.Subject)&&Same(State.LayoutReceiver,State.LayoutService)&&State.SeenLayout==HGMGOPODGJN.Other&&State.LayoutFlag&&Same(State.ScheduleOwner,State.Subject)&&State.ScheduleFlag&&!State.Disposable.Called,"exact service/layout/schedule identities/true flags/discarded result");Need(Same(State.Display.Current.Target,State.Subject)&&State.Display.Current.Method.Name=="PMNJIOHDABB"&&Same(State.Tick.Target,State.Subject)&&State.Tick.Method.Name=="NMJIFHLPFNP","exact delegate targets and methods");Done();
            for(int i=0;i<Normal.Length;i++)
            {
                State.Reset();State.FailAt=i+1;Need(Throws<ApplicationException>(),"propagated dependency failure "+i);Events(Normal.Take(i+1));Pose(i>4,i>6,i>8);Need(State.ScheduleOwner==null,"no later scheduling effect after failure");Done();
            }
            State.Reset();State.Subject.SetMain(null);Need(Throws<NullReferenceException>(),"null main fails before first effect");Events(new string[0]);Done();
            State.Reset();RecRoom.Core.UI.UIInputModule.Instance=null;Need(Throws<NullReferenceException>(),"null UI instance fails after mode and before worldCamera");Events(Normal.Take(1));Done();
            State.Reset();State.Main.Value=null;Need(Throws<NullReferenceException>(),"null transform");Events(Normal.Take(4));Pose(false,false,false);Done();
            State.Reset();State.Subject.SetOthers(null);State.Subject.Run();Events(Normal.Take(9).Concat(Normal.Skip(15)));Done();
            State.Reset();State.Subject.SetOthers(new Canvas[0]);State.Subject.Run();Events(Normal.Take(9).Concat(Normal.Skip(15)));Done();
            State.Reset();State.Subject.SetOthers(new Canvas[]{null});Need(Throws<NullReferenceException>(),"null array element");Events(Normal.Take(9));Done();
            State.Reset();State.OnRender=c=>{if(Same(c,State.A))State.Subject.SetOthers(null);};Need(Throws<NullReferenceException>(),"array reread after render setter");Events(Normal.Take(10));Done();
            State.Reset();State.OnRender=c=>{if(Same(c,State.A))State.Subject.SetOthers(new Canvas[0]);};Need(Throws<IndexOutOfRangeException>(),"bounds reread after render setter");Events(Normal.Take(10));Done();
            State.Reset();var replacement=State.NewCanvas("replacement",40);State.OnRender=c=>{if(Same(c,State.A))State.Subject.SetOthers(new[]{replacement});};State.Subject.Run();Need(Same(replacement.SeenCamera,State.Camera)&&State.A.SeenCamera==null,"second same-index lookup uses replaced array");Events(Normal.Take(10).Concat(new[]{"camera:input","world:replacement"}).Concat(Normal.Skip(15)));Done();
            State.Reset();State.OnWorld=c=>{if(Same(c,State.A))State.Subject.SetOthers(null);};Need(Throws<NullReferenceException>(),"condition rereads null array");Events(Normal.Take(12));Done();
            State.Reset();State.OnWorld=c=>{if(Same(c,State.A))State.Subject.SetOthers(new Canvas[0]);};State.Subject.Run();Events(Normal.Take(12).Concat(Normal.Skip(15)));Done();
            State.Reset();State.Subject.SetOthers(new[]{State.A});State.OnWorld=c=>{if(Same(c,State.A))State.Subject.SetOthers(new[]{State.A,State.B});};State.Subject.Run();Events(Normal);Done();
            State.Reset();var p=State.NewCanvas("p",100);var s=State.NewCanvas("s",200);var r=State.NewCanvas("r",300);State.OnRender=c=>{if(Same(c,State.Main))State.Subject.SetMain(p);};State.OnTransform=c=>{if(Same(c,p))State.Subject.SetMain(s);};State.OnScale=()=>State.Subject.SetMain(r);State.Subject.SetOthers(null);State.Subject.Run();Need(State.Subject.Position.x==100&&State.Subject.Scale.x==203&&State.Subject.Rotation.x==306&&Same(p.SeenCamera,State.Camera)&&State.Main.SeenCamera==null,"main/transform accesses separately reevaluated");Events(new[]{"render:main","camera:input","world:p","transform:p:1","position:p","transform:s:1","scale:s","transform:r:1","rotation:r"}.Concat(Normal.Skip(15)));Done();
            State.Reset();var original=State.Display;var changed=new CPBPJLLMKDB();State.OnServiceGet=()=>State.Subject.SetDisplay(changed);State.Subject.Run();Need(Same(State.PropertySetReceiver,original)&&original.Current!=null&&changed.Current==null,"same compound-assignment receiver retained across getter side effect");Events(Normal);Done();
            State.Reset();State.Subject.SetDisplay(null);Need(Throws<NullReferenceException>(),"null display property receiver");Events(Normal.Take(15));Done();
            State.Reset();State.Platform=null;Need(Throws<NullReferenceException>(),"null platform singleton");Events(Normal.Take(19));Done();
            State.Reset();State.Subject.SetLayout(null);Need(Throws<NullReferenceException>(),"layout receiver fails after argument getters");Events(Normal.Take(20));Done();
            State.Reset();RecRoom.Core.UI.UIInputModule.Instance.Value=null;State.Subject.Run();Need(State.Main.SeenCamera==null&&State.A.SeenCamera==null&&State.B.SeenCamera==null,"null camera forwarded normally");Events(Normal);Done();
            State.Reset();State.Display.Current=()=>State.Event("previous");State.Subject.Run();State.Events.Clear();State.Display.Current();State.Tick(123.5f);Events(new[]{"previous","callback","tick"});Need(Same(State.DirectReceiver,State.Subject)&&Same(State.TickReceiver,State.Subject)&&State.TickValue==123.5f,"prior listener order and exact scheduled callback argument");Done();
            Need(cases==42,"exact finite42 effect cases");Console.WriteLine("{\"status\":\"fortytwo_exact_Start_controlled_effect_cases_passed\",\"cases\":42,\"production_callees_or_Unity_executed\":false,\"working_boot_claimed\":false}");
        }
        static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
        static void NeedCall(MethodReference method,string owner,string name,string ret,params string[] args)
        {Need(method.DeclaringType.FullName==owner&&method.Name==name&&method.ReturnType.FullName==ret&&method.Parameters.Select(x=>x.ParameterType.FullName).SequenceEqual(args),"exact typed call "+owner+"."+name);}
        static void Inspect(string path)
        {
            using(var m=ModuleDefinition.ReadModule(path,new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false}))
            {
                var owner=Types(m.Types).Single(x=>x.FullName=="TitleScreenManager");var method=owner.Methods.Single(x=>x.Name=="Start"&&x.Parameters.Count==0);Need(method.IsPrivate&&!method.IsStatic&&method.ReturnType.FullName=="System.Void","exact private instance Start");var il=method.Body.Instructions.ToArray();var callInstructions=il.Where(x=>x.OpCode.Code==Code.Call||x.OpCode.Code==Code.Callvirt||x.OpCode.Code==Code.Newobj).ToArray();var calls=callInstructions.Select(x=>(MethodReference)x.Operand).ToArray();Need(calls.Length==22,"exact22 compiled calls");
                foreach(int n in new[]{0,9})NeedCall(calls[n],"UnityEngine.Canvas","set_renderMode","System.Void","UnityEngine.RenderMode");foreach(int n in new[]{1,10})NeedCall(calls[n],"RecRoom.Core.UI.UIInputModule","get_ControllerCamera","UnityEngine.Camera");foreach(int n in new[]{2,11})NeedCall(calls[n],"UnityEngine.Canvas","set_worldCamera","System.Void","UnityEngine.Camera");foreach(int n in new[]{3,5,7})NeedCall(calls[n],"UnityEngine.Component","get_transform","UnityEngine.Transform");NeedCall(calls[4],"UnityEngine.Transform","get_position","UnityEngine.Vector3");NeedCall(calls[6],"UnityEngine.Transform","get_localScale","UnityEngine.Vector3");NeedCall(calls[8],"UnityEngine.Transform","get_rotation","UnityEngine.Quaternion");NeedCall(calls[12],"CPBPJLLMKDB","get_DisplayModeChange","System.Action");NeedCall(calls[13],"System.Action",".ctor","System.Void","System.Object","System.IntPtr");NeedCall(calls[14],"System.Delegate","Combine","System.Delegate","System.Delegate","System.Delegate");NeedCall(calls[15],"CPBPJLLMKDB","set_DisplayModeChange","System.Void","System.Action");NeedCall(calls[16],"TitleScreenManager","PMNJIOHDABB","System.Void");Need(calls[17].DeclaringType.FullName=="SingletonMonoBehaviour`1<PlatformManager>"&&calls[17].Name=="get_Instance"&&calls[17].Parameters.Count==0,"exact platform singleton getter");NeedCall(calls[18],"PlatformManager","get_DefaultLayout","HGMGOPODGJN");NeedCall(calls[19],"DCCDAPLPICN","LEODHBOENKA","System.Void","HGMGOPODGJN","System.Boolean");NeedCall(calls[20],"System.Action`1<System.Single>",".ctor","System.Void","System.Object","System.IntPtr");NeedCall(calls[21],"JHIKKDDFDGA","PEOPJAFNOBD","System.IDisposable","UnityEngine.MonoBehaviour","System.Action`1<System.Single>","System.Boolean");
                foreach(int n in new[]{0,9}){var at=callInstructions[n];Need(at.Previous.OpCode.Code==Code.Ldc_I4_2,"exact WorldSpace2");}foreach(int n in new[]{19,21}){var at=callInstructions[n];Need(at.Previous.OpCode.Code==Code.Ldc_I4_1,"exact true argument");}Need(callInstructions[21].Next.OpCode.Code==Code.Pop,"scheduler result discarded");
                var delegates=il.Where(x=>x.OpCode.Code==Code.Ldftn).Select(x=>(MethodReference)x.Operand).ToArray();Need(delegates.Length==2,"exact two delegate targets");NeedCall(delegates[0],"TitleScreenManager","PMNJIOHDABB","System.Void");NeedCall(delegates[1],"TitleScreenManager","NMJIFHLPFNP","System.Void","System.Single");Need(il.Count(x=>x.OpCode.Code==Code.Castclass&&((TypeReference)x.Operand).FullName=="System.Action")==1,"exact delegate cast");
                var fields=il.Where(x=>x.Operand is FieldReference).Select(x=>(FieldReference)x.Operand).ToArray();Need(fields.Length==16,"exact16 original field accesses");Need(fields.Count(x=>x.DeclaringType.FullName=="TitleScreenManager"&&x.Name=="mainCanvas"&&x.FieldType.FullName=="UnityEngine.Canvas")==5&&fields.Count(x=>x.DeclaringType.FullName=="TitleScreenManager"&&x.Name=="otherCanvases"&&x.FieldType.FullName=="UnityEngine.Canvas[]")==4&&fields.Count(x=>x.DeclaringType.FullName=="RecRoom.Core.UI.UIInputModule"&&x.Name=="Instance"&&x.FieldType.FullName=="RecRoom.Core.UI.UIInputModule")==2,"exact repeated canvas and singleton fields");
                var stores=il.Where(x=>x.OpCode.Code==Code.Stfld).Select(x=>(FieldReference)x.Operand).ToArray();Need(stores.Length==3&&stores.Select(x=>x.Name).SequenceEqual(new[]{"AFFEJPNPKPM","AHAPJIODLLJ","BGMCKGNIMKN"})&&stores.Select(x=>x.FieldType.FullName).SequenceEqual(new[]{"UnityEngine.Vector3","UnityEngine.Vector3","UnityEngine.Quaternion"}),"only exact ordered pose fields written");Need(fields.Count(x=>x.DeclaringType.FullName=="TitleScreenManager"&&x.Name=="LIPCPJMCHDF"&&x.FieldType.FullName=="CPBPJLLMKDB")==1&&fields.Count(x=>x.DeclaringType.FullName=="TitleScreenManager"&&x.Name=="IBDKAJJPLGA"&&x.FieldType.FullName=="DCCDAPLPICN")==1,"exact service receivers");Need(!il.Any(x=>x.OpCode.Code==Code.Newarr),"no substituted array snapshot");
                Console.WriteLine("{\"status\":\"actual_full_Start_file_typed_binding_verified_metadata_only\",\"members\":1,\"game_code_invoked\":false}");
            }
        }
        static int Main(string[] args){try{if(args.Length==0)Effects();else if(args.Length==2&&args[0]=="--inspect")Inspect(args[1]);else throw new Exception("invalid harness arguments");return 0;}catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}}
    }
}
