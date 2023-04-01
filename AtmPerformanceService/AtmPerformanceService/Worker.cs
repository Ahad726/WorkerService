using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AtmPerformanceService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly int _oneSecDelay = 1000;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Log.Information($" Hi there! Service is running at :{DateTime.Now.Minute} min , {DateTime.Now.Second} sec \n");
                await Task.Delay(_oneSecDelay * 5, stoppingToken);
            }
        }
    }
}
