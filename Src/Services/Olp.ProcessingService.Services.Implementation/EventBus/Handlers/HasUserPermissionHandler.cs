using Microsoft.Extensions.Logging;
using Olp.ProcessingService.WebApi.EventBus.Events;
using Olp.RabbitMqTools.Infrastructure.EventBus.Handlers;


namespace Olp.ProcessingService.WebApi.EventBus.Handlers;

public class HasUserPermissionHandler(
    ILogger<HasUserPermissionHandler> logger
) : EventHandlerBase<HasUserPermissionEvent>(logger)
{
    protected override async Task HandleAsync(HasUserPermissionEvent busEvent)
    {
        try
        {
            Logger.LogInformation($"Event processing started: id = {busEvent.Id}, message = {busEvent.Message}.");

            // Event processing stub
            await Task.CompletedTask;

            Logger.LogInformation($"Event processing completed: id = {busEvent.Id}");
        }
        catch (Exception ex)
        {
            Logger.LogInformation(ex, "Event processing error.");
        }
    }
}
