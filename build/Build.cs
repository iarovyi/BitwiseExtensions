using System;
using System.IO;
using System.Linq;
using Microsoft.Build.Tasks;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.NuGet.NuGetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Publish);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("Path to artifacts directory")]
    readonly string ArtifactsDir = "./.artifacts";

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;
    //[GitVersion] readonly GitVersion GitVersion;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => (AbsolutePath)Path.GetFullPath(ArtifactsDir);
    AbsolutePath PublishProjectDirectory => SourceDirectory 
                                            / "BitwiseExtensions.DemoConsole/BitwiseExtensions.DemoConsole.csproj";

    Target Clean => _ => _
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                /*/.SetAssemblyVersion(GitVersion.GetNormalizedAssemblyVersion())
                .SetFileVersion(GitVersion.GetNormalizedFileVersion())
                .SetInformationalVersion(GitVersion.InformationalVersion)*/
                .EnableNoRestore());
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(o => o
                .SetProjectFile(Solution));
        });

    Target Pack => _ => _
        .DependsOn(Test)
        .Executes(() =>
        {
            DotNetPack(s => s
                .SetProject(Solution)
                .EnableNoBuild()
                .SetConfiguration(Configuration)
                .EnableIncludeSymbols()
                .SetOutputDirectory(ArtifactsDirectory)
                /*.SetVersion(GitVersion.NuGetVersionV2)*/);
        });

    Target Publish => _ => _
        .DependsOn(Pack)
        .Executes(() =>
        {
            DotNetPublish(s => s
                .SetNoBuild(true)
                .SetOutput(ArtifactsDirectory)
                .SetProject(PublishProjectDirectory)
                .SetConfiguration(Configuration));
        });
}
