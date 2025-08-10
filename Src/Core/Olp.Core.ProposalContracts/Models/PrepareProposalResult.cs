using Olp.Core.ProposalContracts.Commands;


namespace Olp.Core.ProposalContracts.ProposalServiceClient;

public class PrepareProposalResult
{
    public Guid OperationStepId { get; set; }
    public required PrepareProposalCommand Command { get; set; }
    public required PrepareProposalCommandResult Result { get; set; }
}
