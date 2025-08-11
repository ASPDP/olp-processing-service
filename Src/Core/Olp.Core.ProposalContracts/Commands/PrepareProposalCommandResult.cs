using Olp.Core.ProposalContracts.Dtos;


namespace Olp.Core.ProposalContracts.Commands;

public class PrepareProposalCommandResult : CommandResult
{
    public required ProposalDto Proposal { get; set; }
}
