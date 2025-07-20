using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Olp.ProcessingService.Core.Domain.Entities;
using Olp.ProcessingService.Infrastructure.EntityFramework;
using Olp.ProcessingService.Repositories.Abstractions;


namespace Olp.ProcessingService.Repositories.Implementation;

public class OperationStepRepository(
    ProcessingDbContext dbContext
) : RepositoryBase<OperationStep>(dbContext), IOperationStepRepository
{
}
