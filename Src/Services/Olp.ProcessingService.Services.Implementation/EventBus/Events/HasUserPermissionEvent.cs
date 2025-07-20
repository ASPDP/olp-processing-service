using Olp.RabbitMqTools.Infrastructure.EventBus.Events;

namespace Olp.ProcessingService.WebApi.EventBus.Events;

public class HasUserPermissionEvent(
    string message
) : EventBase(message)
{
}
