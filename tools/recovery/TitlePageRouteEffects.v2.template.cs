// Explicit test doubles in a separate namespace, not recovered SDK bodies.
// The exact source property span is inserted into RouteSubject without edits.
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Route = RecoveryRouteControlledEffects.RouteValue;

namespace RecoveryRouteControlledEffects
{
    sealed class RouteValue { }
    static class State
    {
        public static readonly List<string> Events=new List<string>();
        public static bool Init,ThrowInit,ThrowService,ThrowResolve,ThrowPredicate;
        public static Container Container;
        public static void Reset() { Events.Clear();Init=true;ThrowInit=ThrowService=ThrowResolve=ThrowPredicate=false;Container=new Container(); }
        public static void Event(string name,bool fail) { Events.Add(name);if(fail)throw new ApplicationException("controlled-"+name); }
    }
    sealed class PlatformManager { } // Type argument only in the controlled subject.
    static class SingletonMonoBehaviour<T>
    { public static bool IsInitialized { get { State.Event("initialized",State.ThrowInit);return State.Init; } } }
    interface MCCKDPKLCIN { bool SupportsPortraitMode { get; } }
    sealed class Capabilities : MCCKDPKLCIN
    {
        public bool Value;public Action OnRead;
        public bool SupportsPortraitMode { get { State.Event("predicate",State.ThrowPredicate);if(OnRead!=null)OnRead();return Value; } }
    }
    sealed class Container
    {
        public MCCKDPKLCIN Value=new Capabilities();
        public T HHCPOGCCGNF<T>(string name)
        { State.Event("resolve",State.ThrowResolve);if(typeof(T)!=typeof(MCCKDPKLCIN) || name!=null)throw new Exception("typed/null resolution changed");return (T)Value; }
    }
    static class MPAAIECKLGA
    { public static Container CFHDLGEGDFD { get { State.Event("service",State.ThrowService);return State.Container; } } }
    sealed class RouteSubject
    {
        private bool routeIsDifferentOnMobile;
        private Route route,mobileRoute;
        public RouteSubject(bool flag,Route normal,Route mobile) { routeIsDifferentOnMobile=flag;route=normal;mobileRoute=mobile; }
        public void SetRoutes(Route normal,Route mobile) { route=normal;mobileRoute=mobile; }
        /*EXACT_ROUTE_PROPERTY*/
    }
    static class Program
    {
        static void Need(bool value,string message) { if(!value)throw new Exception(message); }
        static void Events(params string[] expected) { Need(State.Events.SequenceEqual(expected),"effect order/count"); }
        static void Same(object a,object b) { Need(Object.ReferenceEquals(a,b),"stored route identity"); }
        static void Effects()
        {
            var normal=new Route();var mobile=new Route();
            State.Reset();Same(new RouteSubject(false,normal,mobile).Route,normal);Events();
            State.Reset();State.Init=false;Same(new RouteSubject(true,normal,mobile).Route,normal);Events("initialized");
            State.Reset();Same(new RouteSubject(true,normal,mobile).Route,normal);Events("initialized","service","resolve","predicate");
            State.Reset();((Capabilities)State.Container.Value).Value=true;Same(new RouteSubject(true,normal,mobile).Route,mobile);Events("initialized","service","resolve","predicate");
            State.Reset();Same(new RouteSubject(false,null,mobile).Route,null);Events();
            State.Reset();((Capabilities)State.Container.Value).Value=true;Same(new RouteSubject(true,normal,null).Route,null);Events("initialized","service","resolve","predicate");
            State.Reset();State.Container=null;bool threw=false;
            try { var unused=new RouteSubject(true,normal,mobile).Route; } catch(NullReferenceException) { threw=true; }
            Need(threw,"null service propagates");Events("initialized","service");
            State.Reset();State.Container.Value=null;threw=false;
            try { var unused=new RouteSubject(true,normal,mobile).Route; } catch(NullReferenceException) { threw=true; }
            Need(threw,"null resolution propagates");Events("initialized","service","resolve");
            foreach(var stage in new[]{"initialized","service","resolve","predicate"})
            {
                State.Reset();State.ThrowInit=stage=="initialized";State.ThrowService=stage=="service";State.ThrowResolve=stage=="resolve";State.ThrowPredicate=stage=="predicate";threw=false;
                try { var unused=new RouteSubject(true,normal,mobile).Route; } catch(ApplicationException e) { threw=e.Message=="controlled-"+stage; }
                Need(threw,"dependency exception propagates");var all=new[]{"initialized","service","resolve","predicate"};Events(all.Take(Array.IndexOf(all,stage)+1).ToArray());
            }
            State.Reset();var changed=new Route();var subject=new RouteSubject(true,normal,mobile);var cap=(Capabilities)State.Container.Value;cap.Value=true;cap.OnRead=()=>subject.SetRoutes(normal,changed);Same(subject.Route,changed);Events("initialized","service","resolve","predicate");
            Console.WriteLine("{\"status\":\"thirteen_exact_Route_controlled_effect_cases_passed\",\"cases\":13,\"production_SDK_callees_executed\":false,\"working_title_claimed\":false}");
        }
        static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows)
        { foreach(var row in rows) { yield return row;foreach(var child in Types(row.NestedTypes))yield return child; } }
        static string PropertyGetter(string path,string owner,string property)
        {
            using(var m=ModuleDefinition.ReadModule(path,new ReaderParameters{ReadingMode=ReadingMode.Deferred,InMemory=false,ReadSymbols=false}))
                return Types(m.Types).Single(x=>x.FullName==owner).Properties.Single(x=>x.Name==property).GetMethod.Name;
        }
        static void Inspect(string path,string initialization,string interfaces)
        {
            string serviceName=PropertyGetter(initialization,"MPAAIECKLGA","CFHDLGEGDFD");
            string capabilityName=PropertyGetter(interfaces,"MCCKDPKLCIN","SupportsPortraitMode");
            using(var m=ModuleDefinition.ReadModule(path,new ReaderParameters{ReadingMode=ReadingMode.Deferred,InMemory=false,ReadSymbols=false}))
            {
                var type=Types(m.Types).Single(x=>x.FullName=="RRUI.Data.TitleScreenFlowModel/TitleScreenPage");
                var getter=type.Methods.Single(x=>x.Name=="get_Route" && x.Parameters.Count==0);
                Need(getter.ReturnType.FullName=="RRUI.Navigation.Route" && getter.HasBody,"real nested getter signature");
                var calls=getter.Body.Instructions.Select(x=>x.Operand as MethodReference).Where(x=>x!=null).ToArray();
                Need(calls.Length==4,"exact four real application calls");
                Need(calls[0].Name=="get_IsInitialized" && calls[0].DeclaringType.FullName=="SingletonMonoBehaviour`1<PlatformManager>" && calls[0].ReturnType.FullName=="System.Boolean" && calls[0].Parameters.Count==0,"exact platform singleton getter");
                Need(calls[1].Name==serviceName && calls[1].DeclaringType.FullName=="MPAAIECKLGA" && calls[1].ReturnType.FullName=="MNALHHOLFGL" && calls[1].Parameters.Count==0,"exact original service PropertyDef getter");
                var resolve=calls[2] as GenericInstanceMethod;
                Need(resolve!=null && resolve.Name=="HHCPOGCCGNF" && resolve.DeclaringType.FullName=="MNALHHOLFGL" && resolve.GenericArguments.Count==1 && resolve.GenericArguments[0].FullName=="MCCKDPKLCIN" && resolve.Parameters.Count==1 && resolve.Parameters[0].ParameterType.FullName=="System.String","exact generic typed service resolution");
                Need(calls[3].Name==capabilityName && calls[3].DeclaringType.FullName=="MCCKDPKLCIN" && calls[3].ReturnType.FullName=="System.Boolean" && calls[3].Parameters.Count==0,"exact interface slot5 PropertyDef getter");
                var fields=getter.Body.Instructions.Select(x=>x.Operand as FieldReference).Where(x=>x!=null).ToArray();
                Need(fields.Length==4 && fields.All(x=>x.DeclaringType.FullName==type.FullName) && fields.Count(x=>x.Name=="routeIsDifferentOnMobile" && x.FieldType.FullName=="System.Boolean")==1 && fields.Count(x=>x.Name=="route" && x.FieldType.FullName=="RRUI.Navigation.Route")==2 && fields.Count(x=>x.Name=="mobileRoute" && x.FieldType.FullName=="RRUI.Navigation.Route")==1,"exact original three serialized field bindings");
                var call=getter.Body.Instructions.Single(x=>Object.ReferenceEquals(x.Operand,resolve));Need(call.Previous.OpCode.Code==Mono.Cecil.Cil.Code.Ldnull,"exact null resolver name");
                Need(!getter.Body.Instructions.Any(x=>x.OpCode.Code==Mono.Cecil.Cil.Code.Newobj),"no fabricated Route construction");
                Console.WriteLine("{\"status\":\"actual_full_Route_file_typed_binding_verified_metadata_only\",\"members\":1,\"game_or_SDK_code_invoked\":false}");
            }
        }
        static int Main(string[] args)
        {
            try { if(args.Length==0)Effects();else if(args.Length==4 && args[0]=="--inspect")Inspect(args[1],args[2],args[3]);else throw new Exception("invalid controlled fixture arguments");return 0; }
            catch(Exception e) { Console.Error.WriteLine(e.GetType().Name+": "+e.Message);return 1; }
        }
    }
}
