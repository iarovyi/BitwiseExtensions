/*namespace BitwiseExtensions.DemoConsole
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <example>
    /// using Microsoft.Extensions.DependencyInjection;
    /// using Microsoft.Extensions.Hosting;
    /// 
    /// public static void Main(string[] args)
    /// {
    ///    CreateHostBuilder(args).Build().Run();
    /// }
    /// 
    /// public static IHostBuilder CreateHostBuilder(string[] args) =&gt;
    ///       Host.CreateDefaultBuilder(args)
    ///     .ConfigureServices((hostContext, services) =&gt;
    ///   {
    ///       services.AddHostedService&lt;Worker&gt;();
    ///   });
    /// </example>
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}*/
