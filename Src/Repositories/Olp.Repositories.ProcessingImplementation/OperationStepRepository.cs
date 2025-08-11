using Olp.Core.ProcessingDomain.Entities;
using Olp.Infrastructure.EntityFramework.ProcessingContext;
using Olp.Repositories.ProcessingAbstractions;
using Olp.Repositories.ProcessingImplementation;


namespace Olp.ProcessingService.Repositories.Implementation;

public class OperationStepRepository(
    ProcessingDbContext dbContext
) : RepositoryBase<OperationStep>(dbContext), IOperationStepRepository
{
}
