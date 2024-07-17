using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Builder
{
    private static void BuildWebGL()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();

        string[] scenePaths = new string[EditorBuildSettings.scenes.Length];
        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {

            scenePaths[i] = EditorBuildSettings.scenes[i].path;
            Debug.Log("scene in build settings: " + scenePaths[i]);
        }

        //return;
        
        buildPlayerOptions.scenes = scenePaths;
        
        string projectPath = Directory.GetCurrentDirectory();
        
        //buildPlayerOptions.locationPathName =  $"{projectPath}/AutoWebglBuild/"; // into folder where unity project
        buildPlayerOptions.locationPathName =  "../AutoWebglBuild/"; // into folder where  meta folders
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.subtarget = (int)StandaloneBuildSubtarget.NoSubtarget;
        //buildPlayerOptions.options = BuildOptions.AutoRunPlayer;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }

    [MenuItem("MyMenu/Do Build")]
    public static void Build()
    {
        // Build EmbeddedLinux ARM64 Unity player
        BuildWebGL();
    }
    
    [MenuItem("MyMenu/Log Build Settings")]
    public static void MyBuild()
    {
        // Log some of the current build options retrieved from the Build Settings Window
        BuildPlayerOptions buildPlayerOptions = BuildPlayerWindow.DefaultBuildMethods.GetBuildPlayerOptions(new BuildPlayerOptions());
        Debug.Log("BuildPlayerOptions\n"
                  + "Scenes: " + string.Join(",", buildPlayerOptions.scenes) + "\n"
                  + "Build location: " + buildPlayerOptions.locationPathName + "\n"
                  + "Options: " + buildPlayerOptions.options + "\n"
                  + "Target: " + buildPlayerOptions.target);
    }
}
