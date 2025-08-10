using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Olp.Core.ProcessingContracts.Models;
using Olp.Services.ProcessingAbstractions;

namespace Olp.ProcessingService.WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class OperationsController(
    IProposalOperationService operationService
) : ControllerBase
{
    /// <summary>
    /// Создать заявку.
    /// </summary>
    /// <param name="request">Модель создания заявки.</param>
    /// <returns>Результат создания заявки.</returns>
    [HttpPost("create-proposal")]
    public async Task<CreateProposalResult> Post([FromBody] CreateProposalModel model)
    {
        var userId = Guid.Parse("a3e3f3e7-3e3f-4e3f-8e3f-3e3f3e3f3e3f");
        return await operationService.CreateProposalAsync(userId, model.Command);
    }
}
