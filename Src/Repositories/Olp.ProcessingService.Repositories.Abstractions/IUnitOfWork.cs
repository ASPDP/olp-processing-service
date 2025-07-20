using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Olp.ProcessingService.Repositories.Abstractions;

public interface IUnitOfWork
{
    IOperationRepository OperationRepository { get; }
    IOperationStepRepository OperationStepRepository { get; }

    Task<T> ExecInTransactionAsync<T>(Func<IUnitOfWork, Task<T>> doWorkAsync);
    Task SaveChangesAsync();
}
