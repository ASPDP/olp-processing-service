using Olp.Core.ProcessingContracts.Commands;


namespace Olp.Core.ProcessingContracts.Clients.ProposalServiceClient;

public class CreateProposalResponse
{
    public Guid OperationStepId { get; set; }
    public required string Action { get; set; }
    public required CreateProposalCommand Command { get; set; }
    public required CreateProposalResult Result { get; set; }
}
