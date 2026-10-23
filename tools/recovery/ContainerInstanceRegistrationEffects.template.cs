// Explicit controlled boundaries only. Original SDK/donor/base/provider/Reg
// implementations never execute. Exact three selected bodies are inserted.
using System;using System.Linq;using System.Collections.Generic;
using Mono.Cecil;using Mono.Cecil.Cil;
namespace ContainerInstanceRegistrationControlled
{
    static class Effects
    {
        internal static readonly List<string> Calls=new List<string>();internal static string ThrowAt;internal static Action<object> OnBase,OnValueCtor;internal static Action OnRegister;internal static object LastBase,LastValueProvider;
        internal static void Call(string s){Calls.Add(s);if(ThrowAt==s)throw new ApplicationException(s);}
        internal static void Reset(){Calls.Clear();ThrowAt=null;OnBase=null;OnValueCtor=null;OnRegister=null;LastBase=null;LastValueProvider=null;}
    }
    static class MKECFLEMHEL
    {
        public static void GFKAFPHLKMJ(bool condition,string message){Effects.Call("guard:"+condition);if(condition)throw new InvalidOperationException(message);}
    }
    public interface CKAJONGONMK{}
    public interface MOANAJANOIL<T>{}
    public abstract class NPILHMLGJCC<T>:CKAJONGONMK
    {
        protected NPILHMLGJCC(){Effects.Call("base");Effects.LastBase=this;Effects.OnBase?.Invoke(this);}
    }
    internal class PLIPHMBIGMM<T>:MOANAJANOIL<T>
    {
        internal readonly T Value;public PLIPHMBIGMM(T value){Effects.Call("value-provider");Value=value;Effects.LastValueProvider=this;Effects.OnValueCtor?.Invoke(value);}
    }
    internal class IKGLJOBBAAC<TImpl>:NPILHMLGJCC<TImpl>
    {
        private readonly MOANAJANOIL<TImpl> JPEDOBINBHH;
        /*EXACT_INSTANCE_PROVIDER_CTOR*/
        internal MOANAJANOIL<TImpl> Read(){return JPEDOBINBHH;}
    }
    public struct CPAMAFPANDM
    {
        public readonly Type Type;public readonly string Id;
        public CPAMAFPANDM(Type type,string id){Effects.Call("key:"+type.Name);Type=type;Id=id;}
    }
    public sealed class MNALHHOLFGL
    {
        private bool KBDIBPJIHNN;internal CPAMAFPANDM SeenFrom,SeenTo;internal CKAJONGONMK SeenProvider;
        internal void DisposeForTest(){KBDIBPJIHNN=true;}
        private void JONINBOMMEP(CPAMAFPANDM from,CPAMAFPANDM to,CKAJONGONMK provider){Effects.Call("register");SeenFrom=from;SeenTo=to;SeenProvider=provider;Effects.OnRegister?.Invoke();}
        /*EXACT_INSTANCE_BIND_MEMBER*/
        /*EXACT_GENERIC_KEY_REG_MEMBER*/
    }
    interface IService{}class Service:IService{}class Derived:Service{}struct ValueService:IService{internal int Value;}
    static class Program
    {
        static int cases;static void Need(bool v,string s){if(!v)throw new InvalidOperationException(s);}
        static void Case(string s,Action a){Effects.Reset();a();cases++;Console.WriteLine("PASS "+s);}
        static bool Same(object a,object b){return Object.ReferenceEquals(a,b);}
        static bool Throws<T>(Action a,string msg=null)where T:Exception{try{a();return false;}catch(Exception e){return e.GetType()==typeof(T)&&(msg==null||e.Message==msg);}}
        static void Order(params string[] e){Need(Effects.Calls.SequenceEqual(e),"exact ordered effects: "+String.Join(",",Effects.Calls));}
        static void Run()
        {
            Case("disposed instance bind rejects before interface and allocation",()=>{var c=new MNALHHOLFGL();c.DisposeForTest();Need(Throws<InvalidOperationException>(()=>c.PHJOGIEDKPN<IService>(null),"You should not try to bind to a disposed container!")&&Same(Effects.LastBase,null),"disposed guard wins");Order("guard:True");});
            Case("interface generic rejects even nonnull implementation value",()=>{var c=new MNALHHOLFGL();IService value=new Service();Need(Throws<InvalidOperationException>(()=>c.PHJOGIEDKPN<IService>(value),"You should not try to bind an instance of an interface!")&&Same(Effects.LastBase,null),"typeof interface guard");Order("guard:False","guard:True");});
            Case("interface generic null rejected by type not value",()=>{var c=new MNALHHOLFGL();Need(Throws<InvalidOperationException>(()=>c.PHJOGIEDKPN<IService>(null),"You should not try to bind an instance of an interface!"),"null interface same type guard");Order("guard:False","guard:True");});
            Case("class null value is accepted and preserved",()=>{var c=new MNALHHOLFGL();var result=c.PHJOGIEDKPN<Service>(null);var outer=(IKGLJOBBAAC<Service>)c.SeenProvider;var value=(PLIPHMBIGMM<Service>)outer.Read();Need(Same(result,c)&&Same(value.Value,null),"null class instance no invented null check");Order("guard:False","guard:False","base","value-provider","key:Service","key:Service","register");});
            Case("nonnull class bind forwards same value and returns same container",()=>{var c=new MNALHHOLFGL();var value=new Service();var id=new String(new[]{'i','d'});Need(Same(c.PHJOGIEDKPN(value,id),c),"same return");var outer=(IKGLJOBBAAC<Service>)c.SeenProvider;Need(Same(((PLIPHMBIGMM<Service>)outer.Read()).Value,value)&&Same(c.SeenFrom.Id,id)&&c.SeenFrom.Type==typeof(Service)&&c.SeenTo.Type==typeof(Service)&&Same(c.SeenTo.Id,null),"same input/key types and raw ids");Order("guard:False","guard:False","base","value-provider","key:Service","key:Service","register");});
            Case("runtime derived value does not replace generic declared key type",()=>{var c=new MNALHHOLFGL();Service value=new Derived();c.PHJOGIEDKPN<Service>(value);Need(c.SeenFrom.Type==typeof(Service)&&c.SeenTo.Type==typeof(Service)&&Same(((PLIPHMBIGMM<Service>)((IKGLJOBBAAC<Service>)c.SeenProvider).Read()).Value,value),"declared generic class identity");});
            Case("raw null custom id is retained for both keys",()=>{var c=new MNALHHOLFGL();c.PHJOGIEDKPN(new Service());Need(Same(c.SeenFrom.Id,null)&&Same(c.SeenTo.Id,null),"optional default preserved");});
            Case("empty custom id remains distinct from implementation null id",()=>{var c=new MNALHHOLFGL();c.PHJOGIEDKPN(new Service(),String.Empty);Need(Same(c.SeenFrom.Id,String.Empty)&&Same(c.SeenTo.Id,null),"no null coalescing");});
            Case("base constructor failure prevents value provider and registration",()=>{var c=new MNALHHOLFGL();Effects.ThrowAt="base";Need(Throws<ApplicationException>(()=>c.PHJOGIEDKPN(new Service()))&&Same(c.SeenProvider,null),"base exception");Order("guard:False","guard:False","base");});
            Case("value provider failure prevents field assignment keys and registration",()=>{var c=new MNALHHOLFGL();Effects.ThrowAt="value-provider";Need(Throws<ApplicationException>(()=>c.PHJOGIEDKPN(new Service()))&&Same(((IKGLJOBBAAC<Service>)Effects.LastBase).Read(),null)&&Same(c.SeenProvider,null),"constructor failure field remains default");Order("guard:False","guard:False","base","value-provider");});
            Case("private registration failure propagates after full provider creation",()=>{var c=new MNALHHOLFGL();Effects.ThrowAt="register";Need(Throws<ApplicationException>(()=>c.PHJOGIEDKPN(new Service()))&&!Same(((IKGLJOBBAAC<Service>)Effects.LastBase).Read(),null),"reg failure after provider assignment");Order("guard:False","guard:False","base","value-provider","key:Service","key:Service","register");});
            Case("base boundary observes original instance field still null",()=>{var value=new Service();Effects.OnBase=o=>Need(Same(((IKGLJOBBAAC<Service>)o).Read(),null),"no field assignment before base");var p=new IKGLJOBBAAC<Service>(value);Need(Same(((PLIPHMBIGMM<Service>)p.Read()).Value,value),"completed field");Order("base","value-provider");});
            Case("value constructor observes readonly field null until return",()=>{Effects.OnValueCtor=v=>Need(Same(((IKGLJOBBAAC<Service>)Effects.LastBase).Read(),null),"store occurs after ctor");var p=new IKGLJOBBAAC<Service>(new Service());Need(Same(p.Read(),Effects.LastValueProvider),"exact allocated provider interface stored");Order("base","value-provider");});
            Case("provider constructor supports unconstrained int value",()=>{var p=new IKGLJOBBAAC<int>(37);Need(((PLIPHMBIGMM<int>)p.Read()).Value==37,"value type TImpl preserved");Order("base","value-provider");});
            Case("provider constructor supports value struct implementing interface",()=>{var p=new IKGLJOBBAAC<ValueService>(new ValueService{Value=9});Need(((PLIPHMBIGMM<ValueService>)p.Read()).Value.Value==9,"struct TImpl no invented class constraint");Order("base","value-provider");});
            Case("provider constructor supports interface generic and null value",()=>{var p=new IKGLJOBBAAC<IService>(null);Need(Same(((PLIPHMBIGMM<IService>)p.Read()).Value,null),"provider ctor has no interface or null guard");Order("base","value-provider");});
            Case("provider construction allocates independent wrappers",()=>{var value=new Service();var a=new IKGLJOBBAAC<Service>(value);var b=new IKGLJOBBAAC<Service>(value);Need(!Same(a.Read(),b.Read())&&Same(((PLIPHMBIGMM<Service>)a.Read()).Value,((PLIPHMBIGMM<Service>)b.Read()).Value),"fresh wrapper same input");Order("base","value-provider","base","value-provider");});
            Case("generic registration builds from and to keys in order",()=>{var c=new MNALHHOLFGL();var p=new IKGLJOBBAAC<Service>(new Service());Effects.Calls.Clear();var id=new String(new[]{'c'});c.JONINBOMMEP<IService,Service>(id,p);Need(c.SeenFrom.Type==typeof(IService)&&Same(c.SeenFrom.Id,id)&&c.SeenTo.Type==typeof(Service)&&Same(c.SeenTo.Id,null)&&Same(c.SeenProvider,p),"typed keys and same provider");Order("key:IService","key:Service","register");});
            Case("generic key registration forwards null provider without guard",()=>{var c=new MNALHHOLFGL();c.JONINBOMMEP<IService,Service>(null,null);Need(Same(c.SeenProvider,null),"no provider null rejection");Order("key:IService","key:Service","register");});
            Case("generic key registration has no disposed check",()=>{var c=new MNALHHOLFGL();c.DisposeForTest();c.JONINBOMMEP<IService,Service>(null,null);Order("key:IService","key:Service","register");});
            Case("unconstrained TFrom permits int same-type registration",()=>{var c=new MNALHHOLFGL();c.JONINBOMMEP<int,int>("v",null);Need(c.SeenFrom.Type==typeof(int)&&c.SeenTo.Type==typeof(int),"value generic keys");Order("key:Int32","key:Int32","register");});
            Case("dependent generic constraint permits struct implementation",()=>{var c=new MNALHHOLFGL();c.JONINBOMMEP<IService,ValueService>(null,null);Need(c.SeenTo.Type==typeof(ValueService),"TTo implements TFrom without class constraint");Order("key:IService","key:ValueService","register");});
            Case("first key failure prevents second key and private registration",()=>{var c=new MNALHHOLFGL();Effects.ThrowAt="key:IService";Need(Throws<ApplicationException>(()=>c.JONINBOMMEP<IService,Service>(null,null)),"first key exception");Order("key:IService");});
            Case("second key failure follows first and suppresses private registration",()=>{var c=new MNALHHOLFGL();Effects.ThrowAt="key:Service";Need(Throws<ApplicationException>(()=>c.JONINBOMMEP<IService,Service>(null,null)),"second key exception");Order("key:IService","key:Service");});
            Case("registration boundary sees completed value provider and both keys",()=>{var c=new MNALHHOLFGL();var value=new Service();Effects.OnRegister=()=>{Need(c.SeenFrom.Type==typeof(Service)&&c.SeenTo.Type==typeof(Service)&&Same(((PLIPHMBIGMM<Service>)((IKGLJOBBAAC<Service>)c.SeenProvider).Read()).Value,value),"all effects before register");};c.PHJOGIEDKPN(value);Order("guard:False","guard:False","base","value-provider","key:Service","key:Service","register");});
            Need(cases==25,"exact25 controlled registration cases");Console.WriteLine("RESULT twenty_five_original_instance_registration_effects_passed; production_SDK_base_provider_private_registration_executed=false");
        }
        static string Key(TypeReference t)
        {
            if(t is GenericParameter gp)return(gp.Type==GenericParameterType.Method?"!!":"!")+gp.Position;
            if(t is GenericInstanceType gi)return Key(gi.ElementType)+"<"+String.Join(",",gi.GenericArguments.Select(Key))+">";
            if(t is ByReferenceType r)return Key(r.ElementType)+"&";
            string n=t.FullName;foreach(string name in new[]{"IKGLJOBBAAC","NPILHMLGJCC","PLIPHMBIGMM","MOANAJANOIL"})if(n==name+"`1")return name;return n;
        }
        static string Sig(MethodReference m){return Key(m.ReturnType)+"("+String.Join(",",m.Parameters.Select(x=>Key(x.ParameterType)))+")";}
        static Instruction[] Calls(MethodDefinition m){return m.Body.Instructions.Where(i=>i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Callvirt||i.OpCode.Code==Code.Newobj).ToArray();}
        static void Same(MethodDefinition raw,MethodDefinition donor){Need(raw.Attributes==donor.Attributes&&raw.ImplAttributes==donor.ImplAttributes&&Sig(raw)==Sig(donor)&&raw.Parameters.Select(p=>(uint)p.Attributes).SequenceEqual(donor.Parameters.Select(p=>(uint)p.Attributes))&&raw.Parameters.Select(p=>p.HasConstant?p.Constant:null).SequenceEqual(donor.Parameters.Select(p=>p.HasConstant?p.Constant:null)),"same original method flags/signature/optional defaults "+raw.FullName);}
        static void GP(IGenericParameterProvider owner,uint[] flags,string[][] constraints){Need(owner.GenericParameters.Count==flags.Length,"exact GP arity");for(int i=0;i<flags.Length;i++)Need((uint)owner.GenericParameters[i].Attributes==flags[i]&&owner.GenericParameters[i].Constraints.Select(c=>Key(c.ConstraintType)).SequenceEqual(constraints[i]),"exact original GP flags/constraints");}
        static void Inspect(string originalPath,string donorPath)
        {
            var opt=new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false};using(var o=ModuleDefinition.ReadModule(originalPath,opt))using(var d=ModuleDefinition.ReadModule(donorPath,opt))
            {
                Need(o.Assembly.FullName==d.Assembly.FullName&&o.Assembly.Name.Name=="UJect.Runtime","exact original-owner donor identity metadata only");var raw=o.Types.Single(t=>t.MetadataToken.ToUInt32()==0x02000006&&t.Name=="MNALHHOLFGL");var now=d.Types.Single(t=>t.Name==raw.Name);
                var bind=now.Methods.Single(m=>m.Name=="PHJOGIEDKPN");var rb=raw.Methods.Single(m=>m.MetadataToken.ToUInt32()==0x06000013);Same(rb,bind);foreach(var m in new[]{rb,bind})GP(m,new uint[]{4},new[]{new string[0]});
                var reg=now.Methods.Single(m=>m.Name=="JONINBOMMEP"&&m.GenericParameters.Count==2);var rr=raw.Methods.Single(m=>m.MetadataToken.ToUInt32()==0x06000017);Same(rr,reg);foreach(var m in new[]{rr,reg})GP(m,new uint[]{0,0},new[]{new string[0],new[]{"!!0"}});
                var provider=d.Types.Single(t=>t.Name=="IKGLJOBBAAC`1");var rp=o.Types.Single(t=>t.MetadataToken.ToUInt32()==0x02000026&&t.Name=="IKGLJOBBAAC");Need(provider.Attributes==rp.Attributes&&Key(provider.BaseType)==Key(rp.BaseType),"same original internal provider type and base");foreach(var t in new[]{provider,rp})GP(t,new uint[]{0},new[]{new string[0]});var ctor=provider.Methods.Single(m=>m.IsConstructor);var rc=rp.Methods.Single(m=>m.MetadataToken.ToUInt32()==0x06000084);Same(rc,ctor);
                var bc=Calls(bind);Need(bc.Length==6&&((MethodReference)bc[0].Operand).Name=="GFKAFPHLKMJ"&&((MethodReference)bc[1].Operand).DeclaringType.FullName=="System.Type"&&((MethodReference)bc[1].Operand).Name=="GetTypeFromHandle"&&((MethodReference)bc[2].Operand).DeclaringType.FullName=="System.Type"&&((MethodReference)bc[2].Operand).Name=="get_IsInterface"&&((MethodReference)bc[3].Operand).Name=="GFKAFPHLKMJ"&&bc[4].OpCode.Code==Code.Newobj&&Key(((MethodReference)bc[4].Operand).DeclaringType)=="IKGLJOBBAAC<!!0>"&&((MethodReference)bc[5].Operand).Name=="JONINBOMMEP","original bind guard/type-interface/allocation/registration targets");
                // Csc has six calls; this explicit count is checked against the
                // exact selected sequence below rather than accepting extra calls.
                var bnames=bc.Select(i=>((MethodReference)i.Operand).Name).ToArray();Need(bnames.SequenceEqual(new[]{"GFKAFPHLKMJ","GetTypeFromHandle","get_IsInterface","GFKAFPHLKMJ",".ctor","JONINBOMMEP"}),"only six original bind effects");
                foreach(var i in new[]{0,3}){var guard=(MethodReference)bc[i].Operand;Need(bc[i].OpCode.Code==Code.Call&&guard.DeclaringType.FullName=="MKECFLEMHEL"&&!guard.HasThis&&Sig(guard)=="System.Void(System.Boolean,System.String)","same exact original assertion helper");}var typeTest=(MethodReference)bc[2].Operand;Need(bc[2].OpCode.Code==Code.Callvirt&&typeTest.HasThis&&Sig(typeTest)=="System.Boolean()","genuine Type.IsInterface instance getter");var bindToken=bind.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldtoken).ToArray();Need(bindToken.Length==1&&Key((TypeReference)bindToken[0].Operand)=="!!0","type guard uses original declared TClass, never runtime value type");
                var instance=bc[5].Operand as GenericInstanceMethod;Need(instance!=null&&instance.GenericArguments.Select(Key).SequenceEqual(new[]{"!!0","!!0"})&&instance.ElementMethod.Resolve()==reg,"same exact generic this registration target/class arguments");Need(bind.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldfld).Select(i=>((FieldReference)i.Operand).Name).SequenceEqual(new[]{"KBDIBPJIHNN"})&&bind.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldstr).Select(i=>(string)i.Operand).SequenceEqual(new[]{"You should not try to bind to a disposed container!","You should not try to bind an instance of an interface!"}),"only disposed field and exact guard text; no instance-null check");
                var gc=Calls(reg);Need(gc.Length==5&&gc.Select(i=>((MethodReference)i.Operand).Name).SequenceEqual(new[]{"GetTypeFromHandle",".ctor","GetTypeFromHandle",".ctor","JONINBOMMEP"})&&new[]{gc[1],gc[3]}.All(i=>(i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Newobj)&&((MethodReference)i.Operand).HasThis&&((MethodReference)i.Operand).DeclaringType.FullName=="CPAMAFPANDM"&&Sig((MethodReference)i.Operand)=="System.Void(System.Type,System.String)"),"two exact ordered value-key constructions then private three-argument registration");var privateReg=gc[4].Operand as MethodReference;Need(privateReg.DeclaringType.FullName=="MNALHHOLFGL"&&Sig(privateReg)=="System.Void(CPAMAFPANDM,CPAMAFPANDM,CKAJONGONMK)"&&privateReg.Resolve().IsPrivate&&!privateReg.Resolve().HasGenericParameters,"exact held private overload");var tokens=reg.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldtoken).Select(i=>(TypeReference)i.Operand).ToArray();Need(tokens.Length==2&&Key(tokens[0])=="!!0"&&Key(tokens[1])=="!!1","interface and implementation declared generic type order");Need(gc[3].Previous.OpCode.Code==Code.Ldnull,"implementation key custom id is exact null");
                var cc=Calls(ctor);Need(cc.Length==2&&cc[0].OpCode.Code==Code.Call&&Key(((MethodReference)cc[0].Operand).DeclaringType)=="NPILHMLGJCC<!0>"&&Sig((MethodReference)cc[0].Operand)=="System.Void()"&&cc[1].OpCode.Code==Code.Newobj&&Key(((MethodReference)cc[1].Operand).DeclaringType)=="PLIPHMBIGMM<!0>"&&Sig((MethodReference)cc[1].Operand)=="System.Void(!0)","exact generic base then concrete value provider constructor");var writes=ctor.Body.Instructions.Where(i=>i.OpCode.Code==Code.Stfld).ToArray();var rf=rp.Fields.Single(f=>f.MetadataToken.ToUInt32()==0x0400003c&&f.Name=="JPEDOBINBHH");var df=provider.Fields.Single(f=>f.Name==rf.Name);Need(writes.Length==1&&((FieldReference)writes[0].Operand).Name==rf.Name&&rf.Attributes==df.Attributes&&df.IsPrivate&&df.IsInitOnly&&Key(rf.FieldType)==Key(df.FieldType)&&Key(df.FieldType)=="MOANAJANOIL<!0>"&&writes[0].Previous==cc[1],"sole exact readonly provider field assigned only returned constructed instance");
                foreach(var m in new[]{bind,reg,ctor})Need(!m.Body.ExceptionHandlers.Any()&&!m.Body.Instructions.Any(i=>i.OpCode.Code==Code.Calli||i.OpCode.Code==Code.Stsfld),"no invented exception/static effects");Console.WriteLine("RESULT three_actual_original_instance_registration_bindings_passed; metadata_only=true");
            }
        }
        public static int Main(string[] args){try{if(args.Length==3&&args[0]=="--inspect")Inspect(args[1],args[2]);else{Need(args.Length==0,"exact test arguments");Run();}return 0;}catch(Exception e){Console.Error.WriteLine(e);return 1;}}
    }
}
