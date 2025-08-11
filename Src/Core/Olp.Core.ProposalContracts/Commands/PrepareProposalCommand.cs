namespace Olp.Core.ProposalContracts.Commands;


public class PrepareProposalCommand() : CommandBase(nameof(PrepareProposalCommand))
{
    public required PrepareProposalCommandParams Params { get; set; }
}
