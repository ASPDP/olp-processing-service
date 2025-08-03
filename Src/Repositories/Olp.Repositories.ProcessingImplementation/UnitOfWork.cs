using Olp.Core.ProcessingDomain.Exceptions;
using Olp.Infrastructure.EntityFramework.ProcessingContext;
using Olp.ProcessingService.Repositories.Implementation;
using Olp.Repositories.ProcessingAbstractions;


namespace Olp.Repositories.ProcessingImplementation;

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
