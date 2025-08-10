using Olp.Core.ProposalContracts.ProposalServiceClient;

namespace Olp.Services.ProcessingAbstractions.Clients;

public interface IProposalServiceClient
{
    Task<PrepareProposalResult> CreateProposalAsync(PrepareProposalModel request, CancellationToken cancellationToken = default);
}
