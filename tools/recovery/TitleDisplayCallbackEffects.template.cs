// Explicit controlled effects, not recovered production framework/callee bodies.
// Actual candidate method is inserted unchanged; full-file binding is separate.
using System;
using System.Linq;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using UnityEngine;
using FX=RecoveryDisplayControlledEffects.State;
namespace UnityEngine
{
    public class Object
    {
        public bool Alive=true;
        public static bool operator !=(Object a,Object b){FX.Event("background:test");FX.ComparedBackground=a;if(FX.OnBackgroundTest!=null)FX.OnBackgroundTest();return !System.Object.ReferenceEquals(a,null)&&a.Alive;}
        public static bool operator ==(Object a,Object b){FX.Event("attached:equal");FX.EqualLeft=a;FX.EqualRight=b;return FX.Equality;}
        public override bool Equals(object value){throw new Exception("unexpected Equals");}
        public override int GetHashCode(){return 1;}
    }
    public class Behaviour:Object {public bool SeenEnabled;public bool enabled {set {FX.Event("background:enabled");SeenEnabled=value;FX.EnabledReceiver=this;}}}
    public class MonoBehaviour:Behaviour {}
    public class GameObject:Object {}
    public struct Vector2 {public float x,y;public Vector2(float a,float b){x=a;y=b;}}
    public struct Vector3
    {
        public float x,y,z;public Vector3(float a,float b,float c){x=a;y=b;z=c;}
        public static float Distance(Vector3 a,Vector3 b){FX.Event("distance");FX.DistanceLeft=a;FX.DistanceRight=b;float x=a.x-b.x,y=a.y-b.y,z=a.z-b.z;return (float)Math.Sqrt(x*x+y*y+z*z);}
    }
    public struct Quaternion {public float x,y,z,w;public Quaternion(float a,float b,float c,float d){x=a;y=b;z=c;w=d;}}
    public sealed class Transform
    {
        public string Name;public Vector3 Position,Scale;public Quaternion Rotation;
        public Vector3 position {get {FX.Event(Name+":position:get");if(Name=="screen"&&FX.OnScreenPosition!=null)FX.OnScreenPosition();return Position;}set {FX.Event(Name+":position:set");Position=value;if(FX.OnPositionSet!=null)FX.OnPositionSet();}}
        public Vector3 localScale {set {FX.Event(Name+":scale:set");Scale=value;}}
        public Quaternion rotation {get {FX.Event(Name+":rotation:get");return Rotation;}set {FX.Event(Name+":rotation:set");Rotation=value;}}
    }
    public sealed class Canvas:Behaviour
    {
        public Transform Pose;public GameObject Value;
        public GameObject gameObject {get {FX.Event("canvas:object");return Value;}}
        public Transform transform {get {FX.Event("canvas:transform");if(FX.OnCanvasTransform!=null)FX.OnCanvasTransform();return Pose;}}
    }
    public sealed class Camera:Behaviour
    {
        public string Name;public Transform Pose;public float Clip;
        public Transform transform {get {FX.Event(Name+":transform");return Pose;}}
        public float farClipPlane {set {FX.Event("clip:set");Clip=value;FX.ClipReceiver=this;}}
    }
}
namespace RRUI {public sealed class RoundedCorners:Behaviour {}}
namespace RecRoom.Core.UI
{
    public sealed class UIInputModule {public static UIInputModule Instance;public Camera Value;public Camera ControllerCamera {get {FX.Event("ui:camera");return Value;}}}
}
namespace RecRoom.Core
{
    public sealed class CameraRig
    {
        public ScreenHUD HUD;public Camera Camera;
        public static CameraRig Instance {get {int n=++FX.RigReads;FX.Event("rig:"+n);return n==1?FX.FirstRig:FX.SecondRig;}}
        public ScreenHUD ScreenModeHUD {get {FX.Event("rig:hud");return HUD;}}
        public Camera ScreenModeCamera {get {FX.Event("rig:camera");return Camera;}}
    }
    public sealed class ScreenHUD {public ScreenWorldSpaceUIAnchor Value;public ScreenWorldSpaceUIAnchor WorldSpaceUIAnchor {get {FX.Event("hud:anchor");return Value;}}}
    public sealed class ScreenWorldSpaceUIAnchor
    {
        public GameObject Value;
        public GameObject AttachedGameObject {get {FX.Event("anchor:object");return Value;}}
        public void Detach(){FX.Event("anchor:detach");FX.DetachReceiver=this;}
        public void Attach(GameObject gameObject,Func<Vector2> callback,Quaternion rotation,float scale,float distance,bool flag)
        {FX.Event("anchor:attach");FX.AttachReceiver=this;FX.AttachObject=gameObject;FX.AttachCallback=callback;FX.AttachRotation=rotation;FX.AttachScale=scale;FX.AttachDistance=distance;FX.AttachFlag=flag;}
    }
}
namespace RecoveryDisplayControlledEffects
{
    sealed class CPBPJLLMKDB {public bool InScreenDisplayMode {get {State.Event("mode");return State.Screen;}}}
    sealed class TitleDisplaySubject
    {
        private CPBPJLLMKDB LIPCPJMCHDF;
        private RRUI.RoundedCorners backgroundRoundedCorners;
        private Canvas mainCanvas;
        private Vector3 AFFEJPNPKPM;
        private Vector3 AHAPJIODLLJ;
        private Quaternion BGMCKGNIMKN;
        public TitleDisplaySubject(){LIPCPJMCHDF=new CPBPJLLMKDB();backgroundRoundedCorners=State.Background;mainCanvas=State.Canvas;AFFEJPNPKPM=new Vector3(1,2,3);AHAPJIODLLJ=new Vector3(4,5,6);BGMCKGNIMKN=new Quaternion(7,8,9,10);}
        /*EXACT_DISPLAY_METHOD*/
        private Vector2 EKJBJGDALKG(){State.Event("size:callback");State.SizeReceiver=this;return new Vector2(71,72);}
        public void Run(){PMNJIOHDABB();}
        public void SetBackground(RRUI.RoundedCorners x){backgroundRoundedCorners=x;}
        public void SetCanvas(Canvas x){mainCanvas=x;}
        public void NullService(){LIPCPJMCHDF=null;}
        public void SetSavedPosition(Vector3 p){AFFEJPNPKPM=p;}
    }
    static class State
    {
        public static readonly List<string> Events=new List<string>();public static int FailAt,RigReads;public static bool Screen,Equality;
        public static RRUI.RoundedCorners Background;public static UnityEngine.Object ComparedBackground,EqualLeft,EqualRight;public static Behaviour EnabledReceiver;
        public static Canvas Canvas;public static Camera ScreenCamera,Controller,ClipReceiver;
        public static RecRoom.Core.CameraRig FirstRig,SecondRig;public static RecRoom.Core.ScreenHUD HUD;public static RecRoom.Core.ScreenWorldSpaceUIAnchor Anchor,DetachReceiver,AttachReceiver;
        public static GameObject AttachObject;public static Func<Vector2> AttachCallback;public static Quaternion AttachRotation;public static float AttachScale,AttachDistance;public static bool AttachFlag;public static Vector3 DistanceLeft,DistanceRight;public static TitleDisplaySubject Subject;public static object SizeReceiver;
        public static Action OnBackgroundTest,OnCanvasTransform,OnPositionSet,OnScreenPosition;
        public static void Event(string name){Events.Add(name);if(FailAt==Events.Count)throw new ApplicationException("controlled-"+name);}
        public static void Reset(bool screen)
        {
            Events.Clear();FailAt=RigReads=0;Screen=screen;Equality=true;Background=new RRUI.RoundedCorners();ComparedBackground=EqualLeft=EqualRight=null;EnabledReceiver=null;Canvas=new Canvas{Value=new GameObject(),Pose=new Transform{Name="pose",Position=new Vector3(10,20,30)}};ScreenCamera=new Camera{Name="screen",Pose=new Transform{Name="screen",Position=new Vector3(2,3,6),Rotation=new Quaternion(11,12,13,14)}};Controller=new Camera{Name="controller"};ClipReceiver=null;Anchor=new RecRoom.Core.ScreenWorldSpaceUIAnchor{Value=Canvas.Value};HUD=new RecRoom.Core.ScreenHUD{Value=Anchor};FirstRig=new RecRoom.Core.CameraRig{HUD=HUD};SecondRig=new RecRoom.Core.CameraRig{Camera=ScreenCamera};RecRoom.Core.UI.UIInputModule.Instance=new RecRoom.Core.UI.UIInputModule{Value=Controller};DetachReceiver=AttachReceiver=null;AttachObject=null;AttachCallback=null;AttachRotation=default(Quaternion);AttachScale=AttachDistance=-1;AttachFlag=true;DistanceLeft=DistanceRight=default(Vector3);SizeReceiver=null;OnBackgroundTest=OnCanvasTransform=OnPositionSet=OnScreenPosition=null;Subject=new TitleDisplaySubject();
        }
    }
    static class Program
    {
        static int cases;
        static readonly string[] VR={"mode","background:test","background:enabled","rig:1","rig:hud","hud:anchor","anchor:object","canvas:object","attached:equal","anchor:detach","canvas:transform","pose:position:set","canvas:transform","pose:scale:set","canvas:transform","pose:rotation:set","ui:camera","clip:set"};
        static readonly string[] Screen={"mode","background:test","background:enabled","rig:1","rig:hud","hud:anchor","rig:2","rig:camera","canvas:object","screen:transform","screen:rotation:get","anchor:attach","ui:camera","canvas:transform","pose:position:get","screen:transform","screen:position:get","distance","clip:set"};
        static bool Same(object a,object b){return System.Object.ReferenceEquals(a,b);}
        static void Need(bool b,string message){if(!b)throw new Exception(message);}
        static void Events(IEnumerable<string> expected){Need(State.Events.SequenceEqual(expected),"effect order: "+String.Join(",",State.Events));}
        static bool Throws<T>() where T:Exception {try{State.Subject.Run();return false;}catch(T){return true;}}
        static void Done(){cases++;}
        static void Effects()
        {
            State.Reset(false);State.Subject.Run();Events(VR);Need(State.Background.SeenEnabled&&Same(State.ComparedBackground,State.Background)&&Same(State.EqualLeft,State.Anchor.Value)&&Same(State.EqualRight,State.Canvas.Value)&&Same(State.DetachReceiver,State.Anchor)&&State.Canvas.Pose.Position.x==1&&State.Canvas.Pose.Position.y==2&&State.Canvas.Pose.Position.z==3&&State.Canvas.Pose.Scale.x==4&&State.Canvas.Pose.Rotation.w==10&&Same(State.ClipReceiver,State.Controller)&&State.Controller.Clip==20,"VR exact fake-null test, detach, saved values and camera20");Done();
            State.Reset(true);State.Subject.Run();Events(Screen);Need(!State.Background.SeenEnabled&&Same(State.AttachReceiver,State.Anchor)&&Same(State.AttachObject,State.Canvas.Value)&&Same(State.AttachCallback.Target,State.Subject)&&State.AttachCallback.Method.Name=="EKJBJGDALKG"&&State.AttachRotation.x==11&&State.AttachRotation.w==14&&State.AttachScale==1&&State.AttachDistance==0&&!State.AttachFlag&&State.RigReads==2&&Same(State.ClipReceiver,State.Controller)&&Math.Abs(State.Controller.Clip-2*(float)Math.Sqrt(8*8+17*17+24*24))<0.001,"screen exact attach tuple/delegate/different singleton results and distance2");Done();
            foreach(bool screen in new[]{false,true})
            {
                var expected=screen?Screen:VR;
                for(int n=0;n<expected.Length;n++)
                {State.Reset(screen);State.FailAt=n+1;Need(Throws<ApplicationException>(),"each original failure boundary");Events(expected.Take(n+1));Need(State.Controller.Clip==0,"failed calls cannot apply later clip");Done();}
            }
            State.Reset(false);State.Subject.SetBackground(null);State.Subject.Run();Need(Same(State.ComparedBackground,null)&&Same(State.EnabledReceiver,null),"null background skipped using actual comparison result");Events(VR.Where(x=>x!="background:enabled"));Done();
            State.Reset(false);State.Background.Alive=false;State.Subject.Run();Need(Same(State.ComparedBackground,State.Background)&&Same(State.EnabledReceiver,null),"non-null fake-dead background skipped");Events(VR.Where(x=>x!="background:enabled"));Done();
            State.Reset(false);State.Equality=false;State.Subject.Run();Need(State.DetachReceiver==null,"detach skipped on original equality false");Events(VR.Where(x=>x!="anchor:detach"));Done();
            State.Reset(false);State.Subject.NullService();Need(Throws<NullReferenceException>(),"null mode service before all effects");Events(new string[0]);Done();
            State.Reset(false);State.FirstRig=null;Need(Throws<NullReferenceException>(),"null first singleton");Events(VR.Take(4));Done();
            State.Reset(false);State.FirstRig.HUD=null;Need(Throws<NullReferenceException>(),"null HUD");Events(VR.Take(5));Done();
            State.Reset(false);State.HUD.Value=null;Need(Throws<NullReferenceException>(),"null anchor VR before gameObject getter");Events(VR.Take(6));Done();
            State.Reset(true);State.HUD.Value=null;Need(Throws<NullReferenceException>(),"null anchor screen after attach arguments");Events(Screen.Take(11));Done();
            State.Reset(true);State.SecondRig=null;Need(Throws<NullReferenceException>(),"second independent singleton null");Events(Screen.Take(7));Done();
            State.Reset(true);RecRoom.Core.UI.UIInputModule.Instance.Value=null;Need(Throws<NullReferenceException>(),"null controller screen fails after full RHS distance");Events(Screen.Take(18));Done();
            State.Reset(true);var originalCamera=State.Controller;State.OnCanvasTransform=()=>RecRoom.Core.UI.UIInputModule.Instance.Value=new Camera();State.OnScreenPosition=()=>State.Canvas.Pose.Position=new Vector3(900,901,902);State.Subject.Run();Need(Same(State.ClipReceiver,originalCamera)&&State.DistanceLeft.x==10&&State.DistanceLeft.y==20&&State.DistanceRight.x==2,"UI receiver and left position value captured before following side effects");Events(Screen);Done();
            State.Reset(false);State.Subject.SetCanvas(null);Need(Throws<NullReferenceException>(),"null main VR after anchor getter");Events(VR.Take(7));Done();
            State.Reset(true);State.Subject.SetCanvas(null);Need(Throws<NullReferenceException>(),"null main screen after second camera getter");Events(Screen.Take(8));Done();
            State.Reset(true);State.SecondRig.Camera=null;Need(Throws<NullReferenceException>(),"null screen camera after canvas object/delegate evaluation");Events(Screen.Take(9));Done();
            State.Reset(false);RecRoom.Core.UI.UIInputModule.Instance=null;Need(Throws<NullReferenceException>(),"null UI instance VR after pose restores");Events(VR.Take(16));Done();
            State.Reset(false);RecRoom.Core.UI.UIInputModule.Instance.Value=null;Need(Throws<NullReferenceException>(),"null UI camera VR after getter");Events(VR.Take(17));Done();
            State.Reset(false);var replacement=new Canvas{Pose=new Transform{Name="next"}};State.OnCanvasTransform=()=>State.Subject.SetSavedPosition(new Vector3(101,102,103));State.OnPositionSet=()=>State.Subject.SetCanvas(replacement);State.Subject.Run();Need(State.Canvas.Pose.Position.x==101&&replacement.Pose.Scale.x==4&&replacement.Pose.Rotation.w==10,"saved argument after receiver getter and next mainCanvas rereads");Events(VR.Take(10).Concat(new[]{"canvas:transform","pose:position:set","canvas:transform","next:scale:set","canvas:transform","next:rotation:set","ui:camera","clip:set"}));Done();
            State.Reset(true);State.Subject.Run();State.Events.Clear();var size=State.AttachCallback();Need(Same(State.SizeReceiver,State.Subject)&&size.x==71&&size.y==72,"same original Func target and return value forwarded");Events(new[]{"size:callback"});Done();
            Need(cases==57,"finite57 case count");Console.WriteLine("{\"status\":\"fiftyseven_exact_display_callback_controlled_effect_cases_passed\",\"cases\":57,\"production_callees_or_Unity_executed\":false}");
        }
        static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
        static void Call(MethodReference m,string owner,string name,string ret,params string[] args){Need(m.DeclaringType.FullName==owner&&m.Name==name&&m.ReturnType.FullName==ret&&m.Parameters.Select(x=>x.ParameterType.FullName).SequenceEqual(args),"typed actual call "+owner+"."+name);}
        static void Inspect(string path)
        {
            using(var module=ModuleDefinition.ReadModule(path,new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false}))
            {
                var owner=Types(module.Types).Single(x=>x.FullName=="TitleScreenManager");var method=owner.Methods.Single(x=>x.Name=="PMNJIOHDABB"&&x.Parameters.Count==0);Need(method.IsPrivate&&!method.IsStatic&&method.ReturnType.FullName=="System.Void","exact private original callback signature");var il=method.Body.Instructions.ToArray();var sites=il.Where(x=>x.OpCode.Code==Code.Call||x.OpCode.Code==Code.Callvirt||x.OpCode.Code==Code.Newobj).ToArray();var calls=sites.Select(x=>(MethodReference)x.Operand).ToArray();Need(calls.Length==32,"exact32 managed calls including original inlined leaf contracts");
                Call(calls[0],"CPBPJLLMKDB","get_InScreenDisplayMode","System.Boolean");Call(calls[1],"UnityEngine.Object","op_Inequality","System.Boolean","UnityEngine.Object","UnityEngine.Object");Call(calls[2],"UnityEngine.Behaviour","set_enabled","System.Void","System.Boolean");foreach(int n in new[]{3,18})Need(calls[n].DeclaringType.FullName=="SingletonMonoBehaviour`1<RecRoom.Core.CameraRig>"&&calls[n].Name=="get_Instance"&&calls[n].Parameters.Count==0,"exact original independent rig singleton getter");Call(calls[4],"RecRoom.Core.CameraRig","get_ScreenModeHUD","RecRoom.Core.ScreenHUD");Call(calls[5],"RecRoom.Core.ScreenHUD","get_WorldSpaceUIAnchor","RecRoom.Core.ScreenWorldSpaceUIAnchor");Call(calls[6],"RecRoom.Core.ScreenWorldSpaceUIAnchor","get_AttachedGameObject","UnityEngine.GameObject");foreach(int n in new[]{7,20})Call(calls[n],"UnityEngine.Component","get_gameObject","UnityEngine.GameObject");Call(calls[8],"UnityEngine.Object","op_Equality","System.Boolean","UnityEngine.Object","UnityEngine.Object");Call(calls[9],"RecRoom.Core.ScreenWorldSpaceUIAnchor","Detach","System.Void");foreach(int n in new[]{10,12,14,22,26,28})Call(calls[n],"UnityEngine.Component","get_transform","UnityEngine.Transform");Call(calls[11],"UnityEngine.Transform","set_position","System.Void","UnityEngine.Vector3");Call(calls[13],"UnityEngine.Transform","set_localScale","System.Void","UnityEngine.Vector3");Call(calls[15],"UnityEngine.Transform","set_rotation","System.Void","UnityEngine.Quaternion");foreach(int n in new[]{16,25})Call(calls[n],"RecRoom.Core.UI.UIInputModule","get_ControllerCamera","UnityEngine.Camera");foreach(int n in new[]{17,31})Call(calls[n],"UnityEngine.Camera","set_farClipPlane","System.Void","System.Single");Call(calls[19],"RecRoom.Core.CameraRig","get_ScreenModeCamera","UnityEngine.Camera");Call(calls[21],"System.Func`1<UnityEngine.Vector2>",".ctor","System.Void","System.Object","System.IntPtr");Call(calls[23],"UnityEngine.Transform","get_rotation","UnityEngine.Quaternion");Call(calls[24],"RecRoom.Core.ScreenWorldSpaceUIAnchor","Attach","System.Void","UnityEngine.GameObject","System.Func`1<UnityEngine.Vector2>","UnityEngine.Quaternion","System.Single","System.Single","System.Boolean");foreach(int n in new[]{27,29})Call(calls[n],"UnityEngine.Transform","get_position","UnityEngine.Vector3");Call(calls[30],"UnityEngine.Vector3","Distance","System.Single","UnityEngine.Vector3","UnityEngine.Vector3");
                Need(sites[17].Previous.OpCode.Code==Code.Ldc_R4&&(float)sites[17].Previous.Operand==20f,"exact VR20f");Need(sites[24].Previous.OpCode.Code==Code.Ldc_I4_0&&sites[24].Previous.Previous.OpCode.Code==Code.Ldc_R4&&(float)sites[24].Previous.Previous.Operand==0f&&sites[24].Previous.Previous.Previous.OpCode.Code==Code.Ldc_R4&&(float)sites[24].Previous.Previous.Previous.Operand==1f,"exact attach1f,0f,false");Need(sites[31].Previous.OpCode.Code==Code.Mul&&sites[31].Previous.Previous.OpCode.Code==Code.Ldc_R4&&(float)sites[31].Previous.Previous.Operand==2f,"exact original distance times2f");var callback=il.Where(x=>x.OpCode.Code==Code.Ldftn).Select(x=>(MethodReference)x.Operand).Single();Call(callback,"TitleScreenManager","EKJBJGDALKG","UnityEngine.Vector2");
                var fields=il.Where(x=>x.Operand is FieldReference).Select(x=>(FieldReference)x.Operand).ToArray();Need(fields.Length==14&&!il.Any(x=>x.OpCode.Code==Code.Stfld||x.OpCode.Code==Code.Stsfld),"exact14 field reads, no invented caller state writes");foreach(var pair in new[]{Tuple.Create("mainCanvas",6),Tuple.Create("backgroundRoundedCorners",2),Tuple.Create("LIPCPJMCHDF",1),Tuple.Create("AFFEJPNPKPM",1),Tuple.Create("AHAPJIODLLJ",1),Tuple.Create("BGMCKGNIMKN",1)})Need(fields.Count(x=>x.DeclaringType.FullName=="TitleScreenManager"&&x.Name==pair.Item1)==pair.Item2,"exact field reevaluation "+pair.Item1);Need(fields.Count(x=>x.DeclaringType.FullName=="RecRoom.Core.UI.UIInputModule"&&x.Name=="Instance")==2,"both independent UI singleton fields");Console.WriteLine("{\"status\":\"actual_full_display_callback_typed_binding_verified_metadata_only\",\"game_code_invoked\":false}");
            }
        }
        static int Main(string[] args){try{if(args.Length==0)Effects();else if(args.Length==2&&args[0]=="--inspect")Inspect(args[1]);else throw new Exception("invalid controlled harness arguments");return 0;}catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}}
    }
}
