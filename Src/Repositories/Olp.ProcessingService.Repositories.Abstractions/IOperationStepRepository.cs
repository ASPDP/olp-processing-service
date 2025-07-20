using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Olp.ProcessingService.Core.Domain.Entities;


namespace Olp.ProcessingService.Repositories.Abstractions;

public interface IOperationStepRepository : IRepositoryBase<Guid, OperationStep>
{
}
