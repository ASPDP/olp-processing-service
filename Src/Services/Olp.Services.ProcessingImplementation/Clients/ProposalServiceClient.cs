using Olp.Core.ProposalContracts.ProposalServiceClient;
using Olp.Services.ProcessingAbstractions.Clients;


namespace Olp.Services.ProcessingImplementation.Clients;

public class ProposalServiceClient(
    HttpClient httpClient
) : IProposalServiceClient
{
    HttpClient HttpClient { get; } = httpClient;

    #region IProposalServiceClient

    public async Task<PrepareProposalResult> CreateProposalAsync(PrepareProposalModel request, CancellationToken cancellationToken = default)
    {
        //var response = await httpClient.PostAsJsonAsync("/api/v1/Proposals", request, cancellationToken);
        //response.EnsureSuccessStatusCode();

        //return await response.Content.ReadFromJsonAsync<CreateProposalResponse>()
        //    ?? throw new InvalidOperationException("Unknown response content.");
        // Dummy
        await Task.CompletedTask;

        return new()
        {
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
