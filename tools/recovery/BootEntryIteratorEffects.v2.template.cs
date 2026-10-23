// Recording contexts only. Production full-source bindings are checked separately.
using System;using System.Linq;using System.Collections;using System.Collections.Generic;using Mono.Cecil;using Mono.Cecil.Cil;
static class BootEntryEffects
{
    internal static readonly List<string> Calls=new List<string>();internal static readonly Exception Failure=new ApplicationException("controlled boundary");internal static string ThrowAt;internal static Action<string> OnCall;internal static Action OnFlag;
    internal static void Hit(string s){Calls.Add(s);if(ThrowAt==s)throw Failure;OnCall?.Invoke(s);}
    internal static void Reset(){Calls.Clear();ThrowAt=null;OnCall=null;OnFlag=null;}
}
sealed class OFDHBOEDNCN
{
    internal readonly string Name;internal OFDHBOEDNCN(string n){Name=n;}
    internal void FHBILIJBOGI(string key){BootEntryEffects.Hit("start:"+Name+":"+key);}
    internal void NOMPIEABHOP(string key){BootEntryEffects.Hit("stop:"+Name+":"+key);}
}
class OOMEAMBGFPG{internal string Name;internal void CDJHKCNAIKI(){BootEntryEffects.Hit("tick:"+Name);}}
sealed class MDEJADHJOEJ:OOMEAMBGFPG{internal MDEJADHJOEJ(string n){Name=n;}}
sealed class BootSequence
{
    internal sealed class NJIJPADHPEC{internal string Name;public override bool Equals(object v){throw new Exception("ordinary reference equality must not call Equals");}public override int GetHashCode(){return base.GetHashCode();}}
    enum INFFBPOJOIJ{POST_LOGIN_RECNET_OPERATIONS=3}
    internal OFDHBOEDNCN AIDHPHJKAMP;internal bool LIPOFDEAMPE;internal NJIJPADHPEC OHDIFKONNPP;internal MDEJADHJOEJ HOMDODONEKI,DFECAIFGNCA;bool flag;
    // Test-only observer makes the original field-store boundary observable.
    internal bool IHCDBPMANNH{get{return flag;}set{flag=value;BootEntryEffects.OnFlag?.Invoke();}}
    INFFBPOJOIJ GAKFIBCGHNA{set{BootEntryEffects.Hit("state:"+(int)value);}}
    internal sealed class NEKGMMPKEPF:IEnumerator<object>
    {
        internal int _003C_003E1__state;internal object _003C_003E2__current;internal BootSequence _003C_003E4__this;
        object IEnumerator<object>.Current{get{/*EXACT_GENERIC_CURRENT*/}}
        object IEnumerator.Current{get{/*EXACT_CURRENT*/}}
        /*EXACT_ITERATOR_CTOR*/
        /*EXACT_RETAINED_DISPOSE*/
        bool IEnumerator.MoveNext(){throw new InvalidOperationException("held original MoveNext is not executed by these effects");}
        /*EXACT_RESET*/
    }
    /*EXACT_START*/
    /*EXACT_BEGIN*/
    /*EXACT_END*/
    /*EXACT_LAUNCH*/
    /*EXACT_HKB*/
    internal IEnumerator NewStart(){return Start();}internal void Tick(float value){HKBJKPPPCPM(value);}
}
static class Program
{
    const string Wait="(Waiting for Rec Room)",Boot="(Boot Start To User Interaction)",Process="(Process Start To User Interaction)";static int count;
    static void Need(bool v,string m){if(!v)throw new InvalidOperationException(m);}
    static void Case(string n,Action a){BootEntryEffects.Reset();a();count++;Console.WriteLine("PASS "+n);}
    static void Order(params string[] n){Need(BootEntryEffects.Calls.SequenceEqual(n),"ordered calls: "+String.Join(",",BootEntryEffects.Calls));}
    static bool Throws<T>(Action a,Exception expected=null)where T:Exception{try{a();return false;}catch(Exception e){return e.GetType()==typeof(T)&&(expected==null||ReferenceEquals(e,expected));}}
    static BootSequence New(){return new BootSequence{AIDHPHJKAMP=new OFDHBOEDNCN("A"),HOMDODONEKI=new MDEJADHJOEJ("H"),DFECAIFGNCA=new MDEJADHJOEJ("D")};}
    static void Login(BootSequence b,bool begin){if(begin)b.BeginPlatformLogin();else b.EndPlatformLogin();}
    static string Prefix(bool begin){return begin?"start:":"stop:";}
    static void Effects()
    {
        Case("Start returns original nested interface iterator state0 with same Boot owner",()=>{var b=New();var it=(BootSequence.NEKGMMPKEPF)b.NewStart();Need(it._003C_003E1__state==0&&it._003C_003E2__current==null&&ReferenceEquals(it._003C_003E4__this,b),"state/current/owner");Order();});
        Case("Start creates independent original iterator objects",()=>{var b=New();var a=b.NewStart();var c=b.NewStart();Need(!ReferenceEquals(a,c),"independent iterator allocations");Order();});
        Case("state ctor retains signed states and ordinary default references",()=>{foreach(int n in new[]{Int32.MinValue,-1,0,1,Int32.MaxValue}){var it=new BootSequence.NEKGMMPKEPF(n);Need(it._003C_003E1__state==n&&it._003C_003E2__current==null&&it._003C_003E4__this==null,"same int/defaults");}Order();});
        Case("both Current interfaces return same reference or raw null without state change",()=>{var b=New();var it=new BootSequence.NEKGMMPKEPF(91){_003C_003E4__this=b};var item=new object();foreach(object o in new[]{null,item}){it._003C_003E2__current=o;Need(ReferenceEquals(((IEnumerator<object>)it).Current,o)&&ReferenceEquals(((IEnumerator)it).Current,o)&&it._003C_003E1__state==91&&ReferenceEquals(it._003C_003E4__this,b),"same returned reference/state/owner");}Order();});
        Case("Current getters read fresh current field for every invocation",()=>{var it=new BootSequence.NEKGMMPKEPF(2);object a=new object(),b=new object();it._003C_003E2__current=a;Need(ReferenceEquals(((IEnumerator<object>)it).Current,a),"generic fresh1");it._003C_003E2__current=b;Need(ReferenceEquals(((IEnumerator)it).Current,b),"nongeneric fresh2");Order();});
        Case("already-correct retained Dispose leaves all iterator fields unchanged",()=>{var b=New();var item=new object();var it=new BootSequence.NEKGMMPKEPF(12){_003C_003E2__current=item,_003C_003E4__this=b};((IDisposable)it).Dispose();Need(it._003C_003E1__state==12&&ReferenceEquals(it._003C_003E2__current,item)&&ReferenceEquals(it._003C_003E4__this,b),"untouched retained Dispose");Order();});
        Case("Reset throws exact NotSupportedException and leaves iterator fields unchanged",()=>{var b=New();var item=new object();var it=new BootSequence.NEKGMMPKEPF(12){_003C_003E2__current=item,_003C_003E4__this=b};Need(Throws<NotSupportedException>(()=>((IEnumerator)it).Reset()),"exact original exception type");Need(it._003C_003E1__state==12&&ReferenceEquals(it._003C_003E2__current,item)&&ReferenceEquals(it._003C_003E4__this,b),"Reset does not mutate fields");Order();});
        Case("Reset constructs a new exception for each invocation",()=>{var it=new BootSequence.NEKGMMPKEPF(0);Exception a=null,b=null;try{((IEnumerator)it).Reset();}catch(NotSupportedException e){a=e;}try{((IEnumerator)it).Reset();}catch(NotSupportedException e){b=e;}Need(a!=null&&b!=null&&!ReferenceEquals(a,b),"new original exception every call");Order();});
        foreach(bool begin in new[]{true,false})
        {
            bool mode=begin;string p=Prefix(mode);
            Case("login flag and two ordered timers; no process flag "+mode,()=>{var b=New();b.IHCDBPMANNH=!mode;Login(b,mode);Need(b.IHCDBPMANNH==mode,"original flag");Order(p+"A:"+Wait,p+"A:"+Boot);});
            Case("login process flag adds exact third timer "+mode,()=>{var b=New();b.LIPOFDEAMPE=true;Login(b,mode);Need(b.IHCDBPMANNH==mode,"original flag");Order(p+"A:"+Wait,p+"A:"+Boot,p+"A:"+Process);});
            Case("null first timer throws after flag write "+mode,()=>{var b=New();b.AIDHPHJKAMP=null;b.IHCDBPMANNH=!mode;Need(Throws<NullReferenceException>(()=>Login(b,mode)),"raw null receiver");Need(b.IHCDBPMANNH==mode,"flag written before null failure");Order();});
            Case("first receiver captured before flag store, second freshly loaded "+mode,()=>{var b=New();BootEntryEffects.OnFlag=()=>b.AIDHPHJKAMP=new OFDHBOEDNCN("B");Login(b,mode);Order(p+"A:"+Wait,p+"B:"+Boot);});
            Case("second receiver observes first callee replacement "+mode,()=>{var b=New();BootEntryEffects.OnCall=s=>{if(s==p+"A:"+Wait)b.AIDHPHJKAMP=new OFDHBOEDNCN("B");};Login(b,mode);Order(p+"A:"+Wait,p+"B:"+Boot);});
            Case("second receiver null after first callee throws at fresh read "+mode,()=>{var b=New();BootEntryEffects.OnCall=s=>{if(s==p+"A:"+Wait)b.AIDHPHJKAMP=null;};Need(Throws<NullReferenceException>(()=>Login(b,mode)),"fresh second receiver null");Order(p+"A:"+Wait);});
            Case("conditional flag is freshly read after second call "+mode,()=>{var b=New();BootEntryEffects.OnCall=s=>{if(s==p+"A:"+Boot)b.LIPOFDEAMPE=true;};Login(b,mode);Order(p+"A:"+Wait,p+"A:"+Boot,p+"A:"+Process);});
            Case("fresh conditional false suppresses initially enabled third call "+mode,()=>{var b=New();b.LIPOFDEAMPE=true;BootEntryEffects.OnCall=s=>{if(s==p+"A:"+Boot)b.LIPOFDEAMPE=false;};Login(b,mode);Order(p+"A:"+Wait,p+"A:"+Boot);});
            Case("third receiver freshly loaded after second call "+mode,()=>{var b=New();b.LIPOFDEAMPE=true;BootEntryEffects.OnCall=s=>{if(s==p+"A:"+Boot)b.AIDHPHJKAMP=new OFDHBOEDNCN("C");};Login(b,mode);Order(p+"A:"+Wait,p+"A:"+Boot,p+"C:"+Process);});
            Case("null third receiver fails only after first two calls "+mode,()=>{var b=New();b.LIPOFDEAMPE=true;BootEntryEffects.OnCall=s=>{if(s==p+"A:"+Boot)b.AIDHPHJKAMP=null;};Need(Throws<NullReferenceException>(()=>Login(b,mode)),"fresh third raw null");Order(p+"A:"+Wait,p+"A:"+Boot);});
            foreach(string stop in new[]{Wait,Boot,Process})
            {
                string at=stop;
                Case("callee exception identity/order suppresses all later timers "+mode+at,()=>{var b=New();b.LIPOFDEAMPE=true;BootEntryEffects.ThrowAt=p+"A:"+at;Need(Throws<ApplicationException>(()=>Login(b,mode),BootEntryEffects.Failure),"exact callee exception");var all=new[]{p+"A:"+Wait,p+"A:"+Boot,p+"A:"+Process};Order(all.Take(Array.IndexOf(new[]{Wait,Boot,Process},at)+1).ToArray());Need(b.IHCDBPMANNH==mode,"flag survives callee failure");});
            }
        }
        Case("LaunchGame raw-null argument preserves prior target then timer and state3",()=>{var b=New();var old=new BootSequence.NJIJPADHPEC();b.OHDIFKONNPP=old;b.LaunchGame(null);Need(ReferenceEquals(b.OHDIFKONNPP,old),"old target retained");Order("stop:A:"+Wait,"state:3");});
        Case("LaunchGame nonnull argument stored before first timer call",()=>{var b=New();var arg=new BootSequence.NJIJPADHPEC();BootEntryEffects.OnCall=s=>{if(s=="stop:A:"+Wait)Need(ReferenceEquals(b.OHDIFKONNPP,arg),"original target already stored");};b.LaunchGame(arg);Order("stop:A:"+Wait,"state:3");});
        Case("LaunchGame null timer leaves prior successful target store and no state",()=>{var b=New();b.AIDHPHJKAMP=null;var arg=new BootSequence.NJIJPADHPEC();Need(Throws<NullReferenceException>(()=>b.LaunchGame(arg)),"null timer");Need(ReferenceEquals(b.OHDIFKONNPP,arg),"store retained");Order();});
        Case("LaunchGame timer exception propagated before state transition",()=>{var b=New();BootEntryEffects.ThrowAt="stop:A:"+Wait;Need(Throws<ApplicationException>(()=>b.LaunchGame(null),BootEntryEffects.Failure),"same timer failure");Order("stop:A:"+Wait);});
        Case("LaunchGame state exception propagated after completed timer",()=>{var b=New();var arg=new BootSequence.NJIJPADHPEC();BootEntryEffects.ThrowAt="state:3";Need(Throws<ApplicationException>(()=>b.LaunchGame(arg),BootEntryEffects.Failure),"same state failure");Need(ReferenceEquals(b.OHDIFKONNPP,arg),"target survives");Order("stop:A:"+Wait,"state:3");});
        Case("LaunchGame does not overwrite target again after timer mutation",()=>{var b=New();var arg=new BootSequence.NJIJPADHPEC();var other=new BootSequence.NJIJPADHPEC();BootEntryEffects.OnCall=s=>{if(s=="stop:A:"+Wait)b.OHDIFKONNPP=other;};b.LaunchGame(arg);Need(ReferenceEquals(b.OHDIFKONNPP,other),"no late duplicate store");Order("stop:A:"+Wait,"state:3");});
        Case("HKB calls original controllers in order and ignores NaN float argument",()=>{New().Tick(Single.NaN);Order("tick:H","tick:D");});
        Case("HKB null first controller suppresses second call",()=>{var b=New();b.HOMDODONEKI=null;Need(Throws<NullReferenceException>(()=>b.Tick(1)),"first raw null");Order();});
        Case("HKB null second controller fails after completed first call",()=>{var b=New();b.DFECAIFGNCA=null;Need(Throws<NullReferenceException>(()=>b.Tick(-99)),"second raw null");Order("tick:H");});
        Case("HKB first callee exception suppresses later field read/call",()=>{var b=New();BootEntryEffects.ThrowAt="tick:H";Need(Throws<ApplicationException>(()=>b.Tick(0),BootEntryEffects.Failure),"same first exception");Order("tick:H");});
        Case("HKB second callee exception preserves first completed call",()=>{var b=New();BootEntryEffects.ThrowAt="tick:D";Need(Throws<ApplicationException>(()=>b.Tick(0),BootEntryEffects.Failure),"same second exception");Order("tick:H","tick:D");});
        Case("HKB second controller is fresh field read after first callback",()=>{var b=New();BootEntryEffects.OnCall=s=>{if(s=="tick:H")b.DFECAIFGNCA=new MDEJADHJOEJ("X");};b.Tick(0);Order("tick:H","tick:X");});
        Case("HKB same controller in both fields is called twice",()=>{var b=New();b.DFECAIFGNCA=b.HOMDODONEKI;b.Tick(0);Order("tick:H","tick:H");});
        Need(count==47,"exact47 distinct boundary/effect cases");Console.WriteLine("RESULT nine_Boot_entry_iterator_bindings_and47_controlled_effects_scope; production_game_network_executed=false");
    }
    static string Sig(MethodReference m){return m.ReturnType.FullName+"("+String.Join(",",m.Parameters.Select(p=>p.ParameterType.FullName))+")";}
    static Instruction[] Calls(MethodDefinition m){return m.Body.Instructions.Where(i=>i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Callvirt||i.OpCode.Code==Code.Newobj).ToArray();}
    static string[] Reads(MethodDefinition m){return m.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldfld).Select(i=>((FieldReference)i.Operand).Name).ToArray();}
    static string[] Writes(MethodDefinition m){return m.Body.Instructions.Where(i=>i.OpCode.Code==Code.Stfld).Select(i=>((FieldReference)i.Operand).Name).ToArray();}
    static void Call(Instruction i,string owner,string name,string sig,Code code){var m=(MethodReference)i.Operand;Need(i.OpCode.Code==code&&m.DeclaringType.FullName==owner&&m.Name==name&&Sig(m)==sig,"exact call "+owner+"::"+name+" "+Sig(m));}
    static void Inspect(string path,string originalPath)
    {
        var o=new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false};using(var m=ModuleDefinition.ReadModule(path,o))using(var raw=ModuleDefinition.ReadModule(originalPath,o))
        {
            Need(m.Assembly.Name.Name=="Assembly-CSharp"&&raw.Assembly.Name.Name=="Assembly-CSharp","actual compiled Core and genuine metadata provider");var boot=m.Types.Single(t=>t.FullName=="BootSequence");var original=raw.Types.Single(t=>t.FullName=="BootSequence");var iterator=boot.NestedTypes.Single(t=>t.Name=="NEKGMMPKEPF");var rawIterator=original.NestedTypes.Single(t=>t.Name=="NEKGMMPKEPF");
            var tokens=new uint[]{0x060014a8,0x060014aa,0x060014ab,0x060014bd,0x060014d8,0x060014f8,0x060014fb,0x060014fc,0x060014fd};var selected=new List<MethodDefinition>();
            foreach(uint token in tokens){var a=(MethodDefinition)raw.LookupToken((int)token);var owner=a.DeclaringType.FullName=="BootSequence"?boot:iterator;Need(a.DeclaringType.FullName==owner.FullName,"exact original owner");var b=owner.Methods.Single(x=>x.Name==a.Name&&Sig(x)==Sig(a));Need(a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&!b.IsStatic&&b.HasBody&&!b.Body.ExceptionHandlers.Any(),"original method attributes/signature/body/no EH "+a.FullName);selected.Add(b);}
            var start=selected.Single(x=>x.Name=="Start");var calls=Calls(start);Need(calls.Length==1,"only original iterator allocation/ctor");Call(calls[0],"BootSequence/NEKGMMPKEPF",".ctor","System.Void(System.Int32)",Code.Newobj);Need(calls[0].Previous.OpCode.Code==Code.Ldc_I4_0&&Writes(start).SequenceEqual(new[]{"_003C_003E4__this"})&&Reads(start).Length==0,"Start state0 and one same-this owner store");var store=start.Body.Instructions.Single(i=>i.OpCode.Code==Code.Stfld);Need(store.Previous.OpCode.Code==Code.Ldarg_0&&((FieldReference)store.Operand).FieldType.FullName=="BootSequence","exact same original this capture");
            var ctor=selected.Single(x=>x.IsConstructor);calls=Calls(ctor);Need(calls.Length==1,"only Object base constructor");Call(calls[0],"System.Object",".ctor","System.Void()",Code.Call);Need(Writes(ctor).SequenceEqual(new[]{"_003C_003E1__state"})&&Reads(ctor).Length==0,"only original state field assigned");var sw=ctor.Body.Instructions.Single(i=>i.OpCode.Code==Code.Stfld);Need(sw.Previous.OpCode.Code==Code.Ldarg_1&&ctor.Body.Instructions.IndexOf(calls[0])<ctor.Body.Instructions.IndexOf(sw)&&((FieldReference)sw.Operand).FieldType.FullName=="System.Int32","state argument stored after Object base");
            foreach(bool begin in new[]{true,false})
            {
                var f=selected.Single(x=>x.Name==(begin?"BeginPlatformLogin":"EndPlatformLogin"));calls=Calls(f);Need(calls.Length==3,"three original timer calls");foreach(var c in calls)Call(c,"OFDHBOEDNCN",begin?"FHBILIJBOGI":"NOMPIEABHOP","System.Void(System.String)",Code.Callvirt);Need(Reads(f).SequenceEqual(new[]{"AIDHPHJKAMP","AIDHPHJKAMP","LIPOFDEAMPE","AIDHPHJKAMP"})&&Writes(f).SequenceEqual(new[]{"IHCDBPMANNH"}),"exact first/fresh timer and conditional field reads/one flag write");Need(f.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldstr).Select(i=>(string)i.Operand).SequenceEqual(new[]{Wait,Boot,Process}),"exact ordered native strings");var flag=f.Body.Instructions.Single(i=>i.OpCode.Code==Code.Stfld);var first=f.Body.Instructions.First(i=>i.OpCode.Code==Code.Ldfld);Need(flag.Previous.OpCode.Code==(begin?Code.Ldc_I4_1:Code.Ldc_I4_0)&&f.Body.Instructions.IndexOf(first)<f.Body.Instructions.IndexOf(flag)&&f.Body.Instructions.IndexOf(flag)<f.Body.Instructions.IndexOf(calls[0]),"captured first timer before flag, flag before call/null failure");var conditional=f.Body.Instructions.Single(i=>i.OpCode.Code==Code.Ldfld&&((FieldReference)i.Operand).Name=="LIPOFDEAMPE");var thirdReceiver=f.Body.Instructions.Last(i=>i.OpCode.Code==Code.Ldfld);var prefix=f.Body.Instructions.Skip(f.Body.Instructions.IndexOf(conditional)+1).Take(f.Body.Instructions.IndexOf(thirdReceiver)-f.Body.Instructions.IndexOf(conditional)-1).ToArray();var branches=prefix.Where(i=>i.OpCode.FlowControl==FlowControl.Cond_Branch).ToArray();Need(branches.Length==1&&(branches[0].OpCode.Code==Code.Brfalse||branches[0].OpCode.Code==Code.Brfalse_S)&&f.Body.Instructions.IndexOf((Instruction)branches[0].Operand)>f.Body.Instructions.IndexOf(calls[2])&&prefix.All(i=>i.OpCode.Code==Code.Nop||i.OpCode.Code==Code.Ldarg_0||i.OpCode.Code.ToString().StartsWith("Ldloc",StringComparison.Ordinal)||i.OpCode.Code.ToString().StartsWith("Stloc",StringComparison.Ordinal)||i==branches[0]),"fresh bool field with only compiler-local copies then false branch skips complete third timer call");
            }
            var launch=selected.Single(x=>x.Name=="LaunchGame");calls=Calls(launch);Need(calls.Length==2,"no raw-reference comparison helper/operator calls");Call(calls[0],"OFDHBOEDNCN","NOMPIEABHOP","System.Void(System.String)",Code.Callvirt);var originalSetter=(MethodDefinition)raw.LookupToken(0x06001497);var originalProperty=original.Properties.Single(p=>p.SetMethod==originalSetter);var actualProperty=boot.Properties.Single(p=>p.Name==originalProperty.Name);Need(originalSetter.Name=="BCOIAODGNGB"&&originalSetter.IsSetter&&originalSetter.IsSpecialName&&originalProperty.Name=="GAKFIBCGHNA"&&originalProperty.MetadataToken.ToUInt32()==0x1700038c&&originalProperty.PropertyType.FullName=="BootSequence/INFFBPOJOIJ"&&actualProperty.PropertyType.FullName==originalProperty.PropertyType.FullName&&actualProperty.SetMethod.IsPrivate,"exact original native accessor association and existing source property");Call(calls[1],"BootSequence",actualProperty.SetMethod.Name,"System.Void(BootSequence/INFFBPOJOIJ)",Code.Call);Need(calls[1].Previous.OpCode.Code==Code.Ldc_I4_3&&Reads(launch).SequenceEqual(new[]{"AIDHPHJKAMP"})&&Writes(launch).SequenceEqual(new[]{"OHDIFKONNPP"}),"exact timer read, one target store, state3 argument");var ls=launch.Body.Instructions.Single(i=>i.OpCode.Code==Code.Stfld);Need(ls.Previous.OpCode.Code==Code.Ldarg_1&&launch.Body.Instructions.IndexOf(ls)<launch.Body.Instructions.IndexOf(calls[0])&&launch.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldstr).Select(i=>(string)i.Operand).SequenceEqual(new[]{Wait}),"same input target stored before exact waiting timer");Need(launch.Body.Instructions.Any(i=>i.OpCode.FlowControl==FlowControl.Cond_Branch),"raw ordinary reference null branch exists");
            foreach(var current in selected.Where(x=>x.Name.EndsWith("get_Current",StringComparison.Ordinal))){Need(Calls(current).Length==0&&Reads(current).SequenceEqual(new[]{"_003C_003E2__current"})&&Writes(current).Length==0&&current.ReturnType.FullName=="System.Object"&&current.Body.Instructions.Any(i=>i.OpCode.Code==Code.Ret),"same raw current field, no operator/callee/mutation");}
            var reset=selected.Single(x=>x.Name.EndsWith(".Reset",StringComparison.Ordinal));calls=Calls(reset);Need(calls.Length==1,"Reset only allocates exact exception");Call(calls[0],"System.NotSupportedException",".ctor","System.Void()",Code.Newobj);Need(calls[0].Next.OpCode.Code==Code.Throw&&Reads(reset).Length==0&&Writes(reset).Length==0,"throws newly allocated same exception without field mutations");
            var tick=selected.Single(x=>x.Name=="HKBJKPPPCPM");calls=Calls(tick);Need(calls.Length==2,"exact two state method calls");foreach(var c in calls)Call(c,"OOMEAMBGFPG","CDJHKCNAIKI","System.Void()",Code.Callvirt);Need(Reads(tick).SequenceEqual(new[]{"HOMDODONEKI","DFECAIFGNCA"})&&Writes(tick).Length==0&&!tick.Body.Instructions.Any(i=>i.OpCode.Code==Code.Ldarg_1),"ordered fresh controller fields and unused input float");Need(tick.Body.Instructions.IndexOf(calls[0])<tick.Body.Instructions.IndexOf(tick.Body.Instructions.Last(i=>i.OpCode.Code==Code.Ldfld)),"second controller loaded only after first call");
            var dispose=iterator.Methods.Single(x=>x.Name=="System.IDisposable.Dispose");Need(Calls(dispose).Length==0&&Reads(dispose).Length==0&&Writes(dispose).Length==0&&dispose.Body.Instructions.All(i=>i.OpCode.Code==Code.Nop||i.OpCode.Code==Code.Ret),"retained Dispose already matches original empty behavior");Console.WriteLine("RESULT actual_full_source_nine_original_Boot_entry_iterator_bindings_passed; metadata_only=true");
        }
    }
    public static int Main(string[] args){try{if(args.Length==3&&args[0]=="inspect")Inspect(args[1],args[2]);else{Need(args.Length==1&&args[0]=="effects","exact helper arguments");Effects();}return 0;}catch(Exception e){Console.Error.WriteLine(e);return 1;}}
}
