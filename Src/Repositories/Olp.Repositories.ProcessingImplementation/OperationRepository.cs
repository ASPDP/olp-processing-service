using Olp.Core.ProcessingDomain.Entities;
using Olp.Infrastructure.EntityFramework.ProcessingContext;
using Olp.Repositories.ProcessingAbstractions;

namespace Olp.Repositories.ProcessingImplementation;

public class OperationRepository(
    ProcessingDbContext dbContext
) : RepositoryBase<Operation>(dbContext), IOperationRepository
{
    #region IOperationRepository members

    #endregion
}
