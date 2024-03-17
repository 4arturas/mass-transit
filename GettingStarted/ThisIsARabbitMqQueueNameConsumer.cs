using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace GettingStarted
{

    public class SomeData
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class ThisIsARabbitMqQueueNameConsumer : IConsumer<SomeData>
    {
        readonly ILogger<ThisIsARabbitMqQueueNameConsumer> _logger;

        public ThisIsARabbitMqQueueNameConsumer(ILogger<ThisIsARabbitMqQueueNameConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SomeData> context)
        {
            
            string Id = context.Message.Id;
            string Value = context.Message.Value;
            string txt = "Id=" + Id + " Value=" + Value;
            _logger.LogInformation("Received Text: {Text}", txt );

            return Task.CompletedTask;
        }
    }
}