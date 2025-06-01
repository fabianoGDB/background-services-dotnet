using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HostDemo
{
    internal class TimeService(ILogger<TimeService> logger) : BackgroundService
    {
        private readonly ILogger<TimeService> _logger = logger;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _ = Task.Run(async () =>
            {
                while (true) 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    _logger.LogInformation("The Time is {Time}", TimeOnly.FromDateTime(DateTime.UtcNow));
                    await Task.Delay(2000, cancellationToken);
                };

            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                stoppingToken.ThrowIfCancellationRequested();
                _logger.LogInformation("The Time is {Time}", TimeOnly.FromDateTime(DateTime.UtcNow));
                await Task.Delay(2000, stoppingToken);
            };
        }
    }


}
