// Actual matching Windows Mono player; only two proven SDK constructors run.
// No container registration, resolver, factory, provider or logger invocation.
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
public sealed class ContainerLowerAllocationSmoke:MonoBehaviour
{
    [Serializable] sealed class Result
    {
        public string schema="actual-Unity-original-container-allocation-smoke/v1",status="starting",unity_version,platform,exception,requested_original_System_Core_reference,actual_HashSet_framework_identity,actual_HashSet_field_type;
        public bool mono_runtime,original_reference_preserved,actual_HashSet_allocated,actual_Dictionary_allocated,key_constructor_fields_proved,independent_auxiliary_allocations;
        public bool production_registration_lookup_factory_logger_or_provider_executed=false,Main_modified=false,working_boot_or_provider_graph_claimed=false;
        public string[] checks,errors;
    }
    readonly Result result=new Result();readonly List<string> checks=new List<string>(),errors=new List<string>();
    static string Arg(string name){var args=Environment.GetCommandLineArgs();for(int i=0;i+1<args.Length;i++)if(args[i]==name)return args[i+1];throw new ArgumentException(name);}
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]static void Initialize(){new GameObject("Original container allocation diagnostic").AddComponent<ContainerLowerAllocationSmoke>();}
    void Need(bool value,string name){if(!value)throw new InvalidOperationException(name);checks.Add(name);}
    void OnLog(string text,string stack,LogType type){if(type==LogType.Error||type==LogType.Exception||type==LogType.Assert)errors.Add(text);}
    void Start()
    {
        string output=null;bool passed=false;Application.logMessageReceived+=OnLog;
        try
        {
            output=Path.GetFullPath(Arg("-startupSdkResult"));if(File.Exists(output))throw new IOException("Fresh result required");
            result.unity_version=Application.unityVersion;result.platform=Application.platform.ToString();result.mono_runtime=Type.GetType("Mono.Runtime")!=null;
            Need(result.unity_version=="2020.3.33f1"&&Application.platform==RuntimePlatform.WindowsPlayer&&result.mono_runtime&&IntPtr.Size==8&&Debug.isDebugBuild,"matching genuine Windows64 Mono Development runtime");
            var sdk=typeof(MNALHHOLFGL).Assembly;Need(sdk.FullName=="UJect.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null","exact retained SDK assembly identity");
            var refs=sdk.GetReferencedAssemblies().Where(a=>a.Name=="System.Core").ToArray();Need(refs.Length==1,"exactly one original System.Core reference");result.requested_original_System_Core_reference=refs[0].FullName;result.original_reference_preserved=refs[0].FullName=="System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e";Need(result.original_reference_preserved,"original System.Core token7cec preserved in actual packaged SDK metadata");
            var aux=sdk.GetType("OENEDGPIOFN",true);var ctor=aux.GetConstructor(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance,null,Type.EmptyTypes,null);Need(ctor!=null&&ctor.MetadataToken==0x0600003f,"exact original auxiliary constructor MethodDef");
            var dictionary=aux.GetField("NLDFDGJCKFH",BindingFlags.NonPublic|BindingFlags.Instance);var set=aux.GetField("DJGFOAKOCAP",BindingFlags.NonPublic|BindingFlags.Instance);var list=aux.GetField("OMMELJLAGLB",BindingFlags.NonPublic|BindingFlags.Instance);
            Need(dictionary!=null&&set!=null&&list!=null&&dictionary.MetadataToken==0x04000012&&set.MetadataToken==0x04000013&&list.MetadataToken==0x04000014,"exact original auxiliary field identities");
            Need(set.FieldType.IsGenericType&&set.FieldType.GetGenericTypeDefinition().FullName=="System.Collections.Generic.HashSet`1"&&set.FieldType.GenericTypeArguments.Single().FullName=="OENEDGPIOFN+NPDGPDKAHLN"&&set.FieldType.GenericTypeArguments.Single().Assembly==sdk,"original nested provider type only used as generic metadata argument");
            object first=ctor.Invoke(null),second=ctor.Invoke(null);var d1=dictionary.GetValue(first);var s1=set.GetValue(first);var d2=dictionary.GetValue(second);var s2=set.GetValue(second);
            result.actual_Dictionary_allocated=d1!=null&&d1.GetType()==dictionary.FieldType&&(int)d1.GetType().GetProperty("Count").GetValue(d1,null)==0;Need(result.actual_Dictionary_allocated,"actual original constructor allocates empty dictionary");
            result.actual_HashSet_allocated=s1!=null&&s1.GetType()==set.FieldType&&(int)s1.GetType().GetProperty("Count").GetValue(s1,null)==0;Need(result.actual_HashSet_allocated,"actual original HashSet constructor allocates empty set");
            result.actual_HashSet_framework_identity=s1.GetType().Assembly.FullName;result.actual_HashSet_field_type=set.FieldType.AssemblyQualifiedName;
            Need(s1.GetType().Assembly==typeof(HashSet<int>).Assembly&&s1.GetType().Module.ModuleVersionId==typeof(HashSet<int>).Module.ModuleVersionId,"HashSet field resolves to genuine same-player framework assembly and MVID; requested/resolved identities recorded separately");
            Need(list.GetValue(first)==null&&list.GetValue(second)==null,"original list field remains default null");
            result.independent_auxiliary_allocations=!ReferenceEquals(d1,d2)&&!ReferenceEquals(s1,s2)&&!ReferenceEquals(d1,s1);Need(result.independent_auxiliary_allocations,"independent actual original auxiliary allocations");
            var key=sdk.GetType("CPAMAFPANDM",true);var keyCtor=key.GetConstructor(new[]{typeof(Type),typeof(string)});var typeField=key.GetField("AFJAGKNNCBE");var nameField=key.GetField("FEKLPCPODAH");Need(keyCtor!=null&&keyCtor.MetadataToken==0x0600004d&&typeField!=null&&nameField!=null&&typeField.FieldType==typeof(Type)&&nameField.FieldType==typeof(string),"exact original key constructor and typed fields");
            var instance=keyCtor.Invoke(new object[]{typeof(ContainerLowerAllocationSmoke),"owned-key"});var nullKey=keyCtor.Invoke(new object[]{null,null});var emptyKey=keyCtor.Invoke(new object[]{typeof(string),""});
            result.key_constructor_fields_proved=ReferenceEquals(typeField.GetValue(instance),typeof(ContainerLowerAllocationSmoke))&&(string)nameField.GetValue(instance)=="owned-key"&&typeField.GetValue(nullKey)==null&&nameField.GetValue(nullKey)==null&&ReferenceEquals(typeField.GetValue(emptyKey),typeof(string))&&(string)nameField.GetValue(emptyKey)=="";Need(result.key_constructor_fields_proved,"actual key constructor preserves type/name/null/empty fields without invoking equality/hash or providers");
            Need(errors.Count==0,"no unexpected Unity runtime errors");if(checks.Count!=15)throw new InvalidOperationException("exact fifteen actual allocation checks");passed=true;
        }
        catch(Exception error){result.exception=error.ToString();}
        finally
        {
            Application.logMessageReceived-=OnLog;result.status=passed?"actual_original_HashSet_scope_allocation_and_key_fields_passed":"failed";result.checks=checks.ToArray();result.errors=errors.ToArray();
            try{if(output==null)passed=false;else File.WriteAllText(output,JsonUtility.ToJson(result,true));}catch(Exception error){Debug.LogException(error);passed=false;}
            Application.Quit(passed?0:1);
        }
    }
}
