using Olp.Core.ProcessingContracts.Commands;

namespace Olp.Services.ProcessingAbstractions;

public interface IOperationService
{
    Task<CommandBaseResult> ExecCommandAsync(Guid userId, CommandBase commandModel);
}
