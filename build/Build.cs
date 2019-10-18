namespace build_script
{
    using System;
    using System.CommandLine;
    using static Bullseye.Targets;
    using static SimpleExec.Command;

    class Program
    {
        private const string ProjectDir = "./src";
        private const string ArtifactsDir = "/.artifacts";

        static void Main(string[] args)
        {
            var arguments = ParseArgs(args,
                new Option("--mount-dir", "Directory of mounted source code") { Argument = new Argument<string>("mount-dir") });
            var outputDir = $"{arguments.ValueForOption<string>("--mount-dir")}{ArtifactsDir}";

            Target("clean",                         () => Run("rm", $"-rf {outputDir}"));
            Target("restore", DependsOn("clean"),   () => Run("dotnet", $"restore {ProjectDir}"));
            Target("build",   DependsOn("restore"), () => Run("dotnet", $"build -c Release -o /app/build {ProjectDir}"));
            Target("test",    DependsOn("build"),   () => Run("dotnet", $"test {ProjectDir}"));
            Target("publish", DependsOn("test"),    () => Run("dotnet", $"publish {ProjectDir} -c Release -o {outputDir}"));
            Target("default", DependsOn("publish"));

            RunTargetsAndExit(arguments.UnmatchedTokens);
        }

        private static ParseResult ParseArgs(string[] args, params Option[] options)
        {
            var cmd = new RootCommand { TreatUnmatchedTokensAsErrors = false };
            foreach (var option in options)
            {
                cmd.Add(option);
            }
            return cmd.Parse(args);
        }
    }
}