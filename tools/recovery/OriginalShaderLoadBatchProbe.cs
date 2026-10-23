// Diagnostic player only: exact Resources identities and properties, no draw.
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public sealed class OriginalShaderLoadBatchProbe : MonoBehaviour
{
    [Serializable] public class Expected
    {
        public string guid, resource_key, name, pipeline_tag_argument;
        public int expected_property_count;
        public string[] expected_property_names;
    }
    [Serializable] public class Config { public string schema; public Expected[] shaders; }
    [Serializable] public class Observed
    {
        public string guid, resource_key, name, pipeline_tag;
        public int property_count;
        public string[] property_names;
        public bool loaded_exact_original_identity, supported;
    }
    [Serializable] public class Result
    {
        public string schema="actual-original-Shader-structural-load-batch/v1",status="starting",exception,unity_version,graphics_api,graphics_device;
        public int start_frame,end_frame,partial_constant_buffer_messages;
        public Observed[] shaders;
        public string[] shader_error_lines;
        public bool GPU_draw_attempted=false,original_game_code_loaded=false,Main_modified=false;
        public bool unsupported_status_is_observation_not_a_failure_or_visual_claim=true;
    }
    const string URP="UniversalPipeline,LightweightPipeline";
    static Result result;
    static readonly List<string> errors=new List<string>();
    static void Need(bool value,string message) { if(!value)throw new InvalidOperationException(message); }
    static string Arg(string name)
    {
        string[] args=Environment.GetCommandLineArgs();
        for(int i=0;i<args.Length;++i)if(args[i]==name){Need(i+1<args.Length,"Missing value for "+name);return args[i+1];}
        throw new ArgumentException("Missing "+name);
    }
    public static bool IsRequested()
    {
        foreach(string value in Environment.GetCommandLineArgs())if(value=="-shaderLoadBatchConfig")return true;
        return false;
    }
    public static void Begin()
    {
        var host=new GameObject("OriginalShaderStructuralLoadBatch");DontDestroyOnLoad(host);
        host.AddComponent<OriginalShaderLoadBatchProbe>().StartCoroutine(AfterFrame());
    }
    static IEnumerator AfterFrame() { yield return null; Execute(); }
    static void Log(string message,string trace,LogType kind)
    {
        if(message.Contains("Partial constant buffer not found."))result.partial_constant_buffer_messages++;
        if(errors.Count<64&&(kind==LogType.Error||kind==LogType.Exception||kind==LogType.Assert||message.Contains("Shader error")))
            errors.Add(message.Length<=1024?message:message.Substring(0,1024));
    }
    static void Execute()
    {
        string output=null,oldPipeline=Shader.globalRenderPipeline;int exit=1;var observed=new List<Observed>();
        result=new Result{unity_version=Application.unityVersion,graphics_api=SystemInfo.graphicsDeviceType.ToString(),graphics_device=SystemInfo.graphicsDeviceName,start_frame=Time.frameCount};
        Application.logMessageReceived+=Log;
        try
        {
            output=Path.GetFullPath(Arg("-shaderLoadBatchOutput"));Need(!File.Exists(output)&&Directory.Exists(Path.GetDirectoryName(output)),"Fresh existing isolated output directory");
            Need(Application.unityVersion=="2020.3.33f1"&&Application.platform==RuntimePlatform.WindowsPlayer&&SystemInfo.graphicsDeviceType==GraphicsDeviceType.Direct3D11,"Matching Windows D3D11 diagnostic player");
            Config config=JsonUtility.FromJson<Config>(File.ReadAllText(Arg("-shaderLoadBatchConfig")));
            Need(config!=null&&config.schema=="explicit-original-Shader-structural-load-batch-input/v1"&&config.shaders!=null&&config.shaders.Length>0&&config.shaders.Length<=32,"Explicit bounded structural input batch");
            var identities=new HashSet<string>(StringComparer.Ordinal);
            foreach(Expected expected in config.shaders)
            {
                Need(expected!=null&&expected.guid!=null&&expected.guid.Length==32&&identities.Add(expected.guid)
                    &&expected.resource_key=="OriginalShaders/"+expected.guid&&!String.IsNullOrEmpty(expected.name)
                    &&expected.expected_property_count>=0&&expected.expected_property_count<=4096
                    &&expected.expected_property_names!=null&&expected.expected_property_names.Length==expected.expected_property_count,"Exact expected original identity/property contract");
                Need(expected.pipeline_tag_argument=="unchanged"||expected.pipeline_tag_argument==URP,"Only unchanged or genuine URP selection tag");
                Shader.globalRenderPipeline=expected.pipeline_tag_argument=="unchanged"?oldPipeline:URP;
                Shader shader=Resources.Load<Shader>(expected.resource_key);
                Need(shader!=null&&shader.name==expected.name,"Exact original Resources Shader load: "+expected.guid);
                var row=new Observed{guid=expected.guid,resource_key=expected.resource_key,name=shader.name,pipeline_tag=Shader.globalRenderPipeline,
                    loaded_exact_original_identity=true,property_count=shader.GetPropertyCount(),supported=shader.isSupported};
                Need(row.property_count==expected.expected_property_count,"Original property count changed: "+expected.guid);
                row.property_names=new string[row.property_count];
                for(int i=0;i<row.property_count;++i){row.property_names[i]=shader.GetPropertyName(i);Need(row.property_names[i]==expected.expected_property_names[i],"Original property identity/order changed: "+expected.guid);}
                observed.Add(row);
            }
            Need(result.partial_constant_buffer_messages==0&&errors.Count==0,"Shader/deserialization/constant-buffer error logged");
            result.status="all_explicit_original_Shader_names_and_properties_loaded_without_errors";exit=0;
        }
        catch(Exception error){result.status="failed_or_guard_refused";result.exception=error.ToString();}
        finally
        {
            Shader.globalRenderPipeline=oldPipeline;result.end_frame=Time.frameCount;result.shaders=observed.ToArray();result.shader_error_lines=errors.ToArray();Application.logMessageReceived-=Log;
            try{if(output!=null)File.WriteAllText(output,JsonUtility.ToJson(result,true));}catch{exit=1;}
            Application.Quit(exit);
        }
    }
}
