using Olp.Core.ProcessingContracts.Commands;


namespace Olp.Core.ProcessingContracts.Clients.ProposalServiceClient;

public class CreateProposalRequest
{
    public string Action { get; } = "Request";
    public Guid OperationStepId { get; set; }        
    public required CreateProposalCommand Command { get; set; }
}
