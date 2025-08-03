namespace Olp.Repositories.ProcessingAbstractions;

public interface IUnitOfWork
{
    IOperationRepository OperationRepository { get; }
    IOperationStepRepository OperationStepRepository { get; }

    Task<T> ExecInTransactionAsync<T>(Func<IUnitOfWork, Task<T>> doWorkAsync);
    Task SaveChangesAsync();
}
