using Microsoft.Extensions.Logging;

using Olp.Infrastructure.EventBus.AuthContracts.EventMessages;
using Olp.Infrastructure.EventBus.Interfaces;


namespace Olp.ProcessingService.WebApi.EventBus.Handlers;

public class HasUserPermissionResultHandler(
    ILogger<HasUserPermissionResultHandler> logger
) : IEventHandler<HasUserPermissionEventResult>
{
    public async Task HandleMessageAsync(HasUserPermissionEventResult message, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation($"Event processing started: OperationStepId = {message.OperationStepId}, Actrion = {message.Action}.");

            // Event processing stub
            await Task.CompletedTask;

            logger.LogInformation($"Event processing completed: id = OperationStepId = {message.OperationStepId}, Actrion = {message.Action}");
        }
        catch (Exception ex)
        {
            logger.LogInformation(ex, "Event processing error.");
        }
    }
}
