using Olp.ProcessingService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olp.ProcessingService.Repositories.Abstractions;

public interface IOperationRepository : IRepositoryBase<Guid, Operation>
{
}
