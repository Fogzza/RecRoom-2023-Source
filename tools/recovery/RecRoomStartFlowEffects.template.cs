// Test-only boundary doubles. Production validation separately compiles all
// original sources against genuine project references and reads their CIL.
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.AddressableAssets;
using FX = StartFlowEffects.State;
namespace UnityEngine
{
    public class Transform {}
    public class Component
    {
        public Transform Parent;
        public Transform transform {get {FX.Event("transform");if(FX.OnTransform!=null)FX.OnTransform();return Parent;}}
    }
    public class GameObject
    {
        public bool Active; public int Calls;
        public void SetActive(bool value) {FX.Event("activate");Active=value;Calls++;if(FX.OnActivate!=null)FX.OnActivate();}
    }
}
namespace UnityEngine.ResourceManagement.AsyncOperations
{
    public struct AsyncOperationHandle<T>
    {
        public T Value; public int Identity;
        public T WaitForCompletion() {FX.Event("wait");FX.SeenHandle=Identity;return Value;}
    }
}
namespace UnityEngine.AddressableAssets
{
    public class AssetReference {}
    public static class Addressables
    {
        public static UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> InstantiateAsync(object key,Transform parent,bool world,bool track)
        {
            FX.Event("instantiate");FX.SeenKey=key;FX.SeenParent=parent;FX.SeenWorld=world;FX.SeenTrack=track;
            return new UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject>{Value=FX.Result,Identity=++FX.NextHandle};
        }
    }
}
namespace StartFlowEffects
{
    class Subject:Component
    {
        private AssetReference startupObjectReference;
        public Subject(AssetReference key) {startupObjectReference=key;}
        /*EXACT_START*/
        protected virtual void HPCJAAEDLCH() {State.Event("hook");State.HookReceiver=this;}
        public void Run(){Start();}
        public void ReplaceKey(AssetReference value){startupObjectReference=value;}
    }
    sealed class Derived:Subject
    {
        public Derived(AssetReference key):base(key){}
        protected override void HPCJAAEDLCH(){State.Event("derived-hook");State.HookReceiver=this;}
    }
    static class State
    {
        public static readonly List<string> Events=new List<string>();
        public static readonly Exception Failure=new ApplicationException("controlled boundary failure");
        public static string Fail;
        public static Action OnTransform,OnActivate;
        public static AssetReference Key;
        public static Transform Parent,SeenParent;
        public static GameObject Result;
        public static object SeenKey,HookReceiver;
        public static bool SeenWorld,SeenTrack;
        public static int NextHandle,SeenHandle;
        public static Subject Current;
        public static void Event(string value){Events.Add(value);if(Fail==value)throw Failure;}
        public static void Reset()
        {
            Events.Clear();Fail=null;OnTransform=OnActivate=null;Key=new AssetReference();Parent=new Transform();Result=new GameObject();SeenParent=null;SeenKey=HookReceiver=null;SeenWorld=true;SeenTrack=false;NextHandle=SeenHandle=0;Current=new Subject(Key){Parent=Parent};
        }
    }
    static class Program
    {
        static int cases;
        static readonly string[] Normal={"transform","instantiate","wait","activate","hook"};
        static void Need(bool value,string text){if(!value)throw new Exception(text);}
        static bool Same(object a,object b){return Object.ReferenceEquals(a,b);}
        static void Events(IEnumerable<string> expected){Need(State.Events.SequenceEqual(expected),"Exact effects/order: "+String.Join(",",State.Events));}
        static void Done(){cases++;}
        static void Effects()
        {
            State.Reset();var subject=State.Current;subject.Run();Events(Normal);Need(Same(State.SeenKey,State.Key)&&Same(State.SeenParent,State.Parent)&&!State.SeenWorld&&State.SeenTrack&&State.SeenHandle==1&&State.Result.Active&&State.Result.Calls==1&&Same(State.HookReceiver,subject),"Original key/parent/flags/handle/activation/hook receiver");Done();
            for(int i=0;i<Normal.Length;i++)
            {
                State.Reset();State.Fail=Normal[i];Exception caught=null;
                try{State.Current.Run();}catch(Exception error){caught=error;}
                Need(Same(caught,State.Failure),"Original exception instance propagates unchanged");Events(Normal.Take(i+1));Need(State.Result.Calls==(i==4?1:0),"No activation after earlier failure");Done();
            }
            State.Reset();State.Current.ReplaceKey(null);State.Current.Run();Events(Normal);Need(State.SeenKey==null,"Null key is forwarded without extra assertion");Done();
            State.Reset();State.Current.Parent=null;State.Current.Run();Events(Normal);Need(State.SeenParent==null,"Null parent is forwarded");Done();
            State.Reset();State.Result=null;bool nullThrown=false;try{State.Current.Run();}catch(NullReferenceException){nullThrown=true;}Need(nullThrown,"Raw null GameObject fails at instance invocation");Events(Normal.Take(3));Need(State.HookReceiver==null,"No hook after null result");Done();
            State.Reset();var firstKey=State.Key;State.OnTransform=()=>State.Current.ReplaceKey(new AssetReference());State.Current.Run();Need(Same(State.SeenKey,firstKey),"Key captured before transform getter");Events(Normal);Done();
            State.Reset();var derived=new Derived(State.Key){Parent=State.Parent};derived.Run();Events(new[]{"transform","instantiate","wait","activate","derived-hook"});Need(Same(State.HookReceiver,derived),"Genuine same-receiver virtual hook dispatch");Done();
            State.Reset();State.Current.Run();State.Current.Run();Events(Normal.Concat(Normal));Need(State.NextHandle==2&&State.SeenHandle==2&&State.Result.Calls==2,"No invented startup cache or guard");Done();
            State.Reset();var original=State.Current;State.OnActivate=()=>State.Current=new Subject(new AssetReference());original.Run();Events(Normal);Need(Same(State.HookReceiver,original),"Activation callback cannot replace original method receiver");Done();
            Need(cases==13,"Exactly13 controlled native-sequence cases");Console.WriteLine("thirteen controlled original Start cases passed");
        }
        static string Key(TypeReference type)
        {
            if(type is GenericInstanceType g)return Key(g.ElementType)+"<"+String.Join(",",g.GenericArguments.Select(Key))+">";
            return type.FullName;
        }
        static string Sig(MethodReference method){return Key(method.DeclaringType)+"::"+method.Name+"("+String.Join(",",method.Parameters.Select(p=>Key(p.ParameterType)))+")";}
        static string Scope(TypeReference type){while(type is TypeSpecification s)type=s.ElementType;return type.Scope.Name;}
        static void Inspect(string path)
        {
            using(var assembly=AssemblyDefinition.ReadAssembly(path))
            {
                var type=assembly.MainModule.Types.Single(t=>t.FullName=="RecRoomGameRoot");
                var start=type.Methods.Single(m=>m.Name=="Start"&&m.Parameters.Count==0);
                Need(start.IsPrivate&&!start.IsStatic&&start.ReturnType.FullName=="System.Void"&&start.Body.ExceptionHandlers.Count==0,"Original private void Start; no invented catch/finally");
                var instructions=start.Body.Instructions;
                Need(instructions.Count(i=>i.OpCode.Code==Code.Ldfld)==1,"One original startup key capture");
                var field=(FieldReference)instructions.Single(i=>i.OpCode.Code==Code.Ldfld).Operand;
                Need(field.Name=="startupObjectReference"&&field.DeclaringType.FullName=="RecRoomGameRoot"&&field.FieldType.FullName=="UnityEngine.AddressableAssets.AssetReference"&&Scope(field.FieldType)=="Unity.Addressables","Exact original key field and genuine SDK owner");
                var callInstructions=instructions.Where(i=>i.Operand is MethodReference).ToArray();
                Need(callInstructions.Length==5,"Exactly original five calls");
                var calls=callInstructions.Select(i=>(MethodReference)i.Operand).ToArray();
                Need(Sig(calls[0])=="UnityEngine.Component::get_transform()"&&Scope(calls[0].DeclaringType)=="UnityEngine.CoreModule","Genuine Component transform getter");
                Need(Sig(calls[1])=="UnityEngine.AddressableAssets.Addressables::InstantiateAsync(System.Object,UnityEngine.Transform,System.Boolean,System.Boolean)"&&Scope(calls[1].DeclaringType)=="Unity.Addressables"&&!calls[1].HasThis,"Exact original Addressables overload, not AssetReference helper");
                Need(callInstructions[1].Previous.OpCode.Code==Code.Ldc_I4_1&&callInstructions[1].Previous.Previous.OpCode.Code==Code.Ldc_I4_0,"Exact world=false, track=true values and argument order");
                Need(Key(calls[1].ReturnType)=="UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle`1<UnityEngine.GameObject>"&&Scope(calls[1].ReturnType)=="Unity.ResourceManager","Original handle<GameObject> return type");
                Need(Sig(calls[2])=="UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle`1<UnityEngine.GameObject>::WaitForCompletion()"&&Scope(calls[2].DeclaringType)=="Unity.ResourceManager"&&calls[2].HasThis&&callInstructions[2].Previous.OpCode.Code==Code.Ldloca_S,"Exact same local handle address and genuine WaitForCompletion");
                Need(Sig(calls[3])=="UnityEngine.GameObject::SetActive(System.Boolean)"&&Scope(calls[3].DeclaringType)=="UnityEngine.CoreModule"&&callInstructions[3].OpCode.Code==Code.Callvirt&&callInstructions[3].Previous.OpCode.Code==Code.Ldc_I4_1,"Raw returned GameObject instance activation true");
                Need(Sig(calls[4])=="GameRoot::HPCJAAEDLCH()"&&callInstructions[4].OpCode.Code==Code.Callvirt&&callInstructions[4].Previous.OpCode.Code==Code.Ldarg_0,"Same receiver original virtual bootstrap hook");
                Need(instructions.IndexOf(instructions.Single(i=>i.OpCode.Code==Code.Ldfld))<instructions.IndexOf(callInstructions[0]),"Key load occurs before transform getter");
                Need(!instructions.Any(i=>i.Operand is MethodReference m&&(m.Name=="Dispose"||m.Name=="Release"||m.Name.StartsWith("op_"))),"No invented cleanup or Unity equality check");
                Console.WriteLine("actual full source Start binding metadata checks passed");
            }
        }
        static int Main(string[] args){try{if(args.Length==2&&args[0]=="--inspect")Inspect(args[1]);else if(args.Length==0)Effects();else throw new Exception("Exact mode required");return 0;}catch(Exception error){Console.Error.WriteLine(error);return 1;}}
    }
}
