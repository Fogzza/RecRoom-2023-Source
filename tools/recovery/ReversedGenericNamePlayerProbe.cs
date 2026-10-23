// Matching-player binding diagnostic only; no GameRoot or SDK body invocation.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
public sealed class ReversedGenericNamePlayerProbe:MonoBehaviour
{
    [Serializable] sealed class Result
    {
        public string schema="actual-Windows-Mono-production-reversed-generic-name-binding/v1",status="starting",unity_version,platform;
        public string original_projected_type_name="HHOBPMOCKMJ`1";
        public string requested_SDK_identity,requested_type_name,raw_SDK_identity,raw_type_name,raw_type_token,raw_SDK_mvid;
        public string resolved_type_identity,resolved_type_mvid,projected_resolution_exception_type,projected_resolution_exception_message,exception;
        public bool mono_runtime,raw_generic_constructible,arity_suffixed_lookup_exists,projected_consumer_binding_succeeded,raw_and_resolved_same_type;
        public bool Main_modified=false,SDK_bodies_invoked=false,production_GameRoot_instantiated=false,working_startup_claimed=false;
        public string[] checks,errors;
    }
    readonly Result result=new Result();readonly List<string> checks=new List<string>(),errors=new List<string>();
    static string Arg(string name){var a=Environment.GetCommandLineArgs();for(int i=0;i+1<a.Length;i++)if(a[i]==name)return a[i+1];throw new ArgumentException(name);}
    void Need(bool value,string name){if(!value)throw new InvalidOperationException(name);checks.Add(name);}
    void OnLog(string text,string stack,LogType type){if(type==LogType.Error||type==LogType.Exception||type==LogType.Assert)errors.Add(text);}
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]static void Initialize(){new GameObject("Production reference inverse binding diagnostic").AddComponent<ReversedGenericNamePlayerProbe>();}
    void Start()
    {
        string output=null;bool completed=false;Application.logMessageReceived+=OnLog;
        try
        {
            output=Path.GetFullPath(Arg("-startupSdkResult"));Need(!File.Exists(output),"fresh diagnostic result");
            result.unity_version=Application.unityVersion;result.platform=Application.platform.ToString();result.mono_runtime=Type.GetType("Mono.Runtime")!=null;
            Need(result.unity_version=="2020.3.33f1"&&Application.platform==RuntimePlatform.WindowsPlayer&&result.mono_runtime&&IntPtr.Size==8&&Debug.isDebugBuild,"matching actual Windows64 Mono Development player");
            var sdk=Assembly.Load("RecRoom.Datastructures.Runtime");result.raw_SDK_identity=sdk.FullName;result.raw_SDK_mvid=sdk.ManifestModule.ModuleVersionId.ToString();
            Need(sdk.FullName=="RecRoom.Datastructures.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null","exact retained raw SDK identity");
            var raw=sdk.GetType("HHOBPMOCKMJ",true,false);result.raw_type_name=raw.FullName;result.raw_type_token="0x"+raw.MetadataToken.ToString("X8");
            Need(raw.MetadataToken==0x02000032&&raw.IsGenericTypeDefinition&&raw.GetGenericArguments().Length==1,"raw original generic TypeDef token and arity");
            var rawClosed=raw.MakeGenericType(typeof(GameObject));result.raw_generic_constructible=rawClosed.IsGenericType&&rawClosed.GetGenericTypeDefinition()==raw&&rawClosed.GetGenericArguments().Single()==typeof(GameObject);
            Need(result.raw_generic_constructible,"raw generic definition forms the exact GameObject closed type without invoking any SDK body");
            result.arity_suffixed_lookup_exists=sdk.GetType("HHOBPMOCKMJ`1",false,false)!=null;
            var consumer=Assembly.Load("Recovery.ProjectedGenericConsumer");var requested=consumer.GetReferencedAssemblies().Single(a=>a.Name=="RecRoom.Datastructures.Runtime");
            result.requested_SDK_identity=requested.FullName;result.requested_type_name="HHOBPMOCKMJ";
            Need(requested.FullName==sdk.FullName,"consumer requested and raw SDK assembly identities match exactly");
            var owner=consumer.GetType("Recovery.ProjectedGenericBinding.Consumer",true,false);
            Need((Type)owner.GetMethod("BaselineType",BindingFlags.Public|BindingFlags.Static).Invoke(null,null)==typeof(GameObject),"same compiled consumer loads and its SDK-independent Unity type baseline resolves");
            try
            {
                var resolved=(Type)owner.GetMethod("ProjectedClosedType",BindingFlags.Public|BindingFlags.Static).Invoke(null,null);
                Need(resolved!=null,"projected typeof returned a type");result.projected_consumer_binding_succeeded=true;
                result.resolved_type_identity=resolved.AssemblyQualifiedName;result.resolved_type_mvid=resolved.Module.ModuleVersionId.ToString();result.raw_and_resolved_same_type=resolved==rawClosed;
                Need(result.raw_and_resolved_same_type,"actual projected name resolves to the exact retained raw SDK definition and GameObject argument");
            }
            catch(Exception error) when(error is TargetInvocationException||error is TypeLoadException||error is FileNotFoundException||error is FileLoadException)
            {
                var cause=error is TargetInvocationException?(error.InnerException??error):error;result.projected_resolution_exception_type=cause.GetType().FullName;result.projected_resolution_exception_message=cause.Message;
                Need(cause is TypeLoadException||cause is FileNotFoundException||cause is FileLoadException,"bounded actual generic resolution failure recorded distinctly from infrastructure errors");
            }
            Need(result.projected_consumer_binding_succeeded&&result.raw_and_resolved_same_type,"existing production inverse must resolve the original consumer to the exact raw SDK closed type");
            Need(errors.Count==0,"no unexpected Unity runtime errors");completed=true;
        }
        catch(Exception error){result.exception=error.ToString();}
        finally
        {
            Application.logMessageReceived-=OnLog;result.status=completed?(result.projected_consumer_binding_succeeded?"diagnostic_completed_projected_name_resolves_to_raw_definition":"diagnostic_completed_projected_name_does_not_resolve"):"failed_diagnostic_infrastructure";result.checks=checks.ToArray();result.errors=errors.ToArray();
            try{if(output==null)completed=false;else File.WriteAllText(output,JsonUtility.ToJson(result,true));}catch(Exception error){Debug.LogException(error);completed=false;}
            Application.Quit(completed?0:1);
        }
    }
}
