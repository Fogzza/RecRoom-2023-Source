// Explicit test-only boundaries; production SDK/provider/graph bodies never run.
// All8 selected candidate bodies are separate, unchanged source inputs.
using System;using System.Collections;using System.Collections.Generic;
static class PreparationState
{
    internal static readonly List<string> Calls=new List<string>();
    internal static string ThrowAt;internal static bool Cycle;internal static Action OnCycle,OnInject;
    internal static Func<IEnumerable<OENEDGPIOFN.NPDGPDKAHLN>> Roots;
    internal static Func<IEnumerable<OENEDGPIOFN.NPDGPDKAHLN>,List<OENEDGPIOFN.NPDGPDKAHLN>> Sort;
    internal static void Hit(string value){Calls.Add(value);if(ThrowAt==value)throw new ApplicationException(value);}
    internal static void Reset(){Calls.Clear();ThrowAt=null;Cycle=false;OnCycle=OnInject=null;Roots=null;Sort=null;OENEDGPIOFN.SortedClosureAlias.CachedSelector=null;MNALHHOLFGL.ResolveClosureAlias.CachedSelector=null;}
}
public interface DCDAPNDPFMI{void IHEKMEOIBOI(MNALHHOLFGL container);}
public interface NJAICAFMPBE:DCDAPNDPFMI{object AIKLEKDPIFH();bool DHABENNNOIJ();}
public interface CKAJONGONMK{NJAICAFMPBE IBOAFOPAJKI();}
public struct CPAMAFPANDM:IComparable<CPAMAFPANDM>
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;}
    /*EXACT_TESTED_KEY_MEMBERS*/
    public int CompareTo(CPAMAFPANDM other){throw new NotImplementedException("Held original ordering");}
    public override string ToString(){PreparationState.Hit("key-format");return FEKLPCPODAH;}
}
public partial class OENEDGPIOFN
{
    private List<CPAMAFPANDM> OMMELJLAGLB;
    public class NPDGPDKAHLN{public readonly CPAMAFPANDM HDPNFBMCAHN;public NPDGPDKAHLN(CPAMAFPANDM key){HDPNFBMCAHN=key;}}
    private IEnumerable<NPDGPDKAHLN> IEPIDJGAOIN(){PreparationState.Hit("roots");return PreparationState.Roots();}
    private static List<NPDGPDKAHLN> LAEKFDEFKFK(IEnumerable<NPDGPDKAHLN> source){PreparationState.Hit("toposort");return PreparationState.Sort(source);}
    public bool HCILKBKIKOG(out string cycle){PreparationState.Hit("cycle");PreparationState.OnCycle?.Invoke();cycle="controlled-cycle";return PreparationState.Cycle;}
    internal void Cache(List<CPAMAFPANDM> list){OMMELJLAGLB=list;}
    internal List<CPAMAFPANDM> ReadCache(){return OMMELJLAGLB;}
}
public partial class MNALHHOLFGL
{
    private readonly Dictionary<CPAMAFPANDM,NJAICAFMPBE> AAHKPPMHGFI;
    private readonly Dictionary<CPAMAFPANDM,CKAJONGONMK> LMAFHCPPMAD;
    private readonly OENEDGPIOFN OLGLBMGAHBO;
    private PFCPCBJDEMB MGADLDPDPGK;
    private enum PFCPCBJDEMB:byte{Bind=0,Resolved=1}
    internal readonly List<object> Injected=new List<object>();
    internal MNALHHOLFGL(OENEDGPIOFN graph,Dictionary<CPAMAFPANDM,NJAICAFMPBE> resolved=null){OLGLBMGAHBO=graph;AAHKPPMHGFI=resolved??new TrackingDictionary<CPAMAFPANDM,NJAICAFMPBE>();LMAFHCPPMAD=new Dictionary<CPAMAFPANDM,CKAJONGONMK>();}
    internal void FIKOCEOODPI(object instance,Nullable<CPAMAFPANDM> key){PreparationState.Hit("inject-value");if(!key.HasValue)throw new Exception("original nonnull key");Injected.Add(instance);PreparationState.OnInject?.Invoke();}
    internal void Factory(CPAMAFPANDM key,CKAJONGONMK factory){LMAFHCPPMAD[key]=factory;}
    internal void Resolved(CPAMAFPANDM key,NJAICAFMPBE provider){AAHKPPMHGFI[key]=provider;}
    internal NJAICAFMPBE Read(CPAMAFPANDM key){NJAICAFMPBE value;AAHKPPMHGFI.TryGetValue(key,out value);return value;}
    internal bool Has(CPAMAFPANDM key){return AAHKPPMHGFI.ContainsKey(key);}
    internal byte ReadState(){return(byte)MGADLDPDPGK;}
    internal void State(byte value){MGADLDPDPGK=(PFCPCBJDEMB)value;}
}
sealed class TestProvider:NJAICAFMPBE
{
    internal readonly string Name;internal object Value=new object();internal bool Dead;internal MNALHHOLFGL SeenContainer;
    internal TestProvider(string name){Name=name;}
    public object AIKLEKDPIFH(){PreparationState.Hit(Name+".value");return Value;}
    public bool DHABENNNOIJ(){PreparationState.Hit(Name+".dead");return Dead;}
    public void IHEKMEOIBOI(MNALHHOLFGL container){PreparationState.Hit(Name+".resolve");SeenContainer=container;}
}
sealed class TestFactory:CKAJONGONMK
{
    internal NJAICAFMPBE Value;internal TestFactory(NJAICAFMPBE value){Value=value;}
    public NJAICAFMPBE IBOAFOPAJKI(){PreparationState.Hit("factory");return Value;}
}
sealed class TrackingEnumerator<T>:IEnumerator<T>
{
    readonly IEnumerator<T> inner;readonly string name;
    internal TrackingEnumerator(IEnumerator<T> iterator,string label){inner=iterator;name=label;}
    public T Current{get{PreparationState.Hit(name+".current");return inner.Current;}}
    object IEnumerator.Current{get{return Current;}}
    public bool MoveNext(){PreparationState.Hit(name+".move");return inner.MoveNext();}
    public void Reset(){throw new NotSupportedException();}
    public void Dispose(){PreparationState.Hit(name+".dispose");inner.Dispose();}
}
sealed class TrackingList<T>:List<T>,IEnumerable<T>
{
    IEnumerator<T> IEnumerable<T>.GetEnumerator(){PreparationState.Hit("keys.get");return new TrackingEnumerator<T>(base.GetEnumerator(),"keys");}
    IEnumerator IEnumerable.GetEnumerator(){return((IEnumerable<T>)this).GetEnumerator();}
}
sealed class TrackingDictionary<K,V>:Dictionary<K,V>,IEnumerable<KeyValuePair<K,V>>
{
    IEnumerator<KeyValuePair<K,V>> IEnumerable<KeyValuePair<K,V>>.GetEnumerator(){PreparationState.Hit("values.get");return new TrackingEnumerator<KeyValuePair<K,V>>(base.GetEnumerator(),"values");}
    IEnumerator IEnumerable.GetEnumerator(){return((IEnumerable<KeyValuePair<K,V>>)this).GetEnumerator();}
}
static class ContainerPreparationEffects
{
    static int cases;static void Need(bool v,string m){if(!v)throw new InvalidOperationException(m);}
    static void Case(string name,Action body){PreparationState.Reset();body();cases++;Console.WriteLine("PASS "+name);}
    static bool Same(object a,object b){return Object.ReferenceEquals(a,b);}
    static CPAMAFPANDM Key(string name="k"){return new CPAMAFPANDM(typeof(object),name);}
    static OENEDGPIOFN Graph(params CPAMAFPANDM[] keys){var graph=new OENEDGPIOFN();var list=new TrackingList<CPAMAFPANDM>();list.AddRange(keys);graph.Cache(list);return graph;}
    static bool Has(string s){return PreparationState.Calls.Contains(s);}
    static int At(string s){return PreparationState.Calls.IndexOf(s);}
    static int Count(string s){return PreparationState.Calls.FindAll(x=>x==s).Count;}
    static Exception Catch(Action a){try{a();throw new Exception("expected exception");}catch(Exception e){return e;}}
    static void Error<T>(Action a,string message=null)where T:Exception{var e=Catch(a);Need(e.GetType()==typeof(T)&&(message==null||e.Message==message),"exact exception "+e.GetType()+":"+e.Message);}
    static void No(string s){Need(!Has(s),"no effect "+s);}
    static void Prerequisites()
    {
        Case("both original closure singleton constructors initialize once",()=>{Need(!Same(MNALHHOLFGL.ResolveClosureAlias.Singleton,null)&&!Same(OENEDGPIOFN.SortedClosureAlias.Singleton,null)&&Same(MNALHHOLFGL.ResolveClosureAlias.Singleton,MNALHHOLFGL.ResolveClosureAlias.Singleton),"existing readonly closure instances");});
        Case("original provider selector returns exact reference and null",()=>{var p=new TestProvider("p");Need(Same(MNALHHOLFGL.ResolveClosureAlias.Singleton.SelectProvider(new KeyValuePair<CPAMAFPANDM,NJAICAFMPBE>(Key(),p)),p)&&Same(MNALHHOLFGL.ResolveClosureAlias.Singleton.SelectProvider(new KeyValuePair<CPAMAFPANDM,NJAICAFMPBE>(Key(),null)),null),"only Value");Need(PreparationState.Calls.Count==0,"no provider evaluation or key formatting");});
        Case("node key selector copies exact readonly key",()=>{var key=Key();var result=OENEDGPIOFN.SortedClosureAlias.Singleton.SelectKey(new OENEDGPIOFN.NPDGPDKAHLN(key));Need(Same(result.AFJAGKNNCBE,key.AFJAGKNNCBE)&&Same(result.FEKLPCPODAH,key.FEKLPCPODAH),"two same fields");});
        Case("node key selector preserves null reference failure",()=>Error<NullReferenceException>(()=>OENEDGPIOFN.SortedClosureAlias.Singleton.SelectKey(null)));
        Case("Sorted cache hit returns same object without graph helpers",()=>{var graph=Graph(Key());var list=graph.ReadCache();Need(Same(graph.IJAKDIKAJHP(),list)&&PreparationState.Calls.Count==0,"single capture existing cache");});
        Case("Sorted miss invokes exact helpers then actual Select ToList",()=>{var graph=new OENEDGPIOFN();var nodes=new List<OENEDGPIOFN.NPDGPDKAHLN>{new OENEDGPIOFN.NPDGPDKAHLN(Key("a")),new OENEDGPIOFN.NPDGPDKAHLN(Key("b"))};PreparationState.Roots=()=>nodes;PreparationState.Sort=x=>{Need(Same(x,nodes),"same roots");return nodes;};var result=(List<CPAMAFPANDM>)graph.IJAKDIKAJHP();Need(Same(result,graph.ReadCache())&&result.Count==2&&result[0].FEKLPCPODAH=="a"&&result[1].FEKLPCPODAH=="b"&&At("roots")<At("toposort")&&!Same(OENEDGPIOFN.SortedClosureAlias.CachedSelector,null),"ordered source and memoized projection");});
        Case("Sorted roots failure preserves null cache",()=>{var graph=new OENEDGPIOFN();PreparationState.ThrowAt="roots";Error<ApplicationException>(()=>graph.IJAKDIKAJHP(),"roots");Need(graph.ReadCache()==null,"no list store");No("toposort");});
        Case("Sorted topological helper failure preserves null cache",()=>{var graph=new OENEDGPIOFN();PreparationState.Roots=()=>null;PreparationState.ThrowAt="toposort";Error<ApplicationException>(()=>graph.IJAKDIKAJHP(),"toposort");Need(graph.ReadCache()==null,"no list store");});
        Case("Sorted null topological result preserves genuine LINQ failure",()=>{var graph=new OENEDGPIOFN();PreparationState.Roots=()=>null;PreparationState.Sort=x=>null;Error<ArgumentNullException>(()=>graph.IJAKDIKAJHP());Need(graph.ReadCache()==null,"no cache store on Select error");});
        Case("Sorted null node fails before list assignment",()=>{var graph=new OENEDGPIOFN();PreparationState.Roots=()=>null;PreparationState.Sort=x=>new List<OENEDGPIOFN.NPDGPDKAHLN>{null};Error<NullReferenceException>(()=>graph.IJAKDIKAJHP());Need(graph.ReadCache()==null,"failed selector never publishes partial list");});
        Case("Sorted existing cached delegate is retained and invoked",()=>{var graph=new OENEDGPIOFN();var selector=new Func<OENEDGPIOFN.NPDGPDKAHLN,CPAMAFPANDM>(n=>Key("custom"));OENEDGPIOFN.SortedClosureAlias.CachedSelector=selector;PreparationState.Roots=()=>null;PreparationState.Sort=x=>new List<OENEDGPIOFN.NPDGPDKAHLN>{new OENEDGPIOFN.NPDGPDKAHLN(Key())};var result=(List<CPAMAFPANDM>)graph.IJAKDIKAJHP();Need(result[0].FEKLPCPODAH=="custom"&&Same(selector,OENEDGPIOFN.SortedClosureAlias.CachedSelector),"no replacement delegate");});
        Case("null provider predicate skips interface access",()=>{Need(AGNPJIHDJFG.EJFNLENHABL(null)&&PreparationState.Calls.Count==0,"null short circuit");});
        Case("dead predicate reads original flag exactly once",()=>{var p=new TestProvider("p"){Dead=true};Need(AGNPJIHDJFG.EJFNLENHABL(p)&&Count("p.dead")==1,"dead once");});
        Case("live predicate and assertion avoid all formatting",()=>{var p=new TestProvider("p");Need(!AGNPJIHDJFG.EJFNLENHABL(p),"live false");PreparationState.Calls.Clear();MKECFLEMHEL.LGKIDJCLIAD(p,"{0}",Key());Need(Count("p.dead")==1&&!Has("key-format"),"format not evaluated on live");});
        Case("null assertion formats same key and exact exception",()=>{Error<InvalidOperationException>(()=>MKECFLEMHEL.LGKIDJCLIAD<CPAMAFPANDM>(null,"bad {0}",Key("named")),"bad named");Need(Count("key-format")==1,"only failure formats");});
        Case("dead assertion property failure precedes formatting",()=>{PreparationState.ThrowAt="p.dead";Error<ApplicationException>(()=>MKECFLEMHEL.LGKIDJCLIAD(new TestProvider("p"),"{0}",Key()),"p.dead");No("key-format");});
    }
    static void Lnf()
    {
        Case("state1 and state255 return before any graph access",()=>{var c=new MNALHHOLFGL(null);c.State(1);c.LNFNAIMOFOF();c.State(255);c.LNFNAIMOFOF();Need(PreparationState.Calls.Count==0&&c.ReadState()==255,"byte unsigned early-return");});
        Case("state becomes1 before cycle callback and never resets",()=>{var c=new MNALHHOLFGL(Graph());PreparationState.OnCycle=()=>Need(c.ReadState()==1,"state written before graph");c.LNFNAIMOFOF();Need(c.ReadState()==1,"state remains resolved");});
        Case("cycle failure is exact and prevents enumeration",()=>{var c=new MNALHHOLFGL(Graph(Key()));PreparationState.Cycle=true;Error<InvalidOperationException>(()=>c.LNFNAIMOFOF(),"Cycle detected in dependency tree!");Need(c.ReadState()==1,"failure state retained");No("keys.get");});
        Case("cycle helper exception retains state and original error",()=>{var c=new MNALHHOLFGL(Graph());PreparationState.ThrowAt="cycle";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"cycle");Need(c.ReadState()==1,"no reset");});
        Case("null graph produces ordinary NRE after state write",()=>{var c=new MNALHHOLFGL(null);Error<NullReferenceException>(()=>c.LNFNAIMOFOF());Need(c.ReadState()==1,"state set before null access");});
        Case("empty enumerations both disposed with no provider calls",()=>{var c=new MNALHHOLFGL(Graph());c.LNFNAIMOFOF();Need(Has("keys.dispose")&&Has("values.dispose")&&At("keys.dispose")<At("values.get"),"two genuine enumerator disposal paths");});
        Case("factory missing skips publication and finishes",()=>{var key=Key();var c=new MNALHHOLFGL(Graph(key));c.LNFNAIMOFOF();Need(!c.Has(key)&&c.Injected.Count==0,"no invented provider");No("factory");Need(Has("keys.dispose")&&Has("values.dispose"),"both loops finish");});
        Case("already resolved key skips factory and only resolves live provider",()=>{var key=Key();var p=new TestProvider("p");var c=new MNALHHOLFGL(Graph(key));c.Resolved(key,p);c.Factory(key,new TestFactory(new TestProvider("unused")));c.LNFNAIMOFOF();No("factory");No("p.value");Need(Count("p.dead")==1&&Same(p.SeenContainer,c),"same provider/container final injection");});
        Case("factory result value injection and publication preserve order",()=>{var key=Key();var p=new TestProvider("p");var c=new MNALHHOLFGL(Graph(key));c.Factory(key,new TestFactory(p));PreparationState.OnInject=()=>Need(!c.Has(key),"Add follows FIKO");c.LNFNAIMOFOF();Need(Same(c.Read(key),p)&&Same(c.Injected[0],p.Value)&&At("factory")<At("p.dead")&&At("p.dead")<At("p.value")&&At("p.value")<At("inject-value")&&At("inject-value")<At("keys.dispose")&&At("keys.dispose")<At("p.resolve"),"actual Dictionary and callback ordering");});
        Case("null factory is dereferenced and first enumerator disposed",()=>{var key=Key();var c=new MNALHHOLFGL(Graph(key));c.Factory(key,null);Error<NullReferenceException>(()=>c.LNFNAIMOFOF());Need(Has("keys.dispose")&&!c.Has(key),"cleanup before NRE escapes");No("values.get");});
        Case("factory exception disposes key enumerator and skips publication",()=>{var key=Key();var c=new MNALHHOLFGL(Graph(key));c.Factory(key,new TestFactory(null));PreparationState.ThrowAt="factory";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"factory");Need(Has("keys.dispose")&&!c.Has(key),"first finally");No("values.get");});
        Case("null provider rejected with original called assertion",()=>{var key=Key("null");var c=new MNALHHOLFGL(Graph(key));c.Factory(key,new TestFactory(null));Error<InvalidOperationException>(()=>c.LNFNAIMOFOF(),"Cannot inject into dead resolved instance for key null");Need(Has("keys.dispose")&&!c.Has(key),"null result not stored");No("inject-value");});
        Case("dead provider rejected before value read",()=>{var key=Key("dead");var p=new TestProvider("p"){Dead=true};var c=new MNALHHOLFGL(Graph(key));c.Factory(key,new TestFactory(p));Error<InvalidOperationException>(()=>c.LNFNAIMOFOF(),"Cannot inject into dead resolved instance for key dead");Need(Has("keys.dispose")&&!c.Has(key),"dead not published");No("p.value");});
        Case("provider dead getter failure disposes first enumeration",()=>{var key=Key();var c=new MNALHHOLFGL(Graph(key));c.Factory(key,new TestFactory(new TestProvider("p")));PreparationState.ThrowAt="p.dead";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"p.dead");Need(Has("keys.dispose")&&!c.Has(key),"assert dependency exception");No("p.value");});
        Case("provider value failure precedes FIKO Add and final loop",()=>{var key=Key();var c=new MNALHHOLFGL(Graph(key));c.Factory(key,new TestFactory(new TestProvider("p")));PreparationState.ThrowAt="p.value";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"p.value");Need(Has("keys.dispose")&&!c.Has(key),"value failure");No("inject-value");No("values.get");});
        Case("null returned service is passed unchanged to FIKO",()=>{var key=Key();var p=new TestProvider("p"){Value=null};var c=new MNALHHOLFGL(Graph(key));c.Factory(key,new TestFactory(p));c.LNFNAIMOFOF();Need(c.Injected.Count==1&&Same(c.Injected[0],null)&&Same(c.Read(key),p),"no invented service-null guard");});
        Case("FIKO failure prevents Add and final resolution",()=>{var key=Key();var c=new MNALHHOLFGL(Graph(key));c.Factory(key,new TestFactory(new TestProvider("p")));PreparationState.ThrowAt="inject-value";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"inject-value");Need(Has("keys.dispose")&&!c.Has(key),"failed injection never publishes");No("values.get");});
        Case("Dictionary Add conflict follows original FIKO mutation",()=>{var key=Key();var c=new MNALHHOLFGL(Graph(key));c.Factory(key,new TestFactory(new TestProvider("p")));var existing=new TestProvider("existing");PreparationState.OnInject=()=>c.Resolved(key,existing);Error<ArgumentException>(()=>c.LNFNAIMOFOF());Need(Same(c.Read(key),existing)&&Has("keys.dispose"),"real Add conflict is not overwritten");No("values.get");});
        Case("first GetEnumerator failure does not dispose nonexistent enumerator",()=>{var c=new MNALHHOLFGL(Graph(Key()));PreparationState.ThrowAt="keys.get";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"keys.get");No("keys.dispose");No("values.get");});
        Case("first MoveNext failure disposes captured enumerator",()=>{var c=new MNALHHOLFGL(Graph());PreparationState.ThrowAt="keys.move";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"keys.move");Need(Has("keys.dispose"),"first finally from MoveNext");});
        Case("first Current failure disposes captured enumerator",()=>{var c=new MNALHHOLFGL(Graph(Key()));PreparationState.ThrowAt="keys.current";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"keys.current");Need(Has("keys.dispose"),"first finally from Current");});
        Case("first Dispose failure skips final loop",()=>{var c=new MNALHHOLFGL(Graph());PreparationState.ThrowAt="keys.dispose";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"keys.dispose");No("values.get");});
        Case("first Dispose exception supersedes original body exception",()=>{var key=Key();var c=new MNALHHOLFGL(Graph(key));c.Factory(key,null);PreparationState.ThrowAt="keys.dispose";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"keys.dispose");});
        Case("second GetEnumerator failure does not dispose nonexistent enumerator",()=>{var c=new MNALHHOLFGL(Graph());PreparationState.ThrowAt="values.get";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"values.get");Need(Has("keys.dispose"),"first ended");No("values.dispose");});
        Case("second MoveNext failure disposes actual LINQ source enumerator",()=>{var c=new MNALHHOLFGL(Graph());PreparationState.ThrowAt="values.move";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"values.move");Need(Has("values.dispose"),"actual LINQ finally disposes source");});
        Case("second Current failure disposes actual LINQ source enumerator",()=>{var c=new MNALHHOLFGL(Graph());c.Resolved(Key(),new TestProvider("p"));PreparationState.ThrowAt="values.current";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"values.current");Need(Has("values.dispose"),"second Current finally");});
        Case("existing null provider skipped without property call",()=>{var c=new MNALHHOLFGL(Graph());c.Resolved(Key(),null);c.LNFNAIMOFOF();Need(Has("values.dispose")&&c.Injected.Count==0,"null skip");});
        Case("existing dead provider skipped without inherited injection",()=>{var p=new TestProvider("p"){Dead=true};var c=new MNALHHOLFGL(Graph());c.Resolved(Key(),p);c.LNFNAIMOFOF();Need(Count("p.dead")==1&&p.SeenContainer==null,"dead skip");No("p.value");});
        Case("final dead getter failure disposes second enumerator",()=>{var c=new MNALHHOLFGL(Graph());c.Resolved(Key(),new TestProvider("p"));PreparationState.ThrowAt="p.dead";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"p.dead");Need(Has("values.dispose"),"dead flag failure finally");});
        Case("inherited provider injection failure disposes second enumerator",()=>{var c=new MNALHHOLFGL(Graph());c.Resolved(Key(),new TestProvider("p"));PreparationState.ThrowAt="p.resolve";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"p.resolve");Need(Has("values.dispose"),"inherited interface exception finally");});
        Case("second Dispose failure propagates",()=>{var c=new MNALHHOLFGL(Graph());PreparationState.ThrowAt="values.dispose";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"values.dispose");});
        Case("second Dispose exception supersedes original body exception",()=>{var c=new MNALHHOLFGL(Graph());c.Resolved(Key(),new TestProvider("p"));PreparationState.ThrowAt="values.dispose";MNALHHOLFGL.ResolveClosureAlias.CachedSelector=pair=>{throw new InvalidOperationException("body-original");};Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"values.dispose");});
        Case("existing cached final selector used unchanged",()=>{var c=new MNALHHOLFGL(Graph());var original=new TestProvider("original");var replacement=new TestProvider("replacement");c.Resolved(Key(),original);var f=new Func<KeyValuePair<CPAMAFPANDM,NJAICAFMPBE>,NJAICAFMPBE>(pair=>replacement);MNALHHOLFGL.ResolveClosureAlias.CachedSelector=f;c.LNFNAIMOFOF();Need(Same(replacement.SeenContainer,c)&&original.SeenContainer==null&&Same(f,MNALHHOLFGL.ResolveClosureAlias.CachedSelector),"existing delegate retained");});
        Case("second preparation call returns without replaying partial failures",()=>{var c=new MNALHHOLFGL(Graph());PreparationState.ThrowAt="cycle";Error<ApplicationException>(()=>c.LNFNAIMOFOF(),"cycle");PreparationState.Calls.Clear();PreparationState.ThrowAt=null;c.LNFNAIMOFOF();Need(PreparationState.Calls.Count==0,"state1 failure not silently retried");});
    }
    public static int Main(){try{Prerequisites();Lnf();Need(cases==50,"exact50 finite prerequisite/LNF cases");Console.WriteLine("RESULT fifty_original_preparation_controlled_cases_passed; real_Dictionary_LINQ=true; production_SDK_graph_injection_provider_code_executed=false");return 0;}catch(Exception e){Console.Error.WriteLine(e);return 1;}}
}
