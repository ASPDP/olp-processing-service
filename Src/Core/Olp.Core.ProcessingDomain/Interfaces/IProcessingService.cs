using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olp.Core.ProcessingDomain.Interfaces
{
    public interface IProcessingService
    {
        Task<ProcessingTask> CreateTaskAsync(string payload, CancellationToken cancellationToken);
        Task<ProcessingTask?> GetTaskAsync(Guid id, CancellationToken cancellationToken);
    }
}
