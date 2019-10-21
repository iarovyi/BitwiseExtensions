namespace build_script
{
    using System;
    using System.CommandLine;
    using static Bullseye.Targets;
    using static SimpleExec.Command;

    class Program
    {
        private const string ProjectDir = "./src";
        static void Main(string[] args)
        {
            var arguments = ParseArgs(args,
                new Option("--artifacts-dir", "Directory for generated artifacts") { Argument = new Argument<string>("artifacts-dir") });
            var artifactsDir = arguments.ValueForOption<string>("--artifacts-dir");

            Target("clean",                         () => Run("rm", $"-rf {artifactsDir}"));
            Target("restore", DependsOn("clean"),   () => Run("dotnet", $"restore {ProjectDir}"));
            Target("build",   DependsOn("restore"), () => Run("dotnet", $"build -c Release -o /app/build {ProjectDir}"));
            Target("test",    DependsOn("build"),   () => Run("dotnet", $"test {ProjectDir}"));
            Target("publish", DependsOn("test"),    () => Run("dotnet", $"publish {ProjectDir} -c Release -o {artifactsDir}"));
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