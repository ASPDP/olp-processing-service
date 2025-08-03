using Olp.Core.ProcessingContracts.Clients.ProposalServiceClient;

namespace Olp.Services.ProcessingAbstractions.Clients;

public interface IProposalServiceClient
{
    Task<CreateProposalResponse> CreateProposalAsync(CreateProposalRequest request, CancellationToken cancellationToken = default);
}
