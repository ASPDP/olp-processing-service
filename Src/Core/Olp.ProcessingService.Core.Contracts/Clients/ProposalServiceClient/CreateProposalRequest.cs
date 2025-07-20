using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Olp.ProcessingService.Core.Contracts.Commands.CreateProposal;

namespace Olp.ProcessingService.Core.Contracts.Clients.ProposalServiceClient
{
    public class CreateProposalRequest
    {
        public string Action { get; } = "Request";
        public Guid OperationStepId { get; set; }        
        public required CreateProposalCommand Command { get; set; }
    }
}
