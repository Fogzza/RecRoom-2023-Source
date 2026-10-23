// Actual retained/staged SDK key methods in matching Unity. No container path.
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
public sealed class ContainerKeyDictionarySmoke:MonoBehaviour
{
    [Serializable] sealed class Result
    {
        public string schema="actual-Unity-original-container-key-dictionary-smoke/v1",status="starting",unity_version,platform,SDK_identity,SDK_mvid,key_type,Dictionary_framework_identity,Dictionary_framework_mvid,exception;
        public bool mono_runtime,actual_key_equality_hash_and_Dictionary_tested,production_container_child_registration_lookup_factory_logger_or_provider_executed=false;
        public string[] checks,errors;
    }
    readonly Result result=new Result();readonly List<string> checks=new List<string>(),errors=new List<string>();
    Type keyType;ConstructorInfo constructor;MethodInfo typed,boxed,hash;
    static string Arg(string name){var args=Environment.GetCommandLineArgs();for(int i=0;i+1<args.Length;i++)if(args[i]==name)return args[i+1];throw new ArgumentException(name);}
    void Need(bool value,string name){if(!value)throw new InvalidOperationException(name);checks.Add(name);}
    void OnLog(string text,string stack,LogType type){if(type==LogType.Error||type==LogType.Exception||type==LogType.Assert)errors.Add(text);}
    object Key(Type type,string name){return constructor.Invoke(new object[]{type,name});}
    bool Equal(object left,object right){return (bool)typed.Invoke(left,new object[]{right});}
    bool BoxEqual(object left,object right){return (bool)boxed.Invoke(left,new object[]{right});}
    int Hash(object key){return (int)hash.Invoke(key,null);}
    static bool Throws<T>(Action action) where T:Exception
    {try{action();return false;}catch(Exception error){var actual=error is TargetInvocationException?(error.InnerException??error):error;return actual.GetType()==typeof(T);}}
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]static void Initialize(){new GameObject("Actual original SDK key Dictionary smoke").AddComponent<ContainerKeyDictionarySmoke>();}
    void Start()
    {
        string output=null;bool success=false;Application.logMessageReceived+=OnLog;
        try
        {
            output=Path.GetFullPath(Arg("-startupSdkResult"));Need(!File.Exists(output),"fresh runtime proof output");
            result.unity_version=Application.unityVersion;result.platform=Application.platform.ToString();result.mono_runtime=Type.GetType("Mono.Runtime")!=null;
            Need(result.unity_version=="2020.3.33f1"&&result.platform=="WindowsPlayer"&&result.mono_runtime&&IntPtr.Size==8&&Debug.isDebugBuild,"matching actual Windows64 Mono Development player");
            var sdk=Assembly.Load("UJect.Runtime");result.SDK_identity=sdk.FullName;result.SDK_mvid=sdk.ManifestModule.ModuleVersionId.ToString();Need(sdk.FullName=="UJect.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null","exact original SDK assembly identity");
            keyType=sdk.GetType("CPAMAFPANDM",true,false);result.key_type=keyType.FullName;Need(keyType.IsValueType&&keyType.MetadataToken==0x02000010,"exact original key value TypeDef");
            var fields=keyType.GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.DeclaredOnly).OrderBy(f=>f.MetadataToken).ToArray();Need(fields.Length==2&&fields[0].Name=="AFJAGKNNCBE"&&fields[0].FieldType==typeof(Type)&&fields[1].Name=="FEKLPCPODAH"&&fields[1].FieldType==typeof(string)&&fields.All(f=>f.IsPublic&&f.IsInitOnly),"exact original two readonly Type/string field declarations");
            constructor=keyType.GetConstructor(new[]{typeof(Type),typeof(string)});typed=keyType.GetMethod("OFPEIHMPLIL",new[]{keyType});boxed=keyType.GetMethod("Equals",new[]{typeof(object)});hash=keyType.GetMethod("GetHashCode",Type.EmptyTypes);Need(constructor!=null&&constructor.MetadataToken==0x0600004d&&typed!=null&&typed.MetadataToken==0x0600004e&&boxed!=null&&boxed.MetadataToken==0x0600004f&&hash!=null&&hash.MetadataToken==0x06000050,"exact original ctor/equality/hash MethodDef identities");
            string a=new String(new[]{'n','a','m','e'}),b=new String(new[]{'n','a','m','e'});var first=Key(typeof(string),a);var equal=Key(typeof(string),b);
            Need(ReferenceEquals(fields[0].GetValue(first),typeof(string))&&ReferenceEquals(fields[1].GetValue(first),a),"actual original key constructor field values");
            Need(!ReferenceEquals(a,b)&&Equal(first,equal)&&!Equal(first,Key(typeof(string),"Name"))&&!Equal(first,Key(typeof(int),a)),"actual typed equality uses Type and ordinal string values");
            Need(Equal(Key(null,a),Key(null,b))&&!Equal(Key(null,a),first)&&Equal(Key(null,null),Key(null,null)),"actual typed null Type/name semantics");
            Need(!BoxEqual(first,null)&&!BoxEqual(first,a)&&!BoxEqual(first,typeof(string)),"actual boxed equality rejects null and wrong boxed types");
            Need(BoxEqual(first,equal)&&!BoxEqual(first,Key(typeof(string),"different"))&&!BoxEqual(first,Key(typeof(int),a)),"actual boxed key equality preserves both fields");
            Need(!Equal(Key(typeof(string),null),Key(typeof(string),""))&&!BoxEqual(Key(typeof(string),null),Key(typeof(string),"")),"actual null and empty key names remain distinct");
            Need(Hash(first)==unchecked(typeof(string).GetHashCode()*397^a.GetHashCode())&&Hash(Key(typeof(string),null))==unchecked(typeof(string).GetHashCode()*397),"actual key hash unchecked times397 XOR with null-name zero");
            Need(Hash(first)==Hash(equal),"actual equal independent string values have equal hashes");
            Need(Throws<NullReferenceException>(()=>Hash(Key(null,null)))&&Throws<NullReferenceException>(()=>Hash(Key(null,a))),"actual key hash null Type throws rather than inventing a default hash");
            var dictionaryType=typeof(Dictionary<,>).MakeGenericType(keyType,typeof(string));result.Dictionary_framework_identity=dictionaryType.Assembly.FullName;result.Dictionary_framework_mvid=dictionaryType.Module.ModuleVersionId.ToString();Need(dictionaryType.Assembly==typeof(Dictionary<int,string>).Assembly&&dictionaryType.Module.ModuleVersionId==typeof(Dictionary<int,string>).Module.ModuleVersionId,"actual generic Dictionary uses the same matching player framework");
            var dictionary=(IDictionary)Activator.CreateInstance(dictionaryType);dictionary.Add(first,"first");Need(dictionary.Count==1&&(string)dictionary[equal]=="first"&&dictionary.Contains(equal),"actual Dictionary resolves an independently boxed equal key");
            Need(Throws<ArgumentException>(()=>dictionary.Add(equal,"duplicate"))&&dictionary.Count==1&&(string)dictionary[first]=="first","actual duplicate equal key rejected without overwriting value");
            var otherType=Key(typeof(int),a);dictionary.Add(otherType,"other-type");Need(dictionary.Count==2&&(string)dictionary[otherType]=="other-type"&&(string)dictionary[first]=="first","actual Dictionary distinguishes original Type field");
            var nullName=Key(typeof(string),null);var emptyName=Key(typeof(string),"");dictionary.Add(nullName,"null-name");dictionary.Add(emptyName,"empty-name");Need(dictionary.Count==4&&(string)dictionary[Key(typeof(string),null)]=="null-name"&&(string)dictionary[Key(typeof(string),"")]=="empty-name","actual Dictionary retains separate null and empty name bindings");
            Need(Throws<NullReferenceException>(()=>dictionary.Add(Key(null,a),"invalid"))&&dictionary.Count==4,"actual invalid null-Type hash does not insert a dictionary binding");
            dictionary.Remove(equal);Need(dictionary.Count==3&&!dictionary.Contains(first)&&!dictionary.Contains(Key(typeof(string),"missing"))&&(string)dictionary[otherType]=="other-type","actual Dictionary removal uses equal key and leaves distinct bindings");
            if(checks.Count!=22||errors.Count!=0)throw new InvalidOperationException("exact22 key/Dictionary checks and no unexpected Unity errors required");result.actual_key_equality_hash_and_Dictionary_tested=true;success=true;
        }
        catch(Exception error){result.exception=error.ToString();}
        finally
        {
            Application.logMessageReceived-=OnLog;result.status=success?"actual_original_key_equality_hash_and_Dictionary_passed":"failed_actual_original_key_dictionary_smoke";result.checks=checks.ToArray();result.errors=errors.ToArray();
            try{if(output==null)success=false;else File.WriteAllText(output,JsonUtility.ToJson(result,true));}catch(Exception error){Debug.LogException(error);success=false;}
            Application.Quit(success?0:1);
        }
    }
}
