using EventBus.Base.Standard;
using Microsoft.Extensions.Logging;

using Olp.RabbitMqTools.Infrastructure.EventBus.Events;


namespace Olp.RabbitMqTools.Infrastructure.EventBus.Services;

public interface IEventBusService
{
    void SendEvent<T>(T @event) where T : EventBase;
}

public class EventBusService(
    IEventBus eventBus,
    ILogger logger
) : IEventBusService
{
    public void SendEvent<T>(T @event)
        where T : EventBase
    {
        try
        {
            eventBus.Publish(@event);
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "Critical error happened during event sending.");
            throw;
        }
    }
}
