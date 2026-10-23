// Test-only recording contexts. No production SDK/game body executes here.
using System;using System.Linq;using System.Collections.Generic;using Mono.Cecil;using Mono.Cecil.Cil;
static class BootEffects
{
    internal static readonly List<string> Calls=new List<string>();internal static readonly Exception Failure=new ApplicationException("controlled exact exception");internal static string ThrowAt;internal static int PlatformReads,ContainerReads;internal static Action OnFlag,OnTimer;internal static PlatformManager First,Second;internal static MNALHHOLFGL C1,C2;internal static OFDHBOEDNCN Timer;internal static string Version="20230414";internal static object Log;internal static HJDBOADFHMC? Color;internal static Action<float> Callback;internal static BootSequence SchedulerOwner;internal static bool SchedulerFlag;internal static IDisposable Scheduled;
    internal static void Hit(string s){Calls.Add(s);if(ThrowAt==s)throw Failure;}
    internal static void Reset(){Calls.Clear();ThrowAt=null;PlatformReads=ContainerReads=0;OnFlag=OnTimer=null;First=new PlatformManager(2f,false);Second=new PlatformManager(0f,false);C1=new MNALHHOLFGL();C2=new MNALHHOLFGL();Timer=new OFDHBOEDNCN("A");Version="20230414";Log=null;Color=null;Callback=null;SchedulerOwner=null;SchedulerFlag=false;Scheduled=new Disposable();}
    internal sealed class Disposable:IDisposable{public void Dispose(){throw new Exception("No disposal is allowed in MoveNext");}}
}
sealed class PlatformManager
{
    readonly float time;readonly bool needs;internal PlatformManager(float t,bool n){time=t;needs=n;}
    internal static PlatformManager Instance{get{int n=++BootEffects.PlatformReads;BootEffects.Hit("platform"+n);return n==1?BootEffects.First:BootEffects.Second;}}
    internal float GetCurrentProcessTimeSinceBoot(){BootEffects.Hit("process");return time;}
    internal bool RequiresLoginBeforeInternet{get{BootEffects.Hit("requires");return needs;}}
}
enum KDHPMLNMNNO{Other=0,Selected=1}
interface MCCKDPKLCIN{KDHPMLNMNNO CurrentUnityLauncher{get;}}
interface GCLANALOAPO{void IHEKMEOIBOI();}
sealed class Launcher:MCCKDPKLCIN{internal KDHPMLNMNNO Value=KDHPMLNMNNO.Selected;public KDHPMLNMNNO CurrentUnityLauncher{get{BootEffects.Hit("launcher");return Value;}}}
sealed class Gcl:GCLANALOAPO{public void IHEKMEOIBOI(){BootEffects.Hit("gcl-init");}}
sealed class MNALHHOLFGL
{
    internal MCCKDPKLCIN Launcher=new Launcher();internal GCLANALOAPO Gcl=new Gcl();internal string LastKey;
    internal T HHCPOGCCGNF<T>(string key){LastKey=key;BootEffects.Hit(typeof(T)==typeof(MCCKDPKLCIN)?"resolve-launcher":"resolve-gcl");return(T)(object)(typeof(T)==typeof(MCCKDPKLCIN)?(object)Launcher:Gcl);}
}
static class MPAAIECKLGA{internal static MNALHHOLFGL CFHDLGEGDFD{get{int n=++BootEffects.ContainerReads;BootEffects.Hit("container"+n);return n==1?BootEffects.C1:BootEffects.C2;}}}
sealed class OFDHBOEDNCN
{
    internal readonly string Name;internal readonly List<Tuple<string,float>> Timers=new List<Tuple<string,float>>();internal OFDHBOEDNCN(string name){Name=name;}
    internal void OJFIFFKKFLH(string key,float value){BootEffects.Hit("timer:"+Name+":"+key);Timers.Add(Tuple.Create(key,value));BootEffects.OnTimer?.Invoke();}
}
struct HJDBOADFHMC{internal int Value;internal static readonly HJDBOADFHMC NLODGHMOFNO=new HJDBOADFHMC{Value=91};}
static class IDDIAODMAPP{internal static string OLGKJALIAAI{get{BootEffects.Hit("version");return BootEffects.Version;}}}
static class PNAABCMOHGM{internal static void FPNMONCCAAE(object log,HJDBOADFHMC? color){BootEffects.Hit("log");BootEffects.Log=log;BootEffects.Color=color;}}
static class NDFLHBFOIGB{internal static void IHEKMEOIBOI(){BootEffects.Hit("network");}}
sealed class MDEJADHJOEJ{internal ushort Received=99;internal void IHEKMEOIBOI(ushort value){BootEffects.Hit("controller");Received=value;}}
static class JHIKKDDFDGA{internal static IDisposable FJNOABDJGMO(BootSequence owner,Action<float> callback,bool flag){BootEffects.Hit("scheduler");BootEffects.SchedulerOwner=owner;BootEffects.Callback=callback;BootEffects.SchedulerFlag=flag;return BootEffects.Scheduled;}}
namespace UnityEngine{sealed class WaitForEndOfFrame{internal WaitForEndOfFrame(){BootEffects.Hit("yield");}}}
sealed class BootSequence
{
    const string KFLCEJHCAII="(Process Start To User Interaction)",MDGBEFOBMLG="(Total)",KFKHDPIOGDF="(Waiting for Rec Room)",JIGCOAAHHCO="(Before Login)",DPOPFLBCAKF="(Boot Start To User Interaction)";
    internal int CGCGDEEJADP;internal float KEEBMEBDMMH=-77;bool lip;internal bool LIPOFDEAMPE{get{return lip;}set{lip=value;BootEffects.OnFlag?.Invoke();}}internal OFDHBOEDNCN AIDHPHJKAMP{get{return BootEffects.Timer;}}internal string HLLLBLNAABH="old";internal bool PHFHOMMGCGJ=true;internal MDEJADHJOEJ HOMDODONEKI=new MDEJADHJOEJ();internal IDisposable CBFAAHKFJCI=new BootEffects.Disposable();internal float CallbackValue=-1;
    internal void DKODHBLBHDC(){BootEffects.Hit("internet");}internal void HKBJKPPPCPM(float v){CallbackValue=v;}
    internal sealed class NEKGMMPKEPF
    {
        int _003C_003E1__state;object _003C_003E2__current;BootSequence _003C_003E4__this;
        internal NEKGMMPKEPF(int state,BootSequence boot){_003C_003E1__state=state;_003C_003E4__this=boot;_003C_003E2__current=new object();}
        internal int State{get{return _003C_003E1__state;}}internal object Current{get{return _003C_003E2__current;}}
        /*EXACT_NATIVE_REVIEWED_MOVE_NEXT*/
        internal bool Step(){return MoveNext();}
    }
}
static class BootCoroutineMoveNextEffects
{
    static int count;static void Need(bool v,string m){if(!v)throw new Exception(m);}static void Case(string name,Action test){BootEffects.Reset();try{test();count++;}catch(Exception e){throw new Exception("Case "+name,e);}}
    static void Throws<T>(Action f,Exception exact=null)where T:Exception{try{f();throw new Exception("Expected "+typeof(T).Name);}catch(T e){if(exact!=null)Need(Object.ReferenceEquals(e,exact),"Same thrown object");}}
    static BootSequence.NEKGMMPKEPF Machine(out BootSequence b,int state=0){b=new BootSequence();return new BootSequence.NEKGMMPKEPF(state,b);}
    static readonly string[] Normal={"platform1","process","timer:A:(Process Start To User Interaction)","timer:A:(Total)","timer:A:(Waiting for Rec Room)","timer:A:(Before Login)","timer:A:(Boot Start To User Interaction)","version","log","network","container1","resolve-launcher","launcher","container2","resolve-gcl","gcl-init","platform2","requires","internet","yield"};
    static void Effects()
    {
        Case("state0 full native order",()=>{BootSequence b;var m=Machine(out b);Need(m.Step()&&m.State==1&&m.Current is UnityEngine.WaitForEndOfFrame,"First yield");Need(BootEffects.Calls.SequenceEqual(Normal),"Whole ordered external trace");Need(b.LIPOFDEAMPE&&b.KEEBMEBDMMH==2&&b.HLLLBLNAABH==null&&!b.PHFHOMMGCGJ,"Original stores");Need(BootEffects.C1.LastKey==null&&BootEffects.C2.LastKey==null,"Both null lookup keys");Need((string)BootEffects.Log=="Build version: 20230414"&&BootEffects.Color.HasValue&&BootEffects.Color.Value.Value==91,"Exact log and optional color");});
        Case("state1 schedule and same callback receiver",()=>{BootSequence b;var m=Machine(out b,1);var old=m.Current;Need(!m.Step()&&m.State==-1&&Object.ReferenceEquals(old,m.Current),"Resume false/current retained");Need(BootEffects.Calls.SequenceEqual(new[]{"controller","scheduler"})&&b.HOMDODONEKI.Received==0,"Controller before scheduler exact ushort0");Need(Object.ReferenceEquals(BootEffects.SchedulerOwner,b)&&BootEffects.SchedulerFlag&&Object.ReferenceEquals(b.CBFAAHKFJCI,BootEffects.Scheduled),"Exact scheduler operands/store");BootEffects.Callback(3.5f);Need(b.CallbackValue==3.5f,"Bound callback target");});
        Case("state2 no boot dereference",()=>{var m=new BootSequence.NEKGMMPKEPF(2,null);var old=m.Current;Need(!m.Step()&&m.State==2&&Object.ReferenceEquals(old,m.Current)&&BootEffects.Calls.Count==0,"No work");});
        Case("minus1 no boot dereference",()=>{var m=new BootSequence.NEKGMMPKEPF(-1,null);Need(!m.Step()&&m.State==-1&&BootEffects.Calls.Count==0,"Completed");});
        Case("null build version retains Concat semantics",()=>{BootEffects.Version=null;BootSequence b;var m=Machine(out b);Need(m.Step()&&(string)BootEffects.Log=="Build version: ","Real String.Concat null behavior");});
        Case("nonzero counter skips process singleton",()=>{BootSequence b;var m=Machine(out b);b.CGCGDEEJADP=1;Need(m.Step()&&!b.LIPOFDEAMPE&&b.KEEBMEBDMMH==-77&&BootEffects.PlatformReads==1&&!BootEffects.Calls.Contains("process"),"Skip original optional branch");});
        Case("zero time saved skips optional timer",()=>{BootEffects.First=new PlatformManager(0,false);BootSequence b;var m=Machine(out b);Need(m.Step()&&b.KEEBMEBDMMH==0&&!b.LIPOFDEAMPE&&BootEffects.Timer.Timers.Count==4,"Zero");});
        Case("negative time saved skips optional timer",()=>{BootEffects.First=new PlatformManager(-2,false);BootSequence b;var m=Machine(out b);Need(m.Step()&&b.KEEBMEBDMMH==-2&&!b.LIPOFDEAMPE&&BootEffects.Timer.Timers.Count==4,"Negative");});
        Case("NaN saved and unordered branch skips optional timer",()=>{BootEffects.First=new PlatformManager(float.NaN,false);BootSequence b;var m=Machine(out b);Need(m.Step()&&float.IsNaN(b.KEEBMEBDMMH)&&!b.LIPOFDEAMPE&&BootEffects.Timer.Timers.Count==4,"NaN");});
        Case("positive infinity accepted",()=>{BootEffects.First=new PlatformManager(float.PositiveInfinity,false);BootSequence b;var m=Machine(out b);Need(m.Step()&&b.LIPOFDEAMPE&&float.IsPositiveInfinity(BootEffects.Timer.Timers[0].Item2),"Positive infinity");});
        Case("negative infinity skips",()=>{BootEffects.First=new PlatformManager(float.NegativeInfinity,false);BootSequence b;var m=Machine(out b);Need(m.Step()&&!b.LIPOFDEAMPE&&BootEffects.Timer.Timers.Count==4,"Negative infinity");});
        Case("receiver captured before flag write",()=>{var first=BootEffects.Timer;var second=new OFDHBOEDNCN("B");BootEffects.OnFlag=()=>BootEffects.Timer=second;BootSequence b;var m=Machine(out b);Need(m.Step()&&first.Timers.Count==1&&first.Timers[0].Item1=="(Process Start To User Interaction)"&&second.Timers.Count==4,"Captured original receiver then four rereads");});
        Case("timer field reread for each unconditional timer",()=>{var first=BootEffects.Timer;var second=new OFDHBOEDNCN("B");BootEffects.OnTimer=()=>{if(first.Timers.Count==2)BootEffects.Timer=second;};BootSequence b;var m=Machine(out b);Need(m.Step()&&first.Timers.Count==2&&second.Timers.Count==3,"No timer caching across calls");});
        Case("singleton reread uses second receiver",()=>{BootEffects.First=new PlatformManager(7,true);BootEffects.Second=new PlatformManager(0,false);BootSequence b;var m=Machine(out b);Need(m.Step()&&b.KEEBMEBDMMH==7&&BootEffects.Calls.Contains("internet")&&BootEffects.PlatformReads==2,"Second receiver used");});
        Case("container reread uses second container",()=>{BootEffects.C1.Gcl=null;BootEffects.C2.Launcher=null;BootSequence b;var m=Machine(out b);Need(m.Step()&&BootEffects.ContainerReads==2&&BootEffects.Calls.Contains("gcl-init"),"Distinct containers");});
        Case("other launcher skips second container",()=>{((Launcher)BootEffects.C1.Launcher).Value=0;BootSequence b;var m=Machine(out b);Need(m.Step()&&BootEffects.ContainerReads==1&&!BootEffects.Calls.Contains("resolve-gcl"),"Conditional service");});
        Case("requires login skips internet",()=>{BootEffects.Second=new PlatformManager(0,true);BootSequence b;var m=Machine(out b);Need(m.Step()&&!BootEffects.Calls.Contains("internet"),"Requires branch");});
        Case("null boot state0 after state minus1",()=>{var m=new BootSequence.NEKGMMPKEPF(0,null);Throws<NullReferenceException>(()=>m.Step());Need(m.State==-1&&BootEffects.Calls.Count==0,"State before dereference");});
        Case("null boot state1 after state minus1",()=>{var m=new BootSequence.NEKGMMPKEPF(1,null);Throws<NullReferenceException>(()=>m.Step());Need(m.State==-1&&BootEffects.Calls.Count==0,"Resume state");});
        Case("null first platform",()=>{BootEffects.First=null;BootSequence b;var m=Machine(out b);Throws<NullReferenceException>(()=>m.Step());Need(m.State==-1&&BootEffects.Calls.SequenceEqual(new[]{"platform1"}),"No process call");});
        Case("null second platform after DI",()=>{BootEffects.Second=null;BootSequence b;var m=Machine(out b);Throws<NullReferenceException>(()=>m.Step());Need(BootEffects.Calls.Last()=="platform2"&&!BootEffects.Calls.Contains("requires")&&m.State==-1,"No yield");});
        Case("null launcher propagates",()=>{BootEffects.C1.Launcher=null;BootSequence b;var m=Machine(out b);Throws<NullReferenceException>(()=>m.Step());Need(BootEffects.Calls.Last()=="resolve-launcher"&&b.HLLLBLNAABH==null&&!b.PHFHOMMGCGJ,"Cleared before failed service");});
        Case("null gcl propagates",()=>{BootEffects.C2.Gcl=null;BootSequence b;var m=Machine(out b);Throws<NullReferenceException>(()=>m.Step());Need(BootEffects.Calls.Last()=="resolve-gcl"&&!BootEffects.Calls.Contains("platform2"),"No null skip");});
        Case("null first container",()=>{BootEffects.C1=null;BootSequence b;var m=Machine(out b);Throws<NullReferenceException>(()=>m.Step());Need(BootEffects.Calls.Last()=="container1","Before resolve");});
        Case("null second container",()=>{BootEffects.C2=null;BootSequence b;var m=Machine(out b);Throws<NullReferenceException>(()=>m.Step());Need(BootEffects.Calls.Last()=="container2","Before second resolve");});
        Case("null optional timer flag already true",()=>{BootEffects.Timer=null;BootSequence b;var m=Machine(out b);Throws<NullReferenceException>(()=>m.Step());Need(b.LIPOFDEAMPE&&b.KEEBMEBDMMH==2&&BootEffects.Calls.SequenceEqual(new[]{"platform1","process"}),"Store before optional receiver null throw");});
        Case("null unconditional timer skips process when counter nonzero",()=>{BootEffects.Timer=null;BootSequence b;var m=Machine(out b);b.CGCGDEEJADP=2;Throws<NullReferenceException>(()=>m.Step());Need(!b.LIPOFDEAMPE&&BootEffects.Calls.Count==0,"No singleton or timer call");});
        Case("null resumed controller",()=>{BootSequence b;var m=Machine(out b,1);b.HOMDODONEKI=null;Throws<NullReferenceException>(()=>m.Step());Need(m.State==-1&&BootEffects.Calls.Count==0,"No scheduler");});
        Case("controller exception unchanged",()=>{BootSequence b;var m=Machine(out b,1);var old=b.CBFAAHKFJCI;BootEffects.ThrowAt="controller";Throws<ApplicationException>(()=>m.Step(),BootEffects.Failure);Need(Object.ReferenceEquals(old,b.CBFAAHKFJCI)&&BootEffects.Callback==null&&m.State==-1,"No callback/scheduler or store");});
        Case("scheduler exception preserves old disposable",()=>{BootSequence b;var m=Machine(out b,1);var old=b.CBFAAHKFJCI;BootEffects.ThrowAt="scheduler";Throws<ApplicationException>(()=>m.Step(),BootEffects.Failure);Need(Object.ReferenceEquals(old,b.CBFAAHKFJCI)&&b.HOMDODONEKI.Received==0&&m.State==-1,"Store only after success");});
        foreach(var point in Normal){string at=point;Case("state0 exact exception at "+at,()=>{BootSequence b;var m=Machine(out b);var old=m.Current;BootEffects.ThrowAt=at;Throws<ApplicationException>(()=>m.Step(),BootEffects.Failure);int end=Array.IndexOf(Normal,at);Need(BootEffects.Calls.SequenceEqual(Normal.Take(end+1))&&m.State==-1&&Object.ReferenceEquals(old,m.Current),"Exact prefix/state/current and no swallowed exception");Need(!m.Step()&&BootEffects.Calls.Count==end+1,"No automatic retry from minus1");});}
        Need(count==50,"Exactly fifty finite state/ordering/null/exception cases");Console.WriteLine("RESULT fifty_original_boot_MoveNext_controlled_cases_passed; production_code_executed=false");
    }
    static void Inspect(string assembly,string init,string singleton)
    {
        using(var module=ModuleDefinition.ReadModule(assembly))using(var i=ModuleDefinition.ReadModule(init))using(var s=ModuleDefinition.ReadModule(singleton))
        {
            var type=module.GetType("BootSequence").NestedTypes.Single(t=>t.Name=="NEKGMMPKEPF");var method=type.Methods.Single(m=>m.Name=="MoveNext");Need(method.IsPrivate&&method.ReturnType.FullName=="System.Boolean"&&method.Parameters.Count==0&&method.Body.ExceptionHandlers.Count==0,"Exact private projected MoveNext source target/no invented EH");
            var calls=method.Body.Instructions.Where(x=>x.OpCode.Code==Code.Call||x.OpCode.Code==Code.Callvirt||x.OpCode.Code==Code.Newobj).ToArray();var expectedGetter=i.GetType("MPAAIECKLGA").Properties.Single(p=>p.Name=="CFHDLGEGDFD").GetMethod;var singletonGetter=s.Types.Single(t=>t.Name=="SingletonMonoBehaviour`1").Properties.Single(p=>p.Name=="Instance").GetMethod;
            string[] names={singletonGetter.Name,"GetCurrentProcessTimeSinceBoot","OJFIFFKKFLH","OJFIFFKKFLH","OJFIFFKKFLH","OJFIFFKKFLH","OJFIFFKKFLH","get_OLGKJALIAAI","Concat",".ctor","FPNMONCCAAE","IHEKMEOIBOI",expectedGetter.Name,"HHCPOGCCGNF","get_CurrentUnityLauncher",expectedGetter.Name,"HHCPOGCCGNF","IHEKMEOIBOI",singletonGetter.Name,"get_RequiresLoginBeforeInternet","DKODHBLBHDC",".ctor","IHEKMEOIBOI",".ctor","FJNOABDJGMO"};
            Need(calls.Length==25&&calls.Select(x=>((MethodReference)x.Operand).Name).SequenceEqual(names),"Exact25 ordered source/framework/SDK callsites");var refs=calls.Select(x=>(MethodReference)x.Operand).ToArray();Need(refs[0].DeclaringType is GenericInstanceType sg&&sg.GenericArguments.Single().FullName=="PlatformManager"&&refs[18].DeclaringType.FullName==refs[0].DeclaringType.FullName,"Both same singleton specialized accessor declarations");
            Need(refs[12].DeclaringType.FullName=="MPAAIECKLGA"&&refs[15].DeclaringType.FullName=="MPAAIECKLGA"&&expectedGetter.MetadataToken.ToUInt32()==0x0600001eu,"Both exact projected original root getter joins");Need(refs[13] is GenericInstanceMethod a&&a.GenericArguments.Single().FullName=="MCCKDPKLCIN"&&refs[16] is GenericInstanceMethod b&&b.GenericArguments.Single().FullName=="GCLANALOAPO","Exact two original generic resolve targets");Need(refs[14].DeclaringType.FullName=="MCCKDPKLCIN"&&refs[17].DeclaringType.FullName=="GCLANALOAPO"&&refs[21].DeclaringType.FullName=="UnityEngine.WaitForEndOfFrame"&&refs[22].DeclaringType.FullName=="MDEJADHJOEJ"&&refs[22].Parameters.Single().ParameterType.FullName=="System.UInt16"&&refs[23].DeclaringType.FullName=="System.Action`1<System.Single>"&&refs[24].DeclaringType.FullName=="JHIKKDDFDGA","Exact interface/yield/resume/scheduler owners");
            Need(refs[2].DeclaringType.FullName=="OFDHBOEDNCN"&&refs[8].DeclaringType.FullName=="System.String"&&refs[8].Parameters.All(p=>p.ParameterType.FullName=="System.String")&&refs[9].DeclaringType.FullName=="System.Nullable`1<HJDBOADFHMC>"&&refs[10].DeclaringType.FullName=="PNAABCMOHGM"&&refs[11].DeclaringType.FullName=="NDFLHBFOIGB","Exact timer/logger/network bindings");
            var ins=method.Body.Instructions;var flag=ins.Single(x=>x.OpCode.Code==Code.Stfld&&((FieldReference)x.Operand).Name=="LIPOFDEAMPE");var timer=ins.Last(x=>x.Offset<flag.Offset&&x.OpCode.Code==Code.Ldfld&&((FieldReference)x.Operand).Name=="AIDHPHJKAMP");Need(timer.Offset<flag.Offset&&flag.Offset<calls[2].Offset&&!ins.Any(x=>x.Offset>flag.Offset&&x.Offset<calls[2].Offset&&x.OpCode.Code==Code.Ldfld&&((FieldReference)x.Operand).Name=="AIDHPHJKAMP"),"Original timer receiver captured before flag store and not reread before optional call");Need(ins.Count(x=>x.OpCode.Code==Code.Ldftn)==1&&((MethodReference)ins.Single(x=>x.OpCode.Code==Code.Ldftn).Operand).Name=="HKBJKPPPCPM","Exact original callback only, no added lambda");
            var writes=ins.Where(x=>x.OpCode.Code==Code.Stfld).Select(x=>((FieldReference)x.Operand).Name).ToArray();Need(writes.SequenceEqual(new[]{"_003C_003E1__state","KEEBMEBDMMH","LIPOFDEAMPE","HLLLBLNAABH","PHFHOMMGCGJ","_003C_003E2__current","_003C_003E1__state","_003C_003E1__state","CBFAAHKFJCI"}),"All original state/object writes in exact source order");Console.WriteLine("RESULT actual_full_source_boot_MoveNext_original_call_bindings_and_receiver_capture_passed; metadata_only=true");
        }
    }
    public static int Main(string[] args){try{if(args.Length==4&&args[0]=="inspect")Inspect(args[1],args[2],args[3]);else{Need(args.Length==1&&args[0]=="effects","Exact test mode");Effects();}return 0;}catch(Exception e){Console.Error.WriteLine(e);return 1;}}
}
