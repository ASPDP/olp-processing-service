using Olp.Core.ProcessingContracts.Operation;
using Olp.Core.ProcessingContracts.Proposal;


namespace Olp.Core.ProcessingContracts.Commands;

public class CreateProposalCommandResult : BaseResultDto
{
    public required OperationDto Operation { get; set; } 
    public required ProposalDto Proposal { get; set; }
}
