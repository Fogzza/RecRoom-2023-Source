// Test-only effects, not SDK/game implementations. The exact candidate method
// is inserted unchanged into TitleAwakeSubject. Actual binding is a separate
// full5095-source compile and metadata-only inspection against genuine refs.
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using UnityEngine;
using FX=RecoveryTitleAwakeControlledEffects.State;
namespace UnityEngine
{
    public struct Vector3
    {
        public float x,y,z;
        public Vector3(float x,float y,float z){this.x=x;this.y=y;this.z=z;}
        public static Vector3 zero {get {FX.Event("position");var value=FX.Zero;if(FX.OnPosition!=null)FX.OnPosition();return value;}}
    }
    public struct Quaternion
    {
        public float x,y,z,w;
        public Quaternion(float x,float y,float z,float w){this.x=x;this.y=y;this.z=z;this.w=w;}
        public static Quaternion identity {get {FX.Event("rotation");if(FX.OnRotation!=null)FX.OnRotation();return FX.Identity;}}
    }
    public class Object
    {
        public static T Instantiate<T>(T prefab,Vector3 position,Quaternion rotation) where T:Object
        {FX.Event("instantiate");FX.SeenPrefab=prefab;FX.SeenPosition=position;FX.SeenRotation=rotation;return (T)(Object)FX.KeyboardResult;}
    }
}
namespace RecoveryTitleAwakeControlledEffects
{
    sealed class DCCDAPLPICN { }
    sealed class CPBPJLLMKDB { }
    sealed class AGVirtualKeyboard:UnityEngine.Object
    {public void ForceHideKeyboard(bool hide){State.Event("hide");State.HideTarget=this;State.HideValue=hide;}}
    sealed class LoadingScreen
    {
        public static LoadingScreen Instance {get {State.Event("loading");return State.Loading;}}
        public event Action<bool> IsVisibleChangeEvent
        {
            add {State.Event("subscribe");State.Listener=value;State.ListenerReceiver=this;if(State.InvokeOnSubscribe)value(true);}
            remove {throw new Exception("not part of Awake");}
        }
    }
    sealed class Container
    {
        readonly int index;
        public Container(int index){this.index=index;}
        public T HHCPOGCCGNF<T>(string name)
        {
            string kind=typeof(T)==typeof(DCCDAPLPICN)?"DCCD":typeof(T)==typeof(CPBPJLLMKDB)?"CPBP":throw new Exception("wrong generic service");
            State.Event("resolve:"+kind);if(name!=null || index!=(kind=="DCCD"?1:2))throw new Exception("resolve name/receiver changed");
            return (T)(object)(kind=="DCCD"?(object)State.FirstResult:State.SecondResult);
        }
    }
    static class MPAAIECKLGA
    {public static Container CFHDLGEGDFD {get {int n=++State.ServiceCalls;State.Event("service:"+n);if(n!=1 && n!=2)throw new Exception("extra getter");return n==1?State.FirstContainer:State.SecondContainer;}}}
    class BaseSubject {protected virtual void Awake(){State.Event("base");}}
    sealed class TitleAwakeSubject:BaseSubject
    {
        private AGVirtualKeyboard keyboardPrefab;
        private AGVirtualKeyboard KMNIAGFPHEN;
        private DCCDAPLPICN IBDKAJJPLGA;
        private CPBPJLLMKDB LIPCPJMCHDF;
        public TitleAwakeSubject(AGVirtualKeyboard prefab,AGVirtualKeyboard prior,DCCDAPLPICN a,CPBPJLLMKDB b){keyboardPrefab=prefab;KMNIAGFPHEN=prior;IBDKAJJPLGA=a;LIPCPJMCHDF=b;}
        /*EXACT_AWAKE_METHOD*/
        private void NBDKIBMNLCA(bool value){State.Events.Add("callback:"+value);State.CallbackReceiver=this;State.CallbackValue=value;}
        public void Run(){Awake();}
        public void SetPrefab(AGVirtualKeyboard value){keyboardPrefab=value;}
        public AGVirtualKeyboard Keyboard {get{return KMNIAGFPHEN;}}
        public DCCDAPLPICN First {get{return IBDKAJJPLGA;}}
        public CPBPJLLMKDB Second {get{return LIPCPJMCHDF;}}
    }
    static class State
    {
        public static readonly List<string> Events=new List<string>();
        public static string Fail;
        public static LoadingScreen Loading,ListenerReceiver;
        public static Container FirstContainer,SecondContainer;
        public static DCCDAPLPICN FirstResult,OldFirst;
        public static CPBPJLLMKDB SecondResult,OldSecond;
        public static AGVirtualKeyboard Prefab,PriorKeyboard,KeyboardResult,HideTarget;
        public static UnityEngine.Object SeenPrefab;
        public static Vector3 Zero,SeenPosition;
        public static Quaternion Identity,SeenRotation;
        public static int ServiceCalls;
        public static bool HideValue,InvokeOnSubscribe,CallbackValue;
        public static Action<bool> Listener;
        public static object CallbackReceiver;
        public static Action OnPosition,OnRotation;
        public static TitleAwakeSubject Subject;
        public static void Event(string name){Events.Add(name);if(Fail==name)throw new ApplicationException("controlled-"+name);}
        public static void Reset()
        {
            Events.Clear();Fail=null;Loading=new LoadingScreen();FirstContainer=new Container(1);SecondContainer=new Container(2);FirstResult=new DCCDAPLPICN();SecondResult=new CPBPJLLMKDB();OldFirst=new DCCDAPLPICN();OldSecond=new CPBPJLLMKDB();Prefab=new AGVirtualKeyboard();PriorKeyboard=new AGVirtualKeyboard();KeyboardResult=new AGVirtualKeyboard();HideTarget=null;SeenPrefab=null;Zero=new Vector3(0,0,0);Identity=new Quaternion(0,0,0,1);ServiceCalls=0;HideValue=false;InvokeOnSubscribe=false;Listener=null;ListenerReceiver=null;CallbackReceiver=null;CallbackValue=false;OnPosition=OnRotation=null;Subject=new TitleAwakeSubject(Prefab,PriorKeyboard,OldFirst,OldSecond);
        }
    }
    static class Program
    {
        static int cases;
        static readonly string[] Normal={"base","loading","subscribe","position","rotation","instantiate","hide","service:1","resolve:DCCD","service:2","resolve:CPBP"};
        static void Need(bool x,string message){if(!x)throw new Exception(message);}
        static bool Same(object a,object b){return System.Object.ReferenceEquals(a,b);}
        static void Events(IEnumerable<string> expected){Need(State.Events.SequenceEqual(expected),"effect order/count: "+String.Join(",",State.Events));}
        static void Done(){cases++;}
        static void Effects()
        {
            State.Reset();State.Subject.Run();Events(Normal);Need(Same(State.Subject.Keyboard,State.KeyboardResult)&&Same(State.HideTarget,State.KeyboardResult)&&State.HideValue&&Same(State.Subject.First,State.FirstResult)&&Same(State.Subject.Second,State.SecondResult)&&Same(State.SeenPrefab,State.Prefab)&&State.ServiceCalls==2,"same objects/true hide/two separate service getters");Need(State.SeenPosition.x==0&&State.SeenPosition.y==0&&State.SeenPosition.z==0&&State.SeenRotation.x==0&&State.SeenRotation.y==0&&State.SeenRotation.z==0&&State.SeenRotation.w==1,"exact default pose");Need(Same(State.Listener.Target,State.Subject)&&State.Listener.Method.Name=="NBDKIBMNLCA"&&Same(State.ListenerReceiver,State.Loading),"same delegate target/method/event receiver");Done();
            foreach(string fail in Normal)
            {
                State.Reset();State.Fail=fail;bool threw=false;try{State.Subject.Run();}catch(ApplicationException e){threw=e.Message=="controlled-"+fail;}Need(threw,"exact dependency exception");int n=Array.IndexOf(Normal,fail);Events(Normal.Take(n+1));Need(Same(State.Subject.Keyboard,n>=6?State.KeyboardResult:State.PriorKeyboard),"keyboard store boundary");Need(Same(State.Subject.First,n>=9?State.FirstResult:State.OldFirst)&&Same(State.Subject.Second,State.OldSecond),"service store failure boundary");Done();
            }
            State.Reset();State.Loading=null;bool nullFailure=false;try{State.Subject.Run();}catch(NullReferenceException){nullFailure=true;}Need(nullFailure&&Same(State.Subject.Keyboard,State.PriorKeyboard),"null loading before keyboard");Events(Normal.Take(2));Done();
            State.Reset();State.KeyboardResult=null;nullFailure=false;try{State.Subject.Run();}catch(NullReferenceException){nullFailure=true;}Need(nullFailure&&Same(State.Subject.Keyboard,null)&&Same(State.Subject.First,State.OldFirst),"null keyboard stored before failure");Events(Normal.Take(6));Done();
            State.Reset();State.FirstContainer=null;nullFailure=false;try{State.Subject.Run();}catch(NullReferenceException){nullFailure=true;}Need(nullFailure&&Same(State.Subject.First,State.OldFirst),"null first service before resolve/store");Events(Normal.Take(8));Done();
            State.Reset();State.SecondContainer=null;nullFailure=false;try{State.Subject.Run();}catch(NullReferenceException){nullFailure=true;}Need(nullFailure&&Same(State.Subject.First,State.FirstResult)&&Same(State.Subject.Second,State.OldSecond),"null second service retains first store");Events(Normal.Take(10));Done();
            State.Reset();State.FirstResult=null;State.Subject.Run();Need(Same(State.Subject.First,null)&&Same(State.Subject.Second,State.SecondResult),"null first resolution stored and second continues");Events(Normal);Done();
            State.Reset();State.SecondResult=null;State.Subject.Run();Need(Same(State.Subject.First,State.FirstResult)&&Same(State.Subject.Second,null),"null second resolution stored");Events(Normal);Done();
            State.Reset();State.Zero=new Vector3(11,12,13);State.Identity=new Quaternion(21,22,23,24);State.OnPosition=()=>State.Subject.SetPrefab(new AGVirtualKeyboard());State.OnRotation=()=>State.Zero=new Vector3(31,32,33);State.Subject.Run();Need(Same(State.SeenPrefab,State.Prefab)&&State.SeenPosition.x==11&&State.SeenPosition.y==12&&State.SeenPosition.z==13&&State.SeenRotation.x==21&&State.SeenRotation.y==22&&State.SeenRotation.z==23&&State.SeenRotation.w==24,"prefab read before getters, copied position before rotation");Events(Normal);Done();
            State.Reset();State.InvokeOnSubscribe=true;State.Subject.Run();Need(Same(State.CallbackReceiver,State.Subject)&&State.CallbackValue,"exact callback binding");Events(Normal.Take(3).Concat(new[]{"callback:True"}).Concat(Normal.Skip(3)));Done();
            Need(cases==20,"exact finite case count");Console.WriteLine("{\"status\":\"twenty_exact_Awake_controlled_effect_cases_passed\",\"cases\":20,\"production_callees_or_Unity_executed\":false,\"working_boot_claimed\":false}");
        }
        static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
        static void NeedCall(MethodReference m,string owner,string name,string ret,string[] args)
        {Need(m.DeclaringType.FullName==owner&&m.Name==name&&m.ReturnType.FullName==ret&&m.Parameters.Select(x=>x.ParameterType.FullName).SequenceEqual(args),"real typed call "+owner+"."+name);}
        static void Inspect(string path,string initialization)
        {
            string serviceGetter;
            using(var sdk=ModuleDefinition.ReadModule(initialization,new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false}))serviceGetter=Types(sdk.Types).Single(x=>x.FullName=="MPAAIECKLGA").Properties.Single(x=>x.Name=="CFHDLGEGDFD").GetMethod.Name;
            using(var m=ModuleDefinition.ReadModule(path,new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false}))
            {
                var owner=Types(m.Types).Single(x=>x.FullName=="TitleScreenManager");var method=owner.Methods.Single(x=>x.Name=="Awake"&&x.Parameters.Count==0);Need(method.IsFamily&&method.IsVirtual&&!method.IsNewSlot&&method.ReturnType.FullName=="System.Void","actual protected override Awake");
                var il=method.Body.Instructions.ToArray();var calls=il.Where(x=>x.OpCode.Code==Code.Call||x.OpCode.Code==Code.Callvirt||x.OpCode.Code==Code.Newobj).Select(x=>(MethodReference)x.Operand).ToArray();Need(calls.Length==12,"exact twelve managed application calls, runtime support is compiler-owned");
                NeedCall(calls[0],"SingletonMonoBehaviour`1<TitleScreenManager>","Awake","System.Void",new string[0]);Need(calls[1].DeclaringType.FullName=="SingletonMonoBehaviour`1<LoadingScreen>"&&calls[1].Name=="get_Instance"&&calls[1].Parameters.Count==0,"actual loading singleton getter");NeedCall(calls[2],"System.Action`1<System.Boolean>",".ctor","System.Void",new[]{"System.Object","System.IntPtr"});NeedCall(calls[3],"LoadingScreen","add_IsVisibleChangeEvent","System.Void",new[]{"System.Action`1<System.Boolean>"});NeedCall(calls[4],"UnityEngine.Vector3","get_zero","UnityEngine.Vector3",new string[0]);NeedCall(calls[5],"UnityEngine.Quaternion","get_identity","UnityEngine.Quaternion",new string[0]);
                var instantiate=calls[6] as GenericInstanceMethod;Need(instantiate!=null&&instantiate.DeclaringType.FullName=="UnityEngine.Object"&&instantiate.Name=="Instantiate"&&instantiate.GenericArguments.Single().FullName=="RecRoom.AGVirtualKeyboard"&&instantiate.Parameters.Count==3&&instantiate.Parameters[1].ParameterType.FullName=="UnityEngine.Vector3"&&instantiate.Parameters[2].ParameterType.FullName=="UnityEngine.Quaternion","exact generic Instantiate overload and pose types");NeedCall(calls[7],"RecRoom.AGVirtualKeyboard","ForceHideKeyboard","System.Void",new[]{"System.Boolean"});
                foreach(int n in new[]{8,10})NeedCall(calls[n],"MPAAIECKLGA",serviceGetter,"MNALHHOLFGL",new string[0]);
                foreach(int n in new[]{9,11}){var resolve=calls[n] as GenericInstanceMethod;Need(resolve!=null&&resolve.DeclaringType.FullName=="MNALHHOLFGL"&&resolve.Name=="HHCPOGCCGNF"&&resolve.GenericArguments.Single().FullName==(n==9?"DCCDAPLPICN":"CPBPJLLMKDB")&&resolve.Parameters.Single().ParameterType.FullName=="System.String","exact typed service resolution");var at=il.Single(x=>System.Object.ReferenceEquals(x.Operand,calls[n]));Need(at.Previous.OpCode.Code==Code.Ldnull,"null resolver name");}
                var callback=il.Where(x=>x.OpCode.Code==Code.Ldftn).Select(x=>(MethodReference)x.Operand).Single();NeedCall(callback,"TitleScreenManager","NBDKIBMNLCA","System.Void",new[]{"System.Boolean"});var hide=il.Single(x=>System.Object.ReferenceEquals(x.Operand,calls[7]));Need(hide.Previous.OpCode.Code==Code.Ldc_I4_1,"exact true hide argument");
                var fields=il.Where(x=>x.Operand is FieldReference).Select(x=>(FieldReference)x.Operand).ToArray();Need(fields.Length==5&&fields.All(x=>x.DeclaringType.FullName=="TitleScreenManager")&&fields.Count(x=>x.Name=="keyboardPrefab"&&x.FieldType.FullName=="RecRoom.AGVirtualKeyboard")==1&&fields.Count(x=>x.Name=="KMNIAGFPHEN"&&x.FieldType.FullName=="RecRoom.AGVirtualKeyboard")==2&&fields.Count(x=>x.Name=="IBDKAJJPLGA"&&x.FieldType.FullName=="DCCDAPLPICN")==1&&fields.Count(x=>x.Name=="LIPCPJMCHDF"&&x.FieldType.FullName=="CPBPJLLMKDB")==1,"exact original four field bindings, no extra state");
                Console.WriteLine("{\"status\":\"actual_full_Awake_file_typed_binding_verified_metadata_only\",\"members\":1,\"game_code_invoked\":false}");
            }
        }
        static int Main(string[] args){try{if(args.Length==0)Effects();else if(args.Length==3&&args[0]=="--inspect")Inspect(args[1],args[2]);else throw new Exception("invalid controlled harness arguments");return 0;}catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}}
    }
}
