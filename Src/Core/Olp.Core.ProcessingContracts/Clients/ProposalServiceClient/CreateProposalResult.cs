using Olp.Core.ProcessingContracts.Proposal;


namespace Olp.Core.ProcessingContracts.Clients.ProposalServiceClient;

public class CreateProposalResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
    public required ProposalDto Proposal { get; set; }
}
