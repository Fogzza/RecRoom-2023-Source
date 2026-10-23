// Only this explicit controlled context runs. Original SDK/donor is metadata-only.
using System;
using System.Linq;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
static class State
{
    internal static readonly List<string> Events=new List<string>();
    internal static bool Found,ThrowPrepare,ThrowLookup,ThrowProvider;
    internal static NJAICAFMPBE Provider;internal static object Value;
    internal static Type RequestedType;internal static CPAMAFPANDM RequestedKey;
    internal static Action OnPrepare,OnLookup,OnProvider;
    internal static void Reset(){Events.Clear();Found=ThrowPrepare=ThrowLookup=ThrowProvider=false;Provider=null;Value=null;RequestedType=null;RequestedKey=default(CPAMAFPANDM);OnPrepare=OnLookup=OnProvider=null;}
}
public interface NJAICAFMPBE{object AIKLEKDPIFH();}
sealed class ControlledProvider:NJAICAFMPBE
{
    public object AIKLEKDPIFH(){State.Events.Add("provider");if(State.OnProvider!=null)State.OnProvider();if(State.ThrowProvider)throw new ApplicationException("provider-marker");return State.Value;}
}
public struct CPAMAFPANDM
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;}
}
public sealed class MNALHHOLFGL
{
    private bool KBDIBPJIHNN;
    /*EXACT_LOOKUP_MEMBER*/
    public void LNFNAIMOFOF(){State.Events.Add("prepare");if(State.OnPrepare!=null)State.OnPrepare();if(State.ThrowPrepare)throw new ApplicationException("prepare-marker");}
    private bool CPBMOKFMMMK<TType>(CPAMAFPANDM key,out NJAICAFMPBE provider)
    {State.Events.Add("lookup");State.RequestedKey=key;State.RequestedType=typeof(TType);if(State.OnLookup!=null)State.OnLookup();if(State.ThrowLookup)throw new ApplicationException("lookup-marker");provider=State.Provider;return State.Found;}
    public void SetDisposed(bool value){KBDIBPJIHNN=value;}
}
internal static class OriginalDisposedGuard
{
    /*EXACT_TESTED_DISPOSED_GUARD*/
}
internal static class MKECFLEMHEL
{
    public static void GFKAFPHLKMJ(bool condition,string message){State.Events.Add("guard");if(message!="You should not try to retrieve bindings from a disposed container!")throw new Exception("exact native disposed text");OriginalDisposedGuard.GFKAFPHLKMJ(condition,message);}
}
interface IService{}
sealed class Service:IService{}
static class ContainerLookupEffects
{
    static int cases;
    static void Need(bool value,string message){if(!value)throw new InvalidOperationException(message);}
    static void Case(string name,Action action){action();cases++;Console.WriteLine("PASS "+name);}
    static void Events(params string[] values){Need(State.Events.SequenceEqual(values),"exact effect order: "+String.Join(",",State.Events));}
    static bool Same(object a,object b){return Object.ReferenceEquals(a,b);}
    static bool Throws<T>(Action action,string message=null) where T:Exception{try{action();return false;}catch(Exception error){return error.GetType()==typeof(T)&&(message==null||error.Message==message);}}
    static MNALHHOLFGL Fresh(){State.Reset();return new MNALHHOLFGL();}
    static void Successful(object value){State.Found=true;State.Provider=new ControlledProvider();State.Value=value;}
    static void Run()
    {
        var key=new CPAMAFPANDM(typeof(IService),new String(new[]{'i','d'}));var old=new Service();var actual=new Service();
        Case("missing provider clears prior out value",()=>{var x=Fresh();IService value=old;Need(!x.NGBMOPMLJCM<IService>(key,out value)&&value==null,"false/default output");Events("guard","prepare","lookup");});
        Case("missing provider ignores nonnull provider output",()=>{var x=Fresh();State.Provider=new ControlledProvider();State.ThrowProvider=true;IService value=old;Need(!x.NGBMOPMLJCM<IService>(key,out value)&&value==null,"no getter on miss");Events("guard","prepare","lookup");});
        Case("success returns exact interface service and key identity",()=>{var x=Fresh();Successful(actual);IService value=old;Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,actual)&&State.RequestedType==typeof(IService)&&State.RequestedKey.AFJAGKNNCBE==key.AFJAGKNNCBE&&Same(State.RequestedKey.FEKLPCPODAH,key.FEKLPCPODAH),"exact T/key/result");Events("guard","prepare","lookup","provider");});
        Case("successful null provider result is preserved",()=>{var x=Fresh();Successful(null);IService value=old;Need(x.NGBMOPMLJCM<IService>(key,out value)&&value==null,"true null result");Events("guard","prepare","lookup","provider");});
        Case("object reference constraint permits boxed provider result",()=>{var x=Fresh();object boxed=23;Successful(boxed);object value=old;Need(x.NGBMOPMLJCM<object>(key,out value)&&Same(value,boxed),"reference-constrained object can hold boxed value");});
        Case("string reference result preserves exact reference",()=>{var x=Fresh();var text=new String(new[]{'v'});Successful(text);string value="old";Need(x.NGBMOPMLJCM<string>(key,out value)&&Same(value,text),"string T cast");});
        Case("wrong provider result throws checked cast before out store",()=>{var x=Fresh();Successful(new object());IService value=old;Need(Throws<InvalidCastException>(()=>x.NGBMOPMLJCM<IService>(key,out value))&&Same(value,old),"checked cast/out unchanged");Events("guard","prepare","lookup","provider");});
        Case("successful null provider throws before out store",()=>{var x=Fresh();State.Found=true;IService value=old;Need(Throws<NullReferenceException>(()=>x.NGBMOPMLJCM<IService>(key,out value))&&Same(value,old),"null provider not substituted");Events("guard","prepare","lookup");});
        Case("disposed guard precedes preparation and out write",()=>{var x=Fresh();x.SetDisposed(true);IService value=old;Need(Throws<InvalidOperationException>(()=>x.NGBMOPMLJCM<IService>(key,out value),"You should not try to retrieve bindings from a disposed container!")&&Same(value,old),"disposed/out unchanged");Events("guard");});
        Case("preparation exception prevents lookup and out write",()=>{var x=Fresh();State.ThrowPrepare=true;IService value=old;Need(Throws<ApplicationException>(()=>x.NGBMOPMLJCM<IService>(key,out value),"prepare-marker")&&Same(value,old),"initializer exception");Events("guard","prepare");});
        Case("provider discovery exception prevents getter and out write",()=>{var x=Fresh();State.ThrowLookup=true;IService value=old;Need(Throws<ApplicationException>(()=>x.NGBMOPMLJCM<IService>(key,out value),"lookup-marker")&&Same(value,old),"lookup exception");Events("guard","prepare","lookup");});
        Case("provider getter exception leaves out unchanged",()=>{var x=Fresh();Successful(actual);State.ThrowProvider=true;IService value=old;Need(Throws<ApplicationException>(()=>x.NGBMOPMLJCM<IService>(key,out value),"provider-marker")&&Same(value,old),"provider exception");Events("guard","prepare","lookup","provider");});
        Case("preparation sees original caller out value",()=>{var x=Fresh();Successful(actual);IService value=old;State.OnPrepare=()=>Need(Same(value,old),"no early preparation output write");Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,actual),"prepare observation");});
        Case("discovery sees original caller out value",()=>{var x=Fresh();Successful(actual);IService value=old;State.OnLookup=()=>Need(Same(value,old),"no early lookup output write");Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,actual),"lookup observation");});
        Case("provider sees original caller out value",()=>{var x=Fresh();Successful(actual);IService value=old;State.OnProvider=()=>Need(Same(value,old),"no early getter output write");Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,actual),"provider observation");});
        Case("provider callback write is followed by original result assignment",()=>{var x=Fresh();Successful(actual);var alternate=new Service();IService value=old;State.OnProvider=()=>value=alternate;Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,actual),"getter RHS completes before output assignment");});
        Case("initializer changing disposed does not invent second guard",()=>{var x=Fresh();Successful(actual);State.OnPrepare=()=>x.SetDisposed(true);IService value;Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,actual),"native single disposed check");Events("guard","prepare","lookup","provider");});
        Case("discovery changing disposed does not invent second guard",()=>{var x=Fresh();Successful(actual);State.OnLookup=()=>x.SetDisposed(true);IService value;Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,actual),"no post-discovery disposed check");Events("guard","prepare","lookup","provider");});
        Case("default key forwarded without invented type or name validation",()=>{var x=Fresh();Successful(actual);IService value;Need(x.NGBMOPMLJCM<IService>(default(CPAMAFPANDM),out value)&&State.RequestedKey.AFJAGKNNCBE==null&&State.RequestedKey.FEKLPCPODAH==null&&Same(value,actual),"key passed as original value");});
        Case("repeated caller does not invent provider caching",()=>{var x=Fresh();Successful(actual);IService value;Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,actual),"first result");var second=new Service();State.Value=second;Need(x.NGBMOPMLJCM<IService>(key,out value)&&Same(value,second),"second exact provider result");Events("guard","prepare","lookup","provider","guard","prepare","lookup","provider");});
        Need(cases==20,"exact finite20 cases");Console.WriteLine("RESULT twenty_reference_lookup_controlled_effects_passed; original_preparation_discovery_provider_executed=false");
    }
    static string TypeKey(TypeReference t){if(t is GenericParameter g)return(g.Type==GenericParameterType.Method?"!!":"!")+g.Position;if(t is ByReferenceType r)return TypeKey(r.ElementType)+"&";return t.FullName;}
    static string Signature(MethodReference m){return TypeKey(m.ReturnType)+"("+String.Join(",",m.Parameters.Select(p=>TypeKey(p.ParameterType)))+")";}
    static void ReferenceConstraint(MethodReference m){Need(m.GenericParameters.Count==1&&m.GenericParameters[0].Attributes==GenericParameterAttributes.ReferenceTypeConstraint&&m.GenericParameters[0].Constraints.Count==0,"exact class-only method generic constraint");}
    static string Scope(TypeReference type){return type.Scope is ModuleDefinition module?module.Assembly.Name.Name:((AssemblyNameReference)type.Scope).Name;}
    static void Inspect(string originalPath,string donorPath)
    {
        var options=new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false};
        using(var a=ModuleDefinition.ReadModule(originalPath,options))using(var b=ModuleDefinition.ReadModule(donorPath,options))
        {
            Need(a.Assembly.Name.FullName==b.Assembly.Name.FullName&&a.Assembly.Name.Name=="UJect.Runtime","exact original-owner assembly identity");var original=a.Types.Single(t=>t.FullName=="MNALHHOLFGL");var donor=b.Types.Single(t=>t.FullName=="MNALHHOLFGL");var target=original.Methods.Single(m=>m.MetadataToken.ToUInt32()==0x0600001e);var m=donor.Methods.Single(x=>x.Name=="NGBMOPMLJCM");
            Need(target.Name==m.Name&&(uint)target.Attributes==131&&target.Attributes==m.Attributes&&target.ImplAttributes==m.ImplAttributes&&Signature(target)=="System.Boolean(CPAMAFPANDM,!!0&)"&&Signature(target)==Signature(m)&&m.Parameters[1].IsOut&&target.Parameters[1].Attributes==m.Parameters[1].Attributes,"exact original internal bool/value-key/out-generic member contract");ReferenceConstraint(target);ReferenceConstraint(m);
            var rawGetter=a.Types.Single(t=>t.FullName=="NJAICAFMPBE").Methods.Single(x=>x.MetadataToken.ToUInt32()==0x06000053);var contextGetter=b.Types.Single(t=>t.FullName=="NJAICAFMPBE").Methods.Single(x=>x.Name=="AIKLEKDPIFH");
            Need(rawGetter.Name==contextGetter.Name&&Signature(rawGetter)=="System.Object()"&&Signature(rawGetter)==Signature(contextGetter)&&rawGetter.IsSpecialName&&((uint)rawGetter.Attributes^(uint)contextGetter.Attributes)==0x800,"ordinary thin interface declaration differs only by raw getter SpecialName; declaration is never imported");var property=rawGetter.DeclaringType.Properties.Single(p=>p.GetMethod==rawGetter);Need(property.PropertyType.FullName=="System.Object","raw original getter retains exact property association");
            Need(m.HasBody&&m.Body.ExceptionHandlers.Count==0,"complete selected managed body no added handlers");var ins=m.Body.Instructions;var calls=ins.Where(i=>i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Callvirt||i.OpCode.Code==Code.Newobj).ToArray();Need(calls.Length==4,"exact four original call boundaries");
            var first=(MethodReference)calls[0].Operand;Need(calls[0].OpCode.Code==Code.Call&&first.DeclaringType.FullName=="MKECFLEMHEL"&&first.Name=="GFKAFPHLKMJ"&&Signature(first)=="System.Void(System.Boolean,System.String)"&&!first.HasThis&&Scope(first.DeclaringType)=="UJect.Runtime","exact original disposed guard");
            var prepare=(MethodReference)calls[1].Operand;Need(calls[1].OpCode.Code==Code.Call&&prepare.DeclaringType.FullName=="MNALHHOLFGL"&&prepare.Name=="LNFNAIMOFOF"&&Signature(prepare)=="System.Void()"&&prepare.HasThis,"exact original preparation boundary");
            var discovery=calls[2].Operand as GenericInstanceMethod;Need(calls[2].OpCode.Code==Code.Call&&discovery!=null&&discovery.ElementMethod.DeclaringType.FullName=="MNALHHOLFGL"&&discovery.ElementMethod.Name=="CPBMOKFMMMK"&&Signature(discovery.ElementMethod)=="System.Boolean(CPAMAFPANDM,NJAICAFMPBE&)"&&discovery.GenericArguments.Count==1&&discovery.GenericArguments[0] is GenericParameter argument&&argument.Type==GenericParameterType.Method&&argument.Position==0,"exact original provider discovery MethodSpec<TType>");
            var rawDiscovery=original.Methods.Single(x=>x.MetadataToken.ToUInt32()==0x0600001f);Need((uint)rawDiscovery.Attributes==129&&rawDiscovery.Name=="CPBMOKFMMMK"&&rawDiscovery.GenericParameters.Count==1&&rawDiscovery.GenericParameters[0].Attributes==GenericParameterAttributes.NonVariant&&rawDiscovery.GenericParameters[0].Constraints.Count==0&&discovery.ElementMethod.GenericParameters.Count==1&&discovery.ElementMethod.GenericParameters[0].Attributes==GenericParameterAttributes.NonVariant&&discovery.ElementMethod.GenericParameters[0].Constraints.Count==0,"exact unconstrained private discovery context; only NGB is class-constrained");
            var get=(MethodReference)calls[3].Operand;Need(calls[3].OpCode.Code==Code.Callvirt&&get.DeclaringType.FullName=="NJAICAFMPBE"&&get.Name==rawGetter.Name&&Signature(get)=="System.Object()"&&get.HasThis&&Scope(get.DeclaringType)=="UJect.Runtime","exact interface slot0 raw getter name/signature binding");
            foreach(var reference in new[]{first,prepare,discovery.ElementMethod,get})Need(Scope(reference.DeclaringType)=="UJect.Runtime","all exact existing same-module dependencies");
            var fields=ins.Where(i=>i.OpCode.Code==Code.Ldfld).Select(i=>(FieldReference)i.Operand).ToArray();Need(fields.Length==1&&fields[0].DeclaringType.FullName=="MNALHHOLFGL"&&fields[0].Name=="KBDIBPJIHNN"&&fields[0].FieldType.FullName=="System.Boolean","only original disposed field read");var field=original.Fields.Single(f=>f.Name==fields[0].Name);Need(field.MetadataToken.ToUInt32()==0x0400000b&&field.IsPrivate&&!field.IsStatic,"raw exact disposed FieldDef");
            var strings=ins.Where(i=>i.OpCode.Code==Code.Ldstr).Select(i=>(string)i.Operand).ToArray();Need(strings.SequenceEqual(new[]{"You should not try to retrieve bindings from a disposed container!"}),"exact native guard text");var cast=ins.Where(i=>i.OpCode.Code==Code.Unbox_Any).ToArray();Need(cast.Length==1&&cast[0].Operand is GenericParameter checkedType&&checkedType.Type==GenericParameterType.Method&&checkedType.Position==0,"one exact checked original TType cast with proven reference constraint");Need(ins.Count(i=>i.OpCode.FlowControl==FlowControl.Cond_Branch)==1&&!ins.Any(i=>i.OpCode.Code==Code.Isinst||i.OpCode.Code==Code.Stfld||i.OpCode.Code==Code.Stsfld||i.OpCode.Code==Code.Newobj),"one discovery branch, no fallback type test/new object/state write");
            var resets=ins.Where(i=>i.OpCode.Code==Code.Initobj).ToArray();var stores=ins.Where(i=>i.OpCode.Code==Code.Stobj).ToArray();Need(resets.Length==1&&stores.Length==1&&!ins.Any(i=>i.OpCode.Code==Code.Stind_Ref),"exact original Csc default initobj and successful stobj lowering");
            foreach(var write in new[]{resets[0],stores[0]})Need(write.Operand is GenericParameter gp&&gp.Type==GenericParameterType.Method&&gp.Position==0,"both out writes use exact reference-constrained method GP0");
            Need(resets[0].Previous.OpCode.Code==Code.Ldarg_2&&resets[0].Next.OpCode.Code==Code.Ldc_I4_0&&resets[0].Next.Next.OpCode.Code==Code.Ret,"missing path initializes only original out arg then returns false");
            Need(stores[0].Previous==cast[0]&&cast[0].Previous==calls[3]&&calls[3].Previous.OpCode.Code==Code.Ldloc_0&&calls[3].Previous.Previous.OpCode.Code==Code.Ldarg_2&&stores[0].Next.OpCode.Code==Code.Ldc_I4_1&&stores[0].Next.Next.OpCode.Code==Code.Ret,"successful path gets provider then checks exact GP0 then stores original out and returns true");
            Need((calls[2].Next.OpCode.Code==Code.Brtrue||calls[2].Next.OpCode.Code==Code.Brtrue_S)&&Object.ReferenceEquals(calls[2].Next.Operand,calls[3].Previous.Previous)&&calls[2].Next.Next==resets[0].Previous,"exact discovery branch targets success output receiver; miss falls directly into default out initialization");
            Need(ins.All(i=>!(i.Operand is Instruction branch)||ins.Contains(branch)),"all managed branch targets within selected body");Console.WriteLine("RESULT one_exact_original_lookup_binding_passed; raw_getter_property="+property.Name+"; original_ordinary_context_declaration_imported=false; metadata_only=true");
        }
    }
    public static int Main(string[] args){try{if(args.Length==3&&args[0]=="--inspect")Inspect(args[1],args[2]);else{Need(args.Length==0,"exact effects args");Run();}return 0;}catch(Exception error){Console.Error.WriteLine(error);return 1;}}
}
