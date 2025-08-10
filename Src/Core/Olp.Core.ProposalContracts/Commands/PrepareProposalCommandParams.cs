namespace Olp.Core.ProposalContracts.Commands;


public class PrepareProposalCommandParams
{
    public required string Title { get; set; }
    public string? Description { get; set; }
}
