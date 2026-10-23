// Test-only subjects. Exact candidate spans replace the two markers below.
// These types are deliberately not production game types or callee restorations.
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace RecoveryTitleLoginControlledEffects
{
    interface IFlow { }
    sealed class Flow : IFlow { }
    sealed class GetterSubject
    {
        private Flow flowModel;
        public GetterSubject(Flow value) { flowModel = value; }
        public IFlow FlowModel { /*EXACT_FLOWMODEL_GETTER*/ }
    }
    sealed class Route { }
    sealed class Page
    {
        public readonly List<string> Events;
        public Route Value;
        public bool Throw;
        public Page(List<string> events, Route value) { Events=events; Value=value; }
        public Route Route { get { Events.Add("route"); if(Throw) throw new ApplicationException("controlled-route"); return Value; } }
    }
    sealed class Browser
    {
        public readonly List<string> Events;
        public int Calls;
        public Route Seen;
        public bool Flag;
        public Browser(List<string> events) { Events=events; }
        public void GoTo(Route route, bool flag) { Events.Add("navigate"); Calls++; Seen=route; Flag=flag; }
        public static bool operator ==(Browser x, Browser y) { throw new Exception("operator equality must not execute"); }
        public static bool operator !=(Browser x, Browser y) { throw new Exception("operator inequality must not execute"); }
        public override bool Equals(object value) { throw new Exception("Equals must not execute"); }
        public override int GetHashCode() { return 1; }
    }
    sealed class LoginSubject
    {
        private readonly List<string> events;
        private readonly Browser value;
        private readonly Page loginPage;
        public LoginSubject(List<string> events, Browser value, Page page) { this.events=events; this.value=value; loginPage=page; }
        private Browser BrowserModel { get { events.Add("browser"); return value; } }
        /*EXACT_GOTOLOGIN_METHOD*/
    }
    static class Program
    {
        static void Need(bool value,string message) { if(!value) throw new Exception(message); }
        static void Events(List<string> value,params string[] expected) { Need(value.SequenceEqual(expected),"effect order/count"); }
        static void Effects()
        {
            var flow=new Flow(); Need(Object.ReferenceEquals(new GetterSubject(flow).FlowModel,flow),"getter identity");
            Need(Object.ReferenceEquals(new GetterSubject(null).FlowModel,null),"getter null");
            var e=new List<string>(); var route=new Route(); var page=new Page(e,route);
            new LoginSubject(e,null,page).GoToLogin(); Events(e,"browser");
            e.Clear(); new LoginSubject(e,null,null).GoToLogin(); Events(e,"browser");
            e.Clear(); var browser=new Browser(e); new LoginSubject(e,browser,page).GoToLogin();
            Events(e,"browser","route","navigate"); Need(browser.Calls==1 && Object.ReferenceEquals(browser.Seen,route) && browser.Flag==false,"same route once and false");
            e.Clear(); browser=new Browser(e); bool threw=false;
            try { new LoginSubject(e,browser,null).GoToLogin(); } catch(NullReferenceException) { threw=true; }
            Need(threw && browser.Calls==0,"null page before navigation"); Events(e,"browser");
            e.Clear(); browser=new Browser(e); new LoginSubject(e,browser,new Page(e,null)).GoToLogin();
            Need(browser.Calls==1 && Object.ReferenceEquals(browser.Seen,null) && !browser.Flag,"null route forwarded"); Events(e,"browser","route","navigate");
            e.Clear(); browser=new Browser(e); page=new Page(e,route);page.Throw=true;threw=false;
            try { new LoginSubject(e,browser,page).GoToLogin(); } catch(ApplicationException) { threw=true; }
            Need(threw && browser.Calls==0,"route exception before navigation"); Events(e,"browser","route");
            Console.WriteLine("{\"status\":\"eight_controlled_effect_cases_passed\",\"cases\":8,\"exact_candidate_spans\":true,\"production_callees_executed\":false,\"working_login_claimed\":false}");
        }
        static IEnumerable<TypeDefinition> Types(IEnumerable<TypeDefinition> rows)
        { foreach(var row in rows) { yield return row; foreach(var nested in Types(row.NestedTypes)) yield return nested; } }
        static void Inspect(string path)
        {
            // Metadata only: no Assembly.Load, Resolve or invocation of game code.
            using(var module=ModuleDefinition.ReadModule(path,new ReaderParameters { ReadingMode=ReadingMode.Deferred, InMemory=false, ReadSymbols=false }))
            {
                var all=Types(module.Types).ToArray();
                var manager=all.Single(x=>x.FullName=="TitleScreenManager");
                var getter=manager.Methods.Single(x=>x.Name=="get_FlowModel" && x.Parameters.Count==0);
                Need(getter.ReturnType.FullName=="AIOCIBMFJEJ" && getter.HasBody,"real getter signature");
                var il=getter.Body.Instructions.Where(x=>x.OpCode.Code!=Code.Nop).ToArray();
                var fields=il.Select(x=>x.Operand as FieldReference).Where(x=>x!=null).ToArray();
                Need(fields.Length==1 && fields[0].Name=="flowModel" && fields[0].DeclaringType.FullName=="TitleScreenManager" && fields[0].FieldType.FullName=="RRUI.Data.TitleScreenFlowModel","real serialized field binding");
                Need(il.Count(x=>x.OpCode.Code==Code.Ldfld)==1 && il.Last().OpCode.Code==Code.Ret && !il.Any(x=>x.Operand is MethodReference),"getter load without guessed callees");
                var flow=all.Single(x=>x.FullName=="RRUI.Data.TitleScreenFlowModel");
                var method=flow.Methods.Single(x=>x.Name=="GoToLogin" && x.Parameters.Count==0);
                Need(method.ReturnType.FullName=="System.Void" && method.HasBody,"real GoToLogin signature");
                il=method.Body.Instructions.Where(x=>x.OpCode.Code!=Code.Nop).ToArray();
                fields=il.Select(x=>x.Operand as FieldReference).Where(x=>x!=null).ToArray();
                Need(fields.Length==1 && fields[0].Name=="loginPage" && fields[0].DeclaringType.FullName==flow.FullName && fields[0].FieldType.FullName=="RRUI.Data.TitleScreenFlowModel/TitleScreenPage","real page field binding");
                var calls=il.Select(x=>x.Operand as MethodReference).Where(x=>x!=null).ToArray();
                Need(calls.Length==4,"exact four managed caller targets");
                Need(calls[0].Name=="get_BrowserModel" && calls[0].DeclaringType.FullName.StartsWith("RRUI.Data.RRUIModel`1<",StringComparison.Ordinal) && calls[0].ReturnType.FullName=="RRUI.Data.BrowserModel" && calls[0].Parameters.Count==0,"real inherited browser getter binding");
                Need(calls[1].FullName=="System.Boolean System.Object::ReferenceEquals(System.Object,System.Object)","raw reference-null binding");
                Need(calls[2].FullName=="RRUI.Navigation.Route RRUI.Data.TitleScreenFlowModel/TitleScreenPage::get_Route()","real route getter binding");
                Need(calls[3].FullName=="System.Void RRUI.Data.BrowserModel::GoTo(RRUI.Navigation.Route,System.Boolean)","real GoTo overload binding");
                var goIndex=Array.FindIndex(il,x=>Object.ReferenceEquals(x.Operand,calls[3]));
                Need(goIndex>0 && il[goIndex-1].OpCode.Code==Code.Ldc_I4_0,"false argument bound");
                Console.WriteLine("{\"status\":\"actual_full_file_typed_binding_verified_metadata_only\",\"members\":2,\"original_game_code_invoked\":false}");
            }
        }
        static int Main(string[] args)
        {
            try { if(args.Length==0) Effects(); else if(args.Length==2 && args[0]=="--inspect") Inspect(args[1]); else throw new Exception("invalid fixture arguments"); return 0; }
            catch(Exception e) { Console.Error.WriteLine(e.GetType().Name+": "+e.Message); return 1; }
        }
    }
}
