// Isolated builder; never references a production GameRoot or SDK method.
using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class BuildStartupSdkLifecycleSmoke
{
    [Serializable] sealed class Result
    {
        public string schema="matching-Unity-startup-SDK-smoke-build/v1",status="starting",unity_version,backend,target,build_options,output_path,exception;
        public int errors,warnings;public bool development,Main_modified=false;
    }
    static string Arg(string name) { var args=Environment.GetCommandLineArgs();for(int i=0;i+1<args.Length;i++)if(args[i]==name)return args[i+1];throw new ArgumentException("Missing smoke build argument "+name); }
    public static void Run()
    {
        var result=new Result{unity_version=Application.unityVersion};string report=null;int exit=1;
        try
        {
            report=Path.GetFullPath(Arg("-startupSdkBuildReport"));result.output_path=Path.GetFullPath(Arg("-buildOutput"));var expected=Path.GetFullPath(Arg("-startupSdkProject")).TrimEnd(Path.DirectorySeparatorChar);
            if(Application.unityVersion!="2020.3.33f1"||Path.GetFullPath(Path.Combine(Application.dataPath,"..")).TrimEnd(Path.DirectorySeparatorChar)!=expected||File.Exists(result.output_path))throw new InvalidOperationException("Exact matching fresh fixture only");
            if(EditorUserBuildSettings.activeBuildTarget!=BuildTarget.StandaloneWindows64)throw new InvalidOperationException("CLI must select Windows64 before compilation");
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone,ScriptingImplementation.Mono2x);PlayerSettings.SetManagedStrippingLevel(BuildTargetGroup.Standalone,ManagedStrippingLevel.Disabled);EditorUserBuildSettings.development=true;
            result.backend=PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone).ToString();result.target=EditorUserBuildSettings.activeBuildTarget.ToString();result.development=EditorUserBuildSettings.development;
            if(result.backend!="Mono2x")throw new InvalidOperationException("Only matching Mono player");
            var scene=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);Directory.CreateDirectory("Assets/Scenes");
            if(!EditorSceneManager.SaveScene(scene,"Assets/Scenes/StartupSdkSmoke.unity"))throw new IOException("Cannot save fresh isolated empty scene");
            var options=BuildOptions.Development|BuildOptions.StrictMode;result.build_options=options.ToString();
            var build=BuildPipeline.BuildPlayer(new BuildPlayerOptions{scenes=new[]{"Assets/Scenes/StartupSdkSmoke.unity"},locationPathName=result.output_path,target=BuildTarget.StandaloneWindows64,targetGroup=BuildTargetGroup.Standalone,options=options});
            if(build==null)throw new InvalidOperationException("Actual BuildReport absent");result.status=build.summary.result.ToString();result.errors=build.summary.totalErrors;result.warnings=build.summary.totalWarnings;
            if(build.summary.result==BuildResult.Succeeded&&result.errors==0&&File.Exists(result.output_path))exit=0;
        }
        catch(Exception error){result.status="exception";result.exception=error.ToString();Debug.LogException(error);}
        finally { try{if(report!=null)File.WriteAllText(report,JsonUtility.ToJson(result,true));}catch(Exception error){Debug.LogException(error);exit=1;} }
        EditorApplication.Exit(exit);
    }
}
