using System.Net.Http.Json;

using Olp.ProcessingService.Core.Contracts.Clients.ProposalServiceClient;
using Olp.ProcessingService.Services.Abstractions.Clients;


namespace Olp.ProcessingService.Services.Implementation.Clients;

public class ProposalServiceClient(
    HttpClient httpClient
) : IProposalServiceClient
{
    #region IProposalServiceClient

    public async Task<CreateProposalResponse> CreateProposalAsync(CreateProposalRequest request, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/v1/Proposals", request, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CreateProposalResponse>()
            ?? throw new InvalidOperationException("Unknown response content.");
    }

    #endregion
}
