using Olp.ProcessingService.Core.Contracts.Commands;

namespace Olp.ProcessingService.Services.Abstractions;

public interface IOperationService
{
    Task<BaseCommandResult> ExecCommandAsync(Guid userId, BaseCommand commandModel);
}
