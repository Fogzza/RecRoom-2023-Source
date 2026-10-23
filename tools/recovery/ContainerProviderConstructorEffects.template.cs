// Exact three ctor bodies in explicit nonproduction declaration contexts.
// No original SDK/provider/registration/Unity/network code is executed.
using System;using System.Linq;using System.Collections.Generic;
using Mono.Cecil;using Mono.Cecil.Cil;
namespace ContainerProviderCtorControlled
{
    public abstract class NPILHMLGJCC<TImpl>
    {
        /*EXACT_NPIL_CTOR*/
    }
    sealed class NPILProbe<T>:NPILHMLGJCC<T>{}
    public abstract class JEMKLLFDDFD<TImpl>
    {
        private bool OEAONLGBBPN;
        /*EXACT_JEM_CTOR*/
        internal bool ReadBaseFlag(){return OEAONLGBBPN;}
    }
    sealed class JEMProbe<T>:JEMKLLFDDFD<T>{}
    internal class PLIPHMBIGMM<TImpl>:JEMKLLFDDFD<TImpl>
    {
        // Donor-only source spelling emits exact original backing-field name;
        // the original obfuscated PropertyDef/getter is not this declaration.
        public TImpl LHGCALINHGC {get;}
        /*EXACT_PLIPH_CTOR*/
    }
    interface IService{}class Service:IService{}class Derived:Service{}struct Copy{internal int N;internal object Ref;}
    static class Program
    {
        static int cases;static void Need(bool v,string s){if(!v)throw new InvalidOperationException(s);}
        static bool Same(object a,object b){return Object.ReferenceEquals(a,b);}
        static void Case(string n,Action a){a();cases++;Console.WriteLine("PASS "+n);}
        static void Run()
        {
            Case("NPIL empty protected constructor supports class and value contexts",()=>{Need(new NPILProbe<object>()!=null&&new NPILProbe<int>()!=null,"unconstrained empty base");});
            Case("JEM empty protected constructor leaves original private bool false",()=>{Need(!new JEMProbe<object>().ReadBaseFlag()&&!new JEMProbe<int>().ReadBaseFlag(),"genuine CLR zero initialization");});
            Case("nonnull object value retained with exact reference identity",()=>{var value=new Service();var p=new PLIPHMBIGMM<Service>(value);Need(Same(p.LHGCALINHGC,value),"same captured input reference");});
            Case("null reference accepted and retained",()=>{Need(Same(new PLIPHMBIGMM<Service>(null).LHGCALINHGC,null),"no added value null guard");});
            Case("interface generic accepts both concrete value and null",()=>{IService value=new Service();Need(Same(new PLIPHMBIGMM<IService>(value).LHGCALINHGC,value)&&Same(new PLIPHMBIGMM<IService>(null).LHGCALINHGC,null),"no invented interface guard");});
            Case("object generic retains same preboxed value object",()=>{object value=17;Need(Same(new PLIPHMBIGMM<object>(value).LHGCALINHGC,value),"no new boxing or replacement");});
            Case("string null empty and reference spelling preserved",()=>{var value=new String(new[]{'a'});Need(Same(new PLIPHMBIGMM<string>(null).LHGCALINHGC,null)&&Same(new PLIPHMBIGMM<string>(String.Empty).LHGCALINHGC,String.Empty)&&Same(new PLIPHMBIGMM<string>(value).LHGCALINHGC,value),"no null/empty conversion");});
            Case("unconstrained int preserves full signed domain examples",()=>{foreach(int n in new[]{Int32.MinValue,-1,0,37,Int32.MaxValue})Need(new PLIPHMBIGMM<int>(n).LHGCALINHGC==n,"exact int value");});
            Case("struct argument is copied before later caller mutation",()=>{var reference=new object();var value=new Copy{N=9,Ref=reference};var p=new PLIPHMBIGMM<Copy>(value);value.N=100;value.Ref=null;Need(p.LHGCALINHGC.N==9&&Same(p.LHGCALINHGC.Ref,reference),"generic by-value copy and embedded reference");});
            Case("nullable value generic preserves absent and present values",()=>{Need(!new PLIPHMBIGMM<int?>(null).LHGCALINHGC.HasValue&&new PLIPHMBIGMM<int?>(42).LHGCALINHGC.Value==42,"unconstrained nullable values");});
            Case("independent instances retain independent values",()=>{var a=new object();var b=new object();var p=new PLIPHMBIGMM<object>(a);var q=new PLIPHMBIGMM<object>(b);Need(Same(p.LHGCALINHGC,a)&&Same(q.LHGCALINHGC,b)&&!Same(p.LHGCALINHGC,q.LHGCALINHGC),"no static/shared field");});
            Case("derived bool value store does not overwrite base bool",()=>{var p=new PLIPHMBIGMM<bool>(true);Need(p.LHGCALINHGC&&!p.ReadBaseFlag(),"correct derived generic field, base remains default");});
            Case("declared generic class type preserves derived runtime reference",()=>{Service value=new Derived();var p=new PLIPHMBIGMM<Service>(value);Need(Same(p.LHGCALINHGC,value)&&typeof(PLIPHMBIGMM<Service>).GetGenericArguments().Single()==typeof(Service),"declared TImpl and actual object retained");});
            Need(cases==13,"exact13 constructor controlled cases");Console.WriteLine("RESULT thirteen_original_provider_constructor_effects_passed; original_SDK_or_provider_runtime_executed=false");
        }
        static string Key(TypeReference t){if(t is GenericParameter g)return(g.Type==GenericParameterType.Method?"!!":"!")+g.Position;if(t is GenericInstanceType i)return Key(i.ElementType)+"<"+String.Join(",",i.GenericArguments.Select(Key))+">";foreach(var n in new[]{"NPILHMLGJCC","JEMKLLFDDFD","PLIPHMBIGMM"})if(t.FullName==n+"`1")return n;return t.FullName;}
        static string Sig(MethodReference m){return Key(m.ReturnType)+"("+String.Join(",",m.Parameters.Select(p=>Key(p.ParameterType)))+")";}
        static void Inspect(string originalPath,string donorPath)
        {
            var opt=new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false};using(var o=ModuleDefinition.ReadModule(originalPath,opt))using(var d=ModuleDefinition.ReadModule(donorPath,opt))
            {
                Need(o.Assembly.FullName==d.Assembly.FullName&&o.Assembly.Name.Name=="UJect.Runtime","exact original-owner ctor donor metadata only");
                foreach(var row in new[]{Tuple.Create("NPILHMLGJCC",0x06000083u),Tuple.Create("JEMKLLFDDFD",0x0600005cu),Tuple.Create("PLIPHMBIGMM",0x06000057u)})
                {
                    var raw=o.Types.Single(t=>t.Name==row.Item1);var now=d.Types.Single(t=>t.Name==row.Item1+"`1");Need(raw.Attributes==now.Attributes&&Key(raw.BaseType)==Key(now.BaseType),"exact original generic owner attributes/base "+row.Item1);foreach(var t in new[]{raw,now})Need(t.GenericParameters.Count==1&&(uint)t.GenericParameters[0].Attributes==0&&t.GenericParameters[0].Constraints.Count==0,"original owner type genuinely unconstrained");var a=raw.Methods.Single(m=>m.MetadataToken.ToUInt32()==row.Item2);var b=now.Methods.Single(m=>m.IsConstructor&&!m.IsStatic);Need(a.Name==b.Name&&a.Attributes==b.Attributes&&a.ImplAttributes==b.ImplAttributes&&Sig(a)==Sig(b)&&a.Parameters.Select(p=>(uint)p.Attributes).SequenceEqual(b.Parameters.Select(p=>(uint)p.Attributes))&&b.HasBody&&!b.Body.ExceptionHandlers.Any(),"original ctor exact flags/signature "+row.Item1);var calls=b.Body.Instructions.Where(i=>i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Callvirt||i.OpCode.Code==Code.Newobj).ToArray();Need(calls.Length==1&&calls[0].OpCode.Code==Code.Call&&((MethodReference)calls[0].Operand).Name==".ctor"&&Sig((MethodReference)calls[0].Operand)=="System.Void()","only exact base constructor call");
                    if(row.Item1!="PLIPHMBIGMM")Need(((MethodReference)calls[0].Operand).DeclaringType.FullName=="System.Object"&&b.Body.Instructions.Select(i=>i.OpCode.Code).SequenceEqual(new[]{Code.Ldarg_0,Code.Call,Code.Ret}),"entire empty Object-forwarding ctor, no fields or new effects");
                    else
                    {
                        Need(Key(((MethodReference)calls[0].Operand).DeclaringType)=="JEMKLLFDDFD<!0>","exact original generic JEM base");var ins=b.Body.Instructions;Need(ins.Select(i=>i.OpCode.Code).SequenceEqual(new[]{Code.Ldarg_0,Code.Call,Code.Ldarg_0,Code.Ldarg_1,Code.Stfld,Code.Ret}),"base before exact same argument value store; no guards/conversions");var field=(FieldReference)ins[4].Operand;var rfield=raw.Fields.Single(f=>f.MetadataToken.ToUInt32()==0x04000027);var dfield=now.Fields.Single(f=>f.Name==rfield.Name);Need(rfield.Name=="<LHGCALINHGC>k__BackingField"&&field.Name==rfield.Name&&rfield.Attributes==dfield.Attributes&&rfield.IsPrivate&&rfield.IsInitOnly&&!rfield.IsStatic&&Key(rfield.FieldType)=="!0"&&Key(dfield.FieldType)=="!0"&&Key(field.DeclaringType)=="PLIPHMBIGMM<!0>","exact original readonly field, emitted class-generic context and value type");Need(raw.Properties.Single(p=>p.GetMethod!=null&&p.GetMethod.MetadataToken.ToUInt32()==0x06000056).Name=="OAPFKCFKCOD"&&now.Properties.Single(p=>p.Name=="LHGCALINHGC").GetMethod!=null,"donor-only auto-property context is distinct from preserved original property; declaration never imported");
                    }
                }
                var rb=o.Types.Single(t=>t.Name=="JEMKLLFDDFD").Fields.Single(f=>f.Name=="OEAONLGBBPN");var db=d.Types.Single(t=>t.Name=="JEMKLLFDDFD`1").Fields.Single(f=>f.Name==rb.Name);Need(rb.Attributes==db.Attributes&&rb.FieldType.FullName=="System.Boolean"&&db.FieldType.FullName==rb.FieldType.FullName,"base original private bool contract retained");Console.WriteLine("RESULT three_original_provider_constructor_bindings_passed; two_existing_empty_forwarder_semantics_confirmed=true; metadata_only=true");
            }
        }
        public static int Main(string[] args){try{if(args.Length==3&&args[0]=="--inspect")Inspect(args[1],args[2]);else{Need(args.Length==0,"exact args");Run();}return 0;}catch(Exception e){Console.Error.WriteLine(e);return 1;}}
    }
}
