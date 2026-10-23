// Explicit test-only Unity effects. Candidate member bytes are inserted unchanged.
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

static class Effects
{
    internal static readonly List<string> Events=new List<string>();
    internal static Action OnWarning;
    internal static bool ThrowDestroy,ThrowEquality;
    internal static UnityEngine.Object Destroyed;
    internal static void Reset() { Events.Clear();OnWarning=null;ThrowDestroy=false;ThrowEquality=false;Destroyed=null; }
}
namespace UnityEngine
{
    public class Object
    {
        public bool Alive=true;
        public static bool operator ==(Object a,Object b)
        {
            Effects.Events.Add("equality");if(Effects.ThrowEquality)throw new ApplicationException("equality");
            bool an=System.Object.ReferenceEquals(a,null),bn=System.Object.ReferenceEquals(b,null);
            if(an&&bn)return true;if(an)return !b.Alive;if(bn)return !a.Alive;return System.Object.ReferenceEquals(a,b);
        }
        public static bool operator !=(Object a,Object b) { Effects.Events.Add("inequality");return !(a==b); }
        public override bool Equals(object other) { throw new Exception("Equals must not replace Unity operator"); }
        public override int GetHashCode() { return 1; }
        public static void Destroy(Object value) { Effects.Events.Add("destroy");Effects.Destroyed=value;if(Effects.ThrowDestroy)throw new ApplicationException("destroy"); }
    }
    public class GameObject:Object { }
    public class Component:Object
    {
        public readonly GameObject Value=new GameObject();
        public bool ThrowGameObject;
        public GameObject gameObject { get { Effects.Events.Add("gameObject");if(ThrowGameObject)throw new ApplicationException("gameObject");return Value; } }
    }
    public class MonoBehaviour:Component { }
    public static class Debug
    {
        public static void LogWarning(object value) { Effects.Events.Add("warning:"+value);if(Effects.OnWarning!=null)Effects.OnWarning(); }
    }
}
public class SingletonMonoBehaviour<T>:UnityEngine.MonoBehaviour where T:SingletonMonoBehaviour<T>
{
    private static T CMDPMJBEBAB;
    /*EXACT_SINGLETON_MEMBERS*/
    // Test-only observation/entry points; excluded from production donor files.
    public static T Observe() { return CMDPMJBEBAB; }
    public static void Set(T value) { CMDPMJBEBAB=value; }
    public void TestAwake() { Awake(); }
    public void TestDestroy() { OnDestroy(); }
}
public static class MKECFLEMHEL
{
    /*EXACT_DISPOSED_MEMBER*/
}
sealed class First:SingletonMonoBehaviour<First> { }
sealed class InvalidSelf:SingletonMonoBehaviour<First> { }
static class StartupSingletonDisposedEffects
{
    static int cases;
    static void Need(bool value,string why) { if(!value)throw new Exception(why); }
    static bool Same(object a,object b) { return Object.ReferenceEquals(a,b); }
    static void Begin() { Effects.Reset();First.Set(null); }
    static void Done(string name) { cases++;Console.WriteLine("PASS "+name); }
    static void Events(params string[] expected) { Need(Effects.Events.SequenceEqual(expected),"exact controlled effects: "+String.Join(",",Effects.Events)); }
    static string Warning { get { return "warning:Created more than one singleton of "+typeof(First).ToString()+"! Destroying the old one."; } }
    static void RunEffects()
    {
        Begin();var fresh=new First();fresh.TestAwake();Need(Same(First.Observe(),fresh),"fresh stored");Events("inequality","equality");Done("fresh stores this");
        Begin();var old=new First();fresh=new First();First.Set(old);fresh.TestAwake();Need(Same(First.Observe(),fresh)&&Same(Effects.Destroyed,old.Value),"previous GameObject destroyed then this stored");Events("inequality","equality",Warning,"gameObject","destroy");Done("previous GameObject, exact warning/order");
        Begin();old=new First();var replacement=new First();fresh=new First();First.Set(old);Effects.OnWarning=()=>First.Set(replacement);fresh.TestAwake();Need(Same(Effects.Destroyed,replacement.Value)&&Same(First.Observe(),fresh),"field reread after warning");Done("warning side effect rereads actual stored instance");
        Begin();old=new First();fresh=new First();First.Set(old);Effects.OnWarning=()=>{throw new ApplicationException("warning");};bool threw=false;try{fresh.TestAwake();}catch(ApplicationException e){threw=e.Message=="warning";}Need(threw&&Same(First.Observe(),old)&&Same(Effects.Destroyed,null),"warning throws before destroy/store");Done("warning exception preserves old storage");
        Begin();old=new First{ThrowGameObject=true};fresh=new First();First.Set(old);threw=false;try{fresh.TestAwake();}catch(ApplicationException e){threw=e.Message=="gameObject";}Need(threw&&Same(First.Observe(),old)&&Same(Effects.Destroyed,null),"GameObject exception before store");Done("GameObject exception preserves storage");
        Begin();old=new First();fresh=new First();First.Set(old);Effects.ThrowDestroy=true;threw=false;try{fresh.TestAwake();}catch(ApplicationException e){threw=e.Message=="destroy";}Need(threw&&Same(First.Observe(),old),"destroy exception before new store");Done("destroy exception preserves storage");
        Begin();threw=false;try{new InvalidSelf().TestAwake();}catch(InvalidCastException){threw=true;}Need(threw&&Same(First.Observe(),null),"checked cast rejects invalid self");Done("checked cast failure does not store");
        Begin();old=new First{Alive=false};fresh=new First();First.Set(old);fresh.TestAwake();Need(Same(First.Observe(),fresh)&&Same(Effects.Destroyed,null),"Unity fake-null suppresses duplicate warning/destroy");Events("inequality","equality");Done("destroyed previous instance model");
        Begin();fresh=new First();First.Set(fresh);fresh.TestDestroy();Need(Same(First.Observe(),null),"current cleanup clears");Events("equality");Done("cleanup current instance");
        Begin();old=new First();fresh=new First();First.Set(old);fresh.TestDestroy();Need(Same(First.Observe(),old),"other cleanup preserves");Events("equality");Done("cleanup different instance");
        Begin();fresh=new First{Alive=false};First.Set(fresh);fresh.TestDestroy();Need(Same(First.Observe(),null),"same destroyed instance clears");Done("cleanup same destroyed instance model");
        Begin();old=new First();fresh=new First();First.Set(old);Effects.ThrowEquality=true;threw=false;try{fresh.TestDestroy();}catch(ApplicationException){threw=true;}Need(threw&&Same(First.Observe(),old),"equality exception preserves");Done("cleanup equality exception");
        Begin();fresh=new First();Effects.ThrowEquality=true;threw=false;try{fresh.TestAwake();}catch(ApplicationException){threw=true;}Need(threw&&Same(First.Observe(),null),"inequality exception preserves");Done("initial Unity comparison exception");
        MKECFLEMHEL.GFKAFPHLKMJ(false,"message");Done("false disposed guard returns");
        MKECFLEMHEL.GFKAFPHLKMJ(false,null);Done("false guard accepts null message");
        threw=false;try{MKECFLEMHEL.GFKAFPHLKMJ(true,"exact-original-payload");}catch(InvalidOperationException e){threw=e.Message=="exact-original-payload"&&e.InnerException==null;}Need(threw,"true guard exact exception/message");Done("true guard exception payload");
        threw=false;try{MKECFLEMHEL.GFKAFPHLKMJ(true,null);}catch(InvalidOperationException e){threw=e.InnerException==null;}Need(threw,"true null message retains standard framework ctor semantics");Done("true guard null message");
        Need(cases==17,"exact finite controlled case count");
        Console.WriteLine("RESULT seventeen_exact_member_controlled_effect_cases_passed; production_game_callees_executed=false; Unity_lifecycle_proved=false");
    }
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows) { foreach(var row in rows){yield return row;foreach(var child in Types(row.NestedTypes))yield return child;} }
    static string Key(TypeReference t)
    {
        if(t is GenericParameter g)return(g.Type==GenericParameterType.Method?"!!":"!")+g.Position;
        if(t is GenericInstanceType i)return i.ElementType.FullName+"<"+String.Join(",",i.GenericArguments.Select(Key))+">";
        return t.FullName;
    }
    static void Inspect(string originalSingleton,string donorSingleton,string originalGuard,string donorGuard)
    {
        using(var a=ModuleDefinition.ReadModule(originalSingleton))using(var b=ModuleDefinition.ReadModule(donorSingleton))
        using(var c=ModuleDefinition.ReadModule(originalGuard))using(var d=ModuleDefinition.ReadModule(donorGuard))
        {
            var original=Types(a.Types).Single(t=>t.FullName=="SingletonMonoBehaviour`1");var donor=Types(b.Types).Single(t=>t.FullName==original.FullName);
            Need(Key(original.BaseType)==Key(donor.BaseType)&&original.GenericParameters.Count==1&&donor.GenericParameters.Count==1,"real original owner and arity");
            Need(original.GenericParameters[0].Constraints.Select(x=>Key(x.ConstraintType)).SequenceEqual(donor.GenericParameters[0].Constraints.Select(x=>Key(x.ConstraintType))),"exact original generic constraint");
            var field=original.Fields.Single(x=>x.Name=="CMDPMJBEBAB");var df=donor.Fields.Single(x=>x.Name==field.Name);Need(field.Attributes==df.Attributes&&Key(field.FieldType)==Key(df.FieldType),"exact original private static T field");
            foreach(string name in new[]{"Awake","OnDestroy"})
            {
                var left=original.Methods.Single(x=>x.Name==name&&x.Parameters.Count==0);var right=donor.Methods.Single(x=>x.Name==name&&x.Parameters.Count==0);
                Need(left.Attributes==right.Attributes&&Key(left.ReturnType)==Key(right.ReturnType)&&right.HasBody,"exact original singleton method binding");
                var refs=right.Body.Instructions.Where(i=>i.Operand is FieldReference).Select(i=>(FieldReference)i.Operand).ToArray();Need(refs.All(x=>x.Name==field.Name&&x.DeclaringType.FullName.StartsWith("SingletonMonoBehaviour`1",StringComparison.Ordinal)&&Key(x.FieldType)=="!0"),"only original static instance field touched");
                var calls=right.Body.Instructions.Where(i=>i.Operand is MethodReference).Select(i=>(MethodReference)i.Operand).ToArray();
                if(name=="OnDestroy")Need(calls.Length==1&&calls[0].Name=="op_Equality"&&calls[0].DeclaringType.FullName=="UnityEngine.Object","genuine Unity cleanup equality");
                else
                {
                    Need(calls.Length==7,"seven actual compiler bound Awake calls");
                    Need(calls.Select(x=>x.Name).SequenceEqual(new[]{"op_Inequality","GetTypeFromHandle","ToString","Concat","LogWarning","get_gameObject","Destroy"}),"actual typed Awake call order");
                    Need(calls[0].DeclaringType.FullName=="UnityEngine.Object"&&calls[1].DeclaringType.FullName=="System.Type"&&(calls[2].DeclaringType.FullName=="System.Type"||calls[2].DeclaringType.FullName=="System.Object")&&calls[3].DeclaringType.FullName=="System.String"&&calls[4].DeclaringType.FullName=="UnityEngine.Debug"&&calls[5].DeclaringType.FullName=="UnityEngine.Component"&&calls[6].DeclaringType.FullName=="UnityEngine.Object","genuine framework owners");
                    Need(!original.IsValueType && original.BaseType.FullName=="UnityEngine.MonoBehaviour" && original.GenericParameters[0].Constraints.Single().ConstraintType.FullName=="SingletonMonoBehaviour`1<T>","native self constraint proves T is a reference type");
                    var cast=right.Body.Instructions.Single(i=>i.OpCode.Code==Code.Unbox_Any);Need(Key((TypeReference)cast.Operand)=="!0" && right.Body.Instructions[right.Body.Instructions.IndexOf(cast)-1].OpCode.Code==Code.Ldarg_0 && right.Body.Instructions[right.Body.Instructions.IndexOf(cast)+1].OpCode.Code==Code.Stsfld && !right.Body.Instructions.Any(i=>i.OpCode.Code==Code.Castclass),"actual Csc checked reference unbox.any !0 from this immediately into original static field");
                }
            }
            var og=Types(c.Types).Single(x=>x.FullName=="MKECFLEMHEL").Methods.Single(x=>x.Name=="GFKAFPHLKMJ");
            var dg=Types(d.Types).Single(x=>x.FullName=="MKECFLEMHEL").Methods.Single(x=>x.Name==og.Name);
            Need(og.Attributes==dg.Attributes&&og.ReturnType.FullName==dg.ReturnType.FullName&&og.Parameters.Select(x=>Key(x.ParameterType)).SequenceEqual(dg.Parameters.Select(x=>Key(x.ParameterType))),"exact original disposed signature/flags");
            var dc=dg.Body.Instructions.Where(i=>i.Operand is MethodReference).Select(i=>(MethodReference)i.Operand).ToArray();Need(dc.Length==1&&dc[0].DeclaringType.FullName=="System.InvalidOperationException"&&dc[0].Name==".ctor"&&dc[0].Parameters.Single().ParameterType.FullName=="System.String"&&dg.Body.Instructions.Count(i=>i.OpCode.Code==Code.Throw)==1,"exact original exception type/message overload");
            Console.WriteLine("RESULT three_exact_original_owner_bindings_verified_metadata_only; game_assembly_loaded=false");
        }
    }
    static int Main(string[] args)
    {
        try { if(args.Length==0)RunEffects();else if(args.Length==5&&args[0]=="--inspect")Inspect(args[1],args[2],args[3],args[4]);else throw new Exception("invalid fixture arguments");return 0; }
        catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}
    }
}
