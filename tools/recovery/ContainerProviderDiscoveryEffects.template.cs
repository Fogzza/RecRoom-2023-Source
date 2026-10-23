// Controlled integration: real Dictionary and exact recovered caller/key bodies.
// LNF, formatting and provider getter below are explicit unproved boundaries.
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
static class State
{
    internal static readonly List<string> Calls=new List<string>();
    internal static Action<MNALHHOLFGL> OnPrepare,OnContainerString;
    internal static Action OnKeyString;internal static string ThrowPrepareName;
    internal static int ProviderGets;
    internal static void Reset(){Calls.Clear();OnPrepare=OnContainerString=null;OnKeyString=null;ThrowPrepareName=null;ProviderGets=0;}
}
public interface NJAICAFMPBE{object AIKLEKDPIFH();}
sealed class Provider:NJAICAFMPBE
{
    internal object Value;internal bool ThrowOnGet;
    public object AIKLEKDPIFH(){State.Calls.Add("provider");State.ProviderGets++;if(ThrowOnGet)throw new ApplicationException("provider-marker");return Value;}
}
public struct CPAMAFPANDM:IComparable<CPAMAFPANDM>
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;}
    /*EXACT_TESTED_KEY_MEMBERS*/
    public int CompareTo(CPAMAFPANDM other){throw new NotImplementedException("Unselected CompareTo; Dictionary must not invoke it");}
    public override string ToString(){State.Calls.Add("key-string");if(State.OnKeyString!=null)State.OnKeyString();return "key";}
}
public sealed class MNALHHOLFGL
{
    private readonly Dictionary<CPAMAFPANDM,NJAICAFMPBE> AAHKPPMHGFI=new Dictionary<CPAMAFPANDM,NJAICAFMPBE>();
    private readonly MNALHHOLFGL DDFCHDGPJBN;private bool KBDIBPJIHNN;
    internal readonly string Name;
    internal MNALHHOLFGL(MNALHHOLFGL parent,string name){DDFCHDGPJBN=parent;Name=name;}
    /*EXACT_LOOKUP_MEMBER*/
    /*EXACT_PROVIDER_DISCOVERY_MEMBER*/
    public void LNFNAIMOFOF(){State.Calls.Add("prepare:"+Name);if(State.OnPrepare!=null)State.OnPrepare(this);if(State.ThrowPrepareName==Name)throw new ApplicationException("prepare-marker");}
    internal bool Discover<T>(CPAMAFPANDM key,out NJAICAFMPBE value){return CPBMOKFMMMK<T>(key,out value);}
    internal void Bind(CPAMAFPANDM key,NJAICAFMPBE value){AAHKPPMHGFI[key]=value;}
    internal void SetDisposed(){KBDIBPJIHNN=true;}
    public override string ToString(){State.Calls.Add("container-string:"+Name);if(State.OnContainerString!=null)State.OnContainerString(this);return Name;}
}
internal static class OriginalDisposedGuard
{
    /*EXACT_TESTED_DISPOSED_GUARD*/
}
internal static class MKECFLEMHEL
{
    public static void GFKAFPHLKMJ(bool condition,string message){State.Calls.Add("guard");if(message!="You should not try to retrieve bindings from a disposed container!")throw new Exception("exact native disposed text");OriginalDisposedGuard.GFKAFPHLKMJ(condition,message);}
}
sealed class ThrowingHashType:TypeDelegator
{
    internal bool Throw;
    internal ThrowingHashType():base(typeof(object)){}
    public override int GetHashCode(){State.Calls.Add("hash");if(Throw)throw new ApplicationException("hash-marker");return 7;}
}
interface IService{}
sealed class Service:IService{}
static class ContainerProviderDiscoveryEffects
{
    static int cases;
    static void Need(bool value,string message){if(!value)throw new InvalidOperationException(message);}
    static void Case(string name,Action body){State.Reset();body();cases++;Console.WriteLine("PASS "+name);}
    static bool Same(object a,object b){return Object.ReferenceEquals(a,b);}
    static bool Throws<T>(Action action,string message=null) where T:Exception{try{action();return false;}catch(Exception error){return error.GetType()==typeof(T)&&(message==null||error.Message==message);}}
    static void Order(params string[] calls){Need(State.Calls.SequenceEqual(calls),"exact calls: "+String.Join(",",State.Calls));}
    static MNALHHOLFGL Node(string name="root",MNALHHOLFGL parent=null){return new MNALHHOLFGL(parent,name);}
    static CPAMAFPANDM Key(string name="id"){return new CPAMAFPANDM(typeof(IService),name);}
    static void Run()
    {
        var key=Key();var sentinel=new Provider();var local=new Provider();var inherited=new Provider();
        const string NullMessage="Null dependency detected in: child for key key. It should have been unregistered!";
        Case("root miss returns false and null out",()=>{var x=Node();NJAICAFMPBE p=sentinel;Need(!x.Discover<object>(key,out p)&&p==null,"root miss");Order("guard","prepare:root");});
        Case("local hit returns exact provider without invoking getter",()=>{var x=Node();x.Bind(key,local);NJAICAFMPBE p=sentinel;Need(x.Discover<object>(key,out p)&&Same(p,local)&&State.ProviderGets==0,"local identity");Order("guard","prepare:root");});
        Case("local null sets caller out before format and exact exception",()=>{var x=Node("child");x.Bind(key,null);NJAICAFMPBE p=sentinel;State.OnContainerString=n=>Need(Same(n,x)&&p==null,"out assigned null before container formatting");State.OnKeyString=()=>Need(p==null,"out assigned null before key formatting");Need(Throws<InvalidOperationException>(()=>x.Discover<object>(key,out p),NullMessage)&&p==null,"inline null assertion");Order("guard","prepare:child","container-string:child","key-string");});
        Case("missing local binding falls back to exact parent",()=>{var parent=Node("parent");parent.Bind(key,inherited);var x=Node("child",parent);NJAICAFMPBE p;Need(x.Discover<object>(key,out p)&&Same(p,inherited),"parent hit");Order("guard","prepare:child","guard","prepare:parent");});
        Case("parent miss clears old outer output",()=>{var x=Node("child",Node("parent"));NJAICAFMPBE p=sentinel;Need(!x.Discover<object>(key,out p)&&p==null,"parent miss");Order("guard","prepare:child","guard","prepare:parent");});
        Case("nonnull local binding shadows parent",()=>{var parent=Node("parent");parent.Bind(key,inherited);var x=Node("child",parent);x.Bind(key,local);NJAICAFMPBE p;Need(x.Discover<object>(key,out p)&&Same(p,local),"local shadow");Order("guard","prepare:child");});
        Case("null local binding shadows parent and still throws",()=>{var parent=Node("parent");parent.Bind(key,inherited);var x=Node("child",parent);x.Bind(key,null);NJAICAFMPBE p=sentinel;Need(Throws<InvalidOperationException>(()=>x.Discover<object>(key,out p),NullMessage)&&p==null,"null shadow not fallback");Order("guard","prepare:child","container-string:child","key-string");});
        Case("discovery recurses through missing parent to grandparent",()=>{var grand=Node("grand");grand.Bind(key,inherited);var x=Node("child",Node("parent",grand));NJAICAFMPBE p;Need(x.Discover<object>(key,out p)&&Same(p,inherited),"grandparent");Order("guard","prepare:child","guard","prepare:parent","guard","prepare:grand");});
        Case("disposed current node prevents initialization and output write",()=>{var x=Node();x.SetDisposed();NJAICAFMPBE p=sentinel;Need(Throws<InvalidOperationException>(()=>x.Discover<object>(key,out p),"You should not try to retrieve bindings from a disposed container!")&&Same(p,sentinel),"current disposed");Order("guard");});
        Case("disposed parent exception leaves outer output untouched",()=>{var parent=Node("parent");parent.SetDisposed();var x=Node("child",parent);NJAICAFMPBE p=sentinel;Need(Throws<InvalidOperationException>(()=>x.Discover<object>(key,out p))&&Same(p,sentinel),"parent disposed output");Order("guard","prepare:child","guard");});
        Case("current preparation failure prevents lookup/output write",()=>{var x=Node();State.ThrowPrepareName="root";NJAICAFMPBE p=sentinel;Need(Throws<ApplicationException>(()=>x.Discover<object>(key,out p),"prepare-marker")&&Same(p,sentinel),"current preparation exception");Order("guard","prepare:root");});
        Case("parent preparation failure leaves outer output untouched",()=>{var x=Node("child",Node("parent"));State.ThrowPrepareName="parent";NJAICAFMPBE p=sentinel;Need(Throws<ApplicationException>(()=>x.Discover<object>(key,out p),"prepare-marker")&&Same(p,sentinel),"parent preparation exception");Order("guard","prepare:child","guard","prepare:parent");});
        Case("actual Dictionary hash failure propagates before outer write",()=>{var x=Node();x.Bind(key,local);var type=new ThrowingHashType{Throw=true};var bad=new CPAMAFPANDM(type,"bad");NJAICAFMPBE p=sentinel;Need(Throws<ApplicationException>(()=>x.Discover<object>(bad,out p),"hash-marker")&&Same(p,sentinel),"Dictionary hash exception");Order("guard","prepare:root","hash");});
        Case("container formatting failure follows null output assignment",()=>{var x=Node("child");x.Bind(key,null);NJAICAFMPBE p=sentinel;State.OnContainerString=n=>{Need(p==null,"null output before formatter failure");throw new ApplicationException("container-string-marker");};Need(Throws<ApplicationException>(()=>x.Discover<object>(key,out p),"container-string-marker")&&p==null,"container formatting boundary");Order("guard","prepare:child","container-string:child");});
        Case("key formatting failure follows container formatting and null output",()=>{var x=Node("child");x.Bind(key,null);NJAICAFMPBE p=sentinel;State.OnKeyString=()=>{Need(p==null,"null output before key format");throw new ApplicationException("key-string-marker");};Need(Throws<ApplicationException>(()=>x.Discover<object>(key,out p),"key-string-marker")&&p==null,"key formatting boundary");Order("guard","prepare:child","container-string:child","key-string");});
        Case("current preparation sees original caller output",()=>{var x=Node();x.Bind(key,local);NJAICAFMPBE p=sentinel;State.OnPrepare=n=>Need(Same(p,sentinel),"no early local output assignment");Need(x.Discover<object>(key,out p)&&Same(p,local),"local preparation observation");});
        Case("parent preparation sees original outer caller output",()=>{var parent=Node("parent");parent.Bind(key,inherited);var x=Node("child",parent);NJAICAFMPBE p=sentinel;State.OnPrepare=n=>Need(Same(p,sentinel),"no outer write before parent returns");Need(x.Discover<object>(key,out p)&&Same(p,inherited),"parent preparation observation");});
        Case("unconstrained discovery generic permits value type argument",()=>{var x=Node();x.Bind(key,local);NJAICAFMPBE p;Need(x.Discover<int>(key,out p)&&Same(p,local),"no invented class constraint on CPBM");});
        Case("discovery never calls provider return implementation",()=>{var x=Node();var provider=new Provider{ThrowOnGet=true};x.Bind(key,provider);NJAICAFMPBE p;Need(x.Discover<object>(key,out p)&&Same(p,provider)&&State.ProviderGets==0,"provider remains unevaluated");});
        Case("real Dictionary matches independent equal key values",()=>{var x=Node();string a=new String(new[]{'i','d'}),b=new String(new[]{'i','d'});x.Bind(new CPAMAFPANDM(typeof(IService),a),local);NJAICAFMPBE p;Need(!Same(a,b)&&x.Discover<object>(new CPAMAFPANDM(typeof(IService),b),out p)&&Same(p,local),"actual equal key hash/Equals");});
        Case("nonnull Dictionary rejects null Type key by its real hash",()=>{var x=Node();x.Bind(key,local);NJAICAFMPBE p=sentinel;Need(Throws<NullReferenceException>(()=>x.Discover<object>(new CPAMAFPANDM(null,"bad"),out p))&&Same(p,sentinel),"no invented null-Type guard or hash");});
        Case("repeated discovery reads current Dictionary binding",()=>{var x=Node();x.Bind(key,local);NJAICAFMPBE p;Need(x.Discover<object>(key,out p)&&Same(p,local),"first provider");x.Bind(key,inherited);Need(x.Discover<object>(key,out p)&&Same(p,inherited),"fresh provider without cache");Order("guard","prepare:root","guard","prepare:root");});
        Case("null and empty custom ids select distinct bindings",()=>{var x=Node();x.Bind(Key(null),local);x.Bind(Key(""),inherited);NJAICAFMPBE p;Need(x.Discover<object>(Key(null),out p)&&Same(p,local)&&x.Discover<object>(Key(""),out p)&&Same(p,inherited),"distinct custom ids");});
        Case("preparation can publish binding before Dictionary lookup",()=>{var x=Node();State.OnPrepare=n=>n.Bind(key,local);NJAICAFMPBE p;Need(x.Discover<object>(key,out p)&&Same(p,local),"preparation effects precede query");Order("guard","prepare:root");});
        Case("combined local resolution retains both preparation calls",()=>{var x=Node();var service=new Service();x.Bind(key,new Provider{Value=service});IService value;Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,service),"combined exact result");Order("guard","prepare:root","guard","prepare:root","provider");});
        Case("combined parent resolution preserves recursive order",()=>{var parent=Node("parent");var service=new Service();parent.Bind(key,new Provider{Value=service});var x=Node("child",parent);IService value;Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,service),"combined parent result");Order("guard","prepare:child","guard","prepare:child","guard","prepare:parent","provider");});
        Case("combined missing provider clears outer generic output",()=>{var x=Node();IService value=new Service();Need(!x.NGBMOPMLJCM<IService>(key,out value)&&value==null,"combined missing output");Order("guard","prepare:root","guard","prepare:root");});
        Case("combined null-binding assertion retains outer generic output",()=>{var x=Node("child");x.Bind(key,null);var old=new Service();IService value=old;Need(Throws<InvalidOperationException>(()=>x.NGBMOPMLJCM<IService>(key,out value),NullMessage)&&Same(value,old),"CPBM local out must not prematurely write NGB caller output");Order("guard","prepare:child","guard","prepare:child","container-string:child","key-string");});
        Case("combined wrong returned object retains outer generic output",()=>{var x=Node();x.Bind(key,new Provider{Value=new object()});var old=new Service();IService value=old;Need(Throws<InvalidCastException>(()=>x.NGBMOPMLJCM<IService>(key,out value))&&Same(value,old),"combined checked cast");});
        Case("combined successful null provider return remains true/null",()=>{var x=Node();x.Bind(key,new Provider{Value=null});IService value=new Service();Need(x.NGBMOPMLJCM<IService>(key,out value)&&value==null,"combined null service value");});
        Need(cases==30,"exact finite30 Dictionary/discovery/combined cases");Console.WriteLine("RESULT thirty_real_Dictionary_provider_discovery_and_combined_effects_passed; original_LNF_formatters_or_providers_executed=false");
    }
    static string Key(TypeReference t){if(t is GenericParameter gp)return(gp.Type==GenericParameterType.Method?"!!":"!")+gp.Position;if(t is ByReferenceType r)return Key(r.ElementType)+"&";return t.FullName;}
    static string Signature(MethodReference m){return Key(m.ReturnType)+"("+String.Join(",",m.Parameters.Select(p=>Key(p.ParameterType)))+")";}
    static string Scope(TypeReference t){return t.Scope is ModuleDefinition m?m.Assembly.Name.Name:((AssemblyNameReference)t.Scope).Name;}
    static void Inspect(string originalPath,string donorPath)
    {
        OriginalLookupMetadataReader.Inspect(originalPath,donorPath);
        var options=new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false};using(var original=ModuleDefinition.ReadModule(originalPath,options))using(var donor=ModuleDefinition.ReadModule(donorPath,options))
        {
            Need(original.Assembly.FullName==donor.Assembly.FullName&&original.Assembly.Name.Name=="UJect.Runtime","exact original-owner SDK donor identity");var a=original.Types.Single(t=>t.FullName=="MNALHHOLFGL");var b=donor.Types.Single(t=>t.FullName=="MNALHHOLFGL");var target=a.Methods.Single(m=>m.MetadataToken.ToUInt32()==0x0600001f);var method=b.Methods.Single(m=>m.Name=="CPBMOKFMMMK");Need(target.Name==method.Name&&(uint)target.Attributes==129&&target.Attributes==method.Attributes&&target.ImplAttributes==method.ImplAttributes&&Signature(target)=="System.Boolean(CPAMAFPANDM,NJAICAFMPBE&)"&&Signature(target)==Signature(method)&&target.Parameters[1].Attributes==method.Parameters[1].Attributes&&method.Parameters[1].IsOut,"exact original private discovery signature/flags/out");
            foreach(var m in new[]{target,method})Need(m.GenericParameters.Count==1&&(uint)m.GenericParameters[0].Attributes==0&&m.GenericParameters[0].Constraints.Count==0,"original discovery generic is exactly unconstrained");Need(method.HasBody&&method.Body.ExceptionHandlers.Count==0,"no invented exception handler");var ins=method.Body.Instructions;var calls=ins.Where(i=>i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Callvirt||i.OpCode.Code==Code.Newobj).ToArray();Need(calls.Length==6,"exact guard/preparation/Dictionary/Format/exception/self-recursion calls");
            var guard=(MethodReference)calls[0].Operand;var prepare=(MethodReference)calls[1].Operand;Need(guard.DeclaringType.FullName=="MKECFLEMHEL"&&guard.Name=="GFKAFPHLKMJ"&&Signature(guard)=="System.Void(System.Boolean,System.String)"&&prepare.DeclaringType.FullName=="MNALHHOLFGL"&&prepare.Name=="LNFNAIMOFOF"&&Signature(prepare)=="System.Void()","exact held guard/preparation boundaries");
            var query=(MethodReference)calls[2].Operand;var dict=query.DeclaringType as GenericInstanceType;Need(calls[2].OpCode.Code==Code.Callvirt&&query.Name=="TryGetValue"&&query.ReturnType.FullName=="System.Boolean"&&dict!=null&&dict.ElementType.FullName=="System.Collections.Generic.Dictionary`2"&&Scope(dict.ElementType)=="mscorlib"&&dict.GenericArguments.Select(t=>t.FullName).SequenceEqual(new[]{"CPAMAFPANDM","NJAICAFMPBE"})&&Signature(query)=="System.Boolean(!0,!1&)","exact genuine generic Dictionary specialization and TryGetValue");
            var format=(MethodReference)calls[3].Operand;var exception=(MethodReference)calls[4].Operand;Need(calls[3].OpCode.Code==Code.Call&&format.DeclaringType.FullName=="System.String"&&Scope(format.DeclaringType)=="mscorlib"&&format.Name=="Format"&&!format.HasThis&&Signature(format)=="System.String(System.String,System.Object,System.Object)","exact original null assertion Format with two original objects");Need(calls[4].OpCode.Code==Code.Newobj&&exception.DeclaringType.FullName=="System.InvalidOperationException"&&Scope(exception.DeclaringType)=="mscorlib"&&exception.Name==".ctor"&&Signature(exception)=="System.Void(System.String)","exact original exception type/message constructor");
            var recurse=calls[5].Operand as GenericInstanceMethod;Need(calls[5].OpCode.Code==Code.Call&&recurse!=null&&recurse.ElementMethod.DeclaringType.FullName=="MNALHHOLFGL"&&recurse.ElementMethod.Name=="CPBMOKFMMMK"&&Signature(recurse.ElementMethod)==Signature(method)&&recurse.GenericArguments.Count==1&&recurse.GenericArguments[0] is GenericParameter gp&&gp.Type==GenericParameterType.Method&&gp.Position==0,"exact parent self-recursion with unchanged generic argument");
            var fields=ins.Where(i=>i.OpCode.Code==Code.Ldfld).Select(i=>(FieldReference)i.Operand).ToArray();Need(fields.Select(f=>f.Name).SequenceEqual(new[]{"KBDIBPJIHNN","AAHKPPMHGFI","DDFCHDGPJBN"})&&fields.All(f=>f.DeclaringType.FullName=="MNALHHOLFGL"&&Scope(f.DeclaringType)=="UJect.Runtime"),"exact original disposed/map/parent field order and single parent capture");foreach(var f in fields){var x=a.Fields.Single(v=>v.Name==f.Name);var y=b.Fields.Single(v=>v.Name==f.Name);Need(x.Attributes==y.Attributes&&x.FieldType.FullName==y.FieldType.FullName,"exact original read field contracts");}
            Need(ins.Where(i=>i.OpCode.Code==Code.Ldstr).Select(i=>(string)i.Operand).SequenceEqual(new[]{"You should not try to retrieve bindings from a disposed container!","Null dependency detected in: {0} for key {1}. It should have been unregistered!"}),"exact original disposed/null assertion text");var boxes=ins.Where(i=>i.OpCode.Code==Code.Box).ToArray();Need(boxes.Length==1&&((TypeReference)boxes[0].Operand).FullName=="CPAMAFPANDM","exact original key boxed for Format");Need(ins.Count(i=>i.OpCode.Code==Code.Stind_Ref)==3&&!ins.Any(i=>i.OpCode.Code==Code.Stobj||i.OpCode.Code==Code.Stfld||i.OpCode.Code==Code.Stsfld),"exact local-hit/parent-hit/miss output writes with no field mutation");
            var assigned=ins.Where(i=>i.OpCode.Code==Code.Stind_Ref).ToArray();Need(ins.IndexOf(assigned[0])<ins.IndexOf(calls[3])&&ins.IndexOf(assigned[0])>ins.IndexOf(calls[2]),"local provider output precedes null assertion formatting");Need(ins.All(i=>!(i.Operand is Instruction branch)||ins.Contains(branch)),"all selected managed branches close");Console.WriteLine("RESULT exact_unconstrained_provider_discovery_and_rechecked_lookup_bindings_passed; metadata_only=true");
        }
    }
    public static int Main(string[] args){try{if(args.Length==3&&args[0]=="--inspect")Inspect(args[1],args[2]);else{Need(args.Length==0,"exact effect args");Run();}return 0;}catch(Exception error){Console.Error.WriteLine(error);return 1;}}
}
