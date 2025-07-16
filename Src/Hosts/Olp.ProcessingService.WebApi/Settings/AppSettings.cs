using Olp.ProcessingService.Infrastructure.EntityFramework.Settings;

namespace Olp.ProcessingService.WebApi.Settings
{
    public class AppSettings
    {
        public required DbSettings DbSettings { get; set; }
        public required RabbitMqSettings RabbitMqSettings { get; set; }
    }
}
