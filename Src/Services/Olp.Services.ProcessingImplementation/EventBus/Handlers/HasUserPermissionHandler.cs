using Microsoft.Extensions.Logging;
using Olp.Infrastructure.EventBus.AuthContracts.EventMessages;
using Olp.Infrastructure.EventBus.Interfaces;


namespace Olp.Services.ProcessingImplementation.EventBus.Handlers;

public class HasUserPermissionHandler(
    ILogger<HasUserPermissionHandler> logger
) : IEventHandler<HasUserPermissionEvent>
{
    public async Task HandleMessageAsync(HasUserPermissionEvent message, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation($"Event processing started: OperationStepId = {message.OperationStepId}, Action = {message.Action}.");

            // Event processing stub
            await Task.CompletedTask;

            logger.LogInformation($"Event processing completed: id = OperationStepId = {message.OperationStepId}, Action = {message.Action}");
        }
        catch (Exception ex)
        {
            logger.LogInformation(ex, "Event processing error.");
        }
    }
}
