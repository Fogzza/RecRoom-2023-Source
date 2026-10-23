// Explicit test-only dependencies. Never load or invoke a production donor DLL.
using System;
using System.Linq;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
static class State
{
    internal static readonly List<string> Events=new List<string>();
    internal static MNALHHOLFGL Registered,Parent,Child;
    internal static Type RegisteredType,LookupType;
    internal static string RegisteredName,LookupName,Log;
    internal static object Value;
    internal static bool Success,ThrowRegistration,ThrowLookup,ThrowLog,ThrowChild;
    internal static Action OnLog;
    internal static HJDBOADFHMC? Color;
    internal static void Reset(){Events.Clear();Registered=Parent=Child=null;RegisteredType=LookupType=null;RegisteredName=LookupName=Log=null;Value=null;Success=ThrowRegistration=ThrowLookup=ThrowLog=ThrowChild=false;OnLog=null;Color=null;MPAAIECKLGA.SetCache(null);}
}
public interface NJAICAFMPBE{}
public interface CKAJONGONMK{}
public sealed class MNALHHOLFGL
{
    private readonly MNALHHOLFGL DDFCHDGPJBN;
    private readonly string LGENGCEEBPB;
    private PFCPCBJDEMB MGADLDPDPGK;
    private bool KBDIBPJIHNN;
    private enum PFCPCBJDEMB:byte{CompileContextZero=0}
    /*EXACT_CONTAINER_CTORS*/
    /*EXACT_RESOLVER*/
    public MNALHHOLFGL PHJOGIEDKPN<TClass>(TClass value,string name=null) where TClass:class
    {
        State.Events.Add("register");State.Registered=this;State.RegisteredType=typeof(TClass);State.RegisteredName=name;
        if(!ReferenceEquals(value,this)||AAHKPPMHGFI==null||LMAFHCPPMAD==null||OLGLBMGAHBO==null||(byte)MGADLDPDPGK!=0)throw new Exception("ctor registration input/initialization order");
        if(State.ThrowRegistration)throw new ApplicationException("registration-marker");return this;
    }
    private bool NGBMOPMLJCM<TType>(CPAMAFPANDM key,out TType value) where TType:class
    {
        State.Events.Add("lookup");State.LookupType=key.AFJAGKNNCBE;State.LookupName=key.FEKLPCPODAH;
        if(State.ThrowLookup)throw new ApplicationException("lookup-marker");value=(TType)State.Value;return State.Success;
    }
    public MNALHHOLFGL MJHONDPGJFA(string name)
    {State.Events.Add("child");State.Parent=this;State.RegisteredName=name;if(State.ThrowChild)throw new ApplicationException("child-marker");return State.Child;}
    public static MNALHHOLFGL Parented(MNALHHOLFGL parent,string name){return new MNALHHOLFGL(parent,name);}
    public MNALHHOLFGL Parent{get{return DDFCHDGPJBN;}}
    public string Name{get{return LGENGCEEBPB;}}
    public object[] Allocations{get{return new object[]{AAHKPPMHGFI,LMAFHCPPMAD,OLGLBMGAHBO};}}
    public void DisposeForTest(){KBDIBPJIHNN=true;}
}
public struct CPAMAFPANDM
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    /*EXACT_KEY_CTOR*/
}
internal sealed class OENEDGPIOFN
{
    private sealed class NPDGPDKAHLN{}
    private List<CPAMAFPANDM> OMMELJLAGLB;
    /*EXACT_AUX_CTOR*/
    public bool Initialized{get{return NLDFDGJCKFH!=null&&DJGFOAKOCAP!=null&&NLDFDGJCKFH.Count==0&&DJGFOAKOCAP.Count==0&&OMMELJLAGLB==null;}}
}
internal static class OriginalGuard
{
    /*EXACT_DISPOSED_GUARD*/
}
internal static class MKECFLEMHEL
{
    public static void GFKAFPHLKMJ(bool condition,string message){State.Events.Add("guard");OriginalGuard.GFKAFPHLKMJ(condition,message);}
}
// These are explicit test-only enum/color/logger dependencies. Their real
// original implementations are not replaced, executed, or claimed recovered.
public enum NAFLJHIHEAG{TestZero=0}
public struct HJDBOADFHMC{public int Value;public static HJDBOADFHMC LMOLABKFOAB=new HJDBOADFHMC{Value=731};}
public static class PNAABCMOHGM
{
    public static void FPNMONCCAAE(object message,in HJDBOADFHMC? color)
    {State.Events.Add("log");State.Log=(string)message;State.Color=color;if(State.OnLog!=null)State.OnLog();if(State.ThrowLog)throw new ApplicationException("log-marker");}
}
public static class MPAAIECKLGA
{
    private static MNALHHOLFGL OAEHHEPLLJE;
    /*EXACT_INITIALIZATION_MEMBERS*/
    public static void SetCache(MNALHHOLFGL value){OAEHHEPLLJE=value;}
    public static MNALHHOLFGL Peek(){return OAEHHEPLLJE;}
    public static MNALHHOLFGL Factory(string name,MNALHHOLFGL parent){return OBAIKOPBHAP(name,parent);}
}
interface IService{}
sealed class Service:IService{}
static class ContainerLowerEffects
{
    static int cases;
    static void Need(bool v,string m){if(!v)throw new Exception(m);}
    static bool Same(object a,object b){return Object.ReferenceEquals(a,b);}
    static void Done(string name){cases++;Console.WriteLine("PASS "+name);}
    static void Events(params string[] values){Need(State.Events.SequenceEqual(values),"effect order: "+String.Join(",",State.Events));}
    static bool Throws<T>(Action action,string message=null) where T:Exception{try{action();return false;}catch(Exception e){return e is T&&(message==null||e.Message==message);}}
    static MNALHHOLFGL Fresh(){State.Reset();var x=new MNALHHOLFGL();State.Events.Clear();return x;}
    static void Missing(MNALHHOLFGL x,string name)
    {
        try{x.HHCPOGCCGNF<IService>(name);throw new Exception("missing accepted");}
        catch(ArgumentException e){Need(e.ParamName==null&&e.Message==String.Format("No dependency of type {0} found{1}",typeof(IService),name!=null?String.Concat(" with customId \"",name,"\""):""),"exact original missing message/no invented parameter name");}
    }
    static void Run()
    {
        State.Reset();var x=new MNALHHOLFGL();Need(Same(State.Registered,x)&&State.RegisteredType==typeof(MNALHHOLFGL)&&State.RegisteredName==null&&x.Parent==null&&x.Name==null,"default constructor inputs");Events("register");Done("default ctor chain and self registration");
        State.Reset();x=new MNALHHOLFGL("named");Need(x.Name=="named"&&x.Parent==null,"name forwarded");Events("register");Done("string ctor chain");
        var parent=x;State.Reset();x=MNALHHOLFGL.Parented(parent,"child");Need(Same(x.Parent,parent)&&x.Name=="child","private ctor exact parent/name");Done("private ctor parent/name/state");
        State.Reset();State.ThrowRegistration=true;Need(Throws<ApplicationException>(()=>new MNALHHOLFGL("throw"),"registration-marker")&&State.Registered.Name=="throw","registration exception retains initialized original fields");Done("constructor registration exception propagates");
        State.Reset();var a=new MNALHHOLFGL();var b=new MNALHHOLFGL();Need(a.Allocations.Zip(b.Allocations,(l,r)=>!Same(l,r)).All(v=>v)&&!Same(a.Allocations[0],a.Allocations[1]),"per object independent dictionaries/auxiliary");Done("fresh initializer allocations per container");
        var key=new CPAMAFPANDM(typeof(IService),"id");Need(key.AFJAGKNNCBE==typeof(IService)&&key.FEKLPCPODAH=="id","key exact fields");Done("key constructor fields");
        key=new CPAMAFPANDM(null,null);Need(key.AFJAGKNNCBE==null&&key.FEKLPCPODAH==null,"key permits original nulls");Done("key nulls preserved");
        key=new CPAMAFPANDM(typeof(IService),"");Need(key.FEKLPCPODAH=="","empty distinct from null");Done("key empty name preserved");
        Need(new OENEDGPIOFN().Initialized,"original auxiliary maps initialized/list untouched");Done("auxiliary dictionary/hashset/list initialization");
        x=Fresh();var service=new Service();State.Success=true;State.Value=service;Need(Same(x.HHCPOGCCGNF<IService>("named"),service)&&State.LookupType==typeof(IService)&&State.LookupName=="named","exact requested key/result");Events("guard","lookup");Done("successful typed lookup");
        x=Fresh();State.Success=true;Need(x.HHCPOGCCGNF<IService>()==null,"successful null result forwarded");Events("guard","lookup");Done("successful null lookup preserved");
        x=Fresh();Missing(x,null);Events("guard","lookup");Done("missing null-name message");
        x=Fresh();Missing(x,"");Done("missing empty-name suffix");
        x=Fresh();Missing(x,"quoted\"name");Done("missing name retains original quote formatting");
        x=Fresh();x.DisposeForTest();Need(Throws<InvalidOperationException>(()=>x.HHCPOGCCGNF<IService>(),"You should not try to retrieve bindings from a disposed container!"),"original disposed exception");Events("guard");Done("disposed guard precedes lookup");
        x=Fresh();State.ThrowLookup=true;Need(Throws<ApplicationException>(()=>x.HHCPOGCCGNF<IService>(),"lookup-marker"),"lookup exception propagates");Events("guard","lookup");Done("lookup exception propagation");
        State.Reset();x=new MNALHHOLFGL("cached");State.Events.Clear();MPAAIECKLGA.SetCache(x);Need(Same(MPAAIECKLGA.CFHDLGEGDFD,x),"cache hit exact");Events();Done("getter cache hit no construction/logging");
        State.Reset();x=MPAAIECKLGA.CFHDLGEGDFD;Need(x!=null&&Same(x,MPAAIECKLGA.Peek())&&x.Name=="TestZero"&&x.Parent==null,"enum ToString/factory/cache");Events("log","register");Done("getter miss uses boxed enum name and caches real result");
        State.Reset();State.ThrowLog=true;Need(Throws<ApplicationException>(()=>{var ignored=MPAAIECKLGA.CFHDLGEGDFD;},"log-marker")&&MPAAIECKLGA.Peek()==null,"getter failure no cache update");Events("log");Done("getter logging failure retains null cache");
        State.Reset();State.ThrowRegistration=true;Need(Throws<ApplicationException>(()=>{var ignored=MPAAIECKLGA.CFHDLGEGDFD;},"registration-marker")&&MPAAIECKLGA.Peek()==null,"constructor failure no cache update");Events("log","register");Done("getter construction failure retains null cache");
        State.Reset();x=MPAAIECKLGA.Factory("root",null);Need(x.Name=="root"&&x.Parent==null&&State.Log=="DI: Creating Container (root)"&&State.Color.HasValue&&State.Color.Value.Value==731,"exact log/name/nullable color");Events("log","register");Done("root factory logs before construction with exact color");
        parent=x;State.Reset();State.Child=parent;Need(Same(MPAAIECKLGA.Factory("child",parent),parent)&&Same(State.Parent,parent)&&State.RegisteredName=="child","same parent and returned child");Events("log","child");Done("parent factory exact receiver/name/return");
        State.Reset();Need(MPAAIECKLGA.Factory("child",parent)==null,"child null forwarded");Events("log","child");Done("parent child-null result preserved");
        State.Reset();x=MPAAIECKLGA.Factory(null,null);Need(x.Name==null&&State.Log=="DI: Creating Container ()","null concat/name behavior");Done("factory null name preserved");
        State.Reset();State.ThrowLog=true;Need(Throws<ApplicationException>(()=>MPAAIECKLGA.Factory("x",parent),"log-marker")&&State.Parent==null,"logging before child branch");Events("log");Done("logging failure prevents child dispatch");
        State.Reset();State.ThrowChild=true;Need(Throws<ApplicationException>(()=>MPAAIECKLGA.Factory("x",parent),"child-marker"),"child failure propagates");Events("log","child");Done("child exception propagation");
        Need(cases==26,"exact finite 26 cases");Console.WriteLine("RESULT twenty_six_exact_lower_container_effects_passed; production_dependencies_executed=false; provider_graph_recovered=false");
    }
    static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows){foreach(var t in rows){yield return t;foreach(var n in Types(t.NestedTypes))yield return n;}}
    static string Key(TypeReference t){if(t is GenericParameter g)return(g.Type==GenericParameterType.Method?"!!":"!")+g.Position;if(t is GenericInstanceType i)return i.ElementType.FullName+"<"+String.Join(",",i.GenericArguments.Select(Key))+">";if(t is ByReferenceType r)return Key(r.ElementType)+"&";return t.FullName;}
    static string Signature(MethodReference m){return Key(m.ReturnType)+"("+String.Join(",",m.Parameters.Select(p=>Key(p.ParameterType)))+")";}
    static void Inspect(string originalUject,string donorUject,string originalInit,string donorInit)
    {
        using(var a=ModuleDefinition.ReadModule(originalUject))using(var b=ModuleDefinition.ReadModule(donorUject))using(var c=ModuleDefinition.ReadModule(originalInit))using(var d=ModuleDefinition.ReadModule(donorInit))
        {
            int count=0;
            foreach(var pair in new[]{Tuple.Create(a,b),Tuple.Create(c,d)})
            foreach(string ownerName in pair.Item1==a?new[]{"MNALHHOLFGL","CPAMAFPANDM","OENEDGPIOFN"}:new[]{"MPAAIECKLGA"})
            {
                var x=Types(pair.Item1.Types).Single(t=>t.FullName==ownerName);var y=Types(pair.Item2.Types).Single(t=>t.FullName==ownerName);
                var selected=x.Methods.Where(m=>ownerName=="MNALHHOLFGL"?(m.Name==".ctor"||m.Name=="HHCPOGCCGNF"):ownerName=="MPAAIECKLGA"?(m.Name=="PNFLFFOAING"||m.Name=="OBAIKOPBHAP"):m.Name==".ctor").ToArray();
                foreach(var m in selected)
                {
                    string donorName=m.Name=="PNFLFFOAING"?"get_CFHDLGEGDFD":m.Name;var n=y.Methods.Single(v=>v.Name==donorName&&Signature(v)==Signature(m)&&v.GenericParameters.Count==m.GenericParameters.Count);
                    Need(m.Attributes==n.Attributes&&m.ImplAttributes==n.ImplAttributes,"exact selected flags/signature "+ownerName+"."+m.Name);Need(m.GenericParameters.Select(g=>g.Attributes).SequenceEqual(n.GenericParameters.Select(g=>g.Attributes)),"generic constraints flags");
                    foreach(var field in n.Body.Instructions.Where(i=>i.Operand is FieldReference).Select(i=>(FieldReference)i.Operand).Where(f=>f.DeclaringType.GetElementType().FullName==ownerName))
                    {var original=x.Fields.Single(f=>f.Name==field.Name);Need(Key(original.FieldType)==Key(field.FieldType),"original field identity/type "+field.Name);}
                    var calls=n.Body.Instructions.Where(i=>i.Operand is MethodReference).Select(i=>(MethodReference)i.Operand).ToArray();
                    if(ownerName=="MNALHHOLFGL"&&m.Name==".ctor"&&m.Parameters.Count==2)
                    {Need(calls.Length==5&&calls[0].DeclaringType.FullName.StartsWith("System.Collections.Generic.Dictionary`2")&&calls[1].DeclaringType.FullName.StartsWith("System.Collections.Generic.Dictionary`2")&&calls[2].DeclaringType.FullName=="OENEDGPIOFN"&&calls[3].DeclaringType.FullName=="System.Object"&&calls[4] is GenericInstanceMethod reg&&reg.Name=="PHJOGIEDKPN"&&reg.GenericArguments.Single().FullName=="MNALHHOLFGL","three field initializers before base, exact self registration after base");}
                    if(ownerName=="MNALHHOLFGL"&&m.Name=="HHCPOGCCGNF")
                    {Need(calls[0].DeclaringType.FullName=="MKECFLEMHEL"&&calls[0].Name=="GFKAFPHLKMJ"&&calls.Count(v=>v.Name=="NGBMOPMLJCM")==1&&calls.Single(v=>v.Name=="NGBMOPMLJCM") is GenericInstanceMethod lookup&&Key(lookup.GenericArguments.Single())=="!!0"&&calls.Last().DeclaringType.FullName=="System.ArgumentException","guard/typed original lookup/missing exception bindings");}
                    if(ownerName=="MPAAIECKLGA"&&m.Name=="OBAIKOPBHAP")Need(calls.Select(v=>v.Name).SequenceEqual(new[]{"Concat",".ctor","FPNMONCCAAE","MJHONDPGJFA",".ctor"})&&calls[2].DeclaringType.FullName=="PNAABCMOHGM"&&calls[2].Parameters[1].ParameterType is ByReferenceType,"preserved nullable color/log first/parent and root branches");
                    count++;
                }
            }
            Need(count==8,"exact eight selected member bindings");Console.WriteLine("RESULT eight_exact_lower_member_bindings_verified_metadata_only; donor_not_loaded=true");
        }
    }
    static int Main(string[] args){try{if(args.Length==0)Run();else if(args.Length==5&&args[0]=="--inspect")Inspect(args[1],args[2],args[3],args[4]);else throw new Exception("fixture arguments");return 0;}catch(Exception e){Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1;}}
}
