using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Olp.ProcessingService.Core.Domain.Exceptions;
using Olp.ProcessingService.Infrastructure.EntityFramework;
using Olp.ProcessingService.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace Olp.ProcessingService.Repositories.Implementation;

public class UnitOfWork(
    ProcessingDbContext dbContext
) : IUnitOfWork
{
    #region IUnitOfWork implementation

    public IOperationRepository OperationRepository { get; } = new OperationRepository(dbContext);
    public IOperationStepRepository OperationStepRepository { get; } = new OperationStepRepository(dbContext);

    public async Task<T> ExecInTransactionAsync<T>(Func<IUnitOfWork, Task<T>> doWorkAsync)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            var result = await doWorkAsync(this);

            // Commit transaction if all commands succeed, transaction will auto-rollback
            // when disposed if either commands fails
            await transaction.CommitAsync();

            return result;
        }
        catch (Exception ex)
        {
            throw new DatabaseException("Database transaction failed.", ex);
        }
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    #endregion
}
