using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly IOptionsMonitor<HisFileConfig> _config;
        private readonly ILogger<Worker> _logger;

        public Worker(IOptionsMonitor<HisFileConfig> config, ILogger<Worker> logger)
        {
            _config = config;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"{DateTimeOffset.Now} -> {_config.CurrentValue.FileServerPath} : {_config.CurrentValue.ProductPath}");

                await Task.Delay(3000, stoppingToken).ConfigureAwait(false);
            }
        }
    }
}
