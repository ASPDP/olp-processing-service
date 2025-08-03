using Olp.Core.ProcessingContracts.Clients.ProposalServiceClient;
using Olp.Services.ProcessingAbstractions.Clients;


namespace Olp.Services.ProcessingImplementation.Clients;

public class ProposalServiceClient(
    HttpClient httpClient
) : IProposalServiceClient
{
    #region IProposalServiceClient

    public async Task<CreateProposalResponse> CreateProposalAsync(CreateProposalRequest request, CancellationToken cancellationToken = default)
    {
        //var response = await httpClient.PostAsJsonAsync("/api/v1/Proposals", request, cancellationToken);
        //response.EnsureSuccessStatusCode();

        //return await response.Content.ReadFromJsonAsync<CreateProposalResponse>()
        //    ?? throw new InvalidOperationException("Unknown response content.");
        // Dummy
        await Task.CompletedTask;

        return new CreateProposalResponse
        {
            Action = "Response",
            Command = request.Command,
            OperationStepId = request.OperationStepId,
            Result = new()
            {
                Success = true,
                Proposal = new()
                {
                    Id = Guid.NewGuid(),
                    Status = "Create_Pending"
                }
            }
        };
    }

    #endregion
}
