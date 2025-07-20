using EventBus.Base.Standard;

namespace Olp.RabbitMqTools.Infrastructure.EventBus.Events;

/// <summary>
/// </summary>
public class EventBase : IntegrationEvent
{
    public EventBase(string message)
    {
        Message = message;
    }

    public string Message { get; set; } = null!;
}
