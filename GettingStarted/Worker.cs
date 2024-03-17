using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace GettingStarted
{
    public class Worker : BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string jSon = "{\"time\":\""+DateTimeOffset.Now+"\"}";
                await _bus.Publish(new SomeData{ Id="1", Value = "Some Value"}, stoppingToken);
                // await _bus.Publish(new Message { Text = jSon }, stoppingToken);
                // await _bus.Publish(new Message { Text = $"The time is {DateTimeOffset.Now}" }, stoppingToken);

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}