using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Olp.ProcessingService.Core.Contracts.Clients.ProposalServiceClient;


namespace Olp.ProcessingService.Services.Abstractions.Clients
{
    public interface IProposalServiceClient
    {
        Task<CreateProposalResponse> CreateProposalAsync(CreateProposalRequest request, CancellationToken cancellationToken = default);
    }
}
