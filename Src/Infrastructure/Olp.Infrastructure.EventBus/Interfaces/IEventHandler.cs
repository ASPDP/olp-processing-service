namespace Olp.Infrastructure.EventBus.Interfaces
{
    public interface IEventHandler<T>
        where T: IEventMessage
    {
        Task HandleMessageAsync(T message, CancellationToken cancellationToken = default);
    }
}
