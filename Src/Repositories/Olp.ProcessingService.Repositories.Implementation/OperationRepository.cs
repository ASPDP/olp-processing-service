using Olp.ProcessingService.Core.Domain.Entities;
using Olp.ProcessingService.Infrastructure.EntityFramework;
using Olp.ProcessingService.Repositories.Abstractions;

namespace Olp.ProcessingService.Repositories.Implementation;

public class OperationRepository(
    ProcessingDbContext dbContext
) : RepositoryBase<Operation>(dbContext), IOperationRepository
{
    #region IOperationRepository members

    #endregion
}
