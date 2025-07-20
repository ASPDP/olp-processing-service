using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Olp.ProcessingService.Core.Contracts.Proposal;


namespace Olp.ProcessingService.Core.Contracts.Clients.ProposalServiceClient;

public class CreateProposalResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }

    public ProposalDto Proposal { get; set; }
}
