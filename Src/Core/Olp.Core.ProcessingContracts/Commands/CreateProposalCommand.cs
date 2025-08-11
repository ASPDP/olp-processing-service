namespace Olp.Core.ProcessingContracts.Commands;

public class CreateProposalCommand() : CommandBase(nameof(CreateProposalCommand))
{
    public required CreateProposalCommandParams Params { get; set; }
}
