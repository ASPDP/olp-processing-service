namespace Olp.Core.ProcessingContracts.Commands;

public class CreateProposalCommandParams
{
    public required string Title { get; set; }
    public string? Description { get; set; }
}
