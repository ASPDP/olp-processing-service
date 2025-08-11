using Olp.Core.ProcessingContracts.Commands;
using Olp.Core.ProcessingContracts.Models;


namespace Olp.Services.ProcessingAbstractions;

public interface IProposalOperationService
{
    Task<CreateProposalResult> CreateProposalAsync(Guid userId, CreateProposalCommand command);
}
