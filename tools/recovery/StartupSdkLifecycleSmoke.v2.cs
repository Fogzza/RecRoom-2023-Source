// Isolated Windows-player fixture only; no production GameRoot or network code.
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public sealed class StartupSdkLifecycleSmoke:MonoBehaviour
{
    [Serializable] sealed class Result
    {
        public string schema="actual-Unity-original-startup-SDK-lifecycle-smoke/v1",status="starting",unity_version,platform,exception;
        public bool mono_runtime,old_GameObject_destroyed,new_instance_survived_old_OnDestroy,current_instance_cleared,independent_generic_storage,disposed_guard_exact_exception;
        public int start_frame,end_frame;
        public string[] checks,errors;
        public bool production_GameRoot_instantiated=false,game_getter_stubs_used=false,Main_modified=false,login_or_bootstrap_functionality_claimed=false;
    }
    readonly Result result=new Result();readonly List<string> checks=new List<string>();readonly List<string> errors=new List<string>();string output;bool finished;
    static string Arg(string name)
    {
        var args=Environment.GetCommandLineArgs();for(int i=0;i+1<args.Length;i++)if(args[i]==name)return args[i+1];throw new ArgumentException("Missing smoke argument "+name);
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Initialize() { new GameObject("Original SDK lifecycle diagnostic").AddComponent<StartupSdkLifecycleSmoke>(); }
    void Need(bool value,string name) { if(!value)throw new InvalidOperationException("SDK smoke failed: "+name);checks.Add(name); }
    void OnLog(string text,string stack,LogType type) { if(type==LogType.Error||type==LogType.Exception||type==LogType.Assert)errors.Add(text); }
    static object Stored(Type concrete)
    {
        var owner=typeof(SingletonMonoBehaviour<>).MakeGenericType(concrete);var field=owner.GetField("CMDPMJBEBAB",BindingFlags.Static|BindingFlags.NonPublic);
        if(field==null||field.DeclaringType!=owner||field.FieldType!=concrete)throw new InvalidOperationException("Exact original private static field metadata absent");return field.GetValue(null);
    }
    static void Guard(bool condition,string message)
    {
        var originalType=typeof(MNALHHOLFGL).Assembly.GetType("MKECFLEMHEL",true);
        var method=originalType.GetMethod("GFKAFPHLKMJ",BindingFlags.Public|BindingFlags.Static,null,new[]{typeof(bool),typeof(string)},null);
        if(method==null||method.ReturnType!=typeof(void))throw new InvalidOperationException("Exact original disposed guard signature absent");method.Invoke(null,new object[]{condition,message});
    }
    IEnumerator Start()
    {
        Application.runInBackground=true;Application.targetFrameRate=60;Application.logMessageReceived+=OnLog;
        result.unity_version=Application.unityVersion;result.platform=Application.platform.ToString();result.mono_runtime=Type.GetType("Mono.Runtime")!=null;result.start_frame=Time.frameCount;
        Exception setupError=null;
        try { output=Path.GetFullPath(Arg("-startupSdkResult"));if(File.Exists(output))throw new IOException("Fresh runtime result required"); }
        catch(Exception error) { setupError=error; }
        if(setupError!=null){Finish(false,setupError);yield break;}
        IEnumerator sequence=RunChecks();
        while(true)
        {
            bool more;object current=null;Exception failure=null;
            try { more=sequence.MoveNext();if(more)current=sequence.Current; }
            catch(Exception error) { more=false;failure=error; }
            if(failure!=null){Finish(false,failure);yield break;}
            if(!more){Finish(true,null);yield break;}
            yield return current;
        }
    }
    IEnumerator RunChecks()
    {
        Need(result.unity_version=="2020.3.33f1"&&Application.platform==RuntimePlatform.WindowsPlayer&&result.mono_runtime,"matching Windows64 Mono runtime");
        Need(ReferenceEquals(Stored(typeof(StartupSdkSingletonA)),null)&&ReferenceEquals(Stored(typeof(StartupSdkSingletonB)),null),"original private generic fields initially null");
        var oldObject=new GameObject("First original Singleton A");var first=oldObject.AddComponent<StartupSdkSingletonA>();
        Need(ReferenceEquals(Stored(typeof(StartupSdkSingletonA)),first),"real AddComponent invokes original Awake and stores first instance");
        var independentObject=new GameObject("Independent original Singleton B");var independent=independentObject.AddComponent<StartupSdkSingletonB>();
        result.independent_generic_storage=ReferenceEquals(Stored(typeof(StartupSdkSingletonA)),first)&&ReferenceEquals(Stored(typeof(StartupSdkSingletonB)),independent);Need(result.independent_generic_storage,"distinct original generic static storage");
        var newObject=new GameObject("Second original Singleton A");var second=newObject.AddComponent<StartupSdkSingletonA>();
        Need(ReferenceEquals(Stored(typeof(StartupSdkSingletonA)),second),"duplicate original Awake stores new instance synchronously");
        yield return null;yield return null;
        result.old_GameObject_destroyed=oldObject==null;Need(result.old_GameObject_destroyed,"previous GameObject destroyed through real deferred Unity lifecycle");
        result.new_instance_survived_old_OnDestroy=ReferenceEquals(Stored(typeof(StartupSdkSingletonA)),second);Need(result.new_instance_survived_old_OnDestroy,"old original OnDestroy preserves newly stored instance");
        UnityEngine.Object.Destroy(newObject);yield return null;yield return null;
        result.current_instance_cleared=newObject==null&&ReferenceEquals(Stored(typeof(StartupSdkSingletonA)),null);Need(result.current_instance_cleared,"current original OnDestroy clears private storage after frames");
        Need(ReferenceEquals(Stored(typeof(StartupSdkSingletonB)),independent),"other generic Singleton remains intact");
        UnityEngine.Object.Destroy(independentObject);yield return null;yield return null;
        Need(independentObject==null&&ReferenceEquals(Stored(typeof(StartupSdkSingletonB)),null),"independent generic Singleton cleanup");
        Guard(false,"ignored");Guard(false,null);Need(true,"actual disposed guard false paths return");
        bool exact=false;try{Guard(true,"actual-guard-payload");}catch(TargetInvocationException error){exact=error.InnerException!=null&&error.InnerException.GetType()==typeof(InvalidOperationException)&&error.InnerException.Message=="actual-guard-payload"&&error.InnerException.InnerException==null;}
        result.disposed_guard_exact_exception=exact;Need(exact,"actual SDK guard throws exact InvalidOperationException with original message");
        exact=false;try{Guard(true,null);}catch(TargetInvocationException error){exact=error.InnerException!=null&&error.InnerException.GetType()==typeof(InvalidOperationException)&&error.InnerException.InnerException==null;}
        Need(exact,"actual SDK guard null-message constructor semantics");
        Need(Time.frameCount-result.start_frame>=6,"actual player frames advanced across callbacks");Need(errors.Count==0,"no Unity runtime errors or exceptions outside expected reflection checks");
    }
    void Finish(bool passed,Exception error)
    {
        if(finished)return;finished=true;Application.logMessageReceived-=OnLog;result.end_frame=Time.frameCount;result.status=passed?"actual_original_SDK_Awake_OnDestroy_and_disposed_guard_passed":"failed";result.exception=error==null?null:error.ToString();result.checks=checks.ToArray();result.errors=errors.ToArray();
        try { if(output!=null)File.WriteAllText(output,JsonUtility.ToJson(result,true));else passed=false; }
        catch(Exception writeError){Debug.LogException(writeError);passed=false;}
        Application.Quit(passed?0:1);
    }
}
