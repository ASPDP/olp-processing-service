using Olp.Core.ProcessingContracts.Commands;


namespace Olp.Core.ProcessingContracts.Models;

public class CreateProposalModel
{
    public required CreateProposalCommand Command { get; set; }
}
