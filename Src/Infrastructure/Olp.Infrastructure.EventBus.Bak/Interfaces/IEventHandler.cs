namespace Olp.Infrastructure.EventBus.Interfaces
{
    public interface IEventHandler<T>
        where T: IMessageBase
    {
        Task HandleMessageAsync(T message, CancellationToken cancellationToken = default);
    }
}
