// Explicit controlled-effect contexts. No production SDK/donor is executed.
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
static class ChildBoundary
{
    internal static int Calls;internal static bool Throw;
    internal static MNALHHOLFGL Parent;internal static string Name;
    internal static void Reset(){Calls=0;Throw=false;Parent=null;Name=null;}
}
public sealed class MNALHHOLFGL
{
    internal readonly MNALHHOLFGL ObservedParent;internal readonly string ObservedName;
    internal MNALHHOLFGL(MNALHHOLFGL parent,string name)
    {
        ChildBoundary.Calls++;ChildBoundary.Parent=parent;ChildBoundary.Name=name;
        if(ChildBoundary.Throw)throw new ApplicationException("controlled-child-constructor-marker");
        ObservedParent=parent;ObservedName=name;
    }
    /*EXACT_CHILD_MEMBER*/
}
public struct CPAMAFPANDM:IComparable<CPAMAFPANDM>
{
    public readonly Type AFJAGKNNCBE;public readonly string FEKLPCPODAH;
    public CPAMAFPANDM(Type type,string name){AFJAGKNNCBE=type;FEKLPCPODAH=name;}
    public int CompareTo(CPAMAFPANDM other){throw new NotImplementedException("Unselected original member context");}
    /*EXACT_KEY_MEMBERS*/
}
sealed class ControlledHashType:TypeDelegator
{
    internal int Calls;internal readonly int Value;internal bool Throw;
    internal ControlledHashType(int value):base(typeof(object)){Value=value;}
    public override int GetHashCode(){Calls++;if(Throw)throw new ApplicationException("controlled-type-hash-marker");return Value;}
}
static class ContainerKeyChildEffects
{
    static int cases;
    static void Need(bool value,string message){if(!value)throw new InvalidOperationException(message);}
    static bool Same(object a,object b){return Object.ReferenceEquals(a,b);}
    static void Case(string name,Action body){body();cases++;Console.WriteLine("PASS "+name);}
    static bool Throws<T>(Action action,string message=null) where T:Exception{try{action();return false;}catch(Exception error){return error.GetType()==typeof(T)&&(message==null||error.Message==message);}}
    static CPAMAFPANDM Key(Type type,string name){return new CPAMAFPANDM(type,name);}
    static void Run()
    {
        string first=new String(new[]{'n','a','m','e'}),second=new String(new[]{'n','a','m','e'});
        Case("typed same type and ordinal equal independent string references",()=>Need(!Same(first,second)&&Key(typeof(string),first).OFPEIHMPLIL(Key(typeof(string),second)),"value string equality"));
        Case("typed default keys equal",()=>Need(default(CPAMAFPANDM).OFPEIHMPLIL(default(CPAMAFPANDM)),"default key"));
        Case("typed same type null names equal",()=>Need(Key(typeof(string),null).OFPEIHMPLIL(Key(typeof(string),null)),"null name"));
        Case("typed same type empty names equal",()=>Need(Key(typeof(string),"").OFPEIHMPLIL(Key(typeof(string),"")),"empty name"));
        Case("typed null and empty names differ",()=>Need(!Key(typeof(string),null).OFPEIHMPLIL(Key(typeof(string),"")),"null versus empty"));
        Case("typed different types differ despite identical names",()=>Need(!Key(typeof(int),first).OFPEIHMPLIL(Key(typeof(string),first)),"different types"));
        Case("typed ordinal case difference retained",()=>Need(!Key(typeof(string),"Name").OFPEIHMPLIL(Key(typeof(string),"name")),"case sensitivity"));
        Case("typed one null type differs",()=>Need(!Key(null,first).OFPEIHMPLIL(Key(typeof(string),first))&&!Key(typeof(string),first).OFPEIHMPLIL(Key(null,first)),"null type comparison"));
        Case("typed both null types equal with equal names",()=>Need(Key(null,first).OFPEIHMPLIL(Key(null,second)),"null types and name values"));
        Case("typed both null types unequal with different names",()=>Need(!Key(null,"left").OFPEIHMPLIL(Key(null,"right")),"different names"));
        Case("object null rejected",()=>Need(!Key(typeof(string),first).Equals((object)null),"null object"));
        Case("object string rejected",()=>Need(!Key(typeof(string),first).Equals((object)first),"wrong boxed type string"));
        Case("object Type rejected",()=>Need(!Key(typeof(string),first).Equals((object)typeof(string)),"wrong boxed type Type"));
        Case("object exact boxed key compares field values",()=>Need(Key(typeof(string),first).Equals((object)Key(typeof(string),second)),"same boxed fields"));
        Case("object different type field differs",()=>Need(!Key(typeof(string),first).Equals((object)Key(typeof(int),first)),"boxed different Type"));
        Case("object different name field differs",()=>Need(!Key(typeof(string),"left").Equals((object)Key(typeof(string),"right")),"boxed different string"));
        Case("object default boxed key matches",()=>Need(default(CPAMAFPANDM).Equals((object)default(CPAMAFPANDM)),"boxed default"));
        Case("object null and empty names differ",()=>Need(!Key(typeof(string),null).Equals((object)Key(typeof(string),"")),"boxed null versus empty"));
        Case("hash null name keeps type hash times397",()=>Need(Key(typeof(string),null).GetHashCode()==unchecked(typeof(string).GetHashCode()*397),"null hash"));
        Case("hash empty name uses actual empty string hash",()=>Need(Key(typeof(string),"").GetHashCode()==unchecked((typeof(string).GetHashCode()*397)^"".GetHashCode()),"empty hash"));
        Case("equal independent strings produce equal hashes",()=>Need(Key(typeof(string),first).GetHashCode()==Key(typeof(string),second).GetHashCode(),"equal values hash"));
        Case("hash null type throws before null-name branch",()=>Need(Throws<NullReferenceException>(()=>Key(null,null).GetHashCode()),"null Type hash"));
        Case("hash null type throws with nonnull name",()=>Need(Throws<NullReferenceException>(()=>Key(null,"name").GetHashCode()),"null Type named hash"));
        Case("hash invokes exact virtual Type override once",()=>{var t=new ControlledHashType(7);Need(Key(t,"name").GetHashCode()==unchecked(7*397^"name".GetHashCode())&&t.Calls==1,"virtual hash receiver/count");});
        Case("hash positive signed overflow is unchecked32",()=>{var t=new ControlledHashType(Int32.MaxValue);Need(Key(t,null).GetHashCode()==unchecked(Int32.MaxValue*397)&&t.Calls==1,"positive unchecked overflow");});
        Case("hash negative signed overflow is unchecked32",()=>{var t=new ControlledHashType(Int32.MinValue);Need(Key(t,"name").GetHashCode()==unchecked(Int32.MinValue*397^"name".GetHashCode())&&t.Calls==1,"negative unchecked overflow");});
        Case("virtual Type hash exception propagates once",()=>{var t=new ControlledHashType(0){Throw=true};Need(Throws<ApplicationException>(()=>Key(t,"name").GetHashCode(),"controlled-type-hash-marker")&&t.Calls==1,"hash exception boundary");});
        var parent=new MNALHHOLFGL(null,"parent");
        Case("child allocates distinct object and passes exact original parent/name",()=>{ChildBoundary.Reset();var child=parent.MJHONDPGJFA(first);Need(!Same(child,parent)&&Same(child.ObservedParent,parent)&&Same(ChildBoundary.Parent,parent)&&Same(child.ObservedName,first)&&Same(ChildBoundary.Name,first)&&ChildBoundary.Calls==1,"child exact constructor boundary");});
        Case("child null name preserved",()=>{ChildBoundary.Reset();var child=parent.MJHONDPGJFA(null);Need(child.ObservedName==null&&ChildBoundary.Name==null&&ChildBoundary.Calls==1,"child null name");});
        Case("child empty name preserved",()=>{ChildBoundary.Reset();var child=parent.MJHONDPGJFA("");Need(child.ObservedName==""&&ChildBoundary.Name==""&&ChildBoundary.Calls==1,"child empty name");});
        Case("each child call allocates independently",()=>{ChildBoundary.Reset();var a=parent.MJHONDPGJFA(first);var b=parent.MJHONDPGJFA(first);Need(!Same(a,b)&&Same(a.ObservedParent,parent)&&Same(b.ObservedParent,parent)&&ChildBoundary.Calls==2,"fresh child per call");});
        Case("child constructor exception propagates without substitute",()=>{ChildBoundary.Reset();ChildBoundary.Throw=true;Need(Throws<ApplicationException>(()=>parent.MJHONDPGJFA(first),"controlled-child-constructor-marker")&&ChildBoundary.Calls==1&&Same(ChildBoundary.Parent,parent)&&Same(ChildBoundary.Name,first),"child constructor failure");});
        Need(cases==32,"exact finite32 cases");Console.WriteLine("RESULT thirty_two_key_child_controlled_effects_passed; production_SDK_or_provider_executed=false");
    }
    static string TypeName(TypeReference type){return type.FullName;}
    static string Signature(MethodReference method){return TypeName(method.ReturnType)+"("+String.Join(",",method.Parameters.Select(p=>TypeName(p.ParameterType)))+")";}
    static string AssemblyName(TypeReference type){return type.Scope is ModuleDefinition module?module.Assembly.Name.Name:((AssemblyNameReference)type.Scope).Name;}
    static void Framework(MethodReference method){Need(AssemblyName(method.DeclaringType)=="mscorlib","genuine scoped framework target");}
    static Instruction[] Calls(MethodDefinition method){return method.Body.Instructions.Where(i=>i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Callvirt||i.OpCode.Code==Code.Newobj).ToArray();}
    static FieldReference[] Fields(MethodDefinition method){return method.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldfld).Select(i=>(FieldReference)i.Operand).ToArray();}
    static void EqualCalls(MethodDefinition method)
    {
        var calls=Calls(method);Need(calls.Length==2&&calls.All(i=>i.OpCode.Code==Code.Call),"only exact two static equality calls");
        var a=(MethodReference)calls[0].Operand;var b=(MethodReference)calls[1].Operand;Framework(a);Framework(b);
        Need(a.DeclaringType.FullName=="System.Type"&&a.Name=="op_Equality"&&!a.HasThis&&Signature(a)=="System.Boolean(System.Type,System.Type)","actual source Type operator target");
        Need(b.DeclaringType.FullName=="System.String"&&b.Name=="Equals"&&!b.HasThis&&Signature(b)=="System.Boolean(System.String,System.String)","actual source same-native string Equals target");
        var fields=Fields(method);Need(fields.Select(f=>f.Name).SequenceEqual(new[]{"AFJAGKNNCBE","AFJAGKNNCBE","FEKLPCPODAH","FEKLPCPODAH"})&&fields.All(f=>f.DeclaringType.FullName=="CPAMAFPANDM"&&AssemblyName(f.DeclaringType)=="UJect.Runtime"),"exact own immutable key field reads in original order");
    }
    static void HashCall(Instruction instruction,string receiver)
    {
        Need(instruction.OpCode.Code==Code.Callvirt,"hash uses original virtual dispatch");var method=(MethodReference)instruction.Operand;Framework(method);
        // A compiler may name the base virtual declaration. All accepted owners
        // are the same original GetHashCode slot2; the field receiver remains
        // Type or string respectively. No unrelated method/signature is allowed.
        Need(method.Name=="GetHashCode"&&method.HasThis&&Signature(method)=="System.Int32()"&&(method.DeclaringType.FullName==receiver||method.DeclaringType.FullName=="System.Object"),"exact genuine hash virtual slot declaration");
    }
    static void Inspect(string originalPath,string donorPath)
    {
        var options=new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false};
        using(var original=ModuleDefinition.ReadModule(originalPath,options))using(var donor=ModuleDefinition.ReadModule(donorPath,options))
        {
            Need(original.Assembly.Name.Name=="UJect.Runtime"&&donor.Assembly.Name.Name=="UJect.Runtime","original-owner donor assembly scope");
            int count=0;
            foreach(var selector in new[]{Tuple.Create("MNALHHOLFGL","MJHONDPGJFA",0x0600002cu),Tuple.Create("CPAMAFPANDM","OFPEIHMPLIL",0x0600004eu),Tuple.Create("CPAMAFPANDM","Equals",0x0600004fu),Tuple.Create("CPAMAFPANDM","GetHashCode",0x06000050u)})
            {
                var a=original.Types.Single(t=>t.FullName==selector.Item1);var b=donor.Types.Single(t=>t.FullName==selector.Item1);var target=a.Methods.Single(m=>m.MetadataToken.ToUInt32()==selector.Item3);var selected=b.Methods.Single(m=>m.Name==selector.Item2);
                Need(target.Name==selected.Name&&target.Attributes==selected.Attributes&&target.ImplAttributes==selected.ImplAttributes&&Signature(target)==Signature(selected)&&!target.HasGenericParameters&&!selected.HasGenericParameters&&target.HasThis==selected.HasThis,"exact original member name/flags/signature/owner");
                Need(selected.HasBody&&!selected.Body.ExceptionHandlers.Any()&&!selected.IsPInvokeImpl,"only body-bearing non-PInvoke fragment");
                var ins=selected.Body.Instructions;Need(ins.All(i=>!(i.Operand is Instruction branch)||ins.Contains(branch))&&!ins.Any(i=>i.OpCode.Code==Code.Stfld||i.OpCode.Code==Code.Stsfld||i.OpCode.Code==Code.Ldsfld||i.OpCode.Code==Code.Calli),"closed managed branches and no hidden field writes/static state/indirect invocation");
                if(selector.Item2=="MJHONDPGJFA")
                {
                    Need(ins.Select(i=>i.OpCode.Code).SequenceEqual(new[]{Code.Ldarg_0,Code.Ldarg_1,Code.Newobj,Code.Ret}),"child exact this/name/new/return IL");var ctor=(MethodReference)Calls(selected).Single().Operand;Need(ctor.Name==".ctor"&&ctor.HasThis&&ctor.DeclaringType.FullName=="MNALHHOLFGL"&&AssemblyName(ctor.DeclaringType)=="UJect.Runtime"&&Signature(ctor)=="System.Void(MNALHHOLFGL,System.String)","exact original child ctor boundary");
                }
                else if(selector.Item2=="GetHashCode")
                {
                    var calls=Calls(selected);Need(calls.Length==2,"only two original hash calls");HashCall(calls[0],"System.Type");HashCall(calls[1],"System.String");Need(Fields(selected).Select(f=>f.Name).SequenceEqual(new[]{"AFJAGKNNCBE","FEKLPCPODAH"}),"type hash precedes single name read");Need(ins.Count(i=>i.OpCode.Code==Code.Mul)==1&&ins.Count(i=>i.OpCode.Code==Code.Xor)==1&&ins.Count(i=>i.OpCode.Code==Code.Ldc_I4&&(int)i.Operand==397)==1&&!ins.Any(i=>i.OpCode.Code==Code.Mul_Ovf||i.OpCode.Code==Code.Mul_Ovf_Un),"exact unchecked32 times397 XOR");Need(ins.Count(i=>i.OpCode.FlowControl==FlowControl.Cond_Branch)==1,"one raw name null branch");
                }
                else
                {
                    EqualCalls(selected);int branches=selector.Item2=="Equals"?2:1;Need(ins.Count(i=>i.OpCode.FlowControl==FlowControl.Cond_Branch)==branches,"original equality short circuit branch count");var test=ins.Where(i=>i.OpCode.Code==Code.Isinst).ToArray();var cast=ins.Where(i=>i.OpCode.Code==Code.Unbox_Any).ToArray();if(selector.Item2=="Equals")Need(test.Length==1&&cast.Length==1&&((TypeReference)test[0].Operand).FullName=="CPAMAFPANDM"&&((TypeReference)cast[0].Operand).FullName=="CPAMAFPANDM","exact boxed value type test and checked unbox copy");else Need(test.Length==0&&cast.Length==0,"plain typed equality no boxing");
                }
                count++;
            }
            var originalKey=original.Types.Single(t=>t.FullName=="CPAMAFPANDM");var donorKey=donor.Types.Single(t=>t.FullName=="CPAMAFPANDM");Need(originalKey.Fields.Count==2&&donorKey.Fields.Count==2,"exact key two fields");
            for(int i=0;i<2;i++){var a=originalKey.Fields[i];var b=donorKey.Fields[i];Need(a.Name==b.Name&&a.Attributes==b.Attributes&&a.FieldType.FullName==b.FieldType.FullName&&a.IsInitOnly&&a.IsPublic,"exact original immutable field contracts");}
            Need(originalKey.Interfaces.Count==1&&originalKey.Interfaces[0].InterfaceType.FullName.StartsWith("System.IComparable`1<")&&donorKey.Interfaces.Count==1&&donorKey.Interfaces[0].InterfaceType.FullName==originalKey.Interfaces[0].InterfaceType.FullName,"preserved original IComparable context without invented IEquatable");
            Need(count==4,"exact selected member count4");Console.WriteLine("RESULT four_original_key_child_member_bindings_passed; metadata_only_no_SDK_execution=true");
        }
    }
    public static int Main(string[] args)
    {
        try{if(args.Length==3&&args[0]=="--inspect")Inspect(args[1],args[2]);else{Need(args.Length==0,"exact controlled run args");Run();}return 0;}catch(Exception error){Console.Error.WriteLine(error);return 1;}
    }
}
