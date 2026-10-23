// Exact candidate members run only with these explicit test-only boundaries.
// No production Unity/game/SDK/audio/iterator/network implementation executes.
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
namespace TitleMusicControlled
{
    static class Effects
    {
        internal static List<string> Calls=new List<string>();internal static string ThrowAt;
        internal static void Call(string value){Calls.Add(value);if(ThrowAt==value)throw new ApplicationException(value);}
        internal static void Reset(){Calls.Clear();ThrowAt=null;AudioManager.Clip=null;AudioManager.OnRead=null;AudioManager.OnStop=null;PlatformManager.Value=null;UObject.OnEqual=null;}
    }
    class UObject
    {
        internal bool Destroyed;internal static Action<UObject,UObject> OnEqual;
        public static bool operator ==(UObject a,UObject b){Effects.Call(a is FlowModel||b is FlowModel?"flow-equality":"clip-equality");OnEqual?.Invoke(a,b);bool an=ReferenceEquals(a,null)||(!ReferenceEquals(a,null)&&a.Destroyed),bn=ReferenceEquals(b,null)||(!ReferenceEquals(b,null)&&b.Destroyed);return an&&bn||!an&&!bn&&ReferenceEquals(a,b);}
        public static bool operator !=(UObject a,UObject b){return !(a==b);}
        public override bool Equals(object o){return ReferenceEquals(this,o);}public override int GetHashCode(){return base.GetHashCode();}
    }
    sealed class AudioClip:UObject{}
    // Both are ordinary references in the original metadata, with no Unity op.
    sealed class Coroutine {internal string Name;}
    sealed class RecRoomAudioClip {public AudioClip audioClip;}
    sealed class FlowModel:UObject
    {
        internal bool Interstitial,Chat,Feed,Account;internal Action<string> OnRead;
        bool Read(string name,bool value){Effects.Call(name);OnRead?.Invoke(name);return value;}
        public bool IsInInterstitialState{get{return Read("interstitial",Interstitial);}}
        public bool IsInChatState{get{return Read("chat",Chat);}}
        public bool IsInFeedState{get{return Read("feed",Feed);}}
        public bool IsInAccountCreationState{get{return Read("account",Account);}}
    }
    enum KDHPMLNMNNO{Other=0,Stop=1}
    sealed class PlatformManager
    {
        internal static PlatformManager Value;internal KDHPMLNMNNO Launcher;
        public static PlatformManager Instance {get{Effects.Call("platform");return Value;}}
        public KDHPMLNMNNO CurrentUnityLauncher {get{Effects.Call("launcher");return Launcher;}}
    }
    static class AudioManager
    {
        internal static AudioClip Clip;internal static Action OnRead,OnStop;
        public static AudioClip CurrentMusicAudioClip(){Effects.Call("current");OnRead?.Invoke();return Clip;}
        public static void StopMusic(){Effects.Call("audio-stop");OnStop?.Invoke();}
    }
    sealed class StateSubject<T>
    {
        private ushort MFHOAFKBLGN;
        internal StateSubject(ushort value){MFHOAFKBLGN=value;}
        public ushort CPDFJCCALIA {get{return /*EXACT_STATE_EXPRESSION*/;}}
    }
    sealed class PredicateSubject
    {
        internal StateSubject<object> BGBIFFLGANM;
        /*EXACT_IsInAccountCreationState*/
        /*EXACT_IsInChatState*/
        /*EXACT_IsInFeedState*/
        /*EXACT_IsInInterstitialState*/
    }
    sealed class Subject
    {
        internal FlowModel flowModel;internal RecRoomAudioClip titleScreenMusic,accountCreationMusic;internal Coroutine HEGLMMJABEN;
        internal Coroutine Started=new Coroutine{Name="new"};internal IEnumerator SeenIterator;internal Coroutine SeenStopped;internal Action OnStart,OnCoroutineStop;
        Coroutine StartCoroutine(IEnumerator routine){Effects.Call("start");SeenIterator=routine;OnStart?.Invoke();return Started;}
        void StopCoroutine(Coroutine coroutine){Effects.Call("coroutine-stop");SeenStopped=coroutine;OnCoroutineStop?.Invoke();}
        sealed class BBOMFKCKKEP:IEnumerator
        {
            private int _003C_003E1__state;public Subject _003C_003E4__this;
            /*EXACT_BBOMFKCKKEP_ctor*/
            public object Current{get{throw new InvalidOperationException("unrecovered iterator body invoked");}}
            public bool MoveNext(){throw new InvalidOperationException("unrecovered iterator body invoked");}public void Reset(){throw new InvalidOperationException("unrecovered iterator body invoked");}
            internal int State{get{return _003C_003E1__state;}}
        }
        sealed class EPCGHFICLMA:IEnumerator
        {
            private int _003C_003E1__state;public Subject _003C_003E4__this;
            /*EXACT_EPCGHFICLMA_ctor*/
            public object Current{get{throw new InvalidOperationException("unrecovered iterator body invoked");}}
            public bool MoveNext(){throw new InvalidOperationException("unrecovered iterator body invoked");}public void Reset(){throw new InvalidOperationException("unrecovered iterator body invoked");}
            internal int State{get{return _003C_003E1__state;}}
        }
        /*EXACT_TITLE_MUSIC_METHODS*/
        internal void Run(float v=0){NMJIFHLPFNP(v);}internal void Stop(){MLOEPDOPGJD();}internal void Start(IEnumerator routine){NDENAIFEGGC(routine);}
        internal IEnumerator TitleFactory(){return KJNOGCGEIHD();}internal IEnumerator AccountFactory(){return MDLLPIFKLJO();}
        internal bool IteratorMatches(IEnumerator value,bool account){return account?value is EPCGHFICLMA&&((EPCGHFICLMA)value).State==0&&ReferenceEquals(((EPCGHFICLMA)value)._003C_003E4__this,this):value is BBOMFKCKKEP&&((BBOMFKCKKEP)value).State==0&&ReferenceEquals(((BBOMFKCKKEP)value)._003C_003E4__this,this);}
    }
    static class Program
    {
        static int cases;static void Need(bool v,string m){if(!v)throw new InvalidOperationException(m);}
        static void Case(string n,Action a){Effects.Reset();a();cases++;Console.WriteLine("PASS "+n);}
        static bool Throws<T>(Action a)where T:Exception{try{a();return false;}catch(Exception e){return e.GetType()==typeof(T);}}
        static void Order(params string[] v){Need(Effects.Calls.SequenceEqual(v),"ordered effects: "+String.Join(",",Effects.Calls));}
        static Subject New(){PlatformManager.Value=new PlatformManager();return new Subject{flowModel=new FlowModel(),titleScreenMusic=new RecRoomAudioClip{audioClip=new AudioClip()},accountCreationMusic=new RecRoomAudioClip{audioClip=new AudioClip()}};}
        static readonly string[] Prefix={"flow-equality","interstitial","current","chat","feed","account"};
        static string[] P(params string[] tail){return Prefix.Concat(tail).ToArray();}
        static void Run()
        {
            Case("all65536 ushort values match four original unsigned predicates",()=>{for(int i=0;i<=65535;i++){var p=new PredicateSubject{BGBIFFLGANM=new StateSubject<object>((ushort)i)};Need(p.IsInAccountCreationState==(i>=17&&i<=34)&&p.IsInChatState==(i>=54&&i<=55)&&p.IsInFeedState==(i==56)&&p.IsInInterstitialState==(i==33||i==52),"exhaustive original predicate bounds");}Order();});
            Case("all four predicates raw-null state throws",()=>{var p=new PredicateSubject();Need(Throws<NullReferenceException>(()=>{var v=p.IsInAccountCreationState;})&&Throws<NullReferenceException>(()=>{var v=p.IsInChatState;})&&Throws<NullReferenceException>(()=>{var v=p.IsInFeedState;})&&Throws<NullReferenceException>(()=>{var v=p.IsInInterstitialState;}),"raw state null");Order();});
            Case("raw ushort getter keeps instance and type contexts independent",()=>{Need(new StateSubject<object>(65535).CPDFJCCALIA==65535&&new StateSubject<string>(17).CPDFJCCALIA==17&&new StateSubject<object>(0).CPDFJCCALIA==0,"exact raw field values");Order();});
            Case("title factory allocates fresh exact state0 iterator with same this",()=>{var s=New();var a=s.TitleFactory();var b=s.TitleFactory();Need(s.IteratorMatches(a,false)&&s.IteratorMatches(b,false)&&!ReferenceEquals(a,b),"title identity and capture");Order();});
            Case("account factory allocates fresh exact state0 iterator with same this",()=>{var s=New();var a=s.AccountFactory();Need(s.IteratorMatches(a,true),"account identity and capture");Order();});
            Case("stop always audio-stops even raw null handle",()=>{var s=New();s.Stop();Need(ReferenceEquals(s.HEGLMMJABEN,null),"null retained");Order("audio-stop");});
            Case("audio failure precedes handle reads and preserves handle",()=>{var s=New();var old=s.HEGLMMJABEN=new Coroutine();Effects.ThrowAt="audio-stop";Need(Throws<ApplicationException>(()=>s.Stop())&&ReferenceEquals(old,s.HEGLMMJABEN),"audio failure unchanged");Order("audio-stop");});
            Case("stop reads handle after audio effect then clears",()=>{var s=New();var fresh=new Coroutine();AudioManager.OnStop=()=>s.HEGLMMJABEN=fresh;s.Stop();Need(ReferenceEquals(s.SeenStopped,fresh)&&ReferenceEquals(s.HEGLMMJABEN,null),"fresh post audio handle");Order("audio-stop","coroutine-stop");});
            Case("coroutine stop failure preserves current handle",()=>{var s=New();var old=s.HEGLMMJABEN=new Coroutine();Effects.ThrowAt="coroutine-stop";Need(Throws<ApplicationException>(()=>s.Stop())&&ReferenceEquals(old,s.HEGLMMJABEN),"stop failure");Order("audio-stop","coroutine-stop");});
            Case("clear occurs after coroutine-stop callback",()=>{var s=New();s.HEGLMMJABEN=new Coroutine();s.OnCoroutineStop=()=>s.HEGLMMJABEN=new Coroutine();s.Stop();Need(ReferenceEquals(s.HEGLMMJABEN,null),"final clear after effect");Order("audio-stop","coroutine-stop");});
            Case("start stops first then forwards exact iterator and stores return",()=>{var s=New();s.HEGLMMJABEN=new Coroutine();var iterator=s.TitleFactory();s.Start(iterator);Need(ReferenceEquals(s.SeenIterator,iterator)&&ReferenceEquals(s.HEGLMMJABEN,s.Started),"same iterator and return");Order("audio-stop","coroutine-stop","start");});
            Case("start stop failure suppresses start and store",()=>{var s=New();var old=s.HEGLMMJABEN=new Coroutine();Effects.ThrowAt="audio-stop";Need(Throws<ApplicationException>(()=>s.Start(null))&&ReferenceEquals(old,s.HEGLMMJABEN)&&ReferenceEquals(s.SeenIterator,null),"stop-before-start failure");Order("audio-stop");});
            Case("start failure follows completed stop and preserves cleared handle",()=>{var s=New();s.HEGLMMJABEN=new Coroutine();Effects.ThrowAt="start";Need(Throws<ApplicationException>(()=>s.Start(s.TitleFactory()))&&ReferenceEquals(s.HEGLMMJABEN,null),"start failure no store");Order("audio-stop","coroutine-stop","start");});
            Case("null iterator is forwarded without added guard",()=>{var s=New();s.Start(null);Need(ReferenceEquals(s.SeenIterator,null)&&ReferenceEquals(s.HEGLMMJABEN,s.Started),"exact null iterator boundary");Order("audio-stop","start");});
            Case("Unity-null flow suppresses predicates and audio",()=>{var s=New();s.flowModel=null;s.Run();Order("clip-equality");});
            Case("destroyed-style flow uses Unity equality and returns",()=>{var s=New();s.flowModel.Destroyed=true;s.Run();Order("flow-equality");});
            Case("Unity flow operator exception propagates first",()=>{var s=New();Effects.ThrowAt="flow-equality";Need(Throws<ApplicationException>(()=>s.Run()),"equality exception");Order("flow-equality");});
            Case("fresh raw flow read after equality is required",()=>{var s=New();UObject.OnEqual=(a,b)=>s.flowModel=null;Need(Throws<NullReferenceException>(()=>s.Run()),"fresh field null");Order("flow-equality");});
            Case("interstitial exits before current audio read",()=>{var s=New();s.flowModel.Interstitial=true;s.Run();Order("flow-equality","interstitial");});
            Case("current music failure suppresses remaining state reads",()=>{var s=New();Effects.ThrowAt="current";Need(Throws<ApplicationException>(()=>s.Run()),"current failure");Order("flow-equality","interstitial","current");});
            Case("chat true short-circuits feed and stops current clip",()=>{var s=New();AudioManager.Clip=new AudioClip();s.flowModel.Chat=true;s.Run();Order("flow-equality","interstitial","current","chat","clip-equality","audio-stop");});
            Case("feed true only after chat false suppresses account and platform",()=>{var s=New();s.flowModel.Feed=true;AudioManager.Clip=new AudioClip();s.Run();Order("flow-equality","interstitial","current","chat","feed","clip-equality","audio-stop");});
            Case("chat with Unity-null current does not stop",()=>{var s=New();s.flowModel.Chat=true;AudioManager.Clip=new AudioClip{Destroyed=true};s.Run();Order("flow-equality","interstitial","current","chat","clip-equality");});
            Case("account branch bypasses platform and starts exact account iterator",()=>{var s=New();s.flowModel.Account=true;PlatformManager.Value=null;s.Run(Single.NaN);Need(s.IteratorMatches(s.SeenIterator,true),"account iterator");Order(P("audio-stop","start"));});
            Case("launcher1 stops current without reading selected clips",()=>{var s=New();PlatformManager.Value.Launcher=KDHPMLNMNNO.Stop;AudioManager.Clip=new AudioClip();s.Run();Order(P("platform","launcher","clip-equality","audio-stop"));});
            Case("raw null platform throws after account false",()=>{var s=New();PlatformManager.Value=null;Need(Throws<NullReferenceException>(()=>s.Run()),"raw platform null");Order(P("platform"));});
            Case("title matching clip with existing handle returns",()=>{var s=New();s.HEGLMMJABEN=new Coroutine();AudioManager.Clip=s.titleScreenMusic.audioClip;s.Run();Order(P("platform","launcher","clip-equality"));});
            Case("account matching clip with existing handle returns",()=>{var s=New();s.flowModel.Account=true;s.HEGLMMJABEN=new Coroutine();AudioManager.Clip=s.accountCreationMusic.audioClip;s.Run();Order(P("clip-equality"));});
            Case("raw-null music wrapper yields null clip for Unity comparison",()=>{var s=New();s.titleScreenMusic=null;s.HEGLMMJABEN=new Coroutine();s.Run();Order(P("platform","launcher","clip-equality"));});
            Case("no handle suppresses clip comparison and starts title iterator",()=>{var s=New();AudioManager.Clip=s.titleScreenMusic.audioClip;s.Run(-1);Need(s.IteratorMatches(s.SeenIterator,false),"title iterator");Order(P("platform","launcher","audio-stop","start"));});
            Case("clip equality failure suppresses allocation and start",()=>{var s=New();s.HEGLMMJABEN=new Coroutine();Effects.ThrowAt="clip-equality";Need(Throws<ApplicationException>(()=>s.Run())&&ReferenceEquals(s.SeenIterator,null),"clip comparison failure");Order(P("platform","launcher","clip-equality"));});
            Case("selected clip arguments captured before equality callback",()=>{var s=New();s.HEGLMMJABEN=new Coroutine();var old=s.titleScreenMusic;AudioManager.Clip=old.audioClip;UObject.OnEqual=(a,b)=>{if(a is AudioClip){Need(ReferenceEquals(b,old.audioClip),"captured selected audio clip");s.titleScreenMusic=new RecRoomAudioClip();}};s.Run();Order(P("platform","launcher","clip-equality"));});
            Case("captured current clip retained across later launcher effect",()=>{var s=New();var old=AudioManager.Clip=s.titleScreenMusic.audioClip;s.HEGLMMJABEN=new Coroutine();s.flowModel.OnRead=n=>{if(n=="account")AudioManager.Clip=new AudioClip();};s.Run();Need(!ReferenceEquals(old,AudioManager.Clip),"later current source changed");Order(P("platform","launcher","clip-equality"));});
            Case("launcher exception suppresses selected music and start",()=>{var s=New();Effects.ThrowAt="launcher";Need(Throws<ApplicationException>(()=>s.Run()),"launcher failure");Order(P("platform","launcher"));});
            Case("each state exception propagates before following boundaries",()=>{foreach(var name in new[]{"interstitial","chat","feed","account"}){Effects.Reset();var s=New();Effects.ThrowAt=name;Need(Throws<ApplicationException>(()=>s.Run()),"state exception "+name);var expected=Prefix.Take(Array.IndexOf(Prefix,name)+1);Need(Effects.Calls.SequenceEqual(expected),"state failure prefix "+name);}});
            Need(cases==35,"exact35 distinct controlled cases");Console.WriteLine("RESULT thirty_five_original_music_slice_effects_passed; production_game_Unity_audio_iterator_network_executed=false");
        }
        static string Sig(MethodReference m){return m.ReturnType.FullName+"("+String.Join(",",m.Parameters.Select(p=>p.ParameterType.FullName))+")";}
        static Instruction[] Calls(MethodDefinition m){return m.Body.Instructions.Where(i=>i.OpCode.Code==Code.Call||i.OpCode.Code==Code.Callvirt||i.OpCode.Code==Code.Newobj).ToArray();}
        static MethodDefinition Method(TypeDefinition t,string n){return t.Methods.Single(m=>m.Name==n);}
        static void Same(MethodDefinition raw,MethodDefinition now){Need(raw.Attributes==now.Attributes&&raw.ImplAttributes==now.ImplAttributes&&Sig(raw)==Sig(now)&&now.HasBody&&!now.Body.ExceptionHandlers.Any(),"exact original signature and flags "+now.FullName);}
        static void Field(FieldReference a,FieldDefinition b){Need(a.Name==b.Name&&a.FieldType.FullName==b.FieldType.FullName&&a.DeclaringType.FullName==b.DeclaringType.FullName,"same original field "+b.FullName);}
        static void Inspect(string compiledPath,string originalPath)
        {
            var opts=new ReaderParameters{ReadingMode=ReadingMode.Deferred,ReadSymbols=false};
            using(var c=ModuleDefinition.ReadModule(compiledPath,opts))using(var o=ModuleDefinition.ReadModule(originalPath,opts))
            {
                Need(c.Assembly.Name.Name=="Assembly-CSharp"&&o.Assembly.Name.Name=="Assembly-CSharp","actual full-source metadata only");
                var t=c.Types.Single(x=>x.FullName=="TitleScreenManager");var r=o.Types.Single(x=>x.FullName=="TitleScreenManager"&&x.MetadataToken.ToUInt32()==0x02000145);
                foreach(var x in new[]{Tuple.Create("NDENAIFEGGC",0x060008a8u),Tuple.Create("MLOEPDOPGJD",0x060008a9u),Tuple.Create("NMJIFHLPFNP",0x060008aau),Tuple.Create("KJNOGCGEIHD",0x060008abu),Tuple.Create("MDLLPIFKLJO",0x060008acu)})Same(r.Methods.Single(m=>m.MetadataToken.ToUInt32()==x.Item2&&m.Name==x.Item1),Method(t,x.Item1));
                var start=Method(t,"NDENAIFEGGC");var sc=Calls(start);Need(sc.Length==2&&((MethodReference)sc[0].Operand).FullName==Method(t,"MLOEPDOPGJD").FullName&&((MethodReference)sc[1].Operand).DeclaringType.FullName=="UnityEngine.MonoBehaviour"&&((MethodReference)sc[1].Operand).Name=="StartCoroutine"&&Sig((MethodReference)sc[1].Operand)=="UnityEngine.Coroutine(System.Collections.IEnumerator)","exact stop/start targets and iterator overload");
                Need(start.Body.Instructions.Count(i=>i.OpCode.Code==Code.Stfld&&((FieldReference)i.Operand).Name=="HEGLMMJABEN")==1&&start.Body.Instructions.Single(i=>i.OpCode.Code==Code.Stfld).Previous==sc[1],"only returned handle store follows StartCoroutine");
                var stop=Method(t,"MLOEPDOPGJD");var st=Calls(stop);Need(st.Length==2&&((MethodReference)st[0].Operand).DeclaringType.FullName=="RecRoom.Audio.AudioManager"&&((MethodReference)st[0].Operand).Name=="StopMusic"&&Sig((MethodReference)st[0].Operand)=="System.Void()"&&((MethodReference)st[1].Operand).DeclaringType.FullName=="UnityEngine.MonoBehaviour"&&((MethodReference)st[1].Operand).Name=="StopCoroutine"&&Sig((MethodReference)st[1].Operand)=="System.Void(UnityEngine.Coroutine)","exact audio-first/Coroutine stop overload");
                Need(stop.Body.Instructions.Count(i=>i.OpCode.Code==Code.Ldfld&&((FieldReference)i.Operand).Name=="HEGLMMJABEN")==1&&stop.Body.Instructions.Count(i=>i.OpCode.Code==Code.Stfld&&((FieldReference)i.Operand).Name=="HEGLMMJABEN")==1,"single post-audio handle capture and clear");
                foreach(var x in new[]{Tuple.Create("BBOMFKCKKEP","KJNOGCGEIHD",0x060008b9u),Tuple.Create("EPCGHFICLMA","MDLLPIFKLJO",0x060008bfu)})
                {
                    var nested=t.NestedTypes.Single(n=>n.Name==x.Item1);var raw=r.NestedTypes.Single(n=>n.Name==x.Item1);var ctor=nested.Methods.Single(m=>m.IsConstructor&&!m.IsStatic);Same(raw.Methods.Single(m=>m.MetadataToken.ToUInt32()==x.Item3),ctor);
                    var cc=Calls(ctor);Need(cc.Length==1&&((MethodReference)cc[0].Operand).DeclaringType.FullName=="System.Object"&&((MethodReference)cc[0].Operand).Name==".ctor","exact base object constructor");var store=ctor.Body.Instructions.Single(i=>i.OpCode.Code==Code.Stfld);var field=(FieldReference)store.Operand;var original=raw.Fields.Single(f=>f.Name=="<>1__state");Need(field.Name=="_003C_003E1__state"&&field.FieldType.FullName==original.FieldType.FullName&&store.Previous.OpCode.Code==Code.Ldarg_1,"exact original state parameter store/export alias");
                    var f=Method(t,x.Item2);var fc=Calls(f);Need(fc.Length==1&&fc[0].OpCode.Code==Code.Newobj&&((MethodReference)fc[0].Operand).DeclaringType.FullName==nested.FullName&&fc[0].Previous.OpCode.Code==Code.Ldc_I4_0,"exact iterator type and ctor0");var capture=f.Body.Instructions.Single(i=>i.OpCode.Code==Code.Stfld);Need(((FieldReference)capture.Operand).Name=="_003C_003E4__this"&&capture.Previous.OpCode.Code==Code.Ldarg_0&&((FieldReference)capture.Operand).FieldType.FullName=="TitleScreenManager","same original this capture, no iterator execution");
                }
                var gf=c.Types.Single(x=>x.Name=="GONBPKCPFNK`1"&&x.GenericParameters.Count==1);var gr=o.Types.Single(x=>x.MetadataToken.ToUInt32()==0x02002bcd&&x.Name=="GONBPKCPFNK"&&x.GenericParameters.Count==1);var rawGetter=gr.Methods.Single(m=>m.MetadataToken.ToUInt32()==0x06011b4d&&m.Name=="DAOIFPKEGOG");var getter=gf.Properties.Single(p=>p.Name=="CPDFJCCALIA").GetMethod;Need(gr.Properties.Single(p=>p.GetMethod==rawGetter).Name=="CPDFJCCALIA","exact original state property/getter association");Same(rawGetter,getter);Need(Calls(getter).Length==0,"raw field-only state getter");var read=getter.Body.Instructions.Single(i=>i.OpCode.Code==Code.Ldfld);var sourceField=gf.Fields.Single(f=>f.Name=="MFHOAFKBLGN");var rawField=gr.Fields.Single(f=>f.MetadataToken.ToUInt32()==0x0400b505);Need(rawField.Name=="<MFHOAFKBLGN>k__BackingField"&&rawField.FieldType.FullName=="System.UInt16"&&sourceField.Attributes==rawField.Attributes&&sourceField.FieldType.FullName==rawField.FieldType.FullName&&rawField.CustomAttributes.Any(a=>a.AttributeType.FullName=="System.Runtime.CompilerServices.CompilerGeneratedAttribute"),"exact original backing-field export alias and flags");Need(((FieldReference)read.Operand).Name==sourceField.Name&&((FieldReference)read.Operand).DeclaringType is GenericInstanceType&&((GenericInstanceType)((FieldReference)read.Operand).DeclaringType).GenericArguments.Single() is GenericParameter,"same generic owner field read");
                var flow=c.Types.Single(x=>x.FullName=="RRUI.Data.TitleScreenFlowModel");var fr=o.Types.Single(x=>x.MetadataToken.ToUInt32()==0x02001883&&x.FullName==flow.FullName);var fs=flow.Fields.Single(f=>f.Name=="BGBIFFLGANM");var fraw=fr.Fields.Single(f=>f.MetadataToken.ToUInt32()==0x04004f0b&&f.Name==fs.Name);Need(fs.Attributes==fraw.Attributes&&fs.FieldType.FullName==fraw.FieldType.FullName&&fs.IsPrivate&&fs.IsInitOnly,"same original private readonly state field");
                foreach(var x in new[]{Tuple.Create("IsInAccountCreationState",0x06008929u),Tuple.Create("IsInChatState",0x0600892au),Tuple.Create("IsInFeedState",0x0600892bu),Tuple.Create("IsInInterstitialState",0x0600892du)}){var m=flow.Properties.Single(p=>p.Name==x.Item1).GetMethod;Same(fr.Methods.Single(v=>v.MetadataToken.ToUInt32()==x.Item2),m);var calls=Calls(m);Need(calls.Length==1&&((MethodReference)calls[0].Operand).Name=="get_CPDFJCCALIA"&&Sig((MethodReference)calls[0].Operand)=="System.UInt16()"&&((MethodReference)calls[0].Operand).DeclaringType.FullName=="GONBPKCPFNK`1<OOMEAMBGFPG/JEGOKBPEODC>","one exact original closed state getter "+x.Item1);var rr=m.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldfld).ToArray();Need(rr.Length==1,"one raw state field read");Field((FieldReference)rr[0].Operand,fs);}
                var music=Method(t,"NMJIFHLPFNP");var callsMusic=Calls(music).Select(i=>(MethodReference)i.Operand).ToArray();var expected=new[]{"op_Equality","get_IsInInterstitialState","CurrentMusicAudioClip","get_IsInChatState","get_IsInFeedState","op_Inequality","MLOEPDOPGJD","get_IsInAccountCreationState","op_Equality","MDLLPIFKLJO","NDENAIFEGGC","get_Instance","get_CurrentUnityLauncher","op_Inequality","MLOEPDOPGJD","op_Equality","KJNOGCGEIHD","NDENAIFEGGC"};Need(callsMusic.Select(m=>m.Name).SequenceEqual(expected),"all18 exact original caller effect targets/order");
                Need(callsMusic.Where(m=>m.Name.StartsWith("op_",StringComparison.Ordinal)).Count()==5&&callsMusic.Where(m=>m.Name.StartsWith("op_",StringComparison.Ordinal)).All(m=>m.DeclaringType.FullName=="UnityEngine.Object"&&m.DeclaringType.Scope.ToString()=="UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"&&Sig(m)=="System.Boolean(UnityEngine.Object,UnityEngine.Object)"),"only five genuine Unity equality calls on flow/AudioClip, no raw wrapper/Coroutine operator");
                var first=Calls(music)[0];Need(first.Previous.OpCode.Code==Code.Ldnull&&first.Previous.Previous.OpCode.Code==Code.Ldfld&&((FieldReference)first.Previous.Previous.Operand).Name=="flowModel"&&((FieldReference)first.Previous.Previous.Operand).FieldType.FullName=="RRUI.Data.TitleScreenFlowModel","initial null comparison invokes genuine Unity Object equality on exact flow field");
                var handles=music.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldfld&&((FieldReference)i.Operand).Name=="HEGLMMJABEN").ToArray();Need(handles.Length==2&&handles.All(i=>((FieldReference)i.Operand).FieldType.FullName=="UnityEngine.Coroutine")&&!callsMusic.Any(m=>m.DeclaringType.FullName=="UnityEngine.Coroutine"||m.DeclaringType.FullName=="RecRoom.Audio.RecRoomAudioClip"),"both raw Coroutine handle checks and ordinary wrapper ternaries introduce no operator/conversion calls");
                Need(!music.Body.Instructions.Any(i=>i.OpCode.Code==Code.Newobj||i.OpCode.Code==Code.Stfld||i.OpCode.Code==Code.Stsfld||i.OpCode.Code==Code.Ldarg_1),"caller has no invented allocations/stores/float reads; allocation exact factories only");
                var external=music.Body.Instructions.Where(i=>i.OpCode.Code==Code.Ldfld).Select(i=>(FieldReference)i.Operand).Where(f=>f.DeclaringType.FullName=="RecRoom.Audio.RecRoomAudioClip").ToArray();Need(external.Length==2&&external.All(f=>f.Name=="audioClip"&&f.FieldType.FullName=="UnityEngine.AudioClip"),"both original ordinary-wrapper public audioClip fields");
                Console.WriteLine("RESULT actual_full_original_twelve_music_member_bindings_passed; metadata_only_no_game_execution=true");
            }
        }
        public static int Main(string[] args){try{if(args.Length==3&&args[0]=="--inspect")Inspect(args[1],args[2]);else{Need(args.Length==0,"exact controlled effects args");Run();}return 0;}catch(Exception e){Console.Error.WriteLine(e);return 1;}}
    }
}
