using EventBus.RabbitMQ.Standard.Options;

using Olp.ProcessingService.Infrastructure.EntityFramework.Settings;


namespace Olp.ProcessingService.WebApi.Settings
{
    public class AppSettings
    {
        public required DbSettings DbSettings { get; set; }
        public required RabbitMqOptions RabbitMqOptions { get; set; }
        public required ProposalServiceSettings ProposalServiceSettings { get; set; }
    }
}
