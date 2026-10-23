// Explicit test-only effect contexts. No Unity/game/backend callee executes.
using System;
using System.Linq;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
namespace TitleSmallCallbacksControlled
{
    enum ScreenOrientation { AutoRotation=5 }
    static class Effects
    {
        internal static readonly List<string> Calls=new List<string>();internal static string ThrowAt;
        internal static void Call(string value){Calls.Add(value);if(value==ThrowAt)throw new ApplicationException(value);}
        internal static void Reset(){Calls.Clear();ThrowAt=null;}
    }
    static class Screen
    {
        public static bool autorotateToLandscapeLeft {set{Effects.Call("left:"+value);}}
        public static bool autorotateToLandscapeRight {set{Effects.Call("right:"+value);}}
        public static bool autorotateToPortrait {set{Effects.Call("portrait:"+value);}}
        public static bool autorotateToPortraitUpsideDown {set{Effects.Call("upside:"+value);}}
        public static ScreenOrientation orientation {set{Effects.Call("orientation:"+(int)value);}}
    }
    struct Vector2 {public float x,y;}
    struct Vector3 {public float x,y,z;}
    class Transform
    {
        public static bool operator ==(Transform a,Transform b){throw new InvalidOperationException("unproved Unity fake-null operator used");}
        public static bool operator !=(Transform a,Transform b){throw new InvalidOperationException("unproved Unity fake-null operator used");}
        public override bool Equals(object other){return ReferenceEquals(this,other);}public override int GetHashCode(){return base.GetHashCode();}
    }
    sealed class RectTransform:Transform
    {
        internal Vector2 Size;internal Vector3 Scale;internal Action OnSize,OnScale;internal bool Destroyed;
        public Vector2 sizeDelta {get{Effects.Call("size");OnSize?.Invoke();return Size;}}
        public Vector3 lossyScale {get{Effects.Call("scale");OnScale?.Invoke();return Scale;}}
    }
    sealed class Canvas
    {
        internal Transform Value;internal Action OnTransform;internal bool Destroyed;
        public Transform transform {get{Effects.Call("transform");OnTransform?.Invoke();return Value;}}
        public static bool operator ==(Canvas a,Canvas b){throw new InvalidOperationException("unproved Unity fake-null canvas operator used");}
        public static bool operator !=(Canvas a,Canvas b){throw new InvalidOperationException("unproved Unity fake-null canvas operator used");}
        public override bool Equals(object other){return ReferenceEquals(this,other);}public override int GetHashCode(){return base.GetHashCode();}
    }
    sealed class Subject
    {
        internal Canvas mainCanvas;
        /*EXACT_ORIGINAL_SMALL_CALLBACKS*/
        internal void Visible(bool value){NBDKIBMNLCA(value);}
        internal Vector2 Size(){return EKJBJGDALKG();}
    }
    static class Program
    {
        static int cases;
        static void Need(bool value,string message){if(!value)throw new InvalidOperationException(message);}
        static void Case(string name,Action body){Effects.Reset();body();cases++;Console.WriteLine("PASS "+name);}
        static bool Throws<T>(Action action,string message=null) where T:Exception {try{action();return false;}catch(Exception e){return e.GetType()==typeof(T)&&(message==null||e.Message==message);}}
        static void Order(params string[] values){Need(Effects.Calls.SequenceEqual(values),"exact ordered effects: "+String.Join(",",Effects.Calls));}
        static Subject New(out RectTransform rect){rect=new RectTransform{Size=new Vector2{x=2,y=3},Scale=new Vector3{x=4,y=5,z=99}};return new Subject{mainCanvas=new Canvas{Value=rect}};}
        static void Value(Vector2 v,float x,float y){Need(BitConverter.ToInt32(BitConverter.GetBytes(v.x),0)==BitConverter.ToInt32(BitConverter.GetBytes(x),0)&&BitConverter.ToInt32(BitConverter.GetBytes(v.y),0)==BitConverter.ToInt32(BitConverter.GetBytes(y),0),"exact returned component bits");}
        static void Run()
        {
            var expected=new[]{"left:True","right:True","portrait:False","upside:False","orientation:5"};
            Case("visibility true performs exact original five setters",()=>{new Subject().Visible(true);Order(expected);});
            Case("visibility false performs same setters and ignores bool",()=>{new Subject().Visible(false);Order(expected);});
            foreach(var value in expected)
            {
                string stop=value;
                Case("setter failure propagates and suppresses following effects "+stop,()=>{Effects.ThrowAt=stop;Need(Throws<ApplicationException>(()=>new Subject().Visible(false),stop),"exact setter exception");Order(expected.Take(Array.IndexOf(expected,stop)+1).ToArray());});
            }
            Case("size reads transform then size then scale and returns products",()=>{RectTransform rect;var s=New(out rect);Value(s.Size(),8,15);Order("transform","size","scale");});
            Case("raw null canvas throws before transform property",()=>{Need(Throws<NullReferenceException>(()=>new Subject().Size()),"raw canvas null");Order();});
            Case("transform getter failure propagates before cast or size",()=>{RectTransform rect;var s=New(out rect);Effects.ThrowAt="transform";Need(Throws<ApplicationException>(()=>s.Size(),"transform"),"transform failure");Order("transform");});
            Case("raw null transform throws before size getter",()=>{var s=new Subject{mainCanvas=new Canvas{Value=null}};Need(Throws<NullReferenceException>(()=>s.Size()),"raw transform null");Order("transform");});
            Case("wrong exact transform class produces invalid cast",()=>{var s=new Subject{mainCanvas=new Canvas{Value=new Transform()}};Need(Throws<InvalidCastException>(()=>s.Size()),"sealed cast boundary");Order("transform");});
            Case("size getter failure suppresses scale read",()=>{RectTransform rect;var s=New(out rect);Effects.ThrowAt="size";Need(Throws<ApplicationException>(()=>s.Size(),"size"),"size failure");Order("transform","size");});
            Case("scale getter failure follows completed size read",()=>{RectTransform rect;var s=New(out rect);Effects.ThrowAt="scale";Need(Throws<ApplicationException>(()=>s.Size(),"scale"),"scale failure");Order("transform","size","scale");});
            Case("captured transform survives canvas field replacement in size",()=>{RectTransform rect;var s=New(out rect);rect.OnSize=()=>s.mainCanvas=null;Value(s.Size(),8,15);Order("transform","size","scale");});
            Case("size getter effect on scale is observed",()=>{RectTransform rect;var s=New(out rect);rect.OnSize=()=>rect.Scale=new Vector3{x=7,y=11,z=-1};Value(s.Size(),14,33);Order("transform","size","scale");});
            Case("copied size value survives mutation by scale getter",()=>{RectTransform rect;var s=New(out rect);rect.OnScale=()=>rect.Size=new Vector2{x=100,y=200};Value(s.Size(),8,15);Order("transform","size","scale");});
            Case("signed zero product bits retained",()=>{RectTransform rect;var s=New(out rect);float negativeZero=BitConverter.ToSingle(BitConverter.GetBytes(unchecked((int)0x80000000)),0);rect.Scale=new Vector3{x=negativeZero,y=2,z=0};rect.Size=new Vector2{x=3,y=negativeZero};Value(s.Size(),negativeZero,negativeZero);Order("transform","size","scale");});
            Case("infinity and NaN propagate without normalization",()=>{RectTransform rect;var s=New(out rect);rect.Scale=new Vector3{x=Single.PositiveInfinity,y=3,z=0};rect.Size=new Vector2{x=2,y=Single.NaN};var v=s.Size();Need(Single.IsPositiveInfinity(v.x)&&Single.IsNaN(v.y),"nonfinite components");Order("transform","size","scale");});
            Case("destroyed-style references do not invoke Unity equality",()=>{RectTransform rect;var s=New(out rect);rect.Destroyed=true;s.mainCanvas.Destroyed=true;Value(s.Size(),8,15);Order("transform","size","scale");});
            Case("successive calls read fresh receiver and struct values",()=>{RectTransform rect;var s=New(out rect);Value(s.Size(),8,15);s.mainCanvas=new Canvas{Value=new RectTransform{Size=new Vector2{x=7,y=9},Scale=new Vector3{x=2,y=3,z=0}}};Value(s.Size(),14,27);Order("transform","size","scale","transform","size","scale");});
            Need(cases==21,"exact twenty-one distinct effect cases");Console.WriteLine("RESULT twenty_one_original_small_callback_effects_passed; production_game_Unity_network_executed=false");
        }
        static string Sig(MethodReference m){return m.ReturnType.FullName+"("+String.Join(",",m.Parameters.Select(x=>x.ParameterType.FullName))+")";}
        static Instruction[] Calls(MethodDefinition m){return m.Body.Instructions.Where(i=>i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Callvirt||i.OpCode.Code==Code.Newobj).ToArray();}
        static void Inspect(string compiledPath,string originalPath)
        {
            var options=new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false};
            using(var compiled=ModuleDefinition.ReadModule(compiledPath,options))using(var original=ModuleDefinition.ReadModule(originalPath,options))
            {
                Need(compiled.Assembly.Name.Name=="Assembly-CSharp"&&original.Assembly.Name.Name=="Assembly-CSharp","actual full Core and original attribute-provider metadata only");
                var owner=compiled.Types.Single(t=>t.FullName=="TitleScreenManager");var raw=original.Types.Single(t=>t.MetadataToken.ToUInt32()==0x02000145&&t.FullName=="TitleScreenManager");
                foreach(var row in new[]{Tuple.Create("NBDKIBMNLCA",0x060008a1u),Tuple.Create("EKJBJGDALKG",0x060008b1u)})
                {
                    var a=raw.Methods.Single(x=>x.MetadataToken.ToUInt32()==row.Item2);var b=owner.Methods.Single(x=>x.Name==row.Item1);
                    Need(a.Name==b.Name&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&Sig(a)==Sig(b)&&!b.IsStatic&&b.IsPrivate&&b.HasBody&&!b.Body.ExceptionHandlers.Any(),"exact original callback owner/name/private/signature/flags");
                }
                var screen=owner.Methods.Single(m=>m.Name=="NBDKIBMNLCA");var setters=Calls(screen);var names=new[]{"set_autorotateToLandscapeLeft","set_autorotateToLandscapeRight","set_autorotateToPortrait","set_autorotateToPortraitUpsideDown","set_orientation"};var constants=new[]{Code.Ldc_I4_1,Code.Ldc_I4_1,Code.Ldc_I4_0,Code.Ldc_I4_0,Code.Ldc_I4_5};
                Need(setters.Length==5&&!screen.Body.Instructions.Any(i=>i.OpCode.Code.ToString().StartsWith("Ldarg",StringComparison.Ordinal)),"exact five calls with no receiver or bool parameter read");
                for(int i=0;i<5;i++){var m=(MethodReference)setters[i].Operand;Need(setters[i].OpCode.Code==Code.Call&&!m.HasThis&&m.DeclaringType.FullName=="UnityEngine.Screen"&&m.DeclaringType.Scope.ToString()=="UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"&&m.Name==names[i]&&Sig(m)=="System.Void("+(i==4?"UnityEngine.ScreenOrientation":"System.Boolean")+")"&&setters[i].Previous.OpCode.Code==constants[i],"exact ordered static Screen setter/argument");}
                var size=owner.Methods.Single(m=>m.Name=="EKJBJGDALKG");var calls=Calls(size);var callNames=new[]{"get_transform","get_sizeDelta","get_lossyScale"};var callOwners=new[]{"UnityEngine.Component","UnityEngine.RectTransform","UnityEngine.Transform"};var returns=new[]{"UnityEngine.Transform","UnityEngine.Vector2","UnityEngine.Vector3"};Need(calls.Length==3,"only three native-proven getters; no invented Vector2 constructor/operator");
                for(int i=0;i<3;i++){var m=(MethodReference)calls[i].Operand;Need(calls[i].OpCode.Code==Code.Callvirt&&m.HasThis&&m.Name==callNames[i]&&m.DeclaringType.FullName==callOwners[i]&&m.DeclaringType.Scope.ToString()=="UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"&&Sig(m)==returns[i]+"()","exact ordered getter signature and original engine scope");}
                var casts=size.Body.Instructions.Where(i=>i.OpCode.Code==Code.Castclass).ToArray();Need(casts.Length==1&&((TypeReference)casts[0].Operand).FullName=="UnityEngine.RectTransform","exact sealed RectTransform cast");
                var reads=size.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldfld).Select(i=>(FieldReference)i.Operand).ToArray();Need(reads.Select(f=>f.DeclaringType.FullName+"::"+f.Name).SequenceEqual(new[]{"TitleScreenManager::mainCanvas","UnityEngine.Vector3::x","UnityEngine.Vector2::x","UnityEngine.Vector3::y","UnityEngine.Vector2::y"})&&reads[0].FieldType.FullName=="UnityEngine.Canvas"&&reads.Skip(1).All(f=>f.FieldType.FullName=="System.Single"),"once-captured mainCanvas and exact copied vector component read order");
                var writes=size.Body.Instructions.Where(i=>i.OpCode.Code==Code.Stfld).Select(i=>(FieldReference)i.Operand).ToArray();Need(writes.Select(f=>f.DeclaringType.FullName+"::"+f.Name).SequenceEqual(new[]{"UnityEngine.Vector2::x","UnityEngine.Vector2::y"})&&writes.All(f=>f.FieldType.FullName=="System.Single"),"only two local returned-struct component stores");
                Need(size.Body.Instructions.Count(i=>i.OpCode.Code==Code.Mul)==2&&size.Body.Instructions.Count(i=>i.OpCode.Code==Code.Initobj&&((TypeReference)i.Operand).FullName=="UnityEngine.Vector2")==1&&!size.Body.Instructions.Any(i=>i.OpCode.Code==Code.Stsfld||i.OpCode.Code==Code.Starg||i.OpCode.Code==Code.Calli),"two exact scalar products and local value construction with no external state write");
                Console.WriteLine("RESULT actual_full_original_two_small_callback_bindings_passed; metadata_only_no_game_execution=true");
            }
        }
        public static int Main(string[] args){try{if(args.Length==3&&args[0]=="--inspect")Inspect(args[1],args[2]);else{Need(args.Length==0,"exact effect arguments");Run();}return 0;}catch(Exception e){Console.Error.WriteLine(e);return 1;}}
    }
}
