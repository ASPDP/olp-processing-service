using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Olp.ProcessingService.Core.Contracts.Commands.CreateProposal;


namespace Olp.ProcessingService.Core.Contracts.Clients.ProposalServiceClient;

public class CreateProposalResponse
{
    public Guid OperationStepId { get; set; }
    public required string Action { get; set; }
    public required CreateProposalCommand Command { get; set; }
    public required CreateProposalResult Result { get; set; }
}
