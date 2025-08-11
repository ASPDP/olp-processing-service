using Olp.Core.ProposalContracts.Commands;


namespace Olp.Core.ProposalContracts.ProposalServiceClient;

public class PrepareProposalModel
{
    public Guid OperationStepId { get; set; }
    public required PrepareProposalCommand Command { get; set; }
}
