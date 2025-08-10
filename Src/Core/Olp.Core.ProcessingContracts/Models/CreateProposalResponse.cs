using Olp.Core.ProcessingContracts.Commands;


namespace Olp.Core.ProcessingContracts.Models;

public class CreateProposalResult
{
    public required string CommandName { get; set; }
    public required CreateProposalCommandResult CommandResult { get; set; }
}
