using EventBus.Base.Standard;
using Microsoft.Extensions.Logging;

using Olp.RabbitMqTools.Infrastructure.EventBus.Events;


namespace Olp.RabbitMqTools.Infrastructure.EventBus.Handlers;

public abstract class EventHandlerBase<T>(
    ILogger logger
) : IIntegrationEventHandler<T>
    where T : EventBase
{
    protected ILogger Logger { get; } = logger;

    protected abstract Task HandleAsync(T @event);

    #region IIntegrationEventHandler<EventBase> members

    public async Task Handle(T @event)
    {
        @event = @event ?? throw new ArgumentNullException(nameof(@event));

        try
        {
            logger.LogInformation($"Event processing started: EventName = {@event.GetType().Name}");

            await HandleAsync(@event);

            logger.LogInformation($"Event processing succeeded: {@event.GetType().Name}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Critical error happened during event processing.");
        }
    }

    #endregion
}
