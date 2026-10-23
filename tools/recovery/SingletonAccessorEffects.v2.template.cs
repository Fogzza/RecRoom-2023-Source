// Explicit controlled Unity effects; never execute the production donor DLL.
using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
static class Effects
{
    internal static int Calls;
    internal static UnityEngine.Object Left,Right;
    internal static Action DuringComparison;
    internal static bool Throw;
    internal static void Reset(){Calls=0;Left=null;Right=null;DuringComparison=null;Throw=false;}
}
namespace UnityEngine
{
    public class Object
    {
        public bool Alive=true;
        public static bool operator !=(Object a,Object b)
        {
            Effects.Calls++;Effects.Left=a;Effects.Right=b;
            if(Effects.DuringComparison!=null)Effects.DuringComparison();
            if(Effects.Throw)throw new ApplicationException("operator-marker");
            bool an=System.Object.ReferenceEquals(a,null),bn=System.Object.ReferenceEquals(b,null);
            return an ? (!bn&&b.Alive) : (bn ? a.Alive : !System.Object.ReferenceEquals(a,b));
        }
        public static bool operator ==(Object a,Object b){throw new Exception("wrong operator");}
        public override bool Equals(object value){throw new Exception("wrong Equals");}
        public override int GetHashCode(){return 1;}
    }
    public class MonoBehaviour:Object { }
}
public class SingletonMonoBehaviour<T>:UnityEngine.MonoBehaviour where T:SingletonMonoBehaviour<T>
{
    private static T CMDPMJBEBAB;
    /*EXACT_ACCESSOR_MEMBERS*/
    public static void Set(T value){CMDPMJBEBAB=value;}
}
sealed class First:SingletonMonoBehaviour<First>{}
sealed class Second:SingletonMonoBehaviour<Second>{}
static class SingletonAccessorEffects
{
    static int cases;
    static void Need(bool value,string why){if(!value)throw new Exception(why);}
    static bool Same(object a,object b){return Object.ReferenceEquals(a,b);}
    static void Reset(){Effects.Reset();First.Set(null);Second.Set(null);}
    static void Done(string name){cases++;Console.WriteLine("PASS "+name);}
    static void Compare(object expected){Need(Effects.Calls==1&&Same(Effects.Left,expected)&&Same(Effects.Right,null),"one genuine inequality-shaped comparison with captured instance and null");}
    static void Run()
    {
        Reset();Need(Same(First.Instance,null)&&Effects.Calls==0,"null raw field");Done("Instance initial null without Unity operator");
        Reset();var first=new First();First.Set(first);Need(Same(First.Instance,first)&&Effects.Calls==0,"exact raw instance");Done("Instance exact stored reference");
        Reset();first=new First{Alive=false};First.Set(first);Need(Same(First.Instance,first)&&Effects.Calls==0,"no fake-null normalization in raw getter");Done("Instance preserves destroyed-object reference");
        Reset();first=new First();var second=new Second();First.Set(first);Second.Set(second);Need(Same(First.Instance,first)&&Same(Second.Instance,second)&&Effects.Calls==0,"generic separation");Done("independent closed generic storage");
        Reset();Need(!First.IsInitialized,"null false");Compare(null);Done("IsInitialized null false through operator");
        Reset();first=new First();First.Set(first);Need(First.IsInitialized,"live true");Compare(first);Done("IsInitialized live true through operator");
        Reset();first=new First{Alive=false};First.Set(first);Need(!First.IsInitialized,"Unity fake-null false");Compare(first);Done("IsInitialized destroyed-object false");
        Reset();first=new First();First.Set(first);Effects.Throw=true;bool threw=false;try{var ignored=First.IsInitialized;}catch(ApplicationException e){threw=e.Message=="operator-marker";}Need(threw&&Same(First.Instance,first),"comparison exception propagation/storage");Compare(first);Done("operator exception propagates with original field retained");
        Reset();first=new First();First.Set(first);Effects.DuringComparison=()=>First.Set(null);Need(First.IsInitialized&&Same(First.Instance,null),"operator sees captured object, getter re-reads later");Compare(first);Done("one getter capture before operator callback");
        Reset();Need(Same(First.Instance,null),"first read");first=new First();First.Set(first);Need(Same(First.Instance,first),"second read");First.Set(null);Need(Same(First.Instance,null)&&Effects.Calls==0,"third read");Done("Instance reads current storage without cache");
        Need(cases==10,"ten bounded controlled cases");Console.WriteLine("RESULT ten_exact_accessor_controlled_effect_cases_passed; production_Dâ€‹â€‹LL_executed=false; Unity_runtime_proved=false");
    }
    static string Key(TypeReference t)
    {
        if(t is GenericParameter g)return(g.Type==GenericParameterType.Method?"!!":"!")+g.Position;
        if(t is GenericInstanceType i)return i.ElementType.FullName+"<"+String.Join(",",i.GenericArguments.Select(Key))+">";
        return t.FullName;
    }
    static void Inspect(string originalPath,string donorPath)
    {
        using(var a=ModuleDefinition.ReadModule(originalPath))using(var b=ModuleDefinition.ReadModule(donorPath))
        {
            var x=a.Types.Single(t=>t.FullName=="SingletonMonoBehaviour`1");var y=b.Types.Single(t=>t.FullName==x.FullName);
            Need(x.BaseType.FullName=="UnityEngine.MonoBehaviour"&&Key(x.BaseType)==Key(y.BaseType)&&x.GenericParameters.Count==1&&y.GenericParameters.Count==1,"exact original owner/base/generic arity");
            Need(x.GenericParameters[0].Attributes==y.GenericParameters[0].Attributes&&x.GenericParameters[0].Constraints.Select(c=>Key(c.ConstraintType)).SequenceEqual(y.GenericParameters[0].Constraints.Select(c=>Key(c.ConstraintType))),"exact original generic constraint");
            var f=x.Fields.Single(v=>v.Name=="CMDPMJBEBAB");var g=y.Fields.Single(v=>v.Name==f.Name);Need(f.Attributes==g.Attributes&&Key(f.FieldType)=="!0"&&Key(g.FieldType)=="!0","original private static T field");
            foreach(var name in new[]{"Instance","IsInitialized"})
            {
                // Runtime PropertyDef names remain original and obfuscated.
                // Join through the exact getter MethodDef instead of assuming
                // the readable donor's source alias is the runtime property name.
                var m=x.Methods.Single(v=>v.Name=="get_"+name&&v.Parameters.Count==0);var p=x.Properties.Single(v=>v.GetMethod==m);
                var q=y.Properties.Single(v=>v.Name==name);var n=q.GetMethod;
                Need(m.MetadataToken.ToUInt32()==(name=="Instance"?0x06000011u:0x06000012u)&&p.MetadataToken.ToUInt32()==(name=="Instance"?0x17000002u:0x17000003u)&&p.Name==(name=="Instance"?"OFDKPDDLIJC":"KKKHNMGIFMF"),"exact original getter/obfuscated PropertyDef ownership");
                Need(m.Attributes==n.Attributes&&m.ImplAttributes==n.ImplAttributes&&m.IsStatic&&m.Parameters.Count==0&&n.Parameters.Count==0&&Key(m.ReturnType)==Key(n.ReturnType)&&p.SetMethod==null&&q.SetMethod==null,"exact original getter property/signature/flags");
                var ins=n.Body.Instructions.ToArray();
                if(name=="Instance")
                {
                    Need(ins.Select(i=>i.OpCode.Code).SequenceEqual(new[]{Code.Ldsfld,Code.Ret}),"exact load-static-field return IL");
                    var field=(FieldReference)ins[0].Operand;Need(field.Name==f.Name&&Key(field.FieldType)=="!0"&&Key(field.DeclaringType)=="SingletonMonoBehaviour`1<!0>","exact generic original field binding");
                }
                else
                {
                    Need(ins.Select(i=>i.OpCode.Code).SequenceEqual(new[]{Code.Call,Code.Box,Code.Ldnull,Code.Call,Code.Ret}),"exact get-Instance, reference conversion, null, Unity inequality, return IL");
                    var get=(MethodReference)ins[0].Operand;var cmp=(MethodReference)ins[3].Operand;
                    Need(get.Name=="get_Instance"&&Key(get.DeclaringType)=="SingletonMonoBehaviour`1<!0>"&&Key(get.ReturnType)=="!0"&&get.Parameters.Count==0&&Key((TypeReference)ins[1].Operand)=="!0","exact original generic getter call/reference conversion");
                    Need(cmp.DeclaringType.FullName=="UnityEngine.Object"&&((AssemblyNameReference)cmp.DeclaringType.Scope).Name=="UnityEngine.CoreModule"&&cmp.Name=="op_Inequality"&&cmp.ReturnType.FullName=="System.Boolean"&&cmp.Parameters.Select(v=>v.ParameterType.FullName).SequenceEqual(new[]{"UnityEngine.Object","UnityEngine.Object"}),"genuine matching Unity typed inequality");
                }
            }
            Console.WriteLine("RESULT two_exact_original_accessor_bindings_verified_metadata_only; donor_not_loaded=true");
        }
    }
    static int Main(string[] args)
    {
        try{if(args.Length==0)Run();else if(args.Length==3&&args[0]=="--inspect")Inspect(args[1],args[2]);else throw new Exception("fixture arguments");return 0;}
        catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}
    }
}
