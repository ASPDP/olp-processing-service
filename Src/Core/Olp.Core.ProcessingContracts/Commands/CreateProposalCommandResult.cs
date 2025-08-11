using Olp.Core.ProcessingContracts.Dtos;


namespace Olp.Core.ProcessingContracts.Commands;

public class CreateProposalCommandResult : CommandResult
{
    public OperationDto? Operation { get; set; } 
    public ProposalDto? Proposal { get; set; }
}
